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
    public class KREDITORFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDKREDITOR")]
        private UltraLabel _label1IDKREDITOR;
        [AccessedThroughProperty("label1NAZIVKREDITOR")]
        private UltraLabel _label1NAZIVKREDITOR;
        [AccessedThroughProperty("label1PRIMATELJKREDITOR1")]
        private UltraLabel _label1PRIMATELJKREDITOR1;
        [AccessedThroughProperty("label1PRIMATELJKREDITOR2")]
        private UltraLabel _label1PRIMATELJKREDITOR2;
        [AccessedThroughProperty("label1PRIMATELJKREDITOR3")]
        private UltraLabel _label1PRIMATELJKREDITOR3;
        [AccessedThroughProperty("label1VBDIKREDITOR")]
        private UltraLabel _label1VBDIKREDITOR;
        [AccessedThroughProperty("label1ZRNKREDITOR")]
        private UltraLabel _label1ZRNKREDITOR;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDKREDITOR")]
        private UltraNumericEditor _textIDKREDITOR;
        [AccessedThroughProperty("textNAZIVKREDITOR")]
        private UltraTextEditor _textNAZIVKREDITOR;
        [AccessedThroughProperty("textPRIMATELJKREDITOR1")]
        private UltraTextEditor _textPRIMATELJKREDITOR1;
        [AccessedThroughProperty("textPRIMATELJKREDITOR2")]
        private UltraTextEditor _textPRIMATELJKREDITOR2;
        [AccessedThroughProperty("textPRIMATELJKREDITOR3")]
        private UltraTextEditor _textPRIMATELJKREDITOR3;
        [AccessedThroughProperty("textVBDIKREDITOR")]
        private UltraTextEditor _textVBDIKREDITOR;
        [AccessedThroughProperty("textZRNKREDITOR")]
        private UltraTextEditor _textZRNKREDITOR;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceKREDITOR;
        private IContainer components = null;
        private KREDITORDataSet dsKREDITORDataSet1;
        protected TableLayoutPanel layoutManagerformKREDITOR;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private KREDITORDataSet.KREDITORRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "KREDITOR";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.KREDITORDescription;
        private DeklaritMode m_Mode;

        public KREDITORFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceKREDITOR.DataSource = this.KREDITORController.DataSet;
            this.dsKREDITORDataSet1 = this.KREDITORController.DataSet;
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
                    enumerator = this.dsKREDITORDataSet1.KREDITOR.Rows.GetEnumerator();
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
                if (this.KREDITORController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "KREDITOR", this.m_Mode, this.dsKREDITORDataSet1, this.dsKREDITORDataSet1.KREDITOR.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsKREDITORDataSet1.KREDITOR[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (KREDITORDataSet.KREDITORRow) ((DataRowView) this.bindingSourceKREDITOR.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(KREDITORFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceKREDITOR = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceKREDITOR).BeginInit();
            this.layoutManagerformKREDITOR = new TableLayoutPanel();
            this.layoutManagerformKREDITOR.SuspendLayout();
            this.layoutManagerformKREDITOR.AutoSize = true;
            this.layoutManagerformKREDITOR.Dock = DockStyle.Fill;
            this.layoutManagerformKREDITOR.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformKREDITOR.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformKREDITOR.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformKREDITOR.Size = size;
            this.layoutManagerformKREDITOR.ColumnCount = 2;
            this.layoutManagerformKREDITOR.RowCount = 8;
            this.layoutManagerformKREDITOR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformKREDITOR.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformKREDITOR.RowStyles.Add(new RowStyle());
            this.layoutManagerformKREDITOR.RowStyles.Add(new RowStyle());
            this.layoutManagerformKREDITOR.RowStyles.Add(new RowStyle());
            this.layoutManagerformKREDITOR.RowStyles.Add(new RowStyle());
            this.layoutManagerformKREDITOR.RowStyles.Add(new RowStyle());
            this.layoutManagerformKREDITOR.RowStyles.Add(new RowStyle());
            this.layoutManagerformKREDITOR.RowStyles.Add(new RowStyle());
            this.layoutManagerformKREDITOR.RowStyles.Add(new RowStyle());
            this.label1IDKREDITOR = new UltraLabel();
            this.textIDKREDITOR = new UltraNumericEditor();
            this.label1NAZIVKREDITOR = new UltraLabel();
            this.textNAZIVKREDITOR = new UltraTextEditor();
            this.label1VBDIKREDITOR = new UltraLabel();
            this.textVBDIKREDITOR = new UltraTextEditor();
            this.label1ZRNKREDITOR = new UltraLabel();
            this.textZRNKREDITOR = new UltraTextEditor();
            this.label1PRIMATELJKREDITOR1 = new UltraLabel();
            this.textPRIMATELJKREDITOR1 = new UltraTextEditor();
            this.label1PRIMATELJKREDITOR2 = new UltraLabel();
            this.textPRIMATELJKREDITOR2 = new UltraTextEditor();
            this.label1PRIMATELJKREDITOR3 = new UltraLabel();
            this.textPRIMATELJKREDITOR3 = new UltraTextEditor();
            ((ISupportInitialize) this.textIDKREDITOR).BeginInit();
            ((ISupportInitialize) this.textNAZIVKREDITOR).BeginInit();
            ((ISupportInitialize) this.textVBDIKREDITOR).BeginInit();
            ((ISupportInitialize) this.textZRNKREDITOR).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJKREDITOR1).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJKREDITOR2).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJKREDITOR3).BeginInit();
            this.dsKREDITORDataSet1 = new KREDITORDataSet();
            this.dsKREDITORDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsKREDITORDataSet1.DataSetName = "dsKREDITOR";
            this.dsKREDITORDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceKREDITOR.DataSource = this.dsKREDITORDataSet1;
            this.bindingSourceKREDITOR.DataMember = "KREDITOR";
            ((ISupportInitialize) this.bindingSourceKREDITOR).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDKREDITOR.Location = point;
            this.label1IDKREDITOR.Name = "label1IDKREDITOR";
            this.label1IDKREDITOR.TabIndex = 1;
            this.label1IDKREDITOR.Tag = "labelIDKREDITOR";
            this.label1IDKREDITOR.Text = "Šifra kreditora:";
            this.label1IDKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1IDKREDITOR.AutoSize = true;
            this.label1IDKREDITOR.Anchor = AnchorStyles.Left;
            this.label1IDKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDKREDITOR.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDKREDITOR.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDKREDITOR.ImageSize = size;
            this.label1IDKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1IDKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformKREDITOR.Controls.Add(this.label1IDKREDITOR, 0, 0);
            this.layoutManagerformKREDITOR.SetColumnSpan(this.label1IDKREDITOR, 1);
            this.layoutManagerformKREDITOR.SetRowSpan(this.label1IDKREDITOR, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x6a, 0x17);
            this.label1IDKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDKREDITOR.Location = point;
            this.textIDKREDITOR.Name = "textIDKREDITOR";
            this.textIDKREDITOR.Tag = "IDKREDITOR";
            this.textIDKREDITOR.TabIndex = 0;
            this.textIDKREDITOR.Anchor = AnchorStyles.Left;
            this.textIDKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDKREDITOR.ReadOnly = false;
            this.textIDKREDITOR.PromptChar = ' ';
            this.textIDKREDITOR.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDKREDITOR.DataBindings.Add(new Binding("Value", this.bindingSourceKREDITOR, "IDKREDITOR"));
            this.textIDKREDITOR.NumericType = NumericType.Integer;
            this.textIDKREDITOR.MaskInput = "99999999";
            this.layoutManagerformKREDITOR.Controls.Add(this.textIDKREDITOR, 1, 0);
            this.layoutManagerformKREDITOR.SetColumnSpan(this.textIDKREDITOR, 1);
            this.layoutManagerformKREDITOR.SetRowSpan(this.textIDKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVKREDITOR.Location = point;
            this.label1NAZIVKREDITOR.Name = "label1NAZIVKREDITOR";
            this.label1NAZIVKREDITOR.TabIndex = 1;
            this.label1NAZIVKREDITOR.Tag = "labelNAZIVKREDITOR";
            this.label1NAZIVKREDITOR.Text = "Naziv kreditora:";
            this.label1NAZIVKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVKREDITOR.AutoSize = true;
            this.label1NAZIVKREDITOR.Anchor = AnchorStyles.Left;
            this.label1NAZIVKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1NAZIVKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformKREDITOR.Controls.Add(this.label1NAZIVKREDITOR, 0, 1);
            this.layoutManagerformKREDITOR.SetColumnSpan(this.label1NAZIVKREDITOR, 1);
            this.layoutManagerformKREDITOR.SetRowSpan(this.label1NAZIVKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x72, 0x17);
            this.label1NAZIVKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVKREDITOR.Location = point;
            this.textNAZIVKREDITOR.Name = "textNAZIVKREDITOR";
            this.textNAZIVKREDITOR.Tag = "NAZIVKREDITOR";
            this.textNAZIVKREDITOR.TabIndex = 0;
            this.textNAZIVKREDITOR.Anchor = AnchorStyles.Left;
            this.textNAZIVKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVKREDITOR.ReadOnly = false;
            this.textNAZIVKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceKREDITOR, "NAZIVKREDITOR"));
            this.textNAZIVKREDITOR.MaxLength = 20;
            this.layoutManagerformKREDITOR.Controls.Add(this.textNAZIVKREDITOR, 1, 1);
            this.layoutManagerformKREDITOR.SetColumnSpan(this.textNAZIVKREDITOR, 1);
            this.layoutManagerformKREDITOR.SetRowSpan(this.textNAZIVKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textNAZIVKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textNAZIVKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VBDIKREDITOR.Location = point;
            this.label1VBDIKREDITOR.Name = "label1VBDIKREDITOR";
            this.label1VBDIKREDITOR.TabIndex = 1;
            this.label1VBDIKREDITOR.Tag = "labelVBDIKREDITOR";
            this.label1VBDIKREDITOR.Text = "VBDI kreditora:";
            this.label1VBDIKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1VBDIKREDITOR.AutoSize = true;
            this.label1VBDIKREDITOR.Anchor = AnchorStyles.Left;
            this.label1VBDIKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1VBDIKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1VBDIKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformKREDITOR.Controls.Add(this.label1VBDIKREDITOR, 0, 2);
            this.layoutManagerformKREDITOR.SetColumnSpan(this.label1VBDIKREDITOR, 1);
            this.layoutManagerformKREDITOR.SetRowSpan(this.label1VBDIKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VBDIKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VBDIKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x70, 0x17);
            this.label1VBDIKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVBDIKREDITOR.Location = point;
            this.textVBDIKREDITOR.Name = "textVBDIKREDITOR";
            this.textVBDIKREDITOR.Tag = "VBDIKREDITOR";
            this.textVBDIKREDITOR.TabIndex = 0;
            this.textVBDIKREDITOR.Anchor = AnchorStyles.Left;
            this.textVBDIKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVBDIKREDITOR.ReadOnly = false;
            this.textVBDIKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceKREDITOR, "VBDIKREDITOR"));
            this.textVBDIKREDITOR.MaxLength = 7;
            this.layoutManagerformKREDITOR.Controls.Add(this.textVBDIKREDITOR, 1, 2);
            this.layoutManagerformKREDITOR.SetColumnSpan(this.textVBDIKREDITOR, 1);
            this.layoutManagerformKREDITOR.SetRowSpan(this.textVBDIKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVBDIKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDIKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDIKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZRNKREDITOR.Location = point;
            this.label1ZRNKREDITOR.Name = "label1ZRNKREDITOR";
            this.label1ZRNKREDITOR.TabIndex = 1;
            this.label1ZRNKREDITOR.Tag = "labelZRNKREDITOR";
            this.label1ZRNKREDITOR.Text = "ŽRN kreditora:";
            this.label1ZRNKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1ZRNKREDITOR.AutoSize = true;
            this.label1ZRNKREDITOR.Anchor = AnchorStyles.Left;
            this.label1ZRNKREDITOR.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZRNKREDITOR.Appearance.ForeColor = Color.Black;
            this.label1ZRNKREDITOR.BackColor = Color.Transparent;
            this.layoutManagerformKREDITOR.Controls.Add(this.label1ZRNKREDITOR, 0, 3);
            this.layoutManagerformKREDITOR.SetColumnSpan(this.label1ZRNKREDITOR, 1);
            this.layoutManagerformKREDITOR.SetRowSpan(this.label1ZRNKREDITOR, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZRNKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZRNKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x6a, 0x17);
            this.label1ZRNKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZRNKREDITOR.Location = point;
            this.textZRNKREDITOR.Name = "textZRNKREDITOR";
            this.textZRNKREDITOR.Tag = "ZRNKREDITOR";
            this.textZRNKREDITOR.TabIndex = 0;
            this.textZRNKREDITOR.Anchor = AnchorStyles.Left;
            this.textZRNKREDITOR.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZRNKREDITOR.ReadOnly = false;
            this.textZRNKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceKREDITOR, "ZRNKREDITOR"));
            this.textZRNKREDITOR.MaxLength = 10;
            this.layoutManagerformKREDITOR.Controls.Add(this.textZRNKREDITOR, 1, 3);
            this.layoutManagerformKREDITOR.SetColumnSpan(this.textZRNKREDITOR, 1);
            this.layoutManagerformKREDITOR.SetRowSpan(this.textZRNKREDITOR, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZRNKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZRNKREDITOR.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZRNKREDITOR.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJKREDITOR1.Location = point;
            this.label1PRIMATELJKREDITOR1.Name = "label1PRIMATELJKREDITOR1";
            this.label1PRIMATELJKREDITOR1.TabIndex = 1;
            this.label1PRIMATELJKREDITOR1.Tag = "labelPRIMATELJKREDITOR1";
            this.label1PRIMATELJKREDITOR1.Text = "Primatelj kreditor (1):";
            this.label1PRIMATELJKREDITOR1.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJKREDITOR1.AutoSize = true;
            this.label1PRIMATELJKREDITOR1.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJKREDITOR1.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJKREDITOR1.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJKREDITOR1.BackColor = Color.Transparent;
            this.layoutManagerformKREDITOR.Controls.Add(this.label1PRIMATELJKREDITOR1, 0, 4);
            this.layoutManagerformKREDITOR.SetColumnSpan(this.label1PRIMATELJKREDITOR1, 1);
            this.layoutManagerformKREDITOR.SetRowSpan(this.label1PRIMATELJKREDITOR1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJKREDITOR1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJKREDITOR1.MinimumSize = size;
            size = new System.Drawing.Size(0x98, 0x17);
            this.label1PRIMATELJKREDITOR1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJKREDITOR1.Location = point;
            this.textPRIMATELJKREDITOR1.Name = "textPRIMATELJKREDITOR1";
            this.textPRIMATELJKREDITOR1.Tag = "PRIMATELJKREDITOR1";
            this.textPRIMATELJKREDITOR1.TabIndex = 0;
            this.textPRIMATELJKREDITOR1.Anchor = AnchorStyles.Left;
            this.textPRIMATELJKREDITOR1.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJKREDITOR1.ReadOnly = false;
            this.textPRIMATELJKREDITOR1.DataBindings.Add(new Binding("Text", this.bindingSourceKREDITOR, "PRIMATELJKREDITOR1"));
            this.textPRIMATELJKREDITOR1.MaxLength = 20;
            this.layoutManagerformKREDITOR.Controls.Add(this.textPRIMATELJKREDITOR1, 1, 4);
            this.layoutManagerformKREDITOR.SetColumnSpan(this.textPRIMATELJKREDITOR1, 1);
            this.layoutManagerformKREDITOR.SetRowSpan(this.textPRIMATELJKREDITOR1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJKREDITOR1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJKREDITOR1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJKREDITOR1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJKREDITOR2.Location = point;
            this.label1PRIMATELJKREDITOR2.Name = "label1PRIMATELJKREDITOR2";
            this.label1PRIMATELJKREDITOR2.TabIndex = 1;
            this.label1PRIMATELJKREDITOR2.Tag = "labelPRIMATELJKREDITOR2";
            this.label1PRIMATELJKREDITOR2.Text = "Primatelj kreditor (2):";
            this.label1PRIMATELJKREDITOR2.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJKREDITOR2.AutoSize = true;
            this.label1PRIMATELJKREDITOR2.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJKREDITOR2.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJKREDITOR2.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJKREDITOR2.BackColor = Color.Transparent;
            this.layoutManagerformKREDITOR.Controls.Add(this.label1PRIMATELJKREDITOR2, 0, 5);
            this.layoutManagerformKREDITOR.SetColumnSpan(this.label1PRIMATELJKREDITOR2, 1);
            this.layoutManagerformKREDITOR.SetRowSpan(this.label1PRIMATELJKREDITOR2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJKREDITOR2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJKREDITOR2.MinimumSize = size;
            size = new System.Drawing.Size(0x98, 0x17);
            this.label1PRIMATELJKREDITOR2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJKREDITOR2.Location = point;
            this.textPRIMATELJKREDITOR2.Name = "textPRIMATELJKREDITOR2";
            this.textPRIMATELJKREDITOR2.Tag = "PRIMATELJKREDITOR2";
            this.textPRIMATELJKREDITOR2.TabIndex = 0;
            this.textPRIMATELJKREDITOR2.Anchor = AnchorStyles.Left;
            this.textPRIMATELJKREDITOR2.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJKREDITOR2.ContextMenu = this.contextMenu1;
            this.textPRIMATELJKREDITOR2.ReadOnly = false;
            this.textPRIMATELJKREDITOR2.DataBindings.Add(new Binding("Text", this.bindingSourceKREDITOR, "PRIMATELJKREDITOR2"));
            this.textPRIMATELJKREDITOR2.Nullable = true;
            this.textPRIMATELJKREDITOR2.MaxLength = 20;
            this.layoutManagerformKREDITOR.Controls.Add(this.textPRIMATELJKREDITOR2, 1, 5);
            this.layoutManagerformKREDITOR.SetColumnSpan(this.textPRIMATELJKREDITOR2, 1);
            this.layoutManagerformKREDITOR.SetRowSpan(this.textPRIMATELJKREDITOR2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJKREDITOR2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJKREDITOR2.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJKREDITOR2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJKREDITOR3.Location = point;
            this.label1PRIMATELJKREDITOR3.Name = "label1PRIMATELJKREDITOR3";
            this.label1PRIMATELJKREDITOR3.TabIndex = 1;
            this.label1PRIMATELJKREDITOR3.Tag = "labelPRIMATELJKREDITOR3";
            this.label1PRIMATELJKREDITOR3.Text = "Primatelj kreditor (3):";
            this.label1PRIMATELJKREDITOR3.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJKREDITOR3.AutoSize = true;
            this.label1PRIMATELJKREDITOR3.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJKREDITOR3.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJKREDITOR3.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJKREDITOR3.BackColor = Color.Transparent;
            this.layoutManagerformKREDITOR.Controls.Add(this.label1PRIMATELJKREDITOR3, 0, 6);
            this.layoutManagerformKREDITOR.SetColumnSpan(this.label1PRIMATELJKREDITOR3, 1);
            this.layoutManagerformKREDITOR.SetRowSpan(this.label1PRIMATELJKREDITOR3, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJKREDITOR3.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJKREDITOR3.MinimumSize = size;
            size = new System.Drawing.Size(0x98, 0x17);
            this.label1PRIMATELJKREDITOR3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJKREDITOR3.Location = point;
            this.textPRIMATELJKREDITOR3.Name = "textPRIMATELJKREDITOR3";
            this.textPRIMATELJKREDITOR3.Tag = "PRIMATELJKREDITOR3";
            this.textPRIMATELJKREDITOR3.TabIndex = 0;
            this.textPRIMATELJKREDITOR3.Anchor = AnchorStyles.Left;
            this.textPRIMATELJKREDITOR3.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJKREDITOR3.ContextMenu = this.contextMenu1;
            this.textPRIMATELJKREDITOR3.ReadOnly = false;
            this.textPRIMATELJKREDITOR3.DataBindings.Add(new Binding("Text", this.bindingSourceKREDITOR, "PRIMATELJKREDITOR3"));
            this.textPRIMATELJKREDITOR3.Nullable = true;
            this.textPRIMATELJKREDITOR3.MaxLength = 20;
            this.layoutManagerformKREDITOR.Controls.Add(this.textPRIMATELJKREDITOR3, 1, 6);
            this.layoutManagerformKREDITOR.SetColumnSpan(this.textPRIMATELJKREDITOR3, 1);
            this.layoutManagerformKREDITOR.SetRowSpan(this.textPRIMATELJKREDITOR3, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJKREDITOR3.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJKREDITOR3.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJKREDITOR3.Size = size;
            this.Controls.Add(this.layoutManagerformKREDITOR);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceKREDITOR;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "KREDITORFormUserControl";
            this.Text = "Kreditori";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.KREDITORFormUserControl_Load);
            this.layoutManagerformKREDITOR.ResumeLayout(false);
            this.layoutManagerformKREDITOR.PerformLayout();
            ((ISupportInitialize) this.bindingSourceKREDITOR).EndInit();
            ((ISupportInitialize) this.textIDKREDITOR).EndInit();
            ((ISupportInitialize) this.textNAZIVKREDITOR).EndInit();
            ((ISupportInitialize) this.textVBDIKREDITOR).EndInit();
            ((ISupportInitialize) this.textZRNKREDITOR).EndInit();
            ((ISupportInitialize) this.textPRIMATELJKREDITOR1).EndInit();
            ((ISupportInitialize) this.textPRIMATELJKREDITOR2).EndInit();
            ((ISupportInitialize) this.textPRIMATELJKREDITOR3).EndInit();
            this.dsKREDITORDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.KREDITORController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceKREDITOR, this.KREDITORController.WorkItem, this))
            {
                return false;
            }
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void KREDITORFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.KREDITORDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void Localize()
        {
            this.label1IDKREDITOR.Text = StringResources.KREDITORIDKREDITORDescription;
            this.label1NAZIVKREDITOR.Text = StringResources.KREDITORNAZIVKREDITORDescription;
            this.label1VBDIKREDITOR.Text = StringResources.KREDITORVBDIKREDITORDescription;
            this.label1ZRNKREDITOR.Text = StringResources.KREDITORZRNKREDITORDescription;
            this.label1PRIMATELJKREDITOR1.Text = StringResources.KREDITORPRIMATELJKREDITOR1Description;
            this.label1PRIMATELJKREDITOR2.Text = StringResources.KREDITORPRIMATELJKREDITOR2Description;
            this.label1PRIMATELJKREDITOR3.Text = StringResources.KREDITORPRIMATELJKREDITOR3Description;
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
            if (!this.KREDITORController.WorkItem.Items.Contains("KREDITOR|KREDITOR"))
            {
                this.KREDITORController.WorkItem.Items.Add(this.bindingSourceKREDITOR, "KREDITOR|KREDITOR");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsKREDITORDataSet1.KREDITOR.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.KREDITORController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.KREDITORController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.KREDITORController.Update(this))
            {
                this.KREDITORController.DataSet = new KREDITORDataSet();
                DataSetUtil.AddEmptyRow(this.KREDITORController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.KREDITORController.DataSet.KREDITOR[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDKREDITOR.Focus();
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.KREDITORController KREDITORController { get; set; }

        protected virtual UltraLabel label1IDKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1NAZIVKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJKREDITOR1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJKREDITOR1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJKREDITOR1 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJKREDITOR2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJKREDITOR2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJKREDITOR2 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJKREDITOR3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJKREDITOR3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJKREDITOR3 = value;
            }
        }

        protected virtual UltraLabel label1VBDIKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VBDIKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VBDIKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1ZRNKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZRNKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZRNKREDITOR = value;
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

        protected virtual UltraNumericEditor textIDKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJKREDITOR1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJKREDITOR1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJKREDITOR1 = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJKREDITOR2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJKREDITOR2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJKREDITOR2 = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJKREDITOR3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJKREDITOR3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJKREDITOR3 = value;
            }
        }

        protected virtual UltraTextEditor textVBDIKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVBDIKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVBDIKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textZRNKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZRNKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZRNKREDITOR = value;
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

