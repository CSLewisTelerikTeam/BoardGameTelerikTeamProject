using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    //Interfaces describe the behavior of the units
    
    interface IMoveable
    {
        //Return true if trip to the destination position is possible
        bool IsMoveable(Position destination);
    }

    interface IAttacking
    {
        void Attack(Unit objectToAttack);
    }

    interface IHealing
    {
        void Heal(Unit objectToHeal);
    }
}
