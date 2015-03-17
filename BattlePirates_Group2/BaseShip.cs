using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
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

        public bool checkForHit(Point p) {
            for(int i = 0; i < location.Length; i++) {
                if(location[i] == p) {
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
