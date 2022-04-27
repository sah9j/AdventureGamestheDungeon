using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AdventureGamesTheDungeon
{
    internal static class CreatingForm
    {
        // This method creates a SpecialInteractions form that is used to handle events from
        // Adventure Cards 80-87.
        public static void createCharEventForm(string nameOfPlayer, int health, int ID)
        {
            List<string> names = new List<string>(nameOfPlayer.Split(' '));
            bool isOkoro = names.Contains("Okoro");
            bool isHaruka = names.Contains("Haruka");
            bool isAref = names.Contains("Aref");
            bool isKassandra = names.Contains("Kassandra");
            SpecialInteractions form = new SpecialInteractions(health);
            form.name = nameOfPlayer;
            form.button5.Visible = false;
            form.textBox1.Visible = false;
            switch(ID)
            {
                case 80:
                    form.label1.Text = "When you took your last step, you already had a hunch that the mask was watching you. As you continue your way, an arrow comes from the mouth of the mask. Choose who gets hit:";
                    form.entries.Add(159);
                    form.entries.Add(259);
                    form.entries.Add(359);
                    form.entries.Add(459);
                    break;
                case 81:
                    form.label1.Text = "Monte appears to mean you no harm. Thus, you decide to call the others. Place all characters on Room Card C. As you arrive, his smile widens. \"A rare sight to see this many friendly faces down here! Well, let us see what I can give you... Who will accept his offering?";
                    form.entries.Add(155);
                    form.entries.Add(255);
                    form.entries.Add(355);
                    form.entries.Add(455);
                    break;
                case 82:
                    form.label1.Text = "You show the others what you have found and you gather around the crystal ball. Place all characters on Room Card J. Who will be the first to take a look?";
                    form.entries.Add(157);
                    form.entries.Add(257);
                    form.entries.Add(357);
                    form.entries.Add(457);
                    break;
                case 83:
                    form.label1.Text = "Breathing heavily with suppressed anger, pupils dilated, the hand of the prisoner suddenly reaches forward… Who does he reach for?";
                    form.entries.Add(154);
                    form.entries.Add(254);
                    form.entries.Add(354);
                    form.entries.Add(454);
                    break;
                case 84:
                    form.label1.Text = "The path into the deep is hardly visible. You call the others to discuss further actions. Place all characters on Room Card I. Who dares the descend?";
                    form.entries.Add(153);
                    form.entries.Add(253);
                    form.entries.Add(353);
                    form.entries.Add(453);
                    break;
                case 85:
                    form.label1.Text = "Slowly you realize that this vision is part of your lost memories. It belongs to the time when you were a submissive member of the League of Guardians. At the last moment, you catch a glimpse of what has been… Choose who has this vision:";
                    form.entries.Add(152);
                    form.entries.Add(252);
                    form.entries.Add(352);
                    form.entries.Add(452);
                    break;
                case 86:
                    form.label1.Text = "Bit by bit, your senses are returning. Agonizingly at first, then quicker. But mania will not loosen its grip on you without a fight. You have one last vision… Choose who has the vision:";
                    form.entries.Add(171);
                    form.entries.Add(271);
                    form.entries.Add(371);
                    form.entries.Add(471);
                    break;
                case 87:
                    form.label1.Text = "Something tells you that it is important which one of you talks to her and thus you call the others. Place all characters on Room Card N. Who knows how she will respond…Who will talk to her?";
                    form.entries.Add(161);
                    form.entries.Add(261);
                    form.entries.Add(361);
                    form.entries.Add(461);
                    break;
            }
            if(names.Count == 2)
            {
                if (isOkoro && isHaruka && !isKassandra && !isAref)
                {
                    form.button3.Visible = false;
                    form.label4.Visible = false;
                    form.button4.Visible = false;
                    form.label5.Visible = false;
                }
                else if (isOkoro && !isHaruka && isKassandra && !isAref)
                {
                    form.button2.Visible = false;
                    form.label3.Visible = false;
                    form.button3.Visible = false;
                    form.label4.Visible = false;
                }
                else if (isOkoro && !isHaruka && !isKassandra && isAref)
                {
                    form.button2.Visible = false;
                    form.label3.Visible = false;
                    form.button4.Visible = false;
                    form.label5.Visible = false;
                }
                else if(!isOkoro && isHaruka && isKassandra && !isAref)
                {
                    form.button1.Visible = false;
                    form.label2.Visible = false;
                    form.button3.Visible = false;
                    form.label4.Visible = false;
                }
                else if(!isOkoro && isHaruka && !isKassandra && isAref)
                {
                    form.button1.Visible = false;
                    form.label2.Visible = false;
                    form.button4.Visible = false;
                    form.label5.Visible = false;
                }
                else if(!isOkoro && !isHaruka && isKassandra && isAref)
                {
                    form.button1.Visible = false;
                    form.label2.Visible = false;
                    form.button2.Visible = false;
                    form.label3.Visible = false;
                }
            }
            else if(names.Count == 3)
            {
                if(isOkoro && isHaruka && isKassandra && !isAref)
                {
                    form.button3.Visible = false;
                    form.label4.Visible = false;
                }
                else if(isOkoro && !isHaruka && isKassandra && isAref)
                {
                    form.button2.Visible = false;
                    form.label3.Visible = false;
                }
                else if(isOkoro && isHaruka && !isKassandra && isAref)
                {
                    form.button4.Visible = false;
                    form.label5.Visible = false;
                }
                else if(!isOkoro && isHaruka && isKassandra && isAref)
                {
                    form.button1.Visible = false;
                    form.label2.Visible = false;
                }
            }
            
            form.ShowDialog();

        }
        // This method creates an instance of the SpecialInteractions form can designs it to handle events
        // that ask for the player to input a value.
        public static void EnterEntry(int digits)
        {
            SpecialInteractions form = new SpecialInteractions(0);
            form.digits = digits;
            form.label1.Text = "Enter Your 3-digit code:";
            form.button1.Visible = false;
            form.label2.Visible=false;
            form.button2.Visible = false;
            form.label3.Visible = false;
            form.button3.Visible = false;
            form.label4.Visible=false;
            form.button4.Visible = false;
            form.label5.Visible = false;

            form.Width = 630;
            form.Height = 167;
            form.ShowDialog();
        }
        // This method creates a TradingForm instance to handle events in which the player talks to Edric.
        public static void Trade()
        {
            TradingForm form = new TradingForm();
            form.ShowDialog();
        }
        // This method creates an instance of the SpecialInteractions form and designs it so that the 
        // player can choose between Adventure Cards 70-74.
        public static void ChooseYourCard()
        {
            SpecialInteractions form = new SpecialInteractions(0);

            form.textBox1.Visible=false;
            form.button5.Visible=false;
            form.label1.Text = "Choose One option. If all options are taken, then close the window.";

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT * FROM AdventureCards WHERE ID > 69 AND ID < 74;";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                if (int.Parse(data["ID"].ToString()) == 70 && int.Parse(data["Taken"].ToString()) == 1)
                    form.button1.Enabled = false;
                else if (int.Parse(data["ID"].ToString()) == 71 && int.Parse(data["Taken"].ToString()) == 1)
                    form.button2.Enabled = false;
                else if (int.Parse(data["ID"].ToString()) == 72 && int.Parse(data["Taken"].ToString()) == 1)
                    form.button3.Enabled = false;
                else if (int.Parse(data["ID"].ToString()) == 73 && int.Parse(data["Taken"].ToString()) == 1)
                    form.button4.Enabled = false;
            }
            cmd.Dispose();
            data.Close();

            form.label2.Visible = false;
            form.label3.Visible = false;
            form.label4.Visible = false;
            form.label5.Visible = false;

            form.button1.Text = "70";
            form.button2.Text = "71";
            form.button3.Text = "72";
            form.button4.Text = "73";

            form.choosing = true;
            form.ShowDialog();
        }
    }
}
