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
    public class VW_MJESECI_GODINE_OBRACUNAUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridVW_MJESECI_GODINE_OBRACUNA")]
        private VW_MJESECI_GODINE_OBRACUNAUserDataGrid _userControlDataGridVW_MJESECI_GODINE_OBRACUNA;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformVW_MJESECI_GODINE_OBRACUNA;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public VW_MJESECI_GODINE_OBRACUNAUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.VW_MJESECI_GODINE_OBRACUNADescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.VW_MJESECI_GODINE_OBRACUNADescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<VW_MJESECI_GODINE_OBRACUNADataSet> serviceInstance = new UltraGridSelectedRowsProviderService<VW_MJESECI_GODINE_OBRACUNADataSet>(this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid);
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
            if ((this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.Rows.Count > 0) && (this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.FillByPage;
                this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.Fill();
                ((VW_MJESECI_GODINE_OBRACUNAWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataView.Table.DataSet;
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
            ResourceManager manager = new ResourceManager(typeof(VW_MJESECI_GODINE_OBRACUNAUserControl));
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA = new TableLayoutPanel();
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.SuspendLayout();
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.AutoSize = true;
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.Dock = DockStyle.Fill;
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.Size = size;
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.ColumnCount = 2;
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.RowCount = 1;
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.RowStyles.Add(new RowStyle());
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA = new VW_MJESECI_GODINE_OBRACUNAUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.Controls.Add(this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA, 0, 0);
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.SetColumnSpan(this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA, 2);
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.SetRowSpan(this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA, 1);
            Padding padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.MinimumSize = size;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA);
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.Name = "userControlDataGridVW_MJESECI_GODINE_OBRACUNA";
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.Dock = DockStyle.Fill;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DockPadding.All = 5;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.FillAtStartup = false;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "VW_MJESECI_GODINE_OBRACUNAWorkWith";
            this.Text = "Work With VW_MJESECI_GODINE_OBRACUNA";
            this.Load += new EventHandler(this.VW_MJESECI_GODINE_OBRACUNAUserControl_Load);
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.ResumeLayout(false);
            this.layoutManagerformVW_MJESECI_GODINE_OBRACUNA.PerformLayout();
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
                    this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.DataSet.Clear();
                    this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new VW_MJESECI_GODINE_OBRACUNADataAdapter().Update(this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.DataSet);
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
                this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} VW_MJESECI_GODINE_OBRACUNA ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} VW_MJESECI_GODINE_OBRACUNA ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void VW_MJESECI_GODINE_OBRACUNAUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.FillByPage = false;
            this.FillData();
        }

        [CreateNew]
        public VW_MJESECI_GODINE_OBRACUNAController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataView[this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DataGrid.CurrentRowIndex].Row;
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

        protected virtual VW_MJESECI_GODINE_OBRACUNAUserDataGrid userControlDataGridVW_MJESECI_GODINE_OBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridVW_MJESECI_GODINE_OBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridVW_MJESECI_GODINE_OBRACUNA = value;
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

