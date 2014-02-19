using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    //Unit types for this race are delcared as enumeration.
    //All protected properties will bi used only in inheritor class.

    public enum AllianceTypeUnits
    {
        Squire01, Squire02, Squire03, Squire04, Squire05, Squire06, Squire07, Squire08,
        Mage01, Mage02, Captain01, Captain02, WarGolem01, WarGolem02, Priest, King
    }

    abstract class RaceAlliance : Unit, IMoveable
    {
        public AllianceTypeUnits UnitType { get; set; }

        public virtual bool IsMoveable(Position destination)
        {   
            throw new NotImplementedException();
        }

        // // InflictDamage takes two parameters: attacked unit (of race opposite to that of the attacker) and damage source (attack, counterattack, spells...)
        public void InflictDamage(RaceHorde attackedUnit, double damageSource)
        {
            attackedUnit.HealthLevel -= damageSource;
        }
    }
}
