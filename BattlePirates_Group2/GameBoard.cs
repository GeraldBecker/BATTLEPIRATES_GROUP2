using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
    class GameBoard {

        private BaseShip[] ships;
        private LocationState[,] grid;

        public GameBoard() {
            ships = new BaseShip[5];
            ships[0] = new ManowarShip();
            ships[1] = new ManowarShip();
            ships[2] = new ManowarShip();
            ships[3] = new ManowarShip();
            ships[4] = new ManowarShip();
            

            grid = new LocationState[10, 10];
            for(int i = 0; i < 10; i++) {
                for(int j = 0; j < 10; j++) {
                    grid[i, j] = LocationState.EMPTY;
                }
            }

            initiateShipPlacement();
        }



        public void initiateShipPlacement() {
            ships[0].setLocation(new Point[] { new Point(1, 2), new Point(1, 3), new Point(1, 4), new Point(1, 5), new Point(1, 6) });
            ships[1].setLocation(new Point[] { new Point(3, 2), new Point(3, 3), new Point(3, 4), new Point(3, 5), new Point(3, 6) });
            ships[2].setLocation(new Point[] { new Point(9, 0), new Point(9, 1), new Point(9, 2), new Point(9, 3), new Point(9, 4) });
            ships[3].setLocation(new Point[] { new Point(5, 1), new Point(5, 2), new Point(5, 3), new Point(5, 4), new Point(5, 5) });
            ships[4].setLocation(new Point[] { new Point(8, 2), new Point(8, 3), new Point(8, 4), new Point(8, 5), new Point(8, 6) });
        }

        public LocationState[,] getBoardForDrawing() {
            return grid;
        }

        //temp class
        public bool hasShip(Point p){
            for(int i = 0; i < ships.Length; i++) {
                if(ships[i].checkForHit(p)) {
                    return true;
                } 
            }
            return false;
        }


        public LocationState strikeCoordinates(Point p) {
            if(grid[p.X, p.Y] != LocationState.EMPTY) {
                return LocationState.CLICKED;
            }
            for(int i = 0; i < ships.Length; i++) {
                if(ships[i].checkForHit(p)) {
                    return LocationState.HIT;
                } 
            }
            return LocationState.MISS;
        }


    }
}
