using System.Diagnostics;
using System.IO.Pipes;
using System.Text;

namespace AppClient
{
    public partial class FormClient : Form
    {
        private NamedPipeClientStream pipeClient;
        private string clientId = "";
        public FormClient()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Task.Run(() => Connect());
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            Task.Run(() => Send());
        }

        private void Connect()
        {
            try
            {
                buttonConnect.Invoke(
                    new Action(() => buttonConnect.Enabled = false));

                pipeClient = new NamedPipeClientStream(".", "Server511",
                    PipeDirection.InOut, PipeOptions.Asynchronous);
                pipeClient.Connect(2000);
                byte[] buffer = new byte[256];
                int bytesRead = pipeClient.Read(buffer, 0, buffer.Length);
                clientId = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                textBoxClientId.Invoke(new Action(() =>
                    textBoxClientId.Text = clientId));

                Debug.WriteLine($"Client connected.");

                Task.Run(() => Receive());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while connecting: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonConnect.Invoke(new Action(() =>
                    buttonConnect.Enabled = true));
            }
        }

        private void Receive()
        {
            try
            {
                while (pipeClient != null && pipeClient.IsConnected)
                {
                    Debug.WriteLine($"Client is waiting for data.");

                    byte[] buffer = new byte[256];
                    int bytesRead = pipeClient.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    if(response.Contains("Ping"))
                    {
                        string message = $"Pong";
                        byte[] bytes = Encoding.UTF8.GetBytes(message);
                        pipeClient.Write(bytes, 0, bytes.Length);
                    }

                    textBoxInput.Invoke(new Action(() => textBoxInput.Text += response + Environment.NewLine));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while receiving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Send()
        {
            try
            {
                if (pipeClient != null && pipeClient.IsConnected)
                {
                    string message = $"{textBoxOutput.Text}";

                    if (!string.IsNullOrEmpty(message))
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(message);
                        pipeClient.Write(bytes, 0, bytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while sending: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
