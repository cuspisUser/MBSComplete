using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Materijalno.Enums;

namespace Materijalno.UI.Dokumenti
{
    public partial class PrimkaStavkeForm : Controls.BaseUserControl
    {
        #region Properties

        private FormEditMode FormEditMode { get; set; }

        //temp property za prijenos iz forme primka
        public string pBrojPrimke { get; set; }
        public DateTime pDatumPrimke { get; set; }
        public int pPartner { get; set; }
        public Nullable<int> pVrstaDokumenta { get; set; }
        public Nullable<int> pSkaldiste { get; set; }
        public Nullable<decimal> pNeto { get; set; }
        public Nullable<decimal> pPDV { get; set; }
        public Nullable<decimal> pBruto { get; set; }
        public Nullable<int> pNarudzbenica { get; set; }

        #endregion

        #region Methods

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public PrimkaStavkeForm(FormEditMode formEditMode)
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
                BusinessLogic.Primka.pBrojUlaznogDokumenta = uteBroj.Text;
                return true;
            }

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (uteBroj.Text.Length == 0)
            {
                message.Append("- Broj ulaznog dokumenta je obavezan podatak");
            }

            return message;
        }

        public Nullable<T> IsDbNull<T>(object value) where T : struct
        {
            if (value != DBNull.Value && value != null)
            {
                // return (T)value; // CAST
                return (T)Convert.ChangeType(value, typeof(T)); // CONVERT
            }

            return null;
        }

        private void LoadFirstTimeStavke(BusinessLogic.Primka objekt)
        {
            if (BusinessLogic.Primka.pID != null && BusinessLogic.Primka.pPrimkaStavke.Rows.Count == 0)
            {
                
                BusinessLogic.Primka.pPrimkaStavke = objekt.GetPrimkaStavke();

                DataView sort = BusinessLogic.Primka.pPrimkaStavke.DefaultView;
                sort.Sort = "RedniBroj";
                BusinessLogic.Primka.pPrimkaStavke = sort.ToTable();

                BusinessLogic.Primka.pPrimkaStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Primka.pPrimkaStavke.Columns["ID_Proizvoda"] };

                ugdPrimkaStavke.DataSource = BusinessLogic.Primka.pPrimkaStavke;
                ugdPrimkaStavke.DataBind();

                Utils.Tools.UltraGridStyling(ugdPrimkaStavke);

                if (ugdPrimkaStavke.DisplayLayout.Bands.Count > 0)
                {
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_Primke"].Hidden = true;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_JedinicaMjere"].Hidden = true;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_Porez"].Hidden = true;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_Proizvoda"].Hidden = true;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["BrojUlaznogDokumenta"].Hidden = true;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Porez"].Hidden = true;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["JedinicaMjere"].Hidden = true;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Format = "F2";
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Cijena"].Format = "F2";
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Header.Caption = "Neto + ne može se odbiti";
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Width = 130;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Cijena"].Header.Caption = "Neto";
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Header.Caption = "Količina";
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["UkupnaNabavnaCijena"].Header.Caption = "Ukupna nabavna vrijednost";
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["UkupnaNabavnaCijena"].Format = "F2";

                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["RedniBroj"].Header.VisiblePosition = 1;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Proizvod"].Header.VisiblePosition = 2;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Header.VisiblePosition = 3;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Cijena"].Header.VisiblePosition = 4;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Header.VisiblePosition = 5;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["UkupnaNabavnaCijena"].Header.VisiblePosition = 6;
                }

                if (BusinessLogic.Primka.pPrimkaStavke.Rows.Count == 0)
                {
                    btnBrisiStavku.Enabled = false;
                    btnUrediStavku.Enabled = false;
                }
                else
                {
                    btnBrisiStavku.Enabled = true;
                    btnUrediStavku.Enabled = true;
                }
            }
        }

        private void LoadStavke()
        {
            DataView sort = BusinessLogic.Primka.pPrimkaStavke.DefaultView;
            sort.Sort = "RedniBroj";
            BusinessLogic.Primka.pPrimkaStavke = sort.ToTable();

            BusinessLogic.Primka.pPrimkaStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Primka.pPrimkaStavke.Columns["ID_Proizvoda"] };

            ugdPrimkaStavke.DataSource = BusinessLogic.Primka.pPrimkaStavke;
            ugdPrimkaStavke.DataBind();

            Utils.Tools.UltraGridStyling(ugdPrimkaStavke);

            if (ugdPrimkaStavke.DisplayLayout.Bands.Count > 0)
            {
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_Primke"].Hidden = true;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_JedinicaMjere"].Hidden = true;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_Porez"].Hidden = true;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Porez"].Hidden = true;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["JedinicaMjere"].Hidden = true;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_Proizvoda"].Header.Caption = "Šifra";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["BrojUlaznogDokumenta"].Hidden = true;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Header.Caption = "Neto + ne može se odbiti";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Width = 130;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Cijena"].Header.Caption = "Neto";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Header.Caption = "Količina";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["UkupnaNabavnaCijena"].Header.Caption = "Ukupna nabavna vrijednost";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["UkupnaNabavnaCijena"].Format = "F2";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Cijena"].Format = "F2";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Format = "F2";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Format = "F2";

                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["RedniBroj"].Header.VisiblePosition = 1;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Proizvod"].Header.VisiblePosition = 2;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Header.VisiblePosition = 3;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Cijena"].Header.VisiblePosition = 4;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Header.VisiblePosition = 5;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["UkupnaNabavnaCijena"].Header.VisiblePosition = 6;
            }

            if (BusinessLogic.Primka.pPrimkaStavke.Rows.Count == 0)
            {
                btnBrisiStavku.Enabled = false;
                btnUrediStavku.Enabled = false;
            }
            else
            {
                btnBrisiStavku.Enabled = true;
                btnUrediStavku.Enabled = true;
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
                //ucbVrstaNabave.Value = null;

                FormEditMode = Enums.FormEditMode.Insert;
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            using(BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                uteBrojDokumenta.Value = pBrojPrimke;
                udtDatumPrimke.Value = pDatumPrimke;

                var obj = objekt.GetFullPartnerByID(pPartner);

                if (obj != null)
                {
                    uteNazivPartnera.Value = obj["Naziv"].ToString();
                    uteAdresaPartner.Value = obj["Adresa"].ToString();
                    uteGradPartner.Value = obj["Grad"].ToString();
                    uteOIB.Value = obj["OIB"].ToString();
                }
                uneNeto.Value = pNeto;
                uneBruto.Value = pBruto;
                unePDV.Value = pPDV;
                uteVrstaDokumenta.Value = objekt.GetFullVrstaDokumenta(pVrstaDokumenta);
                uteBroj.Text = BusinessLogic.Primka.pBrojUlaznogDokumenta;

                LoadFirstTimeStavke(objekt);
                if (ugdPrimkaStavke.Rows.Count == 0)
                {
                    LoadStavke();
                }

                if (FormEditMode == Enums.FormEditMode.Insert && pNarudzbenica != null)
                {
                    FillStavkeFromNarudzbenica();
                }
            }
        }

        private void FillStavkeFromNarudzbenica()
        {
            using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                BusinessLogic.Primka.pPrimkaStavke = objekt.GetStavkeFromNarudzbenica((int)pNarudzbenica);

                DataView sort = BusinessLogic.Primka.pPrimkaStavke.DefaultView;
                sort.Sort = "RedniBroj";
                BusinessLogic.Primka.pPrimkaStavke = sort.ToTable();

                BusinessLogic.Primka.pPrimkaStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Primka.pPrimkaStavke.Columns["ID_Proizvoda"] };

                ugdPrimkaStavke.DataSource = BusinessLogic.Primka.pPrimkaStavke;
                ugdPrimkaStavke.DataBind();

                Utils.Tools.UltraGridStyling(ugdPrimkaStavke);

                if (ugdPrimkaStavke.DisplayLayout.Bands.Count > 0)
                {
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_Primke"].Hidden = true;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_JedinicaMjere"].Hidden = true;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Porez"].Hidden = true;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["JedinicaMjere"].Hidden = true;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_Porez"].Hidden = true;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_Proizvoda"].Header.Caption = "Šifra";
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Cijena"].Format = "F2";
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Format = "F2";
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Format = "F2";
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["BrojUlaznogDokumenta"].Hidden = true;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Header.Caption = "Neto + ne može se odbiti";
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Width = 130;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Cijena"].Header.Caption = "Neto";
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Header.Caption = "Količina";
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["UkupnaNabavnaCijena"].Header.Caption = "Ukupna nabavna vrijednost";
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["UkupnaNabavnaCijena"].Format = "F2";

                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["RedniBroj"].Header.VisiblePosition = 1;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Proizvod"].Header.VisiblePosition = 2;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Header.VisiblePosition = 3;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Cijena"].Header.VisiblePosition = 4;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Header.VisiblePosition = 5;
                    ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["UkupnaNabavnaCijena"].Header.VisiblePosition = 6;
                }

                if (BusinessLogic.Primka.pPrimkaStavke.Rows.Count == 0)
                {
                    btnBrisiStavku.Enabled = false;
                    btnUrediStavku.Enabled = false;
                }
                else
                {
                    btnBrisiStavku.Enabled = true;
                    btnUrediStavku.Enabled = true;
                }
            }
        }

        private void btnNovaStavka_Click(object sender, EventArgs e)
        {
            using (PrimkaStavkeUnosForm objekt = new PrimkaStavkeUnosForm(Enums.FormEditMode.Insert))
            {
                PrimkaStavkeUnosForm.pProizvod = null;

                if (objekt.ShowDialogForm("PrimkaStavke") == DialogResult.OK)
                {
                    LoadStavke();

                    NapuniUkupno();
                }
            }
        }

        internal void NapuniUkupno()
        {
            decimal neto = 0;
            decimal neto_uk = 0;
            decimal pdv = 0;
            decimal pdv_uk = 0;
            decimal bruto = 0;
            decimal bruto_uk = 0;

            foreach (DataRow row in BusinessLogic.Primka.pPrimkaStavke.Rows)
            {
                neto = Convert.ToDecimal(row["Cijena"]) * Convert.ToDecimal(row["Kolicina"]);
                bruto = Convert.ToDecimal(row["CijenaPDV"]) * Convert.ToDecimal(row["Kolicina"]);

                pdv = bruto - neto;

                neto_uk += neto;
                pdv_uk += pdv;
                bruto_uk += bruto;
            }

            uneNeto.Value = neto_uk;
            uneBruto.Value = bruto_uk;
            unePDV.Value = pdv_uk;
        }

        private decimal GetStopaPDV(int stopa)
        {
            using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                return objekt.GetStopaPDV(stopa);
            }
        }

        internal bool IsPreneseno()
        {
            using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                if (objekt.IsPreneseno())
                {
                    return false;
                }
                return true;
            }
        }

        private void btnUrediStavku_Click(object sender, EventArgs e)
        {

            using (PrimkaStavkeUnosForm objekt = new PrimkaStavkeUnosForm(Enums.FormEditMode.Update))
            {
                PrimkaStavkeUnosForm.pProizvod = (int)ugdPrimkaStavke.ActiveRow.Cells["ID_Proizvoda"].Value;
                PrimkaStavkeUnosForm.pJedinicaMjere = (int)ugdPrimkaStavke.ActiveRow.Cells["ID_JedinicaMjere"].Value;
                PrimkaStavkeUnosForm.pNeto = IsDbNull<decimal>(ugdPrimkaStavke.ActiveRow.Cells["Cijena"].Value);
                PrimkaStavkeUnosForm.pNetoNeMoze = IsDbNull<decimal>(ugdPrimkaStavke.ActiveRow.Cells["CijenaPDV"].Value);
                PrimkaStavkeUnosForm.pPorez = IsDbNull<int>(ugdPrimkaStavke.ActiveRow.Cells["ID_Porez"].Value);
                PrimkaStavkeUnosForm.pKolicina = IsDbNull<decimal>(ugdPrimkaStavke.ActiveRow.Cells["Kolicina"].Value);
                PrimkaStavkeUnosForm.pUkupnaVrijednost = IsDbNull<decimal>(ugdPrimkaStavke.ActiveRow.Cells["UkupnaNabavnaCijena"].Value);


                if (objekt.ShowDialogForm("PrimkaStavke") == DialogResult.OK)
                {
                    NapuniUkupno();
                }
            }

        }

        private void btnBrisiStavku_Click(object sender, EventArgs e)
        {
            for (int i = ugdPrimkaStavke.Rows.Count - 1; i > -1; i--)
            {
                if (bool.Parse(ugdPrimkaStavke.Rows[i].Cells["SEL"].Value.ToString()))
                {
                    DataRow row = BusinessLogic.Primka.pPrimkaStavke.Rows.Find(ugdPrimkaStavke.Rows[i].Cells["ID_Proizvoda"].Value);
                    if (row != null)
                    {
                        BusinessLogic.Primka.pPrimkaStavke.Rows.Remove(row);
                    }

                    RecalculateRedniBroj();
                }
            }
            ugdPrimkaStavke.DataSource = null;
            ugdPrimkaStavke.DataSource = BusinessLogic.Primka.pPrimkaStavke;
            ugdPrimkaStavke.DataBind();

            Utils.Tools.UltraGridStyling(ugdPrimkaStavke);

            if (ugdPrimkaStavke.DisplayLayout.Bands.Count > 0)
            {
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_Primke"].Hidden = true;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_JedinicaMjere"].Hidden = true;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_Porez"].Hidden = true;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Porez"].Hidden = true;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["JedinicaMjere"].Hidden = true;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["ID_Proizvoda"].Header.Caption = "Šifra";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["BrojUlaznogDokumenta"].Hidden = true;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Header.Caption = "Neto + ne može se odbiti";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Width = 130;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Cijena"].Header.Caption = "Neto";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Header.Caption = "Količina";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["UkupnaNabavnaCijena"].Header.Caption = "Ukupna nabavna vrijednost";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["UkupnaNabavnaCijena"].Format = "F2";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Cijena"].Format = "F2";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Format = "F2";
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Format = "F2";

                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["RedniBroj"].Header.VisiblePosition = 1;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Proizvod"].Header.VisiblePosition = 2;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Header.VisiblePosition = 3;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["Cijena"].Header.VisiblePosition = 4;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Header.VisiblePosition = 5;
                ugdPrimkaStavke.DisplayLayout.Bands[0].Columns["UkupnaNabavnaCijena"].Header.VisiblePosition = 6;
            }
        }

        private void RecalculateRedniBroj()
        {
            int redniBroj = 1;

            foreach (DataRow row in BusinessLogic.Primka.pPrimkaStavke.Rows)
            {
                row["RedniBroj"] = redniBroj;
                redniBroj++;
            }
        }

        #endregion
    }
}
