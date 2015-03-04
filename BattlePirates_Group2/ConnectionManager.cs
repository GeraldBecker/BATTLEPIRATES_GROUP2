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
        private TcpClient CLIENT;
        private TcpListener LISTENER;

        public ConnectionManager() {
            //Create a default port
            PORT = 1116; 
            

        }

        public bool initiateServer() {
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
                    IP = ipAddresses[i];
                    return true;
                }
            }
            return false;
        }

        

        public bool startServer() {
            LISTENER = new TcpListener(IP, PORT);
            LISTENER.Start();
            return true;
        }

        public bool initiateClient(string ip) {
            IP = IPAddress.Parse(ip);
            CLIENT = new TcpClient();
            return true;
        }

        public bool clientConnect() {
            try {
                CLIENT.Connect(IP, PORT);
                return true;
            } catch {
                return false;
            }
            
        }

        public void stopServer() {
            if(LISTENER != null)
                LISTENER.Stop();
        }

        public TcpClient getClient() {
            //LISTENER.AcceptTcpClientAsync();
            return LISTENER.AcceptTcpClient();
        }

        public string getIPString() {
            return IP.ToString();
        }


    }
}
