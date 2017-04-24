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
    public partial class VoditeljForm : Controls.BaseUserControl
    {
        private int? ID { get; set; }
        private FormEditMode FormEditMode { get; set; }

        public VoditeljForm(FormEditMode formEditMode, int? id)
        {
            InitializeComponent();

            this.TextBoxIme.Focus();

            this.FormEditMode = formEditMode;
            this.ID = id;
        }

        #region Event Handlers

        private void VoditeljForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxRadnaMjesta();

            if (this.FormEditMode == Enums.FormEditMode.Update ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadFormVoditelj();
            }
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        private void ToolStripButtonSpremi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                TextBoxIme.Text = string.Empty;
                TextBoxOIB.Text = string.Empty;
                TextBoxPrezime.Text = string.Empty;
                ComboBoxRadnoMjesto.SelectedIndex = -1;
                CheckBoxAktivnost.Checked = false;
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
        private void btnVoditeljiZatvori_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        #endregion

        private void LoadComboBoxRadnaMjesta()
        {
            BusinessLogic.RadnaMjesta radnaMjesta = new BusinessLogic.RadnaMjesta();

            this.ComboBoxRadnoMjesto.DataSource = radnaMjesta.GetRadnaMjestaComboBox();
            this.ComboBoxRadnoMjesto.DataBind();
        }

        private void LoadFormVoditelj()
        {
            BusinessLogic.Voditelji voditelji = new BusinessLogic.Voditelji();

            var voditelj = voditelji.GetVoditelj(this.ID.GetValueOrDefault(0));

            this.TextBoxIme.Text = voditelj.Ime;
            this.TextBoxPrezime.Text = voditelj.Prezime;
            this.TextBoxOIB.Text = voditelj.OIB;
            this.ComboBoxRadnoMjesto.Value = voditelj.RadnoMjestoID;
            this.CheckBoxAktivnost.Checked = voditelj.Aktivnost;
        }

        private bool SaveData()
        {
            this.lblValidationMessages.ResetText();

            BusinessLogic.Voditelji voditelji = new BusinessLogic.Voditelji();


            if (this.FormEditMode == Enums.FormEditMode.Insert ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                voditelji.Add(this.TextBoxIme.Text.Trim(),
                    this.TextBoxPrezime.Text.Trim(),
                    this.TextBoxOIB.Text.Trim(),
                    (int?)(this.ComboBoxRadnoMjesto.Value != null ? this.ComboBoxRadnoMjesto.Value : null),
                    this.CheckBoxAktivnost.Checked);
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                voditelji.Update(this.ID.Value,
                    this.TextBoxIme.Text.Trim(),
                    this.TextBoxPrezime.Text.Trim(),
                    this.TextBoxOIB.Text.Trim(),
                    (int?)(this.ComboBoxRadnoMjesto.Value != null ? this.ComboBoxRadnoMjesto.Value : null),
                    this.CheckBoxAktivnost.Checked);
            }

            if (voditelji.IsValid)
            {
                return voditelji.Persist();
            }
            else
            {
                voditelji.DisplayValidationMessages(this);
            }

            return false;
        }

        
    }
}
