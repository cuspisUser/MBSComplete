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
    public class RSVRSTEOBRACUNAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDRSVRSTEOBRACUNA")]
        private UltraLabel _label1IDRSVRSTEOBRACUNA;
        [AccessedThroughProperty("label1NAZIVRSVRSTEOBRACUNA")]
        private UltraLabel _label1NAZIVRSVRSTEOBRACUNA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDRSVRSTEOBRACUNA")]
        private UltraTextEditor _textIDRSVRSTEOBRACUNA;
        [AccessedThroughProperty("textNAZIVRSVRSTEOBRACUNA")]
        private UltraTextEditor _textNAZIVRSVRSTEOBRACUNA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRSVRSTEOBRACUNA;
        private IContainer components = null;
        private RSVRSTEOBRACUNADataSet dsRSVRSTEOBRACUNADataSet1;
        protected TableLayoutPanel layoutManagerformRSVRSTEOBRACUNA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RSVRSTEOBRACUNA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.RSVRSTEOBRACUNADescription;
        private DeklaritMode m_Mode;

        public RSVRSTEOBRACUNAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceRSVRSTEOBRACUNA.DataSource = this.RSVRSTEOBRACUNAController.DataSet;
            this.dsRSVRSTEOBRACUNADataSet1 = this.RSVRSTEOBRACUNAController.DataSet;
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
                    enumerator = this.dsRSVRSTEOBRACUNADataSet1.RSVRSTEOBRACUNA.Rows.GetEnumerator();
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
                if (this.RSVRSTEOBRACUNAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RSVRSTEOBRACUNA", this.m_Mode, this.dsRSVRSTEOBRACUNADataSet1, this.dsRSVRSTEOBRACUNADataSet1.RSVRSTEOBRACUNA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsRSVRSTEOBRACUNADataSet1.RSVRSTEOBRACUNA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RSVRSTEOBRACUNADataSet.RSVRSTEOBRACUNARow) ((DataRowView) this.bindingSourceRSVRSTEOBRACUNA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(RSVRSTEOBRACUNAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRSVRSTEOBRACUNA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRSVRSTEOBRACUNA).BeginInit();
            this.layoutManagerformRSVRSTEOBRACUNA = new TableLayoutPanel();
            this.layoutManagerformRSVRSTEOBRACUNA.SuspendLayout();
            this.layoutManagerformRSVRSTEOBRACUNA.AutoSize = true;
            this.layoutManagerformRSVRSTEOBRACUNA.Dock = DockStyle.Fill;
            this.layoutManagerformRSVRSTEOBRACUNA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRSVRSTEOBRACUNA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRSVRSTEOBRACUNA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRSVRSTEOBRACUNA.Size = size;
            this.layoutManagerformRSVRSTEOBRACUNA.ColumnCount = 2;
            this.layoutManagerformRSVRSTEOBRACUNA.RowCount = 3;
            this.layoutManagerformRSVRSTEOBRACUNA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRSVRSTEOBRACUNA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRSVRSTEOBRACUNA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSVRSTEOBRACUNA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSVRSTEOBRACUNA.RowStyles.Add(new RowStyle());
            this.label1IDRSVRSTEOBRACUNA = new UltraLabel();
            this.textIDRSVRSTEOBRACUNA = new UltraTextEditor();
            this.label1NAZIVRSVRSTEOBRACUNA = new UltraLabel();
            this.textNAZIVRSVRSTEOBRACUNA = new UltraTextEditor();
            ((ISupportInitialize) this.textIDRSVRSTEOBRACUNA).BeginInit();
            ((ISupportInitialize) this.textNAZIVRSVRSTEOBRACUNA).BeginInit();
            this.dsRSVRSTEOBRACUNADataSet1 = new RSVRSTEOBRACUNADataSet();
            this.dsRSVRSTEOBRACUNADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRSVRSTEOBRACUNADataSet1.DataSetName = "dsRSVRSTEOBRACUNA";
            this.dsRSVRSTEOBRACUNADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRSVRSTEOBRACUNA.DataSource = this.dsRSVRSTEOBRACUNADataSet1;
            this.bindingSourceRSVRSTEOBRACUNA.DataMember = "RSVRSTEOBRACUNA";
            ((ISupportInitialize) this.bindingSourceRSVRSTEOBRACUNA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDRSVRSTEOBRACUNA.Location = point;
            this.label1IDRSVRSTEOBRACUNA.Name = "label1IDRSVRSTEOBRACUNA";
            this.label1IDRSVRSTEOBRACUNA.TabIndex = 1;
            this.label1IDRSVRSTEOBRACUNA.Tag = "labelIDRSVRSTEOBRACUNA";
            this.label1IDRSVRSTEOBRACUNA.Text = "Šifra vrste obračuna:";
            this.label1IDRSVRSTEOBRACUNA.StyleSetName = "FieldUltraLabel";
            this.label1IDRSVRSTEOBRACUNA.AutoSize = true;
            this.label1IDRSVRSTEOBRACUNA.Anchor = AnchorStyles.Left;
            this.label1IDRSVRSTEOBRACUNA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDRSVRSTEOBRACUNA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDRSVRSTEOBRACUNA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDRSVRSTEOBRACUNA.ImageSize = size;
            this.label1IDRSVRSTEOBRACUNA.Appearance.ForeColor = Color.Black;
            this.label1IDRSVRSTEOBRACUNA.BackColor = Color.Transparent;
            this.layoutManagerformRSVRSTEOBRACUNA.Controls.Add(this.label1IDRSVRSTEOBRACUNA, 0, 0);
            this.layoutManagerformRSVRSTEOBRACUNA.SetColumnSpan(this.label1IDRSVRSTEOBRACUNA, 1);
            this.layoutManagerformRSVRSTEOBRACUNA.SetRowSpan(this.label1IDRSVRSTEOBRACUNA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDRSVRSTEOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDRSVRSTEOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(0x8e, 0x17);
            this.label1IDRSVRSTEOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDRSVRSTEOBRACUNA.Location = point;
            this.textIDRSVRSTEOBRACUNA.Name = "textIDRSVRSTEOBRACUNA";
            this.textIDRSVRSTEOBRACUNA.Tag = "IDRSVRSTEOBRACUNA";
            this.textIDRSVRSTEOBRACUNA.TabIndex = 0;
            this.textIDRSVRSTEOBRACUNA.Anchor = AnchorStyles.Left;
            this.textIDRSVRSTEOBRACUNA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDRSVRSTEOBRACUNA.ReadOnly = false;
            this.textIDRSVRSTEOBRACUNA.DataBindings.Add(new Binding("Text", this.bindingSourceRSVRSTEOBRACUNA, "IDRSVRSTEOBRACUNA"));
            this.textIDRSVRSTEOBRACUNA.MaxLength = 2;
            this.layoutManagerformRSVRSTEOBRACUNA.Controls.Add(this.textIDRSVRSTEOBRACUNA, 1, 0);
            this.layoutManagerformRSVRSTEOBRACUNA.SetColumnSpan(this.textIDRSVRSTEOBRACUNA, 1);
            this.layoutManagerformRSVRSTEOBRACUNA.SetRowSpan(this.textIDRSVRSTEOBRACUNA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDRSVRSTEOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textIDRSVRSTEOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textIDRSVRSTEOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVRSVRSTEOBRACUNA.Location = point;
            this.label1NAZIVRSVRSTEOBRACUNA.Name = "label1NAZIVRSVRSTEOBRACUNA";
            this.label1NAZIVRSVRSTEOBRACUNA.TabIndex = 1;
            this.label1NAZIVRSVRSTEOBRACUNA.Tag = "labelNAZIVRSVRSTEOBRACUNA";
            this.label1NAZIVRSVRSTEOBRACUNA.Text = "Naziv vrste obračuna:";
            this.label1NAZIVRSVRSTEOBRACUNA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVRSVRSTEOBRACUNA.AutoSize = true;
            this.label1NAZIVRSVRSTEOBRACUNA.Anchor = AnchorStyles.Left;
            this.label1NAZIVRSVRSTEOBRACUNA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVRSVRSTEOBRACUNA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVRSVRSTEOBRACUNA.BackColor = Color.Transparent;
            this.layoutManagerformRSVRSTEOBRACUNA.Controls.Add(this.label1NAZIVRSVRSTEOBRACUNA, 0, 1);
            this.layoutManagerformRSVRSTEOBRACUNA.SetColumnSpan(this.label1NAZIVRSVRSTEOBRACUNA, 1);
            this.layoutManagerformRSVRSTEOBRACUNA.SetRowSpan(this.label1NAZIVRSVRSTEOBRACUNA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVRSVRSTEOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVRSVRSTEOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(150, 0x17);
            this.label1NAZIVRSVRSTEOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVRSVRSTEOBRACUNA.Location = point;
            this.textNAZIVRSVRSTEOBRACUNA.Name = "textNAZIVRSVRSTEOBRACUNA";
            this.textNAZIVRSVRSTEOBRACUNA.Tag = "NAZIVRSVRSTEOBRACUNA";
            this.textNAZIVRSVRSTEOBRACUNA.TabIndex = 0;
            this.textNAZIVRSVRSTEOBRACUNA.Anchor = AnchorStyles.Left;
            this.textNAZIVRSVRSTEOBRACUNA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVRSVRSTEOBRACUNA.ReadOnly = false;
            this.textNAZIVRSVRSTEOBRACUNA.DataBindings.Add(new Binding("Text", this.bindingSourceRSVRSTEOBRACUNA, "NAZIVRSVRSTEOBRACUNA"));
            this.textNAZIVRSVRSTEOBRACUNA.MaxLength = 100;
            this.layoutManagerformRSVRSTEOBRACUNA.Controls.Add(this.textNAZIVRSVRSTEOBRACUNA, 1, 1);
            this.layoutManagerformRSVRSTEOBRACUNA.SetColumnSpan(this.textNAZIVRSVRSTEOBRACUNA, 1);
            this.layoutManagerformRSVRSTEOBRACUNA.SetRowSpan(this.textNAZIVRSVRSTEOBRACUNA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVRSVRSTEOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVRSVRSTEOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVRSVRSTEOBRACUNA.Size = size;
            this.Controls.Add(this.layoutManagerformRSVRSTEOBRACUNA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRSVRSTEOBRACUNA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RSVRSTEOBRACUNAFormUserControl";
            this.Text = "R-Sm - Vrste obraeuna";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RSVRSTEOBRACUNAFormUserControl_Load);
            this.layoutManagerformRSVRSTEOBRACUNA.ResumeLayout(false);
            this.layoutManagerformRSVRSTEOBRACUNA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRSVRSTEOBRACUNA).EndInit();
            ((ISupportInitialize) this.textIDRSVRSTEOBRACUNA).EndInit();
            ((ISupportInitialize) this.textNAZIVRSVRSTEOBRACUNA).EndInit();
            this.dsRSVRSTEOBRACUNADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RSVRSTEOBRACUNAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRSVRSTEOBRACUNA, this.RSVRSTEOBRACUNAController.WorkItem, this))
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
            this.label1IDRSVRSTEOBRACUNA.Text = StringResources.RSVRSTEOBRACUNAIDRSVRSTEOBRACUNADescription;
            this.label1NAZIVRSVRSTEOBRACUNA.Text = StringResources.RSVRSTEOBRACUNANAZIVRSVRSTEOBRACUNADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewRSMA")]
        public void NewRSMAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RSVRSTEOBRACUNAController.NewRSMA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.RSVRSTEOBRACUNAController.WorkItem.Items.Contains("RSVRSTEOBRACUNA|RSVRSTEOBRACUNA"))
            {
                this.RSVRSTEOBRACUNAController.WorkItem.Items.Add(this.bindingSourceRSVRSTEOBRACUNA, "RSVRSTEOBRACUNA|RSVRSTEOBRACUNA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsRSVRSTEOBRACUNADataSet1.RSVRSTEOBRACUNA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.m_Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.m_Mode;
                this.m_BaseMethods.FormLoadStyle();
            }
        }

        private void RSVRSTEOBRACUNAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RSVRSTEOBRACUNADescription;
            this.errorProvider1.ContainerControl = this;
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RSVRSTEOBRACUNAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RSVRSTEOBRACUNAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RSVRSTEOBRACUNAController.Update(this))
            {
                this.RSVRSTEOBRACUNAController.DataSet = new RSVRSTEOBRACUNADataSet();
                DataSetUtil.AddEmptyRow(this.RSVRSTEOBRACUNAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.RSVRSTEOBRACUNAController.DataSet.RSVRSTEOBRACUNA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDRSVRSTEOBRACUNA.Focus();
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

        [LocalCommandHandler("ViewRSMA")]
        public void ViewRSMAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RSVRSTEOBRACUNAController.ViewRSMA(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDRSVRSTEOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDRSVRSTEOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDRSVRSTEOBRACUNA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVRSVRSTEOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVRSVRSTEOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVRSVRSTEOBRACUNA = value;
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
        public NetAdvantage.Controllers.RSVRSTEOBRACUNAController RSVRSTEOBRACUNAController { get; set; }

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

        protected virtual UltraTextEditor textIDRSVRSTEOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDRSVRSTEOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDRSVRSTEOBRACUNA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVRSVRSTEOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVRSVRSTEOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVRSVRSTEOBRACUNA = value;
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

