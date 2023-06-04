using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Pairs
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        int index = 1;
        List<Player> players = new List<Player>();

        public CreateAccount()
        {
            InitializeComponent();
            readUsers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "C:\\Users\\user\\Desktop\\imagesPaths.txt");
            //string[] paths = File.ReadAllLines(path);
            //int index = 0;
            //string psource = profilPicture.Source.ToString();
            //string ps = psource.Substring(psource.Length-8, 8);
            //string p = psource.Substring(0, psource.Length - 8);
            //foreach (string img in paths)
            //{
            //    if (img.Equals(ps))
            //    {
            //        break;
            //    }
            //    index++;
            //}
            //if (index + 1 < paths.Length)
            //{
            //    profilPicture.Source = new BitmapImage(new Uri(p+paths[index + 1]));
            //}
            //else
            //{
            //    profilPicture.Source = new BitmapImage(new Uri(p+paths[0]));
            //}

            index++;
            if(index>10)
            {
                index = 1;
            }
            profilePicture.Source= new BitmapImage(new Uri(@"profilePictures/im" + index + ".jpg",UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "C:\\Users\\user\\Desktop\\imagesPaths.txt");
            //string[] paths = File.ReadAllLines(path);
            //int index = 0;
            //string psource = profilPicture.Source.ToString();
            //string ps = psource.Substring(psource.Length - 8, 8);
            //string p = psource.Substring(0, psource.Length - 8);
            //foreach (string img in paths)
            //{
            //    if (img.Equals(ps))
            //    {
            //        break;
            //    }
            //    index++;
            //}
            //if (index - 1 >= 0)
            //{
            //    profilPicture.Source = new BitmapImage(new Uri(p + paths[index - 1]));
            //}
            //else
            //{
            //    profilPicture.Source = new BitmapImage(new Uri(p + paths[paths.Length-1]));
            //}

            index--;
            if (index < 1)
            {
                index = 10;
            }
            profilePicture.Source = new BitmapImage(new Uri(@"profilePictures/im" + index + ".jpg", UriKind.Relative));

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            string imagePath=profilePicture.Source.ToString();
            imagePath=imagePath.Substring(imagePath.Length-7,7);

            if (imagePath[0]!='i')
            {
                imagePath = 'i'+imagePath;
            }

            if (name.Text == "")
            {
                MessageBox.Show("Please enter your username");
                return;
            }
            else
            {
                foreach (Player player in players)
                {
                    if (player.Name == name.Text)
                    {
                        MessageBox.Show("This username is already taken");
                        return;
                    }
                }

                //Player newPlayer = new Player(name.Text, imagePath);

                Uri filePath = new Uri(@"..\..\Users.txt", UriKind.Relative);
                List<string> lines = System.IO.File.ReadAllLines(filePath.ToString()).ToList();
                StreamWriter writer = new StreamWriter(filePath.ToString());
                if (lines.Count != 0)
                {
                    foreach (String line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }
                writer.WriteLine(name.Text + ' ' + imagePath + ' ' + 0 + ' ' + 0);
                writer.Close();

                MessageBox.Show("Your account has been created");
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
        }

        private void readUsers()
        {
            Uri filePath = new Uri(@"..\..\Users.txt", UriKind.Relative);
            List<string> lines = System.IO.File.ReadAllLines(filePath.ToString()).ToList();

            foreach (String line in lines)
            {
                string[] items = line.Split(' ');
                Player player = new Player(items[0], items[1]);
                players.Add(player);
            }
        }
    }

}
