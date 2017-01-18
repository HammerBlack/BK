using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
namespace OneDayRaisingDog
{
    class Grayhound
    {
        public int StartingPosition ;
        public int RacetrackLength;
        public PictureBox MyPictureBox =null;
        public int Location=0;
        public Random Randomizer;

        public bool Run()
        {
            this.Location += Randomizer.Next(1,7);
            MyPictureBox.Left = this.StartingPosition + this.Location;
                
            if (MyPictureBox.Left >= this.RacetrackLength)
            {
                return true;
            }
            else
                return false;  
        }

        public void TakeStartingPosition()
        {
            this.MyPictureBox.Left = this.StartingPosition;
            this.Location = 0; 
        }
    }
}
