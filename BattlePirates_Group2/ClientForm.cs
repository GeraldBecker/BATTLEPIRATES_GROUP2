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
using System.Media;

namespace BattlePirates_Group2 {
    /// <summary>
    /// Client form for connecting to a game
    /// </summary>
    public partial class ClientForm : Form {
        //protocol for connection
        private ConnectionManager connection;

        //the form to replace this form with
        private MainForm screen;

        //if user clicks back button
        private bool userQuit;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="screen">
        /// The form that calls - initial splash screen
        /// </param>
        public ClientForm(MainForm screen) {
            //replaces the splash screen at it's location
            this.screen = screen;
            this.DesktopLocation = screen.Location;

            InitializeComponent();
            userQuit = true;
            connection = new ConnectionManager();
        }

        /// <summary>
        /// botton click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClick(object sender, EventArgs e) {
            //if connect game button pressed
            if(sender.Equals(connectGameButton)) {
                clientConnect();
            //if back button pressed
            } else if(sender.Equals(backButton)) {
                connection.stopServer();
                screen.Show();
                userQuit = false;
                this.Close();
            } 
        }

        /// <summary>
        /// Connection for client
        /// shows progress
        /// </summary>
        public void clientConnect() {
            progressBar2.Maximum = 100;
            connectGameButton.Visible = false;

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
            new shipPlacementForm(screen, connection, false).Show();

            //Get rid of the connection form.
            userQuit = false;
            this.Close();
        }

        /// <summary>
        /// Sets the label output
        /// </summary>
        /// <param name="msg">
        /// the message to display
        /// </param>
        private void setStatus(string msg) {
            statusLabel.Text = msg;
        }

        /// <summary>
        /// Form closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e) {
            if(userQuit) {
                Application.Exit();
            }
        }
    }
}
