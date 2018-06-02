using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class StateOfGame
    {
        public int Day { set; get; }
        public int Money { set; get; }

        public StateOfGame()
        {
            Day = 1;
            Money = (int)Config.StartMoneyValue;
        }
    }
}
