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
    public partial class frmStanjeDokumenti : Form
    {
        #region svojstva
        public static DateTime datumOd
        {
            get;
            set;
        }
        public static DateTime datumDo
        {
            get;
            set;
        }

        public static Nullable<int> idSkladista
        {
            get;
            set;
        }

        public static int idMjestoTroska
        {
            get;
            set;
        }
        public static string dokument { get; set; }

        #endregion

        public frmStanjeDokumenti()
        {
            InitializeComponent();

            // db - 14.10.2016
            NapuniSkladiste();
            //cbSkladiste.SelectedIndex = -1; //čisti popis na combu
            NapuniMjestoTroska();
            cbMjestoTroska.SelectedIndex = -1;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            //dodavanje trenutnog vazeceg datuma ukoliko su datetime pickeri ostali prazni
            if (udtDatumOd.Value == null) udtDatumOd.Value = DateTime.Now.Date;
            if (udtDatumDo.Value == null) udtDatumDo.Value = DateTime.Now.Date;
            datumOd = udtDatumOd.DateTime;
            datumDo = udtDatumDo.DateTime;

            if ((int)cbSkladiste.SelectedIndex != -1)
            {
                idSkladista = (int)cbSkladiste.SelectedValue;
            }
            else
            {
                idSkladista = 0;
            }

            if ((int)cbMjestoTroska.SelectedIndex != -1)
            {
                idMjestoTroska = (int)cbMjestoTroska.SelectedValue;
            }
            else
            {
                idMjestoTroska = 0;
            }

            if (rbrPrimka.Checked)
            {
                dokument = "Primka";
            }
            else if (rbrIzdatnica.Checked)
            {
                dokument = "Izdatnica";
            }
            else
            {
                dokument = "Nijedan";
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        // db - 14.10.2016
        private void NapuniSkladiste()
        {
            BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod();
            cbSkladiste.DisplayMember = "Naziv";
            cbSkladiste.ValueMember = "ID";

            DataTable skladista = objekt.GetSkladiste();

            DataRow row = skladista.NewRow();
            row["ID"] = -1;
            row["Naziv"] = "<-Sva skladišta->";
            skladista.Rows.InsertAt(row, 0);

            cbSkladiste.DataSource = skladista;
        }

        // db - 14.10.2016
        private void NapuniMjestoTroska()
        {
            DataTable dt = new DataTable();
            BusinessLogic.OtvaranjeSkladista obj = new BusinessLogic.OtvaranjeSkladista();
            dt = obj.GetMjestoTroska();
            cbMjestoTroska.DataSource = dt;
            cbMjestoTroska.DisplayMember = "Naziv";
            cbMjestoTroska.ValueMember = "ID";
        }





    }
}

