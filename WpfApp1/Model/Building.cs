using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    abstract class Building
    {
        public string Name { get; protected set; }
        public int Income { get; protected set; }
        public int Cost { get; protected set; }
        public int Count { get; protected set; }
        public Uri ImageMy { get; protected set; }


        public bool BuildNow(int x, int y, Gra gra, Builds name)
        {
            if (!gra.IsEmptyField(x, y))
            {
                //MessageBox.Show("Tam juz jest jakis budynek ! ://");
                return false;
            }
            else
            {
                if (gra.GetMoney() < this.Cost)
                {
                    //MessageBox.Show("Za mało pieniążków");
                    return false;
                }
                //MessageBox.Show("Budynek zostanie postawiony, prezez sie zgodzil !");
                gra.SetField(x, y, name);
                gra.UseMoney(Cost);
                Count++;
                return true;
            }

        }
        
    }

    class Quarry : Building
    {
        private Quarry()
        {
            Name = "Kamieniołom";
            Income = 200;
            Cost = 500;
            Count = 0;
            ImageMy = new Uri(@"\Resources\quarry.png");
        }

        private static Quarry instance;
        public static Quarry Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Quarry();
                }
                return instance;
            }
        }

    }
    class Woodcutter : Building
    {
        private Woodcutter()
        {
            Name = "Chatka Drwala";
            Income = 300;
            Cost = 1500;
            Count = 0;
            ImageMy = new Uri(@"C:\Users\macfr\source\repos\WpfApp1\WpfApp1\Forrest.png");
        }

        private static Woodcutter instance;
        public static Woodcutter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Woodcutter();
                }
                return instance;
            }
        }
    }
    class Sawmill : Building
    {
        private Sawmill()
        {
            Name = "Tartak";
            Income = 500;
            Cost = 3000;
            Count = 0;
            ImageMy = new Uri(@"C:\Users\macfr\source\repos\WpfApp1\WpfApp1\sawmil.png");
        }

        private static Sawmill instance;
        public static Sawmill Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Sawmill();
                }
                return instance;
            }
        }
    }
    class GoldMine : Building
    {
        private GoldMine()
        {
            Name = "Kopalnia zlota";
            Income = 1000;
            Cost = 5000;
            Count = 0;
            ImageMy = new Uri(@"C:\Users\macfr\source\repos\WpfApp1\WpfApp1\gold-mine.png");
        }
        private static GoldMine instance;
        public static GoldMine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GoldMine();
                }
                return instance;
            }
        }
    }
    class Mint : Building
    {
        private Mint()
        {
            Name = "Mennica";
            Income = 3000;
            Cost = 10000;
            Count = 0;
            ImageMy = new Uri(@"C:\Users\macfr\source\repos\WpfApp1\WpfApp1\GoldenAnvil.png");
        }

        private static Mint instance;
        public static Mint Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Mint();
                }
                return instance;
            }
        }
    }

}
