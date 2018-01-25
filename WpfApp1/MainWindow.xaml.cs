using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        Gra gra1 = new Gra();
        Image[,] linkImage = new Image[4, 4];
        Build build;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void NextDayButton_Click(object sender, RoutedEventArgs e)
        {
            DayCounter.Text = "Day : "+gra1.NextDay().ToString();
            MoneyCounter.Text = "Money : "+gra1.CountMoney().ToString();
        }
        
        private void BuildNow_Click(object sender, RoutedEventArgs e)
        {
            int x, y;
            if (!int.TryParse(CoorX.Text, out x))
            {
                MessageBox.Show("Wprowadz poprawnie wspolrzedna X");
                return;
            }
            if (!int.TryParse(CoorY.Text, out y))
            {
                MessageBox.Show("Wprowadz poprawnie wspolrzedna Y");
                return;
            }         
            if (x < 0 || x > 4)
            {
                MessageBox.Show("Bledna wspolrzedna X");
                return;
            }
            if (y < 0 || y > 4)
            {
                MessageBox.Show("Bledna wspolrzedna Y");
                return;
            }

            linkImage[0, 0] = Img_0_0;
            linkImage[0, 1] = Img_0_1;
            linkImage[0, 2] = Img_0_2;
            linkImage[0, 3] = Img_0_3;
            linkImage[1, 0] = Img_1_0;
            linkImage[1, 1] = Img_1_1;
            linkImage[1, 2] = Img_1_2;
            linkImage[1, 3] = Img_1_3;
            linkImage[2, 0] = Img_2_0;
            linkImage[2, 1] = Img_2_1;
            linkImage[2, 2] = Img_2_2;
            linkImage[2, 3] = Img_2_3;
            linkImage[3, 0] = Img_3_0;
            linkImage[3, 1] = Img_3_1;
            linkImage[3, 2] = Img_3_2;
            linkImage[3, 3] = Img_3_3;

            switch (ComboBoks.Text.Substring(0, 1))
            {
                case "1":
                    //MessageBox.Show("Quarry");
                    build = Quarry.Instance;
                    break;
                case "2":
                    //MessageBox.Show("Woodcutter");
                    build = Woodcutter.Instance;
                    break;
                case "3":
                    //MessageBox.Show("Sawmill");
                    build = Sawmill.Instance;
                    break;
                case "4":
                    //MessageBox.Show("GoldMine");
                    build = GoldMine.Instance;
                    break;
                case "5":
                    //MessageBox.Show("Mint");
                    build = Mint.Instance;
                    break;
                default:
                    MessageBox.Show("Error");
                    break;

            }

           
            if(build.BuildNow(x, y, gra1, (Builds)2))
                linkImage[x, y].Source = new BitmapImage(build.ImageMy);
            MoneyCounter.Text="Money : "+gra1.GetMoney().ToString();
            CountQuarry.Text = Quarry.Instance.Count.ToString();
            CountWoodcutter.Text = Woodcutter.Instance.Count.ToString();
            CountSawmil.Text = Sawmill.Instance.Count.ToString();
            CountGoldMine.Text = GoldMine.Instance.Count.ToString();
            CountMint.Text = Mint.Instance.Count.ToString();
        }
    }
    enum Builds
    {
        Soil,
        Quarry,
        Woodcutter,
        Sawmill,
        GoldMine,
        Mint
    };
    

    class StateOfGame
    {
        public int Day { set; get; }
        public int Money { set; get; }
        
        public StateOfGame()
        {
            Day = 1;
            Money = 2000;
        }
    }
    class MapOfGame
    {
        public Builds[,] Field { set; get; }

        public MapOfGame()
        {
            Field = new Builds[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Field[i, j] = Builds.Soil;
        }
    }
    
    class Gra
    {
        private StateOfGame stan;
        private MapOfGame mapka;

        public bool IsEmptyField(int x, int y)
        {
            bool result = false;
            if (mapka.Field[x, y] == Builds.Soil)
                result = true;
            return result;

        }
        public void SetField(int x,int y,Builds name)
        {
            mapka.Field[x, y] = name;
        }
        public int CountMoney()
        {
            int result = stan.Money;
            result += Quarry.Instance.Income *       Quarry.Instance.Count;
            result += Woodcutter.Instance.Income *   Woodcutter.Instance.Count;
            result += Sawmill.Instance.Income *      Sawmill.Instance.Count;
            result += GoldMine.Instance.Income *     GoldMine.Instance.Count;
            result += Mint.Instance.Income *         Mint.Instance.Count;
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

        public Gra()
        {
            stan = new StateOfGame();
            mapka = new MapOfGame();
        }

        public int NextDay()
        {
            int currentDayInGame = stan.Day++;
            return currentDayInGame;
        }
    }
    abstract class Build
    {
        public string Name { get; set; }
        public int Income { get; set; }
        public int Cost { get; set; }
        public int Count { get; set; }
        public Uri ImageMy { get; set; }
        public int GetCost2()
        {
            return Cost;
        }

        public bool BuildNow(int x, int y, Gra gra,Builds name)
        {
            if (!gra.IsEmptyField(x, y))
            {
                MessageBox.Show("Tam juz jest jakis budynek ! ://");
                return false;
            }
            else
            {
                if (gra.GetMoney() < this.GetCost2())
                {
                    MessageBox.Show("Za mało pieniążków");
                    return false;
                }
                MessageBox.Show("Budynek zostanie postawiony, prezez sie zgodzil !");
                gra.SetField(x, y, name);
                gra.UseMoney(Cost);
                Count++;
                return true;
            }

        }
    }

    class Quarry : Build
    {
        private Quarry()
        {
            Name = "Kamieniolom";
            Income = 200;
            Cost = 500;
            Count = 0;
            ImageMy = new Uri(@"C:\Users\macfr\source\repos\WpfApp1\WpfApp1\quarry.png");
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
    class Woodcutter : Build
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
    class Sawmill : Build
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
    class GoldMine : Build
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
    class Mint : Build
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


