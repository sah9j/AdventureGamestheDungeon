using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGamesTheDungeon
{
    // This class holds the values for the Player's inventory, name, and Life.
    internal class Player
    {
        public List<Card> inventory = new List<Card>();
        public string Name { get; set; }
        public int Life;

        public Player(string name, int life)
        {
            this.Name = name;
            this.Life = life;

        }
    }
}
