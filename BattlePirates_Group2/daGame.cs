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

        private const int BLOCKWIDTH = 25;
        private ConnectionManager connection;
        private MainForm screen;
        private bool myTurn;
        private bool host;

        private GameBoard mine;
        private GameBoard opponent;

        private BaseShip[] opponentShips;
        LocationState[,] _grid;

        private const int SPACER = 300;

        internal daGame(MainForm screen, ConnectionManager connection, bool whosTurn, BaseShip[] userShips) {
            InitializeComponent();
            this.connection = connection;
            this.screen = screen;
            this.DesktopLocation = screen.Location;


            myTurn = host = whosTurn;

            mine = new GameBoard();
            mine.initiateShipPlacement(userShips);
            //mine = new GameBoard();

            opponent = new GameBoard();
            // TO-Delete just for testing game logic
            opponent.initiateShipPlacement(userShips);

            opponentShips = opponent.getShips();
        }


        private void daGame_MouseUp(object sender, MouseEventArgs e)
        {
            if((e.X / BLOCKWIDTH) < 10 && (e.Y / BLOCKWIDTH) < 10)
            {
                int r = e.X / BLOCKWIDTH;
                int c = e.Y / BLOCKWIDTH;

                Point shot = new Point(c, r);

                for (int i = 0; i < opponentShips.Length; i++)
                {
                    if (opponentShips[i].checkForHit(shot))
                    {
                        
                        _grid[c, r] = LocationState.HIT;
                        Console.WriteLine("hit: " + c + ":" + r);
                        break;
                    }
                    else
                    {
                        _grid[c, r] = LocationState.MISS;
                        Console.WriteLine("Miss: " + c + ":" + r);
                    }
                }
                
                this.Refresh();
            }

        }

        /*private void taskGetData() {
            Task.Factory.StartNew(() => {
                Console.WriteLine("TRYING TO GET THE BOARD");
                opponent = connection.getData2();
                Console.WriteLine("GOT THE BOARD");
            });
        }*/

        /*private void checkTurn() {
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
            _grid = opponent.getBoardForDrawing();
            for(int r = 0; r < 10; r++) {
                for(int c = 0; c < 10; c++) {
                    if(opponent.hasShip(new Point(r, c)))
                        e.Graphics.FillRectangle(new SolidBrush(Color.Orange), c * 25, r * 25, 20, 20);
                    else if(_grid[r, c] == LocationState.EMPTY)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Aqua), c * 25, r * 25, 20, 20);
                    else if(_grid[r, c] == LocationState.HIT)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Red), c * 25, r * 25, 20, 20);
                    else if(_grid[r, c] == LocationState.MISS)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Purple), c * 25, r * 25, 20, 20);
                    
                }
                Console.WriteLine("opponent: " + opponent.hasShip(new Point(0,0)));
            }



            LocationState[,] _grid2 = opponent.getBoardForDrawing();
            for(int r = 0; r < 10; r++) {
                for(int c = 0; c < 10; c++) {
                    if(mine.hasShip(new Point(r, c)))
                        e.Graphics.FillRectangle(new SolidBrush(Color.Orange), c * 25 + SPACER, r * 25, 20, 20);
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
