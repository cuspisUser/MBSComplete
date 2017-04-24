using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UcenickoFakturiranje.UI.Izvjestaji
{
    public partial class frmOtvoreneStavke : Form
    {
        #region svojstva
        public static DateTime pDoDatuma
        {
            get;
            set;
        }
        public static int pUstanova
        {
            get;
            set;
        }
        public static int pRazred
        {
            get;
            set;
        }
        #endregion

        public frmOtvoreneStavke()
        {
            InitializeComponent();

            dtpDoDatuma.Value = DateTime.Now;
            NapuniUstanove();
        }

        private void NapuniUstanove()
        {
            BusinessLogic.Ustanove ustanove = new BusinessLogic.Ustanove();
            cmbUstanova.DisplayMember = "Naziv";
            cmbUstanova.ValueMember = "ID";
            cmbUstanova.DataSource = ustanove.GetUstanoveComboBox();
        }

        private void NapuniRazredOdjeljenje(int id_ustanova)
        {
            BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenja razredna_odjeljenja = new BusinessLogic.UstanoveSkolskeGodineRazrednaOdjeljenja();
            cmbRazred.DisplayMember = "Naziv";
            cmbRazred.ValueMember = "ID";
            cmbRazred.DataSource = razredna_odjeljenja.GetRazrednaOdjeljenjaByUstanova(id_ustanova);
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            if (cmbUstanova.DataSource != null & cmbRazred.DataSource != null)
            {
                pDoDatuma = dtpDoDatuma.Value;
                pUstanova = (int)cmbUstanova.SelectedValue;
                pRazred = (int)cmbRazred.SelectedValue;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void cmbUstanova_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUstanova.SelectedValue != null)
            {
                NapuniRazredOdjeljenje((int)cmbUstanova.SelectedValue);
            }
        }
    }
}
