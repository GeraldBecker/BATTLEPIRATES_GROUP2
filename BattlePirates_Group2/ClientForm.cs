using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
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

            setStatus("ATTEMPTING TO CREATE CONNECTION...");

            
            progressBar2.Value = 10;

            //Sets the IP Address of the host to connect to.
            if(connection.initiateClient(ipAddressConnect.Text)) {
                progressBar2.Value = 25;
                setStatus("STARTING CONNECTION");
            } else {
                progressBar2.Value = 100;
                setStatus("FAILED");
                return;
            }

            if(connection.clientConnect()) {
                progressBar2.Value = 100;
                setStatus("CONNECTION SUCCESSFUL");
                
            } else {
                progressBar2.Value = 100;
                setStatus("CONNECTION FAILED");
                return;
            }

            
            //Start the ship placement screen.
            new tempoClass(screen, connection, false).Show();

            //Get rid of the connection form.
            userQuit = false;
            this.Close();
        }


        private void setStatus(string msg) {
            statusLabel.Text = msg;
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e) {
            if(userQuit) {
                Application.Exit();
            }
        }
    }
}
