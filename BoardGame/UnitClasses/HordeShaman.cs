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
        private const double InitialAttackLevel = 0;
        private const double InitialHealthLevel = 50;

        //Unit constructor
        public HordeShaman(int InitialRowPosition = 0, int InitialColPosition = 0)
        {
            this.UnitType = HordeTypeUnits.Shaman;
            
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;

            this.RowPosition = InitialRowPosition;
            this.ColPosition = InitialColPosition;
        }
    }
}
