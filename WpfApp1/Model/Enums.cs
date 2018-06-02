using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    enum Builds
    {
        Soil,
        Quarry,
        Woodcutter,
        Sawmill,
        GoldMine,
        Mint
    };

    enum Config
    {
        BuildingsCount = 16,
        BuildingsCountRow = 4,
        BuildingsCountColumn = 4,
        StartMoneyValue=2000
    }
}
