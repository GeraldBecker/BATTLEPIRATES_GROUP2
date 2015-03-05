using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattlePirates_Group2 {
    public partial class shipPlaceForm : Form {
        private ConnectionManager connection;
        private MainForm owner;
        private int[,] board; //not a jagered array
        private bool isTurn;


        public shipPlaceForm(MainForm owner, ConnectionManager connection, bool whosturn) {
            InitializeComponent();
            this.owner = owner;
            this.connection = connection;
            board = new int[10, 10];
            isTurn = whosturn;

            this.owner = owner;
            this.DesktopLocation = owner.Location;
        }

        private void taskGetData() {
            Task.Factory.StartNew(() => {
                Console.WriteLine("TRYING TO GET THE BOARD");
                board = connection.getData();
                Console.WriteLine("GOT THE BOARD");
                isTurn = true;
                checkTurn();
            });
        }

        private void button1_Click(object sender, EventArgs e) {
            if(isTurn) {
                Random rnd = new Random();
                for(int i = 0; i < 10; i++) {
                    for(int j = 0; j < 10; j++) {

                        board[i, j] = rnd.Next(0, 9);
                    }
                }
                connection.sendData(board);
                Console.WriteLine("WAS ABLE TO SEND THE BOARD");
                isTurn = false;
                checkTurn();
            }

        }

        private void checkTurn() {
            if(!this.InvokeRequired) {
                if(isTurn) {
                } else {
                    //If a move is made, call and create a task to wait to receive data.
                    taskGetData();
                }
                //resetText();
            } else
                this.Invoke((MethodInvoker)delegate {
                    checkTurn();
                });
        }

        private void shipPlaceForm_FormClosing(object sender, FormClosingEventArgs e) {
            Application.Exit();
        }

        private void shipPlaceForm_Load(object sender, EventArgs e) {
            checkTurn();
        }
    }
}
