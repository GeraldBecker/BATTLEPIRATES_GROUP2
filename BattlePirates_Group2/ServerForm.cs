﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BattlePirates_Group2 {
    /// <summary>
    /// The form for creating a game by starting a connection
    /// </summary>
    public partial class ServerForm : Form {
        private MainForm screen;
        private bool userQuit;
        private ConnectionManager connection;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="screen"></param>
        public ServerForm(MainForm screen) {
            
            this.screen = screen;
            this.DesktopLocation = screen.Location;
            userQuit = true;

            InitializeComponent();

            connectionPanel.Visible = false;
            connection = new ConnectionManager();
        }

        /// <summary>
        /// Event handle for button click
        /// start server or go back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_click(object sender, EventArgs e) {
            if(sender.Equals(createGameButton)) {
                //Set up the server configuration.
                serverSetup();
            } else if(sender.Equals(backButton)) {
                connection.stopServer();
                screen.Show();
                userQuit = false;
                this.Close();
            }            
        }

        /// <summary>
        /// Setup the server
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
            if(connection.startServer()) {
                createGameButton.Visible = false;
                setStatus("WAITING FOR OPPONENT TO CONNECT...");
                progressBar1.Value = 50;
            } else {
                setStatus("FAILED TO START SERVER.");
                return;
            }
            startServer();
        }

        /// <summary>
        /// Starts the server
        /// </summary>
        public void startServer() {

            Task.Factory.StartNew(() => {
                connection.waitForClient();
                startGamePlacement();
            });

            progressBar1.Value = 75;
        }

        /// <summary>
        /// Starts the ship placement screen in a seperate thread
        /// </summary>
        private void startGamePlacement() {
            MethodInvoker mi = delegate {
                setStatus("CONNECTION SUCCESSFUL");
                progressBar1.Value = 100;
                //Start the ship placement screen.
                new shipPlacementForm(screen, connection, true).Show();

                //Get rid of the connection form.
                userQuit = false;
                this.Close();
            };

            if(InvokeRequired) {
                try {
                    this.Invoke(mi);
                } catch(ObjectDisposedException e) {
                }
            }
        }

        /// <summary>
        /// Sets the status string
        /// </summary>
        /// <param name="msg"></param>
        private void setStatus(string msg) {
            statusLabel.Text = msg;
        }

        /// <summary>
        /// Form closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e) {
            if(userQuit) {
                Application.Exit();
            }
            
        }
    }
}
