using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattlePirates_Group2 {
    public partial class ServerForm : Form {
        private MainForm screen;
        private bool userQuit;

        public ServerForm(MainForm screen) {
            
            this.screen = screen;

            this.DesktopLocation = screen.Location;

            userQuit = true;

            InitializeComponent();


            connectionPanel.Visible = false;

        }

        private void button_click(object sender, EventArgs e) {
            if(sender.Equals(createGameButton)) {
                connectionPanel.Visible = true;
                backButton.Visible = false;
                createGameButton.Visible = false;

                statusLabel.Text = "ATTEMPTING TO CREATE CONNECTION";

                new ConnectionManager();

            } else if(sender.Equals(backButton) || sender.Equals(backButton2)) {
                screen.Show();
                userQuit = false;
                this.Close();
            } 

            
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e) {
            if(userQuit) {
                Application.Exit();
            }
            
        }
    }
}
