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
                    break;
                case Builds.Woodcutter:
                    Field[x, y] = Woodcutter.Instance;
                    break;
                case Builds.Sawmill:
                    Field[x, y] = Sawmill.Instance;
                    break;
                case Builds.GoldMine:
                    Field[x, y] = GoldMine.Instance;
                    break;
                case Builds.Mint:
                    Field[x, y] = Mint.Instance;
                    break;
                default:
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
            if (!IsEmptyField(x, y))
            {
                //System.Windows.MessageBox.Show("Tam juz jest jakis budynek ! ://");
                throw new SomeBuildingIsAlreadyThereException();
                return false;
            }
            else
            {
                if (0==1 )
                {
                    //MessageBox.Show("Za mało pieniążków");
                    return false;
                }
                //MessageBox.Show("Budynek zostanie postawiony, prezez sie zgodzil !");
                //gra.SetField(x, y, name);
                //gra.UseMoney(Cost);
                //Count++;
                return true;
            }

        }
    }
}
