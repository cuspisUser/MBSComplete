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
    public partial class uscStjecateljPrimitka : Controls.BaseUserControl
    {
        #region Svojstva

        private JOPPD.Enums.FormEditMode FormEditMode
        {
            get;
            set;
        }

        #endregion

        #region Metode

        public uscStjecateljPrimitka(FormEditMode formEditMode)
        {
            InitializeComponent();
            FormEditMode = formEditMode;
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);

        }

        private bool SaveData()
        {
            this.lblValidationMessages.ResetText();

            BusinessLogic save = new BusinessLogic();

            if (this.FormEditMode == Enums.FormEditMode.Insert)
            {
                if (save.Insert("JOPPDOznakaStjecateljaPrimitka"))
                {
                    FormEditMode = Enums.FormEditMode.Update;
                    return true;
                }
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                if (save.Update("JOPPDOznakaStjecateljaPrimitka"))
                {
                    return true;
                }
            }

            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (BusinessLogic.pOznaka.Length == 0)
            {
                message.Append(" - Oznaka je obavezno polje");
            }
            else if (BusinessLogic.pOznaka.Length > 4)
            {
                message.Append(" - Oznaka može sadržavati maksimalno 4 znaka");
            }
            if (BusinessLogic.pKratkiOpis.Length == 0)
            {
                message.Append(" - Kratki opis je obavezno polje");
            }
            else if (BusinessLogic.pKratkiOpis.Length > 140)
            {
                message.Append(" - Kratki opis može sadržavati maksimalno 140 znakova");
            }
            if (BusinessLogic.pDugiOpis.Length == 0)
            {
                message.Append(" - Dugi opis je obavezno polje");
            }
            else if (BusinessLogic.pDugiOpis.Length > 410)
            {
                message.Append(" - Dugi opis može sadržavati maksimalno 410 znakova");
            }

            return message;
        }

        #endregion

        #region Događaji

        private void btnZatvori_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        private void btnSpremiZatvori_Click(object sender, EventArgs e)
        {
            BusinessLogic.pOznaka = txtOznaka.Text.Trim();
            BusinessLogic.pKratkiOpis = txtKratkiOpis.Text.Trim();
            BusinessLogic.pDugiOpis = txtDugiOpis.Text.Trim();

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                if (SaveData())
                {
                    base.ContainerForm.DialogResult = DialogResult.OK;
                    base.ContainerForm.Close();
                }
                else
                {
                    lblValidationMessages.Text = "Dogodila se greška prilikom upisa Stjecatelja primitka.\nKontaktirajte administratora";
                }
            }
            else
            {
                lblValidationMessages.Text = message.ToString();
                return;
            }
        }

        private void btnSpremiNovi_Click(object sender, EventArgs e)
        {
            BusinessLogic.pOznaka = txtOznaka.Text.Trim();
            BusinessLogic.pKratkiOpis = txtKratkiOpis.Text.Trim();
            BusinessLogic.pDugiOpis = txtDugiOpis.Text.Trim();

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                if (SaveData())
                {
                    txtOznaka.Text = string.Empty;
                    txtKratkiOpis.Text = string.Empty;
                    txtDugiOpis.Text = string.Empty;
                    FormEditMode = Enums.FormEditMode.Insert;
                }
                else
                {
                    lblValidationMessages.Text = "Dogodila se greška prilikom upisa Stjecatelja primitka.\nKontaktirajte administratora";
                }
            }
            else
            {
                lblValidationMessages.Text = message.ToString();
                return;
            }
        }

        private void uscStjecateljPrimitka_Load(object sender, EventArgs e)
        {
            if (FormEditMode == Enums.FormEditMode.Update)
            {
                txtOznaka.Text = BusinessLogic.pOznaka;
                txtKratkiOpis.Text = BusinessLogic.pKratkiOpis;
                txtDugiOpis.Text = BusinessLogic.pDugiOpis;
            }
        }

        #endregion
    }
}
