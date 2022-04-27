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
    // This form allows the player to combine items with locations.
    public partial class ItemAndLocation : Form
    {
        // The room card that the player is currently in.
        char room;

        // This list stores what listbox1 contains.
        List<string> playerInventory = AdventureCardDatabase.GetInventory();
        
        // This list contains a copy of the player inventory and is used to be passed into the EntryEvaluations class.
        List<Card> invent;

        public ItemAndLocation(char r, List<Card> cards)
        {
            InitializeComponent();
            invent = cards;
            room = r;
        }

        // This event takes what 2 IDs were selected and evaluates the combined entry.
        private void Combine_Click(object sender, EventArgs e)
        {
            var locationID = listBox2.SelectedItem;

            string item = listBox1.SelectedItem.ToString();
            int itemID = int.Parse(item.Substring(0, 2));
            string entry = itemID.ToString() + locationID.ToString();

            // placeholder
            int hp = 16;

            EntryEvaluation.ItemLocationEvaluation(int.Parse(entry),ref invent,ref hp,"");

            playerInventory = AdventureCardDatabase.GetInventory();
            listBox1.Items.Clear();
            foreach (string record in playerInventory)
            {
                listBox1.Items.Add(record);
            }
        }

        // This event is used to fill the listboxes.
        private void ItemAndLocation_Load(object sender, EventArgs e)
        {

            foreach (string item in playerInventory)
            {
                listBox1.Items.Add(item);
            }
            switch(room)
            {
                case 'A':
                    listBox2.Items.Add(101);
                    listBox2.Items.Add(201);
                    listBox2.Items.Add(301);
                    listBox2.Items.Add(401);
                    listBox2.Items.Add(501);
                    listBox2.Items.Add(601);
                    listBox2.Items.Add(701);
                    listBox2.Items.Add(801);
                    break;
                case 'B':
                    listBox2.Items.Add(110);
                    listBox2.Items.Add(210);
                    listBox2.Items.Add(310);
                    listBox2.Items.Add(510);
                    break;
                case 'C':
                    listBox2.Items.Add(105);
                    listBox2.Items.Add(205);
                    listBox2.Items.Add(305);
                    listBox2.Items.Add(405);
                    listBox2.Items.Add(505);
                    listBox2.Items.Add(605);
                    listBox2.Items.Add(705);
                    listBox2.Items.Add(805);
                    break;
                case 'D':
                    listBox2.Items.Add(109);
                    listBox2.Items.Add(209);
                    listBox2.Items.Add(309);
                    listBox2.Items.Add(409);
                    listBox2.Items.Add(509);
                    listBox2.Items.Add(609);
                    break;
                case 'E':
                    listBox2.Items.Add(107);
                    listBox2.Items.Add(207);
                    listBox2.Items.Add(307);
                    listBox2.Items.Add(507);
                    listBox2.Items.Add(607);
                    listBox2.Items.Add(707);
                    break;
                case 'F':
                    listBox2.Items.Add(112);
                    listBox2.Items.Add(212);
                    listBox2.Items.Add(312);
                    break;
                case 'G':
                    listBox2.Items.Add(102);
                    listBox2.Items.Add(202);
                    listBox2.Items.Add(302);
                    listBox2.Items.Add(402);
                    listBox2.Items.Add(502);
                    listBox2.Items.Add(602);
                    listBox2.Items.Add(702);
                    listBox2.Items.Add(802);
                    break;
                case 'H':
                    listBox2.Items.Add(104);
                    listBox2.Items.Add(204);
                    listBox2.Items.Add(304);
                    listBox2.Items.Add(404);
                    listBox2.Items.Add(504);
                    break;
                case 'I':
                    listBox2.Items.Add(203);
                    listBox2.Items.Add(303);
                    listBox2.Items.Add(403);
                    listBox2.Items.Add(503);
                    break;
                case 'J':
                    listBox2.Items.Add(108);
                    listBox2.Items.Add(208);
                    listBox2.Items.Add(308);
                    listBox2.Items.Add(408);
                    listBox2.Items.Add(508);
                    listBox2.Items.Add(608);
                    break;
                case 'K':
                    listBox2.Items.Add(113);
                    listBox2.Items.Add(213);
                    listBox2.Items.Add(313);
                    break;
                case 'L':
                    listBox2.Items.Add(110);
                    listBox2.Items.Add(210);
                    listBox2.Items.Add(310);
                    listBox2.Items.Add(410);
                    break;
                case 'M':
                    listBox2.Items.Add(106);
                    listBox2.Items.Add(206);
                    listBox2.Items.Add(306);
                    listBox2.Items.Add(406);
                    listBox2.Items.Add(506);
                    listBox2.Items.Add(606);
                    listBox2.Items.Add(706);
                    break;
                case 'N':
                    listBox2.Items.Add(111);
                    listBox2.Items.Add(211);
                    listBox2.Items.Add(311);
                    listBox2.Items.Add(411);
                    listBox2.Items.Add(511);
                    listBox2.Items.Add(611);
                    listBox2.Items.Add(711);
                    break;
                case 'O':
                    listBox2.Items.Add(114);
                    listBox2.Items.Add(214);
                    listBox2.Items.Add(314);
                    listBox2.Items.Add(414);
                    break;
                case 'P':
                    listBox2.Items.Add(115);
                    listBox2.Items.Add(215);
                    listBox2.Items.Add(315);
                    listBox2.Items.Add(415);
                    listBox2.Items.Add(515);
                    break;
                case 'Q':
                    listBox2.Items.Add(309);
                    listBox2.Items.Add(409);
                    listBox2.Items.Add(509);
                    listBox2.Items.Add(609);
                    listBox2.Items.Add(709);
                    listBox2.Items.Add(809);
                    break;
                case 'R':
                    listBox2.Items.Add(107);
                    listBox2.Items.Add(207);
                    listBox2.Items.Add(307);
                    listBox2.Items.Add(507);
                    listBox2.Items.Add(607);
                    listBox2.Items.Add(807);
                    break;
            }
        }

        // player is finished with combining.
        private void Done_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
