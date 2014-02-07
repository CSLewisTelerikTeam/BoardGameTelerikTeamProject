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
                            if (unit.Value.ColPosition == currentCol && unit.Value.RowPosition == this.RowPosition)
                            {
                                return false;
                            }
                        }

                        foreach (var unit in InitializedTeams.hordeTeam)
                        {
                            if (unit.Value.ColPosition == currentCol && unit.Value.RowPosition == this.RowPosition)
                            {
                                return false;
                            }
                        }
                    }
                }

                if (deltaCol < 0)
                {
                    for (int currentCol = this.ColPosition; currentCol >= destination.col; currentCol--)
                    {
                        foreach (var unit in InitializedTeams.allianceTeam)
                        {
                            if (unit.Value.ColPosition == currentCol && unit.Value.RowPosition == this.RowPosition)
                            {
                                return false;
                            }
                        }

                        foreach (var unit in InitializedTeams.hordeTeam)
                        {
                            if (unit.Value.ColPosition == currentCol && unit.Value.RowPosition == this.RowPosition)
                            {
                                return false;
                            }
                        }
                    }
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
                            if (unit.Value.RowPosition == currentRow && unit.Value.ColPosition == this.ColPosition)
                            {
                                return false;
                            }
                        }

                        foreach (var unit in InitializedTeams.hordeTeam)
                        {
                            if (unit.Value.RowPosition == currentRow && unit.Value.ColPosition == this.ColPosition)
                            {
                                return false;
                            }
                        }
                    }
                }

                if (deltaCol < 0)
                {
                    for (int currentRow = this.RowPosition; currentRow >= destination.row; currentRow--)
                    {
                        foreach (var unit in InitializedTeams.allianceTeam)
                        {
                            if (unit.Value.RowPosition == currentRow && unit.Value.ColPosition == this.ColPosition)
                            {
                                return false;
                            }
                        }

                        foreach (var unit in InitializedTeams.hordeTeam)
                        {
                            if (unit.Value.RowPosition == currentRow && unit.Value.ColPosition == this.ColPosition)
                            {
                                return false;
                            }
                        }
                    }
                }

            }
            // Check diagonal line if it's clear to move
            else if (deltaRow == deltaCol)
            {
                //TODO
                throw new NotImplementedException();
            }




            return false;
        }
    }
}
