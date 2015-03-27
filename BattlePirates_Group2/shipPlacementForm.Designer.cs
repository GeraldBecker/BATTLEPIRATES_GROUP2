namespace BattlePirates_Group2 {
    partial class shipPlacementForm {
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
            this.startGameButton = new System.Windows.Forms.Button();
            this.battlePiratesLabel = new System.Windows.Forms.Label();
            this.placeShipsLabel = new System.Windows.Forms.Label();
            this.placeShipsSubLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startGameButton
            // 
            this.startGameButton.BackColor = System.Drawing.Color.Blue;
            this.startGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startGameButton.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startGameButton.ForeColor = System.Drawing.Color.White;
            this.startGameButton.Location = new System.Drawing.Point(626, 400);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(111, 71);
            this.startGameButton.TabIndex = 0;
            this.startGameButton.Text = "Start Game";
            this.startGameButton.UseVisualStyleBackColor = false;
            this.startGameButton.Click += new System.EventHandler(this.startGame_click);
            // 
            // battlePiratesLabel
            // 
            this.battlePiratesLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.battlePiratesLabel.AutoSize = true;
            this.battlePiratesLabel.Font = new System.Drawing.Font("Garamond", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.battlePiratesLabel.ForeColor = System.Drawing.Color.White;
            this.battlePiratesLabel.Location = new System.Drawing.Point(187, 20);
            this.battlePiratesLabel.Name = "battlePiratesLabel";
            this.battlePiratesLabel.Size = new System.Drawing.Size(409, 54);
            this.battlePiratesLabel.TabIndex = 7;
            this.battlePiratesLabel.Text = "BATTLE PIRATES";
            // 
            // placeShipsLabel
            // 
            this.placeShipsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.placeShipsLabel.AutoSize = true;
            this.placeShipsLabel.Font = new System.Drawing.Font("Garamond", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeShipsLabel.ForeColor = System.Drawing.Color.White;
            this.placeShipsLabel.Location = new System.Drawing.Point(229, 94);
            this.placeShipsLabel.Name = "placeShipsLabel";
            this.placeShipsLabel.Size = new System.Drawing.Size(322, 36);
            this.placeShipsLabel.TabIndex = 8;
            this.placeShipsLabel.Text = "PLACE YOUR SHIPS";
            // 
            // placeShipsSubLabel
            // 
            this.placeShipsSubLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.placeShipsSubLabel.AutoSize = true;
            this.placeShipsSubLabel.Font = new System.Drawing.Font("Garamond", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeShipsSubLabel.ForeColor = System.Drawing.Color.Red;
            this.placeShipsSubLabel.Location = new System.Drawing.Point(442, 163);
            this.placeShipsSubLabel.Name = "placeShipsSubLabel";
            this.placeShipsSubLabel.Size = new System.Drawing.Size(230, 27);
            this.placeShipsSubLabel.TabIndex = 9;
            this.placeShipsSubLabel.Text = "PLACE YOUR SHIPS";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(41, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(29, 278);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Garamond", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Garamond", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Garamond", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Garamond", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Garamond", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Garamond", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Garamond", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Garamond", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 24);
            this.label8.TabIndex = 7;
            this.label8.Text = "8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Garamond", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 24);
            this.label9.TabIndex = 8;
            this.label9.Text = "9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Garamond", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 24);
            this.label10.TabIndex = 9;
            this.label10.Text = "10";
            // 
            // shipPlacementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.placeShipsSubLabel);
            this.Controls.Add(this.placeShipsLabel);
            this.Controls.Add(this.battlePiratesLabel);
            this.Controls.Add(this.startGameButton);
            this.Name = "shipPlacementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "shipPlacementForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.shipPlacementForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.shipPlacementForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.shipPlacementForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.shipPlacementForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.shipPlacementForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.shipPlacementForm_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.Label battlePiratesLabel;
        private System.Windows.Forms.Label placeShipsLabel;
        private System.Windows.Forms.Label placeShipsSubLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}