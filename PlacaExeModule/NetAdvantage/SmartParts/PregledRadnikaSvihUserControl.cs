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
    public class PregledRadnikaSvihUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridPregledRadnikaSvih")]
        private PregledRadnikaSvihUserDataGrid _userControlDataGridPregledRadnikaSvih;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformRADNIK;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public PregledRadnikaSvihUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.PregledRadnikaSvihDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.PregledRadnikaSvihDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridPregledRadnikaSvih.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<PregledRadnikaSvihDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<PregledRadnikaSvihDataSet>(this.userControlDataGridPregledRadnikaSvih.DataGrid);
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
            if ((this.userControlDataGridPregledRadnikaSvih.DataGrid.Rows.Count > 0) && (this.userControlDataGridPregledRadnikaSvih.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridPregledRadnikaSvih.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridPregledRadnikaSvih.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridPregledRadnikaSvih.DataGrid.FillByPage;
                this.userControlDataGridPregledRadnikaSvih.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridPregledRadnikaSvih.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridPregledRadnikaSvih.Fill();
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    ((RADNIKSelectionListWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridPregledRadnikaSvih.DataView.Table.DataSet;
                }
                else
                {
                    ((PregledRadnikaSvihWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridPregledRadnikaSvih.DataView.Table.DataSet;
                }
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
            ResourceManager manager = new ResourceManager(typeof(PregledRadnikaSvihUserControl));
            this.layoutManagerformRADNIK = new TableLayoutPanel();
            this.layoutManagerformRADNIK.SuspendLayout();
            this.layoutManagerformRADNIK.AutoSize = true;
            this.layoutManagerformRADNIK.Dock = DockStyle.Fill;
            this.layoutManagerformRADNIK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRADNIK.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRADNIK.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRADNIK.Size = size;
            this.layoutManagerformRADNIK.ColumnCount = 2;
            this.layoutManagerformRADNIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIK.RowCount = 1;
            this.layoutManagerformRADNIK.RowStyles.Add(new RowStyle());
            this.userControlDataGridPregledRadnikaSvih = new PregledRadnikaSvihUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.layoutManagerformRADNIK.Controls.Add(this.userControlDataGridPregledRadnikaSvih, 0, 0);
            this.layoutManagerformRADNIK.SetColumnSpan(this.userControlDataGridPregledRadnikaSvih, 2);
            this.layoutManagerformRADNIK.SetRowSpan(this.userControlDataGridPregledRadnikaSvih, 1);
            Padding padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridPregledRadnikaSvih.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridPregledRadnikaSvih.MinimumSize = size;
            this.userControlDataGridPregledRadnikaSvih.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformRADNIK);
            this.userControlDataGridPregledRadnikaSvih.Name = "userControlDataGridPregledRadnikaSvih";
            this.userControlDataGridPregledRadnikaSvih.Dock = DockStyle.Fill;
            this.userControlDataGridPregledRadnikaSvih.DockPadding.All = 5;
            this.userControlDataGridPregledRadnikaSvih.FillAtStartup = false;
            this.userControlDataGridPregledRadnikaSvih.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridPregledRadnikaSvih.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridPregledRadnikaSvih.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridPregledRadnikaSvih.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "RADNIKWorkWith";
            this.Text = "Work With Zaposlenici";
            this.Load += new EventHandler(this.PregledRadnikaSvihUserControl_Load);
            this.layoutManagerformRADNIK.ResumeLayout(false);
            this.layoutManagerformRADNIK.PerformLayout();
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

        private void PregledRadnikaSvihUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridPregledRadnikaSvih.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridPregledRadnikaSvih.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridPregledRadnikaSvih.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridPregledRadnikaSvih.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridPregledRadnikaSvih.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridPregledRadnikaSvih.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridPregledRadnikaSvih.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridPregledRadnikaSvih.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            this.userControlDataGridPregledRadnikaSvih.DataGrid.FillByPage = false;
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
                this.userControlDataGridPregledRadnikaSvih.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridPregledRadnikaSvih.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} Zaposlenici ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} Zaposlenici ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public RADNIKController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridPregledRadnikaSvih.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridPregledRadnikaSvih.DataView[this.userControlDataGridPregledRadnikaSvih.DataGrid.CurrentRowIndex].Row;
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

        protected virtual PregledRadnikaSvihUserDataGrid userControlDataGridPregledRadnikaSvih
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridPregledRadnikaSvih;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridPregledRadnikaSvih = value;
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

