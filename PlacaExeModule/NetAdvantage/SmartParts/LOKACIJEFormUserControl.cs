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
    public class LOKACIJEFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDLOKACIJE")]
        private UltraLabel _label1IDLOKACIJE;
        [AccessedThroughProperty("label1LOK")]
        private UltraLabel _label1LOK;
        [AccessedThroughProperty("label1OPISLOKACIJE")]
        private UltraLabel _label1OPISLOKACIJE;
        [AccessedThroughProperty("labelLOK")]
        private UltraLabel _labelLOK;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDLOKACIJE")]
        private UltraNumericEditor _textIDLOKACIJE;
        [AccessedThroughProperty("textOPISLOKACIJE")]
        private UltraTextEditor _textOPISLOKACIJE;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceLOKACIJE;
        private IContainer components = null;
        private LOKACIJEDataSet dsLOKACIJEDataSet1;
        protected TableLayoutPanel layoutManagerformLOKACIJE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private LOKACIJEDataSet.LOKACIJERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "LOKACIJE";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.LOKACIJEDescription;
        private DeklaritMode m_Mode;

        public LOKACIJEFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceLOKACIJE.DataSource = this.LOKACIJEController.DataSet;
            this.dsLOKACIJEDataSet1 = this.LOKACIJEController.DataSet;
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
                    enumerator = this.dsLOKACIJEDataSet1.LOKACIJE.Rows.GetEnumerator();
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
                if (this.LOKACIJEController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "LOKACIJE", this.m_Mode, this.dsLOKACIJEDataSet1, this.dsLOKACIJEDataSet1.LOKACIJE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsLOKACIJEDataSet1.LOKACIJE[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (LOKACIJEDataSet.LOKACIJERow) ((DataRowView) this.bindingSourceLOKACIJE.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(LOKACIJEFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceLOKACIJE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceLOKACIJE).BeginInit();
            this.layoutManagerformLOKACIJE = new TableLayoutPanel();
            this.layoutManagerformLOKACIJE.SuspendLayout();
            this.layoutManagerformLOKACIJE.AutoSize = true;
            this.layoutManagerformLOKACIJE.Dock = DockStyle.Fill;
            this.layoutManagerformLOKACIJE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformLOKACIJE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformLOKACIJE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformLOKACIJE.Size = size;
            this.layoutManagerformLOKACIJE.ColumnCount = 2;
            this.layoutManagerformLOKACIJE.RowCount = 4;
            this.layoutManagerformLOKACIJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformLOKACIJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformLOKACIJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformLOKACIJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformLOKACIJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformLOKACIJE.RowStyles.Add(new RowStyle());
            this.label1IDLOKACIJE = new UltraLabel();
            this.textIDLOKACIJE = new UltraNumericEditor();
            this.label1OPISLOKACIJE = new UltraLabel();
            this.textOPISLOKACIJE = new UltraTextEditor();
            this.label1LOK = new UltraLabel();
            this.labelLOK = new UltraLabel();
            ((ISupportInitialize) this.textIDLOKACIJE).BeginInit();
            ((ISupportInitialize) this.textOPISLOKACIJE).BeginInit();
            this.dsLOKACIJEDataSet1 = new LOKACIJEDataSet();
            this.dsLOKACIJEDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsLOKACIJEDataSet1.DataSetName = "dsLOKACIJE";
            this.dsLOKACIJEDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceLOKACIJE.DataSource = this.dsLOKACIJEDataSet1;
            this.bindingSourceLOKACIJE.DataMember = "LOKACIJE";
            ((ISupportInitialize) this.bindingSourceLOKACIJE).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDLOKACIJE.Location = point;
            this.label1IDLOKACIJE.Name = "label1IDLOKACIJE";
            this.label1IDLOKACIJE.TabIndex = 1;
            this.label1IDLOKACIJE.Tag = "labelIDLOKACIJE";
            this.label1IDLOKACIJE.Text = "Šfr.:";
            this.label1IDLOKACIJE.StyleSetName = "FieldUltraLabel";
            this.label1IDLOKACIJE.AutoSize = true;
            this.label1IDLOKACIJE.Anchor = AnchorStyles.Left;
            this.label1IDLOKACIJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDLOKACIJE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDLOKACIJE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDLOKACIJE.ImageSize = size;
            this.label1IDLOKACIJE.Appearance.ForeColor = Color.Black;
            this.label1IDLOKACIJE.BackColor = Color.Transparent;
            this.layoutManagerformLOKACIJE.Controls.Add(this.label1IDLOKACIJE, 0, 0);
            this.layoutManagerformLOKACIJE.SetColumnSpan(this.label1IDLOKACIJE, 1);
            this.layoutManagerformLOKACIJE.SetRowSpan(this.label1IDLOKACIJE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDLOKACIJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDLOKACIJE.MinimumSize = size;
            size = new System.Drawing.Size(0x26, 0x17);
            this.label1IDLOKACIJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDLOKACIJE.Location = point;
            this.textIDLOKACIJE.Name = "textIDLOKACIJE";
            this.textIDLOKACIJE.Tag = "IDLOKACIJE";
            this.textIDLOKACIJE.TabIndex = 0;
            this.textIDLOKACIJE.Anchor = AnchorStyles.Left;
            this.textIDLOKACIJE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDLOKACIJE.ReadOnly = false;
            this.textIDLOKACIJE.PromptChar = ' ';
            this.textIDLOKACIJE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDLOKACIJE.DataBindings.Add(new Binding("Value", this.bindingSourceLOKACIJE, "IDLOKACIJE"));
            this.textIDLOKACIJE.NumericType = NumericType.Integer;
            this.textIDLOKACIJE.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformLOKACIJE.Controls.Add(this.textIDLOKACIJE, 1, 0);
            this.layoutManagerformLOKACIJE.SetColumnSpan(this.textIDLOKACIJE, 1);
            this.layoutManagerformLOKACIJE.SetRowSpan(this.textIDLOKACIJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDLOKACIJE.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDLOKACIJE.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDLOKACIJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISLOKACIJE.Location = point;
            this.label1OPISLOKACIJE.Name = "label1OPISLOKACIJE";
            this.label1OPISLOKACIJE.TabIndex = 1;
            this.label1OPISLOKACIJE.Tag = "labelOPISLOKACIJE";
            this.label1OPISLOKACIJE.Text = "Opis:";
            this.label1OPISLOKACIJE.StyleSetName = "FieldUltraLabel";
            this.label1OPISLOKACIJE.AutoSize = true;
            this.label1OPISLOKACIJE.Anchor = AnchorStyles.Left;
            this.label1OPISLOKACIJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISLOKACIJE.Appearance.ForeColor = Color.Black;
            this.label1OPISLOKACIJE.BackColor = Color.Transparent;
            this.layoutManagerformLOKACIJE.Controls.Add(this.label1OPISLOKACIJE, 0, 1);
            this.layoutManagerformLOKACIJE.SetColumnSpan(this.label1OPISLOKACIJE, 1);
            this.layoutManagerformLOKACIJE.SetRowSpan(this.label1OPISLOKACIJE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISLOKACIJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISLOKACIJE.MinimumSize = size;
            size = new System.Drawing.Size(0x2e, 0x17);
            this.label1OPISLOKACIJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPISLOKACIJE.Location = point;
            this.textOPISLOKACIJE.Name = "textOPISLOKACIJE";
            this.textOPISLOKACIJE.Tag = "OPISLOKACIJE";
            this.textOPISLOKACIJE.TabIndex = 0;
            this.textOPISLOKACIJE.Anchor = AnchorStyles.Left;
            this.textOPISLOKACIJE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPISLOKACIJE.ReadOnly = false;
            this.textOPISLOKACIJE.DataBindings.Add(new Binding("Text", this.bindingSourceLOKACIJE, "OPISLOKACIJE"));
            this.textOPISLOKACIJE.MaxLength = 50;
            this.layoutManagerformLOKACIJE.Controls.Add(this.textOPISLOKACIJE, 1, 1);
            this.layoutManagerformLOKACIJE.SetColumnSpan(this.textOPISLOKACIJE, 1);
            this.layoutManagerformLOKACIJE.SetRowSpan(this.textOPISLOKACIJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPISLOKACIJE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textOPISLOKACIJE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textOPISLOKACIJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1LOK.Location = point;
            this.label1LOK.Name = "label1LOK";
            this.label1LOK.TabIndex = 1;
            this.label1LOK.Tag = "labelLOK";
            this.label1LOK.Text = "LOK:";
            this.label1LOK.StyleSetName = "FieldUltraLabel";
            this.label1LOK.AutoSize = true;
            this.label1LOK.Anchor = AnchorStyles.Left;
            this.label1LOK.Appearance.TextVAlign = VAlign.Middle;
            this.label1LOK.Appearance.ForeColor = Color.Black;
            this.label1LOK.BackColor = Color.Transparent;
            this.layoutManagerformLOKACIJE.Controls.Add(this.label1LOK, 0, 2);
            this.layoutManagerformLOKACIJE.SetColumnSpan(this.label1LOK, 1);
            this.layoutManagerformLOKACIJE.SetRowSpan(this.label1LOK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1LOK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1LOK.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x17);
            this.label1LOK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelLOK.Location = point;
            this.labelLOK.Name = "labelLOK";
            this.labelLOK.Tag = "LOK";
            this.labelLOK.TabIndex = 0;
            this.labelLOK.Anchor = AnchorStyles.Left;
            this.labelLOK.BackColor = Color.Transparent;
            this.labelLOK.DataBindings.Add(new Binding("Text", this.bindingSourceLOKACIJE, "LOK"));
            this.labelLOK.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformLOKACIJE.Controls.Add(this.labelLOK, 1, 2);
            this.layoutManagerformLOKACIJE.SetColumnSpan(this.labelLOK, 1);
            this.layoutManagerformLOKACIJE.SetRowSpan(this.labelLOK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelLOK.Margin = padding;
            size = new System.Drawing.Size(0x1b4, 0x16);
            this.labelLOK.MinimumSize = size;
            size = new System.Drawing.Size(0x1b4, 0x16);
            this.labelLOK.Size = size;
            this.Controls.Add(this.layoutManagerformLOKACIJE);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceLOKACIJE;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "LOKACIJEFormUserControl";
            this.Text = "Lokacije OS-a i SI-a";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.LOKACIJEFormUserControl_Load);
            this.layoutManagerformLOKACIJE.ResumeLayout(false);
            this.layoutManagerformLOKACIJE.PerformLayout();
            ((ISupportInitialize) this.bindingSourceLOKACIJE).EndInit();
            ((ISupportInitialize) this.textIDLOKACIJE).EndInit();
            ((ISupportInitialize) this.textOPISLOKACIJE).EndInit();
            this.dsLOKACIJEDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.LOKACIJEController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceLOKACIJE, this.LOKACIJEController.WorkItem, this))
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
            this.label1IDLOKACIJE.Text = StringResources.LOKACIJEIDLOKACIJEDescription;
            this.label1OPISLOKACIJE.Text = StringResources.LOKACIJEOPISLOKACIJEDescription;
            this.label1LOK.Text = StringResources.LOKACIJELOKDescription;
        }

        private void LOKACIJEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.LOKACIJEDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewOSRAZMJESTAJ")]
        public void NewOSRAZMJESTAJHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.LOKACIJEController.NewOSRAZMJESTAJ(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.LOKACIJEController.WorkItem.Items.Contains("LOKACIJE|LOKACIJE"))
            {
                this.LOKACIJEController.WorkItem.Items.Add(this.bindingSourceLOKACIJE, "LOKACIJE|LOKACIJE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsLOKACIJEDataSet1.LOKACIJE.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.LOKACIJEController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.LOKACIJEController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.LOKACIJEController.Update(this))
            {
                this.LOKACIJEController.DataSet = new LOKACIJEDataSet();
                DataSetUtil.AddEmptyRow(this.LOKACIJEController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.LOKACIJEController.DataSet.LOKACIJE[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDLOKACIJE.Focus();
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

        [LocalCommandHandler("ViewOSRAZMJESTAJ")]
        public void ViewOSRAZMJESTAJHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.LOKACIJEController.ViewOSRAZMJESTAJ(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDLOKACIJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDLOKACIJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDLOKACIJE = value;
            }
        }

        protected virtual UltraLabel label1LOK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1LOK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1LOK = value;
            }
        }

        protected virtual UltraLabel label1OPISLOKACIJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISLOKACIJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISLOKACIJE = value;
            }
        }

        protected virtual UltraLabel labelLOK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelLOK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelLOK = value;
            }
        }

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.LOKACIJEController LOKACIJEController { get; set; }

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

        protected virtual UltraNumericEditor textIDLOKACIJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDLOKACIJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDLOKACIJE = value;
            }
        }

        protected virtual UltraTextEditor textOPISLOKACIJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPISLOKACIJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPISLOKACIJE = value;
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

