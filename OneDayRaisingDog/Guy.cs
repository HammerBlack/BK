using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
namespace OneDayRaisingDog
{
    class Guy
    {
        public string Name;
        public Bet MyBet =new Bet() ;
        public int Cash; 

        public RadioButton MyRadioButton ;
        public Label MyLabel;

        public void UpdateLabel()
        {
            MyLabel.Text =this.Name+MyBet.GetDesciption(); 
            MyRadioButton.Text = this.Name + " has " + this.Cash + " bucks"; 
        } 
        public void ClearBet()
        {
            this.MyBet.Amount = 0; 
        }
        public bool PlaceBet(int betamount, int dogtowin)
        {
            if(betamount<=Cash)
            {
                MyBet.Amount = betamount;
                MyBet.Dog = dogtowin;
                return true; 
            }
            else
            {
                return false; 
            }
        }
        public void Collect(int winner)
        {
            this.Cash += MyBet.PayOut(winner);
            this.ClearBet();
            this.UpdateLabel(); 
        }
    }
}
