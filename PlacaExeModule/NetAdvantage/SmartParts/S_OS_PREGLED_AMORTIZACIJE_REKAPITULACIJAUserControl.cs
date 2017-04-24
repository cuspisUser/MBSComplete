namespace NetAdvantage.SmartParts
{
    using Deklarit;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Practices.CompositeUI.NetAdvantage.Services;
    using Deklarit.Practices.CompositeUI.Services;
    using Deklarit.Resources;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.Printing;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinGrid.ExcelExport;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using NetAdvantage.WorkItems;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using Placa;

    [SmartPart]
    public class S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1brojdok")]
        private UltraLabel _label1brojdok;
        [AccessedThroughProperty("textbrojdok")]
        private UltraNumericEditor _textbrojdok;
        [AccessedThroughProperty("userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA")]
        private S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAUserDataGrid _userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJADataSet>(this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid);
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
            if ((this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.FillByPage;
                this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Parameterbrojdok = int.Parse(this.textbrojdok.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Fill();
                ((S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("brojdok", typeof(int));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["brojdok"] = int.Parse(this.textbrojdok.Value.ToString(), CultureInfo.CurrentCulture);
            return row2;
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAUserControl));
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA = new TableLayoutPanel();
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.SuspendLayout();
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.AutoSize = true;
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Dock = DockStyle.Fill;
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Size = size;
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.ColumnCount = 2;
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.RowCount = 2;
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.RowStyles.Add(new RowStyle());
            this.label1brojdok = new UltraLabel();
            this.textbrojdok = new UltraNumericEditor();
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA = new S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textbrojdok).BeginInit();
            this.SuspendLayout();
            this.label1brojdok.Name = "label1brojdok";
            this.label1brojdok.TabIndex = 1;
            this.label1brojdok.Tag = "labelbrojdok";
            this.label1brojdok.AutoSize = true;
            this.label1brojdok.StyleSetName = "FieldUltraLabel";
            this.label1brojdok.Text = "brojdok     :";
            this.label1brojdok.Appearance.TextVAlign = VAlign.Middle;
            this.label1brojdok.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1brojdok.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Controls.Add(this.label1brojdok, 0, 0);
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.SetColumnSpan(this.label1brojdok, 1);
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.SetRowSpan(this.label1brojdok, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1brojdok.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1brojdok.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textbrojdok.Location = point;
            this.textbrojdok.Name = "textbrojdok";
            this.textbrojdok.Tag = "brojdok";
            this.textbrojdok.TabIndex = 0;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textbrojdok.Size = size;
            this.textbrojdok.PromptChar = ' ';
            this.textbrojdok.Enter += new EventHandler(this.numericEditor_Enter);
            this.textbrojdok.NumericType = NumericType.Integer;
            this.textbrojdok.MaskInput = "{LOC}-nnnnnnnn";
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Controls.Add(this.textbrojdok, 1, 0);
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.SetColumnSpan(this.textbrojdok, 1);
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.SetRowSpan(this.textbrojdok, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textbrojdok.Margin = padding;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textbrojdok.MinimumSize = size;
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Controls.Add(this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA, 0, 1);
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.SetColumnSpan(this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA, 2);
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.SetRowSpan(this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.MinimumSize = size;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA);
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Name = "userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA";
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Dock = DockStyle.Fill;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DockPadding.All = 5;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.FillAtStartup = false;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAWorkWith";
            this.Text = "Work With S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA";
            this.Load += new EventHandler(this.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAUserControl_Load);
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.ResumeLayout(false);
            this.layoutManagerformS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.PerformLayout();
            ((ISupportInitialize) this.textbrojdok).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textbrojdok.Text = "0";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("brojdok") && (this.m_FillByRow["brojdok"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textbrojdok, this.m_FillByRow["brojdok"].ToString(), this.m_FillByRow.Table.Columns["brojdok"].DataType);
                    this.parameterSeted = true;
                    this.textbrojdok.Visible = false;
                    this.label1brojdok.Visible = false;
                    str = str + "," + this.m_FillByRow["brojdok"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                }
            }
        }

        private void Localize()
        {
            this.label1brojdok.Text = StringResources.S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAbrojdokParameter;
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

        private void S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.FillByPage = true;
                this.FillData();
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataView[this.userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1brojdok
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1brojdok;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1brojdok = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraNumericEditor textbrojdok
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textbrojdok;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textbrojdok = value;
            }
        }

        protected virtual S_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJAUserDataGrid userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_OS_PREGLED_AMORTIZACIJE_REKAPITULACIJA = value;
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

