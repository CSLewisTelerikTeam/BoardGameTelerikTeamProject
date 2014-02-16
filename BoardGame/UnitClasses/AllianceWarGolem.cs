using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    class AllianceWarGolem : RaceAlliance, IMoveable
    {
        //Attack & Health start values
        private const double InitialAttackLevel = 30;
        private const double InitialHealthLevel = 80;

        //Unit constructor
        public AllianceWarGolem(int InitialRowPosition = 0, int InitialColPosition = 0)
        {
            this.UnitType = AllianceTypeUnits.WarGolem;
            
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;

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

            //Invalid move
            if (deltaCol != 0 && deltaRow != 0)
            {
                return false;
            }
            else if (deltaCol == 0)
            {
                int currentRow = this.RowPosition;
                int currentCol = this.ColPosition;

                for (int i = 0; i < Math.Abs(deltaRow); i++)
                {
                    foreach (var unit in InitializedTeams.allianceTeam)
                    {
                        if (unit.ColPosition == currentCol && unit.RowPosition == currentRow)
                        {
                            return false;
                        }
                    }

                    foreach (var unit in InitializedTeams.hordeTeam)
                    {
                        if (unit.ColPosition == currentCol && unit.RowPosition == currentRow)
                        {
                            return false;
                        }
                    }

                    if (deltaRow < 0)
                    {
                        currentRow--;
                    }
                    else
                    {
                        currentRow++;
                    }
                }

                return true;
            }
            else if (deltaRow == 0)
            {
                int currentRow = this.RowPosition;
                int currentCol = this.ColPosition;

                for (int i = 0; i < Math.Abs(deltaCol); i++)
                {
                    foreach (var unit in InitializedTeams.allianceTeam)
                    {
                        if (unit.ColPosition == currentCol && unit.RowPosition == currentRow)
                        {
                            return false;
                        }
                    }

                    foreach (var unit in InitializedTeams.hordeTeam)
                    {
                        if (unit.ColPosition == currentCol && unit.RowPosition == currentRow)
                        {
                            return false;
                        }
                    }

                    if (deltaCol < 0)
                    {
                        currentCol--;
                    }
                    else
                    {
                        currentCol++;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
