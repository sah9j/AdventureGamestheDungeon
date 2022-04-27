using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGamesTheDungeon
{
    // This class holds the data for a card.
    public class Card
    {
        public int canCombine { get; private set; }
        public int canTrade { get; private set; }
        public string Picture { get; private set; }
        public string Text { get; private set; }
        public int ID { get; private set; }
        public string Name { get; private set; }

        public Card(int combining, int trading, string picture, string textstr, int IDs, string name)
        {
            canCombine = combining;
            canTrade = trading;
            Picture = picture;
            Text = textstr;
            ID = IDs;
            Name = name;
        }
         public Card()
        {
            canCombine = 0;
            canTrade = 0;
            Picture = "";
            Text = "";
            ID = 0;
            Name = "";
        }

    }
}
