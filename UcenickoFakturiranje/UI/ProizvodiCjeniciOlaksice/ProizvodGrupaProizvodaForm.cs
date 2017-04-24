using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UcenickoFakturiranje.Enums;
using Infragistics.Win.UltraWinGrid;
using System.Data.SqlClient;

namespace UcenickoFakturiranje.UI.ProizvodiCjeniciOlaksice
{
    public partial class ProizvodGrupaProizvodaForm : Controls.BaseUserControl
    {
        private int? ID { get; set; }
        private FormEditMode FormEditMode { get; set; }

        private UltraGrid Ppod_stavke { get; set; }

        public ProizvodGrupaProizvodaForm(FormEditMode formEditMode, int? id)
        {
            InitializeComponent();

            this.TextBoxNaziv.Focus();

            this.FormEditMode = formEditMode;
            this.ID = id;
        }

        #region Event Handlers

        private void ProizvodGrupaProizvodaForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxJediniceMjere();
            LoadComboBoxTipObracunskeKolicine();
            UcitajPoreze();

            if (this.FormEditMode == Enums.FormEditMode.Update ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                LoadFormProizvod();
                LoadFormProizvodStavke();
            }

            KontrolaButtonaDodajStavku();
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        private void ToolStripButtonSpremi_Click(object sender, EventArgs e)
        {
            if (SaveDataProizvodi())
            {
                SaveDataProizvodiStavke();

                TextBoxNaziv.Text = string.Empty;
                ComboBoxTipObracunskeKolicine.SelectedIndex = -1;
                ComboBoxJedinicaMjere.SelectedIndex = -1;
                CheckBoxIsGrupa.Checked = false;
                UltraGridPodProizvodi.DataSource = null;
                cmbProizvodPorez.SelectedIndex = -1;
                unmProizvodCijena.Value = null;
            }
        }

        private void ToolStripButtonSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveDataProizvodi())
            {
                SaveDataProizvodiStavke();
                    
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }

        private void ButtonPodProizvodDodaj_Click(object sender, EventArgs e)
        {
            ProizvodGrupaProizvodaOdabirForm proizvodGrupaProizvodaForm = new ProizvodGrupaProizvodaOdabirForm(ID);
            if (proizvodGrupaProizvodaForm.ShowDialogForm("Odabir pod-proizvoda") == DialogResult.OK) 
            {
                LoadFormProizvodStavke();
                Ppod_stavke = proizvodGrupaProizvodaForm.Ppod_stavke;

                DataTable stavke = PodaciStavkePostojeci(UltraGridPodProizvodi);
                stavke.Merge(PodaciStavkeDodaj(Ppod_stavke));

                UltraGridPodProizvodi.DataSource = stavke;
            }
            
            KontrolaButtonaDodajStavku();
        }

        private void CheckBoxIsGrupa_CheckedChanged(object sender, EventArgs e)
        {
            this.ButtonPodProizvodDodaj.Enabled = this.CheckBoxIsGrupa.Checked;
            this.UltraGridPodProizvodi.Enabled = this.CheckBoxIsGrupa.Checked;
        }

        private void btnProizvodiGrupeProizvodaOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        #endregion

        private void LoadComboBoxJediniceMjere()
        {
            BusinessLogic.JedinicaMjere jedinicaMjere = new BusinessLogic.JedinicaMjere();

            this.ComboBoxJedinicaMjere.DataSource = jedinicaMjere.GetJediniceMjereComboBox();
            this.ComboBoxJedinicaMjere.DataBind();
        }

        private void LoadComboBoxTipObracunskeKolicine()
        {
            BusinessLogic.ProizvodiGrupeProizvodaTipKolicine tipKolicine = new BusinessLogic.ProizvodiGrupeProizvodaTipKolicine();

            this.ComboBoxTipObracunskeKolicine.DataSource = tipKolicine.GetTipoviKolicineComboBox();
            this.ComboBoxTipObracunskeKolicine.DataBind();
        }

        private void LoadFormProizvod()
        {
            BusinessLogic.ProizvodiGrupeProizvoda grupaProizvoda = new BusinessLogic.ProizvodiGrupeProizvoda();
            var proizvodi = grupaProizvoda.GetProizvod(this.ID.GetValueOrDefault(0));

            TextBoxNaziv.Text = proizvodi.Naziv;
            ComboBoxJedinicaMjere.Value = proizvodi.JedinicaMjereID;
            ComboBoxTipObracunskeKolicine.Value = proizvodi.TipKolicineID;
            CheckBoxIsGrupa.Checked = proizvodi.IsGrupa;
            cmbProizvodPorez.Value = proizvodi.PorezID;
            unmProizvodCijena.Value = proizvodi.Cijena;
            
        }

