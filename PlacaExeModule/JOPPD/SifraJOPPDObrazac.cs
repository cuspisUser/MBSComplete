using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JOPPD
{
	public partial class SifraJOPPDObrazac: Form
	{
        NetAdvantage.WorkItems.VirmaniWorkItemUser user2;

		public SifraJOPPDObrazac(NetAdvantage.WorkItems.VirmaniWorkItemUser user)
		{
			InitializeComponent();

             user2= user;
		}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbkIsprazni.Checked)
                NetAdvantage.WorkItems.VirmaniWorkItemUser.isprazni_model = true;
            else
                NetAdvantage.WorkItems.VirmaniWorkItemUser.isprazni_model = false;

            NetAdvantage.WorkItems.VirmaniWorkItemUser.oznaka_izvjesca = txtOznakaIzvjesca.Text.Trim();
            NetAdvantage.WorkItems.VirmaniWorkItemUser.kontorla_potvde = true;

            if (cbkInvalid.Checked)
            {
                NetAdvantage.WorkItems.VirmaniWorkItemUser.invalid = true;
            }
            else 
            {
                NetAdvantage.WorkItems.VirmaniWorkItemUser.invalid = false;
            }

            this.Close();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            if (cbkIsprazni.Checked)
                NetAdvantage.WorkItems.VirmaniWorkItemUser.isprazni_model = true;
            else
                NetAdvantage.WorkItems.VirmaniWorkItemUser.isprazni_model = false;

            if (cbkInvalid.Checked)
            {
                NetAdvantage.WorkItems.VirmaniWorkItemUser.invalid = true;
            }
            else
            {
                NetAdvantage.WorkItems.VirmaniWorkItemUser.invalid = false;
            }

            NetAdvantage.WorkItems.VirmaniWorkItemUser.oznaka_izvjesca = "";
            NetAdvantage.WorkItems.VirmaniWorkItemUser.kontorla_potvde = false;
            this.Close();
        }

        private void SifraJOPPDObrazac_FormClosing(object sender, FormClosingEventArgs e)
        {
            user2.Show(user2.Workspaces["main"]);
        }

	}
}
