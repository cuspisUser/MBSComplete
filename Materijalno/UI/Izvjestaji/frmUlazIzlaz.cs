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
    public partial class frmUlazIzlaz : Form
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
        public static int  vrstaDokumenta { get; set; }
        #endregion

        public frmUlazIzlaz()
        {
            InitializeComponent();
            NapuniSkladiste();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            datumOd = udtDatumOd.DateTime;
            datumDo = udtDatumDo.DateTime;
            if (rbrPrimka.Checked)
            {
                vrstaDokumenta = 1;
            }
            else
            {
                vrstaDokumenta = 0;
            }

            if ((int)cmbSkladiste.SelectedValue != -1) //SelectedValue???
            {
                skladiste = (int)cmbSkladiste.SelectedValue;
            }
            else
            {
                skladiste = null;
            }

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
    }
}
