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
        Squire, Mage, Sergeant, Captain, WarGolem, Priest, King
    }

    abstract class RaceAlliance : Unit, IMoveable
    {
        protected AllianceTypeUnits UnitType { get; set; }

        public virtual bool IsMoveable(Position destination)
        {
            throw new NotImplementedException();
        }
    }
}