        private void LoadFormProizvodStavke()
        {
            BusinessLogic.ProizvodiGrupeProizvodaStavke proizvodi = new BusinessLogic.ProizvodiGrupeProizvodaStavke();

            this.UltraGridPodProizvodi.DataSource = proizvodi.GetProizvodiStavkeMainGrid(this.ID.GetValueOrDefault(0));
            this.UltraGridPodProizvodi.DataBind();

            Utils.Tools.UltraGridStyling(this.UltraGridPodProizvodi);

            UltraGridPodProizvodi.DisplayLayout.Bands[0].Columns["Naziv"].Width = 200;

            if (UltraGridPodProizvodi.DisplayLayout.Bands.Count > 0)
                if (UltraGridPodProizvodi.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    UltraGridPodProizvodi.DisplayLayout.Bands[0].Columns[0].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    UltraGridPodProizvodi.DisplayLayout.Bands[0].Columns[0].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }       

        }

        /// <summary>
        /// Spremanje proizvoda u bazu
        /// </summary>
        /// <returns></returns>
        private bool SaveDataProizvodi()
        {
            this.lblValidationMessages.ResetText();

            BusinessLogic.ProizvodiGrupeProizvoda proizvodi = new BusinessLogic.ProizvodiGrupeProizvoda();

            bool is_grupa = false;

            if (CheckBoxIsGrupa.Checked && UltraGridPodProizvodi.Rows.Count > 0)
                is_grupa = true;

            if (this.FormEditMode == Enums.FormEditMode.Insert ||
                this.FormEditMode == Enums.FormEditMode.Copy)
            {
                string combo_jedinica_mjere = string.Empty;
                string combo_tip_obracunske_kolicine = string.Empty;
                string combo_stopa_poreza = string.Empty;
                string cijena = string.Empty;

                if (ComboBoxJedinicaMjere.Value != null)
                    combo_jedinica_mjere = ComboBoxJedinicaMjere.Value.ToString().Trim();
                if (ComboBoxTipObracunskeKolicine.Value != null)
                    combo_tip_obracunske_kolicine = ComboBoxTipObracunskeKolicine.Value.ToString().Trim();
                if (cmbProizvodPorez.Value != null)
                    combo_stopa_poreza = cmbProizvodPorez.Value.ToString().Trim();
                if (unmProizvodCijena.Value != null)
                    cijena = unmProizvodCijena.Value.ToString().Trim();

                proizvodi.Add(this.TextBoxNaziv.Text.Trim(),
                    combo_jedinica_mjere,
                    combo_tip_obracunske_kolicine, combo_stopa_poreza, cijena, is_grupa);
                    
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                string combo_jedinica_mjere = string.Empty;
                string combo_tip_obracunske_kolicine = string.Empty;
                string combo_stopa_poreza = string.Empty;
                string cijena = string.Empty;

                if (ComboBoxJedinicaMjere.Value != null)
                    combo_jedinica_mjere = ComboBoxJedinicaMjere.Value.ToString().Trim();
                if (ComboBoxTipObracunskeKolicine.Value != null)
                    combo_tip_obracunske_kolicine = ComboBoxTipObracunskeKolicine.Value.ToString().Trim();
                if (cmbProizvodPorez.Value != null)
                    combo_stopa_poreza = cmbProizvodPorez.Value.ToString().Trim();
                if (unmProizvodCijena.Value != null)
                    cijena = unmProizvodCijena.Value.ToString().Trim();

                proizvodi.Update(this.ID.Value,
                    this.TextBoxNaziv.Text.Trim(),
                    combo_jedinica_mjere,
                    combo_tip_obracunske_kolicine, combo_stopa_poreza, cijena, is_grupa);

            }
            bool persist = false;
            if (proizvodi.IsValid)
            {
                persist = proizvodi.Persist();
                if (FormEditMode == Enums.FormEditMode.Insert)
                    ID = proizvodi.GetMaxId();
                if (persist)
                    return true;
            }
            else
            {
                proizvodi.DisplayValidationMessages(this);
            }

            return false;
        }

