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

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    public partial class uscPredlosci : Controls.BaseUserControl
    {

        #region varijable

        /// <summary>
        /// da se pamte stavke predloska kod edita kad se mjenja combo odjeljenja
        /// </summary>
        bool kontrola_za_stavke = false;

        /// <summary>
        /// ne dozvoljava se spremanje dok se ne napravi zaduzivanje nekih ucenika
        /// </summary>
        bool kontrola_za_zaduzenje = false;

        #endregion

        #region Svojstva

        private int ID
        {
            get;
            set;
        }
        private FormEditMode FormEditMode
        {
            get;
            set;
        }

        private DataTable dt_predlosci_stavke
        {
            get;
            set;
        }

        #endregion

        #region Dogadaji

        private void tsbObracunOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        private void uscPredlosci_Load(object sender, EventArgs e)
        {
            LoadUstanoveSkolskeGodine();
            LoadCjenik();
            if (FormEditMode == Enums.FormEditMode.Update)
            {
                NapuniFormuZaEditiranje();
                kontrola_za_stavke = true;
            }
        }

        private void ucbPredlosciUstanovaSkolskaGodina_SelectionChanged(object sender, EventArgs e)
        {
            LoadRazrediOdjeljenja((int)ucbPredlosciUstanovaSkolskaGodina.Value);
        }

        private void ucbPredlosciRazredOdjeljenje_SelectionChanged(object sender, EventArgs e)
        {
            LoadUcenici((int)ucbPredlosciRazredOdjeljenje.Value);

        }

        private void btnPredlosciOznaciSve_Click(object sender, EventArgs e)
        {
            foreach (UltraGridRow row in ugdPredlosciUcenici.Rows)
            {
                if (!bool.Parse(row.Cells["SEL"].Value.ToString()))
                {
                    row.Cells["SEL"].Value = true;
                }

            }
        }

        private void btnPredlosciOdznaciSve_Click(object sender, EventArgs e)
        {
            foreach (UltraGridRow row in ugdPredlosciUcenici.Rows)
            {
                if (bool.Parse(row.Cells["SEL"].Value.ToString()))
                {
                    row.Cells["SEL"].Value = false;
                }

            }
        }

        private void ucbPredlosciCjenik_SelectionChanged(object sender, EventArgs e)
        {
            if (FormEditMode == Enums.FormEditMode.Update)
            {
                //int cjenik = 0;

                if (kontrola_za_stavke)
                {
                    NapuniFormuZaEditiranjeStavke();
                    kontrola_za_stavke = false;
                }
                foreach (UltraGridRow row in ugdPredlosciUcenici.Rows)
                {
                    row.Cells["SEL"].Value = false;
                    foreach (DataRow stavke_red in dt_predlosci_stavke.Rows)
                    {
                        if ((int)row.Cells["ID"].Value == (int)stavke_red["IDUcenik"] && (int)stavke_red["IDCjenik"] == (int)ucbPredlosciCjenik.Value)
                        {
                            row.Cells["SEL"].Value = true;
                        }
                    }
                }
            }

            try
            {
                LoadCjenikStavke((int)ucbPredlosciCjenik.Value);
            }
            catch
            {
                ugdPredlosciCjenikStavke.DataSource = null;
            }
        }

        private void btnPredlosciZaduzi_Click(object sender, EventArgs e)
        {
            BusinessLogic.Predlosci.pId_ustanova_skolska_godina = (int?)ucbPredlosciUstanovaSkolskaGodina.Value;
            BusinessLogic.Predlosci.pNaziv = utePredlosciNazivPredloska.Text.Trim();
            BusinessLogic.Predlosci.pAktivan = false;
            BusinessLogic.Predlosci.pId_predlozak = ID;
            BusinessLogic.Predlosci.pIDRazrednoOdjeljenje = (int?)ucbPredlosciRazredOdjeljenje.Value;
            BusinessLogic.Predlosci.pIDCjenik = (int?)ucbPredlosciCjenik.Value;

            BusinessLogic.Predlosci Predlosci = new BusinessLogic.Predlosci();
            StringBuilder message = Predlosci.ValidateDataInput();

            if (message.Length == 0)
            {
                ZaduziStavkePredloska();
                if (dt_predlosci_stavke.Rows.Count > 0)
                {
                    kontrola_za_zaduzenje = true;
                    lblValidationMessages.ResetText();
                    ucbPredlosciUstanovaSkolskaGodina.Enabled = false;
                    ucbPredlosciRazredOdjeljenje.Enabled = false;
                }
                else
                {
                    lblValidationMessages.Text = "Potrebno je odabrati učenika da bi se predložak mogao zaduziti";
                }
            }
            else
                lblValidationMessages.Text = message.ToString();
        }

        private void btnPredlosciRazduzi_Click(object sender, EventArgs e)
        {
            DialogResult poruka = MessageBox.Show("Svi učenici unutra predloška biti će razduženi\nJeste li sigurni da želite razužiti učenike?", "Razuduživanje učenika", MessageBoxButtons.YesNo);
            if (poruka == DialogResult.Yes)
            {
                DataView dvStavke = new DataView(dt_predlosci_stavke);
                dvStavke.RowFilter = "IDRazrednoOdjeljenje <> '" + ucbPredlosciRazredOdjeljenje.Value + "'";
                dt_predlosci_stavke = dvStavke.ToTable("PredlosciStavke");
                dvStavke.Dispose();

                foreach (UltraGridRow row in ugdPredlosciUcenici.Rows)
                {
                    if (bool.Parse(row.Cells["SEL"].Value.ToString()))
                    {
                        row.Cells["SEL"].Value = false;
                    }

                }
                ucbPredlosciUstanovaSkolskaGodina.Enabled = true;
                ucbPredlosciRazredOdjeljenje.Enabled = true;
            }
        }

        private void tsbObracunSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (kontrola_za_zaduzenje)
            {
                if (SaveData())
                {
                    base.ContainerForm.DialogResult = DialogResult.OK;
                    base.ContainerForm.Close();
                }
            }
            else
            {
                lblValidationMessages.Text = "Potrebno je izvršiti zaduženje učenika da bi se predložak mogao spremiti";
            }
        }

        private void tsbObracunSpremiNovi_Click(object sender, EventArgs e)
        {
            if (kontrola_za_zaduzenje)
            {
                if (SaveData())
                {
                    utePredlosciNazivPredloska.Text = string.Empty;
                    try
                    {
                        ucbPredlosciUstanovaSkolskaGodina.Enabled = true;
                        ucbPredlosciUstanovaSkolskaGodina.SelectedIndex = -1;
                    }
                    catch { }
                    try
                    {
                        ucbPredlosciRazredOdjeljenje.Enabled = true;
                        ucbPredlosciRazredOdjeljenje.DataSource = null;
                    }
                    catch { }
                    try
                    {
                        ucbPredlosciCjenik.Enabled = true;
                        ucbPredlosciCjenik.SelectedIndex = -1;
                    }
                    catch { }
                    ugdPredlosciUcenici.DataSource = null;
                    ugdPredlosciCjenikStavke.DataSource = null;
                    dt_predlosci_stavke.Rows.Clear();
                }
            }
            else
            {
                lblValidationMessages.Text = "Potrebno je izvršiti zaduženje učenika da bi se predložak mogao spremiti";
            }
        }

        private void ugdPredlosciUcenici_ClickCell(object sender, ClickCellEventArgs e)
        {
            BusinessLogic.Predlosci Predlosci = new BusinessLogic.Predlosci();

            if (ugdPredlosciUcenici.DisplayLayout.Bands.Count > 0)
                if (ugdPredlosciUcenici.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdPredlosciZaduzeniCjenik.DataSource = Predlosci.NapuniStavkeCjenikZaUcenika((int)ugdPredlosciUcenici.ActiveRow.Cells["ID"].Value);
                    ugdPredlosciZaduzeniCjenik.DataBind();
                    ugdPredlosciZaduzeniCjenik.UpdateData();

                    if (ugdPredlosciZaduzeniCjenik.DisplayLayout.Bands.Count > 0)
                        if (ugdPredlosciZaduzeniCjenik.DisplayLayout.Bands[0].Columns.Count > 0)
                        {
                            ugdPredlosciZaduzeniCjenik.DisplayLayout.Bands["Cjenik"].Columns["IDCjenik"].Hidden = true;
                            ugdPredlosciZaduzeniCjenik.DisplayLayout.Bands["Cjenik_stavka"].Columns["ID"].Hidden = true;
                            ugdPredlosciZaduzeniCjenik.DisplayLayout.Bands["Cjenik_stavka"].Columns["CjenikID"].Hidden = true;
                            ugdPredlosciZaduzeniCjenik.Rows.ExpandAll(true);
                        }
                }
        }

        #endregion

        #region Metode

        public uscPredlosci(FormEditMode formEditMode, int id)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
            ID = id;
            dt_predlosci_stavke = new DataTable("PredlosciStavke");
            dt_predlosci_stavke.Columns.Add("IDRazrednoOdjeljenje", typeof(int));
            dt_predlosci_stavke.Columns.Add("IDUcenik", typeof(int));
            dt_predlosci_stavke.Columns.Add("IDCjenik", typeof(int));

        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);

        }

        /// <summary>
        /// Punjenje ComboBoxa Ustanove i skolske godine
        /// </summary>
        private void LoadUstanoveSkolskeGodine()
        {
            BusinessLogic.Predlosci Predlosci = new BusinessLogic.Predlosci();

            ucbPredlosciUstanovaSkolskaGodina.DataSource = Predlosci.GetUstanoveSkolskeGodine().DefaultView;
            ucbPredlosciUstanovaSkolskaGodina.DataBind();
        }

        /// <summary>
        /// Punjenje ComboBoxa Razredi odjeljenja
        /// </summary>
        private void LoadRazrediOdjeljenja(int id_skolska_godina)
        {
            BusinessLogic.Predlosci Predlosci = new BusinessLogic.Predlosci();

            ucbPredlosciRazredOdjeljenje.DataSource = Predlosci.GetRazrediOdjeljenja(id_skolska_godina).DefaultView;
            ucbPredlosciRazredOdjeljenje.DataBind();
        }

        /// <summary>
        /// Punjenje grida ucenici
        /// </summary>
        private void LoadUcenici(int id_razredno_odjeljenje)
        {
            BusinessLogic.Predlosci Predlosci = new BusinessLogic.Predlosci();

            ugdPredlosciUcenici.DataSource = Predlosci.GetuceniciOdjeljenje(id_razredno_odjeljenje).DefaultView;
            ugdPredlosciUcenici.DataBind();

            //stiliziranje grida
            Utils.Tools.UltraGridStyling(ugdPredlosciUcenici);

            if (ugdPredlosciUcenici.DisplayLayout.Bands.Count > 0)
                if (ugdPredlosciUcenici.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdPredlosciUcenici.DisplayLayout.Bands[0].Columns[0].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdPredlosciUcenici.DisplayLayout.Bands[0].Columns[0].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
        }

        /// <summary>
        /// Punjenje Comboboxa Cjenik
        /// </summary>
        private void LoadCjenik()
        {
            BusinessLogic.Predlosci Predlosci = new BusinessLogic.Predlosci();

            ucbPredlosciCjenik.DataSource = Predlosci.GetCjenik().DefaultView;
            ucbPredlosciCjenik.DataBind();
        }

        /// <summary>
        /// Punjenje grida cjenik stavke
        /// </summary>
        private void LoadCjenikStavke(int id_cjenik)
        {
            BusinessLogic.Predlosci Predlosci = new BusinessLogic.Predlosci();

            ugdPredlosciCjenikStavke.DataSource = Predlosci.GetCjenikStavke(id_cjenik).DefaultView;
            ugdPredlosciCjenikStavke.DataBind();

            //stiliziranje grida
            Utils.Tools.UltraGridStyling(ugdPredlosciCjenikStavke);
        }

        private void ZaduziStavkePredloska()
        {
            //brisanje duplih stavki
            DataView dvStavke = new DataView(dt_predlosci_stavke);
            dvStavke.RowFilter = "IDCjenik <> '" + ucbPredlosciCjenik.Value + "'";
            dt_predlosci_stavke = dvStavke.ToTable("PredlosciStavke");
            dvStavke.Dispose();

            //dodavanje stavaka u tablicu
            foreach (UltraGridRow row in ugdPredlosciUcenici.Rows)
            {
                if (bool.Parse(row.Cells["SEL"].Value.ToString()))
                {
                    dt_predlosci_stavke.Rows.Add((int)ucbPredlosciRazredOdjeljenje.Value, (int)row.Cells["ID"].Value, (int)ucbPredlosciCjenik.Value);
                }
            }
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            BusinessLogic.Predlosci Predlosci = new BusinessLogic.Predlosci();

            if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
            {
                if (Predlosci.InsertPredlosci())
                {
                    foreach (DataRow stavka_red in dt_predlosci_stavke.Rows)
                    {
                        BusinessLogic.Predlosci.pIDRazrednoOdjeljenje = (int)stavka_red["IDRazrednoOdjeljenje"];
                        BusinessLogic.Predlosci.pIDCjenik = (int)stavka_red["IDCjenik"];
                        BusinessLogic.Predlosci.pIDUcenik = (int)stavka_red["IDUcenik"];
                        Predlosci.InsertPredlosciStavke();
                    }
                    return true;
                }
            }
            else if (this.FormEditMode == Enums.FormEditMode.Update)
            {
                if (Predlosci.UpdatePredlosci())
                {
                    if (Predlosci.DeletePredlosciStavke())
                    {
                        foreach (DataRow stavka_red in dt_predlosci_stavke.Rows)
                        {
                            BusinessLogic.Predlosci.pIDRazrednoOdjeljenje = (int)stavka_red["IDRazrednoOdjeljenje"];
                            BusinessLogic.Predlosci.pIDCjenik = (int)stavka_red["IDCjenik"];
                            BusinessLogic.Predlosci.pIDUcenik = (int)stavka_red["IDUcenik"];
                            Predlosci.InsertPredlosciStavke();
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Punjenje forme kod edita
        /// </summary>
        private void NapuniFormuZaEditiranje()
        {
            BusinessLogic.Predlosci Predlosci = new BusinessLogic.Predlosci();
            DataRow predlozak = Predlosci.DohvatPredloska(ID);
            utePredlosciNazivPredloska.Text = predlozak["Naziv"].ToString();
            ucbPredlosciUstanovaSkolskaGodina.Value = predlozak["IDUstanovaSkolskaGodina"].ToString();
            ucbPredlosciRazredOdjeljenje.Value = predlozak["IDRazrednoOdjeljenje"].ToString();
        }

        /// <summary>
        /// Punjenje forme kod edita Stavke
        /// </summary>
        private void NapuniFormuZaEditiranjeStavke()
        {
            BusinessLogic.Predlosci Predlosci = new BusinessLogic.Predlosci();
            dt_predlosci_stavke = Predlosci.DohvatPredloskaStavke(ID);

        }

        #endregion
    }
}
