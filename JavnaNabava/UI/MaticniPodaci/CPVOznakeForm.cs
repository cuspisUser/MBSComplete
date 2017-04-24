using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JavnaNabava.Enums;

namespace JavnaNabava.UI.MaticniPodaci
{
    public partial class uscCPVOznake : Controls.BaseUserControl
    {

        #region Svojstva

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Metode

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public uscCPVOznake(FormEditMode formEditMode)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            BusinessLogic.CPVOznake cpv_oznake = new BusinessLogic.CPVOznake();

            if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
            {
                if (cpv_oznake.Insert())
                {
                    FormEditMode = Enums.FormEditMode.Update;
                    return true;
                }
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                if (cpv_oznake.Update())
                {
                    return true;
                }
            }
            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (BusinessLogic.CPVOznake.pNaziv.Length == 0)
            {
                message.Append(" - Naziv CPV oznake je obavezno polje");
            }
            else if (BusinessLogic.CPVOznake.pNaziv.Length > 50)
            {
                message.Append(" - Naziv CPV oznake može sadržavati maksimalno 50 znakova");
            }

            return message;
        }

        #endregion

        #region Dogadaji

        private void tsbCPVOznakeSpremiNovi_Click(object sender, EventArgs e)
        {
            BusinessLogic.CPVOznake.pNaziv = uteNaziv.Text.Trim();

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                if (SaveData())
                {
                    uteNaziv.Text = string.Empty;
                    FormEditMode = Enums.FormEditMode.Insert;
                }
                else
                {
                    MessageBox.Show("Dogodila se greška prilikom upisa CPV oznake.\nKontaktirajte administratora [Error:00007]");
                }
            }
            else
            {
                lblValidationMessages.Text = message.ToString();
                return;
            }
        }

        private void tsbCPVOznakeSpremiZatvori_Click(object sender, EventArgs e)
        {
            BusinessLogic.CPVOznake.pNaziv = uteNaziv.Text.Trim();

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
                    MessageBox.Show("Dogodila se greška prilikom upisa CPV oznake.\nKontaktirajte administratora [Error:00007]");
                }
            }
            else
            {
                lblValidationMessages.Text = message.ToString();
                return;
            }
        }

        private void tsbCPVOznakeOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void uscCPVOznake_Load(object sender, EventArgs e)
        {
            if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
            {
                uteNaziv.Value = BusinessLogic.CPVOznake.pNaziv;
            }
        }

        #endregion

    }
}
