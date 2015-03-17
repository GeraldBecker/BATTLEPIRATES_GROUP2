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
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void buttonClick(object sender, EventArgs e) {
            if(sender.Equals(createButton)) {
                this.Hide();
                //this.DesktopLocation = 
                ServerForm server = new ServerForm(this);
                server.Show();
            } else if(sender.Equals(connectButton)) {
                this.Hide();
                //this.DesktopLocation = 
                ClientForm client = new ClientForm(this);
                client.Show();
            }
            
            
        }
    }
}
