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
    public class PREGLEDZADUZENJAUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridPREGLEDZADUZENJA")]
        private PREGLEDZADUZENJAUserDataGrid _userControlDataGridPREGLEDZADUZENJA;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformPARTNERZADUZENJE;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public PREGLEDZADUZENJAUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.PREGLEDZADUZENJADescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.PREGLEDZADUZENJADescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridPREGLEDZADUZENJA.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<PREGLEDZADUZENJADataSet> serviceInstance = new UltraGridSelectedRowsProviderService<PREGLEDZADUZENJADataSet>(this.userControlDataGridPREGLEDZADUZENJA.DataGrid);
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
            if ((this.userControlDataGridPREGLEDZADUZENJA.DataGrid.Rows.Count > 0) && (this.userControlDataGridPREGLEDZADUZENJA.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridPREGLEDZADUZENJA.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridPREGLEDZADUZENJA.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridPREGLEDZADUZENJA.DataGrid.FillByPage;
                this.userControlDataGridPREGLEDZADUZENJA.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridPREGLEDZADUZENJA.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridPREGLEDZADUZENJA.Fill();
                ((PREGLEDZADUZENJAWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridPREGLEDZADUZENJA.DataView.Table.DataSet;
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
            ResourceManager manager = new ResourceManager(typeof(PREGLEDZADUZENJAUserControl));
            this.layoutManagerformPARTNERZADUZENJE = new TableLayoutPanel();
            this.layoutManagerformPARTNERZADUZENJE.SuspendLayout();
            this.layoutManagerformPARTNERZADUZENJE.AutoSize = true;
            this.layoutManagerformPARTNERZADUZENJE.Dock = DockStyle.Fill;
            this.layoutManagerformPARTNERZADUZENJE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPARTNERZADUZENJE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPARTNERZADUZENJE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPARTNERZADUZENJE.Size = size;
            this.layoutManagerformPARTNERZADUZENJE.ColumnCount = 2;
            this.layoutManagerformPARTNERZADUZENJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPARTNERZADUZENJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPARTNERZADUZENJE.RowCount = 1;
            this.layoutManagerformPARTNERZADUZENJE.RowStyles.Add(new RowStyle());
            this.userControlDataGridPREGLEDZADUZENJA = new PREGLEDZADUZENJAUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.layoutManagerformPARTNERZADUZENJE.Controls.Add(this.userControlDataGridPREGLEDZADUZENJA, 0, 0);
            this.layoutManagerformPARTNERZADUZENJE.SetColumnSpan(this.userControlDataGridPREGLEDZADUZENJA, 2);
            this.layoutManagerformPARTNERZADUZENJE.SetRowSpan(this.userControlDataGridPREGLEDZADUZENJA, 1);
            Padding padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridPREGLEDZADUZENJA.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridPREGLEDZADUZENJA.MinimumSize = size;
            this.userControlDataGridPREGLEDZADUZENJA.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformPARTNERZADUZENJE);
            this.userControlDataGridPREGLEDZADUZENJA.Name = "userControlDataGridPREGLEDZADUZENJA";
            this.userControlDataGridPREGLEDZADUZENJA.Dock = DockStyle.Fill;
            this.userControlDataGridPREGLEDZADUZENJA.DockPadding.All = 5;
            this.userControlDataGridPREGLEDZADUZENJA.FillAtStartup = false;
            this.userControlDataGridPREGLEDZADUZENJA.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridPREGLEDZADUZENJA.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridPREGLEDZADUZENJA.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridPREGLEDZADUZENJA.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "PREGLEDZADUZENJAWorkWith";
            this.Text = "Work With PREGLEDZADUZENJA";
            this.Load += new EventHandler(this.PREGLEDZADUZENJAUserControl_Load);
            this.layoutManagerformPARTNERZADUZENJE.ResumeLayout(false);
            this.layoutManagerformPARTNERZADUZENJE.PerformLayout();
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
                    this.userControlDataGridPREGLEDZADUZENJA.DataGrid.DataSet.Clear();
                    this.userControlDataGridPREGLEDZADUZENJA.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new PREGLEDZADUZENJADataAdapter().Update(this.userControlDataGridPREGLEDZADUZENJA.DataGrid.DataSet);
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

        private void PREGLEDZADUZENJAUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridPREGLEDZADUZENJA.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridPREGLEDZADUZENJA.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridPREGLEDZADUZENJA.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridPREGLEDZADUZENJA.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridPREGLEDZADUZENJA.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridPREGLEDZADUZENJA.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridPREGLEDZADUZENJA.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridPREGLEDZADUZENJA.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            this.userControlDataGridPREGLEDZADUZENJA.DataGrid.FillByPage = false;
            this.FillData();
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
                this.userControlDataGridPREGLEDZADUZENJA.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridPREGLEDZADUZENJA.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} PREGLEDZADUZENJA ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} PREGLEDZADUZENJA ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public PREGLEDZADUZENJAController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridPREGLEDZADUZENJA.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridPREGLEDZADUZENJA.DataView[this.userControlDataGridPREGLEDZADUZENJA.DataGrid.CurrentRowIndex].Row;
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

        protected virtual PREGLEDZADUZENJAUserDataGrid userControlDataGridPREGLEDZADUZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridPREGLEDZADUZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridPREGLEDZADUZENJA = value;
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

