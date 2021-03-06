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
    public partial class daGame : Form {

        private const int BLOCKWIDTH = 33;// grid block size
        private const int SQUARESIZE = (int)(0.96 * BLOCKWIDTH);
        private const int START_X = 30;//3;// offset for grid from left
        private const int START_Y = 220;//12;// offset for grid from top
        private ConnectionManager connection;
        private MainForm screen;
        private bool myTurn;
        private bool host;
        private bool win = false;

        private GameBoard mine;
        private GameBoard opponent;

        LocationState[,] _grid;
        LocationState[,] _grid2;

        private const int SPACER = 400;

        
        /// <summary>
        /// Constructor for the GameEngine
        /// Initializes Mine and Opponents game boards after connection
        /// passed and received each others game boards
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="connection"></param>
        /// <param name="whosTurn"></param>
        /// <param name="mine"></param>
        /// <param name="opponent"></param>
        internal daGame(MainForm screen, ConnectionManager connection, bool whosTurn, GameBoard mine, GameBoard opponent) {
            InitializeComponent();
            this.connection = connection;
            this.screen = screen;
            this.DesktopLocation = screen.Location;

            host = whosTurn;
            myTurn = !host;

            this.mine = mine;
            this.opponent = opponent;
            if(!myTurn)
                yourTurnLabel.Visible = false;

            
            labelWinPanel.Visible = false;

            //Fix the flicker problem by double buffering.
            DoubleBuffered = true;
        }

        
        private void daGame_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }

        /// <summary>
        /// Paints the board with updated status by changing the square colors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daGame_Paint(object sender, PaintEventArgs e) {
            _grid = opponent.getBoardForDrawing();// Opponent's board update

            for(int r = 0; r < 10; r++) {
                for(int c = 0; c < 10; c++) {
                    if(_grid[r, c] == LocationState.EMPTY)
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 76, 179)), c * BLOCKWIDTH + START_X, r * BLOCKWIDTH + START_Y, SQUARESIZE, SQUARESIZE);
                    else if(_grid[r, c] == LocationState.HIT) {
                        e.Graphics.FillRectangle(new SolidBrush(Color.Orange), c * BLOCKWIDTH + START_X, r * BLOCKWIDTH + START_Y, SQUARESIZE, SQUARESIZE);
                        //Test drawing the X
                        Pen myPen = new Pen(Color.Red, 8);
                        e.Graphics.DrawPolygon(myPen, getXDrawing(c, r, 0));
                    } else if(_grid[r, c] == LocationState.MISS) {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 76, 179)), c * BLOCKWIDTH + START_X, r * BLOCKWIDTH + START_Y, SQUARESIZE, SQUARESIZE);

                        Pen myPen = new Pen(Color.White, 8);
                        e.Graphics.DrawPolygon(myPen, getXDrawing(c, r, 0));
                    } else if(_grid[r, c] == LocationState.SUNK) {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(104, 49, 4)), c * BLOCKWIDTH + START_X, r * BLOCKWIDTH + START_Y, SQUARESIZE, SQUARESIZE);
                        Pen myPen = new Pen(Color.Red, 8);
                        e.Graphics.DrawPolygon(myPen, getXDrawing(c, r, 0));
                    } else
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 76, 179)), c * BLOCKWIDTH + START_X, r * BLOCKWIDTH + START_Y, SQUARESIZE, SQUARESIZE);

                }

            }


            // Mine board update
            _grid2 = mine.getBoardForDrawing();

            for(int r = 0; r < 10; r++) {
                for(int c = 0; c < 10; c++) {
                    if(_grid2[r, c] == LocationState.SHIP)
                        e.Graphics.FillRectangle(new SolidBrush(Color.Orange), c * BLOCKWIDTH + START_X + SPACER, r * BLOCKWIDTH + START_Y, SQUARESIZE, SQUARESIZE);
                    else if(_grid2[r, c] == LocationState.EMPTY)
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 76, 179)), c * BLOCKWIDTH + START_X + SPACER, r * BLOCKWIDTH + START_Y, SQUARESIZE, SQUARESIZE);
                    else if(_grid2[r, c] == LocationState.HIT) {
                        e.Graphics.FillRectangle(new SolidBrush(Color.Orange), c * BLOCKWIDTH + START_X + SPACER, r * BLOCKWIDTH + START_Y, SQUARESIZE, SQUARESIZE);
                        //Draw the X
                        Pen myPen = new Pen(Color.Red, 8);
                        e.Graphics.DrawPolygon(myPen, getXDrawing(c, r, SPACER));
                    } else if(_grid2[r, c] == LocationState.MISS) {

                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 76, 179)), c * BLOCKWIDTH + START_X + SPACER, r * BLOCKWIDTH + START_Y, SQUARESIZE, SQUARESIZE);
                        //Draw the X
                        Pen myPen = new Pen(Color.White, 8);
                        e.Graphics.DrawPolygon(myPen, getXDrawing(c, r, SPACER));
                    } else if(_grid2[r, c] == LocationState.SUNK) {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(104, 49, 4)), c * BLOCKWIDTH + START_X + SPACER, r * BLOCKWIDTH + START_Y, SQUARESIZE, SQUARESIZE);
                        //Draw the X
                        Pen myPen = new Pen(Color.Red, 8);
                        e.Graphics.DrawPolygon(myPen, getXDrawing(c, r, SPACER));
                    }

                }
            }
        }


        public PointF[] getXDrawing(int c, int r, int spacer) {
            return new PointF[] {
                new PointF((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.1)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.06)+ START_Y), //start point
                new PointF((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.16)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.28)+ START_Y),//5,9
                new PointF ((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.55)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.55)+ START_Y), //MIDDLE 18,18 
                new PointF ((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.67)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.73)+ START_Y), //22, 24
                new PointF((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.82)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.82)+ START_Y), //27,27
                new PointF((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.85)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.82)+ START_Y),//bottom right //28,27
                new PointF((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.82)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.82)+ START_Y), //27, 27
                new PointF ((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.67)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.73)+ START_Y), //22, 24
                new PointF ((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.55)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.55)+ START_Y), //MIDDLE 18,18
                new PointF((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.28)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.79)+ START_Y),//9,26
                new PointF((c*BLOCKWIDTH)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.85)+ START_Y),//bottom left  0,28
                new PointF((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.28)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.79)+ START_Y),//9,26
                new PointF ((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.55)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.55)+ START_Y), //MIDDLE 18,18
                new PointF((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.76)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.28)+ START_Y),//25,9
                new PointF((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.85)+ START_X + spacer, (r*BLOCKWIDTH)+ START_Y),//top right 28,0
                new PointF((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.76)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.28)+ START_Y),//25,9
                new PointF ((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.55)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.55)+ START_Y), //MIDDLE 18,18
                new PointF((c*BLOCKWIDTH)+(int)(BLOCKWIDTH*.16)+ START_X + spacer, (r*BLOCKWIDTH)+(int)(BLOCKWIDTH*.28)+ START_Y) };
        }

        /// <summary>
        /// Mouse Down event - player strike of ship
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daGame_MouseDown(object sender, MouseEventArgs e) {
            if(myTurn) {
                // check to see if hit
                int xStrike = ((e.X - START_X) / BLOCKWIDTH) ;
                int yStrike = ((e.Y - START_Y) / BLOCKWIDTH) ;

                if(0 <= xStrike && xStrike < 10 && 0 <= yStrike && yStrike < 10) {
                    int c = xStrike;
                    int r = yStrike;

                    Point shot = new Point(r, c);
                    LocationState shotResult;
                    shotResult = opponent.strikeCoordinates(shot);

                    if(shotResult != LocationState.CLICKED)// check if square has been previously selected
                    {
                        // check if a hit
                        if(shotResult == LocationState.HIT || shotResult == LocationState.SUNK) {
                            if(shotResult == LocationState.HIT)
                            {
                                //SoundPlayer snd = new SoundPlayer(Properties.Resources.bomb_x_converted);
                                SoundPlayer snd = new SoundPlayer(Properties.Resources.cannon);
                                snd.Play();
                            }
                            else
                            {
                                SoundPlayer snd = new SoundPlayer(Properties.Resources.bubbling_converted);
                                snd.Play();
                            }
                            BaseShip[] oppShips = opponent.getShips();
                            for(int k = 0; k < oppShips.Length; ++k) {
                                if(!oppShips[k].isSunk()) {
                                    win = false;
                                    break;
                                } else {
                                    win = true;
                                }
                            }
                            if(win == true) {
                                myTurn = false;
                                labelWin.Text = "You Win!!!";
                                labelWinPanel.Visible = true;
                                mainMenuBtn.Visible = true;
                               // SoundPlayer snd2 = new SoundPlayer(Properties.Resources.cheering_converted);
                                //snd2.Play();
                            }
                        } else {
                            SoundPlayer snd2 = new SoundPlayer(Properties.Resources.miss);
                            snd2.Play();
                            myTurn = false;
                        }

                        // Send to opponent
                        TransmitMessage msg1 = SerializationHelper.Serialize(e.Location);
                        connection.sendGamePoint(msg1);
                        // update opponent grid in this GameBoard instance
                        _grid[r, c] = shotResult;
                        CheckTurn();
                        
                    }
                }



            } 
        }

        /// <summary>
        /// Checks and updates turn information to both players
        /// </summary>
        private void CheckTurn() {
            if(!this.InvokeRequired) {
                if(myTurn) {// Mine's turn
                    //waitPanel.Hide();
                    waitPanel.Visible = false;
                    yourTurnLabel.Visible = true;
                    //SetEnabled(true);
                    this.Refresh();
                } else {
                    //waitPanel.Show();
                    waitPanel.Visible = true;
                    yourTurnLabel.Visible = false;
                    //SetEnabled(false);
                    GetDataFromOthers();
                    this.Refresh();
                }
                //ReSetBoard();
            } else
                this.Invoke((MethodInvoker)delegate {
                    CheckTurn();
                });
        }

        /// <summary>
        /// Receiving strike point data
        /// </summary>
        private void GetDataFromOthers() {
            Task.Factory.StartNew(() => {
                TransmitMessage msg = connection.getGamePoint();
                Point p;
                try
                {
                    p = (Point)SerializationHelper.Deserialize(msg);
                }
                catch (NullReferenceException ex)
                {
                    return;
                }

                // check and update mine gameBoard
                LocationState shotResult;

                int xStrike = ((p.X - START_X) / BLOCKWIDTH);
                int yStrike = ((p.Y - START_Y) / BLOCKWIDTH);

                int c = xStrike;
                int r = yStrike;
                shotResult = mine.strikeCoordinates(new Point(r, c));
                _grid2[r, c] = shotResult;
                if(shotResult == LocationState.HIT || shotResult == LocationState.SUNK) {
                    BaseShip[] mineShips = mine.getShips();
                    for(int i = 0; i < mineShips.Length; ++i) {
                        if(!mineShips[i].isSunk()) {
                            win = false;
                            break;
                        } else {
                            win = true;
                        }
                    }
                    if(win == true) {
                        myTurn = false;
                        labelUpdate();
                        
                    }
                } else {
                    myTurn = true;
                }
                CheckTurn();
            });
        }

        /// <summary>
        /// Checks for initial player's turn on GameEngine load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daGame_Load(object sender, EventArgs e) {
            CheckTurn();
        }

        /// <summary>
        /// Displays winner loser label with different thread
        /// </summary>
        private void labelUpdate() {
            MethodInvoker mi = delegate {
                //labelWin.ForeColor = Color.Red;
                labelWin.Text = "You Lose!!";
                labelWinPanel.Visible = true;
                mainMenuBtn.Visible = true;
            };
            if(InvokeRequired) {
                this.Invoke(mi);
            }
        }

        private void mainMenuBtn_Click(object sender, EventArgs e) {
            /*Owner = new MainForm();
            Owner.Show();
            this.Hide();*/

            //stop connection
            connection.stopNetwork();

            new shipPlacementForm(screen, connection, host).Show();
            this.Close();
        }
    }
}
