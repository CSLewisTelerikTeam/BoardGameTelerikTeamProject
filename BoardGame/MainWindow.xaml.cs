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
            LoadBackgroundMusic();
            InitializeUnits();

            

        }

        private bool isMouseCapture;
        private double mouseXOffset;
        private double mouseYOffset;
        private TranslateTransform translateTransform;
        private MediaPlayer backgroundMusic = new MediaPlayer();

        //private void WarchiefUnit_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    Image warchief = new Image();
        //    warchief.Source = new BitmapImage(new Uri(@"http://vidimitrov.com/images/Warcraft_Units/warchief.png", UriKind.Absolute));
        //    this.BigCardImage.Width = 330;
        //    this.BigCardImage.Source = warchief.Source;
        //}   
        //private void WarchiefUnit_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    this.BigCardImage.Source = null;           
        //}

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image img = new Image();

            string smallImgSource = (sender as Image).Source.ToString();

            string bigImgSource = smallImgSource.Replace("small", "big");

            img.Source = new BitmapImage(new Uri(bigImgSource, UriKind.Absolute));

            this.BigCardImage.Width = 330;
            this.BigCardImage.Source = img.Source;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            this.BigCardImage.Source = null;
        }


        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = (Image)sender;
            Border border = (Border)image.Parent;

            image.CaptureMouse();
            isMouseCapture = true;
            mouseXOffset = e.GetPosition(border).X;
            mouseYOffset = e.GetPosition(border).Y;


            var chessPiece = (Image)sender;
            var chessSquare = (Border)chessPiece.Parent;

            var row = (byte)(Grid.GetRow(chessSquare));
            var column = (byte)(Grid.GetColumn(chessSquare) - 1);

            //if (engine.HumanPlayer == ChessPieceColor.White)
            //{
            //    SelectionChanged(row, column, false);
            //}
            //else
            //{
            //    SelectionChanged((byte)(7 - row), (byte)(7 - column), false);
            //}
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            Image image = (Image)sender;
            Border border = (Border)image.Parent;


            //if (!currentSource.Selected)
            //{
            //    image.ReleaseMouseCapture();
            //    isMouseCapture = false;

            //    translateTransform = new TranslateTransform();

            //    translateTransform.X = 0;
            //    translateTransform.Y = 0;

            //    mouseXOffset = 0;
            //    mouseYOffset = 0;
            //}



            if (isMouseCapture)
            {
                translateTransform = new TranslateTransform();

                translateTransform.X = e.GetPosition(border).X - mouseXOffset;
                translateTransform.Y = e.GetPosition(border).Y - mouseYOffset;

                image.RenderTransform = translateTransform;

                //CalculateSquareSelected((int)translateTransform.X, (int)translateTransform.Y, false);
            }
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (translateTransform == null)
            {
                return;
            }


            Image image = (Image)sender;
            Border border = (Border)image.Parent;
            //border.Child = image;

            

            image.ReleaseMouseCapture();
            isMouseCapture = false;

            if (translateTransform.X > 10 || translateTransform.Y > 10 || translateTransform.X < -10 || translateTransform.Y < -10)
            {
                CalculateSquareSelected((int)translateTransform.X, (int)translateTransform.Y, true, border);
            }

            translateTransform = new TranslateTransform();

            translateTransform.X = 0;
            translateTransform.Y = 0;

            mouseXOffset = 0;
            mouseYOffset = 0;

            image.RenderTransform = translateTransform;
        }

        private void CalculateSquareSelected(int inputX, int inputY, bool something, UIElement element)
        {
            int x = Math.Abs(inputX / 100);
            int y = Math.Abs(inputY / 100);

            Grid.SetRow(element, x);
            Grid.SetColumn(element, y);
        }

        private void InitializeUnits()
        {
            var king = InitializedTeams.allianceTeam[15] as AllianceKing;
            king.SmallImage.MouseLeftButtonDown += new MouseButtonEventHandler(Image_MouseLeftButtonDown);
            king.SmallImage.MouseMove += new MouseEventHandler(Image_MouseMove);
            king.SmallImage.MouseLeftButtonUp += new MouseButtonEventHandler(Image_MouseLeftButtonUp);
            king.SmallImage.MouseEnter += new MouseEventHandler(Image_MouseEnter);
            king.SmallImage.MouseLeave += new MouseEventHandler(Image_MouseLeave);

            var unit00 = (Border)this.Playfield.FindName("Unit00");
            unit00.Child = (InitializedTeams.allianceTeam[15] as AllianceKing).SmallImage;

            var captain = InitializedTeams.allianceTeam[10] as AllianceCaptain;
            captain.SmallImage.MouseLeftButtonDown += new MouseButtonEventHandler(Image_MouseLeftButtonDown);
            captain.SmallImage.MouseMove += new MouseEventHandler(Image_MouseMove);
            captain.SmallImage.MouseLeftButtonUp += new MouseButtonEventHandler(Image_MouseLeftButtonUp);
            captain.SmallImage.MouseEnter += new MouseEventHandler(Image_MouseEnter);
            captain.SmallImage.MouseLeave += new MouseEventHandler(Image_MouseLeave);

            var unit01 = (Border)this.Playfield.FindName("Unit01");
            unit01.Child = (InitializedTeams.allianceTeam[10] as AllianceCaptain).SmallImage;

        }
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

       
    }
}
