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
using System.Diagnostics;
using Microsoft.VisualBasic;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using Placa;
using System.Runtime.CompilerServices;
using Deklarit.Practices.CompositeUI.Workspaces;
using NetAdvantage.WorkItems;

namespace FinPosModule
{
    [SmartPart]
    public partial class OdobrenjeFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public OdobrenjeFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("Odobrenje - pregled", "Odobrenje - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        #region Event Handlers

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                Odobrenje.pSelectedIndex = ugdOdobrenje.ActiveRow.Index;
            }
            catch { }
            LoadGridData();
        }

        private void UltraGridUstanove_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            Update(null, null);
        }

        #endregion

        #region Command's - command handlers for WorkItems

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (OdobrenjeFrm objekt = new OdobrenjeFrm(FormEditMode.Insert))
            {
                if (objekt.ShowDialogForm("Odobrenje") == DialogResult.OK)
                {
                    try
                    {
                        Odobrenje.pSelectedIndex = ugdOdobrenje.ActiveRow.Index;
                    }
                    catch { }
                    LoadGridData();
                }
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdOdobrenje.ActiveRow != null)
            {
                Odobrenje.pID = Convert.ToInt32(ugdOdobrenje.ActiveRow.Cells["ID"].Value);

                using (OdobrenjeFrm objekt = new OdobrenjeFrm(FormEditMode.Update))
                {
                    if (objekt.ShowDialogForm("Odobrenje") == DialogResult.OK)
                    {
                        try
                        {
                            Odobrenje.pSelectedIndex = ugdOdobrenje.ActiveRow.Index;
                        }
                        catch { }
                        LoadGridData();
                    }
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdOdobrenje.ActiveRow != null)
            {
                Odobrenje.pID = Convert.ToInt32(ugdOdobrenje.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati Odobrenje '{0}-{1}'?", Odobrenje.pID, ugdOdobrenje.ActiveRow.Cells["ID"].Value),
                    "Brisanje Primke", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (Odobrenje objekt = new Odobrenje())
                    {
                        StringBuilder message = new StringBuilder();

                        if (!objekt.Delete(message))
                        {
                            MessageBox.Show(message.ToString());
                        }
                        try
                        {
                           Odobrenje.pSelectedIndex = ugdOdobrenje.ActiveRow.Index;
                        }
                        catch { }
                        LoadGridData();
                    }
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (ugdOdobrenje.ActiveRow != null)
            {
                Odobrenje.pID = (int)ugdOdobrenje.ActiveRow.Cells["ID"].Value;

                using (OdobrenjeFrm objekt = new OdobrenjeFrm(FormEditMode.Copy))
                {

                    if (objekt.ShowDialogForm("Odobrenje") == DialogResult.OK)
                    {
                        try
                        {
                            Odobrenje.pSelectedIndex = ugdOdobrenje.ActiveRow.Index;
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
                Odobrenje.pSelectedIndex = ugdOdobrenje.ActiveRow.Index;
            }
            catch { }
            LoadGridData();
        }

        [CommandHandler("Ispis")]
        public void Ispis(object sender, EventArgs e)
        {
            if (ugdOdobrenje.ActiveRow != null)
            {
                ReportDocument rpt = new ReportDocument();
                rpt.Load(System.Windows.Forms.Application.StartupPath + @"\FinposIzvjestaji\Odobrenje.rpt");

                // Set connection string from config in existing LogonProperties
                rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                Odobrenje.pID = (int)ugdOdobrenje.ActiveRow.Cells["ID"].Value;

                using (Odobrenje objekt = new Odobrenje())
                {
                    rpt.SetDataSource(objekt.GetOdobrenjeIspis());

                    KORISNIKDataSet set2 = new KORISNIKDataSet();
                    new KORISNIKDataAdapter().Fill(set2);

                    if (set2.KORISNIK.Rows.Count > 0)
                    {
                        rpt.SetParameterValue("naziv", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1NAZIV"]));
                        rpt.SetParameterValue("oib", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIKOIB"]));
                        rpt.SetParameterValue("adresa", RuntimeHelpers.GetObjectValue(set2.KORISNIK.Rows[0]["KORISNIK1ADRESA"]));
                    }

                    // podesavanje loga na ispisu, ukoliko nije podesena lokacija za logo, gleda staru logiku
                    Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
                    string putanja = client.ExecuteScalar("Select Top 1 Logo From Korisnik").ToString();

                    if (putanja.Length == 0)
                    {
                        try
                        {
                            rpt.SetParameterValue("logoPath", string.Empty);

                            string logoPath = AppDomain.CurrentDomain.BaseDirectory + @"Resources\logo_135_135.jpg";

                            if (System.IO.File.Exists(logoPath))
                                rpt.SetParameterValue("logoPath", logoPath);
                        }
                        catch { }
                    }
                    else
                    {
                        rpt.SetParameterValue("logoPath", putanja);
                    }

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

        #endregion
        
        private void LoadGridData()
        {
            using (Odobrenje objekt = new Odobrenje())
            {
                ugdOdobrenje.DataSource = objekt.GetMainGridData();
                ugdOdobrenje.DataBind();
                Tools.UltraGridStyling(ugdOdobrenje);

                if (ugdOdobrenje.DisplayLayout.Bands.Count > 0)
                {
                    ugdOdobrenje.DisplayLayout.Bands[1].Columns["ID_Odobrenje"].Hidden = true;
                    ugdOdobrenje.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;

                    ugdOdobrenje.DisplayLayout.Bands[1].Columns["Cijena Neto"].Format = "N2";
                    ugdOdobrenje.DisplayLayout.Bands[1].Columns["Cijena PDV"].Format = "N2";
                    ugdOdobrenje.DisplayLayout.Bands[0].Columns["Partner"].Width = 260;

                    //ugdFormPregled.DisplayLayout.Bands[0].Columns["Ozn"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    //ugdFormPregled.DisplayLayout.Bands[0].Columns["Ozn"].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    //ugdFormPregled.DisplayLayout.Bands[0].Columns["Preneseno"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                    //ugdFormPregled.DisplayLayout.Bands[0].Columns["Ozn"].Width = 30;
                }
                foreach (UltraGridRow row in ugdOdobrenje.Rows)
                {
                    if (row.Index == Odobrenje.pSelectedIndex)
                    {
                        ugdOdobrenje.ActiveRow = row;
                    }
                }
            }
        }

    }
}
