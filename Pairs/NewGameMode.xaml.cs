using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Pairs
{
    /// <summary>
    /// Interaction logic for NewGameMode.xaml
    /// </summary>
    public partial class NewGameMode : Window
    {
        Player player;
        List<Player> players;
        public NewGameMode(Player player,List<Player> players)
        {
            this.player = player;
            this.players=players;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Play play = new Play(player,players);
            play.Show();
            this.Close();
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
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Game game = new Game(player,0, players);
            player.GamesPlayed++;
            UpdateUserList(player);
            game.Show();
            this.Close();
        }
        
    }
}
