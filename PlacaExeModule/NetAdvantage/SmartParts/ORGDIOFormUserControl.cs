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
    public class ORGDIOFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDORGDIO")]
        private UltraLabel _label1IDORGDIO;
        [AccessedThroughProperty("label1ORGANIZACIJSKIDIO")]
        private UltraLabel _label1ORGANIZACIJSKIDIO;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDORGDIO")]
        private UltraNumericEditor _textIDORGDIO;
        [AccessedThroughProperty("textORGANIZACIJSKIDIO")]
        private UltraTextEditor _textORGANIZACIJSKIDIO;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceORGDIO;
        private IContainer components = null;
        private ORGDIODataSet dsORGDIODataSet1;
        protected TableLayoutPanel layoutManagerformORGDIO;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private ORGDIODataSet.ORGDIORow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "ORGDIO";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.ORGDIODescription;
        private DeklaritMode m_Mode;

        public ORGDIOFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceORGDIO.DataSource = this.ORGDIOController.DataSet;
            this.dsORGDIODataSet1 = this.ORGDIOController.DataSet;
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
                    enumerator = this.dsORGDIODataSet1.ORGDIO.Rows.GetEnumerator();
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
                if (this.ORGDIOController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "ORGDIO", this.m_Mode, this.dsORGDIODataSet1, this.dsORGDIODataSet1.ORGDIO.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsORGDIODataSet1.ORGDIO[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (ORGDIODataSet.ORGDIORow) ((DataRowView) this.bindingSourceORGDIO.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(ORGDIOFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceORGDIO = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceORGDIO).BeginInit();
            this.layoutManagerformORGDIO = new TableLayoutPanel();
            this.layoutManagerformORGDIO.SuspendLayout();
            this.layoutManagerformORGDIO.AutoSize = true;
            this.layoutManagerformORGDIO.Dock = DockStyle.Fill;
            this.layoutManagerformORGDIO.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformORGDIO.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformORGDIO.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformORGDIO.Size = size;
            this.layoutManagerformORGDIO.ColumnCount = 2;
            this.layoutManagerformORGDIO.RowCount = 3;
            this.layoutManagerformORGDIO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformORGDIO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformORGDIO.RowStyles.Add(new RowStyle());
            this.layoutManagerformORGDIO.RowStyles.Add(new RowStyle());
            this.layoutManagerformORGDIO.RowStyles.Add(new RowStyle());
            this.label1IDORGDIO = new UltraLabel();
            this.textIDORGDIO = new UltraNumericEditor();
            this.label1ORGANIZACIJSKIDIO = new UltraLabel();
            this.textORGANIZACIJSKIDIO = new UltraTextEditor();
            ((ISupportInitialize) this.textIDORGDIO).BeginInit();
            ((ISupportInitialize) this.textORGANIZACIJSKIDIO).BeginInit();
            this.dsORGDIODataSet1 = new ORGDIODataSet();
            this.dsORGDIODataSet1.BeginInit();
            this.SuspendLayout();
            this.dsORGDIODataSet1.DataSetName = "dsORGDIO";
            this.dsORGDIODataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceORGDIO.DataSource = this.dsORGDIODataSet1;
            this.bindingSourceORGDIO.DataMember = "ORGDIO";
            ((ISupportInitialize) this.bindingSourceORGDIO).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDORGDIO.Location = point;
            this.label1IDORGDIO.Name = "label1IDORGDIO";
            this.label1IDORGDIO.TabIndex = 1;
            this.label1IDORGDIO.Tag = "labelIDORGDIO";
            this.label1IDORGDIO.Text = "Šifra organizacijske jedinice:";
            this.label1IDORGDIO.StyleSetName = "FieldUltraLabel";
            this.label1IDORGDIO.AutoSize = true;
            this.label1IDORGDIO.Anchor = AnchorStyles.Left;
            this.label1IDORGDIO.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDORGDIO.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDORGDIO.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDORGDIO.ImageSize = size;
            this.label1IDORGDIO.Appearance.ForeColor = Color.Black;
            this.label1IDORGDIO.BackColor = Color.Transparent;
            this.layoutManagerformORGDIO.Controls.Add(this.label1IDORGDIO, 0, 0);
            this.layoutManagerformORGDIO.SetColumnSpan(this.label1IDORGDIO, 1);
            this.layoutManagerformORGDIO.SetRowSpan(this.label1IDORGDIO, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDORGDIO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDORGDIO.MinimumSize = size;
            size = new System.Drawing.Size(0xbf, 0x17);
            this.label1IDORGDIO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDORGDIO.Location = point;
            this.textIDORGDIO.Name = "textIDORGDIO";
            this.textIDORGDIO.Tag = "IDORGDIO";
            this.textIDORGDIO.TabIndex = 0;
            this.textIDORGDIO.Anchor = AnchorStyles.Left;
            this.textIDORGDIO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDORGDIO.ReadOnly = false;
            this.textIDORGDIO.PromptChar = ' ';
            this.textIDORGDIO.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDORGDIO.DataBindings.Add(new Binding("Value", this.bindingSourceORGDIO, "IDORGDIO"));
            this.textIDORGDIO.NumericType = NumericType.Integer;
            this.textIDORGDIO.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformORGDIO.Controls.Add(this.textIDORGDIO, 1, 0);
            this.layoutManagerformORGDIO.SetColumnSpan(this.textIDORGDIO, 1);
            this.layoutManagerformORGDIO.SetRowSpan(this.textIDORGDIO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDORGDIO.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDORGDIO.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDORGDIO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ORGANIZACIJSKIDIO.Location = point;
            this.label1ORGANIZACIJSKIDIO.Name = "label1ORGANIZACIJSKIDIO";
            this.label1ORGANIZACIJSKIDIO.TabIndex = 1;
            this.label1ORGANIZACIJSKIDIO.Tag = "labelORGANIZACIJSKIDIO";
            this.label1ORGANIZACIJSKIDIO.Text = "Naziv organizacijske jedinice:";
            this.label1ORGANIZACIJSKIDIO.StyleSetName = "FieldUltraLabel";
            this.label1ORGANIZACIJSKIDIO.AutoSize = true;
            this.label1ORGANIZACIJSKIDIO.Anchor = AnchorStyles.Left;
            this.label1ORGANIZACIJSKIDIO.Appearance.TextVAlign = VAlign.Middle;
            this.label1ORGANIZACIJSKIDIO.Appearance.ForeColor = Color.Black;
            this.label1ORGANIZACIJSKIDIO.BackColor = Color.Transparent;
            this.layoutManagerformORGDIO.Controls.Add(this.label1ORGANIZACIJSKIDIO, 0, 1);
            this.layoutManagerformORGDIO.SetColumnSpan(this.label1ORGANIZACIJSKIDIO, 1);
            this.layoutManagerformORGDIO.SetRowSpan(this.label1ORGANIZACIJSKIDIO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ORGANIZACIJSKIDIO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ORGANIZACIJSKIDIO.MinimumSize = size;
            size = new System.Drawing.Size(0xc7, 0x17);
            this.label1ORGANIZACIJSKIDIO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textORGANIZACIJSKIDIO.Location = point;
            this.textORGANIZACIJSKIDIO.Name = "textORGANIZACIJSKIDIO";
            this.textORGANIZACIJSKIDIO.Tag = "ORGANIZACIJSKIDIO";
            this.textORGANIZACIJSKIDIO.TabIndex = 0;
            this.textORGANIZACIJSKIDIO.Anchor = AnchorStyles.Left;
            this.textORGANIZACIJSKIDIO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textORGANIZACIJSKIDIO.ReadOnly = false;
            this.textORGANIZACIJSKIDIO.DataBindings.Add(new Binding("Text", this.bindingSourceORGDIO, "ORGANIZACIJSKIDIO"));
            this.textORGANIZACIJSKIDIO.MaxLength = 50;
            this.layoutManagerformORGDIO.Controls.Add(this.textORGANIZACIJSKIDIO, 1, 1);
            this.layoutManagerformORGDIO.SetColumnSpan(this.textORGANIZACIJSKIDIO, 1);
            this.layoutManagerformORGDIO.SetRowSpan(this.textORGANIZACIJSKIDIO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textORGANIZACIJSKIDIO.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textORGANIZACIJSKIDIO.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textORGANIZACIJSKIDIO.Size = size;
            this.Controls.Add(this.layoutManagerformORGDIO);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceORGDIO;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "ORGDIOFormUserControl";
            this.Text = "Organizacijske jedinice";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.ORGDIOFormUserControl_Load);
            this.layoutManagerformORGDIO.ResumeLayout(false);
            this.layoutManagerformORGDIO.PerformLayout();
            ((ISupportInitialize) this.bindingSourceORGDIO).EndInit();
            ((ISupportInitialize) this.textIDORGDIO).EndInit();
            ((ISupportInitialize) this.textORGANIZACIJSKIDIO).EndInit();
            this.dsORGDIODataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.ORGDIOController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceORGDIO, this.ORGDIOController.WorkItem, this))
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
            this.label1IDORGDIO.Text = StringResources.ORGDIOIDORGDIODescription;
            this.label1ORGANIZACIJSKIDIO.Text = StringResources.ORGDIOORGANIZACIJSKIDIODescription;
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
                this.ORGDIOController.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void ORGDIOFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.ORGDIODescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.ORGDIOController.WorkItem.Items.Contains("ORGDIO|ORGDIO"))
            {
                this.ORGDIOController.WorkItem.Items.Add(this.bindingSourceORGDIO, "ORGDIO|ORGDIO");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsORGDIODataSet1.ORGDIO.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.ORGDIOController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.ORGDIOController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.ORGDIOController.Update(this))
            {
                this.ORGDIOController.DataSet = new ORGDIODataSet();
                DataSetUtil.AddEmptyRow(this.ORGDIOController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.ORGDIOController.DataSet.ORGDIO[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDORGDIO.Focus();
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
                this.ORGDIOController.ViewRADNIK(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDORGDIO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDORGDIO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDORGDIO = value;
            }
        }

        protected virtual UltraLabel label1ORGANIZACIJSKIDIO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ORGANIZACIJSKIDIO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ORGANIZACIJSKIDIO = value;
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
        public NetAdvantage.Controllers.ORGDIOController ORGDIOController { get; set; }

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

        protected virtual UltraNumericEditor textIDORGDIO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDORGDIO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDORGDIO = value;
            }
        }

        protected virtual UltraTextEditor textORGANIZACIJSKIDIO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textORGANIZACIJSKIDIO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textORGANIZACIJSKIDIO = value;
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

