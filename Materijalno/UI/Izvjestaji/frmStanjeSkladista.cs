using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Materijalno.UI.Izvjestaji
{
    public partial class frmStanjeSkladista : Form
    {
        #region svojstva
        public static int pSkladiste
        {
            get;
            set;
        }
        public static int pSort
        {
            get;
            set;
        }
        public static Nullable<DateTime> naDan { get; set; }
     
        #endregion

        public frmStanjeSkladista()
        {
            InitializeComponent();

            NapuniSkladiste();
            cmbSort.SelectedIndex = -1;
        }

        private void NapuniSkladiste()
        {
            BusinessLogic.OtvaranjeSkladista objekt = new BusinessLogic.OtvaranjeSkladista();
            cmbSkladiste.DisplayMember = "Naziv";
            cmbSkladiste.ValueMember = "ID";
            cmbSkladiste.DataSource = objekt.GetSkladista();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            if (cmbSkladiste.DataSource != null)
            {
                naDan = null;             
                pSkladiste = (int)cmbSkladiste.SelectedValue;
                pSort = (int)cmbSort.SelectedIndex;

                if (tcDatum.SelectedTab == tcNaDan)
                {
                    if (udtNaDan.Value != null)
                    {
                        naDan = udtNaDan.DateTime;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        // db - 14.10.2016
                        naDan = DateTime.Now.Date;
                        udtNaDan.Value = DateTime.Now.Date;
                        //MessageBox.Show("Potrebno je odabrati datum za koji se radi izvještaj!");
                        return;
                    }
                }
                else
                {
                    //if (udtRazdobljeDatumOd.Value != null & udtRazdobljeDatumDo.Value != null)
                    //{
                    //    razdobljeDatumOd = udtRazdobljeDatumOd.DateTime;
                    //    razdobljeDatumDo = udtRazdobljeDatumDo.DateTime;
                    //    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Potrebno je datumsko razdoblje za koje se radi izvještaj!");
                    //    return;
                    //}
                }

            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }
    }
}
