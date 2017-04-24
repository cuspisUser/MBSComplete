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
    public class VRSTADOPRINOSFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDVRSTADOPRINOS")]
        private UltraLabel _label1IDVRSTADOPRINOS;
        [AccessedThroughProperty("label1NAZIVVRSTADOPRINOS")]
        private UltraLabel _label1NAZIVVRSTADOPRINOS;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDVRSTADOPRINOS")]
        private UltraNumericEditor _textIDVRSTADOPRINOS;
        [AccessedThroughProperty("textNAZIVVRSTADOPRINOS")]
        private UltraTextEditor _textNAZIVVRSTADOPRINOS;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceVRSTADOPRINOS;
        private IContainer components = null;
        private VRSTADOPRINOSDataSet dsVRSTADOPRINOSDataSet1;
        protected TableLayoutPanel layoutManagerformVRSTADOPRINOS;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private VRSTADOPRINOSDataSet.VRSTADOPRINOSRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "VRSTADOPRINOS";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.VRSTADOPRINOSDescription;
        private DeklaritMode m_Mode;

        public VRSTADOPRINOSFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceVRSTADOPRINOS.DataSource = this.VRSTADOPRINOSController.DataSet;
            this.dsVRSTADOPRINOSDataSet1 = this.VRSTADOPRINOSController.DataSet;
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
                    enumerator = this.dsVRSTADOPRINOSDataSet1.VRSTADOPRINOS.Rows.GetEnumerator();
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
                if (this.VRSTADOPRINOSController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "VRSTADOPRINOS", this.m_Mode, this.dsVRSTADOPRINOSDataSet1, this.dsVRSTADOPRINOSDataSet1.VRSTADOPRINOS.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsVRSTADOPRINOSDataSet1.VRSTADOPRINOS[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (VRSTADOPRINOSDataSet.VRSTADOPRINOSRow) ((DataRowView) this.bindingSourceVRSTADOPRINOS.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(VRSTADOPRINOSFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceVRSTADOPRINOS = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceVRSTADOPRINOS).BeginInit();
            this.layoutManagerformVRSTADOPRINOS = new TableLayoutPanel();
            this.layoutManagerformVRSTADOPRINOS.SuspendLayout();
            this.layoutManagerformVRSTADOPRINOS.AutoSize = true;
            this.layoutManagerformVRSTADOPRINOS.Dock = DockStyle.Fill;
            this.layoutManagerformVRSTADOPRINOS.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformVRSTADOPRINOS.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformVRSTADOPRINOS.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformVRSTADOPRINOS.Size = size;
            this.layoutManagerformVRSTADOPRINOS.ColumnCount = 2;
            this.layoutManagerformVRSTADOPRINOS.RowCount = 3;
            this.layoutManagerformVRSTADOPRINOS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVRSTADOPRINOS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVRSTADOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformVRSTADOPRINOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformVRSTADOPRINOS.RowStyles.Add(new RowStyle());
            this.label1IDVRSTADOPRINOS = new UltraLabel();
            this.textIDVRSTADOPRINOS = new UltraNumericEditor();
            this.label1NAZIVVRSTADOPRINOS = new UltraLabel();
            this.textNAZIVVRSTADOPRINOS = new UltraTextEditor();
            ((ISupportInitialize) this.textIDVRSTADOPRINOS).BeginInit();
            ((ISupportInitialize) this.textNAZIVVRSTADOPRINOS).BeginInit();
            this.dsVRSTADOPRINOSDataSet1 = new VRSTADOPRINOSDataSet();
            this.dsVRSTADOPRINOSDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsVRSTADOPRINOSDataSet1.DataSetName = "dsVRSTADOPRINOS";
            this.dsVRSTADOPRINOSDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceVRSTADOPRINOS.DataSource = this.dsVRSTADOPRINOSDataSet1;
            this.bindingSourceVRSTADOPRINOS.DataMember = "VRSTADOPRINOS";
            ((ISupportInitialize) this.bindingSourceVRSTADOPRINOS).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDVRSTADOPRINOS.Location = point;
            this.label1IDVRSTADOPRINOS.Name = "label1IDVRSTADOPRINOS";
            this.label1IDVRSTADOPRINOS.TabIndex = 1;
            this.label1IDVRSTADOPRINOS.Tag = "labelIDVRSTADOPRINOS";
            this.label1IDVRSTADOPRINOS.Text = "Šifra vrste doprinosa:";
            this.label1IDVRSTADOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1IDVRSTADOPRINOS.AutoSize = true;
            this.label1IDVRSTADOPRINOS.Anchor = AnchorStyles.Left;
            this.label1IDVRSTADOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDVRSTADOPRINOS.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDVRSTADOPRINOS.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDVRSTADOPRINOS.ImageSize = size;
            this.label1IDVRSTADOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1IDVRSTADOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformVRSTADOPRINOS.Controls.Add(this.label1IDVRSTADOPRINOS, 0, 0);
            this.layoutManagerformVRSTADOPRINOS.SetColumnSpan(this.label1IDVRSTADOPRINOS, 1);
            this.layoutManagerformVRSTADOPRINOS.SetRowSpan(this.label1IDVRSTADOPRINOS, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDVRSTADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDVRSTADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x91, 0x17);
            this.label1IDVRSTADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDVRSTADOPRINOS.Location = point;
            this.textIDVRSTADOPRINOS.Name = "textIDVRSTADOPRINOS";
            this.textIDVRSTADOPRINOS.Tag = "IDVRSTADOPRINOS";
            this.textIDVRSTADOPRINOS.TabIndex = 0;
            this.textIDVRSTADOPRINOS.Anchor = AnchorStyles.Left;
            this.textIDVRSTADOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDVRSTADOPRINOS.ReadOnly = false;
            this.textIDVRSTADOPRINOS.PromptChar = ' ';
            this.textIDVRSTADOPRINOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDVRSTADOPRINOS.DataBindings.Add(new Binding("Value", this.bindingSourceVRSTADOPRINOS, "IDVRSTADOPRINOS"));
            this.textIDVRSTADOPRINOS.NumericType = NumericType.Integer;
            this.textIDVRSTADOPRINOS.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformVRSTADOPRINOS.Controls.Add(this.textIDVRSTADOPRINOS, 1, 0);
            this.layoutManagerformVRSTADOPRINOS.SetColumnSpan(this.textIDVRSTADOPRINOS, 1);
            this.layoutManagerformVRSTADOPRINOS.SetRowSpan(this.textIDVRSTADOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDVRSTADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDVRSTADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDVRSTADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVVRSTADOPRINOS.Location = point;
            this.label1NAZIVVRSTADOPRINOS.Name = "label1NAZIVVRSTADOPRINOS";
            this.label1NAZIVVRSTADOPRINOS.TabIndex = 1;
            this.label1NAZIVVRSTADOPRINOS.Tag = "labelNAZIVVRSTADOPRINOS";
            this.label1NAZIVVRSTADOPRINOS.Text = "Naziv vrste doprinosa:";
            this.label1NAZIVVRSTADOPRINOS.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVVRSTADOPRINOS.AutoSize = true;
            this.label1NAZIVVRSTADOPRINOS.Anchor = AnchorStyles.Left;
            this.label1NAZIVVRSTADOPRINOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVVRSTADOPRINOS.Appearance.ForeColor = Color.Black;
            this.label1NAZIVVRSTADOPRINOS.BackColor = Color.Transparent;
            this.layoutManagerformVRSTADOPRINOS.Controls.Add(this.label1NAZIVVRSTADOPRINOS, 0, 1);
            this.layoutManagerformVRSTADOPRINOS.SetColumnSpan(this.label1NAZIVVRSTADOPRINOS, 1);
            this.layoutManagerformVRSTADOPRINOS.SetRowSpan(this.label1NAZIVVRSTADOPRINOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVVRSTADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVVRSTADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x99, 0x17);
            this.label1NAZIVVRSTADOPRINOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVVRSTADOPRINOS.Location = point;
            this.textNAZIVVRSTADOPRINOS.Name = "textNAZIVVRSTADOPRINOS";
            this.textNAZIVVRSTADOPRINOS.Tag = "NAZIVVRSTADOPRINOS";
            this.textNAZIVVRSTADOPRINOS.TabIndex = 0;
            this.textNAZIVVRSTADOPRINOS.Anchor = AnchorStyles.Left;
            this.textNAZIVVRSTADOPRINOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVVRSTADOPRINOS.ReadOnly = false;
            this.textNAZIVVRSTADOPRINOS.DataBindings.Add(new Binding("Text", this.bindingSourceVRSTADOPRINOS, "NAZIVVRSTADOPRINOS"));
            this.textNAZIVVRSTADOPRINOS.MaxLength = 50;
            this.layoutManagerformVRSTADOPRINOS.Controls.Add(this.textNAZIVVRSTADOPRINOS, 1, 1);
            this.layoutManagerformVRSTADOPRINOS.SetColumnSpan(this.textNAZIVVRSTADOPRINOS, 1);
            this.layoutManagerformVRSTADOPRINOS.SetRowSpan(this.textNAZIVVRSTADOPRINOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVVRSTADOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVVRSTADOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVVRSTADOPRINOS.Size = size;
            this.Controls.Add(this.layoutManagerformVRSTADOPRINOS);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceVRSTADOPRINOS;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "VRSTADOPRINOSFormUserControl";
            this.Text = "Vrste doprinosa";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.VRSTADOPRINOSFormUserControl_Load);
            this.layoutManagerformVRSTADOPRINOS.ResumeLayout(false);
            this.layoutManagerformVRSTADOPRINOS.PerformLayout();
            ((ISupportInitialize) this.bindingSourceVRSTADOPRINOS).EndInit();
            ((ISupportInitialize) this.textIDVRSTADOPRINOS).EndInit();
            ((ISupportInitialize) this.textNAZIVVRSTADOPRINOS).EndInit();
            this.dsVRSTADOPRINOSDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.VRSTADOPRINOSController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceVRSTADOPRINOS, this.VRSTADOPRINOSController.WorkItem, this))
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
            this.label1IDVRSTADOPRINOS.Text = StringResources.VRSTADOPRINOSIDVRSTADOPRINOSDescription;
            this.label1NAZIVVRSTADOPRINOS.Text = StringResources.VRSTADOPRINOSNAZIVVRSTADOPRINOSDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewDOPRINOS")]
        public void NewDOPRINOSHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.VRSTADOPRINOSController.NewDOPRINOS(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.VRSTADOPRINOSController.WorkItem.Items.Contains("VRSTADOPRINOS|VRSTADOPRINOS"))
            {
                this.VRSTADOPRINOSController.WorkItem.Items.Add(this.bindingSourceVRSTADOPRINOS, "VRSTADOPRINOS|VRSTADOPRINOS");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsVRSTADOPRINOSDataSet1.VRSTADOPRINOS.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.VRSTADOPRINOSController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.VRSTADOPRINOSController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.VRSTADOPRINOSController.Update(this))
            {
                this.VRSTADOPRINOSController.DataSet = new VRSTADOPRINOSDataSet();
                DataSetUtil.AddEmptyRow(this.VRSTADOPRINOSController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.VRSTADOPRINOSController.DataSet.VRSTADOPRINOS[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDVRSTADOPRINOS.Focus();
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

        [LocalCommandHandler("ViewDOPRINOS")]
        public void ViewDOPRINOSHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.VRSTADOPRINOSController.ViewDOPRINOS(this.m_CurrentRow);
            }
        }

        private void VRSTADOPRINOSFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.VRSTADOPRINOSDescription;
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

        protected virtual UltraLabel label1IDVRSTADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDVRSTADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDVRSTADOPRINOS = value;
            }
        }

        protected virtual UltraLabel label1NAZIVVRSTADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVVRSTADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVVRSTADOPRINOS = value;
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

        protected virtual UltraNumericEditor textIDVRSTADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDVRSTADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDVRSTADOPRINOS = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVVRSTADOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVVRSTADOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVVRSTADOPRINOS = value;
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.VRSTADOPRINOSController VRSTADOPRINOSController { get; set; }
    }
}

