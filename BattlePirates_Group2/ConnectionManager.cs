using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;

namespace BattlePirates_Group2 {
    /// <summary>
    /// Handles all connections using tcp/ip protocols
    /// </summary>
    public class ConnectionManager {
        private IPAddress IP;
        private int PORT;
        private TcpClient CLIENT;
        private TcpListener SERVER;
        private NetworkStream NETWORKSTREAM;

        public ConnectionManager() {
            //Create a default port
            PORT = 1116; 
        }

        /// <summary>
        /// Initiates the server connection by obtaining the IP address of the host computer.
        /// The IP Address is then stored and used for future calls to start the server.
        /// </summary>
        /// <returns>
        /// true if finds a local ip address, false otherwise
        /// </returns>
        public bool initiateServer() {
            string hostName = Dns.GetHostName();
            Console.WriteLine("Host name: " + hostName.ToString());
            IPHostEntry ipEntries = Dns.GetHostEntry(hostName);
            IPAddress[] ipAddresses = ipEntries.AddressList;

            //Cycle through available address and find the local IP Address
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
        
        /// <summary>
        /// Starts listening for incoming connections on a specified IP and PORT.
        /// </summary>
        /// <returns>
        /// true if connected, false otherwise
        /// </returns>
        public bool startServer() {
            try {
                SERVER = new TcpListener(IP, PORT);
            } catch(ArgumentNullException) {
                return false;
            } catch(ArgumentOutOfRangeException) {
                return false;
            }

            try {
                SERVER.Start();
            } catch(SocketException) {
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Waits for the client to connect and obtains the stream to send data back and forth.
        /// </summary>
        /// <returns>
        /// true if connected, false otherwise
        /// </returns>
        public bool waitForClient() {
            try {
                //SERVER.AcceptTcpClientAsync();
                CLIENT = SERVER.AcceptTcpClient();
                
            } catch(InvalidOperationException) {
                return false;
            } catch(SocketException) {
                return false;
            }

            try {
                NETWORKSTREAM = CLIENT.GetStream();
            } catch(ObjectDisposedException) {
                return false;
            } catch(InvalidOperationException) {
                return false;
            } 
            return true;
        }


        /// <summary>
        /// Initiates the client side connection by storing the IP address of the host.
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool initiateClient(string ip) {
            IP = IPAddress.Parse(ip);
            CLIENT = new TcpClient();
            return true;
        }

        /// <summary>
        /// Connects to the host and obtains the stream to send data back and forth.
        /// </summary>
        /// <returns>
        /// true if connected, false otherwise
        /// </returns>
        public bool clientConnect() {
            try {
                CLIENT.Connect(IP, PORT);
                NETWORKSTREAM = CLIENT.GetStream();
                
                
            } catch(ArgumentNullException) {
                return false;
            } catch(ArgumentOutOfRangeException) {
                return false;
            } catch(SocketException) {
                return false;
            } catch(ObjectDisposedException) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Stops the server connection before exiting back to the main menu.
        /// </summary>
        public void stopServer() {
            if(SERVER != null) {
                try {
                    SERVER.Stop();
                } catch(SocketException) {
                    Console.WriteLine("Unable to stop");
                }
            }
                
        }
        
        /// <summary>
        /// Properties for IP
        /// </summary>
        /// <returns></returns>
        public string getIPString() {
            return IP.ToString();
        }

        /// <summary>
        /// Sends the player's shots to opponent
        /// </summary>
        /// <param name="msg"></param>
        public void sendGamePoint(TransmitMessage msg) {
            int length = msg.Data.Length;
            Console.WriteLine("Sending length: " + length);
            try {
                byte[] dataLength = BitConverter.GetBytes((Int32)length);
                NETWORKSTREAM.Write(dataLength, 0, 4);
                NETWORKSTREAM.Write(msg.Data, 0, msg.Data.Length);
                //The below line of code delays the thread to allow the sending of the entire stream before the next form is loaded. 
                //Fix this issue if possible. 
                //Thread.Sleep(10000);
            } catch(Exception ex) {
                Console.WriteLine("We failed");
                Console.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Receives opponents shots
        /// </summary>
        /// <returns>
        /// The opponents shots received
        /// </returns>
        public TransmitMessage getGamePoint() {
            byte[] dataLength = new byte[4];
            try
            {
                NETWORKSTREAM.Read(dataLength, 0, 4);
            }
            catch(System.ObjectDisposedException ex)
            {
                //SoundPlayer snd2 = new SoundPlayer(Properties.Resources.disconnect_11_converted);
                //snd2.Play();
            } catch (System.IO.IOException ex) {
                return null;
            }
            
            int dataLen = BitConverter.ToInt32(dataLength, 0);
            Console.WriteLine("Receiving length: " + dataLen);
            TransmitMessage msg = new TransmitMessage();
            msg.Data = new byte[dataLen];
            Console.WriteLine();
            try {
                NETWORKSTREAM.Read(msg.Data, 0, dataLen);
            } catch(System.ArgumentNullException ex) {
                Console.WriteLine("arg null exception");
            } catch(System.ArgumentOutOfRangeException ex) {
                Console.WriteLine("arg out of range");
            } catch(System.IO.IOException) {
                Console.WriteLine("io excp");
            } catch(System.ObjectDisposedException) {
                Console.WriteLine("object disposed");
            }
            return msg;
        }

        /// <summary>
        /// Sends gameBoard to opponent
        /// </summary>
        /// <param name="msg"></param>
        public void sendGameBoard(TransmitMessage msg) {
            int length = msg.Data.Length;
            Console.WriteLine("Sending length: " + length);
            try {
                byte[] dataLength = BitConverter.GetBytes((Int32)length);
                NETWORKSTREAM.Write(dataLength, 0, 4);
                NETWORKSTREAM.Write(msg.Data, 0, msg.Data.Length);

                //SoundPlayer snd = new SoundPlayer(Properties.Resources.avwait);
                //snd.Play();

                //The below line of code delays the thread to allow the sending of the entire stream before the next form is loaded. 
                //Fix this issue if possible. 
                //Thread.Sleep(5000);
            } catch(Exception ex) {
                Console.WriteLine("We failed");
                Console.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Receives gameBoard from opponent
        /// </summary>
        /// <returns></returns>
        public TransmitMessage getGameBoard() {
            byte[] dataLength = new byte[4];
            try {
                Console.WriteLine("Trying to read the length");
                NETWORKSTREAM.Read(dataLength, 0, 4);
                Console.WriteLine("Read the length");
            } catch(ObjectDisposedException) {
                Console.WriteLine("Object disposed");
            }
            //Delay the thread to allow for the length to be received.
            Thread.Sleep(2000);
            int dataLen = BitConverter.ToInt32(dataLength, 0);
            Console.WriteLine("Receiving length: " + dataLen);
            TransmitMessage msg = new TransmitMessage();
            msg.Data = new byte[dataLen];
            Console.WriteLine();
            try {
                Console.WriteLine("Starting network read");
                NETWORKSTREAM.Read(msg.Data, 0, dataLen);
                Console.WriteLine("Ending the network read");
            } catch(System.ArgumentNullException ex) {
                Console.WriteLine("arg null exception");
            } catch(System.ArgumentOutOfRangeException ex) {
                Console.WriteLine("arg out of range");
            } catch(System.IO.IOException) {
                Console.WriteLine("io excp");
            } catch(System.ObjectDisposedException) {
                Console.WriteLine("object disposed");
            }

            Console.WriteLine("returning the message");
            return msg;
        }

        public void stopConnection() {
            NETWORKSTREAM.Close();
            SERVER.Stop();
            CLIENT.Close();
            
        }

        public void stopNetwork()
        {
            NETWORKSTREAM.Close();
        }

        
    }
}
