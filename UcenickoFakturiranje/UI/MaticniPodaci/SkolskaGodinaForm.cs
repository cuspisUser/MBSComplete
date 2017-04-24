using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using UcenickoFakturiranje.Enums;

namespace UcenickoFakturiranje.UI.MaticniPodaci
{
    public partial class SkolskaGodinaForm : Controls.BaseUserControl
    {
        private int? ID { get; set; }
        private FormEditMode FormEditMode { get; set; }

        public SkolskaGodinaForm(FormEditMode formEditMode, int? id)
        {
            InitializeComponent();

            this.TextBoxNaziv.Focus();
            this.DateTimePickerDatumPocetka.Value = DateTime.Today;
            this.DateTimePickerDatumZavrsetka.Value = DateTime.Today;

            this.FormEditMode = formEditMode;
            this.ID = id;
        }

        #region EventHandlers

        private void SkolskaGodinaForm_Load(object sender, EventArgs e)
        {
            if (this.FormEditMode == Enums.FormEditMode.Update ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadFormSkolskaGodina();
            }
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        private void ToolStripButtonSpremi_Click(object sender, EventArgs e)
        {
            if (CheckBoxAktivnost.Checked)
                AktivnaSkolskaGodina();

            if (SaveData())
            {
                TextBoxNaziv.Text = string.Empty;
                DateTimePickerDatumPocetka.Value = DateTime.Now;
                DateTimePickerDatumZavrsetka.Value = DateTime.Now;
                CheckBoxAktivnost.Checked = false;
            }
        }

        private void ToolStripButtonSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (CheckBoxAktivnost.Checked)
                AktivnaSkolskaGodina();

            if (SaveData())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }

        private void btnSkolskaGodinaZatvori_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        #endregion

        private void LoadFormSkolskaGodina()
        {
            BusinessLogic.SkolskeGodine skolskeGodine = new BusinessLogic.SkolskeGodine();

            var skolskaGodina = skolskeGodine.GetSkolskaGodina(this.ID.GetValueOrDefault(0));

            this.TextBoxNaziv.Text = skolskaGodina.Naziv;
            this.DateTimePickerDatumPocetka.Value = skolskaGodina.DatumPocetka;
            this.DateTimePickerDatumZavrsetka.Value = skolskaGodina.DatumZavrsetka;
            this.CheckBoxAktivnost.CheckedValue = skolskaGodina.Aktivnost;            
        }

        private bool SaveData()
        {
            this.lblValidationMessages.ResetText();

            BusinessLogic.SkolskeGodine skolskeGodine = new BusinessLogic.SkolskeGodine();


            if (this.FormEditMode == Enums.FormEditMode.Insert ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                skolskeGodine.Add(this.TextBoxNaziv.Text.Trim(), 
                    (DateTime)this.DateTimePickerDatumPocetka.Value,
                    (DateTime)this.DateTimePickerDatumZavrsetka.Value,
                    this.CheckBoxAktivnost.Checked);
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                skolskeGodine.Update(this.ID.Value,
                    this.TextBoxNaziv.Text.Trim(),
                    (DateTime)this.DateTimePickerDatumPocetka.Value,
                    (DateTime)this.DateTimePickerDatumZavrsetka.Value,
                    this.CheckBoxAktivnost.Checked);
            }

            if (skolskeGodine.IsValid)
            {
                return skolskeGodine.Persist();
            }
            else
            {
                skolskeGodine.DisplayValidationMessages(this);
            }

            return false;
        }

        /// <summary>
        /// Setiranje aktivnih skolskih godina na false prilikom  otvaranja nove aktivne skolske godine
        /// </summary>
        private void AktivnaSkolskaGodina()
        {
            Mipsed7.DataAccessLayer.SqlClient sql_client = new Mipsed7.DataAccessLayer.SqlClient();


            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = sql_client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update UF_SkolskaGodina set aktivnost = 0";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch (Exception greska)
            {
                lblValidationMessages.Text = "Dogodila se greška prilikom upisa školske godine: " + greska + "\nKontaktirajte Administratora ('ER0001')";
            }
        }
    }
}
