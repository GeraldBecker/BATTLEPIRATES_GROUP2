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
    public partial class shipPlacementForm : Form {
        public shipPlacementForm() {
            InitializeComponent();



        }

        private void shipPlacementForm_Paint(object sender, PaintEventArgs e) {
            for(int r = 0; r < 10; r++) {
                for(int c = 0; c < 10; c++) {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Aqua), c * 25, r * 25, 20, 20);
                    
                }
            }
        }
    }
}
