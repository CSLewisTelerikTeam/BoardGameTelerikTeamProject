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
            new AllianceSquire(6,0, AllianceTypeUnits.Squire01),        //0
            new AllianceSquire(6,1, AllianceTypeUnits.Squire02),        //1
            new AllianceSquire(6,2, AllianceTypeUnits.Squire03),        //2
            new AllianceSquire(6,3, AllianceTypeUnits.Squire04),        //3
            new AllianceSquire(6,4, AllianceTypeUnits.Squire05),        //4
            new AllianceSquire(6,5, AllianceTypeUnits.Squire06),        //5
            new AllianceSquire(6,6, AllianceTypeUnits.Squire07),        //6
            new AllianceSquire(6,7, AllianceTypeUnits.Squire08),        //7
            new AllianceMage(7,1, AllianceTypeUnits.Mage01),            //8
            new AllianceMage(7,6, AllianceTypeUnits.Mage02),            //9
            new AllianceCaptain(7,2, AllianceTypeUnits.Captain01),      //10
            new AllianceCaptain(7,5, AllianceTypeUnits.Captain02),      //11
            new AllianceWarGolem(7,0, AllianceTypeUnits.WarGolem01),    //12
            new AllianceWarGolem(7,7, AllianceTypeUnits.WarGolem02),    //13
            new AlliancePriest(7,3, AllianceTypeUnits.Priest),          //14            
            new AllianceKing(7,4, AllianceTypeUnits.King),              //15
        };

        //Horde playing units. These instances will be used in the game.
        public static List<RaceHorde> hordeTeam = new List<RaceHorde>()
        {
            new HordeGrunt(1,0, HordeTypeUnits.Grunt01),                //0
            new HordeGrunt(1,1, HordeTypeUnits.Grunt02),                //1
            new HordeGrunt(1,2, HordeTypeUnits.Grunt03),                //2
            new HordeGrunt(1,3, HordeTypeUnits.Grunt04),                //3
            new HordeGrunt(1,4, HordeTypeUnits.Grunt05),                //4
            new HordeGrunt(1,5, HordeTypeUnits.Grunt06),                //5
            new HordeGrunt(1,6, HordeTypeUnits.Grunt07),                //6
            new HordeGrunt(1,7, HordeTypeUnits.Grunt08),                //7
            new HordeWarlock(0,1, HordeTypeUnits.Warlock01),            //8
            new HordeWarlock(0,6, HordeTypeUnits.Warlock02),            //9
            new HordeCommander(0,2, HordeTypeUnits.Commander01),        //10
            new HordeCommander(0,5, HordeTypeUnits.Commander02),        //11
            new HordeDemolisher(0,0, HordeTypeUnits.Demolisher01),      //12
            new HordeDemolisher(0,7, HordeTypeUnits.Demolisher02),      //13     
            new HordeShaman(0,3, HordeTypeUnits.Shaman),                //14 
            new HordeWarchief(0,4, HordeTypeUnits.Warchief),            //15
        };
    }
}
