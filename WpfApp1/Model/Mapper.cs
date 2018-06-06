using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public static class Mapper
    {

        public static Builds BuildingStringToEnumMapper(String a)
        {
            switch (a)
            {
                case "Kamieniołom":
                    return Builds.Quarry;
                case "Chatka Drwala":
                    return Builds.Woodcutter;
                case "Tartak":
                    return Builds.Sawmill;
                case "Kopalnia złota":
                    return Builds.GoldMine;
                case "Mennica":
                    return Builds.Mint;
                default:
                    throw new BuildingStringToEnumMapperException();
            }
        }
        public static dynamic BuildingStringToBuildingMapper(String a)
        {
            switch (a)
            {
                case "Kamieniołom":
                    return Quarry.Instance;
                case "Chatka Drwala":
                    return Woodcutter.Instance;
                case "Tartak":
                    return Sawmill.Instance;
                case "Kopalnia złota":
                    return GoldMine.Instance;
                case "Mennica":
                    return Mint.Instance;
                default:
                    throw new BuildingStringToBuildingMapperException();
            }
        }
        public static dynamic BuildingEnumToBuildingMapper(Builds a)
        {
            switch (a)
            {
                case Builds.Soil:
                    throw new BuildingEnumToBuildingMapperException();
                    break;
                case Builds.Quarry:
                    return Quarry.Instance;
                case Builds.Woodcutter:
                    return Woodcutter.Instance;
                case Builds.Sawmill:
                    return Sawmill.Instance;
                case Builds.GoldMine:
                    return GoldMine.Instance;
                case Builds.Mint:
                    return Mint.Instance;
                default:
                    throw new BuildingEnumToBuildingMapperException();
            }
        }

    }
}
