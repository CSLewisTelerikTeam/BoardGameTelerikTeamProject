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

        public bool IsMoveable(Position destination)
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

            // Check diagonal line if it's clear to move
            if ( Math.Abs(deltaRow) == Math.Abs(deltaCol))
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
