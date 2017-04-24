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
    public class MZOSTABLICEFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDMZOSTABLICE")]
        private UltraLabel _label1IDMZOSTABLICE;
        [AccessedThroughProperty("label1OPISMZOSTABLICE")]
        private UltraLabel _label1OPISMZOSTABLICE;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDMZOSTABLICE")]
        private UltraNumericEditor _textIDMZOSTABLICE;
        [AccessedThroughProperty("textOPISMZOSTABLICE")]
        private UltraTextEditor _textOPISMZOSTABLICE;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceMZOSTABLICE;
        private IContainer components = null;
        private MZOSTABLICEDataSet dsMZOSTABLICEDataSet1;
        protected TableLayoutPanel layoutManagerformMZOSTABLICE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private MZOSTABLICEDataSet.MZOSTABLICERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "MZOSTABLICE";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.MZOSTABLICEDescription;
        private DeklaritMode m_Mode;

        public MZOSTABLICEFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceMZOSTABLICE.DataSource = this.MZOSTABLICEController.DataSet;
            this.dsMZOSTABLICEDataSet1 = this.MZOSTABLICEController.DataSet;
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
                    enumerator = this.dsMZOSTABLICEDataSet1.MZOSTABLICE.Rows.GetEnumerator();
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
                if (this.MZOSTABLICEController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "MZOSTABLICE", this.m_Mode, this.dsMZOSTABLICEDataSet1, this.dsMZOSTABLICEDataSet1.MZOSTABLICE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsMZOSTABLICEDataSet1.MZOSTABLICE[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (MZOSTABLICEDataSet.MZOSTABLICERow) ((DataRowView) this.bindingSourceMZOSTABLICE.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(MZOSTABLICEFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceMZOSTABLICE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceMZOSTABLICE).BeginInit();
            this.layoutManagerformMZOSTABLICE = new TableLayoutPanel();
            this.layoutManagerformMZOSTABLICE.SuspendLayout();
            this.layoutManagerformMZOSTABLICE.AutoSize = true;
            this.layoutManagerformMZOSTABLICE.Dock = DockStyle.Fill;
            this.layoutManagerformMZOSTABLICE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformMZOSTABLICE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformMZOSTABLICE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformMZOSTABLICE.Size = size;
            this.layoutManagerformMZOSTABLICE.ColumnCount = 2;
            this.layoutManagerformMZOSTABLICE.RowCount = 3;
            this.layoutManagerformMZOSTABLICE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformMZOSTABLICE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformMZOSTABLICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformMZOSTABLICE.RowStyles.Add(new RowStyle());
            this.layoutManagerformMZOSTABLICE.RowStyles.Add(new RowStyle());
            this.label1IDMZOSTABLICE = new UltraLabel();
            this.textIDMZOSTABLICE = new UltraNumericEditor();
            this.label1OPISMZOSTABLICE = new UltraLabel();
            this.textOPISMZOSTABLICE = new UltraTextEditor();
            ((ISupportInitialize) this.textIDMZOSTABLICE).BeginInit();
            ((ISupportInitialize) this.textOPISMZOSTABLICE).BeginInit();
            this.dsMZOSTABLICEDataSet1 = new MZOSTABLICEDataSet();
            this.dsMZOSTABLICEDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsMZOSTABLICEDataSet1.DataSetName = "dsMZOSTABLICE";
            this.dsMZOSTABLICEDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceMZOSTABLICE.DataSource = this.dsMZOSTABLICEDataSet1;
            this.bindingSourceMZOSTABLICE.DataMember = "MZOSTABLICE";
            ((ISupportInitialize) this.bindingSourceMZOSTABLICE).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDMZOSTABLICE.Location = point;
            this.label1IDMZOSTABLICE.Name = "label1IDMZOSTABLICE";
            this.label1IDMZOSTABLICE.TabIndex = 1;
            this.label1IDMZOSTABLICE.Tag = "labelIDMZOSTABLICE";
            this.label1IDMZOSTABLICE.Text = "Šifra tablice:";
            this.label1IDMZOSTABLICE.StyleSetName = "FieldUltraLabel";
            this.label1IDMZOSTABLICE.AutoSize = true;
            this.label1IDMZOSTABLICE.Anchor = AnchorStyles.Left;
            this.label1IDMZOSTABLICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDMZOSTABLICE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDMZOSTABLICE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDMZOSTABLICE.ImageSize = size;
            this.label1IDMZOSTABLICE.Appearance.ForeColor = Color.Black;
            this.label1IDMZOSTABLICE.BackColor = Color.Transparent;
            this.layoutManagerformMZOSTABLICE.Controls.Add(this.label1IDMZOSTABLICE, 0, 0);
            this.layoutManagerformMZOSTABLICE.SetColumnSpan(this.label1IDMZOSTABLICE, 1);
            this.layoutManagerformMZOSTABLICE.SetRowSpan(this.label1IDMZOSTABLICE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDMZOSTABLICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDMZOSTABLICE.MinimumSize = size;
            size = new System.Drawing.Size(90, 0x17);
            this.label1IDMZOSTABLICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDMZOSTABLICE.Location = point;
            this.textIDMZOSTABLICE.Name = "textIDMZOSTABLICE";
            this.textIDMZOSTABLICE.Tag = "IDMZOSTABLICE";
            this.textIDMZOSTABLICE.TabIndex = 0;
            this.textIDMZOSTABLICE.Anchor = AnchorStyles.Left;
            this.textIDMZOSTABLICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDMZOSTABLICE.ReadOnly = false;
            this.textIDMZOSTABLICE.PromptChar = ' ';
            this.textIDMZOSTABLICE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDMZOSTABLICE.DataBindings.Add(new Binding("Value", this.bindingSourceMZOSTABLICE, "IDMZOSTABLICE"));
            this.textIDMZOSTABLICE.NumericType = NumericType.Integer;
            this.textIDMZOSTABLICE.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformMZOSTABLICE.Controls.Add(this.textIDMZOSTABLICE, 1, 0);
            this.layoutManagerformMZOSTABLICE.SetColumnSpan(this.textIDMZOSTABLICE, 1);
            this.layoutManagerformMZOSTABLICE.SetRowSpan(this.textIDMZOSTABLICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDMZOSTABLICE.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDMZOSTABLICE.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDMZOSTABLICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISMZOSTABLICE.Location = point;
            this.label1OPISMZOSTABLICE.Name = "label1OPISMZOSTABLICE";
            this.label1OPISMZOSTABLICE.TabIndex = 1;
            this.label1OPISMZOSTABLICE.Tag = "labelOPISMZOSTABLICE";
            this.label1OPISMZOSTABLICE.Text = "Naziv tablice:";
            this.label1OPISMZOSTABLICE.StyleSetName = "FieldUltraLabel";
            this.label1OPISMZOSTABLICE.AutoSize = true;
            this.label1OPISMZOSTABLICE.Anchor = AnchorStyles.Left;
            this.label1OPISMZOSTABLICE.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISMZOSTABLICE.Appearance.ForeColor = Color.Black;
            this.label1OPISMZOSTABLICE.BackColor = Color.Transparent;
            this.layoutManagerformMZOSTABLICE.Controls.Add(this.label1OPISMZOSTABLICE, 0, 1);
            this.layoutManagerformMZOSTABLICE.SetColumnSpan(this.label1OPISMZOSTABLICE, 1);
            this.layoutManagerformMZOSTABLICE.SetRowSpan(this.label1OPISMZOSTABLICE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISMZOSTABLICE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISMZOSTABLICE.MinimumSize = size;
            size = new System.Drawing.Size(0x63, 0x17);
            this.label1OPISMZOSTABLICE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPISMZOSTABLICE.Location = point;
            this.textOPISMZOSTABLICE.Name = "textOPISMZOSTABLICE";
            this.textOPISMZOSTABLICE.Tag = "OPISMZOSTABLICE";
            this.textOPISMZOSTABLICE.TabIndex = 0;
            this.textOPISMZOSTABLICE.Anchor = AnchorStyles.Left;
            this.textOPISMZOSTABLICE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPISMZOSTABLICE.ReadOnly = false;
            this.textOPISMZOSTABLICE.DataBindings.Add(new Binding("Text", this.bindingSourceMZOSTABLICE, "OPISMZOSTABLICE"));
            this.textOPISMZOSTABLICE.MaxLength = 20;
            this.layoutManagerformMZOSTABLICE.Controls.Add(this.textOPISMZOSTABLICE, 1, 1);
            this.layoutManagerformMZOSTABLICE.SetColumnSpan(this.textOPISMZOSTABLICE, 1);
            this.layoutManagerformMZOSTABLICE.SetRowSpan(this.textOPISMZOSTABLICE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPISMZOSTABLICE.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textOPISMZOSTABLICE.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textOPISMZOSTABLICE.Size = size;
            this.Controls.Add(this.layoutManagerformMZOSTABLICE);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceMZOSTABLICE;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "MZOSTABLICEFormUserControl";
            this.Text = "MZOŠ Tablica";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.MZOSTABLICEFormUserControl_Load);
            this.layoutManagerformMZOSTABLICE.ResumeLayout(false);
            this.layoutManagerformMZOSTABLICE.PerformLayout();
            ((ISupportInitialize) this.bindingSourceMZOSTABLICE).EndInit();
            ((ISupportInitialize) this.textIDMZOSTABLICE).EndInit();
            ((ISupportInitialize) this.textOPISMZOSTABLICE).EndInit();
            this.dsMZOSTABLICEDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.MZOSTABLICEController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceMZOSTABLICE, this.MZOSTABLICEController.WorkItem, this))
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
            this.label1IDMZOSTABLICE.Text = StringResources.MZOSTABLICEIDMZOSTABLICEDescription;
            this.label1OPISMZOSTABLICE.Text = StringResources.MZOSTABLICEOPISMZOSTABLICEDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void MZOSTABLICEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.MZOSTABLICEDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.MZOSTABLICEController.WorkItem.Items.Contains("MZOSTABLICE|MZOSTABLICE"))
            {
                this.MZOSTABLICEController.WorkItem.Items.Add(this.bindingSourceMZOSTABLICE, "MZOSTABLICE|MZOSTABLICE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsMZOSTABLICEDataSet1.MZOSTABLICE.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.MZOSTABLICEController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.MZOSTABLICEController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.MZOSTABLICEController.Update(this))
            {
                this.MZOSTABLICEController.DataSet = new MZOSTABLICEDataSet();
                DataSetUtil.AddEmptyRow(this.MZOSTABLICEController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.MZOSTABLICEController.DataSet.MZOSTABLICE[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDMZOSTABLICE.Focus();
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

        protected virtual UltraLabel label1IDMZOSTABLICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDMZOSTABLICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDMZOSTABLICE = value;
            }
        }

        protected virtual UltraLabel label1OPISMZOSTABLICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISMZOSTABLICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISMZOSTABLICE = value;
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
        public NetAdvantage.Controllers.MZOSTABLICEController MZOSTABLICEController { get; set; }

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

        protected virtual UltraNumericEditor textIDMZOSTABLICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDMZOSTABLICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDMZOSTABLICE = value;
            }
        }

        protected virtual UltraTextEditor textOPISMZOSTABLICE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPISMZOSTABLICE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPISMZOSTABLICE = value;
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

