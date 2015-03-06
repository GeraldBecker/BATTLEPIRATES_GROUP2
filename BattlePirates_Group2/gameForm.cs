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
    public partial class gameForm : Form {
        public enum _types { MW, GA, BR, BA };
        public enum SquareState { Empty, Miss, Hit, MW, GA, BR, BA };
        private SquareState[,] _grid;

        private PlayerBoard playaBoard;

        private ConnectionManager connection;
        private MainForm owner;
        private int[,] board; //not a jagered array
        private bool isTurn;
        private bool whosTurn;

        public gameForm(MainForm owner, ConnectionManager connection, bool whosturn) {
            InitializeComponent();
            this.owner = owner;
            this.DesktopLocation = owner.Location;
            this.connection = connection;
            /*playaBoard = new PlayerBoard();
            playaBoard.reset();*/

            /*Ship haha = new Ship();
            haha.ShipType = (Ship._types)_types.GA;
            playaBoard.set(haha, 1, 1);*/

            /*for(int r = 0; r < 10; r++) {
                for(int c = 0; c < 10; c++) {
                    Console.Write(playaBoard.get(r, c));
                }
                Console.WriteLine();
            }
            */

            isTurn = whosturn;
            this.whosTurn = whosturn;

            _grid = new SquareState[10, 10];
            for(int i = 0; i < 10; ++i) {
                for(int j = 0; j < 10; ++j) {
                    _grid[i, j] = SquareState.Empty;
                }
            }

            _grid[3, 6] = SquareState.BA;
            _grid[3, 7] = SquareState.BA;
            _grid[3, 8] = SquareState.BA;

            _grid[1, 1] = SquareState.BR;
            _grid[2, 1] = SquareState.BR;
            _grid[3, 1] = SquareState.BR;
            _grid[4, 1] = SquareState.BR;
            _grid[5, 1] = SquareState.BR;

            for(int r = 0; r < 10; r++) {
                for(int c = 0; c < 10; c++) {
                    Console.Write(_grid[r, c]);
                }
                Console.WriteLine();
            }

        }

        private void taskGetData() {
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
        }

        private void gameForm_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }

        private void gameForm_Paint(object sender, PaintEventArgs e) {
           // e.Graphics.FillRectangle(new SolidBrush(Color.AliceBlue), 10, 10, 10, 10);

            for(int r = 0; r < 10; r++) {
                for(int c = 0; c < 10; c++) {
                    if(_grid[r, c] == SquareState.Empty)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Aqua), r * 25, c * 25, 20, 20);
                    else if(_grid[r, c] == SquareState.BA)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Red), r * 25, c * 25, 20, 20);
                    else if(_grid[r, c] == SquareState.BR)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Purple), r * 25, c * 25, 20, 20);
                }
                Console.WriteLine();
            }
        }

        private void gameForm_Load(object sender, EventArgs e) {
            checkTurn();
        }

        private void button1_Click(object sender, EventArgs e) {
            if(isTurn) {
                if(whosTurn) {
                    _grid = new SquareState[10, 10];
                    for(int i = 0; i < 10; ++i) {
                        for(int j = 0; j < 10; ++j) {
                            _grid[i, j] = SquareState.Empty;
                        }
                    }

                    _grid[3, 6] = SquareState.BA;
                    _grid[3, 7] = SquareState.BA;
                    _grid[3, 8] = SquareState.BA;

                    _grid[1, 1] = SquareState.BR;
                    _grid[2, 1] = SquareState.BR;
                    _grid[3, 1] = SquareState.BR;
                    _grid[4, 1] = SquareState.BR;
                    _grid[5, 1] = SquareState.BR;

                } else {
                    _grid = new SquareState[10, 10];
                    for(int i = 0; i < 10; ++i) {
                        for(int j = 0; j < 10; ++j) {
                            _grid[i, j] = SquareState.Empty;
                        }
                    }

                    _grid[9, 6] = SquareState.BA;
                    _grid[9, 7] = SquareState.BA;
                    _grid[9, 8] = SquareState.BA;

                    _grid[3, 1] = SquareState.BR;
                    _grid[4, 1] = SquareState.BR;
                    _grid[5, 1] = SquareState.BR;
                    _grid[6, 1] = SquareState.BR;
                    _grid[7, 1] = SquareState.BR;
                }

                connection.sendData2(_grid);
                Console.WriteLine("WAS ABLE TO SEND THE BOARD");
                isTurn = false;
                checkTurn();


            }
        }
    }
}
