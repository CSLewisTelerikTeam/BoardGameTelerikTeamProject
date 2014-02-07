using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace BoardGame.UnitClasses
{
    //Abstract class Unit, parent for both races and all units. 
    //Unit class can't make any instances

    abstract class Unit
    {
        //Private Fields 
        private int healthLevel;
        private int attackLevel;
        private Point unitPosition;              
        
        //Properties over private fields, in case need of data validation
        public int HealthLevel
        {
            get {return this.healthLevel;}
            set {this.healthLevel = value; }
        }
        
        public int AttackLevel
        {
            get { return this.attackLevel; }
            set { this.attackLevel = value; }
        }

        public Point UnitPosition
        {
            get { return this.unitPosition; }
            set { this.unitPosition = value; }
        }
        
    }
}
