using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    class AllianceKing : RaceAlliance
    {
        //Attack & Health start values
        private const int InitialAttackLevel = 40;
        private const int InitialHealthLevel = 100;

        //Unit constructor
        public AllianceKing()
        {
            this.UnitType = AllianceTypeUnits.King;
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;
        }
    }
}