        /// <summary>
        /// Spremanje stavki od proizvoda u bazu
        /// </summary>
        /// <returns></returns>
        private bool SaveDataProizvodiStavke()
        {
            BusinessLogic.ProizvodiGrupeProizvodaStavke stavke = new BusinessLogic.ProizvodiGrupeProizvodaStavke();

            bool res = false;

            BrisanjePostojecihStavki(ID.Value);

            foreach (UltraGridRow row in UltraGridPodProizvodi.Rows)
            {
                stavke.Add(ID.Value, int.Parse(row.Cells["ID"].Value.ToString()));
                res = true;
            }
            if (res == false)
            {
                return res;
            }
            if (stavke.IsValid)
            {
                return stavke.Persist();
            }
            else
            {
                stavke.DisplayValidationMessages(this);
            }
            return res;
        }

        /// <summary>
        /// Prikazivanje ili sakrivanje buttona ovisno o tome dali postoje stavke u gridu
        /// </summary>
        private void KontrolaButtonaDodajStavku()
        {
            if (UltraGridPodProizvodi.Rows.Count > 0)
            {
                btnBrisiOznacene.Visible = true;
                btnOdznaciSve.Visible = true;
                btnOznaciSve.Visible = true;
            }
            else
            {
                btnBrisiOznacene.Visible = false;
                btnOdznaciSve.Visible = false;
                btnOznaciSve.Visible = false;
            }
        }

        DataTable PodaciStavkeDodaj(UltraGrid stavke)
        {
            DataTable dtGridView = new DataTable();
            dtGridView.Columns.Add("SEL", typeof(bool));
            dtGridView.Columns.Add("ID", typeof(string));
            dtGridView.Columns.Add("Naziv", typeof(string));
            dtGridView.Columns.Add("JedinicaMjere", typeof(string));
            foreach (UltraGridRow row in stavke.Rows)
            {
                if (bool.Parse(row.Cells["SEL"].Value.ToString()))
                {
                    dtGridView.Rows.Add(row.Cells["SEL"].Value.ToString(), row.Cells["ID"].Value.ToString(), row.Cells["Naziv"].Value.ToString(), row.Cells["JedinicaMjere"].Value.ToString());
                }

            }
            return dtGridView;
        }
        DataTable PodaciStavkePostojeci(UltraGrid stavke)
        {
            DataTable dtGridView = new DataTable();
            dtGridView.Columns.Add("SEL", typeof(bool));
            dtGridView.Columns.Add("ID", typeof(string));
            dtGridView.Columns.Add("Naziv", typeof(string));
            dtGridView.Columns.Add("JedinicaMjere", typeof(string));
            foreach (UltraGridRow row in stavke.Rows)
            {
                dtGridView.Rows.Add(row.Cells["SEL"].Value.ToString(), row.Cells["ID"].Value.ToString(), row.Cells["Naziv"].Value.ToString(), row.Cells["JedinicaMjere"].Value.ToString());
            }
            return dtGridView;
        }

        private void btnOznaciSve_Click(object sender, EventArgs e)
        {
            foreach (UltraGridRow row in UltraGridPodProizvodi.Rows)
            {
                if (!bool.Parse(row.Cells["SEL"].Value.ToString()))
                {
                    row.Cells["SEL"].Value = true;
                }

            }
        }

        private void btnOdznaciSve_Click(object sender, EventArgs e)
        {
            foreach (UltraGridRow row in UltraGridPodProizvodi.Rows)
            {
                if (bool.Parse(row.Cells["SEL"].Value.ToString()))
                {
                    row.Cells["SEL"].Value = false;
                }

            }
        }

        private void btnBrisiOznacene_Click(object sender, EventArgs e)
        {
            for (int i = UltraGridPodProizvodi.Rows.Count - 1; i > -1; i--)
            {
                if (bool.Parse(UltraGridPodProizvodi.Rows[i].Cells["SEL"].Value.ToString()))
                {
                    UltraGridPodProizvodi.Rows[i].Delete();
                }
            }
        }

        private void UltraGridPodProizvodi_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        /// <summary>
        /// Brisanje postojecih stavki kod editiranja proizvoda
        /// </summary>
        /// <param name="id"></param>
        private void BrisanjePostojecihStavki(int id)
        {
            Mipsed7.DataAccessLayer.SqlClient sql_client = new Mipsed7.DataAccessLayer.SqlClient();

            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = sql_client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Delete from UF_ProizvodStavka where ProizvodID = '" + id + "'";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch { }
        }

        /// <summary>
        /// Punjenje comboboxa sa porezima
        /// </summary>
        private void UcitajPoreze()
        {
            BusinessLogic.Porez porez = new BusinessLogic.Porez();

            cmbProizvodPorez.DataSource = porez.GetPorezComboBox();
            cmbProizvodPorez.DataBind();
        }
    }
}
