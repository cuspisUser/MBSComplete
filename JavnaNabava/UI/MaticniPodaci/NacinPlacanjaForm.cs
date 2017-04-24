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
    public partial class uscNacinPlacanjaForm : Controls.BaseUserControl
    {

        #region Svojstva

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Metode

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public uscNacinPlacanjaForm(FormEditMode formEditMode)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            BusinessLogic.NacinPlacanja.pNaziv = BusinessLogic.NacinPlacanja.IsDbNull<string>(uteNaziv.Value);

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                BusinessLogic.NacinPlacanja objekt = new BusinessLogic.NacinPlacanja();

                if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
                {
                    if (objekt.Insert(message))
                    {
                        FormEditMode = Enums.FormEditMode.Update;
                        return true;
                    }
                }
                else if (this.FormEditMode == Enums.FormEditMode.Update)
                {
                    if (objekt.Update(message))
                    {
                        return true;
                    }
                }
            }

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (BusinessLogic.NacinPlacanja.pNaziv.Length == 0)
            {
                message.Append(" - Naziv vrste nabave je obavezno polje");
            }
            else if (BusinessLogic.NacinPlacanja.pNaziv.Length > 100)
            {
                message.Append(" - Naziv vrste nabave može sadržavati maksimalno 100 znakova");
            }

            return message;
        }

        #endregion

        #region Dogadaji

        private void uscNacinPlacanjaForm_Load(object sender, EventArgs e)
        {
            if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
            {
                uteNaziv.Value = BusinessLogic.NacinPlacanja.pNaziv;
            }
        }

        private void tsbNacinPlacanjaOdustani_Click(object sender, EventArgs e)
        {
            ContainerForm.DialogResult = DialogResult.Cancel;
            ContainerForm.Close();
        }

        private void tsbNacinPlacanjaSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                ContainerForm.DialogResult = DialogResult.OK;
                ContainerForm.Close();
            }
        }

        private void tsbNacinPlacanjaSpremiNovi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                uteNaziv.Value = null;
                FormEditMode = Enums.FormEditMode.Insert;
            }
        }

        #endregion

    }
}
