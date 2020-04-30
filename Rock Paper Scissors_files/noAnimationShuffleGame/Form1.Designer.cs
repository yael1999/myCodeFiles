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
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private Button[,] arrButtons = new Button[4, 4];
        Random myR = new Random();
       private void CreateDynamicButtonArray()
        {
            int i, j;
            int w = 50, h = 50;
            for (i = 0; i < 4; i++)
                for (j = 0; j < 4; j++)
                {
                    arrButtons[i, j] = new Button();
                    arrButtons[i, j].Width = w;
                    arrButtons[i, j].Height = h;
                    arrButtons[i, j].Left = 1 + j % 4 * w;
                    arrButtons[i, j].Top = 80 + i * h;
                    arrButtons[i, j].Font = new Font("Microsoft Sans Serif", 15, FontStyle.Regular);
                    arrButtons[i, j].TabIndex = i * 4 + j;
                    arrButtons[i, j].Name = ("button" + ((i * 4 + j)+1)).ToString();
                    arrButtons[i, j].Text= ((i * 4 + j)+1).ToString();
                     arrButtons[i, j].Click += new EventHandler(btn_Click);
                    this.Controls.Add(arrButtons[i, j]);
                    if(!(i==3 && j == 3)){
                arrButtons[i, j].BackColor = Color.FromArgb(myR.Next(255), myR.Next(255), myR.Next(255)); }
                  
                }
            arrButtons[3, 3].Visible = false;

        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 

       




        private void InitializeComponent()
        {
            this.newGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.newGameButton.Location = new System.Drawing.Point(12, 22);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(729, 42);
            this.newGameButton.TabIndex = 0;
            this.newGameButton.Text = "New Game";
            this.newGameButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.newGameButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }
    

        #endregion

        private Button newGameButton;
        
}
    }
