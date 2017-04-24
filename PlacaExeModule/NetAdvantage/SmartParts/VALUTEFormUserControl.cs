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
    public class VALUTEFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDVALUTA")]
        private UltraLabel _label1IDVALUTA;
        [AccessedThroughProperty("label1NAZIVVALUTA")]
        private UltraLabel _label1NAZIVVALUTA;
        [AccessedThroughProperty("label1TECAJ")]
        private UltraLabel _label1TECAJ;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDVALUTA")]
        private UltraNumericEditor _textIDVALUTA;
        [AccessedThroughProperty("textNAZIVVALUTA")]
        private UltraTextEditor _textNAZIVVALUTA;
        [AccessedThroughProperty("textTECAJ")]
        private UltraNumericEditor _textTECAJ;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceVALUTE;
        private IContainer components = null;
        private VALUTEDataSet dsVALUTEDataSet1;
        protected TableLayoutPanel layoutManagerformVALUTE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private VALUTEDataSet.VALUTERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "VALUTE";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.VALUTEDescription;
        private DeklaritMode m_Mode;

        public VALUTEFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceVALUTE.DataSource = this.VALUTEController.DataSet;
            this.dsVALUTEDataSet1 = this.VALUTEController.DataSet;
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
                    enumerator = this.dsVALUTEDataSet1.VALUTE.Rows.GetEnumerator();
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
                if (this.VALUTEController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "VALUTE", this.m_Mode, this.dsVALUTEDataSet1, this.dsVALUTEDataSet1.VALUTE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsVALUTEDataSet1.VALUTE[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (VALUTEDataSet.VALUTERow) ((DataRowView) this.bindingSourceVALUTE.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(VALUTEFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceVALUTE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceVALUTE).BeginInit();
            this.layoutManagerformVALUTE = new TableLayoutPanel();
            this.layoutManagerformVALUTE.SuspendLayout();
            this.layoutManagerformVALUTE.AutoSize = true;
            this.layoutManagerformVALUTE.Dock = DockStyle.Fill;
            this.layoutManagerformVALUTE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformVALUTE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformVALUTE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformVALUTE.Size = size;
            this.layoutManagerformVALUTE.ColumnCount = 2;
            this.layoutManagerformVALUTE.RowCount = 4;
            this.layoutManagerformVALUTE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVALUTE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformVALUTE.RowStyles.Add(new RowStyle());
            this.layoutManagerformVALUTE.RowStyles.Add(new RowStyle());
            this.layoutManagerformVALUTE.RowStyles.Add(new RowStyle());
            this.layoutManagerformVALUTE.RowStyles.Add(new RowStyle());
            this.label1IDVALUTA = new UltraLabel();
            this.textIDVALUTA = new UltraNumericEditor();
            this.label1NAZIVVALUTA = new UltraLabel();
            this.textNAZIVVALUTA = new UltraTextEditor();
            this.label1TECAJ = new UltraLabel();
            this.textTECAJ = new UltraNumericEditor();
            ((ISupportInitialize) this.textIDVALUTA).BeginInit();
            ((ISupportInitialize) this.textNAZIVVALUTA).BeginInit();
            ((ISupportInitialize) this.textTECAJ).BeginInit();
            this.dsVALUTEDataSet1 = new VALUTEDataSet();
            this.dsVALUTEDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsVALUTEDataSet1.DataSetName = "dsVALUTE";
            this.dsVALUTEDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceVALUTE.DataSource = this.dsVALUTEDataSet1;
            this.bindingSourceVALUTE.DataMember = "VALUTE";
            ((ISupportInitialize) this.bindingSourceVALUTE).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDVALUTA.Location = point;
            this.label1IDVALUTA.Name = "label1IDVALUTA";
            this.label1IDVALUTA.TabIndex = 1;
            this.label1IDVALUTA.Tag = "labelIDVALUTA";
            this.label1IDVALUTA.Text = "Šifra valute:";
            this.label1IDVALUTA.StyleSetName = "FieldUltraLabel";
            this.label1IDVALUTA.AutoSize = true;
            this.label1IDVALUTA.Anchor = AnchorStyles.Left;
            this.label1IDVALUTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDVALUTA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDVALUTA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDVALUTA.ImageSize = size;
            this.label1IDVALUTA.Appearance.ForeColor = Color.Black;
            this.label1IDVALUTA.BackColor = Color.Transparent;
            this.layoutManagerformVALUTE.Controls.Add(this.label1IDVALUTA, 0, 0);
            this.layoutManagerformVALUTE.SetColumnSpan(this.label1IDVALUTA, 1);
            this.layoutManagerformVALUTE.SetRowSpan(this.label1IDVALUTA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDVALUTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDVALUTA.MinimumSize = size;
            size = new System.Drawing.Size(0x57, 0x17);
            this.label1IDVALUTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDVALUTA.Location = point;
            this.textIDVALUTA.Name = "textIDVALUTA";
            this.textIDVALUTA.Tag = "IDVALUTA";
            this.textIDVALUTA.TabIndex = 0;
            this.textIDVALUTA.Anchor = AnchorStyles.Left;
            this.textIDVALUTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDVALUTA.ReadOnly = false;
            this.textIDVALUTA.PromptChar = ' ';
            this.textIDVALUTA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDVALUTA.DataBindings.Add(new Binding("Value", this.bindingSourceVALUTE, "IDVALUTA"));
            this.textIDVALUTA.NumericType = NumericType.Integer;
            this.textIDVALUTA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformVALUTE.Controls.Add(this.textIDVALUTA, 1, 0);
            this.layoutManagerformVALUTE.SetColumnSpan(this.textIDVALUTA, 1);
            this.layoutManagerformVALUTE.SetRowSpan(this.textIDVALUTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDVALUTA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDVALUTA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDVALUTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVVALUTA.Location = point;
            this.label1NAZIVVALUTA.Name = "label1NAZIVVALUTA";
            this.label1NAZIVVALUTA.TabIndex = 1;
            this.label1NAZIVVALUTA.Tag = "labelNAZIVVALUTA";
            this.label1NAZIVVALUTA.Text = "Naziv valute:";
            this.label1NAZIVVALUTA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVVALUTA.AutoSize = true;
            this.label1NAZIVVALUTA.Anchor = AnchorStyles.Left;
            this.label1NAZIVVALUTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVVALUTA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVVALUTA.BackColor = Color.Transparent;
            this.layoutManagerformVALUTE.Controls.Add(this.label1NAZIVVALUTA, 0, 1);
            this.layoutManagerformVALUTE.SetColumnSpan(this.label1NAZIVVALUTA, 1);
            this.layoutManagerformVALUTE.SetRowSpan(this.label1NAZIVVALUTA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVVALUTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVVALUTA.MinimumSize = size;
            size = new System.Drawing.Size(0x60, 0x17);
            this.label1NAZIVVALUTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVVALUTA.Location = point;
            this.textNAZIVVALUTA.Name = "textNAZIVVALUTA";
            this.textNAZIVVALUTA.Tag = "NAZIVVALUTA";
            this.textNAZIVVALUTA.TabIndex = 0;
            this.textNAZIVVALUTA.Anchor = AnchorStyles.Left;
            this.textNAZIVVALUTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVVALUTA.ReadOnly = false;
            this.textNAZIVVALUTA.DataBindings.Add(new Binding("Text", this.bindingSourceVALUTE, "NAZIVVALUTA"));
            this.textNAZIVVALUTA.MaxLength = 50;
            this.layoutManagerformVALUTE.Controls.Add(this.textNAZIVVALUTA, 1, 1);
            this.layoutManagerformVALUTE.SetColumnSpan(this.textNAZIVVALUTA, 1);
            this.layoutManagerformVALUTE.SetRowSpan(this.textNAZIVVALUTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVVALUTA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVVALUTA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVVALUTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1TECAJ.Location = point;
            this.label1TECAJ.Name = "label1TECAJ";
            this.label1TECAJ.TabIndex = 1;
            this.label1TECAJ.Tag = "labelTECAJ";
            this.label1TECAJ.Text = "Tečaj:";
            this.label1TECAJ.StyleSetName = "FieldUltraLabel";
            this.label1TECAJ.AutoSize = true;
            this.label1TECAJ.Anchor = AnchorStyles.Left;
            this.label1TECAJ.Appearance.TextVAlign = VAlign.Middle;
            this.label1TECAJ.Appearance.ForeColor = Color.Black;
            this.label1TECAJ.BackColor = Color.Transparent;
            this.layoutManagerformVALUTE.Controls.Add(this.label1TECAJ, 0, 2);
            this.layoutManagerformVALUTE.SetColumnSpan(this.label1TECAJ, 1);
            this.layoutManagerformVALUTE.SetRowSpan(this.label1TECAJ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1TECAJ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1TECAJ.MinimumSize = size;
            size = new System.Drawing.Size(0x34, 0x17);
            this.label1TECAJ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textTECAJ.Location = point;
            this.textTECAJ.Name = "textTECAJ";
            this.textTECAJ.Tag = "TECAJ";
            this.textTECAJ.TabIndex = 0;
            this.textTECAJ.Anchor = AnchorStyles.Left;
            this.textTECAJ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textTECAJ.ReadOnly = false;
            this.textTECAJ.PromptChar = ' ';
            this.textTECAJ.Enter += new EventHandler(this.numericEditor_Enter);
            this.textTECAJ.DataBindings.Add(new Binding("Value", this.bindingSourceVALUTE, "TECAJ"));
            this.textTECAJ.NumericType = NumericType.Double;
            this.textTECAJ.MaxValue = 79228162514264337593543950335M;
            this.textTECAJ.MinValue = -79228162514264337593543950335M;
            this.textTECAJ.MaskInput = "{LOC}-nnnn.nnnnnnnn";
            this.layoutManagerformVALUTE.Controls.Add(this.textTECAJ, 1, 2);
            this.layoutManagerformVALUTE.SetColumnSpan(this.textTECAJ, 1);
            this.layoutManagerformVALUTE.SetRowSpan(this.textTECAJ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textTECAJ.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textTECAJ.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textTECAJ.Size = size;
            this.Controls.Add(this.layoutManagerformVALUTE);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceVALUTE;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "VALUTEFormUserControl";
            this.Text = "Valute i teeajna lista";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.VALUTEFormUserControl_Load);
            this.layoutManagerformVALUTE.ResumeLayout(false);
            this.layoutManagerformVALUTE.PerformLayout();
            ((ISupportInitialize) this.bindingSourceVALUTE).EndInit();
            ((ISupportInitialize) this.textIDVALUTA).EndInit();
            ((ISupportInitialize) this.textNAZIVVALUTA).EndInit();
            ((ISupportInitialize) this.textTECAJ).EndInit();
            this.dsVALUTEDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.VALUTEController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceVALUTE, this.VALUTEController.WorkItem, this))
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
            this.label1IDVALUTA.Text = StringResources.VALUTEIDVALUTADescription;
            this.label1NAZIVVALUTA.Text = StringResources.VALUTENAZIVVALUTADescription;
            this.label1TECAJ.Text = StringResources.VALUTETECAJDescription;
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
            if (!this.VALUTEController.WorkItem.Items.Contains("VALUTE|VALUTE"))
            {
                this.VALUTEController.WorkItem.Items.Add(this.bindingSourceVALUTE, "VALUTE|VALUTE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsVALUTEDataSet1.VALUTE.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.VALUTEController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.VALUTEController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.VALUTEController.Update(this))
            {
                this.VALUTEController.DataSet = new VALUTEDataSet();
                DataSetUtil.AddEmptyRow(this.VALUTEController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.VALUTEController.DataSet.VALUTE[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDVALUTA.Focus();
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

        private void VALUTEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.VALUTEDescription;
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

        protected virtual UltraLabel label1IDVALUTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDVALUTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDVALUTA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVVALUTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVVALUTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVVALUTA = value;
            }
        }

        protected virtual UltraLabel label1TECAJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1TECAJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1TECAJ = value;
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

        protected virtual UltraNumericEditor textIDVALUTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDVALUTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDVALUTA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVVALUTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVVALUTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVVALUTA = value;
            }
        }

        protected virtual UltraNumericEditor textTECAJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textTECAJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textTECAJ = value;
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
        public NetAdvantage.Controllers.VALUTEController VALUTEController { get; set; }
    }
}

