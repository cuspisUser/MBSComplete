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
    public class RAD1MELEMENTIFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1RAD1ELEMENTIID")]
        private UltraLabel _label1RAD1ELEMENTIID;
        [AccessedThroughProperty("label1RAD1ELEMENTINAZIV")]
        private UltraLabel _label1RAD1ELEMENTINAZIV;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textRAD1ELEMENTIID")]
        private UltraNumericEditor _textRAD1ELEMENTIID;
        [AccessedThroughProperty("textRAD1ELEMENTINAZIV")]
        private UltraTextEditor _textRAD1ELEMENTINAZIV;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRAD1MELEMENTI;
        private IContainer components = null;
        private RAD1MELEMENTIDataSet dsRAD1MELEMENTIDataSet1;
        protected TableLayoutPanel layoutManagerformRAD1MELEMENTI;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RAD1MELEMENTIDataSet.RAD1MELEMENTIRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RAD1MELEMENTI";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.RAD1MELEMENTIDescription;
        private DeklaritMode m_Mode;

        public RAD1MELEMENTIFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceRAD1MELEMENTI.DataSource = this.RAD1MELEMENTIController.DataSet;
            this.dsRAD1MELEMENTIDataSet1 = this.RAD1MELEMENTIController.DataSet;
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
                    enumerator = this.dsRAD1MELEMENTIDataSet1.RAD1MELEMENTI.Rows.GetEnumerator();
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
                if (this.RAD1MELEMENTIController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RAD1MELEMENTI", this.m_Mode, this.dsRAD1MELEMENTIDataSet1, this.dsRAD1MELEMENTIDataSet1.RAD1MELEMENTI.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsRAD1MELEMENTIDataSet1.RAD1MELEMENTI[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RAD1MELEMENTIDataSet.RAD1MELEMENTIRow) ((DataRowView) this.bindingSourceRAD1MELEMENTI.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(RAD1MELEMENTIFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRAD1MELEMENTI = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRAD1MELEMENTI).BeginInit();
            this.layoutManagerformRAD1MELEMENTI = new TableLayoutPanel();
            this.layoutManagerformRAD1MELEMENTI.SuspendLayout();
            this.layoutManagerformRAD1MELEMENTI.AutoSize = true;
            this.layoutManagerformRAD1MELEMENTI.Dock = DockStyle.Fill;
            this.layoutManagerformRAD1MELEMENTI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRAD1MELEMENTI.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRAD1MELEMENTI.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRAD1MELEMENTI.Size = size;
            this.layoutManagerformRAD1MELEMENTI.ColumnCount = 2;
            this.layoutManagerformRAD1MELEMENTI.RowCount = 3;
            this.layoutManagerformRAD1MELEMENTI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1MELEMENTI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRAD1MELEMENTI.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1MELEMENTI.RowStyles.Add(new RowStyle());
            this.layoutManagerformRAD1MELEMENTI.RowStyles.Add(new RowStyle());
            this.label1RAD1ELEMENTIID = new UltraLabel();
            this.textRAD1ELEMENTIID = new UltraNumericEditor();
            this.label1RAD1ELEMENTINAZIV = new UltraLabel();
            this.textRAD1ELEMENTINAZIV = new UltraTextEditor();
            ((ISupportInitialize) this.textRAD1ELEMENTIID).BeginInit();
            ((ISupportInitialize) this.textRAD1ELEMENTINAZIV).BeginInit();
            this.dsRAD1MELEMENTIDataSet1 = new RAD1MELEMENTIDataSet();
            this.dsRAD1MELEMENTIDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRAD1MELEMENTIDataSet1.DataSetName = "dsRAD1MELEMENTI";
            this.dsRAD1MELEMENTIDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRAD1MELEMENTI.DataSource = this.dsRAD1MELEMENTIDataSet1;
            this.bindingSourceRAD1MELEMENTI.DataMember = "RAD1MELEMENTI";
            ((ISupportInitialize) this.bindingSourceRAD1MELEMENTI).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1RAD1ELEMENTIID.Location = point;
            this.label1RAD1ELEMENTIID.Name = "label1RAD1ELEMENTIID";
            this.label1RAD1ELEMENTIID.TabIndex = 1;
            this.label1RAD1ELEMENTIID.Tag = "labelRAD1ELEMENTIID";
            this.label1RAD1ELEMENTIID.Text = "RAD1 ELEMENTIID:";
            this.label1RAD1ELEMENTIID.StyleSetName = "FieldUltraLabel";
            this.label1RAD1ELEMENTIID.AutoSize = true;
            this.label1RAD1ELEMENTIID.Anchor = AnchorStyles.Left;
            this.label1RAD1ELEMENTIID.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAD1ELEMENTIID.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1RAD1ELEMENTIID.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1RAD1ELEMENTIID.ImageSize = size;
            this.label1RAD1ELEMENTIID.Appearance.ForeColor = Color.Black;
            this.label1RAD1ELEMENTIID.BackColor = Color.Transparent;
            this.layoutManagerformRAD1MELEMENTI.Controls.Add(this.label1RAD1ELEMENTIID, 0, 0);
            this.layoutManagerformRAD1MELEMENTI.SetColumnSpan(this.label1RAD1ELEMENTIID, 1);
            this.layoutManagerformRAD1MELEMENTI.SetRowSpan(this.label1RAD1ELEMENTIID, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1RAD1ELEMENTIID.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAD1ELEMENTIID.MinimumSize = size;
            size = new System.Drawing.Size(0x86, 0x17);
            this.label1RAD1ELEMENTIID.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRAD1ELEMENTIID.Location = point;
            this.textRAD1ELEMENTIID.Name = "textRAD1ELEMENTIID";
            this.textRAD1ELEMENTIID.Tag = "RAD1ELEMENTIID";
            this.textRAD1ELEMENTIID.TabIndex = 0;
            this.textRAD1ELEMENTIID.Anchor = AnchorStyles.Left;
            this.textRAD1ELEMENTIID.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRAD1ELEMENTIID.ReadOnly = false;
            this.textRAD1ELEMENTIID.PromptChar = ' ';
            this.textRAD1ELEMENTIID.Enter += new EventHandler(this.numericEditor_Enter);
            this.textRAD1ELEMENTIID.DataBindings.Add(new Binding("Value", this.bindingSourceRAD1MELEMENTI, "RAD1ELEMENTIID"));
            this.textRAD1ELEMENTIID.NumericType = NumericType.Integer;
            this.textRAD1ELEMENTIID.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformRAD1MELEMENTI.Controls.Add(this.textRAD1ELEMENTIID, 1, 0);
            this.layoutManagerformRAD1MELEMENTI.SetColumnSpan(this.textRAD1ELEMENTIID, 1);
            this.layoutManagerformRAD1MELEMENTI.SetRowSpan(this.textRAD1ELEMENTIID, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRAD1ELEMENTIID.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textRAD1ELEMENTIID.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textRAD1ELEMENTIID.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RAD1ELEMENTINAZIV.Location = point;
            this.label1RAD1ELEMENTINAZIV.Name = "label1RAD1ELEMENTINAZIV";
            this.label1RAD1ELEMENTINAZIV.TabIndex = 1;
            this.label1RAD1ELEMENTINAZIV.Tag = "labelRAD1ELEMENTINAZIV";
            this.label1RAD1ELEMENTINAZIV.Text = "RAD1 ELEMENTINAZIV:";
            this.label1RAD1ELEMENTINAZIV.StyleSetName = "FieldUltraLabel";
            this.label1RAD1ELEMENTINAZIV.AutoSize = true;
            this.label1RAD1ELEMENTINAZIV.Anchor = AnchorStyles.Left;
            this.label1RAD1ELEMENTINAZIV.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAD1ELEMENTINAZIV.Appearance.ForeColor = Color.Black;
            this.label1RAD1ELEMENTINAZIV.BackColor = Color.Transparent;
            this.layoutManagerformRAD1MELEMENTI.Controls.Add(this.label1RAD1ELEMENTINAZIV, 0, 1);
            this.layoutManagerformRAD1MELEMENTI.SetColumnSpan(this.label1RAD1ELEMENTINAZIV, 1);
            this.layoutManagerformRAD1MELEMENTI.SetRowSpan(this.label1RAD1ELEMENTINAZIV, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RAD1ELEMENTINAZIV.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAD1ELEMENTINAZIV.MinimumSize = size;
            size = new System.Drawing.Size(0xa1, 0x17);
            this.label1RAD1ELEMENTINAZIV.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRAD1ELEMENTINAZIV.Location = point;
            this.textRAD1ELEMENTINAZIV.Name = "textRAD1ELEMENTINAZIV";
            this.textRAD1ELEMENTINAZIV.Tag = "RAD1ELEMENTINAZIV";
            this.textRAD1ELEMENTINAZIV.TabIndex = 0;
            this.textRAD1ELEMENTINAZIV.Anchor = AnchorStyles.Left;
            this.textRAD1ELEMENTINAZIV.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRAD1ELEMENTINAZIV.ReadOnly = false;
            this.textRAD1ELEMENTINAZIV.DataBindings.Add(new Binding("Text", this.bindingSourceRAD1MELEMENTI, "RAD1ELEMENTINAZIV"));
            this.textRAD1ELEMENTINAZIV.MaxLength = 50;
            this.layoutManagerformRAD1MELEMENTI.Controls.Add(this.textRAD1ELEMENTINAZIV, 1, 1);
            this.layoutManagerformRAD1MELEMENTI.SetColumnSpan(this.textRAD1ELEMENTINAZIV, 1);
            this.layoutManagerformRAD1MELEMENTI.SetRowSpan(this.textRAD1ELEMENTINAZIV, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRAD1ELEMENTINAZIV.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textRAD1ELEMENTINAZIV.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textRAD1ELEMENTINAZIV.Size = size;
            this.Controls.Add(this.layoutManagerformRAD1MELEMENTI);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRAD1MELEMENTI;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RAD1MELEMENTIFormUserControl";
            this.Text = "RAD1MELEMENTI";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RAD1MELEMENTIFormUserControl_Load);
            this.layoutManagerformRAD1MELEMENTI.ResumeLayout(false);
            this.layoutManagerformRAD1MELEMENTI.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRAD1MELEMENTI).EndInit();
            ((ISupportInitialize) this.textRAD1ELEMENTIID).EndInit();
            ((ISupportInitialize) this.textRAD1ELEMENTINAZIV).EndInit();
            this.dsRAD1MELEMENTIDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RAD1MELEMENTIController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRAD1MELEMENTI, this.RAD1MELEMENTIController.WorkItem, this))
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
            this.label1RAD1ELEMENTIID.Text = StringResources.RAD1MELEMENTIRAD1ELEMENTIIDDescription;
            this.label1RAD1ELEMENTINAZIV.Text = StringResources.RAD1MELEMENTIRAD1ELEMENTINAZIVDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewRAD1MELEMENTIVEZA")]
        public void NewRAD1MELEMENTIVEZAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RAD1MELEMENTIController.NewRAD1MELEMENTIVEZA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RAD1MELEMENTIFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RAD1MELEMENTIDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RAD1MELEMENTIController.WorkItem.Items.Contains("RAD1MELEMENTI|RAD1MELEMENTI"))
            {
                this.RAD1MELEMENTIController.WorkItem.Items.Add(this.bindingSourceRAD1MELEMENTI, "RAD1MELEMENTI|RAD1MELEMENTI");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsRAD1MELEMENTIDataSet1.RAD1MELEMENTI.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.RAD1MELEMENTIController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1MELEMENTIController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RAD1MELEMENTIController.Update(this))
            {
                this.RAD1MELEMENTIController.DataSet = new RAD1MELEMENTIDataSet();
                DataSetUtil.AddEmptyRow(this.RAD1MELEMENTIController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.RAD1MELEMENTIController.DataSet.RAD1MELEMENTI[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textRAD1ELEMENTIID.Focus();
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

        [LocalCommandHandler("ViewRAD1MELEMENTIVEZA")]
        public void ViewRAD1MELEMENTIVEZAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RAD1MELEMENTIController.ViewRAD1MELEMENTIVEZA(this.m_CurrentRow);
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

        protected virtual UltraLabel label1RAD1ELEMENTIID
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAD1ELEMENTIID;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAD1ELEMENTIID = value;
            }
        }

        protected virtual UltraLabel label1RAD1ELEMENTINAZIV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAD1ELEMENTINAZIV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAD1ELEMENTINAZIV = value;
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
        public NetAdvantage.Controllers.RAD1MELEMENTIController RAD1MELEMENTIController { get; set; }

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

        protected virtual UltraNumericEditor textRAD1ELEMENTIID
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRAD1ELEMENTIID;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRAD1ELEMENTIID = value;
            }
        }

        protected virtual UltraTextEditor textRAD1ELEMENTINAZIV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRAD1ELEMENTINAZIV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRAD1ELEMENTINAZIV = value;
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

