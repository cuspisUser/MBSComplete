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
    public class RADNOMJESTOFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDRADNOMJESTO")]
        private UltraLabel _label1IDRADNOMJESTO;
        [AccessedThroughProperty("label1NAZIVRADNOMJESTO")]
        private UltraLabel _label1NAZIVRADNOMJESTO;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDRADNOMJESTO")]
        private UltraNumericEditor _textIDRADNOMJESTO;
        [AccessedThroughProperty("textNAZIVRADNOMJESTO")]
        private UltraTextEditor _textNAZIVRADNOMJESTO;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRADNOMJESTO;
        private IContainer components = null;
        private RADNOMJESTODataSet dsRADNOMJESTODataSet1;
        protected TableLayoutPanel layoutManagerformRADNOMJESTO;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RADNOMJESTODataSet.RADNOMJESTORow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RADNOMJESTO";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.RADNOMJESTODescription;
        private DeklaritMode m_Mode;

        public RADNOMJESTOFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceRADNOMJESTO.DataSource = this.RADNOMJESTOController.DataSet;
            this.dsRADNOMJESTODataSet1 = this.RADNOMJESTOController.DataSet;
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
                    enumerator = this.dsRADNOMJESTODataSet1.RADNOMJESTO.Rows.GetEnumerator();
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
                if (this.RADNOMJESTOController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RADNOMJESTO", this.m_Mode, this.dsRADNOMJESTODataSet1, this.dsRADNOMJESTODataSet1.RADNOMJESTO.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsRADNOMJESTODataSet1.RADNOMJESTO[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RADNOMJESTODataSet.RADNOMJESTORow) ((DataRowView) this.bindingSourceRADNOMJESTO.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(RADNOMJESTOFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRADNOMJESTO = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNOMJESTO).BeginInit();
            this.layoutManagerformRADNOMJESTO = new TableLayoutPanel();
            this.layoutManagerformRADNOMJESTO.SuspendLayout();
            this.layoutManagerformRADNOMJESTO.AutoSize = true;
            this.layoutManagerformRADNOMJESTO.Dock = DockStyle.Fill;
            this.layoutManagerformRADNOMJESTO.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRADNOMJESTO.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRADNOMJESTO.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRADNOMJESTO.Size = size;
            this.layoutManagerformRADNOMJESTO.ColumnCount = 2;
            this.layoutManagerformRADNOMJESTO.RowCount = 3;
            this.layoutManagerformRADNOMJESTO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNOMJESTO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNOMJESTO.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNOMJESTO.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNOMJESTO.RowStyles.Add(new RowStyle());
            this.label1IDRADNOMJESTO = new UltraLabel();
            this.textIDRADNOMJESTO = new UltraNumericEditor();
            this.label1NAZIVRADNOMJESTO = new UltraLabel();
            this.textNAZIVRADNOMJESTO = new UltraTextEditor();
            ((ISupportInitialize) this.textIDRADNOMJESTO).BeginInit();
            ((ISupportInitialize) this.textNAZIVRADNOMJESTO).BeginInit();
            this.dsRADNOMJESTODataSet1 = new RADNOMJESTODataSet();
            this.dsRADNOMJESTODataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRADNOMJESTODataSet1.DataSetName = "dsRADNOMJESTO";
            this.dsRADNOMJESTODataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRADNOMJESTO.DataSource = this.dsRADNOMJESTODataSet1;
            this.bindingSourceRADNOMJESTO.DataMember = "RADNOMJESTO";
            ((ISupportInitialize) this.bindingSourceRADNOMJESTO).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDRADNOMJESTO.Location = point;
            this.label1IDRADNOMJESTO.Name = "label1IDRADNOMJESTO";
            this.label1IDRADNOMJESTO.TabIndex = 1;
            this.label1IDRADNOMJESTO.Tag = "labelIDRADNOMJESTO";
            this.label1IDRADNOMJESTO.Text = "Šifra radnog mjesta:";
            this.label1IDRADNOMJESTO.StyleSetName = "FieldUltraLabel";
            this.label1IDRADNOMJESTO.AutoSize = true;
            this.label1IDRADNOMJESTO.Anchor = AnchorStyles.Left;
            this.label1IDRADNOMJESTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDRADNOMJESTO.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDRADNOMJESTO.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDRADNOMJESTO.ImageSize = size;
            this.label1IDRADNOMJESTO.Appearance.ForeColor = Color.Black;
            this.label1IDRADNOMJESTO.BackColor = Color.Transparent;
            this.layoutManagerformRADNOMJESTO.Controls.Add(this.label1IDRADNOMJESTO, 0, 0);
            this.layoutManagerformRADNOMJESTO.SetColumnSpan(this.label1IDRADNOMJESTO, 1);
            this.layoutManagerformRADNOMJESTO.SetRowSpan(this.label1IDRADNOMJESTO, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDRADNOMJESTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDRADNOMJESTO.MinimumSize = size;
            size = new System.Drawing.Size(0x8b, 0x17);
            this.label1IDRADNOMJESTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDRADNOMJESTO.Location = point;
            this.textIDRADNOMJESTO.Name = "textIDRADNOMJESTO";
            this.textIDRADNOMJESTO.Tag = "IDRADNOMJESTO";
            this.textIDRADNOMJESTO.TabIndex = 0;
            this.textIDRADNOMJESTO.Anchor = AnchorStyles.Left;
            this.textIDRADNOMJESTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDRADNOMJESTO.ReadOnly = false;
            this.textIDRADNOMJESTO.PromptChar = ' ';
            this.textIDRADNOMJESTO.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDRADNOMJESTO.DataBindings.Add(new Binding("Value", this.bindingSourceRADNOMJESTO, "IDRADNOMJESTO"));
            this.textIDRADNOMJESTO.NumericType = NumericType.Integer;
            this.textIDRADNOMJESTO.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformRADNOMJESTO.Controls.Add(this.textIDRADNOMJESTO, 1, 0);
            this.layoutManagerformRADNOMJESTO.SetColumnSpan(this.textIDRADNOMJESTO, 1);
            this.layoutManagerformRADNOMJESTO.SetRowSpan(this.textIDRADNOMJESTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDRADNOMJESTO.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDRADNOMJESTO.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDRADNOMJESTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVRADNOMJESTO.Location = point;
            this.label1NAZIVRADNOMJESTO.Name = "label1NAZIVRADNOMJESTO";
            this.label1NAZIVRADNOMJESTO.TabIndex = 1;
            this.label1NAZIVRADNOMJESTO.Tag = "labelNAZIVRADNOMJESTO";
            this.label1NAZIVRADNOMJESTO.Text = "Naziv radnog mjesta:";
            this.label1NAZIVRADNOMJESTO.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVRADNOMJESTO.AutoSize = true;
            this.label1NAZIVRADNOMJESTO.Anchor = AnchorStyles.Left;
            this.label1NAZIVRADNOMJESTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVRADNOMJESTO.Appearance.ForeColor = Color.Black;
            this.label1NAZIVRADNOMJESTO.BackColor = Color.Transparent;
            this.layoutManagerformRADNOMJESTO.Controls.Add(this.label1NAZIVRADNOMJESTO, 0, 1);
            this.layoutManagerformRADNOMJESTO.SetColumnSpan(this.label1NAZIVRADNOMJESTO, 1);
            this.layoutManagerformRADNOMJESTO.SetRowSpan(this.label1NAZIVRADNOMJESTO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVRADNOMJESTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVRADNOMJESTO.MinimumSize = size;
            size = new System.Drawing.Size(0x93, 0x17);
            this.label1NAZIVRADNOMJESTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVRADNOMJESTO.Location = point;
            this.textNAZIVRADNOMJESTO.Name = "textNAZIVRADNOMJESTO";
            this.textNAZIVRADNOMJESTO.Tag = "NAZIVRADNOMJESTO";
            this.textNAZIVRADNOMJESTO.TabIndex = 0;
            this.textNAZIVRADNOMJESTO.Anchor = AnchorStyles.Left;
            this.textNAZIVRADNOMJESTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVRADNOMJESTO.ReadOnly = false;
            this.textNAZIVRADNOMJESTO.DataBindings.Add(new Binding("Text", this.bindingSourceRADNOMJESTO, "NAZIVRADNOMJESTO"));
            this.textNAZIVRADNOMJESTO.MaxLength = 50;
            this.layoutManagerformRADNOMJESTO.Controls.Add(this.textNAZIVRADNOMJESTO, 1, 1);
            this.layoutManagerformRADNOMJESTO.SetColumnSpan(this.textNAZIVRADNOMJESTO, 1);
            this.layoutManagerformRADNOMJESTO.SetRowSpan(this.textNAZIVRADNOMJESTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVRADNOMJESTO.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVRADNOMJESTO.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVRADNOMJESTO.Size = size;
            this.Controls.Add(this.layoutManagerformRADNOMJESTO);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRADNOMJESTO;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RADNOMJESTOFormUserControl";
            this.Text = "Radna mjesta";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RADNOMJESTOFormUserControl_Load);
            this.layoutManagerformRADNOMJESTO.ResumeLayout(false);
            this.layoutManagerformRADNOMJESTO.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRADNOMJESTO).EndInit();
            ((ISupportInitialize) this.textIDRADNOMJESTO).EndInit();
            ((ISupportInitialize) this.textNAZIVRADNOMJESTO).EndInit();
            this.dsRADNOMJESTODataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RADNOMJESTOController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRADNOMJESTO, this.RADNOMJESTOController.WorkItem, this))
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
            this.label1IDRADNOMJESTO.Text = StringResources.RADNOMJESTOIDRADNOMJESTODescription;
            this.label1NAZIVRADNOMJESTO.Text = StringResources.RADNOMJESTONAZIVRADNOMJESTODescription;
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
                this.RADNOMJESTOController.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RADNOMJESTOFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RADNOMJESTODescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RADNOMJESTOController.WorkItem.Items.Contains("RADNOMJESTO|RADNOMJESTO"))
            {
                this.RADNOMJESTOController.WorkItem.Items.Add(this.bindingSourceRADNOMJESTO, "RADNOMJESTO|RADNOMJESTO");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsRADNOMJESTODataSet1.RADNOMJESTO.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.RADNOMJESTOController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RADNOMJESTOController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RADNOMJESTOController.Update(this))
            {
                this.RADNOMJESTOController.DataSet = new RADNOMJESTODataSet();
                DataSetUtil.AddEmptyRow(this.RADNOMJESTOController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.RADNOMJESTOController.DataSet.RADNOMJESTO[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDRADNOMJESTO.Focus();
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
                this.RADNOMJESTOController.ViewRADNIK(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDRADNOMJESTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDRADNOMJESTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDRADNOMJESTO = value;
            }
        }

        protected virtual UltraLabel label1NAZIVRADNOMJESTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVRADNOMJESTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVRADNOMJESTO = value;
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
        public NetAdvantage.Controllers.RADNOMJESTOController RADNOMJESTOController { get; set; }

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

        protected virtual UltraNumericEditor textIDRADNOMJESTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDRADNOMJESTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDRADNOMJESTO = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVRADNOMJESTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVRADNOMJESTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVRADNOMJESTO = value;
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

