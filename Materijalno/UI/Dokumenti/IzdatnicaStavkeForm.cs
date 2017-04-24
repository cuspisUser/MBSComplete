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
    public partial class IzdatnicaStavkeForm : Controls.BaseUserControl
    {
        #region Properties
        private FormEditMode FormEditMode { get; set; }
        public int pStavka { get; set; }
        public int pSkladiste { get; set; }
        public Nullable<decimal> pKolicina { get; set; }
        public Nullable<decimal> pNabavnaCijena { get; set; }
        public string pStanje { get; set; }
        public DateTime pDatum { get; set; }
        public decimal kolicinaEdit { get; set; }

        #endregion

        #region Methods

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        public IzdatnicaStavkeForm(FormEditMode formEditMode)
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
                decimal kolicina = Convert.ToDecimal(uneKolicina.Value);
                decimal cijena = Convert.ToDecimal(uneNabavnaCijena.Value);
                int redniBroj = BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows.Count + 1;

                if (ProvjeraZaMinus(kolicina, Convert.ToDecimal(lblStanje.Text)))
                {
                    MessageBox.Show("Nije dozvoljen unos artikala u minus.\nNazovite podršku na tel: 01/4645-655.", "Upozorenje");
                    return false;
                }
                else if(ProvjeraZaMinus2(kolicina, Convert.ToDecimal(lblStanje.Text)))
                {
                    DialogResult result = MessageBox.Show("Upozorenje artikl ide u minus želite li nastaviti?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.No)
                    {
                        return false;
                    }
                }

                if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
                {

                    DataRow row = BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows.Find((int)uceStavka.SelectedItem.GetType().GetProperty("ID").GetValue(this.uceStavka.SelectedItem, null));

                    if (row != null)
                    {
                        message.Append("- Proizvod je već dodan, nije moguće dodavati 2 ista proizvoda.");
                    }
                    else
                    {

                        BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows.Add(false, BusinessLogic.Izdatnica.pID, (int)uceStavka.SelectedItem.GetType().GetProperty("ID").GetValue(this.uceStavka.SelectedItem, null), uceStavka.Text,
                                                                   kolicina, cijena, redniBroj);

                        FormEditMode = Enums.FormEditMode.Update;
                        return true;
                    }
                }
                else if (this.FormEditMode == Enums.FormEditMode.Update)
                {

                    DataRow red = BusinessLogic.Izdatnica.pIzdatnicaStavke.Select("ID_Proizvoda = " + pStavka)[0];

                    redniBroj = Convert.ToInt32(red["RedniBroj"]);

                    BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows.Remove(red);
                    BusinessLogic.Izdatnica.pIzdatnicaStavke.AcceptChanges();

                    BusinessLogic.Izdatnica.pIzdatnicaStavke.Rows.Add(false, BusinessLogic.Izdatnica.pID, (int)uceStavka.SelectedItem.GetType().GetProperty("ID").GetValue(this.uceStavka.SelectedItem, null), uceStavka.Text,
                                                                      kolicina, cijena, redniBroj);


                    DataView dv = BusinessLogic.Izdatnica.pIzdatnicaStavke.DefaultView;
                    dv.Sort = "RedniBroj";
                    BusinessLogic.Izdatnica.pIzdatnicaStavke = dv.ToTable();
                    BusinessLogic.Izdatnica.pIzdatnicaStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Izdatnica.pIzdatnicaStavke.Columns["ID_Proizvoda"] };

                    return true;
                }
            }

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        private bool ProvjeraZaMinus(decimal kolicina, decimal stanje)
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            string materijalno = client.ExecuteScalar("Select Distinct Materijalno From Korisnik").ToString();

            if (materijalno == "True" & (stanje - kolicina) < 0)
            {
                return true;
            }

            return false;
        }

        private bool ProvjeraZaMinus2(decimal kolicina, decimal stanje)
        {
            if (stanje  - kolicina < 0)
            {
                return true;
            }

            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            if (uceStavka.SelectedItem == null)
            {
                message.Append("- Stavka skladišta je obavezna");
            }
            decimal parser;

            if (!decimal.TryParse(uneKolicina.Value.ToString(), out parser))
            {
                message.Append("- Krivi format količine");
            }

            if (!decimal.TryParse(uneNabavnaCijena.Value.ToString(), out parser))
            {
                message.Append("- Krivi format cijene");
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
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        //private void tsbSpremiNovi_Click(object sender, EventArgs e)
        //{
        //    if (SaveData())
        //    {
        //        uceStavka.SelectedItem = null;
        //        uneKolicina.Value = null;
        //        uneNabavnaCijena.Value = null;

        //        FormEditMode = Enums.FormEditMode.Insert;
        //    }
        //}

        private void FormLoad(object sender, EventArgs e)
        {
            using (BusinessLogic.Izdatnica objekt = new BusinessLogic.Izdatnica())
            {
                LoadSkladiste(objekt, pSkladiste);

                if (FormEditMode == Enums.FormEditMode.Update || FormEditMode == Enums.FormEditMode.Copy)
                {
                    foreach (var item in uceStavka.Items)
                    {
                        if (((Mipsed7.DataAccessLayer.SqlClient.FillCombo)(item)).ID == pStavka)
                        {
                            uceStavka.SelectedItem = item;
                            break;
                        }
                    }
                    uneKolicina.Value = pKolicina;
                    uneNabavnaCijena.Value = pNabavnaCijena;
                    uceStavka.DisplayMember = "Naziv";
                    uceStavka.ValueMember = "ID";
                }
            }
        }

        private void LoadSkladiste(BusinessLogic.Izdatnica objekt, int skladiste)
        {
            uceStavka.Items.AddRange(objekt.GetStavka(skladiste));
            uceStavka.DisplayMember = "Naziv";
            uceStavka.ValueMember = "ID";
        }

        #endregion

        //private void uceStavka_ValueChanged(object sender, EventArgs e)
        //{
        //    if (uceStavka.SelectedItem != null)
        //    {
        //        try
        //        {
        //            FillStanjeNaSkladistu((int)uceStavka.SelectedItem.GetType().GetProperty("ID").GetValue(this.uceStavka.SelectedItem, null));
        //        }
        //        catch
        //        {
        //            uneKolicina.Value = null;
        //            uneNabavnaCijena.Value = null;
        //            lblStanje.Text = "";
        //        }
        //    }
        //}

        private void uceStavka_SelectedValueChanged(object sender, EventArgs e)
        {
            if (uceStavka.SelectedItem != null)
            {
                try
                {
                    FillStanjeNaSkladistu((int)uceStavka.SelectedItem.GetType().GetProperty("ID").GetValue(this.uceStavka.SelectedItem, null));
                }
                catch
                {
                    uneKolicina.Value = 1;
                    uneNabavnaCijena.Value = 0;
                    lblStanje.Text = "0.00";
                }
            }
        }

        private void FillStanjeNaSkladistu(int stavka)
        {
            using (BusinessLogic.Izdatnica objekt = new BusinessLogic.Izdatnica())
            {
                var row = objekt.GetStanjeSkladiste(stavka, pSkladiste, pDatum);
                lblStanje.Text = (Convert.ToDecimal(row["Stanje"]) + kolicinaEdit).ToString();
                try
                {
                    uneNabavnaCijena.Value = row["Cijena"];
                    pNabavnaCijena = Convert.ToDecimal(uneNabavnaCijena.Value);
                }
                catch { uneNabavnaCijena.Value = pNabavnaCijena; }
            }
        }

        private void uneKolicina_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            uneKolicina.SelectAll();
        }

        private void uneNabavnaCijena_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            uneNabavnaCijena.SelectAll();
        }

        private void uceStavka_KeyPress(object sender, KeyPressEventArgs e)
        {
            uceDokumentKeyPressed();
        }

        private void uceStavka_KeyUp(object sender, KeyEventArgs e)
        {
            //uceDokumentKeyPressed();
        }

        private void uceStavka_TextChanged(object sender, EventArgs e)
        {
            if (uceStavka.Text.Length == 0) uceDokumentKeyPressed();
        }
        private void uceDokumentKeyPressed()
        {
            uceStavka.DroppedDown = true;

            object[] originalList = (object[])uceStavka.Tag;
            if (originalList == null)
            {
                // backup original list
                originalList = new object[uceStavka.Items.Count];
                uceStavka.Items.CopyTo(originalList, 0);
                uceStavka.Tag = originalList;
            }

            // prepare list of matching items
            string s = uceStavka.Text.ToLower();
            IEnumerable<object> newList = originalList;



            if (s.Length > 0)
            {

                newList = originalList.Where(item => item.GetType().GetProperty("Naziv").GetValue(item, null).ToString().ToLower().Contains(s));

                //newList = originalList.Where(item => item[1].ToString().ToLower().Contains(s));
            }

            // clear list (loop through it, otherwise the cursor would move to the beginning of the textbox...)
            while (uceStavka.Items.Count > 0)
            {
                uceStavka.Items.RemoveAt(0);
            }

            // re-set list
            uceStavka.Items.AddRange(newList.ToArray());
            uceStavka.DisplayMember = "Naziv";
            uceStavka.ValueMember = "ID";
        }

  

    }
}
