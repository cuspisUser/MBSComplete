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
    public class vw_mjeseci_godine_isplateUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridvw_mjeseci_godine_isplate")]
        private vw_mjeseci_godine_isplateUserDataGrid _userControlDataGridvw_mjeseci_godine_isplate;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformvw_mjeseci_godine_isplate;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public vw_mjeseci_godine_isplateUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.vw_mjeseci_godine_isplateDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.vw_mjeseci_godine_isplateDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<vw_mjeseci_godine_isplateDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<vw_mjeseci_godine_isplateDataSet>(this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid);
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
            if ((this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.Rows.Count > 0) && (this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.FillByPage;
                this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridvw_mjeseci_godine_isplate.Fill();
                ((vw_mjeseci_godine_isplateWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridvw_mjeseci_godine_isplate.DataView.Table.DataSet;
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
            ResourceManager manager = new ResourceManager(typeof(vw_mjeseci_godine_isplateUserControl));
            this.layoutManagerformvw_mjeseci_godine_isplate = new TableLayoutPanel();
            this.layoutManagerformvw_mjeseci_godine_isplate.SuspendLayout();
            this.layoutManagerformvw_mjeseci_godine_isplate.AutoSize = true;
            this.layoutManagerformvw_mjeseci_godine_isplate.Dock = DockStyle.Fill;
            this.layoutManagerformvw_mjeseci_godine_isplate.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformvw_mjeseci_godine_isplate.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformvw_mjeseci_godine_isplate.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformvw_mjeseci_godine_isplate.Size = size;
            this.layoutManagerformvw_mjeseci_godine_isplate.ColumnCount = 2;
            this.layoutManagerformvw_mjeseci_godine_isplate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformvw_mjeseci_godine_isplate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformvw_mjeseci_godine_isplate.RowCount = 1;
            this.layoutManagerformvw_mjeseci_godine_isplate.RowStyles.Add(new RowStyle());
            this.userControlDataGridvw_mjeseci_godine_isplate = new vw_mjeseci_godine_isplateUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.layoutManagerformvw_mjeseci_godine_isplate.Controls.Add(this.userControlDataGridvw_mjeseci_godine_isplate, 0, 0);
            this.layoutManagerformvw_mjeseci_godine_isplate.SetColumnSpan(this.userControlDataGridvw_mjeseci_godine_isplate, 2);
            this.layoutManagerformvw_mjeseci_godine_isplate.SetRowSpan(this.userControlDataGridvw_mjeseci_godine_isplate, 1);
            Padding padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridvw_mjeseci_godine_isplate.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridvw_mjeseci_godine_isplate.MinimumSize = size;
            this.userControlDataGridvw_mjeseci_godine_isplate.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformvw_mjeseci_godine_isplate);
            this.userControlDataGridvw_mjeseci_godine_isplate.Name = "userControlDataGridvw_mjeseci_godine_isplate";
            this.userControlDataGridvw_mjeseci_godine_isplate.Dock = DockStyle.Fill;
            this.userControlDataGridvw_mjeseci_godine_isplate.DockPadding.All = 5;
            this.userControlDataGridvw_mjeseci_godine_isplate.FillAtStartup = false;
            this.userControlDataGridvw_mjeseci_godine_isplate.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridvw_mjeseci_godine_isplate.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridvw_mjeseci_godine_isplate.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "vw_mjeseci_godine_isplateWorkWith";
            this.Text = "Work With vw_mjeseci_godine_isplate";
            this.Load += new EventHandler(this.vw_mjeseci_godine_isplateUserControl_Load);
            this.layoutManagerformvw_mjeseci_godine_isplate.ResumeLayout(false);
            this.layoutManagerformvw_mjeseci_godine_isplate.PerformLayout();
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
                    this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.DataSet.Clear();
                    this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new vw_mjeseci_godine_isplateDataAdapter().Update(this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.DataSet);
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
                this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} vw_mjeseci_godine_isplate ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} vw_mjeseci_godine_isplate ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void vw_mjeseci_godine_isplateUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.FillByPage = false;
            this.FillData();
        }

        [CreateNew]
        public vw_mjeseci_godine_isplateController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridvw_mjeseci_godine_isplate.DataView[this.userControlDataGridvw_mjeseci_godine_isplate.DataGrid.CurrentRowIndex].Row;
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

        protected virtual vw_mjeseci_godine_isplateUserDataGrid userControlDataGridvw_mjeseci_godine_isplate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridvw_mjeseci_godine_isplate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridvw_mjeseci_godine_isplate = value;
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

