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
    public class STRUCNASPREMAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDSTRUCNASPREMA")]
        private UltraLabel _label1IDSTRUCNASPREMA;
        [AccessedThroughProperty("label1NAZIVSTRUCNASPREMA")]
        private UltraLabel _label1NAZIVSTRUCNASPREMA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDSTRUCNASPREMA")]
        private UltraNumericEditor _textIDSTRUCNASPREMA;
        [AccessedThroughProperty("textNAZIVSTRUCNASPREMA")]
        private UltraTextEditor _textNAZIVSTRUCNASPREMA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSTRUCNASPREMA;
        private IContainer components = null;
        private STRUCNASPREMADataSet dsSTRUCNASPREMADataSet1;
        protected TableLayoutPanel layoutManagerformSTRUCNASPREMA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private STRUCNASPREMADataSet.STRUCNASPREMARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "STRUCNASPREMA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.STRUCNASPREMADescription;
        private DeklaritMode m_Mode;

        public STRUCNASPREMAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceSTRUCNASPREMA.DataSource = this.STRUCNASPREMAController.DataSet;
            this.dsSTRUCNASPREMADataSet1 = this.STRUCNASPREMAController.DataSet;
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
                    enumerator = this.dsSTRUCNASPREMADataSet1.STRUCNASPREMA.Rows.GetEnumerator();
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
                if (this.STRUCNASPREMAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "STRUCNASPREMA", this.m_Mode, this.dsSTRUCNASPREMADataSet1, this.dsSTRUCNASPREMADataSet1.STRUCNASPREMA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsSTRUCNASPREMADataSet1.STRUCNASPREMA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (STRUCNASPREMADataSet.STRUCNASPREMARow) ((DataRowView) this.bindingSourceSTRUCNASPREMA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(STRUCNASPREMAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSTRUCNASPREMA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSTRUCNASPREMA).BeginInit();
            this.layoutManagerformSTRUCNASPREMA = new TableLayoutPanel();
            this.layoutManagerformSTRUCNASPREMA.SuspendLayout();
            this.layoutManagerformSTRUCNASPREMA.AutoSize = true;
            this.layoutManagerformSTRUCNASPREMA.Dock = DockStyle.Fill;
            this.layoutManagerformSTRUCNASPREMA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSTRUCNASPREMA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSTRUCNASPREMA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSTRUCNASPREMA.Size = size;
            this.layoutManagerformSTRUCNASPREMA.ColumnCount = 2;
            this.layoutManagerformSTRUCNASPREMA.RowCount = 3;
            this.layoutManagerformSTRUCNASPREMA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSTRUCNASPREMA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSTRUCNASPREMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSTRUCNASPREMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSTRUCNASPREMA.RowStyles.Add(new RowStyle());
            this.label1IDSTRUCNASPREMA = new UltraLabel();
            this.textIDSTRUCNASPREMA = new UltraNumericEditor();
            this.label1NAZIVSTRUCNASPREMA = new UltraLabel();
            this.textNAZIVSTRUCNASPREMA = new UltraTextEditor();
            ((ISupportInitialize) this.textIDSTRUCNASPREMA).BeginInit();
            ((ISupportInitialize) this.textNAZIVSTRUCNASPREMA).BeginInit();
            this.dsSTRUCNASPREMADataSet1 = new STRUCNASPREMADataSet();
            this.dsSTRUCNASPREMADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSTRUCNASPREMADataSet1.DataSetName = "dsSTRUCNASPREMA";
            this.dsSTRUCNASPREMADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSTRUCNASPREMA.DataSource = this.dsSTRUCNASPREMADataSet1;
            this.bindingSourceSTRUCNASPREMA.DataMember = "STRUCNASPREMA";
            ((ISupportInitialize) this.bindingSourceSTRUCNASPREMA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDSTRUCNASPREMA.Location = point;
            this.label1IDSTRUCNASPREMA.Name = "label1IDSTRUCNASPREMA";
            this.label1IDSTRUCNASPREMA.TabIndex = 1;
            this.label1IDSTRUCNASPREMA.Tag = "labelIDSTRUCNASPREMA";
            this.label1IDSTRUCNASPREMA.Text = "Šifra stručne spreme:";
            this.label1IDSTRUCNASPREMA.StyleSetName = "FieldUltraLabel";
            this.label1IDSTRUCNASPREMA.AutoSize = true;
            this.label1IDSTRUCNASPREMA.Anchor = AnchorStyles.Left;
            this.label1IDSTRUCNASPREMA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDSTRUCNASPREMA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDSTRUCNASPREMA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDSTRUCNASPREMA.ImageSize = size;
            this.label1IDSTRUCNASPREMA.Appearance.ForeColor = Color.Black;
            this.label1IDSTRUCNASPREMA.BackColor = Color.Transparent;
            this.layoutManagerformSTRUCNASPREMA.Controls.Add(this.label1IDSTRUCNASPREMA, 0, 0);
            this.layoutManagerformSTRUCNASPREMA.SetColumnSpan(this.label1IDSTRUCNASPREMA, 1);
            this.layoutManagerformSTRUCNASPREMA.SetRowSpan(this.label1IDSTRUCNASPREMA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDSTRUCNASPREMA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDSTRUCNASPREMA.MinimumSize = size;
            size = new System.Drawing.Size(0x91, 0x17);
            this.label1IDSTRUCNASPREMA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDSTRUCNASPREMA.Location = point;
            this.textIDSTRUCNASPREMA.Name = "textIDSTRUCNASPREMA";
            this.textIDSTRUCNASPREMA.Tag = "IDSTRUCNASPREMA";
            this.textIDSTRUCNASPREMA.TabIndex = 0;
            this.textIDSTRUCNASPREMA.Anchor = AnchorStyles.Left;
            this.textIDSTRUCNASPREMA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDSTRUCNASPREMA.ReadOnly = false;
            this.textIDSTRUCNASPREMA.PromptChar = ' ';
            this.textIDSTRUCNASPREMA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDSTRUCNASPREMA.DataBindings.Add(new Binding("Value", this.bindingSourceSTRUCNASPREMA, "IDSTRUCNASPREMA"));
            this.textIDSTRUCNASPREMA.NumericType = NumericType.Integer;
            this.textIDSTRUCNASPREMA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformSTRUCNASPREMA.Controls.Add(this.textIDSTRUCNASPREMA, 1, 0);
            this.layoutManagerformSTRUCNASPREMA.SetColumnSpan(this.textIDSTRUCNASPREMA, 1);
            this.layoutManagerformSTRUCNASPREMA.SetRowSpan(this.textIDSTRUCNASPREMA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDSTRUCNASPREMA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSTRUCNASPREMA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSTRUCNASPREMA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVSTRUCNASPREMA.Location = point;
            this.label1NAZIVSTRUCNASPREMA.Name = "label1NAZIVSTRUCNASPREMA";
            this.label1NAZIVSTRUCNASPREMA.TabIndex = 1;
            this.label1NAZIVSTRUCNASPREMA.Tag = "labelNAZIVSTRUCNASPREMA";
            this.label1NAZIVSTRUCNASPREMA.Text = "Naziv stručne spreme:";
            this.label1NAZIVSTRUCNASPREMA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVSTRUCNASPREMA.AutoSize = true;
            this.label1NAZIVSTRUCNASPREMA.Anchor = AnchorStyles.Left;
            this.label1NAZIVSTRUCNASPREMA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVSTRUCNASPREMA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVSTRUCNASPREMA.BackColor = Color.Transparent;
            this.layoutManagerformSTRUCNASPREMA.Controls.Add(this.label1NAZIVSTRUCNASPREMA, 0, 1);
            this.layoutManagerformSTRUCNASPREMA.SetColumnSpan(this.label1NAZIVSTRUCNASPREMA, 1);
            this.layoutManagerformSTRUCNASPREMA.SetRowSpan(this.label1NAZIVSTRUCNASPREMA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVSTRUCNASPREMA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVSTRUCNASPREMA.MinimumSize = size;
            size = new System.Drawing.Size(0x99, 0x17);
            this.label1NAZIVSTRUCNASPREMA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVSTRUCNASPREMA.Location = point;
            this.textNAZIVSTRUCNASPREMA.Name = "textNAZIVSTRUCNASPREMA";
            this.textNAZIVSTRUCNASPREMA.Tag = "NAZIVSTRUCNASPREMA";
            this.textNAZIVSTRUCNASPREMA.TabIndex = 0;
            this.textNAZIVSTRUCNASPREMA.Anchor = AnchorStyles.Left;
            this.textNAZIVSTRUCNASPREMA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVSTRUCNASPREMA.ReadOnly = false;
            this.textNAZIVSTRUCNASPREMA.DataBindings.Add(new Binding("Text", this.bindingSourceSTRUCNASPREMA, "NAZIVSTRUCNASPREMA"));
            this.textNAZIVSTRUCNASPREMA.MaxLength = 50;
            this.layoutManagerformSTRUCNASPREMA.Controls.Add(this.textNAZIVSTRUCNASPREMA, 1, 1);
            this.layoutManagerformSTRUCNASPREMA.SetColumnSpan(this.textNAZIVSTRUCNASPREMA, 1);
            this.layoutManagerformSTRUCNASPREMA.SetRowSpan(this.textNAZIVSTRUCNASPREMA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVSTRUCNASPREMA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVSTRUCNASPREMA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVSTRUCNASPREMA.Size = size;
            this.Controls.Add(this.layoutManagerformSTRUCNASPREMA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSTRUCNASPREMA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "STRUCNASPREMAFormUserControl";
            this.Text = "Struene spreme";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.STRUCNASPREMAFormUserControl_Load);
            this.layoutManagerformSTRUCNASPREMA.ResumeLayout(false);
            this.layoutManagerformSTRUCNASPREMA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSTRUCNASPREMA).EndInit();
            ((ISupportInitialize) this.textIDSTRUCNASPREMA).EndInit();
            ((ISupportInitialize) this.textNAZIVSTRUCNASPREMA).EndInit();
            this.dsSTRUCNASPREMADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.STRUCNASPREMAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSTRUCNASPREMA, this.STRUCNASPREMAController.WorkItem, this))
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
            this.label1IDSTRUCNASPREMA.Text = StringResources.STRUCNASPREMAIDSTRUCNASPREMADescription;
            this.label1NAZIVSTRUCNASPREMA.Text = StringResources.STRUCNASPREMANAZIVSTRUCNASPREMADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewRAD1SPREMEVEZA")]
        public void NewRAD1SPREMEVEZAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.STRUCNASPREMAController.NewRAD1SPREMEVEZA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewRADNIK1")]
        public void NewRADNIK1Handler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.STRUCNASPREMAController.NewRADNIK1(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewRADNIK")]
        public void NewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.STRUCNASPREMAController.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.STRUCNASPREMAController.WorkItem.Items.Contains("STRUCNASPREMA|STRUCNASPREMA"))
            {
                this.STRUCNASPREMAController.WorkItem.Items.Add(this.bindingSourceSTRUCNASPREMA, "STRUCNASPREMA|STRUCNASPREMA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsSTRUCNASPREMADataSet1.STRUCNASPREMA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.STRUCNASPREMAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.STRUCNASPREMAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.STRUCNASPREMAController.Update(this))
            {
                this.STRUCNASPREMAController.DataSet = new STRUCNASPREMADataSet();
                DataSetUtil.AddEmptyRow(this.STRUCNASPREMAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.STRUCNASPREMAController.DataSet.STRUCNASPREMA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDSTRUCNASPREMA.Focus();
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

        private void STRUCNASPREMAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.STRUCNASPREMADescription;
            this.errorProvider1.ContainerControl = this;
        }

        [LocalCommandHandler("ViewRAD1SPREMEVEZA")]
        public void ViewRAD1SPREMEVEZAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.STRUCNASPREMAController.ViewRAD1SPREMEVEZA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewRADNIK1")]
        public void ViewRADNIK1Handler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.STRUCNASPREMAController.ViewRADNIK1(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewRADNIK")]
        public void ViewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.STRUCNASPREMAController.ViewRADNIK(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDSTRUCNASPREMA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDSTRUCNASPREMA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDSTRUCNASPREMA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVSTRUCNASPREMA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVSTRUCNASPREMA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVSTRUCNASPREMA = value;
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
        public NetAdvantage.Controllers.STRUCNASPREMAController STRUCNASPREMAController { get; set; }

        protected virtual UltraNumericEditor textIDSTRUCNASPREMA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDSTRUCNASPREMA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDSTRUCNASPREMA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVSTRUCNASPREMA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVSTRUCNASPREMA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVSTRUCNASPREMA = value;
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

