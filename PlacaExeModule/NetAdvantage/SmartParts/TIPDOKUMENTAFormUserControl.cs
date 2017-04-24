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
    public class TIPDOKUMENTAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDTIPDOKUMENTA")]
        private UltraLabel _label1IDTIPDOKUMENTA;
        [AccessedThroughProperty("label1NAZIVTIPDOKUMENTA")]
        private UltraLabel _label1NAZIVTIPDOKUMENTA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDTIPDOKUMENTA")]
        private UltraNumericEditor _textIDTIPDOKUMENTA;
        [AccessedThroughProperty("textNAZIVTIPDOKUMENTA")]
        private UltraTextEditor _textNAZIVTIPDOKUMENTA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceTIPDOKUMENTA;
        private IContainer components = null;
        private TIPDOKUMENTADataSet dsTIPDOKUMENTADataSet1;
        protected TableLayoutPanel layoutManagerformTIPDOKUMENTA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private TIPDOKUMENTADataSet.TIPDOKUMENTARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "TIPDOKUMENTA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.TIPDOKUMENTADescription;
        private DeklaritMode m_Mode;

        public TIPDOKUMENTAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceTIPDOKUMENTA.DataSource = this.TIPDOKUMENTAController.DataSet;
            this.dsTIPDOKUMENTADataSet1 = this.TIPDOKUMENTAController.DataSet;
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
                    enumerator = this.dsTIPDOKUMENTADataSet1.TIPDOKUMENTA.Rows.GetEnumerator();
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
                if (this.TIPDOKUMENTAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "TIPDOKUMENTA", this.m_Mode, this.dsTIPDOKUMENTADataSet1, this.dsTIPDOKUMENTADataSet1.TIPDOKUMENTA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsTIPDOKUMENTADataSet1.TIPDOKUMENTA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (TIPDOKUMENTADataSet.TIPDOKUMENTARow) ((DataRowView) this.bindingSourceTIPDOKUMENTA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(TIPDOKUMENTAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceTIPDOKUMENTA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceTIPDOKUMENTA).BeginInit();
            this.layoutManagerformTIPDOKUMENTA = new TableLayoutPanel();
            this.layoutManagerformTIPDOKUMENTA.SuspendLayout();
            this.layoutManagerformTIPDOKUMENTA.AutoSize = true;
            this.layoutManagerformTIPDOKUMENTA.Dock = DockStyle.Fill;
            this.layoutManagerformTIPDOKUMENTA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformTIPDOKUMENTA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformTIPDOKUMENTA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformTIPDOKUMENTA.Size = size;
            this.layoutManagerformTIPDOKUMENTA.ColumnCount = 2;
            this.layoutManagerformTIPDOKUMENTA.RowCount = 3;
            this.layoutManagerformTIPDOKUMENTA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformTIPDOKUMENTA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformTIPDOKUMENTA.RowStyles.Add(new RowStyle());
            this.layoutManagerformTIPDOKUMENTA.RowStyles.Add(new RowStyle());
            this.layoutManagerformTIPDOKUMENTA.RowStyles.Add(new RowStyle());
            this.label1IDTIPDOKUMENTA = new UltraLabel();
            this.textIDTIPDOKUMENTA = new UltraNumericEditor();
            this.label1NAZIVTIPDOKUMENTA = new UltraLabel();
            this.textNAZIVTIPDOKUMENTA = new UltraTextEditor();
            ((ISupportInitialize) this.textIDTIPDOKUMENTA).BeginInit();
            ((ISupportInitialize) this.textNAZIVTIPDOKUMENTA).BeginInit();
            this.dsTIPDOKUMENTADataSet1 = new TIPDOKUMENTADataSet();
            this.dsTIPDOKUMENTADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsTIPDOKUMENTADataSet1.DataSetName = "dsTIPDOKUMENTA";
            this.dsTIPDOKUMENTADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceTIPDOKUMENTA.DataSource = this.dsTIPDOKUMENTADataSet1;
            this.bindingSourceTIPDOKUMENTA.DataMember = "TIPDOKUMENTA";
            ((ISupportInitialize) this.bindingSourceTIPDOKUMENTA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDTIPDOKUMENTA.Location = point;
            this.label1IDTIPDOKUMENTA.Name = "label1IDTIPDOKUMENTA";
            this.label1IDTIPDOKUMENTA.TabIndex = 1;
            this.label1IDTIPDOKUMENTA.Tag = "labelIDTIPDOKUMENTA";
            this.label1IDTIPDOKUMENTA.Text = "Šifr. tipa dok.:";
            this.label1IDTIPDOKUMENTA.StyleSetName = "FieldUltraLabel";
            this.label1IDTIPDOKUMENTA.AutoSize = true;
            this.label1IDTIPDOKUMENTA.Anchor = AnchorStyles.Left;
            this.label1IDTIPDOKUMENTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDTIPDOKUMENTA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDTIPDOKUMENTA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDTIPDOKUMENTA.ImageSize = size;
            this.label1IDTIPDOKUMENTA.Appearance.ForeColor = Color.Black;
            this.label1IDTIPDOKUMENTA.BackColor = Color.Transparent;
            this.layoutManagerformTIPDOKUMENTA.Controls.Add(this.label1IDTIPDOKUMENTA, 0, 0);
            this.layoutManagerformTIPDOKUMENTA.SetColumnSpan(this.label1IDTIPDOKUMENTA, 1);
            this.layoutManagerformTIPDOKUMENTA.SetRowSpan(this.label1IDTIPDOKUMENTA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDTIPDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDTIPDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x17);
            this.label1IDTIPDOKUMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDTIPDOKUMENTA.Location = point;
            this.textIDTIPDOKUMENTA.Name = "textIDTIPDOKUMENTA";
            this.textIDTIPDOKUMENTA.Tag = "IDTIPDOKUMENTA";
            this.textIDTIPDOKUMENTA.TabIndex = 0;
            this.textIDTIPDOKUMENTA.Anchor = AnchorStyles.Left;
            this.textIDTIPDOKUMENTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDTIPDOKUMENTA.ReadOnly = false;
            this.textIDTIPDOKUMENTA.PromptChar = ' ';
            this.textIDTIPDOKUMENTA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDTIPDOKUMENTA.DataBindings.Add(new Binding("Value", this.bindingSourceTIPDOKUMENTA, "IDTIPDOKUMENTA"));
            this.textIDTIPDOKUMENTA.NumericType = NumericType.Integer;
            this.textIDTIPDOKUMENTA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformTIPDOKUMENTA.Controls.Add(this.textIDTIPDOKUMENTA, 1, 0);
            this.layoutManagerformTIPDOKUMENTA.SetColumnSpan(this.textIDTIPDOKUMENTA, 1);
            this.layoutManagerformTIPDOKUMENTA.SetRowSpan(this.textIDTIPDOKUMENTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDTIPDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDTIPDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDTIPDOKUMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVTIPDOKUMENTA.Location = point;
            this.label1NAZIVTIPDOKUMENTA.Name = "label1NAZIVTIPDOKUMENTA";
            this.label1NAZIVTIPDOKUMENTA.TabIndex = 1;
            this.label1NAZIVTIPDOKUMENTA.Tag = "labelNAZIVTIPDOKUMENTA";
            this.label1NAZIVTIPDOKUMENTA.Text = "Tip dokumenta:";
            this.label1NAZIVTIPDOKUMENTA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVTIPDOKUMENTA.AutoSize = true;
            this.label1NAZIVTIPDOKUMENTA.Anchor = AnchorStyles.Left;
            this.label1NAZIVTIPDOKUMENTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVTIPDOKUMENTA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVTIPDOKUMENTA.BackColor = Color.Transparent;
            this.layoutManagerformTIPDOKUMENTA.Controls.Add(this.label1NAZIVTIPDOKUMENTA, 0, 1);
            this.layoutManagerformTIPDOKUMENTA.SetColumnSpan(this.label1NAZIVTIPDOKUMENTA, 1);
            this.layoutManagerformTIPDOKUMENTA.SetRowSpan(this.label1NAZIVTIPDOKUMENTA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVTIPDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVTIPDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x70, 0x17);
            this.label1NAZIVTIPDOKUMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVTIPDOKUMENTA.Location = point;
            this.textNAZIVTIPDOKUMENTA.Name = "textNAZIVTIPDOKUMENTA";
            this.textNAZIVTIPDOKUMENTA.Tag = "NAZIVTIPDOKUMENTA";
            this.textNAZIVTIPDOKUMENTA.TabIndex = 0;
            this.textNAZIVTIPDOKUMENTA.Anchor = AnchorStyles.Left;
            this.textNAZIVTIPDOKUMENTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVTIPDOKUMENTA.ReadOnly = false;
            this.textNAZIVTIPDOKUMENTA.DataBindings.Add(new Binding("Text", this.bindingSourceTIPDOKUMENTA, "NAZIVTIPDOKUMENTA"));
            this.textNAZIVTIPDOKUMENTA.MaxLength = 50;
            this.layoutManagerformTIPDOKUMENTA.Controls.Add(this.textNAZIVTIPDOKUMENTA, 1, 1);
            this.layoutManagerformTIPDOKUMENTA.SetColumnSpan(this.textNAZIVTIPDOKUMENTA, 1);
            this.layoutManagerformTIPDOKUMENTA.SetRowSpan(this.textNAZIVTIPDOKUMENTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVTIPDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVTIPDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVTIPDOKUMENTA.Size = size;
            this.Controls.Add(this.layoutManagerformTIPDOKUMENTA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceTIPDOKUMENTA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "TIPDOKUMENTAFormUserControl";
            this.Text = "TIPDOKUMENTA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.TIPDOKUMENTAFormUserControl_Load);
            this.layoutManagerformTIPDOKUMENTA.ResumeLayout(false);
            this.layoutManagerformTIPDOKUMENTA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceTIPDOKUMENTA).EndInit();
            ((ISupportInitialize) this.textIDTIPDOKUMENTA).EndInit();
            ((ISupportInitialize) this.textNAZIVTIPDOKUMENTA).EndInit();
            this.dsTIPDOKUMENTADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.TIPDOKUMENTAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceTIPDOKUMENTA, this.TIPDOKUMENTAController.WorkItem, this))
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
            this.label1IDTIPDOKUMENTA.Text = StringResources.TIPDOKUMENTAIDTIPDOKUMENTADescription;
            this.label1NAZIVTIPDOKUMENTA.Text = StringResources.TIPDOKUMENTANAZIVTIPDOKUMENTADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewDOKUMENT")]
        public void NewDOKUMENTHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.TIPDOKUMENTAController.NewDOKUMENT(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.TIPDOKUMENTAController.WorkItem.Items.Contains("TIPDOKUMENTA|TIPDOKUMENTA"))
            {
                this.TIPDOKUMENTAController.WorkItem.Items.Add(this.bindingSourceTIPDOKUMENTA, "TIPDOKUMENTA|TIPDOKUMENTA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsTIPDOKUMENTADataSet1.TIPDOKUMENTA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.TIPDOKUMENTAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.TIPDOKUMENTAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.TIPDOKUMENTAController.Update(this))
            {
                this.TIPDOKUMENTAController.DataSet = new TIPDOKUMENTADataSet();
                DataSetUtil.AddEmptyRow(this.TIPDOKUMENTAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.TIPDOKUMENTAController.DataSet.TIPDOKUMENTA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDTIPDOKUMENTA.Focus();
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

        private void TIPDOKUMENTAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.TIPDOKUMENTADescription;
            this.errorProvider1.ContainerControl = this;
        }

        [LocalCommandHandler("ViewDOKUMENT")]
        public void ViewDOKUMENTHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.TIPDOKUMENTAController.ViewDOKUMENT(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDTIPDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDTIPDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDTIPDOKUMENTA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVTIPDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVTIPDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVTIPDOKUMENTA = value;
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

        protected virtual UltraNumericEditor textIDTIPDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDTIPDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDTIPDOKUMENTA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVTIPDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVTIPDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVTIPDOKUMENTA = value;
            }
        }

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.TIPDOKUMENTAController TIPDOKUMENTAController { get; set; }

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

