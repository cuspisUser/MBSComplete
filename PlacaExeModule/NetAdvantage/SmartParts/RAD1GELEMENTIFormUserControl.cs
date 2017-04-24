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
    public class RAD1GELEMENTIFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1RAD1GELEMENTIID")]
        private UltraLabel _label1RAD1GELEMENTIID;
        [AccessedThroughProperty("label1RAD1GELEMENTINAZIV")]
        private UltraLabel _label1RAD1GELEMENTINAZIV;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textRAD1GELEMENTIID")]
        private UltraNumericEditor _textRAD1GELEMENTIID;
        [AccessedThroughProperty("textRAD1GELEMENTINAZIV")]
        private UltraTextEditor _textRAD1GELEMENTINAZIV;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRAD1GELEMENTI;
        private IContainer components = null;
        private RAD1GELEMENTIDataSet dsRAD1GELEMENTIDataSet1;
        protected TableLayoutPanel layoutManagerformRAD1GELEMENTI;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RAD1GELEMENTIDataSet.RAD1GELEMENTIRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RAD1GELEMENTI";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.RAD1GELEMENTIDescription;
        private DeklaritMode m_Mode;

        public RAD1GELEMENTIFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceRAD1GELEMENTI.DataSource = this.RAD1GELEMENTIController.DataSet;
            this.dsRAD1GELEMENTIDataSet1 = this.RAD1GELEMENTIController.DataSet;
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
                    enumerator = this.dsRAD1GELEMENTIDataSet1.RAD1GELEMENTI.Rows.GetEnumerator();
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
                if (this.RAD1GELEMENTIController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RAD1GELEMENTI", this.m_Mode, this.dsRAD1GELEMENTIDataSet1, this.dsRAD1GELEMENTIDataSet1.RAD1GELEMENTI.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsRAD1GELEMENTIDataSet1.RAD1GELEMENTI[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RAD1GELEMENTIDataSet.RAD1GELEMENTIRow) ((DataRowView) this.bindingSourceRAD1GELEMENTI.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(RAD1GELEMENTIFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRAD1GELEMENTI = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRAD1GELEMENTI).BeginInit();
            this.layoutManagerformRAD1GELEMENTI = new TableLayoutPanel();
            this.layoutManagerformRAD1GELEMENTI.SuspendLayout();
            this.layoutManagerformRAD1GELEMENTI.AutoSize = true;
            this.layoutManagerformRAD1GELEMENTI.Dock = DockStyle.Fill;
            this.layoutManagerformRAD1GELEMENTI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRAD1GELEMENTI.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRAD1GELEMENTI.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRAD1GELEMENTI.Size = size;
            this.layoutManagerformRAD1GELEMENTI.ColumnCount = 2;
            this.layoutManagerformRAD1GELEMENTI.RowCount = 3;
            this.layoutManagerformRAD1GELEMENTI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1GELEMENTI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1GELEMENTI.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1GELEMENTI.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1GELEMENTI.RowStyles.Add(new RowStyle());
            this.label1RAD1GELEMENTIID = new UltraLabel();
            this.textRAD1GELEMENTIID = new UltraNumericEditor();
            this.label1RAD1GELEMENTINAZIV = new UltraLabel();
            this.textRAD1GELEMENTINAZIV = new UltraTextEditor();
            ((ISupportInitialize) this.textRAD1GELEMENTIID).BeginInit();
            ((ISupportInitialize) this.textRAD1GELEMENTINAZIV).BeginInit();
            this.dsRAD1GELEMENTIDataSet1 = new RAD1GELEMENTIDataSet();
            this.dsRAD1GELEMENTIDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRAD1GELEMENTIDataSet1.DataSetName = "dsRAD1GELEMENTI";
            this.dsRAD1GELEMENTIDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRAD1GELEMENTI.DataSource = this.dsRAD1GELEMENTIDataSet1;
            this.bindingSourceRAD1GELEMENTI.DataMember = "RAD1GELEMENTI";
            ((ISupportInitialize) this.bindingSourceRAD1GELEMENTI).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1RAD1GELEMENTIID.Location = point;
            this.label1RAD1GELEMENTIID.Name = "label1RAD1GELEMENTIID";
            this.label1RAD1GELEMENTIID.TabIndex = 1;
            this.label1RAD1GELEMENTIID.Tag = "labelRAD1GELEMENTIID";
            this.label1RAD1GELEMENTIID.Text = "RAD1 GELEMENTIID:";
            this.label1RAD1GELEMENTIID.StyleSetName = "FieldUltraLabel";
            this.label1RAD1GELEMENTIID.AutoSize = true;
            this.label1RAD1GELEMENTIID.Anchor = AnchorStyles.Left;
            this.label1RAD1GELEMENTIID.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAD1GELEMENTIID.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1RAD1GELEMENTIID.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1RAD1GELEMENTIID.ImageSize = size;
            this.label1RAD1GELEMENTIID.Appearance.ForeColor = Color.Black;
            this.label1RAD1GELEMENTIID.BackColor = Color.Transparent;
            this.layoutManagerformRAD1GELEMENTI.Controls.Add(this.label1RAD1GELEMENTIID, 0, 0);
            this.layoutManagerformRAD1GELEMENTI.SetColumnSpan(this.label1RAD1GELEMENTIID, 1);
            this.layoutManagerformRAD1GELEMENTI.SetRowSpan(this.label1RAD1GELEMENTIID, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1RAD1GELEMENTIID.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAD1GELEMENTIID.MinimumSize = size;
            size = new System.Drawing.Size(0x8f, 0x17);
            this.label1RAD1GELEMENTIID.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRAD1GELEMENTIID.Location = point;
            this.textRAD1GELEMENTIID.Name = "textRAD1GELEMENTIID";
            this.textRAD1GELEMENTIID.Tag = "RAD1GELEMENTIID";
            this.textRAD1GELEMENTIID.TabIndex = 0;
            this.textRAD1GELEMENTIID.Anchor = AnchorStyles.Left;
            this.textRAD1GELEMENTIID.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRAD1GELEMENTIID.ReadOnly = false;
            this.textRAD1GELEMENTIID.PromptChar = ' ';
            this.textRAD1GELEMENTIID.Enter += new EventHandler(this.numericEditor_Enter);
            this.textRAD1GELEMENTIID.DataBindings.Add(new Binding("Value", this.bindingSourceRAD1GELEMENTI, "RAD1GELEMENTIID"));
            this.textRAD1GELEMENTIID.NumericType = NumericType.Integer;
            this.textRAD1GELEMENTIID.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformRAD1GELEMENTI.Controls.Add(this.textRAD1GELEMENTIID, 1, 0);
            this.layoutManagerformRAD1GELEMENTI.SetColumnSpan(this.textRAD1GELEMENTIID, 1);
            this.layoutManagerformRAD1GELEMENTI.SetRowSpan(this.textRAD1GELEMENTIID, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRAD1GELEMENTIID.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textRAD1GELEMENTIID.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textRAD1GELEMENTIID.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RAD1GELEMENTINAZIV.Location = point;
            this.label1RAD1GELEMENTINAZIV.Name = "label1RAD1GELEMENTINAZIV";
            this.label1RAD1GELEMENTINAZIV.TabIndex = 1;
            this.label1RAD1GELEMENTINAZIV.Tag = "labelRAD1GELEMENTINAZIV";
            this.label1RAD1GELEMENTINAZIV.Text = "RAD1 GELEMENTINAZIV:";
            this.label1RAD1GELEMENTINAZIV.StyleSetName = "FieldUltraLabel";
            this.label1RAD1GELEMENTINAZIV.AutoSize = true;
            this.label1RAD1GELEMENTINAZIV.Anchor = AnchorStyles.Left;
            this.label1RAD1GELEMENTINAZIV.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAD1GELEMENTINAZIV.Appearance.ForeColor = Color.Black;
            this.label1RAD1GELEMENTINAZIV.BackColor = Color.Transparent;
            this.layoutManagerformRAD1GELEMENTI.Controls.Add(this.label1RAD1GELEMENTINAZIV, 0, 1);
            this.layoutManagerformRAD1GELEMENTI.SetColumnSpan(this.label1RAD1GELEMENTINAZIV, 1);
            this.layoutManagerformRAD1GELEMENTI.SetRowSpan(this.label1RAD1GELEMENTINAZIV, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RAD1GELEMENTINAZIV.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAD1GELEMENTINAZIV.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x17);
            this.label1RAD1GELEMENTINAZIV.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRAD1GELEMENTINAZIV.Location = point;
            this.textRAD1GELEMENTINAZIV.Name = "textRAD1GELEMENTINAZIV";
            this.textRAD1GELEMENTINAZIV.Tag = "RAD1GELEMENTINAZIV";
            this.textRAD1GELEMENTINAZIV.TabIndex = 0;
            this.textRAD1GELEMENTINAZIV.Anchor = AnchorStyles.Left;
            this.textRAD1GELEMENTINAZIV.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRAD1GELEMENTINAZIV.ReadOnly = false;
            this.textRAD1GELEMENTINAZIV.DataBindings.Add(new Binding("Text", this.bindingSourceRAD1GELEMENTI, "RAD1GELEMENTINAZIV"));
            this.textRAD1GELEMENTINAZIV.MaxLength = 30;
            this.layoutManagerformRAD1GELEMENTI.Controls.Add(this.textRAD1GELEMENTINAZIV, 1, 1);
            this.layoutManagerformRAD1GELEMENTI.SetColumnSpan(this.textRAD1GELEMENTINAZIV, 1);
            this.layoutManagerformRAD1GELEMENTI.SetRowSpan(this.textRAD1GELEMENTINAZIV, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRAD1GELEMENTINAZIV.Margin = padding;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textRAD1GELEMENTINAZIV.MinimumSize = size;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textRAD1GELEMENTINAZIV.Size = size;
            this.Controls.Add(this.layoutManagerformRAD1GELEMENTI);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRAD1GELEMENTI;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RAD1GELEMENTIFormUserControl";
            this.Text = "RAD1GELEMENTI";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RAD1GELEMENTIFormUserControl_Load);
            this.layoutManagerformRAD1GELEMENTI.ResumeLayout(false);
            this.layoutManagerformRAD1GELEMENTI.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRAD1GELEMENTI).EndInit();
            ((ISupportInitialize) this.textRAD1GELEMENTIID).EndInit();
            ((ISupportInitialize) this.textRAD1GELEMENTINAZIV).EndInit();
            this.dsRAD1GELEMENTIDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RAD1GELEMENTIController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRAD1GELEMENTI, this.RAD1GELEMENTIController.WorkItem, this))
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
            this.label1RAD1GELEMENTIID.Text = StringResources.RAD1GELEMENTIRAD1GELEMENTIIDDescription;
            this.label1RAD1GELEMENTINAZIV.Text = StringResources.RAD1GELEMENTIRAD1GELEMENTINAZIVDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewRAD1GELEMENTIVEZA")]
        public void NewRAD1GELEMENTIVEZAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RAD1GELEMENTIController.NewRAD1GELEMENTIVEZA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RAD1GELEMENTIFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RAD1GELEMENTIDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RAD1GELEMENTIController.WorkItem.Items.Contains("RAD1GELEMENTI|RAD1GELEMENTI"))
            {
                this.RAD1GELEMENTIController.WorkItem.Items.Add(this.bindingSourceRAD1GELEMENTI, "RAD1GELEMENTI|RAD1GELEMENTI");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsRAD1GELEMENTIDataSet1.RAD1GELEMENTI.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.RAD1GELEMENTIController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1GELEMENTIController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1GELEMENTIController.Update(this))
            {
                this.RAD1GELEMENTIController.DataSet = new RAD1GELEMENTIDataSet();
                DataSetUtil.AddEmptyRow(this.RAD1GELEMENTIController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.RAD1GELEMENTIController.DataSet.RAD1GELEMENTI[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textRAD1GELEMENTIID.Focus();
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

        [LocalCommandHandler("ViewRAD1GELEMENTIVEZA")]
        public void ViewRAD1GELEMENTIVEZAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RAD1GELEMENTIController.ViewRAD1GELEMENTIVEZA(this.m_CurrentRow);
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

        protected virtual UltraLabel label1RAD1GELEMENTIID
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAD1GELEMENTIID;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAD1GELEMENTIID = value;
            }
        }

        protected virtual UltraLabel label1RAD1GELEMENTINAZIV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAD1GELEMENTINAZIV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAD1GELEMENTINAZIV = value;
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
        public NetAdvantage.Controllers.RAD1GELEMENTIController RAD1GELEMENTIController { get; set; }

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

        protected virtual UltraNumericEditor textRAD1GELEMENTIID
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRAD1GELEMENTIID;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRAD1GELEMENTIID = value;
            }
        }

        protected virtual UltraTextEditor textRAD1GELEMENTINAZIV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRAD1GELEMENTINAZIV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRAD1GELEMENTINAZIV = value;
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

