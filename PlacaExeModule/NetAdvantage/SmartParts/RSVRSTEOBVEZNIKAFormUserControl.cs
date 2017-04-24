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
    public class RSVRSTEOBVEZNIKAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDRSVRSTEOBVEZNIKA")]
        private UltraLabel _label1IDRSVRSTEOBVEZNIKA;
        [AccessedThroughProperty("label1NAZIVRSVRSTEOBVEZNIKA")]
        private UltraLabel _label1NAZIVRSVRSTEOBVEZNIKA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDRSVRSTEOBVEZNIKA")]
        private UltraTextEditor _textIDRSVRSTEOBVEZNIKA;
        [AccessedThroughProperty("textNAZIVRSVRSTEOBVEZNIKA")]
        private UltraTextEditor _textNAZIVRSVRSTEOBVEZNIKA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRSVRSTEOBVEZNIKA;
        private IContainer components = null;
        private RSVRSTEOBVEZNIKADataSet dsRSVRSTEOBVEZNIKADataSet1;
        protected TableLayoutPanel layoutManagerformRSVRSTEOBVEZNIKA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RSVRSTEOBVEZNIKA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.RSVRSTEOBVEZNIKADescription;
        private DeklaritMode m_Mode;

        public RSVRSTEOBVEZNIKAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceRSVRSTEOBVEZNIKA.DataSource = this.RSVRSTEOBVEZNIKAController.DataSet;
            this.dsRSVRSTEOBVEZNIKADataSet1 = this.RSVRSTEOBVEZNIKAController.DataSet;
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
                    enumerator = this.dsRSVRSTEOBVEZNIKADataSet1.RSVRSTEOBVEZNIKA.Rows.GetEnumerator();
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
                if (this.RSVRSTEOBVEZNIKAController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RSVRSTEOBVEZNIKA", this.m_Mode, this.dsRSVRSTEOBVEZNIKADataSet1, this.dsRSVRSTEOBVEZNIKADataSet1.RSVRSTEOBVEZNIKA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsRSVRSTEOBVEZNIKADataSet1.RSVRSTEOBVEZNIKA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RSVRSTEOBVEZNIKADataSet.RSVRSTEOBVEZNIKARow) ((DataRowView) this.bindingSourceRSVRSTEOBVEZNIKA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(RSVRSTEOBVEZNIKAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRSVRSTEOBVEZNIKA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRSVRSTEOBVEZNIKA).BeginInit();
            this.layoutManagerformRSVRSTEOBVEZNIKA = new TableLayoutPanel();
            this.layoutManagerformRSVRSTEOBVEZNIKA.SuspendLayout();
            this.layoutManagerformRSVRSTEOBVEZNIKA.AutoSize = true;
            this.layoutManagerformRSVRSTEOBVEZNIKA.Dock = DockStyle.Fill;
            this.layoutManagerformRSVRSTEOBVEZNIKA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRSVRSTEOBVEZNIKA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRSVRSTEOBVEZNIKA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRSVRSTEOBVEZNIKA.Size = size;
            this.layoutManagerformRSVRSTEOBVEZNIKA.ColumnCount = 2;
            this.layoutManagerformRSVRSTEOBVEZNIKA.RowCount = 3;
            this.layoutManagerformRSVRSTEOBVEZNIKA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRSVRSTEOBVEZNIKA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRSVRSTEOBVEZNIKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSVRSTEOBVEZNIKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSVRSTEOBVEZNIKA.RowStyles.Add(new RowStyle());
            this.label1IDRSVRSTEOBVEZNIKA = new UltraLabel();
            this.textIDRSVRSTEOBVEZNIKA = new UltraTextEditor();
            this.label1NAZIVRSVRSTEOBVEZNIKA = new UltraLabel();
            this.textNAZIVRSVRSTEOBVEZNIKA = new UltraTextEditor();
            ((ISupportInitialize) this.textIDRSVRSTEOBVEZNIKA).BeginInit();
            ((ISupportInitialize) this.textNAZIVRSVRSTEOBVEZNIKA).BeginInit();
            this.dsRSVRSTEOBVEZNIKADataSet1 = new RSVRSTEOBVEZNIKADataSet();
            this.dsRSVRSTEOBVEZNIKADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRSVRSTEOBVEZNIKADataSet1.DataSetName = "dsRSVRSTEOBVEZNIKA";
            this.dsRSVRSTEOBVEZNIKADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRSVRSTEOBVEZNIKA.DataSource = this.dsRSVRSTEOBVEZNIKADataSet1;
            this.bindingSourceRSVRSTEOBVEZNIKA.DataMember = "RSVRSTEOBVEZNIKA";
            ((ISupportInitialize) this.bindingSourceRSVRSTEOBVEZNIKA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDRSVRSTEOBVEZNIKA.Location = point;
            this.label1IDRSVRSTEOBVEZNIKA.Name = "label1IDRSVRSTEOBVEZNIKA";
            this.label1IDRSVRSTEOBVEZNIKA.TabIndex = 1;
            this.label1IDRSVRSTEOBVEZNIKA.Tag = "labelIDRSVRSTEOBVEZNIKA";
            this.label1IDRSVRSTEOBVEZNIKA.Text = "Šifra vrste obveznika:";
            this.label1IDRSVRSTEOBVEZNIKA.StyleSetName = "FieldUltraLabel";
            this.label1IDRSVRSTEOBVEZNIKA.AutoSize = true;
            this.label1IDRSVRSTEOBVEZNIKA.Anchor = AnchorStyles.Left;
            this.label1IDRSVRSTEOBVEZNIKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDRSVRSTEOBVEZNIKA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDRSVRSTEOBVEZNIKA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDRSVRSTEOBVEZNIKA.ImageSize = size;
            this.label1IDRSVRSTEOBVEZNIKA.Appearance.ForeColor = Color.Black;
            this.label1IDRSVRSTEOBVEZNIKA.BackColor = Color.Transparent;
            this.layoutManagerformRSVRSTEOBVEZNIKA.Controls.Add(this.label1IDRSVRSTEOBVEZNIKA, 0, 0);
            this.layoutManagerformRSVRSTEOBVEZNIKA.SetColumnSpan(this.label1IDRSVRSTEOBVEZNIKA, 1);
            this.layoutManagerformRSVRSTEOBVEZNIKA.SetRowSpan(this.label1IDRSVRSTEOBVEZNIKA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDRSVRSTEOBVEZNIKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDRSVRSTEOBVEZNIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x93, 0x17);
            this.label1IDRSVRSTEOBVEZNIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDRSVRSTEOBVEZNIKA.Location = point;
            this.textIDRSVRSTEOBVEZNIKA.Name = "textIDRSVRSTEOBVEZNIKA";
            this.textIDRSVRSTEOBVEZNIKA.Tag = "IDRSVRSTEOBVEZNIKA";
            this.textIDRSVRSTEOBVEZNIKA.TabIndex = 0;
            this.textIDRSVRSTEOBVEZNIKA.Anchor = AnchorStyles.Left;
            this.textIDRSVRSTEOBVEZNIKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDRSVRSTEOBVEZNIKA.ReadOnly = false;
            this.textIDRSVRSTEOBVEZNIKA.DataBindings.Add(new Binding("Text", this.bindingSourceRSVRSTEOBVEZNIKA, "IDRSVRSTEOBVEZNIKA"));
            this.textIDRSVRSTEOBVEZNIKA.MaxLength = 2;
            this.layoutManagerformRSVRSTEOBVEZNIKA.Controls.Add(this.textIDRSVRSTEOBVEZNIKA, 1, 0);
            this.layoutManagerformRSVRSTEOBVEZNIKA.SetColumnSpan(this.textIDRSVRSTEOBVEZNIKA, 1);
            this.layoutManagerformRSVRSTEOBVEZNIKA.SetRowSpan(this.textIDRSVRSTEOBVEZNIKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDRSVRSTEOBVEZNIKA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textIDRSVRSTEOBVEZNIKA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textIDRSVRSTEOBVEZNIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVRSVRSTEOBVEZNIKA.Location = point;
            this.label1NAZIVRSVRSTEOBVEZNIKA.Name = "label1NAZIVRSVRSTEOBVEZNIKA";
            this.label1NAZIVRSVRSTEOBVEZNIKA.TabIndex = 1;
            this.label1NAZIVRSVRSTEOBVEZNIKA.Tag = "labelNAZIVRSVRSTEOBVEZNIKA";
            this.label1NAZIVRSVRSTEOBVEZNIKA.Text = "Naziv vrste obveznika:";
            this.label1NAZIVRSVRSTEOBVEZNIKA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVRSVRSTEOBVEZNIKA.AutoSize = true;
            this.label1NAZIVRSVRSTEOBVEZNIKA.Anchor = AnchorStyles.Left;
            this.label1NAZIVRSVRSTEOBVEZNIKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVRSVRSTEOBVEZNIKA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVRSVRSTEOBVEZNIKA.BackColor = Color.Transparent;
            this.layoutManagerformRSVRSTEOBVEZNIKA.Controls.Add(this.label1NAZIVRSVRSTEOBVEZNIKA, 0, 1);
            this.layoutManagerformRSVRSTEOBVEZNIKA.SetColumnSpan(this.label1NAZIVRSVRSTEOBVEZNIKA, 1);
            this.layoutManagerformRSVRSTEOBVEZNIKA.SetRowSpan(this.label1NAZIVRSVRSTEOBVEZNIKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVRSVRSTEOBVEZNIKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVRSVRSTEOBVEZNIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x9b, 0x17);
            this.label1NAZIVRSVRSTEOBVEZNIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVRSVRSTEOBVEZNIKA.Location = point;
            this.textNAZIVRSVRSTEOBVEZNIKA.Name = "textNAZIVRSVRSTEOBVEZNIKA";
            this.textNAZIVRSVRSTEOBVEZNIKA.Tag = "NAZIVRSVRSTEOBVEZNIKA";
            this.textNAZIVRSVRSTEOBVEZNIKA.TabIndex = 0;
            this.textNAZIVRSVRSTEOBVEZNIKA.Anchor = AnchorStyles.Left;
            this.textNAZIVRSVRSTEOBVEZNIKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVRSVRSTEOBVEZNIKA.ReadOnly = false;
            this.textNAZIVRSVRSTEOBVEZNIKA.DataBindings.Add(new Binding("Text", this.bindingSourceRSVRSTEOBVEZNIKA, "NAZIVRSVRSTEOBVEZNIKA"));
            this.textNAZIVRSVRSTEOBVEZNIKA.MaxLength = 100;
            this.layoutManagerformRSVRSTEOBVEZNIKA.Controls.Add(this.textNAZIVRSVRSTEOBVEZNIKA, 1, 1);
            this.layoutManagerformRSVRSTEOBVEZNIKA.SetColumnSpan(this.textNAZIVRSVRSTEOBVEZNIKA, 1);
            this.layoutManagerformRSVRSTEOBVEZNIKA.SetRowSpan(this.textNAZIVRSVRSTEOBVEZNIKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVRSVRSTEOBVEZNIKA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVRSVRSTEOBVEZNIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVRSVRSTEOBVEZNIKA.Size = size;
            this.Controls.Add(this.layoutManagerformRSVRSTEOBVEZNIKA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRSVRSTEOBVEZNIKA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RSVRSTEOBVEZNIKAFormUserControl";
            this.Text = "R-Sm - Vrste obveznika";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RSVRSTEOBVEZNIKAFormUserControl_Load);
            this.layoutManagerformRSVRSTEOBVEZNIKA.ResumeLayout(false);
            this.layoutManagerformRSVRSTEOBVEZNIKA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRSVRSTEOBVEZNIKA).EndInit();
            ((ISupportInitialize) this.textIDRSVRSTEOBVEZNIKA).EndInit();
            ((ISupportInitialize) this.textNAZIVRSVRSTEOBVEZNIKA).EndInit();
            this.dsRSVRSTEOBVEZNIKADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RSVRSTEOBVEZNIKAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRSVRSTEOBVEZNIKA, this.RSVRSTEOBVEZNIKAController.WorkItem, this))
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
            this.label1IDRSVRSTEOBVEZNIKA.Text = StringResources.RSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKADescription;
            this.label1NAZIVRSVRSTEOBVEZNIKA.Text = StringResources.RSVRSTEOBVEZNIKANAZIVRSVRSTEOBVEZNIKADescription;
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
                this.RSVRSTEOBVEZNIKAController.NewRSMA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.RSVRSTEOBVEZNIKAController.WorkItem.Items.Contains("RSVRSTEOBVEZNIKA|RSVRSTEOBVEZNIKA"))
            {
                this.RSVRSTEOBVEZNIKAController.WorkItem.Items.Add(this.bindingSourceRSVRSTEOBVEZNIKA, "RSVRSTEOBVEZNIKA|RSVRSTEOBVEZNIKA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsRSVRSTEOBVEZNIKADataSet1.RSVRSTEOBVEZNIKA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.m_Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.m_Mode;
                this.m_BaseMethods.FormLoadStyle();
            }
        }

        private void RSVRSTEOBVEZNIKAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RSVRSTEOBVEZNIKADescription;
            this.errorProvider1.ContainerControl = this;
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RSVRSTEOBVEZNIKAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RSVRSTEOBVEZNIKAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RSVRSTEOBVEZNIKAController.Update(this))
            {
                this.RSVRSTEOBVEZNIKAController.DataSet = new RSVRSTEOBVEZNIKADataSet();
                DataSetUtil.AddEmptyRow(this.RSVRSTEOBVEZNIKAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.RSVRSTEOBVEZNIKAController.DataSet.RSVRSTEOBVEZNIKA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDRSVRSTEOBVEZNIKA.Focus();
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
                this.RSVRSTEOBVEZNIKAController.ViewRSMA(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDRSVRSTEOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDRSVRSTEOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDRSVRSTEOBVEZNIKA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVRSVRSTEOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVRSVRSTEOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVRSVRSTEOBVEZNIKA = value;
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
        public NetAdvantage.Controllers.RSVRSTEOBVEZNIKAController RSVRSTEOBVEZNIKAController { get; set; }

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

        protected virtual UltraTextEditor textIDRSVRSTEOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDRSVRSTEOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDRSVRSTEOBVEZNIKA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVRSVRSTEOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVRSVRSTEOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVRSVRSTEOBVEZNIKA = value;
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

