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
    public class RAD1SPOLFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1RAD1SPOLID")]
        private UltraLabel _label1RAD1SPOLID;
        [AccessedThroughProperty("label1RAD1SPOLNAZIV")]
        private UltraLabel _label1RAD1SPOLNAZIV;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textRAD1SPOLID")]
        private UltraNumericEditor _textRAD1SPOLID;
        [AccessedThroughProperty("textRAD1SPOLNAZIV")]
        private UltraTextEditor _textRAD1SPOLNAZIV;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRAD1SPOL;
        private IContainer components = null;
        private RAD1SPOLDataSet dsRAD1SPOLDataSet1;
        protected TableLayoutPanel layoutManagerformRAD1SPOL;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RAD1SPOLDataSet.RAD1SPOLRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RAD1SPOL";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.RAD1SPOLDescription;
        private DeklaritMode m_Mode;

        public RAD1SPOLFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceRAD1SPOL.DataSource = this.RAD1SPOLController.DataSet;
            this.dsRAD1SPOLDataSet1 = this.RAD1SPOLController.DataSet;
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
                    enumerator = this.dsRAD1SPOLDataSet1.RAD1SPOL.Rows.GetEnumerator();
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
                if (this.RAD1SPOLController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RAD1SPOL", this.m_Mode, this.dsRAD1SPOLDataSet1, this.dsRAD1SPOLDataSet1.RAD1SPOL.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsRAD1SPOLDataSet1.RAD1SPOL[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RAD1SPOLDataSet.RAD1SPOLRow) ((DataRowView) this.bindingSourceRAD1SPOL.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(RAD1SPOLFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRAD1SPOL = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRAD1SPOL).BeginInit();
            this.layoutManagerformRAD1SPOL = new TableLayoutPanel();
            this.layoutManagerformRAD1SPOL.SuspendLayout();
            this.layoutManagerformRAD1SPOL.AutoSize = true;
            this.layoutManagerformRAD1SPOL.Dock = DockStyle.Fill;
            this.layoutManagerformRAD1SPOL.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRAD1SPOL.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRAD1SPOL.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRAD1SPOL.Size = size;
            this.layoutManagerformRAD1SPOL.ColumnCount = 2;
            this.layoutManagerformRAD1SPOL.RowCount = 3;
            this.layoutManagerformRAD1SPOL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1SPOL.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1SPOL.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1SPOL.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1SPOL.RowStyles.Add(new RowStyle());
            this.label1RAD1SPOLID = new UltraLabel();
            this.textRAD1SPOLID = new UltraNumericEditor();
            this.label1RAD1SPOLNAZIV = new UltraLabel();
            this.textRAD1SPOLNAZIV = new UltraTextEditor();
            ((ISupportInitialize) this.textRAD1SPOLID).BeginInit();
            ((ISupportInitialize) this.textRAD1SPOLNAZIV).BeginInit();
            this.dsRAD1SPOLDataSet1 = new RAD1SPOLDataSet();
            this.dsRAD1SPOLDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRAD1SPOLDataSet1.DataSetName = "dsRAD1SPOL";
            this.dsRAD1SPOLDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRAD1SPOL.DataSource = this.dsRAD1SPOLDataSet1;
            this.bindingSourceRAD1SPOL.DataMember = "RAD1SPOL";
            ((ISupportInitialize) this.bindingSourceRAD1SPOL).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1RAD1SPOLID.Location = point;
            this.label1RAD1SPOLID.Name = "label1RAD1SPOLID";
            this.label1RAD1SPOLID.TabIndex = 1;
            this.label1RAD1SPOLID.Tag = "labelRAD1SPOLID";
            this.label1RAD1SPOLID.Text = "RAD1 SPOLID:";
            this.label1RAD1SPOLID.StyleSetName = "FieldUltraLabel";
            this.label1RAD1SPOLID.AutoSize = true;
            this.label1RAD1SPOLID.Anchor = AnchorStyles.Left;
            this.label1RAD1SPOLID.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAD1SPOLID.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1RAD1SPOLID.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1RAD1SPOLID.ImageSize = size;
            this.label1RAD1SPOLID.Appearance.ForeColor = Color.Black;
            this.label1RAD1SPOLID.BackColor = Color.Transparent;
            this.layoutManagerformRAD1SPOL.Controls.Add(this.label1RAD1SPOLID, 0, 0);
            this.layoutManagerformRAD1SPOL.SetColumnSpan(this.label1RAD1SPOLID, 1);
            this.layoutManagerformRAD1SPOL.SetRowSpan(this.label1RAD1SPOLID, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1RAD1SPOLID.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAD1SPOLID.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x17);
            this.label1RAD1SPOLID.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRAD1SPOLID.Location = point;
            this.textRAD1SPOLID.Name = "textRAD1SPOLID";
            this.textRAD1SPOLID.Tag = "RAD1SPOLID";
            this.textRAD1SPOLID.TabIndex = 0;
            this.textRAD1SPOLID.Anchor = AnchorStyles.Left;
            this.textRAD1SPOLID.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRAD1SPOLID.ReadOnly = false;
            this.textRAD1SPOLID.PromptChar = ' ';
            this.textRAD1SPOLID.Enter += new EventHandler(this.numericEditor_Enter);
            this.textRAD1SPOLID.DataBindings.Add(new Binding("Value", this.bindingSourceRAD1SPOL, "RAD1SPOLID"));
            this.textRAD1SPOLID.NumericType = NumericType.Integer;
            this.textRAD1SPOLID.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformRAD1SPOL.Controls.Add(this.textRAD1SPOLID, 1, 0);
            this.layoutManagerformRAD1SPOL.SetColumnSpan(this.textRAD1SPOLID, 1);
            this.layoutManagerformRAD1SPOL.SetRowSpan(this.textRAD1SPOLID, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRAD1SPOLID.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textRAD1SPOLID.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textRAD1SPOLID.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RAD1SPOLNAZIV.Location = point;
            this.label1RAD1SPOLNAZIV.Name = "label1RAD1SPOLNAZIV";
            this.label1RAD1SPOLNAZIV.TabIndex = 1;
            this.label1RAD1SPOLNAZIV.Tag = "labelRAD1SPOLNAZIV";
            this.label1RAD1SPOLNAZIV.Text = "RAD1 SPOLNAZIV:";
            this.label1RAD1SPOLNAZIV.StyleSetName = "FieldUltraLabel";
            this.label1RAD1SPOLNAZIV.AutoSize = true;
            this.label1RAD1SPOLNAZIV.Anchor = AnchorStyles.Left;
            this.label1RAD1SPOLNAZIV.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAD1SPOLNAZIV.Appearance.ForeColor = Color.Black;
            this.label1RAD1SPOLNAZIV.BackColor = Color.Transparent;
            this.layoutManagerformRAD1SPOL.Controls.Add(this.label1RAD1SPOLNAZIV, 0, 1);
            this.layoutManagerformRAD1SPOL.SetColumnSpan(this.label1RAD1SPOLNAZIV, 1);
            this.layoutManagerformRAD1SPOL.SetRowSpan(this.label1RAD1SPOLNAZIV, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RAD1SPOLNAZIV.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAD1SPOLNAZIV.MinimumSize = size;
            size = new System.Drawing.Size(130, 0x17);
            this.label1RAD1SPOLNAZIV.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRAD1SPOLNAZIV.Location = point;
            this.textRAD1SPOLNAZIV.Name = "textRAD1SPOLNAZIV";
            this.textRAD1SPOLNAZIV.Tag = "RAD1SPOLNAZIV";
            this.textRAD1SPOLNAZIV.TabIndex = 0;
            this.textRAD1SPOLNAZIV.Anchor = AnchorStyles.Left;
            this.textRAD1SPOLNAZIV.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRAD1SPOLNAZIV.ReadOnly = false;
            this.textRAD1SPOLNAZIV.DataBindings.Add(new Binding("Text", this.bindingSourceRAD1SPOL, "RAD1SPOLNAZIV"));
            this.textRAD1SPOLNAZIV.MaxLength = 20;
            this.layoutManagerformRAD1SPOL.Controls.Add(this.textRAD1SPOLNAZIV, 1, 1);
            this.layoutManagerformRAD1SPOL.SetColumnSpan(this.textRAD1SPOLNAZIV, 1);
            this.layoutManagerformRAD1SPOL.SetRowSpan(this.textRAD1SPOLNAZIV, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRAD1SPOLNAZIV.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textRAD1SPOLNAZIV.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textRAD1SPOLNAZIV.Size = size;
            this.Controls.Add(this.layoutManagerformRAD1SPOL);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRAD1SPOL;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RAD1SPOLFormUserControl";
            this.Text = "RAD1SPOL";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RAD1SPOLFormUserControl_Load);
            this.layoutManagerformRAD1SPOL.ResumeLayout(false);
            this.layoutManagerformRAD1SPOL.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRAD1SPOL).EndInit();
            ((ISupportInitialize) this.textRAD1SPOLID).EndInit();
            ((ISupportInitialize) this.textRAD1SPOLNAZIV).EndInit();
            this.dsRAD1SPOLDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RAD1SPOLController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRAD1SPOL, this.RAD1SPOLController.WorkItem, this))
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
            this.label1RAD1SPOLID.Text = StringResources.RAD1SPOLRAD1SPOLIDDescription;
            this.label1RAD1SPOLNAZIV.Text = StringResources.RAD1SPOLRAD1SPOLNAZIVDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewRAD1VEZASPOL")]
        public void NewRAD1VEZASPOLHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RAD1SPOLController.NewRAD1VEZASPOL(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RAD1SPOLFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RAD1SPOLDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RAD1SPOLController.WorkItem.Items.Contains("RAD1SPOL|RAD1SPOL"))
            {
                this.RAD1SPOLController.WorkItem.Items.Add(this.bindingSourceRAD1SPOL, "RAD1SPOL|RAD1SPOL");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsRAD1SPOLDataSet1.RAD1SPOL.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.RAD1SPOLController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1SPOLController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1SPOLController.Update(this))
            {
                this.RAD1SPOLController.DataSet = new RAD1SPOLDataSet();
                DataSetUtil.AddEmptyRow(this.RAD1SPOLController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.RAD1SPOLController.DataSet.RAD1SPOL[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textRAD1SPOLID.Focus();
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

        [LocalCommandHandler("ViewRAD1VEZASPOL")]
        public void ViewRAD1VEZASPOLHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RAD1SPOLController.ViewRAD1VEZASPOL(this.m_CurrentRow);
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

        protected virtual UltraLabel label1RAD1SPOLID
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAD1SPOLID;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAD1SPOLID = value;
            }
        }

        protected virtual UltraLabel label1RAD1SPOLNAZIV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAD1SPOLNAZIV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAD1SPOLNAZIV = value;
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
        public NetAdvantage.Controllers.RAD1SPOLController RAD1SPOLController { get; set; }

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

        protected virtual UltraNumericEditor textRAD1SPOLID
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRAD1SPOLID;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRAD1SPOLID = value;
            }
        }

        protected virtual UltraTextEditor textRAD1SPOLNAZIV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRAD1SPOLNAZIV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRAD1SPOLNAZIV = value;
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

