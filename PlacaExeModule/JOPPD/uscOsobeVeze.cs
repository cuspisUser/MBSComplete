using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using JOPPD.Enums;

namespace JOPPD
{
    public partial class uscOsobeVeze : Form
    {
        BusinessLogic.ObracunRazno element = new BusinessLogic.ObracunRazno();

        #region Svojstva

        private FormEditMode pFormEditMode
        {
            get;
            set;
        }

        #endregion

        #region Metode

        public uscOsobeVeze(FormEditMode vrsta_promjene)
        {
            InitializeComponent();
            pFormEditMode = vrsta_promjene;
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
              
            }

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        private StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            return message;
        }

        private T IsDbNull<T>(object value)
        {
            if (value != DBNull.Value && value != null)
            {
                // return (T)value; // CAST
                return (T)Convert.ChangeType(value, typeof(T)); // CONVERT
            }

            return default(T);
        }

        private void SetUpSizeOfForm()
        {
            this.Height = 126;

            if (uceOsoba.Value != null)
            {
                this.Height = 186;
                cbkVrstaVeze1.Visible = true;
                uceVrstaVeze1.Visible = true;
            }
            if (uceVrstaVeze1.Value != null)
            {
                this.Height = 246;
                cbkVrstaVeze2.Visible = true;
                uceVrstaVeze2.Visible = true;
            }
            if (uceVrstaVeze2.Value != null)
            {
                this.Height = 306;
                cbkVrstaVeze3.Visible = true;
                uceVrstaVeze3.Visible = true;
            }
            if (uceVrstaVeze3.Value != null)
            {
                this.Height = 366;
                cbkVrstaVeze4.Visible = true;
                uceVrstaVeze4.Visible = true;
            }
        }

        private void NapuniUcenike()
        {
            uceOsoba.DataSource = element.GetUceniciVeze().DefaultView;
            uceOsoba.DataBind();
        }

        private void NapuniVezaOsobe1(int id_ucenik)
        {
            uceOsobaVeza1.DataSource = element.GetOsobaVeza1(id_ucenik).DefaultView;
            uceOsobaVeza1.DataBind();
        }

        private void NapuniVezaOsobe2(int id_ucenik, int id_veza1)
        {
            uceOsobaVeza2.DataSource = element.GetOsobaVeza2(id_ucenik, id_veza1).DefaultView;
            uceOsobaVeza2.DataBind();
        }

        private void NapuniVezaOsobe3(int id_ucenik, int id_veza1, int id_veza2)
        {
            uceOsobaVeza3.DataSource = element.GetOsobaVeza3(id_ucenik, id_veza1, id_veza2).DefaultView;
            uceOsobaVeza3.DataBind();
        }

        private void NapuniVezaOsobe4(int id_ucenik, int id_veza1, int id_veza2, int id_veza3)
        {
            uceOsobaVeza4.DataSource = element.GetOsobaVeza4(id_ucenik, id_veza1, id_veza2, id_veza3).DefaultView;
            uceOsobaVeza4.DataBind();
        }

        private void NapuniVrstaVeze1(int id_veze)
        {
            uceVrstaVeze1.DataSource = element.GetVrstaVeze1(id_veze).DefaultView;
            uceVrstaVeze1.DataBind();

            if (id_veze != 1)
            {
                uceVrstaVeze1.ReadOnly = true;
                uceVrstaVeze1.SelectedIndex = 0;
            }
            else
            {
                uceVrstaVeze1.ReadOnly = false;
            }
        }

        private void NapuniVrstaVeze2(int id_veze)
        {
            uceVrstaVeze2.DataSource = element.GetVrstaVeze1(id_veze).DefaultView;
            uceVrstaVeze2.DataBind();

            if (id_veze != 1)
            {
                uceVrstaVeze2.ReadOnly = true;
                uceVrstaVeze2.SelectedIndex = 0;
            }
            else
            {
                uceVrstaVeze2.ReadOnly = false;
            }
        }

