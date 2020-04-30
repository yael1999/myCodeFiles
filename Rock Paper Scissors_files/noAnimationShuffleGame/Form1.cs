using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace try1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateDynamicButtonArray();
            
            shuffle();
           
        }
       

         
        public void emptySpotChecker(Button butt1, Button butt2)
        {
            if (butt2.Visible == false)
            {
                butt2.Text = butt1.Text;
                butt1.Text = "";
                butt2.BackColor = butt1.BackColor;
                butt1.Visible=false;
                butt2.Visible = true;
            }
        }
        public void winCheck()
        {
            if (arrButtons[0,0].Text == "1" && arrButtons[0,1].Text == "2" && arrButtons[0, 2].Text == "3" &&
                arrButtons[0, 3].Text == "4" && arrButtons[1, 0].Text == "5" &&
                arrButtons[1, 1].Text == "6" && arrButtons[1,2].Text == "7" && arrButtons[1, 3].Text == "8" &&
                arrButtons[2, 0].Text == "9" && arrButtons[2, 1].Text == "10" &&
               arrButtons[2, 2].Text == "11" && arrButtons[2, 3].Text == "12" && arrButtons[3, 0].Text == "13" &&
               arrButtons[3, 1].Text == "14" &&
                   arrButtons[3, 2].Text == "15" && arrButtons[3, 3].Text == "")
            {
                //massage that l won            
                DialogResult gameOver = MessageBox.Show("You won!New Game?", "Game Over!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (gameOver == DialogResult.Yes) 
                    shuffle();
                if (gameOver == DialogResult.No)
                    Application.Exit();
            }
            if (arrButtons[0,0].Text == "1" && arrButtons[0,1].Text == "2" && arrButtons[0, 2].Text == "3" &&
                arrButtons[0, 3].Text == "4" && arrButtons[1, 0].Text == "5" &&
                arrButtons[1, 1].Text == "6" && arrButtons[1,2].Text == "7" && arrButtons[1, 3].Text == "8" &&
                arrButtons[2, 0].Text == "9" && arrButtons[2, 1].Text == "10" &&
               arrButtons[2, 2].Text == "11" && arrButtons[2, 3].Text == "12" && arrButtons[3, 0].Text == "13" &&
               arrButtons[3, 1].Text == "15" &&
                   arrButtons[3, 2].Text == "14" && arrButtons[3, 3].Text == "16")
            {
                DialogResult gameOver = MessageBox.Show("You lost!New Game?", "Game Over!",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (gameOver == DialogResult.Yes)
                    shuffle();
                if (gameOver == DialogResult.No)
                    Application.Exit();
            }
        }
        private void NewGame_Click(object sender, EventArgs e)
        {
            shuffle();
            this.Refresh();
            this.Hide();
            Form1 newGame = new Form1();
            newGame.Show();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            switch (b.Name)
            {
                case "button1":
                    emptySpotChecker(b,arrButtons[0, 1]);
                    emptySpotChecker(b,arrButtons[1, 0]);
                    winCheck();
                    break;
                case "button2":
                   emptySpotChecker(b, arrButtons[0,0]);
                    emptySpotChecker(b, arrButtons[0, 2]);
                    emptySpotChecker(b, arrButtons[1,1]);
                    winCheck();
                    break;
                case "button3":
                    emptySpotChecker(b, arrButtons[0, 1]);
                    emptySpotChecker(b, arrButtons[0, 3]);
                    emptySpotChecker(b, arrButtons[1, 2]);
                    winCheck();
                    break;
                case "button4":
                    emptySpotChecker(b, arrButtons[1, 3]);
                    emptySpotChecker(b, arrButtons[0, 2]);
                    winCheck();
                    break;
                case "button5":
                    emptySpotChecker(b, arrButtons[0, 0]);
                    emptySpotChecker(b, arrButtons[2,0 ]);
                    emptySpotChecker(b, arrButtons[1, 1]);
                    winCheck();
                    break;
                case "button6":
                    emptySpotChecker(b, arrButtons[0, 1]);
                    emptySpotChecker(b, arrButtons[1,2 ]);
                    emptySpotChecker(b, arrButtons[1, 0]);
                    emptySpotChecker(b, arrButtons[2, 1]);
                    winCheck();
                    break;
                case "button7":
                    emptySpotChecker(b, arrButtons[1, 3]);
                    emptySpotChecker(b, arrButtons[0, 2]);
                    emptySpotChecker(b, arrButtons[1, 1]);
                    emptySpotChecker(b, arrButtons[2, 2]);
                    winCheck();
                    break;
                case "button8":
                    emptySpotChecker(b, arrButtons[2, 3]);
                    emptySpotChecker(b, arrButtons[0, 3]);
                    emptySpotChecker(b, arrButtons[1, 2]);
                    winCheck();
                    break;
                case "button9":
                    emptySpotChecker(b, arrButtons[1, 0]);
                    emptySpotChecker(b, arrButtons[2, 1]);
                    emptySpotChecker(b, arrButtons[3, 0]);
                    winCheck();
                    break;
                case "button10":
                    emptySpotChecker(b, arrButtons[1, 1]); 
                    emptySpotChecker(b, arrButtons[2, 0]);
                    emptySpotChecker(b, arrButtons[2, 2]);
                    emptySpotChecker(b, arrButtons[3, 1]);
                    winCheck();
                    break;
                case "button11":
                    emptySpotChecker(b, arrButtons[3, 2]);
                    emptySpotChecker(b, arrButtons[2, 3]);
                    emptySpotChecker(b, arrButtons[2, 1]);
                    emptySpotChecker(b, arrButtons[1, 2]);
                    winCheck();
                    break;
                case "button12":
                    emptySpotChecker(b, arrButtons[3, 3]);
                    emptySpotChecker(b, arrButtons[2, 2]);
                    emptySpotChecker(b, arrButtons[1, 3]);
                    winCheck();
                    break;
                case "button13":
                    emptySpotChecker(b, arrButtons[2, 0]);
                    emptySpotChecker(b, arrButtons[3, 1]);
                    winCheck();
                    break;
                case "button14":
                    emptySpotChecker(b, arrButtons[3, 0]);
                    emptySpotChecker(b, arrButtons[3, 2]);
                    emptySpotChecker(b, arrButtons[2, 1]);
                    winCheck();
                    break;
                case "button15":
                    emptySpotChecker(b, arrButtons[3, 3]);
                    emptySpotChecker(b, arrButtons[2, 2]);
                    emptySpotChecker(b, arrButtons[3, 1]);
                    winCheck();
                    break;
                case "button16":
                    emptySpotChecker(b, arrButtons[2, 3]);
                    emptySpotChecker(b, arrButtons[3, 2]);
                    winCheck();
                    break;
                default:
                    break;
            }
        }
        
    





        public void shuffle()
        {
            int[] bnum = new int[16];
            int i, j, rowChecker;
            Boolean flag = false;
            i = 1;
            do
            {
                Random rnd = new Random();
                rowChecker = Convert.ToInt32(rnd.Next(0, 15) + 1);
                for (j = 1; j <= i; j++)
                {
                    if (bnum[j] == rowChecker)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag == true)
                {
                    flag = false;
                }
                else
                {
                    bnum[i] = rowChecker;
                    i++;
                }
            }
            while (i <= 15);
            foreach (Button b in Controls)
            {
                if (b.Name == "button1")
                    b.Text = Convert.ToString(bnum[1]);
                if (b.Name == "button2")
                    b.Text = Convert.ToString(bnum[2]);
                if (b.Name == "button3")
                    b.Text = Convert.ToString(bnum[3]);
                if (b.Name == "button4")
                    b.Text = Convert.ToString(bnum[4]);
                if (b.Name == "button5")
                    b.Text = Convert.ToString(bnum[5]);
                if (b.Name == "button6")
                    b.Text = Convert.ToString(bnum[6]);
                if (b.Name == "button7")
                    b.Text = Convert.ToString(bnum[7]);
                if (b.Name == "button8")
                    b.Text = Convert.ToString(bnum[8]);
                if (b.Name == "button9")
                    b.Text = Convert.ToString(bnum[9]);
                if (b.Name == "button10")
                    b.Text = Convert.ToString(bnum[10]);
                if (b.Name == "button11")
                    b.Text = Convert.ToString(bnum[11]);
                if (b.Name == "button12")
                    b.Text = Convert.ToString(bnum[12]);
                if (b.Name == "button13")
                    b.Text = Convert.ToString(bnum[13]);
                if (b.Name == "button14")
                    b.Text = Convert.ToString(bnum[14]);
                if (b.Name == "button15")
                    b.Text = Convert.ToString(bnum[15]);
                if (b.Name == "button16")
                    b.Text = "";
            }
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
           // shuffle();
            this.Refresh();
            this.Hide();
            Form1 newGame = new Form1();
            newGame.Show();

        }
    }
}
