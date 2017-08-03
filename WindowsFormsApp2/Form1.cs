using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        bool potez = true;
        int brojacPoteza = 0;
        string ime1;
        string ime2;
       
        public Form1(string ime1,string ime2)
        {
            this.ime1 = ime1;
            this.ime2 = ime2;
            InitializeComponent();
            label1.Text = ime1;
            label2.Text = ime2;
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kreirao Dusan Milenkovic","IKS OKS");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            
            Button b = (Button)sender;
            if (potez)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            potez = !potez;
            b.Enabled = false;
            brojacPoteza++;
            imaLiPobednika();
        }

        private void imaLiPobednika()
        {
            bool pobednik = false;
            //horizontalno
            if ((a1.Text==a2.Text)&&(a2.Text==a3.Text) && (!a1.Enabled))
                pobednik = true;
            else if ((b1.Text == b2.Text) && (b2.Text == b3.Text) && (!b1.Enabled))
                pobednik = true;
            else if ((c1.Text == c2.Text) && (c2.Text == c3.Text) && (!c1.Enabled))
                pobednik = true;
            //vertikalno
            else if ((a1.Text == b1.Text) && (b1.Text == c1.Text) && (!a1.Enabled))
                pobednik = true;
            else if ((a2.Text == b2.Text) && (b2.Text == c2.Text) && (!a2.Enabled))
                pobednik = true;
            else if ((a3.Text == b3.Text) && (b3.Text == c3.Text) && (!a3.Enabled))
                pobednik = true;
            //dijagonale
            else if ((a1.Text == b2.Text) && (b2.Text == c3.Text) && (!a1.Enabled))
                pobednik = true;
            else if ((a3.Text == b2.Text) && (b2.Text == c1.Text) && (!a3.Enabled))
                pobednik = true;

            if (pobednik)
            {
                
                string winner = "";
                if (potez)
                {
                    winner = "0";
                    o_win_count.Text = (Convert.ToInt32(o_win_count.Text)+1).ToString();
                    MessageBox.Show(ime2 + " je pobednik!", "Pobednik je");
                }
                else
                {
                    winner = "X";
                    x_win_count.Text = (Convert.ToInt32(x_win_count.Text) + 1).ToString();
                    MessageBox.Show(ime1 + " je pobednik!", "Pobednik je");
                }
                disableButtons();
            }
            else
            {
                if (brojacPoteza==9)
                {
                    draw_count.Text = (Convert.ToInt32(draw_count.Text) + 1).ToString();
                    MessageBox.Show("Nema Pobednika!","Nereseno");
                }
            }
        }
        public void disableButtons()
        {
           
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = false;
                    }
                    catch { }
                }
           
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            potez = true;
            brojacPoteza = 0;
            
                foreach (Control c in Controls)
                {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
                }
           
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_win_count.Text = 0.ToString();
            o_win_count.Text = 0.ToString();
            draw_count.Text = 0.ToString();

        }

        
    }
}
