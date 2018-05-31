using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
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
}
