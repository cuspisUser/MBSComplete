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
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class S_FIN_DNEVNIKBLAGAJNEODDOUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1AKTIVNAGODINA")]
        private UltraLabel _label1AKTIVNAGODINA;
        [AccessedThroughProperty("label1BLAG")]
        private UltraLabel _label1BLAG;
        [AccessedThroughProperty("label1DOO")]
        private UltraLabel _label1DOO;
        [AccessedThroughProperty("label1ODD")]
        private UltraLabel _label1ODD;
        [AccessedThroughProperty("label1VRSTA")]
        private UltraLabel _label1VRSTA;
        [AccessedThroughProperty("textAKTIVNAGODINA")]
        private UltraNumericEditor _textAKTIVNAGODINA;
        [AccessedThroughProperty("textBLAG")]
        private UltraNumericEditor _textBLAG;
        [AccessedThroughProperty("textDOO")]
        private UltraNumericEditor _textDOO;
        [AccessedThroughProperty("textODD")]
        private UltraNumericEditor _textODD;
        [AccessedThroughProperty("textVRSTA")]
        private UltraNumericEditor _textVRSTA;
        [AccessedThroughProperty("userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO")]
        private S_FIN_DNEVNIKBLAGAJNEODDOUserDataGrid _userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_FIN_DNEVNIKBLAGAJNEODDOUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_FIN_DNEVNIKBLAGAJNEODDODescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_FIN_DNEVNIKBLAGAJNEODDODescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_FIN_DNEVNIKBLAGAJNEODDODataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_FIN_DNEVNIKBLAGAJNEODDODataSet>(this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid);
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
            if ((this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.FillByPage;
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.ParameterODD = int.Parse(this.textODD.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.ParameterDOO = int.Parse(this.textDOO.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.ParameterVRSTA = int.Parse(this.textVRSTA.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.ParameterBLAG = int.Parse(this.textBLAG.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.ParameterAKTIVNAGODINA = short.Parse(this.textAKTIVNAGODINA.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.Fill();
                ((S_FIN_DNEVNIKBLAGAJNEODDOWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("ODD", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("DOO", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("VRSTA", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("BLAG", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("AKTIVNAGODINA", typeof(short));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["ODD"] = int.Parse(this.textODD.Value.ToString(), CultureInfo.CurrentCulture);
            row2["DOO"] = int.Parse(this.textDOO.Value.ToString(), CultureInfo.CurrentCulture);
            row2["VRSTA"] = int.Parse(this.textVRSTA.Value.ToString(), CultureInfo.CurrentCulture);
            row2["BLAG"] = int.Parse(this.textBLAG.Value.ToString(), CultureInfo.CurrentCulture);
            row2["AKTIVNAGODINA"] = short.Parse(this.textAKTIVNAGODINA.Value.ToString(), CultureInfo.CurrentCulture);
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
            ResourceManager manager = new ResourceManager(typeof(S_FIN_DNEVNIKBLAGAJNEODDOUserControl));
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO = new TableLayoutPanel();
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SuspendLayout();
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.AutoSize = true;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.Dock = DockStyle.Fill;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.Size = size;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.ColumnCount = 2;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.RowCount = 6;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.RowStyles.Add(new RowStyle());
            this.label1ODD = new UltraLabel();
            this.textODD = new UltraNumericEditor();
            this.label1DOO = new UltraLabel();
            this.textDOO = new UltraNumericEditor();
            this.label1VRSTA = new UltraLabel();
            this.textVRSTA = new UltraNumericEditor();
            this.label1BLAG = new UltraLabel();
            this.textBLAG = new UltraNumericEditor();
            this.label1AKTIVNAGODINA = new UltraLabel();
            this.textAKTIVNAGODINA = new UltraNumericEditor();
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO = new S_FIN_DNEVNIKBLAGAJNEODDOUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textODD).BeginInit();
            ((ISupportInitialize) this.textDOO).BeginInit();
            ((ISupportInitialize) this.textVRSTA).BeginInit();
            ((ISupportInitialize) this.textBLAG).BeginInit();
            ((ISupportInitialize) this.textAKTIVNAGODINA).BeginInit();
            this.SuspendLayout();
            this.label1ODD.Name = "label1ODD";
            this.label1ODD.TabIndex = 1;
            this.label1ODD.Tag = "labelODD";
            this.label1ODD.AutoSize = true;
            this.label1ODD.StyleSetName = "FieldUltraLabel";
            this.label1ODD.Text = "ODD    :";
            this.label1ODD.Appearance.TextVAlign = VAlign.Middle;
            this.label1ODD.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ODD.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.Controls.Add(this.label1ODD, 0, 0);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetColumnSpan(this.label1ODD, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetRowSpan(this.label1ODD, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1ODD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ODD.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textODD.Location = point;
            this.textODD.Name = "textODD";
            this.textODD.Tag = "ODD";
            this.textODD.TabIndex = 0;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textODD.Size = size;
            this.textODD.PromptChar = ' ';
            this.textODD.Enter += new EventHandler(this.numericEditor_Enter);
            this.textODD.NumericType = NumericType.Integer;
            this.textODD.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.Controls.Add(this.textODD, 1, 0);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetColumnSpan(this.textODD, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetRowSpan(this.textODD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textODD.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textODD.MinimumSize = size;
            this.label1DOO.Name = "label1DOO";
            this.label1DOO.TabIndex = 1;
            this.label1DOO.Tag = "labelDOO";
            this.label1DOO.AutoSize = true;
            this.label1DOO.StyleSetName = "FieldUltraLabel";
            this.label1DOO.Text = "DOO    :";
            this.label1DOO.Appearance.TextVAlign = VAlign.Middle;
            this.label1DOO.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1DOO.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.Controls.Add(this.label1DOO, 0, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetColumnSpan(this.label1DOO, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetRowSpan(this.label1DOO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DOO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DOO.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textDOO.Location = point;
            this.textDOO.Name = "textDOO";
            this.textDOO.Tag = "DOO";
            this.textDOO.TabIndex = 1;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textDOO.Size = size;
            this.textDOO.PromptChar = ' ';
            this.textDOO.Enter += new EventHandler(this.numericEditor_Enter);
            this.textDOO.NumericType = NumericType.Integer;
            this.textDOO.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.Controls.Add(this.textDOO, 1, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetColumnSpan(this.textDOO, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetRowSpan(this.textDOO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDOO.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textDOO.MinimumSize = size;
            this.label1VRSTA.Name = "label1VRSTA";
            this.label1VRSTA.TabIndex = 1;
            this.label1VRSTA.Tag = "labelVRSTA";
            this.label1VRSTA.AutoSize = true;
            this.label1VRSTA.StyleSetName = "FieldUltraLabel";
            this.label1VRSTA.Text = "VRSTA    :";
            this.label1VRSTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1VRSTA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1VRSTA.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.Controls.Add(this.label1VRSTA, 0, 2);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetColumnSpan(this.label1VRSTA, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetRowSpan(this.label1VRSTA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VRSTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VRSTA.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textVRSTA.Location = point;
            this.textVRSTA.Name = "textVRSTA";
            this.textVRSTA.Tag = "VRSTA";
            this.textVRSTA.TabIndex = 2;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textVRSTA.Size = size;
            this.textVRSTA.PromptChar = ' ';
            this.textVRSTA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textVRSTA.NumericType = NumericType.Integer;
            this.textVRSTA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.Controls.Add(this.textVRSTA, 1, 2);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetColumnSpan(this.textVRSTA, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetRowSpan(this.textVRSTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVRSTA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textVRSTA.MinimumSize = size;
            this.label1BLAG.Name = "label1BLAG";
            this.label1BLAG.TabIndex = 1;
            this.label1BLAG.Tag = "labelBLAG";
            this.label1BLAG.AutoSize = true;
            this.label1BLAG.StyleSetName = "FieldUltraLabel";
            this.label1BLAG.Text = "BLAG    :";
            this.label1BLAG.Appearance.TextVAlign = VAlign.Middle;
            this.label1BLAG.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1BLAG.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.Controls.Add(this.label1BLAG, 0, 3);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetColumnSpan(this.label1BLAG, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetRowSpan(this.label1BLAG, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BLAG.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BLAG.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textBLAG.Location = point;
            this.textBLAG.Name = "textBLAG";
            this.textBLAG.Tag = "BLAG";
            this.textBLAG.TabIndex = 3;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textBLAG.Size = size;
            this.textBLAG.PromptChar = ' ';
            this.textBLAG.Enter += new EventHandler(this.numericEditor_Enter);
            this.textBLAG.NumericType = NumericType.Integer;
            this.textBLAG.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.Controls.Add(this.textBLAG, 1, 3);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetColumnSpan(this.textBLAG, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetRowSpan(this.textBLAG, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBLAG.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textBLAG.MinimumSize = size;
            this.label1AKTIVNAGODINA.Name = "label1AKTIVNAGODINA";
            this.label1AKTIVNAGODINA.TabIndex = 1;
            this.label1AKTIVNAGODINA.Tag = "labelAKTIVNAGODINA";
            this.label1AKTIVNAGODINA.AutoSize = true;
            this.label1AKTIVNAGODINA.StyleSetName = "FieldUltraLabel";
            this.label1AKTIVNAGODINA.Text = "AKTIVNAGODINA :";
            this.label1AKTIVNAGODINA.Appearance.TextVAlign = VAlign.Middle;
            this.label1AKTIVNAGODINA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1AKTIVNAGODINA.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.Controls.Add(this.label1AKTIVNAGODINA, 0, 4);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetColumnSpan(this.label1AKTIVNAGODINA, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetRowSpan(this.label1AKTIVNAGODINA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1AKTIVNAGODINA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1AKTIVNAGODINA.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textAKTIVNAGODINA.Location = point;
            this.textAKTIVNAGODINA.Name = "textAKTIVNAGODINA";
            this.textAKTIVNAGODINA.Tag = "AKTIVNAGODINA";
            this.textAKTIVNAGODINA.TabIndex = 4;
            size = new System.Drawing.Size(0x2d, 0x16);
            this.textAKTIVNAGODINA.Size = size;
            this.textAKTIVNAGODINA.PromptChar = ' ';
            this.textAKTIVNAGODINA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textAKTIVNAGODINA.NumericType = NumericType.Integer;
            this.textAKTIVNAGODINA.MaskInput = "{LOC}-nnnn";
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.Controls.Add(this.textAKTIVNAGODINA, 1, 4);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetColumnSpan(this.textAKTIVNAGODINA, 1);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetRowSpan(this.textAKTIVNAGODINA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textAKTIVNAGODINA.Margin = padding;
            size = new System.Drawing.Size(0x2d, 0x16);
            this.textAKTIVNAGODINA.MinimumSize = size;
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.Controls.Add(this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO, 0, 5);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetColumnSpan(this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO, 2);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.SetRowSpan(this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.MinimumSize = size;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.Name = "userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO";
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DockPadding.All = 5;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.FillAtStartup = false;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_FIN_DNEVNIKBLAGAJNEODDOWorkWith";
            this.Text = "Work With S_FIN_DNEVNIKBLAGAJNEODDO";
            this.Load += new EventHandler(this.S_FIN_DNEVNIKBLAGAJNEODDOUserControl_Load);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.ResumeLayout(false);
            this.layoutManagerformS_FIN_DNEVNIKBLAGAJNEODDO.PerformLayout();
            ((ISupportInitialize) this.textODD).EndInit();
            ((ISupportInitialize) this.textDOO).EndInit();
            ((ISupportInitialize) this.textVRSTA).EndInit();
            ((ISupportInitialize) this.textBLAG).EndInit();
            ((ISupportInitialize) this.textAKTIVNAGODINA).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textODD.Text = "0";
            this.textDOO.Text = "0";
            this.textVRSTA.Text = "0";
            this.textBLAG.Text = "0";
            this.textAKTIVNAGODINA.Text = "0";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("ODD") && (this.m_FillByRow["ODD"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textODD, this.m_FillByRow["ODD"].ToString(), this.m_FillByRow.Table.Columns["ODD"].DataType);
                    this.parameterSeted = true;
                    this.textODD.Visible = false;
                    this.label1ODD.Visible = false;
                    str = str + "," + this.m_FillByRow["ODD"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("DOO") && (this.m_FillByRow["DOO"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textDOO, this.m_FillByRow["DOO"].ToString(), this.m_FillByRow.Table.Columns["DOO"].DataType);
                    this.parameterSeted = true;
                    this.textDOO.Visible = false;
                    this.label1DOO.Visible = false;
                    str = str + "," + this.m_FillByRow["DOO"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("VRSTA") && (this.m_FillByRow["VRSTA"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textVRSTA, this.m_FillByRow["VRSTA"].ToString(), this.m_FillByRow.Table.Columns["VRSTA"].DataType);
                    this.parameterSeted = true;
                    this.textVRSTA.Visible = false;
                    this.label1VRSTA.Visible = false;
                    str = str + "," + this.m_FillByRow["VRSTA"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("BLAG") && (this.m_FillByRow["BLAG"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textBLAG, this.m_FillByRow["BLAG"].ToString(), this.m_FillByRow.Table.Columns["BLAG"].DataType);
                    this.parameterSeted = true;
                    this.textBLAG.Visible = false;
                    this.label1BLAG.Visible = false;
                    str = str + "," + this.m_FillByRow["BLAG"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("AKTIVNAGODINA") && (this.m_FillByRow["AKTIVNAGODINA"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textAKTIVNAGODINA, this.m_FillByRow["AKTIVNAGODINA"].ToString(), this.m_FillByRow.Table.Columns["AKTIVNAGODINA"].DataType);
                    this.parameterSeted = true;
                    this.textAKTIVNAGODINA.Visible = false;
                    this.label1AKTIVNAGODINA.Visible = false;
                    str = str + "," + this.m_FillByRow["AKTIVNAGODINA"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_FIN_DNEVNIKBLAGAJNEODDO " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_FIN_DNEVNIKBLAGAJNEODDO " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_FIN_DNEVNIKBLAGAJNEODDODataAdapter().Update(this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.DataSet);
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
            this.label1ODD.Text = StringResources.S_FIN_DNEVNIKBLAGAJNEODDOODDParameter;
            this.label1DOO.Text = StringResources.S_FIN_DNEVNIKBLAGAJNEODDODOOParameter;
            this.label1VRSTA.Text = StringResources.S_FIN_DNEVNIKBLAGAJNEODDOVRSTAParameter;
            this.label1BLAG.Text = StringResources.S_FIN_DNEVNIKBLAGAJNEODDOBLAGParameter;
            this.label1AKTIVNAGODINA.Text = StringResources.S_FIN_DNEVNIKBLAGAJNEODDOAKTIVNAGODINAParameter;
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

        private void S_FIN_DNEVNIKBLAGAJNEODDOUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_DNEVNIKBLAGAJNEODDO ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_DNEVNIKBLAGAJNEODDO ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_FIN_DNEVNIKBLAGAJNEODDOController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataView[this.userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1AKTIVNAGODINA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1AKTIVNAGODINA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1AKTIVNAGODINA = value;
            }
        }

        protected virtual UltraLabel label1BLAG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BLAG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BLAG = value;
            }
        }

        protected virtual UltraLabel label1DOO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DOO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DOO = value;
            }
        }

        protected virtual UltraLabel label1ODD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ODD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ODD = value;
            }
        }

        protected virtual UltraLabel label1VRSTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VRSTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VRSTA = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraNumericEditor textAKTIVNAGODINA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textAKTIVNAGODINA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textAKTIVNAGODINA = value;
            }
        }

        protected virtual UltraNumericEditor textBLAG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBLAG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textBLAG = value;
            }
        }

        protected virtual UltraNumericEditor textDOO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDOO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDOO = value;
            }
        }

        protected virtual UltraNumericEditor textODD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textODD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textODD = value;
            }
        }

        protected virtual UltraNumericEditor textVRSTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVRSTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVRSTA = value;
            }
        }

        protected virtual S_FIN_DNEVNIKBLAGAJNEODDOUserDataGrid userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_FIN_DNEVNIKBLAGAJNEODDO = value;
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