        private void NapuniVrstaVeze3(int id_veze)
        {
            uceVrstaVeze3.DataSource = element.GetVrstaVeze1(id_veze).DefaultView;
            uceVrstaVeze3.DataBind();

            if (id_veze != 1)
            {
                uceVrstaVeze3.ReadOnly = true;
                uceVrstaVeze3.SelectedIndex = 0;
            }
            else
            {
                uceVrstaVeze3.ReadOnly = false;
            }
        }

        private void NapuniVrstaVeze4(int id_veze)
        {
            uceVrstaVeze4.DataSource = element.GetVrstaVeze1(id_veze).DefaultView;
            uceVrstaVeze4.DataBind();

            if (id_veze != 1)
            {
                uceVrstaVeze4.ReadOnly = true;
                uceVrstaVeze4.SelectedIndex = 0;
            }
            else
            {
                uceVrstaVeze4.ReadOnly = false;
            }
        }

        private int ProvjeraVezeNaOdabranojOsobi(int id_osobe)
        {
            var id_veze = element.GetIDVeze(id_osobe);
            return Convert.ToInt32(id_veze["ID_VrstaObiteljskeVeze"]);
        }

        #endregion

        #region Događaji

        private void uscOsobeVeze_Load(object sender, EventArgs e)
        {
            NapuniUcenike();

            if (pFormEditMode == FormEditMode.Update)
            {

            }
            SetUpSizeOfForm();
        }

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnSpremiNovi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                
            }
        }

        private void uceVrstaOsobe_ValueChanged(object sender, EventArgs e)
        {
        }

        private void cbkVrstaVeze1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkVrstaVeze1.Checked)
            {
                uceVrstaVeze1.Visible = true;
                uceOsobaVeza1.Visible = true;
                NapuniVezaOsobe1((int)uceOsoba.Value);
            }
            else
            {
                this.Height = 186;
                uceVrstaVeze1.Visible = false;
                uceVrstaVeze2.Visible = false;
                uceVrstaVeze3.Visible = false;
                uceVrstaVeze4.Visible = false;
                uceVrstaVeze1.Value = null;
                uceVrstaVeze2.Value = null;
                uceVrstaVeze3.Value = null;
                uceVrstaVeze4.Value = null;
                cbkVrstaVeze2.Checked = false;
                cbkVrstaVeze3.Checked = false;
                cbkVrstaVeze4.Checked = false;
                uceOsobaVeza1.Visible = false;
                uceOsobaVeza2.Visible = false;
                uceOsobaVeza3.Visible = false;
                uceOsobaVeza4.Visible = false;
                uceOsobaVeza1.Value = null;
                uceOsobaVeza2.Value = null;
                uceOsobaVeza3.Value = null;
                uceOsobaVeza4.Value = null;
            }
        }

        private void uceVrstaVeze1_ValueChanged(object sender, EventArgs e)
        {
            if (uceVrstaVeze1.Value != null)
            {
                this.Height = 246;
                cbkVrstaVeze2.Visible = true;
            }
            else
            {
                this.Height = 186;
                cbkVrstaVeze2.Visible = false;
            }
        }

        private void cbkVrstaVeze2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkVrstaVeze2.Checked)
            {
                uceVrstaVeze2.Visible = true;
                uceOsobaVeza2.Visible = true;
                NapuniVezaOsobe2((int)uceOsoba.Value, (int)uceOsobaVeza1.Value);
            }
            else
            {
                this.Height = 246;
                uceVrstaVeze2.Visible = false;
                uceVrstaVeze3.Visible = false;
                uceVrstaVeze4.Visible = false;
                uceVrstaVeze2.Value = null;
                uceVrstaVeze3.Value = null;
                uceVrstaVeze4.Value = null;
                cbkVrstaVeze3.Checked = false;
                cbkVrstaVeze4.Checked = false;
                uceOsobaVeza2.Visible = false;
                uceOsobaVeza3.Visible = false;
                uceOsobaVeza4.Visible = false;
                uceOsobaVeza2.Value = null;
                uceOsobaVeza3.Value = null;
                uceOsobaVeza4.Value = null;
            }
        }

        private void uceVrstaVeze2_ValueChanged(object sender, EventArgs e)
        {
            if (uceVrstaVeze2.Value != null)
            {
                this.Height = 306;
                cbkVrstaVeze3.Visible = true;
            }
            else
            {
                this.Height = 246;
                cbkVrstaVeze3.Visible = false;
            }
        }

        private void cbkVrstaVeze3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkVrstaVeze3.Checked)
            {
                uceVrstaVeze3.Visible = true;
                uceOsobaVeza3.Visible = true;
                NapuniVezaOsobe3((int)uceOsoba.Value, (int)uceOsobaVeza1.Value, (int)uceOsobaVeza2.Value);
            }
            else
            {
                this.Height = 306;
                uceVrstaVeze3.Visible = false;
                uceVrstaVeze4.Visible = false;
                uceVrstaVeze3.Value = null;
                uceVrstaVeze4.Value = null;
                cbkVrstaVeze4.Checked = false;
                uceOsobaVeza3.Visible = false;
                uceOsobaVeza4.Visible = false;
                uceOsobaVeza3.Value = null;
                uceOsobaVeza4.Value = null;
            }
        }

        private void uceVrstaVeze3_ValueChanged(object sender, EventArgs e)
        {
            if (uceVrstaVeze3.Value != null)
            {
                this.Height = 366;
                cbkVrstaVeze4.Visible = true;
            }
            else
            {
                this.Height = 306;
                cbkVrstaVeze4.Visible = false;
            }
        }

        private void cbkVrstaVeze4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkVrstaVeze4.Checked)
            {
                uceVrstaVeze4.Visible = true;
                uceOsobaVeza4.Visible = true;
                NapuniVezaOsobe4((int)uceOsoba.Value, (int)uceOsobaVeza1.Value, (int)uceOsobaVeza2.Value, (int)uceOsobaVeza3.Value);
            }
            else
            {
                this.Height = 366;
                uceVrstaVeze4.Visible = false;
                uceVrstaVeze4.Value = null;
                uceOsobaVeza4.Visible = false;
                uceOsobaVeza4.Value = null;
            }
        }

        #endregion

        private void uceOsoba_ValueChanged(object sender, EventArgs e)
        {
            if (uceOsoba.Value != null)
            {
                this.Height = 186;
                cbkVrstaVeze1.Visible = true;
            }
            else
            {
                this.Height = 126;
                cbkVrstaVeze1.Visible = false;
            }
        }

        private void uceOsobaVeza1_ValueChanged(object sender, EventArgs e)
        {
            if (uceOsobaVeza1.Value != null)
            {
                NapuniVrstaVeze1(ProvjeraVezeNaOdabranojOsobi((int)uceOsobaVeza1.Value));
            }
        }

        private void uceOsobaVeza2_ValueChanged(object sender, EventArgs e)
        {
            if (uceOsobaVeza2.Value != null)
            {
                NapuniVrstaVeze2(ProvjeraVezeNaOdabranojOsobi((int)uceOsobaVeza2.Value));
            }
        }

        private void uceOsobaVeza3_ValueChanged(object sender, EventArgs e)
        {
            if (uceOsobaVeza3.Value != null)
            {
                NapuniVrstaVeze3(ProvjeraVezeNaOdabranojOsobi((int)uceOsobaVeza3.Value));
            }
        }

        private void uceOsobaVeza4_ValueChanged(object sender, EventArgs e)
        {
            if (uceOsobaVeza4.Value != null)
            {
                NapuniVrstaVeze4(ProvjeraVezeNaOdabranojOsobi((int)uceOsobaVeza4.Value));
            }
        }

    }
}
