using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KrydsOgBolleOneScreenAI
{
    public partial class KNOSAIView : Form
    {
        //012
        //345
        //678
        string[] board = new string[9];
        string currentPlayer;
        int numbersOfX;
        int numbersOfO;
        Boolean gameOver;
        Bitmap Xpic = new Bitmap(Application.StartupPath + @"\Pics\kryds.jpg");
        Bitmap Opic = new Bitmap(Application.StartupPath + @"\Pics\bolle.jpg");

        public KNOSAIView()
        {
            InitializeComponent();
            NewGame();
        }
        private void NewGame()
        {
            currentPlayer = "X";
            numbersOfX = 0;
            numbersOfO = 0;
            gameOver = false;
            ClearBoard();

        }
        private void ClearBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = null;
            }
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
        }
        private void ChangeCurrentPlayer()
        {
            if (gameOver == false)
            {
                if (numbersOfX == 5)
                {
                    textBoxPlayer.Text = "Spillet er slut, ingen vandt";
                }
                else if (currentPlayer == "X")
                {
                    currentPlayer = "O";
                    textBoxPlayer.Text = "Spiller O har tur";
                    AIMove();
                }
                else
                {
                    currentPlayer = "X";
                    textBoxPlayer.Text = "Spiller X har tur";
                }
            }
        }
        private string MakeAMovePlayer(int place)
        {
            if (gameOver == false)
            {
                if (currentPlayer == "X")
                {
                    if (board[place] == null)
                    {
                        numbersOfX++;
                        board[place] = "X";
                        TestForWin();
                        ChangeCurrentPlayer();
                        return "X";
                    }                    
                    return "ERROR";
                }
                return "ERROR";
            }
            return "ERROR";
        }
        private void MakeAMoveAI(int place)
        {
            if (currentPlayer == "O")
            {
                if (board[place] == null)
                {
                    numbersOfO++;
                    board[place] = "O";
                    TestForWin();
                    ChangePic(place);
                    ChangeCurrentPlayer();
                }
            }
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
            if (board[0] == currentPlayer && board[1] == currentPlayer  && board[2] == currentPlayer)
            {
                return true;
            }
            else if (board[3] == currentPlayer && board[4] == currentPlayer && board[5] == currentPlayer)
            {
                return true;
            }
            else if (board[6] == currentPlayer && board[7] == currentPlayer && board[8] == currentPlayer)
            {
                return true;
            }
            else if (board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer)
            {
                return true;
            }
            else if (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer)
            {
                return true;
            }
            else if (board[0] == currentPlayer && board[3] == currentPlayer && board[6] == currentPlayer)
            {
                return true;
            }
            else if (board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer)
            {
                return true;
            }
            else if (board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
        private void ChangePic(int i)
        {
            if (i == 0)
            {
               pictureBox1.Image = Opic;
            }
            else if (i == 1)
            {
                pictureBox2.Image = Opic;
            }
            else if (i == 2)
            {
                pictureBox3.Image = Opic;
            }
            else if (i == 3)
            {
                pictureBox4.Image = Opic;
            }
            else if (i == 4)
            {
                pictureBox5.Image = Opic;
            }
            else if (i == 5)
            {
                pictureBox6.Image = Opic;
            }
            else if (i == 6)
            {
                pictureBox7.Image = Opic;
            }
            else if (i == 7)
            {
                pictureBox8.Image = Opic;
            }
            else if (i == 8)
            {
                pictureBox9.Image = Opic;
            }
        }
        private void AIMove()
        {
            if (numbersOfX == 1)
            {
                if (board[4] == "X")
                {
                    int[] ia = new int[4];
                    ia[0] = 0;
                    ia[1] = 2;
                    ia[2] = 6;
                    ia[3] = 8;
                    Random rng = new Random();
                    MakeAMoveAI(ia[rng.Next(0, 4)]);                    
                }
                else if (board[4] != "X")
                {
                    MakeAMoveAI(4);
                }
                else
                {
                    AIStandartMove();
                }

            }
            else if (numbersOfX >= 2)
            {
                int OCount = 0;
                int XCount = 0;
                Boolean moveMade = false;
                if (!moveMade)
                {
                    if (board[0] == "O")
                    {
                        OCount++;
                    }
                    if (board[1] == "O")
                    {
                        OCount++;
                    }
                    if (board[2] == "O")
                    {
                        OCount++;
                    }
                    if (board[0] == "X" || board[1] == "X" || board[2] == "X")
                    {
                        XCount++;
                    }
                    if (OCount == 2 && XCount == 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }
                if (!moveMade)
                {
                    OCount = 0;
                    XCount = 0;
                    if (board[3] == "O")
                    {
                        OCount++;
                    }
                    if (board[4] == "O")
                    {
                        OCount++;
                    }
                    if (board[5] == "O")
                    {
                        OCount++;
                    }
                    if (board[3] == "X" || board[4] == "X" || board[5] == "X")
                    {
                        XCount++;
                    }
                    if (OCount == 2 && XCount == 0)
                    {
                        for (int i = 3; i < 6; i++)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }
                if (!moveMade)
                {
                    OCount = 0;
                    XCount = 0;
                    if (board[6] == "O")
                    {
                        OCount++;
                    }
                    if (board[7] == "O")
                    {
                        OCount++;
                    }
                    if (board[8] == "O")
                    {
                        OCount++;
                    }
                    if (board[6] == "X" || board[7] == "X" || board[8] == "X")
                    {
                        XCount++;
                    }
                    if (OCount == 2 && XCount == 0)
                    {
                        for (int i = 7; i < 9; i++)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }
                if (!moveMade)
                {
                    OCount = 0;
                    XCount = 0;
                    if (board[0] == "O")
                    {
                        OCount++;
                    }
                    if (board[3] == "O")
                    {
                        OCount++;
                    }
                    if (board[6] == "O")
                    {
                        OCount++;
                    }
                    if (board[0] == "X" || board[3] == "X" || board[6] == "X")
                    {
                        XCount++;
                    }
                    if (OCount == 2 && XCount == 0)
                    {
                        for (int i = 0; i < 7; i += 3)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }
                if (!moveMade)
                {
                    OCount = 0;
                    XCount = 0;
                    if (board[1] == "O")
                    {
                        OCount++;
                    }
                    if (board[4] == "O")
                    {
                        OCount++;
                    }
                    if (board[7] == "O")
                    {
                        OCount++;
                    }
                    if (board[1] == "X" || board[4] == "X" || board[7] == "X")
                    {
                        XCount++;
                    }
                    if (OCount == 2 && XCount == 0)
                    {
                        for (int i = 1; i < 8; i += 3)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }
                if (!moveMade)
                {
                    OCount = 0;
                    XCount = 0;
                    if (board[2] == "O")
                    {
                        OCount++;
                    }
                    if (board[5] == "O")
                    {
                        OCount++;
                    }
                    if (board[8] == "O")
                    {
                        OCount++;
                    }
                    if (board[2] == "X" || board[5] == "X" || board[8] == "X")
                    {
                        XCount++;
                    }
                    if (OCount == 2 && XCount == 0)
                    {
                        for (int i = 2; i < 9; i += 3)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }
                if (!moveMade)
                {
                    OCount = 0;
                    XCount = 0;
                    if (board[0] == "O")
                    {
                        OCount++;
                    }
                    if (board[4] == "O")
                    {
                        OCount++;
                    }
                    if (board[8] == "O")
                    {
                        OCount++;
                    }
                    if (board[0] == "X" || board[4] == "X" || board[8] == "X")
                    {
                        XCount++;
                    }
                    if (OCount == 2 && XCount == 0)
                    {
                        for (int i = 0; i < 9; i += 4)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }
                if (!moveMade)
                {
                    OCount = 0;
                    XCount = 0;
                    if (board[2] == "O")
                    {
                        OCount++;
                    }
                    if (board[4] == "O")
                    {
                        OCount++;
                    }
                    if (board[6] == "O")
                    {
                        OCount++;
                    }
                    if (board[0] == "X" || board[4] == "X" || board[8] == "X")
                    {
                        XCount++;
                    }
                    if (OCount == 2 && XCount == 0)
                    {
                        for (int i = 2; i < 9; i += 4)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }


                if (!moveMade)
                {
                    OCount = 0;
                    XCount = 0;
                    if (board[0] == "X")
                    {
                        XCount++;
                    }
                    if (board[1] == "X")
                    {
                        XCount++;
                    }
                    if (board[2] == "X")
                    {
                        XCount++;
                    }
                    if (board[0] == "O" || board[1] == "O" || board[2] == "O")
                    {                        
                        OCount++;
                    }
                    if (XCount == 2 && OCount == 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }
                if (!moveMade)
                {
                    OCount = 0;
                    XCount = 0;
                    if (board[3] == "X")
                    {
                        XCount++;
                    }
                    if (board[4] == "X")
                    {
                        XCount++;
                    }
                    if (board[5] == "X")
                    {
                        XCount++;
                    }
                    if (board[3] == "O" || board[4] == "O" || board[5] == "O")
                    {
                        OCount++;
                    }
                    if (XCount == 2 && OCount == 0)
                    {
                        for (int i = 3; i < 6; i++)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }
                if (!moveMade)
                {
                    OCount = 0;
                    XCount = 0;
                    if (board[6] == "X")
                    {
                        XCount++;
                    }
                    if (board[7] == "X")
                    {
                        XCount++;
                    }
                    if (board[8] == "X")
                    {
                        XCount++;
                    }
                    if (board[6] == "O" || board[7] == "O" || board[8] == "O")
                    {
                        OCount++;
                    }
                    if (XCount == 2 && OCount == 0)
                    {
                        for (int i = 7; i < 9; i++)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }
                if (!moveMade)
                {
                    OCount = 0;
                    XCount = 0;
                    if (board[0] == "X")
                    {
                        XCount++;
                    }
                    if (board[3] == "X")
                    {
                        XCount++;
                    }
                    if (board[6] == "X")
                    {
                        XCount++;
                    }
                    if (board[0] == "O" || board[3] == "O" || board[6] == "O")
                    {
                        OCount++;
                    }
                    if (XCount == 2 && OCount == 0)
                    {
                        for (int i = 0; i < 7; i += 3)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }
                if (!moveMade)
                {
                    OCount = 0;
                    XCount = 0;
                    if (board[1] == "X")
                    {
                        XCount++;
                    }
                    if (board[4] == "X")
                    {
                        XCount++;
                    }
                    if (board[7] == "X")
                    {
                        XCount++;
                    }
                    if (board[1] == "O" || board[4] == "O" || board[7] == "O")
                    {
                        OCount++;
                    }
                    if (XCount == 2 && OCount == 0)
                    {
                        for (int i = 1; i < 8; i += 3)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }
                if (!moveMade)
                {
                    OCount = 0;
                    XCount = 0;
                    if (board[2] == "X")
                    {
                        XCount++;
                    }
                    if (board[5] == "X")
                    {
                        XCount++;
                    }
                    if (board[8] == "X")
                    {
                        XCount++;
                    }
                    if (board[2] == "O" || board[5] == "O" || board[8] == "O")
                    {
                        OCount++;
                    }
                    if (XCount == 2 && OCount == 0)
                    {
                        for (int i = 2; i < 9; i += 3)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }
                if (!moveMade)
                {
                    OCount = 0;
                    XCount = 0;
                    if (board[0] == "X")
                    {
                        XCount++;
                    }
                    if (board[4] == "X")
                    {
                        XCount++;
                    }
                    if (board[8] == "X")
                    {
                        XCount++;
                    }
                    if (board[0] == "O" || board[4] == "O" || board[8] == "O")
                    {
                        OCount++;
                    }
                    if (XCount == 2 && OCount == 0)
                    {
                        for (int i = 0; i < 9; i += 4)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }
                if (!moveMade)
                {
                    OCount = 0;
                    XCount = 0;
                    if (board[2] == "X")
                    {
                        XCount++;
                    }
                    if (board[4] == "X")
                    {
                        XCount++;
                    }
                    if (board[6] == "X")
                    {
                        XCount++;
                    }
                    if (board[2] == "O" || board[4] == "O" || board[6] == "O")
                    {
                        OCount++;
                    }
                    if (XCount == 2 && OCount == 0)
                    {
                        for (int i = 2; i < 7; i += 2)
                        {
                            if (board[i] == null)
                            {
                                MakeAMoveAI(i);
                                moveMade = true;
                            }
                        }
                    }
                }
                if (!moveMade)
                {
                    AIStandartMove();
                }                
            }
            else
            {
                AIStandartMove();
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string s = MakeAMovePlayer(0);
            if (s == "X")
            {
                pictureBox1.Image = Xpic;
            }
        }
        private void AIStandartMove()
        {
            List<int> placeOfNull = new List<int>();
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == null)
                {
                    placeOfNull.Add(i);
                }
            }
            Random rng = new Random();
            MakeAMoveAI(placeOfNull[rng.Next(0, placeOfNull.Count)]);
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            string s = MakeAMovePlayer(1);
            if (s == "X")
            {
                pictureBox2.Image = Xpic;
            }
        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            string s = MakeAMovePlayer(2);
            if (s == "X")
            {
                pictureBox3.Image = Xpic;
            }
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            string s = MakeAMovePlayer(3);
            if (s == "X")
            {
                pictureBox4.Image = Xpic;
            }
        }

        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            string s = MakeAMovePlayer(4);
            if (s == "X")
            {
                pictureBox5.Image = Xpic;
            }
        }

        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            string s = MakeAMovePlayer(5);
            if (s == "X")
            {
                pictureBox6.Image = Xpic;
            }
        }

        private void pictureBox7_MouseClick(object sender, MouseEventArgs e)
        {
            string s = MakeAMovePlayer(6);
            if (s == "X")
            {
                pictureBox7.Image = Xpic;
            }
        }

        private void pictureBox8_MouseClick(object sender, MouseEventArgs e)
        {
            string s = MakeAMovePlayer(7);
            if (s == "X")
            {
                pictureBox8.Image = Xpic;
            }
        }

        private void pictureBox9_MouseClick(object sender, MouseEventArgs e)
        {
            string s = MakeAMovePlayer(8);
            if (s == "X")
            {
                pictureBox9.Image = Xpic;
            }
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }
    }
}
