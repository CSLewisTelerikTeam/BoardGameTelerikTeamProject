using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    class AlliancePriest : RaceAlliance
    {
        //Attack & Health start values
        private const double InitialAttackLevel = 0;
        private const double InitialHealthLevel = 50;

        //Unit constructor
        public AlliancePriest(int InitialRowPosition = 0, int InitialColPosition = 0)
        {
            this.UnitType = AllianceTypeUnits.Priest;

            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;

            this.RowPosition = InitialRowPosition;
            this.ColPosition = InitialColPosition;
        }
    }
}
