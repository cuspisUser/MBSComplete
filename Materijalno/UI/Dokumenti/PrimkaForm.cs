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
    public partial class PrimkaForm : Controls.BaseUserControl
    {

        #region Properties

        private FormEditMode FormEditMode { get; set; }
        private static DateTime datum { get; set; }

        #endregion

        #region Methods

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public PrimkaForm(FormEditMode formEditMode)
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
                using(BusinessLogic.Primka objekt = new BusinessLogic.Primka())
                {
                    objekt.pBrojPrimke = uteBrojDokumenta.Value.ToString();
                    objekt.pDatumNastajanja = udtDatumPrimke.DateTime;
                    //set current time na odabrani datum ako je vrijeme 0
                    if (objekt.pDatumNastajanja.TimeOfDay.TotalSeconds == 0)
                    {
                        DateTime date = objekt.pDatumNastajanja.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second);
                        objekt.pDatumNastajanja = date;
                    }
                    objekt.pDobavljac = (int)uceDobavljac.SelectedItem.GetType().GetProperty("ID").GetValue(this.uceDobavljac.SelectedItem, null);
                    objekt.pVrstaDokumenta = objekt.IsDbNull<int>(uceVrstaUlaznogDokumenta.Value);
                    objekt.pDatumDokumentaDobavljaca = objekt.IsDbNull<DateTime>(udtDatumDokumentaDobavljaca.DateTime);
                    objekt.pSkaldiste = objekt.IsDbNull<int>(uceOdabirSkladista.Value);
                    objekt.pNarudzbenica = objekt.IsDbNull<int>(uceBrojNarudzbe.Value);
                    objekt.pNeto = objekt.IsDbNull<decimal>(uneNeto.Value);
                    objekt.pPDV = objekt.IsDbNull<decimal>(unePDV.Value);
                    objekt.pBruto = objekt.IsDbNull<decimal>(uneBruto.Value);
                    objekt.pZavrsniTransport = objekt.IsDbNull<decimal>(uneTransport.Value);
                    objekt.pZavrsniCarina = objekt.IsDbNull<decimal>(uneCarina.Value);
                    objekt.pZavrsniOstalo = objekt.IsDbNull<decimal>(uneOstalo.Value);
                    if (uteOpisPrimke.Value != null)
                    {
                        objekt.pOpis = uteOpisPrimke.Value.ToString();
                    }

                    if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
                    {
                        if (objekt.Insert(message, objekt))
                        {
                            FormEditMode = Enums.FormEditMode.Update;
                            return true;
                        }
                    }
                    else if (this.FormEditMode == Enums.FormEditMode.Update)
                    {
                        if (objekt.Update(message, objekt, IsPreneseno()))
                        {
                            if (datum != udtDatumPrimke.DateTime)
                            {
                                MessageBox.Show("Molimo provjerite sve izdatnice nastale nakon datuma ove primke!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            return true;
                        }
                    }
                }
            }

            lblValidationMessages.Text = message.ToString();
            return false;
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

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            //sifra primke
            if (uteBrojDokumenta.Value == null)
            {
                message.Append(" - Šifre primke je obavezno polje");
            }
            else if (uteBrojDokumenta.Value.ToString().Any(u => char.IsLetter(u)))
            {
                message.Append(" - Šifra primke nesmije sadržavati slova");
            }
            else if (uteBrojDokumenta.Value.ToString().Length > 50)
            {
                message.Append(" - Maksimalna dužina šifre primke je 50");
            }

            //datum nastajanja
            if (udtDatumPrimke.Value == null)
            {
                message.Append(" - Datum primke je obavezno polje");
            }

            //partner - dobavljac
            if (uceDobavljac.SelectedItem == null)
            {
                message.Append(" - Partner je obavezno polje");
            }

            //skladiste
            if (uceOdabirSkladista.Value == null)
            {
                message.Append(" - Skladište je obavezno polje");
            }

            //opis
            if (uteOpisPrimke.Value != null)
            {
                if (uteOpisPrimke.Value.ToString().Length > 100)
                {
                    message.Append(" - Opis nesmije sadržavati više od 100 znakova");
                }
            }

            return message;
        }

        private void LoadForm(BusinessLogic.Primka objekt)
        {
            var primka = objekt.GetPrimka();

            if (primka != null)
            {
                uteBrojDokumenta.Value = primka["SifraPrimke"].ToString();
                udtDatumPrimke.Value = Convert.ToDateTime(primka["DatumNastajanja"].ToString());
                foreach (var item in uceDobavljac.Items)
                {
                    if (((Mipsed7.DataAccessLayer.SqlClient.FillCombo)(item)).ID == Convert.ToInt32(primka["ID_PARTNERA"]))
                    {
                        uceDobavljac.SelectedItem = item;
                        break;
                    }
                }
                uceVrstaUlaznogDokumenta.Value = objekt.IsDbNull<int>(primka["ID_Dokumenta"]);
                udtDatumDokumentaDobavljaca.Value = objekt.IsDbNull<DateTime>(primka["DatumDokumentaDobavljaca"]);
                uceOdabirSkladista.Value = Convert.ToInt32(primka["ID_Skladista"].ToString());
                uceBrojNarudzbe.Value = objekt.IsDbNull<int>(primka["ID_Narudzbenice"]);
                uneNeto.Value = objekt.IsDbNull<decimal>(primka["NetoPrimke"]);
                unePDV.Value = objekt.IsDbNull<decimal>(primka["PDVPrimke"]);
                uneBruto.Value = objekt.IsDbNull<decimal>(primka["BrutoPrimke"]);
                uneTransport.Value = objekt.IsDbNull<decimal>(primka["ZavisniTransport"]);
                uneCarina.Value = objekt.IsDbNull<decimal>(primka["ZavisniCarina"]);
                uneOstalo.Value = objekt.IsDbNull<decimal>(primka["ZavisniOstalo"]);
                BusinessLogic.Primka.pBrojUlaznogDokumenta = primka["BrojUlaznogDokumenta"].ToString();
                uteOpisPrimke.Value = primka["Opis"].ToString();
                //udtDatumPrimke.Enabled = false;
                //uceOdabirSkladista.Enabled = false;
            }
        }

        private void LoadNarudzbenica(BusinessLogic.Primka objekt)
        {
            uceBrojNarudzbe.DataSource = objekt.GetNarudzbenica();
            uceBrojNarudzbe.DataBind();
        }

        private void LoadSkladiste(BusinessLogic.Primka objekt)
        {
            uceOdabirSkladista.DataSource = objekt.GetSkladiste();
            uceOdabirSkladista.DataBind();
        }

        private void LoadDokument(BusinessLogic.Primka objekt)
        {
            uceVrstaUlaznogDokumenta.DataSource = objekt.GetDokument();
            uceVrstaUlaznogDokumenta.DataBind();
        }

        private void LoadPartner(BusinessLogic.Primka objekt)
        {
            uceDobavljac.Items.AddRange(objekt.GetPartner());

            uceDobavljac.DisplayMember = "Naziv";
            uceDobavljac.ValueMember = "ID";
        }

        private bool ValidatePrimka()
        {
            StringBuilder error = new StringBuilder();

            if (uteBrojDokumenta.Value == null)
            {
                error.Append(" - Broj primke je obavezno polje");
            }
            if (udtDatumPrimke.Value == null)
            {
                error.Append(" - Datum primke je obavezno polje");
            }
            if (uceDobavljac.SelectedItem == null)
            {
                error.Append(" - Dobavljač je obavezno polje");
            }
            if (uceOdabirSkladista.Value == null)
            {
                error.Append(" - Skladište je obavezno polje");
            }

            if (error.Length > 0)
            {
                lblValidationMessages.Text = error.ToString();
                return false;
            }

            return true;
        }

        #endregion

        #region Dogadaji

        private void tsbSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                BusinessLogic.Primka.pID = null;
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
                BusinessLogic.Primka.pBrojUlaznogDokumenta = "";
            }
        }

        private void tsbOdustani_Click(object sender, EventArgs e)
        {
            BusinessLogic.Primka.pID = null;
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
            BusinessLogic.Primka.pBrojUlaznogDokumenta = "";
        }

        private void tsbSpremiNovi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                 FormEditMode = Enums.FormEditMode.Insert;
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            BusinessLogic.Primka.pPrimkaStavke = new DataTable();
            BusinessLogic.Primka.pPrimkaStavke.Columns.Add("SEL", typeof(bool));
            BusinessLogic.Primka.pPrimkaStavke.Columns.Add("ID_Primke", typeof(int));
            BusinessLogic.Primka.pPrimkaStavke.Columns.Add("ID_Proizvoda", typeof(int));
            BusinessLogic.Primka.pPrimkaStavke.Columns.Add("Proizvod", typeof(string));
            BusinessLogic.Primka.pPrimkaStavke.Columns.Add("ID_JedinicaMjere", typeof(int));
            BusinessLogic.Primka.pPrimkaStavke.Columns.Add("JedinicaMjere", typeof(string));
            BusinessLogic.Primka.pPrimkaStavke.Columns.Add("Cijena", typeof(decimal));
            BusinessLogic.Primka.pPrimkaStavke.Columns.Add("ID_Porez", typeof(int));
            BusinessLogic.Primka.pPrimkaStavke.Columns.Add("Porez", typeof(string));
            BusinessLogic.Primka.pPrimkaStavke.Columns.Add("Kolicina", typeof(decimal));
            BusinessLogic.Primka.pPrimkaStavke.Columns.Add("CijenaPDV", typeof(decimal));
            BusinessLogic.Primka.pPrimkaStavke.Columns.Add("BrojUlaznogDokumenta", typeof(string));
            BusinessLogic.Primka.pPrimkaStavke.Columns.Add("UkupnaNabavnaCijena", typeof(decimal));
            BusinessLogic.Primka.pPrimkaStavke.Columns.Add("RedniBroj", typeof(int));
            BusinessLogic.Primka.pPrimkaStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Primka.pPrimkaStavke.Columns["ID_Proizvoda"] };

            using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                LoadPartner(objekt);
                LoadDokument(objekt);
                LoadSkladiste(objekt);
                LoadNarudzbenica(objekt);

                uceVrstaUlaznogDokumenta.Value = 2;
                udtDatumPrimke.Value = DateTime.Now;
                udtDatumPrimke.Enabled = true;
                uceOdabirSkladista.Enabled = true;
                uteBrojDokumenta.Value = objekt.GetBrojDokumenta();

                if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
                {
                    LoadForm(objekt);
                    datum = udtDatumPrimke.DateTime;
                    BusinessLogic.Primka.pPrimkaStavke = objekt.GetPrimkaStavke();
                    DataView sort = BusinessLogic.Primka.pPrimkaStavke.DefaultView;
                    sort.Sort = "RedniBroj";
                    BusinessLogic.Primka.pPrimkaStavke = sort.ToTable();
                    BusinessLogic.Primka.pPrimkaStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Primka.pPrimkaStavke.Columns["ID_Proizvoda"] };
                }
            }
        }

        private void btnPrimkaStavke_Click(object sender, EventArgs e)
        {
            using (PrimkaStavkeForm objekt = new PrimkaStavkeForm(FormEditMode))
            {
                lblValidationMessages.Text = string.Empty;
                if (ValidatePrimka())
                {
                    objekt.pBrojPrimke = uteBrojDokumenta.Value.ToString();
                    objekt.pDatumPrimke = udtDatumPrimke.DateTime;
                    objekt.pPartner = (int)uceDobavljac.SelectedItem.GetType().GetProperty("ID").GetValue(this.uceDobavljac.SelectedItem, null);
                    objekt.pSkaldiste = objekt.IsDbNull<int>(uceOdabirSkladista.Value);
                    objekt.pVrstaDokumenta = objekt.IsDbNull<int>(uceVrstaUlaznogDokumenta.Value);
                    objekt.pNeto = objekt.IsDbNull<decimal>(uneNeto.Value);
                    objekt.pPDV = objekt.IsDbNull<decimal>(unePDV.Value);
                    objekt.pBruto = objekt.IsDbNull<decimal>(uneBruto.Value);
                    objekt.pNarudzbenica = objekt.IsDbNull<int>(uceBrojNarudzbe.Value);

                    if (objekt.ShowDialogForm("PrimkaStavke") == DialogResult.OK)
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
                            pdv = neto * GetStopaPDV(Convert.ToInt32(row["ID_Porez"]));
                            bruto = Convert.ToDecimal(row["CijenaPDV"]) * Convert.ToDecimal(row["Kolicina"]);

                            neto_uk += neto;
                            pdv_uk += pdv;
                            bruto_uk += bruto;
                        }

                        objekt.pNeto = neto_uk;
                        objekt.pBruto = bruto_uk;
                        objekt.pPDV = pdv_uk;
                        uneNeto.Value = neto_uk;
                        uneBruto.Value = bruto_uk;
                        unePDV.Value = pdv_uk;
                    }

                    BusinessLogic.Primka.kontrola_stavke = true;
                }
            }
        }

        private decimal GetStopaPDV(int stopa)
        {
            using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                return objekt.GetStopaPDV(stopa);
            }
        }

        #endregion


        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                string srch = comboBox1.Text;
                string srch_str = "ABackCDeleteEFGHIJKLMNOPQRSpaceTUVWXYZD1D2D3D4D5D6D7D8D9D0";
                if (srch_str.IndexOf(e.KeyCode.ToString()) >= 0)
                {
                    comboBox1.DisplayMember = "Naziv";
                    comboBox1.ValueMember = "ID";
                    DataView dv_source = new DataView(objekt.GetPartner1());
                    dv_source.RowFilter = "Naziv LIKE '%" + srch + "%'";
                    comboBox1.DataSource = dv_source;
                    comboBox1.SelectedIndex = -1;
                    comboBox1.Text = srch;
                    comboBox1.Select(100, 0);
                    comboBox1.DroppedDown = true; 
                }
            }
        }

        private void uceDobavljac_KeyPress(object sender, KeyPressEventArgs e)
        {
            uceDokumentKeyPressed();
        }

        private void uceDobavljac_TextChanged(object sender, EventArgs e)
        {
            if (uceDobavljac.Text.Length == 0) uceDokumentKeyPressed();
        }
        private void uceDokumentKeyPressed()
        {
            uceDobavljac.DroppedDown = true;

            object[] originalList = (object[])uceDobavljac.Tag;
            if (originalList == null)
            {
                // backup original list
                originalList = new object[uceDobavljac.Items.Count];
                uceDobavljac.Items.CopyTo(originalList, 0);
                uceDobavljac.Tag = originalList;
            }

            // prepare list of matching items
            string s = uceDobavljac.Text.ToLower();
            IEnumerable<object> newList = originalList;



            if (s.Length > 0)
            {

                newList = originalList.Where(item => item.GetType().GetProperty("Naziv").GetValue(item, null).ToString().ToLower().Contains(s));

                //newList = originalList.Where(item => item[1].ToString().ToLower().Contains(s));
            }

            // clear list (loop through it, otherwise the cursor would move to the beginning of the textbox...)
            while (uceDobavljac.Items.Count > 0)
            {
                uceDobavljac.Items.RemoveAt(0);
            }

            // re-set list
            uceDobavljac.Items.AddRange(newList.ToArray());
            uceDobavljac.DisplayMember = "Naziv";
            uceDobavljac.ValueMember = "ID";
        }
    }
}
