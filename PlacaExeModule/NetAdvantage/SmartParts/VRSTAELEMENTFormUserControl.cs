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
    public class VRSTAELEMENTFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDVRSTAELEMENTA")]
        private UltraLabel _label1IDVRSTAELEMENTA;
        [AccessedThroughProperty("label1NAZIVVRSTAELEMENT")]
        private UltraLabel _label1NAZIVVRSTAELEMENT;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDVRSTAELEMENTA")]
        private UltraNumericEditor _textIDVRSTAELEMENTA;
        [AccessedThroughProperty("textNAZIVVRSTAELEMENT")]
        private UltraTextEditor _textNAZIVVRSTAELEMENT;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceVRSTAELEMENT;
        private IContainer components = null;
        private VRSTAELEMENTDataSet dsVRSTAELEMENTDataSet1;
        protected TableLayoutPanel layoutManagerformVRSTAELEMENT;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private VRSTAELEMENTDataSet.VRSTAELEMENTRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "VRSTAELEMENT";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.VRSTAELEMENTDescription;
        private DeklaritMode m_Mode;

        public VRSTAELEMENTFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceVRSTAELEMENT.DataSource = this.VRSTAELEMENTController.DataSet;
            this.dsVRSTAELEMENTDataSet1 = this.VRSTAELEMENTController.DataSet;
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
                    enumerator = this.dsVRSTAELEMENTDataSet1.VRSTAELEMENT.Rows.GetEnumerator();
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
                if (this.VRSTAELEMENTController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "VRSTAELEMENT", this.m_Mode, this.dsVRSTAELEMENTDataSet1, this.dsVRSTAELEMENTDataSet1.VRSTAELEMENT.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsVRSTAELEMENTDataSet1.VRSTAELEMENT[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (VRSTAELEMENTDataSet.VRSTAELEMENTRow) ((DataRowView) this.bindingSourceVRSTAELEMENT.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(VRSTAELEMENTFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceVRSTAELEMENT = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceVRSTAELEMENT).BeginInit();
            this.layoutManagerformVRSTAELEMENT = new TableLayoutPanel();
            this.layoutManagerformVRSTAELEMENT.SuspendLayout();
            this.layoutManagerformVRSTAELEMENT.AutoSize = true;
            this.layoutManagerformVRSTAELEMENT.Dock = DockStyle.Fill;
            this.layoutManagerformVRSTAELEMENT.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformVRSTAELEMENT.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformVRSTAELEMENT.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformVRSTAELEMENT.Size = size;
            this.layoutManagerformVRSTAELEMENT.ColumnCount = 2;
            this.layoutManagerformVRSTAELEMENT.RowCount = 3;
            this.layoutManagerformVRSTAELEMENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVRSTAELEMENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVRSTAELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformVRSTAELEMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformVRSTAELEMENT.RowStyles.Add(new RowStyle());
            this.label1IDVRSTAELEMENTA = new UltraLabel();
            this.textIDVRSTAELEMENTA = new UltraNumericEditor();
            this.label1NAZIVVRSTAELEMENT = new UltraLabel();
            this.textNAZIVVRSTAELEMENT = new UltraTextEditor();
            ((ISupportInitialize) this.textIDVRSTAELEMENTA).BeginInit();
            ((ISupportInitialize) this.textNAZIVVRSTAELEMENT).BeginInit();
            this.dsVRSTAELEMENTDataSet1 = new VRSTAELEMENTDataSet();
            this.dsVRSTAELEMENTDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsVRSTAELEMENTDataSet1.DataSetName = "dsVRSTAELEMENT";
            this.dsVRSTAELEMENTDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceVRSTAELEMENT.DataSource = this.dsVRSTAELEMENTDataSet1;
            this.bindingSourceVRSTAELEMENT.DataMember = "VRSTAELEMENT";
            ((ISupportInitialize) this.bindingSourceVRSTAELEMENT).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDVRSTAELEMENTA.Location = point;
            this.label1IDVRSTAELEMENTA.Name = "label1IDVRSTAELEMENTA";
            this.label1IDVRSTAELEMENTA.TabIndex = 1;
            this.label1IDVRSTAELEMENTA.Tag = "labelIDVRSTAELEMENTA";
            this.label1IDVRSTAELEMENTA.Text = "Šifra Vrste elementa:";
            this.label1IDVRSTAELEMENTA.StyleSetName = "FieldUltraLabel";
            this.label1IDVRSTAELEMENTA.AutoSize = true;
            this.label1IDVRSTAELEMENTA.Anchor = AnchorStyles.Left;
            this.label1IDVRSTAELEMENTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDVRSTAELEMENTA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDVRSTAELEMENTA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDVRSTAELEMENTA.ImageSize = size;
            this.label1IDVRSTAELEMENTA.Appearance.ForeColor = Color.Black;
            this.label1IDVRSTAELEMENTA.BackColor = Color.Transparent;
            this.layoutManagerformVRSTAELEMENT.Controls.Add(this.label1IDVRSTAELEMENTA, 0, 0);
            this.layoutManagerformVRSTAELEMENT.SetColumnSpan(this.label1IDVRSTAELEMENTA, 1);
            this.layoutManagerformVRSTAELEMENT.SetRowSpan(this.label1IDVRSTAELEMENTA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDVRSTAELEMENTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDVRSTAELEMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x8f, 0x17);
            this.label1IDVRSTAELEMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDVRSTAELEMENTA.Location = point;
            this.textIDVRSTAELEMENTA.Name = "textIDVRSTAELEMENTA";
            this.textIDVRSTAELEMENTA.Tag = "IDVRSTAELEMENTA";
            this.textIDVRSTAELEMENTA.TabIndex = 0;
            this.textIDVRSTAELEMENTA.Anchor = AnchorStyles.Left;
            this.textIDVRSTAELEMENTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDVRSTAELEMENTA.ReadOnly = false;
            this.textIDVRSTAELEMENTA.PromptChar = ' ';
            this.textIDVRSTAELEMENTA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDVRSTAELEMENTA.DataBindings.Add(new Binding("Value", this.bindingSourceVRSTAELEMENT, "IDVRSTAELEMENTA"));
            this.textIDVRSTAELEMENTA.NumericType = NumericType.Integer;
            this.textIDVRSTAELEMENTA.MaskInput = "{LOC}-nnnn";
            this.layoutManagerformVRSTAELEMENT.Controls.Add(this.textIDVRSTAELEMENTA, 1, 0);
            this.layoutManagerformVRSTAELEMENT.SetColumnSpan(this.textIDVRSTAELEMENTA, 1);
            this.layoutManagerformVRSTAELEMENT.SetRowSpan(this.textIDVRSTAELEMENTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDVRSTAELEMENTA.Margin = padding;
            size = new System.Drawing.Size(0x2d, 0x16);
            this.textIDVRSTAELEMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x16);
            this.textIDVRSTAELEMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVVRSTAELEMENT.Location = point;
            this.label1NAZIVVRSTAELEMENT.Name = "label1NAZIVVRSTAELEMENT";
            this.label1NAZIVVRSTAELEMENT.TabIndex = 1;
            this.label1NAZIVVRSTAELEMENT.Tag = "labelNAZIVVRSTAELEMENT";
            this.label1NAZIVVRSTAELEMENT.Text = "Naziv vrste elementa:";
            this.label1NAZIVVRSTAELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVVRSTAELEMENT.AutoSize = true;
            this.label1NAZIVVRSTAELEMENT.Anchor = AnchorStyles.Left;
            this.label1NAZIVVRSTAELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVVRSTAELEMENT.Appearance.ForeColor = Color.Black;
            this.label1NAZIVVRSTAELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformVRSTAELEMENT.Controls.Add(this.label1NAZIVVRSTAELEMENT, 0, 1);
            this.layoutManagerformVRSTAELEMENT.SetColumnSpan(this.label1NAZIVVRSTAELEMENT, 1);
            this.layoutManagerformVRSTAELEMENT.SetRowSpan(this.label1NAZIVVRSTAELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVVRSTAELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVVRSTAELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(150, 0x17);
            this.label1NAZIVVRSTAELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVVRSTAELEMENT.Location = point;
            this.textNAZIVVRSTAELEMENT.Name = "textNAZIVVRSTAELEMENT";
            this.textNAZIVVRSTAELEMENT.Tag = "NAZIVVRSTAELEMENT";
            this.textNAZIVVRSTAELEMENT.TabIndex = 0;
            this.textNAZIVVRSTAELEMENT.Anchor = AnchorStyles.Left;
            this.textNAZIVVRSTAELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVVRSTAELEMENT.ReadOnly = false;
            this.textNAZIVVRSTAELEMENT.DataBindings.Add(new Binding("Text", this.bindingSourceVRSTAELEMENT, "NAZIVVRSTAELEMENT"));
            this.textNAZIVVRSTAELEMENT.MaxLength = 0x19;
            this.layoutManagerformVRSTAELEMENT.Controls.Add(this.textNAZIVVRSTAELEMENT, 1, 1);
            this.layoutManagerformVRSTAELEMENT.SetColumnSpan(this.textNAZIVVRSTAELEMENT, 1);
            this.layoutManagerformVRSTAELEMENT.SetRowSpan(this.textNAZIVVRSTAELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVVRSTAELEMENT.Margin = padding;
            size = new System.Drawing.Size(0xbf, 0x16);
            this.textNAZIVVRSTAELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0xbf, 0x16);
            this.textNAZIVVRSTAELEMENT.Size = size;
            this.Controls.Add(this.layoutManagerformVRSTAELEMENT);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceVRSTAELEMENT;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "VRSTAELEMENTFormUserControl";
            this.Text = "Vrste elementa";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.VRSTAELEMENTFormUserControl_Load);
            this.layoutManagerformVRSTAELEMENT.ResumeLayout(false);
            this.layoutManagerformVRSTAELEMENT.PerformLayout();
            ((ISupportInitialize) this.bindingSourceVRSTAELEMENT).EndInit();
            ((ISupportInitialize) this.textIDVRSTAELEMENTA).EndInit();
            ((ISupportInitialize) this.textNAZIVVRSTAELEMENT).EndInit();
            this.dsVRSTAELEMENTDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.VRSTAELEMENTController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceVRSTAELEMENT, this.VRSTAELEMENTController.WorkItem, this))
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
            this.label1IDVRSTAELEMENTA.Text = StringResources.VRSTAELEMENTIDVRSTAELEMENTADescription;
            this.label1NAZIVVRSTAELEMENT.Text = StringResources.VRSTAELEMENTNAZIVVRSTAELEMENTDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewELEMENT")]
        public void NewELEMENTHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.VRSTAELEMENTController.NewELEMENT(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.VRSTAELEMENTController.WorkItem.Items.Contains("VRSTAELEMENT|VRSTAELEMENT"))
            {
                this.VRSTAELEMENTController.WorkItem.Items.Add(this.bindingSourceVRSTAELEMENT, "VRSTAELEMENT|VRSTAELEMENT");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsVRSTAELEMENTDataSet1.VRSTAELEMENT.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.VRSTAELEMENTController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.VRSTAELEMENTController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.VRSTAELEMENTController.Update(this))
            {
                this.VRSTAELEMENTController.DataSet = new VRSTAELEMENTDataSet();
                DataSetUtil.AddEmptyRow(this.VRSTAELEMENTController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.VRSTAELEMENTController.DataSet.VRSTAELEMENT[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDVRSTAELEMENTA.Focus();
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

        [LocalCommandHandler("ViewELEMENT")]
        public void ViewELEMENTHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.VRSTAELEMENTController.ViewELEMENT(this.m_CurrentRow);
            }
        }

        private void VRSTAELEMENTFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.VRSTAELEMENTDescription;
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

        protected virtual UltraLabel label1IDVRSTAELEMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDVRSTAELEMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDVRSTAELEMENTA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVVRSTAELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVVRSTAELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVVRSTAELEMENT = value;
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

        protected virtual UltraNumericEditor textIDVRSTAELEMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDVRSTAELEMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDVRSTAELEMENTA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVVRSTAELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVVRSTAELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVVRSTAELEMENT = value;
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
        public NetAdvantage.Controllers.VRSTAELEMENTController VRSTAELEMENTController { get; set; }
    }
}

