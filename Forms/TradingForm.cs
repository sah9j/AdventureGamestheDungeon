using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AdventureGamesTheDungeon
{
    // This handles the events in which the player decides to trade with Edric.
    public partial class TradingForm : Form
    {
        private int numberOfCoins = 0;
        List<int> playerInventory;
        public TradingForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        // This event finds the number of coins that the player holds and finds out if the player has already taken a specific card from Edric before.
        private void TradingForm_Load(object sender, EventArgs e)
        {
            label1.Text = "To purchase a medicinal herb, return 1 coin to the box and take adventure card 18. To purchase a ring, return 2 coins to the box and take adventure card 19. To purchase a bronze key, return 1 coin to the box and take adventure card 20. You can purchase as many items as you can afford.";
            
            // Creates and opens sqlite connection
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            // This finds the full records of the Medicinal Herb Comfrey and the Ring cards. It then checks
            // to see if the player has already obtained them before. If so, they cannot get it again.
            string sql = "SELECT * FROM AdventureCards WHERE Name == 'Medicinal herb Comfrey' OR 'Ring';";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                if(int.Parse(data["ID"].ToString()) == 18 && int.Parse(data["Taken"].ToString()) == 1)
                    button1.Enabled = false;
                if (int.Parse(data["ID"].ToString()) == 19 && int.Parse(data["Taken"].ToString()) == 1)
                    button2.Enabled = false;
            }
            data.Close();

            // This finds the full records of the Bronze Key card. It then checks to see if the player has already obtained it before. If so, they cannot get it again.
            sql = "SELECT * FROM AdventureCards WHERE Name == 'Bronze Key' AND ID == 20;";
            cmd = new SQLiteCommand(sql, m_dbConnection);
            data = cmd.ExecuteReader();
            if(data.Read())
            {
                if(int.Parse(data["Taken"].ToString()) == 1)
                    button3.Enabled = false;
            }
            data.Close();

            // This finds the number of coins in the player inventory.
            sql = "SELECT * FROM POneInventory WHERE NAME == 'Coin'";
            cmd = new SQLiteCommand(sql, m_dbConnection);
            data = cmd.ExecuteReader();
            while(data.Read())
            {
                numberOfCoins++;
                playerInventory.Add(int.Parse(data["ID"].ToString()));
            }
            data.Close();
            cmd.Dispose();

            // close the connection
            m_dbConnection.Close();

            label5.Text = $"You have {numberOfCoins} Coins!";
        }

        private void button4_Click(object sender, EventArgs e)
        {
                this.Close();
        }
        // This event occurs if the player wants to buy the Medicinal Herb Comfrey.
        private void button1_Click(object sender, EventArgs e)
        {
            if (numberOfCoins > 0)
            {
                numberOfCoins--;

                // This if/else-if statement is used to get rid of one coin in the inventory.
                if(playerInventory.Find(p => p == 15) != 0)
                    AdventureCardDatabase.RemoveCard(15);
                else if (playerInventory.Find(p => p == 21) != 0)
                    AdventureCardDatabase.RemoveCard(21);
                else if (playerInventory.Find(p => p == 22) != 0)
                    AdventureCardDatabase.RemoveCard(22);
                else if (playerInventory.Find(p => p == 23) != 0)
                    AdventureCardDatabase.RemoveCard(23);

                // add the card.
                AdventureCardDatabase.AddCardToInventory(18);

                button1.Enabled = false;
                label5.Text = $"You have {numberOfCoins} Coins!";
            }
            else
                MessageBox.Show("You do not have enough Coins to purchase this item!");
        }
        // This event occurs if the player wants to buy the Ring.
        private void button2_Click(object sender, EventArgs e)
        {
            if (numberOfCoins >= 2)
            {
                numberOfCoins-=2;
                if (playerInventory.Find(p => p == 15) != 0)
                    AdventureCardDatabase.RemoveCard(15);
                else if (playerInventory.Find(p => p == 21) != 0)
                    AdventureCardDatabase.RemoveCard(21);
                else if (playerInventory.Find(p => p == 22) != 0)
                    AdventureCardDatabase.RemoveCard(22);
                else if (playerInventory.Find(p => p == 23) != 0)
                    AdventureCardDatabase.RemoveCard(23);

                if (playerInventory.Find(p => p == 15) != 0)
                    AdventureCardDatabase.RemoveCard(15);
                else if (playerInventory.Find(p => p == 21) != 0)
                    AdventureCardDatabase.RemoveCard(21);
                else if (playerInventory.Find(p => p == 22) != 0)
                    AdventureCardDatabase.RemoveCard(22);
                else if (playerInventory.Find(p => p == 23) != 0)
                    AdventureCardDatabase.RemoveCard(23);

                AdventureCardDatabase.AddCardToInventory(19);
                button2.Enabled = false;
                label5.Text = $"You have {numberOfCoins} Coins!";
            }
            else
                MessageBox.Show("You do not have enough Coins to purchase this item!");
        }
        // This event occurs if the player wants to buy the Bronze Key.
        private void button3_Click(object sender, EventArgs e)
        {
            if (numberOfCoins > 0)
            {
                numberOfCoins--;
                if (playerInventory.Find(p => p == 15) != 0)
                    AdventureCardDatabase.RemoveCard(15);
                else if (playerInventory.Find(p => p == 21) != 0)
                    AdventureCardDatabase.RemoveCard(21);
                else if (playerInventory.Find(p => p == 22) != 0)
                    AdventureCardDatabase.RemoveCard(22);
                else if (playerInventory.Find(p => p == 23) != 0)
                    AdventureCardDatabase.RemoveCard(23);
                AdventureCardDatabase.AddCardToInventory(20);
                button3.Enabled = false;
                label5.Text = $"You have {numberOfCoins} Coins!";
            }
            else
                MessageBox.Show("You do not have enough Coins to purchase this item!");
        }
    }
}
