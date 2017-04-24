namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Win;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinDock;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.Controllers;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class UnosKreditaSmartPart : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("_UnosKreditaSmartPartAutoHideControl")]
        private AutoHideControl __UnosKreditaSmartPartAutoHideControl;
        [AccessedThroughProperty("_UnosKreditaSmartPartUnpinnedTabAreaBottom")]
        private UnpinnedTabArea __UnosKreditaSmartPartUnpinnedTabAreaBottom;
        [AccessedThroughProperty("_UnosKreditaSmartPartUnpinnedTabAreaLeft")]
        private UnpinnedTabArea __UnosKreditaSmartPartUnpinnedTabAreaLeft;
        [AccessedThroughProperty("_UnosKreditaSmartPartUnpinnedTabAreaRight")]
        private UnpinnedTabArea __UnosKreditaSmartPartUnpinnedTabAreaRight;
        [AccessedThroughProperty("_UnosKreditaSmartPartUnpinnedTabAreaTop")]
        private UnpinnedTabArea __UnosKreditaSmartPartUnpinnedTabAreaTop;
        [AccessedThroughProperty("bindingSourceOBRACUNKrediti")]
        private BindingSource _bindingSourceOBRACUNKrediti;
        [AccessedThroughProperty("chkAktivni")]
        private UltraCheckEditor _chkAktivni;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("datePickerDatumUgovora")]
        private UltraDateTimeEditor _datePickerDatumUgovora;
        [AccessedThroughProperty("DockableWindow1")]
        private DockableWindow _DockableWindow1;
        [AccessedThroughProperty("DockableWindow2")]
        private DockableWindow _DockableWindow2;
        [AccessedThroughProperty("DockableWindow3")]
        private DockableWindow _DockableWindow3;
        [AccessedThroughProperty("dsOBRACUNDataSet1")]
        private OBRACUNDataSet _dsOBRACUNDataSet1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("GroupBox1")]
        private GroupBox _GroupBox1;
        [AccessedThroughProperty("label1DatumUgovora")]
        private UltraLabel _label1DatumUgovora;
        [AccessedThroughProperty("label1IDKREDITOR")]
        private UltraLabel _label1IDKREDITOR;
        [AccessedThroughProperty("label1NAZIVKREDITOR")]
        private UltraLabel _label1NAZIVKREDITOR;
        [AccessedThroughProperty("label1OBRIZNOSRATEKREDITOR")]
        private UltraLabel _label1OBRIZNOSRATEKREDITOR;
        [AccessedThroughProperty("label1OBRMOKREDITOR")]
        private UltraLabel _label1OBRMOKREDITOR;
        [AccessedThroughProperty("label1OBRMZKREDITOR")]
        private UltraLabel _label1OBRMZKREDITOR;
        [AccessedThroughProperty("label1OBROPISPLACANJAKREDITOR")]
        private UltraLabel _label1OBROPISPLACANJAKREDITOR;
        [AccessedThroughProperty("label1OBRPOKREDITOR")]
        private UltraLabel _label1OBRPOKREDITOR;
        [AccessedThroughProperty("label1OBRPZKREDITOR")]
        private UltraLabel _label1OBRPZKREDITOR;
        [AccessedThroughProperty("label1OBRSIFRAOPISAPLACANJAKREDITOR")]
        private UltraLabel _label1OBRSIFRAOPISAPLACANJAKREDITOR;
        [AccessedThroughProperty("label1PRIMATELJKREDITOR1")]
        private UltraLabel _label1PRIMATELJKREDITOR1;
        [AccessedThroughProperty("label1PRIMATELJKREDITOR2")]
        private UltraLabel _label1PRIMATELJKREDITOR2;
        [AccessedThroughProperty("label1PRIMATELJKREDITOR3")]
        private UltraLabel _label1PRIMATELJKREDITOR3;
        [AccessedThroughProperty("label1VBDIKREDITOR")]
        private UltraLabel _label1VBDIKREDITOR;
        [AccessedThroughProperty("label1ZRNKREDITOR")]
        private UltraLabel _label1ZRNKREDITOR;
        [AccessedThroughProperty("labelNAZIVKREDITOR")]
        private UltraLabel _labelNAZIVKREDITOR;
        [AccessedThroughProperty("labelPRIMATELJKREDITOR1")]
        private UltraLabel _labelPRIMATELJKREDITOR1;
        [AccessedThroughProperty("labelPRIMATELJKREDITOR2")]
        private UltraLabel _labelPRIMATELJKREDITOR2;
        [AccessedThroughProperty("labelPRIMATELJKREDITOR3")]
        private UltraLabel _labelPRIMATELJKREDITOR3;
        [AccessedThroughProperty("labelVBDIKREDITOR")]
        private UltraLabel _labelVBDIKREDITOR;
        [AccessedThroughProperty("labelZRNKREDITOR")]
        private UltraLabel _labelZRNKREDITOR;
        [AccessedThroughProperty("layoutManagerformOBRACUNKrediti")]
        private TableLayoutPanel _layoutManagerformOBRACUNKrediti;
        [AccessedThroughProperty("Panel1")]
        private Panel _Panel1;
        [AccessedThroughProperty("Panel2")]
        private Panel _Panel2;
        [AccessedThroughProperty("PregledRadnikaDataset2")]
        private PregledRadnikaSvihDataSet _PregledRadnikaDataset2;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDKREDITOR")]
        private UltraNumericEditor _textIDKREDITOR;
        [AccessedThroughProperty("textOBRIZNOSRATEKREDITOR")]
        private UltraNumericEditor _textOBRIZNOSRATEKREDITOR;
        [AccessedThroughProperty("textOBRMOKREDITOR")]
        private UltraTextEditor _textOBRMOKREDITOR;
        [AccessedThroughProperty("textOBRMZKREDITOR")]
        private UltraTextEditor _textOBRMZKREDITOR;
        [AccessedThroughProperty("textOBROPISPLACANJAKREDITOR")]
        private UltraTextEditor _textOBROPISPLACANJAKREDITOR;
        [AccessedThroughProperty("textOBRPOKREDITOR")]
        private UltraTextEditor _textOBRPOKREDITOR;
        [AccessedThroughProperty("textOBRPZKREDITOR")]
        private UltraTextEditor _textOBRPZKREDITOR;
        [AccessedThroughProperty("textOBRSIFRAOPISAPLACANJAKREDITOR")]
        private UltraTextEditor _textOBRSIFRAOPISAPLACANJAKREDITOR;
        [AccessedThroughProperty("textUKUPNIZNOSKREDITA")]
        private UltraNumericEditor _textUKUPNIZNOSKREDITA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        [AccessedThroughProperty("UltraButton1")]
        private UltraButton _UltraButton1;
        [AccessedThroughProperty("UltraButton2")]
        private UltraButton _UltraButton2;
        [AccessedThroughProperty("UltraButton3")]
        private UltraButton _UltraButton3;
        [AccessedThroughProperty("UltraDockManager1")]
        private UltraDockManager _UltraDockManager1;
        [AccessedThroughProperty("UltraGrid2")]
        private UltraGrid _UltraGrid2;
        [AccessedThroughProperty("UltraLabel1")]
        private UltraLabel _UltraLabel1;
        [AccessedThroughProperty("WindowDockingArea1")]
        private WindowDockingArea _WindowDockingArea1;
        [AccessedThroughProperty("WindowDockingArea2")]
        private WindowDockingArea _WindowDockingArea2;
        [AccessedThroughProperty("WindowDockingArea3")]
        private WindowDockingArea _WindowDockingArea3;
        private IContainer components;
        private SmartPartInfoProvider infoProvider;
        
        private SmartPartInfo smartPartInfo1;

        public UnosKreditaSmartPart()
        {
            base.Load += new EventHandler(this.UnosKreditaSmartPart_Load);
            this.PregledRadnikaDataset2 = new PregledRadnikaSvihDataSet();
            this.smartPartInfo1 = new SmartPartInfo("Unos kredita", "UnosKredita");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        private int BrojOznacenihRadnika()
        {
            int num2 = 0;
            int num4 = this.UltraGrid2.Rows.Count - 1;
            for (int i = 0; i <= num4; i++)
            {
                if (Conversions.ToBoolean(this.UltraGrid2.Rows[i].Cells["oznacen"].Value))
                {
                    num2++;
                }
            }
            return num2;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
        }

        private void chkAktivni_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAktivni.Checked)
            {
                this.Parametri_PrikaziSamoAktivne();
            }
            else
            {
                this.Parametri_PrikaziSve();
            }
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            ISmartPartInfo info = null;
            return info;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("RADNIK", -1);
            UltraGridColumn column = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column3 = new UltraGridColumn("JMBG");
            UltraGridColumn column4 = new UltraGridColumn("PREZIME", -1, null, 0, SortIndicator.Ascending, false);
            UltraGridColumn column5 = new UltraGridColumn("IME");
            UltraGridColumn column6 = new UltraGridColumn("AKTIVAN");
            UltraGridColumn column7 = new UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            UltraGridColumn column8 = new UltraGridColumn("IDORGDIO");
            UltraGridColumn column9 = new UltraGridColumn("OIB");
            UltraGridColumn column10 = new UltraGridColumn("UKUPNIFAKTOR");
            UltraGridColumn column2 = new UltraGridColumn("oznacen", 0);
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            EditorButton button = new EditorButton("editorButtonKREDITORIDKREDITOR");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(UnosKreditaSmartPart));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Guid internalId = new Guid("90d5d628-641f-4740-add3-bd7e8ed80d8f");
            DockAreaPane pane4 = new DockAreaPane(DockedLocation.DockedTop, internalId);
            internalId = new Guid("abad36a7-e99d-42aa-9948-ca791e6b1ee3");
            Guid floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            Guid dockedParentId = new Guid("90d5d628-641f-4740-add3-bd7e8ed80d8f");
            DockableControlPane pane = new DockableControlPane(internalId, floatingParentId, -1, dockedParentId, -1);
            dockedParentId = new Guid("10298b39-0b8f-4634-aa30-a8dc5b77a47b");
            DockAreaPane pane5 = new DockAreaPane(DockedLocation.DockedLeft, dockedParentId);
            dockedParentId = new Guid("7d39311a-d55a-4601-9d7d-454db18dc2fb");
            floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            internalId = new Guid("10298b39-0b8f-4634-aa30-a8dc5b77a47b");
            DockableControlPane pane2 = new DockableControlPane(dockedParentId, floatingParentId, -1, internalId, -1);
            dockedParentId = new Guid("41c8bf55-da03-46d6-975d-0bb0318d9332");
            DockAreaPane pane6 = new DockAreaPane(DockedLocation.DockedLeft, dockedParentId);
            dockedParentId = new Guid("6e601cb4-1235-4f47-b29a-0c3afc4383dd");
            floatingParentId = new Guid("00000000-0000-0000-0000-000000000000");
            internalId = new Guid("41c8bf55-da03-46d6-975d-0bb0318d9332");
            DockableControlPane pane3 = new DockableControlPane(dockedParentId, floatingParentId, -1, internalId, -1);
            this.GroupBox1 = new GroupBox();
            this.chkAktivni = new UltraCheckEditor();
            this.UltraButton2 = new UltraButton();
            this.UltraButton1 = new UltraButton();
            this.Panel2 = new Panel();
            this.UltraGrid2 = new UltraGrid();
            this.PregledRadnikaDataset2 = new PregledRadnikaSvihDataSet();
            this.Panel1 = new Panel();
            this.layoutManagerformOBRACUNKrediti = new TableLayoutPanel();
            this.UltraButton3 = new UltraButton();
            this.UltraLabel1 = new UltraLabel();
            this.textIDKREDITOR = new UltraNumericEditor();
            this.bindingSourceOBRACUNKrediti = new BindingSource(this.components);
            this.dsOBRACUNDataSet1 = new OBRACUNDataSet();
            this.label1DatumUgovora = new UltraLabel();
            this.datePickerDatumUgovora = new UltraDateTimeEditor();
            this.label1NAZIVKREDITOR = new UltraLabel();
            this.labelNAZIVKREDITOR = new UltraLabel();
            this.label1VBDIKREDITOR = new UltraLabel();
            this.labelVBDIKREDITOR = new UltraLabel();
            this.label1ZRNKREDITOR = new UltraLabel();
            this.labelZRNKREDITOR = new UltraLabel();
            this.label1PRIMATELJKREDITOR1 = new UltraLabel();
            this.labelPRIMATELJKREDITOR1 = new UltraLabel();
            this.labelPRIMATELJKREDITOR2 = new UltraLabel();
            this.label1PRIMATELJKREDITOR3 = new UltraLabel();
            this.labelPRIMATELJKREDITOR3 = new UltraLabel();
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR = new UltraLabel();
            this.textOBRSIFRAOPISAPLACANJAKREDITOR = new UltraTextEditor();
            this.label1OBROPISPLACANJAKREDITOR = new UltraLabel();
            this.textOBROPISPLACANJAKREDITOR = new UltraTextEditor();
            this.label1OBRMOKREDITOR = new UltraLabel();
            this.textOBRMOKREDITOR = new UltraTextEditor();
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.label1OBRPOKREDITOR = new UltraLabel();
            this.textOBRPOKREDITOR = new UltraTextEditor();
            this.label1OBRMZKREDITOR = new UltraLabel();
            this.textOBRMZKREDITOR = new UltraTextEditor();
            this.label1OBRPZKREDITOR = new UltraLabel();
            this.textOBRPZKREDITOR = new UltraTextEditor();
            this.label1OBRIZNOSRATEKREDITOR = new UltraLabel();
            this.label1PRIMATELJKREDITOR2 = new UltraLabel();
            this.textOBRIZNOSRATEKREDITOR = new UltraNumericEditor();
            this.textUKUPNIZNOSKREDITA = new UltraNumericEditor();
            this.label1IDKREDITOR = new UltraLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider(this.components);
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this._UnosKreditaSmartPartUnpinnedTabAreaLeft = new UnpinnedTabArea();
            this.UltraDockManager1 = new UltraDockManager(this.components);
            this._UnosKreditaSmartPartUnpinnedTabAreaRight = new UnpinnedTabArea();
            this._UnosKreditaSmartPartUnpinnedTabAreaTop = new UnpinnedTabArea();
            this._UnosKreditaSmartPartUnpinnedTabAreaBottom = new UnpinnedTabArea();
            this._UnosKreditaSmartPartAutoHideControl = new AutoHideControl();
            this.WindowDockingArea1 = new WindowDockingArea();
            this.DockableWindow1 = new DockableWindow();
            this.WindowDockingArea3 = new WindowDockingArea();
            this.DockableWindow3 = new DockableWindow();
            this.WindowDockingArea2 = new WindowDockingArea();
            this.DockableWindow2 = new DockableWindow();
            this.GroupBox1.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((ISupportInitialize) this.UltraGrid2).BeginInit();
            this.PregledRadnikaDataset2.BeginInit();
            this.Panel1.SuspendLayout();
            this.layoutManagerformOBRACUNKrediti.SuspendLayout();
            ((ISupportInitialize) this.textIDKREDITOR).BeginInit();
            ((ISupportInitialize) this.bindingSourceOBRACUNKrediti).BeginInit();
            this.dsOBRACUNDataSet1.BeginInit();
            ((ISupportInitialize) this.datePickerDatumUgovora).BeginInit();
            ((ISupportInitialize) this.textOBRSIFRAOPISAPLACANJAKREDITOR).BeginInit();
            ((ISupportInitialize) this.textOBROPISPLACANJAKREDITOR).BeginInit();
            ((ISupportInitialize) this.textOBRMOKREDITOR).BeginInit();
            ((ISupportInitialize) this.textOBRPOKREDITOR).BeginInit();
            ((ISupportInitialize) this.textOBRMZKREDITOR).BeginInit();
            ((ISupportInitialize) this.textOBRPZKREDITOR).BeginInit();
            ((ISupportInitialize) this.textOBRIZNOSRATEKREDITOR).BeginInit();
            ((ISupportInitialize) this.textUKUPNIZNOSKREDITA).BeginInit();
            ((ISupportInitialize) this.errorProvider1).BeginInit();
            ((ISupportInitialize) this.UltraDockManager1).BeginInit();
            this.WindowDockingArea1.SuspendLayout();
            this.DockableWindow1.SuspendLayout();
            this.WindowDockingArea3.SuspendLayout();
            this.DockableWindow3.SuspendLayout();
            this.WindowDockingArea2.SuspendLayout();
            this.DockableWindow2.SuspendLayout();
            this.SuspendLayout();
            this.GroupBox1.Controls.Add(this.chkAktivni);
            this.GroupBox1.Controls.Add(this.UltraButton2);
            this.GroupBox1.Controls.Add(this.UltraButton1);
            this.errorProviderValidator1.SetDisplayName(this.GroupBox1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            System.Drawing.Point point = new System.Drawing.Point(0, 0x12);
            this.GroupBox1.Location = point;
            this.GroupBox1.Name = "GroupBox1";
            this.errorProviderValidator1.SetRegularExpression(this.GroupBox1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.GroupBox1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.GroupBox1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.GroupBox1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            Size size = new System.Drawing.Size(0x48a, 0x79);
            this.GroupBox1.Size = size;
            this.GroupBox1.TabIndex = 0x37;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "GroupBox1";
            this.errorProviderValidator1.SetDisplayName(this.chkAktivni, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(6, 0x13);
            this.chkAktivni.Location = point;
            this.chkAktivni.Name = "chkAktivni";
            this.errorProviderValidator1.SetRegularExpression(this.chkAktivni, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.chkAktivni, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.chkAktivni, false);
            this.errorProviderValidator1.SetRequiredMessage(this.chkAktivni, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x88, 20);
            this.chkAktivni.Size = size;
            this.chkAktivni.TabIndex = 0x31;
            this.chkAktivni.Text = "Prikaži samo aktivne";
            this.chkAktivni.UseAppStyling = false;
            this.UltraButton2.ButtonStyle = UIElementButtonStyle.WindowsVistaButton;
            this.errorProviderValidator1.SetDisplayName(this.UltraButton2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(0x87, 0x4e);
            this.UltraButton2.Location = point;
            this.UltraButton2.Name = "UltraButton2";
            this.errorProviderValidator1.SetRegularExpression(this.UltraButton2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.UltraButton2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.UltraButton2, false);
            this.errorProviderValidator1.SetRequiredMessage(this.UltraButton2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x80, 0x17);
            this.UltraButton2.Size = size;
            this.UltraButton2.TabIndex = 0x30;
            this.UltraButton2.Text = "Ukloni oznake svima";
            this.UltraButton2.UseAppStyling = false;
            this.UltraButton2.UseOsThemes = DefaultableBoolean.False;
            this.UltraButton1.ButtonStyle = UIElementButtonStyle.WindowsVistaButton;
            this.errorProviderValidator1.SetDisplayName(this.UltraButton1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(6, 0x4e);
            this.UltraButton1.Location = point;
            this.UltraButton1.Name = "UltraButton1";
            this.errorProviderValidator1.SetRegularExpression(this.UltraButton1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.UltraButton1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.UltraButton1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.UltraButton1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x7b, 0x17);
            this.UltraButton1.Size = size;
            this.UltraButton1.TabIndex = 0x2f;
            this.UltraButton1.Text = "Dodaj oznake svima";
            this.UltraButton1.UseAppStyling = false;
            this.UltraButton1.UseOsThemes = DefaultableBoolean.False;
            this.Panel2.Controls.Add(this.UltraGrid2);
            this.errorProviderValidator1.SetDisplayName(this.Panel2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(0, 0x12);
            this.Panel2.Location = point;
            this.Panel2.Name = "Panel2";
            this.errorProviderValidator1.SetRegularExpression(this.Panel2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.Panel2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.Panel2, false);
            this.errorProviderValidator1.SetRequiredMessage(this.Panel2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x266, 0x20b);
            this.Panel2.Size = size;
            this.Panel2.TabIndex = 0x3a;
            this.UltraGrid2.DataMember = "RADNIK";
            this.UltraGrid2.DataSource = this.PregledRadnikaDataset2;
            appearance18.BackColor = Color.White;
            this.UltraGrid2.DisplayLayout.Appearance = appearance18;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            column.CellActivation = Activation.NoEdit;
            column.Header.VisiblePosition = 1;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            column3.CellActivation = Activation.NoEdit;
            column3.Header.VisiblePosition = 2;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            column4.CellActivation = Activation.NoEdit;
            column4.Header.VisiblePosition = 3;
            column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            column5.CellActivation = Activation.NoEdit;
            column5.Header.VisiblePosition = 4;
            column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            column6.CellActivation = Activation.NoEdit;
            column6.Header.VisiblePosition = 5;
            column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            column7.CellActivation = Activation.NoEdit;
            column7.Header.VisiblePosition = 6;
            column8.Header.VisiblePosition = 7;
            column9.Header.VisiblePosition = 8;
            column10.Header.VisiblePosition = 9;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            column2.DataType = typeof(bool);
            column2.DefaultCellValue = false;
            column2.Header.Caption = "Označen";
            column2.Header.VisiblePosition = 0;
            band.Columns.AddRange(new object[] { column, column3, column4, column5, column6, column7, column8, column9, column10, column2 });
            band.Override.RowSelectors = DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid2.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid2.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance19.BackColor = Color.Transparent;
            this.UltraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance19;
            this.UltraGrid2.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.UltraGrid2.DisplayLayout.Override.CellPadding = 3;
            this.UltraGrid2.DisplayLayout.Override.ColumnAutoSizeMode = ColumnAutoSizeMode.AllRowsInBand;
            appearance20.TextHAlignAsString = "Left";
            this.UltraGrid2.DisplayLayout.Override.HeaderAppearance = appearance20;
            this.UltraGrid2.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;
            appearance21.BorderColor = Color.LightGray;
            appearance21.TextVAlignAsString = "Middle";
            this.UltraGrid2.DisplayLayout.Override.RowAppearance = appearance21;
            appearance22.BackColor = Color.LightSteelBlue;
            appearance22.BorderColor = Color.Black;
            appearance22.ForeColor = Color.Black;
            this.UltraGrid2.DisplayLayout.Override.SelectedRowAppearance = appearance22;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCol = SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
            this.UltraGrid2.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid2.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            this.UltraGrid2.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            this.UltraGrid2.DisplayLayout.TabNavigation = TabNavigation.NextControl;
            this.UltraGrid2.DisplayLayout.ViewStyle = ViewStyle.SingleBand;
            this.errorProviderValidator1.SetDisplayName(this.UltraGrid2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.UltraGrid2.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.UltraGrid2.Location = point;
            this.UltraGrid2.Name = "UltraGrid2";
            this.errorProviderValidator1.SetRegularExpression(this.UltraGrid2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.UltraGrid2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.UltraGrid2, false);
            this.errorProviderValidator1.SetRequiredMessage(this.UltraGrid2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x266, 0x20b);
            this.UltraGrid2.Size = size;
            this.UltraGrid2.TabIndex = 0x2c;
            this.toolTip1.SetToolTip(this.UltraGrid2, "Lijevim klikom miša odaberite zaposlenike kojima želite zadati kredit");
            this.PregledRadnikaDataset2.DataSetName = "PregledRadnikaDataset2";
            this.Panel1.Controls.Add(this.layoutManagerformOBRACUNKrediti);
            this.errorProviderValidator1.SetDisplayName(this.Panel1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(0, 0x12);
            this.Panel1.Location = point;
            this.Panel1.Name = "Panel1";
            this.errorProviderValidator1.SetRegularExpression(this.Panel1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.Panel1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.Panel1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.Panel1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x216, 0x20b);
            this.Panel1.Size = size;
            this.Panel1.TabIndex = 0x2d;
            this.layoutManagerformOBRACUNKrediti.AutoSize = true;
            this.layoutManagerformOBRACUNKrediti.ColumnCount = 2;
            this.layoutManagerformOBRACUNKrediti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOBRACUNKrediti.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.UltraButton3, 1, 0x10);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.UltraLabel1, 0, 15);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textIDKREDITOR, 1, 0);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1DatumUgovora, 0, 1);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.datePickerDatumUgovora, 1, 1);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1NAZIVKREDITOR, 0, 2);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.labelNAZIVKREDITOR, 1, 2);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1VBDIKREDITOR, 0, 3);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.labelVBDIKREDITOR, 1, 3);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1ZRNKREDITOR, 0, 4);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.labelZRNKREDITOR, 1, 4);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1PRIMATELJKREDITOR1, 0, 5);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.labelPRIMATELJKREDITOR1, 1, 5);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.labelPRIMATELJKREDITOR2, 1, 6);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1PRIMATELJKREDITOR3, 0, 7);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.labelPRIMATELJKREDITOR3, 1, 7);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1OBRSIFRAOPISAPLACANJAKREDITOR, 0, 8);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textOBRSIFRAOPISAPLACANJAKREDITOR, 1, 8);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1OBROPISPLACANJAKREDITOR, 0, 9);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textOBROPISPLACANJAKREDITOR, 1, 9);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1OBRMOKREDITOR, 0, 10);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textOBRMOKREDITOR, 1, 10);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1OBRPOKREDITOR, 0, 11);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textOBRPOKREDITOR, 1, 11);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1OBRMZKREDITOR, 0, 12);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textOBRMZKREDITOR, 1, 12);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1OBRPZKREDITOR, 0, 13);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textOBRPZKREDITOR, 1, 13);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1OBRIZNOSRATEKREDITOR, 0, 14);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1PRIMATELJKREDITOR2, 0, 6);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textOBRIZNOSRATEKREDITOR, 1, 14);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.textUKUPNIZNOSKREDITA, 1, 15);
            this.layoutManagerformOBRACUNKrediti.Controls.Add(this.label1IDKREDITOR, 0, 0);
            this.errorProviderValidator1.SetDisplayName(this.layoutManagerformOBRACUNKrediti, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.layoutManagerformOBRACUNKrediti.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.layoutManagerformOBRACUNKrediti.Location = point;
            this.layoutManagerformOBRACUNKrediti.Name = "layoutManagerformOBRACUNKrediti";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerformOBRACUNKrediti, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerformOBRACUNKrediti, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.layoutManagerformOBRACUNKrediti, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerformOBRACUNKrediti, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.layoutManagerformOBRACUNKrediti.RowCount = 0x11;
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle());
            this.layoutManagerformOBRACUNKrediti.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            size = new System.Drawing.Size(0x216, 0x20b);
            this.layoutManagerformOBRACUNKrediti.Size = size;
            this.layoutManagerformOBRACUNKrediti.TabIndex = 1;
            this.UltraButton3.ButtonStyle = UIElementButtonStyle.WindowsVistaButton;
            this.errorProviderValidator1.SetDisplayName(this.UltraButton3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(0xcb, 0x192);
            this.UltraButton3.Location = point;
            this.UltraButton3.Name = "UltraButton3";
            this.errorProviderValidator1.SetRegularExpression(this.UltraButton3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.UltraButton3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.UltraButton3, false);
            this.errorProviderValidator1.SetRequiredMessage(this.UltraButton3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x80, 0x17);
            this.UltraButton3.Size = size;
            this.UltraButton3.TabIndex = 50;
            this.UltraButton3.Text = "Zaduži kredit";
            this.UltraButton3.UseAppStyling = false;
            this.UltraButton3.UseOsThemes = DefaultableBoolean.False;
            appearance16.ForeColor = Color.Black;
            appearance16.TextVAlignAsString = "Middle";
            this.UltraLabel1.Appearance = appearance16;
            this.UltraLabel1.AutoSize = true;
            this.UltraLabel1.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.UltraLabel1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(3, 0x178);
            this.UltraLabel1.Location = point;
            Padding padding = new Padding(3, 1, 5, 2);
            this.UltraLabel1.Margin = padding;
            this.UltraLabel1.Name = "UltraLabel1";
            this.errorProviderValidator1.SetRegularExpression(this.UltraLabel1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.UltraLabel1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.UltraLabel1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.UltraLabel1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x9b, 14);
            this.UltraLabel1.Size = size;
            this.UltraLabel1.StyleSetName = "FieldUltraLabel";
            this.UltraLabel1.TabIndex = 0x2f;
            this.UltraLabel1.Tag = "labelOBRIZNOSRATEKREDITOR";
            this.UltraLabel1.Text = "OBRIZNOSRATEKREDITOR:";
            this.textIDKREDITOR.Anchor = AnchorStyles.Left;
            button.Key = "editorButtonKREDITORIDKREDITOR";
            button.Tag = "editorButtonKREDITORIDKREDITOR";
            button.Text = "...";
            this.textIDKREDITOR.ButtonsRight.Add(button);
            this.textIDKREDITOR.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUNKrediti, "IDKREDITOR", true));
            this.errorProviderValidator1.SetDisplayName(this.textIDKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 1);
            this.textIDKREDITOR.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.textIDKREDITOR.Margin = padding;
            this.textIDKREDITOR.MaskInput = "99999999";
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textIDKREDITOR.MinimumSize = size;
            this.textIDKREDITOR.Name = "textIDKREDITOR";
            this.textIDKREDITOR.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textIDKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textIDKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.textIDKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textIDKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x5c, 0x16);
            this.textIDKREDITOR.Size = size;
            this.textIDKREDITOR.TabIndex = 0;
            this.textIDKREDITOR.Tag = "IDKREDITOR";
            this.bindingSourceOBRACUNKrediti.DataMember = "OBRACUNKrediti";
            this.bindingSourceOBRACUNKrediti.DataSource = this.dsOBRACUNDataSet1;
            this.dsOBRACUNDataSet1.DataSetName = "dsOBRACUN";
            this.dsOBRACUNDataSet1.Locale = new CultureInfo("hr-HR");
            this.label1DatumUgovora.Anchor = AnchorStyles.Left;
            appearance4.ForeColor = Color.Black;
            appearance4.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("Appearance12.Image"));
            appearance4.ImageHAlign = HAlign.Right;
            appearance4.TextVAlignAsString = "Middle";
            this.label1DatumUgovora.Appearance = appearance4;
            this.label1DatumUgovora.AutoSize = true;
            this.label1DatumUgovora.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1DatumUgovora, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(7, 10);
            this.label1DatumUgovora.ImageSize = size;
            point = new System.Drawing.Point(3, 30);
            this.label1DatumUgovora.Location = point;
            padding = new Padding(3, 1, 5, 2);
            this.label1DatumUgovora.Margin = padding;
            this.label1DatumUgovora.Name = "label1DatumUgovora";
            this.errorProviderValidator1.SetRegularExpression(this.label1DatumUgovora, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1DatumUgovora, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.label1DatumUgovora, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1DatumUgovora, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x5e, 14);
            this.label1DatumUgovora.Size = size;
            this.label1DatumUgovora.StyleSetName = "FieldUltraLabel";
            this.label1DatumUgovora.TabIndex = 1;
            this.label1DatumUgovora.Tag = "labelDatumUgovora";
            this.label1DatumUgovora.Text = "Datum Ugovora:";
            this.datePickerDatumUgovora.Anchor = AnchorStyles.Left;
            this.errorProviderValidator1.SetDisplayName(this.datePickerDatumUgovora, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 0x1a);
            this.datePickerDatumUgovora.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDatumUgovora.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDatumUgovora.MinimumSize = size;
            this.datePickerDatumUgovora.Name = "datePickerDatumUgovora";
            this.errorProviderValidator1.SetRegularExpression(this.datePickerDatumUgovora, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.datePickerDatumUgovora, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.datePickerDatumUgovora, false);
            this.errorProviderValidator1.SetRequiredMessage(this.datePickerDatumUgovora, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDatumUgovora.Size = size;
            this.datePickerDatumUgovora.TabIndex = 0;
            this.datePickerDatumUgovora.Tag = "DatumUgovora";
            this.label1NAZIVKREDITOR.Anchor = AnchorStyles.Left;
            appearance2.ForeColor = Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.label1NAZIVKREDITOR.Appearance = appearance2;
            this.label1NAZIVKREDITOR.AutoSize = true;
            this.label1NAZIVKREDITOR.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1NAZIVKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(3, 0x37);
            this.label1NAZIVKREDITOR.Location = point;
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVKREDITOR.Margin = padding;
            this.label1NAZIVKREDITOR.Name = "label1NAZIVKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.label1NAZIVKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1NAZIVKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.label1NAZIVKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1NAZIVKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x63, 14);
            this.label1NAZIVKREDITOR.Size = size;
            this.label1NAZIVKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVKREDITOR.TabIndex = 1;
            this.label1NAZIVKREDITOR.Tag = "labelNAZIVKREDITOR";
            this.label1NAZIVKREDITOR.Text = "NAZIVKREDITOR:";
            this.labelNAZIVKREDITOR.Anchor = AnchorStyles.Left;
            appearance5.TextVAlignAsString = "Middle";
            this.labelNAZIVKREDITOR.Appearance = appearance5;
            this.labelNAZIVKREDITOR.BackColorInternal = Color.Transparent;
            this.labelNAZIVKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "NAZIVKREDITOR", true));
            this.errorProviderValidator1.SetDisplayName(this.labelNAZIVKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 0x33);
            this.labelNAZIVKREDITOR.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelNAZIVKREDITOR.MinimumSize = size;
            this.labelNAZIVKREDITOR.Name = "labelNAZIVKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.labelNAZIVKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.labelNAZIVKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.labelNAZIVKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.labelNAZIVKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelNAZIVKREDITOR.Size = size;
            this.labelNAZIVKREDITOR.TabIndex = 0;
            this.labelNAZIVKREDITOR.Tag = "NAZIVKREDITOR";
            this.label1VBDIKREDITOR.Anchor = AnchorStyles.Left;
            appearance6.ForeColor = Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.label1VBDIKREDITOR.Appearance = appearance6;
            this.label1VBDIKREDITOR.AutoSize = true;
            this.label1VBDIKREDITOR.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1VBDIKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(3, 80);
            this.label1VBDIKREDITOR.Location = point;
            padding = new Padding(3, 1, 5, 2);
            this.label1VBDIKREDITOR.Margin = padding;
            this.label1VBDIKREDITOR.Name = "label1VBDIKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.label1VBDIKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1VBDIKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.label1VBDIKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1VBDIKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x5c, 14);
            this.label1VBDIKREDITOR.Size = size;
            this.label1VBDIKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1VBDIKREDITOR.TabIndex = 1;
            this.label1VBDIKREDITOR.Tag = "labelVBDIKREDITOR";
            this.label1VBDIKREDITOR.Text = "VBDIKREDITOR:";
            this.labelVBDIKREDITOR.Anchor = AnchorStyles.Left;
            appearance7.TextVAlignAsString = "Middle";
            this.labelVBDIKREDITOR.Appearance = appearance7;
            this.labelVBDIKREDITOR.BackColorInternal = Color.Transparent;
            this.labelVBDIKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "VBDIKREDITOR", true));
            this.errorProviderValidator1.SetDisplayName(this.labelVBDIKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 0x4c);
            this.labelVBDIKREDITOR.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.labelVBDIKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.labelVBDIKREDITOR.MinimumSize = size;
            this.labelVBDIKREDITOR.Name = "labelVBDIKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.labelVBDIKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.labelVBDIKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.labelVBDIKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.labelVBDIKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x41, 0x16);
            this.labelVBDIKREDITOR.Size = size;
            this.labelVBDIKREDITOR.TabIndex = 0;
            this.labelVBDIKREDITOR.Tag = "VBDIKREDITOR";
            this.label1ZRNKREDITOR.Anchor = AnchorStyles.Left;
            appearance27.ForeColor = Color.Black;
            appearance27.TextVAlignAsString = "Middle";
            this.label1ZRNKREDITOR.Appearance = appearance27;
            this.label1ZRNKREDITOR.AutoSize = true;
            this.label1ZRNKREDITOR.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1ZRNKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(3, 0x69);
            this.label1ZRNKREDITOR.Location = point;
            padding = new Padding(3, 1, 5, 2);
            this.label1ZRNKREDITOR.Margin = padding;
            this.label1ZRNKREDITOR.Name = "label1ZRNKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.label1ZRNKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1ZRNKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.label1ZRNKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1ZRNKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x59, 14);
            this.label1ZRNKREDITOR.Size = size;
            this.label1ZRNKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1ZRNKREDITOR.TabIndex = 1;
            this.label1ZRNKREDITOR.Tag = "labelZRNKREDITOR";
            this.label1ZRNKREDITOR.Text = "ZRNKREDITOR:";
            this.labelZRNKREDITOR.Anchor = AnchorStyles.Left;
            appearance.TextVAlignAsString = "Middle";
            this.labelZRNKREDITOR.Appearance = appearance;
            this.labelZRNKREDITOR.BackColorInternal = Color.Transparent;
            this.labelZRNKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "ZRNKREDITOR", true));
            this.errorProviderValidator1.SetDisplayName(this.labelZRNKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 0x65);
            this.labelZRNKREDITOR.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.labelZRNKREDITOR.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.labelZRNKREDITOR.MinimumSize = size;
            this.labelZRNKREDITOR.Name = "labelZRNKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.labelZRNKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.labelZRNKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.labelZRNKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.labelZRNKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x56, 0x16);
            this.labelZRNKREDITOR.Size = size;
            this.labelZRNKREDITOR.TabIndex = 0;
            this.labelZRNKREDITOR.Tag = "ZRNKREDITOR";
            this.label1PRIMATELJKREDITOR1.Anchor = AnchorStyles.Left;
            appearance8.ForeColor = Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.label1PRIMATELJKREDITOR1.Appearance = appearance8;
            this.label1PRIMATELJKREDITOR1.AutoSize = true;
            this.label1PRIMATELJKREDITOR1.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PRIMATELJKREDITOR1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(3, 130);
            this.label1PRIMATELJKREDITOR1.Location = point;
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJKREDITOR1.Margin = padding;
            this.label1PRIMATELJKREDITOR1.Name = "label1PRIMATELJKREDITOR1";
            this.errorProviderValidator1.SetRegularExpression(this.label1PRIMATELJKREDITOR1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PRIMATELJKREDITOR1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.label1PRIMATELJKREDITOR1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PRIMATELJKREDITOR1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x89, 14);
            this.label1PRIMATELJKREDITOR1.Size = size;
            this.label1PRIMATELJKREDITOR1.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJKREDITOR1.TabIndex = 1;
            this.label1PRIMATELJKREDITOR1.Tag = "labelPRIMATELJKREDITOR1";
            this.label1PRIMATELJKREDITOR1.Text = "PRIMATELJKREDITO R1:";
            this.labelPRIMATELJKREDITOR1.Anchor = AnchorStyles.Left;
            appearance9.TextVAlignAsString = "Middle";
            this.labelPRIMATELJKREDITOR1.Appearance = appearance9;
            this.labelPRIMATELJKREDITOR1.BackColorInternal = Color.Transparent;
            this.labelPRIMATELJKREDITOR1.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "PRIMATELJKREDITOR1", true));
            this.errorProviderValidator1.SetDisplayName(this.labelPRIMATELJKREDITOR1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 0x7e);
            this.labelPRIMATELJKREDITOR1.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJKREDITOR1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJKREDITOR1.MinimumSize = size;
            this.labelPRIMATELJKREDITOR1.Name = "labelPRIMATELJKREDITOR1";
            this.errorProviderValidator1.SetRegularExpression(this.labelPRIMATELJKREDITOR1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.labelPRIMATELJKREDITOR1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.labelPRIMATELJKREDITOR1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.labelPRIMATELJKREDITOR1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJKREDITOR1.Size = size;
            this.labelPRIMATELJKREDITOR1.TabIndex = 0;
            this.labelPRIMATELJKREDITOR1.Tag = "PRIMATELJKREDITOR1";
            this.labelPRIMATELJKREDITOR2.Anchor = AnchorStyles.Left;
            appearance11.TextVAlignAsString = "Middle";
            this.labelPRIMATELJKREDITOR2.Appearance = appearance11;
            this.labelPRIMATELJKREDITOR2.BackColorInternal = Color.Transparent;
            this.labelPRIMATELJKREDITOR2.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "PRIMATELJKREDITOR2", true));
            this.errorProviderValidator1.SetDisplayName(this.labelPRIMATELJKREDITOR2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 0x97);
            this.labelPRIMATELJKREDITOR2.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJKREDITOR2.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJKREDITOR2.MinimumSize = size;
            this.labelPRIMATELJKREDITOR2.Name = "labelPRIMATELJKREDITOR2";
            this.errorProviderValidator1.SetRegularExpression(this.labelPRIMATELJKREDITOR2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.labelPRIMATELJKREDITOR2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.labelPRIMATELJKREDITOR2, false);
            this.errorProviderValidator1.SetRequiredMessage(this.labelPRIMATELJKREDITOR2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJKREDITOR2.Size = size;
            this.labelPRIMATELJKREDITOR2.TabIndex = 0;
            this.labelPRIMATELJKREDITOR2.Tag = "PRIMATELJKREDITOR2";
            this.label1PRIMATELJKREDITOR3.Anchor = AnchorStyles.Left;
            appearance13.ForeColor = Color.Black;
            appearance13.TextVAlignAsString = "Middle";
            this.label1PRIMATELJKREDITOR3.Appearance = appearance13;
            this.label1PRIMATELJKREDITOR3.AutoSize = true;
            this.label1PRIMATELJKREDITOR3.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PRIMATELJKREDITOR3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(3, 180);
            this.label1PRIMATELJKREDITOR3.Location = point;
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJKREDITOR3.Margin = padding;
            this.label1PRIMATELJKREDITOR3.Name = "label1PRIMATELJKREDITOR3";
            this.errorProviderValidator1.SetRegularExpression(this.label1PRIMATELJKREDITOR3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PRIMATELJKREDITOR3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.label1PRIMATELJKREDITOR3, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PRIMATELJKREDITOR3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x89, 14);
            this.label1PRIMATELJKREDITOR3.Size = size;
            this.label1PRIMATELJKREDITOR3.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJKREDITOR3.TabIndex = 1;
            this.label1PRIMATELJKREDITOR3.Tag = "labelPRIMATELJKREDITOR3";
            this.label1PRIMATELJKREDITOR3.Text = "PRIMATELJKREDITO R3:";
            this.labelPRIMATELJKREDITOR3.Anchor = AnchorStyles.Left;
            appearance17.TextVAlignAsString = "Middle";
            this.labelPRIMATELJKREDITOR3.Appearance = appearance17;
            this.labelPRIMATELJKREDITOR3.BackColorInternal = Color.Transparent;
            this.labelPRIMATELJKREDITOR3.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "PRIMATELJKREDITOR3", true));
            this.errorProviderValidator1.SetDisplayName(this.labelPRIMATELJKREDITOR3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 0xb0);
            this.labelPRIMATELJKREDITOR3.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.labelPRIMATELJKREDITOR3.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJKREDITOR3.MinimumSize = size;
            this.labelPRIMATELJKREDITOR3.Name = "labelPRIMATELJKREDITOR3";
            this.errorProviderValidator1.SetRegularExpression(this.labelPRIMATELJKREDITOR3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.labelPRIMATELJKREDITOR3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.labelPRIMATELJKREDITOR3, false);
            this.errorProviderValidator1.SetRequiredMessage(this.labelPRIMATELJKREDITOR3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelPRIMATELJKREDITOR3.Size = size;
            this.labelPRIMATELJKREDITOR3.TabIndex = 0;
            this.labelPRIMATELJKREDITOR3.Tag = "PRIMATELJKREDITOR3";
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Anchor = AnchorStyles.Left;
            appearance12.ForeColor = Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Appearance = appearance12;
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.AutoSize = true;
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OBRSIFRAOPISAPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(3, 0xcd);
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Location = point;
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Margin = padding;
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Name = "label1OBRSIFRAOPISAPLACANJAKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.label1OBRSIFRAOPISAPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OBRSIFRAOPISAPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.label1OBRSIFRAOPISAPLACANJAKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OBRSIFRAOPISAPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0xc0, 14);
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Size = size;
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.TabIndex = 1;
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Tag = "labelOBRSIFRAOPISAPLACANJAKREDITOR";
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Text = "SIFRAOPISAPLACANJAKREDITOR:";
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.Anchor = AnchorStyles.Left;
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "OBRSIFRAOPISAPLACANJAKREDITOR", true));
            this.errorProviderValidator1.SetDisplayName(this.textOBRSIFRAOPISAPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 0xc9);
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.Margin = padding;
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.MaxLength = 2;
            size = new System.Drawing.Size(30, 0x16);
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.MinimumSize = size;
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.Name = "textOBRSIFRAOPISAPLACANJAKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.textOBRSIFRAOPISAPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOBRSIFRAOPISAPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.textOBRSIFRAOPISAPLACANJAKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOBRSIFRAOPISAPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(30, 0x16);
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.Size = size;
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.TabIndex = 0;
            this.textOBRSIFRAOPISAPLACANJAKREDITOR.Tag = "OBRSIFRAOPISAPLACANJAKREDITOR";
            this.label1OBROPISPLACANJAKREDITOR.Anchor = AnchorStyles.Left;
            appearance14.ForeColor = Color.Black;
            appearance14.TextVAlignAsString = "Middle";
            this.label1OBROPISPLACANJAKREDITOR.Appearance = appearance14;
            this.label1OBROPISPLACANJAKREDITOR.AutoSize = true;
            this.label1OBROPISPLACANJAKREDITOR.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OBROPISPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(3, 230);
            this.label1OBROPISPLACANJAKREDITOR.Location = point;
            padding = new Padding(3, 1, 5, 2);
            this.label1OBROPISPLACANJAKREDITOR.Margin = padding;
            this.label1OBROPISPLACANJAKREDITOR.Name = "label1OBROPISPLACANJAKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.label1OBROPISPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OBROPISPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.label1OBROPISPLACANJAKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OBROPISPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0xb0, 14);
            this.label1OBROPISPLACANJAKREDITOR.Size = size;
            this.label1OBROPISPLACANJAKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1OBROPISPLACANJAKREDITOR.TabIndex = 1;
            this.label1OBROPISPLACANJAKREDITOR.Tag = "labelOBROPISPLACANJAKREDITOR";
            this.label1OBROPISPLACANJAKREDITOR.Text = "OBROPISPLACANJAKREDITOR:";
            this.textOBROPISPLACANJAKREDITOR.Anchor = AnchorStyles.Left;
            this.textOBROPISPLACANJAKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "OBROPISPLACANJAKREDITOR", true));
            this.errorProviderValidator1.SetDisplayName(this.textOBROPISPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 0xe2);
            this.textOBROPISPLACANJAKREDITOR.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.textOBROPISPLACANJAKREDITOR.Margin = padding;
            this.textOBROPISPLACANJAKREDITOR.MaxLength = 0x24;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOBROPISPLACANJAKREDITOR.MinimumSize = size;
            this.textOBROPISPLACANJAKREDITOR.Name = "textOBROPISPLACANJAKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.textOBROPISPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOBROPISPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.textOBROPISPLACANJAKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOBROPISPLACANJAKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textOBROPISPLACANJAKREDITOR.Size = size;
            this.textOBROPISPLACANJAKREDITOR.TabIndex = 0;
            this.textOBROPISPLACANJAKREDITOR.Tag = "OBROPISPLACANJAKREDITOR";
            this.label1OBRMOKREDITOR.Anchor = AnchorStyles.Left;
            appearance25.ForeColor = Color.Black;
            appearance25.TextVAlignAsString = "Middle";
            this.label1OBRMOKREDITOR.Appearance = appearance25;
            this.label1OBRMOKREDITOR.AutoSize = true;
            this.label1OBRMOKREDITOR.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OBRMOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(3, 0xff);
            this.label1OBRMOKREDITOR.Location = point;
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRMOKREDITOR.Margin = padding;
            this.label1OBRMOKREDITOR.Name = "label1OBRMOKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.label1OBRMOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OBRMOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.label1OBRMOKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OBRMOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x6d, 14);
            this.label1OBRMOKREDITOR.Size = size;
            this.label1OBRMOKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1OBRMOKREDITOR.TabIndex = 1;
            this.label1OBRMOKREDITOR.Tag = "labelOBRMOKREDITOR";
            this.label1OBRMOKREDITOR.Text = "OBRMOKREDITOR:";
            this.textOBRMOKREDITOR.Anchor = AnchorStyles.Left;
            this.textOBRMOKREDITOR.ContextMenu = this.contextMenu1;
            this.textOBRMOKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "OBRMOKREDITOR", true));
            this.errorProviderValidator1.SetDisplayName(this.textOBRMOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 0xfb);
            this.textOBRMOKREDITOR.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.textOBRMOKREDITOR.Margin = padding;
            this.textOBRMOKREDITOR.MaxLength = 2;
            size = new System.Drawing.Size(30, 0x16);
            this.textOBRMOKREDITOR.MinimumSize = size;
            this.textOBRMOKREDITOR.Name = "textOBRMOKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.textOBRMOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOBRMOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.textOBRMOKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOBRMOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(30, 0x16);
            this.textOBRMOKREDITOR.Size = size;
            this.textOBRMOKREDITOR.TabIndex = 0;
            this.textOBRMOKREDITOR.Tag = "OBRMOKREDITOR";
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.label1OBRPOKREDITOR.Anchor = AnchorStyles.Left;
            appearance23.ForeColor = Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.label1OBRPOKREDITOR.Appearance = appearance23;
            this.label1OBRPOKREDITOR.AutoSize = true;
            this.label1OBRPOKREDITOR.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OBRPOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(3, 280);
            this.label1OBRPOKREDITOR.Location = point;
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRPOKREDITOR.Margin = padding;
            this.label1OBRPOKREDITOR.Name = "label1OBRPOKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.label1OBRPOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OBRPOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.label1OBRPOKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OBRPOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x6b, 14);
            this.label1OBRPOKREDITOR.Size = size;
            this.label1OBRPOKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1OBRPOKREDITOR.TabIndex = 1;
            this.label1OBRPOKREDITOR.Tag = "labelOBRPOKREDITOR";
            this.label1OBRPOKREDITOR.Text = "OBRPOKREDITOR:";
            this.textOBRPOKREDITOR.Anchor = AnchorStyles.Left;
            this.textOBRPOKREDITOR.ContextMenu = this.contextMenu1;
            this.textOBRPOKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "OBRPOKREDITOR", true));
            this.errorProviderValidator1.SetDisplayName(this.textOBRPOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 0x114);
            this.textOBRPOKREDITOR.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.textOBRPOKREDITOR.Margin = padding;
            this.textOBRPOKREDITOR.MaxLength = 0x16;
            size = new System.Drawing.Size(170, 0x16);
            this.textOBRPOKREDITOR.MinimumSize = size;
            this.textOBRPOKREDITOR.Name = "textOBRPOKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.textOBRPOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOBRPOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.textOBRPOKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOBRPOKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(170, 0x16);
            this.textOBRPOKREDITOR.Size = size;
            this.textOBRPOKREDITOR.TabIndex = 0;
            this.textOBRPOKREDITOR.Tag = "OBRPOKREDITOR";
            this.label1OBRMZKREDITOR.Anchor = AnchorStyles.Left;
            appearance24.ForeColor = Color.Black;
            appearance24.TextVAlignAsString = "Middle";
            this.label1OBRMZKREDITOR.Appearance = appearance24;
            this.label1OBRMZKREDITOR.AutoSize = true;
            this.label1OBRMZKREDITOR.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OBRMZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(3, 0x131);
            this.label1OBRMZKREDITOR.Location = point;
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRMZKREDITOR.Margin = padding;
            this.label1OBRMZKREDITOR.Name = "label1OBRMZKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.label1OBRMZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OBRMZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.label1OBRMZKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OBRMZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x6b, 14);
            this.label1OBRMZKREDITOR.Size = size;
            this.label1OBRMZKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1OBRMZKREDITOR.TabIndex = 1;
            this.label1OBRMZKREDITOR.Tag = "labelOBRMZKREDITOR";
            this.label1OBRMZKREDITOR.Text = "OBRMZKREDITOR:";
            this.textOBRMZKREDITOR.Anchor = AnchorStyles.Left;
            this.textOBRMZKREDITOR.ContextMenu = this.contextMenu1;
            this.textOBRMZKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "OBRMZKREDITOR", true));
            this.errorProviderValidator1.SetDisplayName(this.textOBRMZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 0x12d);
            this.textOBRMZKREDITOR.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.textOBRMZKREDITOR.Margin = padding;
            this.textOBRMZKREDITOR.MaxLength = 2;
            size = new System.Drawing.Size(30, 0x16);
            this.textOBRMZKREDITOR.MinimumSize = size;
            this.textOBRMZKREDITOR.Name = "textOBRMZKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.textOBRMZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOBRMZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.textOBRMZKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOBRMZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(30, 0x16);
            this.textOBRMZKREDITOR.Size = size;
            this.textOBRMZKREDITOR.TabIndex = 0;
            this.textOBRMZKREDITOR.Tag = "OBRMZKREDITOR";
            this.label1OBRPZKREDITOR.Anchor = AnchorStyles.Left;
            appearance15.ForeColor = Color.Black;
            appearance15.TextVAlignAsString = "Middle";
            this.label1OBRPZKREDITOR.Appearance = appearance15;
            this.label1OBRPZKREDITOR.AutoSize = true;
            this.label1OBRPZKREDITOR.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OBRPZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(3, 330);
            this.label1OBRPZKREDITOR.Location = point;
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRPZKREDITOR.Margin = padding;
            this.label1OBRPZKREDITOR.Name = "label1OBRPZKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.label1OBRPZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OBRPZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.label1OBRPZKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OBRPZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x69, 14);
            this.label1OBRPZKREDITOR.Size = size;
            this.label1OBRPZKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1OBRPZKREDITOR.TabIndex = 1;
            this.label1OBRPZKREDITOR.Tag = "labelOBRPZKREDITOR";
            this.label1OBRPZKREDITOR.Text = "OBRPZKREDITOR:";
            this.textOBRPZKREDITOR.Anchor = AnchorStyles.Left;
            this.textOBRPZKREDITOR.ContextMenu = this.contextMenu1;
            this.textOBRPZKREDITOR.DataBindings.Add(new Binding("Text", this.bindingSourceOBRACUNKrediti, "OBRPZKREDITOR", true));
            this.errorProviderValidator1.SetDisplayName(this.textOBRPZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 0x146);
            this.textOBRPZKREDITOR.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.textOBRPZKREDITOR.Margin = padding;
            this.textOBRPZKREDITOR.MaxLength = 0x16;
            size = new System.Drawing.Size(170, 0x16);
            this.textOBRPZKREDITOR.MinimumSize = size;
            this.textOBRPZKREDITOR.Name = "textOBRPZKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.textOBRPZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOBRPZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.textOBRPZKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOBRPZKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(170, 0x16);
            this.textOBRPZKREDITOR.Size = size;
            this.textOBRPZKREDITOR.TabIndex = 0;
            this.textOBRPZKREDITOR.Tag = "OBRPZKREDITOR";
            this.label1OBRIZNOSRATEKREDITOR.Anchor = AnchorStyles.Left;
            appearance26.ForeColor = Color.Black;
            appearance26.TextVAlignAsString = "Middle";
            this.label1OBRIZNOSRATEKREDITOR.Appearance = appearance26;
            this.label1OBRIZNOSRATEKREDITOR.AutoSize = true;
            this.label1OBRIZNOSRATEKREDITOR.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OBRIZNOSRATEKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(3, 0x163);
            this.label1OBRIZNOSRATEKREDITOR.Location = point;
            padding = new Padding(3, 1, 5, 2);
            this.label1OBRIZNOSRATEKREDITOR.Margin = padding;
            this.label1OBRIZNOSRATEKREDITOR.Name = "label1OBRIZNOSRATEKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.label1OBRIZNOSRATEKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OBRIZNOSRATEKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.label1OBRIZNOSRATEKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OBRIZNOSRATEKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x9b, 14);
            this.label1OBRIZNOSRATEKREDITOR.Size = size;
            this.label1OBRIZNOSRATEKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1OBRIZNOSRATEKREDITOR.TabIndex = 1;
            this.label1OBRIZNOSRATEKREDITOR.Tag = "labelOBRIZNOSRATEKREDITOR";
            this.label1OBRIZNOSRATEKREDITOR.Text = "OBRIZNOSRATEKREDITOR:";
            this.label1PRIMATELJKREDITOR2.Anchor = AnchorStyles.Left;
            appearance10.ForeColor = Color.Black;
            appearance10.TextVAlignAsString = "Middle";
            this.label1PRIMATELJKREDITOR2.Appearance = appearance10;
            this.label1PRIMATELJKREDITOR2.AutoSize = true;
            this.label1PRIMATELJKREDITOR2.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PRIMATELJKREDITOR2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(3, 0x9b);
            this.label1PRIMATELJKREDITOR2.Location = point;
            padding = new Padding(3, 1, 5, 2);
            this.label1PRIMATELJKREDITOR2.Margin = padding;
            this.label1PRIMATELJKREDITOR2.Name = "label1PRIMATELJKREDITOR2";
            this.errorProviderValidator1.SetRegularExpression(this.label1PRIMATELJKREDITOR2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PRIMATELJKREDITOR2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.label1PRIMATELJKREDITOR2, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PRIMATELJKREDITOR2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x89, 14);
            this.label1PRIMATELJKREDITOR2.Size = size;
            this.label1PRIMATELJKREDITOR2.StyleSetName = "FieldUltraLabel";
            this.label1PRIMATELJKREDITOR2.TabIndex = 1;
            this.label1PRIMATELJKREDITOR2.Tag = "labelPRIMATELJKREDITOR2";
            this.label1PRIMATELJKREDITOR2.Text = "PRIMATELJKREDITO R2:";
            this.textOBRIZNOSRATEKREDITOR.Anchor = AnchorStyles.Left;
            this.textOBRIZNOSRATEKREDITOR.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUNKrediti, "OBRIZNOSRATEKREDITOR", true));
            this.errorProviderValidator1.SetDisplayName(this.textOBRIZNOSRATEKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 0x15f);
            this.textOBRIZNOSRATEKREDITOR.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.textOBRIZNOSRATEKREDITOR.Margin = padding;
            this.textOBRIZNOSRATEKREDITOR.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            decimal num = new decimal(new int[] { -1, -1, -1, 0 });
            this.textOBRIZNOSRATEKREDITOR.MaxValue = num;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRIZNOSRATEKREDITOR.MinimumSize = size;
            num = new decimal(new int[] { -1, -1, -1, -2147483648 });
            this.textOBRIZNOSRATEKREDITOR.MinValue = num;
            this.textOBRIZNOSRATEKREDITOR.Name = "textOBRIZNOSRATEKREDITOR";
            this.textOBRIZNOSRATEKREDITOR.NumericType = NumericType.Double;
            this.textOBRIZNOSRATEKREDITOR.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOBRIZNOSRATEKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOBRIZNOSRATEKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.textOBRIZNOSRATEKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOBRIZNOSRATEKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x66, 0x16);
            this.textOBRIZNOSRATEKREDITOR.Size = size;
            this.textOBRIZNOSRATEKREDITOR.TabIndex = 0;
            this.textOBRIZNOSRATEKREDITOR.Tag = "OBRIZNOSRATEKREDITOR";
            this.textUKUPNIZNOSKREDITA.DataBindings.Add(new Binding("Value", this.bindingSourceOBRACUNKrediti, "UKUPNIZNOSKREDITA", true));
            this.errorProviderValidator1.SetDisplayName(this.textUKUPNIZNOSKREDITA, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(200, 0x178);
            this.textUKUPNIZNOSKREDITA.Location = point;
            padding = new Padding(0, 1, 3, 2);
            this.textUKUPNIZNOSKREDITA.Margin = padding;
            this.textUKUPNIZNOSKREDITA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            num = new decimal(new int[] { -1, -1, -1, 0 });
            this.textUKUPNIZNOSKREDITA.MaxValue = num;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textUKUPNIZNOSKREDITA.MinimumSize = size;
            num = new decimal(new int[] { -1, -1, -1, -2147483648 });
            this.textUKUPNIZNOSKREDITA.MinValue = num;
            this.textUKUPNIZNOSKREDITA.Name = "textUKUPNIZNOSKREDITA";
            this.textUKUPNIZNOSKREDITA.NumericType = NumericType.Double;
            this.textUKUPNIZNOSKREDITA.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textUKUPNIZNOSKREDITA, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textUKUPNIZNOSKREDITA, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.textUKUPNIZNOSKREDITA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textUKUPNIZNOSKREDITA, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x66, 0x16);
            this.textUKUPNIZNOSKREDITA.Size = size;
            this.textUKUPNIZNOSKREDITA.TabIndex = 0x2e;
            this.textUKUPNIZNOSKREDITA.Tag = "UKUPNIZNOSKREDITA";
            this.label1IDKREDITOR.Anchor = AnchorStyles.Left;
            appearance3.ForeColor = Color.Black;
            appearance3.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("Appearance11.Image"));
            appearance3.ImageHAlign = HAlign.Right;
            appearance3.TextVAlignAsString = "Middle";
            this.label1IDKREDITOR.Appearance = appearance3;
            this.label1IDKREDITOR.AutoSize = true;
            this.label1IDKREDITOR.BackColorInternal = Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IDKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(7, 10);
            this.label1IDKREDITOR.ImageSize = size;
            point = new System.Drawing.Point(3, 5);
            this.label1IDKREDITOR.Location = point;
            padding = new Padding(3, 1, 5, 2);
            this.label1IDKREDITOR.Margin = padding;
            this.label1IDKREDITOR.Name = "label1IDKREDITOR";
            this.errorProviderValidator1.SetRegularExpression(this.label1IDKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IDKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.label1IDKREDITOR, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IDKREDITOR, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x54, 14);
            this.label1IDKREDITOR.Size = size;
            this.label1IDKREDITOR.StyleSetName = "FieldUltraLabel";
            this.label1IDKREDITOR.TabIndex = 1;
            this.label1IDKREDITOR.Tag = "labelIDKREDITOR";
            this.label1IDKREDITOR.Text = "IDKREDITOR:";
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.bindingSourceOBRACUNKrediti;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.errorProviderValidator1.ToolTipProvider = null;
            this.errorProviderValidator1.SetDisplayName(this._UnosKreditaSmartPartUnpinnedTabAreaLeft, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this._UnosKreditaSmartPartUnpinnedTabAreaLeft.Dock = DockStyle.Left;
            this._UnosKreditaSmartPartUnpinnedTabAreaLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._UnosKreditaSmartPartUnpinnedTabAreaLeft.Location = point;
            this._UnosKreditaSmartPartUnpinnedTabAreaLeft.Name = "_UnosKreditaSmartPartUnpinnedTabAreaLeft";
            this._UnosKreditaSmartPartUnpinnedTabAreaLeft.Owner = this.UltraDockManager1;
            this.errorProviderValidator1.SetRegularExpression(this._UnosKreditaSmartPartUnpinnedTabAreaLeft, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this._UnosKreditaSmartPartUnpinnedTabAreaLeft, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this._UnosKreditaSmartPartUnpinnedTabAreaLeft, false);
            this.errorProviderValidator1.SetRequiredMessage(this._UnosKreditaSmartPartUnpinnedTabAreaLeft, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0, 0x2ad);
            this._UnosKreditaSmartPartUnpinnedTabAreaLeft.Size = size;
            this._UnosKreditaSmartPartUnpinnedTabAreaLeft.TabIndex = 50;
            dockedParentId = new Guid("10298b39-0b8f-4634-aa30-a8dc5b77a47b");
            pane4.DockedBefore = dockedParentId;
            pane.Control = this.GroupBox1;
            Rectangle rectangle = new Rectangle(0x155, 0x1c7, 0x26d, 100);
            pane.OriginalControlBounds = rectangle;
            size = new System.Drawing.Size(100, 100);
            pane.Size = size;
            pane.Text = "GroupBox1";
            pane4.Panes.AddRange(new DockablePaneBase[] { pane });
            size = new System.Drawing.Size(0x48a, 0x8b);
            pane4.Size = size;
            pane5.ChildPaneStyle = ChildPaneStyle.VerticalSplit;
            dockedParentId = new Guid("41c8bf55-da03-46d6-975d-0bb0318d9332");
            pane5.DockedBefore = dockedParentId;
            pane2.Control = this.Panel2;
            rectangle = new Rectangle(20, 0x94, 200, 0xe5);
            pane2.OriginalControlBounds = rectangle;
            size = new System.Drawing.Size(100, 100);
            pane2.Size = size;
            pane2.Text = "Panel2";
            pane5.Panes.AddRange(new DockablePaneBase[] { pane2 });
            size = new System.Drawing.Size(0x266, 0x21d);
            pane5.Size = size;
            pane3.Control = this.Panel1;
            rectangle = new Rectangle(0x1b7, 0x10, 0x275, 0x1b1);
            pane3.OriginalControlBounds = rectangle;
            size = new System.Drawing.Size(100, 100);
            pane3.Size = size;
            pane3.Text = "Panel1";
            pane6.Panes.AddRange(new DockablePaneBase[] { pane3 });
            size = new System.Drawing.Size(0x216, 0x21d);
            pane6.Size = size;
            this.UltraDockManager1.DockAreas.AddRange(new DockAreaPane[] { pane4, pane5, pane6 });
            this.UltraDockManager1.HostControl = this;
            this.UltraDockManager1.UseAppStyling = false;
            this.UltraDockManager1.WindowStyle = WindowStyle.Office2007;
            this.errorProviderValidator1.SetDisplayName(this._UnosKreditaSmartPartUnpinnedTabAreaRight, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this._UnosKreditaSmartPartUnpinnedTabAreaRight.Dock = DockStyle.Right;
            this._UnosKreditaSmartPartUnpinnedTabAreaRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x48a, 0);
            this._UnosKreditaSmartPartUnpinnedTabAreaRight.Location = point;
            this._UnosKreditaSmartPartUnpinnedTabAreaRight.Name = "_UnosKreditaSmartPartUnpinnedTabAreaRight";
            this._UnosKreditaSmartPartUnpinnedTabAreaRight.Owner = this.UltraDockManager1;
            this.errorProviderValidator1.SetRegularExpression(this._UnosKreditaSmartPartUnpinnedTabAreaRight, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this._UnosKreditaSmartPartUnpinnedTabAreaRight, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this._UnosKreditaSmartPartUnpinnedTabAreaRight, false);
            this.errorProviderValidator1.SetRequiredMessage(this._UnosKreditaSmartPartUnpinnedTabAreaRight, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0, 0x2ad);
            this._UnosKreditaSmartPartUnpinnedTabAreaRight.Size = size;
            this._UnosKreditaSmartPartUnpinnedTabAreaRight.TabIndex = 0x33;
            this.errorProviderValidator1.SetDisplayName(this._UnosKreditaSmartPartUnpinnedTabAreaTop, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this._UnosKreditaSmartPartUnpinnedTabAreaTop.Dock = DockStyle.Top;
            this._UnosKreditaSmartPartUnpinnedTabAreaTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._UnosKreditaSmartPartUnpinnedTabAreaTop.Location = point;
            this._UnosKreditaSmartPartUnpinnedTabAreaTop.Name = "_UnosKreditaSmartPartUnpinnedTabAreaTop";
            this._UnosKreditaSmartPartUnpinnedTabAreaTop.Owner = this.UltraDockManager1;
            this.errorProviderValidator1.SetRegularExpression(this._UnosKreditaSmartPartUnpinnedTabAreaTop, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this._UnosKreditaSmartPartUnpinnedTabAreaTop, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this._UnosKreditaSmartPartUnpinnedTabAreaTop, false);
            this.errorProviderValidator1.SetRequiredMessage(this._UnosKreditaSmartPartUnpinnedTabAreaTop, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x48a, 0);
            this._UnosKreditaSmartPartUnpinnedTabAreaTop.Size = size;
            this._UnosKreditaSmartPartUnpinnedTabAreaTop.TabIndex = 0x34;
            this.errorProviderValidator1.SetDisplayName(this._UnosKreditaSmartPartUnpinnedTabAreaBottom, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this._UnosKreditaSmartPartUnpinnedTabAreaBottom.Dock = DockStyle.Bottom;
            this._UnosKreditaSmartPartUnpinnedTabAreaBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0x2ad);
            this._UnosKreditaSmartPartUnpinnedTabAreaBottom.Location = point;
            this._UnosKreditaSmartPartUnpinnedTabAreaBottom.Name = "_UnosKreditaSmartPartUnpinnedTabAreaBottom";
            this._UnosKreditaSmartPartUnpinnedTabAreaBottom.Owner = this.UltraDockManager1;
            this.errorProviderValidator1.SetRegularExpression(this._UnosKreditaSmartPartUnpinnedTabAreaBottom, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this._UnosKreditaSmartPartUnpinnedTabAreaBottom, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this._UnosKreditaSmartPartUnpinnedTabAreaBottom, false);
            this.errorProviderValidator1.SetRequiredMessage(this._UnosKreditaSmartPartUnpinnedTabAreaBottom, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x48a, 0);
            this._UnosKreditaSmartPartUnpinnedTabAreaBottom.Size = size;
            this._UnosKreditaSmartPartUnpinnedTabAreaBottom.TabIndex = 0x35;
            this.errorProviderValidator1.SetDisplayName(this._UnosKreditaSmartPartAutoHideControl, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this._UnosKreditaSmartPartAutoHideControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this._UnosKreditaSmartPartAutoHideControl.Location = point;
            this._UnosKreditaSmartPartAutoHideControl.Name = "_UnosKreditaSmartPartAutoHideControl";
            this._UnosKreditaSmartPartAutoHideControl.Owner = this.UltraDockManager1;
            this.errorProviderValidator1.SetRegularExpression(this._UnosKreditaSmartPartAutoHideControl, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this._UnosKreditaSmartPartAutoHideControl, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this._UnosKreditaSmartPartAutoHideControl, false);
            this.errorProviderValidator1.SetRequiredMessage(this._UnosKreditaSmartPartAutoHideControl, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0, 0x2ad);
            this._UnosKreditaSmartPartAutoHideControl.Size = size;
            this._UnosKreditaSmartPartAutoHideControl.TabIndex = 0x36;
            this.WindowDockingArea1.Controls.Add(this.DockableWindow1);
            this.errorProviderValidator1.SetDisplayName(this.WindowDockingArea1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.WindowDockingArea1.Dock = DockStyle.Top;
            this.WindowDockingArea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0);
            this.WindowDockingArea1.Location = point;
            this.WindowDockingArea1.Name = "WindowDockingArea1";
            this.WindowDockingArea1.Owner = this.UltraDockManager1;
            this.errorProviderValidator1.SetRegularExpression(this.WindowDockingArea1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.WindowDockingArea1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.WindowDockingArea1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.WindowDockingArea1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x48a, 0x90);
            this.WindowDockingArea1.Size = size;
            this.WindowDockingArea1.TabIndex = 0x38;
            this.DockableWindow1.Controls.Add(this.GroupBox1);
            this.errorProviderValidator1.SetDisplayName(this.DockableWindow1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(0, 0);
            this.DockableWindow1.Location = point;
            this.DockableWindow1.Name = "DockableWindow1";
            this.DockableWindow1.Owner = this.UltraDockManager1;
            this.errorProviderValidator1.SetRegularExpression(this.DockableWindow1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.DockableWindow1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.DockableWindow1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.DockableWindow1, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x48a, 0x8b);
            this.DockableWindow1.Size = size;
            this.DockableWindow1.TabIndex = 0x3d;
            this.WindowDockingArea3.Controls.Add(this.DockableWindow3);
            this.errorProviderValidator1.SetDisplayName(this.WindowDockingArea3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.WindowDockingArea3.Dock = DockStyle.Left;
            this.WindowDockingArea3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0, 0x90);
            this.WindowDockingArea3.Location = point;
            this.WindowDockingArea3.Name = "WindowDockingArea3";
            this.WindowDockingArea3.Owner = this.UltraDockManager1;
            this.errorProviderValidator1.SetRegularExpression(this.WindowDockingArea3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.WindowDockingArea3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.WindowDockingArea3, false);
            this.errorProviderValidator1.SetRequiredMessage(this.WindowDockingArea3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x26b, 0x21d);
            this.WindowDockingArea3.Size = size;
            this.WindowDockingArea3.TabIndex = 0x3b;
            this.DockableWindow3.Controls.Add(this.Panel2);
            this.errorProviderValidator1.SetDisplayName(this.DockableWindow3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(0, 0);
            this.DockableWindow3.Location = point;
            this.DockableWindow3.Name = "DockableWindow3";
            this.DockableWindow3.Owner = this.UltraDockManager1;
            this.errorProviderValidator1.SetRegularExpression(this.DockableWindow3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.DockableWindow3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.DockableWindow3, false);
            this.errorProviderValidator1.SetRequiredMessage(this.DockableWindow3, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x266, 0x21d);
            this.DockableWindow3.Size = size;
            this.DockableWindow3.TabIndex = 0x3e;
            this.WindowDockingArea2.Controls.Add(this.DockableWindow2);
            this.errorProviderValidator1.SetDisplayName(this.WindowDockingArea2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.WindowDockingArea2.Dock = DockStyle.Left;
            this.WindowDockingArea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            point = new System.Drawing.Point(0x26b, 0x90);
            this.WindowDockingArea2.Location = point;
            this.WindowDockingArea2.Name = "WindowDockingArea2";
            this.WindowDockingArea2.Owner = this.UltraDockManager1;
            this.errorProviderValidator1.SetRegularExpression(this.WindowDockingArea2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.WindowDockingArea2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.WindowDockingArea2, false);
            this.errorProviderValidator1.SetRequiredMessage(this.WindowDockingArea2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x21b, 0x21d);
            this.WindowDockingArea2.Size = size;
            this.WindowDockingArea2.TabIndex = 60;
            this.DockableWindow2.Controls.Add(this.Panel1);
            this.errorProviderValidator1.SetDisplayName(this.DockableWindow2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            point = new System.Drawing.Point(0, 0);
            this.DockableWindow2.Location = point;
            this.DockableWindow2.Name = "DockableWindow2";
            this.DockableWindow2.Owner = this.UltraDockManager1;
            this.errorProviderValidator1.SetRegularExpression(this.DockableWindow2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this.DockableWindow2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this.DockableWindow2, false);
            this.errorProviderValidator1.SetRequiredMessage(this.DockableWindow2, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x216, 0x21d);
            this.DockableWindow2.Size = size;
            this.DockableWindow2.TabIndex = 0x3f;
            this.Controls.Add(this._UnosKreditaSmartPartAutoHideControl);
            this.Controls.Add(this.WindowDockingArea2);
            this.Controls.Add(this.WindowDockingArea3);
            this.Controls.Add(this.WindowDockingArea1);
            this.Controls.Add(this._UnosKreditaSmartPartUnpinnedTabAreaTop);
            this.Controls.Add(this._UnosKreditaSmartPartUnpinnedTabAreaBottom);
            this.Controls.Add(this._UnosKreditaSmartPartUnpinnedTabAreaLeft);
            this.Controls.Add(this._UnosKreditaSmartPartUnpinnedTabAreaRight);
            this.errorProviderValidator1.SetDisplayName(this, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.Name = "UnosKreditaSmartPart";
            this.errorProviderValidator1.SetRegularExpression(this, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRegularExpressionMessage(this, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            this.errorProviderValidator1.SetRequired(this, false);
            this.errorProviderValidator1.SetRequiredMessage(this, StringResources.OBRACUNELEMENTRAZDOBLJEODDescription);
            size = new System.Drawing.Size(0x48a, 0x2ad);
            this.Size = size;
            this.GroupBox1.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            ((ISupportInitialize) this.UltraGrid2).EndInit();
            this.PregledRadnikaDataset2.EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.layoutManagerformOBRACUNKrediti.ResumeLayout(false);
            this.layoutManagerformOBRACUNKrediti.PerformLayout();
            ((ISupportInitialize) this.textIDKREDITOR).EndInit();
            ((ISupportInitialize) this.bindingSourceOBRACUNKrediti).EndInit();
            this.dsOBRACUNDataSet1.EndInit();
            ((ISupportInitialize) this.datePickerDatumUgovora).EndInit();
            ((ISupportInitialize) this.textOBRSIFRAOPISAPLACANJAKREDITOR).EndInit();
            ((ISupportInitialize) this.textOBROPISPLACANJAKREDITOR).EndInit();
            ((ISupportInitialize) this.textOBRMOKREDITOR).EndInit();
            ((ISupportInitialize) this.textOBRPOKREDITOR).EndInit();
            ((ISupportInitialize) this.textOBRMZKREDITOR).EndInit();
            ((ISupportInitialize) this.textOBRPZKREDITOR).EndInit();
            ((ISupportInitialize) this.textOBRIZNOSRATEKREDITOR).EndInit();
            ((ISupportInitialize) this.textUKUPNIZNOSKREDITA).EndInit();
            ((ISupportInitialize) this.errorProvider1).EndInit();
            ((ISupportInitialize) this.UltraDockManager1).EndInit();
            this.WindowDockingArea1.ResumeLayout(false);
            this.DockableWindow1.ResumeLayout(false);
            this.WindowDockingArea3.ResumeLayout(false);
            this.DockableWindow3.ResumeLayout(false);
            this.WindowDockingArea2.ResumeLayout(false);
            this.DockableWindow2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void Localize()
        {
            this.label1IDKREDITOR.Text = "Šifra";
            this.label1DatumUgovora.Text = "Datum ugovora";
            this.label1NAZIVKREDITOR.Text = "Kreditor";
            this.label1VBDIKREDITOR.Text = "VBDI kreditor";
            this.label1ZRNKREDITOR.Text = "ŽRN kreditor";
            this.label1PRIMATELJKREDITOR1.Text = "Primatelj (1)";
            this.label1PRIMATELJKREDITOR2.Text = "Primatelj (2)";
            this.label1PRIMATELJKREDITOR3.Text = "Primatelj (3)";
            this.label1OBRSIFRAOPISAPLACANJAKREDITOR.Text = "Šifra opisa plaćanja";
            this.label1OBROPISPLACANJAKREDITOR.Text = "Opis plaćanja";
            this.label1OBRMOKREDITOR.Text = "Model odobrenja";
            this.label1OBRPOKREDITOR.Text = "Poziv na broj odobrenja";
            this.label1OBRMZKREDITOR.Text = "Model zaduženja";
            this.label1OBRPZKREDITOR.Text = "Poziv na broj zaduženja";
            this.label1OBRIZNOSRATEKREDITOR.Text = "Iznos rate";
            this.UltraLabel1.Text = "Ukupni iznos";
        }

        private void Parametri_OznaciSve()
        {
            int num2 = this.UltraGrid2.Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                if (this.chkAktivni.Checked)
                {
                    if (Operators.ConditionalCompareObjectEqual(this.UltraGrid2.Rows[i].Cells["aktivan"].Value, true, false))
                    {
                        this.UltraGrid2.Rows[i].Cells["oznacen"].Value = true;
                    }
                }
                else
                {
                    this.UltraGrid2.Rows[i].Cells["oznacen"].Value = true;
                }
            }
            this.UltraDockManager1.ControlPanes[1].Text = "Odabrano: " + Conversions.ToString(this.BrojOznacenihRadnika()) + " zaposlenika";
        }

        private void Parametri_PrikaziSamoAktivne()
        {
            this.UltraGrid2.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
            this.UltraGrid2.DisplayLayout.Bands[0].ColumnFilters["aktivan"].FilterConditions.Add(FilterComparisionOperator.Equals, 1);
        }

        private void Parametri_PrikaziSve()
        {
            this.UltraGrid2.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void Parametri_SkiniOznakeSvima()
        {
            int num2 = this.UltraGrid2.Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                this.UltraGrid2.Rows[i].Cells["oznacen"].Value = false;
            }
            this.UltraDockManager1.ControlPanes[1].Text = "Odabrano: " + Conversions.ToString(this.BrojOznacenihRadnika()) + " zaposlenika";
        }

        private void textIDKREDITOR_EditorButtonClick(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.OBRACUNController.SelectKREDITORIDKREDITOR(fillMethod, fillByRow);
            this.UpdateValuesKREDITORIDKREDITOR(result);
            this.textUKUPNIZNOSKREDITA.Value = 0;
            this.textOBRIZNOSRATEKREDITOR.Value = 0;
        }

        private void textIDKREDITOR_ValueChanged(object sender, EventArgs e)
        {
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            this.Parametri_OznaciSve();
        }

        private void UltraButton2_Click(object sender, EventArgs e)
        {
            this.Parametri_SkiniOznakeSvima();
        }

        private void UltraButton3_Click(object sender, EventArgs e)
        {
            int num = 0;
            RADNIKDataSet dataSet = new RADNIKDataSet();
            RADNIKDataAdapter adapter = new RADNIKDataAdapter();
            adapter.Fill(dataSet);
            int num3 = this.UltraGrid2.Rows.Count - 1;
            for (int i = 0; i <= num3; i++)
            {
                if (Operators.ConditionalCompareObjectEqual(this.UltraGrid2.Rows[i].Cells["oznacen"].Value, true, false))
                {
                    DataRow row = dataSet.RADNIKKrediti.NewRow();
                    row["idradnik"] = RuntimeHelpers.GetObjectValue(this.UltraGrid2.Rows[i].Cells["idradnik"].Value);
                    row["zadkreditiidkreditor"] = RuntimeHelpers.GetObjectValue(this.textIDKREDITOR.Value);
                    row["datumugovora"] = RuntimeHelpers.GetObjectValue(this.datePickerDatumUgovora.Value);
                    row["kreditaktivan"] = true;
                    row["sifraopisaplacanjakreditor"] = RuntimeHelpers.GetObjectValue(this.textOBRSIFRAOPISAPLACANJAKREDITOR.Value);
                    row["opisplacanjakreditor"] = RuntimeHelpers.GetObjectValue(this.textOBROPISPLACANJAKREDITOR.Value);
                    row["mokreditor"] = RuntimeHelpers.GetObjectValue(this.textOBRMOKREDITOR.Value);
                    row["pokreditor"] = RuntimeHelpers.GetObjectValue(this.textOBRPOKREDITOR.Value);
                    row["mzkreditor"] = RuntimeHelpers.GetObjectValue(this.textOBRMZKREDITOR.Value);
                    row["pzkreditor"] = RuntimeHelpers.GetObjectValue(this.textOBRPZKREDITOR.Value);
                    row["zadiznosratekredita"] = RuntimeHelpers.GetObjectValue(this.textOBRIZNOSRATEKREDITOR.Value);
                    row["zadbrojrataobustave"] = 0;
                    row["zadukupniznoskredita"] = RuntimeHelpers.GetObjectValue(this.textUKUPNIZNOSKREDITA.Value);
                    row["zadvecotplacenobrojrata"] = 0;
                    row["zadvecotplacenoukupniiznos"] = 0;
                    dataSet.RADNIKKrediti.Rows.Add(row);
                    try
                    {
                        adapter.Update(dataSet);
                        num++;
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;
                    }
                }
            }
            if (num > 0)
            {
                Interaction.MsgBox("Broj zaposlenika kojima je zadužen kredit: " + Conversions.ToString(num), MsgBoxStyle.OkOnly, null);
            }
            else
            {
                Interaction.MsgBox("Zaduživanje kredita nije uspjelo!", MsgBoxStyle.OkOnly, null);
            }
        }

        private void UltraGrid2_MouseDown(object sender, MouseEventArgs e)
        {
            this.UltraGrid2.ActiveRow = null;
            if (e.Button == MouseButtons.Left)
            {
                UltraGridRow context = null;
                context = (UltraGridRow) this.UltraGrid2.DisplayLayout.UIElement.ElementFromPoint(e.Location).GetContext(typeof(UltraGridRow));
                if ((context != null) && context.IsDataRow)
                {
                    context.Selected = true;
                    context.Cells["oznacen"].Value = Operators.NotObject(context.Cells["oznacen"].Value);
                }
            }
            this.UltraDockManager1.ControlPanes[1].Text = "Odabrano: " + Conversions.ToString(this.BrojOznacenihRadnika()) + " zaposlenika";
        }

        private void UnosKreditaSmartPart_Load(object sender, EventArgs e)
        {
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            new PregledRadnikaSvihDataAdapter().Fill(this.PregledRadnikaDataset2);
            this.UltraDockManager1.ControlPanes[0].Text = "...";
            this.UltraDockManager1.ControlPanes[1].Text = "";
            this.UltraDockManager1.ControlPanes[2].Text = "Podaci o kreditu koji se zadužuje";
            this.GroupBox1.Text = "";
            this.Localize();
            this.datePickerDatumUgovora.Value = DateTime.Today;
        }

        private void UpdateValuesKREDITORIDKREDITOR(DataRow result)
        {
            if (result != null)
            {
                this.textIDKREDITOR.Value = RuntimeHelpers.GetObjectValue(result["IDKREDITOR"]);
                this.labelNAZIVKREDITOR.Text = Conversions.ToString(result["NAZIVKREDITOR"]);
                this.labelVBDIKREDITOR.Text = Conversions.ToString(result["VBDIKREDITOR"]);
                this.labelZRNKREDITOR.Text = Conversions.ToString(result["ZRNKREDITOR"]);
                this.labelPRIMATELJKREDITOR1.Text = Conversions.ToString(result["PRIMATELJKREDITOR1"]);
                this.labelPRIMATELJKREDITOR2.Text = DB.FixNull(RuntimeHelpers.GetObjectValue(result["PRIMATELJKREDITOR2"]));
                this.labelPRIMATELJKREDITOR3.Text = DB.FixNull(RuntimeHelpers.GetObjectValue(result["PRIMATELJKREDITOR3"]));
            }
        }

        internal AutoHideControl _UnosKreditaSmartPartAutoHideControl
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__UnosKreditaSmartPartAutoHideControl;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__UnosKreditaSmartPartAutoHideControl = value;
            }
        }

        internal UnpinnedTabArea _UnosKreditaSmartPartUnpinnedTabAreaBottom
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__UnosKreditaSmartPartUnpinnedTabAreaBottom;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__UnosKreditaSmartPartUnpinnedTabAreaBottom = value;
            }
        }

        internal UnpinnedTabArea _UnosKreditaSmartPartUnpinnedTabAreaLeft
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__UnosKreditaSmartPartUnpinnedTabAreaLeft;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__UnosKreditaSmartPartUnpinnedTabAreaLeft = value;
            }
        }

        internal UnpinnedTabArea _UnosKreditaSmartPartUnpinnedTabAreaRight
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__UnosKreditaSmartPartUnpinnedTabAreaRight;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__UnosKreditaSmartPartUnpinnedTabAreaRight = value;
            }
        }

        internal UnpinnedTabArea _UnosKreditaSmartPartUnpinnedTabAreaTop
        {
            [DebuggerNonUserCode]
            get
            {
                return this.__UnosKreditaSmartPartUnpinnedTabAreaTop;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this.__UnosKreditaSmartPartUnpinnedTabAreaTop = value;
            }
        }

        private BindingSource bindingSourceOBRACUNKrediti
        {
            [DebuggerNonUserCode]
            get
            {
                return this._bindingSourceOBRACUNKrediti;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._bindingSourceOBRACUNKrediti = value;
            }
        }

        internal UltraCheckEditor chkAktivni
        {
            [DebuggerNonUserCode]
            get
            {
                return this._chkAktivni;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.chkAktivni_CheckedChanged);
                if (this._chkAktivni != null)
                {
                    this._chkAktivni.CheckedChanged -= handler;
                }
                this._chkAktivni = value;
                if (this._chkAktivni != null)
                {
                    this._chkAktivni.CheckedChanged += handler;
                }
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

        protected virtual UltraDateTimeEditor datePickerDatumUgovora
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDatumUgovora;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDatumUgovora = value;
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.FillByRow
        {
            set
            {
            }
        }

        string Deklarit.Practices.CompositeUI.IFilteredView.FillMethod
        {
            set
            {
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode Deklarit.Practices.CompositeUI.IFilteredView.WorkWithMode
        {
            set
            {
            }
        }

        internal DockableWindow DockableWindow1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._DockableWindow1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._DockableWindow1 = value;
            }
        }

        internal DockableWindow DockableWindow2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._DockableWindow2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._DockableWindow2 = value;
            }
        }

        internal DockableWindow DockableWindow3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._DockableWindow3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._DockableWindow3 = value;
            }
        }

        private OBRACUNDataSet dsOBRACUNDataSet1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._dsOBRACUNDataSet1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._dsOBRACUNDataSet1 = value;
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

        public DataRow FillByRow
        {
            set
            {
            }
        }

        public string FillMethod
        {
            set
            {
            }
        }

        internal GroupBox GroupBox1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._GroupBox1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._GroupBox1 = value;
            }
        }

        protected virtual UltraLabel label1DatumUgovora
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DatumUgovora;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DatumUgovora = value;
            }
        }

        protected virtual UltraLabel label1IDKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1NAZIVKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1OBRIZNOSRATEKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRIZNOSRATEKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRIZNOSRATEKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1OBRMOKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRMOKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRMOKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1OBRMZKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRMZKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRMZKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1OBROPISPLACANJAKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBROPISPLACANJAKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBROPISPLACANJAKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1OBRPOKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRPOKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRPOKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1OBRPZKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRPZKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRPZKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1OBRSIFRAOPISAPLACANJAKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OBRSIFRAOPISAPLACANJAKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OBRSIFRAOPISAPLACANJAKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJKREDITOR1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJKREDITOR1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJKREDITOR1 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJKREDITOR2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJKREDITOR2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJKREDITOR2 = value;
            }
        }

        protected virtual UltraLabel label1PRIMATELJKREDITOR3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRIMATELJKREDITOR3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRIMATELJKREDITOR3 = value;
            }
        }

        protected virtual UltraLabel label1VBDIKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VBDIKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VBDIKREDITOR = value;
            }
        }

        protected virtual UltraLabel label1ZRNKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZRNKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZRNKREDITOR = value;
            }
        }

        protected virtual UltraLabel labelNAZIVKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVKREDITOR = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJKREDITOR1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJKREDITOR1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJKREDITOR1 = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJKREDITOR2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJKREDITOR2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJKREDITOR2 = value;
            }
        }

        protected virtual UltraLabel labelPRIMATELJKREDITOR3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPRIMATELJKREDITOR3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPRIMATELJKREDITOR3 = value;
            }
        }

        protected virtual UltraLabel labelVBDIKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelVBDIKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelVBDIKREDITOR = value;
            }
        }

        protected virtual UltraLabel labelZRNKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelZRNKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelZRNKREDITOR = value;
            }
        }

        protected virtual TableLayoutPanel layoutManagerformOBRACUNKrediti
        {
            [DebuggerNonUserCode]
            get
            {
                return this._layoutManagerformOBRACUNKrediti;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._layoutManagerformOBRACUNKrediti = value;
            }
        }

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.OBRACUNController OBRACUNController { get; set; }

        private Panel Panel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Panel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Panel1 = value;
            }
        }

        private Panel Panel2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Panel2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Panel2 = value;
            }
        }

        internal PregledRadnikaSvihDataSet PregledRadnikaDataset2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._PregledRadnikaDataset2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._PregledRadnikaDataset2 = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
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

        protected virtual UltraNumericEditor textIDKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.textIDKREDITOR_ValueChanged);
                EditorButtonEventHandler handler2 = new EditorButtonEventHandler(this.textIDKREDITOR_EditorButtonClick);
                if (this._textIDKREDITOR != null)
                {
                    this._textIDKREDITOR.ValueChanged -= handler;
                    this._textIDKREDITOR.EditorButtonClick -= handler2;
                }
                this._textIDKREDITOR = value;
                if (this._textIDKREDITOR != null)
                {
                    this._textIDKREDITOR.ValueChanged += handler;
                    this._textIDKREDITOR.EditorButtonClick += handler2;
                }
            }
        }

        protected virtual UltraNumericEditor textOBRIZNOSRATEKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRIZNOSRATEKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRIZNOSRATEKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textOBRMOKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRMOKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRMOKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textOBRMZKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRMZKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRMZKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textOBROPISPLACANJAKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBROPISPLACANJAKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBROPISPLACANJAKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textOBRPOKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRPOKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRPOKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textOBRPZKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRPZKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRPZKREDITOR = value;
            }
        }

        protected virtual UltraTextEditor textOBRSIFRAOPISAPLACANJAKREDITOR
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOBRSIFRAOPISAPLACANJAKREDITOR;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOBRSIFRAOPISAPLACANJAKREDITOR = value;
            }
        }

        protected virtual UltraNumericEditor textUKUPNIZNOSKREDITA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textUKUPNIZNOSKREDITA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textUKUPNIZNOSKREDITA = value;
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

        private UltraButton UltraButton1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraButton1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.UltraButton1_Click);
                if (this._UltraButton1 != null)
                {
                    this._UltraButton1.Click -= handler;
                }
                this._UltraButton1 = value;
                if (this._UltraButton1 != null)
                {
                    this._UltraButton1.Click += handler;
                }
            }
        }

        private UltraButton UltraButton2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraButton2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.UltraButton2_Click);
                if (this._UltraButton2 != null)
                {
                    this._UltraButton2.Click -= handler;
                }
                this._UltraButton2 = value;
                if (this._UltraButton2 != null)
                {
                    this._UltraButton2.Click += handler;
                }
            }
        }

        private UltraButton UltraButton3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraButton3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.UltraButton3_Click);
                if (this._UltraButton3 != null)
                {
                    this._UltraButton3.Click -= handler;
                }
                this._UltraButton3 = value;
                if (this._UltraButton3 != null)
                {
                    this._UltraButton3.Click += handler;
                }
            }
        }

        private UltraDockManager UltraDockManager1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraDockManager1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraDockManager1 = value;
            }
        }

        private UltraGrid UltraGrid2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraGrid2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                MouseEventHandler handler = new MouseEventHandler(this.UltraGrid2_MouseDown);
                if (this._UltraGrid2 != null)
                {
                    this._UltraGrid2.MouseDown -= handler;
                }
                this._UltraGrid2 = value;
                if (this._UltraGrid2 != null)
                {
                    this._UltraGrid2.MouseDown += handler;
                }
            }
        }

        protected virtual UltraLabel UltraLabel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._UltraLabel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._UltraLabel1 = value;
            }
        }

        internal WindowDockingArea WindowDockingArea1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._WindowDockingArea1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._WindowDockingArea1 = value;
            }
        }

        internal WindowDockingArea WindowDockingArea2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._WindowDockingArea2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._WindowDockingArea2 = value;
            }
        }

        internal WindowDockingArea WindowDockingArea3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._WindowDockingArea3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._WindowDockingArea3 = value;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }
    }
}

