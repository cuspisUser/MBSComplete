using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using Materijalno.Enums;
using Infragistics.Win.UltraWinGrid;
using Materijalno.BusinessLogic;

namespace Materijalno.UI.Dokumenti
{
    public partial class InventuraForm : Controls.BaseUserControl
    {
        SqlClient client = null;

        public event EventHandler<EventArgs> MyEvent;

        #region Properties
        private FormEditMode FormEditMode { get; set; }
       
        #endregion

        #region Methods       
      
        private void FormLoad(object sender, EventArgs e)
        {
            BusinessLogic.Inventura.pInventuraStavke = new DataTable();
            BusinessLogic.Inventura.pInventuraStavke.Columns.Add("SEL", typeof(bool));
            BusinessLogic.Inventura.pInventuraStavke.Columns.Add("ID_Izdatnice", typeof(int));
            BusinessLogic.Inventura.pInventuraStavke.Columns.Add("ID_Proizvoda", typeof(int));
            BusinessLogic.Inventura.pInventuraStavke.Columns.Add("StavkaSkladista", typeof(string));
            BusinessLogic.Inventura.pInventuraStavke.Columns.Add("Kolicina", typeof(decimal));
            BusinessLogic.Inventura.pInventuraStavke.Columns.Add("NabavnaCijena", typeof(decimal));
            BusinessLogic.Inventura.pInventuraStavke.Columns.Add("RedniBroj", typeof(int));
            BusinessLogic.Inventura.pInventuraStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Inventura.pInventuraStavke.Columns["ID_Proizvoda"] };

            using (BusinessLogic.Inventura objekt = new BusinessLogic.Inventura())
            {
                udtDatumInventure.Enabled = true;
                udtDatumInventure.Value = DateTime.Now;

                LoadSkladiste(objekt);

                if (FormEditMode == Enums.FormEditMode.Update)
                {
                    LoadForm(objekt);
                }
                else if (FormEditMode == Enums.FormEditMode.Copy)
                {
                    LoadForm(objekt);
                }
            }
        }

        public InventuraForm()
        { }

        public InventuraForm(FormEditMode formEditMode)
        {
            InitializeComponent();

            FormEditMode = formEditMode;
            client = new SqlClient();

            if (formEditMode == Enums.FormEditMode.Insert)
            {
                btnNovaStavka.Visible = false;
                btnUrediStavku.Visible = false;
                btnBrisiStavku.Visible = false;
                gbxStavke.Visible = false;

                this.Size = new Size(692, 200);
            }
        }

      
        public DialogResult ShowDialogForm(string title)
        {
            return base.ShowDialog(title, this);
        }

        private void LoadStavke()
        {        
            //db - 2.1.2017 --> sortiranje stavaka u tablici
            DataView dv = BusinessLogic.Inventura.pInventuraStavke.DefaultView;
            dv.Sort = "StavkaSkladista";
            BusinessLogic.Inventura.pInventuraStavke = dv.ToTable();

            ugdInventuraStavke.DataSource = BusinessLogic.Inventura.pInventuraStavke;
            ugdInventuraStavke.DataBind();
       

            string[] popis = new string[] { "StvarnaKolicina" };

            Utils.Tools.UltraGridStyling(ugdInventuraStavke, popis);

            if (ugdInventuraStavke.DisplayLayout.Bands.Count > 0)
            {
                ugdInventuraStavke.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                ugdInventuraStavke.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                ugdInventuraStavke.DisplayLayout.Bands[0].Columns["ID_Inventura"].Hidden = true;
                ugdInventuraStavke.DisplayLayout.Bands[0].Columns["ID_Proizvod"].Hidden = true;

                ugdInventuraStavke.DisplayLayout.Bands[0].Columns["StavkaSkladista"].Format = "F4";
                ugdInventuraStavke.DisplayLayout.Bands[0].Columns["KolicinaZaliha"].Format = "F4";
                ugdInventuraStavke.DisplayLayout.Bands[0].Columns["StvarnaKolicina"].Format = "F4";

                //ugdInventuraStavke.DisplayLayout.Bands[0].Columns["RedniBroj"].Header.VisiblePosition = 1;
                ugdInventuraStavke.DisplayLayout.Bands[0].Columns["StavkaSkladista"].Header.VisiblePosition = 2;
                ugdInventuraStavke.DisplayLayout.Bands[0].Columns["KolicinaZaliha"].Header.VisiblePosition = 3;
                ugdInventuraStavke.DisplayLayout.Bands[0].Columns["StvarnaKolicina"].Header.VisiblePosition = 4;
            }

        }

