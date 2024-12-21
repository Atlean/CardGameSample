using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CardGameSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox card1 = new PictureBox();
        PictureBox card2 = new PictureBox();
        string[] cardlist = Directory.GetFiles(@""); //The cards are available in the GitHub repository. After downloading the path to your computer, please write it here.
        string[] cardlist1 = new string[26];
        string[] cardlist2 = new string[26];

        int number = 0;
        int score = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            string cardName1 = Path.GetFileName(cardlist1[number]); // Path.GetFileName: Extracts only the file name from the file path.
            string cardName2 = Path.GetFileName(cardlist2[number]);

            if (cardName1[0] == cardName2[0])
            {
                score++;
                label2.Text = score.ToString();
            }

            if (number < 26)
            {
                card1.ImageLocation = cardlist1[number];
                card1.Location = new System.Drawing.Point(350, 20);
                card1.Size = new System.Drawing.Size(100, 100);
                card1.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(card1);

                card2.ImageLocation = cardlist2[number];
                card2.Location = new System.Drawing.Point(350, 320);
                card2.Size = new System.Drawing.Size(100, 100);
                card2.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(card2);

                number++;
            }

            if (number == 26)
            {
                MessageBox.Show("Game Over");
                number = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cardlist = shuffle(cardlist);
            dividecards(cardlist);
        }

        private void dividecards(string[] cardlist)
        {
            for (int i = 0; i < 26; i++)
            {
                cardlist1[i] = cardlist[i];
            }
            for (int i = 26; i < cardlist.Length; i++)
            {
                cardlist2[i - 26] = cardlist[i];
            }
        }

        private string[] shuffle(string[] cardlist)
        {
            Random rnd = new Random();
            return cardlist.OrderBy(x => rnd.Next()).ToArray();
        }
    }
}