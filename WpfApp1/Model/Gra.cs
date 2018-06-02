using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class Gra
    {
        private StateOfGame stan;
        private MapOfGame mapka;
        

        public int Day { get => stan.Day; }
        public int Money { get => stan.Money; }
        public string[] ImgPath {
            get {
                string[] ListOfImgPath = new string[(int) Config.BuildingsCount];
                mapka.SetField(0,0,Builds.Quarry);

                for (int i = 0; i < (int)Config.BuildingsCount; i++)
                {
                    if (mapka.Field[i / (int)Config.BuildingsCountColumn, i % (int)Config.BuildingsCountColumn]
                        == null)
                        ListOfImgPath[i] = @"";
                        //ListOfImgPath[i] = @"/Resources/soil.png";
                    else
                    ListOfImgPath[i] = 
                        mapka.Field[i/(int)Config.BuildingsCountColumn, i% (int)Config.BuildingsCountColumn]
                        .ImagePath;
                }
                return ListOfImgPath;
            }
        }

        public Gra()
        {
            stan = new StateOfGame();
            mapka = new MapOfGame();
        }

        public void NewDay()
        {
            stan.Day++;
            stan.Money = CountIncome();
        }
        public int CountIncome()
        {
            int result = stan.Money;
            result -= 100;
            result += Quarry.Instance.Income * Quarry.Instance.Count;
            result += Woodcutter.Instance.Income * Woodcutter.Instance.Count;
            result += Sawmill.Instance.Income * Sawmill.Instance.Count;
            result += GoldMine.Instance.Income * GoldMine.Instance.Count;
            result += Mint.Instance.Income * Mint.Instance.Count;
            return result;
        }


        
    }
}
