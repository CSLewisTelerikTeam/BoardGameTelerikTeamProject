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

            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource =
            new BitmapImage(new Uri(@"http://vidimitrov.com/images/Warcraft_Units/bg.jpg", UriKind.Absolute));
            this.Background = myBrush;

            Image warchief = new Image();
            warchief.Source = new BitmapImage(new Uri(@"http://vidimitrov.com/images/Warcraft_Units/warchief.png", UriKind.Absolute));
            Image captain = new Image();
            captain.Source = new BitmapImage(new Uri(@"http://vidimitrov.com/images/Warcraft_Units/captain.png", UriKind.Absolute));
            Image commander = new Image();
            commander.Source = new BitmapImage(new Uri(@"http://vidimitrov.com/images/Warcraft_Units/commander.png", UriKind.Absolute));
            Image grunt = new Image();
            grunt.Source = new BitmapImage(new Uri(@"http://vidimitrov.com/images/Warcraft_Units/grunt.png", UriKind.Absolute));
            Image king = new Image();
            king.Source = new BitmapImage(new Uri(@"http://vidimitrov.com/images/Warcraft_Units/king.png", UriKind.Absolute));
            Image squire = new Image();
            squire.Source = new BitmapImage(new Uri(@"http://vidimitrov.com/images/Warcraft_Units/squire.png", UriKind.Absolute));

            Img1.Source = warchief.Source;
            Img2.Source = captain.Source;
            Img3.Source = king.Source;
            Img4.Source = squire.Source;
            Img5.Source = commander.Source;
            Img6.Source = warchief.Source;
            Img7.Source = grunt.Source;
            Img8.Source = king.Source;
            Img11.Source = warchief.Source;
            Img12.Source = captain.Source;
            Img13.Source = king.Source;
            Img14.Source = warchief.Source;
            Img15.Source = commander.Source;
            Img16.Source = warchief.Source;
            Img17.Source = grunt.Source;
            Img18.Source = king.Source;

            //WarchiefCanvas.

        }

        private void WarchiefUnit_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"http://vidimitrov.com/images/Warcraft_Units/warchiefVoice.mp3"));
            mediaPlayer.Play();
        }

        private void CaptainUnit_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"http://vidimitrov.com/images/Warcraft_Units/captainVoice.mp3"));
            mediaPlayer.Play();
        }

        private void KingUnit_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"http://vidimitrov.com/images/Warcraft_Units/kingVoice.mp3"));
            mediaPlayer.Play();
        }

        private void SquireUnit_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"http://vidimitrov.com/images/Warcraft_Units/squireVoice.mp3"));
            mediaPlayer.Play();
        }
    }
}
