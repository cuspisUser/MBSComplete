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
    public partial class frmMjestoTroska : Form
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
        public static Nullable<int> skladiste { get; set; }
        public static int  mjestoTroska {get; set;}
        #endregion

        public frmMjestoTroska()
        {
            InitializeComponent();
            NapuniSkladiste();
            NapuniMjestoTroska();
            cmbmjestoTroska.SelectedIndex = 0;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            datumOd = udtDatumOd.DateTime;
            datumDo = udtDatumDo.DateTime;

            if ((int)cmbSkladiste.SelectedValue != -1)
            {
                skladiste = (int)cmbSkladiste.SelectedValue;
            }
            else
            {
                skladiste = null;
            }
            mjestoTroska = (int)cmbmjestoTroska.SelectedValue;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void NapuniSkladiste()
        {
            BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod();
            cmbSkladiste.DisplayMember = "Naziv";
            cmbSkladiste.ValueMember = "ID";

            DataTable skladista = objekt.GetSkladiste();

            DataRow row = skladista.NewRow();
            row["ID"] = -1;
            row["Naziv"] = "<-Sva skladišta->";
            skladista.Rows.InsertAt(row, 0);

            cmbSkladiste.DataSource = skladista;
        }

        private void NapuniMjestoTroska()
        {
            BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod();
            cmbmjestoTroska.DisplayMember = "Naziv";
            cmbmjestoTroska.ValueMember = "ID";

            cmbmjestoTroska.DataSource = objekt.GetMjestoTroska();
        }
    }
}
