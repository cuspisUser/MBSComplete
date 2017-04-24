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
    public class BRACNOSTANJEFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDBRACNOSTANJE")]
        private UltraLabel _label1IDBRACNOSTANJE;
        [AccessedThroughProperty("label1NAZIVBRACNOSTANJE")]
        private UltraLabel _label1NAZIVBRACNOSTANJE;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDBRACNOSTANJE")]
        private UltraNumericEditor _textIDBRACNOSTANJE;
        [AccessedThroughProperty("textNAZIVBRACNOSTANJE")]
        private UltraTextEditor _textNAZIVBRACNOSTANJE;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceBRACNOSTANJE;
        private IContainer components = null;
        private BRACNOSTANJEDataSet dsBRACNOSTANJEDataSet1;
        protected TableLayoutPanel layoutManagerformBRACNOSTANJE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private BRACNOSTANJEDataSet.BRACNOSTANJERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "BRACNOSTANJE";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.BRACNOSTANJEDescription;
        private DeklaritMode m_Mode;

        public BRACNOSTANJEFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void BRACNOSTANJEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.BRACNOSTANJEDescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void ChangeBinding()
        {
            this.bindingSourceBRACNOSTANJE.DataSource = this.BRACNOSTANJEController.DataSet;
            this.dsBRACNOSTANJEDataSet1 = this.BRACNOSTANJEController.DataSet;
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
                    enumerator = this.dsBRACNOSTANJEDataSet1.BRACNOSTANJE.Rows.GetEnumerator();
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
                if (this.BRACNOSTANJEController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "BRACNOSTANJE", this.m_Mode, this.dsBRACNOSTANJEDataSet1, this.dsBRACNOSTANJEDataSet1.BRACNOSTANJE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsBRACNOSTANJEDataSet1.BRACNOSTANJE[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (BRACNOSTANJEDataSet.BRACNOSTANJERow) ((DataRowView) this.bindingSourceBRACNOSTANJE.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(BRACNOSTANJEFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceBRACNOSTANJE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceBRACNOSTANJE).BeginInit();
            this.layoutManagerformBRACNOSTANJE = new TableLayoutPanel();
            this.layoutManagerformBRACNOSTANJE.SuspendLayout();
            this.layoutManagerformBRACNOSTANJE.AutoSize = true;
            this.layoutManagerformBRACNOSTANJE.Dock = DockStyle.Fill;
            this.layoutManagerformBRACNOSTANJE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformBRACNOSTANJE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformBRACNOSTANJE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformBRACNOSTANJE.Size = size;
            this.layoutManagerformBRACNOSTANJE.ColumnCount = 2;
            this.layoutManagerformBRACNOSTANJE.RowCount = 3;
            this.layoutManagerformBRACNOSTANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformBRACNOSTANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformBRACNOSTANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformBRACNOSTANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformBRACNOSTANJE.RowStyles.Add(new RowStyle());
            this.label1IDBRACNOSTANJE = new UltraLabel();
            this.textIDBRACNOSTANJE = new UltraNumericEditor();
            this.label1NAZIVBRACNOSTANJE = new UltraLabel();
            this.textNAZIVBRACNOSTANJE = new UltraTextEditor();
            ((ISupportInitialize) this.textIDBRACNOSTANJE).BeginInit();
            ((ISupportInitialize) this.textNAZIVBRACNOSTANJE).BeginInit();
            this.dsBRACNOSTANJEDataSet1 = new BRACNOSTANJEDataSet();
            this.dsBRACNOSTANJEDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsBRACNOSTANJEDataSet1.DataSetName = "dsBRACNOSTANJE";
            this.dsBRACNOSTANJEDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceBRACNOSTANJE.DataSource = this.dsBRACNOSTANJEDataSet1;
            this.bindingSourceBRACNOSTANJE.DataMember = "BRACNOSTANJE";
            ((ISupportInitialize) this.bindingSourceBRACNOSTANJE).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDBRACNOSTANJE.Location = point;
            this.label1IDBRACNOSTANJE.Name = "label1IDBRACNOSTANJE";
            this.label1IDBRACNOSTANJE.TabIndex = 1;
            this.label1IDBRACNOSTANJE.Tag = "labelIDBRACNOSTANJE";
            this.label1IDBRACNOSTANJE.Text = "Šifra bračnog stanja:";
            this.label1IDBRACNOSTANJE.StyleSetName = "FieldUltraLabel";
            this.label1IDBRACNOSTANJE.AutoSize = true;
            this.label1IDBRACNOSTANJE.Anchor = AnchorStyles.Left;
            this.label1IDBRACNOSTANJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDBRACNOSTANJE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDBRACNOSTANJE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDBRACNOSTANJE.ImageSize = size;
            this.label1IDBRACNOSTANJE.Appearance.ForeColor = Color.Black;
            this.label1IDBRACNOSTANJE.BackColor = Color.Transparent;
            this.layoutManagerformBRACNOSTANJE.Controls.Add(this.label1IDBRACNOSTANJE, 0, 0);
            this.layoutManagerformBRACNOSTANJE.SetColumnSpan(this.label1IDBRACNOSTANJE, 1);
            this.layoutManagerformBRACNOSTANJE.SetRowSpan(this.label1IDBRACNOSTANJE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDBRACNOSTANJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDBRACNOSTANJE.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 0x17);
            this.label1IDBRACNOSTANJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDBRACNOSTANJE.Location = point;
            this.textIDBRACNOSTANJE.Name = "textIDBRACNOSTANJE";
            this.textIDBRACNOSTANJE.Tag = "IDBRACNOSTANJE";
            this.textIDBRACNOSTANJE.TabIndex = 0;
            this.textIDBRACNOSTANJE.Anchor = AnchorStyles.Left;
            this.textIDBRACNOSTANJE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDBRACNOSTANJE.ReadOnly = false;
            this.textIDBRACNOSTANJE.PromptChar = ' ';
            this.textIDBRACNOSTANJE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDBRACNOSTANJE.DataBindings.Add(new Binding("Value", this.bindingSourceBRACNOSTANJE, "IDBRACNOSTANJE"));
            this.textIDBRACNOSTANJE.NumericType = NumericType.Integer;
            this.textIDBRACNOSTANJE.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformBRACNOSTANJE.Controls.Add(this.textIDBRACNOSTANJE, 1, 0);
            this.layoutManagerformBRACNOSTANJE.SetColumnSpan(this.textIDBRACNOSTANJE, 1);
            this.layoutManagerformBRACNOSTANJE.SetRowSpan(this.textIDBRACNOSTANJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDBRACNOSTANJE.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDBRACNOSTANJE.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDBRACNOSTANJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVBRACNOSTANJE.Location = point;
            this.label1NAZIVBRACNOSTANJE.Name = "label1NAZIVBRACNOSTANJE";
            this.label1NAZIVBRACNOSTANJE.TabIndex = 1;
            this.label1NAZIVBRACNOSTANJE.Tag = "labelNAZIVBRACNOSTANJE";
            this.label1NAZIVBRACNOSTANJE.Text = "Naziv bračnog stanja:";
            this.label1NAZIVBRACNOSTANJE.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVBRACNOSTANJE.AutoSize = true;
            this.label1NAZIVBRACNOSTANJE.Anchor = AnchorStyles.Left;
            this.label1NAZIVBRACNOSTANJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVBRACNOSTANJE.Appearance.ForeColor = Color.Black;
            this.label1NAZIVBRACNOSTANJE.BackColor = Color.Transparent;
            this.layoutManagerformBRACNOSTANJE.Controls.Add(this.label1NAZIVBRACNOSTANJE, 0, 1);
            this.layoutManagerformBRACNOSTANJE.SetColumnSpan(this.label1NAZIVBRACNOSTANJE, 1);
            this.layoutManagerformBRACNOSTANJE.SetRowSpan(this.label1NAZIVBRACNOSTANJE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVBRACNOSTANJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVBRACNOSTANJE.MinimumSize = size;
            size = new System.Drawing.Size(150, 0x17);
            this.label1NAZIVBRACNOSTANJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVBRACNOSTANJE.Location = point;
            this.textNAZIVBRACNOSTANJE.Name = "textNAZIVBRACNOSTANJE";
            this.textNAZIVBRACNOSTANJE.Tag = "NAZIVBRACNOSTANJE";
            this.textNAZIVBRACNOSTANJE.TabIndex = 0;
            this.textNAZIVBRACNOSTANJE.Anchor = AnchorStyles.Left;
            this.textNAZIVBRACNOSTANJE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVBRACNOSTANJE.ReadOnly = false;
            this.textNAZIVBRACNOSTANJE.DataBindings.Add(new Binding("Text", this.bindingSourceBRACNOSTANJE, "NAZIVBRACNOSTANJE"));
            this.textNAZIVBRACNOSTANJE.MaxLength = 50;
            this.layoutManagerformBRACNOSTANJE.Controls.Add(this.textNAZIVBRACNOSTANJE, 1, 1);
            this.layoutManagerformBRACNOSTANJE.SetColumnSpan(this.textNAZIVBRACNOSTANJE, 1);
            this.layoutManagerformBRACNOSTANJE.SetRowSpan(this.textNAZIVBRACNOSTANJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVBRACNOSTANJE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVBRACNOSTANJE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVBRACNOSTANJE.Size = size;
            this.Controls.Add(this.layoutManagerformBRACNOSTANJE);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceBRACNOSTANJE;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "BRACNOSTANJEFormUserControl";
            this.Text = "Braeno stanje";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.BRACNOSTANJEFormUserControl_Load);
            this.layoutManagerformBRACNOSTANJE.ResumeLayout(false);
            this.layoutManagerformBRACNOSTANJE.PerformLayout();
            ((ISupportInitialize) this.bindingSourceBRACNOSTANJE).EndInit();
            ((ISupportInitialize) this.textIDBRACNOSTANJE).EndInit();
            ((ISupportInitialize) this.textNAZIVBRACNOSTANJE).EndInit();
            this.dsBRACNOSTANJEDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.BRACNOSTANJEController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceBRACNOSTANJE, this.BRACNOSTANJEController.WorkItem, this))
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
            this.label1IDBRACNOSTANJE.Text = StringResources.BRACNOSTANJEIDBRACNOSTANJEDescription;
            this.label1NAZIVBRACNOSTANJE.Text = StringResources.BRACNOSTANJENAZIVBRACNOSTANJEDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewRADNIK")]
        public void NewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.BRACNOSTANJEController.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.BRACNOSTANJEController.WorkItem.Items.Contains("BRACNOSTANJE|BRACNOSTANJE"))
            {
                this.BRACNOSTANJEController.WorkItem.Items.Add(this.bindingSourceBRACNOSTANJE, "BRACNOSTANJE|BRACNOSTANJE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsBRACNOSTANJEDataSet1.BRACNOSTANJE.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.BRACNOSTANJEController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.BRACNOSTANJEController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.BRACNOSTANJEController.Update(this))
            {
                this.BRACNOSTANJEController.DataSet = new BRACNOSTANJEDataSet();
                DataSetUtil.AddEmptyRow(this.BRACNOSTANJEController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.BRACNOSTANJEController.DataSet.BRACNOSTANJE[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDBRACNOSTANJE.Focus();
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

        [LocalCommandHandler("ViewRADNIK")]
        public void ViewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.BRACNOSTANJEController.ViewRADNIK(this.m_CurrentRow);
            }
        }

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.BRACNOSTANJEController BRACNOSTANJEController { get; set; }

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

        protected virtual UltraLabel label1IDBRACNOSTANJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDBRACNOSTANJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDBRACNOSTANJE = value;
            }
        }

        protected virtual UltraLabel label1NAZIVBRACNOSTANJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVBRACNOSTANJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVBRACNOSTANJE = value;
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

        protected virtual UltraNumericEditor textIDBRACNOSTANJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDBRACNOSTANJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDBRACNOSTANJE = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVBRACNOSTANJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVBRACNOSTANJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVBRACNOSTANJE = value;
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

