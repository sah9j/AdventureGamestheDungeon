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
    // player selects characters
    public partial class Character_Select : Form
    {
        List<string> name = new List<string>();
        int charCount;
        public Character_Select()
        {
            InitializeComponent();

            this.Focus();

            // Hides check boxes at start when selecting first character
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;

            // Back button hide
            BackButton.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Aref button
        private void button1_Click(object sender, EventArgs e)
        {
            // Additional characters text
            label1.Visible = false;
            label2.Visible = true;

            // Back & OK button
            BackButton.Visible = true;
            ConfirmButton.Visible = true;

            name.Add("Aref");

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;

            checkBox2.Visible = true;
            checkBox3.Visible = true;
            checkBox4.Visible = true;

        }

        // Haruka button
        private void button2_Click(object sender, EventArgs e)
        {
            // Additional characters text
            label1.Visible = false;
            label2.Visible = true;

            // Back & OK button
            BackButton.Visible = true;
            ConfirmButton.Visible = true;

            name.Add("Haruka");

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;

            checkBox1.Visible = true;
            checkBox3.Visible = true;
            checkBox4.Visible = true;
        }

        // Kassandra Button
        private void button3_Click(object sender, EventArgs e)
        {
            // Additional characters text
            label1.Visible = false;
            label2.Visible = true;

            // Back & OK button
            BackButton.Visible = true;
            ConfirmButton.Visible = true;

            name.Add("Kassandra");

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;

            checkBox1.Visible = true;
            checkBox2.Visible = true;
            checkBox4.Visible = true;
        }

        // Okoro Button
        private void button4_Click(object sender, EventArgs e)
        {
            // Additional characters text
            label1.Visible = false;
            label2.Visible = true;

            // Back & OK button
            BackButton.Visible = true;
            ConfirmButton.Visible = true;

            name.Add("Okoro");

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;

            checkBox1.Visible = true;
            checkBox2.Visible = true;
            checkBox3.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                charCount++;
                name.Add(" Aref");
            }
            else
            {
                charCount--;
                name.Remove(" Aref");
            }

            if (charCount >= 1)
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                charCount++;
                name.Add(" Haruka");
            }
            else
            {
                charCount--;
                name.Remove(" Haruka");
            }

            if (charCount >= 1)
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
            }
        }


        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                charCount++;
                name.Add(" Kassandra");
            }
            else
            {
                charCount--;
                name.Remove(" Kassandra");
            }

            if (charCount >= 1)
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
            }
        }   

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                charCount++;
                name.Add(" Okoro");
            }
            else
            {
                charCount--;
                name.Remove(" Okoro");

            }

            if (charCount >= 1)
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
            }
        }

        // return to initial state.
        private void BackButton_Click(object sender, EventArgs e)
        {
            // Select a Character text
            label1.Visible = true;
            label2.Visible = false;

            // Back & OK button
            BackButton.Visible = false;
            ConfirmButton.Visible = false;

            // Checkboxes disabled and unchecked
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;


            // Reverts back to initial selection
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;

        }

        // when names have been chosen
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            string names = "";
            foreach(string n in name)
            {
                names += n;
            }
            this.Hide();
            MainForm form = new MainForm(names);
            form.Show();
            form.Closed += (s, args) => this.Close();
                
        }

        
        private void Character_Select_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }

       
        private void Character_Select_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
