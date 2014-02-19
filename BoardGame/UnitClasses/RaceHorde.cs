using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    //Unit types for this race are delcared as enumeration.
    //All protected properties will bi used only in inheritor class.

    public enum HordeTypeUnits
    {
        Grunt01, Grunt02, Grunt03, Grunt04, Grunt05, Grunt06, Grunt07, Grunt08,
        Warlock01, Warlock02, Commander01, Commander02, Demolisher01, Demolisher02, Shaman, Warchief
    }

    abstract class RaceHorde : Unit, IMoveable
    {        
        public HordeTypeUnits UnitType { get; set; }

        public virtual bool IsMoveable(Position destination)
        {
            throw new NotImplementedException();
        }

        // InflictDamage takes two parameters: attacked unit (of race opposite to that of the attacker) and damage source (attack, counterattack, spells...) 
        public void InflictDamage(RaceAlliance attackedUnit, double damageSource)
        {
            attackedUnit.HealthLevel -= damageSource;
        }
    }
}
