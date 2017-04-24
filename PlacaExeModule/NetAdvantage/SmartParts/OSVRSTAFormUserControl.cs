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
    public class OSVRSTAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDOSVRSTA")]
        private UltraLabel _label1IDOSVRSTA;
        [AccessedThroughProperty("label1OPISOSVRSTA")]
        private UltraLabel _label1OPISOSVRSTA;
        [AccessedThroughProperty("label1OSV")]
        private UltraLabel _label1OSV;
        [AccessedThroughProperty("labelOSV")]
        private UltraLabel _labelOSV;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDOSVRSTA")]
        private UltraNumericEditor _textIDOSVRSTA;
        [AccessedThroughProperty("textOPISOSVRSTA")]
        private UltraTextEditor _textOPISOSVRSTA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceOSVRSTA;
        private IContainer components = null;
        private OSVRSTADataSet dsOSVRSTADataSet1;
        protected TableLayoutPanel layoutManagerformOSVRSTA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OSVRSTADataSet.OSVRSTARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "OSVRSTA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.OSVRSTADescription;
        private DeklaritMode m_Mode;

        public OSVRSTAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceOSVRSTA.DataSource = this.OSVRSTAController.DataSet;
            this.dsOSVRSTADataSet1 = this.OSVRSTAController.DataSet;
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
                    enumerator = this.dsOSVRSTADataSet1.OSVRSTA.Rows.GetEnumerator();
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
                if (this.OSVRSTAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OSVRSTA", this.m_Mode, this.dsOSVRSTADataSet1, this.dsOSVRSTADataSet1.OSVRSTA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsOSVRSTADataSet1.OSVRSTA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (OSVRSTADataSet.OSVRSTARow) ((DataRowView) this.bindingSourceOSVRSTA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(OSVRSTAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceOSVRSTA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOSVRSTA).BeginInit();
            this.layoutManagerformOSVRSTA = new TableLayoutPanel();
            this.layoutManagerformOSVRSTA.SuspendLayout();
            this.layoutManagerformOSVRSTA.AutoSize = true;
            this.layoutManagerformOSVRSTA.Dock = DockStyle.Fill;
            this.layoutManagerformOSVRSTA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformOSVRSTA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformOSVRSTA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformOSVRSTA.Size = size;
            this.layoutManagerformOSVRSTA.ColumnCount = 2;
            this.layoutManagerformOSVRSTA.RowCount = 4;
            this.layoutManagerformOSVRSTA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOSVRSTA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOSVRSTA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSVRSTA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSVRSTA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSVRSTA.RowStyles.Add(new RowStyle());
            this.label1IDOSVRSTA = new UltraLabel();
            this.textIDOSVRSTA = new UltraNumericEditor();
            this.label1OPISOSVRSTA = new UltraLabel();
            this.textOPISOSVRSTA = new UltraTextEditor();
            this.label1OSV = new UltraLabel();
            this.labelOSV = new UltraLabel();
            ((ISupportInitialize) this.textIDOSVRSTA).BeginInit();
            ((ISupportInitialize) this.textOPISOSVRSTA).BeginInit();
            this.dsOSVRSTADataSet1 = new OSVRSTADataSet();
            this.dsOSVRSTADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsOSVRSTADataSet1.DataSetName = "dsOSVRSTA";
            this.dsOSVRSTADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceOSVRSTA.DataSource = this.dsOSVRSTADataSet1;
            this.bindingSourceOSVRSTA.DataMember = "OSVRSTA";
            ((ISupportInitialize) this.bindingSourceOSVRSTA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDOSVRSTA.Location = point;
            this.label1IDOSVRSTA.Name = "label1IDOSVRSTA";
            this.label1IDOSVRSTA.TabIndex = 1;
            this.label1IDOSVRSTA.Tag = "labelIDOSVRSTA";
            this.label1IDOSVRSTA.Text = "Šfr.:";
            this.label1IDOSVRSTA.StyleSetName = "FieldUltraLabel";
            this.label1IDOSVRSTA.AutoSize = true;
            this.label1IDOSVRSTA.Anchor = AnchorStyles.Left;
            this.label1IDOSVRSTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOSVRSTA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDOSVRSTA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDOSVRSTA.ImageSize = size;
            this.label1IDOSVRSTA.Appearance.ForeColor = Color.Black;
            this.label1IDOSVRSTA.BackColor = Color.Transparent;
            this.layoutManagerformOSVRSTA.Controls.Add(this.label1IDOSVRSTA, 0, 0);
            this.layoutManagerformOSVRSTA.SetColumnSpan(this.label1IDOSVRSTA, 1);
            this.layoutManagerformOSVRSTA.SetRowSpan(this.label1IDOSVRSTA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDOSVRSTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOSVRSTA.MinimumSize = size;
            size = new System.Drawing.Size(0x26, 0x17);
            this.label1IDOSVRSTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDOSVRSTA.Location = point;
            this.textIDOSVRSTA.Name = "textIDOSVRSTA";
            this.textIDOSVRSTA.Tag = "IDOSVRSTA";
            this.textIDOSVRSTA.TabIndex = 0;
            this.textIDOSVRSTA.Anchor = AnchorStyles.Left;
            this.textIDOSVRSTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDOSVRSTA.ReadOnly = false;
            this.textIDOSVRSTA.PromptChar = ' ';
            this.textIDOSVRSTA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDOSVRSTA.DataBindings.Add(new Binding("Value", this.bindingSourceOSVRSTA, "IDOSVRSTA"));
            this.textIDOSVRSTA.NumericType = NumericType.Integer;
            this.textIDOSVRSTA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformOSVRSTA.Controls.Add(this.textIDOSVRSTA, 1, 0);
            this.layoutManagerformOSVRSTA.SetColumnSpan(this.textIDOSVRSTA, 1);
            this.layoutManagerformOSVRSTA.SetRowSpan(this.textIDOSVRSTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOSVRSTA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDOSVRSTA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDOSVRSTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISOSVRSTA.Location = point;
            this.label1OPISOSVRSTA.Name = "label1OPISOSVRSTA";
            this.label1OPISOSVRSTA.TabIndex = 1;
            this.label1OPISOSVRSTA.Tag = "labelOPISOSVRSTA";
            this.label1OPISOSVRSTA.Text = "Vrsta sredstva (OS ili SI):";
            this.label1OPISOSVRSTA.StyleSetName = "FieldUltraLabel";
            this.label1OPISOSVRSTA.AutoSize = true;
            this.label1OPISOSVRSTA.Anchor = AnchorStyles.Left;
            this.label1OPISOSVRSTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISOSVRSTA.Appearance.ForeColor = Color.Black;
            this.label1OPISOSVRSTA.BackColor = Color.Transparent;
            this.layoutManagerformOSVRSTA.Controls.Add(this.label1OPISOSVRSTA, 0, 1);
            this.layoutManagerformOSVRSTA.SetColumnSpan(this.label1OPISOSVRSTA, 1);
            this.layoutManagerformOSVRSTA.SetRowSpan(this.label1OPISOSVRSTA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISOSVRSTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISOSVRSTA.MinimumSize = size;
            size = new System.Drawing.Size(0xad, 0x17);
            this.label1OPISOSVRSTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPISOSVRSTA.Location = point;
            this.textOPISOSVRSTA.Name = "textOPISOSVRSTA";
            this.textOPISOSVRSTA.Tag = "OPISOSVRSTA";
            this.textOPISOSVRSTA.TabIndex = 0;
            this.textOPISOSVRSTA.Anchor = AnchorStyles.Left;
            this.textOPISOSVRSTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPISOSVRSTA.ReadOnly = false;
            this.textOPISOSVRSTA.DataBindings.Add(new Binding("Text", this.bindingSourceOSVRSTA, "OPISOSVRSTA"));
            this.textOPISOSVRSTA.MaxLength = 30;
            this.layoutManagerformOSVRSTA.Controls.Add(this.textOPISOSVRSTA, 1, 1);
            this.layoutManagerformOSVRSTA.SetColumnSpan(this.textOPISOSVRSTA, 1);
            this.layoutManagerformOSVRSTA.SetRowSpan(this.textOPISOSVRSTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPISOSVRSTA.Margin = padding;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textOPISOSVRSTA.MinimumSize = size;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textOPISOSVRSTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OSV.Location = point;
            this.label1OSV.Name = "label1OSV";
            this.label1OSV.TabIndex = 1;
            this.label1OSV.Tag = "labelOSV";
            this.label1OSV.Text = "OSV:";
            this.label1OSV.StyleSetName = "FieldUltraLabel";
            this.label1OSV.AutoSize = true;
            this.label1OSV.Anchor = AnchorStyles.Left;
            this.label1OSV.Appearance.TextVAlign = VAlign.Middle;
            this.label1OSV.Appearance.ForeColor = Color.Black;
            this.label1OSV.BackColor = Color.Transparent;
            this.layoutManagerformOSVRSTA.Controls.Add(this.label1OSV, 0, 2);
            this.layoutManagerformOSVRSTA.SetColumnSpan(this.label1OSV, 1);
            this.layoutManagerformOSVRSTA.SetRowSpan(this.label1OSV, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OSV.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OSV.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1OSV.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOSV.Location = point;
            this.labelOSV.Name = "labelOSV";
            this.labelOSV.Tag = "OSV";
            this.labelOSV.TabIndex = 0;
            this.labelOSV.Anchor = AnchorStyles.Left;
            this.labelOSV.BackColor = Color.Transparent;
            this.labelOSV.DataBindings.Add(new Binding("Text", this.bindingSourceOSVRSTA, "OSV"));
            this.labelOSV.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOSVRSTA.Controls.Add(this.labelOSV, 1, 2);
            this.layoutManagerformOSVRSTA.SetColumnSpan(this.labelOSV, 1);
            this.layoutManagerformOSVRSTA.SetRowSpan(this.labelOSV, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOSV.Margin = padding;
            size = new System.Drawing.Size(0x105, 0x16);
            this.labelOSV.MinimumSize = size;
            size = new System.Drawing.Size(0x105, 0x16);
            this.labelOSV.Size = size;
            this.Controls.Add(this.layoutManagerformOSVRSTA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceOSVRSTA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "OSVRSTAFormUserControl";
            this.Text = "Vrste sredstava (OS ili SI)";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OSVRSTAFormUserControl_Load);
            this.layoutManagerformOSVRSTA.ResumeLayout(false);
            this.layoutManagerformOSVRSTA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceOSVRSTA).EndInit();
            ((ISupportInitialize) this.textIDOSVRSTA).EndInit();
            ((ISupportInitialize) this.textOPISOSVRSTA).EndInit();
            this.dsOSVRSTADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OSVRSTAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceOSVRSTA, this.OSVRSTAController.WorkItem, this))
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
            this.label1IDOSVRSTA.Text = StringResources.OSVRSTAIDOSVRSTADescription;
            this.label1OPISOSVRSTA.Text = StringResources.OSVRSTAOPISOSVRSTADescription;
            this.label1OSV.Text = StringResources.OSVRSTAOSVDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewOS")]
        public void NewOSHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OSVRSTAController.NewOS(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void OSVRSTAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OSVRSTADescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.OSVRSTAController.WorkItem.Items.Contains("OSVRSTA|OSVRSTA"))
            {
                this.OSVRSTAController.WorkItem.Items.Add(this.bindingSourceOSVRSTA, "OSVRSTA|OSVRSTA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsOSVRSTADataSet1.OSVRSTA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.OSVRSTAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OSVRSTAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OSVRSTAController.Update(this))
            {
                this.OSVRSTAController.DataSet = new OSVRSTADataSet();
                DataSetUtil.AddEmptyRow(this.OSVRSTAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.OSVRSTAController.DataSet.OSVRSTA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDOSVRSTA.Focus();
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

        [LocalCommandHandler("ViewOS")]
        public void ViewOSHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OSVRSTAController.ViewOS(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDOSVRSTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOSVRSTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOSVRSTA = value;
            }
        }

        protected virtual UltraLabel label1OPISOSVRSTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISOSVRSTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISOSVRSTA = value;
            }
        }

        protected virtual UltraLabel label1OSV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OSV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OSV = value;
            }
        }

        protected virtual UltraLabel labelOSV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOSV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOSV = value;
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
        public NetAdvantage.Controllers.OSVRSTAController OSVRSTAController { get; set; }

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

        protected virtual UltraNumericEditor textIDOSVRSTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDOSVRSTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDOSVRSTA = value;
            }
        }

        protected virtual UltraTextEditor textOPISOSVRSTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPISOSVRSTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPISOSVRSTA = value;
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

