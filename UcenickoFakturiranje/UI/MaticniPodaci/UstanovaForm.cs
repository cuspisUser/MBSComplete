using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using UcenickoFakturiranje.Enums;

namespace UcenickoFakturiranje.UI.MaticniPodaci
{
    public partial class UstanovaForm : Controls.BaseUserControl
    {
        private int? ID { get; set; }
        private FormEditMode FormEditMode { get; set; }

        public UstanovaForm(FormEditMode formEditMode, int? id)
        {
            InitializeComponent();

            this.TextBoxNaziv.Focus();

            this.FormEditMode = formEditMode;
            this.ID = id;
        }

        #region Event Handlers

        private void UstanovaForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxPostanskiBrojevi();
            LoadComboBoxKorisnici();
            LoadRKPKorisnika();

            if (this.FormEditMode == Enums.FormEditMode.Update ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadFormUstanova();
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
                TextBoxNaziv.Text = string.Empty;
                TextBoxSkraceniNaziv.Text = string.Empty;
                TextBoxOIB.Text = string.Empty;
                TextBoxUlicaKucniBroj.Text = string.Empty;
                ComboBoxPostanskiBroj.SelectedIndex = -1;
                TextBoxKontaktPodaci.Text = string.Empty;
                TextBoxLogotip.Text = string.Empty;
                cbkMaticnaPodrucnaUstanova.Checked = false;
                cbkOtvorneStavke.Checked = false;
                cbkPDVNapomena.Checked = false;
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

        private void ButtonLogotipOdaberi_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "GIF|*.gif|JPG|*.jpg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.TextBoxLogotip.Text = openFileDialog.FileName;
            }
            double fileLength = new FileInfo(TextBoxLogotip.Text).Length / 1000;
            if (fileLength > 512)
            {
                MessageBox.Show("Odabrana slika je prevelika", "Velicina slike", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                this.TextBoxLogotip.Text = string.Empty;
            }
        }

        #endregion

        private void LoadComboBoxPostanskiBrojevi()
        {
            BusinessLogic.PostanskiBrojevi postanskiBrojevi = new BusinessLogic.PostanskiBrojevi();

            this.ComboBoxPostanskiBroj.DataSource = postanskiBrojevi.GetPostanskiBrojeviComboBox();
            this.ComboBoxPostanskiBroj.DataBind();
        }

        /// <summary>
        /// Punjenje ComboBoxa Korisnik
        /// </summary>
        private void LoadComboBoxKorisnici()
        {
            BusinessLogic.Ustanove ustanove = new BusinessLogic.Ustanove();

            ucbUstanoveKorisnik.DataSource = ustanove.GetKorisnici();
            ucbUstanoveKorisnik.DataBind();
        }

        private void LoadRKPKorisnika()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            label12.Text = "- " + client.ExecuteScalar("Select Top(1) RKP From Korisnik").ToString(); 
        }

        private void LoadFormUstanova()
        {
            BusinessLogic.Ustanove ustanove = new BusinessLogic.Ustanove();

            var ustanova = ustanove.GetUstanova(this.ID.GetValueOrDefault(0));

            ucbUstanoveKorisnik.Value = ustanova.KorisnikID;
            uteUstanoveSifraUstanove.Value = ustanova.SifraUstanove;
            this.TextBoxNaziv.Text = ustanova.Naziv;
            this.TextBoxSkraceniNaziv.Text = ustanova.SkraceniNaziv;
            this.TextBoxOIB.Text = ustanova.OIB;
            this.TextBoxUlicaKucniBroj.Text = ustanova.UlicaKucniBroj;
            this.TextBoxKontaktPodaci.Text = ustanova.KontaktPodaci;
            this.ComboBoxPostanskiBroj.Value = ustanova.PostanskiBrojID;
            if (ustanova.Logo != null)
                this.TextBoxLogotip.Text = TextBoxLogotip.Tag.ToString();
            this.cbkMaticnaPodrucnaUstanova.Checked = ustanova.Maticna.HasValue;
            txtModel.Text = ustanova.Model;
            txtPozivNaBroj01.Text = ustanova.PozivNaBroj01;
            if (ustanova.Maticna != null)
            {
                cbkMaticnaPodrucnaUstanova.Checked = (bool)ustanova.Maticna;
            }
            else
            {
                cbkMaticnaPodrucnaUstanova.Checked = false;
            }
            if (ustanova.Broj == 1)
            {
                rbrPrva.Checked = true;
            }
            else if(ustanova.Broj == 2)
            {
                rbrDruga.Checked = true;
            }
            else if (ustanova.Broj == 3)
            {
                rbrTreci.Checked = true;
            }
            txtModel2.Text = ustanova.ModelOdobrenja2;

            txtModel3.Text = ustanova.ModelOdobrenja;

            utePozivNaBro03.Text = ustanova.PozivNaBrojOdobrenja;

            cbkOtvorneStavke.Checked = ustanova.OtvoreneStavke;
            cbkPDVNapomena.Checked = ustanova.PDVNapomena;
        }

