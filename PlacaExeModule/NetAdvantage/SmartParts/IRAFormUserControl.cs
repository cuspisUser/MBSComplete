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

    [SmartPart]
    public class IRAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        private BindingSource bindingSourceIRA;
        private IContainer components;
        private IRADataSet dsIRADataSet1;
        protected TableLayoutPanel layoutManagerformIRA;
        protected TableLayoutPanel layoutManagerTabPage1;
        protected TableLayoutPanel layoutManagerTabPage2;
        private bool m_AutoNumber;
        private GenericFormClass m_BaseMethods;
        private IRADataSet.IRARow m_CurrentRow;
        private ArrayList m_DataGrids;
        private string m_FirstLevelName;
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription;
        private UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private UltraLabel label1OSN25;
        private UltraLabel label1PDV25;
        private UltraLabel label1OSN05;
        private UltraLabel label1PDV05;
        private UltraNumericEditor textOSN25;
        private UltraNumericEditor textPDV25;
        private UltraLabel lblNeoporezivoUsluge;
        private UltraNumericEditor txtNeoporezivoUsluge;

        private UltraNumericEditor textOSN5;
        private UltraNumericEditor textPDV5;

        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public IRAFormUserControl()
        {
            base.GotFocus += new EventHandler(this.IRAFormUserControl_GotFocus);
            this.components = null;
            this.m_FrameworkDescription = StringResources.IRADescription;
            this.m_DataGrids = new ArrayList();
            this.m_FirstLevelName = "IRA";
            this.m_AutoNumber = false;
            this.InitializeComponent();
            this.SetSize();
        }

        private void CallPromptGODINEIRAGODIDGODINE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.IRAController.SelectGODINEIRAGODIDGODINE(fillMethod, fillByRow);
            this.UpdateValuesGODINEIRAGODIDGODINE(result);
        }

        private void CallPromptTIPIRAIDTIPIRA(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.IRAController.SelectTIPIRAIDTIPIRA(fillMethod, fillByRow);
            this.UpdateValuesTIPIRAIDTIPIRA(result);
        }

        private void CallViewGODINEIRAGODIDGODINE(object sender, EventArgs e)
        {
            DataRow result = this.IRAController.ShowGODINEIRAGODIDGODINE(this.m_CurrentRow);
            this.UpdateValuesGODINEIRAGODIDGODINE(result);
        }

        private void CallViewTIPIRAIDTIPIRA(object sender, EventArgs e)
        {
            DataRow result = this.IRAController.ShowTIPIRAIDTIPIRA(this.m_CurrentRow);
            this.UpdateValuesTIPIRAIDTIPIRA(result);
        }

        public void ChangeBinding()
        {
            this.bindingSourceIRA.DataSource = this.IRAController.DataSet;
            this.dsIRADataSet1 = this.IRAController.DataSet;
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
        public void comboIRADOKIDDOKUMENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboIRADOKIDDOKUMENT.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/PARTNER", Thread=ThreadOption.UserInterface)]
        public void comboIRAPARTNERIDPARTNER_Add(object sender, ComponentEventArgs e)
        {
            this.comboIRAPARTNERIDPARTNER.Fill();
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
                    enumerator = this.dsIRADataSet1.IRA.Rows.GetEnumerator();
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
                if (this.IRAController.Update(this))
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
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "IRA", this.m_Mode, this.dsIRADataSet1, this.dsIRADataSet1.IRA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceIRA, "IRADATUM", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerIRADATUM.DataBindings["Text"] != null)
            {
                this.datePickerIRADATUM.DataBindings.Remove(this.datePickerIRADATUM.DataBindings["Text"]);
            }
            this.datePickerIRADATUM.DataBindings.Add(binding);
            Binding binding2 = new Binding("Text", this.bindingSourceIRA, "IRAVALUTA", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding2.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerIRAVALUTA.DataBindings["Text"] != null)
            {
                this.datePickerIRAVALUTA.DataBindings.Remove(this.datePickerIRAVALUTA.DataBindings["Text"]);
            }
            this.datePickerIRAVALUTA.DataBindings.Add(binding2);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsIRADataSet1.IRA[0];
                this.textIRAGODIDGODINE.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textIRAGODIDGODINE.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (IRADataSet.IRARow) ((DataRowView) this.bindingSourceIRA.AddNew()).Row;
                foreach (string str in DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, foreignKeys))
                {
                    if (!str.ToLower().Contains("25".ToLower()))
                    {
                        this.m_BaseMethods.SetReadOnly(str, true);
                        this.m_BaseMethods.GetLabelControl(str).Visible = false;
                        this.m_BaseMethods.GetControl(str).Visible = false;
                    }
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
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab tab = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab tab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.TabPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.layoutManagerTabPage1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1IRAGODIDGODINE = new Infragistics.Win.Misc.UltraLabel();
            this.textIRAGODIDGODINE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.bindingSourceIRA = new System.Windows.Forms.BindingSource(this.components);
            this.dsIRADataSet1 = new Placa.IRADataSet();
            this.label1IRADOKIDDOKUMENT = new Infragistics.Win.Misc.UltraLabel();
            this.comboIRADOKIDDOKUMENT = new NetAdvantage.Controls.DOKUMENTComboBox();
            this.label1IRABROJ = new Infragistics.Win.Misc.UltraLabel();
            this.textIRABROJ = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1IRAPARTNERIDPARTNER = new Infragistics.Win.Misc.UltraLabel();
            this.comboIRAPARTNERIDPARTNER = new NetAdvantage.Controls.PARTNERComboBox();
            this.label1IRADATUM = new Infragistics.Win.Misc.UltraLabel();
            this.datePickerIRADATUM = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label1IRAVALUTA = new Infragistics.Win.Misc.UltraLabel();
            this.datePickerIRAVALUTA = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label1IRANAPOMENA = new Infragistics.Win.Misc.UltraLabel();
            this.textIRANAPOMENA = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1IRAUKUPNO = new Infragistics.Win.Misc.UltraLabel();
            this.textIRAUKUPNO = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.TabPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.layoutManagerTabPage2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1NEPODLEZE = new Infragistics.Win.Misc.UltraLabel();
            this.textNEPODLEZE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1IDTIPIRA = new Infragistics.Win.Misc.UltraLabel();
            this.textIDTIPIRA = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1IZVOZ = new Infragistics.Win.Misc.UltraLabel();
            this.textIZVOZ = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1MEDJTRANS = new Infragistics.Win.Misc.UltraLabel();
            this.textMEDJTRANS = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1TUZEMSTVO = new Infragistics.Win.Misc.UltraLabel();
            this.textTUZEMSTVO = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1NULA = new Infragistics.Win.Misc.UltraLabel();
            this.textNULA = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1OSN10 = new Infragistics.Win.Misc.UltraLabel();
            this.textOSN10 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1OSN22 = new Infragistics.Win.Misc.UltraLabel();
            this.textOSN22 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1OSN23 = new Infragistics.Win.Misc.UltraLabel();
            this.textOSN23 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1OSTALO = new Infragistics.Win.Misc.UltraLabel();
            this.textOSTALO = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1PDV10 = new Infragistics.Win.Misc.UltraLabel();
            this.textPDV10 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1PDV22 = new Infragistics.Win.Misc.UltraLabel();
            this.textPDV22 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1PDV23 = new Infragistics.Win.Misc.UltraLabel();
            this.textPDV23 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1OSN25 = new Infragistics.Win.Misc.UltraLabel();
            this.label1PDV25 = new Infragistics.Win.Misc.UltraLabel();
            this.textOSN25 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.textPDV25 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            //hrvoje
            this.textOSN5 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.textPDV5 = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1OSN05 = new Infragistics.Win.Misc.UltraLabel();
            this.label1PDV05 = new Infragistics.Win.Misc.UltraLabel();
            this.lblNeoporezivoUsluge = new Infragistics.Win.Misc.UltraLabel();
            this.txtNeoporezivoUsluge = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();

            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.SetNullItem = new System.Windows.Forms.MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderValidator1 = new Deklarit.Win.ErrorProviderValidator(this.components);
            this.layoutManagerformIRA = new System.Windows.Forms.TableLayoutPanel();
            this.Tab1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.UserDefinedControl1 = new NetAdvantage.SmartParts.StavkeIre();
            this.TabPage1.SuspendLayout();
            this.layoutManagerTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textIRAGODIDGODINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceIRA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsIRADataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textIRABROJ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePickerIRADATUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePickerIRAVALUTA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textIRANAPOMENA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textIRAUKUPNO)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.layoutManagerTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textNEPODLEZE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textIDTIPIRA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textIZVOZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMEDJTRANS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textTUZEMSTVO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNULA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSN10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSN22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSN23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSTALO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSN25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV25)).BeginInit();
            //hrvoje
            ((System.ComponentModel.ISupportInitialize)(this.textPDV5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSN5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNeoporezivoUsluge)).BeginInit();


            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.layoutManagerformIRA.SuspendLayout();
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
            this.TabPage1.Size = new System.Drawing.Size(876, 274);
            // 
            // layoutManagerTabPage1
            // 
            this.layoutManagerTabPage1.AutoSize = true;
            this.layoutManagerTabPage1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage1.ColumnCount = 2;
            this.layoutManagerTabPage1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage1.Controls.Add(this.label1IRAGODIDGODINE, 0, 0);
            this.layoutManagerTabPage1.Controls.Add(this.textIRAGODIDGODINE, 1, 0);
            this.layoutManagerTabPage1.Controls.Add(this.label1IRADOKIDDOKUMENT, 0, 1);
            this.layoutManagerTabPage1.Controls.Add(this.comboIRADOKIDDOKUMENT, 1, 1);
            this.layoutManagerTabPage1.Controls.Add(this.label1IRABROJ, 0, 2);
            this.layoutManagerTabPage1.Controls.Add(this.textIRABROJ, 1, 2);
            this.layoutManagerTabPage1.Controls.Add(this.label1IRAPARTNERIDPARTNER, 0, 3);
            this.layoutManagerTabPage1.Controls.Add(this.comboIRAPARTNERIDPARTNER, 1, 3);
            this.layoutManagerTabPage1.Controls.Add(this.label1IRADATUM, 0, 4);
            this.layoutManagerTabPage1.Controls.Add(this.datePickerIRADATUM, 1, 4);
            this.layoutManagerTabPage1.Controls.Add(this.label1IRAVALUTA, 0, 5);
            this.layoutManagerTabPage1.Controls.Add(this.datePickerIRAVALUTA, 1, 5);
            this.layoutManagerTabPage1.Controls.Add(this.label1IRANAPOMENA, 0, 6);
            this.layoutManagerTabPage1.Controls.Add(this.textIRANAPOMENA, 1, 6);
            this.layoutManagerTabPage1.Controls.Add(this.label1IRAUKUPNO, 0, 7);
            this.layoutManagerTabPage1.Controls.Add(this.textIRAUKUPNO, 1, 7);
            this.errorProviderValidator1.SetDisplayName(this.layoutManagerTabPage1, "");
            this.layoutManagerTabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutManagerTabPage1.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerTabPage1.Margin = new System.Windows.Forms.Padding(5);
            this.layoutManagerTabPage1.Name = "layoutManagerTabPage1";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerTabPage1, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerTabPage1, "");
            this.errorProviderValidator1.SetRequired(this.layoutManagerTabPage1, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerTabPage1, "");
            this.layoutManagerTabPage1.RowCount = 9;
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerTabPage1.Size = new System.Drawing.Size(876, 274);
            this.layoutManagerTabPage1.TabIndex = 0;
            // 
            // label1IRAGODIDGODINE
            // 
            this.label1IRAGODIDGODINE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.TextVAlignAsString = "Middle";
            this.label1IRAGODIDGODINE.Appearance = appearance1;
            this.label1IRAGODIDGODINE.AutoSize = true;
            this.label1IRAGODIDGODINE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IRAGODIDGODINE, "");
            this.label1IRAGODIDGODINE.ImageSize = new System.Drawing.Size(7, 10);
            this.label1IRAGODIDGODINE.Location = new System.Drawing.Point(3, 5);
            this.label1IRAGODIDGODINE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IRAGODIDGODINE.Name = "label1IRAGODIDGODINE";
            this.errorProviderValidator1.SetRegularExpression(this.label1IRAGODIDGODINE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IRAGODIDGODINE, "");
            this.errorProviderValidator1.SetRequired(this.label1IRAGODIDGODINE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IRAGODIDGODINE, "");
            this.label1IRAGODIDGODINE.Size = new System.Drawing.Size(63, 14);
            this.label1IRAGODIDGODINE.StyleSetName = "FieldUltraLabel";
            this.label1IRAGODIDGODINE.TabIndex = 1;
            this.label1IRAGODIDGODINE.Tag = "labelIRAGODIDGODINE";
            this.label1IRAGODIDGODINE.Text = "IDGODINE:";
            // 
            // textIRAGODIDGODINE
            // 
            this.textIRAGODIDGODINE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textIRAGODIDGODINE.ButtonsRight.Add(editorButton2);
            this.textIRAGODIDGODINE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "IRAGODIDGODINE", true));
            this.errorProviderValidator1.SetDisplayName(this.textIRAGODIDGODINE, "");
            this.textIRAGODIDGODINE.Location = new System.Drawing.Point(98, 1);
            this.textIRAGODIDGODINE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textIRAGODIDGODINE.MaskInput = "{LOC}-nnnn";
            this.textIRAGODIDGODINE.MinimumSize = new System.Drawing.Size(65, 22);
            this.textIRAGODIDGODINE.Name = "textIRAGODIDGODINE";
            this.textIRAGODIDGODINE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textIRAGODIDGODINE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textIRAGODIDGODINE, "");
            this.errorProviderValidator1.SetRequired(this.textIRAGODIDGODINE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textIRAGODIDGODINE, "");
            this.textIRAGODIDGODINE.Size = new System.Drawing.Size(65, 22);
            this.textIRAGODIDGODINE.TabIndex = 0;
            this.textIRAGODIDGODINE.Tag = "IRAGODIDGODINE";
            this.textIRAGODIDGODINE.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.CallPromptGODINEIRAGODIDGODINE);
            this.textIRAGODIDGODINE.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textIRAGODIDGODINE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // bindingSourceIRA
            // 
            this.bindingSourceIRA.DataMember = "IRA";
            this.bindingSourceIRA.DataSource = this.dsIRADataSet1;
            // 
            // dsIRADataSet1
            // 
            this.dsIRADataSet1.DataSetName = "dsIRA";
            this.dsIRADataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // label1IRADOKIDDOKUMENT
            // 
            this.label1IRADOKIDDOKUMENT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.TextVAlignAsString = "Middle";
            this.label1IRADOKIDDOKUMENT.Appearance = appearance2;
            this.label1IRADOKIDDOKUMENT.AutoSize = true;
            this.label1IRADOKIDDOKUMENT.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IRADOKIDDOKUMENT, "");
            this.label1IRADOKIDDOKUMENT.ImageSize = new System.Drawing.Size(7, 10);
            this.label1IRADOKIDDOKUMENT.Location = new System.Drawing.Point(3, 30);
            this.label1IRADOKIDDOKUMENT.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IRADOKIDDOKUMENT.Name = "label1IRADOKIDDOKUMENT";
            this.errorProviderValidator1.SetRegularExpression(this.label1IRADOKIDDOKUMENT, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IRADOKIDDOKUMENT, "");
            this.errorProviderValidator1.SetRequired(this.label1IRADOKIDDOKUMENT, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IRADOKIDDOKUMENT, "");
            this.label1IRADOKIDDOKUMENT.Size = new System.Drawing.Size(90, 14);
            this.label1IRADOKIDDOKUMENT.StyleSetName = "FieldUltraLabel";
            this.label1IRADOKIDDOKUMENT.TabIndex = 1;
            this.label1IRADOKIDDOKUMENT.Tag = "labelIRADOKIDDOKUMENT";
            this.label1IRADOKIDDOKUMENT.Text = "Šifra dokumenta:";
            // 
            // comboIRADOKIDDOKUMENT
            // 
            this.comboIRADOKIDDOKUMENT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboIRADOKIDDOKUMENT.BackColor = System.Drawing.Color.Transparent;
            this.comboIRADOKIDDOKUMENT.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "IRADOKIDDOKUMENT", true));
            this.comboIRADOKIDDOKUMENT.DisplayMember = "NAZIVDOKUMENT";
            this.errorProviderValidator1.SetDisplayName(this.comboIRADOKIDDOKUMENT, "");
            this.comboIRADOKIDDOKUMENT.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
            this.comboIRADOKIDDOKUMENT.FillByIDTIPDOKUMENTAIDTIPDOKUMENTA = 0;
            this.comboIRADOKIDDOKUMENT.Location = new System.Drawing.Point(98, 26);
            this.comboIRADOKIDDOKUMENT.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.comboIRADOKIDDOKUMENT.MinimumSize = new System.Drawing.Size(406, 23);
            this.comboIRADOKIDDOKUMENT.Name = "comboIRADOKIDDOKUMENT";
            this.errorProviderValidator1.SetRegularExpression(this.comboIRADOKIDDOKUMENT, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.comboIRADOKIDDOKUMENT, "");
            this.errorProviderValidator1.SetRequired(this.comboIRADOKIDDOKUMENT, false);
            this.errorProviderValidator1.SetRequiredMessage(this.comboIRADOKIDDOKUMENT, "");
            this.comboIRADOKIDDOKUMENT.ShowPictureBox = true;
            this.comboIRADOKIDDOKUMENT.Size = new System.Drawing.Size(406, 23);
            this.comboIRADOKIDDOKUMENT.TabIndex = 0;
            this.comboIRADOKIDDOKUMENT.Tag = "IRADOKIDDOKUMENT";
            this.comboIRADOKIDDOKUMENT.ValueMember = "IDDOKUMENT";
            this.comboIRADOKIDDOKUMENT.PictureBoxClicked += new System.EventHandler(this.PictureBoxClickedIRADOKIDDOKUMENT);
            this.comboIRADOKIDDOKUMENT.SelectionChanged += new System.EventHandler(this.SelectedIndexChangedIRADOKIDDOKUMENT);
            this.comboIRADOKIDDOKUMENT.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1IRABROJ
            // 
            this.label1IRABROJ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance3.TextVAlignAsString = "Middle";
            this.label1IRABROJ.Appearance = appearance3;
            this.label1IRABROJ.AutoSize = true;
            this.label1IRABROJ.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IRABROJ, "");
            this.label1IRABROJ.ImageSize = new System.Drawing.Size(7, 10);
            this.label1IRABROJ.Location = new System.Drawing.Point(3, 56);
            this.label1IRABROJ.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IRABROJ.Name = "label1IRABROJ";
            this.errorProviderValidator1.SetRegularExpression(this.label1IRABROJ, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IRABROJ, "");
            this.errorProviderValidator1.SetRequired(this.label1IRABROJ, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IRABROJ, "");
            this.label1IRABROJ.Size = new System.Drawing.Size(49, 14);
            this.label1IRABROJ.StyleSetName = "FieldUltraLabel";
            this.label1IRABROJ.TabIndex = 1;
            this.label1IRABROJ.Tag = "labelIRABROJ";
            this.label1IRABROJ.Text = "Broj IRE:";
            // 
            // textIRABROJ
            // 
            this.textIRABROJ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textIRABROJ.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "IRABROJ", true));
            this.errorProviderValidator1.SetDisplayName(this.textIRABROJ, "");
            this.textIRABROJ.Location = new System.Drawing.Point(98, 52);
            this.textIRABROJ.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textIRABROJ.MaskInput = "{LOC}-nnnnnnnn";
            this.textIRABROJ.MinimumSize = new System.Drawing.Size(72, 22);
            this.textIRABROJ.Name = "textIRABROJ";
            this.textIRABROJ.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textIRABROJ, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textIRABROJ, "");
            this.errorProviderValidator1.SetRequired(this.textIRABROJ, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textIRABROJ, "");
            this.textIRABROJ.Size = new System.Drawing.Size(72, 22);
            this.textIRABROJ.TabIndex = 0;
            this.textIRABROJ.Tag = "IRABROJ";
            this.textIRABROJ.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textIRABROJ.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1IRAPARTNERIDPARTNER
            // 
            this.label1IRAPARTNERIDPARTNER.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextVAlignAsString = "Middle";
            this.label1IRAPARTNERIDPARTNER.Appearance = appearance4;
            this.label1IRAPARTNERIDPARTNER.AutoSize = true;
            this.label1IRAPARTNERIDPARTNER.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IRAPARTNERIDPARTNER, "");
            this.label1IRAPARTNERIDPARTNER.Location = new System.Drawing.Point(3, 81);
            this.label1IRAPARTNERIDPARTNER.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IRAPARTNERIDPARTNER.Name = "label1IRAPARTNERIDPARTNER";
            this.errorProviderValidator1.SetRegularExpression(this.label1IRAPARTNERIDPARTNER, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IRAPARTNERIDPARTNER, "");
            this.errorProviderValidator1.SetRequired(this.label1IRAPARTNERIDPARTNER, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IRAPARTNERIDPARTNER, "");
            this.label1IRAPARTNERIDPARTNER.Size = new System.Drawing.Size(76, 14);
            this.label1IRAPARTNERIDPARTNER.StyleSetName = "FieldUltraLabel";
            this.label1IRAPARTNERIDPARTNER.TabIndex = 1;
            this.label1IRAPARTNERIDPARTNER.Tag = "labelIRAPARTNERIDPARTNER";
            this.label1IRAPARTNERIDPARTNER.Text = "Šifra partnera:";
            // 
            // comboIRAPARTNERIDPARTNER
            // 
            this.comboIRAPARTNERIDPARTNER.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboIRAPARTNERIDPARTNER.BackColor = System.Drawing.Color.Transparent;
            this.comboIRAPARTNERIDPARTNER.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "IRAPARTNERIDPARTNER", true));
            this.comboIRAPARTNERIDPARTNER.DisplayMember = "PT";
            this.errorProviderValidator1.SetDisplayName(this.comboIRAPARTNERIDPARTNER, "");
            this.comboIRAPARTNERIDPARTNER.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
            this.comboIRAPARTNERIDPARTNER.Location = new System.Drawing.Point(98, 77);
            this.comboIRAPARTNERIDPARTNER.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.comboIRAPARTNERIDPARTNER.MinimumSize = new System.Drawing.Size(616, 23);
            this.comboIRAPARTNERIDPARTNER.Name = "comboIRAPARTNERIDPARTNER";
            this.errorProviderValidator1.SetRegularExpression(this.comboIRAPARTNERIDPARTNER, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.comboIRAPARTNERIDPARTNER, "");
            this.errorProviderValidator1.SetRequired(this.comboIRAPARTNERIDPARTNER, false);
            this.errorProviderValidator1.SetRequiredMessage(this.comboIRAPARTNERIDPARTNER, "");
            this.comboIRAPARTNERIDPARTNER.ShowPictureBox = true;
            this.comboIRAPARTNERIDPARTNER.Size = new System.Drawing.Size(616, 23);
            this.comboIRAPARTNERIDPARTNER.TabIndex = 0;
            this.comboIRAPARTNERIDPARTNER.Tag = "IRAPARTNERIDPARTNER";
            this.comboIRAPARTNERIDPARTNER.ValueMember = "IDPARTNER";
            this.comboIRAPARTNERIDPARTNER.PictureBoxClicked += new System.EventHandler(this.PictureBoxClickedIRAPARTNERIDPARTNER);
            this.comboIRAPARTNERIDPARTNER.SelectionChanged += new System.EventHandler(this.SelectedIndexChangedIRAPARTNERIDPARTNER);
            this.comboIRAPARTNERIDPARTNER.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.comboIRAPARTNERIDPARTNER.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend;
            // 
            // label1IRADATUM
            // 
            this.label1IRADATUM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextVAlignAsString = "Middle";
            this.label1IRADATUM.Appearance = appearance5;
            this.label1IRADATUM.AutoSize = true;
            this.label1IRADATUM.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IRADATUM, "");
            this.label1IRADATUM.Location = new System.Drawing.Point(3, 107);
            this.label1IRADATUM.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IRADATUM.Name = "label1IRADATUM";
            this.errorProviderValidator1.SetRegularExpression(this.label1IRADATUM, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IRADATUM, "");
            this.errorProviderValidator1.SetRequired(this.label1IRADATUM, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IRADATUM, "");
            this.label1IRADATUM.Size = new System.Drawing.Size(41, 14);
            this.label1IRADATUM.StyleSetName = "FieldUltraLabel";
            this.label1IRADATUM.TabIndex = 1;
            this.label1IRADATUM.Tag = "labelIRADATUM";
            this.label1IRADATUM.Text = "Datum:";
            // 
            // datePickerIRADATUM
            // 
            this.datePickerIRADATUM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorProviderValidator1.SetDisplayName(this.datePickerIRADATUM, "");
            this.datePickerIRADATUM.Location = new System.Drawing.Point(98, 103);
            this.datePickerIRADATUM.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.datePickerIRADATUM.MinimumSize = new System.Drawing.Size(100, 22);
            this.datePickerIRADATUM.Name = "datePickerIRADATUM";
            this.errorProviderValidator1.SetRegularExpression(this.datePickerIRADATUM, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.datePickerIRADATUM, "");
            this.errorProviderValidator1.SetRequired(this.datePickerIRADATUM, false);
            this.errorProviderValidator1.SetRequiredMessage(this.datePickerIRADATUM, "");
            this.datePickerIRADATUM.Size = new System.Drawing.Size(100, 22);
            this.datePickerIRADATUM.TabIndex = 0;
            this.datePickerIRADATUM.Tag = "IRADATUM";
            this.datePickerIRADATUM.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1IRAVALUTA
            // 
            this.label1IRAVALUTA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.label1IRAVALUTA.Appearance = appearance6;
            this.label1IRAVALUTA.AutoSize = true;
            this.label1IRAVALUTA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IRAVALUTA, "");
            this.label1IRAVALUTA.Location = new System.Drawing.Point(3, 132);
            this.label1IRAVALUTA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IRAVALUTA.Name = "label1IRAVALUTA";
            this.errorProviderValidator1.SetRegularExpression(this.label1IRAVALUTA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IRAVALUTA, "");
            this.errorProviderValidator1.SetRequired(this.label1IRAVALUTA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IRAVALUTA, "");
            this.label1IRAVALUTA.Size = new System.Drawing.Size(40, 14);
            this.label1IRAVALUTA.StyleSetName = "FieldUltraLabel";
            this.label1IRAVALUTA.TabIndex = 1;
            this.label1IRAVALUTA.Tag = "labelIRAVALUTA";
            this.label1IRAVALUTA.Text = "Valuta:";
            // 
            // datePickerIRAVALUTA
            // 
            this.datePickerIRAVALUTA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorProviderValidator1.SetDisplayName(this.datePickerIRAVALUTA, "");
            this.datePickerIRAVALUTA.Location = new System.Drawing.Point(98, 128);
            this.datePickerIRAVALUTA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.datePickerIRAVALUTA.MinimumSize = new System.Drawing.Size(100, 22);
            this.datePickerIRAVALUTA.Name = "datePickerIRAVALUTA";
            this.errorProviderValidator1.SetRegularExpression(this.datePickerIRAVALUTA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.datePickerIRAVALUTA, "");
            this.errorProviderValidator1.SetRequired(this.datePickerIRAVALUTA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.datePickerIRAVALUTA, "");
            this.datePickerIRAVALUTA.Size = new System.Drawing.Size(100, 22);
            this.datePickerIRAVALUTA.TabIndex = 0;
            this.datePickerIRAVALUTA.Tag = "IRAVALUTA";
            this.datePickerIRAVALUTA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1IRANAPOMENA
            // 
            this.label1IRANAPOMENA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.label1IRANAPOMENA.Appearance = appearance7;
            this.label1IRANAPOMENA.AutoSize = true;
            this.label1IRANAPOMENA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IRANAPOMENA, "");
            this.label1IRANAPOMENA.Location = new System.Drawing.Point(3, 156);
            this.label1IRANAPOMENA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IRANAPOMENA.Name = "label1IRANAPOMENA";
            this.errorProviderValidator1.SetRegularExpression(this.label1IRANAPOMENA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IRANAPOMENA, "");
            this.errorProviderValidator1.SetRequired(this.label1IRANAPOMENA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IRANAPOMENA, "");
            this.label1IRANAPOMENA.Size = new System.Drawing.Size(63, 14);
            this.label1IRANAPOMENA.StyleSetName = "FieldUltraLabel";
            this.label1IRANAPOMENA.TabIndex = 1;
            this.label1IRANAPOMENA.Tag = "labelIRANAPOMENA";
            this.label1IRANAPOMENA.Text = "Napomena:";
            // 
            // textIRANAPOMENA
            // 
            this.textIRANAPOMENA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textIRANAPOMENA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceIRA, "IRANAPOMENA", true));
            this.errorProviderValidator1.SetDisplayName(this.textIRANAPOMENA, "");
            this.textIRANAPOMENA.Location = new System.Drawing.Point(98, 153);
            this.textIRANAPOMENA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textIRANAPOMENA.MaxLength = 50;
            this.textIRANAPOMENA.MinimumSize = new System.Drawing.Size(366, 22);
            this.textIRANAPOMENA.Name = "textIRANAPOMENA";
            this.errorProviderValidator1.SetRegularExpression(this.textIRANAPOMENA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textIRANAPOMENA, "");
            this.errorProviderValidator1.SetRequired(this.textIRANAPOMENA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textIRANAPOMENA, "");
            this.textIRANAPOMENA.Size = new System.Drawing.Size(366, 22);
            this.textIRANAPOMENA.TabIndex = 0;
            this.textIRANAPOMENA.Tag = "IRANAPOMENA";
            this.textIRANAPOMENA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1IRAUKUPNO
            // 
            this.label1IRAUKUPNO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.label1IRAUKUPNO.Appearance = appearance8;
            this.label1IRAUKUPNO.AutoSize = true;
            this.label1IRAUKUPNO.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IRAUKUPNO, "");
            this.label1IRAUKUPNO.Location = new System.Drawing.Point(3, 180);
            this.label1IRAUKUPNO.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IRAUKUPNO.Name = "label1IRAUKUPNO";
            this.errorProviderValidator1.SetRegularExpression(this.label1IRAUKUPNO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IRAUKUPNO, "");
            this.errorProviderValidator1.SetRequired(this.label1IRAUKUPNO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IRAUKUPNO, "");
            this.label1IRAUKUPNO.Size = new System.Drawing.Size(46, 14);
            this.label1IRAUKUPNO.StyleSetName = "FieldUltraLabel";
            this.label1IRAUKUPNO.TabIndex = 1;
            this.label1IRAUKUPNO.Tag = "labelIRAUKUPNO";
            this.label1IRAUKUPNO.Text = "Ukupno:";
            // 
            // textIRAUKUPNO
            // 
            this.textIRAUKUPNO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textIRAUKUPNO.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "IRAUKUPNO", true));
            this.errorProviderValidator1.SetDisplayName(this.textIRAUKUPNO, "");
            this.textIRAUKUPNO.Location = new System.Drawing.Point(98, 177);
            this.textIRAUKUPNO.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textIRAUKUPNO.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textIRAUKUPNO.MinimumSize = new System.Drawing.Size(102, 22);
            this.textIRAUKUPNO.Name = "textIRAUKUPNO";
            this.textIRAUKUPNO.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textIRAUKUPNO.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textIRAUKUPNO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textIRAUKUPNO, "");
            this.errorProviderValidator1.SetRequired(this.textIRAUKUPNO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textIRAUKUPNO, "");
            this.textIRAUKUPNO.Size = new System.Drawing.Size(102, 22);
            this.textIRAUKUPNO.TabIndex = 0;
            this.textIRAUKUPNO.Tag = "IRAUKUPNO";
            this.textIRAUKUPNO.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textIRAUKUPNO.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
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
            this.TabPage2.Size = new System.Drawing.Size(876, 274);
            // 
            // layoutManagerTabPage2
            // 
            this.layoutManagerTabPage2.AutoSize = true;
            this.layoutManagerTabPage2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage2.ColumnCount = 4;
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.Controls.Add(this.label1NEPODLEZE, 2, 0);
            this.layoutManagerTabPage2.Controls.Add(this.textNEPODLEZE, 3, 0);
            this.layoutManagerTabPage2.Controls.Add(this.label1IDTIPIRA, 0, 1);
            this.layoutManagerTabPage2.Controls.Add(this.textIDTIPIRA, 1, 1);
            this.layoutManagerTabPage2.Controls.Add(this.label1IZVOZ, 0, 2);
            this.layoutManagerTabPage2.Controls.Add(this.textIZVOZ, 1, 2);
            this.layoutManagerTabPage2.Controls.Add(this.label1MEDJTRANS, 0, 3);
            this.layoutManagerTabPage2.Controls.Add(this.textMEDJTRANS, 1, 3);
            this.layoutManagerTabPage2.Controls.Add(this.label1TUZEMSTVO, 0, 4);
            this.layoutManagerTabPage2.Controls.Add(this.textTUZEMSTVO, 1, 4);
            //this.layoutManagerTabPage2.Controls.Add(this.label1NULA, 0, 5);
            //this.layoutManagerTabPage2.Controls.Add(this.textNULA, 1, 5);
            this.layoutManagerTabPage2.Controls.Add(this.label1OSTALO, 0, 5);
            this.layoutManagerTabPage2.Controls.Add(this.textOSTALO, 1, 5);
            //hrvoje
            this.layoutManagerTabPage2.Controls.Add(this.label1OSN05, 0, 6);
            this.layoutManagerTabPage2.Controls.Add(this.label1PDV05, 2, 6);
            this.layoutManagerTabPage2.Controls.Add(this.textOSN5, 1, 6);
            this.layoutManagerTabPage2.Controls.Add(this.textPDV5, 3, 6);
            this.layoutManagerTabPage2.Controls.Add(this.txtNeoporezivoUsluge, 1, 0);
            this.layoutManagerTabPage2.Controls.Add(this.lblNeoporezivoUsluge, 0, 0);

            this.layoutManagerTabPage2.Controls.Add(this.label1OSN10, 0, 7);
            this.layoutManagerTabPage2.Controls.Add(this.textOSN10, 1, 7);
            this.layoutManagerTabPage2.Controls.Add(this.label1PDV10, 2, 7);
            this.layoutManagerTabPage2.Controls.Add(this.textPDV10, 3, 7);
            
            //this.layoutManagerTabPage2.Controls.Add(this.label1OSN22, 0, 8);
            //this.layoutManagerTabPage2.Controls.Add(this.textOSN22, 1, 8);
            //this.layoutManagerTabPage2.Controls.Add(this.label1PDV22, 2, 8);
            //this.layoutManagerTabPage2.Controls.Add(this.textPDV22, 3, 8);

            //this.layoutManagerTabPage2.Controls.Add(this.label1OSN23, 0, 9);
            //this.layoutManagerTabPage2.Controls.Add(this.textOSN23, 1, 9);
            //this.layoutManagerTabPage2.Controls.Add(this.label1PDV23, 2, 9);
            //this.layoutManagerTabPage2.Controls.Add(this.textPDV23, 3, 9);

            this.layoutManagerTabPage2.Controls.Add(this.label1OSN25, 0, 8);
            this.layoutManagerTabPage2.Controls.Add(this.label1PDV25, 2, 8);
            this.layoutManagerTabPage2.Controls.Add(this.textOSN25, 1, 8);
            this.layoutManagerTabPage2.Controls.Add(this.textPDV25, 3, 8);

            this.errorProviderValidator1.SetDisplayName(this.layoutManagerTabPage2, "");
            this.layoutManagerTabPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutManagerTabPage2.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerTabPage2.Margin = new System.Windows.Forms.Padding(5);
            this.layoutManagerTabPage2.Name = "layoutManagerTabPage2";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerTabPage2, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerTabPage2, "");
            this.errorProviderValidator1.SetRequired(this.layoutManagerTabPage2, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerTabPage2, "");
            this.layoutManagerTabPage2.RowCount = 12;
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
            this.layoutManagerTabPage2.Size = new System.Drawing.Size(876, 274);
            this.layoutManagerTabPage2.TabIndex = 0;
            // 
            // label1NEPODLEZE
            // 
            this.label1NEPODLEZE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextVAlignAsString = "Middle";
            this.label1NEPODLEZE.Appearance = appearance9;
            this.label1NEPODLEZE.AutoSize = true;
            this.label1NEPODLEZE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1NEPODLEZE, "");
            this.label1NEPODLEZE.Location = new System.Drawing.Point(3, 5);
            this.label1NEPODLEZE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1NEPODLEZE.Name = "label1NEPODLEZE";
            this.errorProviderValidator1.SetRegularExpression(this.label1NEPODLEZE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1NEPODLEZE, "");
            this.errorProviderValidator1.SetRequired(this.label1NEPODLEZE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1NEPODLEZE, "");
            this.label1NEPODLEZE.Size = new System.Drawing.Size(152, 14);
            this.label1NEPODLEZE.StyleSetName = "FieldUltraLabel";
            this.label1NEPODLEZE.TabIndex = 1;
            this.label1NEPODLEZE.Tag = "labelNEPODLEZE";
            this.label1NEPODLEZE.Text = "Neop.dobra unut. EU- oslob.:";
            // 
            // textNEPODLEZE
            // 
            this.textNEPODLEZE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textNEPODLEZE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "NEPODLEZE", true));
            this.errorProviderValidator1.SetDisplayName(this.textNEPODLEZE, "");
            this.textNEPODLEZE.Location = new System.Drawing.Point(145, 1);
            this.textNEPODLEZE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textNEPODLEZE.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textNEPODLEZE.MinimumSize = new System.Drawing.Size(102, 22);
            this.textNEPODLEZE.Name = "textNEPODLEZE";
            this.textNEPODLEZE.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textNEPODLEZE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textNEPODLEZE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textNEPODLEZE, "");
            this.errorProviderValidator1.SetRequired(this.textNEPODLEZE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textNEPODLEZE, "");
            this.textNEPODLEZE.Size = new System.Drawing.Size(102, 22);
            this.textNEPODLEZE.TabIndex = 2;
            this.textNEPODLEZE.Tag = "NEPODLEZE";
            this.textNEPODLEZE.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textNEPODLEZE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1IDTIPIRA
            // 
            this.label1IDTIPIRA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextVAlignAsString = "Middle";
            this.label1IDTIPIRA.Appearance = appearance10;
            this.label1IDTIPIRA.AutoSize = true;
            this.label1IDTIPIRA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IDTIPIRA, "");
            this.label1IDTIPIRA.Location = new System.Drawing.Point(3, 30);
            this.label1IDTIPIRA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IDTIPIRA.Name = "label1IDTIPIRA";
            this.errorProviderValidator1.SetRegularExpression(this.label1IDTIPIRA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IDTIPIRA, "");
            this.errorProviderValidator1.SetRequired(this.label1IDTIPIRA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IDTIPIRA, "");
            this.label1IDTIPIRA.Size = new System.Drawing.Size(45, 14);
            this.label1IDTIPIRA.StyleSetName = "FieldUltraLabel";
            this.label1IDTIPIRA.TabIndex = 1;
            this.label1IDTIPIRA.Tag = "labelIDTIPIRA";
            this.label1IDTIPIRA.Text = "Tip IRE:";
            // 
            // textIDTIPIRA
            // 
            this.textIDTIPIRA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textIDTIPIRA.ButtonsRight.Add(editorButton1);
            this.textIDTIPIRA.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "IDTIPIRA", true));
            this.errorProviderValidator1.SetDisplayName(this.textIDTIPIRA, "");
            this.textIDTIPIRA.Location = new System.Drawing.Point(145, 26);
            this.textIDTIPIRA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textIDTIPIRA.MaskInput = "{LOC}-nnnnn";
            this.textIDTIPIRA.MinimumSize = new System.Drawing.Size(71, 22);
            this.textIDTIPIRA.Name = "textIDTIPIRA";
            this.textIDTIPIRA.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textIDTIPIRA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textIDTIPIRA, "");
            this.errorProviderValidator1.SetRequired(this.textIDTIPIRA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textIDTIPIRA, "");
            this.textIDTIPIRA.Size = new System.Drawing.Size(71, 22);
            this.textIDTIPIRA.TabIndex = 3;
            this.textIDTIPIRA.Tag = "IDTIPIRA";
            this.textIDTIPIRA.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.CallPromptTIPIRAIDTIPIRA);
            this.textIDTIPIRA.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textIDTIPIRA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1IZVOZ
            // 
            this.label1IZVOZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextVAlignAsString = "Middle";
            this.label1IZVOZ.Appearance = appearance11;
            this.label1IZVOZ.AutoSize = true;
            this.label1IZVOZ.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IZVOZ, "");
            this.label1IZVOZ.Location = new System.Drawing.Point(3, 55);
            this.label1IZVOZ.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IZVOZ.Name = "label1IZVOZ";
            this.errorProviderValidator1.SetRegularExpression(this.label1IZVOZ, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IZVOZ, "");
            this.errorProviderValidator1.SetRequired(this.label1IZVOZ, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IZVOZ, "");
            this.label1IZVOZ.Size = new System.Drawing.Size(140, 14);
            this.label1IZVOZ.StyleSetName = "FieldUltraLabel";
            this.label1IZVOZ.TabIndex = 1;
            this.label1IZVOZ.Tag = "labelIZVOZ";
            this.label1IZVOZ.Text = "Izvoz. isporuke- oslobođ.:";
            // 
            // textIZVOZ
            // 
            this.textIZVOZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textIZVOZ.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "IZVOZ", true));
            this.errorProviderValidator1.SetDisplayName(this.textIZVOZ, "");
            this.textIZVOZ.Location = new System.Drawing.Point(145, 51);
            this.textIZVOZ.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textIZVOZ.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textIZVOZ.MinimumSize = new System.Drawing.Size(102, 22);
            this.textIZVOZ.Name = "textIZVOZ";
            this.textIZVOZ.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textIZVOZ.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textIZVOZ, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textIZVOZ, "");
            this.errorProviderValidator1.SetRequired(this.textIZVOZ, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textIZVOZ, "");
            this.textIZVOZ.Size = new System.Drawing.Size(102, 22);
            this.textIZVOZ.TabIndex = 4;
            this.textIZVOZ.Tag = "IZVOZ";
            this.textIZVOZ.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textIZVOZ.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1MEDJTRANS
            // 
            this.label1MEDJTRANS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.label1MEDJTRANS.Appearance = appearance12;
            this.label1MEDJTRANS.AutoSize = true;
            this.label1MEDJTRANS.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1MEDJTRANS, "");
            this.label1MEDJTRANS.Location = new System.Drawing.Point(3, 80);
            this.label1MEDJTRANS.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1MEDJTRANS.Name = "label1MEDJTRANS";
            this.errorProviderValidator1.SetRegularExpression(this.label1MEDJTRANS, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1MEDJTRANS, "");
            this.errorProviderValidator1.SetRequired(this.label1MEDJTRANS, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1MEDJTRANS, "");
            this.label1MEDJTRANS.Size = new System.Drawing.Size(140, 14);
            this.label1MEDJTRANS.StyleSetName = "FieldUltraLabel";
            this.label1MEDJTRANS.TabIndex = 1;
            this.label1MEDJTRANS.Tag = "labelMEDJTRANS";
            this.label1MEDJTRANS.Text = "Tuzem.prij.por.obv.:";
            // 
            // textMEDJTRANS
            // 
            this.textMEDJTRANS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textMEDJTRANS.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "MEDJTRANS", true));
            this.errorProviderValidator1.SetDisplayName(this.textMEDJTRANS, "");
            this.textMEDJTRANS.Location = new System.Drawing.Point(145, 76);
            this.textMEDJTRANS.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textMEDJTRANS.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textMEDJTRANS.MinimumSize = new System.Drawing.Size(102, 22);
            this.textMEDJTRANS.Name = "textMEDJTRANS";
            this.textMEDJTRANS.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textMEDJTRANS.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textMEDJTRANS, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textMEDJTRANS, "");
            this.errorProviderValidator1.SetRequired(this.textMEDJTRANS, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textMEDJTRANS, "");
            this.textMEDJTRANS.Size = new System.Drawing.Size(102, 22);
            this.textMEDJTRANS.TabIndex = 5;
            this.textMEDJTRANS.Tag = "MEDJTRANS";
            this.textMEDJTRANS.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textMEDJTRANS.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1TUZEMSTVO
            // 
            this.label1TUZEMSTVO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.TextVAlignAsString = "Middle";
            this.label1TUZEMSTVO.Appearance = appearance13;
            this.label1TUZEMSTVO.AutoSize = true;
            this.label1TUZEMSTVO.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1TUZEMSTVO, "");
            this.label1TUZEMSTVO.Location = new System.Drawing.Point(3, 104);
            this.label1TUZEMSTVO.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1TUZEMSTVO.Name = "label1TUZEMSTVO";
            this.errorProviderValidator1.SetRegularExpression(this.label1TUZEMSTVO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1TUZEMSTVO, "");
            this.errorProviderValidator1.SetRequired(this.label1TUZEMSTVO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1TUZEMSTVO, "");
            this.label1TUZEMSTVO.Size = new System.Drawing.Size(140, 14);
            this.label1TUZEMSTVO.StyleSetName = "FieldUltraLabel";
            this.label1TUZEMSTVO.TabIndex = 1;
            this.label1TUZEMSTVO.Tag = "labelTUZEMSTVO";
            this.label1TUZEMSTVO.Text = "U tuzem.oslobođeno:";
            // 
            // textTUZEMSTVO
            // 
            this.textTUZEMSTVO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textTUZEMSTVO.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "TUZEMSTVO", true));
            this.errorProviderValidator1.SetDisplayName(this.textTUZEMSTVO, "");
            this.textTUZEMSTVO.Location = new System.Drawing.Point(145, 101);
            this.textTUZEMSTVO.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textTUZEMSTVO.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textTUZEMSTVO.MinimumSize = new System.Drawing.Size(102, 22);
            this.textTUZEMSTVO.Name = "textTUZEMSTVO";
            this.textTUZEMSTVO.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textTUZEMSTVO.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textTUZEMSTVO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textTUZEMSTVO, "");
            this.errorProviderValidator1.SetRequired(this.textTUZEMSTVO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textTUZEMSTVO, "");
            this.textTUZEMSTVO.Size = new System.Drawing.Size(102, 22);
            this.textTUZEMSTVO.TabIndex = 6;
            this.textTUZEMSTVO.Tag = "TUZEMSTVO";
            this.textTUZEMSTVO.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textTUZEMSTVO.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1NULA
            // 
            this.label1NULA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextVAlignAsString = "Middle";
            this.label1NULA.Appearance = appearance14;
            this.label1NULA.AutoSize = true;
            this.label1NULA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1NULA, "");
            this.label1NULA.Location = new System.Drawing.Point(3, 128);
            this.label1NULA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1NULA.Name = "label1NULA";
            this.errorProviderValidator1.SetRegularExpression(this.label1NULA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1NULA, "");
            this.errorProviderValidator1.SetRequired(this.label1NULA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1NULA, "");
            this.label1NULA.Size = new System.Drawing.Size(27, 14);
            this.label1NULA.StyleSetName = "FieldUltraLabel";
            this.label1NULA.TabIndex = 1;
            this.label1NULA.Tag = "labelNULA";
            this.label1NULA.Text = "0 %:";
            this.label1NULA.Visible = false;
            // 
            // textNULA
            // 
            this.textNULA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textNULA.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "NULA", true));
            this.errorProviderValidator1.SetDisplayName(this.textNULA, "");
            this.textNULA.Location = new System.Drawing.Point(145, 125);
            this.textNULA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textNULA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textNULA.MinimumSize = new System.Drawing.Size(102, 22);
            this.textNULA.Name = "textNULA";
            this.textNULA.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textNULA.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textNULA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textNULA, "");
            this.errorProviderValidator1.SetRequired(this.textNULA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textNULA, "");
            this.textNULA.Size = new System.Drawing.Size(102, 22);
            this.textNULA.TabIndex = 0;
            this.textNULA.Tag = "NULA";
            this.textNULA.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textNULA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.textNULA.Visible = false;
            // 
            // label1OSN10
            // 
            this.label1OSN10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextVAlignAsString = "Middle";
            this.label1OSN10.Appearance = appearance15;
            this.label1OSN10.AutoSize = true;
            this.label1OSN10.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSN10, "");
            this.label1OSN10.Location = new System.Drawing.Point(3, 152);
            this.label1OSN10.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSN10.Name = "label1OSN10";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSN10, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSN10, "");
            this.errorProviderValidator1.SetRequired(this.label1OSN10, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSN10, "");
            this.label1OSN10.Size = new System.Drawing.Size(70, 14);
            this.label1OSN10.StyleSetName = "FieldUltraLabel";
            this.label1OSN10.TabIndex = 1;
            this.label1OSN10.Tag = "labelOSN10";
            this.label1OSN10.Text = "Osnovica 13:";
            // 
            // textOSN10
            // 
            this.textOSN10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSN10.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "OSN10", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSN10, "");
            this.textOSN10.Location = new System.Drawing.Point(145, 149);
            this.textOSN10.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSN10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSN10.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSN10.Name = "textOSN10";
            this.textOSN10.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSN10.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSN10, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSN10, "");
            this.errorProviderValidator1.SetRequired(this.textOSN10, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSN10, "");
            this.textOSN10.Size = new System.Drawing.Size(102, 22);
            this.textOSN10.TabIndex = 10;
            this.textOSN10.Tag = "OSN10";
            this.textOSN10.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOSN10.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1OSN22
            // 
            this.label1OSN22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextVAlignAsString = "Middle";
            this.label1OSN22.Appearance = appearance16;
            this.label1OSN22.AutoSize = true;
            this.label1OSN22.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSN22, "");
            this.label1OSN22.Location = new System.Drawing.Point(3, 176);
            this.label1OSN22.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSN22.Name = "label1OSN22";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSN22, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSN22, "");
            this.errorProviderValidator1.SetRequired(this.label1OSN22, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSN22, "");
            this.label1OSN22.Size = new System.Drawing.Size(70, 14);
            this.label1OSN22.StyleSetName = "FieldUltraLabel";
            this.label1OSN22.TabIndex = 1;
            this.label1OSN22.Tag = "labelOSN22";
            this.label1OSN22.Text = "Osnovica 22:";
            this.label1OSN22.Visible = false;
            // 
            // textOSN22
            // 
            this.textOSN22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSN22.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "OSN22", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSN22, "");
            this.textOSN22.Location = new System.Drawing.Point(145, 173);
            this.textOSN22.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSN22.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSN22.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSN22.Name = "textOSN22";
            this.textOSN22.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSN22.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSN22, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSN22, "");
            this.errorProviderValidator1.SetRequired(this.textOSN22, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSN22, "");
            this.textOSN22.Size = new System.Drawing.Size(102, 22);
            this.textOSN22.TabIndex = 0;
            this.textOSN22.Tag = "OSN22";
            this.textOSN22.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOSN22.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.textOSN22.Visible = false;
            // 
            // label1OSN23
            // 
            this.label1OSN23.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance22.ForeColor = System.Drawing.Color.Black;
            appearance22.TextVAlignAsString = "Middle";
            this.label1OSN23.Appearance = appearance22;
            this.label1OSN23.AutoSize = true;
            this.label1OSN23.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSN23, "");
            this.label1OSN23.Location = new System.Drawing.Point(3, 200);
            this.label1OSN23.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSN23.Name = "label1OSN23";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSN23, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSN23, "");
            this.errorProviderValidator1.SetRequired(this.label1OSN23, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSN23, "");
            this.label1OSN23.Size = new System.Drawing.Size(70, 14);
            this.label1OSN23.StyleSetName = "FieldUltraLabel";
            this.label1OSN23.TabIndex = 1;
            this.label1OSN23.Tag = "labelOSN23";
            this.label1OSN23.Text = "Osnovica 23:";
            this.label1OSN23.Visible = false;
            // 
            // textOSN23
            // 
            this.textOSN23.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSN23.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "OSN23", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSN23, "");
            this.textOSN23.Location = new System.Drawing.Point(145, 197);
            this.textOSN23.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSN23.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSN23.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSN23.Name = "textOSN23";
            this.textOSN23.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSN23.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSN23, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSN23, "");
            this.errorProviderValidator1.SetRequired(this.textOSN23, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSN23, "");
            this.textOSN23.Size = new System.Drawing.Size(102, 22);
            this.textOSN23.TabIndex = 0;
            this.textOSN23.Tag = "OSN23";
            this.textOSN23.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOSN23.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.textOSN23.Visible = false;
            // 
            // label1OSTALO
            // 
            this.label1OSTALO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Middle";
            this.label1OSTALO.Appearance = appearance18;
            this.label1OSTALO.AutoSize = true;
            this.label1OSTALO.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSTALO, "");
            this.label1OSTALO.Location = new System.Drawing.Point(253, 128);
            this.label1OSTALO.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSTALO.Name = "label1OSTALO";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSTALO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSTALO, "");
            this.errorProviderValidator1.SetRequired(this.label1OSTALO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSTALO, "");
            this.label1OSTALO.Size = new System.Drawing.Size(140, 14);
            this.label1OSTALO.StyleSetName = "FieldUltraLabel";
            this.label1OSTALO.TabIndex = 1;
            this.label1OSTALO.Tag = "labelOSTALO";
            this.label1OSTALO.Text = "Ostala oslobođenja:";
            // 
            // textOSTALO
            // 
            this.textOSTALO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSTALO.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "OSTALO", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSTALO, "");
            this.textOSTALO.Location = new System.Drawing.Point(311, 125);
            this.textOSTALO.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSTALO.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSTALO.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSTALO.Name = "textOSTALO";
            this.textOSTALO.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSTALO.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSTALO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSTALO, "");
            this.errorProviderValidator1.SetRequired(this.textOSTALO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSTALO, "");
            this.textOSTALO.Size = new System.Drawing.Size(102, 22);
            this.textOSTALO.TabIndex = 7;
            this.textOSTALO.Tag = "OSTALO";
            this.textOSTALO.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOSTALO.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1PDV10
            // 
            this.label1PDV10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.label1PDV10.Appearance = appearance19;
            this.label1PDV10.AutoSize = true;
            this.label1PDV10.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PDV10, "");
            this.label1PDV10.Location = new System.Drawing.Point(253, 152);
            this.label1PDV10.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PDV10.Name = "label1PDV10";
            this.errorProviderValidator1.SetRegularExpression(this.label1PDV10, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PDV10, "");
            this.errorProviderValidator1.SetRequired(this.label1PDV10, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PDV10, "");
            this.label1PDV10.Size = new System.Drawing.Size(46, 14);
            this.label1PDV10.StyleSetName = "FieldUltraLabel";
            this.label1PDV10.TabIndex = 1;
            this.label1PDV10.Tag = "labelPDV10";
            this.label1PDV10.Text = "PDV 13:";
            // 
            // textPDV10
            // 
            this.textPDV10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPDV10.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "PDV10", true));
            this.errorProviderValidator1.SetDisplayName(this.textPDV10, "");
            this.textPDV10.Location = new System.Drawing.Point(311, 149);
            this.textPDV10.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPDV10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPDV10.MinimumSize = new System.Drawing.Size(102, 22);
            this.textPDV10.Name = "textPDV10";
            this.textPDV10.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textPDV10.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textPDV10, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPDV10, "");
            this.errorProviderValidator1.SetRequired(this.textPDV10, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPDV10, "");
            this.textPDV10.Size = new System.Drawing.Size(102, 22);
            this.textPDV10.TabIndex = 11;
            this.textPDV10.Tag = "PDV10";
            this.textPDV10.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textPDV10.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1PDV22
            // 
            this.label1PDV22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextVAlignAsString = "Middle";
            this.label1PDV22.Appearance = appearance20;
            this.label1PDV22.AutoSize = true;
            this.label1PDV22.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PDV22, "");
            this.label1PDV22.Location = new System.Drawing.Point(253, 176);
            this.label1PDV22.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PDV22.Name = "label1PDV22";
            this.errorProviderValidator1.SetRegularExpression(this.label1PDV22, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PDV22, "");
            this.errorProviderValidator1.SetRequired(this.label1PDV22, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PDV22, "");
            this.label1PDV22.Size = new System.Drawing.Size(46, 14);
            this.label1PDV22.StyleSetName = "FieldUltraLabel";
            this.label1PDV22.TabIndex = 1;
            this.label1PDV22.Tag = "labelPDV22";
            this.label1PDV22.Text = "PDV 22:";
            this.label1PDV22.Visible = false;
            // 
            // textPDV22
            // 
            this.textPDV22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPDV22.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "PDV22", true));
            this.errorProviderValidator1.SetDisplayName(this.textPDV22, "");
            this.textPDV22.Location = new System.Drawing.Point(311, 173);
            this.textPDV22.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPDV22.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPDV22.MinimumSize = new System.Drawing.Size(102, 22);
            this.textPDV22.Name = "textPDV22";
            this.textPDV22.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textPDV22.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textPDV22, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPDV22, "");
            this.errorProviderValidator1.SetRequired(this.textPDV22, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPDV22, "");
            this.textPDV22.Size = new System.Drawing.Size(102, 22);
            this.textPDV22.TabIndex = 0;
            this.textPDV22.Tag = "PDV22";
            this.textPDV22.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textPDV22.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.textPDV22.Visible = false;
            // 
            // label1PDV23
            // 
            this.label1PDV23.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.label1PDV23.Appearance = appearance23;
            this.label1PDV23.AutoSize = true;
            this.label1PDV23.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PDV23, "");
            this.label1PDV23.Location = new System.Drawing.Point(253, 200);
            this.label1PDV23.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PDV23.Name = "label1PDV23";
            this.errorProviderValidator1.SetRegularExpression(this.label1PDV23, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PDV23, "");
            this.errorProviderValidator1.SetRequired(this.label1PDV23, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PDV23, "");
            this.label1PDV23.Size = new System.Drawing.Size(46, 14);
            this.label1PDV23.StyleSetName = "FieldUltraLabel";
            this.label1PDV23.TabIndex = 1;
            this.label1PDV23.Tag = "labelPDV23";
            this.label1PDV23.Text = "PDV 23:";
            this.label1PDV23.Visible = false;
            // 
            // textPDV23
            // 
            this.textPDV23.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPDV23.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "PDV23", true));
            this.errorProviderValidator1.SetDisplayName(this.textPDV23, "");
            this.textPDV23.Location = new System.Drawing.Point(311, 197);
            this.textPDV23.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPDV23.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPDV23.MinimumSize = new System.Drawing.Size(102, 22);
            this.textPDV23.Name = "textPDV23";
            this.textPDV23.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textPDV23.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textPDV23, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPDV23, "");
            this.errorProviderValidator1.SetRequired(this.textPDV23, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPDV23, "");
            this.textPDV23.Size = new System.Drawing.Size(102, 22);
            this.textPDV23.TabIndex = 0;
            this.textPDV23.Tag = "PDV23";
            this.textPDV23.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textPDV23.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            this.textPDV23.Visible = false;
            // 
            // label1OSN25
            // 
            this.label1OSN25.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextVAlignAsString = "Middle";
            this.label1OSN25.Appearance = appearance17;
            this.label1OSN25.AutoSize = true;
            this.label1OSN25.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSN25, "");
            this.label1OSN25.Location = new System.Drawing.Point(3, 224);
            this.label1OSN25.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSN25.Name = "label1OSN25";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSN25, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSN25, "");
            this.errorProviderValidator1.SetRequired(this.label1OSN25, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSN25, "");
            this.label1OSN25.Size = new System.Drawing.Size(70, 14);
            this.label1OSN25.StyleSetName = "FieldUltraLabel";
            this.label1OSN25.TabIndex = 2;
            this.label1OSN25.Tag = "labelOSN25";
            this.label1OSN25.Text = "Osnovica 25:";
            // 
            // label1PDV25
            // 
            this.label1PDV25.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.TextVAlignAsString = "Middle";
            this.label1PDV25.Appearance = appearance21;
            this.label1PDV25.AutoSize = true;
            this.label1PDV25.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PDV25, "");
            this.label1PDV25.Location = new System.Drawing.Point(253, 224);
            this.label1PDV25.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PDV25.Name = "label1PDV25";
            this.errorProviderValidator1.SetRegularExpression(this.label1PDV25, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PDV25, "");
            this.errorProviderValidator1.SetRequired(this.label1PDV25, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PDV25, "");
            this.label1PDV25.Size = new System.Drawing.Size(46, 14);
            this.label1PDV25.StyleSetName = "FieldUltraLabel";
            this.label1PDV25.TabIndex = 3;
            this.label1PDV25.Tag = "labelPDV25";
            this.label1PDV25.Text = "PDV 25:";
            // 
            // label1OSN05
            // 
            this.label1OSN05.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextVAlignAsString = "Middle";
            this.label1OSN05.Appearance = appearance17;
            this.label1OSN05.AutoSize = true;
            this.label1OSN05.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OSN05, "");
            this.label1OSN05.Location = new System.Drawing.Point(3, 230);
            this.label1OSN05.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OSN05.Name = "label1OSN05";
            this.errorProviderValidator1.SetRegularExpression(this.label1OSN05, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OSN05, "");
            this.errorProviderValidator1.SetRequired(this.label1OSN05, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OSN05, "");
            this.label1OSN05.Size = new System.Drawing.Size(70, 14);
            this.label1OSN05.StyleSetName = "FieldUltraLabel";
            this.label1OSN05.TabIndex = 2;
            this.label1OSN25.Tag = "label1OSN05";
            this.label1OSN05.Text = "Osnovica 5:";
            // 
            // label1PDV25
            // 
            this.label1PDV05.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.TextVAlignAsString = "Middle";
            this.label1PDV05.Appearance = appearance21;
            this.label1PDV05.AutoSize = true;
            this.label1PDV05.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1PDV05, "");
            this.label1PDV05.Location = new System.Drawing.Point(253, 230);
            this.label1PDV05.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1PDV05.Name = "label1PDV05";
            this.errorProviderValidator1.SetRegularExpression(this.label1PDV05, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1PDV05, "");
            this.errorProviderValidator1.SetRequired(this.label1PDV05, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1PDV05, "");
            this.label1PDV05.Size = new System.Drawing.Size(46, 14);
            this.label1PDV05.StyleSetName = "FieldUltraLabel";
            this.label1PDV05.TabIndex = 3;
            this.label1PDV05.Tag = "label1PDV05";
            this.label1PDV05.Text = "PDV 5:";
            // 
            // textOSN25
            // 
            this.textOSN25.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSN25.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "OSN25", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSN25, "");
            this.textOSN25.Location = new System.Drawing.Point(145, 221);
            this.textOSN25.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSN25.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSN25.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSN25.Name = "textOSN25";
            this.textOSN25.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSN25.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSN25, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSN25, "");
            this.errorProviderValidator1.SetRequired(this.textOSN25, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSN25, "");
            this.textOSN25.Size = new System.Drawing.Size(102, 22);
            this.textOSN25.TabIndex = 12;
            this.textOSN25.Tag = "OSN25";
            this.textOSN25.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOSN25.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // textPDV25
            // 
            this.textPDV25.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPDV25.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "PDV25", true));
            this.errorProviderValidator1.SetDisplayName(this.textPDV25, "");
            this.textPDV25.Location = new System.Drawing.Point(311, 221);
            this.textPDV25.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPDV25.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPDV25.MinimumSize = new System.Drawing.Size(102, 22);
            this.textPDV25.Name = "textPDV25";
            this.textPDV25.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textPDV25.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textPDV25, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPDV25, "");
            this.errorProviderValidator1.SetRequired(this.textPDV25, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPDV25, "");
            this.textPDV25.Size = new System.Drawing.Size(102, 22);
            this.textPDV25.TabIndex = 13;
            this.textPDV25.Tag = "PDV25";
            this.textPDV25.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textPDV25.MouseEnter += new System.EventHandler(this.mouseEnter_Text);

            // 
            // textOSN5
            // 
            this.textOSN5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOSN5.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "OSN05", true));
            this.errorProviderValidator1.SetDisplayName(this.textOSN5, "");
            this.textOSN5.Location = new System.Drawing.Point(145, 221);
            this.textOSN5.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOSN5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textOSN5.MinimumSize = new System.Drawing.Size(102, 22);
            this.textOSN5.Name = "textOSN5";
            this.textOSN5.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textOSN5.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textOSN5, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOSN5, "");
            this.errorProviderValidator1.SetRequired(this.textOSN5, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOSN5, "");
            this.textOSN5.Size = new System.Drawing.Size(102, 22);
            this.textOSN5.TabIndex = 8;
            this.textOSN5.Tag = "OSN5";
            this.textOSN5.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textOSN5.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // textPDV5
            // 
            this.textPDV5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPDV5.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "PDV05", true));
            this.errorProviderValidator1.SetDisplayName(this.textPDV5, "");
            this.textPDV5.Location = new System.Drawing.Point(311, 221);
            this.textPDV5.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textPDV5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.textPDV5.MinimumSize = new System.Drawing.Size(102, 22);
            this.textPDV5.Name = "textPDV5";
            this.textPDV5.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textPDV5.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textPDV5, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textPDV5, "");
            this.errorProviderValidator1.SetRequired(this.textPDV5, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textPDV5, "");
            this.textPDV5.Size = new System.Drawing.Size(102, 22);
            this.textPDV5.TabIndex = 9;
            this.textPDV5.Tag = "PDV5";
            this.textPDV5.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textPDV5.MouseEnter += new System.EventHandler(this.mouseEnter_Text);

            // 
            // lblNeoporezivoUsluge
            // 
            this.lblNeoporezivoUsluge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextVAlignAsString = "Middle";
            this.lblNeoporezivoUsluge.Appearance = appearance9;
            this.lblNeoporezivoUsluge.AutoSize = true;
            this.lblNeoporezivoUsluge.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.lblNeoporezivoUsluge, "");
            this.lblNeoporezivoUsluge.Location = new System.Drawing.Point(3, 5);
            this.lblNeoporezivoUsluge.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.lblNeoporezivoUsluge.Name = "lblNeoporezivoUsluge";
            this.errorProviderValidator1.SetRegularExpression(this.lblNeoporezivoUsluge, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.lblNeoporezivoUsluge, "");
            this.errorProviderValidator1.SetRequired(this.lblNeoporezivoUsluge, false);
            this.errorProviderValidator1.SetRequiredMessage(this.lblNeoporezivoUsluge, "");
            this.lblNeoporezivoUsluge.Size = new System.Drawing.Size(140, 14);
            this.lblNeoporezivoUsluge.StyleSetName = "FieldUltraLabel";
            this.lblNeoporezivoUsluge.TabIndex = 0;
            this.lblNeoporezivoUsluge.Tag = "labelNEPODLEZE";
            this.lblNeoporezivoUsluge.Text = "Neop.usluge unut. EU- oslob.:";
            // 
            // txtNeoporezivoUsluge
            // 
            this.txtNeoporezivoUsluge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNeoporezivoUsluge.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceIRA, "NEPODLEZE_USLUGA", true));
            this.errorProviderValidator1.SetDisplayName(this.txtNeoporezivoUsluge, "");
            this.txtNeoporezivoUsluge.Location = new System.Drawing.Point(145, 1);
            this.txtNeoporezivoUsluge.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.txtNeoporezivoUsluge.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.txtNeoporezivoUsluge.MinimumSize = new System.Drawing.Size(102, 22);
            this.txtNeoporezivoUsluge.Name = "txtNeoporezivoUsluge";
            this.txtNeoporezivoUsluge.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtNeoporezivoUsluge.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.txtNeoporezivoUsluge, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.txtNeoporezivoUsluge, "");
            this.errorProviderValidator1.SetRequired(this.txtNeoporezivoUsluge, false);
            this.errorProviderValidator1.SetRequiredMessage(this.txtNeoporezivoUsluge, "");
            this.txtNeoporezivoUsluge.Size = new System.Drawing.Size(102, 22);
            this.txtNeoporezivoUsluge.TabIndex = 1;
            this.txtNeoporezivoUsluge.Tag = "NEPODLEZE";
            this.txtNeoporezivoUsluge.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.txtNeoporezivoUsluge.MouseEnter += new System.EventHandler(this.mouseEnter_Text);


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
            this.errorProvider1.DataSource = this.bindingSourceIRA;
            // 
            // errorProviderValidator1
            // 
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.errorProviderValidator1.ToolTipProvider = null;
            // 
            // layoutManagerformIRA
            // 
            this.layoutManagerformIRA.AutoSize = true;
            this.layoutManagerformIRA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerformIRA.ColumnCount = 1;
            this.layoutManagerformIRA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformIRA.Controls.Add(this.Tab1, 0, 0);
            this.errorProviderValidator1.SetDisplayName(this.layoutManagerformIRA, "");
            this.layoutManagerformIRA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutManagerformIRA.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerformIRA.Name = "layoutManagerformIRA";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerformIRA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerformIRA, "");
            this.errorProviderValidator1.SetRequired(this.layoutManagerformIRA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerformIRA, "");
            this.layoutManagerformIRA.RowCount = 2;
            this.layoutManagerformIRA.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformIRA.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformIRA.Size = new System.Drawing.Size(890, 518);
            this.layoutManagerformIRA.TabIndex = 0;


            this.layoutManagerformIRA.Controls.Add(this.UserDefinedControl1, 0, 1);
            this.layoutManagerformIRA.SetColumnSpan(this.UserDefinedControl1, 1);
            this.layoutManagerformIRA.SetRowSpan(this.UserDefinedControl1, 1);

            // 
            // Tab1
            // 
            this.Tab1.Controls.Add(this.TabPage1);
            this.Tab1.Controls.Add(this.TabPage2);
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
            this.Tab1.Size = new System.Drawing.Size(880, 300);
            this.Tab1.TabIndex = 0;
            tab.TabPage = this.TabPage1;
            tab.Text = "Osnovni podaci";
            tab2.TabPage = this.TabPage2;
            tab2.Text = "PDV";
            this.Tab1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            tab,
            tab2});
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
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(876, 274);
            // 
            // UserDefinedControl1
            // 
            this.errorProviderValidator1.SetDisplayName(this.UserDefinedControl1, "");
            this.UserDefinedControl1.IraControlerfORM = null;
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
            // 
            // IRAFormUserControl
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.layoutManagerformIRA);
            this.errorProviderValidator1.SetDisplayName(this, "");
            this.Name = "IRAFormUserControl";
            this.errorProviderValidator1.SetRegularExpression(this, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this, "");
            this.errorProviderValidator1.SetRequired(this, false);
            this.errorProviderValidator1.SetRequiredMessage(this, "");
            this.Size = new System.Drawing.Size(890, 518);
            this.Load += new System.EventHandler(this.IRAFormUserControl_Load);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.layoutManagerTabPage1.ResumeLayout(false);
            this.layoutManagerTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textIRAGODIDGODINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceIRA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsIRADataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textIRABROJ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePickerIRADATUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePickerIRAVALUTA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textIRANAPOMENA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textIRAUKUPNO)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.layoutManagerTabPage2.ResumeLayout(false);
            this.layoutManagerTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textNEPODLEZE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textIDTIPIRA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textIZVOZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMEDJTRANS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textTUZEMSTVO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNULA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSN10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSN22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSN23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSTALO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOSN25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPDV25)).EndInit();
            //hrvoje
            ((System.ComponentModel.ISupportInitialize)(this.textPDV5)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.textOSN5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNeoporezivoUsluge)).EndInit();


            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.layoutManagerformIRA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tab1)).EndInit();
            this.Tab1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool InValidState()
        {
            if ((this.IRAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceIRA, this.IRAController.WorkItem, this))
            {
                return false;
            }
            if (!this.m_BaseMethods.IsDelete() && this.errorProviderValidator1.HasErrors)
            {
                return false;
            }
            return true;
        }

        private void IRAFormUserControl_GotFocus(object sender, EventArgs e)
        {
            this.textIRABROJ.TabIndex = 0x63;
        }

        private void IRAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.IRADescription;
            this.errorProvider1.ContainerControl = this;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIRADOKIDDOKUMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("DOKUMENT", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIRAPARTNERIDPARTNER(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("PARTNER", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.IRAController.WorkItem.Items.Contains("IRA|IRA"))
            {
                this.IRAController.WorkItem.Items.Add(this.bindingSourceIRA, "IRA|IRA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
            // MATIJA
            this.IRAController.WorkItem.Items.Add(this.UserDefinedControl1);
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsIRADataSet1.IRA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.m_Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.m_Mode;
                this.m_BaseMethods.FormLoadStyle();
                this.textIRAGODIDGODINE.ButtonsRight[0].Visible = false;
            }
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.IRAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.IRAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.IRAController.Update(this))
            {
                this.IRAController.DataSet = new IRADataSet();
                DataSetUtil.AddEmptyRow(this.IRAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.IRAController.DataSet.IRA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedIRADOKIDDOKUMENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIRADOKIDDOKUMENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIRADOKIDDOKUMENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceIRA.Current).Row["IRADOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(row["IDDOKUMENT"]);
                    this.bindingSourceIRA.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedIRAPARTNERIDPARTNER(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIRAPARTNERIDPARTNER.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIRAPARTNERIDPARTNER.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceIRA.Current).Row["IRAPARTNERIDPARTNER"] = RuntimeHelpers.GetObjectValue(row["IDPARTNER"]);
                    this.bindingSourceIRA.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIRAGODIDGODINE.Focus();
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

        private void UpdateValuesGODINEIRAGODIDGODINE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceIRA.Current).Row["IRAGODIDGODINE"] = RuntimeHelpers.GetObjectValue(result["IDGODINE"]);
                this.bindingSourceIRA.ResetCurrentItem();
            }
        }

        private void UpdateValuesTIPIRAIDTIPIRA(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceIRA.Current).Row["IDTIPIRA"] = RuntimeHelpers.GetObjectValue(result["IDTIPIRA"]);
                this.bindingSourceIRA.ResetCurrentItem();
            }
        }

        private DOKUMENTComboBox comboIRADOKIDDOKUMENT;

        private PARTNERComboBox comboIRAPARTNERIDPARTNER;

        private ContextMenu contextMenu1;

        private UltraDateTimeEditor datePickerIRADATUM;

        private UltraDateTimeEditor datePickerIRAVALUTA;

        private ErrorProvider errorProvider1;

        private ErrorProviderValidator errorProviderValidator1;

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.IRAController IRAController { get; set; }

        private UltraLabel label1IDTIPIRA;

        private UltraLabel label1IRABROJ;

        private UltraLabel label1IRADATUM;

        private UltraLabel label1IRADOKIDDOKUMENT;

        private UltraLabel label1IRAGODIDGODINE;

        private UltraLabel label1IRANAPOMENA;

        private UltraLabel label1IRAPARTNERIDPARTNER;

        private UltraLabel label1IRAUKUPNO;

        private UltraLabel label1IRAVALUTA;

        private UltraLabel label1IZVOZ;

        private UltraLabel label1MEDJTRANS;

        private UltraLabel label1NEPODLEZE;

        private UltraLabel label1NULA;

        private UltraLabel label1OSN10;

        private UltraLabel label1OSN22;

        private UltraLabel label1OSN23;

        private UltraLabel label1OSTALO;

        private UltraLabel label1PDV10;

        private UltraLabel label1PDV22;

        private UltraLabel label1PDV23;

        private UltraLabel label1TUZEMSTVO;

        public DeklaritMode Mode;

        private MenuItem SetNullItem;

        private UltraTabControl Tab1;

        private UltraTabPageControl TabPage1;

        private UltraTabPageControl TabPage2;

        private UltraNumericEditor textIDTIPIRA;

        private UltraNumericEditor textIRABROJ;

        private UltraNumericEditor textIRAGODIDGODINE;

        private UltraTextEditor textIRANAPOMENA;

        private UltraNumericEditor textIRAUKUPNO;

        private UltraNumericEditor textIZVOZ;

        private UltraNumericEditor textMEDJTRANS;

        private UltraNumericEditor textNEPODLEZE;

        private UltraNumericEditor textNULA;

        private UltraNumericEditor textOSN10;

        private UltraNumericEditor textOSN22;

        private UltraNumericEditor textOSN23;

        private UltraNumericEditor textOSTALO;

        private UltraNumericEditor textPDV10;

        private UltraNumericEditor textPDV22;

        private UltraNumericEditor textPDV23;

        private UltraNumericEditor textTUZEMSTVO;

        private System.Windows.Forms.ToolTip toolTip1;

        private StavkeIre UserDefinedControl1;
    }
}

