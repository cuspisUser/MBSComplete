using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServisModule.ServisModule.Migracija
{
	public partial class frmLoginServiseri: Form
	{
		public frmLoginServiseri()
		{
			InitializeComponent();
		}

        private void btnOK_Click(object sender, EventArgs e)
        {
            string lozinka = this.txtLozinka.Text.Trim();

            if (!string.IsNullOrWhiteSpace(lozinka))
            {
                if (lozinka == "serviser123")
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Upisana lozinka nije ispravna!", "Lozinka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtLozinka.Clear();
                    this.txtLozinka.Focus();
                }
            }
            else
            {
                MessageBox.Show("Molimo, upišite lozinku!", "Lozinka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
	}
}
