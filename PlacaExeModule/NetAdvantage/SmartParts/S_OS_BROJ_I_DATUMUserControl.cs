namespace NetAdvantage.SmartParts
{
    using Deklarit;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Practices.CompositeUI.NetAdvantage.Services;
    using Deklarit.Practices.CompositeUI.Services;
    using Deklarit.Resources;
    using Infragistics.Win;
    using Infragistics.Win.Printing;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinGrid.ExcelExport;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.Controllers;
    using NetAdvantage.WorkItems;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using Placa;

    [SmartPart]
    public class S_OS_BROJ_I_DATUMUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridS_OS_BROJ_I_DATUM")]
        private S_OS_BROJ_I_DATUMUserDataGrid _userControlDataGridS_OS_BROJ_I_DATUM;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_OS_BROJ_I_DATUM;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_OS_BROJ_I_DATUMUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_OS_BROJ_I_DATUMDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_OS_BROJ_I_DATUMDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_OS_BROJ_I_DATUMDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_OS_BROJ_I_DATUMDataSet>(this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        private void DataGrid_AfterRowActivate(object sender, EventArgs e)
        {
            DataRow currentDataRow = this.CurrentDataRow;
        }

        private void DataGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
        }

        private void DataGrid_SetFocus()
        {
            if ((this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.Rows[0].Activate();
            }
        }

        private void DefaultAction()
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        [LocalCommandHandler("ExportExcel")]
        public void ExportExcelHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    DefaultExt = "xls",
                    Filter = "Excel file (*.xls)|*.xls"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.FillByPage;
                this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_OS_BROJ_I_DATUM.Fill();
                ((S_OS_BROJ_I_DATUMWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_OS_BROJ_I_DATUM.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            return null;
        }

        private DataRow GetParameterRow()
        {
            return null;
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(S_OS_BROJ_I_DATUMUserControl));
            this.layoutManagerformS_OS_BROJ_I_DATUM = new TableLayoutPanel();
            this.layoutManagerformS_OS_BROJ_I_DATUM.SuspendLayout();
            this.layoutManagerformS_OS_BROJ_I_DATUM.AutoSize = true;
            this.layoutManagerformS_OS_BROJ_I_DATUM.Dock = DockStyle.Fill;
            this.layoutManagerformS_OS_BROJ_I_DATUM.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_OS_BROJ_I_DATUM.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_OS_BROJ_I_DATUM.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_OS_BROJ_I_DATUM.Size = size;
            this.layoutManagerformS_OS_BROJ_I_DATUM.ColumnCount = 2;
            this.layoutManagerformS_OS_BROJ_I_DATUM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OS_BROJ_I_DATUM.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OS_BROJ_I_DATUM.RowCount = 1;
            this.layoutManagerformS_OS_BROJ_I_DATUM.RowStyles.Add(new RowStyle());
            this.userControlDataGridS_OS_BROJ_I_DATUM = new S_OS_BROJ_I_DATUMUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.layoutManagerformS_OS_BROJ_I_DATUM.Controls.Add(this.userControlDataGridS_OS_BROJ_I_DATUM, 0, 0);
            this.layoutManagerformS_OS_BROJ_I_DATUM.SetColumnSpan(this.userControlDataGridS_OS_BROJ_I_DATUM, 2);
            this.layoutManagerformS_OS_BROJ_I_DATUM.SetRowSpan(this.userControlDataGridS_OS_BROJ_I_DATUM, 1);
            Padding padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_OS_BROJ_I_DATUM.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_OS_BROJ_I_DATUM.MinimumSize = size;
            this.userControlDataGridS_OS_BROJ_I_DATUM.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_OS_BROJ_I_DATUM);
            this.userControlDataGridS_OS_BROJ_I_DATUM.Name = "userControlDataGridS_OS_BROJ_I_DATUM";
            this.userControlDataGridS_OS_BROJ_I_DATUM.Dock = DockStyle.Fill;
            this.userControlDataGridS_OS_BROJ_I_DATUM.DockPadding.All = 5;
            this.userControlDataGridS_OS_BROJ_I_DATUM.FillAtStartup = false;
            this.userControlDataGridS_OS_BROJ_I_DATUM.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OS_BROJ_I_DATUM.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_OS_BROJ_I_DATUM.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_OS_BROJ_I_DATUMWorkWith";
            this.Text = "Work With S_OS_BROJ_I_DATUM";
            this.Load += new EventHandler(this.S_OS_BROJ_I_DATUMUserControl_Load);
            this.layoutManagerformS_OS_BROJ_I_DATUM.ResumeLayout(false);
            this.layoutManagerformS_OS_BROJ_I_DATUM.PerformLayout();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
        }

        private void Localize()
        {
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        [LocalCommandHandler("Print")]
        public void PrintHandler(object sender, EventArgs e)
        {
            if (Information.IsNothing(this.ultraPrintPreviewDialog1.Document))
            {
                this.ultraPrintPreviewDialog1.Document = this.ultraGridPrintDocument1;
                this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
                this.ultraPrintPreviewDialog1.Document.DocumentName = "";
                this.ultraPrintPreviewDialog1.Text = "";
            }
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.ultraPrintPreviewDialog1.ShowDialog(this);
            }
        }

        public void RefreshGrid(object sender, ComponentEventArgs args)
        {
            this.FillData();
        }

        [LocalCommandHandler("Refresh")]
        public void RefreshHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.FillData();
            }
        }

        private void S_OS_BROJ_I_DATUMUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.FillByPage = false;
            this.FillData();
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.DisplayLayout.UIElement.LastElementEntered;
            if (lastElementEntered is RowUIElement)
            {
                ancestor = (RowUIElement) lastElementEntered;
            }
            else
            {
                ancestor = (RowUIElement) lastElementEntered.GetAncestor(typeof(RowUIElement));
            }
            if (ancestor != null)
            {
                this.SelectHandler(RuntimeHelpers.GetObjectValue(sender), e);
            }
        }

        [LocalCommandHandler("Select")]
        public void SelectHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.m_RowSelected = this.CurrentDataRow;
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetSmartPartInfoInformation()
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.smartPartInfo1.Title = string.Format("{0} S_OS_BROJ_I_DATUM ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_OS_BROJ_I_DATUM ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_OS_BROJ_I_DATUMController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_OS_BROJ_I_DATUM.DataView[this.userControlDataGridS_OS_BROJ_I_DATUM.DataGrid.CurrentRowIndex].Row;
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.FillByRow
        {
            set
            {
                this.m_FillByRow = value;
                this.SetSmartPartInfoInformation();
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
                this.SetSmartPartInfoInformation();
            }
        }

        public DataRow FillByRow
        {
            set
            {
                this.m_FillByRow = value;
                this.SetSmartPartInfoInformation();
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

        protected virtual S_OS_BROJ_I_DATUMUserDataGrid userControlDataGridS_OS_BROJ_I_DATUM
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_OS_BROJ_I_DATUM;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_OS_BROJ_I_DATUM = value;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
                this.m_WorkWithMode = value;
                this.SetSmartPartInfoInformation();
            }
        }
    }
}

