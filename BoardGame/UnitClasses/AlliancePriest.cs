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
        private const int InitialAttackLevel = 0;
        private const int InitialHealthLevel = 50;

        //Unit constructor
        public AlliancePriest()
        {
            this.UnitType = AllianceTypeUnits.Priest;
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;
        }
    }
}
