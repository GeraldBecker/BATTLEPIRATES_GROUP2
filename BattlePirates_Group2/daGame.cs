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
    public partial class daGame : Form {

        private ConnectionManager connection;
        private MainForm owner;
        private bool myTurn;
        private bool host;

        private GameBoard mine;
        private GameBoard opponent;

        private const int SPACER = 300;

        public daGame(MainForm owner, ConnectionManager connection, bool whosTurn) {
            InitializeComponent();
            this.connection = connection;
            this.owner = owner;
            this.DesktopLocation = owner.Location;


            myTurn = host = whosTurn;

            
            mine = new GameBoard();
            opponent = new GameBoard();

            
        }

        /*private void taskGetData() {
            Task.Factory.StartNew(() => {
                Console.WriteLine("TRYING TO GET THE BOARD");
                _grid = connection.getData2();
                Console.WriteLine("GOT THE BOARD");
                isTurn = true;
                checkTurn();
            });
        }

        private void checkTurn() {
            if(!this.InvokeRequired) {
                if(isTurn) {
                } else {
                    //If a move is made, call and create a task to wait to receive data.
                    taskGetData();
                }
                this.Refresh();
            } else
                this.Invoke((MethodInvoker)delegate {
                    checkTurn();
                });
        }*/

        private void daGame_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }

        private void daGame_Paint(object sender, PaintEventArgs e) {
            LocationState[,] _grid = mine.getBoardForDrawing();
            for(int r = 0; r < 10; r++) {
                for(int c = 0; c < 10; c++) {
                    if(mine.hasShip(new Point(r, c)))
                        e.Graphics.FillRectangle(new SolidBrush(Color.OrangeRed), c * 25, r * 25, 20, 20);
                    else if(_grid[r, c] == LocationState.EMPTY)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Aqua), c * 25, r * 25, 20, 20);
                    else if(_grid[r, c] == LocationState.HIT)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Red), c * 25, r * 25, 20, 20);
                    else if(_grid[r, c] == LocationState.MISS)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Purple), c * 25, r * 25, 20, 20);
                    
                }
                Console.WriteLine();
            }



            LocationState[,] _grid2 = opponent.getBoardForDrawing();
            for(int r = 0; r < 10; r++) {
                for(int c = 0; c < 10; c++) {
                    if(mine.hasShip(new Point(r, c)))
                        e.Graphics.FillRectangle(new SolidBrush(Color.OrangeRed), c * 25 + SPACER, r * 25, 20, 20);
                    else if(_grid2[r, c] == LocationState.EMPTY)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Aqua), c * 25 + SPACER, r * 25, 20, 20);
                    else if(_grid2[r, c] == LocationState.HIT)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Red), c * 25 + SPACER, r * 25, 20, 20);
                    else if(_grid2[r, c] == LocationState.MISS)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Purple), c * 25 + SPACER, r * 25, 20, 20);

                }
                Console.WriteLine();
            }
        }



    }
}
