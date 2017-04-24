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
    public class UGOVORORADUFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDUGOVORORADU")]
        private UltraLabel _label1IDUGOVORORADU;
        [AccessedThroughProperty("label1NAZIVUGOVORORADU")]
        private UltraLabel _label1NAZIVUGOVORORADU;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDUGOVORORADU")]
        private UltraNumericEditor _textIDUGOVORORADU;
        [AccessedThroughProperty("textNAZIVUGOVORORADU")]
        private UltraTextEditor _textNAZIVUGOVORORADU;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceUGOVORORADU;
        private IContainer components = null;
        private UGOVORORADUDataSet dsUGOVORORADUDataSet1;
        protected TableLayoutPanel layoutManagerformUGOVORORADU;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private UGOVORORADUDataSet.UGOVORORADURow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "UGOVORORADU";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.UGOVORORADUDescription;
        private DeklaritMode m_Mode;

        public UGOVORORADUFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceUGOVORORADU.DataSource = this.UGOVORORADUController.DataSet;
            this.dsUGOVORORADUDataSet1 = this.UGOVORORADUController.DataSet;
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
                    enumerator = this.dsUGOVORORADUDataSet1.UGOVORORADU.Rows.GetEnumerator();
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
                if (this.UGOVORORADUController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "UGOVORORADU", this.m_Mode, this.dsUGOVORORADUDataSet1, this.dsUGOVORORADUDataSet1.UGOVORORADU.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsUGOVORORADUDataSet1.UGOVORORADU[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (UGOVORORADUDataSet.UGOVORORADURow) ((DataRowView) this.bindingSourceUGOVORORADU.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(UGOVORORADUFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceUGOVORORADU = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceUGOVORORADU).BeginInit();
            this.layoutManagerformUGOVORORADU = new TableLayoutPanel();
            this.layoutManagerformUGOVORORADU.SuspendLayout();
            this.layoutManagerformUGOVORORADU.AutoSize = true;
            this.layoutManagerformUGOVORORADU.Dock = DockStyle.Fill;
            this.layoutManagerformUGOVORORADU.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformUGOVORORADU.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformUGOVORORADU.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformUGOVORORADU.Size = size;
            this.layoutManagerformUGOVORORADU.ColumnCount = 2;
            this.layoutManagerformUGOVORORADU.RowCount = 3;
            this.layoutManagerformUGOVORORADU.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformUGOVORORADU.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformUGOVORORADU.RowStyles.Add(new RowStyle());
            this.layoutManagerformUGOVORORADU.RowStyles.Add(new RowStyle());
            this.layoutManagerformUGOVORORADU.RowStyles.Add(new RowStyle());
            this.label1IDUGOVORORADU = new UltraLabel();
            this.textIDUGOVORORADU = new UltraNumericEditor();
            this.label1NAZIVUGOVORORADU = new UltraLabel();
            this.textNAZIVUGOVORORADU = new UltraTextEditor();
            ((ISupportInitialize) this.textIDUGOVORORADU).BeginInit();
            ((ISupportInitialize) this.textNAZIVUGOVORORADU).BeginInit();
            this.dsUGOVORORADUDataSet1 = new UGOVORORADUDataSet();
            this.dsUGOVORORADUDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsUGOVORORADUDataSet1.DataSetName = "dsUGOVORORADU";
            this.dsUGOVORORADUDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceUGOVORORADU.DataSource = this.dsUGOVORORADUDataSet1;
            this.bindingSourceUGOVORORADU.DataMember = "UGOVORORADU";
            ((ISupportInitialize) this.bindingSourceUGOVORORADU).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDUGOVORORADU.Location = point;
            this.label1IDUGOVORORADU.Name = "label1IDUGOVORORADU";
            this.label1IDUGOVORORADU.TabIndex = 1;
            this.label1IDUGOVORORADU.Tag = "labelIDUGOVORORADU";
            this.label1IDUGOVORORADU.Text = "Šifra:";
            this.label1IDUGOVORORADU.StyleSetName = "FieldUltraLabel";
            this.label1IDUGOVORORADU.AutoSize = true;
            this.label1IDUGOVORORADU.Anchor = AnchorStyles.Left;
            this.label1IDUGOVORORADU.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDUGOVORORADU.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDUGOVORORADU.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDUGOVORORADU.ImageSize = size;
            this.label1IDUGOVORORADU.Appearance.ForeColor = Color.Black;
            this.label1IDUGOVORORADU.BackColor = Color.Transparent;
            this.layoutManagerformUGOVORORADU.Controls.Add(this.label1IDUGOVORORADU, 0, 0);
            this.layoutManagerformUGOVORORADU.SetColumnSpan(this.label1IDUGOVORORADU, 1);
            this.layoutManagerformUGOVORORADU.SetRowSpan(this.label1IDUGOVORORADU, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDUGOVORORADU.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDUGOVORORADU.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDUGOVORORADU.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDUGOVORORADU.Location = point;
            this.textIDUGOVORORADU.Name = "textIDUGOVORORADU";
            this.textIDUGOVORORADU.Tag = "IDUGOVORORADU";
            this.textIDUGOVORORADU.TabIndex = 0;
            this.textIDUGOVORORADU.Anchor = AnchorStyles.Left;
            this.textIDUGOVORORADU.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDUGOVORORADU.ReadOnly = false;
            this.textIDUGOVORORADU.PromptChar = ' ';
            this.textIDUGOVORORADU.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDUGOVORORADU.DataBindings.Add(new Binding("Value", this.bindingSourceUGOVORORADU, "IDUGOVORORADU"));
            this.textIDUGOVORORADU.NumericType = NumericType.Integer;
            this.textIDUGOVORORADU.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformUGOVORORADU.Controls.Add(this.textIDUGOVORORADU, 1, 0);
            this.layoutManagerformUGOVORORADU.SetColumnSpan(this.textIDUGOVORORADU, 1);
            this.layoutManagerformUGOVORORADU.SetRowSpan(this.textIDUGOVORORADU, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDUGOVORORADU.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDUGOVORORADU.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDUGOVORORADU.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVUGOVORORADU.Location = point;
            this.label1NAZIVUGOVORORADU.Name = "label1NAZIVUGOVORORADU";
            this.label1NAZIVUGOVORORADU.TabIndex = 1;
            this.label1NAZIVUGOVORORADU.Tag = "labelNAZIVUGOVORORADU";
            this.label1NAZIVUGOVORORADU.Text = "Vrsta ugovora:";
            this.label1NAZIVUGOVORORADU.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVUGOVORORADU.AutoSize = true;
            this.label1NAZIVUGOVORORADU.Anchor = AnchorStyles.Left;
            this.label1NAZIVUGOVORORADU.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVUGOVORORADU.Appearance.ForeColor = Color.Black;
            this.label1NAZIVUGOVORORADU.BackColor = Color.Transparent;
            this.layoutManagerformUGOVORORADU.Controls.Add(this.label1NAZIVUGOVORORADU, 0, 1);
            this.layoutManagerformUGOVORORADU.SetColumnSpan(this.label1NAZIVUGOVORORADU, 1);
            this.layoutManagerformUGOVORORADU.SetRowSpan(this.label1NAZIVUGOVORORADU, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVUGOVORORADU.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVUGOVORORADU.MinimumSize = size;
            size = new System.Drawing.Size(0x6a, 0x17);
            this.label1NAZIVUGOVORORADU.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVUGOVORORADU.Location = point;
            this.textNAZIVUGOVORORADU.Name = "textNAZIVUGOVORORADU";
            this.textNAZIVUGOVORORADU.Tag = "NAZIVUGOVORORADU";
            this.textNAZIVUGOVORORADU.TabIndex = 0;
            this.textNAZIVUGOVORORADU.Anchor = AnchorStyles.Left;
            this.textNAZIVUGOVORORADU.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVUGOVORORADU.ReadOnly = false;
            this.textNAZIVUGOVORORADU.DataBindings.Add(new Binding("Text", this.bindingSourceUGOVORORADU, "NAZIVUGOVORORADU"));
            this.textNAZIVUGOVORORADU.MaxLength = 20;
            this.layoutManagerformUGOVORORADU.Controls.Add(this.textNAZIVUGOVORORADU, 1, 1);
            this.layoutManagerformUGOVORORADU.SetColumnSpan(this.textNAZIVUGOVORORADU, 1);
            this.layoutManagerformUGOVORORADU.SetRowSpan(this.textNAZIVUGOVORORADU, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVUGOVORORADU.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textNAZIVUGOVORORADU.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textNAZIVUGOVORORADU.Size = size;
            this.Controls.Add(this.layoutManagerformUGOVORORADU);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceUGOVORORADU;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "UGOVORORADUFormUserControl";
            this.Text = "Vrste ugovora o radu";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.UGOVORORADUFormUserControl_Load);
            this.layoutManagerformUGOVORORADU.ResumeLayout(false);
            this.layoutManagerformUGOVORORADU.PerformLayout();
            ((ISupportInitialize) this.bindingSourceUGOVORORADU).EndInit();
            ((ISupportInitialize) this.textIDUGOVORORADU).EndInit();
            ((ISupportInitialize) this.textNAZIVUGOVORORADU).EndInit();
            this.dsUGOVORORADUDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.UGOVORORADUController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceUGOVORORADU, this.UGOVORORADUController.WorkItem, this))
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
            this.label1IDUGOVORORADU.Text = StringResources.UGOVORORADUIDUGOVORORADUDescription;
            this.label1NAZIVUGOVORORADU.Text = StringResources.UGOVORORADUNAZIVUGOVORORADUDescription;
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
                this.UGOVORORADUController.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.UGOVORORADUController.WorkItem.Items.Contains("UGOVORORADU|UGOVORORADU"))
            {
                this.UGOVORORADUController.WorkItem.Items.Add(this.bindingSourceUGOVORORADU, "UGOVORORADU|UGOVORORADU");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsUGOVORORADUDataSet1.UGOVORORADU.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.UGOVORORADUController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.UGOVORORADUController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.UGOVORORADUController.Update(this))
            {
                this.UGOVORORADUController.DataSet = new UGOVORORADUDataSet();
                DataSetUtil.AddEmptyRow(this.UGOVORORADUController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.UGOVORORADUController.DataSet.UGOVORORADU[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDUGOVORORADU.Focus();
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

        private void UGOVORORADUFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.UGOVORORADUDescription;
            this.errorProvider1.ContainerControl = this;
        }

        [LocalCommandHandler("ViewRADNIK")]
        public void ViewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.UGOVORORADUController.ViewRADNIK(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDUGOVORORADU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDUGOVORORADU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDUGOVORORADU = value;
            }
        }

        protected virtual UltraLabel label1NAZIVUGOVORORADU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVUGOVORORADU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVUGOVORORADU = value;
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

        protected virtual UltraNumericEditor textIDUGOVORORADU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDUGOVORORADU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDUGOVORORADU = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVUGOVORORADU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVUGOVORORADU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVUGOVORORADU = value;
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.UGOVORORADUController UGOVORORADUController { get; set; }
    }
}

