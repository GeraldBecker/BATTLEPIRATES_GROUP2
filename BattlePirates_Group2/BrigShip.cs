using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
    [Serializable]
    class BrigShip : BaseShip {
        const int SHIPSIZE = 3;
        int x = 0;

        //somecomments
        public BrigShip() : base(SHIPSIZE) {
            
        }
    }
}
