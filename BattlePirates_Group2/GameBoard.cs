using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
    /// <summary>
    /// The GameBoard of each player
    /// Holds the state of each square on the grid of the 
    /// GameBoard.
    /// Also holds the ships array that holds ships
    /// that in turn hold their own locations
    /// </summary>
    [Serializable]
    class GameBoard {

        private BaseShip[] ships;
        private LocationState[,] grid;

        /// <summary>
        /// Constructor
        /// </summary>
        public GameBoard() {
            ships = new BaseShip[5];// ships array

            // Why is it all ManowarShip?  should it be baseship?
            ships[0] = new ManowarShip();
            ships[1] = new ManowarShip();
            ships[2] = new ManowarShip();
            ships[3] = new ManowarShip();
            ships[4] = new ManowarShip();
            
            // constructs the grid (GameBoard) and sets it to empty
            grid = new LocationState[10, 10];
            for(int i = 0; i < 10; i++) {
                for(int j = 0; j < 10; j++) {
                    grid[i, j] = LocationState.EMPTY;
                }
            }

            //initiateShipPlacement();
        }


        /// <summary>
        /// Sets the ships location and placement by passing in 
        /// ships array.
        /// </summary>
        /// <param name="ships"></param>
        public void initiateShipPlacement(BaseShip[] ships) {
            /*ships[0].setLocation(new Point[] { new Point(1, 2), new Point(1, 3), new Point(1, 4), new Point(1, 5), new Point(1, 6) }, false);
            ships[1].setLocation(new Point[] { new Point(3, 2), new Point(3, 3), new Point(3, 4), new Point(3, 5), new Point(3, 6) }, false);
            ships[2].setLocation(new Point[] { new Point(9, 0), new Point(9, 1), new Point(9, 2), new Point(9, 3), new Point(9, 4) }, false);
            ships[3].setLocation(new Point[] { new Point(5, 1), new Point(5, 2), new Point(5, 3), new Point(5, 4), new Point(5, 5) }, false);
            ships[4].setLocation(new Point[] { new Point(8, 2), new Point(8, 3), new Point(8, 4), new Point(8, 5), new Point(8, 6) }, false);*/

            this.ships = ships;
        }

        /// <summary>
        /// Returns the grid (GameBoard) to paint
        /// </summary>
        /// <returns></returns>
        public LocationState[,] getBoardForDrawing() {
            return grid;
        }

        //temp class
        public bool hasShip(Point p){
            for(int i = 0; i < ships.Length; i++) {
                if(ships[i].checkForShip(p)) {
                    return true;
                } 
            }
            return false;
        }

        /// <summary>
        /// The strike logic.  Checks for grid square state
        /// then updates the respective grid (GameBoard)
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public LocationState strikeCoordinates(Point p) {
            /*if(grid[p.X, p.Y] != LocationState.EMPTY) {
                return LocationState.CLICKED;
            }*/
            if (grid[p.X, p.Y] == LocationState.EMPTY)
            {
                for (int i = 0; i < ships.Length; i++)
                {
                    if (ships[i].checkForHit(p))
                    {
                        grid[p.X, p.Y] = LocationState.HIT;
                        return LocationState.HIT;
                    }
                }
                grid[p.X, p.Y] = LocationState.MISS;
                return LocationState.MISS;
            }
            return LocationState.CLICKED;
        }

        /// <summary>
        /// Getter for ships array
        /// </summary>
        /// <returns></returns>
        public BaseShip[] getShips()
        {
            return ships;
        }
    }
}
