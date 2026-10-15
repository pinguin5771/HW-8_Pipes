namespace AppClient
{
    partial class FormClient
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
            buttonConnect = new Button();
            buttonSend = new Button();
            textBoxInput = new TextBox();
            textBoxOutput = new TextBox();
            textBoxClientId = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(12, 448);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(150, 46);
            buttonConnect.TabIndex = 0;
            buttonConnect.Text = "Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(616, 451);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(150, 46);
            buttonSend.TabIndex = 1;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new Point(12, 90);
            textBoxInput.Multiline = true;
            textBoxInput.Name = "textBoxInput";
            textBoxInput.ReadOnly = true;
            textBoxInput.ScrollBars = ScrollBars.Vertical;
            textBoxInput.Size = new Size(754, 323);
            textBoxInput.TabIndex = 2;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Location = new Point(182, 455);
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.Size = new Size(412, 39);
            textBoxOutput.TabIndex = 3;
            // 
            // textBoxClientId
            // 
            textBoxClientId.Location = new Point(78, 23);
            textBoxClientId.Name = "textBoxClientId";
            textBoxClientId.ReadOnly = true;
            textBoxClientId.Size = new Size(431, 39);
            textBoxClientId.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(42, 32);
            label1.TabIndex = 5;
            label1.Text = "ID:";
            // 
            // FormClient
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 518);
            Controls.Add(label1);
            Controls.Add(textBoxClientId);
            Controls.Add(textBoxOutput);
            Controls.Add(textBoxInput);
            Controls.Add(buttonSend);
            Controls.Add(buttonConnect);
            Name = "FormClient";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonConnect;
        private Button buttonSend;
        private TextBox textBoxInput;
        private TextBox textBoxOutput;
        private TextBox textBoxClientId;
        private Label label1;
    }
}
