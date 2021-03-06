﻿using System;
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
    public abstract class BaseShip {

        protected int totalSize;// the size passed by the child
        protected int health;// totalSize minus hits
        protected Point[] location;// the grids ship occupies
        protected Point[] hitLocations;
        protected bool isVert;// if vertically oriented

        private const int BLOCKWIDTH = 25;// grid block size
        private const int START_X = 3;// offset for grid from left
        private const int START_Y = 12;// offset for grid from top

        /// <summary>
        /// Constructor - used by child class to instantiate
        /// </summary>
        /// <param name="size">
        /// The size of each child ship
        /// </param>
        public BaseShip(int size) {
            totalSize = health = size;
            location = hitLocations = new Point[size];
            for(int i = 0; i < hitLocations.Length; i++) {
                hitLocations[i] = new Point(-1, -1);
            }
            
        }

        /// <summary>
        /// Sets location of ship on grid
        /// </summary>
        /// <param name="newLocation">
        /// Point representation of the square location on the GameBoard grid
        /// that the ship is set to
        /// </param>
        /// <param name="isVert"></param>
        /// <returns>
        /// true when set
        /// </returns>
        public bool setLocation(Point[] newLocation, bool isVert) {
            location = newLocation;
            this.isVert = isVert;
            return true;
        }

        /// <summary>
        /// Property for isVert
        /// </summary>
        /// <returns>
        /// Bool representation of the verticalness of the ship
        /// </returns>
        public bool isVertical() {
            return isVert;
        }

        /// <summary>
        /// Property for location
        /// </summary>
        /// <returns>
        /// Array of Point representations of squares the ship is 
        /// set to. (located)
        /// </returns>
        public Point[] getLocation() {
            return location;
        }

        /// <summary>
        /// Grid bounds checking
        /// </summary>
        /// <returns>
        /// true if ship outside of GameBoard grid, false otherwise
        /// </returns>
        public bool outsideGrid()
        {
            for (int i = 0; i < location.Length; i++)
            {
                Console.WriteLine("location[" + i + "].X: " + location[i].X);
                Console.WriteLine("location[" + i + "].Y: " + location[i].Y);
                if (location[i].X < START_Y || location[i].X > (START_Y + 9))
                {
                    return true;
                }
                else if (location[i].Y < START_X || location[i].Y > (START_X + 9))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check if ship exists at Point
        /// </summary>
        /// <param name="p">
        /// Point representation of square of gameBoard grid
        /// </param>
        /// <returns>
        /// true if exists, false otherwise
        /// </returns>
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
        /// <param name="p">
        /// Point representation of square of gameBoard grid
        /// </param>
        /// <returns>
        /// True if ship is located in the Point representation square from gameBoard grid
        /// </returns>
        public bool checkForHit(Point p)
        {
            for (int i = 0; i < location.Length; i++)
            {
                if(location[i] == p && hitLocations[i] != p)
                {
                    Console.WriteLine("hit point: " + p.X + " Y: " + p.Y);
                    hitLocations[i] = new Point(-1, -1);//changed
                    health--;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns if the ship is sunk - 0 health
        /// </summary>
        /// <returns>
        /// true if ship is sunk, false otherwise
        /// </returns>
        public bool isSunk() {
            return health == 0;
        }
    } 
}
