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
    public class FINPOREZFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1FINPOREZIDPOREZ")]
        private UltraLabel _label1FINPOREZIDPOREZ;
        [AccessedThroughProperty("label1FINPOREZNAZIVPOREZ")]
        private UltraLabel _label1FINPOREZNAZIVPOREZ;
        [AccessedThroughProperty("label1FINPOREZSTOPA")]
        private UltraLabel _label1FINPOREZSTOPA;
        [AccessedThroughProperty("label1OSNOVICAUKNIZIIRA")]
        private UltraLabel _label1OSNOVICAUKNIZIIRA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textFINPOREZIDPOREZ")]
        private UltraNumericEditor _textFINPOREZIDPOREZ;
        [AccessedThroughProperty("textFINPOREZNAZIVPOREZ")]
        private UltraTextEditor _textFINPOREZNAZIVPOREZ;
        [AccessedThroughProperty("textFINPOREZSTOPA")]
        private UltraNumericEditor _textFINPOREZSTOPA;
        [AccessedThroughProperty("textOSNOVICAUKNIZIIRA")]
        private UltraNumericEditor _textOSNOVICAUKNIZIIRA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceFINPOREZ;
        private IContainer components = null;
        private FINPOREZDataSet dsFINPOREZDataSet1;
        protected TableLayoutPanel layoutManagerformFINPOREZ;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private FINPOREZDataSet.FINPOREZRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "FINPOREZ";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.FINPOREZDescription;
        private DeklaritMode m_Mode;

        public FINPOREZFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceFINPOREZ.DataSource = this.FINPOREZController.DataSet;
            this.dsFINPOREZDataSet1 = this.FINPOREZController.DataSet;
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
                    enumerator = this.dsFINPOREZDataSet1.FINPOREZ.Rows.GetEnumerator();
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
                if (this.FINPOREZController.Update(this))
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

        private void FINPOREZFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.FINPOREZDescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "FINPOREZ", this.m_Mode, this.dsFINPOREZDataSet1, this.dsFINPOREZDataSet1.FINPOREZ.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsFINPOREZDataSet1.FINPOREZ[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (FINPOREZDataSet.FINPOREZRow) ((DataRowView) this.bindingSourceFINPOREZ.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(FINPOREZFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceFINPOREZ = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceFINPOREZ).BeginInit();
            this.layoutManagerformFINPOREZ = new TableLayoutPanel();
            this.layoutManagerformFINPOREZ.SuspendLayout();
            this.layoutManagerformFINPOREZ.AutoSize = true;
            this.layoutManagerformFINPOREZ.Dock = DockStyle.Fill;
            this.layoutManagerformFINPOREZ.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformFINPOREZ.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformFINPOREZ.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformFINPOREZ.Size = size;
            this.layoutManagerformFINPOREZ.ColumnCount = 2;
            this.layoutManagerformFINPOREZ.RowCount = 5;
            this.layoutManagerformFINPOREZ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformFINPOREZ.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformFINPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformFINPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformFINPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformFINPOREZ.RowStyles.Add(new RowStyle());
            this.layoutManagerformFINPOREZ.RowStyles.Add(new RowStyle());
            this.label1FINPOREZIDPOREZ = new UltraLabel();
            this.textFINPOREZIDPOREZ = new UltraNumericEditor();
            this.label1FINPOREZNAZIVPOREZ = new UltraLabel();
            this.textFINPOREZNAZIVPOREZ = new UltraTextEditor();
            this.label1FINPOREZSTOPA = new UltraLabel();
            this.textFINPOREZSTOPA = new UltraNumericEditor();
            this.label1OSNOVICAUKNIZIIRA = new UltraLabel();
            this.textOSNOVICAUKNIZIIRA = new UltraNumericEditor();
            ((ISupportInitialize) this.textFINPOREZIDPOREZ).BeginInit();
            ((ISupportInitialize) this.textFINPOREZNAZIVPOREZ).BeginInit();
            ((ISupportInitialize) this.textFINPOREZSTOPA).BeginInit();
            ((ISupportInitialize) this.textOSNOVICAUKNIZIIRA).BeginInit();
            this.dsFINPOREZDataSet1 = new FINPOREZDataSet();
            this.dsFINPOREZDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsFINPOREZDataSet1.DataSetName = "dsFINPOREZ";
            this.dsFINPOREZDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceFINPOREZ.DataSource = this.dsFINPOREZDataSet1;
            this.bindingSourceFINPOREZ.DataMember = "FINPOREZ";
            ((ISupportInitialize) this.bindingSourceFINPOREZ).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1FINPOREZIDPOREZ.Location = point;
            this.label1FINPOREZIDPOREZ.Name = "label1FINPOREZIDPOREZ";
            this.label1FINPOREZIDPOREZ.TabIndex = 1;
            this.label1FINPOREZIDPOREZ.Tag = "labelFINPOREZIDPOREZ";
            this.label1FINPOREZIDPOREZ.Text = "Šifra:";
            this.label1FINPOREZIDPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1FINPOREZIDPOREZ.AutoSize = true;
            this.label1FINPOREZIDPOREZ.Anchor = AnchorStyles.Left;
            this.label1FINPOREZIDPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1FINPOREZIDPOREZ.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1FINPOREZIDPOREZ.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1FINPOREZIDPOREZ.ImageSize = size;
            this.label1FINPOREZIDPOREZ.Appearance.ForeColor = Color.Black;
            this.label1FINPOREZIDPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformFINPOREZ.Controls.Add(this.label1FINPOREZIDPOREZ, 0, 0);
            this.layoutManagerformFINPOREZ.SetColumnSpan(this.label1FINPOREZIDPOREZ, 1);
            this.layoutManagerformFINPOREZ.SetRowSpan(this.label1FINPOREZIDPOREZ, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1FINPOREZIDPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1FINPOREZIDPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1FINPOREZIDPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textFINPOREZIDPOREZ.Location = point;
            this.textFINPOREZIDPOREZ.Name = "textFINPOREZIDPOREZ";
            this.textFINPOREZIDPOREZ.Tag = "FINPOREZIDPOREZ";
            this.textFINPOREZIDPOREZ.TabIndex = 0;
            this.textFINPOREZIDPOREZ.Anchor = AnchorStyles.Left;
            this.textFINPOREZIDPOREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textFINPOREZIDPOREZ.ReadOnly = false;
            this.textFINPOREZIDPOREZ.PromptChar = ' ';
            this.textFINPOREZIDPOREZ.Enter += new EventHandler(this.numericEditor_Enter);
            this.textFINPOREZIDPOREZ.DataBindings.Add(new Binding("Value", this.bindingSourceFINPOREZ, "FINPOREZIDPOREZ"));
            this.textFINPOREZIDPOREZ.NumericType = NumericType.Integer;
            this.textFINPOREZIDPOREZ.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformFINPOREZ.Controls.Add(this.textFINPOREZIDPOREZ, 1, 0);
            this.layoutManagerformFINPOREZ.SetColumnSpan(this.textFINPOREZIDPOREZ, 1);
            this.layoutManagerformFINPOREZ.SetRowSpan(this.textFINPOREZIDPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textFINPOREZIDPOREZ.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textFINPOREZIDPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textFINPOREZIDPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1FINPOREZNAZIVPOREZ.Location = point;
            this.label1FINPOREZNAZIVPOREZ.Name = "label1FINPOREZNAZIVPOREZ";
            this.label1FINPOREZNAZIVPOREZ.TabIndex = 1;
            this.label1FINPOREZNAZIVPOREZ.Tag = "labelFINPOREZNAZIVPOREZ";
            this.label1FINPOREZNAZIVPOREZ.Text = "Naziv:";
            this.label1FINPOREZNAZIVPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1FINPOREZNAZIVPOREZ.AutoSize = true;
            this.label1FINPOREZNAZIVPOREZ.Anchor = AnchorStyles.Left;
            this.label1FINPOREZNAZIVPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1FINPOREZNAZIVPOREZ.Appearance.ForeColor = Color.Black;
            this.label1FINPOREZNAZIVPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformFINPOREZ.Controls.Add(this.label1FINPOREZNAZIVPOREZ, 0, 1);
            this.layoutManagerformFINPOREZ.SetColumnSpan(this.label1FINPOREZNAZIVPOREZ, 1);
            this.layoutManagerformFINPOREZ.SetRowSpan(this.label1FINPOREZNAZIVPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1FINPOREZNAZIVPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1FINPOREZNAZIVPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1FINPOREZNAZIVPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textFINPOREZNAZIVPOREZ.Location = point;
            this.textFINPOREZNAZIVPOREZ.Name = "textFINPOREZNAZIVPOREZ";
            this.textFINPOREZNAZIVPOREZ.Tag = "FINPOREZNAZIVPOREZ";
            this.textFINPOREZNAZIVPOREZ.TabIndex = 0;
            this.textFINPOREZNAZIVPOREZ.Anchor = AnchorStyles.Left;
            this.textFINPOREZNAZIVPOREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textFINPOREZNAZIVPOREZ.ReadOnly = false;
            this.textFINPOREZNAZIVPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourceFINPOREZ, "FINPOREZNAZIVPOREZ"));
            this.textFINPOREZNAZIVPOREZ.MaxLength = 30;
            this.layoutManagerformFINPOREZ.Controls.Add(this.textFINPOREZNAZIVPOREZ, 1, 1);
            this.layoutManagerformFINPOREZ.SetColumnSpan(this.textFINPOREZNAZIVPOREZ, 1);
            this.layoutManagerformFINPOREZ.SetRowSpan(this.textFINPOREZNAZIVPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textFINPOREZNAZIVPOREZ.Margin = padding;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textFINPOREZNAZIVPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textFINPOREZNAZIVPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1FINPOREZSTOPA.Location = point;
            this.label1FINPOREZSTOPA.Name = "label1FINPOREZSTOPA";
            this.label1FINPOREZSTOPA.TabIndex = 1;
            this.label1FINPOREZSTOPA.Tag = "labelFINPOREZSTOPA";
            this.label1FINPOREZSTOPA.Text = "Stopa:";
            this.label1FINPOREZSTOPA.StyleSetName = "FieldUltraLabel";
            this.label1FINPOREZSTOPA.AutoSize = true;
            this.label1FINPOREZSTOPA.Anchor = AnchorStyles.Left;
            this.label1FINPOREZSTOPA.Appearance.TextVAlign = VAlign.Middle;
            this.label1FINPOREZSTOPA.Appearance.ForeColor = Color.Black;
            this.label1FINPOREZSTOPA.BackColor = Color.Transparent;
            this.layoutManagerformFINPOREZ.Controls.Add(this.label1FINPOREZSTOPA, 0, 2);
            this.layoutManagerformFINPOREZ.SetColumnSpan(this.label1FINPOREZSTOPA, 1);
            this.layoutManagerformFINPOREZ.SetRowSpan(this.label1FINPOREZSTOPA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1FINPOREZSTOPA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1FINPOREZSTOPA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x17);
            this.label1FINPOREZSTOPA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textFINPOREZSTOPA.Location = point;
            this.textFINPOREZSTOPA.Name = "textFINPOREZSTOPA";
            this.textFINPOREZSTOPA.Tag = "FINPOREZSTOPA";
            this.textFINPOREZSTOPA.TabIndex = 0;
            this.textFINPOREZSTOPA.Anchor = AnchorStyles.Left;
            this.textFINPOREZSTOPA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textFINPOREZSTOPA.ReadOnly = false;
            this.textFINPOREZSTOPA.PromptChar = ' ';
            this.textFINPOREZSTOPA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textFINPOREZSTOPA.DataBindings.Add(new Binding("Value", this.bindingSourceFINPOREZ, "FINPOREZSTOPA"));
            this.textFINPOREZSTOPA.NumericType = NumericType.Double;
            this.textFINPOREZSTOPA.MaxValue = 79228162514264337593543950335M;
            this.textFINPOREZSTOPA.MinValue = -79228162514264337593543950335M;
            this.textFINPOREZSTOPA.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformFINPOREZ.Controls.Add(this.textFINPOREZSTOPA, 1, 2);
            this.layoutManagerformFINPOREZ.SetColumnSpan(this.textFINPOREZSTOPA, 1);
            this.layoutManagerformFINPOREZ.SetRowSpan(this.textFINPOREZSTOPA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textFINPOREZSTOPA.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textFINPOREZSTOPA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textFINPOREZSTOPA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OSNOVICAUKNIZIIRA.Location = point;
            this.label1OSNOVICAUKNIZIIRA.Name = "label1OSNOVICAUKNIZIIRA";
            this.label1OSNOVICAUKNIZIIRA.TabIndex = 1;
            this.label1OSNOVICAUKNIZIIRA.Tag = "labelOSNOVICAUKNIZIIRA";
            this.label1OSNOVICAUKNIZIIRA.Text = "Osnovica iz Knjige IRA:";
            this.label1OSNOVICAUKNIZIIRA.StyleSetName = "FieldUltraLabel";
            this.label1OSNOVICAUKNIZIIRA.AutoSize = true;
            this.label1OSNOVICAUKNIZIIRA.Anchor = AnchorStyles.Left;
            this.label1OSNOVICAUKNIZIIRA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OSNOVICAUKNIZIIRA.Appearance.ForeColor = Color.Black;
            this.label1OSNOVICAUKNIZIIRA.BackColor = Color.Transparent;
            this.layoutManagerformFINPOREZ.Controls.Add(this.label1OSNOVICAUKNIZIIRA, 0, 3);
            this.layoutManagerformFINPOREZ.SetColumnSpan(this.label1OSNOVICAUKNIZIIRA, 1);
            this.layoutManagerformFINPOREZ.SetRowSpan(this.label1OSNOVICAUKNIZIIRA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OSNOVICAUKNIZIIRA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OSNOVICAUKNIZIIRA.MinimumSize = size;
            size = new System.Drawing.Size(160, 0x17);
            this.label1OSNOVICAUKNIZIIRA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOSNOVICAUKNIZIIRA.Location = point;
            this.textOSNOVICAUKNIZIIRA.Name = "textOSNOVICAUKNIZIIRA";
            this.textOSNOVICAUKNIZIIRA.Tag = "OSNOVICAUKNIZIIRA";
            this.textOSNOVICAUKNIZIIRA.TabIndex = 0;
            this.textOSNOVICAUKNIZIIRA.Anchor = AnchorStyles.Left;
            this.textOSNOVICAUKNIZIIRA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOSNOVICAUKNIZIIRA.ReadOnly = false;
            this.textOSNOVICAUKNIZIIRA.PromptChar = ' ';
            this.textOSNOVICAUKNIZIIRA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOSNOVICAUKNIZIIRA.DataBindings.Add(new Binding("Value", this.bindingSourceFINPOREZ, "OSNOVICAUKNIZIIRA"));
            this.textOSNOVICAUKNIZIIRA.NumericType = NumericType.Integer;
            this.textOSNOVICAUKNIZIIRA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformFINPOREZ.Controls.Add(this.textOSNOVICAUKNIZIIRA, 1, 3);
            this.layoutManagerformFINPOREZ.SetColumnSpan(this.textOSNOVICAUKNIZIIRA, 1);
            this.layoutManagerformFINPOREZ.SetRowSpan(this.textOSNOVICAUKNIZIIRA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOSNOVICAUKNIZIIRA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textOSNOVICAUKNIZIIRA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textOSNOVICAUKNIZIIRA.Size = size;
            this.Controls.Add(this.layoutManagerformFINPOREZ);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceFINPOREZ;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "FINPOREZFormUserControl";
            this.Text = "FINPOREZ";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.FINPOREZFormUserControl_Load);
            this.layoutManagerformFINPOREZ.ResumeLayout(false);
            this.layoutManagerformFINPOREZ.PerformLayout();
            ((ISupportInitialize) this.bindingSourceFINPOREZ).EndInit();
            ((ISupportInitialize) this.textFINPOREZIDPOREZ).EndInit();
            ((ISupportInitialize) this.textFINPOREZNAZIVPOREZ).EndInit();
            ((ISupportInitialize) this.textFINPOREZSTOPA).EndInit();
            ((ISupportInitialize) this.textOSNOVICAUKNIZIIRA).EndInit();
            this.dsFINPOREZDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.FINPOREZController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceFINPOREZ, this.FINPOREZController.WorkItem, this))
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
            this.label1FINPOREZIDPOREZ.Text = StringResources.FINPOREZFINPOREZIDPOREZDescription;
            this.label1FINPOREZNAZIVPOREZ.Text = StringResources.FINPOREZFINPOREZNAZIVPOREZDescription;
            this.label1FINPOREZSTOPA.Text = StringResources.FINPOREZFINPOREZSTOPADescription;
            this.label1OSNOVICAUKNIZIIRA.Text = StringResources.FINPOREZOSNOVICAUKNIZIIRADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewPROIZVOD")]
        public void NewPROIZVODHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.FINPOREZController.NewPROIZVOD(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.FINPOREZController.WorkItem.Items.Contains("FINPOREZ|FINPOREZ"))
            {
                this.FINPOREZController.WorkItem.Items.Add(this.bindingSourceFINPOREZ, "FINPOREZ|FINPOREZ");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsFINPOREZDataSet1.FINPOREZ.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.FINPOREZController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.FINPOREZController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.FINPOREZController.Update(this))
            {
                this.FINPOREZController.DataSet = new FINPOREZDataSet();
                DataSetUtil.AddEmptyRow(this.FINPOREZController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.FINPOREZController.DataSet.FINPOREZ[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textFINPOREZIDPOREZ.Focus();
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

        [LocalCommandHandler("ViewPROIZVOD")]
        public void ViewPROIZVODHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.FINPOREZController.ViewPROIZVOD(this.m_CurrentRow);
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.FINPOREZController FINPOREZController { get; set; }

        protected virtual UltraLabel label1FINPOREZIDPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1FINPOREZIDPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1FINPOREZIDPOREZ = value;
            }
        }

        protected virtual UltraLabel label1FINPOREZNAZIVPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1FINPOREZNAZIVPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1FINPOREZNAZIVPOREZ = value;
            }
        }

        protected virtual UltraLabel label1FINPOREZSTOPA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1FINPOREZSTOPA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1FINPOREZSTOPA = value;
            }
        }

        protected virtual UltraLabel label1OSNOVICAUKNIZIIRA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OSNOVICAUKNIZIIRA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OSNOVICAUKNIZIIRA = value;
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

        protected virtual UltraNumericEditor textFINPOREZIDPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textFINPOREZIDPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textFINPOREZIDPOREZ = value;
            }
        }

        protected virtual UltraTextEditor textFINPOREZNAZIVPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textFINPOREZNAZIVPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textFINPOREZNAZIVPOREZ = value;
            }
        }

        protected virtual UltraNumericEditor textFINPOREZSTOPA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textFINPOREZSTOPA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textFINPOREZSTOPA = value;
            }
        }

        protected virtual UltraNumericEditor textOSNOVICAUKNIZIIRA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOSNOVICAUKNIZIIRA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOSNOVICAUKNIZIIRA = value;
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

