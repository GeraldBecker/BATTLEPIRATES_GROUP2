namespace BattlePirates_Group2 {
    partial class daGame {
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
            this.waitPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.waitPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // waitPanel
            // 
            this.waitPanel.BackColor = System.Drawing.Color.DarkRed;
            this.waitPanel.Controls.Add(this.label1);
            this.waitPanel.Location = new System.Drawing.Point(561, 354);
            this.waitPanel.Name = "waitPanel";
            this.waitPanel.Size = new System.Drawing.Size(200, 100);
            this.waitPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Garamond", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(45, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "WAIT";
            // 
            // daGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.waitPanel);
            this.Name = "daGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "daGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.daGame_FormClosing);
            this.Load += new System.EventHandler(this.daGame_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.daGame_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daGame_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.daGame_MouseUp);
            this.waitPanel.ResumeLayout(false);
            this.waitPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel waitPanel;
        private System.Windows.Forms.Label label1;
    }
}