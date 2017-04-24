using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//db - 06.12.2016
namespace Materijalno.UI.Izvjestaji
{
    public partial class frmInventurnaLista : Form
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

        public static bool prikazatiKolicinu;

        public bool PrikazatiKolicinu
        {
            get { return prikazatiKolicinu; }
            set { prikazatiKolicinu = value; }
        }


        #endregion
        public frmInventurnaLista()
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
        private void frmInventurnaLista_Load(object sender, EventArgs e)
        {

        }

        private void btnOdustani_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnIspis_Click(object sender, System.EventArgs e)
        {
            if (cmbSkladiste.DataSource != null)
            {
                naDan = null;
                pSkladiste = (int)cmbSkladiste.SelectedValue;
                pSort = (int)cmbSort.SelectedIndex;

                //db - 16.1.2017
                if (ckbKolicina.Checked == true)
                {
                    prikazatiKolicinu = true;
                }
                else
                {
                    prikazatiKolicinu = false;
                }

                if (tcDatum.SelectedTab == tcNaDan)
                {
                    if (udtNaDan.Value != null)
                    {
                        naDan = udtNaDan.DateTime;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {                        
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

        //db - 16.1.2017
        private void ckbKolicina_CheckedChanged(object sender, System.EventArgs e)
        {
            if (ckbKolicina.Checked == true)
            {
                prikazatiKolicinu = true;
            }
            else
            {
                prikazatiKolicinu = false;
            }
        }
    }
}
