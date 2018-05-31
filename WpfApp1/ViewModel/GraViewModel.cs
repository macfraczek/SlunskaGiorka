﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    using WpfApp1.Model;

    class GraViewModel
    {
        Gra _gra = new Gra();

        public String DayInGame { get { return String.Format("Dzień: {0}", _gra.Day); } }
        public String MoneyInGame { get { return String.Format("Monety: {0}", _gra.Money); } }

        /*Image[,] linkImage = new Image[4, 4];
        Building _building;


        private void NextDayButton_Click(object sender, RoutedEventArgs e)
        {
            DayCounter.Text = "Day : " + gra1.NextDay().ToString();
            MoneyCounter.Text = "Money : " + gra1.CountMoney().ToString();
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
                    _building = Quarry.Instance;
                    break;
                case "2":
                    //MessageBox.Show("Woodcutter");
                    _building = Woodcutter.Instance;
                    break;
                case "3":
                    //MessageBox.Show("Sawmill");
                    _building = Sawmill.Instance;
                    break;
                case "4":
                    //MessageBox.Show("GoldMine");
                    _building = GoldMine.Instance;
                    break;
                case "5":
                    //MessageBox.Show("Mint");
                    _building = Mint.Instance;
                    break;
                default:
                    MessageBox.Show("Error");
                    break;

            }


            if (_building.BuildNow(x, y, gra1, (Builds)2))
                linkImage[x, y].Source = new BitmapImage(_building.ImageMy);
            MoneyCounter.Text = "Money : " + gra1.GetMoney().ToString();
            CountQuarry.Text = Quarry.Instance.Count.ToString();
            CountWoodcutter.Text = Woodcutter.Instance.Count.ToString();
            CountSawmil.Text = Sawmill.Instance.Count.ToString();
            CountGoldMine.Text = GoldMine.Instance.Count.ToString();
            CountMint.Text = Mint.Instance.Count.ToString();
        }*/
    }
}
