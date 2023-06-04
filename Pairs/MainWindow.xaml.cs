using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace Pairs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        List<Player> players = new List<Player>();
        public MainWindow()
        {
            InitializeComponent();
            readUsers();
            bindListBox();
        }

        private void Exit_Click(object sender, RoutedEventArgs e) => Close();

        private void New_User_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            createAccount.Show();
            this.Close();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Player player = (Player)usersListBox.SelectedItem;
            if (player == null)
            {
                MessageBox.Show("Please select your account.");
                return;
            }
            else
            {
                Play playWindow = new Play(player,players);
                playWindow.Show();
                this.Close();
            }
        }

        private void DeleteUser(Player player)
        {
            Uri filePath = new Uri(@"..\..\Users.txt", UriKind.Relative);
            List<string> lines = System.IO.File.ReadAllLines(filePath.ToString()).ToList();

            StreamWriter writer = new StreamWriter(filePath.ToString());
            if (lines.Count != 0 && player.Name!="")
            {
                foreach (String line in lines)
                {
                    string[] items = line.Split(' ');
                    if (!items[0].Equals(player.Name))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            writer.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Player player = (Player)usersListBox.SelectedItem;
            if (player==null)
            {
                MessageBox.Show("Please select a user to delete");
                return;
            }
            else
            {
                DeleteUser(player);
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Player player = (Player)usersListBox.SelectedItem;
            profilePicture.Source = new BitmapImage(new Uri(@"profilePictures/"+ player.ImageName, UriKind.Relative));
        }

        private void readUsers()
        {

            Uri filePath = new Uri(@"..\..\Users.txt", UriKind.Relative);

            List<string> lines = System.IO.File.ReadAllLines(filePath.ToString()).ToList();

            foreach(String line in lines)
            {
                string[] items = line.Split(' ');
                if (items.Length != 4)
                {
                    Player player = new Player(items[0], items[1], 0, 0);
                    players.Add(player);
                }
                else
                {
                    Player player = new Player(items[0], items[1], Int32.Parse(items[2]), Int32.Parse(items[3]));
                    players.Add(player);
                }
            }
        }
        private void bindListBox()
        {
            usersListBox.ItemsSource = players;
            usersListBox.DisplayMemberPath = "Name";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nume student: Stroescu Victor-Cristian\nGrupa: 10LF213\nSpecializare: Informatica");
        }
    }
}
