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
        
        // IMG PATH DO POPRAWKI


        public int Day { get => stan.Day; }
        public int Money { get => stan.Money; private set => stan.Money=value; }
        public string[] ImgPath {
            get {
                string[] ListOfImgPath = new string[(int) Config.BuildingsCount];
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
        public bool IsEmptyField(int x,int y)
        {
            return mapka.IsEmptyField(x,y);
        }
        public void SetField(int x, int y, Builds name)
        {
            mapka.SetField(x, y, name);
        }
        public void PayForBuild(int prize)
        {
            if (prize > 0)
            {
                stan.PayForBuilding(prize);
                System.Windows.MessageBox.Show("good", "");
            }
            //else
                //for(; ; )
                    //System.Windows.MessageBox.Show("CHEATER","");
        }
        public void BuildNow(int x, int y, Builds name)
        {
            if (Money > (Mapper.BuildingEnumToBuildingMapper(name)).Cost)
                if(mapka.BuildNow(x, y, name))
                    PayForBuild(Mapper.BuildingEnumToBuildingMapper(name).Cost);
        }





    }
}
