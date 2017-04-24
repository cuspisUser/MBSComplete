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
    public class DDKATEGORIJAFormDDKATEGORIJAIzdaciUserControl : UserControl, IBusinessComponentUserControl
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
        [AccessedThroughProperty("labelDDNAZIVIZDATKA")]
        private UltraLabel _labelDDNAZIVIZDATKA;
        [AccessedThroughProperty("labelDDPOSTOTAKIZDATKA")]
        private UltraLabel _labelDDPOSTOTAKIZDATKA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textDDIDIZDATAK")]
        private UltraNumericEditor _textDDIDIZDATAK;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceDDKATEGORIJAIzdaci;
        private IContainer components = null;
        private DDKATEGORIJADataSet dsDDKATEGORIJADataSet1;
        protected TableLayoutPanel layoutManagerformDDKATEGORIJAIzdaci;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "DDKATEGORIJAIzdaci";
        private string m_FrameworkDescription = StringResources.DDKATEGORIJADescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        public DDKATEGORIJAFormDDKATEGORIJAIzdaciUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("DDKATEGORIJAIzdaciAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("DDKATEGORIJAIzdaciAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow) ((DataRowView) this.bindingSourceDDKATEGORIJAIzdaci.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CallPromptDDIZDATAKDDIDIZDATAK(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.Controller.SelectDDIZDATAKDDIDIZDATAK(fillMethod, fillByRow);
            this.UpdateValuesDDIZDATAKDDIDIZDATAK(result);
        }

        private void CallViewDDIZDATAKDDIDIZDATAK(object sender, EventArgs e)
        {
            DataRow result = this.Controller.ShowDDIZDATAKDDIDIZDATAK(this.m_CurrentRow);
            this.UpdateValuesDDIZDATAKDDIDIZDATAK(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsDDKATEGORIJADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceDDKATEGORIJAIzdaci.DataSource = this.Controller.DataSet;
            this.dsDDKATEGORIJADataSet1 = this.Controller.DataSet;
        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            this.m_BaseMethods.ContextMenu1PopupBase(this.contextMenu1, this.m_CurrentRow);
        }

        private void DDKATEGORIJAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.DDKATEGORIJADDKATEGORIJAIzdaciLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EndEditCurrentRow()
        {
        }

        public void Initialize(DeklaritMode mode, DataRow parentRow, bool isCopy)
        {
            this.m_ParentRow = parentRow;
            this.dsDDKATEGORIJADataSet1 = (DDKATEGORIJADataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceDDKATEGORIJAIzdaci.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsDDKATEGORIJADataSet1.Tables["DDKATEGORIJAIzdaci"]);
            this.bindingSourceDDKATEGORIJAIzdaci.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "DDKATEGORIJA", this.m_Mode, this.dsDDKATEGORIJADataSet1, this.dsDDKATEGORIJADataSet1.DDKATEGORIJAIzdaci.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceDDKATEGORIJAIzdaci, "DDPOSTOTAKIZDATKA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelDDPOSTOTAKIZDATKA.DataBindings["Text"] != null)
            {
                this.labelDDPOSTOTAKIZDATKA.DataBindings.Remove(this.labelDDPOSTOTAKIZDATKA.DataBindings["Text"]);
            }
            this.labelDDPOSTOTAKIZDATKA.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow) ((DataRowView) this.bindingSourceDDKATEGORIJAIzdaci.Current).Row;
                this.textDDIDIZDATAK.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textDDIDIZDATAK.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (DDKATEGORIJADataSet.DDKATEGORIJAIzdaciRow) ((DataRowView) this.bindingSourceDDKATEGORIJAIzdaci.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(DDKATEGORIJAFormDDKATEGORIJAIzdaciUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceDDKATEGORIJAIzdaci = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDDKATEGORIJAIzdaci).BeginInit();
            this.layoutManagerformDDKATEGORIJAIzdaci = new TableLayoutPanel();
            this.layoutManagerformDDKATEGORIJAIzdaci.SuspendLayout();
            this.layoutManagerformDDKATEGORIJAIzdaci.AutoSize = true;
            this.layoutManagerformDDKATEGORIJAIzdaci.Dock = DockStyle.Fill;
            this.layoutManagerformDDKATEGORIJAIzdaci.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformDDKATEGORIJAIzdaci.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformDDKATEGORIJAIzdaci.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformDDKATEGORIJAIzdaci.Size = size;
            this.layoutManagerformDDKATEGORIJAIzdaci.ColumnCount = 2;
            this.layoutManagerformDDKATEGORIJAIzdaci.RowCount = 4;
            this.layoutManagerformDDKATEGORIJAIzdaci.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDDKATEGORIJAIzdaci.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDDKATEGORIJAIzdaci.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDKATEGORIJAIzdaci.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDKATEGORIJAIzdaci.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDKATEGORIJAIzdaci.RowStyles.Add(new RowStyle());
            this.label1DDIDIZDATAK = new UltraLabel();
            this.textDDIDIZDATAK = new UltraNumericEditor();
            this.label1DDNAZIVIZDATKA = new UltraLabel();
            this.labelDDNAZIVIZDATKA = new UltraLabel();
            this.label1DDPOSTOTAKIZDATKA = new UltraLabel();
            this.labelDDPOSTOTAKIZDATKA = new UltraLabel();
            ((ISupportInitialize) this.textDDIDIZDATAK).BeginInit();
            this.dsDDKATEGORIJADataSet1 = new DDKATEGORIJADataSet();
            this.dsDDKATEGORIJADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsDDKATEGORIJADataSet1.DataSetName = "dsDDKATEGORIJA";
            this.dsDDKATEGORIJADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceDDKATEGORIJAIzdaci.DataSource = this.dsDDKATEGORIJADataSet1;
            this.bindingSourceDDKATEGORIJAIzdaci.DataMember = "DDKATEGORIJAIzdaci";
            ((ISupportInitialize) this.bindingSourceDDKATEGORIJAIzdaci).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1DDIDIZDATAK.Location = point;
            this.label1DDIDIZDATAK.Name = "label1DDIDIZDATAK";
            this.label1DDIDIZDATAK.TabIndex = 1;
            this.label1DDIDIZDATAK.Tag = "labelDDIDIZDATAK";
            this.label1DDIDIZDATAK.Text = "Šifra:";
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
            this.layoutManagerformDDKATEGORIJAIzdaci.Controls.Add(this.label1DDIDIZDATAK, 0, 0);
            this.layoutManagerformDDKATEGORIJAIzdaci.SetColumnSpan(this.label1DDIDIZDATAK, 1);
            this.layoutManagerformDDKATEGORIJAIzdaci.SetRowSpan(this.label1DDIDIZDATAK, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1DDIDIZDATAK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDIDIZDATAK.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
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
            this.textDDIDIZDATAK.DataBindings.Add(new Binding("Value", this.bindingSourceDDKATEGORIJAIzdaci, "DDIDIZDATAK"));
            this.textDDIDIZDATAK.NumericType = NumericType.Integer;
            this.textDDIDIZDATAK.MaskInput = "{LOC}-nnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonDDIZDATAKDDIDIZDATAK",
                Tag = "editorButtonDDIZDATAKDDIDIZDATAK",
                Text = "..."
            };
            this.textDDIDIZDATAK.ButtonsRight.Add(button);
            this.textDDIDIZDATAK.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptDDIZDATAKDDIDIZDATAK);
            this.layoutManagerformDDKATEGORIJAIzdaci.Controls.Add(this.textDDIDIZDATAK, 1, 0);
            this.layoutManagerformDDKATEGORIJAIzdaci.SetColumnSpan(this.textDDIDIZDATAK, 1);
            this.layoutManagerformDDKATEGORIJAIzdaci.SetRowSpan(this.textDDIDIZDATAK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDIDIZDATAK.Margin = padding;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textDDIDIZDATAK.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x16);
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
            this.layoutManagerformDDKATEGORIJAIzdaci.Controls.Add(this.label1DDNAZIVIZDATKA, 0, 1);
            this.layoutManagerformDDKATEGORIJAIzdaci.SetColumnSpan(this.label1DDNAZIVIZDATKA, 1);
            this.layoutManagerformDDKATEGORIJAIzdaci.SetRowSpan(this.label1DDNAZIVIZDATKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDNAZIVIZDATKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDNAZIVIZDATKA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x17);
            this.label1DDNAZIVIZDATKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelDDNAZIVIZDATKA.Location = point;
            this.labelDDNAZIVIZDATKA.Name = "labelDDNAZIVIZDATKA";
            this.labelDDNAZIVIZDATKA.Tag = "DDNAZIVIZDATKA";
            this.labelDDNAZIVIZDATKA.TabIndex = 0;
            this.labelDDNAZIVIZDATKA.Anchor = AnchorStyles.Left;
            this.labelDDNAZIVIZDATKA.BackColor = Color.Transparent;
            this.labelDDNAZIVIZDATKA.DataBindings.Add(new Binding("Text", this.bindingSourceDDKATEGORIJAIzdaci, "DDNAZIVIZDATKA"));
            this.labelDDNAZIVIZDATKA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformDDKATEGORIJAIzdaci.Controls.Add(this.labelDDNAZIVIZDATKA, 1, 1);
            this.layoutManagerformDDKATEGORIJAIzdaci.SetColumnSpan(this.labelDDNAZIVIZDATKA, 1);
            this.layoutManagerformDDKATEGORIJAIzdaci.SetRowSpan(this.labelDDNAZIVIZDATKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelDDNAZIVIZDATKA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelDDNAZIVIZDATKA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelDDNAZIVIZDATKA.Size = size;
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
            this.layoutManagerformDDKATEGORIJAIzdaci.Controls.Add(this.label1DDPOSTOTAKIZDATKA, 0, 2);
            this.layoutManagerformDDKATEGORIJAIzdaci.SetColumnSpan(this.label1DDPOSTOTAKIZDATKA, 1);
            this.layoutManagerformDDKATEGORIJAIzdaci.SetRowSpan(this.label1DDPOSTOTAKIZDATKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDPOSTOTAKIZDATKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDPOSTOTAKIZDATKA.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1DDPOSTOTAKIZDATKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelDDPOSTOTAKIZDATKA.Location = point;
            this.labelDDPOSTOTAKIZDATKA.Name = "labelDDPOSTOTAKIZDATKA";
            this.labelDDPOSTOTAKIZDATKA.Tag = "DDPOSTOTAKIZDATKA";
            this.labelDDPOSTOTAKIZDATKA.TabIndex = 0;
            this.labelDDPOSTOTAKIZDATKA.Anchor = AnchorStyles.Left;
            this.labelDDPOSTOTAKIZDATKA.BackColor = Color.Transparent;
            this.labelDDPOSTOTAKIZDATKA.Appearance.TextHAlign = HAlign.Left;
            this.labelDDPOSTOTAKIZDATKA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformDDKATEGORIJAIzdaci.Controls.Add(this.labelDDPOSTOTAKIZDATKA, 1, 2);
            this.layoutManagerformDDKATEGORIJAIzdaci.SetColumnSpan(this.labelDDPOSTOTAKIZDATKA, 1);
            this.layoutManagerformDDKATEGORIJAIzdaci.SetRowSpan(this.labelDDPOSTOTAKIZDATKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelDDPOSTOTAKIZDATKA.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.labelDDPOSTOTAKIZDATKA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.labelDDPOSTOTAKIZDATKA.Size = size;
            this.Controls.Add(this.layoutManagerformDDKATEGORIJAIzdaci);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceDDKATEGORIJAIzdaci;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "DDKATEGORIJAFormDDKATEGORIJAIzdaciUserControl";
            this.Text = " Izdaci";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.DDKATEGORIJAFormUserControl_Load);
            this.layoutManagerformDDKATEGORIJAIzdaci.ResumeLayout(false);
            this.layoutManagerformDDKATEGORIJAIzdaci.PerformLayout();
            ((ISupportInitialize) this.bindingSourceDDKATEGORIJAIzdaci).EndInit();
            ((ISupportInitialize) this.textDDIDIZDATAK).EndInit();
            this.dsDDKATEGORIJADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.Controller.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceDDKATEGORIJAIzdaci, this.Controller.WorkItem, this))
            {
                return false;
            }
            this.EndEditCurrentRow();
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void Localize()
        {
            this.label1DDIDIZDATAK.Text = StringResources.DDKATEGORIJADDIDIZDATAKDescription;
            this.label1DDNAZIVIZDATKA.Text = StringResources.DDKATEGORIJADDNAZIVIZDATKADescription;
            this.label1DDPOSTOTAKIZDATKA.Text = StringResources.DDKATEGORIJADDPOSTOTAKIZDATKADescription;
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
            if (!this.Controller.WorkItem.Items.Contains("DDKATEGORIJAIzdaci|DDKATEGORIJAIzdaci"))
            {
                this.Controller.WorkItem.Items.Add(this.bindingSourceDDKATEGORIJAIzdaci, "DDKATEGORIJAIzdaci|DDKATEGORIJAIzdaci");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("DDKATEGORIJAIzdaciSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
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

        private void UpdateValuesDDIZDATAKDDIDIZDATAK(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceDDKATEGORIJAIzdaci.Current).Row["DDIDIZDATAK"] = RuntimeHelpers.GetObjectValue(result["DDIDIZDATAK"]);
                ((DataRowView) this.bindingSourceDDKATEGORIJAIzdaci.Current).Row["DDNAZIVIZDATKA"] = RuntimeHelpers.GetObjectValue(result["DDNAZIVIZDATKA"]);
                ((DataRowView) this.bindingSourceDDKATEGORIJAIzdaci.Current).Row["DDPOSTOTAKIZDATKA"] = RuntimeHelpers.GetObjectValue(result["DDPOSTOTAKIZDATKA"]);
                this.bindingSourceDDKATEGORIJAIzdaci.ResetCurrentItem();
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.DDKATEGORIJAController Controller { get; set; }

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

        protected virtual UltraLabel labelDDNAZIVIZDATKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelDDNAZIVIZDATKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelDDNAZIVIZDATKA = value;
            }
        }

        protected virtual UltraLabel labelDDPOSTOTAKIZDATKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelDDPOSTOTAKIZDATKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelDDPOSTOTAKIZDATKA = value;
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

