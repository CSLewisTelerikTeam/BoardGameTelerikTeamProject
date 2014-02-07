using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    class AllianceSquire : RaceAlliance
    {
        //Attack & Health start values
        private const int InitialAttackLevel = 20;
        private const int InitialHealthLevel = 50;

        //Unit constructor
        public AllianceSquire()
        {
            this.UnitType = AllianceTypeUnits.Squire;
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;
        }
    }
}
