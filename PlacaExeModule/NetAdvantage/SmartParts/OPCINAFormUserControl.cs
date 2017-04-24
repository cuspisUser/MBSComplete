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
    public class OPCINAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDOPCINE")]
        private UltraLabel _label1IDOPCINE;
        [AccessedThroughProperty("label1NAZIVOPCINE")]
        private UltraLabel _label1NAZIVOPCINE;
        [AccessedThroughProperty("label1PRIREZ")]
        private UltraLabel _label1PRIREZ;
        [AccessedThroughProperty("label1VBDIOPCINA")]
        private UltraLabel _label1VBDIOPCINA;
        [AccessedThroughProperty("label1ZRNOPCINA")]
        private UltraLabel _label1ZRNOPCINA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDOPCINE")]
        private UltraTextEditor _textIDOPCINE;
        [AccessedThroughProperty("textNAZIVOPCINE")]
        private UltraTextEditor _textNAZIVOPCINE;
        [AccessedThroughProperty("textPRIREZ")]
        private UltraNumericEditor _textPRIREZ;
        [AccessedThroughProperty("textVBDIOPCINA")]
        private UltraTextEditor _textVBDIOPCINA;
        [AccessedThroughProperty("textZRNOPCINA")]
        private UltraTextEditor _textZRNOPCINA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceOPCINA;
        private IContainer components = null;
        private OPCINADataSet dsOPCINADataSet1;
        protected TableLayoutPanel layoutManagerformOPCINA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OPCINADataSet.OPCINARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "OPCINA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.OPCINADescription;
        private DeklaritMode m_Mode;

        public OPCINAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceOPCINA.DataSource = this.OPCINAController.DataSet;
            this.dsOPCINADataSet1 = this.OPCINAController.DataSet;
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
                    enumerator = this.dsOPCINADataSet1.OPCINA.Rows.GetEnumerator();
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
                if (this.OPCINAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OPCINA", this.m_Mode, this.dsOPCINADataSet1, this.dsOPCINADataSet1.OPCINA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsOPCINADataSet1.OPCINA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (OPCINADataSet.OPCINARow) ((DataRowView) this.bindingSourceOPCINA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(OPCINAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceOPCINA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOPCINA).BeginInit();
            this.layoutManagerformOPCINA = new TableLayoutPanel();
            this.layoutManagerformOPCINA.SuspendLayout();
            this.layoutManagerformOPCINA.AutoSize = true;
            this.layoutManagerformOPCINA.Dock = DockStyle.Fill;
            this.layoutManagerformOPCINA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformOPCINA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformOPCINA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformOPCINA.Size = size;
            this.layoutManagerformOPCINA.ColumnCount = 2;
            this.layoutManagerformOPCINA.RowCount = 6;
            this.layoutManagerformOPCINA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOPCINA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOPCINA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOPCINA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOPCINA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOPCINA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOPCINA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOPCINA.RowStyles.Add(new RowStyle());
            this.label1IDOPCINE = new UltraLabel();
            this.textIDOPCINE = new UltraTextEditor();
            this.label1NAZIVOPCINE = new UltraLabel();
            this.textNAZIVOPCINE = new UltraTextEditor();
            this.label1PRIREZ = new UltraLabel();
            this.textPRIREZ = new UltraNumericEditor();
            this.label1VBDIOPCINA = new UltraLabel();
            this.textVBDIOPCINA = new UltraTextEditor();
            this.label1ZRNOPCINA = new UltraLabel();
            this.textZRNOPCINA = new UltraTextEditor();
            ((ISupportInitialize) this.textIDOPCINE).BeginInit();
            ((ISupportInitialize) this.textNAZIVOPCINE).BeginInit();
            ((ISupportInitialize) this.textPRIREZ).BeginInit();
            ((ISupportInitialize) this.textVBDIOPCINA).BeginInit();
            ((ISupportInitialize) this.textZRNOPCINA).BeginInit();
            this.dsOPCINADataSet1 = new OPCINADataSet();
            this.dsOPCINADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsOPCINADataSet1.DataSetName = "dsOPCINA";
            this.dsOPCINADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceOPCINA.DataSource = this.dsOPCINADataSet1;
            this.bindingSourceOPCINA.DataMember = "OPCINA";
            ((ISupportInitialize) this.bindingSourceOPCINA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDOPCINE.Location = point;
            this.label1IDOPCINE.Name = "label1IDOPCINE";
            this.label1IDOPCINE.TabIndex = 1;
            this.label1IDOPCINE.Tag = "labelIDOPCINE";
            this.label1IDOPCINE.Text = "Šifra općine:";
            this.label1IDOPCINE.StyleSetName = "FieldUltraLabel";
            this.label1IDOPCINE.AutoSize = true;
            this.label1IDOPCINE.Anchor = AnchorStyles.Left;
            this.label1IDOPCINE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOPCINE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDOPCINE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDOPCINE.ImageSize = size;
            this.label1IDOPCINE.Appearance.ForeColor = Color.Black;
            this.label1IDOPCINE.BackColor = Color.Transparent;
            this.layoutManagerformOPCINA.Controls.Add(this.label1IDOPCINE, 0, 0);
            this.layoutManagerformOPCINA.SetColumnSpan(this.label1IDOPCINE, 1);
            this.layoutManagerformOPCINA.SetRowSpan(this.label1IDOPCINE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDOPCINE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(90, 0x17);
            this.label1IDOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDOPCINE.Location = point;
            this.textIDOPCINE.Name = "textIDOPCINE";
            this.textIDOPCINE.Tag = "IDOPCINE";
            this.textIDOPCINE.TabIndex = 0;
            this.textIDOPCINE.Anchor = AnchorStyles.Left;
            this.textIDOPCINE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDOPCINE.ReadOnly = false;
            this.textIDOPCINE.DataBindings.Add(new Binding("Text", this.bindingSourceOPCINA, "IDOPCINE"));
            this.textIDOPCINE.MaxLength = 4;
            this.layoutManagerformOPCINA.Controls.Add(this.textIDOPCINE, 1, 0);
            this.layoutManagerformOPCINA.SetColumnSpan(this.textIDOPCINE, 1);
            this.layoutManagerformOPCINA.SetRowSpan(this.textIDOPCINE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOPCINE.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textIDOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textIDOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVOPCINE.Location = point;
            this.label1NAZIVOPCINE.Name = "label1NAZIVOPCINE";
            this.label1NAZIVOPCINE.TabIndex = 1;
            this.label1NAZIVOPCINE.Tag = "labelNAZIVOPCINE";
            this.label1NAZIVOPCINE.Text = "Naziv općine:";
            this.label1NAZIVOPCINE.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVOPCINE.AutoSize = true;
            this.label1NAZIVOPCINE.Anchor = AnchorStyles.Left;
            this.label1NAZIVOPCINE.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVOPCINE.Appearance.ForeColor = Color.Black;
            this.label1NAZIVOPCINE.BackColor = Color.Transparent;
            this.layoutManagerformOPCINA.Controls.Add(this.label1NAZIVOPCINE, 0, 1);
            this.layoutManagerformOPCINA.SetColumnSpan(this.label1NAZIVOPCINE, 1);
            this.layoutManagerformOPCINA.SetRowSpan(this.label1NAZIVOPCINE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVOPCINE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0x62, 0x17);
            this.label1NAZIVOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVOPCINE.Location = point;
            this.textNAZIVOPCINE.Name = "textNAZIVOPCINE";
            this.textNAZIVOPCINE.Tag = "NAZIVOPCINE";
            this.textNAZIVOPCINE.TabIndex = 0;
            this.textNAZIVOPCINE.Anchor = AnchorStyles.Left;
            this.textNAZIVOPCINE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVOPCINE.ReadOnly = false;
            this.textNAZIVOPCINE.DataBindings.Add(new Binding("Text", this.bindingSourceOPCINA, "NAZIVOPCINE"));
            this.textNAZIVOPCINE.MaxLength = 50;
            this.layoutManagerformOPCINA.Controls.Add(this.textNAZIVOPCINE, 1, 1);
            this.layoutManagerformOPCINA.SetColumnSpan(this.textNAZIVOPCINE, 1);
            this.layoutManagerformOPCINA.SetRowSpan(this.textNAZIVOPCINE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVOPCINE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIREZ.Location = point;
            this.label1PRIREZ.Name = "label1PRIREZ";
            this.label1PRIREZ.TabIndex = 1;
            this.label1PRIREZ.Tag = "labelPRIREZ";
            this.label1PRIREZ.Text = "Prirez općine:";
            this.label1PRIREZ.StyleSetName = "FieldUltraLabel";
            this.label1PRIREZ.AutoSize = true;
            this.label1PRIREZ.Anchor = AnchorStyles.Left;
            this.label1PRIREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIREZ.Appearance.ForeColor = Color.Black;
            this.label1PRIREZ.BackColor = Color.Transparent;
            this.layoutManagerformOPCINA.Controls.Add(this.label1PRIREZ, 0, 2);
            this.layoutManagerformOPCINA.SetColumnSpan(this.label1PRIREZ, 1);
            this.layoutManagerformOPCINA.SetRowSpan(this.label1PRIREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIREZ.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x17);
            this.label1PRIREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIREZ.Location = point;
            this.textPRIREZ.Name = "textPRIREZ";
            this.textPRIREZ.Tag = "PRIREZ";
            this.textPRIREZ.TabIndex = 0;
            this.textPRIREZ.Anchor = AnchorStyles.Left;
            this.textPRIREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIREZ.ReadOnly = false;
            this.textPRIREZ.PromptChar = ' ';
            this.textPRIREZ.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPRIREZ.DataBindings.Add(new Binding("Value", this.bindingSourceOPCINA, "PRIREZ"));
            this.textPRIREZ.NumericType = NumericType.Double;
            this.textPRIREZ.MaxValue = 79228162514264337593543950335M;
            this.textPRIREZ.MinValue = -79228162514264337593543950335M;
            this.textPRIREZ.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOPCINA.Controls.Add(this.textPRIREZ, 1, 2);
            this.layoutManagerformOPCINA.SetColumnSpan(this.textPRIREZ, 1);
            this.layoutManagerformOPCINA.SetRowSpan(this.textPRIREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIREZ.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textPRIREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textPRIREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VBDIOPCINA.Location = point;
            this.label1VBDIOPCINA.Name = "label1VBDIOPCINA";
            this.label1VBDIOPCINA.TabIndex = 1;
            this.label1VBDIOPCINA.Tag = "labelVBDIOPCINA";
            this.label1VBDIOPCINA.Text = "VBDI žiro računa općine:";
            this.label1VBDIOPCINA.StyleSetName = "FieldUltraLabel";
            this.label1VBDIOPCINA.AutoSize = true;
            this.label1VBDIOPCINA.Anchor = AnchorStyles.Left;
            this.label1VBDIOPCINA.Appearance.TextVAlign = VAlign.Middle;
            this.label1VBDIOPCINA.Appearance.ForeColor = Color.Black;
            this.label1VBDIOPCINA.BackColor = Color.Transparent;
            this.layoutManagerformOPCINA.Controls.Add(this.label1VBDIOPCINA, 0, 3);
            this.layoutManagerformOPCINA.SetColumnSpan(this.label1VBDIOPCINA, 1);
            this.layoutManagerformOPCINA.SetRowSpan(this.label1VBDIOPCINA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VBDIOPCINA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VBDIOPCINA.MinimumSize = size;
            size = new System.Drawing.Size(0xa9, 0x17);
            this.label1VBDIOPCINA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVBDIOPCINA.Location = point;
            this.textVBDIOPCINA.Name = "textVBDIOPCINA";
            this.textVBDIOPCINA.Tag = "VBDIOPCINA";
            this.textVBDIOPCINA.TabIndex = 0;
            this.textVBDIOPCINA.Anchor = AnchorStyles.Left;
            this.textVBDIOPCINA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVBDIOPCINA.ReadOnly = false;
            this.textVBDIOPCINA.DataBindings.Add(new Binding("Text", this.bindingSourceOPCINA, "VBDIOPCINA"));
            this.textVBDIOPCINA.MaxLength = 7;
            this.layoutManagerformOPCINA.Controls.Add(this.textVBDIOPCINA, 1, 3);
            this.layoutManagerformOPCINA.SetColumnSpan(this.textVBDIOPCINA, 1);
            this.layoutManagerformOPCINA.SetRowSpan(this.textVBDIOPCINA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVBDIOPCINA.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDIOPCINA.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDIOPCINA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZRNOPCINA.Location = point;
            this.label1ZRNOPCINA.Name = "label1ZRNOPCINA";
            this.label1ZRNOPCINA.TabIndex = 1;
            this.label1ZRNOPCINA.Tag = "labelZRNOPCINA";
            this.label1ZRNOPCINA.Text = "Broj žiro računa općine:";
            this.label1ZRNOPCINA.StyleSetName = "FieldUltraLabel";
            this.label1ZRNOPCINA.AutoSize = true;
            this.label1ZRNOPCINA.Anchor = AnchorStyles.Left;
            this.label1ZRNOPCINA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZRNOPCINA.Appearance.ForeColor = Color.Black;
            this.label1ZRNOPCINA.BackColor = Color.Transparent;
            this.layoutManagerformOPCINA.Controls.Add(this.label1ZRNOPCINA, 0, 4);
            this.layoutManagerformOPCINA.SetColumnSpan(this.label1ZRNOPCINA, 1);
            this.layoutManagerformOPCINA.SetRowSpan(this.label1ZRNOPCINA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZRNOPCINA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZRNOPCINA.MinimumSize = size;
            size = new System.Drawing.Size(0xa2, 0x17);
            this.label1ZRNOPCINA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZRNOPCINA.Location = point;
            this.textZRNOPCINA.Name = "textZRNOPCINA";
            this.textZRNOPCINA.Tag = "ZRNOPCINA";
            this.textZRNOPCINA.TabIndex = 0;
            this.textZRNOPCINA.Anchor = AnchorStyles.Left;
            this.textZRNOPCINA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZRNOPCINA.ReadOnly = false;
            this.textZRNOPCINA.DataBindings.Add(new Binding("Text", this.bindingSourceOPCINA, "ZRNOPCINA"));
            this.textZRNOPCINA.MaxLength = 10;
            this.layoutManagerformOPCINA.Controls.Add(this.textZRNOPCINA, 1, 4);
            this.layoutManagerformOPCINA.SetColumnSpan(this.textZRNOPCINA, 1);
            this.layoutManagerformOPCINA.SetRowSpan(this.textZRNOPCINA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZRNOPCINA.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZRNOPCINA.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZRNOPCINA.Size = size;
            this.Controls.Add(this.layoutManagerformOPCINA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceOPCINA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "OPCINAFormUserControl";
            this.Text = "Opaine";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OPCINAFormUserControl_Load);
            this.layoutManagerformOPCINA.ResumeLayout(false);
            this.layoutManagerformOPCINA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceOPCINA).EndInit();
            ((ISupportInitialize) this.textIDOPCINE).EndInit();
            ((ISupportInitialize) this.textNAZIVOPCINE).EndInit();
            ((ISupportInitialize) this.textPRIREZ).EndInit();
            ((ISupportInitialize) this.textVBDIOPCINA).EndInit();
            ((ISupportInitialize) this.textZRNOPCINA).EndInit();
            this.dsOPCINADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OPCINAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceOPCINA, this.OPCINAController.WorkItem, this))
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
            this.label1IDOPCINE.Text = StringResources.OPCINAIDOPCINEDescription;
            this.label1NAZIVOPCINE.Text = StringResources.OPCINANAZIVOPCINEDescription;
            this.label1PRIREZ.Text = StringResources.OPCINAPRIREZDescription;
            this.label1VBDIOPCINA.Text = StringResources.OPCINAVBDIOPCINADescription;
            this.label1ZRNOPCINA.Text = StringResources.OPCINAZRNOPCINADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewDDRADNIK1")]
        public void NewDDRADNIK1Handler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OPCINAController.NewDDRADNIK1(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewDDRADNIK")]
        public void NewDDRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OPCINAController.NewDDRADNIK(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewRADNIK1")]
        public void NewRADNIK1Handler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OPCINAController.NewRADNIK1(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewRADNIK")]
        public void NewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OPCINAController.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void OPCINAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OPCINADescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.OPCINAController.WorkItem.Items.Contains("OPCINA|OPCINA"))
            {
                this.OPCINAController.WorkItem.Items.Add(this.bindingSourceOPCINA, "OPCINA|OPCINA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsOPCINADataSet1.OPCINA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.OPCINAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OPCINAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OPCINAController.Update(this))
            {
                this.OPCINAController.DataSet = new OPCINADataSet();
                DataSetUtil.AddEmptyRow(this.OPCINAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.OPCINAController.DataSet.OPCINA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDOPCINE.Focus();
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

        [LocalCommandHandler("ViewDDRADNIK1")]
        public void ViewDDRADNIK1Handler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OPCINAController.ViewDDRADNIK1(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewDDRADNIK")]
        public void ViewDDRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OPCINAController.ViewDDRADNIK(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewRADNIK1")]
        public void ViewRADNIK1Handler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OPCINAController.ViewRADNIK1(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewRADNIK")]
        public void ViewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OPCINAController.ViewRADNIK(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOPCINE = value;
            }
        }

        protected virtual UltraLabel label1NAZIVOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVOPCINE = value;
            }
        }

        protected virtual UltraLabel label1PRIREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIREZ = value;
            }
        }

        protected virtual UltraLabel label1VBDIOPCINA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VBDIOPCINA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VBDIOPCINA = value;
            }
        }

        protected virtual UltraLabel label1ZRNOPCINA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZRNOPCINA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZRNOPCINA = value;
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
        public NetAdvantage.Controllers.OPCINAController OPCINAController { get; set; }

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

        protected virtual UltraTextEditor textIDOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDOPCINE = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVOPCINE = value;
            }
        }

        protected virtual UltraNumericEditor textPRIREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIREZ = value;
            }
        }

        protected virtual UltraTextEditor textVBDIOPCINA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVBDIOPCINA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVBDIOPCINA = value;
            }
        }

        protected virtual UltraTextEditor textZRNOPCINA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZRNOPCINA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZRNOPCINA = value;
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

