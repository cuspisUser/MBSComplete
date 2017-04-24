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
using Deklarit.Practices.CompositeUI.Workspaces;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.Practices.CompositeUI.Commands;
using Infragistics.Win.UltraWinGrid.ExcelExport;
using System.Diagnostics;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using NetAdvantage.WorkItems;
using Infragistics.Win.UltraWinGrid;

namespace JavnaNabava.UI.Nabava
{
    [SmartPart]
    public partial class PlanNabaveFormPregled : UserControl, ISmartPartInfoProvider, IFilteredView
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

        public PlanNabaveFormPregled()
        {
            InitializeComponent();

            this.smartPartInfo1 = new SmartPartInfo("PLAN NABAVE - pregled", "PLAN NABAVE - pregled");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
        }

        private void LoadGridPlanNabave()
        {
            BusinessLogic.PlanNabave plan_nabave = new BusinessLogic.PlanNabave();

            ugdPlanNabave.DataSource = plan_nabave.GetPlanNabaveMainGrid();
            ugdPlanNabave.DataBind();

            Utils.Tools.UltraGridStyling(ugdPlanNabave);

            if (ugdPlanNabave.DisplayLayout.Bands.Count > 0)
            {
                ugdPlanNabave.DisplayLayout.Bands[0].Columns["Ukupna vrijednost sa porezom"].Format = "N2";
                ugdPlanNabave.DisplayLayout.Bands[0].Columns["Ustanova"].Width = 200;
                ugdPlanNabave.DisplayLayout.Bands[1].Columns["ID_PlanNabave"].Hidden = true;
                ugdPlanNabave.DisplayLayout.Bands[1].Columns["BezPoreza"].Format = "N2";
                ugdPlanNabave.DisplayLayout.Bands[1].Columns["SaPorezom"].Format = "N2";
            }

            foreach (UltraGridRow row in ugdPlanNabave.Rows)
            {
                if (row.Index == BusinessLogic.PlanNabave.pSelectedIndex)
                {
                    ugdPlanNabave.ActiveRow = row;
                }
            }
        }

        #endregion
        
        #region Dogadaji

        [CommandHandler("Insert")]
        public void Insert(object sender, EventArgs e)
        {
            using (uscPlanNabave plan_nabave = new uscPlanNabave(Enums.FormEditMode.Insert))
            {
                if (plan_nabave.ShowDialogForm("Plan nabave") == DialogResult.OK)
                {
                    try
                    {
                        BusinessLogic.PlanNabave.pSelectedIndex = ugdPlanNabave.ActiveRow.Index;
                    }
                    catch { }
                    LoadGridPlanNabave();
                }
            }
        }

        [CommandHandler("Update")]
        public void Update(object sender, EventArgs e)
        {
            if (ugdPlanNabave.ActiveRow != null)
            {
                BusinessLogic.PlanNabave.pID = Convert.ToInt32(ugdPlanNabave.ActiveRow.Cells["ID"].Value);

                using (uscPlanNabave plan_nabave = new uscPlanNabave(Enums.FormEditMode.Update))
                {
                    if (plan_nabave.ShowDialogForm("Plan nabave") == DialogResult.OK)
                    {
                        BusinessLogic.PlanNabave.pSelectedIndex = ugdPlanNabave.ActiveRow.Index;
                        LoadGridPlanNabave();
                    }
                }
            }
        }

        [CommandHandler("Delete")]
        public void Delete(object sender, EventArgs e)
        {
            if (ugdPlanNabave.ActiveRow != null)
            {
                BusinessLogic.PlanNabave.pID = Convert.ToInt32(ugdPlanNabave.ActiveRow.Cells["ID"].Value);

                if (MessageBox.Show(string.Format("Obrisati plan nabave '{0}-{1}'?", BusinessLogic.PlanNabave.pID, ugdPlanNabave.ActiveRow.Cells["Ustanova"].Value),
                    "Brisanje plana nabave", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.PlanNabave plan_nabave = new BusinessLogic.PlanNabave();
                    if (!plan_nabave.Delete())
                    {
                        MessageBox.Show("Dogodila se greška prilikom brisanja plana nabave.\nKontaktirajte administratora [Error:00014]");
                    }
                    LoadGridPlanNabave();
                }
            }
        }

        [CommandHandler("Copy")]
        public void Copy(object sender, EventArgs e)
        {
            if (ugdPlanNabave.ActiveRow != null)
            {
                BusinessLogic.PlanNabave.pID = Convert.ToInt32(ugdPlanNabave.ActiveRow.Cells["ID"].Value);

                using (uscPlanNabave plan_nabave = new uscPlanNabave(Enums.FormEditMode.Copy))
                {
                    if (plan_nabave.ShowDialogForm("Plan nabave") == DialogResult.OK)
                    {
                        LoadGridPlanNabave();
                    }
                }
            }
        }

        [CommandHandler("Refresh")]
        public void Refresh(object sender, EventArgs e)
        {
            try
            {
                BusinessLogic.PlanNabave.pSelectedIndex = ugdPlanNabave.ActiveRow.Index;
            }
            catch { }
            LoadGridPlanNabave();
        }

        [CommandHandler("ExportExcel")]
        public void ExportExcel(object sender, EventArgs e)
        {
            SaveFileDialog sfdExcel = new SaveFileDialog();
            sfdExcel.DefaultExt = "xls";
            sfdExcel.Filter = "Excel file (*.xls)|*.xls";
            sfdExcel.FileName = "Plan nabave";

            if (sfdExcel.ShowDialog() == DialogResult.OK)
            {
                new UltraGridExcelExporter().Export(ugdPlanNabave, sfdExcel.FileName);
                Process.Start(sfdExcel.FileName);
            }
        }

        [CommandHandler("PlanNabave")]
        public void PlanNabave(object sender, EventArgs e)
        {
            if (ugdPlanNabave.ActiveRow != null)
            {
                using (PlanNabveIspis plan_ispis = new PlanNabveIspis())
                {
                    if (plan_ispis.ShowDialogForm("Plan nabave ispis") == DialogResult.OK)
                    {
                        BusinessLogic.PlanNabave.pID = Convert.ToInt32(ugdPlanNabave.ActiveRow.Cells["ID"].Value);
                        BusinessLogic.PlanNabave plan_nabave = new BusinessLogic.PlanNabave();

                        DataTable dt_plan_nabave = plan_nabave.GetPlanNabaveIspis(BusinessLogic.PlanNabave.pID);

                        ReportDocument rpt = new ReportDocument();
                        rpt.Load(System.Windows.Forms.Application.StartupPath + @"\Izvjestaji\crpPlanNabave.rpt");
                        rpt.SetDataSource(dt_plan_nabave);
                        rpt.SetParameterValue("KorisnickiDatum", BusinessLogic.PlanNabave.pIspisPlanaNabave);

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

        private void ugdPlanNabave_DoubleClick(object sender, EventArgs e)
        {
            Update(null, null);
        }

        #endregion

        private void PlanNabaveFormPregled_Load(object sender, EventArgs e)
        {
            LoadGridPlanNabave();
        }

    }
}
