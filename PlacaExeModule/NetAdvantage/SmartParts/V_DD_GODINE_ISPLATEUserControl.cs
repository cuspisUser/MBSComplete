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
    public class V_DD_GODINE_ISPLATEUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridV_DD_GODINE_ISPLATE")]
        private V_DD_GODINE_ISPLATEUserDataGrid _userControlDataGridV_DD_GODINE_ISPLATE;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformV_DD_GODINE_ISPLATE;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public V_DD_GODINE_ISPLATEUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.V_DD_GODINE_ISPLATEDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.V_DD_GODINE_ISPLATEDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<V_DD_GODINE_ISPLATEDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<V_DD_GODINE_ISPLATEDataSet>(this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid);
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
            if ((this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.Rows.Count > 0) && (this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.FillByPage;
                this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridV_DD_GODINE_ISPLATE.Fill();
                ((V_DD_GODINE_ISPLATEWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridV_DD_GODINE_ISPLATE.DataView.Table.DataSet;
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
            ResourceManager manager = new ResourceManager(typeof(V_DD_GODINE_ISPLATEUserControl));
            this.layoutManagerformV_DD_GODINE_ISPLATE = new TableLayoutPanel();
            this.layoutManagerformV_DD_GODINE_ISPLATE.SuspendLayout();
            this.layoutManagerformV_DD_GODINE_ISPLATE.AutoSize = true;
            this.layoutManagerformV_DD_GODINE_ISPLATE.Dock = DockStyle.Fill;
            this.layoutManagerformV_DD_GODINE_ISPLATE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformV_DD_GODINE_ISPLATE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformV_DD_GODINE_ISPLATE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformV_DD_GODINE_ISPLATE.Size = size;
            this.layoutManagerformV_DD_GODINE_ISPLATE.ColumnCount = 2;
            this.layoutManagerformV_DD_GODINE_ISPLATE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformV_DD_GODINE_ISPLATE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformV_DD_GODINE_ISPLATE.RowCount = 1;
            this.layoutManagerformV_DD_GODINE_ISPLATE.RowStyles.Add(new RowStyle());
            this.userControlDataGridV_DD_GODINE_ISPLATE = new V_DD_GODINE_ISPLATEUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.layoutManagerformV_DD_GODINE_ISPLATE.Controls.Add(this.userControlDataGridV_DD_GODINE_ISPLATE, 0, 0);
            this.layoutManagerformV_DD_GODINE_ISPLATE.SetColumnSpan(this.userControlDataGridV_DD_GODINE_ISPLATE, 2);
            this.layoutManagerformV_DD_GODINE_ISPLATE.SetRowSpan(this.userControlDataGridV_DD_GODINE_ISPLATE, 1);
            Padding padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridV_DD_GODINE_ISPLATE.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridV_DD_GODINE_ISPLATE.MinimumSize = size;
            this.userControlDataGridV_DD_GODINE_ISPLATE.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformV_DD_GODINE_ISPLATE);
            this.userControlDataGridV_DD_GODINE_ISPLATE.Name = "userControlDataGridV_DD_GODINE_ISPLATE";
            this.userControlDataGridV_DD_GODINE_ISPLATE.Dock = DockStyle.Fill;
            this.userControlDataGridV_DD_GODINE_ISPLATE.DockPadding.All = 5;
            this.userControlDataGridV_DD_GODINE_ISPLATE.FillAtStartup = false;
            this.userControlDataGridV_DD_GODINE_ISPLATE.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridV_DD_GODINE_ISPLATE.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridV_DD_GODINE_ISPLATE.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "V_DD_GODINE_ISPLATEWorkWith";
            this.Text = "Work With V_DD_GODINE_ISPLATE";
            this.Load += new EventHandler(this.V_DD_GODINE_ISPLATEUserControl_Load);
            this.layoutManagerformV_DD_GODINE_ISPLATE.ResumeLayout(false);
            this.layoutManagerformV_DD_GODINE_ISPLATE.PerformLayout();
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
                    this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.DataSet.Clear();
                    this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new V_DD_GODINE_ISPLATEDataAdapter().Update(this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.DataSet);
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
                this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} V_DD_GODINE_ISPLATE ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} V_DD_GODINE_ISPLATE ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void V_DD_GODINE_ISPLATEUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.FillByPage = false;
            this.FillData();
        }

        [CreateNew]
        public V_DD_GODINE_ISPLATEController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridV_DD_GODINE_ISPLATE.DataView[this.userControlDataGridV_DD_GODINE_ISPLATE.DataGrid.CurrentRowIndex].Row;
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

        protected virtual V_DD_GODINE_ISPLATEUserDataGrid userControlDataGridV_DD_GODINE_ISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridV_DD_GODINE_ISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridV_DD_GODINE_ISPLATE = value;
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

