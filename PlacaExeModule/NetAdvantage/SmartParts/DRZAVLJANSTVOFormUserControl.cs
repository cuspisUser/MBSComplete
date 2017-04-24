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
    public class DRZAVLJANSTVOFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDDRZAVLJANSTVO")]
        private UltraLabel _label1IDDRZAVLJANSTVO;
        [AccessedThroughProperty("label1NAZIVDRZAVLJANSTVO")]
        private UltraLabel _label1NAZIVDRZAVLJANSTVO;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDDRZAVLJANSTVO")]
        private UltraNumericEditor _textIDDRZAVLJANSTVO;
        [AccessedThroughProperty("textNAZIVDRZAVLJANSTVO")]
        private UltraTextEditor _textNAZIVDRZAVLJANSTVO;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceDRZAVLJANSTVO;
        private IContainer components = null;
        private DRZAVLJANSTVODataSet dsDRZAVLJANSTVODataSet1;
        protected TableLayoutPanel layoutManagerformDRZAVLJANSTVO;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private DRZAVLJANSTVODataSet.DRZAVLJANSTVORow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "DRZAVLJANSTVO";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.DRZAVLJANSTVODescription;
        private DeklaritMode m_Mode;

        public DRZAVLJANSTVOFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceDRZAVLJANSTVO.DataSource = this.DRZAVLJANSTVOController.DataSet;
            this.dsDRZAVLJANSTVODataSet1 = this.DRZAVLJANSTVOController.DataSet;
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
                    enumerator = this.dsDRZAVLJANSTVODataSet1.DRZAVLJANSTVO.Rows.GetEnumerator();
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
                if (this.DRZAVLJANSTVOController.Update(this))
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

        private void DRZAVLJANSTVOFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.DRZAVLJANSTVODescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "DRZAVLJANSTVO", this.m_Mode, this.dsDRZAVLJANSTVODataSet1, this.dsDRZAVLJANSTVODataSet1.DRZAVLJANSTVO.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsDRZAVLJANSTVODataSet1.DRZAVLJANSTVO[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (DRZAVLJANSTVODataSet.DRZAVLJANSTVORow) ((DataRowView) this.bindingSourceDRZAVLJANSTVO.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(DRZAVLJANSTVOFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceDRZAVLJANSTVO = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDRZAVLJANSTVO).BeginInit();
            this.layoutManagerformDRZAVLJANSTVO = new TableLayoutPanel();
            this.layoutManagerformDRZAVLJANSTVO.SuspendLayout();
            this.layoutManagerformDRZAVLJANSTVO.AutoSize = true;
            this.layoutManagerformDRZAVLJANSTVO.Dock = DockStyle.Fill;
            this.layoutManagerformDRZAVLJANSTVO.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformDRZAVLJANSTVO.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformDRZAVLJANSTVO.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformDRZAVLJANSTVO.Size = size;
            this.layoutManagerformDRZAVLJANSTVO.ColumnCount = 2;
            this.layoutManagerformDRZAVLJANSTVO.RowCount = 3;
            this.layoutManagerformDRZAVLJANSTVO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDRZAVLJANSTVO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDRZAVLJANSTVO.RowStyles.Add(new RowStyle());
            this.layoutManagerformDRZAVLJANSTVO.RowStyles.Add(new RowStyle());
            this.layoutManagerformDRZAVLJANSTVO.RowStyles.Add(new RowStyle());
            this.label1IDDRZAVLJANSTVO = new UltraLabel();
            this.textIDDRZAVLJANSTVO = new UltraNumericEditor();
            this.label1NAZIVDRZAVLJANSTVO = new UltraLabel();
            this.textNAZIVDRZAVLJANSTVO = new UltraTextEditor();
            ((ISupportInitialize) this.textIDDRZAVLJANSTVO).BeginInit();
            ((ISupportInitialize) this.textNAZIVDRZAVLJANSTVO).BeginInit();
            this.dsDRZAVLJANSTVODataSet1 = new DRZAVLJANSTVODataSet();
            this.dsDRZAVLJANSTVODataSet1.BeginInit();
            this.SuspendLayout();
            this.dsDRZAVLJANSTVODataSet1.DataSetName = "dsDRZAVLJANSTVO";
            this.dsDRZAVLJANSTVODataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceDRZAVLJANSTVO.DataSource = this.dsDRZAVLJANSTVODataSet1;
            this.bindingSourceDRZAVLJANSTVO.DataMember = "DRZAVLJANSTVO";
            ((ISupportInitialize) this.bindingSourceDRZAVLJANSTVO).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDDRZAVLJANSTVO.Location = point;
            this.label1IDDRZAVLJANSTVO.Name = "label1IDDRZAVLJANSTVO";
            this.label1IDDRZAVLJANSTVO.TabIndex = 1;
            this.label1IDDRZAVLJANSTVO.Tag = "labelIDDRZAVLJANSTVO";
            this.label1IDDRZAVLJANSTVO.Text = "Šifra:";
            this.label1IDDRZAVLJANSTVO.StyleSetName = "FieldUltraLabel";
            this.label1IDDRZAVLJANSTVO.AutoSize = true;
            this.label1IDDRZAVLJANSTVO.Anchor = AnchorStyles.Left;
            this.label1IDDRZAVLJANSTVO.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDDRZAVLJANSTVO.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDDRZAVLJANSTVO.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDDRZAVLJANSTVO.ImageSize = size;
            this.label1IDDRZAVLJANSTVO.Appearance.ForeColor = Color.Black;
            this.label1IDDRZAVLJANSTVO.BackColor = Color.Transparent;
            this.layoutManagerformDRZAVLJANSTVO.Controls.Add(this.label1IDDRZAVLJANSTVO, 0, 0);
            this.layoutManagerformDRZAVLJANSTVO.SetColumnSpan(this.label1IDDRZAVLJANSTVO, 1);
            this.layoutManagerformDRZAVLJANSTVO.SetRowSpan(this.label1IDDRZAVLJANSTVO, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDDRZAVLJANSTVO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDDRZAVLJANSTVO.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDDRZAVLJANSTVO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDDRZAVLJANSTVO.Location = point;
            this.textIDDRZAVLJANSTVO.Name = "textIDDRZAVLJANSTVO";
            this.textIDDRZAVLJANSTVO.Tag = "IDDRZAVLJANSTVO";
            this.textIDDRZAVLJANSTVO.TabIndex = 0;
            this.textIDDRZAVLJANSTVO.Anchor = AnchorStyles.Left;
            this.textIDDRZAVLJANSTVO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDDRZAVLJANSTVO.ReadOnly = false;
            this.textIDDRZAVLJANSTVO.PromptChar = ' ';
            this.textIDDRZAVLJANSTVO.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDDRZAVLJANSTVO.DataBindings.Add(new Binding("Value", this.bindingSourceDRZAVLJANSTVO, "IDDRZAVLJANSTVO"));
            this.textIDDRZAVLJANSTVO.NumericType = NumericType.Integer;
            this.textIDDRZAVLJANSTVO.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformDRZAVLJANSTVO.Controls.Add(this.textIDDRZAVLJANSTVO, 1, 0);
            this.layoutManagerformDRZAVLJANSTVO.SetColumnSpan(this.textIDDRZAVLJANSTVO, 1);
            this.layoutManagerformDRZAVLJANSTVO.SetRowSpan(this.textIDDRZAVLJANSTVO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDDRZAVLJANSTVO.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDDRZAVLJANSTVO.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDDRZAVLJANSTVO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVDRZAVLJANSTVO.Location = point;
            this.label1NAZIVDRZAVLJANSTVO.Name = "label1NAZIVDRZAVLJANSTVO";
            this.label1NAZIVDRZAVLJANSTVO.TabIndex = 1;
            this.label1NAZIVDRZAVLJANSTVO.Tag = "labelNAZIVDRZAVLJANSTVO";
            this.label1NAZIVDRZAVLJANSTVO.Text = "Drzavljanstvo:";
            this.label1NAZIVDRZAVLJANSTVO.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVDRZAVLJANSTVO.AutoSize = true;
            this.label1NAZIVDRZAVLJANSTVO.Anchor = AnchorStyles.Left;
            this.label1NAZIVDRZAVLJANSTVO.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVDRZAVLJANSTVO.Appearance.ForeColor = Color.Black;
            this.label1NAZIVDRZAVLJANSTVO.BackColor = Color.Transparent;
            this.layoutManagerformDRZAVLJANSTVO.Controls.Add(this.label1NAZIVDRZAVLJANSTVO, 0, 1);
            this.layoutManagerformDRZAVLJANSTVO.SetColumnSpan(this.label1NAZIVDRZAVLJANSTVO, 1);
            this.layoutManagerformDRZAVLJANSTVO.SetRowSpan(this.label1NAZIVDRZAVLJANSTVO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVDRZAVLJANSTVO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVDRZAVLJANSTVO.MinimumSize = size;
            size = new System.Drawing.Size(0x69, 0x17);
            this.label1NAZIVDRZAVLJANSTVO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVDRZAVLJANSTVO.Location = point;
            this.textNAZIVDRZAVLJANSTVO.Name = "textNAZIVDRZAVLJANSTVO";
            this.textNAZIVDRZAVLJANSTVO.Tag = "NAZIVDRZAVLJANSTVO";
            this.textNAZIVDRZAVLJANSTVO.TabIndex = 0;
            this.textNAZIVDRZAVLJANSTVO.Anchor = AnchorStyles.Left;
            this.textNAZIVDRZAVLJANSTVO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVDRZAVLJANSTVO.ReadOnly = false;
            this.textNAZIVDRZAVLJANSTVO.DataBindings.Add(new Binding("Text", this.bindingSourceDRZAVLJANSTVO, "NAZIVDRZAVLJANSTVO"));
            this.textNAZIVDRZAVLJANSTVO.MaxLength = 50;
            this.layoutManagerformDRZAVLJANSTVO.Controls.Add(this.textNAZIVDRZAVLJANSTVO, 1, 1);
            this.layoutManagerformDRZAVLJANSTVO.SetColumnSpan(this.textNAZIVDRZAVLJANSTVO, 1);
            this.layoutManagerformDRZAVLJANSTVO.SetRowSpan(this.textNAZIVDRZAVLJANSTVO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVDRZAVLJANSTVO.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVDRZAVLJANSTVO.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVDRZAVLJANSTVO.Size = size;
            this.Controls.Add(this.layoutManagerformDRZAVLJANSTVO);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceDRZAVLJANSTVO;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "DRZAVLJANSTVOFormUserControl";
            this.Text = "Državljanstvo";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.DRZAVLJANSTVOFormUserControl_Load);
            this.layoutManagerformDRZAVLJANSTVO.ResumeLayout(false);
            this.layoutManagerformDRZAVLJANSTVO.PerformLayout();
            ((ISupportInitialize) this.bindingSourceDRZAVLJANSTVO).EndInit();
            ((ISupportInitialize) this.textIDDRZAVLJANSTVO).EndInit();
            ((ISupportInitialize) this.textNAZIVDRZAVLJANSTVO).EndInit();
            this.dsDRZAVLJANSTVODataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.DRZAVLJANSTVOController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceDRZAVLJANSTVO, this.DRZAVLJANSTVOController.WorkItem, this))
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
            this.label1IDDRZAVLJANSTVO.Text = StringResources.DRZAVLJANSTVOIDDRZAVLJANSTVODescription;
            this.label1NAZIVDRZAVLJANSTVO.Text = StringResources.DRZAVLJANSTVONAZIVDRZAVLJANSTVODescription;
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
                this.DRZAVLJANSTVOController.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.DRZAVLJANSTVOController.WorkItem.Items.Contains("DRZAVLJANSTVO|DRZAVLJANSTVO"))
            {
                this.DRZAVLJANSTVOController.WorkItem.Items.Add(this.bindingSourceDRZAVLJANSTVO, "DRZAVLJANSTVO|DRZAVLJANSTVO");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsDRZAVLJANSTVODataSet1.DRZAVLJANSTVO.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.DRZAVLJANSTVOController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DRZAVLJANSTVOController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DRZAVLJANSTVOController.Update(this))
            {
                this.DRZAVLJANSTVOController.DataSet = new DRZAVLJANSTVODataSet();
                DataSetUtil.AddEmptyRow(this.DRZAVLJANSTVOController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.DRZAVLJANSTVOController.DataSet.DRZAVLJANSTVO[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDDRZAVLJANSTVO.Focus();
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
                this.DRZAVLJANSTVOController.ViewRADNIK(this.m_CurrentRow);
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.DRZAVLJANSTVOController DRZAVLJANSTVOController { get; set; }

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

        protected virtual UltraLabel label1IDDRZAVLJANSTVO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDDRZAVLJANSTVO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDDRZAVLJANSTVO = value;
            }
        }

        protected virtual UltraLabel label1NAZIVDRZAVLJANSTVO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVDRZAVLJANSTVO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVDRZAVLJANSTVO = value;
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

        protected virtual UltraNumericEditor textIDDRZAVLJANSTVO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDDRZAVLJANSTVO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDDRZAVLJANSTVO = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVDRZAVLJANSTVO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVDRZAVLJANSTVO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVDRZAVLJANSTVO = value;
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

