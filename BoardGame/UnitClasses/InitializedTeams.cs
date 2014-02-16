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
            new AllianceSquire(6,0),
            new AllianceSquire(6,1),
            new AllianceSquire(6,2),
            new AllianceSquire(6,3),
            new AllianceSquire(6,4),
            new AllianceSquire(6,5),
            new AllianceSquire(6,6),
            new AllianceSquire(6,7),
            new AllianceMage(7,1),
            new AllianceMage(7,6),
            new AllianceCaptain(7,2),
            new AllianceCaptain(7,5),
            new AllianceWarGolem(7,0),
            new AllianceWarGolem(7,7),
            new AlliancePriest(7,3),                     
            new AllianceKing(7,4),           
        };

        //Horde playing units. These instances will be used in the game.
        public static List<RaceHorde> hordeTeam = new List<RaceHorde>()
        {
            new HordeGrunt(1,0),
            new HordeGrunt(1,1),
            new HordeGrunt(1,2),
            new HordeGrunt(1,3),
            new HordeGrunt(1,4),
            new HordeGrunt(1,5),
            new HordeGrunt(1,6),
            new HordeGrunt(1,7),
            new HordeWarlock(0,1),
            new HordeWarlock(0,6),         
            new HordeCommander(0,2),
            new HordeCommander(0,5),
            new HordeDemolisher(0,0),
            new HordeDemolisher(0,7),            
            new HordeShaman(0,3),            
            new HordeWarchief(0,4),
        };
    }
}
