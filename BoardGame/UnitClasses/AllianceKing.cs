using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OOPGame_WoWChess;

namespace BoardGame.UnitClasses
{
    class AllianceKing : RaceAlliance, IMoveable
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

            //Check horizonal line if it's clear to move
            if (deltaRow == 0)
            {
                if (deltaCol > 0)
                {
                    for (int currentCol = this.ColPosition; currentCol <= destination.col; currentCol++)
                    {
                        foreach (var unit in InitializedTeams.allianceTeam)
                        {
                            if (unit.ColPosition == currentCol && unit.RowPosition == this.RowPosition)
                            {
                                return false;
                            }
                        }

                        foreach (var unit in InitializedTeams.hordeTeam)
                        {
                            if (unit.ColPosition == currentCol && unit.RowPosition == this.RowPosition)
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }

                if (deltaCol < 0)
                {
                    for (int currentCol = this.ColPosition; currentCol >= destination.col; currentCol--)
                    {
                        foreach (var unit in InitializedTeams.allianceTeam)
                        {
                            if (unit.ColPosition == currentCol && unit.RowPosition == this.RowPosition)
                            {
                                return false;
                            }
                        }

                        foreach (var unit in InitializedTeams.hordeTeam)
                        {
                            if (unit.ColPosition == currentCol && unit.RowPosition == this.RowPosition)
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }               
            }

            //Check vertical line if it's clear to move
            else if (deltaCol == 0)
            {
                if (deltaRow > 0)
                {
                    for (int currentRow = this.RowPosition; currentRow <= destination.row; currentRow++)
                    {
                        foreach (var unit in InitializedTeams.allianceTeam)
                        {
                            if (unit.RowPosition == currentRow && unit.ColPosition == this.ColPosition)
                            {
                                return false;
                            }
                        }

                        foreach (var unit in InitializedTeams.hordeTeam)
                        {
                            if (unit.RowPosition == currentRow && unit.ColPosition == this.ColPosition)
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }

                if (deltaCol < 0)
                {
                    for (int currentRow = this.RowPosition; currentRow >= destination.row; currentRow--)
                    {
                        foreach (var unit in InitializedTeams.allianceTeam)
                        {
                            if (unit.RowPosition == currentRow && unit.ColPosition == this.ColPosition)
                            {
                                return false;
                            }
                        }

                        foreach (var unit in InitializedTeams.hordeTeam)
                        {
                            if (unit.RowPosition == currentRow && unit.ColPosition == this.ColPosition)
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }

            }
            // Check diagonal line if it's clear to move
            else if ( Math.Abs(deltaRow) == Math.Abs(deltaCol))
            {
                int currentRow = this.RowPosition;
                int currentCol = this.ColPosition;

                for (int i = 0; i < Math.Abs(deltaRow); i++)
                {
                    if (deltaRow <0  && deltaCol <0)
                    {
                        foreach (var unit in InitializedTeams.allianceTeam)
                        {
                            if (currentRow == unit.RowPosition && currentCol == unit.ColPosition)
                            {
                                return false;
                            }
                        }

                        foreach (var unit in InitializedTeams.hordeTeam)
                        {
                            if (currentRow == unit.RowPosition && currentCol == unit.ColPosition)
                            {
                                return false;
                            }
                        }

                        currentCol--;
                        currentRow--;
                    }
                    else if (deltaRow < 0 && deltaCol > 0)
                    {
                        foreach (var unit in InitializedTeams.allianceTeam)
                        {
                            if (currentRow == unit.RowPosition && currentCol == unit.ColPosition)
                            {
                                return false;
                            }
                        }

                        foreach (var unit in InitializedTeams.hordeTeam)
                        {
                            if (currentRow == unit.RowPosition && currentCol == unit.ColPosition)
                            {
                                return false;
                            }
                        }

                        currentCol++;
                        currentRow--;
                    }
                    else if (deltaRow > 0 && deltaCol > 0)
                    {
                        foreach (var unit in InitializedTeams.allianceTeam)
                        {
                            if (currentRow == unit.RowPosition && currentCol == unit.ColPosition)
                            {
                                return false;
                            }
                        }

                        foreach (var unit in InitializedTeams.hordeTeam)
                        {
                            if (currentRow == unit.RowPosition && currentCol == unit.ColPosition)
                            {
                                return false;
                            }
                        }

                        currentCol++;
                        currentRow++;
                    }
                    else if (deltaRow > 0 && deltaCol < 0)
                    {
                        foreach (var unit in InitializedTeams.allianceTeam)
                        {
                            if (currentRow == unit.RowPosition && currentCol == unit.ColPosition)
                            {
                                return false;
                            }
                        }

                        foreach (var unit in InitializedTeams.hordeTeam)
                        {
                            if (currentRow == unit.RowPosition && currentCol == unit.ColPosition)
                            {
                                return false;
                            }
                        }

                        currentCol--;
                        currentRow++;
                    }                   
                    
                }

                return true;
            }

            return false;
        }
    }
}
