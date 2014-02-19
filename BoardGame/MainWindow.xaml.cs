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

        //Aliance units events

        private void Squire01_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[0].IsSelected = true;
            if (InitializedTeams.allianceTeam[0].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Squire01.GetValue(Grid.RowProperty), (int)Squire01.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Squire02_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[1].IsSelected = true;
            if (InitializedTeams.allianceTeam[1].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Squire02.GetValue(Grid.RowProperty), (int)Squire02.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Squire03_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[2].IsSelected = true;
            if (InitializedTeams.allianceTeam[2].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Squire03.GetValue(Grid.RowProperty), (int)Squire03.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Squire04_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[3].IsSelected = true;
            if (InitializedTeams.allianceTeam[3].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Squire04.GetValue(Grid.RowProperty), (int)Squire04.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Squire05_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[4].IsSelected = true;
            if (InitializedTeams.allianceTeam[4].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Squire05.GetValue(Grid.RowProperty), (int)Squire05.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Squire06_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[5].IsSelected = true;
            if (InitializedTeams.allianceTeam[5].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Squire06.GetValue(Grid.RowProperty), (int)Squire06.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Squire07_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[6].IsSelected = true;
            if (InitializedTeams.allianceTeam[6].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Squire07.GetValue(Grid.RowProperty), (int)Squire07.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Squire08_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[7].IsSelected = true;
            if (InitializedTeams.allianceTeam[7].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Squire08.GetValue(Grid.RowProperty), (int)Squire08.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Mage01_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[8].IsSelected = true;
            if (InitializedTeams.allianceTeam[8].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Mage01.GetValue(Grid.RowProperty), (int)Mage01.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Mage02_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[9].IsSelected = true;
            if (InitializedTeams.allianceTeam[9].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Mage02.GetValue(Grid.RowProperty), (int)Mage02.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Captain01LeftButton(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[10].IsSelected = true;
            if (InitializedTeams.allianceTeam[10].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Captain01.GetValue(Grid.RowProperty), (int)Captain01.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Captain02_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[11].IsSelected = true;
            if (InitializedTeams.allianceTeam[11].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Captain02.GetValue(Grid.RowProperty), (int)Captain02.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void WarGolem01_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[12].IsSelected = true;
            if (InitializedTeams.allianceTeam[12].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)WarGolem01.GetValue(Grid.RowProperty), (int)WarGolem01.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void WarGolem02_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[13].IsSelected = true;
            if (InitializedTeams.allianceTeam[13].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)WarGolem02.GetValue(Grid.RowProperty), (int)WarGolem02.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void King_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[15].IsSelected = true;
            if (InitializedTeams.allianceTeam[15].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)King.GetValue(Grid.RowProperty), (int)King.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Priest_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.allianceTeam[14].IsSelected = true;
            if (InitializedTeams.allianceTeam[14].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Priest.GetValue(Grid.RowProperty), (int)Priest.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        //Horde units events    

        private void Grunt01_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[0].IsSelected = true;
            if (InitializedTeams.hordeTeam[0].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Grunt01.GetValue(Grid.RowProperty), (int)Grunt01.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Grunt01_MouseRightButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Unit aggressor = CheckForSelectedEnemy();
            Attack(aggressor, InitializedTeams.hordeTeam[0]);
        }

        private void Grunt02_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[1].IsSelected = true;
            if (InitializedTeams.hordeTeam[1].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Grunt02.GetValue(Grid.RowProperty), (int)Grunt02.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Grunt03_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[2].IsSelected = true;
            if (InitializedTeams.hordeTeam[2].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Grunt03.GetValue(Grid.RowProperty), (int)Grunt03.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Grunt04_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[3].IsSelected = true;
            if (InitializedTeams.hordeTeam[3].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Grunt04.GetValue(Grid.RowProperty), (int)Grunt04.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Grunt05_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[4].IsSelected = true;
            if (InitializedTeams.hordeTeam[4].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Grunt05.GetValue(Grid.RowProperty), (int)Grunt05.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Grunt06_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[5].IsSelected = true;
            if (InitializedTeams.hordeTeam[5].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Grunt06.GetValue(Grid.RowProperty), (int)Grunt06.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Grunt07_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[6].IsSelected = true;
            if (InitializedTeams.hordeTeam[6].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Grunt07.GetValue(Grid.RowProperty), (int)Grunt07.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Grunt08_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[7].IsSelected = true;
            if (InitializedTeams.hordeTeam[7].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Grunt08.GetValue(Grid.RowProperty), (int)Grunt08.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Warlock01_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[8].IsSelected = true;
            if (InitializedTeams.hordeTeam[8].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Warlock01.GetValue(Grid.RowProperty), (int)Warlock01.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Warlock02_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[9].IsSelected = true;
            if (InitializedTeams.hordeTeam[9].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Warlock02.GetValue(Grid.RowProperty), (int)Warlock02.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Commander01_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[10].IsSelected = true;
            if (InitializedTeams.hordeTeam[10].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Commander01.GetValue(Grid.RowProperty), (int)Commander01.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Commander02_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[11].IsSelected = true;
            if (InitializedTeams.hordeTeam[11].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Commander02.GetValue(Grid.RowProperty), (int)Commander02.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Demolisher01_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[12].IsSelected = true;
            if (InitializedTeams.hordeTeam[12].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Demolisher01.GetValue(Grid.RowProperty), (int)Demolisher01.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Demolisher02_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[13].IsSelected = true;
            if (InitializedTeams.hordeTeam[13].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Demolisher02.GetValue(Grid.RowProperty), (int)Demolisher02.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Shaman_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[14].IsSelected = true;
            if (InitializedTeams.hordeTeam[14].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Shaman.GetValue(Grid.RowProperty), (int)Shaman.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }

        private void Warchief_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DeselectAll();
            InitializedTeams.hordeTeam[15].IsSelected = true;
            if (InitializedTeams.hordeTeam[15].IsSelected)
            {
                UnmarkCurrentCell();
                MarkCurrentCell((int)Warchief.GetValue(Grid.RowProperty), (int)Warchief.GetValue(Grid.ColumnProperty));
            }
            else
            {
                UnmarkCurrentCell();
            }
        }       


        //FieldsEvents

        private void FieldMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            string unit = CheckForSelectedItem();
            Move(unit, (int)(sender as Border).GetValue(Grid.RowProperty), (int)(sender as Border).GetValue(Grid.ColumnProperty));
        }

        

        

        

        
        

        

        



        

        

        

        

        

        

        

        

        

        

       
    }
}
