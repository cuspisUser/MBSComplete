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
    public class SKUPPOREZAIDOPRINOSAFormSKUPPOREZAIDOPRINOSA1UserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDPOREZ")]
        private UltraLabel _label1IDPOREZ;
        [AccessedThroughProperty("label1MOPOREZ")]
        private UltraLabel _label1MOPOREZ;
        [AccessedThroughProperty("label1MZPOREZ")]
        private UltraLabel _label1MZPOREZ;
        [AccessedThroughProperty("label1NAZIVPOREZ")]
        private UltraLabel _label1NAZIVPOREZ;
        [AccessedThroughProperty("label1OPISPLACANJAPOREZ")]
        private UltraLabel _label1OPISPLACANJAPOREZ;
        [AccessedThroughProperty("label1POPOREZ")]
        private UltraLabel _label1POPOREZ;
        [AccessedThroughProperty("label1POREZMJESECNO")]
        private UltraLabel _label1POREZMJESECNO;
        [AccessedThroughProperty("label1PRIMATELJPOREZ1")]
        private UltraLabel _label1PRIMATELJPOREZ1;
        [AccessedThroughProperty("label1PRIMATELJPOREZ2")]
        private UltraLabel _label1PRIMATELJPOREZ2;
        [AccessedThroughProperty("label1PZPOREZ")]
        private UltraLabel _label1PZPOREZ;
        [AccessedThroughProperty("label1SIFRAOPISAPLACANJAPOREZ")]
        private UltraLabel _label1SIFRAOPISAPLACANJAPOREZ;
        [AccessedThroughProperty("label1STOPAPOREZA")]
        private UltraLabel _label1STOPAPOREZA;
        [AccessedThroughProperty("labelMOPOREZ")]
        private UltraLabel _labelMOPOREZ;
        [AccessedThroughProperty("labelMZPOREZ")]
        private UltraLabel _labelMZPOREZ;
        [AccessedThroughProperty("labelNAZIVPOREZ")]
        private UltraLabel _labelNAZIVPOREZ;
        [AccessedThroughProperty("labelOPISPLACANJAPOREZ")]
        private UltraLabel _labelOPISPLACANJAPOREZ;
        [AccessedThroughProperty("labelPOPOREZ")]
        private UltraLabel _labelPOPOREZ;
        [AccessedThroughProperty("labelPOREZMJESECNO")]
        private UltraLabel _labelPOREZMJESECNO;
        [AccessedThroughProperty("labelPRIMATELJPOREZ1")]
        private UltraLabel _labelPRIMATELJPOREZ1;
        [AccessedThroughProperty("labelPRIMATELJPOREZ2")]
        private UltraLabel _labelPRIMATELJPOREZ2;
        [AccessedThroughProperty("labelPZPOREZ")]
        private UltraLabel _labelPZPOREZ;
        [AccessedThroughProperty("labelSIFRAOPISAPLACANJAPOREZ")]
        private UltraLabel _labelSIFRAOPISAPLACANJAPOREZ;
        [AccessedThroughProperty("labelSTOPAPOREZA")]
        private UltraLabel _labelSTOPAPOREZA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDPOREZ")]
        private UltraNumericEditor _textIDPOREZ;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSKUPPOREZAIDOPRINOSA1;
        private IContainer components = null;
        private SKUPPOREZAIDOPRINOSADataSet dsSKUPPOREZAIDOPRINOSADataSet1;
        protected TableLayoutPanel layoutManagerformSKUPPOREZAIDOPRINOSA1;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SKUPPOREZAIDOPRINOSA1";
        private string m_FrameworkDescription = StringResources.SKUPPOREZAIDOPRINOSADescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        public SKUPPOREZAIDOPRINOSAFormSKUPPOREZAIDOPRINOSA1UserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("SKUPPOREZAIDOPRINOSA1AddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SKUPPOREZAIDOPRINOSA1AddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row) ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA1.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CallPromptPOREZIDPOREZ(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.SKUPPOREZAIDOPRINOSAController.SelectPOREZIDPOREZ(fillMethod, fillByRow);
            this.UpdateValuesPOREZIDPOREZ(result);
        }

        private void CallViewPOREZIDPOREZ(object sender, EventArgs e)
        {
            DataRow result = this.SKUPPOREZAIDOPRINOSAController.ShowPOREZIDPOREZ(this.m_CurrentRow);
            this.UpdateValuesPOREZIDPOREZ(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsSKUPPOREZAIDOPRINOSADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceSKUPPOREZAIDOPRINOSA1.DataSource = this.SKUPPOREZAIDOPRINOSAController.DataSet;
            this.dsSKUPPOREZAIDOPRINOSADataSet1 = this.SKUPPOREZAIDOPRINOSAController.DataSet;
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
            this.dsSKUPPOREZAIDOPRINOSADataSet1 = (SKUPPOREZAIDOPRINOSADataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceSKUPPOREZAIDOPRINOSA1.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsSKUPPOREZAIDOPRINOSADataSet1.Tables["SKUPPOREZAIDOPRINOSA1"]);
            this.bindingSourceSKUPPOREZAIDOPRINOSA1.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SKUPPOREZAIDOPRINOSA", this.m_Mode, this.dsSKUPPOREZAIDOPRINOSADataSet1, this.dsSKUPPOREZAIDOPRINOSADataSet1.SKUPPOREZAIDOPRINOSA1.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA1, "POREZMJESECNO", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelPOREZMJESECNO.DataBindings["Text"] != null)
            {
                this.labelPOREZMJESECNO.DataBindings.Remove(this.labelPOREZMJESECNO.DataBindings["Text"]);
            }
            this.labelPOREZMJESECNO.DataBindings.Add(binding);
            Binding binding2 = new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA1, "STOPAPOREZA", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelSTOPAPOREZA.DataBindings["Text"] != null)
            {
                this.labelSTOPAPOREZA.DataBindings.Remove(this.labelSTOPAPOREZA.DataBindings["Text"]);
            }
            this.labelSTOPAPOREZA.DataBindings.Add(binding2);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row) ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA1.Current).Row;
                this.textIDPOREZ.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textIDPOREZ.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSA1Row) ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA1.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(SKUPPOREZAIDOPRINOSAFormSKUPPOREZAIDOPRINOSA1UserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSKUPPOREZAIDOPRINOSA1 = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSKUPPOREZAIDOPRINOSA1).BeginInit();
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1 = new TableLayoutPanel();
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SuspendLayout();
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.AutoSize = true;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Dock = DockStyle.Fill;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Size = size;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.ColumnCount = 2;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.RowCount = 13;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.RowStyles.Add(new RowStyle());
            this.label1IDPOREZ = new UltraLabel();
            this.textIDPOREZ = new UltraNumericEditor();
            this.label1NAZIVPOREZ = new UltraLabel();
            this.labelNAZIVPOREZ = new UltraLabel();
            this.label1POREZMJESECNO = new UltraLabel();
            this.labelPOREZMJESECNO = new UltraLabel();
            this.label1STOPAPOREZA = new UltraLabel();
            this.labelSTOPAPOREZA = new UltraLabel();
            this.label1MOPOREZ = new UltraLabel();
            this.labelMOPOREZ = new UltraLabel();
            this.label1POPOREZ = new UltraLabel();
            this.labelPOPOREZ = new UltraLabel();
            this.label1MZPOREZ = new UltraLabel();
            this.labelMZPOREZ = new UltraLabel();
            this.label1PZPOREZ = new UltraLabel();
            this.labelPZPOREZ = new UltraLabel();
            this.label1PRIMATELJPOREZ1 = new UltraLabel();
            this.labelPRIMATELJPOREZ1 = new UltraLabel();
            this.label1PRIMATELJPOREZ2 = new UltraLabel();
            this.labelPRIMATELJPOREZ2 = new UltraLabel();
            this.label1SIFRAOPISAPLACANJAPOREZ = new UltraLabel();
            this.labelSIFRAOPISAPLACANJAPOREZ = new UltraLabel();
            this.label1OPISPLACANJAPOREZ = new UltraLabel();
            this.labelOPISPLACANJAPOREZ = new UltraLabel();
            ((ISupportInitialize) this.textIDPOREZ).BeginInit();
            this.dsSKUPPOREZAIDOPRINOSADataSet1 = new SKUPPOREZAIDOPRINOSADataSet();
            this.dsSKUPPOREZAIDOPRINOSADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSKUPPOREZAIDOPRINOSADataSet1.DataSetName = "dsSKUPPOREZAIDOPRINOSA";
            this.dsSKUPPOREZAIDOPRINOSADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSKUPPOREZAIDOPRINOSA1.DataSource = this.dsSKUPPOREZAIDOPRINOSADataSet1;
            this.bindingSourceSKUPPOREZAIDOPRINOSA1.DataMember = "SKUPPOREZAIDOPRINOSA1";
            ((ISupportInitialize) this.bindingSourceSKUPPOREZAIDOPRINOSA1).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDPOREZ.Location = point;
            this.label1IDPOREZ.Name = "label1IDPOREZ";
            this.label1IDPOREZ.TabIndex = 1;
            this.label1IDPOREZ.Tag = "labelIDPOREZ";
            this.label1IDPOREZ.Text = "Šifra poreza:";
            this.label1IDPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1IDPOREZ.AutoSize = true;
            this.label1IDPOREZ.Anchor = AnchorStyles.Left;
            this.label1IDPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDPOREZ.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDPOREZ.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDPOREZ.ImageSize = size;
            this.label1IDPOREZ.Appearance.ForeColor = Color.Black;
            this.label1IDPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.label1IDPOREZ, 0, 0);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.label1IDPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.label1IDPOREZ, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x5b, 0x17);
            this.label1IDPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDPOREZ.Location = point;
            this.textIDPOREZ.Name = "textIDPOREZ";
            this.textIDPOREZ.Tag = "IDPOREZ";
            this.textIDPOREZ.TabIndex = 0;
            this.textIDPOREZ.Anchor = AnchorStyles.Left;
            this.textIDPOREZ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDPOREZ.ReadOnly = false;
            this.textIDPOREZ.PromptChar = ' ';
            this.textIDPOREZ.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDPOREZ.DataBindings.Add(new Binding("Value", this.bindingSourceSKUPPOREZAIDOPRINOSA1, "IDPOREZ"));
            this.textIDPOREZ.NumericType = NumericType.Integer;
            this.textIDPOREZ.MaskInput = "{LOC}-nnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonPOREZIDPOREZ",
                Tag = "editorButtonPOREZIDPOREZ",
                Text = "..."
            };
            this.textIDPOREZ.ButtonsRight.Add(button);
            this.textIDPOREZ.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptPOREZIDPOREZ);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.textIDPOREZ, 1, 0);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.textIDPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.textIDPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDPOREZ.Margin = padding;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVPOREZ.Location = point;
            this.label1NAZIVPOREZ.Name = "label1NAZIVPOREZ";
            this.label1NAZIVPOREZ.TabIndex = 1;
            this.label1NAZIVPOREZ.Tag = "labelNAZIVPOREZ";
            this.label1NAZIVPOREZ.Text = "Naziv poreza:";
            this.label1NAZIVPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVPOREZ.AutoSize = true;
            this.label1NAZIVPOREZ.Anchor = AnchorStyles.Left;
            this.label1NAZIVPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVPOREZ.Appearance.ForeColor = Color.Black;
            this.label1NAZIVPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.label1NAZIVPOREZ, 0, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.label1NAZIVPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.label1NAZIVPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x63, 0x17);
            this.label1NAZIVPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVPOREZ.Location = point;
            this.labelNAZIVPOREZ.Name = "labelNAZIVPOREZ";
            this.labelNAZIVPOREZ.Tag = "NAZIVPOREZ";
            this.labelNAZIVPOREZ.TabIndex = 0;
            this.labelNAZIVPOREZ.Anchor = AnchorStyles.Left;
            this.labelNAZIVPOREZ.BackColor = Color.Transparent;
            this.labelNAZIVPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA1, "NAZIVPOREZ"));
            this.labelNAZIVPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.labelNAZIVPOREZ, 1, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.labelNAZIVPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.labelNAZIVPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVPOREZ.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POREZMJESECNO.Location = point;
            this.label1POREZMJESECNO.Name = "label1POREZMJESECNO";
            this.label1POREZMJESECNO.TabIndex = 1;
            this.label1POREZMJESECNO.Tag = "labelPOREZMJESECNO";
            this.label1POREZMJESECNO.Text = "Maks. mjesečni iznos osnovice:";
            this.label1POREZMJESECNO.StyleSetName = "FieldUltraLabel";
            this.label1POREZMJESECNO.AutoSize = true;
            this.label1POREZMJESECNO.Anchor = AnchorStyles.Left;
            this.label1POREZMJESECNO.Appearance.TextVAlign = VAlign.Middle;
            this.label1POREZMJESECNO.Appearance.ForeColor = Color.Black;
            this.label1POREZMJESECNO.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.label1POREZMJESECNO, 0, 2);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.label1POREZMJESECNO, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.label1POREZMJESECNO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POREZMJESECNO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POREZMJESECNO.MinimumSize = size;
            size = new System.Drawing.Size(0xd0, 0x17);
            this.label1POREZMJESECNO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPOREZMJESECNO.Location = point;
            this.labelPOREZMJESECNO.Name = "labelPOREZMJESECNO";
            this.labelPOREZMJESECNO.Tag = "POREZMJESECNO";
            this.labelPOREZMJESECNO.TabIndex = 0;
            this.labelPOREZMJESECNO.Anchor = AnchorStyles.Left;
            this.labelPOREZMJESECNO.BackColor = Color.Transparent;
            this.labelPOREZMJESECNO.Appearance.TextHAlign = HAlign.Left;
            this.labelPOREZMJESECNO.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.labelPOREZMJESECNO, 1, 2);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.labelPOREZMJESECNO, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.labelPOREZMJESECNO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPOREZMJESECNO.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelPOREZMJESECNO.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelPOREZMJESECNO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1STOPAPOREZA.Location = point;
            this.label1STOPAPOREZA.Name = "label1STOPAPOREZA";
            this.label1STOPAPOREZA.TabIndex = 1;
            this.label1STOPAPOREZA.Tag = "labelSTOPAPOREZA";
            this.label1STOPAPOREZA.Text = "Stopa poreza:";
            this.label1STOPAPOREZA.StyleSetName = "FieldUltraLabel";
            this.label1STOPAPOREZA.AutoSize = true;
            this.label1STOPAPOREZA.Anchor = AnchorStyles.Left;
            this.label1STOPAPOREZA.Appearance.TextVAlign = VAlign.Middle;
            this.label1STOPAPOREZA.Appearance.ForeColor = Color.Black;
            this.label1STOPAPOREZA.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.label1STOPAPOREZA, 0, 3);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.label1STOPAPOREZA, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.label1STOPAPOREZA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1STOPAPOREZA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1STOPAPOREZA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x17);
            this.label1STOPAPOREZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelSTOPAPOREZA.Location = point;
            this.labelSTOPAPOREZA.Name = "labelSTOPAPOREZA";
            this.labelSTOPAPOREZA.Tag = "STOPAPOREZA";
            this.labelSTOPAPOREZA.TabIndex = 0;
            this.labelSTOPAPOREZA.Anchor = AnchorStyles.Left;
            this.labelSTOPAPOREZA.BackColor = Color.Transparent;
            this.labelSTOPAPOREZA.Appearance.TextHAlign = HAlign.Left;
            this.labelSTOPAPOREZA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.labelSTOPAPOREZA, 1, 3);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.labelSTOPAPOREZA, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.labelSTOPAPOREZA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelSTOPAPOREZA.Margin = padding;
            size = new System.Drawing.Size(0x30, 0x16);
            this.labelSTOPAPOREZA.MinimumSize = size;
            size = new System.Drawing.Size(0x30, 0x16);
            this.labelSTOPAPOREZA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MOPOREZ.Location = point;
            this.label1MOPOREZ.Name = "label1MOPOREZ";
            this.label1MOPOREZ.TabIndex = 1;
            this.label1MOPOREZ.Tag = "labelMOPOREZ";
            this.label1MOPOREZ.Text = "Model odobrenja poreza:";
            this.label1MOPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1MOPOREZ.AutoSize = true;
            this.label1MOPOREZ.Anchor = AnchorStyles.Left;
            this.label1MOPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1MOPOREZ.Appearance.ForeColor = Color.Black;
            this.label1MOPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.label1MOPOREZ, 0, 4);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.label1MOPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.label1MOPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MOPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MOPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0xa9, 0x17);
            this.label1MOPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelMOPOREZ.Location = point;
            this.labelMOPOREZ.Name = "labelMOPOREZ";
            this.labelMOPOREZ.Tag = "MOPOREZ";
            this.labelMOPOREZ.TabIndex = 0;
            this.labelMOPOREZ.Anchor = AnchorStyles.Left;
            this.labelMOPOREZ.BackColor = Color.Transparent;
            this.labelMOPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA1, "MOPOREZ"));
            this.labelMOPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.labelMOPOREZ, 1, 4);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.labelMOPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.labelMOPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelMOPOREZ.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.labelMOPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.labelMOPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POPOREZ.Location = point;
            this.label1POPOREZ.Name = "label1POPOREZ";
            this.label1POPOREZ.TabIndex = 1;
            this.label1POPOREZ.Tag = "labelPOPOREZ";
            this.label1POPOREZ.Text = "Poziv na broj odobrenja poreza:";
            this.label1POPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1POPOREZ.AutoSize = true;
            this.label1POPOREZ.Anchor = AnchorStyles.Left;
            this.label1POPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1POPOREZ.Appearance.ForeColor = Color.Black;
            this.label1POPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.label1POPOREZ, 0, 5);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.label1POPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.label1POPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0xd5, 0x17);
            this.label1POPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPOPOREZ.Location = point;
            this.labelPOPOREZ.Name = "labelPOPOREZ";
            this.labelPOPOREZ.Tag = "POPOREZ";
            this.labelPOPOREZ.TabIndex = 0;
            this.labelPOPOREZ.Anchor = AnchorStyles.Left;
            this.labelPOPOREZ.BackColor = Color.Transparent;
            this.labelPOPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA1, "POPOREZ"));
            this.labelPOPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.labelPOPOREZ, 1, 5);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.labelPOPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.labelPOPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPOPOREZ.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.labelPOPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.labelPOPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MZPOREZ.Location = point;
            this.label1MZPOREZ.Name = "label1MZPOREZ";
            this.label1MZPOREZ.TabIndex = 1;
            this.label1MZPOREZ.Tag = "labelMZPOREZ";
            this.label1MZPOREZ.Text = "Model zaduženja poreza:";
            this.label1MZPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1MZPOREZ.AutoSize = true;
            this.label1MZPOREZ.Anchor = AnchorStyles.Left;
            this.label1MZPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1MZPOREZ.Appearance.ForeColor = Color.Black;
            this.label1MZPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.label1MZPOREZ, 0, 6);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.label1MZPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.label1MZPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MZPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MZPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0xa9, 0x17);
            this.label1MZPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelMZPOREZ.Location = point;
            this.labelMZPOREZ.Name = "labelMZPOREZ";
            this.labelMZPOREZ.Tag = "MZPOREZ";
            this.labelMZPOREZ.TabIndex = 0;
            this.labelMZPOREZ.Anchor = AnchorStyles.Left;
            this.labelMZPOREZ.BackColor = Color.Transparent;
            this.labelMZPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA1, "MZPOREZ"));
            this.labelMZPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.labelMZPOREZ, 1, 6);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.labelMZPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.labelMZPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelMZPOREZ.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.labelMZPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.labelMZPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PZPOREZ.Location = point;
            this.label1PZPOREZ.Name = "label1PZPOREZ";
            this.label1PZPOREZ.TabIndex = 1;
            this.label1PZPOREZ.Tag = "labelPZPOREZ";
            this.label1PZPOREZ.Text = "Poziv na broj zaduženja poreza:";
            this.label1PZPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1PZPOREZ.AutoSize = true;
            this.label1PZPOREZ.Anchor = AnchorStyles.Left;
            this.label1PZPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1PZPOREZ.Appearance.ForeColor = Color.Black;
            this.label1PZPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.label1PZPOREZ, 0, 7);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.label1PZPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.label1PZPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PZPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PZPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0xd4, 0x17);
            this.label1PZPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPZPOREZ.Location = point;
            this.labelPZPOREZ.Name = "labelPZPOREZ";
            this.labelPZPOREZ.Tag = "PZPOREZ";
            this.labelPZPOREZ.TabIndex = 0;
            this.labelPZPOREZ.Anchor = AnchorStyles.Left;
            this.labelPZPOREZ.BackColor = Color.Transparent;
            this.labelPZPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA1, "PZPOREZ"));
            this.labelPZPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.labelPZPOREZ, 1, 7);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.labelPZPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.labelPZPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPZPOREZ.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.labelPZPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.labelPZPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJPOREZ1.Location = point;
            this.label1PRIMATELJPOREZ1.Name = "label1PRIMATELJPOREZ1";
            this.label1PRIMATELJPOREZ1.TabIndex = 1;
            this.label1PRIMATELJPOREZ1.Tag = "labelPRIMATELJPOREZ1";
            this.label1PRIMATELJPOREZ1.Text = "Primatelj poreza (1):";
            this.label1PRIMATELJPOREZ1.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJPOREZ1.AutoSize = true;
            this.label1PRIMATELJPOREZ1.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJPOREZ1.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJPOREZ1.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJPOREZ1.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.label1PRIMATELJPOREZ1, 0, 8);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.label1PRIMATELJPOREZ1, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.label1PRIMATELJPOREZ1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJPOREZ1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJPOREZ1.MinimumSize = size;
            size = new System.Drawing.Size(0x90, 0x17);
            this.label1PRIMATELJPOREZ1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPRIMATELJPOREZ1.Location = point;
            this.labelPRIMATELJPOREZ1.Name = "labelPRIMATELJPOREZ1";
            this.labelPRIMATELJPOREZ1.Tag = "PRIMATELJPOREZ1";
            this.labelPRIMATELJPOREZ1.TabIndex = 0;
            this.labelPRIMATELJPOREZ1.Anchor = AnchorStyles.Left;
            this.labelPRIMATELJPOREZ1.BackColor = Color.Transparent;
            this.labelPRIMATELJPOREZ1.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA1, "PRIMATELJPOREZ1"));
            this.labelPRIMATELJPOREZ1.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.labelPRIMATELJPOREZ1, 1, 8);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.labelPRIMATELJPOREZ1, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.labelPRIMATELJPOREZ1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJPOREZ1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJPOREZ1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJPOREZ1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJPOREZ2.Location = point;
            this.label1PRIMATELJPOREZ2.Name = "label1PRIMATELJPOREZ2";
            this.label1PRIMATELJPOREZ2.TabIndex = 1;
            this.label1PRIMATELJPOREZ2.Tag = "labelPRIMATELJPOREZ2";
            this.label1PRIMATELJPOREZ2.Text = "Primatelj poreza (2):";
            this.label1PRIMATELJPOREZ2.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJPOREZ2.AutoSize = true;
            this.label1PRIMATELJPOREZ2.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJPOREZ2.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJPOREZ2.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJPOREZ2.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.label1PRIMATELJPOREZ2, 0, 9);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.label1PRIMATELJPOREZ2, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.label1PRIMATELJPOREZ2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJPOREZ2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJPOREZ2.MinimumSize = size;
            size = new System.Drawing.Size(0x90, 0x17);
            this.label1PRIMATELJPOREZ2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPRIMATELJPOREZ2.Location = point;
            this.labelPRIMATELJPOREZ2.Name = "labelPRIMATELJPOREZ2";
            this.labelPRIMATELJPOREZ2.Tag = "PRIMATELJPOREZ2";
            this.labelPRIMATELJPOREZ2.TabIndex = 0;
            this.labelPRIMATELJPOREZ2.Anchor = AnchorStyles.Left;
            this.labelPRIMATELJPOREZ2.BackColor = Color.Transparent;
            this.labelPRIMATELJPOREZ2.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA1, "PRIMATELJPOREZ2"));
            this.labelPRIMATELJPOREZ2.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.labelPRIMATELJPOREZ2, 1, 9);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.labelPRIMATELJPOREZ2, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.labelPRIMATELJPOREZ2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJPOREZ2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJPOREZ2.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJPOREZ2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAOPISAPLACANJAPOREZ.Location = point;
            this.label1SIFRAOPISAPLACANJAPOREZ.Name = "label1SIFRAOPISAPLACANJAPOREZ";
            this.label1SIFRAOPISAPLACANJAPOREZ.TabIndex = 1;
            this.label1SIFRAOPISAPLACANJAPOREZ.Tag = "labelSIFRAOPISAPLACANJAPOREZ";
            this.label1SIFRAOPISAPLACANJAPOREZ.Text = "Šifra opisa plaćanja poreza:";
            this.label1SIFRAOPISAPLACANJAPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAOPISAPLACANJAPOREZ.AutoSize = true;
            this.label1SIFRAOPISAPLACANJAPOREZ.Anchor = AnchorStyles.Left;
            this.label1SIFRAOPISAPLACANJAPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAOPISAPLACANJAPOREZ.Appearance.ForeColor = Color.Black;
            this.label1SIFRAOPISAPLACANJAPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.label1SIFRAOPISAPLACANJAPOREZ, 0, 10);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.label1SIFRAOPISAPLACANJAPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.label1SIFRAOPISAPLACANJAPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAOPISAPLACANJAPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAOPISAPLACANJAPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0xba, 0x17);
            this.label1SIFRAOPISAPLACANJAPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelSIFRAOPISAPLACANJAPOREZ.Location = point;
            this.labelSIFRAOPISAPLACANJAPOREZ.Name = "labelSIFRAOPISAPLACANJAPOREZ";
            this.labelSIFRAOPISAPLACANJAPOREZ.Tag = "SIFRAOPISAPLACANJAPOREZ";
            this.labelSIFRAOPISAPLACANJAPOREZ.TabIndex = 0;
            this.labelSIFRAOPISAPLACANJAPOREZ.Anchor = AnchorStyles.Left;
            this.labelSIFRAOPISAPLACANJAPOREZ.BackColor = Color.Transparent;
            this.labelSIFRAOPISAPLACANJAPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA1, "SIFRAOPISAPLACANJAPOREZ"));
            this.labelSIFRAOPISAPLACANJAPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.labelSIFRAOPISAPLACANJAPOREZ, 1, 10);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.labelSIFRAOPISAPLACANJAPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.labelSIFRAOPISAPLACANJAPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelSIFRAOPISAPLACANJAPOREZ.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.labelSIFRAOPISAPLACANJAPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.labelSIFRAOPISAPLACANJAPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISPLACANJAPOREZ.Location = point;
            this.label1OPISPLACANJAPOREZ.Name = "label1OPISPLACANJAPOREZ";
            this.label1OPISPLACANJAPOREZ.TabIndex = 1;
            this.label1OPISPLACANJAPOREZ.Tag = "labelOPISPLACANJAPOREZ";
            this.label1OPISPLACANJAPOREZ.Text = "Opis plaćanja poreza:";
            this.label1OPISPLACANJAPOREZ.StyleSetName = "FieldUltraLabel";
            this.label1OPISPLACANJAPOREZ.AutoSize = true;
            this.label1OPISPLACANJAPOREZ.Anchor = AnchorStyles.Left;
            this.label1OPISPLACANJAPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISPLACANJAPOREZ.Appearance.ForeColor = Color.Black;
            this.label1OPISPLACANJAPOREZ.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.label1OPISPLACANJAPOREZ, 0, 11);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.label1OPISPLACANJAPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.label1OPISPLACANJAPOREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISPLACANJAPOREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISPLACANJAPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x94, 0x17);
            this.label1OPISPLACANJAPOREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOPISPLACANJAPOREZ.Location = point;
            this.labelOPISPLACANJAPOREZ.Name = "labelOPISPLACANJAPOREZ";
            this.labelOPISPLACANJAPOREZ.Tag = "OPISPLACANJAPOREZ";
            this.labelOPISPLACANJAPOREZ.TabIndex = 0;
            this.labelOPISPLACANJAPOREZ.Anchor = AnchorStyles.Left;
            this.labelOPISPLACANJAPOREZ.BackColor = Color.Transparent;
            this.labelOPISPLACANJAPOREZ.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA1, "OPISPLACANJAPOREZ"));
            this.labelOPISPLACANJAPOREZ.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.Controls.Add(this.labelOPISPLACANJAPOREZ, 1, 11);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.labelOPISPLACANJAPOREZ, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.labelOPISPLACANJAPOREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOPISPLACANJAPOREZ.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.labelOPISPLACANJAPOREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.labelOPISPLACANJAPOREZ.Size = size;
            this.Controls.Add(this.layoutManagerformSKUPPOREZAIDOPRINOSA1);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSKUPPOREZAIDOPRINOSA1;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "SKUPPOREZAIDOPRINOSAFormSKUPPOREZAIDOPRINOSA1UserControl";
            this.Text = " Porezi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SKUPPOREZAIDOPRINOSAFormUserControl_Load);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.ResumeLayout(false);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA1.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSKUPPOREZAIDOPRINOSA1).EndInit();
            ((ISupportInitialize) this.textIDPOREZ).EndInit();
            this.dsSKUPPOREZAIDOPRINOSADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.SKUPPOREZAIDOPRINOSAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSKUPPOREZAIDOPRINOSA1, this.SKUPPOREZAIDOPRINOSAController.WorkItem, this))
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
            this.label1IDPOREZ.Text = StringResources.SKUPPOREZAIDOPRINOSAIDPOREZDescription;
            this.label1NAZIVPOREZ.Text = StringResources.SKUPPOREZAIDOPRINOSANAZIVPOREZDescription;
            this.label1POREZMJESECNO.Text = StringResources.SKUPPOREZAIDOPRINOSAPOREZMJESECNODescription;
            this.label1STOPAPOREZA.Text = StringResources.SKUPPOREZAIDOPRINOSASTOPAPOREZADescription;
            this.label1MOPOREZ.Text = StringResources.SKUPPOREZAIDOPRINOSAMOPOREZDescription;
            this.label1POPOREZ.Text = StringResources.SKUPPOREZAIDOPRINOSAPOPOREZDescription;
            this.label1MZPOREZ.Text = StringResources.SKUPPOREZAIDOPRINOSAMZPOREZDescription;
            this.label1PZPOREZ.Text = StringResources.SKUPPOREZAIDOPRINOSAPZPOREZDescription;
            this.label1PRIMATELJPOREZ1.Text = StringResources.SKUPPOREZAIDOPRINOSAPRIMATELJPOREZ1Description;
            this.label1PRIMATELJPOREZ2.Text = StringResources.SKUPPOREZAIDOPRINOSAPRIMATELJPOREZ2Description;
            this.label1SIFRAOPISAPLACANJAPOREZ.Text = StringResources.SKUPPOREZAIDOPRINOSASIFRAOPISAPLACANJAPOREZDescription;
            this.label1OPISPLACANJAPOREZ.Text = StringResources.SKUPPOREZAIDOPRINOSAOPISPLACANJAPOREZDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewRADNIK")]
        public void NewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SKUPPOREZAIDOPRINOSAController.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.SKUPPOREZAIDOPRINOSAController.WorkItem.Items.Contains("SKUPPOREZAIDOPRINOSA1|SKUPPOREZAIDOPRINOSA1"))
            {
                this.SKUPPOREZAIDOPRINOSAController.WorkItem.Items.Add(this.bindingSourceSKUPPOREZAIDOPRINOSA1, "SKUPPOREZAIDOPRINOSA1|SKUPPOREZAIDOPRINOSA1");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("SKUPPOREZAIDOPRINOSA1SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDPOREZ.Focus();
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

        private void SKUPPOREZAIDOPRINOSAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.SKUPPOREZAIDOPRINOSASKUPPOREZAIDOPRINOSA1LevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void UpdateValuesPOREZIDPOREZ(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA1.Current).Row["IDPOREZ"] = RuntimeHelpers.GetObjectValue(result["IDPOREZ"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA1.Current).Row["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(result["NAZIVPOREZ"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA1.Current).Row["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(result["POREZMJESECNO"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA1.Current).Row["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(result["STOPAPOREZA"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA1.Current).Row["MOPOREZ"] = RuntimeHelpers.GetObjectValue(result["MOPOREZ"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA1.Current).Row["POPOREZ"] = RuntimeHelpers.GetObjectValue(result["POPOREZ"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA1.Current).Row["MZPOREZ"] = RuntimeHelpers.GetObjectValue(result["MZPOREZ"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA1.Current).Row["PZPOREZ"] = RuntimeHelpers.GetObjectValue(result["PZPOREZ"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA1.Current).Row["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJPOREZ1"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA1.Current).Row["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJPOREZ2"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA1.Current).Row["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(result["SIFRAOPISAPLACANJAPOREZ"]);
                ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA1.Current).Row["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(result["OPISPLACANJAPOREZ"]);
                this.bindingSourceSKUPPOREZAIDOPRINOSA1.ResetCurrentItem();
            }
        }

        [LocalCommandHandler("ViewRADNIK")]
        public void ViewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SKUPPOREZAIDOPRINOSAController.ViewRADNIK(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDPOREZ = value;
            }
        }

        protected virtual UltraLabel label1MOPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MOPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MOPOREZ = value;
            }
        }

        protected virtual UltraLabel label1MZPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MZPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MZPOREZ = value;
            }
        }

        protected virtual UltraLabel label1NAZIVPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVPOREZ = value;
            }
        }

        protected virtual UltraLabel label1OPISPLACANJAPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISPLACANJAPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISPLACANJAPOREZ = value;
            }
        }

        protected virtual UltraLabel label1POPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POPOREZ = value;
            }
        }

        protected virtual UltraLabel label1POREZMJESECNO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POREZMJESECNO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POREZMJESECNO = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJPOREZ1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJPOREZ1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJPOREZ1 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJPOREZ2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJPOREZ2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJPOREZ2 = value;
            }
        }

        protected virtual UltraLabel label1PZPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PZPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PZPOREZ = value;
            }
        }

        protected virtual UltraLabel label1SIFRAOPISAPLACANJAPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAOPISAPLACANJAPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAOPISAPLACANJAPOREZ = value;
            }
        }

        protected virtual UltraLabel label1STOPAPOREZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1STOPAPOREZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1STOPAPOREZA = value;
            }
        }

        protected virtual UltraLabel labelMOPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelMOPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelMOPOREZ = value;
            }
        }

        protected virtual UltraLabel labelMZPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelMZPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelMZPOREZ = value;
            }
        }

        protected virtual UltraLabel labelNAZIVPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVPOREZ = value;
            }
        }

        protected virtual UltraLabel labelOPISPLACANJAPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOPISPLACANJAPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOPISPLACANJAPOREZ = value;
            }
        }

        protected virtual UltraLabel labelPOPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPOPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPOPOREZ = value;
            }
        }

        protected virtual UltraLabel labelPOREZMJESECNO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPOREZMJESECNO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPOREZMJESECNO = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJPOREZ1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJPOREZ1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJPOREZ1 = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJPOREZ2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJPOREZ2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJPOREZ2 = value;
            }
        }

        protected virtual UltraLabel labelPZPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPZPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPZPOREZ = value;
            }
        }

        protected virtual UltraLabel labelSIFRAOPISAPLACANJAPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelSIFRAOPISAPLACANJAPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelSIFRAOPISAPLACANJAPOREZ = value;
            }
        }

        protected virtual UltraLabel labelSTOPAPOREZA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelSTOPAPOREZA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelSTOPAPOREZA = value;
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.SKUPPOREZAIDOPRINOSAController SKUPPOREZAIDOPRINOSAController { get; set; }

        protected virtual UltraNumericEditor textIDPOREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDPOREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDPOREZ = value;
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

