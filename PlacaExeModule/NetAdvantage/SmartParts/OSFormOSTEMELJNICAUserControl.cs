namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.EventBroker;
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
    public class OSFormOSTEMELJNICAUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDOSDOKUMENT")]
        private OSDOKUMENTComboBox _comboIDOSDOKUMENT;
        [AccessedThroughProperty("comboRASHODLOKACIJEIDLOKACIJE")]
        private LOKACIJEComboBox _comboRASHODLOKACIJEIDLOKACIJE;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("datePickerOSDATUMDOK")]
        private UltraDateTimeEditor _datePickerOSDATUMDOK;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1IDOSDOKUMENT")]
        private UltraLabel _label1IDOSDOKUMENT;
        [AccessedThroughProperty("label1OSBROJDOKUMENTA")]
        private UltraLabel _label1OSBROJDOKUMENTA;
        [AccessedThroughProperty("label1OSDATUMDOK")]
        private UltraLabel _label1OSDATUMDOK;
        [AccessedThroughProperty("label1OSDUGUJE")]
        private UltraLabel _label1OSDUGUJE;
        [AccessedThroughProperty("label1OSKOLICINA")]
        private UltraLabel _label1OSKOLICINA;
        [AccessedThroughProperty("label1OSOSNOVICA")]
        private UltraLabel _label1OSOSNOVICA;
        [AccessedThroughProperty("label1OSPOTRAZUJE")]
        private UltraLabel _label1OSPOTRAZUJE;
        [AccessedThroughProperty("label1OSSTOPA")]
        private UltraLabel _label1OSSTOPA;
        [AccessedThroughProperty("label1RASHODLOKACIJEIDLOKACIJE")]
        private UltraLabel _label1RASHODLOKACIJEIDLOKACIJE;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textOSBROJDOKUMENTA")]
        private UltraNumericEditor _textOSBROJDOKUMENTA;
        [AccessedThroughProperty("textOSDUGUJE")]
        private UltraNumericEditor _textOSDUGUJE;
        [AccessedThroughProperty("textOSKOLICINA")]
        private UltraNumericEditor _textOSKOLICINA;
        [AccessedThroughProperty("textOSOSNOVICA")]
        private UltraNumericEditor _textOSOSNOVICA;
        [AccessedThroughProperty("textOSPOTRAZUJE")]
        private UltraNumericEditor _textOSPOTRAZUJE;
        [AccessedThroughProperty("textOSSTOPA")]
        private UltraNumericEditor _textOSSTOPA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceOSTEMELJNICA;
        private IContainer components = null;
        private OSDataSet dsOSDataSet1;
        protected TableLayoutPanel layoutManagerformOSTEMELJNICA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OSDataSet.OSTEMELJNICARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "OSTEMELJNICA";
        private string m_FrameworkDescription = StringResources.OSDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public OSFormOSTEMELJNICAUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("OSTEMELJNICAAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("OSTEMELJNICAAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (OSDataSet.OSTEMELJNICARow) ((DataRowView) this.bindingSourceOSTEMELJNICA.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsOSDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceOSTEMELJNICA.DataSource = this.OSController.DataSet;
            this.dsOSDataSet1 = this.OSController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/OSDOKUMENT", Thread=ThreadOption.UserInterface)]
        public void comboIDOSDOKUMENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDOSDOKUMENT.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/LOKACIJE", Thread=ThreadOption.UserInterface)]
        public void comboRASHODLOKACIJEIDLOKACIJE_Add(object sender, ComponentEventArgs e)
        {
            this.comboRASHODLOKACIJEIDLOKACIJE.Fill();
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
            this.dsOSDataSet1 = (OSDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourceOSTEMELJNICA.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsOSDataSet1.Tables["OSTEMELJNICA"]);
            this.bindingSourceOSTEMELJNICA.DataMember = "";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OS", this.m_Mode, this.dsOSDataSet1, this.dsOSDataSet1.OSTEMELJNICA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceOSTEMELJNICA, "OSDATUMDOK", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerOSDATUMDOK.DataBindings["Text"] != null)
            {
                this.datePickerOSDATUMDOK.DataBindings.Remove(this.datePickerOSDATUMDOK.DataBindings["Text"]);
            }
            this.datePickerOSDATUMDOK.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (OSDataSet.OSTEMELJNICARow) ((DataRowView) this.bindingSourceOSTEMELJNICA.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (OSDataSet.OSTEMELJNICARow) ((DataRowView) this.bindingSourceOSTEMELJNICA.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(OSFormOSTEMELJNICAUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceOSTEMELJNICA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOSTEMELJNICA).BeginInit();
            this.layoutManagerformOSTEMELJNICA = new TableLayoutPanel();
            this.layoutManagerformOSTEMELJNICA.SuspendLayout();
            this.layoutManagerformOSTEMELJNICA.AutoSize = true;
            this.layoutManagerformOSTEMELJNICA.Dock = DockStyle.Fill;
            this.layoutManagerformOSTEMELJNICA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformOSTEMELJNICA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformOSTEMELJNICA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformOSTEMELJNICA.Size = size;
            this.layoutManagerformOSTEMELJNICA.ColumnCount = 2;
            this.layoutManagerformOSTEMELJNICA.RowCount = 10;
            this.layoutManagerformOSTEMELJNICA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOSTEMELJNICA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOSTEMELJNICA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSTEMELJNICA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSTEMELJNICA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSTEMELJNICA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSTEMELJNICA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSTEMELJNICA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSTEMELJNICA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSTEMELJNICA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSTEMELJNICA.RowStyles.Add(new RowStyle());
            this.layoutManagerformOSTEMELJNICA.RowStyles.Add(new RowStyle());
            this.label1IDOSDOKUMENT = new UltraLabel();
            this.comboIDOSDOKUMENT = new OSDOKUMENTComboBox();
            this.label1OSBROJDOKUMENTA = new UltraLabel();
            this.textOSBROJDOKUMENTA = new UltraNumericEditor();
            this.label1OSDATUMDOK = new UltraLabel();
            this.datePickerOSDATUMDOK = new UltraDateTimeEditor();
            this.label1OSKOLICINA = new UltraLabel();
            this.textOSKOLICINA = new UltraNumericEditor();
            this.label1OSSTOPA = new UltraLabel();
            this.textOSSTOPA = new UltraNumericEditor();
            this.label1OSOSNOVICA = new UltraLabel();
            this.textOSOSNOVICA = new UltraNumericEditor();
            this.label1OSDUGUJE = new UltraLabel();
            this.textOSDUGUJE = new UltraNumericEditor();
            this.label1OSPOTRAZUJE = new UltraLabel();
            this.textOSPOTRAZUJE = new UltraNumericEditor();
            this.label1RASHODLOKACIJEIDLOKACIJE = new UltraLabel();
            this.comboRASHODLOKACIJEIDLOKACIJE = new LOKACIJEComboBox();
            ((ISupportInitialize) this.textOSBROJDOKUMENTA).BeginInit();
            ((ISupportInitialize) this.textOSKOLICINA).BeginInit();
            ((ISupportInitialize) this.textOSSTOPA).BeginInit();
            ((ISupportInitialize) this.textOSOSNOVICA).BeginInit();
            ((ISupportInitialize) this.textOSDUGUJE).BeginInit();
            ((ISupportInitialize) this.textOSPOTRAZUJE).BeginInit();
            this.dsOSDataSet1 = new OSDataSet();
            this.dsOSDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsOSDataSet1.DataSetName = "dsOS";
            this.dsOSDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceOSTEMELJNICA.DataSource = this.dsOSDataSet1;
            this.bindingSourceOSTEMELJNICA.DataMember = "OSTEMELJNICA";
            ((ISupportInitialize) this.bindingSourceOSTEMELJNICA).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.label1IDOSDOKUMENT.Location = point;
            this.label1IDOSDOKUMENT.Name = "label1IDOSDOKUMENT";
            this.label1IDOSDOKUMENT.TabIndex = 1;
            this.label1IDOSDOKUMENT.Tag = "labelIDOSDOKUMENT";
            this.label1IDOSDOKUMENT.Text = "Dokument:";
            this.label1IDOSDOKUMENT.StyleSetName = "FieldUltraLabel";
            this.label1IDOSDOKUMENT.AutoSize = true;
            this.label1IDOSDOKUMENT.Anchor = AnchorStyles.Left;
            this.label1IDOSDOKUMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOSDOKUMENT.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDOSDOKUMENT.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDOSDOKUMENT.ImageSize = size;
            this.label1IDOSDOKUMENT.Appearance.ForeColor = Color.Black;
            this.label1IDOSDOKUMENT.BackColor = Color.Transparent;
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.label1IDOSDOKUMENT, 0, 0);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.label1IDOSDOKUMENT, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.label1IDOSDOKUMENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDOSDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOSDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x51, 0x17);
            this.label1IDOSDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDOSDOKUMENT.Location = point;
            this.comboIDOSDOKUMENT.Name = "comboIDOSDOKUMENT";
            this.comboIDOSDOKUMENT.Tag = "IDOSDOKUMENT";
            this.comboIDOSDOKUMENT.TabIndex = 0;
            this.comboIDOSDOKUMENT.Anchor = AnchorStyles.Left;
            this.comboIDOSDOKUMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDOSDOKUMENT.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDOSDOKUMENT.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDOSDOKUMENT.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDOSDOKUMENT.Enabled = true;
            this.comboIDOSDOKUMENT.DataBindings.Add(new Binding("Value", this.bindingSourceOSTEMELJNICA, "IDOSDOKUMENT"));
            this.comboIDOSDOKUMENT.ShowPictureBox = true;
            this.comboIDOSDOKUMENT.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDOSDOKUMENT);
            this.comboIDOSDOKUMENT.ValueMember = "IDOSDOKUMENT";
            this.comboIDOSDOKUMENT.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDOSDOKUMENT);
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.comboIDOSDOKUMENT, 1, 0);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.comboIDOSDOKUMENT, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.comboIDOSDOKUMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDOSDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0x150, 0x17);
            this.comboIDOSDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x150, 0x17);
            this.comboIDOSDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OSBROJDOKUMENTA.Location = point;
            this.label1OSBROJDOKUMENTA.Name = "label1OSBROJDOKUMENTA";
            this.label1OSBROJDOKUMENTA.TabIndex = 1;
            this.label1OSBROJDOKUMENTA.Tag = "labelOSBROJDOKUMENTA";
            this.label1OSBROJDOKUMENTA.Text = "Broj:";
            this.label1OSBROJDOKUMENTA.StyleSetName = "FieldUltraLabel";
            this.label1OSBROJDOKUMENTA.AutoSize = true;
            this.label1OSBROJDOKUMENTA.Anchor = AnchorStyles.Left;
            this.label1OSBROJDOKUMENTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OSBROJDOKUMENTA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1OSBROJDOKUMENTA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1OSBROJDOKUMENTA.ImageSize = size;
            this.label1OSBROJDOKUMENTA.Appearance.ForeColor = Color.Black;
            this.label1OSBROJDOKUMENTA.BackColor = Color.Transparent;
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.label1OSBROJDOKUMENTA, 0, 1);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.label1OSBROJDOKUMENTA, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.label1OSBROJDOKUMENTA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OSBROJDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OSBROJDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x2a, 0x17);
            this.label1OSBROJDOKUMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOSBROJDOKUMENTA.Location = point;
            this.textOSBROJDOKUMENTA.Name = "textOSBROJDOKUMENTA";
            this.textOSBROJDOKUMENTA.Tag = "OSBROJDOKUMENTA";
            this.textOSBROJDOKUMENTA.TabIndex = 0;
            this.textOSBROJDOKUMENTA.Anchor = AnchorStyles.Left;
            this.textOSBROJDOKUMENTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOSBROJDOKUMENTA.ReadOnly = false;
            this.textOSBROJDOKUMENTA.PromptChar = ' ';
            this.textOSBROJDOKUMENTA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOSBROJDOKUMENTA.DataBindings.Add(new Binding("Value", this.bindingSourceOSTEMELJNICA, "OSBROJDOKUMENTA"));
            this.textOSBROJDOKUMENTA.NumericType = NumericType.Integer;
            this.textOSBROJDOKUMENTA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.textOSBROJDOKUMENTA, 1, 1);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.textOSBROJDOKUMENTA, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.textOSBROJDOKUMENTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOSBROJDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textOSBROJDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textOSBROJDOKUMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OSDATUMDOK.Location = point;
            this.label1OSDATUMDOK.Name = "label1OSDATUMDOK";
            this.label1OSDATUMDOK.TabIndex = 1;
            this.label1OSDATUMDOK.Tag = "labelOSDATUMDOK";
            this.label1OSDATUMDOK.Text = "Datum:";
            this.label1OSDATUMDOK.StyleSetName = "FieldUltraLabel";
            this.label1OSDATUMDOK.AutoSize = true;
            this.label1OSDATUMDOK.Anchor = AnchorStyles.Left;
            this.label1OSDATUMDOK.Appearance.TextVAlign = VAlign.Middle;
            this.label1OSDATUMDOK.Appearance.ForeColor = Color.Black;
            this.label1OSDATUMDOK.BackColor = Color.Transparent;
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.label1OSDATUMDOK, 0, 2);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.label1OSDATUMDOK, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.label1OSDATUMDOK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OSDATUMDOK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OSDATUMDOK.MinimumSize = size;
            size = new System.Drawing.Size(0x3d, 0x17);
            this.label1OSDATUMDOK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerOSDATUMDOK.Location = point;
            this.datePickerOSDATUMDOK.Name = "datePickerOSDATUMDOK";
            this.datePickerOSDATUMDOK.Tag = "OSDATUMDOK";
            this.datePickerOSDATUMDOK.TabIndex = 0;
            this.datePickerOSDATUMDOK.Anchor = AnchorStyles.Left;
            this.datePickerOSDATUMDOK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerOSDATUMDOK.Enabled = true;
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.datePickerOSDATUMDOK, 1, 2);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.datePickerOSDATUMDOK, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.datePickerOSDATUMDOK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerOSDATUMDOK.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerOSDATUMDOK.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerOSDATUMDOK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OSKOLICINA.Location = point;
            this.label1OSKOLICINA.Name = "label1OSKOLICINA";
            this.label1OSKOLICINA.TabIndex = 1;
            this.label1OSKOLICINA.Tag = "labelOSKOLICINA";
            this.label1OSKOLICINA.Text = "Količina:";
            this.label1OSKOLICINA.StyleSetName = "FieldUltraLabel";
            this.label1OSKOLICINA.AutoSize = true;
            this.label1OSKOLICINA.Anchor = AnchorStyles.Left;
            this.label1OSKOLICINA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OSKOLICINA.Appearance.ForeColor = Color.Black;
            this.label1OSKOLICINA.BackColor = Color.Transparent;
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.label1OSKOLICINA, 0, 3);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.label1OSKOLICINA, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.label1OSKOLICINA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OSKOLICINA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OSKOLICINA.MinimumSize = size;
            size = new System.Drawing.Size(0x44, 0x17);
            this.label1OSKOLICINA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOSKOLICINA.Location = point;
            this.textOSKOLICINA.Name = "textOSKOLICINA";
            this.textOSKOLICINA.Tag = "OSKOLICINA";
            this.textOSKOLICINA.TabIndex = 0;
            this.textOSKOLICINA.Anchor = AnchorStyles.Left;
            this.textOSKOLICINA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOSKOLICINA.ReadOnly = false;
            this.textOSKOLICINA.PromptChar = ' ';
            this.textOSKOLICINA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOSKOLICINA.DataBindings.Add(new Binding("Value", this.bindingSourceOSTEMELJNICA, "OSKOLICINA"));
            this.textOSKOLICINA.NumericType = NumericType.Double;
            this.textOSKOLICINA.MaxValue = 79228162514264337593543950335M;
            this.textOSKOLICINA.MinValue = -79228162514264337593543950335M;
            this.textOSKOLICINA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.textOSKOLICINA, 1, 3);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.textOSKOLICINA, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.textOSKOLICINA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOSKOLICINA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOSKOLICINA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOSKOLICINA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OSSTOPA.Location = point;
            this.label1OSSTOPA.Name = "label1OSSTOPA";
            this.label1OSSTOPA.TabIndex = 1;
            this.label1OSSTOPA.Tag = "labelOSSTOPA";
            this.label1OSSTOPA.Text = "Stopa:";
            this.label1OSSTOPA.StyleSetName = "FieldUltraLabel";
            this.label1OSSTOPA.AutoSize = true;
            this.label1OSSTOPA.Anchor = AnchorStyles.Left;
            this.label1OSSTOPA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OSSTOPA.Appearance.ForeColor = Color.Black;
            this.label1OSSTOPA.BackColor = Color.Transparent;
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.label1OSSTOPA, 0, 4);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.label1OSSTOPA, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.label1OSSTOPA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OSSTOPA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OSSTOPA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x17);
            this.label1OSSTOPA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOSSTOPA.Location = point;
            this.textOSSTOPA.Name = "textOSSTOPA";
            this.textOSSTOPA.Tag = "OSSTOPA";
            this.textOSSTOPA.TabIndex = 0;
            this.textOSSTOPA.Anchor = AnchorStyles.Left;
            this.textOSSTOPA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOSSTOPA.ReadOnly = false;
            this.textOSSTOPA.PromptChar = ' ';
            this.textOSSTOPA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOSSTOPA.DataBindings.Add(new Binding("Value", this.bindingSourceOSTEMELJNICA, "OSSTOPA"));
            this.textOSSTOPA.NumericType = NumericType.Double;
            this.textOSSTOPA.MaxValue = 79228162514264337593543950335M;
            this.textOSSTOPA.MinValue = -79228162514264337593543950335M;
            this.textOSSTOPA.MaskInput = "{LOC}-nnn.nn";
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.textOSSTOPA, 1, 4);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.textOSSTOPA, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.textOSSTOPA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOSSTOPA.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textOSSTOPA.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.textOSSTOPA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OSOSNOVICA.Location = point;
            this.label1OSOSNOVICA.Name = "label1OSOSNOVICA";
            this.label1OSOSNOVICA.TabIndex = 1;
            this.label1OSOSNOVICA.Tag = "labelOSOSNOVICA";
            this.label1OSOSNOVICA.Text = "Osnovica:";
            this.label1OSOSNOVICA.StyleSetName = "FieldUltraLabel";
            this.label1OSOSNOVICA.AutoSize = true;
            this.label1OSOSNOVICA.Anchor = AnchorStyles.Left;
            this.label1OSOSNOVICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1OSOSNOVICA.Appearance.ForeColor = Color.Black;
            this.label1OSOSNOVICA.BackColor = Color.Transparent;
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.label1OSOSNOVICA, 0, 5);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.label1OSOSNOVICA, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.label1OSOSNOVICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OSOSNOVICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OSOSNOVICA.MinimumSize = size;
            size = new System.Drawing.Size(0x4b, 0x17);
            this.label1OSOSNOVICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOSOSNOVICA.Location = point;
            this.textOSOSNOVICA.Name = "textOSOSNOVICA";
            this.textOSOSNOVICA.Tag = "OSOSNOVICA";
            this.textOSOSNOVICA.TabIndex = 0;
            this.textOSOSNOVICA.Anchor = AnchorStyles.Left;
            this.textOSOSNOVICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOSOSNOVICA.ReadOnly = false;
            this.textOSOSNOVICA.PromptChar = ' ';
            this.textOSOSNOVICA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOSOSNOVICA.DataBindings.Add(new Binding("Value", this.bindingSourceOSTEMELJNICA, "OSOSNOVICA"));
            this.textOSOSNOVICA.NumericType = NumericType.Double;
            this.textOSOSNOVICA.MaxValue = 79228162514264337593543950335M;
            this.textOSOSNOVICA.MinValue = -79228162514264337593543950335M;
            this.textOSOSNOVICA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.textOSOSNOVICA, 1, 5);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.textOSOSNOVICA, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.textOSOSNOVICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOSOSNOVICA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOSOSNOVICA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOSOSNOVICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OSDUGUJE.Location = point;
            this.label1OSDUGUJE.Name = "label1OSDUGUJE";
            this.label1OSDUGUJE.TabIndex = 1;
            this.label1OSDUGUJE.Tag = "labelOSDUGUJE";
            this.label1OSDUGUJE.Text = "Duguje:";
            this.label1OSDUGUJE.StyleSetName = "FieldUltraLabel";
            this.label1OSDUGUJE.AutoSize = true;
            this.label1OSDUGUJE.Anchor = AnchorStyles.Left;
            this.label1OSDUGUJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1OSDUGUJE.Appearance.ForeColor = Color.Black;
            this.label1OSDUGUJE.BackColor = Color.Transparent;
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.label1OSDUGUJE, 0, 6);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.label1OSDUGUJE, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.label1OSDUGUJE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OSDUGUJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OSDUGUJE.MinimumSize = size;
            size = new System.Drawing.Size(0x40, 0x17);
            this.label1OSDUGUJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOSDUGUJE.Location = point;
            this.textOSDUGUJE.Name = "textOSDUGUJE";
            this.textOSDUGUJE.Tag = "OSDUGUJE";
            this.textOSDUGUJE.TabIndex = 0;
            this.textOSDUGUJE.Anchor = AnchorStyles.Left;
            this.textOSDUGUJE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOSDUGUJE.ReadOnly = false;
            this.textOSDUGUJE.PromptChar = ' ';
            this.textOSDUGUJE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOSDUGUJE.DataBindings.Add(new Binding("Value", this.bindingSourceOSTEMELJNICA, "OSDUGUJE"));
            this.textOSDUGUJE.NumericType = NumericType.Double;
            this.textOSDUGUJE.MaxValue = 79228162514264337593543950335M;
            this.textOSDUGUJE.MinValue = -79228162514264337593543950335M;
            this.textOSDUGUJE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.textOSDUGUJE, 1, 6);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.textOSDUGUJE, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.textOSDUGUJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOSDUGUJE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOSDUGUJE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOSDUGUJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OSPOTRAZUJE.Location = point;
            this.label1OSPOTRAZUJE.Name = "label1OSPOTRAZUJE";
            this.label1OSPOTRAZUJE.TabIndex = 1;
            this.label1OSPOTRAZUJE.Tag = "labelOSPOTRAZUJE";
            this.label1OSPOTRAZUJE.Text = "Potražuje:";
            this.label1OSPOTRAZUJE.StyleSetName = "FieldUltraLabel";
            this.label1OSPOTRAZUJE.AutoSize = true;
            this.label1OSPOTRAZUJE.Anchor = AnchorStyles.Left;
            this.label1OSPOTRAZUJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1OSPOTRAZUJE.Appearance.ForeColor = Color.Black;
            this.label1OSPOTRAZUJE.BackColor = Color.Transparent;
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.label1OSPOTRAZUJE, 0, 7);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.label1OSPOTRAZUJE, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.label1OSPOTRAZUJE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OSPOTRAZUJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OSPOTRAZUJE.MinimumSize = size;
            size = new System.Drawing.Size(0x4f, 0x17);
            this.label1OSPOTRAZUJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOSPOTRAZUJE.Location = point;
            this.textOSPOTRAZUJE.Name = "textOSPOTRAZUJE";
            this.textOSPOTRAZUJE.Tag = "OSPOTRAZUJE";
            this.textOSPOTRAZUJE.TabIndex = 0;
            this.textOSPOTRAZUJE.Anchor = AnchorStyles.Left;
            this.textOSPOTRAZUJE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOSPOTRAZUJE.ReadOnly = false;
            this.textOSPOTRAZUJE.PromptChar = ' ';
            this.textOSPOTRAZUJE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textOSPOTRAZUJE.DataBindings.Add(new Binding("Value", this.bindingSourceOSTEMELJNICA, "OSPOTRAZUJE"));
            this.textOSPOTRAZUJE.NumericType = NumericType.Double;
            this.textOSPOTRAZUJE.MaxValue = 79228162514264337593543950335M;
            this.textOSPOTRAZUJE.MinValue = -79228162514264337593543950335M;
            this.textOSPOTRAZUJE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.textOSPOTRAZUJE, 1, 7);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.textOSPOTRAZUJE, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.textOSPOTRAZUJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOSPOTRAZUJE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOSPOTRAZUJE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOSPOTRAZUJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RASHODLOKACIJEIDLOKACIJE.Location = point;
            this.label1RASHODLOKACIJEIDLOKACIJE.Name = "label1RASHODLOKACIJEIDLOKACIJE";
            this.label1RASHODLOKACIJEIDLOKACIJE.TabIndex = 1;
            this.label1RASHODLOKACIJEIDLOKACIJE.Tag = "labelRASHODLOKACIJEIDLOKACIJE";
            this.label1RASHODLOKACIJEIDLOKACIJE.Text = "Lokacija:";
            this.label1RASHODLOKACIJEIDLOKACIJE.StyleSetName = "FieldUltraLabel";
            this.label1RASHODLOKACIJEIDLOKACIJE.AutoSize = true;
            this.label1RASHODLOKACIJEIDLOKACIJE.Anchor = AnchorStyles.Left;
            this.label1RASHODLOKACIJEIDLOKACIJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1RASHODLOKACIJEIDLOKACIJE.Appearance.ForeColor = Color.Black;
            this.label1RASHODLOKACIJEIDLOKACIJE.BackColor = Color.Transparent;
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.label1RASHODLOKACIJEIDLOKACIJE, 0, 8);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.label1RASHODLOKACIJEIDLOKACIJE, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.label1RASHODLOKACIJEIDLOKACIJE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RASHODLOKACIJEIDLOKACIJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RASHODLOKACIJEIDLOKACIJE.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x17);
            this.label1RASHODLOKACIJEIDLOKACIJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboRASHODLOKACIJEIDLOKACIJE.Location = point;
            this.comboRASHODLOKACIJEIDLOKACIJE.Name = "comboRASHODLOKACIJEIDLOKACIJE";
            this.comboRASHODLOKACIJEIDLOKACIJE.Tag = "RASHODLOKACIJEIDLOKACIJE";
            this.comboRASHODLOKACIJEIDLOKACIJE.TabIndex = 0;
            this.comboRASHODLOKACIJEIDLOKACIJE.Anchor = AnchorStyles.Left;
            this.comboRASHODLOKACIJEIDLOKACIJE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboRASHODLOKACIJEIDLOKACIJE.ContextMenu = this.contextMenu1;
            this.comboRASHODLOKACIJEIDLOKACIJE.DropDownStyle = DropDownStyle.DropDown;
            this.comboRASHODLOKACIJEIDLOKACIJE.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboRASHODLOKACIJEIDLOKACIJE.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboRASHODLOKACIJEIDLOKACIJE.Enabled = true;
            this.comboRASHODLOKACIJEIDLOKACIJE.DataBindings.Add(new Binding("Value", this.bindingSourceOSTEMELJNICA, "RASHODLOKACIJEIDLOKACIJE"));
            this.comboRASHODLOKACIJEIDLOKACIJE.ShowPictureBox = true;
            this.comboRASHODLOKACIJEIDLOKACIJE.PictureBoxClicked += new EventHandler(this.PictureBoxClickedRASHODLOKACIJEIDLOKACIJE);
            this.comboRASHODLOKACIJEIDLOKACIJE.ValueMember = "IDLOKACIJE";
            this.comboRASHODLOKACIJEIDLOKACIJE.SelectionChanged += new EventHandler(this.SelectedIndexChangedRASHODLOKACIJEIDLOKACIJE);
            this.layoutManagerformOSTEMELJNICA.Controls.Add(this.comboRASHODLOKACIJEIDLOKACIJE, 1, 8);
            this.layoutManagerformOSTEMELJNICA.SetColumnSpan(this.comboRASHODLOKACIJEIDLOKACIJE, 1);
            this.layoutManagerformOSTEMELJNICA.SetRowSpan(this.comboRASHODLOKACIJEIDLOKACIJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboRASHODLOKACIJEIDLOKACIJE.Margin = padding;
            size = new System.Drawing.Size(0x1dc, 0x17);
            this.comboRASHODLOKACIJEIDLOKACIJE.MinimumSize = size;
            size = new System.Drawing.Size(0x1dc, 0x17);
            this.comboRASHODLOKACIJEIDLOKACIJE.Size = size;
            this.Controls.Add(this.layoutManagerformOSTEMELJNICA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceOSTEMELJNICA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "OSFormOSTEMELJNICAUserControl";
            this.Text = " TEMELJNICA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OSFormUserControl_Load);
            this.layoutManagerformOSTEMELJNICA.ResumeLayout(false);
            this.layoutManagerformOSTEMELJNICA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceOSTEMELJNICA).EndInit();
            ((ISupportInitialize) this.textOSBROJDOKUMENTA).EndInit();
            ((ISupportInitialize) this.textOSKOLICINA).EndInit();
            ((ISupportInitialize) this.textOSSTOPA).EndInit();
            ((ISupportInitialize) this.textOSOSNOVICA).EndInit();
            ((ISupportInitialize) this.textOSDUGUJE).EndInit();
            ((ISupportInitialize) this.textOSPOTRAZUJE).EndInit();
            this.dsOSDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OSController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceOSTEMELJNICA, this.OSController.WorkItem, this))
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
            this.label1IDOSDOKUMENT.Text = StringResources.OSIDOSDOKUMENTDescription;
            this.label1OSBROJDOKUMENTA.Text = StringResources.OSOSBROJDOKUMENTADescription;
            this.label1OSDATUMDOK.Text = StringResources.OSOSDATUMDOKDescription;
            this.label1OSKOLICINA.Text = StringResources.OSOSKOLICINADescription;
            this.label1OSSTOPA.Text = StringResources.OSOSSTOPADescription;
            this.label1OSOSNOVICA.Text = StringResources.OSOSOSNOVICADescription;
            this.label1OSDUGUJE.Text = StringResources.OSOSDUGUJEDescription;
            this.label1OSPOTRAZUJE.Text = StringResources.OSOSPOTRAZUJEDescription;
            this.label1RASHODLOKACIJEIDLOKACIJE.Text = StringResources.OSRASHODLOKACIJEIDLOKACIJEDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewOSRAZMJESTAJ")]
        public void NewOSRAZMJESTAJHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OSController.NewOSRAZMJESTAJ(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void OSFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OSOSTEMELJNICALevelDescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void PictureBoxClickedIDOSDOKUMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("OSDOKUMENT", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedRASHODLOKACIJEIDLOKACIJE(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("LOKACIJE", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.OSController.WorkItem.Items.Contains("OSTEMELJNICA|OSTEMELJNICA"))
            {
                this.OSController.WorkItem.Items.Add(this.bindingSourceOSTEMELJNICA, "OSTEMELJNICA|OSTEMELJNICA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("OSTEMELJNICASaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedIDOSDOKUMENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDOSDOKUMENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDOSDOKUMENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceOSTEMELJNICA.Current).Row["IDOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(row["IDOSDOKUMENT"]);
                    ((DataRowView) this.bindingSourceOSTEMELJNICA.Current).Row["NAZIVOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(row["NAZIVOSDOKUMENT"]);
                    this.bindingSourceOSTEMELJNICA.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedRASHODLOKACIJEIDLOKACIJE(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboRASHODLOKACIJEIDLOKACIJE.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboRASHODLOKACIJEIDLOKACIJE.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceOSTEMELJNICA.Current).Row["RASHODLOKACIJEIDLOKACIJE"] = RuntimeHelpers.GetObjectValue(row["IDLOKACIJE"]);
                    this.bindingSourceOSTEMELJNICA.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.comboIDOSDOKUMENT.Focus();
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

        [LocalCommandHandler("ViewOSRAZMJESTAJ")]
        public void ViewOSRAZMJESTAJHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OSController.ViewOSRAZMJESTAJ(this.m_CurrentRow);
            }
        }

        protected virtual OSDOKUMENTComboBox comboIDOSDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDOSDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDOSDOKUMENT = value;
            }
        }

        protected virtual LOKACIJEComboBox comboRASHODLOKACIJEIDLOKACIJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboRASHODLOKACIJEIDLOKACIJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboRASHODLOKACIJEIDLOKACIJE = value;
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

        protected virtual UltraDateTimeEditor datePickerOSDATUMDOK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerOSDATUMDOK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerOSDATUMDOK = value;
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

        protected virtual UltraLabel label1IDOSDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOSDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOSDOKUMENT = value;
            }
        }

        protected virtual UltraLabel label1OSBROJDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OSBROJDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OSBROJDOKUMENTA = value;
            }
        }

        protected virtual UltraLabel label1OSDATUMDOK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OSDATUMDOK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OSDATUMDOK = value;
            }
        }

        protected virtual UltraLabel label1OSDUGUJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OSDUGUJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OSDUGUJE = value;
            }
        }

        protected virtual UltraLabel label1OSKOLICINA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OSKOLICINA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OSKOLICINA = value;
            }
        }

        protected virtual UltraLabel label1OSOSNOVICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OSOSNOVICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OSOSNOVICA = value;
            }
        }

        protected virtual UltraLabel label1OSPOTRAZUJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OSPOTRAZUJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OSPOTRAZUJE = value;
            }
        }

        protected virtual UltraLabel label1OSSTOPA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OSSTOPA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OSSTOPA = value;
            }
        }

        protected virtual UltraLabel label1RASHODLOKACIJEIDLOKACIJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RASHODLOKACIJEIDLOKACIJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RASHODLOKACIJEIDLOKACIJE = value;
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
        public NetAdvantage.Controllers.OSController OSController { get; set; }

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

        protected virtual UltraNumericEditor textOSBROJDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOSBROJDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOSBROJDOKUMENTA = value;
            }
        }

        protected virtual UltraNumericEditor textOSDUGUJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOSDUGUJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOSDUGUJE = value;
            }
        }

        protected virtual UltraNumericEditor textOSKOLICINA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOSKOLICINA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOSKOLICINA = value;
            }
        }

        protected virtual UltraNumericEditor textOSOSNOVICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOSOSNOVICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOSOSNOVICA = value;
            }
        }

        protected virtual UltraNumericEditor textOSPOTRAZUJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOSPOTRAZUJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOSPOTRAZUJE = value;
            }
        }

        protected virtual UltraNumericEditor textOSSTOPA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOSSTOPA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOSSTOPA = value;
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

