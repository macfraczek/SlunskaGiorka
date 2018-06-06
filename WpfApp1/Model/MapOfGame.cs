using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class MapOfGame
    {
        public Building[,] Field { set; get; }

        public MapOfGame()
        {
            Field = new Building[(int)Config.BuildingsCountRow, (int)Config.BuildingsCountColumn];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Field[i,j] = null;
        }

        public void SetField(int x, int y, Builds name)
        {
            switch (name)
            {
                case Builds.Soil:
                    Field[x, y] = null;
                    break;
                case Builds.Quarry:
                    Field[x, y] = Quarry.Instance;
                    Quarry.Instance.Count++;
                    break;
                case Builds.Woodcutter:
                    Field[x, y] = Woodcutter.Instance;
                    Woodcutter.Instance.Count++;
                    break;
                case Builds.Sawmill:
                    Field[x, y] = Sawmill.Instance;
                    Sawmill.Instance.Count++;
                    break;
                case Builds.GoldMine:
                    Field[x, y] = GoldMine.Instance;
                    GoldMine.Instance.Count++;
                    break;
                case Builds.Mint:
                    Field[x, y] = Mint.Instance;
                    Mint.Instance.Count++;
                    break;
                default:
                    System.Windows.MessageBox.Show("Sth goes wrong with building select :(\n", "ERROR",
                        System.Windows.MessageBoxButton.OK);
                    break;
            }
        }
        public bool IsEmptyField(int x, int y)
        {
            bool result = false;
            if (Field[x, y] == null)
                result = true;
            return result;
        }
        public bool BuildNow(int x, int y, Builds name)
        {
            bool _IsEmptyField = IsEmptyField(x, y);

            if (_IsEmptyField)
            {
                SetField(x, y, name);
                return true;
            }
            else
                return false;
        }
    }
}
