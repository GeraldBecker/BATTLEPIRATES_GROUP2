using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2
{
    class Ship
    {
        private int health;
        private bool sunk;
        private bool activated;
        private int[][] location;

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        public bool Sunk
        {

        }
    }
}
