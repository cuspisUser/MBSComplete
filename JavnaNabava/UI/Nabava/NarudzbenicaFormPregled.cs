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
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using Deklarit.Practices.CompositeUI.Workspaces;
using NetAdvantage.WorkItems;
using Infragistics.Win.UltraWinGrid;

namespace JavnaNabava.UI.Nabava
{
    [SmartPart]
    public partial class NarudzbenicaFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        #region Metode

        public NarudzbenicaFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("NARUDZBENICA - pregled", "NARUDZBENICA - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridNarudzbenica()
        {
            BusinessLogic.Narudzbenica objekt = new BusinessLogic.Narudzbenica();

            ugdNarudzbenica.DataSource = objekt.GetDataMainGrid();
            ugdNarudzbenica.DataBind();

            Utils.Tools.UltraGridStyling(ugdNarudzbenica);

            if (ugdNarudzbenica.DisplayLayout.Bands.Count > 0)
            {
                ugdNarudzbenica.DisplayLayout.Bands[0].Columns["ID"].Hidden = true;
                ugdNarudzbenica.DisplayLayout.Bands[0].Columns["Naziv partnera"].Width = 200;
                ugdNarudzbenica.DisplayLayout.Bands[0].Columns["Partner adresa"].Width = 200;
                ugdNarudzbenica.DisplayLayout.Bands[1].Columns["ID_Narudzbenica"].Hidden = true;
                ugdNarudzbenica.DisplayLayout.Bands[1].Columns["Naziv proizvoda"].Width = 200;
            }

            foreach (UltraGridRow row in ugdNarudzbenica.Rows)
            {
                if (row.Index == BusinessLogic.Narudzbenica.pSelectedIndex)
                {
                    ugdNarudzbenica.ActiveRow = row;
                }
            }
        }

        #endregion
        
        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscNarudzbenica objekt = new uscNarudzbenica(Enums.FormEditMode.Insert))
            {
                if (objekt.ShowDialogForm("Narudžbenica") == DialogResult.OK)
                {
                    try
                    {
                        BusinessLogic.Narudzbenica.pSelectedIndex = ugdNarudzbenica.ActiveRow.Index;
                    }
                    catch { }
                    LoadGridNarudzbenica();
                }
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdNarudzbenica.ActiveRow != null)
            {
                BusinessLogic.Narudzbenica.pID_Narudzbenica = Convert.ToInt32(ugdNarudzbenica.ActiveRow.Cells["ID"].Value);

                using (uscNarudzbenica objekt = new uscNarudzbenica(Enums.FormEditMode.Update))
                {
                    if (objekt.ShowDialogForm("Narudžbenica") == DialogResult.OK)
                    {
                        BusinessLogic.Narudzbenica.pSelectedIndex = ugdNarudzbenica.ActiveRow.Index;
                        LoadGridNarudzbenica();
                    }
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdNarudzbenica.ActiveRow != null)
            {
                BusinessLogic.Narudzbenica.pID_Narudzbenica = Convert.ToInt32(ugdNarudzbenica.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati narudžbenicu '{0}-{1}'?", BusinessLogic.Narudzbenica.pID_Narudzbenica, ugdNarudzbenica.ActiveRow.Cells["Broj narudžbe"].Value),
                    "Brisanje narudžbenice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.Narudzbenica objekt = new BusinessLogic.Narudzbenica();
                    if (!objekt.Delete())
                    {
                        MessageBox.Show("Dogodila se greška prilikom brisanja narudžbenice.\nKontaktirajte administratora [Error:00020]");
                    }
                    LoadGridNarudzbenica();
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (ugdNarudzbenica.ActiveRow != null)
            {
                BusinessLogic.Narudzbenica.pID_Narudzbenica = Convert.ToInt32(ugdNarudzbenica.ActiveRow.Cells["ID"].Value);

                using (uscNarudzbenica objekt = new uscNarudzbenica(Enums.FormEditMode.Copy))
                {
                    if (objekt.ShowDialogForm("Narudžbenice") == DialogResult.OK)
                    {
                        BusinessLogic.Narudzbenica.pSelectedIndex = ugdNarudzbenica.ActiveRow.Index;
                        LoadGridNarudzbenica();
                    }
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.Narudzbenica.pSelectedIndex = ugdNarudzbenica.ActiveRow.Index;
            }
            catch { }
            LoadGridNarudzbenica();
        }

        [CommandHandler("Narudzbenice")]
        public void Izvjestaji(object sender, EventArgs e)
        {
            if (ugdNarudzbenica.ActiveRow != null)
            {
                BusinessLogic.Narudzbenica.pID_Narudzbenica = BusinessLogic.Narudzbenica.IsDbNull<int>(ugdNarudzbenica.ActiveRow.Cells["ID"].Value);
                BusinessLogic.Narudzbenica objekt = new BusinessLogic.Narudzbenica();

                ReportDocument rpt = new ReportDocument();
                rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpNarudzbeniceIspis.rpt");

                // Set connection string from config in existing LogonProperties
                rpt.DataSourceConnections[0].SetConnection(Mipsed7.Core.ApplicationDatabaseInformation.ServerName, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName, true);
                rpt.DataSourceConnections[0].SetLogon(Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName, Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                rpt.SetDataSource(objekt.GetNarudzbenicaIspis(BusinessLogic.Narudzbenica.pID_Narudzbenica));

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

        private void NarudzbenicaFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridNarudzbenica();
        }

        private void ugdNarudzbenica_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        #endregion

    }
}
