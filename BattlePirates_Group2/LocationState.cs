using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
    /// <summary>
    /// Holds the state of each square on the grid
    /// </summary>
[Serializable]
    enum LocationState {
        MISS,
        HIT,
        EMPTY,
        SUNK,
        CLICKED,
        SHIP
    }
}
