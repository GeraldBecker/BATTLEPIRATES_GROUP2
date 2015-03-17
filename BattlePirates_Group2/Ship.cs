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
        // Size of ship for testing if location size is correct
        private int _size;

        // Types of ships
        // MW (Man o'War = 5 squares), GA (Galleon = 4), BR (Briq = 3), BA (Bargue = 2)
        public enum _types {MW, GA, BR, BA};

        // The type of ship
        public _types _shipType;

        //private bool _sunk;// if the ship is sunk
        private bool _activated;// if placed on board

        // Holds the grid location of a vertical ship
        // <int row, int col>
        private SortedDictionary<int, int> _vertLocation;

        // Holds the grid location of a horizontal ship
        // <int col, int row>
        private SortedDictionary<int, int> _horLocation;

        // The orientation of the ship
        // value set from the PlayerBoard object
        private bool _horizontal;

        /// <summary>
        /// constructor initializes _activated
        /// </summary>
        public Ship()
        {
            _activated = false;
        }


        public _types ShipType
        {
            get
            {
                return _shipType;
            }
            set
            {
                _shipType = value;
            }
        }
        // properties for _size
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }

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
        public void setVertLocation(SortedDictionary<int, int> location)
        {
            _vertLocation = location;
            IsHorizontal = false;
        }

        // sets the location for a horizontal ship
        public void setHorLocation(SortedDictionary<int, int> location)
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
