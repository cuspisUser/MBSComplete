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
    public class TIPOLAKSICEFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDTIPOLAKSICE")]
        private UltraLabel _label1IDTIPOLAKSICE;
        [AccessedThroughProperty("label1NAZIVTIPOLAKSICE")]
        private UltraLabel _label1NAZIVTIPOLAKSICE;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDTIPOLAKSICE")]
        private UltraNumericEditor _textIDTIPOLAKSICE;
        [AccessedThroughProperty("textNAZIVTIPOLAKSICE")]
        private UltraTextEditor _textNAZIVTIPOLAKSICE;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceTIPOLAKSICE;
        private IContainer components = null;
        private TIPOLAKSICEDataSet dsTIPOLAKSICEDataSet1;
        protected TableLayoutPanel layoutManagerformTIPOLAKSICE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private TIPOLAKSICEDataSet.TIPOLAKSICERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "TIPOLAKSICE";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.TIPOLAKSICEDescription;
        private DeklaritMode m_Mode;

        public TIPOLAKSICEFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceTIPOLAKSICE.DataSource = this.TIPOLAKSICEController.DataSet;
            this.dsTIPOLAKSICEDataSet1 = this.TIPOLAKSICEController.DataSet;
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
                    enumerator = this.dsTIPOLAKSICEDataSet1.TIPOLAKSICE.Rows.GetEnumerator();
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
                if (this.TIPOLAKSICEController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "TIPOLAKSICE", this.m_Mode, this.dsTIPOLAKSICEDataSet1, this.dsTIPOLAKSICEDataSet1.TIPOLAKSICE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsTIPOLAKSICEDataSet1.TIPOLAKSICE[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (TIPOLAKSICEDataSet.TIPOLAKSICERow) ((DataRowView) this.bindingSourceTIPOLAKSICE.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(TIPOLAKSICEFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceTIPOLAKSICE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceTIPOLAKSICE).BeginInit();
            this.layoutManagerformTIPOLAKSICE = new TableLayoutPanel();
            this.layoutManagerformTIPOLAKSICE.SuspendLayout();
            this.layoutManagerformTIPOLAKSICE.AutoSize = true;
            this.layoutManagerformTIPOLAKSICE.Dock = DockStyle.Fill;
            this.layoutManagerformTIPOLAKSICE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformTIPOLAKSICE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformTIPOLAKSICE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformTIPOLAKSICE.Size = size;
            this.layoutManagerformTIPOLAKSICE.ColumnCount = 2;
            this.layoutManagerformTIPOLAKSICE.RowCount = 3;
            this.layoutManagerformTIPOLAKSICE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformTIPOLAKSICE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformTIPOLAKSICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformTIPOLAKSICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformTIPOLAKSICE.RowStyles.Add(new RowStyle());
            this.label1IDTIPOLAKSICE = new UltraLabel();
            this.textIDTIPOLAKSICE = new UltraNumericEditor();
            this.label1NAZIVTIPOLAKSICE = new UltraLabel();
            this.textNAZIVTIPOLAKSICE = new UltraTextEditor();
            ((ISupportInitialize) this.textIDTIPOLAKSICE).BeginInit();
            ((ISupportInitialize) this.textNAZIVTIPOLAKSICE).BeginInit();
            this.dsTIPOLAKSICEDataSet1 = new TIPOLAKSICEDataSet();
            this.dsTIPOLAKSICEDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsTIPOLAKSICEDataSet1.DataSetName = "dsTIPOLAKSICE";
            this.dsTIPOLAKSICEDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceTIPOLAKSICE.DataSource = this.dsTIPOLAKSICEDataSet1;
            this.bindingSourceTIPOLAKSICE.DataMember = "TIPOLAKSICE";
            ((ISupportInitialize) this.bindingSourceTIPOLAKSICE).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDTIPOLAKSICE.Location = point;
            this.label1IDTIPOLAKSICE.Name = "label1IDTIPOLAKSICE";
            this.label1IDTIPOLAKSICE.TabIndex = 1;
            this.label1IDTIPOLAKSICE.Tag = "labelIDTIPOLAKSICE";
            this.label1IDTIPOLAKSICE.Text = "Tip olakšice:";
            this.label1IDTIPOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1IDTIPOLAKSICE.AutoSize = true;
            this.label1IDTIPOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1IDTIPOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDTIPOLAKSICE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDTIPOLAKSICE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDTIPOLAKSICE.ImageSize = size;
            this.label1IDTIPOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1IDTIPOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformTIPOLAKSICE.Controls.Add(this.label1IDTIPOLAKSICE, 0, 0);
            this.layoutManagerformTIPOLAKSICE.SetColumnSpan(this.label1IDTIPOLAKSICE, 1);
            this.layoutManagerformTIPOLAKSICE.SetRowSpan(this.label1IDTIPOLAKSICE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDTIPOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDTIPOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x59, 0x17);
            this.label1IDTIPOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDTIPOLAKSICE.Location = point;
            this.textIDTIPOLAKSICE.Name = "textIDTIPOLAKSICE";
            this.textIDTIPOLAKSICE.Tag = "IDTIPOLAKSICE";
            this.textIDTIPOLAKSICE.TabIndex = 0;
            this.textIDTIPOLAKSICE.Anchor = AnchorStyles.Left;
            this.textIDTIPOLAKSICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDTIPOLAKSICE.ReadOnly = false;
            this.textIDTIPOLAKSICE.PromptChar = ' ';
            this.textIDTIPOLAKSICE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDTIPOLAKSICE.DataBindings.Add(new Binding("Value", this.bindingSourceTIPOLAKSICE, "IDTIPOLAKSICE"));
            this.textIDTIPOLAKSICE.NumericType = NumericType.Integer;
            this.textIDTIPOLAKSICE.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformTIPOLAKSICE.Controls.Add(this.textIDTIPOLAKSICE, 1, 0);
            this.layoutManagerformTIPOLAKSICE.SetColumnSpan(this.textIDTIPOLAKSICE, 1);
            this.layoutManagerformTIPOLAKSICE.SetRowSpan(this.textIDTIPOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDTIPOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDTIPOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDTIPOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVTIPOLAKSICE.Location = point;
            this.label1NAZIVTIPOLAKSICE.Name = "label1NAZIVTIPOLAKSICE";
            this.label1NAZIVTIPOLAKSICE.TabIndex = 1;
            this.label1NAZIVTIPOLAKSICE.Tag = "labelNAZIVTIPOLAKSICE";
            this.label1NAZIVTIPOLAKSICE.Text = "Naziv tipa olakšice:";
            this.label1NAZIVTIPOLAKSICE.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVTIPOLAKSICE.AutoSize = true;
            this.label1NAZIVTIPOLAKSICE.Anchor = AnchorStyles.Left;
            this.label1NAZIVTIPOLAKSICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVTIPOLAKSICE.Appearance.ForeColor = Color.Black;
            this.label1NAZIVTIPOLAKSICE.BackColor = Color.Transparent;
            this.layoutManagerformTIPOLAKSICE.Controls.Add(this.label1NAZIVTIPOLAKSICE, 0, 1);
            this.layoutManagerformTIPOLAKSICE.SetColumnSpan(this.label1NAZIVTIPOLAKSICE, 1);
            this.layoutManagerformTIPOLAKSICE.SetRowSpan(this.label1NAZIVTIPOLAKSICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVTIPOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVTIPOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x87, 0x17);
            this.label1NAZIVTIPOLAKSICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVTIPOLAKSICE.Location = point;
            this.textNAZIVTIPOLAKSICE.Name = "textNAZIVTIPOLAKSICE";
            this.textNAZIVTIPOLAKSICE.Tag = "NAZIVTIPOLAKSICE";
            this.textNAZIVTIPOLAKSICE.TabIndex = 0;
            this.textNAZIVTIPOLAKSICE.Anchor = AnchorStyles.Left;
            this.textNAZIVTIPOLAKSICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVTIPOLAKSICE.ReadOnly = false;
            this.textNAZIVTIPOLAKSICE.DataBindings.Add(new Binding("Text", this.bindingSourceTIPOLAKSICE, "NAZIVTIPOLAKSICE"));
            this.textNAZIVTIPOLAKSICE.MaxLength = 50;
            this.layoutManagerformTIPOLAKSICE.Controls.Add(this.textNAZIVTIPOLAKSICE, 1, 1);
            this.layoutManagerformTIPOLAKSICE.SetColumnSpan(this.textNAZIVTIPOLAKSICE, 1);
            this.layoutManagerformTIPOLAKSICE.SetRowSpan(this.textNAZIVTIPOLAKSICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVTIPOLAKSICE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVTIPOLAKSICE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVTIPOLAKSICE.Size = size;
            this.Controls.Add(this.layoutManagerformTIPOLAKSICE);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceTIPOLAKSICE;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "TIPOLAKSICEFormUserControl";
            this.Text = "Tipovi olakšica";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.TIPOLAKSICEFormUserControl_Load);
            this.layoutManagerformTIPOLAKSICE.ResumeLayout(false);
            this.layoutManagerformTIPOLAKSICE.PerformLayout();
            ((ISupportInitialize) this.bindingSourceTIPOLAKSICE).EndInit();
            ((ISupportInitialize) this.textIDTIPOLAKSICE).EndInit();
            ((ISupportInitialize) this.textNAZIVTIPOLAKSICE).EndInit();
            this.dsTIPOLAKSICEDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.TIPOLAKSICEController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceTIPOLAKSICE, this.TIPOLAKSICEController.WorkItem, this))
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
            this.label1IDTIPOLAKSICE.Text = StringResources.TIPOLAKSICEIDTIPOLAKSICEDescription;
            this.label1NAZIVTIPOLAKSICE.Text = StringResources.TIPOLAKSICENAZIVTIPOLAKSICEDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewOLAKSICE")]
        public void NewOLAKSICEHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.TIPOLAKSICEController.NewOLAKSICE(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.TIPOLAKSICEController.WorkItem.Items.Contains("TIPOLAKSICE|TIPOLAKSICE"))
            {
                this.TIPOLAKSICEController.WorkItem.Items.Add(this.bindingSourceTIPOLAKSICE, "TIPOLAKSICE|TIPOLAKSICE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsTIPOLAKSICEDataSet1.TIPOLAKSICE.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.TIPOLAKSICEController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.TIPOLAKSICEController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.TIPOLAKSICEController.Update(this))
            {
                this.TIPOLAKSICEController.DataSet = new TIPOLAKSICEDataSet();
                DataSetUtil.AddEmptyRow(this.TIPOLAKSICEController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.TIPOLAKSICEController.DataSet.TIPOLAKSICE[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDTIPOLAKSICE.Focus();
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

        private void TIPOLAKSICEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.TIPOLAKSICEDescription;
            this.errorProvider1.ContainerControl = this;
        }

        [LocalCommandHandler("ViewOLAKSICE")]
        public void ViewOLAKSICEHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.TIPOLAKSICEController.ViewOLAKSICE(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDTIPOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDTIPOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDTIPOLAKSICE = value;
            }
        }

        protected virtual UltraLabel label1NAZIVTIPOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVTIPOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVTIPOLAKSICE = value;
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

        protected virtual UltraNumericEditor textIDTIPOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDTIPOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDTIPOLAKSICE = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVTIPOLAKSICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVTIPOLAKSICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVTIPOLAKSICE = value;
            }
        }

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.TIPOLAKSICEController TIPOLAKSICEController { get; set; }

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

