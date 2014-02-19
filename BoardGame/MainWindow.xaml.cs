using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BoardGame.UnitClasses;
using System.Threading;
using System.IO;
using System.Reflection;

namespace OOPGame_WoWChess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadBackgroundImage();
            //LoadBackgroundMusic();            
        }
        private const int TeamsCount = 16;

        private static bool HordeTurn = true;
        
        private MediaPlayer backgroundMusic = new MediaPlayer();        

        private void LoadBackgroundImage()
        {
            ImageBrush myBrush = new ImageBrush();
            var path = System.IO.Path.GetFullPath(@"..\..\Resources\Other_graphics\background_image.png");
            myBrush.ImageSource = new BitmapImage(new Uri(path, UriKind.Absolute));
            this.Background = myBrush;
        }

        private void LoadBackgroundMusic()
        {
            var path = System.IO.Path.GetFullPath(@"..\..\Resources\Background_music\background_music.mp3");
            backgroundMusic.Open(new Uri(path));
            backgroundMusic.Play();
        }

        private string CheckForSelectedItem()
        {
            string unit = "";

            for (int i = 0; i < InitializedTeams.allianceTeam.Count; i++)
            {
                if (InitializedTeams.allianceTeam[i].IsSelected)
                {
                    unit = InitializedTeams.allianceTeam[i].UnitType.ToString();                    
                    return unit;
                    
                }
                else if (InitializedTeams.hordeTeam[i].IsSelected)
                {
                    unit = InitializedTeams.hordeTeam[i].UnitType.ToString();                    
                    return unit;
                }
            }
            

            return unit;
        }

        private Unit CheckForSelectedEnemy()
        {
            for (int i = 0; i < TeamsCount; i++)
            {
                if (InitializedTeams.allianceTeam[i].IsSelected == true)
                {
                    return InitializedTeams.allianceTeam[i];
                }
                if (InitializedTeams.hordeTeam[i].IsSelected == true)
                {
                    return InitializedTeams.hordeTeam[i];
                }
            }
            return null;
        }

        private void MarkCurrentCell(int row, int col)
        {
            for (int i = 0; i < Playfield.Children.Count; i++)
            {
                if (Playfield.Children[i] is Border)
                {                    
                    if (row == (int)Playfield.Children[i].GetValue(Grid.RowProperty) && col == (int)Playfield.Children[i].GetValue(Grid.ColumnProperty))
                    {
                        (Playfield.Children[i] as Border).BorderBrush = Brushes.White;
                    }
                    
                }
            }
        }

        private void UnmarkCurrentCell()
        {
            for (int i = 0; i < Playfield.Children.Count; i++)
            {
                if (Playfield.Children[i] is Border)
                {
                    (Playfield.Children[i] as Border).BorderBrush = Brushes.Transparent;     
                }
            }
        }

        private void DeselectAll()
        {
            for (int i = 0; i < InitializedTeams.allianceTeam.Count; i++)
            {
                InitializedTeams.allianceTeam[i].IsSelected = false;
                InitializedTeams.hordeTeam[i].IsSelected = false;
            }

            
        }

        private void Move(string unit, int destRow, int destCol)
        {
            if (unit == "")
            {
                return;
            }
            Position destination = new Position(destRow, destCol);
            string race = "";
            int index = -1;

            if (IsMoveable(unit, destination, out index, out race))
            {
                if (race == "horde")
                {
                    InitializedTeams.hordeTeam[index].RowPosition = destination.row;
                    InitializedTeams.hordeTeam[index].ColPosition = destination.col;
                }
                else if (race == "alliance")
                {
                    InitializedTeams.allianceTeam[index].RowPosition = destination.row;
                    InitializedTeams.allianceTeam[index].ColPosition = destination.col;
                }
            }
            else
            {
                return;                
            }

            //Moving unit picture
            for (int i = 0; i < Playfield.Children.Count; i++)
            {
                if (unit == (string)Playfield.Children[i].GetValue(Image.NameProperty))
                {                    
                    Playfield.Children[i].SetValue(Grid.RowProperty, destRow);
                    Playfield.Children[i].SetValue(Grid.ColumnProperty, destCol);
                }
            }
            HordeTurn = !HordeTurn;
            UnmarkCurrentCell();
            DeselectAll();
        }

        private bool IsMoveable(string unit, Position destination, out int i, out string strRace)
        {
            strRace = "";
            for (i = 0; i < InitializedTeams.allianceTeam.Count; i++)
            {
                
                if (unit == InitializedTeams.hordeTeam[i].UnitType.ToString())
                {
                    strRace = "horde";
                    if (HordeTurn == false)
                    {
                        UnmarkCurrentCell();
                        DeselectAll();
                        return false;
                    }
                    switch (unit)
                    {
                        case "Grunt01":
                            if (!(InitializedTeams.hordeTeam[i] as HordeGrunt).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Grunt02":
                            if (!(InitializedTeams.hordeTeam[i] as HordeGrunt).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Grunt03":
                            if (!(InitializedTeams.hordeTeam[i] as HordeGrunt).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Grunt04":
                            if (!(InitializedTeams.hordeTeam[i] as HordeGrunt).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Grunt05":
                            if (!(InitializedTeams.hordeTeam[i] as HordeGrunt).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Grunt06":
                            if (!(InitializedTeams.hordeTeam[i] as HordeGrunt).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Grunt07":
                            if (!(InitializedTeams.hordeTeam[i] as HordeGrunt).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Grunt08":
                            if (!(InitializedTeams.hordeTeam[i] as HordeGrunt).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Warlock01":
                            if (!(InitializedTeams.hordeTeam[i] as HordeWarlock).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Warlock02":
                            if (!(InitializedTeams.hordeTeam[i] as HordeWarlock).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Commander01":
                            if (!(InitializedTeams.hordeTeam[i] as HordeCommander).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Commander02":
                            if (!(InitializedTeams.hordeTeam[i] as HordeCommander).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Demolisher01":
                            if (!(InitializedTeams.hordeTeam[i] as HordeDemolisher).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Demolisher02":
                            if (!(InitializedTeams.hordeTeam[i] as HordeDemolisher).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Warchief":
                            if (!(InitializedTeams.hordeTeam[i] as HordeWarchief).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Shaman":
                            MessageBox.Show("Shaman");
                            return false;
                    }
                    //InitializedTeams.hordeTeam[i].RowPosition = destination.row;
                    //InitializedTeams.hordeTeam[i].ColPosition = destination.col;
                    break;
                }
                else if (unit == InitializedTeams.allianceTeam[i].UnitType.ToString())
                {
                    strRace = "alliance";
                    if (HordeTurn == true)
                    {
                        UnmarkCurrentCell();
                        DeselectAll();
                        return false;
                    }
                    switch (unit)
                    {
                        case "Squire01":
                            if (!(InitializedTeams.allianceTeam[i] as AllianceSquire).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }
                            break;
                        case "Squire02":
                            if (!(InitializedTeams.allianceTeam[i] as AllianceSquire).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }

                            break;
                        case "Squire03":
                            if (!(InitializedTeams.allianceTeam[i] as AllianceSquire).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }

                            break;
                        case "Squire04":
                            if (!(InitializedTeams.allianceTeam[i] as AllianceSquire).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }

                            break;
                        case "Squire05":
                            if (!(InitializedTeams.allianceTeam[i] as AllianceSquire).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }

                            break;
                        case "Squire06":
                            if (!(InitializedTeams.allianceTeam[i] as AllianceSquire).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }

                            break;
                        case "Squire07":
                            if (!(InitializedTeams.allianceTeam[i] as AllianceSquire).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }

                            break;
                        case "Squire08":
                            if (!(InitializedTeams.allianceTeam[i] as AllianceSquire).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }

                            break;
                        case "Mage01":
                            if (!(InitializedTeams.allianceTeam[i] as AllianceMage).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }

                            break;
                        case "Mage02":
                            if (!(InitializedTeams.allianceTeam[i] as AllianceMage).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }

                            break;
                        case "Captain01":
                            if (!(InitializedTeams.allianceTeam[i] as AllianceCaptain).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }

                            break;
                        case "Captain02":
                            if (!(InitializedTeams.allianceTeam[i] as AllianceCaptain).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }

                            break;
                        case "WarGolem01":
                            if (!(InitializedTeams.allianceTeam[i] as AllianceWarGolem).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }

                            break;
                        case "WarGolem02":
                            if (!(InitializedTeams.allianceTeam[i] as AllianceWarGolem).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }

                            break;
                        case "King":
                            if (!(InitializedTeams.allianceTeam[i] as AllianceKing).IsMoveable(destination))
                            {
                                UnmarkCurrentCell();
                                DeselectAll();
                                return false;
                            }

                            break;
                        case "Priest":
                            MessageBox.Show("Priest");
                            return false;
                    }

                    //InitializedTeams.allianceTeam[i].RowPosition = destination.row;
                    //InitializedTeams.allianceTeam[i].ColPosition = destination.col;
                    break;
                }
            }
            
            return true;
        }

        private void Attack(Unit aggressor, Unit target)
        {
            string race;
            int unitIndex;
            Position targetPosition = new Position(target.RowPosition, target.ColPosition);

            if (aggressor.UnitRace != target.UnitRace)
            {
                if (aggressor.UnitRace == UnitRaceType.alliance)
                {
                    //Check if the aggresssor could reach the target
                    if (IsMoveable((aggressor as RaceAlliance).UnitType.ToString(), targetPosition, out unitIndex, out race))
                    {
                        target.HealthLevel -= aggressor.AttackLevel;
                        aggressor.HealthLevel -= target.CounterAttackLevel;
                    }                    
                }
                else if (aggressor.UnitRace == UnitRaceType.horde)
                {
                    //Check if the aggresssor could reach the target
                    if (IsMoveable((aggressor as RaceHorde).UnitType.ToString(), targetPosition, out unitIndex, out race))
                    {
                        target.HealthLevel -= aggressor.AttackLevel;
                        aggressor.HealthLevel -= target.CounterAttackLevel;
                    }
                }
            }
            
        }

        //Unit select event
        private void Unit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();            

            for (int i = 0; i < TeamsCount; i++)
            {
                if (InitializedTeams.allianceTeam[i].UnitType.ToString() == (sender as Image).Name)
                {
                    InitializedTeams.allianceTeam[i].IsSelected = true;
                    UnmarkCurrentCell();
                    MarkCurrentCell((int)(sender as Image).GetValue(Grid.RowProperty), (int)(sender as Image).GetValue(Grid.ColumnProperty));
                    break;
                }
                if (InitializedTeams.hordeTeam[i].UnitType.ToString() == (sender as Image).Name)
                {
                    InitializedTeams.hordeTeam[i].IsSelected = true;
                    UnmarkCurrentCell();
                    MarkCurrentCell((int)(sender as Image).GetValue(Grid.RowProperty), (int)(sender as Image).GetValue(Grid.ColumnProperty));
                    break;
                }

            }
        }

        //FieldsEvent
        private void FieldMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            string unit = CheckForSelectedItem();
            Move(unit, (int)(sender as Border).GetValue(Grid.RowProperty), (int)(sender as Border).GetValue(Grid.ColumnProperty));
        }

        

        

        

        

        
        

        

        



        

        

        

        

        

        

        

        

        

        

       
    }
}
