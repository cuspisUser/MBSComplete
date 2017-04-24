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
    public class SPOLFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDSPOL")]
        private UltraLabel _label1IDSPOL;
        [AccessedThroughProperty("label1NAZIVSPOL")]
        private UltraLabel _label1NAZIVSPOL;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDSPOL")]
        private UltraNumericEditor _textIDSPOL;
        [AccessedThroughProperty("textNAZIVSPOL")]
        private UltraTextEditor _textNAZIVSPOL;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSPOL;
        private IContainer components = null;
        private SPOLDataSet dsSPOLDataSet1;
        protected TableLayoutPanel layoutManagerformSPOL;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SPOLDataSet.SPOLRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SPOL";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.SPOLDescription;
        private DeklaritMode m_Mode;

        public SPOLFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceSPOL.DataSource = this.SPOLController.DataSet;
            this.dsSPOLDataSet1 = this.SPOLController.DataSet;
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
                    enumerator = this.dsSPOLDataSet1.SPOL.Rows.GetEnumerator();
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
                if (this.SPOLController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SPOL", this.m_Mode, this.dsSPOLDataSet1, this.dsSPOLDataSet1.SPOL.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsSPOLDataSet1.SPOL[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (SPOLDataSet.SPOLRow) ((DataRowView) this.bindingSourceSPOL.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(SPOLFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSPOL = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSPOL).BeginInit();
            this.layoutManagerformSPOL = new TableLayoutPanel();
            this.layoutManagerformSPOL.SuspendLayout();
            this.layoutManagerformSPOL.AutoSize = true;
            this.layoutManagerformSPOL.Dock = DockStyle.Fill;
            this.layoutManagerformSPOL.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSPOL.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSPOL.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSPOL.Size = size;
            this.layoutManagerformSPOL.ColumnCount = 2;
            this.layoutManagerformSPOL.RowCount = 3;
            this.layoutManagerformSPOL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSPOL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSPOL.RowStyles.Add(new RowStyle());
            this.layoutManagerformSPOL.RowStyles.Add(new RowStyle());
            this.layoutManagerformSPOL.RowStyles.Add(new RowStyle());
            this.label1IDSPOL = new UltraLabel();
            this.textIDSPOL = new UltraNumericEditor();
            this.label1NAZIVSPOL = new UltraLabel();
            this.textNAZIVSPOL = new UltraTextEditor();
            ((ISupportInitialize) this.textIDSPOL).BeginInit();
            ((ISupportInitialize) this.textNAZIVSPOL).BeginInit();
            this.dsSPOLDataSet1 = new SPOLDataSet();
            this.dsSPOLDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSPOLDataSet1.DataSetName = "dsSPOL";
            this.dsSPOLDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSPOL.DataSource = this.dsSPOLDataSet1;
            this.bindingSourceSPOL.DataMember = "SPOL";
            ((ISupportInitialize) this.bindingSourceSPOL).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDSPOL.Location = point;
            this.label1IDSPOL.Name = "label1IDSPOL";
            this.label1IDSPOL.TabIndex = 1;
            this.label1IDSPOL.Tag = "labelIDSPOL";
            this.label1IDSPOL.Text = "Šifra:";
            this.label1IDSPOL.StyleSetName = "FieldUltraLabel";
            this.label1IDSPOL.AutoSize = true;
            this.label1IDSPOL.Anchor = AnchorStyles.Left;
            this.label1IDSPOL.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDSPOL.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDSPOL.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDSPOL.ImageSize = size;
            this.label1IDSPOL.Appearance.ForeColor = Color.Black;
            this.label1IDSPOL.BackColor = Color.Transparent;
            this.layoutManagerformSPOL.Controls.Add(this.label1IDSPOL, 0, 0);
            this.layoutManagerformSPOL.SetColumnSpan(this.label1IDSPOL, 1);
            this.layoutManagerformSPOL.SetRowSpan(this.label1IDSPOL, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDSPOL.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDSPOL.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDSPOL.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDSPOL.Location = point;
            this.textIDSPOL.Name = "textIDSPOL";
            this.textIDSPOL.Tag = "IDSPOL";
            this.textIDSPOL.TabIndex = 0;
            this.textIDSPOL.Anchor = AnchorStyles.Left;
            this.textIDSPOL.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDSPOL.ReadOnly = false;
            this.textIDSPOL.PromptChar = ' ';
            this.textIDSPOL.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDSPOL.DataBindings.Add(new Binding("Value", this.bindingSourceSPOL, "IDSPOL"));
            this.textIDSPOL.NumericType = NumericType.Integer;
            this.textIDSPOL.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformSPOL.Controls.Add(this.textIDSPOL, 1, 0);
            this.layoutManagerformSPOL.SetColumnSpan(this.textIDSPOL, 1);
            this.layoutManagerformSPOL.SetRowSpan(this.textIDSPOL, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDSPOL.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSPOL.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSPOL.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVSPOL.Location = point;
            this.label1NAZIVSPOL.Name = "label1NAZIVSPOL";
            this.label1NAZIVSPOL.TabIndex = 1;
            this.label1NAZIVSPOL.Tag = "labelNAZIVSPOL";
            this.label1NAZIVSPOL.Text = "Spol:";
            this.label1NAZIVSPOL.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVSPOL.AutoSize = true;
            this.label1NAZIVSPOL.Anchor = AnchorStyles.Left;
            this.label1NAZIVSPOL.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVSPOL.Appearance.ForeColor = Color.Black;
            this.label1NAZIVSPOL.BackColor = Color.Transparent;
            this.layoutManagerformSPOL.Controls.Add(this.label1NAZIVSPOL, 0, 1);
            this.layoutManagerformSPOL.SetColumnSpan(this.label1NAZIVSPOL, 1);
            this.layoutManagerformSPOL.SetRowSpan(this.label1NAZIVSPOL, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVSPOL.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVSPOL.MinimumSize = size;
            size = new System.Drawing.Size(0x2e, 0x17);
            this.label1NAZIVSPOL.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVSPOL.Location = point;
            this.textNAZIVSPOL.Name = "textNAZIVSPOL";
            this.textNAZIVSPOL.Tag = "NAZIVSPOL";
            this.textNAZIVSPOL.TabIndex = 0;
            this.textNAZIVSPOL.Anchor = AnchorStyles.Left;
            this.textNAZIVSPOL.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVSPOL.ReadOnly = false;
            this.textNAZIVSPOL.DataBindings.Add(new Binding("Text", this.bindingSourceSPOL, "NAZIVSPOL"));
            this.textNAZIVSPOL.MaxLength = 20;
            this.layoutManagerformSPOL.Controls.Add(this.textNAZIVSPOL, 1, 1);
            this.layoutManagerformSPOL.SetColumnSpan(this.textNAZIVSPOL, 1);
            this.layoutManagerformSPOL.SetRowSpan(this.textNAZIVSPOL, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVSPOL.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textNAZIVSPOL.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textNAZIVSPOL.Size = size;
            this.Controls.Add(this.layoutManagerformSPOL);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSPOL;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "SPOLFormUserControl";
            this.Text = "Spol";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SPOLFormUserControl_Load);
            this.layoutManagerformSPOL.ResumeLayout(false);
            this.layoutManagerformSPOL.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSPOL).EndInit();
            ((ISupportInitialize) this.textIDSPOL).EndInit();
            ((ISupportInitialize) this.textNAZIVSPOL).EndInit();
            this.dsSPOLDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.SPOLController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSPOL, this.SPOLController.WorkItem, this))
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
            this.label1IDSPOL.Text = StringResources.SPOLIDSPOLDescription;
            this.label1NAZIVSPOL.Text = StringResources.SPOLNAZIVSPOLDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewRAD1VEZASPOL")]
        public void NewRAD1VEZASPOLHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SPOLController.NewRAD1VEZASPOL(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewRADNIK")]
        public void NewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SPOLController.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.SPOLController.WorkItem.Items.Contains("SPOL|SPOL"))
            {
                this.SPOLController.WorkItem.Items.Add(this.bindingSourceSPOL, "SPOL|SPOL");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsSPOLDataSet1.SPOL.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.SPOLController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.SPOLController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.SPOLController.Update(this))
            {
                this.SPOLController.DataSet = new SPOLDataSet();
                DataSetUtil.AddEmptyRow(this.SPOLController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.SPOLController.DataSet.SPOL[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDSPOL.Focus();
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

        private void SPOLFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.SPOLDescription;
            this.errorProvider1.ContainerControl = this;
        }

        [LocalCommandHandler("ViewRAD1VEZASPOL")]
        public void ViewRAD1VEZASPOLHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SPOLController.ViewRAD1VEZASPOL(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewRADNIK")]
        public void ViewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SPOLController.ViewRADNIK(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDSPOL
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDSPOL;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDSPOL = value;
            }
        }

        protected virtual UltraLabel label1NAZIVSPOL
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVSPOL;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVSPOL = value;
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
        public NetAdvantage.Controllers.SPOLController SPOLController { get; set; }

        protected virtual UltraNumericEditor textIDSPOL
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDSPOL;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDSPOL = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVSPOL
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVSPOL;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVSPOL = value;
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

