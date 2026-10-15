namespace AppServer
{
    partial class FormServer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonStart = new Button();
            buttonSend = new Button();
            textBoxInput = new TextBox();
            textBoxOutput = new TextBox();
            listBoxClients = new ListBox();
            label1 = new Label();
            buttonSendOne = new Button();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(12, 12);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(203, 46);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(688, 748);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(170, 46);
            buttonSend.TabIndex = 1;
            buttonSend.Text = "Send to all";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(12, 64);
            textBoxInput.Multiline = true;
            textBoxInput.Name = "textBoxInput";
            textBoxInput.ReadOnly = true;
            textBoxInput.ScrollBars = ScrollBars.Vertical;
            textBoxInput.Size = new Size(489, 584);
            textBoxInput.TabIndex = 2;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Location = new Point(12, 696);
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.Size = new Size(673, 39);
            textBoxOutput.TabIndex = 3;
            // 
            // listBoxClients
            // 
            listBoxClients.FormattingEnabled = true;
            listBoxClients.Location = new Point(554, 68);
            listBoxClients.Name = "listBoxClients";
            listBoxClients.ScrollAlwaysVisible = true;
            listBoxClients.Size = new Size(304, 580);
            listBoxClients.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(543, 19);
            label1.Name = "label1";
            label1.Size = new Size(91, 32);
            label1.TabIndex = 5;
            label1.Text = "Clients:";
            // 
            // buttonSendOne
            // 
            buttonSendOne.Location = new Point(691, 696);
            buttonSendOne.Name = "buttonSendOne";
            buttonSendOne.Size = new Size(167, 46);
            buttonSendOne.TabIndex = 6;
            buttonSendOne.Text = "Send";
            buttonSendOne.UseVisualStyleBackColor = true;
            buttonSendOne.Click += buttonSendOne_Click;
            // 
            // FormServer
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 809);
            Controls.Add(buttonSendOne);
            Controls.Add(label1);
            Controls.Add(listBoxClients);
            Controls.Add(textBoxOutput);
            Controls.Add(textBoxInput);
            Controls.Add(buttonSend);
            Controls.Add(buttonStart);
            Name = "FormServer";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonStart;
        private Button buttonSend;
        private TextBox textBoxInput;
        private TextBox textBoxOutput;
        private ListBox listBoxClients;
        private Label label1;
        private Button buttonSendOne;
    }
}
