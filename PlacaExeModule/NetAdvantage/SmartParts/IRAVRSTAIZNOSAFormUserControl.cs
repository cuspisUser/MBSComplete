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
    public class IRAVRSTAIZNOSAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDIRAVRSTAIZNOSA")]
        private UltraLabel _label1IDIRAVRSTAIZNOSA;
        [AccessedThroughProperty("label1IRAVRSTAIZNOSANAZIV")]
        private UltraLabel _label1IRAVRSTAIZNOSANAZIV;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDIRAVRSTAIZNOSA")]
        private UltraNumericEditor _textIDIRAVRSTAIZNOSA;
        [AccessedThroughProperty("textIRAVRSTAIZNOSANAZIV")]
        private UltraTextEditor _textIRAVRSTAIZNOSANAZIV;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceIRAVRSTAIZNOSA;
        private IContainer components = null;
        private IRAVRSTAIZNOSADataSet dsIRAVRSTAIZNOSADataSet1;
        protected TableLayoutPanel layoutManagerformIRAVRSTAIZNOSA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "IRAVRSTAIZNOSA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.IRAVRSTAIZNOSADescription;
        private DeklaritMode m_Mode;

        public IRAVRSTAIZNOSAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceIRAVRSTAIZNOSA.DataSource = this.IRAVRSTAIZNOSAController.DataSet;
            this.dsIRAVRSTAIZNOSADataSet1 = this.IRAVRSTAIZNOSAController.DataSet;
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
                    enumerator = this.dsIRAVRSTAIZNOSADataSet1.IRAVRSTAIZNOSA.Rows.GetEnumerator();
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
                if (this.IRAVRSTAIZNOSAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "IRAVRSTAIZNOSA", this.m_Mode, this.dsIRAVRSTAIZNOSADataSet1, this.dsIRAVRSTAIZNOSADataSet1.IRAVRSTAIZNOSA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsIRAVRSTAIZNOSADataSet1.IRAVRSTAIZNOSA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (IRAVRSTAIZNOSADataSet.IRAVRSTAIZNOSARow) ((DataRowView) this.bindingSourceIRAVRSTAIZNOSA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(IRAVRSTAIZNOSAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceIRAVRSTAIZNOSA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceIRAVRSTAIZNOSA).BeginInit();
            this.layoutManagerformIRAVRSTAIZNOSA = new TableLayoutPanel();
            this.layoutManagerformIRAVRSTAIZNOSA.SuspendLayout();
            this.layoutManagerformIRAVRSTAIZNOSA.AutoSize = true;
            this.layoutManagerformIRAVRSTAIZNOSA.Dock = DockStyle.Fill;
            this.layoutManagerformIRAVRSTAIZNOSA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformIRAVRSTAIZNOSA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformIRAVRSTAIZNOSA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformIRAVRSTAIZNOSA.Size = size;
            this.layoutManagerformIRAVRSTAIZNOSA.ColumnCount = 2;
            this.layoutManagerformIRAVRSTAIZNOSA.RowCount = 3;
            this.layoutManagerformIRAVRSTAIZNOSA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformIRAVRSTAIZNOSA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformIRAVRSTAIZNOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformIRAVRSTAIZNOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformIRAVRSTAIZNOSA.RowStyles.Add(new RowStyle());
            this.label1IDIRAVRSTAIZNOSA = new UltraLabel();
            this.textIDIRAVRSTAIZNOSA = new UltraNumericEditor();
            this.label1IRAVRSTAIZNOSANAZIV = new UltraLabel();
            this.textIRAVRSTAIZNOSANAZIV = new UltraTextEditor();
            ((ISupportInitialize) this.textIDIRAVRSTAIZNOSA).BeginInit();
            ((ISupportInitialize) this.textIRAVRSTAIZNOSANAZIV).BeginInit();
            this.dsIRAVRSTAIZNOSADataSet1 = new IRAVRSTAIZNOSADataSet();
            this.dsIRAVRSTAIZNOSADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsIRAVRSTAIZNOSADataSet1.DataSetName = "dsIRAVRSTAIZNOSA";
            this.dsIRAVRSTAIZNOSADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceIRAVRSTAIZNOSA.DataSource = this.dsIRAVRSTAIZNOSADataSet1;
            this.bindingSourceIRAVRSTAIZNOSA.DataMember = "IRAVRSTAIZNOSA";
            ((ISupportInitialize) this.bindingSourceIRAVRSTAIZNOSA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDIRAVRSTAIZNOSA.Location = point;
            this.label1IDIRAVRSTAIZNOSA.Name = "label1IDIRAVRSTAIZNOSA";
            this.label1IDIRAVRSTAIZNOSA.TabIndex = 1;
            this.label1IDIRAVRSTAIZNOSA.Tag = "labelIDIRAVRSTAIZNOSA";
            this.label1IDIRAVRSTAIZNOSA.Text = "IDIRAVRSTAIZNOSA:";
            this.label1IDIRAVRSTAIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1IDIRAVRSTAIZNOSA.AutoSize = true;
            this.label1IDIRAVRSTAIZNOSA.Anchor = AnchorStyles.Left;
            this.label1IDIRAVRSTAIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDIRAVRSTAIZNOSA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDIRAVRSTAIZNOSA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDIRAVRSTAIZNOSA.ImageSize = size;
            this.label1IDIRAVRSTAIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1IDIRAVRSTAIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformIRAVRSTAIZNOSA.Controls.Add(this.label1IDIRAVRSTAIZNOSA, 0, 0);
            this.layoutManagerformIRAVRSTAIZNOSA.SetColumnSpan(this.label1IDIRAVRSTAIZNOSA, 1);
            this.layoutManagerformIRAVRSTAIZNOSA.SetRowSpan(this.label1IDIRAVRSTAIZNOSA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDIRAVRSTAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDIRAVRSTAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x91, 0x17);
            this.label1IDIRAVRSTAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDIRAVRSTAIZNOSA.Location = point;
            this.textIDIRAVRSTAIZNOSA.Name = "textIDIRAVRSTAIZNOSA";
            this.textIDIRAVRSTAIZNOSA.Tag = "IDIRAVRSTAIZNOSA";
            this.textIDIRAVRSTAIZNOSA.TabIndex = 0;
            this.textIDIRAVRSTAIZNOSA.Anchor = AnchorStyles.Left;
            this.textIDIRAVRSTAIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDIRAVRSTAIZNOSA.ReadOnly = false;
            this.textIDIRAVRSTAIZNOSA.PromptChar = ' ';
            this.textIDIRAVRSTAIZNOSA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDIRAVRSTAIZNOSA.DataBindings.Add(new Binding("Value", this.bindingSourceIRAVRSTAIZNOSA, "IDIRAVRSTAIZNOSA"));
            this.textIDIRAVRSTAIZNOSA.NumericType = NumericType.Integer;
            this.textIDIRAVRSTAIZNOSA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformIRAVRSTAIZNOSA.Controls.Add(this.textIDIRAVRSTAIZNOSA, 1, 0);
            this.layoutManagerformIRAVRSTAIZNOSA.SetColumnSpan(this.textIDIRAVRSTAIZNOSA, 1);
            this.layoutManagerformIRAVRSTAIZNOSA.SetRowSpan(this.textIDIRAVRSTAIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDIRAVRSTAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDIRAVRSTAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDIRAVRSTAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IRAVRSTAIZNOSANAZIV.Location = point;
            this.label1IRAVRSTAIZNOSANAZIV.Name = "label1IRAVRSTAIZNOSANAZIV";
            this.label1IRAVRSTAIZNOSANAZIV.TabIndex = 1;
            this.label1IRAVRSTAIZNOSANAZIV.Tag = "labelIRAVRSTAIZNOSANAZIV";
            this.label1IRAVRSTAIZNOSANAZIV.Text = "IRAVRSTAIZNOSANAZIV:";
            this.label1IRAVRSTAIZNOSANAZIV.StyleSetName = "FieldUltraLabel";
            this.label1IRAVRSTAIZNOSANAZIV.AutoSize = true;
            this.label1IRAVRSTAIZNOSANAZIV.Anchor = AnchorStyles.Left;
            this.label1IRAVRSTAIZNOSANAZIV.Appearance.TextVAlign = VAlign.Middle;
            this.label1IRAVRSTAIZNOSANAZIV.Appearance.ForeColor = Color.Black;
            this.label1IRAVRSTAIZNOSANAZIV.BackColor = Color.Transparent;
            this.layoutManagerformIRAVRSTAIZNOSA.Controls.Add(this.label1IRAVRSTAIZNOSANAZIV, 0, 1);
            this.layoutManagerformIRAVRSTAIZNOSA.SetColumnSpan(this.label1IRAVRSTAIZNOSANAZIV, 1);
            this.layoutManagerformIRAVRSTAIZNOSA.SetRowSpan(this.label1IRAVRSTAIZNOSANAZIV, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IRAVRSTAIZNOSANAZIV.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IRAVRSTAIZNOSANAZIV.MinimumSize = size;
            size = new System.Drawing.Size(0xad, 0x17);
            this.label1IRAVRSTAIZNOSANAZIV.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIRAVRSTAIZNOSANAZIV.Location = point;
            this.textIRAVRSTAIZNOSANAZIV.Name = "textIRAVRSTAIZNOSANAZIV";
            this.textIRAVRSTAIZNOSANAZIV.Tag = "IRAVRSTAIZNOSANAZIV";
            this.textIRAVRSTAIZNOSANAZIV.TabIndex = 0;
            this.textIRAVRSTAIZNOSANAZIV.Anchor = AnchorStyles.Left;
            this.textIRAVRSTAIZNOSANAZIV.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIRAVRSTAIZNOSANAZIV.ReadOnly = false;
            this.textIRAVRSTAIZNOSANAZIV.DataBindings.Add(new Binding("Text", this.bindingSourceIRAVRSTAIZNOSA, "IRAVRSTAIZNOSANAZIV"));
            this.textIRAVRSTAIZNOSANAZIV.MaxLength = 30;
            this.layoutManagerformIRAVRSTAIZNOSA.Controls.Add(this.textIRAVRSTAIZNOSANAZIV, 1, 1);
            this.layoutManagerformIRAVRSTAIZNOSA.SetColumnSpan(this.textIRAVRSTAIZNOSANAZIV, 1);
            this.layoutManagerformIRAVRSTAIZNOSA.SetRowSpan(this.textIRAVRSTAIZNOSANAZIV, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIRAVRSTAIZNOSANAZIV.Margin = padding;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textIRAVRSTAIZNOSANAZIV.MinimumSize = size;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textIRAVRSTAIZNOSANAZIV.Size = size;
            this.Controls.Add(this.layoutManagerformIRAVRSTAIZNOSA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceIRAVRSTAIZNOSA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "IRAVRSTAIZNOSAFormUserControl";
            this.Text = "Vrste iznosa IRA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.IRAVRSTAIZNOSAFormUserControl_Load);
            this.layoutManagerformIRAVRSTAIZNOSA.ResumeLayout(false);
            this.layoutManagerformIRAVRSTAIZNOSA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceIRAVRSTAIZNOSA).EndInit();
            ((ISupportInitialize) this.textIDIRAVRSTAIZNOSA).EndInit();
            ((ISupportInitialize) this.textIRAVRSTAIZNOSANAZIV).EndInit();
            this.dsIRAVRSTAIZNOSADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.IRAVRSTAIZNOSAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceIRAVRSTAIZNOSA, this.IRAVRSTAIZNOSAController.WorkItem, this))
            {
                return false;
            }
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void IRAVRSTAIZNOSAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.IRAVRSTAIZNOSADescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void Localize()
        {
            this.label1IDIRAVRSTAIZNOSA.Text = StringResources.IRAVRSTAIZNOSAIDIRAVRSTAIZNOSADescription;
            this.label1IRAVRSTAIZNOSANAZIV.Text = StringResources.IRAVRSTAIZNOSAIRAVRSTAIZNOSANAZIVDescription;
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
            if (!this.IRAVRSTAIZNOSAController.WorkItem.Items.Contains("IRAVRSTAIZNOSA|IRAVRSTAIZNOSA"))
            {
                this.IRAVRSTAIZNOSAController.WorkItem.Items.Add(this.bindingSourceIRAVRSTAIZNOSA, "IRAVRSTAIZNOSA|IRAVRSTAIZNOSA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsIRAVRSTAIZNOSADataSet1.IRAVRSTAIZNOSA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.IRAVRSTAIZNOSAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.IRAVRSTAIZNOSAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.IRAVRSTAIZNOSAController.Update(this))
            {
                this.IRAVRSTAIZNOSAController.DataSet = new IRAVRSTAIZNOSADataSet();
                DataSetUtil.AddEmptyRow(this.IRAVRSTAIZNOSAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.IRAVRSTAIZNOSAController.DataSet.IRAVRSTAIZNOSA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDIRAVRSTAIZNOSA.Focus();
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.IRAVRSTAIZNOSAController IRAVRSTAIZNOSAController { get; set; }

        protected virtual UltraLabel label1IDIRAVRSTAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDIRAVRSTAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDIRAVRSTAIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1IRAVRSTAIZNOSANAZIV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IRAVRSTAIZNOSANAZIV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IRAVRSTAIZNOSANAZIV = value;
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

        protected virtual UltraNumericEditor textIDIRAVRSTAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDIRAVRSTAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDIRAVRSTAIZNOSA = value;
            }
        }

        protected virtual UltraTextEditor textIRAVRSTAIZNOSANAZIV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIRAVRSTAIZNOSANAZIV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIRAVRSTAIZNOSANAZIV = value;
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

