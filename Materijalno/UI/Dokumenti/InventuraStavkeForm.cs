using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Materijalno.Enums;
using Materijalno.BusinessLogic;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;

namespace Materijalno.UI.Dokumenti
{
    public partial class InventuraStavkeForm : Controls.BaseUserControl
    {
        bool _loadMode;

        SqlClient client;

        #region Properties
        private FormEditMode FormEditMode { get; set; }
        public int pStavka { get; set; }
        public int pSkladiste { get; set; }
        public int pInventura { get; set; }
        public Nullable<decimal> pKolicina { get; set; }
        public Nullable<decimal> pNabavnaCijena { get; set; }
        public decimal pStanje { get; set; }
        public DateTime pDatum { get; set; }
        public decimal kolicinaEdit { get; set; }

        #endregion

        #region Methods
        public InventuraStavkeForm(FormEditMode formEditMode)
        {
            InitializeComponent();

            client = new SqlClient();

            FormEditMode = formEditMode;
        }

        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        private bool SaveData()
        {
            lblValidationMessages.ResetText();

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                decimal kolicina = Convert.ToDecimal(uneKolicina.Value);
                decimal cijena = Convert.ToDecimal(uneNabavnaCijena.Value);
                int redniBroj = BusinessLogic.Inventura.pInventuraStavke.Rows.Count + 1;

                if (ProvjeraZaMinus(kolicina, Convert.ToDecimal(lblStanje.Text)))
                {
                    MessageBox.Show("Nije dozvoljen unos artikala u minus.\nNazovite podršku na tel: 01/4645-655.", "Upozorenje");
                    return false;
                }
                else if (ProvjeraZaMinus2(kolicina, Convert.ToDecimal(lblStanje.Text)))
                {
                    DialogResult result = MessageBox.Show("Upozorenje artikl ide u minus želite li nastaviti?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.No)
                    {
                        return false;
                    }
                }

                if (FormEditMode == Enums.FormEditMode.Insert || FormEditMode == Enums.FormEditMode.Copy)
                {
                    DataRow row = null;

                    try
                    {
                        row = BusinessLogic.Inventura.pInventuraStavke.Rows.Find((int)uceStavka.SelectedItem.GetType().GetProperty("ID").GetValue(this.uceStavka.SelectedItem, null));
                    }
                    catch { }

                    if (row != null)
                    {
                        message.Append("- Proizvod je već dodan, nije moguće dodavati 2 ista proizvoda.");
                    }
                    else
                    {
                        //tu ide poziv metodi koja ispravlja string 
                        string opis = IspravakNazivaStavke(uceStavka.Text);

                        //dodavanje stavke u popis postojećih
                        BusinessLogic.Inventura.pInventuraStavke.Rows.Add(false, BusinessLogic.Inventura.pID, (int)uceStavka.SelectedItem.GetType().GetProperty("ID").GetValue(this.uceStavka.SelectedItem, null), opis, kolicina, cijena);

                        int idStavke = 0;
                        decimal stanjeNaSklad = 0;
                        try
                        {
                            idStavke = (int)uceStavka.SelectedItem.GetType().GetProperty("ID").GetValue(this.uceStavka.SelectedItem, null);
                            stanjeNaSklad = Convert.ToDecimal(lblStanje.Text);
                        }
                        catch { }

                        //db - 4.1.2017
                        SqlConnection conn = new SqlConnection();
                        conn = client.sqlConnection;                             
                        SqlCommand com = new SqlCommand();
                        com.Connection = conn;
                        com.CommandType = CommandType.Text;

                        com.Parameters.AddWithValue("@IDInventura", BusinessLogic.Inventura.pID);
                        com.Parameters.AddWithValue("@IDStavke", idStavke);
                        com.Parameters.AddWithValue("@StanjeNaSklad", stanjeNaSklad);

                        //Provjera postojanja prvo, a ukoliko ne postoji u popisu stavki
                        //ONDA OVDJE IDE UPIS U BAZU ODMAH!!!!
                        com.CommandText = ("Insert into MT_InventuraStavka (ID_Inventura, ID_Proizvod, KolicinaZaliha) values (@IDInventura, @IDStavke, @StanjeNaSklad)");
                        
                        if (client.sqlConnection.State == ConnectionState.Closed) conn.Open();

                        try
                        {
                            com.ExecuteNonQuery();
                        }
                        catch (SqlException greska)
                        {
                        }
                        catch (Exception greska)
                        {
                        }

                        conn.Close();

                        //FormEditMode = Enums.FormEditMode.Update;
                        return true;
                    }
                }
                else if (this.FormEditMode == Enums.FormEditMode.Update)
                {
                    //db - 3.1.2017
                    pStavka = (int)uceStavka.SelectedItem.GetType().GetProperty("ID").GetValue(this.uceStavka.SelectedItem, null);

                    DataRow red = BusinessLogic.Inventura.pInventuraStavke.Select("ID_Proizvod = " + pStavka)[0];

                    //redniBroj = Convert.ToInt32(red["RedniBroj"]);

                    BusinessLogic.Inventura.pInventuraStavke.Rows.Remove(red);
                    BusinessLogic.Inventura.pInventuraStavke.AcceptChanges();

                    BusinessLogic.Inventura.pInventuraStavke.Rows.Add(false, BusinessLogic.Inventura.pID, pStavka, uceStavka.Text, kolicina, cijena);


                    DataView dv = BusinessLogic.Inventura.pInventuraStavke.DefaultView;
                    dv.Sort = "StavkaSkladista";
                    BusinessLogic.Inventura.pInventuraStavke = dv.ToTable();
                    BusinessLogic.Inventura.pInventuraStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Inventura.pInventuraStavke.Columns["ID_Proizvod"] };

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
            if (stanje - kolicina < 0)
            {
                return true;
            }

            return false;
        }

        private string IspravakNazivaStavke(string text)
        {
            int pozicija = 0;
            string opis = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text == "|") pozicija = i;
            }

            int pozicija2 = text.IndexOf("|");
            opis = text.Substring(pozicija2+2);

            return opis;
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

        #region Events

        private void tsbOdustani_Click(object sender, EventArgs e)
        {
            base.ContainerForm.DialogResult = DialogResult.OK;
            base.ContainerForm.Close();
        }

        private void tsbSpremiZatvori_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            _loadMode = true;//db - 07.02.2017

            using (BusinessLogic.Inventura objekt = new BusinessLogic.Inventura())
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
            _loadMode = false;
        }

        private void LoadSkladiste(BusinessLogic.Inventura objekt, int skladiste)
        {
            uceStavka.Items.AddRange(objekt.GetStavka(skladiste)); //dohvat iz BAZE!!
            uceStavka.DisplayMember = "Naziv";
            uceStavka.ValueMember = "ID";
        }       

        private void uceStavka_SelectedValueChanged(object sender, EventArgs e)
        {
            if (_loadMode == true) return;

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
            using (BusinessLogic.Inventura objekt = new BusinessLogic.Inventura())
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

        private void uceStavka_TextChanged(object sender, EventArgs e)
        {
            if (uceStavka.Text.Length == 0) uceDokumentKeyPressed();
        }

        #endregion
    }
}
