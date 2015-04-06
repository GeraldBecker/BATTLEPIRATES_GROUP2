using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace BattlePirates_Group2 {
    /// <summary>
    /// Form for placing ships prior to game start
    /// </summary>
    public partial class shipPlacementForm : Form {
        private const int BLOCKWIDTH = 25;// grid block size
        private const int START_X = 3;// offset for grid from left
        private const int START_Y = 12;// offset for grid from top
        private bool dragging;// if mouse down and ready to drag a ship

        // Array of ships
        private BaseShip[] myShips = new BaseShip[6];
        // Array of ships converted to (0,0) origin points
        private BaseShip[] toSetShips = new BaseShip[6];

        private bool containsTrue;// if mouse down point contains a ship
        private Point[] tempShapePoints;// the dragging ship locations
        private bool tempOrientVert;// the dragging ship vertical orientation
        private int shipToMove;// the ship being moved
        private bool collision = false;// if collision of ships occur

        private ConnectionManager connection;
        private MainForm screen;
        private bool whoStarts;// if this player starts to play game first
        private bool userQuit;// if user quit shipPlacementForm

        private bool clientReady;
        private bool serverPlaced;

        private GameBoard myboard;

        private GameBoard enemyBoard;



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="connection"></param>
        /// <param name="whoStarts"></param>
        public shipPlacementForm(MainForm screen, ConnectionManager connection, bool whoStarts) {
            InitializeComponent();
            //SoundPlayer snd = new SoundPlayer(Properties.Resources.alright2_converted);
            //snd.Play();

            this.screen = screen;
            this.connection = connection;
            this.whoStarts = whoStarts;
            this.DesktopLocation = screen.Location;

            userQuit = true;
            clientReady = false;
            serverPlaced = false;

            // Initial locations of ships for dragging into grid (lower right side of form)
            //5 square size
            toSetShips[0] = new ManowarShip(); 
            myShips[0] = new ManowarShip();
            myShips[0].setLocation(new Point[] { new Point(8, 16), new Point(9, 16), new Point(10, 16), new Point(11, 16), new Point(12, 16) }, true);

            //4 square size
            toSetShips[1] = new Galleon(); 
            myShips[1] = new Galleon();
            myShips[1].setLocation(new Point[] { new Point(8, 18), new Point(9, 18), new Point(10, 18), new Point(11, 18) }, true);

            //3 square size
            toSetShips[2] = new BrigShip(); 
            myShips[2] = new BrigShip();
            myShips[2].setLocation(new Point[] { new Point(8, 20), new Point(9, 20), new Point(10, 20) }, true);

            toSetShips[3] = new BrigShip(); 
            myShips[3] = new BrigShip();
            myShips[3].setLocation(new Point[] { new Point(8, 22), new Point(9, 22), new Point(10, 22) }, true);


            //2 square size
            toSetShips[4] = new BarqueShip(); 
            myShips[4] = new BarqueShip();
            myShips[4].setLocation(new Point[] { new Point(8, 24), new Point(9, 24) }, true);

            toSetShips[5] = new BarqueShip(); 
            myShips[5] = new BarqueShip();
            myShips[5].setLocation(new Point[] { new Point(8, 26), new Point(9, 26) }, true);

            dragging = false;

            //Prevent the start game button from taking focus
            readyButton.TabStop = false;

            //Fix the flicker problem by double buffering.
            DoubleBuffered = true;

            //Start receiving the opponents board if you are the server
            if(whoStarts) {
                readyButton.Visible = false;
                Task.Factory.StartNew(() => {
                    TransmitMessage msg = connection.getGameBoard();
                    enemyBoard = (GameBoard)SerializationHelper.Deserialize(msg);
                    receiveClientBoardSuccess();
                });
            }


        }

        /// <summary>
        /// Paints the grid to place ships and the ships for placing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shipPlacementForm_Paint(object sender, PaintEventArgs e) {
            for(int r = START_X; r < (START_X + 10); r++) {
                for(int c = START_Y; c < (START_Y + 10); c++) {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 76, 179)), r * BLOCKWIDTH, c * BLOCKWIDTH, BLOCKWIDTH - 5, BLOCKWIDTH - 5);

                }
            }

            Point[] points;


            //array of ships
            for(int n = 0; n < myShips.Length; n++) {
                points = myShips[n].getLocation();
                for(int i = 0; i < points.Length; i++) {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Orange), points[i].Y * BLOCKWIDTH, points[i].X * BLOCKWIDTH, BLOCKWIDTH - 5, BLOCKWIDTH - 5);
                }
            }

            // the temporary mouse dragged ship
            if(tempShapePoints != null && dragging) {
                for(int i = 0; i < tempShapePoints.Length; i++) {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), tempShapePoints[i].Y * BLOCKWIDTH, tempShapePoints[i].X * BLOCKWIDTH, BLOCKWIDTH - 5, BLOCKWIDTH - 5);
                }
            }
        }

        /// <summary>
        /// Mouse Down event.  Checks to see if mousedown on a ship to drag.
        /// Enables a temporary ship object to be dragged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shipPlacementForm_MouseDown(object sender, MouseEventArgs e) {
            Console.WriteLine("Mouse Down Location: " + e.X + " " + e.Y);
            int c = e.X / BLOCKWIDTH;
            int r = e.Y / BLOCKWIDTH;
            Console.WriteLine("Point: " + r + " " + c);


            //Loop through the array of ships to find a ship that is at the point.
            for(int n = 0; n < myShips.Length; n++) {
                if(myShips[n].checkForShip(new Point(r, c))) {
                    Console.WriteLine("YOU HIT A SHIP");

                    containsTrue = true;

                    tempShapePoints = myShips[n].getLocation().ToArray<Point>();
                    tempOrientVert = myShips[n].isVertical();
                    shipToMove = n;
                    break;
                }
            }

            dragging = true;
        }

        /// <summary>
        /// Mouse move event.  Drags the temporary ship object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shipPlacementForm_MouseMove(object sender, MouseEventArgs e) {
            if(dragging && containsTrue) {
                Console.WriteLine("Mouse UP Location: " + e.Y / BLOCKWIDTH + " " + e.X / BLOCKWIDTH);


                // checks the orientation and sets the points accordingly
                if(tempOrientVert) {
                    for(int i = 0; i < tempShapePoints.Length; i++) {
                        tempShapePoints[i].X = (e.Y + (i * BLOCKWIDTH)) / BLOCKWIDTH;
                        tempShapePoints[i].Y = (e.X) / BLOCKWIDTH;
                    }

                } else {
                    for(int i = 0; i < tempShapePoints.Length; i++) {
                        tempShapePoints[i].X = (e.Y) / BLOCKWIDTH;
                        tempShapePoints[i].Y = (e.X + (i * BLOCKWIDTH)) / BLOCKWIDTH;
                    }
                }
                // Form bounds checking
                if(ClientRectangle.Contains(PointToClient(Control.MousePosition))) {
                    this.Refresh();
                }

            }


        }

        /// <summary>
        /// Sets the temporary ship object with the actual ship object in the location
        /// dragged to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shipPlacementForm_MouseUp(object sender, MouseEventArgs e) {
            dragging = false;
            if(containsTrue && ClientRectangle.Contains(PointToClient(Control.MousePosition))) {
                // Collison detection of ship placement
                for(int i = 0; i < tempShapePoints.Length; ++i) {
                    for(int j = 0; j < myShips.Length; ++j) {
                        if(myShips[j] != myShips[shipToMove]) {
                            if(myShips[j].checkForShip(tempShapePoints[i])) {
                                collision = true;
                                this.Refresh();
                                return;
                            } else {
                                collision = false;
                            }
                        }
                    }
                }
                // convert tempShapePoints to reference (0,0) coordinates
                Point[] setShapePoints = new Point[tempShapePoints.Length];
                for (int i = 0; i < tempShapePoints.Length; i++)
                {
                    setShapePoints[i].X = tempShapePoints[i].X - START_Y;
                    setShapePoints[i].Y = tempShapePoints[i].Y - START_X;
                }
                // ships to be set, converted to (0,0) origin
                toSetShips[shipToMove].setLocation(setShapePoints, tempOrientVert);
                // ships for this shipPlacementForm
                myShips[shipToMove].setLocation(tempShapePoints, tempOrientVert);
            }

            Console.WriteLine("Mouse UP Location: " + e.X + " " + e.Y);
            containsTrue = false;

            // show start button if all ships on grid
            // Check if ships on game board
            for (int n = 0; n < myShips.Length; n++)
            {
                if (myShips[n].outsideGrid())
                {
                    Console.WriteLine("Ship: " + n);
                    startServerButton.Visible = false;
                    serverPlaced = false;

                    if(!whoStarts)
                        readyButton.Visible = false;
                    break;
                }
                // Check if ship collision
                if (collision == false)
                {
                    serverPlaced = true;

                    //startGameButton.Visible = true;
                    if(!whoStarts)
                        readyButton.Visible = true;

                    if(clientReady)
                        startServerButton.Visible = true;
                }
            }

            this.Refresh();
        }

        /// <summary>
        /// KeyDown event.  Allows for rotation of the temporary ship object
        /// being dragged by the space bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shipPlacementForm_KeyDown(object sender, KeyEventArgs e) {
            // Spacebar toggles orientation of temporary dragged ship
            if(e.KeyCode == Keys.Space && dragging) {
                Console.WriteLine("Rotate Selected.");


                if(tempOrientVert) {
                    for(int i = 0; i < tempShapePoints.Length; i++) {
                        Console.WriteLine("b4i . X : " + i + " , " + tempShapePoints[i].X);
                        Console.WriteLine("b4i . Y : " + i + " , " + tempShapePoints[i].Y);

                        tempShapePoints[i].Y = tempShapePoints[i].Y + i; 
                        tempShapePoints[i].X = tempShapePoints[0].X;
                        Console.WriteLine("i . X : " + i + " , " + tempShapePoints[i].X);
                        Console.WriteLine("i . Y : " + i + " , " + tempShapePoints[i].Y);
                    }
                } else {
                    for(int i = 0; i < tempShapePoints.Length; i++) {
                        tempShapePoints[i].X = tempShapePoints[i].X + i;
                        tempShapePoints[i].Y = tempShapePoints[0].Y;
                        Console.WriteLine("i . X : " + i + " , " + tempShapePoints[i].X);
                    }
                }


                if(tempOrientVert)
                    tempOrientVert = false;
                else
                    tempOrientVert = true;

            }

            this.Focus();
        }

        private void receiveClientBoardSuccess() {
            MethodInvoker mi = delegate {
                if(serverPlaced)
                    startServerButton.Visible = true;
                clientReady = true;
            };

            if(InvokeRequired) {
                try {
                    this.Invoke(mi);
                } catch(ObjectDisposedException e) {
                    Console.WriteLine("Object Disposed.");
                }

            }
        }

        /// <summary>
        /// For the connecting user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readyButton_Click(object sender, EventArgs e) {
            readyButton.Enabled = false;

            myboard = new GameBoard();
            myboard.initiateShipPlacement(toSetShips);

            //enemyBoard;
            TransmitMessage msg = SerializationHelper.Serialize(myboard);

            connection.sendGameBoard(msg);

            //make this a factory
            Task.Factory.StartNew(() => {
                TransmitMessage msg1 = connection.getGameBoard();
                enemyBoard = (GameBoard)SerializationHelper.Deserialize(msg1);
                readyButtonFix();

                Thread.Sleep(2000);
                autoStartThread();
            });
            

            
        }

        private void readyButtonFix() {
            MethodInvoker mi = delegate {
                readyButton.Visible = false;
                //tempStartButton.Visible = true;
            };

            if(InvokeRequired) {
                try {
                    this.Invoke(mi);
                } catch(ObjectDisposedException e) {
                    Console.WriteLine("Object Disposed.");
                }

            }
        }

        private void serverStart_Click(object sender, EventArgs e) {
            myboard = new GameBoard();
            myboard.initiateShipPlacement(toSetShips);

            TransmitMessage msg1 = SerializationHelper.Serialize(myboard);
            connection.sendGameBoard(msg1);
            //tempStartButton.Visible = true;
            Thread.Sleep(2000);
            autoStart();
        }


        private void autoStart() {
            new daGame(screen, connection, whoStarts, myboard, enemyBoard).Show();

            //Get rid of the connection form.
            userQuit = false;
            this.Close();
        }

        private void autoStartThread() {

            MethodInvoker mi = delegate {
                new daGame(screen, connection, whoStarts, myboard, enemyBoard).Show();

                //Get rid of the connection form.
                userQuit = false;
                this.Close();
            };

            if(InvokeRequired) {
                try {
                    this.Invoke(mi);
                } catch(ObjectDisposedException e) {
                    Console.WriteLine("Object Disposed.");
                }

            }
            
        }


        

        /// <summary>
        /// Form closing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shipPlacementForm_FormClosing(object sender, FormClosingEventArgs e) {
            if(userQuit) {
                Application.Exit();
            }
        }

        

        

        
    }
}
