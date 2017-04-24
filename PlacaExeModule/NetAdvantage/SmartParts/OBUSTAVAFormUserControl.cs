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
    public class OBUSTAVAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDOBUSTAVA")]
        private UltraLabel _label1IDOBUSTAVA;
        [AccessedThroughProperty("label1MOOBUSTAVA")]
        private UltraLabel _label1MOOBUSTAVA;
        [AccessedThroughProperty("label1MZOBUSTAVA")]
        private UltraLabel _label1MZOBUSTAVA;
        [AccessedThroughProperty("label1NAZIVOBUSTAVA")]
        private UltraLabel _label1NAZIVOBUSTAVA;
        [AccessedThroughProperty("label1NAZIVVRSTAOBUSTAVE")]
        private UltraLabel _label1NAZIVVRSTAOBUSTAVE;
        [AccessedThroughProperty("label1OPISPLACANJAOBUSTAVA")]
        private UltraLabel _label1OPISPLACANJAOBUSTAVA;
        [AccessedThroughProperty("label1POOBUSTAVA")]
        private UltraLabel _label1POOBUSTAVA;
        [AccessedThroughProperty("label1PRIMATELJOBUSTAVA1")]
        private UltraLabel _label1PRIMATELJOBUSTAVA1;
        [AccessedThroughProperty("label1PRIMATELJOBUSTAVA2")]
        private UltraLabel _label1PRIMATELJOBUSTAVA2;
        [AccessedThroughProperty("label1PRIMATELJOBUSTAVA3")]
        private UltraLabel _label1PRIMATELJOBUSTAVA3;
        [AccessedThroughProperty("label1PZOBUSTAVA")]
        private UltraLabel _label1PZOBUSTAVA;
        [AccessedThroughProperty("label1SIFRAOPISAPLACANJAOBUSTAVA")]
        private UltraLabel _label1SIFRAOPISAPLACANJAOBUSTAVA;
        [AccessedThroughProperty("label1VBDIOBUSTAVA")]
        private UltraLabel _label1VBDIOBUSTAVA;
        [AccessedThroughProperty("label1VRSTAOBUSTAVE")]
        private UltraLabel _label1VRSTAOBUSTAVE;
        [AccessedThroughProperty("label1ZRNOBUSTAVA")]
        private UltraLabel _label1ZRNOBUSTAVA;
        [AccessedThroughProperty("labelNAZIVVRSTAOBUSTAVE")]
        private UltraLabel _labelNAZIVVRSTAOBUSTAVE;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDOBUSTAVA")]
        private UltraNumericEditor _textIDOBUSTAVA;
        [AccessedThroughProperty("textMOOBUSTAVA")]
        private UltraTextEditor _textMOOBUSTAVA;
        [AccessedThroughProperty("textMZOBUSTAVA")]
        private UltraTextEditor _textMZOBUSTAVA;
        [AccessedThroughProperty("textNAZIVOBUSTAVA")]
        private UltraTextEditor _textNAZIVOBUSTAVA;
        [AccessedThroughProperty("textOPISPLACANJAOBUSTAVA")]
        private UltraTextEditor _textOPISPLACANJAOBUSTAVA;
        [AccessedThroughProperty("textPOOBUSTAVA")]
        private UltraTextEditor _textPOOBUSTAVA;
        [AccessedThroughProperty("textPRIMATELJOBUSTAVA1")]
        private UltraTextEditor _textPRIMATELJOBUSTAVA1;
        [AccessedThroughProperty("textPRIMATELJOBUSTAVA2")]
        private UltraTextEditor _textPRIMATELJOBUSTAVA2;
        [AccessedThroughProperty("textPRIMATELJOBUSTAVA3")]
        private UltraTextEditor _textPRIMATELJOBUSTAVA3;
        [AccessedThroughProperty("textPZOBUSTAVA")]
        private UltraTextEditor _textPZOBUSTAVA;
        [AccessedThroughProperty("textSIFRAOPISAPLACANJAOBUSTAVA")]
        private UltraTextEditor _textSIFRAOPISAPLACANJAOBUSTAVA;
        [AccessedThroughProperty("textVBDIOBUSTAVA")]
        private UltraTextEditor _textVBDIOBUSTAVA;
        [AccessedThroughProperty("textVRSTAOBUSTAVE")]
        private UltraNumericEditor _textVRSTAOBUSTAVE;
        [AccessedThroughProperty("textZRNOBUSTAVA")]
        private UltraTextEditor _textZRNOBUSTAVA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceOBUSTAVA;
        private IContainer components = null;
        private OBUSTAVADataSet dsOBUSTAVADataSet1;
        protected TableLayoutPanel layoutManagerformOBUSTAVA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OBUSTAVADataSet.OBUSTAVARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "OBUSTAVA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.OBUSTAVADescription;
        private DeklaritMode m_Mode;

        public OBUSTAVAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptVRSTAOBUSTAVEVRSTAOBUSTAVE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.OBUSTAVAController.SelectVRSTAOBUSTAVEVRSTAOBUSTAVE(fillMethod, fillByRow);
            this.UpdateValuesVRSTAOBUSTAVEVRSTAOBUSTAVE(result);
        }

        private void CallViewVRSTAOBUSTAVEVRSTAOBUSTAVE(object sender, EventArgs e)
        {
            DataRow result = this.OBUSTAVAController.ShowVRSTAOBUSTAVEVRSTAOBUSTAVE(this.m_CurrentRow);
            this.UpdateValuesVRSTAOBUSTAVEVRSTAOBUSTAVE(result);
        }

        public void ChangeBinding()
        {
            this.bindingSourceOBUSTAVA.DataSource = this.OBUSTAVAController.DataSet;
            this.dsOBUSTAVADataSet1 = this.OBUSTAVAController.DataSet;
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
                    enumerator = this.dsOBUSTAVADataSet1.OBUSTAVA.Rows.GetEnumerator();
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
                if (this.OBUSTAVAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OBUSTAVA", this.m_Mode, this.dsOBUSTAVADataSet1, this.dsOBUSTAVADataSet1.OBUSTAVA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsOBUSTAVADataSet1.OBUSTAVA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (OBUSTAVADataSet.OBUSTAVARow) ((DataRowView) this.bindingSourceOBUSTAVA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(OBUSTAVAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceOBUSTAVA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOBUSTAVA).BeginInit();
            this.layoutManagerformOBUSTAVA = new TableLayoutPanel();
            this.layoutManagerformOBUSTAVA.SuspendLayout();
            this.layoutManagerformOBUSTAVA.AutoSize = true;
            this.layoutManagerformOBUSTAVA.Dock = DockStyle.Fill;
            this.layoutManagerformOBUSTAVA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformOBUSTAVA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformOBUSTAVA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformOBUSTAVA.Size = size;
            this.layoutManagerformOBUSTAVA.ColumnCount = 2;
            this.layoutManagerformOBUSTAVA.RowCount = 0x10;
            this.layoutManagerformOBUSTAVA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOBUSTAVA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBUSTAVA.RowStyles.Add(new RowStyle());
            this.label1IDOBUSTAVA = new UltraLabel();
            this.textIDOBUSTAVA = new UltraNumericEditor();
            this.label1NAZIVOBUSTAVA = new UltraLabel();
            this.textNAZIVOBUSTAVA = new UltraTextEditor();
            this.label1MOOBUSTAVA = new UltraLabel();
            this.textMOOBUSTAVA = new UltraTextEditor();
            this.label1POOBUSTAVA = new UltraLabel();
            this.textPOOBUSTAVA = new UltraTextEditor();
            this.label1MZOBUSTAVA = new UltraLabel();
            this.textMZOBUSTAVA = new UltraTextEditor();
            this.label1PZOBUSTAVA = new UltraLabel();
            this.textPZOBUSTAVA = new UltraTextEditor();
            this.label1VBDIOBUSTAVA = new UltraLabel();
            this.textVBDIOBUSTAVA = new UltraTextEditor();
            this.label1ZRNOBUSTAVA = new UltraLabel();
            this.textZRNOBUSTAVA = new UltraTextEditor();
            this.label1PRIMATELJOBUSTAVA1 = new UltraLabel();
            this.textPRIMATELJOBUSTAVA1 = new UltraTextEditor();
            this.label1PRIMATELJOBUSTAVA2 = new UltraLabel();
            this.textPRIMATELJOBUSTAVA2 = new UltraTextEditor();
            this.label1PRIMATELJOBUSTAVA3 = new UltraLabel();
            this.textPRIMATELJOBUSTAVA3 = new UltraTextEditor();
            this.label1SIFRAOPISAPLACANJAOBUSTAVA = new UltraLabel();
            this.textSIFRAOPISAPLACANJAOBUSTAVA = new UltraTextEditor();
            this.label1OPISPLACANJAOBUSTAVA = new UltraLabel();
            this.textOPISPLACANJAOBUSTAVA = new UltraTextEditor();
            this.label1VRSTAOBUSTAVE = new UltraLabel();
            this.textVRSTAOBUSTAVE = new UltraNumericEditor();
            this.label1NAZIVVRSTAOBUSTAVE = new UltraLabel();
            this.labelNAZIVVRSTAOBUSTAVE = new UltraLabel();
            ((ISupportInitialize) this.textIDOBUSTAVA).BeginInit();
            ((ISupportInitialize) this.textNAZIVOBUSTAVA).BeginInit();
            ((ISupportInitialize) this.textMOOBUSTAVA).BeginInit();
            ((ISupportInitialize) this.textPOOBUSTAVA).BeginInit();
            ((ISupportInitialize) this.textMZOBUSTAVA).BeginInit();
            ((ISupportInitialize) this.textPZOBUSTAVA).BeginInit();
            ((ISupportInitialize) this.textVBDIOBUSTAVA).BeginInit();
            ((ISupportInitialize) this.textZRNOBUSTAVA).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJOBUSTAVA1).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJOBUSTAVA2).BeginInit();
            ((ISupportInitialize) this.textPRIMATELJOBUSTAVA3).BeginInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJAOBUSTAVA).BeginInit();
            ((ISupportInitialize) this.textOPISPLACANJAOBUSTAVA).BeginInit();
            ((ISupportInitialize) this.textVRSTAOBUSTAVE).BeginInit();
            this.dsOBUSTAVADataSet1 = new OBUSTAVADataSet();
            this.dsOBUSTAVADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsOBUSTAVADataSet1.DataSetName = "dsOBUSTAVA";
            this.dsOBUSTAVADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceOBUSTAVA.DataSource = this.dsOBUSTAVADataSet1;
            this.bindingSourceOBUSTAVA.DataMember = "OBUSTAVA";
            ((ISupportInitialize) this.bindingSourceOBUSTAVA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDOBUSTAVA.Location = point;
            this.label1IDOBUSTAVA.Name = "label1IDOBUSTAVA";
            this.label1IDOBUSTAVA.TabIndex = 1;
            this.label1IDOBUSTAVA.Tag = "labelIDOBUSTAVA";
            this.label1IDOBUSTAVA.Text = "Šifra obustave:";
            this.label1IDOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1IDOBUSTAVA.AutoSize = true;
            this.label1IDOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1IDOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOBUSTAVA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDOBUSTAVA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDOBUSTAVA.ImageSize = size;
            this.label1IDOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1IDOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.label1IDOBUSTAVA, 0, 0);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.label1IDOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.label1IDOBUSTAVA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x69, 0x17);
            this.label1IDOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDOBUSTAVA.Location = point;
            this.textIDOBUSTAVA.Name = "textIDOBUSTAVA";
            this.textIDOBUSTAVA.Tag = "IDOBUSTAVA";
            this.textIDOBUSTAVA.TabIndex = 0;
            this.textIDOBUSTAVA.Anchor = AnchorStyles.Left;
            this.textIDOBUSTAVA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDOBUSTAVA.ReadOnly = false;
            this.textIDOBUSTAVA.PromptChar = ' ';
            this.textIDOBUSTAVA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDOBUSTAVA.DataBindings.Add(new Binding("Value", this.bindingSourceOBUSTAVA, "IDOBUSTAVA"));
            this.textIDOBUSTAVA.NumericType = NumericType.Integer;
            this.textIDOBUSTAVA.MaskInput = "{LOC}-nnnnnnnn";
            this.layoutManagerformOBUSTAVA.Controls.Add(this.textIDOBUSTAVA, 1, 0);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.textIDOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.textIDOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVOBUSTAVA.Location = point;
            this.label1NAZIVOBUSTAVA.Name = "label1NAZIVOBUSTAVA";
            this.label1NAZIVOBUSTAVA.TabIndex = 1;
            this.label1NAZIVOBUSTAVA.Tag = "labelNAZIVOBUSTAVA";
            this.label1NAZIVOBUSTAVA.Text = "Naziv obustave:";
            this.label1NAZIVOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVOBUSTAVA.AutoSize = true;
            this.label1NAZIVOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1NAZIVOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.label1NAZIVOBUSTAVA, 0, 1);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.label1NAZIVOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.label1NAZIVOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x72, 0x17);
            this.label1NAZIVOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVOBUSTAVA.Location = point;
            this.textNAZIVOBUSTAVA.Name = "textNAZIVOBUSTAVA";
            this.textNAZIVOBUSTAVA.Tag = "NAZIVOBUSTAVA";
            this.textNAZIVOBUSTAVA.TabIndex = 0;
            this.textNAZIVOBUSTAVA.Anchor = AnchorStyles.Left;
            this.textNAZIVOBUSTAVA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVOBUSTAVA.ReadOnly = false;
            this.textNAZIVOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBUSTAVA, "NAZIVOBUSTAVA"));
            this.textNAZIVOBUSTAVA.MaxLength = 100;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.textNAZIVOBUSTAVA, 1, 1);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.textNAZIVOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.textNAZIVOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MOOBUSTAVA.Location = point;
            this.label1MOOBUSTAVA.Name = "label1MOOBUSTAVA";
            this.label1MOOBUSTAVA.TabIndex = 1;
            this.label1MOOBUSTAVA.Tag = "labelMOOBUSTAVA";
            this.label1MOOBUSTAVA.Text = "Model odobrenja:";
            this.label1MOOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1MOOBUSTAVA.AutoSize = true;
            this.label1MOOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1MOOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MOOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1MOOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.label1MOOBUSTAVA, 0, 2);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.label1MOOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.label1MOOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MOOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MOOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1MOOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMOOBUSTAVA.Location = point;
            this.textMOOBUSTAVA.Name = "textMOOBUSTAVA";
            this.textMOOBUSTAVA.Tag = "MOOBUSTAVA";
            this.textMOOBUSTAVA.TabIndex = 0;
            this.textMOOBUSTAVA.Anchor = AnchorStyles.Left;
            this.textMOOBUSTAVA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMOOBUSTAVA.ContextMenu = this.contextMenu1;
            this.textMOOBUSTAVA.ReadOnly = false;
            this.textMOOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBUSTAVA, "MOOBUSTAVA"));
            this.textMOOBUSTAVA.Nullable = true;
            this.textMOOBUSTAVA.MaxLength = 2;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.textMOOBUSTAVA, 1, 2);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.textMOOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.textMOOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMOOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMOOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMOOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POOBUSTAVA.Location = point;
            this.label1POOBUSTAVA.Name = "label1POOBUSTAVA";
            this.label1POOBUSTAVA.TabIndex = 1;
            this.label1POOBUSTAVA.Tag = "labelPOOBUSTAVA";
            this.label1POOBUSTAVA.Text = "Poziv na broj odobrenja obustave:";
            this.label1POOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1POOBUSTAVA.AutoSize = true;
            this.label1POOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1POOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1POOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1POOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.label1POOBUSTAVA, 0, 3);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.label1POOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.label1POOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0xe3, 0x17);
            this.label1POOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOOBUSTAVA.Location = point;
            this.textPOOBUSTAVA.Name = "textPOOBUSTAVA";
            this.textPOOBUSTAVA.Tag = "POOBUSTAVA";
            this.textPOOBUSTAVA.TabIndex = 0;
            this.textPOOBUSTAVA.Anchor = AnchorStyles.Left;
            this.textPOOBUSTAVA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOOBUSTAVA.ContextMenu = this.contextMenu1;
            this.textPOOBUSTAVA.ReadOnly = false;
            this.textPOOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBUSTAVA, "POOBUSTAVA"));
            this.textPOOBUSTAVA.Nullable = true;
            this.textPOOBUSTAVA.MaxLength = 0x16;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.textPOOBUSTAVA, 1, 3);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.textPOOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.textPOOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPOOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MZOBUSTAVA.Location = point;
            this.label1MZOBUSTAVA.Name = "label1MZOBUSTAVA";
            this.label1MZOBUSTAVA.TabIndex = 1;
            this.label1MZOBUSTAVA.Tag = "labelMZOBUSTAVA";
            this.label1MZOBUSTAVA.Text = "Model zaduženja obustave:";
            this.label1MZOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1MZOBUSTAVA.AutoSize = true;
            this.label1MZOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1MZOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MZOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1MZOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.label1MZOBUSTAVA, 0, 4);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.label1MZOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.label1MZOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MZOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MZOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0xb8, 0x17);
            this.label1MZOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMZOBUSTAVA.Location = point;
            this.textMZOBUSTAVA.Name = "textMZOBUSTAVA";
            this.textMZOBUSTAVA.Tag = "MZOBUSTAVA";
            this.textMZOBUSTAVA.TabIndex = 0;
            this.textMZOBUSTAVA.Anchor = AnchorStyles.Left;
            this.textMZOBUSTAVA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMZOBUSTAVA.ContextMenu = this.contextMenu1;
            this.textMZOBUSTAVA.ReadOnly = false;
            this.textMZOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBUSTAVA, "MZOBUSTAVA"));
            this.textMZOBUSTAVA.Nullable = true;
            this.textMZOBUSTAVA.MaxLength = 2;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.textMZOBUSTAVA, 1, 4);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.textMZOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.textMZOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMZOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMZOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMZOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PZOBUSTAVA.Location = point;
            this.label1PZOBUSTAVA.Name = "label1PZOBUSTAVA";
            this.label1PZOBUSTAVA.TabIndex = 1;
            this.label1PZOBUSTAVA.Tag = "labelPZOBUSTAVA";
            this.label1PZOBUSTAVA.Text = "Poziv na broj zaduženja obustave:";
            this.label1PZOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1PZOBUSTAVA.AutoSize = true;
            this.label1PZOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1PZOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1PZOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1PZOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.label1PZOBUSTAVA, 0, 5);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.label1PZOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.label1PZOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PZOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PZOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0xe3, 0x17);
            this.label1PZOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPZOBUSTAVA.Location = point;
            this.textPZOBUSTAVA.Name = "textPZOBUSTAVA";
            this.textPZOBUSTAVA.Tag = "PZOBUSTAVA";
            this.textPZOBUSTAVA.TabIndex = 0;
            this.textPZOBUSTAVA.Anchor = AnchorStyles.Left;
            this.textPZOBUSTAVA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPZOBUSTAVA.ContextMenu = this.contextMenu1;
            this.textPZOBUSTAVA.ReadOnly = false;
            this.textPZOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBUSTAVA, "PZOBUSTAVA"));
            this.textPZOBUSTAVA.Nullable = true;
            this.textPZOBUSTAVA.MaxLength = 0x16;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.textPZOBUSTAVA, 1, 5);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.textPZOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.textPZOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPZOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textPZOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textPZOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VBDIOBUSTAVA.Location = point;
            this.label1VBDIOBUSTAVA.Name = "label1VBDIOBUSTAVA";
            this.label1VBDIOBUSTAVA.TabIndex = 1;
            this.label1VBDIOBUSTAVA.Tag = "labelVBDIOBUSTAVA";
            this.label1VBDIOBUSTAVA.Text = "VBDI žiro računa obustave:";
            this.label1VBDIOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1VBDIOBUSTAVA.AutoSize = true;
            this.label1VBDIOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1VBDIOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1VBDIOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1VBDIOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.label1VBDIOBUSTAVA, 0, 6);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.label1VBDIOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.label1VBDIOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VBDIOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VBDIOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0xb8, 0x17);
            this.label1VBDIOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVBDIOBUSTAVA.Location = point;
            this.textVBDIOBUSTAVA.Name = "textVBDIOBUSTAVA";
            this.textVBDIOBUSTAVA.Tag = "VBDIOBUSTAVA";
            this.textVBDIOBUSTAVA.TabIndex = 0;
            this.textVBDIOBUSTAVA.Anchor = AnchorStyles.Left;
            this.textVBDIOBUSTAVA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVBDIOBUSTAVA.ReadOnly = false;
            this.textVBDIOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBUSTAVA, "VBDIOBUSTAVA"));
            this.textVBDIOBUSTAVA.MaxLength = 7;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.textVBDIOBUSTAVA, 1, 6);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.textVBDIOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.textVBDIOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVBDIOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDIOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textVBDIOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZRNOBUSTAVA.Location = point;
            this.label1ZRNOBUSTAVA.Name = "label1ZRNOBUSTAVA";
            this.label1ZRNOBUSTAVA.TabIndex = 1;
            this.label1ZRNOBUSTAVA.Tag = "labelZRNOBUSTAVA";
            this.label1ZRNOBUSTAVA.Text = "Broj žiro računa obustave:";
            this.label1ZRNOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1ZRNOBUSTAVA.AutoSize = true;
            this.label1ZRNOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1ZRNOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZRNOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1ZRNOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.label1ZRNOBUSTAVA, 0, 7);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.label1ZRNOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.label1ZRNOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZRNOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZRNOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0xb2, 0x17);
            this.label1ZRNOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZRNOBUSTAVA.Location = point;
            this.textZRNOBUSTAVA.Name = "textZRNOBUSTAVA";
            this.textZRNOBUSTAVA.Tag = "ZRNOBUSTAVA";
            this.textZRNOBUSTAVA.TabIndex = 0;
            this.textZRNOBUSTAVA.Anchor = AnchorStyles.Left;
            this.textZRNOBUSTAVA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZRNOBUSTAVA.ReadOnly = false;
            this.textZRNOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBUSTAVA, "ZRNOBUSTAVA"));
            this.textZRNOBUSTAVA.MaxLength = 10;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.textZRNOBUSTAVA, 1, 7);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.textZRNOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.textZRNOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZRNOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZRNOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textZRNOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJOBUSTAVA1.Location = point;
            this.label1PRIMATELJOBUSTAVA1.Name = "label1PRIMATELJOBUSTAVA1";
            this.label1PRIMATELJOBUSTAVA1.TabIndex = 1;
            this.label1PRIMATELJOBUSTAVA1.Tag = "labelPRIMATELJOBUSTAVA1";
            this.label1PRIMATELJOBUSTAVA1.Text = "Primatelj (1):";
            this.label1PRIMATELJOBUSTAVA1.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJOBUSTAVA1.AutoSize = true;
            this.label1PRIMATELJOBUSTAVA1.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJOBUSTAVA1.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJOBUSTAVA1.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJOBUSTAVA1.BackColor = Color.Transparent;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.label1PRIMATELJOBUSTAVA1, 0, 8);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.label1PRIMATELJOBUSTAVA1, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.label1PRIMATELJOBUSTAVA1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJOBUSTAVA1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJOBUSTAVA1.MinimumSize = size;
            size = new System.Drawing.Size(0x63, 0x17);
            this.label1PRIMATELJOBUSTAVA1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJOBUSTAVA1.Location = point;
            this.textPRIMATELJOBUSTAVA1.Name = "textPRIMATELJOBUSTAVA1";
            this.textPRIMATELJOBUSTAVA1.Tag = "PRIMATELJOBUSTAVA1";
            this.textPRIMATELJOBUSTAVA1.TabIndex = 0;
            this.textPRIMATELJOBUSTAVA1.Anchor = AnchorStyles.Left;
            this.textPRIMATELJOBUSTAVA1.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJOBUSTAVA1.ReadOnly = false;
            this.textPRIMATELJOBUSTAVA1.DataBindings.Add(new Binding("Text", this.bindingSourceOBUSTAVA, "PRIMATELJOBUSTAVA1"));
            this.textPRIMATELJOBUSTAVA1.MaxLength = 20;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.textPRIMATELJOBUSTAVA1, 1, 8);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.textPRIMATELJOBUSTAVA1, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.textPRIMATELJOBUSTAVA1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJOBUSTAVA1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJOBUSTAVA1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJOBUSTAVA1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJOBUSTAVA2.Location = point;
            this.label1PRIMATELJOBUSTAVA2.Name = "label1PRIMATELJOBUSTAVA2";
            this.label1PRIMATELJOBUSTAVA2.TabIndex = 1;
            this.label1PRIMATELJOBUSTAVA2.Tag = "labelPRIMATELJOBUSTAVA2";
            this.label1PRIMATELJOBUSTAVA2.Text = "Primatelj (2):";
            this.label1PRIMATELJOBUSTAVA2.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJOBUSTAVA2.AutoSize = true;
            this.label1PRIMATELJOBUSTAVA2.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJOBUSTAVA2.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJOBUSTAVA2.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJOBUSTAVA2.BackColor = Color.Transparent;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.label1PRIMATELJOBUSTAVA2, 0, 9);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.label1PRIMATELJOBUSTAVA2, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.label1PRIMATELJOBUSTAVA2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJOBUSTAVA2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJOBUSTAVA2.MinimumSize = size;
            size = new System.Drawing.Size(0x63, 0x17);
            this.label1PRIMATELJOBUSTAVA2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJOBUSTAVA2.Location = point;
            this.textPRIMATELJOBUSTAVA2.Name = "textPRIMATELJOBUSTAVA2";
            this.textPRIMATELJOBUSTAVA2.Tag = "PRIMATELJOBUSTAVA2";
            this.textPRIMATELJOBUSTAVA2.TabIndex = 0;
            this.textPRIMATELJOBUSTAVA2.Anchor = AnchorStyles.Left;
            this.textPRIMATELJOBUSTAVA2.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJOBUSTAVA2.ContextMenu = this.contextMenu1;
            this.textPRIMATELJOBUSTAVA2.ReadOnly = false;
            this.textPRIMATELJOBUSTAVA2.DataBindings.Add(new Binding("Text", this.bindingSourceOBUSTAVA, "PRIMATELJOBUSTAVA2"));
            this.textPRIMATELJOBUSTAVA2.Nullable = true;
            this.textPRIMATELJOBUSTAVA2.MaxLength = 20;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.textPRIMATELJOBUSTAVA2, 1, 9);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.textPRIMATELJOBUSTAVA2, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.textPRIMATELJOBUSTAVA2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJOBUSTAVA2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJOBUSTAVA2.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJOBUSTAVA2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJOBUSTAVA3.Location = point;
            this.label1PRIMATELJOBUSTAVA3.Name = "label1PRIMATELJOBUSTAVA3";
            this.label1PRIMATELJOBUSTAVA3.TabIndex = 1;
            this.label1PRIMATELJOBUSTAVA3.Tag = "labelPRIMATELJOBUSTAVA3";
            this.label1PRIMATELJOBUSTAVA3.Text = "Primatelj (3):";
            this.label1PRIMATELJOBUSTAVA3.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJOBUSTAVA3.AutoSize = true;
            this.label1PRIMATELJOBUSTAVA3.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJOBUSTAVA3.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJOBUSTAVA3.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJOBUSTAVA3.BackColor = Color.Transparent;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.label1PRIMATELJOBUSTAVA3, 0, 10);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.label1PRIMATELJOBUSTAVA3, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.label1PRIMATELJOBUSTAVA3, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJOBUSTAVA3.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJOBUSTAVA3.MinimumSize = size;
            size = new System.Drawing.Size(0x63, 0x17);
            this.label1PRIMATELJOBUSTAVA3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRIMATELJOBUSTAVA3.Location = point;
            this.textPRIMATELJOBUSTAVA3.Name = "textPRIMATELJOBUSTAVA3";
            this.textPRIMATELJOBUSTAVA3.Tag = "PRIMATELJOBUSTAVA3";
            this.textPRIMATELJOBUSTAVA3.TabIndex = 0;
            this.textPRIMATELJOBUSTAVA3.Anchor = AnchorStyles.Left;
            this.textPRIMATELJOBUSTAVA3.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRIMATELJOBUSTAVA3.ContextMenu = this.contextMenu1;
            this.textPRIMATELJOBUSTAVA3.ReadOnly = false;
            this.textPRIMATELJOBUSTAVA3.DataBindings.Add(new Binding("Text", this.bindingSourceOBUSTAVA, "PRIMATELJOBUSTAVA3"));
            this.textPRIMATELJOBUSTAVA3.Nullable = true;
            this.textPRIMATELJOBUSTAVA3.MaxLength = 20;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.textPRIMATELJOBUSTAVA3, 1, 10);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.textPRIMATELJOBUSTAVA3, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.textPRIMATELJOBUSTAVA3, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRIMATELJOBUSTAVA3.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJOBUSTAVA3.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPRIMATELJOBUSTAVA3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Location = point;
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Name = "label1SIFRAOPISAPLACANJAOBUSTAVA";
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.TabIndex = 1;
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Tag = "labelSIFRAOPISAPLACANJAOBUSTAVA";
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Text = "Šifra opisa plaćanja:";
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.AutoSize = true;
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.label1SIFRAOPISAPLACANJAOBUSTAVA, 0, 11);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.label1SIFRAOPISAPLACANJAOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.label1SIFRAOPISAPLACANJAOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 0x17);
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSIFRAOPISAPLACANJAOBUSTAVA.Location = point;
            this.textSIFRAOPISAPLACANJAOBUSTAVA.Name = "textSIFRAOPISAPLACANJAOBUSTAVA";
            this.textSIFRAOPISAPLACANJAOBUSTAVA.Tag = "SIFRAOPISAPLACANJAOBUSTAVA";
            this.textSIFRAOPISAPLACANJAOBUSTAVA.TabIndex = 0;
            this.textSIFRAOPISAPLACANJAOBUSTAVA.Anchor = AnchorStyles.Left;
            this.textSIFRAOPISAPLACANJAOBUSTAVA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSIFRAOPISAPLACANJAOBUSTAVA.ReadOnly = false;
            this.textSIFRAOPISAPLACANJAOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBUSTAVA, "SIFRAOPISAPLACANJAOBUSTAVA"));
            this.textSIFRAOPISAPLACANJAOBUSTAVA.MaxLength = 2;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.textSIFRAOPISAPLACANJAOBUSTAVA, 1, 11);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.textSIFRAOPISAPLACANJAOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.textSIFRAOPISAPLACANJAOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSIFRAOPISAPLACANJAOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJAOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textSIFRAOPISAPLACANJAOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISPLACANJAOBUSTAVA.Location = point;
            this.label1OPISPLACANJAOBUSTAVA.Name = "label1OPISPLACANJAOBUSTAVA";
            this.label1OPISPLACANJAOBUSTAVA.TabIndex = 1;
            this.label1OPISPLACANJAOBUSTAVA.Tag = "labelOPISPLACANJAOBUSTAVA";
            this.label1OPISPLACANJAOBUSTAVA.Text = "Opis plaćanja:";
            this.label1OPISPLACANJAOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1OPISPLACANJAOBUSTAVA.AutoSize = true;
            this.label1OPISPLACANJAOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1OPISPLACANJAOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISPLACANJAOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1OPISPLACANJAOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.label1OPISPLACANJAOBUSTAVA, 0, 12);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.label1OPISPLACANJAOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.label1OPISPLACANJAOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISPLACANJAOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISPLACANJAOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x67, 0x17);
            this.label1OPISPLACANJAOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPISPLACANJAOBUSTAVA.Location = point;
            this.textOPISPLACANJAOBUSTAVA.Name = "textOPISPLACANJAOBUSTAVA";
            this.textOPISPLACANJAOBUSTAVA.Tag = "OPISPLACANJAOBUSTAVA";
            this.textOPISPLACANJAOBUSTAVA.TabIndex = 0;
            this.textOPISPLACANJAOBUSTAVA.Anchor = AnchorStyles.Left;
            this.textOPISPLACANJAOBUSTAVA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPISPLACANJAOBUSTAVA.ReadOnly = false;
            this.textOPISPLACANJAOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBUSTAVA, "OPISPLACANJAOBUSTAVA"));
            this.textOPISPLACANJAOBUSTAVA.MaxLength = 0x24;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.textOPISPLACANJAOBUSTAVA, 1, 12);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.textOPISPLACANJAOBUSTAVA, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.textOPISPLACANJAOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPISPLACANJAOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJAOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOPISPLACANJAOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VRSTAOBUSTAVE.Location = point;
            this.label1VRSTAOBUSTAVE.Name = "label1VRSTAOBUSTAVE";
            this.label1VRSTAOBUSTAVE.TabIndex = 1;
            this.label1VRSTAOBUSTAVE.Tag = "labelVRSTAOBUSTAVE";
            this.label1VRSTAOBUSTAVE.Text = "Vrsta obustave:";
            this.label1VRSTAOBUSTAVE.StyleSetName = "FieldUltraLabel";
            this.label1VRSTAOBUSTAVE.AutoSize = true;
            this.label1VRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.label1VRSTAOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.label1VRSTAOBUSTAVE.Appearance.ForeColor = Color.Black;
            this.label1VRSTAOBUSTAVE.BackColor = Color.Transparent;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.label1VRSTAOBUSTAVE, 0, 13);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.label1VRSTAOBUSTAVE, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.label1VRSTAOBUSTAVE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x70, 0x17);
            this.label1VRSTAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVRSTAOBUSTAVE.Location = point;
            this.textVRSTAOBUSTAVE.Name = "textVRSTAOBUSTAVE";
            this.textVRSTAOBUSTAVE.Tag = "VRSTAOBUSTAVE";
            this.textVRSTAOBUSTAVE.TabIndex = 0;
            this.textVRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.textVRSTAOBUSTAVE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVRSTAOBUSTAVE.ReadOnly = false;
            this.textVRSTAOBUSTAVE.PromptChar = ' ';
            this.textVRSTAOBUSTAVE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textVRSTAOBUSTAVE.DataBindings.Add(new Binding("Value", this.bindingSourceOBUSTAVA, "VRSTAOBUSTAVE"));
            this.textVRSTAOBUSTAVE.NumericType = NumericType.Integer;
            this.textVRSTAOBUSTAVE.MaskInput = "{LOC}-nn";
            EditorButton button = new EditorButton {
                Key = "editorButtonVRSTAOBUSTAVEVRSTAOBUSTAVE",
                Tag = "editorButtonVRSTAOBUSTAVEVRSTAOBUSTAVE",
                Text = "..."
            };
            this.textVRSTAOBUSTAVE.ButtonsRight.Add(button);
            this.textVRSTAOBUSTAVE.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptVRSTAOBUSTAVEVRSTAOBUSTAVE);
            this.layoutManagerformOBUSTAVA.Controls.Add(this.textVRSTAOBUSTAVE, 1, 13);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.textVRSTAOBUSTAVE, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.textVRSTAOBUSTAVE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textVRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textVRSTAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVVRSTAOBUSTAVE.Location = point;
            this.label1NAZIVVRSTAOBUSTAVE.Name = "label1NAZIVVRSTAOBUSTAVE";
            this.label1NAZIVVRSTAOBUSTAVE.TabIndex = 1;
            this.label1NAZIVVRSTAOBUSTAVE.Tag = "labelNAZIVVRSTAOBUSTAVE";
            this.label1NAZIVVRSTAOBUSTAVE.Text = "Opis vrste obustave:";
            this.label1NAZIVVRSTAOBUSTAVE.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVVRSTAOBUSTAVE.AutoSize = true;
            this.label1NAZIVVRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.label1NAZIVVRSTAOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVVRSTAOBUSTAVE.Appearance.ForeColor = Color.Black;
            this.label1NAZIVVRSTAOBUSTAVE.BackColor = Color.Transparent;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.label1NAZIVVRSTAOBUSTAVE, 0, 14);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.label1NAZIVVRSTAOBUSTAVE, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.label1NAZIVVRSTAOBUSTAVE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVVRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVVRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x8e, 0x17);
            this.label1NAZIVVRSTAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVVRSTAOBUSTAVE.Location = point;
            this.labelNAZIVVRSTAOBUSTAVE.Name = "labelNAZIVVRSTAOBUSTAVE";
            this.labelNAZIVVRSTAOBUSTAVE.Tag = "NAZIVVRSTAOBUSTAVE";
            this.labelNAZIVVRSTAOBUSTAVE.TabIndex = 0;
            this.labelNAZIVVRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.labelNAZIVVRSTAOBUSTAVE.BackColor = Color.Transparent;
            this.labelNAZIVVRSTAOBUSTAVE.DataBindings.Add(new Binding("Text", this.bindingSourceOBUSTAVA, "NAZIVVRSTAOBUSTAVE"));
            this.labelNAZIVVRSTAOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBUSTAVA.Controls.Add(this.labelNAZIVVRSTAOBUSTAVE, 1, 14);
            this.layoutManagerformOBUSTAVA.SetColumnSpan(this.labelNAZIVVRSTAOBUSTAVE, 1);
            this.layoutManagerformOBUSTAVA.SetRowSpan(this.labelNAZIVVRSTAOBUSTAVE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVVRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVVRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVVRSTAOBUSTAVE.Size = size;
            this.Controls.Add(this.layoutManagerformOBUSTAVA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceOBUSTAVA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "OBUSTAVAFormUserControl";
            this.Text = "Obustave";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OBUSTAVAFormUserControl_Load);
            this.layoutManagerformOBUSTAVA.ResumeLayout(false);
            this.layoutManagerformOBUSTAVA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceOBUSTAVA).EndInit();
            ((ISupportInitialize) this.textIDOBUSTAVA).EndInit();
            ((ISupportInitialize) this.textNAZIVOBUSTAVA).EndInit();
            ((ISupportInitialize) this.textMOOBUSTAVA).EndInit();
            ((ISupportInitialize) this.textPOOBUSTAVA).EndInit();
            ((ISupportInitialize) this.textMZOBUSTAVA).EndInit();
            ((ISupportInitialize) this.textPZOBUSTAVA).EndInit();
            ((ISupportInitialize) this.textVBDIOBUSTAVA).EndInit();
            ((ISupportInitialize) this.textZRNOBUSTAVA).EndInit();
            ((ISupportInitialize) this.textPRIMATELJOBUSTAVA1).EndInit();
            ((ISupportInitialize) this.textPRIMATELJOBUSTAVA2).EndInit();
            ((ISupportInitialize) this.textPRIMATELJOBUSTAVA3).EndInit();
            ((ISupportInitialize) this.textSIFRAOPISAPLACANJAOBUSTAVA).EndInit();
            ((ISupportInitialize) this.textOPISPLACANJAOBUSTAVA).EndInit();
            ((ISupportInitialize) this.textVRSTAOBUSTAVE).EndInit();
            this.dsOBUSTAVADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OBUSTAVAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceOBUSTAVA, this.OBUSTAVAController.WorkItem, this))
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
            this.label1IDOBUSTAVA.Text = StringResources.OBUSTAVAIDOBUSTAVADescription;
            this.label1NAZIVOBUSTAVA.Text = StringResources.OBUSTAVANAZIVOBUSTAVADescription;
            this.label1MOOBUSTAVA.Text = StringResources.OBUSTAVAMOOBUSTAVADescription;
            this.label1POOBUSTAVA.Text = StringResources.OBUSTAVAPOOBUSTAVADescription;
            this.label1MZOBUSTAVA.Text = StringResources.OBUSTAVAMZOBUSTAVADescription;
            this.label1PZOBUSTAVA.Text = StringResources.OBUSTAVAPZOBUSTAVADescription;
            this.label1VBDIOBUSTAVA.Text = StringResources.OBUSTAVAVBDIOBUSTAVADescription;
            this.label1ZRNOBUSTAVA.Text = StringResources.OBUSTAVAZRNOBUSTAVADescription;
            this.label1PRIMATELJOBUSTAVA1.Text = StringResources.OBUSTAVAPRIMATELJOBUSTAVA1Description;
            this.label1PRIMATELJOBUSTAVA2.Text = StringResources.OBUSTAVAPRIMATELJOBUSTAVA2Description;
            this.label1PRIMATELJOBUSTAVA3.Text = StringResources.OBUSTAVAPRIMATELJOBUSTAVA3Description;
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Text = StringResources.OBUSTAVASIFRAOPISAPLACANJAOBUSTAVADescription;
            this.label1OPISPLACANJAOBUSTAVA.Text = StringResources.OBUSTAVAOPISPLACANJAOBUSTAVADescription;
            this.label1VRSTAOBUSTAVE.Text = StringResources.OBUSTAVAVRSTAOBUSTAVEDescription;
            this.label1NAZIVVRSTAOBUSTAVE.Text = StringResources.OBUSTAVANAZIVVRSTAOBUSTAVEDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void OBUSTAVAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OBUSTAVADescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.OBUSTAVAController.WorkItem.Items.Contains("OBUSTAVA|OBUSTAVA"))
            {
                this.OBUSTAVAController.WorkItem.Items.Add(this.bindingSourceOBUSTAVA, "OBUSTAVA|OBUSTAVA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsOBUSTAVADataSet1.OBUSTAVA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.OBUSTAVAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OBUSTAVAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OBUSTAVAController.Update(this))
            {
                this.OBUSTAVAController.DataSet = new OBUSTAVADataSet();
                DataSetUtil.AddEmptyRow(this.OBUSTAVAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.OBUSTAVAController.DataSet.OBUSTAVA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDOBUSTAVA.Focus();
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

        private void UpdateValuesVRSTAOBUSTAVEVRSTAOBUSTAVE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceOBUSTAVA.Current).Row["VRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(result["VRSTAOBUSTAVE"]);
                ((DataRowView) this.bindingSourceOBUSTAVA.Current).Row["NAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(result["NAZIVVRSTAOBUSTAVE"]);
                this.bindingSourceOBUSTAVA.ResetCurrentItem();
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

        protected virtual UltraLabel label1IDOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1MOOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MOOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MOOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1MZOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MZOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MZOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVVRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVVRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVVRSTAOBUSTAVE = value;
            }
        }

        protected virtual UltraLabel label1OPISPLACANJAOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISPLACANJAOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISPLACANJAOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1POOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJOBUSTAVA1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJOBUSTAVA1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJOBUSTAVA1 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJOBUSTAVA2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJOBUSTAVA2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJOBUSTAVA2 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJOBUSTAVA3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJOBUSTAVA3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJOBUSTAVA3 = value;
            }
        }

        protected virtual UltraLabel label1PZOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PZOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PZOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1SIFRAOPISAPLACANJAOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAOPISAPLACANJAOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAOPISAPLACANJAOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1VBDIOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VBDIOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VBDIOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1VRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VRSTAOBUSTAVE = value;
            }
        }

        protected virtual UltraLabel label1ZRNOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZRNOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZRNOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel labelNAZIVVRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVVRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVVRSTAOBUSTAVE = value;
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
        public NetAdvantage.Controllers.OBUSTAVAController OBUSTAVAController { get; set; }

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

        protected virtual UltraNumericEditor textIDOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDOBUSTAVA = value;
            }
        }

        protected virtual UltraTextEditor textMOOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMOOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMOOBUSTAVA = value;
            }
        }

        protected virtual UltraTextEditor textMZOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMZOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMZOBUSTAVA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVOBUSTAVA = value;
            }
        }

        protected virtual UltraTextEditor textOPISPLACANJAOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPISPLACANJAOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPISPLACANJAOBUSTAVA = value;
            }
        }

        protected virtual UltraTextEditor textPOOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOOBUSTAVA = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJOBUSTAVA1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJOBUSTAVA1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJOBUSTAVA1 = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJOBUSTAVA2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJOBUSTAVA2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJOBUSTAVA2 = value;
            }
        }

        protected virtual UltraTextEditor textPRIMATELJOBUSTAVA3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRIMATELJOBUSTAVA3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRIMATELJOBUSTAVA3 = value;
            }
        }

        protected virtual UltraTextEditor textPZOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPZOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPZOBUSTAVA = value;
            }
        }

        protected virtual UltraTextEditor textSIFRAOPISAPLACANJAOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSIFRAOPISAPLACANJAOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSIFRAOPISAPLACANJAOBUSTAVA = value;
            }
        }

        protected virtual UltraTextEditor textVBDIOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVBDIOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVBDIOBUSTAVA = value;
            }
        }

        protected virtual UltraNumericEditor textVRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVRSTAOBUSTAVE = value;
            }
        }

        protected virtual UltraTextEditor textZRNOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZRNOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZRNOBUSTAVA = value;
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

