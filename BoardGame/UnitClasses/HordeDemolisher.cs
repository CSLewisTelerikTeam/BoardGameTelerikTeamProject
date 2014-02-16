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
        private const double InitialAttackLevel = 30;
        private const double InitialHealthLevel = 80;

        //Unit constructor
        public HordeDemolisher(int InitialRowPosition = 0, int InitialColPosition = 0)
        {
            this.UnitType = HordeTypeUnits.Demolisher;
            
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;

            this.RowPosition = InitialRowPosition;
            this.ColPosition = InitialColPosition;
        }
    }
}
