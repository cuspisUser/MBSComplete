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
    public class DDVRSTEPOSLAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1DDIDVRSTAPOSLA")]
        private UltraLabel _label1DDIDVRSTAPOSLA;
        [AccessedThroughProperty("label1DDNAZIVVRSTAPOSLA")]
        private UltraLabel _label1DDNAZIVVRSTAPOSLA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textDDIDVRSTAPOSLA")]
        private UltraNumericEditor _textDDIDVRSTAPOSLA;
        [AccessedThroughProperty("textDDNAZIVVRSTAPOSLA")]
        private UltraTextEditor _textDDNAZIVVRSTAPOSLA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceDDVRSTEPOSLA;
        private IContainer components = null;
        private DDVRSTEPOSLADataSet dsDDVRSTEPOSLADataSet1;
        protected TableLayoutPanel layoutManagerformDDVRSTEPOSLA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private DDVRSTEPOSLADataSet.DDVRSTEPOSLARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "DDVRSTEPOSLA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.DDVRSTEPOSLADescription;
        private DeklaritMode m_Mode;

        public DDVRSTEPOSLAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceDDVRSTEPOSLA.DataSource = this.DDVRSTEPOSLAController.DataSet;
            this.dsDDVRSTEPOSLADataSet1 = this.DDVRSTEPOSLAController.DataSet;
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

        private void DDVRSTEPOSLAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.DDVRSTEPOSLADescription;
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
                    enumerator = this.dsDDVRSTEPOSLADataSet1.DDVRSTEPOSLA.Rows.GetEnumerator();
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
                if (this.DDVRSTEPOSLAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "DDVRSTEPOSLA", this.m_Mode, this.dsDDVRSTEPOSLADataSet1, this.dsDDVRSTEPOSLADataSet1.DDVRSTEPOSLA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsDDVRSTEPOSLADataSet1.DDVRSTEPOSLA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (DDVRSTEPOSLADataSet.DDVRSTEPOSLARow) ((DataRowView) this.bindingSourceDDVRSTEPOSLA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(DDVRSTEPOSLAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceDDVRSTEPOSLA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDDVRSTEPOSLA).BeginInit();
            this.layoutManagerformDDVRSTEPOSLA = new TableLayoutPanel();
            this.layoutManagerformDDVRSTEPOSLA.SuspendLayout();
            this.layoutManagerformDDVRSTEPOSLA.AutoSize = true;
            this.layoutManagerformDDVRSTEPOSLA.Dock = DockStyle.Fill;
            this.layoutManagerformDDVRSTEPOSLA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformDDVRSTEPOSLA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformDDVRSTEPOSLA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformDDVRSTEPOSLA.Size = size;
            this.layoutManagerformDDVRSTEPOSLA.ColumnCount = 2;
            this.layoutManagerformDDVRSTEPOSLA.RowCount = 3;
            this.layoutManagerformDDVRSTEPOSLA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDDVRSTEPOSLA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDDVRSTEPOSLA.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDVRSTEPOSLA.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDVRSTEPOSLA.RowStyles.Add(new RowStyle());
            this.label1DDIDVRSTAPOSLA = new UltraLabel();
            this.textDDIDVRSTAPOSLA = new UltraNumericEditor();
            this.label1DDNAZIVVRSTAPOSLA = new UltraLabel();
            this.textDDNAZIVVRSTAPOSLA = new UltraTextEditor();
            ((ISupportInitialize) this.textDDIDVRSTAPOSLA).BeginInit();
            ((ISupportInitialize) this.textDDNAZIVVRSTAPOSLA).BeginInit();
            this.dsDDVRSTEPOSLADataSet1 = new DDVRSTEPOSLADataSet();
            this.dsDDVRSTEPOSLADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsDDVRSTEPOSLADataSet1.DataSetName = "dsDDVRSTEPOSLA";
            this.dsDDVRSTEPOSLADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceDDVRSTEPOSLA.DataSource = this.dsDDVRSTEPOSLADataSet1;
            this.bindingSourceDDVRSTEPOSLA.DataMember = "DDVRSTEPOSLA";
            ((ISupportInitialize) this.bindingSourceDDVRSTEPOSLA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1DDIDVRSTAPOSLA.Location = point;
            this.label1DDIDVRSTAPOSLA.Name = "label1DDIDVRSTAPOSLA";
            this.label1DDIDVRSTAPOSLA.TabIndex = 1;
            this.label1DDIDVRSTAPOSLA.Tag = "labelDDIDVRSTAPOSLA";
            this.label1DDIDVRSTAPOSLA.Text = "Šifra:";
            this.label1DDIDVRSTAPOSLA.StyleSetName = "FieldUltraLabel";
            this.label1DDIDVRSTAPOSLA.AutoSize = true;
            this.label1DDIDVRSTAPOSLA.Anchor = AnchorStyles.Left;
            this.label1DDIDVRSTAPOSLA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDIDVRSTAPOSLA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1DDIDVRSTAPOSLA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1DDIDVRSTAPOSLA.ImageSize = size;
            this.label1DDIDVRSTAPOSLA.Appearance.ForeColor = Color.Black;
            this.label1DDIDVRSTAPOSLA.BackColor = Color.Transparent;
            this.layoutManagerformDDVRSTEPOSLA.Controls.Add(this.label1DDIDVRSTAPOSLA, 0, 0);
            this.layoutManagerformDDVRSTEPOSLA.SetColumnSpan(this.label1DDIDVRSTAPOSLA, 1);
            this.layoutManagerformDDVRSTEPOSLA.SetRowSpan(this.label1DDIDVRSTAPOSLA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1DDIDVRSTAPOSLA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDIDVRSTAPOSLA.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1DDIDVRSTAPOSLA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDIDVRSTAPOSLA.Location = point;
            this.textDDIDVRSTAPOSLA.Name = "textDDIDVRSTAPOSLA";
            this.textDDIDVRSTAPOSLA.Tag = "DDIDVRSTAPOSLA";
            this.textDDIDVRSTAPOSLA.TabIndex = 0;
            this.textDDIDVRSTAPOSLA.Anchor = AnchorStyles.Left;
            this.textDDIDVRSTAPOSLA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDIDVRSTAPOSLA.ReadOnly = false;
            this.textDDIDVRSTAPOSLA.PromptChar = ' ';
            this.textDDIDVRSTAPOSLA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textDDIDVRSTAPOSLA.DataBindings.Add(new Binding("Value", this.bindingSourceDDVRSTEPOSLA, "DDIDVRSTAPOSLA"));
            this.textDDIDVRSTAPOSLA.NumericType = NumericType.Integer;
            this.textDDIDVRSTAPOSLA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformDDVRSTEPOSLA.Controls.Add(this.textDDIDVRSTAPOSLA, 1, 0);
            this.layoutManagerformDDVRSTEPOSLA.SetColumnSpan(this.textDDIDVRSTAPOSLA, 1);
            this.layoutManagerformDDVRSTEPOSLA.SetRowSpan(this.textDDIDVRSTAPOSLA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDIDVRSTAPOSLA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textDDIDVRSTAPOSLA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textDDIDVRSTAPOSLA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDNAZIVVRSTAPOSLA.Location = point;
            this.label1DDNAZIVVRSTAPOSLA.Name = "label1DDNAZIVVRSTAPOSLA";
            this.label1DDNAZIVVRSTAPOSLA.TabIndex = 1;
            this.label1DDNAZIVVRSTAPOSLA.Tag = "labelDDNAZIVVRSTAPOSLA";
            this.label1DDNAZIVVRSTAPOSLA.Text = "Naziv:";
            this.label1DDNAZIVVRSTAPOSLA.StyleSetName = "FieldUltraLabel";
            this.label1DDNAZIVVRSTAPOSLA.AutoSize = true;
            this.label1DDNAZIVVRSTAPOSLA.Anchor = AnchorStyles.Left;
            this.label1DDNAZIVVRSTAPOSLA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDNAZIVVRSTAPOSLA.Appearance.ForeColor = Color.Black;
            this.label1DDNAZIVVRSTAPOSLA.BackColor = Color.Transparent;
            this.layoutManagerformDDVRSTEPOSLA.Controls.Add(this.label1DDNAZIVVRSTAPOSLA, 0, 1);
            this.layoutManagerformDDVRSTEPOSLA.SetColumnSpan(this.label1DDNAZIVVRSTAPOSLA, 1);
            this.layoutManagerformDDVRSTEPOSLA.SetRowSpan(this.label1DDNAZIVVRSTAPOSLA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDNAZIVVRSTAPOSLA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDNAZIVVRSTAPOSLA.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1DDNAZIVVRSTAPOSLA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDNAZIVVRSTAPOSLA.Location = point;
            this.textDDNAZIVVRSTAPOSLA.Name = "textDDNAZIVVRSTAPOSLA";
            this.textDDNAZIVVRSTAPOSLA.Tag = "DDNAZIVVRSTAPOSLA";
            this.textDDNAZIVVRSTAPOSLA.TabIndex = 0;
            this.textDDNAZIVVRSTAPOSLA.Anchor = AnchorStyles.Left;
            this.textDDNAZIVVRSTAPOSLA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDNAZIVVRSTAPOSLA.ReadOnly = false;
            this.textDDNAZIVVRSTAPOSLA.DataBindings.Add(new Binding("Text", this.bindingSourceDDVRSTEPOSLA, "DDNAZIVVRSTAPOSLA"));
            this.textDDNAZIVVRSTAPOSLA.MaxLength = 50;
            this.layoutManagerformDDVRSTEPOSLA.Controls.Add(this.textDDNAZIVVRSTAPOSLA, 1, 1);
            this.layoutManagerformDDVRSTEPOSLA.SetColumnSpan(this.textDDNAZIVVRSTAPOSLA, 1);
            this.layoutManagerformDDVRSTEPOSLA.SetRowSpan(this.textDDNAZIVVRSTAPOSLA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDNAZIVVRSTAPOSLA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textDDNAZIVVRSTAPOSLA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textDDNAZIVVRSTAPOSLA.Size = size;
            this.Controls.Add(this.layoutManagerformDDVRSTEPOSLA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceDDVRSTEPOSLA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "DDVRSTEPOSLAFormUserControl";
            this.Text = "Vrste posla";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.DDVRSTEPOSLAFormUserControl_Load);
            this.layoutManagerformDDVRSTEPOSLA.ResumeLayout(false);
            this.layoutManagerformDDVRSTEPOSLA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceDDVRSTEPOSLA).EndInit();
            ((ISupportInitialize) this.textDDIDVRSTAPOSLA).EndInit();
            ((ISupportInitialize) this.textDDNAZIVVRSTAPOSLA).EndInit();
            this.dsDDVRSTEPOSLADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.DDVRSTEPOSLAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceDDVRSTEPOSLA, this.DDVRSTEPOSLAController.WorkItem, this))
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
            this.label1DDIDVRSTAPOSLA.Text = StringResources.DDVRSTEPOSLADDIDVRSTAPOSLADescription;
            this.label1DDNAZIVVRSTAPOSLA.Text = StringResources.DDVRSTEPOSLADDNAZIVVRSTAPOSLADescription;
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
            if (!this.DDVRSTEPOSLAController.WorkItem.Items.Contains("DDVRSTEPOSLA|DDVRSTEPOSLA"))
            {
                this.DDVRSTEPOSLAController.WorkItem.Items.Add(this.bindingSourceDDVRSTEPOSLA, "DDVRSTEPOSLA|DDVRSTEPOSLA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsDDVRSTEPOSLADataSet1.DDVRSTEPOSLA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.DDVRSTEPOSLAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DDVRSTEPOSLAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DDVRSTEPOSLAController.Update(this))
            {
                this.DDVRSTEPOSLAController.DataSet = new DDVRSTEPOSLADataSet();
                DataSetUtil.AddEmptyRow(this.DDVRSTEPOSLAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.DDVRSTEPOSLAController.DataSet.DDVRSTEPOSLA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textDDIDVRSTAPOSLA.Focus();
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
        public NetAdvantage.Controllers.DDVRSTEPOSLAController DDVRSTEPOSLAController { get; set; }

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

        protected virtual UltraLabel label1DDIDVRSTAPOSLA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDIDVRSTAPOSLA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDIDVRSTAPOSLA = value;
            }
        }

        protected virtual UltraLabel label1DDNAZIVVRSTAPOSLA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDNAZIVVRSTAPOSLA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDNAZIVVRSTAPOSLA = value;
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

        protected virtual UltraNumericEditor textDDIDVRSTAPOSLA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDIDVRSTAPOSLA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDIDVRSTAPOSLA = value;
            }
        }

        protected virtual UltraTextEditor textDDNAZIVVRSTAPOSLA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDNAZIVVRSTAPOSLA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDNAZIVVRSTAPOSLA = value;
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

