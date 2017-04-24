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
    public class GKSTAVKAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkstatusgk")]
        private UltraCheckEditor _checkstatusgk;
        [AccessedThroughProperty("comboIDDOKUMENT")]
        private DOKUMENTComboBox _comboIDDOKUMENT;
        [AccessedThroughProperty("comboIDKONTO")]
        private KONTOComboBox _comboIDKONTO;
        [AccessedThroughProperty("comboIDMJESTOTROSKA")]
        private MJESTOTROSKAComboBox _comboIDMJESTOTROSKA;
        [AccessedThroughProperty("comboIDORGJED")]
        private ORGJEDComboBox _comboIDORGJED;
        [AccessedThroughProperty("comboIDPARTNER")]
        private PARTNERComboBox _comboIDPARTNER;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("datePickerDATUMDOKUMENTA")]
        private UltraDateTimeEditor _datePickerDATUMDOKUMENTA;
        [AccessedThroughProperty("datePickerDATUMPRIJAVE")]
        private UltraDateTimeEditor _datePickerDATUMPRIJAVE;
        [AccessedThroughProperty("datePickerGKDATUMVALUTE")]
        private UltraDateTimeEditor _datePickerGKDATUMVALUTE;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1BROJDOKUMENTA")]
        private UltraLabel _label1BROJDOKUMENTA;
        [AccessedThroughProperty("label1BROJSTAVKE")]
        private UltraLabel _label1BROJSTAVKE;
        [AccessedThroughProperty("label1DATUMDOKUMENTA")]
        private UltraLabel _label1DATUMDOKUMENTA;
        [AccessedThroughProperty("label1DATUMPRIJAVE")]
        private UltraLabel _label1DATUMPRIJAVE;
        [AccessedThroughProperty("label1duguje")]
        private UltraLabel _label1duguje;
        [AccessedThroughProperty("label1GKDATUMVALUTE")]
        private UltraLabel _label1GKDATUMVALUTE;
        [AccessedThroughProperty("label1GKGODIDGODINE")]
        private UltraLabel _label1GKGODIDGODINE;
        [AccessedThroughProperty("label1IDAKTIVNOST")]
        private UltraLabel _label1IDAKTIVNOST;
        [AccessedThroughProperty("label1IDDOKUMENT")]
        private UltraLabel _label1IDDOKUMENT;
        [AccessedThroughProperty("label1IDKONTO")]
        private UltraLabel _label1IDKONTO;
        [AccessedThroughProperty("label1IDMJESTOTROSKA")]
        private UltraLabel _label1IDMJESTOTROSKA;
        [AccessedThroughProperty("label1IDORGJED")]
        private UltraLabel _label1IDORGJED;
        [AccessedThroughProperty("label1IDPARTNER")]
        private UltraLabel _label1IDPARTNER;
        [AccessedThroughProperty("label1NAZIVAKTIVNOST")]
        private UltraLabel _label1NAZIVAKTIVNOST;
        [AccessedThroughProperty("label1NAZIVKONTO")]
        private UltraLabel _label1NAZIVKONTO;
        [AccessedThroughProperty("label1NAZIVMJESTOTROSKA")]
        private UltraLabel _label1NAZIVMJESTOTROSKA;
        [AccessedThroughProperty("label1NAZIVORGJED")]
        private UltraLabel _label1NAZIVORGJED;
        [AccessedThroughProperty("label1NAZIVPARTNER")]
        private UltraLabel _label1NAZIVPARTNER;
        [AccessedThroughProperty("label1OPIS")]
        private UltraLabel _label1OPIS;
        [AccessedThroughProperty("label1ORIGINALNIDOKUMENT")]
        private UltraLabel _label1ORIGINALNIDOKUMENT;
        [AccessedThroughProperty("label1POTRAZUJE")]
        private UltraLabel _label1POTRAZUJE;
        [AccessedThroughProperty("label1statusgk")]
        private UltraLabel _label1statusgk;
        [AccessedThroughProperty("label1ZATVORENIIZNOS")]
        private UltraLabel _label1ZATVORENIIZNOS;
        [AccessedThroughProperty("labelIDAKTIVNOST")]
        private UltraLabel _labelIDAKTIVNOST;
        [AccessedThroughProperty("labelNAZIVAKTIVNOST")]
        private UltraLabel _labelNAZIVAKTIVNOST;
        [AccessedThroughProperty("labelNAZIVKONTO")]
        private UltraLabel _labelNAZIVKONTO;
        [AccessedThroughProperty("labelNAZIVMJESTOTROSKA")]
        private UltraLabel _labelNAZIVMJESTOTROSKA;
        [AccessedThroughProperty("labelNAZIVORGJED")]
        private UltraLabel _labelNAZIVORGJED;
        [AccessedThroughProperty("labelNAZIVPARTNER")]
        private UltraLabel _labelNAZIVPARTNER;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textBROJDOKUMENTA")]
        private UltraNumericEditor _textBROJDOKUMENTA;
        [AccessedThroughProperty("textBROJSTAVKE")]
        private UltraNumericEditor _textBROJSTAVKE;
        [AccessedThroughProperty("textduguje")]
        private UltraNumericEditor _textduguje;
        [AccessedThroughProperty("textGKGODIDGODINE")]
        private UltraNumericEditor _textGKGODIDGODINE;
        [AccessedThroughProperty("textOPIS")]
        private UltraTextEditor _textOPIS;
        [AccessedThroughProperty("textORIGINALNIDOKUMENT")]
        private UltraTextEditor _textORIGINALNIDOKUMENT;
        [AccessedThroughProperty("textPOTRAZUJE")]
        private UltraNumericEditor _textPOTRAZUJE;
        [AccessedThroughProperty("textZATVORENIIZNOS")]
        private UltraNumericEditor _textZATVORENIIZNOS;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceGKSTAVKA;
        private IContainer components = null;
        private GKSTAVKADataSet dsGKSTAVKADataSet1;
        protected TableLayoutPanel layoutManagerformGKSTAVKA;
        private bool m_AutoNumber = true;
        private GenericFormClass m_BaseMethods;
        private GKSTAVKADataSet.GKSTAVKARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "GKSTAVKA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.GKSTAVKADescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public GKSTAVKAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptGODINEGKGODIDGODINE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.GKSTAVKAController.SelectGODINEGKGODIDGODINE(fillMethod, fillByRow);
            this.UpdateValuesGODINEGKGODIDGODINE(result);
        }

        private void CallViewGODINEGKGODIDGODINE(object sender, EventArgs e)
        {
            DataRow result = this.GKSTAVKAController.ShowGODINEGKGODIDGODINE(this.m_CurrentRow);
            this.UpdateValuesGODINEGKGODIDGODINE(result);
        }

        public void ChangeBinding()
        {
            this.bindingSourceGKSTAVKA.DataSource = this.GKSTAVKAController.DataSet;
            this.dsGKSTAVKADataSet1 = this.GKSTAVKAController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/DOKUMENT", Thread=ThreadOption.UserInterface)]
        public void comboIDDOKUMENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDDOKUMENT.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void comboIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDKONTO.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/MJESTOTROSKA", Thread=ThreadOption.UserInterface)]
        public void comboIDMJESTOTROSKA_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDMJESTOTROSKA.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ORGJED", Thread=ThreadOption.UserInterface)]
        public void comboIDORGJED_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDORGJED.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/PARTNER", Thread=ThreadOption.UserInterface)]
        public void comboIDPARTNER_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDPARTNER.Fill();
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
                    enumerator = this.dsGKSTAVKADataSet1.GKSTAVKA.Rows.GetEnumerator();
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
                if (this.GKSTAVKAController.Update(this))
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

        private void GKSTAVKAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.GKSTAVKADescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "GKSTAVKA", this.m_Mode, this.dsGKSTAVKADataSet1, this.dsGKSTAVKADataSet1.GKSTAVKA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceGKSTAVKA, "DATUMDOKUMENTA", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerDATUMDOKUMENTA.DataBindings["Text"] != null)
            {
                this.datePickerDATUMDOKUMENTA.DataBindings.Remove(this.datePickerDATUMDOKUMENTA.DataBindings["Text"]);
            }
            this.datePickerDATUMDOKUMENTA.DataBindings.Add(binding);
            Binding binding2 = new Binding("Text", this.bindingSourceGKSTAVKA, "DATUMPRIJAVE", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding2.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParse);
            if (this.datePickerDATUMPRIJAVE.DataBindings["Text"] != null)
            {
                this.datePickerDATUMPRIJAVE.DataBindings.Remove(this.datePickerDATUMPRIJAVE.DataBindings["Text"]);
            }
            this.datePickerDATUMPRIJAVE.DataBindings.Add(binding2);
            Binding binding3 = new Binding("Text", this.bindingSourceGKSTAVKA, "GKDATUMVALUTE", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding3.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParse);
            if (this.datePickerGKDATUMVALUTE.DataBindings["Text"] != null)
            {
                this.datePickerGKDATUMVALUTE.DataBindings.Remove(this.datePickerGKDATUMVALUTE.DataBindings["Text"]);
            }
            this.datePickerGKDATUMVALUTE.DataBindings.Add(binding3);
            Binding binding4 = new Binding("CheckState", this.bindingSourceGKSTAVKA, "statusgk", true);
            binding4.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding4.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkstatusgk.DataBindings["CheckState"] != null)
            {
                this.checkstatusgk.DataBindings.Remove(this.checkstatusgk.DataBindings["CheckState"]);
            }
            this.checkstatusgk.DataBindings.Add(binding4);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsGKSTAVKADataSet1.GKSTAVKA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (GKSTAVKADataSet.GKSTAVKARow) ((DataRowView) this.bindingSourceGKSTAVKA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(GKSTAVKAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceGKSTAVKA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceGKSTAVKA).BeginInit();
            this.layoutManagerformGKSTAVKA = new TableLayoutPanel();
            this.layoutManagerformGKSTAVKA.SuspendLayout();
            this.layoutManagerformGKSTAVKA.AutoSize = true;
            this.layoutManagerformGKSTAVKA.Dock = DockStyle.Fill;
            this.layoutManagerformGKSTAVKA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformGKSTAVKA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformGKSTAVKA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformGKSTAVKA.Size = size;
            this.layoutManagerformGKSTAVKA.ColumnCount = 2;
            this.layoutManagerformGKSTAVKA.RowCount = 0x18;
            this.layoutManagerformGKSTAVKA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformGKSTAVKA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformGKSTAVKA.RowStyles.Add(new RowStyle());
            this.label1IDAKTIVNOST = new UltraLabel();
            this.labelIDAKTIVNOST = new UltraLabel();
            this.label1DATUMDOKUMENTA = new UltraLabel();
            this.datePickerDATUMDOKUMENTA = new UltraDateTimeEditor();
            this.label1BROJDOKUMENTA = new UltraLabel();
            this.textBROJDOKUMENTA = new UltraNumericEditor();
            this.label1BROJSTAVKE = new UltraLabel();
            this.textBROJSTAVKE = new UltraNumericEditor();
            this.label1IDDOKUMENT = new UltraLabel();
            this.comboIDDOKUMENT = new DOKUMENTComboBox();
            this.label1IDMJESTOTROSKA = new UltraLabel();
            this.comboIDMJESTOTROSKA = new MJESTOTROSKAComboBox();
            this.label1NAZIVMJESTOTROSKA = new UltraLabel();
            this.labelNAZIVMJESTOTROSKA = new UltraLabel();
            this.label1IDORGJED = new UltraLabel();
            this.comboIDORGJED = new ORGJEDComboBox();
            this.label1NAZIVORGJED = new UltraLabel();
            this.labelNAZIVORGJED = new UltraLabel();
            this.label1IDKONTO = new UltraLabel();
            this.comboIDKONTO = new KONTOComboBox();
            this.label1NAZIVKONTO = new UltraLabel();
            this.labelNAZIVKONTO = new UltraLabel();
            this.label1NAZIVAKTIVNOST = new UltraLabel();
            this.labelNAZIVAKTIVNOST = new UltraLabel();
            this.label1OPIS = new UltraLabel();
            this.textOPIS = new UltraTextEditor();
            this.label1duguje = new UltraLabel();
            this.textduguje = new UltraNumericEditor();
            this.label1POTRAZUJE = new UltraLabel();
            this.textPOTRAZUJE = new UltraNumericEditor();
            this.label1DATUMPRIJAVE = new UltraLabel();
            this.datePickerDATUMPRIJAVE = new UltraDateTimeEditor();
            this.label1IDPARTNER = new UltraLabel();
            this.comboIDPARTNER = new PARTNERComboBox();
            this.label1NAZIVPARTNER = new UltraLabel();
            this.labelNAZIVPARTNER = new UltraLabel();
            this.label1ZATVORENIIZNOS = new UltraLabel();
            this.textZATVORENIIZNOS = new UltraNumericEditor();
            this.label1GKDATUMVALUTE = new UltraLabel();
            this.datePickerGKDATUMVALUTE = new UltraDateTimeEditor();
            this.label1statusgk = new UltraLabel();
            this.checkstatusgk = new UltraCheckEditor();
            this.label1ORIGINALNIDOKUMENT = new UltraLabel();
            this.textORIGINALNIDOKUMENT = new UltraTextEditor();
            this.label1GKGODIDGODINE = new UltraLabel();
            this.textGKGODIDGODINE = new UltraNumericEditor();
            ((ISupportInitialize) this.textBROJDOKUMENTA).BeginInit();
            ((ISupportInitialize) this.textBROJSTAVKE).BeginInit();
            ((ISupportInitialize) this.textOPIS).BeginInit();
            ((ISupportInitialize) this.textduguje).BeginInit();
            ((ISupportInitialize) this.textPOTRAZUJE).BeginInit();
            ((ISupportInitialize) this.textZATVORENIIZNOS).BeginInit();
            ((ISupportInitialize) this.textORIGINALNIDOKUMENT).BeginInit();
            ((ISupportInitialize) this.textGKGODIDGODINE).BeginInit();
            this.dsGKSTAVKADataSet1 = new GKSTAVKADataSet();
            this.dsGKSTAVKADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsGKSTAVKADataSet1.DataSetName = "dsGKSTAVKA";
            this.dsGKSTAVKADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceGKSTAVKA.DataSource = this.dsGKSTAVKADataSet1;
            this.bindingSourceGKSTAVKA.DataMember = "GKSTAVKA";
            ((ISupportInitialize) this.bindingSourceGKSTAVKA).BeginInit();
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
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1IDAKTIVNOST, 0, 0);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1IDAKTIVNOST, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1IDAKTIVNOST, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDAKTIVNOST.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDAKTIVNOST.MinimumSize = size;
            size = new System.Drawing.Size(0x71, 0x17);
            this.label1IDAKTIVNOST.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelIDAKTIVNOST.Location = point;
            this.labelIDAKTIVNOST.Name = "labelIDAKTIVNOST";
            this.labelIDAKTIVNOST.Tag = "IDAKTIVNOST";
            this.labelIDAKTIVNOST.TabIndex = 0;
            this.labelIDAKTIVNOST.Anchor = AnchorStyles.Left;
            this.labelIDAKTIVNOST.BackColor = Color.Transparent;
            this.labelIDAKTIVNOST.Appearance.TextHAlign = HAlign.Left;
            this.labelIDAKTIVNOST.DataBindings.Add(new Binding("Text", this.bindingSourceGKSTAVKA, "IDAKTIVNOST"));
            this.labelIDAKTIVNOST.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.labelIDAKTIVNOST, 1, 0);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.labelIDAKTIVNOST, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.labelIDAKTIVNOST, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelIDAKTIVNOST.Margin = padding;
            size = new System.Drawing.Size(0x3a, 0x16);
            this.labelIDAKTIVNOST.MinimumSize = size;
            size = new System.Drawing.Size(0x3a, 0x16);
            this.labelIDAKTIVNOST.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DATUMDOKUMENTA.Location = point;
            this.label1DATUMDOKUMENTA.Name = "label1DATUMDOKUMENTA";
            this.label1DATUMDOKUMENTA.TabIndex = 1;
            this.label1DATUMDOKUMENTA.Tag = "labelDATUMDOKUMENTA";
            this.label1DATUMDOKUMENTA.Text = "Datum:";
            this.label1DATUMDOKUMENTA.StyleSetName = "FieldUltraLabel";
            this.label1DATUMDOKUMENTA.AutoSize = true;
            this.label1DATUMDOKUMENTA.Anchor = AnchorStyles.Left;
            this.label1DATUMDOKUMENTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMDOKUMENTA.Appearance.ForeColor = Color.Black;
            this.label1DATUMDOKUMENTA.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1DATUMDOKUMENTA, 0, 1);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1DATUMDOKUMENTA, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1DATUMDOKUMENTA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUMDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUMDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x3d, 0x17);
            this.label1DATUMDOKUMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUMDOKUMENTA.Location = point;
            this.datePickerDATUMDOKUMENTA.Name = "datePickerDATUMDOKUMENTA";
            this.datePickerDATUMDOKUMENTA.Tag = "DATUMDOKUMENTA";
            this.datePickerDATUMDOKUMENTA.TabIndex = 0;
            this.datePickerDATUMDOKUMENTA.Anchor = AnchorStyles.Left;
            this.datePickerDATUMDOKUMENTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMDOKUMENTA.Enabled = true;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.datePickerDATUMDOKUMENTA, 1, 1);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.datePickerDATUMDOKUMENTA, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.datePickerDATUMDOKUMENTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMDOKUMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1BROJDOKUMENTA.Location = point;
            this.label1BROJDOKUMENTA.Name = "label1BROJDOKUMENTA";
            this.label1BROJDOKUMENTA.TabIndex = 1;
            this.label1BROJDOKUMENTA.Tag = "labelBROJDOKUMENTA";
            this.label1BROJDOKUMENTA.Text = "Broj dok.:";
            this.label1BROJDOKUMENTA.StyleSetName = "FieldUltraLabel";
            this.label1BROJDOKUMENTA.AutoSize = true;
            this.label1BROJDOKUMENTA.Anchor = AnchorStyles.Left;
            this.label1BROJDOKUMENTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1BROJDOKUMENTA.Appearance.ForeColor = Color.Black;
            this.label1BROJDOKUMENTA.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1BROJDOKUMENTA, 0, 2);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1BROJDOKUMENTA, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1BROJDOKUMENTA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BROJDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BROJDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x4b, 0x17);
            this.label1BROJDOKUMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textBROJDOKUMENTA.Location = point;
            this.textBROJDOKUMENTA.Name = "textBROJDOKUMENTA";
            this.textBROJDOKUMENTA.Tag = "BROJDOKUMENTA";
            this.textBROJDOKUMENTA.TabIndex = 0;
            this.textBROJDOKUMENTA.Anchor = AnchorStyles.Left;
            this.textBROJDOKUMENTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textBROJDOKUMENTA.ReadOnly = false;
            this.textBROJDOKUMENTA.PromptChar = ' ';
            this.textBROJDOKUMENTA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textBROJDOKUMENTA.DataBindings.Add(new Binding("Value", this.bindingSourceGKSTAVKA, "BROJDOKUMENTA"));
            this.textBROJDOKUMENTA.NumericType = NumericType.Integer;
            this.textBROJDOKUMENTA.MaskInput = "{LOC}-nnnnnn";
            this.layoutManagerformGKSTAVKA.Controls.Add(this.textBROJDOKUMENTA, 1, 2);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.textBROJDOKUMENTA, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.textBROJDOKUMENTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBROJDOKUMENTA.Margin = padding;
            size = new System.Drawing.Size(0x3a, 0x16);
            this.textBROJDOKUMENTA.MinimumSize = size;
            size = new System.Drawing.Size(0x3a, 0x16);
            this.textBROJDOKUMENTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1BROJSTAVKE.Location = point;
            this.label1BROJSTAVKE.Name = "label1BROJSTAVKE";
            this.label1BROJSTAVKE.TabIndex = 1;
            this.label1BROJSTAVKE.Tag = "labelBROJSTAVKE";
            this.label1BROJSTAVKE.Text = "Stavka:";
            this.label1BROJSTAVKE.StyleSetName = "FieldUltraLabel";
            this.label1BROJSTAVKE.AutoSize = true;
            this.label1BROJSTAVKE.Anchor = AnchorStyles.Left;
            this.label1BROJSTAVKE.Appearance.TextVAlign = VAlign.Middle;
            this.label1BROJSTAVKE.Appearance.ForeColor = Color.Black;
            this.label1BROJSTAVKE.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1BROJSTAVKE, 0, 3);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1BROJSTAVKE, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1BROJSTAVKE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BROJSTAVKE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BROJSTAVKE.MinimumSize = size;
            size = new System.Drawing.Size(0x3d, 0x17);
            this.label1BROJSTAVKE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textBROJSTAVKE.Location = point;
            this.textBROJSTAVKE.Name = "textBROJSTAVKE";
            this.textBROJSTAVKE.Tag = "BROJSTAVKE";
            this.textBROJSTAVKE.TabIndex = 0;
            this.textBROJSTAVKE.Anchor = AnchorStyles.Left;
            this.textBROJSTAVKE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textBROJSTAVKE.ReadOnly = false;
            this.textBROJSTAVKE.PromptChar = ' ';
            this.textBROJSTAVKE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textBROJSTAVKE.DataBindings.Add(new Binding("Value", this.bindingSourceGKSTAVKA, "BROJSTAVKE"));
            this.textBROJSTAVKE.NumericType = NumericType.Integer;
            this.textBROJSTAVKE.MaskInput = "{LOC}-nnnnnn";
            this.layoutManagerformGKSTAVKA.Controls.Add(this.textBROJSTAVKE, 1, 3);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.textBROJSTAVKE, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.textBROJSTAVKE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBROJSTAVKE.Margin = padding;
            size = new System.Drawing.Size(0x3a, 0x16);
            this.textBROJSTAVKE.MinimumSize = size;
            size = new System.Drawing.Size(0x3a, 0x16);
            this.textBROJSTAVKE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDDOKUMENT.Location = point;
            this.label1IDDOKUMENT.Name = "label1IDDOKUMENT";
            this.label1IDDOKUMENT.TabIndex = 1;
            this.label1IDDOKUMENT.Tag = "labelIDDOKUMENT";
            this.label1IDDOKUMENT.Text = "Šifra dokumenta:";
            this.label1IDDOKUMENT.StyleSetName = "FieldUltraLabel";
            this.label1IDDOKUMENT.AutoSize = true;
            this.label1IDDOKUMENT.Anchor = AnchorStyles.Left;
            this.label1IDDOKUMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDDOKUMENT.Appearance.ForeColor = Color.Black;
            this.label1IDDOKUMENT.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1IDDOKUMENT, 0, 4);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1IDDOKUMENT, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1IDDOKUMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x7a, 0x17);
            this.label1IDDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDDOKUMENT.Location = point;
            this.comboIDDOKUMENT.Name = "comboIDDOKUMENT";
            this.comboIDDOKUMENT.Tag = "IDDOKUMENT";
            this.comboIDDOKUMENT.TabIndex = 0;
            this.comboIDDOKUMENT.Anchor = AnchorStyles.Left;
            this.comboIDDOKUMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDDOKUMENT.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDDOKUMENT.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDDOKUMENT.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDDOKUMENT.Enabled = true;
            this.comboIDDOKUMENT.DataBindings.Add(new Binding("Value", this.bindingSourceGKSTAVKA, "IDDOKUMENT"));
            this.comboIDDOKUMENT.ShowPictureBox = true;
            this.comboIDDOKUMENT.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDDOKUMENT);
            this.comboIDDOKUMENT.ValueMember = "IDDOKUMENT";
            this.comboIDDOKUMENT.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDDOKUMENT);
            this.layoutManagerformGKSTAVKA.Controls.Add(this.comboIDDOKUMENT, 1, 4);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.comboIDDOKUMENT, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.comboIDDOKUMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDMJESTOTROSKA.Location = point;
            this.label1IDMJESTOTROSKA.Name = "label1IDMJESTOTROSKA";
            this.label1IDMJESTOTROSKA.TabIndex = 1;
            this.label1IDMJESTOTROSKA.Tag = "labelIDMJESTOTROSKA";
            this.label1IDMJESTOTROSKA.Text = "Šifra MT:";
            this.label1IDMJESTOTROSKA.StyleSetName = "FieldUltraLabel";
            this.label1IDMJESTOTROSKA.AutoSize = true;
            this.label1IDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.label1IDMJESTOTROSKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDMJESTOTROSKA.Appearance.ForeColor = Color.Black;
            this.label1IDMJESTOTROSKA.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1IDMJESTOTROSKA, 0, 5);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1IDMJESTOTROSKA, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1IDMJESTOTROSKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(70, 0x17);
            this.label1IDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDMJESTOTROSKA.Location = point;
            this.comboIDMJESTOTROSKA.Name = "comboIDMJESTOTROSKA";
            this.comboIDMJESTOTROSKA.Tag = "IDMJESTOTROSKA";
            this.comboIDMJESTOTROSKA.TabIndex = 0;
            this.comboIDMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.comboIDMJESTOTROSKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDMJESTOTROSKA.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDMJESTOTROSKA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDMJESTOTROSKA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDMJESTOTROSKA.Enabled = true;
            this.comboIDMJESTOTROSKA.DataBindings.Add(new Binding("Value", this.bindingSourceGKSTAVKA, "IDMJESTOTROSKA"));
            this.comboIDMJESTOTROSKA.ShowPictureBox = true;
            this.comboIDMJESTOTROSKA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDMJESTOTROSKA);
            this.comboIDMJESTOTROSKA.ValueMember = "IDMJESTOTROSKA";
            this.comboIDMJESTOTROSKA.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDMJESTOTROSKA);
            this.layoutManagerformGKSTAVKA.Controls.Add(this.comboIDMJESTOTROSKA, 1, 5);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.comboIDMJESTOTROSKA, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.comboIDMJESTOTROSKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVMJESTOTROSKA.Location = point;
            this.label1NAZIVMJESTOTROSKA.Name = "label1NAZIVMJESTOTROSKA";
            this.label1NAZIVMJESTOTROSKA.TabIndex = 1;
            this.label1NAZIVMJESTOTROSKA.Tag = "labelNAZIVMJESTOTROSKA";
            this.label1NAZIVMJESTOTROSKA.Text = "Naziv MT:";
            this.label1NAZIVMJESTOTROSKA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVMJESTOTROSKA.AutoSize = true;
            this.label1NAZIVMJESTOTROSKA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1NAZIVMJESTOTROSKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVMJESTOTROSKA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVMJESTOTROSKA.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1NAZIVMJESTOTROSKA, 0, 6);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1NAZIVMJESTOTROSKA, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1NAZIVMJESTOTROSKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x4c, 0x17);
            this.label1NAZIVMJESTOTROSKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVMJESTOTROSKA.Location = point;
            this.labelNAZIVMJESTOTROSKA.Name = "labelNAZIVMJESTOTROSKA";
            this.labelNAZIVMJESTOTROSKA.Tag = "NAZIVMJESTOTROSKA";
            this.labelNAZIVMJESTOTROSKA.TabIndex = 0;
            this.labelNAZIVMJESTOTROSKA.Anchor = AnchorStyles.Left;
            this.labelNAZIVMJESTOTROSKA.BackColor = Color.Transparent;
            this.labelNAZIVMJESTOTROSKA.DataBindings.Add(new Binding("Text", this.bindingSourceGKSTAVKA, "NAZIVMJESTOTROSKA"));
            this.labelNAZIVMJESTOTROSKA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.labelNAZIVMJESTOTROSKA, 1, 6);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.labelNAZIVMJESTOTROSKA, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.labelNAZIVMJESTOTROSKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVMJESTOTROSKA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.labelNAZIVMJESTOTROSKA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.labelNAZIVMJESTOTROSKA.Size = size;
            this.labelNAZIVMJESTOTROSKA.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.label1IDORGJED.Location = point;
            this.label1IDORGJED.Name = "label1IDORGJED";
            this.label1IDORGJED.TabIndex = 1;
            this.label1IDORGJED.Tag = "labelIDORGJED";
            this.label1IDORGJED.Text = "Šifra OJ:";
            this.label1IDORGJED.StyleSetName = "FieldUltraLabel";
            this.label1IDORGJED.AutoSize = true;
            this.label1IDORGJED.Anchor = AnchorStyles.Left;
            this.label1IDORGJED.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDORGJED.Appearance.ForeColor = Color.Black;
            this.label1IDORGJED.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1IDORGJED, 0, 7);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1IDORGJED, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1IDORGJED, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDORGJED.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x43, 0x17);
            this.label1IDORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDORGJED.Location = point;
            this.comboIDORGJED.Name = "comboIDORGJED";
            this.comboIDORGJED.Tag = "IDORGJED";
            this.comboIDORGJED.TabIndex = 0;
            this.comboIDORGJED.Anchor = AnchorStyles.Left;
            this.comboIDORGJED.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDORGJED.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDORGJED.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDORGJED.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDORGJED.Enabled = true;
            this.comboIDORGJED.DataBindings.Add(new Binding("Value", this.bindingSourceGKSTAVKA, "IDORGJED"));
            this.comboIDORGJED.ShowPictureBox = true;
            this.comboIDORGJED.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDORGJED);
            this.comboIDORGJED.ValueMember = "IDORGJED";
            this.comboIDORGJED.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDORGJED);
            this.layoutManagerformGKSTAVKA.Controls.Add(this.comboIDORGJED, 1, 7);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.comboIDORGJED, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.comboIDORGJED, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDORGJED.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVORGJED.Location = point;
            this.label1NAZIVORGJED.Name = "label1NAZIVORGJED";
            this.label1NAZIVORGJED.TabIndex = 1;
            this.label1NAZIVORGJED.Tag = "labelNAZIVORGJED";
            this.label1NAZIVORGJED.Text = "Naziv OJ:";
            this.label1NAZIVORGJED.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVORGJED.AutoSize = true;
            this.label1NAZIVORGJED.Anchor = AnchorStyles.Left;
            this.label1NAZIVORGJED.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVORGJED.Appearance.ForeColor = Color.Black;
            this.label1NAZIVORGJED.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1NAZIVORGJED, 0, 8);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1NAZIVORGJED, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1NAZIVORGJED, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVORGJED.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x49, 0x17);
            this.label1NAZIVORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVORGJED.Location = point;
            this.labelNAZIVORGJED.Name = "labelNAZIVORGJED";
            this.labelNAZIVORGJED.Tag = "NAZIVORGJED";
            this.labelNAZIVORGJED.TabIndex = 0;
            this.labelNAZIVORGJED.Anchor = AnchorStyles.Left;
            this.labelNAZIVORGJED.BackColor = Color.Transparent;
            this.labelNAZIVORGJED.DataBindings.Add(new Binding("Text", this.bindingSourceGKSTAVKA, "NAZIVORGJED"));
            this.labelNAZIVORGJED.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.labelNAZIVORGJED, 1, 8);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.labelNAZIVORGJED, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.labelNAZIVORGJED, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVORGJED.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVORGJED.Size = size;
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
            this.label1IDKONTO.Appearance.ForeColor = Color.Black;
            this.label1IDKONTO.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1IDKONTO, 0, 9);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1IDKONTO, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1IDKONTO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDKONTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x38, 0x17);
            this.label1IDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDKONTO.Location = point;
            this.comboIDKONTO.Name = "comboIDKONTO";
            this.comboIDKONTO.Tag = "IDKONTO";
            this.comboIDKONTO.TabIndex = 0;
            this.comboIDKONTO.Anchor = AnchorStyles.Left;
            this.comboIDKONTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDKONTO.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDKONTO.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDKONTO.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDKONTO.Enabled = true;
            this.comboIDKONTO.DataBindings.Add(new Binding("Value", this.bindingSourceGKSTAVKA, "IDKONTO"));
            this.comboIDKONTO.ShowPictureBox = true;
            this.comboIDKONTO.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDKONTO);
            this.comboIDKONTO.ValueMember = "IDKONTO";
            this.comboIDKONTO.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDKONTO);
            this.layoutManagerformGKSTAVKA.Controls.Add(this.comboIDKONTO, 1, 9);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.comboIDKONTO, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.comboIDKONTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDKONTO.Size = size;
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
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1NAZIVKONTO, 0, 10);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1NAZIVKONTO, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1NAZIVKONTO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVKONTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x5c, 0x17);
            this.label1NAZIVKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVKONTO.Location = point;
            this.labelNAZIVKONTO.Name = "labelNAZIVKONTO";
            this.labelNAZIVKONTO.Tag = "NAZIVKONTO";
            this.labelNAZIVKONTO.TabIndex = 0;
            this.labelNAZIVKONTO.Anchor = AnchorStyles.Left;
            this.labelNAZIVKONTO.BackColor = Color.Transparent;
            this.labelNAZIVKONTO.DataBindings.Add(new Binding("Text", this.bindingSourceGKSTAVKA, "NAZIVKONTO"));
            this.labelNAZIVKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.labelNAZIVKONTO, 1, 10);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.labelNAZIVKONTO, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.labelNAZIVKONTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVKONTO.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.labelNAZIVKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.labelNAZIVKONTO.Size = size;
            this.labelNAZIVKONTO.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVAKTIVNOST.Location = point;
            this.label1NAZIVAKTIVNOST.Name = "label1NAZIVAKTIVNOST";
            this.label1NAZIVAKTIVNOST.TabIndex = 1;
            this.label1NAZIVAKTIVNOST.Tag = "labelNAZIVAKTIVNOST";
            this.label1NAZIVAKTIVNOST.Text = "Naziv aktivnosti:";
            this.label1NAZIVAKTIVNOST.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVAKTIVNOST.AutoSize = true;
            this.label1NAZIVAKTIVNOST.Anchor = AnchorStyles.Left;
            this.label1NAZIVAKTIVNOST.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVAKTIVNOST.Appearance.ForeColor = Color.Black;
            this.label1NAZIVAKTIVNOST.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1NAZIVAKTIVNOST, 0, 11);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1NAZIVAKTIVNOST, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1NAZIVAKTIVNOST, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVAKTIVNOST.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVAKTIVNOST.MinimumSize = size;
            size = new System.Drawing.Size(0x77, 0x17);
            this.label1NAZIVAKTIVNOST.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVAKTIVNOST.Location = point;
            this.labelNAZIVAKTIVNOST.Name = "labelNAZIVAKTIVNOST";
            this.labelNAZIVAKTIVNOST.Tag = "NAZIVAKTIVNOST";
            this.labelNAZIVAKTIVNOST.TabIndex = 0;
            this.labelNAZIVAKTIVNOST.Anchor = AnchorStyles.Left;
            this.labelNAZIVAKTIVNOST.BackColor = Color.Transparent;
            this.labelNAZIVAKTIVNOST.DataBindings.Add(new Binding("Text", this.bindingSourceGKSTAVKA, "NAZIVAKTIVNOST"));
            this.labelNAZIVAKTIVNOST.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.labelNAZIVAKTIVNOST, 1, 11);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.labelNAZIVAKTIVNOST, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.labelNAZIVAKTIVNOST, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVAKTIVNOST.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVAKTIVNOST.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVAKTIVNOST.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPIS.Location = point;
            this.label1OPIS.Name = "label1OPIS";
            this.label1OPIS.TabIndex = 1;
            this.label1OPIS.Tag = "labelOPIS";
            this.label1OPIS.Text = "OPIS:";
            this.label1OPIS.StyleSetName = "FieldUltraLabel";
            this.label1OPIS.AutoSize = true;
            this.label1OPIS.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1OPIS.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPIS.Appearance.ForeColor = Color.Black;
            this.label1OPIS.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1OPIS, 0, 12);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1OPIS, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1OPIS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPIS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPIS.MinimumSize = size;
            size = new System.Drawing.Size(50, 0x17);
            this.label1OPIS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPIS.Location = point;
            this.textOPIS.Name = "textOPIS";
            this.textOPIS.Tag = "OPIS";
            this.textOPIS.TabIndex = 0;
            this.textOPIS.Anchor = AnchorStyles.Left;
            this.textOPIS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPIS.ContextMenu = this.contextMenu1;
            this.textOPIS.ReadOnly = false;
            this.textOPIS.DataBindings.Add(new Binding("Text", this.bindingSourceGKSTAVKA, "OPIS"));
            this.textOPIS.Nullable = true;
            this.textOPIS.Multiline = true;
            this.textOPIS.MaxLength = 150;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.textOPIS, 1, 12);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.textOPIS, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.textOPIS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPIS.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.textOPIS.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.textOPIS.Size = size;
            this.textOPIS.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.label1duguje.Location = point;
            this.label1duguje.Name = "label1duguje";
            this.label1duguje.TabIndex = 1;
            this.label1duguje.Tag = "labelduguje";
            this.label1duguje.Text = "duguje:";
            this.label1duguje.StyleSetName = "FieldUltraLabel";
            this.label1duguje.AutoSize = true;
            this.label1duguje.Anchor = AnchorStyles.Left;
            this.label1duguje.Appearance.TextVAlign = VAlign.Middle;
            this.label1duguje.Appearance.ForeColor = Color.Black;
            this.label1duguje.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1duguje, 0, 13);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1duguje, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1duguje, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1duguje.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1duguje.MinimumSize = size;
            size = new System.Drawing.Size(0x3e, 0x17);
            this.label1duguje.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textduguje.Location = point;
            this.textduguje.Name = "textduguje";
            this.textduguje.Tag = "duguje";
            this.textduguje.TabIndex = 0;
            this.textduguje.Anchor = AnchorStyles.Left;
            this.textduguje.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textduguje.ContextMenu = this.contextMenu1;
            this.textduguje.ReadOnly = false;
            this.textduguje.PromptChar = ' ';
            this.textduguje.Enter += new EventHandler(this.numericEditor_Enter);
            this.textduguje.DataBindings.Add(new Binding("Value", this.bindingSourceGKSTAVKA, "duguje"));
            this.textduguje.NumericType = NumericType.Double;
            this.textduguje.MaxValue = 79228162514264337593543950335M;
            this.textduguje.MinValue = -79228162514264337593543950335M;
            this.textduguje.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textduguje.Nullable = true;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.textduguje, 1, 13);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.textduguje, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.textduguje, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textduguje.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textduguje.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textduguje.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POTRAZUJE.Location = point;
            this.label1POTRAZUJE.Name = "label1POTRAZUJE";
            this.label1POTRAZUJE.TabIndex = 1;
            this.label1POTRAZUJE.Tag = "labelPOTRAZUJE";
            this.label1POTRAZUJE.Text = "Potražuje:";
            this.label1POTRAZUJE.StyleSetName = "FieldUltraLabel";
            this.label1POTRAZUJE.AutoSize = true;
            this.label1POTRAZUJE.Anchor = AnchorStyles.Left;
            this.label1POTRAZUJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1POTRAZUJE.Appearance.ForeColor = Color.Black;
            this.label1POTRAZUJE.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1POTRAZUJE, 0, 14);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1POTRAZUJE, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1POTRAZUJE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POTRAZUJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POTRAZUJE.MinimumSize = size;
            size = new System.Drawing.Size(0x4f, 0x17);
            this.label1POTRAZUJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOTRAZUJE.Location = point;
            this.textPOTRAZUJE.Name = "textPOTRAZUJE";
            this.textPOTRAZUJE.Tag = "POTRAZUJE";
            this.textPOTRAZUJE.TabIndex = 0;
            this.textPOTRAZUJE.Anchor = AnchorStyles.Left;
            this.textPOTRAZUJE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOTRAZUJE.ContextMenu = this.contextMenu1;
            this.textPOTRAZUJE.ReadOnly = false;
            this.textPOTRAZUJE.PromptChar = ' ';
            this.textPOTRAZUJE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPOTRAZUJE.DataBindings.Add(new Binding("Value", this.bindingSourceGKSTAVKA, "POTRAZUJE"));
            this.textPOTRAZUJE.NumericType = NumericType.Double;
            this.textPOTRAZUJE.MaxValue = 79228162514264337593543950335M;
            this.textPOTRAZUJE.MinValue = -79228162514264337593543950335M;
            this.textPOTRAZUJE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPOTRAZUJE.Nullable = true;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.textPOTRAZUJE, 1, 14);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.textPOTRAZUJE, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.textPOTRAZUJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOTRAZUJE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textPOTRAZUJE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textPOTRAZUJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DATUMPRIJAVE.Location = point;
            this.label1DATUMPRIJAVE.Name = "label1DATUMPRIJAVE";
            this.label1DATUMPRIJAVE.TabIndex = 1;
            this.label1DATUMPRIJAVE.Tag = "labelDATUMPRIJAVE";
            this.label1DATUMPRIJAVE.Text = "DATUMPRIJAVE:";
            this.label1DATUMPRIJAVE.StyleSetName = "FieldUltraLabel";
            this.label1DATUMPRIJAVE.AutoSize = true;
            this.label1DATUMPRIJAVE.Anchor = AnchorStyles.Left;
            this.label1DATUMPRIJAVE.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMPRIJAVE.Appearance.ForeColor = Color.Black;
            this.label1DATUMPRIJAVE.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1DATUMPRIJAVE, 0, 15);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1DATUMPRIJAVE, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1DATUMPRIJAVE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUMPRIJAVE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUMPRIJAVE.MinimumSize = size;
            size = new System.Drawing.Size(0x76, 0x17);
            this.label1DATUMPRIJAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUMPRIJAVE.Location = point;
            this.datePickerDATUMPRIJAVE.Name = "datePickerDATUMPRIJAVE";
            this.datePickerDATUMPRIJAVE.Tag = "DATUMPRIJAVE";
            this.datePickerDATUMPRIJAVE.TabIndex = 0;
            this.datePickerDATUMPRIJAVE.Anchor = AnchorStyles.Left;
            this.datePickerDATUMPRIJAVE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMPRIJAVE.ContextMenu = this.contextMenu1;
            this.datePickerDATUMPRIJAVE.Enabled = true;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.datePickerDATUMPRIJAVE, 1, 15);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.datePickerDATUMPRIJAVE, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.datePickerDATUMPRIJAVE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUMPRIJAVE.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMPRIJAVE.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMPRIJAVE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDPARTNER.Location = point;
            this.label1IDPARTNER.Name = "label1IDPARTNER";
            this.label1IDPARTNER.TabIndex = 1;
            this.label1IDPARTNER.Tag = "labelIDPARTNER";
            this.label1IDPARTNER.Text = "Šifra partnera:";
            this.label1IDPARTNER.StyleSetName = "FieldUltraLabel";
            this.label1IDPARTNER.AutoSize = true;
            this.label1IDPARTNER.Anchor = AnchorStyles.Left;
            this.label1IDPARTNER.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDPARTNER.Appearance.ForeColor = Color.Black;
            this.label1IDPARTNER.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1IDPARTNER, 0, 0x10);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1IDPARTNER, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1IDPARTNER, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDPARTNER.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDPARTNER.MinimumSize = size;
            size = new System.Drawing.Size(0x69, 0x17);
            this.label1IDPARTNER.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDPARTNER.Location = point;
            this.comboIDPARTNER.Name = "comboIDPARTNER";
            this.comboIDPARTNER.Tag = "IDPARTNER";
            this.comboIDPARTNER.TabIndex = 0;
            this.comboIDPARTNER.Anchor = AnchorStyles.Left;
            this.comboIDPARTNER.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDPARTNER.ContextMenu = this.contextMenu1;
            this.comboIDPARTNER.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDPARTNER.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDPARTNER.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDPARTNER.Enabled = true;
            this.comboIDPARTNER.DataBindings.Add(new Binding("Value", this.bindingSourceGKSTAVKA, "IDPARTNER"));
            this.comboIDPARTNER.ShowPictureBox = true;
            this.comboIDPARTNER.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDPARTNER);
            this.comboIDPARTNER.ValueMember = "IDPARTNER";
            this.comboIDPARTNER.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDPARTNER);
            this.layoutManagerformGKSTAVKA.Controls.Add(this.comboIDPARTNER, 1, 0x10);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.comboIDPARTNER, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.comboIDPARTNER, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDPARTNER.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDPARTNER.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDPARTNER.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVPARTNER.Location = point;
            this.label1NAZIVPARTNER.Name = "label1NAZIVPARTNER";
            this.label1NAZIVPARTNER.TabIndex = 1;
            this.label1NAZIVPARTNER.Tag = "labelNAZIVPARTNER";
            this.label1NAZIVPARTNER.Text = "Naziv partnera:";
            this.label1NAZIVPARTNER.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVPARTNER.AutoSize = true;
            this.label1NAZIVPARTNER.Anchor = AnchorStyles.Left;
            this.label1NAZIVPARTNER.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVPARTNER.Appearance.ForeColor = Color.Black;
            this.label1NAZIVPARTNER.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1NAZIVPARTNER, 0, 0x11);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1NAZIVPARTNER, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1NAZIVPARTNER, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVPARTNER.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVPARTNER.MinimumSize = size;
            size = new System.Drawing.Size(0x6f, 0x17);
            this.label1NAZIVPARTNER.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVPARTNER.Location = point;
            this.labelNAZIVPARTNER.Name = "labelNAZIVPARTNER";
            this.labelNAZIVPARTNER.Tag = "NAZIVPARTNER";
            this.labelNAZIVPARTNER.TabIndex = 0;
            this.labelNAZIVPARTNER.Anchor = AnchorStyles.Left;
            this.labelNAZIVPARTNER.BackColor = Color.Transparent;
            this.labelNAZIVPARTNER.DataBindings.Add(new Binding("Text", this.bindingSourceGKSTAVKA, "NAZIVPARTNER"));
            this.labelNAZIVPARTNER.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.labelNAZIVPARTNER, 1, 0x11);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.labelNAZIVPARTNER, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.labelNAZIVPARTNER, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVPARTNER.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVPARTNER.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVPARTNER.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ZATVORENIIZNOS.Location = point;
            this.label1ZATVORENIIZNOS.Name = "label1ZATVORENIIZNOS";
            this.label1ZATVORENIIZNOS.TabIndex = 1;
            this.label1ZATVORENIIZNOS.Tag = "labelZATVORENIIZNOS";
            this.label1ZATVORENIIZNOS.Text = "Zatvoreni iznos:";
            this.label1ZATVORENIIZNOS.StyleSetName = "FieldUltraLabel";
            this.label1ZATVORENIIZNOS.AutoSize = true;
            this.label1ZATVORENIIZNOS.Anchor = AnchorStyles.Left;
            this.label1ZATVORENIIZNOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZATVORENIIZNOS.Appearance.ForeColor = Color.Black;
            this.label1ZATVORENIIZNOS.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1ZATVORENIIZNOS, 0, 0x12);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1ZATVORENIIZNOS, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1ZATVORENIIZNOS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ZATVORENIIZNOS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZATVORENIIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x72, 0x17);
            this.label1ZATVORENIIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textZATVORENIIZNOS.Location = point;
            this.textZATVORENIIZNOS.Name = "textZATVORENIIZNOS";
            this.textZATVORENIIZNOS.Tag = "ZATVORENIIZNOS";
            this.textZATVORENIIZNOS.TabIndex = 0;
            this.textZATVORENIIZNOS.Anchor = AnchorStyles.Left;
            this.textZATVORENIIZNOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textZATVORENIIZNOS.ContextMenu = this.contextMenu1;
            this.textZATVORENIIZNOS.ReadOnly = false;
            this.textZATVORENIIZNOS.PromptChar = ' ';
            this.textZATVORENIIZNOS.Enter += new EventHandler(this.numericEditor_Enter);
            this.textZATVORENIIZNOS.DataBindings.Add(new Binding("Value", this.bindingSourceGKSTAVKA, "ZATVORENIIZNOS"));
            this.textZATVORENIIZNOS.NumericType = NumericType.Double;
            this.textZATVORENIIZNOS.MaxValue = 79228162514264337593543950335M;
            this.textZATVORENIIZNOS.MinValue = -79228162514264337593543950335M;
            this.textZATVORENIIZNOS.MaskInput = "{LOC}-nnnnnn.nn";
            this.textZATVORENIIZNOS.Nullable = true;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.textZATVORENIIZNOS, 1, 0x12);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.textZATVORENIIZNOS, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.textZATVORENIIZNOS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textZATVORENIIZNOS.Margin = padding;
            size = new System.Drawing.Size(0x4b, 0x16);
            this.textZATVORENIIZNOS.MinimumSize = size;
            size = new System.Drawing.Size(0x4b, 0x16);
            this.textZATVORENIIZNOS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1GKDATUMVALUTE.Location = point;
            this.label1GKDATUMVALUTE.Name = "label1GKDATUMVALUTE";
            this.label1GKDATUMVALUTE.TabIndex = 1;
            this.label1GKDATUMVALUTE.Tag = "labelGKDATUMVALUTE";
            this.label1GKDATUMVALUTE.Text = "Valuta:";
            this.label1GKDATUMVALUTE.StyleSetName = "FieldUltraLabel";
            this.label1GKDATUMVALUTE.AutoSize = true;
            this.label1GKDATUMVALUTE.Anchor = AnchorStyles.Left;
            this.label1GKDATUMVALUTE.Appearance.TextVAlign = VAlign.Middle;
            this.label1GKDATUMVALUTE.Appearance.ForeColor = Color.Black;
            this.label1GKDATUMVALUTE.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1GKDATUMVALUTE, 0, 0x13);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1GKDATUMVALUTE, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1GKDATUMVALUTE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1GKDATUMVALUTE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1GKDATUMVALUTE.MinimumSize = size;
            size = new System.Drawing.Size(0x3b, 0x17);
            this.label1GKDATUMVALUTE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerGKDATUMVALUTE.Location = point;
            this.datePickerGKDATUMVALUTE.Name = "datePickerGKDATUMVALUTE";
            this.datePickerGKDATUMVALUTE.Tag = "GKDATUMVALUTE";
            this.datePickerGKDATUMVALUTE.TabIndex = 0;
            this.datePickerGKDATUMVALUTE.Anchor = AnchorStyles.Left;
            this.datePickerGKDATUMVALUTE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerGKDATUMVALUTE.ContextMenu = this.contextMenu1;
            this.datePickerGKDATUMVALUTE.Enabled = true;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.datePickerGKDATUMVALUTE, 1, 0x13);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.datePickerGKDATUMVALUTE, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.datePickerGKDATUMVALUTE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerGKDATUMVALUTE.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerGKDATUMVALUTE.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerGKDATUMVALUTE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1statusgk.Location = point;
            this.label1statusgk.Name = "label1statusgk";
            this.label1statusgk.TabIndex = 1;
            this.label1statusgk.Tag = "labelstatusgk";
            this.label1statusgk.Text = "statusgk:";
            this.label1statusgk.StyleSetName = "FieldUltraLabel";
            this.label1statusgk.AutoSize = true;
            this.label1statusgk.Anchor = AnchorStyles.Left;
            this.label1statusgk.Appearance.TextVAlign = VAlign.Middle;
            this.label1statusgk.Appearance.ForeColor = Color.Black;
            this.label1statusgk.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1statusgk, 0, 20);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1statusgk, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1statusgk, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1statusgk.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1statusgk.MinimumSize = size;
            size = new System.Drawing.Size(0x49, 0x17);
            this.label1statusgk.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkstatusgk.Location = point;
            this.checkstatusgk.Name = "checkstatusgk";
            this.checkstatusgk.Tag = "statusgk";
            this.checkstatusgk.TabIndex = 0;
            this.checkstatusgk.Anchor = AnchorStyles.Left;
            this.checkstatusgk.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkstatusgk.Enabled = true;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.checkstatusgk, 1, 20);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.checkstatusgk, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.checkstatusgk, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkstatusgk.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkstatusgk.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkstatusgk.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ORIGINALNIDOKUMENT.Location = point;
            this.label1ORIGINALNIDOKUMENT.Name = "label1ORIGINALNIDOKUMENT";
            this.label1ORIGINALNIDOKUMENT.TabIndex = 1;
            this.label1ORIGINALNIDOKUMENT.Tag = "labelORIGINALNIDOKUMENT";
            this.label1ORIGINALNIDOKUMENT.Text = "Originalni dokument:";
            this.label1ORIGINALNIDOKUMENT.StyleSetName = "FieldUltraLabel";
            this.label1ORIGINALNIDOKUMENT.AutoSize = true;
            this.label1ORIGINALNIDOKUMENT.Anchor = AnchorStyles.Left;
            this.label1ORIGINALNIDOKUMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1ORIGINALNIDOKUMENT.Appearance.ForeColor = Color.Black;
            this.label1ORIGINALNIDOKUMENT.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1ORIGINALNIDOKUMENT, 0, 0x15);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1ORIGINALNIDOKUMENT, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1ORIGINALNIDOKUMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ORIGINALNIDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ORIGINALNIDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x92, 0x17);
            this.label1ORIGINALNIDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textORIGINALNIDOKUMENT.Location = point;
            this.textORIGINALNIDOKUMENT.Name = "textORIGINALNIDOKUMENT";
            this.textORIGINALNIDOKUMENT.Tag = "ORIGINALNIDOKUMENT";
            this.textORIGINALNIDOKUMENT.TabIndex = 0;
            this.textORIGINALNIDOKUMENT.Anchor = AnchorStyles.Left;
            this.textORIGINALNIDOKUMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textORIGINALNIDOKUMENT.ContextMenu = this.contextMenu1;
            this.textORIGINALNIDOKUMENT.ReadOnly = false;
            this.textORIGINALNIDOKUMENT.DataBindings.Add(new Binding("Text", this.bindingSourceGKSTAVKA, "ORIGINALNIDOKUMENT"));
            this.textORIGINALNIDOKUMENT.Nullable = true;
            this.textORIGINALNIDOKUMENT.MaxLength = 50;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.textORIGINALNIDOKUMENT, 1, 0x15);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.textORIGINALNIDOKUMENT, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.textORIGINALNIDOKUMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textORIGINALNIDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textORIGINALNIDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textORIGINALNIDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1GKGODIDGODINE.Location = point;
            this.label1GKGODIDGODINE.Name = "label1GKGODIDGODINE";
            this.label1GKGODIDGODINE.TabIndex = 1;
            this.label1GKGODIDGODINE.Tag = "labelGKGODIDGODINE";
            this.label1GKGODIDGODINE.Text = "Godina:";
            this.label1GKGODIDGODINE.StyleSetName = "FieldUltraLabel";
            this.label1GKGODIDGODINE.AutoSize = true;
            this.label1GKGODIDGODINE.Anchor = AnchorStyles.Left;
            this.label1GKGODIDGODINE.Appearance.TextVAlign = VAlign.Middle;
            this.label1GKGODIDGODINE.Appearance.ForeColor = Color.Black;
            this.label1GKGODIDGODINE.BackColor = Color.Transparent;
            this.layoutManagerformGKSTAVKA.Controls.Add(this.label1GKGODIDGODINE, 0, 0x16);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.label1GKGODIDGODINE, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.label1GKGODIDGODINE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1GKGODIDGODINE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1GKGODIDGODINE.MinimumSize = size;
            size = new System.Drawing.Size(0x3f, 0x17);
            this.label1GKGODIDGODINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textGKGODIDGODINE.Location = point;
            this.textGKGODIDGODINE.Name = "textGKGODIDGODINE";
            this.textGKGODIDGODINE.Tag = "GKGODIDGODINE";
            this.textGKGODIDGODINE.TabIndex = 0;
            this.textGKGODIDGODINE.Anchor = AnchorStyles.Left;
            this.textGKGODIDGODINE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textGKGODIDGODINE.ReadOnly = false;
            this.textGKGODIDGODINE.PromptChar = ' ';
            this.textGKGODIDGODINE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textGKGODIDGODINE.DataBindings.Add(new Binding("Value", this.bindingSourceGKSTAVKA, "GKGODIDGODINE"));
            this.textGKGODIDGODINE.NumericType = NumericType.Integer;
            this.textGKGODIDGODINE.MaskInput = "{LOC}-nnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonGODINEGKGODIDGODINE",
                Tag = "editorButtonGODINEGKGODIDGODINE",
                Text = "..."
            };
            this.textGKGODIDGODINE.ButtonsRight.Add(button);
            this.textGKGODIDGODINE.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptGODINEGKGODIDGODINE);
            this.layoutManagerformGKSTAVKA.Controls.Add(this.textGKGODIDGODINE, 1, 0x16);
            this.layoutManagerformGKSTAVKA.SetColumnSpan(this.textGKGODIDGODINE, 1);
            this.layoutManagerformGKSTAVKA.SetRowSpan(this.textGKGODIDGODINE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textGKGODIDGODINE.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textGKGODIDGODINE.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textGKGODIDGODINE.Size = size;
            this.Controls.Add(this.layoutManagerformGKSTAVKA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceGKSTAVKA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "GKSTAVKAFormUserControl";
            this.Text = "GKSTAVKA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.GKSTAVKAFormUserControl_Load);
            this.layoutManagerformGKSTAVKA.ResumeLayout(false);
            this.layoutManagerformGKSTAVKA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceGKSTAVKA).EndInit();
            ((ISupportInitialize) this.textBROJDOKUMENTA).EndInit();
            ((ISupportInitialize) this.textBROJSTAVKE).EndInit();
            ((ISupportInitialize) this.textOPIS).EndInit();
            ((ISupportInitialize) this.textduguje).EndInit();
            ((ISupportInitialize) this.textPOTRAZUJE).EndInit();
            ((ISupportInitialize) this.textZATVORENIIZNOS).EndInit();
            ((ISupportInitialize) this.textORIGINALNIDOKUMENT).EndInit();
            ((ISupportInitialize) this.textGKGODIDGODINE).EndInit();
            this.dsGKSTAVKADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.GKSTAVKAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceGKSTAVKA, this.GKSTAVKAController.WorkItem, this))
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
            this.label1IDAKTIVNOST.Text = StringResources.GKSTAVKAIDAKTIVNOSTDescription;
            this.label1DATUMDOKUMENTA.Text = StringResources.GKSTAVKADATUMDOKUMENTADescription;
            this.label1BROJDOKUMENTA.Text = StringResources.GKSTAVKABROJDOKUMENTADescription;
            this.label1BROJSTAVKE.Text = StringResources.GKSTAVKABROJSTAVKEDescription;
            this.label1IDDOKUMENT.Text = StringResources.GKSTAVKAIDDOKUMENTDescription;
            this.label1IDMJESTOTROSKA.Text = StringResources.GKSTAVKAIDMJESTOTROSKADescription;
            this.label1NAZIVMJESTOTROSKA.Text = StringResources.GKSTAVKANAZIVMJESTOTROSKADescription;
            this.label1IDORGJED.Text = StringResources.GKSTAVKAIDORGJEDDescription;
            this.label1NAZIVORGJED.Text = StringResources.GKSTAVKANAZIVORGJEDDescription;
            this.label1IDKONTO.Text = StringResources.GKSTAVKAIDKONTODescription;
            this.label1NAZIVKONTO.Text = StringResources.GKSTAVKANAZIVKONTODescription;
            this.label1NAZIVAKTIVNOST.Text = StringResources.GKSTAVKANAZIVAKTIVNOSTDescription;
            this.label1OPIS.Text = StringResources.GKSTAVKAOPISDescription;
            this.label1duguje.Text = StringResources.GKSTAVKAdugujeDescription;
            this.label1POTRAZUJE.Text = StringResources.GKSTAVKAPOTRAZUJEDescription;
            this.label1DATUMPRIJAVE.Text = StringResources.GKSTAVKADATUMPRIJAVEDescription;
            this.label1IDPARTNER.Text = StringResources.GKSTAVKAIDPARTNERDescription;
            this.label1NAZIVPARTNER.Text = StringResources.GKSTAVKANAZIVPARTNERDescription;
            this.label1ZATVORENIIZNOS.Text = StringResources.GKSTAVKAZATVORENIIZNOSDescription;
            this.label1GKDATUMVALUTE.Text = StringResources.GKSTAVKAGKDATUMVALUTEDescription;
            this.label1statusgk.Text = StringResources.GKSTAVKAstatusgkDescription;
            this.label1ORIGINALNIDOKUMENT.Text = StringResources.GKSTAVKAORIGINALNIDOKUMENTDescription;
            this.label1GKGODIDGODINE.Text = StringResources.GKSTAVKAGKGODIDGODINEDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewZATVARANJA1")]
        public void NewZATVARANJA1Handler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GKSTAVKAController.NewZATVARANJA1(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewZATVARANJA")]
        public void NewZATVARANJAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GKSTAVKAController.NewZATVARANJA(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDDOKUMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("DOKUMENT", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIDMJESTOTROSKA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("MJESTOTROSKA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIDORGJED(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ORGJED", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIDPARTNER(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("PARTNER", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.GKSTAVKAController.WorkItem.Items.Contains("GKSTAVKA|GKSTAVKA"))
            {
                this.GKSTAVKAController.WorkItem.Items.Add(this.bindingSourceGKSTAVKA, "GKSTAVKA|GKSTAVKA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsGKSTAVKADataSet1.GKSTAVKA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.GKSTAVKAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.GKSTAVKAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.GKSTAVKAController.Update(this))
            {
                this.GKSTAVKAController.DataSet = new GKSTAVKADataSet();
                DataSetUtil.AddEmptyRow(this.GKSTAVKAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.GKSTAVKAController.DataSet.GKSTAVKA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedIDDOKUMENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDDOKUMENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDDOKUMENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceGKSTAVKA.Current).Row["IDDOKUMENT"] = RuntimeHelpers.GetObjectValue(row["IDDOKUMENT"]);
                    ((DataRowView) this.bindingSourceGKSTAVKA.Current).Row["NAZIVDOKUMENT"] = RuntimeHelpers.GetObjectValue(row["NAZIVDOKUMENT"]);
                    this.bindingSourceGKSTAVKA.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedIDKONTO(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDKONTO.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDKONTO.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceGKSTAVKA.Current).Row["IDKONTO"] = RuntimeHelpers.GetObjectValue(row["IDKONTO"]);
                    ((DataRowView) this.bindingSourceGKSTAVKA.Current).Row["NAZIVKONTO"] = RuntimeHelpers.GetObjectValue(row["NAZIVKONTO"]);
                    ((DataRowView) this.bindingSourceGKSTAVKA.Current).Row["IDAKTIVNOST"] = RuntimeHelpers.GetObjectValue(row["IDAKTIVNOST"]);
                    ((DataRowView) this.bindingSourceGKSTAVKA.Current).Row["NAZIVAKTIVNOST"] = RuntimeHelpers.GetObjectValue(row["NAZIVAKTIVNOST"]);
                    this.bindingSourceGKSTAVKA.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedIDMJESTOTROSKA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDMJESTOTROSKA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDMJESTOTROSKA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceGKSTAVKA.Current).Row["IDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["IDMJESTOTROSKA"]);
                    ((DataRowView) this.bindingSourceGKSTAVKA.Current).Row["NAZIVMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(row["NAZIVMJESTOTROSKA"]);
                    this.bindingSourceGKSTAVKA.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedIDORGJED(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDORGJED.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDORGJED.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceGKSTAVKA.Current).Row["IDORGJED"] = RuntimeHelpers.GetObjectValue(row["IDORGJED"]);
                    ((DataRowView) this.bindingSourceGKSTAVKA.Current).Row["NAZIVORGJED"] = RuntimeHelpers.GetObjectValue(row["NAZIVORGJED"]);
                    this.bindingSourceGKSTAVKA.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedIDPARTNER(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDPARTNER.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDPARTNER.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceGKSTAVKA.Current).Row["IDPARTNER"] = RuntimeHelpers.GetObjectValue(row["IDPARTNER"]);
                    ((DataRowView) this.bindingSourceGKSTAVKA.Current).Row["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(row["NAZIVPARTNER"]);
                    this.bindingSourceGKSTAVKA.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.labelIDAKTIVNOST.Focus();
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

        private void UpdateValuesGODINEGKGODIDGODINE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceGKSTAVKA.Current).Row["GKGODIDGODINE"] = RuntimeHelpers.GetObjectValue(result["IDGODINE"]);
                this.bindingSourceGKSTAVKA.ResetCurrentItem();
            }
        }

        [LocalCommandHandler("ViewZATVARANJA1")]
        public void ViewZATVARANJA1Handler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GKSTAVKAController.ViewZATVARANJA1(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewZATVARANJA")]
        public void ViewZATVARANJAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.GKSTAVKAController.ViewZATVARANJA(this.m_CurrentRow);
            }
        }

        protected virtual UltraCheckEditor checkstatusgk
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkstatusgk;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkstatusgk = value;
            }
        }

        protected virtual DOKUMENTComboBox comboIDDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDDOKUMENT = value;
            }
        }

        protected virtual KONTOComboBox comboIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDKONTO = value;
            }
        }

        protected virtual MJESTOTROSKAComboBox comboIDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDMJESTOTROSKA = value;
            }
        }

        protected virtual ORGJEDComboBox comboIDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDORGJED = value;
            }
        }

        protected virtual PARTNERComboBox comboIDPARTNER
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDPARTNER;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDPARTNER = value;
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

        protected virtual UltraDateTimeEditor datePickerDATUMDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUMDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUMDOKUMENTA = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerDATUMPRIJAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUMPRIJAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUMPRIJAVE = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerGKDATUMVALUTE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerGKDATUMVALUTE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerGKDATUMVALUTE = value;
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.GKSTAVKAController GKSTAVKAController { get; set; }

        protected virtual UltraLabel label1BROJDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BROJDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BROJDOKUMENTA = value;
            }
        }

        protected virtual UltraLabel label1BROJSTAVKE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BROJSTAVKE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BROJSTAVKE = value;
            }
        }

        protected virtual UltraLabel label1DATUMDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUMDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUMDOKUMENTA = value;
            }
        }

        protected virtual UltraLabel label1DATUMPRIJAVE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUMPRIJAVE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUMPRIJAVE = value;
            }
        }

        protected virtual UltraLabel label1duguje
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1duguje;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1duguje = value;
            }
        }

        protected virtual UltraLabel label1GKDATUMVALUTE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1GKDATUMVALUTE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1GKDATUMVALUTE = value;
            }
        }

        protected virtual UltraLabel label1GKGODIDGODINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1GKGODIDGODINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1GKGODIDGODINE = value;
            }
        }

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

        protected virtual UltraLabel label1IDDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDDOKUMENT = value;
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

        protected virtual UltraLabel label1IDMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDMJESTOTROSKA = value;
            }
        }

        protected virtual UltraLabel label1IDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDORGJED = value;
            }
        }

        protected virtual UltraLabel label1IDPARTNER
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDPARTNER;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDPARTNER = value;
            }
        }

        protected virtual UltraLabel label1NAZIVAKTIVNOST
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVAKTIVNOST;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVAKTIVNOST = value;
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

        protected virtual UltraLabel label1NAZIVMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVMJESTOTROSKA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVORGJED = value;
            }
        }

        protected virtual UltraLabel label1NAZIVPARTNER
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVPARTNER;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVPARTNER = value;
            }
        }

        protected virtual UltraLabel label1OPIS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPIS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPIS = value;
            }
        }

        protected virtual UltraLabel label1ORIGINALNIDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ORIGINALNIDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ORIGINALNIDOKUMENT = value;
            }
        }

        protected virtual UltraLabel label1POTRAZUJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POTRAZUJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POTRAZUJE = value;
            }
        }

        protected virtual UltraLabel label1statusgk
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1statusgk;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1statusgk = value;
            }
        }

        protected virtual UltraLabel label1ZATVORENIIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZATVORENIIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZATVORENIIZNOS = value;
            }
        }

        protected virtual UltraLabel labelIDAKTIVNOST
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelIDAKTIVNOST;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelIDAKTIVNOST = value;
            }
        }

        protected virtual UltraLabel labelNAZIVAKTIVNOST
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVAKTIVNOST;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVAKTIVNOST = value;
            }
        }

        protected virtual UltraLabel labelNAZIVKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVKONTO = value;
            }
        }

        protected virtual UltraLabel labelNAZIVMJESTOTROSKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVMJESTOTROSKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVMJESTOTROSKA = value;
            }
        }

        protected virtual UltraLabel labelNAZIVORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVORGJED = value;
            }
        }

        protected virtual UltraLabel labelNAZIVPARTNER
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVPARTNER;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVPARTNER = value;
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

        protected virtual UltraNumericEditor textBROJDOKUMENTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBROJDOKUMENTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textBROJDOKUMENTA = value;
            }
        }

        protected virtual UltraNumericEditor textBROJSTAVKE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBROJSTAVKE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textBROJSTAVKE = value;
            }
        }

        protected virtual UltraNumericEditor textduguje
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textduguje;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textduguje = value;
            }
        }

        protected virtual UltraNumericEditor textGKGODIDGODINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textGKGODIDGODINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textGKGODIDGODINE = value;
            }
        }

        protected virtual UltraTextEditor textOPIS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPIS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPIS = value;
            }
        }

        protected virtual UltraTextEditor textORIGINALNIDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textORIGINALNIDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textORIGINALNIDOKUMENT = value;
            }
        }

        protected virtual UltraNumericEditor textPOTRAZUJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOTRAZUJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPOTRAZUJE = value;
            }
        }

        protected virtual UltraNumericEditor textZATVORENIIZNOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textZATVORENIIZNOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textZATVORENIIZNOS = value;
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

