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
    public class sp_maticni_kartonUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("checkukljucenobruto")]
        private UltraCheckEditor _checkukljucenobruto;
        [AccessedThroughProperty("checkukljucenodoprinosiiz")]
        private UltraCheckEditor _checkukljucenodoprinosiiz;
        [AccessedThroughProperty("checkukljucenodoprinosina")]
        private UltraCheckEditor _checkukljucenodoprinosina;
        [AccessedThroughProperty("checkukljucenoisplata")]
        private UltraCheckEditor _checkukljucenoisplata;
        [AccessedThroughProperty("checkukljucenonetonaknade")]
        private UltraCheckEditor _checkukljucenonetonaknade;
        [AccessedThroughProperty("checkukljucenonetoplaca")]
        private UltraCheckEditor _checkukljucenonetoplaca;
        [AccessedThroughProperty("checkukljucenoobustave")]
        private UltraCheckEditor _checkukljucenoobustave;
        [AccessedThroughProperty("checkukljucenoolaksice")]
        private UltraCheckEditor _checkukljucenoolaksice;
        [AccessedThroughProperty("checkukljucenooo")]
        private UltraCheckEditor _checkukljucenooo;
        [AccessedThroughProperty("checkukljucenoporezi")]
        private UltraCheckEditor _checkukljucenoporezi;
        [AccessedThroughProperty("checkzbirni")]
        private UltraCheckEditor _checkzbirni;
        [AccessedThroughProperty("label1godina")]
        private UltraLabel _label1godina;
        [AccessedThroughProperty("label1idradnik_do")]
        private UltraLabel _label1idradnik_do;
        [AccessedThroughProperty("label1idradnik_od")]
        private UltraLabel _label1idradnik_od;
        [AccessedThroughProperty("label1ukljucenobruto")]
        private UltraLabel _label1ukljucenobruto;
        [AccessedThroughProperty("label1ukljucenodoprinosiiz")]
        private UltraLabel _label1ukljucenodoprinosiiz;
        [AccessedThroughProperty("label1ukljucenodoprinosina")]
        private UltraLabel _label1ukljucenodoprinosina;
        [AccessedThroughProperty("label1ukljucenoisplata")]
        private UltraLabel _label1ukljucenoisplata;
        [AccessedThroughProperty("label1ukljucenonetonaknade")]
        private UltraLabel _label1ukljucenonetonaknade;
        [AccessedThroughProperty("label1ukljucenonetoplaca")]
        private UltraLabel _label1ukljucenonetoplaca;
        [AccessedThroughProperty("label1ukljucenoobustave")]
        private UltraLabel _label1ukljucenoobustave;
        [AccessedThroughProperty("label1ukljucenoolaksice")]
        private UltraLabel _label1ukljucenoolaksice;
        [AccessedThroughProperty("label1ukljucenooo")]
        private UltraLabel _label1ukljucenooo;
        [AccessedThroughProperty("label1ukljucenoporezi")]
        private UltraLabel _label1ukljucenoporezi;
        [AccessedThroughProperty("label1zbirni")]
        private UltraLabel _label1zbirni;
        [AccessedThroughProperty("textgodina")]
        private UltraTextEditor _textgodina;
        [AccessedThroughProperty("textidradnik_do")]
        private UltraNumericEditor _textidradnik_do;
        [AccessedThroughProperty("textidradnik_od")]
        private UltraNumericEditor _textidradnik_od;
        [AccessedThroughProperty("userControlDataGridsp_maticni_karton")]
        private sp_maticni_kartonUserDataGrid _userControlDataGridsp_maticni_karton;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformsp_maticni_karton;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public sp_maticni_kartonUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.sp_maticni_kartonDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.sp_maticni_kartonDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridsp_maticni_karton.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<sp_maticni_kartonDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<sp_maticni_kartonDataSet>(this.userControlDataGridsp_maticni_karton.DataGrid);
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
            if ((this.userControlDataGridsp_maticni_karton.DataGrid.Rows.Count > 0) && (this.userControlDataGridsp_maticni_karton.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridsp_maticni_karton.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridsp_maticni_karton.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridsp_maticni_karton.DataGrid.FillByPage;
                this.userControlDataGridsp_maticni_karton.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridsp_maticni_karton.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridsp_maticni_karton.Parametergodina = this.textgodina.Text;
                this.userControlDataGridsp_maticni_karton.Parameteridradnik_od = int.Parse(this.textidradnik_od.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridsp_maticni_karton.Parameteridradnik_do = int.Parse(this.textidradnik_do.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridsp_maticni_karton.Parameterzbirni = this.checkzbirni.Checked;
                this.userControlDataGridsp_maticni_karton.Parameterukljucenobruto = this.checkukljucenobruto.Checked;
                this.userControlDataGridsp_maticni_karton.Parameterukljucenodoprinosiiz = this.checkukljucenodoprinosiiz.Checked;
                this.userControlDataGridsp_maticni_karton.Parameterukljucenodoprinosina = this.checkukljucenodoprinosina.Checked;
                this.userControlDataGridsp_maticni_karton.Parameterukljucenoporezi = this.checkukljucenoporezi.Checked;
                this.userControlDataGridsp_maticni_karton.Parameterukljucenooo = this.checkukljucenooo.Checked;
                this.userControlDataGridsp_maticni_karton.Parameterukljucenoobustave = this.checkukljucenoobustave.Checked;
                this.userControlDataGridsp_maticni_karton.Parameterukljucenoolaksice = this.checkukljucenoolaksice.Checked;
                this.userControlDataGridsp_maticni_karton.Parameterukljucenonetoplaca = this.checkukljucenonetoplaca.Checked;
                this.userControlDataGridsp_maticni_karton.Parameterukljucenonetonaknade = this.checkukljucenonetonaknade.Checked;
                this.userControlDataGridsp_maticni_karton.Parameterukljucenoisplata = this.checkukljucenoisplata.Checked;
                this.userControlDataGridsp_maticni_karton.Fill();
                ((sp_maticni_kartonWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridsp_maticni_karton.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("godina", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("idradnik_od", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("idradnik_do", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("zbirni", typeof(bool));
            table2.Columns.Add(column);
            column = new DataColumn("ukljucenobruto", typeof(bool));
            table2.Columns.Add(column);
            column = new DataColumn("ukljucenodoprinosiiz", typeof(bool));
            table2.Columns.Add(column);
            column = new DataColumn("ukljucenodoprinosina", typeof(bool));
            table2.Columns.Add(column);
            column = new DataColumn("ukljucenoporezi", typeof(bool));
            table2.Columns.Add(column);
            column = new DataColumn("ukljucenooo", typeof(bool));
            table2.Columns.Add(column);
            column = new DataColumn("ukljucenoobustave", typeof(bool));
            table2.Columns.Add(column);
            column = new DataColumn("ukljucenoolaksice", typeof(bool));
            table2.Columns.Add(column);
            column = new DataColumn("ukljucenonetoplaca", typeof(bool));
            table2.Columns.Add(column);
            column = new DataColumn("ukljucenonetonaknade", typeof(bool));
            table2.Columns.Add(column);
            column = new DataColumn("ukljucenoisplata", typeof(bool));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["godina"] = this.textgodina.Text;
            row2["idradnik_od"] = int.Parse(this.textidradnik_od.Value.ToString(), CultureInfo.CurrentCulture);
            row2["idradnik_do"] = int.Parse(this.textidradnik_do.Value.ToString(), CultureInfo.CurrentCulture);
            row2["zbirni"] = this.checkzbirni.Checked;
            row2["ukljucenobruto"] = this.checkukljucenobruto.Checked;
            row2["ukljucenodoprinosiiz"] = this.checkukljucenodoprinosiiz.Checked;
            row2["ukljucenodoprinosina"] = this.checkukljucenodoprinosina.Checked;
            row2["ukljucenoporezi"] = this.checkukljucenoporezi.Checked;
            row2["ukljucenooo"] = this.checkukljucenooo.Checked;
            row2["ukljucenoobustave"] = this.checkukljucenoobustave.Checked;
            row2["ukljucenoolaksice"] = this.checkukljucenoolaksice.Checked;
            row2["ukljucenonetoplaca"] = this.checkukljucenonetoplaca.Checked;
            row2["ukljucenonetonaknade"] = this.checkukljucenonetonaknade.Checked;
            row2["ukljucenoisplata"] = this.checkukljucenoisplata.Checked;
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
            ResourceManager manager = new ResourceManager(typeof(sp_maticni_kartonUserControl));
            this.layoutManagerformsp_maticni_karton = new TableLayoutPanel();
            this.layoutManagerformsp_maticni_karton.SuspendLayout();
            this.layoutManagerformsp_maticni_karton.AutoSize = true;
            this.layoutManagerformsp_maticni_karton.Dock = DockStyle.Fill;
            this.layoutManagerformsp_maticni_karton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformsp_maticni_karton.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformsp_maticni_karton.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformsp_maticni_karton.Size = size;
            this.layoutManagerformsp_maticni_karton.ColumnCount = 2;
            this.layoutManagerformsp_maticni_karton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformsp_maticni_karton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformsp_maticni_karton.RowCount = 15;
            this.layoutManagerformsp_maticni_karton.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_maticni_karton.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_maticni_karton.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_maticni_karton.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_maticni_karton.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_maticni_karton.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_maticni_karton.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_maticni_karton.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_maticni_karton.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_maticni_karton.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_maticni_karton.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_maticni_karton.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_maticni_karton.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_maticni_karton.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_maticni_karton.RowStyles.Add(new RowStyle());
            this.label1godina = new UltraLabel();
            this.textgodina = new UltraTextEditor();
            this.label1idradnik_od = new UltraLabel();
            this.textidradnik_od = new UltraNumericEditor();
            this.label1idradnik_do = new UltraLabel();
            this.textidradnik_do = new UltraNumericEditor();
            this.label1zbirni = new UltraLabel();
            this.checkzbirni = new UltraCheckEditor();
            this.label1ukljucenobruto = new UltraLabel();
            this.checkukljucenobruto = new UltraCheckEditor();
            this.label1ukljucenodoprinosiiz = new UltraLabel();
            this.checkukljucenodoprinosiiz = new UltraCheckEditor();
            this.label1ukljucenodoprinosina = new UltraLabel();
            this.checkukljucenodoprinosina = new UltraCheckEditor();
            this.label1ukljucenoporezi = new UltraLabel();
            this.checkukljucenoporezi = new UltraCheckEditor();
            this.label1ukljucenooo = new UltraLabel();
            this.checkukljucenooo = new UltraCheckEditor();
            this.label1ukljucenoobustave = new UltraLabel();
            this.checkukljucenoobustave = new UltraCheckEditor();
            this.label1ukljucenoolaksice = new UltraLabel();
            this.checkukljucenoolaksice = new UltraCheckEditor();
            this.label1ukljucenonetoplaca = new UltraLabel();
            this.checkukljucenonetoplaca = new UltraCheckEditor();
            this.label1ukljucenonetonaknade = new UltraLabel();
            this.checkukljucenonetonaknade = new UltraCheckEditor();
            this.label1ukljucenoisplata = new UltraLabel();
            this.checkukljucenoisplata = new UltraCheckEditor();
            this.userControlDataGridsp_maticni_karton = new sp_maticni_kartonUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textgodina).BeginInit();
            ((ISupportInitialize) this.textidradnik_od).BeginInit();
            ((ISupportInitialize) this.textidradnik_do).BeginInit();
            this.SuspendLayout();
            this.label1godina.Name = "label1godina";
            this.label1godina.TabIndex = 1;
            this.label1godina.Tag = "labelgodina";
            this.label1godina.AutoSize = true;
            this.label1godina.StyleSetName = "FieldUltraLabel";
            this.label1godina.Text = "godina    :";
            this.label1godina.Appearance.TextVAlign = VAlign.Middle;
            this.label1godina.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1godina.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.label1godina, 0, 0);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.label1godina, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.label1godina, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1godina.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1godina.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textgodina.Location = point;
            this.textgodina.Name = "textgodina";
            this.textgodina.Tag = "godina";
            this.textgodina.TabIndex = 0;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textgodina.Size = size;
            this.textgodina.MaxLength = 4;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.textgodina, 1, 0);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.textgodina, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.textgodina, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textgodina.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textgodina.MinimumSize = size;
            this.label1idradnik_od.Name = "label1idradnik_od";
            this.label1idradnik_od.TabIndex = 1;
            this.label1idradnik_od.Tag = "labelidradnik_od";
            this.label1idradnik_od.AutoSize = true;
            this.label1idradnik_od.StyleSetName = "FieldUltraLabel";
            this.label1idradnik_od.Text = "idradnik od   :";
            this.label1idradnik_od.Appearance.TextVAlign = VAlign.Middle;
            this.label1idradnik_od.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1idradnik_od.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.label1idradnik_od, 0, 1);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.label1idradnik_od, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.label1idradnik_od, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1idradnik_od.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1idradnik_od.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textidradnik_od.Location = point;
            this.textidradnik_od.Name = "textidradnik_od";
            this.textidradnik_od.Tag = "idradnik_od";
            this.textidradnik_od.TabIndex = 1;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textidradnik_od.Size = size;
            this.textidradnik_od.PromptChar = ' ';
            this.textidradnik_od.Enter += new EventHandler(this.numericEditor_Enter);
            this.textidradnik_od.NumericType = NumericType.Integer;
            this.textidradnik_od.MaskInput = "{LOC}-nnnnnnnn";
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.textidradnik_od, 1, 1);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.textidradnik_od, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.textidradnik_od, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textidradnik_od.Margin = padding;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textidradnik_od.MinimumSize = size;
            this.label1idradnik_do.Name = "label1idradnik_do";
            this.label1idradnik_do.TabIndex = 1;
            this.label1idradnik_do.Tag = "labelidradnik_do";
            this.label1idradnik_do.AutoSize = true;
            this.label1idradnik_do.StyleSetName = "FieldUltraLabel";
            this.label1idradnik_do.Text = "idradnik do   :";
            this.label1idradnik_do.Appearance.TextVAlign = VAlign.Middle;
            this.label1idradnik_do.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1idradnik_do.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.label1idradnik_do, 0, 2);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.label1idradnik_do, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.label1idradnik_do, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1idradnik_do.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1idradnik_do.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textidradnik_do.Location = point;
            this.textidradnik_do.Name = "textidradnik_do";
            this.textidradnik_do.Tag = "idradnik_do";
            this.textidradnik_do.TabIndex = 2;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textidradnik_do.Size = size;
            this.textidradnik_do.PromptChar = ' ';
            this.textidradnik_do.Enter += new EventHandler(this.numericEditor_Enter);
            this.textidradnik_do.NumericType = NumericType.Integer;
            this.textidradnik_do.MaskInput = "{LOC}-nnnnnnnn";
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.textidradnik_do, 1, 2);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.textidradnik_do, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.textidradnik_do, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textidradnik_do.Margin = padding;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textidradnik_do.MinimumSize = size;
            this.label1zbirni.Name = "label1zbirni";
            this.label1zbirni.TabIndex = 1;
            this.label1zbirni.Tag = "labelzbirni";
            this.label1zbirni.AutoSize = true;
            this.label1zbirni.StyleSetName = "FieldUltraLabel";
            this.label1zbirni.Text = "zbirni   :";
            this.label1zbirni.Appearance.TextVAlign = VAlign.Middle;
            this.label1zbirni.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1zbirni.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.label1zbirni, 0, 3);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.label1zbirni, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.label1zbirni, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1zbirni.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1zbirni.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.checkzbirni.Location = point;
            this.checkzbirni.Name = "checkzbirni";
            this.checkzbirni.Tag = "zbirni";
            this.checkzbirni.TabIndex = 3;
            size = new System.Drawing.Size(13, 13);
            this.checkzbirni.Size = size;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.checkzbirni, 1, 3);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.checkzbirni, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.checkzbirni, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkzbirni.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkzbirni.MinimumSize = size;
            this.label1ukljucenobruto.Name = "label1ukljucenobruto";
            this.label1ukljucenobruto.TabIndex = 1;
            this.label1ukljucenobruto.Tag = "labelukljucenobruto";
            this.label1ukljucenobruto.AutoSize = true;
            this.label1ukljucenobruto.StyleSetName = "FieldUltraLabel";
            this.label1ukljucenobruto.Text = "ukljucenobruto   :";
            this.label1ukljucenobruto.Appearance.TextVAlign = VAlign.Middle;
            this.label1ukljucenobruto.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ukljucenobruto.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.label1ukljucenobruto, 0, 4);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.label1ukljucenobruto, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.label1ukljucenobruto, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ukljucenobruto.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ukljucenobruto.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.checkukljucenobruto.Location = point;
            this.checkukljucenobruto.Name = "checkukljucenobruto";
            this.checkukljucenobruto.Tag = "ukljucenobruto";
            this.checkukljucenobruto.TabIndex = 4;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenobruto.Size = size;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.checkukljucenobruto, 1, 4);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.checkukljucenobruto, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.checkukljucenobruto, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkukljucenobruto.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenobruto.MinimumSize = size;
            this.label1ukljucenodoprinosiiz.Name = "label1ukljucenodoprinosiiz";
            this.label1ukljucenodoprinosiiz.TabIndex = 1;
            this.label1ukljucenodoprinosiiz.Tag = "labelukljucenodoprinosiiz";
            this.label1ukljucenodoprinosiiz.AutoSize = true;
            this.label1ukljucenodoprinosiiz.StyleSetName = "FieldUltraLabel";
            this.label1ukljucenodoprinosiiz.Text = "ukljucenodoprinosiiz   :";
            this.label1ukljucenodoprinosiiz.Appearance.TextVAlign = VAlign.Middle;
            this.label1ukljucenodoprinosiiz.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ukljucenodoprinosiiz.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.label1ukljucenodoprinosiiz, 0, 5);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.label1ukljucenodoprinosiiz, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.label1ukljucenodoprinosiiz, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ukljucenodoprinosiiz.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ukljucenodoprinosiiz.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.checkukljucenodoprinosiiz.Location = point;
            this.checkukljucenodoprinosiiz.Name = "checkukljucenodoprinosiiz";
            this.checkukljucenodoprinosiiz.Tag = "ukljucenodoprinosiiz";
            this.checkukljucenodoprinosiiz.TabIndex = 5;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenodoprinosiiz.Size = size;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.checkukljucenodoprinosiiz, 1, 5);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.checkukljucenodoprinosiiz, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.checkukljucenodoprinosiiz, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkukljucenodoprinosiiz.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenodoprinosiiz.MinimumSize = size;
            this.label1ukljucenodoprinosina.Name = "label1ukljucenodoprinosina";
            this.label1ukljucenodoprinosina.TabIndex = 1;
            this.label1ukljucenodoprinosina.Tag = "labelukljucenodoprinosina";
            this.label1ukljucenodoprinosina.AutoSize = true;
            this.label1ukljucenodoprinosina.StyleSetName = "FieldUltraLabel";
            this.label1ukljucenodoprinosina.Text = "ukljucenodoprinosina   :";
            this.label1ukljucenodoprinosina.Appearance.TextVAlign = VAlign.Middle;
            this.label1ukljucenodoprinosina.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ukljucenodoprinosina.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.label1ukljucenodoprinosina, 0, 6);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.label1ukljucenodoprinosina, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.label1ukljucenodoprinosina, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ukljucenodoprinosina.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ukljucenodoprinosina.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.checkukljucenodoprinosina.Location = point;
            this.checkukljucenodoprinosina.Name = "checkukljucenodoprinosina";
            this.checkukljucenodoprinosina.Tag = "ukljucenodoprinosina";
            this.checkukljucenodoprinosina.TabIndex = 6;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenodoprinosina.Size = size;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.checkukljucenodoprinosina, 1, 6);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.checkukljucenodoprinosina, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.checkukljucenodoprinosina, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkukljucenodoprinosina.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenodoprinosina.MinimumSize = size;
            this.label1ukljucenoporezi.Name = "label1ukljucenoporezi";
            this.label1ukljucenoporezi.TabIndex = 1;
            this.label1ukljucenoporezi.Tag = "labelukljucenoporezi";
            this.label1ukljucenoporezi.AutoSize = true;
            this.label1ukljucenoporezi.StyleSetName = "FieldUltraLabel";
            this.label1ukljucenoporezi.Text = "ukljucenoporezi   :";
            this.label1ukljucenoporezi.Appearance.TextVAlign = VAlign.Middle;
            this.label1ukljucenoporezi.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ukljucenoporezi.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.label1ukljucenoporezi, 0, 7);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.label1ukljucenoporezi, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.label1ukljucenoporezi, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ukljucenoporezi.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ukljucenoporezi.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.checkukljucenoporezi.Location = point;
            this.checkukljucenoporezi.Name = "checkukljucenoporezi";
            this.checkukljucenoporezi.Tag = "ukljucenoporezi";
            this.checkukljucenoporezi.TabIndex = 7;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenoporezi.Size = size;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.checkukljucenoporezi, 1, 7);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.checkukljucenoporezi, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.checkukljucenoporezi, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkukljucenoporezi.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenoporezi.MinimumSize = size;
            this.label1ukljucenooo.Name = "label1ukljucenooo";
            this.label1ukljucenooo.TabIndex = 1;
            this.label1ukljucenooo.Tag = "labelukljucenooo";
            this.label1ukljucenooo.AutoSize = true;
            this.label1ukljucenooo.StyleSetName = "FieldUltraLabel";
            this.label1ukljucenooo.Text = "ukljucenooo   :";
            this.label1ukljucenooo.Appearance.TextVAlign = VAlign.Middle;
            this.label1ukljucenooo.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ukljucenooo.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.label1ukljucenooo, 0, 8);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.label1ukljucenooo, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.label1ukljucenooo, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ukljucenooo.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ukljucenooo.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.checkukljucenooo.Location = point;
            this.checkukljucenooo.Name = "checkukljucenooo";
            this.checkukljucenooo.Tag = "ukljucenooo";
            this.checkukljucenooo.TabIndex = 8;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenooo.Size = size;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.checkukljucenooo, 1, 8);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.checkukljucenooo, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.checkukljucenooo, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkukljucenooo.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenooo.MinimumSize = size;
            this.label1ukljucenoobustave.Name = "label1ukljucenoobustave";
            this.label1ukljucenoobustave.TabIndex = 1;
            this.label1ukljucenoobustave.Tag = "labelukljucenoobustave";
            this.label1ukljucenoobustave.AutoSize = true;
            this.label1ukljucenoobustave.StyleSetName = "FieldUltraLabel";
            this.label1ukljucenoobustave.Text = "ukljucenoobustave   :";
            this.label1ukljucenoobustave.Appearance.TextVAlign = VAlign.Middle;
            this.label1ukljucenoobustave.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ukljucenoobustave.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.label1ukljucenoobustave, 0, 9);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.label1ukljucenoobustave, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.label1ukljucenoobustave, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ukljucenoobustave.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ukljucenoobustave.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.checkukljucenoobustave.Location = point;
            this.checkukljucenoobustave.Name = "checkukljucenoobustave";
            this.checkukljucenoobustave.Tag = "ukljucenoobustave";
            this.checkukljucenoobustave.TabIndex = 9;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenoobustave.Size = size;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.checkukljucenoobustave, 1, 9);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.checkukljucenoobustave, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.checkukljucenoobustave, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkukljucenoobustave.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenoobustave.MinimumSize = size;
            this.label1ukljucenoolaksice.Name = "label1ukljucenoolaksice";
            this.label1ukljucenoolaksice.TabIndex = 1;
            this.label1ukljucenoolaksice.Tag = "labelukljucenoolaksice";
            this.label1ukljucenoolaksice.AutoSize = true;
            this.label1ukljucenoolaksice.StyleSetName = "FieldUltraLabel";
            this.label1ukljucenoolaksice.Text = "ukljucenoolaksice   :";
            this.label1ukljucenoolaksice.Appearance.TextVAlign = VAlign.Middle;
            this.label1ukljucenoolaksice.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ukljucenoolaksice.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.label1ukljucenoolaksice, 0, 10);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.label1ukljucenoolaksice, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.label1ukljucenoolaksice, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ukljucenoolaksice.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ukljucenoolaksice.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.checkukljucenoolaksice.Location = point;
            this.checkukljucenoolaksice.Name = "checkukljucenoolaksice";
            this.checkukljucenoolaksice.Tag = "ukljucenoolaksice";
            this.checkukljucenoolaksice.TabIndex = 10;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenoolaksice.Size = size;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.checkukljucenoolaksice, 1, 10);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.checkukljucenoolaksice, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.checkukljucenoolaksice, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkukljucenoolaksice.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenoolaksice.MinimumSize = size;
            this.label1ukljucenonetoplaca.Name = "label1ukljucenonetoplaca";
            this.label1ukljucenonetoplaca.TabIndex = 1;
            this.label1ukljucenonetoplaca.Tag = "labelukljucenonetoplaca";
            this.label1ukljucenonetoplaca.AutoSize = true;
            this.label1ukljucenonetoplaca.StyleSetName = "FieldUltraLabel";
            this.label1ukljucenonetoplaca.Text = "ukljucenonetoplaca   :";
            this.label1ukljucenonetoplaca.Appearance.TextVAlign = VAlign.Middle;
            this.label1ukljucenonetoplaca.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ukljucenonetoplaca.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.label1ukljucenonetoplaca, 0, 11);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.label1ukljucenonetoplaca, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.label1ukljucenonetoplaca, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ukljucenonetoplaca.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ukljucenonetoplaca.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.checkukljucenonetoplaca.Location = point;
            this.checkukljucenonetoplaca.Name = "checkukljucenonetoplaca";
            this.checkukljucenonetoplaca.Tag = "ukljucenonetoplaca";
            this.checkukljucenonetoplaca.TabIndex = 11;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenonetoplaca.Size = size;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.checkukljucenonetoplaca, 1, 11);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.checkukljucenonetoplaca, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.checkukljucenonetoplaca, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkukljucenonetoplaca.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenonetoplaca.MinimumSize = size;
            this.label1ukljucenonetonaknade.Name = "label1ukljucenonetonaknade";
            this.label1ukljucenonetonaknade.TabIndex = 1;
            this.label1ukljucenonetonaknade.Tag = "labelukljucenonetonaknade";
            this.label1ukljucenonetonaknade.AutoSize = true;
            this.label1ukljucenonetonaknade.StyleSetName = "FieldUltraLabel";
            this.label1ukljucenonetonaknade.Text = "ukljucenonetonaknade   :";
            this.label1ukljucenonetonaknade.Appearance.TextVAlign = VAlign.Middle;
            this.label1ukljucenonetonaknade.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ukljucenonetonaknade.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.label1ukljucenonetonaknade, 0, 12);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.label1ukljucenonetonaknade, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.label1ukljucenonetonaknade, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ukljucenonetonaknade.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ukljucenonetonaknade.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.checkukljucenonetonaknade.Location = point;
            this.checkukljucenonetonaknade.Name = "checkukljucenonetonaknade";
            this.checkukljucenonetonaknade.Tag = "ukljucenonetonaknade";
            this.checkukljucenonetonaknade.TabIndex = 12;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenonetonaknade.Size = size;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.checkukljucenonetonaknade, 1, 12);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.checkukljucenonetonaknade, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.checkukljucenonetonaknade, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkukljucenonetonaknade.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenonetonaknade.MinimumSize = size;
            this.label1ukljucenoisplata.Name = "label1ukljucenoisplata";
            this.label1ukljucenoisplata.TabIndex = 1;
            this.label1ukljucenoisplata.Tag = "labelukljucenoisplata";
            this.label1ukljucenoisplata.AutoSize = true;
            this.label1ukljucenoisplata.StyleSetName = "FieldUltraLabel";
            this.label1ukljucenoisplata.Text = "ukljucenoisplata   :";
            this.label1ukljucenoisplata.Appearance.TextVAlign = VAlign.Middle;
            this.label1ukljucenoisplata.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ukljucenoisplata.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.label1ukljucenoisplata, 0, 13);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.label1ukljucenoisplata, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.label1ukljucenoisplata, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ukljucenoisplata.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ukljucenoisplata.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.checkukljucenoisplata.Location = point;
            this.checkukljucenoisplata.Name = "checkukljucenoisplata";
            this.checkukljucenoisplata.Tag = "ukljucenoisplata";
            this.checkukljucenoisplata.TabIndex = 13;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenoisplata.Size = size;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.checkukljucenoisplata, 1, 13);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.checkukljucenoisplata, 1);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.checkukljucenoisplata, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkukljucenoisplata.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkukljucenoisplata.MinimumSize = size;
            this.layoutManagerformsp_maticni_karton.Controls.Add(this.userControlDataGridsp_maticni_karton, 0, 14);
            this.layoutManagerformsp_maticni_karton.SetColumnSpan(this.userControlDataGridsp_maticni_karton, 2);
            this.layoutManagerformsp_maticni_karton.SetRowSpan(this.userControlDataGridsp_maticni_karton, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridsp_maticni_karton.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridsp_maticni_karton.MinimumSize = size;
            this.userControlDataGridsp_maticni_karton.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformsp_maticni_karton);
            this.userControlDataGridsp_maticni_karton.Name = "userControlDataGridsp_maticni_karton";
            this.userControlDataGridsp_maticni_karton.Dock = DockStyle.Fill;
            this.userControlDataGridsp_maticni_karton.DockPadding.All = 5;
            this.userControlDataGridsp_maticni_karton.FillAtStartup = false;
            this.userControlDataGridsp_maticni_karton.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridsp_maticni_karton.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridsp_maticni_karton.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridsp_maticni_karton.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "sp_maticni_kartonWorkWith";
            this.Text = "Work With sp_maticni_karton";
            this.Load += new EventHandler(this.sp_maticni_kartonUserControl_Load);
            this.layoutManagerformsp_maticni_karton.ResumeLayout(false);
            this.layoutManagerformsp_maticni_karton.PerformLayout();
            ((ISupportInitialize) this.textgodina).EndInit();
            ((ISupportInitialize) this.textidradnik_od).EndInit();
            ((ISupportInitialize) this.textidradnik_do).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textgodina.Text = "";
            this.textidradnik_od.Text = "0";
            this.textidradnik_do.Text = "0";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("godina") && (this.m_FillByRow["godina"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textgodina, this.m_FillByRow["godina"].ToString(), this.m_FillByRow.Table.Columns["godina"].DataType);
                    this.parameterSeted = true;
                    this.textgodina.Visible = false;
                    this.label1godina.Visible = false;
                    str = str + "," + this.m_FillByRow["godina"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("idradnik_od") && (this.m_FillByRow["idradnik_od"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textidradnik_od, this.m_FillByRow["idradnik_od"].ToString(), this.m_FillByRow.Table.Columns["idradnik_od"].DataType);
                    this.parameterSeted = true;
                    this.textidradnik_od.Visible = false;
                    this.label1idradnik_od.Visible = false;
                    str = str + "," + this.m_FillByRow["idradnik_od"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("idradnik_do") && (this.m_FillByRow["idradnik_do"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textidradnik_do, this.m_FillByRow["idradnik_do"].ToString(), this.m_FillByRow.Table.Columns["idradnik_do"].DataType);
                    this.parameterSeted = true;
                    this.textidradnik_do.Visible = false;
                    this.label1idradnik_do.Visible = false;
                    str = str + "," + this.m_FillByRow["idradnik_do"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("zbirni") && (this.m_FillByRow["zbirni"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.checkzbirni, this.m_FillByRow["zbirni"].ToString(), this.m_FillByRow.Table.Columns["zbirni"].DataType);
                    this.parameterSeted = true;
                    this.checkzbirni.Visible = false;
                    this.label1zbirni.Visible = false;
                    str = str + "," + this.m_FillByRow["zbirni"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("ukljucenobruto") && (this.m_FillByRow["ukljucenobruto"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.checkukljucenobruto, this.m_FillByRow["ukljucenobruto"].ToString(), this.m_FillByRow.Table.Columns["ukljucenobruto"].DataType);
                    this.parameterSeted = true;
                    this.checkukljucenobruto.Visible = false;
                    this.label1ukljucenobruto.Visible = false;
                    str = str + "," + this.m_FillByRow["ukljucenobruto"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("ukljucenodoprinosiiz") && (this.m_FillByRow["ukljucenodoprinosiiz"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.checkukljucenodoprinosiiz, this.m_FillByRow["ukljucenodoprinosiiz"].ToString(), this.m_FillByRow.Table.Columns["ukljucenodoprinosiiz"].DataType);
                    this.parameterSeted = true;
                    this.checkukljucenodoprinosiiz.Visible = false;
                    this.label1ukljucenodoprinosiiz.Visible = false;
                    str = str + "," + this.m_FillByRow["ukljucenodoprinosiiz"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("ukljucenodoprinosina") && (this.m_FillByRow["ukljucenodoprinosina"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.checkukljucenodoprinosina, this.m_FillByRow["ukljucenodoprinosina"].ToString(), this.m_FillByRow.Table.Columns["ukljucenodoprinosina"].DataType);
                    this.parameterSeted = true;
                    this.checkukljucenodoprinosina.Visible = false;
                    this.label1ukljucenodoprinosina.Visible = false;
                    str = str + "," + this.m_FillByRow["ukljucenodoprinosina"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("ukljucenoporezi") && (this.m_FillByRow["ukljucenoporezi"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.checkukljucenoporezi, this.m_FillByRow["ukljucenoporezi"].ToString(), this.m_FillByRow.Table.Columns["ukljucenoporezi"].DataType);
                    this.parameterSeted = true;
                    this.checkukljucenoporezi.Visible = false;
                    this.label1ukljucenoporezi.Visible = false;
                    str = str + "," + this.m_FillByRow["ukljucenoporezi"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("ukljucenooo") && (this.m_FillByRow["ukljucenooo"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.checkukljucenooo, this.m_FillByRow["ukljucenooo"].ToString(), this.m_FillByRow.Table.Columns["ukljucenooo"].DataType);
                    this.parameterSeted = true;
                    this.checkukljucenooo.Visible = false;
                    this.label1ukljucenooo.Visible = false;
                    str = str + "," + this.m_FillByRow["ukljucenooo"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("ukljucenoobustave") && (this.m_FillByRow["ukljucenoobustave"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.checkukljucenoobustave, this.m_FillByRow["ukljucenoobustave"].ToString(), this.m_FillByRow.Table.Columns["ukljucenoobustave"].DataType);
                    this.parameterSeted = true;
                    this.checkukljucenoobustave.Visible = false;
                    this.label1ukljucenoobustave.Visible = false;
                    str = str + "," + this.m_FillByRow["ukljucenoobustave"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("ukljucenoolaksice") && (this.m_FillByRow["ukljucenoolaksice"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.checkukljucenoolaksice, this.m_FillByRow["ukljucenoolaksice"].ToString(), this.m_FillByRow.Table.Columns["ukljucenoolaksice"].DataType);
                    this.parameterSeted = true;
                    this.checkukljucenoolaksice.Visible = false;
                    this.label1ukljucenoolaksice.Visible = false;
                    str = str + "," + this.m_FillByRow["ukljucenoolaksice"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("ukljucenonetoplaca") && (this.m_FillByRow["ukljucenonetoplaca"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.checkukljucenonetoplaca, this.m_FillByRow["ukljucenonetoplaca"].ToString(), this.m_FillByRow.Table.Columns["ukljucenonetoplaca"].DataType);
                    this.parameterSeted = true;
                    this.checkukljucenonetoplaca.Visible = false;
                    this.label1ukljucenonetoplaca.Visible = false;
                    str = str + "," + this.m_FillByRow["ukljucenonetoplaca"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("ukljucenonetonaknade") && (this.m_FillByRow["ukljucenonetonaknade"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.checkukljucenonetonaknade, this.m_FillByRow["ukljucenonetonaknade"].ToString(), this.m_FillByRow.Table.Columns["ukljucenonetonaknade"].DataType);
                    this.parameterSeted = true;
                    this.checkukljucenonetonaknade.Visible = false;
                    this.label1ukljucenonetonaknade.Visible = false;
                    str = str + "," + this.m_FillByRow["ukljucenonetonaknade"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("ukljucenoisplata") && (this.m_FillByRow["ukljucenoisplata"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.checkukljucenoisplata, this.m_FillByRow["ukljucenoisplata"].ToString(), this.m_FillByRow.Table.Columns["ukljucenoisplata"].DataType);
                    this.parameterSeted = true;
                    this.checkukljucenoisplata.Visible = false;
                    this.label1ukljucenoisplata.Visible = false;
                    str = str + "," + this.m_FillByRow["ukljucenoisplata"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "sp_maticni_karton " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "sp_maticni_karton " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridsp_maticni_karton.DataGrid.DataSet.Clear();
                    this.userControlDataGridsp_maticni_karton.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new sp_maticni_kartonDataAdapter().Update(this.userControlDataGridsp_maticni_karton.DataGrid.DataSet);
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
            this.label1godina.Text = StringResources.sp_maticni_kartongodinaParameter;
            this.label1idradnik_od.Text = StringResources.sp_maticni_kartonidradnik_odParameter;
            this.label1idradnik_do.Text = StringResources.sp_maticni_kartonidradnik_doParameter;
            this.label1zbirni.Text = StringResources.sp_maticni_kartonzbirniParameter;
            this.label1ukljucenobruto.Text = StringResources.sp_maticni_kartonukljucenobrutoParameter;
            this.label1ukljucenodoprinosiiz.Text = StringResources.sp_maticni_kartonukljucenodoprinosiizParameter;
            this.label1ukljucenodoprinosina.Text = StringResources.sp_maticni_kartonukljucenodoprinosinaParameter;
            this.label1ukljucenoporezi.Text = StringResources.sp_maticni_kartonukljucenoporeziParameter;
            this.label1ukljucenooo.Text = StringResources.sp_maticni_kartonukljucenoooParameter;
            this.label1ukljucenoobustave.Text = StringResources.sp_maticni_kartonukljucenoobustaveParameter;
            this.label1ukljucenoolaksice.Text = StringResources.sp_maticni_kartonukljucenoolaksiceParameter;
            this.label1ukljucenonetoplaca.Text = StringResources.sp_maticni_kartonukljucenonetoplacaParameter;
            this.label1ukljucenonetonaknade.Text = StringResources.sp_maticni_kartonukljucenonetonaknadeParameter;
            this.label1ukljucenoisplata.Text = StringResources.sp_maticni_kartonukljucenoisplataParameter;
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
                this.userControlDataGridsp_maticni_karton.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridsp_maticni_karton.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} sp_maticni_karton ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} sp_maticni_karton ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void sp_maticni_kartonUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridsp_maticni_karton.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridsp_maticni_karton.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridsp_maticni_karton.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridsp_maticni_karton.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridsp_maticni_karton.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridsp_maticni_karton.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridsp_maticni_karton.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridsp_maticni_karton.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridsp_maticni_karton.DataGrid.FillByPage = true;
                this.FillData();
            }
        }

        protected virtual UltraCheckEditor checkukljucenobruto
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkukljucenobruto;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkukljucenobruto = value;
            }
        }

        protected virtual UltraCheckEditor checkukljucenodoprinosiiz
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkukljucenodoprinosiiz;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkukljucenodoprinosiiz = value;
            }
        }

        protected virtual UltraCheckEditor checkukljucenodoprinosina
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkukljucenodoprinosina;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkukljucenodoprinosina = value;
            }
        }

        protected virtual UltraCheckEditor checkukljucenoisplata
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkukljucenoisplata;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkukljucenoisplata = value;
            }
        }

        protected virtual UltraCheckEditor checkukljucenonetonaknade
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkukljucenonetonaknade;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkukljucenonetonaknade = value;
            }
        }

        protected virtual UltraCheckEditor checkukljucenonetoplaca
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkukljucenonetoplaca;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkukljucenonetoplaca = value;
            }
        }

        protected virtual UltraCheckEditor checkukljucenoobustave
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkukljucenoobustave;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkukljucenoobustave = value;
            }
        }

        protected virtual UltraCheckEditor checkukljucenoolaksice
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkukljucenoolaksice;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkukljucenoolaksice = value;
            }
        }

        protected virtual UltraCheckEditor checkukljucenooo
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkukljucenooo;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkukljucenooo = value;
            }
        }

        protected virtual UltraCheckEditor checkukljucenoporezi
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkukljucenoporezi;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkukljucenoporezi = value;
            }
        }

        protected virtual UltraCheckEditor checkzbirni
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkzbirni;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkzbirni = value;
            }
        }

        [CreateNew]
        public sp_maticni_kartonController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridsp_maticni_karton.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridsp_maticni_karton.DataView[this.userControlDataGridsp_maticni_karton.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1godina
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1godina;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1godina = value;
            }
        }

        protected virtual UltraLabel label1idradnik_do
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1idradnik_do;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1idradnik_do = value;
            }
        }

        protected virtual UltraLabel label1idradnik_od
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1idradnik_od;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1idradnik_od = value;
            }
        }

        protected virtual UltraLabel label1ukljucenobruto
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ukljucenobruto;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ukljucenobruto = value;
            }
        }

        protected virtual UltraLabel label1ukljucenodoprinosiiz
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ukljucenodoprinosiiz;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ukljucenodoprinosiiz = value;
            }
        }

        protected virtual UltraLabel label1ukljucenodoprinosina
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ukljucenodoprinosina;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ukljucenodoprinosina = value;
            }
        }

        protected virtual UltraLabel label1ukljucenoisplata
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ukljucenoisplata;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ukljucenoisplata = value;
            }
        }

        protected virtual UltraLabel label1ukljucenonetonaknade
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ukljucenonetonaknade;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ukljucenonetonaknade = value;
            }
        }

        protected virtual UltraLabel label1ukljucenonetoplaca
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ukljucenonetoplaca;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ukljucenonetoplaca = value;
            }
        }

        protected virtual UltraLabel label1ukljucenoobustave
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ukljucenoobustave;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ukljucenoobustave = value;
            }
        }

        protected virtual UltraLabel label1ukljucenoolaksice
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ukljucenoolaksice;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ukljucenoolaksice = value;
            }
        }

        protected virtual UltraLabel label1ukljucenooo
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ukljucenooo;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ukljucenooo = value;
            }
        }

        protected virtual UltraLabel label1ukljucenoporezi
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ukljucenoporezi;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ukljucenoporezi = value;
            }
        }

        protected virtual UltraLabel label1zbirni
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1zbirni;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1zbirni = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraTextEditor textgodina
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textgodina;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textgodina = value;
            }
        }

        protected virtual UltraNumericEditor textidradnik_do
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textidradnik_do;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textidradnik_do = value;
            }
        }

        protected virtual UltraNumericEditor textidradnik_od
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textidradnik_od;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textidradnik_od = value;
            }
        }

        protected virtual sp_maticni_kartonUserDataGrid userControlDataGridsp_maticni_karton
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridsp_maticni_karton;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridsp_maticni_karton = value;
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

