using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UcenickoFakturiranje.Enums;

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    public partial class RacunForm : Controls.BaseUserControl
    {
        #region Properties

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Methods

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public RacunForm(FormEditMode formEditMode)
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
                using (BusinessLogic.Racuni objekt = new BusinessLogic.Racuni())
                {
                    objekt.pDatum = udtDatum.DateTime;
                    objekt.pValuta = udtValuta.DateTime;
                    objekt.pIDPartner = (int)ucePartner.Value;
                    objekt.pModel = uteModel.Value.ToString();
                    objekt.pPoziv = utePoziv.Value.ToString();
                    objekt.pUkupanIznos = GetUkupanIznos(ugdStavke.Rows);

                    if (uteNapomena.Value != null)
                    {
                        objekt.pNapomena = uteNapomena.Value.ToString();
                    }

                    if (this.FormEditMode == Enums.FormEditMode.Update)
                    {
                        if (objekt.Update(message, objekt))
                        {
                            return true;
                        }
                    }
                }
            }

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        private decimal GetUkupanIznos(Infragistics.Win.UltraWinGrid.RowsCollection rowsCollection)
        {
            decimal ukupno = 0;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rowsCollection)
            {
                ukupno += Convert.ToDecimal(row.Cells["CijenaPDV"].Value);
            }
            return ukupno;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            //datum nastajanja
            if (udtDatum.Value == null)
            {
                message.Append(" - Datum je obavezno polje");
            }

            if (udtValuta.Value == null)
            {
                message.Append(" - Valuta je obavezno polje");
            }

            //partner - dobavljac
            if (ucePartner.Value == null)
            {
                message.Append(" - Partner je obavezno polje");
            }

            if (uteModel.Value == null)
            {
                message.Append(" - Model je obavezno polje");
            }

            if (utePoziv.Value == null)
            {
                message.Append(" - Poziv je obavezno polje");
            }

            return message;
        }

        private void LoadForm(BusinessLogic.Racuni objekt)
        {
            var selected = objekt.GetSelected();

            if (selected != null)
            {
                uteSifra.Value = BusinessLogic.Racuni.pIDRacun.ToString() + "-"  + BusinessLogic.Racuni.pIDGodina.ToString();
                udtDatum.Value = Convert.ToDateTime(selected["DATUM"].ToString());
                udtValuta.Value = Convert.ToDateTime(selected["VALUTA"].ToString());
                ucePartner.Value = Convert.ToInt32(selected["IDPARTNER"].ToString());
                uteModel.Value = selected["MODEL"].ToString();
                utePoziv.Value = selected["POZIV"].ToString();
                uteNapomena.Value = selected["Napomena"].ToString();

                BusinessLogic.Racuni.pRacuniStavke = objekt.GetPostojeceStavke();

                BusinessLogic.Racuni.pRacuniStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Racuni.pRacuniStavke.Columns["IDPROIZVOD"] };
                ugdStavke.DataSource = BusinessLogic.Racuni.pRacuniStavke;
                ugdStavke.DataBind();

                Utils.Tools.UltraGridStyling(ugdStavke);

                if (ugdStavke.DisplayLayout.Bands.Count > 0)
                {
                    ugdStavke.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdStavke.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                    ugdStavke.DisplayLayout.Bands[0].Columns["IDPROIZVOD"].Hidden = true;
                    ugdStavke.DisplayLayout.Bands[0].Columns["BROJSTAVKE"].Hidden = true;
                    ugdStavke.DisplayLayout.Bands[0].Columns["CIJENARACUN"].Format = "N2";
                    ugdStavke.DisplayLayout.Bands[0].Columns["RABAT"].Format = "N2";
                    ugdStavke.DisplayLayout.Bands[0].Columns["KOLICINA"].Format = "N2";
                    ugdStavke.DisplayLayout.Bands[0].Columns["FINPOREZSTOPARACUN"].Format = "N2";
                    ugdStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Format = "N2";
                }

                if (BusinessLogic.Racuni.pRacuniStavke.Rows.Count == 0)
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
        
        private void LoadPartner(BusinessLogic.Racuni objekt)
        {
            ucePartner.DataSource = objekt.GetPartner();
            ucePartner.DataBind();
        }

        #endregion

        #region Events

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

        private void FormLoad(object sender, EventArgs e)
        {
            BusinessLogic.Racuni.pRacuniStavke = new DataTable();
            BusinessLogic.Racuni.pRacuniStavke.Columns.Add("SEL", typeof(bool));
            BusinessLogic.Racuni.pRacuniStavke.Columns.Add("BROJSTAVKE", typeof(int));
            BusinessLogic.Racuni.pRacuniStavke.Columns.Add("IDPROIZVOD", typeof(int));
            BusinessLogic.Racuni.pRacuniStavke.Columns.Add("NAZIVPROIZVODRACUN", typeof(string));
            BusinessLogic.Racuni.pRacuniStavke.Columns.Add("CIJENARACUN", typeof(decimal));
            BusinessLogic.Racuni.pRacuniStavke.Columns.Add("RABAT", typeof(decimal));
            BusinessLogic.Racuni.pRacuniStavke.Columns.Add("KOLICNA", typeof(decimal));
            BusinessLogic.Racuni.pRacuniStavke.Columns.Add("FINPOREZSTOPARACUN", typeof(decimal));
            BusinessLogic.Racuni.pRacuniStavke.Columns.Add("CijenaPDV", typeof(decimal));

            BusinessLogic.Racuni.pRacuniStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Racuni.pRacuniStavke.Columns["IDPROIZVOD"] };

            using (BusinessLogic.Racuni objekt = new BusinessLogic.Racuni())
            {
                LoadPartner(objekt);

                if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
                {
                    LoadForm(objekt);
                }
            }
        }

        private void LoadStavke()
        {
            DataView sortedList = BusinessLogic.Racuni.pRacuniStavke.DefaultView;
            sortedList.Sort = "BROJSTAVKE";

            ugdStavke.DataSource = sortedList.ToTable();
            ugdStavke.DataBind();

            Utils.Tools.UltraGridStyling(ugdStavke);

            if (ugdStavke.DisplayLayout.Bands.Count > 0)
            {
                ugdStavke.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                ugdStavke.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                ugdStavke.DisplayLayout.Bands[0].Columns["IDPROIZVOD"].Hidden = true;
                ugdStavke.DisplayLayout.Bands[0].Columns["BROJSTAVKE"].Hidden = true;
                ugdStavke.DisplayLayout.Bands[0].Columns["CIJENARACUN"].Format = "N2";
                ugdStavke.DisplayLayout.Bands[0].Columns["RABAT"].Format = "N2";
                ugdStavke.DisplayLayout.Bands[0].Columns["KOLICINA"].Format = "N2";
                ugdStavke.DisplayLayout.Bands[0].Columns["FINPOREZSTOPARACUN"].Format = "N2";
                ugdStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Format = "N2";
            }

            if (BusinessLogic.Racuni.pRacuniStavke.Rows.Count == 0)
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

        private void btnNovaStavka_Click(object sender, EventArgs e)
        {
            using (RacuniStavkeForm objekt = new RacuniStavkeForm(Enums.FormEditMode.Insert))
            {
                if (objekt.ShowDialogForm("RacuniStavke") == DialogResult.OK)
                {
                    LoadStavke();
                }
            }
        }

        private void btnUrediStavku_Click(object sender, EventArgs e)
        {
            using (RacuniStavkeForm objekt = new RacuniStavkeForm(Enums.FormEditMode.Update))
            {
                objekt.pIDProizvod = (int)ugdStavke.ActiveRow.Cells["IDPROIZVOD"].Value;
                objekt.pNazivPriozvod = ugdStavke.ActiveRow.Cells["NAZIVPROIZVODRACUN"].Value.ToString();
                objekt.pCijena = Convert.ToDecimal(ugdStavke.ActiveRow.Cells["CIJENARACUN"].Value);
                objekt.pRabat = Convert.ToDecimal(ugdStavke.ActiveRow.Cells["RABAT"].Value);
                objekt.pKolicina = Convert.ToDecimal(ugdStavke.ActiveRow.Cells["KOLICINA"].Value);
                objekt.pPorez = Convert.ToDecimal(ugdStavke.ActiveRow.Cells["FINPOREZSTOPARACUN"].Value);
                objekt.pCijenaPDV = Convert.ToDecimal(ugdStavke.ActiveRow.Cells["CijenaPDV"].Value);

                if (objekt.ShowDialogForm("RacuniStavke") == DialogResult.OK)
                {
                    LoadStavke();
                }

            }
        }

        public Nullable<T> IsDbNull<T>(object value) where T : struct
        {
            if (value != DBNull.Value && value != null)
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }

            return null;
        }

        private void btnBrisiStavku_Click(object sender, EventArgs e)
        {
            for (int i = ugdStavke.Rows.Count - 1; i > -1; i--)
            {
                if (bool.Parse(ugdStavke.Rows[i].Cells["SEL"].Value.ToString()))
                {
                    DataRow row = BusinessLogic.Racuni.pRacuniStavke.Rows.Find(ugdStavke.Rows[i].Cells["IDPROIZVOD"].Value);
                    BusinessLogic.Racuni.pRacuniStavke.Rows.Remove(row);
                }
            }

            LoadStavke();
        }
    }
}
