using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
    [Serializable]
    class GameBoard {

        private BaseShip[] ships;
        private LocationState[,] grid;

        /// <summary>
        /// Constructor
        /// Logic Game Board for holding the game data
        /// Holds the grid and data
        /// Holds the ships array and data
        /// </summary>
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
        }


        /// <summary>
        /// Records the ship locations to grid locationState
        /// </summary>
        /// <param name="ships">
        /// Array of BaseShip types
        /// </param>
        public void initiateShipPlacement(BaseShip[] ships) {
            this.ships = ships;

            for(int r = 0; r < 10; r++) {
                for(int c = 0; c < 10; c++) {
                    if(hasShip(new Point(r, c))) {
                        grid[r, c] = LocationState.SHIP;
                    }
                }
            } 
        }

        /// <summary>
        /// Returns the locationsState of the GameBoard grid
        /// </summary>
        /// <returns>
        /// LocationState enums of square states of GameBoard grid
        /// </returns>
        public LocationState[,] getBoardForDrawing() {
            return grid;
        }

        /// <summary>
        /// Tests if square(point) occupied by a ship
        /// </summary>
        /// <param name="p">
        /// Point that is tested for a ship location
        /// </param>
        /// <returns>
        /// True is ship has Point as location, false otherwise
        /// </returns>
        public bool hasShip(Point p){
            for(int i = 0; i < ships.Length; i++) {
                if(ships[i].checkForShip(p)) {
                    return true;
                } 
            }
            return false;
        }

        /// <summary>
        /// Checks and updates player's shots with the chosen square
        /// on the grid
        /// </summary>
        /// <param name="p">
        /// Point representation of the square chosen by player to shoot at
        /// </param>
        /// <returns>
        /// LocationState enum representing the state of the point
        /// </returns>
        public LocationState strikeCoordinates(Point p) {
            Console.WriteLine("YOU ARE SENDING: [" + p.X + "," + p.Y+"]");
            //If the square has not been shot at before
            if(grid[p.X, p.Y] == LocationState.EMPTY || grid[p.X, p.Y] == LocationState.SHIP)
            {
                for (int i = 0; i < ships.Length; i++)
                {
                    //if it's a hit
                    if (ships[i].checkForHit(p))
                    {
                        grid[p.X, p.Y] = LocationState.HIT;

                        //If the ship is sunk, update each point to be sunk
                        if(ships[i].isSunk()) {
                            Point[] temp = ships[i].getLocation();
                            for(int x = 0; x < temp.Length; x++) {
                                Console.WriteLine("SUNK: " + temp[x].ToString());
                                grid[temp[x].X, temp[x].Y] = LocationState.SUNK;
                            }
                            return LocationState.SUNK;
                        }
                        return LocationState.HIT;
                    }
                }
                //if it's a miss
                grid[p.X, p.Y] = LocationState.MISS;
                return LocationState.MISS;
            }
            //if square has already been clicked - do nothing
            return LocationState.CLICKED;
        }

        /// <summary>
        /// Getter for ships
        /// </summary>
        /// <returns>
        /// The array of ships as BaseShip type objects
        /// </returns>
        public BaseShip[] getShips()
        {
            return ships;
        }
    }
}
