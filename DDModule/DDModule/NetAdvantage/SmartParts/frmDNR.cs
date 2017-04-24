using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DDModule.NetAdvantage.SmartParts
{
    public partial class frmDNR : Form
    {
        #region properties
        public int pGodina
        {
            get;
            set;
        }
        public int pOdMjeseca
        {
            get;
            set;
        }
        public int pDoMjeseca
        {
            get;
            set;
        }

        public string pOsobe { get; set; }

        #endregion
        public frmDNR()
        {
            InitializeComponent();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            pOsobe = "";
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ugdOsobe.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Ozn"].Value))
                {
                    if (pOsobe.Length == 0)
                    {
                        pOsobe += "'" + Convert.ToInt32(row.Cells["IDRADNIK"].Value).ToString() + "'";
                    }
                    else
                    {
                        pOsobe += ",'" + Convert.ToInt32(row.Cells["IDRADNIK"].Value).ToString() + "'";
                    }

                }
            }

            if (uneOdMjeseca.Value != null & uneDoMjeseca.Value != null & uneGodina.Value != null & pOsobe.Length > 0)
            {
                pOdMjeseca = Convert.ToInt32(uneOdMjeseca.Value);
                pDoMjeseca = Convert.ToInt32(uneDoMjeseca.Value);
                pGodina = Convert.ToInt32(uneGodina.Value);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void NapuniOsobe()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            ugdOsobe.DataSource = client.GetDataTable("SELECT 'false' As 'Ozn', DDIDRADNIK As IDRADNIK, (DDIME + ' ' + DDPREZIME) As Osoba From DDRADNIK");
            ugdOsobe.DataBind();

            if (ugdOsobe.DisplayLayout.Bands.Count > 0)
                if (ugdOsobe.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdOsobe.DisplayLayout.Bands[0].Columns[0].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdOsobe.DisplayLayout.Bands[0].Columns[0].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    ugdOsobe.DisplayLayout.Bands[0].ColHeadersVisible = false;
                    ugdOsobe.DisplayLayout.Bands[0].Columns[1].Hidden = true;
                    ugdOsobe.DisplayLayout.Bands[0].Columns[0].Width = 50;
                    ugdOsobe.DisplayLayout.Bands[0].Columns[2].Width = 220;
                }
        }

        private void frmDNR_Load(object sender, EventArgs e)
        {
            NapuniOsobe();
        }
    }
}
