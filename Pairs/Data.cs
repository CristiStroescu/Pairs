using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Pairs
{
    public class Data
    {
        public List<List<String>> StringItems { get; set; }

        public int rows { get; set; }
        public int columns { get; set; }

        public Data() {
            StringItems = new List<List<String>>();
            HashSet<string> strings = new HashSet<string>();
            while (strings.Count < (5 * 5) / 2)
            {
                Random rnd = new Random();
                int number = rnd.Next(1, 20);
                strings.Add(number.ToString());
            }

            List<string> finalNumbers = new List<string>();
            foreach (string nr in strings)
            {
                finalNumbers.Add(nr);
                finalNumbers.Add(nr);
            }

            if ((5 * 5) % 2 == 1)
            {
                finalNumbers.Add("0");
            }

            Random rng = new Random();
            int n = finalNumbers.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = finalNumbers[k];
                finalNumbers[k] = finalNumbers[n];
                finalNumbers[n] = value;
            }

            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                List<String> item = new List<String>();
                for (int j = 0; j < 5; j++)
                {
                    item.Add(finalNumbers[index].ToString());
                    index++;
                }
                StringItems.Add(item);
            }
        } 
        public Data(int row, int col)
        {
            StringItems = new List<List<String>>();
            HashSet<string> strings = new HashSet<string>();
            while(strings.Count < (row*col)/2)
            {
                Random rnd = new Random();
                int number = rnd.Next(1, 20);
                strings.Add(number.ToString());
            }

            List<string> finalNumbers = new List<string>();
            foreach(string nr in strings)
            {
                finalNumbers.Add(nr);
                finalNumbers.Add(nr);
            }

            if((row * col) % 2 == 1)
            {
                finalNumbers.Add("0");
            }

            Random rng = new Random();
            int n = finalNumbers.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = finalNumbers[k];
                finalNumbers[k] = finalNumbers[n];
                finalNumbers[n] = value;
            }

            int index = 0;
            for (int i=0;i<row;i++)
            {
                List<String> item = new List<String>();
                for (int j = 0; j < col; j++)
                {
                    item.Add(finalNumbers[index].ToString());
                    index++;
                }
                StringItems.Add(item);
            }
        }
    }
}
