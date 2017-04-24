namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Deklarit.WinHelper;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinTabControl;
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
    public class DDRADNIKFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("checkDDDRUGISTUP")]
        private UltraCheckEditor _checkDDDRUGISTUP;
        [AccessedThroughProperty("checkDDPDVOBVEZNIK")]
        private UltraCheckEditor _checkDDPDVOBVEZNIK;
        [AccessedThroughProperty("checkDDZBIRNINETO")]
        private UltraCheckEditor _checkDDZBIRNINETO;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;

        [AccessedThroughProperty("cbkAktivan")]
        private UltraCheckEditor _cbkAktivan;

        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("label1DDADRESA")]
        private UltraLabel _label1DDADRESA;
        [AccessedThroughProperty("label1DDDRUGISTUP")]
        private UltraLabel _label1DDDRUGISTUP;
        [AccessedThroughProperty("label1DDIDRADNIK")]
        private UltraLabel _label1DDIDRADNIK;
        [AccessedThroughProperty("label1DDIME")]
        private UltraLabel _label1DDIME;
        [AccessedThroughProperty("label1DDJMBG")]
        private UltraLabel _label1DDJMBG;
        [AccessedThroughProperty("label1DDKUCNIBROJ")]
        private UltraLabel _label1DDKUCNIBROJ;
        [AccessedThroughProperty("label1DDMJESTO")]
        private UltraLabel _label1DDMJESTO;
        [AccessedThroughProperty("label1DDMO")]
        private UltraLabel _label1DDMO;
        [AccessedThroughProperty("label1DDOIB")]
        private UltraLabel _label1DDOIB;
        [AccessedThroughProperty("label1DDOPISPLACANJANETO")]
        private UltraLabel _label1DDOPISPLACANJANETO;
        [AccessedThroughProperty("label1DDPBO")]
        private UltraLabel _label1DDPBO;
        [AccessedThroughProperty("label1DDPDVOBVEZNIK")]
        private UltraLabel _label1DDPDVOBVEZNIK;
        [AccessedThroughProperty("label1DDPREZIME")]
        private UltraLabel _label1DDPREZIME;
        [AccessedThroughProperty("label1DDSIFRAOPISAPLACANJANETO")]
        private UltraLabel _label1DDSIFRAOPISAPLACANJANETO;
        [AccessedThroughProperty("label1DDZBIRNINETO")]
        private UltraLabel _label1DDZBIRNINETO;
        [AccessedThroughProperty("label1DDZRN")]
        private UltraLabel _label1DDZRN;
        [AccessedThroughProperty("label1IDBANKE")]
        private UltraLabel _label1IDBANKE;

        [AccessedThroughProperty("lblAktivan")]
        private UltraLabel _lblAktivan;

        [AccessedThroughProperty("label1NAZIVBANKE1")]
        private UltraLabel _label1NAZIVBANKE1;
        [AccessedThroughProperty("label1OPCINARADAIDOPCINE")]
        private UltraLabel _label1OPCINARADAIDOPCINE;
        [AccessedThroughProperty("label1OPCINARADANAZIVOPCINE")]
        private UltraLabel _label1OPCINARADANAZIVOPCINE;
        [AccessedThroughProperty("label1OPCINASTANOVANJAIDOPCINE")]
        private UltraLabel _label1OPCINASTANOVANJAIDOPCINE;
        [AccessedThroughProperty("label1OPCINASTANOVANJANAZIVOPCINE")]
        private UltraLabel _label1OPCINASTANOVANJANAZIVOPCINE;
        [AccessedThroughProperty("label1OPCINASTANOVANJAPRIREZ")]
        private UltraLabel _label1OPCINASTANOVANJAPRIREZ;
        [AccessedThroughProperty("labelNAZIVBANKE1")]
        private UltraLabel _labelNAZIVBANKE1;
        [AccessedThroughProperty("labelOPCINARADANAZIVOPCINE")]
        private UltraLabel _labelOPCINARADANAZIVOPCINE;
        [AccessedThroughProperty("labelOPCINASTANOVANJANAZIVOPCINE")]
        private UltraLabel _labelOPCINASTANOVANJANAZIVOPCINE;
        [AccessedThroughProperty("labelOPCINASTANOVANJAPRIREZ")]
        private UltraLabel _labelOPCINASTANOVANJAPRIREZ;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("Tab1")]
        private UltraTabControl _Tab1;
        [AccessedThroughProperty("TabPage1")]
        private UltraTabPageControl _TabPage1;
        [AccessedThroughProperty("TabPage2")]
        private UltraTabPageControl _TabPage2;
        [AccessedThroughProperty("TabPage3")]
        private UltraTabPageControl _TabPage3;
        [AccessedThroughProperty("textDDADRESA")]
        private UltraTextEditor _textDDADRESA;
        [AccessedThroughProperty("textDDIDRADNIK")]
        private UltraNumericEditor _textDDIDRADNIK;
        [AccessedThroughProperty("textDDIME")]
        private UltraTextEditor _textDDIME;
        [AccessedThroughProperty("textDDJMBG")]
        private UltraTextEditor _textDDJMBG;
        [AccessedThroughProperty("textDDKUCNIBROJ")]
        private UltraTextEditor _textDDKUCNIBROJ;
        [AccessedThroughProperty("textDDMJESTO")]
        private UltraTextEditor _textDDMJESTO;
        [AccessedThroughProperty("textDDMO")]
        private UltraTextEditor _textDDMO;
        [AccessedThroughProperty("textDDOIB")]
        private UltraTextEditor _textDDOIB;
        [AccessedThroughProperty("textDDOPISPLACANJANETO")]
        private UltraTextEditor _textDDOPISPLACANJANETO;
        [AccessedThroughProperty("textDDPBO")]
        private UltraTextEditor _textDDPBO;
        [AccessedThroughProperty("textDDPREZIME")]
        private UltraTextEditor _textDDPREZIME;
        [AccessedThroughProperty("textDDSIFRAOPISAPLACANJANETO")]
        private UltraTextEditor _textDDSIFRAOPISAPLACANJANETO;
        [AccessedThroughProperty("textDDZRN")]
        private UltraTextEditor _textDDZRN;
        [AccessedThroughProperty("textIDBANKE")]
        private UltraNumericEditor _textIDBANKE;
        [AccessedThroughProperty("textOPCINARADAIDOPCINE")]
        private UltraTextEditor _textOPCINARADAIDOPCINE;
        [AccessedThroughProperty("textOPCINASTANOVANJAIDOPCINE")]
        private UltraTextEditor _textOPCINASTANOVANJAIDOPCINE;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceDDRADNIK;
        private IContainer components = null;
        private DDRADNIKDataSet dsDDRADNIKDataSet1;
        protected TableLayoutPanel layoutManagerformDDRADNIK;
        protected TableLayoutPanel layoutManagerTabPage1;
        protected TableLayoutPanel layoutManagerTabPage2;
        protected TableLayoutPanel layoutManagerTabPage3;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private DDRADNIKDataSet.DDRADNIKRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "DDRADNIK";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.DDRADNIKDescription;
        private DeklaritMode m_Mode;

        public DDRADNIKFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptBANKEIDBANKE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.DDRADNIKController.SelectBANKEIDBANKE(fillMethod, fillByRow);
            this.UpdateValuesBANKEIDBANKE(result);
        }

        private void CallPromptOPCINAOPCINARADAIDOPCINE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.DDRADNIKController.SelectOPCINAOPCINARADAIDOPCINE(fillMethod, fillByRow);
            this.UpdateValuesOPCINAOPCINARADAIDOPCINE(result);
        }

        private void CallPromptOPCINAOPCINASTANOVANJAIDOPCINE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.DDRADNIKController.SelectOPCINAOPCINASTANOVANJAIDOPCINE(fillMethod, fillByRow);
            this.UpdateValuesOPCINAOPCINASTANOVANJAIDOPCINE(result);
        }

        private void CallViewBANKEIDBANKE(object sender, EventArgs e)
        {
            DataRow result = this.DDRADNIKController.ShowBANKEIDBANKE(this.m_CurrentRow);
            this.UpdateValuesBANKEIDBANKE(result);
        }

        private void CallViewOPCINAOPCINARADAIDOPCINE(object sender, EventArgs e)
        {
            DataRow result = this.DDRADNIKController.ShowOPCINAOPCINARADAIDOPCINE(this.m_CurrentRow);
            this.UpdateValuesOPCINAOPCINARADAIDOPCINE(result);
        }

        private void CallViewOPCINAOPCINASTANOVANJAIDOPCINE(object sender, EventArgs e)
        {
            DataRow result = this.DDRADNIKController.ShowOPCINAOPCINASTANOVANJAIDOPCINE(this.m_CurrentRow);
            this.UpdateValuesOPCINAOPCINASTANOVANJAIDOPCINE(result);
        }

        public void ChangeBinding()
        {
            this.bindingSourceDDRADNIK.DataSource = this.DDRADNIKController.DataSet;
            this.dsDDRADNIKDataSet1 = this.DDRADNIKController.DataSet;
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

        private void DDRADNIKFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.DDRADNIKDescription;
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
                    enumerator = this.dsDDRADNIKDataSet1.DDRADNIK.Rows.GetEnumerator();
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
                if (this.DDRADNIKController.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "DDRADNIK", this.m_Mode, this.dsDDRADNIKDataSet1, this.dsDDRADNIKDataSet1.DDRADNIK.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding4 = new Binding("Text", this.bindingSourceDDRADNIK, "OPCINASTANOVANJAPRIREZ", true);
            binding4.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelOPCINASTANOVANJAPRIREZ.DataBindings["Text"] != null)
            {
                this.labelOPCINASTANOVANJAPRIREZ.DataBindings.Remove(this.labelOPCINASTANOVANJAPRIREZ.DataBindings["Text"]);
            }
            this.labelOPCINASTANOVANJAPRIREZ.DataBindings.Add(binding4);
            Binding binding2 = new Binding("CheckState", this.bindingSourceDDRADNIK, "DDPDVOBVEZNIK", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding2.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkDDPDVOBVEZNIK.DataBindings["CheckState"] != null)
            {
                this.checkDDPDVOBVEZNIK.DataBindings.Remove(this.checkDDPDVOBVEZNIK.DataBindings["CheckState"]);
            }
            this.checkDDPDVOBVEZNIK.DataBindings.Add(binding2);

            Binding binding22 = new Binding("CheckState", this.bindingSourceDDRADNIK, "Aktivan", true);
            binding22.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding22.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.cbkAktivan.DataBindings["CheckState"] != null)
            {
                this.cbkAktivan.DataBindings.Remove(this.cbkAktivan.DataBindings["CheckState"]);
            }
            this.cbkAktivan.DataBindings.Add(binding22);

            Binding binding = new Binding("CheckState", this.bindingSourceDDRADNIK, "DDDRUGISTUP", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkDDDRUGISTUP.DataBindings["CheckState"] != null)
            {
                this.checkDDDRUGISTUP.DataBindings.Remove(this.checkDDDRUGISTUP.DataBindings["CheckState"]);
            }
            this.checkDDDRUGISTUP.DataBindings.Add(binding);
            Binding binding3 = new Binding("CheckState", this.bindingSourceDDRADNIK, "DDZBIRNINETO", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding3.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkDDZBIRNINETO.DataBindings["CheckState"] != null)
            {
                this.checkDDZBIRNINETO.DataBindings.Remove(this.checkDDZBIRNINETO.DataBindings["CheckState"]);
            }
            this.checkDDZBIRNINETO.DataBindings.Add(binding3);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsDDRADNIKDataSet1.DDRADNIK[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (DDRADNIKDataSet.DDRADNIKRow) ((DataRowView) this.bindingSourceDDRADNIK.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(DDRADNIKFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceDDRADNIK = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDDRADNIK).BeginInit();
            this.layoutManagerformDDRADNIK = new TableLayoutPanel();
            this.layoutManagerformDDRADNIK.SuspendLayout();
            this.layoutManagerformDDRADNIK.AutoSize = true;
            this.layoutManagerformDDRADNIK.Dock = DockStyle.Fill;
            this.layoutManagerformDDRADNIK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformDDRADNIK.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformDDRADNIK.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformDDRADNIK.Size = size;
            this.layoutManagerformDDRADNIK.ColumnCount = 1;
            this.layoutManagerformDDRADNIK.RowCount = 1;
            this.layoutManagerformDDRADNIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDDRADNIK.RowStyles.Add(new RowStyle());
            this.Tab1 = new UltraTabControl();
            UltraTab tab = new UltraTab();
            this.TabPage1 = new UltraTabPageControl();
            this.layoutManagerTabPage1 = new TableLayoutPanel();
            this.layoutManagerTabPage1.AutoSize = true;
            this.layoutManagerTabPage1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage1.ColumnCount = 2;
            this.layoutManagerTabPage1.RowCount = 9;
            this.layoutManagerTabPage1.Dock = DockStyle.Fill;
            this.layoutManagerTabPage1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new RowStyle());
            Padding padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage1.Margin = padding;
            this.label1DDIDRADNIK = new UltraLabel();
            this.textDDIDRADNIK = new UltraNumericEditor();
            this.label1DDJMBG = new UltraLabel();
            this.textDDJMBG = new UltraTextEditor();
            this.label1DDOIB = new UltraLabel();
            this.textDDOIB = new UltraTextEditor();
            this.label1DDPREZIME = new UltraLabel();
            this.textDDPREZIME = new UltraTextEditor();
            this.label1DDIME = new UltraLabel();
            this.textDDIME = new UltraTextEditor();
            this.label1DDADRESA = new UltraLabel();
            this.textDDADRESA = new UltraTextEditor();
            this.label1DDKUCNIBROJ = new UltraLabel();
            lblAktivan = new UltraLabel();
            cbkAktivan = new UltraCheckEditor();
            this.textDDKUCNIBROJ = new UltraTextEditor();
            this.label1DDMJESTO = new UltraLabel();
            this.textDDMJESTO = new UltraTextEditor();
            UltraTab tab2 = new UltraTab();
            this.TabPage2 = new UltraTabPageControl();
            this.layoutManagerTabPage2 = new TableLayoutPanel();
            this.layoutManagerTabPage2.AutoSize = true;
            this.layoutManagerTabPage2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage2.ColumnCount = 2;
            this.layoutManagerTabPage2.RowCount = 9;
            this.layoutManagerTabPage2.Dock = DockStyle.Fill;
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage2.Margin = padding;
            this.label1DDZRN = new UltraLabel();
            this.textDDZRN = new UltraTextEditor();
            this.label1IDBANKE = new UltraLabel();
            this.textIDBANKE = new UltraNumericEditor();
            this.label1NAZIVBANKE1 = new UltraLabel();
            this.labelNAZIVBANKE1 = new UltraLabel();
            this.label1OPCINARADAIDOPCINE = new UltraLabel();
            this.textOPCINARADAIDOPCINE = new UltraTextEditor();
            this.label1OPCINARADANAZIVOPCINE = new UltraLabel();
            this.labelOPCINARADANAZIVOPCINE = new UltraLabel();
            this.label1OPCINASTANOVANJAIDOPCINE = new UltraLabel();
            this.textOPCINASTANOVANJAIDOPCINE = new UltraTextEditor();
            this.label1OPCINASTANOVANJANAZIVOPCINE = new UltraLabel();
            this.labelOPCINASTANOVANJANAZIVOPCINE = new UltraLabel();
            this.label1OPCINASTANOVANJAPRIREZ = new UltraLabel();
            this.labelOPCINASTANOVANJAPRIREZ = new UltraLabel();
            UltraTab tab3 = new UltraTab();
            this.TabPage3 = new UltraTabPageControl();
            this.layoutManagerTabPage3 = new TableLayoutPanel();
            this.layoutManagerTabPage3.AutoSize = true;
            this.layoutManagerTabPage3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage3.ColumnCount = 2;
            this.layoutManagerTabPage3.RowCount = 8;
            this.layoutManagerTabPage3.Dock = DockStyle.Fill;
            this.layoutManagerTabPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage3.Margin = padding;
            this.label1DDSIFRAOPISAPLACANJANETO = new UltraLabel();
            this.textDDSIFRAOPISAPLACANJANETO = new UltraTextEditor();
            this.label1DDOPISPLACANJANETO = new UltraLabel();
            this.textDDOPISPLACANJANETO = new UltraTextEditor();
            this.label1DDPDVOBVEZNIK = new UltraLabel();
            this.checkDDPDVOBVEZNIK = new UltraCheckEditor();
            this.label1DDDRUGISTUP = new UltraLabel();
            this.checkDDDRUGISTUP = new UltraCheckEditor();
            this.label1DDZBIRNINETO = new UltraLabel();
            this.checkDDZBIRNINETO = new UltraCheckEditor();
            this.label1DDMO = new UltraLabel();
            this.textDDMO = new UltraTextEditor();
            this.label1DDPBO = new UltraLabel();
            this.textDDPBO = new UltraTextEditor();
            this.Tab1.SuspendLayout();
            ((ISupportInitialize) this.Tab1).BeginInit();
            this.layoutManagerTabPage1.SuspendLayout();
            ((ISupportInitialize) this.textDDIDRADNIK).BeginInit();
            ((ISupportInitialize) this.textDDJMBG).BeginInit();
            ((ISupportInitialize) this.textDDOIB).BeginInit();
            ((ISupportInitialize) this.textDDPREZIME).BeginInit();
            ((ISupportInitialize) this.textDDIME).BeginInit();
            ((ISupportInitialize) this.textDDADRESA).BeginInit();
            ((ISupportInitialize) this.textDDKUCNIBROJ).BeginInit();
            ((ISupportInitialize) this.textDDMJESTO).BeginInit();
            this.layoutManagerTabPage2.SuspendLayout();
            ((ISupportInitialize) this.textDDZRN).BeginInit();
            ((ISupportInitialize) this.textIDBANKE).BeginInit();
            ((ISupportInitialize) this.textOPCINARADAIDOPCINE).BeginInit();
            ((ISupportInitialize) this.textOPCINASTANOVANJAIDOPCINE).BeginInit();
            this.layoutManagerTabPage3.SuspendLayout();
            ((ISupportInitialize) this.textDDSIFRAOPISAPLACANJANETO).BeginInit();
            ((ISupportInitialize) this.textDDOPISPLACANJANETO).BeginInit();
            ((ISupportInitialize) this.textDDMO).BeginInit();
            ((ISupportInitialize) this.textDDPBO).BeginInit();
            this.dsDDRADNIKDataSet1 = new DDRADNIKDataSet();
            this.dsDDRADNIKDataSet1.BeginInit();
            this.SuspendLayout();
            this.Tab1.Tabs.Add(tab);
            this.Tab1.Controls.Add(this.TabPage1);
            this.Tab1.Tabs.Add(tab2);
            this.Tab1.Controls.Add(this.TabPage2);
            this.Tab1.Tabs.Add(tab3);
            this.Tab1.Controls.Add(this.TabPage3);
            this.dsDDRADNIKDataSet1.DataSetName = "dsDDRADNIK";
            this.dsDDRADNIKDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceDDRADNIK.DataSource = this.dsDDRADNIKDataSet1;
            this.bindingSourceDDRADNIK.DataMember = "DDRADNIK";
            ((ISupportInitialize) this.bindingSourceDDRADNIK).BeginInit();
            point = new System.Drawing.Point(0, 0);
            this.Tab1.Location = point;
            this.Tab1.Name = "Tab1";
            this.layoutManagerformDDRADNIK.Controls.Add(this.Tab1, 0, 0);
            this.layoutManagerformDDRADNIK.SetColumnSpan(this.Tab1, 1);
            this.layoutManagerformDDRADNIK.SetRowSpan(this.Tab1, 1);
            padding = new Padding(5, 11, 5, 5);
            this.Tab1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.Tab1.MinimumSize = size;
            this.Tab1.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.TabPage1.Location = point;
            this.TabPage1.Name = "TabPage1";
            tab.TabPage = this.TabPage1;
            tab.Text = "Opći podaci";
            this.TabPage1.Controls.Add(this.layoutManagerTabPage1);
            point = new System.Drawing.Point(0, 0);
            this.label1DDIDRADNIK.Location = point;
            this.label1DDIDRADNIK.Name = "label1DDIDRADNIK";
            this.label1DDIDRADNIK.TabIndex = 1;
            this.label1DDIDRADNIK.Tag = "labelDDIDRADNIK";
            this.label1DDIDRADNIK.Text = "Šifra:";
            this.label1DDIDRADNIK.StyleSetName = "FieldUltraLabel";
            this.label1DDIDRADNIK.AutoSize = true;
            this.label1DDIDRADNIK.Anchor = AnchorStyles.Left;
            this.label1DDIDRADNIK.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDIDRADNIK.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1DDIDRADNIK.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1DDIDRADNIK.ImageSize = size;
            this.label1DDIDRADNIK.Appearance.ForeColor = Color.Black;
            this.label1DDIDRADNIK.BackColor = Color.Transparent;
            this.layoutManagerTabPage1.Controls.Add(this.label1DDIDRADNIK, 0, 0);
            this.layoutManagerTabPage1.SetColumnSpan(this.label1DDIDRADNIK, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.label1DDIDRADNIK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDIDRADNIK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDIDRADNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1DDIDRADNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDIDRADNIK.Location = point;
            this.textDDIDRADNIK.Name = "textDDIDRADNIK";
            this.textDDIDRADNIK.Tag = "DDIDRADNIK";
            this.textDDIDRADNIK.TabIndex = 0;
            this.textDDIDRADNIK.Anchor = AnchorStyles.Left;
            this.textDDIDRADNIK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDIDRADNIK.ReadOnly = false;
            this.textDDIDRADNIK.PromptChar = ' ';
            this.textDDIDRADNIK.Enter += new EventHandler(this.numericEditor_Enter);
            this.textDDIDRADNIK.DataBindings.Add(new Binding("Value", this.bindingSourceDDRADNIK, "DDIDRADNIK"));
            this.textDDIDRADNIK.NumericType = NumericType.Integer;
            this.textDDIDRADNIK.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerTabPage1.Controls.Add(this.textDDIDRADNIK, 1, 0);
            this.layoutManagerTabPage1.SetColumnSpan(this.textDDIDRADNIK, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.textDDIDRADNIK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDIDRADNIK.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textDDIDRADNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textDDIDRADNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDJMBG.Location = point;
            this.label1DDJMBG.Name = "label1DDJMBG";
            this.label1DDJMBG.TabIndex = 1;
            this.label1DDJMBG.Tag = "labelDDJMBG";
            this.label1DDJMBG.Text = "JMBG:";
            this.label1DDJMBG.StyleSetName = "FieldUltraLabel";
            this.label1DDJMBG.AutoSize = true;
            this.label1DDJMBG.Anchor = AnchorStyles.Left;
            this.label1DDJMBG.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDJMBG.Appearance.ForeColor = Color.Black;
            this.label1DDJMBG.BackColor = Color.Transparent;
            this.layoutManagerTabPage1.Controls.Add(this.label1DDJMBG, 0, 1);
            this.layoutManagerTabPage1.SetColumnSpan(this.label1DDJMBG, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.label1DDJMBG, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDJMBG.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDJMBG.MinimumSize = size;
            size = new System.Drawing.Size(0x36, 0x17);
            this.label1DDJMBG.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDJMBG.Location = point;
            this.textDDJMBG.Name = "textDDJMBG";
            this.textDDJMBG.Tag = "DDJMBG";
            textDDJMBG.Text = "00000000000";
            textDDJMBG.Visible = false;
            label1DDJMBG.Visible = false;
            this.textDDJMBG.TabIndex = 0;
            this.textDDJMBG.Anchor = AnchorStyles.Left;
            this.textDDJMBG.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDJMBG.ReadOnly = false;
            this.textDDJMBG.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "DDJMBG"));
            this.textDDJMBG.MaxLength = 13;
            this.layoutManagerTabPage1.Controls.Add(this.textDDJMBG, 1, 1);
            this.layoutManagerTabPage1.SetColumnSpan(this.textDDJMBG, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.textDDJMBG, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDJMBG.Margin = padding;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.textDDJMBG.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.textDDJMBG.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDOIB.Location = point;
            this.label1DDOIB.Name = "label1DDOIB";
            this.label1DDOIB.TabIndex = 1;
            this.label1DDOIB.Tag = "labelDDOIB";
            this.label1DDOIB.Text = "OIB:";
            this.label1DDOIB.StyleSetName = "FieldUltraLabel";
            this.label1DDOIB.AutoSize = true;
            this.label1DDOIB.Anchor = AnchorStyles.Left;
            this.label1DDOIB.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDOIB.Appearance.ForeColor = Color.Black;
            this.label1DDOIB.BackColor = Color.Transparent;
            this.layoutManagerTabPage1.Controls.Add(this.label1DDOIB, 0, 2);
            this.layoutManagerTabPage1.SetColumnSpan(this.label1DDOIB, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.label1DDOIB, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDOIB.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDOIB.MinimumSize = size;
            size = new System.Drawing.Size(0x2b, 0x17);
            this.label1DDOIB.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDOIB.Location = point;
            this.textDDOIB.Name = "textDDOIB";
            this.textDDOIB.Tag = "DDOIB";
            this.textDDOIB.TabIndex = 0;
            this.textDDOIB.Anchor = AnchorStyles.Left;
            this.textDDOIB.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDOIB.ReadOnly = false;
            this.textDDOIB.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "DDOIB"));
            this.textDDOIB.MaxLength = 11;
            this.layoutManagerTabPage1.Controls.Add(this.textDDOIB, 1, 2);
            this.layoutManagerTabPage1.SetColumnSpan(this.textDDOIB, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.textDDOIB, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDOIB.Margin = padding;
            size = new System.Drawing.Size(0x5d, 0x16);
            this.textDDOIB.MinimumSize = size;
            size = new System.Drawing.Size(0x5d, 0x16);
            this.textDDOIB.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDPREZIME.Location = point;
            this.label1DDPREZIME.Name = "label1DDPREZIME";
            this.label1DDPREZIME.TabIndex = 1;
            this.label1DDPREZIME.Tag = "labelDDPREZIME";
            this.label1DDPREZIME.Text = "Prezime:";
            this.label1DDPREZIME.StyleSetName = "FieldUltraLabel";
            this.label1DDPREZIME.AutoSize = true;
            this.label1DDPREZIME.Anchor = AnchorStyles.Left;
            this.label1DDPREZIME.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDPREZIME.Appearance.ForeColor = Color.Black;
            this.label1DDPREZIME.BackColor = Color.Transparent;
            this.layoutManagerTabPage1.Controls.Add(this.label1DDPREZIME, 0, 3);
            this.layoutManagerTabPage1.SetColumnSpan(this.label1DDPREZIME, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.label1DDPREZIME, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDPREZIME.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDPREZIME.MinimumSize = size;
            size = new System.Drawing.Size(0x45, 0x17);
            this.label1DDPREZIME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDPREZIME.Location = point;
            this.textDDPREZIME.Name = "textDDPREZIME";
            this.textDDPREZIME.Tag = "DDPREZIME";
            this.textDDPREZIME.TabIndex = 0;
            this.textDDPREZIME.Anchor = AnchorStyles.Left;
            this.textDDPREZIME.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDPREZIME.ReadOnly = false;
            this.textDDPREZIME.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "DDPREZIME"));
            this.textDDPREZIME.MaxLength = 50;
            this.layoutManagerTabPage1.Controls.Add(this.textDDPREZIME, 1, 3);
            this.layoutManagerTabPage1.SetColumnSpan(this.textDDPREZIME, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.textDDPREZIME, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDPREZIME.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textDDPREZIME.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textDDPREZIME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDIME.Location = point;
            this.label1DDIME.Name = "label1DDIME";
            this.label1DDIME.TabIndex = 1;
            this.label1DDIME.Tag = "labelDDIME";
            this.label1DDIME.Text = "Ime:";
            this.label1DDIME.StyleSetName = "FieldUltraLabel";
            this.label1DDIME.AutoSize = true;
            this.label1DDIME.Anchor = AnchorStyles.Left;
            this.label1DDIME.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDIME.Appearance.ForeColor = Color.Black;
            this.label1DDIME.BackColor = Color.Transparent;
            this.layoutManagerTabPage1.Controls.Add(this.label1DDIME, 0, 4);
            this.layoutManagerTabPage1.SetColumnSpan(this.label1DDIME, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.label1DDIME, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDIME.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDIME.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x17);
            this.label1DDIME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDIME.Location = point;
            this.textDDIME.Name = "textDDIME";
            this.textDDIME.Tag = "DDIME";
            this.textDDIME.TabIndex = 0;
            this.textDDIME.Anchor = AnchorStyles.Left;
            this.textDDIME.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDIME.ReadOnly = false;
            this.textDDIME.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "DDIME"));
            this.textDDIME.MaxLength = 50;
            this.layoutManagerTabPage1.Controls.Add(this.textDDIME, 1, 4);
            this.layoutManagerTabPage1.SetColumnSpan(this.textDDIME, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.textDDIME, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDIME.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textDDIME.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textDDIME.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDADRESA.Location = point;
            this.label1DDADRESA.Name = "label1DDADRESA";
            this.label1DDADRESA.TabIndex = 1;
            this.label1DDADRESA.Tag = "labelDDADRESA";
            this.label1DDADRESA.Text = "Adresa:";
            this.label1DDADRESA.StyleSetName = "FieldUltraLabel";
            this.label1DDADRESA.AutoSize = true;
            this.label1DDADRESA.Anchor = AnchorStyles.Left;
            this.label1DDADRESA.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDADRESA.Appearance.ForeColor = Color.Black;
            this.label1DDADRESA.BackColor = Color.Transparent;
            this.layoutManagerTabPage1.Controls.Add(this.label1DDADRESA, 0, 5);
            this.layoutManagerTabPage1.SetColumnSpan(this.label1DDADRESA, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.label1DDADRESA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDADRESA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDADRESA.MinimumSize = size;
            size = new System.Drawing.Size(0x3e, 0x17);
            this.label1DDADRESA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDADRESA.Location = point;
            this.textDDADRESA.Name = "textDDADRESA";
            this.textDDADRESA.Tag = "DDADRESA";
            this.textDDADRESA.TabIndex = 0;
            this.textDDADRESA.Anchor = AnchorStyles.Left;
            this.textDDADRESA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDADRESA.ReadOnly = false;
            this.textDDADRESA.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "DDADRESA"));
            this.textDDADRESA.MaxLength = 50;
            this.layoutManagerTabPage1.Controls.Add(this.textDDADRESA, 1, 5);
            this.layoutManagerTabPage1.SetColumnSpan(this.textDDADRESA, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.textDDADRESA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDADRESA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textDDADRESA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textDDADRESA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDKUCNIBROJ.Location = point;
            this.label1DDKUCNIBROJ.Name = "label1DDKUCNIBROJ";
            this.label1DDKUCNIBROJ.TabIndex = 1;
            this.label1DDKUCNIBROJ.Tag = "labelDDKUCNIBROJ";
            this.label1DDKUCNIBROJ.Text = "Kućni broj:";
            this.label1DDKUCNIBROJ.StyleSetName = "FieldUltraLabel";
            this.label1DDKUCNIBROJ.AutoSize = true;
            this.label1DDKUCNIBROJ.Anchor = AnchorStyles.Left;
            this.label1DDKUCNIBROJ.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDKUCNIBROJ.Appearance.ForeColor = Color.Black;
            this.label1DDKUCNIBROJ.BackColor = Color.Transparent;
            this.layoutManagerTabPage1.Controls.Add(this.label1DDKUCNIBROJ, 0, 6);
            this.layoutManagerTabPage1.SetColumnSpan(this.label1DDKUCNIBROJ, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.label1DDKUCNIBROJ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDKUCNIBROJ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDKUCNIBROJ.MinimumSize = size;
            size = new System.Drawing.Size(0x53, 0x17);
            this.label1DDKUCNIBROJ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDKUCNIBROJ.Location = point;
            this.textDDKUCNIBROJ.Name = "textDDKUCNIBROJ";
            this.textDDKUCNIBROJ.Tag = "DDKUCNIBROJ";
            this.textDDKUCNIBROJ.TabIndex = 0;
            this.textDDKUCNIBROJ.Anchor = AnchorStyles.Left;
            this.textDDKUCNIBROJ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDKUCNIBROJ.ReadOnly = false;
            this.textDDKUCNIBROJ.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "DDKUCNIBROJ"));
            this.textDDKUCNIBROJ.MaxLength = 10;
            this.layoutManagerTabPage1.Controls.Add(this.textDDKUCNIBROJ, 1, 6);
            this.layoutManagerTabPage1.SetColumnSpan(this.textDDKUCNIBROJ, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.textDDKUCNIBROJ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDKUCNIBROJ.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textDDKUCNIBROJ.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textDDKUCNIBROJ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDMJESTO.Location = point;
            this.label1DDMJESTO.Name = "label1DDMJESTO";
            this.label1DDMJESTO.TabIndex = 1;
            this.label1DDMJESTO.Tag = "labelDDMJESTO";
            this.label1DDMJESTO.Text = "Mjesto:";
            this.label1DDMJESTO.StyleSetName = "FieldUltraLabel";
            this.label1DDMJESTO.AutoSize = true;
            this.label1DDMJESTO.Anchor = AnchorStyles.Left;
            this.label1DDMJESTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDMJESTO.Appearance.ForeColor = Color.Black;
            this.label1DDMJESTO.BackColor = Color.Transparent;
            this.layoutManagerTabPage1.Controls.Add(this.label1DDMJESTO, 0, 7);
            this.layoutManagerTabPage1.SetColumnSpan(this.label1DDMJESTO, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.label1DDMJESTO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDMJESTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDMJESTO.MinimumSize = size;
            size = new System.Drawing.Size(0x3d, 0x17);
            this.label1DDMJESTO.Size = size;

            point = new System.Drawing.Point(0, 0);
            this.lblAktivan.Location = point;
            this.lblAktivan.Name = "lblAktivan";
            this.lblAktivan.TabIndex = 1;
            this.lblAktivan.Tag = "lblAktivan";
            this.lblAktivan.Text = "Aktivan:";
            this.lblAktivan.StyleSetName = "FieldUltraLabel";
            this.lblAktivan.AutoSize = true;
            this.lblAktivan.Anchor = AnchorStyles.Left;
            this.lblAktivan.Appearance.TextVAlign = VAlign.Middle;
            this.lblAktivan.Appearance.ForeColor = Color.Black;
            this.lblAktivan.BackColor = Color.Transparent;
            this.layoutManagerTabPage1.Controls.Add(this.lblAktivan, 0, 8);
            this.layoutManagerTabPage1.SetColumnSpan(this.lblAktivan, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.lblAktivan, 1);
            padding = new Padding(3, 1, 5, 2);
            this.lblAktivan.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.lblAktivan.MinimumSize = size;
            size = new System.Drawing.Size(0x3d, 0x17);
            this.lblAktivan.Size = size;

            point = new System.Drawing.Point(0, 0);
            this.cbkAktivan.Location = point;
            this.cbkAktivan.Name = "cbkAktivan";
            this.cbkAktivan.Tag = "cbkAktivan";
            this.cbkAktivan.TabIndex = 0;
            this.cbkAktivan.Anchor = AnchorStyles.Left;
            this.cbkAktivan.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.cbkAktivan.Enabled = true;
            this.layoutManagerTabPage1.Controls.Add(this.cbkAktivan, 1, 8);
            this.layoutManagerTabPage1.SetColumnSpan(this.cbkAktivan, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.cbkAktivan, 1);
            padding = new Padding(0, 1, 3, 2);
            this.cbkAktivan.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.cbkAktivan.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.cbkAktivan.Size = size;

            point = new System.Drawing.Point(0, 0);
            this.textDDMJESTO.Location = point;
            this.textDDMJESTO.Name = "textDDMJESTO";
            this.textDDMJESTO.Tag = "DDMJESTO";
            this.textDDMJESTO.TabIndex = 0;
            this.textDDMJESTO.Anchor = AnchorStyles.Left;
            this.textDDMJESTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDMJESTO.ReadOnly = false;
            this.textDDMJESTO.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "DDMJESTO"));
            this.textDDMJESTO.MaxLength = 50;
            this.layoutManagerTabPage1.Controls.Add(this.textDDMJESTO, 1, 7);
            this.layoutManagerTabPage1.SetColumnSpan(this.textDDMJESTO, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.textDDMJESTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDMJESTO.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textDDMJESTO.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textDDMJESTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.TabPage2.Location = point;
            this.TabPage2.Name = "TabPage2";
            tab2.TabPage = this.TabPage2;
            tab2.Text = "Banke i općine";
            this.TabPage2.Controls.Add(this.layoutManagerTabPage2);
            point = new System.Drawing.Point(0, 0);
            this.label1DDZRN.Location = point;
            this.label1DDZRN.Name = "label1DDZRN";
            this.label1DDZRN.TabIndex = 1;
            this.label1DDZRN.Tag = "labelDDZRN";
            this.label1DDZRN.Text = "Žiro račun:";
            this.label1DDZRN.StyleSetName = "FieldUltraLabel";
            this.label1DDZRN.AutoSize = true;
            this.label1DDZRN.Anchor = AnchorStyles.Left;
            this.label1DDZRN.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDZRN.Appearance.ForeColor = Color.Black;
            this.label1DDZRN.BackColor = Color.Transparent;
            this.layoutManagerTabPage2.Controls.Add(this.label1DDZRN, 0, 0);
            this.layoutManagerTabPage2.SetColumnSpan(this.label1DDZRN, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.label1DDZRN, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDZRN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDZRN.MinimumSize = size;
            size = new System.Drawing.Size(0x52, 0x17);
            this.label1DDZRN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDZRN.Location = point;
            this.textDDZRN.Name = "textDDZRN";
            this.textDDZRN.Tag = "DDZRN";
            this.textDDZRN.TabIndex = 0;
            this.textDDZRN.Anchor = AnchorStyles.Left;
            this.textDDZRN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDZRN.ReadOnly = false;
            this.textDDZRN.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "DDZRN"));
            this.textDDZRN.MaxLength = 10;
            this.layoutManagerTabPage2.Controls.Add(this.textDDZRN, 1, 0);
            this.layoutManagerTabPage2.SetColumnSpan(this.textDDZRN, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.textDDZRN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDZRN.Margin = padding;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textDDZRN.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x16);
            this.textDDZRN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDBANKE.Location = point;
            this.label1IDBANKE.Name = "label1IDBANKE";
            this.label1IDBANKE.TabIndex = 1;
            this.label1IDBANKE.Tag = "labelIDBANKE";
            this.label1IDBANKE.Text = "Otvoren u:";
            this.label1IDBANKE.StyleSetName = "FieldUltraLabel";
            this.label1IDBANKE.AutoSize = true;
            this.label1IDBANKE.Anchor = AnchorStyles.Left;
            this.label1IDBANKE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDBANKE.Appearance.ForeColor = Color.Black;
            this.label1IDBANKE.BackColor = Color.Transparent;
            this.layoutManagerTabPage2.Controls.Add(this.label1IDBANKE, 0, 1);
            this.layoutManagerTabPage2.SetColumnSpan(this.label1IDBANKE, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.label1IDBANKE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDBANKE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDBANKE.MinimumSize = size;
            size = new System.Drawing.Size(0x51, 0x17);
            this.label1IDBANKE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDBANKE.Location = point;
            this.textIDBANKE.Name = "textIDBANKE";
            this.textIDBANKE.Tag = "IDBANKE";
            this.textIDBANKE.TabIndex = 0;
            this.textIDBANKE.Anchor = AnchorStyles.Left;
            this.textIDBANKE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDBANKE.ReadOnly = false;
            this.textIDBANKE.PromptChar = ' ';
            this.textIDBANKE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDBANKE.DataBindings.Add(new Binding("Value", this.bindingSourceDDRADNIK, "IDBANKE"));
            this.textIDBANKE.NumericType = NumericType.Integer;
            this.textIDBANKE.MaskInput = "{LOC}-nnnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonBANKEIDBANKE",
                Tag = "editorButtonBANKEIDBANKE",
                Text = "..."
            };
            this.textIDBANKE.ButtonsRight.Add(button);
            this.textIDBANKE.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptBANKEIDBANKE);
            this.layoutManagerTabPage2.Controls.Add(this.textIDBANKE, 1, 1);
            this.layoutManagerTabPage2.SetColumnSpan(this.textIDBANKE, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.textIDBANKE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDBANKE.Margin = padding;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDBANKE.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 0x16);
            this.textIDBANKE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVBANKE1.Location = point;
            this.label1NAZIVBANKE1.Name = "label1NAZIVBANKE1";
            this.label1NAZIVBANKE1.TabIndex = 1;
            this.label1NAZIVBANKE1.Tag = "labelNAZIVBANKE1";
            this.label1NAZIVBANKE1.Text = "Naziv banke:";
            this.label1NAZIVBANKE1.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVBANKE1.AutoSize = true;
            this.label1NAZIVBANKE1.Anchor = AnchorStyles.Left;
            this.label1NAZIVBANKE1.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVBANKE1.Appearance.ForeColor = Color.Black;
            this.label1NAZIVBANKE1.BackColor = Color.Transparent;
            this.layoutManagerTabPage2.Controls.Add(this.label1NAZIVBANKE1, 0, 2);
            this.layoutManagerTabPage2.SetColumnSpan(this.label1NAZIVBANKE1, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.label1NAZIVBANKE1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVBANKE1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVBANKE1.MinimumSize = size;
            size = new System.Drawing.Size(0x5f, 0x17);
            this.label1NAZIVBANKE1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVBANKE1.Location = point;
            this.labelNAZIVBANKE1.Name = "labelNAZIVBANKE1";
            this.labelNAZIVBANKE1.Tag = "NAZIVBANKE1";
            this.labelNAZIVBANKE1.TabIndex = 0;
            this.labelNAZIVBANKE1.Anchor = AnchorStyles.Left;
            this.labelNAZIVBANKE1.BackColor = Color.Transparent;
            this.labelNAZIVBANKE1.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "NAZIVBANKE1"));
            this.labelNAZIVBANKE1.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerTabPage2.Controls.Add(this.labelNAZIVBANKE1, 1, 2);
            this.layoutManagerTabPage2.SetColumnSpan(this.labelNAZIVBANKE1, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.labelNAZIVBANKE1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVBANKE1.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelNAZIVBANKE1.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.labelNAZIVBANKE1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPCINARADAIDOPCINE.Location = point;
            this.label1OPCINARADAIDOPCINE.Name = "label1OPCINARADAIDOPCINE";
            this.label1OPCINARADAIDOPCINE.TabIndex = 1;
            this.label1OPCINARADAIDOPCINE.Tag = "labelOPCINARADAIDOPCINE";
            this.label1OPCINARADAIDOPCINE.Text = "Šifra općine rada:";
            this.label1OPCINARADAIDOPCINE.StyleSetName = "FieldUltraLabel";
            this.label1OPCINARADAIDOPCINE.AutoSize = true;
            this.label1OPCINARADAIDOPCINE.Anchor = AnchorStyles.Left;
            this.label1OPCINARADAIDOPCINE.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPCINARADAIDOPCINE.Appearance.ForeColor = Color.Black;
            this.label1OPCINARADAIDOPCINE.BackColor = Color.Transparent;
            this.layoutManagerTabPage2.Controls.Add(this.label1OPCINARADAIDOPCINE, 0, 3);
            this.layoutManagerTabPage2.SetColumnSpan(this.label1OPCINARADAIDOPCINE, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.label1OPCINARADAIDOPCINE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPCINARADAIDOPCINE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPCINARADAIDOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0x7c, 0x17);
            this.label1OPCINARADAIDOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPCINARADAIDOPCINE.Location = point;
            this.textOPCINARADAIDOPCINE.Name = "textOPCINARADAIDOPCINE";
            this.textOPCINARADAIDOPCINE.Tag = "OPCINARADAIDOPCINE";
            this.textOPCINARADAIDOPCINE.TabIndex = 0;
            this.textOPCINARADAIDOPCINE.Anchor = AnchorStyles.Left;
            this.textOPCINARADAIDOPCINE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPCINARADAIDOPCINE.ReadOnly = false;
            this.textOPCINARADAIDOPCINE.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "OPCINARADAIDOPCINE"));
            this.textOPCINARADAIDOPCINE.MaxLength = 4;
            EditorButton button2 = new EditorButton {
                Key = "editorButtonOPCINAOPCINARADAIDOPCINE",
                Tag = "editorButtonOPCINAOPCINARADAIDOPCINE",
                Text = "..."
            };
            this.textOPCINARADAIDOPCINE.ButtonsRight.Add(button2);
            this.textOPCINARADAIDOPCINE.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOPCINAOPCINARADAIDOPCINE);
            this.layoutManagerTabPage2.Controls.Add(this.textOPCINARADAIDOPCINE, 1, 3);
            this.layoutManagerTabPage2.SetColumnSpan(this.textOPCINARADAIDOPCINE, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.textOPCINARADAIDOPCINE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPCINARADAIDOPCINE.Margin = padding;
            size = new System.Drawing.Size(0x40, 0x16);
            this.textOPCINARADAIDOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0x40, 0x16);
            this.textOPCINARADAIDOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPCINARADANAZIVOPCINE.Location = point;
            this.label1OPCINARADANAZIVOPCINE.Name = "label1OPCINARADANAZIVOPCINE";
            this.label1OPCINARADANAZIVOPCINE.TabIndex = 1;
            this.label1OPCINARADANAZIVOPCINE.Tag = "labelOPCINARADANAZIVOPCINE";
            this.label1OPCINARADANAZIVOPCINE.Text = "Naziv općine rada:";
            this.label1OPCINARADANAZIVOPCINE.StyleSetName = "FieldUltraLabel";
            this.label1OPCINARADANAZIVOPCINE.AutoSize = true;
            this.label1OPCINARADANAZIVOPCINE.Anchor = AnchorStyles.Left;
            this.label1OPCINARADANAZIVOPCINE.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPCINARADANAZIVOPCINE.Appearance.ForeColor = Color.Black;
            this.label1OPCINARADANAZIVOPCINE.BackColor = Color.Transparent;
            this.layoutManagerTabPage2.Controls.Add(this.label1OPCINARADANAZIVOPCINE, 0, 4);
            this.layoutManagerTabPage2.SetColumnSpan(this.label1OPCINARADANAZIVOPCINE, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.label1OPCINARADANAZIVOPCINE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPCINARADANAZIVOPCINE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPCINARADANAZIVOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0x81, 0x17);
            this.label1OPCINARADANAZIVOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOPCINARADANAZIVOPCINE.Location = point;
            this.labelOPCINARADANAZIVOPCINE.Name = "labelOPCINARADANAZIVOPCINE";
            this.labelOPCINARADANAZIVOPCINE.Tag = "OPCINARADANAZIVOPCINE";
            this.labelOPCINARADANAZIVOPCINE.TabIndex = 0;
            this.labelOPCINARADANAZIVOPCINE.Anchor = AnchorStyles.Left;
            this.labelOPCINARADANAZIVOPCINE.BackColor = Color.Transparent;
            this.labelOPCINARADANAZIVOPCINE.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "OPCINARADANAZIVOPCINE"));
            this.labelOPCINARADANAZIVOPCINE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerTabPage2.Controls.Add(this.labelOPCINARADANAZIVOPCINE, 1, 4);
            this.layoutManagerTabPage2.SetColumnSpan(this.labelOPCINARADANAZIVOPCINE, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.labelOPCINARADANAZIVOPCINE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOPCINARADANAZIVOPCINE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelOPCINARADANAZIVOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelOPCINARADANAZIVOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPCINASTANOVANJAIDOPCINE.Location = point;
            this.label1OPCINASTANOVANJAIDOPCINE.Name = "label1OPCINASTANOVANJAIDOPCINE";
            this.label1OPCINASTANOVANJAIDOPCINE.TabIndex = 1;
            this.label1OPCINASTANOVANJAIDOPCINE.Tag = "labelOPCINASTANOVANJAIDOPCINE";
            this.label1OPCINASTANOVANJAIDOPCINE.Text = "Šifra općine stanovanja:";
            this.label1OPCINASTANOVANJAIDOPCINE.StyleSetName = "FieldUltraLabel";
            this.label1OPCINASTANOVANJAIDOPCINE.AutoSize = true;
            this.label1OPCINASTANOVANJAIDOPCINE.Anchor = AnchorStyles.Left;
            this.label1OPCINASTANOVANJAIDOPCINE.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPCINASTANOVANJAIDOPCINE.Appearance.ForeColor = Color.Black;
            this.label1OPCINASTANOVANJAIDOPCINE.BackColor = Color.Transparent;
            this.layoutManagerTabPage2.Controls.Add(this.label1OPCINASTANOVANJAIDOPCINE, 0, 5);
            this.layoutManagerTabPage2.SetColumnSpan(this.label1OPCINASTANOVANJAIDOPCINE, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.label1OPCINASTANOVANJAIDOPCINE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPCINASTANOVANJAIDOPCINE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPCINASTANOVANJAIDOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0xa5, 0x17);
            this.label1OPCINASTANOVANJAIDOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPCINASTANOVANJAIDOPCINE.Location = point;
            this.textOPCINASTANOVANJAIDOPCINE.Name = "textOPCINASTANOVANJAIDOPCINE";
            this.textOPCINASTANOVANJAIDOPCINE.Tag = "OPCINASTANOVANJAIDOPCINE";
            this.textOPCINASTANOVANJAIDOPCINE.TabIndex = 0;
            this.textOPCINASTANOVANJAIDOPCINE.Anchor = AnchorStyles.Left;
            this.textOPCINASTANOVANJAIDOPCINE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPCINASTANOVANJAIDOPCINE.ReadOnly = false;
            this.textOPCINASTANOVANJAIDOPCINE.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "OPCINASTANOVANJAIDOPCINE"));
            this.textOPCINASTANOVANJAIDOPCINE.MaxLength = 4;
            EditorButton button3 = new EditorButton {
                Key = "editorButtonOPCINAOPCINASTANOVANJAIDOPCINE",
                Tag = "editorButtonOPCINAOPCINASTANOVANJAIDOPCINE",
                Text = "..."
            };
            this.textOPCINASTANOVANJAIDOPCINE.ButtonsRight.Add(button3);
            this.textOPCINASTANOVANJAIDOPCINE.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOPCINAOPCINASTANOVANJAIDOPCINE);
            this.layoutManagerTabPage2.Controls.Add(this.textOPCINASTANOVANJAIDOPCINE, 1, 5);
            this.layoutManagerTabPage2.SetColumnSpan(this.textOPCINASTANOVANJAIDOPCINE, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.textOPCINASTANOVANJAIDOPCINE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPCINASTANOVANJAIDOPCINE.Margin = padding;
            size = new System.Drawing.Size(0x40, 0x16);
            this.textOPCINASTANOVANJAIDOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0x40, 0x16);
            this.textOPCINASTANOVANJAIDOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPCINASTANOVANJANAZIVOPCINE.Location = point;
            this.label1OPCINASTANOVANJANAZIVOPCINE.Name = "label1OPCINASTANOVANJANAZIVOPCINE";
            this.label1OPCINASTANOVANJANAZIVOPCINE.TabIndex = 1;
            this.label1OPCINASTANOVANJANAZIVOPCINE.Tag = "labelOPCINASTANOVANJANAZIVOPCINE";
            this.label1OPCINASTANOVANJANAZIVOPCINE.Text = "Naziv općine stanovanja:";
            this.label1OPCINASTANOVANJANAZIVOPCINE.StyleSetName = "FieldUltraLabel";
            this.label1OPCINASTANOVANJANAZIVOPCINE.AutoSize = true;
            this.label1OPCINASTANOVANJANAZIVOPCINE.Anchor = AnchorStyles.Left;
            this.label1OPCINASTANOVANJANAZIVOPCINE.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPCINASTANOVANJANAZIVOPCINE.Appearance.ForeColor = Color.Black;
            this.label1OPCINASTANOVANJANAZIVOPCINE.BackColor = Color.Transparent;
            this.layoutManagerTabPage2.Controls.Add(this.label1OPCINASTANOVANJANAZIVOPCINE, 0, 6);
            this.layoutManagerTabPage2.SetColumnSpan(this.label1OPCINASTANOVANJANAZIVOPCINE, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.label1OPCINASTANOVANJANAZIVOPCINE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPCINASTANOVANJANAZIVOPCINE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPCINASTANOVANJANAZIVOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x17);
            this.label1OPCINASTANOVANJANAZIVOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOPCINASTANOVANJANAZIVOPCINE.Location = point;
            this.labelOPCINASTANOVANJANAZIVOPCINE.Name = "labelOPCINASTANOVANJANAZIVOPCINE";
            this.labelOPCINASTANOVANJANAZIVOPCINE.Tag = "OPCINASTANOVANJANAZIVOPCINE";
            this.labelOPCINASTANOVANJANAZIVOPCINE.TabIndex = 0;
            this.labelOPCINASTANOVANJANAZIVOPCINE.Anchor = AnchorStyles.Left;
            this.labelOPCINASTANOVANJANAZIVOPCINE.BackColor = Color.Transparent;
            this.labelOPCINASTANOVANJANAZIVOPCINE.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "OPCINASTANOVANJANAZIVOPCINE"));
            this.labelOPCINASTANOVANJANAZIVOPCINE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerTabPage2.Controls.Add(this.labelOPCINASTANOVANJANAZIVOPCINE, 1, 6);
            this.layoutManagerTabPage2.SetColumnSpan(this.labelOPCINASTANOVANJANAZIVOPCINE, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.labelOPCINASTANOVANJANAZIVOPCINE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOPCINASTANOVANJANAZIVOPCINE.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelOPCINASTANOVANJANAZIVOPCINE.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelOPCINASTANOVANJANAZIVOPCINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPCINASTANOVANJAPRIREZ.Location = point;
            this.label1OPCINASTANOVANJAPRIREZ.Name = "label1OPCINASTANOVANJAPRIREZ";
            this.label1OPCINASTANOVANJAPRIREZ.TabIndex = 1;
            this.label1OPCINASTANOVANJAPRIREZ.Tag = "labelOPCINASTANOVANJAPRIREZ";
            this.label1OPCINASTANOVANJAPRIREZ.Text = "Prirez općine stanovanja:";
            this.label1OPCINASTANOVANJAPRIREZ.StyleSetName = "FieldUltraLabel";
            this.label1OPCINASTANOVANJAPRIREZ.AutoSize = true;
            this.label1OPCINASTANOVANJAPRIREZ.Anchor = AnchorStyles.Left;
            this.label1OPCINASTANOVANJAPRIREZ.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPCINASTANOVANJAPRIREZ.Appearance.ForeColor = Color.Black;
            this.label1OPCINASTANOVANJAPRIREZ.BackColor = Color.Transparent;
            this.layoutManagerTabPage2.Controls.Add(this.label1OPCINASTANOVANJAPRIREZ, 0, 7);
            this.layoutManagerTabPage2.SetColumnSpan(this.label1OPCINASTANOVANJAPRIREZ, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.label1OPCINASTANOVANJAPRIREZ, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPCINASTANOVANJAPRIREZ.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPCINASTANOVANJAPRIREZ.MinimumSize = size;
            size = new System.Drawing.Size(0xac, 0x17);
            this.label1OPCINASTANOVANJAPRIREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelOPCINASTANOVANJAPRIREZ.Location = point;
            this.labelOPCINASTANOVANJAPRIREZ.Name = "labelOPCINASTANOVANJAPRIREZ";
            this.labelOPCINASTANOVANJAPRIREZ.Tag = "OPCINASTANOVANJAPRIREZ";
            this.labelOPCINASTANOVANJAPRIREZ.TabIndex = 0;
            this.labelOPCINASTANOVANJAPRIREZ.Anchor = AnchorStyles.Left;
            this.labelOPCINASTANOVANJAPRIREZ.BackColor = Color.Transparent;
            this.labelOPCINASTANOVANJAPRIREZ.Appearance.TextHAlign = HAlign.Left;
            this.labelOPCINASTANOVANJAPRIREZ.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerTabPage2.Controls.Add(this.labelOPCINASTANOVANJAPRIREZ, 1, 7);
            this.layoutManagerTabPage2.SetColumnSpan(this.labelOPCINASTANOVANJAPRIREZ, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.labelOPCINASTANOVANJAPRIREZ, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelOPCINASTANOVANJAPRIREZ.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelOPCINASTANOVANJAPRIREZ.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelOPCINASTANOVANJAPRIREZ.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.TabPage3.Location = point;
            this.TabPage3.Name = "TabPage3";
            tab3.TabPage = this.TabPage3;
            tab3.Text = "Dodatni podaci";
            this.TabPage3.Controls.Add(this.layoutManagerTabPage3);
            point = new System.Drawing.Point(0, 0);
            this.label1DDSIFRAOPISAPLACANJANETO.Location = point;
            this.label1DDSIFRAOPISAPLACANJANETO.Name = "label1DDSIFRAOPISAPLACANJANETO";
            this.label1DDSIFRAOPISAPLACANJANETO.TabIndex = 1;
            this.label1DDSIFRAOPISAPLACANJANETO.Tag = "labelDDSIFRAOPISAPLACANJANETO";
            this.label1DDSIFRAOPISAPLACANJANETO.Text = "Šifra opisa plaćanja:";
            this.label1DDSIFRAOPISAPLACANJANETO.StyleSetName = "FieldUltraLabel";
            this.label1DDSIFRAOPISAPLACANJANETO.AutoSize = true;
            this.label1DDSIFRAOPISAPLACANJANETO.Anchor = AnchorStyles.Left;
            this.label1DDSIFRAOPISAPLACANJANETO.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDSIFRAOPISAPLACANJANETO.Appearance.ForeColor = Color.Black;
            this.label1DDSIFRAOPISAPLACANJANETO.BackColor = Color.Transparent;
            this.layoutManagerTabPage3.Controls.Add(this.label1DDSIFRAOPISAPLACANJANETO, 0, 0);
            this.layoutManagerTabPage3.SetColumnSpan(this.label1DDSIFRAOPISAPLACANJANETO, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.label1DDSIFRAOPISAPLACANJANETO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDSIFRAOPISAPLACANJANETO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDSIFRAOPISAPLACANJANETO.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 0x17);
            this.label1DDSIFRAOPISAPLACANJANETO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDSIFRAOPISAPLACANJANETO.Location = point;
            this.textDDSIFRAOPISAPLACANJANETO.Name = "textDDSIFRAOPISAPLACANJANETO";
            this.textDDSIFRAOPISAPLACANJANETO.Tag = "DDSIFRAOPISAPLACANJANETO";
            this.textDDSIFRAOPISAPLACANJANETO.TabIndex = 0;
            this.textDDSIFRAOPISAPLACANJANETO.Anchor = AnchorStyles.Left;
            this.textDDSIFRAOPISAPLACANJANETO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDSIFRAOPISAPLACANJANETO.ReadOnly = false;
            this.textDDSIFRAOPISAPLACANJANETO.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "DDSIFRAOPISAPLACANJANETO"));
            this.textDDSIFRAOPISAPLACANJANETO.MaxLength = 2;
            this.layoutManagerTabPage3.Controls.Add(this.textDDSIFRAOPISAPLACANJANETO, 1, 0);
            this.layoutManagerTabPage3.SetColumnSpan(this.textDDSIFRAOPISAPLACANJANETO, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.textDDSIFRAOPISAPLACANJANETO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDSIFRAOPISAPLACANJANETO.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textDDSIFRAOPISAPLACANJANETO.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textDDSIFRAOPISAPLACANJANETO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDOPISPLACANJANETO.Location = point;
            this.label1DDOPISPLACANJANETO.Name = "label1DDOPISPLACANJANETO";
            this.label1DDOPISPLACANJANETO.TabIndex = 1;
            this.label1DDOPISPLACANJANETO.Tag = "labelDDOPISPLACANJANETO";
            this.label1DDOPISPLACANJANETO.Text = "Opis plaćanja za neto:";
            this.label1DDOPISPLACANJANETO.StyleSetName = "FieldUltraLabel";
            this.label1DDOPISPLACANJANETO.AutoSize = true;
            this.label1DDOPISPLACANJANETO.Anchor = AnchorStyles.Left;
            this.label1DDOPISPLACANJANETO.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDOPISPLACANJANETO.Appearance.ForeColor = Color.Black;
            this.label1DDOPISPLACANJANETO.BackColor = Color.Transparent;
            this.layoutManagerTabPage3.Controls.Add(this.label1DDOPISPLACANJANETO, 0, 1);
            this.layoutManagerTabPage3.SetColumnSpan(this.label1DDOPISPLACANJANETO, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.label1DDOPISPLACANJANETO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDOPISPLACANJANETO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDOPISPLACANJANETO.MinimumSize = size;
            size = new System.Drawing.Size(0x98, 0x17);
            this.label1DDOPISPLACANJANETO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDOPISPLACANJANETO.Location = point;
            this.textDDOPISPLACANJANETO.Name = "textDDOPISPLACANJANETO";
            this.textDDOPISPLACANJANETO.Tag = "DDOPISPLACANJANETO";
            this.textDDOPISPLACANJANETO.TabIndex = 0;
            this.textDDOPISPLACANJANETO.Anchor = AnchorStyles.Left;
            this.textDDOPISPLACANJANETO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDOPISPLACANJANETO.ReadOnly = false;
            this.textDDOPISPLACANJANETO.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "DDOPISPLACANJANETO"));
            this.textDDOPISPLACANJANETO.MaxLength = 0x24;
            this.layoutManagerTabPage3.Controls.Add(this.textDDOPISPLACANJANETO, 1, 1);
            this.layoutManagerTabPage3.SetColumnSpan(this.textDDOPISPLACANJANETO, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.textDDOPISPLACANJANETO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDOPISPLACANJANETO.Margin = padding;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textDDOPISPLACANJANETO.MinimumSize = size;
            size = new System.Drawing.Size(0x10c, 0x16);
            this.textDDOPISPLACANJANETO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDPDVOBVEZNIK.Location = point;
            this.label1DDPDVOBVEZNIK.Name = "label1DDPDVOBVEZNIK";
            this.label1DDPDVOBVEZNIK.TabIndex = 1;
            this.label1DDPDVOBVEZNIK.Tag = "labelDDPDVOBVEZNIK";
            this.label1DDPDVOBVEZNIK.Text = "Obveznik PDV-a:";
            this.label1DDPDVOBVEZNIK.StyleSetName = "FieldUltraLabel";
            this.label1DDPDVOBVEZNIK.AutoSize = true;
            this.label1DDPDVOBVEZNIK.Anchor = AnchorStyles.Left;
            this.label1DDPDVOBVEZNIK.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDPDVOBVEZNIK.Appearance.ForeColor = Color.Black;
            this.label1DDPDVOBVEZNIK.BackColor = Color.Transparent;
            this.layoutManagerTabPage3.Controls.Add(this.label1DDPDVOBVEZNIK, 0, 2);
            this.layoutManagerTabPage3.SetColumnSpan(this.label1DDPDVOBVEZNIK, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.label1DDPDVOBVEZNIK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDPDVOBVEZNIK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDPDVOBVEZNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x77, 0x17);
            this.label1DDPDVOBVEZNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkDDPDVOBVEZNIK.Location = point;
            this.checkDDPDVOBVEZNIK.Name = "checkDDPDVOBVEZNIK";
            this.checkDDPDVOBVEZNIK.Tag = "DDPDVOBVEZNIK";
            this.checkDDPDVOBVEZNIK.TabIndex = 0;
            this.checkDDPDVOBVEZNIK.Anchor = AnchorStyles.Left;
            this.checkDDPDVOBVEZNIK.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkDDPDVOBVEZNIK.Enabled = true;
            this.layoutManagerTabPage3.Controls.Add(this.checkDDPDVOBVEZNIK, 1, 2);
            this.layoutManagerTabPage3.SetColumnSpan(this.checkDDPDVOBVEZNIK, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.checkDDPDVOBVEZNIK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkDDPDVOBVEZNIK.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkDDPDVOBVEZNIK.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkDDPDVOBVEZNIK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDDRUGISTUP.Location = point;
            this.label1DDDRUGISTUP.Name = "label1DDDRUGISTUP";
            this.label1DDDRUGISTUP.TabIndex = 1;
            this.label1DDDRUGISTUP.Tag = "labelDDDRUGISTUP";
            this.label1DDDRUGISTUP.Text = "Član MIO2:";
            this.label1DDDRUGISTUP.StyleSetName = "FieldUltraLabel";
            this.label1DDDRUGISTUP.AutoSize = true;
            this.label1DDDRUGISTUP.Anchor = AnchorStyles.Left;
            this.label1DDDRUGISTUP.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDDRUGISTUP.Appearance.ForeColor = Color.Black;
            this.label1DDDRUGISTUP.BackColor = Color.Transparent;
            this.layoutManagerTabPage3.Controls.Add(this.label1DDDRUGISTUP, 0, 3);
            this.layoutManagerTabPage3.SetColumnSpan(this.label1DDDRUGISTUP, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.label1DDDRUGISTUP, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDDRUGISTUP.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDDRUGISTUP.MinimumSize = size;
            size = new System.Drawing.Size(0x54, 0x17);
            this.label1DDDRUGISTUP.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkDDDRUGISTUP.Location = point;
            this.checkDDDRUGISTUP.Name = "checkDDDRUGISTUP";
            this.checkDDDRUGISTUP.Tag = "DDDRUGISTUP";
            this.checkDDDRUGISTUP.TabIndex = 0;
            this.checkDDDRUGISTUP.Anchor = AnchorStyles.Left;
            this.checkDDDRUGISTUP.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkDDDRUGISTUP.Enabled = true;
            this.layoutManagerTabPage3.Controls.Add(this.checkDDDRUGISTUP, 1, 3);
            this.layoutManagerTabPage3.SetColumnSpan(this.checkDDDRUGISTUP, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.checkDDDRUGISTUP, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkDDDRUGISTUP.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkDDDRUGISTUP.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkDDDRUGISTUP.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDZBIRNINETO.Location = point;
            this.label1DDZBIRNINETO.Name = "label1DDZBIRNINETO";
            this.label1DDZBIRNINETO.TabIndex = 1;
            this.label1DDZBIRNINETO.Tag = "labelDDZBIRNINETO";
            this.label1DDZBIRNINETO.Text = "Zbirni neto:";
            this.label1DDZBIRNINETO.StyleSetName = "FieldUltraLabel";
            this.label1DDZBIRNINETO.AutoSize = true;
            this.label1DDZBIRNINETO.Anchor = AnchorStyles.Left;
            this.label1DDZBIRNINETO.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDZBIRNINETO.Appearance.ForeColor = Color.Black;
            this.label1DDZBIRNINETO.BackColor = Color.Transparent;
            this.layoutManagerTabPage3.Controls.Add(this.label1DDZBIRNINETO, 0, 4);
            this.layoutManagerTabPage3.SetColumnSpan(this.label1DDZBIRNINETO, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.label1DDZBIRNINETO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDZBIRNINETO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDZBIRNINETO.MinimumSize = size;
            size = new System.Drawing.Size(0x57, 0x17);
            this.label1DDZBIRNINETO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkDDZBIRNINETO.Location = point;
            this.checkDDZBIRNINETO.Name = "checkDDZBIRNINETO";
            this.checkDDZBIRNINETO.Tag = "DDZBIRNINETO";
            this.checkDDZBIRNINETO.TabIndex = 0;
            this.checkDDZBIRNINETO.Anchor = AnchorStyles.Left;
            this.checkDDZBIRNINETO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkDDZBIRNINETO.Enabled = true;
            this.layoutManagerTabPage3.Controls.Add(this.checkDDZBIRNINETO, 1, 4);
            this.layoutManagerTabPage3.SetColumnSpan(this.checkDDZBIRNINETO, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.checkDDZBIRNINETO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkDDZBIRNINETO.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkDDZBIRNINETO.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkDDZBIRNINETO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDMO.Location = point;
            this.label1DDMO.Name = "label1DDMO";
            this.label1DDMO.TabIndex = 1;
            this.label1DDMO.Tag = "labelDDMO";
            this.label1DDMO.Text = "Model odobrenja kod pojedinačne uplate:";
            this.label1DDMO.StyleSetName = "FieldUltraLabel";
            this.label1DDMO.AutoSize = true;
            this.label1DDMO.Anchor = AnchorStyles.Left;
            this.label1DDMO.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDMO.Appearance.ForeColor = Color.Black;
            this.label1DDMO.BackColor = Color.Transparent;
            this.layoutManagerTabPage3.Controls.Add(this.label1DDMO, 0, 5);
            this.layoutManagerTabPage3.SetColumnSpan(this.label1DDMO, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.label1DDMO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDMO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDMO.MinimumSize = size;
            size = new System.Drawing.Size(0x110, 0x17);
            this.label1DDMO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDMO.Location = point;
            this.textDDMO.Name = "textDDMO";
            this.textDDMO.Tag = "DDMO";
            this.textDDMO.TabIndex = 0;
            this.textDDMO.Anchor = AnchorStyles.Left;
            this.textDDMO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDMO.ContextMenu = this.contextMenu1;
            this.textDDMO.ReadOnly = false;
            this.textDDMO.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "DDMO"));
            this.textDDMO.Nullable = true;
            this.textDDMO.MaxLength = 2;
            this.layoutManagerTabPage3.Controls.Add(this.textDDMO, 1, 5);
            this.layoutManagerTabPage3.SetColumnSpan(this.textDDMO, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.textDDMO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDMO.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textDDMO.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textDDMO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DDPBO.Location = point;
            this.label1DDPBO.Name = "label1DDPBO";
            this.label1DDPBO.TabIndex = 1;
            this.label1DDPBO.Tag = "labelDDPBO";
            this.label1DDPBO.Text = "Poziv na broj odobrenja kod pojedinačne uplate:";
            this.label1DDPBO.StyleSetName = "FieldUltraLabel";
            this.label1DDPBO.AutoSize = true;
            this.label1DDPBO.Anchor = AnchorStyles.Left;
            this.label1DDPBO.Appearance.TextVAlign = VAlign.Middle;
            this.label1DDPBO.Appearance.ForeColor = Color.Black;
            this.label1DDPBO.BackColor = Color.Transparent;
            this.layoutManagerTabPage3.Controls.Add(this.label1DDPBO, 0, 6);
            this.layoutManagerTabPage3.SetColumnSpan(this.label1DDPBO, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.label1DDPBO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DDPBO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DDPBO.MinimumSize = size;
            size = new System.Drawing.Size(0x13c, 0x17);
            this.label1DDPBO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textDDPBO.Location = point;
            this.textDDPBO.Name = "textDDPBO";
            this.textDDPBO.Tag = "DDPBO";
            this.textDDPBO.TabIndex = 0;
            this.textDDPBO.Anchor = AnchorStyles.Left;
            this.textDDPBO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textDDPBO.ContextMenu = this.contextMenu1;
            this.textDDPBO.ReadOnly = false;
            this.textDDPBO.DataBindings.Add(new Binding("Text", this.bindingSourceDDRADNIK, "DDPBO"));
            this.textDDPBO.Nullable = true;
            this.textDDPBO.MaxLength = 0x16;
            this.layoutManagerTabPage3.Controls.Add(this.textDDPBO, 1, 6);
            this.layoutManagerTabPage3.SetColumnSpan(this.textDDPBO, 1);
            this.layoutManagerTabPage3.SetRowSpan(this.textDDPBO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textDDPBO.Margin = padding;
            size = new System.Drawing.Size(170, 0x16);
            this.textDDPBO.MinimumSize = size;
            size = new System.Drawing.Size(170, 0x16);
            this.textDDPBO.Size = size;
            this.Controls.Add(this.layoutManagerformDDRADNIK);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceDDRADNIK;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.Name = "DDRADNIKFormUserControl";
            this.Text = "Primatelji DD";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.DDRADNIKFormUserControl_Load);
            this.layoutManagerformDDRADNIK.ResumeLayout(false);
            this.layoutManagerformDDRADNIK.PerformLayout();
            ((ISupportInitialize) this.bindingSourceDDRADNIK).EndInit();
            ((ISupportInitialize) this.textDDIDRADNIK).EndInit();
            ((ISupportInitialize) this.textDDJMBG).EndInit();
            ((ISupportInitialize) this.textDDOIB).EndInit();
            ((ISupportInitialize) this.textDDPREZIME).EndInit();
            ((ISupportInitialize) this.textDDIME).EndInit();
            ((ISupportInitialize) this.textDDADRESA).EndInit();
            ((ISupportInitialize) this.textDDKUCNIBROJ).EndInit();
            ((ISupportInitialize) this.textDDMJESTO).EndInit();
            this.layoutManagerTabPage1.ResumeLayout(false);
            this.layoutManagerTabPage1.PerformLayout();
            ((ISupportInitialize) this.textDDZRN).EndInit();
            ((ISupportInitialize) this.textIDBANKE).EndInit();
            ((ISupportInitialize) this.textOPCINARADAIDOPCINE).EndInit();
            ((ISupportInitialize) this.textOPCINASTANOVANJAIDOPCINE).EndInit();
            this.layoutManagerTabPage2.ResumeLayout(false);
            this.layoutManagerTabPage2.PerformLayout();
            ((ISupportInitialize) this.textDDSIFRAOPISAPLACANJANETO).EndInit();
            ((ISupportInitialize) this.textDDOPISPLACANJANETO).EndInit();
            ((ISupportInitialize) this.textDDMO).EndInit();
            ((ISupportInitialize) this.textDDPBO).EndInit();
            this.layoutManagerTabPage3.ResumeLayout(false);
            this.layoutManagerTabPage3.PerformLayout();
            this.Tab1.ResumeLayout(true);
            this.Tab1.PerformLayout();
            ((ISupportInitialize) this.Tab1).EndInit();
            this.dsDDRADNIKDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.DDRADNIKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceDDRADNIK, this.DDRADNIKController.WorkItem, this))
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
            this.label1DDIDRADNIK.Text = StringResources.DDRADNIKDDIDRADNIKDescription;
            this.label1DDJMBG.Text = StringResources.DDRADNIKDDJMBGDescription;
            this.label1DDOIB.Text = StringResources.DDRADNIKDDOIBDescription;
            this.label1DDPREZIME.Text = StringResources.DDRADNIKDDPREZIMEDescription;
            this.label1DDIME.Text = StringResources.DDRADNIKDDIMEDescription;
            this.label1DDADRESA.Text = StringResources.DDRADNIKDDADRESADescription;
            this.label1DDKUCNIBROJ.Text = StringResources.DDRADNIKDDKUCNIBROJDescription;
            this.label1DDMJESTO.Text = StringResources.DDRADNIKDDMJESTODescription;
            this.label1DDZRN.Text = StringResources.DDRADNIKDDZRNDescription;
            this.label1IDBANKE.Text = StringResources.DDRADNIKIDBANKEDescription;
            this.label1NAZIVBANKE1.Text = StringResources.DDRADNIKNAZIVBANKE1Description;
            this.label1OPCINARADAIDOPCINE.Text = StringResources.DDRADNIKOPCINARADAIDOPCINEDescription;
            this.label1OPCINARADANAZIVOPCINE.Text = StringResources.DDRADNIKOPCINARADANAZIVOPCINEDescription;
            this.label1OPCINASTANOVANJAIDOPCINE.Text = StringResources.DDRADNIKOPCINASTANOVANJAIDOPCINEDescription;
            this.label1OPCINASTANOVANJANAZIVOPCINE.Text = StringResources.DDRADNIKOPCINASTANOVANJANAZIVOPCINEDescription;
            this.label1OPCINASTANOVANJAPRIREZ.Text = StringResources.DDRADNIKOPCINASTANOVANJAPRIREZDescription;
            this.label1DDSIFRAOPISAPLACANJANETO.Text = StringResources.DDRADNIKDDSIFRAOPISAPLACANJANETODescription;
            this.label1DDOPISPLACANJANETO.Text = StringResources.DDRADNIKDDOPISPLACANJANETODescription;
            this.label1DDPDVOBVEZNIK.Text = StringResources.DDRADNIKDDPDVOBVEZNIKDescription;
            this.label1DDDRUGISTUP.Text = StringResources.DDRADNIKDDDRUGISTUPDescription;
            this.label1DDZBIRNINETO.Text = StringResources.DDRADNIKDDZBIRNINETODescription;
            this.label1DDMO.Text = StringResources.DDRADNIKDDMODescription;
            this.label1DDPBO.Text = StringResources.DDRADNIKDDPBODescription;
            this.TabPage1.Tab.Text = StringResources.DDRADNIKDDRADNIKTabPage1TabDescription;
            this.TabPage2.Tab.Text = StringResources.DDRADNIKDDRADNIKTabPage2TabDescription;
            this.TabPage3.Tab.Text = StringResources.DDRADNIKDDRADNIKTabPage3TabDescription;
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
            if (!this.DDRADNIKController.WorkItem.Items.Contains("DDRADNIK|DDRADNIK"))
            {
                this.DDRADNIKController.WorkItem.Items.Add(this.bindingSourceDDRADNIK, "DDRADNIK|DDRADNIK");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsDDRADNIKDataSet1.DDRADNIK.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.DDRADNIKController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DDRADNIKController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.DDRADNIKController.Update(this))
            {
                this.DDRADNIKController.DataSet = new DDRADNIKDataSet();
                DataSetUtil.AddEmptyRow(this.DDRADNIKController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.DDRADNIKController.DataSet.DDRADNIK[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textDDIDRADNIK.Focus();
        }

        private void SetNullItem_Click(object sender, EventArgs e)
        {
            this.m_BaseMethods.SetNullItemClickBase(RuntimeHelpers.GetObjectValue(sender), this.m_CurrentRow);
        }

        private void SetSize()
        {
            Size controlSize = WinHelperUtil.GetControlSize(this.Tab1);
            this.Tab1.TabPageSize = controlSize;
            controlSize.Width = (controlSize.Width + this.Tab1.Parent.Margin.Horizontal) + this.Tab1.Margin.Horizontal;
            controlSize.Height += this.Tab1.Margin.Vertical;
            this.Tab1.Size = controlSize;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.m_FrameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void UpdateValuesBANKEIDBANKE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceDDRADNIK.Current).Row["IDBANKE"] = RuntimeHelpers.GetObjectValue(result["IDBANKE"]);
                ((DataRowView) this.bindingSourceDDRADNIK.Current).Row["NAZIVBANKE1"] = RuntimeHelpers.GetObjectValue(result["NAZIVBANKE1"]);
                ((DataRowView) this.bindingSourceDDRADNIK.Current).Row["NAZIVBANKE2"] = RuntimeHelpers.GetObjectValue(result["NAZIVBANKE2"]);
                ((DataRowView) this.bindingSourceDDRADNIK.Current).Row["NAZIVBANKE3"] = RuntimeHelpers.GetObjectValue(result["NAZIVBANKE3"]);
                ((DataRowView) this.bindingSourceDDRADNIK.Current).Row["VBDIBANKE"] = RuntimeHelpers.GetObjectValue(result["VBDIBANKE"]);
                ((DataRowView) this.bindingSourceDDRADNIK.Current).Row["ZRNBANKE"] = RuntimeHelpers.GetObjectValue(result["ZRNBANKE"]);
                this.bindingSourceDDRADNIK.ResetCurrentItem();
            }
        }

        private void UpdateValuesOPCINAOPCINARADAIDOPCINE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceDDRADNIK.Current).Row["OPCINARADAIDOPCINE"] = RuntimeHelpers.GetObjectValue(result["IDOPCINE"]);
                ((DataRowView) this.bindingSourceDDRADNIK.Current).Row["OPCINARADANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(result["NAZIVOPCINE"]);
                this.bindingSourceDDRADNIK.ResetCurrentItem();
            }
        }

        private void UpdateValuesOPCINAOPCINASTANOVANJAIDOPCINE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceDDRADNIK.Current).Row["OPCINASTANOVANJAIDOPCINE"] = RuntimeHelpers.GetObjectValue(result["IDOPCINE"]);
                ((DataRowView) this.bindingSourceDDRADNIK.Current).Row["OPCINASTANOVANJANAZIVOPCINE"] = RuntimeHelpers.GetObjectValue(result["NAZIVOPCINE"]);
                ((DataRowView) this.bindingSourceDDRADNIK.Current).Row["OPCINASTANOVANJAPRIREZ"] = RuntimeHelpers.GetObjectValue(result["PRIREZ"]);
                ((DataRowView) this.bindingSourceDDRADNIK.Current).Row["OPCINASTANOVANJAVBDIOPCINA"] = RuntimeHelpers.GetObjectValue(result["VBDIOPCINA"]);
                ((DataRowView) this.bindingSourceDDRADNIK.Current).Row["OPCINASTANOVANJAZRNOPCINA"] = RuntimeHelpers.GetObjectValue(result["ZRNOPCINA"]);
                this.bindingSourceDDRADNIK.ResetCurrentItem();
            }
        }

        protected virtual UltraCheckEditor checkDDDRUGISTUP
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkDDDRUGISTUP;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkDDDRUGISTUP = value;
            }
        }

        protected virtual UltraCheckEditor checkDDPDVOBVEZNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkDDPDVOBVEZNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkDDPDVOBVEZNIK = value;
            }
        }

        protected virtual UltraCheckEditor checkDDZBIRNINETO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkDDZBIRNINETO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkDDZBIRNINETO = value;
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.DDRADNIKController DDRADNIKController { get; set; }

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

        protected virtual UltraCheckEditor cbkAktivan
        {
            [DebuggerNonUserCode]
            get
            {
                return this._cbkAktivan;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._cbkAktivan = value;
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

        protected virtual UltraLabel label1DDADRESA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDADRESA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDADRESA = value;
            }
        }

        protected virtual UltraLabel label1DDDRUGISTUP
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDDRUGISTUP;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDDRUGISTUP = value;
            }
        }

        protected virtual UltraLabel label1DDIDRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDIDRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDIDRADNIK = value;
            }
        }

        protected virtual UltraLabel label1DDIME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDIME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDIME = value;
            }
        }

        protected virtual UltraLabel label1DDJMBG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDJMBG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDJMBG = value;
            }
        }

        protected virtual UltraLabel label1DDKUCNIBROJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDKUCNIBROJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDKUCNIBROJ = value;
            }
        }

        protected virtual UltraLabel label1DDMJESTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDMJESTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDMJESTO = value;
            }
        }

        protected virtual UltraLabel label1DDMO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDMO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDMO = value;
            }
        }

        protected virtual UltraLabel label1DDOIB
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDOIB;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDOIB = value;
            }
        }

        protected virtual UltraLabel label1DDOPISPLACANJANETO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDOPISPLACANJANETO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDOPISPLACANJANETO = value;
            }
        }

        protected virtual UltraLabel label1DDPBO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDPBO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDPBO = value;
            }
        }

        protected virtual UltraLabel label1DDPDVOBVEZNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDPDVOBVEZNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDPDVOBVEZNIK = value;
            }
        }

        protected virtual UltraLabel label1DDPREZIME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDPREZIME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDPREZIME = value;
            }
        }

        protected virtual UltraLabel label1DDSIFRAOPISAPLACANJANETO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDSIFRAOPISAPLACANJANETO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDSIFRAOPISAPLACANJANETO = value;
            }
        }

        protected virtual UltraLabel label1DDZBIRNINETO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDZBIRNINETO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDZBIRNINETO = value;
            }
        }

        protected virtual UltraLabel label1DDZRN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DDZRN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DDZRN = value;
            }
        }

        protected virtual UltraLabel label1IDBANKE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDBANKE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDBANKE = value;
            }
        }

        protected virtual UltraLabel label1NAZIVBANKE1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVBANKE1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVBANKE1 = value;
            }
        }

        protected virtual UltraLabel label1OPCINARADAIDOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPCINARADAIDOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPCINARADAIDOPCINE = value;
            }
        }

        protected virtual UltraLabel label1OPCINARADANAZIVOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPCINARADANAZIVOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPCINARADANAZIVOPCINE = value;
            }
        }

        protected virtual UltraLabel lblAktivan
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lblAktivan;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._lblAktivan = value;
            }
        }

        protected virtual UltraLabel label1OPCINASTANOVANJAIDOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPCINASTANOVANJAIDOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPCINASTANOVANJAIDOPCINE = value;
            }
        }

        protected virtual UltraLabel label1OPCINASTANOVANJANAZIVOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPCINASTANOVANJANAZIVOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPCINASTANOVANJANAZIVOPCINE = value;
            }
        }

        protected virtual UltraLabel label1OPCINASTANOVANJAPRIREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPCINASTANOVANJAPRIREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPCINASTANOVANJAPRIREZ = value;
            }
        }

        protected virtual UltraLabel labelNAZIVBANKE1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVBANKE1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVBANKE1 = value;
            }
        }

        protected virtual UltraLabel labelOPCINARADANAZIVOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOPCINARADANAZIVOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOPCINARADANAZIVOPCINE = value;
            }
        }

        protected virtual UltraLabel labelOPCINASTANOVANJANAZIVOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOPCINASTANOVANJANAZIVOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOPCINASTANOVANJANAZIVOPCINE = value;
            }
        }

        protected virtual UltraLabel labelOPCINASTANOVANJAPRIREZ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelOPCINASTANOVANJAPRIREZ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelOPCINASTANOVANJAPRIREZ = value;
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

        protected virtual UltraTabControl Tab1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Tab1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Tab1 = value;
            }
        }

        protected virtual UltraTabPageControl TabPage1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage1 = value;
            }
        }

        protected virtual UltraTabPageControl TabPage2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage2 = value;
            }
        }

        protected virtual UltraTabPageControl TabPage3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage3 = value;
            }
        }

        protected virtual UltraTextEditor textDDADRESA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDADRESA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDADRESA = value;
            }
        }

        protected virtual UltraNumericEditor textDDIDRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDIDRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDIDRADNIK = value;
            }
        }

        protected virtual UltraTextEditor textDDIME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDIME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDIME = value;
            }
        }

        protected virtual UltraTextEditor textDDJMBG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDJMBG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDJMBG = value;
            }
        }

        protected virtual UltraTextEditor textDDKUCNIBROJ
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDKUCNIBROJ;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDKUCNIBROJ = value;
            }
        }

        protected virtual UltraTextEditor textDDMJESTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDMJESTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDMJESTO = value;
            }
        }

        protected virtual UltraTextEditor textDDMO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDMO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDMO = value;
            }
        }

        protected virtual UltraTextEditor textDDOIB
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDOIB;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDOIB = value;
            }
        }

        protected virtual UltraTextEditor textDDOPISPLACANJANETO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDOPISPLACANJANETO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDOPISPLACANJANETO = value;
            }
        }

        protected virtual UltraTextEditor textDDPBO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDPBO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDPBO = value;
            }
        }

        protected virtual UltraTextEditor textDDPREZIME
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDPREZIME;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDPREZIME = value;
            }
        }

        protected virtual UltraTextEditor textDDSIFRAOPISAPLACANJANETO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDSIFRAOPISAPLACANJANETO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDSIFRAOPISAPLACANJANETO = value;
            }
        }

        protected virtual UltraTextEditor textDDZRN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textDDZRN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textDDZRN = value;
            }
        }

        protected virtual UltraNumericEditor textIDBANKE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDBANKE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDBANKE = value;
            }
        }

        protected virtual UltraTextEditor textOPCINARADAIDOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPCINARADAIDOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPCINARADAIDOPCINE = value;
            }
        }

        protected virtual UltraTextEditor textOPCINASTANOVANJAIDOPCINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPCINASTANOVANJAIDOPCINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPCINASTANOVANJAIDOPCINE = value;
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

