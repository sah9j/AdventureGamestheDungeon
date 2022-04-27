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
    // This form is used to combine two selected items together.
    public partial class CombineItems : Form
    {
        // This list holds the essential data for each record in the database. This is used to display
        // each item in the inventory.
        List<string> playerInventory = AdventureCardDatabase.GetInventory();
        
        // This list will hold a copy of the player's inventory in order to pass it into the EntryEvaluations class.
        List<Card> itemInventory = new List<Card>();
        
        // name of player.
        string name;
        public CombineItems(string name, List<Card> inventory)
        {
            InitializeComponent();
            this.name = name;
            itemInventory.AddRange(inventory);
        }

        // This event will take the items selected from both listboxes, obtain their IDs, and combine them
        // in order to evaluate the entry.
        private void Combine_Click(object sender, EventArgs e)
        {
            string oneItemChosen = listBox1.SelectedItem.ToString();
            int firstItemID = int.Parse(oneItemChosen.Substring(0, 2));

            string secondItemChosen = listBox2.SelectedItem.ToString();
            int secondItemID = int.Parse(secondItemChosen.Substring(0, 2));

            int hp = 6;
            if(firstItemID < secondItemID)
            {
                EntryEvaluation.ItemsEntryEval(ref itemInventory,ref hp,name, int.Parse(oneItemChosen.Substring(0, 2) + secondItemChosen.Substring(0, 2)));
                
            }
            else
            {
                EntryEvaluation.ItemsEntryEval(ref itemInventory, ref hp, name, int.Parse(secondItemChosen.Substring(0, 2) + oneItemChosen.Substring(0, 2)));
            }
            playerInventory = AdventureCardDatabase.GetInventory();
            listBox1.DataSource = playerInventory;
            listBox2.DataSource = playerInventory;
        }
        // This sets up what the listboxes are referencing.
        private void CombineItems_Load(object sender, EventArgs e)
        {
            listBox1.BindingContext = new BindingContext();
            listBox1.DataSource = playerInventory;
            listBox2.BindingContext = new BindingContext();
            listBox2.DataSource = playerInventory;
        }

        // Player is done combining items.
        private void Done_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
