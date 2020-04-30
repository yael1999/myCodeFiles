using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateDynamicArray();
            shuffle();
        }
        //int xEmpty = 151;
        //int yEmpty = 151;
        // int empty = 16;
        int counter = 0;
        string movement = "";
          bool is_press = false; 
        // int xPushed, yPushed;
        Button b;
        //  Button empty= arrButtons[16];
        private void btn_Click(object sender, EventArgs e)
        {
            winCheck();
              if (!is_press)
              {
                    b = sender as Button;
                    RightEmptyButton();
                    LeftEmptyButton();
                    DownEmptyButton();
                    UpEmptyButton();
                    

              }
        }
        public void winCheck()
        {
            if (arrButtons[0].Text == "1" && arrButtons[1].Text == "2" && arrButtons[2].Text == "3" &&
                arrButtons[3].Text == "4" && arrButtons[4].Text == "5" &&
                arrButtons[5].Text == "6" && arrButtons[6].Text == "7" && arrButtons[7].Text == "8" &&
                arrButtons[8].Text == "9" && arrButtons[9].Text == "10" &&
               arrButtons[10].Text == "11" && arrButtons[11].Text == "12" && arrButtons[12].Text == "13" &&
               arrButtons[13].Text == "14" &&
                   arrButtons[14].Text == "15")
            {
                //massage that l won            
                DialogResult gameOver = MessageBox.Show("You won!New Game?", "Game Over!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (gameOver == DialogResult.Yes)
                    shuffle();
                if (gameOver == DialogResult.No)
                    Application.Exit();
            }
            if (arrButtons[0].Text == "1" && arrButtons[1].Text == "2" && arrButtons[2].Text == "3" &&
                 arrButtons[3].Text == "4" && arrButtons[4].Text == "5" &&
                 arrButtons[5].Text == "6" && arrButtons[6].Text == "7" && arrButtons[7].Text == "8" &&
                 arrButtons[8].Text == "9" && arrButtons[9].Text == "10" &&
                arrButtons[10].Text == "11" && arrButtons[11].Text == "12" && arrButtons[12].Text == "13" &&
                arrButtons[13].Text == "15" &&
                    arrButtons[14].Text == "14")
            {
                DialogResult gameOver = MessageBox.Show("You lost!New Game?", "Game Over!",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (gameOver == DialogResult.Yes)
                    shuffle();
                if (gameOver == DialogResult.No)
                    Application.Exit();
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

        public void DownEmptyButton()
        {
            if (b.Location.Y == 200)
                return;
            bool flag = true;

            for (int i = 0; i < arrButtons.Length; i++)
            {
                if (b.Location.X == arrButtons[i].Location.X &&
                   b.Location.Y == arrButtons[i].Location.Y)
                    continue;
                if (b.Location.Y + 50 == arrButtons[i].Location.Y &&
                    b.Location.X == arrButtons[i].Location.X)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                timer1.Start();
                movement = "down";
                is_press = true;
            }
        }
        public void UpEmptyButton()
        {
            if ((b.Location.X == 151 || b.Location.X==101 || b.Location.X==51 || b.Location.X==1)&& b.Location.Y==50)
                return;
            bool flag = true;

            for (int i = 0; i < arrButtons.Length; i++)
            {
                if (b.Location.X == arrButtons[i].Location.X &&
                   b.Location.Y == arrButtons[i].Location.Y)
                    continue;
                if (b.Location.Y - 50 == arrButtons[i].Location.Y &&
                    b.Location.X == arrButtons[i].Location.X)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                timer1.Start();
                movement = "up";
                is_press = true;
            }
        }
        public void RightEmptyButton()
        {
            if (b.Location.X == 151)
            return;
            bool flag = true;

            for (int i = 0; i < arrButtons.Length; i++)
            {
                if (b.Location.X == arrButtons[i].Location.X &&
                   b.Location.Y == arrButtons[i].Location.Y)
                    continue;
                if (b.Location.X + 50 == arrButtons[i].Location.X &&
                    b.Location.Y == arrButtons[i].Location.Y)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                timer1.Start();
                movement = "right";
                is_press = true;
            }
        }
        public void LeftEmptyButton()
        {
            if (b.Location.X == 1)
                return;
            bool flag = true;

            for (int i = 0; i < arrButtons.Length; i++)
            {
                if (b.Location.X == arrButtons[i].Location.X &&
                   b.Location.Y == arrButtons[i].Location.Y)
                    continue;
                if (b.Location.X - 50 == arrButtons[i].Location.X &&
                    b.Location.Y == arrButtons[i].Location.Y)
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                timer1.Start();
                movement = "left";
                is_press = true;
            }
        }




        

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (movement)
            {
                case "right":
                    b.Location = new Point(b.Location.X + 2, b.Location.Y);
                    counter++;
                    if (counter == 25)
                    {
                        counter = 0;
                        timer1.Stop();
                        is_press = false;
                    }
                    break;
                case "left":
                    b.Location = new Point(b.Location.X - 2, b.Location.Y);
                    counter++;
                    if (counter == 25)
                    {
                        counter = 0;
                        timer1.Stop();
                        is_press = false;
                    }
                    break;
                case "up":
                    b.Location = new Point(b.Location.X, b.Location.Y - 2);
                    counter++;
                    if (counter == 25)
                    {
                        counter = 0;
                        timer1.Stop();
                        is_press = false;
                    }
                    break;
                 case "down":
                    b.Location = new Point( b.Location.X, b.Location.Y + 2);
                    counter++;
                    if (counter == 25)
                    {
                        counter = 0;
                        timer1.Stop();
                        is_press = false;
                    }
                    break;
                default:break;
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

        /* private void newGameButton_Click(object sender, EventArgs e)
         {
             // shuffle();
             this.Refresh();
             this.Hide();
             Form1 newGame = new Form1();
             newGame.Show();

         }*/
        //right


        /* private void timer1_Tick(object sender, EventArgs e)
         {


                 if (xPushed - xEmpty == 1) { 
                     //move left 
                 }
             //move right
              if (xPushed - xEmpty == -1)
             {
                     b.Location = new Point(b.Location.X + 2, b.Location.Y);
                     counter++;
                     if (counter ==25)
                     {
                         counter = 0;
                         timer1.Stop();
                     }
                 }
                 if (yPushed - yEmpty == 1)
                 {
                     //move up 
                 }
                 if (yPushed - yEmpty == -1)
                 { //move down
                 }  

         }*/
    }
}
