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
    public class GODINEFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkGODINEAKTIVNA")]
        private UltraCheckEditor _checkGODINEAKTIVNA;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1GODINEAKTIVNA")]
        private UltraLabel _label1GODINEAKTIVNA;
        [AccessedThroughProperty("label1IDGODINE")]
        private UltraLabel _label1IDGODINE;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDGODINE")]
        private UltraNumericEditor _textIDGODINE;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceGODINE;
        private IContainer components = null;
        private GODINEDataSet dsGODINEDataSet1;
        protected TableLayoutPanel layoutManagerformGODINE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private GODINEDataSet.GODINERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "GODINE";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.GODINEDescription;
        private DeklaritMode m_Mode;

        public GODINEFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceGODINE.DataSource = this.GODINEController.DataSet;
            this.dsGODINEDataSet1 = this.GODINEController.DataSet;
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
                    enumerator = this.dsGODINEDataSet1.GODINE.Rows.GetEnumerator();
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
                if (this.GODINEController.Update(this))
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

        private void GODINEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.GODINEDescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "GODINE", this.m_Mode, this.dsGODINEDataSet1, this.dsGODINEDataSet1.GODINE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("CheckState", this.bindingSourceGODINE, "GODINEAKTIVNA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkGODINEAKTIVNA.DataBindings["CheckState"] != null)
            {
                this.checkGODINEAKTIVNA.DataBindings.Remove(this.checkGODINEAKTIVNA.DataBindings["CheckState"]);
            }
            this.checkGODINEAKTIVNA.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsGODINEDataSet1.GODINE[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (GODINEDataSet.GODINERow) ((DataRowView) this.bindingSourceGODINE.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(GODINEFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceGODINE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceGODINE).BeginInit();
            this.layoutManagerformGODINE = new TableLayoutPanel();
            this.layoutManagerformGODINE.SuspendLayout();
            this.layoutManagerformGODINE.AutoSize = true;
            this.layoutManagerformGODINE.Dock = DockStyle.Fill;
            this.layoutManagerformGODINE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformGODINE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformGODINE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformGODINE.Size = size;
            this.layoutManagerformGODINE.ColumnCount = 2;
            this.layoutManagerformGODINE.RowCount = 3;
            this.layoutManagerformGODINE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformGODINE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformGODINE.RowStyles.Add(new RowStyle());
            this.layoutManagerformGODINE.RowStyles.Add(new RowStyle());
            this.layoutManagerformGODINE.RowStyles.Add(new RowStyle());
            this.label1IDGODINE = new UltraLabel();
            this.textIDGODINE = new UltraNumericEditor();
            this.label1GODINEAKTIVNA = new UltraLabel();
            this.checkGODINEAKTIVNA = new UltraCheckEditor();
            ((ISupportInitialize) this.textIDGODINE).BeginInit();
            this.dsGODINEDataSet1 = new GODINEDataSet();
            this.dsGODINEDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsGODINEDataSet1.DataSetName = "dsGODINE";
            this.dsGODINEDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceGODINE.DataSource = this.dsGODINEDataSet1;
            this.bindingSourceGODINE.DataMember = "GODINE";
            ((ISupportInitialize) this.bindingSourceGODINE).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDGODINE.Location = point;
            this.label1IDGODINE.Name = "label1IDGODINE";
            this.label1IDGODINE.TabIndex = 1;
            this.label1IDGODINE.Tag = "labelIDGODINE";
            this.label1IDGODINE.Text = "Godina:";
            this.label1IDGODINE.StyleSetName = "FieldUltraLabel";
            this.label1IDGODINE.AutoSize = true;
            this.label1IDGODINE.Anchor = AnchorStyles.Left;
            this.label1IDGODINE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDGODINE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDGODINE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDGODINE.ImageSize = size;
            this.label1IDGODINE.Appearance.ForeColor = Color.Black;
            this.label1IDGODINE.BackColor = Color.Transparent;
            this.layoutManagerformGODINE.Controls.Add(this.label1IDGODINE, 0, 0);
            this.layoutManagerformGODINE.SetColumnSpan(this.label1IDGODINE, 1);
            this.layoutManagerformGODINE.SetRowSpan(this.label1IDGODINE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDGODINE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDGODINE.MinimumSize = size;
            size = new System.Drawing.Size(60, 0x17);
            this.label1IDGODINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDGODINE.Location = point;
            this.textIDGODINE.Name = "textIDGODINE";
            this.textIDGODINE.Tag = "IDGODINE";
            this.textIDGODINE.TabIndex = 0;
            this.textIDGODINE.Anchor = AnchorStyles.Left;
            this.textIDGODINE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDGODINE.ReadOnly = false;
            this.textIDGODINE.PromptChar = ' ';
            this.textIDGODINE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDGODINE.DataBindings.Add(new Binding("Value", this.bindingSourceGODINE, "IDGODINE"));
            this.textIDGODINE.NumericType = NumericType.Integer;
            this.textIDGODINE.MaskInput = "{LOC}-nnnn";
            this.layoutManagerformGODINE.Controls.Add(this.textIDGODINE, 1, 0);
            this.layoutManagerformGODINE.SetColumnSpan(this.textIDGODINE, 1);
            this.layoutManagerformGODINE.SetRowSpan(this.textIDGODINE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDGODINE.Margin = padding;
            size = new System.Drawing.Size(0x2d, 0x16);
            this.textIDGODINE.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x16);
            this.textIDGODINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1GODINEAKTIVNA.Location = point;
            this.label1GODINEAKTIVNA.Name = "label1GODINEAKTIVNA";
            this.label1GODINEAKTIVNA.TabIndex = 1;
            this.label1GODINEAKTIVNA.Tag = "labelGODINEAKTIVNA";
            this.label1GODINEAKTIVNA.Text = "Aktivna:";
            this.label1GODINEAKTIVNA.StyleSetName = "FieldUltraLabel";
            this.label1GODINEAKTIVNA.AutoSize = true;
            this.label1GODINEAKTIVNA.Anchor = AnchorStyles.Left;
            this.label1GODINEAKTIVNA.Appearance.TextVAlign = VAlign.Middle;
            this.label1GODINEAKTIVNA.Appearance.ForeColor = Color.Black;
            this.label1GODINEAKTIVNA.BackColor = Color.Transparent;
            this.layoutManagerformGODINE.Controls.Add(this.label1GODINEAKTIVNA, 0, 1);
            this.layoutManagerformGODINE.SetColumnSpan(this.label1GODINEAKTIVNA, 1);
            this.layoutManagerformGODINE.SetRowSpan(this.label1GODINEAKTIVNA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1GODINEAKTIVNA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1GODINEAKTIVNA.MinimumSize = size;
            size = new System.Drawing.Size(0x42, 0x17);
            this.label1GODINEAKTIVNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkGODINEAKTIVNA.Location = point;
            this.checkGODINEAKTIVNA.Name = "checkGODINEAKTIVNA";
            this.checkGODINEAKTIVNA.Tag = "GODINEAKTIVNA";
            this.checkGODINEAKTIVNA.TabIndex = 0;
            this.checkGODINEAKTIVNA.Anchor = AnchorStyles.Left;
            this.checkGODINEAKTIVNA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkGODINEAKTIVNA.Enabled = true;
            this.layoutManagerformGODINE.Controls.Add(this.checkGODINEAKTIVNA, 1, 1);
            this.layoutManagerformGODINE.SetColumnSpan(this.checkGODINEAKTIVNA, 1);
            this.layoutManagerformGODINE.SetRowSpan(this.checkGODINEAKTIVNA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkGODINEAKTIVNA.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkGODINEAKTIVNA.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkGODINEAKTIVNA.Size = size;
            this.Controls.Add(this.layoutManagerformGODINE);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceGODINE;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "GODINEFormUserControl";
            this.Text = "GODINE";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.GODINEFormUserControl_Load);
            this.layoutManagerformGODINE.ResumeLayout(false);
            this.layoutManagerformGODINE.PerformLayout();
            ((ISupportInitialize) this.bindingSourceGODINE).EndInit();
            ((ISupportInitialize) this.textIDGODINE).EndInit();
            this.dsGODINEDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.GODINEController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceGODINE, this.GODINEController.WorkItem, this))
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
            this.label1IDGODINE.Text = StringResources.GODINEIDGODINEDescription;
            this.label1GODINEAKTIVNA.Text = StringResources.GODINEGODINEAKTIVNADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewEVIDENCIJA")]
        public void NewEVIDENCIJAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GODINEController.NewEVIDENCIJA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewGKSTAVKA")]
        public void NewGKSTAVKAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GODINEController.NewGKSTAVKA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewIRA")]
        public void NewIRAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GODINEController.NewIRA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewPLAN")]
        public void NewPLANHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GODINEController.NewPLAN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewRACUN")]
        public void NewRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GODINEController.NewRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewURA")]
        public void NewURAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GODINEController.NewURA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.GODINEController.WorkItem.Items.Contains("GODINE|GODINE"))
            {
                this.GODINEController.WorkItem.Items.Add(this.bindingSourceGODINE, "GODINE|GODINE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsGODINEDataSet1.GODINE.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.GODINEController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.GODINEController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.GODINEController.Update(this))
            {
                this.GODINEController.DataSet = new GODINEDataSet();
                DataSetUtil.AddEmptyRow(this.GODINEController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.GODINEController.DataSet.GODINE[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDGODINE.Focus();
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

        [LocalCommandHandler("ViewEVIDENCIJA")]
        public void ViewEVIDENCIJAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GODINEController.ViewEVIDENCIJA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewGKSTAVKA")]
        public void ViewGKSTAVKAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GODINEController.ViewGKSTAVKA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewIRA")]
        public void ViewIRAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GODINEController.ViewIRA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewPLAN")]
        public void ViewPLANHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GODINEController.ViewPLAN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewRACUN")]
        public void ViewRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GODINEController.ViewRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewURA")]
        public void ViewURAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GODINEController.ViewURA(this.m_CurrentRow);
            }
        }

        protected virtual UltraCheckEditor checkGODINEAKTIVNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkGODINEAKTIVNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkGODINEAKTIVNA = value;
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
        public NetAdvantage.Controllers.GODINEController GODINEController { get; set; }

        protected virtual UltraLabel label1GODINEAKTIVNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1GODINEAKTIVNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1GODINEAKTIVNA = value;
            }
        }

        protected virtual UltraLabel label1IDGODINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDGODINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDGODINE = value;
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

        protected virtual UltraNumericEditor textIDGODINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDGODINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDGODINE = value;
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

