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
    public partial class frmPrimkeDobavljac : Form
    {
        #region svojstva
        public static int pDobavljac
        {
            get;
            set;
        }

        public static DateTime datumOD
        {
            get;
            set;
        }

        public static DateTime datumDo
        {
            get;
            set;
        }
        public static int pSort
        {
            get;
            set;
        }
        public static Nullable<DateTime> naDan { get; set; }
        #endregion

        public frmPrimkeDobavljac()
        {
            InitializeComponent();

            NapuniDobavljac();
        }

        private void NapuniDobavljac()
        {
            BusinessLogic.OtvaranjeSkladista objekt = new BusinessLogic.OtvaranjeSkladista();
            cmbDobavljac.DisplayMember = "Naziv";
            cmbDobavljac.ValueMember = "ID";
            cmbDobavljac.Items.AddRange(objekt.GetDobavljac());
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnIspis_Click(object sender, EventArgs e)
        {
            if (cmbDobavljac.SelectedItem.GetType().GetProperty("ID").GetValue(this.cmbDobavljac.SelectedItem, null) != null)
            {
                naDan = null;
                pDobavljac = (int)cmbDobavljac.SelectedItem.GetType().GetProperty("ID").GetValue(cmbDobavljac.SelectedItem, null);
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }

            datumOD = udtDatumOd.DateTime;
            datumDo = udtDatumDo.DateTime;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmPrimkeDobavljac_Load(object sender, EventArgs e)
        {

        }

        private void cmbDobavljac_KeyPress(object sender, KeyPressEventArgs e)
        {
            uceDokumentKeyPressed();
        }

        private void cmbDobavljac_TextChanged(object sender, EventArgs e)
        {
            if (cmbDobavljac.Text.Length == 0) uceDokumentKeyPressed();
        }
        private void uceDokumentKeyPressed()
        {
            cmbDobavljac.DroppedDown = true;

            object[] originalList = (object[])cmbDobavljac.Tag;
            if (originalList == null)
            {
                // backup original list
                originalList = new object[cmbDobavljac.Items.Count];
                cmbDobavljac.Items.CopyTo(originalList, 0);
                cmbDobavljac.Tag = originalList;
            }

            // prepare list of matching items
            string s = cmbDobavljac.Text.ToLower();
            IEnumerable<object> newList = originalList;



            if (s.Length > 0)
            {

                newList = originalList.Where(item => item.GetType().GetProperty("Naziv").GetValue(item, null).ToString().ToLower().Contains(s));

                //newList = originalList.Where(item => item[1].ToString().ToLower().Contains(s));
            }

            // clear list (loop through it, otherwise the cursor would move to the beginning of the textbox...)
            while (cmbDobavljac.Items.Count > 0)
            {
                cmbDobavljac.Items.RemoveAt(0);
            }

            // re-set list
            cmbDobavljac.Items.AddRange(newList.ToArray());
            cmbDobavljac.DisplayMember = "Naziv";
            cmbDobavljac.ValueMember = "ID";
        }
    }
}