        private bool SaveData()
        {
            if (uceSkladiste.Text == "")
            {
                uceSkladiste.Focus();
                return false;
            }

            lblValidationMessages.ResetText();

            StringBuilder message = ValidateDataInput();
            if (message.Length == 0)
            {
                using (BusinessLogic.Inventura objekt = new BusinessLogic.Inventura())
                {
                    objekt.idSkladiste = (Int32)uceSkladiste.Value;
                    Inventura.datumInventure = udtDatumInventure.DateTime;
                    objekt.idGodina = (Int16)udtDatumInventure.DateTime.Year;

                    ////set current time na odabrani datum ako je vrijeme 0
                    //if (objekt.pDatumNastajanja.TimeOfDay.TotalSeconds == 0)
                    //{
                    //    DateTime date = objekt.pDatumNastajanja.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second);
                    //    objekt.pDatumNastajanja = date;
                    //}

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
                        int brojStavki = 0;
                        brojStavki = ugdInventuraStavke.Rows.Count;

                        //nova tablica koja prima izmjenjene stavke s grida
                        InventuraStavke stav = new InventuraStavke();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("IDInventure", typeof(int));
                        dt.Columns.Add("IDProizvod", typeof(int));
                        dt.Columns.Add("Cijena", typeof(decimal));
                        dt.Columns.Add("KolicinaZaliha", typeof(decimal));
                        dt.Columns.Add("StvarnaKolicina", typeof(decimal));

                        //dodavanje redova
                        for (int i = 0; i < brojStavki; i++)
                        {
                            DataRow dr = dt.NewRow();
                            dt.Rows.Add(dr);
                        }

                        //db - 02.02.2017 - ubačena IMENA umjesto indexa kolona
                        //prebacivanje vrijednosti
                        for (int i = 0; i < ugdInventuraStavke.Rows.Count; i++)
                        {
                            dt.Rows[i]["IDInventure"] = Convert.ToInt32(ugdInventuraStavke.Rows[i].Cells["ID_Inventura"].Value);
                            dt.Rows[i]["IDProizvod"] = Convert.ToInt32(ugdInventuraStavke.Rows[i].Cells["ID_Proizvod"].Value);
                            dt.Rows[i]["KolicinaZaliha"] = Convert.ToDecimal(ugdInventuraStavke.Rows[i].Cells["KolicinaZaliha"].Value);

                            if (ugdInventuraStavke.Rows[i].Cells["StvarnaKolicina"].Value == DBNull.Value)
                            {
                                dt.Rows[i]["StvarnaKolicina"] = DBNull.Value;
                            }
                            else
                            {
                                dt.Rows[i]["StvarnaKolicina"] = Convert.ToDecimal(ugdInventuraStavke.Rows[i].Cells["StvarnaKolicina"].Value);
                            }
                        }

                        objekt.UpdateStavke(Convert.ToInt32(dt.Rows[0][0]), dt);
                        return true;
                    }
                }
            }

            //setiranje natrag na false
            Materijalno.UI.Dokumenti.InventuraFormPregled._update = false;
            Materijalno.UI.Dokumenti.InventuraFormPregled._insert = false;

