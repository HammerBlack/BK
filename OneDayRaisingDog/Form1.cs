using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneDayRaisingDog
{
    public partial class GameChanel : Form
    {
        
        Grayhound[] GreyhoundArray = new Grayhound[4];
        Guy[] men = new Guy[3]; 
        Random MyRandomizer = new Random();
        public GameChanel()
        {
            InitializeComponent();
            GreyhoundArray[0] = new Grayhound()
            {
                MyPictureBox = PictureDog1,
                StartingPosition = PictureDog1.Left,
                RacetrackLength = PictureRaceGround.Width - PictureDog1.Width,
                Randomizer = MyRandomizer
            };
            GreyhoundArray[1] = new Grayhound()
            {
                MyPictureBox = PictureDog2,
                StartingPosition = PictureDog2.Left,
                RacetrackLength = PictureRaceGround.Width - PictureDog2.Width,
                Randomizer = MyRandomizer
            };
            GreyhoundArray[2] = new Grayhound()
            {
                MyPictureBox = PictureDog3,
                StartingPosition = PictureDog3.Left,
                RacetrackLength = PictureRaceGround.Width - PictureDog3.Width,
                Randomizer = MyRandomizer
            };
            GreyhoundArray[3] = new Grayhound()
            {
                MyPictureBox = PictureDog4,
                StartingPosition = PictureDog4.Left,
                RacetrackLength = PictureRaceGround.Width - PictureDog4.Width,
                Randomizer = MyRandomizer
            };

            men[0] = new Guy()
            {
                Name = "Joe",
                Cash = 50,
                MyRadioButton = JoeRadioButton,
                MyLabel = JoeInformationLabel 
            };
            men[1] = new Guy()
            {
                Name = "Bob",
                Cash = 50,
                MyRadioButton = BobRadioButton,
                MyLabel = BobInformationLabel
            };
            men[2] = new Guy()
            {
                Name = "Ai",
                Cash = 50,
                MyRadioButton = AiRadioButton,
                MyLabel = AiInformationLabel
            };
            for(int i=0;i<men.Length;i++)
            {
                men[i].UpdateLabel();
            }
            ProcessingTimeLabel.Text = "Round Time: 0 seconds"; 

        }
        int seconds = 0;

        private void JoeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            NameLabel.Text = men[0].Name;
            if (JoeRadioButton.Checked)
                JoeInformationLabel.BackColor = Color.Yellow; 
            else
                JoeInformationLabel.BackColor = Color.White;
        }
        private void BobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            NameLabel.Text = men[1].Name;
            if (BobRadioButton.Checked)
                BobInformationLabel.BackColor = Color.Yellow;
            else
                BobInformationLabel.BackColor = Color.White;
        }

        private void AiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            NameLabel.Text = men[2].Name;
            if (AiRadioButton.Checked)
                AiInformationLabel.BackColor = Color.Yellow;
            else
                AiInformationLabel.BackColor = Color.White;
        }





        private void BetsButton_Click(object sender, EventArgs e)
        {
            if (NameLabel.Text != null)
            {
                string tempName = NameLabel.Text.ToString();
                for (int i=0;i<men.Length;i++)
                {
                    if (tempName==men[i].Name)
                    {
                        men[i].PlaceBet((int)MoneyUpDown.Value, (int)DogNumberUpDown.Value);
                        NameLabel.Text = "Bettor";
                        men[i].UpdateLabel(); 
                    }
                }
             }
        }

        private void RaceButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GreyhoundArray.Length; i++)
                GreyhoundArray[i].TakeStartingPosition();

            JoeInformationLabel.Enabled = false;
            JoeRadioButton.Enabled = false;
            BobInformationLabel.Enabled = false;
            BobRadioButton.Enabled = false;
            AiInformationLabel.Enabled = false;
            AiRadioButton.Enabled = false;
            BetsButton.Enabled = false;
            MoneyUpDown.Enabled = false;
            DogNumberUpDown.Enabled = false;
            timer1.Start();
            ProcessingTimeLabel.Text = "Round Time: 0 seconds";
            seconds = 0; 
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < GreyhoundArray.Length; i++)
            {
                if (GreyhoundArray[i].Run() == true)
                {
                    for (int j = 0; j < men.Length;j++)
                    {
                        men[j].Collect(i);
                    }
                    timer1.Stop();
                    timer2.Stop();
                    JoeInformationLabel.Enabled = true;
                    JoeRadioButton.Enabled = true;
                    BobInformationLabel.Enabled = true;
                    BobRadioButton.Enabled = true;
                    AiInformationLabel.Enabled = true;
                    AiRadioButton.Enabled = true;
                    BetsButton.Enabled = true;
                    MoneyUpDown.Enabled = true;
                    DogNumberUpDown.Enabled = true; 
                    MessageBox.Show("The winner house is!!!" +(i+1));
                    
                    
                    
                }
                

            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            seconds += 1;
            ProcessingTimeLabel.Text = "Round Time: "+ seconds+" seconds"; 
        }
    }
}
