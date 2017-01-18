using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDayRaisingDog
{
    class Bet
    {
        public int Amount;
        public int Dog;
 //       public string Bettor;

        public string GetDesciption()
        {
            if (this.Amount == 0)
            {
                return  " hasn't placed a bet";
            }
            else
                return " bets " + Amount + " on #" + Dog;
        }
        public int PayOut(int winner)
        {
            if (this.Dog == winner+1)
                return Amount;
            else
                return (-Amount); 
        }
    }
}
