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
    public class TIPURAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDTIPURA")]
        private UltraLabel _label1IDTIPURA;
        [AccessedThroughProperty("label1NAZIVTIPURA")]
        private UltraLabel _label1NAZIVTIPURA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDTIPURA")]
        private UltraNumericEditor _textIDTIPURA;
        [AccessedThroughProperty("textNAZIVTIPURA")]
        private UltraTextEditor _textNAZIVTIPURA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceTIPURA;
        private IContainer components = null;
        private TIPURADataSet dsTIPURADataSet1;
        protected TableLayoutPanel layoutManagerformTIPURA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private TIPURADataSet.TIPURARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "TIPURA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.TIPURADescription;
        private DeklaritMode m_Mode;

        public TIPURAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceTIPURA.DataSource = this.TIPURAController.DataSet;
            this.dsTIPURADataSet1 = this.TIPURAController.DataSet;
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
                    enumerator = this.dsTIPURADataSet1.TIPURA.Rows.GetEnumerator();
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
                if (this.TIPURAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "TIPURA", this.m_Mode, this.dsTIPURADataSet1, this.dsTIPURADataSet1.TIPURA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsTIPURADataSet1.TIPURA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (TIPURADataSet.TIPURARow) ((DataRowView) this.bindingSourceTIPURA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(TIPURAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceTIPURA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceTIPURA).BeginInit();
            this.layoutManagerformTIPURA = new TableLayoutPanel();
            this.layoutManagerformTIPURA.SuspendLayout();
            this.layoutManagerformTIPURA.AutoSize = true;
            this.layoutManagerformTIPURA.Dock = DockStyle.Fill;
            this.layoutManagerformTIPURA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformTIPURA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformTIPURA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformTIPURA.Size = size;
            this.layoutManagerformTIPURA.ColumnCount = 2;
            this.layoutManagerformTIPURA.RowCount = 3;
            this.layoutManagerformTIPURA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformTIPURA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformTIPURA.RowStyles.Add(new RowStyle());
            this.layoutManagerformTIPURA.RowStyles.Add(new RowStyle());
            this.layoutManagerformTIPURA.RowStyles.Add(new RowStyle());
            this.label1IDTIPURA = new UltraLabel();
            this.textIDTIPURA = new UltraNumericEditor();
            this.label1NAZIVTIPURA = new UltraLabel();
            this.textNAZIVTIPURA = new UltraTextEditor();
            ((ISupportInitialize) this.textIDTIPURA).BeginInit();
            ((ISupportInitialize) this.textNAZIVTIPURA).BeginInit();
            this.dsTIPURADataSet1 = new TIPURADataSet();
            this.dsTIPURADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsTIPURADataSet1.DataSetName = "dsTIPURA";
            this.dsTIPURADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceTIPURA.DataSource = this.dsTIPURADataSet1;
            this.bindingSourceTIPURA.DataMember = "TIPURA";
            ((ISupportInitialize) this.bindingSourceTIPURA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDTIPURA.Location = point;
            this.label1IDTIPURA.Name = "label1IDTIPURA";
            this.label1IDTIPURA.TabIndex = 1;
            this.label1IDTIPURA.Tag = "labelIDTIPURA";
            this.label1IDTIPURA.Text = "Šifra:";
            this.label1IDTIPURA.StyleSetName = "FieldUltraLabel";
            this.label1IDTIPURA.AutoSize = true;
            this.label1IDTIPURA.Anchor = AnchorStyles.Left;
            this.label1IDTIPURA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDTIPURA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDTIPURA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDTIPURA.ImageSize = size;
            this.label1IDTIPURA.Appearance.ForeColor = Color.Black;
            this.label1IDTIPURA.BackColor = Color.Transparent;
            this.layoutManagerformTIPURA.Controls.Add(this.label1IDTIPURA, 0, 0);
            this.layoutManagerformTIPURA.SetColumnSpan(this.label1IDTIPURA, 1);
            this.layoutManagerformTIPURA.SetRowSpan(this.label1IDTIPURA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDTIPURA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDTIPURA.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDTIPURA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDTIPURA.Location = point;
            this.textIDTIPURA.Name = "textIDTIPURA";
            this.textIDTIPURA.Tag = "IDTIPURA";
            this.textIDTIPURA.TabIndex = 0;
            this.textIDTIPURA.Anchor = AnchorStyles.Left;
            this.textIDTIPURA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDTIPURA.ReadOnly = false;
            this.textIDTIPURA.PromptChar = ' ';
            this.textIDTIPURA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDTIPURA.DataBindings.Add(new Binding("Value", this.bindingSourceTIPURA, "IDTIPURA"));
            this.textIDTIPURA.NumericType = NumericType.Integer;
            this.textIDTIPURA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformTIPURA.Controls.Add(this.textIDTIPURA, 1, 0);
            this.layoutManagerformTIPURA.SetColumnSpan(this.textIDTIPURA, 1);
            this.layoutManagerformTIPURA.SetRowSpan(this.textIDTIPURA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDTIPURA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDTIPURA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDTIPURA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVTIPURA.Location = point;
            this.label1NAZIVTIPURA.Name = "label1NAZIVTIPURA";
            this.label1NAZIVTIPURA.TabIndex = 1;
            this.label1NAZIVTIPURA.Tag = "labelNAZIVTIPURA";
            this.label1NAZIVTIPURA.Text = "Naziv URE:";
            this.label1NAZIVTIPURA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVTIPURA.AutoSize = true;
            this.label1NAZIVTIPURA.Anchor = AnchorStyles.Left;
            this.label1NAZIVTIPURA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVTIPURA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVTIPURA.BackColor = Color.Transparent;
            this.layoutManagerformTIPURA.Controls.Add(this.label1NAZIVTIPURA, 0, 1);
            this.layoutManagerformTIPURA.SetColumnSpan(this.label1NAZIVTIPURA, 1);
            this.layoutManagerformTIPURA.SetRowSpan(this.label1NAZIVTIPURA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVTIPURA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVTIPURA.MinimumSize = size;
            size = new System.Drawing.Size(0x53, 0x17);
            this.label1NAZIVTIPURA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVTIPURA.Location = point;
            this.textNAZIVTIPURA.Name = "textNAZIVTIPURA";
            this.textNAZIVTIPURA.Tag = "NAZIVTIPURA";
            this.textNAZIVTIPURA.TabIndex = 0;
            this.textNAZIVTIPURA.Anchor = AnchorStyles.Left;
            this.textNAZIVTIPURA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVTIPURA.ReadOnly = false;
            this.textNAZIVTIPURA.DataBindings.Add(new Binding("Text", this.bindingSourceTIPURA, "NAZIVTIPURA"));
            this.textNAZIVTIPURA.MaxLength = 50;
            this.layoutManagerformTIPURA.Controls.Add(this.textNAZIVTIPURA, 1, 1);
            this.layoutManagerformTIPURA.SetColumnSpan(this.textNAZIVTIPURA, 1);
            this.layoutManagerformTIPURA.SetRowSpan(this.textNAZIVTIPURA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVTIPURA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVTIPURA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVTIPURA.Size = size;
            this.Controls.Add(this.layoutManagerformTIPURA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceTIPURA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "TIPURAFormUserControl";
            this.Text = "TIPURA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.TIPURAFormUserControl_Load);
            this.layoutManagerformTIPURA.ResumeLayout(false);
            this.layoutManagerformTIPURA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceTIPURA).EndInit();
            ((ISupportInitialize) this.textIDTIPURA).EndInit();
            ((ISupportInitialize) this.textNAZIVTIPURA).EndInit();
            this.dsTIPURADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.TIPURAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceTIPURA, this.TIPURAController.WorkItem, this))
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
            this.label1IDTIPURA.Text = StringResources.TIPURAIDTIPURADescription;
            this.label1NAZIVTIPURA.Text = StringResources.TIPURANAZIVTIPURADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewURA")]
        public void NewURAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.TIPURAController.NewURA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.TIPURAController.WorkItem.Items.Contains("TIPURA|TIPURA"))
            {
                this.TIPURAController.WorkItem.Items.Add(this.bindingSourceTIPURA, "TIPURA|TIPURA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsTIPURADataSet1.TIPURA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.TIPURAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.TIPURAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.TIPURAController.Update(this))
            {
                this.TIPURAController.DataSet = new TIPURADataSet();
                DataSetUtil.AddEmptyRow(this.TIPURAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.TIPURAController.DataSet.TIPURA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDTIPURA.Focus();
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

        private void TIPURAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.TIPURADescription;
            this.errorProvider1.ContainerControl = this;
        }

        [LocalCommandHandler("ViewURA")]
        public void ViewURAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.TIPURAController.ViewURA(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDTIPURA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDTIPURA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDTIPURA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVTIPURA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVTIPURA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVTIPURA = value;
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

        protected virtual UltraNumericEditor textIDTIPURA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDTIPURA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDTIPURA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVTIPURA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVTIPURA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVTIPURA = value;
            }
        }

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.TIPURAController TIPURAController { get; set; }

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

