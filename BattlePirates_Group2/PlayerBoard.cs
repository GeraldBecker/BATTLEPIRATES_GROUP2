using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2
{
    /// <summary>
    /// 
    /// </summary>
    class PlayerBoard
    {
        // Array to hold the playerBoard SquareState
        private SquareState[,] _grid;

        // Choice of states for the Squares of the PlayerBoard
        private enum SquareState {Empty, Miss, Hit, MW, GA, BR, BA};

        // Constructor for PlayerBoard
        public PlayerBoard()
        {
            _grid = new SquareState[10, 10];
        }

        // 
        public void reset()
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    _grid[i, j] = SquareState.Empty;
                }
            }
        }
        public void set(Ship ship, int row, int col)
        {
            _grid[row, col] = (SquareState) ship.ShipType;
        }

        public void unSet(int row, int col)
        {
            _grid[row, col] = SquareState.Empty;
        }

        public void hit(int row, int col)
        {

        }
    }
}
