using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        Button prvoKliknuto = null;
        Button drugoKliknuto = null;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InicijalizujIgru();
        }

        private void InicijalizujIgru()
        {
            List<int> brojevi = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };
            List<Button> dugmici = new List<Button> { 
                button1, button2, button3, button4, 
                button5, button6, button7, button8,
                button9, button10, button11, button12 
            };

            foreach (Button btn in dugmici)
            {
                int indeks = rnd.Next(0, brojevi.Count);
                btn.Tag = brojevi[indeks];
                btn.Text = "";
                btn.BackColor = Control.DefaultBackColor;
                btn.Enabled = true;
                brojevi.RemoveAt(indeks);
            }
        }

        private void Dugme_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled) return;

            Button kliknutoDugme = sender as Button;
            if (kliknutoDugme == null) return;
            if (kliknutoDugme.Text != "") return;

            if (prvoKliknuto == null)
            {
                prvoKliknuto = kliknutoDugme;
                prvoKliknuto.Text = prvoKliknuto.Tag.ToString();
                prvoKliknuto.BackColor = Color.Red;
                return;
            }

            drugoKliknuto = kliknutoDugme;
            drugoKliknuto.Text = drugoKliknuto.Tag.ToString();
            drugoKliknuto.BackColor = Color.Red;

            if (prvoKliknuto.Tag.ToString() == drugoKliknuto.Tag.ToString())
            {
                prvoKliknuto = null;
                drugoKliknuto = null;
            }
            else
            {
                timer2.Start();
            }
        }

        private void obrisi()
        {
            if (prvoKliknuto != null)
            {
                prvoKliknuto.Text = "";
                prvoKliknuto.BackColor = Control.DefaultBackColor;
            }
            if (drugoKliknuto != null)
            {
                drugoKliknuto.Text = "";
                drugoKliknuto.BackColor = Control.DefaultBackColor;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            obrisi();
            prvoKliknuto = null;
            drugoKliknuto = null;

            if (timer2.Enabled)
            {
                timer2.Stop();
            }
        }
    }
}