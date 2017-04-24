using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Materijalno.BusinessLogic;

namespace Materijalno.UI.Izvjestaji
{
    public partial class frmSaldoKartica : Form
    {
        #region svojstva
        private static DateTime datumOd;

        public static DateTime DatumOd
        {
            get { return frmSaldoKartica.datumOd; }
            set { frmSaldoKartica.datumOd = value; }
        }

        private static DateTime datumDo;

        public static DateTime DatumDo
        {
            get { return frmSaldoKartica.datumDo; }
            set { frmSaldoKartica.datumDo = value; }
        }

        private static int idSkladista;

        public static int IdSkladista
        {
            get { return frmSaldoKartica.idSkladista; }
            set { frmSaldoKartica.idSkladista = value; }
        }
       

        //nema kontrole za ovo, određuje se preko odabira skladišta tj. ako je odabrano neko skladište onda je ovo = 1, u suprotnom = 0
        private static object pProizvod;

        public static object PProizvod
        {
            get { return frmSaldoKartica.pProizvod; }
            set { frmSaldoKartica.pProizvod = value; }
        }
       
        #endregion



        public frmSaldoKartica()
        {
            InitializeComponent();
            NapuniSkladiste();
        }

        // db - 20.10.2016
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

            idSkladista = 0;
            if ((int)cbSkladiste.SelectedIndex != -1 || (int)cbSkladiste.SelectedIndex == 0)
            {
                idSkladista = (int)cbSkladiste.SelectedValue;
                pProizvod = 13;
            }
            else
            {
                idSkladista = 0;
                pProizvod = DBNull.Value;
            }           

            //bez ovog ne prolazi dalje u MainController-u
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

     


    }
}
