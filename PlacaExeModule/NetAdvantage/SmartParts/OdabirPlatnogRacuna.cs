using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetAdvantage.SmartParts
{
    public partial class JOPPDBroj : Form
    {
        public JOPPDBroj()
        {
            InitializeComponent();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            Virmani.vrsta_izvjesca = txtOznakaIzvjesca.Text;

            if (Virmani.vrsta_izvjesca.Length == 0)
            {
                MessageBox.Show("Oznaka JOPPD-a je obavezna!!!\n\rUnesite oznaku JOPPD-a.");
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

    }
}
