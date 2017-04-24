using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Materijalno.Enums;

namespace Materijalno.UI.Skladista
{
    public partial class TipSkladistaForm : Controls.BaseUserControl
    {
        #region Properties

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Methods

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public TipSkladistaForm(FormEditMode formEditMode)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            StringBuilder message = ValidateDataInput();

            if (message.Length == 0)
            {
                using (BusinessLogic.TipSkladista objekt = new BusinessLogic.TipSkladista())
                {
                    objekt.pNaziv = uteNaziv.Value.ToString();

                    if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
                    {
                        if (objekt.Insert(message, objekt))
                        {
                            FormEditMode = Enums.FormEditMode.Update;
                            return true;
                        }
                    }
                    else if (this.FormEditMode == Enums.FormEditMode.Update)
                    {
                        if (objekt.Update(message, objekt))
                        {
                            return true;
                        }
                    }
                }
            }

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (uteNaziv.Value == null)
            {
                message.Append(" - Naziv je obavezno polje");
            }
            else if (uteNaziv.Value.ToString().Length > 250)
            {
                message.Append(" - Naziv može sadržavati maksimalno 250 znakova");
            }

            return message;
        }

        private void LoadForm(BusinessLogic.TipSkladista objekt)
        {
            var obj = objekt.GetSelectedRow();

            if (obj != null)
            {
                uteNaziv.Value = obj["Naziv"].ToString();
            }
        }

        #endregion

        #region Dogadaji

        private void tsbSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }

        private void tsbOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void tsbSpremiNovi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                uteNaziv.Value = null;

                FormEditMode = Enums.FormEditMode.Insert;
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            using (BusinessLogic.TipSkladista objekt = new BusinessLogic.TipSkladista())
            {
                if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
                {
                    LoadForm(objekt);
                }
            }
        }

        #endregion

    }
}
