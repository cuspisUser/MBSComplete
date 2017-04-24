using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinPosModule.GK
{
    public partial class frmIspisDokumenta : Form
    {
        public frmIspisDokumenta()
        {
            InitializeComponent();
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            if (uneOd.Value != null && uneDo.Value != null)
            {
                GKSmartPart.pocetna_temeljnica = (int)uneOd.Value;
                GKSmartPart.zavrsna_temeljnica = (int)uneDo.Value;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
