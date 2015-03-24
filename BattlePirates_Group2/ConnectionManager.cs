using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
    
    public class ConnectionManager {
        private IPAddress IP;
        private int PORT;
        private TcpClient CLIENT;
        private TcpListener SERVER;
        private NetworkStream NETWORKSTREAM;

        public enum SquareState { Empty, Miss, Hit, MW, GA, BR, BA };

        public ConnectionManager() {
            //Create a default port
            PORT = 1116; 
            

        }

        /// <summary>
        /// Initiates the server connection by obtaining the IP address of the host computer.
        /// The IP Address is then stored and used for future calls to start the server.
        /// </summary>
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
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

        

        public string getIPString() {
            return IP.ToString();
        }

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

        public TransmitMessage getGamePoint() {
            byte[] dataLength = new byte[4];
            NETWORKSTREAM.Read(dataLength, 0, 4);
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

        public void sendGameBoard(TransmitMessage msg) {
            int length = msg.Data.Length;
            Console.WriteLine("Sending length: " + length);
            try {
                byte[] dataLength = BitConverter.GetBytes((Int32)length);
                NETWORKSTREAM.Write(dataLength, 0, 4);
                NETWORKSTREAM.Write(msg.Data, 0, msg.Data.Length);
                //The below line of code delays the thread to allow the sending of the entire stream before the next form is loaded. 
                //Fix this issue if possible. 
                Thread.Sleep(10000);
            } catch(Exception ex) {
                Console.WriteLine("We failed");
                Console.WriteLine(ex.StackTrace);

            }
        }

        public TransmitMessage getGameBoard() {
            byte[] dataLength = new byte[4];
            NETWORKSTREAM.Read(dataLength, 0, 4);
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
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool sendData(int[,] data) {
            try {
                string dataString = "";
                for(int y = 0; y < 10; y++)
                    for(int x = 0; x < 10; x++)
                        dataString += data[y,x];

                byte[] bytes = new byte[255];
                bytes = new ASCIIEncoding().GetBytes(dataString);
                NETWORKSTREAM.Write(bytes, 0, bytes.Length);
            } catch(Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int[,] getData() {

            byte[] bytes = new byte[255];
            NETWORKSTREAM.Read(bytes, 0, bytes.Length);
            string dataString = new ASCIIEncoding().GetString(bytes);
            char[] charOfTemp = dataString.ToCharArray();
            int[,] data = new int[10, 10];
            for(int y = 0; y < 10; y++)
                for(int x = 0; x < 10; x++)
                    data[y, x] = Int32.Parse("" + charOfTemp[(y * 3) + x]);
            return data;
        }

        public bool sendData2(gameForm.SquareState[,] grid) {
            try {
                string dataString = "";
                for(int y = 0; y < 10; y++)
                    for(int x = 0; x < 10; x++)
                        dataString += grid[y, x];

                byte[] bytes = new byte[255];
                bytes = new ASCIIEncoding().GetBytes(dataString);
                NETWORKSTREAM.Write(bytes, 0, bytes.Length);
            } catch(Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
            
        }

        public gameForm.SquareState[,] getData2() {

            byte[] bytes = new byte[255];
            NETWORKSTREAM.Read(bytes, 0, bytes.Length);
            string dataString = new ASCIIEncoding().GetString(bytes);
            char[] charOfTemp = dataString.ToCharArray();
            gameForm.SquareState[,] data = new gameForm.SquareState[10, 10];
            for(int y = 0; y < 10; y++)
                for(int x = 0; x < 10; x++)
                    data[y, x] = gameForm.SquareState.BR;//Int32.Parse("" + charOfTemp[(y * 3) + x]);
            return data;
        }
        //The below code is for reference purposes only from MSDN.
        /*
        public void writeIt() {
            try {
                if(NETWORKSTREAM.CanWrite) {

                    byte[] myWriteBuffer = Encoding.ASCII.GetBytes("Are you receiving this message?");
                    NETWORKSTREAM.Write(myWriteBuffer, 0, myWriteBuffer.Length);
                } else {
                    Console.WriteLine("Sorry.  You cannot write to this NetworkStream.");
                }
            } catch {
                Console.WriteLine("caught writing exp");
            }
            
        }
        public bool readIt() {
            bool gotWord = false;
            Console.WriteLine("Starting to read");
            

                try {
                    // Check to see if this NetworkStream is readable. 
                    if(NETWORKSTREAM.CanRead) {
                        byte[] myReadBuffer = new byte[1024];
                        StringBuilder myCompleteMessage = new StringBuilder();
                        int numberOfBytesRead = 0;

                        // Incoming message may be larger than the buffer size. 
                        do {
                            numberOfBytesRead = NETWORKSTREAM.Read(myReadBuffer, 0, myReadBuffer.Length);

                            myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));

                        }
                        while(NETWORKSTREAM.DataAvailable);

                        // Print out the received message to the console.
                        Console.WriteLine("You received the following message : " +
                                                     myCompleteMessage);
                        gotWord = true;
                    } else {
                        Console.WriteLine("Sorry.  You cannot read from this NetworkStream.");
                        
                    }
                } catch {
                    Console.WriteLine("caught reading exception");
                    
                }




                
            Console.WriteLine("EXITED THE readit function");
            return gotWord;
            
        }*/
    }
}
