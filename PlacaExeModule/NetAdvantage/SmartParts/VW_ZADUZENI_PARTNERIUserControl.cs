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
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class VW_ZADUZENI_PARTNERIUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridVW_ZADUZENI_PARTNERI")]
        private VW_ZADUZENI_PARTNERIUserDataGrid _userControlDataGridVW_ZADUZENI_PARTNERI;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformVW_ZADUZENI_PARTNERI;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public VW_ZADUZENI_PARTNERIUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.VW_ZADUZENI_PARTNERIDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.VW_ZADUZENI_PARTNERIDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<VW_ZADUZENI_PARTNERIDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<VW_ZADUZENI_PARTNERIDataSet>(this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid);
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
            if ((this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.Rows.Count > 0) && (this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.FillByPage;
                this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridVW_ZADUZENI_PARTNERI.Fill();
                ((VW_ZADUZENI_PARTNERIWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridVW_ZADUZENI_PARTNERI.DataView.Table.DataSet;
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
            ResourceManager manager = new ResourceManager(typeof(VW_ZADUZENI_PARTNERIUserControl));
            this.layoutManagerformVW_ZADUZENI_PARTNERI = new TableLayoutPanel();
            this.layoutManagerformVW_ZADUZENI_PARTNERI.SuspendLayout();
            this.layoutManagerformVW_ZADUZENI_PARTNERI.AutoSize = true;
            this.layoutManagerformVW_ZADUZENI_PARTNERI.Dock = DockStyle.Fill;
            this.layoutManagerformVW_ZADUZENI_PARTNERI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformVW_ZADUZENI_PARTNERI.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformVW_ZADUZENI_PARTNERI.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformVW_ZADUZENI_PARTNERI.Size = size;
            this.layoutManagerformVW_ZADUZENI_PARTNERI.ColumnCount = 2;
            this.layoutManagerformVW_ZADUZENI_PARTNERI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVW_ZADUZENI_PARTNERI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVW_ZADUZENI_PARTNERI.RowCount = 1;
            this.layoutManagerformVW_ZADUZENI_PARTNERI.RowStyles.Add(new RowStyle());
            this.userControlDataGridVW_ZADUZENI_PARTNERI = new VW_ZADUZENI_PARTNERIUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.layoutManagerformVW_ZADUZENI_PARTNERI.Controls.Add(this.userControlDataGridVW_ZADUZENI_PARTNERI, 0, 0);
            this.layoutManagerformVW_ZADUZENI_PARTNERI.SetColumnSpan(this.userControlDataGridVW_ZADUZENI_PARTNERI, 2);
            this.layoutManagerformVW_ZADUZENI_PARTNERI.SetRowSpan(this.userControlDataGridVW_ZADUZENI_PARTNERI, 1);
            Padding padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridVW_ZADUZENI_PARTNERI.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridVW_ZADUZENI_PARTNERI.MinimumSize = size;
            this.userControlDataGridVW_ZADUZENI_PARTNERI.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformVW_ZADUZENI_PARTNERI);
            this.userControlDataGridVW_ZADUZENI_PARTNERI.Name = "userControlDataGridVW_ZADUZENI_PARTNERI";
            this.userControlDataGridVW_ZADUZENI_PARTNERI.Dock = DockStyle.Fill;
            this.userControlDataGridVW_ZADUZENI_PARTNERI.DockPadding.All = 5;
            this.userControlDataGridVW_ZADUZENI_PARTNERI.FillAtStartup = false;
            this.userControlDataGridVW_ZADUZENI_PARTNERI.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridVW_ZADUZENI_PARTNERI.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridVW_ZADUZENI_PARTNERI.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "VW_ZADUZENI_PARTNERIWorkWith";
            this.Text = "Work With VW_ZADUZENI_PARTNERI";
            this.Load += new EventHandler(this.VW_ZADUZENI_PARTNERIUserControl_Load);
            this.layoutManagerformVW_ZADUZENI_PARTNERI.ResumeLayout(false);
            this.layoutManagerformVW_ZADUZENI_PARTNERI.PerformLayout();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
        }

        [LocalCommandHandler("ImportXml")]
        public void LoadFromXml(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                DefaultExt = "xml",
                Filter = "XML file (*.xml)|*.xml"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.DataSet.Clear();
                    this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new VW_ZADUZENI_PARTNERIDataAdapter().Update(this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.DataSet);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    
                }
            }
            this.FillData();
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

        [LocalCommandHandler("ExportXml")]
        public void SaveToXml(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog {
                DefaultExt = "xml",
                Filter = "XML file (*.xml)|*.xml"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} VW_ZADUZENI_PARTNERI ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} VW_ZADUZENI_PARTNERI ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void VW_ZADUZENI_PARTNERIUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.FillByPage = false;
            this.FillData();
        }

        [CreateNew]
        public VW_ZADUZENI_PARTNERIController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridVW_ZADUZENI_PARTNERI.DataView[this.userControlDataGridVW_ZADUZENI_PARTNERI.DataGrid.CurrentRowIndex].Row;
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

        protected virtual VW_ZADUZENI_PARTNERIUserDataGrid userControlDataGridVW_ZADUZENI_PARTNERI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridVW_ZADUZENI_PARTNERI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridVW_ZADUZENI_PARTNERI = value;
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