        private bool SaveData()
        {
            this.lblValidationMessages.ResetText();

            BusinessLogic.Ustanove ustanove = new BusinessLogic.Ustanove();

            if (TextBoxLogotip.Text == TextBoxLogotip.Tag.ToString())
                TextBoxLogotip.Text = string.Empty;

            byte? model = null;

            if (rbrPrva.Checked)
            {
                model = 1;
            }
            else if (rbrDruga.Checked)
            {
                model = 2;
            }
            else if (rbrTreci.Checked)
            {
                model = 3;
            }
            else
            {
                MessageBox.Show("Odaberite po kojem modelu će se raditi!!!");
                return false;
            }

            if (this.FormEditMode == Enums.FormEditMode.Insert ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {

                ustanove.Add(this.TextBoxNaziv.Text.Trim(), 
                    this.TextBoxSkraceniNaziv.Text.Trim(),
                    this.TextBoxOIB.Text.Trim(),
                    this.TextBoxUlicaKucniBroj.Text.Trim(),
                    (this.ComboBoxPostanskiBroj.Value != null ? this.ComboBoxPostanskiBroj.Value.ToString() : null),
                    this.TextBoxKontaktPodaci.Text.Trim(),
                    this.TextBoxLogotip.Text.Trim(),
                    cbkMaticnaPodrucnaUstanova.Checked, (int?)ucbUstanoveKorisnik.Value, (string)uteUstanoveSifraUstanove.Value.ToString(),
                    txtModel.Text.Trim(), txtPozivNaBroj01.Text.Trim(), txtModel2.Text.Trim(), (byte)model, txtModel3.Text.Trim(), utePozivNaBro03.Text.Trim(), 
                    cbkPDVNapomena.Checked, cbkOtvorneStavke.Checked);
                
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                ustanove.Update(this.ID.Value,
                    this.TextBoxNaziv.Text.Trim(),
                    this.TextBoxSkraceniNaziv.Text.Trim(),
                    this.TextBoxOIB.Text.Trim(),
                    this.TextBoxUlicaKucniBroj.Text.Trim(),
                    (this.ComboBoxPostanskiBroj.Value != null ? this.ComboBoxPostanskiBroj.Value.ToString() : null),
                    this.TextBoxKontaktPodaci.Text.Trim(),
                    this.TextBoxLogotip.Text.Trim(),
                    cbkMaticnaPodrucnaUstanova.Checked, (int?)ucbUstanoveKorisnik.Value, (string)uteUstanoveSifraUstanove.Value.ToString(),
                    txtModel.Text.Trim(), txtPozivNaBroj01.Text.Trim(), txtModel2.Text.Trim(), (byte)model, txtModel3.Text.Trim(), utePozivNaBro03.Text.Trim(),
                    cbkPDVNapomena.Checked, cbkOtvorneStavke.Checked);
            }

            if (ustanove.IsValid)
            {
                return ustanove.Persist();
            }
            else
            {
                ustanove.DisplayValidationMessages(this);
            }

            return false;
        }

        private void btnOdustaniIZatvori_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
