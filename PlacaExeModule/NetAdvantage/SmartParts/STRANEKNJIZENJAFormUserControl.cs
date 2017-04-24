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
    public class STRANEKNJIZENJAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDSTRANEKNJIZENJA")]
        private UltraLabel _label1IDSTRANEKNJIZENJA;
        [AccessedThroughProperty("label1NAZIVSTRANEKNJIZENJA")]
        private UltraLabel _label1NAZIVSTRANEKNJIZENJA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDSTRANEKNJIZENJA")]
        private UltraNumericEditor _textIDSTRANEKNJIZENJA;
        [AccessedThroughProperty("textNAZIVSTRANEKNJIZENJA")]
        private UltraTextEditor _textNAZIVSTRANEKNJIZENJA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSTRANEKNJIZENJA;
        private IContainer components = null;
        private STRANEKNJIZENJADataSet dsSTRANEKNJIZENJADataSet1;
        protected TableLayoutPanel layoutManagerformSTRANEKNJIZENJA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private STRANEKNJIZENJADataSet.STRANEKNJIZENJARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "STRANEKNJIZENJA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.STRANEKNJIZENJADescription;
        private DeklaritMode m_Mode;

        public STRANEKNJIZENJAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceSTRANEKNJIZENJA.DataSource = this.STRANEKNJIZENJAController.DataSet;
            this.dsSTRANEKNJIZENJADataSet1 = this.STRANEKNJIZENJAController.DataSet;
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
                    enumerator = this.dsSTRANEKNJIZENJADataSet1.STRANEKNJIZENJA.Rows.GetEnumerator();
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
                if (this.STRANEKNJIZENJAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "STRANEKNJIZENJA", this.m_Mode, this.dsSTRANEKNJIZENJADataSet1, this.dsSTRANEKNJIZENJADataSet1.STRANEKNJIZENJA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsSTRANEKNJIZENJADataSet1.STRANEKNJIZENJA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (STRANEKNJIZENJADataSet.STRANEKNJIZENJARow) ((DataRowView) this.bindingSourceSTRANEKNJIZENJA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(STRANEKNJIZENJAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSTRANEKNJIZENJA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSTRANEKNJIZENJA).BeginInit();
            this.layoutManagerformSTRANEKNJIZENJA = new TableLayoutPanel();
            this.layoutManagerformSTRANEKNJIZENJA.SuspendLayout();
            this.layoutManagerformSTRANEKNJIZENJA.AutoSize = true;
            this.layoutManagerformSTRANEKNJIZENJA.Dock = DockStyle.Fill;
            this.layoutManagerformSTRANEKNJIZENJA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSTRANEKNJIZENJA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSTRANEKNJIZENJA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSTRANEKNJIZENJA.Size = size;
            this.layoutManagerformSTRANEKNJIZENJA.ColumnCount = 2;
            this.layoutManagerformSTRANEKNJIZENJA.RowCount = 3;
            this.layoutManagerformSTRANEKNJIZENJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSTRANEKNJIZENJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSTRANEKNJIZENJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSTRANEKNJIZENJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSTRANEKNJIZENJA.RowStyles.Add(new RowStyle());
            this.label1IDSTRANEKNJIZENJA = new UltraLabel();
            this.textIDSTRANEKNJIZENJA = new UltraNumericEditor();
            this.label1NAZIVSTRANEKNJIZENJA = new UltraLabel();
            this.textNAZIVSTRANEKNJIZENJA = new UltraTextEditor();
            ((ISupportInitialize) this.textIDSTRANEKNJIZENJA).BeginInit();
            ((ISupportInitialize) this.textNAZIVSTRANEKNJIZENJA).BeginInit();
            this.dsSTRANEKNJIZENJADataSet1 = new STRANEKNJIZENJADataSet();
            this.dsSTRANEKNJIZENJADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSTRANEKNJIZENJADataSet1.DataSetName = "dsSTRANEKNJIZENJA";
            this.dsSTRANEKNJIZENJADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSTRANEKNJIZENJA.DataSource = this.dsSTRANEKNJIZENJADataSet1;
            this.bindingSourceSTRANEKNJIZENJA.DataMember = "STRANEKNJIZENJA";
            ((ISupportInitialize) this.bindingSourceSTRANEKNJIZENJA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDSTRANEKNJIZENJA.Location = point;
            this.label1IDSTRANEKNJIZENJA.Name = "label1IDSTRANEKNJIZENJA";
            this.label1IDSTRANEKNJIZENJA.TabIndex = 1;
            this.label1IDSTRANEKNJIZENJA.Tag = "labelIDSTRANEKNJIZENJA";
            this.label1IDSTRANEKNJIZENJA.Text = "Šifra strane:";
            this.label1IDSTRANEKNJIZENJA.StyleSetName = "FieldUltraLabel";
            this.label1IDSTRANEKNJIZENJA.AutoSize = true;
            this.label1IDSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.label1IDSTRANEKNJIZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDSTRANEKNJIZENJA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDSTRANEKNJIZENJA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDSTRANEKNJIZENJA.ImageSize = size;
            this.label1IDSTRANEKNJIZENJA.Appearance.ForeColor = Color.Black;
            this.label1IDSTRANEKNJIZENJA.BackColor = Color.Transparent;
            this.layoutManagerformSTRANEKNJIZENJA.Controls.Add(this.label1IDSTRANEKNJIZENJA, 0, 0);
            this.layoutManagerformSTRANEKNJIZENJA.SetColumnSpan(this.label1IDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSTRANEKNJIZENJA.SetRowSpan(this.label1IDSTRANEKNJIZENJA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x58, 0x17);
            this.label1IDSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDSTRANEKNJIZENJA.Location = point;
            this.textIDSTRANEKNJIZENJA.Name = "textIDSTRANEKNJIZENJA";
            this.textIDSTRANEKNJIZENJA.Tag = "IDSTRANEKNJIZENJA";
            this.textIDSTRANEKNJIZENJA.TabIndex = 0;
            this.textIDSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.textIDSTRANEKNJIZENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDSTRANEKNJIZENJA.ReadOnly = false;
            this.textIDSTRANEKNJIZENJA.PromptChar = ' ';
            this.textIDSTRANEKNJIZENJA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDSTRANEKNJIZENJA.DataBindings.Add(new Binding("Value", this.bindingSourceSTRANEKNJIZENJA, "IDSTRANEKNJIZENJA"));
            this.textIDSTRANEKNJIZENJA.NumericType = NumericType.Integer;
            this.textIDSTRANEKNJIZENJA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformSTRANEKNJIZENJA.Controls.Add(this.textIDSTRANEKNJIZENJA, 1, 0);
            this.layoutManagerformSTRANEKNJIZENJA.SetColumnSpan(this.textIDSTRANEKNJIZENJA, 1);
            this.layoutManagerformSTRANEKNJIZENJA.SetRowSpan(this.textIDSTRANEKNJIZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVSTRANEKNJIZENJA.Location = point;
            this.label1NAZIVSTRANEKNJIZENJA.Name = "label1NAZIVSTRANEKNJIZENJA";
            this.label1NAZIVSTRANEKNJIZENJA.TabIndex = 1;
            this.label1NAZIVSTRANEKNJIZENJA.Tag = "labelNAZIVSTRANEKNJIZENJA";
            this.label1NAZIVSTRANEKNJIZENJA.Text = "Naziv strane:";
            this.label1NAZIVSTRANEKNJIZENJA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVSTRANEKNJIZENJA.AutoSize = true;
            this.label1NAZIVSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.label1NAZIVSTRANEKNJIZENJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVSTRANEKNJIZENJA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVSTRANEKNJIZENJA.BackColor = Color.Transparent;
            this.layoutManagerformSTRANEKNJIZENJA.Controls.Add(this.label1NAZIVSTRANEKNJIZENJA, 0, 1);
            this.layoutManagerformSTRANEKNJIZENJA.SetColumnSpan(this.label1NAZIVSTRANEKNJIZENJA, 1);
            this.layoutManagerformSTRANEKNJIZENJA.SetRowSpan(this.label1NAZIVSTRANEKNJIZENJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0x60, 0x17);
            this.label1NAZIVSTRANEKNJIZENJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVSTRANEKNJIZENJA.Location = point;
            this.textNAZIVSTRANEKNJIZENJA.Name = "textNAZIVSTRANEKNJIZENJA";
            this.textNAZIVSTRANEKNJIZENJA.Tag = "NAZIVSTRANEKNJIZENJA";
            this.textNAZIVSTRANEKNJIZENJA.TabIndex = 0;
            this.textNAZIVSTRANEKNJIZENJA.Anchor = AnchorStyles.Left;
            this.textNAZIVSTRANEKNJIZENJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVSTRANEKNJIZENJA.ReadOnly = false;
            this.textNAZIVSTRANEKNJIZENJA.DataBindings.Add(new Binding("Text", this.bindingSourceSTRANEKNJIZENJA, "NAZIVSTRANEKNJIZENJA"));
            this.textNAZIVSTRANEKNJIZENJA.MaxLength = 30;
            this.layoutManagerformSTRANEKNJIZENJA.Controls.Add(this.textNAZIVSTRANEKNJIZENJA, 1, 1);
            this.layoutManagerformSTRANEKNJIZENJA.SetColumnSpan(this.textNAZIVSTRANEKNJIZENJA, 1);
            this.layoutManagerformSTRANEKNJIZENJA.SetRowSpan(this.textNAZIVSTRANEKNJIZENJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVSTRANEKNJIZENJA.Margin = padding;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textNAZIVSTRANEKNJIZENJA.MinimumSize = size;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textNAZIVSTRANEKNJIZENJA.Size = size;
            this.Controls.Add(this.layoutManagerformSTRANEKNJIZENJA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSTRANEKNJIZENJA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "STRANEKNJIZENJAFormUserControl";
            this.Text = "Strane knjiženja";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.STRANEKNJIZENJAFormUserControl_Load);
            this.layoutManagerformSTRANEKNJIZENJA.ResumeLayout(false);
            this.layoutManagerformSTRANEKNJIZENJA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSTRANEKNJIZENJA).EndInit();
            ((ISupportInitialize) this.textIDSTRANEKNJIZENJA).EndInit();
            ((ISupportInitialize) this.textNAZIVSTRANEKNJIZENJA).EndInit();
            this.dsSTRANEKNJIZENJADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.STRANEKNJIZENJAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSTRANEKNJIZENJA, this.STRANEKNJIZENJAController.WorkItem, this))
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
            this.label1IDSTRANEKNJIZENJA.Text = StringResources.STRANEKNJIZENJAIDSTRANEKNJIZENJADescription;
            this.label1NAZIVSTRANEKNJIZENJA.Text = StringResources.STRANEKNJIZENJANAZIVSTRANEKNJIZENJADescription;
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
            if (!this.STRANEKNJIZENJAController.WorkItem.Items.Contains("STRANEKNJIZENJA|STRANEKNJIZENJA"))
            {
                this.STRANEKNJIZENJAController.WorkItem.Items.Add(this.bindingSourceSTRANEKNJIZENJA, "STRANEKNJIZENJA|STRANEKNJIZENJA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsSTRANEKNJIZENJADataSet1.STRANEKNJIZENJA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.STRANEKNJIZENJAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.STRANEKNJIZENJAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.STRANEKNJIZENJAController.Update(this))
            {
                this.STRANEKNJIZENJAController.DataSet = new STRANEKNJIZENJADataSet();
                DataSetUtil.AddEmptyRow(this.STRANEKNJIZENJAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.STRANEKNJIZENJAController.DataSet.STRANEKNJIZENJA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDSTRANEKNJIZENJA.Focus();
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

        private void STRANEKNJIZENJAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.STRANEKNJIZENJADescription;
            this.errorProvider1.ContainerControl = this;
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

        protected virtual UltraLabel label1IDSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDSTRANEKNJIZENJA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVSTRANEKNJIZENJA = value;
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
        public NetAdvantage.Controllers.STRANEKNJIZENJAController STRANEKNJIZENJAController { get; set; }

        protected virtual UltraNumericEditor textIDSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDSTRANEKNJIZENJA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVSTRANEKNJIZENJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVSTRANEKNJIZENJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVSTRANEKNJIZENJA = value;
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

