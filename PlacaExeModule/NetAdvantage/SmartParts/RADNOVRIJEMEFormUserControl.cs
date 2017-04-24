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
    public class RADNOVRIJEMEFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDRADNOVRIJEME")]
        private UltraLabel _label1IDRADNOVRIJEME;
        [AccessedThroughProperty("label1NAZIVRADNOVRIJEME")]
        private UltraLabel _label1NAZIVRADNOVRIJEME;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDRADNOVRIJEME")]
        private UltraNumericEditor _textIDRADNOVRIJEME;
        [AccessedThroughProperty("textNAZIVRADNOVRIJEME")]
        private UltraTextEditor _textNAZIVRADNOVRIJEME;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRADNOVRIJEME;
        private IContainer components = null;
        private RADNOVRIJEMEDataSet dsRADNOVRIJEMEDataSet1;
        protected TableLayoutPanel layoutManagerformRADNOVRIJEME;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RADNOVRIJEMEDataSet.RADNOVRIJEMERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RADNOVRIJEME";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.RADNOVRIJEMEDescription;
        private DeklaritMode m_Mode;

        public RADNOVRIJEMEFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceRADNOVRIJEME.DataSource = this.RADNOVRIJEMEController.DataSet;
            this.dsRADNOVRIJEMEDataSet1 = this.RADNOVRIJEMEController.DataSet;
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
                    enumerator = this.dsRADNOVRIJEMEDataSet1.RADNOVRIJEME.Rows.GetEnumerator();
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
                if (this.RADNOVRIJEMEController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RADNOVRIJEME", this.m_Mode, this.dsRADNOVRIJEMEDataSet1, this.dsRADNOVRIJEMEDataSet1.RADNOVRIJEME.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsRADNOVRIJEMEDataSet1.RADNOVRIJEME[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RADNOVRIJEMEDataSet.RADNOVRIJEMERow) ((DataRowView) this.bindingSourceRADNOVRIJEME.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(RADNOVRIJEMEFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRADNOVRIJEME = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNOVRIJEME).BeginInit();
            this.layoutManagerformRADNOVRIJEME = new TableLayoutPanel();
            this.layoutManagerformRADNOVRIJEME.SuspendLayout();
            this.layoutManagerformRADNOVRIJEME.AutoSize = true;
            this.layoutManagerformRADNOVRIJEME.Dock = DockStyle.Fill;
            this.layoutManagerformRADNOVRIJEME.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRADNOVRIJEME.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRADNOVRIJEME.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRADNOVRIJEME.Size = size;
            this.layoutManagerformRADNOVRIJEME.ColumnCount = 2;
            this.layoutManagerformRADNOVRIJEME.RowCount = 3;
            this.layoutManagerformRADNOVRIJEME.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNOVRIJEME.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNOVRIJEME.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNOVRIJEME.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNOVRIJEME.RowStyles.Add(new RowStyle());
            this.label1IDRADNOVRIJEME = new UltraLabel();
            this.textIDRADNOVRIJEME = new UltraNumericEditor();
            this.label1NAZIVRADNOVRIJEME = new UltraLabel();
            this.textNAZIVRADNOVRIJEME = new UltraTextEditor();
            ((ISupportInitialize) this.textIDRADNOVRIJEME).BeginInit();
            ((ISupportInitialize) this.textNAZIVRADNOVRIJEME).BeginInit();
            this.dsRADNOVRIJEMEDataSet1 = new RADNOVRIJEMEDataSet();
            this.dsRADNOVRIJEMEDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRADNOVRIJEMEDataSet1.DataSetName = "dsRADNOVRIJEME";
            this.dsRADNOVRIJEMEDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRADNOVRIJEME.DataSource = this.dsRADNOVRIJEMEDataSet1;
            this.bindingSourceRADNOVRIJEME.DataMember = "RADNOVRIJEME";
            ((ISupportInitialize) this.bindingSourceRADNOVRIJEME).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDRADNOVRIJEME.Location = point;
            this.label1IDRADNOVRIJEME.Name = "label1IDRADNOVRIJEME";
            this.label1IDRADNOVRIJEME.TabIndex = 1;
            this.label1IDRADNOVRIJEME.Tag = "labelIDRADNOVRIJEME";
            this.label1IDRADNOVRIJEME.Text = "IDRADNOVRIJEME:";
            this.label1IDRADNOVRIJEME.StyleSetName = "FieldUltraLabel";
            this.label1IDRADNOVRIJEME.AutoSize = true;
            this.label1IDRADNOVRIJEME.Anchor = AnchorStyles.Left;
            this.label1IDRADNOVRIJEME.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDRADNOVRIJEME.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDRADNOVRIJEME.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDRADNOVRIJEME.ImageSize = size;
            this.label1IDRADNOVRIJEME.Appearance.ForeColor = Color.Black;
            this.label1IDRADNOVRIJEME.BackColor = Color.Transparent;
            this.layoutManagerformRADNOVRIJEME.Controls.Add(this.label1IDRADNOVRIJEME, 0, 0);
            this.layoutManagerformRADNOVRIJEME.SetColumnSpan(this.label1IDRADNOVRIJEME, 1);
            this.layoutManagerformRADNOVRIJEME.SetRowSpan(this.label1IDRADNOVRIJEME, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDRADNOVRIJEME.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDRADNOVRIJEME.MinimumSize = size;
            size = new System.Drawing.Size(0x85, 0x17);
            this.label1IDRADNOVRIJEME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDRADNOVRIJEME.Location = point;
            this.textIDRADNOVRIJEME.Name = "textIDRADNOVRIJEME";
            this.textIDRADNOVRIJEME.Tag = "IDRADNOVRIJEME";
            this.textIDRADNOVRIJEME.TabIndex = 0;
            this.textIDRADNOVRIJEME.Anchor = AnchorStyles.Left;
            this.textIDRADNOVRIJEME.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDRADNOVRIJEME.ReadOnly = false;
            this.textIDRADNOVRIJEME.PromptChar = ' ';
            this.textIDRADNOVRIJEME.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDRADNOVRIJEME.DataBindings.Add(new Binding("Value", this.bindingSourceRADNOVRIJEME, "IDRADNOVRIJEME"));
            this.textIDRADNOVRIJEME.NumericType = NumericType.Integer;
            this.textIDRADNOVRIJEME.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformRADNOVRIJEME.Controls.Add(this.textIDRADNOVRIJEME, 1, 0);
            this.layoutManagerformRADNOVRIJEME.SetColumnSpan(this.textIDRADNOVRIJEME, 1);
            this.layoutManagerformRADNOVRIJEME.SetRowSpan(this.textIDRADNOVRIJEME, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDRADNOVRIJEME.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDRADNOVRIJEME.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDRADNOVRIJEME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVRADNOVRIJEME.Location = point;
            this.label1NAZIVRADNOVRIJEME.Name = "label1NAZIVRADNOVRIJEME";
            this.label1NAZIVRADNOVRIJEME.TabIndex = 1;
            this.label1NAZIVRADNOVRIJEME.Tag = "labelNAZIVRADNOVRIJEME";
            this.label1NAZIVRADNOVRIJEME.Text = "NAZIVRADNOVRIJEME:";
            this.label1NAZIVRADNOVRIJEME.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVRADNOVRIJEME.AutoSize = true;
            this.label1NAZIVRADNOVRIJEME.Anchor = AnchorStyles.Left;
            this.label1NAZIVRADNOVRIJEME.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVRADNOVRIJEME.Appearance.ForeColor = Color.Black;
            this.label1NAZIVRADNOVRIJEME.BackColor = Color.Transparent;
            this.layoutManagerformRADNOVRIJEME.Controls.Add(this.label1NAZIVRADNOVRIJEME, 0, 1);
            this.layoutManagerformRADNOVRIJEME.SetColumnSpan(this.label1NAZIVRADNOVRIJEME, 1);
            this.layoutManagerformRADNOVRIJEME.SetRowSpan(this.label1NAZIVRADNOVRIJEME, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVRADNOVRIJEME.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVRADNOVRIJEME.MinimumSize = size;
            size = new System.Drawing.Size(0xa1, 0x17);
            this.label1NAZIVRADNOVRIJEME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVRADNOVRIJEME.Location = point;
            this.textNAZIVRADNOVRIJEME.Name = "textNAZIVRADNOVRIJEME";
            this.textNAZIVRADNOVRIJEME.Tag = "NAZIVRADNOVRIJEME";
            this.textNAZIVRADNOVRIJEME.TabIndex = 0;
            this.textNAZIVRADNOVRIJEME.Anchor = AnchorStyles.Left;
            this.textNAZIVRADNOVRIJEME.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVRADNOVRIJEME.ReadOnly = false;
            this.textNAZIVRADNOVRIJEME.DataBindings.Add(new Binding("Text", this.bindingSourceRADNOVRIJEME, "NAZIVRADNOVRIJEME"));
            this.textNAZIVRADNOVRIJEME.MaxLength = 50;
            this.layoutManagerformRADNOVRIJEME.Controls.Add(this.textNAZIVRADNOVRIJEME, 1, 1);
            this.layoutManagerformRADNOVRIJEME.SetColumnSpan(this.textNAZIVRADNOVRIJEME, 1);
            this.layoutManagerformRADNOVRIJEME.SetRowSpan(this.textNAZIVRADNOVRIJEME, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVRADNOVRIJEME.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVRADNOVRIJEME.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVRADNOVRIJEME.Size = size;
            this.Controls.Add(this.layoutManagerformRADNOVRIJEME);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRADNOVRIJEME;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RADNOVRIJEMEFormUserControl";
            this.Text = "RADNOVRIJEME";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RADNOVRIJEMEFormUserControl_Load);
            this.layoutManagerformRADNOVRIJEME.ResumeLayout(false);
            this.layoutManagerformRADNOVRIJEME.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRADNOVRIJEME).EndInit();
            ((ISupportInitialize) this.textIDRADNOVRIJEME).EndInit();
            ((ISupportInitialize) this.textNAZIVRADNOVRIJEME).EndInit();
            this.dsRADNOVRIJEMEDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RADNOVRIJEMEController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRADNOVRIJEME, this.RADNOVRIJEMEController.WorkItem, this))
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
            this.label1IDRADNOVRIJEME.Text = StringResources.RADNOVRIJEMEIDRADNOVRIJEMEDescription;
            this.label1NAZIVRADNOVRIJEME.Text = StringResources.RADNOVRIJEMENAZIVRADNOVRIJEMEDescription;
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
                this.RADNOVRIJEMEController.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RADNOVRIJEMEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RADNOVRIJEMEDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RADNOVRIJEMEController.WorkItem.Items.Contains("RADNOVRIJEME|RADNOVRIJEME"))
            {
                this.RADNOVRIJEMEController.WorkItem.Items.Add(this.bindingSourceRADNOVRIJEME, "RADNOVRIJEME|RADNOVRIJEME");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsRADNOVRIJEMEDataSet1.RADNOVRIJEME.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.RADNOVRIJEMEController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RADNOVRIJEMEController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RADNOVRIJEMEController.Update(this))
            {
                this.RADNOVRIJEMEController.DataSet = new RADNOVRIJEMEDataSet();
                DataSetUtil.AddEmptyRow(this.RADNOVRIJEMEController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.RADNOVRIJEMEController.DataSet.RADNOVRIJEME[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDRADNOVRIJEME.Focus();
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
                this.RADNOVRIJEMEController.ViewRADNIK(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDRADNOVRIJEME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDRADNOVRIJEME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDRADNOVRIJEME = value;
            }
        }

        protected virtual UltraLabel label1NAZIVRADNOVRIJEME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVRADNOVRIJEME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVRADNOVRIJEME = value;
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
        public NetAdvantage.Controllers.RADNOVRIJEMEController RADNOVRIJEMEController { get; set; }

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

        protected virtual UltraNumericEditor textIDRADNOVRIJEME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDRADNOVRIJEME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDRADNOVRIJEME = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVRADNOVRIJEME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVRADNOVRIJEME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVRADNOVRIJEME = value;
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

