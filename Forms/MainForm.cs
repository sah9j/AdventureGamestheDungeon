using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AdventureGamesTheDungeon
{
    // This is the form that the player will see the most.
    public partial class MainForm : Form
    {
        Player player;
        public string name;
        public char locationCurrently;
        public int missionNumber;
        public static MainForm frm;
        public bool edrickAlive = true;
        public bool beastAlive = false;
        public bool endOfGame = false;
        public int Countdown = 4;
        public bool isOpen = false;
        public MainForm(string names)
        {
            player = new Player(names,6);
            name = names;
            frm = this;
            InitializeComponent();
            AdventureCardDatabase.CreateProfile(player.Name,player.Life);
            // For Location A.
            button1.Parent = pictureBox1;
            button2.Parent = pictureBox1;
            button3.Parent = pictureBox1;
            button4.Parent = pictureBox1;
            button5.Parent = pictureBox1;
            button6.Parent = pictureBox1;
            button7.Parent = pictureBox1;
            button8.Parent = pictureBox1;

            extraAction.BringToFront();
            aToolStripMenuItem.PerformClick();
        }
        // This loads in the image of the first selected character. It then starts the introduction.
        private void Form1_Load(object sender, EventArgs e)
        {
            if (name[0] == 'A')
            {
                button9.BackgroundImage = Properties.Resources.Aref;
            }
            else if (name[0] == 'H')
            {
                button9.BackgroundImage = Properties.Resources.Haruka;
            }
            else if (name[0] == 'K')
            {
                button9.BackgroundImage = Properties.Resources.Kassandra;
            }
            else if (name[0] == 'O')
            {
                button9.BackgroundImage = Properties.Resources.Okoro;
            }

            EntryEvaluation.LocEntry(ref player.inventory,ref player.Life,name,id:100);


            // hide locations.
            bToolStripMenuItem.Visible = false;
            cToolStripMenuItem.Visible = false;
            dToolStripMenuItem.Visible = false;
            eToolStripMenuItem.Visible = false;
            fToolStripMenuItem.Visible = false;
            gToolStripMenuItem.Visible = false;
            hToolStripMenuItem.Visible = false;
            iToolStripMenuItem.Visible = false;
            jToolStripMenuItem.Visible = false;
            kToolStripMenuItem.Visible = false;
            lToolStripMenuItem.Visible = false;
            mToolStripMenuItem.Visible = false;
            nToolStripMenuItem.Visible = false;
            oToolStripMenuItem.Visible = false;
            pToolStripMenuItem.Visible = false;
            qToolStripMenuItem.Visible = false;
            rToolStripMenuItem.Visible = false;
            
        }

        // This handles events where the lefthand digit is 1.
        private void button1_Click(object sender, EventArgs e)
        {
            switch (locationCurrently)
            {
                case 'A':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 101);
                    break;
                case 'B':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 110);
                    break;
                case 'C':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 105);
                    break;
                case 'D':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 109);
                    break;
                case 'E':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 107);
                    break;
                case 'F':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 112);
                    break;
                case 'G':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 102);
                    break;
                case 'H':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 104);
                    break;
                case 'J':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 108);
                    break;
                case 'K':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 113);
                    break;
                case 'L':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 110);
                    break;
                case 'M':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 106);
                    break;
                case 'N':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 111);
                    break;
                case 'O':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 114);
                    break;
                case 'P':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 115);
                    break;
                case 'R':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 107);
                    break;
            }
        }
        // This method allows the EntryEvaluations class to be able to open rooms.
        public static void OpenLocation(char loc)
        {
            switch (loc)
            {
                case 'A':
                    frm.aToolStripMenuItem.Visible = true;
                    frm.aToolStripMenuItem.PerformClick();
                    break;
                case 'B':
                    frm.bToolStripMenuItem.Visible = true;
                    frm.bToolStripMenuItem.PerformClick();
                    break;
                case 'C':
                    frm.cToolStripMenuItem.Visible = true;
                    frm.cToolStripMenuItem.PerformClick();
                    break;
                case 'D':
                    frm.dToolStripMenuItem.Visible = true;
                    frm.dToolStripMenuItem.PerformClick();
                    frm.isOpen = true;
                    break;
                case 'E':
                    frm.eToolStripMenuItem.Visible = true;
                    frm.eToolStripMenuItem.PerformClick();
                    break;
                case 'F':
                    frm.fToolStripMenuItem.Visible = true;
                    frm.fToolStripMenuItem.PerformClick();
                    break;
                case 'G':
                    frm.gToolStripMenuItem.Visible = true;
                    frm.gToolStripMenuItem.PerformClick();
                    break;
                case 'H':
                    frm.hToolStripMenuItem.Visible = true;
                    frm.hToolStripMenuItem.PerformClick();
                    break;
                case 'I':
                    frm.iToolStripMenuItem.Visible = true;
                    frm.iToolStripMenuItem.PerformClick();
                    break;
                case 'J':
                    frm.jToolStripMenuItem.Visible = true;
                    frm.jToolStripMenuItem.PerformClick();
                    break;
                case 'K':
                    frm.kToolStripMenuItem.Visible = true;
                    frm.kToolStripMenuItem.PerformClick();
                    break;
                case 'L':
                    frm.lToolStripMenuItem.Visible = true;
                    frm.lToolStripMenuItem.PerformClick();
                    break;
                case 'M':
                    frm.mToolStripMenuItem.Visible = true;
                    frm.mToolStripMenuItem.PerformClick();
                    break;
                case 'N':
                    frm.nToolStripMenuItem.Visible = true;
                    frm.nToolStripMenuItem.PerformClick();
                    break;
                case 'O':
                    frm.oToolStripMenuItem.Visible = true;
                    frm.oToolStripMenuItem.PerformClick();
                    break;
                case 'P':
                    frm.pToolStripMenuItem.Visible = true;
                    frm.pToolStripMenuItem.PerformClick();
                    break;
                case 'Q':
                    frm.qToolStripMenuItem.Visible = true;
                    frm.qToolStripMenuItem.PerformClick();
                    break;
                case 'R':
                    frm.rToolStripMenuItem.Visible = true;
                    frm.rToolStripMenuItem.PerformClick();
                    break;
                default:
                    MessageBox.Show("Invalid location ID");
                    break;
            }
        }

        // This method allows the EntryEvaluations class to be able to block rooms.
        public static void BlockLocation(char loc)
        {
            switch (loc)
            {
                case 'A':
                    frm.aToolStripMenuItem.Visible = false;
                    break;
                case 'B':
                    frm.bToolStripMenuItem.Visible = false;
                    break;
                case 'C':
                    frm.cToolStripMenuItem.Visible = false;
                    break;
                case 'D':
                    frm.dToolStripMenuItem.Visible = false;
                    break;
                case 'E':
                    frm.eToolStripMenuItem.Visible = false;
                    break;
                case 'F':
                    frm.fToolStripMenuItem.Visible = false;
                    break;
                case 'G':
                    frm.gToolStripMenuItem.Visible = false;
                    break;
                case 'H':
                    frm.hToolStripMenuItem.Visible = false;
                    break;
                case 'I':
                    frm.iToolStripMenuItem.Visible = false;
                    break;
                case 'J':
                    frm.jToolStripMenuItem.Visible = false;
                    break;
                case 'K':
                    frm.kToolStripMenuItem.Visible = false;
                    break;
                case 'L':
                    frm.lToolStripMenuItem.Visible = false;
                    break;
                case 'M':
                    frm.mToolStripMenuItem.Visible = false;
                    break;
                case 'N':
                    frm.nToolStripMenuItem.Visible = false;
                    break;
                case 'O':
                    frm.oToolStripMenuItem.Visible = false;
                    break;
                case 'P':
                    frm.pToolStripMenuItem.Visible = false;
                    break;
                case 'Q':
                    frm.qToolStripMenuItem.Visible = false;
                    break;
                case 'R':
                    frm.rToolStripMenuItem.Visible = false;
                    break;
                default:
                    MessageBox.Show("Invalid location ID");
                    break;
            }
        }

        // This event holds a menu from which the player can select from.
        private void button9_Click(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(button9, new Point(0,-3 * button9.Height + 10));
        }
        
        // opens room A.
        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.A;
            button1.Location = new Point(395, 172);
            button2.Location = new Point(410, 117);
            button3.Location = new Point(305, 161);
            button4.Location = new Point(281, 277);
            button5.Location = new Point(219, 172);
            button6.Location = new Point(83, 252);
            button7.Location = new Point(74, 183);
            button8.Location = new Point(83, 135);

            if(button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button4.Visible == false)
                button4.Visible = true;
            if (button5.Visible == false)
                button5.Visible = true;
            if (button6.Visible == false)
                button6.Visible = true;
            if (button7.Visible == false)
                button7.Visible = true;
            if (button8.Visible == false)
                button8.Visible = true;
            extraAction.Visible = false;
            ExtraCharacter.Visible = false;

            locationCurrently = 'A';
        }

        // This handles events where the lefthand digit is 2.
        private void button2_Click(object sender, EventArgs e)
        {
            switch (locationCurrently)
            {
                case 'A':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 201);
                    break;
                case 'B':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 210);
                    break;
                case 'C':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 205);
                    break;
                case 'D':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 209);
                    break;
                case 'E':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 207);
                    break;
                case 'F':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 212);
                    break;
                case 'G':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 202);
                    break;
                case 'H':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 204);
                    break;
                case 'I':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 203);
                    break;
                case 'J':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 208);
                    break;
                case 'K':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 213);
                    break;
                case 'L':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 210);
                    break;
                case 'M':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 206);
                    break;
                case 'N':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 211);
                    break;
                case 'O':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 214);
                    break;
                case 'P':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 215);
                    break;
                case 'R':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 207);
                    break;
            }
        }

        // opens room C.
        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.C;
            button1.Location = new Point(83, 190);
            button2.Location = new Point(373, 190);
            button3.Location = new Point(184, 190);
            button4.Location = new Point(288, 141);
            button5.Location = new Point(171, 289);
            button6.Location = new Point(251, 289);
            button7.Location = new Point(331, 289);
            button8.Location = new Point(437, 165);

            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button4.Visible == false)
                button4.Visible = true;
            if (button5.Visible == false)
                button5.Visible = true;
            if (button6.Visible == false)
                button6.Visible = true;
            if (button7.Visible == false)
                button7.Visible = true;
            if (button8.Visible == false)
                button8.Visible = true;
            extraAction.Visible = false;
            ExtraCharacter.Visible = false;
            locationCurrently = 'C';
        }

        // opens room D.
        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.D;
            button1.Location = new Point(238, 190);
            button2.Location = new Point(125, 217);
            button3.Location = new Point(371, 206);
            button4.Location = new Point(316, 260);
            button5.Location = new Point(88, 69);
            button6.Location = new Point(30, 217);

            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button4.Visible == false)
                button4.Visible = true;
            if (button5.Visible == false)
                button5.Visible = true;
            if (button6.Visible == false)
                button6.Visible = true;
            button7.Visible = false;
            button8.Visible = false;
            extraAction.Visible = false;
            ExtraCharacter.Visible = false;
            locationCurrently = 'D';
        }

        // opens room E.
        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.E;
            button1.Location = new Point(107, 221);
            button2.Location = new Point(31, 240);
            button3.Location = new Point(109, 146);
            button5.Location = new Point(381, 221);
            button6.Location = new Point(31, 48);
            button7.Location = new Point(437, 147);


            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button5.Visible == false)
                button5.Visible = true;
            if (button6.Visible == false)
                button6.Visible = true;
            if (button7.Visible == false)
                button7.Visible = true;
            button4.Visible = false;
            button8.Visible = false;
            if(edrickAlive)
            {
                ExtraCharacter.Image = Properties.Resources._90;
                extraAction.Visible = true;
                extraAction.Image = Properties.Resources.edricnum;
                ExtraCharacter.Visible = true;
            }
            locationCurrently = 'E';
        }

        // opens room B.
        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.B;
            button1.Location = new Point(82, 254);
            button2.Location = new Point(109, 186);
            button3.Location = new Point(254, 109);
            button5.Location = new Point(413, 120);

            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button5.Visible == false)
                button5.Visible = true;
            button6.Visible=false;
            button7.Visible=false;
            button4.Visible = false;
            button8.Visible = false;
            extraAction.Visible = false;
            ExtraCharacter.Visible = false;

            locationCurrently = 'B';
        }

        // Opens room F.
        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.F;
            button1.Location = new Point(31, 157);
            button2.Location = new Point(226, 210);
            button3.Location = new Point(432, 210);

            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            button4.Visible = false;
            button5.Visible=false;
            button6.Visible = false;
            button7.Visible=false;
            button8.Visible=false;
            extraAction.Visible = false;
            ExtraCharacter.Visible = false;
            if(endOfGame)
            {
                ExtraCharacter.Image = Properties.Resources._66;
                ExtraCharacter.Visible = true;
                extraAction.Visible = true;
                extraAction.Image = Properties.Resources.Berengar;
            }
            locationCurrently = 'F';
        }

        // Opens Room G.
        private void gToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.G;
            button1.Location = new Point(320, 173);
            button2.Location = new Point(209, 131);
            button3.Location = new Point(51, 93);
            button4.Location = new Point(68, 214);
            button5.Location = new Point(425, 188);
            button6.Location = new Point(94, 277);
            button7.Location = new Point(51, 173);
            button8.Location = new Point(58, 23);

            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button4.Visible == false)
                button4.Visible = true;
            if (button5.Visible == false)
                button5.Visible = true;
            if (button6.Visible == false)
                button6.Visible = true;
            if (button7.Visible == false)
                button7.Visible = true;
            if (button8.Visible == false)
                button8.Visible = true;

            extraAction.Visible = false;
            ExtraCharacter.Visible = false;

            locationCurrently = 'G';
        }

        // Opens room H.
        private void hToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.H;
            button1.Location = new Point(158, 93);
            button2.Location = new Point(250, 129);
            button3.Location = new Point(320, 138);
            button4.Location = new Point(425, 138);
            button5.Location = new Point(177, 276);

            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button4.Visible == false)
                button4.Visible = true;
            if (button5.Visible == false)
                button5.Visible = true;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible=false;
            extraAction.Visible = false;
            ExtraCharacter.Visible = false;

            locationCurrently = 'H';
        }

        // Opens room I
        private void iToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.I;
            button2.Location = new Point(194, 248);
            button3.Location = new Point(110, 221);
            button4.Location = new Point(162, 192);
            button5.Location = new Point(162, 77);

            
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button4.Visible == false)
                button4.Visible = true;
            if (button5.Visible == false)
                button5.Visible = true;
            button1.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            extraAction.Visible = false;
            ExtraCharacter.Visible = false;

            locationCurrently = 'I';
        }

        // opens room J.
        private void jToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.J;
            button1.Location = new Point(407, 191);
            button2.Location = new Point(250, 221);
            button3.Location = new Point(389, 129);
            button4.Location = new Point(56, 263);
            button5.Location = new Point(95, 120);
            button6.Location = new Point(37, 205);

            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button4.Visible == false)
                button4.Visible = true;
            if (button5.Visible == false)
                button5.Visible = true;
            if (button6.Visible == false)
                button6.Visible = true;
            button7.Visible = false;
            button8.Visible = false;
            extraAction.Visible = false;
            ExtraCharacter.Visible = false;

            locationCurrently = 'J';
        }

        // opens room K.
        private void kToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.K;
            button1.Location = new Point(241, 138);
            button2.Location = new Point(214, 29);
            button3.Location = new Point(155, 162);

            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;

            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            extraAction.Visible = false;
            if(beastAlive)
            {
                ExtraCharacter.Image = Properties.Resources._55;
                ExtraCharacter.Visible = true;
            }
            else
            {
                ExtraCharacter.Visible=false;
            }

            locationCurrently = 'K';
        }

        // opens room L.
        private void lToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.L;
            button1.Location = new Point(78, 253);
            button2.Location = new Point(102, 191);
            button3.Location = new Point(266, 108);
            button4.Location = new Point(372, 219);

            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button4.Visible == false)
                button4.Visible = true;
            extraAction.Visible = false;
            ExtraCharacter.Visible = false;

            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;

            locationCurrently = 'L';
        }

        // opens room M.
        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.M;
            button1.Location = new Point(12, 71);
            button2.Location = new Point(12, 100);
            button3.Location = new Point(0, 119);
            button4.Location = new Point(54, 190);
            button5.Location = new Point(211, 204);
            button6.Location = new Point(162, 100);
            button7.Location = new Point(63, 277);

            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button4.Visible == false)
                button4.Visible = true;
            if (button5.Visible == false)
                button5.Visible = true;
            if (button6.Visible == false)
                button6.Visible = true;
            if (button7.Visible == false)
                button7.Visible = true;

            button8.Visible = false;

            locationCurrently = 'M';
            extraAction.Visible = false;
            ExtraCharacter.Visible = false;
        }

        // Opens room N.
        private void nToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.N;
            button1.Location = new Point(75, 248);
            button2.Location = new Point(285, 119);
            button3.Location = new Point(386, 119);
            button4.Location = new Point(405, 181);
            button5.Location = new Point(365, 234);
            button6.Location = new Point(386, 277);
            button7.Location = new Point(183, 181);

            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button4.Visible == false)
                button4.Visible = true;
            if (button5.Visible == false)
                button5.Visible = true;
            if (button6.Visible == false)
                button6.Visible = true;
            if (button7.Visible == false)
                button7.Visible = true;
            extraAction.Visible = false;
            ExtraCharacter.Visible = false;
            button8.Visible = false;

            locationCurrently = 'N';
        }

        // opens room O.
        private void oToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.O;
            button1.Location = new Point(268, 12);
            button2.Location = new Point(245, 143);
            button3.Location = new Point(425, 133);
            button4.Location = new Point(437, 252);

            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button4.Visible == false)
                button4.Visible = true;
            extraAction.Visible = false;
            ExtraCharacter.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;

            locationCurrently = 'O';
        }

        // This handles events where the lefthand digit is 3.
        private void button3_Click(object sender, EventArgs e)
        {
            switch(locationCurrently)
            {
                case 'A':
                    EntryEvaluation.LocEntry(ref player.inventory,ref player.Life, player.Name,id:301);
                    break;
                case 'B':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 310);
                    break;
                case 'C':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 305);
                    break;
                case 'D':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 309);
                    break;
                case 'E':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 307);
                    break;
                case 'F':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 312);
                    break;
                case 'G':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 302);
                    break;
                case 'H':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 304);
                    break;
                case 'I':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 303);
                    break;
                case 'J':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 308);
                    break;
                case 'K':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 313);
                    break;
                case 'L':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 310);
                    break;
                case 'M':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 306);
                    break;
                case 'N':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 311);
                    break;
                case 'O':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 314);
                    break;
                case 'P':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 315);
                    break;
                case 'Q':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 309);
                    break;
                case 'R':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 307);
                    break;
            }
        }

        // opens room P.
        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.P;
            button1.Location = new Point(52, 104);
            button2.Location = new Point(126, 93);
            button3.Location = new Point(280, 93);
            button4.Location = new Point(255, 166);
            button5.Location = new Point(170, 227);

            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button4.Visible == false)
                button4.Visible = true;
            if (button5.Visible == false)
                button5.Visible = true;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            extraAction.Visible = false;
            ExtraCharacter.Visible = false;

            locationCurrently = 'P';
        }

        // opens room Q.
        private void qToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.Q;
            button3.Location = new Point(369, 205);
            button4.Location = new Point(315, 271);
            button5.Location = new Point(77, 70);
            button6.Location = new Point(28, 219);
            button7.Location = new Point(237, 184);
            button8.Location = new Point(127, 219);

            if (button3.Visible == false)
                button3.Visible = true;
            if (button4.Visible == false)
                button4.Visible = true;
            if (button5.Visible == false)
                button5.Visible = true;
            if (button6.Visible == false)
                button6.Visible = true;
            if (button7.Visible == false)
                button7.Visible = true;
            if (button8.Visible == false)
                button8.Visible = true;
            extraAction.Visible = false;
            ExtraCharacter.Visible = false;
            button1.Visible = false;
            button2.Visible = false;

            locationCurrently = 'Q';
        }

        // Opens room R.
        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.R;
            button1.Location = new Point(117, 212);
            button2.Location = new Point(33, 226);
            button3.Location = new Point(117, 136);
            button5.Location = new Point(379, 212);
            button6.Location = new Point(33, 44);
            button8.Location = new Point(437, 136);

            if (button1.Visible == false)
                button1.Visible = true;
            if (button2.Visible == false)
                button2.Visible = true;
            if (button3.Visible == false)
                button3.Visible = true;
            if (button5.Visible == false)
                button5.Visible = true;
            if (button6.Visible == false)
                button6.Visible = true;
            if (button8.Visible == false)
                button8.Visible = true;

            button4.Visible = false;
            button7.Visible = false;
            if (edrickAlive)
            {
                extraAction.Visible = true;
                ExtraCharacter.Visible = true;
            }
            else
            {
                extraAction.Visible = false;
                ExtraCharacter.Visible = false;
            }

            locationCurrently = 'R';
        }

        // Allows the user to see how much health points that they have remaining.
        private void healthPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"You have {player.Life} health points remaining...");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // This creates an instance of the ItemLocation form in order to evaluate any chosen 
        // item/location ID combination.
        private void combineAnItemWithALocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemAndLocation form = new ItemAndLocation(locationCurrently,player.inventory);
            form.ShowDialog();
            AdventureCardDatabase.CompareDatabase(ref player.inventory,ref player.Life);
        }

        // Allows the player to view their current mission card.
        private void currentMissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch(missionNumber)
            {
                case 1:
                    CardRecieved mOne = new CardRecieved();
                    mOne.pictureBox1.Image = Properties.Resources.MissionA1;
                    mOne.ShowDialog();
                    break;
                case 2:
                    CardRecieved form = new CardRecieved();
                    form.pictureBox1.Image = Properties.Resources.MissionA2;
                    form.ShowDialog();
                    break;
                case 3:
                    CardRecieved card = new CardRecieved();
                    card.pictureBox1.Image = Properties.Resources.MissionA3;
                    card.ShowDialog();
                    break;
            }
        }

        // Creates an instance of the Inventory form and then syncs up the player inventory and the 
        // AdventureCardDatabase table inventory.
        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory form = new Inventory(player.Name,player.inventory,player.Life);
            form.ShowDialog();
            AdventureCardDatabase.CompareDatabase(ref player.inventory,ref player.Life);
        }

        // This handles events where the lefthand digit is 6.
        private void button6_Click(object sender, EventArgs e)
        {
            switch (locationCurrently)
            {
                case 'A':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 601);
                    break;
                case 'C':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 605);
                    break;
                case 'D':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 609);
                    break;
                case 'E':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 607);
                    break;
                case 'G':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 602);
                    break;
                case 'J':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 608);
                    break;
                case 'M':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 606);
                    break;
                case 'N':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 611);
                    break;
                case 'Q':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 609);
                    break;
                case 'R':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 607);
                    break;
            }
        }

        // player must face Berengar once 4 turns have elapsed since he appeared on bridge.
        public void CountDownFinished()
        {
            MessageBox.Show("It has been four turns. You must face Berengar Now.");
            EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 500);
        }

        // If Berengar is on Room Card F, then evaluate entry 500, if the player wants.
        // Otherwise evaluate entry 407.
        private void extraAction_Click(object sender, EventArgs e)
        {
            DialogResult result;
            if (endOfGame)
            {
                result = MessageBox.Show("Are you sure you want to skip the countdown and face Berengar now?", "Continue?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 500);
            }
            else
                EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id:407);
        }

        // This handles events where the lefthand digit is 4.
        private void button4_Click(object sender, EventArgs e)
        {
            switch (locationCurrently)
            {
                case 'A':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 401);
                    break;
                case 'C':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 405);
                    break;
                case 'D':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 409);
                    break;
                case 'G':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 402);
                    break;
                case 'H':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 404);
                    break;
                case 'I':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 403);
                    break;
                case 'J':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 408);
                    break;
                case 'L':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 410);
                    break;
                case 'M':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 406);
                    break;
                case 'N':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 411);
                    break;
                case 'O':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 414);
                    break;
                case 'P':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 415);
                    break;
                case 'Q':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 409);
                    break;
            }
        }

        // This handles events where the lefthand digit is 5.
        private void button5_Click(object sender, EventArgs e)
        {
            switch (locationCurrently)
            {
                case 'A':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 501);
                    break;
                case 'B':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 510);
                    break;
                case 'C':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 505);
                    break;
                case 'D':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 509);
                    break;
                case 'E':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 507);
                    break;
                case 'G':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 502);
                    break;
                case 'H':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 504);
                    break;
                case 'I':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 503);
                    break;
                case 'J':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 508);
                    break;
                case 'M':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 506);
                    break;
                case 'N':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 511);
                    break;
                case 'P':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 515);
                    break;
                case 'Q':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 509);
                    break;
                case 'R':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 507);
                    break;
            }
        }

        // This handles events where the lefthand digit is 8.
        private void button8_Click(object sender, EventArgs e)
        {
            switch (locationCurrently)
            {
                case 'A':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 801);
                    break;
                case 'C':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 805);
                    break;
                case 'G':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 802);
                    break;
                case 'Q':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 809);
                    break;
                case 'R':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 807);
                    break;
            }
        }

        // This creates a CombineItems form and then syncs up the player inventory and the POneInventory
        // together.
        private void combineItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CombineItems form = new CombineItems(player.Name,player.inventory);
            form.ShowDialog();
            AdventureCardDatabase.CompareDatabase(ref player.inventory, ref player.Life);
        }

        // This handles events where the lefthand digit is 7.
        private void button7_Click(object sender, EventArgs e)
        {
            switch (locationCurrently)
            {
                case 'A':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 701);
                    break;
                case 'C':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 705);
                    break;
                case 'E':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 707);
                    break;
                case 'G':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 702);
                    break;
                case 'M':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 706);
                    break;
                case 'N':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 711);
                    break;
                case 'Q':
                    EntryEvaluation.LocEntry(ref player.inventory, ref player.Life, player.Name, id: 709);
                    break;
            }
        }
    }
}
