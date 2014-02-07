using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    //Unit types for this race are delcared as enumeration.
    //All protected properties will bi used only in inheritor class.

    public enum HordeTypeUnits
    {
        Grunt, Warlock, Commander, Warlord, Demolisher, Shaman, Warchief
    }

    abstract class RaceHorde : Unit
    {        
        protected HordeTypeUnits UnitType { get; set; }
    }
}
