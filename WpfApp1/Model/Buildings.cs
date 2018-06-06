using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public abstract class Building
    {
        public string Name { get; protected set; }
        public int Income { get; protected set; }
        public int Cost { get; protected set; }
        public int Count { get; set; }
        public virtual string ImagePath { get; protected set; }
                                 = (@"\Resources\soil.png");
    }

    public class Quarry : Building
    {
        private Quarry()
        {
            Name = "Kamieniołom";
            Income = 200;
            Cost = 500;
            Count = 0;
            ImagePath = (@"\Resources\quarry.png");
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
    public class Woodcutter : Building
    {
        private Woodcutter()
        {
            Name = "Chatka Drwala";
            Income = 300;
            Cost = 1500;
            Count = 0;
            ImagePath = (@"\Resources\axe.png");
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
    public class Sawmill : Building
    {
        private Sawmill()
        {
            Name = "Tartak";
            Income = 500;
            Cost = 3000;
            Count = 0;
            ImagePath = (@"\Resources\hut.png");
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
    public class GoldMine : Building
    {
        private GoldMine()
        {
            Name = "Kopalnia zlota";
            Income = 1000;
            Cost = 5000;
            Count = 0;
            ImagePath = (@"\Resources\gold mine.png");
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
    public class Mint : Building
    {
        private Mint()
        {
            Name = "Mennica";
            Income = 3000;
            Cost = 10000;
            Count = 0;
            ImagePath = (@"\Resources\dollar.png");
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
