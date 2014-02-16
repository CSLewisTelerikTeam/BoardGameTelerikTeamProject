using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    class HordeWarchief : RaceHorde
    {
        //Attack & Health start values
        private const double InitialAttackLevel = 40;
        private const double InitialHealthLevel = 100;

        //Unit constructor
        public HordeWarchief(int InitialRowPosition = 0, int InitialColPosition = 0)
        {
            this.UnitType = HordeTypeUnits.Warchief;
            
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;

            this.RowPosition = InitialRowPosition;
            this.ColPosition = InitialColPosition;
        }
        
    }
}
