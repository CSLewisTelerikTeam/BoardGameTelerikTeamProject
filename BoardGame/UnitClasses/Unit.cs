using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    //Abstract class Unit, parent for both races and all units. 
    //Unit class can't make any instances

    abstract class Unit
    {
        private int healthLevel;
        private int attackLevel;

        public int HealthLevel { get; set; }
        public int AttackLevel { get; set; }
    }
}
