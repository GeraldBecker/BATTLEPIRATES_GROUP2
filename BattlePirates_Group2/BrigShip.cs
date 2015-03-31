using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
    [Serializable]
    public class BrigShip : BaseShip {
        //the size of this child class of ship
        const int SHIPSIZE = 3;

        /// <summary>
        /// Constructor
        /// sets the size of the ship
        /// </summary>
        public BrigShip() : base(SHIPSIZE) {
            
        }
    }
}
