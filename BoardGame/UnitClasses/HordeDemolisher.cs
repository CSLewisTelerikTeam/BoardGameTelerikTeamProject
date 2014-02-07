using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    class HordeDemolisher : RaceHorde
    {
        //Attack & Health start values
        private const int InitialAttackLevel = 30;
        private const int InitialHealthLevel = 80;

        //Unit constructor
        public HordeDemolisher()
        {
            this.UnitType = HordeTypeUnits.Demolisher;
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;
        }
    }
}
