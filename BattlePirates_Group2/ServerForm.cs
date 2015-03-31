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
            connection = new ConnectionManager();
        }

        private void button_click(object sender, EventArgs e) {
            if(sender.Equals(createGameButton)) {
                //Set up the server configuration.
                serverSetup();
            } else if(sender.Equals(backButton)) {
                connection.stopServer();
                screen.Show();
                userQuit = false;
                this.Close();
            } else if(sender.Equals(pressButton)) {
                //Start the server connection once it has been configured.
                startServer();
            }             
        }

        /// <summary>
        /// 
        /// </summary>
        private void serverSetup() {
            progressBar1.Maximum = 100;
            connectionPanel.Visible = true;
            createGameButton.Text = "TRY AGAIN";

            setStatus("ATTEMPTING TO CREATE CONNECTION...");

            //update the status bar
            progressBar1.Value = 10;

            //Gets the hosts IP Address.
            if(connection.initiateServer()) {
                ipAddress.Text = connection.getIPString();
                setStatus("STARTING CONNECTION");
                //update the status bar
                progressBar1.Value = 25;
            } else {
                setStatus("FAILED TO CREATE SERVER.");
                return;
            }
            
            //Starts the server connection and waits for a client to connect.
            //Note: ***This currently causes the screen to freeze until a connection is made***
            if(connection.startServer()) {
                createGameButton.Visible = false;
                setStatus("WAITING FOR OPPONENT TO CONNECT...");
                progressBar1.Value = 50;
            } else {
                setStatus("FAILED TO START SERVER.");
                return;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public void startServer() {

            connection.waitForClient();
            setStatus("CONNECTION SUCCESSFUL");
            progressBar1.Value = 100;

            //Start the ship placement screen.
            //new shipPlaceForm(screen, connection, true).Show();
            //new gameForm(screen, connection, true).Show();
            //new daGame(screen, connection, true).Show();
            new shipPlacementForm(screen, connection, true).Show();

            //Get rid of the connection form.
            userQuit = false;
            this.Close();
        }

        private void setStatus(string msg) {
            statusLabel.Text = msg;
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e) {
            if(userQuit) {
                Application.Exit();
            }
            
        }
    }
}
