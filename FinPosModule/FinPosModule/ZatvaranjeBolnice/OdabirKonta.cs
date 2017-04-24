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
    public partial class OdabirKonta : JOPPD.Controls.BaseUserControl
    {
        public OdabirKonta()
        {
            InitializeComponent();
            LoadKonto();
        }

        public string idKonto = "";

        private void btnObracunOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void btnZaduzi_Click(object sender, EventArgs e)
        {
            if (uceKonto.Value != null)
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();

                idKonto = uceKonto.Value.ToString();
            }
            else
            {
                MessageBox.Show("Potrebno je odabrati konto za zatvaranje");
            }
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);

        }

        private void LoadKonto()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            uceKonto.DataSource = client.GetDataTable("SELECT IDKONTO As ID, (IDKONTO + ' | ' + NAZIVKONTO) As NAZIV FROM KONTO");
            uceKonto.DataBind();
        }
    }
}
