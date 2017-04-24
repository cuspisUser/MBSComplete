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
    public class TITULAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDTITULA")]
        private UltraLabel _label1IDTITULA;
        [AccessedThroughProperty("label1NAZIVTITULA")]
        private UltraLabel _label1NAZIVTITULA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDTITULA")]
        private UltraNumericEditor _textIDTITULA;
        [AccessedThroughProperty("textNAZIVTITULA")]
        private UltraTextEditor _textNAZIVTITULA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceTITULA;
        private IContainer components = null;
        private TITULADataSet dsTITULADataSet1;
        protected TableLayoutPanel layoutManagerformTITULA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private TITULADataSet.TITULARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "TITULA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.TITULADescription;
        private DeklaritMode m_Mode;

        public TITULAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceTITULA.DataSource = this.TITULAController.DataSet;
            this.dsTITULADataSet1 = this.TITULAController.DataSet;
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
                    enumerator = this.dsTITULADataSet1.TITULA.Rows.GetEnumerator();
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
                if (this.TITULAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "TITULA", this.m_Mode, this.dsTITULADataSet1, this.dsTITULADataSet1.TITULA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsTITULADataSet1.TITULA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (TITULADataSet.TITULARow) ((DataRowView) this.bindingSourceTITULA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(TITULAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceTITULA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceTITULA).BeginInit();
            this.layoutManagerformTITULA = new TableLayoutPanel();
            this.layoutManagerformTITULA.SuspendLayout();
            this.layoutManagerformTITULA.AutoSize = true;
            this.layoutManagerformTITULA.Dock = DockStyle.Fill;
            this.layoutManagerformTITULA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformTITULA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformTITULA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformTITULA.Size = size;
            this.layoutManagerformTITULA.ColumnCount = 2;
            this.layoutManagerformTITULA.RowCount = 3;
            this.layoutManagerformTITULA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformTITULA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformTITULA.RowStyles.Add(new RowStyle());
            this.layoutManagerformTITULA.RowStyles.Add(new RowStyle());
            this.layoutManagerformTITULA.RowStyles.Add(new RowStyle());
            this.label1IDTITULA = new UltraLabel();
            this.textIDTITULA = new UltraNumericEditor();
            this.label1NAZIVTITULA = new UltraLabel();
            this.textNAZIVTITULA = new UltraTextEditor();
            ((ISupportInitialize) this.textIDTITULA).BeginInit();
            ((ISupportInitialize) this.textNAZIVTITULA).BeginInit();
            this.dsTITULADataSet1 = new TITULADataSet();
            this.dsTITULADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsTITULADataSet1.DataSetName = "dsTITULA";
            this.dsTITULADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceTITULA.DataSource = this.dsTITULADataSet1;
            this.bindingSourceTITULA.DataMember = "TITULA";
            ((ISupportInitialize) this.bindingSourceTITULA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDTITULA.Location = point;
            this.label1IDTITULA.Name = "label1IDTITULA";
            this.label1IDTITULA.TabIndex = 1;
            this.label1IDTITULA.Tag = "labelIDTITULA";
            this.label1IDTITULA.Text = "Šifra titule:";
            this.label1IDTITULA.StyleSetName = "FieldUltraLabel";
            this.label1IDTITULA.AutoSize = true;
            this.label1IDTITULA.Anchor = AnchorStyles.Left;
            this.label1IDTITULA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDTITULA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDTITULA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDTITULA.ImageSize = size;
            this.label1IDTITULA.Appearance.ForeColor = Color.Black;
            this.label1IDTITULA.BackColor = Color.Transparent;
            this.layoutManagerformTITULA.Controls.Add(this.label1IDTITULA, 0, 0);
            this.layoutManagerformTITULA.SetColumnSpan(this.label1IDTITULA, 1);
            this.layoutManagerformTITULA.SetRowSpan(this.label1IDTITULA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDTITULA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDTITULA.MinimumSize = size;
            size = new System.Drawing.Size(0x52, 0x17);
            this.label1IDTITULA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDTITULA.Location = point;
            this.textIDTITULA.Name = "textIDTITULA";
            this.textIDTITULA.Tag = "IDTITULA";
            this.textIDTITULA.TabIndex = 0;
            this.textIDTITULA.Anchor = AnchorStyles.Left;
            this.textIDTITULA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDTITULA.ReadOnly = false;
            this.textIDTITULA.PromptChar = ' ';
            this.textIDTITULA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDTITULA.DataBindings.Add(new Binding("Value", this.bindingSourceTITULA, "IDTITULA"));
            this.textIDTITULA.NumericType = NumericType.Integer;
            this.textIDTITULA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformTITULA.Controls.Add(this.textIDTITULA, 1, 0);
            this.layoutManagerformTITULA.SetColumnSpan(this.textIDTITULA, 1);
            this.layoutManagerformTITULA.SetRowSpan(this.textIDTITULA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDTITULA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDTITULA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDTITULA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVTITULA.Location = point;
            this.label1NAZIVTITULA.Name = "label1NAZIVTITULA";
            this.label1NAZIVTITULA.TabIndex = 1;
            this.label1NAZIVTITULA.Tag = "labelNAZIVTITULA";
            this.label1NAZIVTITULA.Text = "Naziv titule:";
            this.label1NAZIVTITULA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVTITULA.AutoSize = true;
            this.label1NAZIVTITULA.Anchor = AnchorStyles.Left;
            this.label1NAZIVTITULA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVTITULA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVTITULA.BackColor = Color.Transparent;
            this.layoutManagerformTITULA.Controls.Add(this.label1NAZIVTITULA, 0, 1);
            this.layoutManagerformTITULA.SetColumnSpan(this.label1NAZIVTITULA, 1);
            this.layoutManagerformTITULA.SetRowSpan(this.label1NAZIVTITULA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVTITULA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVTITULA.MinimumSize = size;
            size = new System.Drawing.Size(90, 0x17);
            this.label1NAZIVTITULA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVTITULA.Location = point;
            this.textNAZIVTITULA.Name = "textNAZIVTITULA";
            this.textNAZIVTITULA.Tag = "NAZIVTITULA";
            this.textNAZIVTITULA.TabIndex = 0;
            this.textNAZIVTITULA.Anchor = AnchorStyles.Left;
            this.textNAZIVTITULA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVTITULA.ReadOnly = false;
            this.textNAZIVTITULA.DataBindings.Add(new Binding("Text", this.bindingSourceTITULA, "NAZIVTITULA"));
            this.textNAZIVTITULA.MaxLength = 50;
            this.layoutManagerformTITULA.Controls.Add(this.textNAZIVTITULA, 1, 1);
            this.layoutManagerformTITULA.SetColumnSpan(this.textNAZIVTITULA, 1);
            this.layoutManagerformTITULA.SetRowSpan(this.textNAZIVTITULA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVTITULA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVTITULA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVTITULA.Size = size;
            this.Controls.Add(this.layoutManagerformTITULA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceTITULA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "TITULAFormUserControl";
            this.Text = "Titule";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.TITULAFormUserControl_Load);
            this.layoutManagerformTITULA.ResumeLayout(false);
            this.layoutManagerformTITULA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceTITULA).EndInit();
            ((ISupportInitialize) this.textIDTITULA).EndInit();
            ((ISupportInitialize) this.textNAZIVTITULA).EndInit();
            this.dsTITULADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.TITULAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceTITULA, this.TITULAController.WorkItem, this))
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
            this.label1IDTITULA.Text = StringResources.TITULAIDTITULADescription;
            this.label1NAZIVTITULA.Text = StringResources.TITULANAZIVTITULADescription;
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
                this.TITULAController.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.TITULAController.WorkItem.Items.Contains("TITULA|TITULA"))
            {
                this.TITULAController.WorkItem.Items.Add(this.bindingSourceTITULA, "TITULA|TITULA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsTITULADataSet1.TITULA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.TITULAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.TITULAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.TITULAController.Update(this))
            {
                this.TITULAController.DataSet = new TITULADataSet();
                DataSetUtil.AddEmptyRow(this.TITULAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.TITULAController.DataSet.TITULA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDTITULA.Focus();
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

        private void TITULAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.TITULADescription;
            this.errorProvider1.ContainerControl = this;
        }

        [LocalCommandHandler("ViewRADNIK")]
        public void ViewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.TITULAController.ViewRADNIK(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDTITULA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDTITULA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDTITULA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVTITULA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVTITULA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVTITULA = value;
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

        protected virtual UltraNumericEditor textIDTITULA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDTITULA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDTITULA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVTITULA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVTITULA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVTITULA = value;
            }
        }

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.TITULAController TITULAController { get; set; }

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

