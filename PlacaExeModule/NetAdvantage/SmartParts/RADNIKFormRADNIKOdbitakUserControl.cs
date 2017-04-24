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
    public class RADNIKFormRADNIKOdbitakUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1FAKTOROSOBNOGODBITKA")]
        private UltraLabel _label1FAKTOROSOBNOGODBITKA;
        [AccessedThroughProperty("label1NAZIVOSOBNIODBITAK")]
        private UltraLabel _label1NAZIVOSOBNIODBITAK;
        [AccessedThroughProperty("label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK")]
        private UltraLabel _label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK;
        [AccessedThroughProperty("labelFAKTOROSOBNOGODBITKA")]
        private UltraLabel _labelFAKTOROSOBNOGODBITKA;
        [AccessedThroughProperty("labelNAZIVOSOBNIODBITAK")]
        private UltraLabel _labelNAZIVOSOBNIODBITAK;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK")]
        private UltraNumericEditor _textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRADNIKOdbitak;
        private IContainer components = null;
        private RADNIKDataSet dsRADNIKDataSet1;
        protected TableLayoutPanel layoutManagerformRADNIKOdbitak;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RADNIKDataSet.RADNIKOdbitakRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RADNIKOdbitak";
        private string m_FrameworkDescription = StringResources.RADNIKDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        public RADNIKFormRADNIKOdbitakUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("RADNIKOdbitakAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("RADNIKOdbitakAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (RADNIKDataSet.RADNIKOdbitakRow) ((DataRowView) this.bindingSourceRADNIKOdbitak.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CallPromptOSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.RADNIKController.SelectOSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK(fillMethod, fillByRow);
            this.UpdateValuesOSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK(result);
        }

        private void CallViewOSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK(object sender, EventArgs e)
        {
            DataRow result = this.RADNIKController.ShowOSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK(this.m_CurrentRow);
            this.UpdateValuesOSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsRADNIKDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceRADNIKOdbitak.DataSource = this.RADNIKController.DataSet;
            this.dsRADNIKDataSet1 = this.RADNIKController.DataSet;
        }

        private void contextMenu1_Popup(object sender, EventArgs e)
        {
            this.m_BaseMethods.ContextMenu1PopupBase(this.contextMenu1, this.m_CurrentRow);
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
            this.dsRADNIKDataSet1 = (RADNIKDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceRADNIKOdbitak.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsRADNIKDataSet1.Tables["RADNIKOdbitak"]);
            this.bindingSourceRADNIKOdbitak.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RADNIK", this.m_Mode, this.dsRADNIKDataSet1, this.dsRADNIKDataSet1.RADNIKOdbitak.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceRADNIKOdbitak, "FAKTOROSOBNOGODBITKA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelFAKTOROSOBNOGODBITKA.DataBindings["Text"] != null)
            {
                this.labelFAKTOROSOBNOGODBITKA.DataBindings.Remove(this.labelFAKTOROSOBNOGODBITKA.DataBindings["Text"]);
            }
            this.labelFAKTOROSOBNOGODBITKA.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (RADNIKDataSet.RADNIKOdbitakRow) ((DataRowView) this.bindingSourceRADNIKOdbitak.Current).Row;
                this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (RADNIKDataSet.RADNIKOdbitakRow) ((DataRowView) this.bindingSourceRADNIKOdbitak.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(RADNIKFormRADNIKOdbitakUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRADNIKOdbitak = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRADNIKOdbitak).BeginInit();
            this.layoutManagerformRADNIKOdbitak = new TableLayoutPanel();
            this.layoutManagerformRADNIKOdbitak.SuspendLayout();
            this.layoutManagerformRADNIKOdbitak.AutoSize = true;
            this.layoutManagerformRADNIKOdbitak.Dock = DockStyle.Fill;
            this.layoutManagerformRADNIKOdbitak.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRADNIKOdbitak.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRADNIKOdbitak.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRADNIKOdbitak.Size = size;
            this.layoutManagerformRADNIKOdbitak.ColumnCount = 2;
            this.layoutManagerformRADNIKOdbitak.RowCount = 4;
            this.layoutManagerformRADNIKOdbitak.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKOdbitak.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRADNIKOdbitak.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOdbitak.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOdbitak.RowStyles.Add(new RowStyle());
            this.layoutManagerformRADNIKOdbitak.RowStyles.Add(new RowStyle());
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK = new UltraLabel();
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK = new UltraNumericEditor();
            this.label1NAZIVOSOBNIODBITAK = new UltraLabel();
            this.labelNAZIVOSOBNIODBITAK = new UltraLabel();
            this.label1FAKTOROSOBNOGODBITKA = new UltraLabel();
            this.labelFAKTOROSOBNOGODBITKA = new UltraLabel();
            ((ISupportInitialize) this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK).BeginInit();
            this.dsRADNIKDataSet1 = new RADNIKDataSet();
            this.dsRADNIKDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRADNIKDataSet1.DataSetName = "dsRADNIK";
            this.dsRADNIKDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRADNIKOdbitak.DataSource = this.dsRADNIKDataSet1;
            this.bindingSourceRADNIKOdbitak.DataMember = "RADNIKOdbitak";
            ((ISupportInitialize) this.bindingSourceRADNIKOdbitak).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Location = point;
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Name = "label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK";
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.TabIndex = 1;
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Tag = "labelOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK";
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Text = "Šifra:";
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.StyleSetName = "FieldUltraLabel";
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.AutoSize = true;
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Anchor = AnchorStyles.Left;
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Appearance.TextVAlign = VAlign.Middle;
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ImageSize = size;
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Appearance.ForeColor = Color.Black;
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOdbitak.Controls.Add(this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK, 0, 0);
            this.layoutManagerformRADNIKOdbitak.SetColumnSpan(this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK, 1);
            this.layoutManagerformRADNIKOdbitak.SetRowSpan(this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Location = point;
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Name = "textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK";
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Tag = "OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK";
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.TabIndex = 0;
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Anchor = AnchorStyles.Left;
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ReadOnly = false;
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.PromptChar = ' ';
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.DataBindings.Add(new Binding("Value", this.bindingSourceRADNIKOdbitak, "OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK"));
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.NumericType = NumericType.Integer;
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.MaskInput = "{LOC}-nnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonOSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK",
                Tag = "editorButtonOSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK",
                Text = "..."
            };
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.ButtonsRight.Add(button);
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK);
            this.layoutManagerformRADNIKOdbitak.Controls.Add(this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK, 1, 0);
            this.layoutManagerformRADNIKOdbitak.SetColumnSpan(this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK, 1);
            this.layoutManagerformRADNIKOdbitak.SetRowSpan(this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Margin = padding;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVOSOBNIODBITAK.Location = point;
            this.label1NAZIVOSOBNIODBITAK.Name = "label1NAZIVOSOBNIODBITAK";
            this.label1NAZIVOSOBNIODBITAK.TabIndex = 1;
            this.label1NAZIVOSOBNIODBITAK.Tag = "labelNAZIVOSOBNIODBITAK";
            this.label1NAZIVOSOBNIODBITAK.Text = "Naziv OD:";
            this.label1NAZIVOSOBNIODBITAK.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVOSOBNIODBITAK.AutoSize = true;
            this.label1NAZIVOSOBNIODBITAK.Anchor = AnchorStyles.Left;
            this.label1NAZIVOSOBNIODBITAK.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVOSOBNIODBITAK.Appearance.ForeColor = Color.Black;
            this.label1NAZIVOSOBNIODBITAK.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOdbitak.Controls.Add(this.label1NAZIVOSOBNIODBITAK, 0, 1);
            this.layoutManagerformRADNIKOdbitak.SetColumnSpan(this.label1NAZIVOSOBNIODBITAK, 1);
            this.layoutManagerformRADNIKOdbitak.SetRowSpan(this.label1NAZIVOSOBNIODBITAK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVOSOBNIODBITAK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVOSOBNIODBITAK.MinimumSize = size;
            size = new System.Drawing.Size(0x4c, 0x17);
            this.label1NAZIVOSOBNIODBITAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVOSOBNIODBITAK.Location = point;
            this.labelNAZIVOSOBNIODBITAK.Name = "labelNAZIVOSOBNIODBITAK";
            this.labelNAZIVOSOBNIODBITAK.Tag = "NAZIVOSOBNIODBITAK";
            this.labelNAZIVOSOBNIODBITAK.TabIndex = 0;
            this.labelNAZIVOSOBNIODBITAK.Anchor = AnchorStyles.Left;
            this.labelNAZIVOSOBNIODBITAK.BackColor = Color.Transparent;
            this.labelNAZIVOSOBNIODBITAK.DataBindings.Add(new Binding("Text", this.bindingSourceRADNIKOdbitak, "NAZIVOSOBNIODBITAK"));
            this.labelNAZIVOSOBNIODBITAK.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKOdbitak.Controls.Add(this.labelNAZIVOSOBNIODBITAK, 1, 1);
            this.layoutManagerformRADNIKOdbitak.SetColumnSpan(this.labelNAZIVOSOBNIODBITAK, 1);
            this.layoutManagerformRADNIKOdbitak.SetRowSpan(this.labelNAZIVOSOBNIODBITAK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVOSOBNIODBITAK.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVOSOBNIODBITAK.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVOSOBNIODBITAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1FAKTOROSOBNOGODBITKA.Location = point;
            this.label1FAKTOROSOBNOGODBITKA.Name = "label1FAKTOROSOBNOGODBITKA";
            this.label1FAKTOROSOBNOGODBITKA.TabIndex = 1;
            this.label1FAKTOROSOBNOGODBITKA.Tag = "labelFAKTOROSOBNOGODBITKA";
            this.label1FAKTOROSOBNOGODBITKA.Text = "Faktor:";
            this.label1FAKTOROSOBNOGODBITKA.StyleSetName = "FieldUltraLabel";
            this.label1FAKTOROSOBNOGODBITKA.AutoSize = true;
            this.label1FAKTOROSOBNOGODBITKA.Anchor = AnchorStyles.Left;
            this.label1FAKTOROSOBNOGODBITKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1FAKTOROSOBNOGODBITKA.Appearance.ForeColor = Color.Black;
            this.label1FAKTOROSOBNOGODBITKA.BackColor = Color.Transparent;
            this.layoutManagerformRADNIKOdbitak.Controls.Add(this.label1FAKTOROSOBNOGODBITKA, 0, 2);
            this.layoutManagerformRADNIKOdbitak.SetColumnSpan(this.label1FAKTOROSOBNOGODBITKA, 1);
            this.layoutManagerformRADNIKOdbitak.SetRowSpan(this.label1FAKTOROSOBNOGODBITKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1FAKTOROSOBNOGODBITKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1FAKTOROSOBNOGODBITKA.MinimumSize = size;
            size = new System.Drawing.Size(0x3b, 0x17);
            this.label1FAKTOROSOBNOGODBITKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelFAKTOROSOBNOGODBITKA.Location = point;
            this.labelFAKTOROSOBNOGODBITKA.Name = "labelFAKTOROSOBNOGODBITKA";
            this.labelFAKTOROSOBNOGODBITKA.Tag = "FAKTOROSOBNOGODBITKA";
            this.labelFAKTOROSOBNOGODBITKA.TabIndex = 0;
            this.labelFAKTOROSOBNOGODBITKA.Anchor = AnchorStyles.Left;
            this.labelFAKTOROSOBNOGODBITKA.BackColor = Color.Transparent;
            this.labelFAKTOROSOBNOGODBITKA.Appearance.TextHAlign = HAlign.Left;
            this.labelFAKTOROSOBNOGODBITKA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRADNIKOdbitak.Controls.Add(this.labelFAKTOROSOBNOGODBITKA, 1, 2);
            this.layoutManagerformRADNIKOdbitak.SetColumnSpan(this.labelFAKTOROSOBNOGODBITKA, 1);
            this.layoutManagerformRADNIKOdbitak.SetRowSpan(this.labelFAKTOROSOBNOGODBITKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelFAKTOROSOBNOGODBITKA.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.labelFAKTOROSOBNOGODBITKA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.labelFAKTOROSOBNOGODBITKA.Size = size;
            this.Controls.Add(this.layoutManagerformRADNIKOdbitak);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRADNIKOdbitak;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "RADNIKFormRADNIKOdbitakUserControl";
            this.Text = " Osobni odbici radnika";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RADNIKFormUserControl_Load);
            this.layoutManagerformRADNIKOdbitak.ResumeLayout(false);
            this.layoutManagerformRADNIKOdbitak.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRADNIKOdbitak).EndInit();
            ((ISupportInitialize) this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK).EndInit();
            this.dsRADNIKDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RADNIKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRADNIKOdbitak, this.RADNIKController.WorkItem, this))
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
            this.label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Text = StringResources.RADNIKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAKDescription;
            this.label1NAZIVOSOBNIODBITAK.Text = StringResources.RADNIKNAZIVOSOBNIODBITAKDescription;
            this.label1FAKTOROSOBNOGODBITKA.Text = StringResources.RADNIKFAKTOROSOBNOGODBITKADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewGOOBRACUN")]
        public void NewGOOBRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.NewGOOBRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewOTISLI")]
        public void NewOTISLIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.NewOTISLI(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewZAPOSLENI")]
        public void NewZAPOSLENIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.NewZAPOSLENI(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RADNIKFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RADNIKRADNIKOdbitakLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.RADNIKController.WorkItem.Items.Contains("RADNIKOdbitak|RADNIKOdbitak"))
            {
                this.RADNIKController.WorkItem.Items.Add(this.bindingSourceRADNIKOdbitak, "RADNIKOdbitak|RADNIKOdbitak");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("RADNIKOdbitakSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetFocusInFirstField()
        {
            this.textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK.Focus();
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

        private void UpdateValuesOSOBNIODBITAKOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceRADNIKOdbitak.Current).Row["OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK"] = RuntimeHelpers.GetObjectValue(result["IDOSOBNIODBITAK"]);
                ((DataRowView) this.bindingSourceRADNIKOdbitak.Current).Row["NAZIVOSOBNIODBITAK"] = RuntimeHelpers.GetObjectValue(result["NAZIVOSOBNIODBITAK"]);
                ((DataRowView) this.bindingSourceRADNIKOdbitak.Current).Row["FAKTOROSOBNOGODBITKA"] = RuntimeHelpers.GetObjectValue(result["FAKTOROSOBNOGODBITKA"]);
                this.bindingSourceRADNIKOdbitak.ResetCurrentItem();
            }
        }

        [LocalCommandHandler("ViewGOOBRACUN")]
        public void ViewGOOBRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.ViewGOOBRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewOTISLI")]
        public void ViewOTISLIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.ViewOTISLI(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewZAPOSLENI")]
        public void ViewZAPOSLENIHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RADNIKController.ViewZAPOSLENI(this.m_CurrentRow);
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

        protected virtual UltraLabel label1FAKTOROSOBNOGODBITKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1FAKTOROSOBNOGODBITKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1FAKTOROSOBNOGODBITKA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVOSOBNIODBITAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVOSOBNIODBITAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVOSOBNIODBITAK = value;
            }
        }

        protected virtual UltraLabel label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK = value;
            }
        }

        protected virtual UltraLabel labelFAKTOROSOBNOGODBITKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelFAKTOROSOBNOGODBITKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelFAKTOROSOBNOGODBITKA = value;
            }
        }

        protected virtual UltraLabel labelNAZIVOSOBNIODBITAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVOSOBNIODBITAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVOSOBNIODBITAK = value;
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
        public NetAdvantage.Controllers.RADNIKController RADNIKController { get; set; }

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

        protected virtual UltraNumericEditor textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK = value;
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

