using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZadatakMovinglabel
{
    public partial class Form1 : Form
    {
        private char[,] polja = new char[3, 3];
        private int rezultatIgrac1 = 0;
        private int rezultatIgrac2 = 0;
        private bool igrac1NaPotezu = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button dugme = (Button)sender;

            if (dugme.Text == "")
            {
                if (igrac1NaPotezu)
                {
                    dugme.Text = "X";
                    igrac1NaPotezu = false;
                }
                else
                {
                    dugme.Text = "O";
                    igrac1NaPotezu = true;
                }
            }
            if (ProveriPobednika('X'))
            {
                MessageBox.Show("Igrač 1 je pobedio!");
                rezultatIgrac1++;
                lblScore.Text = $"Rezultat: Igrač 1 - {rezultatIgrac1}, Igrač 2 - {rezultatIgrac2}";
                ResetujIgru();
                return;
            }
            else if (ProveriPobednika('O'))
            {
                MessageBox.Show("Igrač 2 je pobedio!");
                rezultatIgrac2++;
                lblScore.Text = $"Rezultat: Igrač 1 - {rezultatIgrac1}, Igrač 2 - {rezultatIgrac2}";
                ResetujIgru();
                return;
            }
        }

            private bool ProveriPobednika(char igrac)
            {
                // Proveri horizontalne linije
                for (int i = 0; i < 3; i++)
                {
                    if (polja[i, 0] == igrac && polja[i, 1] == igrac && polja[i, 2] == igrac)
                        return true;
                }

                // Proveri vertikalne linije
                for (int j = 0; j < 3; j++)
                {
                    if (polja[0, j] == igrac && polja[1, j] == igrac && polja[2, j] == igrac)
                        return true;
                }

                // Proveri dijagonalne linije
                if (polja[0, 0] == igrac && polja[1, 1] == igrac && polja[2, 2] == igrac)
                    return true;

                if (polja[2, 0] == igrac && polja[1, 1] == igrac && polja[0, 2] == igrac)
                    return true;

                return false;
            }

        private void ResetujIgru()
        {
            // Resetuj polja
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    polja[i, j] = ' ';
                }
            }
            // Resetuj dugmad
            foreach (Button button in Controls.OfType<Button>())
            {
                button.Text = string.Empty;
                button.Enabled = true;
            }
        }
    }
}