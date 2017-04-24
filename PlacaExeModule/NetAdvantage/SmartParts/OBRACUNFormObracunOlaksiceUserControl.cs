namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class OBRACUNFormObracunOlaksiceUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDGRUPEOLAKSICA")]
        private UltraLabel _label1IDGRUPEOLAKSICA;
        [AccessedThroughProperty("label1IDOLAKSICE")]
        private UltraLabel _label1IDOLAKSICE;
        [AccessedThroughProperty("label1IDTIPOLAKSICE")]
        private UltraLabel _label1IDTIPOLAKSICE;
        [AccessedThroughProperty("label1IZNOSOLAKSICE")]
        private UltraLabel _label1IZNOSOLAKSICE;
        [AccessedThroughProperty("label1MAXIMALNIIZNOSGRUPE")]
        private UltraLabel _label1MAXIMALNIIZNOSGRUPE;
        [AccessedThroughProperty("label1MOOLAKSICA")]
        private UltraLabel _label1MOOLAKSICA;
        [AccessedThroughProperty("label1MZOLAKSICA")]
        private UltraLabel _label1MZOLAKSICA;
        [AccessedThroughProperty("label1NAZIVGRUPEOLAKSICA")]
        private UltraLabel _label1NAZIVGRUPEOLAKSICA;
        [AccessedThroughProperty("label1NAZIVOLAKSICE")]
        private UltraLabel _label1NAZIVOLAKSICE;
        [AccessedThroughProperty("label1NAZIVTIPOLAKSICE")]
        private UltraLabel _label1NAZIVTIPOLAKSICE;
        [AccessedThroughProperty("label1OBRACUNATAOLAKSICA")]
        private UltraLabel _label1OBRACUNATAOLAKSICA;
        [AccessedThroughProperty("label1OPISPLACANJAOLAKSICA")]
        private UltraLabel _label1OPISPLACANJAOLAKSICA;
        [AccessedThroughProperty("label1POOLAKSICA")]
        private UltraLabel _label1POOLAKSICA;
        [AccessedThroughProperty("label1PRIMATELJOLAKSICA1")]
        private UltraLabel _label1PRIMATELJOLAKSICA1;
        [AccessedThroughProperty("label1PRIMATELJOLAKSICA2")]
        private UltraLabel _label1PRIMATELJOLAKSICA2;
        [AccessedThroughProperty("label1PRIMATELJOLAKSICA3")]
        private UltraLabel _label1PRIMATELJOLAKSICA3;
        [AccessedThroughProperty("label1PZOLAKSICA")]
        private UltraLabel _label1PZOLAKSICA;
        [AccessedThroughProperty("label1SIFRAOPISAPLACANJAOLAKSICA")]
        private UltraLabel _label1SIFRAOPISAPLACANJAOLAKSICA;
        [AccessedThroughProperty("label1VBDIOLAKSICA")]
        private UltraLabel _label1VBDIOLAKSICA;
        [AccessedThroughProperty("label1ZRNOLAKSICA")]
        private UltraLabel _label1ZRNOLAKSICA;
        [AccessedThroughProperty("labelIDGRUPEOLAKSICA")]
        private UltraLabel _labelIDGRUPEOLAKSICA;
        [AccessedThroughProperty("labelIDTIPOLAKSICE")]
        private UltraLabel _labelIDTIPOLAKSICE;
        [AccessedThroughProperty("labelMAXIMALNIIZNOSGRUPE")]
        private UltraLabel _labelMAXIMALNIIZNOSGRUPE;
        [AccessedThroughProperty("labelNAZIVGRUPEOLAKSICA")]
        private UltraLabel _labelNAZIVGRUPEOLAKSICA;
        [AccessedThroughProperty("labelNAZIVOLAKSICE")]
        private UltraLabel _labelNAZIVOLAKSICE;
        [AccessedThroughProperty("labelNAZIVTIPOLAKSICE")]
        private UltraLabel _labelNAZIVTIPOLAKSICE;
        [AccessedThroughProperty("labelPRIMATELJOLAKSICA1")]
        private UltraLabel _labelPRIMATELJOLAKSICA1;
        [AccessedThroughProperty("labelPRIMATELJOLAKSICA2")]
        private UltraLabel _labelPRIMATELJOLAKSICA2;
        [AccessedThroughProperty("labelPRIMATELJOLAKSICA3")]
        private UltraLabel _labelPRIMATELJOLAKSICA3;
        [AccessedThroughProperty("labelVBDIOLAKSICA")]
        private UltraLabel _labelVBDIOLAKSICA;
        [AccessedThroughProperty("labelZRNOLAKSICA")]
        private UltraLabel _labelZRNOLAKSICA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDOLAKSICE")]
        private UltraNumericEditor _textIDOLAKSICE;
        [AccessedThroughProperty("textIZNOSOLAKSICE")]
        private UltraNumericEditor _textIZNOSOLAKSICE;
        [AccessedThroughProperty("textMOOLAKSICA")]
        private UltraTextEditor _textMOOLAKSICA;
        [AccessedThroughProperty("textMZOLAKSICA")]
        private UltraTextEditor _textMZOLAKSICA;
        [AccessedThroughProperty("textOBRACUNATAOLAKSICA")]
        private UltraNumericEditor _textOBRACUNATAOLAKSICA;
        [AccessedThroughProperty("textOPISPLACANJAOLAKSICA")]
        private UltraTextEditor _textOPISPLACANJAOLAKSICA;
        [AccessedThroughProperty("textPOOLAKSICA")]
        private UltraTextEditor _textPOOLAKSICA;
        [AccessedThroughProperty("textPZOLAKSICA")]
        private UltraTextEditor _textPZOLAKSICA;
        [AccessedThroughProperty("textSIFRAOPISAPLACANJAOLAKSICA")]
        private UltraTextEditor _textSIFRAOPISAPLACANJAOLAKSICA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceObracunOlaksice;
        private IContainer components = null;
        private OBRACUNDataSet dsOBRACUNDataSet1;
        protected TableLayoutPanel layoutManagerformObracunOlaksice;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OBRACUNDataSet.ObracunOlaksiceRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "ObracunOlaksice";
        private string m_FrameworkDescription = StringResources.OBRACUNDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        public OBRACUNFormObracunOlaksiceUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("ObracunOlaksiceAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("ObracunOlaksiceAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (OBRACUNDataSet.ObracunOlaksiceRow) ((DataRowView) this.bindingSourceObracunOlaksice.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CallPromptOLAKSICEIDOLAKSICE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.OBRACUNController.SelectOLAKSICEIDOLAKSICE(fillMethod, fillByRow);
            this.UpdateValuesOLAKSICEIDOLAKSICE(result);
        }

        private void CallViewOLAKSICEIDOLAKSICE(object sender, EventArgs e)
        {
            DataRow result = this.OBRACUNController.ShowOLAKSICEIDOLAKSICE(this.m_CurrentRow);
            this.UpdateValuesOLAKSICEIDOLAKSICE(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsOBRACUNDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceObracunOlaksice.DataSource = this.OBRACUNController.DataSet;
            this.dsOBRACUNDataSet1 = this.OBRACUNController.DataSet;
        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            this.m_BaseMethods.ContextMenu1PopupBase(this.contextMenu1, this.m_CurrentRow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EndEditCurrentRow()
        {
        }

        public void Initialize(DeklaritMode mode, DataRow parentRow, bool isCopy)
        {
            this.m_ParentRow = parentRow;
            this.dsOBRACUNDataSet1 = (OBRACUNDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceObracunOlaksice.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsOBRACUNDataSet1.Tables["ObracunOlaksice"]);
            this.bindingSourceObracunOlaksice.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OBRACUN", this.m_Mode, this.dsOBRACUNDataSet1, this.dsOBRACUNDataSet1.ObracunOlaksice.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceObracunOlaksice, "MAXIMALNIIZNOSGRUPE", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelMAXIMALNIIZNOSGRUPE.DataBindings["Text"] != null)
            {
                this.labelMAXIMALNIIZNOSGRUPE.DataBindings.Remove(this.labelMAXIMALNIIZNOSGRUPE.DataBindings["Text"]);
            }
            this.labelMAXIMALNIIZNOSGRUPE.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (OBRACUNDataSet.ObracunOlaksiceRow) ((DataRowView) this.bindingSourceObracunOlaksice.Current).Row;
                this.textIDOLAKSICE.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textIDOLAKSICE.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (OBRACUNDataSet.ObracunOlaksiceRow) ((DataRowView) this.bindingSourceObracunOlaksice.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(OBRACUNFormObracunOlaksiceUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceObracunOlaksice = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceObracunOlaksice).BeginInit();
            this.layoutManagerformObracunOlaksice = new TableLayoutPanel();
            this.layoutManagerformObracunOlaksice.SuspendLayout();
            this.layoutManagerformObracunOlaksice.AutoSize = true;
            this.layoutManagerformObracunOlaksice.Dock = DockStyle.Fill;
            this.layoutManagerformObracunOlaksice.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformObracunOlaksice.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformObracunOlaksice.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformObracunOlaksice.Size = size;
            this.layoutManagerformObracunOlaksice.ColumnCount = 2;
            this.layoutManagerformObracunOlaksice.RowCount = 0x15;
            this.layoutManagerformObracunOlaksice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformObracunOlaksice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.layoutManagerformObracunOlaksice.RowStyles.Add(new RowStyle());
            this.label1IDOLAKSICE = new UltraLabel();
            this.textIDOLAKSICE = new UltraNumericEditor();
            this.label1NAZIVOLAKSICE = new UltraLabel();
            this.labelNAZIVOLAKSICE = new UltraLabel();
            this.label1IDGRUPEOLAKSICA = new UltraLabel();
            this.labelIDGRUPEOLAKSICA = new UltraLabel();
            this.label1NAZIVGRUPEOLAKSICA = new UltraLabel();
            this.labelNAZIVGRUPEOLAKSICA = new UltraLabel();
            this.label1MAXIMALNIIZNOSGRUPE = new UltraLabel();
            this.labelMAXIMALNIIZNOSGRUPE = new UltraLabel();
            this.label1IDTIPOLAKSICE = new UltraLabel();
            this.labelIDTIPOLAKSICE = new UltraLabel();
            this.label1NAZIVTIPOLAKSICE = new UltraLabel();
            this.labelNAZIVTIPOLAKSICE = new UltraLabel();
            this.label1VBDIOLAKSICA = new UltraLabel();
            this.labelVBDIOLAKSICA = new UltraLabel();
            this.label1ZRNOLAKSICA = new UltraLabel();
            this.labelZRNOLAKSICA = new UltraLabel();
            this.label1PRIMATELJOLAKSICA1 = new UltraLabel();
            this.labelPRIMATELJOLAKSICA1 = new UltraLabel();
            this.label1PRIMATELJOLAKSICA2 = new UltraLabel();
            this.labelPRIMATELJOLAKSICA2 = new UltraLabel();
            this.label1PRIMATELJOLAKSICA3 = new UltraLabel();
            this.labelPRIMATELJOLAKSICA3 = new UltraLabel();
            this.label1MZOLAKSICA = new UltraLabel();
            this.textMZOLAKSICA = new UltraTextEditor();
            this.label1PZOLAKSICA = new UltraLabel();
            this.textPZOLAKSICA = new UltraTextEditor();
            this.label1MOOLAKSICA = new UltraLabel();
            this.textMOOLAKSICA = new UltraTextEditor();
            this.label1POOLAKSICA = new UltraLabel();
            this.textPOOLAKSICA = new UltraTextEditor();
            this.label1SIFRAOPISAPLACANJAOLAKSICA = new UltraLabel();
            this.textSIFRAOPISAPLACANJAOLAKSICA = new UltraTextEditor();
            this.label1OPISPLACANJAOLAKSICA = new UltraLabel();
            this.textOPISPLACANJAOLAKSICA = new UltraTextEditor();
            this.label1IZNOSOLAKSICE = new UltraLabel();
            this.textIZNOSOLAKSICE = new UltraNumericEditor();
            this.label1OBRACUNATAOLAKSICA = new UltraLabel();
            this.textOBRACUNATAOLAKSICA = new UltraNumericEditor();
            ((ISupportInitialize) this.textIDOLAKSICE).BeginInit();
            ((ISupportInitialize) this.textMZOLAKSICA).BeginInit();
            ((ISupportInitialize) this.textPZOLAKSICA).BeginInit();
            ((ISupportInitialize) this.textMOOLAKSICA).BeginInit();
            ((ISupportInitialize) this.textPOOLAKSICA).BeginInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJAOLAKSICA).BeginInit();
            ((ISupportInitialize) this.textOPISPLACANJAOLAKSICA).BeginInit();
            ((ISupportInitialize) this.textIZNOSOLAKSICE).BeginInit();
            ((ISupportInitialize) this.textOBRACUNATAOLAKSICA).BeginInit();
            this.dsOBRACUNDataSet1 = new OBRACUNDataSet();
            this.dsOBRACUNDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsOBRACUNDataSet1.DataSetName = "dsOBRACUN";
            this.dsOBRACUNDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceObracunOlaksice.DataSource = this.dsOBRACUNDataSet1;
            this.bindingSourceObracunOlaksice.DataMember = "ObracunOlaksice";
            ((ISupportInitialize) this.bindingSourceObracunOlaksice).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDOLAKSICE.Location = point;
            this.label1IDOLAKSICE.Name = "label1IDOLAKSICE";
            this.label1IDOLAKSICE.TabIndex = 1;
            this.label1IDOLAKSICE.Tag = "labelIDOLAKSICE";
            this.label1IDOLAKSICE.Text = "Šifra olakšice:";
            this.label1IDOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1IDOLAKSICE.AutoSize = true;
            this.label1IDOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1IDOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOLAKSICE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDOLAKSICE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDOLAKSICE.ImageSize = size;
            this.label1IDOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1IDOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1IDOLAKSICE, 0, 0);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1IDOLAKSICE, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1IDOLAKSICE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x63, 0x17);
            this.label1IDOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDOLAKSICE.Location = point;
            this.textIDOLAKSICE.Name = "textIDOLAKSICE";
            this.textIDOLAKSICE.Tag = "IDOLAKSICE";
            this.textIDOLAKSICE.TabIndex = 0;
            this.textIDOLAKSICE.Anchor = AnchorStyles.Left;
            this.textIDOLAKSICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDOLAKSICE.ReadOnly = false;
            this.textIDOLAKSICE.PromptChar = ' ';
            this.textIDOLAKSICE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDOLAKSICE.DataBindings.Add(new Binding("Value", this.bindingSourceObracunOlaksice, "IDOLAKSICE"));
            this.textIDOLAKSICE.NumericType = NumericType.Integer;
            this.textIDOLAKSICE.MaskInput = "{LOC}-nnnnnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonOLAKSICEIDOLAKSICE",
                Tag = "editorButtonOLAKSICEIDOLAKSICE",
                Text = "..."
            };
            this.textIDOLAKSICE.ButtonsRight.Add(button);
            this.textIDOLAKSICE.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOLAKSICEIDOLAKSICE);
            this.layoutManagerformObracunOlaksice.Controls.Add(this.textIDOLAKSICE, 1, 0);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.textIDOLAKSICE, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.textIDOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textIDOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textIDOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVOLAKSICE.Location = point;
            this.label1NAZIVOLAKSICE.Name = "label1NAZIVOLAKSICE";
            this.label1NAZIVOLAKSICE.TabIndex = 1;
            this.label1NAZIVOLAKSICE.Tag = "labelNAZIVOLAKSICE";
            this.label1NAZIVOLAKSICE.Text = "Naziv olakšice:";
            this.label1NAZIVOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVOLAKSICE.AutoSize = true;
            this.label1NAZIVOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1NAZIVOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1NAZIVOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1NAZIVOLAKSICE, 0, 1);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1NAZIVOLAKSICE, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1NAZIVOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x17);
            this.label1NAZIVOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVOLAKSICE.Location = point;
            this.labelNAZIVOLAKSICE.Name = "labelNAZIVOLAKSICE";
            this.labelNAZIVOLAKSICE.Tag = "NAZIVOLAKSICE";
            this.labelNAZIVOLAKSICE.TabIndex = 0;
            this.labelNAZIVOLAKSICE.Anchor = AnchorStyles.Left;
            this.labelNAZIVOLAKSICE.BackColor = Color.Transparent;
            this.labelNAZIVOLAKSICE.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "NAZIVOLAKSICE"));
            this.labelNAZIVOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.labelNAZIVOLAKSICE, 1, 1);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.labelNAZIVOLAKSICE, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.labelNAZIVOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDGRUPEOLAKSICA.Location = point;
            this.label1IDGRUPEOLAKSICA.Name = "label1IDGRUPEOLAKSICA";
            this.label1IDGRUPEOLAKSICA.TabIndex = 1;
            this.label1IDGRUPEOLAKSICA.Tag = "labelIDGRUPEOLAKSICA";
            this.label1IDGRUPEOLAKSICA.Text = "Šifra grupe olakšica:";
            this.label1IDGRUPEOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1IDGRUPEOLAKSICA.AutoSize = true;
            this.label1IDGRUPEOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1IDGRUPEOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDGRUPEOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1IDGRUPEOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1IDGRUPEOLAKSICA, 0, 2);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1IDGRUPEOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1IDGRUPEOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDGRUPEOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDGRUPEOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x8e, 0x17);
            this.label1IDGRUPEOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelIDGRUPEOLAKSICA.Location = point;
            this.labelIDGRUPEOLAKSICA.Name = "labelIDGRUPEOLAKSICA";
            this.labelIDGRUPEOLAKSICA.Tag = "IDGRUPEOLAKSICA";
            this.labelIDGRUPEOLAKSICA.TabIndex = 0;
            this.labelIDGRUPEOLAKSICA.Anchor = AnchorStyles.Left;
            this.labelIDGRUPEOLAKSICA.BackColor = Color.Transparent;
            this.labelIDGRUPEOLAKSICA.Appearance.TextHAlign = HAlign.Left;
            this.labelIDGRUPEOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "IDGRUPEOLAKSICA"));
            this.labelIDGRUPEOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.labelIDGRUPEOLAKSICA, 1, 2);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.labelIDGRUPEOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.labelIDGRUPEOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelIDGRUPEOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.labelIDGRUPEOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.labelIDGRUPEOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVGRUPEOLAKSICA.Location = point;
            this.label1NAZIVGRUPEOLAKSICA.Name = "label1NAZIVGRUPEOLAKSICA";
            this.label1NAZIVGRUPEOLAKSICA.TabIndex = 1;
            this.label1NAZIVGRUPEOLAKSICA.Tag = "labelNAZIVGRUPEOLAKSICA";
            this.label1NAZIVGRUPEOLAKSICA.Text = "Naziv grupe olakšice:";
            this.label1NAZIVGRUPEOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVGRUPEOLAKSICA.AutoSize = true;
            this.label1NAZIVGRUPEOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1NAZIVGRUPEOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVGRUPEOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVGRUPEOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1NAZIVGRUPEOLAKSICA, 0, 3);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1NAZIVGRUPEOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1NAZIVGRUPEOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVGRUPEOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVGRUPEOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x93, 0x17);
            this.label1NAZIVGRUPEOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVGRUPEOLAKSICA.Location = point;
            this.labelNAZIVGRUPEOLAKSICA.Name = "labelNAZIVGRUPEOLAKSICA";
            this.labelNAZIVGRUPEOLAKSICA.Tag = "NAZIVGRUPEOLAKSICA";
            this.labelNAZIVGRUPEOLAKSICA.TabIndex = 0;
            this.labelNAZIVGRUPEOLAKSICA.Anchor = AnchorStyles.Left;
            this.labelNAZIVGRUPEOLAKSICA.BackColor = Color.Transparent;
            this.labelNAZIVGRUPEOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "NAZIVGRUPEOLAKSICA"));
            this.labelNAZIVGRUPEOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.labelNAZIVGRUPEOLAKSICA, 1, 3);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.labelNAZIVGRUPEOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.labelNAZIVGRUPEOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVGRUPEOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVGRUPEOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVGRUPEOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MAXIMALNIIZNOSGRUPE.Location = point;
            this.label1MAXIMALNIIZNOSGRUPE.Name = "label1MAXIMALNIIZNOSGRUPE";
            this.label1MAXIMALNIIZNOSGRUPE.TabIndex = 1;
            this.label1MAXIMALNIIZNOSGRUPE.Tag = "labelMAXIMALNIIZNOSGRUPE";
            this.label1MAXIMALNIIZNOSGRUPE.Text = "Maks. iznos olakšica u grupi:";
            this.label1MAXIMALNIIZNOSGRUPE.StyleSetName = "FieldUltraLabel";
            this.label1MAXIMALNIIZNOSGRUPE.AutoSize = true;
            this.label1MAXIMALNIIZNOSGRUPE.Anchor = AnchorStyles.Left;
            this.label1MAXIMALNIIZNOSGRUPE.Appearance.TextVAlign = VAlign.Middle;
            this.label1MAXIMALNIIZNOSGRUPE.Appearance.ForeColor = Color.Black;
            this.label1MAXIMALNIIZNOSGRUPE.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1MAXIMALNIIZNOSGRUPE, 0, 4);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1MAXIMALNIIZNOSGRUPE, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1MAXIMALNIIZNOSGRUPE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MAXIMALNIIZNOSGRUPE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MAXIMALNIIZNOSGRUPE.MinimumSize = size;
            size = new System.Drawing.Size(0xc0, 0x17);
            this.label1MAXIMALNIIZNOSGRUPE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelMAXIMALNIIZNOSGRUPE.Location = point;
            this.labelMAXIMALNIIZNOSGRUPE.Name = "labelMAXIMALNIIZNOSGRUPE";
            this.labelMAXIMALNIIZNOSGRUPE.Tag = "MAXIMALNIIZNOSGRUPE";
            this.labelMAXIMALNIIZNOSGRUPE.TabIndex = 0;
            this.labelMAXIMALNIIZNOSGRUPE.Anchor = AnchorStyles.Left;
            this.labelMAXIMALNIIZNOSGRUPE.BackColor = Color.Transparent;
            this.labelMAXIMALNIIZNOSGRUPE.Appearance.TextHAlign = HAlign.Left;
            this.labelMAXIMALNIIZNOSGRUPE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.labelMAXIMALNIIZNOSGRUPE, 1, 4);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.labelMAXIMALNIIZNOSGRUPE, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.labelMAXIMALNIIZNOSGRUPE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelMAXIMALNIIZNOSGRUPE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelMAXIMALNIIZNOSGRUPE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelMAXIMALNIIZNOSGRUPE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDTIPOLAKSICE.Location = point;
            this.label1IDTIPOLAKSICE.Name = "label1IDTIPOLAKSICE";
            this.label1IDTIPOLAKSICE.TabIndex = 1;
            this.label1IDTIPOLAKSICE.Tag = "labelIDTIPOLAKSICE";
            this.label1IDTIPOLAKSICE.Text = "Tip olakšice:";
            this.label1IDTIPOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1IDTIPOLAKSICE.AutoSize = true;
            this.label1IDTIPOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1IDTIPOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDTIPOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1IDTIPOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1IDTIPOLAKSICE, 0, 5);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1IDTIPOLAKSICE, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1IDTIPOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDTIPOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDTIPOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x5c, 0x17);
            this.label1IDTIPOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelIDTIPOLAKSICE.Location = point;
            this.labelIDTIPOLAKSICE.Name = "labelIDTIPOLAKSICE";
            this.labelIDTIPOLAKSICE.Tag = "IDTIPOLAKSICE";
            this.labelIDTIPOLAKSICE.TabIndex = 0;
            this.labelIDTIPOLAKSICE.Anchor = AnchorStyles.Left;
            this.labelIDTIPOLAKSICE.BackColor = Color.Transparent;
            this.labelIDTIPOLAKSICE.Appearance.TextHAlign = HAlign.Left;
            this.labelIDTIPOLAKSICE.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "IDTIPOLAKSICE"));
            this.labelIDTIPOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.labelIDTIPOLAKSICE, 1, 5);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.labelIDTIPOLAKSICE, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.labelIDTIPOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelIDTIPOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.labelIDTIPOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.labelIDTIPOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVTIPOLAKSICE.Location = point;
            this.label1NAZIVTIPOLAKSICE.Name = "label1NAZIVTIPOLAKSICE";
            this.label1NAZIVTIPOLAKSICE.TabIndex = 1;
            this.label1NAZIVTIPOLAKSICE.Tag = "labelNAZIVTIPOLAKSICE";
            this.label1NAZIVTIPOLAKSICE.Text = "Naziv tipa olakšice:";
            this.label1NAZIVTIPOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVTIPOLAKSICE.AutoSize = true;
            this.label1NAZIVTIPOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1NAZIVTIPOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVTIPOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1NAZIVTIPOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1NAZIVTIPOLAKSICE, 0, 6);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1NAZIVTIPOLAKSICE, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1NAZIVTIPOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVTIPOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVTIPOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x87, 0x17);
            this.label1NAZIVTIPOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVTIPOLAKSICE.Location = point;
            this.labelNAZIVTIPOLAKSICE.Name = "labelNAZIVTIPOLAKSICE";
            this.labelNAZIVTIPOLAKSICE.Tag = "NAZIVTIPOLAKSICE";
            this.labelNAZIVTIPOLAKSICE.TabIndex = 0;
            this.labelNAZIVTIPOLAKSICE.Anchor = AnchorStyles.Left;
            this.labelNAZIVTIPOLAKSICE.BackColor = Color.Transparent;
            this.labelNAZIVTIPOLAKSICE.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "NAZIVTIPOLAKSICE"));
            this.labelNAZIVTIPOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.labelNAZIVTIPOLAKSICE, 1, 6);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.labelNAZIVTIPOLAKSICE, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.labelNAZIVTIPOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVTIPOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVTIPOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVTIPOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VBDIOLAKSICA.Location = point;
            this.label1VBDIOLAKSICA.Name = "label1VBDIOLAKSICA";
            this.label1VBDIOLAKSICA.TabIndex = 1;
            this.label1VBDIOLAKSICA.Tag = "labelVBDIOLAKSICA";
            this.label1VBDIOLAKSICA.Text = "VBDI žiro računa olakšice:";
            this.label1VBDIOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1VBDIOLAKSICA.AutoSize = true;
            this.label1VBDIOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1VBDIOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1VBDIOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1VBDIOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1VBDIOLAKSICA, 0, 7);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1VBDIOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1VBDIOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VBDIOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VBDIOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0xb2, 0x17);
            this.label1VBDIOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelVBDIOLAKSICA.Location = point;
            this.labelVBDIOLAKSICA.Name = "labelVBDIOLAKSICA";
            this.labelVBDIOLAKSICA.Tag = "VBDIOLAKSICA";
            this.labelVBDIOLAKSICA.TabIndex = 0;
            this.labelVBDIOLAKSICA.Anchor = AnchorStyles.Left;
            this.labelVBDIOLAKSICA.BackColor = Color.Transparent;
            this.labelVBDIOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "VBDIOLAKSICA"));
            this.labelVBDIOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.labelVBDIOLAKSICA, 1, 7);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.labelVBDIOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.labelVBDIOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelVBDIOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.labelVBDIOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.labelVBDIOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZRNOLAKSICA.Location = point;
            this.label1ZRNOLAKSICA.Name = "label1ZRNOLAKSICA";
            this.label1ZRNOLAKSICA.TabIndex = 1;
            this.label1ZRNOLAKSICA.Tag = "labelZRNOLAKSICA";
            this.label1ZRNOLAKSICA.Text = "Broj žiro računa olakšice:";
            this.label1ZRNOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1ZRNOLAKSICA.AutoSize = true;
            this.label1ZRNOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1ZRNOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZRNOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1ZRNOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1ZRNOLAKSICA, 0, 8);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1ZRNOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1ZRNOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZRNOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZRNOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0xac, 0x17);
            this.label1ZRNOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZRNOLAKSICA.Location = point;
            this.labelZRNOLAKSICA.Name = "labelZRNOLAKSICA";
            this.labelZRNOLAKSICA.Tag = "ZRNOLAKSICA";
            this.labelZRNOLAKSICA.TabIndex = 0;
            this.labelZRNOLAKSICA.Anchor = AnchorStyles.Left;
            this.labelZRNOLAKSICA.BackColor = Color.Transparent;
            this.labelZRNOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "ZRNOLAKSICA"));
            this.labelZRNOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.labelZRNOLAKSICA, 1, 8);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.labelZRNOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.labelZRNOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZRNOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.labelZRNOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.labelZRNOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJOLAKSICA1.Location = point;
            this.label1PRIMATELJOLAKSICA1.Name = "label1PRIMATELJOLAKSICA1";
            this.label1PRIMATELJOLAKSICA1.TabIndex = 1;
            this.label1PRIMATELJOLAKSICA1.Tag = "labelPRIMATELJOLAKSICA1";
            this.label1PRIMATELJOLAKSICA1.Text = "Primatelj olakšice (1):";
            this.label1PRIMATELJOLAKSICA1.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJOLAKSICA1.AutoSize = true;
            this.label1PRIMATELJOLAKSICA1.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJOLAKSICA1.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJOLAKSICA1.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJOLAKSICA1.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1PRIMATELJOLAKSICA1, 0, 9);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1PRIMATELJOLAKSICA1, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1PRIMATELJOLAKSICA1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJOLAKSICA1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJOLAKSICA1.MinimumSize = size;
            size = new System.Drawing.Size(0x99, 0x17);
            this.label1PRIMATELJOLAKSICA1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPRIMATELJOLAKSICA1.Location = point;
            this.labelPRIMATELJOLAKSICA1.Name = "labelPRIMATELJOLAKSICA1";
            this.labelPRIMATELJOLAKSICA1.Tag = "PRIMATELJOLAKSICA1";
            this.labelPRIMATELJOLAKSICA1.TabIndex = 0;
            this.labelPRIMATELJOLAKSICA1.Anchor = AnchorStyles.Left;
            this.labelPRIMATELJOLAKSICA1.BackColor = Color.Transparent;
            this.labelPRIMATELJOLAKSICA1.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "PRIMATELJOLAKSICA1"));
            this.labelPRIMATELJOLAKSICA1.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.labelPRIMATELJOLAKSICA1, 1, 9);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.labelPRIMATELJOLAKSICA1, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.labelPRIMATELJOLAKSICA1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJOLAKSICA1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJOLAKSICA1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJOLAKSICA1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJOLAKSICA2.Location = point;
            this.label1PRIMATELJOLAKSICA2.Name = "label1PRIMATELJOLAKSICA2";
            this.label1PRIMATELJOLAKSICA2.TabIndex = 1;
            this.label1PRIMATELJOLAKSICA2.Tag = "labelPRIMATELJOLAKSICA2";
            this.label1PRIMATELJOLAKSICA2.Text = "Primatelj olakšice (2):";
            this.label1PRIMATELJOLAKSICA2.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJOLAKSICA2.AutoSize = true;
            this.label1PRIMATELJOLAKSICA2.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJOLAKSICA2.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJOLAKSICA2.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJOLAKSICA2.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1PRIMATELJOLAKSICA2, 0, 10);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1PRIMATELJOLAKSICA2, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1PRIMATELJOLAKSICA2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJOLAKSICA2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJOLAKSICA2.MinimumSize = size;
            size = new System.Drawing.Size(0x99, 0x17);
            this.label1PRIMATELJOLAKSICA2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPRIMATELJOLAKSICA2.Location = point;
            this.labelPRIMATELJOLAKSICA2.Name = "labelPRIMATELJOLAKSICA2";
            this.labelPRIMATELJOLAKSICA2.Tag = "PRIMATELJOLAKSICA2";
            this.labelPRIMATELJOLAKSICA2.TabIndex = 0;
            this.labelPRIMATELJOLAKSICA2.Anchor = AnchorStyles.Left;
            this.labelPRIMATELJOLAKSICA2.BackColor = Color.Transparent;
            this.labelPRIMATELJOLAKSICA2.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "PRIMATELJOLAKSICA2"));
            this.labelPRIMATELJOLAKSICA2.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.labelPRIMATELJOLAKSICA2, 1, 10);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.labelPRIMATELJOLAKSICA2, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.labelPRIMATELJOLAKSICA2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJOLAKSICA2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJOLAKSICA2.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJOLAKSICA2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJOLAKSICA3.Location = point;
            this.label1PRIMATELJOLAKSICA3.Name = "label1PRIMATELJOLAKSICA3";
            this.label1PRIMATELJOLAKSICA3.TabIndex = 1;
            this.label1PRIMATELJOLAKSICA3.Tag = "labelPRIMATELJOLAKSICA3";
            this.label1PRIMATELJOLAKSICA3.Text = "Primatelj olakšice (3):";
            this.label1PRIMATELJOLAKSICA3.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJOLAKSICA3.AutoSize = true;
            this.label1PRIMATELJOLAKSICA3.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJOLAKSICA3.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJOLAKSICA3.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJOLAKSICA3.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1PRIMATELJOLAKSICA3, 0, 11);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1PRIMATELJOLAKSICA3, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1PRIMATELJOLAKSICA3, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJOLAKSICA3.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJOLAKSICA3.MinimumSize = size;
            size = new System.Drawing.Size(0x99, 0x17);
            this.label1PRIMATELJOLAKSICA3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPRIMATELJOLAKSICA3.Location = point;
            this.labelPRIMATELJOLAKSICA3.Name = "labelPRIMATELJOLAKSICA3";
            this.labelPRIMATELJOLAKSICA3.Tag = "PRIMATELJOLAKSICA3";
            this.labelPRIMATELJOLAKSICA3.TabIndex = 0;
            this.labelPRIMATELJOLAKSICA3.Anchor = AnchorStyles.Left;
            this.labelPRIMATELJOLAKSICA3.BackColor = Color.Transparent;
            this.labelPRIMATELJOLAKSICA3.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "PRIMATELJOLAKSICA3"));
            this.labelPRIMATELJOLAKSICA3.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.labelPRIMATELJOLAKSICA3, 1, 11);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.labelPRIMATELJOLAKSICA3, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.labelPRIMATELJOLAKSICA3, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJOLAKSICA3.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJOLAKSICA3.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJOLAKSICA3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MZOLAKSICA.Location = point;
            this.label1MZOLAKSICA.Name = "label1MZOLAKSICA";
            this.label1MZOLAKSICA.TabIndex = 1;
            this.label1MZOLAKSICA.Tag = "labelMZOLAKSICA";
            this.label1MZOLAKSICA.Text = "Model zaduženja:";
            this.label1MZOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1MZOLAKSICA.AutoSize = true;
            this.label1MZOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1MZOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MZOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1MZOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1MZOLAKSICA, 0, 12);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1MZOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1MZOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MZOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MZOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1MZOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMZOLAKSICA.Location = point;
            this.textMZOLAKSICA.Name = "textMZOLAKSICA";
            this.textMZOLAKSICA.Tag = "MZOLAKSICA";
            this.textMZOLAKSICA.TabIndex = 0;
            this.textMZOLAKSICA.Anchor = AnchorStyles.Left;
            this.textMZOLAKSICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMZOLAKSICA.ContextMenu = this.contextMenu1;
            this.textMZOLAKSICA.ReadOnly = false;
            this.textMZOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "MZOLAKSICA"));
            this.textMZOLAKSICA.Nullable = true;
            this.textMZOLAKSICA.MaxLength = 2;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.textMZOLAKSICA, 1, 12);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.textMZOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.textMZOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMZOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMZOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMZOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PZOLAKSICA.Location = point;
            this.label1PZOLAKSICA.Name = "label1PZOLAKSICA";
            this.label1PZOLAKSICA.TabIndex = 1;
            this.label1PZOLAKSICA.Tag = "labelPZOLAKSICA";
            this.label1PZOLAKSICA.Text = "Poziv na broj zaduženja:";
            this.label1PZOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1PZOLAKSICA.AutoSize = true;
            this.label1PZOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1PZOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1PZOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1PZOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1PZOLAKSICA, 0, 13);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1PZOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1PZOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PZOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PZOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0xa7, 0x17);
            this.label1PZOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPZOLAKSICA.Location = point;
            this.textPZOLAKSICA.Name = "textPZOLAKSICA";
            this.textPZOLAKSICA.Tag = "PZOLAKSICA";
            this.textPZOLAKSICA.TabIndex = 0;
            this.textPZOLAKSICA.Anchor = AnchorStyles.Left;
            this.textPZOLAKSICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPZOLAKSICA.ContextMenu = this.contextMenu1;
            this.textPZOLAKSICA.ReadOnly = false;
            this.textPZOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "PZOLAKSICA"));
            this.textPZOLAKSICA.Nullable = true;
            this.textPZOLAKSICA.MaxLength = 0x16;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.textPZOLAKSICA, 1, 13);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.textPZOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.textPZOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPZOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPZOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPZOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MOOLAKSICA.Location = point;
            this.label1MOOLAKSICA.Name = "label1MOOLAKSICA";
            this.label1MOOLAKSICA.TabIndex = 1;
            this.label1MOOLAKSICA.Tag = "labelMOOLAKSICA";
            this.label1MOOLAKSICA.Text = "Model odobrenja olakšice:";
            this.label1MOOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1MOOLAKSICA.AutoSize = true;
            this.label1MOOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1MOOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MOOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1MOOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1MOOLAKSICA, 0, 14);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1MOOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1MOOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MOOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MOOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0xb1, 0x17);
            this.label1MOOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMOOLAKSICA.Location = point;
            this.textMOOLAKSICA.Name = "textMOOLAKSICA";
            this.textMOOLAKSICA.Tag = "MOOLAKSICA";
            this.textMOOLAKSICA.TabIndex = 0;
            this.textMOOLAKSICA.Anchor = AnchorStyles.Left;
            this.textMOOLAKSICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMOOLAKSICA.ContextMenu = this.contextMenu1;
            this.textMOOLAKSICA.ReadOnly = false;
            this.textMOOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "MOOLAKSICA"));
            this.textMOOLAKSICA.Nullable = true;
            this.textMOOLAKSICA.MaxLength = 2;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.textMOOLAKSICA, 1, 14);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.textMOOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.textMOOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMOOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMOOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMOOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POOLAKSICA.Location = point;
            this.label1POOLAKSICA.Name = "label1POOLAKSICA";
            this.label1POOLAKSICA.TabIndex = 1;
            this.label1POOLAKSICA.Tag = "labelPOOLAKSICA";
            this.label1POOLAKSICA.Text = "Poziv na broj odobrenja olakšice:";
            this.label1POOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1POOLAKSICA.AutoSize = true;
            this.label1POOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1POOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1POOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1POOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1POOLAKSICA, 0, 15);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1POOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1POOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0xdd, 0x17);
            this.label1POOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOOLAKSICA.Location = point;
            this.textPOOLAKSICA.Name = "textPOOLAKSICA";
            this.textPOOLAKSICA.Tag = "POOLAKSICA";
            this.textPOOLAKSICA.TabIndex = 0;
            this.textPOOLAKSICA.Anchor = AnchorStyles.Left;
            this.textPOOLAKSICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOOLAKSICA.ContextMenu = this.contextMenu1;
            this.textPOOLAKSICA.ReadOnly = false;
            this.textPOOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "POOLAKSICA"));
            this.textPOOLAKSICA.Nullable = true;
            this.textPOOLAKSICA.MaxLength = 0x16;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.textPOOLAKSICA, 1, 15);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.textPOOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.textPOOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAOPISAPLACANJAOLAKSICA.Location = point;
            this.label1SIFRAOPISAPLACANJAOLAKSICA.Name = "label1SIFRAOPISAPLACANJAOLAKSICA";
            this.label1SIFRAOPISAPLACANJAOLAKSICA.TabIndex = 1;
            this.label1SIFRAOPISAPLACANJAOLAKSICA.Tag = "labelSIFRAOPISAPLACANJAOLAKSICA";
            this.label1SIFRAOPISAPLACANJAOLAKSICA.Text = "Šifra opisa plaćanja olakšice:";
            this.label1SIFRAOPISAPLACANJAOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAOPISAPLACANJAOLAKSICA.AutoSize = true;
            this.label1SIFRAOPISAPLACANJAOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1SIFRAOPISAPLACANJAOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAOPISAPLACANJAOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1SIFRAOPISAPLACANJAOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1SIFRAOPISAPLACANJAOLAKSICA, 0, 0x10);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1SIFRAOPISAPLACANJAOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1SIFRAOPISAPLACANJAOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAOPISAPLACANJAOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAOPISAPLACANJAOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0xc3, 0x17);
            this.label1SIFRAOPISAPLACANJAOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSIFRAOPISAPLACANJAOLAKSICA.Location = point;
            this.textSIFRAOPISAPLACANJAOLAKSICA.Name = "textSIFRAOPISAPLACANJAOLAKSICA";
            this.textSIFRAOPISAPLACANJAOLAKSICA.Tag = "SIFRAOPISAPLACANJAOLAKSICA";
            this.textSIFRAOPISAPLACANJAOLAKSICA.TabIndex = 0;
            this.textSIFRAOPISAPLACANJAOLAKSICA.Anchor = AnchorStyles.Left;
            this.textSIFRAOPISAPLACANJAOLAKSICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSIFRAOPISAPLACANJAOLAKSICA.ReadOnly = false;
            this.textSIFRAOPISAPLACANJAOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "SIFRAOPISAPLACANJAOLAKSICA"));
            this.textSIFRAOPISAPLACANJAOLAKSICA.MaxLength = 2;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.textSIFRAOPISAPLACANJAOLAKSICA, 1, 0x10);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.textSIFRAOPISAPLACANJAOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.textSIFRAOPISAPLACANJAOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSIFRAOPISAPLACANJAOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJAOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJAOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISPLACANJAOLAKSICA.Location = point;
            this.label1OPISPLACANJAOLAKSICA.Name = "label1OPISPLACANJAOLAKSICA";
            this.label1OPISPLACANJAOLAKSICA.TabIndex = 1;
            this.label1OPISPLACANJAOLAKSICA.Tag = "labelOPISPLACANJAOLAKSICA";
            this.label1OPISPLACANJAOLAKSICA.Text = "Opis plaćanja olakšice:";
            this.label1OPISPLACANJAOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1OPISPLACANJAOLAKSICA.AutoSize = true;
            this.label1OPISPLACANJAOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1OPISPLACANJAOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISPLACANJAOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1OPISPLACANJAOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1OPISPLACANJAOLAKSICA, 0, 0x11);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1OPISPLACANJAOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1OPISPLACANJAOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISPLACANJAOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISPLACANJAOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x17);
            this.label1OPISPLACANJAOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPISPLACANJAOLAKSICA.Location = point;
            this.textOPISPLACANJAOLAKSICA.Name = "textOPISPLACANJAOLAKSICA";
            this.textOPISPLACANJAOLAKSICA.Tag = "OPISPLACANJAOLAKSICA";
            this.textOPISPLACANJAOLAKSICA.TabIndex = 0;
            this.textOPISPLACANJAOLAKSICA.Anchor = AnchorStyles.Left;
            this.textOPISPLACANJAOLAKSICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPISPLACANJAOLAKSICA.ReadOnly = false;
            this.textOPISPLACANJAOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceObracunOlaksice, "OPISPLACANJAOLAKSICA"));
            this.textOPISPLACANJAOLAKSICA.MaxLength = 0x24;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.textOPISPLACANJAOLAKSICA, 1, 0x11);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.textOPISPLACANJAOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.textOPISPLACANJAOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPISPLACANJAOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJAOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJAOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IZNOSOLAKSICE.Location = point;
            this.label1IZNOSOLAKSICE.Name = "label1IZNOSOLAKSICE";
            this.label1IZNOSOLAKSICE.TabIndex = 1;
            this.label1IZNOSOLAKSICE.Tag = "labelIZNOSOLAKSICE";
            this.label1IZNOSOLAKSICE.Text = "Iznos olakšice:";
            this.label1IZNOSOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1IZNOSOLAKSICE.AutoSize = true;
            this.label1IZNOSOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1IZNOSOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IZNOSOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1IZNOSOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1IZNOSOLAKSICE, 0, 0x12);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1IZNOSOLAKSICE, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1IZNOSOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IZNOSOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IZNOSOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x17);
            this.label1IZNOSOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIZNOSOLAKSICE.Location = point;
            this.textIZNOSOLAKSICE.Name = "textIZNOSOLAKSICE";
            this.textIZNOSOLAKSICE.Tag = "IZNOSOLAKSICE";
            this.textIZNOSOLAKSICE.TabIndex = 0;
            this.textIZNOSOLAKSICE.Anchor = AnchorStyles.Left;
            this.textIZNOSOLAKSICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIZNOSOLAKSICE.ReadOnly = false;
            this.textIZNOSOLAKSICE.PromptChar = ' ';
            this.textIZNOSOLAKSICE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIZNOSOLAKSICE.DataBindings.Add(new Binding("Value", this.bindingSourceObracunOlaksice, "IZNOSOLAKSICE"));
            this.textIZNOSOLAKSICE.NumericType = NumericType.Double;
            this.textIZNOSOLAKSICE.MaxValue = 79228162514264337593543950335M;
            this.textIZNOSOLAKSICE.MinValue = -79228162514264337593543950335M;
            this.textIZNOSOLAKSICE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformObracunOlaksice.Controls.Add(this.textIZNOSOLAKSICE, 1, 0x12);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.textIZNOSOLAKSICE, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.textIZNOSOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIZNOSOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textIZNOSOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textIZNOSOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRACUNATAOLAKSICA.Location = point;
            this.label1OBRACUNATAOLAKSICA.Name = "label1OBRACUNATAOLAKSICA";
            this.label1OBRACUNATAOLAKSICA.TabIndex = 1;
            this.label1OBRACUNATAOLAKSICA.Tag = "labelOBRACUNATAOLAKSICA";
            this.label1OBRACUNATAOLAKSICA.Text = "OBRACUNATAOLAKSICA:";
            this.label1OBRACUNATAOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1OBRACUNATAOLAKSICA.AutoSize = true;
            this.label1OBRACUNATAOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1OBRACUNATAOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRACUNATAOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1OBRACUNATAOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformObracunOlaksice.Controls.Add(this.label1OBRACUNATAOLAKSICA, 0, 0x13);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.label1OBRACUNATAOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.label1OBRACUNATAOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRACUNATAOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRACUNATAOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x17);
            this.label1OBRACUNATAOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRACUNATAOLAKSICA.Location = point;
            this.textOBRACUNATAOLAKSICA.Name = "textOBRACUNATAOLAKSICA";
            this.textOBRACUNATAOLAKSICA.Tag = "OBRACUNATAOLAKSICA";
            this.textOBRACUNATAOLAKSICA.TabIndex = 0;
            this.textOBRACUNATAOLAKSICA.Anchor = AnchorStyles.Left;
            this.textOBRACUNATAOLAKSICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRACUNATAOLAKSICA.ReadOnly = false;
            this.textOBRACUNATAOLAKSICA.PromptChar = ' ';
            this.textOBRACUNATAOLAKSICA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOBRACUNATAOLAKSICA.DataBindings.Add(new Binding("Value", this.bindingSourceObracunOlaksice, "OBRACUNATAOLAKSICA"));
            this.textOBRACUNATAOLAKSICA.NumericType = NumericType.Double;
            this.textOBRACUNATAOLAKSICA.MaxValue = 79228162514264337593543950335M;
            this.textOBRACUNATAOLAKSICA.MinValue = -79228162514264337593543950335M;
            this.textOBRACUNATAOLAKSICA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformObracunOlaksice.Controls.Add(this.textOBRACUNATAOLAKSICA, 1, 0x13);
            this.layoutManagerformObracunOlaksice.SetColumnSpan(this.textOBRACUNATAOLAKSICA, 1);
            this.layoutManagerformObracunOlaksice.SetRowSpan(this.textOBRACUNATAOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRACUNATAOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRACUNATAOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRACUNATAOLAKSICA.Size = size;
            this.Controls.Add(this.layoutManagerformObracunOlaksice);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceObracunOlaksice;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "OBRACUNFormObracunOlaksiceUserControl";
            this.Text = " ObracunOlaksice";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OBRACUNFormUserControl_Load);
            this.layoutManagerformObracunOlaksice.ResumeLayout(false);
            this.layoutManagerformObracunOlaksice.PerformLayout();
            ((ISupportInitialize) this.bindingSourceObracunOlaksice).EndInit();
            ((ISupportInitialize) this.textIDOLAKSICE).EndInit();
            ((ISupportInitialize) this.textMZOLAKSICA).EndInit();
            ((ISupportInitialize) this.textPZOLAKSICA).EndInit();
            ((ISupportInitialize) this.textMOOLAKSICA).EndInit();
            ((ISupportInitialize) this.textPOOLAKSICA).EndInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJAOLAKSICA).EndInit();
            ((ISupportInitialize) this.textOPISPLACANJAOLAKSICA).EndInit();
            ((ISupportInitialize) this.textIZNOSOLAKSICE).EndInit();
            ((ISupportInitialize) this.textOBRACUNATAOLAKSICA).EndInit();
            this.dsOBRACUNDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OBRACUNController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceObracunOlaksice, this.OBRACUNController.WorkItem, this))
            {
                return false;
            }
            this.EndEditCurrentRow();
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void Localize()
        {
            this.label1IDOLAKSICE.Text = StringResources.OBRACUNIDOLAKSICEDescription;
            this.label1NAZIVOLAKSICE.Text = StringResources.OBRACUNNAZIVOLAKSICEDescription;
            this.label1IDGRUPEOLAKSICA.Text = StringResources.OBRACUNIDGRUPEOLAKSICADescription;
            this.label1NAZIVGRUPEOLAKSICA.Text = StringResources.OBRACUNNAZIVGRUPEOLAKSICADescription;
            this.label1MAXIMALNIIZNOSGRUPE.Text = StringResources.OBRACUNMAXIMALNIIZNOSGRUPEDescription;
            this.label1IDTIPOLAKSICE.Text = StringResources.OBRACUNIDTIPOLAKSICEDescription;
            this.label1NAZIVTIPOLAKSICE.Text = StringResources.OBRACUNNAZIVTIPOLAKSICEDescription;
            this.label1VBDIOLAKSICA.Text = StringResources.OBRACUNVBDIOLAKSICADescription;
            this.label1ZRNOLAKSICA.Text = StringResources.OBRACUNZRNOLAKSICADescription;
            this.label1PRIMATELJOLAKSICA1.Text = StringResources.OBRACUNPRIMATELJOLAKSICA1Description;
            this.label1PRIMATELJOLAKSICA2.Text = StringResources.OBRACUNPRIMATELJOLAKSICA2Description;
            this.label1PRIMATELJOLAKSICA3.Text = StringResources.OBRACUNPRIMATELJOLAKSICA3Description;
            this.label1MZOLAKSICA.Text = StringResources.OBRACUNMZOLAKSICADescription;
            this.label1PZOLAKSICA.Text = StringResources.OBRACUNPZOLAKSICADescription;
            this.label1MOOLAKSICA.Text = StringResources.OBRACUNMOOLAKSICADescription;
            this.label1POOLAKSICA.Text = StringResources.OBRACUNPOOLAKSICADescription;
            this.label1SIFRAOPISAPLACANJAOLAKSICA.Text = StringResources.OBRACUNSIFRAOPISAPLACANJAOLAKSICADescription;
            this.label1OPISPLACANJAOLAKSICA.Text = StringResources.OBRACUNOPISPLACANJAOLAKSICADescription;
            this.label1IZNOSOLAKSICE.Text = StringResources.OBRACUNIZNOSOLAKSICEDescription;
            this.label1OBRACUNATAOLAKSICA.Text = StringResources.OBRACUNOBRACUNATAOLAKSICADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewRSMA")]
        public void NewRSMAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OBRACUNController.NewRSMA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void OBRACUNFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OBRACUNObracunOlaksiceLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.OBRACUNController.WorkItem.Items.Contains("ObracunOlaksice|ObracunOlaksice"))
            {
                this.OBRACUNController.WorkItem.Items.Add(this.bindingSourceObracunOlaksice, "ObracunOlaksice|ObracunOlaksice");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("ObracunOlaksiceSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDOLAKSICE.Focus();
        }

        private void SetNullItem_Click(object sender, EventArgs e)
        {
            this.m_BaseMethods.SetNullItemClickBase(RuntimeHelpers.GetObjectValue(sender), this.m_CurrentRow);
        }

        private void SetSize()
        {
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.m_FrameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void UpdateValuesOLAKSICEIDOLAKSICE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceObracunOlaksice.Current).Row["IDOLAKSICE"] = RuntimeHelpers.GetObjectValue(result["IDOLAKSICE"]);
                ((DataRowView) this.bindingSourceObracunOlaksice.Current).Row["NAZIVOLAKSICE"] = RuntimeHelpers.GetObjectValue(result["NAZIVOLAKSICE"]);
                ((DataRowView) this.bindingSourceObracunOlaksice.Current).Row["IDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(result["IDGRUPEOLAKSICA"]);
                ((DataRowView) this.bindingSourceObracunOlaksice.Current).Row["IDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(result["IDTIPOLAKSICE"]);
                ((DataRowView) this.bindingSourceObracunOlaksice.Current).Row["VBDIOLAKSICA"] = RuntimeHelpers.GetObjectValue(result["VBDIOLAKSICA"]);
                ((DataRowView) this.bindingSourceObracunOlaksice.Current).Row["ZRNOLAKSICA"] = RuntimeHelpers.GetObjectValue(result["ZRNOLAKSICA"]);
                ((DataRowView) this.bindingSourceObracunOlaksice.Current).Row["PRIMATELJOLAKSICA1"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJOLAKSICA1"]);
                ((DataRowView) this.bindingSourceObracunOlaksice.Current).Row["PRIMATELJOLAKSICA2"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJOLAKSICA2"]);
                ((DataRowView) this.bindingSourceObracunOlaksice.Current).Row["PRIMATELJOLAKSICA3"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJOLAKSICA3"]);
                ((DataRowView) this.bindingSourceObracunOlaksice.Current).Row["NAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(result["NAZIVGRUPEOLAKSICA"]);
                ((DataRowView) this.bindingSourceObracunOlaksice.Current).Row["MAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(result["MAXIMALNIIZNOSGRUPE"]);
                ((DataRowView) this.bindingSourceObracunOlaksice.Current).Row["NAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(result["NAZIVTIPOLAKSICE"]);
                this.bindingSourceObracunOlaksice.ResetCurrentItem();
            }
        }

        [LocalCommandHandler("ViewRSMA")]
        public void ViewRSMAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OBRACUNController.ViewRSMA(this.m_CurrentRow);
            }
        }

        private ContextMenu contextMenu1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._contextMenu1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._contextMenu1 = value;
            }
        }

        private ErrorProvider errorProvider1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._errorProvider1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._errorProvider1 = value;
            }
        }

        private ErrorProviderValidator errorProviderValidator1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._errorProviderValidator1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._errorProviderValidator1 = value;
            }
        }

        protected virtual UltraLabel label1IDGRUPEOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDGRUPEOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDGRUPEOLAKSICA = value;
            }
        }

        protected virtual UltraLabel label1IDOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1IDTIPOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDTIPOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDTIPOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1IZNOSOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IZNOSOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IZNOSOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1MAXIMALNIIZNOSGRUPE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MAXIMALNIIZNOSGRUPE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MAXIMALNIIZNOSGRUPE = value;
            }
        }

        protected virtual UltraLabel label1MOOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MOOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MOOLAKSICA = value;
            }
        }

        protected virtual UltraLabel label1MZOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MZOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MZOLAKSICA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVGRUPEOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVGRUPEOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVGRUPEOLAKSICA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1NAZIVTIPOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVTIPOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVTIPOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1OBRACUNATAOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRACUNATAOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRACUNATAOLAKSICA = value;
            }
        }

        protected virtual UltraLabel label1OPISPLACANJAOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISPLACANJAOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISPLACANJAOLAKSICA = value;
            }
        }

        protected virtual UltraLabel label1POOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POOLAKSICA = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJOLAKSICA1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJOLAKSICA1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJOLAKSICA1 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJOLAKSICA2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJOLAKSICA2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJOLAKSICA2 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJOLAKSICA3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJOLAKSICA3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJOLAKSICA3 = value;
            }
        }

        protected virtual UltraLabel label1PZOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PZOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PZOLAKSICA = value;
            }
        }

        protected virtual UltraLabel label1SIFRAOPISAPLACANJAOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAOPISAPLACANJAOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAOPISAPLACANJAOLAKSICA = value;
            }
        }

        protected virtual UltraLabel label1VBDIOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VBDIOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VBDIOLAKSICA = value;
            }
        }

        protected virtual UltraLabel label1ZRNOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZRNOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZRNOLAKSICA = value;
            }
        }

        protected virtual UltraLabel labelIDGRUPEOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelIDGRUPEOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelIDGRUPEOLAKSICA = value;
            }
        }

        protected virtual UltraLabel labelIDTIPOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelIDTIPOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelIDTIPOLAKSICE = value;
            }
        }

        protected virtual UltraLabel labelMAXIMALNIIZNOSGRUPE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelMAXIMALNIIZNOSGRUPE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelMAXIMALNIIZNOSGRUPE = value;
            }
        }

        protected virtual UltraLabel labelNAZIVGRUPEOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVGRUPEOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVGRUPEOLAKSICA = value;
            }
        }

        protected virtual UltraLabel labelNAZIVOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVOLAKSICE = value;
            }
        }

        protected virtual UltraLabel labelNAZIVTIPOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVTIPOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVTIPOLAKSICE = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJOLAKSICA1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJOLAKSICA1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJOLAKSICA1 = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJOLAKSICA2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJOLAKSICA2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJOLAKSICA2 = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJOLAKSICA3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJOLAKSICA3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJOLAKSICA3 = value;
            }
        }

        protected virtual UltraLabel labelVBDIOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelVBDIOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelVBDIOLAKSICA = value;
            }
        }

        protected virtual UltraLabel labelZRNOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZRNOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZRNOLAKSICA = value;
            }
        }

        public DeklaritMode Mode
        {
            get
            {
                return this.m_Mode;
            }
            set
            {
                this.m_Mode = value;
            }
        }

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.OBRACUNController OBRACUNController { get; set; }

        private MenuItem SetNullItem
        {
            [DebuggerNonUserCode]
            get
            {
                return this._SetNullItem;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._SetNullItem = value;
            }
        }

        protected virtual UltraNumericEditor textIDOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDOLAKSICE = value;
            }
        }

        protected virtual UltraNumericEditor textIZNOSOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIZNOSOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIZNOSOLAKSICE = value;
            }
        }

        protected virtual UltraTextEditor textMOOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMOOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMOOLAKSICA = value;
            }
        }

        protected virtual UltraTextEditor textMZOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMZOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMZOLAKSICA = value;
            }
        }

        protected virtual UltraNumericEditor textOBRACUNATAOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRACUNATAOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRACUNATAOLAKSICA = value;
            }
        }

        protected virtual UltraTextEditor textOPISPLACANJAOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPISPLACANJAOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPISPLACANJAOLAKSICA = value;
            }
        }

        protected virtual UltraTextEditor textPOOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOOLAKSICA = value;
            }
        }

        protected virtual UltraTextEditor textPZOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPZOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPZOLAKSICA = value;
            }
        }

        protected virtual UltraTextEditor textSIFRAOPISAPLACANJAOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSIFRAOPISAPLACANJAOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSIFRAOPISAPLACANJAOLAKSICA = value;
            }
        }

        private System.Windows.Forms.ToolTip toolTip1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._toolTip1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._toolTip1 = value;
            }
        }
    }
}

