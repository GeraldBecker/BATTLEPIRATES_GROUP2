using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
    /// <summary>
    /// For transmitting message as bytes array
    /// </summary>
    public class TransmitMessage {
        private byte[] myData;

        public byte[] Data {
            get {
                return myData;
            }
            set {
                myData = value;
            }
        }
    }
}
