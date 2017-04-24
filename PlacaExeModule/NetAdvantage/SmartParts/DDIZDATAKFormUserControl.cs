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
    public class DDIZDATAKFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1DDIDIZDATAK")]
        private UltraLabel _label1DDIDIZDATAK;
        [AccessedThroughProperty("label1DDNAZIVIZDATKA")]
        private UltraLabel _label1DDNAZIVIZDATKA;
        [AccessedThroughProperty("label1DDPOSTOTAKIZDATKA")]
        private UltraLabel _label1DDPOSTOTAKIZDATKA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textDDIDIZDATAK")]
        private UltraNumericEditor _textDDIDIZDATAK;
        [AccessedThroughProperty("textDDNAZIVIZDATKA")]
        private UltraTextEditor _textDDNAZIVIZDATKA;
        [AccessedThroughProperty("textDDPOSTOTAKIZDATKA")]
        private UltraNumericEditor _textDDPOSTOTAKIZDATKA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceDDIZDATAK;
        private IContainer components = null;
        private DDIZDATAKDataSet dsDDIZDATAKDataSet1;
        protected TableLayoutPanel layoutManagerformDDIZDATAK;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private DDIZDATAKDataSet.DDIZDATAKRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "DDIZDATAK";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.DDIZDATAKDescription;
        private DeklaritMode m_Mode;

        public DDIZDATAKFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public void ChangeBinding()
        {
            this.bindingSourceDDIZDATAK.DataSource = this.DDIZDATAKController.DataSet;
            this.dsDDIZDATAKDataSet1 = this.DDIZDATAKController.DataSet;
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

        private void DDIZDATAKFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.DDIZDATAKDescription;
            this.errorProvider1.ContainerControl = this;
        }

        [LocalCommandHandler("DeleteInstance")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.dsDDIZDATAKDataSet1.DDIZDATAK.Rows.GetEnumerator();
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
                if (this.DDIZDATAKController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "DDIZDATAK", this.m_Mode, this.dsDDIZDATAKDataSet1, this.dsDDIZDATAKDataSet1.DDIZDATAK.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsDDIZDATAKDataSet1.DDIZDATAK[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (DDIZDATAKDataSet.DDIZDATAKRow) ((DataRowView) this.bindingSourceDDIZDATAK.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(DDIZDATAKFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceDDIZDATAK = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDDIZDATAK).BeginInit();
            this.layoutManagerformDDIZDATAK = new TableLayoutPanel();
            this.layoutManagerformDDIZDATAK.SuspendLayout();
            this.layoutManagerformDDIZDATAK.AutoSize = true;
            this.layoutManagerformDDIZDATAK.Dock = DockStyle.Fill;
            this.layoutManagerformDDIZDATAK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformDDIZDATAK.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformDDIZDATAK.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformDDIZDATAK.Size = size;
            this.layoutManagerformDDIZDATAK.ColumnCount = 2;
            this.layoutManagerformDDIZDATAK.RowCount = 4;
            this.layoutManagerformDDIZDATAK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDDIZDATAK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDDIZDATAK.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDIZDATAK.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDIZDATAK.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDIZDATAK.RowStyles.Add(new RowStyle());
            this.label1DDIDIZDATAK = new UltraLabel();
            this.textDDIDIZDATAK = new UltraNumericEditor();
            this.label1DDNAZIVIZDATKA = new UltraLabel();
            this.textDDNAZIVIZDATKA = new UltraTextEditor();
            this.label1DDPOSTOTAKIZDATKA = new UltraLabel();
            this.textDDPOSTOTAKIZDATKA = new UltraNumericEditor();
            ((ISupportInitialize) this.textDDIDIZDATAK).BeginInit();
            ((ISupportInitialize) this.textDDNAZIVIZDATKA).BeginInit();
            ((ISupportInitialize) this.textDDPOSTOTAKIZDATKA).BeginInit();
            this.dsDDIZDATAKDataSet1 = new DDIZDATAKDataSet();
            this.dsDDIZDATAKDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsDDIZDATAKDataSet1.DataSetName = "dsDDIZDATAK";
            this.dsDDIZDATAKDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceDDIZDATAK.DataSource = this.dsDDIZDATAKDataSet1;
            this.bindingSourceDDIZDATAK.DataMember = "DDIZDATAK";
            ((ISupportInitialize) this.bindingSourceDDIZDATAK).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1DDIDIZDATAK.Location = point;
            this.label1DDIDIZDATAK.Name = "label1DDIDIZDATAK";
            this.label1DDIDIZDATAK.TabIndex = 1;
            this.label1DDIDIZDATAK.Tag = "labelDDIDIZDATAK";
            this.label1DDIDIZDATAK.Text = "Šifra izdatka:";
            this.label1DDIDIZDATAK.StyleSetName = "FieldUltraLabel";
            this.label1DDIDIZDATAK.AutoSize = true;
            this.label1DDIDIZDATAK.Anchor = AnchorStyles.Left;
            this.label1DDIDIZDATAK.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDIDIZDATAK.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1DDIDIZDATAK.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1DDIDIZDATAK.ImageSize = size;
            this.label1DDIDIZDATAK.Appearance.ForeColor = Color.Black;
            this.label1DDIDIZDATAK.BackColor = Color.Transparent;
            this.layoutManagerformDDIZDATAK.Controls.Add(this.label1DDIDIZDATAK, 0, 0);
            this.layoutManagerformDDIZDATAK.SetColumnSpan(this.label1DDIDIZDATAK, 1);
            this.layoutManagerformDDIZDATAK.SetRowSpan(this.label1DDIDIZDATAK, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1DDIDIZDATAK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDIDIZDATAK.MinimumSize = size;
            size = new System.Drawing.Size(0x5e, 0x17);
            this.label1DDIDIZDATAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDIDIZDATAK.Location = point;
            this.textDDIDIZDATAK.Name = "textDDIDIZDATAK";
            this.textDDIDIZDATAK.Tag = "DDIDIZDATAK";
            this.textDDIDIZDATAK.TabIndex = 0;
            this.textDDIDIZDATAK.Anchor = AnchorStyles.Left;
            this.textDDIDIZDATAK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDIDIZDATAK.ReadOnly = false;
            this.textDDIDIZDATAK.PromptChar = ' ';
            this.textDDIDIZDATAK.Enter += new EventHandler(this.numericEditor_Enter);
            this.textDDIDIZDATAK.DataBindings.Add(new Binding("Value", this.bindingSourceDDIZDATAK, "DDIDIZDATAK"));
            this.textDDIDIZDATAK.NumericType = NumericType.Integer;
            this.textDDIDIZDATAK.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformDDIZDATAK.Controls.Add(this.textDDIDIZDATAK, 1, 0);
            this.layoutManagerformDDIZDATAK.SetColumnSpan(this.textDDIDIZDATAK, 1);
            this.layoutManagerformDDIZDATAK.SetRowSpan(this.textDDIDIZDATAK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDIDIZDATAK.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textDDIDIZDATAK.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textDDIDIZDATAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDNAZIVIZDATKA.Location = point;
            this.label1DDNAZIVIZDATKA.Name = "label1DDNAZIVIZDATKA";
            this.label1DDNAZIVIZDATKA.TabIndex = 1;
            this.label1DDNAZIVIZDATKA.Tag = "labelDDNAZIVIZDATKA";
            this.label1DDNAZIVIZDATKA.Text = "Naziv izdatka:";
            this.label1DDNAZIVIZDATKA.StyleSetName = "FieldUltraLabel";
            this.label1DDNAZIVIZDATKA.AutoSize = true;
            this.label1DDNAZIVIZDATKA.Anchor = AnchorStyles.Left;
            this.label1DDNAZIVIZDATKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDNAZIVIZDATKA.Appearance.ForeColor = Color.Black;
            this.label1DDNAZIVIZDATKA.BackColor = Color.Transparent;
            this.layoutManagerformDDIZDATAK.Controls.Add(this.label1DDNAZIVIZDATKA, 0, 1);
            this.layoutManagerformDDIZDATAK.SetColumnSpan(this.label1DDNAZIVIZDATKA, 1);
            this.layoutManagerformDDIZDATAK.SetRowSpan(this.label1DDNAZIVIZDATKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDNAZIVIZDATKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDNAZIVIZDATKA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x17);
            this.label1DDNAZIVIZDATKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDNAZIVIZDATKA.Location = point;
            this.textDDNAZIVIZDATKA.Name = "textDDNAZIVIZDATKA";
            this.textDDNAZIVIZDATKA.Tag = "DDNAZIVIZDATKA";
            this.textDDNAZIVIZDATKA.TabIndex = 0;
            this.textDDNAZIVIZDATKA.Anchor = AnchorStyles.Left;
            this.textDDNAZIVIZDATKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDNAZIVIZDATKA.ReadOnly = false;
            this.textDDNAZIVIZDATKA.DataBindings.Add(new Binding("Text", this.bindingSourceDDIZDATAK, "DDNAZIVIZDATKA"));
            this.textDDNAZIVIZDATKA.MaxLength = 50;
            this.layoutManagerformDDIZDATAK.Controls.Add(this.textDDNAZIVIZDATKA, 1, 1);
            this.layoutManagerformDDIZDATAK.SetColumnSpan(this.textDDNAZIVIZDATKA, 1);
            this.layoutManagerformDDIZDATAK.SetRowSpan(this.textDDNAZIVIZDATKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDNAZIVIZDATKA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textDDNAZIVIZDATKA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textDDNAZIVIZDATKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDPOSTOTAKIZDATKA.Location = point;
            this.label1DDPOSTOTAKIZDATKA.Name = "label1DDPOSTOTAKIZDATKA";
            this.label1DDPOSTOTAKIZDATKA.TabIndex = 1;
            this.label1DDPOSTOTAKIZDATKA.Tag = "labelDDPOSTOTAKIZDATKA";
            this.label1DDPOSTOTAKIZDATKA.Text = "Postotak izdatka:";
            this.label1DDPOSTOTAKIZDATKA.StyleSetName = "FieldUltraLabel";
            this.label1DDPOSTOTAKIZDATKA.AutoSize = true;
            this.label1DDPOSTOTAKIZDATKA.Anchor = AnchorStyles.Left;
            this.label1DDPOSTOTAKIZDATKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDPOSTOTAKIZDATKA.Appearance.ForeColor = Color.Black;
            this.label1DDPOSTOTAKIZDATKA.BackColor = Color.Transparent;
            this.layoutManagerformDDIZDATAK.Controls.Add(this.label1DDPOSTOTAKIZDATKA, 0, 2);
            this.layoutManagerformDDIZDATAK.SetColumnSpan(this.label1DDPOSTOTAKIZDATKA, 1);
            this.layoutManagerformDDIZDATAK.SetRowSpan(this.label1DDPOSTOTAKIZDATKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDPOSTOTAKIZDATKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDPOSTOTAKIZDATKA.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1DDPOSTOTAKIZDATKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDPOSTOTAKIZDATKA.Location = point;
            this.textDDPOSTOTAKIZDATKA.Name = "textDDPOSTOTAKIZDATKA";
            this.textDDPOSTOTAKIZDATKA.Tag = "DDPOSTOTAKIZDATKA";
            this.textDDPOSTOTAKIZDATKA.TabIndex = 0;
            this.textDDPOSTOTAKIZDATKA.Anchor = AnchorStyles.Left;
            this.textDDPOSTOTAKIZDATKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDPOSTOTAKIZDATKA.ReadOnly = false;
            this.textDDPOSTOTAKIZDATKA.PromptChar = ' ';
            this.textDDPOSTOTAKIZDATKA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textDDPOSTOTAKIZDATKA.DataBindings.Add(new Binding("Value", this.bindingSourceDDIZDATAK, "DDPOSTOTAKIZDATKA"));
            this.textDDPOSTOTAKIZDATKA.NumericType = NumericType.Double;
            this.textDDPOSTOTAKIZDATKA.MaxValue = 79228162514264337593543950335M;
            this.textDDPOSTOTAKIZDATKA.MinValue = -79228162514264337593543950335M;
            this.textDDPOSTOTAKIZDATKA.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformDDIZDATAK.Controls.Add(this.textDDPOSTOTAKIZDATKA, 1, 2);
            this.layoutManagerformDDIZDATAK.SetColumnSpan(this.textDDPOSTOTAKIZDATKA, 1);
            this.layoutManagerformDDIZDATAK.SetRowSpan(this.textDDPOSTOTAKIZDATKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDPOSTOTAKIZDATKA.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textDDPOSTOTAKIZDATKA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textDDPOSTOTAKIZDATKA.Size = size;
            this.Controls.Add(this.layoutManagerformDDIZDATAK);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceDDIZDATAK;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "DDIZDATAKFormUserControl";
            this.Text = "Izdaci";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.DDIZDATAKFormUserControl_Load);
            this.layoutManagerformDDIZDATAK.ResumeLayout(false);
            this.layoutManagerformDDIZDATAK.PerformLayout();
            ((ISupportInitialize) this.bindingSourceDDIZDATAK).EndInit();
            ((ISupportInitialize) this.textDDIDIZDATAK).EndInit();
            ((ISupportInitialize) this.textDDNAZIVIZDATKA).EndInit();
            ((ISupportInitialize) this.textDDPOSTOTAKIZDATKA).EndInit();
            this.dsDDIZDATAKDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.DDIZDATAKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceDDIZDATAK, this.DDIZDATAKController.WorkItem, this))
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
            this.label1DDIDIZDATAK.Text = StringResources.DDIZDATAKDDIDIZDATAKDescription;
            this.label1DDNAZIVIZDATKA.Text = StringResources.DDIZDATAKDDNAZIVIZDATKADescription;
            this.label1DDPOSTOTAKIZDATKA.Text = StringResources.DDIZDATAKDDPOSTOTAKIZDATKADescription;
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
            if (!this.DDIZDATAKController.WorkItem.Items.Contains("DDIZDATAK|DDIZDATAK"))
            {
                this.DDIZDATAKController.WorkItem.Items.Add(this.bindingSourceDDIZDATAK, "DDIZDATAK|DDIZDATAK");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsDDIZDATAKDataSet1.DDIZDATAK.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.DDIZDATAKController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DDIZDATAKController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DDIZDATAKController.Update(this))
            {
                this.DDIZDATAKController.DataSet = new DDIZDATAKDataSet();
                DataSetUtil.AddEmptyRow(this.DDIZDATAKController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.DDIZDATAKController.DataSet.DDIZDATAK[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textDDIDIZDATAK.Focus();
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.DDIZDATAKController DDIZDATAKController { get; set; }

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

        protected virtual UltraLabel label1DDIDIZDATAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDIDIZDATAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDIDIZDATAK = value;
            }
        }

        protected virtual UltraLabel label1DDNAZIVIZDATKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDNAZIVIZDATKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDNAZIVIZDATKA = value;
            }
        }

        protected virtual UltraLabel label1DDPOSTOTAKIZDATKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDPOSTOTAKIZDATKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDPOSTOTAKIZDATKA = value;
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

        protected virtual UltraNumericEditor textDDIDIZDATAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDIDIZDATAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDIDIZDATAK = value;
            }
        }

        protected virtual UltraTextEditor textDDNAZIVIZDATKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDNAZIVIZDATKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDNAZIVIZDATKA = value;
            }
        }

        protected virtual UltraNumericEditor textDDPOSTOTAKIZDATKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDPOSTOTAKIZDATKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDPOSTOTAKIZDATKA = value;
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