            lblValidationMessages.Text = message.ToString();
            return false;
        }

        public StringBuilder ValidateDataInput()
        {
            StringBuilder message = new StringBuilder();

            ////sifra
            //if (uteSkladiste.Value == null)
            //{
            //    message.Append(" - Šifre je obavezno polje");
            //}
            //else if (uteSkladiste.Value.ToString().Any(u => char.IsLetter(u)))
            //{
            //    message.Append(" - Šifra primke nesmije sadržavati slova");
            //}
            //else if (uteSkladiste.Value.ToString().Length > 50)
            //{
            //    message.Append(" - Maksimalna dužina šifre je 50");
            //}

            //datum nastajanja
            if (udtDatumInventure.Value == null)
            {
                message.Append(" - Datum je obavezno polje");
            }


            return message;
        }

        private void LoadForm(BusinessLogic.Inventura objekt)
        {
            var selected = objekt.GetSelectedInventura();

            if (selected != null)
            {
                udtDatumInventure.Value = Convert.ToDateTime(selected["DatumInventure"].ToString());
                //udtDatumNastajanja.Enabled = false;

                uceSkladiste.Value = Convert.ToInt32(selected["IDSkladiste"].ToString());

                //setiranje stavki za punjenje grida
                BusinessLogic.Inventura.pInventuraStavke = objekt.GetPostojeceStavke();
                BusinessLogic.Inventura.pInventuraStavke.PrimaryKey = new DataColumn[] { BusinessLogic.Inventura.pInventuraStavke.Columns["ID_Proizvod"] };

                //punjenje grida
                ugdInventuraStavke.DataSource = BusinessLogic.Inventura.pInventuraStavke;
                ugdInventuraStavke.DataBind();

                //selekcija editabilnih kolona
                Utils.Tools.UltraGridStyling(ugdInventuraStavke);

                if (ugdInventuraStavke.DisplayLayout.Bands.Count > 0)
                {
                    ugdInventuraStavke.DisplayLayout.Bands[0].Columns["SEL"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    ugdInventuraStavke.DisplayLayout.Bands[0].Columns["SEL"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                    ugdInventuraStavke.DisplayLayout.Bands[0].Columns["ID_Inventura"].Hidden = true;
                    ugdInventuraStavke.DisplayLayout.Bands[0].Columns["ID_Proizvod"].Hidden = true;

                    ugdInventuraStavke.DisplayLayout.Bands[0].Columns["StavkaSkladista"].Format = "F4";
                    ugdInventuraStavke.DisplayLayout.Bands[0].Columns["KolicinaZaliha"].Format = "F4";
                    ugdInventuraStavke.DisplayLayout.Bands[0].Columns["StvarnaKolicina"].Format = "F4";

                    //ugdInventuraStavke.DisplayLayout.Bands[0].Columns["RedniBroj"].Header.VisiblePosition = 1;
                    ugdInventuraStavke.DisplayLayout.Bands[0].Columns["StavkaSkladista"].Header.VisiblePosition = 2;
                    ugdInventuraStavke.DisplayLayout.Bands[0].Columns["KolicinaZaliha"].Header.VisiblePosition = 3;
                    ugdInventuraStavke.DisplayLayout.Bands[0].Columns["StvarnaKolicina"].Header.VisiblePosition = 4;
                }

                if (BusinessLogic.Inventura.pInventuraStavke.Rows.Count == 0)
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

        /// <summary>
        /// Punjenje skladišta u combo
        /// </summary>
        /// <param name="objekt"></param>
        private void LoadSkladiste(BusinessLogic.Inventura objekt)
        {
            uceSkladiste.DataSource = objekt.GetSkladiste();
            uceSkladiste.DataBind();
        }
        private void NapuniSkladiste()
        {
            BusinessLogic.OtvaranjeSkladista objekt = new BusinessLogic.OtvaranjeSkladista();
            uceSkladiste.DisplayMember = "Naziv";
            uceSkladiste.ValueMember = "ID";
            uceSkladiste.DataSource = objekt.GetSkladista();
        }
        private void RecalculateRedniBroj()
        {
            int redniBroj = 1;

            foreach (DataRow row in BusinessLogic.Inventura.pInventuraStavke.Rows)
            {
                row["RedniBroj"] = redniBroj;
                redniBroj++;
            }
        }


        #endregion

        #region Events
        public void tsbSpremiZatvori_Click(object sender, EventArgs e)
        {
            //db - 02.02.2017
            if (Materijalno.UI.Dokumenti.InventuraFormPregled._update == false)
            {
                //db - 26.1.2017 - provjera postojanja u bazi
                SqlConnection conn = new SqlConnection();
                conn = client.sqlConnection;

                if (client.sqlConnection.State == ConnectionState.Closed) conn.Open();

                int broj = 0;

                SqlCommand com = new SqlCommand("select Count(ID) from MT_Inventura where IDSKladiste = '" + Convert.ToInt32(uceSkladiste.Value) + "' and  DatumInventure = cast(@Datum as date)  ", conn);
                //com.Parameters.AddWithValue("@IDSklad", Convert.ToInt32(uceSkladiste.Value));
                com.Parameters.AddWithValue("@Datum", Convert.ToDateTime(udtDatumInventure.Value));
                broj = (int)com.ExecuteScalar();

                if (broj == 1)
                {
                    MessageBox.Show("Već postoji inventura s tim skladištem i datumom.");
                    return;
                }

                conn.Close();
            }


            this.Cursor = Cursors.WaitCursor;
            if (SaveData())
            {
                //db - 02.02.2017
                //setiranje natrag na false
                Materijalno.UI.Dokumenti.InventuraFormPregled._update = false;
                Materijalno.UI.Dokumenti.InventuraFormPregled._insert = false;

                //postavljanje broja inventure u InventuraFormPregled
                if (BusinessLogic.Inventura.pID != null) InventuraFormPregled._idInv = (int)BusinessLogic.Inventura.pID;

                this.Cursor = Cursors.Default;
                BusinessLogic.Inventura.pID = null;
                base.ContainerForm.DialogResult = DialogResult.OK;
                base.ContainerForm.Close();
            }
            this.Cursor = Cursors.Default;

            OnMyEvent(new EventArgs());
        }

        protected virtual void OnMyEvent(EventArgs e)
        {
            //EventHandler handler = MyEvent;

            //if (handler != null)
            //{
            //    handler(this, e);
            //}
        }

        private void tsbOdustani_Click(object sender, EventArgs e)
        {
            BusinessLogic.Inventura.pID = null;
            base.ContainerForm.DialogResult = DialogResult.Cancel;
            base.ContainerForm.Close();
        }

        private void btnNovaStavka_Click(object sender, EventArgs e)
        {
            using (InventuraStavkeForm objekt = new InventuraStavkeForm(Enums.FormEditMode.Insert))
            {
                lblValidationMessages.Text = string.Empty;

                if (uceSkladiste.Value != null)
                {
                    objekt.pSkladiste = (int)uceSkladiste.Value;
                    objekt.pDatum = udtDatumInventure.DateTime;

                    if (objekt.ShowDialogForm("InventuraStavka") == DialogResult.OK)
                    {
                        LoadStavke();
                    }
                }
                else
                {
                    lblValidationMessages.Text = "- Potrebno je odabrati skladište da bi se mogla unositi stavka!";
                }
            }

            DataTable dt = new DataTable();
            dt = client.GetDataTable("select 'false' as SEL, stav.ID_Inventura, stav.ID_Proizvod,	pro.NAZIVPROIZVOD As StavkaSkladista, stav.KolicinaZaliha, stav.StvarnaKolicina " +
                               "from MT_InventuraStavka stav inner join PROIZVOD pro on pro.IDPROIZVOD = stav.ID_Proizvod " +
                               "order by stav.ID");
            BusinessLogic.Inventura.pInventuraStavke = dt;
        }

        private void btnUrediStavku_Click(object sender, EventArgs e)
        {
            if (ugdInventuraStavke.Rows.Count == 0) return;

            using (InventuraStavkeForm objekt = new InventuraStavkeForm(Enums.FormEditMode.Update))
            {
                lblValidationMessages.Text = string.Empty;
                if (uceSkladiste.Value != null)
                {
                    objekt.pSkladiste = (int)uceSkladiste.Value;
                    objekt.pStavka = (int)ugdInventuraStavke.ActiveRow.Cells["ID_Proizvod"].Value;
                    objekt.pInventura = (int)ugdInventuraStavke.ActiveRow.Cells["ID_Inventura"].Value;
                    objekt.pKolicina = IsDbNull<decimal>(ugdInventuraStavke.ActiveRow.Cells["KolicinaZaliha"].Value);
                    objekt.pStanje = Convert.ToDecimal(ugdInventuraStavke.ActiveRow.Cells["StvarnaKolicina"].Value);
                    //objekt.pNabavnaCijena = IsDbNull<decimal>(ugdInventuraStavke.ActiveRow.Cells["NabavnaCijena"].Value);
                    //objekt.kolicinaEdit = (decimal)ugdInventuraStavke.ActiveRow.Cells["nekajebenakolicina"].Value;
                    objekt.pDatum = udtDatumInventure.DateTime;

                    if (FormEditMode == Enums.FormEditMode.Update)
                    {
                        objekt.kolicinaEdit = objekt.pKolicina.Value;
                    }
                    else
                    {
                        objekt.kolicinaEdit = 0;
                    }

                    if (objekt.ShowDialogForm("InventuraStavka") == DialogResult.OK)
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

        private void btnBrisiStavku_Click_1(object sender, EventArgs e)
        {
            for (int i = ugdInventuraStavke.Rows.Count - 1; i > -1; i--)
            {
                if (bool.Parse(ugdInventuraStavke.Rows[i].Cells["SEL"].Value.ToString()))
                {
                    try
                    {
                        DataRow row = BusinessLogic.Inventura.pInventuraStavke.Rows.Find(ugdInventuraStavke.Rows[i].Cells["ID_Proizvod"].Value);

                        if (row != null)
                        {
                            BusinessLogic.Inventura.pInventuraStavke.Rows.Remove(row);
                        }
                    }
                    catch
                    {
                        LoadStavke();
                    }

                    //RecalculateRedniBroj();
                }
            }
        }


        #endregion




        //sklad
        //private void uceSkladiste_ValueChanged(object sender, EventArgs e)
        //{
        //    if (FormEditMode == Enums.FormEditMode.Update)
        //    {
        //        if (uceSkladiste.Value != null && udtDatumInventure.Value != null)
        //        {
        //            using (BusinessLogic.Inventura objekt = new BusinessLogic.Inventura())
        //            {
        //                StringBuilder message = new StringBuilder();
        //                foreach (DataRow row in BusinessLogic.Inventura.pInventuraStavke.Rows)
        //                {
        //                    objekt.ProvjeraDaliMozeNaSkladiste(Convert.ToInt32(row["ID_Proizvoda"]), Convert.ToDecimal(row["Kolicina"]), (int)uceSkladiste.Value,
        //                        Convert.ToDateTime(udtDatumInventure.DateTime), row["StavkaSkladista"].ToString(), message);
        //                }

        //                if (message.Length > 0)
        //                {
        //                    MessageBox.Show(message.ToString(), "Upozorenje");
        //                }
        //            }
        //        }
        //    }
        //}

        //private void udtDatumNastajanja_ValueChanged(object sender, EventArgs e)
        //{
        //    if (FormEditMode == Enums.FormEditMode.Update)
        //    {
        //        if (uceSkladiste.Value != null && udtDatumInventure.Value != null)
        //        {
        //            using (BusinessLogic.Inventura objekt = new BusinessLogic.Inventura())
        //            {
        //                StringBuilder message = new StringBuilder();
        //                foreach (DataRow row in BusinessLogic.Inventura.pInventuraStavke.Rows)
        //                {
        //                    objekt.ProvjeraDaliMozeNaSkladiste(Convert.ToInt32(row["ID_Proizvoda"]), Convert.ToDecimal(row["Kolicina"]), (int)uceSkladiste.Value,
        //                        Convert.ToDateTime(udtDatumInventure.DateTime), row["StavkaSkladista"].ToString(), message);
        //                }

        //                if (message.Length > 0)
        //                {
        //                    MessageBox.Show(message.ToString(), "Upozorenje");
        //                }
        //            }
        //        }
        //    }
        //}



    }
}
