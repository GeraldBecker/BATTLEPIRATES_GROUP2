using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
    [Serializable]
    abstract class BaseShip {

        protected int totalSize;
        protected int health;
        protected Point[] location;
        protected bool isVert;


        public BaseShip(int size) {
            totalSize = health = size;
            location = new Point[size];
        }


        public bool setLocation(Point[] newLocation, bool isVert) {
            //TODO   Run through loop to check if it is over other ships.
            location = newLocation;
            this.isVert = isVert;
            return true;
        }

        public bool isVertical() {
            return isVert;
        }

        public Point[] getLocation() {
            return location;
        }


        public bool containsPoint(Point p) {
            for(int i = 0; i < location.Length; i++) {
                if(location[i] == p) {
                    return true;
                }
            }
            return false;
        }

        public bool outsideGrid()
        {
            for (int i = 0; i < location.Length; i++)
            {
                Console.WriteLine("location[" + i + "].X: " + location[i].X);
                Console.WriteLine("location[" + i + "].Y: " + location[i].Y);
                if (location[i].X < 0 || location[i].X > 9)
                {
                    return true;
                }
                else if (location[i].Y < 0 || location[i].Y > 9)
                {
                    return true;
                }
            }
            return false;
        }

        public bool checkForShip(Point p) {
            for(int i = 0; i < location.Length; i++) {
                if(location[i] == p) {
                    return true;
                }
            }
            return false;
        }

        public bool checkForHit(Point p)
        {
            for (int i = 0; i < location.Length; i++)
            {
                if (location[i] == p)
                {
                    Console.WriteLine("hit point: " + p.X + " Y: " + p.Y);
                    location[i] = new Point(-1, -1);
                    health--;
                    return true;
                }
            }
            return false;
        }

        public bool isSunk() {
            return health == 0;
        }
    } 
}
