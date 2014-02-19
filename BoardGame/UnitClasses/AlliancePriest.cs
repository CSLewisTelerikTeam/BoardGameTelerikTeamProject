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
        private const double InitialHealthLevel = 10;

        //Unit constructor
        public AlliancePriest(int InitialRowPosition, int InitialColPosition, AllianceTypeUnits unitType)
        {
            this.UnitType = unitType;
            this.UnitRace = UnitRaceType.alliance;

            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;

            this.CounterAttackLevel = InitialAttackLevel / 2;

            this.RowPosition = InitialRowPosition;
            this.ColPosition = InitialColPosition;
                        
        }
    }
}
