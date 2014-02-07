using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    class HordeShaman : RaceHorde
    {
        //Attack & Health start values
        private const int InitialAttackLevel = 0;
        private const int InitialHealthLevel = 50;

        //Unit constructor
        public HordeShaman()
        {
            this.UnitType = HordeTypeUnits.Shaman;
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;
        }
    }
}
