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
    public class SMJENEFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDSMJENE")]
        private UltraLabel _label1IDSMJENE;
        [AccessedThroughProperty("label1OPISSMJENE")]
        private UltraLabel _label1OPISSMJENE;
        [AccessedThroughProperty("label1POCETAK")]
        private UltraLabel _label1POCETAK;
        [AccessedThroughProperty("label1ZAVRSETAK")]
        private UltraLabel _label1ZAVRSETAK;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDSMJENE")]
        private UltraNumericEditor _textIDSMJENE;
        [AccessedThroughProperty("textOPISSMJENE")]
        private UltraTextEditor _textOPISSMJENE;
        [AccessedThroughProperty("textPOCETAK")]
        private UltraTextEditor _textPOCETAK;
        [AccessedThroughProperty("textZAVRSETAK")]
        private UltraTextEditor _textZAVRSETAK;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSMJENE;
        private IContainer components = null;
        private SMJENEDataSet dsSMJENEDataSet1;
        protected TableLayoutPanel layoutManagerformSMJENE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SMJENEDataSet.SMJENERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SMJENE";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.SMJENEDescription;
        private DeklaritMode m_Mode;

        public SMJENEFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceSMJENE.DataSource = this.SMJENEController.DataSet;
            this.dsSMJENEDataSet1 = this.SMJENEController.DataSet;
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
                    enumerator = this.dsSMJENEDataSet1.SMJENE.Rows.GetEnumerator();
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
                if (this.SMJENEController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SMJENE", this.m_Mode, this.dsSMJENEDataSet1, this.dsSMJENEDataSet1.SMJENE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsSMJENEDataSet1.SMJENE[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (SMJENEDataSet.SMJENERow) ((DataRowView) this.bindingSourceSMJENE.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(SMJENEFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSMJENE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSMJENE).BeginInit();
            this.layoutManagerformSMJENE = new TableLayoutPanel();
            this.layoutManagerformSMJENE.SuspendLayout();
            this.layoutManagerformSMJENE.AutoSize = true;
            this.layoutManagerformSMJENE.Dock = DockStyle.Fill;
            this.layoutManagerformSMJENE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSMJENE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSMJENE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSMJENE.Size = size;
            this.layoutManagerformSMJENE.ColumnCount = 2;
            this.layoutManagerformSMJENE.RowCount = 4;
            this.layoutManagerformSMJENE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSMJENE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSMJENE.RowStyles.Add(new RowStyle());
            this.layoutManagerformSMJENE.RowStyles.Add(new RowStyle());
            this.layoutManagerformSMJENE.RowStyles.Add(new RowStyle());
            this.layoutManagerformSMJENE.RowStyles.Add(new RowStyle());
            this.label1IDSMJENE = new UltraLabel();
            this.textIDSMJENE = new UltraNumericEditor();
            this.label1OPISSMJENE = new UltraLabel();
            this.textOPISSMJENE = new UltraTextEditor();
            this.label1POCETAK = new UltraLabel();
            this.textPOCETAK = new UltraTextEditor();
            this.label1ZAVRSETAK = new UltraLabel();
            this.textZAVRSETAK = new UltraTextEditor();
            ((ISupportInitialize) this.textIDSMJENE).BeginInit();
            ((ISupportInitialize) this.textOPISSMJENE).BeginInit();
            ((ISupportInitialize) this.textPOCETAK).BeginInit();
            ((ISupportInitialize) this.textZAVRSETAK).BeginInit();
            this.dsSMJENEDataSet1 = new SMJENEDataSet();
            this.dsSMJENEDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSMJENEDataSet1.DataSetName = "dsSMJENE";
            this.dsSMJENEDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSMJENE.DataSource = this.dsSMJENEDataSet1;
            this.bindingSourceSMJENE.DataMember = "SMJENE";
            ((ISupportInitialize) this.bindingSourceSMJENE).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDSMJENE.Location = point;
            this.label1IDSMJENE.Name = "label1IDSMJENE";
            this.label1IDSMJENE.TabIndex = 1;
            this.label1IDSMJENE.Tag = "labelIDSMJENE";
            this.label1IDSMJENE.Text = "Šifra:";
            this.label1IDSMJENE.StyleSetName = "FieldUltraLabel";
            this.label1IDSMJENE.AutoSize = true;
            this.label1IDSMJENE.Anchor = AnchorStyles.Left;
            this.label1IDSMJENE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDSMJENE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDSMJENE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDSMJENE.ImageSize = size;
            this.label1IDSMJENE.Appearance.ForeColor = Color.Black;
            this.label1IDSMJENE.BackColor = Color.Transparent;
            this.layoutManagerformSMJENE.Controls.Add(this.label1IDSMJENE, 0, 0);
            this.layoutManagerformSMJENE.SetColumnSpan(this.label1IDSMJENE, 1);
            this.layoutManagerformSMJENE.SetRowSpan(this.label1IDSMJENE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDSMJENE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDSMJENE.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDSMJENE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDSMJENE.Location = point;
            this.textIDSMJENE.Name = "textIDSMJENE";
            this.textIDSMJENE.Tag = "IDSMJENE";
            this.textIDSMJENE.TabIndex = 0;
            this.textIDSMJENE.Anchor = AnchorStyles.Left;
            this.textIDSMJENE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDSMJENE.ReadOnly = false;
            this.textIDSMJENE.PromptChar = ' ';
            this.textIDSMJENE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDSMJENE.DataBindings.Add(new Binding("Value", this.bindingSourceSMJENE, "IDSMJENE"));
            this.textIDSMJENE.NumericType = NumericType.Integer;
            this.textIDSMJENE.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformSMJENE.Controls.Add(this.textIDSMJENE, 1, 0);
            this.layoutManagerformSMJENE.SetColumnSpan(this.textIDSMJENE, 1);
            this.layoutManagerformSMJENE.SetRowSpan(this.textIDSMJENE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDSMJENE.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSMJENE.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSMJENE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISSMJENE.Location = point;
            this.label1OPISSMJENE.Name = "label1OPISSMJENE";
            this.label1OPISSMJENE.TabIndex = 1;
            this.label1OPISSMJENE.Tag = "labelOPISSMJENE";
            this.label1OPISSMJENE.Text = "Opis:";
            this.label1OPISSMJENE.StyleSetName = "FieldUltraLabel";
            this.label1OPISSMJENE.AutoSize = true;
            this.label1OPISSMJENE.Anchor = AnchorStyles.Left;
            this.label1OPISSMJENE.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISSMJENE.Appearance.ForeColor = Color.Black;
            this.label1OPISSMJENE.BackColor = Color.Transparent;
            this.layoutManagerformSMJENE.Controls.Add(this.label1OPISSMJENE, 0, 1);
            this.layoutManagerformSMJENE.SetColumnSpan(this.label1OPISSMJENE, 1);
            this.layoutManagerformSMJENE.SetRowSpan(this.label1OPISSMJENE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISSMJENE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISSMJENE.MinimumSize = size;
            size = new System.Drawing.Size(0x2e, 0x17);
            this.label1OPISSMJENE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPISSMJENE.Location = point;
            this.textOPISSMJENE.Name = "textOPISSMJENE";
            this.textOPISSMJENE.Tag = "OPISSMJENE";
            this.textOPISSMJENE.TabIndex = 0;
            this.textOPISSMJENE.Anchor = AnchorStyles.Left;
            this.textOPISSMJENE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPISSMJENE.ReadOnly = false;
            this.textOPISSMJENE.DataBindings.Add(new Binding("Text", this.bindingSourceSMJENE, "OPISSMJENE"));
            this.textOPISSMJENE.MaxLength = 50;
            this.layoutManagerformSMJENE.Controls.Add(this.textOPISSMJENE, 1, 1);
            this.layoutManagerformSMJENE.SetColumnSpan(this.textOPISSMJENE, 1);
            this.layoutManagerformSMJENE.SetRowSpan(this.textOPISSMJENE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPISSMJENE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textOPISSMJENE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textOPISSMJENE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POCETAK.Location = point;
            this.label1POCETAK.Name = "label1POCETAK";
            this.label1POCETAK.TabIndex = 1;
            this.label1POCETAK.Tag = "labelPOCETAK";
            this.label1POCETAK.Text = "Početak rada:";
            this.label1POCETAK.StyleSetName = "FieldUltraLabel";
            this.label1POCETAK.AutoSize = true;
            this.label1POCETAK.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1POCETAK.Appearance.TextVAlign = VAlign.Middle;
            this.label1POCETAK.Appearance.ForeColor = Color.Black;
            this.label1POCETAK.BackColor = Color.Transparent;
            this.layoutManagerformSMJENE.Controls.Add(this.label1POCETAK, 0, 2);
            this.layoutManagerformSMJENE.SetColumnSpan(this.label1POCETAK, 1);
            this.layoutManagerformSMJENE.SetRowSpan(this.label1POCETAK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POCETAK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POCETAK.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x17);
            this.label1POCETAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOCETAK.Location = point;
            this.textPOCETAK.Name = "textPOCETAK";
            this.textPOCETAK.Tag = "POCETAK";
            this.textPOCETAK.TabIndex = 0;
            this.textPOCETAK.Anchor = AnchorStyles.Left;
            this.textPOCETAK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOCETAK.ReadOnly = false;
            this.textPOCETAK.DataBindings.Add(new Binding("Text", this.bindingSourceSMJENE, "POCETAK"));
            this.textPOCETAK.Multiline = true;
            this.layoutManagerformSMJENE.Controls.Add(this.textPOCETAK, 1, 2);
            this.layoutManagerformSMJENE.SetColumnSpan(this.textPOCETAK, 1);
            this.layoutManagerformSMJENE.SetRowSpan(this.textPOCETAK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOCETAK.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x58);
            this.textPOCETAK.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x58);
            this.textPOCETAK.Size = size;
            this.textPOCETAK.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.label1ZAVRSETAK.Location = point;
            this.label1ZAVRSETAK.Name = "label1ZAVRSETAK";
            this.label1ZAVRSETAK.TabIndex = 1;
            this.label1ZAVRSETAK.Tag = "labelZAVRSETAK";
            this.label1ZAVRSETAK.Text = "Završetak rada:";
            this.label1ZAVRSETAK.StyleSetName = "FieldUltraLabel";
            this.label1ZAVRSETAK.AutoSize = true;
            this.label1ZAVRSETAK.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ZAVRSETAK.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZAVRSETAK.Appearance.ForeColor = Color.Black;
            this.label1ZAVRSETAK.BackColor = Color.Transparent;
            this.layoutManagerformSMJENE.Controls.Add(this.label1ZAVRSETAK, 0, 3);
            this.layoutManagerformSMJENE.SetColumnSpan(this.label1ZAVRSETAK, 1);
            this.layoutManagerformSMJENE.SetRowSpan(this.label1ZAVRSETAK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZAVRSETAK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZAVRSETAK.MinimumSize = size;
            size = new System.Drawing.Size(0x70, 0x17);
            this.label1ZAVRSETAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZAVRSETAK.Location = point;
            this.textZAVRSETAK.Name = "textZAVRSETAK";
            this.textZAVRSETAK.Tag = "ZAVRSETAK";
            this.textZAVRSETAK.TabIndex = 0;
            this.textZAVRSETAK.Anchor = AnchorStyles.Left;
            this.textZAVRSETAK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZAVRSETAK.ReadOnly = false;
            this.textZAVRSETAK.DataBindings.Add(new Binding("Text", this.bindingSourceSMJENE, "ZAVRSETAK"));
            this.textZAVRSETAK.Multiline = true;
            this.layoutManagerformSMJENE.Controls.Add(this.textZAVRSETAK, 1, 3);
            this.layoutManagerformSMJENE.SetColumnSpan(this.textZAVRSETAK, 1);
            this.layoutManagerformSMJENE.SetRowSpan(this.textZAVRSETAK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZAVRSETAK.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x58);
            this.textZAVRSETAK.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x58);
            this.textZAVRSETAK.Size = size;
            this.textZAVRSETAK.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformSMJENE);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSMJENE;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "SMJENEFormUserControl";
            this.Text = "SMJENE";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SMJENEFormUserControl_Load);
            this.layoutManagerformSMJENE.ResumeLayout(false);
            this.layoutManagerformSMJENE.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSMJENE).EndInit();
            ((ISupportInitialize) this.textIDSMJENE).EndInit();
            ((ISupportInitialize) this.textOPISSMJENE).EndInit();
            ((ISupportInitialize) this.textPOCETAK).EndInit();
            ((ISupportInitialize) this.textZAVRSETAK).EndInit();
            this.dsSMJENEDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.SMJENEController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSMJENE, this.SMJENEController.WorkItem, this))
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
            this.label1IDSMJENE.Text = StringResources.SMJENEIDSMJENEDescription;
            this.label1OPISSMJENE.Text = StringResources.SMJENEOPISSMJENEDescription;
            this.label1POCETAK.Text = StringResources.SMJENEPOCETAKDescription;
            this.label1ZAVRSETAK.Text = StringResources.SMJENEZAVRSETAKDescription;
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
            if (!this.SMJENEController.WorkItem.Items.Contains("SMJENE|SMJENE"))
            {
                this.SMJENEController.WorkItem.Items.Add(this.bindingSourceSMJENE, "SMJENE|SMJENE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsSMJENEDataSet1.SMJENE.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.SMJENEController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.SMJENEController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.SMJENEController.Update(this))
            {
                this.SMJENEController.DataSet = new SMJENEDataSet();
                DataSetUtil.AddEmptyRow(this.SMJENEController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.SMJENEController.DataSet.SMJENE[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDSMJENE.Focus();
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

        private void SMJENEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.SMJENEDescription;
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

        protected virtual UltraLabel label1IDSMJENE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDSMJENE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDSMJENE = value;
            }
        }

        protected virtual UltraLabel label1OPISSMJENE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISSMJENE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISSMJENE = value;
            }
        }

        protected virtual UltraLabel label1POCETAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POCETAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POCETAK = value;
            }
        }

        protected virtual UltraLabel label1ZAVRSETAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZAVRSETAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZAVRSETAK = value;
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.SMJENEController SMJENEController { get; set; }

        protected virtual UltraNumericEditor textIDSMJENE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDSMJENE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDSMJENE = value;
            }
        }

        protected virtual UltraTextEditor textOPISSMJENE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPISSMJENE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPISSMJENE = value;
            }
        }

        protected virtual UltraTextEditor textPOCETAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOCETAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOCETAK = value;
            }
        }

        protected virtual UltraTextEditor textZAVRSETAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZAVRSETAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZAVRSETAK = value;
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

