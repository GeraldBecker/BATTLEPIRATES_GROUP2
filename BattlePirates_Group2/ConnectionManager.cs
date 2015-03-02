using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
    
    class ConnectionManager {
        private IPAddress IP;
        private int PORT;


        public ConnectionManager() {
            //IP = IPAddress.Parse("192.168.1.108");
            PORT = 1116;

            string hostName = Dns.GetHostName();
            Console.WriteLine("Host name: " + hostName.ToString());
            IPHostEntry ipEntries = Dns.GetHostEntry(hostName);
            IPAddress[] ipAddresses = ipEntries.AddressList;
            //IP = ipAddresses[0];
            //Console.WriteLine(ipAddresses[0].ToString());
            //Console.WriteLine(IP.ToString());
            for(int i = 0; i < ipAddresses.Length; i++) {
                Console.WriteLine("IP Address {0}: {1} : {2}", i, ipAddresses[i].ToString(), ipAddresses[i].AddressFamily);
                Console.WriteLine(ipAddresses[i].AddressFamily);
                if(ipAddresses[i].AddressFamily.ToString() == ProtocolFamily.InterNetwork.ToString()) {
                    Console.WriteLine("FOUND HIM");
                    IP = ipAddresses[i];
                    break;
                }
            }

        }

        public string getIPString() {
            return IP.ToString();
        }


    }
}
