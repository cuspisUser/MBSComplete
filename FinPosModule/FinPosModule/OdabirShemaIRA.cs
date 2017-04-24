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
    public partial class OdabirShemaIRA : JOPPD.Controls.BaseUserControl
    {
        public OdabirShemaIRA()
        {
            InitializeComponent();
            LoadShemaIRA();
        }

        public int idShema = 0;

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

                idShema = (int)uceKonto.Value;
            }
            else
            {
                MessageBox.Show("Potrebno je odabrati Sheme knjiženja.");
            }
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);

        }

        private void LoadShemaIRA()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            uceKonto.DataSource = client.GetDataTable("SELECT IDSHEMAIRA As ID, NAZIVSHEMAIRA As NAZIV FROM SHEMAIRA");
            uceKonto.DataBind();
        }
    }
}
