using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace BoardGame.UnitClasses
{
    class AllianceCaptain : RaceAlliance, IMoveable
    {        
        //Attack & Health start values
        private const int InitialAttackLevel = 35;
        private const int InitialHealthLevel = 70;
        
        //Unit's images field
        private Image smallImage;
        private Image bigImage;

        //Unit's images property
        public Image SmallImage
        {
            get 
            {
                return this.smallImage;
            }
            set
            {
                this.smallImage = value;
            }
        }
        public Image BigImage
        {
            get
            {
                return this.bigImage;
            }
            set 
            {
                this.bigImage = value;
            }
        }

        //Unit constructor
        public AllianceCaptain()
        {
            this.UnitType = AllianceTypeUnits.Captain;
            this.AttackLevel = InitialAttackLevel;
            this.HealthLevel = InitialHealthLevel;
            this.SmallImage = new Image();
            this.BigImage = new Image();

            var path = System.IO.Path.GetFullPath(@"..\..\Resources\Alliance\Frames\captain_small.png");
            this.SmallImage.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
            path = System.IO.Path.GetFullPath(@"..\..\Resources\Alliance\Frames\captain_big.png");
            this.BigImage.Source = new BitmapImage(new Uri(path, UriKind.Absolute));
        }

        public bool Move(Position destination)
        {
            //Check if the destination cell is not busy of Alliance unit
            foreach (var unit in InitializedTeams.allianceTeam)
            {
                //Commented with the reason below

                //Error	1	'BoardGame.UnitClasses.RaceAlliance' does not contain a definition for 'Value' and no extension method 'Value' accepting a first argument of type 'BoardGame.UnitClasses.RaceAlliance' could be found (are you missing a using directive or an assembly reference?)	C:\Users\vesel_000\Documents\GitHub\BoardGameTelerikTeamProject\BoardGame\UnitClasses\AllianceCaptain.cs	57	45	BoardGame

                //if (destination.col == unit.Value.ColPosition && destination.row == unit.Value.RowPosition)
                //{
                //    return false;
                //}
            }

            int deltaRow = (int)Math.Abs(destination.row - this.RowPosition);
            int deltaCol = (int)Math.Abs(destination.col - this.ColPosition);

            //Check if the destination cell is corresponding to the unit move rules
            if ( (deltaRow == 2 && deltaCol == 1) || (deltaRow == 1 && deltaCol == 2))
            {
                return true;
            }

            return false;
        }
    }

    
}
