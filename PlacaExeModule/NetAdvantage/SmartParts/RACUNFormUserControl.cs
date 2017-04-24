namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Resources;
    using Deklarit.Win;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.EventBroker;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using NetAdvantage.Controls;
    using mipsed.application.framework;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class RACUNFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("ButtonControl1")]
        private Button _ButtonControl1;
        [AccessedThroughProperty("ButtonControl2")]
        private Button _ButtonControl2;
        [AccessedThroughProperty("ButtonControl3")]
        private Button _ButtonControl3;
        [AccessedThroughProperty("ButtonControl4")]
        private Button _ButtonControl4;
        [AccessedThroughProperty("checkZAPREDUJAM")]
        private UltraCheckEditor _checkZAPREDUJAM;
        [AccessedThroughProperty("comboIDPARTNER")]
        private PARTNERComboBox _comboIDPARTNER;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("datePickerDATUM")]
        private UltraDateTimeEditor _datePickerDATUM;
        [AccessedThroughProperty("datePickerRAZDOBLJEDO")]
        private UltraDateTimeEditor _datePickerRAZDOBLJEDO;
        [AccessedThroughProperty("datePickerRAZDOBLJEOD")]
        private UltraDateTimeEditor _datePickerRAZDOBLJEOD;
        [AccessedThroughProperty("datePickerVALUTA")]
        private UltraDateTimeEditor _datePickerVALUTA;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelRACUNRacunStavke")]
        private UltraGrid _grdLevelRACUNRacunStavke;
        [AccessedThroughProperty("label1DATUM")]
        private UltraLabel _label1DATUM;
        [AccessedThroughProperty("label1IDPARTNER")]
        private UltraLabel _label1IDPARTNER;
        [AccessedThroughProperty("label1IDRACUN")]
        private UltraLabel _label1IDRACUN;
        [AccessedThroughProperty("label1MODEL")]
        private UltraLabel _label1MODEL;
        [AccessedThroughProperty("label1NAPOMENA")]
        private UltraLabel _label1NAPOMENA;
        [AccessedThroughProperty("label1POZIV")]
        private UltraLabel _label1POZIV;
        [AccessedThroughProperty("label1RAZDOBLJEDO")]
        private UltraLabel _label1RAZDOBLJEDO;
        [AccessedThroughProperty("label1RAZDOBLJEOD")]
        private UltraLabel _label1RAZDOBLJEOD;
        [AccessedThroughProperty("label1VALUTA")]
        private UltraLabel _label1VALUTA;
        [AccessedThroughProperty("label1ZAPREDUJAM")]
        private UltraLabel _label1ZAPREDUJAM;
        [AccessedThroughProperty("linkLabelRACUNRacunStavke")]
        private UltraLabel _linkLabelRACUNRacunStavke;
        [AccessedThroughProperty("linkLabelRACUNRacunStavkeAdd")]
        private UltraLabel _linkLabelRACUNRacunStavkeAdd;
        [AccessedThroughProperty("linkLabelRACUNRacunStavkeDelete")]
        private UltraLabel _linkLabelRACUNRacunStavkeDelete;
        [AccessedThroughProperty("linkLabelRACUNRacunStavkeUpdate")]
        private UltraLabel _linkLabelRACUNRacunStavkeUpdate;
        [AccessedThroughProperty("panelactionsRACUNRacunStavke")]
        private Panel _panelactionsRACUNRacunStavke;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDRACUN")]
        private UltraNumericEditor _textIDRACUN;
        [AccessedThroughProperty("textMODEL")]
        private UltraTextEditor _textMODEL;
        [AccessedThroughProperty("textNAPOMENA")]
        private UltraTextEditor _textNAPOMENA;
        [AccessedThroughProperty("textPOZIV")]
        private UltraTextEditor _textPOZIV;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRACUN;
        private BindingSource bindingSourceRACUNRacunStavke;
        private IContainer components;
        private RACUNDataSet dsRACUNDataSet1;
        protected TableLayoutPanel layoutManagerformRACUN;
        protected TableLayoutPanel layoutManagerpanelactionsRACUNRacunStavke;
        private bool m_AutoNumber;
        private GenericFormClass m_BaseMethods;
        private RACUNDataSet.RACUNRow m_CurrentRow;
        private ArrayList m_DataGrids;
        private string m_FirstLevelName;
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription;
        private DeklaritMode m_Mode;
        private string upisanibroj;

        [EventPublication("topic://RACUN.ButtonControl1.ClickEvent", PublicationScope.WorkItem)]
        public event EventHandler<EventArgs> ButtonControl1ClickEvent;

        [EventPublication("topic://RACUN.ButtonControl2.ClickEvent", PublicationScope.WorkItem)]
        public event EventHandler<EventArgs> ButtonControl2ClickEvent;

        [EventPublication("topic://RACUN.ButtonControl3.ClickEvent", PublicationScope.WorkItem)]
        public event EventHandler<EventArgs> ButtonControl3ClickEvent;

        [EventPublication("topic://RACUN.ButtonControl4.ClickEvent", PublicationScope.WorkItem)]
        public event EventHandler<EventArgs> ButtonControl4ClickEvent;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public RACUNFormUserControl()
        {
            base.Load += new EventHandler(this.RACUNFormUserControl_Load1);
            this.components = null;
            this.m_FrameworkDescription = StringResources.RACUNDescription;
            this.m_DataGrids = new ArrayList();
            this.m_FirstLevelName = "RACUN";
            this.m_AutoNumber = false;
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        public int Broj_Racuna()
        {
            int num = 0;
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.Text,
                CommandText = "SELECT MAX(CAST(IDRACUN AS INTEGER)) FROM RACUN WHERE RACUNGODINAIDGODINE = @GODINA"
            };
            command.Parameters.AddWithValue("@GODINA", mipsed.application.framework.Application.ActiveYear);
            command.Connection = connection;
            connection.Open();
            try
            {
                num = Convert.ToInt32(DB.N20(RuntimeHelpers.GetObjectValue(command.ExecuteScalar())));
                num++;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
            connection.Close();
            return num;
        }

        private void ButtonControl1_Click(object sender, EventArgs e)
        {
            if (this.ButtonControl1ClickEvent != null)
            {
                EventHandler<EventArgs> handler = this.ButtonControl1ClickEvent;
                if (handler != null)
                {
                    handler(RuntimeHelpers.GetObjectValue(sender), e);
                }
            }
        }

        private void ButtonControl2_Click(object sender, EventArgs e)
        {
            if (this.ButtonControl2ClickEvent != null)
            {
                EventHandler<EventArgs> handler = this.ButtonControl2ClickEvent;
                if (handler != null)
                {
                    handler(RuntimeHelpers.GetObjectValue(sender), e);
                }
            }
        }

        private void ButtonControl3_Click(object sender, EventArgs e)
        {
            if (this.ButtonControl3ClickEvent != null)
            {
                EventHandler<EventArgs> handler = this.ButtonControl3ClickEvent;
                if (handler != null)
                {
                    handler(RuntimeHelpers.GetObjectValue(sender), e);
                }
            }
        }

        private void ButtonControl4_Click(object sender, EventArgs e)
        {
            if (this.ButtonControl4ClickEvent != null)
            {
                EventHandler<EventArgs> handler = this.ButtonControl4ClickEvent;
                if (handler != null)
                {
                    handler(RuntimeHelpers.GetObjectValue(sender), e);
                }
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsRACUNDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceRACUN.DataSource = this.RACUNController.DataSet;
            this.dsRACUNDataSet1 = this.RACUNController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
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
            //if (this.InValidState())
            //{
            //    IEnumerator enumerator = null;
            //    try
            //    {
            //        enumerator = this.dsRACUNDataSet1.RACUN.Rows.GetEnumerator();
            //        while (enumerator.MoveNext())
            //        {
            //            ((DataRow) enumerator.Current).Delete();
            //        }
            //    }
            //    finally
            //    {
            //        if (enumerator is IDisposable)
            //        {
            //            (enumerator as IDisposable).Dispose();
            //        }
            //    }
            //    if (this.RACUNController.Update(this))
            //    {
            //        this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            //    }
            //}

            if (BrisanjeRacuna((int)textIDRACUN.Value))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private bool BrisanjeRacuna(int id_racuna)
        {
            try
            {
                Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

                client.ExecuteNonQuery("Delete From RACUNRacunStavke Where IDRACUN = " + id_racuna);

                client.ExecuteNonQuery("Delete From Racun Where IDRACUN = " + id_racuna);

                return true;
            }
            catch 
            {
                return false;
            }
        }

        private void dg_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGridColumn column = e.Cell.Column;
            if (column.CellActivation == Activation.AllowEdit)
            {
                string str = Conversions.ToString(column.Tag);
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

        [OnBuiltUp]
        public void Dodatno()
        {
            InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            this.datePickerDATUM.MinDate = mipsed.application.framework.Application.Pocetni;
            this.datePickerDATUM.MaxDate = mipsed.application.framework.Application.Zavrsni;
        }

        private void EndEditCurrentRow()
        {
            if (this.grdLevelRACUNRacunStavke.ActiveRow != null)
            {
                this.grdLevelRACUNRacunStavke.PerformAction(UltraGridAction.NextRow);
            }
        }

        private void grdLevelRACUNRacunStavke_AfterRowActivate(object sender, EventArgs e)
        {
            string rACUNRACUNRacunStavkeLevelDescription = StringResources.RACUNRACUNRacunStavkeLevelDescription;
            UltraGridRow activeRow = this.grdLevelRACUNRacunStavke.ActiveRow;
            this.linkLabelRACUNRacunStavkeAdd.Text = Deklarit.Resources.Resources.Add + " " + rACUNRACUNRacunStavkeLevelDescription;
            this.linkLabelRACUNRacunStavkeUpdate.Text = Deklarit.Resources.Resources.Update + " " + rACUNRACUNRacunStavkeLevelDescription;
            this.linkLabelRACUNRacunStavkeDelete.Text = Deklarit.Resources.Resources.Delete + " " + rACUNRACUNRacunStavkeLevelDescription;
        }

        private void grdLevelRACUNRacunStavke_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceRACUN.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceRACUN.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelRACUNRacunStavke_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.RACUNRacunStavkeUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelRACUNRacunStavke_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceRACUN, this.RACUNController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RACUN", this.m_Mode, this.dsRACUNDataSet1, this.dsRACUNDataSet1.RACUN.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding5 = new Binding("CheckState", this.bindingSourceRACUN, "ZAPREDUJAM", true);
            binding5.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding5.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkZAPREDUJAM.DataBindings["CheckState"] != null)
            {
                this.checkZAPREDUJAM.DataBindings.Remove(this.checkZAPREDUJAM.DataBindings["CheckState"]);
            }
            this.checkZAPREDUJAM.DataBindings.Add(binding5);
            Binding binding = new Binding("Text", this.bindingSourceRACUN, "DATUM", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerDATUM.DataBindings["Text"] != null)
            {
                this.datePickerDATUM.DataBindings.Remove(this.datePickerDATUM.DataBindings["Text"]);
            }
            this.datePickerDATUM.DataBindings.Add(binding);
            Binding binding4 = new Binding("Text", this.bindingSourceRACUN, "VALUTA", true);
            binding4.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding4.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerVALUTA.DataBindings["Text"] != null)
            {
                this.datePickerVALUTA.DataBindings.Remove(this.datePickerVALUTA.DataBindings["Text"]);
            }
            this.datePickerVALUTA.DataBindings.Add(binding4);
            Binding binding3 = new Binding("Text", this.bindingSourceRACUN, "RAZDOBLJEOD", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding3.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParse);
            if (this.datePickerRAZDOBLJEOD.DataBindings["Text"] != null)
            {
                this.datePickerRAZDOBLJEOD.DataBindings.Remove(this.datePickerRAZDOBLJEOD.DataBindings["Text"]);
            }
            this.datePickerRAZDOBLJEOD.DataBindings.Add(binding3);
            Binding binding2 = new Binding("Text", this.bindingSourceRACUN, "RAZDOBLJEDO", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding2.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParse);
            if (this.datePickerRAZDOBLJEDO.DataBindings["Text"] != null)
            {
                this.datePickerRAZDOBLJEDO.DataBindings.Remove(this.datePickerRAZDOBLJEDO.DataBindings["Text"]);
            }
            this.datePickerRAZDOBLJEDO.DataBindings.Add(binding2);
            if (!this.m_DataGrids.Contains(this.grdLevelRACUNRacunStavke))
            {
                this.m_DataGrids.Add(this.grdLevelRACUNRacunStavke);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsRACUNDataSet1.RACUN[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RACUNDataSet.RACUNRow) ((DataRowView) this.bindingSourceRACUN.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(RACUNFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRACUN = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRACUN).BeginInit();
            this.bindingSourceRACUNRacunStavke = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRACUNRacunStavke).BeginInit();
            this.layoutManagerformRACUN = new TableLayoutPanel();
            this.layoutManagerformRACUN.SuspendLayout();
            this.layoutManagerformRACUN.AutoSize = true;
            this.layoutManagerformRACUN.Dock = DockStyle.Fill;
            this.layoutManagerformRACUN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRACUN.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRACUN.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRACUN.Size = size;
            this.layoutManagerformRACUN.ColumnCount = 4;
            this.layoutManagerformRACUN.RowCount = 12;
            this.layoutManagerformRACUN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRACUN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRACUN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRACUN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUN.RowStyles.Add(new RowStyle());
            this.layoutManagerformRACUN.RowStyles.Add(new RowStyle());
            this.label1ZAPREDUJAM = new UltraLabel();
            this.checkZAPREDUJAM = new UltraCheckEditor();
            this.label1IDRACUN = new UltraLabel();
            this.textIDRACUN = new UltraNumericEditor();
            this.label1IDPARTNER = new UltraLabel();
            this.comboIDPARTNER = new PARTNERComboBox();
            this.label1DATUM = new UltraLabel();
            this.datePickerDATUM = new UltraDateTimeEditor();
            this.label1VALUTA = new UltraLabel();
            this.datePickerVALUTA = new UltraDateTimeEditor();
            this.label1RAZDOBLJEOD = new UltraLabel();
            this.datePickerRAZDOBLJEOD = new UltraDateTimeEditor();
            this.label1RAZDOBLJEDO = new UltraLabel();
            this.datePickerRAZDOBLJEDO = new UltraDateTimeEditor();
            this.label1NAPOMENA = new UltraLabel();
            this.textNAPOMENA = new UltraTextEditor();
            this.label1MODEL = new UltraLabel();
            this.textMODEL = new UltraTextEditor();
            this.label1POZIV = new UltraLabel();
            this.textPOZIV = new UltraTextEditor();
            this.grdLevelRACUNRacunStavke = new UltraGrid();
            this.panelactionsRACUNRacunStavke = new Panel();
            this.layoutManagerpanelactionsRACUNRacunStavke = new TableLayoutPanel();
            this.layoutManagerpanelactionsRACUNRacunStavke.AutoSize = true;
            this.layoutManagerpanelactionsRACUNRacunStavke.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsRACUNRacunStavke.ColumnCount = 4;
            this.layoutManagerpanelactionsRACUNRacunStavke.RowCount = 1;
            this.layoutManagerpanelactionsRACUNRacunStavke.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsRACUNRacunStavke.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRACUNRacunStavke.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRACUNRacunStavke.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRACUNRacunStavke.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsRACUNRacunStavke.RowStyles.Add(new RowStyle());
            this.linkLabelRACUNRacunStavkeAdd = new UltraLabel();
            this.linkLabelRACUNRacunStavkeUpdate = new UltraLabel();
            this.linkLabelRACUNRacunStavkeDelete = new UltraLabel();
            this.linkLabelRACUNRacunStavke = new UltraLabel();
            this.ButtonControl3 = new Button();
            this.ButtonControl1 = new Button();
            this.ButtonControl2 = new Button();
            this.ButtonControl4 = new Button();
            ((ISupportInitialize) this.textIDRACUN).BeginInit();
            ((ISupportInitialize) this.textNAPOMENA).BeginInit();
            ((ISupportInitialize) this.textMODEL).BeginInit();
            ((ISupportInitialize) this.textPOZIV).BeginInit();
            ((ISupportInitialize) this.grdLevelRACUNRacunStavke).BeginInit();
            this.panelactionsRACUNRacunStavke.SuspendLayout();
            this.layoutManagerpanelactionsRACUNRacunStavke.SuspendLayout();
            UltraGridBand band = new UltraGridBand("RACUNRacunStavke", -1);
            UltraGridColumn column9 = new UltraGridColumn("IDRACUN");
            UltraGridColumn column21 = new UltraGridColumn("RACUNGODINAIDGODINE");
            UltraGridColumn column = new UltraGridColumn("BROJSTAVKE");
            UltraGridColumn column7 = new UltraGridColumn("IDPROIZVOD");
            UltraGridColumn column8 = new UltraGridColumn("columnIDPROIZVODAddNew", 0);
            UltraGridColumn column16 = new UltraGridColumn("NAZIVPROIZVOD");
            UltraGridColumn column17 = new UltraGridColumn("NAZIVPROIZVODRACUN");
            UltraGridColumn column2 = new UltraGridColumn("CIJENA");
            UltraGridColumn column3 = new UltraGridColumn("CIJENARACUN");
            UltraGridColumn column20 = new UltraGridColumn("RABAT");
            UltraGridColumn column14 = new UltraGridColumn("KOLICINA");
            UltraGridColumn column5 = new UltraGridColumn("FINPOREZSTOPARACUN");
            UltraGridColumn column4 = new UltraGridColumn("FINPOREZSTOPA");
            UltraGridColumn column13 = new UltraGridColumn("IZNOSRACUN");
            UltraGridColumn column12 = new UltraGridColumn("IZNOSRABATA");
            UltraGridColumn column10 = new UltraGridColumn("IZNOSMINUSRABAT");
            UltraGridColumn column19 = new UltraGridColumn("PDV");
            UltraGridColumn column11 = new UltraGridColumn("IZNOSPLUSPDV");
            UltraGridColumn column6 = new UltraGridColumn("IDJEDINICAMJERE");
            UltraGridColumn column15 = new UltraGridColumn("NAZIVJEDINICAMJERE");
            UltraGridColumn column18 = new UltraGridColumn("OSNOVICAUKNIZIIRA");
            this.dsRACUNDataSet1 = new RACUNDataSet();
            this.dsRACUNDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRACUNDataSet1.DataSetName = "dsRACUN";
            this.dsRACUNDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRACUN.DataSource = this.dsRACUNDataSet1;
            this.bindingSourceRACUN.DataMember = "RACUN";
            ((ISupportInitialize) this.bindingSourceRACUN).BeginInit();
            this.bindingSourceRACUNRacunStavke.DataSource = this.bindingSourceRACUN;
            this.bindingSourceRACUNRacunStavke.DataMember = "RACUN_RACUNRacunStavke";
            point = new System.Drawing.Point(0, 0);
            this.label1ZAPREDUJAM.Location = point;
            this.label1ZAPREDUJAM.Name = "label1ZAPREDUJAM";
            this.label1ZAPREDUJAM.TabIndex = 1;
            this.label1ZAPREDUJAM.Tag = "labelZAPREDUJAM";
            this.label1ZAPREDUJAM.Text = "Rn.za predujam:";
            this.label1ZAPREDUJAM.StyleSetName = "FieldUltraLabel";
            this.label1ZAPREDUJAM.AutoSize = true;
            this.label1ZAPREDUJAM.Anchor = AnchorStyles.Left;
            this.label1ZAPREDUJAM.Appearance.TextVAlign = VAlign.Middle;
            this.label1ZAPREDUJAM.Appearance.ForeColor = Color.Black;
            this.label1ZAPREDUJAM.BackColor = Color.Transparent;
            this.layoutManagerformRACUN.Controls.Add(this.label1ZAPREDUJAM, 0, 0);
            this.layoutManagerformRACUN.SetColumnSpan(this.label1ZAPREDUJAM, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.label1ZAPREDUJAM, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1ZAPREDUJAM.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ZAPREDUJAM.MinimumSize = size;
            size = new System.Drawing.Size(0x75, 0x17);
            this.label1ZAPREDUJAM.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.checkZAPREDUJAM.Location = point;
            this.checkZAPREDUJAM.Name = "checkZAPREDUJAM";
            this.checkZAPREDUJAM.Tag = "ZAPREDUJAM";
            this.checkZAPREDUJAM.TabIndex = 0;
            this.checkZAPREDUJAM.Anchor = AnchorStyles.Left;
            this.checkZAPREDUJAM.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.checkZAPREDUJAM.Enabled = true;
            this.layoutManagerformRACUN.Controls.Add(this.checkZAPREDUJAM, 1, 0);
            this.layoutManagerformRACUN.SetColumnSpan(this.checkZAPREDUJAM, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.checkZAPREDUJAM, 1);
            padding = new Padding(0, 1, 3, 2);
            this.checkZAPREDUJAM.Margin = padding;
            size = new System.Drawing.Size(13, 13);
            this.checkZAPREDUJAM.MinimumSize = size;
            size = new System.Drawing.Size(13, 13);
            this.checkZAPREDUJAM.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDRACUN.Location = point;
            this.label1IDRACUN.Name = "label1IDRACUN";
            this.label1IDRACUN.TabIndex = 1;
            this.label1IDRACUN.Tag = "labelIDRACUN";
            this.label1IDRACUN.Text = "Račun:";
            this.label1IDRACUN.StyleSetName = "FieldUltraLabel";
            this.label1IDRACUN.AutoSize = true;
            this.label1IDRACUN.Anchor = AnchorStyles.Left;
            this.label1IDRACUN.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDRACUN.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDRACUN.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDRACUN.ImageSize = size;
            this.label1IDRACUN.Appearance.ForeColor = Color.Black;
            this.label1IDRACUN.BackColor = Color.Transparent;
            this.layoutManagerformRACUN.Controls.Add(this.label1IDRACUN, 0, 1);
            this.layoutManagerformRACUN.SetColumnSpan(this.label1IDRACUN, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.label1IDRACUN, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDRACUN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDRACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x17);
            this.label1IDRACUN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDRACUN.Location = point;
            this.textIDRACUN.Name = "textIDRACUN";
            this.textIDRACUN.Tag = "IDRACUN";
            this.textIDRACUN.TabIndex = 0;
            this.textIDRACUN.Anchor = AnchorStyles.Left;
            this.textIDRACUN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDRACUN.ReadOnly = false;
            this.textIDRACUN.PromptChar = ' ';
            this.textIDRACUN.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDRACUN.DataBindings.Add(new Binding("Value", this.bindingSourceRACUN, "IDRACUN"));
            this.textIDRACUN.NumericType = NumericType.Integer;
            this.textIDRACUN.MaskInput = "{LOC}-nnnnnn";
            this.layoutManagerformRACUN.Controls.Add(this.textIDRACUN, 1, 1);
            this.layoutManagerformRACUN.SetColumnSpan(this.textIDRACUN, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.textIDRACUN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDRACUN.Margin = padding;
            size = new System.Drawing.Size(0x3a, 0x16);
            this.textIDRACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x3a, 0x16);
            this.textIDRACUN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDPARTNER.Location = point;
            this.label1IDPARTNER.Name = "label1IDPARTNER";
            this.label1IDPARTNER.TabIndex = 1;
            this.label1IDPARTNER.Tag = "labelIDPARTNER";
            this.label1IDPARTNER.Text = "Šif. partnera:";
            this.label1IDPARTNER.StyleSetName = "FieldUltraLabel";
            this.label1IDPARTNER.AutoSize = true;
            this.label1IDPARTNER.Anchor = AnchorStyles.Left;
            this.label1IDPARTNER.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDPARTNER.Appearance.ForeColor = Color.Black;
            this.label1IDPARTNER.BackColor = Color.Transparent;
            this.layoutManagerformRACUN.Controls.Add(this.label1IDPARTNER, 0, 2);
            this.layoutManagerformRACUN.SetColumnSpan(this.label1IDPARTNER, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.label1IDPARTNER, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDPARTNER.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDPARTNER.MinimumSize = size;
            size = new System.Drawing.Size(0x60, 0x17);
            this.label1IDPARTNER.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDPARTNER.Location = point;
            this.comboIDPARTNER.Name = "comboIDPARTNER";
            this.comboIDPARTNER.Tag = "IDPARTNER";
            this.comboIDPARTNER.TabIndex = 0;
            this.comboIDPARTNER.Anchor = AnchorStyles.Left;
            this.comboIDPARTNER.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDPARTNER.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDPARTNER.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDPARTNER.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDPARTNER.Enabled = true;
            this.comboIDPARTNER.DataBindings.Add(new Binding("Value", this.bindingSourceRACUN, "IDPARTNER"));
            this.comboIDPARTNER.ShowPictureBox = true;
            this.comboIDPARTNER.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDPARTNER);
            this.comboIDPARTNER.ValueMember = "IDPARTNER";
            this.comboIDPARTNER.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDPARTNER);
            this.layoutManagerformRACUN.Controls.Add(this.comboIDPARTNER, 1, 2);
            this.layoutManagerformRACUN.SetColumnSpan(this.comboIDPARTNER, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.comboIDPARTNER, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDPARTNER.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDPARTNER.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDPARTNER.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1DATUM.Location = point;
            this.label1DATUM.Name = "label1DATUM";
            this.label1DATUM.TabIndex = 1;
            this.label1DATUM.Tag = "labelDATUM";
            this.label1DATUM.Text = "Datum:";
            this.label1DATUM.StyleSetName = "FieldUltraLabel";
            this.label1DATUM.AutoSize = true;
            this.label1DATUM.Anchor = AnchorStyles.Left;
            this.label1DATUM.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUM.Appearance.ForeColor = Color.Black;
            this.label1DATUM.BackColor = Color.Transparent;
            this.layoutManagerformRACUN.Controls.Add(this.label1DATUM, 0, 3);
            this.layoutManagerformRACUN.SetColumnSpan(this.label1DATUM, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.label1DATUM, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1DATUM.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1DATUM.MinimumSize = size;
            size = new System.Drawing.Size(0x3d, 0x17);
            this.label1DATUM.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerDATUM.Location = point;
            this.datePickerDATUM.Name = "datePickerDATUM";
            this.datePickerDATUM.Tag = "DATUM";
            this.datePickerDATUM.TabIndex = 0;
            this.datePickerDATUM.Anchor = AnchorStyles.Left;
            this.datePickerDATUM.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUM.Enabled = true;
            this.layoutManagerformRACUN.Controls.Add(this.datePickerDATUM, 1, 3);
            this.layoutManagerformRACUN.SetColumnSpan(this.datePickerDATUM, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.datePickerDATUM, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerDATUM.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUM.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUM.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1VALUTA.Location = point;
            this.label1VALUTA.Name = "label1VALUTA";
            this.label1VALUTA.TabIndex = 1;
            this.label1VALUTA.Tag = "labelVALUTA";
            this.label1VALUTA.Text = "Valuta:";
            this.label1VALUTA.StyleSetName = "FieldUltraLabel";
            this.label1VALUTA.AutoSize = true;
            this.label1VALUTA.Anchor = AnchorStyles.Left;
            this.label1VALUTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1VALUTA.Appearance.ForeColor = Color.Black;
            this.label1VALUTA.BackColor = Color.Transparent;
            this.layoutManagerformRACUN.Controls.Add(this.label1VALUTA, 0, 4);
            this.layoutManagerformRACUN.SetColumnSpan(this.label1VALUTA, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.label1VALUTA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1VALUTA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1VALUTA.MinimumSize = size;
            size = new System.Drawing.Size(0x3b, 0x17);
            this.label1VALUTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerVALUTA.Location = point;
            this.datePickerVALUTA.Name = "datePickerVALUTA";
            this.datePickerVALUTA.Tag = "VALUTA";
            this.datePickerVALUTA.TabIndex = 0;
            this.datePickerVALUTA.Anchor = AnchorStyles.Left;
            this.datePickerVALUTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerVALUTA.Enabled = true;
            this.layoutManagerformRACUN.Controls.Add(this.datePickerVALUTA, 1, 4);
            this.layoutManagerformRACUN.SetColumnSpan(this.datePickerVALUTA, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.datePickerVALUTA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerVALUTA.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerVALUTA.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerVALUTA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RAZDOBLJEOD.Location = point;
            this.label1RAZDOBLJEOD.Name = "label1RAZDOBLJEOD";
            this.label1RAZDOBLJEOD.TabIndex = 1;
            this.label1RAZDOBLJEOD.Tag = "labelRAZDOBLJEOD";
            this.label1RAZDOBLJEOD.Text = "Od:";
            this.label1RAZDOBLJEOD.StyleSetName = "FieldUltraLabel";
            this.label1RAZDOBLJEOD.AutoSize = true;
            this.label1RAZDOBLJEOD.Anchor = AnchorStyles.Left;
            this.label1RAZDOBLJEOD.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAZDOBLJEOD.Appearance.ForeColor = Color.Black;
            this.label1RAZDOBLJEOD.BackColor = Color.Transparent;
            this.layoutManagerformRACUN.Controls.Add(this.label1RAZDOBLJEOD, 0, 5);
            this.layoutManagerformRACUN.SetColumnSpan(this.label1RAZDOBLJEOD, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.label1RAZDOBLJEOD, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RAZDOBLJEOD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAZDOBLJEOD.MinimumSize = size;
            size = new System.Drawing.Size(0x24, 0x17);
            this.label1RAZDOBLJEOD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerRAZDOBLJEOD.Location = point;
            this.datePickerRAZDOBLJEOD.Name = "datePickerRAZDOBLJEOD";
            this.datePickerRAZDOBLJEOD.Tag = "RAZDOBLJEOD";
            this.datePickerRAZDOBLJEOD.TabIndex = 0;
            this.datePickerRAZDOBLJEOD.Anchor = AnchorStyles.Left;
            this.datePickerRAZDOBLJEOD.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerRAZDOBLJEOD.ContextMenu = this.contextMenu1;
            this.datePickerRAZDOBLJEOD.Enabled = true;
            this.layoutManagerformRACUN.Controls.Add(this.datePickerRAZDOBLJEOD, 1, 5);
            this.layoutManagerformRACUN.SetColumnSpan(this.datePickerRAZDOBLJEOD, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.datePickerRAZDOBLJEOD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerRAZDOBLJEOD.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerRAZDOBLJEOD.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerRAZDOBLJEOD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RAZDOBLJEDO.Location = point;
            this.label1RAZDOBLJEDO.Name = "label1RAZDOBLJEDO";
            this.label1RAZDOBLJEDO.TabIndex = 1;
            this.label1RAZDOBLJEDO.Tag = "labelRAZDOBLJEDO";
            this.label1RAZDOBLJEDO.Text = "Do:";
            this.label1RAZDOBLJEDO.StyleSetName = "FieldUltraLabel";
            this.label1RAZDOBLJEDO.AutoSize = true;
            this.label1RAZDOBLJEDO.Anchor = AnchorStyles.Left;
            this.label1RAZDOBLJEDO.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAZDOBLJEDO.Appearance.ForeColor = Color.Black;
            this.label1RAZDOBLJEDO.BackColor = Color.Transparent;
            this.layoutManagerformRACUN.Controls.Add(this.label1RAZDOBLJEDO, 0, 6);
            this.layoutManagerformRACUN.SetColumnSpan(this.label1RAZDOBLJEDO, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.label1RAZDOBLJEDO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RAZDOBLJEDO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAZDOBLJEDO.MinimumSize = size;
            size = new System.Drawing.Size(0x24, 0x17);
            this.label1RAZDOBLJEDO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerRAZDOBLJEDO.Location = point;
            this.datePickerRAZDOBLJEDO.Name = "datePickerRAZDOBLJEDO";
            this.datePickerRAZDOBLJEDO.Tag = "RAZDOBLJEDO";
            this.datePickerRAZDOBLJEDO.TabIndex = 0;
            this.datePickerRAZDOBLJEDO.Anchor = AnchorStyles.Left;
            this.datePickerRAZDOBLJEDO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerRAZDOBLJEDO.ContextMenu = this.contextMenu1;
            this.datePickerRAZDOBLJEDO.Enabled = true;
            this.layoutManagerformRACUN.Controls.Add(this.datePickerRAZDOBLJEDO, 1, 6);
            this.layoutManagerformRACUN.SetColumnSpan(this.datePickerRAZDOBLJEDO, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.datePickerRAZDOBLJEDO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerRAZDOBLJEDO.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerRAZDOBLJEDO.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerRAZDOBLJEDO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAPOMENA.Location = point;
            this.label1NAPOMENA.Name = "label1NAPOMENA";
            this.label1NAPOMENA.TabIndex = 1;
            this.label1NAPOMENA.Tag = "labelNAPOMENA";
            this.label1NAPOMENA.Text = "NAPOMENA:";
            this.label1NAPOMENA.StyleSetName = "FieldUltraLabel";
            this.label1NAPOMENA.AutoSize = true;
            this.label1NAPOMENA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1NAPOMENA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAPOMENA.Appearance.ForeColor = Color.Black;
            this.label1NAPOMENA.BackColor = Color.Transparent;
            this.layoutManagerformRACUN.Controls.Add(this.label1NAPOMENA, 0, 7);
            this.layoutManagerformRACUN.SetColumnSpan(this.label1NAPOMENA, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.label1NAPOMENA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAPOMENA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAPOMENA.MinimumSize = size;
            size = new System.Drawing.Size(0x5b, 0x17);
            this.label1NAPOMENA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAPOMENA.Location = point;
            this.textNAPOMENA.Name = "textNAPOMENA";
            this.textNAPOMENA.Tag = "NAPOMENA";
            this.textNAPOMENA.TabIndex = 0;
            this.textNAPOMENA.Anchor = AnchorStyles.Left;
            this.textNAPOMENA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAPOMENA.ContextMenu = this.contextMenu1;
            this.textNAPOMENA.ReadOnly = false;
            this.textNAPOMENA.DataBindings.Add(new Binding("Text", this.bindingSourceRACUN, "NAPOMENA"));
            this.textNAPOMENA.Nullable = true;
            this.textNAPOMENA.Multiline = true;
            this.textNAPOMENA.MaxLength = 200;
            this.layoutManagerformRACUN.Controls.Add(this.textNAPOMENA, 1, 7);
            this.layoutManagerformRACUN.SetColumnSpan(this.textNAPOMENA, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.textNAPOMENA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAPOMENA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.textNAPOMENA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.textNAPOMENA.Size = size;
            this.textNAPOMENA.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.label1MODEL.Location = point;
            this.label1MODEL.Name = "label1MODEL";
            this.label1MODEL.TabIndex = 1;
            this.label1MODEL.Tag = "labelMODEL";
            this.label1MODEL.Text = "MODEL:";
            this.label1MODEL.StyleSetName = "FieldUltraLabel";
            this.label1MODEL.AutoSize = true;
            this.label1MODEL.Anchor = AnchorStyles.Left;
            this.label1MODEL.Appearance.TextVAlign = VAlign.Middle;
            this.label1MODEL.Appearance.ForeColor = Color.Black;
            this.label1MODEL.BackColor = Color.Transparent;
            this.layoutManagerformRACUN.Controls.Add(this.label1MODEL, 0, 8);
            this.layoutManagerformRACUN.SetColumnSpan(this.label1MODEL, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.label1MODEL, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MODEL.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MODEL.MinimumSize = size;
            size = new System.Drawing.Size(0x40, 0x17);
            this.label1MODEL.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMODEL.Location = point;
            this.textMODEL.Name = "textMODEL";
            this.textMODEL.Tag = "MODEL";
            this.textMODEL.TabIndex = 0;
            this.textMODEL.Anchor = AnchorStyles.Left;
            this.textMODEL.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMODEL.ReadOnly = false;
            this.textMODEL.DataBindings.Add(new Binding("Text", this.bindingSourceRACUN, "MODEL"));
            this.textMODEL.MaxLength = 2;
            this.layoutManagerformRACUN.Controls.Add(this.textMODEL, 1, 8);
            this.layoutManagerformRACUN.SetColumnSpan(this.textMODEL, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.textMODEL, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMODEL.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textMODEL.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textMODEL.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POZIV.Location = point;
            this.label1POZIV.Name = "label1POZIV";
            this.label1POZIV.TabIndex = 1;
            this.label1POZIV.Tag = "labelPOZIV";
            this.label1POZIV.Text = "Poziv na broj:";
            this.label1POZIV.StyleSetName = "FieldUltraLabel";
            this.label1POZIV.AutoSize = true;
            this.label1POZIV.Anchor = AnchorStyles.Left;
            this.label1POZIV.Appearance.TextVAlign = VAlign.Middle;
            this.label1POZIV.Appearance.ForeColor = Color.Black;
            this.label1POZIV.BackColor = Color.Transparent;
            this.layoutManagerformRACUN.Controls.Add(this.label1POZIV, 0, 9);
            this.layoutManagerformRACUN.SetColumnSpan(this.label1POZIV, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.label1POZIV, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POZIV.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POZIV.MinimumSize = size;
            size = new System.Drawing.Size(100, 0x17);
            this.label1POZIV.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPOZIV.Location = point;
            this.textPOZIV.Name = "textPOZIV";
            this.textPOZIV.Tag = "POZIV";
            this.textPOZIV.TabIndex = 0;
            this.textPOZIV.Anchor = AnchorStyles.Left;
            this.textPOZIV.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPOZIV.ReadOnly = false;
            this.textPOZIV.DataBindings.Add(new Binding("Text", this.bindingSourceRACUN, "POZIV"));
            this.textPOZIV.MaxLength = 22;
            this.layoutManagerformRACUN.Controls.Add(this.textPOZIV, 1, 9);
            this.layoutManagerformRACUN.SetColumnSpan(this.textPOZIV, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.textPOZIV, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPOZIV.Margin = padding;
            size = new System.Drawing.Size(0xa3, 0x16);
            this.textPOZIV.MinimumSize = size;
            size = new System.Drawing.Size(0xa3, 0x16);
            this.textPOZIV.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelRACUNRacunStavke.Location = point;
            this.grdLevelRACUNRacunStavke.Name = "grdLevelRACUNRacunStavke";
            this.layoutManagerformRACUN.Controls.Add(this.grdLevelRACUNRacunStavke, 0, 10);
            this.layoutManagerformRACUN.SetColumnSpan(this.grdLevelRACUNRacunStavke, 2);
            this.layoutManagerformRACUN.SetRowSpan(this.grdLevelRACUNRacunStavke, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelRACUNRacunStavke.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelRACUNRacunStavke.MinimumSize = size;
            size = new System.Drawing.Size(0x252, 200);
            this.grdLevelRACUNRacunStavke.Size = size;
            this.grdLevelRACUNRacunStavke.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsRACUNRacunStavke.Location = point;
            this.panelactionsRACUNRacunStavke.Name = "panelactionsRACUNRacunStavke";
            this.panelactionsRACUNRacunStavke.BackColor = Color.Transparent;
            this.panelactionsRACUNRacunStavke.Controls.Add(this.layoutManagerpanelactionsRACUNRacunStavke);
            this.layoutManagerformRACUN.Controls.Add(this.panelactionsRACUNRacunStavke, 0, 11);
            this.layoutManagerformRACUN.SetColumnSpan(this.panelactionsRACUNRacunStavke, 2);
            this.layoutManagerformRACUN.SetRowSpan(this.panelactionsRACUNRacunStavke, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsRACUNRacunStavke.Margin = padding;
            size = new System.Drawing.Size(0x192, 0x19);
            this.panelactionsRACUNRacunStavke.MinimumSize = size;
            size = new System.Drawing.Size(0x192, 0x19);
            this.panelactionsRACUNRacunStavke.Size = size;
            this.panelactionsRACUNRacunStavke.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRACUNRacunStavkeAdd.Location = point;
            this.linkLabelRACUNRacunStavkeAdd.Name = "linkLabelRACUNRacunStavkeAdd";
            size = new System.Drawing.Size(110, 15);
            this.linkLabelRACUNRacunStavkeAdd.Size = size;
            this.linkLabelRACUNRacunStavkeAdd.Text = " Add Stavke racuna  ";
            this.linkLabelRACUNRacunStavkeAdd.Click += new EventHandler(this.RACUNRacunStavkeAdd_Click);
            this.linkLabelRACUNRacunStavkeAdd.BackColor = Color.Transparent;
            this.linkLabelRACUNRacunStavkeAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelRACUNRacunStavkeAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRACUNRacunStavkeAdd.Cursor = Cursors.Hand;
            this.linkLabelRACUNRacunStavkeAdd.AutoSize = true;
            this.layoutManagerpanelactionsRACUNRacunStavke.Controls.Add(this.linkLabelRACUNRacunStavkeAdd, 0, 0);
            this.layoutManagerpanelactionsRACUNRacunStavke.SetColumnSpan(this.linkLabelRACUNRacunStavkeAdd, 1);
            this.layoutManagerpanelactionsRACUNRacunStavke.SetRowSpan(this.linkLabelRACUNRacunStavkeAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRACUNRacunStavkeAdd.Margin = padding;
            size = new System.Drawing.Size(110, 15);
            this.linkLabelRACUNRacunStavkeAdd.MinimumSize = size;
            size = new System.Drawing.Size(110, 15);
            this.linkLabelRACUNRacunStavkeAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRACUNRacunStavkeUpdate.Location = point;
            this.linkLabelRACUNRacunStavkeUpdate.Name = "linkLabelRACUNRacunStavkeUpdate";
            size = new System.Drawing.Size(0x80, 15);
            this.linkLabelRACUNRacunStavkeUpdate.Size = size;
            this.linkLabelRACUNRacunStavkeUpdate.Text = " Update Stavke racuna  ";
            this.linkLabelRACUNRacunStavkeUpdate.Click += new EventHandler(this.RACUNRacunStavkeUpdate_Click);
            this.linkLabelRACUNRacunStavkeUpdate.BackColor = Color.Transparent;
            this.linkLabelRACUNRacunStavkeUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelRACUNRacunStavkeUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRACUNRacunStavkeUpdate.Cursor = Cursors.Hand;
            this.linkLabelRACUNRacunStavkeUpdate.AutoSize = true;
            this.layoutManagerpanelactionsRACUNRacunStavke.Controls.Add(this.linkLabelRACUNRacunStavkeUpdate, 1, 0);
            this.layoutManagerpanelactionsRACUNRacunStavke.SetColumnSpan(this.linkLabelRACUNRacunStavkeUpdate, 1);
            this.layoutManagerpanelactionsRACUNRacunStavke.SetRowSpan(this.linkLabelRACUNRacunStavkeUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRACUNRacunStavkeUpdate.Margin = padding;
            size = new System.Drawing.Size(0x80, 15);
            this.linkLabelRACUNRacunStavkeUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x80, 15);
            this.linkLabelRACUNRacunStavkeUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRACUNRacunStavkeDelete.Location = point;
            this.linkLabelRACUNRacunStavkeDelete.Name = "linkLabelRACUNRacunStavkeDelete";
            size = new System.Drawing.Size(0x7c, 15);
            this.linkLabelRACUNRacunStavkeDelete.Size = size;
            this.linkLabelRACUNRacunStavkeDelete.Text = " Delete Stavke racuna  ";
            this.linkLabelRACUNRacunStavkeDelete.Click += new EventHandler(this.RACUNRacunStavkeDelete_Click);
            this.linkLabelRACUNRacunStavkeDelete.BackColor = Color.Transparent;
            this.linkLabelRACUNRacunStavkeDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelRACUNRacunStavkeDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelRACUNRacunStavkeDelete.Cursor = Cursors.Hand;
            this.linkLabelRACUNRacunStavkeDelete.AutoSize = true;
            this.layoutManagerpanelactionsRACUNRacunStavke.Controls.Add(this.linkLabelRACUNRacunStavkeDelete, 2, 0);
            this.layoutManagerpanelactionsRACUNRacunStavke.SetColumnSpan(this.linkLabelRACUNRacunStavkeDelete, 1);
            this.layoutManagerpanelactionsRACUNRacunStavke.SetRowSpan(this.linkLabelRACUNRacunStavkeDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRACUNRacunStavkeDelete.Margin = padding;
            size = new System.Drawing.Size(0x7c, 15);
            this.linkLabelRACUNRacunStavkeDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x7c, 15);
            this.linkLabelRACUNRacunStavkeDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelRACUNRacunStavke.Location = point;
            this.linkLabelRACUNRacunStavke.Name = "linkLabelRACUNRacunStavke";
            this.layoutManagerpanelactionsRACUNRacunStavke.Controls.Add(this.linkLabelRACUNRacunStavke, 3, 0);
            this.layoutManagerpanelactionsRACUNRacunStavke.SetColumnSpan(this.linkLabelRACUNRacunStavke, 1);
            this.layoutManagerpanelactionsRACUNRacunStavke.SetRowSpan(this.linkLabelRACUNRacunStavke, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelRACUNRacunStavke.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRACUNRacunStavke.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelRACUNRacunStavke.Size = size;
            this.linkLabelRACUNRacunStavke.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.ButtonControl3.Location = point;
            this.ButtonControl3.Name = "ButtonControl3";
            this.ButtonControl3.AutoSize = true;
            this.ButtonControl3.Text = "PDV Napomena1";
            this.ButtonControl3.Click += new EventHandler(this.ButtonControl3_Click);
            this.layoutManagerformRACUN.Controls.Add(this.ButtonControl3, 2, 6);
            this.layoutManagerformRACUN.SetColumnSpan(this.ButtonControl3, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.ButtonControl3, 1);
            padding = new Padding(2, 2, 2, 2);
            this.ButtonControl3.Margin = padding;
            size = new System.Drawing.Size(4, 4);
            this.ButtonControl3.MinimumSize = size;
            size = new System.Drawing.Size(4, 4);
            this.ButtonControl3.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.ButtonControl1.Location = point;
            this.ButtonControl1.Name = "ButtonControl1";
            this.ButtonControl1.AutoSize = true;
            this.ButtonControl1.Text = "Kontrolni broj";
            this.ButtonControl1.Click += new EventHandler(this.ButtonControl1_Click);
            this.layoutManagerformRACUN.Controls.Add(this.ButtonControl1, 2, 7);
            this.layoutManagerformRACUN.SetColumnSpan(this.ButtonControl1, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.ButtonControl1, 1);
            padding = new Padding(2, 2, 2, 2);
            this.ButtonControl1.Margin = padding;
            size = new System.Drawing.Size(4, 4);
            this.ButtonControl1.MinimumSize = size;
            size = new System.Drawing.Size(4, 4);
            this.ButtonControl1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.ButtonControl2.Location = point;
            this.ButtonControl2.Name = "ButtonControl2";
            this.ButtonControl2.AutoSize = true;
            this.ButtonControl2.Text = "Dopuni model i poziv na broj";
            this.ButtonControl2.Click += new EventHandler(this.ButtonControl2_Click);
            this.layoutManagerformRACUN.Controls.Add(this.ButtonControl2, 2, 8);
            this.layoutManagerformRACUN.SetColumnSpan(this.ButtonControl2, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.ButtonControl2, 1);
            padding = new Padding(2, 2, 2, 2);
            this.ButtonControl2.Margin = padding;
            size = new System.Drawing.Size(4, 4);
            this.ButtonControl2.MinimumSize = size;
            size = new System.Drawing.Size(4, 4);
            this.ButtonControl2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.ButtonControl4.Location = point;
            this.ButtonControl4.Name = "ButtonControl4";
            this.ButtonControl4.AutoSize = true;
            this.ButtonControl4.Text = "PDV Napomena2";
            this.ButtonControl4.Click += new EventHandler(this.ButtonControl4_Click);
            this.layoutManagerformRACUN.Controls.Add(this.ButtonControl4, 3, 6);
            this.layoutManagerformRACUN.SetColumnSpan(this.ButtonControl4, 1);
            this.layoutManagerformRACUN.SetRowSpan(this.ButtonControl4, 1);
            padding = new Padding(2, 2, 2, 2);
            this.ButtonControl4.Margin = padding;
            size = new System.Drawing.Size(4, 4);
            this.ButtonControl4.MinimumSize = size;
            size = new System.Drawing.Size(4, 4);
            this.ButtonControl4.Size = size;
            this.Controls.Add(this.layoutManagerformRACUN);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRACUN;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.Disabled;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.RACUNIDRACUNDescription;
            column9.Width = 0x3a;
            appearance8.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnn";
            column9.PromptChar = ' ';
            column9.Format = "";
            column9.CellAppearance = appearance8;
            column9.Hidden = true;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.Disabled;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.RACUNRACUNGODINAIDGODINEDescription;
            column21.Width = 0x48;
            appearance20.TextHAlign = HAlign.Right;
            column21.MaskInput = "{LOC}-nnnn";
            column21.PromptChar = ' ';
            column21.Format = "";
            column21.CellAppearance = appearance20;
            column21.Hidden = true;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.RACUNBROJSTAVKEDescription;
            column.Width = 0x3a;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.RACUNIDPROIZVODDescription;
            column7.Width = 0x48;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            column7.Hidden = true;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.Disabled;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.RACUNNAZIVPROIZVODDescription;
            column16.Width = 0x128;
            column16.Format = "";
            column16.CellAppearance = appearance15;
            column16.Hidden = true;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.RACUNNAZIVPROIZVODRACUNDescription;
            column17.Width = 0x128;
            column17.Format = "";
            column17.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.Disabled;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.RACUNCIJENADescription;
            column2.Width = 0x52;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn.nnnn";
            column2.PromptChar = ' ';
            column2.Format = "F4";
            column2.CellAppearance = appearance2;
            column2.Hidden = true;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.RACUNCIJENARACUNDescription;
            column3.Width = 0x52;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn.nnnn";
            column3.PromptChar = ' ';
            column3.Format = "F4";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.RACUNRABATDescription;
            column20.Width = 0x45;
            appearance19.TextHAlign = HAlign.Right;
            column20.MaskInput = "{LOC}-nnn.nn";
            column20.PromptChar = ' ';
            column20.Format = "F2";
            column20.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.RACUNKOLICINADescription;
            column14.Width = 0x66;
            appearance13.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.RACUNFINPOREZSTOPARACUNDescription;
            column5.Width = 0x8f;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            column5.Hidden = true;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.Disabled;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.RACUNFINPOREZSTOPADescription;
            column4.Width = 0x6d;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            column4.Hidden = true;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.Disabled;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.RACUNIZNOSRACUNDescription;
            column13.Width = 0x66;
            appearance12.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance12;
            column13.Hidden = true;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.Disabled;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.RACUNIZNOSRABATADescription;
            column12.Width = 0x66;
            appearance11.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance11;
            column12.Hidden = true;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.Disabled;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.RACUNIZNOSMINUSRABATDescription;
            column10.Width = 0x81;
            appearance9.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance9;
            column10.Hidden = true;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.Disabled;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.RACUNPDVDescription;
            column19.Width = 0x66;
            appearance18.TextHAlign = HAlign.Right;
            column19.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column19.PromptChar = ' ';
            column19.Format = "F2";
            column19.CellAppearance = appearance18;
            column19.Hidden = true;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.Disabled;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.RACUNIZNOSPLUSPDVDescription;
            column11.Width = 0x7b;
            appearance10.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance10;
            column11.Hidden = true;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.Disabled;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.RACUNIDJEDINICAMJEREDescription;
            column6.Width = 0x69;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnn";
            column6.PromptChar = ' ';
            column6.Format = "";
            column6.CellAppearance = appearance6;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.Disabled;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.RACUNNAZIVJEDINICAMJEREDescription;
            column15.Width = 0x128;
            column15.Format = "";
            column15.CellAppearance = appearance14;
            column15.Hidden = true;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.Disabled;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.RACUNOSNOVICAUKNIZIIRADescription;
            column18.Width = 0x84;
            appearance17.TextHAlign = HAlign.Right;
            column18.MaskInput = "{LOC}-nnnnn";
            column18.PromptChar = ' ';
            column18.Format = "";
            column18.CellAppearance = appearance17;
            column18.Hidden = true;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 1;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 2;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 3;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 4;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 5;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 6;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 7;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 8;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 9;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 10;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 11;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 12;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 13;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 14;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 15;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 0x10;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 0x11;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 0x12;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 0x13;
            this.grdLevelRACUNRacunStavke.Visible = true;
            this.grdLevelRACUNRacunStavke.Name = "grdLevelRACUNRacunStavke";
            this.grdLevelRACUNRacunStavke.Tag = "RACUNRacunStavke";
            this.grdLevelRACUNRacunStavke.TabIndex = 30;
            this.grdLevelRACUNRacunStavke.Dock = DockStyle.Fill;
            this.grdLevelRACUNRacunStavke.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelRACUNRacunStavke.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelRACUNRacunStavke.DataSource = this.bindingSourceRACUNRacunStavke;
            this.grdLevelRACUNRacunStavke.Enter += new EventHandler(this.grdLevelRACUNRacunStavke_Enter);
            this.grdLevelRACUNRacunStavke.AfterRowInsert += new RowEventHandler(this.grdLevelRACUNRacunStavke_AfterRowInsert);
            this.grdLevelRACUNRacunStavke.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelRACUNRacunStavke.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelRACUNRacunStavke.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelRACUNRacunStavke.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelRACUNRacunStavke_DoubleClick);
            this.grdLevelRACUNRacunStavke.AfterRowActivate += new EventHandler(this.grdLevelRACUNRacunStavke_AfterRowActivate);
            this.grdLevelRACUNRacunStavke.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelRACUNRacunStavke.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelRACUNRacunStavke.DisplayLayout.BandsSerializer.Add(band);
            this.Name = "RACUNFormUserControl";
            this.Text = "Izlazni računi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RACUNFormUserControl_Load);
            this.layoutManagerformRACUN.ResumeLayout(false);
            this.layoutManagerformRACUN.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRACUN).EndInit();
            ((ISupportInitialize) this.bindingSourceRACUNRacunStavke).EndInit();
            ((ISupportInitialize) this.textIDRACUN).EndInit();
            ((ISupportInitialize) this.textNAPOMENA).EndInit();
            ((ISupportInitialize) this.textMODEL).EndInit();
            ((ISupportInitialize) this.textPOZIV).EndInit();
            ((ISupportInitialize) this.grdLevelRACUNRacunStavke).EndInit();
            this.panelactionsRACUNRacunStavke.ResumeLayout(true);
            this.panelactionsRACUNRacunStavke.PerformLayout();
            this.layoutManagerpanelactionsRACUNRacunStavke.ResumeLayout(false);
            this.layoutManagerpanelactionsRACUNRacunStavke.PerformLayout();
            this.dsRACUNDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RACUNController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRACUN, this.RACUNController.WorkItem, this))
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
            this.label1ZAPREDUJAM.Text = StringResources.RACUNZAPREDUJAMDescription;
            this.label1IDRACUN.Text = StringResources.RACUNIDRACUNDescription;
            this.label1IDPARTNER.Text = StringResources.RACUNIDPARTNERDescription;
            this.label1DATUM.Text = StringResources.RACUNDATUMDescription;
            this.label1VALUTA.Text = StringResources.RACUNVALUTADescription;
            this.label1RAZDOBLJEOD.Text = StringResources.RACUNRAZDOBLJEODDescription;
            this.label1RAZDOBLJEDO.Text = StringResources.RACUNRAZDOBLJEDODescription;
            this.label1NAPOMENA.Text = StringResources.RACUNNAPOMENADescription;
            this.label1MODEL.Text = StringResources.RACUNMODELDescription;
            this.label1POZIV.Text = StringResources.RACUNPOZIVDescription;
            this.ButtonControl3.Text = StringResources.RACUNRACUNButtonControl3ButtonDescription;
            this.ButtonControl1.Text = StringResources.RACUNRACUNButtonControl1ButtonDescription;
            this.ButtonControl2.Text = StringResources.RACUNRACUNButtonControl2ButtonDescription;
            this.ButtonControl4.Text = StringResources.RACUNRACUNButtonControl4ButtonDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [EventSubscription("topic://RACUN.ButtonControl1.ClickEvent")]
        public void MyEvent(object sender, EventArgs e)
        {
            Interaction.MsgBox("Kontrolni broj za označeni tekst: " + Razno.KontrolniBroj(Strings.Trim(this.upisanibroj)), MsgBoxStyle.OkOnly, null);
            this.textPOZIV.Text = this.textPOZIV.Text + Razno.KontrolniBroj(Strings.Trim(this.upisanibroj));
        }

        [EventSubscription("topic://RACUN.ButtonControl2.ClickEvent")]
        public void MyEvent2(object sender, EventArgs e)
        {
            this.textMODEL.Text = "01";
            this.textPOZIV.Text = this.textIDRACUN.Value.ToString() + "-" + mipsed.application.framework.Application.ActiveYear.ToString().Substring(2, 2) + "-" + this.comboIDPARTNER.Value.ToString();
            //29.12 boris fakturiranje racuna
            //this.textPOZIV.Text = this.textPOZIV.Text + Razno.KontrolniBroj(this.textPOZIV.Text);
        }

        [EventSubscription("topic://RACUN.ButtonControl4.ClickEvent")]
        public void MyEvent3(object sender, EventArgs e)
        {
            this.textNAPOMENA.Text = " " + this.textNAPOMENA.Text + " Oslobođeno PDV-a temeljem čl.39 zakona o PDV-u";
        }

        [EventSubscription("topic://RACUN.ButtonControl3.ClickEvent")]
        public void MyEvent4(object sender, EventArgs e)
        {
            this.textNAPOMENA.Text = " " + this.textNAPOMENA.Text + " Oslobođeno PDV-a temeljem čl.39A zakona o PDV-u";
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDPARTNER(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("PARTNER", null, DeklaritMode.Insert));
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!((msg.Msg == 0x100) | (msg.Msg == 260)))
            {
                bool flag = false;
                return flag;
            }
            switch (keyData)
            {
                case Keys.F7:
                    if (this.textNAPOMENA.Text.Trim() != "")
                    {
                        this.textNAPOMENA.Text = this.textNAPOMENA.Text + " \nDRUŠTVO NIJE U SUSTAVU PDV-a PREMA ČLANKU 22.ZAKONA.";
                        break;
                    }
                    this.textNAPOMENA.Text = this.textNAPOMENA.Text + " DRUŠTVO NIJE U SUSTAVU PDV-a PREMA ČLANKU 22.ZAKONA.";
                    break;

                case Keys.F8:
                    if (this.textNAPOMENA.Text.Trim() != "")
                    {
                        this.textNAPOMENA.Text = this.textNAPOMENA.Text + "\n RAČUN JE PLAĆEN.";
                    }
                    else
                    {
                        this.textNAPOMENA.Text = " " + this.textNAPOMENA.Text + " RAČUN JE PLAĆEN.";
                    }
                    return true;

                case Keys.F9:
                    if (this.textNAPOMENA.Text.Trim() != "")
                    {
                        this.textNAPOMENA.Text = this.textNAPOMENA.Text + "\n DOKUMENT JE IZRAĐEN NA RAČUNALU I PRAVOVALJAN JE BEZ PEČATA I POTPISA";
                    }
                    else
                    {
                        this.textNAPOMENA.Text = " " + this.textNAPOMENA.Text + " DOKUMENT JE IZRAĐEN NA RAČUNALU I PRAVOVALJAN JE BEZ PEČATA I POTPISA";
                    }
                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void RACUNFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RACUNDescription;
            this.errorProvider1.ContainerControl = this;
            this.linkLabelRACUNRacunStavkeAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.RACUNRACUNRacunStavkeLevelDescription;
            this.linkLabelRACUNRacunStavkeUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.RACUNRACUNRacunStavkeLevelDescription;
            this.linkLabelRACUNRacunStavkeDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.RACUNRACUNRacunStavkeLevelDescription;
        }

        private void RACUNFormUserControl_Load1(object sender, EventArgs e)
        {
            if (this.Mode == DeklaritMode.Insert)
            {
                ((UltraNumericEditor) this.RACUNController.RACUNFormDefinition.GetControl("TEXTIDRACUN")).Visible = true;
                ((UltraNumericEditor) this.RACUNController.RACUNFormDefinition.GetControl("TEXTIDRACUN")).Enabled = true;
                ((UltraLabel) this.RACUNController.RACUNFormDefinition.GetControl("label1IDRACUN")).Visible = true;
                ((UltraCheckEditor) this.RACUNController.RACUNFormDefinition.GetControl("checkZAPREDUJAM")).Visible = true;
                ((UltraCheckEditor) this.RACUNController.RACUNFormDefinition.GetControl("checkZAPREDUJAM")).Enabled = true;
                ((UltraLabel) this.RACUNController.RACUNFormDefinition.GetControl("label1ZAPREDUJAM")).Visible = true;
                ((UltraCheckEditor) this.RACUNController.RACUNFormDefinition.GetControl("checkZAPREDUJAM")).Checked = false;
            }
            else
            {
                ((UltraNumericEditor) this.RACUNController.RACUNFormDefinition.GetControl("TEXTIDRACUN")).Visible = true;
                ((UltraNumericEditor) this.RACUNController.RACUNFormDefinition.GetControl("TEXTIDRACUN")).Enabled = true;
                ((UltraLabel) this.RACUNController.RACUNFormDefinition.GetControl("label1IDRACUN")).Visible = true;
                ((UltraCheckEditor) this.RACUNController.RACUNFormDefinition.GetControl("checkZAPREDUJAM")).Visible = true;
                ((UltraCheckEditor) this.RACUNController.RACUNFormDefinition.GetControl("checkZAPREDUJAM")).Enabled = true;
                ((UltraLabel) this.RACUNController.RACUNFormDefinition.GetControl("label1ZAPREDUJAM")).Visible = true;
            }
            if (Conversions.ToInteger(((DataRowView) this.bindingSourceRACUN.Current).Row["RACUNGODINAIDGODINE"]) == 0)
            {
                ((DataRowView) this.bindingSourceRACUN.Current).Row["RACUNGODINAIDGODINE"] = mipsed.application.framework.Application.ActiveYear;
            }
        }

        private void RACUNRacunStavkeAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelRACUNRacunStavke.ActiveRow;
            this.RACUNRacunStavkeInsert();
        }

        private void RACUNRacunStavkeDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelRACUNRacunStavke);
            if ((currentRowListIndex != -1) && (this.grdLevelRACUNRacunStavke.Selected.Rows.Count > 0))
            {
                this.grdLevelRACUNRacunStavke.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelRACUNRacunStavke).Selected = true;
                this.grdLevelRACUNRacunStavke.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RACUNRacunStavkeInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceRACUN, this.RACUNController.WorkItem, this))
            {
                this.RACUNController.AddRACUNRacunStavke(this.m_CurrentRow);
            }
        }

        private void RACUNRacunStavkeUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelRACUNRacunStavke) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelRACUNRacunStavke);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.RACUNController.UpdateRACUNRacunStavke(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RACUNRacunStavkeUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelRACUNRacunStavke.ActiveRow != null)
            {
                this.RACUNRacunStavkeUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.RACUNController.WorkItem.Items.Contains("RACUN|RACUN"))
            {
                this.RACUNController.WorkItem.Items.Add(this.bindingSourceRACUN, "RACUN|RACUN");
            }
            if (!this.RACUNController.WorkItem.Items.Contains("RACUN|RACUNRacunStavke"))
            {
                this.RACUNController.WorkItem.Items.Add(this.bindingSourceRACUNRacunStavke, "RACUN|RACUNRacunStavke");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsRACUNDataSet1.RACUN.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.RACUNController.Update(this);
            }
            UpdateVrstaUkupanIznos(textIDRACUN.Value);
        }

        private void UpdateVrstaUkupanIznos(object id)
        {
            if (id != null)
            {
                Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

                string year = mipsed.application.framework.Application.ActiveYear.ToString();

                client.ExecuteNonQuery("Update RACUN Set Vrsta = Case When LEN(Vrsta) > 0 Then Vrsta Else 'Rac' End Where IDRacun = '" + id.ToString() + "' And RACUNGODINAIDGODINE = '" + year + "'");
                client.ExecuteNonQuery("Update RACUN Set UkupanIznos = Case When Vrsta Not In ('SR','SU') Then " + 
                "(Select Sum(CijenaPDV) From RACUNRacunStavke Where RACUNRacunStavke.IDRACUN = '" + id.ToString() + "' And RACUNRacunStavke.RACUNGODINAIDGODINE = '" + year + "') Else " +
                "(Select Sum(CijenaPDV) * -1 From RACUNRacunStavke Where RACUNRacunStavke.IDRACUN = '" + id.ToString() + "' And RACUNRacunStavke.RACUNGODINAIDGODINE = '" + year + "') End " + 
                "Where IDRacun = '" + id.ToString() + "' And RACUNGODINAIDGODINE = '" + year + "'");
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RACUNController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            UpdateVrstaUkupanIznos(textIDRACUN.Value);
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RACUNController.Update(this))
            {
                this.RACUNController.DataSet = new RACUNDataSet();
                DataSetUtil.AddEmptyRow(this.RACUNController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.RACUNController.DataSet.RACUN[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
                this.textIDRACUN.Value = (int)textIDRACUN.Value + 1;
            }
            UpdateVrstaUkupanIznos(textIDRACUN.Value);
        }

        private void SelectedIndexChangedIDPARTNER(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDPARTNER.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDPARTNER.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceRACUN.Current).Row["IDPARTNER"] = RuntimeHelpers.GetObjectValue(row["IDPARTNER"]);
                    ((DataRowView) this.bindingSourceRACUN.Current).Row["NAZIVPARTNER"] = RuntimeHelpers.GetObjectValue(row["NAZIVPARTNER"]);
                    ((DataRowView) this.bindingSourceRACUN.Current).Row["MB"] = RuntimeHelpers.GetObjectValue(row["MB"]);
                    ((DataRowView) this.bindingSourceRACUN.Current).Row["PARTNERMJESTO"] = RuntimeHelpers.GetObjectValue(row["PARTNERMJESTO"]);
                    ((DataRowView) this.bindingSourceRACUN.Current).Row["PARTNERULICA"] = RuntimeHelpers.GetObjectValue(row["PARTNERULICA"]);
                    ((DataRowView) this.bindingSourceRACUN.Current).Row["PARTNEREMAIL"] = RuntimeHelpers.GetObjectValue(row["PARTNEREMAIL"]);
                    ((DataRowView) this.bindingSourceRACUN.Current).Row["PARTNEROIB"] = RuntimeHelpers.GetObjectValue(row["PARTNEROIB"]);
                    this.bindingSourceRACUN.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.checkZAPREDUJAM.Focus();
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

        private void textIDRACUN_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
        }

        private void textMODEL_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
        }

        private void textPOZIV_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
        }

        private void textPOZIV_BeforeExitEditMode(object sender, Infragistics.Win.BeforeExitEditModeEventArgs e)
        {
            this.upisanibroj = this.textPOZIV.SelectedText;
        }

        private void textPOZIV_Validated(object sender, EventArgs e)
        {
        }

        protected virtual Button ButtonControl1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ButtonControl1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ButtonControl1 = value;
            }
        }

        protected virtual Button ButtonControl2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ButtonControl2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ButtonControl2 = value;
            }
        }

        protected virtual Button ButtonControl3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ButtonControl3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ButtonControl3 = value;
            }
        }

        protected virtual Button ButtonControl4
        {
            [DebuggerNonUserCode]
            get
            {
                return this._ButtonControl4;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._ButtonControl4 = value;
            }
        }

        protected virtual UltraCheckEditor checkZAPREDUJAM
        {
            [DebuggerNonUserCode]
            get
            {
                return this._checkZAPREDUJAM;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._checkZAPREDUJAM = value;
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

        protected virtual UltraDateTimeEditor datePickerDATUM
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerDATUM;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerDATUM = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerRAZDOBLJEDO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerRAZDOBLJEDO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerRAZDOBLJEDO = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerRAZDOBLJEOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerRAZDOBLJEOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerRAZDOBLJEOD = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerVALUTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerVALUTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerVALUTA = value;
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

        protected virtual UltraGrid grdLevelRACUNRacunStavke
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelRACUNRacunStavke;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelRACUNRacunStavke = value;
            }
        }

        protected virtual UltraLabel label1DATUM
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1DATUM;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1DATUM = value;
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

        protected virtual UltraLabel label1IDRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDRACUN = value;
            }
        }

        protected virtual UltraLabel label1MODEL
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MODEL;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MODEL = value;
            }
        }

        protected virtual UltraLabel label1NAPOMENA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAPOMENA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAPOMENA = value;
            }
        }

        protected virtual UltraLabel label1POZIV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POZIV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POZIV = value;
            }
        }

        protected virtual UltraLabel label1RAZDOBLJEDO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAZDOBLJEDO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAZDOBLJEDO = value;
            }
        }

        protected virtual UltraLabel label1RAZDOBLJEOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAZDOBLJEOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAZDOBLJEOD = value;
            }
        }

        protected virtual UltraLabel label1VALUTA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1VALUTA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1VALUTA = value;
            }
        }

        protected virtual UltraLabel label1ZAPREDUJAM
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ZAPREDUJAM;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ZAPREDUJAM = value;
            }
        }

        protected virtual UltraLabel linkLabelRACUNRacunStavke
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRACUNRacunStavke;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRACUNRacunStavke = value;
            }
        }

        protected virtual UltraLabel linkLabelRACUNRacunStavkeAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRACUNRacunStavkeAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRACUNRacunStavkeAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelRACUNRacunStavkeDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRACUNRacunStavkeDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRACUNRacunStavkeDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelRACUNRacunStavkeUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelRACUNRacunStavkeUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelRACUNRacunStavkeUpdate = value;
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

        protected virtual Panel panelactionsRACUNRacunStavke
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsRACUNRacunStavke;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsRACUNRacunStavke = value;
            }
        }

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.RACUNController RACUNController { get; set; }

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

        protected virtual UltraNumericEditor textIDRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                CancelEventHandler handler = new CancelEventHandler(this.textIDRACUN_BeforeEnterEditMode);
                if (this._textIDRACUN != null)
                {
                    this._textIDRACUN.BeforeEnterEditMode -= handler;
                }
                this._textIDRACUN = value;
                if (this._textIDRACUN != null)
                {
                    this._textIDRACUN.BeforeEnterEditMode += handler;
                }
            }
        }

        protected virtual UltraTextEditor textMODEL
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMODEL;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                CancelEventHandler handler = new CancelEventHandler(this.textMODEL_BeforeEnterEditMode);
                if (this._textMODEL != null)
                {
                    this._textMODEL.BeforeEnterEditMode -= handler;
                }
                this._textMODEL = value;
                if (this._textMODEL != null)
                {
                    this._textMODEL.BeforeEnterEditMode += handler;
                }
            }
        }

        protected virtual UltraTextEditor textNAPOMENA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAPOMENA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAPOMENA = value;
            }
        }

        protected virtual UltraTextEditor textPOZIV
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPOZIV;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                EventHandler handler = new EventHandler(this.textPOZIV_Validated);
                Infragistics.Win.BeforeExitEditModeEventHandler handler2 = new Infragistics.Win.BeforeExitEditModeEventHandler(this.textPOZIV_BeforeExitEditMode);
                CancelEventHandler handler3 = new CancelEventHandler(this.textPOZIV_BeforeEnterEditMode);
                if (this._textPOZIV != null)
                {
                    this._textPOZIV.Validated -= handler;
                    this._textPOZIV.BeforeExitEditMode -= handler2;
                    this._textPOZIV.BeforeEnterEditMode -= handler3;
                }
                this._textPOZIV = value;
                if (this._textPOZIV != null)
                {
                    this._textPOZIV.Validated += handler;
                    this._textPOZIV.BeforeExitEditMode += handler2;
                    this._textPOZIV.BeforeEnterEditMode += handler3;
                }
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

