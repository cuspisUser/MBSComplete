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
    public partial class uscFiskalneGodine : Controls.BaseUserControl
    {

        #region Svojstva

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Metode

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public uscFiskalneGodine(FormEditMode formEditMode)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            BusinessLogic.FiskalneGodine fiskalne_godine = new BusinessLogic.FiskalneGodine();

            if (cbkAktivna.Checked)
            {
                if (!fiskalne_godine.AktivnaSkolskaGodina())
                {
                    MessageBox.Show("Dogodila se greška prilikom upisa fiskalne godine.\nKontaktirajte administratora [Error:00011]");
                    return false;
                }
            }

            if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
            {
                if (fiskalne_godine.Insert())
                {
                    FormEditMode = Enums.FormEditMode.Update;
                    return true;
                }
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                if (fiskalne_godine.Update())
                {
                    return true;
                }
            }
            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (BusinessLogic.FiskalneGodine.pID < 2000)
            {
                message.Append(" - Godina nesmije biti manja od 2000.g.");
            }
            else if (BusinessLogic.FiskalneGodine.pID > DateTime.Now.Year + 1)
            {
                message.Append(" - Godina nesmije biti veća od sljedeće godine");
            }

            return message;
        }

        #endregion

        #region Dogadaji

        private void tsbVrsteNabaveSpremiNovi_Click(object sender, EventArgs e)
        {
            BusinessLogic.FiskalneGodine.pID = (int)nudGodina.Value;
            BusinessLogic.FiskalneGodine.pAktivna = cbkAktivna.Checked;

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                if (SaveData())
                {
                    nudGodina.Value = DateTime.Now.Year;
                    cbkAktivna.Checked = false;
                    FormEditMode = Enums.FormEditMode.Insert;
                }
                else
                {
                    MessageBox.Show("Dogodila se greška prilikom upisa fiskalne godine.\nKontaktirajte administratora [Error:00011]");
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
            BusinessLogic.FiskalneGodine.pID = (int)nudGodina.Value;
            BusinessLogic.FiskalneGodine.pAktivna = cbkAktivna.Checked;

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
                    MessageBox.Show("Dogodila se greška prilikom upisa fiskalne godine.\nKontaktirajte administratora [Error:00011]");
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

        private void uscFiskalneGodine_Load(object sender, EventArgs e)
        {
            if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
            {
                nudGodina.Value = BusinessLogic.FiskalneGodine.pID;
                cbkAktivna.Checked = BusinessLogic.FiskalneGodine.pAktivna;
            }
        }

        #endregion

        
    }
}
