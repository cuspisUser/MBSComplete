using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinPosModule
{
    public partial class OdabirSheme : JOPPD.Controls.BaseUserControl
    {
        public OdabirSheme()
        {
            InitializeComponent();
            LoadShemaOsnovno();
            LoadShemaDopunsko();
            LoadTipIRA();
            LoadPartner();
        }

        public int id_sheme = 0;
        public int idPartner = 0;
        public int idTipIRA = 0;
        public int idShemaDopunsko = 0;

        private void btnObracunOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void btnZaduzi_Click(object sender, EventArgs e)
        {
            if (ucbShemaOsnovno.Value != null & uceTipIRA.Value != null & ucePartner.Value != null & uceShemaDopunsko.Value != null)
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();

                id_sheme = (int)ucbShemaOsnovno.Value;
                idPartner = (int)ucePartner.Value;
                idTipIRA = (int)uceTipIRA.Value;
                idShemaDopunsko = (int)uceShemaDopunsko.Value;
            }
            else
            {
                MessageBox.Show("Potrebno je odabrati Sheme knjiženja,\n\rPartnera\n\rTip IRA-e.");
            }
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);

        }

        private void LoadShemaOsnovno()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            ucbShemaOsnovno.DataSource = client.GetDataTable("SELECT IDSHEMAIRA As ID, NAZIVSHEMAIRA As NAZIV FROM SHEMAIRA");
            ucbShemaOsnovno.DataBind();
        }

        private void LoadShemaDopunsko()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            uceShemaDopunsko.DataSource = client.GetDataTable("SELECT IDSHEMAIRA As ID, NAZIVSHEMAIRA As NAZIV FROM SHEMAIRA");
            uceShemaDopunsko.DataBind();
        }

        private void LoadPartner()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            ucePartner.DataSource = client.GetDataTable("SELECT IDPARTNER As ID, NAZIVPARTNER As NAZIV From PARTNER");
            ucePartner.DataBind();
        }

        private void LoadTipIRA()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            uceTipIRA.DataSource = client.GetDataTable("SELECT IDTIPIRA As ID, NAZIVTIPIRA As NAZIV FROM TIPIRA");
            uceTipIRA.DataBind();
        }
    }
}
