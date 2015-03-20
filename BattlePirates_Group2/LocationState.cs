using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
    /// <summary>
    /// Location states of grid squares as enumerated types
    /// </summary>
    [Serializable]
    enum LocationState {
        MISS,
        HIT,
        EMPTY,
        //SUNK,
        CLICKED
    }
}
