using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Gra
    {
        protected StateOfGame stan;
        private MapOfGame mapka;
        

        public int Day { get => stan.Day; }
        public int Money { get => stan.Money; }

        public Gra()
        {
            stan = new StateOfGame();
            mapka = new MapOfGame();
        }

        public bool IsEmptyField(int x, int y)
        {
            bool result = false;
            if (mapka.Field[x, y] == Builds.Soil)
                result = true;
            return result;

        }
        public void SetField(int x, int y, Builds name)
        {
            mapka.Field[x, y] = name;
        }
        public int CountMoney()
        {
            int result = stan.Money;
            result += Quarry.Instance.Income * Quarry.Instance.Count;
            result += Woodcutter.Instance.Income * Woodcutter.Instance.Count;
            result += Sawmill.Instance.Income * Sawmill.Instance.Count;
            result += GoldMine.Instance.Income * GoldMine.Instance.Count;
            result += Mint.Instance.Income * Mint.Instance.Count;
            stan.Money = result;
            return result;
        }
        public int GetMoney()
        {
            return stan.Money;
        }
        public int UseMoney(int diff)
        {
            int result = stan.Money;
            result -= diff;
            return stan.Money = result;
        }


        public int NextDay()
        {
            int currentDayInGame = stan.Day++;
            return currentDayInGame;
        }
    }
}
