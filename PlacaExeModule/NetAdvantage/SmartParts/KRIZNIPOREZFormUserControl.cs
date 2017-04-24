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
    public class KRIZNIPOREZFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDKRIZNIPOREZ")]
        private UltraLabel _label1IDKRIZNIPOREZ;
        [AccessedThroughProperty("label1KRIZNIDO")]
        private UltraLabel _label1KRIZNIDO;
        [AccessedThroughProperty("label1KRIZNIOD")]
        private UltraLabel _label1KRIZNIOD;
        [AccessedThroughProperty("label1KRIZNISTOPA")]
        private UltraLabel _label1KRIZNISTOPA;
        [AccessedThroughProperty("label1MOKRIZNI")]
        private UltraLabel _label1MOKRIZNI;
        [AccessedThroughProperty("label1MZKRIZNI")]
        private UltraLabel _label1MZKRIZNI;
        [AccessedThroughProperty("label1NAZIVKRIZNIPOREZ")]
        private UltraLabel _label1NAZIVKRIZNIPOREZ;
        [AccessedThroughProperty("label1OPISPLACANJAKRIZNI")]
        private UltraLabel _label1OPISPLACANJAKRIZNI;
        [AccessedThroughProperty("label1POKRIZNI")]
        private UltraLabel _label1POKRIZNI;
        [AccessedThroughProperty("label1PRIMATELJKRIZNI1")]
        private UltraLabel _label1PRIMATELJKRIZNI1;
        [AccessedThroughProperty("label1PRIMATELJKRIZNI2")]
        private UltraLabel _label1PRIMATELJKRIZNI2;
        [AccessedThroughProperty("label1PRIMATELJKRIZNI3")]
        private UltraLabel _label1PRIMATELJKRIZNI3;
        [AccessedThroughProperty("label1PZKRIZNI")]
        private UltraLabel _label1PZKRIZNI;
        [AccessedThroughProperty("label1SIFRAOPISAPLACANJAKRIZNI")]
        private UltraLabel _label1SIFRAOPISAPLACANJAKRIZNI;
        [AccessedThroughProperty("label1VBDIKRIZNI")]
        private UltraLabel _label1VBDIKRIZNI;
        [AccessedThroughProperty("label1ZRNKRIZNI")]
        private UltraLabel _label1ZRNKRIZNI;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDKRIZNIPOREZ")]
        private UltraNumericEditor _textIDKRIZNIPOREZ;
        [AccessedThroughProperty("textKRIZNIDO")]
        private UltraNumericEditor _textKRIZNIDO;
        [AccessedThroughProperty("textKRIZNIOD")]
        private UltraNumericEditor _textKRIZNIOD;
        [AccessedThroughProperty("textKRIZNISTOPA")]
        private UltraNumericEditor _textKRIZNISTOPA;
        [AccessedThroughProperty("textMOKRIZNI")]
        private UltraTextEditor _textMOKRIZNI;
        [AccessedThroughProperty("textMZKRIZNI")]
        private UltraTextEditor _textMZKRIZNI;
        [AccessedThroughProperty("textNAZIVKRIZNIPOREZ")]
        private UltraTextEditor _textNAZIVKRIZNIPOREZ;
        [AccessedThroughProperty("textOPISPLACANJAKRIZNI")]
        private UltraTextEditor _textOPISPLACANJAKRIZNI;
        [AccessedThroughProperty("textPOKRIZNI")]
        private UltraTextEditor _textPOKRIZNI;
        [AccessedThroughProperty("textPRIMATELJKRIZNI1")]
        private UltraTextEditor _textPRIMATELJKRIZNI1;
        [AccessedThroughProperty("textPRIMATELJKRIZNI2")]
        private UltraTextEditor _textPRIMATELJKRIZNI2;
        [AccessedThroughProperty("textPRIMATELJKRIZNI3")]
        private UltraTextEditor _textPRIMATELJKRIZNI3;
        [AccessedThroughProperty("textPZKRIZNI")]
        private UltraTextEditor _textPZKRIZNI;
        [AccessedThroughProperty("textSIFRAOPISAPLACANJAKRIZNI")]
        private UltraTextEditor _textSIFRAOPISAPLACANJAKRIZNI;
        [AccessedThroughProperty("textVBDIKRIZNI")]
        private UltraTextEditor _textVBDIKRIZNI;
        [AccessedThroughProperty("textZRNKRIZNI")]
        private UltraTextEditor _textZRNKRIZNI;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceKRIZNIPOREZ;
        private IContainer components = null;
        private KRIZNIPOREZDataSet dsKRIZNIPOREZDataSet1;
        protected TableLayoutPanel layoutManagerformKRIZNIPOREZ;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private KRIZNIPOREZDataSet.KRIZNIPOREZRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "KRIZNIPOREZ";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.KRIZNIPOREZDescription;
        private DeklaritMode m_Mode;

        public KRIZNIPOREZFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceKRIZNIPOREZ.DataSource = this.KRIZNIPOREZController.DataSet;
            this.dsKRIZNIPOREZDataSet1 = this.KRIZNIPOREZController.DataSet;
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
                    enumerator = this.dsKRIZNIPOREZDataSet1.KRIZNIPOREZ.Rows.GetEnumerator();
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
                if (this.KRIZNIPOREZController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "KRIZNIPOREZ", this.m_Mode, this.dsKRIZNIPOREZDataSet1, this.dsKRIZNIPOREZDataSet1.KRIZNIPOREZ.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsKRIZNIPOREZDataSet1.KRIZNIPOREZ[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (KRIZNIPOREZDataSet.KRIZNIPOREZRow) ((DataRowView) this.bindingSourceKRIZNIPOREZ.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(KRIZNIPOREZFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceKRIZNIPOREZ = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceKRIZNIPOREZ).BeginInit();
            this.layoutManagerformKRIZNIPOREZ = new TableLayoutPanel();
            this.layoutManagerformKRIZNIPOREZ.SuspendLayout();
            this.layoutManagerformKRIZNIPOREZ.AutoSize = true;
            this.layoutManagerformKRIZNIPOREZ.Dock = DockStyle.Fill;
            this.layoutManagerformKRIZNIPOREZ.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformKRIZNIPOREZ.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformKRIZNIPOREZ.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformKRIZNIPOREZ.Size = size;
            this.layoutManagerformKRIZNIPOREZ.ColumnCount = 2;
            this.layoutManagerformKRIZNIPOREZ.RowCount = 0x11;
            this.layoutManagerformKRIZNIPOREZ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformKRIZNIPOREZ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformKRIZNIPOREZ.RowStyles.Add(new RowStyle());
            this.label1IDKRIZNIPOREZ = new UltraLabel();
            this.textIDKRIZNIPOREZ = new UltraNumericEditor();
            this.label1NAZIVKRIZNIPOREZ = new UltraLabel();
            this.textNAZIVKRIZNIPOREZ = new UltraTextEditor();
            this.label1KRIZNISTOPA = new UltraLabel();
            this.textKRIZNISTOPA = new UltraNumericEditor();
            this.label1KRIZNIOD = new UltraLabel();
            this.textKRIZNIOD = new UltraNumericEditor();
            this.label1KRIZNIDO = new UltraLabel();
            this.textKRIZNIDO = new UltraNumericEditor();
            this.label1MOKRIZNI = new UltraLabel();
            this.textMOKRIZNI = new UltraTextEditor();
            this.label1POKRIZNI = new UltraLabel();
            this.textPOKRIZNI = new UltraTextEditor();
            this.label1MZKRIZNI = new UltraLabel();
            this.textMZKRIZNI = new UltraTextEditor();
            this.label1PZKRIZNI = new UltraLabel();
            this.textPZKRIZNI = new UltraTextEditor();
            this.label1PRIMATELJKRIZNI1 = new UltraLabel();
            this.textPRIMATELJKRIZNI1 = new UltraTextEditor();
            this.label1PRIMATELJKRIZNI2 = new UltraLabel();
            this.textPRIMATELJKRIZNI2 = new UltraTextEditor();
            this.label1PRIMATELJKRIZNI3 = new UltraLabel();
            this.textPRIMATELJKRIZNI3 = new UltraTextEditor();
            this.label1SIFRAOPISAPLACANJAKRIZNI = new UltraLabel();
            this.textSIFRAOPISAPLACANJAKRIZNI = new UltraTextEditor();
            this.label1OPISPLACANJAKRIZNI = new UltraLabel();
            this.textOPISPLACANJAKRIZNI = new UltraTextEditor();
            this.label1VBDIKRIZNI = new UltraLabel();
            this.textVBDIKRIZNI = new UltraTextEditor();
            this.label1ZRNKRIZNI = new UltraLabel();
            this.textZRNKRIZNI = new UltraTextEditor();
            ((ISupportInitialize) this.textIDKRIZNIPOREZ).BeginInit();
            ((ISupportInitialize) this.textNAZIVKRIZNIPOREZ).BeginInit();
            ((ISupportInitialize) this.textKRIZNISTOPA).BeginInit();
            ((ISupportInitialize) this.textKRIZNIOD).BeginInit();
            ((ISupportInitialize) this.textKRIZNIDO).BeginInit();
            ((ISupportInitialize) this.textMOKRIZNI).BeginInit();
            ((ISupportInitialize) this.textPOKRIZNI).BeginInit();
            ((ISupportInitialize) this.textMZKRIZNI).BeginInit();
            ((ISupportInitialize) this.textPZKRIZNI).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJKRIZNI1).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJKRIZNI2).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJKRIZNI3).BeginInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJAKRIZNI).BeginInit();
            ((ISupportInitialize) this.textOPISPLACANJAKRIZNI).BeginInit();
            ((ISupportInitialize) this.textVBDIKRIZNI).BeginInit();
            ((ISupportInitialize) this.textZRNKRIZNI).BeginInit();
            this.dsKRIZNIPOREZDataSet1 = new KRIZNIPOREZDataSet();
            this.dsKRIZNIPOREZDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsKRIZNIPOREZDataSet1.DataSetName = "dsKRIZNIPOREZ";
            this.dsKRIZNIPOREZDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceKRIZNIPOREZ.DataSource = this.dsKRIZNIPOREZDataSet1;
            this.bindingSourceKRIZNIPOREZ.DataMember = "KRIZNIPOREZ";
            ((ISupportInitialize) this.bindingSourceKRIZNIPOREZ).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDKRIZNIPOREZ.Location = point;
            this.label1IDKRIZNIPOREZ.Name = "label1IDKRIZNIPOREZ";
            this.label1IDKRIZNIPOREZ.TabIndex = 1;
            this.label1IDKRIZNIPOREZ.Tag = "labelIDKRIZNIPOREZ";
            this.label1IDKRIZNIPOREZ.Text = "IDKRIZNIPOREZ:";
            this.label1IDKRIZNIPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1IDKRIZNIPOREZ.AutoSize = true;
            this.label1IDKRIZNIPOREZ.Anchor = AnchorStyles.Left;
            this.label1IDKRIZNIPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDKRIZNIPOREZ.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDKRIZNIPOREZ.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDKRIZNIPOREZ.ImageSize = size;
            this.label1IDKRIZNIPOREZ.Appearance.ForeColor = Color.Black;
            this.label1IDKRIZNIPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1IDKRIZNIPOREZ, 0, 0);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1IDKRIZNIPOREZ, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1IDKRIZNIPOREZ, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDKRIZNIPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDKRIZNIPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(120, 0x17);
            this.label1IDKRIZNIPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDKRIZNIPOREZ.Location = point;
            this.textIDKRIZNIPOREZ.Name = "textIDKRIZNIPOREZ";
            this.textIDKRIZNIPOREZ.Tag = "IDKRIZNIPOREZ";
            this.textIDKRIZNIPOREZ.TabIndex = 0;
            this.textIDKRIZNIPOREZ.Anchor = AnchorStyles.Left;
            this.textIDKRIZNIPOREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDKRIZNIPOREZ.ReadOnly = false;
            this.textIDKRIZNIPOREZ.PromptChar = ' ';
            this.textIDKRIZNIPOREZ.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDKRIZNIPOREZ.DataBindings.Add(new Binding("Value", this.bindingSourceKRIZNIPOREZ, "IDKRIZNIPOREZ"));
            this.textIDKRIZNIPOREZ.NumericType = NumericType.Integer;
            this.textIDKRIZNIPOREZ.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textIDKRIZNIPOREZ, 1, 0);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textIDKRIZNIPOREZ, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textIDKRIZNIPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDKRIZNIPOREZ.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDKRIZNIPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDKRIZNIPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVKRIZNIPOREZ.Location = point;
            this.label1NAZIVKRIZNIPOREZ.Name = "label1NAZIVKRIZNIPOREZ";
            this.label1NAZIVKRIZNIPOREZ.TabIndex = 1;
            this.label1NAZIVKRIZNIPOREZ.Tag = "labelNAZIVKRIZNIPOREZ";
            this.label1NAZIVKRIZNIPOREZ.Text = "Naziv:";
            this.label1NAZIVKRIZNIPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVKRIZNIPOREZ.AutoSize = true;
            this.label1NAZIVKRIZNIPOREZ.Anchor = AnchorStyles.Left;
            this.label1NAZIVKRIZNIPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVKRIZNIPOREZ.Appearance.ForeColor = Color.Black;
            this.label1NAZIVKRIZNIPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1NAZIVKRIZNIPOREZ, 0, 1);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1NAZIVKRIZNIPOREZ, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1NAZIVKRIZNIPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVKRIZNIPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVKRIZNIPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1NAZIVKRIZNIPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVKRIZNIPOREZ.Location = point;
            this.textNAZIVKRIZNIPOREZ.Name = "textNAZIVKRIZNIPOREZ";
            this.textNAZIVKRIZNIPOREZ.Tag = "NAZIVKRIZNIPOREZ";
            this.textNAZIVKRIZNIPOREZ.TabIndex = 0;
            this.textNAZIVKRIZNIPOREZ.Anchor = AnchorStyles.Left;
            this.textNAZIVKRIZNIPOREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVKRIZNIPOREZ.ReadOnly = false;
            this.textNAZIVKRIZNIPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourceKRIZNIPOREZ, "NAZIVKRIZNIPOREZ"));
            this.textNAZIVKRIZNIPOREZ.MaxLength = 50;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textNAZIVKRIZNIPOREZ, 1, 1);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textNAZIVKRIZNIPOREZ, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textNAZIVKRIZNIPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVKRIZNIPOREZ.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVKRIZNIPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVKRIZNIPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KRIZNISTOPA.Location = point;
            this.label1KRIZNISTOPA.Name = "label1KRIZNISTOPA";
            this.label1KRIZNISTOPA.TabIndex = 1;
            this.label1KRIZNISTOPA.Tag = "labelKRIZNISTOPA";
            this.label1KRIZNISTOPA.Text = "Stopa:";
            this.label1KRIZNISTOPA.StyleSetName = "FieldUltraLabel";
            this.label1KRIZNISTOPA.AutoSize = true;
            this.label1KRIZNISTOPA.Anchor = AnchorStyles.Left;
            this.label1KRIZNISTOPA.Appearance.TextVAlign = VAlign.Middle;
            this.label1KRIZNISTOPA.Appearance.ForeColor = Color.Black;
            this.label1KRIZNISTOPA.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1KRIZNISTOPA, 0, 2);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1KRIZNISTOPA, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1KRIZNISTOPA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KRIZNISTOPA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KRIZNISTOPA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x17);
            this.label1KRIZNISTOPA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textKRIZNISTOPA.Location = point;
            this.textKRIZNISTOPA.Name = "textKRIZNISTOPA";
            this.textKRIZNISTOPA.Tag = "KRIZNISTOPA";
            this.textKRIZNISTOPA.TabIndex = 0;
            this.textKRIZNISTOPA.Anchor = AnchorStyles.Left;
            this.textKRIZNISTOPA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textKRIZNISTOPA.ReadOnly = false;
            this.textKRIZNISTOPA.PromptChar = ' ';
            this.textKRIZNISTOPA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textKRIZNISTOPA.DataBindings.Add(new Binding("Value", this.bindingSourceKRIZNIPOREZ, "KRIZNISTOPA"));
            this.textKRIZNISTOPA.NumericType = NumericType.Double;
            this.textKRIZNISTOPA.MaxValue = 79228162514264337593543950335M;
            this.textKRIZNISTOPA.MinValue = -79228162514264337593543950335M;
            this.textKRIZNISTOPA.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textKRIZNISTOPA, 1, 2);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textKRIZNISTOPA, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textKRIZNISTOPA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textKRIZNISTOPA.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textKRIZNISTOPA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textKRIZNISTOPA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KRIZNIOD.Location = point;
            this.label1KRIZNIOD.Name = "label1KRIZNIOD";
            this.label1KRIZNIOD.TabIndex = 1;
            this.label1KRIZNIOD.Tag = "labelKRIZNIOD";
            this.label1KRIZNIOD.Text = "Od iznosa:";
            this.label1KRIZNIOD.StyleSetName = "FieldUltraLabel";
            this.label1KRIZNIOD.AutoSize = true;
            this.label1KRIZNIOD.Anchor = AnchorStyles.Left;
            this.label1KRIZNIOD.Appearance.TextVAlign = VAlign.Middle;
            this.label1KRIZNIOD.Appearance.ForeColor = Color.Black;
            this.label1KRIZNIOD.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1KRIZNIOD, 0, 3);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1KRIZNIOD, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1KRIZNIOD, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KRIZNIOD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KRIZNIOD.MinimumSize = size;
            size = new System.Drawing.Size(0x4f, 0x17);
            this.label1KRIZNIOD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textKRIZNIOD.Location = point;
            this.textKRIZNIOD.Name = "textKRIZNIOD";
            this.textKRIZNIOD.Tag = "KRIZNIOD";
            this.textKRIZNIOD.TabIndex = 0;
            this.textKRIZNIOD.Anchor = AnchorStyles.Left;
            this.textKRIZNIOD.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textKRIZNIOD.ReadOnly = false;
            this.textKRIZNIOD.PromptChar = ' ';
            this.textKRIZNIOD.Enter += new EventHandler(this.numericEditor_Enter);
            this.textKRIZNIOD.DataBindings.Add(new Binding("Value", this.bindingSourceKRIZNIPOREZ, "KRIZNIOD"));
            this.textKRIZNIOD.NumericType = NumericType.Double;
            this.textKRIZNIOD.MaxValue = 79228162514264337593543950335M;
            this.textKRIZNIOD.MinValue = -79228162514264337593543950335M;
            this.textKRIZNIOD.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textKRIZNIOD, 1, 3);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textKRIZNIOD, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textKRIZNIOD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textKRIZNIOD.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textKRIZNIOD.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textKRIZNIOD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KRIZNIDO.Location = point;
            this.label1KRIZNIDO.Name = "label1KRIZNIDO";
            this.label1KRIZNIDO.TabIndex = 1;
            this.label1KRIZNIDO.Tag = "labelKRIZNIDO";
            this.label1KRIZNIDO.Text = "Do iznosa:";
            this.label1KRIZNIDO.StyleSetName = "FieldUltraLabel";
            this.label1KRIZNIDO.AutoSize = true;
            this.label1KRIZNIDO.Anchor = AnchorStyles.Left;
            this.label1KRIZNIDO.Appearance.TextVAlign = VAlign.Middle;
            this.label1KRIZNIDO.Appearance.ForeColor = Color.Black;
            this.label1KRIZNIDO.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1KRIZNIDO, 0, 4);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1KRIZNIDO, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1KRIZNIDO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KRIZNIDO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KRIZNIDO.MinimumSize = size;
            size = new System.Drawing.Size(0x4f, 0x17);
            this.label1KRIZNIDO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textKRIZNIDO.Location = point;
            this.textKRIZNIDO.Name = "textKRIZNIDO";
            this.textKRIZNIDO.Tag = "KRIZNIDO";
            this.textKRIZNIDO.TabIndex = 0;
            this.textKRIZNIDO.Anchor = AnchorStyles.Left;
            this.textKRIZNIDO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textKRIZNIDO.ReadOnly = false;
            this.textKRIZNIDO.PromptChar = ' ';
            this.textKRIZNIDO.Enter += new EventHandler(this.numericEditor_Enter);
            this.textKRIZNIDO.DataBindings.Add(new Binding("Value", this.bindingSourceKRIZNIPOREZ, "KRIZNIDO"));
            this.textKRIZNIDO.NumericType = NumericType.Double;
            this.textKRIZNIDO.MaxValue = 79228162514264337593543950335M;
            this.textKRIZNIDO.MinValue = -79228162514264337593543950335M;
            this.textKRIZNIDO.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textKRIZNIDO, 1, 4);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textKRIZNIDO, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textKRIZNIDO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textKRIZNIDO.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textKRIZNIDO.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textKRIZNIDO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MOKRIZNI.Location = point;
            this.label1MOKRIZNI.Name = "label1MOKRIZNI";
            this.label1MOKRIZNI.TabIndex = 1;
            this.label1MOKRIZNI.Tag = "labelMOKRIZNI";
            this.label1MOKRIZNI.Text = "Model odobrenja:";
            this.label1MOKRIZNI.StyleSetName = "FieldUltraLabel";
            this.label1MOKRIZNI.AutoSize = true;
            this.label1MOKRIZNI.Anchor = AnchorStyles.Left;
            this.label1MOKRIZNI.Appearance.TextVAlign = VAlign.Middle;
            this.label1MOKRIZNI.Appearance.ForeColor = Color.Black;
            this.label1MOKRIZNI.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1MOKRIZNI, 0, 5);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1MOKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1MOKRIZNI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MOKRIZNI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MOKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1MOKRIZNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMOKRIZNI.Location = point;
            this.textMOKRIZNI.Name = "textMOKRIZNI";
            this.textMOKRIZNI.Tag = "MOKRIZNI";
            this.textMOKRIZNI.TabIndex = 0;
            this.textMOKRIZNI.Anchor = AnchorStyles.Left;
            this.textMOKRIZNI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMOKRIZNI.ReadOnly = false;
            this.textMOKRIZNI.DataBindings.Add(new Binding("Text", this.bindingSourceKRIZNIPOREZ, "MOKRIZNI"));
            this.textMOKRIZNI.MaxLength = 2;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textMOKRIZNI, 1, 5);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textMOKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textMOKRIZNI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMOKRIZNI.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMOKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMOKRIZNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POKRIZNI.Location = point;
            this.label1POKRIZNI.Name = "label1POKRIZNI";
            this.label1POKRIZNI.TabIndex = 1;
            this.label1POKRIZNI.Tag = "labelPOKRIZNI";
            this.label1POKRIZNI.Text = "Poziv na broj odobrenja:";
            this.label1POKRIZNI.StyleSetName = "FieldUltraLabel";
            this.label1POKRIZNI.AutoSize = true;
            this.label1POKRIZNI.Anchor = AnchorStyles.Left;
            this.label1POKRIZNI.Appearance.TextVAlign = VAlign.Middle;
            this.label1POKRIZNI.Appearance.ForeColor = Color.Black;
            this.label1POKRIZNI.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1POKRIZNI, 0, 6);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1POKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1POKRIZNI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POKRIZNI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(0xa7, 0x17);
            this.label1POKRIZNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOKRIZNI.Location = point;
            this.textPOKRIZNI.Name = "textPOKRIZNI";
            this.textPOKRIZNI.Tag = "POKRIZNI";
            this.textPOKRIZNI.TabIndex = 0;
            this.textPOKRIZNI.Anchor = AnchorStyles.Left;
            this.textPOKRIZNI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOKRIZNI.ReadOnly = false;
            this.textPOKRIZNI.DataBindings.Add(new Binding("Text", this.bindingSourceKRIZNIPOREZ, "POKRIZNI"));
            this.textPOKRIZNI.MaxLength = 0x16;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textPOKRIZNI, 1, 6);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textPOKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textPOKRIZNI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOKRIZNI.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOKRIZNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MZKRIZNI.Location = point;
            this.label1MZKRIZNI.Name = "label1MZKRIZNI";
            this.label1MZKRIZNI.TabIndex = 1;
            this.label1MZKRIZNI.Tag = "labelMZKRIZNI";
            this.label1MZKRIZNI.Text = "Model zaduženja:";
            this.label1MZKRIZNI.StyleSetName = "FieldUltraLabel";
            this.label1MZKRIZNI.AutoSize = true;
            this.label1MZKRIZNI.Anchor = AnchorStyles.Left;
            this.label1MZKRIZNI.Appearance.TextVAlign = VAlign.Middle;
            this.label1MZKRIZNI.Appearance.ForeColor = Color.Black;
            this.label1MZKRIZNI.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1MZKRIZNI, 0, 7);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1MZKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1MZKRIZNI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MZKRIZNI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MZKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1MZKRIZNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMZKRIZNI.Location = point;
            this.textMZKRIZNI.Name = "textMZKRIZNI";
            this.textMZKRIZNI.Tag = "MZKRIZNI";
            this.textMZKRIZNI.TabIndex = 0;
            this.textMZKRIZNI.Anchor = AnchorStyles.Left;
            this.textMZKRIZNI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMZKRIZNI.ContextMenu = this.contextMenu1;
            this.textMZKRIZNI.ReadOnly = false;
            this.textMZKRIZNI.DataBindings.Add(new Binding("Text", this.bindingSourceKRIZNIPOREZ, "MZKRIZNI"));
            this.textMZKRIZNI.Nullable = true;
            this.textMZKRIZNI.MaxLength = 2;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textMZKRIZNI, 1, 7);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textMZKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textMZKRIZNI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMZKRIZNI.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMZKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMZKRIZNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PZKRIZNI.Location = point;
            this.label1PZKRIZNI.Name = "label1PZKRIZNI";
            this.label1PZKRIZNI.TabIndex = 1;
            this.label1PZKRIZNI.Tag = "labelPZKRIZNI";
            this.label1PZKRIZNI.Text = "Poziv na broj zaduženja:";
            this.label1PZKRIZNI.StyleSetName = "FieldUltraLabel";
            this.label1PZKRIZNI.AutoSize = true;
            this.label1PZKRIZNI.Anchor = AnchorStyles.Left;
            this.label1PZKRIZNI.Appearance.TextVAlign = VAlign.Middle;
            this.label1PZKRIZNI.Appearance.ForeColor = Color.Black;
            this.label1PZKRIZNI.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1PZKRIZNI, 0, 8);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1PZKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1PZKRIZNI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PZKRIZNI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PZKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(0xa7, 0x17);
            this.label1PZKRIZNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPZKRIZNI.Location = point;
            this.textPZKRIZNI.Name = "textPZKRIZNI";
            this.textPZKRIZNI.Tag = "PZKRIZNI";
            this.textPZKRIZNI.TabIndex = 0;
            this.textPZKRIZNI.Anchor = AnchorStyles.Left;
            this.textPZKRIZNI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPZKRIZNI.ContextMenu = this.contextMenu1;
            this.textPZKRIZNI.ReadOnly = false;
            this.textPZKRIZNI.DataBindings.Add(new Binding("Text", this.bindingSourceKRIZNIPOREZ, "PZKRIZNI"));
            this.textPZKRIZNI.Nullable = true;
            this.textPZKRIZNI.MaxLength = 0x16;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textPZKRIZNI, 1, 8);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textPZKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textPZKRIZNI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPZKRIZNI.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPZKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPZKRIZNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJKRIZNI1.Location = point;
            this.label1PRIMATELJKRIZNI1.Name = "label1PRIMATELJKRIZNI1";
            this.label1PRIMATELJKRIZNI1.TabIndex = 1;
            this.label1PRIMATELJKRIZNI1.Tag = "labelPRIMATELJKRIZNI1";
            this.label1PRIMATELJKRIZNI1.Text = "Primatelj (1):";
            this.label1PRIMATELJKRIZNI1.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJKRIZNI1.AutoSize = true;
            this.label1PRIMATELJKRIZNI1.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJKRIZNI1.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJKRIZNI1.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJKRIZNI1.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1PRIMATELJKRIZNI1, 0, 9);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1PRIMATELJKRIZNI1, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1PRIMATELJKRIZNI1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJKRIZNI1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJKRIZNI1.MinimumSize = size;
            size = new System.Drawing.Size(0x63, 0x17);
            this.label1PRIMATELJKRIZNI1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJKRIZNI1.Location = point;
            this.textPRIMATELJKRIZNI1.Name = "textPRIMATELJKRIZNI1";
            this.textPRIMATELJKRIZNI1.Tag = "PRIMATELJKRIZNI1";
            this.textPRIMATELJKRIZNI1.TabIndex = 0;
            this.textPRIMATELJKRIZNI1.Anchor = AnchorStyles.Left;
            this.textPRIMATELJKRIZNI1.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJKRIZNI1.ReadOnly = false;
            this.textPRIMATELJKRIZNI1.DataBindings.Add(new Binding("Text", this.bindingSourceKRIZNIPOREZ, "PRIMATELJKRIZNI1"));
            this.textPRIMATELJKRIZNI1.MaxLength = 20;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textPRIMATELJKRIZNI1, 1, 9);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textPRIMATELJKRIZNI1, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textPRIMATELJKRIZNI1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJKRIZNI1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJKRIZNI1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJKRIZNI1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJKRIZNI2.Location = point;
            this.label1PRIMATELJKRIZNI2.Name = "label1PRIMATELJKRIZNI2";
            this.label1PRIMATELJKRIZNI2.TabIndex = 1;
            this.label1PRIMATELJKRIZNI2.Tag = "labelPRIMATELJKRIZNI2";
            this.label1PRIMATELJKRIZNI2.Text = "Primatelj (2):";
            this.label1PRIMATELJKRIZNI2.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJKRIZNI2.AutoSize = true;
            this.label1PRIMATELJKRIZNI2.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJKRIZNI2.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJKRIZNI2.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJKRIZNI2.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1PRIMATELJKRIZNI2, 0, 10);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1PRIMATELJKRIZNI2, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1PRIMATELJKRIZNI2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJKRIZNI2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJKRIZNI2.MinimumSize = size;
            size = new System.Drawing.Size(0x63, 0x17);
            this.label1PRIMATELJKRIZNI2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJKRIZNI2.Location = point;
            this.textPRIMATELJKRIZNI2.Name = "textPRIMATELJKRIZNI2";
            this.textPRIMATELJKRIZNI2.Tag = "PRIMATELJKRIZNI2";
            this.textPRIMATELJKRIZNI2.TabIndex = 0;
            this.textPRIMATELJKRIZNI2.Anchor = AnchorStyles.Left;
            this.textPRIMATELJKRIZNI2.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJKRIZNI2.ReadOnly = false;
            this.textPRIMATELJKRIZNI2.DataBindings.Add(new Binding("Text", this.bindingSourceKRIZNIPOREZ, "PRIMATELJKRIZNI2"));
            this.textPRIMATELJKRIZNI2.MaxLength = 20;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textPRIMATELJKRIZNI2, 1, 10);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textPRIMATELJKRIZNI2, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textPRIMATELJKRIZNI2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJKRIZNI2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJKRIZNI2.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJKRIZNI2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJKRIZNI3.Location = point;
            this.label1PRIMATELJKRIZNI3.Name = "label1PRIMATELJKRIZNI3";
            this.label1PRIMATELJKRIZNI3.TabIndex = 1;
            this.label1PRIMATELJKRIZNI3.Tag = "labelPRIMATELJKRIZNI3";
            this.label1PRIMATELJKRIZNI3.Text = "Primatelj (3):";
            this.label1PRIMATELJKRIZNI3.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJKRIZNI3.AutoSize = true;
            this.label1PRIMATELJKRIZNI3.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJKRIZNI3.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJKRIZNI3.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJKRIZNI3.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1PRIMATELJKRIZNI3, 0, 11);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1PRIMATELJKRIZNI3, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1PRIMATELJKRIZNI3, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJKRIZNI3.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJKRIZNI3.MinimumSize = size;
            size = new System.Drawing.Size(0x63, 0x17);
            this.label1PRIMATELJKRIZNI3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJKRIZNI3.Location = point;
            this.textPRIMATELJKRIZNI3.Name = "textPRIMATELJKRIZNI3";
            this.textPRIMATELJKRIZNI3.Tag = "PRIMATELJKRIZNI3";
            this.textPRIMATELJKRIZNI3.TabIndex = 0;
            this.textPRIMATELJKRIZNI3.Anchor = AnchorStyles.Left;
            this.textPRIMATELJKRIZNI3.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJKRIZNI3.ReadOnly = false;
            this.textPRIMATELJKRIZNI3.DataBindings.Add(new Binding("Text", this.bindingSourceKRIZNIPOREZ, "PRIMATELJKRIZNI3"));
            this.textPRIMATELJKRIZNI3.MaxLength = 20;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textPRIMATELJKRIZNI3, 1, 11);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textPRIMATELJKRIZNI3, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textPRIMATELJKRIZNI3, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJKRIZNI3.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJKRIZNI3.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJKRIZNI3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAOPISAPLACANJAKRIZNI.Location = point;
            this.label1SIFRAOPISAPLACANJAKRIZNI.Name = "label1SIFRAOPISAPLACANJAKRIZNI";
            this.label1SIFRAOPISAPLACANJAKRIZNI.TabIndex = 1;
            this.label1SIFRAOPISAPLACANJAKRIZNI.Tag = "labelSIFRAOPISAPLACANJAKRIZNI";
            this.label1SIFRAOPISAPLACANJAKRIZNI.Text = "Šifra opisa plaćanja:";
            this.label1SIFRAOPISAPLACANJAKRIZNI.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAOPISAPLACANJAKRIZNI.AutoSize = true;
            this.label1SIFRAOPISAPLACANJAKRIZNI.Anchor = AnchorStyles.Left;
            this.label1SIFRAOPISAPLACANJAKRIZNI.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAOPISAPLACANJAKRIZNI.Appearance.ForeColor = Color.Black;
            this.label1SIFRAOPISAPLACANJAKRIZNI.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1SIFRAOPISAPLACANJAKRIZNI, 0, 12);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1SIFRAOPISAPLACANJAKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1SIFRAOPISAPLACANJAKRIZNI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAOPISAPLACANJAKRIZNI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAOPISAPLACANJAKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 0x17);
            this.label1SIFRAOPISAPLACANJAKRIZNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSIFRAOPISAPLACANJAKRIZNI.Location = point;
            this.textSIFRAOPISAPLACANJAKRIZNI.Name = "textSIFRAOPISAPLACANJAKRIZNI";
            this.textSIFRAOPISAPLACANJAKRIZNI.Tag = "SIFRAOPISAPLACANJAKRIZNI";
            this.textSIFRAOPISAPLACANJAKRIZNI.TabIndex = 0;
            this.textSIFRAOPISAPLACANJAKRIZNI.Anchor = AnchorStyles.Left;
            this.textSIFRAOPISAPLACANJAKRIZNI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSIFRAOPISAPLACANJAKRIZNI.ReadOnly = false;
            this.textSIFRAOPISAPLACANJAKRIZNI.DataBindings.Add(new Binding("Text", this.bindingSourceKRIZNIPOREZ, "SIFRAOPISAPLACANJAKRIZNI"));
            this.textSIFRAOPISAPLACANJAKRIZNI.MaxLength = 2;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textSIFRAOPISAPLACANJAKRIZNI, 1, 12);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textSIFRAOPISAPLACANJAKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textSIFRAOPISAPLACANJAKRIZNI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSIFRAOPISAPLACANJAKRIZNI.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJAKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJAKRIZNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISPLACANJAKRIZNI.Location = point;
            this.label1OPISPLACANJAKRIZNI.Name = "label1OPISPLACANJAKRIZNI";
            this.label1OPISPLACANJAKRIZNI.TabIndex = 1;
            this.label1OPISPLACANJAKRIZNI.Tag = "labelOPISPLACANJAKRIZNI";
            this.label1OPISPLACANJAKRIZNI.Text = "Opis plaćanja krizni:";
            this.label1OPISPLACANJAKRIZNI.StyleSetName = "FieldUltraLabel";
            this.label1OPISPLACANJAKRIZNI.AutoSize = true;
            this.label1OPISPLACANJAKRIZNI.Anchor = AnchorStyles.Left;
            this.label1OPISPLACANJAKRIZNI.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISPLACANJAKRIZNI.Appearance.ForeColor = Color.Black;
            this.label1OPISPLACANJAKRIZNI.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1OPISPLACANJAKRIZNI, 0, 13);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1OPISPLACANJAKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1OPISPLACANJAKRIZNI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISPLACANJAKRIZNI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISPLACANJAKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 0x17);
            this.label1OPISPLACANJAKRIZNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPISPLACANJAKRIZNI.Location = point;
            this.textOPISPLACANJAKRIZNI.Name = "textOPISPLACANJAKRIZNI";
            this.textOPISPLACANJAKRIZNI.Tag = "OPISPLACANJAKRIZNI";
            this.textOPISPLACANJAKRIZNI.TabIndex = 0;
            this.textOPISPLACANJAKRIZNI.Anchor = AnchorStyles.Left;
            this.textOPISPLACANJAKRIZNI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPISPLACANJAKRIZNI.ReadOnly = false;
            this.textOPISPLACANJAKRIZNI.DataBindings.Add(new Binding("Text", this.bindingSourceKRIZNIPOREZ, "OPISPLACANJAKRIZNI"));
            this.textOPISPLACANJAKRIZNI.MaxLength = 0x24;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textOPISPLACANJAKRIZNI, 1, 13);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textOPISPLACANJAKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textOPISPLACANJAKRIZNI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPISPLACANJAKRIZNI.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJAKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJAKRIZNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VBDIKRIZNI.Location = point;
            this.label1VBDIKRIZNI.Name = "label1VBDIKRIZNI";
            this.label1VBDIKRIZNI.TabIndex = 1;
            this.label1VBDIKRIZNI.Tag = "labelVBDIKRIZNI";
            this.label1VBDIKRIZNI.Text = "VBDI:";
            this.label1VBDIKRIZNI.StyleSetName = "FieldUltraLabel";
            this.label1VBDIKRIZNI.AutoSize = true;
            this.label1VBDIKRIZNI.Anchor = AnchorStyles.Left;
            this.label1VBDIKRIZNI.Appearance.TextVAlign = VAlign.Middle;
            this.label1VBDIKRIZNI.Appearance.ForeColor = Color.Black;
            this.label1VBDIKRIZNI.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1VBDIKRIZNI, 0, 14);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1VBDIKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1VBDIKRIZNI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VBDIKRIZNI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VBDIKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x17);
            this.label1VBDIKRIZNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVBDIKRIZNI.Location = point;
            this.textVBDIKRIZNI.Name = "textVBDIKRIZNI";
            this.textVBDIKRIZNI.Tag = "VBDIKRIZNI";
            this.textVBDIKRIZNI.TabIndex = 0;
            this.textVBDIKRIZNI.Anchor = AnchorStyles.Left;
            this.textVBDIKRIZNI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVBDIKRIZNI.ReadOnly = false;
            this.textVBDIKRIZNI.DataBindings.Add(new Binding("Text", this.bindingSourceKRIZNIPOREZ, "VBDIKRIZNI"));
            this.textVBDIKRIZNI.MaxLength = 7;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textVBDIKRIZNI, 1, 14);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textVBDIKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textVBDIKRIZNI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVBDIKRIZNI.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDIKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDIKRIZNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZRNKRIZNI.Location = point;
            this.label1ZRNKRIZNI.Name = "label1ZRNKRIZNI";
            this.label1ZRNKRIZNI.TabIndex = 1;
            this.label1ZRNKRIZNI.Tag = "labelZRNKRIZNI";
            this.label1ZRNKRIZNI.Text = "Žiro račun:";
            this.label1ZRNKRIZNI.StyleSetName = "FieldUltraLabel";
            this.label1ZRNKRIZNI.AutoSize = true;
            this.label1ZRNKRIZNI.Anchor = AnchorStyles.Left;
            this.label1ZRNKRIZNI.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZRNKRIZNI.Appearance.ForeColor = Color.Black;
            this.label1ZRNKRIZNI.BackColor = Color.Transparent;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.label1ZRNKRIZNI, 0, 15);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.label1ZRNKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.label1ZRNKRIZNI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZRNKRIZNI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZRNKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(0x52, 0x17);
            this.label1ZRNKRIZNI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZRNKRIZNI.Location = point;
            this.textZRNKRIZNI.Name = "textZRNKRIZNI";
            this.textZRNKRIZNI.Tag = "ZRNKRIZNI";
            this.textZRNKRIZNI.TabIndex = 0;
            this.textZRNKRIZNI.Anchor = AnchorStyles.Left;
            this.textZRNKRIZNI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZRNKRIZNI.ReadOnly = false;
            this.textZRNKRIZNI.DataBindings.Add(new Binding("Text", this.bindingSourceKRIZNIPOREZ, "ZRNKRIZNI"));
            this.textZRNKRIZNI.MaxLength = 10;
            this.layoutManagerformKRIZNIPOREZ.Controls.Add(this.textZRNKRIZNI, 1, 15);
            this.layoutManagerformKRIZNIPOREZ.SetColumnSpan(this.textZRNKRIZNI, 1);
            this.layoutManagerformKRIZNIPOREZ.SetRowSpan(this.textZRNKRIZNI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZRNKRIZNI.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZRNKRIZNI.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZRNKRIZNI.Size = size;
            this.Controls.Add(this.layoutManagerformKRIZNIPOREZ);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceKRIZNIPOREZ;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "KRIZNIPOREZFormUserControl";
            this.Text = "KRIZNIPOREZ";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.KRIZNIPOREZFormUserControl_Load);
            this.layoutManagerformKRIZNIPOREZ.ResumeLayout(false);
            this.layoutManagerformKRIZNIPOREZ.PerformLayout();
            ((ISupportInitialize) this.bindingSourceKRIZNIPOREZ).EndInit();
            ((ISupportInitialize) this.textIDKRIZNIPOREZ).EndInit();
            ((ISupportInitialize) this.textNAZIVKRIZNIPOREZ).EndInit();
            ((ISupportInitialize) this.textKRIZNISTOPA).EndInit();
            ((ISupportInitialize) this.textKRIZNIOD).EndInit();
            ((ISupportInitialize) this.textKRIZNIDO).EndInit();
            ((ISupportInitialize) this.textMOKRIZNI).EndInit();
            ((ISupportInitialize) this.textPOKRIZNI).EndInit();
            ((ISupportInitialize) this.textMZKRIZNI).EndInit();
            ((ISupportInitialize) this.textPZKRIZNI).EndInit();
            ((ISupportInitialize) this.textPRIMATELJKRIZNI1).EndInit();
            ((ISupportInitialize) this.textPRIMATELJKRIZNI2).EndInit();
            ((ISupportInitialize) this.textPRIMATELJKRIZNI3).EndInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJAKRIZNI).EndInit();
            ((ISupportInitialize) this.textOPISPLACANJAKRIZNI).EndInit();
            ((ISupportInitialize) this.textVBDIKRIZNI).EndInit();
            ((ISupportInitialize) this.textZRNKRIZNI).EndInit();
            this.dsKRIZNIPOREZDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.KRIZNIPOREZController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceKRIZNIPOREZ, this.KRIZNIPOREZController.WorkItem, this))
            {
                return false;
            }
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void KRIZNIPOREZFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.KRIZNIPOREZDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void Localize()
        {
            this.label1IDKRIZNIPOREZ.Text = StringResources.KRIZNIPOREZIDKRIZNIPOREZDescription;
            this.label1NAZIVKRIZNIPOREZ.Text = StringResources.KRIZNIPOREZNAZIVKRIZNIPOREZDescription;
            this.label1KRIZNISTOPA.Text = StringResources.KRIZNIPOREZKRIZNISTOPADescription;
            this.label1KRIZNIOD.Text = StringResources.KRIZNIPOREZKRIZNIODDescription;
            this.label1KRIZNIDO.Text = StringResources.KRIZNIPOREZKRIZNIDODescription;
            this.label1MOKRIZNI.Text = StringResources.KRIZNIPOREZMOKRIZNIDescription;
            this.label1POKRIZNI.Text = StringResources.KRIZNIPOREZPOKRIZNIDescription;
            this.label1MZKRIZNI.Text = StringResources.KRIZNIPOREZMZKRIZNIDescription;
            this.label1PZKRIZNI.Text = StringResources.KRIZNIPOREZPZKRIZNIDescription;
            this.label1PRIMATELJKRIZNI1.Text = StringResources.KRIZNIPOREZPRIMATELJKRIZNI1Description;
            this.label1PRIMATELJKRIZNI2.Text = StringResources.KRIZNIPOREZPRIMATELJKRIZNI2Description;
            this.label1PRIMATELJKRIZNI3.Text = StringResources.KRIZNIPOREZPRIMATELJKRIZNI3Description;
            this.label1SIFRAOPISAPLACANJAKRIZNI.Text = StringResources.KRIZNIPOREZSIFRAOPISAPLACANJAKRIZNIDescription;
            this.label1OPISPLACANJAKRIZNI.Text = StringResources.KRIZNIPOREZOPISPLACANJAKRIZNIDescription;
            this.label1VBDIKRIZNI.Text = StringResources.KRIZNIPOREZVBDIKRIZNIDescription;
            this.label1ZRNKRIZNI.Text = StringResources.KRIZNIPOREZZRNKRIZNIDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.KRIZNIPOREZController.WorkItem.Items.Contains("KRIZNIPOREZ|KRIZNIPOREZ"))
            {
                this.KRIZNIPOREZController.WorkItem.Items.Add(this.bindingSourceKRIZNIPOREZ, "KRIZNIPOREZ|KRIZNIPOREZ");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsKRIZNIPOREZDataSet1.KRIZNIPOREZ.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.KRIZNIPOREZController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.KRIZNIPOREZController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.KRIZNIPOREZController.Update(this))
            {
                this.KRIZNIPOREZController.DataSet = new KRIZNIPOREZDataSet();
                DataSetUtil.AddEmptyRow(this.KRIZNIPOREZController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.KRIZNIPOREZController.DataSet.KRIZNIPOREZ[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDKRIZNIPOREZ.Focus();
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.KRIZNIPOREZController KRIZNIPOREZController { get; set; }

        protected virtual UltraLabel label1IDKRIZNIPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDKRIZNIPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDKRIZNIPOREZ = value;
            }
        }

        protected virtual UltraLabel label1KRIZNIDO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KRIZNIDO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KRIZNIDO = value;
            }
        }

        protected virtual UltraLabel label1KRIZNIOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KRIZNIOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KRIZNIOD = value;
            }
        }

        protected virtual UltraLabel label1KRIZNISTOPA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KRIZNISTOPA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KRIZNISTOPA = value;
            }
        }

        protected virtual UltraLabel label1MOKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MOKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MOKRIZNI = value;
            }
        }

        protected virtual UltraLabel label1MZKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MZKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MZKRIZNI = value;
            }
        }

        protected virtual UltraLabel label1NAZIVKRIZNIPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVKRIZNIPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVKRIZNIPOREZ = value;
            }
        }

        protected virtual UltraLabel label1OPISPLACANJAKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISPLACANJAKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISPLACANJAKRIZNI = value;
            }
        }

        protected virtual UltraLabel label1POKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POKRIZNI = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJKRIZNI1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJKRIZNI1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJKRIZNI1 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJKRIZNI2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJKRIZNI2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJKRIZNI2 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJKRIZNI3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJKRIZNI3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJKRIZNI3 = value;
            }
        }

        protected virtual UltraLabel label1PZKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PZKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PZKRIZNI = value;
            }
        }

        protected virtual UltraLabel label1SIFRAOPISAPLACANJAKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAOPISAPLACANJAKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAOPISAPLACANJAKRIZNI = value;
            }
        }

        protected virtual UltraLabel label1VBDIKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VBDIKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VBDIKRIZNI = value;
            }
        }

        protected virtual UltraLabel label1ZRNKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZRNKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZRNKRIZNI = value;
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

        protected virtual UltraNumericEditor textIDKRIZNIPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDKRIZNIPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDKRIZNIPOREZ = value;
            }
        }

        protected virtual UltraNumericEditor textKRIZNIDO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textKRIZNIDO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textKRIZNIDO = value;
            }
        }

        protected virtual UltraNumericEditor textKRIZNIOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textKRIZNIOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textKRIZNIOD = value;
            }
        }

        protected virtual UltraNumericEditor textKRIZNISTOPA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textKRIZNISTOPA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textKRIZNISTOPA = value;
            }
        }

        protected virtual UltraTextEditor textMOKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMOKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMOKRIZNI = value;
            }
        }

        protected virtual UltraTextEditor textMZKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMZKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMZKRIZNI = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVKRIZNIPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVKRIZNIPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVKRIZNIPOREZ = value;
            }
        }

        protected virtual UltraTextEditor textOPISPLACANJAKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPISPLACANJAKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPISPLACANJAKRIZNI = value;
            }
        }

        protected virtual UltraTextEditor textPOKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOKRIZNI = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJKRIZNI1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJKRIZNI1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJKRIZNI1 = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJKRIZNI2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJKRIZNI2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJKRIZNI2 = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJKRIZNI3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJKRIZNI3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJKRIZNI3 = value;
            }
        }

        protected virtual UltraTextEditor textPZKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPZKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPZKRIZNI = value;
            }
        }

        protected virtual UltraTextEditor textSIFRAOPISAPLACANJAKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSIFRAOPISAPLACANJAKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSIFRAOPISAPLACANJAKRIZNI = value;
            }
        }

        protected virtual UltraTextEditor textVBDIKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVBDIKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVBDIKRIZNI = value;
            }
        }

        protected virtual UltraTextEditor textZRNKRIZNI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZRNKRIZNI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZRNKRIZNI = value;
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

