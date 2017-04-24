using Materijalno.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Materijalno.UI.Dokumenti
{
    public partial class IzdatnicaForm : Controls.BaseUserControl
    {
        #region Properties

        private FormEditMode FormEditMode { get; set; }

        #endregion

        #region Methods
        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public IzdatnicaForm(FormEditMode formEditMode)
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
                using (BusinessLogic.Izdatnica objekt = new BusinessLogic.Izdatnica())
                {
                    objekt.pSifra = uteSifra.Value.ToString();
                    objekt.pDatumNastajanja = udtDatumNastajanja.DateTime;
                    //set current time na odabrani datum ako je vrijeme 0
                    if (objekt.pDatumNastajanja.TimeOfDay.TotalSeconds == 0)
                    {
                        DateTime date = objekt.pDatumNastajanja.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second);
                        objekt.pDatumNastajanja = date;
                    }
                    objekt.pID_Dokumenta = (int)comDokument.SelectedItem.GetType().GetProperty("ID").GetValue(comDokument.SelectedItem, null);
                    objekt.pID_Skladista = (int)uceSkladiste.Value;
                    objekt.pUkupanIznos = objekt.CalculateUkupno();
                    if (cmbMjestoTroska.SelectedItem != null)
                    {
                        objekt.mjestoTroska = ((Mipsed7.DataAccessLayer.SqlClient.FillCombo)(cmbMjestoTroska.SelectedItem)).ID;
                    }
                    else
                    {
                        objekt.mjestoTroska = null;
                    }

                    if (uteNapomena.Value != null)
                    {
                        objekt.pNapomena = uteNapomena.Value.ToString();
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

            //sifra
            if (uteSifra.Value == null)
            {
                message.Append(" - Šifre je obavezno polje");
            }
            else if (uteSifra.Value.ToString().Any(u => char.IsLetter(u)))
            {
                message.Append(" - Šifra primke nesmije sadržavati slova");
            }
            else if (uteSifra.Value.ToString().Length > 50)
            {
                message.Append(" - Maksimalna dužina šifre je 50");
            }

            //datum nastajanja
            if (udtDatumNastajanja.Value == null)
            {
                message.Append(" - Datum je obavezno polje");
            }

            //partner - dobavljac
            if (comDokument.SelectedItem == null)
            {
                message.Append(" - Dokument je obavezno polje");
            }

            //skladiste
            if (uceSkladiste.Value == null)
            {
                message.Append(" - Skladište je obavezno polje");
            }

            if (BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows.Count < 1)
            {
                message.Append(" - Potrebno je unjeti stavke izdatnice");
            }

            return message;
        }

        private void LoadForm(BusinessLogic.Izdatnica objekt)
        {
            var selected = objekt.GetSelected();

            if (selected != null)
            {
                comDokument.DisplayMember = "Naziv";
                comDokument.ValueMember = "ID";

                uteSifra.Value = selected["Sifra"].ToString();
                udtDatumNastajanja.Value = Convert.ToDateTime(selected["DatumNastajanja"].ToString());
                //udtDatumNastajanja.Enabled = false;

                foreach (var item in comDokument.Items)
                {
                    if (((Mipsed7.DataAccessLayer.SqlClient.FillCombo)(item)).ID == Convert.ToInt32(selected["ID_Dokumenta"]))
                    {
                        comDokument.SelectedItem = item;
                        break;
                    }
                }

                if (selected["MjestoTroska"].ToString().Length > 0)
                {
                    cmbMjestoTroska.DisplayMember = "Naziv";
                    cmbMjestoTroska.ValueMember = "ID";

                    foreach (var item in cmbMjestoTroska.Items)
                    {
                        if (((Mipsed7.DataAccessLayer.SqlClient.FillCombo)(item)).ID == Convert.ToInt32(selected["MjestoTroska"]))
                        {
                            cmbMjestoTroska.SelectedItem = item;
                            break;
                        }
                    }
                }

                uceSkladiste.Value = Convert.ToInt32(selected["ID_Skladista"].ToString());
                uteNapomena.Value = selected["Napomena"].ToString();
                BusinessLogic.Izdatnica.pIzdatnicaStavke = objekt.GetPostojeceStavke();
                BusinessLogic.Izdatnica.pIzdatnicaStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Izdatnica.pIzdatnicaStavke.Columns["ID_Proizvoda"] };
                ugdIzdatnicaStavke.DataSource = BusinessLogic.Izdatnica.pIzdatnicaStavke;
                ugdIzdatnicaStavke.DataBind();

                Utils.Tools.UltraGridStyling(ugdIzdatnicaStavke);

                if (ugdIzdatnicaStavke.DisplayLayout.Bands.Count > 0)
                {
                    ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["SEL"].ResetAutoSizeEdit();

                    ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["ID_Izdatnice"].Hidden = true;
                    ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["ID_Proizvoda"].Hidden = true;
                    ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["NabavnaCijena"].Format = "F4";
                    ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Format = "F4";
                }

                if (BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows.Count == 0)
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

        private void LoadSkladiste(BusinessLogic.Izdatnica objekt)
        {
            uceSkladiste.DataSource = objekt.GetSkladiste();
            uceSkladiste.DataBind();
        }

        private void LoadMjestoTroska(BusinessLogic.Izdatnica objekt)
        {
            cmbMjestoTroska.Items.AddRange(objekt.GetMjestoTroska());
        }

        private void LoadDokument(BusinessLogic.Izdatnica objekt)
        {
            //uceDokument.DataSource = objekt.GetDokument();
            //uceDokument.DataBind();
            comDokument.Items.AddRange(objekt.GetDokument1());
        }

        private void LoadStavke()
        {
            ugdIzdatnicaStavke.DataSource = BusinessLogic.Izdatnica.pIzdatnicaStavke;
            ugdIzdatnicaStavke.DataBind();

            Utils.Tools.UltraGridStyling(ugdIzdatnicaStavke);

            if (ugdIzdatnicaStavke.DisplayLayout.Bands.Count > 0)
            {
                ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["ID_Izdatnice"].Hidden = true;
                ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["ID_Proizvoda"].Hidden = true;
                ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["NabavnaCijena"].Format = "F4";
                ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Format = "F4";

                ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["RedniBroj"].Header.VisiblePosition = 1;
                ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["StavkaSkladista"].Header.VisiblePosition = 2;
                ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["NabavnaCijena"].Header.VisiblePosition = 3;
                ugdIzdatnicaStavke.DisplayLayout.Bands[0].Columns["Kolicina"].Header.VisiblePosition = 4;
            }

            if (BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows.Count == 0)
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

        private void RecalculateRedniBroj()
        {
            int redniBroj = 1;

            foreach (DataRow row in BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows)
            {
                row["RedniBroj"] = redniBroj;
                redniBroj++;
            }
        }

        #endregion

        #region Dogadaji
        private void tsbSpremiZatvori_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (SaveData())
            {
                this.Cursor = Cursors.Default;
                BusinessLogic.Izdatnica.pID = null;
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
            this.Cursor = Cursors.Default;
        }

        private void tsbOdustani_Click(object sender, EventArgs e)
        {
            BusinessLogic.Izdatnica.pID = null;
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            BusinessLogic.Izdatnica.pIzdatnicaStavke = new DataTable();
            BusinessLogic.Izdatnica.pIzdatnicaStavke.Columns.Add("SEL", typeof(bool));
            BusinessLogic.Izdatnica.pIzdatnicaStavke.Columns.Add("ID_Izdatnice", typeof(int));
            BusinessLogic.Izdatnica.pIzdatnicaStavke.Columns.Add("ID_Proizvoda", typeof(int));
            BusinessLogic.Izdatnica.pIzdatnicaStavke.Columns.Add("StavkaSkladista", typeof(string));
            BusinessLogic.Izdatnica.pIzdatnicaStavke.Columns.Add("Kolicina", typeof(decimal));
            BusinessLogic.Izdatnica.pIzdatnicaStavke.Columns.Add("NabavnaCijena", typeof(decimal));
            BusinessLogic.Izdatnica.pIzdatnicaStavke.Columns.Add("RedniBroj", typeof(int));
            BusinessLogic.Izdatnica.pIzdatnicaStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Izdatnica.pIzdatnicaStavke.Columns["ID_Proizvoda"] };

            using (BusinessLogic.Izdatnica objekt = new BusinessLogic.Izdatnica())
            {
                LoadDokument(objekt);
                LoadSkladiste(objekt);
                LoadMjestoTroska(objekt);
                udtDatumNastajanja.Enabled = true;
                udtDatumNastajanja.Value = DateTime.Now;
                comDokument.SelectedIndex = 2;

                if (FormEditMode == Enums.FormEditMode.Update)
                {
                    LoadForm(objekt);
                }
                else if (FormEditMode == Enums.FormEditMode.Copy)
                {
                    LoadForm(objekt);
                    GetNextSifra(objekt);
                }
                else
                {
                    GetNextSifra(objekt);
                }
            }
        }

        private void GetNextSifra(BusinessLogic.Izdatnica objekt)
        {
            uteSifra.Value = objekt.GetNextSifra();
        }

        private void btnNovaStavka_Click(object sender, EventArgs e)
        {
            using (IzdatnicaStavkeForm objekt = new IzdatnicaStavkeForm(Enums.FormEditMode.Insert))
            {
                lblValidationMessages.Text = string.Empty;
                if (uceSkladiste.Value != null)
                {
                    objekt.pSkladiste = (int)uceSkladiste.Value;
                    objekt.pDatum = udtDatumNastajanja.DateTime;
                    if (objekt.ShowDialogForm("IzdatnicaStavka") == DialogResult.OK)
                    {
                        LoadStavke();
                    }
                }
                else
                {
                    lblValidationMessages.Text = "- Potrebno je odabrati skladište da bi se mogla unositi stavka!";
                }
            }
        }

        private void btnUrediStavku_Click(object sender, EventArgs e)
        {
            using (IzdatnicaStavkeForm objekt = new IzdatnicaStavkeForm(Enums.FormEditMode.Update))
            {
                lblValidationMessages.Text = string.Empty;
                if (uceSkladiste.Value != null)
                {
                    objekt.pSkladiste = (int)uceSkladiste.Value;
                    objekt.pStavka = (int)ugdIzdatnicaStavke.ActiveRow.Cells["ID_Proizvoda"].Value;
                    objekt.pKolicina = IsDbNull<decimal>(ugdIzdatnicaStavke.ActiveRow.Cells["Kolicina"].Value);
                    objekt.pNabavnaCijena = IsDbNull<decimal>(ugdIzdatnicaStavke.ActiveRow.Cells["NabavnaCijena"].Value);
                    objekt.pDatum = udtDatumNastajanja.DateTime;

                    if (FormEditMode == Enums.FormEditMode.Update)
                    {
                        objekt.kolicinaEdit = objekt.pKolicina.Value;
                    }
                    else
                    {
                        objekt.kolicinaEdit = 0;
                    }

                    if (objekt.ShowDialogForm("IzdatnicaStavka") == DialogResult.OK)
                    {
                        LoadStavke();
                    }
                }
                else
                {
                    lblValidationMessages.Text = "- Potrebno je odabrati skladište da bi se mogla unositi stavka!";
                }
            }
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

        private void btnBrisiStavku_Click(object sender, EventArgs e)
        {
            for (int i = ugdIzdatnicaStavke.Rows.Count - 1; i > -1; i--)
            {
                if (bool.Parse(ugdIzdatnicaStavke.Rows[i].Cells["SEL"].Value.ToString()))
                {
                    DataRow row = BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows.Find(ugdIzdatnicaStavke.Rows[i].Cells["ID_Proizvoda"].Value);
                    BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows.Remove(row);

                    RecalculateRedniBroj();
                }
            }
        }
       
        //dok.
        private void uceDokument_KeyPress(object sender, KeyPressEventArgs e)
        {
            uceDokumentKeyPressed();
        }

        private void uceDokument_TextChanged(object sender, EventArgs e)
        {
            if (comDokument.Text.Length == 0) uceDokumentKeyPressed();
        }

        private void uceDokumentKeyPressed()
        {
            comDokument.DroppedDown = true;

            object[] originalList = (object[])comDokument.Tag;
            if (originalList == null)
            {
                // backup original list
                originalList = new object[comDokument.Items.Count];
                comDokument.Items.CopyTo(originalList, 0);
                comDokument.Tag = originalList;
            }

            // prepare list of matching items
            string s = comDokument.Text.ToLower();
            IEnumerable<object> newList = originalList;



            if (s.Length > 0)
            {

                newList = originalList.Where(item => item.GetType().GetProperty("Naziv").GetValue(item, null).ToString().ToLower().Contains(s));

                //newList = originalList.Where(item => item[1].ToString().ToLower().Contains(s));
            }

            // clear list (loop through it, otherwise the cursor would move to the beginning of the textbox...)
            while (comDokument.Items.Count > 0)
            {
                comDokument.Items.RemoveAt(0);
            }

            // re-set list
            comDokument.Items.AddRange(newList.ToArray());
            comDokument.DisplayMember = "Naziv";
            comDokument.ValueMember = "ID";
        }

        //MT
        private void cmbMjestoTroska_KeyPress(object sender, KeyPressEventArgs e)
        {
            uceDokumentKeyPressed();
        }

        private void cmbMjestoTroska_TextChanged(object sender, EventArgs e)
        {
            if (cmbMjestoTroska.Text.Length == 0) cmbMjestoTroskaKeyPressed();
        }

        private void cmbMjestoTroskaKeyPressed()
        {
            cmbMjestoTroska.DroppedDown = true;

            object[] originalList = (object[])cmbMjestoTroska.Tag;
            if (originalList == null)
            {
                // backup original list
                originalList = new object[cmbMjestoTroska.Items.Count];
                cmbMjestoTroska.Items.CopyTo(originalList, 0);
                cmbMjestoTroska.Tag = originalList;
            }

            // prepare list of matching items
            string s = cmbMjestoTroska.Text.ToLower();
            IEnumerable<object> newList = originalList;



            if (s.Length > 0)
            {

                newList = originalList.Where(item => item.GetType().GetProperty("Naziv").GetValue(item, null).ToString().ToLower().Contains(s));

                //newList = originalList.Where(item => item[1].ToString().ToLower().Contains(s));
            }

            // clear list (loop through it, otherwise the cursor would move to the beginning of the textbox...)
            while (cmbMjestoTroska.Items.Count > 0)
            {
                cmbMjestoTroska.Items.RemoveAt(0);
            }

            // re-set list
            cmbMjestoTroska.Items.AddRange(newList.ToArray());
            cmbMjestoTroska.DisplayMember = "Naziv";
            cmbMjestoTroska.ValueMember = "ID";
        }

        //sklad
        private void uceSkladiste_ValueChanged(object sender, EventArgs e)
        {
            if (FormEditMode == Enums.FormEditMode.Update)
            {
                if(uceSkladiste.Value != null && udtDatumNastajanja.Value != null)
                {
                    using (BusinessLogic.Izdatnica objekt = new BusinessLogic.Izdatnica())
                    {
                        StringBuilder message = new StringBuilder();
                        foreach (DataRow row in BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows)
                        {
                            objekt.ProvjeraDaliMozeNaSkladiste(Convert.ToInt32(row["ID_Proizvoda"]), Convert.ToDecimal(row["Kolicina"]), (int)uceSkladiste.Value, 
                                Convert.ToDateTime(udtDatumNastajanja.DateTime), row["StavkaSkladista"].ToString(), message);
                        }

                        if (message.Length > 0)
                        {
                            MessageBox.Show(message.ToString(), "Upozorenje");
                        }
                    }
                }
            }
        }

        private void udtDatumNastajanja_ValueChanged(object sender, EventArgs e)
        {
            if (FormEditMode == Enums.FormEditMode.Update)
            {
                if (uceSkladiste.Value != null && udtDatumNastajanja.Value != null)
                {
                    using (BusinessLogic.Izdatnica objekt = new BusinessLogic.Izdatnica())
                    {
                        StringBuilder message = new StringBuilder();
                        foreach (DataRow row in BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows)
                        {
                            objekt.ProvjeraDaliMozeNaSkladiste(Convert.ToInt32(row["ID_Proizvoda"]), Convert.ToDecimal(row["Kolicina"]), (int)uceSkladiste.Value,
                                Convert.ToDateTime(udtDatumNastajanja.DateTime), row["StavkaSkladista"].ToString(), message);
                        }

                        if (message.Length > 0)
                        {
                            MessageBox.Show(message.ToString(), "Upozorenje");
                        }
                    }
                }
            }
        }

        #endregion
    }
}
