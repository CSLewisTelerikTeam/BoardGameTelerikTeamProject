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
        void Move();
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
