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
    public class OSDOKUMENTFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDOSDOKUMENT")]
        private UltraLabel _label1IDOSDOKUMENT;
        [AccessedThroughProperty("label1NAZIVOSDOKUMENT")]
        private UltraLabel _label1NAZIVOSDOKUMENT;
        [AccessedThroughProperty("label1OSDK")]
        private UltraLabel _label1OSDK;
        [AccessedThroughProperty("labelOSDK")]
        private UltraLabel _labelOSDK;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDOSDOKUMENT")]
        private UltraNumericEditor _textIDOSDOKUMENT;
        [AccessedThroughProperty("textNAZIVOSDOKUMENT")]
        private UltraTextEditor _textNAZIVOSDOKUMENT;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceOSDOKUMENT;
        private IContainer components = null;
        private OSDOKUMENTDataSet dsOSDOKUMENTDataSet1;
        protected TableLayoutPanel layoutManagerformOSDOKUMENT;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OSDOKUMENTDataSet.OSDOKUMENTRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "OSDOKUMENT";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.OSDOKUMENTDescription;
        private DeklaritMode m_Mode;

        public OSDOKUMENTFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceOSDOKUMENT.DataSource = this.OSDOKUMENTController.DataSet;
            this.dsOSDOKUMENTDataSet1 = this.OSDOKUMENTController.DataSet;
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
                    enumerator = this.dsOSDOKUMENTDataSet1.OSDOKUMENT.Rows.GetEnumerator();
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
                if (this.OSDOKUMENTController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OSDOKUMENT", this.m_Mode, this.dsOSDOKUMENTDataSet1, this.dsOSDOKUMENTDataSet1.OSDOKUMENT.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsOSDOKUMENTDataSet1.OSDOKUMENT[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (OSDOKUMENTDataSet.OSDOKUMENTRow) ((DataRowView) this.bindingSourceOSDOKUMENT.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(OSDOKUMENTFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceOSDOKUMENT = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOSDOKUMENT).BeginInit();
            this.layoutManagerformOSDOKUMENT = new TableLayoutPanel();
            this.layoutManagerformOSDOKUMENT.SuspendLayout();
            this.layoutManagerformOSDOKUMENT.AutoSize = true;
            this.layoutManagerformOSDOKUMENT.Dock = DockStyle.Fill;
            this.layoutManagerformOSDOKUMENT.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformOSDOKUMENT.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformOSDOKUMENT.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformOSDOKUMENT.Size = size;
            this.layoutManagerformOSDOKUMENT.ColumnCount = 2;
            this.layoutManagerformOSDOKUMENT.RowCount = 4;
            this.layoutManagerformOSDOKUMENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOSDOKUMENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOSDOKUMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSDOKUMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSDOKUMENT.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSDOKUMENT.RowStyles.Add(new RowStyle());
            this.label1IDOSDOKUMENT = new UltraLabel();
            this.textIDOSDOKUMENT = new UltraNumericEditor();
            this.label1NAZIVOSDOKUMENT = new UltraLabel();
            this.textNAZIVOSDOKUMENT = new UltraTextEditor();
            this.label1OSDK = new UltraLabel();
            this.labelOSDK = new UltraLabel();
            ((ISupportInitialize) this.textIDOSDOKUMENT).BeginInit();
            ((ISupportInitialize) this.textNAZIVOSDOKUMENT).BeginInit();
            this.dsOSDOKUMENTDataSet1 = new OSDOKUMENTDataSet();
            this.dsOSDOKUMENTDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsOSDOKUMENTDataSet1.DataSetName = "dsOSDOKUMENT";
            this.dsOSDOKUMENTDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceOSDOKUMENT.DataSource = this.dsOSDOKUMENTDataSet1;
            this.bindingSourceOSDOKUMENT.DataMember = "OSDOKUMENT";
            ((ISupportInitialize) this.bindingSourceOSDOKUMENT).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDOSDOKUMENT.Location = point;
            this.label1IDOSDOKUMENT.Name = "label1IDOSDOKUMENT";
            this.label1IDOSDOKUMENT.TabIndex = 1;
            this.label1IDOSDOKUMENT.Tag = "labelIDOSDOKUMENT";
            this.label1IDOSDOKUMENT.Text = "Šifra:";
            this.label1IDOSDOKUMENT.StyleSetName = "FieldUltraLabel";
            this.label1IDOSDOKUMENT.AutoSize = true;
            this.label1IDOSDOKUMENT.Anchor = AnchorStyles.Left;
            this.label1IDOSDOKUMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOSDOKUMENT.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDOSDOKUMENT.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDOSDOKUMENT.ImageSize = size;
            this.label1IDOSDOKUMENT.Appearance.ForeColor = Color.Black;
            this.label1IDOSDOKUMENT.BackColor = Color.Transparent;
            this.layoutManagerformOSDOKUMENT.Controls.Add(this.label1IDOSDOKUMENT, 0, 0);
            this.layoutManagerformOSDOKUMENT.SetColumnSpan(this.label1IDOSDOKUMENT, 1);
            this.layoutManagerformOSDOKUMENT.SetRowSpan(this.label1IDOSDOKUMENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDOSDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOSDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDOSDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDOSDOKUMENT.Location = point;
            this.textIDOSDOKUMENT.Name = "textIDOSDOKUMENT";
            this.textIDOSDOKUMENT.Tag = "IDOSDOKUMENT";
            this.textIDOSDOKUMENT.TabIndex = 0;
            this.textIDOSDOKUMENT.Anchor = AnchorStyles.Left;
            this.textIDOSDOKUMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDOSDOKUMENT.ReadOnly = false;
            this.textIDOSDOKUMENT.PromptChar = ' ';
            this.textIDOSDOKUMENT.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDOSDOKUMENT.DataBindings.Add(new Binding("Value", this.bindingSourceOSDOKUMENT, "IDOSDOKUMENT"));
            this.textIDOSDOKUMENT.NumericType = NumericType.Integer;
            this.textIDOSDOKUMENT.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformOSDOKUMENT.Controls.Add(this.textIDOSDOKUMENT, 1, 0);
            this.layoutManagerformOSDOKUMENT.SetColumnSpan(this.textIDOSDOKUMENT, 1);
            this.layoutManagerformOSDOKUMENT.SetRowSpan(this.textIDOSDOKUMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOSDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDOSDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDOSDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVOSDOKUMENT.Location = point;
            this.label1NAZIVOSDOKUMENT.Name = "label1NAZIVOSDOKUMENT";
            this.label1NAZIVOSDOKUMENT.TabIndex = 1;
            this.label1NAZIVOSDOKUMENT.Tag = "labelNAZIVOSDOKUMENT";
            this.label1NAZIVOSDOKUMENT.Text = "Dokument:";
            this.label1NAZIVOSDOKUMENT.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVOSDOKUMENT.AutoSize = true;
            this.label1NAZIVOSDOKUMENT.Anchor = AnchorStyles.Left;
            this.label1NAZIVOSDOKUMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVOSDOKUMENT.Appearance.ForeColor = Color.Black;
            this.label1NAZIVOSDOKUMENT.BackColor = Color.Transparent;
            this.layoutManagerformOSDOKUMENT.Controls.Add(this.label1NAZIVOSDOKUMENT, 0, 1);
            this.layoutManagerformOSDOKUMENT.SetColumnSpan(this.label1NAZIVOSDOKUMENT, 1);
            this.layoutManagerformOSDOKUMENT.SetRowSpan(this.label1NAZIVOSDOKUMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVOSDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVOSDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x54, 0x17);
            this.label1NAZIVOSDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVOSDOKUMENT.Location = point;
            this.textNAZIVOSDOKUMENT.Name = "textNAZIVOSDOKUMENT";
            this.textNAZIVOSDOKUMENT.Tag = "NAZIVOSDOKUMENT";
            this.textNAZIVOSDOKUMENT.TabIndex = 0;
            this.textNAZIVOSDOKUMENT.Anchor = AnchorStyles.Left;
            this.textNAZIVOSDOKUMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVOSDOKUMENT.ReadOnly = false;
            this.textNAZIVOSDOKUMENT.DataBindings.Add(new Binding("Text", this.bindingSourceOSDOKUMENT, "NAZIVOSDOKUMENT"));
            this.textNAZIVOSDOKUMENT.MaxLength = 30;
            this.layoutManagerformOSDOKUMENT.Controls.Add(this.textNAZIVOSDOKUMENT, 1, 1);
            this.layoutManagerformOSDOKUMENT.SetColumnSpan(this.textNAZIVOSDOKUMENT, 1);
            this.layoutManagerformOSDOKUMENT.SetRowSpan(this.textNAZIVOSDOKUMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVOSDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textNAZIVOSDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textNAZIVOSDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OSDK.Location = point;
            this.label1OSDK.Name = "label1OSDK";
            this.label1OSDK.TabIndex = 1;
            this.label1OSDK.Tag = "labelOSDK";
            this.label1OSDK.Text = "OSDK:";
            this.label1OSDK.StyleSetName = "FieldUltraLabel";
            this.label1OSDK.AutoSize = true;
            this.label1OSDK.Anchor = AnchorStyles.Left;
            this.label1OSDK.Appearance.TextVAlign = VAlign.Middle;
            this.label1OSDK.Appearance.ForeColor = Color.Black;
            this.label1OSDK.BackColor = Color.Transparent;
            this.layoutManagerformOSDOKUMENT.Controls.Add(this.label1OSDK, 0, 2);
            this.layoutManagerformOSDOKUMENT.SetColumnSpan(this.label1OSDK, 1);
            this.layoutManagerformOSDOKUMENT.SetRowSpan(this.label1OSDK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OSDK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OSDK.MinimumSize = size;
            size = new System.Drawing.Size(0x36, 0x17);
            this.label1OSDK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOSDK.Location = point;
            this.labelOSDK.Name = "labelOSDK";
            this.labelOSDK.Tag = "OSDK";
            this.labelOSDK.TabIndex = 0;
            this.labelOSDK.Anchor = AnchorStyles.Left;
            this.labelOSDK.BackColor = Color.Transparent;
            this.labelOSDK.DataBindings.Add(new Binding("Text", this.bindingSourceOSDOKUMENT, "OSDK"));
            this.labelOSDK.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOSDOKUMENT.Controls.Add(this.labelOSDK, 1, 2);
            this.layoutManagerformOSDOKUMENT.SetColumnSpan(this.labelOSDK, 1);
            this.layoutManagerformOSDOKUMENT.SetRowSpan(this.labelOSDK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOSDK.Margin = padding;
            size = new System.Drawing.Size(0x128, 0x16);
            this.labelOSDK.MinimumSize = size;
            size = new System.Drawing.Size(0x128, 0x16);
            this.labelOSDK.Size = size;
            this.Controls.Add(this.layoutManagerformOSDOKUMENT);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceOSDOKUMENT;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "OSDOKUMENTFormUserControl";
            this.Text = "OSDOKUMENT";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OSDOKUMENTFormUserControl_Load);
            this.layoutManagerformOSDOKUMENT.ResumeLayout(false);
            this.layoutManagerformOSDOKUMENT.PerformLayout();
            ((ISupportInitialize) this.bindingSourceOSDOKUMENT).EndInit();
            ((ISupportInitialize) this.textIDOSDOKUMENT).EndInit();
            ((ISupportInitialize) this.textNAZIVOSDOKUMENT).EndInit();
            this.dsOSDOKUMENTDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OSDOKUMENTController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceOSDOKUMENT, this.OSDOKUMENTController.WorkItem, this))
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
            this.label1IDOSDOKUMENT.Text = StringResources.OSDOKUMENTIDOSDOKUMENTDescription;
            this.label1NAZIVOSDOKUMENT.Text = StringResources.OSDOKUMENTNAZIVOSDOKUMENTDescription;
            this.label1OSDK.Text = StringResources.OSDOKUMENTOSDKDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void OSDOKUMENTFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OSDOKUMENTDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.OSDOKUMENTController.WorkItem.Items.Contains("OSDOKUMENT|OSDOKUMENT"))
            {
                this.OSDOKUMENTController.WorkItem.Items.Add(this.bindingSourceOSDOKUMENT, "OSDOKUMENT|OSDOKUMENT");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsOSDOKUMENTDataSet1.OSDOKUMENT.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.OSDOKUMENTController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OSDOKUMENTController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OSDOKUMENTController.Update(this))
            {
                this.OSDOKUMENTController.DataSet = new OSDOKUMENTDataSet();
                DataSetUtil.AddEmptyRow(this.OSDOKUMENTController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.OSDOKUMENTController.DataSet.OSDOKUMENT[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDOSDOKUMENT.Focus();
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

        protected virtual UltraLabel label1IDOSDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOSDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOSDOKUMENT = value;
            }
        }

        protected virtual UltraLabel label1NAZIVOSDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVOSDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVOSDOKUMENT = value;
            }
        }

        protected virtual UltraLabel label1OSDK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OSDK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OSDK = value;
            }
        }

        protected virtual UltraLabel labelOSDK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOSDK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOSDK = value;
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
        public NetAdvantage.Controllers.OSDOKUMENTController OSDOKUMENTController { get; set; }

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

        protected virtual UltraNumericEditor textIDOSDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDOSDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDOSDOKUMENT = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVOSDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVOSDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVOSDOKUMENT = value;
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

