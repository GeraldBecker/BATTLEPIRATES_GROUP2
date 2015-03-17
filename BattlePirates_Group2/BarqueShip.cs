using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
    [Serializable]
    class BarqueShip : BaseShip {
        const int SHIPSIZE = 2;

        public BarqueShip() : base(SHIPSIZE) {
            
        }
    }
}
