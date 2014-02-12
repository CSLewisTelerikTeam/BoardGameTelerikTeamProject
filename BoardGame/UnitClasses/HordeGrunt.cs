﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    class HordeGrunt : RaceHorde
    {
        //Attack & Health start values
        private const double InitialAttackLevel = 20;
        private const double InitialHealthLevel = 50;

        //Unit constructor
        public HordeGrunt()
        {
            this.UnitType = HordeTypeUnits.Grunt;
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;
        }
    }
}
