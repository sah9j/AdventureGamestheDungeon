using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace AdventureGamesTheDungeon
{
    internal static class AdventureCardDatabase
    {
        // This holds the connector string for the database.
        private static SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");

        // This function creates a table that stores all the records/recipes needed in order to create a specified card.
        static public void CreateTable()
        {
            // Creates database
            SQLiteConnection.CreateFile("MyDatabase.sqlite");

            // Open Connection
            m_dbConnection.Open();

            
            string sql = "drop table if exists AdventureCards";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "create table AdventureCards (ID integer primary key, Name nvarchar(30),Text nvarchar(200) null, Combine int null, Trade int null, Picture nvarchar(50) null, Taken int)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();


            // Obtain all the records for the cards and put into description.
            string pathForText = @"InputFiles\\Description.txt";
            string[] description;

            description = File.ReadAllLines(pathForText);
            int counter = 10;
            // Splits each record into different fields in order to add to table.
            for (int i = 0; i < description.Length; i++)
            {
                string[] record = description[i].Split('|');
                CreateRecord(counter, record[1], record[0], int.Parse(record[2]), int.Parse(record[3]), record[4]);
                counter++;
            }

            sql = "drop table if exists PlayerOne";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "create table PlayerOne (Name nvarchar(30) primary key, Life int)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "drop table if exists POneInventory";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "create table POneInventory (ID integer primary key, Name nvarchar(30),Text nvarchar(200) null, Combine int null, Trade int null, Picture nvarchar(50) null, Taken int)";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            // close connection
            m_dbConnection.Close();
        }

        // Adds a record to the AdventureCards table.
        static private void CreateRecord(int ID, string name, string text, int toCombine, int toTrade, string picture)
        {
            SQLiteCommand command;
            string sqOne = $"INSERT into AdventureCards VALUES ({ID},'{name}','{text}',{toCombine},{toTrade},'{picture}',0) ON CONFLICT(ID) DO UPDATE SET Name=excluded.Name;";
            command = new SQLiteCommand(sqOne, m_dbConnection);
            command.ExecuteNonQuery();

        }
        // This function reads a record in order to create the card object specified
        // and adds it to the player inventory in both the table and object.
        static public void CreateCard(ref List<Card> cards, int ID)
        {
            m_dbConnection.Open();
            string sql = "";
            sql = $"SELECT * FROM AdventureCards WHERE ID == {ID} LIMIT 1";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (int.Parse(reader["Taken"].ToString()) == 0)
                {
                    string path = reader["Picture"].ToString();
                    Card newCard = new Card(int.Parse(reader["Combine"].ToString()), int.Parse(reader["Trade"].ToString()), reader["Picture"].ToString(), reader["Text"].ToString(), int.Parse(reader["ID"].ToString()), reader["Name"].ToString());
                    cards.Add(newCard);
                    sql = $"INSERT into POneInventory values({reader["ID"]},'{reader["Name"]}','{reader["Text"]}','{reader["Combine"]}','{reader["Trade"]}','{reader["Picture"]}',0) ON CONFLICT(ID) DO UPDATE SET Name=excluded.Name;";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                    CardRecieved form = new CardRecieved();
                    form.pictureBox1.Image = (Image) (Properties.Resources.ResourceManager.GetObject($"{path}"));
                    form.ShowDialog();
                }
            }
            sql = $"update AdventureCards set Taken = 1 where ID == {ID} limit 1;";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            reader.Close();
            m_dbConnection.Close();
        }
        // This function adds a new player record into the PlayerOne table.
        public static void CreateProfile(string name, int life)
        {
            m_dbConnection.Open();
            string sql = $"INSERT into PlayerOne values ('{name}',{life}) ON CONFLICT(Name) DO UPDATE SET Name=excluded.Name;";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        // This function removes a card from the player inventory table.
        public static void RemoveCard(int id)
        {
            m_dbConnection.Open();
            string sql = $"DELETE from POneInventory where ID == {id}";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        // This function will make changes to the player hp in the Player profile.
        public static void ChangeHP(int hp, string name)
        {
            m_dbConnection.Open();
            MessageBox.Show($"{hp}");
            string sql = $"update PlayerOne set Life = {hp} where Name == '{name}' limit 1;";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
        // This function syncs up the Player details and inventory between the object and the tables.
        public static void CompareDatabase(ref List<Card> inventory, ref int life)
        {
            m_dbConnection.Open();
            List<int> cardIDs = new List<int>();
            string sql = $"SELECT * from POneInventory";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            // if a card is in the table, but not the inventory, then add the card to it.
            while (reader.Read())
            {
                cardIDs.Add(int.Parse(reader["ID"].ToString()));
                if (inventory.FindIndex(p => p.ID == int.Parse(reader["ID"].ToString())) == -1)
                {
                    Card card = new Card(int.Parse(reader["Combine"].ToString()),int.Parse(reader["Trade"].ToString()),reader["Picture"].ToString(),reader["Text"].ToString(), int.Parse(reader["ID"].ToString()),reader["Name"].ToString());
                    inventory.Add(card);
                }
            }
            reader.Close();
            reader.Dispose();
            // If a card is not in the table, but is in the inventory, then remove the card.
            List<Card> list = new List<Card>(inventory);
            foreach (Card id in list)
            {
                if (!cardIDs.Contains(id.ID))
                {
                    inventory.Remove(id);
                }
            }
            inventory = list;

            // Make sure that the hp matches.
            sql = $"SELECT * from PlayerOne";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (life != int.Parse(reader["Life"].ToString()))
                {
                    life = int.Parse(reader["Life"].ToString());
                }
            }
            m_dbConnection.Close();
        }
        // This function adds the card to the table inventory only.
        public static void AddCardToInventory(int ID)
        {
            m_dbConnection.Open();
            string sql = "";
            sql = $"SELECT * FROM AdventureCards WHERE ID == {ID} LIMIT 1";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (int.Parse(reader["Taken"].ToString()) == 0)
                {
                    string path = reader["Picture"].ToString();
                    sql = $"INSERT into POneInventory values({reader["ID"]},'{reader["Name"]}','{reader["Text"]}','{reader["Combine"]}','{reader["Trade"]}','{reader["Picture"]}',0) ON CONFLICT(ID) DO UPDATE SET Name=excluded.Name;";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                    CardRecieved form = new CardRecieved();
                    form.pictureBox1.Image = (Image)(Properties.Resources.ResourceManager.GetObject($"{path}"));
                    form.ShowDialog();
                }
            }
            sql = $"update AdventureCards set Taken = 1 where ID == {ID} limit 1;";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            reader.Close();
            m_dbConnection.Close();
        }
        // This method returns a list of the records in the inventory. It's purpose is to only return the essentials of the card details.
        public static List<string> GetInventory()
        {
            List<string> inventory = new List<string>();

            m_dbConnection.Open();
            string sql = "";
            sql = $"SELECT * FROM POneInventory";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                inventory.Add(reader["ID"].ToString() + " " + reader["Name"].ToString());
            }
            reader.Close();
            m_dbConnection.Close();
            command.Dispose();

            return inventory;

        }
    }
}
