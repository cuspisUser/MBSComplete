using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UcenickoFakturiranje.Enums;

namespace UcenickoFakturiranje.UI.SkolskeGodineRazrednaOdjeljenja
{
    public partial class UstanovaSkolskaGodinaForm : Controls.BaseUserControl
    {
        private int? ID { get; set; }
        private FormEditMode FormEditMode { get; set; }

        public UstanovaSkolskaGodinaForm(FormEditMode formEditMode, int? id)
        {
            InitializeComponent();

            this.ComboBoxUstanova.Focus();

            this.FormEditMode = formEditMode;
            this.ID = id;
        }

        #region Event Handlers

        private void UstanovaSkolskaGodinaForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxUstanove();
            LoadComboBoxSkolskeGodine();

            if (this.FormEditMode == Enums.FormEditMode.Update ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadFormUstanovaSkolskaGodina();
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
                ComboBoxUstanova.SelectedIndex = -1;
                ComboBoxSkolskaGodina.SelectedIndex = -1;
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

        private void btnUstanovaSkolskaGodinaZatvori_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        #endregion

        private void LoadComboBoxUstanove()
        {
            BusinessLogic.Ustanove ustanove = new BusinessLogic.Ustanove();

            this.ComboBoxUstanova.DataSource = ustanove.GetUstanoveComboBox();
            this.ComboBoxUstanova.DataBind();
        }

        private void LoadComboBoxSkolskeGodine()
        {
            BusinessLogic.SkolskeGodine skolskeGodine = new BusinessLogic.SkolskeGodine();

            this.ComboBoxSkolskaGodina.DataSource = skolskeGodine.GetSkolskeGodineComboBox(this.ID);
            this.ComboBoxSkolskaGodina.DataBind();
        }

        private void LoadFormUstanovaSkolskaGodina()
        {
            BusinessLogic.UstanoveSkolskeGodine ustanoveSkolskeGodine = new BusinessLogic.UstanoveSkolskeGodine();

            var ustanovaSkolskaGodina = ustanoveSkolskeGodine.GetUstanovaSkolskaGodina(this.ID.GetValueOrDefault(0));

            this.ComboBoxUstanova.Value = ustanovaSkolskaGodina.UstanovaID;
            this.ComboBoxSkolskaGodina.Value = ustanovaSkolskaGodina.SkolskaGodinaID;
        }

        private bool SaveData()
        {
            this.lblValidationMessages.ResetText();

            BusinessLogic.UstanoveSkolskeGodine ustanoveSkolskeGodine = new BusinessLogic.UstanoveSkolskeGodine();


            if (this.FormEditMode == Enums.FormEditMode.Insert ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                ustanoveSkolskeGodine.Add((int?)(this.ComboBoxUstanova.Value != null ? this.ComboBoxUstanova.Value : null),
                    (int?)(this.ComboBoxSkolskaGodina.Value != null ? this.ComboBoxSkolskaGodina.Value : null));
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                ustanoveSkolskeGodine.Update(this.ID.Value, (int?)(this.ComboBoxUstanova.Value != null ? this.ComboBoxUstanova.Value : null),
                    (int?)(this.ComboBoxSkolskaGodina.Value != null ? this.ComboBoxSkolskaGodina.Value : null));
            }

            if (ustanoveSkolskeGodine.IsValid)
            {
                return ustanoveSkolskeGodine.Persist();
            }
            else
            {
                ustanoveSkolskeGodine.DisplayValidationMessages(this);
            }

            return false;
        }

        
    }
}
