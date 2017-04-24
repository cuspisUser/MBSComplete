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
    public class IPIDENTFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDIPIDENT")]
        private UltraLabel _label1IDIPIDENT;
        [AccessedThroughProperty("label1NAZIVIPIDENT")]
        private UltraLabel _label1NAZIVIPIDENT;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDIPIDENT")]
        private UltraNumericEditor _textIDIPIDENT;
        [AccessedThroughProperty("textNAZIVIPIDENT")]
        private UltraTextEditor _textNAZIVIPIDENT;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceIPIDENT;
        private IContainer components = null;
        private IPIDENTDataSet dsIPIDENTDataSet1;
        protected TableLayoutPanel layoutManagerformIPIDENT;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private IPIDENTDataSet.IPIDENTRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "IPIDENT";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.IPIDENTDescription;
        private DeklaritMode m_Mode;

        public IPIDENTFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceIPIDENT.DataSource = this.IPIDENTController.DataSet;
            this.dsIPIDENTDataSet1 = this.IPIDENTController.DataSet;
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
                    enumerator = this.dsIPIDENTDataSet1.IPIDENT.Rows.GetEnumerator();
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
                if (this.IPIDENTController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "IPIDENT", this.m_Mode, this.dsIPIDENTDataSet1, this.dsIPIDENTDataSet1.IPIDENT.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsIPIDENTDataSet1.IPIDENT[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (IPIDENTDataSet.IPIDENTRow) ((DataRowView) this.bindingSourceIPIDENT.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(IPIDENTFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceIPIDENT = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceIPIDENT).BeginInit();
            this.layoutManagerformIPIDENT = new TableLayoutPanel();
            this.layoutManagerformIPIDENT.SuspendLayout();
            this.layoutManagerformIPIDENT.AutoSize = true;
            this.layoutManagerformIPIDENT.Dock = DockStyle.Fill;
            this.layoutManagerformIPIDENT.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformIPIDENT.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformIPIDENT.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformIPIDENT.Size = size;
            this.layoutManagerformIPIDENT.ColumnCount = 2;
            this.layoutManagerformIPIDENT.RowCount = 3;
            this.layoutManagerformIPIDENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformIPIDENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformIPIDENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformIPIDENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformIPIDENT.RowStyles.Add(new RowStyle());
            this.label1IDIPIDENT = new UltraLabel();
            this.textIDIPIDENT = new UltraNumericEditor();
            this.label1NAZIVIPIDENT = new UltraLabel();
            this.textNAZIVIPIDENT = new UltraTextEditor();
            ((ISupportInitialize) this.textIDIPIDENT).BeginInit();
            ((ISupportInitialize) this.textNAZIVIPIDENT).BeginInit();
            this.dsIPIDENTDataSet1 = new IPIDENTDataSet();
            this.dsIPIDENTDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsIPIDENTDataSet1.DataSetName = "dsIPIDENT";
            this.dsIPIDENTDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceIPIDENT.DataSource = this.dsIPIDENTDataSet1;
            this.bindingSourceIPIDENT.DataMember = "IPIDENT";
            ((ISupportInitialize) this.bindingSourceIPIDENT).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDIPIDENT.Location = point;
            this.label1IDIPIDENT.Name = "label1IDIPIDENT";
            this.label1IDIPIDENT.TabIndex = 1;
            this.label1IDIPIDENT.Tag = "labelIDIPIDENT";
            this.label1IDIPIDENT.Text = "IP Identifikator:";
            this.label1IDIPIDENT.StyleSetName = "FieldUltraLabel";
            this.label1IDIPIDENT.AutoSize = true;
            this.label1IDIPIDENT.Anchor = AnchorStyles.Left;
            this.label1IDIPIDENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDIPIDENT.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDIPIDENT.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDIPIDENT.ImageSize = size;
            this.label1IDIPIDENT.Appearance.ForeColor = Color.Black;
            this.label1IDIPIDENT.BackColor = Color.Transparent;
            this.layoutManagerformIPIDENT.Controls.Add(this.label1IDIPIDENT, 0, 0);
            this.layoutManagerformIPIDENT.SetColumnSpan(this.label1IDIPIDENT, 1);
            this.layoutManagerformIPIDENT.SetRowSpan(this.label1IDIPIDENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDIPIDENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDIPIDENT.MinimumSize = size;
            size = new System.Drawing.Size(0x71, 0x17);
            this.label1IDIPIDENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDIPIDENT.Location = point;
            this.textIDIPIDENT.Name = "textIDIPIDENT";
            this.textIDIPIDENT.Tag = "IDIPIDENT";
            this.textIDIPIDENT.TabIndex = 0;
            this.textIDIPIDENT.Anchor = AnchorStyles.Left;
            this.textIDIPIDENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDIPIDENT.ReadOnly = false;
            this.textIDIPIDENT.PromptChar = ' ';
            this.textIDIPIDENT.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDIPIDENT.DataBindings.Add(new Binding("Value", this.bindingSourceIPIDENT, "IDIPIDENT"));
            this.textIDIPIDENT.NumericType = NumericType.Integer;
            this.textIDIPIDENT.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformIPIDENT.Controls.Add(this.textIDIPIDENT, 1, 0);
            this.layoutManagerformIPIDENT.SetColumnSpan(this.textIDIPIDENT, 1);
            this.layoutManagerformIPIDENT.SetRowSpan(this.textIDIPIDENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDIPIDENT.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDIPIDENT.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDIPIDENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVIPIDENT.Location = point;
            this.label1NAZIVIPIDENT.Name = "label1NAZIVIPIDENT";
            this.label1NAZIVIPIDENT.TabIndex = 1;
            this.label1NAZIVIPIDENT.Tag = "labelNAZIVIPIDENT";
            this.label1NAZIVIPIDENT.Text = "Naziv IP identifikator:";
            this.label1NAZIVIPIDENT.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVIPIDENT.AutoSize = true;
            this.label1NAZIVIPIDENT.Anchor = AnchorStyles.Left;
            this.label1NAZIVIPIDENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVIPIDENT.Appearance.ForeColor = Color.Black;
            this.label1NAZIVIPIDENT.BackColor = Color.Transparent;
            this.layoutManagerformIPIDENT.Controls.Add(this.label1NAZIVIPIDENT, 0, 1);
            this.layoutManagerformIPIDENT.SetColumnSpan(this.label1NAZIVIPIDENT, 1);
            this.layoutManagerformIPIDENT.SetRowSpan(this.label1NAZIVIPIDENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVIPIDENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVIPIDENT.MinimumSize = size;
            size = new System.Drawing.Size(0x98, 0x17);
            this.label1NAZIVIPIDENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVIPIDENT.Location = point;
            this.textNAZIVIPIDENT.Name = "textNAZIVIPIDENT";
            this.textNAZIVIPIDENT.Tag = "NAZIVIPIDENT";
            this.textNAZIVIPIDENT.TabIndex = 0;
            this.textNAZIVIPIDENT.Anchor = AnchorStyles.Left;
            this.textNAZIVIPIDENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVIPIDENT.ReadOnly = false;
            this.textNAZIVIPIDENT.DataBindings.Add(new Binding("Text", this.bindingSourceIPIDENT, "NAZIVIPIDENT"));
            this.textNAZIVIPIDENT.MaxLength = 20;
            this.layoutManagerformIPIDENT.Controls.Add(this.textNAZIVIPIDENT, 1, 1);
            this.layoutManagerformIPIDENT.SetColumnSpan(this.textNAZIVIPIDENT, 1);
            this.layoutManagerformIPIDENT.SetRowSpan(this.textNAZIVIPIDENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVIPIDENT.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textNAZIVIPIDENT.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textNAZIVIPIDENT.Size = size;
            this.Controls.Add(this.layoutManagerformIPIDENT);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceIPIDENT;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "IPIDENTFormUserControl";
            this.Text = "IP Identifikatori";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.IPIDENTFormUserControl_Load);
            this.layoutManagerformIPIDENT.ResumeLayout(false);
            this.layoutManagerformIPIDENT.PerformLayout();
            ((ISupportInitialize) this.bindingSourceIPIDENT).EndInit();
            ((ISupportInitialize) this.textIDIPIDENT).EndInit();
            ((ISupportInitialize) this.textNAZIVIPIDENT).EndInit();
            this.dsIPIDENTDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.IPIDENTController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceIPIDENT, this.IPIDENTController.WorkItem, this))
            {
                return false;
            }
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void IPIDENTFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.IPIDENTDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void Localize()
        {
            this.label1IDIPIDENT.Text = StringResources.IPIDENTIDIPIDENTDescription;
            this.label1NAZIVIPIDENT.Text = StringResources.IPIDENTNAZIVIPIDENTDescription;
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
                this.IPIDENTController.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.IPIDENTController.WorkItem.Items.Contains("IPIDENT|IPIDENT"))
            {
                this.IPIDENTController.WorkItem.Items.Add(this.bindingSourceIPIDENT, "IPIDENT|IPIDENT");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsIPIDENTDataSet1.IPIDENT.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.IPIDENTController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.IPIDENTController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.IPIDENTController.Update(this))
            {
                this.IPIDENTController.DataSet = new IPIDENTDataSet();
                DataSetUtil.AddEmptyRow(this.IPIDENTController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.IPIDENTController.DataSet.IPIDENT[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDIPIDENT.Focus();
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
                this.IPIDENTController.ViewRADNIK(this.m_CurrentRow);
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.IPIDENTController IPIDENTController { get; set; }

        protected virtual UltraLabel label1IDIPIDENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDIPIDENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDIPIDENT = value;
            }
        }

        protected virtual UltraLabel label1NAZIVIPIDENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVIPIDENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVIPIDENT = value;
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

        protected virtual UltraNumericEditor textIDIPIDENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDIPIDENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDIPIDENT = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVIPIDENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVIPIDENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVIPIDENT = value;
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

