﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    class HordeCommander : RaceHorde
    {
        //Attack & Health start values
        private const double InitialAttackLevel = 35;
        private const double InitialHealthLevel = 80;

        //Unit constructor
        public HordeCommander()
        {
            this.UnitType = HordeTypeUnits.Commander;
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;
        }
    
    }
}
