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
    public partial class ClientForm : Form {
        private ConnectionManager connection;
        private MainForm screen;
        private bool userQuit;

        public ClientForm(MainForm screen) {
            this.screen = screen;
            this.DesktopLocation = screen.Location;

            InitializeComponent();
            userQuit = true;
            connection = new ConnectionManager();
        }

        private void buttonClick(object sender, EventArgs e) {
            if(sender.Equals(connectGameButton)) {
                clientConnect();
            } else if(sender.Equals(backButton)) {
                connection.stopServer();
                screen.Show();
                userQuit = false;
                this.Close();
            } 
        }

        public void clientConnect() {
            progressBar2.Maximum = 100;
            connectGameButton.Visible = false;
            //connectGameButton.Text = "TRY AGAIN";

            statusLabel.Text = "ATTEMPTING TO CREATE CONNECTION...";

            
            progressBar2.Value = 10;

            if(connection.initiateClient(ipAddressConnect.Text)) {
                
                progressBar2.Value = 25;
                statusLabel.Text = "STARTING CONNECTION";
            } else {
                statusLabel.Text = "FAILED";
                return;
            }

            if(connection.clientConnect()) {
                statusLabel.Text = "CONNECTION SUCCESSFUL";
                progressBar2.Value = 100;
            } else {
                statusLabel.Text = "CONNECTION FAILED";
                return;
            }

            
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e) {
            if(userQuit) {
                Application.Exit();
            }
        }
    }
}
