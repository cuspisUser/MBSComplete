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
    public class RADNIKFormRADNIKOlaksicaUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1ZADIZNOSOLAKSICE")]
        private UltraLabel _label1ZADIZNOSOLAKSICE;
        [AccessedThroughProperty("label1ZADMOOLAKSICE")]
        private UltraLabel _label1ZADMOOLAKSICE;
        [AccessedThroughProperty("label1ZADMZOLAKSICE")]
        private UltraLabel _label1ZADMZOLAKSICE;
        [AccessedThroughProperty("label1ZADOLAKSICEIDOLAKSICE")]
        private UltraLabel _label1ZADOLAKSICEIDOLAKSICE;
        [AccessedThroughProperty("label1ZADOLAKSICENAZIVOLAKSICE")]
        private UltraLabel _label1ZADOLAKSICENAZIVOLAKSICE;
        [AccessedThroughProperty("label1ZADOLAKSICENAZIVTIPOLAKSICE")]
        private UltraLabel _label1ZADOLAKSICENAZIVTIPOLAKSICE;
        [AccessedThroughProperty("label1ZADOLAKSICEVBDIOLAKSICA")]
        private UltraLabel _label1ZADOLAKSICEVBDIOLAKSICA;
        [AccessedThroughProperty("label1ZADOLAKSICEZRNOLAKSICA")]
        private UltraLabel _label1ZADOLAKSICEZRNOLAKSICA;
        [AccessedThroughProperty("label1ZADOPISPLACANJAOLAKSICE")]
        private UltraLabel _label1ZADOPISPLACANJAOLAKSICE;
        [AccessedThroughProperty("label1ZADPOJEDINACNIPOZIV")]
        private UltraLabel _label1ZADPOJEDINACNIPOZIV;
        [AccessedThroughProperty("label1ZADPOOLAKSICE")]
        private UltraLabel _label1ZADPOOLAKSICE;
        [AccessedThroughProperty("label1ZADPZOLAKSICE")]
        private UltraLabel _label1ZADPZOLAKSICE;
        [AccessedThroughProperty("label1ZADSIFRAOPISAPLACANJAOLAKSICE")]
        private UltraLabel _label1ZADSIFRAOPISAPLACANJAOLAKSICE;
        [AccessedThroughProperty("labelZADOLAKSICENAZIVOLAKSICE")]
        private UltraLabel _labelZADOLAKSICENAZIVOLAKSICE;
        [AccessedThroughProperty("labelZADOLAKSICENAZIVTIPOLAKSICE")]
        private UltraLabel _labelZADOLAKSICENAZIVTIPOLAKSICE;
        [AccessedThroughProperty("labelZADOLAKSICEVBDIOLAKSICA")]
        private UltraLabel _labelZADOLAKSICEVBDIOLAKSICA;
        [AccessedThroughProperty("labelZADOLAKSICEZRNOLAKSICA")]
        private UltraLabel _labelZADOLAKSICEZRNOLAKSICA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textZADIZNOSOLAKSICE")]
        private UltraNumericEditor _textZADIZNOSOLAKSICE;
        [AccessedThroughProperty("textZADMOOLAKSICE")]
        private UltraTextEditor _textZADMOOLAKSICE;
        [AccessedThroughProperty("textZADMZOLAKSICE")]
        private UltraTextEditor _textZADMZOLAKSICE;
        [AccessedThroughProperty("textZADOLAKSICEIDOLAKSICE")]
        private UltraNumericEditor _textZADOLAKSICEIDOLAKSICE;
        [AccessedThroughProperty("textZADOPISPLACANJAOLAKSICE")]
        private UltraTextEditor _textZADOPISPLACANJAOLAKSICE;
        [AccessedThroughProperty("textZADPOJEDINACNIPOZIV")]
        private UltraTextEditor _textZADPOJEDINACNIPOZIV;
        [AccessedThroughProperty("textZADPOOLAKSICE")]
        private UltraTextEditor _textZADPOOLAKSICE;
        [AccessedThroughProperty("textZADPZOLAKSICE")]
        private UltraTextEditor _textZADPZOLAKSICE;
        [AccessedThroughProperty("textZADSIFRAOPISAPLACANJAOLAKSICE")]
        private UltraTextEditor _textZADSIFRAOPISAPLACANJAOLAKSICE;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRADNIKOlaksica;
        private IContainer components = null;
        private RADNIKDataSet dsRADNIKDataSet1;
        protected TableLayoutPanel layoutManagerformRADNIKOlaksica;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RADNIKDataSet.RADNIKOlaksicaRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RADNIKOlaksica";
        private string m_FrameworkDescription = StringResources.RADNIKDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        public RADNIKFormRADNIKOlaksicaUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("RADNIKOlaksicaAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("RADNIKOlaksicaAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (RADNIKDataSet.RADNIKOlaksicaRow) ((DataRowView) this.bindingSourceRADNIKOlaksica.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CallPromptOLAKSICEZADOLAKSICEIDOLAKSICE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.RADNIKController.SelectOLAKSICEZADOLAKSICEIDOLAKSICE(fillMethod, fillByRow);
            this.UpdateValuesOLAKSICEZADOLAKSICEIDOLAKSICE(result);
        }

        private void CallViewOLAKSICEZADOLAKSICEIDOLAKSICE(object sender, EventArgs e)
        {
            DataRow result = this.RADNIKController.ShowOLAKSICEZADOLAKSICEIDOLAKSICE(this.m_CurrentRow);
            this.UpdateValuesOLAKSICEZADOLAKSICEIDOLAKSICE(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsRADNIKDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceRADNIKOlaksica.DataSource = this.RADNIKController.DataSet;
            this.dsRADNIKDataSet1 = this.RADNIKController.DataSet;
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
            this.dsRADNIKDataSet1 = (RADNIKDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceRADNIKOlaksica.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsRADNIKDataSet1.Tables["RADNIKOlaksica"]);
            this.bindingSourceRADNIKOlaksica.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RADNIK", this.m_Mode, this.dsRADNIKDataSet1, this.dsRADNIKDataSet1.RADNIKOlaksica.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (RADNIKDataSet.RADNIKOlaksicaRow) ((DataRowView) this.bindingSourceRADNIKOlaksica.Current).Row;
                this.textZADOLAKSICEIDOLAKSICE.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textZADOLAKSICEIDOLAKSICE.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (RADNIKDataSet.RADNIKOlaksicaRow) ((DataRowView) this.bindingSourceRADNIKOlaksica.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(RADNIKFormRADNIKOlaksicaUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRADNIKOlaksica = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKOlaksica).BeginInit();
            this.layoutManagerformRADNIKOlaksica = new TableLayoutPanel();
            this.layoutManagerformRADNIKOlaksica.SuspendLayout();
            this.layoutManagerformRADNIKOlaksica.AutoSize = true;
            this.layoutManagerformRADNIKOlaksica.Dock = DockStyle.Fill;
            this.layoutManagerformRADNIKOlaksica.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRADNIKOlaksica.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRADNIKOlaksica.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRADNIKOlaksica.Size = size;
            this.layoutManagerformRADNIKOlaksica.ColumnCount = 2;
            this.layoutManagerformRADNIKOlaksica.RowCount = 14;
            this.layoutManagerformRADNIKOlaksica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKOlaksica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKOlaksica.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOlaksica.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOlaksica.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOlaksica.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOlaksica.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOlaksica.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOlaksica.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOlaksica.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOlaksica.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOlaksica.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOlaksica.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOlaksica.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOlaksica.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOlaksica.RowStyles.Add(new RowStyle());
            this.label1ZADOLAKSICEIDOLAKSICE = new UltraLabel();
            this.textZADOLAKSICEIDOLAKSICE = new UltraNumericEditor();
            this.label1ZADOLAKSICENAZIVOLAKSICE = new UltraLabel();
            this.labelZADOLAKSICENAZIVOLAKSICE = new UltraLabel();
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE = new UltraLabel();
            this.labelZADOLAKSICENAZIVTIPOLAKSICE = new UltraLabel();
            this.label1ZADOLAKSICEVBDIOLAKSICA = new UltraLabel();
            this.labelZADOLAKSICEVBDIOLAKSICA = new UltraLabel();
            this.label1ZADOLAKSICEZRNOLAKSICA = new UltraLabel();
            this.labelZADOLAKSICEZRNOLAKSICA = new UltraLabel();
            this.label1ZADMZOLAKSICE = new UltraLabel();
            this.textZADMZOLAKSICE = new UltraTextEditor();
            this.label1ZADPZOLAKSICE = new UltraLabel();
            this.textZADPZOLAKSICE = new UltraTextEditor();
            this.label1ZADMOOLAKSICE = new UltraLabel();
            this.textZADMOOLAKSICE = new UltraTextEditor();
            this.label1ZADPOOLAKSICE = new UltraLabel();
            this.textZADPOOLAKSICE = new UltraTextEditor();
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE = new UltraLabel();
            this.textZADSIFRAOPISAPLACANJAOLAKSICE = new UltraTextEditor();
            this.label1ZADOPISPLACANJAOLAKSICE = new UltraLabel();
            this.textZADOPISPLACANJAOLAKSICE = new UltraTextEditor();
            this.label1ZADPOJEDINACNIPOZIV = new UltraLabel();
            this.textZADPOJEDINACNIPOZIV = new UltraTextEditor();
            this.label1ZADIZNOSOLAKSICE = new UltraLabel();
            this.textZADIZNOSOLAKSICE = new UltraNumericEditor();
            ((ISupportInitialize) this.textZADOLAKSICEIDOLAKSICE).BeginInit();
            ((ISupportInitialize) this.textZADMZOLAKSICE).BeginInit();
            ((ISupportInitialize) this.textZADPZOLAKSICE).BeginInit();
            ((ISupportInitialize) this.textZADMOOLAKSICE).BeginInit();
            ((ISupportInitialize) this.textZADPOOLAKSICE).BeginInit();
            ((ISupportInitialize) this.textZADSIFRAOPISAPLACANJAOLAKSICE).BeginInit();
            ((ISupportInitialize) this.textZADOPISPLACANJAOLAKSICE).BeginInit();
            ((ISupportInitialize) this.textZADPOJEDINACNIPOZIV).BeginInit();
            ((ISupportInitialize) this.textZADIZNOSOLAKSICE).BeginInit();
            this.dsRADNIKDataSet1 = new RADNIKDataSet();
            this.dsRADNIKDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRADNIKDataSet1.DataSetName = "dsRADNIK";
            this.dsRADNIKDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRADNIKOlaksica.DataSource = this.dsRADNIKDataSet1;
            this.bindingSourceRADNIKOlaksica.DataMember = "RADNIKOlaksica";
            ((ISupportInitialize) this.bindingSourceRADNIKOlaksica).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1ZADOLAKSICEIDOLAKSICE.Location = point;
            this.label1ZADOLAKSICEIDOLAKSICE.Name = "label1ZADOLAKSICEIDOLAKSICE";
            this.label1ZADOLAKSICEIDOLAKSICE.TabIndex = 1;
            this.label1ZADOLAKSICEIDOLAKSICE.Tag = "labelZADOLAKSICEIDOLAKSICE";
            this.label1ZADOLAKSICEIDOLAKSICE.Text = "Šifra:";
            this.label1ZADOLAKSICEIDOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1ZADOLAKSICEIDOLAKSICE.AutoSize = true;
            this.label1ZADOLAKSICEIDOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1ZADOLAKSICEIDOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADOLAKSICEIDOLAKSICE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1ZADOLAKSICEIDOLAKSICE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1ZADOLAKSICEIDOLAKSICE.ImageSize = size;
            this.label1ZADOLAKSICEIDOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1ZADOLAKSICEIDOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.label1ZADOLAKSICEIDOLAKSICE, 0, 0);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.label1ZADOLAKSICEIDOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.label1ZADOLAKSICEIDOLAKSICE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1ZADOLAKSICEIDOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADOLAKSICEIDOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1ZADOLAKSICEIDOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADOLAKSICEIDOLAKSICE.Location = point;
            this.textZADOLAKSICEIDOLAKSICE.Name = "textZADOLAKSICEIDOLAKSICE";
            this.textZADOLAKSICEIDOLAKSICE.Tag = "ZADOLAKSICEIDOLAKSICE";
            this.textZADOLAKSICEIDOLAKSICE.TabIndex = 0;
            this.textZADOLAKSICEIDOLAKSICE.Anchor = AnchorStyles.Left;
            this.textZADOLAKSICEIDOLAKSICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADOLAKSICEIDOLAKSICE.ReadOnly = false;
            this.textZADOLAKSICEIDOLAKSICE.PromptChar = ' ';
            this.textZADOLAKSICEIDOLAKSICE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZADOLAKSICEIDOLAKSICE.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKOlaksica, "ZADOLAKSICEIDOLAKSICE"));
            this.textZADOLAKSICEIDOLAKSICE.NumericType = NumericType.Integer;
            this.textZADOLAKSICEIDOLAKSICE.MaskInput = "{LOC}-nnnnnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonOLAKSICEZADOLAKSICEIDOLAKSICE",
                Tag = "editorButtonOLAKSICEZADOLAKSICEIDOLAKSICE",
                Text = "..."
            };
            this.textZADOLAKSICEIDOLAKSICE.ButtonsRight.Add(button);
            this.textZADOLAKSICEIDOLAKSICE.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOLAKSICEZADOLAKSICEIDOLAKSICE);
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.textZADOLAKSICEIDOLAKSICE, 1, 0);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.textZADOLAKSICEIDOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.textZADOLAKSICEIDOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADOLAKSICEIDOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textZADOLAKSICEIDOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textZADOLAKSICEIDOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADOLAKSICENAZIVOLAKSICE.Location = point;
            this.label1ZADOLAKSICENAZIVOLAKSICE.Name = "label1ZADOLAKSICENAZIVOLAKSICE";
            this.label1ZADOLAKSICENAZIVOLAKSICE.TabIndex = 1;
            this.label1ZADOLAKSICENAZIVOLAKSICE.Tag = "labelZADOLAKSICENAZIVOLAKSICE";
            this.label1ZADOLAKSICENAZIVOLAKSICE.Text = "Olakšica:";
            this.label1ZADOLAKSICENAZIVOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1ZADOLAKSICENAZIVOLAKSICE.AutoSize = true;
            this.label1ZADOLAKSICENAZIVOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1ZADOLAKSICENAZIVOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADOLAKSICENAZIVOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1ZADOLAKSICENAZIVOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.label1ZADOLAKSICENAZIVOLAKSICE, 0, 1);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.label1ZADOLAKSICENAZIVOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.label1ZADOLAKSICENAZIVOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADOLAKSICENAZIVOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADOLAKSICENAZIVOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x17);
            this.label1ZADOLAKSICENAZIVOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZADOLAKSICENAZIVOLAKSICE.Location = point;
            this.labelZADOLAKSICENAZIVOLAKSICE.Name = "labelZADOLAKSICENAZIVOLAKSICE";
            this.labelZADOLAKSICENAZIVOLAKSICE.Tag = "ZADOLAKSICENAZIVOLAKSICE";
            this.labelZADOLAKSICENAZIVOLAKSICE.TabIndex = 0;
            this.labelZADOLAKSICENAZIVOLAKSICE.Anchor = AnchorStyles.Left;
            this.labelZADOLAKSICENAZIVOLAKSICE.BackColor = Color.Transparent;
            this.labelZADOLAKSICENAZIVOLAKSICE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKOlaksica, "ZADOLAKSICENAZIVOLAKSICE"));
            this.labelZADOLAKSICENAZIVOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.labelZADOLAKSICENAZIVOLAKSICE, 1, 1);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.labelZADOLAKSICENAZIVOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.labelZADOLAKSICENAZIVOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZADOLAKSICENAZIVOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelZADOLAKSICENAZIVOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelZADOLAKSICENAZIVOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE.Location = point;
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE.Name = "label1ZADOLAKSICENAZIVTIPOLAKSICE";
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE.TabIndex = 1;
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE.Tag = "labelZADOLAKSICENAZIVTIPOLAKSICE";
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE.Text = "Naziv tip olakšice:";
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE.AutoSize = true;
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.label1ZADOLAKSICENAZIVTIPOLAKSICE, 0, 2);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.label1ZADOLAKSICENAZIVTIPOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.label1ZADOLAKSICENAZIVTIPOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x7f, 0x17);
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZADOLAKSICENAZIVTIPOLAKSICE.Location = point;
            this.labelZADOLAKSICENAZIVTIPOLAKSICE.Name = "labelZADOLAKSICENAZIVTIPOLAKSICE";
            this.labelZADOLAKSICENAZIVTIPOLAKSICE.Tag = "ZADOLAKSICENAZIVTIPOLAKSICE";
            this.labelZADOLAKSICENAZIVTIPOLAKSICE.TabIndex = 0;
            this.labelZADOLAKSICENAZIVTIPOLAKSICE.Anchor = AnchorStyles.Left;
            this.labelZADOLAKSICENAZIVTIPOLAKSICE.BackColor = Color.Transparent;
            this.labelZADOLAKSICENAZIVTIPOLAKSICE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKOlaksica, "ZADOLAKSICENAZIVTIPOLAKSICE"));
            this.labelZADOLAKSICENAZIVTIPOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.labelZADOLAKSICENAZIVTIPOLAKSICE, 1, 2);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.labelZADOLAKSICENAZIVTIPOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.labelZADOLAKSICENAZIVTIPOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZADOLAKSICENAZIVTIPOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelZADOLAKSICENAZIVTIPOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelZADOLAKSICENAZIVTIPOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADOLAKSICEVBDIOLAKSICA.Location = point;
            this.label1ZADOLAKSICEVBDIOLAKSICA.Name = "label1ZADOLAKSICEVBDIOLAKSICA";
            this.label1ZADOLAKSICEVBDIOLAKSICA.TabIndex = 1;
            this.label1ZADOLAKSICEVBDIOLAKSICA.Tag = "labelZADOLAKSICEVBDIOLAKSICA";
            this.label1ZADOLAKSICEVBDIOLAKSICA.Text = "VBDI žiro računa olakšice:";
            this.label1ZADOLAKSICEVBDIOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1ZADOLAKSICEVBDIOLAKSICA.AutoSize = true;
            this.label1ZADOLAKSICEVBDIOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1ZADOLAKSICEVBDIOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADOLAKSICEVBDIOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1ZADOLAKSICEVBDIOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.label1ZADOLAKSICEVBDIOLAKSICA, 0, 3);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.label1ZADOLAKSICEVBDIOLAKSICA, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.label1ZADOLAKSICEVBDIOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADOLAKSICEVBDIOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADOLAKSICEVBDIOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0xb2, 0x17);
            this.label1ZADOLAKSICEVBDIOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZADOLAKSICEVBDIOLAKSICA.Location = point;
            this.labelZADOLAKSICEVBDIOLAKSICA.Name = "labelZADOLAKSICEVBDIOLAKSICA";
            this.labelZADOLAKSICEVBDIOLAKSICA.Tag = "ZADOLAKSICEVBDIOLAKSICA";
            this.labelZADOLAKSICEVBDIOLAKSICA.TabIndex = 0;
            this.labelZADOLAKSICEVBDIOLAKSICA.Anchor = AnchorStyles.Left;
            this.labelZADOLAKSICEVBDIOLAKSICA.BackColor = Color.Transparent;
            this.labelZADOLAKSICEVBDIOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKOlaksica, "ZADOLAKSICEVBDIOLAKSICA"));
            this.labelZADOLAKSICEVBDIOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.labelZADOLAKSICEVBDIOLAKSICA, 1, 3);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.labelZADOLAKSICEVBDIOLAKSICA, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.labelZADOLAKSICEVBDIOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZADOLAKSICEVBDIOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.labelZADOLAKSICEVBDIOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.labelZADOLAKSICEVBDIOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADOLAKSICEZRNOLAKSICA.Location = point;
            this.label1ZADOLAKSICEZRNOLAKSICA.Name = "label1ZADOLAKSICEZRNOLAKSICA";
            this.label1ZADOLAKSICEZRNOLAKSICA.TabIndex = 1;
            this.label1ZADOLAKSICEZRNOLAKSICA.Tag = "labelZADOLAKSICEZRNOLAKSICA";
            this.label1ZADOLAKSICEZRNOLAKSICA.Text = "Broj žiro računa olakšice:";
            this.label1ZADOLAKSICEZRNOLAKSICA.StyleSetName = "FieldUltraLabel";
            this.label1ZADOLAKSICEZRNOLAKSICA.AutoSize = true;
            this.label1ZADOLAKSICEZRNOLAKSICA.Anchor = AnchorStyles.Left;
            this.label1ZADOLAKSICEZRNOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADOLAKSICEZRNOLAKSICA.Appearance.ForeColor = Color.Black;
            this.label1ZADOLAKSICEZRNOLAKSICA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.label1ZADOLAKSICEZRNOLAKSICA, 0, 4);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.label1ZADOLAKSICEZRNOLAKSICA, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.label1ZADOLAKSICEZRNOLAKSICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADOLAKSICEZRNOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADOLAKSICEZRNOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0xac, 0x17);
            this.label1ZADOLAKSICEZRNOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZADOLAKSICEZRNOLAKSICA.Location = point;
            this.labelZADOLAKSICEZRNOLAKSICA.Name = "labelZADOLAKSICEZRNOLAKSICA";
            this.labelZADOLAKSICEZRNOLAKSICA.Tag = "ZADOLAKSICEZRNOLAKSICA";
            this.labelZADOLAKSICEZRNOLAKSICA.TabIndex = 0;
            this.labelZADOLAKSICEZRNOLAKSICA.Anchor = AnchorStyles.Left;
            this.labelZADOLAKSICEZRNOLAKSICA.BackColor = Color.Transparent;
            this.labelZADOLAKSICEZRNOLAKSICA.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKOlaksica, "ZADOLAKSICEZRNOLAKSICA"));
            this.labelZADOLAKSICEZRNOLAKSICA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.labelZADOLAKSICEZRNOLAKSICA, 1, 4);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.labelZADOLAKSICEZRNOLAKSICA, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.labelZADOLAKSICEZRNOLAKSICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZADOLAKSICEZRNOLAKSICA.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.labelZADOLAKSICEZRNOLAKSICA.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.labelZADOLAKSICEZRNOLAKSICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADMZOLAKSICE.Location = point;
            this.label1ZADMZOLAKSICE.Name = "label1ZADMZOLAKSICE";
            this.label1ZADMZOLAKSICE.TabIndex = 1;
            this.label1ZADMZOLAKSICE.Tag = "labelZADMZOLAKSICE";
            this.label1ZADMZOLAKSICE.Text = "Model zaduženja:";
            this.label1ZADMZOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1ZADMZOLAKSICE.AutoSize = true;
            this.label1ZADMZOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1ZADMZOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADMZOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1ZADMZOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.label1ZADMZOLAKSICE, 0, 5);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.label1ZADMZOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.label1ZADMZOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADMZOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADMZOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1ZADMZOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADMZOLAKSICE.Location = point;
            this.textZADMZOLAKSICE.Name = "textZADMZOLAKSICE";
            this.textZADMZOLAKSICE.Tag = "ZADMZOLAKSICE";
            this.textZADMZOLAKSICE.TabIndex = 0;
            this.textZADMZOLAKSICE.Anchor = AnchorStyles.Left;
            this.textZADMZOLAKSICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADMZOLAKSICE.ContextMenu = this.contextMenu1;
            this.textZADMZOLAKSICE.ReadOnly = false;
            this.textZADMZOLAKSICE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKOlaksica, "ZADMZOLAKSICE"));
            this.textZADMZOLAKSICE.Nullable = true;
            this.textZADMZOLAKSICE.MaxLength = 2;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.textZADMZOLAKSICE, 1, 5);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.textZADMZOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.textZADMZOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADMZOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textZADMZOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textZADMZOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADPZOLAKSICE.Location = point;
            this.label1ZADPZOLAKSICE.Name = "label1ZADPZOLAKSICE";
            this.label1ZADPZOLAKSICE.TabIndex = 1;
            this.label1ZADPZOLAKSICE.Tag = "labelZADPZOLAKSICE";
            this.label1ZADPZOLAKSICE.Text = "Poziv na broj zaduženja:";
            this.label1ZADPZOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1ZADPZOLAKSICE.AutoSize = true;
            this.label1ZADPZOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1ZADPZOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADPZOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1ZADPZOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.label1ZADPZOLAKSICE, 0, 6);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.label1ZADPZOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.label1ZADPZOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADPZOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADPZOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0xa7, 0x17);
            this.label1ZADPZOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADPZOLAKSICE.Location = point;
            this.textZADPZOLAKSICE.Name = "textZADPZOLAKSICE";
            this.textZADPZOLAKSICE.Tag = "ZADPZOLAKSICE";
            this.textZADPZOLAKSICE.TabIndex = 0;
            this.textZADPZOLAKSICE.Anchor = AnchorStyles.Left;
            this.textZADPZOLAKSICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADPZOLAKSICE.ContextMenu = this.contextMenu1;
            this.textZADPZOLAKSICE.ReadOnly = false;
            this.textZADPZOLAKSICE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKOlaksica, "ZADPZOLAKSICE"));
            this.textZADPZOLAKSICE.Nullable = true;
            this.textZADPZOLAKSICE.MaxLength = 0x16;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.textZADPZOLAKSICE, 1, 6);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.textZADPZOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.textZADPZOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADPZOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textZADPZOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textZADPZOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADMOOLAKSICE.Location = point;
            this.label1ZADMOOLAKSICE.Name = "label1ZADMOOLAKSICE";
            this.label1ZADMOOLAKSICE.TabIndex = 1;
            this.label1ZADMOOLAKSICE.Tag = "labelZADMOOLAKSICE";
            this.label1ZADMOOLAKSICE.Text = "Model odobrenja:";
            this.label1ZADMOOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1ZADMOOLAKSICE.AutoSize = true;
            this.label1ZADMOOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1ZADMOOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADMOOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1ZADMOOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.label1ZADMOOLAKSICE, 0, 7);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.label1ZADMOOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.label1ZADMOOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADMOOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADMOOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1ZADMOOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADMOOLAKSICE.Location = point;
            this.textZADMOOLAKSICE.Name = "textZADMOOLAKSICE";
            this.textZADMOOLAKSICE.Tag = "ZADMOOLAKSICE";
            this.textZADMOOLAKSICE.TabIndex = 0;
            this.textZADMOOLAKSICE.Anchor = AnchorStyles.Left;
            this.textZADMOOLAKSICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADMOOLAKSICE.ContextMenu = this.contextMenu1;
            this.textZADMOOLAKSICE.ReadOnly = false;
            this.textZADMOOLAKSICE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKOlaksica, "ZADMOOLAKSICE"));
            this.textZADMOOLAKSICE.Nullable = true;
            this.textZADMOOLAKSICE.MaxLength = 2;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.textZADMOOLAKSICE, 1, 7);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.textZADMOOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.textZADMOOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADMOOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textZADMOOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textZADMOOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADPOOLAKSICE.Location = point;
            this.label1ZADPOOLAKSICE.Name = "label1ZADPOOLAKSICE";
            this.label1ZADPOOLAKSICE.TabIndex = 1;
            this.label1ZADPOOLAKSICE.Tag = "labelZADPOOLAKSICE";
            this.label1ZADPOOLAKSICE.Text = "Poziv na broj odobrenja:";
            this.label1ZADPOOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1ZADPOOLAKSICE.AutoSize = true;
            this.label1ZADPOOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1ZADPOOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADPOOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1ZADPOOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.label1ZADPOOLAKSICE, 0, 8);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.label1ZADPOOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.label1ZADPOOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADPOOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADPOOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0xa7, 0x17);
            this.label1ZADPOOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADPOOLAKSICE.Location = point;
            this.textZADPOOLAKSICE.Name = "textZADPOOLAKSICE";
            this.textZADPOOLAKSICE.Tag = "ZADPOOLAKSICE";
            this.textZADPOOLAKSICE.TabIndex = 0;
            this.textZADPOOLAKSICE.Anchor = AnchorStyles.Left;
            this.textZADPOOLAKSICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADPOOLAKSICE.ContextMenu = this.contextMenu1;
            this.textZADPOOLAKSICE.ReadOnly = false;
            this.textZADPOOLAKSICE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKOlaksica, "ZADPOOLAKSICE"));
            this.textZADPOOLAKSICE.Nullable = true;
            this.textZADPOOLAKSICE.MaxLength = 0x16;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.textZADPOOLAKSICE, 1, 8);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.textZADPOOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.textZADPOOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADPOOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textZADPOOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textZADPOOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE.Location = point;
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE.Name = "label1ZADSIFRAOPISAPLACANJAOLAKSICE";
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE.TabIndex = 1;
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE.Tag = "labelZADSIFRAOPISAPLACANJAOLAKSICE";
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE.Text = "Šifra opisa plaćanja:";
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE.AutoSize = true;
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.label1ZADSIFRAOPISAPLACANJAOLAKSICE, 0, 9);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.label1ZADSIFRAOPISAPLACANJAOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.label1ZADSIFRAOPISAPLACANJAOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 0x17);
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADSIFRAOPISAPLACANJAOLAKSICE.Location = point;
            this.textZADSIFRAOPISAPLACANJAOLAKSICE.Name = "textZADSIFRAOPISAPLACANJAOLAKSICE";
            this.textZADSIFRAOPISAPLACANJAOLAKSICE.Tag = "ZADSIFRAOPISAPLACANJAOLAKSICE";
            this.textZADSIFRAOPISAPLACANJAOLAKSICE.TabIndex = 0;
            this.textZADSIFRAOPISAPLACANJAOLAKSICE.Anchor = AnchorStyles.Left;
            this.textZADSIFRAOPISAPLACANJAOLAKSICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADSIFRAOPISAPLACANJAOLAKSICE.ReadOnly = false;
            this.textZADSIFRAOPISAPLACANJAOLAKSICE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKOlaksica, "ZADSIFRAOPISAPLACANJAOLAKSICE"));
            this.textZADSIFRAOPISAPLACANJAOLAKSICE.MaxLength = 2;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.textZADSIFRAOPISAPLACANJAOLAKSICE, 1, 9);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.textZADSIFRAOPISAPLACANJAOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.textZADSIFRAOPISAPLACANJAOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADSIFRAOPISAPLACANJAOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textZADSIFRAOPISAPLACANJAOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textZADSIFRAOPISAPLACANJAOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADOPISPLACANJAOLAKSICE.Location = point;
            this.label1ZADOPISPLACANJAOLAKSICE.Name = "label1ZADOPISPLACANJAOLAKSICE";
            this.label1ZADOPISPLACANJAOLAKSICE.TabIndex = 1;
            this.label1ZADOPISPLACANJAOLAKSICE.Tag = "labelZADOPISPLACANJAOLAKSICE";
            this.label1ZADOPISPLACANJAOLAKSICE.Text = "Opis plaćanja:";
            this.label1ZADOPISPLACANJAOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1ZADOPISPLACANJAOLAKSICE.AutoSize = true;
            this.label1ZADOPISPLACANJAOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1ZADOPISPLACANJAOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADOPISPLACANJAOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1ZADOPISPLACANJAOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.label1ZADOPISPLACANJAOLAKSICE, 0, 10);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.label1ZADOPISPLACANJAOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.label1ZADOPISPLACANJAOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADOPISPLACANJAOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADOPISPLACANJAOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x67, 0x17);
            this.label1ZADOPISPLACANJAOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADOPISPLACANJAOLAKSICE.Location = point;
            this.textZADOPISPLACANJAOLAKSICE.Name = "textZADOPISPLACANJAOLAKSICE";
            this.textZADOPISPLACANJAOLAKSICE.Tag = "ZADOPISPLACANJAOLAKSICE";
            this.textZADOPISPLACANJAOLAKSICE.TabIndex = 0;
            this.textZADOPISPLACANJAOLAKSICE.Anchor = AnchorStyles.Left;
            this.textZADOPISPLACANJAOLAKSICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADOPISPLACANJAOLAKSICE.ReadOnly = false;
            this.textZADOPISPLACANJAOLAKSICE.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKOlaksica, "ZADOPISPLACANJAOLAKSICE"));
            this.textZADOPISPLACANJAOLAKSICE.MaxLength = 0x24;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.textZADOPISPLACANJAOLAKSICE, 1, 10);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.textZADOPISPLACANJAOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.textZADOPISPLACANJAOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADOPISPLACANJAOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textZADOPISPLACANJAOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textZADOPISPLACANJAOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADPOJEDINACNIPOZIV.Location = point;
            this.label1ZADPOJEDINACNIPOZIV.Name = "label1ZADPOJEDINACNIPOZIV";
            this.label1ZADPOJEDINACNIPOZIV.TabIndex = 1;
            this.label1ZADPOJEDINACNIPOZIV.Tag = "labelZADPOJEDINACNIPOZIV";
            this.label1ZADPOJEDINACNIPOZIV.Text = "Poziv na broj - disketa HZZO:";
            this.label1ZADPOJEDINACNIPOZIV.StyleSetName = "FieldUltraLabel";
            this.label1ZADPOJEDINACNIPOZIV.AutoSize = true;
            this.label1ZADPOJEDINACNIPOZIV.Anchor = AnchorStyles.Left;
            this.label1ZADPOJEDINACNIPOZIV.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADPOJEDINACNIPOZIV.Appearance.ForeColor = Color.Black;
            this.label1ZADPOJEDINACNIPOZIV.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.label1ZADPOJEDINACNIPOZIV, 0, 11);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.label1ZADPOJEDINACNIPOZIV, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.label1ZADPOJEDINACNIPOZIV, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADPOJEDINACNIPOZIV.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADPOJEDINACNIPOZIV.MinimumSize = size;
            size = new System.Drawing.Size(0xc4, 0x17);
            this.label1ZADPOJEDINACNIPOZIV.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADPOJEDINACNIPOZIV.Location = point;
            this.textZADPOJEDINACNIPOZIV.Name = "textZADPOJEDINACNIPOZIV";
            this.textZADPOJEDINACNIPOZIV.Tag = "ZADPOJEDINACNIPOZIV";
            this.textZADPOJEDINACNIPOZIV.TabIndex = 0;
            this.textZADPOJEDINACNIPOZIV.Anchor = AnchorStyles.Left;
            this.textZADPOJEDINACNIPOZIV.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADPOJEDINACNIPOZIV.ContextMenu = this.contextMenu1;
            this.textZADPOJEDINACNIPOZIV.ReadOnly = false;
            this.textZADPOJEDINACNIPOZIV.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKOlaksica, "ZADPOJEDINACNIPOZIV"));
            this.textZADPOJEDINACNIPOZIV.Nullable = true;
            this.textZADPOJEDINACNIPOZIV.MaxLength = 11;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.textZADPOJEDINACNIPOZIV, 1, 11);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.textZADPOJEDINACNIPOZIV, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.textZADPOJEDINACNIPOZIV, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADPOJEDINACNIPOZIV.Margin = padding;
            size = new System.Drawing.Size(0x5d, 0x16);
            this.textZADPOJEDINACNIPOZIV.MinimumSize = size;
            size = new System.Drawing.Size(0x5d, 0x16);
            this.textZADPOJEDINACNIPOZIV.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZADIZNOSOLAKSICE.Location = point;
            this.label1ZADIZNOSOLAKSICE.Name = "label1ZADIZNOSOLAKSICE";
            this.label1ZADIZNOSOLAKSICE.TabIndex = 1;
            this.label1ZADIZNOSOLAKSICE.Tag = "labelZADIZNOSOLAKSICE";
            this.label1ZADIZNOSOLAKSICE.Text = "Iznos olakšice:";
            this.label1ZADIZNOSOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1ZADIZNOSOLAKSICE.AutoSize = true;
            this.label1ZADIZNOSOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1ZADIZNOSOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZADIZNOSOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1ZADIZNOSOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.label1ZADIZNOSOLAKSICE, 0, 12);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.label1ZADIZNOSOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.label1ZADIZNOSOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZADIZNOSOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZADIZNOSOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x17);
            this.label1ZADIZNOSOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZADIZNOSOLAKSICE.Location = point;
            this.textZADIZNOSOLAKSICE.Name = "textZADIZNOSOLAKSICE";
            this.textZADIZNOSOLAKSICE.Tag = "ZADIZNOSOLAKSICE";
            this.textZADIZNOSOLAKSICE.TabIndex = 0;
            this.textZADIZNOSOLAKSICE.Anchor = AnchorStyles.Left;
            this.textZADIZNOSOLAKSICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZADIZNOSOLAKSICE.ReadOnly = false;
            this.textZADIZNOSOLAKSICE.PromptChar = ' ';
            this.textZADIZNOSOLAKSICE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZADIZNOSOLAKSICE.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKOlaksica, "ZADIZNOSOLAKSICE"));
            this.textZADIZNOSOLAKSICE.NumericType = NumericType.Double;
            this.textZADIZNOSOLAKSICE.MaxValue = 79228162514264337593543950335M;
            this.textZADIZNOSOLAKSICE.MinValue = -79228162514264337593543950335M;
            this.textZADIZNOSOLAKSICE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformRADNIKOlaksica.Controls.Add(this.textZADIZNOSOLAKSICE, 1, 12);
            this.layoutManagerformRADNIKOlaksica.SetColumnSpan(this.textZADIZNOSOLAKSICE, 1);
            this.layoutManagerformRADNIKOlaksica.SetRowSpan(this.textZADIZNOSOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZADIZNOSOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADIZNOSOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textZADIZNOSOLAKSICE.Size = size;
            this.Controls.Add(this.layoutManagerformRADNIKOlaksica);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRADNIKOlaksica;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RADNIKFormRADNIKOlaksicaUserControl";
            this.Text = " Olakšice";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RADNIKFormUserControl_Load);
            this.layoutManagerformRADNIKOlaksica.ResumeLayout(false);
            this.layoutManagerformRADNIKOlaksica.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRADNIKOlaksica).EndInit();
            ((ISupportInitialize) this.textZADOLAKSICEIDOLAKSICE).EndInit();
            ((ISupportInitialize) this.textZADMZOLAKSICE).EndInit();
            ((ISupportInitialize) this.textZADPZOLAKSICE).EndInit();
            ((ISupportInitialize) this.textZADMOOLAKSICE).EndInit();
            ((ISupportInitialize) this.textZADPOOLAKSICE).EndInit();
            ((ISupportInitialize) this.textZADSIFRAOPISAPLACANJAOLAKSICE).EndInit();
            ((ISupportInitialize) this.textZADOPISPLACANJAOLAKSICE).EndInit();
            ((ISupportInitialize) this.textZADPOJEDINACNIPOZIV).EndInit();
            ((ISupportInitialize) this.textZADIZNOSOLAKSICE).EndInit();
            this.dsRADNIKDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RADNIKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIKOlaksica, this.RADNIKController.WorkItem, this))
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
            this.label1ZADOLAKSICEIDOLAKSICE.Text = StringResources.RADNIKZADOLAKSICEIDOLAKSICEDescription;
            this.label1ZADOLAKSICENAZIVOLAKSICE.Text = StringResources.RADNIKZADOLAKSICENAZIVOLAKSICEDescription;
            this.label1ZADOLAKSICENAZIVTIPOLAKSICE.Text = StringResources.RADNIKZADOLAKSICENAZIVTIPOLAKSICEDescription;
            this.label1ZADOLAKSICEVBDIOLAKSICA.Text = StringResources.RADNIKZADOLAKSICEVBDIOLAKSICADescription;
            this.label1ZADOLAKSICEZRNOLAKSICA.Text = StringResources.RADNIKZADOLAKSICEZRNOLAKSICADescription;
            this.label1ZADMZOLAKSICE.Text = StringResources.RADNIKZADMZOLAKSICEDescription;
            this.label1ZADPZOLAKSICE.Text = StringResources.RADNIKZADPZOLAKSICEDescription;
            this.label1ZADMOOLAKSICE.Text = StringResources.RADNIKZADMOOLAKSICEDescription;
            this.label1ZADPOOLAKSICE.Text = StringResources.RADNIKZADPOOLAKSICEDescription;
            this.label1ZADSIFRAOPISAPLACANJAOLAKSICE.Text = StringResources.RADNIKZADSIFRAOPISAPLACANJAOLAKSICEDescription;
            this.label1ZADOPISPLACANJAOLAKSICE.Text = StringResources.RADNIKZADOPISPLACANJAOLAKSICEDescription;
            this.label1ZADPOJEDINACNIPOZIV.Text = StringResources.RADNIKZADPOJEDINACNIPOZIVDescription;
            this.label1ZADIZNOSOLAKSICE.Text = StringResources.RADNIKZADIZNOSOLAKSICEDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewGOOBRACUN")]
        public void NewGOOBRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.NewGOOBRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewOTISLI")]
        public void NewOTISLIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.NewOTISLI(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewZAPOSLENI")]
        public void NewZAPOSLENIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.NewZAPOSLENI(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RADNIKFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RADNIKRADNIKOlaksicaLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIKOlaksica|RADNIKOlaksica"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKOlaksica, "RADNIKOlaksica|RADNIKOlaksica");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("RADNIKOlaksicaSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetFocusInFirstField()
        {
            this.textZADOLAKSICEIDOLAKSICE.Focus();
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

        private void UpdateValuesOLAKSICEZADOLAKSICEIDOLAKSICE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceRADNIKOlaksica.Current).Row["ZADOLAKSICEIDOLAKSICE"] = RuntimeHelpers.GetObjectValue(result["IDOLAKSICE"]);
                ((DataRowView) this.bindingSourceRADNIKOlaksica.Current).Row["ZADOLAKSICENAZIVOLAKSICE"] = RuntimeHelpers.GetObjectValue(result["NAZIVOLAKSICE"]);
                ((DataRowView) this.bindingSourceRADNIKOlaksica.Current).Row["ZADOLAKSICEVBDIOLAKSICA"] = RuntimeHelpers.GetObjectValue(result["VBDIOLAKSICA"]);
                ((DataRowView) this.bindingSourceRADNIKOlaksica.Current).Row["ZADOLAKSICEZRNOLAKSICA"] = RuntimeHelpers.GetObjectValue(result["ZRNOLAKSICA"]);
                ((DataRowView) this.bindingSourceRADNIKOlaksica.Current).Row["ZADOLAKSICEPRIMATELJOLAKSICA1"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJOLAKSICA1"]);
                ((DataRowView) this.bindingSourceRADNIKOlaksica.Current).Row["ZADOLAKSICEPRIMATELJOLAKSICA2"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJOLAKSICA2"]);
                ((DataRowView) this.bindingSourceRADNIKOlaksica.Current).Row["ZADOLAKSICEPRIMATELJOLAKSICA3"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJOLAKSICA3"]);
                ((DataRowView) this.bindingSourceRADNIKOlaksica.Current).Row["ZADOLAKSICEIDGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(result["IDGRUPEOLAKSICA"]);
                ((DataRowView) this.bindingSourceRADNIKOlaksica.Current).Row["ZADOLAKSICEIDTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(result["IDTIPOLAKSICE"]);
                ((DataRowView) this.bindingSourceRADNIKOlaksica.Current).Row["ZADOLAKSICEMAXIMALNIIZNOSGRUPE"] = RuntimeHelpers.GetObjectValue(result["MAXIMALNIIZNOSGRUPE"]);
                ((DataRowView) this.bindingSourceRADNIKOlaksica.Current).Row["ZADOLAKSICENAZIVGRUPEOLAKSICA"] = RuntimeHelpers.GetObjectValue(result["NAZIVGRUPEOLAKSICA"]);
                ((DataRowView) this.bindingSourceRADNIKOlaksica.Current).Row["ZADOLAKSICENAZIVTIPOLAKSICE"] = RuntimeHelpers.GetObjectValue(result["NAZIVTIPOLAKSICE"]);
                this.bindingSourceRADNIKOlaksica.ResetCurrentItem();
            }
        }

        [LocalCommandHandler("ViewGOOBRACUN")]
        public void ViewGOOBRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.ViewGOOBRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewOTISLI")]
        public void ViewOTISLIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.ViewOTISLI(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewZAPOSLENI")]
        public void ViewZAPOSLENIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.ViewZAPOSLENI(this.m_CurrentRow);
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

        protected virtual UltraLabel label1ZADIZNOSOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADIZNOSOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADIZNOSOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1ZADMOOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADMOOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADMOOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1ZADMZOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADMZOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADMZOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1ZADOLAKSICEIDOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADOLAKSICEIDOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADOLAKSICEIDOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1ZADOLAKSICENAZIVOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADOLAKSICENAZIVOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADOLAKSICENAZIVOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1ZADOLAKSICENAZIVTIPOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADOLAKSICENAZIVTIPOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADOLAKSICENAZIVTIPOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1ZADOLAKSICEVBDIOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADOLAKSICEVBDIOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADOLAKSICEVBDIOLAKSICA = value;
            }
        }

        protected virtual UltraLabel label1ZADOLAKSICEZRNOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADOLAKSICEZRNOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADOLAKSICEZRNOLAKSICA = value;
            }
        }

        protected virtual UltraLabel label1ZADOPISPLACANJAOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADOPISPLACANJAOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADOPISPLACANJAOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1ZADPOJEDINACNIPOZIV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADPOJEDINACNIPOZIV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADPOJEDINACNIPOZIV = value;
            }
        }

        protected virtual UltraLabel label1ZADPOOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADPOOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADPOOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1ZADPZOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADPZOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADPZOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1ZADSIFRAOPISAPLACANJAOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZADSIFRAOPISAPLACANJAOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZADSIFRAOPISAPLACANJAOLAKSICE = value;
            }
        }

        protected virtual UltraLabel labelZADOLAKSICENAZIVOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZADOLAKSICENAZIVOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZADOLAKSICENAZIVOLAKSICE = value;
            }
        }

        protected virtual UltraLabel labelZADOLAKSICENAZIVTIPOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZADOLAKSICENAZIVTIPOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZADOLAKSICENAZIVTIPOLAKSICE = value;
            }
        }

        protected virtual UltraLabel labelZADOLAKSICEVBDIOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZADOLAKSICEVBDIOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZADOLAKSICEVBDIOLAKSICA = value;
            }
        }

        protected virtual UltraLabel labelZADOLAKSICEZRNOLAKSICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZADOLAKSICEZRNOLAKSICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZADOLAKSICEZRNOLAKSICA = value;
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.RADNIKController RADNIKController { get; set; }

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

        protected virtual UltraNumericEditor textZADIZNOSOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADIZNOSOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADIZNOSOLAKSICE = value;
            }
        }

        protected virtual UltraTextEditor textZADMOOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADMOOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADMOOLAKSICE = value;
            }
        }

        protected virtual UltraTextEditor textZADMZOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADMZOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADMZOLAKSICE = value;
            }
        }

        protected virtual UltraNumericEditor textZADOLAKSICEIDOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADOLAKSICEIDOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADOLAKSICEIDOLAKSICE = value;
            }
        }

        protected virtual UltraTextEditor textZADOPISPLACANJAOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADOPISPLACANJAOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADOPISPLACANJAOLAKSICE = value;
            }
        }

        protected virtual UltraTextEditor textZADPOJEDINACNIPOZIV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADPOJEDINACNIPOZIV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADPOJEDINACNIPOZIV = value;
            }
        }

        protected virtual UltraTextEditor textZADPOOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADPOOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADPOOLAKSICE = value;
            }
        }

        protected virtual UltraTextEditor textZADPZOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADPZOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADPZOLAKSICE = value;
            }
        }

        protected virtual UltraTextEditor textZADSIFRAOPISAPLACANJAOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZADSIFRAOPISAPLACANJAOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZADSIFRAOPISAPLACANJAOLAKSICE = value;
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

