﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    class AllianceMage :RaceAlliance, IMoveable
    {
        //Attack & Health start values
        private const double InitialAttackLevel = 3;
        private const double InitialHealthLevel = 7;

        //Unit constructor
        public AllianceMage(int InitialRowPosition, int InitialColPosition, AllianceTypeUnits unitType)
        {
            this.UnitType = unitType;
            this.UnitRace = UnitRaceType.alliance;

            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;

            this.RowPosition = InitialRowPosition;
            this.ColPosition = InitialColPosition;

            this.CounterAttackLevel = InitialAttackLevel / 2;
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

            int deltaRow = (int)Math.Abs(destination.row - this.RowPosition);
            int deltaCol = (int)Math.Abs(destination.col - this.ColPosition);

            //Check if the destination cell is corresponding to the unit move rules
            if ((deltaRow == 2 && deltaCol == 1) || (deltaRow == 1 && deltaCol == 2))
            {
                return true;
            }

            return false;
        }
    }
}
