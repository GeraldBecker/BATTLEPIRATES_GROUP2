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
        private ConnectionManager connection;

        public ServerForm(MainForm screen) {
            
            this.screen = screen;

            this.DesktopLocation = screen.Location;

            userQuit = true;

            InitializeComponent();

            
            connectionPanel.Visible = false;

        }

        private void button_click(object sender, EventArgs e) {
            if(sender.Equals(createGameButton)) {
                /*connectionPanel.Visible = true;
                backButton.Visible = false;
                createGameButton.Visible = false;

                statusLabel.Text = "ATTEMPTING TO CREATE CONNECTION";

                connection = new ConnectionManager();

                //ipAddress.Text = connection.getIPString();*/
                serverConnect();
            } else if(sender.Equals(backButton)) {
                connection.stopServer();
                screen.Show();
                userQuit = false;
                this.Close();
            } 

            
        }


        private void serverConnect() {
            progressBar1.Maximum = 100;
            connectionPanel.Visible = true;
            //createGameButton.Visible = false;
            createGameButton.Text = "TRY AGAIN";

            statusLabel.Text = "ATTEMPTING TO CREATE CONNECTION...";

            connection = new ConnectionManager();
            progressBar1.Value = 10;
            if(connection.initiateServer()) {
                ipAddress.Text = connection.getIPString();
                statusLabel.Text = "STARTING CONNECTION";
                progressBar1.Value = 25;
            } else {
                statusLabel.Text = "FAILED TO CREATE SERVER.";
                return;
            }

            if(connection.startServer()) {
                createGameButton.Visible = false;
                statusLabel.Text = "WAITING FOR OPPONENT TO CONNECT...";
                setLabel("WAITING FOR OPPONENT TO CONNECT...");
                Console.WriteLine("Started server");
                progressBar1.Value = 50;
            } else {
                statusLabel.Text = "FAILED TO START SERVER.";
                return;
            }

            //This line of code is giving errors.
            //connection.getClient();
            statusLabel.Text = "CONNECTION SUCCESSFUL";
            progressBar1.Value = 100;
        }

        private void setLabel(string msg) {
            statusLabel.Text = msg;
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e) {
            if(userQuit) {
                Application.Exit();
            }
            
        }
    }
}
