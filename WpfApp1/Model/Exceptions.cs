﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class SomeBuildingIsAlreadyThereException : Exception { }
    class NotEnoughtMoneyException : Exception { }
    class BuildingStringToEnumMapperException : Exception { };
    class BuildingStringToBuildingMapperException : Exception { };
    class BuildingEnumToBuildingMapperException : Exception { };
}
