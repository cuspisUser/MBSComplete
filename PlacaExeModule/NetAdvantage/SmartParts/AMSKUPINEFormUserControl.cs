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
    public class AMSKUPINEFormUserControl : UserControl, IBusinessComponentUserControl
    {
        private BindingSource bindingSourceAMSKUPINE;
        private IContainer components = null;
        private AMSKUPINEDataSet dsAMSKUPINEDataSet1;
        protected TableLayoutPanel layoutManagerformAMSKUPINE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private AMSKUPINEDataSet.AMSKUPINERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "AMSKUPINE";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.AMSKUPINEDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public AMSKUPINEFormUserControl()
        {
            this.InitializeComponent();

            // Deaktivaran poziv procedure Localize() koji (ovdje) samo prepisuje lables "Konto...".
            //this.Localize();

            this.SetSize();
        }

        private void AMSKUPINEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.AMSKUPINEDescription;
            this.errorProvider1.ContainerControl = this;
        }

        public void ChangeBinding()
        {
            this.bindingSourceAMSKUPINE.DataSource = this.Controller.DataSet;
            this.dsAMSKUPINEDataSet1 = this.Controller.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void comboKTOISPRAVKAIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            this.comboKTOISPRAVKAIDKONTO.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void comboKTOIZVORAIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            this.comboKTOIZVORAIDKONTO.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void comboKTONABAVKEIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            this.comboKTONABAVKEIDKONTO.Fill();
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
                    enumerator = this.dsAMSKUPINEDataSet1.AMSKUPINE.Rows.GetEnumerator();
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
                if (this.Controller.Update(this))
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
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "AMSKUPINE", this.m_Mode, this.dsAMSKUPINEDataSet1, this.dsAMSKUPINEDataSet1.AMSKUPINE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsAMSKUPINEDataSet1.AMSKUPINE[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (AMSKUPINEDataSet.AMSKUPINERow) ((DataRowView) this.bindingSourceAMSKUPINE.AddNew()).Row;
                foreach (string str in DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, foreignKeys))
                {
                    this.m_BaseMethods.SetReadOnly(str, true);
                    this.m_BaseMethods.GetLabelControl(str).Visible = false;
                    this.m_BaseMethods.GetControl(str).Visible = false;
                }
            }
            this.SetFocusInFirstField();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.SetNullItem = new System.Windows.Forms.MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSourceAMSKUPINE = new System.Windows.Forms.BindingSource(this.components);
            this.dsAMSKUPINEDataSet1 = new Placa.AMSKUPINEDataSet();
            this.errorProviderValidator1 = new Deklarit.Win.ErrorProviderValidator(this.components);
            this.layoutManagerformAMSKUPINE = new System.Windows.Forms.TableLayoutPanel();
            this.label1IDAMSKUPINE = new Infragistics.Win.Misc.UltraLabel();
            this.textIDAMSKUPINE = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1KRATKASIFRA = new Infragistics.Win.Misc.UltraLabel();
            this.textKRATKASIFRA = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1OPISAMSKUPINE = new Infragistics.Win.Misc.UltraLabel();
            this.textOPISAMSKUPINE = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1AMSKUPINASTOPA = new Infragistics.Win.Misc.UltraLabel();
            this.textAMSKUPINASTOPA = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label1KTONABAVKEIDKONTO = new Infragistics.Win.Misc.UltraLabel();
            this.comboKTONABAVKEIDKONTO = new NetAdvantage.Controls.KONTOComboBox();
            this.label1KTOISPRAVKAIDKONTO = new Infragistics.Win.Misc.UltraLabel();
            this.comboKTOISPRAVKAIDKONTO = new NetAdvantage.Controls.KONTOComboBox();
            this.label1KTOIZVORAIDKONTO = new Infragistics.Win.Misc.UltraLabel();
            this.comboKTOIZVORAIDKONTO = new NetAdvantage.Controls.KONTOComboBox();
            this.label1AM = new Infragistics.Win.Misc.UltraLabel();
            this.labelAM = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAMSKUPINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAMSKUPINEDataSet1)).BeginInit();
            this.layoutManagerformAMSKUPINE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textIDAMSKUPINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKRATKASIFRA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOPISAMSKUPINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textAMSKUPINASTOPA)).BeginInit();
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
            this.errorProvider1.DataSource = this.bindingSourceAMSKUPINE;
            // 
            // bindingSourceAMSKUPINE
            // 
            this.bindingSourceAMSKUPINE.DataMember = "AMSKUPINE";
            this.bindingSourceAMSKUPINE.DataSource = this.dsAMSKUPINEDataSet1;
            // 
            // dsAMSKUPINEDataSet1
            // 
            this.dsAMSKUPINEDataSet1.DataSetName = "dsAMSKUPINE";
            this.dsAMSKUPINEDataSet1.Locale = new System.Globalization.CultureInfo("hr-HR");
            // 
            // errorProviderValidator1
            // 
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            this.errorProviderValidator1.ToolTipProvider = null;
            // 
            // layoutManagerformAMSKUPINE
            // 
            this.layoutManagerformAMSKUPINE.AutoSize = true;
            this.layoutManagerformAMSKUPINE.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerformAMSKUPINE.ColumnCount = 2;
            this.layoutManagerformAMSKUPINE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformAMSKUPINE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformAMSKUPINE.Controls.Add(this.label1IDAMSKUPINE, 0, 0);
            this.layoutManagerformAMSKUPINE.Controls.Add(this.textIDAMSKUPINE, 1, 0);
            this.layoutManagerformAMSKUPINE.Controls.Add(this.label1KRATKASIFRA, 0, 1);
            this.layoutManagerformAMSKUPINE.Controls.Add(this.textKRATKASIFRA, 1, 1);
            this.layoutManagerformAMSKUPINE.Controls.Add(this.label1OPISAMSKUPINE, 0, 2);
            this.layoutManagerformAMSKUPINE.Controls.Add(this.textOPISAMSKUPINE, 1, 2);
            this.layoutManagerformAMSKUPINE.Controls.Add(this.label1AMSKUPINASTOPA, 0, 3);
            this.layoutManagerformAMSKUPINE.Controls.Add(this.textAMSKUPINASTOPA, 1, 3);
            this.layoutManagerformAMSKUPINE.Controls.Add(this.label1KTONABAVKEIDKONTO, 0, 4);
            this.layoutManagerformAMSKUPINE.Controls.Add(this.comboKTONABAVKEIDKONTO, 1, 4);
            this.layoutManagerformAMSKUPINE.Controls.Add(this.label1KTOISPRAVKAIDKONTO, 0, 5);
            this.layoutManagerformAMSKUPINE.Controls.Add(this.comboKTOISPRAVKAIDKONTO, 1, 5);
            this.layoutManagerformAMSKUPINE.Controls.Add(this.label1KTOIZVORAIDKONTO, 0, 6);
            this.layoutManagerformAMSKUPINE.Controls.Add(this.comboKTOIZVORAIDKONTO, 1, 6);
            this.layoutManagerformAMSKUPINE.Controls.Add(this.label1AM, 0, 7);
            this.layoutManagerformAMSKUPINE.Controls.Add(this.labelAM, 1, 7);
            this.errorProviderValidator1.SetDisplayName(this.layoutManagerformAMSKUPINE, "");
            this.layoutManagerformAMSKUPINE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutManagerformAMSKUPINE.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerformAMSKUPINE.Name = "layoutManagerformAMSKUPINE";
            this.errorProviderValidator1.SetRegularExpression(this.layoutManagerformAMSKUPINE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.layoutManagerformAMSKUPINE, "");
            this.errorProviderValidator1.SetRequired(this.layoutManagerformAMSKUPINE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.layoutManagerformAMSKUPINE, "");
            this.layoutManagerformAMSKUPINE.RowCount = 8;
            this.layoutManagerformAMSKUPINE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformAMSKUPINE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformAMSKUPINE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformAMSKUPINE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformAMSKUPINE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformAMSKUPINE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformAMSKUPINE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformAMSKUPINE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutManagerformAMSKUPINE.Size = new System.Drawing.Size(765, 225);
            this.layoutManagerformAMSKUPINE.TabIndex = 0;
            // 
            // label1IDAMSKUPINE
            // 
            this.label1IDAMSKUPINE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.TextVAlignAsString = "Middle";
            this.label1IDAMSKUPINE.Appearance = appearance1;
            this.label1IDAMSKUPINE.AutoSize = true;
            this.label1IDAMSKUPINE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1IDAMSKUPINE, "");
            this.label1IDAMSKUPINE.ImageSize = new System.Drawing.Size(7, 10);
            this.label1IDAMSKUPINE.Location = new System.Drawing.Point(3, 5);
            this.label1IDAMSKUPINE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1IDAMSKUPINE.Name = "label1IDAMSKUPINE";
            this.errorProviderValidator1.SetRegularExpression(this.label1IDAMSKUPINE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1IDAMSKUPINE, "");
            this.errorProviderValidator1.SetRequired(this.label1IDAMSKUPINE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1IDAMSKUPINE, "");
            this.label1IDAMSKUPINE.Size = new System.Drawing.Size(25, 14);
            this.label1IDAMSKUPINE.StyleSetName = "FieldUltraLabel";
            this.label1IDAMSKUPINE.TabIndex = 1;
            this.label1IDAMSKUPINE.Tag = "labelIDAMSKUPINE";
            this.label1IDAMSKUPINE.Text = "Šfr.:";
            // 
            // textIDAMSKUPINE
            // 
            this.textIDAMSKUPINE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textIDAMSKUPINE.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceAMSKUPINE, "IDAMSKUPINE", true));
            this.errorProviderValidator1.SetDisplayName(this.textIDAMSKUPINE, "");
            this.textIDAMSKUPINE.Location = new System.Drawing.Point(146, 1);
            this.textIDAMSKUPINE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textIDAMSKUPINE.MaskInput = "{LOC}-nnnnn";
            this.textIDAMSKUPINE.MinimumSize = new System.Drawing.Size(51, 22);
            this.textIDAMSKUPINE.Name = "textIDAMSKUPINE";
            this.textIDAMSKUPINE.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textIDAMSKUPINE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textIDAMSKUPINE, "");
            this.errorProviderValidator1.SetRequired(this.textIDAMSKUPINE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textIDAMSKUPINE, "");
            this.textIDAMSKUPINE.Size = new System.Drawing.Size(51, 22);
            this.textIDAMSKUPINE.TabIndex = 0;
            this.textIDAMSKUPINE.Tag = "IDAMSKUPINE";
            this.textIDAMSKUPINE.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textIDAMSKUPINE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1KRATKASIFRA
            // 
            this.label1KRATKASIFRA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.label1KRATKASIFRA.Appearance = appearance2;
            this.label1KRATKASIFRA.AutoSize = true;
            this.label1KRATKASIFRA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1KRATKASIFRA, "");
            this.label1KRATKASIFRA.Location = new System.Drawing.Point(3, 30);
            this.label1KRATKASIFRA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1KRATKASIFRA.Name = "label1KRATKASIFRA";
            this.errorProviderValidator1.SetRegularExpression(this.label1KRATKASIFRA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1KRATKASIFRA, "");
            this.errorProviderValidator1.SetRequired(this.label1KRATKASIFRA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1KRATKASIFRA, "");
            this.label1KRATKASIFRA.Size = new System.Drawing.Size(65, 14);
            this.label1KRATKASIFRA.StyleSetName = "FieldUltraLabel";
            this.label1KRATKASIFRA.TabIndex = 1;
            this.label1KRATKASIFRA.Tag = "labelKRATKASIFRA";
            this.label1KRATKASIFRA.Text = "Kratka šifra:";
            // 
            // textKRATKASIFRA
            // 
            this.textKRATKASIFRA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textKRATKASIFRA.ContextMenu = this.contextMenu1;
            this.textKRATKASIFRA.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceAMSKUPINE, "KRATKASIFRA", true));
            this.errorProviderValidator1.SetDisplayName(this.textKRATKASIFRA, "");
            this.textKRATKASIFRA.Location = new System.Drawing.Point(146, 26);
            this.textKRATKASIFRA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textKRATKASIFRA.MaxLength = 15;
            this.textKRATKASIFRA.MinimumSize = new System.Drawing.Size(121, 22);
            this.textKRATKASIFRA.Name = "textKRATKASIFRA";
            this.errorProviderValidator1.SetRegularExpression(this.textKRATKASIFRA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textKRATKASIFRA, "");
            this.errorProviderValidator1.SetRequired(this.textKRATKASIFRA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textKRATKASIFRA, "");
            this.textKRATKASIFRA.Size = new System.Drawing.Size(121, 22);
            this.textKRATKASIFRA.TabIndex = 0;
            this.textKRATKASIFRA.Tag = "KRATKASIFRA";
            this.textKRATKASIFRA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1OPISAMSKUPINE
            // 
            this.label1OPISAMSKUPINE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextVAlignAsString = "Middle";
            this.label1OPISAMSKUPINE.Appearance = appearance3;
            this.label1OPISAMSKUPINE.AutoSize = true;
            this.label1OPISAMSKUPINE.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1OPISAMSKUPINE, "");
            this.label1OPISAMSKUPINE.Location = new System.Drawing.Point(3, 55);
            this.label1OPISAMSKUPINE.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1OPISAMSKUPINE.Name = "label1OPISAMSKUPINE";
            this.errorProviderValidator1.SetRegularExpression(this.label1OPISAMSKUPINE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1OPISAMSKUPINE, "");
            this.errorProviderValidator1.SetRequired(this.label1OPISAMSKUPINE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1OPISAMSKUPINE, "");
            this.label1OPISAMSKUPINE.Size = new System.Drawing.Size(73, 14);
            this.label1OPISAMSKUPINE.StyleSetName = "FieldUltraLabel";
            this.label1OPISAMSKUPINE.TabIndex = 1;
            this.label1OPISAMSKUPINE.Tag = "labelOPISAMSKUPINE";
            this.label1OPISAMSKUPINE.Text = "Opis skupine:";
            // 
            // textOPISAMSKUPINE
            // 
            this.textOPISAMSKUPINE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textOPISAMSKUPINE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceAMSKUPINE, "OPISAMSKUPINE", true));
            this.errorProviderValidator1.SetDisplayName(this.textOPISAMSKUPINE, "");
            this.textOPISAMSKUPINE.Location = new System.Drawing.Point(146, 51);
            this.textOPISAMSKUPINE.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textOPISAMSKUPINE.MaxLength = 100;
            this.textOPISAMSKUPINE.MinimumSize = new System.Drawing.Size(576, 22);
            this.textOPISAMSKUPINE.Name = "textOPISAMSKUPINE";
            this.errorProviderValidator1.SetRegularExpression(this.textOPISAMSKUPINE, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textOPISAMSKUPINE, "");
            this.errorProviderValidator1.SetRequired(this.textOPISAMSKUPINE, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textOPISAMSKUPINE, "");
            this.textOPISAMSKUPINE.Size = new System.Drawing.Size(576, 22);
            this.textOPISAMSKUPINE.TabIndex = 0;
            this.textOPISAMSKUPINE.Tag = "OPISAMSKUPINE";
            this.textOPISAMSKUPINE.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1AMSKUPINASTOPA
            // 
            this.label1AMSKUPINASTOPA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextVAlignAsString = "Middle";
            this.label1AMSKUPINASTOPA.Appearance = appearance4;
            this.label1AMSKUPINASTOPA.AutoSize = true;
            this.label1AMSKUPINASTOPA.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1AMSKUPINASTOPA, "");
            this.label1AMSKUPINASTOPA.Location = new System.Drawing.Point(3, 80);
            this.label1AMSKUPINASTOPA.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1AMSKUPINASTOPA.Name = "label1AMSKUPINASTOPA";
            this.errorProviderValidator1.SetRegularExpression(this.label1AMSKUPINASTOPA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1AMSKUPINASTOPA, "");
            this.errorProviderValidator1.SetRequired(this.label1AMSKUPINASTOPA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1AMSKUPINASTOPA, "");
            this.label1AMSKUPINASTOPA.Size = new System.Drawing.Size(111, 14);
            this.label1AMSKUPINASTOPA.StyleSetName = "FieldUltraLabel";
            this.label1AMSKUPINASTOPA.TabIndex = 1;
            this.label1AMSKUPINASTOPA.Tag = "labelAMSKUPINASTOPA";
            this.label1AMSKUPINASTOPA.Text = "Amortizacijska stopa:";
            // 
            // textAMSKUPINASTOPA
            // 
            this.textAMSKUPINASTOPA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textAMSKUPINASTOPA.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceAMSKUPINE, "AMSKUPINASTOPA", true));
            this.errorProviderValidator1.SetDisplayName(this.textAMSKUPINASTOPA, "");
            this.textAMSKUPINASTOPA.Location = new System.Drawing.Point(146, 76);
            this.textAMSKUPINASTOPA.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.textAMSKUPINASTOPA.MaskInput = "{LOC}-nnn.nn";
            this.textAMSKUPINASTOPA.MinimumSize = new System.Drawing.Size(55, 22);
            this.textAMSKUPINASTOPA.Name = "textAMSKUPINASTOPA";
            this.textAMSKUPINASTOPA.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.textAMSKUPINASTOPA.PromptChar = ' ';
            this.errorProviderValidator1.SetRegularExpression(this.textAMSKUPINASTOPA, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.textAMSKUPINASTOPA, "");
            this.errorProviderValidator1.SetRequired(this.textAMSKUPINASTOPA, false);
            this.errorProviderValidator1.SetRequiredMessage(this.textAMSKUPINASTOPA, "");
            this.textAMSKUPINASTOPA.Size = new System.Drawing.Size(55, 22);
            this.textAMSKUPINASTOPA.TabIndex = 0;
            this.textAMSKUPINASTOPA.Tag = "AMSKUPINASTOPA";
            this.textAMSKUPINASTOPA.Enter += new System.EventHandler(this.numericEditor_Enter);
            this.textAMSKUPINASTOPA.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1KTONABAVKEIDKONTO
            // 
            this.label1KTONABAVKEIDKONTO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextVAlignAsString = "Middle";
            this.label1KTONABAVKEIDKONTO.Appearance = appearance5;
            this.label1KTONABAVKEIDKONTO.AutoSize = true;
            this.label1KTONABAVKEIDKONTO.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1KTONABAVKEIDKONTO, "");
            this.label1KTONABAVKEIDKONTO.Location = new System.Drawing.Point(3, 105);
            this.label1KTONABAVKEIDKONTO.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1KTONABAVKEIDKONTO.Name = "label1KTONABAVKEIDKONTO";
            this.errorProviderValidator1.SetRegularExpression(this.label1KTONABAVKEIDKONTO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1KTONABAVKEIDKONTO, "");
            this.errorProviderValidator1.SetRequired(this.label1KTONABAVKEIDKONTO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1KTONABAVKEIDKONTO, "");
            this.label1KTONABAVKEIDKONTO.Size = new System.Drawing.Size(138, 14);
            this.label1KTONABAVKEIDKONTO.StyleSetName = "FieldUltraLabel";
            this.label1KTONABAVKEIDKONTO.TabIndex = 1;
            this.label1KTONABAVKEIDKONTO.Tag = "labelKTONABAVKEIDKONTO";
            this.label1KTONABAVKEIDKONTO.Text = "Konto nabavne vrijednosti:";
            // 
            // comboKTONABAVKEIDKONTO
            // 
            this.comboKTONABAVKEIDKONTO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboKTONABAVKEIDKONTO.BackColor = System.Drawing.Color.Transparent;
            this.comboKTONABAVKEIDKONTO.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceAMSKUPINE, "KTONABAVKEIDKONTO", true));
            this.comboKTONABAVKEIDKONTO.DisplayMember = "KONT";
            this.errorProviderValidator1.SetDisplayName(this.comboKTONABAVKEIDKONTO, "");
            this.comboKTONABAVKEIDKONTO.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
            this.comboKTONABAVKEIDKONTO.FillByIDAKTIVNOSTIDAKTIVNOST = 0;
            this.comboKTONABAVKEIDKONTO.Location = new System.Drawing.Point(146, 101);
            this.comboKTONABAVKEIDKONTO.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.comboKTONABAVKEIDKONTO.MinimumSize = new System.Drawing.Size(616, 23);
            this.comboKTONABAVKEIDKONTO.Name = "comboKTONABAVKEIDKONTO";
            this.errorProviderValidator1.SetRegularExpression(this.comboKTONABAVKEIDKONTO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.comboKTONABAVKEIDKONTO, "");
            this.errorProviderValidator1.SetRequired(this.comboKTONABAVKEIDKONTO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.comboKTONABAVKEIDKONTO, "");
            this.comboKTONABAVKEIDKONTO.ShowPictureBox = true;
            this.comboKTONABAVKEIDKONTO.Size = new System.Drawing.Size(616, 23);
            this.comboKTONABAVKEIDKONTO.TabIndex = 0;
            this.comboKTONABAVKEIDKONTO.Tag = "KTONABAVKEIDKONTO";
            this.comboKTONABAVKEIDKONTO.ValueMember = "IDKONTO";
            this.comboKTONABAVKEIDKONTO.PictureBoxClicked += new System.EventHandler(this.PictureBoxClickedKTONABAVKEIDKONTO);
            this.comboKTONABAVKEIDKONTO.SelectionChanged += new System.EventHandler(this.SelectedIndexChangedKTONABAVKEIDKONTO);
            this.comboKTONABAVKEIDKONTO.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1KTOISPRAVKAIDKONTO
            // 
            this.label1KTOISPRAVKAIDKONTO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.label1KTOISPRAVKAIDKONTO.Appearance = appearance6;
            this.label1KTOISPRAVKAIDKONTO.AutoSize = true;
            this.label1KTOISPRAVKAIDKONTO.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1KTOISPRAVKAIDKONTO, "");
            this.label1KTOISPRAVKAIDKONTO.Location = new System.Drawing.Point(3, 131);
            this.label1KTOISPRAVKAIDKONTO.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1KTOISPRAVKAIDKONTO.Name = "label1KTOISPRAVKAIDKONTO";
            this.errorProviderValidator1.SetRegularExpression(this.label1KTOISPRAVKAIDKONTO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1KTOISPRAVKAIDKONTO, "");
            this.errorProviderValidator1.SetRequired(this.label1KTOISPRAVKAIDKONTO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1KTOISPRAVKAIDKONTO, "");
            this.label1KTOISPRAVKAIDKONTO.Size = new System.Drawing.Size(136, 14);
            this.label1KTOISPRAVKAIDKONTO.StyleSetName = "FieldUltraLabel";
            this.label1KTOISPRAVKAIDKONTO.TabIndex = 1;
            this.label1KTOISPRAVKAIDKONTO.Tag = "labelKTOISPRAVKAIDKONTO";
            this.label1KTOISPRAVKAIDKONTO.Text = "Konto ispravka vrijednosti:";
            // 
            // comboKTOISPRAVKAIDKONTO
            // 
            this.comboKTOISPRAVKAIDKONTO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboKTOISPRAVKAIDKONTO.BackColor = System.Drawing.Color.Transparent;
            this.comboKTOISPRAVKAIDKONTO.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceAMSKUPINE, "KTOISPRAVKAIDKONTO", true));
            this.comboKTOISPRAVKAIDKONTO.DisplayMember = "KONT";
            this.errorProviderValidator1.SetDisplayName(this.comboKTOISPRAVKAIDKONTO, "");
            this.comboKTOISPRAVKAIDKONTO.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
            this.comboKTOISPRAVKAIDKONTO.FillByIDAKTIVNOSTIDAKTIVNOST = 0;
            this.comboKTOISPRAVKAIDKONTO.Location = new System.Drawing.Point(146, 127);
            this.comboKTOISPRAVKAIDKONTO.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.comboKTOISPRAVKAIDKONTO.MinimumSize = new System.Drawing.Size(616, 23);
            this.comboKTOISPRAVKAIDKONTO.Name = "comboKTOISPRAVKAIDKONTO";
            this.errorProviderValidator1.SetRegularExpression(this.comboKTOISPRAVKAIDKONTO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.comboKTOISPRAVKAIDKONTO, "");
            this.errorProviderValidator1.SetRequired(this.comboKTOISPRAVKAIDKONTO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.comboKTOISPRAVKAIDKONTO, "");
            this.comboKTOISPRAVKAIDKONTO.ShowPictureBox = true;
            this.comboKTOISPRAVKAIDKONTO.Size = new System.Drawing.Size(616, 23);
            this.comboKTOISPRAVKAIDKONTO.TabIndex = 0;
            this.comboKTOISPRAVKAIDKONTO.Tag = "KTOISPRAVKAIDKONTO";
            this.comboKTOISPRAVKAIDKONTO.ValueMember = "IDKONTO";
            this.comboKTOISPRAVKAIDKONTO.PictureBoxClicked += new System.EventHandler(this.PictureBoxClickedKTOISPRAVKAIDKONTO);
            this.comboKTOISPRAVKAIDKONTO.SelectionChanged += new System.EventHandler(this.SelectedIndexChangedKTOISPRAVKAIDKONTO);
            this.comboKTOISPRAVKAIDKONTO.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1KTOIZVORAIDKONTO
            // 
            this.label1KTOIZVORAIDKONTO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.label1KTOIZVORAIDKONTO.Appearance = appearance7;
            this.label1KTOIZVORAIDKONTO.AutoSize = true;
            this.label1KTOIZVORAIDKONTO.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1KTOIZVORAIDKONTO, "");
            this.label1KTOIZVORAIDKONTO.Location = new System.Drawing.Point(3, 157);
            this.label1KTOIZVORAIDKONTO.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1KTOIZVORAIDKONTO.Name = "label1KTOIZVORAIDKONTO";
            this.errorProviderValidator1.SetRegularExpression(this.label1KTOIZVORAIDKONTO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1KTOIZVORAIDKONTO, "");
            this.errorProviderValidator1.SetRequired(this.label1KTOIZVORAIDKONTO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1KTOIZVORAIDKONTO, "");
            this.label1KTOIZVORAIDKONTO.Size = new System.Drawing.Size(123, 14);
            this.label1KTOIZVORAIDKONTO.StyleSetName = "FieldUltraLabel";
            this.label1KTOIZVORAIDKONTO.TabIndex = 1;
            this.label1KTOIZVORAIDKONTO.Tag = "labelKTOIZVORAIDKONTO";
            this.label1KTOIZVORAIDKONTO.Text = "Konto izvora vlasništva:";
            // 
            // comboKTOIZVORAIDKONTO
            // 
            this.comboKTOIZVORAIDKONTO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboKTOIZVORAIDKONTO.BackColor = System.Drawing.Color.Transparent;
            this.comboKTOIZVORAIDKONTO.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceAMSKUPINE, "KTOIZVORAIDKONTO", true));
            this.comboKTOIZVORAIDKONTO.DisplayMember = "KONT";
            this.errorProviderValidator1.SetDisplayName(this.comboKTOIZVORAIDKONTO, "");
            this.comboKTOIZVORAIDKONTO.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
            this.comboKTOIZVORAIDKONTO.FillByIDAKTIVNOSTIDAKTIVNOST = 0;
            this.comboKTOIZVORAIDKONTO.Location = new System.Drawing.Point(146, 153);
            this.comboKTOIZVORAIDKONTO.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.comboKTOIZVORAIDKONTO.MinimumSize = new System.Drawing.Size(616, 23);
            this.comboKTOIZVORAIDKONTO.Name = "comboKTOIZVORAIDKONTO";
            this.errorProviderValidator1.SetRegularExpression(this.comboKTOIZVORAIDKONTO, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.comboKTOIZVORAIDKONTO, "");
            this.errorProviderValidator1.SetRequired(this.comboKTOIZVORAIDKONTO, false);
            this.errorProviderValidator1.SetRequiredMessage(this.comboKTOIZVORAIDKONTO, "");
            this.comboKTOIZVORAIDKONTO.ShowPictureBox = true;
            this.comboKTOIZVORAIDKONTO.Size = new System.Drawing.Size(616, 23);
            this.comboKTOIZVORAIDKONTO.TabIndex = 0;
            this.comboKTOIZVORAIDKONTO.Tag = "KTOIZVORAIDKONTO";
            this.comboKTOIZVORAIDKONTO.ValueMember = "IDKONTO";
            this.comboKTOIZVORAIDKONTO.PictureBoxClicked += new System.EventHandler(this.PictureBoxClickedKTOIZVORAIDKONTO);
            this.comboKTOIZVORAIDKONTO.SelectionChanged += new System.EventHandler(this.SelectedIndexChangedKTOIZVORAIDKONTO);
            this.comboKTOIZVORAIDKONTO.MouseEnter += new System.EventHandler(this.mouseEnter_Text);
            // 
            // label1AM
            // 
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.label1AM.Appearance = appearance8;
            this.label1AM.AutoSize = true;
            this.label1AM.BackColorInternal = System.Drawing.Color.Transparent;
            this.errorProviderValidator1.SetDisplayName(this.label1AM, "");
            this.label1AM.Location = new System.Drawing.Point(3, 179);
            this.label1AM.Margin = new System.Windows.Forms.Padding(3, 1, 5, 2);
            this.label1AM.Name = "label1AM";
            this.errorProviderValidator1.SetRegularExpression(this.label1AM, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.label1AM, "");
            this.errorProviderValidator1.SetRequired(this.label1AM, false);
            this.errorProviderValidator1.SetRequiredMessage(this.label1AM, "");
            this.label1AM.Size = new System.Drawing.Size(24, 14);
            this.label1AM.StyleSetName = "FieldUltraLabel";
            this.label1AM.TabIndex = 1;
            this.label1AM.Tag = "labelAM";
            this.label1AM.Text = "AM:";
            // 
            // labelAM
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.labelAM.Appearance = appearance9;
            this.labelAM.BackColorInternal = System.Drawing.Color.Transparent;
            this.labelAM.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceAMSKUPINE, "AM", true));
            this.errorProviderValidator1.SetDisplayName(this.labelAM, "");
            this.labelAM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAM.Location = new System.Drawing.Point(146, 179);
            this.labelAM.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.labelAM.MinimumSize = new System.Drawing.Size(576, 44);
            this.labelAM.Name = "labelAM";
            this.errorProviderValidator1.SetRegularExpression(this.labelAM, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this.labelAM, "");
            this.errorProviderValidator1.SetRequired(this.labelAM, false);
            this.errorProviderValidator1.SetRequiredMessage(this.labelAM, "");
            this.labelAM.Size = new System.Drawing.Size(616, 44);
            this.labelAM.TabIndex = 0;
            this.labelAM.Tag = "AM";
            // 
            // AMSKUPINEFormUserControl
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.layoutManagerformAMSKUPINE);
            this.errorProviderValidator1.SetDisplayName(this, "");
            this.Name = "AMSKUPINEFormUserControl";
            this.errorProviderValidator1.SetRegularExpression(this, "");
            this.errorProviderValidator1.SetRegularExpressionMessage(this, "");
            this.errorProviderValidator1.SetRequired(this, false);
            this.errorProviderValidator1.SetRequiredMessage(this, "");
            this.Size = new System.Drawing.Size(765, 225);
            this.Load += new System.EventHandler(this.AMSKUPINEFormUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAMSKUPINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAMSKUPINEDataSet1)).EndInit();
            this.layoutManagerformAMSKUPINE.ResumeLayout(false);
            this.layoutManagerformAMSKUPINE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textIDAMSKUPINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textKRATKASIFRA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOPISAMSKUPINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textAMSKUPINASTOPA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool InValidState()
        {
            if ((this.Controller.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceAMSKUPINE, this.Controller.WorkItem, this))
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
            this.label1IDAMSKUPINE.Text = StringResources.AMSKUPINEIDAMSKUPINEDescription;
            this.label1KRATKASIFRA.Text = StringResources.AMSKUPINEKRATKASIFRADescription;
            this.label1OPISAMSKUPINE.Text = StringResources.AMSKUPINEOPISAMSKUPINEDescription;
            this.label1AMSKUPINASTOPA.Text = StringResources.AMSKUPINEAMSKUPINASTOPADescription;
            this.label1KTONABAVKEIDKONTO.Text = StringResources.AMSKUPINEKTONABAVKEIDKONTODescription;
            this.label1KTOISPRAVKAIDKONTO.Text = StringResources.AMSKUPINEKTOISPRAVKAIDKONTODescription;
            this.label1KTOIZVORAIDKONTO.Text = StringResources.AMSKUPINEKTOIZVORAIDKONTODescription;
            this.label1AM.Text = StringResources.AMSKUPINEAMDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewOS")]
        public void NewOSHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.NewOS(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedKTOISPRAVKAIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedKTOIZVORAIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedKTONABAVKEIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.Controller.WorkItem.Items.Contains("AMSKUPINE|AMSKUPINE"))
            {
                this.Controller.WorkItem.Items.Add(this.bindingSourceAMSKUPINE, "AMSKUPINE|AMSKUPINE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsAMSKUPINEDataSet1.AMSKUPINE.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.Controller.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.Controller.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.Controller.Update(this))
            {
                this.Controller.DataSet = new AMSKUPINEDataSet();
                DataSetUtil.AddEmptyRow(this.Controller.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.Controller.DataSet.AMSKUPINE[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedKTOISPRAVKAIDKONTO(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboKTOISPRAVKAIDKONTO.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboKTOISPRAVKAIDKONTO.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceAMSKUPINE.Current).Row["KTOISPRAVKAIDKONTO"] = RuntimeHelpers.GetObjectValue(row["IDKONTO"]);
                    this.bindingSourceAMSKUPINE.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedKTOIZVORAIDKONTO(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboKTOIZVORAIDKONTO.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboKTOIZVORAIDKONTO.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceAMSKUPINE.Current).Row["KTOIZVORAIDKONTO"] = RuntimeHelpers.GetObjectValue(row["IDKONTO"]);
                    this.bindingSourceAMSKUPINE.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedKTONABAVKEIDKONTO(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboKTONABAVKEIDKONTO.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboKTONABAVKEIDKONTO.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceAMSKUPINE.Current).Row["KTONABAVKEIDKONTO"] = RuntimeHelpers.GetObjectValue(row["IDKONTO"]);
                    this.bindingSourceAMSKUPINE.ResetCurrentItem();
                }
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDAMSKUPINE.Focus();
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

        [LocalCommandHandler("ViewOS")]
        public void ViewOSHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.ViewOS(this.m_CurrentRow);
            }
        }

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.AMSKUPINEController Controller { get; set; }

        private KONTOComboBox comboKTOISPRAVKAIDKONTO;

        private KONTOComboBox comboKTOIZVORAIDKONTO;

        private KONTOComboBox comboKTONABAVKEIDKONTO;

        private ContextMenu contextMenu1;

        private ErrorProvider errorProvider1;

        private ErrorProviderValidator errorProviderValidator1;

        private UltraLabel label1AM;

        private UltraLabel label1AMSKUPINASTOPA;

        private UltraLabel label1IDAMSKUPINE;

        private UltraLabel label1KRATKASIFRA;

        private UltraLabel label1KTOISPRAVKAIDKONTO;

        private UltraLabel label1KTOIZVORAIDKONTO;

        private UltraLabel label1KTONABAVKEIDKONTO;

        private UltraLabel label1OPISAMSKUPINE;

        private UltraLabel labelAM;

        public DeklaritMode Mode;

        private MenuItem SetNullItem;

        private UltraNumericEditor textAMSKUPINASTOPA;

        private UltraNumericEditor textIDAMSKUPINE;

        private UltraTextEditor textKRATKASIFRA;

        private UltraTextEditor textOPISAMSKUPINE;

        private System.Windows.Forms.ToolTip toolTip1;
    }
}

