namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Win;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI;
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
    public class RSMAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelRSMA1")]
        private UltraGrid _grdLevelRSMA1;
        [AccessedThroughProperty("label1ADRESA")]
        private UltraLabel _label1ADRESA;
        [AccessedThroughProperty("label1BROJOSIGURANIKA")]
        private UltraLabel _label1BROJOSIGURANIKA;
        [AccessedThroughProperty("label1godinaisplatersm")]
        private UltraLabel _label1godinaisplatersm;
        [AccessedThroughProperty("label1godinaobracunarsm")]
        private UltraLabel _label1godinaobracunarsm;
        [AccessedThroughProperty("label1IDENTIFIKATOROBRASCA")]
        private UltraLabel _label1IDENTIFIKATOROBRASCA;
        [AccessedThroughProperty("label1IDOBRACUN")]
        private UltraLabel _label1IDOBRACUN;
        [AccessedThroughProperty("label1IDRSVRSTEOBRACUNA")]
        private UltraLabel _label1IDRSVRSTEOBRACUNA;
        [AccessedThroughProperty("label1IDRSVRSTEOBVEZNIKA")]
        private UltraLabel _label1IDRSVRSTEOBVEZNIKA;
        [AccessedThroughProperty("label1IZNOSISPLACENEPLACE")]
        private UltraLabel _label1IZNOSISPLACENEPLACE;
        [AccessedThroughProperty("label1IZNOSOBRACUNANEPLACE")]
        private UltraLabel _label1IZNOSOBRACUNANEPLACE;
        [AccessedThroughProperty("label1IZNOSOSNOVICEZADOPRINOSE")]
        private UltraLabel _label1IZNOSOSNOVICEZADOPRINOSE;
        [AccessedThroughProperty("label1MBGOBVEZNIKA")]
        private UltraLabel _label1MBGOBVEZNIKA;
        [AccessedThroughProperty("label1MBOBVEZNIKA")]
        private UltraLabel _label1MBOBVEZNIKA;
        [AccessedThroughProperty("label1MIO1")]
        private UltraLabel _label1MIO1;
        [AccessedThroughProperty("label1MIO2")]
        private UltraLabel _label1MIO2;
        [AccessedThroughProperty("label1mjesecisplatersm")]
        private UltraLabel _label1mjesecisplatersm;
        [AccessedThroughProperty("label1mjesecoBRACUNArsm")]
        private UltraLabel _label1mjesecoBRACUNArsm;
        [AccessedThroughProperty("label1NAZIVOBVEZNIKA")]
        private UltraLabel _label1NAZIVOBVEZNIKA;
        [AccessedThroughProperty("label1NAZIVRSVRSTEOBRACUNA")]
        private UltraLabel _label1NAZIVRSVRSTEOBRACUNA;
        [AccessedThroughProperty("label1NAZIVRSVRSTEOBVEZNIKA")]
        private UltraLabel _label1NAZIVRSVRSTEOBVEZNIKA;
        [AccessedThroughProperty("labelIZNOSISPLACENEPLACE")]
        private UltraLabel _labelIZNOSISPLACENEPLACE;
        [AccessedThroughProperty("labelIZNOSOBRACUNANEPLACE")]
        private UltraLabel _labelIZNOSOBRACUNANEPLACE;
        [AccessedThroughProperty("labelIZNOSOSNOVICEZADOPRINOSE")]
        private UltraLabel _labelIZNOSOSNOVICEZADOPRINOSE;
        [AccessedThroughProperty("labelMIO1")]
        private UltraLabel _labelMIO1;
        [AccessedThroughProperty("labelMIO2")]
        private UltraLabel _labelMIO2;
        [AccessedThroughProperty("labelNAZIVRSVRSTEOBRACUNA")]
        private UltraLabel _labelNAZIVRSVRSTEOBRACUNA;
        [AccessedThroughProperty("labelNAZIVRSVRSTEOBVEZNIKA")]
        private UltraLabel _labelNAZIVRSVRSTEOBVEZNIKA;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textADRESA")]
        private UltraTextEditor _textADRESA;
        [AccessedThroughProperty("textBROJOSIGURANIKA")]
        private UltraTextEditor _textBROJOSIGURANIKA;
        [AccessedThroughProperty("textgodinaisplatersm")]
        private UltraTextEditor _textgodinaisplatersm;
        [AccessedThroughProperty("textgodinaobracunarsm")]
        private UltraTextEditor _textgodinaobracunarsm;
        [AccessedThroughProperty("textIDENTIFIKATOROBRASCA")]
        private UltraTextEditor _textIDENTIFIKATOROBRASCA;
        [AccessedThroughProperty("textIDOBRACUN")]
        private UltraTextEditor _textIDOBRACUN;
        [AccessedThroughProperty("textIDRSVRSTEOBRACUNA")]
        private UltraTextEditor _textIDRSVRSTEOBRACUNA;
        [AccessedThroughProperty("textIDRSVRSTEOBVEZNIKA")]
        private UltraTextEditor _textIDRSVRSTEOBVEZNIKA;
        [AccessedThroughProperty("textMBGOBVEZNIKA")]
        private UltraTextEditor _textMBGOBVEZNIKA;
        [AccessedThroughProperty("textMBOBVEZNIKA")]
        private UltraTextEditor _textMBOBVEZNIKA;
        [AccessedThroughProperty("textmjesecisplatersm")]
        private UltraTextEditor _textmjesecisplatersm;
        [AccessedThroughProperty("textmjesecoBRACUNArsm")]
        private UltraTextEditor _textmjesecoBRACUNArsm;
        [AccessedThroughProperty("textNAZIVOBVEZNIKA")]
        private UltraTextEditor _textNAZIVOBVEZNIKA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceRSMA;
        private BindingSource bindingSourceRSMA1;
        private IContainer components = null;
        private RSMADataSet dsRSMADataSet1;
        protected TableLayoutPanel layoutManagerformRSMA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private RSMADataSet.RSMARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "RSMA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.RSMADescription;
        private DeklaritMode m_Mode;

        public RSMAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptOBRACUNIDOBRACUN(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.RSMAController.SelectOBRACUNIDOBRACUN(fillMethod, fillByRow);
            this.UpdateValuesOBRACUNIDOBRACUN(result);
        }

        private void CallPromptRSVRSTEOBRACUNAIDRSVRSTEOBRACUNA(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.RSMAController.SelectRSVRSTEOBRACUNAIDRSVRSTEOBRACUNA(fillMethod, fillByRow);
            this.UpdateValuesRSVRSTEOBRACUNAIDRSVRSTEOBRACUNA(result);
        }

        private void CallPromptRSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKA(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.RSMAController.SelectRSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKA(fillMethod, fillByRow);
            this.UpdateValuesRSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKA(result);
        }

        private void CallViewOBRACUNIDOBRACUN(object sender, EventArgs e)
        {
            DataRow result = this.RSMAController.ShowOBRACUNIDOBRACUN(this.m_CurrentRow);
            this.UpdateValuesOBRACUNIDOBRACUN(result);
        }

        private void CallViewRSVRSTEOBRACUNAIDRSVRSTEOBRACUNA(object sender, EventArgs e)
        {
            DataRow result = this.RSMAController.ShowRSVRSTEOBRACUNAIDRSVRSTEOBRACUNA(this.m_CurrentRow);
            this.UpdateValuesRSVRSTEOBRACUNAIDRSVRSTEOBRACUNA(result);
        }

        private void CallViewRSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKA(object sender, EventArgs e)
        {
            DataRow result = this.RSMAController.ShowRSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKA(this.m_CurrentRow);
            this.UpdateValuesRSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKA(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsRSMADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceRSMA.DataSource = this.RSMAController.DataSet;
            this.dsRSMADataSet1 = this.RSMAController.DataSet;
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

        [LocalCommandHandler("DeleteInstance")]
        public void Delete(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.dsRSMADataSet1.RSMA.Rows.GetEnumerator();
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
                if (this.RSMAController.Update(this))
                {
                    this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
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

        private void EndEditCurrentRow()
        {
            if (this.grdLevelRSMA1.ActiveRow != null)
            {
                this.grdLevelRSMA1.PerformAction(UltraGridAction.NextRow);
            }
        }

        private void grdLevelRSMA1_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceRSMA.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceRSMA.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelRSMA1_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceRSMA, this.RSMAController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "RSMA", this.m_Mode, this.dsRSMADataSet1, this.dsRSMADataSet1.RSMA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding2 = new Binding("Text", this.bindingSourceRSMA, "IZNOSOBRACUNANEPLACE", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelIZNOSOBRACUNANEPLACE.DataBindings["Text"] != null)
            {
                this.labelIZNOSOBRACUNANEPLACE.DataBindings.Remove(this.labelIZNOSOBRACUNANEPLACE.DataBindings["Text"]);
            }
            this.labelIZNOSOBRACUNANEPLACE.DataBindings.Add(binding2);
            Binding binding3 = new Binding("Text", this.bindingSourceRSMA, "IZNOSOSNOVICEZADOPRINOSE", true);
            binding3.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelIZNOSOSNOVICEZADOPRINOSE.DataBindings["Text"] != null)
            {
                this.labelIZNOSOSNOVICEZADOPRINOSE.DataBindings.Remove(this.labelIZNOSOSNOVICEZADOPRINOSE.DataBindings["Text"]);
            }
            this.labelIZNOSOSNOVICEZADOPRINOSE.DataBindings.Add(binding3);
            Binding binding4 = new Binding("Text", this.bindingSourceRSMA, "MIO1", true);
            binding4.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelMIO1.DataBindings["Text"] != null)
            {
                this.labelMIO1.DataBindings.Remove(this.labelMIO1.DataBindings["Text"]);
            }
            this.labelMIO1.DataBindings.Add(binding4);
            Binding binding5 = new Binding("Text", this.bindingSourceRSMA, "MIO2", true);
            binding5.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelMIO2.DataBindings["Text"] != null)
            {
                this.labelMIO2.DataBindings.Remove(this.labelMIO2.DataBindings["Text"]);
            }
            this.labelMIO2.DataBindings.Add(binding5);
            Binding binding = new Binding("Text", this.bindingSourceRSMA, "IZNOSISPLACENEPLACE", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelIZNOSISPLACENEPLACE.DataBindings["Text"] != null)
            {
                this.labelIZNOSISPLACENEPLACE.DataBindings.Remove(this.labelIZNOSISPLACENEPLACE.DataBindings["Text"]);
            }
            this.labelIZNOSISPLACENEPLACE.DataBindings.Add(binding);
            if (!this.m_DataGrids.Contains(this.grdLevelRSMA1))
            {
                this.m_DataGrids.Add(this.grdLevelRSMA1);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsRSMADataSet1.RSMA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (RSMADataSet.RSMARow) ((DataRowView) this.bindingSourceRSMA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(RSMAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceRSMA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRSMA).BeginInit();
            this.bindingSourceRSMA1 = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceRSMA1).BeginInit();
            this.layoutManagerformRSMA = new TableLayoutPanel();
            this.layoutManagerformRSMA.SuspendLayout();
            this.layoutManagerformRSMA.AutoSize = true;
            this.layoutManagerformRSMA.Dock = DockStyle.Fill;
            this.layoutManagerformRSMA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformRSMA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformRSMA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformRSMA.Size = size;
            this.layoutManagerformRSMA.ColumnCount = 2;
            this.layoutManagerformRSMA.RowCount = 0x15;
            this.layoutManagerformRSMA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRSMA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.layoutManagerformRSMA.RowStyles.Add(new RowStyle());
            this.label1IDENTIFIKATOROBRASCA = new UltraLabel();
            this.textIDENTIFIKATOROBRASCA = new UltraTextEditor();
            this.label1IDOBRACUN = new UltraLabel();
            this.textIDOBRACUN = new UltraTextEditor();
            this.label1MBOBVEZNIKA = new UltraLabel();
            this.textMBOBVEZNIKA = new UltraTextEditor();
            this.label1MBGOBVEZNIKA = new UltraLabel();
            this.textMBGOBVEZNIKA = new UltraTextEditor();
            this.label1NAZIVOBVEZNIKA = new UltraLabel();
            this.textNAZIVOBVEZNIKA = new UltraTextEditor();
            this.label1ADRESA = new UltraLabel();
            this.textADRESA = new UltraTextEditor();
            this.label1IDRSVRSTEOBVEZNIKA = new UltraLabel();
            this.textIDRSVRSTEOBVEZNIKA = new UltraTextEditor();
            this.label1NAZIVRSVRSTEOBVEZNIKA = new UltraLabel();
            this.labelNAZIVRSVRSTEOBVEZNIKA = new UltraLabel();
            this.label1IDRSVRSTEOBRACUNA = new UltraLabel();
            this.textIDRSVRSTEOBRACUNA = new UltraTextEditor();
            this.label1NAZIVRSVRSTEOBRACUNA = new UltraLabel();
            this.labelNAZIVRSVRSTEOBRACUNA = new UltraLabel();
            this.label1mjesecoBRACUNArsm = new UltraLabel();
            this.textmjesecoBRACUNArsm = new UltraTextEditor();
            this.label1godinaobracunarsm = new UltraLabel();
            this.textgodinaobracunarsm = new UltraTextEditor();
            this.label1BROJOSIGURANIKA = new UltraLabel();
            this.textBROJOSIGURANIKA = new UltraTextEditor();
            this.label1IZNOSOBRACUNANEPLACE = new UltraLabel();
            this.labelIZNOSOBRACUNANEPLACE = new UltraLabel();
            this.label1IZNOSOSNOVICEZADOPRINOSE = new UltraLabel();
            this.labelIZNOSOSNOVICEZADOPRINOSE = new UltraLabel();
            this.label1MIO1 = new UltraLabel();
            this.labelMIO1 = new UltraLabel();
            this.label1MIO2 = new UltraLabel();
            this.labelMIO2 = new UltraLabel();
            this.label1IZNOSISPLACENEPLACE = new UltraLabel();
            this.labelIZNOSISPLACENEPLACE = new UltraLabel();
            this.label1mjesecisplatersm = new UltraLabel();
            this.textmjesecisplatersm = new UltraTextEditor();
            this.label1godinaisplatersm = new UltraLabel();
            this.textgodinaisplatersm = new UltraTextEditor();
            this.grdLevelRSMA1 = new UltraGrid();
            ((ISupportInitialize) this.textIDENTIFIKATOROBRASCA).BeginInit();
            ((ISupportInitialize) this.textIDOBRACUN).BeginInit();
            ((ISupportInitialize) this.textMBOBVEZNIKA).BeginInit();
            ((ISupportInitialize) this.textMBGOBVEZNIKA).BeginInit();
            ((ISupportInitialize) this.textNAZIVOBVEZNIKA).BeginInit();
            ((ISupportInitialize) this.textADRESA).BeginInit();
            ((ISupportInitialize) this.textIDRSVRSTEOBVEZNIKA).BeginInit();
            ((ISupportInitialize) this.textIDRSVRSTEOBRACUNA).BeginInit();
            ((ISupportInitialize) this.textmjesecoBRACUNArsm).BeginInit();
            ((ISupportInitialize) this.textgodinaobracunarsm).BeginInit();
            ((ISupportInitialize) this.textBROJOSIGURANIKA).BeginInit();
            ((ISupportInitialize) this.textmjesecisplatersm).BeginInit();
            ((ISupportInitialize) this.textgodinaisplatersm).BeginInit();
            ((ISupportInitialize) this.grdLevelRSMA1).BeginInit();
            UltraGridBand band = new UltraGridBand("RSMA1", -1);
            UltraGridColumn column4 = new UltraGridColumn("IDENTIFIKATOROBRASCA");
            UltraGridColumn column3 = new UltraGridColumn("ID");
            UltraGridColumn column14 = new UltraGridColumn("REDNIBROJ");
            UltraGridColumn column13 = new UltraGridColumn("PREZIMEIIME");
            UltraGridColumn column8 = new UltraGridColumn("MBGOSIGURANIKA");
            UltraGridColumn column15 = new UltraGridColumn("SIFRAGRADARADA");
            UltraGridColumn column12 = new UltraGridColumn("OO");
            UltraGridColumn column = new UltraGridColumn("B");
            UltraGridColumn column11 = new UltraGridColumn("OD");
            UltraGridColumn column2 = new UltraGridColumn("DOO");
            UltraGridColumn column6 = new UltraGridColumn("IZNOSOBRACUNANEPLACERSMB");
            UltraGridColumn column7 = new UltraGridColumn("IZNOSOSNOVICEZADOPRINOSERSMB");
            UltraGridColumn column9 = new UltraGridColumn("MIO1RSMB");
            UltraGridColumn column10 = new UltraGridColumn("MIO2RSMB");
            UltraGridColumn column5 = new UltraGridColumn("IZNOSISPLACENEPLACERSMB");
            this.dsRSMADataSet1 = new RSMADataSet();
            this.dsRSMADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsRSMADataSet1.DataSetName = "dsRSMA";
            this.dsRSMADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceRSMA.DataSource = this.dsRSMADataSet1;
            this.bindingSourceRSMA.DataMember = "RSMA";
            ((ISupportInitialize) this.bindingSourceRSMA).BeginInit();
            this.bindingSourceRSMA1.DataSource = this.bindingSourceRSMA;
            this.bindingSourceRSMA1.DataMember = "RSMA_RSMA1";
            point = new System.Drawing.Point(0, 0);
            this.label1IDENTIFIKATOROBRASCA.Location = point;
            this.label1IDENTIFIKATOROBRASCA.Name = "label1IDENTIFIKATOROBRASCA";
            this.label1IDENTIFIKATOROBRASCA.TabIndex = 1;
            this.label1IDENTIFIKATOROBRASCA.Tag = "labelIDENTIFIKATOROBRASCA";
            this.label1IDENTIFIKATOROBRASCA.Text = "IDENTIFIKATOROBRASCA:";
            this.label1IDENTIFIKATOROBRASCA.StyleSetName = "FieldUltraLabel";
            this.label1IDENTIFIKATOROBRASCA.AutoSize = true;
            this.label1IDENTIFIKATOROBRASCA.Anchor = AnchorStyles.Left;
            this.label1IDENTIFIKATOROBRASCA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDENTIFIKATOROBRASCA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDENTIFIKATOROBRASCA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDENTIFIKATOROBRASCA.ImageSize = size;
            this.label1IDENTIFIKATOROBRASCA.Appearance.ForeColor = Color.Black;
            this.label1IDENTIFIKATOROBRASCA.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1IDENTIFIKATOROBRASCA, 0, 0);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1IDENTIFIKATOROBRASCA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1IDENTIFIKATOROBRASCA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDENTIFIKATOROBRASCA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDENTIFIKATOROBRASCA.MinimumSize = size;
            size = new System.Drawing.Size(0xb2, 0x17);
            this.label1IDENTIFIKATOROBRASCA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDENTIFIKATOROBRASCA.Location = point;
            this.textIDENTIFIKATOROBRASCA.Name = "textIDENTIFIKATOROBRASCA";
            this.textIDENTIFIKATOROBRASCA.Tag = "IDENTIFIKATOROBRASCA";
            this.textIDENTIFIKATOROBRASCA.TabIndex = 0;
            this.textIDENTIFIKATOROBRASCA.Anchor = AnchorStyles.Left;
            this.textIDENTIFIKATOROBRASCA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDENTIFIKATOROBRASCA.ReadOnly = false;
            this.textIDENTIFIKATOROBRASCA.DataBindings.Add(new Binding("Text", this.bindingSourceRSMA, "IDENTIFIKATOROBRASCA"));
            this.textIDENTIFIKATOROBRASCA.MaxLength = 4;
            this.layoutManagerformRSMA.Controls.Add(this.textIDENTIFIKATOROBRASCA, 1, 0);
            this.layoutManagerformRSMA.SetColumnSpan(this.textIDENTIFIKATOROBRASCA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.textIDENTIFIKATOROBRASCA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDENTIFIKATOROBRASCA.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textIDENTIFIKATOROBRASCA.MinimumSize = size;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textIDENTIFIKATOROBRASCA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDOBRACUN.Location = point;
            this.label1IDOBRACUN.Name = "label1IDOBRACUN";
            this.label1IDOBRACUN.TabIndex = 1;
            this.label1IDOBRACUN.Tag = "labelIDOBRACUN";
            this.label1IDOBRACUN.Text = ":";
            this.label1IDOBRACUN.StyleSetName = "FieldUltraLabel";
            this.label1IDOBRACUN.AutoSize = true;
            this.label1IDOBRACUN.Anchor = AnchorStyles.Left;
            this.label1IDOBRACUN.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOBRACUN.Appearance.ForeColor = Color.Black;
            this.label1IDOBRACUN.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1IDOBRACUN, 0, 1);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1IDOBRACUN, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1IDOBRACUN, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOBRACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x13, 0x17);
            this.label1IDOBRACUN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDOBRACUN.Location = point;
            this.textIDOBRACUN.Name = "textIDOBRACUN";
            this.textIDOBRACUN.Tag = "IDOBRACUN";
            this.textIDOBRACUN.TabIndex = 0;
            this.textIDOBRACUN.Anchor = AnchorStyles.Left;
            this.textIDOBRACUN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDOBRACUN.ContextMenu = this.contextMenu1;
            this.textIDOBRACUN.ReadOnly = false;
            this.textIDOBRACUN.DataBindings.Add(new Binding("Text", this.bindingSourceRSMA, "IDOBRACUN"));
            this.textIDOBRACUN.Nullable = true;
            this.textIDOBRACUN.MaxLength = 11;
            EditorButton button = new EditorButton {
                Key = "editorButtonOBRACUNIDOBRACUN",
                Tag = "editorButtonOBRACUNIDOBRACUN",
                Text = "..."
            };
            this.textIDOBRACUN.ButtonsRight.Add(button);
            this.textIDOBRACUN.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOBRACUNIDOBRACUN);
            this.layoutManagerformRSMA.Controls.Add(this.textIDOBRACUN, 1, 1);
            this.layoutManagerformRSMA.SetColumnSpan(this.textIDOBRACUN, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.textIDOBRACUN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0x71, 0x16);
            this.textIDOBRACUN.MinimumSize = size;
            size = new System.Drawing.Size(0x71, 0x16);
            this.textIDOBRACUN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MBOBVEZNIKA.Location = point;
            this.label1MBOBVEZNIKA.Name = "label1MBOBVEZNIKA";
            this.label1MBOBVEZNIKA.TabIndex = 1;
            this.label1MBOBVEZNIKA.Tag = "labelMBOBVEZNIKA";
            this.label1MBOBVEZNIKA.Text = "MBOBVEZNIKA:";
            this.label1MBOBVEZNIKA.StyleSetName = "FieldUltraLabel";
            this.label1MBOBVEZNIKA.AutoSize = true;
            this.label1MBOBVEZNIKA.Anchor = AnchorStyles.Left;
            this.label1MBOBVEZNIKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MBOBVEZNIKA.Appearance.ForeColor = Color.Black;
            this.label1MBOBVEZNIKA.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1MBOBVEZNIKA, 0, 2);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1MBOBVEZNIKA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1MBOBVEZNIKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MBOBVEZNIKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MBOBVEZNIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x71, 0x17);
            this.label1MBOBVEZNIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMBOBVEZNIKA.Location = point;
            this.textMBOBVEZNIKA.Name = "textMBOBVEZNIKA";
            this.textMBOBVEZNIKA.Tag = "MBOBVEZNIKA";
            this.textMBOBVEZNIKA.TabIndex = 0;
            this.textMBOBVEZNIKA.Anchor = AnchorStyles.Left;
            this.textMBOBVEZNIKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMBOBVEZNIKA.ReadOnly = false;
            this.textMBOBVEZNIKA.DataBindings.Add(new Binding("Text", this.bindingSourceRSMA, "MBOBVEZNIKA"));
            this.textMBOBVEZNIKA.MaxLength = 13;
            this.layoutManagerformRSMA.Controls.Add(this.textMBOBVEZNIKA, 1, 2);
            this.layoutManagerformRSMA.SetColumnSpan(this.textMBOBVEZNIKA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.textMBOBVEZNIKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMBOBVEZNIKA.Margin = padding;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.textMBOBVEZNIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.textMBOBVEZNIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MBGOBVEZNIKA.Location = point;
            this.label1MBGOBVEZNIKA.Name = "label1MBGOBVEZNIKA";
            this.label1MBGOBVEZNIKA.TabIndex = 1;
            this.label1MBGOBVEZNIKA.Tag = "labelMBGOBVEZNIKA";
            this.label1MBGOBVEZNIKA.Text = "MBGOBVEZNIKA:";
            this.label1MBGOBVEZNIKA.StyleSetName = "FieldUltraLabel";
            this.label1MBGOBVEZNIKA.AutoSize = true;
            this.label1MBGOBVEZNIKA.Anchor = AnchorStyles.Left;
            this.label1MBGOBVEZNIKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1MBGOBVEZNIKA.Appearance.ForeColor = Color.Black;
            this.label1MBGOBVEZNIKA.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1MBGOBVEZNIKA, 0, 3);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1MBGOBVEZNIKA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1MBGOBVEZNIKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MBGOBVEZNIKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MBGOBVEZNIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x7a, 0x17);
            this.label1MBGOBVEZNIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMBGOBVEZNIKA.Location = point;
            this.textMBGOBVEZNIKA.Name = "textMBGOBVEZNIKA";
            this.textMBGOBVEZNIKA.Tag = "MBGOBVEZNIKA";
            this.textMBGOBVEZNIKA.TabIndex = 0;
            this.textMBGOBVEZNIKA.Anchor = AnchorStyles.Left;
            this.textMBGOBVEZNIKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMBGOBVEZNIKA.ReadOnly = false;
            this.textMBGOBVEZNIKA.DataBindings.Add(new Binding("Text", this.bindingSourceRSMA, "MBGOBVEZNIKA"));
            this.textMBGOBVEZNIKA.MaxLength = 13;
            this.layoutManagerformRSMA.Controls.Add(this.textMBGOBVEZNIKA, 1, 3);
            this.layoutManagerformRSMA.SetColumnSpan(this.textMBGOBVEZNIKA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.textMBGOBVEZNIKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMBGOBVEZNIKA.Margin = padding;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.textMBGOBVEZNIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.textMBGOBVEZNIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVOBVEZNIKA.Location = point;
            this.label1NAZIVOBVEZNIKA.Name = "label1NAZIVOBVEZNIKA";
            this.label1NAZIVOBVEZNIKA.TabIndex = 1;
            this.label1NAZIVOBVEZNIKA.Tag = "labelNAZIVOBVEZNIKA";
            this.label1NAZIVOBVEZNIKA.Text = "NAZIVOBVEZNIKA:";
            this.label1NAZIVOBVEZNIKA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVOBVEZNIKA.AutoSize = true;
            this.label1NAZIVOBVEZNIKA.Anchor = AnchorStyles.Left;
            this.label1NAZIVOBVEZNIKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVOBVEZNIKA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVOBVEZNIKA.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1NAZIVOBVEZNIKA, 0, 4);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1NAZIVOBVEZNIKA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1NAZIVOBVEZNIKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVOBVEZNIKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVOBVEZNIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x85, 0x17);
            this.label1NAZIVOBVEZNIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVOBVEZNIKA.Location = point;
            this.textNAZIVOBVEZNIKA.Name = "textNAZIVOBVEZNIKA";
            this.textNAZIVOBVEZNIKA.Tag = "NAZIVOBVEZNIKA";
            this.textNAZIVOBVEZNIKA.TabIndex = 0;
            this.textNAZIVOBVEZNIKA.Anchor = AnchorStyles.Left;
            this.textNAZIVOBVEZNIKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVOBVEZNIKA.ReadOnly = false;
            this.textNAZIVOBVEZNIKA.DataBindings.Add(new Binding("Text", this.bindingSourceRSMA, "NAZIVOBVEZNIKA"));
            this.textNAZIVOBVEZNIKA.MaxLength = 50;
            this.layoutManagerformRSMA.Controls.Add(this.textNAZIVOBVEZNIKA, 1, 4);
            this.layoutManagerformRSMA.SetColumnSpan(this.textNAZIVOBVEZNIKA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.textNAZIVOBVEZNIKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVOBVEZNIKA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVOBVEZNIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVOBVEZNIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1ADRESA.Location = point;
            this.label1ADRESA.Name = "label1ADRESA";
            this.label1ADRESA.TabIndex = 1;
            this.label1ADRESA.Tag = "labelADRESA";
            this.label1ADRESA.Text = "Adresa:";
            this.label1ADRESA.StyleSetName = "FieldUltraLabel";
            this.label1ADRESA.AutoSize = true;
            this.label1ADRESA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1ADRESA.Appearance.TextVAlign = VAlign.Middle;
            this.label1ADRESA.Appearance.ForeColor = Color.Black;
            this.label1ADRESA.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1ADRESA, 0, 5);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1ADRESA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1ADRESA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1ADRESA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1ADRESA.MinimumSize = size;
            size = new System.Drawing.Size(0x3e, 0x17);
            this.label1ADRESA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textADRESA.Location = point;
            this.textADRESA.Name = "textADRESA";
            this.textADRESA.Tag = "ADRESA";
            this.textADRESA.TabIndex = 0;
            this.textADRESA.Anchor = AnchorStyles.Left;
            this.textADRESA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textADRESA.ReadOnly = false;
            this.textADRESA.DataBindings.Add(new Binding("Text", this.bindingSourceRSMA, "ADRESA"));
            this.textADRESA.Multiline = true;
            this.textADRESA.MaxLength = 150;
            this.layoutManagerformRSMA.Controls.Add(this.textADRESA, 1, 5);
            this.layoutManagerformRSMA.SetColumnSpan(this.textADRESA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.textADRESA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textADRESA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.textADRESA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.textADRESA.Size = size;
            this.textADRESA.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.label1IDRSVRSTEOBVEZNIKA.Location = point;
            this.label1IDRSVRSTEOBVEZNIKA.Name = "label1IDRSVRSTEOBVEZNIKA";
            this.label1IDRSVRSTEOBVEZNIKA.TabIndex = 1;
            this.label1IDRSVRSTEOBVEZNIKA.Tag = "labelIDRSVRSTEOBVEZNIKA";
            this.label1IDRSVRSTEOBVEZNIKA.Text = "Šifra vrste obveznika:";
            this.label1IDRSVRSTEOBVEZNIKA.StyleSetName = "FieldUltraLabel";
            this.label1IDRSVRSTEOBVEZNIKA.AutoSize = true;
            this.label1IDRSVRSTEOBVEZNIKA.Anchor = AnchorStyles.Left;
            this.label1IDRSVRSTEOBVEZNIKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDRSVRSTEOBVEZNIKA.Appearance.ForeColor = Color.Black;
            this.label1IDRSVRSTEOBVEZNIKA.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1IDRSVRSTEOBVEZNIKA, 0, 6);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1IDRSVRSTEOBVEZNIKA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1IDRSVRSTEOBVEZNIKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDRSVRSTEOBVEZNIKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDRSVRSTEOBVEZNIKA.MinimumSize = size;
            size = new System.Drawing.Size(150, 0x17);
            this.label1IDRSVRSTEOBVEZNIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDRSVRSTEOBVEZNIKA.Location = point;
            this.textIDRSVRSTEOBVEZNIKA.Name = "textIDRSVRSTEOBVEZNIKA";
            this.textIDRSVRSTEOBVEZNIKA.Tag = "IDRSVRSTEOBVEZNIKA";
            this.textIDRSVRSTEOBVEZNIKA.TabIndex = 0;
            this.textIDRSVRSTEOBVEZNIKA.Anchor = AnchorStyles.Left;
            this.textIDRSVRSTEOBVEZNIKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDRSVRSTEOBVEZNIKA.ReadOnly = false;
            this.textIDRSVRSTEOBVEZNIKA.DataBindings.Add(new Binding("Text", this.bindingSourceRSMA, "IDRSVRSTEOBVEZNIKA"));
            this.textIDRSVRSTEOBVEZNIKA.MaxLength = 2;
            EditorButton button3 = new EditorButton {
                Key = "editorButtonRSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKA",
                Tag = "editorButtonRSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKA",
                Text = "..."
            };
            this.textIDRSVRSTEOBVEZNIKA.ButtonsRight.Add(button3);
            this.textIDRSVRSTEOBVEZNIKA.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptRSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKA);
            this.layoutManagerformRSMA.Controls.Add(this.textIDRSVRSTEOBVEZNIKA, 1, 6);
            this.layoutManagerformRSMA.SetColumnSpan(this.textIDRSVRSTEOBVEZNIKA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.textIDRSVRSTEOBVEZNIKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDRSVRSTEOBVEZNIKA.Margin = padding;
            size = new System.Drawing.Size(50, 0x16);
            this.textIDRSVRSTEOBVEZNIKA.MinimumSize = size;
            size = new System.Drawing.Size(50, 0x16);
            this.textIDRSVRSTEOBVEZNIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVRSVRSTEOBVEZNIKA.Location = point;
            this.label1NAZIVRSVRSTEOBVEZNIKA.Name = "label1NAZIVRSVRSTEOBVEZNIKA";
            this.label1NAZIVRSVRSTEOBVEZNIKA.TabIndex = 1;
            this.label1NAZIVRSVRSTEOBVEZNIKA.Tag = "labelNAZIVRSVRSTEOBVEZNIKA";
            this.label1NAZIVRSVRSTEOBVEZNIKA.Text = "Naziv vrste obveznika:";
            this.label1NAZIVRSVRSTEOBVEZNIKA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVRSVRSTEOBVEZNIKA.AutoSize = true;
            this.label1NAZIVRSVRSTEOBVEZNIKA.Anchor = AnchorStyles.Left;
            this.label1NAZIVRSVRSTEOBVEZNIKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVRSVRSTEOBVEZNIKA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVRSVRSTEOBVEZNIKA.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1NAZIVRSVRSTEOBVEZNIKA, 0, 7);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1NAZIVRSVRSTEOBVEZNIKA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1NAZIVRSVRSTEOBVEZNIKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVRSVRSTEOBVEZNIKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVRSVRSTEOBVEZNIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x9b, 0x17);
            this.label1NAZIVRSVRSTEOBVEZNIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVRSVRSTEOBVEZNIKA.Location = point;
            this.labelNAZIVRSVRSTEOBVEZNIKA.Name = "labelNAZIVRSVRSTEOBVEZNIKA";
            this.labelNAZIVRSVRSTEOBVEZNIKA.Tag = "NAZIVRSVRSTEOBVEZNIKA";
            this.labelNAZIVRSVRSTEOBVEZNIKA.TabIndex = 0;
            this.labelNAZIVRSVRSTEOBVEZNIKA.Anchor = AnchorStyles.Left;
            this.labelNAZIVRSVRSTEOBVEZNIKA.BackColor = Color.Transparent;
            this.labelNAZIVRSVRSTEOBVEZNIKA.DataBindings.Add(new Binding("Text", this.bindingSourceRSMA, "NAZIVRSVRSTEOBVEZNIKA"));
            this.labelNAZIVRSVRSTEOBVEZNIKA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRSMA.Controls.Add(this.labelNAZIVRSVRSTEOBVEZNIKA, 1, 7);
            this.layoutManagerformRSMA.SetColumnSpan(this.labelNAZIVRSVRSTEOBVEZNIKA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.labelNAZIVRSVRSTEOBVEZNIKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVRSVRSTEOBVEZNIKA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVRSVRSTEOBVEZNIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVRSVRSTEOBVEZNIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDRSVRSTEOBRACUNA.Location = point;
            this.label1IDRSVRSTEOBRACUNA.Name = "label1IDRSVRSTEOBRACUNA";
            this.label1IDRSVRSTEOBRACUNA.TabIndex = 1;
            this.label1IDRSVRSTEOBRACUNA.Tag = "labelIDRSVRSTEOBRACUNA";
            this.label1IDRSVRSTEOBRACUNA.Text = "Šifra vrste obraeuna:";
            this.label1IDRSVRSTEOBRACUNA.StyleSetName = "FieldUltraLabel";
            this.label1IDRSVRSTEOBRACUNA.AutoSize = true;
            this.label1IDRSVRSTEOBRACUNA.Anchor = AnchorStyles.Left;
            this.label1IDRSVRSTEOBRACUNA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDRSVRSTEOBRACUNA.Appearance.ForeColor = Color.Black;
            this.label1IDRSVRSTEOBRACUNA.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1IDRSVRSTEOBRACUNA, 0, 8);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1IDRSVRSTEOBRACUNA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1IDRSVRSTEOBRACUNA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDRSVRSTEOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDRSVRSTEOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(0x91, 0x17);
            this.label1IDRSVRSTEOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDRSVRSTEOBRACUNA.Location = point;
            this.textIDRSVRSTEOBRACUNA.Name = "textIDRSVRSTEOBRACUNA";
            this.textIDRSVRSTEOBRACUNA.Tag = "IDRSVRSTEOBRACUNA";
            this.textIDRSVRSTEOBRACUNA.TabIndex = 0;
            this.textIDRSVRSTEOBRACUNA.Anchor = AnchorStyles.Left;
            this.textIDRSVRSTEOBRACUNA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDRSVRSTEOBRACUNA.ReadOnly = false;
            this.textIDRSVRSTEOBRACUNA.DataBindings.Add(new Binding("Text", this.bindingSourceRSMA, "IDRSVRSTEOBRACUNA"));
            this.textIDRSVRSTEOBRACUNA.MaxLength = 2;
            EditorButton button2 = new EditorButton {
                Key = "editorButtonRSVRSTEOBRACUNAIDRSVRSTEOBRACUNA",
                Tag = "editorButtonRSVRSTEOBRACUNAIDRSVRSTEOBRACUNA",
                Text = "..."
            };
            this.textIDRSVRSTEOBRACUNA.ButtonsRight.Add(button2);
            this.textIDRSVRSTEOBRACUNA.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptRSVRSTEOBRACUNAIDRSVRSTEOBRACUNA);
            this.layoutManagerformRSMA.Controls.Add(this.textIDRSVRSTEOBRACUNA, 1, 8);
            this.layoutManagerformRSMA.SetColumnSpan(this.textIDRSVRSTEOBRACUNA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.textIDRSVRSTEOBRACUNA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDRSVRSTEOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(50, 0x16);
            this.textIDRSVRSTEOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(50, 0x16);
            this.textIDRSVRSTEOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVRSVRSTEOBRACUNA.Location = point;
            this.label1NAZIVRSVRSTEOBRACUNA.Name = "label1NAZIVRSVRSTEOBRACUNA";
            this.label1NAZIVRSVRSTEOBRACUNA.TabIndex = 1;
            this.label1NAZIVRSVRSTEOBRACUNA.Tag = "labelNAZIVRSVRSTEOBRACUNA";
            this.label1NAZIVRSVRSTEOBRACUNA.Text = "Naziv vrste obraeuna:";
            this.label1NAZIVRSVRSTEOBRACUNA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVRSVRSTEOBRACUNA.AutoSize = true;
            this.label1NAZIVRSVRSTEOBRACUNA.Anchor = AnchorStyles.Left;
            this.label1NAZIVRSVRSTEOBRACUNA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVRSVRSTEOBRACUNA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVRSVRSTEOBRACUNA.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1NAZIVRSVRSTEOBRACUNA, 0, 9);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1NAZIVRSVRSTEOBRACUNA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1NAZIVRSVRSTEOBRACUNA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVRSVRSTEOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVRSVRSTEOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(0x97, 0x17);
            this.label1NAZIVRSVRSTEOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVRSVRSTEOBRACUNA.Location = point;
            this.labelNAZIVRSVRSTEOBRACUNA.Name = "labelNAZIVRSVRSTEOBRACUNA";
            this.labelNAZIVRSVRSTEOBRACUNA.Tag = "NAZIVRSVRSTEOBRACUNA";
            this.labelNAZIVRSVRSTEOBRACUNA.TabIndex = 0;
            this.labelNAZIVRSVRSTEOBRACUNA.Anchor = AnchorStyles.Left;
            this.labelNAZIVRSVRSTEOBRACUNA.BackColor = Color.Transparent;
            this.labelNAZIVRSVRSTEOBRACUNA.DataBindings.Add(new Binding("Text", this.bindingSourceRSMA, "NAZIVRSVRSTEOBRACUNA"));
            this.labelNAZIVRSVRSTEOBRACUNA.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRSMA.Controls.Add(this.labelNAZIVRSVRSTEOBRACUNA, 1, 9);
            this.layoutManagerformRSMA.SetColumnSpan(this.labelNAZIVRSVRSTEOBRACUNA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.labelNAZIVRSVRSTEOBRACUNA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVRSVRSTEOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVRSVRSTEOBRACUNA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelNAZIVRSVRSTEOBRACUNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1mjesecoBRACUNArsm.Location = point;
            this.label1mjesecoBRACUNArsm.Name = "label1mjesecoBRACUNArsm";
            this.label1mjesecoBRACUNArsm.TabIndex = 1;
            this.label1mjesecoBRACUNArsm.Tag = "labelmjesecoBRACUNArsm";
            this.label1mjesecoBRACUNArsm.Text = "mjeseco BRACUN Arsm:";
            this.label1mjesecoBRACUNArsm.StyleSetName = "FieldUltraLabel";
            this.label1mjesecoBRACUNArsm.AutoSize = true;
            this.label1mjesecoBRACUNArsm.Anchor = AnchorStyles.Left;
            this.label1mjesecoBRACUNArsm.Appearance.TextVAlign = VAlign.Middle;
            this.label1mjesecoBRACUNArsm.Appearance.ForeColor = Color.Black;
            this.label1mjesecoBRACUNArsm.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1mjesecoBRACUNArsm, 0, 10);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1mjesecoBRACUNArsm, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1mjesecoBRACUNArsm, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1mjesecoBRACUNArsm.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1mjesecoBRACUNArsm.MinimumSize = size;
            size = new System.Drawing.Size(0xa2, 0x17);
            this.label1mjesecoBRACUNArsm.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textmjesecoBRACUNArsm.Location = point;
            this.textmjesecoBRACUNArsm.Name = "textmjesecoBRACUNArsm";
            this.textmjesecoBRACUNArsm.Tag = "mjesecoBRACUNArsm";
            this.textmjesecoBRACUNArsm.TabIndex = 0;
            this.textmjesecoBRACUNArsm.Anchor = AnchorStyles.Left;
            this.textmjesecoBRACUNArsm.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textmjesecoBRACUNArsm.ReadOnly = false;
            this.textmjesecoBRACUNArsm.DataBindings.Add(new Binding("Text", this.bindingSourceRSMA, "mjesecoBRACUNArsm"));
            this.textmjesecoBRACUNArsm.MaxLength = 2;
            this.layoutManagerformRSMA.Controls.Add(this.textmjesecoBRACUNArsm, 1, 10);
            this.layoutManagerformRSMA.SetColumnSpan(this.textmjesecoBRACUNArsm, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.textmjesecoBRACUNArsm, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textmjesecoBRACUNArsm.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textmjesecoBRACUNArsm.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textmjesecoBRACUNArsm.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1godinaobracunarsm.Location = point;
            this.label1godinaobracunarsm.Name = "label1godinaobracunarsm";
            this.label1godinaobracunarsm.TabIndex = 1;
            this.label1godinaobracunarsm.Tag = "labelgodinaobracunarsm";
            this.label1godinaobracunarsm.Text = "godinaobracunarsm:";
            this.label1godinaobracunarsm.StyleSetName = "FieldUltraLabel";
            this.label1godinaobracunarsm.AutoSize = true;
            this.label1godinaobracunarsm.Anchor = AnchorStyles.Left;
            this.label1godinaobracunarsm.Appearance.TextVAlign = VAlign.Middle;
            this.label1godinaobracunarsm.Appearance.ForeColor = Color.Black;
            this.label1godinaobracunarsm.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1godinaobracunarsm, 0, 11);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1godinaobracunarsm, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1godinaobracunarsm, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1godinaobracunarsm.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1godinaobracunarsm.MinimumSize = size;
            size = new System.Drawing.Size(0x8f, 0x17);
            this.label1godinaobracunarsm.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textgodinaobracunarsm.Location = point;
            this.textgodinaobracunarsm.Name = "textgodinaobracunarsm";
            this.textgodinaobracunarsm.Tag = "godinaobracunarsm";
            this.textgodinaobracunarsm.TabIndex = 0;
            this.textgodinaobracunarsm.Anchor = AnchorStyles.Left;
            this.textgodinaobracunarsm.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textgodinaobracunarsm.ReadOnly = false;
            this.textgodinaobracunarsm.DataBindings.Add(new Binding("Text", this.bindingSourceRSMA, "godinaobracunarsm"));
            this.textgodinaobracunarsm.MaxLength = 5;
            this.layoutManagerformRSMA.Controls.Add(this.textgodinaobracunarsm, 1, 11);
            this.layoutManagerformRSMA.SetColumnSpan(this.textgodinaobracunarsm, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.textgodinaobracunarsm, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textgodinaobracunarsm.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textgodinaobracunarsm.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textgodinaobracunarsm.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1BROJOSIGURANIKA.Location = point;
            this.label1BROJOSIGURANIKA.Name = "label1BROJOSIGURANIKA";
            this.label1BROJOSIGURANIKA.TabIndex = 1;
            this.label1BROJOSIGURANIKA.Tag = "labelBROJOSIGURANIKA";
            this.label1BROJOSIGURANIKA.Text = "BROJOSIGURANIKA:";
            this.label1BROJOSIGURANIKA.StyleSetName = "FieldUltraLabel";
            this.label1BROJOSIGURANIKA.AutoSize = true;
            this.label1BROJOSIGURANIKA.Anchor = AnchorStyles.Left;
            this.label1BROJOSIGURANIKA.Appearance.TextVAlign = VAlign.Middle;
            this.label1BROJOSIGURANIKA.Appearance.ForeColor = Color.Black;
            this.label1BROJOSIGURANIKA.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1BROJOSIGURANIKA, 0, 12);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1BROJOSIGURANIKA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1BROJOSIGURANIKA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BROJOSIGURANIKA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BROJOSIGURANIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x90, 0x17);
            this.label1BROJOSIGURANIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textBROJOSIGURANIKA.Location = point;
            this.textBROJOSIGURANIKA.Name = "textBROJOSIGURANIKA";
            this.textBROJOSIGURANIKA.Tag = "BROJOSIGURANIKA";
            this.textBROJOSIGURANIKA.TabIndex = 0;
            this.textBROJOSIGURANIKA.Anchor = AnchorStyles.Left;
            this.textBROJOSIGURANIKA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textBROJOSIGURANIKA.ReadOnly = false;
            this.textBROJOSIGURANIKA.DataBindings.Add(new Binding("Text", this.bindingSourceRSMA, "BROJOSIGURANIKA"));
            this.textBROJOSIGURANIKA.MaxLength = 5;
            this.layoutManagerformRSMA.Controls.Add(this.textBROJOSIGURANIKA, 1, 12);
            this.layoutManagerformRSMA.SetColumnSpan(this.textBROJOSIGURANIKA, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.textBROJOSIGURANIKA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBROJOSIGURANIKA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textBROJOSIGURANIKA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textBROJOSIGURANIKA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IZNOSOBRACUNANEPLACE.Location = point;
            this.label1IZNOSOBRACUNANEPLACE.Name = "label1IZNOSOBRACUNANEPLACE";
            this.label1IZNOSOBRACUNANEPLACE.TabIndex = 1;
            this.label1IZNOSOBRACUNANEPLACE.Tag = "labelIZNOSOBRACUNANEPLACE";
            this.label1IZNOSOBRACUNANEPLACE.Text = "IZNOSOBRACUNANEPLACE:";
            this.label1IZNOSOBRACUNANEPLACE.StyleSetName = "FieldUltraLabel";
            this.label1IZNOSOBRACUNANEPLACE.AutoSize = true;
            this.label1IZNOSOBRACUNANEPLACE.Anchor = AnchorStyles.Left;
            this.label1IZNOSOBRACUNANEPLACE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IZNOSOBRACUNANEPLACE.Appearance.ForeColor = Color.Black;
            this.label1IZNOSOBRACUNANEPLACE.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1IZNOSOBRACUNANEPLACE, 0, 13);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1IZNOSOBRACUNANEPLACE, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1IZNOSOBRACUNANEPLACE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IZNOSOBRACUNANEPLACE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IZNOSOBRACUNANEPLACE.MinimumSize = size;
            size = new System.Drawing.Size(0xbb, 0x17);
            this.label1IZNOSOBRACUNANEPLACE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelIZNOSOBRACUNANEPLACE.Location = point;
            this.labelIZNOSOBRACUNANEPLACE.Name = "labelIZNOSOBRACUNANEPLACE";
            this.labelIZNOSOBRACUNANEPLACE.Tag = "IZNOSOBRACUNANEPLACE";
            this.labelIZNOSOBRACUNANEPLACE.TabIndex = 0;
            this.labelIZNOSOBRACUNANEPLACE.Anchor = AnchorStyles.Left;
            this.labelIZNOSOBRACUNANEPLACE.BackColor = Color.Transparent;
            this.labelIZNOSOBRACUNANEPLACE.Appearance.TextHAlign = HAlign.Left;
            this.labelIZNOSOBRACUNANEPLACE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRSMA.Controls.Add(this.labelIZNOSOBRACUNANEPLACE, 1, 13);
            this.layoutManagerformRSMA.SetColumnSpan(this.labelIZNOSOBRACUNANEPLACE, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.labelIZNOSOBRACUNANEPLACE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelIZNOSOBRACUNANEPLACE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelIZNOSOBRACUNANEPLACE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelIZNOSOBRACUNANEPLACE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IZNOSOSNOVICEZADOPRINOSE.Location = point;
            this.label1IZNOSOSNOVICEZADOPRINOSE.Name = "label1IZNOSOSNOVICEZADOPRINOSE";
            this.label1IZNOSOSNOVICEZADOPRINOSE.TabIndex = 1;
            this.label1IZNOSOSNOVICEZADOPRINOSE.Tag = "labelIZNOSOSNOVICEZADOPRINOSE";
            this.label1IZNOSOSNOVICEZADOPRINOSE.Text = "IZNOSOSNOVICEZADOPRINOSE:";
            this.label1IZNOSOSNOVICEZADOPRINOSE.StyleSetName = "FieldUltraLabel";
            this.label1IZNOSOSNOVICEZADOPRINOSE.AutoSize = true;
            this.label1IZNOSOSNOVICEZADOPRINOSE.Anchor = AnchorStyles.Left;
            this.label1IZNOSOSNOVICEZADOPRINOSE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IZNOSOSNOVICEZADOPRINOSE.Appearance.ForeColor = Color.Black;
            this.label1IZNOSOSNOVICEZADOPRINOSE.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1IZNOSOSNOVICEZADOPRINOSE, 0, 14);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1IZNOSOSNOVICEZADOPRINOSE, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1IZNOSOSNOVICEZADOPRINOSE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IZNOSOSNOVICEZADOPRINOSE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IZNOSOSNOVICEZADOPRINOSE.MinimumSize = size;
            size = new System.Drawing.Size(0xdb, 0x17);
            this.label1IZNOSOSNOVICEZADOPRINOSE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelIZNOSOSNOVICEZADOPRINOSE.Location = point;
            this.labelIZNOSOSNOVICEZADOPRINOSE.Name = "labelIZNOSOSNOVICEZADOPRINOSE";
            this.labelIZNOSOSNOVICEZADOPRINOSE.Tag = "IZNOSOSNOVICEZADOPRINOSE";
            this.labelIZNOSOSNOVICEZADOPRINOSE.TabIndex = 0;
            this.labelIZNOSOSNOVICEZADOPRINOSE.Anchor = AnchorStyles.Left;
            this.labelIZNOSOSNOVICEZADOPRINOSE.BackColor = Color.Transparent;
            this.labelIZNOSOSNOVICEZADOPRINOSE.Appearance.TextHAlign = HAlign.Left;
            this.labelIZNOSOSNOVICEZADOPRINOSE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRSMA.Controls.Add(this.labelIZNOSOSNOVICEZADOPRINOSE, 1, 14);
            this.layoutManagerformRSMA.SetColumnSpan(this.labelIZNOSOSNOVICEZADOPRINOSE, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.labelIZNOSOSNOVICEZADOPRINOSE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelIZNOSOSNOVICEZADOPRINOSE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelIZNOSOSNOVICEZADOPRINOSE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelIZNOSOSNOVICEZADOPRINOSE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MIO1.Location = point;
            this.label1MIO1.Name = "label1MIO1";
            this.label1MIO1.TabIndex = 1;
            this.label1MIO1.Tag = "labelMIO1";
            this.label1MIO1.Text = "MI O1:";
            this.label1MIO1.StyleSetName = "FieldUltraLabel";
            this.label1MIO1.AutoSize = true;
            this.label1MIO1.Anchor = AnchorStyles.Left;
            this.label1MIO1.Appearance.TextVAlign = VAlign.Middle;
            this.label1MIO1.Appearance.ForeColor = Color.Black;
            this.label1MIO1.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1MIO1, 0, 15);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1MIO1, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1MIO1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MIO1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MIO1.MinimumSize = size;
            size = new System.Drawing.Size(0x39, 0x17);
            this.label1MIO1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelMIO1.Location = point;
            this.labelMIO1.Name = "labelMIO1";
            this.labelMIO1.Tag = "MIO1";
            this.labelMIO1.TabIndex = 0;
            this.labelMIO1.Anchor = AnchorStyles.Left;
            this.labelMIO1.BackColor = Color.Transparent;
            this.labelMIO1.Appearance.TextHAlign = HAlign.Left;
            this.labelMIO1.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRSMA.Controls.Add(this.labelMIO1, 1, 15);
            this.layoutManagerformRSMA.SetColumnSpan(this.labelMIO1, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.labelMIO1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelMIO1.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelMIO1.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelMIO1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MIO2.Location = point;
            this.label1MIO2.Name = "label1MIO2";
            this.label1MIO2.TabIndex = 1;
            this.label1MIO2.Tag = "labelMIO2";
            this.label1MIO2.Text = "MI O2:";
            this.label1MIO2.StyleSetName = "FieldUltraLabel";
            this.label1MIO2.AutoSize = true;
            this.label1MIO2.Anchor = AnchorStyles.Left;
            this.label1MIO2.Appearance.TextVAlign = VAlign.Middle;
            this.label1MIO2.Appearance.ForeColor = Color.Black;
            this.label1MIO2.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1MIO2, 0, 0x10);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1MIO2, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1MIO2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MIO2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MIO2.MinimumSize = size;
            size = new System.Drawing.Size(0x39, 0x17);
            this.label1MIO2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelMIO2.Location = point;
            this.labelMIO2.Name = "labelMIO2";
            this.labelMIO2.Tag = "MIO2";
            this.labelMIO2.TabIndex = 0;
            this.labelMIO2.Anchor = AnchorStyles.Left;
            this.labelMIO2.BackColor = Color.Transparent;
            this.labelMIO2.Appearance.TextHAlign = HAlign.Left;
            this.labelMIO2.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRSMA.Controls.Add(this.labelMIO2, 1, 0x10);
            this.layoutManagerformRSMA.SetColumnSpan(this.labelMIO2, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.labelMIO2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelMIO2.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelMIO2.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelMIO2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IZNOSISPLACENEPLACE.Location = point;
            this.label1IZNOSISPLACENEPLACE.Name = "label1IZNOSISPLACENEPLACE";
            this.label1IZNOSISPLACENEPLACE.TabIndex = 1;
            this.label1IZNOSISPLACENEPLACE.Tag = "labelIZNOSISPLACENEPLACE";
            this.label1IZNOSISPLACENEPLACE.Text = "IZNOSISPLACENEPLACE:";
            this.label1IZNOSISPLACENEPLACE.StyleSetName = "FieldUltraLabel";
            this.label1IZNOSISPLACENEPLACE.AutoSize = true;
            this.label1IZNOSISPLACENEPLACE.Anchor = AnchorStyles.Left;
            this.label1IZNOSISPLACENEPLACE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IZNOSISPLACENEPLACE.Appearance.ForeColor = Color.Black;
            this.label1IZNOSISPLACENEPLACE.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1IZNOSISPLACENEPLACE, 0, 0x11);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1IZNOSISPLACENEPLACE, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1IZNOSISPLACENEPLACE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IZNOSISPLACENEPLACE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IZNOSISPLACENEPLACE.MinimumSize = size;
            size = new System.Drawing.Size(0xa9, 0x17);
            this.label1IZNOSISPLACENEPLACE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelIZNOSISPLACENEPLACE.Location = point;
            this.labelIZNOSISPLACENEPLACE.Name = "labelIZNOSISPLACENEPLACE";
            this.labelIZNOSISPLACENEPLACE.Tag = "IZNOSISPLACENEPLACE";
            this.labelIZNOSISPLACENEPLACE.TabIndex = 0;
            this.labelIZNOSISPLACENEPLACE.Anchor = AnchorStyles.Left;
            this.labelIZNOSISPLACENEPLACE.BackColor = Color.Transparent;
            this.labelIZNOSISPLACENEPLACE.Appearance.TextHAlign = HAlign.Left;
            this.labelIZNOSISPLACENEPLACE.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformRSMA.Controls.Add(this.labelIZNOSISPLACENEPLACE, 1, 0x11);
            this.layoutManagerformRSMA.SetColumnSpan(this.labelIZNOSISPLACENEPLACE, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.labelIZNOSISPLACENEPLACE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelIZNOSISPLACENEPLACE.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelIZNOSISPLACENEPLACE.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.labelIZNOSISPLACENEPLACE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1mjesecisplatersm.Location = point;
            this.label1mjesecisplatersm.Name = "label1mjesecisplatersm";
            this.label1mjesecisplatersm.TabIndex = 1;
            this.label1mjesecisplatersm.Tag = "labelmjesecisplatersm";
            this.label1mjesecisplatersm.Text = "mjesecisplatersm:";
            this.label1mjesecisplatersm.StyleSetName = "FieldUltraLabel";
            this.label1mjesecisplatersm.AutoSize = true;
            this.label1mjesecisplatersm.Anchor = AnchorStyles.Left;
            this.label1mjesecisplatersm.Appearance.TextVAlign = VAlign.Middle;
            this.label1mjesecisplatersm.Appearance.ForeColor = Color.Black;
            this.label1mjesecisplatersm.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1mjesecisplatersm, 0, 0x12);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1mjesecisplatersm, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1mjesecisplatersm, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1mjesecisplatersm.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1mjesecisplatersm.MinimumSize = size;
            size = new System.Drawing.Size(0x80, 0x17);
            this.label1mjesecisplatersm.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textmjesecisplatersm.Location = point;
            this.textmjesecisplatersm.Name = "textmjesecisplatersm";
            this.textmjesecisplatersm.Tag = "mjesecisplatersm";
            this.textmjesecisplatersm.TabIndex = 0;
            this.textmjesecisplatersm.Anchor = AnchorStyles.Left;
            this.textmjesecisplatersm.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textmjesecisplatersm.ReadOnly = false;
            this.textmjesecisplatersm.DataBindings.Add(new Binding("Text", this.bindingSourceRSMA, "mjesecisplatersm"));
            this.textmjesecisplatersm.MaxLength = 2;
            this.layoutManagerformRSMA.Controls.Add(this.textmjesecisplatersm, 1, 0x12);
            this.layoutManagerformRSMA.SetColumnSpan(this.textmjesecisplatersm, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.textmjesecisplatersm, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textmjesecisplatersm.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textmjesecisplatersm.MinimumSize = size;
            size = new System.Drawing.Size(30, 0x16);
            this.textmjesecisplatersm.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1godinaisplatersm.Location = point;
            this.label1godinaisplatersm.Name = "label1godinaisplatersm";
            this.label1godinaisplatersm.TabIndex = 1;
            this.label1godinaisplatersm.Tag = "labelgodinaisplatersm";
            this.label1godinaisplatersm.Text = "godinaisplatersm:";
            this.label1godinaisplatersm.StyleSetName = "FieldUltraLabel";
            this.label1godinaisplatersm.AutoSize = true;
            this.label1godinaisplatersm.Anchor = AnchorStyles.Left;
            this.label1godinaisplatersm.Appearance.TextVAlign = VAlign.Middle;
            this.label1godinaisplatersm.Appearance.ForeColor = Color.Black;
            this.label1godinaisplatersm.BackColor = Color.Transparent;
            this.layoutManagerformRSMA.Controls.Add(this.label1godinaisplatersm, 0, 0x13);
            this.layoutManagerformRSMA.SetColumnSpan(this.label1godinaisplatersm, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.label1godinaisplatersm, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1godinaisplatersm.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1godinaisplatersm.MinimumSize = size;
            size = new System.Drawing.Size(0x7e, 0x17);
            this.label1godinaisplatersm.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textgodinaisplatersm.Location = point;
            this.textgodinaisplatersm.Name = "textgodinaisplatersm";
            this.textgodinaisplatersm.Tag = "godinaisplatersm";
            this.textgodinaisplatersm.TabIndex = 0;
            this.textgodinaisplatersm.Anchor = AnchorStyles.Left;
            this.textgodinaisplatersm.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textgodinaisplatersm.ReadOnly = false;
            this.textgodinaisplatersm.DataBindings.Add(new Binding("Text", this.bindingSourceRSMA, "godinaisplatersm"));
            this.textgodinaisplatersm.MaxLength = 5;
            this.layoutManagerformRSMA.Controls.Add(this.textgodinaisplatersm, 1, 0x13);
            this.layoutManagerformRSMA.SetColumnSpan(this.textgodinaisplatersm, 1);
            this.layoutManagerformRSMA.SetRowSpan(this.textgodinaisplatersm, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textgodinaisplatersm.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textgodinaisplatersm.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textgodinaisplatersm.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelRSMA1.Location = point;
            this.grdLevelRSMA1.Name = "grdLevelRSMA1";
            this.layoutManagerformRSMA.Controls.Add(this.grdLevelRSMA1, 0, 20);
            this.layoutManagerformRSMA.SetColumnSpan(this.grdLevelRSMA1, 2);
            this.layoutManagerformRSMA.SetRowSpan(this.grdLevelRSMA1, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelRSMA1.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelRSMA1.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelRSMA1.Size = size;
            this.grdLevelRSMA1.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformRSMA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceRSMA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.Disabled;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.RSMAIDENTIFIKATOROBRASCADescription;
            column4.Width = 0x9c;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            column4.Hidden = true;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.RSMAIDDescription;
            column3.Width = 0x33;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.RSMAREDNIBROJDescription;
            column14.Width = 0x4f;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.RSMAPREZIMEIIMEDescription;
            column13.Width = 0x128;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.RSMAMBGOSIGURANIKADescription;
            column8.Width = 0x72;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.RSMASIFRAGRADARADADescription;
            column15.Width = 0x72;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.RSMAOODescription;
            column12.Width = 30;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.RSMABDescription;
            column.Width = 0x17;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.RSMAODDescription;
            column11.Width = 30;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.RSMADOODescription;
            column2.Width = 0x25;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.RSMAIZNOSOBRACUNANEPLACERSMBDescription;
            column6.Width = 0xb7;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.RSMAIZNOSOSNOVICEZADOPRINOSERSMBDescription;
            column7.Width = 210;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.RSMAMIO1RSMBDescription;
            column9.Width = 0x66;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.RSMAMIO2RSMBDescription;
            column10.Width = 0x66;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.RSMAIZNOSISPLACENEPLACERSMBDescription;
            column5.Width = 0xb1;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 1;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 2;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 3;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 4;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 5;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 6;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 7;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 8;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 9;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 10;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 11;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 12;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 13;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 14;
            this.grdLevelRSMA1.Visible = true;
            this.grdLevelRSMA1.Name = "grdLevelRSMA1";
            this.grdLevelRSMA1.Tag = "RSMA1";
            this.grdLevelRSMA1.TabIndex = 0x29;
            this.grdLevelRSMA1.Dock = DockStyle.Fill;
            this.grdLevelRSMA1.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelRSMA1.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelRSMA1.DataSource = this.bindingSourceRSMA1;
            this.grdLevelRSMA1.Enter += new EventHandler(this.grdLevelRSMA1_Enter);
            this.grdLevelRSMA1.AfterRowInsert += new RowEventHandler(this.grdLevelRSMA1_AfterRowInsert);
            this.grdLevelRSMA1.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelRSMA1.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelRSMA1.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.grdLevelRSMA1.DisplayLayout.BandsSerializer.Add(band);
            this.Name = "RSMAFormUserControl";
            this.Text = "RSMA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.RSMAFormUserControl_Load);
            this.layoutManagerformRSMA.ResumeLayout(false);
            this.layoutManagerformRSMA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceRSMA).EndInit();
            ((ISupportInitialize) this.bindingSourceRSMA1).EndInit();
            ((ISupportInitialize) this.textIDENTIFIKATOROBRASCA).EndInit();
            ((ISupportInitialize) this.textIDOBRACUN).EndInit();
            ((ISupportInitialize) this.textMBOBVEZNIKA).EndInit();
            ((ISupportInitialize) this.textMBGOBVEZNIKA).EndInit();
            ((ISupportInitialize) this.textNAZIVOBVEZNIKA).EndInit();
            ((ISupportInitialize) this.textADRESA).EndInit();
            ((ISupportInitialize) this.textIDRSVRSTEOBVEZNIKA).EndInit();
            ((ISupportInitialize) this.textIDRSVRSTEOBRACUNA).EndInit();
            ((ISupportInitialize) this.textmjesecoBRACUNArsm).EndInit();
            ((ISupportInitialize) this.textgodinaobracunarsm).EndInit();
            ((ISupportInitialize) this.textBROJOSIGURANIKA).EndInit();
            ((ISupportInitialize) this.textmjesecisplatersm).EndInit();
            ((ISupportInitialize) this.textgodinaisplatersm).EndInit();
            ((ISupportInitialize) this.grdLevelRSMA1).EndInit();
            this.dsRSMADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.RSMAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceRSMA, this.RSMAController.WorkItem, this))
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
            this.label1IDENTIFIKATOROBRASCA.Text = StringResources.RSMAIDENTIFIKATOROBRASCADescription;
            this.label1IDOBRACUN.Text = StringResources.RSMAIDOBRACUNDescription;
            this.label1MBOBVEZNIKA.Text = StringResources.RSMAMBOBVEZNIKADescription;
            this.label1MBGOBVEZNIKA.Text = StringResources.RSMAMBGOBVEZNIKADescription;
            this.label1NAZIVOBVEZNIKA.Text = StringResources.RSMANAZIVOBVEZNIKADescription;
            this.label1ADRESA.Text = StringResources.RSMAADRESADescription;
            this.label1IDRSVRSTEOBVEZNIKA.Text = StringResources.RSMAIDRSVRSTEOBVEZNIKADescription;
            this.label1NAZIVRSVRSTEOBVEZNIKA.Text = StringResources.RSMANAZIVRSVRSTEOBVEZNIKADescription;
            this.label1IDRSVRSTEOBRACUNA.Text = StringResources.RSMAIDRSVRSTEOBRACUNADescription;
            this.label1NAZIVRSVRSTEOBRACUNA.Text = StringResources.RSMANAZIVRSVRSTEOBRACUNADescription;
            this.label1mjesecoBRACUNArsm.Text = StringResources.RSMAmjesecoBRACUNArsmDescription;
            this.label1godinaobracunarsm.Text = StringResources.RSMAgodinaobracunarsmDescription;
            this.label1BROJOSIGURANIKA.Text = StringResources.RSMABROJOSIGURANIKADescription;
            this.label1IZNOSOBRACUNANEPLACE.Text = StringResources.RSMAIZNOSOBRACUNANEPLACEDescription;
            this.label1IZNOSOSNOVICEZADOPRINOSE.Text = StringResources.RSMAIZNOSOSNOVICEZADOPRINOSEDescription;
            this.label1MIO1.Text = StringResources.RSMAMIO1Description;
            this.label1MIO2.Text = StringResources.RSMAMIO2Description;
            this.label1IZNOSISPLACENEPLACE.Text = StringResources.RSMAIZNOSISPLACENEPLACEDescription;
            this.label1mjesecisplatersm.Text = StringResources.RSMAmjesecisplatersmDescription;
            this.label1godinaisplatersm.Text = StringResources.RSMAgodinaisplatersmDescription;
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
            if (!this.RSMAController.WorkItem.Items.Contains("RSMA|RSMA"))
            {
                this.RSMAController.WorkItem.Items.Add(this.bindingSourceRSMA, "RSMA|RSMA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsRSMADataSet1.RSMA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.m_Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.m_Mode;
                this.m_BaseMethods.FormLoadStyle();
            }
        }

        private void RSMAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.RSMADescription;
            this.errorProvider1.ContainerControl = this;
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.RSMAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RSMAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.RSMAController.Update(this))
            {
                this.RSMAController.DataSet = new RSMADataSet();
                DataSetUtil.AddEmptyRow(this.RSMAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.RSMAController.DataSet.RSMA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetFocusInFirstField()
        {
            this.textIDENTIFIKATOROBRASCA.Focus();
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

        private void UpdateValuesOBRACUNIDOBRACUN(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceRSMA.Current).Row["IDOBRACUN"] = RuntimeHelpers.GetObjectValue(result["IDOBRACUN"]);
                this.bindingSourceRSMA.ResetCurrentItem();
            }
        }

        private void UpdateValuesRSVRSTEOBRACUNAIDRSVRSTEOBRACUNA(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceRSMA.Current).Row["IDRSVRSTEOBRACUNA"] = RuntimeHelpers.GetObjectValue(result["IDRSVRSTEOBRACUNA"]);
                ((DataRowView) this.bindingSourceRSMA.Current).Row["NAZIVRSVRSTEOBRACUNA"] = RuntimeHelpers.GetObjectValue(result["NAZIVRSVRSTEOBRACUNA"]);
                this.bindingSourceRSMA.ResetCurrentItem();
            }
        }

        private void UpdateValuesRSVRSTEOBVEZNIKAIDRSVRSTEOBVEZNIKA(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceRSMA.Current).Row["IDRSVRSTEOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(result["IDRSVRSTEOBVEZNIKA"]);
                ((DataRowView) this.bindingSourceRSMA.Current).Row["NAZIVRSVRSTEOBVEZNIKA"] = RuntimeHelpers.GetObjectValue(result["NAZIVRSVRSTEOBVEZNIKA"]);
                this.bindingSourceRSMA.ResetCurrentItem();
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

        protected virtual UltraGrid grdLevelRSMA1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelRSMA1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelRSMA1 = value;
            }
        }

        protected virtual UltraLabel label1ADRESA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1ADRESA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1ADRESA = value;
            }
        }

        protected virtual UltraLabel label1BROJOSIGURANIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BROJOSIGURANIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BROJOSIGURANIKA = value;
            }
        }

        protected virtual UltraLabel label1godinaisplatersm
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1godinaisplatersm;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1godinaisplatersm = value;
            }
        }

        protected virtual UltraLabel label1godinaobracunarsm
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1godinaobracunarsm;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1godinaobracunarsm = value;
            }
        }

        protected virtual UltraLabel label1IDENTIFIKATOROBRASCA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDENTIFIKATOROBRASCA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDENTIFIKATOROBRASCA = value;
            }
        }

        protected virtual UltraLabel label1IDOBRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOBRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOBRACUN = value;
            }
        }

        protected virtual UltraLabel label1IDRSVRSTEOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDRSVRSTEOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDRSVRSTEOBRACUNA = value;
            }
        }

        protected virtual UltraLabel label1IDRSVRSTEOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDRSVRSTEOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDRSVRSTEOBVEZNIKA = value;
            }
        }

        protected virtual UltraLabel label1IZNOSISPLACENEPLACE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IZNOSISPLACENEPLACE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IZNOSISPLACENEPLACE = value;
            }
        }

        protected virtual UltraLabel label1IZNOSOBRACUNANEPLACE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IZNOSOBRACUNANEPLACE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IZNOSOBRACUNANEPLACE = value;
            }
        }

        protected virtual UltraLabel label1IZNOSOSNOVICEZADOPRINOSE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IZNOSOSNOVICEZADOPRINOSE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IZNOSOSNOVICEZADOPRINOSE = value;
            }
        }

        protected virtual UltraLabel label1MBGOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MBGOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MBGOBVEZNIKA = value;
            }
        }

        protected virtual UltraLabel label1MBOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MBOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MBOBVEZNIKA = value;
            }
        }

        protected virtual UltraLabel label1MIO1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MIO1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MIO1 = value;
            }
        }

        protected virtual UltraLabel label1MIO2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MIO2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MIO2 = value;
            }
        }

        protected virtual UltraLabel label1mjesecisplatersm
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1mjesecisplatersm;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1mjesecisplatersm = value;
            }
        }

        protected virtual UltraLabel label1mjesecoBRACUNArsm
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1mjesecoBRACUNArsm;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1mjesecoBRACUNArsm = value;
            }
        }

        protected virtual UltraLabel label1NAZIVOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVOBVEZNIKA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVRSVRSTEOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVRSVRSTEOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVRSVRSTEOBRACUNA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVRSVRSTEOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVRSVRSTEOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVRSVRSTEOBVEZNIKA = value;
            }
        }

        protected virtual UltraLabel labelIZNOSISPLACENEPLACE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelIZNOSISPLACENEPLACE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelIZNOSISPLACENEPLACE = value;
            }
        }

        protected virtual UltraLabel labelIZNOSOBRACUNANEPLACE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelIZNOSOBRACUNANEPLACE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelIZNOSOBRACUNANEPLACE = value;
            }
        }

        protected virtual UltraLabel labelIZNOSOSNOVICEZADOPRINOSE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelIZNOSOSNOVICEZADOPRINOSE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelIZNOSOSNOVICEZADOPRINOSE = value;
            }
        }

        protected virtual UltraLabel labelMIO1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelMIO1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelMIO1 = value;
            }
        }

        protected virtual UltraLabel labelMIO2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelMIO2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelMIO2 = value;
            }
        }

        protected virtual UltraLabel labelNAZIVRSVRSTEOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVRSVRSTEOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVRSVRSTEOBRACUNA = value;
            }
        }

        protected virtual UltraLabel labelNAZIVRSVRSTEOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVRSVRSTEOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVRSVRSTEOBVEZNIKA = value;
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
        public NetAdvantage.Controllers.RSMAController RSMAController { get; set; }

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

        protected virtual UltraTextEditor textADRESA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textADRESA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textADRESA = value;
            }
        }

        protected virtual UltraTextEditor textBROJOSIGURANIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBROJOSIGURANIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textBROJOSIGURANIKA = value;
            }
        }

        protected virtual UltraTextEditor textgodinaisplatersm
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textgodinaisplatersm;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textgodinaisplatersm = value;
            }
        }

        protected virtual UltraTextEditor textgodinaobracunarsm
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textgodinaobracunarsm;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textgodinaobracunarsm = value;
            }
        }

        protected virtual UltraTextEditor textIDENTIFIKATOROBRASCA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDENTIFIKATOROBRASCA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDENTIFIKATOROBRASCA = value;
            }
        }

        protected virtual UltraTextEditor textIDOBRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDOBRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDOBRACUN = value;
            }
        }

        protected virtual UltraTextEditor textIDRSVRSTEOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDRSVRSTEOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDRSVRSTEOBRACUNA = value;
            }
        }

        protected virtual UltraTextEditor textIDRSVRSTEOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDRSVRSTEOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDRSVRSTEOBVEZNIKA = value;
            }
        }

        protected virtual UltraTextEditor textMBGOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMBGOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMBGOBVEZNIKA = value;
            }
        }

        protected virtual UltraTextEditor textMBOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMBOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMBOBVEZNIKA = value;
            }
        }

        protected virtual UltraTextEditor textmjesecisplatersm
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textmjesecisplatersm;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textmjesecisplatersm = value;
            }
        }

        protected virtual UltraTextEditor textmjesecoBRACUNArsm
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textmjesecoBRACUNArsm;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textmjesecoBRACUNArsm = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVOBVEZNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVOBVEZNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVOBVEZNIKA = value;
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

