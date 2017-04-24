using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    public partial class OdabirSheme : Controls.BaseUserControl
    {
        public OdabirSheme()
        {
            InitializeComponent();
            LoadCombo();
        }

        public int id_sheme = 0;

        private void btnObracunOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void btnZaduzi_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
            id_sheme = (int)ucbShema.Value;
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);

        }

        private void LoadCombo()
        {
            BusinessLogic.Obracuni objekt = new BusinessLogic.Obracuni();

            ucbShema.DataSource = objekt.GetShemaFinancijsko();
            ucbShema.DataBind();
        }
    }
}
