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
    public class BLGVRSTEDOKFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDBLGVRSTEDOK")]
        private UltraLabel _label1IDBLGVRSTEDOK;
        [AccessedThroughProperty("label1NAZIVVRSTEDOK")]
        private UltraLabel _label1NAZIVVRSTEDOK;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDBLGVRSTEDOK")]
        private UltraNumericEditor _textIDBLGVRSTEDOK;
        [AccessedThroughProperty("textNAZIVVRSTEDOK")]
        private UltraTextEditor _textNAZIVVRSTEDOK;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceBLGVRSTEDOK;
        private IContainer components = null;
        private BLGVRSTEDOKDataSet dsBLGVRSTEDOKDataSet1;
        protected TableLayoutPanel layoutManagerformBLGVRSTEDOK;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private BLGVRSTEDOKDataSet.BLGVRSTEDOKRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "BLGVRSTEDOK";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.BLGVRSTEDOKDescription;
        private DeklaritMode m_Mode;

        public BLGVRSTEDOKFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void BLGVRSTEDOKFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.BLGVRSTEDOKDescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void ChangeBinding()
        {
            this.bindingSourceBLGVRSTEDOK.DataSource = this.BLGVRSTEDOKController.DataSet;
            this.dsBLGVRSTEDOKDataSet1 = this.BLGVRSTEDOKController.DataSet;
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
                    enumerator = this.dsBLGVRSTEDOKDataSet1.BLGVRSTEDOK.Rows.GetEnumerator();
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
                if (this.BLGVRSTEDOKController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "BLGVRSTEDOK", this.m_Mode, this.dsBLGVRSTEDOKDataSet1, this.dsBLGVRSTEDOKDataSet1.BLGVRSTEDOK.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsBLGVRSTEDOKDataSet1.BLGVRSTEDOK[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (BLGVRSTEDOKDataSet.BLGVRSTEDOKRow) ((DataRowView) this.bindingSourceBLGVRSTEDOK.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(BLGVRSTEDOKFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceBLGVRSTEDOK = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceBLGVRSTEDOK).BeginInit();
            this.layoutManagerformBLGVRSTEDOK = new TableLayoutPanel();
            this.layoutManagerformBLGVRSTEDOK.SuspendLayout();
            this.layoutManagerformBLGVRSTEDOK.AutoSize = true;
            this.layoutManagerformBLGVRSTEDOK.Dock = DockStyle.Fill;
            this.layoutManagerformBLGVRSTEDOK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformBLGVRSTEDOK.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformBLGVRSTEDOK.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformBLGVRSTEDOK.Size = size;
            this.layoutManagerformBLGVRSTEDOK.ColumnCount = 2;
            this.layoutManagerformBLGVRSTEDOK.RowCount = 3;
            this.layoutManagerformBLGVRSTEDOK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformBLGVRSTEDOK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformBLGVRSTEDOK.RowStyles.Add(new RowStyle());
            this.layoutManagerformBLGVRSTEDOK.RowStyles.Add(new RowStyle());
            this.layoutManagerformBLGVRSTEDOK.RowStyles.Add(new RowStyle());
            this.label1IDBLGVRSTEDOK = new UltraLabel();
            this.textIDBLGVRSTEDOK = new UltraNumericEditor();
            this.label1NAZIVVRSTEDOK = new UltraLabel();
            this.textNAZIVVRSTEDOK = new UltraTextEditor();
            ((ISupportInitialize) this.textIDBLGVRSTEDOK).BeginInit();
            ((ISupportInitialize) this.textNAZIVVRSTEDOK).BeginInit();
            this.dsBLGVRSTEDOKDataSet1 = new BLGVRSTEDOKDataSet();
            this.dsBLGVRSTEDOKDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsBLGVRSTEDOKDataSet1.DataSetName = "dsBLGVRSTEDOK";
            this.dsBLGVRSTEDOKDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceBLGVRSTEDOK.DataSource = this.dsBLGVRSTEDOKDataSet1;
            this.bindingSourceBLGVRSTEDOK.DataMember = "BLGVRSTEDOK";
            ((ISupportInitialize) this.bindingSourceBLGVRSTEDOK).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDBLGVRSTEDOK.Location = point;
            this.label1IDBLGVRSTEDOK.Name = "label1IDBLGVRSTEDOK";
            this.label1IDBLGVRSTEDOK.TabIndex = 1;
            this.label1IDBLGVRSTEDOK.Tag = "labelIDBLGVRSTEDOK";
            this.label1IDBLGVRSTEDOK.Text = "Šif.dok.blagajne:";
            this.label1IDBLGVRSTEDOK.StyleSetName = "FieldUltraLabel";
            this.label1IDBLGVRSTEDOK.AutoSize = true;
            this.label1IDBLGVRSTEDOK.Anchor = AnchorStyles.Left;
            this.label1IDBLGVRSTEDOK.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDBLGVRSTEDOK.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDBLGVRSTEDOK.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDBLGVRSTEDOK.ImageSize = size;
            this.label1IDBLGVRSTEDOK.Appearance.ForeColor = Color.Black;
            this.label1IDBLGVRSTEDOK.BackColor = Color.Transparent;
            this.layoutManagerformBLGVRSTEDOK.Controls.Add(this.label1IDBLGVRSTEDOK, 0, 0);
            this.layoutManagerformBLGVRSTEDOK.SetColumnSpan(this.label1IDBLGVRSTEDOK, 1);
            this.layoutManagerformBLGVRSTEDOK.SetRowSpan(this.label1IDBLGVRSTEDOK, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDBLGVRSTEDOK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDBLGVRSTEDOK.MinimumSize = size;
            size = new System.Drawing.Size(0x75, 0x17);
            this.label1IDBLGVRSTEDOK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDBLGVRSTEDOK.Location = point;
            this.textIDBLGVRSTEDOK.Name = "textIDBLGVRSTEDOK";
            this.textIDBLGVRSTEDOK.Tag = "IDBLGVRSTEDOK";
            this.textIDBLGVRSTEDOK.TabIndex = 0;
            this.textIDBLGVRSTEDOK.Anchor = AnchorStyles.Left;
            this.textIDBLGVRSTEDOK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDBLGVRSTEDOK.ReadOnly = false;
            this.textIDBLGVRSTEDOK.PromptChar = ' ';
            this.textIDBLGVRSTEDOK.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDBLGVRSTEDOK.DataBindings.Add(new Binding("Value", this.bindingSourceBLGVRSTEDOK, "IDBLGVRSTEDOK"));
            this.textIDBLGVRSTEDOK.NumericType = NumericType.Integer;
            this.textIDBLGVRSTEDOK.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformBLGVRSTEDOK.Controls.Add(this.textIDBLGVRSTEDOK, 1, 0);
            this.layoutManagerformBLGVRSTEDOK.SetColumnSpan(this.textIDBLGVRSTEDOK, 1);
            this.layoutManagerformBLGVRSTEDOK.SetRowSpan(this.textIDBLGVRSTEDOK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDBLGVRSTEDOK.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDBLGVRSTEDOK.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDBLGVRSTEDOK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVVRSTEDOK.Location = point;
            this.label1NAZIVVRSTEDOK.Name = "label1NAZIVVRSTEDOK";
            this.label1NAZIVVRSTEDOK.TabIndex = 1;
            this.label1NAZIVVRSTEDOK.Tag = "labelNAZIVVRSTEDOK";
            this.label1NAZIVVRSTEDOK.Text = "Naziv dok.:";
            this.label1NAZIVVRSTEDOK.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVVRSTEDOK.AutoSize = true;
            this.label1NAZIVVRSTEDOK.Anchor = AnchorStyles.Left;
            this.label1NAZIVVRSTEDOK.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVVRSTEDOK.Appearance.ForeColor = Color.Black;
            this.label1NAZIVVRSTEDOK.BackColor = Color.Transparent;
            this.layoutManagerformBLGVRSTEDOK.Controls.Add(this.label1NAZIVVRSTEDOK, 0, 1);
            this.layoutManagerformBLGVRSTEDOK.SetColumnSpan(this.label1NAZIVVRSTEDOK, 1);
            this.layoutManagerformBLGVRSTEDOK.SetRowSpan(this.label1NAZIVVRSTEDOK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVVRSTEDOK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVVRSTEDOK.MinimumSize = size;
            size = new System.Drawing.Size(0x54, 0x17);
            this.label1NAZIVVRSTEDOK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVVRSTEDOK.Location = point;
            this.textNAZIVVRSTEDOK.Name = "textNAZIVVRSTEDOK";
            this.textNAZIVVRSTEDOK.Tag = "NAZIVVRSTEDOK";
            this.textNAZIVVRSTEDOK.TabIndex = 0;
            this.textNAZIVVRSTEDOK.Anchor = AnchorStyles.Left;
            this.textNAZIVVRSTEDOK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVVRSTEDOK.ReadOnly = false;
            this.textNAZIVVRSTEDOK.DataBindings.Add(new Binding("Text", this.bindingSourceBLGVRSTEDOK, "NAZIVVRSTEDOK"));
            this.textNAZIVVRSTEDOK.MaxLength = 30;
            this.layoutManagerformBLGVRSTEDOK.Controls.Add(this.textNAZIVVRSTEDOK, 1, 1);
            this.layoutManagerformBLGVRSTEDOK.SetColumnSpan(this.textNAZIVVRSTEDOK, 1);
            this.layoutManagerformBLGVRSTEDOK.SetRowSpan(this.textNAZIVVRSTEDOK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVVRSTEDOK.Margin = padding;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textNAZIVVRSTEDOK.MinimumSize = size;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textNAZIVVRSTEDOK.Size = size;
            this.Controls.Add(this.layoutManagerformBLGVRSTEDOK);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceBLGVRSTEDOK;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "BLGVRSTEDOKFormUserControl";
            this.Text = "BLGVRSTEDOK";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.BLGVRSTEDOKFormUserControl_Load);
            this.layoutManagerformBLGVRSTEDOK.ResumeLayout(false);
            this.layoutManagerformBLGVRSTEDOK.PerformLayout();
            ((ISupportInitialize) this.bindingSourceBLGVRSTEDOK).EndInit();
            ((ISupportInitialize) this.textIDBLGVRSTEDOK).EndInit();
            ((ISupportInitialize) this.textNAZIVVRSTEDOK).EndInit();
            this.dsBLGVRSTEDOKDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.BLGVRSTEDOKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceBLGVRSTEDOK, this.BLGVRSTEDOKController.WorkItem, this))
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
            this.label1IDBLGVRSTEDOK.Text = StringResources.BLGVRSTEDOKIDBLGVRSTEDOKDescription;
            this.label1NAZIVVRSTEDOK.Text = StringResources.BLGVRSTEDOKNAZIVVRSTEDOKDescription;
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
            if (!this.BLGVRSTEDOKController.WorkItem.Items.Contains("BLGVRSTEDOK|BLGVRSTEDOK"))
            {
                this.BLGVRSTEDOKController.WorkItem.Items.Add(this.bindingSourceBLGVRSTEDOK, "BLGVRSTEDOK|BLGVRSTEDOK");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsBLGVRSTEDOKDataSet1.BLGVRSTEDOK.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.BLGVRSTEDOKController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.BLGVRSTEDOKController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.BLGVRSTEDOKController.Update(this))
            {
                this.BLGVRSTEDOKController.DataSet = new BLGVRSTEDOKDataSet();
                DataSetUtil.AddEmptyRow(this.BLGVRSTEDOKController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.BLGVRSTEDOKController.DataSet.BLGVRSTEDOK[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDBLGVRSTEDOK.Focus();
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.BLGVRSTEDOKController BLGVRSTEDOKController { get; set; }

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

        protected virtual UltraLabel label1IDBLGVRSTEDOK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDBLGVRSTEDOK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDBLGVRSTEDOK = value;
            }
        }

        protected virtual UltraLabel label1NAZIVVRSTEDOK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVVRSTEDOK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVVRSTEDOK = value;
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

        protected virtual UltraNumericEditor textIDBLGVRSTEDOK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDBLGVRSTEDOK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDBLGVRSTEDOK = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVVRSTEDOK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVVRSTEDOK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVVRSTEDOK = value;
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

