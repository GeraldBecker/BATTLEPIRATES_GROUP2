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

        private bool dragging;


        private BaseShip[] myShips = new BaseShip[6];


        public shipPlacementForm() {
            InitializeComponent();

            /*ship1 = new ManowarShip();
            ship1.setLocation(new Point[] { new Point(5, 15), new Point(6, 15), new Point(7, 15), new Point(8, 15), new Point(9, 15) }, true);*/


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
        }

        private void shipPlacementForm_Paint(object sender, PaintEventArgs e) {
            for(int r = 0; r < 10; r++) {
                for(int c = 0; c < 10; c++) {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Aqua), r * 25, c * 25, 20, 20);
                    
                }
            }

            Point[] points;// = ship1.getLocation();
            /*for(int i = 0; i < points.Length; i++) {
                e.Graphics.FillRectangle(new SolidBrush(Color.Orange), points[i].Y * 25, points[i].X * 25, 20, 20);
            }*/


            //array of ships
            for(int n = 0; n < myShips.Length; n++) {
                points = myShips[n].getLocation();
                for(int i = 0; i < points.Length; i++) {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Orange), points[i].Y * 25, points[i].X * 25, 20, 20);
                }
            }


            if(tempShapePoints != null && dragging) {
                for(int i = 0; i < tempShapePoints.Length; i++) {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), tempShapePoints[i].Y * 25, tempShapePoints[i].X * 25, 20, 20);
                }
            }
        }


        int origRow;
        int origCol;
        bool containsTrue;
        Point[] tempShapePoints;
        bool tempOrientVert;
        int shipToMove;

        private void shipPlacementForm_MouseDown(object sender, MouseEventArgs e) {
            
            Console.WriteLine("Mouse Down Location: " + e.X + " " + e.Y);
            int c = e.X / 25;
            int r = e.Y / 25;
            Console.WriteLine("Point: " + r + " " + c);


            //Loop through the array of ships to find a ship that is at the point.
            for(int n = 0; n < myShips.Length; n++) {
                if(myShips[n].containsPoint(new Point(r, c))) {
                    Console.WriteLine("YOU HIT A SHIP");

                    origRow = r;
                    origCol = c;
                    containsTrue = true;

                    tempShapePoints = myShips[n].getLocation().ToArray<Point>();
                    tempOrientVert = myShips[n].isVertical();
                    shipToMove = n;
                    break;
                }
            }


                
            





            /*if(ship1.containsPoint(new Point(r, c))) {
                Console.WriteLine("YOU HIT A SHIP");

                origRow = r;
                origCol = c;
                containsTrue = true;

                tempShapePoints = ship1.getLocation().ToArray<Point>();
                tempOrientVert = ship1.isVertical();
            }*/
            dragging = true;
        }

        private void shipPlacementForm_MouseMove(object sender, MouseEventArgs e) {
            if(dragging && containsTrue) {
                Console.WriteLine("Mouse UP Location: " + e.Y / 25 + " " + e.X / 25);
                int moveR = origRow - e.Y/25;
                int moveC = origCol - e.X/25;


                if(tempOrientVert) {
                    for(int i = 0; i < tempShapePoints.Length; i++) {
                        tempShapePoints[i].X = (e.Y + (i * 25)) / 25;
                        tempShapePoints[i].Y = (e.X) / 25;
                    }

                    /*
                    tempShapePoints[0].X = e.Y / 25;
                    tempShapePoints[0].Y = e.X / 25;
                    tempShapePoints[1].X = (e.Y + (1 * 25)) / 25;
                    tempShapePoints[1].Y = (e.X) / 25;
                    tempShapePoints[2].X = (e.Y + (2 * 25)) / 25;
                    tempShapePoints[2].Y = (e.X) / 25;
                    tempShapePoints[3].X = (e.Y + (3 * 25)) / 25;
                    tempShapePoints[3].Y = (e.X) / 25;
                    tempShapePoints[4].X = (e.Y + (4 * 25)) / 25;
                    tempShapePoints[4].Y = (e.X) / 25;*/
                } else {
                    for(int i = 0; i < tempShapePoints.Length; i++) {
                        tempShapePoints[i].X = (e.Y) / 25;
                        tempShapePoints[i].Y = (e.X + (i * 25)) / 25;
                    }
                    /*tempShapePoints[0].X = e.Y / 25;
                    tempShapePoints[0].Y = e.X / 25;
                    tempShapePoints[1].X = e.Y / 25;
                    tempShapePoints[1].Y = (e.X + (1 * 25)) / 25;
                    tempShapePoints[2].X = (e.Y) / 25;
                    tempShapePoints[2].Y = (e.X + (2 * 25)) / 25;
                    tempShapePoints[3].X = (e.Y) / 25;
                    tempShapePoints[3].Y = (e.X + (3 * 25)) / 25;
                    tempShapePoints[4].X = (e.Y) / 25;
                    tempShapePoints[4].Y = (e.X + (4 * 25)) / 25;*/
                }
                

                this.Refresh();
            }
            
            
        }

        private void shipPlacementForm_MouseUp(object sender, MouseEventArgs e) {
            dragging = false;
            if(containsTrue) {
                /*Point[] orig = ship1.getLocation();
                int moveR = origRow - e.Y / 25;
                int moveC = origCol - e.X / 25;
                //temp.setLocation(new Point[] { new Point(orig[0].X - moveR, orig[0].Y - moveC), new Point(1, 3), new Point(1, 4), new Point(1, 5), new Point(1, 6) });
                ship1.setLocation(tempShapePoints, false);*/

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

                    /*tempShapePoints[1].X = tempShapePoints[0].X;
                    tempShapePoints[2].X = tempShapePoints[0].X;
                    tempShapePoints[3].X = tempShapePoints[0].X;
                    tempShapePoints[4].X = tempShapePoints[0].X;*/
                } else {
                    for(int i = 0; i < tempShapePoints.Length; i++) {
                        tempShapePoints[i].Y = tempShapePoints[0].Y;
                    }
                    /*tempShapePoints[0].Y = tempShapePoints[0].Y;
                    tempShapePoints[1].Y = tempShapePoints[0].Y;
                    tempShapePoints[2].Y = tempShapePoints[0].Y;
                    tempShapePoints[3].Y = tempShapePoints[0].Y;
                    tempShapePoints[4].Y = tempShapePoints[0].Y;*/
                }
                
                
                if(tempOrientVert)
                    tempOrientVert = false;
                else
                    tempOrientVert = true;

            }
            
            
        }

        private void startGame_click(object sender, EventArgs e) {

        }

        
    }
}
