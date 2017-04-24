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
    public class POREZFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDPOREZ")]
        private UltraLabel _label1IDPOREZ;
        [AccessedThroughProperty("label1MOPOREZ")]
        private UltraLabel _label1MOPOREZ;
        [AccessedThroughProperty("label1MZPOREZ")]
        private UltraLabel _label1MZPOREZ;
        [AccessedThroughProperty("label1NAZIVPOREZ")]
        private UltraLabel _label1NAZIVPOREZ;
        [AccessedThroughProperty("label1OPISPLACANJAPOREZ")]
        private UltraLabel _label1OPISPLACANJAPOREZ;
        [AccessedThroughProperty("label1POPOREZ")]
        private UltraLabel _label1POPOREZ;
        [AccessedThroughProperty("label1POREZMJESECNO")]
        private UltraLabel _label1POREZMJESECNO;
        [AccessedThroughProperty("label1PRIMATELJPOREZ1")]
        private UltraLabel _label1PRIMATELJPOREZ1;
        [AccessedThroughProperty("label1PRIMATELJPOREZ2")]
        private UltraLabel _label1PRIMATELJPOREZ2;
        [AccessedThroughProperty("label1PZPOREZ")]
        private UltraLabel _label1PZPOREZ;
        [AccessedThroughProperty("label1SIFRAOPISAPLACANJAPOREZ")]
        private UltraLabel _label1SIFRAOPISAPLACANJAPOREZ;
        [AccessedThroughProperty("label1STOPAPOREZA")]
        private UltraLabel _label1STOPAPOREZA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDPOREZ")]
        private UltraNumericEditor _textIDPOREZ;
        [AccessedThroughProperty("textMOPOREZ")]
        private UltraTextEditor _textMOPOREZ;
        [AccessedThroughProperty("textMZPOREZ")]
        private UltraTextEditor _textMZPOREZ;
        [AccessedThroughProperty("textNAZIVPOREZ")]
        private UltraTextEditor _textNAZIVPOREZ;
        [AccessedThroughProperty("textOPISPLACANJAPOREZ")]
        private UltraTextEditor _textOPISPLACANJAPOREZ;
        [AccessedThroughProperty("textPOPOREZ")]
        private UltraTextEditor _textPOPOREZ;
        [AccessedThroughProperty("textPOREZMJESECNO")]
        private UltraNumericEditor _textPOREZMJESECNO;
        [AccessedThroughProperty("textPRIMATELJPOREZ1")]
        private UltraTextEditor _textPRIMATELJPOREZ1;
        [AccessedThroughProperty("textPRIMATELJPOREZ2")]
        private UltraTextEditor _textPRIMATELJPOREZ2;
        [AccessedThroughProperty("textPZPOREZ")]
        private UltraTextEditor _textPZPOREZ;
        [AccessedThroughProperty("textSIFRAOPISAPLACANJAPOREZ")]
        private UltraTextEditor _textSIFRAOPISAPLACANJAPOREZ;
        [AccessedThroughProperty("textSTOPAPOREZA")]
        private UltraNumericEditor _textSTOPAPOREZA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourcePOREZ;
        private IContainer components = null;
        private POREZDataSet dsPOREZDataSet1;
        protected TableLayoutPanel layoutManagerformPOREZ;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private POREZDataSet.POREZRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "POREZ";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.POREZDescription;
        private DeklaritMode m_Mode;

        public POREZFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourcePOREZ.DataSource = this.POREZController.DataSet;
            this.dsPOREZDataSet1 = this.POREZController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            this.m_BaseMethods.ContextMenu1PopupBase(this.contextMenu1, this.m_CurrentRow);
        }

        [LocalCommandHandler("DeleteInstance")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.dsPOREZDataSet1.POREZ.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ((DataRow) enumerator.Current).Delete();
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                if (this.POREZController.Update(this))
                {
                    this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "POREZ", this.m_Mode, this.dsPOREZDataSet1, this.dsPOREZDataSet1.POREZ.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsPOREZDataSet1.POREZ[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (POREZDataSet.POREZRow) ((DataRowView) this.bindingSourcePOREZ.AddNew()).Row;
                foreach (string str in DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, foreignKeys))
                {
                    this.m_BaseMethods.SetReadOnly(str, true);
                    this.m_BaseMethods.GetLabelControl(str).Visible = false;
                    this.m_BaseMethods.GetControl(str).Visible = false;
                }
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(POREZFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourcePOREZ = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePOREZ).BeginInit();
            this.layoutManagerformPOREZ = new TableLayoutPanel();
            this.layoutManagerformPOREZ.SuspendLayout();
            this.layoutManagerformPOREZ.AutoSize = true;
            this.layoutManagerformPOREZ.Dock = DockStyle.Fill;
            this.layoutManagerformPOREZ.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPOREZ.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPOREZ.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPOREZ.Size = size;
            this.layoutManagerformPOREZ.ColumnCount = 2;
            this.layoutManagerformPOREZ.RowCount = 13;
            this.layoutManagerformPOREZ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPOREZ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformPOREZ.RowStyles.Add(new RowStyle());
            this.label1IDPOREZ = new UltraLabel();
            this.textIDPOREZ = new UltraNumericEditor();
            this.label1NAZIVPOREZ = new UltraLabel();
            this.textNAZIVPOREZ = new UltraTextEditor();
            this.label1POREZMJESECNO = new UltraLabel();
            this.textPOREZMJESECNO = new UltraNumericEditor();
            this.label1STOPAPOREZA = new UltraLabel();
            this.textSTOPAPOREZA = new UltraNumericEditor();
            this.label1MOPOREZ = new UltraLabel();
            this.textMOPOREZ = new UltraTextEditor();
            this.label1POPOREZ = new UltraLabel();
            this.textPOPOREZ = new UltraTextEditor();
            this.label1MZPOREZ = new UltraLabel();
            this.textMZPOREZ = new UltraTextEditor();
            this.label1PZPOREZ = new UltraLabel();
            this.textPZPOREZ = new UltraTextEditor();
            this.label1PRIMATELJPOREZ1 = new UltraLabel();
            this.textPRIMATELJPOREZ1 = new UltraTextEditor();
            this.label1PRIMATELJPOREZ2 = new UltraLabel();
            this.textPRIMATELJPOREZ2 = new UltraTextEditor();
            this.label1SIFRAOPISAPLACANJAPOREZ = new UltraLabel();
            this.textSIFRAOPISAPLACANJAPOREZ = new UltraTextEditor();
            this.label1OPISPLACANJAPOREZ = new UltraLabel();
            this.textOPISPLACANJAPOREZ = new UltraTextEditor();
            ((ISupportInitialize) this.textIDPOREZ).BeginInit();
            ((ISupportInitialize) this.textNAZIVPOREZ).BeginInit();
            ((ISupportInitialize) this.textPOREZMJESECNO).BeginInit();
            ((ISupportInitialize) this.textSTOPAPOREZA).BeginInit();
            ((ISupportInitialize) this.textMOPOREZ).BeginInit();
            ((ISupportInitialize) this.textPOPOREZ).BeginInit();
            ((ISupportInitialize) this.textMZPOREZ).BeginInit();
            ((ISupportInitialize) this.textPZPOREZ).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJPOREZ1).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJPOREZ2).BeginInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJAPOREZ).BeginInit();
            ((ISupportInitialize) this.textOPISPLACANJAPOREZ).BeginInit();
            this.dsPOREZDataSet1 = new POREZDataSet();
            this.dsPOREZDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsPOREZDataSet1.DataSetName = "dsPOREZ";
            this.dsPOREZDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourcePOREZ.DataSource = this.dsPOREZDataSet1;
            this.bindingSourcePOREZ.DataMember = "POREZ";
            ((ISupportInitialize) this.bindingSourcePOREZ).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDPOREZ.Location = point;
            this.label1IDPOREZ.Name = "label1IDPOREZ";
            this.label1IDPOREZ.TabIndex = 1;
            this.label1IDPOREZ.Tag = "labelIDPOREZ";
            this.label1IDPOREZ.Text = "Šifra poreza:";
            this.label1IDPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1IDPOREZ.AutoSize = true;
            this.label1IDPOREZ.Anchor = AnchorStyles.Left;
            this.label1IDPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDPOREZ.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDPOREZ.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDPOREZ.ImageSize = size;
            this.label1IDPOREZ.Appearance.ForeColor = Color.Black;
            this.label1IDPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformPOREZ.Controls.Add(this.label1IDPOREZ, 0, 0);
            this.layoutManagerformPOREZ.SetColumnSpan(this.label1IDPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.label1IDPOREZ, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x5b, 0x17);
            this.label1IDPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDPOREZ.Location = point;
            this.textIDPOREZ.Name = "textIDPOREZ";
            this.textIDPOREZ.Tag = "IDPOREZ";
            this.textIDPOREZ.TabIndex = 0;
            this.textIDPOREZ.Anchor = AnchorStyles.Left;
            this.textIDPOREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDPOREZ.ReadOnly = false;
            this.textIDPOREZ.PromptChar = ' ';
            this.textIDPOREZ.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDPOREZ.DataBindings.Add(new Binding("Value", this.bindingSourcePOREZ, "IDPOREZ"));
            this.textIDPOREZ.NumericType = NumericType.Integer;
            this.textIDPOREZ.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformPOREZ.Controls.Add(this.textIDPOREZ, 1, 0);
            this.layoutManagerformPOREZ.SetColumnSpan(this.textIDPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.textIDPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDPOREZ.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVPOREZ.Location = point;
            this.label1NAZIVPOREZ.Name = "label1NAZIVPOREZ";
            this.label1NAZIVPOREZ.TabIndex = 1;
            this.label1NAZIVPOREZ.Tag = "labelNAZIVPOREZ";
            this.label1NAZIVPOREZ.Text = "Naziv poreza:";
            this.label1NAZIVPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVPOREZ.AutoSize = true;
            this.label1NAZIVPOREZ.Anchor = AnchorStyles.Left;
            this.label1NAZIVPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVPOREZ.Appearance.ForeColor = Color.Black;
            this.label1NAZIVPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformPOREZ.Controls.Add(this.label1NAZIVPOREZ, 0, 1);
            this.layoutManagerformPOREZ.SetColumnSpan(this.label1NAZIVPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.label1NAZIVPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x63, 0x17);
            this.label1NAZIVPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVPOREZ.Location = point;
            this.textNAZIVPOREZ.Name = "textNAZIVPOREZ";
            this.textNAZIVPOREZ.Tag = "NAZIVPOREZ";
            this.textNAZIVPOREZ.TabIndex = 0;
            this.textNAZIVPOREZ.Anchor = AnchorStyles.Left;
            this.textNAZIVPOREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVPOREZ.ReadOnly = false;
            this.textNAZIVPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourcePOREZ, "NAZIVPOREZ"));
            this.textNAZIVPOREZ.MaxLength = 50;
            this.layoutManagerformPOREZ.Controls.Add(this.textNAZIVPOREZ, 1, 1);
            this.layoutManagerformPOREZ.SetColumnSpan(this.textNAZIVPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.textNAZIVPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVPOREZ.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POREZMJESECNO.Location = point;
            this.label1POREZMJESECNO.Name = "label1POREZMJESECNO";
            this.label1POREZMJESECNO.TabIndex = 1;
            this.label1POREZMJESECNO.Tag = "labelPOREZMJESECNO";
            this.label1POREZMJESECNO.Text = "Maks. mjesečni iznos osnovice:";
            this.label1POREZMJESECNO.StyleSetName = "FieldUltraLabel";
            this.label1POREZMJESECNO.AutoSize = true;
            this.label1POREZMJESECNO.Anchor = AnchorStyles.Left;
            this.label1POREZMJESECNO.Appearance.TextVAlign = VAlign.Middle;
            this.label1POREZMJESECNO.Appearance.ForeColor = Color.Black;
            this.label1POREZMJESECNO.BackColor = Color.Transparent;
            this.layoutManagerformPOREZ.Controls.Add(this.label1POREZMJESECNO, 0, 2);
            this.layoutManagerformPOREZ.SetColumnSpan(this.label1POREZMJESECNO, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.label1POREZMJESECNO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POREZMJESECNO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POREZMJESECNO.MinimumSize = size;
            size = new System.Drawing.Size(0xd0, 0x17);
            this.label1POREZMJESECNO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOREZMJESECNO.Location = point;
            this.textPOREZMJESECNO.Name = "textPOREZMJESECNO";
            this.textPOREZMJESECNO.Tag = "POREZMJESECNO";
            this.textPOREZMJESECNO.TabIndex = 0;
            this.textPOREZMJESECNO.Anchor = AnchorStyles.Left;
            this.textPOREZMJESECNO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOREZMJESECNO.ReadOnly = false;
            this.textPOREZMJESECNO.PromptChar = ' ';
            this.textPOREZMJESECNO.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPOREZMJESECNO.DataBindings.Add(new Binding("Value", this.bindingSourcePOREZ, "POREZMJESECNO"));
            this.textPOREZMJESECNO.NumericType = NumericType.Double;
            this.textPOREZMJESECNO.MaxValue = 79228162514264337593543950335M;
            this.textPOREZMJESECNO.MinValue = -79228162514264337593543950335M;
            this.textPOREZMJESECNO.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformPOREZ.Controls.Add(this.textPOREZMJESECNO, 1, 2);
            this.layoutManagerformPOREZ.SetColumnSpan(this.textPOREZMJESECNO, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.textPOREZMJESECNO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOREZMJESECNO.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textPOREZMJESECNO.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textPOREZMJESECNO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1STOPAPOREZA.Location = point;
            this.label1STOPAPOREZA.Name = "label1STOPAPOREZA";
            this.label1STOPAPOREZA.TabIndex = 1;
            this.label1STOPAPOREZA.Tag = "labelSTOPAPOREZA";
            this.label1STOPAPOREZA.Text = "Stopa poreza:";
            this.label1STOPAPOREZA.StyleSetName = "FieldUltraLabel";
            this.label1STOPAPOREZA.AutoSize = true;
            this.label1STOPAPOREZA.Anchor = AnchorStyles.Left;
            this.label1STOPAPOREZA.Appearance.TextVAlign = VAlign.Middle;
            this.label1STOPAPOREZA.Appearance.ForeColor = Color.Black;
            this.label1STOPAPOREZA.BackColor = Color.Transparent;
            this.layoutManagerformPOREZ.Controls.Add(this.label1STOPAPOREZA, 0, 3);
            this.layoutManagerformPOREZ.SetColumnSpan(this.label1STOPAPOREZA, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.label1STOPAPOREZA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1STOPAPOREZA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1STOPAPOREZA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x17);
            this.label1STOPAPOREZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSTOPAPOREZA.Location = point;
            this.textSTOPAPOREZA.Name = "textSTOPAPOREZA";
            this.textSTOPAPOREZA.Tag = "STOPAPOREZA";
            this.textSTOPAPOREZA.TabIndex = 0;
            this.textSTOPAPOREZA.Anchor = AnchorStyles.Left;
            this.textSTOPAPOREZA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSTOPAPOREZA.ReadOnly = false;
            this.textSTOPAPOREZA.PromptChar = ' ';
            this.textSTOPAPOREZA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textSTOPAPOREZA.DataBindings.Add(new Binding("Value", this.bindingSourcePOREZ, "STOPAPOREZA"));
            this.textSTOPAPOREZA.NumericType = NumericType.Double;
            this.textSTOPAPOREZA.MaxValue = 79228162514264337593543950335M;
            this.textSTOPAPOREZA.MinValue = -79228162514264337593543950335M;
            this.textSTOPAPOREZA.MaskInput = "{LOC}-nn.nn";
            this.layoutManagerformPOREZ.Controls.Add(this.textSTOPAPOREZA, 1, 3);
            this.layoutManagerformPOREZ.SetColumnSpan(this.textSTOPAPOREZA, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.textSTOPAPOREZA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSTOPAPOREZA.Margin = padding;
            size = new System.Drawing.Size(0x30, 0x16);
            this.textSTOPAPOREZA.MinimumSize = size;
            size = new System.Drawing.Size(0x30, 0x16);
            this.textSTOPAPOREZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MOPOREZ.Location = point;
            this.label1MOPOREZ.Name = "label1MOPOREZ";
            this.label1MOPOREZ.TabIndex = 1;
            this.label1MOPOREZ.Tag = "labelMOPOREZ";
            this.label1MOPOREZ.Text = "Model odobrenja poreza:";
            this.label1MOPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1MOPOREZ.AutoSize = true;
            this.label1MOPOREZ.Anchor = AnchorStyles.Left;
            this.label1MOPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1MOPOREZ.Appearance.ForeColor = Color.Black;
            this.label1MOPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformPOREZ.Controls.Add(this.label1MOPOREZ, 0, 4);
            this.layoutManagerformPOREZ.SetColumnSpan(this.label1MOPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.label1MOPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MOPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MOPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0xa9, 0x17);
            this.label1MOPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMOPOREZ.Location = point;
            this.textMOPOREZ.Name = "textMOPOREZ";
            this.textMOPOREZ.Tag = "MOPOREZ";
            this.textMOPOREZ.TabIndex = 0;
            this.textMOPOREZ.Anchor = AnchorStyles.Left;
            this.textMOPOREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMOPOREZ.ReadOnly = false;
            this.textMOPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourcePOREZ, "MOPOREZ"));
            this.textMOPOREZ.MaxLength = 2;
            this.layoutManagerformPOREZ.Controls.Add(this.textMOPOREZ, 1, 4);
            this.layoutManagerformPOREZ.SetColumnSpan(this.textMOPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.textMOPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMOPOREZ.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMOPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMOPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POPOREZ.Location = point;
            this.label1POPOREZ.Name = "label1POPOREZ";
            this.label1POPOREZ.TabIndex = 1;
            this.label1POPOREZ.Tag = "labelPOPOREZ";
            this.label1POPOREZ.Text = "Poziv na broj odobrenja poreza:";
            this.label1POPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1POPOREZ.AutoSize = true;
            this.label1POPOREZ.Anchor = AnchorStyles.Left;
            this.label1POPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1POPOREZ.Appearance.ForeColor = Color.Black;
            this.label1POPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformPOREZ.Controls.Add(this.label1POPOREZ, 0, 5);
            this.layoutManagerformPOREZ.SetColumnSpan(this.label1POPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.label1POPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0xd5, 0x17);
            this.label1POPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOPOREZ.Location = point;
            this.textPOPOREZ.Name = "textPOPOREZ";
            this.textPOPOREZ.Tag = "POPOREZ";
            this.textPOPOREZ.TabIndex = 0;
            this.textPOPOREZ.Anchor = AnchorStyles.Left;
            this.textPOPOREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOPOREZ.ReadOnly = false;
            this.textPOPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourcePOREZ, "POPOREZ"));
            this.textPOPOREZ.MaxLength = 0x16;
            this.layoutManagerformPOREZ.Controls.Add(this.textPOPOREZ, 1, 5);
            this.layoutManagerformPOREZ.SetColumnSpan(this.textPOPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.textPOPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOPOREZ.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MZPOREZ.Location = point;
            this.label1MZPOREZ.Name = "label1MZPOREZ";
            this.label1MZPOREZ.TabIndex = 1;
            this.label1MZPOREZ.Tag = "labelMZPOREZ";
            this.label1MZPOREZ.Text = "Model zaduženja poreza:";
            this.label1MZPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1MZPOREZ.AutoSize = true;
            this.label1MZPOREZ.Anchor = AnchorStyles.Left;
            this.label1MZPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1MZPOREZ.Appearance.ForeColor = Color.Black;
            this.label1MZPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformPOREZ.Controls.Add(this.label1MZPOREZ, 0, 6);
            this.layoutManagerformPOREZ.SetColumnSpan(this.label1MZPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.label1MZPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MZPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MZPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0xa9, 0x17);
            this.label1MZPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMZPOREZ.Location = point;
            this.textMZPOREZ.Name = "textMZPOREZ";
            this.textMZPOREZ.Tag = "MZPOREZ";
            this.textMZPOREZ.TabIndex = 0;
            this.textMZPOREZ.Anchor = AnchorStyles.Left;
            this.textMZPOREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMZPOREZ.ContextMenu = this.contextMenu1;
            this.textMZPOREZ.ReadOnly = false;
            this.textMZPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourcePOREZ, "MZPOREZ"));
            this.textMZPOREZ.Nullable = true;
            this.textMZPOREZ.MaxLength = 2;
            this.layoutManagerformPOREZ.Controls.Add(this.textMZPOREZ, 1, 6);
            this.layoutManagerformPOREZ.SetColumnSpan(this.textMZPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.textMZPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMZPOREZ.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMZPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMZPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PZPOREZ.Location = point;
            this.label1PZPOREZ.Name = "label1PZPOREZ";
            this.label1PZPOREZ.TabIndex = 1;
            this.label1PZPOREZ.Tag = "labelPZPOREZ";
            this.label1PZPOREZ.Text = "Poziv na broj zaduženja poreza:";
            this.label1PZPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1PZPOREZ.AutoSize = true;
            this.label1PZPOREZ.Anchor = AnchorStyles.Left;
            this.label1PZPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1PZPOREZ.Appearance.ForeColor = Color.Black;
            this.label1PZPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformPOREZ.Controls.Add(this.label1PZPOREZ, 0, 7);
            this.layoutManagerformPOREZ.SetColumnSpan(this.label1PZPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.label1PZPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PZPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PZPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0xd4, 0x17);
            this.label1PZPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPZPOREZ.Location = point;
            this.textPZPOREZ.Name = "textPZPOREZ";
            this.textPZPOREZ.Tag = "PZPOREZ";
            this.textPZPOREZ.TabIndex = 0;
            this.textPZPOREZ.Anchor = AnchorStyles.Left;
            this.textPZPOREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPZPOREZ.ContextMenu = this.contextMenu1;
            this.textPZPOREZ.ReadOnly = false;
            this.textPZPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourcePOREZ, "PZPOREZ"));
            this.textPZPOREZ.Nullable = true;
            this.textPZPOREZ.MaxLength = 0x16;
            this.layoutManagerformPOREZ.Controls.Add(this.textPZPOREZ, 1, 7);
            this.layoutManagerformPOREZ.SetColumnSpan(this.textPZPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.textPZPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPZPOREZ.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPZPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPZPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJPOREZ1.Location = point;
            this.label1PRIMATELJPOREZ1.Name = "label1PRIMATELJPOREZ1";
            this.label1PRIMATELJPOREZ1.TabIndex = 1;
            this.label1PRIMATELJPOREZ1.Tag = "labelPRIMATELJPOREZ1";
            this.label1PRIMATELJPOREZ1.Text = "Primatelj poreza (1):";
            this.label1PRIMATELJPOREZ1.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJPOREZ1.AutoSize = true;
            this.label1PRIMATELJPOREZ1.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJPOREZ1.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJPOREZ1.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJPOREZ1.BackColor = Color.Transparent;
            this.layoutManagerformPOREZ.Controls.Add(this.label1PRIMATELJPOREZ1, 0, 8);
            this.layoutManagerformPOREZ.SetColumnSpan(this.label1PRIMATELJPOREZ1, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.label1PRIMATELJPOREZ1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJPOREZ1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJPOREZ1.MinimumSize = size;
            size = new System.Drawing.Size(0x90, 0x17);
            this.label1PRIMATELJPOREZ1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJPOREZ1.Location = point;
            this.textPRIMATELJPOREZ1.Name = "textPRIMATELJPOREZ1";
            this.textPRIMATELJPOREZ1.Tag = "PRIMATELJPOREZ1";
            this.textPRIMATELJPOREZ1.TabIndex = 0;
            this.textPRIMATELJPOREZ1.Anchor = AnchorStyles.Left;
            this.textPRIMATELJPOREZ1.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJPOREZ1.ReadOnly = false;
            this.textPRIMATELJPOREZ1.DataBindings.Add(new Binding("Text", this.bindingSourcePOREZ, "PRIMATELJPOREZ1"));
            this.textPRIMATELJPOREZ1.MaxLength = 20;
            this.layoutManagerformPOREZ.Controls.Add(this.textPRIMATELJPOREZ1, 1, 8);
            this.layoutManagerformPOREZ.SetColumnSpan(this.textPRIMATELJPOREZ1, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.textPRIMATELJPOREZ1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJPOREZ1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJPOREZ1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJPOREZ1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJPOREZ2.Location = point;
            this.label1PRIMATELJPOREZ2.Name = "label1PRIMATELJPOREZ2";
            this.label1PRIMATELJPOREZ2.TabIndex = 1;
            this.label1PRIMATELJPOREZ2.Tag = "labelPRIMATELJPOREZ2";
            this.label1PRIMATELJPOREZ2.Text = "Primatelj poreza (2):";
            this.label1PRIMATELJPOREZ2.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJPOREZ2.AutoSize = true;
            this.label1PRIMATELJPOREZ2.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJPOREZ2.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJPOREZ2.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJPOREZ2.BackColor = Color.Transparent;
            this.layoutManagerformPOREZ.Controls.Add(this.label1PRIMATELJPOREZ2, 0, 9);
            this.layoutManagerformPOREZ.SetColumnSpan(this.label1PRIMATELJPOREZ2, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.label1PRIMATELJPOREZ2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJPOREZ2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJPOREZ2.MinimumSize = size;
            size = new System.Drawing.Size(0x90, 0x17);
            this.label1PRIMATELJPOREZ2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJPOREZ2.Location = point;
            this.textPRIMATELJPOREZ2.Name = "textPRIMATELJPOREZ2";
            this.textPRIMATELJPOREZ2.Tag = "PRIMATELJPOREZ2";
            this.textPRIMATELJPOREZ2.TabIndex = 0;
            this.textPRIMATELJPOREZ2.Anchor = AnchorStyles.Left;
            this.textPRIMATELJPOREZ2.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJPOREZ2.ContextMenu = this.contextMenu1;
            this.textPRIMATELJPOREZ2.ReadOnly = false;
            this.textPRIMATELJPOREZ2.DataBindings.Add(new Binding("Text", this.bindingSourcePOREZ, "PRIMATELJPOREZ2"));
            this.textPRIMATELJPOREZ2.Nullable = true;
            this.textPRIMATELJPOREZ2.MaxLength = 20;
            this.layoutManagerformPOREZ.Controls.Add(this.textPRIMATELJPOREZ2, 1, 9);
            this.layoutManagerformPOREZ.SetColumnSpan(this.textPRIMATELJPOREZ2, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.textPRIMATELJPOREZ2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJPOREZ2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJPOREZ2.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJPOREZ2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAOPISAPLACANJAPOREZ.Location = point;
            this.label1SIFRAOPISAPLACANJAPOREZ.Name = "label1SIFRAOPISAPLACANJAPOREZ";
            this.label1SIFRAOPISAPLACANJAPOREZ.TabIndex = 1;
            this.label1SIFRAOPISAPLACANJAPOREZ.Tag = "labelSIFRAOPISAPLACANJAPOREZ";
            this.label1SIFRAOPISAPLACANJAPOREZ.Text = "Šifra opisa plaćanja poreza:";
            this.label1SIFRAOPISAPLACANJAPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAOPISAPLACANJAPOREZ.AutoSize = true;
            this.label1SIFRAOPISAPLACANJAPOREZ.Anchor = AnchorStyles.Left;
            this.label1SIFRAOPISAPLACANJAPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAOPISAPLACANJAPOREZ.Appearance.ForeColor = Color.Black;
            this.label1SIFRAOPISAPLACANJAPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformPOREZ.Controls.Add(this.label1SIFRAOPISAPLACANJAPOREZ, 0, 10);
            this.layoutManagerformPOREZ.SetColumnSpan(this.label1SIFRAOPISAPLACANJAPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.label1SIFRAOPISAPLACANJAPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAOPISAPLACANJAPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAOPISAPLACANJAPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0xba, 0x17);
            this.label1SIFRAOPISAPLACANJAPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSIFRAOPISAPLACANJAPOREZ.Location = point;
            this.textSIFRAOPISAPLACANJAPOREZ.Name = "textSIFRAOPISAPLACANJAPOREZ";
            this.textSIFRAOPISAPLACANJAPOREZ.Tag = "SIFRAOPISAPLACANJAPOREZ";
            this.textSIFRAOPISAPLACANJAPOREZ.TabIndex = 0;
            this.textSIFRAOPISAPLACANJAPOREZ.Anchor = AnchorStyles.Left;
            this.textSIFRAOPISAPLACANJAPOREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSIFRAOPISAPLACANJAPOREZ.ReadOnly = false;
            this.textSIFRAOPISAPLACANJAPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourcePOREZ, "SIFRAOPISAPLACANJAPOREZ"));
            this.textSIFRAOPISAPLACANJAPOREZ.MaxLength = 2;
            this.layoutManagerformPOREZ.Controls.Add(this.textSIFRAOPISAPLACANJAPOREZ, 1, 10);
            this.layoutManagerformPOREZ.SetColumnSpan(this.textSIFRAOPISAPLACANJAPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.textSIFRAOPISAPLACANJAPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSIFRAOPISAPLACANJAPOREZ.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJAPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJAPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISPLACANJAPOREZ.Location = point;
            this.label1OPISPLACANJAPOREZ.Name = "label1OPISPLACANJAPOREZ";
            this.label1OPISPLACANJAPOREZ.TabIndex = 1;
            this.label1OPISPLACANJAPOREZ.Tag = "labelOPISPLACANJAPOREZ";
            this.label1OPISPLACANJAPOREZ.Text = "Opis plaćanja poreza:";
            this.label1OPISPLACANJAPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1OPISPLACANJAPOREZ.AutoSize = true;
            this.label1OPISPLACANJAPOREZ.Anchor = AnchorStyles.Left;
            this.label1OPISPLACANJAPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISPLACANJAPOREZ.Appearance.ForeColor = Color.Black;
            this.label1OPISPLACANJAPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformPOREZ.Controls.Add(this.label1OPISPLACANJAPOREZ, 0, 11);
            this.layoutManagerformPOREZ.SetColumnSpan(this.label1OPISPLACANJAPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.label1OPISPLACANJAPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISPLACANJAPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISPLACANJAPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x94, 0x17);
            this.label1OPISPLACANJAPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPISPLACANJAPOREZ.Location = point;
            this.textOPISPLACANJAPOREZ.Name = "textOPISPLACANJAPOREZ";
            this.textOPISPLACANJAPOREZ.Tag = "OPISPLACANJAPOREZ";
            this.textOPISPLACANJAPOREZ.TabIndex = 0;
            this.textOPISPLACANJAPOREZ.Anchor = AnchorStyles.Left;
            this.textOPISPLACANJAPOREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPISPLACANJAPOREZ.ReadOnly = false;
            this.textOPISPLACANJAPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourcePOREZ, "OPISPLACANJAPOREZ"));
            this.textOPISPLACANJAPOREZ.MaxLength = 0x24;
            this.layoutManagerformPOREZ.Controls.Add(this.textOPISPLACANJAPOREZ, 1, 11);
            this.layoutManagerformPOREZ.SetColumnSpan(this.textOPISPLACANJAPOREZ, 1);
            this.layoutManagerformPOREZ.SetRowSpan(this.textOPISPLACANJAPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPISPLACANJAPOREZ.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJAPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJAPOREZ.Size = size;
            this.Controls.Add(this.layoutManagerformPOREZ);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourcePOREZ;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "POREZFormUserControl";
            this.Text = "Porezi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.POREZFormUserControl_Load);
            this.layoutManagerformPOREZ.ResumeLayout(false);
            this.layoutManagerformPOREZ.PerformLayout();
            ((ISupportInitialize) this.bindingSourcePOREZ).EndInit();
            ((ISupportInitialize) this.textIDPOREZ).EndInit();
            ((ISupportInitialize) this.textNAZIVPOREZ).EndInit();
            ((ISupportInitialize) this.textPOREZMJESECNO).EndInit();
            ((ISupportInitialize) this.textSTOPAPOREZA).EndInit();
            ((ISupportInitialize) this.textMOPOREZ).EndInit();
            ((ISupportInitialize) this.textPOPOREZ).EndInit();
            ((ISupportInitialize) this.textMZPOREZ).EndInit();
            ((ISupportInitialize) this.textPZPOREZ).EndInit();
            ((ISupportInitialize) this.textPRIMATELJPOREZ1).EndInit();
            ((ISupportInitialize) this.textPRIMATELJPOREZ2).EndInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJAPOREZ).EndInit();
            ((ISupportInitialize) this.textOPISPLACANJAPOREZ).EndInit();
            this.dsPOREZDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.POREZController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourcePOREZ, this.POREZController.WorkItem, this))
            {
                return false;
            }
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void Localize()
        {
            this.label1IDPOREZ.Text = StringResources.POREZIDPOREZDescription;
            this.label1NAZIVPOREZ.Text = StringResources.POREZNAZIVPOREZDescription;
            this.label1POREZMJESECNO.Text = StringResources.POREZPOREZMJESECNODescription;
            this.label1STOPAPOREZA.Text = StringResources.POREZSTOPAPOREZADescription;
            this.label1MOPOREZ.Text = StringResources.POREZMOPOREZDescription;
            this.label1POPOREZ.Text = StringResources.POREZPOPOREZDescription;
            this.label1MZPOREZ.Text = StringResources.POREZMZPOREZDescription;
            this.label1PZPOREZ.Text = StringResources.POREZPZPOREZDescription;
            this.label1PRIMATELJPOREZ1.Text = StringResources.POREZPRIMATELJPOREZ1Description;
            this.label1PRIMATELJPOREZ2.Text = StringResources.POREZPRIMATELJPOREZ2Description;
            this.label1SIFRAOPISAPLACANJAPOREZ.Text = StringResources.POREZSIFRAOPISAPLACANJAPOREZDescription;
            this.label1OPISPLACANJAPOREZ.Text = StringResources.POREZOPISPLACANJAPOREZDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void POREZFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.POREZDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.POREZController.WorkItem.Items.Contains("POREZ|POREZ"))
            {
                this.POREZController.WorkItem.Items.Add(this.bindingSourcePOREZ, "POREZ|POREZ");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsPOREZDataSet1.POREZ.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.m_Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.m_Mode;
                this.m_BaseMethods.FormLoadStyle();
            }
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.POREZController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.POREZController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.POREZController.Update(this))
            {
                this.POREZController.DataSet = new POREZDataSet();
                DataSetUtil.AddEmptyRow(this.POREZController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.POREZController.DataSet.POREZ[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDPOREZ.Focus();
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

        protected virtual UltraLabel label1IDPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDPOREZ = value;
            }
        }

        protected virtual UltraLabel label1MOPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MOPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MOPOREZ = value;
            }
        }

        protected virtual UltraLabel label1MZPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MZPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MZPOREZ = value;
            }
        }

        protected virtual UltraLabel label1NAZIVPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVPOREZ = value;
            }
        }

        protected virtual UltraLabel label1OPISPLACANJAPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISPLACANJAPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISPLACANJAPOREZ = value;
            }
        }

        protected virtual UltraLabel label1POPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POPOREZ = value;
            }
        }

        protected virtual UltraLabel label1POREZMJESECNO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POREZMJESECNO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POREZMJESECNO = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJPOREZ1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJPOREZ1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJPOREZ1 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJPOREZ2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJPOREZ2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJPOREZ2 = value;
            }
        }

        protected virtual UltraLabel label1PZPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PZPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PZPOREZ = value;
            }
        }

        protected virtual UltraLabel label1SIFRAOPISAPLACANJAPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAOPISAPLACANJAPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAOPISAPLACANJAPOREZ = value;
            }
        }

        protected virtual UltraLabel label1STOPAPOREZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1STOPAPOREZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1STOPAPOREZA = value;
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
        public NetAdvantage.Controllers.POREZController POREZController { get; set; }

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

        protected virtual UltraNumericEditor textIDPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDPOREZ = value;
            }
        }

        protected virtual UltraTextEditor textMOPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMOPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMOPOREZ = value;
            }
        }

        protected virtual UltraTextEditor textMZPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMZPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMZPOREZ = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVPOREZ = value;
            }
        }

        protected virtual UltraTextEditor textOPISPLACANJAPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPISPLACANJAPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPISPLACANJAPOREZ = value;
            }
        }

        protected virtual UltraTextEditor textPOPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOPOREZ = value;
            }
        }

        protected virtual UltraNumericEditor textPOREZMJESECNO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOREZMJESECNO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOREZMJESECNO = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJPOREZ1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJPOREZ1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJPOREZ1 = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJPOREZ2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJPOREZ2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJPOREZ2 = value;
            }
        }

        protected virtual UltraTextEditor textPZPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPZPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPZPOREZ = value;
            }
        }

        protected virtual UltraTextEditor textSIFRAOPISAPLACANJAPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSIFRAOPISAPLACANJAPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSIFRAOPISAPLACANJAPOREZ = value;
            }
        }

        protected virtual UltraNumericEditor textSTOPAPOREZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSTOPAPOREZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSTOPAPOREZA = value;
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

