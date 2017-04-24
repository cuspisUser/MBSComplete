using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UcenickoFakturiranje.Enums;

namespace UcenickoFakturiranje.UI.MaticniPodaci
{
    public partial class RazredForm : Controls.BaseUserControl
    {

        #region Svojstva

        private int? ID { get; set; }
        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Metode

        public RazredForm(FormEditMode formEditMode, int? id)
        {
            InitializeComponent();

            this.TextBoxNaziv.Focus();

            this.FormEditMode = formEditMode;
            this.ID = id;
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        private void LoadFormRazred()
        {
            BusinessLogic.Razredi razredi = new BusinessLogic.Razredi();

            var razred = razredi.GetRazred(this.ID.GetValueOrDefault(0));

            this.TextBoxNaziv.Text = razred.Naziv;
        }

        private bool SaveData()
        {
            this.lblValidationMessages.ResetText();

            BusinessLogic.Razredi razredi = new BusinessLogic.Razredi();


            if (this.FormEditMode == Enums.FormEditMode.Insert ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                razredi.Add(this.TextBoxNaziv.Text.Trim());
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                razredi.Update(this.ID.Value,
                    this.TextBoxNaziv.Text.Trim());
            }

            if (razredi.IsValid)
            {
                return razredi.Persist();
            }
            else
            {
                razredi.DisplayValidationMessages(this);
            }

            return false;
        }

        #endregion

        #region Dogadaji

        private void RazredForm_Load(object sender, EventArgs e)
        {
            if (this.FormEditMode == Enums.FormEditMode.Update ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadFormRazred();
            }
        }

        private void ToolStripButtonSpremi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                TextBoxNaziv.Text = string.Empty;
            }
        }

        private void ToolStripButtonSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }

        private void btnRazredOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        #endregion

    }
}
