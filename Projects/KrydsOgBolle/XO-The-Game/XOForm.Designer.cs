namespace XO_The_Game
{
    partial class XOForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.buttonHost = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(349, 8);
            this.textBoxIP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(163, 20);
            this.textBoxIP.TabIndex = 0;
            // 
            // buttonHost
            // 
            this.buttonHost.Location = new System.Drawing.Point(69, 8);
            this.buttonHost.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonHost.Name = "buttonHost";
            this.buttonHost.Size = new System.Drawing.Size(50, 18);
            this.buttonHost.TabIndex = 1;
            this.buttonHost.Text = "HOST";
            this.buttonHost.UseVisualStyleBackColor = true;
            this.buttonHost.Click += new System.EventHandler(this.buttonHost_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(282, 8);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(63, 17);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(161, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // XOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 484);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonHost);
            this.Controls.Add(this.textBoxIP);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "XOForm";
            this.Text = "The Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button buttonHost;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button button1;
    }
}

