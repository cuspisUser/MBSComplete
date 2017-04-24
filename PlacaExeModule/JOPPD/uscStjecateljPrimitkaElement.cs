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
    public partial class uscStjecateljPrimitkaElement : Controls.BaseUserControl
    {
        #region Svojstva

        private JOPPD.Enums.FormEditMode FormEditMode
        {
            get;
            set;
        }

        #endregion

        #region Metode

        public uscStjecateljPrimitkaElement(FormEditMode formEditMode)
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
                if (save.InsertStjecateljPrimitkaElement())
                {
                    FormEditMode = Enums.FormEditMode.Update;
                    return true;
                }
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                if (save.UpdateStjecateljPrimitkaElement())
                {
                    return true;
                }
            }

            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (BusinessLogic.pElement == null)
            {
                message.Append(" - Element je obavezno polje");
            }
            if (BusinessLogic.pJOPPDOznaka == null)
            {
                message.Append(" - JOPPD oznaka je obavezno polje");
            }

            return message;
        }

        private void NapuniJOPPDOznake(BusinessLogic element)
        {
            ucbJOPPDOznaka.DataSource = element.GetJOPPDStjecateljPrimitkaElement().DefaultView; 
            ucbJOPPDOznaka.DataBind();
        }

        private void NapuniElemente(BusinessLogic element)
        {
            ucbElement.DataSource = element.GetElement().DefaultView;
            ucbElement.DataBind();
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
            BusinessLogic.pElement = (int?)ucbElement.Value;
            BusinessLogic.pJOPPDOznaka = (int?)ucbJOPPDOznaka.Value;

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
                    lblValidationMessages.Text = "Dogodila se greška prilikom upisa stjecatelj primitka elementa.\nKontaktirajte administratora";
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
            BusinessLogic.pElement = (int?)ucbElement.Value;
            BusinessLogic.pJOPPDOznaka = (int?)ucbJOPPDOznaka.Value;

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                if (SaveData())
                {
                    ucbElement.Value = null;
                    ucbJOPPDOznaka.Value = null;
                    FormEditMode = Enums.FormEditMode.Insert;
                }
                else
                {
                    lblValidationMessages.Text = "Dogodila se greška prilikom upisa stjecatelj primitka element.\nKontaktirajte administratora";
                }
            }
            else
            {
                lblValidationMessages.Text = message.ToString();
                return;
            }
        }

        private void uscRadnoVrijeme_Load(object sender, EventArgs e)
        {
            BusinessLogic element = new BusinessLogic();

            NapuniJOPPDOznake(element);
            NapuniElemente(element);

            if (FormEditMode == Enums.FormEditMode.Update)
            {
                ucbElement.Value = BusinessLogic.pElement;
                ucbJOPPDOznaka.Value = BusinessLogic.pJOPPDOznaka;
            }
        }

        #endregion

    }
}
