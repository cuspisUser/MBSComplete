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
    public class JEDINICAMJEREFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDJEDINICAMJERE")]
        private UltraLabel _label1IDJEDINICAMJERE;
        [AccessedThroughProperty("label1NAZIVJEDINICAMJERE")]
        private UltraLabel _label1NAZIVJEDINICAMJERE;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDJEDINICAMJERE")]
        private UltraNumericEditor _textIDJEDINICAMJERE;
        [AccessedThroughProperty("textNAZIVJEDINICAMJERE")]
        private UltraTextEditor _textNAZIVJEDINICAMJERE;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceJEDINICAMJERE;
        private IContainer components = null;
        private JEDINICAMJEREDataSet dsJEDINICAMJEREDataSet1;
        protected TableLayoutPanel layoutManagerformJEDINICAMJERE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private JEDINICAMJEREDataSet.JEDINICAMJERERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "JEDINICAMJERE";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.JEDINICAMJEREDescription;
        private DeklaritMode m_Mode;

        public JEDINICAMJEREFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceJEDINICAMJERE.DataSource = this.JEDINICAMJEREController.DataSet;
            this.dsJEDINICAMJEREDataSet1 = this.JEDINICAMJEREController.DataSet;
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
                    enumerator = this.dsJEDINICAMJEREDataSet1.JEDINICAMJERE.Rows.GetEnumerator();
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
                if (this.JEDINICAMJEREController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "JEDINICAMJERE", this.m_Mode, this.dsJEDINICAMJEREDataSet1, this.dsJEDINICAMJEREDataSet1.JEDINICAMJERE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsJEDINICAMJEREDataSet1.JEDINICAMJERE[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (JEDINICAMJEREDataSet.JEDINICAMJERERow) ((DataRowView) this.bindingSourceJEDINICAMJERE.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(JEDINICAMJEREFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceJEDINICAMJERE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceJEDINICAMJERE).BeginInit();
            this.layoutManagerformJEDINICAMJERE = new TableLayoutPanel();
            this.layoutManagerformJEDINICAMJERE.SuspendLayout();
            this.layoutManagerformJEDINICAMJERE.AutoSize = true;
            this.layoutManagerformJEDINICAMJERE.Dock = DockStyle.Fill;
            this.layoutManagerformJEDINICAMJERE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformJEDINICAMJERE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformJEDINICAMJERE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformJEDINICAMJERE.Size = size;
            this.layoutManagerformJEDINICAMJERE.ColumnCount = 2;
            this.layoutManagerformJEDINICAMJERE.RowCount = 3;
            this.layoutManagerformJEDINICAMJERE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformJEDINICAMJERE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformJEDINICAMJERE.RowStyles.Add(new RowStyle());
            this.layoutManagerformJEDINICAMJERE.RowStyles.Add(new RowStyle());
            this.layoutManagerformJEDINICAMJERE.RowStyles.Add(new RowStyle());
            this.label1IDJEDINICAMJERE = new UltraLabel();
            this.textIDJEDINICAMJERE = new UltraNumericEditor();
            this.label1NAZIVJEDINICAMJERE = new UltraLabel();
            this.textNAZIVJEDINICAMJERE = new UltraTextEditor();
            ((ISupportInitialize) this.textIDJEDINICAMJERE).BeginInit();
            ((ISupportInitialize) this.textNAZIVJEDINICAMJERE).BeginInit();
            this.dsJEDINICAMJEREDataSet1 = new JEDINICAMJEREDataSet();
            this.dsJEDINICAMJEREDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsJEDINICAMJEREDataSet1.DataSetName = "dsJEDINICAMJERE";
            this.dsJEDINICAMJEREDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceJEDINICAMJERE.DataSource = this.dsJEDINICAMJEREDataSet1;
            this.bindingSourceJEDINICAMJERE.DataMember = "JEDINICAMJERE";
            ((ISupportInitialize) this.bindingSourceJEDINICAMJERE).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDJEDINICAMJERE.Location = point;
            this.label1IDJEDINICAMJERE.Name = "label1IDJEDINICAMJERE";
            this.label1IDJEDINICAMJERE.TabIndex = 1;
            this.label1IDJEDINICAMJERE.Tag = "labelIDJEDINICAMJERE";
            this.label1IDJEDINICAMJERE.Text = "Šifra JM:";
            this.label1IDJEDINICAMJERE.StyleSetName = "FieldUltraLabel";
            this.label1IDJEDINICAMJERE.AutoSize = true;
            this.label1IDJEDINICAMJERE.Anchor = AnchorStyles.Left;
            this.label1IDJEDINICAMJERE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDJEDINICAMJERE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDJEDINICAMJERE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDJEDINICAMJERE.ImageSize = size;
            this.label1IDJEDINICAMJERE.Appearance.ForeColor = Color.Black;
            this.label1IDJEDINICAMJERE.BackColor = Color.Transparent;
            this.layoutManagerformJEDINICAMJERE.Controls.Add(this.label1IDJEDINICAMJERE, 0, 0);
            this.layoutManagerformJEDINICAMJERE.SetColumnSpan(this.label1IDJEDINICAMJERE, 1);
            this.layoutManagerformJEDINICAMJERE.SetRowSpan(this.label1IDJEDINICAMJERE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDJEDINICAMJERE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDJEDINICAMJERE.MinimumSize = size;
            size = new System.Drawing.Size(0x42, 0x17);
            this.label1IDJEDINICAMJERE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDJEDINICAMJERE.Location = point;
            this.textIDJEDINICAMJERE.Name = "textIDJEDINICAMJERE";
            this.textIDJEDINICAMJERE.Tag = "IDJEDINICAMJERE";
            this.textIDJEDINICAMJERE.TabIndex = 0;
            this.textIDJEDINICAMJERE.Anchor = AnchorStyles.Left;
            this.textIDJEDINICAMJERE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDJEDINICAMJERE.ReadOnly = false;
            this.textIDJEDINICAMJERE.PromptChar = ' ';
            this.textIDJEDINICAMJERE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDJEDINICAMJERE.DataBindings.Add(new Binding("Value", this.bindingSourceJEDINICAMJERE, "IDJEDINICAMJERE"));
            this.textIDJEDINICAMJERE.NumericType = NumericType.Integer;
            this.textIDJEDINICAMJERE.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformJEDINICAMJERE.Controls.Add(this.textIDJEDINICAMJERE, 1, 0);
            this.layoutManagerformJEDINICAMJERE.SetColumnSpan(this.textIDJEDINICAMJERE, 1);
            this.layoutManagerformJEDINICAMJERE.SetRowSpan(this.textIDJEDINICAMJERE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDJEDINICAMJERE.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDJEDINICAMJERE.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDJEDINICAMJERE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVJEDINICAMJERE.Location = point;
            this.label1NAZIVJEDINICAMJERE.Name = "label1NAZIVJEDINICAMJERE";
            this.label1NAZIVJEDINICAMJERE.TabIndex = 1;
            this.label1NAZIVJEDINICAMJERE.Tag = "labelNAZIVJEDINICAMJERE";
            this.label1NAZIVJEDINICAMJERE.Text = "Jed mjere:";
            this.label1NAZIVJEDINICAMJERE.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVJEDINICAMJERE.AutoSize = true;
            this.label1NAZIVJEDINICAMJERE.Anchor = AnchorStyles.Left;
            this.label1NAZIVJEDINICAMJERE.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVJEDINICAMJERE.Appearance.ForeColor = Color.Black;
            this.label1NAZIVJEDINICAMJERE.BackColor = Color.Transparent;
            this.layoutManagerformJEDINICAMJERE.Controls.Add(this.label1NAZIVJEDINICAMJERE, 0, 1);
            this.layoutManagerformJEDINICAMJERE.SetColumnSpan(this.label1NAZIVJEDINICAMJERE, 1);
            this.layoutManagerformJEDINICAMJERE.SetRowSpan(this.label1NAZIVJEDINICAMJERE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVJEDINICAMJERE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVJEDINICAMJERE.MinimumSize = size;
            size = new System.Drawing.Size(80, 0x17);
            this.label1NAZIVJEDINICAMJERE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVJEDINICAMJERE.Location = point;
            this.textNAZIVJEDINICAMJERE.Name = "textNAZIVJEDINICAMJERE";
            this.textNAZIVJEDINICAMJERE.Tag = "NAZIVJEDINICAMJERE";
            this.textNAZIVJEDINICAMJERE.TabIndex = 0;
            this.textNAZIVJEDINICAMJERE.Anchor = AnchorStyles.Left;
            this.textNAZIVJEDINICAMJERE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVJEDINICAMJERE.ReadOnly = false;
            this.textNAZIVJEDINICAMJERE.DataBindings.Add(new Binding("Text", this.bindingSourceJEDINICAMJERE, "NAZIVJEDINICAMJERE"));
            this.textNAZIVJEDINICAMJERE.MaxLength = 50;
            this.layoutManagerformJEDINICAMJERE.Controls.Add(this.textNAZIVJEDINICAMJERE, 1, 1);
            this.layoutManagerformJEDINICAMJERE.SetColumnSpan(this.textNAZIVJEDINICAMJERE, 1);
            this.layoutManagerformJEDINICAMJERE.SetRowSpan(this.textNAZIVJEDINICAMJERE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVJEDINICAMJERE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVJEDINICAMJERE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVJEDINICAMJERE.Size = size;
            this.Controls.Add(this.layoutManagerformJEDINICAMJERE);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceJEDINICAMJERE;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "JEDINICAMJEREFormUserControl";
            this.Text = "JEDINICAMJERE";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.JEDINICAMJEREFormUserControl_Load);
            this.layoutManagerformJEDINICAMJERE.ResumeLayout(false);
            this.layoutManagerformJEDINICAMJERE.PerformLayout();
            ((ISupportInitialize) this.bindingSourceJEDINICAMJERE).EndInit();
            ((ISupportInitialize) this.textIDJEDINICAMJERE).EndInit();
            ((ISupportInitialize) this.textNAZIVJEDINICAMJERE).EndInit();
            this.dsJEDINICAMJEREDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.JEDINICAMJEREController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceJEDINICAMJERE, this.JEDINICAMJEREController.WorkItem, this))
            {
                return false;
            }
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void JEDINICAMJEREFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.JEDINICAMJEREDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void Localize()
        {
            this.label1IDJEDINICAMJERE.Text = StringResources.JEDINICAMJEREIDJEDINICAMJEREDescription;
            this.label1NAZIVJEDINICAMJERE.Text = StringResources.JEDINICAMJERENAZIVJEDINICAMJEREDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewPROIZVOD")]
        public void NewPROIZVODHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.JEDINICAMJEREController.NewPROIZVOD(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.JEDINICAMJEREController.WorkItem.Items.Contains("JEDINICAMJERE|JEDINICAMJERE"))
            {
                this.JEDINICAMJEREController.WorkItem.Items.Add(this.bindingSourceJEDINICAMJERE, "JEDINICAMJERE|JEDINICAMJERE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsJEDINICAMJEREDataSet1.JEDINICAMJERE.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.JEDINICAMJEREController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.JEDINICAMJEREController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.JEDINICAMJEREController.Update(this))
            {
                this.JEDINICAMJEREController.DataSet = new JEDINICAMJEREDataSet();
                DataSetUtil.AddEmptyRow(this.JEDINICAMJEREController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.JEDINICAMJEREController.DataSet.JEDINICAMJERE[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDJEDINICAMJERE.Focus();
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

        [LocalCommandHandler("ViewPROIZVOD")]
        public void ViewPROIZVODHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.JEDINICAMJEREController.ViewPROIZVOD(this.m_CurrentRow);
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.JEDINICAMJEREController JEDINICAMJEREController { get; set; }

        protected virtual UltraLabel label1IDJEDINICAMJERE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDJEDINICAMJERE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDJEDINICAMJERE = value;
            }
        }

        protected virtual UltraLabel label1NAZIVJEDINICAMJERE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVJEDINICAMJERE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVJEDINICAMJERE = value;
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

        protected virtual UltraNumericEditor textIDJEDINICAMJERE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDJEDINICAMJERE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDJEDINICAMJERE = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVJEDINICAMJERE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVJEDINICAMJERE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVJEDINICAMJERE = value;
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

