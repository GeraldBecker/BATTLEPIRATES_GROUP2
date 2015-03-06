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
            this.SuspendLayout();
            // 
            // daGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Name = "daGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "daGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.daGame_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.daGame_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}