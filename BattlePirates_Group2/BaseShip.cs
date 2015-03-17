using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
    /// <summary>
    /// Parent class of ships
    /// </summary>
    [Serializable]
    abstract class BaseShip {

        protected int totalSize;// the size passed by the child
        protected int health;// totalSize minus hits
        protected Point[] location;// the grids ship occupies
        protected bool isVert;// if vertically oriented

        /// <summary>
        /// Constructor - used by child class to instantiate
        /// </summary>
        /// <param name="size"></param>
        public BaseShip(int size) {
            totalSize = health = size;
            location = new Point[size];
        }

        /// <summary>
        /// Sets location of ship on grid
        /// </summary>
        /// <param name="newLocation"></param>
        /// <param name="isVert"></param>
        /// <returns></returns>
        public bool setLocation(Point[] newLocation, bool isVert) {
            //TODO   Run through loop to check if it is over other ships.
            location = newLocation;
            this.isVert = isVert;
            return true;
        }

        /// <summary>
        /// Property for isVert
        /// </summary>
        /// <returns></returns>
        public bool isVertical() {
            return isVert;
        }

        /// <summary>
        /// Property for location
        /// </summary>
        /// <returns></returns>
        public Point[] getLocation() {
            return location;
        }

        // depricated
        public bool containsPoint(Point p) {
            for(int i = 0; i < location.Length; i++) {
                if(location[i] == p) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Grid bounds checking
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Check if ship exists at Point
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool checkForShip(Point p) {
            for(int i = 0; i < location.Length; i++) {
                if(location[i] == p) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check if the strike is a hit
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns if the ship is sunk - 0 health
        /// </summary>
        /// <returns></returns>
        public bool isSunk() {
            return health == 0;
        }
    } 
}
