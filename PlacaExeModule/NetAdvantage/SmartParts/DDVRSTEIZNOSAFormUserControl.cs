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
    public class DDVRSTEIZNOSAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDDDVRSTEIZNOSA")]
        private UltraLabel _label1IDDDVRSTEIZNOSA;
        [AccessedThroughProperty("label1NAZIVDDVRSTEIZNOSA")]
        private UltraLabel _label1NAZIVDDVRSTEIZNOSA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDDDVRSTEIZNOSA")]
        private UltraNumericEditor _textIDDDVRSTEIZNOSA;
        [AccessedThroughProperty("textNAZIVDDVRSTEIZNOSA")]
        private UltraTextEditor _textNAZIVDDVRSTEIZNOSA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceDDVRSTEIZNOSA;
        private IContainer components = null;
        private DDVRSTEIZNOSADataSet dsDDVRSTEIZNOSADataSet1;
        protected TableLayoutPanel layoutManagerformDDVRSTEIZNOSA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "DDVRSTEIZNOSA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.DDVRSTEIZNOSADescription;
        private DeklaritMode m_Mode;

        public DDVRSTEIZNOSAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceDDVRSTEIZNOSA.DataSource = this.DDVRSTEIZNOSAController.DataSet;
            this.dsDDVRSTEIZNOSADataSet1 = this.DDVRSTEIZNOSAController.DataSet;
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

        private void DDVRSTEIZNOSAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.DDVRSTEIZNOSADescription;
            this.errorProvider1.ContainerControl = this;
        }

        [LocalCommandHandler("DeleteInstance")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.dsDDVRSTEIZNOSADataSet1.DDVRSTEIZNOSA.Rows.GetEnumerator();
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
                if (this.DDVRSTEIZNOSAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "DDVRSTEIZNOSA", this.m_Mode, this.dsDDVRSTEIZNOSADataSet1, this.dsDDVRSTEIZNOSADataSet1.DDVRSTEIZNOSA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsDDVRSTEIZNOSADataSet1.DDVRSTEIZNOSA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow) ((DataRowView) this.bindingSourceDDVRSTEIZNOSA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(DDVRSTEIZNOSAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceDDVRSTEIZNOSA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDDVRSTEIZNOSA).BeginInit();
            this.layoutManagerformDDVRSTEIZNOSA = new TableLayoutPanel();
            this.layoutManagerformDDVRSTEIZNOSA.SuspendLayout();
            this.layoutManagerformDDVRSTEIZNOSA.AutoSize = true;
            this.layoutManagerformDDVRSTEIZNOSA.Dock = DockStyle.Fill;
            this.layoutManagerformDDVRSTEIZNOSA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformDDVRSTEIZNOSA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformDDVRSTEIZNOSA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformDDVRSTEIZNOSA.Size = size;
            this.layoutManagerformDDVRSTEIZNOSA.ColumnCount = 2;
            this.layoutManagerformDDVRSTEIZNOSA.RowCount = 3;
            this.layoutManagerformDDVRSTEIZNOSA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDDVRSTEIZNOSA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDDVRSTEIZNOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDVRSTEIZNOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDVRSTEIZNOSA.RowStyles.Add(new RowStyle());
            this.label1IDDDVRSTEIZNOSA = new UltraLabel();
            this.textIDDDVRSTEIZNOSA = new UltraNumericEditor();
            this.label1NAZIVDDVRSTEIZNOSA = new UltraLabel();
            this.textNAZIVDDVRSTEIZNOSA = new UltraTextEditor();
            ((ISupportInitialize) this.textIDDDVRSTEIZNOSA).BeginInit();
            ((ISupportInitialize) this.textNAZIVDDVRSTEIZNOSA).BeginInit();
            this.dsDDVRSTEIZNOSADataSet1 = new DDVRSTEIZNOSADataSet();
            this.dsDDVRSTEIZNOSADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsDDVRSTEIZNOSADataSet1.DataSetName = "dsDDVRSTEIZNOSA";
            this.dsDDVRSTEIZNOSADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceDDVRSTEIZNOSA.DataSource = this.dsDDVRSTEIZNOSADataSet1;
            this.bindingSourceDDVRSTEIZNOSA.DataMember = "DDVRSTEIZNOSA";
            ((ISupportInitialize) this.bindingSourceDDVRSTEIZNOSA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDDDVRSTEIZNOSA.Location = point;
            this.label1IDDDVRSTEIZNOSA.Name = "label1IDDDVRSTEIZNOSA";
            this.label1IDDDVRSTEIZNOSA.TabIndex = 1;
            this.label1IDDDVRSTEIZNOSA.Tag = "labelIDDDVRSTEIZNOSA";
            this.label1IDDDVRSTEIZNOSA.Text = "Šifra:";
            this.label1IDDDVRSTEIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1IDDDVRSTEIZNOSA.AutoSize = true;
            this.label1IDDDVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.label1IDDDVRSTEIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDDDVRSTEIZNOSA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDDDVRSTEIZNOSA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDDDVRSTEIZNOSA.ImageSize = size;
            this.label1IDDDVRSTEIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1IDDDVRSTEIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformDDVRSTEIZNOSA.Controls.Add(this.label1IDDDVRSTEIZNOSA, 0, 0);
            this.layoutManagerformDDVRSTEIZNOSA.SetColumnSpan(this.label1IDDDVRSTEIZNOSA, 1);
            this.layoutManagerformDDVRSTEIZNOSA.SetRowSpan(this.label1IDDDVRSTEIZNOSA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDDDVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDDDVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDDDVRSTEIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDDDVRSTEIZNOSA.Location = point;
            this.textIDDDVRSTEIZNOSA.Name = "textIDDDVRSTEIZNOSA";
            this.textIDDDVRSTEIZNOSA.Tag = "IDDDVRSTEIZNOSA";
            this.textIDDDVRSTEIZNOSA.TabIndex = 0;
            this.textIDDDVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.textIDDDVRSTEIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDDDVRSTEIZNOSA.ReadOnly = false;
            this.textIDDDVRSTEIZNOSA.PromptChar = ' ';
            this.textIDDDVRSTEIZNOSA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDDDVRSTEIZNOSA.DataBindings.Add(new Binding("Value", this.bindingSourceDDVRSTEIZNOSA, "IDDDVRSTEIZNOSA"));
            this.textIDDDVRSTEIZNOSA.NumericType = NumericType.Integer;
            this.textIDDDVRSTEIZNOSA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformDDVRSTEIZNOSA.Controls.Add(this.textIDDDVRSTEIZNOSA, 1, 0);
            this.layoutManagerformDDVRSTEIZNOSA.SetColumnSpan(this.textIDDDVRSTEIZNOSA, 1);
            this.layoutManagerformDDVRSTEIZNOSA.SetRowSpan(this.textIDDDVRSTEIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDDDVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDDDVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDDDVRSTEIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVDDVRSTEIZNOSA.Location = point;
            this.label1NAZIVDDVRSTEIZNOSA.Name = "label1NAZIVDDVRSTEIZNOSA";
            this.label1NAZIVDDVRSTEIZNOSA.TabIndex = 1;
            this.label1NAZIVDDVRSTEIZNOSA.Tag = "labelNAZIVDDVRSTEIZNOSA";
            this.label1NAZIVDDVRSTEIZNOSA.Text = "Vrsta iznosa - DD:";
            this.label1NAZIVDDVRSTEIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVDDVRSTEIZNOSA.AutoSize = true;
            this.label1NAZIVDDVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.label1NAZIVDDVRSTEIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVDDVRSTEIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVDDVRSTEIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformDDVRSTEIZNOSA.Controls.Add(this.label1NAZIVDDVRSTEIZNOSA, 0, 1);
            this.layoutManagerformDDVRSTEIZNOSA.SetColumnSpan(this.label1NAZIVDDVRSTEIZNOSA, 1);
            this.layoutManagerformDDVRSTEIZNOSA.SetRowSpan(this.label1NAZIVDDVRSTEIZNOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVDDVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVDDVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x7e, 0x17);
            this.label1NAZIVDDVRSTEIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVDDVRSTEIZNOSA.Location = point;
            this.textNAZIVDDVRSTEIZNOSA.Name = "textNAZIVDDVRSTEIZNOSA";
            this.textNAZIVDDVRSTEIZNOSA.Tag = "NAZIVDDVRSTEIZNOSA";
            this.textNAZIVDDVRSTEIZNOSA.TabIndex = 0;
            this.textNAZIVDDVRSTEIZNOSA.Anchor = AnchorStyles.Left;
            this.textNAZIVDDVRSTEIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVDDVRSTEIZNOSA.ReadOnly = false;
            this.textNAZIVDDVRSTEIZNOSA.DataBindings.Add(new Binding("Text", this.bindingSourceDDVRSTEIZNOSA, "NAZIVDDVRSTEIZNOSA"));
            this.textNAZIVDDVRSTEIZNOSA.MaxLength = 50;
            this.layoutManagerformDDVRSTEIZNOSA.Controls.Add(this.textNAZIVDDVRSTEIZNOSA, 1, 1);
            this.layoutManagerformDDVRSTEIZNOSA.SetColumnSpan(this.textNAZIVDDVRSTEIZNOSA, 1);
            this.layoutManagerformDDVRSTEIZNOSA.SetRowSpan(this.textNAZIVDDVRSTEIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVDDVRSTEIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVDDVRSTEIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVDDVRSTEIZNOSA.Size = size;
            this.Controls.Add(this.layoutManagerformDDVRSTEIZNOSA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceDDVRSTEIZNOSA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "DDVRSTEIZNOSAFormUserControl";
            this.Text = "DD-Vrste iznosa";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.DDVRSTEIZNOSAFormUserControl_Load);
            this.layoutManagerformDDVRSTEIZNOSA.ResumeLayout(false);
            this.layoutManagerformDDVRSTEIZNOSA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceDDVRSTEIZNOSA).EndInit();
            ((ISupportInitialize) this.textIDDDVRSTEIZNOSA).EndInit();
            ((ISupportInitialize) this.textNAZIVDDVRSTEIZNOSA).EndInit();
            this.dsDDVRSTEIZNOSADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.DDVRSTEIZNOSAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceDDVRSTEIZNOSA, this.DDVRSTEIZNOSAController.WorkItem, this))
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
            this.label1IDDDVRSTEIZNOSA.Text = StringResources.DDVRSTEIZNOSAIDDDVRSTEIZNOSADescription;
            this.label1NAZIVDDVRSTEIZNOSA.Text = StringResources.DDVRSTEIZNOSANAZIVDDVRSTEIZNOSADescription;
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
            if (!this.DDVRSTEIZNOSAController.WorkItem.Items.Contains("DDVRSTEIZNOSA|DDVRSTEIZNOSA"))
            {
                this.DDVRSTEIZNOSAController.WorkItem.Items.Add(this.bindingSourceDDVRSTEIZNOSA, "DDVRSTEIZNOSA|DDVRSTEIZNOSA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsDDVRSTEIZNOSADataSet1.DDVRSTEIZNOSA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.DDVRSTEIZNOSAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DDVRSTEIZNOSAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DDVRSTEIZNOSAController.Update(this))
            {
                this.DDVRSTEIZNOSAController.DataSet = new DDVRSTEIZNOSADataSet();
                DataSetUtil.AddEmptyRow(this.DDVRSTEIZNOSAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.DDVRSTEIZNOSAController.DataSet.DDVRSTEIZNOSA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDDDVRSTEIZNOSA.Focus();
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.DDVRSTEIZNOSAController DDVRSTEIZNOSAController { get; set; }

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

        protected virtual UltraLabel label1IDDDVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDDDVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDDDVRSTEIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVDDVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVDDVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVDDVRSTEIZNOSA = value;
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

        protected virtual UltraNumericEditor textIDDDVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDDDVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDDDVRSTEIZNOSA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVDDVRSTEIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVDDVRSTEIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVDDVRSTEIZNOSA = value;
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

