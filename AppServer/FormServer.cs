using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO.Pipes;
using System.Text;

namespace AppServer
{
    public partial class FormServer : Form
    {
        private int nextClientId = 0;
        private List<int> clientIds = new();
        private List<NamedPipeServerStream> clientPipes = new();
        public ConcurrentBag<NamedPipeServerStream> allServers = new();
        //List<NamedPipeServerStream> Add/Remove (thread safe usage)
        // NamedPipeServerStream
        // NamedPipeClientStream
        public FormServer()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            //StartPipeServer();
            // Task + Run() -> delegate -> Equals to controlled Thread

            // Task.Run(delegate () { StartPipeServer(); });
            //_ = Task.Run( () => StartPipeServer()); // StartPipeServer method
            Task.Run(() => StartPipeServer()); // StartPipeServer method
                                               // will be started in a different Thread
                                               // delegate to lambdas: "delegate" -> " => "
            Task.Run(() => PingClients());
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SendToAll();
        }

        private void StartPipeServer()
        {
            while (true)
            {
                var server = new NamedPipeServerStream("Server511",
                    PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances,
                    PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
                server.WaitForConnection();
                //
                int clientId = ++nextClientId;
                allServers.Add(server);
                lock(clientIds)
                {
                    clientIds.Add(clientId);
                    clientPipes.Add(server);
                }
                listBoxClients.Invoke(new Action(() =>
                    listBoxClients.Items.Add($"Client{clientId}")));
                byte[] bytes = Encoding.UTF8.GetBytes($"Client{clientId}");
                server.Write(bytes, 0, bytes.Length);

                Task.Run(() => HandleClient(server, clientId));
                //Tread thread = new Thread(HandleClient)

                //Task.Run(() => HandleClient(server));
                //HandleClient(server);
            }
        }

        private void HandleClient(NamedPipeServerStream server, int clientId)
        {
            // client can be active at least 5 hours
            try
            {
                while (server.IsConnected)
                {
                    Debug.WriteLine($"Server is waiting for data.");

                    byte[] buffer = new byte[256];
                    int bytesRead = server.Read(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Debug.WriteLine($"Client: {message}" + Environment.NewLine);

                    textBoxInput.Invoke(new Action(() => textBoxInput.Text
                        += $"Client{clientId}: {message}" +
                        Environment.NewLine)); // we should handle client name OR Id
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while connecting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                listBoxClients.Invoke(new Action(() =>
                    listBoxClients.Items.Remove($"Client{clientId}")));
                lock (clientIds)
                {
                    int index = clientIds.IndexOf(clientId);
                    if (index >= 0)
                    {
                        clientIds.RemoveAt(index);
                        clientPipes.RemoveAt(index);
                    }
                }
                allServers.TryTake(out server!);
                server?.Dispose();
            }
        }

        private void Send(NamedPipeServerStream server)
        {
            string message = textBoxOutput.Text;

            if (!string.IsNullOrEmpty(message))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                server.Write(bytes, 0, bytes.Length);
            }
        }

        private void SendToAll()

        {
            // Parallel.ForEach(allServers, s => Send(s));
            NamedPipeServerStream server1 = allServers.First();
            foreach (NamedPipeServerStream server in allServers)
            {
                Send(server);
            }
        }
        private async Task PingClients()
        {
            while (true)
            {
                await Task.Delay(5000);
                foreach (var server in allServers)
                {
                    if (server.IsConnected)
                    {
                        try
                        {
                            byte[] bytes = Encoding.UTF8.GetBytes("Ping");
                            server.Write(bytes, 0, bytes.Length);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }

        private void buttonSendOne_Click(object sender, EventArgs e)
        {
            if (listBoxClients.SelectedItem == null) return;

            string selectedClient = listBoxClients.SelectedItem.ToString()!;
            int selectedId = int.Parse(selectedClient.Replace("Client", ""));
            string message = textBoxOutput.Text;

            if (string.IsNullOrWhiteSpace(message)) return;

            lock (clientIds)
            {
                int index = clientIds.IndexOf(selectedId);

                if (index >= 0 && clientPipes[index].IsConnected)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(message);
                    clientPipes[index].Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
}
