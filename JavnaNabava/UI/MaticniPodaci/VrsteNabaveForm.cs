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
    public partial class uscVrsteNabaveForm : Controls.BaseUserControl
    {

        #region Svojstva

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Metode

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public uscVrsteNabaveForm(FormEditMode formEditMode)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            BusinessLogic.VrsteNabave vrste_nabave = new BusinessLogic.VrsteNabave();

            if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
            {
                if (vrste_nabave.Insert())
                {
                    FormEditMode = Enums.FormEditMode.Update;
                    return true;
                }
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                if (vrste_nabave.Update())
                {
                    return true;
                }
            }
            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (BusinessLogic.VrsteNabave.pNaziv.Length == 0)
            {
                message.Append(" - Naziv vrste nabave je obavezno polje");
            }
            else if (BusinessLogic.VrsteNabave.pNaziv.Length > 50)
            {
                message.Append(" - Naziv vrste nabave može sadržavati maksimalno 50 znakova");
            }

            return message;
        }

        #endregion

        

        #region Dogadaji

        private void uscVrsteNabaveForm_Load(object sender, EventArgs e)
        {
            if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
            {
                uteNaziv.Value = BusinessLogic.VrsteNabave.pNaziv;
            }
        }

        private void tsbVrsteNabaveSpremiNovi_Click(object sender, EventArgs e)
        {
            BusinessLogic.VrsteNabave.pNaziv = uteNaziv.Text.Trim();

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
                    MessageBox.Show("Dogodila se greška prilikom upisa CPV oznake.\nKontaktirajte administratora [Error:00009]");
                }
            }
            else
            {
                lblValidationMessages.Text = message.ToString();
                return;
            }
        }

        private void tsbVrsteNabaveSpremiZatvori_Click(object sender, EventArgs e)
        {
            BusinessLogic.VrsteNabave.pNaziv = uteNaziv.Text.Trim();

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
                    MessageBox.Show("Dogodila se greška prilikom upisa vrste nabave.\nKontaktirajte administratora [Error:00009]");
                }
            }
            else
            {
                lblValidationMessages.Text = message.ToString();
                return;
            }
        }

        private void tsbVrsteNabaveOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        #endregion

    }
}
