namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Deklarit.WinHelper;
    using Hlp;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinTabControl;
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
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;

    [SmartPart]
    public class URAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        private BindingSource bindingSourceURA;
        private IContainer components;
        private URADataSet dsURADataSet1;
        protected TableLayoutPanel layoutManagerformURA;
        protected TableLayoutPanel layoutManagerTabPage1;
        protected TableLayoutPanel layoutManagerTabPage2;

        private bool m_AutoNumber;
        private GenericFormClass m_BaseMethods;
        private URADataSet.URARow m_CurrentRow;
        private ArrayList m_DataGrids;
        private string m_FirstLevelName;
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription;
        private UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private UltraLabel ultraLabel1;
        private UltraLabel label1PDV25NE;
        private UltraLabel label1PDV25DA;
        private UltraLabel label1OSNOVICA25NE;
        private UltraLabel label1OSNOVICA25;
        private UltraNumericEditor textPDV25NE;
        private UltraNumericEditor textPDV25DA;
        private UltraNumericEditor textOSNOVICA25NE;
        private UltraNumericEditor textOSNOVICA25;
        private UltraLabel ultraLabel2;
        private UltraLabel ultraLabel3;
        private UltraLabel ultraLabel4;
        private UltraLabel ultraLabel5;
        private UltraLabel ultraLabel9;
        private UltraLabel label1OSNOVICA5;
        private UltraLabel label1OSNOVICA5NE;
        private UltraNumericEditor textOSNOVICA5;
        private UltraNumericEditor textOSNOVICA5NE;
        private UltraLabel label1PDV5DA;
        private UltraLabel label1PDV5NE;
        private UltraNumericEditor textPDV5DA;
        private UltraNumericEditor textPDV5NE;
        private Button pdv5;
        private UltraLabel ultraLabel6;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public URAFormUserControl()
        {
            base.Load += new EventHandler(this.URAFormUserControl_Load1);
            base.GotFocus += new EventHandler(this.URAFormUserControl_GotFocus);
            this.components = null;
            this.m_FrameworkDescription = StringResources.URADescription;
            this.m_DataGrids = new ArrayList();
            this.m_FirstLevelName = "URA";
            this.m_AutoNumber = false;
            this.InitializeComponent();
            this.SetSize();
        }

        private void CallPromptGODINEURAGODIDGODINE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.URAController.SelectGODINEURAGODIDGODINE(fillMethod, fillByRow);
            this.UpdateValuesGODINEURAGODIDGODINE(result);
        }

        private void CallPromptTIPURAIDTIPURA(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.URAController.SelectTIPURAIDTIPURA(fillMethod, fillByRow);
            this.UpdateValuesTIPURAIDTIPURA(result);
        }

        private void CallViewGODINEURAGODIDGODINE(object sender, EventArgs e)
        {
            DataRow result = this.URAController.ShowGODINEURAGODIDGODINE(this.m_CurrentRow);
            this.UpdateValuesGODINEURAGODIDGODINE(result);
        }

        private void CallViewTIPURAIDTIPURA(object sender, EventArgs e)
        {
            DataRow result = this.URAController.ShowTIPURAIDTIPURA(this.m_CurrentRow);
            this.UpdateValuesTIPURAIDTIPURA(result);
        }

        public void ChangeBinding()
        {
            this.bindingSourceURA.DataSource = this.URAController.DataSet;
            this.dsURADataSet1 = this.URAController.DataSet;
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
        public void comboURADOKIDDOKUMENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboURADOKIDDOKUMENT.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/PARTNER", Thread=ThreadOption.UserInterface)]
        public void combourapartnerIDPARTNER_Add(object sender, ComponentEventArgs e)
        {
            this.combourapartnerIDPARTNER.Fill();
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
                    enumerator = this.dsURADataSet1.URA.Rows.GetEnumerator();
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
                if (this.URAController.Update(this))
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

        [OnBuiltUp]
        public void Dodatno()
        {
            InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "URA", this.Mode, this.dsURADataSet1, this.dsURADataSet1.URA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding2 = new Binding("Text", this.bindingSourceURA, "URADATUM", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding2.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerURADATUM.DataBindings["Text"] != null)
            {
                this.datePickerURADATUM.DataBindings.Remove(this.datePickerURADATUM.DataBindings["Text"]);
            }
            this.datePickerURADATUM.DataBindings.Add(binding2);
            Binding binding3 = new Binding("Text", this.bindingSourceURA, "URAVALUTA", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding3.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerURAVALUTA.DataBindings["Text"] != null)
            {
                this.datePickerURAVALUTA.DataBindings.Remove(this.datePickerURAVALUTA.DataBindings["Text"]);
            }
            this.datePickerURAVALUTA.DataBindings.Add(binding3);
            Binding binding = new Binding("CheckState", this.bindingSourceURA, "R2", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.BooleanFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.BooleanParse);
            if (this.checkR2.DataBindings["CheckState"] != null)
            {
                this.checkR2.DataBindings.Remove(this.checkR2.DataBindings["CheckState"]);
            }
            this.checkR2.DataBindings.Add(binding);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsURADataSet1.URA[0];
                this.textURAGODIDGODINE.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textURAGODIDGODINE.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (URADataSet.URARow) ((DataRowView) this.bindingSourceURA.AddNew()).Row;
                foreach (string str in DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, foreignKeys))
                {
                    /*
                    // MATIJA - neki fix, jer mi je inaće sakrivao labele i kontrole za PDV na 25%
                    if (!str.ToLower().Contains("PDV25".ToLower()))
                    {
                        this.m_BaseMethods.SetReadOnly(str, true);
                        this.m_BaseMethods.GetLabelControl(str).Visible = false;
                        this.m_BaseMethods.GetControl(str).Visible = false;
                    }
                    */
                }
            }
            this.SetFocusInFirstField();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton2 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab tab = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab tab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab tab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.TabPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.layoutManagerTabPage1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1URAGODIDGODINE = new Infragistics.Win.Misc.UltraLabel();
            this.textURAGODIDGODINE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.bindingSourceURA = new System.Windows.Forms.BindingSource(this.components);
            this.dsURADataSet1 = new Placa.URADataSet();
            this.label1URADOKIDDOKUMENT = new Infragistics.Win.Misc.UltraLabel();
            this.comboURADOKIDDOKUMENT = new NetAdvantage.Controls.DOKUMENTComboBox();
            this.label1URABROJ = new Infragistics.Win.Misc.UltraLabel();
            this.textURABROJ = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1urapartnerIDPARTNER = new Infragistics.Win.Misc.UltraLabel();
            this.combourapartnerIDPARTNER = new NetAdvantage.Controls.PARTNERComboBox();
            this.label1URABROJRACUNADOBAVLJACA = new Infragistics.Win.Misc.UltraLabel();
            this.textURABROJRACUNADOBAVLJACA = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1URADATUM = new Infragistics.Win.Misc.UltraLabel();
            this.datePickerURADATUM = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label1URAVALUTA = new Infragistics.Win.Misc.UltraLabel();
            this.datePickerURAVALUTA = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label1URANAPOMENA = new Infragistics.Win.Misc.UltraLabel();
            this.textURANAPOMENA = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1URAMODEL = new Infragistics.Win.Misc.UltraLabel();
            this.textURAMODEL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.SetNullItem = new System.Windows.Forms.MenuItem();
            this.label1URAPOZIVNABROJ = new Infragistics.Win.Misc.UltraLabel();
            this.textURAPOZIVNABROJ = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1URAUKUPNO = new Infragistics.Win.Misc.UltraLabel();
            this.textURAUKUPNO = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.TabPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();

            #region MBS.Complete 26.04.2016
            this.TabPage3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.layoutManagerTabPage3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMoze = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblMoze = new Infragistics.Win.Misc.UltraLabel();
            this.txtNeMoze = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblNeMoze = new Infragistics.Win.Misc.UltraLabel();
            this.txtOsnovica = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.lblOsnovica = new Infragistics.Win.Misc.UltraLabel();
            #endregion

            this.layoutManagerTabPage2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1R2 = new Infragistics.Win.Misc.UltraLabel();
            this.checkR2 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.textIDTIPURA = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1IDTIPURA = new Infragistics.Win.Misc.UltraLabel();
            this.label1OSNOVICA0 = new Infragistics.Win.Misc.UltraLabel();
            this.pdv22 = new System.Windows.Forms.Button();
            this.textOSNOVICA0 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.textOSNOVICA22NE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1OSNOVICA22NE = new Infragistics.Win.Misc.UltraLabel();
            this.textOSNOVICA22 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1OSNOVICA22 = new Infragistics.Win.Misc.UltraLabel();
            this.label1PDV22NE = new Infragistics.Win.Misc.UltraLabel();
            this.textPDV22NE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.label1PDV22DA = new Infragistics.Win.Misc.UltraLabel();
            this.textPDV22DA = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.label1OSNOVICA25 = new Infragistics.Win.Misc.UltraLabel();
            this.label1OSNOVICA25NE = new Infragistics.Win.Misc.UltraLabel();
            this.label1PDV25DA = new Infragistics.Win.Misc.UltraLabel();
            this.textOSNOVICA25 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.textOSNOVICA25NE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.textPDV25DA = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.textPDV25NE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1PDV25NE = new Infragistics.Win.Misc.UltraLabel();
            this.pdv25 = new System.Windows.Forms.Button();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.label1OSNOVICA23 = new Infragistics.Win.Misc.UltraLabel();
            this.label1OSNOVICA23NE = new Infragistics.Win.Misc.UltraLabel();
            this.label1PDV23DA = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.label1PDV23NE = new Infragistics.Win.Misc.UltraLabel();
            this.textOSNOVICA23 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.textOSNOVICA23NE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.textPDV23DA = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.textPDV23NE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            //this.pdv23 = new System.Windows.Forms.Button();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.label1OSNOVICA10 = new Infragistics.Win.Misc.UltraLabel();
            this.textOSNOVICA10 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1OSNOVICA10NE = new Infragistics.Win.Misc.UltraLabel();
            this.textOSNOVICA10NE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1PDV10DA = new Infragistics.Win.Misc.UltraLabel();
            this.textPDV10DA = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1PDV10NE = new Infragistics.Win.Misc.UltraLabel();
            this.textPDV10NE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.pdv10 = new System.Windows.Forms.Button();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.label1OSNOVICA5 = new Infragistics.Win.Misc.UltraLabel();
            this.label1OSNOVICA5NE = new Infragistics.Win.Misc.UltraLabel();
            this.textOSNOVICA5 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.textOSNOVICA5NE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1PDV5DA = new Infragistics.Win.Misc.UltraLabel();
            this.label1PDV5NE = new Infragistics.Win.Misc.UltraLabel();
            this.pdv5 = new System.Windows.Forms.Button();
            this.textPDV5DA = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.textPDV5NE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderValidator1 = new Deklarit.Win.ErrorProviderValidator(this.components);
            this.layoutManagerformURA = new System.Windows.Forms.TableLayoutPanel();
            this.Tab1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.UserDefinedControl1 = new NetAdvantage.SmartParts.StavkeUre();
            this.TabPage1.SuspendLayout();
            this.layoutManagerTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textURAGODIDGODINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceURA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsURADataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textURABROJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textURABROJRACUNADOBAVLJACA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePickerURADATUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePickerURAVALUTA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textURANAPOMENA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textURAMODEL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textURAPOZIVNABROJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textURAUKUPNO)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.layoutManagerTabPage2.SuspendLayout();

            #region MBS.Complete 26.04.2016
            this.TabPage3.SuspendLayout();
            this.layoutManagerTabPage3.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.txtOsnovica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNeMoze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoze)).BeginInit();
            #endregion

            ((System.ComponentModel.ISupportInitialize)(this.textIDTIPURA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA22NE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV22NE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV22DA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA25NE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV25DA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV25NE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA23NE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV23DA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV23NE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA10NE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV10DA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV10NE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA5NE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV5DA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV5NE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.layoutManagerformURA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tab1)).BeginInit();
            this.Tab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.layoutManagerTabPage1);
            this.errorProviderValidator1.SetDisplayName(this.TabPage1, "");
            this.TabPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.TabPage1.Name = "TabPage1";
            this.errorProviderValidator1.SetRegularExpression(this.TabPage1, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.TabPage1, "");
            this.errorProviderValidator1.SetRequired(this.TabPage1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.TabPage1, "");
            this.TabPage1.Size = new System.Drawing.Size(1363, 450);
            // 
            // layoutManagerTabPage1
            // 
            this.layoutManagerTabPage1.AutoSize = true;
            this.layoutManagerTabPage1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage1.ColumnCount = 2;
            this.layoutManagerTabPage1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage1.Controls.Add(this.label1URAGODIDGODINE, 0, 0);
            this.layoutManagerTabPage1.Controls.Add(this.textURAGODIDGODINE, 1, 0);
            this.layoutManagerTabPage1.Controls.Add(this.label1URADOKIDDOKUMENT, 0, 1);
            this.layoutManagerTabPage1.Controls.Add(this.comboURADOKIDDOKUMENT, 1, 1);
            this.layoutManagerTabPage1.Controls.Add(this.label1URABROJ, 0, 2);
            this.layoutManagerTabPage1.Controls.Add(this.textURABROJ, 1, 2);
            this.layoutManagerTabPage1.Controls.Add(this.label1urapartnerIDPARTNER, 0, 3);
            this.layoutManagerTabPage1.Controls.Add(this.combourapartnerIDPARTNER, 1, 3);
            this.layoutManagerTabPage1.Controls.Add(this.label1URABROJRACUNADOBAVLJACA, 0, 4);
            this.layoutManagerTabPage1.Controls.Add(this.textURABROJRACUNADOBAVLJACA, 1, 4);
            this.layoutManagerTabPage1.Controls.Add(this.label1URADATUM, 0, 5);
            this.layoutManagerTabPage1.Controls.Add(this.datePickerURADATUM, 1, 5);
            this.layoutManagerTabPage1.Controls.Add(this.label1URAVALUTA, 0, 6);
            this.layoutManagerTabPage1.Controls.Add(this.datePickerURAVALUTA, 1, 6);
            this.layoutManagerTabPage1.Controls.Add(this.label1URANAPOMENA, 0, 7);
            this.layoutManagerTabPage1.Controls.Add(this.textURANAPOMENA, 1, 7);
            this.layoutManagerTabPage1.Controls.Add(this.label1URAMODEL, 0, 8);
            this.layoutManagerTabPage1.Controls.Add(this.textURAMODEL, 1, 8);
            this.layoutManagerTabPage1.Controls.Add(this.label1URAPOZIVNABROJ, 0, 9);
            this.layoutManagerTabPage1.Controls.Add(this.textURAPOZIVNABROJ, 1, 9);
            this.layoutManagerTabPage1.Controls.Add(this.label1URAUKUPNO, 0, 10);
            this.layoutManagerTabPage1.Controls.Add(this.textURAUKUPNO, 1, 10);
            this.errorProviderValidator1.SetDisplayName(this.layoutManagerTabPage1, "");
            this.layoutManagerTabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutManagerTabPage1.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerTabPage1.Margin = new System.Windows.Forms.Padding(5);
            this.layoutManagerTabPage1.Name = "layoutManagerTabPage1";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerTabPage1, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerTabPage1, "");
            this.errorProviderValidator1.SetRequired(this.layoutManagerTabPage1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerTabPage1, "");
            this.layoutManagerTabPage1.RowCount = 12;
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.Size = new System.Drawing.Size(1363, 450);
            this.layoutManagerTabPage1.TabIndex = 0;
            // 
            // label1URAGODIDGODINE
            // 
            this.label1URAGODIDGODINE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.TextVAlignAsString = "Middle";
            this.label1URAGODIDGODINE.Appearance = appearance1;
            this.label1URAGODIDGODINE.AutoSize = true;
            this.label1URAGODIDGODINE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1URAGODIDGODINE, "");
            this.label1URAGODIDGODINE.ImageSize = new System.Drawing.Size(7, 10);
            this.label1URAGODIDGODINE.Location = new System.Drawing.Point(3, 5);
            this.label1URAGODIDGODINE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1URAGODIDGODINE.Name = "label1URAGODIDGODINE";
            this.errorProviderValidator1.SetRegularExpression(this.label1URAGODIDGODINE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1URAGODIDGODINE, "");
            this.errorProviderValidator1.SetRequired(this.label1URAGODIDGODINE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1URAGODIDGODINE, "");
            this.label1URAGODIDGODINE.Size = new System.Drawing.Size(44, 14);
            this.label1URAGODIDGODINE.StyleSetName = "FieldUltraLabel";
            this.label1URAGODIDGODINE.TabIndex = 1;
            this.label1URAGODIDGODINE.Tag = "labelURAGODIDGODINE";
            this.label1URAGODIDGODINE.Text = "Godina:";
            // 
            // textURAGODIDGODINE
            // 
            this.textURAGODIDGODINE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textURAGODIDGODINE.ButtonsRight.Add(editorButton2);
            this.textURAGODIDGODINE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "URAGODIDGODINE", true));
            this.errorProviderValidator1.SetDisplayName(this.textURAGODIDGODINE, "");
            this.textURAGODIDGODINE.Location = new System.Drawing.Point(134, 1);
            this.textURAGODIDGODINE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textURAGODIDGODINE.MaskInput = "{LOC}-nnnn";
            this.textURAGODIDGODINE.MinimumSize = new System.Drawing.Size(65, 22);
            this.textURAGODIDGODINE.Name = "textURAGODIDGODINE";
            this.textURAGODIDGODINE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textURAGODIDGODINE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textURAGODIDGODINE, "");
            this.errorProviderValidator1.SetRequired(this.textURAGODIDGODINE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textURAGODIDGODINE, "");
            this.textURAGODIDGODINE.Size = new System.Drawing.Size(65, 22);
            this.textURAGODIDGODINE.TabIndex = 0;
            this.textURAGODIDGODINE.Tag = "URAGODIDGODINE";
            this.textURAGODIDGODINE.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.CallPromptGODINEURAGODIDGODINE);
            this.textURAGODIDGODINE.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textURAGODIDGODINE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // bindingSourceURA
            // 
            this.bindingSourceURA.DataMember = "URA";
            this.bindingSourceURA.DataSource = this.dsURADataSet1;
            // 
            // dsURADataSet1
            // 
            this.dsURADataSet1.DataSetName = "dsURA";
            this.dsURADataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // label1URADOKIDDOKUMENT
            // 
            this.label1URADOKIDDOKUMENT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.TextVAlignAsString = "Middle";
            this.label1URADOKIDDOKUMENT.Appearance = appearance2;
            this.label1URADOKIDDOKUMENT.AutoSize = true;
            this.label1URADOKIDDOKUMENT.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1URADOKIDDOKUMENT, "");
            this.label1URADOKIDDOKUMENT.ImageSize = new System.Drawing.Size(7, 10);
            this.label1URADOKIDDOKUMENT.Location = new System.Drawing.Point(3, 30);
            this.label1URADOKIDDOKUMENT.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1URADOKIDDOKUMENT.Name = "label1URADOKIDDOKUMENT";
            this.errorProviderValidator1.SetRegularExpression(this.label1URADOKIDDOKUMENT, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1URADOKIDDOKUMENT, "");
            this.errorProviderValidator1.SetRequired(this.label1URADOKIDDOKUMENT, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1URADOKIDDOKUMENT, "");
            this.label1URADOKIDDOKUMENT.Size = new System.Drawing.Size(59, 14);
            this.label1URADOKIDDOKUMENT.StyleSetName = "FieldUltraLabel";
            this.label1URADOKIDDOKUMENT.TabIndex = 1;
            this.label1URADOKIDDOKUMENT.Tag = "labelURADOKIDDOKUMENT";
            this.label1URADOKIDDOKUMENT.Text = "Dokument:";
            // 
            // comboURADOKIDDOKUMENT
            // 
            this.comboURADOKIDDOKUMENT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboURADOKIDDOKUMENT.BackColor = System.Drawing.Color.Transparent;
            this.comboURADOKIDDOKUMENT.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "URADOKIDDOKUMENT", true));
            this.comboURADOKIDDOKUMENT.DisplayMember = "NAZIVDOKUMENT";
            this.errorProviderValidator1.SetDisplayName(this.comboURADOKIDDOKUMENT, "");
            this.comboURADOKIDDOKUMENT.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
            this.comboURADOKIDDOKUMENT.FillByIDTIPDOKUMENTAIDTIPDOKUMENTA = 0;
            this.comboURADOKIDDOKUMENT.Location = new System.Drawing.Point(134, 26);
            this.comboURADOKIDDOKUMENT.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.comboURADOKIDDOKUMENT.MinimumSize = new System.Drawing.Size(406, 23);
            this.comboURADOKIDDOKUMENT.Name = "comboURADOKIDDOKUMENT";
            this.errorProviderValidator1.SetRegularExpression(this.comboURADOKIDDOKUMENT, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.comboURADOKIDDOKUMENT, "");
            this.errorProviderValidator1.SetRequired(this.comboURADOKIDDOKUMENT, false);
            this.errorProviderValidator1.SetRequiredMessage(this.comboURADOKIDDOKUMENT, "");
            this.comboURADOKIDDOKUMENT.ShowPictureBox = true;
            this.comboURADOKIDDOKUMENT.Size = new System.Drawing.Size(406, 23);
            this.comboURADOKIDDOKUMENT.TabIndex = 0;
            this.comboURADOKIDDOKUMENT.Tag = "URADOKIDDOKUMENT";
            this.comboURADOKIDDOKUMENT.ValueMember = "IDDOKUMENT";
            this.comboURADOKIDDOKUMENT.PictureBoxClicked += new System.EventHandler(this.PictureBoxClickedURADOKIDDOKUMENT);
            this.comboURADOKIDDOKUMENT.SelectionChanged += new System.EventHandler(this.SelectedIndexChangedURADOKIDDOKUMENT);
            this.comboURADOKIDDOKUMENT.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1URABROJ
            // 
            this.label1URABROJ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.TextVAlignAsString = "Middle";
            this.label1URABROJ.Appearance = appearance3;
            this.label1URABROJ.AutoSize = true;
            this.label1URABROJ.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1URABROJ, "");
            this.label1URABROJ.ImageSize = new System.Drawing.Size(7, 10);
            this.label1URABROJ.Location = new System.Drawing.Point(3, 56);
            this.label1URABROJ.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1URABROJ.Name = "label1URABROJ";
            this.errorProviderValidator1.SetRegularExpression(this.label1URABROJ, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1URABROJ, "");
            this.errorProviderValidator1.SetRequired(this.label1URABROJ, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1URABROJ, "");
            this.label1URABROJ.Size = new System.Drawing.Size(47, 14);
            this.label1URABROJ.StyleSetName = "FieldUltraLabel";
            this.label1URABROJ.TabIndex = 1;
            this.label1URABROJ.Tag = "labelURABROJ";
            this.label1URABROJ.Text = "Broj ure:";
            // 
            // textURABROJ
            // 
            this.textURABROJ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textURABROJ.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "URABROJ", true));
            this.errorProviderValidator1.SetDisplayName(this.textURABROJ, "");
            this.textURABROJ.Location = new System.Drawing.Point(134, 52);
            this.textURABROJ.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textURABROJ.MaskInput = "{LOC}-nnnnn";
            this.textURABROJ.MinimumSize = new System.Drawing.Size(51, 22);
            this.textURABROJ.Name = "textURABROJ";
            this.textURABROJ.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textURABROJ, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textURABROJ, "");
            this.errorProviderValidator1.SetRequired(this.textURABROJ, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textURABROJ, "");
            this.textURABROJ.Size = new System.Drawing.Size(51, 22);
            this.textURABROJ.TabIndex = 0;
            this.textURABROJ.Tag = "URABROJ";
            this.textURABROJ.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textURABROJ.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1urapartnerIDPARTNER
            // 
            this.label1urapartnerIDPARTNER.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextVAlignAsString = "Middle";
            this.label1urapartnerIDPARTNER.Appearance = appearance4;
            this.label1urapartnerIDPARTNER.AutoSize = true;
            this.label1urapartnerIDPARTNER.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1urapartnerIDPARTNER, "");
            this.label1urapartnerIDPARTNER.Location = new System.Drawing.Point(3, 81);
            this.label1urapartnerIDPARTNER.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1urapartnerIDPARTNER.Name = "label1urapartnerIDPARTNER";
            this.errorProviderValidator1.SetRegularExpression(this.label1urapartnerIDPARTNER, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1urapartnerIDPARTNER, "");
            this.errorProviderValidator1.SetRequired(this.label1urapartnerIDPARTNER, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1urapartnerIDPARTNER, "");
            this.label1urapartnerIDPARTNER.Size = new System.Drawing.Size(44, 14);
            this.label1urapartnerIDPARTNER.StyleSetName = "FieldUltraLabel";
            this.label1urapartnerIDPARTNER.TabIndex = 1;
            this.label1urapartnerIDPARTNER.Tag = "labelurapartnerIDPARTNER";
            this.label1urapartnerIDPARTNER.Text = "Partner:";
            // 
            // combourapartnerIDPARTNER
            // 
            this.combourapartnerIDPARTNER.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.combourapartnerIDPARTNER.BackColor = System.Drawing.Color.Transparent;
            this.combourapartnerIDPARTNER.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "urapartnerIDPARTNER", true));
            this.combourapartnerIDPARTNER.DisplayMember = "PT";
            this.errorProviderValidator1.SetDisplayName(this.combourapartnerIDPARTNER, "");
            this.combourapartnerIDPARTNER.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
            this.combourapartnerIDPARTNER.Location = new System.Drawing.Point(134, 77);
            this.combourapartnerIDPARTNER.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.combourapartnerIDPARTNER.MinimumSize = new System.Drawing.Size(616, 23);
            this.combourapartnerIDPARTNER.Name = "combourapartnerIDPARTNER";
            this.errorProviderValidator1.SetRegularExpression(this.combourapartnerIDPARTNER, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.combourapartnerIDPARTNER, "");
            this.errorProviderValidator1.SetRequired(this.combourapartnerIDPARTNER, false);
            this.errorProviderValidator1.SetRequiredMessage(this.combourapartnerIDPARTNER, "");
            this.combourapartnerIDPARTNER.ShowPictureBox = true;
            this.combourapartnerIDPARTNER.Size = new System.Drawing.Size(616, 23);
            this.combourapartnerIDPARTNER.TabIndex = 0;
            this.combourapartnerIDPARTNER.Tag = "urapartnerIDPARTNER";
            this.combourapartnerIDPARTNER.ValueMember = "IDPARTNER";
            this.combourapartnerIDPARTNER.PictureBoxClicked += new System.EventHandler(this.PictureBoxClickedurapartnerIDPARTNER);
            this.combourapartnerIDPARTNER.SelectionChanged += new System.EventHandler(this.SelectedIndexChangedurapartnerIDPARTNER);
            this.combourapartnerIDPARTNER.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.combourapartnerIDPARTNER.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            // 
            // label1URABROJRACUNADOBAVLJACA
            // 
            this.label1URABROJRACUNADOBAVLJACA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextVAlignAsString = "Middle";
            this.label1URABROJRACUNADOBAVLJACA.Appearance = appearance5;
            this.label1URABROJRACUNADOBAVLJACA.AutoSize = true;
            this.label1URABROJRACUNADOBAVLJACA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1URABROJRACUNADOBAVLJACA, "");
            this.label1URABROJRACUNADOBAVLJACA.Location = new System.Drawing.Point(3, 107);
            this.label1URABROJRACUNADOBAVLJACA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1URABROJRACUNADOBAVLJACA.Name = "label1URABROJRACUNADOBAVLJACA";
            this.errorProviderValidator1.SetRegularExpression(this.label1URABROJRACUNADOBAVLJACA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1URABROJRACUNADOBAVLJACA, "");
            this.errorProviderValidator1.SetRequired(this.label1URABROJRACUNADOBAVLJACA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1URABROJRACUNADOBAVLJACA, "");
            this.label1URABROJRACUNADOBAVLJACA.Size = new System.Drawing.Size(122, 14);
            this.label1URABROJRACUNADOBAVLJACA.StyleSetName = "FieldUltraLabel";
            this.label1URABROJRACUNADOBAVLJACA.TabIndex = 1;
            this.label1URABROJRACUNADOBAVLJACA.Tag = "labelURABROJRACUNADOBAVLJACA";
            this.label1URABROJRACUNADOBAVLJACA.Text = "Broj računa dobavljača:";
            // 
            // textURABROJRACUNADOBAVLJACA
            // 
            this.textURABROJRACUNADOBAVLJACA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textURABROJRACUNADOBAVLJACA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceURA, "URABROJRACUNADOBAVLJACA", true));
            this.errorProviderValidator1.SetDisplayName(this.textURABROJRACUNADOBAVLJACA, "");
            this.textURABROJRACUNADOBAVLJACA.Location = new System.Drawing.Point(134, 103);
            this.textURABROJRACUNADOBAVLJACA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textURABROJRACUNADOBAVLJACA.MaxLength = 100;
            this.textURABROJRACUNADOBAVLJACA.MinimumSize = new System.Drawing.Size(576, 22);
            this.textURABROJRACUNADOBAVLJACA.Name = "textURABROJRACUNADOBAVLJACA";
            this.errorProviderValidator1.SetRegularExpression(this.textURABROJRACUNADOBAVLJACA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textURABROJRACUNADOBAVLJACA, "");
            this.errorProviderValidator1.SetRequired(this.textURABROJRACUNADOBAVLJACA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textURABROJRACUNADOBAVLJACA, "");
            this.textURABROJRACUNADOBAVLJACA.Size = new System.Drawing.Size(576, 22);
            this.textURABROJRACUNADOBAVLJACA.TabIndex = 0;
            this.textURABROJRACUNADOBAVLJACA.Tag = "URABROJRACUNADOBAVLJACA";
            this.textURABROJRACUNADOBAVLJACA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1URADATUM
            // 
            this.label1URADATUM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.label1URADATUM.Appearance = appearance6;
            this.label1URADATUM.AutoSize = true;
            this.label1URADATUM.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1URADATUM, "");
            this.label1URADATUM.Location = new System.Drawing.Point(3, 132);
            this.label1URADATUM.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1URADATUM.Name = "label1URADATUM";
            this.errorProviderValidator1.SetRegularExpression(this.label1URADATUM, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1URADATUM, "");
            this.errorProviderValidator1.SetRequired(this.label1URADATUM, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1URADATUM, "");
            this.label1URADATUM.Size = new System.Drawing.Size(41, 14);
            this.label1URADATUM.StyleSetName = "FieldUltraLabel";
            this.label1URADATUM.TabIndex = 1;
            this.label1URADATUM.Tag = "labelURADATUM";
            this.label1URADATUM.Text = "Datum:";
            // 
            // datePickerURADATUM
            // 
            this.datePickerURADATUM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorProviderValidator1.SetDisplayName(this.datePickerURADATUM, "");
            this.datePickerURADATUM.Location = new System.Drawing.Point(134, 128);
            this.datePickerURADATUM.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.datePickerURADATUM.MinimumSize = new System.Drawing.Size(100, 22);
            this.datePickerURADATUM.Name = "datePickerURADATUM";
            this.errorProviderValidator1.SetRegularExpression(this.datePickerURADATUM, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.datePickerURADATUM, "");
            this.errorProviderValidator1.SetRequired(this.datePickerURADATUM, false);
            this.errorProviderValidator1.SetRequiredMessage(this.datePickerURADATUM, "");
            this.datePickerURADATUM.Size = new System.Drawing.Size(100, 22);
            this.datePickerURADATUM.TabIndex = 0;
            this.datePickerURADATUM.Tag = "URADATUM";
            this.datePickerURADATUM.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1URAVALUTA
            // 
            this.label1URAVALUTA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.label1URAVALUTA.Appearance = appearance7;
            this.label1URAVALUTA.AutoSize = true;
            this.label1URAVALUTA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1URAVALUTA, "");
            this.label1URAVALUTA.Location = new System.Drawing.Point(3, 157);
            this.label1URAVALUTA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1URAVALUTA.Name = "label1URAVALUTA";
            this.errorProviderValidator1.SetRegularExpression(this.label1URAVALUTA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1URAVALUTA, "");
            this.errorProviderValidator1.SetRequired(this.label1URAVALUTA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1URAVALUTA, "");
            this.label1URAVALUTA.Size = new System.Drawing.Size(40, 14);
            this.label1URAVALUTA.StyleSetName = "FieldUltraLabel";
            this.label1URAVALUTA.TabIndex = 1;
            this.label1URAVALUTA.Tag = "labelURAVALUTA";
            this.label1URAVALUTA.Text = "Valuta:";
            // 
            // datePickerURAVALUTA
            // 
            this.datePickerURAVALUTA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorProviderValidator1.SetDisplayName(this.datePickerURAVALUTA, "");
            this.datePickerURAVALUTA.Location = new System.Drawing.Point(134, 153);
            this.datePickerURAVALUTA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.datePickerURAVALUTA.MinimumSize = new System.Drawing.Size(100, 22);
            this.datePickerURAVALUTA.Name = "datePickerURAVALUTA";
            this.errorProviderValidator1.SetRegularExpression(this.datePickerURAVALUTA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.datePickerURAVALUTA, "");
            this.errorProviderValidator1.SetRequired(this.datePickerURAVALUTA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.datePickerURAVALUTA, "");
            this.datePickerURAVALUTA.Size = new System.Drawing.Size(100, 22);
            this.datePickerURAVALUTA.TabIndex = 0;
            this.datePickerURAVALUTA.Tag = "URAVALUTA";
            this.datePickerURAVALUTA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1URANAPOMENA
            // 
            this.label1URANAPOMENA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.label1URANAPOMENA.Appearance = appearance8;
            this.label1URANAPOMENA.AutoSize = true;
            this.label1URANAPOMENA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1URANAPOMENA, "");
            this.label1URANAPOMENA.Location = new System.Drawing.Point(3, 182);
            this.label1URANAPOMENA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1URANAPOMENA.Name = "label1URANAPOMENA";
            this.errorProviderValidator1.SetRegularExpression(this.label1URANAPOMENA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1URANAPOMENA, "");
            this.errorProviderValidator1.SetRequired(this.label1URANAPOMENA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1URANAPOMENA, "");
            this.label1URANAPOMENA.Size = new System.Drawing.Size(63, 14);
            this.label1URANAPOMENA.StyleSetName = "FieldUltraLabel";
            this.label1URANAPOMENA.TabIndex = 1;
            this.label1URANAPOMENA.Tag = "labelURANAPOMENA";
            this.label1URANAPOMENA.Text = "Napomena:";
            // 
            // textURANAPOMENA
            // 
            this.textURANAPOMENA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textURANAPOMENA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceURA, "URANAPOMENA", true));
            this.errorProviderValidator1.SetDisplayName(this.textURANAPOMENA, "");
            this.textURANAPOMENA.Location = new System.Drawing.Point(134, 178);
            this.textURANAPOMENA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textURANAPOMENA.MaxLength = 50;
            this.textURANAPOMENA.MinimumSize = new System.Drawing.Size(366, 22);
            this.textURANAPOMENA.Name = "textURANAPOMENA";
            this.errorProviderValidator1.SetRegularExpression(this.textURANAPOMENA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textURANAPOMENA, "");
            this.errorProviderValidator1.SetRequired(this.textURANAPOMENA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textURANAPOMENA, "");
            this.textURANAPOMENA.Size = new System.Drawing.Size(366, 22);
            this.textURANAPOMENA.TabIndex = 0;
            this.textURANAPOMENA.Tag = "URANAPOMENA";
            this.textURANAPOMENA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1URAMODEL
            // 
            this.label1URAMODEL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextVAlignAsString = "Middle";
            this.label1URAMODEL.Appearance = appearance9;
            this.label1URAMODEL.AutoSize = true;
            this.label1URAMODEL.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1URAMODEL, "");
            this.label1URAMODEL.Location = new System.Drawing.Point(3, 207);
            this.label1URAMODEL.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1URAMODEL.Name = "label1URAMODEL";
            this.errorProviderValidator1.SetRegularExpression(this.label1URAMODEL, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1URAMODEL, "");
            this.errorProviderValidator1.SetRequired(this.label1URAMODEL, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1URAMODEL, "");
            this.label1URAMODEL.Size = new System.Drawing.Size(92, 14);
            this.label1URAMODEL.StyleSetName = "FieldUltraLabel";
            this.label1URAMODEL.TabIndex = 1;
            this.label1URAMODEL.Tag = "labelURAMODEL";
            this.label1URAMODEL.Text = "Model odobrenja:";
            // 
            // textURAMODEL
            // 
            this.textURAMODEL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textURAMODEL.ContextMenu = this.contextMenu1;
            this.textURAMODEL.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceURA, "URAMODEL", true));
            this.errorProviderValidator1.SetDisplayName(this.textURAMODEL, "");
            this.textURAMODEL.Location = new System.Drawing.Point(134, 203);
            this.textURAMODEL.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textURAMODEL.MaxLength = 2;
            this.textURAMODEL.MinimumSize = new System.Drawing.Size(30, 22);
            this.textURAMODEL.Name = "textURAMODEL";
            this.errorProviderValidator1.SetRegularExpression(this.textURAMODEL, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textURAMODEL, "");
            this.errorProviderValidator1.SetRequired(this.textURAMODEL, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textURAMODEL, "");
            this.textURAMODEL.Size = new System.Drawing.Size(30, 22);
            this.textURAMODEL.TabIndex = 0;
            this.textURAMODEL.Tag = "URAMODEL";
            this.textURAMODEL.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
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
            // label1URAPOZIVNABROJ
            // 
            this.label1URAPOZIVNABROJ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextVAlignAsString = "Middle";
            this.label1URAPOZIVNABROJ.Appearance = appearance10;
            this.label1URAPOZIVNABROJ.AutoSize = true;
            this.label1URAPOZIVNABROJ.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1URAPOZIVNABROJ, "");
            this.label1URAPOZIVNABROJ.Location = new System.Drawing.Point(3, 232);
            this.label1URAPOZIVNABROJ.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1URAPOZIVNABROJ.Name = "label1URAPOZIVNABROJ";
            this.errorProviderValidator1.SetRegularExpression(this.label1URAPOZIVNABROJ, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1URAPOZIVNABROJ, "");
            this.errorProviderValidator1.SetRequired(this.label1URAPOZIVNABROJ, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1URAPOZIVNABROJ, "");
            this.label1URAPOZIVNABROJ.Size = new System.Drawing.Size(126, 14);
            this.label1URAPOZIVNABROJ.StyleSetName = "FieldUltraLabel";
            this.label1URAPOZIVNABROJ.TabIndex = 1;
            this.label1URAPOZIVNABROJ.Tag = "labelURAPOZIVNABROJ";
            this.label1URAPOZIVNABROJ.Text = "Poziv na broj odobrenja:";
            // 
            // textURAPOZIVNABROJ
            // 
            this.textURAPOZIVNABROJ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textURAPOZIVNABROJ.ContextMenu = this.contextMenu1;
            this.textURAPOZIVNABROJ.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceURA, "URAPOZIVNABROJ", true));
            this.errorProviderValidator1.SetDisplayName(this.textURAPOZIVNABROJ, "");
            this.textURAPOZIVNABROJ.Location = new System.Drawing.Point(134, 228);
            this.textURAPOZIVNABROJ.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textURAPOZIVNABROJ.MaxLength = 22;
            this.textURAPOZIVNABROJ.MinimumSize = new System.Drawing.Size(170, 22);
            this.textURAPOZIVNABROJ.Name = "textURAPOZIVNABROJ";
            this.errorProviderValidator1.SetRegularExpression(this.textURAPOZIVNABROJ, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textURAPOZIVNABROJ, "");
            this.errorProviderValidator1.SetRequired(this.textURAPOZIVNABROJ, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textURAPOZIVNABROJ, "");
            this.textURAPOZIVNABROJ.Size = new System.Drawing.Size(170, 22);
            this.textURAPOZIVNABROJ.TabIndex = 0;
            this.textURAPOZIVNABROJ.Tag = "URAPOZIVNABROJ";
            this.textURAPOZIVNABROJ.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1URAUKUPNO
            // 
            this.label1URAUKUPNO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextVAlignAsString = "Middle";
            this.label1URAUKUPNO.Appearance = appearance11;
            this.label1URAUKUPNO.AutoSize = true;
            this.label1URAUKUPNO.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1URAUKUPNO, "");
            this.label1URAUKUPNO.Location = new System.Drawing.Point(3, 257);
            this.label1URAUKUPNO.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1URAUKUPNO.Name = "label1URAUKUPNO";
            this.errorProviderValidator1.SetRegularExpression(this.label1URAUKUPNO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1URAUKUPNO, "");
            this.errorProviderValidator1.SetRequired(this.label1URAUKUPNO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1URAUKUPNO, "");
            this.label1URAUKUPNO.Size = new System.Drawing.Size(114, 14);
            this.label1URAUKUPNO.StyleSetName = "FieldUltraLabel";
            this.label1URAUKUPNO.TabIndex = 1;
            this.label1URAUKUPNO.Tag = "labelURAUKUPNO";
            this.label1URAUKUPNO.Text = "Ukupan iznos računa:";
            // 
            // textURAUKUPNO
            // 
            this.textURAUKUPNO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textURAUKUPNO.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "URAUKUPNO", true));
            this.errorProviderValidator1.SetDisplayName(this.textURAUKUPNO, "");
            this.textURAUKUPNO.Location = new System.Drawing.Point(134, 253);
            this.textURAUKUPNO.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textURAUKUPNO.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textURAUKUPNO.MinimumSize = new System.Drawing.Size(102, 22);
            this.textURAUKUPNO.Name = "textURAUKUPNO";
            this.textURAUKUPNO.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textURAUKUPNO.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textURAUKUPNO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textURAUKUPNO, "");
            this.errorProviderValidator1.SetRequired(this.textURAUKUPNO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textURAUKUPNO, "");
            this.textURAUKUPNO.Size = new System.Drawing.Size(102, 22);
            this.textURAUKUPNO.TabIndex = 0;
            this.textURAUKUPNO.Tag = "URAUKUPNO";
            this.textURAUKUPNO.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textURAUKUPNO.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.layoutManagerTabPage2);
            this.errorProviderValidator1.SetDisplayName(this.TabPage2, "");
            this.TabPage2.Location = new System.Drawing.Point(1, 23);
            this.TabPage2.Name = "TabPage2";
            this.errorProviderValidator1.SetRegularExpression(this.TabPage2, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.TabPage2, "");
            this.errorProviderValidator1.SetRequired(this.TabPage2, false);
            this.errorProviderValidator1.SetRequiredMessage(this.TabPage2, "");
            this.TabPage2.Size = new System.Drawing.Size(1363, 450);

            #region MBS.Complete 26.04.2016
            this.TabPage3.Controls.Add(this.layoutManagerTabPage3);
            this.errorProviderValidator1.SetDisplayName(this.TabPage3, "");
            this.TabPage3.Location = new System.Drawing.Point(1, 23);
            this.TabPage3.Name = "TabPage3";
            this.errorProviderValidator1.SetRegularExpression(this.TabPage3, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.TabPage3, "");
            this.errorProviderValidator1.SetRequired(this.TabPage3, false);
            this.errorProviderValidator1.SetRequiredMessage(this.TabPage3, "");
            this.TabPage3.Size = new System.Drawing.Size(1363, 450);
            #endregion

            // 
            // layoutManagerTabPage2
            // 
            this.layoutManagerTabPage2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage2.ColumnCount = 10;
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.Controls.Add(this.label1R2, 0, 1);
            this.layoutManagerTabPage2.Controls.Add(this.checkR2, 1, 1);
            this.layoutManagerTabPage2.Controls.Add(this.textIDTIPURA, 1, 0);
            this.layoutManagerTabPage2.Controls.Add(this.label1IDTIPURA, 0, 0);
            this.layoutManagerTabPage2.Controls.Add(this.label1OSNOVICA0, 0, 2);
            this.layoutManagerTabPage2.Controls.Add(this.pdv22, 7, 17);
            this.layoutManagerTabPage2.Controls.Add(this.textOSNOVICA0, 1, 2);
            this.layoutManagerTabPage2.Controls.Add(this.textOSNOVICA22NE, 7, 9);
            this.layoutManagerTabPage2.Controls.Add(this.label1OSNOVICA22NE, 6, 9);
            this.layoutManagerTabPage2.Controls.Add(this.textOSNOVICA22, 7, 8);
            this.layoutManagerTabPage2.Controls.Add(this.label1OSNOVICA22, 6, 8);
            this.layoutManagerTabPage2.Controls.Add(this.label1PDV22NE, 6, 15);
            this.layoutManagerTabPage2.Controls.Add(this.textPDV22NE, 7, 15);
            this.layoutManagerTabPage2.Controls.Add(this.ultraLabel6, 0, 12);
            this.layoutManagerTabPage2.Controls.Add(this.label1PDV22DA, 6, 14);
            this.layoutManagerTabPage2.Controls.Add(this.textPDV22DA, 7, 14);
            this.layoutManagerTabPage2.Controls.Add(this.ultraLabel3, 0, 6);
            this.layoutManagerTabPage2.Controls.Add(this.label1OSNOVICA25, 0, 8);
            this.layoutManagerTabPage2.Controls.Add(this.label1OSNOVICA25NE, 0, 9);
            this.layoutManagerTabPage2.Controls.Add(this.label1PDV25DA, 0, 14);
            this.layoutManagerTabPage2.Controls.Add(this.textOSNOVICA25, 1, 8);
            this.layoutManagerTabPage2.Controls.Add(this.textOSNOVICA25NE, 1, 9);
            this.layoutManagerTabPage2.Controls.Add(this.textPDV25DA, 1, 14);
            this.layoutManagerTabPage2.Controls.Add(this.textPDV25NE, 1, 15);
            this.layoutManagerTabPage2.Controls.Add(this.label1PDV25NE, 0, 15);
            this.layoutManagerTabPage2.Controls.Add(this.pdv25, 1, 17);
            this.layoutManagerTabPage2.Controls.Add(this.ultraLabel4, 6, 6);
            this.layoutManagerTabPage2.Controls.Add(this.ultraLabel5, 8, 6);
            this.layoutManagerTabPage2.Controls.Add(this.label1OSNOVICA23, 8, 8);
            this.layoutManagerTabPage2.Controls.Add(this.label1OSNOVICA23NE, 8, 9);
            this.layoutManagerTabPage2.Controls.Add(this.label1PDV23DA, 8, 14);
            this.layoutManagerTabPage2.Controls.Add(this.ultraLabel1, 0, 19);
            this.layoutManagerTabPage2.Controls.Add(this.label1PDV23NE, 8, 15);
            this.layoutManagerTabPage2.Controls.Add(this.textOSNOVICA23, 9, 8);
            this.layoutManagerTabPage2.Controls.Add(this.textOSNOVICA23NE, 9, 9);
            this.layoutManagerTabPage2.Controls.Add(this.textPDV23DA, 9, 14);
            this.layoutManagerTabPage2.Controls.Add(this.textPDV23NE, 9, 15);
            //this.layoutManagerTabPage2.Controls.Add(this.pdv23, 9, 17);
            this.layoutManagerTabPage2.Controls.Add(this.ultraLabel2, 4, 6);
            this.layoutManagerTabPage2.Controls.Add(this.label1OSNOVICA10, 4, 8);
            this.layoutManagerTabPage2.Controls.Add(this.textOSNOVICA10, 5, 8);
            this.layoutManagerTabPage2.Controls.Add(this.label1OSNOVICA10NE, 4, 9);
            this.layoutManagerTabPage2.Controls.Add(this.textOSNOVICA10NE, 5, 9);
            this.layoutManagerTabPage2.Controls.Add(this.label1PDV10DA, 4, 14);
            this.layoutManagerTabPage2.Controls.Add(this.textPDV10DA, 5, 14);
            this.layoutManagerTabPage2.Controls.Add(this.label1PDV10NE, 4, 15);
            this.layoutManagerTabPage2.Controls.Add(this.textPDV10NE, 5, 15);
            this.layoutManagerTabPage2.Controls.Add(this.pdv10, 5, 17);
            this.layoutManagerTabPage2.Controls.Add(this.ultraLabel9, 2, 6);
            this.layoutManagerTabPage2.Controls.Add(this.label1OSNOVICA5, 2, 8);
            this.layoutManagerTabPage2.Controls.Add(this.label1OSNOVICA5NE, 2, 9);
            this.layoutManagerTabPage2.Controls.Add(this.textOSNOVICA5, 3, 8);
            this.layoutManagerTabPage2.Controls.Add(this.textOSNOVICA5NE, 3, 9);
            this.layoutManagerTabPage2.Controls.Add(this.label1PDV5DA, 2, 14);
            this.layoutManagerTabPage2.Controls.Add(this.label1PDV5NE, 2, 15);
            this.layoutManagerTabPage2.Controls.Add(this.pdv5, 3, 17);
            this.layoutManagerTabPage2.Controls.Add(this.textPDV5DA, 3, 14);
            this.layoutManagerTabPage2.Controls.Add(this.textPDV5NE, 3, 15);
            this.errorProviderValidator1.SetDisplayName(this.layoutManagerTabPage2, "");
            this.layoutManagerTabPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutManagerTabPage2.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerTabPage2.Margin = new System.Windows.Forms.Padding(5);
            this.layoutManagerTabPage2.Name = "layoutManagerTabPage2";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerTabPage2, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerTabPage2, "");
            this.errorProviderValidator1.SetRequired(this.layoutManagerTabPage2, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerTabPage2, "");
            this.layoutManagerTabPage2.RowCount = 20;
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutManagerTabPage2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutManagerTabPage2.Size = new System.Drawing.Size(1363, 450);
            this.layoutManagerTabPage2.TabIndex = 0;


            #region MBS.Complete 26.04.2016
            this.layoutManagerTabPage3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage3.ColumnCount = 10;
            this.layoutManagerTabPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());

            this.layoutManagerTabPage3.Controls.Add(this.lblOsnovica, 0, 0);
            this.layoutManagerTabPage3.Controls.Add(this.txtOsnovica, 1, 0);
            this.layoutManagerTabPage3.Controls.Add(this.lblMoze, 0, 1);
            this.layoutManagerTabPage3.Controls.Add(this.txtMoze, 1, 1);
            this.layoutManagerTabPage3.Controls.Add(this.lblNeMoze, 0, 2);
            this.layoutManagerTabPage3.Controls.Add(this.txtNeMoze, 1, 2);
          
            this.errorProviderValidator1.SetDisplayName(this.layoutManagerTabPage3, "");
            this.layoutManagerTabPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutManagerTabPage3.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerTabPage3.Margin = new System.Windows.Forms.Padding(5);
            this.layoutManagerTabPage3.Name = "layoutManagerTabPage3";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerTabPage3, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerTabPage3, "");
            this.errorProviderValidator1.SetRequired(this.layoutManagerTabPage3, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerTabPage3, "");
            this.layoutManagerTabPage3.RowCount = 20;
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutManagerTabPage3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutManagerTabPage3.Size = new System.Drawing.Size(1363, 450);
            this.layoutManagerTabPage3.TabIndex = 0;

            this.txtOsnovica.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtOsnovica.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "OsnovicaPPO", true));
            this.errorProviderValidator1.SetDisplayName(this.txtOsnovica, "");
            this.txtOsnovica.Location = new System.Drawing.Point(158, 133);
            this.txtOsnovica.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.txtOsnovica.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.txtOsnovica.MinimumSize = new System.Drawing.Size(102, 22);
            this.txtOsnovica.Name = "txtOsnovica";
            this.txtOsnovica.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtOsnovica.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.txtOsnovica, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.txtOsnovica, "");
            this.errorProviderValidator1.SetRequired(this.txtOsnovica, false);
            this.errorProviderValidator1.SetRequiredMessage(this.txtOsnovica, "");
            this.txtOsnovica.Size = new System.Drawing.Size(102, 22);
            this.txtOsnovica.TabIndex = 2;
            this.txtOsnovica.Tag = "Osnovica";
            this.txtOsnovica.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.txtOsnovica.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.txtMoze.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMoze.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "MozePPO", true));
            this.errorProviderValidator1.SetDisplayName(this.txtOsnovica, "");
            this.txtMoze.Location = new System.Drawing.Point(158, 133);
            this.txtMoze.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.txtMoze.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.txtMoze.MinimumSize = new System.Drawing.Size(102, 22);
            this.txtMoze.Name = "txtMoze";
            this.txtMoze.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtMoze.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.txtMoze, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.txtMoze, "");
            this.errorProviderValidator1.SetRequired(this.txtMoze, false);
            this.errorProviderValidator1.SetRequiredMessage(this.txtMoze, "");
            this.txtMoze.Size = new System.Drawing.Size(102, 22);
            this.txtMoze.TabIndex = 2;
            this.txtMoze.Tag = "Moze";
            this.txtMoze.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.txtMoze.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.txtNeMoze.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNeMoze.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "NeMozePPO", true));
            this.errorProviderValidator1.SetDisplayName(this.txtNeMoze, "");
            this.txtNeMoze.Location = new System.Drawing.Point(158, 133);
            this.txtNeMoze.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.txtNeMoze.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.txtNeMoze.MinimumSize = new System.Drawing.Size(102, 22);
            this.txtNeMoze.Name = "txtNeMoze";
            this.txtNeMoze.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtNeMoze.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.txtNeMoze, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.txtNeMoze, "");
            this.errorProviderValidator1.SetRequired(this.txtNeMoze, false);
            this.errorProviderValidator1.SetRequiredMessage(this.txtNeMoze, "");
            this.txtNeMoze.Size = new System.Drawing.Size(102, 22);
            this.txtNeMoze.TabIndex = 2;
            this.txtNeMoze.Tag = "NeMoze";
            this.txtNeMoze.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.txtNeMoze.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            #endregion



            // 
            // label1R2
            // 
            this.label1R2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance22.ForeColor = System.Drawing.Color.Black;
            appearance22.TextVAlignAsString = "Middle";
            this.label1R2.Appearance = appearance22;
            this.label1R2.AutoSize = true;
            this.label1R2.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1R2, "");
            this.label1R2.Location = new System.Drawing.Point(3, 26);
            this.label1R2.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1R2.Name = "label1R2";
            this.errorProviderValidator1.SetRegularExpression(this.label1R2, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1R2, "");
            this.errorProviderValidator1.SetRequired(this.label1R2, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1R2, "");
            this.label1R2.Size = new System.Drawing.Size(22, 14);
            this.label1R2.StyleSetName = "FieldUltraLabel";
            this.label1R2.TabIndex = 1;
            this.label1R2.Tag = "labelR2";
            this.label1R2.Text = "R2:";
            // 
            // checkR2
            // 
            this.checkR2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorProviderValidator1.SetDisplayName(this.checkR2, "");
            this.checkR2.Location = new System.Drawing.Point(158, 26);
            this.checkR2.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.checkR2.MinimumSize = new System.Drawing.Size(13, 13);
            this.checkR2.Name = "checkR2";
            this.errorProviderValidator1.SetRegularExpression(this.checkR2, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.checkR2, "");
            this.errorProviderValidator1.SetRequired(this.checkR2, false);
            this.errorProviderValidator1.SetRequiredMessage(this.checkR2, "");
            this.checkR2.Size = new System.Drawing.Size(13, 13);
            this.checkR2.TabIndex = 0;
            this.checkR2.Tag = "R2";
            this.checkR2.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // textIDTIPURA
            // 
            this.textIDTIPURA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textIDTIPURA.ButtonsRight.Add(editorButton1);
            this.textIDTIPURA.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "IDTIPURA", true));
            this.errorProviderValidator1.SetDisplayName(this.textIDTIPURA, "");
            this.textIDTIPURA.Location = new System.Drawing.Point(158, 1);
            this.textIDTIPURA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textIDTIPURA.MaskInput = "{LOC}-nnnnn";
            this.textIDTIPURA.MinimumSize = new System.Drawing.Size(71, 22);
            this.textIDTIPURA.Name = "textIDTIPURA";
            this.textIDTIPURA.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textIDTIPURA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textIDTIPURA, "");
            this.errorProviderValidator1.SetRequired(this.textIDTIPURA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textIDTIPURA, "");
            this.textIDTIPURA.Size = new System.Drawing.Size(71, 22);
            this.textIDTIPURA.TabIndex = 0;
            this.textIDTIPURA.Tag = "IDTIPURA";
            this.textIDTIPURA.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.CallPromptTIPURAIDTIPURA);
            this.textIDTIPURA.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textIDTIPURA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1IDTIPURA
            // 
            this.label1IDTIPURA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance38.ForeColor = System.Drawing.Color.Black;
            appearance38.TextVAlignAsString = "Middle";
            this.label1IDTIPURA.Appearance = appearance38;
            this.label1IDTIPURA.AutoSize = true;
            this.label1IDTIPURA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IDTIPURA, "");
            this.label1IDTIPURA.Location = new System.Drawing.Point(3, 5);
            this.label1IDTIPURA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IDTIPURA.Name = "label1IDTIPURA";
            this.errorProviderValidator1.SetRegularExpression(this.label1IDTIPURA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IDTIPURA, "");
            this.errorProviderValidator1.SetRequired(this.label1IDTIPURA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IDTIPURA, "");
            this.label1IDTIPURA.Size = new System.Drawing.Size(43, 14);
            this.label1IDTIPURA.StyleSetName = "FieldUltraLabel";
            this.label1IDTIPURA.TabIndex = 1;
            this.label1IDTIPURA.Tag = "labelIDTIPURA";
            this.label1IDTIPURA.Text = "Tip ure:";
            // 
            // label1OSNOVICA0
            // 
            this.label1OSNOVICA0.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance36.ForeColor = System.Drawing.Color.Black;
            appearance36.TextVAlignAsString = "Middle";
            this.label1OSNOVICA0.Appearance = appearance36;
            this.label1OSNOVICA0.AutoSize = true;
            this.label1OSNOVICA0.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSNOVICA0, "");
            this.label1OSNOVICA0.Location = new System.Drawing.Point(3, 47);
            this.label1OSNOVICA0.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSNOVICA0.Name = "label1OSNOVICA0";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSNOVICA0, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSNOVICA0, "");
            this.errorProviderValidator1.SetRequired(this.label1OSNOVICA0, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSNOVICA0, "");
            this.label1OSNOVICA0.Size = new System.Drawing.Size(74, 14);
            this.label1OSNOVICA0.StyleSetName = "FieldUltraLabel";
            this.label1OSNOVICA0.TabIndex = 1;
            this.label1OSNOVICA0.Tag = "labelOSNOVICA0";
            this.label1OSNOVICA0.Text = "Osnovica 0%:";
            // 
            // pdv22
            // 
            this.errorProviderValidator1.SetDisplayName(this.pdv22, "");
            this.pdv22.Location = new System.Drawing.Point(943, 227);
            this.pdv22.Name = "pdv22";
            this.errorProviderValidator1.SetRegularExpression(this.pdv22, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.pdv22, "");
            this.errorProviderValidator1.SetRequired(this.pdv22, false);
            this.errorProviderValidator1.SetRequiredMessage(this.pdv22, "");
            this.pdv22.Size = new System.Drawing.Size(61, 23);
            this.pdv22.TabIndex = 20;
            this.pdv22.Text = "PDV 22";
            this.pdv22.UseVisualStyleBackColor = true;
            this.pdv22.Visible = false;
            //this.pdv22.Click += new System.EventHandler(this.pdv22_Click);
            // 
            // textOSNOVICA0
            // 
            this.textOSNOVICA0.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSNOVICA0.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "OSNOVICA0", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSNOVICA0, "");
            this.textOSNOVICA0.Location = new System.Drawing.Point(158, 43);
            this.textOSNOVICA0.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSNOVICA0.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSNOVICA0.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSNOVICA0.Name = "textOSNOVICA0";
            this.textOSNOVICA0.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSNOVICA0.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSNOVICA0, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSNOVICA0, "");
            this.errorProviderValidator1.SetRequired(this.textOSNOVICA0, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSNOVICA0, "");
            this.textOSNOVICA0.Size = new System.Drawing.Size(102, 22);
            this.textOSNOVICA0.TabIndex = 0;
            this.textOSNOVICA0.Tag = "OSNOVICA0";
            this.textOSNOVICA0.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOSNOVICA0.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // textOSNOVICA22NE
            // 
            this.textOSNOVICA22NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSNOVICA22NE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "OSNOVICA22NE", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSNOVICA22NE, "");
            this.textOSNOVICA22NE.Location = new System.Drawing.Point(940, 133);
            this.textOSNOVICA22NE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSNOVICA22NE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSNOVICA22NE.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSNOVICA22NE.Name = "textOSNOVICA22NE";
            this.textOSNOVICA22NE.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSNOVICA22NE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSNOVICA22NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSNOVICA22NE, "");
            this.errorProviderValidator1.SetRequired(this.textOSNOVICA22NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSNOVICA22NE, "");
            this.textOSNOVICA22NE.Size = new System.Drawing.Size(102, 22);
            this.textOSNOVICA22NE.TabIndex = 17;
            this.textOSNOVICA22NE.Tag = "OSNOVICA22NE";
            this.textOSNOVICA22NE.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOSNOVICA22NE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1OSNOVICA22NE
            // 
            this.label1OSNOVICA22NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.TextVAlignAsString = "Middle";
            this.label1OSNOVICA22NE.Appearance = appearance24;
            this.label1OSNOVICA22NE.AutoSize = true;
            this.label1OSNOVICA22NE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSNOVICA22NE, "");
            this.label1OSNOVICA22NE.Location = new System.Drawing.Point(785, 137);
            this.label1OSNOVICA22NE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSNOVICA22NE.Name = "label1OSNOVICA22NE";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSNOVICA22NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSNOVICA22NE, "");
            this.errorProviderValidator1.SetRequired(this.label1OSNOVICA22NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSNOVICA22NE, "");
            this.label1OSNOVICA22NE.Size = new System.Drawing.Size(147, 14);
            this.label1OSNOVICA22NE.StyleSetName = "FieldUltraLabel";
            this.label1OSNOVICA22NE.TabIndex = 1;
            this.label1OSNOVICA22NE.Tag = "labelOSNOVICA22NE";
            this.label1OSNOVICA22NE.Text = "Osnovica za 22% por. nepr.:";
            this.label1OSNOVICA22NE.Visible = false;
            // 
            // textOSNOVICA22
            // 
            this.textOSNOVICA22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSNOVICA22.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "OSNOVICA22", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSNOVICA22, "");
            this.textOSNOVICA22.Location = new System.Drawing.Point(940, 108);
            this.textOSNOVICA22.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSNOVICA22.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSNOVICA22.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSNOVICA22.Name = "textOSNOVICA22";
            this.textOSNOVICA22.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSNOVICA22.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSNOVICA22, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSNOVICA22, "");
            this.errorProviderValidator1.SetRequired(this.textOSNOVICA22, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSNOVICA22, "");
            this.textOSNOVICA22.Size = new System.Drawing.Size(102, 22);
            this.textOSNOVICA22.TabIndex = 16;
            this.textOSNOVICA22.Tag = "OSNOVICA22";
            this.textOSNOVICA22.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOSNOVICA22.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.textOSNOVICA22.Visible = false;
            // 
            // label1OSNOVICA22
            // 
            this.label1OSNOVICA22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.label1OSNOVICA22.Appearance = appearance23;
            this.label1OSNOVICA22.AutoSize = true;
            this.label1OSNOVICA22.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSNOVICA22, "");
            this.label1OSNOVICA22.Location = new System.Drawing.Point(785, 112);
            this.label1OSNOVICA22.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSNOVICA22.Name = "label1OSNOVICA22";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSNOVICA22, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSNOVICA22, "");
            this.errorProviderValidator1.SetRequired(this.label1OSNOVICA22, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSNOVICA22, "");
            this.label1OSNOVICA22.Size = new System.Drawing.Size(95, 14);
            this.label1OSNOVICA22.StyleSetName = "FieldUltraLabel";
            this.label1OSNOVICA22.TabIndex = 1;
            this.label1OSNOVICA22.Tag = "labelOSNOVICA22";
            this.label1OSNOVICA22.Text = "Osnovica za 22%:";
            this.label1OSNOVICA22.Visible = false;
            // 
            // label1PDV22NE
            // 
            this.label1PDV22NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.TextVAlignAsString = "Middle";
            this.label1PDV22NE.Appearance = appearance26;
            this.label1PDV22NE.AutoSize = true;
            this.label1PDV22NE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PDV22NE, "");
            this.label1PDV22NE.Location = new System.Drawing.Point(785, 204);
            this.label1PDV22NE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PDV22NE.Name = "label1PDV22NE";
            this.errorProviderValidator1.SetRegularExpression(this.label1PDV22NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PDV22NE, "");
            this.errorProviderValidator1.SetRequired(this.label1PDV22NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PDV22NE, "");
            this.label1PDV22NE.Size = new System.Drawing.Size(150, 14);
            this.label1PDV22NE.StyleSetName = "FieldUltraLabel";
            this.label1PDV22NE.TabIndex = 1;
            this.label1PDV22NE.Tag = "labelPDV22NE";
            this.label1PDV22NE.Text = "PDV 22% Ne može se odbiti:";
            this.label1PDV22NE.Visible = false;

            #region MBS.Complete 26.04.2016
            this.lblOsnovica.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.TextVAlignAsString = "Middle";
            this.lblOsnovica.Appearance = appearance26;
            this.lblOsnovica.AutoSize = true;
            this.lblOsnovica.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.lblOsnovica, "");
            this.lblOsnovica.Location = new System.Drawing.Point(785, 204);
            this.lblOsnovica.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.lblOsnovica.Name = "lblOsnovica";
            this.errorProviderValidator1.SetRegularExpression(this.lblOsnovica, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.lblOsnovica, "");
            this.errorProviderValidator1.SetRequired(this.lblOsnovica, false);
            this.errorProviderValidator1.SetRequiredMessage(this.lblOsnovica, "");
            this.lblOsnovica.Size = new System.Drawing.Size(150, 14);
            this.lblOsnovica.StyleSetName = "FieldUltraLabel";
            this.lblOsnovica.TabIndex = 1;
            this.lblOsnovica.Tag = "lblOsnovica";
            this.lblOsnovica.Text = "Osnovica:";
            this.lblMoze.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.TextVAlignAsString = "Middle";
            this.lblMoze.Appearance = appearance26;
            this.lblMoze.AutoSize = true;
            this.lblMoze.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.lblMoze, "");
            this.lblMoze.Location = new System.Drawing.Point(785, 204);
            this.lblMoze.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.lblMoze.Name = "lblMoze";
            this.errorProviderValidator1.SetRegularExpression(this.lblMoze, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.lblMoze, "");
            this.errorProviderValidator1.SetRequired(this.lblMoze, false);
            this.errorProviderValidator1.SetRequiredMessage(this.lblMoze, "");
            this.lblMoze.Size = new System.Drawing.Size(150, 14);
            this.lblMoze.StyleSetName = "FieldUltraLabel";
            this.lblMoze.TabIndex = 1;
            this.lblMoze.Tag = "lblMoze";
            this.lblMoze.Text = "Može se odbiti:";
            this.lblNeMoze.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.TextVAlignAsString = "Middle";
            this.lblNeMoze.Appearance = appearance26;
            this.lblNeMoze.AutoSize = true;
            this.lblNeMoze.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.lblNeMoze, "");
            this.lblNeMoze.Location = new System.Drawing.Point(785, 204);
            this.lblNeMoze.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.lblNeMoze.Name = "lblNeMoze";
            this.errorProviderValidator1.SetRegularExpression(this.lblNeMoze, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.lblNeMoze, "");
            this.errorProviderValidator1.SetRequired(this.lblNeMoze, false);
            this.errorProviderValidator1.SetRequiredMessage(this.lblNeMoze, "");
            this.lblNeMoze.Size = new System.Drawing.Size(150, 14);
            this.lblNeMoze.StyleSetName = "FieldUltraLabel";
            this.lblNeMoze.TabIndex = 1;
            this.lblNeMoze.Tag = "lblNeMoze";
            this.lblNeMoze.Text = "Ne može se odbiti:";
            #endregion


            // 
            // textPDV22NE
            // 
            this.textPDV22NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPDV22NE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "PDV22NE", true));
            this.errorProviderValidator1.SetDisplayName(this.textPDV22NE, "");
            this.textPDV22NE.Location = new System.Drawing.Point(940, 200);
            this.textPDV22NE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPDV22NE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPDV22NE.MinimumSize = new System.Drawing.Size(102, 22);
            this.textPDV22NE.Name = "textPDV22NE";
            this.textPDV22NE.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textPDV22NE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textPDV22NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPDV22NE, "");
            this.errorProviderValidator1.SetRequired(this.textPDV22NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPDV22NE, "");
            this.textPDV22NE.Size = new System.Drawing.Size(102, 22);
            this.textPDV22NE.TabIndex = 19;
            this.textPDV22NE.Tag = "PDV22NE";
            this.textPDV22NE.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textPDV22NE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.textPDV22NE.Visible = false;
            // 
            // ultraLabel6
            // 
            this.ultraLabel6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance21;
            this.ultraLabel6.AutoSize = true;
            this.ultraLabel6.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.ultraLabel6, "");
            this.ultraLabel6.Location = new System.Drawing.Point(3, 158);
            this.ultraLabel6.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.ultraLabel6.Name = "ultraLabel6";
            this.errorProviderValidator1.SetRegularExpression(this.ultraLabel6, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.ultraLabel6, "");
            this.errorProviderValidator1.SetRequired(this.ultraLabel6, false);
            this.errorProviderValidator1.SetRequiredMessage(this.ultraLabel6, "");
            this.ultraLabel6.Size = new System.Drawing.Size(4, 14);
            this.ultraLabel6.StyleSetName = "FieldUltraLabel";
            this.ultraLabel6.TabIndex = 12;
            this.ultraLabel6.Tag = "";
            this.ultraLabel6.Text = " ";
            // 
            // label1PDV22DA
            // 
            this.label1PDV22DA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.TextVAlignAsString = "Middle";
            this.label1PDV22DA.Appearance = appearance25;
            this.label1PDV22DA.AutoSize = true;
            this.label1PDV22DA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PDV22DA, "");
            this.label1PDV22DA.Location = new System.Drawing.Point(785, 179);
            this.label1PDV22DA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PDV22DA.Name = "label1PDV22DA";
            this.errorProviderValidator1.SetRegularExpression(this.label1PDV22DA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PDV22DA, "");
            this.errorProviderValidator1.SetRequired(this.label1PDV22DA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PDV22DA, "");
            this.label1PDV22DA.Size = new System.Drawing.Size(132, 14);
            this.label1PDV22DA.StyleSetName = "FieldUltraLabel";
            this.label1PDV22DA.TabIndex = 1;
            this.label1PDV22DA.Tag = "labelPDV22DA";
            this.label1PDV22DA.Text = "PDV 22% Može se odbiti:";
            this.label1PDV22DA.Visible = false;
            // 
            // textPDV22DA
            // 
            this.textPDV22DA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPDV22DA.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "PDV22DA", true));
            this.errorProviderValidator1.SetDisplayName(this.textPDV22DA, "");
            this.textPDV22DA.Location = new System.Drawing.Point(940, 175);
            this.textPDV22DA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPDV22DA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPDV22DA.MinimumSize = new System.Drawing.Size(102, 22);
            this.textPDV22DA.Name = "textPDV22DA";
            this.textPDV22DA.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textPDV22DA.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textPDV22DA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPDV22DA, "");
            this.errorProviderValidator1.SetRequired(this.textPDV22DA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPDV22DA, "");
            this.textPDV22DA.Size = new System.Drawing.Size(102, 22);
            this.textPDV22DA.TabIndex = 18;
            this.textPDV22DA.Tag = "PDV22DA";
            this.textPDV22DA.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textPDV22DA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.textPDV22DA.Visible = false;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance17;
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.ultraLabel3, "");
            this.ultraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel3.Location = new System.Drawing.Point(3, 88);
            this.ultraLabel3.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.ultraLabel3.Name = "ultraLabel3";
            this.errorProviderValidator1.SetRegularExpression(this.ultraLabel3, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.ultraLabel3, "");
            this.errorProviderValidator1.SetRequired(this.ultraLabel3, false);
            this.errorProviderValidator1.SetRequiredMessage(this.ultraLabel3, "");
            this.ultraLabel3.Size = new System.Drawing.Size(65, 17);
            this.ultraLabel3.StyleSetName = "FieldUltraLabel";
            this.ultraLabel3.TabIndex = 15;
            this.ultraLabel3.Tag = "labelOSNOVICA25";
            this.ultraLabel3.Text = "PDV 25%";
            // 
            // label1OSNOVICA25
            // 
            this.label1OSNOVICA25.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance32.ForeColor = System.Drawing.Color.Black;
            appearance32.TextVAlignAsString = "Middle";
            this.label1OSNOVICA25.Appearance = appearance32;
            this.label1OSNOVICA25.AutoSize = true;
            this.label1OSNOVICA25.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSNOVICA25, "");
            this.label1OSNOVICA25.Location = new System.Drawing.Point(3, 112);
            this.label1OSNOVICA25.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSNOVICA25.Name = "label1OSNOVICA25";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSNOVICA25, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSNOVICA25, "");
            this.errorProviderValidator1.SetRequired(this.label1OSNOVICA25, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSNOVICA25, "");
            this.label1OSNOVICA25.Size = new System.Drawing.Size(95, 14);
            this.label1OSNOVICA25.StyleSetName = "FieldUltraLabel";
            this.label1OSNOVICA25.TabIndex = 8;
            this.label1OSNOVICA25.Tag = "labelOSNOVICA25";
            this.label1OSNOVICA25.Text = "Osnovica za 25%:";
            // 
            // label1OSNOVICA25NE
            // 
            this.label1OSNOVICA25NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance31.ForeColor = System.Drawing.Color.Black;
            appearance31.TextVAlignAsString = "Middle";
            this.label1OSNOVICA25NE.Appearance = appearance31;
            this.label1OSNOVICA25NE.AutoSize = true;
            this.label1OSNOVICA25NE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSNOVICA25NE, "");
            this.label1OSNOVICA25NE.Location = new System.Drawing.Point(3, 137);
            this.label1OSNOVICA25NE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSNOVICA25NE.Name = "label1OSNOVICA25NE";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSNOVICA25NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSNOVICA25NE, "");
            this.errorProviderValidator1.SetRequired(this.label1OSNOVICA25NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSNOVICA25NE, "");
            this.label1OSNOVICA25NE.Size = new System.Drawing.Size(147, 14);
            this.label1OSNOVICA25NE.StyleSetName = "FieldUltraLabel";
            this.label1OSNOVICA25NE.TabIndex = 7;
            this.label1OSNOVICA25NE.Tag = "labelOSNOVICA25NE";
            this.label1OSNOVICA25NE.Text = "Osnovica za 25% por. nepr.:";
            // 
            // label1PDV25DA
            // 
            this.label1PDV25DA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance30.ForeColor = System.Drawing.Color.Black;
            appearance30.TextVAlignAsString = "Middle";
            this.label1PDV25DA.Appearance = appearance30;
            this.label1PDV25DA.AutoSize = true;
            this.label1PDV25DA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PDV25DA, "");
            this.label1PDV25DA.Location = new System.Drawing.Point(3, 179);
            this.label1PDV25DA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PDV25DA.Name = "label1PDV25DA";
            this.errorProviderValidator1.SetRegularExpression(this.label1PDV25DA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PDV25DA, "");
            this.errorProviderValidator1.SetRequired(this.label1PDV25DA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PDV25DA, "");
            this.label1PDV25DA.Size = new System.Drawing.Size(132, 14);
            this.label1PDV25DA.StyleSetName = "FieldUltraLabel";
            this.label1PDV25DA.TabIndex = 6;
            this.label1PDV25DA.Tag = "labelPDV25DA";
            this.label1PDV25DA.Text = "PDV 25% Može se odbiti:";
            // 
            // textOSNOVICA25
            // 
            this.textOSNOVICA25.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSNOVICA25.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "OSNOVICA25", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSNOVICA25, "");
            this.textOSNOVICA25.Location = new System.Drawing.Point(158, 108);
            this.textOSNOVICA25.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSNOVICA25.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSNOVICA25.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSNOVICA25.Name = "textOSNOVICA25";
            this.textOSNOVICA25.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSNOVICA25.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSNOVICA25, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSNOVICA25, "");
            this.errorProviderValidator1.SetRequired(this.textOSNOVICA25, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSNOVICA25, "");
            this.textOSNOVICA25.Size = new System.Drawing.Size(102, 22);
            this.textOSNOVICA25.TabIndex = 1;
            this.textOSNOVICA25.Tag = "OSNOVICA25";
            this.textOSNOVICA25.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOSNOVICA25.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // textOSNOVICA25NE
            // 
            this.textOSNOVICA25NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSNOVICA25NE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "OSNOVICA25NE", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSNOVICA25NE, "");
            this.textOSNOVICA25NE.Location = new System.Drawing.Point(158, 133);
            this.textOSNOVICA25NE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSNOVICA25NE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSNOVICA25NE.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSNOVICA25NE.Name = "textOSNOVICA25NE";
            this.textOSNOVICA25NE.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSNOVICA25NE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSNOVICA25NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSNOVICA25NE, "");
            this.errorProviderValidator1.SetRequired(this.textOSNOVICA25NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSNOVICA25NE, "");
            this.textOSNOVICA25NE.Size = new System.Drawing.Size(102, 22);
            this.textOSNOVICA25NE.TabIndex = 2;
            this.textOSNOVICA25NE.Tag = "OSNOVICA25NE";
            this.textOSNOVICA25NE.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOSNOVICA25NE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // textPDV25DA
            // 
            this.textPDV25DA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPDV25DA.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "PDV25DA", true));
            this.errorProviderValidator1.SetDisplayName(this.textPDV25DA, "");
            this.textPDV25DA.Location = new System.Drawing.Point(158, 175);
            this.textPDV25DA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPDV25DA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPDV25DA.MinimumSize = new System.Drawing.Size(102, 22);
            this.textPDV25DA.Name = "textPDV25DA";
            this.textPDV25DA.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textPDV25DA.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textPDV25DA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPDV25DA, "");
            this.errorProviderValidator1.SetRequired(this.textPDV25DA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPDV25DA, "");
            this.textPDV25DA.Size = new System.Drawing.Size(102, 22);
            this.textPDV25DA.TabIndex = 3;
            this.textPDV25DA.Tag = "PDV25DA";
            this.textPDV25DA.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textPDV25DA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // textPDV25NE
            // 
            this.textPDV25NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPDV25NE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "PDV25NE", true));
            this.errorProviderValidator1.SetDisplayName(this.textPDV25NE, "");
            this.textPDV25NE.Location = new System.Drawing.Point(158, 200);
            this.textPDV25NE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPDV25NE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPDV25NE.MinimumSize = new System.Drawing.Size(102, 22);
            this.textPDV25NE.Name = "textPDV25NE";
            this.textPDV25NE.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textPDV25NE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textPDV25NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPDV25NE, "");
            this.errorProviderValidator1.SetRequired(this.textPDV25NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPDV25NE, "");
            this.textPDV25NE.Size = new System.Drawing.Size(102, 22);
            this.textPDV25NE.TabIndex = 4;
            this.textPDV25NE.Tag = "PDV25NE";
            this.textPDV25NE.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textPDV25NE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1PDV25NE
            // 
            this.label1PDV25NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance33.ForeColor = System.Drawing.Color.Black;
            appearance33.TextVAlignAsString = "Middle";
            this.label1PDV25NE.Appearance = appearance33;
            this.label1PDV25NE.AutoSize = true;
            this.label1PDV25NE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PDV25NE, "");
            this.label1PDV25NE.Location = new System.Drawing.Point(3, 204);
            this.label1PDV25NE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PDV25NE.Name = "label1PDV25NE";
            this.errorProviderValidator1.SetRegularExpression(this.label1PDV25NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PDV25NE, "");
            this.errorProviderValidator1.SetRequired(this.label1PDV25NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PDV25NE, "");
            this.label1PDV25NE.Size = new System.Drawing.Size(150, 14);
            this.label1PDV25NE.StyleSetName = "FieldUltraLabel";
            this.label1PDV25NE.TabIndex = 4;
            this.label1PDV25NE.Tag = "labelPDV25NE";
            this.label1PDV25NE.Text = "PDV 25% Ne može se odbiti:";
            // 
            // pdv25
            // 
            this.errorProviderValidator1.SetDisplayName(this.pdv25, "");
            this.pdv25.Location = new System.Drawing.Point(161, 227);
            this.pdv25.Name = "pdv25";
            this.errorProviderValidator1.SetRegularExpression(this.pdv25, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.pdv25, "");
            this.errorProviderValidator1.SetRequired(this.pdv25, false);
            this.errorProviderValidator1.SetRequiredMessage(this.pdv25, "");
            this.pdv25.Size = new System.Drawing.Size(61, 23);
            this.pdv25.TabIndex = 5;
            this.pdv25.Text = "PDV 25";
            this.pdv25.UseVisualStyleBackColor = true;
            this.pdv25.Click += new System.EventHandler(this.pdv25_Click);
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance34.ForeColor = System.Drawing.Color.Black;
            appearance34.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance34;
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.ultraLabel4, "");
            this.ultraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel4.Location = new System.Drawing.Point(785, 88);
            this.ultraLabel4.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.ultraLabel4.Name = "ultraLabel4";
            this.errorProviderValidator1.SetRegularExpression(this.ultraLabel4, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.ultraLabel4, "");
            this.errorProviderValidator1.SetRequired(this.ultraLabel4, false);
            this.errorProviderValidator1.SetRequiredMessage(this.ultraLabel4, "");
            this.ultraLabel4.Size = new System.Drawing.Size(65, 17);
            this.ultraLabel4.StyleSetName = "FieldUltraLabel";
            this.ultraLabel4.TabIndex = 16;
            this.ultraLabel4.Tag = "labelOSNOVICA22";
            this.ultraLabel4.Text = "PDV 22%";
            this.ultraLabel4.Visible = false;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance27;
            this.ultraLabel5.AutoSize = true;
            this.ultraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.ultraLabel5, "");
            this.ultraLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel5.Location = new System.Drawing.Point(1048, 88);
            this.ultraLabel5.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.ultraLabel5.Name = "ultraLabel5";
            this.errorProviderValidator1.SetRegularExpression(this.ultraLabel5, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.ultraLabel5, "");
            this.errorProviderValidator1.SetRequired(this.ultraLabel5, false);
            this.errorProviderValidator1.SetRequiredMessage(this.ultraLabel5, "");
            this.ultraLabel5.Size = new System.Drawing.Size(65, 17);
            this.ultraLabel5.StyleSetName = "FieldUltraLabel";
            this.ultraLabel5.TabIndex = 17;
            this.ultraLabel5.Tag = "labelOSNOVICA23";
            this.ultraLabel5.Text = "PDV 23%";
            this.ultraLabel5.Visible = false;
            // 
            // label1OSNOVICA23
            // 
            this.label1OSNOVICA23.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Middle";
            this.label1OSNOVICA23.Appearance = appearance18;
            this.label1OSNOVICA23.AutoSize = true;
            this.label1OSNOVICA23.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSNOVICA23, "");
            this.label1OSNOVICA23.Location = new System.Drawing.Point(1048, 112);
            this.label1OSNOVICA23.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSNOVICA23.Name = "label1OSNOVICA23";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSNOVICA23, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSNOVICA23, "");
            this.errorProviderValidator1.SetRequired(this.label1OSNOVICA23, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSNOVICA23, "");
            this.label1OSNOVICA23.Size = new System.Drawing.Size(95, 14);
            this.label1OSNOVICA23.StyleSetName = "FieldUltraLabel";
            this.label1OSNOVICA23.TabIndex = 1;
            this.label1OSNOVICA23.Tag = "labelOSNOVICA23";
            this.label1OSNOVICA23.Text = "Osnovica za 23%:";
            this.label1OSNOVICA23.Visible = false;
            // 
            // label1OSNOVICA23NE
            // 
            this.label1OSNOVICA23NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.label1OSNOVICA23NE.Appearance = appearance19;
            this.label1OSNOVICA23NE.AutoSize = true;
            this.label1OSNOVICA23NE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSNOVICA23NE, "");
            this.label1OSNOVICA23NE.Location = new System.Drawing.Point(1048, 137);
            this.label1OSNOVICA23NE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSNOVICA23NE.Name = "label1OSNOVICA23NE";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSNOVICA23NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSNOVICA23NE, "");
            this.errorProviderValidator1.SetRequired(this.label1OSNOVICA23NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSNOVICA23NE, "");
            this.label1OSNOVICA23NE.Size = new System.Drawing.Size(147, 14);
            this.label1OSNOVICA23NE.StyleSetName = "FieldUltraLabel";
            this.label1OSNOVICA23NE.TabIndex = 1;
            this.label1OSNOVICA23NE.Tag = "labelOSNOVICA23NE";
            this.label1OSNOVICA23NE.Text = "Osnovica za 23% por. nepr.:";
            this.label1OSNOVICA23NE.Visible = false;
            // 
            // label1PDV23DA
            // 
            this.label1PDV23DA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.TextVAlignAsString = "Middle";
            this.label1PDV23DA.Appearance = appearance29;
            this.label1PDV23DA.AutoSize = true;
            this.label1PDV23DA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PDV23DA, "");
            this.label1PDV23DA.Location = new System.Drawing.Point(1048, 179);
            this.label1PDV23DA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PDV23DA.Name = "label1PDV23DA";
            this.errorProviderValidator1.SetRegularExpression(this.label1PDV23DA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PDV23DA, "");
            this.errorProviderValidator1.SetRequired(this.label1PDV23DA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PDV23DA, "");
            this.label1PDV23DA.Size = new System.Drawing.Size(132, 14);
            this.label1PDV23DA.StyleSetName = "FieldUltraLabel";
            this.label1PDV23DA.TabIndex = 1;
            this.label1PDV23DA.Tag = "labelPDV23DA";
            this.label1PDV23DA.Text = "PDV 23% Može se odbiti:";
            this.label1PDV23DA.Visible = false;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance13;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.ultraLabel1, "");
            this.ultraLabel1.Location = new System.Drawing.Point(3, 354);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.ultraLabel1.Name = "ultraLabel1";
            this.errorProviderValidator1.SetRegularExpression(this.ultraLabel1, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.ultraLabel1, "");
            this.errorProviderValidator1.SetRequired(this.ultraLabel1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.ultraLabel1, "");
            this.ultraLabel1.Size = new System.Drawing.Size(4, 14);
            this.ultraLabel1.StyleSetName = "FieldUltraLabel";
            this.ultraLabel1.TabIndex = 3;
            this.ultraLabel1.Tag = "";
            this.ultraLabel1.Text = "      ";
            // 
            // label1PDV23NE
            // 
            this.label1PDV23NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.TextVAlignAsString = "Middle";
            this.label1PDV23NE.Appearance = appearance28;
            this.label1PDV23NE.AutoSize = true;
            this.label1PDV23NE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PDV23NE, "");
            this.label1PDV23NE.Location = new System.Drawing.Point(1048, 204);
            this.label1PDV23NE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PDV23NE.Name = "label1PDV23NE";
            this.errorProviderValidator1.SetRegularExpression(this.label1PDV23NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PDV23NE, "");
            this.errorProviderValidator1.SetRequired(this.label1PDV23NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PDV23NE, "");
            this.label1PDV23NE.Size = new System.Drawing.Size(150, 14);
            this.label1PDV23NE.StyleSetName = "FieldUltraLabel";
            this.label1PDV23NE.TabIndex = 1;
            this.label1PDV23NE.Tag = "labelPDV23NE";
            this.label1PDV23NE.Text = "PDV 23% Ne može se odbiti:";
            this.label1PDV23NE.Visible = false;
            // 
            // textOSNOVICA23
            //// 
            this.textOSNOVICA23.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSNOVICA23.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "OSNOVICA23", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSNOVICA23, "");
            this.textOSNOVICA23.Location = new System.Drawing.Point(1203, 108);
            this.textOSNOVICA23.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSNOVICA23.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSNOVICA23.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSNOVICA23.Name = "textOSNOVICA23";
            this.textOSNOVICA23.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSNOVICA23.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSNOVICA23, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSNOVICA23, "");
            this.errorProviderValidator1.SetRequired(this.textOSNOVICA23, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSNOVICA23, "");
            this.textOSNOVICA23.Size = new System.Drawing.Size(102, 22);
            this.textOSNOVICA23.TabIndex = 21;
            this.textOSNOVICA23.Tag = "OSNOVICA23";
            this.textOSNOVICA23.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOSNOVICA23.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.textOSNOVICA23.Visible = false;
            // 
            // textOSNOVICA23NE
            // 
            this.textOSNOVICA23NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSNOVICA23NE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "OSNOVICA23NE", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSNOVICA23NE, "");
            this.textOSNOVICA23NE.Location = new System.Drawing.Point(1203, 133);
            this.textOSNOVICA23NE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSNOVICA23NE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSNOVICA23NE.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSNOVICA23NE.Name = "textOSNOVICA23NE";
            this.textOSNOVICA23NE.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSNOVICA23NE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSNOVICA23NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSNOVICA23NE, "");
            this.errorProviderValidator1.SetRequired(this.textOSNOVICA23NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSNOVICA23NE, "");
            this.textOSNOVICA23NE.Size = new System.Drawing.Size(102, 22);
            this.textOSNOVICA23NE.TabIndex = 22;
            this.textOSNOVICA23NE.Tag = "OSNOVICA23NE";
            this.textOSNOVICA23NE.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOSNOVICA23NE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.textOSNOVICA23NE.Visible = false;
            // 
            // textPDV23DA
            //// 
            this.textPDV23DA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPDV23DA.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "PDV23DA", true));
            this.errorProviderValidator1.SetDisplayName(this.textPDV23DA, "");
            this.textPDV23DA.Location = new System.Drawing.Point(1203, 175);
            this.textPDV23DA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPDV23DA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPDV23DA.MinimumSize = new System.Drawing.Size(102, 22);
            this.textPDV23DA.Name = "textPDV23DA";
            this.textPDV23DA.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textPDV23DA.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textPDV23DA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPDV23DA, "");
            this.errorProviderValidator1.SetRequired(this.textPDV23DA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPDV23DA, "");
            this.textPDV23DA.Size = new System.Drawing.Size(102, 22);
            this.textPDV23DA.TabIndex = 23;
            this.textPDV23DA.Tag = "PDV23DA";
            this.textPDV23DA.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textPDV23DA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.textPDV23DA.Visible = false;
            // 
            // textPDV23NE
            // 
            this.textPDV23NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPDV23NE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "PDV23NE", true));
            this.errorProviderValidator1.SetDisplayName(this.textPDV23NE, "");
            this.textPDV23NE.Location = new System.Drawing.Point(1203, 200);
            this.textPDV23NE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPDV23NE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPDV23NE.MinimumSize = new System.Drawing.Size(102, 22);
            this.textPDV23NE.Name = "textPDV23NE";
            this.textPDV23NE.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textPDV23NE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textPDV23NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPDV23NE, "");
            this.errorProviderValidator1.SetRequired(this.textPDV23NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPDV23NE, "");
            this.textPDV23NE.Size = new System.Drawing.Size(102, 22);
            this.textPDV23NE.TabIndex = 24;
            this.textPDV23NE.Tag = "PDV23NE";
            this.textPDV23NE.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textPDV23NE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.textPDV23NE.Visible = false;
            // 
            // pdv23
            // 
            //this.errorProviderValidator1.SetDisplayName(this.pdv23, "");
            //this.pdv23.Location = new System.Drawing.Point(1206, 227);
            //this.pdv23.Name = "pdv23";
            //this.errorProviderValidator1.SetRegularExpression(this.pdv23, "");
            //this.errorProviderValidator1.SetRegularExpressionMessage(this.pdv23, "");
            //this.errorProviderValidator1.SetRequired(this.pdv23, false);
            //this.errorProviderValidator1.SetRequiredMessage(this.pdv23, "");
            //this.pdv23.Size = new System.Drawing.Size(61, 23);
            //this.pdv23.TabIndex = 25;
            //this.pdv23.Text = "PDV 23";
            //this.pdv23.UseVisualStyleBackColor = true;
            //this.pdv23.Click += new System.EventHandler(this.pdv23_Click);
            //this.pdv23.Visible = false;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance40.ForeColor = System.Drawing.Color.Black;
            appearance40.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance40;
            this.ultraLabel2.AutoSize = true;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.ultraLabel2, "");
            this.ultraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel2.Location = new System.Drawing.Point(522, 88);
            this.ultraLabel2.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.ultraLabel2.Name = "ultraLabel2";
            this.errorProviderValidator1.SetRegularExpression(this.ultraLabel2, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.ultraLabel2, "");
            this.errorProviderValidator1.SetRequired(this.ultraLabel2, false);
            this.errorProviderValidator1.SetRequiredMessage(this.ultraLabel2, "");
            this.ultraLabel2.Size = new System.Drawing.Size(65, 17);
            this.ultraLabel2.StyleSetName = "FieldUltraLabel";
            this.ultraLabel2.TabIndex = 14;
            this.ultraLabel2.Tag = "labelOSNOVICA10";
            this.ultraLabel2.Text = "PDV 13%";
            // 
            // label1OSNOVICA10
            // 
            this.label1OSNOVICA10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance41.ForeColor = System.Drawing.Color.Black;
            appearance41.TextVAlignAsString = "Middle";
            this.label1OSNOVICA10.Appearance = appearance41;
            this.label1OSNOVICA10.AutoSize = true;
            this.label1OSNOVICA10.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSNOVICA10, "");
            this.label1OSNOVICA10.Location = new System.Drawing.Point(522, 112);
            this.label1OSNOVICA10.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSNOVICA10.Name = "label1OSNOVICA10";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSNOVICA10, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSNOVICA10, "");
            this.errorProviderValidator1.SetRequired(this.label1OSNOVICA10, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSNOVICA10, "");
            this.label1OSNOVICA10.Size = new System.Drawing.Size(95, 14);
            this.label1OSNOVICA10.StyleSetName = "FieldUltraLabel";
            this.label1OSNOVICA10.TabIndex = 1;
            this.label1OSNOVICA10.Tag = "labelOSNOVICA10";
            this.label1OSNOVICA10.Text = "Osnovica za 13%:";
            // 
            // textOSNOVICA10
            // 
            this.textOSNOVICA10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSNOVICA10.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "OSNOVICA10", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSNOVICA10, "");
            this.textOSNOVICA10.Location = new System.Drawing.Point(677, 108);
            this.textOSNOVICA10.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSNOVICA10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSNOVICA10.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSNOVICA10.Name = "textOSNOVICA10";
            this.textOSNOVICA10.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSNOVICA10.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSNOVICA10, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSNOVICA10, "");
            this.errorProviderValidator1.SetRequired(this.textOSNOVICA10, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSNOVICA10, "");
            this.textOSNOVICA10.Size = new System.Drawing.Size(102, 22);
            this.textOSNOVICA10.TabIndex = 11;
            this.textOSNOVICA10.Tag = "OSNOVICA10";
            this.textOSNOVICA10.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOSNOVICA10.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1OSNOVICA10NE
            // 
            this.label1OSNOVICA10NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance42.ForeColor = System.Drawing.Color.Black;
            appearance42.TextVAlignAsString = "Middle";
            this.label1OSNOVICA10NE.Appearance = appearance42;
            this.label1OSNOVICA10NE.AutoSize = true;
            this.label1OSNOVICA10NE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSNOVICA10NE, "");
            this.label1OSNOVICA10NE.Location = new System.Drawing.Point(522, 137);
            this.label1OSNOVICA10NE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSNOVICA10NE.Name = "label1OSNOVICA10NE";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSNOVICA10NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSNOVICA10NE, "");
            this.errorProviderValidator1.SetRequired(this.label1OSNOVICA10NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSNOVICA10NE, "");
            this.label1OSNOVICA10NE.Size = new System.Drawing.Size(147, 14);
            this.label1OSNOVICA10NE.StyleSetName = "FieldUltraLabel";
            this.label1OSNOVICA10NE.TabIndex = 1;
            this.label1OSNOVICA10NE.Tag = "labelOSNOVICA10NE";
            this.label1OSNOVICA10NE.Text = "Osnovica za 13% por. nepr.:";
            // 
            // textOSNOVICA10NE
            // 
            this.textOSNOVICA10NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSNOVICA10NE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "OSNOVICA10NE", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSNOVICA10NE, "");
            this.textOSNOVICA10NE.Location = new System.Drawing.Point(677, 133);
            this.textOSNOVICA10NE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSNOVICA10NE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSNOVICA10NE.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSNOVICA10NE.Name = "textOSNOVICA10NE";
            this.textOSNOVICA10NE.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSNOVICA10NE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSNOVICA10NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSNOVICA10NE, "");
            this.errorProviderValidator1.SetRequired(this.textOSNOVICA10NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSNOVICA10NE, "");
            this.textOSNOVICA10NE.Size = new System.Drawing.Size(102, 22);
            this.textOSNOVICA10NE.TabIndex = 12;
            this.textOSNOVICA10NE.Tag = "OSNOVICA10NE";
            this.textOSNOVICA10NE.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOSNOVICA10NE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1PDV10DA
            // 
            this.label1PDV10DA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.label1PDV10DA.Appearance = appearance12;
            this.label1PDV10DA.AutoSize = true;
            this.label1PDV10DA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PDV10DA, "");
            this.label1PDV10DA.Location = new System.Drawing.Point(522, 179);
            this.label1PDV10DA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PDV10DA.Name = "label1PDV10DA";
            this.errorProviderValidator1.SetRegularExpression(this.label1PDV10DA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PDV10DA, "");
            this.errorProviderValidator1.SetRequired(this.label1PDV10DA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PDV10DA, "");
            this.label1PDV10DA.Size = new System.Drawing.Size(132, 14);
            this.label1PDV10DA.StyleSetName = "FieldUltraLabel";
            this.label1PDV10DA.TabIndex = 1;
            this.label1PDV10DA.Tag = "labelPDV10DA";
            this.label1PDV10DA.Text = "PDV 13% Može se odbiti:";
            // 
            // textPDV10DA
            // 
            this.textPDV10DA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPDV10DA.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "PDV10DA", true));
            this.errorProviderValidator1.SetDisplayName(this.textPDV10DA, "");
            this.textPDV10DA.Location = new System.Drawing.Point(677, 175);
            this.textPDV10DA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPDV10DA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPDV10DA.MinimumSize = new System.Drawing.Size(102, 22);
            this.textPDV10DA.Name = "textPDV10DA";
            this.textPDV10DA.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textPDV10DA.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textPDV10DA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPDV10DA, "");
            this.errorProviderValidator1.SetRequired(this.textPDV10DA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPDV10DA, "");
            this.textPDV10DA.Size = new System.Drawing.Size(102, 22);
            this.textPDV10DA.TabIndex = 13;
            this.textPDV10DA.Tag = "PDV10DA";
            this.textPDV10DA.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textPDV10DA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1PDV10NE
            // 
            this.label1PDV10NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextVAlignAsString = "Middle";
            this.label1PDV10NE.Appearance = appearance16;
            this.label1PDV10NE.AutoSize = true;
            this.label1PDV10NE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PDV10NE, "");
            this.label1PDV10NE.Location = new System.Drawing.Point(522, 204);
            this.label1PDV10NE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PDV10NE.Name = "label1PDV10NE";
            this.errorProviderValidator1.SetRegularExpression(this.label1PDV10NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PDV10NE, "");
            this.errorProviderValidator1.SetRequired(this.label1PDV10NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PDV10NE, "");
            this.label1PDV10NE.Size = new System.Drawing.Size(150, 14);
            this.label1PDV10NE.StyleSetName = "FieldUltraLabel";
            this.label1PDV10NE.TabIndex = 1;
            this.label1PDV10NE.Tag = "labelPDV10NE";
            this.label1PDV10NE.Text = "PDV 13% Ne može se odbiti:";
            // 
            // textPDV10NE
            // 
            this.textPDV10NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPDV10NE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "PDV10NE", true));
            this.errorProviderValidator1.SetDisplayName(this.textPDV10NE, "");
            this.textPDV10NE.Location = new System.Drawing.Point(677, 200);
            this.textPDV10NE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPDV10NE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPDV10NE.MinimumSize = new System.Drawing.Size(102, 22);
            this.textPDV10NE.Name = "textPDV10NE";
            this.textPDV10NE.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textPDV10NE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textPDV10NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPDV10NE, "");
            this.errorProviderValidator1.SetRequired(this.textPDV10NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPDV10NE, "");
            this.textPDV10NE.Size = new System.Drawing.Size(102, 22);
            this.textPDV10NE.TabIndex = 14;
            this.textPDV10NE.Tag = "PDV10NE";
            this.textPDV10NE.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textPDV10NE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // pdv10
            // 
            this.errorProviderValidator1.SetDisplayName(this.pdv10, "");
            this.pdv10.Location = new System.Drawing.Point(680, 227);
            this.pdv10.Name = "pdv10";
            this.errorProviderValidator1.SetRegularExpression(this.pdv10, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.pdv10, "");
            this.errorProviderValidator1.SetRequired(this.pdv10, false);
            this.errorProviderValidator1.SetRequiredMessage(this.pdv10, "");
            this.pdv10.Size = new System.Drawing.Size(61, 23);
            this.pdv10.TabIndex = 15;
            this.pdv10.Text = "PDV 13";
            this.pdv10.UseVisualStyleBackColor = true;
            this.pdv10.Click += new System.EventHandler(this.pdv10_Click);
            // 
            // ultraLabel9
            // 
            this.ultraLabel9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance37.ForeColor = System.Drawing.Color.Black;
            appearance37.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance37;
            this.ultraLabel9.AutoSize = true;
            this.ultraLabel9.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.ultraLabel9, "");
            this.ultraLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel9.Location = new System.Drawing.Point(266, 88);
            this.ultraLabel9.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.ultraLabel9.Name = "ultraLabel9";
            this.errorProviderValidator1.SetRegularExpression(this.ultraLabel9, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.ultraLabel9, "");
            this.errorProviderValidator1.SetRequired(this.ultraLabel9, false);
            this.errorProviderValidator1.SetRequiredMessage(this.ultraLabel9, "");
            this.ultraLabel9.Size = new System.Drawing.Size(57, 17);
            this.ultraLabel9.StyleSetName = "FieldUltraLabel";
            this.ultraLabel9.TabIndex = 20;
            this.ultraLabel9.Tag = "labelOSNOVICA5";
            this.ultraLabel9.Text = "PDV 5%";
            // 
            // label1OSNOVICA5
            // 
            this.label1OSNOVICA5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextVAlignAsString = "Middle";
            this.label1OSNOVICA5.Appearance = appearance20;
            this.label1OSNOVICA5.AutoSize = true;
            this.label1OSNOVICA5.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSNOVICA5, "");
            this.label1OSNOVICA5.Location = new System.Drawing.Point(266, 112);
            this.label1OSNOVICA5.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSNOVICA5.Name = "label1OSNOVICA5";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSNOVICA5, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSNOVICA5, "");
            this.errorProviderValidator1.SetRequired(this.label1OSNOVICA5, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSNOVICA5, "");
            this.label1OSNOVICA5.Size = new System.Drawing.Size(89, 14);
            this.label1OSNOVICA5.StyleSetName = "FieldUltraLabel";
            this.label1OSNOVICA5.TabIndex = 21;
            this.label1OSNOVICA5.Tag = "labelOSNOVICA5";
            this.label1OSNOVICA5.Text = "Osnovica za 5%:";
            // 
            // label1OSNOVICA5NE
            // 
            this.label1OSNOVICA5NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextVAlignAsString = "Middle";
            this.label1OSNOVICA5NE.Appearance = appearance14;
            this.label1OSNOVICA5NE.AutoSize = true;
            this.label1OSNOVICA5NE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSNOVICA5NE, "");
            this.label1OSNOVICA5NE.Location = new System.Drawing.Point(266, 137);
            this.label1OSNOVICA5NE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSNOVICA5NE.Name = "label1OSNOVICA5NE";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSNOVICA5NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSNOVICA5NE, "");
            this.errorProviderValidator1.SetRequired(this.label1OSNOVICA5NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSNOVICA5NE, "");
            this.label1OSNOVICA5NE.Size = new System.Drawing.Size(140, 14);
            this.label1OSNOVICA5NE.StyleSetName = "FieldUltraLabel";
            this.label1OSNOVICA5NE.TabIndex = 22;
            this.label1OSNOVICA5NE.Tag = "labelOSNOVICA5NE";
            this.label1OSNOVICA5NE.Text = "Osnovica za 5% por. nepr.:";
            // 
            // textOSNOVICA5
            // 
            this.textOSNOVICA5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSNOVICA5.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "OSNOVICA5", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSNOVICA5, "");
            this.textOSNOVICA5.Location = new System.Drawing.Point(414, 108);
            this.textOSNOVICA5.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSNOVICA5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSNOVICA5.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSNOVICA5.Name = "textOSNOVICA5";
            this.textOSNOVICA5.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSNOVICA5.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSNOVICA5, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSNOVICA5, "");
            this.errorProviderValidator1.SetRequired(this.textOSNOVICA5, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSNOVICA5, "");
            this.textOSNOVICA5.Size = new System.Drawing.Size(102, 22);
            this.textOSNOVICA5.TabIndex = 6;
            this.textOSNOVICA5.Tag = "OSNOVICA5";
            // 
            // textOSNOVICA5NE
            // 
            this.textOSNOVICA5NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSNOVICA5NE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "OSNOVICA5NE", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSNOVICA5NE, "");
            this.textOSNOVICA5NE.Location = new System.Drawing.Point(414, 133);
            this.textOSNOVICA5NE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSNOVICA5NE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSNOVICA5NE.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSNOVICA5NE.Name = "textOSNOVICA5NE";
            this.textOSNOVICA5NE.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSNOVICA5NE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSNOVICA5NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSNOVICA5NE, "");
            this.errorProviderValidator1.SetRequired(this.textOSNOVICA5NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSNOVICA5NE, "");
            this.textOSNOVICA5NE.Size = new System.Drawing.Size(102, 22);
            this.textOSNOVICA5NE.TabIndex = 7;
            this.textOSNOVICA5NE.Tag = "OSNOVICA5NE";
            // 
            // label1PDV5DA
            // 
            this.label1PDV5DA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextVAlignAsString = "Middle";
            this.label1PDV5DA.Appearance = appearance15;
            this.label1PDV5DA.AutoSize = true;
            this.label1PDV5DA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PDV5DA, "");
            this.label1PDV5DA.Location = new System.Drawing.Point(266, 179);
            this.label1PDV5DA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PDV5DA.Name = "label1PDV5DA";
            this.errorProviderValidator1.SetRegularExpression(this.label1PDV5DA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PDV5DA, "");
            this.errorProviderValidator1.SetRequired(this.label1PDV5DA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PDV5DA, "");
            this.label1PDV5DA.Size = new System.Drawing.Size(126, 14);
            this.label1PDV5DA.StyleSetName = "FieldUltraLabel";
            this.label1PDV5DA.TabIndex = 25;
            this.label1PDV5DA.Tag = "labelPDV5DA";
            this.label1PDV5DA.Text = "PDV 5% Može se odbiti:";
            // 
            // label1PDV5NE
            // 
            this.label1PDV5NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance35.ForeColor = System.Drawing.Color.Black;
            appearance35.TextVAlignAsString = "Middle";
            this.label1PDV5NE.Appearance = appearance35;
            this.label1PDV5NE.AutoSize = true;
            this.label1PDV5NE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PDV5NE, "");
            this.label1PDV5NE.Location = new System.Drawing.Point(266, 204);
            this.label1PDV5NE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PDV5NE.Name = "label1PDV5NE";
            this.errorProviderValidator1.SetRegularExpression(this.label1PDV5NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PDV5NE, "");
            this.errorProviderValidator1.SetRequired(this.label1PDV5NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PDV5NE, "");
            this.label1PDV5NE.Size = new System.Drawing.Size(143, 14);
            this.label1PDV5NE.StyleSetName = "FieldUltraLabel";
            this.label1PDV5NE.TabIndex = 26;
            this.label1PDV5NE.Tag = "labelPDV5NE";
            this.label1PDV5NE.Text = "PDV 5% Ne može se odbiti:";
            // 
            // pdv5
            // 
            this.errorProviderValidator1.SetDisplayName(this.pdv5, "");
            this.pdv5.Location = new System.Drawing.Point(417, 227);
            this.pdv5.Name = "pdv5";
            this.errorProviderValidator1.SetRegularExpression(this.pdv5, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.pdv5, "");
            this.errorProviderValidator1.SetRequired(this.pdv5, false);
            this.errorProviderValidator1.SetRequiredMessage(this.pdv5, "");
            this.pdv5.Size = new System.Drawing.Size(61, 23);
            this.pdv5.TabIndex = 10;
            this.pdv5.Text = "PDV 5";
            this.pdv5.UseVisualStyleBackColor = true;
            this.pdv5.Click += new System.EventHandler(this.pdv5_Click);
            // 
            // textPDV5DA
            // 
            this.textPDV5DA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPDV5DA.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "PDV5DA", true));
            this.errorProviderValidator1.SetDisplayName(this.textPDV5DA, "");
            this.textPDV5DA.Location = new System.Drawing.Point(414, 175);
            this.textPDV5DA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPDV5DA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPDV5DA.MinimumSize = new System.Drawing.Size(102, 22);
            this.textPDV5DA.Name = "textPDV5DA";
            this.textPDV5DA.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textPDV5DA.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textPDV5DA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPDV5DA, "");
            this.errorProviderValidator1.SetRequired(this.textPDV5DA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPDV5DA, "");
            this.textPDV5DA.Size = new System.Drawing.Size(102, 22);
            this.textPDV5DA.TabIndex = 8;
            this.textPDV5DA.Tag = "PDV10DA";
            // 
            // textPDV5NE
            // 
            this.textPDV5NE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPDV5NE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceURA, "PDV5NE", true));
            this.errorProviderValidator1.SetDisplayName(this.textPDV5NE, "");
            this.textPDV5NE.Location = new System.Drawing.Point(414, 200);
            this.textPDV5NE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPDV5NE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPDV5NE.MinimumSize = new System.Drawing.Size(102, 22);
            this.textPDV5NE.Name = "textPDV5NE";
            this.textPDV5NE.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textPDV5NE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textPDV5NE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPDV5NE, "");
            this.errorProviderValidator1.SetRequired(this.textPDV5NE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPDV5NE, "");
            this.textPDV5NE.Size = new System.Drawing.Size(102, 22);
            this.textPDV5NE.TabIndex = 9;
            this.textPDV5NE.Tag = "PDV10NE";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.bindingSourceURA;
            // 
            // errorProviderValidator1
            // 
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.errorProviderValidator1.ToolTipProvider = null;
            // 
            // layoutManagerformURA
            // 
            this.layoutManagerformURA.AutoSize = true;
            this.layoutManagerformURA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerformURA.ColumnCount = 1;
            this.layoutManagerformURA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformURA.Controls.Add(this.Tab1, 0, 0);
            this.layoutManagerformURA.Controls.Add(this.UserDefinedControl1, 0, 1);
            this.errorProviderValidator1.SetDisplayName(this.layoutManagerformURA, "");
            this.layoutManagerformURA.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerformURA.Name = "layoutManagerformURA";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerformURA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerformURA, "");
            this.errorProviderValidator1.SetRequired(this.layoutManagerformURA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerformURA, "");
            this.layoutManagerformURA.RowCount = 2;
            this.layoutManagerformURA.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformURA.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformURA.Size = new System.Drawing.Size(1377, 492);
            this.layoutManagerformURA.TabIndex = 0;
            // 
            // Tab1
            // 
            this.Tab1.Controls.Add(this.TabPage1);
            this.Tab1.Controls.Add(this.TabPage2);
            #region MBS.Complete 26.04.2016
            this.Tab1.Controls.Add(this.TabPage3);
            #endregion

            this.errorProviderValidator1.SetDisplayName(this.Tab1, "");
            this.Tab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab1.Location = new System.Drawing.Point(5, 11);
            this.Tab1.Margin = new System.Windows.Forms.Padding(5, 11, 5, 5);
            this.Tab1.Name = "Tab1";
            this.errorProviderValidator1.SetRegularExpression(this.Tab1, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.Tab1, "");
            this.errorProviderValidator1.SetRequired(this.Tab1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.Tab1, "");
            this.Tab1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.Tab1.Size = new System.Drawing.Size(1367, 476);
            this.Tab1.TabIndex = 0;
            tab.TabPage = this.TabPage1;
            tab.Text = "Osnovni podaci";
            tab2.TabPage = this.TabPage2;
            tab2.Text = "PDV";
            #region MBS.Complete 26.04.2016
            tab3.TabPage = this.TabPage3;
            tab3.Text = "Prenesena porezna obveza";
            #endregion
            this.Tab1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            tab,
            tab2,
            tab3});
            // 
            // ultraTabSharedControlsPage1
            // 
            this.errorProviderValidator1.SetDisplayName(this.ultraTabSharedControlsPage1, "");
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.errorProviderValidator1.SetRegularExpression(this.ultraTabSharedControlsPage1, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.ultraTabSharedControlsPage1, "");
            this.errorProviderValidator1.SetRequired(this.ultraTabSharedControlsPage1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.ultraTabSharedControlsPage1, "");
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(1363, 450);
            // 
            // UserDefinedControl1
            // 
            this.errorProviderValidator1.SetDisplayName(this.UserDefinedControl1, "");
            this.UserDefinedControl1.Location = new System.Drawing.Point(0, 0);
            this.UserDefinedControl1.Margin = new System.Windows.Forms.Padding(2);
            this.UserDefinedControl1.MinimumSize = new System.Drawing.Size(4, 4);
            this.UserDefinedControl1.Name = "UserDefinedControl1";
            this.errorProviderValidator1.SetRegularExpression(this.UserDefinedControl1, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.UserDefinedControl1, "");
            this.errorProviderValidator1.SetRequired(this.UserDefinedControl1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.UserDefinedControl1, "");
            this.UserDefinedControl1.Size = new System.Drawing.Size(1261, 381);
            this.UserDefinedControl1.TabIndex = 0;
            this.UserDefinedControl1.UraControlerfORM = null;
            // 
            // URAFormUserControl
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.layoutManagerformURA);
            this.errorProviderValidator1.SetDisplayName(this, "");
            this.Name = "URAFormUserControl";
            this.errorProviderValidator1.SetRegularExpression(this, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this, "");
            this.errorProviderValidator1.SetRequired(this, false);
            this.errorProviderValidator1.SetRequiredMessage(this, "");
            this.Size = new System.Drawing.Size(1380, 495);
            this.Load += new System.EventHandler(this.URAFormUserControl_Load);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.layoutManagerTabPage1.ResumeLayout(false);
            this.layoutManagerTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textURAGODIDGODINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceURA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsURADataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textURABROJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textURABROJRACUNADOBAVLJACA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePickerURADATUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePickerURAVALUTA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textURANAPOMENA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textURAMODEL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textURAPOZIVNABROJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textURAUKUPNO)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.layoutManagerTabPage2.ResumeLayout(false);
            this.layoutManagerTabPage2.PerformLayout();
            
            #region MBS.Complete 26.04.2016
            this.TabPage3.ResumeLayout(false);
            this.layoutManagerTabPage3.ResumeLayout(false);
            this.layoutManagerTabPage3.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(this.txtMoze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNeMoze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOsnovica)).EndInit();
            #endregion
            
            ((System.ComponentModel.ISupportInitialize)(this.textIDTIPURA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA22NE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV22NE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV22DA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA25NE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV25DA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV25NE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA23NE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV23DA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV23NE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA10NE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV10DA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV10NE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSNOVICA5NE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV5DA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV5NE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.layoutManagerformURA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tab1)).EndInit();
            this.Tab1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool InValidState()
        {
            if ((this.URAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceURA, this.URAController.WorkItem, this))
            {
                return false;
            }
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedURADOKIDDOKUMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("DOKUMENT", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedurapartnerIDPARTNER(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("PARTNER", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.URAController.WorkItem.Items.Contains("URA|URA"))
            {
                this.URAController.WorkItem.Items.Add(this.bindingSourceURA, "URA|URA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
            // MATIJA
            this.URAController.WorkItem.Items.Add(this.UserDefinedControl1);
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsURADataSet1.URA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.Mode;
                this.m_BaseMethods.FormLoadStyle();
                this.textURAGODIDGODINE.ButtonsRight[0].Visible = false;
            }
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.URAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.URAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.URAController.Update(this))
            {
                this.URAController.DataSet = new URADataSet();
                DataSetUtil.AddEmptyRow(this.URAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.URAController.DataSet.URA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedURADOKIDDOKUMENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboURADOKIDDOKUMENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboURADOKIDDOKUMENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceURA.Current).Row["URADOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(row["IDDOKUMENT"]);
                    this.bindingSourceURA.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedurapartnerIDPARTNER(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.combourapartnerIDPARTNER.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.combourapartnerIDPARTNER.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceURA.Current).Row["urapartnerIDPARTNER"] = RuntimeHelpers.GetObjectValue(row["IDPARTNER"]);
                    this.bindingSourceURA.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.textURAGODIDGODINE.Focus();
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

        private void UpdateValuesGODINEURAGODIDGODINE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceURA.Current).Row["URAGODIDGODINE"] = RuntimeHelpers.GetObjectValue(result["IDGODINE"]);
                this.bindingSourceURA.ResetCurrentItem();
            }
        }

        private void UpdateValuesTIPURAIDTIPURA(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceURA.Current).Row["IDTIPURA"] = RuntimeHelpers.GetObjectValue(result["IDTIPURA"]);
                this.bindingSourceURA.ResetCurrentItem();
            }
        }

        private void URAFormUserControl_GotFocus(object sender, EventArgs e)
        {
        }

        private void URAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.URADescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void URAFormUserControl_Load1(object sender, EventArgs e)
        {
            if (this.Mode == DeklaritMode.Insert)
            {
                ((UltraCheckEditor) this.URAController.URAFormDefinition.GetControl("checkR2")).Visible = true;
                ((UltraCheckEditor) this.URAController.URAFormDefinition.GetControl("checkR2")).Enabled = true;
                ((UltraLabel) this.URAController.URAFormDefinition.GetControl("label1R2")).Visible = true;
            }
            else
            {
                ((UltraCheckEditor) this.URAController.URAFormDefinition.GetControl("checkR2")).Visible = true;
                ((UltraCheckEditor) this.URAController.URAFormDefinition.GetControl("checkR2")).Enabled = true;
                ((UltraLabel) this.URAController.URAFormDefinition.GetControl("label1R2")).Visible = true;
            }
        }

        private void pdv5_Click(object sender, EventArgs e)
        {
            decimal osnovica_5, osnovica_5_NE, pdv_5_DA, pdv_5_NE;

            try { osnovica_5 = Convert.ToDecimal(this.textOSNOVICA5.Value); }
            catch (Exception) { osnovica_5 = 0; }

            try { osnovica_5_NE = Convert.ToDecimal(this.textOSNOVICA5NE.Value); }
            catch (Exception) { osnovica_5_NE = 0; }

            try { pdv_5_DA = Convert.ToDecimal(this.textPDV5DA.Value); }
            catch (Exception) { pdv_5_DA = 0; }

            try { pdv_5_NE = Convert.ToDecimal(this.textPDV5NE.Value); }
            catch (Exception) { pdv_5_NE = 0; }

            pdv_5_DA = osnovica_5 * 0.05M;
            pdv_5_NE = osnovica_5_NE * 0.05M;

            // ---------------------------------------------------
            this.textOSNOVICA5.Value = osnovica_5;
            this.textOSNOVICA5NE.Value = osnovica_5_NE;
            this.textPDV5DA.Value = pdv_5_DA;
            this.textPDV5NE.Value = pdv_5_NE;

            #region MBS.Complete
            KORISNIKDataSet dsKorisnik = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dsKorisnik);

            DataRow korisnik = dsKorisnik.Tables["KORISNIK"].Rows[0];

            decimal predporez = 0;
            decimal izracun = 0;
            if (korisnik["OBVEZNIKPDVA"].ToString() == "True")
            {
                try
                {
                    predporez = Convert.ToDecimal(korisnik["Predporez"]);
                }
                catch { predporez = 0; }

                if (predporez > 0)
                {
                    izracun = pdv_5_DA * predporez / 100;
                    this.textPDV5DA.Value = izracun;
                    this.textPDV5NE.Value = pdv_5_DA - izracun;
                }
                else
                {
                    this.textPDV5DA.Value = pdv_5_NE;
                    this.textPDV5NE.Value = pdv_5_DA;
                }
            }
            #endregion
        }

        private void pdv10_Click(object sender, EventArgs e)
        {
            decimal osnovica_10, osnovica_10_NE, pdv_10_DA, pdv_10_NE;

            try { osnovica_10 = Convert.ToDecimal(this.textOSNOVICA10.Value); }
            catch (Exception) { osnovica_10 = 0; }

            try { osnovica_10_NE = Convert.ToDecimal(this.textOSNOVICA10NE.Value); }
            catch (Exception) { osnovica_10_NE = 0; }

            try { pdv_10_DA = Convert.ToDecimal(this.textPDV10DA.Value); }
            catch (Exception) { pdv_10_DA = 0; }

            try { pdv_10_NE = Convert.ToDecimal(this.textPDV10NE.Value); }
            catch (Exception) { pdv_10_NE = 0; }

            pdv_10_DA = osnovica_10 * 0.13M;
            pdv_10_NE = osnovica_10_NE * 0.13M;

            // ---------------------------------------------------
            this.textOSNOVICA10.Value = osnovica_10;
            this.textOSNOVICA10NE.Value = osnovica_10_NE;
            this.textPDV10DA.Value = pdv_10_DA;
            this.textPDV10NE.Value = pdv_10_NE;

            #region MBS.Complete
            KORISNIKDataSet dsKorisnik = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dsKorisnik);

            DataRow korisnik = dsKorisnik.Tables["KORISNIK"].Rows[0];

            decimal predporez = 0;
            decimal izracun = 0;
            if (korisnik["OBVEZNIKPDVA"].ToString() == "True")
            {
                try
                {
                    predporez = Convert.ToDecimal(korisnik["Predporez"]);
                }
                catch { predporez = 0; }

                if (predporez > 0)
                {
                    izracun = pdv_10_DA * predporez / 100;
                    this.textPDV10DA.Value = izracun;
                    this.textPDV10NE.Value = pdv_10_DA - izracun;
                }
                else
                {
                    this.textPDV10DA.Value = pdv_10_NE;
                    this.textPDV10NE.Value = pdv_10_DA;
                }
            }
            #endregion
        }

        private void pdv22_Click(object sender, EventArgs e)
        {
            decimal osnovica_22, osnovica_22_NE, pdv_22_DA, pdv_22_NE;

            try { osnovica_22 = Convert.ToDecimal(this.textOSNOVICA22.Value); }
            catch (Exception) { osnovica_22 = 0; }

            try { osnovica_22_NE = Convert.ToDecimal(this.textOSNOVICA22NE.Value); }
            catch (Exception) { osnovica_22_NE = 0; }

            try { pdv_22_DA = Convert.ToDecimal(this.textPDV22DA.Value); }
            catch (Exception) { pdv_22_DA = 0; }

            try { pdv_22_NE = Convert.ToDecimal(this.textPDV22NE.Value); }
            catch (Exception) { pdv_22_NE = 0; }

            pdv_22_DA = osnovica_22 * 0.22M;
            pdv_22_NE = osnovica_22_NE * 0.22M;

            //// ---------------------------------------------------
            this.textOSNOVICA22.Value = osnovica_22;
            this.textOSNOVICA22NE.Value = osnovica_22_NE;
            this.textPDV22DA.Value = pdv_22_DA;
            this.textPDV22NE.Value = pdv_22_NE;
        }

        private void pdv23_Click(object sender, EventArgs e)
        {
            decimal osnovica_23, osnovica_23_NE, pdv_23_DA, pdv_23_NE;

            try { osnovica_23 = Convert.ToDecimal(this.textOSNOVICA23.Value); }
            catch (Exception) { osnovica_23 = 0; }

            try { osnovica_23_NE = Convert.ToDecimal(this.textOSNOVICA23NE.Value); }
            catch (Exception) { osnovica_23_NE = 0; }

            try { pdv_23_DA = Convert.ToDecimal(this.textPDV23DA.Value); }
            catch (Exception) { pdv_23_DA = 0; }

            try { pdv_23_NE = Convert.ToDecimal(this.textPDV23NE.Value); }
            catch (Exception) { pdv_23_NE = 0; }

            pdv_23_DA = osnovica_23 * 0.23M;
            pdv_23_NE = osnovica_23_NE * 0.23M;

            // ---------------------------------------------------
            this.textOSNOVICA23.Value = osnovica_23;
            this.textOSNOVICA23NE.Value = osnovica_23_NE;
            this.textPDV23DA.Value = pdv_23_DA;
            this.textPDV23NE.Value = pdv_23_NE;
        }

        private void pdv25_Click(object sender, EventArgs e)
        {
            decimal osnovica_25, osnovica_25_NE, pdv_25_DA, pdv_25_NE;

            try { osnovica_25 = Convert.ToDecimal(this.textOSNOVICA25.Value); }
            catch (Exception) { osnovica_25 = 0; }

            try { osnovica_25_NE = Convert.ToDecimal(this.textOSNOVICA25NE.Value); }
            catch (Exception) { osnovica_25_NE = 0; }

            try { pdv_25_DA = Convert.ToDecimal(this.textPDV25DA.Value); }
            catch (Exception) { pdv_25_DA = 0; }

            try { pdv_25_NE = Convert.ToDecimal(this.textPDV25NE.Value); }
            catch (Exception) { pdv_25_NE = 0; }

            pdv_25_DA = osnovica_25 * 0.25M;
            pdv_25_NE = osnovica_25_NE * 0.25M;

            // ---------------------------------------------------
            this.textOSNOVICA25.Value = osnovica_25;
            this.textOSNOVICA25NE.Value = osnovica_25_NE;
            this.textPDV25DA.Value = pdv_25_DA;
            this.textPDV25NE.Value = pdv_25_NE;

            #region MBS.Complete
            KORISNIKDataSet dsKorisnik = new KORISNIKDataSet();
            new KORISNIKDataAdapter().Fill(dsKorisnik);

            DataRow korisnik = dsKorisnik.Tables["KORISNIK"].Rows[0];

            decimal predporez = 0;
            decimal izracun = 0;
            if (korisnik["OBVEZNIKPDVA"].ToString() == "True")
            {
                try
                {
                    predporez = Convert.ToDecimal(korisnik["Predporez"]);
                }
                catch { predporez = 0; }

                if (predporez > 0)
                {
                    izracun = pdv_25_DA * predporez/100;
                    this.textPDV25DA.Value = izracun;
                    this.textPDV25NE.Value = pdv_25_DA - izracun;
                }
                else
                {
                    this.textPDV25DA.Value = pdv_25_NE;
                    this.textPDV25NE.Value = pdv_25_DA;
                }
            }
            #endregion
        }

        private UltraCheckEditor checkR2;

        private DOKUMENTComboBox comboURADOKIDDOKUMENT;

        private PARTNERComboBox combourapartnerIDPARTNER;

        private ContextMenu contextMenu1;

        private UltraDateTimeEditor datePickerURADATUM;

        private UltraDateTimeEditor datePickerURAVALUTA;

        private ErrorProvider errorProvider1;

        private ErrorProviderValidator errorProviderValidator1;

        private UltraLabel label1IDTIPURA;

        private UltraLabel label1OSNOVICA0;

        private UltraLabel label1OSNOVICA10;

        private UltraLabel label1OSNOVICA10NE;

        private UltraLabel label1OSNOVICA22;

        private UltraLabel label1OSNOVICA22NE;

        private UltraLabel label1OSNOVICA23;

        private UltraLabel label1OSNOVICA23NE;

        private UltraLabel label1PDV10DA;

        private UltraLabel label1PDV10NE;

        private UltraLabel label1PDV22DA;

        private UltraLabel label1PDV22NE;

        private UltraLabel label1PDV23DA;

        private UltraLabel label1PDV23NE;

        private UltraLabel label1R2;

        private UltraLabel label1URABROJ;

        private UltraLabel label1URABROJRACUNADOBAVLJACA;

        private UltraLabel label1URADATUM;

        private UltraLabel label1URADOKIDDOKUMENT;

        private UltraLabel label1URAGODIDGODINE;

        private UltraLabel label1URAMODEL;

        private UltraLabel label1URANAPOMENA;

        private UltraLabel label1urapartnerIDPARTNER;

        private UltraLabel label1URAPOZIVNABROJ;

        private UltraLabel label1URAUKUPNO;

        private UltraLabel label1URAVALUTA;

        public DeklaritMode Mode;

        private MenuItem SetNullItem;

        private UltraTabControl Tab1;

        private UltraTabPageControl TabPage1;

        private UltraTabPageControl TabPage2;

        #region MBS.Complete 26.04.2016

        private UltraTabPageControl TabPage3;
        protected TableLayoutPanel layoutManagerTabPage3;
        private UltraNumericEditor txtOsnovica;
        private UltraLabel lblOsnovica;
        private UltraNumericEditor txtMoze;
        private UltraLabel lblMoze;
        private UltraNumericEditor txtNeMoze;
        private UltraLabel lblNeMoze;

        #endregion

        private UltraNumericEditor textIDTIPURA;

        private UltraNumericEditor textOSNOVICA0;

        private UltraNumericEditor textOSNOVICA10;       

        private UltraNumericEditor textOSNOVICA10NE;

        private UltraNumericEditor textOSNOVICA22;

        private UltraNumericEditor textOSNOVICA22NE;

        private UltraNumericEditor textOSNOVICA23;

        private UltraNumericEditor textOSNOVICA23NE;

        private UltraNumericEditor textPDV10DA;

        private UltraNumericEditor textPDV10NE;

        private UltraNumericEditor textPDV22DA;

        private UltraNumericEditor textPDV22NE;

        private UltraNumericEditor textPDV23DA;

        private UltraNumericEditor textPDV23NE;

        private UltraNumericEditor textURABROJ;

        private UltraTextEditor textURABROJRACUNADOBAVLJACA;

        private UltraNumericEditor textURAGODIDGODINE;

        private UltraTextEditor textURAMODEL;

        private UltraTextEditor textURANAPOMENA;

        private UltraTextEditor textURAPOZIVNABROJ;

        private UltraNumericEditor textURAUKUPNO;

        private Button pdv10;

        private Button pdv22;

        //private Button pdv23;

        private Button pdv25;

        private System.Windows.Forms.ToolTip toolTip1;

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.URAController URAController { get; set; }

        private StavkeUre UserDefinedControl1;

    }
}

