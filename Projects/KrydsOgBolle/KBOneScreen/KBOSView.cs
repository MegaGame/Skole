using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBOneScreen
{
    public partial class KBOSView : Form
    {
        String[,] Board = new string[3, 3];
        string currentPlayer;
        int NumbersOfX;
        int NumbersOfO;
        Boolean gameOver;
        Bitmap Xpic = new Bitmap(Application.StartupPath + @"\Pics\kryds.jpg");
        Bitmap Opic = new Bitmap(Application.StartupPath + @"\Pics\bolle.jpg");
        public KBOSView()
        {
            InitializeComponent();
            NewGame();
        }
        private void NewGame()
        {
            currentPlayer = "X";
            NumbersOfX = 0;
            NumbersOfO = 0;
            gameOver = false;
            ClearBoard();
        }
        private void ClearBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Board[i, y] = null;
                }
            }
            pictureBox00.Image = null;
            pictureBox01.Image = null;
            pictureBox02.Image = null;
            pictureBox10.Image = null;
            pictureBox11.Image = null;
            pictureBox12.Image = null;
            pictureBox20.Image = null;
            pictureBox21.Image = null;
            pictureBox22.Image = null;
        }
        private void ChangeCurrentPlayer()
        {            
            if (gameOver == false)
            {
                if (currentPlayer == "X")
                {
                    currentPlayer = "O";
                    textBoxPlayer.Text = "Spiller O har tur";
                }
                else
                {
                    currentPlayer = "X";
                    textBoxPlayer.Text = "Spiller X har tur";
                }
            } 
        }
        private string MakeAMove(int[] place)
        {
            if (gameOver == false)
            {
                if (currentPlayer == "X")
                {
                    if (NumbersOfX < 3 && Board[place[0], place[1]] == null)
                    {
                        NumbersOfX++;
                        Board[place[0], place[1]] = "X";
                        TestForWin();
                        ChangeCurrentPlayer();
                        return "X";                       
                    }
                    else if (NumbersOfX == 3 && Board[place[0], place[1]] == "X")
                    {
                        NumbersOfX--;
                        Board[place[0], place[1]] = null;
                        return "clear";
                    }
                    return "ERROR";
                }
                else if (currentPlayer == "O")
                {
                    if (NumbersOfO < 3 && Board[place[0], place[1]] == null)
                    {
                        NumbersOfO++;
                        Board[place[0], place[1]] = "O";
                        TestForWin();
                        ChangeCurrentPlayer();
                        return "O";                        
                    }
                    else if (NumbersOfO == 3 && Board[place[0], place[1]] == "O")
                    {
                        NumbersOfO--;
                        Board[place[0], place[1]] = null;
                        return "clear";                        
                    }
                    return "ERROR";
                }
            }            
            return "ERROR";
        }
        private void TestForWin()
        {
            Boolean b = LongTest();
            if (b == true)
            {
                gameOver = b;
                textBoxPlayer.Text = "Spiller " + currentPlayer + " har vundet";
            }
        }
        private Boolean LongTest()
        {
            if (Board[0,0] == currentPlayer && Board[0, 1] == currentPlayer && Board[0, 2] == currentPlayer)
            {
                return true;
            }
            else if (Board[1, 0] == currentPlayer && Board[1, 1] == currentPlayer && Board[1, 2] == currentPlayer)
            {
                return true;
            }
            else if (Board[2, 0] == currentPlayer && Board[2, 1] == currentPlayer && Board[2, 2] == currentPlayer)
            {
                return true;
            }
            else if (Board[0, 0] == currentPlayer && Board[1, 0] == currentPlayer && Board[2, 0] == currentPlayer)
            {
                return true;
            }
            else if (Board[0, 1] == currentPlayer && Board[1, 1] == currentPlayer && Board[2, 1] == currentPlayer)
            {
                return true;
            }
            else if (Board[0, 2] == currentPlayer && Board[1, 2] == currentPlayer && Board[2, 2] == currentPlayer)
            {
                return true;
            }
            else if (Board[0, 0] == currentPlayer && Board[1, 1] == currentPlayer && Board[2, 2] == currentPlayer)
            {
                return true;
            }
            else if (Board[0, 2] == currentPlayer && Board[1, 1] == currentPlayer && Board[2, 0] == currentPlayer)
            {
                return true;
            }
            return false;
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        private void pictureBox00_MouseClick(object sender, MouseEventArgs e)
        {
            string rs;
            int[] pos = new int[2];
            pos[0] = 0;
            pos[1] = 0;
            rs = MakeAMove(pos);

            if (rs == "X")
            {
                pictureBox00.Image = Xpic;
            }
            else if (rs == "O")
            {
                pictureBox00.Image = Opic;
            }
            else if (rs == "clear")
            {
                pictureBox00.Image = null;
            }
                        
        }

        private void pictureBox01_MouseClick(object sender, MouseEventArgs e)
        {
            string rs;
            int[] pos = new int[2];
            pos[0] = 0;
            pos[1] = 1;
            rs = MakeAMove(pos);

            if (rs == "X")
            {
                pictureBox01.Image = Xpic;
            }
            if (rs == "O")
            {
                pictureBox01.Image = Opic;
            }
            else if (rs == "clear")
            {
                pictureBox01.Image = null;
            }
        }

        private void pictureBox02_MouseClick(object sender, MouseEventArgs e)
        {
            string rs;
            int[] pos = new int[2];
            pos[0] = 0;
            pos[1] = 2;
            rs = MakeAMove(pos);

            if (rs == "X")
            {
                pictureBox02.Image = Xpic;
            }
            if (rs == "O")
            {
                pictureBox02.Image = Opic;
            }
            else if (rs == "clear")
            {
                pictureBox02.Image = null;
            }
        }

        private void pictureBox10_MouseClick(object sender, MouseEventArgs e)
        {
            string rs;
            int[] pos = new int[2];
            pos[0] = 1;
            pos[1] = 0;
            rs = MakeAMove(pos);

            if (rs == "X")
            {
                pictureBox10.Image = Xpic;
            }
            if (rs == "O")
            {
                pictureBox10.Image = Opic;
            }
            else if (rs == "clear")
            {
                pictureBox10.Image = null;
            }
        }

        private void pictureBox11_MouseClick(object sender, MouseEventArgs e)
        {
            string rs;
            int[] pos = new int[2];
            pos[0] = 1;
            pos[1] = 1;
            rs = MakeAMove(pos);

            if (rs == "X")
            {
                pictureBox11.Image = Xpic;
            }
            if (rs == "O")
            {
                pictureBox11.Image = Opic;
            }
            else if (rs == "clear")
            {
                pictureBox11.Image = null;
            }
        }

        private void pictureBox12_MouseClick(object sender, MouseEventArgs e)
        {
            string rs;
            int[] pos = new int[2];
            pos[0] = 1;
            pos[1] = 2;
            rs = MakeAMove(pos);

            if (rs == "X")
            {
                pictureBox12.Image = Xpic;
            }
            if (rs == "O")
            {
                pictureBox12.Image = Opic;
            }
            else if (rs == "clear")
            {
                pictureBox12.Image = null;
            }
        }

        private void pictureBox20_MouseClick(object sender, MouseEventArgs e)
        {
            string rs;
            int[] pos = new int[2];
            pos[0] = 2;
            pos[1] = 0;
            rs = MakeAMove(pos);

            if (rs == "X")
            {
                pictureBox20.Image = Xpic;
            }
            if (rs == "O")
            {
                pictureBox20.Image = Opic;
            }
            else if (rs == "clear")
            {
                pictureBox20.Image = null;
            }
        }

        private void pictureBox21_MouseClick(object sender, MouseEventArgs e)
        {
            string rs;
            int[] pos = new int[2];
            pos[0] = 2;
            pos[1] = 1;
            rs = MakeAMove(pos);

            if (rs == "X")
            {
                pictureBox21.Image = Xpic;
            }
            if (rs == "O")
            {
                pictureBox21.Image = Opic;
            }
            else if (rs == "clear")
            {
                pictureBox21.Image = null;
            }
        }

        private void pictureBox22_MouseClick(object sender, MouseEventArgs e)
        {
            string rs;
            int[] pos = new int[2];
            pos[0] = 2;
            pos[1] = 2;
            rs = MakeAMove(pos);

            if (rs == "X")
            {
                pictureBox22.Image = Xpic;
            }
            if (rs == "O")
            {
                pictureBox22.Image = Opic;
            }
            else if (rs == "clear")
            {
                pictureBox22.Image = null;
            }
        }
    }
}
