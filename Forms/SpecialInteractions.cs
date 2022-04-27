using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureGamesTheDungeon
{
    // This form handles a variety of different interactions and changes its design depending on the
    // particular interaction.
    public partial class SpecialInteractions : Form
    {
        public List<int> entries = new List<int>();
        private List<Card> cards = new List<Card>();
        public static int fakehp;
        public string name;
        public int digits = 0;
        public bool choosing = false;
        public SpecialInteractions(int hp)
        {
            InitializeComponent();
            fakehp = hp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // If the ChooseYourCard method created this form, then add AdventureCard 70 to the inventory.
            // otherwise, handle the specific entry connected to the character name of the character event.
            if (choosing)
                AdventureCardDatabase.CreateCard(ref cards,70);
            else
                EntryEvaluation.LocEntry(ref cards, ref fakehp, name, entries[0]);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // If the ChooseYourCard method created this form, then add AdventureCard 70 to the inventory.
            // otherwise, handle the specific entry connected to the character name of the character event.
            if (choosing)
                AdventureCardDatabase.CreateCard(ref cards, 71);
            else
                EntryEvaluation.LocEntry(ref cards, ref fakehp,name, entries[1]);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // If the ChooseYourCard method created this form, then add AdventureCard 70 to the inventory.
            // otherwise, handle the specific entry connected to the character name of the character event.
            if (choosing)
                AdventureCardDatabase.CreateCard(ref cards, 72);
            else
                EntryEvaluation.LocEntry(ref cards, ref fakehp, name, entries[2]);
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // If the ChooseYourCard method created this form, then add AdventureCard 70 to the inventory.
            // otherwise, handle the specific entry connected to the character name of the character event.
            if (choosing)
                AdventureCardDatabase.CreateCard(ref cards, 73);
            else
                EntryEvaluation.LocEntry(ref cards, ref fakehp,name, entries[3]);
            this.Close();
        }
        
        // This event handles the instances where the player must enter a value.
        private void button5_Click(object sender, EventArgs e)
        {
            string entryID = textBox1.Text + digits.ToString();
            EntryEvaluation.ItemLocationEvaluation(int.Parse(entryID),ref cards,ref fakehp,name);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
