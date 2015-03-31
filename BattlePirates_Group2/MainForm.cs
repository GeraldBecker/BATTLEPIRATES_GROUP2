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
    /// <summary>
    /// Splash Screen
    /// </summary>
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        /// <summary>
        /// Button click event
        /// determines if player wants to create a game
        /// or connect to a game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClick(object sender, EventArgs e) {
            if(sender.Equals(createButton)) {
                this.Hide();
                //Player selected to create game
                ServerForm server = new ServerForm(this);
                server.Show();
            } else if(sender.Equals(connectButton)) {
                this.Hide();
                //Player selected to connect to a game
                ClientForm client = new ClientForm(this);
                client.Show();
            }
        }
    }
}
