using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.UnitClasses
{
    class InitializedTeams
    {
        //Alliance playing units. These instances will be used in the game.
        public static List<RaceAlliance> allianceTeam = new List<RaceAlliance>()
        {
            new AllianceSquire(),
            new AllianceSquire(),
            new AllianceSquire(),
            new AllianceSquire(),
            new AllianceSquire(),
            new AllianceSquire(),
            new AllianceSquire(),
            new AllianceSquire(),
            new AllianceMage(),
            new AllianceMage(),
            new AllianceCaptain(),
            new AllianceCaptain(),
            new AllianceWarGolem(),
            new AllianceWarGolem(),
            new AlliancePriest(),                     
            new AllianceKing(),           
        };

        //Horde playing units. These instances will be used in the game.
        public static List<RaceHorde> hordeTeam = new List<RaceHorde>()
        {
            new HordeGrunt(),
            new HordeGrunt(),
            new HordeGrunt(),
            new HordeGrunt(),
            new HordeGrunt(),
            new HordeGrunt(),
            new HordeGrunt(),
            new HordeGrunt(),
            new HordeWarlock(),
            new HordeWarlock(),         
            new HordeCommander(),
            new HordeCommander(),
            new HordeDemolisher(),
            new HordeDemolisher(),            
            new HordeShaman(),            
            new HordeWarchief(),
        };
    }
}
