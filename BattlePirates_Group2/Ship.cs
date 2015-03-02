using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BattlePirates_Group2
{
    /// <summary>
    /// Parent class of all ship types
    /// represents a ship and holds it's states
    /// </summary>
    class Ship
    {
        // how many health units left
        // determined by size of _location
        //private int _health;

        //private bool _sunk;// if the ship is sunk
        private bool _activated;// if placed on board

        // Holds the grid location of a vertical ship
        private SortedDictionary<int, char> _vertLocation;

        // Holds the grid location of a horizontal ship
        private SortedDictionary<char, int> _horLocation;

        // The orientation of the ship
        // value set from the PlayerBoard object
        private bool _horizontal;

        /// <summary>
        /// constructor initializes the _sunk and _activated
        /// data
        /// </summary>
        public Ship()
        {
            //_sunk = false;
            _activated = false;
        }

        // properties for health
        /*
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }*/

        /// <summary>
        /// Returns if the ship is sunk
        /// determined by the size of _location
        /// </summary>
        /// <returns></returns>
        public bool isSunk()
        {
            if (IsHorizontal == false)
            {
                return _vertLocation.Count == 0;
            }
            else
            {
                return _horLocation.Count == 0;
            }
        }

        // properties for _activated
        public bool Activated
        {
            get
            {
                return _activated;
            }
            set
            {
                _activated = value;
            }
        }

        // properties for _horizontal
        public bool IsHorizontal
        {
            get
            {
                return _horizontal;
            }
            set
            {
                _horizontal = value;
            }
        }

        // sets the location for a vertical ship
        public void setVertLocation(SortedDictionary<int, char> location)
        {
            _vertLocation = location;
            IsHorizontal = false;
        }

        // sets the location for a horizontal ship
        public void setHorLocation(SortedDictionary<char, int> location)
        {
            _horLocation = location;
            IsHorizontal = true;
        }

        // removes the entry for ship location
        public void setHit(int row, char col)
        {
            if(IsHorizontal == false)
            {
                _vertLocation.Remove(row);
            }
            else
            {
                _horLocation.Remove(col);
            }
        }
    }
}
