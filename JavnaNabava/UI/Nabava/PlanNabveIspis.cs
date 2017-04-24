using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JavnaNabava.Enums;

namespace JavnaNabava.UI.Nabava
{
    public partial class PlanNabveIspis : Controls.BaseUserControl
    {
        #region Metode

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public PlanNabveIspis()
        {
            InitializeComponent();
        }

        #endregion

        private void tsbNarudzbenicaOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void tsbNarudzbenicaSpremiZatvori_Click(object sender, EventArgs e)
        {
            BusinessLogic.PlanNabave.pIspisPlanaNabave = (DateTime)udtDatumIspisa.Value;
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }
    }
}
