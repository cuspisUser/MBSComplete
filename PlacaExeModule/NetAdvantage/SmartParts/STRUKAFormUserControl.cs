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
    public class STRUKAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDSTRUKA")]
        private UltraLabel _label1IDSTRUKA;
        [AccessedThroughProperty("label1NAZIVSTRUKA")]
        private UltraLabel _label1NAZIVSTRUKA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDSTRUKA")]
        private UltraNumericEditor _textIDSTRUKA;
        [AccessedThroughProperty("textNAZIVSTRUKA")]
        private UltraTextEditor _textNAZIVSTRUKA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSTRUKA;
        private IContainer components = null;
        private STRUKADataSet dsSTRUKADataSet1;
        protected TableLayoutPanel layoutManagerformSTRUKA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private STRUKADataSet.STRUKARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "STRUKA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.STRUKADescription;
        private DeklaritMode m_Mode;

        public STRUKAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceSTRUKA.DataSource = this.STRUKAController.DataSet;
            this.dsSTRUKADataSet1 = this.STRUKAController.DataSet;
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
                    enumerator = this.dsSTRUKADataSet1.STRUKA.Rows.GetEnumerator();
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
                if (this.STRUKAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "STRUKA", this.m_Mode, this.dsSTRUKADataSet1, this.dsSTRUKADataSet1.STRUKA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsSTRUKADataSet1.STRUKA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (STRUKADataSet.STRUKARow) ((DataRowView) this.bindingSourceSTRUKA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(STRUKAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSTRUKA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSTRUKA).BeginInit();
            this.layoutManagerformSTRUKA = new TableLayoutPanel();
            this.layoutManagerformSTRUKA.SuspendLayout();
            this.layoutManagerformSTRUKA.AutoSize = true;
            this.layoutManagerformSTRUKA.Dock = DockStyle.Fill;
            this.layoutManagerformSTRUKA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSTRUKA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSTRUKA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSTRUKA.Size = size;
            this.layoutManagerformSTRUKA.ColumnCount = 2;
            this.layoutManagerformSTRUKA.RowCount = 3;
            this.layoutManagerformSTRUKA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSTRUKA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSTRUKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSTRUKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSTRUKA.RowStyles.Add(new RowStyle());
            this.label1IDSTRUKA = new UltraLabel();
            this.textIDSTRUKA = new UltraNumericEditor();
            this.label1NAZIVSTRUKA = new UltraLabel();
            this.textNAZIVSTRUKA = new UltraTextEditor();
            ((ISupportInitialize) this.textIDSTRUKA).BeginInit();
            ((ISupportInitialize) this.textNAZIVSTRUKA).BeginInit();
            this.dsSTRUKADataSet1 = new STRUKADataSet();
            this.dsSTRUKADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSTRUKADataSet1.DataSetName = "dsSTRUKA";
            this.dsSTRUKADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSTRUKA.DataSource = this.dsSTRUKADataSet1;
            this.bindingSourceSTRUKA.DataMember = "STRUKA";
            ((ISupportInitialize) this.bindingSourceSTRUKA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDSTRUKA.Location = point;
            this.label1IDSTRUKA.Name = "label1IDSTRUKA";
            this.label1IDSTRUKA.TabIndex = 1;
            this.label1IDSTRUKA.Tag = "labelIDSTRUKA";
            this.label1IDSTRUKA.Text = "Šifra struke:";
            this.label1IDSTRUKA.StyleSetName = "FieldUltraLabel";
            this.label1IDSTRUKA.AutoSize = true;
            this.label1IDSTRUKA.Anchor = AnchorStyles.Left;
            this.label1IDSTRUKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDSTRUKA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDSTRUKA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDSTRUKA.ImageSize = size;
            this.label1IDSTRUKA.Appearance.ForeColor = Color.Black;
            this.label1IDSTRUKA.BackColor = Color.Transparent;
            this.layoutManagerformSTRUKA.Controls.Add(this.label1IDSTRUKA, 0, 0);
            this.layoutManagerformSTRUKA.SetColumnSpan(this.label1IDSTRUKA, 1);
            this.layoutManagerformSTRUKA.SetRowSpan(this.label1IDSTRUKA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDSTRUKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDSTRUKA.MinimumSize = size;
            size = new System.Drawing.Size(0x58, 0x17);
            this.label1IDSTRUKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDSTRUKA.Location = point;
            this.textIDSTRUKA.Name = "textIDSTRUKA";
            this.textIDSTRUKA.Tag = "IDSTRUKA";
            this.textIDSTRUKA.TabIndex = 0;
            this.textIDSTRUKA.Anchor = AnchorStyles.Left;
            this.textIDSTRUKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDSTRUKA.ReadOnly = false;
            this.textIDSTRUKA.PromptChar = ' ';
            this.textIDSTRUKA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDSTRUKA.DataBindings.Add(new Binding("Value", this.bindingSourceSTRUKA, "IDSTRUKA"));
            this.textIDSTRUKA.NumericType = NumericType.Integer;
            this.textIDSTRUKA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformSTRUKA.Controls.Add(this.textIDSTRUKA, 1, 0);
            this.layoutManagerformSTRUKA.SetColumnSpan(this.textIDSTRUKA, 1);
            this.layoutManagerformSTRUKA.SetRowSpan(this.textIDSTRUKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDSTRUKA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSTRUKA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSTRUKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVSTRUKA.Location = point;
            this.label1NAZIVSTRUKA.Name = "label1NAZIVSTRUKA";
            this.label1NAZIVSTRUKA.TabIndex = 1;
            this.label1NAZIVSTRUKA.Tag = "labelNAZIVSTRUKA";
            this.label1NAZIVSTRUKA.Text = "Naziv struke:";
            this.label1NAZIVSTRUKA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVSTRUKA.AutoSize = true;
            this.label1NAZIVSTRUKA.Anchor = AnchorStyles.Left;
            this.label1NAZIVSTRUKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVSTRUKA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVSTRUKA.BackColor = Color.Transparent;
            this.layoutManagerformSTRUKA.Controls.Add(this.label1NAZIVSTRUKA, 0, 1);
            this.layoutManagerformSTRUKA.SetColumnSpan(this.label1NAZIVSTRUKA, 1);
            this.layoutManagerformSTRUKA.SetRowSpan(this.label1NAZIVSTRUKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVSTRUKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVSTRUKA.MinimumSize = size;
            size = new System.Drawing.Size(0x60, 0x17);
            this.label1NAZIVSTRUKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVSTRUKA.Location = point;
            this.textNAZIVSTRUKA.Name = "textNAZIVSTRUKA";
            this.textNAZIVSTRUKA.Tag = "NAZIVSTRUKA";
            this.textNAZIVSTRUKA.TabIndex = 0;
            this.textNAZIVSTRUKA.Anchor = AnchorStyles.Left;
            this.textNAZIVSTRUKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVSTRUKA.ReadOnly = false;
            this.textNAZIVSTRUKA.DataBindings.Add(new Binding("Text", this.bindingSourceSTRUKA, "NAZIVSTRUKA"));
            this.textNAZIVSTRUKA.MaxLength = 50;
            this.layoutManagerformSTRUKA.Controls.Add(this.textNAZIVSTRUKA, 1, 1);
            this.layoutManagerformSTRUKA.SetColumnSpan(this.textNAZIVSTRUKA, 1);
            this.layoutManagerformSTRUKA.SetRowSpan(this.textNAZIVSTRUKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVSTRUKA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVSTRUKA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVSTRUKA.Size = size;
            this.Controls.Add(this.layoutManagerformSTRUKA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSTRUKA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "STRUKAFormUserControl";
            this.Text = "Struke";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.STRUKAFormUserControl_Load);
            this.layoutManagerformSTRUKA.ResumeLayout(false);
            this.layoutManagerformSTRUKA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSTRUKA).EndInit();
            ((ISupportInitialize) this.textIDSTRUKA).EndInit();
            ((ISupportInitialize) this.textNAZIVSTRUKA).EndInit();
            this.dsSTRUKADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.STRUKAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSTRUKA, this.STRUKAController.WorkItem, this))
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
            this.label1IDSTRUKA.Text = StringResources.STRUKAIDSTRUKADescription;
            this.label1NAZIVSTRUKA.Text = StringResources.STRUKANAZIVSTRUKADescription;
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
                this.STRUKAController.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.STRUKAController.WorkItem.Items.Contains("STRUKA|STRUKA"))
            {
                this.STRUKAController.WorkItem.Items.Add(this.bindingSourceSTRUKA, "STRUKA|STRUKA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsSTRUKADataSet1.STRUKA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.STRUKAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.STRUKAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.STRUKAController.Update(this))
            {
                this.STRUKAController.DataSet = new STRUKADataSet();
                DataSetUtil.AddEmptyRow(this.STRUKAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.STRUKAController.DataSet.STRUKA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDSTRUKA.Focus();
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

        private void STRUKAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.STRUKADescription;
            this.errorProvider1.ContainerControl = this;
        }

        [LocalCommandHandler("ViewRADNIK")]
        public void ViewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.STRUKAController.ViewRADNIK(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDSTRUKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDSTRUKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDSTRUKA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVSTRUKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVSTRUKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVSTRUKA = value;
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.STRUKAController STRUKAController { get; set; }

        protected virtual UltraNumericEditor textIDSTRUKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDSTRUKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDSTRUKA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVSTRUKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVSTRUKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVSTRUKA = value;
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

