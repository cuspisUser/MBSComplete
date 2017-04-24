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
    public class VERZIJAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDVERZIJA")]
        private UltraLabel _label1IDVERZIJA;
        [AccessedThroughProperty("label1VERZIJA")]
        private UltraLabel _label1VERZIJA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDVERZIJA")]
        private UltraNumericEditor _textIDVERZIJA;
        [AccessedThroughProperty("textVERZIJA")]
        private UltraTextEditor _textVERZIJA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceVERZIJA;
        private IContainer components = null;
        private VERZIJADataSet dsVERZIJADataSet1;
        protected TableLayoutPanel layoutManagerformVERZIJA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private VERZIJADataSet.VERZIJARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "VERZIJA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.VERZIJADescription;
        private DeklaritMode m_Mode;

        public VERZIJAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceVERZIJA.DataSource = this.VERZIJAController.DataSet;
            this.dsVERZIJADataSet1 = this.VERZIJAController.DataSet;
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
                    enumerator = this.dsVERZIJADataSet1.VERZIJA.Rows.GetEnumerator();
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
                if (this.VERZIJAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "VERZIJA", this.m_Mode, this.dsVERZIJADataSet1, this.dsVERZIJADataSet1.VERZIJA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsVERZIJADataSet1.VERZIJA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (VERZIJADataSet.VERZIJARow) ((DataRowView) this.bindingSourceVERZIJA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(VERZIJAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceVERZIJA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceVERZIJA).BeginInit();
            this.layoutManagerformVERZIJA = new TableLayoutPanel();
            this.layoutManagerformVERZIJA.SuspendLayout();
            this.layoutManagerformVERZIJA.AutoSize = true;
            this.layoutManagerformVERZIJA.Dock = DockStyle.Fill;
            this.layoutManagerformVERZIJA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformVERZIJA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformVERZIJA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformVERZIJA.Size = size;
            this.layoutManagerformVERZIJA.ColumnCount = 2;
            this.layoutManagerformVERZIJA.RowCount = 3;
            this.layoutManagerformVERZIJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVERZIJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVERZIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformVERZIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformVERZIJA.RowStyles.Add(new RowStyle());
            this.label1IDVERZIJA = new UltraLabel();
            this.textIDVERZIJA = new UltraNumericEditor();
            this.label1VERZIJA = new UltraLabel();
            this.textVERZIJA = new UltraTextEditor();
            ((ISupportInitialize) this.textIDVERZIJA).BeginInit();
            ((ISupportInitialize) this.textVERZIJA).BeginInit();
            this.dsVERZIJADataSet1 = new VERZIJADataSet();
            this.dsVERZIJADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsVERZIJADataSet1.DataSetName = "dsVERZIJA";
            this.dsVERZIJADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceVERZIJA.DataSource = this.dsVERZIJADataSet1;
            this.bindingSourceVERZIJA.DataMember = "VERZIJA";
            ((ISupportInitialize) this.bindingSourceVERZIJA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDVERZIJA.Location = point;
            this.label1IDVERZIJA.Name = "label1IDVERZIJA";
            this.label1IDVERZIJA.TabIndex = 1;
            this.label1IDVERZIJA.Tag = "labelIDVERZIJA";
            this.label1IDVERZIJA.Text = "IDVERZIJA:";
            this.label1IDVERZIJA.StyleSetName = "FieldUltraLabel";
            this.label1IDVERZIJA.AutoSize = true;
            this.label1IDVERZIJA.Anchor = AnchorStyles.Left;
            this.label1IDVERZIJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDVERZIJA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDVERZIJA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDVERZIJA.ImageSize = size;
            this.label1IDVERZIJA.Appearance.ForeColor = Color.Black;
            this.label1IDVERZIJA.BackColor = Color.Transparent;
            this.layoutManagerformVERZIJA.Controls.Add(this.label1IDVERZIJA, 0, 0);
            this.layoutManagerformVERZIJA.SetColumnSpan(this.label1IDVERZIJA, 1);
            this.layoutManagerformVERZIJA.SetRowSpan(this.label1IDVERZIJA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDVERZIJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDVERZIJA.MinimumSize = size;
            size = new System.Drawing.Size(0x55, 0x17);
            this.label1IDVERZIJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDVERZIJA.Location = point;
            this.textIDVERZIJA.Name = "textIDVERZIJA";
            this.textIDVERZIJA.Tag = "IDVERZIJA";
            this.textIDVERZIJA.TabIndex = 0;
            this.textIDVERZIJA.Anchor = AnchorStyles.Left;
            this.textIDVERZIJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDVERZIJA.ReadOnly = false;
            this.textIDVERZIJA.PromptChar = ' ';
            this.textIDVERZIJA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDVERZIJA.DataBindings.Add(new Binding("Value", this.bindingSourceVERZIJA, "IDVERZIJA"));
            this.textIDVERZIJA.NumericType = NumericType.Integer;
            this.textIDVERZIJA.MaskInput = "{LOC}-nn";
            this.layoutManagerformVERZIJA.Controls.Add(this.textIDVERZIJA, 1, 0);
            this.layoutManagerformVERZIJA.SetColumnSpan(this.textIDVERZIJA, 1);
            this.layoutManagerformVERZIJA.SetRowSpan(this.textIDVERZIJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDVERZIJA.Margin = padding;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.textIDVERZIJA.MinimumSize = size;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.textIDVERZIJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VERZIJA.Location = point;
            this.label1VERZIJA.Name = "label1VERZIJA";
            this.label1VERZIJA.TabIndex = 1;
            this.label1VERZIJA.Tag = "labelVERZIJA";
            this.label1VERZIJA.Text = "VERZIJA:";
            this.label1VERZIJA.StyleSetName = "FieldUltraLabel";
            this.label1VERZIJA.AutoSize = true;
            this.label1VERZIJA.Anchor = AnchorStyles.Left;
            this.label1VERZIJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1VERZIJA.Appearance.ForeColor = Color.Black;
            this.label1VERZIJA.BackColor = Color.Transparent;
            this.layoutManagerformVERZIJA.Controls.Add(this.label1VERZIJA, 0, 1);
            this.layoutManagerformVERZIJA.SetColumnSpan(this.label1VERZIJA, 1);
            this.layoutManagerformVERZIJA.SetRowSpan(this.label1VERZIJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VERZIJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VERZIJA.MinimumSize = size;
            size = new System.Drawing.Size(0x48, 0x17);
            this.label1VERZIJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textVERZIJA.Location = point;
            this.textVERZIJA.Name = "textVERZIJA";
            this.textVERZIJA.Tag = "VERZIJA";
            this.textVERZIJA.TabIndex = 0;
            this.textVERZIJA.Anchor = AnchorStyles.Left;
            this.textVERZIJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textVERZIJA.ReadOnly = false;
            this.textVERZIJA.DataBindings.Add(new Binding("Text", this.bindingSourceVERZIJA, "VERZIJA"));
            this.textVERZIJA.MaxLength = 20;
            this.layoutManagerformVERZIJA.Controls.Add(this.textVERZIJA, 1, 1);
            this.layoutManagerformVERZIJA.SetColumnSpan(this.textVERZIJA, 1);
            this.layoutManagerformVERZIJA.SetRowSpan(this.textVERZIJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textVERZIJA.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textVERZIJA.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textVERZIJA.Size = size;
            this.Controls.Add(this.layoutManagerformVERZIJA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceVERZIJA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "VERZIJAFormUserControl";
            this.Text = "VERZIJA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.VERZIJAFormUserControl_Load);
            this.layoutManagerformVERZIJA.ResumeLayout(false);
            this.layoutManagerformVERZIJA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceVERZIJA).EndInit();
            ((ISupportInitialize) this.textIDVERZIJA).EndInit();
            ((ISupportInitialize) this.textVERZIJA).EndInit();
            this.dsVERZIJADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.VERZIJAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceVERZIJA, this.VERZIJAController.WorkItem, this))
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
            this.label1IDVERZIJA.Text = StringResources.VERZIJAIDVERZIJADescription;
            this.label1VERZIJA.Text = StringResources.VERZIJAVERZIJADescription;
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
            if (!this.VERZIJAController.WorkItem.Items.Contains("VERZIJA|VERZIJA"))
            {
                this.VERZIJAController.WorkItem.Items.Add(this.bindingSourceVERZIJA, "VERZIJA|VERZIJA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsVERZIJADataSet1.VERZIJA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.VERZIJAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.VERZIJAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.VERZIJAController.Update(this))
            {
                this.VERZIJAController.DataSet = new VERZIJADataSet();
                DataSetUtil.AddEmptyRow(this.VERZIJAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.VERZIJAController.DataSet.VERZIJA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDVERZIJA.Focus();
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

        private void VERZIJAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.VERZIJADescription;
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

        protected virtual UltraLabel label1IDVERZIJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDVERZIJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDVERZIJA = value;
            }
        }

        protected virtual UltraLabel label1VERZIJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VERZIJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VERZIJA = value;
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

        protected virtual UltraNumericEditor textIDVERZIJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDVERZIJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDVERZIJA = value;
            }
        }

        protected virtual UltraTextEditor textVERZIJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textVERZIJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textVERZIJA = value;
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
        public NetAdvantage.Controllers.VERZIJAController VERZIJAController { get; set; }
    }
}

