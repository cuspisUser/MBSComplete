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
    public class PregledObracunaUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridPregledObracuna")]
        private PregledObracunaUserDataGrid _userControlDataGridPregledObracuna;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformPregledObracuna;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public PregledObracunaUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.PregledObracunaDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.PregledObracunaDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridPregledObracuna.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<PregledObracunaDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<PregledObracunaDataSet>(this.userControlDataGridPregledObracuna.DataGrid);
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
            if ((this.userControlDataGridPregledObracuna.DataGrid.Rows.Count > 0) && (this.userControlDataGridPregledObracuna.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridPregledObracuna.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridPregledObracuna.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridPregledObracuna.DataGrid.FillByPage;
                this.userControlDataGridPregledObracuna.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridPregledObracuna.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridPregledObracuna.Fill();
                ((PregledObracunaWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridPregledObracuna.DataView.Table.DataSet;
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
            ResourceManager manager = new ResourceManager(typeof(PregledObracunaUserControl));
            this.layoutManagerformPregledObracuna = new TableLayoutPanel();
            this.layoutManagerformPregledObracuna.SuspendLayout();
            this.layoutManagerformPregledObracuna.AutoSize = true;
            this.layoutManagerformPregledObracuna.Dock = DockStyle.Fill;
            this.layoutManagerformPregledObracuna.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPregledObracuna.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPregledObracuna.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPregledObracuna.Size = size;
            this.layoutManagerformPregledObracuna.ColumnCount = 2;
            this.layoutManagerformPregledObracuna.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPregledObracuna.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPregledObracuna.RowCount = 1;
            this.layoutManagerformPregledObracuna.RowStyles.Add(new RowStyle());
            this.userControlDataGridPregledObracuna = new PregledObracunaUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.layoutManagerformPregledObracuna.Controls.Add(this.userControlDataGridPregledObracuna, 0, 0);
            this.layoutManagerformPregledObracuna.SetColumnSpan(this.userControlDataGridPregledObracuna, 2);
            this.layoutManagerformPregledObracuna.SetRowSpan(this.userControlDataGridPregledObracuna, 1);
            Padding padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridPregledObracuna.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridPregledObracuna.MinimumSize = size;
            this.userControlDataGridPregledObracuna.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformPregledObracuna);
            this.userControlDataGridPregledObracuna.Name = "userControlDataGridPregledObracuna";
            this.userControlDataGridPregledObracuna.Dock = DockStyle.Fill;
            this.userControlDataGridPregledObracuna.DockPadding.All = 5;
            this.userControlDataGridPregledObracuna.FillAtStartup = false;
            this.userControlDataGridPregledObracuna.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridPregledObracuna.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridPregledObracuna.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridPregledObracuna.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "PregledObracunaWorkWith";
            this.Text = "Work With PregledObracuna";
            this.Load += new EventHandler(this.PregledObracunaUserControl_Load);
            this.layoutManagerformPregledObracuna.ResumeLayout(false);
            this.layoutManagerformPregledObracuna.PerformLayout();
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
                    this.userControlDataGridPregledObracuna.DataGrid.DataSet.Clear();
                    this.userControlDataGridPregledObracuna.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new PregledObracunaDataAdapter().Update(this.userControlDataGridPregledObracuna.DataGrid.DataSet);
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

        private void PregledObracunaUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridPregledObracuna.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridPregledObracuna.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridPregledObracuna.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridPregledObracuna.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridPregledObracuna.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridPregledObracuna.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridPregledObracuna.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridPregledObracuna.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            this.userControlDataGridPregledObracuna.DataGrid.FillByPage = false;
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
                this.userControlDataGridPregledObracuna.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridPregledObracuna.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} PregledObracuna ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} PregledObracuna ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public PregledObracunaController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridPregledObracuna.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridPregledObracuna.DataView[this.userControlDataGridPregledObracuna.DataGrid.CurrentRowIndex].Row;
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

        protected virtual PregledObracunaUserDataGrid userControlDataGridPregledObracuna
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridPregledObracuna;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridPregledObracuna = value;
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

