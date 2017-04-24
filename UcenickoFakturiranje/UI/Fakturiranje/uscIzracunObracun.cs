using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using UcenickoFakturiranje.Enums;
using Microsoft.Practices.CompositeUI.SmartParts;
using Deklarit.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using Infragistics.Win.UltraWinGrid;

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    public partial class uscIzracunObracun : Controls.BaseUserControl, ISmartPartInfoProvider, IFilteredView
    {

        #region Univerzalan kod koji se koristi za forme (Controller, WorkWith, itd...)

        private SmartPartInfoProvider infoProvider { get; set; }
        private DataRow m_FillByRow;
        private DataRow m_RowSelected { get; set; }
        private string m_FillByMethod = "";
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        [CreateNew]
        public Microsoft.Practices.CompositeUI.Controller Controller { get; set; }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.FillByRow
        {
            set
            {
                this.m_FillByRow = value;
            }
        }

        string Deklarit.Practices.CompositeUI.IFilteredView.FillMethod
        {
            set
            {
                this.m_FillByMethod = value;
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode Deklarit.Practices.CompositeUI.IFilteredView.WorkWithMode
        {
            set
            {
                this.m_WorkWithMode = value;
            }
        }

        public DataRow FillByRow
        {
            set
            {
                this.m_FillByRow = value;
            }
        }

        public string FillMethod
        {
            set
            {
                this.m_FillByMethod = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
                this.m_WorkWithMode = value;
            }
        }

        #endregion

        #region Svojstva

        private FormEditMode FormEditMode
        {
            get;
            set;
        }
        private DataSet ds_ustanove_razred_ucenik
        {
            get;
            set;
        }

        #endregion

        #region Dogadaji

        private void btnIzracunObracunBrisi_Click(object sender, EventArgs e)
        {
            BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();

            if (ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands.Count > 0)
                if (ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    if (ugdObracunUstanoveRazrediUcenik.ActiveRow.Band.ToString() == "Ucenici")
                    {
                        Obracuni.pIDRazrednoOdjeljenje = (int)ugdObracunUstanoveRazrediUcenik.ActiveRow.Cells["IDRazrednoOdjeljenje"].Value;
                        Obracuni.pIDUcenik = (int)ugdObracunUstanoveRazrediUcenik.ActiveRow.Cells["ID"].Value;
                        Obracuni.pIDUstanovaSkolskaGodina = (int)ugdObracunUstanoveRazrediUcenik.ActiveRow.Cells["IDUstanovaSkolskaGodina"].Value;

                        Obracuni.BrisiUcenika();

                        UcitajUstanoveRazredUcenikZaPregled();
                    }
                }
        }

        private void uscIzracunObracun_Load(object sender, EventArgs e)
        {
            uteIzracunObracunNazivPredloska.Text = BusinessLogic.Obracuni.pNaziv;
            uneIzracunObracunGodina.Value = BusinessLogic.Obracuni.pGodinaObracuna;
            uneIzracunObracunMjesec.Value = BusinessLogic.Obracuni.pMjesecObracuna;
            udtIzracunObracunValutaPlacanja.Value = BusinessLogic.Obracuni.pValutaPlacanja;

            if (BusinessLogic.Obracuni.pPregledObracuna)
            {
                UcitajUstanoveRazredUcenikZaPregled();
                btnIzracunObracunBrisi.Visible = true;
                if (BusinessLogic.Obracuni.zaduzen)
                {
                    btnObracunIzmjeni.Enabled = false;
                    uneIzracunObracunGodina.ReadOnly = true;
                    uneIzracunObracunMjesec.ReadOnly = true;
                    udtIzracunObracunValutaPlacanja.ReadOnly = true;
                    uteIzracunObracunNazivPredloska.ReadOnly = true;
                    btnIzracunObracunBrisi.Enabled = false;
                }
            }
            else
            {
                UcitajUstanoveRazredUcenik();
                btnIzracunObracunBrisi.Visible = false;
                if (BusinessLogic.Obracuni.zaduzen)
                {
                    btnObracunIzmjeni.Enabled = true;
                    uneIzracunObracunGodina.ReadOnly = false;
                    uneIzracunObracunMjesec.ReadOnly = false;
                    udtIzracunObracunValutaPlacanja.ReadOnly = false;
                    uteIzracunObracunNazivPredloska.ReadOnly = false;
                    btnIzracunObracunBrisi.Enabled = true;
                }
            }

            btnObracunSpremiIzmjene.Visible = false;
        }

        private void ugdObracunUstanoveRazrediUcenik_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();

            if (ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands.Count > 0)
                if (ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    if (ugdObracunUstanoveRazrediUcenik.ActiveRow.Band.ToString() == "Ustanove")
                        NapuniObracunStavke((int)ugdObracunUstanoveRazrediUcenik.ActiveRow.Cells["ID"].Value, 0, 0, ugdObracunUstanoveRazrediUcenik.ActiveRow.Band.ToString());
                    if (ugdObracunUstanoveRazrediUcenik.ActiveRow.Band.ToString() == "Razredi")
                        NapuniObracunStavke((int)ugdObracunUstanoveRazrediUcenik.ActiveRow.Cells["ID"].Value, (int)ugdObracunUstanoveRazrediUcenik.ActiveRow.Cells["IDUstanovaSkolskaGodina"].Value,
                            0, ugdObracunUstanoveRazrediUcenik.ActiveRow.Band.ToString());
                    if (ugdObracunUstanoveRazrediUcenik.ActiveRow.Band.ToString() == "Ucenici")
                    {
                        Obracuni.pIDRazrednoOdjeljenje = (int)ugdObracunUstanoveRazrediUcenik.ActiveRow.Cells["IDRazrednoOdjeljenje"].Value;
                        Obracuni.pIDUcenik = (int)ugdObracunUstanoveRazrediUcenik.ActiveRow.Cells["ID"].Value;
                        Obracuni.pIDUstanovaSkolskaGodina = (int)ugdObracunUstanoveRazrediUcenik.ActiveRow.Cells["IDUstanovaSkolskaGodina"].Value;
                        if (!Obracuni.NadiStavku())
                        {
                            NapuniObracunStavke(Obracuni.pIDUcenik, Obracuni.pIDUstanovaSkolskaGodina, Obracuni.pIDRazrednoOdjeljenje, ugdObracunUstanoveRazrediUcenik.ActiveRow.Band.ToString());
                        }
                        else
                        {
                            NapuniObracunStavkePostojeci(Obracuni.pIDRazrednoOdjeljenje, Obracuni.pIDUcenik);
                        }
                    }
                }
        }

        private void btnObracunDodajRed_Click(object sender, EventArgs e)
        {
            if (ugdIzracunObracunCjenik.DisplayLayout.Bands.Count > 0)
                if (ugdIzracunObracunCjenik.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdIzracunObracunCjenik.DisplayLayout.Bands[0].Columns[3].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    btnObracunSpremiIzmjene.Visible = true;
                }
        }

        private void btnObracunIzuzmiRed_Click(object sender, EventArgs e)
        {
            if (ugdIzracunObracunCjenik.DisplayLayout.Bands.Count > 0)
                if (ugdIzracunObracunCjenik.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ObracunStavkeUcenikSpremi();
                }
        }

        private void ugdIzracunObracunCjenik_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (ugdIzracunObracunCjenik.DisplayLayout.Bands.Count > 0)
                if (ugdIzracunObracunCjenik.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ObracunStavkeIzracunajUkupno();
                }
        }

        private void tsbIzracunObracunSpremiZatvori_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (SpremiIzmjene())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void tsbIzracunObracunOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        #endregion

        #region Metode

        public uscIzracunObracun(FormEditMode formEditMode, int? id)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
            BusinessLogic.Obracuni.pID = id;
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }



        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();
            if (string.IsNullOrEmpty(BusinessLogic.Obracuni.pNaziv))
            {
                message.Append(" - Naziv obračuna je obavezno polje");
            }
            else if (BusinessLogic.Obracuni.pNaziv.Length > 36)
            {
                message.Append(" - Naziv obračuna može sadržavati maksimalno 36 znakova");
            }
            if (BusinessLogic.Obracuni.pkolicinaZaObracun == null)
            {
                message.Append(" - Količina obračun je obavezno polje");
            }
            if (BusinessLogic.Obracuni.pGodinaObracuna == null)
            {
                message.Append(" - Za godinu je obavezno polje");
            }
            if (BusinessLogic.Obracuni.pMjesecObracuna == null)
            {
                message.Append(" - Za mjesec je obavezno polje");
            }

            return message;
        }

        private void UcitajUstanoveRazredUcenik()
        {
            BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();

            ds_ustanove_razred_ucenik = Obracuni.GetUstanoveRazrediUcenici();

            ugdObracunUstanoveRazrediUcenik.DataSource = ds_ustanove_razred_ucenik;

            ugdObracunUstanoveRazrediUcenik.DataBind();
            ugdObracunUstanoveRazrediUcenik.UpdateData();

            if (ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands.Count > 0)
                if (ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands["Razredi"].Columns["IDUstanovaSkolskaGodina"].Hidden = true;
                    ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands["Ucenici"].Columns["IDRazrednoOdjeljenje"].Hidden = true;
                    ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands["Ucenici"].Columns["IDUstanovaSkolskaGodina"].Hidden = true;
                    ugdObracunUstanoveRazrediUcenik.Rows.ExpandAll(true);
                    ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands["Razredi"].Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                    ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands["Ucenici"].Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                    ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands["Ustanove"].Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                }
        }

        private void UcitajUstanoveRazredUcenikZaPregled()
        {
            BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();

            ds_ustanove_razred_ucenik = Obracuni.GetUstanoveRazrediUceniciZaPregled(FormEditMode);

            ugdObracunUstanoveRazrediUcenik.DataSource = ds_ustanove_razred_ucenik;

            ugdObracunUstanoveRazrediUcenik.DataBind();
            ugdObracunUstanoveRazrediUcenik.UpdateData();

            if (ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands.Count > 0)
                if (ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands["Razredi"].Columns["IDUstanovaSkolskaGodina"].Hidden = true;
                    ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands["Ucenici"].Columns["IDRazrednoOdjeljenje"].Hidden = true;
                    ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands["Ucenici"].Columns["IDUstanovaSkolskaGodina"].Hidden = true;
                    ugdObracunUstanoveRazrediUcenik.Rows.ExpandAll(true);
                    ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands["Razredi"].Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                    ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands["Ucenici"].Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                    ugdObracunUstanoveRazrediUcenik.DisplayLayout.Bands["Ustanove"].Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                }
        }

        private void NapuniObracunStavke(int id, int id_razred, int id_ucenik, string tablica)
        {
            BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();

            if (tablica == "Ustanove")
                ugdIzracunObracunCjenik.DataSource = Obracuni.GetObracunUstanoveStavke(id, BusinessLogic.Obracuni.pkolicinaZaObracun);
            if (tablica == "Ucenici")
                ugdIzracunObracunCjenik.DataSource = Obracuni.GetObracunUceniciStavke(id, id_razred, id_ucenik, BusinessLogic.Obracuni.pkolicinaZaObracun);
            if (tablica == "Razredi")
                ugdIzracunObracunCjenik.DataSource = Obracuni.GetObracunRazrediStavke(id, id_razred, BusinessLogic.Obracuni.pkolicinaZaObracun);

            ugdIzracunObracunCjenik.DataBind();

            //stiliziranje grida
            Utils.Tools.UltraGridStyling(ugdIzracunObracunCjenik);

            if (tablica == "Ucenici")
            {
                if (ugdIzracunObracunCjenik.DisplayLayout.Bands.Count > 0)
                    if (ugdIzracunObracunCjenik.DisplayLayout.Bands[0].Columns.Count > 0)
                    {
                        ugdIzracunObracunCjenik.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                        ugdIzracunObracunCjenik.DisplayLayout.Bands[0].Columns["IDRazrednoOdjeljenje"].Hidden = true;
                    }
                btnObracunIzmjeni.Visible = true;
                btnObracunSpremiIzmjene.Visible = false;
            }
            else
            {
                btnObracunIzmjeni.Visible = false;
                btnObracunSpremiIzmjene.Visible = false;
            }

        }

        private void NapuniObracunStavkePostojeci(int id_razred, int id_ucenik)
        {
            BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();

            ugdIzracunObracunCjenik.DataSource = Obracuni.GetObracunUceniciStavkePostojeci(id_razred, id_ucenik);

            ugdIzracunObracunCjenik.DataBind();

            //stiliziranje grida
            Utils.Tools.UltraGridStyling(ugdIzracunObracunCjenik);

            if (ugdIzracunObracunCjenik.DisplayLayout.Bands.Count > 0)
                if (ugdIzracunObracunCjenik.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    ugdIzracunObracunCjenik.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                    ugdIzracunObracunCjenik.DisplayLayout.Bands[0].Columns["IDRazrednoOdjeljenje"].Hidden = true;
                }
            btnObracunIzmjeni.Visible = true;
            btnObracunSpremiIzmjene.Visible = false;
        }

        public bool SaveObracun()
        {
            lblValidationMessages.ResetText();

            BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();

            if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
            {
                Obracuni.InsertObracun();
            }
            else if (FormEditMode == Enums.FormEditMode.Update)
            {
                Obracuni.EditObracun();
            }
            bool persist = false;
            persist = Obracuni.Persist();
            if (FormEditMode == Enums.FormEditMode.Insert)
                BusinessLogic.Obracuni.pID = Obracuni.NajveciID();
            if (persist)
            {
                FormEditMode = Enums.FormEditMode.Update;
                return true;
            }
            return false;
        }

        private void ObracunStavkeUcenikSpremi()
        {
            BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();

            decimal parse = 0;

            Obracuni.pIDUcenik = (int)ugdObracunUstanoveRazrediUcenik.ActiveRow.Cells["ID"].Value;
            Obracuni.pIDRazrednoOdjeljenje = (int)ugdObracunUstanoveRazrediUcenik.ActiveRow.Cells["IDRazrednoOdjeljenje"].Value;

            if (!Obracuni.NadiStavku())
            {
                if (Obracuni.InsertObracunStavka())
                {

                    Obracuni.pPozivNaBrojOdobrenja = Obracuni.VratiPozivNaBroj();

                    foreach (UltraGridRow row in ugdIzracunObracunCjenik.Rows)
                    {
                        Obracuni.pIDCjenikStavka = (int)row.Cells["ID"].Value;
                        Obracuni.pStvarnaKolicina = (int)row.Cells["Količina"].Value;

                        if (Decimal.TryParse(row.Cells["Ukupno za platiti"].Value.ToString(), out parse))
                            Obracuni.pIznosStavka = Convert.ToDecimal(row.Cells["Ukupno za platiti"].Value);
                        else
                            Obracuni.pIznosStavka = 0;

                        Obracuni.InsertObracunStavkaCjenik();

                        Obracuni.pZaPlatiti = Obracuni.pIznosStavka + Obracuni.pZaPlatiti;
                    }
                    Obracuni.InsertUcenikZaduzenje();

                }
                else
                {
                    lblValidationMessages.Text = "Dogodila se greška prilikom upisa stavke obračuna u bazu.\nKontaktirajte administratora [Error:00002]";
                }
            }
            else
            {
                Obracuni.EditObracunStavka();

                Obracuni.DeleteObracunStavkaCjenik();
                foreach (UltraGridRow row in ugdIzracunObracunCjenik.Rows)
                {
                    Obracuni.pIDCjenikStavka = (int)row.Cells["ID"].Value;
                    Obracuni.pStvarnaKolicina = (int)row.Cells["Količina"].Value;

                    if (Decimal.TryParse(row.Cells["Ukupno za platiti"].Value.ToString(), out parse))
                        Obracuni.pIznosStavka = Convert.ToDecimal(row.Cells["Ukupno za platiti"].Value);
                    else
                        Obracuni.pIznosStavka = 0;

                    Obracuni.InsertObracunStavkaCjenik();

                    Obracuni.pZaPlatiti = Obracuni.pIznosStavka + Obracuni.pZaPlatiti;
                }

                Obracuni.EditUcenikZaduzenje();

                Obracuni.pPozivNaBrojOdobrenja = Obracuni.VratiPozivNaBroj();
            }
        }

        private void ObracunStavkeIzracunajUkupno()
        {
            ugdIzracunObracunCjenik.ActiveRow.Cells["Ukupno za platiti"].Value = Convert.ToDecimal(ugdIzracunObracunCjenik.ActiveRow.Cells["Količina"].Value) *
                                                                                Convert.ToDecimal(ugdIzracunObracunCjenik.ActiveRow.Cells["Cijena s olakšicom"].Value);
        }

        private bool SpremiIzmjene()
        {
            if (uneIzracunObracunMjesec.Value == null)
            {
                BusinessLogic.Obracuni.pMjesecObracuna = (int?)uneIzracunObracunMjesec.Value;
            }
            else
            {
                BusinessLogic.Obracuni.pMjesecObracuna = Convert.ToInt32(uneIzracunObracunMjesec.Value);
            }

            BusinessLogic.Obracuni.pGodinaObracuna = (int?)uneIzracunObracunGodina.Value;
            BusinessLogic.Obracuni.pValutaPlacanja = udtIzracunObracunValutaPlacanja.DateTime;
            BusinessLogic.Obracuni.pNaziv = uteIzracunObracunNazivPredloska.Text;

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                if (SaveObracun())
                {
                    BusinessLogic.Obracuni Obracuni = new BusinessLogic.Obracuni();

                    //if (FormEditMode == Enums.FormEditMode.Update)
                    //{
                    //    if (!Obracuni.BrisiStareStavkeObracuna())
                    //    {
                    //        lblValidationMessages.Text = "Dogodila se greška prilikom spremanja obračuna.\nKontaktirajte administratora [Error:00005]";
                    //        return false;
                    //    }
                    //}

                    foreach (UltraGridRow row in ugdObracunUstanoveRazrediUcenik.Rows.GetRowEnumerator(GridRowType.DataRow, null, null))
                    {
                        if (row.Band.ToString() == "Ucenici")
                        {
                            InsertUcenik((int)row.Cells["ID"].Value, (int)row.Cells["IDRazrednoOdjeljenje"].Value, (int)row.Cells["IDUstanovaSkolskaGodina"].Value, Obracuni);
                        }
                    }
                    return true;
                }
                else
                {
                    lblValidationMessages.Text = "Dogodila se greška prilikom upisa obračuna.\nKontaktirajte administratora [Error:00004]";
                    return false;
                }
            }
            else
            {
                lblValidationMessages.Text = message.ToString();
                return false;
            }
        }

        private void InsertUcenik(int id_ucenik, int id_razred, int id_odjeljenje, BusinessLogic.Obracuni Obracuni)
        {
            DataTable dt_ucenik_stavke = Obracuni.GetObracunUceniciStavke(id_ucenik, id_odjeljenje, id_razred, BusinessLogic.Obracuni.pkolicinaZaObracun);

            decimal parse = 0;

            Obracuni.pIDUcenik = id_ucenik;
            Obracuni.pIDRazrednoOdjeljenje = id_razred;

            if (!Obracuni.NadiStavku())
            {
                if (Obracuni.InsertObracunStavka())
                {
                    Obracuni.pPozivNaBrojOdobrenja = Obracuni.VratiPozivNaBroj();
                    Obracuni.pZaPlatiti = 0;

                    foreach (DataRow row in dt_ucenik_stavke.Rows)
                    {
                        Obracuni.pIDCjenikStavka = (int)row["ID"];
                        Obracuni.pStvarnaKolicina = (int)row["Količina"];

                        if (Decimal.TryParse(row["Ukupno za platiti"].ToString(), out parse))
                            Obracuni.pIznosStavka = Convert.ToDecimal(row["Ukupno za platiti"]);
                        else
                            Obracuni.pIznosStavka = 0;

                        Obracuni.InsertObracunStavkaCjenik();

                        Obracuni.pZaPlatiti = Obracuni.pIznosStavka + Obracuni.pZaPlatiti;
                    }
                    Obracuni.InsertUcenikZaduzenje();
                }
                else
                {
                    lblValidationMessages.Text = "Dogodila se greška prilikom upisa stavke obračuna u bazu.\nKontaktirajte administratora [Error:00001]";
                }
            }
        }

        #endregion

    }
}
