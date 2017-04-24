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
    public class URAVRSTAIZNOSAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDURAVRSTAIZNOSA")]
        private UltraLabel _label1IDURAVRSTAIZNOSA;
        [AccessedThroughProperty("label1URAVRSTAIZNOSANAZIV")]
        private UltraLabel _label1URAVRSTAIZNOSANAZIV;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDURAVRSTAIZNOSA")]
        private UltraNumericEditor _textIDURAVRSTAIZNOSA;
        [AccessedThroughProperty("textURAVRSTAIZNOSANAZIV")]
        private UltraTextEditor _textURAVRSTAIZNOSANAZIV;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceURAVRSTAIZNOSA;
        private IContainer components = null;
        private URAVRSTAIZNOSADataSet dsURAVRSTAIZNOSADataSet1;
        protected TableLayoutPanel layoutManagerformURAVRSTAIZNOSA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "URAVRSTAIZNOSA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.URAVRSTAIZNOSADescription;
        private DeklaritMode m_Mode;

        public URAVRSTAIZNOSAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceURAVRSTAIZNOSA.DataSource = this.URAVRSTAIZNOSAController.DataSet;
            this.dsURAVRSTAIZNOSADataSet1 = this.URAVRSTAIZNOSAController.DataSet;
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
                    enumerator = this.dsURAVRSTAIZNOSADataSet1.URAVRSTAIZNOSA.Rows.GetEnumerator();
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
                if (this.URAVRSTAIZNOSAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "URAVRSTAIZNOSA", this.m_Mode, this.dsURAVRSTAIZNOSADataSet1, this.dsURAVRSTAIZNOSADataSet1.URAVRSTAIZNOSA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsURAVRSTAIZNOSADataSet1.URAVRSTAIZNOSA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (URAVRSTAIZNOSADataSet.URAVRSTAIZNOSARow) ((DataRowView) this.bindingSourceURAVRSTAIZNOSA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(URAVRSTAIZNOSAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceURAVRSTAIZNOSA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceURAVRSTAIZNOSA).BeginInit();
            this.layoutManagerformURAVRSTAIZNOSA = new TableLayoutPanel();
            this.layoutManagerformURAVRSTAIZNOSA.SuspendLayout();
            this.layoutManagerformURAVRSTAIZNOSA.AutoSize = true;
            this.layoutManagerformURAVRSTAIZNOSA.Dock = DockStyle.Fill;
            this.layoutManagerformURAVRSTAIZNOSA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformURAVRSTAIZNOSA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformURAVRSTAIZNOSA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformURAVRSTAIZNOSA.Size = size;
            this.layoutManagerformURAVRSTAIZNOSA.ColumnCount = 2;
            this.layoutManagerformURAVRSTAIZNOSA.RowCount = 3;
            this.layoutManagerformURAVRSTAIZNOSA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformURAVRSTAIZNOSA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformURAVRSTAIZNOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformURAVRSTAIZNOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformURAVRSTAIZNOSA.RowStyles.Add(new RowStyle());
            this.label1IDURAVRSTAIZNOSA = new UltraLabel();
            this.textIDURAVRSTAIZNOSA = new UltraNumericEditor();
            this.label1URAVRSTAIZNOSANAZIV = new UltraLabel();
            this.textURAVRSTAIZNOSANAZIV = new UltraTextEditor();
            ((ISupportInitialize) this.textIDURAVRSTAIZNOSA).BeginInit();
            ((ISupportInitialize) this.textURAVRSTAIZNOSANAZIV).BeginInit();
            this.dsURAVRSTAIZNOSADataSet1 = new URAVRSTAIZNOSADataSet();
            this.dsURAVRSTAIZNOSADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsURAVRSTAIZNOSADataSet1.DataSetName = "dsURAVRSTAIZNOSA";
            this.dsURAVRSTAIZNOSADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceURAVRSTAIZNOSA.DataSource = this.dsURAVRSTAIZNOSADataSet1;
            this.bindingSourceURAVRSTAIZNOSA.DataMember = "URAVRSTAIZNOSA";
            ((ISupportInitialize) this.bindingSourceURAVRSTAIZNOSA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDURAVRSTAIZNOSA.Location = point;
            this.label1IDURAVRSTAIZNOSA.Name = "label1IDURAVRSTAIZNOSA";
            this.label1IDURAVRSTAIZNOSA.TabIndex = 1;
            this.label1IDURAVRSTAIZNOSA.Tag = "labelIDURAVRSTAIZNOSA";
            this.label1IDURAVRSTAIZNOSA.Text = "Šifra:";
            this.label1IDURAVRSTAIZNOSA.StyleSetName = "FieldUltraLabel";
            this.label1IDURAVRSTAIZNOSA.AutoSize = true;
            this.label1IDURAVRSTAIZNOSA.Anchor = AnchorStyles.Left;
            this.label1IDURAVRSTAIZNOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDURAVRSTAIZNOSA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDURAVRSTAIZNOSA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDURAVRSTAIZNOSA.ImageSize = size;
            this.label1IDURAVRSTAIZNOSA.Appearance.ForeColor = Color.Black;
            this.label1IDURAVRSTAIZNOSA.BackColor = Color.Transparent;
            this.layoutManagerformURAVRSTAIZNOSA.Controls.Add(this.label1IDURAVRSTAIZNOSA, 0, 0);
            this.layoutManagerformURAVRSTAIZNOSA.SetColumnSpan(this.label1IDURAVRSTAIZNOSA, 1);
            this.layoutManagerformURAVRSTAIZNOSA.SetRowSpan(this.label1IDURAVRSTAIZNOSA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDURAVRSTAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDURAVRSTAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDURAVRSTAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDURAVRSTAIZNOSA.Location = point;
            this.textIDURAVRSTAIZNOSA.Name = "textIDURAVRSTAIZNOSA";
            this.textIDURAVRSTAIZNOSA.Tag = "IDURAVRSTAIZNOSA";
            this.textIDURAVRSTAIZNOSA.TabIndex = 0;
            this.textIDURAVRSTAIZNOSA.Anchor = AnchorStyles.Left;
            this.textIDURAVRSTAIZNOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDURAVRSTAIZNOSA.ReadOnly = false;
            this.textIDURAVRSTAIZNOSA.PromptChar = ' ';
            this.textIDURAVRSTAIZNOSA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDURAVRSTAIZNOSA.DataBindings.Add(new Binding("Value", this.bindingSourceURAVRSTAIZNOSA, "IDURAVRSTAIZNOSA"));
            this.textIDURAVRSTAIZNOSA.NumericType = NumericType.Integer;
            this.textIDURAVRSTAIZNOSA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformURAVRSTAIZNOSA.Controls.Add(this.textIDURAVRSTAIZNOSA, 1, 0);
            this.layoutManagerformURAVRSTAIZNOSA.SetColumnSpan(this.textIDURAVRSTAIZNOSA, 1);
            this.layoutManagerformURAVRSTAIZNOSA.SetRowSpan(this.textIDURAVRSTAIZNOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDURAVRSTAIZNOSA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDURAVRSTAIZNOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDURAVRSTAIZNOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1URAVRSTAIZNOSANAZIV.Location = point;
            this.label1URAVRSTAIZNOSANAZIV.Name = "label1URAVRSTAIZNOSANAZIV";
            this.label1URAVRSTAIZNOSANAZIV.TabIndex = 1;
            this.label1URAVRSTAIZNOSANAZIV.Tag = "labelURAVRSTAIZNOSANAZIV";
            this.label1URAVRSTAIZNOSANAZIV.Text = "Naziv:";
            this.label1URAVRSTAIZNOSANAZIV.StyleSetName = "FieldUltraLabel";
            this.label1URAVRSTAIZNOSANAZIV.AutoSize = true;
            this.label1URAVRSTAIZNOSANAZIV.Anchor = AnchorStyles.Left;
            this.label1URAVRSTAIZNOSANAZIV.Appearance.TextVAlign = VAlign.Middle;
            this.label1URAVRSTAIZNOSANAZIV.Appearance.ForeColor = Color.Black;
            this.label1URAVRSTAIZNOSANAZIV.BackColor = Color.Transparent;
            this.layoutManagerformURAVRSTAIZNOSA.Controls.Add(this.label1URAVRSTAIZNOSANAZIV, 0, 1);
            this.layoutManagerformURAVRSTAIZNOSA.SetColumnSpan(this.label1URAVRSTAIZNOSANAZIV, 1);
            this.layoutManagerformURAVRSTAIZNOSA.SetRowSpan(this.label1URAVRSTAIZNOSANAZIV, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1URAVRSTAIZNOSANAZIV.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1URAVRSTAIZNOSANAZIV.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1URAVRSTAIZNOSANAZIV.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textURAVRSTAIZNOSANAZIV.Location = point;
            this.textURAVRSTAIZNOSANAZIV.Name = "textURAVRSTAIZNOSANAZIV";
            this.textURAVRSTAIZNOSANAZIV.Tag = "URAVRSTAIZNOSANAZIV";
            this.textURAVRSTAIZNOSANAZIV.TabIndex = 0;
            this.textURAVRSTAIZNOSANAZIV.Anchor = AnchorStyles.Left;
            this.textURAVRSTAIZNOSANAZIV.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textURAVRSTAIZNOSANAZIV.ReadOnly = false;
            this.textURAVRSTAIZNOSANAZIV.DataBindings.Add(new Binding("Text", this.bindingSourceURAVRSTAIZNOSA, "URAVRSTAIZNOSANAZIV"));
            this.textURAVRSTAIZNOSANAZIV.MaxLength = 30;
            this.layoutManagerformURAVRSTAIZNOSA.Controls.Add(this.textURAVRSTAIZNOSANAZIV, 1, 1);
            this.layoutManagerformURAVRSTAIZNOSA.SetColumnSpan(this.textURAVRSTAIZNOSANAZIV, 1);
            this.layoutManagerformURAVRSTAIZNOSA.SetRowSpan(this.textURAVRSTAIZNOSANAZIV, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textURAVRSTAIZNOSANAZIV.Margin = padding;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textURAVRSTAIZNOSANAZIV.MinimumSize = size;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textURAVRSTAIZNOSANAZIV.Size = size;
            this.Controls.Add(this.layoutManagerformURAVRSTAIZNOSA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceURAVRSTAIZNOSA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "URAVRSTAIZNOSAFormUserControl";
            this.Text = "Vrste iznosa URA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.URAVRSTAIZNOSAFormUserControl_Load);
            this.layoutManagerformURAVRSTAIZNOSA.ResumeLayout(false);
            this.layoutManagerformURAVRSTAIZNOSA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceURAVRSTAIZNOSA).EndInit();
            ((ISupportInitialize) this.textIDURAVRSTAIZNOSA).EndInit();
            ((ISupportInitialize) this.textURAVRSTAIZNOSANAZIV).EndInit();
            this.dsURAVRSTAIZNOSADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.URAVRSTAIZNOSAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceURAVRSTAIZNOSA, this.URAVRSTAIZNOSAController.WorkItem, this))
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
            this.label1IDURAVRSTAIZNOSA.Text = StringResources.URAVRSTAIZNOSAIDURAVRSTAIZNOSADescription;
            this.label1URAVRSTAIZNOSANAZIV.Text = StringResources.URAVRSTAIZNOSAURAVRSTAIZNOSANAZIVDescription;
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
            if (!this.URAVRSTAIZNOSAController.WorkItem.Items.Contains("URAVRSTAIZNOSA|URAVRSTAIZNOSA"))
            {
                this.URAVRSTAIZNOSAController.WorkItem.Items.Add(this.bindingSourceURAVRSTAIZNOSA, "URAVRSTAIZNOSA|URAVRSTAIZNOSA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsURAVRSTAIZNOSADataSet1.URAVRSTAIZNOSA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.URAVRSTAIZNOSAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.URAVRSTAIZNOSAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.URAVRSTAIZNOSAController.Update(this))
            {
                this.URAVRSTAIZNOSAController.DataSet = new URAVRSTAIZNOSADataSet();
                DataSetUtil.AddEmptyRow(this.URAVRSTAIZNOSAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.URAVRSTAIZNOSAController.DataSet.URAVRSTAIZNOSA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDURAVRSTAIZNOSA.Focus();
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

        private void URAVRSTAIZNOSAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.URAVRSTAIZNOSADescription;
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

        protected virtual UltraLabel label1IDURAVRSTAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDURAVRSTAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDURAVRSTAIZNOSA = value;
            }
        }

        protected virtual UltraLabel label1URAVRSTAIZNOSANAZIV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1URAVRSTAIZNOSANAZIV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1URAVRSTAIZNOSANAZIV = value;
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

        protected virtual UltraNumericEditor textIDURAVRSTAIZNOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDURAVRSTAIZNOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDURAVRSTAIZNOSA = value;
            }
        }

        protected virtual UltraTextEditor textURAVRSTAIZNOSANAZIV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textURAVRSTAIZNOSANAZIV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textURAVRSTAIZNOSANAZIV = value;
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
        public NetAdvantage.Controllers.URAVRSTAIZNOSAController URAVRSTAIZNOSAController { get; set; }
    }
}

