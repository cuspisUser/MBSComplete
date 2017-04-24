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
    public class S_OS_STANJE_LOKACIJAUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1invbroj")]
        private UltraLabel _label1invbroj;
        [AccessedThroughProperty("textinvbroj")]
        private UltraNumericEditor _textinvbroj;
        [AccessedThroughProperty("userControlDataGridS_OS_STANJE_LOKACIJA")]
        private S_OS_STANJE_LOKACIJAUserDataGrid _userControlDataGridS_OS_STANJE_LOKACIJA;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_OS_STANJE_LOKACIJA;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_OS_STANJE_LOKACIJAUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_OS_STANJE_LOKACIJADescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_OS_STANJE_LOKACIJADescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_OS_STANJE_LOKACIJADataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_OS_STANJE_LOKACIJADataSet>(this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        private void CallPromptOSinvbroj(object sender, EditorButtonEventArgs e)
        {
            S_OS_STANJE_LOKACIJAController controller = this.Controller.WorkItem.Items.AddNew<S_OS_STANJE_LOKACIJAController>();
            DataRow parameterRow = this.GetParameterRow();
            DataRow row = controller.SelectOSinvbroj("", parameterRow);
            if (row != null)
            {
                this.textinvbroj.Text = row["INVBROJ"].ToString();
            }
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
            if ((this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.FillByPage;
                this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_OS_STANJE_LOKACIJA.Parameterinvbroj = long.Parse(this.textinvbroj.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_OS_STANJE_LOKACIJA.Fill();
                ((S_OS_STANJE_LOKACIJAWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_OS_STANJE_LOKACIJA.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("invbroj", typeof(long));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["invbroj"] = long.Parse(this.textinvbroj.Value.ToString(), CultureInfo.CurrentCulture);
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
            ResourceManager manager = new ResourceManager(typeof(S_OS_STANJE_LOKACIJAUserControl));
            this.layoutManagerformS_OS_STANJE_LOKACIJA = new TableLayoutPanel();
            this.layoutManagerformS_OS_STANJE_LOKACIJA.SuspendLayout();
            this.layoutManagerformS_OS_STANJE_LOKACIJA.AutoSize = true;
            this.layoutManagerformS_OS_STANJE_LOKACIJA.Dock = DockStyle.Fill;
            this.layoutManagerformS_OS_STANJE_LOKACIJA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_OS_STANJE_LOKACIJA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_OS_STANJE_LOKACIJA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_OS_STANJE_LOKACIJA.Size = size;
            this.layoutManagerformS_OS_STANJE_LOKACIJA.ColumnCount = 2;
            this.layoutManagerformS_OS_STANJE_LOKACIJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OS_STANJE_LOKACIJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OS_STANJE_LOKACIJA.RowCount = 2;
            this.layoutManagerformS_OS_STANJE_LOKACIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OS_STANJE_LOKACIJA.RowStyles.Add(new RowStyle());
            this.label1invbroj = new UltraLabel();
            this.textinvbroj = new UltraNumericEditor();
            this.userControlDataGridS_OS_STANJE_LOKACIJA = new S_OS_STANJE_LOKACIJAUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textinvbroj).BeginInit();
            this.SuspendLayout();
            this.label1invbroj.Name = "label1invbroj";
            this.label1invbroj.TabIndex = 1;
            this.label1invbroj.Tag = "labelinvbroj";
            this.label1invbroj.AutoSize = true;
            this.label1invbroj.StyleSetName = "FieldUltraLabel";
            this.label1invbroj.Text = "invbroj        :";
            this.label1invbroj.Appearance.TextVAlign = VAlign.Middle;
            this.label1invbroj.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1invbroj.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OS_STANJE_LOKACIJA.Controls.Add(this.label1invbroj, 0, 0);
            this.layoutManagerformS_OS_STANJE_LOKACIJA.SetColumnSpan(this.label1invbroj, 1);
            this.layoutManagerformS_OS_STANJE_LOKACIJA.SetRowSpan(this.label1invbroj, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1invbroj.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1invbroj.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textinvbroj.Location = point;
            this.textinvbroj.Name = "textinvbroj";
            this.textinvbroj.Tag = "invbroj";
            this.textinvbroj.TabIndex = 0;
            size = new System.Drawing.Size(0x77, 0x16);
            this.textinvbroj.Size = size;
            this.textinvbroj.PromptChar = ' ';
            this.textinvbroj.Enter += new EventHandler(this.numericEditor_Enter);
            this.textinvbroj.NumericType = NumericType.Double;
            this.textinvbroj.MaxValue = 79228162514264337593543950335M;
            this.textinvbroj.MinValue = -79228162514264337593543950335M;
            this.textinvbroj.MaskInput = "{LOC}-nnnnnnnnnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonOSinvbroj",
                Tag = "editorButtonOSinvbroj",
                Text = "..."
            };
            this.textinvbroj.ButtonsRight.Add(button);
            this.textinvbroj.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOSinvbroj);
            this.layoutManagerformS_OS_STANJE_LOKACIJA.Controls.Add(this.textinvbroj, 1, 0);
            this.layoutManagerformS_OS_STANJE_LOKACIJA.SetColumnSpan(this.textinvbroj, 1);
            this.layoutManagerformS_OS_STANJE_LOKACIJA.SetRowSpan(this.textinvbroj, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textinvbroj.Margin = padding;
            size = new System.Drawing.Size(0x77, 0x16);
            this.textinvbroj.MinimumSize = size;
            this.layoutManagerformS_OS_STANJE_LOKACIJA.Controls.Add(this.userControlDataGridS_OS_STANJE_LOKACIJA, 0, 1);
            this.layoutManagerformS_OS_STANJE_LOKACIJA.SetColumnSpan(this.userControlDataGridS_OS_STANJE_LOKACIJA, 2);
            this.layoutManagerformS_OS_STANJE_LOKACIJA.SetRowSpan(this.userControlDataGridS_OS_STANJE_LOKACIJA, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_OS_STANJE_LOKACIJA.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_OS_STANJE_LOKACIJA.MinimumSize = size;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_OS_STANJE_LOKACIJA);
            this.userControlDataGridS_OS_STANJE_LOKACIJA.Name = "userControlDataGridS_OS_STANJE_LOKACIJA";
            this.userControlDataGridS_OS_STANJE_LOKACIJA.Dock = DockStyle.Fill;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.DockPadding.All = 5;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.FillAtStartup = false;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OS_STANJE_LOKACIJA.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_OS_STANJE_LOKACIJA.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_OS_STANJE_LOKACIJAWorkWith";
            this.Text = "Work With S_OS_STANJE_LOKACIJA";
            this.Load += new EventHandler(this.S_OS_STANJE_LOKACIJAUserControl_Load);
            this.layoutManagerformS_OS_STANJE_LOKACIJA.ResumeLayout(false);
            this.layoutManagerformS_OS_STANJE_LOKACIJA.PerformLayout();
            ((ISupportInitialize) this.textinvbroj).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textinvbroj.Text = "0";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("invbroj") && (this.m_FillByRow["invbroj"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textinvbroj, this.m_FillByRow["invbroj"].ToString(), this.m_FillByRow.Table.Columns["invbroj"].DataType);
                    this.parameterSeted = true;
                    this.textinvbroj.Visible = false;
                    this.label1invbroj.Visible = false;
                    str = str + "," + this.m_FillByRow["invbroj"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_OS_STANJE_LOKACIJA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_OS_STANJE_LOKACIJA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                }
            }
        }

        private void Localize()
        {
            this.label1invbroj.Text = StringResources.S_OS_STANJE_LOKACIJAinvbrojParameter;
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

        private void S_OS_STANJE_LOKACIJAUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.FillByPage = true;
                this.FillData();
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_OS_STANJE_LOKACIJA ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_OS_STANJE_LOKACIJA ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_OS_STANJE_LOKACIJAController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_OS_STANJE_LOKACIJA.DataView[this.userControlDataGridS_OS_STANJE_LOKACIJA.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1invbroj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1invbroj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1invbroj = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraNumericEditor textinvbroj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textinvbroj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textinvbroj = value;
            }
        }

        protected virtual S_OS_STANJE_LOKACIJAUserDataGrid userControlDataGridS_OS_STANJE_LOKACIJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_OS_STANJE_LOKACIJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_OS_STANJE_LOKACIJA = value;
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

