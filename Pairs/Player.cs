using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pairs
{
    public class Player
    {
        public string Name { get; set; }
        public string ImageName { get; set; }

        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }

        public Player()
        {
            Name = "Fara nume";
        }

        public Player(string name, string imageName, int gamesPlayed = 0,int gamesWon=0)
        {
            Name = name;
            ImageName = imageName;
            GamesPlayed = gamesPlayed;
            GamesWon = gamesWon;
        }

        public override string ToString() {
            return Name;
        }
    }
}
