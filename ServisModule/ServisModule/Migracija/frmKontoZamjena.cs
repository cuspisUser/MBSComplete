using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;

namespace ServisModule.ServisModule.Migracija
{
	public partial class frmKontoZamjena: Form
	{
        public string idKonto { get; set; }
        public frmKontoZamjena(string idKonto)
		{
			InitializeComponent();
            UltraComboEditor test = new UltraComboEditor();
            test.Location = new Point(4, 4);

            lblMessage.Text = string.Format("Konto {0} se više ne koristi odaberite konto koji će ga zamjeniti!", idKonto);
            FillKonto();
		}

        private void FillKonto()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
            uceKonto.DataSource = client.GetDataTable("Select IDKONTO As ID, (RTRIM(IDKONTO) + ' | ' + RTRIM(NAZIVKONTO)) As Naziv From Konto Where Aktivan = 1");
            uceKonto.DataBind();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            idKonto = uceKonto.Value.ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
