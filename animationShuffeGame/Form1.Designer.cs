
using System.Runtime.InteropServices;
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
        private Button[] arrButtons = new Button[15];
        Random myR = new Random();
        private int[] fif = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        private void CreateDynamicArray()
        {
            int w = 50;
            int h = 50;
            int number = 1, xp = -1, yp = -1;

            for (int i = 0; i < 15; i++)
            {
                xp++;
                if (i % 4 == 0)
                {
                    xp = 0;
                    yp++;
                }
                arrButtons[i] = new Button();

                arrButtons[i].Name = "button" + number.ToString();
                arrButtons[i].Width = w;
                arrButtons[i].Height = h;
                arrButtons[i].Left = 1 + xp % 4 * w;
                arrButtons[i].Top = 50+ yp * h;
                arrButtons[i].Font = new Font("Microsoft Sans Serif", 15, FontStyle.Regular);
                arrButtons[i].TabIndex = i * 4;
                this.Controls.Add(arrButtons[i]);
                arrButtons[i].Click += new EventHandler(btn_Click);
                arrButtons[i].Text = Convert.ToString(fif[i]);
                arrButtons[i].BackColor = Color.FromArgb(myR.Next(0, 256), myR.Next(0, 256), myR.Next(0, 256));
                number++;
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.newGameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(30, 24);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(740, 36);
            this.newGameButton.TabIndex = 0;
            this.newGameButton.Text = "New Game";
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

        private System.Windows.Forms.Timer timer1;
        private Button newGameButton;
    }
}

