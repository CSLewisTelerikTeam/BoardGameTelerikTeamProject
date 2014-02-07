using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPGame_WoWChess;

namespace BoardGame.UnitClasses
{
    class AllianceCaptain : RaceAlliance, IMoveable
    {        
        //Attack & Health start values
        private const int InitialAttackLevel = 35;
        private const int InitialHealthLevel = 70;

        //Unit constructor
        public AllianceCaptain()
        {
            this.UnitType = AllianceTypeUnits.Captain;
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;
        }

        public bool Move(Position destination)
        {
            //Check if the destination cell is not busy of Alliance unit
            foreach (var unit in InitializedTeams.allianceTeam)
            {
                if (destination.col == unit.Value.ColPosition && destination.row == unit.Value.RowPosition)
                {
                    return false;
                }
            }

            int deltaRow = (int)Math.Abs(destination.row - this.RowPosition);
            int deltaCol = (int)Math.Abs(destination.col - this.ColPosition);

            //Check if the destination cell is corresponding to the unit move rules
            if ( (deltaRow == 2 && deltaCol == 1) || (deltaRow == 1 && deltaCol == 2))
            {
                return true;
            }

            return false;
        }
    }

    
}
