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
    // This form allows the player to view what they currently have in their inventory.
    // It also allows the player to use any special effects that an item offers them.
    public partial class Inventory : Form
    {
        // Used to display what is in listbox.
        List<string> playerInventory = AdventureCardDatabase.GetInventory();

        // holds a copy of the player inventory. The list is passed to the EntryEvaluations class.
        List<Card> itemInventory = new List<Card>();

        string name;
        int hp;
        public Inventory(string name, List<Card> inventory, int hp)
        {
            InitializeComponent();
            button1.Parent = this;
            this.name = name;
            itemInventory.AddRange(inventory);
            this.hp = hp;

            foreach (string item in playerInventory)
            {
                listBox1.Items.Add(item);
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {

        }

        private void Inventory_Load(object sender, EventArgs e)
        {

        }
        // This event is what allows the player to view each card's picture.
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemChosen = listBox1.GetItemText(listBox1.SelectedIndex);
            int itemID;
            if (itemChosen != "-1")
            {
                itemChosen = listBox1.SelectedItem.ToString();
                itemID = int.Parse(itemChosen.Substring(0, 2));
                pictureBox1.Image = (Image)(Properties.Resources.ResourceManager.GetObject($"_{itemID}"));
                if (itemID == 18 || itemID == 32 || itemID == 35 || itemID == 38 || itemID == 39 || itemID == 43 || itemID == 47 || itemID == 52 || itemID == 70 || itemID == 71)
                {
                    button2.Visible = true;
                }
                else
                    button2.Visible = false;
            }
        }

        // player is done looking through inventory.
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // This event is used when the player wants to activate a certain item effect.
        private void button2_Click(object sender, EventArgs e)
        {
            string itemChosen = listBox1.SelectedItem.ToString();
            int itemID = int.Parse(itemChosen.Substring(0, 2));
            switch (itemID)
            {
                case 18:
                    AdventureCardDatabase.ChangeHP(2,name);
                    break;
                case 32:
                    EntryEvaluation.LocEntry(ref itemInventory, ref hp, Name, 125);
                    break;
                case 35:
                    EntryEvaluation.LocEntry(ref itemInventory, ref hp, Name, 425);
                    break;
                case 38:
                    EntryEvaluation.LocEntry(ref itemInventory, ref hp, Name, 225);
                    break;
                case 39:
                    EntryEvaluation.LocEntry(ref itemInventory, ref hp, Name, 325);
                    break;
                case 43:
                    EntryEvaluation.LocEntry(ref itemInventory, ref hp, Name, 425);
                    break;
                case 47:

                    AdventureCardDatabase.ChangeHP(hp+2, name);
                    AdventureCardDatabase.RemoveCard(itemID);
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    break;
                case 52:
                    AdventureCardDatabase.ChangeHP(hp+1, name);
                    AdventureCardDatabase.RemoveCard(itemID);
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    break;
                case 70:
                    EntryEvaluation.LocEntry(ref itemInventory, ref hp, Name, 525);
                    break;
                case 71:
                    AdventureCardDatabase.ChangeHP(1, name);
                    break;
            }
            button2.Enabled = false;
        }
    }
}
