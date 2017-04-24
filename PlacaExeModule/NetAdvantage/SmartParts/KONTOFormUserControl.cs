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
    using NetAdvantage.Controls;
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
    public class KONTOFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDAKTIVNOST")]
        private AKTIVNOSTComboBox _comboIDAKTIVNOST;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDAKTIVNOST")]
        private UltraLabel _label1IDAKTIVNOST;
        [AccessedThroughProperty("label1IDKONTO")]
        private UltraLabel _label1IDKONTO;
        [AccessedThroughProperty("label1KONT")]
        private UltraLabel _label1KONT;
        [AccessedThroughProperty("label1NAZIVKONTO")]
        private UltraLabel _label1NAZIVKONTO;
        [AccessedThroughProperty("labelKONT")]
        private UltraLabel _labelKONT;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDKONTO")]
        private UltraTextEditor _textIDKONTO;
        [AccessedThroughProperty("textNAZIVKONTO")]
        private UltraTextEditor _textNAZIVKONTO;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceKONTO;
        private IContainer components = null;
        private KONTODataSet dsKONTODataSet1;
        protected TableLayoutPanel layoutManagerformKONTO;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private KONTODataSet.KONTORow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "KONTO";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.KONTODescription;
        private DeklaritMode m_Mode;

        public KONTOFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceKONTO.DataSource = this.KONTOController.DataSet;
            this.dsKONTODataSet1 = this.KONTOController.DataSet;
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
                    enumerator = this.dsKONTODataSet1.KONTO.Rows.GetEnumerator();
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
                if (this.KONTOController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "KONTO", this.m_Mode, this.dsKONTODataSet1, this.dsKONTODataSet1.KONTO.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsKONTODataSet1.KONTO[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (KONTODataSet.KONTORow) ((DataRowView) this.bindingSourceKONTO.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(KONTOFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceKONTO = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceKONTO).BeginInit();
            this.layoutManagerformKONTO = new TableLayoutPanel();
            this.layoutManagerformKONTO.SuspendLayout();
            this.layoutManagerformKONTO.AutoSize = true;
            this.layoutManagerformKONTO.Dock = DockStyle.Fill;
            this.layoutManagerformKONTO.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformKONTO.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformKONTO.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformKONTO.Size = size;
            this.layoutManagerformKONTO.ColumnCount = 2;
            this.layoutManagerformKONTO.RowCount = 4;
            this.layoutManagerformKONTO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformKONTO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformKONTO.RowStyles.Add(new RowStyle());
            this.layoutManagerformKONTO.RowStyles.Add(new RowStyle());
            this.layoutManagerformKONTO.RowStyles.Add(new RowStyle());
            this.layoutManagerformKONTO.RowStyles.Add(new RowStyle());
            this.label1IDKONTO = new UltraLabel();
            this.textIDKONTO = new UltraTextEditor();
            this.label1NAZIVKONTO = new UltraLabel();
            this.textNAZIVKONTO = new UltraTextEditor();
            this.label1IDAKTIVNOST = new UltraLabel();
            this.comboIDAKTIVNOST = new AKTIVNOSTComboBox();
            this.label1KONT = new UltraLabel();
            this.labelKONT = new UltraLabel();
            ((ISupportInitialize) this.textIDKONTO).BeginInit();
            ((ISupportInitialize) this.textNAZIVKONTO).BeginInit();
            this.dsKONTODataSet1 = new KONTODataSet();
            this.dsKONTODataSet1.BeginInit();
            this.SuspendLayout();
            this.dsKONTODataSet1.DataSetName = "dsKONTO";
            this.dsKONTODataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceKONTO.DataSource = this.dsKONTODataSet1;
            this.bindingSourceKONTO.DataMember = "KONTO";
            ((ISupportInitialize) this.bindingSourceKONTO).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDKONTO.Location = point;
            this.label1IDKONTO.Name = "label1IDKONTO";
            this.label1IDKONTO.TabIndex = 1;
            this.label1IDKONTO.Tag = "labelIDKONTO";
            this.label1IDKONTO.Text = "Konto:";
            this.label1IDKONTO.StyleSetName = "FieldUltraLabel";
            this.label1IDKONTO.AutoSize = true;
            this.label1IDKONTO.Anchor = AnchorStyles.Left;
            this.label1IDKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDKONTO.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDKONTO.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDKONTO.ImageSize = size;
            this.label1IDKONTO.Appearance.ForeColor = Color.Black;
            this.label1IDKONTO.BackColor = Color.Transparent;
            this.layoutManagerformKONTO.Controls.Add(this.label1IDKONTO, 0, 0);
            this.layoutManagerformKONTO.SetColumnSpan(this.label1IDKONTO, 1);
            this.layoutManagerformKONTO.SetRowSpan(this.label1IDKONTO, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDKONTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1IDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDKONTO.Location = point;
            this.textIDKONTO.Name = "textIDKONTO";
            this.textIDKONTO.Tag = "IDKONTO";
            this.textIDKONTO.TabIndex = 0;
            this.textIDKONTO.Anchor = AnchorStyles.Left;
            this.textIDKONTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDKONTO.ReadOnly = false;
            this.textIDKONTO.DataBindings.Add(new Binding("Text", this.bindingSourceKONTO, "IDKONTO"));
            this.textIDKONTO.MaxLength = 14;
            this.layoutManagerformKONTO.Controls.Add(this.textIDKONTO, 1, 0);
            this.layoutManagerformKONTO.SetColumnSpan(this.textIDKONTO, 1);
            this.layoutManagerformKONTO.SetRowSpan(this.textIDKONTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0x72, 0x16);
            this.textIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x72, 0x16);
            this.textIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVKONTO.Location = point;
            this.label1NAZIVKONTO.Name = "label1NAZIVKONTO";
            this.label1NAZIVKONTO.TabIndex = 1;
            this.label1NAZIVKONTO.Tag = "labelNAZIVKONTO";
            this.label1NAZIVKONTO.Text = "Naziv konta:";
            this.label1NAZIVKONTO.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVKONTO.AutoSize = true;
            this.label1NAZIVKONTO.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1NAZIVKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVKONTO.Appearance.ForeColor = Color.Black;
            this.label1NAZIVKONTO.BackColor = Color.Transparent;
            this.layoutManagerformKONTO.Controls.Add(this.label1NAZIVKONTO, 0, 1);
            this.layoutManagerformKONTO.SetColumnSpan(this.label1NAZIVKONTO, 1);
            this.layoutManagerformKONTO.SetRowSpan(this.label1NAZIVKONTO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVKONTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x5c, 0x17);
            this.label1NAZIVKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVKONTO.Location = point;
            this.textNAZIVKONTO.Name = "textNAZIVKONTO";
            this.textNAZIVKONTO.Tag = "NAZIVKONTO";
            this.textNAZIVKONTO.TabIndex = 0;
            this.textNAZIVKONTO.Anchor = AnchorStyles.Left;
            this.textNAZIVKONTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVKONTO.ReadOnly = false;
            this.textNAZIVKONTO.DataBindings.Add(new Binding("Text", this.bindingSourceKONTO, "NAZIVKONTO"));
            this.textNAZIVKONTO.Multiline = true;
            this.textNAZIVKONTO.MaxLength = 150;
            this.layoutManagerformKONTO.Controls.Add(this.textNAZIVKONTO, 1, 1);
            this.layoutManagerformKONTO.SetColumnSpan(this.textNAZIVKONTO, 1);
            this.layoutManagerformKONTO.SetRowSpan(this.textNAZIVKONTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVKONTO.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.textNAZIVKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.textNAZIVKONTO.Size = size;
            this.textNAZIVKONTO.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.label1IDAKTIVNOST.Location = point;
            this.label1IDAKTIVNOST.Name = "label1IDAKTIVNOST";
            this.label1IDAKTIVNOST.TabIndex = 1;
            this.label1IDAKTIVNOST.Tag = "labelIDAKTIVNOST";
            this.label1IDAKTIVNOST.Text = "Šifra aktivnosti:";
            this.label1IDAKTIVNOST.StyleSetName = "FieldUltraLabel";
            this.label1IDAKTIVNOST.AutoSize = true;
            this.label1IDAKTIVNOST.Anchor = AnchorStyles.Left;
            this.label1IDAKTIVNOST.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDAKTIVNOST.Appearance.ForeColor = Color.Black;
            this.label1IDAKTIVNOST.BackColor = Color.Transparent;
            this.layoutManagerformKONTO.Controls.Add(this.label1IDAKTIVNOST, 0, 2);
            this.layoutManagerformKONTO.SetColumnSpan(this.label1IDAKTIVNOST, 1);
            this.layoutManagerformKONTO.SetRowSpan(this.label1IDAKTIVNOST, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDAKTIVNOST.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDAKTIVNOST.MinimumSize = size;
            size = new System.Drawing.Size(0x71, 0x17);
            this.label1IDAKTIVNOST.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDAKTIVNOST.Location = point;
            this.comboIDAKTIVNOST.Name = "comboIDAKTIVNOST";
            this.comboIDAKTIVNOST.Tag = "IDAKTIVNOST";
            this.comboIDAKTIVNOST.TabIndex = 0;
            this.comboIDAKTIVNOST.Anchor = AnchorStyles.Left;
            this.comboIDAKTIVNOST.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDAKTIVNOST.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDAKTIVNOST.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDAKTIVNOST.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDAKTIVNOST.Enabled = true;
            this.comboIDAKTIVNOST.DataBindings.Add(new Binding("Value", this.bindingSourceKONTO, "IDAKTIVNOST"));
            this.comboIDAKTIVNOST.ValueMember = "IDAKTIVNOST";
            this.comboIDAKTIVNOST.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDAKTIVNOST);
            this.layoutManagerformKONTO.Controls.Add(this.comboIDAKTIVNOST, 1, 2);
            this.layoutManagerformKONTO.SetColumnSpan(this.comboIDAKTIVNOST, 1);
            this.layoutManagerformKONTO.SetRowSpan(this.comboIDAKTIVNOST, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDAKTIVNOST.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDAKTIVNOST.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDAKTIVNOST.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1KONT.Location = point;
            this.label1KONT.Name = "label1KONT";
            this.label1KONT.TabIndex = 1;
            this.label1KONT.Tag = "labelKONT";
            this.label1KONT.Text = "KONT:";
            this.label1KONT.StyleSetName = "FieldUltraLabel";
            this.label1KONT.AutoSize = true;
            this.label1KONT.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1KONT.Appearance.TextVAlign = VAlign.Middle;
            this.label1KONT.Appearance.ForeColor = Color.Black;
            this.label1KONT.BackColor = Color.Transparent;
            this.layoutManagerformKONTO.Controls.Add(this.label1KONT, 0, 3);
            this.layoutManagerformKONTO.SetColumnSpan(this.label1KONT, 1);
            this.layoutManagerformKONTO.SetRowSpan(this.label1KONT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1KONT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1KONT.MinimumSize = size;
            size = new System.Drawing.Size(0x36, 0x17);
            this.label1KONT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelKONT.Location = point;
            this.labelKONT.Name = "labelKONT";
            this.labelKONT.Tag = "KONT";
            this.labelKONT.TabIndex = 0;
            this.labelKONT.Anchor = AnchorStyles.Left;
            this.labelKONT.BackColor = Color.Transparent;
            this.labelKONT.DataBindings.Add(new Binding("Text", this.bindingSourceKONTO, "KONT"));
            this.labelKONT.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformKONTO.Controls.Add(this.labelKONT, 1, 3);
            this.layoutManagerformKONTO.SetColumnSpan(this.labelKONT, 1);
            this.layoutManagerformKONTO.SetRowSpan(this.labelKONT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelKONT.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.labelKONT.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.labelKONT.Size = size;
            this.labelKONT.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformKONTO);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceKONTO;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "KONTOFormUserControl";
            this.Text = "Kontni plan";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.KONTOFormUserControl_Load);
            this.layoutManagerformKONTO.ResumeLayout(false);
            this.layoutManagerformKONTO.PerformLayout();
            ((ISupportInitialize) this.bindingSourceKONTO).EndInit();
            ((ISupportInitialize) this.textIDKONTO).EndInit();
            ((ISupportInitialize) this.textNAZIVKONTO).EndInit();
            this.dsKONTODataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.KONTOController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceKONTO, this.KONTOController.WorkItem, this))
            {
                return false;
            }
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void KONTOFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.KONTODescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void Localize()
        {
            this.label1IDKONTO.Text = StringResources.KONTOIDKONTODescription;
            this.label1NAZIVKONTO.Text = StringResources.KONTONAZIVKONTODescription;
            this.label1IDAKTIVNOST.Text = StringResources.KONTOIDAKTIVNOSTDescription;
            this.label1KONT.Text = StringResources.KONTOKONTDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewAMSKUPINE1")]
        public void NewAMSKUPINE1Handler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.KONTOController.NewAMSKUPINE1(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewAMSKUPINE2")]
        public void NewAMSKUPINE2Handler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.KONTOController.NewAMSKUPINE2(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewAMSKUPINE")]
        public void NewAMSKUPINEHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.KONTOController.NewAMSKUPINE(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewBLAGAJNA")]
        public void NewBLAGAJNAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.KONTOController.NewBLAGAJNA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewGKSTAVKA")]
        public void NewGKSTAVKAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.KONTOController.NewGKSTAVKA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.KONTOController.WorkItem.Items.Contains("KONTO|KONTO"))
            {
                this.KONTOController.WorkItem.Items.Add(this.bindingSourceKONTO, "KONTO|KONTO");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsKONTODataSet1.KONTO.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.KONTOController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.KONTOController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.KONTOController.Update(this))
            {
                this.KONTOController.DataSet = new KONTODataSet();
                DataSetUtil.AddEmptyRow(this.KONTOController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.KONTOController.DataSet.KONTO[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedIDAKTIVNOST(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDAKTIVNOST.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDAKTIVNOST.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceKONTO.Current).Row["IDAKTIVNOST"] = RuntimeHelpers.GetObjectValue(row["IDAKTIVNOST"]);
                    ((DataRowView) this.bindingSourceKONTO.Current).Row["NAZIVAKTIVNOST"] = RuntimeHelpers.GetObjectValue(row["NAZIVAKTIVNOST"]);
                    this.bindingSourceKONTO.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDKONTO.Focus();
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

        [LocalCommandHandler("ViewAMSKUPINE1")]
        public void ViewAMSKUPINE1Handler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.KONTOController.ViewAMSKUPINE1(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewAMSKUPINE2")]
        public void ViewAMSKUPINE2Handler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.KONTOController.ViewAMSKUPINE2(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewAMSKUPINE")]
        public void ViewAMSKUPINEHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.KONTOController.ViewAMSKUPINE(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewBLAGAJNA")]
        public void ViewBLAGAJNAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.KONTOController.ViewBLAGAJNA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewGKSTAVKA")]
        public void ViewGKSTAVKAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.KONTOController.ViewGKSTAVKA(this.m_CurrentRow);
            }
        }

        protected virtual AKTIVNOSTComboBox comboIDAKTIVNOST
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDAKTIVNOST;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDAKTIVNOST = value;
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
        public NetAdvantage.Controllers.KONTOController KONTOController { get; set; }

        protected virtual UltraLabel label1IDAKTIVNOST
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDAKTIVNOST;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDAKTIVNOST = value;
            }
        }

        protected virtual UltraLabel label1IDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDKONTO = value;
            }
        }

        protected virtual UltraLabel label1KONT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1KONT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1KONT = value;
            }
        }

        protected virtual UltraLabel label1NAZIVKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVKONTO = value;
            }
        }

        protected virtual UltraLabel labelKONT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelKONT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelKONT = value;
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

        protected virtual UltraTextEditor textIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDKONTO = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVKONTO = value;
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

