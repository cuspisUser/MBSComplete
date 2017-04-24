using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinPosModule
{
    public partial class OdobrenjeFrm : BaseUserControl
    {
        #region Properties

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Methods

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public OdobrenjeFrm(FormEditMode formEditMode)
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
                using (Odobrenje objekt = new Odobrenje())
                {
                    objekt.pSifra = uteSifra.Value.ToString();
                    objekt.pID_Godina = Convert.ToInt32(uceGodina.Value);
                    objekt.pID_Partner = Convert.ToInt32(ucePartner.Value);
                    objekt.pDatumIzdavanja = udtDatumIzdavanja.DateTime;
                    if (uteNapomena.Value != null)
                    {
                        objekt.pNapomena = uteNapomena.Value.ToString();
                    }

                    if (FormEditMode == FormEditMode.Insert || FormEditMode == FormEditMode.Copy)
                    {
                        if (objekt.Insert(message, objekt))
                        {
                            FormEditMode = FormEditMode.Update;
                            return true;
                        }
                    }
                    else if (this.FormEditMode == FormEditMode.Update)
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

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            //sifra primke
            if (uteSifra.Value == null)
            {
                message.Append(" - Šifre odobrenja je obavezno polje");
            }
            else if (uteSifra.Value.ToString().Any(u => char.IsLetter(u)))
            {
                message.Append(" - Šifra odobrenja ne smije sadržavati slova");
            }

            //datum nastajanja
            if (udtDatumIzdavanja.Value == null)
            {
                message.Append(" - Datum odobrenja je obavezno polje");
            }

            //partner - dobavljac
            if (uceGodina.Value == null)
            {
                message.Append(" - Partner je obavezno polje");
            }

            //napomena
            if (uteNapomena.Value != null)
            {
                if (uteNapomena.Value.ToString().Length > 200)
                {
                    message.Append(" - Napomena ne smije sadržavati više od 200 znakova");
                }
            }

            return message;
        }

        private void LoadForm(Odobrenje objekt)
        {
            var odobrenje = objekt.GetOdobrenje();

            if (odobrenje != null)
            {
                uteSifra.Value = odobrenje["Sifra"].ToString();
                udtDatumIzdavanja.Value = Convert.ToDateTime(odobrenje["DatumIzdavanja"].ToString());
                uceGodina.Value = Convert.ToInt32(odobrenje["ID_Godina"].ToString());
                ucePartner.Value = Convert.ToInt32(odobrenje["ID_Partner"].ToString());
                uteNapomena.Value = odobrenje["Napomena"].ToString();

                Odobrenje.pOdobrenjeStavke = objekt.GetPostojeceStavke();
                Odobrenje.pOdobrenjeStavke.PrimaryKey = new DataColumn[] { Odobrenje.pOdobrenjeStavke.Columns["ID_Proizvod"] };
                ugdOdobrenjeStavke.DataSource = Odobrenje.pOdobrenjeStavke;
                ugdOdobrenjeStavke.DataBind();

                Tools.UltraGridStyling(ugdOdobrenjeStavke);

                if (ugdOdobrenjeStavke.DisplayLayout.Bands.Count > 0)
                {
                    ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                    ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["ID_Odobrenje"].Hidden = true;
                    ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["ID_Proizvod"].Hidden = true;
                    ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["ID_Porez"].Hidden = true;
                    ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["CijenaNeto"].Format = "N2";
                    ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Format = "N2";
                    ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Format = "N2";
                }

                if (Odobrenje.pOdobrenjeStavke.Rows.Count == 0)
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

        private void LoadGodina(Odobrenje objekt)
        {
            uceGodina.DataSource = objekt.GetGodina();
            uceGodina.DataBind();
            uceGodina.SelectedIndex = 0;
        }

        private void LoadPartner(Odobrenje objekt)
        {
            ucePartner.DataSource = objekt.GetPartner();
            ucePartner.DataBind();
        }

        private void CalculateNextID(Odobrenje objekt, int godina)
        {
            uteSifra.Value = objekt.GetNextID(godina);
        }

        #endregion

        #region Events

        private void tsbSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Odobrenje.pID = null;
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }

        private void tsbOdustani_Click(object sender, EventArgs e)
        {
            Odobrenje.pID = null;
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void tsbSpremiNovi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Odobrenje.pID = null;
                FormEditMode = FormEditMode.Insert;
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            Odobrenje.pOdobrenjeStavke = new DataTable();
            Odobrenje.pOdobrenjeStavke.Columns.Add("SEL", typeof(bool));
            Odobrenje.pOdobrenjeStavke.Columns.Add("ID_Odobrenje", typeof(int));
            Odobrenje.pOdobrenjeStavke.Columns.Add("ID_Proizvod", typeof(int));
            Odobrenje.pOdobrenjeStavke.Columns.Add("Proizvod", typeof(string));
            Odobrenje.pOdobrenjeStavke.Columns.Add("ID_Porez", typeof(int));
            Odobrenje.pOdobrenjeStavke.Columns.Add("Porez", typeof(string));
            Odobrenje.pOdobrenjeStavke.Columns.Add("CijenaNeto", typeof(decimal));
            Odobrenje.pOdobrenjeStavke.Columns.Add("RabatStopa", typeof(decimal));
            Odobrenje.pOdobrenjeStavke.Columns.Add("Kolicina", typeof(decimal));
            Odobrenje.pOdobrenjeStavke.Columns.Add("CijenaPDV", typeof(decimal));
            Odobrenje.pOdobrenjeStavke.PrimaryKey = new DataColumn[] { Odobrenje.pOdobrenjeStavke.Columns["ID_Proizvod"] };

            using (Odobrenje objekt = new Odobrenje())
            {
                LoadPartner(objekt);
                LoadGodina(objekt);

                if (FormEditMode == FormEditMode.Update || FormEditMode == FormEditMode.Copy)
                {
                    LoadForm(objekt);
                }
                if (FormEditMode == FormEditMode.Insert || FormEditMode == FormEditMode.Copy)
                {
                    CalculateNextID(objekt, Convert.ToInt32(uceGodina.Value));
                }
            }
        }

        #endregion

        private void btnUrediStavku_Click(object sender, EventArgs e)
        {
            using (OdobrenjeStavkeForm objekt = new OdobrenjeStavkeForm(FormEditMode.Update))
            {
                lblValidationMessages.Text = string.Empty;

                objekt.pProizvod = (int)ugdOdobrenjeStavke.ActiveRow.Cells["ID_Proizvod"].Value;
                objekt.pPorez = (int)ugdOdobrenjeStavke.ActiveRow.Cells["ID_Porez"].Value;
                objekt.pCijenaNeto = Convert.ToDecimal(ugdOdobrenjeStavke.ActiveRow.Cells["CijenaNeto"].Value);
                objekt.pCijenaPDV = Convert.ToDecimal(ugdOdobrenjeStavke.ActiveRow.Cells["CijenaPDV"].Value);
                objekt.pKolicina = Convert.ToDecimal(ugdOdobrenjeStavke.ActiveRow.Cells["Kolicina"].Value);
                objekt.pRabat = Convert.ToDecimal(ugdOdobrenjeStavke.ActiveRow.Cells["RabatStopa"].Value);

                if (objekt.ShowDialogForm("OdobrenjeStavka") == DialogResult.OK)
                {
                    LoadStavke();
                }
            }
        }

        private void btnNovaStavka_Click(object sender, EventArgs e)
        {
            using (OdobrenjeStavkeForm objekt = new OdobrenjeStavkeForm(FormEditMode.Insert))
            {
                lblValidationMessages.Text = string.Empty;

                if (objekt.ShowDialogForm("OdobrenjeStavke") == DialogResult.OK)
                {
                    LoadStavke();
                }
            }
        }

        private void btnBrisiStavku_Click(object sender, EventArgs e)
        {
            for (int i = ugdOdobrenjeStavke.Rows.Count - 1; i > -1; i--)
            {
                if (bool.Parse(ugdOdobrenjeStavke.Rows[i].Cells["SEL"].Value.ToString()))
                {
                    DataRow row = Odobrenje.pOdobrenjeStavke.Rows.Find(ugdOdobrenjeStavke.Rows[i].Cells["ID_Proizvod"].Value);
                    Odobrenje.pOdobrenjeStavke.Rows.Remove(row);
                }
            }
        }

        private void LoadStavke()
        {
            ugdOdobrenjeStavke.DataSource = Odobrenje.pOdobrenjeStavke;
            ugdOdobrenjeStavke.DataBind();

            Tools.UltraGridStyling(ugdOdobrenjeStavke);

            if (ugdOdobrenjeStavke.DisplayLayout.Bands.Count > 0)
            {
                ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["ID_Odobrenje"].Hidden = true;
                ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["ID_Proizvod"].Hidden = true;
                ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["ID_Porez"].Hidden = true;
                ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["CijenaNeto"].Format = "N2";
                ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["CijenaPDV"].Format = "N2";
                ugdOdobrenjeStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Format = "N2";
            }

            if (Odobrenje.pOdobrenjeStavke.Rows.Count == 0)
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
}
