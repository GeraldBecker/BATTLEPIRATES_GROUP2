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
        private const int BLOCKWIDTH = 25;
        private bool dragging;

        
        private BaseShip[] myShips = new BaseShip[6];


        private bool containsTrue;
        private Point[] tempShapePoints;
        private bool tempOrientVert;
        private int shipToMove;

        private ConnectionManager connection;
        private MainForm screen;
        private bool whoStarts;
        private bool userQuit;

        public shipPlacementForm(MainForm screen, ConnectionManager connection, bool whoStarts) {
            InitializeComponent();

            this.screen = screen;
            this.connection = connection;
            this.whoStarts = whoStarts;
            this.DesktopLocation = screen.Location;

            userQuit = true;


            //5 square size
            myShips[0] = new ManowarShip();
            myShips[0].setLocation(new Point[] { new Point(5, 13), new Point(6, 13), new Point(7, 13), new Point(8, 13), new Point(9, 13) }, true);

            //4 square size
            myShips[1] = new Galleon();
            myShips[1].setLocation(new Point[] { new Point(5, 15), new Point(6, 15), new Point(7, 15), new Point(8, 15) }, true);
            
            //3 square size
            myShips[2] = new BrigShip();
            myShips[2].setLocation(new Point[] { new Point(5, 17), new Point(6, 17), new Point(7, 17) }, true);

            myShips[3] = new BrigShip();
            myShips[3].setLocation(new Point[] { new Point(5, 19), new Point(6, 19), new Point(7, 19) }, true);


            //2 square size
            myShips[4] = new BarqueShip();
            myShips[4].setLocation(new Point[] { new Point(5, 21), new Point(6, 21) }, true);

            myShips[5] = new BarqueShip();
            myShips[5].setLocation(new Point[] { new Point(5, 23), new Point(6, 23) }, true);

            dragging = false;

            //Prevent the start game button from taking focus
            startGameButton.TabStop = false;
        }

        private void shipPlacementForm_Paint(object sender, PaintEventArgs e) {
            for(int r = 0; r < 10; r++) {
                for(int c = 0; c < 10; c++) {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Aqua), r * BLOCKWIDTH, c * BLOCKWIDTH, BLOCKWIDTH - 5, BLOCKWIDTH - 5);
                    
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


            if(tempShapePoints != null && dragging) {
                for(int i = 0; i < tempShapePoints.Length; i++) {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), tempShapePoints[i].Y * BLOCKWIDTH, tempShapePoints[i].X * BLOCKWIDTH, BLOCKWIDTH - 5, BLOCKWIDTH - 5);
                }
            }
        }


        

        private void shipPlacementForm_MouseDown(object sender, MouseEventArgs e) {
            
            Console.WriteLine("Mouse Down Location: " + e.X + " " + e.Y);
            int c = e.X / BLOCKWIDTH;
            int r = e.Y / BLOCKWIDTH;
            Console.WriteLine("Point: " + r + " " + c);


            //Loop through the array of ships to find a ship that is at the point.
            for(int n = 0; n < myShips.Length; n++) {
                if(myShips[n].containsPoint(new Point(r, c))) {
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

        private void shipPlacementForm_MouseMove(object sender, MouseEventArgs e) {
            if(dragging && containsTrue) {
                Console.WriteLine("Mouse UP Location: " + e.Y / BLOCKWIDTH + " " + e.X / BLOCKWIDTH);
                


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

                if (ClientRectangle.Contains(PointToClient(Control.MousePosition)))
                {
                    this.Refresh();
                }
                
            }
            
            
        }

        private void shipPlacementForm_MouseUp(object sender, MouseEventArgs e) {
            dragging = false;
            if(containsTrue && ClientRectangle.Contains(PointToClient(Control.MousePosition))) {
                myShips[shipToMove].setLocation(tempShapePoints, tempOrientVert);
            }
            
            Console.WriteLine("Mouse UP Location: " + e.X + " " + e.Y);
            containsTrue = false;
            this.Refresh();
        }

        private void shipPlacementForm_KeyDown(object sender, KeyEventArgs e) {

            if(e.KeyCode == Keys.Space && dragging) {
                Console.WriteLine("HAHHA rotate");

                

                if(tempOrientVert) {
                    for(int i = 0; i < tempShapePoints.Length; i++) {
                        tempShapePoints[i].X = tempShapePoints[0].X;
                    }
                } else {
                    for(int i = 0; i < tempShapePoints.Length; i++) {
                        tempShapePoints[i].Y = tempShapePoints[0].Y;
                    }
                }
                
                
                if(tempOrientVert)
                    tempOrientVert = false;
                else
                    tempOrientVert = true;

            }
            
            
        }

        private void startGame_click(object sender, EventArgs e) {

            // Check if ships on game board
            for (int n = 0; n < myShips.Length; n++) {
                if (myShips[n].outsideGrid()) {
                    Console.WriteLine("Ship: " + n);
                    return;
                }
            }

            GameBoard myboard = new GameBoard();
            myboard.initiateShipPlacement(myShips);

            GameBoard enemyBoard;

            //This is the new code to get the other board

            if(whoStarts) {
                //Task.Factory.StartNew(() => {
                //Get client board
                Console.WriteLine("SERVER TRYING TO GET THE BOARD");
                TransmitMessage msg = connection.getGameBoard();
                enemyBoard = (GameBoard)SerializationHelper.Deserialize(msg);
                Console.WriteLine("SERVER GOT THE BOARD");

                //Send server board
                TransmitMessage msg1 = SerializationHelper.Serialize(myboard);
                connection.sendGameBoard(msg1);
                //});
            } else {
                //Send client board
                TransmitMessage msg = SerializationHelper.Serialize(myboard);

                connection.sendGameBoard(msg);

                //Get server Board
                //Task.Factory.StartNew(() => {
                Console.WriteLine("TRYING TO GET THE BOARD");
                TransmitMessage msg1 = connection.getGameBoard();
                enemyBoard = (GameBoard)SerializationHelper.Deserialize(msg1);
                Console.WriteLine("GOT THE BOARD");
                //});
            }

            Console.WriteLine("PASSED ALL METHODS");

            new daGame(screen, connection, whoStarts, myboard, enemyBoard).Show();

            //new daGame(screen, connection, whoStarts, myShips).Show();

            //Get rid of the connection form.

            userQuit = false;
            this.Close();
        }

        private void shipPlacementForm_FormClosing(object sender, FormClosingEventArgs e) {
            if(userQuit) {
                Application.Exit();
            }
        }

        
    }
}
