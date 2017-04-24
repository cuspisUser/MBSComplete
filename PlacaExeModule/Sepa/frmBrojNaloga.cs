using System;
using System.Windows.Forms;

namespace Sepa
{
    public partial class frmBrojNaloga : Form
    {
        public frmBrojNaloga()
        {
            InitializeComponent();
        }

        public string brojNaloga;

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            if (txtSifra.Text.Length == 0)
            {
                MessageBox.Show("Niste unjeli redni broj naloga!",
                 "Upozorenje",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
                return;
            }
            brojNaloga = txtSifra.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void txtSifra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnOdustani_Click(null, null);
            }
        }
    }

}