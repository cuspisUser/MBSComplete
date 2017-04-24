using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Materijalno.UI.Skladista
{
    public partial class frmSkladiste : Form
    {
        #region svojstva
        public static Nullable <int> pSkladiste { get; set; }

        #endregion

        public frmSkladiste()
        {
            InitializeComponent();

            NapuniSkladiste();
        }

        private void NapuniSkladiste()
        {
            BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod();
            cmbSkladiste.DisplayMember = "Naziv";
            cmbSkladiste.ValueMember = "ID";

            DataTable skladista = objekt.GetSkladiste();

            cmbSkladiste.DataSource = skladista;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            if ((int)cmbSkladiste.SelectedValue != -1)
            {
                pSkladiste = (int)cmbSkladiste.SelectedValue;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                pSkladiste = null;
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }
    }
}
