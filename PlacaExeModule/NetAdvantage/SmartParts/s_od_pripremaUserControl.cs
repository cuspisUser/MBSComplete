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
    public class s_od_pripremaUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1godina")]
        private UltraLabel _label1godina;
        [AccessedThroughProperty("label1id")]
        private UltraLabel _label1id;
        [AccessedThroughProperty("label1mjesec")]
        private UltraLabel _label1mjesec;
        [AccessedThroughProperty("label1vrsta")]
        private UltraLabel _label1vrsta;
        [AccessedThroughProperty("textgodina")]
        private UltraNumericEditor _textgodina;
        [AccessedThroughProperty("textid")]
        private UltraNumericEditor _textid;
        [AccessedThroughProperty("textmjesec")]
        private UltraNumericEditor _textmjesec;
        [AccessedThroughProperty("textvrsta")]
        private UltraTextEditor _textvrsta;
        [AccessedThroughProperty("userControlDataGrids_od_priprema")]
        private s_od_pripremaUserDataGrid _userControlDataGrids_od_priprema;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerforms_od_priprema;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public s_od_pripremaUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.s_od_pripremaDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.s_od_pripremaDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGrids_od_priprema.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<s_od_pripremaDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<s_od_pripremaDataSet>(this.userControlDataGrids_od_priprema.DataGrid);
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
            if ((this.userControlDataGrids_od_priprema.DataGrid.Rows.Count > 0) && (this.userControlDataGrids_od_priprema.DataGrid.Rows[0] != null))
            {
                this.userControlDataGrids_od_priprema.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGrids_od_priprema.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGrids_od_priprema.DataGrid.FillByPage;
                this.userControlDataGrids_od_priprema.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGrids_od_priprema.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGrids_od_priprema.Parametergodina = int.Parse(this.textgodina.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGrids_od_priprema.Parameterid = int.Parse(this.textid.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGrids_od_priprema.Parametermjesec = int.Parse(this.textmjesec.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGrids_od_priprema.Parametervrsta = this.textvrsta.Text;
                this.userControlDataGrids_od_priprema.Fill();
                ((s_od_pripremaWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGrids_od_priprema.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("godina", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("id", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("mjesec", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("vrsta", typeof(string));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["godina"] = int.Parse(this.textgodina.Value.ToString(), CultureInfo.CurrentCulture);
            row2["id"] = int.Parse(this.textid.Value.ToString(), CultureInfo.CurrentCulture);
            row2["mjesec"] = int.Parse(this.textmjesec.Value.ToString(), CultureInfo.CurrentCulture);
            row2["vrsta"] = this.textvrsta.Text;
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
            ResourceManager manager = new ResourceManager(typeof(s_od_pripremaUserControl));
            this.layoutManagerforms_od_priprema = new TableLayoutPanel();
            this.layoutManagerforms_od_priprema.SuspendLayout();
            this.layoutManagerforms_od_priprema.AutoSize = true;
            this.layoutManagerforms_od_priprema.Dock = DockStyle.Fill;
            this.layoutManagerforms_od_priprema.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerforms_od_priprema.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerforms_od_priprema.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerforms_od_priprema.Size = size;
            this.layoutManagerforms_od_priprema.ColumnCount = 2;
            this.layoutManagerforms_od_priprema.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerforms_od_priprema.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerforms_od_priprema.RowCount = 5;
            this.layoutManagerforms_od_priprema.RowStyles.Add(new RowStyle());
            this.layoutManagerforms_od_priprema.RowStyles.Add(new RowStyle());
            this.layoutManagerforms_od_priprema.RowStyles.Add(new RowStyle());
            this.layoutManagerforms_od_priprema.RowStyles.Add(new RowStyle());
            this.layoutManagerforms_od_priprema.RowStyles.Add(new RowStyle());
            this.label1godina = new UltraLabel();
            this.textgodina = new UltraNumericEditor();
            this.label1id = new UltraLabel();
            this.textid = new UltraNumericEditor();
            this.label1mjesec = new UltraLabel();
            this.textmjesec = new UltraNumericEditor();
            this.label1vrsta = new UltraLabel();
            this.textvrsta = new UltraTextEditor();
            this.userControlDataGrids_od_priprema = new s_od_pripremaUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textgodina).BeginInit();
            ((ISupportInitialize) this.textid).BeginInit();
            ((ISupportInitialize) this.textmjesec).BeginInit();
            ((ISupportInitialize) this.textvrsta).BeginInit();
            this.SuspendLayout();
            this.label1godina.Name = "label1godina";
            this.label1godina.TabIndex = 1;
            this.label1godina.Tag = "labelgodina";
            this.label1godina.AutoSize = true;
            this.label1godina.StyleSetName = "FieldUltraLabel";
            this.label1godina.Text = "godina             :";
            this.label1godina.Appearance.TextVAlign = VAlign.Middle;
            this.label1godina.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1godina.Appearance.ForeColor = Color.Black;
            this.layoutManagerforms_od_priprema.Controls.Add(this.label1godina, 0, 0);
            this.layoutManagerforms_od_priprema.SetColumnSpan(this.label1godina, 1);
            this.layoutManagerforms_od_priprema.SetRowSpan(this.label1godina, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1godina.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1godina.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textgodina.Location = point;
            this.textgodina.Name = "textgodina";
            this.textgodina.Tag = "godina";
            this.textgodina.TabIndex = 0;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textgodina.Size = size;
            this.textgodina.PromptChar = ' ';
            this.textgodina.Enter += new EventHandler(this.numericEditor_Enter);
            this.textgodina.NumericType = NumericType.Integer;
            this.textgodina.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerforms_od_priprema.Controls.Add(this.textgodina, 1, 0);
            this.layoutManagerforms_od_priprema.SetColumnSpan(this.textgodina, 1);
            this.layoutManagerforms_od_priprema.SetRowSpan(this.textgodina, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textgodina.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textgodina.MinimumSize = size;
            this.label1id.Name = "label1id";
            this.label1id.TabIndex = 1;
            this.label1id.Tag = "labelid";
            this.label1id.AutoSize = true;
            this.label1id.StyleSetName = "FieldUltraLabel";
            this.label1id.Text = "id             :";
            this.label1id.Appearance.TextVAlign = VAlign.Middle;
            this.label1id.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1id.Appearance.ForeColor = Color.Black;
            this.layoutManagerforms_od_priprema.Controls.Add(this.label1id, 0, 1);
            this.layoutManagerforms_od_priprema.SetColumnSpan(this.label1id, 1);
            this.layoutManagerforms_od_priprema.SetRowSpan(this.label1id, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1id.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1id.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textid.Location = point;
            this.textid.Name = "textid";
            this.textid.Tag = "id";
            this.textid.TabIndex = 1;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textid.Size = size;
            this.textid.PromptChar = ' ';
            this.textid.Enter += new EventHandler(this.numericEditor_Enter);
            this.textid.NumericType = NumericType.Integer;
            this.textid.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerforms_od_priprema.Controls.Add(this.textid, 1, 1);
            this.layoutManagerforms_od_priprema.SetColumnSpan(this.textid, 1);
            this.layoutManagerforms_od_priprema.SetRowSpan(this.textid, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textid.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textid.MinimumSize = size;
            this.label1mjesec.Name = "label1mjesec";
            this.label1mjesec.TabIndex = 1;
            this.label1mjesec.Tag = "labelmjesec";
            this.label1mjesec.AutoSize = true;
            this.label1mjesec.StyleSetName = "FieldUltraLabel";
            this.label1mjesec.Text = "mjesec             :";
            this.label1mjesec.Appearance.TextVAlign = VAlign.Middle;
            this.label1mjesec.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1mjesec.Appearance.ForeColor = Color.Black;
            this.layoutManagerforms_od_priprema.Controls.Add(this.label1mjesec, 0, 2);
            this.layoutManagerforms_od_priprema.SetColumnSpan(this.label1mjesec, 1);
            this.layoutManagerforms_od_priprema.SetRowSpan(this.label1mjesec, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1mjesec.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1mjesec.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textmjesec.Location = point;
            this.textmjesec.Name = "textmjesec";
            this.textmjesec.Tag = "mjesec";
            this.textmjesec.TabIndex = 2;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textmjesec.Size = size;
            this.textmjesec.PromptChar = ' ';
            this.textmjesec.Enter += new EventHandler(this.numericEditor_Enter);
            this.textmjesec.NumericType = NumericType.Integer;
            this.textmjesec.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerforms_od_priprema.Controls.Add(this.textmjesec, 1, 2);
            this.layoutManagerforms_od_priprema.SetColumnSpan(this.textmjesec, 1);
            this.layoutManagerforms_od_priprema.SetRowSpan(this.textmjesec, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textmjesec.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textmjesec.MinimumSize = size;
            this.label1vrsta.Name = "label1vrsta";
            this.label1vrsta.TabIndex = 1;
            this.label1vrsta.Tag = "labelvrsta";
            this.label1vrsta.AutoSize = true;
            this.label1vrsta.StyleSetName = "FieldUltraLabel";
            this.label1vrsta.Text = "vrsta     :";
            this.label1vrsta.Appearance.TextVAlign = VAlign.Middle;
            this.label1vrsta.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1vrsta.Appearance.ForeColor = Color.Black;
            this.layoutManagerforms_od_priprema.Controls.Add(this.label1vrsta, 0, 3);
            this.layoutManagerforms_od_priprema.SetColumnSpan(this.label1vrsta, 1);
            this.layoutManagerforms_od_priprema.SetRowSpan(this.label1vrsta, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1vrsta.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1vrsta.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textvrsta.Location = point;
            this.textvrsta.Name = "textvrsta";
            this.textvrsta.Tag = "vrsta";
            this.textvrsta.TabIndex = 3;
            size = new System.Drawing.Size(0x240, 110);
            this.textvrsta.Size = size;
            this.textvrsta.MaxLength = 500;
            this.textvrsta.Multiline = true;
            this.layoutManagerforms_od_priprema.Controls.Add(this.textvrsta, 1, 3);
            this.layoutManagerforms_od_priprema.SetColumnSpan(this.textvrsta, 1);
            this.layoutManagerforms_od_priprema.SetRowSpan(this.textvrsta, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textvrsta.Margin = padding;
            size = new System.Drawing.Size(0x240, 110);
            this.textvrsta.MinimumSize = size;
            this.textvrsta.Dock = DockStyle.Fill;
            this.layoutManagerforms_od_priprema.Controls.Add(this.userControlDataGrids_od_priprema, 0, 4);
            this.layoutManagerforms_od_priprema.SetColumnSpan(this.userControlDataGrids_od_priprema, 2);
            this.layoutManagerforms_od_priprema.SetRowSpan(this.userControlDataGrids_od_priprema, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGrids_od_priprema.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGrids_od_priprema.MinimumSize = size;
            this.userControlDataGrids_od_priprema.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerforms_od_priprema);
            this.userControlDataGrids_od_priprema.Name = "userControlDataGrids_od_priprema";
            this.userControlDataGrids_od_priprema.Dock = DockStyle.Fill;
            this.userControlDataGrids_od_priprema.DockPadding.All = 5;
            this.userControlDataGrids_od_priprema.FillAtStartup = false;
            this.userControlDataGrids_od_priprema.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGrids_od_priprema.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGrids_od_priprema.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGrids_od_priprema.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "s_od_pripremaWorkWith";
            this.Text = "Work With s_od_priprema";
            this.Load += new EventHandler(this.s_od_pripremaUserControl_Load);
            this.layoutManagerforms_od_priprema.ResumeLayout(false);
            this.layoutManagerforms_od_priprema.PerformLayout();
            ((ISupportInitialize) this.textgodina).EndInit();
            ((ISupportInitialize) this.textid).EndInit();
            ((ISupportInitialize) this.textmjesec).EndInit();
            ((ISupportInitialize) this.textvrsta).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textgodina.Text = "0";
            this.textid.Text = "0";
            this.textmjesec.Text = "0";
            this.textvrsta.Text = "";
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
                if (this.m_FillByRow.Table.Columns.Contains("id") && (this.m_FillByRow["id"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textid, this.m_FillByRow["id"].ToString(), this.m_FillByRow.Table.Columns["id"].DataType);
                    this.parameterSeted = true;
                    this.textid.Visible = false;
                    this.label1id.Visible = false;
                    str = str + "," + this.m_FillByRow["id"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("mjesec") && (this.m_FillByRow["mjesec"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textmjesec, this.m_FillByRow["mjesec"].ToString(), this.m_FillByRow.Table.Columns["mjesec"].DataType);
                    this.parameterSeted = true;
                    this.textmjesec.Visible = false;
                    this.label1mjesec.Visible = false;
                    str = str + "," + this.m_FillByRow["mjesec"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("vrsta") && (this.m_FillByRow["vrsta"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textvrsta, this.m_FillByRow["vrsta"].ToString(), this.m_FillByRow.Table.Columns["vrsta"].DataType);
                    this.parameterSeted = true;
                    this.textvrsta.Visible = false;
                    this.label1vrsta.Visible = false;
                    str = str + "," + this.m_FillByRow["vrsta"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "s_od_priprema " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "s_od_priprema " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGrids_od_priprema.DataGrid.DataSet.Clear();
                    this.userControlDataGrids_od_priprema.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new s_od_pripremaDataAdapter().Update(this.userControlDataGrids_od_priprema.DataGrid.DataSet);
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
            this.label1godina.Text = StringResources.s_od_pripremagodinaParameter;
            this.label1id.Text = StringResources.s_od_pripremaidParameter;
            this.label1mjesec.Text = StringResources.s_od_pripremamjesecParameter;
            this.label1vrsta.Text = StringResources.s_od_pripremavrstaParameter;
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

        private void s_od_pripremaUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGrids_od_priprema.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGrids_od_priprema.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGrids_od_priprema.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGrids_od_priprema.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGrids_od_priprema.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGrids_od_priprema.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGrids_od_priprema.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGrids_od_priprema.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGrids_od_priprema.DataGrid.FillByPage = true;
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
                this.userControlDataGrids_od_priprema.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGrids_od_priprema.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} s_od_priprema ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} s_od_priprema ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public s_od_pripremaController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGrids_od_priprema.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGrids_od_priprema.DataView[this.userControlDataGrids_od_priprema.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1id
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1id;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1id = value;
            }
        }

        protected virtual UltraLabel label1mjesec
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1mjesec;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1mjesec = value;
            }
        }

        protected virtual UltraLabel label1vrsta
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1vrsta;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1vrsta = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraNumericEditor textgodina
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

        protected virtual UltraNumericEditor textid
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textid;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textid = value;
            }
        }

        protected virtual UltraNumericEditor textmjesec
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textmjesec;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textmjesec = value;
            }
        }

        protected virtual UltraTextEditor textvrsta
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textvrsta;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textvrsta = value;
            }
        }

        protected virtual s_od_pripremaUserDataGrid userControlDataGrids_od_priprema
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGrids_od_priprema;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGrids_od_priprema = value;
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

