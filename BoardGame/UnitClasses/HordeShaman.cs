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
        private const double InitialHealthLevel = 10;

        //Unit constructor
        public HordeShaman(int InitialRowPosition, int InitialColPosition, HordeTypeUnits unitType)
        {
            this.UnitType = HordeTypeUnits.Shaman;
            this.UnitRace = UnitRaceType.horde;
            
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;

            this.CounterAttackLevel = InitialAttackLevel / 2;

            this.RowPosition = InitialRowPosition;
            this.ColPosition = InitialColPosition;
        }
    }
}
