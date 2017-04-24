using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Practices.CompositeUI.SmartParts;
using Deklarit.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.Commands;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;
using Infragistics.Win.UltraWinGrid;

namespace UcenickoFakturiranje.UI.MaticniPodaci
{
    [SmartPart]
    public partial class UcenikFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        /// <summary>
        /// Composite UI
        /// ------------------------------------------------------------------ 
        /// Univerzalan kod koji se koristi za forme (Controller, WorkWith, itd...)
        /// </summary>
        #region Composite UI - ALL code necessary

        private SmartPartInfo smartPartInfo1;
        private SmartPartInfoProvider infoProvider;
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

        /// <summary>
        /// Kontrola da se u uf-u moze raditi iskljucivo samo sa ucenicima, a u joppd-u sa svima
        /// </summary>
        public static bool vrsta_osobe = false;

        public UcenikFormPregled()
        {
            InitializeComponent();

            if (vrsta_osobe)
            {
                this.smartPartInfo1 = new SmartPartInfo("Osobe - pregled", "Osobe - pregled");
            }
            else
            {
                this.smartPartInfo1 = new SmartPartInfo("UČENICI - pregled", "UČENICI - pregled");
            }
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        #region Event Handlers

        private void UcenikFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridUcenici();
        }

        private void UltraGridUcenici_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            Update(null, null);
        }

        #endregion

        private void LoadGridUcenici()
        {
            BusinessLogic.Ucenici ucenici = new BusinessLogic.Ucenici();

            this.UltraGridUcenici.DataSource = ucenici.GetUceniciMainGrid();
            this.UltraGridUcenici.DataBind();

            Utils.Tools.UltraGridStyling(this.UltraGridUcenici);

            if (UltraGridUcenici.DisplayLayout.Bands.Count > 0)
                if (UltraGridUcenici.DisplayLayout.Bands[0].Columns.Count > 0)
                {
                    //UltraGridUcenici.DisplayLayout.Bands[0].Columns[10].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                }

            foreach (UltraGridRow row in UltraGridUcenici.Rows)
            {
                if (row.Index == BusinessLogic.Ucenici.pSelectedIndex)
                {
                    UltraGridUcenici.ActiveRow = row;
                }
            }
        }

        #region Command's - command handlers for buttons

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            UcenikForm ucenikForm = new UcenikForm(Enums.FormEditMode.Insert, null);

            if (ucenikForm.ShowDialogForm("Učenik") == DialogResult.OK)
            {
                try
                {
                    BusinessLogic.Ucenici.pSelectedIndex = UltraGridUcenici.ActiveRow.Index;
                }
                catch { }
                LoadGridUcenici();
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (this.UltraGridUcenici.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridUcenici.ActiveRow.Cells["ID"].Value);

                UcenikForm ucenikForm = new UcenikForm(Enums.FormEditMode.Update, id);

                if (ucenikForm.ShowDialogForm("Učenik") == DialogResult.OK)
                {
                    BusinessLogic.Ucenici.pSelectedIndex = UltraGridUcenici.ActiveRow.Index;
                    LoadGridUcenici();
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.UltraGridUcenici.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridUcenici.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati učenika '{0}-{1}'?", id, this.UltraGridUcenici.ActiveRow.Cells["ImePrezime"].Value),
                    "Brisanje učenika", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.Ucenici ucenici = new BusinessLogic.Ucenici();
                    ucenici.Delete(id);

                    if (ucenici.IsValid)
                    {
                        ucenici.Persist();
                        LoadGridUcenici();
                    }
                    else
                    {
                        ucenici.DisplayValidationMessages();
                    }
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (this.UltraGridUcenici.ActiveRow != null)
            {
                int id = Convert.ToInt32(this.UltraGridUcenici.ActiveRow.Cells["ID"].Value);

                UcenikForm ucenikForm = new UcenikForm(Enums.FormEditMode.Copy, id);

                if (ucenikForm.ShowDialogForm("Učenik") == DialogResult.OK)
                {
                    BusinessLogic.Ucenici.pSelectedIndex = UltraGridUcenici.ActiveRow.Index;
                    LoadGridUcenici();
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Ucenici.pSelectedIndex = UltraGridUcenici.ActiveRow.Index;
            }
            catch { }
            LoadGridUcenici();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Excel file (*.xls)|*.xls";
            saveFileDialog.FileName = "Učenici";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(this.UltraGridUcenici, saveFileDialog.FileName);
                Process.Start(saveFileDialog.FileName);
            }
        }

        //prijenos ucenika u partnere
        [CommandHandler("Partneri")]
        public void PrijenosUPartnere(object sender, EventArgs e)
        {
            DialogResult poruka = MessageBox.Show("Želite li napraviti prijenos učenika u partnere?", "Prijenos učenika u partnere", MessageBoxButtons.YesNo);
            if (poruka == DialogResult.Yes)
            {
                BusinessLogic.Ucenici Ucenici = new BusinessLogic.Ucenici();

                int id = Ucenici.GetMaxPartnerID();

                try
                {
                    foreach (UltraGridRow row in UltraGridUcenici.Rows)
                    {
                        if (row.Cells[9].Text.ToLower() == "false")
                        {
                            if (Ucenici.NotExistPartner(row.Cells[2].Text))
                            {
                                Ucenici.PrijenosUceniciPartneri(id, row.Cells[1].Text, row.Cells[3].Text, row.Cells[6].Text, row.Cells[5].Text,
                                 "", row.Cells[2].Text, "fax", "telefon", "ziro1", row.Cells[10].Text);

                                id++;
                            }
                            else
                            {
                                Ucenici.UpdateUceniciPartneri(id, row.Cells[1].Text, row.Cells[3].Text, row.Cells[6].Text, row.Cells[5].Text,
                                "", row.Cells[2].Text, "fax", "telefon", "ziro1", row.Cells[10].Text);
                            }
                        }
                        else
                        {
                            Ucenici.UpdateUceniciPartneri(id, row.Cells[1].Text, row.Cells[3].Text, row.Cells[6].Text, row.Cells[5].Text,
                             "", row.Cells[2].Text, "fax", "telefon", "ziro1", row.Cells[10].Text);
                        }
                    }

                    Ucenici.SetFlagPreneseniUcenik();
                    BusinessLogic.Ucenici.pSelectedIndex = UltraGridUcenici.ActiveRow.Index;
                    LoadGridUcenici();

                    MessageBox.Show("Uspješno napravljen prijenos učenika u partnere.");
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }


        ////podizanje skolske godine
        //[CommandHandler("Razred")]
        //public void PodizanjeSkolskeGOdine(object sender, EventArgs e)
        //{
            
        //}


        // Uvoz iz eMAtice za UF
        [CommandHandler("Uvoz")]
        public void UvozEMatica(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Odaberite datoteku za uvoz učenika";
            dialog.InitialDirectory = @"C\:Desktop";
            dialog.Filter = "XML datoteke (*.xml)|*.xml|All files (*.*)|*.*";
            dialog.FileName = "";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                IEnumerator enumerator = null;
                IEnumerator enumeratorOdjeljenje = null;

                string fileName = dialog.FileName.ToString();
                DataSet set = new DataSet();
                set.ReadXml(fileName);

                if (set.Tables[0] == null || set.Tables[3] == null)
                {
                    Interaction.MsgBox("XML datoteka za uvoz učenika, nije pravilno formatirana!", MsgBoxStyle.OkOnly, null);
                    return;
                }

                Ucenik[] ucenikArray = new Ucenik[set.Tables[3].Rows.Count + 1];
                int index = 0;
                try
                {
                    if (set.Tables[0].Columns["Textbox36"] == null)
                    {
                        throw new System.Exception("XML datoteka ne sadrži informaciju razreda i odjeljenja!");
                    }

                    enumerator = set.Tables[3].Rows.GetEnumerator();
                    enumeratorOdjeljenje = set.Tables[0].Rows.GetEnumerator();

                    string razred, odjeljenje;

                    enumeratorOdjeljenje.MoveNext();
                    DataRow currentOdjeljenje = (DataRow)enumeratorOdjeljenje.Current;
                    string strData = currentOdjeljenje["Textbox36"].ToString();


                    // parsiramo string
                    if (strData.Contains(". razred osnovne škole, odjeljenje:"))
                    {
                        razred = strData.Substring(0, strData.IndexOf(". razred osnovne škole")).Trim();
                        odjeljenje = strData.Substring(strData.IndexOf(":") + 1, strData.Length - strData.IndexOf(":") - 1).Trim();
                    }
                    else if (strData.Contains(". razred srednje škole, odjeljenje:"))
                    {
                        razred = strData.Substring(0, strData.IndexOf(". razred srednje škole")).Trim();
                        odjeljenje = strData.Substring(strData.IndexOf(":") + 1, strData.Length - strData.IndexOf(":") - 1).Trim();
                    }
                    else
                    {
                        // nije prošlo niti jedno parsiranje
                        throw new System.Exception("eMatica - XML datoteka // Nepoznati format podatka '" + currentOdjeljenje["Textbox36"] + "'");
                    }


                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow)enumerator.Current;

                        try
                        {
                            ucenikArray[index].ime = Conversions.ToString(DBNullToString(current["ime"], "-"));
                        }
                        catch
                        {
                            ucenikArray[index].ime = "-";
                        }

                        try
                        {
                            ucenikArray[index].prezime = Conversions.ToString(DBNullToString(current["prezime"], "-"));
                        }
                        catch
                        {
                            ucenikArray[index].prezime = "-";
                        }

                        try
                        {
                            if (Conversions.ToString(DBNullToString(current["Spol"], "-")) == "M")
                                ucenikArray[index].SPOL = 1;
                            else
                                ucenikArray[index].SPOL = 2;
                        }
                        catch
                        {
                            ucenikArray[index].SPOL = 0;
                        }

                        try
                        {
                            ucenikArray[index].oib = Conversions.ToString(DBNullToString(current["OIB"], "-"));
                        }
                        catch
                        {
                            ucenikArray[index].oib = "-";
                        }

                        try
                        {
                            ucenikArray[index].JMBG = Conversions.ToString(DBNullToString(current["JMBG"], "-"));
                        }
                        catch
                        {
                            ucenikArray[index].JMBG = "-";
                        }

                        try
                        {
                            ucenikArray[index].DATUMRODJ = Conversions.ToDate(DBNullToString(current["DatumRodjenja"], "-"));
                        }
                        catch
                        {
                            ucenikArray[index].DATUMRODJ = DateTime.Now;
                        }

                        ucenikArray[index].id_opcina = string.Empty;
                        ucenikArray[index].id_vrsta_veze = 1;
                        ucenikArray[index].ULICAIBROJ = string.Empty;
                        ucenikArray[index].NASELJE = string.Empty;
                        ucenikArray[index].POSTANSKIBROJ = "0";

                        index++;
                    }

                    BusinessLogic.Ucenici Ucenici = new BusinessLogic.Ucenici();
                    int broj_ucenika = ucenikArray.Length - 1;
                    bool kontrola = false;
                    index = 0;

                    while (index <= broj_ucenika)
                    {
                        if (Ucenici.Add(ucenikArray[index].ime, ucenikArray[index].prezime, ucenikArray[index].oib, ucenikArray[index].JMBG, (int)ucenikArray[index].SPOL, ucenikArray[index].ULICAIBROJ,
                           ucenikArray[index].NASELJE, ucenikArray[index].POSTANSKIBROJ, ucenikArray[index].DATUMRODJ, ucenikArray[index].id_opcina, ucenikArray[index].id_vrsta_veze, true, "", "", "", ""))
                        {
                            kontrola = true;
                        }
                        else
                        {
                            kontrola = false;
                        }
                        if (Ucenici.Persist())
                        {
                            kontrola = true;
                        }
                        else
                        {
                            kontrola = false;
                        }
                        index++;
                    }
                    if (kontrola)
                    {
                        MessageBox.Show("Uspješno preneseni učenici iz eMatice!");
                    }
                    else
                    {
                        MessageBox.Show("Dogodila se greška prilikom prijenosta učenika iz eMatice.\nPokušajte ponovo ili kontaktirajte administratora.");
                    }
                }
                catch (System.Exception exception)
                {
                    new Mipsed7.Emailing.SendException(exception).Send();
                    Interaction.MsgBox(exception.Message, MsgBoxStyle.OkOnly);

                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                    LoadGridUcenici();
                }
            }
        }

        public object DBNullToString(object value, string defaultValue)
        {
            if (value == DBNull.Value)
                return defaultValue;

            return value;
        }

        #endregion

        [StructLayout(LayoutKind.Sequential)]
        public struct Ucenik
        {
            public string ime;
            public string prezime;
            public string oib;
            public int SPOL;
            public string ULICAIBROJ;
            public string NASELJE;
            public string JMBG;
            public DateTime DATUMRODJ;
            public string POSTANSKIBROJ;
            public string id_opcina;
            public int id_vrsta_veze;
        }
    }
}
