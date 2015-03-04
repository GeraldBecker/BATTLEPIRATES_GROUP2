using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2
{
    /// <summary>
    /// Represents the player object
    /// </summary>
    class Player
    {
        // How many ships are placed
        private int _shipsPlaced;

        // How many ships are sunk
        private int _shipsSunk;

        // If won game
        private bool _win;

        /// <summary>
        /// Constructor to initialize data
        /// </summary>
        public Player()
        {
            _shipsPlaced = 0;
            _shipsSunk = 0;
            _win = false;
        }

        /// <summary>
        /// Sets the ship by calling PlayerBoard object
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="ship"></param>
        public void placeShip(PlayerBoard pb, Ship ship, int row, int col)
        {
            pb.set(ship, row, col);
        }

        /// <summary>
        /// Unsets the ship by calling PlayerBoard object
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="ship"></param>
        public void moveShip(PlayerBoard pb, Ship ship, int row, int col)
        {
            pb.unSet(row, col);
        }

        /// <summary>
        /// Sends a hit by calling PlayberBoard object
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void shoot(PlayerBoard pb, int row, int col)
        {
            pb.hit(row, col);
        }
    }
}
