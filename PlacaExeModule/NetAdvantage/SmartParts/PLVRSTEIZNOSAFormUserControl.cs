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
    public class PLVRSTEIZNOSAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDPLVRSTEIZNOSA")]
        private UltraLabel _label1IDPLVRSTEIZNOSA;
        [AccessedThroughProperty("label1NAZIVPLVRSTEIZNOSA")]
        private UltraLabel _label1NAZIVPLVRSTEIZNOSA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDPLVRSTEIZNOSA")]
        private UltraNumericEditor _textIDPLVRSTEIZNOSA;
        [AccessedThroughProperty("textNAZIVPLVRSTEIZNOSA")]
        private UltraTextEditor _textNAZIVPLVRSTEIZNOSA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourcePLVRSTEIZNOSA;
        private IContainer components = null;
        private PLVRSTEIZNOSADataSet dsPLVRSTEIZNOSADataSet1;
        protected TableLayoutPanel layoutManagerformPLVRSTEIZNOSA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "PLVRSTEIZNOSA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.PLVRSTEIZNOSADescription;
        private DeklaritMode m_Mode;

        public PLVRSTEIZNOSAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourcePLVRSTEIZNOSA.DataSource = this.PLVRSTEIZNOSAController.DataSet;
            this.dsPLVRSTEIZNOSADataSet1 = this.PLVRSTEIZNOSAController.DataSet;
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
                    enumerator = this.dsPLVRSTEIZNOSADataSet1.PLVRSTEIZNOSA.Rows.GetEnumerator();
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
                if (this.PLVRSTEIZNOSAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "PLVRSTEIZNOSA", this.m_Mode, this.dsPLVRSTEIZNOSADataSet1, this.dsPLVRSTEIZNOSADataSet1.PLVRSTEIZNOSA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsPLVRSTEIZNOSADataSet1.PLVRSTEIZNOSA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (PLVRSTEIZNOSADataSet.PLVRSTEIZNOSARow) ((DataRowView) this.bindingSourcePLVRSTEIZNOSA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(PLVRSTEIZNOSAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourcePLVRSTEIZNOSA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePLVRSTEIZNOSA).BeginInit();
            this.layoutManagerformPLVRSTEIZNOSA = new TableLayoutPanel();
            this.layoutManagerformPLVRSTEIZNOSA.SuspendLayout();
            this.layoutManagerformPLVRSTEIZNOSA.AutoSize = true;
            this.layoutManagerformPLVRSTEIZNOSA.Dock = DockStyle.Fill;
            this.layoutManagerformPLVRSTEIZNOSA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPLVRSTEIZNOSA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPLVRSTEIZNOSA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPLVRSTEIZNOSA.Size = size;
            this.layoutManagerformPLVRSTEIZNOSA.ColumnCount = 2;
            this.layoutManagerformPLVRSTEIZNOSA.RowCount = 3;
            this.layoutManagerformPLVRSTEIZNOSA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPLVRSTEIZNOSA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPLVRSTEIZNOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformPLVRSTEIZNOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformPLVRSTEIZNOSA.RowStyles.Add(new RowStyle());
            this.label1IDPLVRSTEIZNOSA = new UltraLabel();
            this.textIDPLVRSTEIZNOSA = new UltraNumericEditor();
            this.label1NAZIVPLVRSTEIZNOSA = new UltraLabel();
            this.textNAZIVPLVRSTEIZNOSA = new UltraTextEditor();
            ((ISupportInitialize) this.textIDPLVRSTEIZNOSA).BeginInit();
            ((ISupportInitialize) this.textNAZIVPLVRSTEIZNOSA).BeginInit();
            this.dsPLVRSTEIZNOSADataSet1 = new PLVRSTEIZNOSADataSet();
            this.dsPLVRSTEIZNOSADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsPLVRSTEIZNOSADataSet1.DataSetName = "dsPLVRSTEIZNOSA";
            this.dsPLVRSTEIZNOSADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourcePLVRSTEIZNOSA.DataSource = this.dsPLVRSTEIZNOSADataSet1;
            this.bindingSourcePLVRSTEIZNOSA.DataMember = "PLVRSTEIZNOSA";
            ((ISupportInitialize) this.bindingSourcePLVRSTEIZNOSA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDPLVRSTEIZNOSA.Location = point;
            this.label1IDPLVRSTEIZNOSA.Name = "label1IDPLVRSTEIZNOSA";
            this.label1IDPLVRSTEIZNOSA.TabIndex = 1;
            this.label1IDPLVRSTEIZNOSA.Tag = "labelIDPLVRSTEIZNOSA";
            this.label1IDPLVRSTEIZNOSA.Text = "Šifra:";
            this.label1IDPLVRSTEIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1IDPLVRSTEIZNOSA.AutoSize = true;
            this.label1IDPLVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.label1IDPLVRSTEIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDPLVRSTEIZNOSA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDPLVRSTEIZNOSA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDPLVRSTEIZNOSA.ImageSize = size;
            this.label1IDPLVRSTEIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1IDPLVRSTEIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformPLVRSTEIZNOSA.Controls.Add(this.label1IDPLVRSTEIZNOSA, 0, 0);
            this.layoutManagerformPLVRSTEIZNOSA.SetColumnSpan(this.label1IDPLVRSTEIZNOSA, 1);
            this.layoutManagerformPLVRSTEIZNOSA.SetRowSpan(this.label1IDPLVRSTEIZNOSA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDPLVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDPLVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDPLVRSTEIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDPLVRSTEIZNOSA.Location = point;
            this.textIDPLVRSTEIZNOSA.Name = "textIDPLVRSTEIZNOSA";
            this.textIDPLVRSTEIZNOSA.Tag = "IDPLVRSTEIZNOSA";
            this.textIDPLVRSTEIZNOSA.TabIndex = 0;
            this.textIDPLVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.textIDPLVRSTEIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDPLVRSTEIZNOSA.ReadOnly = false;
            this.textIDPLVRSTEIZNOSA.PromptChar = ' ';
            this.textIDPLVRSTEIZNOSA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDPLVRSTEIZNOSA.DataBindings.Add(new Binding("Value", this.bindingSourcePLVRSTEIZNOSA, "IDPLVRSTEIZNOSA"));
            this.textIDPLVRSTEIZNOSA.NumericType = NumericType.Integer;
            this.textIDPLVRSTEIZNOSA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformPLVRSTEIZNOSA.Controls.Add(this.textIDPLVRSTEIZNOSA, 1, 0);
            this.layoutManagerformPLVRSTEIZNOSA.SetColumnSpan(this.textIDPLVRSTEIZNOSA, 1);
            this.layoutManagerformPLVRSTEIZNOSA.SetRowSpan(this.textIDPLVRSTEIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDPLVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDPLVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDPLVRSTEIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVPLVRSTEIZNOSA.Location = point;
            this.label1NAZIVPLVRSTEIZNOSA.Name = "label1NAZIVPLVRSTEIZNOSA";
            this.label1NAZIVPLVRSTEIZNOSA.TabIndex = 1;
            this.label1NAZIVPLVRSTEIZNOSA.Tag = "labelNAZIVPLVRSTEIZNOSA";
            this.label1NAZIVPLVRSTEIZNOSA.Text = "Vrsta iznosa:";
            this.label1NAZIVPLVRSTEIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVPLVRSTEIZNOSA.AutoSize = true;
            this.label1NAZIVPLVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.label1NAZIVPLVRSTEIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVPLVRSTEIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVPLVRSTEIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformPLVRSTEIZNOSA.Controls.Add(this.label1NAZIVPLVRSTEIZNOSA, 0, 1);
            this.layoutManagerformPLVRSTEIZNOSA.SetColumnSpan(this.label1NAZIVPLVRSTEIZNOSA, 1);
            this.layoutManagerformPLVRSTEIZNOSA.SetRowSpan(this.label1NAZIVPLVRSTEIZNOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVPLVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVPLVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x5f, 0x17);
            this.label1NAZIVPLVRSTEIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVPLVRSTEIZNOSA.Location = point;
            this.textNAZIVPLVRSTEIZNOSA.Name = "textNAZIVPLVRSTEIZNOSA";
            this.textNAZIVPLVRSTEIZNOSA.Tag = "NAZIVPLVRSTEIZNOSA";
            this.textNAZIVPLVRSTEIZNOSA.TabIndex = 0;
            this.textNAZIVPLVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.textNAZIVPLVRSTEIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVPLVRSTEIZNOSA.ReadOnly = false;
            this.textNAZIVPLVRSTEIZNOSA.DataBindings.Add(new Binding("Text", this.bindingSourcePLVRSTEIZNOSA, "NAZIVPLVRSTEIZNOSA"));
            this.textNAZIVPLVRSTEIZNOSA.MaxLength = 50;
            this.layoutManagerformPLVRSTEIZNOSA.Controls.Add(this.textNAZIVPLVRSTEIZNOSA, 1, 1);
            this.layoutManagerformPLVRSTEIZNOSA.SetColumnSpan(this.textNAZIVPLVRSTEIZNOSA, 1);
            this.layoutManagerformPLVRSTEIZNOSA.SetRowSpan(this.textNAZIVPLVRSTEIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVPLVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVPLVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVPLVRSTEIZNOSA.Size = size;
            this.Controls.Add(this.layoutManagerformPLVRSTEIZNOSA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourcePLVRSTEIZNOSA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "PLVRSTEIZNOSAFormUserControl";
            this.Text = "PLVRSTEIZNOSA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.PLVRSTEIZNOSAFormUserControl_Load);
            this.layoutManagerformPLVRSTEIZNOSA.ResumeLayout(false);
            this.layoutManagerformPLVRSTEIZNOSA.PerformLayout();
            ((ISupportInitialize) this.bindingSourcePLVRSTEIZNOSA).EndInit();
            ((ISupportInitialize) this.textIDPLVRSTEIZNOSA).EndInit();
            ((ISupportInitialize) this.textNAZIVPLVRSTEIZNOSA).EndInit();
            this.dsPLVRSTEIZNOSADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.PLVRSTEIZNOSAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourcePLVRSTEIZNOSA, this.PLVRSTEIZNOSAController.WorkItem, this))
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
            this.label1IDPLVRSTEIZNOSA.Text = StringResources.PLVRSTEIZNOSAIDPLVRSTEIZNOSADescription;
            this.label1NAZIVPLVRSTEIZNOSA.Text = StringResources.PLVRSTEIZNOSANAZIVPLVRSTEIZNOSADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PLVRSTEIZNOSAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.PLVRSTEIZNOSADescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.PLVRSTEIZNOSAController.WorkItem.Items.Contains("PLVRSTEIZNOSA|PLVRSTEIZNOSA"))
            {
                this.PLVRSTEIZNOSAController.WorkItem.Items.Add(this.bindingSourcePLVRSTEIZNOSA, "PLVRSTEIZNOSA|PLVRSTEIZNOSA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsPLVRSTEIZNOSADataSet1.PLVRSTEIZNOSA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.PLVRSTEIZNOSAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.PLVRSTEIZNOSAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.PLVRSTEIZNOSAController.Update(this))
            {
                this.PLVRSTEIZNOSAController.DataSet = new PLVRSTEIZNOSADataSet();
                DataSetUtil.AddEmptyRow(this.PLVRSTEIZNOSAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.PLVRSTEIZNOSAController.DataSet.PLVRSTEIZNOSA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDPLVRSTEIZNOSA.Focus();
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

        protected virtual UltraLabel label1IDPLVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDPLVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDPLVRSTEIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVPLVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVPLVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVPLVRSTEIZNOSA = value;
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.PLVRSTEIZNOSAController PLVRSTEIZNOSAController { get; set; }

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

        protected virtual UltraNumericEditor textIDPLVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDPLVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDPLVRSTEIZNOSA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVPLVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVPLVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVPLVRSTEIZNOSA = value;
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

