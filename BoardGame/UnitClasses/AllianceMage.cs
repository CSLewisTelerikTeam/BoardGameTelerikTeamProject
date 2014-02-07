using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    class AllianceMage :RaceAlliance
    {
        //Attack & Health start values
        private const int InitialAttackLevel = 30;
        private const int InitialHealthLevel = 60;

        //Unit constructor
        public AllianceMage()
        {
            this.UnitType = AllianceTypeUnits.Mage;
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;
        }
    }
}
