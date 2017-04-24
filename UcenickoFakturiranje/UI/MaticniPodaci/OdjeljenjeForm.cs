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
    public partial class OdjeljenjeForm : Controls.BaseUserControl
    {

        #region Svojstva

        private int? ID { get; set; }

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Metode

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public OdjeljenjeForm(FormEditMode formEditMode, int? id)
        {
            InitializeComponent();

            this.TextBoxNaziv.Focus();

            this.FormEditMode = formEditMode;
            this.ID = id;
        }

        private void LoadFormOdjeljenje()
        {
            BusinessLogic.Odjeljenja odjeljenja = new BusinessLogic.Odjeljenja();

            var odjeljenje = odjeljenja.GetOdjeljenje(this.ID.GetValueOrDefault(0));

            this.TextBoxNaziv.Text = odjeljenje.Naziv;
        }

        private bool SaveData()
        {
            this.lblValidationMessages.ResetText();

            BusinessLogic.Odjeljenja odjeljenja = new BusinessLogic.Odjeljenja();


            if (this.FormEditMode == Enums.FormEditMode.Insert ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                odjeljenja.Add(this.TextBoxNaziv.Text.Trim());
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                odjeljenja.Update(this.ID.Value,
                    this.TextBoxNaziv.Text.Trim());
            }

            if (odjeljenja.IsValid)
            {
                return odjeljenja.Persist();
            }
            else
            {
                odjeljenja.DisplayValidationMessages(this);
            }

            return false;
        }

        #endregion

        #region Dogadaji

        private void OdjeljenjeForm_Load(object sender, EventArgs e)
        {
            if (this.FormEditMode == Enums.FormEditMode.Update ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadFormOdjeljenje();
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

        private void btnOdjeljenjaZatvori_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }
        #endregion
    }
}
