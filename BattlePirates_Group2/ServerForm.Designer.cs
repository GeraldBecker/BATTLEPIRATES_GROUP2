namespace BattlePirates_Group2 {
    partial class ServerForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.createGameButton = new System.Windows.Forms.Button();
            this.connectionPanel = new System.Windows.Forms.Panel();
            this.ipAddress = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pressButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.connectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Garamond", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(265, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "BATTLE PIRATES";
            // 
            // backButton
            // 
            this.backButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(20)))), ((int)(((byte)(243)))));
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(332, 491);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(131, 54);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "BACK";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.button_click);
            // 
            // createGameButton
            // 
            this.createGameButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.createGameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(20)))), ((int)(((byte)(243)))));
            this.createGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createGameButton.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createGameButton.ForeColor = System.Drawing.Color.White;
            this.createGameButton.Location = new System.Drawing.Point(332, 109);
            this.createGameButton.Name = "createGameButton";
            this.createGameButton.Size = new System.Drawing.Size(131, 54);
            this.createGameButton.TabIndex = 2;
            this.createGameButton.Text = "CREATE GAME";
            this.createGameButton.UseVisualStyleBackColor = false;
            this.createGameButton.Click += new System.EventHandler(this.button_click);
            // 
            // connectionPanel
            // 
            this.connectionPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.connectionPanel.Controls.Add(this.pressButton);
            this.connectionPanel.Controls.Add(this.ipAddress);
            this.connectionPanel.Controls.Add(this.statusLabel);
            this.connectionPanel.Controls.Add(this.label2);
            this.connectionPanel.ForeColor = System.Drawing.Color.White;
            this.connectionPanel.Location = new System.Drawing.Point(104, 185);
            this.connectionPanel.Name = "connectionPanel";
            this.connectionPanel.Size = new System.Drawing.Size(600, 257);
            this.connectionPanel.TabIndex = 3;
            // 
            // ipAddress
            // 
            this.ipAddress.AutoSize = true;
            this.ipAddress.Font = new System.Drawing.Font("Garamond", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(183)))), ((int)(((byte)(61)))));
            this.ipAddress.Location = new System.Drawing.Point(180, 191);
            this.ipAddress.MaximumSize = new System.Drawing.Size(250, 40);
            this.ipAddress.MinimumSize = new System.Drawing.Size(250, 40);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(250, 40);
            this.ipAddress.TabIndex = 6;
            this.ipAddress.Text = "###.###.#.###";
            this.ipAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Garamond", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(18, 28);
            this.statusLabel.MaximumSize = new System.Drawing.Size(550, 100);
            this.statusLabel.MinimumSize = new System.Drawing.Size(550, 100);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(550, 100);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "WAITING FOR OPPONENT";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Garamond", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(193, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "YOUR IP ADDRESS:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(348, 82);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // pressButton
            // 
            this.pressButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pressButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(20)))), ((int)(((byte)(243)))));
            this.pressButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pressButton.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pressButton.ForeColor = System.Drawing.Color.White;
            this.pressButton.Location = new System.Drawing.Point(517, 49);
            this.pressButton.Name = "pressButton";
            this.pressButton.Size = new System.Drawing.Size(67, 49);
            this.pressButton.TabIndex = 5;
            this.pressButton.Text = "PRESS";
            this.pressButton.UseVisualStyleBackColor = false;
            this.pressButton.Click += new System.EventHandler(this.button_click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(621, 491);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.createGameButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectionPanel);
            this.Name = "ServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ServerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.connectionPanel.ResumeLayout(false);
            this.connectionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button createGameButton;
        private System.Windows.Forms.Panel connectionPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ipAddress;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button pressButton;
        private System.Windows.Forms.Button button1;
    }
}