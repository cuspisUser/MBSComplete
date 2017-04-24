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
    public class S_OS_POSTOJECI_DOKUMENTIUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridS_OS_POSTOJECI_DOKUMENTI")]
        private S_OS_POSTOJECI_DOKUMENTIUserDataGrid _userControlDataGridS_OS_POSTOJECI_DOKUMENTI;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_OS_POSTOJECI_DOKUMENTI;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_OS_POSTOJECI_DOKUMENTIUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_OS_POSTOJECI_DOKUMENTIDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_OS_POSTOJECI_DOKUMENTIDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_OS_POSTOJECI_DOKUMENTIDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_OS_POSTOJECI_DOKUMENTIDataSet>(this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid);
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
            if ((this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.FillByPage;
                this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.Fill();
                ((S_OS_POSTOJECI_DOKUMENTIWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataView.Table.DataSet;
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
            ResourceManager manager = new ResourceManager(typeof(S_OS_POSTOJECI_DOKUMENTIUserControl));
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI = new TableLayoutPanel();
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.SuspendLayout();
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.AutoSize = true;
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.Dock = DockStyle.Fill;
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.Size = size;
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.ColumnCount = 2;
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.RowCount = 1;
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.RowStyles.Add(new RowStyle());
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI = new S_OS_POSTOJECI_DOKUMENTIUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.Controls.Add(this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI, 0, 0);
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.SetColumnSpan(this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI, 2);
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.SetRowSpan(this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI, 1);
            Padding padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.MinimumSize = size;
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI);
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.Name = "userControlDataGridS_OS_POSTOJECI_DOKUMENTI";
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.Dock = DockStyle.Fill;
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DockPadding.All = 5;
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.FillAtStartup = false;
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_OS_POSTOJECI_DOKUMENTIWorkWith";
            this.Text = "Work With S_OS_POSTOJECI_DOKUMENTI";
            this.Load += new EventHandler(this.S_OS_POSTOJECI_DOKUMENTIUserControl_Load);
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.ResumeLayout(false);
            this.layoutManagerformS_OS_POSTOJECI_DOKUMENTI.PerformLayout();
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

        private void S_OS_POSTOJECI_DOKUMENTIUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.FillByPage = false;
            this.FillData();
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_OS_POSTOJECI_DOKUMENTI ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_OS_POSTOJECI_DOKUMENTI ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_OS_POSTOJECI_DOKUMENTIController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataView[this.userControlDataGridS_OS_POSTOJECI_DOKUMENTI.DataGrid.CurrentRowIndex].Row;
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

        protected virtual S_OS_POSTOJECI_DOKUMENTIUserDataGrid userControlDataGridS_OS_POSTOJECI_DOKUMENTI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_OS_POSTOJECI_DOKUMENTI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_OS_POSTOJECI_DOKUMENTI = value;
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

