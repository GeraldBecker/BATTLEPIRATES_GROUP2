using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
    
    class ConnectionManager {
        private IPAddress IP;
        private int PORT;

        public ConnectionManager() {
            IP = IPAddress.Parse("192.168.1.108");
            PORT = 1116;

            string sHostName = Dns.GetHostName();
            IPHostEntry ipE = Dns.GetHostByName(sHostName);
            IPAddress[] IpA = ipE.AddressList;
            IP = IpA[0];
            /*for(int i = 0; i < IpA.Length; i++) {
                Console.WriteLine("IP Address {0}: {1} ", i, IpA[i].ToString());
            }*/

        }


    }
}
