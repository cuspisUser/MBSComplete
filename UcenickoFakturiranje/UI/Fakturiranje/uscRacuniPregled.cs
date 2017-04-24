using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Deklarit.Practices.CompositeUI;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.Commands;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using System.Diagnostics;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
using Mipsed7.DataAccessLayer;
using UcenickoFakturiranje.BusinessLogic;
using CrystalDecisions.CrystalReports.Engine;
using Deklarit.Practices.CompositeUI.Workspaces;
using Placa;
using Infragistics.Win.UltraWinGrid;
using System.Collections;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using Hlp;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace UcenickoFakturiranje.UI.Fakturiranje
{
    [SmartPart]
    public partial class uscRacuniPregled : UserControl, ISmartPartInfoProvider, IFilteredView
    {

        
        #region Univerzalan kod koji se koristi za forme (Controller, WorkWith, itd...)

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
        public Microsoft.Practices.CompositeUI.Controller Controller 
        { 
            get; set; 
        }

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

        #region Dogadaji

        private void ugdData_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            Update(null, null);
        }

        private void uscRacuniPregled_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }


        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdData.ActiveRow != null)
            {
                try
                {
                    BusinessLogic.Racuni.pIDRacun = Convert.ToInt32(ugdData.ActiveRow.Cells["IDRACUN"].Value);
                    BusinessLogic.Racuni.pIDGodina = Convert.ToInt16(ugdData.ActiveRow.Cells["RACUNGODINAIDGODINE"].Value);
                    
                    if(IsDbNull<int>(ugdData.ActiveRow.Cells["VezaRacunID"].Value) != null)
                    {
                        MessageBox.Show("Nije moguće raditi izmjene na računu koji je storniran");
                        return;
                    }
                }
                catch { }

                using (RacunForm objekt = new RacunForm(Enums.FormEditMode.Update))
                {
                    if (objekt.ShowDialogForm("Racun") == DialogResult.OK)
                    {
                        try
                        {
                            BusinessLogic.Racuni.pSelectedIndex = ugdData.ActiveRow.Index;
                        }
                        catch { }
                        LoadGridData();
                    }
                }
            }
        }


        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Obracuni.pSelectedIndex = ugdData.ActiveRow.Index;
            }
            catch { }
            LoadGridData();
        }

        [CommandHandler("Storno")]
        public void Storno(object sender, EventArgs e)
        {
            if (ugdData.ActiveRow != null)
            {
                try
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ugdData.Rows)
                    {
                        if (row.Cells["Ozn"].Value.ToString() == "True")
                        {
                            BusinessLogic.Racuni.pIDRacun = Convert.ToInt32(row.Cells["IDRACUN"].Value);
                            BusinessLogic.Racuni.pIDGodina = Convert.ToInt16(row.Cells["RACUNGODINAIDGODINE"].Value);

                            using (BusinessLogic.Racuni objekt = new Racuni())
                            {
                                if (objekt.IsStorniran())
                                {
                                    if (objekt.Storno())
                                    {
                                    }
                                    else
                                    {
                                        MessageBox.Show("Dogodila se greška prilikom storniranja dokumenta.\n\rJavite se u T4S.");
                                    }
                                }
                            }
                        }
                    }
                    LoadGridData();
                }
                catch { }
            }
        }

        [CommandHandler("IspisOzn")]
        public void IspisOzn(object sender, EventArgs e)
        {
            if (ugdData.ActiveRow != null)
            {
                Dictionary<int, int> oznaceni = VratiOznaceneRacune(ugdData.Rows);

                if (oznaceni.Count > 0)
                {
                    BusinessLogic.Racuni objekt = new BusinessLogic.Racuni();

                    ReportDocument rpt = new ReportDocument();
                    rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptVirmaniUF.rpt");

                    // Set connection string from config in existing LogonProperties
                    rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                    rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;

                    rpt.SetDataSource(objekt.GetDataRacuni(oznaceni));

                    ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                    PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                    if (item == null)
                    {
                        item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                    }
                    item.Izvjestaj = rpt;
                    item.Activate();
                    item.Show(item.Workspaces["main"]);
                }
            }
        }

        private Dictionary<int, int> VratiOznaceneRacune(RowsCollection rowsCollection)
        {
            Dictionary<int, int> oznaceni = new Dictionary<int, int>();

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rowsCollection)
            {
                if (row.Cells["Ozn"].Value.ToString() == "True")
                {
                    oznaceni.Add(Convert.ToInt32(row.Cells["IDRACUN"].Value), Convert.ToInt32(row.Cells["RACUNGODINAIDGODINE"].Value));
                }
            }

            return oznaceni;
        }

        [CommandHandler("IspisPoBroju")]
        public void IspisPoBroju(object sender, EventArgs e)
        {
            using (uscRacuniBroj objekt = new uscRacuniBroj(true))
            {
                if (objekt.ShowDialogForm("Ispis") == DialogResult.OK)
                {
                    using (BusinessLogic.Racuni racun = new BusinessLogic.Racuni())
                    {
                        Dictionary<int, int> oznaceni = racun.VratiOznaceneRacunePoBroju(objekt.pyear, objekt.pod, objekt.pdo);

                        if (oznaceni.Count > 0)
                        {
                            ReportDocument rpt = new ReportDocument();
                            rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\rptVirmaniUF.rpt");

                            // Set connection string from config in existing LogonProperties
                            rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                            rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                            rpt.DataSourceConnections[0].IntegratedSecurity = false;

                            rpt.SetDataSource(racun.GetDataRacuni(oznaceni));

                            ExtendedWindowWorkspace workspace = new ExtendedWindowWorkspace();
                            PreviewReportWorkItem item = this.Controller.WorkItem.Items.Get<PreviewReportWorkItem>("Pregled");
                            if (item == null)
                            {
                                item = this.Controller.WorkItem.Items.AddNew<PreviewReportWorkItem>("Pregled");
                            }
                            item.Izvjestaj = rpt;
                            item.Activate();
                            item.Show(item.Workspaces["main"]);
                        }
                    }
                }
            }
        }

        

        [CommandHandler("PrijenosGKPoBroju")]
        public void PrijenosGKBroj(object sender, EventArgs e)
        {
            using (uscRacuniBroj objekt = new uscRacuniBroj(false))
            {
                if (objekt.ShowDialogForm("Prijenos") == DialogResult.OK)
                {
                    using (BusinessLogic.Racuni racun = new BusinessLogic.Racuni())
                    {
                        racun.pOdabraniRacuni = racun.VratiOznaceneRacunePoBroju(objekt.pyear, objekt.pod, objekt.pdo);

                        if (racun.pOdabraniRacuni.Count > 0)
                        {
                            if (racun.GetIDShema() != 0)
                            {
                                int id_shema = 0;
                                if (racun.InsertGlavnaKnjiga(ref id_shema))
                                {
                                    if (id_shema != 0)
                                    {
                                        MessageBox.Show("Uspješno je preneseno računa u GK: " + racun.pCounter);

                                        if (racun.InsertIRA())
                                        {
                                            MessageBox.Show("Uspješno je preneseno računa u IRA: " + racun.pCounter);

                                            racun.SetPreneseniObracuni();

                                            if (racun.SetZatvaranja())
                                            {
                                                LoadGridData();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Dogodila se greška prilikom financijskog zaduživanja!\nJavite se u T4S.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("potrebno je napraviti shemu knjiženja\nda bi se računi mogli zadužiti.");
                            }
                        }
                    }
                }
            }
        }

        [CommandHandler("PrijenosGKOznaceni")]
        public void PrijenosGK(object sender, EventArgs e)
        {
            if (ugdData.ActiveRow != null)
            {
                using (BusinessLogic.Racuni objekt = new Racuni())
                {
                    objekt.pOdabraniRacuni = VratiOznaceneRacune(ugdData.Rows);

                    if (objekt.pOdabraniRacuni.Count > 0)
                    {
                        if (objekt.GetIDShema() != 0)
                        {
                            int id_shema = 0;
                            if (objekt.InsertGlavnaKnjiga(ref id_shema))
                            {
                                if (id_shema != 0)
                                {
                                    MessageBox.Show("Uspješno je preneseno računa u GK: " + objekt.pCounter);

                                    if (objekt.InsertIRA())
                                    {
                                        MessageBox.Show("Uspješno je preneseno računa u IRA: " + objekt.pCounter);

                                        objekt.SetPreneseniObracuni();

                                        if (objekt.SetZatvaranja())
                                        {
                                            LoadGridData();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Dogodila se greška prilikom financijskog zaduživanja!\nJavite se u T4S.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("potrebno je napraviti shemu knjiženja\nda bi se računi mogli zadužiti.");
                        }
                    }
                }
            }
        }

        #endregion

        #region Metode

        public uscRacuniPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Računi - pregled", "Računi - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        public Nullable<T> IsDbNull<T>(object value) where T : struct
        {
            if (value != DBNull.Value && value != null)
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }

            return null;
        }

        public void LoadGridData()
        {
            Racuni objekt = new Racuni();
            ugdData.DataSource = objekt.GetGridData();

            ugdData.DataBind();
            ugdData.UpdateData();

            if (ugdData.DisplayLayout.Bands.Count > 0)
            {
                //ugdData.DisplayLayout.Bands[0].Columns["RACUNGODINAIDGODINE"].Hidden = true;
                ugdData.DisplayLayout.Bands[0].Columns["NAZIVPARTNER"].Header.Caption = "Učenik";
                ugdData.DisplayLayout.Bands[0].Columns["IDRACUN"].Header.Caption = "Broj";
                ugdData.DisplayLayout.Bands[0].Columns["DATUM"].Header.Caption = "Datum";
                ugdData.DisplayLayout.Bands[0].Columns["NAPOMENA"].Header.Caption = "Napomena";
                ugdData.DisplayLayout.Bands[0].Columns["UkupanIznos"].Header.Caption = "Ukupan iznos";
                ugdData.DisplayLayout.Bands[0].Columns["UkupanIznos"].Format = "F2";
                ugdData.DisplayLayout.Bands[0].Columns["Ozn"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                ugdData.DisplayLayout.Bands[0].Columns["Ozn"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                ugdData.DisplayLayout.Bands[0].Columns["Ozn"].Width = 20;
                ugdData.DisplayLayout.Bands[0].Columns["IDRACUN"].Width = 50;
                ugdData.DisplayLayout.Bands[0].Columns["Napomena"].Width = 250;
                ugdData.DisplayLayout.Bands[0].Columns["UkupanIznos"].Width = 100;
                ugdData.DisplayLayout.Bands[0].Columns["NAZIVPARTNER"].Width = 200;
                ugdData.DisplayLayout.Bands[0].Columns["VezaRacunID"].Hidden = true;
                ugdData.DisplayLayout.Bands[0].Columns["VezaObracun"].Hidden = true;
                ugdData.DisplayLayout.Bands[0].Columns["Vrsta"].Hidden = true;
                ugdData.DisplayLayout.Bands[0].Columns["RACUNGODINAIDGODINE"].Header.Caption = "Godina";
                ugdData.DisplayLayout.Bands[0].Columns["RACUNGODINAIDGODINE"].Width = 50;

                ugdData.DisplayLayout.Bands[1].Columns["None"].Header.Caption = " ";
                ugdData.DisplayLayout.Bands[1].Columns["IDRACUN"].Hidden = true;
                ugdData.DisplayLayout.Bands[1].Columns["RACUNGODINAIDGODINE"].Hidden = true;
                ugdData.DisplayLayout.Bands[1].Columns["BROJSTAVKE"].Hidden = true;
                ugdData.DisplayLayout.Bands[1].Columns["NAZIVPROIZVODRACUN"].Header.Caption = "Proizvod";
                ugdData.DisplayLayout.Bands[1].Columns["CIJENARACUN"].Header.Caption = "Neto";
                ugdData.DisplayLayout.Bands[1].Columns["RABAT"].Header.Caption = "Rabat";
                ugdData.DisplayLayout.Bands[1].Columns["KOLICINA"].Header.Caption = "Količina";
                ugdData.DisplayLayout.Bands[1].Columns["FINPOREZSTOPARACUN"].Header.Caption = "Stopa PDV-a";
                ugdData.DisplayLayout.Bands[1].Columns["CijenaPDV"].Header.Caption = "Ukupan iznos";
                ugdData.DisplayLayout.Bands[1].Columns["CIJENARACUN"].Format = "F2";
                ugdData.DisplayLayout.Bands[1].Columns["RABAT"].Format = "F2";
                ugdData.DisplayLayout.Bands[1].Columns["KOLICINA"].Format = "F2";
                ugdData.DisplayLayout.Bands[1].Columns["FINPOREZSTOPARACUN"].Format = "F2";
                ugdData.DisplayLayout.Bands[1].Columns["CijenaPDV"].Format = "F2";
            }

           // Utils.Tools.UltraGridStyling(ugdData);

            foreach (UltraGridRow row in ugdData.Rows)
            {
                if (row.Index == BusinessLogic.Obracuni.pSelectedIndex)
                {
                    ugdData.ActiveRow = row;
                }
            }
        }

        #endregion

        private void ugdData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // Display cell text on multiple lines
            //e.Layout.Override.RowSizing = RowSizing.AutoFree;
            //e.Layout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.True;
        }

        private void ugdData_InitializeRow(object sender, InitializeRowEventArgs e)
        {
            // Expand rows in band 0
            //if (e.Row.Band.Index == 0)
            //    e.Row.ExpandAll();

            if (e.Row.Band.Index == 0 && e.Row.Cells["Vrsta"].Value.ToString() == "SU")
            {
                e.Row.Appearance.BackColor = Color.Red;
                e.Row.Appearance.BackColor2 = Color.Red;
            }
        }
    }
}
