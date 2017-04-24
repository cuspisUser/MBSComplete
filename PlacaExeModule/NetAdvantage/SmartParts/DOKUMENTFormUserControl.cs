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
    public class DOKUMENTFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkPS")]
        private UltraCheckEditor _checkPS;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDDOKUMENT")]
        private UltraLabel _label1IDDOKUMENT;
        [AccessedThroughProperty("label1IDTIPDOKUMENTA")]
        private UltraLabel _label1IDTIPDOKUMENTA;
        [AccessedThroughProperty("label1NAZIVDOKUMENT")]
        private UltraLabel _label1NAZIVDOKUMENT;
        [AccessedThroughProperty("label1NAZIVTIPDOKUMENTA")]
        private UltraLabel _label1NAZIVTIPDOKUMENTA;
        [AccessedThroughProperty("label1PS")]
        private UltraLabel _label1PS;
        [AccessedThroughProperty("labelNAZIVTIPDOKUMENTA")]
        private UltraLabel _labelNAZIVTIPDOKUMENTA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDDOKUMENT")]
        private UltraNumericEditor _textIDDOKUMENT;
        [AccessedThroughProperty("textIDTIPDOKUMENTA")]
        private UltraNumericEditor _textIDTIPDOKUMENTA;
        [AccessedThroughProperty("textNAZIVDOKUMENT")]
        private UltraTextEditor _textNAZIVDOKUMENT;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceDOKUMENT;
        private IContainer components = null;
        private DOKUMENTDataSet dsDOKUMENTDataSet1;
        protected TableLayoutPanel layoutManagerformDOKUMENT;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private DOKUMENTDataSet.DOKUMENTRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "DOKUMENT";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.DOKUMENTDescription;
        private DeklaritMode m_Mode;

        public DOKUMENTFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptTIPDOKUMENTAIDTIPDOKUMENTA(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.DOKUMENTController.SelectTIPDOKUMENTAIDTIPDOKUMENTA(fillMethod, fillByRow);
            this.UpdateValuesTIPDOKUMENTAIDTIPDOKUMENTA(result);
        }

        private void CallViewTIPDOKUMENTAIDTIPDOKUMENTA(object sender, EventArgs e)
        {
            DataRow result = this.DOKUMENTController.ShowTIPDOKUMENTAIDTIPDOKUMENTA(this.m_CurrentRow);
            this.UpdateValuesTIPDOKUMENTAIDTIPDOKUMENTA(result);
        }

        public void ChangeBinding()
        {
            this.bindingSourceDOKUMENT.DataSource = this.DOKUMENTController.DataSet;
            this.dsDOKUMENTDataSet1 = this.DOKUMENTController.DataSet;
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
                    enumerator = this.dsDOKUMENTDataSet1.DOKUMENT.Rows.GetEnumerator();
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
                if (this.DOKUMENTController.Update(this))
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

        private void DOKUMENTFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.DOKUMENTDescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "DOKUMENT", this.m_Mode, this.dsDOKUMENTDataSet1, this.dsDOKUMENTDataSet1.DOKUMENT.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("CheckState", this.bindingSourceDOKUMENT, "PS", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkPS.DataBindings["CheckState"] != null)
            {
                this.checkPS.DataBindings.Remove(this.checkPS.DataBindings["CheckState"]);
            }
            this.checkPS.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsDOKUMENTDataSet1.DOKUMENT[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (DOKUMENTDataSet.DOKUMENTRow) ((DataRowView) this.bindingSourceDOKUMENT.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(DOKUMENTFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceDOKUMENT = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDOKUMENT).BeginInit();
            this.layoutManagerformDOKUMENT = new TableLayoutPanel();
            this.layoutManagerformDOKUMENT.SuspendLayout();
            this.layoutManagerformDOKUMENT.AutoSize = true;
            this.layoutManagerformDOKUMENT.Dock = DockStyle.Fill;
            this.layoutManagerformDOKUMENT.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformDOKUMENT.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformDOKUMENT.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformDOKUMENT.Size = size;
            this.layoutManagerformDOKUMENT.ColumnCount = 2;
            this.layoutManagerformDOKUMENT.RowCount = 6;
            this.layoutManagerformDOKUMENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDOKUMENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDOKUMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOKUMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOKUMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOKUMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOKUMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformDOKUMENT.RowStyles.Add(new RowStyle());
            this.label1IDDOKUMENT = new UltraLabel();
            this.textIDDOKUMENT = new UltraNumericEditor();
            this.label1NAZIVDOKUMENT = new UltraLabel();
            this.textNAZIVDOKUMENT = new UltraTextEditor();
            this.label1IDTIPDOKUMENTA = new UltraLabel();
            this.textIDTIPDOKUMENTA = new UltraNumericEditor();
            this.label1NAZIVTIPDOKUMENTA = new UltraLabel();
            this.labelNAZIVTIPDOKUMENTA = new UltraLabel();
            this.label1PS = new UltraLabel();
            this.checkPS = new UltraCheckEditor();
            ((ISupportInitialize) this.textIDDOKUMENT).BeginInit();
            ((ISupportInitialize) this.textNAZIVDOKUMENT).BeginInit();
            ((ISupportInitialize) this.textIDTIPDOKUMENTA).BeginInit();
            this.dsDOKUMENTDataSet1 = new DOKUMENTDataSet();
            this.dsDOKUMENTDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsDOKUMENTDataSet1.DataSetName = "dsDOKUMENT";
            this.dsDOKUMENTDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceDOKUMENT.DataSource = this.dsDOKUMENTDataSet1;
            this.bindingSourceDOKUMENT.DataMember = "DOKUMENT";
            ((ISupportInitialize) this.bindingSourceDOKUMENT).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDDOKUMENT.Location = point;
            this.label1IDDOKUMENT.Name = "label1IDDOKUMENT";
            this.label1IDDOKUMENT.TabIndex = 1;
            this.label1IDDOKUMENT.Tag = "labelIDDOKUMENT";
            this.label1IDDOKUMENT.Text = "Dokument:";
            this.label1IDDOKUMENT.StyleSetName = "FieldUltraLabel";
            this.label1IDDOKUMENT.AutoSize = true;
            this.label1IDDOKUMENT.Anchor = AnchorStyles.Left;
            this.label1IDDOKUMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDDOKUMENT.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDDOKUMENT.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDDOKUMENT.ImageSize = size;
            this.label1IDDOKUMENT.Appearance.ForeColor = Color.Black;
            this.label1IDDOKUMENT.BackColor = Color.Transparent;
            this.layoutManagerformDOKUMENT.Controls.Add(this.label1IDDOKUMENT, 0, 0);
            this.layoutManagerformDOKUMENT.SetColumnSpan(this.label1IDDOKUMENT, 1);
            this.layoutManagerformDOKUMENT.SetRowSpan(this.label1IDDOKUMENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x51, 0x17);
            this.label1IDDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDDOKUMENT.Location = point;
            this.textIDDOKUMENT.Name = "textIDDOKUMENT";
            this.textIDDOKUMENT.Tag = "IDDOKUMENT";
            this.textIDDOKUMENT.TabIndex = 0;
            this.textIDDOKUMENT.Anchor = AnchorStyles.Left;
            this.textIDDOKUMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDDOKUMENT.ReadOnly = false;
            this.textIDDOKUMENT.PromptChar = ' ';
            this.textIDDOKUMENT.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDDOKUMENT.DataBindings.Add(new Binding("Value", this.bindingSourceDOKUMENT, "IDDOKUMENT"));
            this.textIDDOKUMENT.NumericType = NumericType.Integer;
            this.textIDDOKUMENT.MaskInput = "{LOC}-nnnnnnnn";
            this.layoutManagerformDOKUMENT.Controls.Add(this.textIDDOKUMENT, 1, 0);
            this.layoutManagerformDOKUMENT.SetColumnSpan(this.textIDDOKUMENT, 1);
            this.layoutManagerformDOKUMENT.SetRowSpan(this.textIDDOKUMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVDOKUMENT.Location = point;
            this.label1NAZIVDOKUMENT.Name = "label1NAZIVDOKUMENT";
            this.label1NAZIVDOKUMENT.TabIndex = 1;
            this.label1NAZIVDOKUMENT.Tag = "labelNAZIVDOKUMENT";
            this.label1NAZIVDOKUMENT.Text = "Naziv dokumenta:";
            this.label1NAZIVDOKUMENT.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVDOKUMENT.AutoSize = true;
            this.label1NAZIVDOKUMENT.Anchor = AnchorStyles.Left;
            this.label1NAZIVDOKUMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVDOKUMENT.Appearance.ForeColor = Color.Black;
            this.label1NAZIVDOKUMENT.BackColor = Color.Transparent;
            this.layoutManagerformDOKUMENT.Controls.Add(this.label1NAZIVDOKUMENT, 0, 1);
            this.layoutManagerformDOKUMENT.SetColumnSpan(this.label1NAZIVDOKUMENT, 1);
            this.layoutManagerformDOKUMENT.SetRowSpan(this.label1NAZIVDOKUMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x7f, 0x17);
            this.label1NAZIVDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVDOKUMENT.Location = point;
            this.textNAZIVDOKUMENT.Name = "textNAZIVDOKUMENT";
            this.textNAZIVDOKUMENT.Tag = "NAZIVDOKUMENT";
            this.textNAZIVDOKUMENT.TabIndex = 0;
            this.textNAZIVDOKUMENT.Anchor = AnchorStyles.Left;
            this.textNAZIVDOKUMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVDOKUMENT.ReadOnly = false;
            this.textNAZIVDOKUMENT.DataBindings.Add(new Binding("Text", this.bindingSourceDOKUMENT, "NAZIVDOKUMENT"));
            this.textNAZIVDOKUMENT.MaxLength = 50;
            this.layoutManagerformDOKUMENT.Controls.Add(this.textNAZIVDOKUMENT, 1, 1);
            this.layoutManagerformDOKUMENT.SetColumnSpan(this.textNAZIVDOKUMENT, 1);
            this.layoutManagerformDOKUMENT.SetRowSpan(this.textNAZIVDOKUMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDTIPDOKUMENTA.Location = point;
            this.label1IDTIPDOKUMENTA.Name = "label1IDTIPDOKUMENTA";
            this.label1IDTIPDOKUMENTA.TabIndex = 1;
            this.label1IDTIPDOKUMENTA.Tag = "labelIDTIPDOKUMENTA";
            this.label1IDTIPDOKUMENTA.Text = "IDTIPDOKUMENTA:";
            this.label1IDTIPDOKUMENTA.StyleSetName = "FieldUltraLabel";
            this.label1IDTIPDOKUMENTA.AutoSize = true;
            this.label1IDTIPDOKUMENTA.Anchor = AnchorStyles.Left;
            this.label1IDTIPDOKUMENTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDTIPDOKUMENTA.Appearance.ForeColor = Color.Black;
            this.label1IDTIPDOKUMENTA.BackColor = Color.Transparent;
            this.layoutManagerformDOKUMENT.Controls.Add(this.label1IDTIPDOKUMENTA, 0, 2);
            this.layoutManagerformDOKUMENT.SetColumnSpan(this.label1IDTIPDOKUMENTA, 1);
            this.layoutManagerformDOKUMENT.SetRowSpan(this.label1IDTIPDOKUMENTA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDTIPDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDTIPDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x89, 0x17);
            this.label1IDTIPDOKUMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDTIPDOKUMENTA.Location = point;
            this.textIDTIPDOKUMENTA.Name = "textIDTIPDOKUMENTA";
            this.textIDTIPDOKUMENTA.Tag = "IDTIPDOKUMENTA";
            this.textIDTIPDOKUMENTA.TabIndex = 0;
            this.textIDTIPDOKUMENTA.Anchor = AnchorStyles.Left;
            this.textIDTIPDOKUMENTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDTIPDOKUMENTA.ReadOnly = false;
            this.textIDTIPDOKUMENTA.PromptChar = ' ';
            this.textIDTIPDOKUMENTA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDTIPDOKUMENTA.DataBindings.Add(new Binding("Value", this.bindingSourceDOKUMENT, "IDTIPDOKUMENTA"));
            this.textIDTIPDOKUMENTA.NumericType = NumericType.Integer;
            this.textIDTIPDOKUMENTA.MaskInput = "{LOC}-nnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonTIPDOKUMENTAIDTIPDOKUMENTA",
                Tag = "editorButtonTIPDOKUMENTAIDTIPDOKUMENTA",
                Text = "..."
            };
            this.textIDTIPDOKUMENTA.ButtonsRight.Add(button);
            this.textIDTIPDOKUMENTA.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptTIPDOKUMENTAIDTIPDOKUMENTA);
            this.layoutManagerformDOKUMENT.Controls.Add(this.textIDTIPDOKUMENTA, 1, 2);
            this.layoutManagerformDOKUMENT.SetColumnSpan(this.textIDTIPDOKUMENTA, 1);
            this.layoutManagerformDOKUMENT.SetRowSpan(this.textIDTIPDOKUMENTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDTIPDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDTIPDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDTIPDOKUMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVTIPDOKUMENTA.Location = point;
            this.label1NAZIVTIPDOKUMENTA.Name = "label1NAZIVTIPDOKUMENTA";
            this.label1NAZIVTIPDOKUMENTA.TabIndex = 1;
            this.label1NAZIVTIPDOKUMENTA.Tag = "labelNAZIVTIPDOKUMENTA";
            this.label1NAZIVTIPDOKUMENTA.Text = "NAZIVTIPDOKUMENTA:";
            this.label1NAZIVTIPDOKUMENTA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVTIPDOKUMENTA.AutoSize = true;
            this.label1NAZIVTIPDOKUMENTA.Anchor = AnchorStyles.Left;
            this.label1NAZIVTIPDOKUMENTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVTIPDOKUMENTA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVTIPDOKUMENTA.BackColor = Color.Transparent;
            this.layoutManagerformDOKUMENT.Controls.Add(this.label1NAZIVTIPDOKUMENTA, 0, 3);
            this.layoutManagerformDOKUMENT.SetColumnSpan(this.label1NAZIVTIPDOKUMENTA, 1);
            this.layoutManagerformDOKUMENT.SetRowSpan(this.label1NAZIVTIPDOKUMENTA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVTIPDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVTIPDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0xa1, 0x17);
            this.label1NAZIVTIPDOKUMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVTIPDOKUMENTA.Location = point;
            this.labelNAZIVTIPDOKUMENTA.Name = "labelNAZIVTIPDOKUMENTA";
            this.labelNAZIVTIPDOKUMENTA.Tag = "NAZIVTIPDOKUMENTA";
            this.labelNAZIVTIPDOKUMENTA.TabIndex = 0;
            this.labelNAZIVTIPDOKUMENTA.Anchor = AnchorStyles.Left;
            this.labelNAZIVTIPDOKUMENTA.BackColor = Color.Transparent;
            this.labelNAZIVTIPDOKUMENTA.DataBindings.Add(new Binding("Text", this.bindingSourceDOKUMENT, "NAZIVTIPDOKUMENTA"));
            this.labelNAZIVTIPDOKUMENTA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformDOKUMENT.Controls.Add(this.labelNAZIVTIPDOKUMENTA, 1, 3);
            this.layoutManagerformDOKUMENT.SetColumnSpan(this.labelNAZIVTIPDOKUMENTA, 1);
            this.layoutManagerformDOKUMENT.SetRowSpan(this.labelNAZIVTIPDOKUMENTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVTIPDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVTIPDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVTIPDOKUMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PS.Location = point;
            this.label1PS.Name = "label1PS";
            this.label1PS.TabIndex = 1;
            this.label1PS.Tag = "labelPS";
            this.label1PS.Text = "PS:";
            this.label1PS.StyleSetName = "FieldUltraLabel";
            this.label1PS.AutoSize = true;
            this.label1PS.Anchor = AnchorStyles.Left;
            this.label1PS.Appearance.TextVAlign = VAlign.Middle;
            this.label1PS.Appearance.ForeColor = Color.Black;
            this.label1PS.BackColor = Color.Transparent;
            this.layoutManagerformDOKUMENT.Controls.Add(this.label1PS, 0, 4);
            this.layoutManagerformDOKUMENT.SetColumnSpan(this.label1PS, 1);
            this.layoutManagerformDOKUMENT.SetRowSpan(this.label1PS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PS.MinimumSize = size;
            size = new System.Drawing.Size(0x23, 0x17);
            this.label1PS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkPS.Location = point;
            this.checkPS.Name = "checkPS";
            this.checkPS.Tag = "PS";
            this.checkPS.TabIndex = 0;
            this.checkPS.Anchor = AnchorStyles.Left;
            this.checkPS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkPS.Enabled = true;
            this.layoutManagerformDOKUMENT.Controls.Add(this.checkPS, 1, 4);
            this.layoutManagerformDOKUMENT.SetColumnSpan(this.checkPS, 1);
            this.layoutManagerformDOKUMENT.SetRowSpan(this.checkPS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkPS.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkPS.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkPS.Size = size;
            this.Controls.Add(this.layoutManagerformDOKUMENT);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceDOKUMENT;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "DOKUMENTFormUserControl";
            this.Text = "DOKUMENT";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.DOKUMENTFormUserControl_Load);
            this.layoutManagerformDOKUMENT.ResumeLayout(false);
            this.layoutManagerformDOKUMENT.PerformLayout();
            ((ISupportInitialize) this.bindingSourceDOKUMENT).EndInit();
            ((ISupportInitialize) this.textIDDOKUMENT).EndInit();
            ((ISupportInitialize) this.textNAZIVDOKUMENT).EndInit();
            ((ISupportInitialize) this.textIDTIPDOKUMENTA).EndInit();
            this.dsDOKUMENTDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.DOKUMENTController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceDOKUMENT, this.DOKUMENTController.WorkItem, this))
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
            this.label1IDDOKUMENT.Text = StringResources.DOKUMENTIDDOKUMENTDescription;
            this.label1NAZIVDOKUMENT.Text = StringResources.DOKUMENTNAZIVDOKUMENTDescription;
            this.label1IDTIPDOKUMENTA.Text = StringResources.DOKUMENTIDTIPDOKUMENTADescription;
            this.label1NAZIVTIPDOKUMENTA.Text = StringResources.DOKUMENTNAZIVTIPDOKUMENTADescription;
            this.label1PS.Text = StringResources.DOKUMENTPSDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewBLAGAJNA")]
        public void NewBLAGAJNAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.DOKUMENTController.NewBLAGAJNA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewGKSTAVKA")]
        public void NewGKSTAVKAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.DOKUMENTController.NewGKSTAVKA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewIRA")]
        public void NewIRAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.DOKUMENTController.NewIRA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewSHEMAIRA")]
        public void NewSHEMAIRAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.DOKUMENTController.NewSHEMAIRA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewURA")]
        public void NewURAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.DOKUMENTController.NewURA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.DOKUMENTController.WorkItem.Items.Contains("DOKUMENT|DOKUMENT"))
            {
                this.DOKUMENTController.WorkItem.Items.Add(this.bindingSourceDOKUMENT, "DOKUMENT|DOKUMENT");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsDOKUMENTDataSet1.DOKUMENT.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.DOKUMENTController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DOKUMENTController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DOKUMENTController.Update(this))
            {
                this.DOKUMENTController.DataSet = new DOKUMENTDataSet();
                DataSetUtil.AddEmptyRow(this.DOKUMENTController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.DOKUMENTController.DataSet.DOKUMENT[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDDOKUMENT.Focus();
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

        private void UpdateValuesTIPDOKUMENTAIDTIPDOKUMENTA(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceDOKUMENT.Current).Row["IDTIPDOKUMENTA"] = RuntimeHelpers.GetObjectValue(result["IDTIPDOKUMENTA"]);
                ((DataRowView) this.bindingSourceDOKUMENT.Current).Row["NAZIVTIPDOKUMENTA"] = RuntimeHelpers.GetObjectValue(result["NAZIVTIPDOKUMENTA"]);
                this.bindingSourceDOKUMENT.ResetCurrentItem();
            }
        }

        [LocalCommandHandler("ViewBLAGAJNA")]
        public void ViewBLAGAJNAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.DOKUMENTController.ViewBLAGAJNA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewGKSTAVKA")]
        public void ViewGKSTAVKAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.DOKUMENTController.ViewGKSTAVKA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewIRA")]
        public void ViewIRAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.DOKUMENTController.ViewIRA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewSHEMAIRA")]
        public void ViewSHEMAIRAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.DOKUMENTController.ViewSHEMAIRA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewURA")]
        public void ViewURAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.DOKUMENTController.ViewURA(this.m_CurrentRow);
            }
        }

        protected virtual UltraCheckEditor checkPS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkPS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkPS = value;
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.DOKUMENTController DOKUMENTController { get; set; }

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

        protected virtual UltraLabel label1IDDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDDOKUMENT = value;
            }
        }

        protected virtual UltraLabel label1IDTIPDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDTIPDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDTIPDOKUMENTA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVDOKUMENT = value;
            }
        }

        protected virtual UltraLabel label1NAZIVTIPDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVTIPDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVTIPDOKUMENTA = value;
            }
        }

        protected virtual UltraLabel label1PS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PS = value;
            }
        }

        protected virtual UltraLabel labelNAZIVTIPDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVTIPDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVTIPDOKUMENTA = value;
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

        protected virtual UltraNumericEditor textIDDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDDOKUMENT = value;
            }
        }

        protected virtual UltraNumericEditor textIDTIPDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDTIPDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDTIPDOKUMENTA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVDOKUMENT = value;
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

