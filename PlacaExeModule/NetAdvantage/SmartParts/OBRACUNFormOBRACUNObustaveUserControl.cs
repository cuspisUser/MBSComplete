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
    public class OBRACUNFormOBRACUNObustaveUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDOBUSTAVA")]
        private UltraLabel _label1IDOBUSTAVA;
        [AccessedThroughProperty("label1ISPLACENOKASA")]
        private UltraLabel _label1ISPLACENOKASA;
        [AccessedThroughProperty("label1IZNOSOBUSTAVE")]
        private UltraLabel _label1IZNOSOBUSTAVE;
        [AccessedThroughProperty("label1MOOBUSTAVA")]
        private UltraLabel _label1MOOBUSTAVA;
        [AccessedThroughProperty("label1MZOBUSTAVA")]
        private UltraLabel _label1MZOBUSTAVA;
        [AccessedThroughProperty("label1NAZIVOBUSTAVA")]
        private UltraLabel _label1NAZIVOBUSTAVA;
        [AccessedThroughProperty("label1NAZIVVRSTAOBUSTAVE")]
        private UltraLabel _label1NAZIVVRSTAOBUSTAVE;
        [AccessedThroughProperty("label1OBRACUNATAOBUSTAVAUKUNAMA")]
        private UltraLabel _label1OBRACUNATAOBUSTAVAUKUNAMA;
        [AccessedThroughProperty("label1OBUSTAVLJENODOSADA")]
        private UltraLabel _label1OBUSTAVLJENODOSADA;
        [AccessedThroughProperty("label1OBUSTAVLJENODOSADABROJRATA")]
        private UltraLabel _label1OBUSTAVLJENODOSADABROJRATA;
        [AccessedThroughProperty("label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE")]
        private UltraLabel _label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE;
        [AccessedThroughProperty("label1OPISPLACANJAOBUSTAVA")]
        private UltraLabel _label1OPISPLACANJAOBUSTAVA;
        [AccessedThroughProperty("label1POOBUSTAVA")]
        private UltraLabel _label1POOBUSTAVA;
        [AccessedThroughProperty("label1POSTOTAKOBUSTAVE")]
        private UltraLabel _label1POSTOTAKOBUSTAVE;
        [AccessedThroughProperty("label1PRIMATELJOBUSTAVA1")]
        private UltraLabel _label1PRIMATELJOBUSTAVA1;
        [AccessedThroughProperty("label1PRIMATELJOBUSTAVA2")]
        private UltraLabel _label1PRIMATELJOBUSTAVA2;
        [AccessedThroughProperty("label1PRIMATELJOBUSTAVA3")]
        private UltraLabel _label1PRIMATELJOBUSTAVA3;
        [AccessedThroughProperty("label1PZOBUSTAVA")]
        private UltraLabel _label1PZOBUSTAVA;
        [AccessedThroughProperty("label1SALDOKASA")]
        private UltraLabel _label1SALDOKASA;
        [AccessedThroughProperty("label1SIFRAOPISAPLACANJAOBUSTAVA")]
        private UltraLabel _label1SIFRAOPISAPLACANJAOBUSTAVA;
        [AccessedThroughProperty("label1VBDIOBUSTAVA")]
        private UltraLabel _label1VBDIOBUSTAVA;
        [AccessedThroughProperty("label1VRSTAOBUSTAVE")]
        private UltraLabel _label1VRSTAOBUSTAVE;
        [AccessedThroughProperty("label1ZRNOBUSTAVA")]
        private UltraLabel _label1ZRNOBUSTAVA;
        [AccessedThroughProperty("labelMOOBUSTAVA")]
        private UltraLabel _labelMOOBUSTAVA;
        [AccessedThroughProperty("labelMZOBUSTAVA")]
        private UltraLabel _labelMZOBUSTAVA;
        [AccessedThroughProperty("labelNAZIVOBUSTAVA")]
        private UltraLabel _labelNAZIVOBUSTAVA;
        [AccessedThroughProperty("labelNAZIVVRSTAOBUSTAVE")]
        private UltraLabel _labelNAZIVVRSTAOBUSTAVE;
        [AccessedThroughProperty("labelOBUSTAVLJENODOSADA")]
        private UltraLabel _labelOBUSTAVLJENODOSADA;
        [AccessedThroughProperty("labelOBUSTAVLJENODOSADABROJRATA")]
        private UltraLabel _labelOBUSTAVLJENODOSADABROJRATA;
        [AccessedThroughProperty("labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE")]
        private UltraLabel _labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE;
        [AccessedThroughProperty("labelOPISPLACANJAOBUSTAVA")]
        private UltraLabel _labelOPISPLACANJAOBUSTAVA;
        [AccessedThroughProperty("labelPOOBUSTAVA")]
        private UltraLabel _labelPOOBUSTAVA;
        [AccessedThroughProperty("labelPRIMATELJOBUSTAVA1")]
        private UltraLabel _labelPRIMATELJOBUSTAVA1;
        [AccessedThroughProperty("labelPRIMATELJOBUSTAVA2")]
        private UltraLabel _labelPRIMATELJOBUSTAVA2;
        [AccessedThroughProperty("labelPRIMATELJOBUSTAVA3")]
        private UltraLabel _labelPRIMATELJOBUSTAVA3;
        [AccessedThroughProperty("labelPZOBUSTAVA")]
        private UltraLabel _labelPZOBUSTAVA;
        [AccessedThroughProperty("labelSIFRAOPISAPLACANJAOBUSTAVA")]
        private UltraLabel _labelSIFRAOPISAPLACANJAOBUSTAVA;
        [AccessedThroughProperty("labelVBDIOBUSTAVA")]
        private UltraLabel _labelVBDIOBUSTAVA;
        [AccessedThroughProperty("labelVRSTAOBUSTAVE")]
        private UltraLabel _labelVRSTAOBUSTAVE;
        [AccessedThroughProperty("labelZRNOBUSTAVA")]
        private UltraLabel _labelZRNOBUSTAVA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDOBUSTAVA")]
        private UltraNumericEditor _textIDOBUSTAVA;
        [AccessedThroughProperty("textISPLACENOKASA")]
        private UltraNumericEditor _textISPLACENOKASA;
        [AccessedThroughProperty("textIZNOSOBUSTAVE")]
        private UltraNumericEditor _textIZNOSOBUSTAVE;
        [AccessedThroughProperty("textOBRACUNATAOBUSTAVAUKUNAMA")]
        private UltraNumericEditor _textOBRACUNATAOBUSTAVAUKUNAMA;
        [AccessedThroughProperty("textPOSTOTAKOBUSTAVE")]
        private UltraNumericEditor _textPOSTOTAKOBUSTAVE;
        [AccessedThroughProperty("textSALDOKASA")]
        private UltraNumericEditor _textSALDOKASA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceOBRACUNObustave;
        private IContainer components = null;
        private OBRACUNDataSet dsOBRACUNDataSet1;
        protected TableLayoutPanel layoutManagerformOBRACUNObustave;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OBRACUNDataSet.OBRACUNObustaveRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "OBRACUNObustave";
        private string m_FrameworkDescription = StringResources.OBRACUNDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        public OBRACUNFormOBRACUNObustaveUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("OBRACUNObustaveAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("OBRACUNObustaveAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (OBRACUNDataSet.OBRACUNObustaveRow) ((DataRowView) this.bindingSourceOBRACUNObustave.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CallPromptOBUSTAVAIDOBUSTAVA(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.OBRACUNController.SelectOBUSTAVAIDOBUSTAVA(fillMethod, fillByRow);
            this.UpdateValuesOBUSTAVAIDOBUSTAVA(result);
        }

        private void CallViewOBUSTAVAIDOBUSTAVA(object sender, EventArgs e)
        {
            DataRow result = this.OBRACUNController.ShowOBUSTAVAIDOBUSTAVA(this.m_CurrentRow);
            this.UpdateValuesOBUSTAVAIDOBUSTAVA(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsOBRACUNDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceOBRACUNObustave.DataSource = this.OBRACUNController.DataSet;
            this.dsOBRACUNDataSet1 = this.OBRACUNController.DataSet;
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
            this.dsOBRACUNDataSet1 = (OBRACUNDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceOBRACUNObustave.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsOBRACUNDataSet1.Tables["OBRACUNObustave"]);
            this.bindingSourceOBRACUNObustave.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OBRACUN", this.m_Mode, this.dsOBRACUNDataSet1, this.dsOBRACUNDataSet1.OBRACUNObustave.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceOBRACUNObustave, "OBUSTAVLJENODOSADA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelOBUSTAVLJENODOSADA.DataBindings["Text"] != null)
            {
                this.labelOBUSTAVLJENODOSADA.DataBindings.Remove(this.labelOBUSTAVLJENODOSADA.DataBindings["Text"]);
            }
            this.labelOBUSTAVLJENODOSADA.DataBindings.Add(binding);
            Binding binding2 = new Binding("Text", this.bindingSourceOBRACUNObustave, "OBUSTAVLJENODOSADABROJRATA", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelOBUSTAVLJENODOSADABROJRATA.DataBindings["Text"] != null)
            {
                this.labelOBUSTAVLJENODOSADABROJRATA.DataBindings.Remove(this.labelOBUSTAVLJENODOSADABROJRATA.DataBindings["Text"]);
            }
            this.labelOBUSTAVLJENODOSADABROJRATA.DataBindings.Add(binding2);
            Binding binding3 = new Binding("Text", this.bindingSourceOBRACUNObustave, "OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.DataBindings["Text"] != null)
            {
                this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.DataBindings.Remove(this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.DataBindings["Text"]);
            }
            this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.DataBindings.Add(binding3);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (OBRACUNDataSet.OBRACUNObustaveRow) ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row;
                this.textIDOBUSTAVA.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textIDOBUSTAVA.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (OBRACUNDataSet.OBRACUNObustaveRow) ((DataRowView) this.bindingSourceOBRACUNObustave.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(OBRACUNFormOBRACUNObustaveUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceOBRACUNObustave = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOBRACUNObustave).BeginInit();
            this.layoutManagerformOBRACUNObustave = new TableLayoutPanel();
            this.layoutManagerformOBRACUNObustave.SuspendLayout();
            this.layoutManagerformOBRACUNObustave.AutoSize = true;
            this.layoutManagerformOBRACUNObustave.Dock = DockStyle.Fill;
            this.layoutManagerformOBRACUNObustave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformOBRACUNObustave.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformOBRACUNObustave.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformOBRACUNObustave.Size = size;
            this.layoutManagerformOBRACUNObustave.ColumnCount = 2;
            this.layoutManagerformOBRACUNObustave.RowCount = 0x18;
            this.layoutManagerformOBRACUNObustave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOBRACUNObustave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNObustave.RowStyles.Add(new RowStyle());
            this.label1IDOBUSTAVA = new UltraLabel();
            this.textIDOBUSTAVA = new UltraNumericEditor();
            this.label1NAZIVOBUSTAVA = new UltraLabel();
            this.labelNAZIVOBUSTAVA = new UltraLabel();
            this.label1MOOBUSTAVA = new UltraLabel();
            this.labelMOOBUSTAVA = new UltraLabel();
            this.label1POOBUSTAVA = new UltraLabel();
            this.labelPOOBUSTAVA = new UltraLabel();
            this.label1MZOBUSTAVA = new UltraLabel();
            this.labelMZOBUSTAVA = new UltraLabel();
            this.label1PZOBUSTAVA = new UltraLabel();
            this.labelPZOBUSTAVA = new UltraLabel();
            this.label1VBDIOBUSTAVA = new UltraLabel();
            this.labelVBDIOBUSTAVA = new UltraLabel();
            this.label1ZRNOBUSTAVA = new UltraLabel();
            this.labelZRNOBUSTAVA = new UltraLabel();
            this.label1PRIMATELJOBUSTAVA1 = new UltraLabel();
            this.labelPRIMATELJOBUSTAVA1 = new UltraLabel();
            this.label1PRIMATELJOBUSTAVA2 = new UltraLabel();
            this.labelPRIMATELJOBUSTAVA2 = new UltraLabel();
            this.label1PRIMATELJOBUSTAVA3 = new UltraLabel();
            this.labelPRIMATELJOBUSTAVA3 = new UltraLabel();
            this.label1SIFRAOPISAPLACANJAOBUSTAVA = new UltraLabel();
            this.labelSIFRAOPISAPLACANJAOBUSTAVA = new UltraLabel();
            this.label1OPISPLACANJAOBUSTAVA = new UltraLabel();
            this.labelOPISPLACANJAOBUSTAVA = new UltraLabel();
            this.label1VRSTAOBUSTAVE = new UltraLabel();
            this.labelVRSTAOBUSTAVE = new UltraLabel();
            this.label1NAZIVVRSTAOBUSTAVE = new UltraLabel();
            this.labelNAZIVVRSTAOBUSTAVE = new UltraLabel();
            this.label1IZNOSOBUSTAVE = new UltraLabel();
            this.textIZNOSOBUSTAVE = new UltraNumericEditor();
            this.label1POSTOTAKOBUSTAVE = new UltraLabel();
            this.textPOSTOTAKOBUSTAVE = new UltraNumericEditor();
            this.label1OBRACUNATAOBUSTAVAUKUNAMA = new UltraLabel();
            this.textOBRACUNATAOBUSTAVAUKUNAMA = new UltraNumericEditor();
            this.label1ISPLACENOKASA = new UltraLabel();
            this.textISPLACENOKASA = new UltraNumericEditor();
            this.label1SALDOKASA = new UltraLabel();
            this.textSALDOKASA = new UltraNumericEditor();
            this.label1OBUSTAVLJENODOSADA = new UltraLabel();
            this.labelOBUSTAVLJENODOSADA = new UltraLabel();
            this.label1OBUSTAVLJENODOSADABROJRATA = new UltraLabel();
            this.labelOBUSTAVLJENODOSADABROJRATA = new UltraLabel();
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE = new UltraLabel();
            this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE = new UltraLabel();
            ((ISupportInitialize) this.textIDOBUSTAVA).BeginInit();
            ((ISupportInitialize) this.textIZNOSOBUSTAVE).BeginInit();
            ((ISupportInitialize) this.textPOSTOTAKOBUSTAVE).BeginInit();
            ((ISupportInitialize) this.textOBRACUNATAOBUSTAVAUKUNAMA).BeginInit();
            ((ISupportInitialize) this.textISPLACENOKASA).BeginInit();
            ((ISupportInitialize) this.textSALDOKASA).BeginInit();
            this.dsOBRACUNDataSet1 = new OBRACUNDataSet();
            this.dsOBRACUNDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsOBRACUNDataSet1.DataSetName = "dsOBRACUN";
            this.dsOBRACUNDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceOBRACUNObustave.DataSource = this.dsOBRACUNDataSet1;
            this.bindingSourceOBRACUNObustave.DataMember = "OBRACUNObustave";
            ((ISupportInitialize) this.bindingSourceOBRACUNObustave).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDOBUSTAVA.Location = point;
            this.label1IDOBUSTAVA.Name = "label1IDOBUSTAVA";
            this.label1IDOBUSTAVA.TabIndex = 1;
            this.label1IDOBUSTAVA.Tag = "labelIDOBUSTAVA";
            this.label1IDOBUSTAVA.Text = "Šifra obustave:";
            this.label1IDOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1IDOBUSTAVA.AutoSize = true;
            this.label1IDOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1IDOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOBUSTAVA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDOBUSTAVA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDOBUSTAVA.ImageSize = size;
            this.label1IDOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1IDOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1IDOBUSTAVA, 0, 0);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1IDOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1IDOBUSTAVA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x69, 0x17);
            this.label1IDOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDOBUSTAVA.Location = point;
            this.textIDOBUSTAVA.Name = "textIDOBUSTAVA";
            this.textIDOBUSTAVA.Tag = "IDOBUSTAVA";
            this.textIDOBUSTAVA.TabIndex = 0;
            this.textIDOBUSTAVA.Anchor = AnchorStyles.Left;
            this.textIDOBUSTAVA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDOBUSTAVA.ReadOnly = false;
            this.textIDOBUSTAVA.PromptChar = ' ';
            this.textIDOBUSTAVA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDOBUSTAVA.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUNObustave, "IDOBUSTAVA"));
            this.textIDOBUSTAVA.NumericType = NumericType.Integer;
            this.textIDOBUSTAVA.MaskInput = "{LOC}-nnnnnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonOBUSTAVAIDOBUSTAVA",
                Tag = "editorButtonOBUSTAVAIDOBUSTAVA",
                Text = "..."
            };
            this.textIDOBUSTAVA.ButtonsRight.Add(button);
            this.textIDOBUSTAVA.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOBUSTAVAIDOBUSTAVA);
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.textIDOBUSTAVA, 1, 0);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.textIDOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.textIDOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textIDOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textIDOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVOBUSTAVA.Location = point;
            this.label1NAZIVOBUSTAVA.Name = "label1NAZIVOBUSTAVA";
            this.label1NAZIVOBUSTAVA.TabIndex = 1;
            this.label1NAZIVOBUSTAVA.Tag = "labelNAZIVOBUSTAVA";
            this.label1NAZIVOBUSTAVA.Text = "Naziv obustave:";
            this.label1NAZIVOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVOBUSTAVA.AutoSize = true;
            this.label1NAZIVOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1NAZIVOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1NAZIVOBUSTAVA, 0, 1);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1NAZIVOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1NAZIVOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x72, 0x17);
            this.label1NAZIVOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVOBUSTAVA.Location = point;
            this.labelNAZIVOBUSTAVA.Name = "labelNAZIVOBUSTAVA";
            this.labelNAZIVOBUSTAVA.Tag = "NAZIVOBUSTAVA";
            this.labelNAZIVOBUSTAVA.TabIndex = 0;
            this.labelNAZIVOBUSTAVA.Anchor = AnchorStyles.Left;
            this.labelNAZIVOBUSTAVA.BackColor = Color.Transparent;
            this.labelNAZIVOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNObustave, "NAZIVOBUSTAVA"));
            this.labelNAZIVOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelNAZIVOBUSTAVA, 1, 1);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelNAZIVOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelNAZIVOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MOOBUSTAVA.Location = point;
            this.label1MOOBUSTAVA.Name = "label1MOOBUSTAVA";
            this.label1MOOBUSTAVA.TabIndex = 1;
            this.label1MOOBUSTAVA.Tag = "labelMOOBUSTAVA";
            this.label1MOOBUSTAVA.Text = "Model odobrenja:";
            this.label1MOOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1MOOBUSTAVA.AutoSize = true;
            this.label1MOOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1MOOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MOOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1MOOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1MOOBUSTAVA, 0, 2);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1MOOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1MOOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MOOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MOOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 0x17);
            this.label1MOOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelMOOBUSTAVA.Location = point;
            this.labelMOOBUSTAVA.Name = "labelMOOBUSTAVA";
            this.labelMOOBUSTAVA.Tag = "MOOBUSTAVA";
            this.labelMOOBUSTAVA.TabIndex = 0;
            this.labelMOOBUSTAVA.Anchor = AnchorStyles.Left;
            this.labelMOOBUSTAVA.BackColor = Color.Transparent;
            this.labelMOOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNObustave, "MOOBUSTAVA"));
            this.labelMOOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelMOOBUSTAVA, 1, 2);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelMOOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelMOOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelMOOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.labelMOOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.labelMOOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POOBUSTAVA.Location = point;
            this.label1POOBUSTAVA.Name = "label1POOBUSTAVA";
            this.label1POOBUSTAVA.TabIndex = 1;
            this.label1POOBUSTAVA.Tag = "labelPOOBUSTAVA";
            this.label1POOBUSTAVA.Text = "Poziv na broj odobrenja obustave:";
            this.label1POOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1POOBUSTAVA.AutoSize = true;
            this.label1POOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1POOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1POOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1POOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1POOBUSTAVA, 0, 3);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1POOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1POOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0xe3, 0x17);
            this.label1POOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPOOBUSTAVA.Location = point;
            this.labelPOOBUSTAVA.Name = "labelPOOBUSTAVA";
            this.labelPOOBUSTAVA.Tag = "POOBUSTAVA";
            this.labelPOOBUSTAVA.TabIndex = 0;
            this.labelPOOBUSTAVA.Anchor = AnchorStyles.Left;
            this.labelPOOBUSTAVA.BackColor = Color.Transparent;
            this.labelPOOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNObustave, "POOBUSTAVA"));
            this.labelPOOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelPOOBUSTAVA, 1, 3);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelPOOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelPOOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPOOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.labelPOOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.labelPOOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MZOBUSTAVA.Location = point;
            this.label1MZOBUSTAVA.Name = "label1MZOBUSTAVA";
            this.label1MZOBUSTAVA.TabIndex = 1;
            this.label1MZOBUSTAVA.Tag = "labelMZOBUSTAVA";
            this.label1MZOBUSTAVA.Text = "Model zaduženja obustave:";
            this.label1MZOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1MZOBUSTAVA.AutoSize = true;
            this.label1MZOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1MZOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MZOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1MZOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1MZOBUSTAVA, 0, 4);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1MZOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1MZOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MZOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MZOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0xb8, 0x17);
            this.label1MZOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelMZOBUSTAVA.Location = point;
            this.labelMZOBUSTAVA.Name = "labelMZOBUSTAVA";
            this.labelMZOBUSTAVA.Tag = "MZOBUSTAVA";
            this.labelMZOBUSTAVA.TabIndex = 0;
            this.labelMZOBUSTAVA.Anchor = AnchorStyles.Left;
            this.labelMZOBUSTAVA.BackColor = Color.Transparent;
            this.labelMZOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNObustave, "MZOBUSTAVA"));
            this.labelMZOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelMZOBUSTAVA, 1, 4);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelMZOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelMZOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelMZOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.labelMZOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.labelMZOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PZOBUSTAVA.Location = point;
            this.label1PZOBUSTAVA.Name = "label1PZOBUSTAVA";
            this.label1PZOBUSTAVA.TabIndex = 1;
            this.label1PZOBUSTAVA.Tag = "labelPZOBUSTAVA";
            this.label1PZOBUSTAVA.Text = "Poziv na broj zaduženja obustave:";
            this.label1PZOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1PZOBUSTAVA.AutoSize = true;
            this.label1PZOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1PZOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1PZOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1PZOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1PZOBUSTAVA, 0, 5);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1PZOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1PZOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PZOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PZOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0xe3, 0x17);
            this.label1PZOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPZOBUSTAVA.Location = point;
            this.labelPZOBUSTAVA.Name = "labelPZOBUSTAVA";
            this.labelPZOBUSTAVA.Tag = "PZOBUSTAVA";
            this.labelPZOBUSTAVA.TabIndex = 0;
            this.labelPZOBUSTAVA.Anchor = AnchorStyles.Left;
            this.labelPZOBUSTAVA.BackColor = Color.Transparent;
            this.labelPZOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNObustave, "PZOBUSTAVA"));
            this.labelPZOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelPZOBUSTAVA, 1, 5);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelPZOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelPZOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPZOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.labelPZOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.labelPZOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VBDIOBUSTAVA.Location = point;
            this.label1VBDIOBUSTAVA.Name = "label1VBDIOBUSTAVA";
            this.label1VBDIOBUSTAVA.TabIndex = 1;
            this.label1VBDIOBUSTAVA.Tag = "labelVBDIOBUSTAVA";
            this.label1VBDIOBUSTAVA.Text = "VBDI žiro računa obustave:";
            this.label1VBDIOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1VBDIOBUSTAVA.AutoSize = true;
            this.label1VBDIOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1VBDIOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1VBDIOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1VBDIOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1VBDIOBUSTAVA, 0, 6);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1VBDIOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1VBDIOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VBDIOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VBDIOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0xb8, 0x17);
            this.label1VBDIOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelVBDIOBUSTAVA.Location = point;
            this.labelVBDIOBUSTAVA.Name = "labelVBDIOBUSTAVA";
            this.labelVBDIOBUSTAVA.Tag = "VBDIOBUSTAVA";
            this.labelVBDIOBUSTAVA.TabIndex = 0;
            this.labelVBDIOBUSTAVA.Anchor = AnchorStyles.Left;
            this.labelVBDIOBUSTAVA.BackColor = Color.Transparent;
            this.labelVBDIOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNObustave, "VBDIOBUSTAVA"));
            this.labelVBDIOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelVBDIOBUSTAVA, 1, 6);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelVBDIOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelVBDIOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelVBDIOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.labelVBDIOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.labelVBDIOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZRNOBUSTAVA.Location = point;
            this.label1ZRNOBUSTAVA.Name = "label1ZRNOBUSTAVA";
            this.label1ZRNOBUSTAVA.TabIndex = 1;
            this.label1ZRNOBUSTAVA.Tag = "labelZRNOBUSTAVA";
            this.label1ZRNOBUSTAVA.Text = "Broj žiro računa obustave:";
            this.label1ZRNOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1ZRNOBUSTAVA.AutoSize = true;
            this.label1ZRNOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1ZRNOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZRNOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1ZRNOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1ZRNOBUSTAVA, 0, 7);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1ZRNOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1ZRNOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZRNOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZRNOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0xb2, 0x17);
            this.label1ZRNOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelZRNOBUSTAVA.Location = point;
            this.labelZRNOBUSTAVA.Name = "labelZRNOBUSTAVA";
            this.labelZRNOBUSTAVA.Tag = "ZRNOBUSTAVA";
            this.labelZRNOBUSTAVA.TabIndex = 0;
            this.labelZRNOBUSTAVA.Anchor = AnchorStyles.Left;
            this.labelZRNOBUSTAVA.BackColor = Color.Transparent;
            this.labelZRNOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNObustave, "ZRNOBUSTAVA"));
            this.labelZRNOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelZRNOBUSTAVA, 1, 7);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelZRNOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelZRNOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelZRNOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.labelZRNOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.labelZRNOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJOBUSTAVA1.Location = point;
            this.label1PRIMATELJOBUSTAVA1.Name = "label1PRIMATELJOBUSTAVA1";
            this.label1PRIMATELJOBUSTAVA1.TabIndex = 1;
            this.label1PRIMATELJOBUSTAVA1.Tag = "labelPRIMATELJOBUSTAVA1";
            this.label1PRIMATELJOBUSTAVA1.Text = "Primatelj (1):";
            this.label1PRIMATELJOBUSTAVA1.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJOBUSTAVA1.AutoSize = true;
            this.label1PRIMATELJOBUSTAVA1.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJOBUSTAVA1.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJOBUSTAVA1.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJOBUSTAVA1.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1PRIMATELJOBUSTAVA1, 0, 8);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1PRIMATELJOBUSTAVA1, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1PRIMATELJOBUSTAVA1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJOBUSTAVA1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJOBUSTAVA1.MinimumSize = size;
            size = new System.Drawing.Size(0x63, 0x17);
            this.label1PRIMATELJOBUSTAVA1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPRIMATELJOBUSTAVA1.Location = point;
            this.labelPRIMATELJOBUSTAVA1.Name = "labelPRIMATELJOBUSTAVA1";
            this.labelPRIMATELJOBUSTAVA1.Tag = "PRIMATELJOBUSTAVA1";
            this.labelPRIMATELJOBUSTAVA1.TabIndex = 0;
            this.labelPRIMATELJOBUSTAVA1.Anchor = AnchorStyles.Left;
            this.labelPRIMATELJOBUSTAVA1.BackColor = Color.Transparent;
            this.labelPRIMATELJOBUSTAVA1.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNObustave, "PRIMATELJOBUSTAVA1"));
            this.labelPRIMATELJOBUSTAVA1.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelPRIMATELJOBUSTAVA1, 1, 8);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelPRIMATELJOBUSTAVA1, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelPRIMATELJOBUSTAVA1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJOBUSTAVA1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJOBUSTAVA1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJOBUSTAVA1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJOBUSTAVA2.Location = point;
            this.label1PRIMATELJOBUSTAVA2.Name = "label1PRIMATELJOBUSTAVA2";
            this.label1PRIMATELJOBUSTAVA2.TabIndex = 1;
            this.label1PRIMATELJOBUSTAVA2.Tag = "labelPRIMATELJOBUSTAVA2";
            this.label1PRIMATELJOBUSTAVA2.Text = "Primatelj (2):";
            this.label1PRIMATELJOBUSTAVA2.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJOBUSTAVA2.AutoSize = true;
            this.label1PRIMATELJOBUSTAVA2.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJOBUSTAVA2.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJOBUSTAVA2.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJOBUSTAVA2.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1PRIMATELJOBUSTAVA2, 0, 9);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1PRIMATELJOBUSTAVA2, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1PRIMATELJOBUSTAVA2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJOBUSTAVA2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJOBUSTAVA2.MinimumSize = size;
            size = new System.Drawing.Size(0x63, 0x17);
            this.label1PRIMATELJOBUSTAVA2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPRIMATELJOBUSTAVA2.Location = point;
            this.labelPRIMATELJOBUSTAVA2.Name = "labelPRIMATELJOBUSTAVA2";
            this.labelPRIMATELJOBUSTAVA2.Tag = "PRIMATELJOBUSTAVA2";
            this.labelPRIMATELJOBUSTAVA2.TabIndex = 0;
            this.labelPRIMATELJOBUSTAVA2.Anchor = AnchorStyles.Left;
            this.labelPRIMATELJOBUSTAVA2.BackColor = Color.Transparent;
            this.labelPRIMATELJOBUSTAVA2.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNObustave, "PRIMATELJOBUSTAVA2"));
            this.labelPRIMATELJOBUSTAVA2.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelPRIMATELJOBUSTAVA2, 1, 9);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelPRIMATELJOBUSTAVA2, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelPRIMATELJOBUSTAVA2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJOBUSTAVA2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJOBUSTAVA2.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJOBUSTAVA2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRIMATELJOBUSTAVA3.Location = point;
            this.label1PRIMATELJOBUSTAVA3.Name = "label1PRIMATELJOBUSTAVA3";
            this.label1PRIMATELJOBUSTAVA3.TabIndex = 1;
            this.label1PRIMATELJOBUSTAVA3.Tag = "labelPRIMATELJOBUSTAVA3";
            this.label1PRIMATELJOBUSTAVA3.Text = "Primatelj (3):";
            this.label1PRIMATELJOBUSTAVA3.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJOBUSTAVA3.AutoSize = true;
            this.label1PRIMATELJOBUSTAVA3.Anchor = AnchorStyles.Left;
            this.label1PRIMATELJOBUSTAVA3.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRIMATELJOBUSTAVA3.Appearance.ForeColor = Color.Black;
            this.label1PRIMATELJOBUSTAVA3.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1PRIMATELJOBUSTAVA3, 0, 10);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1PRIMATELJOBUSTAVA3, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1PRIMATELJOBUSTAVA3, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJOBUSTAVA3.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRIMATELJOBUSTAVA3.MinimumSize = size;
            size = new System.Drawing.Size(0x63, 0x17);
            this.label1PRIMATELJOBUSTAVA3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPRIMATELJOBUSTAVA3.Location = point;
            this.labelPRIMATELJOBUSTAVA3.Name = "labelPRIMATELJOBUSTAVA3";
            this.labelPRIMATELJOBUSTAVA3.Tag = "PRIMATELJOBUSTAVA3";
            this.labelPRIMATELJOBUSTAVA3.TabIndex = 0;
            this.labelPRIMATELJOBUSTAVA3.Anchor = AnchorStyles.Left;
            this.labelPRIMATELJOBUSTAVA3.BackColor = Color.Transparent;
            this.labelPRIMATELJOBUSTAVA3.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNObustave, "PRIMATELJOBUSTAVA3"));
            this.labelPRIMATELJOBUSTAVA3.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelPRIMATELJOBUSTAVA3, 1, 10);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelPRIMATELJOBUSTAVA3, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelPRIMATELJOBUSTAVA3, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJOBUSTAVA3.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJOBUSTAVA3.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJOBUSTAVA3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Location = point;
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Name = "label1SIFRAOPISAPLACANJAOBUSTAVA";
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.TabIndex = 1;
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Tag = "labelSIFRAOPISAPLACANJAOBUSTAVA";
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Text = "Šifra opisa plaćanja:";
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.AutoSize = true;
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1SIFRAOPISAPLACANJAOBUSTAVA, 0, 11);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1SIFRAOPISAPLACANJAOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1SIFRAOPISAPLACANJAOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 0x17);
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelSIFRAOPISAPLACANJAOBUSTAVA.Location = point;
            this.labelSIFRAOPISAPLACANJAOBUSTAVA.Name = "labelSIFRAOPISAPLACANJAOBUSTAVA";
            this.labelSIFRAOPISAPLACANJAOBUSTAVA.Tag = "SIFRAOPISAPLACANJAOBUSTAVA";
            this.labelSIFRAOPISAPLACANJAOBUSTAVA.TabIndex = 0;
            this.labelSIFRAOPISAPLACANJAOBUSTAVA.Anchor = AnchorStyles.Left;
            this.labelSIFRAOPISAPLACANJAOBUSTAVA.BackColor = Color.Transparent;
            this.labelSIFRAOPISAPLACANJAOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNObustave, "SIFRAOPISAPLACANJAOBUSTAVA"));
            this.labelSIFRAOPISAPLACANJAOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelSIFRAOPISAPLACANJAOBUSTAVA, 1, 11);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelSIFRAOPISAPLACANJAOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelSIFRAOPISAPLACANJAOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelSIFRAOPISAPLACANJAOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.labelSIFRAOPISAPLACANJAOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.labelSIFRAOPISAPLACANJAOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISPLACANJAOBUSTAVA.Location = point;
            this.label1OPISPLACANJAOBUSTAVA.Name = "label1OPISPLACANJAOBUSTAVA";
            this.label1OPISPLACANJAOBUSTAVA.TabIndex = 1;
            this.label1OPISPLACANJAOBUSTAVA.Tag = "labelOPISPLACANJAOBUSTAVA";
            this.label1OPISPLACANJAOBUSTAVA.Text = "Opis plaćanja:";
            this.label1OPISPLACANJAOBUSTAVA.StyleSetName = "FieldUltraLabel";
            this.label1OPISPLACANJAOBUSTAVA.AutoSize = true;
            this.label1OPISPLACANJAOBUSTAVA.Anchor = AnchorStyles.Left;
            this.label1OPISPLACANJAOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISPLACANJAOBUSTAVA.Appearance.ForeColor = Color.Black;
            this.label1OPISPLACANJAOBUSTAVA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1OPISPLACANJAOBUSTAVA, 0, 12);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1OPISPLACANJAOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1OPISPLACANJAOBUSTAVA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISPLACANJAOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISPLACANJAOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x67, 0x17);
            this.label1OPISPLACANJAOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOPISPLACANJAOBUSTAVA.Location = point;
            this.labelOPISPLACANJAOBUSTAVA.Name = "labelOPISPLACANJAOBUSTAVA";
            this.labelOPISPLACANJAOBUSTAVA.Tag = "OPISPLACANJAOBUSTAVA";
            this.labelOPISPLACANJAOBUSTAVA.TabIndex = 0;
            this.labelOPISPLACANJAOBUSTAVA.Anchor = AnchorStyles.Left;
            this.labelOPISPLACANJAOBUSTAVA.BackColor = Color.Transparent;
            this.labelOPISPLACANJAOBUSTAVA.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNObustave, "OPISPLACANJAOBUSTAVA"));
            this.labelOPISPLACANJAOBUSTAVA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelOPISPLACANJAOBUSTAVA, 1, 12);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelOPISPLACANJAOBUSTAVA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelOPISPLACANJAOBUSTAVA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOPISPLACANJAOBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.labelOPISPLACANJAOBUSTAVA.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.labelOPISPLACANJAOBUSTAVA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VRSTAOBUSTAVE.Location = point;
            this.label1VRSTAOBUSTAVE.Name = "label1VRSTAOBUSTAVE";
            this.label1VRSTAOBUSTAVE.TabIndex = 1;
            this.label1VRSTAOBUSTAVE.Tag = "labelVRSTAOBUSTAVE";
            this.label1VRSTAOBUSTAVE.Text = "Vrsta obustave:";
            this.label1VRSTAOBUSTAVE.StyleSetName = "FieldUltraLabel";
            this.label1VRSTAOBUSTAVE.AutoSize = true;
            this.label1VRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.label1VRSTAOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.label1VRSTAOBUSTAVE.Appearance.ForeColor = Color.Black;
            this.label1VRSTAOBUSTAVE.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1VRSTAOBUSTAVE, 0, 13);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1VRSTAOBUSTAVE, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1VRSTAOBUSTAVE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x70, 0x17);
            this.label1VRSTAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelVRSTAOBUSTAVE.Location = point;
            this.labelVRSTAOBUSTAVE.Name = "labelVRSTAOBUSTAVE";
            this.labelVRSTAOBUSTAVE.Tag = "VRSTAOBUSTAVE";
            this.labelVRSTAOBUSTAVE.TabIndex = 0;
            this.labelVRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.labelVRSTAOBUSTAVE.BackColor = Color.Transparent;
            this.labelVRSTAOBUSTAVE.Appearance.TextHAlign = HAlign.Left;
            this.labelVRSTAOBUSTAVE.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNObustave, "VRSTAOBUSTAVE"));
            this.labelVRSTAOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelVRSTAOBUSTAVE, 1, 13);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelVRSTAOBUSTAVE, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelVRSTAOBUSTAVE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelVRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.labelVRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.labelVRSTAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVVRSTAOBUSTAVE.Location = point;
            this.label1NAZIVVRSTAOBUSTAVE.Name = "label1NAZIVVRSTAOBUSTAVE";
            this.label1NAZIVVRSTAOBUSTAVE.TabIndex = 1;
            this.label1NAZIVVRSTAOBUSTAVE.Tag = "labelNAZIVVRSTAOBUSTAVE";
            this.label1NAZIVVRSTAOBUSTAVE.Text = "Opis vrste obustave:";
            this.label1NAZIVVRSTAOBUSTAVE.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVVRSTAOBUSTAVE.AutoSize = true;
            this.label1NAZIVVRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.label1NAZIVVRSTAOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVVRSTAOBUSTAVE.Appearance.ForeColor = Color.Black;
            this.label1NAZIVVRSTAOBUSTAVE.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1NAZIVVRSTAOBUSTAVE, 0, 14);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1NAZIVVRSTAOBUSTAVE, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1NAZIVVRSTAOBUSTAVE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVVRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVVRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x8e, 0x17);
            this.label1NAZIVVRSTAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVVRSTAOBUSTAVE.Location = point;
            this.labelNAZIVVRSTAOBUSTAVE.Name = "labelNAZIVVRSTAOBUSTAVE";
            this.labelNAZIVVRSTAOBUSTAVE.Tag = "NAZIVVRSTAOBUSTAVE";
            this.labelNAZIVVRSTAOBUSTAVE.TabIndex = 0;
            this.labelNAZIVVRSTAOBUSTAVE.Anchor = AnchorStyles.Left;
            this.labelNAZIVVRSTAOBUSTAVE.BackColor = Color.Transparent;
            this.labelNAZIVVRSTAOBUSTAVE.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNObustave, "NAZIVVRSTAOBUSTAVE"));
            this.labelNAZIVVRSTAOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelNAZIVVRSTAOBUSTAVE, 1, 14);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelNAZIVVRSTAOBUSTAVE, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelNAZIVVRSTAOBUSTAVE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVVRSTAOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVVRSTAOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVVRSTAOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IZNOSOBUSTAVE.Location = point;
            this.label1IZNOSOBUSTAVE.Name = "label1IZNOSOBUSTAVE";
            this.label1IZNOSOBUSTAVE.TabIndex = 1;
            this.label1IZNOSOBUSTAVE.Tag = "labelIZNOSOBUSTAVE";
            this.label1IZNOSOBUSTAVE.Text = "IZNOSOBUSTAVE:";
            this.label1IZNOSOBUSTAVE.StyleSetName = "FieldUltraLabel";
            this.label1IZNOSOBUSTAVE.AutoSize = true;
            this.label1IZNOSOBUSTAVE.Anchor = AnchorStyles.Left;
            this.label1IZNOSOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IZNOSOBUSTAVE.Appearance.ForeColor = Color.Black;
            this.label1IZNOSOBUSTAVE.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1IZNOSOBUSTAVE, 0, 15);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1IZNOSOBUSTAVE, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1IZNOSOBUSTAVE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IZNOSOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IZNOSOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x7e, 0x17);
            this.label1IZNOSOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIZNOSOBUSTAVE.Location = point;
            this.textIZNOSOBUSTAVE.Name = "textIZNOSOBUSTAVE";
            this.textIZNOSOBUSTAVE.Tag = "IZNOSOBUSTAVE";
            this.textIZNOSOBUSTAVE.TabIndex = 0;
            this.textIZNOSOBUSTAVE.Anchor = AnchorStyles.Left;
            this.textIZNOSOBUSTAVE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIZNOSOBUSTAVE.ReadOnly = false;
            this.textIZNOSOBUSTAVE.PromptChar = ' ';
            this.textIZNOSOBUSTAVE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIZNOSOBUSTAVE.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUNObustave, "IZNOSOBUSTAVE"));
            this.textIZNOSOBUSTAVE.NumericType = NumericType.Double;
            this.textIZNOSOBUSTAVE.MaxValue = 79228162514264337593543950335M;
            this.textIZNOSOBUSTAVE.MinValue = -79228162514264337593543950335M;
            this.textIZNOSOBUSTAVE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.textIZNOSOBUSTAVE, 1, 15);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.textIZNOSOBUSTAVE, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.textIZNOSOBUSTAVE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIZNOSOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textIZNOSOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textIZNOSOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POSTOTAKOBUSTAVE.Location = point;
            this.label1POSTOTAKOBUSTAVE.Name = "label1POSTOTAKOBUSTAVE";
            this.label1POSTOTAKOBUSTAVE.TabIndex = 1;
            this.label1POSTOTAKOBUSTAVE.Tag = "labelPOSTOTAKOBUSTAVE";
            this.label1POSTOTAKOBUSTAVE.Text = "POSTOTAKOBUSTAVE:";
            this.label1POSTOTAKOBUSTAVE.StyleSetName = "FieldUltraLabel";
            this.label1POSTOTAKOBUSTAVE.AutoSize = true;
            this.label1POSTOTAKOBUSTAVE.Anchor = AnchorStyles.Left;
            this.label1POSTOTAKOBUSTAVE.Appearance.TextVAlign = VAlign.Middle;
            this.label1POSTOTAKOBUSTAVE.Appearance.ForeColor = Color.Black;
            this.label1POSTOTAKOBUSTAVE.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1POSTOTAKOBUSTAVE, 0, 0x10);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1POSTOTAKOBUSTAVE, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1POSTOTAKOBUSTAVE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POSTOTAKOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POSTOTAKOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x99, 0x17);
            this.label1POSTOTAKOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOSTOTAKOBUSTAVE.Location = point;
            this.textPOSTOTAKOBUSTAVE.Name = "textPOSTOTAKOBUSTAVE";
            this.textPOSTOTAKOBUSTAVE.Tag = "POSTOTAKOBUSTAVE";
            this.textPOSTOTAKOBUSTAVE.TabIndex = 0;
            this.textPOSTOTAKOBUSTAVE.Anchor = AnchorStyles.Left;
            this.textPOSTOTAKOBUSTAVE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOSTOTAKOBUSTAVE.ReadOnly = false;
            this.textPOSTOTAKOBUSTAVE.PromptChar = ' ';
            this.textPOSTOTAKOBUSTAVE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPOSTOTAKOBUSTAVE.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUNObustave, "POSTOTAKOBUSTAVE"));
            this.textPOSTOTAKOBUSTAVE.NumericType = NumericType.Double;
            this.textPOSTOTAKOBUSTAVE.MaxValue = 79228162514264337593543950335M;
            this.textPOSTOTAKOBUSTAVE.MinValue = -79228162514264337593543950335M;
            this.textPOSTOTAKOBUSTAVE.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.textPOSTOTAKOBUSTAVE, 1, 0x10);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.textPOSTOTAKOBUSTAVE, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.textPOSTOTAKOBUSTAVE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOSTOTAKOBUSTAVE.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textPOSTOTAKOBUSTAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textPOSTOTAKOBUSTAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBRACUNATAOBUSTAVAUKUNAMA.Location = point;
            this.label1OBRACUNATAOBUSTAVAUKUNAMA.Name = "label1OBRACUNATAOBUSTAVAUKUNAMA";
            this.label1OBRACUNATAOBUSTAVAUKUNAMA.TabIndex = 1;
            this.label1OBRACUNATAOBUSTAVAUKUNAMA.Tag = "labelOBRACUNATAOBUSTAVAUKUNAMA";
            this.label1OBRACUNATAOBUSTAVAUKUNAMA.Text = "OBRACUNATAOBUSTAVAUKUNAMA:";
            this.label1OBRACUNATAOBUSTAVAUKUNAMA.StyleSetName = "FieldUltraLabel";
            this.label1OBRACUNATAOBUSTAVAUKUNAMA.AutoSize = true;
            this.label1OBRACUNATAOBUSTAVAUKUNAMA.Anchor = AnchorStyles.Left;
            this.label1OBRACUNATAOBUSTAVAUKUNAMA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBRACUNATAOBUSTAVAUKUNAMA.Appearance.ForeColor = Color.Black;
            this.label1OBRACUNATAOBUSTAVAUKUNAMA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1OBRACUNATAOBUSTAVAUKUNAMA, 0, 0x11);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1OBRACUNATAOBUSTAVAUKUNAMA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1OBRACUNATAOBUSTAVAUKUNAMA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRACUNATAOBUSTAVAUKUNAMA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBRACUNATAOBUSTAVAUKUNAMA.MinimumSize = size;
            size = new System.Drawing.Size(0xee, 0x17);
            this.label1OBRACUNATAOBUSTAVAUKUNAMA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOBRACUNATAOBUSTAVAUKUNAMA.Location = point;
            this.textOBRACUNATAOBUSTAVAUKUNAMA.Name = "textOBRACUNATAOBUSTAVAUKUNAMA";
            this.textOBRACUNATAOBUSTAVAUKUNAMA.Tag = "OBRACUNATAOBUSTAVAUKUNAMA";
            this.textOBRACUNATAOBUSTAVAUKUNAMA.TabIndex = 0;
            this.textOBRACUNATAOBUSTAVAUKUNAMA.Anchor = AnchorStyles.Left;
            this.textOBRACUNATAOBUSTAVAUKUNAMA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOBRACUNATAOBUSTAVAUKUNAMA.ReadOnly = false;
            this.textOBRACUNATAOBUSTAVAUKUNAMA.PromptChar = ' ';
            this.textOBRACUNATAOBUSTAVAUKUNAMA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOBRACUNATAOBUSTAVAUKUNAMA.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUNObustave, "OBRACUNATAOBUSTAVAUKUNAMA"));
            this.textOBRACUNATAOBUSTAVAUKUNAMA.NumericType = NumericType.Double;
            this.textOBRACUNATAOBUSTAVAUKUNAMA.MaxValue = 79228162514264337593543950335M;
            this.textOBRACUNATAOBUSTAVAUKUNAMA.MinValue = -79228162514264337593543950335M;
            this.textOBRACUNATAOBUSTAVAUKUNAMA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.textOBRACUNATAOBUSTAVAUKUNAMA, 1, 0x11);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.textOBRACUNATAOBUSTAVAUKUNAMA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.textOBRACUNATAOBUSTAVAUKUNAMA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOBRACUNATAOBUSTAVAUKUNAMA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRACUNATAOBUSTAVAUKUNAMA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRACUNATAOBUSTAVAUKUNAMA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ISPLACENOKASA.Location = point;
            this.label1ISPLACENOKASA.Name = "label1ISPLACENOKASA";
            this.label1ISPLACENOKASA.TabIndex = 1;
            this.label1ISPLACENOKASA.Tag = "labelISPLACENOKASA";
            this.label1ISPLACENOKASA.Text = "ISPLACENOKASA:";
            this.label1ISPLACENOKASA.StyleSetName = "FieldUltraLabel";
            this.label1ISPLACENOKASA.AutoSize = true;
            this.label1ISPLACENOKASA.Anchor = AnchorStyles.Left;
            this.label1ISPLACENOKASA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ISPLACENOKASA.Appearance.ForeColor = Color.Black;
            this.label1ISPLACENOKASA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1ISPLACENOKASA, 0, 0x12);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1ISPLACENOKASA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1ISPLACENOKASA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ISPLACENOKASA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ISPLACENOKASA.MinimumSize = size;
            size = new System.Drawing.Size(0x7d, 0x17);
            this.label1ISPLACENOKASA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textISPLACENOKASA.Location = point;
            this.textISPLACENOKASA.Name = "textISPLACENOKASA";
            this.textISPLACENOKASA.Tag = "ISPLACENOKASA";
            this.textISPLACENOKASA.TabIndex = 0;
            this.textISPLACENOKASA.Anchor = AnchorStyles.Left;
            this.textISPLACENOKASA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textISPLACENOKASA.ReadOnly = false;
            this.textISPLACENOKASA.PromptChar = ' ';
            this.textISPLACENOKASA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textISPLACENOKASA.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUNObustave, "ISPLACENOKASA"));
            this.textISPLACENOKASA.NumericType = NumericType.Double;
            this.textISPLACENOKASA.MaxValue = 79228162514264337593543950335M;
            this.textISPLACENOKASA.MinValue = -79228162514264337593543950335M;
            this.textISPLACENOKASA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.textISPLACENOKASA, 1, 0x12);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.textISPLACENOKASA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.textISPLACENOKASA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textISPLACENOKASA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textISPLACENOKASA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textISPLACENOKASA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SALDOKASA.Location = point;
            this.label1SALDOKASA.Name = "label1SALDOKASA";
            this.label1SALDOKASA.TabIndex = 1;
            this.label1SALDOKASA.Tag = "labelSALDOKASA";
            this.label1SALDOKASA.Text = "SALDOKASA:";
            this.label1SALDOKASA.StyleSetName = "FieldUltraLabel";
            this.label1SALDOKASA.AutoSize = true;
            this.label1SALDOKASA.Anchor = AnchorStyles.Left;
            this.label1SALDOKASA.Appearance.TextVAlign = VAlign.Middle;
            this.label1SALDOKASA.Appearance.ForeColor = Color.Black;
            this.label1SALDOKASA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1SALDOKASA, 0, 0x13);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1SALDOKASA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1SALDOKASA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SALDOKASA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SALDOKASA.MinimumSize = size;
            size = new System.Drawing.Size(0x5f, 0x17);
            this.label1SALDOKASA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textSALDOKASA.Location = point;
            this.textSALDOKASA.Name = "textSALDOKASA";
            this.textSALDOKASA.Tag = "SALDOKASA";
            this.textSALDOKASA.TabIndex = 0;
            this.textSALDOKASA.Anchor = AnchorStyles.Left;
            this.textSALDOKASA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textSALDOKASA.ReadOnly = false;
            this.textSALDOKASA.PromptChar = ' ';
            this.textSALDOKASA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textSALDOKASA.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUNObustave, "SALDOKASA"));
            this.textSALDOKASA.NumericType = NumericType.Double;
            this.textSALDOKASA.MaxValue = 79228162514264337593543950335M;
            this.textSALDOKASA.MinValue = -79228162514264337593543950335M;
            this.textSALDOKASA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.textSALDOKASA, 1, 0x13);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.textSALDOKASA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.textSALDOKASA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSALDOKASA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textSALDOKASA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textSALDOKASA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBUSTAVLJENODOSADA.Location = point;
            this.label1OBUSTAVLJENODOSADA.Name = "label1OBUSTAVLJENODOSADA";
            this.label1OBUSTAVLJENODOSADA.TabIndex = 1;
            this.label1OBUSTAVLJENODOSADA.Tag = "labelOBUSTAVLJENODOSADA";
            this.label1OBUSTAVLJENODOSADA.Text = "OBUSTAVLJENODOSADA:";
            this.label1OBUSTAVLJENODOSADA.StyleSetName = "FieldUltraLabel";
            this.label1OBUSTAVLJENODOSADA.AutoSize = true;
            this.label1OBUSTAVLJENODOSADA.Anchor = AnchorStyles.Left;
            this.label1OBUSTAVLJENODOSADA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBUSTAVLJENODOSADA.Appearance.ForeColor = Color.Black;
            this.label1OBUSTAVLJENODOSADA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1OBUSTAVLJENODOSADA, 0, 20);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1OBUSTAVLJENODOSADA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1OBUSTAVLJENODOSADA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBUSTAVLJENODOSADA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBUSTAVLJENODOSADA.MinimumSize = size;
            size = new System.Drawing.Size(0xab, 0x17);
            this.label1OBUSTAVLJENODOSADA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOBUSTAVLJENODOSADA.Location = point;
            this.labelOBUSTAVLJENODOSADA.Name = "labelOBUSTAVLJENODOSADA";
            this.labelOBUSTAVLJENODOSADA.Tag = "OBUSTAVLJENODOSADA";
            this.labelOBUSTAVLJENODOSADA.TabIndex = 0;
            this.labelOBUSTAVLJENODOSADA.Anchor = AnchorStyles.Left;
            this.labelOBUSTAVLJENODOSADA.BackColor = Color.Transparent;
            this.labelOBUSTAVLJENODOSADA.Appearance.TextHAlign = HAlign.Left;
            this.labelOBUSTAVLJENODOSADA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelOBUSTAVLJENODOSADA, 1, 20);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelOBUSTAVLJENODOSADA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelOBUSTAVLJENODOSADA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOBUSTAVLJENODOSADA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelOBUSTAVLJENODOSADA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelOBUSTAVLJENODOSADA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBUSTAVLJENODOSADABROJRATA.Location = point;
            this.label1OBUSTAVLJENODOSADABROJRATA.Name = "label1OBUSTAVLJENODOSADABROJRATA";
            this.label1OBUSTAVLJENODOSADABROJRATA.TabIndex = 1;
            this.label1OBUSTAVLJENODOSADABROJRATA.Tag = "labelOBUSTAVLJENODOSADABROJRATA";
            this.label1OBUSTAVLJENODOSADABROJRATA.Text = "OBUSTAVLJENODOSADABROJRATA:";
            this.label1OBUSTAVLJENODOSADABROJRATA.StyleSetName = "FieldUltraLabel";
            this.label1OBUSTAVLJENODOSADABROJRATA.AutoSize = true;
            this.label1OBUSTAVLJENODOSADABROJRATA.Anchor = AnchorStyles.Left;
            this.label1OBUSTAVLJENODOSADABROJRATA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBUSTAVLJENODOSADABROJRATA.Appearance.ForeColor = Color.Black;
            this.label1OBUSTAVLJENODOSADABROJRATA.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1OBUSTAVLJENODOSADABROJRATA, 0, 0x15);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1OBUSTAVLJENODOSADABROJRATA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1OBUSTAVLJENODOSADABROJRATA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBUSTAVLJENODOSADABROJRATA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBUSTAVLJENODOSADABROJRATA.MinimumSize = size;
            size = new System.Drawing.Size(0xee, 0x17);
            this.label1OBUSTAVLJENODOSADABROJRATA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOBUSTAVLJENODOSADABROJRATA.Location = point;
            this.labelOBUSTAVLJENODOSADABROJRATA.Name = "labelOBUSTAVLJENODOSADABROJRATA";
            this.labelOBUSTAVLJENODOSADABROJRATA.Tag = "OBUSTAVLJENODOSADABROJRATA";
            this.labelOBUSTAVLJENODOSADABROJRATA.TabIndex = 0;
            this.labelOBUSTAVLJENODOSADABROJRATA.Anchor = AnchorStyles.Left;
            this.labelOBUSTAVLJENODOSADABROJRATA.BackColor = Color.Transparent;
            this.labelOBUSTAVLJENODOSADABROJRATA.Appearance.TextHAlign = HAlign.Left;
            this.labelOBUSTAVLJENODOSADABROJRATA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelOBUSTAVLJENODOSADABROJRATA, 1, 0x15);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelOBUSTAVLJENODOSADABROJRATA, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelOBUSTAVLJENODOSADABROJRATA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOBUSTAVLJENODOSADABROJRATA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelOBUSTAVLJENODOSADABROJRATA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelOBUSTAVLJENODOSADABROJRATA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Location = point;
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Name = "label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE";
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.TabIndex = 1;
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Tag = "labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE";
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Text = "OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE:";
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.StyleSetName = "FieldUltraLabel";
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.AutoSize = true;
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Anchor = AnchorStyles.Left;
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Appearance.TextVAlign = VAlign.Middle;
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Appearance.ForeColor = Color.Black;
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.BackColor = Color.Transparent;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE, 0, 0x16);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.MinimumSize = size;
            size = new System.Drawing.Size(0x165, 0x17);
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Location = point;
            this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Name = "labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE";
            this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Tag = "OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE";
            this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.TabIndex = 0;
            this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Anchor = AnchorStyles.Left;
            this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.BackColor = Color.Transparent;
            this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Appearance.TextHAlign = HAlign.Left;
            this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOBRACUNObustave.Controls.Add(this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE, 1, 0x16);
            this.layoutManagerformOBRACUNObustave.SetColumnSpan(this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE, 1);
            this.layoutManagerformOBRACUNObustave.SetRowSpan(this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Size = size;
            this.Controls.Add(this.layoutManagerformOBRACUNObustave);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceOBRACUNObustave;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "OBRACUNFormOBRACUNObustaveUserControl";
            this.Text = " ObracunObustave";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OBRACUNFormUserControl_Load);
            this.layoutManagerformOBRACUNObustave.ResumeLayout(false);
            this.layoutManagerformOBRACUNObustave.PerformLayout();
            ((ISupportInitialize) this.bindingSourceOBRACUNObustave).EndInit();
            ((ISupportInitialize) this.textIDOBUSTAVA).EndInit();
            ((ISupportInitialize) this.textIZNOSOBUSTAVE).EndInit();
            ((ISupportInitialize) this.textPOSTOTAKOBUSTAVE).EndInit();
            ((ISupportInitialize) this.textOBRACUNATAOBUSTAVAUKUNAMA).EndInit();
            ((ISupportInitialize) this.textISPLACENOKASA).EndInit();
            ((ISupportInitialize) this.textSALDOKASA).EndInit();
            this.dsOBRACUNDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OBRACUNController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceOBRACUNObustave, this.OBRACUNController.WorkItem, this))
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
            this.label1IDOBUSTAVA.Text = StringResources.OBRACUNIDOBUSTAVADescription;
            this.label1NAZIVOBUSTAVA.Text = StringResources.OBRACUNNAZIVOBUSTAVADescription;
            this.label1MOOBUSTAVA.Text = StringResources.OBRACUNMOOBUSTAVADescription;
            this.label1POOBUSTAVA.Text = StringResources.OBRACUNPOOBUSTAVADescription;
            this.label1MZOBUSTAVA.Text = StringResources.OBRACUNMZOBUSTAVADescription;
            this.label1PZOBUSTAVA.Text = StringResources.OBRACUNPZOBUSTAVADescription;
            this.label1VBDIOBUSTAVA.Text = StringResources.OBRACUNVBDIOBUSTAVADescription;
            this.label1ZRNOBUSTAVA.Text = StringResources.OBRACUNZRNOBUSTAVADescription;
            this.label1PRIMATELJOBUSTAVA1.Text = StringResources.OBRACUNPRIMATELJOBUSTAVA1Description;
            this.label1PRIMATELJOBUSTAVA2.Text = StringResources.OBRACUNPRIMATELJOBUSTAVA2Description;
            this.label1PRIMATELJOBUSTAVA3.Text = StringResources.OBRACUNPRIMATELJOBUSTAVA3Description;
            this.label1SIFRAOPISAPLACANJAOBUSTAVA.Text = StringResources.OBRACUNSIFRAOPISAPLACANJAOBUSTAVADescription;
            this.label1OPISPLACANJAOBUSTAVA.Text = StringResources.OBRACUNOPISPLACANJAOBUSTAVADescription;
            this.label1VRSTAOBUSTAVE.Text = StringResources.OBRACUNVRSTAOBUSTAVEDescription;
            this.label1NAZIVVRSTAOBUSTAVE.Text = StringResources.OBRACUNNAZIVVRSTAOBUSTAVEDescription;
            this.label1IZNOSOBUSTAVE.Text = StringResources.OBRACUNIZNOSOBUSTAVEDescription;
            this.label1POSTOTAKOBUSTAVE.Text = StringResources.OBRACUNPOSTOTAKOBUSTAVEDescription;
            this.label1OBRACUNATAOBUSTAVAUKUNAMA.Text = StringResources.OBRACUNOBRACUNATAOBUSTAVAUKUNAMADescription;
            this.label1ISPLACENOKASA.Text = StringResources.OBRACUNISPLACENOKASADescription;
            this.label1SALDOKASA.Text = StringResources.OBRACUNSALDOKASADescription;
            this.label1OBUSTAVLJENODOSADA.Text = StringResources.OBRACUNOBUSTAVLJENODOSADADescription;
            this.label1OBUSTAVLJENODOSADABROJRATA.Text = StringResources.OBRACUNOBUSTAVLJENODOSADABROJRATADescription;
            this.label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE.Text = StringResources.OBRACUNOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASEDescription;
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
                this.OBRACUNController.NewRSMA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void OBRACUNFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OBRACUNOBRACUNObustaveLevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void RegisterBindingSources()
        {
            if (!this.OBRACUNController.WorkItem.Items.Contains("OBRACUNObustave|OBRACUNObustave"))
            {
                this.OBRACUNController.WorkItem.Items.Add(this.bindingSourceOBRACUNObustave, "OBRACUNObustave|OBRACUNObustave");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("OBRACUNObustaveSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDOBUSTAVA.Focus();
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

        private void UpdateValuesOBUSTAVAIDOBUSTAVA(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row["IDOBUSTAVA"] = RuntimeHelpers.GetObjectValue(result["IDOBUSTAVA"]);
                ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row["NAZIVOBUSTAVA"] = RuntimeHelpers.GetObjectValue(result["NAZIVOBUSTAVA"]);
                ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row["MOOBUSTAVA"] = RuntimeHelpers.GetObjectValue(result["MOOBUSTAVA"]);
                ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row["POOBUSTAVA"] = RuntimeHelpers.GetObjectValue(result["POOBUSTAVA"]);
                ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row["MZOBUSTAVA"] = RuntimeHelpers.GetObjectValue(result["MZOBUSTAVA"]);
                ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row["PZOBUSTAVA"] = RuntimeHelpers.GetObjectValue(result["PZOBUSTAVA"]);
                ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row["VBDIOBUSTAVA"] = RuntimeHelpers.GetObjectValue(result["VBDIOBUSTAVA"]);
                ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row["ZRNOBUSTAVA"] = RuntimeHelpers.GetObjectValue(result["ZRNOBUSTAVA"]);
                ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row["PRIMATELJOBUSTAVA1"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJOBUSTAVA1"]);
                ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row["PRIMATELJOBUSTAVA2"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJOBUSTAVA2"]);
                ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row["PRIMATELJOBUSTAVA3"] = RuntimeHelpers.GetObjectValue(result["PRIMATELJOBUSTAVA3"]);
                ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row["SIFRAOPISAPLACANJAOBUSTAVA"] = RuntimeHelpers.GetObjectValue(result["SIFRAOPISAPLACANJAOBUSTAVA"]);
                ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row["OPISPLACANJAOBUSTAVA"] = RuntimeHelpers.GetObjectValue(result["OPISPLACANJAOBUSTAVA"]);
                ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row["VRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(result["VRSTAOBUSTAVE"]);
                ((DataRowView) this.bindingSourceOBRACUNObustave.Current).Row["NAZIVVRSTAOBUSTAVE"] = RuntimeHelpers.GetObjectValue(result["NAZIVVRSTAOBUSTAVE"]);
                this.bindingSourceOBRACUNObustave.ResetCurrentItem();
            }
        }

        [LocalCommandHandler("ViewRSMA")]
        public void ViewRSMAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OBRACUNController.ViewRSMA(this.m_CurrentRow);
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

        protected virtual UltraLabel label1IDOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1ISPLACENOKASA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ISPLACENOKASA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ISPLACENOKASA = value;
            }
        }

        protected virtual UltraLabel label1IZNOSOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IZNOSOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IZNOSOBUSTAVE = value;
            }
        }

        protected virtual UltraLabel label1MOOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MOOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MOOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1MZOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MZOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MZOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVVRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVVRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVVRSTAOBUSTAVE = value;
            }
        }

        protected virtual UltraLabel label1OBRACUNATAOBUSTAVAUKUNAMA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRACUNATAOBUSTAVAUKUNAMA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRACUNATAOBUSTAVAUKUNAMA = value;
            }
        }

        protected virtual UltraLabel label1OBUSTAVLJENODOSADA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBUSTAVLJENODOSADA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBUSTAVLJENODOSADA = value;
            }
        }

        protected virtual UltraLabel label1OBUSTAVLJENODOSADABROJRATA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBUSTAVLJENODOSADABROJRATA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBUSTAVLJENODOSADABROJRATA = value;
            }
        }

        protected virtual UltraLabel label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE = value;
            }
        }

        protected virtual UltraLabel label1OPISPLACANJAOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISPLACANJAOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISPLACANJAOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1POOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1POSTOTAKOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POSTOTAKOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POSTOTAKOBUSTAVE = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJOBUSTAVA1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJOBUSTAVA1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJOBUSTAVA1 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJOBUSTAVA2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJOBUSTAVA2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJOBUSTAVA2 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJOBUSTAVA3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJOBUSTAVA3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJOBUSTAVA3 = value;
            }
        }

        protected virtual UltraLabel label1PZOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PZOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PZOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1SALDOKASA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SALDOKASA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SALDOKASA = value;
            }
        }

        protected virtual UltraLabel label1SIFRAOPISAPLACANJAOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SIFRAOPISAPLACANJAOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SIFRAOPISAPLACANJAOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1VBDIOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VBDIOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VBDIOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel label1VRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VRSTAOBUSTAVE = value;
            }
        }

        protected virtual UltraLabel label1ZRNOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZRNOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZRNOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel labelMOOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelMOOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelMOOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel labelMZOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelMZOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelMZOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel labelNAZIVOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel labelNAZIVVRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVVRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVVRSTAOBUSTAVE = value;
            }
        }

        protected virtual UltraLabel labelOBUSTAVLJENODOSADA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOBUSTAVLJENODOSADA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOBUSTAVLJENODOSADA = value;
            }
        }

        protected virtual UltraLabel labelOBUSTAVLJENODOSADABROJRATA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOBUSTAVLJENODOSADABROJRATA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOBUSTAVLJENODOSADABROJRATA = value;
            }
        }

        protected virtual UltraLabel labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOBUSTAVLJENODOSATAUMANJENOZAISPLATUIZKASE = value;
            }
        }

        protected virtual UltraLabel labelOPISPLACANJAOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOPISPLACANJAOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOPISPLACANJAOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel labelPOOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPOOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPOOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJOBUSTAVA1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJOBUSTAVA1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJOBUSTAVA1 = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJOBUSTAVA2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJOBUSTAVA2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJOBUSTAVA2 = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJOBUSTAVA3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJOBUSTAVA3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJOBUSTAVA3 = value;
            }
        }

        protected virtual UltraLabel labelPZOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPZOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPZOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel labelSIFRAOPISAPLACANJAOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelSIFRAOPISAPLACANJAOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelSIFRAOPISAPLACANJAOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel labelVBDIOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelVBDIOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelVBDIOBUSTAVA = value;
            }
        }

        protected virtual UltraLabel labelVRSTAOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelVRSTAOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelVRSTAOBUSTAVE = value;
            }
        }

        protected virtual UltraLabel labelZRNOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZRNOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZRNOBUSTAVA = value;
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.OBRACUNController OBRACUNController { get; set; }

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

        protected virtual UltraNumericEditor textIDOBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDOBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDOBUSTAVA = value;
            }
        }

        protected virtual UltraNumericEditor textISPLACENOKASA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textISPLACENOKASA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textISPLACENOKASA = value;
            }
        }

        protected virtual UltraNumericEditor textIZNOSOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIZNOSOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIZNOSOBUSTAVE = value;
            }
        }

        protected virtual UltraNumericEditor textOBRACUNATAOBUSTAVAUKUNAMA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRACUNATAOBUSTAVAUKUNAMA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRACUNATAOBUSTAVAUKUNAMA = value;
            }
        }

        protected virtual UltraNumericEditor textPOSTOTAKOBUSTAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOSTOTAKOBUSTAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOSTOTAKOBUSTAVE = value;
            }
        }

        protected virtual UltraNumericEditor textSALDOKASA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSALDOKASA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSALDOKASA = value;
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

