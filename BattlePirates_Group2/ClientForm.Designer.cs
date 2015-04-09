namespace BattlePirates_Group2 {
    partial class ClientForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.label3 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.ipAddressConnect = new System.Windows.Forms.TextBox();
            this.connectGameButton = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Garamond", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(266, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "BATTLE PIRATES";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Garamond", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(96, 158);
            this.statusLabel.MaximumSize = new System.Drawing.Size(580, 100);
            this.statusLabel.MinimumSize = new System.Drawing.Size(580, 100);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(580, 100);
            this.statusLabel.TabIndex = 7;
            this.statusLabel.Text = "ENTER IP ADDRESS TO CONNECT TO:";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ipAddressConnect
            // 
            this.ipAddressConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.ipAddressConnect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ipAddressConnect.Font = new System.Drawing.Font("Garamond", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressConnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(189)))), ((int)(((byte)(0)))));
            this.ipAddressConnect.Location = new System.Drawing.Point(273, 272);
            this.ipAddressConnect.MaximumSize = new System.Drawing.Size(260, 50);
            this.ipAddressConnect.MinimumSize = new System.Drawing.Size(260, 50);
            this.ipAddressConnect.Name = "ipAddressConnect";
            this.ipAddressConnect.Size = new System.Drawing.Size(260, 47);
            this.ipAddressConnect.TabIndex = 8;
            this.ipAddressConnect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // connectGameButton
            // 
            this.connectGameButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.connectGameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(20)))), ((int)(((byte)(243)))));
            this.connectGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectGameButton.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectGameButton.ForeColor = System.Drawing.Color.White;
            this.connectGameButton.Location = new System.Drawing.Point(333, 369);
            this.connectGameButton.Name = "connectGameButton";
            this.connectGameButton.Size = new System.Drawing.Size(131, 54);
            this.connectGameButton.TabIndex = 9;
            this.connectGameButton.Text = "CONNECT";
            this.connectGameButton.UseVisualStyleBackColor = false;
            this.connectGameButton.Click += new System.EventHandler(this.buttonClick);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(222, 114);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(380, 41);
            this.progressBar2.TabIndex = 10;
            // 
            // backButton
            // 
            this.backButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(20)))), ((int)(((byte)(243)))));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(333, 442);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(131, 54);
            this.backButton.TabIndex = 11;
            this.backButton.Text = "BACK";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.buttonClick);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.connectGameButton);
            this.Controls.Add(this.ipAddressConnect);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Battle Pirates";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox ipAddressConnect;
        private System.Windows.Forms.Button connectGameButton;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button backButton;
    }
}