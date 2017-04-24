namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Resources;
    using Deklarit.Win;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.EventBroker;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic.CompilerServices;
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
    public class KORISNIKFormUserControl : UserControl, IBusinessComponentUserControl
    {
        private BindingSource bindingSourceKORISNIK;
        private BindingSource bindingSourceKORISNIKLevel1;
        private IContainer components = null;
        private KORISNIKDataSet dsKORISNIKDataSet1;
        protected TableLayoutPanel layoutManagerformKORISNIK;
        protected TableLayoutPanel layoutManagerpanelactionsKORISNIKLevel1;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private KORISNIKDataSet.KORISNIKRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "KORISNIK";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.KORISNIKDescription;
        private UltraLabel label1OBVEZNIKPDVA;
        private UltraCheckEditor checkOBVEZNIKPDVA;
        private UltraLabel lblNeprofitni;
        
        private UltraLabel lblStopaZaInvalide;
        private UltraLabel lblBrojOsoba;
        private UltraCheckEditor cbkPDVPoNaplacenom;
        private UltraLabel lblPDVPoNaplacenom;

        private UltraCheckEditor cbkNeprofitni;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public KORISNIKFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsKORISNIKDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceKORISNIK.DataSource = this.KORISNIKController.DataSet;
            this.dsKORISNIKDataSet1 = this.KORISNIKController.DataSet;
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

        private static void CreateValueList(UltraGrid dataGrid1, string valueListName, DataView enumList, string Id, string Name, bool overrideList)
        {
            ValueList myValueList = null;
            if (overrideList && dataGrid1.DisplayLayout.ValueLists.Exists(valueListName))
            {
                myValueList = dataGrid1.DisplayLayout.ValueLists[valueListName];
                myValueList.ValueListItems.Clear();
            }
            if (!dataGrid1.DisplayLayout.ValueLists.Exists(valueListName))
            {
                myValueList = dataGrid1.DisplayLayout.ValueLists.Add(valueListName);
            }
            if (myValueList != null)
            {
                LoadValueList(myValueList, enumList, Id, Name);
            }
        }

        [LocalCommandHandler("DeleteInstance")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.dsKORISNIKDataSet1.KORISNIK.Rows.GetEnumerator();
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
                if (this.KORISNIKController.Update(this))
                {
                    this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void dg_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGridColumn column = e.Cell.Column;
            if ((column.CellActivation == Activation.AllowEdit) && (Conversions.ToString(column.Tag) == "IZVORDOKUMENTASIFRAIZVORAAddNew"))
            {
                this.PictureBoxClickedInLinesSIFRAIZVORA(RuntimeHelpers.GetObjectValue(sender), e);
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

        private void EndEditCurrentRow()
        {
            if (this.grdLevelKORISNIKLevel1.ActiveRow != null)
            {
                this.grdLevelKORISNIKLevel1.PerformAction(UltraGridAction.NextRow);
            }
        }

        private void grd_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
        }

        private void grd_CellListSelect(object sender, CellEventArgs e)
        {
            if (e.Cell.ValueListResolved != null)
            {
                DataView tag = (DataView) ((ValueList) e.Cell.ValueListResolved).Tag;
                int selectedItemIndex = e.Cell.ValueListResolved.SelectedItemIndex;
                DataRow result = null;
                if ((tag.Count > selectedItemIndex) && (selectedItemIndex >= 0))
                {
                    result = tag[selectedItemIndex].Row;
                }
                if (e.Cell.Column.Key == "SIFRAIZVORA")
                {
                    this.UpdateValuesSIFRAIZVORA(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
            }
        }

        private void grdLevelKORISNIKLevel1_AfterRowActivate(object sender, EventArgs e)
        {
            string str = StringResources.KORISNIKKORISNIKLevel1LevelDescription;
            UltraGridRow activeRow = this.grdLevelKORISNIKLevel1.ActiveRow;
            this.linkLabelKORISNIKLevel1Add.Text = Deklarit.Resources.Resources.Add + " " + str;
            this.linkLabelKORISNIKLevel1Update.Text = Deklarit.Resources.Resources.Update + " " + str;
            this.linkLabelKORISNIKLevel1Delete.Text = Deklarit.Resources.Resources.Delete + " " + str;
        }

        private void grdLevelKORISNIKLevel1_AfterRowInsert(object sender, RowEventArgs e)
        {

        }

        private void grdLevelKORISNIKLevel1_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.KORISNIKLevel1Update_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelKORISNIKLevel1_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceKORISNIK, this.KORISNIKController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "KORISNIK", this.m_Mode, this.dsKORISNIKDataSet1, this.dsKORISNIKDataSet1.KORISNIK.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            
            

            Binding binding = new Binding("CheckState", this.bindingSourceKORISNIK, "STAZUKOEFICIJENTU", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkSTAZUKOEFICIJENTU.DataBindings["CheckState"] != null)
            {
                this.checkSTAZUKOEFICIJENTU.DataBindings.Remove(this.checkSTAZUKOEFICIJENTU.DataBindings["CheckState"]);
            }
            this.checkSTAZUKOEFICIJENTU.DataBindings.Add(binding);


            Binding bindingObveznikPDVA = new Binding("CheckState", this.bindingSourceKORISNIK, "OBVEZNIKPDVA", true);
            bindingObveznikPDVA.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            bindingObveznikPDVA.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkOBVEZNIKPDVA.DataBindings["CheckState"] != null)
            {
                this.checkOBVEZNIKPDVA.DataBindings.Remove(this.checkOBVEZNIKPDVA.DataBindings["CheckState"]);
            }
            this.checkOBVEZNIKPDVA.DataBindings.Add(bindingObveznikPDVA);


            Binding bindingNeprofitni = new Binding("CheckState", this.bindingSourceKORISNIK, "Neprofitni", true);
            bindingNeprofitni.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            bindingNeprofitni.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.cbkNeprofitni.DataBindings["CheckState"] != null)
            {
                this.cbkNeprofitni.DataBindings.Remove(this.cbkNeprofitni.DataBindings["CheckState"]);
            }
            this.cbkNeprofitni.DataBindings.Add(bindingNeprofitni);

            Binding bindingPDVPoNaplacenom = new Binding("CheckState", this.bindingSourceKORISNIK, "PDVPoNaplacenom", true);
            bindingPDVPoNaplacenom.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            bindingPDVPoNaplacenom.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.cbkPDVPoNaplacenom.DataBindings["CheckState"] != null)
            {
                this.cbkPDVPoNaplacenom.DataBindings.Remove(this.cbkPDVPoNaplacenom.DataBindings["CheckState"]);
            }
            this.cbkPDVPoNaplacenom.DataBindings.Add(bindingPDVPoNaplacenom);



            if (!this.m_DataGrids.Contains(this.grdLevelKORISNIKLevel1))
            {
                this.m_DataGrids.Add(this.grdLevelKORISNIKLevel1);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsKORISNIKDataSet1.KORISNIK[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (KORISNIKDataSet.KORISNIKRow) ((DataRowView) this.bindingSourceKORISNIK.AddNew()).Row;
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("KORISNIK_KORISNIKLevel1", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKORISNIK");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDZIRO");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVZIRO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ULICAZIRO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MJESTOZIRO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIKORISNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZIROKORISNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SIFRAIZVORA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVIZVORA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POREZIPRIREZZAJEDNICKI");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POZIVIZADUZENJA");
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.SetNullItem = new System.Windows.Forms.MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSourceKORISNIK = new System.Windows.Forms.BindingSource(this.components);
            this.dsKORISNIKDataSet1 = new Placa.KORISNIKDataSet();
            this.errorProviderValidator1 = new Deklarit.Win.ErrorProviderValidator(this.components);
            this.textEMAIL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.layoutManagerformKORISNIK = new System.Windows.Forms.TableLayoutPanel();
            this.label1IDKORISNIK = new Infragistics.Win.Misc.UltraLabel();
            this.textIDKORISNIK = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1KORISNIK1NAZIV = new Infragistics.Win.Misc.UltraLabel();
            this.textKORISNIK1NAZIV = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1KORISNIK1ADRESA = new Infragistics.Win.Misc.UltraLabel();
            this.textKORISNIK1ADRESA = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1KORISNIK1MJESTO = new Infragistics.Win.Misc.UltraLabel();
            this.textKORISNIK1MJESTO = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1KORISNIKOIB = new Infragistics.Win.Misc.UltraLabel();
            this.textKORISNIKOIB = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1MBKORISNIK = new Infragistics.Win.Misc.UltraLabel();
            this.textMBKORISNIK = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1MBKORISNIKJEDINICA = new Infragistics.Win.Misc.UltraLabel();
            this.textMBKORISNIKJEDINICA = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1JMBGKORISNIK = new Infragistics.Win.Misc.UltraLabel();
            this.textJMBGKORISNIK = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1KONTAKTOSOBA = new Infragistics.Win.Misc.UltraLabel();
            this.textKONTAKTOSOBA = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1KONTAKTTELEFON = new Infragistics.Win.Misc.UltraLabel();
            this.textKONTAKTTELEFON = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1KONTAKTFAX = new Infragistics.Win.Misc.UltraLabel();
            this.textKONTAKTFAX = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1EMAIL = new Infragistics.Win.Misc.UltraLabel();
            this.label1NADLEZNAPU = new Infragistics.Win.Misc.UltraLabel();
            this.textNADLEZNAPU = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1BROJCANAOZNAKAPU = new Infragistics.Win.Misc.UltraLabel();
            this.textBROJCANAOZNAKAPU = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1STAZUKOEFICIJENTU = new Infragistics.Win.Misc.UltraLabel();
            this.checkSTAZUKOEFICIJENTU = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.label1RKP = new Infragistics.Win.Misc.UltraLabel();
            this.textRKP = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1PREZIMEIMEOVLASTENEOSOBE = new Infragistics.Win.Misc.UltraLabel();
            this.textPREZIMEIMEOVLASTENEOSOBE = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1ADRESAOVLASTENEOSOBE = new Infragistics.Win.Misc.UltraLabel();
            this.textADRESAOVLASTENEOSOBE = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1OIBOVLASTENEOSOBE = new Infragistics.Win.Misc.UltraLabel();
            this.textOIBOVLASTENEOSOBE = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.grdLevelKORISNIKLevel1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bindingSourceKORISNIKLevel1 = new System.Windows.Forms.BindingSource(this.components);
            this.panelactionsKORISNIKLevel1 = new System.Windows.Forms.Panel();
            this.layoutManagerpanelactionsKORISNIKLevel1 = new System.Windows.Forms.TableLayoutPanel();
            this.linkLabelKORISNIKLevel1Add = new Infragistics.Win.Misc.UltraLabel();
            this.linkLabelKORISNIKLevel1Update = new Infragistics.Win.Misc.UltraLabel();
            this.linkLabelKORISNIKLevel1Delete = new Infragistics.Win.Misc.UltraLabel();
            this.label1ANALITIKA = new Infragistics.Win.Misc.UltraLabel();
            this.label1KORISNIK1HZZO = new Infragistics.Win.Misc.UltraLabel();
            this.textANALITIKA = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.textKORISNIK1HZZO = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1KORISNIK1NAZIVZANALJEPNICE = new Infragistics.Win.Misc.UltraLabel();
            this.textKORISNIK1NAZIVZANALJEPNICE = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1EMAILPOSILJAOCA = new Infragistics.Win.Misc.UltraLabel();
            this.label1NAZIVPOSILJAOCA = new Infragistics.Win.Misc.UltraLabel();
            this.label1SMTPSERVER = new Infragistics.Win.Misc.UltraLabel();
            this.textEMAILPOSILJAOCA = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.textNAZIVPOSILJAOCA = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.textSMTPSERVER = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1OBVEZNIKPDVA = new Infragistics.Win.Misc.UltraLabel();
            this.checkOBVEZNIKPDVA = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            lblNeprofitni = new Infragistics.Win.Misc.UltraLabel();
            cbkNeprofitni = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();

            //1.1.15
            lblStopaZaInvalide = new Infragistics.Win.Misc.UltraLabel();
            txtStopaZaInvalide = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();

            lblBrojOsoba = new UltraLabel();
            txtBrojOsoba = new UltraNumericEditor();

            cbkPDVPoNaplacenom = new UltraCheckEditor();
            lblPDVPoNaplacenom = new UltraLabel();

            lblPassword = new UltraLabel();
            lblPort = new UltraLabel();
            txtPassword = new UltraTextEditor();
            txtPort = new UltraTextEditor();

            #region MBS.Complete
            txtPredporez = new UltraNumericEditor();
            lblPredporez = new UltraLabel();
            #endregion

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceKORISNIK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKORISNIKDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEMAIL)).BeginInit();
            this.layoutManagerformKORISNIK.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.txtStopaZaInvalide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrojOsoba)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.cbkPDVPoNaplacenom)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).BeginInit();

            #region MBS.Complete
            ((System.ComponentModel.ISupportInitialize)(this.txtPredporez)).BeginInit();
            #endregion


            ((System.ComponentModel.ISupportInitialize)(this.textIDKORISNIK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKORISNIK1NAZIV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKORISNIK1ADRESA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKORISNIK1MJESTO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKORISNIKOIB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMBKORISNIK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMBKORISNIKJEDINICA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textJMBGKORISNIK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKONTAKTOSOBA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKONTAKTTELEFON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKONTAKTFAX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNADLEZNAPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBROJCANAOZNAKAPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textRKP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPREZIMEIMEOVLASTENEOSOBE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textADRESAOVLASTENEOSOBE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOIBOVLASTENEOSOBE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLevelKORISNIKLevel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceKORISNIKLevel1)).BeginInit();
            this.panelactionsKORISNIKLevel1.SuspendLayout();
            this.layoutManagerpanelactionsKORISNIKLevel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textANALITIKA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKORISNIK1HZZO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKORISNIK1NAZIVZANALJEPNICE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEMAILPOSILJAOCA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNAZIVPOSILJAOCA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSMTPSERVER)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.SetNullItem});
            this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
            // 
            // SetNullItem
            // 
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new System.EventHandler(this.SetNullItem_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.bindingSourceKORISNIK;
            // 
            // bindingSourceKORISNIK
            // 
            this.bindingSourceKORISNIK.DataMember = "KORISNIK";
            this.bindingSourceKORISNIK.DataSource = this.dsKORISNIKDataSet1;
            // 
            // dsKORISNIKDataSet1
            // 
            this.dsKORISNIKDataSet1.DataSetName = "dsKORISNIK";
            this.dsKORISNIKDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // errorProviderValidator1
            // 
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.errorProviderValidator1.ToolTipProvider = null;
            // 
            // textEMAIL
            // 
            this.textEMAIL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textEMAIL.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "EMAIL", true));
            this.errorProviderValidator1.SetDisplayName(this.textEMAIL, "");
            this.textEMAIL.Location = new System.Drawing.Point(232, 276);
            this.textEMAIL.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textEMAIL.MaxLength = 100;
            this.textEMAIL.MinimumSize = new System.Drawing.Size(300, 22);
            this.textEMAIL.Name = "textEMAIL";
            this.errorProviderValidator1.SetRegularExpression(this.textEMAIL, "[a-zA-Z0-9]([a-zA-Z0-9_\\-\\.]*)@[a-zA-Z0-9]([a-zA-Z0-9_\\-\\.]*)(\\.[a-zA-Z]{2,3}(\\.[" +
        "a-zA-Z]{2}){0,2})");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textEMAIL, "Invalid E-mail Value ");
            this.errorProviderValidator1.SetRequired(this.textEMAIL, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textEMAIL, "");
            this.textEMAIL.Size = new System.Drawing.Size(300, 22);
            this.textEMAIL.TabIndex = 0;
            this.textEMAIL.Tag = "EMAIL";
            this.textEMAIL.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // layoutManagerformKORISNIK
            // 
            this.layoutManagerformKORISNIK.AutoSize = true;
            this.layoutManagerformKORISNIK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerformKORISNIK.ColumnCount = 4;
            this.layoutManagerformKORISNIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformKORISNIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformKORISNIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformKORISNIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformKORISNIK.Controls.Add(this.label1IDKORISNIK, 0, 0);
            this.layoutManagerformKORISNIK.Controls.Add(this.textIDKORISNIK, 1, 0);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1KORISNIK1NAZIV, 0, 1);
            this.layoutManagerformKORISNIK.Controls.Add(this.textKORISNIK1NAZIV, 1, 1);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1KORISNIK1ADRESA, 0, 2);
            this.layoutManagerformKORISNIK.Controls.Add(this.textKORISNIK1ADRESA, 1, 2);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1KORISNIK1MJESTO, 0, 3);
            this.layoutManagerformKORISNIK.Controls.Add(this.textKORISNIK1MJESTO, 1, 3);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1KORISNIKOIB, 0, 4);
            this.layoutManagerformKORISNIK.Controls.Add(this.textKORISNIKOIB, 1, 4);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1MBKORISNIK, 0, 5);
            this.layoutManagerformKORISNIK.Controls.Add(this.textMBKORISNIK, 1, 5);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1MBKORISNIKJEDINICA, 0, 6);
            this.layoutManagerformKORISNIK.Controls.Add(this.textMBKORISNIKJEDINICA, 1, 6);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1JMBGKORISNIK, 0, 7);
            this.layoutManagerformKORISNIK.Controls.Add(this.textJMBGKORISNIK, 1, 7);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1KONTAKTOSOBA, 0, 8);
            this.layoutManagerformKORISNIK.Controls.Add(this.textKONTAKTOSOBA, 1, 8);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1KONTAKTTELEFON, 0, 9);
            this.layoutManagerformKORISNIK.Controls.Add(this.textKONTAKTTELEFON, 1, 9);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1KONTAKTFAX, 0, 10);
            this.layoutManagerformKORISNIK.Controls.Add(this.textKONTAKTFAX, 1, 10);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1EMAIL, 0, 11);
            this.layoutManagerformKORISNIK.Controls.Add(this.textEMAIL, 1, 11);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1NADLEZNAPU, 0, 12);
            this.layoutManagerformKORISNIK.Controls.Add(this.textNADLEZNAPU, 1, 12);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1BROJCANAOZNAKAPU, 0, 13);
            this.layoutManagerformKORISNIK.Controls.Add(this.textBROJCANAOZNAKAPU, 1, 13);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1STAZUKOEFICIJENTU, 0, 14);
            this.layoutManagerformKORISNIK.Controls.Add(this.checkSTAZUKOEFICIJENTU, 1, 14);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1RKP, 0, 15);
            this.layoutManagerformKORISNIK.Controls.Add(this.textRKP, 1, 15);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1PREZIMEIMEOVLASTENEOSOBE, 0, 16);
            this.layoutManagerformKORISNIK.Controls.Add(this.textPREZIMEIMEOVLASTENEOSOBE, 1, 16);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1ADRESAOVLASTENEOSOBE, 0, 17);
            this.layoutManagerformKORISNIK.Controls.Add(this.textADRESAOVLASTENEOSOBE, 1, 17);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1OIBOVLASTENEOSOBE, 0, 18);
            this.layoutManagerformKORISNIK.Controls.Add(this.textOIBOVLASTENEOSOBE, 1, 18);
            this.layoutManagerformKORISNIK.Controls.Add(this.grdLevelKORISNIKLevel1, 0, 25);
            this.layoutManagerformKORISNIK.Controls.Add(this.panelactionsKORISNIKLevel1, 0, 26);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1ANALITIKA, 2, 0);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1KORISNIK1HZZO, 2, 1);
            this.layoutManagerformKORISNIK.Controls.Add(this.textANALITIKA, 3, 0);
            this.layoutManagerformKORISNIK.Controls.Add(this.textKORISNIK1HZZO, 3, 1);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1KORISNIK1NAZIVZANALJEPNICE, 2, 2);
            this.layoutManagerformKORISNIK.Controls.Add(this.textKORISNIK1NAZIVZANALJEPNICE, 3, 2);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1EMAILPOSILJAOCA, 2, 3);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1NAZIVPOSILJAOCA, 2, 4);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1SMTPSERVER, 2, 5);
            this.layoutManagerformKORISNIK.Controls.Add(this.textEMAILPOSILJAOCA, 3, 3);
            this.layoutManagerformKORISNIK.Controls.Add(this.textNAZIVPOSILJAOCA, 3, 4);
            this.layoutManagerformKORISNIK.Controls.Add(this.textSMTPSERVER, 3, 5);
            this.layoutManagerformKORISNIK.Controls.Add(this.label1OBVEZNIKPDVA, 2, 6);
            this.layoutManagerformKORISNIK.Controls.Add(this.checkOBVEZNIKPDVA, 3, 6);
            layoutManagerformKORISNIK.Controls.Add(lblNeprofitni, 2, 7);
            layoutManagerformKORISNIK.Controls.Add(cbkNeprofitni, 3, 7);

            layoutManagerformKORISNIK.Controls.Add(lblStopaZaInvalide, 2, 8);
            layoutManagerformKORISNIK.Controls.Add(txtStopaZaInvalide, 3, 8);

            layoutManagerformKORISNIK.Controls.Add(lblBrojOsoba, 2, 9);
            layoutManagerformKORISNIK.Controls.Add(txtBrojOsoba, 3, 9);
            layoutManagerformKORISNIK.Controls.Add(lblPDVPoNaplacenom, 2, 10);
            layoutManagerformKORISNIK.Controls.Add(cbkPDVPoNaplacenom, 3, 10);

            layoutManagerformKORISNIK.Controls.Add(lblPassword, 2, 11);
            layoutManagerformKORISNIK.Controls.Add(txtPassword, 3, 11);
            layoutManagerformKORISNIK.Controls.Add(lblPort, 2, 12);
            layoutManagerformKORISNIK.Controls.Add(txtPort, 3, 12);

            #region MBS.Complete
            layoutManagerformKORISNIK.Controls.Add(lblPredporez, 2, 13);
            layoutManagerformKORISNIK.Controls.Add(txtPredporez, 3, 13);
            #endregion

            this.errorProviderValidator1.SetDisplayName(this.layoutManagerformKORISNIK, "");
            this.layoutManagerformKORISNIK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutManagerformKORISNIK.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerformKORISNIK.Name = "layoutManagerformKORISNIK";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerformKORISNIK, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerformKORISNIK, "");
            this.errorProviderValidator1.SetRequired(this.layoutManagerformKORISNIK, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerformKORISNIK, "");
            this.layoutManagerformKORISNIK.RowCount = 28;
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutManagerformKORISNIK.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutManagerformKORISNIK.Size = new System.Drawing.Size(1085, 658);
            this.layoutManagerformKORISNIK.TabIndex = 0;
            // 
            // label1IDKORISNIK
            // 
            this.label1IDKORISNIK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.TextVAlignAsString = "Middle";
            this.label1IDKORISNIK.Appearance = appearance1;
            this.label1IDKORISNIK.AutoSize = true;
            this.label1IDKORISNIK.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IDKORISNIK, "");
            this.label1IDKORISNIK.ImageSize = new System.Drawing.Size(7, 10);
            this.label1IDKORISNIK.Location = new System.Drawing.Point(3, 5);
            this.label1IDKORISNIK.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IDKORISNIK.Name = "label1IDKORISNIK";
            this.errorProviderValidator1.SetRegularExpression(this.label1IDKORISNIK, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IDKORISNIK, "");
            this.errorProviderValidator1.SetRequired(this.label1IDKORISNIK, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IDKORISNIK, "");
            this.label1IDKORISNIK.Size = new System.Drawing.Size(79, 14);
            this.label1IDKORISNIK.StyleSetName = "FieldUltraLabel";
            this.label1IDKORISNIK.TabIndex = 1;
            this.label1IDKORISNIK.Tag = "labelIDKORISNIK";
            this.label1IDKORISNIK.Text = "Šifra korisnika:";
            // 
            // textIDKORISNIK
            // 
            this.textIDKORISNIK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textIDKORISNIK.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceKORISNIK, "IDKORISNIK", true));
            this.errorProviderValidator1.SetDisplayName(this.textIDKORISNIK, "");
            this.textIDKORISNIK.Location = new System.Drawing.Point(232, 1);
            this.textIDKORISNIK.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textIDKORISNIK.MaskInput = "{LOC}-nnnnn";
            this.textIDKORISNIK.MinimumSize = new System.Drawing.Size(51, 22);
            this.textIDKORISNIK.Name = "textIDKORISNIK";
            this.textIDKORISNIK.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textIDKORISNIK, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textIDKORISNIK, "");
            this.errorProviderValidator1.SetRequired(this.textIDKORISNIK, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textIDKORISNIK, "");
            this.textIDKORISNIK.Size = new System.Drawing.Size(51, 22);
            this.textIDKORISNIK.TabIndex = 0;
            this.textIDKORISNIK.Tag = "IDKORISNIK";
            this.textIDKORISNIK.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textIDKORISNIK.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1KORISNIK1NAZIV
            // 
            this.label1KORISNIK1NAZIV.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.label1KORISNIK1NAZIV.Appearance = appearance12;
            this.label1KORISNIK1NAZIV.AutoSize = true;
            this.label1KORISNIK1NAZIV.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1KORISNIK1NAZIV, "");
            this.label1KORISNIK1NAZIV.Location = new System.Drawing.Point(3, 30);
            this.label1KORISNIK1NAZIV.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1KORISNIK1NAZIV.Name = "label1KORISNIK1NAZIV";
            this.errorProviderValidator1.SetRegularExpression(this.label1KORISNIK1NAZIV, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1KORISNIK1NAZIV, "");
            this.errorProviderValidator1.SetRequired(this.label1KORISNIK1NAZIV, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1KORISNIK1NAZIV, "");
            this.label1KORISNIK1NAZIV.Size = new System.Drawing.Size(85, 14);
            this.label1KORISNIK1NAZIV.StyleSetName = "FieldUltraLabel";
            this.label1KORISNIK1NAZIV.TabIndex = 1;
            this.label1KORISNIK1NAZIV.Tag = "labelKORISNIK1NAZIV";
            this.label1KORISNIK1NAZIV.Text = "Naziv (korisnik):";
            // 
            // textKORISNIK1NAZIV
            // 
            this.textKORISNIK1NAZIV.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textKORISNIK1NAZIV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "KORISNIK1NAZIV", true));
            this.errorProviderValidator1.SetDisplayName(this.textKORISNIK1NAZIV, "");
            this.textKORISNIK1NAZIV.Location = new System.Drawing.Point(232, 26);
            this.textKORISNIK1NAZIV.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textKORISNIK1NAZIV.MaxLength = 50;
            this.textKORISNIK1NAZIV.MinimumSize = new System.Drawing.Size(300, 22);
            this.textKORISNIK1NAZIV.Name = "textKORISNIK1NAZIV";
            this.errorProviderValidator1.SetRegularExpression(this.textKORISNIK1NAZIV, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textKORISNIK1NAZIV, "");
            this.errorProviderValidator1.SetRequired(this.textKORISNIK1NAZIV, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textKORISNIK1NAZIV, "");
            this.textKORISNIK1NAZIV.Size = new System.Drawing.Size(300, 22);
            this.textKORISNIK1NAZIV.TabIndex = 0;
            this.textKORISNIK1NAZIV.Tag = "KORISNIK1NAZIV";
            this.textKORISNIK1NAZIV.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1KORISNIK1ADRESA
            // 
            this.label1KORISNIK1ADRESA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.TextVAlignAsString = "Middle";
            this.label1KORISNIK1ADRESA.Appearance = appearance13;
            this.label1KORISNIK1ADRESA.AutoSize = true;
            this.label1KORISNIK1ADRESA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1KORISNIK1ADRESA, "");
            this.label1KORISNIK1ADRESA.Location = new System.Drawing.Point(3, 55);
            this.label1KORISNIK1ADRESA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1KORISNIK1ADRESA.Name = "label1KORISNIK1ADRESA";
            this.errorProviderValidator1.SetRegularExpression(this.label1KORISNIK1ADRESA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1KORISNIK1ADRESA, "");
            this.errorProviderValidator1.SetRequired(this.label1KORISNIK1ADRESA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1KORISNIK1ADRESA, "");
            this.label1KORISNIK1ADRESA.Size = new System.Drawing.Size(109, 14);
            this.label1KORISNIK1ADRESA.StyleSetName = "FieldUltraLabel";
            this.label1KORISNIK1ADRESA.TabIndex = 1;
            this.label1KORISNIK1ADRESA.Tag = "labelKORISNIK1ADRESA";
            this.label1KORISNIK1ADRESA.Text = "Ulica i broj (korisnik):";
            // 
            // textKORISNIK1ADRESA
            // 
            this.textKORISNIK1ADRESA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textKORISNIK1ADRESA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "KORISNIK1ADRESA", true));
            this.errorProviderValidator1.SetDisplayName(this.textKORISNIK1ADRESA, "");
            this.textKORISNIK1ADRESA.Location = new System.Drawing.Point(232, 51);
            this.textKORISNIK1ADRESA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textKORISNIK1ADRESA.MaxLength = 50;
            this.textKORISNIK1ADRESA.MinimumSize = new System.Drawing.Size(300, 22);
            this.textKORISNIK1ADRESA.Name = "textKORISNIK1ADRESA";
            this.errorProviderValidator1.SetRegularExpression(this.textKORISNIK1ADRESA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textKORISNIK1ADRESA, "");
            this.errorProviderValidator1.SetRequired(this.textKORISNIK1ADRESA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textKORISNIK1ADRESA, "");
            this.textKORISNIK1ADRESA.Size = new System.Drawing.Size(300, 22);
            this.textKORISNIK1ADRESA.TabIndex = 0;
            this.textKORISNIK1ADRESA.Tag = "KORISNIK1ADRESA";
            this.textKORISNIK1ADRESA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1KORISNIK1MJESTO
            // 
            this.label1KORISNIK1MJESTO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextVAlignAsString = "Middle";
            this.label1KORISNIK1MJESTO.Appearance = appearance14;
            this.label1KORISNIK1MJESTO.AutoSize = true;
            this.label1KORISNIK1MJESTO.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1KORISNIK1MJESTO, "");
            this.label1KORISNIK1MJESTO.Location = new System.Drawing.Point(3, 80);
            this.label1KORISNIK1MJESTO.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1KORISNIK1MJESTO.Name = "label1KORISNIK1MJESTO";
            this.errorProviderValidator1.SetRegularExpression(this.label1KORISNIK1MJESTO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1KORISNIK1MJESTO, "");
            this.errorProviderValidator1.SetRequired(this.label1KORISNIK1MJESTO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1KORISNIK1MJESTO, "");
            this.label1KORISNIK1MJESTO.Size = new System.Drawing.Size(90, 14);
            this.label1KORISNIK1MJESTO.StyleSetName = "FieldUltraLabel";
            this.label1KORISNIK1MJESTO.TabIndex = 1;
            this.label1KORISNIK1MJESTO.Tag = "labelKORISNIK1MJESTO";
            this.label1KORISNIK1MJESTO.Text = "Mjesto (korisnik):";
            // 
            // textKORISNIK1MJESTO
            // 
            this.textKORISNIK1MJESTO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textKORISNIK1MJESTO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "KORISNIK1MJESTO", true));
            this.errorProviderValidator1.SetDisplayName(this.textKORISNIK1MJESTO, "");
            this.textKORISNIK1MJESTO.Location = new System.Drawing.Point(232, 76);
            this.textKORISNIK1MJESTO.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textKORISNIK1MJESTO.MaxLength = 50;
            this.textKORISNIK1MJESTO.MinimumSize = new System.Drawing.Size(300, 22);
            this.textKORISNIK1MJESTO.Name = "textKORISNIK1MJESTO";
            this.errorProviderValidator1.SetRegularExpression(this.textKORISNIK1MJESTO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textKORISNIK1MJESTO, "");
            this.errorProviderValidator1.SetRequired(this.textKORISNIK1MJESTO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textKORISNIK1MJESTO, "");
            this.textKORISNIK1MJESTO.Size = new System.Drawing.Size(300, 22);
            this.textKORISNIK1MJESTO.TabIndex = 0;
            this.textKORISNIK1MJESTO.Tag = "KORISNIK1MJESTO";
            this.textKORISNIK1MJESTO.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1KORISNIKOIB
            // 
            this.label1KORISNIKOIB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextVAlignAsString = "Middle";
            this.label1KORISNIKOIB.Appearance = appearance15;
            this.label1KORISNIKOIB.AutoSize = true;
            this.label1KORISNIKOIB.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1KORISNIKOIB, "");
            this.label1KORISNIKOIB.Location = new System.Drawing.Point(3, 105);
            this.label1KORISNIKOIB.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1KORISNIKOIB.Name = "label1KORISNIKOIB";
            this.errorProviderValidator1.SetRegularExpression(this.label1KORISNIKOIB, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1KORISNIKOIB, "");
            this.errorProviderValidator1.SetRequired(this.label1KORISNIKOIB, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1KORISNIKOIB, "");
            this.label1KORISNIKOIB.Size = new System.Drawing.Size(138, 14);
            this.label1KORISNIKOIB.StyleSetName = "FieldUltraLabel";
            this.label1KORISNIKOIB.TabIndex = 1;
            this.label1KORISNIKOIB.Tag = "labelKORISNIKOIB";
            this.label1KORISNIKOIB.Text = "Osobni identifikacijski broj:";
            // 
            // textKORISNIKOIB
            // 
            this.textKORISNIKOIB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textKORISNIKOIB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "KORISNIKOIB", true));
            this.errorProviderValidator1.SetDisplayName(this.textKORISNIKOIB, "");
            this.textKORISNIKOIB.Location = new System.Drawing.Point(232, 101);
            this.textKORISNIKOIB.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textKORISNIKOIB.MaxLength = 11;
            this.textKORISNIKOIB.MinimumSize = new System.Drawing.Size(93, 22);
            this.textKORISNIKOIB.Name = "textKORISNIKOIB";
            this.errorProviderValidator1.SetRegularExpression(this.textKORISNIKOIB, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textKORISNIKOIB, "");
            this.errorProviderValidator1.SetRequired(this.textKORISNIKOIB, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textKORISNIKOIB, "");
            this.textKORISNIKOIB.Size = new System.Drawing.Size(93, 22);
            this.textKORISNIKOIB.TabIndex = 0;
            this.textKORISNIKOIB.Tag = "KORISNIKOIB";
            this.textKORISNIKOIB.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1MBKORISNIK
            // 
            this.label1MBKORISNIK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextVAlignAsString = "Middle";
            this.label1MBKORISNIK.Appearance = appearance16;
            this.label1MBKORISNIK.AutoSize = true;
            this.label1MBKORISNIK.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1MBKORISNIK, "");
            this.label1MBKORISNIK.Location = new System.Drawing.Point(3, 130);
            this.label1MBKORISNIK.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1MBKORISNIK.Name = "label1MBKORISNIK";
            this.errorProviderValidator1.SetRegularExpression(this.label1MBKORISNIK, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1MBKORISNIK, "");
            this.errorProviderValidator1.SetRequired(this.label1MBKORISNIK, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1MBKORISNIK, "");
            this.label1MBKORISNIK.Size = new System.Drawing.Size(113, 14);
            this.label1MBKORISNIK.StyleSetName = "FieldUltraLabel";
            this.label1MBKORISNIK.TabIndex = 1;
            this.label1MBKORISNIK.Tag = "labelMBKORISNIK";
            this.label1MBKORISNIK.Text = "Matični broj korisnika:";
            // 
            // textMBKORISNIK
            // 
            this.textMBKORISNIK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textMBKORISNIK.ContextMenu = this.contextMenu1;
            this.textMBKORISNIK.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "MBKORISNIK", true));
            this.errorProviderValidator1.SetDisplayName(this.textMBKORISNIK, "");
            this.textMBKORISNIK.Location = new System.Drawing.Point(232, 126);
            this.textMBKORISNIK.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textMBKORISNIK.MaxLength = 8;
            this.textMBKORISNIK.MinimumSize = new System.Drawing.Size(72, 22);
            this.textMBKORISNIK.Name = "textMBKORISNIK";
            this.errorProviderValidator1.SetRegularExpression(this.textMBKORISNIK, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textMBKORISNIK, "");
            this.errorProviderValidator1.SetRequired(this.textMBKORISNIK, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textMBKORISNIK, "");
            this.textMBKORISNIK.Size = new System.Drawing.Size(72, 22);
            this.textMBKORISNIK.TabIndex = 0;
            this.textMBKORISNIK.Tag = "MBKORISNIK";
            this.textMBKORISNIK.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1MBKORISNIKJEDINICA
            // 
            this.label1MBKORISNIKJEDINICA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextVAlignAsString = "Middle";
            this.label1MBKORISNIKJEDINICA.Appearance = appearance17;
            this.label1MBKORISNIKJEDINICA.AutoSize = true;
            this.label1MBKORISNIKJEDINICA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1MBKORISNIKJEDINICA, "");
            this.label1MBKORISNIKJEDINICA.Location = new System.Drawing.Point(3, 155);
            this.label1MBKORISNIKJEDINICA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1MBKORISNIKJEDINICA.Name = "label1MBKORISNIKJEDINICA";
            this.errorProviderValidator1.SetRegularExpression(this.label1MBKORISNIKJEDINICA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1MBKORISNIKJEDINICA, "");
            this.errorProviderValidator1.SetRequired(this.label1MBKORISNIKJEDINICA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1MBKORISNIKJEDINICA, "");
            this.label1MBKORISNIKJEDINICA.Size = new System.Drawing.Size(97, 14);
            this.label1MBKORISNIKJEDINICA.StyleSetName = "FieldUltraLabel";
            this.label1MBKORISNIKJEDINICA.TabIndex = 1;
            this.label1MBKORISNIKJEDINICA.Tag = "labelMBKORISNIKJEDINICA";
            this.label1MBKORISNIKJEDINICA.Text = "Jedinica korisnika:";
            // 
            // textMBKORISNIKJEDINICA
            // 
            this.textMBKORISNIKJEDINICA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textMBKORISNIKJEDINICA.ContextMenu = this.contextMenu1;
            this.textMBKORISNIKJEDINICA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "MBKORISNIKJEDINICA", true));
            this.errorProviderValidator1.SetDisplayName(this.textMBKORISNIKJEDINICA, "");
            this.textMBKORISNIKJEDINICA.Location = new System.Drawing.Point(232, 151);
            this.textMBKORISNIKJEDINICA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textMBKORISNIKJEDINICA.MaxLength = 4;
            this.textMBKORISNIKJEDINICA.MinimumSize = new System.Drawing.Size(44, 22);
            this.textMBKORISNIKJEDINICA.Name = "textMBKORISNIKJEDINICA";
            this.errorProviderValidator1.SetRegularExpression(this.textMBKORISNIKJEDINICA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textMBKORISNIKJEDINICA, "");
            this.errorProviderValidator1.SetRequired(this.textMBKORISNIKJEDINICA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textMBKORISNIKJEDINICA, "");
            this.textMBKORISNIKJEDINICA.Size = new System.Drawing.Size(44, 22);
            this.textMBKORISNIKJEDINICA.TabIndex = 0;
            this.textMBKORISNIKJEDINICA.Tag = "MBKORISNIKJEDINICA";
            this.textMBKORISNIKJEDINICA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1JMBGKORISNIK
            // 
            this.label1JMBGKORISNIK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Middle";
            this.label1JMBGKORISNIK.Appearance = appearance18;
            this.label1JMBGKORISNIK.AutoSize = true;
            this.label1JMBGKORISNIK.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1JMBGKORISNIK, "");
            this.label1JMBGKORISNIK.Location = new System.Drawing.Point(3, 180);
            this.label1JMBGKORISNIK.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1JMBGKORISNIK.Name = "label1JMBGKORISNIK";
            this.errorProviderValidator1.SetRegularExpression(this.label1JMBGKORISNIK, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1JMBGKORISNIK, "");
            this.errorProviderValidator1.SetRequired(this.label1JMBGKORISNIK, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1JMBGKORISNIK, "");
            this.label1JMBGKORISNIK.Size = new System.Drawing.Size(87, 14);
            this.label1JMBGKORISNIK.StyleSetName = "FieldUltraLabel";
            this.label1JMBGKORISNIK.TabIndex = 1;
            this.label1JMBGKORISNIK.Tag = "labelJMBGKORISNIK";
            this.label1JMBGKORISNIK.Text = "JMBG korisnika:";
            // 
            // textJMBGKORISNIK
            // 
            this.textJMBGKORISNIK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textJMBGKORISNIK.ContextMenu = this.contextMenu1;
            this.textJMBGKORISNIK.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "JMBGKORISNIK", true));
            this.errorProviderValidator1.SetDisplayName(this.textJMBGKORISNIK, "");
            this.textJMBGKORISNIK.Location = new System.Drawing.Point(232, 176);
            this.textJMBGKORISNIK.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textJMBGKORISNIK.MaxLength = 13;
            this.textJMBGKORISNIK.MinimumSize = new System.Drawing.Size(107, 22);
            this.textJMBGKORISNIK.Name = "textJMBGKORISNIK";
            this.errorProviderValidator1.SetRegularExpression(this.textJMBGKORISNIK, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textJMBGKORISNIK, "");
            this.errorProviderValidator1.SetRequired(this.textJMBGKORISNIK, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textJMBGKORISNIK, "");
            this.textJMBGKORISNIK.Size = new System.Drawing.Size(107, 22);
            this.textJMBGKORISNIK.TabIndex = 0;
            this.textJMBGKORISNIK.Tag = "JMBGKORISNIK";
            this.textJMBGKORISNIK.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1KONTAKTOSOBA
            // 
            this.label1KONTAKTOSOBA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.label1KONTAKTOSOBA.Appearance = appearance19;
            this.label1KONTAKTOSOBA.AutoSize = true;
            this.label1KONTAKTOSOBA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1KONTAKTOSOBA, "");
            this.label1KONTAKTOSOBA.Location = new System.Drawing.Point(3, 205);
            this.label1KONTAKTOSOBA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1KONTAKTOSOBA.Name = "label1KONTAKTOSOBA";
            this.errorProviderValidator1.SetRegularExpression(this.label1KONTAKTOSOBA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1KONTAKTOSOBA, "");
            this.errorProviderValidator1.SetRequired(this.label1KONTAKTOSOBA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1KONTAKTOSOBA, "");
            this.label1KONTAKTOSOBA.Size = new System.Drawing.Size(80, 14);
            this.label1KONTAKTOSOBA.StyleSetName = "FieldUltraLabel";
            this.label1KONTAKTOSOBA.TabIndex = 1;
            this.label1KONTAKTOSOBA.Tag = "labelKONTAKTOSOBA";
            this.label1KONTAKTOSOBA.Text = "Kontakt osoba:";
            // 
            // textKONTAKTOSOBA
            // 
            this.textKONTAKTOSOBA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textKONTAKTOSOBA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "KONTAKTOSOBA", true));
            this.errorProviderValidator1.SetDisplayName(this.textKONTAKTOSOBA, "");
            this.textKONTAKTOSOBA.Location = new System.Drawing.Point(232, 201);
            this.textKONTAKTOSOBA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textKONTAKTOSOBA.MaxLength = 50;
            this.textKONTAKTOSOBA.MinimumSize = new System.Drawing.Size(300, 22);
            this.textKONTAKTOSOBA.Name = "textKONTAKTOSOBA";
            this.errorProviderValidator1.SetRegularExpression(this.textKONTAKTOSOBA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textKONTAKTOSOBA, "");
            this.errorProviderValidator1.SetRequired(this.textKONTAKTOSOBA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textKONTAKTOSOBA, "");
            this.textKONTAKTOSOBA.Size = new System.Drawing.Size(300, 22);
            this.textKONTAKTOSOBA.TabIndex = 0;
            this.textKONTAKTOSOBA.Tag = "KONTAKTOSOBA";
            this.textKONTAKTOSOBA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1KONTAKTTELEFON
            // 
            this.label1KONTAKTTELEFON.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextVAlignAsString = "Middle";
            this.label1KONTAKTTELEFON.Appearance = appearance20;
            this.label1KONTAKTTELEFON.AutoSize = true;
            this.label1KONTAKTTELEFON.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1KONTAKTTELEFON, "");
            this.label1KONTAKTTELEFON.Location = new System.Drawing.Point(3, 230);
            this.label1KONTAKTTELEFON.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1KONTAKTTELEFON.Name = "label1KONTAKTTELEFON";
            this.errorProviderValidator1.SetRegularExpression(this.label1KONTAKTTELEFON, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1KONTAKTTELEFON, "");
            this.errorProviderValidator1.SetRequired(this.label1KONTAKTTELEFON, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1KONTAKTTELEFON, "");
            this.label1KONTAKTTELEFON.Size = new System.Drawing.Size(83, 14);
            this.label1KONTAKTTELEFON.StyleSetName = "FieldUltraLabel";
            this.label1KONTAKTTELEFON.TabIndex = 1;
            this.label1KONTAKTTELEFON.Tag = "labelKONTAKTTELEFON";
            this.label1KONTAKTTELEFON.Text = "Kontakt telefon:";
            // 
            // textKONTAKTTELEFON
            // 
            this.textKONTAKTTELEFON.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textKONTAKTTELEFON.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "KONTAKTTELEFON", true));
            this.errorProviderValidator1.SetDisplayName(this.textKONTAKTTELEFON, "");
            this.textKONTAKTTELEFON.Location = new System.Drawing.Point(232, 226);
            this.textKONTAKTTELEFON.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textKONTAKTTELEFON.MaxLength = 30;
            this.textKONTAKTTELEFON.MinimumSize = new System.Drawing.Size(226, 22);
            this.textKONTAKTTELEFON.Name = "textKONTAKTTELEFON";
            this.errorProviderValidator1.SetRegularExpression(this.textKONTAKTTELEFON, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textKONTAKTTELEFON, "");
            this.errorProviderValidator1.SetRequired(this.textKONTAKTTELEFON, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textKONTAKTTELEFON, "");
            this.textKONTAKTTELEFON.Size = new System.Drawing.Size(226, 22);
            this.textKONTAKTTELEFON.TabIndex = 0;
            this.textKONTAKTTELEFON.Tag = "KONTAKTTELEFON";
            this.textKONTAKTTELEFON.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1KONTAKTFAX
            // 
            this.label1KONTAKTFAX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.TextVAlignAsString = "Middle";
            this.label1KONTAKTFAX.Appearance = appearance21;
            this.label1KONTAKTFAX.AutoSize = true;
            this.label1KONTAKTFAX.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1KONTAKTFAX, "");
            this.label1KONTAKTFAX.Location = new System.Drawing.Point(3, 255);
            this.label1KONTAKTFAX.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1KONTAKTFAX.Name = "label1KONTAKTFAX";
            this.errorProviderValidator1.SetRegularExpression(this.label1KONTAKTFAX, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1KONTAKTFAX, "");
            this.errorProviderValidator1.SetRequired(this.label1KONTAKTFAX, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1KONTAKTFAX, "");
            this.label1KONTAKTFAX.Size = new System.Drawing.Size(64, 14);
            this.label1KONTAKTFAX.StyleSetName = "FieldUltraLabel";
            this.label1KONTAKTFAX.TabIndex = 1;
            this.label1KONTAKTFAX.Tag = "labelKONTAKTFAX";
            this.label1KONTAKTFAX.Text = "Kontakt fax:";
            // 
            // textKONTAKTFAX
            // 
            this.textKONTAKTFAX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textKONTAKTFAX.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "KONTAKTFAX", true));
            this.errorProviderValidator1.SetDisplayName(this.textKONTAKTFAX, "");
            this.textKONTAKTFAX.Location = new System.Drawing.Point(232, 251);
            this.textKONTAKTFAX.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textKONTAKTFAX.MaxLength = 30;
            this.textKONTAKTFAX.MinimumSize = new System.Drawing.Size(226, 22);
            this.textKONTAKTFAX.Name = "textKONTAKTFAX";
            this.errorProviderValidator1.SetRegularExpression(this.textKONTAKTFAX, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textKONTAKTFAX, "");
            this.errorProviderValidator1.SetRequired(this.textKONTAKTFAX, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textKONTAKTFAX, "");
            this.textKONTAKTFAX.Size = new System.Drawing.Size(226, 22);
            this.textKONTAKTFAX.TabIndex = 0;
            this.textKONTAKTFAX.Tag = "KONTAKTFAX";
            this.textKONTAKTFAX.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1EMAIL
            // 
            this.label1EMAIL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance22.ForeColor = System.Drawing.Color.Black;
            appearance22.TextVAlignAsString = "Middle";
            this.label1EMAIL.Appearance = appearance22;
            this.label1EMAIL.AutoSize = true;
            this.label1EMAIL.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1EMAIL, "");
            this.label1EMAIL.Location = new System.Drawing.Point(3, 280);
            this.label1EMAIL.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1EMAIL.Name = "label1EMAIL";
            this.errorProviderValidator1.SetRegularExpression(this.label1EMAIL, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1EMAIL, "");
            this.errorProviderValidator1.SetRequired(this.label1EMAIL, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1EMAIL, "");
            this.label1EMAIL.Size = new System.Drawing.Size(40, 14);
            this.label1EMAIL.StyleSetName = "FieldUltraLabel";
            this.label1EMAIL.TabIndex = 1;
            this.label1EMAIL.Tag = "labelEMAIL";
            this.label1EMAIL.Text = "E-mail:";
            // 
            // label1NADLEZNAPU
            // 
            this.label1NADLEZNAPU.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.label1NADLEZNAPU.Appearance = appearance23;
            this.label1NADLEZNAPU.AutoSize = true;
            this.label1NADLEZNAPU.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1NADLEZNAPU, "");
            this.label1NADLEZNAPU.Location = new System.Drawing.Point(3, 305);
            this.label1NADLEZNAPU.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1NADLEZNAPU.Name = "label1NADLEZNAPU";
            this.errorProviderValidator1.SetRegularExpression(this.label1NADLEZNAPU, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1NADLEZNAPU, "");
            this.errorProviderValidator1.SetRequired(this.label1NADLEZNAPU, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1NADLEZNAPU, "");
            this.label1NADLEZNAPU.Size = new System.Drawing.Size(188, 14);
            this.label1NADLEZNAPU.StyleSetName = "FieldUltraLabel";
            this.label1NADLEZNAPU.TabIndex = 1;
            this.label1NADLEZNAPU.Tag = "labelNADLEZNAPU";
            this.label1NADLEZNAPU.Text = "Nadležna ispostava porezne uprave:";
            // 
            // textNADLEZNAPU
            // 
            this.textNADLEZNAPU.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textNADLEZNAPU.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "NADLEZNAPU", true));
            this.errorProviderValidator1.SetDisplayName(this.textNADLEZNAPU, "");
            this.textNADLEZNAPU.Location = new System.Drawing.Point(232, 301);
            this.textNADLEZNAPU.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textNADLEZNAPU.MaxLength = 50;
            this.textNADLEZNAPU.MinimumSize = new System.Drawing.Size(300, 22);
            this.textNADLEZNAPU.Name = "textNADLEZNAPU";
            this.errorProviderValidator1.SetRegularExpression(this.textNADLEZNAPU, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textNADLEZNAPU, "");
            this.errorProviderValidator1.SetRequired(this.textNADLEZNAPU, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textNADLEZNAPU, "");
            this.textNADLEZNAPU.Size = new System.Drawing.Size(300, 22);
            this.textNADLEZNAPU.TabIndex = 0;
            this.textNADLEZNAPU.Tag = "NADLEZNAPU";
            this.textNADLEZNAPU.MouseEnter += new System.EventHandler(this.mouseEnter_Text);

            // 
            // label1BROJCANAOZNAKAPU
            // 
            this.label1BROJCANAOZNAKAPU.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.TextVAlignAsString = "Middle";
            this.label1BROJCANAOZNAKAPU.Appearance = appearance24;
            this.label1BROJCANAOZNAKAPU.AutoSize = true;
            this.label1BROJCANAOZNAKAPU.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1BROJCANAOZNAKAPU, "");
            this.label1BROJCANAOZNAKAPU.Location = new System.Drawing.Point(3, 330);
            this.label1BROJCANAOZNAKAPU.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1BROJCANAOZNAKAPU.Name = "label1BROJCANAOZNAKAPU";
            this.errorProviderValidator1.SetRegularExpression(this.label1BROJCANAOZNAKAPU, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1BROJCANAOZNAKAPU, "");
            this.errorProviderValidator1.SetRequired(this.label1BROJCANAOZNAKAPU, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1BROJCANAOZNAKAPU, "");
            this.label1BROJCANAOZNAKAPU.Size = new System.Drawing.Size(224, 14);
            this.label1BROJCANAOZNAKAPU.StyleSetName = "FieldUltraLabel";
            this.label1BROJCANAOZNAKAPU.TabIndex = 1;
            this.label1BROJCANAOZNAKAPU.Tag = "labelBROJCANAOZNAKAPU";
            this.label1BROJCANAOZNAKAPU.Text = "Brojčana oznaka ispostave porezne uprave:";
            // 
            // textBROJCANAOZNAKAPU
            // 
            this.textBROJCANAOZNAKAPU.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBROJCANAOZNAKAPU.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceKORISNIK, "BROJCANAOZNAKAPU", true));
            this.errorProviderValidator1.SetDisplayName(this.textBROJCANAOZNAKAPU, "");
            this.textBROJCANAOZNAKAPU.Location = new System.Drawing.Point(232, 326);
            this.textBROJCANAOZNAKAPU.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textBROJCANAOZNAKAPU.MaskInput = "{LOC}-nnnnn";
            this.textBROJCANAOZNAKAPU.MinimumSize = new System.Drawing.Size(51, 22);
            this.textBROJCANAOZNAKAPU.Name = "textBROJCANAOZNAKAPU";
            this.textBROJCANAOZNAKAPU.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textBROJCANAOZNAKAPU, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textBROJCANAOZNAKAPU, "");
            this.errorProviderValidator1.SetRequired(this.textBROJCANAOZNAKAPU, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textBROJCANAOZNAKAPU, "");
            this.textBROJCANAOZNAKAPU.Size = new System.Drawing.Size(51, 22);
            this.textBROJCANAOZNAKAPU.TabIndex = 0;
            this.textBROJCANAOZNAKAPU.Tag = "BROJCANAOZNAKAPU";
            this.textBROJCANAOZNAKAPU.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textBROJCANAOZNAKAPU.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1STAZUKOEFICIJENTU
            // 
            this.label1STAZUKOEFICIJENTU.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.TextVAlignAsString = "Middle";
            this.label1STAZUKOEFICIJENTU.Appearance = appearance25;
            this.label1STAZUKOEFICIJENTU.AutoSize = true;
            this.label1STAZUKOEFICIJENTU.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1STAZUKOEFICIJENTU, "");
            this.label1STAZUKOEFICIJENTU.Location = new System.Drawing.Point(3, 351);
            this.label1STAZUKOEFICIJENTU.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1STAZUKOEFICIJENTU.Name = "label1STAZUKOEFICIJENTU";
            this.errorProviderValidator1.SetRegularExpression(this.label1STAZUKOEFICIJENTU, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1STAZUKOEFICIJENTU, "");
            this.errorProviderValidator1.SetRequired(this.label1STAZUKOEFICIJENTU, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1STAZUKOEFICIJENTU, "");
            this.label1STAZUKOEFICIJENTU.Size = new System.Drawing.Size(142, 14);
            this.label1STAZUKOEFICIJENTU.StyleSetName = "FieldUltraLabel";
            this.label1STAZUKOEFICIJENTU.TabIndex = 1;
            this.label1STAZUKOEFICIJENTU.Tag = "labelSTAZUKOEFICIJENTU";
            this.label1STAZUKOEFICIJENTU.Text = "Staž sadržan u koeficijentu:";
            // 
            // checkSTAZUKOEFICIJENTU
            // 
            this.checkSTAZUKOEFICIJENTU.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorProviderValidator1.SetDisplayName(this.checkSTAZUKOEFICIJENTU, "");
            this.checkSTAZUKOEFICIJENTU.Location = new System.Drawing.Point(232, 351);
            this.checkSTAZUKOEFICIJENTU.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.checkSTAZUKOEFICIJENTU.MinimumSize = new System.Drawing.Size(13, 13);
            this.checkSTAZUKOEFICIJENTU.Name = "checkSTAZUKOEFICIJENTU";
            this.errorProviderValidator1.SetRegularExpression(this.checkSTAZUKOEFICIJENTU, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.checkSTAZUKOEFICIJENTU, "");
            this.errorProviderValidator1.SetRequired(this.checkSTAZUKOEFICIJENTU, false);
            this.errorProviderValidator1.SetRequiredMessage(this.checkSTAZUKOEFICIJENTU, "");
            this.checkSTAZUKOEFICIJENTU.Size = new System.Drawing.Size(13, 13);
            this.checkSTAZUKOEFICIJENTU.TabIndex = 0;
            this.checkSTAZUKOEFICIJENTU.Tag = "STAZUKOEFICIJENTU";
            this.checkSTAZUKOEFICIJENTU.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1RKP
            // 
            this.label1RKP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.TextVAlignAsString = "Middle";
            this.label1RKP.Appearance = appearance26;
            this.label1RKP.AutoSize = true;
            this.label1RKP.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1RKP, "");
            this.label1RKP.Location = new System.Drawing.Point(3, 372);
            this.label1RKP.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1RKP.Name = "label1RKP";
            this.errorProviderValidator1.SetRegularExpression(this.label1RKP, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1RKP, "");
            this.errorProviderValidator1.SetRequired(this.label1RKP, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1RKP, "");
            this.label1RKP.Size = new System.Drawing.Size(147, 14);
            this.label1RKP.StyleSetName = "FieldUltraLabel";
            this.label1RKP.TabIndex = 1;
            this.label1RKP.Tag = "labelRKP";
            this.label1RKP.Text = "Šifra u registru korisnika DP:";
            // 
            // textRKP
            // 
            this.textRKP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textRKP.ContextMenu = this.contextMenu1;
            this.textRKP.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceKORISNIK, "RKP", true));
            this.errorProviderValidator1.SetDisplayName(this.textRKP, "");
            this.textRKP.Location = new System.Drawing.Point(232, 368);
            this.textRKP.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textRKP.MaskInput = "{LOC}-nnnnn";
            this.textRKP.MinimumSize = new System.Drawing.Size(51, 22);
            this.textRKP.Name = "textRKP";
            this.textRKP.Nullable = true;
            this.textRKP.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textRKP, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textRKP, "");
            this.errorProviderValidator1.SetRequired(this.textRKP, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textRKP, "");
            this.textRKP.Size = new System.Drawing.Size(51, 22);
            this.textRKP.TabIndex = 0;
            this.textRKP.Tag = "RKP";
            this.textRKP.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textRKP.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1PREZIMEIMEOVLASTENEOSOBE
            // 
            this.label1PREZIMEIMEOVLASTENEOSOBE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.TextVAlignAsString = "Middle";
            this.label1PREZIMEIMEOVLASTENEOSOBE.Appearance = appearance27;
            this.label1PREZIMEIMEOVLASTENEOSOBE.AutoSize = true;
            this.label1PREZIMEIMEOVLASTENEOSOBE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PREZIMEIMEOVLASTENEOSOBE, "");
            this.label1PREZIMEIMEOVLASTENEOSOBE.Location = new System.Drawing.Point(3, 397);
            this.label1PREZIMEIMEOVLASTENEOSOBE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PREZIMEIMEOVLASTENEOSOBE.Name = "label1PREZIMEIMEOVLASTENEOSOBE";
            this.errorProviderValidator1.SetRegularExpression(this.label1PREZIMEIMEOVLASTENEOSOBE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PREZIMEIMEOVLASTENEOSOBE, "");
            this.errorProviderValidator1.SetRequired(this.label1PREZIMEIMEOVLASTENEOSOBE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PREZIMEIMEOVLASTENEOSOBE, "");
            this.label1PREZIMEIMEOVLASTENEOSOBE.Size = new System.Drawing.Size(161, 14);
            this.label1PREZIMEIMEOVLASTENEOSOBE.StyleSetName = "FieldUltraLabel";
            this.label1PREZIMEIMEOVLASTENEOSOBE.TabIndex = 1;
            this.label1PREZIMEIMEOVLASTENEOSOBE.Tag = "labelPREZIMEIMEOVLASTENEOSOBE";
            this.label1PREZIMEIMEOVLASTENEOSOBE.Text = "Prezime i ime ovlaštene osobe:";
            // 
            // textPREZIMEIMEOVLASTENEOSOBE
            // 
            this.textPREZIMEIMEOVLASTENEOSOBE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPREZIMEIMEOVLASTENEOSOBE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "PREZIMEIMEOVLASTENEOSOBE", true));
            this.errorProviderValidator1.SetDisplayName(this.textPREZIMEIMEOVLASTENEOSOBE, "");
            this.textPREZIMEIMEOVLASTENEOSOBE.Location = new System.Drawing.Point(232, 393);
            this.textPREZIMEIMEOVLASTENEOSOBE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPREZIMEIMEOVLASTENEOSOBE.MaxLength = 50;
            this.textPREZIMEIMEOVLASTENEOSOBE.MinimumSize = new System.Drawing.Size(300, 22);
            this.textPREZIMEIMEOVLASTENEOSOBE.Name = "textPREZIMEIMEOVLASTENEOSOBE";
            this.errorProviderValidator1.SetRegularExpression(this.textPREZIMEIMEOVLASTENEOSOBE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPREZIMEIMEOVLASTENEOSOBE, "");
            this.errorProviderValidator1.SetRequired(this.textPREZIMEIMEOVLASTENEOSOBE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPREZIMEIMEOVLASTENEOSOBE, "");
            this.textPREZIMEIMEOVLASTENEOSOBE.Size = new System.Drawing.Size(300, 22);
            this.textPREZIMEIMEOVLASTENEOSOBE.TabIndex = 0;
            this.textPREZIMEIMEOVLASTENEOSOBE.Tag = "PREZIMEIMEOVLASTENEOSOBE";
            this.textPREZIMEIMEOVLASTENEOSOBE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1ADRESAOVLASTENEOSOBE
            // 
            this.label1ADRESAOVLASTENEOSOBE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.TextVAlignAsString = "Middle";
            this.label1ADRESAOVLASTENEOSOBE.Appearance = appearance28;
            this.label1ADRESAOVLASTENEOSOBE.AutoSize = true;
            this.label1ADRESAOVLASTENEOSOBE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1ADRESAOVLASTENEOSOBE, "");
            this.label1ADRESAOVLASTENEOSOBE.Location = new System.Drawing.Point(3, 422);
            this.label1ADRESAOVLASTENEOSOBE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1ADRESAOVLASTENEOSOBE.Name = "label1ADRESAOVLASTENEOSOBE";
            this.errorProviderValidator1.SetRegularExpression(this.label1ADRESAOVLASTENEOSOBE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1ADRESAOVLASTENEOSOBE, "");
            this.errorProviderValidator1.SetRequired(this.label1ADRESAOVLASTENEOSOBE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1ADRESAOVLASTENEOSOBE, "");
            this.label1ADRESAOVLASTENEOSOBE.Size = new System.Drawing.Size(129, 14);
            this.label1ADRESAOVLASTENEOSOBE.StyleSetName = "FieldUltraLabel";
            this.label1ADRESAOVLASTENEOSOBE.TabIndex = 1;
            this.label1ADRESAOVLASTENEOSOBE.Tag = "labelADRESAOVLASTENEOSOBE";
            this.label1ADRESAOVLASTENEOSOBE.Text = "Adresa ovlaštene osobe:";
            // 
            // textADRESAOVLASTENEOSOBE
            // 
            this.textADRESAOVLASTENEOSOBE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textADRESAOVLASTENEOSOBE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "ADRESAOVLASTENEOSOBE", true));
            this.errorProviderValidator1.SetDisplayName(this.textADRESAOVLASTENEOSOBE, "");
            this.textADRESAOVLASTENEOSOBE.Location = new System.Drawing.Point(232, 418);
            this.textADRESAOVLASTENEOSOBE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textADRESAOVLASTENEOSOBE.MaxLength = 50;
            this.textADRESAOVLASTENEOSOBE.MinimumSize = new System.Drawing.Size(300, 22);
            this.textADRESAOVLASTENEOSOBE.Name = "textADRESAOVLASTENEOSOBE";
            this.errorProviderValidator1.SetRegularExpression(this.textADRESAOVLASTENEOSOBE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textADRESAOVLASTENEOSOBE, "");
            this.errorProviderValidator1.SetRequired(this.textADRESAOVLASTENEOSOBE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textADRESAOVLASTENEOSOBE, "");
            this.textADRESAOVLASTENEOSOBE.Size = new System.Drawing.Size(300, 22);
            this.textADRESAOVLASTENEOSOBE.TabIndex = 0;
            this.textADRESAOVLASTENEOSOBE.Tag = "ADRESAOVLASTENEOSOBE";
            this.textADRESAOVLASTENEOSOBE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1OIBOVLASTENEOSOBE
            // 
            this.label1OIBOVLASTENEOSOBE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.TextVAlignAsString = "Middle";
            this.label1OIBOVLASTENEOSOBE.Appearance = appearance29;
            this.label1OIBOVLASTENEOSOBE.AutoSize = true;
            this.label1OIBOVLASTENEOSOBE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OIBOVLASTENEOSOBE, "");
            this.label1OIBOVLASTENEOSOBE.Location = new System.Drawing.Point(3, 447);
            this.label1OIBOVLASTENEOSOBE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OIBOVLASTENEOSOBE.Name = "label1OIBOVLASTENEOSOBE";
            this.errorProviderValidator1.SetRegularExpression(this.label1OIBOVLASTENEOSOBE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OIBOVLASTENEOSOBE, "");
            this.errorProviderValidator1.SetRequired(this.label1OIBOVLASTENEOSOBE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OIBOVLASTENEOSOBE, "");
            this.label1OIBOVLASTENEOSOBE.Size = new System.Drawing.Size(112, 14);
            this.label1OIBOVLASTENEOSOBE.StyleSetName = "FieldUltraLabel";
            this.label1OIBOVLASTENEOSOBE.TabIndex = 1;
            this.label1OIBOVLASTENEOSOBE.Tag = "labelOIBOVLASTENEOSOBE";
            this.label1OIBOVLASTENEOSOBE.Text = "OIB ovlaštene osobe:";
            // 
            // textOIBOVLASTENEOSOBE
            // 
            this.textOIBOVLASTENEOSOBE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOIBOVLASTENEOSOBE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "OIBOVLASTENEOSOBE", true));
            this.errorProviderValidator1.SetDisplayName(this.textOIBOVLASTENEOSOBE, "");
            this.textOIBOVLASTENEOSOBE.Location = new System.Drawing.Point(232, 443);
            this.textOIBOVLASTENEOSOBE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOIBOVLASTENEOSOBE.MaxLength = 11;
            this.textOIBOVLASTENEOSOBE.MinimumSize = new System.Drawing.Size(93, 22);
            this.textOIBOVLASTENEOSOBE.Name = "textOIBOVLASTENEOSOBE";
            this.errorProviderValidator1.SetRegularExpression(this.textOIBOVLASTENEOSOBE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOIBOVLASTENEOSOBE, "");
            this.errorProviderValidator1.SetRequired(this.textOIBOVLASTENEOSOBE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOIBOVLASTENEOSOBE, "");
            this.textOIBOVLASTENEOSOBE.Size = new System.Drawing.Size(93, 22);
            this.textOIBOVLASTENEOSOBE.TabIndex = 0;
            this.textOIBOVLASTENEOSOBE.Tag = "OIBOVLASTENEOSOBE";
            this.textOIBOVLASTENEOSOBE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // grdLevelKORISNIKLevel1
            // 
            this.grdLevelKORISNIKLevel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutManagerformKORISNIK.SetColumnSpan(this.grdLevelKORISNIKLevel1, 4);
            this.grdLevelKORISNIKLevel1.DataSource = this.bindingSourceKORISNIKLevel1;
            appearance36.TextHAlignAsString = "Left";
            this.grdLevelKORISNIKLevel1.DisplayLayout.Appearance = appearance36;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            appearance3.TextHAlignAsString = "Right";
            ultraGridColumn1.CellAppearance = appearance3;
            ultraGridColumn1.Format = "";
            ultraGridColumn1.Header.Caption = "Šifra korisnika";
            ultraGridColumn1.Header.VisiblePosition = 10;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.MaskInput = "{LOC}-nnnnn";
            ultraGridColumn1.PromptChar = ' ';
            ultraGridColumn1.Width = 119;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            appearance4.TextHAlignAsString = "Right";
            ultraGridColumn2.CellAppearance = appearance4;
            ultraGridColumn2.Format = "";
            ultraGridColumn2.Header.Caption = "Šifra";
            ultraGridColumn2.Header.VisiblePosition = 0;
            ultraGridColumn2.MaskInput = "{LOC}-nnnnn";
            ultraGridColumn2.PromptChar = ' ';
            ultraGridColumn2.Width = 51;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn3.Format = "";
            ultraGridColumn3.Header.Caption = "Platitelj (1) na virmanu";
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.Width = 184;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn4.Format = "";
            ultraGridColumn4.Header.Caption = "Platitelj (2) na virmanu";
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.Width = 184;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn5.Format = "";
            ultraGridColumn5.Header.Caption = "Platitelj (3) na virmanu";
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn5.Width = 184;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn6.Format = "";
            ultraGridColumn6.Header.Caption = "VBDI Žrn-a";
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridColumn6.Width = 86;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn7.Format = "";
            ultraGridColumn7.Header.Caption = "Žrn";
            ultraGridColumn7.Header.VisiblePosition = 5;
            ultraGridColumn7.Width = 86;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn8.Format = "";
            ultraGridColumn8.Header.Caption = "Izvor dok";
            ultraGridColumn8.Header.VisiblePosition = 6;
            ultraGridColumn8.Width = 79;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            ultraGridColumn9.Format = "";
            ultraGridColumn9.Header.VisiblePosition = 7;
            ultraGridColumn9.Width = 156;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn10.Format = "";
            ultraGridColumn10.Header.Caption = "Zajednički virman poreza i prireza";
            ultraGridColumn10.Header.VisiblePosition = 8;
            ultraGridColumn10.Width = 254;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            ultraGridColumn11.Format = "";
            ultraGridColumn11.Header.Caption = "Pozivi na broj zaduženja na virmanima";
            ultraGridColumn11.Header.VisiblePosition = 9;
            ultraGridColumn11.Width = 275;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11});
            this.grdLevelKORISNIKLevel1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdLevelKORISNIKLevel1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.grdLevelKORISNIKLevel1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            this.grdLevelKORISNIKLevel1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdLevelKORISNIKLevel1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.errorProviderValidator1.SetDisplayName(this.grdLevelKORISNIKLevel1, "");
            this.grdLevelKORISNIKLevel1.Location = new System.Drawing.Point(5, 477);
            this.grdLevelKORISNIKLevel1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.grdLevelKORISNIKLevel1.MinimumSize = new System.Drawing.Size(100, 125);
            this.grdLevelKORISNIKLevel1.Name = "grdLevelKORISNIKLevel1";
            this.errorProviderValidator1.SetRegularExpression(this.grdLevelKORISNIKLevel1, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.grdLevelKORISNIKLevel1, "");
            this.errorProviderValidator1.SetRequired(this.grdLevelKORISNIKLevel1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.grdLevelKORISNIKLevel1, "");
            this.grdLevelKORISNIKLevel1.Size = new System.Drawing.Size(1075, 125);
            this.grdLevelKORISNIKLevel1.TabIndex = 56;
            this.grdLevelKORISNIKLevel1.Tag = "KORISNIKLevel1";
            this.grdLevelKORISNIKLevel1.AfterCellActivate += new System.EventHandler(this.CellChanged);
            this.grdLevelKORISNIKLevel1.AfterRowActivate += new System.EventHandler(this.grdLevelKORISNIKLevel1_AfterRowActivate);
            this.grdLevelKORISNIKLevel1.AfterRowInsert += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.grdLevelKORISNIKLevel1_AfterRowInsert);
            this.grdLevelKORISNIKLevel1.ClickCellButton += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelKORISNIKLevel1.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grdLevelKORISNIKLevel1_DoubleClick);
            this.grdLevelKORISNIKLevel1.Enter += new System.EventHandler(this.grdLevelKORISNIKLevel1_Enter);
            // 
            // bindingSourceKORISNIKLevel1
            // 
            this.bindingSourceKORISNIKLevel1.DataMember = "KORISNIK_KORISNIKLevel1";
            this.bindingSourceKORISNIKLevel1.DataSource = this.bindingSourceKORISNIK;
            // 
            // panelactionsKORISNIKLevel1
            // 
            this.panelactionsKORISNIKLevel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelactionsKORISNIKLevel1.BackColor = System.Drawing.Color.Transparent;
            this.layoutManagerformKORISNIK.SetColumnSpan(this.panelactionsKORISNIKLevel1, 4);
            this.panelactionsKORISNIKLevel1.Controls.Add(this.layoutManagerpanelactionsKORISNIKLevel1);
            this.errorProviderValidator1.SetDisplayName(this.panelactionsKORISNIKLevel1, "");
            this.panelactionsKORISNIKLevel1.Location = new System.Drawing.Point(0, 612);
            this.panelactionsKORISNIKLevel1.Margin = new System.Windows.Forms.Padding(0);
            this.panelactionsKORISNIKLevel1.MinimumSize = new System.Drawing.Size(762, 25);
            this.panelactionsKORISNIKLevel1.Name = "panelactionsKORISNIKLevel1";
            this.errorProviderValidator1.SetRegularExpression(this.panelactionsKORISNIKLevel1, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.panelactionsKORISNIKLevel1, "");
            this.errorProviderValidator1.SetRequired(this.panelactionsKORISNIKLevel1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.panelactionsKORISNIKLevel1, "");
            this.panelactionsKORISNIKLevel1.Size = new System.Drawing.Size(1085, 26);
            this.panelactionsKORISNIKLevel1.TabIndex = 57;
            // 
            // layoutManagerpanelactionsKORISNIKLevel1
            // 
            this.layoutManagerpanelactionsKORISNIKLevel1.AutoSize = true;
            this.layoutManagerpanelactionsKORISNIKLevel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsKORISNIKLevel1.ColumnCount = 4;
            this.layoutManagerpanelactionsKORISNIKLevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsKORISNIKLevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsKORISNIKLevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsKORISNIKLevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsKORISNIKLevel1.Controls.Add(this.linkLabelKORISNIKLevel1Add, 0, 0);
            this.layoutManagerpanelactionsKORISNIKLevel1.Controls.Add(this.linkLabelKORISNIKLevel1Update, 1, 0);
            this.layoutManagerpanelactionsKORISNIKLevel1.Controls.Add(this.linkLabelKORISNIKLevel1Delete, 2, 0);
            this.errorProviderValidator1.SetDisplayName(this.layoutManagerpanelactionsKORISNIKLevel1, "");
            this.layoutManagerpanelactionsKORISNIKLevel1.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerpanelactionsKORISNIKLevel1.Name = "layoutManagerpanelactionsKORISNIKLevel1";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerpanelactionsKORISNIKLevel1, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerpanelactionsKORISNIKLevel1, "");
            this.errorProviderValidator1.SetRequired(this.layoutManagerpanelactionsKORISNIKLevel1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerpanelactionsKORISNIKLevel1, "");
            this.layoutManagerpanelactionsKORISNIKLevel1.RowCount = 1;
            this.layoutManagerpanelactionsKORISNIKLevel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerpanelactionsKORISNIKLevel1.Size = new System.Drawing.Size(752, 25);
            this.layoutManagerpanelactionsKORISNIKLevel1.TabIndex = 0;
            // 
            // linkLabelKORISNIKLevel1Add
            // 
            appearance39.FontData.UnderlineAsString = "True";
            appearance39.ForeColor = System.Drawing.Color.Blue;
            this.linkLabelKORISNIKLevel1Add.Appearance = appearance39;
            this.linkLabelKORISNIKLevel1Add.AutoSize = true;
            this.linkLabelKORISNIKLevel1Add.BackColorInternal = System.Drawing.Color.Transparent;
            this.linkLabelKORISNIKLevel1Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorProviderValidator1.SetDisplayName(this.linkLabelKORISNIKLevel1Add, "");
            this.linkLabelKORISNIKLevel1Add.Location = new System.Drawing.Point(5, 5);
            this.linkLabelKORISNIKLevel1Add.Margin = new System.Windows.Forms.Padding(5);
            this.linkLabelKORISNIKLevel1Add.MinimumSize = new System.Drawing.Size(230, 15);
            this.linkLabelKORISNIKLevel1Add.Name = "linkLabelKORISNIKLevel1Add";
            this.errorProviderValidator1.SetRegularExpression(this.linkLabelKORISNIKLevel1Add, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.linkLabelKORISNIKLevel1Add, "");
            this.errorProviderValidator1.SetRequired(this.linkLabelKORISNIKLevel1Add, false);
            this.errorProviderValidator1.SetRequiredMessage(this.linkLabelKORISNIKLevel1Add, "");
            this.linkLabelKORISNIKLevel1Add.Size = new System.Drawing.Size(230, 15);
            this.linkLabelKORISNIKLevel1Add.TabIndex = 0;
            this.linkLabelKORISNIKLevel1Add.Text = " Add Podaci o isplatnim Žrn-ima korisnika  ";
            this.linkLabelKORISNIKLevel1Add.Click += new System.EventHandler(this.KORISNIKLevel1Add_Click);
            // 
            // linkLabelKORISNIKLevel1Update
            // 
            appearance40.FontData.UnderlineAsString = "True";
            appearance40.ForeColor = System.Drawing.Color.Blue;
            this.linkLabelKORISNIKLevel1Update.Appearance = appearance40;
            this.linkLabelKORISNIKLevel1Update.AutoSize = true;
            this.linkLabelKORISNIKLevel1Update.BackColorInternal = System.Drawing.Color.Transparent;
            this.linkLabelKORISNIKLevel1Update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorProviderValidator1.SetDisplayName(this.linkLabelKORISNIKLevel1Update, "");
            this.linkLabelKORISNIKLevel1Update.Location = new System.Drawing.Point(245, 5);
            this.linkLabelKORISNIKLevel1Update.Margin = new System.Windows.Forms.Padding(5);
            this.linkLabelKORISNIKLevel1Update.MinimumSize = new System.Drawing.Size(248, 15);
            this.linkLabelKORISNIKLevel1Update.Name = "linkLabelKORISNIKLevel1Update";
            this.errorProviderValidator1.SetRegularExpression(this.linkLabelKORISNIKLevel1Update, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.linkLabelKORISNIKLevel1Update, "");
            this.errorProviderValidator1.SetRequired(this.linkLabelKORISNIKLevel1Update, false);
            this.errorProviderValidator1.SetRequiredMessage(this.linkLabelKORISNIKLevel1Update, "");
            this.linkLabelKORISNIKLevel1Update.Size = new System.Drawing.Size(248, 15);
            this.linkLabelKORISNIKLevel1Update.TabIndex = 1;
            this.linkLabelKORISNIKLevel1Update.Text = " Update Podaci o isplatnim Žrn-ima korisnika  ";
            this.linkLabelKORISNIKLevel1Update.Click += new System.EventHandler(this.KORISNIKLevel1Update_Click);
            // 
            // linkLabelKORISNIKLevel1Delete
            // 
            appearance41.FontData.UnderlineAsString = "True";
            appearance41.ForeColor = System.Drawing.Color.Blue;
            this.linkLabelKORISNIKLevel1Delete.Appearance = appearance41;
            this.linkLabelKORISNIKLevel1Delete.AutoSize = true;
            this.linkLabelKORISNIKLevel1Delete.BackColorInternal = System.Drawing.Color.Transparent;
            this.linkLabelKORISNIKLevel1Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorProviderValidator1.SetDisplayName(this.linkLabelKORISNIKLevel1Delete, "");
            this.linkLabelKORISNIKLevel1Delete.Location = new System.Drawing.Point(503, 5);
            this.linkLabelKORISNIKLevel1Delete.Margin = new System.Windows.Forms.Padding(5);
            this.linkLabelKORISNIKLevel1Delete.MinimumSize = new System.Drawing.Size(244, 15);
            this.linkLabelKORISNIKLevel1Delete.Name = "linkLabelKORISNIKLevel1Delete";
            this.errorProviderValidator1.SetRegularExpression(this.linkLabelKORISNIKLevel1Delete, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.linkLabelKORISNIKLevel1Delete, "");
            this.errorProviderValidator1.SetRequired(this.linkLabelKORISNIKLevel1Delete, false);
            this.errorProviderValidator1.SetRequiredMessage(this.linkLabelKORISNIKLevel1Delete, "");
            this.linkLabelKORISNIKLevel1Delete.Size = new System.Drawing.Size(244, 15);
            this.linkLabelKORISNIKLevel1Delete.TabIndex = 2;
            this.linkLabelKORISNIKLevel1Delete.Text = " Delete Podaci o isplatnim Žrn-ima korisnika  ";
            this.linkLabelKORISNIKLevel1Delete.Click += new System.EventHandler(this.KORISNIKLevel1Delete_Click);
            // 
            // label1ANALITIKA
            // 
            this.label1ANALITIKA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance30.ForeColor = System.Drawing.Color.Black;
            appearance30.TextVAlignAsString = "Middle";
            this.label1ANALITIKA.Appearance = appearance30;
            this.label1ANALITIKA.AutoSize = true;
            this.label1ANALITIKA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1ANALITIKA, "");
            this.label1ANALITIKA.Location = new System.Drawing.Point(538, 5);
            this.label1ANALITIKA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1ANALITIKA.Name = "label1ANALITIKA";
            this.errorProviderValidator1.SetRegularExpression(this.label1ANALITIKA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1ANALITIKA, "");
            this.errorProviderValidator1.SetRequired(this.label1ANALITIKA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1ANALITIKA, "");
            this.label1ANALITIKA.Size = new System.Drawing.Size(149, 14);
            this.label1ANALITIKA.StyleSetName = "FieldUltraLabel";
            this.label1ANALITIKA.TabIndex = 1;
            this.label1ANALITIKA.Tag = "labelANALITIKA";
            this.label1ANALITIKA.Text = "Analitika u računskom planu:";
            // 
            // label1KORISNIK1HZZO
            // 
            this.label1KORISNIK1HZZO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance31.ForeColor = System.Drawing.Color.Black;
            appearance31.TextVAlignAsString = "Middle";
            this.label1KORISNIK1HZZO.Appearance = appearance31;
            this.label1KORISNIK1HZZO.AutoSize = true;
            this.label1KORISNIK1HZZO.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1KORISNIK1HZZO, "");
            this.label1KORISNIK1HZZO.Location = new System.Drawing.Point(538, 30);
            this.label1KORISNIK1HZZO.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1KORISNIK1HZZO.Name = "label1KORISNIK1HZZO";
            this.errorProviderValidator1.SetRegularExpression(this.label1KORISNIK1HZZO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1KORISNIK1HZZO, "");
            this.errorProviderValidator1.SetRequired(this.label1KORISNIK1HZZO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1KORISNIK1HZZO, "");
            this.label1KORISNIK1HZZO.Size = new System.Drawing.Size(141, 14);
            this.label1KORISNIK1HZZO.StyleSetName = "FieldUltraLabel";
            this.label1KORISNIK1HZZO.TabIndex = 1;
            this.label1KORISNIK1HZZO.Tag = "labelKORISNIK1HZZO";
            this.label1KORISNIK1HZZO.Text = "Broj obveze (HZZO) za R1:";
            // 
            // textANALITIKA
            // 
            this.textANALITIKA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textANALITIKA.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceKORISNIK, "ANALITIKA", true));
            this.errorProviderValidator1.SetDisplayName(this.textANALITIKA, "");
            this.textANALITIKA.Location = new System.Drawing.Point(772, 1);
            this.textANALITIKA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textANALITIKA.MaskInput = "{LOC}-nnnnn";
            this.textANALITIKA.MinimumSize = new System.Drawing.Size(51, 22);
            this.textANALITIKA.Name = "textANALITIKA";
            this.textANALITIKA.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textANALITIKA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textANALITIKA, "");
            this.errorProviderValidator1.SetRequired(this.textANALITIKA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textANALITIKA, "");
            this.textANALITIKA.Size = new System.Drawing.Size(51, 22);
            this.textANALITIKA.TabIndex = 0;
            this.textANALITIKA.Tag = "ANALITIKA";
            this.textANALITIKA.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textANALITIKA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // textKORISNIK1HZZO
            // 
            this.textKORISNIK1HZZO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textKORISNIK1HZZO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "KORISNIK1HZZO", true));
            this.errorProviderValidator1.SetDisplayName(this.textKORISNIK1HZZO, "");
            this.textKORISNIK1HZZO.Location = new System.Drawing.Point(772, 26);
            this.textKORISNIK1HZZO.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textKORISNIK1HZZO.MaxLength = 11;
            this.textKORISNIK1HZZO.MinimumSize = new System.Drawing.Size(93, 22);
            this.textKORISNIK1HZZO.Name = "textKORISNIK1HZZO";
            this.errorProviderValidator1.SetRegularExpression(this.textKORISNIK1HZZO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textKORISNIK1HZZO, "");
            this.errorProviderValidator1.SetRequired(this.textKORISNIK1HZZO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textKORISNIK1HZZO, "");
            this.textKORISNIK1HZZO.Size = new System.Drawing.Size(93, 22);
            this.textKORISNIK1HZZO.TabIndex = 0;
            this.textKORISNIK1HZZO.Tag = "KORISNIK1HZZO";
            this.textKORISNIK1HZZO.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1KORISNIK1NAZIVZANALJEPNICE
            // 
            this.label1KORISNIK1NAZIVZANALJEPNICE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance32.ForeColor = System.Drawing.Color.Black;
            appearance32.TextVAlignAsString = "Middle";
            this.label1KORISNIK1NAZIVZANALJEPNICE.Appearance = appearance32;
            this.label1KORISNIK1NAZIVZANALJEPNICE.AutoSize = true;
            this.label1KORISNIK1NAZIVZANALJEPNICE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1KORISNIK1NAZIVZANALJEPNICE, "");
            this.label1KORISNIK1NAZIVZANALJEPNICE.Location = new System.Drawing.Point(538, 55);
            this.label1KORISNIK1NAZIVZANALJEPNICE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1KORISNIK1NAZIVZANALJEPNICE.Name = "label1KORISNIK1NAZIVZANALJEPNICE";
            this.errorProviderValidator1.SetRegularExpression(this.label1KORISNIK1NAZIVZANALJEPNICE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1KORISNIK1NAZIVZANALJEPNICE, "");
            this.errorProviderValidator1.SetRequired(this.label1KORISNIK1NAZIVZANALJEPNICE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1KORISNIK1NAZIVZANALJEPNICE, "");
            this.label1KORISNIK1NAZIVZANALJEPNICE.Size = new System.Drawing.Size(229, 14);
            this.label1KORISNIK1NAZIVZANALJEPNICE.StyleSetName = "FieldUltraLabel";
            this.label1KORISNIK1NAZIVZANALJEPNICE.TabIndex = 1;
            this.label1KORISNIK1NAZIVZANALJEPNICE.Tag = "labelKORISNIK1NAZIVZANALJEPNICE";
            this.label1KORISNIK1NAZIVZANALJEPNICE.Text = "Naziv ustanove na BARCODE naljepnicama:";
            // 
            // textKORISNIK1NAZIVZANALJEPNICE
            // 
            this.textKORISNIK1NAZIVZANALJEPNICE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textKORISNIK1NAZIVZANALJEPNICE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "KORISNIK1NAZIVZANALJEPNICE", true));
            this.errorProviderValidator1.SetDisplayName(this.textKORISNIK1NAZIVZANALJEPNICE, "");
            this.textKORISNIK1NAZIVZANALJEPNICE.Location = new System.Drawing.Point(772, 51);
            this.textKORISNIK1NAZIVZANALJEPNICE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textKORISNIK1NAZIVZANALJEPNICE.MaxLength = 26;
            this.textKORISNIK1NAZIVZANALJEPNICE.MinimumSize = new System.Drawing.Size(198, 22);
            this.textKORISNIK1NAZIVZANALJEPNICE.Name = "textKORISNIK1NAZIVZANALJEPNICE";
            this.errorProviderValidator1.SetRegularExpression(this.textKORISNIK1NAZIVZANALJEPNICE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textKORISNIK1NAZIVZANALJEPNICE, "");
            this.errorProviderValidator1.SetRequired(this.textKORISNIK1NAZIVZANALJEPNICE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textKORISNIK1NAZIVZANALJEPNICE, "");
            this.textKORISNIK1NAZIVZANALJEPNICE.Size = new System.Drawing.Size(198, 22);
            this.textKORISNIK1NAZIVZANALJEPNICE.TabIndex = 0;
            this.textKORISNIK1NAZIVZANALJEPNICE.Tag = "KORISNIK1NAZIVZANALJEPNICE";
            this.textKORISNIK1NAZIVZANALJEPNICE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1EMAILPOSILJAOCA
            // 
            appearance33.ForeColor = System.Drawing.Color.Black;
            appearance33.TextVAlignAsString = "Middle";
            this.label1EMAILPOSILJAOCA.Appearance = appearance33;
            this.label1EMAILPOSILJAOCA.AutoSize = true;
            this.label1EMAILPOSILJAOCA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1EMAILPOSILJAOCA, "");
            this.label1EMAILPOSILJAOCA.Location = new System.Drawing.Point(538, 76);
            this.label1EMAILPOSILJAOCA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1EMAILPOSILJAOCA.Name = "label1EMAILPOSILJAOCA";
            this.errorProviderValidator1.SetRegularExpression(this.label1EMAILPOSILJAOCA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1EMAILPOSILJAOCA, "");
            this.errorProviderValidator1.SetRequired(this.label1EMAILPOSILJAOCA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1EMAILPOSILJAOCA, "");
            this.label1EMAILPOSILJAOCA.Size = new System.Drawing.Size(221, 14);
            this.label1EMAILPOSILJAOCA.StyleSetName = "FieldUltraLabel";
            this.label1EMAILPOSILJAOCA.TabIndex = 1;
            this.label1EMAILPOSILJAOCA.Tag = "labelEMAILPOSILJAOCA";
            this.label1EMAILPOSILJAOCA.Text = "Mail pošiljaoca (za slanje računa emailom):";
            // 
            // label1NAZIVPOSILJAOCA
            // 
            appearance34.ForeColor = System.Drawing.Color.Black;
            appearance34.TextVAlignAsString = "Middle";
            this.label1NAZIVPOSILJAOCA.Appearance = appearance34;
            this.label1NAZIVPOSILJAOCA.AutoSize = true;
            this.label1NAZIVPOSILJAOCA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1NAZIVPOSILJAOCA, "");
            this.label1NAZIVPOSILJAOCA.Location = new System.Drawing.Point(538, 101);
            this.label1NAZIVPOSILJAOCA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1NAZIVPOSILJAOCA.Name = "label1NAZIVPOSILJAOCA";
            this.errorProviderValidator1.SetRegularExpression(this.label1NAZIVPOSILJAOCA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1NAZIVPOSILJAOCA, "");
            this.errorProviderValidator1.SetRequired(this.label1NAZIVPOSILJAOCA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1NAZIVPOSILJAOCA, "");
            this.label1NAZIVPOSILJAOCA.Size = new System.Drawing.Size(228, 14);
            this.label1NAZIVPOSILJAOCA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVPOSILJAOCA.TabIndex = 1;
            this.label1NAZIVPOSILJAOCA.Tag = "labelNAZIVPOSILJAOCA";
            this.label1NAZIVPOSILJAOCA.Text = "Naziv pošiljaoca (za slanje računa emailom):";
            // 
            // label1SMTPSERVER
            // 
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.label1SMTPSERVER.Appearance = appearance2;
            this.label1SMTPSERVER.AutoSize = true;
            this.label1SMTPSERVER.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1SMTPSERVER, "");
            this.label1SMTPSERVER.Location = new System.Drawing.Point(538, 126);
            this.label1SMTPSERVER.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1SMTPSERVER.Name = "label1SMTPSERVER";
            this.errorProviderValidator1.SetRegularExpression(this.label1SMTPSERVER, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1SMTPSERVER, "");
            this.errorProviderValidator1.SetRequired(this.label1SMTPSERVER, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1SMTPSERVER, "");
            this.label1SMTPSERVER.Size = new System.Drawing.Size(144, 14);
            this.label1SMTPSERVER.StyleSetName = "FieldUltraLabel";
            this.label1SMTPSERVER.TabIndex = 1;
            this.label1SMTPSERVER.Tag = "labelSMTPSERVER";
            this.label1SMTPSERVER.Text = "Server odlazne email pošte:";
            // 
            // textEMAILPOSILJAOCA
            // 
            this.textEMAILPOSILJAOCA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textEMAILPOSILJAOCA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "EMAILPOSILJAOCA", true));
            this.errorProviderValidator1.SetDisplayName(this.textEMAILPOSILJAOCA, "");
            this.textEMAILPOSILJAOCA.Location = new System.Drawing.Point(772, 76);
            this.textEMAILPOSILJAOCA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textEMAILPOSILJAOCA.MaxLength = 150;
            this.textEMAILPOSILJAOCA.MinimumSize = new System.Drawing.Size(300, 22);
            this.textEMAILPOSILJAOCA.Name = "textEMAILPOSILJAOCA";
            this.errorProviderValidator1.SetRegularExpression(this.textEMAILPOSILJAOCA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textEMAILPOSILJAOCA, "");
            this.errorProviderValidator1.SetRequired(this.textEMAILPOSILJAOCA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textEMAILPOSILJAOCA, "");
            this.textEMAILPOSILJAOCA.Size = new System.Drawing.Size(300, 22);
            this.textEMAILPOSILJAOCA.TabIndex = 0;
            this.textEMAILPOSILJAOCA.Tag = "EMAILPOSILJAOCA";
            this.textEMAILPOSILJAOCA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // textNAZIVPOSILJAOCA
            // 
            this.textNAZIVPOSILJAOCA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "NAZIVPOSILJAOCA", true));
            this.errorProviderValidator1.SetDisplayName(this.textNAZIVPOSILJAOCA, "");
            this.textNAZIVPOSILJAOCA.Location = new System.Drawing.Point(772, 101);
            this.textNAZIVPOSILJAOCA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textNAZIVPOSILJAOCA.MaxLength = 150;
            this.textNAZIVPOSILJAOCA.MinimumSize = new System.Drawing.Size(300, 22);
            this.textNAZIVPOSILJAOCA.Name = "textNAZIVPOSILJAOCA";
            this.errorProviderValidator1.SetRegularExpression(this.textNAZIVPOSILJAOCA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textNAZIVPOSILJAOCA, "");
            this.errorProviderValidator1.SetRequired(this.textNAZIVPOSILJAOCA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textNAZIVPOSILJAOCA, "");
            this.textNAZIVPOSILJAOCA.Size = new System.Drawing.Size(300, 22);
            this.textNAZIVPOSILJAOCA.TabIndex = 0;
            this.textNAZIVPOSILJAOCA.Tag = "NAZIVPOSILJAOCA";
            this.textNAZIVPOSILJAOCA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // textSMTPSERVER
            // 
            this.textSMTPSERVER.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "SMTPSERVER", true));
            this.errorProviderValidator1.SetDisplayName(this.textSMTPSERVER, "");
            this.textSMTPSERVER.Location = new System.Drawing.Point(772, 126);
            this.textSMTPSERVER.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textSMTPSERVER.MaxLength = 150;
            this.textSMTPSERVER.MinimumSize = new System.Drawing.Size(300, 22);
            this.textSMTPSERVER.Name = "textSMTPSERVER";
            this.errorProviderValidator1.SetRegularExpression(this.textSMTPSERVER, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textSMTPSERVER, "");
            this.errorProviderValidator1.SetRequired(this.textSMTPSERVER, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textSMTPSERVER, "");
            this.textSMTPSERVER.Size = new System.Drawing.Size(300, 22);
            this.textSMTPSERVER.TabIndex = 0;
            this.textSMTPSERVER.Tag = "SMTPSERVER";
            this.textSMTPSERVER.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1OBVEZNIKPDVA
            // 
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextVAlignAsString = "Middle";
            this.label1OBVEZNIKPDVA.Appearance = appearance5;
            this.label1OBVEZNIKPDVA.AutoSize = true;
            this.label1OBVEZNIKPDVA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OBVEZNIKPDVA, "");
            this.label1OBVEZNIKPDVA.Location = new System.Drawing.Point(538, 151);
            this.label1OBVEZNIKPDVA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OBVEZNIKPDVA.Name = "label1OBVEZNIKPDVA";
            this.errorProviderValidator1.SetRegularExpression(this.label1OBVEZNIKPDVA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OBVEZNIKPDVA, "");
            this.errorProviderValidator1.SetRequired(this.label1OBVEZNIKPDVA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OBVEZNIKPDVA, "");
            this.label1OBVEZNIKPDVA.Size = new System.Drawing.Size(91, 14);
            this.label1OBVEZNIKPDVA.StyleSetName = "FieldUltraLabel";
            this.label1OBVEZNIKPDVA.TabIndex = 58;
            this.label1OBVEZNIKPDVA.Tag = "labelOBVEZNIKPDVA";
            this.label1OBVEZNIKPDVA.Text = "Obveznik PDV-a:";
            // 
            // checkOBVEZNIKPDVA
            // 
            this.checkOBVEZNIKPDVA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorProviderValidator1.SetDisplayName(this.checkOBVEZNIKPDVA, "");
            this.checkOBVEZNIKPDVA.Location = new System.Drawing.Point(772, 155);
            this.checkOBVEZNIKPDVA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.checkOBVEZNIKPDVA.MinimumSize = new System.Drawing.Size(13, 13);
            this.checkOBVEZNIKPDVA.Name = "checkOBVEZNIKPDVA";
            this.errorProviderValidator1.SetRegularExpression(this.checkOBVEZNIKPDVA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.checkOBVEZNIKPDVA, "");
            this.errorProviderValidator1.SetRequired(this.checkOBVEZNIKPDVA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.checkOBVEZNIKPDVA, "");
            this.checkOBVEZNIKPDVA.Size = new System.Drawing.Size(13, 13);
            this.checkOBVEZNIKPDVA.TabIndex = 59;
            this.checkOBVEZNIKPDVA.Tag = "OBVEZNIKPDVA";
            this.checkOBVEZNIKPDVA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);

            // 
            // lblNeprofitni
            // 
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextVAlignAsString = "Middle";
            this.lblNeprofitni.Appearance = appearance5;
            this.lblNeprofitni.AutoSize = true;
            this.lblNeprofitni.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.lblNeprofitni, "");
            this.lblNeprofitni.Location = new System.Drawing.Point(538, 200);
            this.lblNeprofitni.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.lblNeprofitni.Name = "lblNeprofitni";
            this.errorProviderValidator1.SetRegularExpression(this.lblNeprofitni, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.lblNeprofitni, "");
            this.errorProviderValidator1.SetRequired(this.lblNeprofitni, false);
            this.errorProviderValidator1.SetRequiredMessage(this.lblNeprofitni, "");
            this.lblNeprofitni.Size = new System.Drawing.Size(91, 14);
            this.lblNeprofitni.StyleSetName = "FieldUltraLabel";
            this.lblNeprofitni.TabIndex = 60;
            this.lblNeprofitni.Tag = "lblNeprofitni";
            this.lblNeprofitni.Text = "Neprofitni:";
            // 
            // cbkNeprofitni
            // 
            this.cbkNeprofitni.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorProviderValidator1.SetDisplayName(this.cbkNeprofitni, "");
            this.cbkNeprofitni.Location = new System.Drawing.Point(772, 204);
            this.cbkNeprofitni.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.cbkNeprofitni.MinimumSize = new System.Drawing.Size(13, 13);
            this.cbkNeprofitni.Name = "cbkNeprofitni";
            this.errorProviderValidator1.SetRegularExpression(this.cbkNeprofitni, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.cbkNeprofitni, "");
            this.errorProviderValidator1.SetRequired(this.cbkNeprofitni, false);
            this.errorProviderValidator1.SetRequiredMessage(this.cbkNeprofitni, "");
            this.cbkNeprofitni.Size = new System.Drawing.Size(13, 13);
            this.cbkNeprofitni.TabIndex = 61;
            this.cbkNeprofitni.Tag = "cbkNeprofitni";
            this.cbkNeprofitni.MouseEnter += new System.EventHandler(this.mouseEnter_Text);


            // 
            // lblStopaZaInvalide
            // 
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextVAlignAsString = "Middle";
            this.lblStopaZaInvalide.Appearance = appearance5;
            this.lblStopaZaInvalide.AutoSize = true;
            this.lblStopaZaInvalide.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.lblStopaZaInvalide, "");
            this.lblStopaZaInvalide.Location = new System.Drawing.Point(538, 258);
            this.lblStopaZaInvalide.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.lblStopaZaInvalide.Name = "lblStopaZaInvalide";
            this.errorProviderValidator1.SetRegularExpression(this.lblStopaZaInvalide, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.lblStopaZaInvalide, "");
            this.errorProviderValidator1.SetRequired(this.lblStopaZaInvalide, false);
            this.errorProviderValidator1.SetRequiredMessage(this.lblStopaZaInvalide, "");
            this.lblStopaZaInvalide.Size = new System.Drawing.Size(91, 14);
            this.lblStopaZaInvalide.StyleSetName = "FieldUltraLabel";
            this.lblStopaZaInvalide.TabIndex = 62;
            this.lblStopaZaInvalide.Tag = "lblStopaZaInvalide";
            this.lblStopaZaInvalide.Text = "Iznos za invalide:";
            // 
            // txtStopaZaInvalide
            // 
            this.txtStopaZaInvalide.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtStopaZaInvalide.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceKORISNIK, "StopaZaInvalide", true));
            this.errorProviderValidator1.SetDisplayName(this.txtStopaZaInvalide, "");
            this.txtStopaZaInvalide.Location = new System.Drawing.Point(772, 260);
            this.txtStopaZaInvalide.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.txtStopaZaInvalide.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            txtStopaZaInvalide.NumericType = NumericType.Double;
            this.txtStopaZaInvalide.MinimumSize = new System.Drawing.Size(51, 22);
            this.txtStopaZaInvalide.Name = "txtStopaZaInvalide";
            this.txtStopaZaInvalide.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.txtStopaZaInvalide, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.txtStopaZaInvalide, "");
            this.errorProviderValidator1.SetRequired(this.txtStopaZaInvalide, false);
            this.errorProviderValidator1.SetRequiredMessage(this.txtStopaZaInvalide, "");
            this.txtStopaZaInvalide.Size = new System.Drawing.Size(100, 22);
            this.txtStopaZaInvalide.TabIndex = 63;
            this.txtStopaZaInvalide.Tag = "txtStopaZaInvalide";
            this.txtStopaZaInvalide.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.txtStopaZaInvalide.MouseEnter += new System.EventHandler(this.mouseEnter_Text);


            #region MBS.Complete

            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextVAlignAsString = "Middle";
            this.lblPredporez.Appearance = appearance5;
            this.lblPredporez.AutoSize = true;
            this.lblPredporez.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.lblPredporez, "");
            this.lblPredporez.Location = new System.Drawing.Point(538, 532);
            this.lblPredporez.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.lblPredporez.Name = "lblPredporez";
            this.errorProviderValidator1.SetRegularExpression(this.lblPredporez, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.lblPredporez, "");
            this.errorProviderValidator1.SetRequired(this.lblPredporez, false);
            this.errorProviderValidator1.SetRequiredMessage(this.lblPredporez, "");
            this.lblPredporez.Size = new System.Drawing.Size(91, 14);
            this.lblPredporez.StyleSetName = "FieldUltraLabel";
            this.lblPredporez.TabIndex = 62;
            this.lblPredporez.Tag = "lblPredporez";
            this.lblPredporez.Text = "Postotak predporeza:";

            this.txtPredporez.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPredporez.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceKORISNIK, "PredPorez", true));
            this.errorProviderValidator1.SetDisplayName(this.txtPredporez, "");
            this.txtPredporez.Location = new System.Drawing.Point(772, 532);
            this.txtPredporez.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.txtPredporez.MaskInput = "{LOC}-nn.nn";
            txtPredporez.NumericType = NumericType.Double;
            txtPredporez.MaxValue = 100;
            this.txtPredporez.MinimumSize = new System.Drawing.Size(51, 22);
            this.txtPredporez.Name = "txtPredporez";
            this.txtPredporez.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.txtPredporez, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.txtPredporez, "");
            this.errorProviderValidator1.SetRequired(this.txtPredporez, false);
            this.errorProviderValidator1.SetRequiredMessage(this.txtPredporez, "");
            this.txtPredporez.Size = new System.Drawing.Size(100, 22);
            this.txtPredporez.TabIndex = 63;
            this.txtPredporez.Tag = "txtPredporez";
            this.txtPredporez.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.txtPredporez.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            #endregion

            // 
            // lblBrojOsoba
            // 
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextVAlignAsString = "Middle";
            this.lblBrojOsoba.Appearance = appearance5;
            this.lblBrojOsoba.AutoSize = true;
            this.lblBrojOsoba.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.lblBrojOsoba, "");
            this.lblBrojOsoba.Location = new System.Drawing.Point(538, 316);
            this.lblBrojOsoba.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.lblBrojOsoba.Name = "lblBrojOsoba";
            this.errorProviderValidator1.SetRegularExpression(this.lblBrojOsoba, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.lblBrojOsoba, "");
            this.errorProviderValidator1.SetRequired(this.lblBrojOsoba, false);
            this.errorProviderValidator1.SetRequiredMessage(this.lblBrojOsoba, "");
            this.lblBrojOsoba.Size = new System.Drawing.Size(91, 14);
            this.lblBrojOsoba.StyleSetName = "FieldUltraLabel";
            this.lblBrojOsoba.TabIndex = 64;
            this.lblBrojOsoba.Tag = "lblBrojOsoba";
            this.lblBrojOsoba.Text = "Broj osoba:";
            // 
            // txtBrojOsoba
            // 
            this.txtBrojOsoba.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBrojOsoba.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceKORISNIK, "BrojOsoba", true));
            this.errorProviderValidator1.SetDisplayName(this.txtBrojOsoba, "");
            this.txtBrojOsoba.Location = new System.Drawing.Point(772, 318);
            this.txtBrojOsoba.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.txtBrojOsoba.MaskInput = "{LOC}-nnnnnnnnnn";
            txtBrojOsoba.NumericType = NumericType.Integer;
            this.txtBrojOsoba.MinimumSize = new System.Drawing.Size(51, 22);
            this.txtBrojOsoba.Name = "txtBrojOsoba";
            this.txtBrojOsoba.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.txtBrojOsoba, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.txtBrojOsoba, "");
            this.errorProviderValidator1.SetRequired(this.txtBrojOsoba, false);
            this.errorProviderValidator1.SetRequiredMessage(this.txtBrojOsoba, "");
            this.txtBrojOsoba.Size = new System.Drawing.Size(100, 22);
            this.txtBrojOsoba.TabIndex = 65;
            this.txtBrojOsoba.Tag = "txtBrojOsoba";
            this.txtBrojOsoba.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.txtBrojOsoba.MouseEnter += new System.EventHandler(this.mouseEnter_Text);

            // 
            // lblPDVPoNaplacenom
            // 
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextVAlignAsString = "Middle";
            this.lblPDVPoNaplacenom.Appearance = appearance5;
            this.lblPDVPoNaplacenom.AutoSize = true;
            this.lblPDVPoNaplacenom.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.lblPDVPoNaplacenom, "");
            this.lblPDVPoNaplacenom.Location = new System.Drawing.Point(538, 370);
            this.lblPDVPoNaplacenom.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.lblPDVPoNaplacenom.Name = "lblPDVPoNaplacenom";
            this.errorProviderValidator1.SetRegularExpression(this.lblPDVPoNaplacenom, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.lblPDVPoNaplacenom, "");
            this.errorProviderValidator1.SetRequired(this.lblPDVPoNaplacenom, false);
            this.errorProviderValidator1.SetRequiredMessage(this.lblPDVPoNaplacenom, "");
            this.lblPDVPoNaplacenom.Size = new System.Drawing.Size(91, 14);
            this.lblPDVPoNaplacenom.StyleSetName = "FieldUltraLabel";
            this.lblPDVPoNaplacenom.TabIndex = 66;
            this.lblPDVPoNaplacenom.Tag = "lblPDVPoNaplacenom";
            this.lblPDVPoNaplacenom.Text = "PDV po naplaćenom računu:";
            // 
            // cbkPDVPoNaplacenom
            // 
            this.cbkPDVPoNaplacenom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorProviderValidator1.SetDisplayName(this.cbkPDVPoNaplacenom, "");
            this.cbkPDVPoNaplacenom.Location = new System.Drawing.Point(772, 372);
            this.cbkPDVPoNaplacenom.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.cbkPDVPoNaplacenom.MinimumSize = new System.Drawing.Size(13, 13);
            this.cbkPDVPoNaplacenom.Name = "cbkPDVPoNaplacenom";
            this.errorProviderValidator1.SetRegularExpression(this.cbkPDVPoNaplacenom, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.cbkPDVPoNaplacenom, "");
            this.errorProviderValidator1.SetRequired(this.cbkPDVPoNaplacenom, false);
            this.errorProviderValidator1.SetRequiredMessage(this.cbkPDVPoNaplacenom, "");
            this.cbkPDVPoNaplacenom.Size = new System.Drawing.Size(13, 13);
            this.cbkPDVPoNaplacenom.TabIndex = 67;
            this.cbkPDVPoNaplacenom.Tag = "cbkPDVPoNaplacenom";
            this.cbkPDVPoNaplacenom.MouseEnter += new System.EventHandler(this.mouseEnter_Text);


            // 
            // lblPassword
            // 
            appearance33.ForeColor = System.Drawing.Color.Black;
            appearance33.TextVAlignAsString = "Middle";
            this.lblPassword.Appearance = appearance33;
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.lblPassword, "");
            this.lblPassword.Location = new System.Drawing.Point(538, 424);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.lblPassword.Name = "lblPassword";
            this.errorProviderValidator1.SetRegularExpression(this.lblPassword, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.lblPassword, "");
            this.errorProviderValidator1.SetRequired(this.lblPassword, false);
            this.errorProviderValidator1.SetRequiredMessage(this.lblPassword, "");
            this.lblPassword.Size = new System.Drawing.Size(240, 14);
            this.lblPassword.StyleSetName = "FieldUltraLabel";
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Tag = "lblPassword";
            this.lblPassword.Text = "Šifra (za slanje računa emailom):";
            // 
            // lblPort
            // 
            appearance33.ForeColor = System.Drawing.Color.Black;
            appearance33.TextVAlignAsString = "Middle";
            this.lblPort.Appearance = appearance33;
            this.lblPort.AutoSize = true;
            this.lblPort.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.lblPort, "");
            this.lblPort.Location = new System.Drawing.Point(538, 478);
            this.lblPort.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.lblPort.Name = "lblPort";
            this.errorProviderValidator1.SetRegularExpression(this.lblPort, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.lblPort, "");
            this.errorProviderValidator1.SetRequired(this.lblPort, false);
            this.errorProviderValidator1.SetRequiredMessage(this.lblPort, "");
            this.lblPort.Size = new System.Drawing.Size(240, 14);
            this.lblPort.StyleSetName = "FieldUltraLabel";
            this.lblPort.TabIndex = 1;
            this.lblPort.Tag = "lblPort";
            this.lblPort.Text = "Port (za slanje računa emailom):";
            // 
            // txtPassword
            // 
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "EmailPassword", true));
            this.errorProviderValidator1.SetDisplayName(this.txtPassword, "");
            this.txtPassword.Location = new System.Drawing.Point(772, 424);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.txtPassword.MaxLength = 150;
            this.txtPassword.MinimumSize = new System.Drawing.Size(300, 22);
            this.txtPassword.Name = "txtPassword";
            this.errorProviderValidator1.SetRegularExpression(this.txtPassword, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.txtPassword, "");
            this.errorProviderValidator1.SetRequired(this.txtPassword, false);
            this.errorProviderValidator1.SetRequiredMessage(this.txtPassword, "");
            this.txtPassword.Size = new System.Drawing.Size(300, 22);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.Tag = "EmailPassword";
            this.txtPassword.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // txtPort
            // 
            this.txtPort.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceKORISNIK, "EmailPort", true));
            this.errorProviderValidator1.SetDisplayName(this.txtPort, "");
            this.txtPort.Location = new System.Drawing.Point(772, 478);
            this.txtPort.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.txtPort.MaxLength = 150;
            this.txtPort.MinimumSize = new System.Drawing.Size(300, 22);
            this.txtPort.Name = "txtPort";
            this.errorProviderValidator1.SetRegularExpression(this.txtPort, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.txtPort, "");
            this.errorProviderValidator1.SetRequired(this.txtPort, false);
            this.errorProviderValidator1.SetRequiredMessage(this.txtPort, "");
            this.txtPort.Size = new System.Drawing.Size(300, 22);
            this.txtPort.TabIndex = 0;
            this.txtPort.Tag = "EmailPort";
            this.txtPort.MouseEnter += new System.EventHandler(this.mouseEnter_Text);


            // 
            // KORISNIKFormUserControl
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.layoutManagerformKORISNIK);
            this.errorProviderValidator1.SetDisplayName(this, "");
            this.Name = "KORISNIKFormUserControl";
            this.errorProviderValidator1.SetRegularExpression(this, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this, "");
            this.errorProviderValidator1.SetRequired(this, false);
            this.errorProviderValidator1.SetRequiredMessage(this, "");
            this.Size = new System.Drawing.Size(1085, 658);
            this.Load += new System.EventHandler(this.KORISNIKFormUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceKORISNIK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKORISNIKDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEMAIL)).EndInit();
            this.layoutManagerformKORISNIK.ResumeLayout(false);
            this.layoutManagerformKORISNIK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textIDKORISNIK)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.txtStopaZaInvalide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBrojOsoba)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.cbkPDVPoNaplacenom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).EndInit();

            #region MBS.Complete
            ((System.ComponentModel.ISupportInitialize)(this.txtPredporez)).EndInit();
            #endregion

            ((System.ComponentModel.ISupportInitialize)(this.textKORISNIK1NAZIV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKORISNIK1ADRESA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKORISNIK1MJESTO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKORISNIKOIB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMBKORISNIK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMBKORISNIKJEDINICA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textJMBGKORISNIK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKONTAKTOSOBA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKONTAKTTELEFON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKONTAKTFAX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNADLEZNAPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBROJCANAOZNAKAPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textRKP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPREZIMEIMEOVLASTENEOSOBE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textADRESAOVLASTENEOSOBE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOIBOVLASTENEOSOBE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLevelKORISNIKLevel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceKORISNIKLevel1)).EndInit();
            this.panelactionsKORISNIKLevel1.ResumeLayout(false);
            this.panelactionsKORISNIKLevel1.PerformLayout();
            this.layoutManagerpanelactionsKORISNIKLevel1.ResumeLayout(false);
            this.layoutManagerpanelactionsKORISNIKLevel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textANALITIKA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKORISNIK1HZZO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKORISNIK1NAZIVZANALJEPNICE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEMAILPOSILJAOCA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNAZIVPOSILJAOCA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSMTPSERVER)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool InValidState()
        {
            if ((this.KORISNIKController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceKORISNIK, this.KORISNIKController.WorkItem, this))
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

        private void KORISNIKFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.KORISNIKDescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textEMAIL, string.Format(Deklarit.Resources.Resources.validateRegular, "E-mail"));
            this.linkLabelKORISNIKLevel1Add.Text = Deklarit.Resources.Resources.Add + " " + StringResources.KORISNIKKORISNIKLevel1LevelDescription;
            this.linkLabelKORISNIKLevel1Update.Text = Deklarit.Resources.Resources.Update + " " + StringResources.KORISNIKKORISNIKLevel1LevelDescription;
            this.linkLabelKORISNIKLevel1Delete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.KORISNIKKORISNIKLevel1LevelDescription;
        }

        private void KORISNIKLevel1Add_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelKORISNIKLevel1.ActiveRow;
            this.KORISNIKLevel1Insert();
        }

        private void KORISNIKLevel1Delete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelKORISNIKLevel1);
            if ((currentRowListIndex != -1) && (this.grdLevelKORISNIKLevel1.Selected.Rows.Count > 0))
            {
                this.grdLevelKORISNIKLevel1.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelKORISNIKLevel1).Selected = true;
                this.grdLevelKORISNIKLevel1.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void KORISNIKLevel1Insert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceKORISNIK, this.KORISNIKController.WorkItem, this))
            {
                this.KORISNIKController.AddKORISNIKLevel1(this.m_CurrentRow);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/IZVORDOKUMENTA", Thread=ThreadOption.UserInterface)]
        public void KORISNIKLevel1SIFRAIZVORA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new IZVORDOKUMENTADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetIZVORDOKUMENTADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["IZVORDOKUMENTA"]) {
                Sort = "SIFRAIZVORA"
            };
            CreateValueList(this.grdLevelKORISNIKLevel1, "IZVORDOKUMENTASIFRAIZVORA", enumList, "SIFRAIZVORA", "SIFRAIZVORA", true);
        }

        private void KORISNIKLevel1Update()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelKORISNIKLevel1) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelKORISNIKLevel1);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.KORISNIKController.UpdateKORISNIKLevel1(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void KORISNIKLevel1Update_Click(object sender, EventArgs e)
        {
            if (this.grdLevelKORISNIKLevel1.ActiveRow != null)
            {
                this.KORISNIKLevel1Update();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private static void LoadValueList(ValueList myValueList, DataView enumList, string Id, string Name)
        {
            IEnumerator enumerator = null;
            try
            {
                enumerator = enumList.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRowView current = (DataRowView) enumerator.Current;
                    DataRow row = current.Row;
                    ValueListItem item = new ValueListItem {
                        DataValue = RuntimeHelpers.GetObjectValue(row[Id]),
                        DisplayText = row[Name].ToString()
                    };
                    myValueList.ValueListItems.Add(item);
                }
            }
            finally
            {
                if (enumerator is IDisposable)
                {
                    (enumerator as IDisposable).Dispose();
                }
            }
            myValueList.Tag = enumList;
        }

        private void Localize()
        {
            this.label1IDKORISNIK.Text = StringResources.KORISNIKIDKORISNIKDescription;
            this.label1KORISNIK1NAZIV.Text = StringResources.KORISNIKKORISNIK1NAZIVDescription;
            this.label1KORISNIK1ADRESA.Text = StringResources.KORISNIKKORISNIK1ADRESADescription;
            this.label1KORISNIK1MJESTO.Text = StringResources.KORISNIKKORISNIK1MJESTODescription;
            this.label1KORISNIKOIB.Text = StringResources.KORISNIKKORISNIKOIBDescription;
            this.label1MBKORISNIK.Text = StringResources.KORISNIKMBKORISNIKDescription;
            this.label1MBKORISNIKJEDINICA.Text = StringResources.KORISNIKMBKORISNIKJEDINICADescription;
            this.label1JMBGKORISNIK.Text = StringResources.KORISNIKJMBGKORISNIKDescription;
            this.label1KONTAKTOSOBA.Text = StringResources.KORISNIKKONTAKTOSOBADescription;
            this.label1KONTAKTTELEFON.Text = StringResources.KORISNIKKONTAKTTELEFONDescription;
            this.label1KONTAKTFAX.Text = StringResources.KORISNIKKONTAKTFAXDescription;
            this.label1EMAIL.Text = StringResources.KORISNIKEMAILDescription;
            this.label1NADLEZNAPU.Text = StringResources.KORISNIKNADLEZNAPUDescription;
            this.label1BROJCANAOZNAKAPU.Text = StringResources.KORISNIKBROJCANAOZNAKAPUDescription;
            this.label1STAZUKOEFICIJENTU.Text = StringResources.KORISNIKSTAZUKOEFICIJENTUDescription;
            this.label1RKP.Text = StringResources.KORISNIKRKPDescription;
            this.label1PREZIMEIMEOVLASTENEOSOBE.Text = StringResources.KORISNIKPREZIMEIMEOVLASTENEOSOBEDescription;
            this.label1ADRESAOVLASTENEOSOBE.Text = StringResources.KORISNIKADRESAOVLASTENEOSOBEDescription;
            this.label1OIBOVLASTENEOSOBE.Text = StringResources.KORISNIKOIBOVLASTENEOSOBEDescription;
            this.label1ANALITIKA.Text = StringResources.KORISNIKANALITIKADescription;
            this.label1KORISNIK1HZZO.Text = StringResources.KORISNIKKORISNIK1HZZODescription;
            this.label1KORISNIK1NAZIVZANALJEPNICE.Text = StringResources.KORISNIKKORISNIK1NAZIVZANALJEPNICEDescription;
            this.label1EMAILPOSILJAOCA.Text = StringResources.KORISNIKEMAILPOSILJAOCADescription;
            this.label1NAZIVPOSILJAOCA.Text = StringResources.KORISNIKNAZIVPOSILJAOCADescription;
            this.label1SMTPSERVER.Text = StringResources.KORISNIKSMTPSERVERDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedInLinesSIFRAIZVORA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("IZVORDOKUMENTA", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.KORISNIKController.WorkItem.Items.Contains("KORISNIK|KORISNIK"))
            {
                this.KORISNIKController.WorkItem.Items.Add(this.bindingSourceKORISNIK, "KORISNIK|KORISNIK");
            }
            if (!this.KORISNIKController.WorkItem.Items.Contains("KORISNIK|KORISNIKLevel1"))
            {
                this.KORISNIKController.WorkItem.Items.Add(this.bindingSourceKORISNIKLevel1, "KORISNIK|KORISNIKLevel1");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsKORISNIKDataSet1.KORISNIK.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.Mode;
                this.m_BaseMethods.FormLoadStyle();
            }
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.KORISNIKController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.KORISNIKController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.KORISNIKController.Update(this))
            {
                this.KORISNIKController.DataSet = new KORISNIKDataSet();
                DataSetUtil.AddEmptyRow(this.KORISNIKController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.KORISNIKController.DataSet.KORISNIK[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetComboBoxColumnProperties()
        {
            DataSet dataSet = new IZVORDOKUMENTADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetIZVORDOKUMENTADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["IZVORDOKUMENTA"]) {
                Sort = "SIFRAIZVORA"
            };
            CreateValueList(this.grdLevelKORISNIKLevel1, "IZVORDOKUMENTASIFRAIZVORA", enumList, "SIFRAIZVORA", "SIFRAIZVORA", false);
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelKORISNIKLevel1, "SIFRAIZVORA");
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            gridColumn.ValueList = this.grdLevelKORISNIKLevel1.DisplayLayout.ValueLists["IZVORDOKUMENTASIFRAIZVORA"];
            gridColumn.Width = 0x5b;
            this.grdLevelKORISNIKLevel1.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelKORISNIKLevel1.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.textIDKORISNIK.Focus();
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

        private void UpdateValuesSIFRAIZVORA(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["SIFRAIZVORA"] = RuntimeHelpers.GetObjectValue(result["SIFRAIZVORA"]);
                    row["NAZIVIZVORA"] = RuntimeHelpers.GetObjectValue(result["NAZIVIZVORA"]);
                }
                catch (ConstraintException exception)
                {
                    throw exception;
                }
            }
        }

        private UltraCheckEditor checkSTAZUKOEFICIJENTU;

        private ContextMenu contextMenu1;

        private ErrorProvider errorProvider1;

        private ErrorProviderValidator errorProviderValidator1;

        private UltraGrid grdLevelKORISNIKLevel1;

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.KORISNIKController KORISNIKController { get; set; }

        private UltraLabel label1ADRESAOVLASTENEOSOBE;

        private UltraLabel label1ANALITIKA;

        private UltraLabel label1BROJCANAOZNAKAPU;

        private UltraLabel label1EMAIL;

        private UltraLabel label1EMAILPOSILJAOCA;

        private UltraLabel lblPassword;

        private UltraLabel lblPort;

        #region MBS.Complete
        private UltraLabel lblPredporez;
        private UltraNumericEditor txtPredporez;
        #endregion


        private UltraLabel label1IDKORISNIK;

        private UltraLabel label1JMBGKORISNIK;

        private UltraLabel label1KONTAKTFAX;

        private UltraLabel label1KONTAKTOSOBA;

        private UltraLabel label1KONTAKTTELEFON;

        private UltraLabel label1KORISNIK1ADRESA;

        private UltraLabel label1KORISNIK1HZZO;

        private UltraLabel label1KORISNIK1MJESTO;

        private UltraLabel label1KORISNIK1NAZIV;

        private UltraLabel label1KORISNIK1NAZIVZANALJEPNICE;

        private UltraLabel label1KORISNIKOIB;

        private UltraLabel label1MBKORISNIK;

        private UltraLabel label1MBKORISNIKJEDINICA;

        private UltraLabel label1NADLEZNAPU;

        private UltraLabel label1NAZIVPOSILJAOCA;

        private UltraLabel label1OIBOVLASTENEOSOBE;

        private UltraLabel label1PREZIMEIMEOVLASTENEOSOBE;

        private UltraLabel label1RKP;

        private UltraLabel label1SMTPSERVER;

        private UltraLabel label1STAZUKOEFICIJENTU;

        private UltraLabel linkLabelKORISNIKLevel1Add;

        private UltraLabel linkLabelKORISNIKLevel1Delete;

        private UltraLabel linkLabelKORISNIKLevel1Update;

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

        private Panel panelactionsKORISNIKLevel1;

        private MenuItem SetNullItem;

        private UltraTextEditor textADRESAOVLASTENEOSOBE;

        private UltraNumericEditor textANALITIKA;

        private UltraNumericEditor textBROJCANAOZNAKAPU;

        private UltraTextEditor textEMAIL;

        private UltraTextEditor textEMAILPOSILJAOCA;

        private UltraNumericEditor textIDKORISNIK;

        private UltraNumericEditor txtStopaZaInvalide;
        private UltraNumericEditor txtBrojOsoba;

        private UltraTextEditor textJMBGKORISNIK;

        private UltraTextEditor textKONTAKTFAX;

        private UltraTextEditor textKONTAKTOSOBA;

        private UltraTextEditor textKONTAKTTELEFON;

        private UltraTextEditor textKORISNIK1ADRESA;

        private UltraTextEditor textKORISNIK1HZZO;

        private UltraTextEditor textKORISNIK1MJESTO;

        private UltraTextEditor textKORISNIK1NAZIV;

        private UltraTextEditor textKORISNIK1NAZIVZANALJEPNICE;

        private UltraTextEditor textKORISNIKOIB;

        private UltraTextEditor textMBKORISNIK;

        private UltraTextEditor textMBKORISNIKJEDINICA;

        private UltraTextEditor textNADLEZNAPU;

        private UltraTextEditor textNAZIVPOSILJAOCA;

        private UltraTextEditor textOIBOVLASTENEOSOBE;

        private UltraTextEditor textPREZIMEIMEOVLASTENEOSOBE;

        private UltraNumericEditor textRKP;

        private UltraTextEditor textSMTPSERVER;

        private UltraTextEditor txtPassword;

        private UltraTextEditor txtPort;

        private System.Windows.Forms.ToolTip toolTip1;
    }
}

