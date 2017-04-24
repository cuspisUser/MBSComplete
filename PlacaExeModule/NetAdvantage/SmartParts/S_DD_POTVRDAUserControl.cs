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
    public class S_DD_POTVRDAUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1GODINAISPLATE")]
        private UltraLabel _label1GODINAISPLATE;
        [AccessedThroughProperty("textGODINAISPLATE")]
        private UltraTextEditor _textGODINAISPLATE;
        [AccessedThroughProperty("userControlDataGridS_DD_POTVRDA")]
        private S_DD_POTVRDAUserDataGrid _userControlDataGridS_DD_POTVRDA;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_DD_POTVRDA;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_DD_POTVRDAUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_DD_POTVRDADescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_DD_POTVRDADescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_DD_POTVRDA.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_DD_POTVRDADataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_DD_POTVRDADataSet>(this.userControlDataGridS_DD_POTVRDA.DataGrid);
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
            if ((this.userControlDataGridS_DD_POTVRDA.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_DD_POTVRDA.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_DD_POTVRDA.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_DD_POTVRDA.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_DD_POTVRDA.DataGrid.FillByPage;
                this.userControlDataGridS_DD_POTVRDA.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_DD_POTVRDA.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_DD_POTVRDA.ParameterGODINAISPLATE = this.textGODINAISPLATE.Text;
                this.userControlDataGridS_DD_POTVRDA.Fill();
                ((S_DD_POTVRDAWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_DD_POTVRDA.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("GODINAISPLATE", typeof(string));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["GODINAISPLATE"] = this.textGODINAISPLATE.Text;
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
            ResourceManager manager = new ResourceManager(typeof(S_DD_POTVRDAUserControl));
            this.layoutManagerformS_DD_POTVRDA = new TableLayoutPanel();
            this.layoutManagerformS_DD_POTVRDA.SuspendLayout();
            this.layoutManagerformS_DD_POTVRDA.AutoSize = true;
            this.layoutManagerformS_DD_POTVRDA.Dock = DockStyle.Fill;
            this.layoutManagerformS_DD_POTVRDA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_DD_POTVRDA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_DD_POTVRDA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_DD_POTVRDA.Size = size;
            this.layoutManagerformS_DD_POTVRDA.ColumnCount = 2;
            this.layoutManagerformS_DD_POTVRDA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_DD_POTVRDA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_DD_POTVRDA.RowCount = 2;
            this.layoutManagerformS_DD_POTVRDA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_DD_POTVRDA.RowStyles.Add(new RowStyle());
            this.label1GODINAISPLATE = new UltraLabel();
            this.textGODINAISPLATE = new UltraTextEditor();
            this.userControlDataGridS_DD_POTVRDA = new S_DD_POTVRDAUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textGODINAISPLATE).BeginInit();
            this.SuspendLayout();
            this.label1GODINAISPLATE.Name = "label1GODINAISPLATE";
            this.label1GODINAISPLATE.TabIndex = 1;
            this.label1GODINAISPLATE.Tag = "labelGODINAISPLATE";
            this.label1GODINAISPLATE.AutoSize = true;
            this.label1GODINAISPLATE.StyleSetName = "FieldUltraLabel";
            this.label1GODINAISPLATE.Text = "GODINAISPLATE     :";
            this.label1GODINAISPLATE.Appearance.TextVAlign = VAlign.Middle;
            this.label1GODINAISPLATE.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1GODINAISPLATE.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_DD_POTVRDA.Controls.Add(this.label1GODINAISPLATE, 0, 0);
            this.layoutManagerformS_DD_POTVRDA.SetColumnSpan(this.label1GODINAISPLATE, 1);
            this.layoutManagerformS_DD_POTVRDA.SetRowSpan(this.label1GODINAISPLATE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1GODINAISPLATE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1GODINAISPLATE.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textGODINAISPLATE.Location = point;
            this.textGODINAISPLATE.Name = "textGODINAISPLATE";
            this.textGODINAISPLATE.Tag = "GODINAISPLATE";
            this.textGODINAISPLATE.TabIndex = 0;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textGODINAISPLATE.Size = size;
            this.textGODINAISPLATE.MaxLength = 4;
            this.layoutManagerformS_DD_POTVRDA.Controls.Add(this.textGODINAISPLATE, 1, 0);
            this.layoutManagerformS_DD_POTVRDA.SetColumnSpan(this.textGODINAISPLATE, 1);
            this.layoutManagerformS_DD_POTVRDA.SetRowSpan(this.textGODINAISPLATE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textGODINAISPLATE.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textGODINAISPLATE.MinimumSize = size;
            this.layoutManagerformS_DD_POTVRDA.Controls.Add(this.userControlDataGridS_DD_POTVRDA, 0, 1);
            this.layoutManagerformS_DD_POTVRDA.SetColumnSpan(this.userControlDataGridS_DD_POTVRDA, 2);
            this.layoutManagerformS_DD_POTVRDA.SetRowSpan(this.userControlDataGridS_DD_POTVRDA, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_DD_POTVRDA.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_DD_POTVRDA.MinimumSize = size;
            this.userControlDataGridS_DD_POTVRDA.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_DD_POTVRDA);
            this.userControlDataGridS_DD_POTVRDA.Name = "userControlDataGridS_DD_POTVRDA";
            this.userControlDataGridS_DD_POTVRDA.Dock = DockStyle.Fill;
            this.userControlDataGridS_DD_POTVRDA.DockPadding.All = 5;
            this.userControlDataGridS_DD_POTVRDA.FillAtStartup = false;
            this.userControlDataGridS_DD_POTVRDA.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_DD_POTVRDA.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_DD_POTVRDA.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_DD_POTVRDA.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_DD_POTVRDAWorkWith";
            this.Text = "Work With S_DD_POTVRDA";
            this.Load += new EventHandler(this.S_DD_POTVRDAUserControl_Load);
            this.layoutManagerformS_DD_POTVRDA.ResumeLayout(false);
            this.layoutManagerformS_DD_POTVRDA.PerformLayout();
            ((ISupportInitialize) this.textGODINAISPLATE).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textGODINAISPLATE.Text = "";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("GODINAISPLATE") && (this.m_FillByRow["GODINAISPLATE"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textGODINAISPLATE, this.m_FillByRow["GODINAISPLATE"].ToString(), this.m_FillByRow.Table.Columns["GODINAISPLATE"].DataType);
                    this.parameterSeted = true;
                    this.textGODINAISPLATE.Visible = false;
                    this.label1GODINAISPLATE.Visible = false;
                    str = str + "," + this.m_FillByRow["GODINAISPLATE"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_DD_POTVRDA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_DD_POTVRDA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                }
            }
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
                    this.userControlDataGridS_DD_POTVRDA.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_DD_POTVRDA.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_DD_POTVRDADataAdapter().Update(this.userControlDataGridS_DD_POTVRDA.DataGrid.DataSet);
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
            this.label1GODINAISPLATE.Text = StringResources.S_DD_POTVRDAGODINAISPLATEParameter;
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

        private void S_DD_POTVRDAUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_DD_POTVRDA.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_DD_POTVRDA.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_DD_POTVRDA.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_DD_POTVRDA.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_DD_POTVRDA.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_DD_POTVRDA.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_DD_POTVRDA.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_DD_POTVRDA.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_DD_POTVRDA.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_DD_POTVRDA.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_DD_POTVRDA.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_DD_POTVRDA ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_DD_POTVRDA ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_DD_POTVRDAController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_DD_POTVRDA.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_DD_POTVRDA.DataView[this.userControlDataGridS_DD_POTVRDA.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1GODINAISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1GODINAISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1GODINAISPLATE = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraTextEditor textGODINAISPLATE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textGODINAISPLATE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textGODINAISPLATE = value;
            }
        }

        protected virtual S_DD_POTVRDAUserDataGrid userControlDataGridS_DD_POTVRDA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_DD_POTVRDA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_DD_POTVRDA = value;
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

