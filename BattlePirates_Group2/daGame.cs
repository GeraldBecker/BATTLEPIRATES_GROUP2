﻿using System;
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
        LocationState[,] _grid2;

        private const int SPACER = 300;

        /// <summary>
        /// Currently depricated
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="connection"></param>
        /// <param name="whosTurn"></param>
        /// <param name="userShips"></param>
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


            myTurn = host = whosTurn;

            this.mine = mine;
            this.opponent = opponent;


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

        /// <summary>
        /// Paints the board with updated status by changing the square colors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daGame_Paint(object sender, PaintEventArgs e) {
            _grid = opponent.getBoardForDrawing();// Opponent's board update
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
                //Console.WriteLine("opponent: " + opponent.hasShip(new Point(0,0)));
            }


            // Mine board update
            _grid2 = mine.getBoardForDrawing();
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
                //Console.WriteLine();
            }
        }

        /// <summary>
        /// Mouse Down event - player strike of ship
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daGame_MouseDown(object sender, MouseEventArgs e) {
            if(myTurn) {
                // check to see if hit
                if ((e.X / BLOCKWIDTH) < 10 && (e.Y / BLOCKWIDTH) < 10)
                {
                    int c = e.X / BLOCKWIDTH;
                    int r = e.Y / BLOCKWIDTH;

                    Point shot = new Point(r, c);
                    LocationState shotResult;
                    shotResult = opponent.strikeCoordinates(shot);

                    if (shotResult != LocationState.CLICKED)// check if square has been previously selected
                    {
                        // Send to opponent
                        TransmitMessage msg1 = SerializationHelper.Serialize(e.Location);
                        connection.sendGamePoint(msg1);
                        Console.WriteLine("Sent location: " + e.Location);
                        // update opponent grid in this GameBoard instance
                        _grid[r, c] = shotResult;

                        // check if a hit
                        if(shotResult != LocationState.HIT)
                        {
                            myTurn = false;
                        }
                        
                        CheckTurn();
                    }
                }

                /*TransmitMessage msg1 = SerializationHelper.Serialize(e.Location);
                connection.sendGamePoint(msg1);
                Console.WriteLine("Sent location: " + e.Location);

                TransmitMessage msg = connection.getGamePoint();
                Point p = (Point)SerializationHelper.Deserialize(msg);
                Console.WriteLine("Received location: " + p);*/


            } else {
                /*TransmitMessage msg = connection.getGamePoint();
                Point p = (Point)SerializationHelper.Deserialize(msg);
                Console.WriteLine("Received location: " + p);

                myTurn = true;*/
            }
        }

        /// <summary>
        /// Checks and updates turn information to both players
        /// </summary>
        private void CheckTurn() {
            if(!this.InvokeRequired) {
                if(myTurn) {// Mine's turn
                    waitPanel.Hide();
                    //SetEnabled(true);
                    this.Refresh();
                } else {
                    waitPanel.Show();
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
                Console.WriteLine("TRYING TO GET A POINT");
                TransmitMessage msg = connection.getGamePoint();
                Point p = (Point)SerializationHelper.Deserialize(msg);
                Console.WriteLine("Received location: " + p);

                // check and update mine gameBoard
                LocationState shotResult;
                int c = p.X / BLOCKWIDTH;
                int r = p.Y / BLOCKWIDTH;
                shotResult = mine.strikeCoordinates(new Point(r, c));
                _grid2[r, c] = shotResult;
                Console.WriteLine("GetData shotResult: " + shotResult);
                if(shotResult != LocationState.HIT)
                {
                    Console.WriteLine("LocationState.Hit");
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

    }
}
