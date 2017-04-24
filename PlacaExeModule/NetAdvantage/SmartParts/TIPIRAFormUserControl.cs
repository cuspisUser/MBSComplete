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
    public class TIPIRAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDTIPIRA")]
        private UltraLabel _label1IDTIPIRA;
        [AccessedThroughProperty("label1NAZIVTIPIRA")]
        private UltraLabel _label1NAZIVTIPIRA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDTIPIRA")]
        private UltraNumericEditor _textIDTIPIRA;
        [AccessedThroughProperty("textNAZIVTIPIRA")]
        private UltraTextEditor _textNAZIVTIPIRA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceTIPIRA;
        private IContainer components = null;
        private TIPIRADataSet dsTIPIRADataSet1;
        protected TableLayoutPanel layoutManagerformTIPIRA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private TIPIRADataSet.TIPIRARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "TIPIRA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.TIPIRADescription;
        private DeklaritMode m_Mode;

        public TIPIRAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceTIPIRA.DataSource = this.TIPIRAController.DataSet;
            this.dsTIPIRADataSet1 = this.TIPIRAController.DataSet;
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
                    enumerator = this.dsTIPIRADataSet1.TIPIRA.Rows.GetEnumerator();
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
                if (this.TIPIRAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "TIPIRA", this.m_Mode, this.dsTIPIRADataSet1, this.dsTIPIRADataSet1.TIPIRA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsTIPIRADataSet1.TIPIRA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (TIPIRADataSet.TIPIRARow) ((DataRowView) this.bindingSourceTIPIRA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(TIPIRAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceTIPIRA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceTIPIRA).BeginInit();
            this.layoutManagerformTIPIRA = new TableLayoutPanel();
            this.layoutManagerformTIPIRA.SuspendLayout();
            this.layoutManagerformTIPIRA.AutoSize = true;
            this.layoutManagerformTIPIRA.Dock = DockStyle.Fill;
            this.layoutManagerformTIPIRA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformTIPIRA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformTIPIRA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformTIPIRA.Size = size;
            this.layoutManagerformTIPIRA.ColumnCount = 2;
            this.layoutManagerformTIPIRA.RowCount = 3;
            this.layoutManagerformTIPIRA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformTIPIRA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformTIPIRA.RowStyles.Add(new RowStyle());
            this.layoutManagerformTIPIRA.RowStyles.Add(new RowStyle());
            this.layoutManagerformTIPIRA.RowStyles.Add(new RowStyle());
            this.label1IDTIPIRA = new UltraLabel();
            this.textIDTIPIRA = new UltraNumericEditor();
            this.label1NAZIVTIPIRA = new UltraLabel();
            this.textNAZIVTIPIRA = new UltraTextEditor();
            ((ISupportInitialize) this.textIDTIPIRA).BeginInit();
            ((ISupportInitialize) this.textNAZIVTIPIRA).BeginInit();
            this.dsTIPIRADataSet1 = new TIPIRADataSet();
            this.dsTIPIRADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsTIPIRADataSet1.DataSetName = "dsTIPIRA";
            this.dsTIPIRADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceTIPIRA.DataSource = this.dsTIPIRADataSet1;
            this.bindingSourceTIPIRA.DataMember = "TIPIRA";
            ((ISupportInitialize) this.bindingSourceTIPIRA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDTIPIRA.Location = point;
            this.label1IDTIPIRA.Name = "label1IDTIPIRA";
            this.label1IDTIPIRA.TabIndex = 1;
            this.label1IDTIPIRA.Tag = "labelIDTIPIRA";
            this.label1IDTIPIRA.Text = "IDTIPIRA:";
            this.label1IDTIPIRA.StyleSetName = "FieldUltraLabel";
            this.label1IDTIPIRA.AutoSize = true;
            this.label1IDTIPIRA.Anchor = AnchorStyles.Left;
            this.label1IDTIPIRA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDTIPIRA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDTIPIRA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDTIPIRA.ImageSize = size;
            this.label1IDTIPIRA.Appearance.ForeColor = Color.Black;
            this.label1IDTIPIRA.BackColor = Color.Transparent;
            this.layoutManagerformTIPIRA.Controls.Add(this.label1IDTIPIRA, 0, 0);
            this.layoutManagerformTIPIRA.SetColumnSpan(this.label1IDTIPIRA, 1);
            this.layoutManagerformTIPIRA.SetRowSpan(this.label1IDTIPIRA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDTIPIRA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDTIPIRA.MinimumSize = size;
            size = new System.Drawing.Size(0x4c, 0x17);
            this.label1IDTIPIRA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDTIPIRA.Location = point;
            this.textIDTIPIRA.Name = "textIDTIPIRA";
            this.textIDTIPIRA.Tag = "IDTIPIRA";
            this.textIDTIPIRA.TabIndex = 0;
            this.textIDTIPIRA.Anchor = AnchorStyles.Left;
            this.textIDTIPIRA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDTIPIRA.ReadOnly = false;
            this.textIDTIPIRA.PromptChar = ' ';
            this.textIDTIPIRA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDTIPIRA.DataBindings.Add(new Binding("Value", this.bindingSourceTIPIRA, "IDTIPIRA"));
            this.textIDTIPIRA.NumericType = NumericType.Integer;
            this.textIDTIPIRA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformTIPIRA.Controls.Add(this.textIDTIPIRA, 1, 0);
            this.layoutManagerformTIPIRA.SetColumnSpan(this.textIDTIPIRA, 1);
            this.layoutManagerformTIPIRA.SetRowSpan(this.textIDTIPIRA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDTIPIRA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDTIPIRA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDTIPIRA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVTIPIRA.Location = point;
            this.label1NAZIVTIPIRA.Name = "label1NAZIVTIPIRA";
            this.label1NAZIVTIPIRA.TabIndex = 1;
            this.label1NAZIVTIPIRA.Tag = "labelNAZIVTIPIRA";
            this.label1NAZIVTIPIRA.Text = "NAZIVTIPIRA:";
            this.label1NAZIVTIPIRA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVTIPIRA.AutoSize = true;
            this.label1NAZIVTIPIRA.Anchor = AnchorStyles.Left;
            this.label1NAZIVTIPIRA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVTIPIRA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVTIPIRA.BackColor = Color.Transparent;
            this.layoutManagerformTIPIRA.Controls.Add(this.label1NAZIVTIPIRA, 0, 1);
            this.layoutManagerformTIPIRA.SetColumnSpan(this.label1NAZIVTIPIRA, 1);
            this.layoutManagerformTIPIRA.SetRowSpan(this.label1NAZIVTIPIRA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVTIPIRA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVTIPIRA.MinimumSize = size;
            size = new System.Drawing.Size(0x68, 0x17);
            this.label1NAZIVTIPIRA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVTIPIRA.Location = point;
            this.textNAZIVTIPIRA.Name = "textNAZIVTIPIRA";
            this.textNAZIVTIPIRA.Tag = "NAZIVTIPIRA";
            this.textNAZIVTIPIRA.TabIndex = 0;
            this.textNAZIVTIPIRA.Anchor = AnchorStyles.Left;
            this.textNAZIVTIPIRA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVTIPIRA.ReadOnly = false;
            this.textNAZIVTIPIRA.DataBindings.Add(new Binding("Text", this.bindingSourceTIPIRA, "NAZIVTIPIRA"));
            this.textNAZIVTIPIRA.MaxLength = 50;
            this.layoutManagerformTIPIRA.Controls.Add(this.textNAZIVTIPIRA, 1, 1);
            this.layoutManagerformTIPIRA.SetColumnSpan(this.textNAZIVTIPIRA, 1);
            this.layoutManagerformTIPIRA.SetRowSpan(this.textNAZIVTIPIRA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVTIPIRA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVTIPIRA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVTIPIRA.Size = size;
            this.Controls.Add(this.layoutManagerformTIPIRA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceTIPIRA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "TIPIRAFormUserControl";
            this.Text = "TIPIRA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.TIPIRAFormUserControl_Load);
            this.layoutManagerformTIPIRA.ResumeLayout(false);
            this.layoutManagerformTIPIRA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceTIPIRA).EndInit();
            ((ISupportInitialize) this.textIDTIPIRA).EndInit();
            ((ISupportInitialize) this.textNAZIVTIPIRA).EndInit();
            this.dsTIPIRADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.TIPIRAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceTIPIRA, this.TIPIRAController.WorkItem, this))
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
            this.label1IDTIPIRA.Text = StringResources.TIPIRAIDTIPIRADescription;
            this.label1NAZIVTIPIRA.Text = StringResources.TIPIRANAZIVTIPIRADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewIRA")]
        public void NewIRAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.TIPIRAController.NewIRA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.TIPIRAController.WorkItem.Items.Contains("TIPIRA|TIPIRA"))
            {
                this.TIPIRAController.WorkItem.Items.Add(this.bindingSourceTIPIRA, "TIPIRA|TIPIRA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsTIPIRADataSet1.TIPIRA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.TIPIRAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.TIPIRAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.TIPIRAController.Update(this))
            {
                this.TIPIRAController.DataSet = new TIPIRADataSet();
                DataSetUtil.AddEmptyRow(this.TIPIRAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.TIPIRAController.DataSet.TIPIRA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDTIPIRA.Focus();
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

        private void TIPIRAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.TIPIRADescription;
            this.errorProvider1.ContainerControl = this;
        }

        [LocalCommandHandler("ViewIRA")]
        public void ViewIRAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.TIPIRAController.ViewIRA(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDTIPIRA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDTIPIRA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDTIPIRA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVTIPIRA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVTIPIRA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVTIPIRA = value;
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

        protected virtual UltraNumericEditor textIDTIPIRA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDTIPIRA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDTIPIRA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVTIPIRA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVTIPIRA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVTIPIRA = value;
            }
        }

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.TIPIRAController TIPIRAController { get; set; }

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

