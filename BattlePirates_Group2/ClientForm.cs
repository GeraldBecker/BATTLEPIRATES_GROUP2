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


        public ClientForm(MainForm screen) {
            InitializeComponent();
        }

        private void buttonClick(object sender, EventArgs e) {
            if(sender.Equals(connectGameButton)) {
                
            }
        }

        public void clientConnect() {
            progressBar2.Maximum = 100;
            connectGameButton.Visible = false;
            //connectGameButton.Text = "TRY AGAIN";

            statusLabel.Text = "ATTEMPTING TO CREATE CONNECTION...";

            connection = new ConnectionManager();
            progressBar2.Value = 10;
            /*
            if(connection.initiateServer()) {
                ipAddress.Text = connection.getIPString();
                statusLabel.Text = "STARTING CONNECTION";
                progressBar2.Value = 25;
            } else {
                statusLabel.Text = "FAILED TO CREATE SERVER.";
                return;
            }*/
            /*
            if(connection.startServer()) {
                createGameButton.Visible = false;
                statusLabel.Text = "WAITING FOR OPPONENT TO CONNECT...";
                setLabel("WAITING FOR OPPONENT TO CONNECT...");
                Console.WriteLine("Started server");
                progressBar2.Value = 50;
            } else {
                statusLabel.Text = "FAILED TO START SERVER.";
                return;
            }*/

            //This line of code is giving errors.
            //connection.getClient();
            statusLabel.Text = "CONNECTION SUCCESSFUL";
            progressBar2.Value = 100;
        }
    }
}
