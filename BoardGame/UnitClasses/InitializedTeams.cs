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
        public static Dictionary<string, RaceAlliance> allianceTeam = new Dictionary<string, RaceAlliance>()
        {
            {"allianceCaptain1", new AllianceCaptain()},
            {"allianceCaptain2", new AllianceCaptain()},
            {"allianceKing1", new AllianceKing()},
            {"allianceKing2", new AllianceKing()},
            {"allianceMage1", new AllianceMage()},
            {"allianceMage2", new AllianceMage()},
            {"alliancePriest1", new AlliancePriest()},
            {"alliancePriest2", new AlliancePriest()},
            {"allianceSergeant1", new AllianceSergeant()},
            {"allianceSergeant2", new AllianceSergeant()},
            {"allianceSqiure1", new AllianceSquire()},
            {"allianceSqiure2", new AllianceSquire()},
            {"allianceWarGolem1", new AllianceWarGolem()},
            {"allianceWarGolem2", new AllianceWarGolem()}
        };

        //Horde playing units. These instances will be used in the game.
        public static Dictionary<string, RaceHorde> hordeTeam = new Dictionary<string, RaceHorde>()
        {
            {"hordeCommander1", new HordeCommander()},
            {"hordeCommander2", new HordeCommander()},
            {"hordeDemolisher1", new HordeDemolisher()},
            {"hordeDemolisher2", new HordeDemolisher()},
            {"hordeGrunt1", new HordeGrunt()},
            {"hordeGrunt2", new HordeGrunt()},
            {"hordeShaman1", new HordeShaman()},
            {"hordeShaman2", new HordeShaman()},
            {"hordeWarchief1", new HordeWarchief()},
            {"hordeWarchief2", new HordeWarchief()},
            {"hordeWarlock1", new HordeWarlock()},
            {"hordeWarlock2", new HordeWarlock()},
            {"hordeWarlord1", new HordeWarlord()},
            {"hordeWarlord2", new HordeWarlord()},

        };
    }
}
