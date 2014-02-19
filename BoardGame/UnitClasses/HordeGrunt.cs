using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    class HordeGrunt : RaceHorde, IMoveable
    {
        //Attack & Health start values
        private const double InitialAttackLevel = 2;
        private const double InitialHealthLevel = 4;

        //Unit constructor
        public HordeGrunt(int InitialRowPosition, int InitialColPosition, HordeTypeUnits unitType)
        {
            this.UnitType = unitType;
            this.UnitRace = UnitRaceType.horde;
            
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;

            this.CounterAttackLevel = InitialAttackLevel / 2;

            this.RowPosition = InitialRowPosition;
            this.ColPosition = InitialColPosition;
        }

        public override bool IsMoveable(Position destination)
        {
            //Check if the destination cell is not busy of Alliance unit
            foreach (var unit in InitializedTeams.allianceTeam)
            {
                if (destination.col == unit.ColPosition && destination.row == unit.RowPosition)
                {
                    return false;
                }
            }

            int deltaRow = destination.row - this.RowPosition;
            int deltaCol = destination.col - this.ColPosition;

            //invalid move
            if (Math.Abs(deltaCol) > 1 || Math.Abs(deltaRow) > 1)
            {
                return false;
            }
            return true;
        }
    }
}
