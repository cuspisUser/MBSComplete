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
    public class S_OS_REKAP_TEMELJNICEUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1BROJOSTEMELJNICE")]
        private UltraLabel _label1BROJOSTEMELJNICE;
        [AccessedThroughProperty("label1vrstaostemeljnice")]
        private UltraLabel _label1vrstaostemeljnice;
        [AccessedThroughProperty("textBROJOSTEMELJNICE")]
        private UltraNumericEditor _textBROJOSTEMELJNICE;
        [AccessedThroughProperty("textvrstaostemeljnice")]
        private UltraNumericEditor _textvrstaostemeljnice;
        [AccessedThroughProperty("userControlDataGridS_OS_REKAP_TEMELJNICE")]
        private S_OS_REKAP_TEMELJNICEUserDataGrid _userControlDataGridS_OS_REKAP_TEMELJNICE;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_OS_REKAP_TEMELJNICE;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_OS_REKAP_TEMELJNICEUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_OS_REKAP_TEMELJNICEDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_OS_REKAP_TEMELJNICEDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_OS_REKAP_TEMELJNICEDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_OS_REKAP_TEMELJNICEDataSet>(this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid);
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
            if ((this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.FillByPage;
                this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_OS_REKAP_TEMELJNICE.ParameterBROJOSTEMELJNICE = int.Parse(this.textBROJOSTEMELJNICE.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_OS_REKAP_TEMELJNICE.Parametervrstaostemeljnice = int.Parse(this.textvrstaostemeljnice.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_OS_REKAP_TEMELJNICE.Fill();
                ((S_OS_REKAP_TEMELJNICEWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("BROJOSTEMELJNICE", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("vrstaostemeljnice", typeof(int));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["BROJOSTEMELJNICE"] = int.Parse(this.textBROJOSTEMELJNICE.Value.ToString(), CultureInfo.CurrentCulture);
            row2["vrstaostemeljnice"] = int.Parse(this.textvrstaostemeljnice.Value.ToString(), CultureInfo.CurrentCulture);
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
            ResourceManager manager = new ResourceManager(typeof(S_OS_REKAP_TEMELJNICEUserControl));
            this.layoutManagerformS_OS_REKAP_TEMELJNICE = new TableLayoutPanel();
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.SuspendLayout();
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.AutoSize = true;
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.Dock = DockStyle.Fill;
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.Size = size;
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.ColumnCount = 2;
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.RowCount = 3;
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.RowStyles.Add(new RowStyle());
            this.label1BROJOSTEMELJNICE = new UltraLabel();
            this.textBROJOSTEMELJNICE = new UltraNumericEditor();
            this.label1vrstaostemeljnice = new UltraLabel();
            this.textvrstaostemeljnice = new UltraNumericEditor();
            this.userControlDataGridS_OS_REKAP_TEMELJNICE = new S_OS_REKAP_TEMELJNICEUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textBROJOSTEMELJNICE).BeginInit();
            ((ISupportInitialize) this.textvrstaostemeljnice).BeginInit();
            this.SuspendLayout();
            this.label1BROJOSTEMELJNICE.Name = "label1BROJOSTEMELJNICE";
            this.label1BROJOSTEMELJNICE.TabIndex = 1;
            this.label1BROJOSTEMELJNICE.Tag = "labelBROJOSTEMELJNICE";
            this.label1BROJOSTEMELJNICE.AutoSize = true;
            this.label1BROJOSTEMELJNICE.StyleSetName = "FieldUltraLabel";
            this.label1BROJOSTEMELJNICE.Text = "BROJOSTEMELJNICE       :";
            this.label1BROJOSTEMELJNICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1BROJOSTEMELJNICE.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1BROJOSTEMELJNICE.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.Controls.Add(this.label1BROJOSTEMELJNICE, 0, 0);
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.SetColumnSpan(this.label1BROJOSTEMELJNICE, 1);
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.SetRowSpan(this.label1BROJOSTEMELJNICE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1BROJOSTEMELJNICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BROJOSTEMELJNICE.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textBROJOSTEMELJNICE.Location = point;
            this.textBROJOSTEMELJNICE.Name = "textBROJOSTEMELJNICE";
            this.textBROJOSTEMELJNICE.Tag = "BROJOSTEMELJNICE";
            this.textBROJOSTEMELJNICE.TabIndex = 0;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textBROJOSTEMELJNICE.Size = size;
            this.textBROJOSTEMELJNICE.PromptChar = ' ';
            this.textBROJOSTEMELJNICE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textBROJOSTEMELJNICE.NumericType = NumericType.Integer;
            this.textBROJOSTEMELJNICE.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.Controls.Add(this.textBROJOSTEMELJNICE, 1, 0);
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.SetColumnSpan(this.textBROJOSTEMELJNICE, 1);
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.SetRowSpan(this.textBROJOSTEMELJNICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBROJOSTEMELJNICE.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textBROJOSTEMELJNICE.MinimumSize = size;
            this.label1vrstaostemeljnice.Name = "label1vrstaostemeljnice";
            this.label1vrstaostemeljnice.TabIndex = 1;
            this.label1vrstaostemeljnice.Tag = "labelvrstaostemeljnice";
            this.label1vrstaostemeljnice.AutoSize = true;
            this.label1vrstaostemeljnice.StyleSetName = "FieldUltraLabel";
            this.label1vrstaostemeljnice.Text = "vrstaostemeljnice :";
            this.label1vrstaostemeljnice.Appearance.TextVAlign = VAlign.Middle;
            this.label1vrstaostemeljnice.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1vrstaostemeljnice.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.Controls.Add(this.label1vrstaostemeljnice, 0, 1);
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.SetColumnSpan(this.label1vrstaostemeljnice, 1);
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.SetRowSpan(this.label1vrstaostemeljnice, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1vrstaostemeljnice.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1vrstaostemeljnice.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textvrstaostemeljnice.Location = point;
            this.textvrstaostemeljnice.Name = "textvrstaostemeljnice";
            this.textvrstaostemeljnice.Tag = "vrstaostemeljnice";
            this.textvrstaostemeljnice.TabIndex = 1;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textvrstaostemeljnice.Size = size;
            this.textvrstaostemeljnice.PromptChar = ' ';
            this.textvrstaostemeljnice.Enter += new EventHandler(this.numericEditor_Enter);
            this.textvrstaostemeljnice.NumericType = NumericType.Integer;
            this.textvrstaostemeljnice.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.Controls.Add(this.textvrstaostemeljnice, 1, 1);
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.SetColumnSpan(this.textvrstaostemeljnice, 1);
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.SetRowSpan(this.textvrstaostemeljnice, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textvrstaostemeljnice.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textvrstaostemeljnice.MinimumSize = size;
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.Controls.Add(this.userControlDataGridS_OS_REKAP_TEMELJNICE, 0, 2);
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.SetColumnSpan(this.userControlDataGridS_OS_REKAP_TEMELJNICE, 2);
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.SetRowSpan(this.userControlDataGridS_OS_REKAP_TEMELJNICE, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.MinimumSize = size;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_OS_REKAP_TEMELJNICE);
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.Name = "userControlDataGridS_OS_REKAP_TEMELJNICE";
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.Dock = DockStyle.Fill;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.DockPadding.All = 5;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.FillAtStartup = false;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_OS_REKAP_TEMELJNICEWorkWith";
            this.Text = "Work With S_OS_REKAP_TEMELJNICE";
            this.Load += new EventHandler(this.S_OS_REKAP_TEMELJNICEUserControl_Load);
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.ResumeLayout(false);
            this.layoutManagerformS_OS_REKAP_TEMELJNICE.PerformLayout();
            ((ISupportInitialize) this.textBROJOSTEMELJNICE).EndInit();
            ((ISupportInitialize) this.textvrstaostemeljnice).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textBROJOSTEMELJNICE.Text = "0";
            this.textvrstaostemeljnice.Text = "0";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("BROJOSTEMELJNICE") && (this.m_FillByRow["BROJOSTEMELJNICE"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textBROJOSTEMELJNICE, this.m_FillByRow["BROJOSTEMELJNICE"].ToString(), this.m_FillByRow.Table.Columns["BROJOSTEMELJNICE"].DataType);
                    this.parameterSeted = true;
                    this.textBROJOSTEMELJNICE.Visible = false;
                    this.label1BROJOSTEMELJNICE.Visible = false;
                    str = str + "," + this.m_FillByRow["BROJOSTEMELJNICE"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("vrstaostemeljnice") && (this.m_FillByRow["vrstaostemeljnice"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textvrstaostemeljnice, this.m_FillByRow["vrstaostemeljnice"].ToString(), this.m_FillByRow.Table.Columns["vrstaostemeljnice"].DataType);
                    this.parameterSeted = true;
                    this.textvrstaostemeljnice.Visible = false;
                    this.label1vrstaostemeljnice.Visible = false;
                    str = str + "," + this.m_FillByRow["vrstaostemeljnice"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_OS_REKAP_TEMELJNICE " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_OS_REKAP_TEMELJNICE " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                }
            }
        }

        private void Localize()
        {
            this.label1BROJOSTEMELJNICE.Text = StringResources.S_OS_REKAP_TEMELJNICEBROJOSTEMELJNICEParameter;
            this.label1vrstaostemeljnice.Text = StringResources.S_OS_REKAP_TEMELJNICEvrstaostemeljniceParameter;
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

        private void S_OS_REKAP_TEMELJNICEUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.FillByPage = true;
                this.FillData();
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_OS_REKAP_TEMELJNICE ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_OS_REKAP_TEMELJNICE ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_OS_REKAP_TEMELJNICEController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataView[this.userControlDataGridS_OS_REKAP_TEMELJNICE.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1BROJOSTEMELJNICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BROJOSTEMELJNICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BROJOSTEMELJNICE = value;
            }
        }

        protected virtual UltraLabel label1vrstaostemeljnice
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1vrstaostemeljnice;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1vrstaostemeljnice = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraNumericEditor textBROJOSTEMELJNICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBROJOSTEMELJNICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textBROJOSTEMELJNICE = value;
            }
        }

        protected virtual UltraNumericEditor textvrstaostemeljnice
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textvrstaostemeljnice;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textvrstaostemeljnice = value;
            }
        }

        protected virtual S_OS_REKAP_TEMELJNICEUserDataGrid userControlDataGridS_OS_REKAP_TEMELJNICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_OS_REKAP_TEMELJNICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_OS_REKAP_TEMELJNICE = value;
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

