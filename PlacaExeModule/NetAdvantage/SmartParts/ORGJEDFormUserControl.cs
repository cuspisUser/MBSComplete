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
    public class ORGJEDFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDORGJED")]
        private UltraLabel _label1IDORGJED;
        [AccessedThroughProperty("label1NAZIVORGJED")]
        private UltraLabel _label1NAZIVORGJED;
        [AccessedThroughProperty("label1oj")]
        private UltraLabel _label1oj;
        [AccessedThroughProperty("labeloj")]
        private UltraLabel _labeloj;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDORGJED")]
        private UltraNumericEditor _textIDORGJED;
        [AccessedThroughProperty("textNAZIVORGJED")]
        private UltraTextEditor _textNAZIVORGJED;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceORGJED;
        private IContainer components = null;
        private ORGJEDDataSet dsORGJEDDataSet1;
        protected TableLayoutPanel layoutManagerformORGJED;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private ORGJEDDataSet.ORGJEDRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "ORGJED";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.ORGJEDDescription;
        private DeklaritMode m_Mode;

        public ORGJEDFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceORGJED.DataSource = this.ORGJEDController.DataSet;
            this.dsORGJEDDataSet1 = this.ORGJEDController.DataSet;
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
                    enumerator = this.dsORGJEDDataSet1.ORGJED.Rows.GetEnumerator();
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
                if (this.ORGJEDController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "ORGJED", this.m_Mode, this.dsORGJEDDataSet1, this.dsORGJEDDataSet1.ORGJED.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsORGJEDDataSet1.ORGJED[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (ORGJEDDataSet.ORGJEDRow) ((DataRowView) this.bindingSourceORGJED.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(ORGJEDFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceORGJED = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceORGJED).BeginInit();
            this.layoutManagerformORGJED = new TableLayoutPanel();
            this.layoutManagerformORGJED.SuspendLayout();
            this.layoutManagerformORGJED.AutoSize = true;
            this.layoutManagerformORGJED.Dock = DockStyle.Fill;
            this.layoutManagerformORGJED.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformORGJED.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformORGJED.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformORGJED.Size = size;
            this.layoutManagerformORGJED.ColumnCount = 2;
            this.layoutManagerformORGJED.RowCount = 3;
            this.layoutManagerformORGJED.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformORGJED.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformORGJED.RowStyles.Add(new RowStyle());
            this.layoutManagerformORGJED.RowStyles.Add(new RowStyle());
            this.layoutManagerformORGJED.RowStyles.Add(new RowStyle());
            this.label1IDORGJED = new UltraLabel();
            this.textIDORGJED = new UltraNumericEditor();
            this.label1NAZIVORGJED = new UltraLabel();
            this.textNAZIVORGJED = new UltraTextEditor();
            this.label1oj = new UltraLabel();
            this.labeloj = new UltraLabel();
            ((ISupportInitialize) this.textIDORGJED).BeginInit();
            ((ISupportInitialize) this.textNAZIVORGJED).BeginInit();
            this.dsORGJEDDataSet1 = new ORGJEDDataSet();
            this.dsORGJEDDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsORGJEDDataSet1.DataSetName = "dsORGJED";
            this.dsORGJEDDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceORGJED.DataSource = this.dsORGJEDDataSet1;
            this.bindingSourceORGJED.DataMember = "ORGJED";
            ((ISupportInitialize) this.bindingSourceORGJED).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDORGJED.Location = point;
            this.label1IDORGJED.Name = "label1IDORGJED";
            this.label1IDORGJED.TabIndex = 1;
            this.label1IDORGJED.Tag = "labelIDORGJED";
            this.label1IDORGJED.Text = "Šifra OJ:";
            this.label1IDORGJED.StyleSetName = "FieldUltraLabel";
            this.label1IDORGJED.AutoSize = true;
            this.label1IDORGJED.Anchor = AnchorStyles.Left;
            this.label1IDORGJED.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDORGJED.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDORGJED.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDORGJED.ImageSize = size;
            this.label1IDORGJED.Appearance.ForeColor = Color.Black;
            this.label1IDORGJED.BackColor = Color.Transparent;
            this.layoutManagerformORGJED.Controls.Add(this.label1IDORGJED, 0, 0);
            this.layoutManagerformORGJED.SetColumnSpan(this.label1IDORGJED, 1);
            this.layoutManagerformORGJED.SetRowSpan(this.label1IDORGJED, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDORGJED.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x40, 0x17);
            this.label1IDORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDORGJED.Location = point;
            this.textIDORGJED.Name = "textIDORGJED";
            this.textIDORGJED.Tag = "IDORGJED";
            this.textIDORGJED.TabIndex = 0;
            this.textIDORGJED.Anchor = AnchorStyles.Left;
            this.textIDORGJED.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDORGJED.ReadOnly = false;
            this.textIDORGJED.PromptChar = ' ';
            this.textIDORGJED.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDORGJED.DataBindings.Add(new Binding("Value", this.bindingSourceORGJED, "IDORGJED"));
            this.textIDORGJED.NumericType = NumericType.Integer;
            this.textIDORGJED.MaskInput = "{LOC}-nnnnnnnn";
            this.layoutManagerformORGJED.Controls.Add(this.textIDORGJED, 1, 0);
            this.layoutManagerformORGJED.SetColumnSpan(this.textIDORGJED, 1);
            this.layoutManagerformORGJED.SetRowSpan(this.textIDORGJED, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDORGJED.Margin = padding;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x48, 0x16);
            this.textIDORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVORGJED.Location = point;
            this.label1NAZIVORGJED.Name = "label1NAZIVORGJED";
            this.label1NAZIVORGJED.TabIndex = 1;
            this.label1NAZIVORGJED.Tag = "labelNAZIVORGJED";
            this.label1NAZIVORGJED.Text = "Naziv OJ:";
            this.label1NAZIVORGJED.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVORGJED.AutoSize = true;
            this.label1NAZIVORGJED.Anchor = AnchorStyles.Left;
            this.label1NAZIVORGJED.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVORGJED.Appearance.ForeColor = Color.Black;
            this.label1NAZIVORGJED.BackColor = Color.Transparent;
            this.layoutManagerformORGJED.Controls.Add(this.label1NAZIVORGJED, 0, 1);
            this.layoutManagerformORGJED.SetColumnSpan(this.label1NAZIVORGJED, 1);
            this.layoutManagerformORGJED.SetRowSpan(this.label1NAZIVORGJED, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVORGJED.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x49, 0x17);
            this.label1NAZIVORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVORGJED.Location = point;
            this.textNAZIVORGJED.Name = "textNAZIVORGJED";
            this.textNAZIVORGJED.Tag = "NAZIVORGJED";
            this.textNAZIVORGJED.TabIndex = 0;
            this.textNAZIVORGJED.Anchor = AnchorStyles.Left;
            this.textNAZIVORGJED.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVORGJED.ReadOnly = false;
            this.textNAZIVORGJED.DataBindings.Add(new Binding("Text", this.bindingSourceORGJED, "NAZIVORGJED"));
            this.textNAZIVORGJED.MaxLength = 100;
            this.layoutManagerformORGJED.Controls.Add(this.textNAZIVORGJED, 1, 1);
            this.layoutManagerformORGJED.SetColumnSpan(this.textNAZIVORGJED, 1);
            this.layoutManagerformORGJED.SetRowSpan(this.textNAZIVORGJED, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVORGJED.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1oj.Location = point;
            this.label1oj.Name = "label1oj";
            this.label1oj.TabIndex = 1;
            this.label1oj.Tag = "labeloj";
            this.label1oj.Text = "oj:";
            this.label1oj.StyleSetName = "FieldUltraLabel";
            this.label1oj.AutoSize = true;
            this.label1oj.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1oj.Appearance.TextVAlign = VAlign.Middle;
            this.label1oj.Appearance.ForeColor = Color.Black;
            this.label1oj.BackColor = Color.Transparent;
            this.layoutManagerformORGJED.Controls.Add(this.label1oj, 0, 2);
            this.layoutManagerformORGJED.SetColumnSpan(this.label1oj, 1);
            this.layoutManagerformORGJED.SetRowSpan(this.label1oj, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1oj.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1oj.MinimumSize = size;
            size = new System.Drawing.Size(0x1f, 0x17);
            this.label1oj.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labeloj.Location = point;
            this.labeloj.Name = "labeloj";
            this.labeloj.Tag = "oj";
            this.labeloj.TabIndex = 0;
            this.labeloj.Anchor = AnchorStyles.Left;
            this.labeloj.BackColor = Color.Transparent;
            this.labeloj.DataBindings.Add(new Binding("Text", this.bindingSourceORGJED, "oj"));
            this.labeloj.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformORGJED.Controls.Add(this.labeloj, 1, 2);
            this.layoutManagerformORGJED.SetColumnSpan(this.labeloj, 1);
            this.layoutManagerformORGJED.SetRowSpan(this.labeloj, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labeloj.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.labeloj.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.labeloj.Size = size;
            this.labeloj.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformORGJED);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceORGJED;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "ORGJEDFormUserControl";
            this.Text = "Organizacijske jedinice";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.ORGJEDFormUserControl_Load);
            this.layoutManagerformORGJED.ResumeLayout(false);
            this.layoutManagerformORGJED.PerformLayout();
            ((ISupportInitialize) this.bindingSourceORGJED).EndInit();
            ((ISupportInitialize) this.textIDORGJED).EndInit();
            ((ISupportInitialize) this.textNAZIVORGJED).EndInit();
            this.dsORGJEDDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.ORGJEDController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceORGJED, this.ORGJEDController.WorkItem, this))
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
            this.label1IDORGJED.Text = StringResources.ORGJEDIDORGJEDDescription;
            this.label1NAZIVORGJED.Text = StringResources.ORGJEDNAZIVORGJEDDescription;
            this.label1oj.Text = StringResources.ORGJEDojDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewGKSTAVKA")]
        public void NewGKSTAVKAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ORGJEDController.NewGKSTAVKA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewSHEMADD")]
        public void NewSHEMADDHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ORGJEDController.NewSHEMADD(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewSHEMAPLACA")]
        public void NewSHEMAPLACAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ORGJEDController.NewSHEMAPLACA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void ORGJEDFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.ORGJEDDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.ORGJEDController.WorkItem.Items.Contains("ORGJED|ORGJED"))
            {
                this.ORGJEDController.WorkItem.Items.Add(this.bindingSourceORGJED, "ORGJED|ORGJED");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsORGJEDDataSet1.ORGJED.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.ORGJEDController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.ORGJEDController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.ORGJEDController.Update(this))
            {
                this.ORGJEDController.DataSet = new ORGJEDDataSet();
                DataSetUtil.AddEmptyRow(this.ORGJEDController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.ORGJEDController.DataSet.ORGJED[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDORGJED.Focus();
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

        [LocalCommandHandler("ViewGKSTAVKA")]
        public void ViewGKSTAVKAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ORGJEDController.ViewGKSTAVKA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewSHEMADD")]
        public void ViewSHEMADDHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ORGJEDController.ViewSHEMADD(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewSHEMAPLACA")]
        public void ViewSHEMAPLACAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ORGJEDController.ViewSHEMAPLACA(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDORGJED = value;
            }
        }

        protected virtual UltraLabel label1NAZIVORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVORGJED = value;
            }
        }

        protected virtual UltraLabel label1oj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1oj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1oj = value;
            }
        }

        protected virtual UltraLabel labeloj
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labeloj;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labeloj = value;
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
        public NetAdvantage.Controllers.ORGJEDController ORGJEDController { get; set; }

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

        protected virtual UltraNumericEditor textIDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDORGJED = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVORGJED = value;
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

