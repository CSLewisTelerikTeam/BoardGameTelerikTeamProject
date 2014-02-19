﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    class HordeCommander : RaceHorde, IMoveable
    {
        //Attack & Health start values
        private const double InitialAttackLevel = 3;
        private const double InitialHealthLevel = 8;

        //Unit constructor
        public HordeCommander(int InitialRowPosition, int InitialColPosition, HordeTypeUnits unitType)
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

            // Check diagonal line if it's clear to move
            if (Math.Abs(deltaRow) == Math.Abs(deltaCol))
            {
                int currentRow = this.RowPosition;
                int currentCol = this.ColPosition;

                for (int i = 0; i < Math.Abs(deltaRow); i++)
                {
                    if (deltaRow < 0 && deltaCol < 0)
                    {
                        currentCol--;
                        currentRow--;

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


                    }
                    else if (deltaRow < 0 && deltaCol > 0)
                    {
                        currentCol++;
                        currentRow--;
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


                    }
                    else if (deltaRow > 0 && deltaCol > 0)
                    {
                        currentCol++;
                        currentRow++;
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


                    }
                    else if (deltaRow > 0 && deltaCol < 0)
                    {
                        currentCol--;
                        currentRow++;
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


                    }

                }

                return true;
            }


            return false;
        }
    
    }
}
