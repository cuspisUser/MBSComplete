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
    public class DDKOLONAIDDFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDKOLONAIDD")]
        private UltraLabel _label1IDKOLONAIDD;
        [AccessedThroughProperty("label1NAZIVKOLONAIDD")]
        private UltraLabel _label1NAZIVKOLONAIDD;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDKOLONAIDD")]
        private UltraNumericEditor _textIDKOLONAIDD;
        [AccessedThroughProperty("textNAZIVKOLONAIDD")]
        private UltraTextEditor _textNAZIVKOLONAIDD;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceDDKOLONAIDD;
        private IContainer components = null;
        private DDKOLONAIDDDataSet dsDDKOLONAIDDDataSet1;
        protected TableLayoutPanel layoutManagerformDDKOLONAIDD;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private DDKOLONAIDDDataSet.DDKOLONAIDDRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "DDKOLONAIDD";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.DDKOLONAIDDDescription;
        private DeklaritMode m_Mode;

        public DDKOLONAIDDFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceDDKOLONAIDD.DataSource = this.DDKOLONAIDDController.DataSet;
            this.dsDDKOLONAIDDDataSet1 = this.DDKOLONAIDDController.DataSet;
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

        private void DDKOLONAIDDFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.DDKOLONAIDDDescription;
            this.errorProvider1.ContainerControl = this;
        }

        [LocalCommandHandler("DeleteInstance")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.dsDDKOLONAIDDDataSet1.DDKOLONAIDD.Rows.GetEnumerator();
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
                if (this.DDKOLONAIDDController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "DDKOLONAIDD", this.m_Mode, this.dsDDKOLONAIDDDataSet1, this.dsDDKOLONAIDDDataSet1.DDKOLONAIDD.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsDDKOLONAIDDDataSet1.DDKOLONAIDD[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (DDKOLONAIDDDataSet.DDKOLONAIDDRow) ((DataRowView) this.bindingSourceDDKOLONAIDD.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(DDKOLONAIDDFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceDDKOLONAIDD = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDDKOLONAIDD).BeginInit();
            this.layoutManagerformDDKOLONAIDD = new TableLayoutPanel();
            this.layoutManagerformDDKOLONAIDD.SuspendLayout();
            this.layoutManagerformDDKOLONAIDD.AutoSize = true;
            this.layoutManagerformDDKOLONAIDD.Dock = DockStyle.Fill;
            this.layoutManagerformDDKOLONAIDD.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformDDKOLONAIDD.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformDDKOLONAIDD.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformDDKOLONAIDD.Size = size;
            this.layoutManagerformDDKOLONAIDD.ColumnCount = 2;
            this.layoutManagerformDDKOLONAIDD.RowCount = 3;
            this.layoutManagerformDDKOLONAIDD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDDKOLONAIDD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDDKOLONAIDD.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDKOLONAIDD.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDKOLONAIDD.RowStyles.Add(new RowStyle());
            this.label1IDKOLONAIDD = new UltraLabel();
            this.textIDKOLONAIDD = new UltraNumericEditor();
            this.label1NAZIVKOLONAIDD = new UltraLabel();
            this.textNAZIVKOLONAIDD = new UltraTextEditor();
            ((ISupportInitialize) this.textIDKOLONAIDD).BeginInit();
            ((ISupportInitialize) this.textNAZIVKOLONAIDD).BeginInit();
            this.dsDDKOLONAIDDDataSet1 = new DDKOLONAIDDDataSet();
            this.dsDDKOLONAIDDDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsDDKOLONAIDDDataSet1.DataSetName = "dsDDKOLONAIDD";
            this.dsDDKOLONAIDDDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceDDKOLONAIDD.DataSource = this.dsDDKOLONAIDDDataSet1;
            this.bindingSourceDDKOLONAIDD.DataMember = "DDKOLONAIDD";
            ((ISupportInitialize) this.bindingSourceDDKOLONAIDD).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDKOLONAIDD.Location = point;
            this.label1IDKOLONAIDD.Name = "label1IDKOLONAIDD";
            this.label1IDKOLONAIDD.TabIndex = 1;
            this.label1IDKOLONAIDD.Tag = "labelIDKOLONAIDD";
            this.label1IDKOLONAIDD.Text = "Kolona:";
            this.label1IDKOLONAIDD.StyleSetName = "FieldUltraLabel";
            this.label1IDKOLONAIDD.AutoSize = true;
            this.label1IDKOLONAIDD.Anchor = AnchorStyles.Left;
            this.label1IDKOLONAIDD.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDKOLONAIDD.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDKOLONAIDD.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDKOLONAIDD.ImageSize = size;
            this.label1IDKOLONAIDD.Appearance.ForeColor = Color.Black;
            this.label1IDKOLONAIDD.BackColor = Color.Transparent;
            this.layoutManagerformDDKOLONAIDD.Controls.Add(this.label1IDKOLONAIDD, 0, 0);
            this.layoutManagerformDDKOLONAIDD.SetColumnSpan(this.label1IDKOLONAIDD, 1);
            this.layoutManagerformDDKOLONAIDD.SetRowSpan(this.label1IDKOLONAIDD, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDKOLONAIDD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDKOLONAIDD.MinimumSize = size;
            size = new System.Drawing.Size(0x3b, 0x17);
            this.label1IDKOLONAIDD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDKOLONAIDD.Location = point;
            this.textIDKOLONAIDD.Name = "textIDKOLONAIDD";
            this.textIDKOLONAIDD.Tag = "IDKOLONAIDD";
            this.textIDKOLONAIDD.TabIndex = 0;
            this.textIDKOLONAIDD.Anchor = AnchorStyles.Left;
            this.textIDKOLONAIDD.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDKOLONAIDD.ReadOnly = false;
            this.textIDKOLONAIDD.PromptChar = ' ';
            this.textIDKOLONAIDD.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDKOLONAIDD.DataBindings.Add(new Binding("Value", this.bindingSourceDDKOLONAIDD, "IDKOLONAIDD"));
            this.textIDKOLONAIDD.NumericType = NumericType.Integer;
            this.textIDKOLONAIDD.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformDDKOLONAIDD.Controls.Add(this.textIDKOLONAIDD, 1, 0);
            this.layoutManagerformDDKOLONAIDD.SetColumnSpan(this.textIDKOLONAIDD, 1);
            this.layoutManagerformDDKOLONAIDD.SetRowSpan(this.textIDKOLONAIDD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDKOLONAIDD.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDKOLONAIDD.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDKOLONAIDD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVKOLONAIDD.Location = point;
            this.label1NAZIVKOLONAIDD.Name = "label1NAZIVKOLONAIDD";
            this.label1NAZIVKOLONAIDD.TabIndex = 1;
            this.label1NAZIVKOLONAIDD.Tag = "labelNAZIVKOLONAIDD";
            this.label1NAZIVKOLONAIDD.Text = "Naziv kolone:";
            this.label1NAZIVKOLONAIDD.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVKOLONAIDD.AutoSize = true;
            this.label1NAZIVKOLONAIDD.Anchor = AnchorStyles.Left;
            this.label1NAZIVKOLONAIDD.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVKOLONAIDD.Appearance.ForeColor = Color.Black;
            this.label1NAZIVKOLONAIDD.BackColor = Color.Transparent;
            this.layoutManagerformDDKOLONAIDD.Controls.Add(this.label1NAZIVKOLONAIDD, 0, 1);
            this.layoutManagerformDDKOLONAIDD.SetColumnSpan(this.label1NAZIVKOLONAIDD, 1);
            this.layoutManagerformDDKOLONAIDD.SetRowSpan(this.label1NAZIVKOLONAIDD, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVKOLONAIDD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVKOLONAIDD.MinimumSize = size;
            size = new System.Drawing.Size(0x63, 0x17);
            this.label1NAZIVKOLONAIDD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVKOLONAIDD.Location = point;
            this.textNAZIVKOLONAIDD.Name = "textNAZIVKOLONAIDD";
            this.textNAZIVKOLONAIDD.Tag = "NAZIVKOLONAIDD";
            this.textNAZIVKOLONAIDD.TabIndex = 0;
            this.textNAZIVKOLONAIDD.Anchor = AnchorStyles.Left;
            this.textNAZIVKOLONAIDD.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVKOLONAIDD.ReadOnly = false;
            this.textNAZIVKOLONAIDD.DataBindings.Add(new Binding("Text", this.bindingSourceDDKOLONAIDD, "NAZIVKOLONAIDD"));
            this.textNAZIVKOLONAIDD.MaxLength = 50;
            this.layoutManagerformDDKOLONAIDD.Controls.Add(this.textNAZIVKOLONAIDD, 1, 1);
            this.layoutManagerformDDKOLONAIDD.SetColumnSpan(this.textNAZIVKOLONAIDD, 1);
            this.layoutManagerformDDKOLONAIDD.SetRowSpan(this.textNAZIVKOLONAIDD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVKOLONAIDD.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVKOLONAIDD.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVKOLONAIDD.Size = size;
            this.Controls.Add(this.layoutManagerformDDKOLONAIDD);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceDDKOLONAIDD;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "DDKOLONAIDDFormUserControl";
            this.Text = "Kolona IDD obrasca";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.DDKOLONAIDDFormUserControl_Load);
            this.layoutManagerformDDKOLONAIDD.ResumeLayout(false);
            this.layoutManagerformDDKOLONAIDD.PerformLayout();
            ((ISupportInitialize) this.bindingSourceDDKOLONAIDD).EndInit();
            ((ISupportInitialize) this.textIDKOLONAIDD).EndInit();
            ((ISupportInitialize) this.textNAZIVKOLONAIDD).EndInit();
            this.dsDDKOLONAIDDDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.DDKOLONAIDDController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceDDKOLONAIDD, this.DDKOLONAIDDController.WorkItem, this))
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
            this.label1IDKOLONAIDD.Text = StringResources.DDKOLONAIDDIDKOLONAIDDDescription;
            this.label1NAZIVKOLONAIDD.Text = StringResources.DDKOLONAIDDNAZIVKOLONAIDDDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewDDKATEGORIJA")]
        public void NewDDKATEGORIJAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.DDKOLONAIDDController.NewDDKATEGORIJA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.DDKOLONAIDDController.WorkItem.Items.Contains("DDKOLONAIDD|DDKOLONAIDD"))
            {
                this.DDKOLONAIDDController.WorkItem.Items.Add(this.bindingSourceDDKOLONAIDD, "DDKOLONAIDD|DDKOLONAIDD");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsDDKOLONAIDDDataSet1.DDKOLONAIDD.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.DDKOLONAIDDController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DDKOLONAIDDController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DDKOLONAIDDController.Update(this))
            {
                this.DDKOLONAIDDController.DataSet = new DDKOLONAIDDDataSet();
                DataSetUtil.AddEmptyRow(this.DDKOLONAIDDController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.DDKOLONAIDDController.DataSet.DDKOLONAIDD[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDKOLONAIDD.Focus();
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

        [LocalCommandHandler("ViewDDKATEGORIJA")]
        public void ViewDDKATEGORIJAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.DDKOLONAIDDController.ViewDDKATEGORIJA(this.m_CurrentRow);
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.DDKOLONAIDDController DDKOLONAIDDController { get; set; }

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

        protected virtual UltraLabel label1IDKOLONAIDD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDKOLONAIDD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDKOLONAIDD = value;
            }
        }

        protected virtual UltraLabel label1NAZIVKOLONAIDD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVKOLONAIDD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVKOLONAIDD = value;
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

        protected virtual UltraNumericEditor textIDKOLONAIDD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDKOLONAIDD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDKOLONAIDD = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVKOLONAIDD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVKOLONAIDD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVKOLONAIDD = value;
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

