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
    public partial class UcenikForm : Controls.BaseUserControl
    {
        private int? ID { get; set; }
        private FormEditMode FormEditMode { get; set; }

        public UcenikForm(FormEditMode formEditMode, int? id)
        {
            InitializeComponent();

            this.TextBoxIme.Focus();
            this.DateTimePickerDatumRodjenja.Value = DateTime.Today;

            this.FormEditMode = formEditMode;
            this.ID = id;
        }

        #region Event Handlers

        private void UcenikForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxSpolovi();
            LoadComboBoxPostanskiBrojevi();
            LoadComboOpcina();
            LoadComboVsteVeza();

            if (!UcenikFormPregled.vrsta_osobe)
            {
                uceVrstaVeze.Enabled = false;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;
                label16.Visible = true;
                uteImeRoditelj.Visible = true;
                utePrezimeRoditelj.Visible = true;
                uteOIBRoditelj.Visible = true;
            }
            else
            {
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                uteImeRoditelj.Visible = false;
                utePrezimeRoditelj.Visible = false;
                uteOIBRoditelj.Visible = false;
            }

            if (this.FormEditMode == Enums.FormEditMode.Update ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadFormUcenik();
            }
            else if (FormEditMode == Enums.FormEditMode.Insert)
            {
                uceVrstaVeze.Value = 1;
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
                uceOpcina.Value = null;
                TextBoxJMBG.Text = string.Empty;
                TextBoxNaselje.Text = string.Empty;
                TextBoxOIB.Text = string.Empty;
                TextBoxPrezime.Text = string.Empty;
                TextBoxUlicaKucniBroj.Text = string.Empty;
                ComboBoxPostanskiBroj.SelectedIndex = -1;
                DateTimePickerDatumRodjenja.Value = DateTime.Now;
                CheckBoxDatumRodjenja.Checked = false;
                uteImeRoditelj.Text = string.Empty;
                utePrezimeRoditelj.Text = string.Empty;
                uteOIBRoditelj.Text = string.Empty;
                uteIBANRoditelj.Text = string.Empty;
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

        private void CheckBoxDatumRodjenja_CheckedChanged(object sender, EventArgs e)
        {
            this.DateTimePickerDatumRodjenja.Visible = this.CheckBoxDatumRodjenja.Checked;
        }

        private void btnUceniciZatvori_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        #endregion

        private void LoadComboBoxSpolovi()
        {
            BusinessLogic.Spolovi spolovi = new BusinessLogic.Spolovi();

            this.ComboBoxSpol.DataSource = spolovi.GetSpoloviComboBox();
            this.ComboBoxSpol.DataBind();

            this.ComboBoxSpol.SelectedIndex = 0;
        }

        private void LoadComboBoxPostanskiBrojevi()
        {
            BusinessLogic.PostanskiBrojevi postanskiBrojevi = new BusinessLogic.PostanskiBrojevi();

            this.ComboBoxPostanskiBroj.DataSource = postanskiBrojevi.GetPostanskiBrojeviComboBox();
            this.ComboBoxPostanskiBroj.DataBind();
        }

        private void LoadComboOpcina()
        {
            BusinessLogic.Ucenici objekt = new BusinessLogic.Ucenici();
            uceOpcina.DataSource = objekt.GetOpcine();
            uceOpcina.DataBind();
        }

        private void LoadComboVsteVeza()
        {
            BusinessLogic.Ucenici objekt = new BusinessLogic.Ucenici();
            uceVrstaVeze.DataSource = objekt.GetVrsteVeza(UcenikFormPregled.vrsta_osobe);
            uceVrstaVeze.DataBind();
        }

        private void LoadFormUcenik()
        {
            BusinessLogic.Ucenici ucenici = new BusinessLogic.Ucenici();

            var ucenik = ucenici.GetUcenik(this.ID.GetValueOrDefault(0));

            this.TextBoxIme.Text = ucenik.Ime;
            this.TextBoxPrezime.Text = ucenik.Prezime;
            this.TextBoxOIB.Text = ucenik.OIB;
            this.TextBoxJMBG.Text = ucenik.JMBG;
            this.ComboBoxSpol.Value = ucenik.SpolID.GetValueOrDefault(0);
            this.TextBoxUlicaKucniBroj.Text = ucenik.UlicaKucniBroj;
            this.TextBoxNaselje.Text = ucenik.Naselje;
            this.ComboBoxPostanskiBroj.Value = ucenik.PostanskiBrojID;
            this.CheckBoxDatumRodjenja.Checked = ucenik.DatumRodjenja.HasValue;
            this.DateTimePickerDatumRodjenja.Value = ucenik.DatumRodjenja;
            uceOpcina.Value = ucenik.ID_Opcina;
            uceVrstaVeze.Value = ucenik.ID_VrstaObiteljskeVeze;
            cbkAktivan.Checked = ucenik.Aktivan;
            uteImeRoditelj.Text = ucenik.ImeRoditelj;
            uteOIBRoditelj.Text = ucenik.OIBRoditelj;
            utePrezimeRoditelj.Text = ucenik.PrezimeRoditelj;
            uteIBANRoditelj.Text = ucenik.IBANRoditelj;
        }

        private bool SaveData()
        {
            this.lblValidationMessages.ResetText();

            BusinessLogic.Ucenici ucenici = new BusinessLogic.Ucenici();


            if (this.FormEditMode == Enums.FormEditMode.Insert ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                ucenici.Add(this.TextBoxIme.Text.Trim(),
                    this.TextBoxPrezime.Text.Trim(),
                    this.TextBoxOIB.Text.Trim(),
                    this.TextBoxJMBG.Text.Trim(),
                    (int)this.ComboBoxSpol.Value,
                    this.TextBoxUlicaKucniBroj.Text.Trim(),
                    this.TextBoxNaselje.Text.Trim(),
                    (this.ComboBoxPostanskiBroj.Value != null ? this.ComboBoxPostanskiBroj.Value.ToString() : null),
                    (DateTime?)(this.CheckBoxDatumRodjenja.Checked ? this.DateTimePickerDatumRodjenja.Value : null),
                    (uceOpcina.Value != null ? uceOpcina.Value.ToString() : ""),
                    (int?)uceVrstaVeze.Value, cbkAktivan.Checked,
                    this.uteImeRoditelj.Text.Trim(), utePrezimeRoditelj.Text.Trim(), uteOIBRoditelj.Text.Trim(), uteIBANRoditelj.Text.Trim());
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                ucenici.Update(this.ID.Value, this.TextBoxIme.Text.Trim(),
                    this.TextBoxPrezime.Text.Trim(),
                    this.TextBoxOIB.Text.Trim(),
                    this.TextBoxJMBG.Text.Trim(),
                    (int)this.ComboBoxSpol.Value,
                    this.TextBoxUlicaKucniBroj.Text.Trim(),
                    this.TextBoxNaselje.Text.Trim(),
                    (this.ComboBoxPostanskiBroj.Value != null ? this.ComboBoxPostanskiBroj.Value.ToString() : null),
                    (DateTime?)(this.CheckBoxDatumRodjenja.Checked ? this.DateTimePickerDatumRodjenja.Value : null),
                    (uceOpcina.Value != null ? uceOpcina.Value.ToString() : ""),
                    (int?)uceVrstaVeze.Value, cbkAktivan.Checked,
                    this.uteImeRoditelj.Text.Trim(), utePrezimeRoditelj.Text.Trim(), uteOIBRoditelj.Text.Trim(), uteIBANRoditelj.Text.Trim());
            }

            if (ucenici.IsValid)
            {
                return ucenici.Persist();
            }
            else
            {
                ucenici.DisplayValidationMessages(this);
            }

            return false;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
       
    }
}
