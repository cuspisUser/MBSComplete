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
    public class IZVORDOKUMENTAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1NAZIVIZVORA")]
        private UltraLabel _label1NAZIVIZVORA;
        [AccessedThroughProperty("label1SIFRAIZVORA")]
        private UltraLabel _label1SIFRAIZVORA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textNAZIVIZVORA")]
        private UltraTextEditor _textNAZIVIZVORA;
        [AccessedThroughProperty("textSIFRAIZVORA")]
        private UltraTextEditor _textSIFRAIZVORA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceIZVORDOKUMENTA;
        private IContainer components = null;
        private IZVORDOKUMENTADataSet dsIZVORDOKUMENTADataSet1;
        protected TableLayoutPanel layoutManagerformIZVORDOKUMENTA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private IZVORDOKUMENTADataSet.IZVORDOKUMENTARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "IZVORDOKUMENTA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.IZVORDOKUMENTADescription;
        private DeklaritMode m_Mode;

        public IZVORDOKUMENTAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceIZVORDOKUMENTA.DataSource = this.IZVORDOKUMENTAController.DataSet;
            this.dsIZVORDOKUMENTADataSet1 = this.IZVORDOKUMENTAController.DataSet;
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
                    enumerator = this.dsIZVORDOKUMENTADataSet1.IZVORDOKUMENTA.Rows.GetEnumerator();
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
                if (this.IZVORDOKUMENTAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "IZVORDOKUMENTA", this.m_Mode, this.dsIZVORDOKUMENTADataSet1, this.dsIZVORDOKUMENTADataSet1.IZVORDOKUMENTA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsIZVORDOKUMENTADataSet1.IZVORDOKUMENTA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (IZVORDOKUMENTADataSet.IZVORDOKUMENTARow) ((DataRowView) this.bindingSourceIZVORDOKUMENTA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(IZVORDOKUMENTAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceIZVORDOKUMENTA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceIZVORDOKUMENTA).BeginInit();
            this.layoutManagerformIZVORDOKUMENTA = new TableLayoutPanel();
            this.layoutManagerformIZVORDOKUMENTA.SuspendLayout();
            this.layoutManagerformIZVORDOKUMENTA.AutoSize = true;
            this.layoutManagerformIZVORDOKUMENTA.Dock = DockStyle.Fill;
            this.layoutManagerformIZVORDOKUMENTA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformIZVORDOKUMENTA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformIZVORDOKUMENTA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformIZVORDOKUMENTA.Size = size;
            this.layoutManagerformIZVORDOKUMENTA.ColumnCount = 2;
            this.layoutManagerformIZVORDOKUMENTA.RowCount = 3;
            this.layoutManagerformIZVORDOKUMENTA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformIZVORDOKUMENTA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformIZVORDOKUMENTA.RowStyles.Add(new RowStyle());
            this.layoutManagerformIZVORDOKUMENTA.RowStyles.Add(new RowStyle());
            this.layoutManagerformIZVORDOKUMENTA.RowStyles.Add(new RowStyle());
            this.label1SIFRAIZVORA = new UltraLabel();
            this.textSIFRAIZVORA = new UltraTextEditor();
            this.label1NAZIVIZVORA = new UltraLabel();
            this.textNAZIVIZVORA = new UltraTextEditor();
            ((ISupportInitialize) this.textSIFRAIZVORA).BeginInit();
            ((ISupportInitialize) this.textNAZIVIZVORA).BeginInit();
            this.dsIZVORDOKUMENTADataSet1 = new IZVORDOKUMENTADataSet();
            this.dsIZVORDOKUMENTADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsIZVORDOKUMENTADataSet1.DataSetName = "dsIZVORDOKUMENTA";
            this.dsIZVORDOKUMENTADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceIZVORDOKUMENTA.DataSource = this.dsIZVORDOKUMENTADataSet1;
            this.bindingSourceIZVORDOKUMENTA.DataMember = "IZVORDOKUMENTA";
            ((ISupportInitialize) this.bindingSourceIZVORDOKUMENTA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAIZVORA.Location = point;
            this.label1SIFRAIZVORA.Name = "label1SIFRAIZVORA";
            this.label1SIFRAIZVORA.TabIndex = 1;
            this.label1SIFRAIZVORA.Tag = "labelSIFRAIZVORA";
            this.label1SIFRAIZVORA.Text = "SIFRAIZVORA:";
            this.label1SIFRAIZVORA.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAIZVORA.AutoSize = true;
            this.label1SIFRAIZVORA.Anchor = AnchorStyles.Left;
            this.label1SIFRAIZVORA.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAIZVORA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1SIFRAIZVORA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1SIFRAIZVORA.ImageSize = size;
            this.label1SIFRAIZVORA.Appearance.ForeColor = Color.Black;
            this.label1SIFRAIZVORA.BackColor = Color.Transparent;
            this.layoutManagerformIZVORDOKUMENTA.Controls.Add(this.label1SIFRAIZVORA, 0, 0);
            this.layoutManagerformIZVORDOKUMENTA.SetColumnSpan(this.label1SIFRAIZVORA, 1);
            this.layoutManagerformIZVORDOKUMENTA.SetRowSpan(this.label1SIFRAIZVORA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAIZVORA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAIZVORA.MinimumSize = size;
            size = new System.Drawing.Size(0x67, 0x17);
            this.label1SIFRAIZVORA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSIFRAIZVORA.Location = point;
            this.textSIFRAIZVORA.Name = "textSIFRAIZVORA";
            this.textSIFRAIZVORA.Tag = "SIFRAIZVORA";
            this.textSIFRAIZVORA.TabIndex = 0;
            this.textSIFRAIZVORA.Anchor = AnchorStyles.Left;
            this.textSIFRAIZVORA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSIFRAIZVORA.ReadOnly = false;
            this.textSIFRAIZVORA.DataBindings.Add(new Binding("Text", this.bindingSourceIZVORDOKUMENTA, "SIFRAIZVORA"));
            this.textSIFRAIZVORA.MaxLength = 3;
            this.layoutManagerformIZVORDOKUMENTA.Controls.Add(this.textSIFRAIZVORA, 1, 0);
            this.layoutManagerformIZVORDOKUMENTA.SetColumnSpan(this.textSIFRAIZVORA, 1);
            this.layoutManagerformIZVORDOKUMENTA.SetRowSpan(this.textSIFRAIZVORA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSIFRAIZVORA.Margin = padding;
            size = new System.Drawing.Size(0x25, 0x16);
            this.textSIFRAIZVORA.MinimumSize = size;
            size = new System.Drawing.Size(0x25, 0x16);
            this.textSIFRAIZVORA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVIZVORA.Location = point;
            this.label1NAZIVIZVORA.Name = "label1NAZIVIZVORA";
            this.label1NAZIVIZVORA.TabIndex = 1;
            this.label1NAZIVIZVORA.Tag = "labelNAZIVIZVORA";
            this.label1NAZIVIZVORA.Text = "NAZIVIZVORA:";
            this.label1NAZIVIZVORA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVIZVORA.AutoSize = true;
            this.label1NAZIVIZVORA.Anchor = AnchorStyles.Left;
            this.label1NAZIVIZVORA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVIZVORA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVIZVORA.BackColor = Color.Transparent;
            this.layoutManagerformIZVORDOKUMENTA.Controls.Add(this.label1NAZIVIZVORA, 0, 1);
            this.layoutManagerformIZVORDOKUMENTA.SetColumnSpan(this.label1NAZIVIZVORA, 1);
            this.layoutManagerformIZVORDOKUMENTA.SetRowSpan(this.label1NAZIVIZVORA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVIZVORA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVIZVORA.MinimumSize = size;
            size = new System.Drawing.Size(0x6c, 0x17);
            this.label1NAZIVIZVORA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVIZVORA.Location = point;
            this.textNAZIVIZVORA.Name = "textNAZIVIZVORA";
            this.textNAZIVIZVORA.Tag = "NAZIVIZVORA";
            this.textNAZIVIZVORA.TabIndex = 0;
            this.textNAZIVIZVORA.Anchor = AnchorStyles.Left;
            this.textNAZIVIZVORA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVIZVORA.ReadOnly = false;
            this.textNAZIVIZVORA.DataBindings.Add(new Binding("Text", this.bindingSourceIZVORDOKUMENTA, "NAZIVIZVORA"));
            this.textNAZIVIZVORA.MaxLength = 20;
            this.layoutManagerformIZVORDOKUMENTA.Controls.Add(this.textNAZIVIZVORA, 1, 1);
            this.layoutManagerformIZVORDOKUMENTA.SetColumnSpan(this.textNAZIVIZVORA, 1);
            this.layoutManagerformIZVORDOKUMENTA.SetRowSpan(this.textNAZIVIZVORA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVIZVORA.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textNAZIVIZVORA.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textNAZIVIZVORA.Size = size;
            this.Controls.Add(this.layoutManagerformIZVORDOKUMENTA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceIZVORDOKUMENTA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "IZVORDOKUMENTAFormUserControl";
            this.Text = "IZVORDOKUMENTA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.IZVORDOKUMENTAFormUserControl_Load);
            this.layoutManagerformIZVORDOKUMENTA.ResumeLayout(false);
            this.layoutManagerformIZVORDOKUMENTA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceIZVORDOKUMENTA).EndInit();
            ((ISupportInitialize) this.textSIFRAIZVORA).EndInit();
            ((ISupportInitialize) this.textNAZIVIZVORA).EndInit();
            this.dsIZVORDOKUMENTADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.IZVORDOKUMENTAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceIZVORDOKUMENTA, this.IZVORDOKUMENTAController.WorkItem, this))
            {
                return false;
            }
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void IZVORDOKUMENTAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.IZVORDOKUMENTADescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void Localize()
        {
            this.label1SIFRAIZVORA.Text = StringResources.IZVORDOKUMENTASIFRAIZVORADescription;
            this.label1NAZIVIZVORA.Text = StringResources.IZVORDOKUMENTANAZIVIZVORADescription;
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
            if (!this.IZVORDOKUMENTAController.WorkItem.Items.Contains("IZVORDOKUMENTA|IZVORDOKUMENTA"))
            {
                this.IZVORDOKUMENTAController.WorkItem.Items.Add(this.bindingSourceIZVORDOKUMENTA, "IZVORDOKUMENTA|IZVORDOKUMENTA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsIZVORDOKUMENTADataSet1.IZVORDOKUMENTA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.IZVORDOKUMENTAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.IZVORDOKUMENTAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.IZVORDOKUMENTAController.Update(this))
            {
                this.IZVORDOKUMENTAController.DataSet = new IZVORDOKUMENTADataSet();
                DataSetUtil.AddEmptyRow(this.IZVORDOKUMENTAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.IZVORDOKUMENTAController.DataSet.IZVORDOKUMENTA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textSIFRAIZVORA.Focus();
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
        public NetAdvantage.Controllers.IZVORDOKUMENTAController IZVORDOKUMENTAController { get; set; }

        protected virtual UltraLabel label1NAZIVIZVORA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVIZVORA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVIZVORA = value;
            }
        }

        protected virtual UltraLabel label1SIFRAIZVORA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAIZVORA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAIZVORA = value;
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

        protected virtual UltraTextEditor textNAZIVIZVORA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVIZVORA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVIZVORA = value;
            }
        }

        protected virtual UltraTextEditor textSIFRAIZVORA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSIFRAIZVORA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSIFRAIZVORA = value;
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

