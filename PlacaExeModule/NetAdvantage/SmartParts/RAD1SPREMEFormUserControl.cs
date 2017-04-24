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
    public class RAD1SPREMEFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1RAD1IDSPREME")]
        private UltraLabel _label1RAD1IDSPREME;
        [AccessedThroughProperty("label1RAD1NAZIVSPREME")]
        private UltraLabel _label1RAD1NAZIVSPREME;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textRAD1IDSPREME")]
        private UltraNumericEditor _textRAD1IDSPREME;
        [AccessedThroughProperty("textRAD1NAZIVSPREME")]
        private UltraTextEditor _textRAD1NAZIVSPREME;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRAD1SPREME;
        private IContainer components = null;
        private RAD1SPREMEDataSet dsRAD1SPREMEDataSet1;
        protected TableLayoutPanel layoutManagerformRAD1SPREME;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RAD1SPREMEDataSet.RAD1SPREMERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RAD1SPREME";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.RAD1SPREMEDescription;
        private DeklaritMode m_Mode;

        public RAD1SPREMEFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceRAD1SPREME.DataSource = this.RAD1SPREMEController.DataSet;
            this.dsRAD1SPREMEDataSet1 = this.RAD1SPREMEController.DataSet;
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
                    enumerator = this.dsRAD1SPREMEDataSet1.RAD1SPREME.Rows.GetEnumerator();
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
                if (this.RAD1SPREMEController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RAD1SPREME", this.m_Mode, this.dsRAD1SPREMEDataSet1, this.dsRAD1SPREMEDataSet1.RAD1SPREME.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsRAD1SPREMEDataSet1.RAD1SPREME[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RAD1SPREMEDataSet.RAD1SPREMERow) ((DataRowView) this.bindingSourceRAD1SPREME.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(RAD1SPREMEFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRAD1SPREME = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRAD1SPREME).BeginInit();
            this.layoutManagerformRAD1SPREME = new TableLayoutPanel();
            this.layoutManagerformRAD1SPREME.SuspendLayout();
            this.layoutManagerformRAD1SPREME.AutoSize = true;
            this.layoutManagerformRAD1SPREME.Dock = DockStyle.Fill;
            this.layoutManagerformRAD1SPREME.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRAD1SPREME.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRAD1SPREME.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRAD1SPREME.Size = size;
            this.layoutManagerformRAD1SPREME.ColumnCount = 2;
            this.layoutManagerformRAD1SPREME.RowCount = 3;
            this.layoutManagerformRAD1SPREME.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1SPREME.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1SPREME.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1SPREME.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1SPREME.RowStyles.Add(new RowStyle());
            this.label1RAD1IDSPREME = new UltraLabel();
            this.textRAD1IDSPREME = new UltraNumericEditor();
            this.label1RAD1NAZIVSPREME = new UltraLabel();
            this.textRAD1NAZIVSPREME = new UltraTextEditor();
            ((ISupportInitialize) this.textRAD1IDSPREME).BeginInit();
            ((ISupportInitialize) this.textRAD1NAZIVSPREME).BeginInit();
            this.dsRAD1SPREMEDataSet1 = new RAD1SPREMEDataSet();
            this.dsRAD1SPREMEDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRAD1SPREMEDataSet1.DataSetName = "dsRAD1SPREME";
            this.dsRAD1SPREMEDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRAD1SPREME.DataSource = this.dsRAD1SPREMEDataSet1;
            this.bindingSourceRAD1SPREME.DataMember = "RAD1SPREME";
            ((ISupportInitialize) this.bindingSourceRAD1SPREME).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1RAD1IDSPREME.Location = point;
            this.label1RAD1IDSPREME.Name = "label1RAD1IDSPREME";
            this.label1RAD1IDSPREME.TabIndex = 1;
            this.label1RAD1IDSPREME.Tag = "labelRAD1IDSPREME";
            this.label1RAD1IDSPREME.Text = "RAD1 IDSPREME:";
            this.label1RAD1IDSPREME.StyleSetName = "FieldUltraLabel";
            this.label1RAD1IDSPREME.AutoSize = true;
            this.label1RAD1IDSPREME.Anchor = AnchorStyles.Left;
            this.label1RAD1IDSPREME.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAD1IDSPREME.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1RAD1IDSPREME.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1RAD1IDSPREME.ImageSize = size;
            this.label1RAD1IDSPREME.Appearance.ForeColor = Color.Black;
            this.label1RAD1IDSPREME.BackColor = Color.Transparent;
            this.layoutManagerformRAD1SPREME.Controls.Add(this.label1RAD1IDSPREME, 0, 0);
            this.layoutManagerformRAD1SPREME.SetColumnSpan(this.label1RAD1IDSPREME, 1);
            this.layoutManagerformRAD1SPREME.SetRowSpan(this.label1RAD1IDSPREME, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1RAD1IDSPREME.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAD1IDSPREME.MinimumSize = size;
            size = new System.Drawing.Size(0x79, 0x17);
            this.label1RAD1IDSPREME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRAD1IDSPREME.Location = point;
            this.textRAD1IDSPREME.Name = "textRAD1IDSPREME";
            this.textRAD1IDSPREME.Tag = "RAD1IDSPREME";
            this.textRAD1IDSPREME.TabIndex = 0;
            this.textRAD1IDSPREME.Anchor = AnchorStyles.Left;
            this.textRAD1IDSPREME.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRAD1IDSPREME.ReadOnly = false;
            this.textRAD1IDSPREME.PromptChar = ' ';
            this.textRAD1IDSPREME.Enter += new EventHandler(this.numericEditor_Enter);
            this.textRAD1IDSPREME.DataBindings.Add(new Binding("Value", this.bindingSourceRAD1SPREME, "RAD1IDSPREME"));
            this.textRAD1IDSPREME.NumericType = NumericType.Integer;
            this.textRAD1IDSPREME.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformRAD1SPREME.Controls.Add(this.textRAD1IDSPREME, 1, 0);
            this.layoutManagerformRAD1SPREME.SetColumnSpan(this.textRAD1IDSPREME, 1);
            this.layoutManagerformRAD1SPREME.SetRowSpan(this.textRAD1IDSPREME, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRAD1IDSPREME.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textRAD1IDSPREME.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textRAD1IDSPREME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RAD1NAZIVSPREME.Location = point;
            this.label1RAD1NAZIVSPREME.Name = "label1RAD1NAZIVSPREME";
            this.label1RAD1NAZIVSPREME.TabIndex = 1;
            this.label1RAD1NAZIVSPREME.Tag = "labelRAD1NAZIVSPREME";
            this.label1RAD1NAZIVSPREME.Text = "RAD1 NAZIVSPREME:";
            this.label1RAD1NAZIVSPREME.StyleSetName = "FieldUltraLabel";
            this.label1RAD1NAZIVSPREME.AutoSize = true;
            this.label1RAD1NAZIVSPREME.Anchor = AnchorStyles.Left;
            this.label1RAD1NAZIVSPREME.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAD1NAZIVSPREME.Appearance.ForeColor = Color.Black;
            this.label1RAD1NAZIVSPREME.BackColor = Color.Transparent;
            this.layoutManagerformRAD1SPREME.Controls.Add(this.label1RAD1NAZIVSPREME, 0, 1);
            this.layoutManagerformRAD1SPREME.SetColumnSpan(this.label1RAD1NAZIVSPREME, 1);
            this.layoutManagerformRAD1SPREME.SetRowSpan(this.label1RAD1NAZIVSPREME, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RAD1NAZIVSPREME.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAD1NAZIVSPREME.MinimumSize = size;
            size = new System.Drawing.Size(0x94, 0x17);
            this.label1RAD1NAZIVSPREME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRAD1NAZIVSPREME.Location = point;
            this.textRAD1NAZIVSPREME.Name = "textRAD1NAZIVSPREME";
            this.textRAD1NAZIVSPREME.Tag = "RAD1NAZIVSPREME";
            this.textRAD1NAZIVSPREME.TabIndex = 0;
            this.textRAD1NAZIVSPREME.Anchor = AnchorStyles.Left;
            this.textRAD1NAZIVSPREME.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRAD1NAZIVSPREME.ReadOnly = false;
            this.textRAD1NAZIVSPREME.DataBindings.Add(new Binding("Text", this.bindingSourceRAD1SPREME, "RAD1NAZIVSPREME"));
            this.textRAD1NAZIVSPREME.MaxLength = 50;
            this.layoutManagerformRAD1SPREME.Controls.Add(this.textRAD1NAZIVSPREME, 1, 1);
            this.layoutManagerformRAD1SPREME.SetColumnSpan(this.textRAD1NAZIVSPREME, 1);
            this.layoutManagerformRAD1SPREME.SetRowSpan(this.textRAD1NAZIVSPREME, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRAD1NAZIVSPREME.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textRAD1NAZIVSPREME.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textRAD1NAZIVSPREME.Size = size;
            this.Controls.Add(this.layoutManagerformRAD1SPREME);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRAD1SPREME;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RAD1SPREMEFormUserControl";
            this.Text = "RAD1SPREME";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RAD1SPREMEFormUserControl_Load);
            this.layoutManagerformRAD1SPREME.ResumeLayout(false);
            this.layoutManagerformRAD1SPREME.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRAD1SPREME).EndInit();
            ((ISupportInitialize) this.textRAD1IDSPREME).EndInit();
            ((ISupportInitialize) this.textRAD1NAZIVSPREME).EndInit();
            this.dsRAD1SPREMEDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RAD1SPREMEController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRAD1SPREME, this.RAD1SPREMEController.WorkItem, this))
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
            this.label1RAD1IDSPREME.Text = StringResources.RAD1SPREMERAD1IDSPREMEDescription;
            this.label1RAD1NAZIVSPREME.Text = StringResources.RAD1SPREMERAD1NAZIVSPREMEDescription;
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
                this.RAD1SPREMEController.NewRAD1SPREMEVEZA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RAD1SPREMEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RAD1SPREMEDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RAD1SPREMEController.WorkItem.Items.Contains("RAD1SPREME|RAD1SPREME"))
            {
                this.RAD1SPREMEController.WorkItem.Items.Add(this.bindingSourceRAD1SPREME, "RAD1SPREME|RAD1SPREME");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsRAD1SPREMEDataSet1.RAD1SPREME.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.RAD1SPREMEController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1SPREMEController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1SPREMEController.Update(this))
            {
                this.RAD1SPREMEController.DataSet = new RAD1SPREMEDataSet();
                DataSetUtil.AddEmptyRow(this.RAD1SPREMEController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.RAD1SPREMEController.DataSet.RAD1SPREME[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textRAD1IDSPREME.Focus();
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

        [LocalCommandHandler("ViewRAD1SPREMEVEZA")]
        public void ViewRAD1SPREMEVEZAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RAD1SPREMEController.ViewRAD1SPREMEVEZA(this.m_CurrentRow);
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

        protected virtual UltraLabel label1RAD1IDSPREME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAD1IDSPREME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAD1IDSPREME = value;
            }
        }

        protected virtual UltraLabel label1RAD1NAZIVSPREME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAD1NAZIVSPREME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAD1NAZIVSPREME = value;
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.RAD1SPREMEController RAD1SPREMEController { get; set; }

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

        protected virtual UltraNumericEditor textRAD1IDSPREME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRAD1IDSPREME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRAD1IDSPREME = value;
            }
        }

        protected virtual UltraTextEditor textRAD1NAZIVSPREME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRAD1NAZIVSPREME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRAD1NAZIVSPREME = value;
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

