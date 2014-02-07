using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace BoardGame.UnitClasses
{
    //Abstract class Unit, parent for both races and all units. 
    //Unit class can't make any instances

    public struct Position
    {
        public int row;
        public int col;

        public Position(int rowPos, int colPos)
            : this()
        {
            this.row = rowPos;
            this.col = colPos;
        }
    }

    abstract class Unit
    {
        //Private Fields 
        private int healthLevel;
        private int attackLevel;        
        private Position unitPosition;
        
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

        public int RowPosition
        {
            get { return this.unitPosition.row; }
            set { this.unitPosition.row = value; }
        }

        public int ColPosition
        {
            get { return this.unitPosition.col; }
            set { this.unitPosition.col = value; }
        }

        public bool IsSelected { get; set; }
    }
}
