using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServisModule.ServisModule.Margine
{
	public partial class frmMargine: Form
    {
        #region Svojstva

        public static int pLeft
        {
            get;
            set;
        }
        public static int pRight
        {
            get;
            set;
        }
        public static int pBottom
        {
            get;
            set;
        }
        public static int pTop
        {
            get;
            set;
        }

        #endregion

        #region Metode

        public frmMargine()
		{
			InitializeComponent();

            if (!string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.Margine))
            {
                Array margine = Mipsed7.Core.ApplicationDatabaseInformation.Margine.Split(';');
                txtGore.Text = ((string[])(margine))[0];
                txtDole.Text = ((string[])(margine))[1];
                txtLeft.Text = ((string[])(margine))[2];
                txtRight.Text = ((string[])(margine))[3];
            }

		}

        #endregion

        #region Događaji

        private void tsbPlanNabaveOdustani_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void tsbPlanNabaveSpremiZatvori_Click(object sender, EventArgs e)
        {
            try
            {
                pTop = Convert.ToInt32(txtGore.Text.Trim());
                pBottom = Convert.ToInt32(txtDole.Text.Trim());
                pLeft = Convert.ToInt32(txtLeft.Text.Trim());
                pRight = Convert.ToInt32(txtRight.Text.Trim());
                Mipsed7.Core.ApplicationDatabaseInformation.Margine = pTop.ToString() + ";" + pBottom.ToString() + ";" + pLeft.ToString() + ";" + pRight.ToString();
            }
            catch 
            {
                MessageBox.Show("Uneseni podaci nisu u ispravnom formatu!!!\nUnesite ispravne vrijednosti za Margine.");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion
    }
}
