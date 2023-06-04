using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pairs
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        Player player;
        List<Player> players;
        Button firstButton, secondButton;
        int index = 0;
        int level;
        int nrTiles;
        public Game(Player player,int level, List<Player> players)
        {
            InitializeComponent();
            this.player = player;
            this.players = players;
            this.level = level;
            profilePicture.Source = new BitmapImage(new Uri(@"profilePictures/" + player.ImageName, UriKind.Relative));
            name.Text = "Name: " + player.Name;
            noLevel.Text = "Level: " + (level + 1).ToString();
            this.players = players;
        }

        private void VerifyTheButtons()
        {
            string name1 = firstButton.ContentStringFormat;
            string name2 = secondButton.ContentStringFormat;
            if(name1.Equals(name2))
            {
                firstButton.Visibility = Visibility.Hidden;
                secondButton.Visibility = Visibility.Hidden;
                nrTiles+=2;
                firstButton = null;
                secondButton = null;
            }
            else
            {
                Image secondImage = secondButton.FindName("tilePicture") as Image;
                index = 0;
                secondImage.Source = new BitmapImage(new Uri("imagesForGame/initial.jpg", UriKind.Relative));
                Image firstImage = firstButton.FindName("tilePicture") as Image;
                firstImage.Source = new BitmapImage(new Uri("imagesForGame/initial.jpg", UriKind.Relative));
                firstButton = null;
                secondButton = null;
            }
        }
        private void AssignButtons(Button button)
        {
            if (firstButton == null)
            {
                firstButton = button;
                return;
            }
            else if (firstButton == button)
            {
                index = 1;
                return;
            }
            else if (secondButton == button)
            {
                index--;
                return;
            }
            else
            {
                secondButton = button;
            }
        }
       

        private void UpdateUserList(Player player)
        {
            Uri filePath = new Uri(@"..\..\Users.txt", UriKind.Relative);
            List<string> lines = System.IO.File.ReadAllLines(filePath.ToString()).ToList();

            StreamWriter writer = new StreamWriter(filePath.ToString());
            if (lines.Count != 0 && player.Name != "")
            {
                foreach (String line in lines)
                {
                    string[] items = line.Split(' ');
                    if (!items[0].Equals(player.Name))
                    {
                        writer.WriteLine(line);
                    }
                    else
                    {
                        writer.WriteLine(player.Name + ' ' + player.ImageName + ' ' + player.GamesPlayed + ' ' + player.GamesWon);
                    }
                }
            }
            writer.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            index++;
            if (index == 3)
            {
                VerifyTheButtons();
                index = 1;
            }
            Button button = sender as Button;
            string name = button.ContentStringFormat;
           
            if (name.Equals("0"))
            {
                button.Visibility = Visibility.Hidden;
                nrTiles++;
                index--;
                return;
            }
            Image image = button.FindName("tilePicture") as Image;
            image.Source = new BitmapImage(new Uri("imagesForGame/"+name+ ".jpg", UriKind.Relative));
            AssignButtons(button);

            if(nrTiles == 23 && index==2)
            {
                VerifyTheButtons();
            }

            if (nrTiles == 25)
            {
                level++;
                nrTiles = 0;
                if (level < 3)
                {
                    Game game = new Game(player,level,players);
                    game.Show();
                    this.Close();
                }
                if(level == 3)
                {
                    player.GamesWon++;
                    UpdateUserList(player);
                    MessageBox.Show("You won the game!");
                    NewGameMode newGameMode = new NewGameMode(player, players);
                    newGameMode.Show();
                    this.Close();
                }
            }
            
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            NewGameMode newGameMode = new NewGameMode(player, players);
            newGameMode.Show();
            this.Close();
        }
    }
}
