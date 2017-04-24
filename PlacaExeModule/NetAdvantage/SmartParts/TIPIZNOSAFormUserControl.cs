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
    public class TIPIZNOSAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDTIPAIZNOSA")]
        private UltraLabel _label1IDTIPAIZNOSA;
        [AccessedThroughProperty("label1MOTIPAIZNOSA")]
        private UltraLabel _label1MOTIPAIZNOSA;
        [AccessedThroughProperty("label1OPISTIPAIZNOSA")]
        private UltraLabel _label1OPISTIPAIZNOSA;
        [AccessedThroughProperty("label1OZNAKATIPAIZNOSA")]
        private UltraLabel _label1OZNAKATIPAIZNOSA;
        [AccessedThroughProperty("label1POTIPAIZNOSA")]
        private UltraLabel _label1POTIPAIZNOSA;
        [AccessedThroughProperty("label1VBDITIPAIZNOSA")]
        private UltraLabel _label1VBDITIPAIZNOSA;
        [AccessedThroughProperty("label1ZIROTIPAIZNOSA")]
        private UltraLabel _label1ZIROTIPAIZNOSA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDTIPAIZNOSA")]
        private UltraNumericEditor _textIDTIPAIZNOSA;
        [AccessedThroughProperty("textMOTIPAIZNOSA")]
        private UltraTextEditor _textMOTIPAIZNOSA;
        [AccessedThroughProperty("textOPISTIPAIZNOSA")]
        private UltraTextEditor _textOPISTIPAIZNOSA;
        [AccessedThroughProperty("textOZNAKATIPAIZNOSA")]
        private UltraTextEditor _textOZNAKATIPAIZNOSA;
        [AccessedThroughProperty("textPOTIPAIZNOSA")]
        private UltraTextEditor _textPOTIPAIZNOSA;
        [AccessedThroughProperty("textVBDITIPAIZNOSA")]
        private UltraTextEditor _textVBDITIPAIZNOSA;
        [AccessedThroughProperty("textZIROTIPAIZNOSA")]
        private UltraTextEditor _textZIROTIPAIZNOSA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceTIPIZNOSA;
        private IContainer components = null;
        private TIPIZNOSADataSet dsTIPIZNOSADataSet1;
        protected TableLayoutPanel layoutManagerformTIPIZNOSA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private TIPIZNOSADataSet.TIPIZNOSARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "TIPIZNOSA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.TIPIZNOSADescription;
        private DeklaritMode m_Mode;

        public TIPIZNOSAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceTIPIZNOSA.DataSource = this.TIPIZNOSAController.DataSet;
            this.dsTIPIZNOSADataSet1 = this.TIPIZNOSAController.DataSet;
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
                    enumerator = this.dsTIPIZNOSADataSet1.TIPIZNOSA.Rows.GetEnumerator();
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
                if (this.TIPIZNOSAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "TIPIZNOSA", this.m_Mode, this.dsTIPIZNOSADataSet1, this.dsTIPIZNOSADataSet1.TIPIZNOSA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsTIPIZNOSADataSet1.TIPIZNOSA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (TIPIZNOSADataSet.TIPIZNOSARow) ((DataRowView) this.bindingSourceTIPIZNOSA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(TIPIZNOSAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceTIPIZNOSA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceTIPIZNOSA).BeginInit();
            this.layoutManagerformTIPIZNOSA = new TableLayoutPanel();
            this.layoutManagerformTIPIZNOSA.SuspendLayout();
            this.layoutManagerformTIPIZNOSA.AutoSize = true;
            this.layoutManagerformTIPIZNOSA.Dock = DockStyle.Fill;
            this.layoutManagerformTIPIZNOSA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformTIPIZNOSA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformTIPIZNOSA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformTIPIZNOSA.Size = size;
            this.layoutManagerformTIPIZNOSA.ColumnCount = 2;
            this.layoutManagerformTIPIZNOSA.RowCount = 8;
            this.layoutManagerformTIPIZNOSA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformTIPIZNOSA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformTIPIZNOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformTIPIZNOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformTIPIZNOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformTIPIZNOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformTIPIZNOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformTIPIZNOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformTIPIZNOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformTIPIZNOSA.RowStyles.Add(new RowStyle());
            this.label1IDTIPAIZNOSA = new UltraLabel();
            this.textIDTIPAIZNOSA = new UltraNumericEditor();
            this.label1OPISTIPAIZNOSA = new UltraLabel();
            this.textOPISTIPAIZNOSA = new UltraTextEditor();
            this.label1OZNAKATIPAIZNOSA = new UltraLabel();
            this.textOZNAKATIPAIZNOSA = new UltraTextEditor();
            this.label1VBDITIPAIZNOSA = new UltraLabel();
            this.textVBDITIPAIZNOSA = new UltraTextEditor();
            this.label1ZIROTIPAIZNOSA = new UltraLabel();
            this.textZIROTIPAIZNOSA = new UltraTextEditor();
            this.label1MOTIPAIZNOSA = new UltraLabel();
            this.textMOTIPAIZNOSA = new UltraTextEditor();
            this.label1POTIPAIZNOSA = new UltraLabel();
            this.textPOTIPAIZNOSA = new UltraTextEditor();
            ((ISupportInitialize) this.textIDTIPAIZNOSA).BeginInit();
            ((ISupportInitialize) this.textOPISTIPAIZNOSA).BeginInit();
            ((ISupportInitialize) this.textOZNAKATIPAIZNOSA).BeginInit();
            ((ISupportInitialize) this.textVBDITIPAIZNOSA).BeginInit();
            ((ISupportInitialize) this.textZIROTIPAIZNOSA).BeginInit();
            ((ISupportInitialize) this.textMOTIPAIZNOSA).BeginInit();
            ((ISupportInitialize) this.textPOTIPAIZNOSA).BeginInit();
            this.dsTIPIZNOSADataSet1 = new TIPIZNOSADataSet();
            this.dsTIPIZNOSADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsTIPIZNOSADataSet1.DataSetName = "dsTIPIZNOSA";
            this.dsTIPIZNOSADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceTIPIZNOSA.DataSource = this.dsTIPIZNOSADataSet1;
            this.bindingSourceTIPIZNOSA.DataMember = "TIPIZNOSA";
            ((ISupportInitialize) this.bindingSourceTIPIZNOSA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDTIPAIZNOSA.Location = point;
            this.label1IDTIPAIZNOSA.Name = "label1IDTIPAIZNOSA";
            this.label1IDTIPAIZNOSA.TabIndex = 1;
            this.label1IDTIPAIZNOSA.Tag = "labelIDTIPAIZNOSA";
            this.label1IDTIPAIZNOSA.Text = "Šifra:";
            this.label1IDTIPAIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1IDTIPAIZNOSA.AutoSize = true;
            this.label1IDTIPAIZNOSA.Anchor = AnchorStyles.Left;
            this.label1IDTIPAIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDTIPAIZNOSA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDTIPAIZNOSA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDTIPAIZNOSA.ImageSize = size;
            this.label1IDTIPAIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1IDTIPAIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformTIPIZNOSA.Controls.Add(this.label1IDTIPAIZNOSA, 0, 0);
            this.layoutManagerformTIPIZNOSA.SetColumnSpan(this.label1IDTIPAIZNOSA, 1);
            this.layoutManagerformTIPIZNOSA.SetRowSpan(this.label1IDTIPAIZNOSA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDTIPAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDTIPAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDTIPAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDTIPAIZNOSA.Location = point;
            this.textIDTIPAIZNOSA.Name = "textIDTIPAIZNOSA";
            this.textIDTIPAIZNOSA.Tag = "IDTIPAIZNOSA";
            this.textIDTIPAIZNOSA.TabIndex = 0;
            this.textIDTIPAIZNOSA.Anchor = AnchorStyles.Left;
            this.textIDTIPAIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDTIPAIZNOSA.ReadOnly = false;
            this.textIDTIPAIZNOSA.PromptChar = ' ';
            this.textIDTIPAIZNOSA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDTIPAIZNOSA.DataBindings.Add(new Binding("Value", this.bindingSourceTIPIZNOSA, "IDTIPAIZNOSA"));
            this.textIDTIPAIZNOSA.NumericType = NumericType.Integer;
            this.textIDTIPAIZNOSA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformTIPIZNOSA.Controls.Add(this.textIDTIPAIZNOSA, 1, 0);
            this.layoutManagerformTIPIZNOSA.SetColumnSpan(this.textIDTIPAIZNOSA, 1);
            this.layoutManagerformTIPIZNOSA.SetRowSpan(this.textIDTIPAIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDTIPAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDTIPAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDTIPAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISTIPAIZNOSA.Location = point;
            this.label1OPISTIPAIZNOSA.Name = "label1OPISTIPAIZNOSA";
            this.label1OPISTIPAIZNOSA.TabIndex = 1;
            this.label1OPISTIPAIZNOSA.Tag = "labelOPISTIPAIZNOSA";
            this.label1OPISTIPAIZNOSA.Text = "Opis:";
            this.label1OPISTIPAIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1OPISTIPAIZNOSA.AutoSize = true;
            this.label1OPISTIPAIZNOSA.Anchor = AnchorStyles.Left;
            this.label1OPISTIPAIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISTIPAIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1OPISTIPAIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformTIPIZNOSA.Controls.Add(this.label1OPISTIPAIZNOSA, 0, 1);
            this.layoutManagerformTIPIZNOSA.SetColumnSpan(this.label1OPISTIPAIZNOSA, 1);
            this.layoutManagerformTIPIZNOSA.SetRowSpan(this.label1OPISTIPAIZNOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISTIPAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISTIPAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x2e, 0x17);
            this.label1OPISTIPAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPISTIPAIZNOSA.Location = point;
            this.textOPISTIPAIZNOSA.Name = "textOPISTIPAIZNOSA";
            this.textOPISTIPAIZNOSA.Tag = "OPISTIPAIZNOSA";
            this.textOPISTIPAIZNOSA.TabIndex = 0;
            this.textOPISTIPAIZNOSA.Anchor = AnchorStyles.Left;
            this.textOPISTIPAIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPISTIPAIZNOSA.ReadOnly = false;
            this.textOPISTIPAIZNOSA.DataBindings.Add(new Binding("Text", this.bindingSourceTIPIZNOSA, "OPISTIPAIZNOSA"));
            this.textOPISTIPAIZNOSA.MaxLength = 100;
            this.layoutManagerformTIPIZNOSA.Controls.Add(this.textOPISTIPAIZNOSA, 1, 1);
            this.layoutManagerformTIPIZNOSA.SetColumnSpan(this.textOPISTIPAIZNOSA, 1);
            this.layoutManagerformTIPIZNOSA.SetRowSpan(this.textOPISTIPAIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPISTIPAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textOPISTIPAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textOPISTIPAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OZNAKATIPAIZNOSA.Location = point;
            this.label1OZNAKATIPAIZNOSA.Name = "label1OZNAKATIPAIZNOSA";
            this.label1OZNAKATIPAIZNOSA.TabIndex = 1;
            this.label1OZNAKATIPAIZNOSA.Tag = "labelOZNAKATIPAIZNOSA";
            this.label1OZNAKATIPAIZNOSA.Text = "Oznaka:";
            this.label1OZNAKATIPAIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1OZNAKATIPAIZNOSA.AutoSize = true;
            this.label1OZNAKATIPAIZNOSA.Anchor = AnchorStyles.Left;
            this.label1OZNAKATIPAIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OZNAKATIPAIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1OZNAKATIPAIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformTIPIZNOSA.Controls.Add(this.label1OZNAKATIPAIZNOSA, 0, 2);
            this.layoutManagerformTIPIZNOSA.SetColumnSpan(this.label1OZNAKATIPAIZNOSA, 1);
            this.layoutManagerformTIPIZNOSA.SetRowSpan(this.label1OZNAKATIPAIZNOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OZNAKATIPAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OZNAKATIPAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x17);
            this.label1OZNAKATIPAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOZNAKATIPAIZNOSA.Location = point;
            this.textOZNAKATIPAIZNOSA.Name = "textOZNAKATIPAIZNOSA";
            this.textOZNAKATIPAIZNOSA.Tag = "OZNAKATIPAIZNOSA";
            this.textOZNAKATIPAIZNOSA.TabIndex = 0;
            this.textOZNAKATIPAIZNOSA.Anchor = AnchorStyles.Left;
            this.textOZNAKATIPAIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOZNAKATIPAIZNOSA.ReadOnly = false;
            this.textOZNAKATIPAIZNOSA.DataBindings.Add(new Binding("Text", this.bindingSourceTIPIZNOSA, "OZNAKATIPAIZNOSA"));
            this.textOZNAKATIPAIZNOSA.MaxLength = 10;
            this.layoutManagerformTIPIZNOSA.Controls.Add(this.textOZNAKATIPAIZNOSA, 1, 2);
            this.layoutManagerformTIPIZNOSA.SetColumnSpan(this.textOZNAKATIPAIZNOSA, 1);
            this.layoutManagerformTIPIZNOSA.SetRowSpan(this.textOZNAKATIPAIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOZNAKATIPAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textOZNAKATIPAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textOZNAKATIPAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VBDITIPAIZNOSA.Location = point;
            this.label1VBDITIPAIZNOSA.Name = "label1VBDITIPAIZNOSA";
            this.label1VBDITIPAIZNOSA.TabIndex = 1;
            this.label1VBDITIPAIZNOSA.Tag = "labelVBDITIPAIZNOSA";
            this.label1VBDITIPAIZNOSA.Text = "VBDI:";
            this.label1VBDITIPAIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1VBDITIPAIZNOSA.AutoSize = true;
            this.label1VBDITIPAIZNOSA.Anchor = AnchorStyles.Left;
            this.label1VBDITIPAIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1VBDITIPAIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1VBDITIPAIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformTIPIZNOSA.Controls.Add(this.label1VBDITIPAIZNOSA, 0, 3);
            this.layoutManagerformTIPIZNOSA.SetColumnSpan(this.label1VBDITIPAIZNOSA, 1);
            this.layoutManagerformTIPIZNOSA.SetRowSpan(this.label1VBDITIPAIZNOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VBDITIPAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VBDITIPAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x17);
            this.label1VBDITIPAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVBDITIPAIZNOSA.Location = point;
            this.textVBDITIPAIZNOSA.Name = "textVBDITIPAIZNOSA";
            this.textVBDITIPAIZNOSA.Tag = "VBDITIPAIZNOSA";
            this.textVBDITIPAIZNOSA.TabIndex = 0;
            this.textVBDITIPAIZNOSA.Anchor = AnchorStyles.Left;
            this.textVBDITIPAIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVBDITIPAIZNOSA.ReadOnly = false;
            this.textVBDITIPAIZNOSA.DataBindings.Add(new Binding("Text", this.bindingSourceTIPIZNOSA, "VBDITIPAIZNOSA"));
            this.textVBDITIPAIZNOSA.MaxLength = 7;
            this.layoutManagerformTIPIZNOSA.Controls.Add(this.textVBDITIPAIZNOSA, 1, 3);
            this.layoutManagerformTIPIZNOSA.SetColumnSpan(this.textVBDITIPAIZNOSA, 1);
            this.layoutManagerformTIPIZNOSA.SetRowSpan(this.textVBDITIPAIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVBDITIPAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDITIPAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDITIPAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZIROTIPAIZNOSA.Location = point;
            this.label1ZIROTIPAIZNOSA.Name = "label1ZIROTIPAIZNOSA";
            this.label1ZIROTIPAIZNOSA.TabIndex = 1;
            this.label1ZIROTIPAIZNOSA.Tag = "labelZIROTIPAIZNOSA";
            this.label1ZIROTIPAIZNOSA.Text = "Broj žiro računa:";
            this.label1ZIROTIPAIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1ZIROTIPAIZNOSA.AutoSize = true;
            this.label1ZIROTIPAIZNOSA.Anchor = AnchorStyles.Left;
            this.label1ZIROTIPAIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZIROTIPAIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1ZIROTIPAIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformTIPIZNOSA.Controls.Add(this.label1ZIROTIPAIZNOSA, 0, 4);
            this.layoutManagerformTIPIZNOSA.SetColumnSpan(this.label1ZIROTIPAIZNOSA, 1);
            this.layoutManagerformTIPIZNOSA.SetRowSpan(this.label1ZIROTIPAIZNOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZIROTIPAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZIROTIPAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x76, 0x17);
            this.label1ZIROTIPAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZIROTIPAIZNOSA.Location = point;
            this.textZIROTIPAIZNOSA.Name = "textZIROTIPAIZNOSA";
            this.textZIROTIPAIZNOSA.Tag = "ZIROTIPAIZNOSA";
            this.textZIROTIPAIZNOSA.TabIndex = 0;
            this.textZIROTIPAIZNOSA.Anchor = AnchorStyles.Left;
            this.textZIROTIPAIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZIROTIPAIZNOSA.ReadOnly = false;
            this.textZIROTIPAIZNOSA.DataBindings.Add(new Binding("Text", this.bindingSourceTIPIZNOSA, "ZIROTIPAIZNOSA"));
            this.textZIROTIPAIZNOSA.MaxLength = 10;
            this.layoutManagerformTIPIZNOSA.Controls.Add(this.textZIROTIPAIZNOSA, 1, 4);
            this.layoutManagerformTIPIZNOSA.SetColumnSpan(this.textZIROTIPAIZNOSA, 1);
            this.layoutManagerformTIPIZNOSA.SetRowSpan(this.textZIROTIPAIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZIROTIPAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZIROTIPAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZIROTIPAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MOTIPAIZNOSA.Location = point;
            this.label1MOTIPAIZNOSA.Name = "label1MOTIPAIZNOSA";
            this.label1MOTIPAIZNOSA.TabIndex = 1;
            this.label1MOTIPAIZNOSA.Tag = "labelMOTIPAIZNOSA";
            this.label1MOTIPAIZNOSA.Text = "Model odobrenja:";
            this.label1MOTIPAIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1MOTIPAIZNOSA.AutoSize = true;
            this.label1MOTIPAIZNOSA.Anchor = AnchorStyles.Left;
            this.label1MOTIPAIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MOTIPAIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1MOTIPAIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformTIPIZNOSA.Controls.Add(this.label1MOTIPAIZNOSA, 0, 5);
            this.layoutManagerformTIPIZNOSA.SetColumnSpan(this.label1MOTIPAIZNOSA, 1);
            this.layoutManagerformTIPIZNOSA.SetRowSpan(this.label1MOTIPAIZNOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MOTIPAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MOTIPAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1MOTIPAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMOTIPAIZNOSA.Location = point;
            this.textMOTIPAIZNOSA.Name = "textMOTIPAIZNOSA";
            this.textMOTIPAIZNOSA.Tag = "MOTIPAIZNOSA";
            this.textMOTIPAIZNOSA.TabIndex = 0;
            this.textMOTIPAIZNOSA.Anchor = AnchorStyles.Left;
            this.textMOTIPAIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMOTIPAIZNOSA.ReadOnly = false;
            this.textMOTIPAIZNOSA.DataBindings.Add(new Binding("Text", this.bindingSourceTIPIZNOSA, "MOTIPAIZNOSA"));
            this.textMOTIPAIZNOSA.MaxLength = 2;
            this.layoutManagerformTIPIZNOSA.Controls.Add(this.textMOTIPAIZNOSA, 1, 5);
            this.layoutManagerformTIPIZNOSA.SetColumnSpan(this.textMOTIPAIZNOSA, 1);
            this.layoutManagerformTIPIZNOSA.SetRowSpan(this.textMOTIPAIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMOTIPAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMOTIPAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMOTIPAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POTIPAIZNOSA.Location = point;
            this.label1POTIPAIZNOSA.Name = "label1POTIPAIZNOSA";
            this.label1POTIPAIZNOSA.TabIndex = 1;
            this.label1POTIPAIZNOSA.Tag = "labelPOTIPAIZNOSA";
            this.label1POTIPAIZNOSA.Text = "Poziv na broj odobrenja:";
            this.label1POTIPAIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1POTIPAIZNOSA.AutoSize = true;
            this.label1POTIPAIZNOSA.Anchor = AnchorStyles.Left;
            this.label1POTIPAIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1POTIPAIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1POTIPAIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformTIPIZNOSA.Controls.Add(this.label1POTIPAIZNOSA, 0, 6);
            this.layoutManagerformTIPIZNOSA.SetColumnSpan(this.label1POTIPAIZNOSA, 1);
            this.layoutManagerformTIPIZNOSA.SetRowSpan(this.label1POTIPAIZNOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POTIPAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POTIPAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0xa7, 0x17);
            this.label1POTIPAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOTIPAIZNOSA.Location = point;
            this.textPOTIPAIZNOSA.Name = "textPOTIPAIZNOSA";
            this.textPOTIPAIZNOSA.Tag = "POTIPAIZNOSA";
            this.textPOTIPAIZNOSA.TabIndex = 0;
            this.textPOTIPAIZNOSA.Anchor = AnchorStyles.Left;
            this.textPOTIPAIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOTIPAIZNOSA.ReadOnly = false;
            this.textPOTIPAIZNOSA.DataBindings.Add(new Binding("Text", this.bindingSourceTIPIZNOSA, "POTIPAIZNOSA"));
            this.textPOTIPAIZNOSA.MaxLength = 0x16;
            this.layoutManagerformTIPIZNOSA.Controls.Add(this.textPOTIPAIZNOSA, 1, 6);
            this.layoutManagerformTIPIZNOSA.SetColumnSpan(this.textPOTIPAIZNOSA, 1);
            this.layoutManagerformTIPIZNOSA.SetRowSpan(this.textPOTIPAIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOTIPAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOTIPAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOTIPAIZNOSA.Size = size;
            this.Controls.Add(this.layoutManagerformTIPIZNOSA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceTIPIZNOSA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "TIPIZNOSAFormUserControl";
            this.Text = "Pregled uplatnih raeuna doprinosa";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.TIPIZNOSAFormUserControl_Load);
            this.layoutManagerformTIPIZNOSA.ResumeLayout(false);
            this.layoutManagerformTIPIZNOSA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceTIPIZNOSA).EndInit();
            ((ISupportInitialize) this.textIDTIPAIZNOSA).EndInit();
            ((ISupportInitialize) this.textOPISTIPAIZNOSA).EndInit();
            ((ISupportInitialize) this.textOZNAKATIPAIZNOSA).EndInit();
            ((ISupportInitialize) this.textVBDITIPAIZNOSA).EndInit();
            ((ISupportInitialize) this.textZIROTIPAIZNOSA).EndInit();
            ((ISupportInitialize) this.textMOTIPAIZNOSA).EndInit();
            ((ISupportInitialize) this.textPOTIPAIZNOSA).EndInit();
            this.dsTIPIZNOSADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.TIPIZNOSAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceTIPIZNOSA, this.TIPIZNOSAController.WorkItem, this))
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
            this.label1IDTIPAIZNOSA.Text = StringResources.TIPIZNOSAIDTIPAIZNOSADescription;
            this.label1OPISTIPAIZNOSA.Text = StringResources.TIPIZNOSAOPISTIPAIZNOSADescription;
            this.label1OZNAKATIPAIZNOSA.Text = StringResources.TIPIZNOSAOZNAKATIPAIZNOSADescription;
            this.label1VBDITIPAIZNOSA.Text = StringResources.TIPIZNOSAVBDITIPAIZNOSADescription;
            this.label1ZIROTIPAIZNOSA.Text = StringResources.TIPIZNOSAZIROTIPAIZNOSADescription;
            this.label1MOTIPAIZNOSA.Text = StringResources.TIPIZNOSAMOTIPAIZNOSADescription;
            this.label1POTIPAIZNOSA.Text = StringResources.TIPIZNOSAPOTIPAIZNOSADescription;
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
            if (!this.TIPIZNOSAController.WorkItem.Items.Contains("TIPIZNOSA|TIPIZNOSA"))
            {
                this.TIPIZNOSAController.WorkItem.Items.Add(this.bindingSourceTIPIZNOSA, "TIPIZNOSA|TIPIZNOSA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsTIPIZNOSADataSet1.TIPIZNOSA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.TIPIZNOSAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.TIPIZNOSAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.TIPIZNOSAController.Update(this))
            {
                this.TIPIZNOSAController.DataSet = new TIPIZNOSADataSet();
                DataSetUtil.AddEmptyRow(this.TIPIZNOSAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.TIPIZNOSAController.DataSet.TIPIZNOSA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDTIPAIZNOSA.Focus();
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

        private void TIPIZNOSAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.TIPIZNOSADescription;
            this.errorProvider1.ContainerControl = this;
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

        protected virtual UltraLabel label1IDTIPAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDTIPAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDTIPAIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1MOTIPAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MOTIPAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MOTIPAIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1OPISTIPAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISTIPAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISTIPAIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1OZNAKATIPAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OZNAKATIPAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OZNAKATIPAIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1POTIPAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POTIPAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POTIPAIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1VBDITIPAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VBDITIPAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VBDITIPAIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1ZIROTIPAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZIROTIPAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZIROTIPAIZNOSA = value;
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

        protected virtual UltraNumericEditor textIDTIPAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDTIPAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDTIPAIZNOSA = value;
            }
        }

        protected virtual UltraTextEditor textMOTIPAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMOTIPAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMOTIPAIZNOSA = value;
            }
        }

        protected virtual UltraTextEditor textOPISTIPAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPISTIPAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPISTIPAIZNOSA = value;
            }
        }

        protected virtual UltraTextEditor textOZNAKATIPAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOZNAKATIPAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOZNAKATIPAIZNOSA = value;
            }
        }

        protected virtual UltraTextEditor textPOTIPAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOTIPAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOTIPAIZNOSA = value;
            }
        }

        protected virtual UltraTextEditor textVBDITIPAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVBDITIPAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVBDITIPAIZNOSA = value;
            }
        }

        protected virtual UltraTextEditor textZIROTIPAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZIROTIPAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZIROTIPAIZNOSA = value;
            }
        }

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.TIPIZNOSAController TIPIZNOSAController { get; set; }

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

