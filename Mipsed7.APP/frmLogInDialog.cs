using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mipsed7.APP
{
    public partial class frmLogInDialog : Form
    {
        public frmLogInDialog()
        {
            InitializeComponent();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            string korisnickoIme = this.txtKorisnickoIme.Text.Trim();
            string lozinka = this.txtLozinka.Text.Trim();

            string sql = string.Format("SELECT COUNT(1) FROM dbo.KORISNIK_SUSTAVA WHERE KORISNICKOIME = '{0}' AND LOZINKA = '{1}' AND DOZVOLIPRIJAVU = 1", 
                korisnickoIme, lozinka);

            // must return "1"
            object result = new Mipsed7.DataAccessLayer.SqlClient().ExecuteScalar(sql);

            if (result.ToString() == "1")
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
            {
                this.txtKorisnickoIme.Focus();
                this.txtKorisnickoIme.SelectAll();

                MessageBox.Show("ODBIJENA PRIJAVA!" + Environment.NewLine + Environment.NewLine + "Korisničko ime ili lozinka nisu ispravni, ili Vam je onemogućena prijava!",
                    "Greška u prijavi", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
