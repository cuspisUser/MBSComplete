using Materijalno.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Materijalno.UI.Dokumenti
{
    public partial class PrimkaStavkeUnosForm : Controls.BaseUserControl
    {
        #region Properties

        private FormEditMode FormEditMode { get; set; }

        public static Nullable<int> pProizvod { get; set; }
        public static int pJedinicaMjere { get; set; }
        public static Nullable<decimal> pNeto { get; set; }
        public static Nullable<decimal> pUkupnaVrijednost { get; set; }
        public static Nullable<int> pPorez { get; set; }
        public static Nullable<decimal> pKolicina { get; set; }

        public static decimal? pNetoNeMoze { get; set; }

        #endregion

        #region Methods

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public PrimkaStavkeUnosForm(FormEditMode formEditMode)
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
                int id_porez;
                decimal cijena;
                decimal cijenaPDV;
                decimal ukupnaNabavnaVrijednost;
                decimal kolicina;
                string proizvod;
                string porez;
                string jedinca_mjere;
                int idJedinacaMjere;
                int redniBroj = BusinessLogic.Primka.pPrimkaStavke.Rows.Count + 1;

                if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
                {
                    if (ucePorez.Value == null)
                    {
                        id_porez = 0;
                    }
                    else
                    {
                        id_porez = Convert.ToInt32(ucePorez.Value);
                    }

                    if (uneNetoCijena.Value == null)
                    {
                        cijena = 0;
                    }
                    else
                    {
                        if (PrimkaStavkeUnosAmbalaza.ambalazaJedinicnaNeto != null)
                        {
                            cijena = (decimal)PrimkaStavkeUnosAmbalaza.ambalazaJedinicnaNeto;
                        }
                        else
                        {
                            cijena = Convert.ToDecimal(uneNetoCijena.Value);
                        }
                    }

                    if (uneNetoPlusNeMoze.Value == null)
                    {
                        cijenaPDV = 0;
                    }
                    else
                    {
                        if (PrimkaStavkeUnosAmbalaza.ambalazaJedinicnaNeMoze != null)
                        {
                            cijenaPDV = (decimal)PrimkaStavkeUnosAmbalaza.ambalazaJedinicnaNeMoze;
                        }
                        else
                        {
                            cijenaPDV = Convert.ToDecimal(uneNetoPlusNeMoze.Value);
                        }
                    }

                    if (uneUkupno.Value == null)
                    {
                        ukupnaNabavnaVrijednost = 0;
                    }
                    else
                    {
                        ukupnaNabavnaVrijednost = Convert.ToDecimal(uneUkupno.Value);
                    }

                    if (uneKolicina.Value == null)
                    {
                        kolicina = 0;
                    }
                    else
                    {
                        if (PrimkaStavkeUnosAmbalaza.ambalazaKolicina != null)
                        {
                            kolicina = Convert.ToDecimal(PrimkaStavkeUnosAmbalaza.ambalazaKolicina);
                        }
                        else
                        {
                            kolicina = Convert.ToDecimal(uneKolicina.Value);
                        }
                    }

                    porez = ucePorez.Text;
                    proizvod = (string)cmbProizvod.SelectedItem.GetType().GetProperty("Naziv").GetValue(cmbProizvod.SelectedItem, null);

                    jedinca_mjere = lblJedinica.Text;

                    idJedinacaMjere = Convert.ToInt32(lblJedinica.Tag);

                    if (PrimkaStavkeUnosAmbalaza.ambalazaMjerna != null)
                    {
                        idJedinacaMjere = (int)PrimkaStavkeUnosAmbalaza.ambalazaMjerna;
                        jedinca_mjere = PrimkaStavkeUnosAmbalaza.ambalazaMjernaTExt;
                    }

                    DataRow row = BusinessLogic.Primka.pPrimkaStavke.Rows.Find(Convert.ToInt32(cmbProizvod.SelectedItem.GetType().GetProperty("ID").GetValue(cmbProizvod.SelectedItem, null)));

                    if (row != null)
                    {
                        MessageBox.Show("Proizvod je već dodan na primku, nije moguće dodavati 2 ista proizvoda.", "Novi proizvod", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        BusinessLogic.Primka.pPrimkaStavke.Rows.Add(false, BusinessLogic.Primka.pID, Convert.ToInt32(cmbProizvod.SelectedItem.GetType().GetProperty("ID").GetValue(cmbProizvod.SelectedItem, null)), proizvod, idJedinacaMjere,
                                                                    jedinca_mjere, cijena, id_porez, porez, kolicina, cijenaPDV, null, ukupnaNabavnaVrijednost, redniBroj);

                        FormEditMode = Enums.FormEditMode.Update;
                        return true;
                    }
                }
                else if (this.FormEditMode == Enums.FormEditMode.Update)
                {

                    DataRow red = BusinessLogic.Primka.pPrimkaStavke.Select("ID_Proizvoda = " + pProizvod)[0];

                    redniBroj = Convert.ToInt32(red["RedniBroj"]);

                    BusinessLogic.Primka.pPrimkaStavke.Rows.Remove(red);
                    BusinessLogic.Primka.pPrimkaStavke.AcceptChanges();

                    if (ucePorez.Value == null)
                    {
                        id_porez = 0;
                    }
                    else
                    {
                        id_porez = Convert.ToInt32(ucePorez.Value);
                    }

                    if (uneNetoCijena.Value == null)
                    {
                        cijena = 0;
                    }
                    else
                    {
                        if (PrimkaStavkeUnosAmbalaza.ambalazaJedinicnaNeto != null)
                        {
                            cijena = (decimal)PrimkaStavkeUnosAmbalaza.ambalazaJedinicnaNeto;
                        }
                        else
                        {
                            cijena = Convert.ToDecimal(uneNetoCijena.Value);
                        }
                    }

                    if (uneNetoPlusNeMoze.Value == null)
                    {
                        cijenaPDV = 0;
                    }
                    else
                    {
                        if (PrimkaStavkeUnosAmbalaza.ambalazaJedinicnaNeMoze != null)
                        {
                            cijenaPDV = (decimal)PrimkaStavkeUnosAmbalaza.ambalazaJedinicnaNeMoze;
                        }
                        else
                        {
                            cijenaPDV = Convert.ToDecimal(uneNetoPlusNeMoze.Value);
                        }
                    }

                    if (uneUkupno.Value == null)
                    {
                        ukupnaNabavnaVrijednost = 0;
                    }
                    else
                    {
                        ukupnaNabavnaVrijednost = Convert.ToDecimal(uneUkupno.Value);
                    }

                    if (uneKolicina.Value == null)
                    {
                        kolicina = 0;
                    }
                    else
                    {
                        if (PrimkaStavkeUnosAmbalaza.ambalazaKolicina != null)
                        {
                            kolicina = Convert.ToDecimal(PrimkaStavkeUnosAmbalaza.ambalazaKolicina);
                        }
                        else
                        {
                            kolicina = Convert.ToDecimal(uneKolicina.Value);
                        }
                    }

                    porez = ucePorez.Text;
                    proizvod = (string)cmbProizvod.SelectedItem.GetType().GetProperty("Naziv").GetValue(cmbProizvod.SelectedItem, null); ;
                    jedinca_mjere = lblJedinica.Text;
                    idJedinacaMjere = Convert.ToInt32(lblJedinica.Tag);

                    if (PrimkaStavkeUnosAmbalaza.ambalazaMjerna != null)
                    {
                        idJedinacaMjere = (int)PrimkaStavkeUnosAmbalaza.ambalazaMjerna;
                        jedinca_mjere = PrimkaStavkeUnosAmbalaza.ambalazaMjernaTExt;
                    }

                    BusinessLogic.Primka.pPrimkaStavke.Rows.Add(false, BusinessLogic.Primka.pID, Convert.ToInt32(cmbProizvod.SelectedItem.GetType().GetProperty("ID").GetValue(cmbProizvod.SelectedItem, null))
                        , proizvod, idJedinacaMjere, jedinca_mjere, cijena, id_porez, porez, kolicina, cijenaPDV, null, ukupnaNabavnaVrijednost, redniBroj);

                    DataView dv = BusinessLogic.Primka.pPrimkaStavke.DefaultView;
                    dv.Sort = "RedniBroj";
                    BusinessLogic.Primka.pPrimkaStavke = dv.ToTable();
                    BusinessLogic.Primka.pPrimkaStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Primka.pPrimkaStavke.Columns["ID_Proizvoda"] };


                    return true;
                }
            }

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (cmbProizvod.SelectedItem == null)
            {
                message.Append(" - Proizvod je obavezno polje");
            }

            decimal parser;
            if (!decimal.TryParse(uneNetoCijena.Value.ToString(), out parser))
            {
                message.Append(" - Krivi format cijene");
            }

            if (!decimal.TryParse(uneNetoPlusNeMoze.Value.ToString(), out parser))
            {
                message.Append(" - Krivi format cijene sa PDV-om");
            }

            if (!decimal.TryParse(uneKolicina.Value.ToString(), out parser))
            {
                message.Append(" - Krivi format količine");
            }

            if (ucePorez.Value == null)
            {
                message.Append(" - Porez je obavezno polje");
            }

            return message;
        }

        private void LoadProizvod(BusinessLogic.Primka objekt)
        {
            cmbProizvod.Items.AddRange(objekt.GetProizvod());
            cmbProizvod.DisplayMember = "Naziv";
            cmbProizvod.ValueMember = "ID";
        }

        private void LoadForm()
        {
            foreach (var item in cmbProizvod.Items)
            {
                if (((Mipsed7.DataAccessLayer.SqlClient.FillCombo)(item)).ID == pProizvod)
                {
                    cmbProizvod.SelectedItem = item;
                    break;
                }
            }
            ucePorez.Value = pPorez;
            uneKolicina.Value = pKolicina;
            uneUkupno.Value = pUkupnaVrijednost;
            uneNetoCijena.Value = pNeto;
            uneNetoPlusNeMoze.Value = pNetoNeMoze;
            cmbProizvod.Focus();
        }

        private void LoadPorez(BusinessLogic.Primka objekt)
        {
            ucePorez.DataSource = objekt.GetPorez();
            ucePorez.DataBind();
        }

        #endregion

        #region Dogadaji

        private void tsbSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (!ProvjeraDaliVecPostoji())
            {
                if (SaveData())
                {

                    base.ContainerForm.DialogResult = DialogResult.OK;
                    base.ContainerForm.Close();

                    PrimkaStavkeUnosAmbalaza.ambalazaJedinicnaNeMoze = null;
                    PrimkaStavkeUnosAmbalaza.ambalazaKolicina = null;
                    PrimkaStavkeUnosAmbalaza.ambalazaMjerna = null;
                    PrimkaStavkeUnosAmbalaza.ambalazaJedinicnaNeto = null;
                }
            }
            else
            {
                MessageBox.Show("Nije moguće zadužiti isti proizvod sa različitim mjernim jedinicama.\n\rMolimo otvorite novi proizvod.",
                    "Upozorenje", MessageBoxButtons.OK);
            }
        }

        private bool ProvjeraDaliVecPostoji()
        {
            using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                try
                {
                    if (objekt.ProvjeraPostoji((int)cmbProizvod.SelectedItem.GetType().GetProperty("ID").GetValue(cmbProizvod.SelectedItem, null), PrimkaStavkeUnosAmbalaza.ambalazaMjerna, Convert.ToInt32(lblJedinica.Tag)))
                    {
                        return true;
                    }
                }
                catch { return false; }
            }

            return false;
        }

        private void tsbOdustani_Click(object sender, EventArgs e)
        {
            PrimkaStavkeUnosAmbalaza.ambalazaJedinicnaNeMoze = null;
            PrimkaStavkeUnosAmbalaza.ambalazaKolicina = null;
            PrimkaStavkeUnosAmbalaza.ambalazaMjerna = null;
            PrimkaStavkeUnosAmbalaza.ambalazaJedinicnaNeto = null;
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        private void tsbSpremiNovi_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                cmbProizvod.SelectedItem = null;
                uneKolicina.Value = 0;
                uneNetoCijena.Value = 0;
                uneNetoPlusNeMoze.Value = 0;
                uneUkupno.Value = 0;
                ucePorez.Value = null;
                cmbProizvod.Focus();
                FormEditMode = Enums.FormEditMode.Insert;

                PrimkaStavkeUnosAmbalaza.ambalazaJedinicnaNeMoze = null;
                PrimkaStavkeUnosAmbalaza.ambalazaKolicina = null;
                PrimkaStavkeUnosAmbalaza.ambalazaMjerna = null;
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                LoadProizvod(objekt);
                //LoadMjernaJedinica(objekt);
                LoadPorez(objekt);

                if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
                {
                    LoadForm();
                }
            }
        }

        #endregion

        private void uceProizvod_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProizvod.SelectedItem.GetType().GetProperty("ID").GetValue(cmbProizvod.SelectedItem, null) != null)
            {
                try
                {
                    FillMjeraPDV(Convert.ToInt32(cmbProizvod.SelectedItem.GetType().GetProperty("ID").GetValue(cmbProizvod.SelectedItem, null)));
                }
                catch
                {
                    ucePorez.Value = null;
                    lblJedinica.Text = string.Empty;
                }
            }
        }

        private void FillMjeraPDV(int proizvod)
        {
            using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                DataRow row = objekt.GetMjeraPDV(proizvod);

                lblJedinica.Text = row["JedinicaMjere"].ToString();
                lblJedinica.Tag = row["ID_JedinicaMjere"].ToString();
                ucePorez.Value = row["ID_PDV"];
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (ProizvodForm objekt = new ProizvodForm(Enums.FormEditMode.Insert))
            {
                if (objekt.ShowDialogForm("Proizvod") == DialogResult.OK)
                {
                }
                BusinessLogic.Primka objekt2 = new BusinessLogic.Primka();
                LoadProizvod(objekt2);
                cmbProizvod.Refresh();
            }
        }

        private void ucePorez_ValueChanged(object sender, EventArgs e)
        {
        }

        private void uneNabavnaCijena_ValueChanged(object sender, EventArgs e)
        {
            //if (ucePorez.Value != null)
            //{
            //    using (BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod())
            //    {
            //        try
            //        {
            //            double predPorez = objekt.PredPorez();
            //            double porez;
            //            double izracunPredporez;

            //            if (objekt.ObveznikPDV() & predPorez > 0)
            //            {
            //                porez = objekt.GetStopaPorez((int)ucePorez.Value) * Convert.ToDouble(uneNetoCijena.Value) / 100;
            //                izracunPredporez = porez * predPorez / 100;
            //                uneNetoPlusNeMoze.Value = Math.Round(Convert.ToDouble(uneNetoCijena.Value) + porez - izracunPredporez, 2);
            //            }
            //            else
            //            {
            //                porez = objekt.GetStopaPorez((int)ucePorez.Value) * Convert.ToDouble(uneNetoCijena.Value) / 100;
            //                uneNetoPlusNeMoze.Value = Math.Round(Convert.ToDouble(uneNetoCijena.Value) + porez, 2);
            //            }

            //            uneUkupno.Value = Math.Round(Convert.ToDecimal(uneNetoPlusNeMoze.Value) * Convert.ToDecimal(uneKolicina.Value), 2);
            //        }
            //        catch { }
            //    }
            //}
        }

        private void uneCijenaPDV_ValueChanged(object sender, EventArgs e)
        {
            //if (ucePorez.Value != null)
            //{
            //    using (BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod())
            //    {
            //        try
            //        {
            //            double predPorez = objekt.PredPorez();
            //            double stopa = objekt.GetStopaPorez((int)ucePorez.Value);

            //            if (objekt.ObveznikPDV() & predPorez > 0)
            //            {
            //                double stopaNeMoze = stopa - (stopa * (predPorez / 100));
            //                uneNetoCijena.Value = Math.Round(Convert.ToDouble(uneNetoPlusNeMoze.Value) / (1 + (stopaNeMoze / 100)), 2);
            //            }
            //            else
            //            {
            //                uneNetoCijena.Value = Math.Round(Convert.ToDouble(uneNetoPlusNeMoze.Value) / (1 + (stopa / 100)), 2);
            //            }
            //        }
            //        catch { }
            //    }
            //}
        }

        private void uneUkupno_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProizvod.SelectedItem != null & uneKolicina.Value != null & ucePorez.Value != null)
            {
                using (BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod())
                {
                    try
                    {
                        double stopa = objekt.GetStopaPorez((int)ucePorez.Value);
                        double porez;
                        double izracunPredporez;

                        double predPorez = objekt.PredPorez();

                        double stopaNeMoze = stopa - (stopa * (predPorez / 100));
                        uneNetoCijena.Value = Math.Round((Convert.ToDouble(uneUkupno.Value) / (1 + (stopa / 100))) / (Convert.ToDouble(uneKolicina.Value)), 4);

                        if (objekt.ObveznikPDV() & predPorez > 0)
                        {
                            porez = stopa * Convert.ToDouble(uneNetoCijena.Value) / 100;
                            izracunPredporez = porez * predPorez / 100;
                            uneNetoPlusNeMoze.Value = Math.Round((Convert.ToDouble(uneNetoCijena.Value) + porez - izracunPredporez), 4);
                        }
                        else
                        {
                            porez = stopa * Convert.ToDouble(uneNetoCijena.Value) / 100;
                            uneNetoPlusNeMoze.Value = Math.Round(Convert.ToDouble(uneNetoCijena.Value) + porez, 4);
                        }
                    }
                    catch { }
                }
            }
        }

        private void uneKolicina_ValueChanged(object sender, EventArgs e)
        {
            if (cmbProizvod.SelectedItem != null & uneUkupno.Value != null & ucePorez.Value != null)
            {
                using (BusinessLogic.Proizvod objekt = new BusinessLogic.Proizvod())
                {
                    try
                    {
                        double stopa = objekt.GetStopaPorez((int)ucePorez.Value);
                        double porez;
                        double izracunPredporez;

                        double predPorez = objekt.PredPorez();

                        double stopaNeMoze = stopa - (stopa * (predPorez / 100));
                        uneNetoCijena.Value = Math.Round((Convert.ToDouble(uneUkupno.Value) / (1 + (stopa / 100))) / (Convert.ToDouble(uneKolicina.Value)), 4);

                        if (objekt.ObveznikPDV() & predPorez > 0)
                        {
                            porez = stopa * Convert.ToDouble(uneNetoCijena.Value) / 100;
                            izracunPredporez = porez * predPorez / 100;
                            uneNetoPlusNeMoze.Value = Math.Round((Convert.ToDouble(uneNetoCijena.Value) + porez - izracunPredporez), 4);
                        }
                        else
                        {
                            porez = stopa * Convert.ToDouble(uneNetoCijena.Value) / 100;
                            uneNetoPlusNeMoze.Value = Math.Round(Convert.ToDouble(uneNetoCijena.Value) + porez, 4);
                        }
                    }
                    catch { }
                }
            }
        }

        private void btnAmbalaza_Click(object sender, EventArgs e)
        {
            if (uneKolicina.Value != null)
            {
                PrimkaStavkeUnosAmbalaza.kolicina = Math.Round(Convert.ToDecimal(uneKolicina.Value), 2);
                PrimkaStavkeUnosAmbalaza.mjernaJedinica = lblJedinica.Text;
                PrimkaStavkeUnosAmbalaza.netoNeMoze = Convert.ToDecimal(uneNetoPlusNeMoze.Value);
                PrimkaStavkeUnosAmbalaza.neto = Convert.ToDecimal(uneNetoCijena.Value);
            }

            using (PrimkaStavkeUnosAmbalaza objekt = new PrimkaStavkeUnosAmbalaza(Enums.FormEditMode.Insert))
            {

                if (objekt.ShowDialogForm("PrimkaAmbalaza") == DialogResult.OK)
                {
                    tsbSpremiZatvori_Click(null, null);
                }
            }
        }

        private void btnKalkulacija_Click(object sender, EventArgs e)
        {
            if (uneUkupno.Value != null && ucePorez.Value != null && cmbProizvod.SelectedItem.GetType().GetProperty("ID").GetValue(cmbProizvod.SelectedItem, null) != null)
            {
                uneUkupno.Value = GetUkupnoProizvod(uneUkupno.Value, ucePorez.Value, cmbProizvod.SelectedItem.GetType().GetProperty("ID").GetValue(cmbProizvod.SelectedItem, null));
            }
        }

        private object GetUkupnoProizvod(object ukupnoPrije, object porez, object proizvod)
        {
            using (BusinessLogic.Primka objekt = new BusinessLogic.Primka())
            {
                return objekt.UkupnaCijena(ukupnoPrije, porez, proizvod);
            }
        }

        private void uneUkupno_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            uneUkupno.SelectAll();
        }

        private void uneKolicina_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            uneKolicina.SelectAll();
        }

        private void uneNetoCijena_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            uneNetoCijena.SelectAll();
        }

        private void uneNetoPlusNeMoze_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            uneNetoPlusNeMoze.SelectAll();
        }

        private void cmbProizvod_KeyPress(object sender, KeyPressEventArgs e)
        {
            uceDokumentKeyPressed();
        }

        private void cmbProizvod_TextChanged(object sender, EventArgs e)
        {
            if (cmbProizvod.Text.Length == 0) uceDokumentKeyPressed();
        }
        private void uceDokumentKeyPressed()
        {
            cmbProizvod.DroppedDown = true;

            object[] originalList = (object[])cmbProizvod.Tag;
            if (originalList == null)
            {
                // backup original list
                originalList = new object[cmbProizvod.Items.Count];
                cmbProizvod.Items.CopyTo(originalList, 0);
                cmbProizvod.Tag = originalList;
            }

            // prepare list of matching items
            string s = cmbProizvod.Text.ToLower();
            IEnumerable<object> newList = originalList;



            if (s.Length > 0)
            {

                newList = originalList.Where(item => item.GetType().GetProperty("Naziv").GetValue(item, null).ToString().ToLower().Contains(s));

                //newList = originalList.Where(item => item[1].ToString().ToLower().Contains(s));
            }

            // clear list (loop through it, otherwise the cursor would move to the beginning of the textbox...)
            while (cmbProizvod.Items.Count > 0)
            {
                cmbProizvod.Items.RemoveAt(0);
            }

            // re-set list
            cmbProizvod.Items.AddRange(newList.ToArray());
            cmbProizvod.DisplayMember = "Naziv";
            cmbProizvod.ValueMember = "ID";
        }

        private void cmbProizvod_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbProizvod.SelectedItem != null)
            {
                try
                {
                    FillMjeraPDV(Convert.ToInt32(cmbProizvod.SelectedItem.GetType().GetProperty("ID").GetValue(cmbProizvod.SelectedItem, null)));
                }
                catch
                {
                    ucePorez.Value = null;
                    lblJedinica.Text = string.Empty;
                }
            }
        }
    }
}
