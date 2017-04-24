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
    public class PARTNERFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelPARTNERZADUZENJE")]
        private UltraGrid _grdLevelPARTNERZADUZENJE;
        [AccessedThroughProperty("label1IDPARTNER")]
        private UltraLabel _label1IDPARTNER;
        [AccessedThroughProperty("label1MB")]
        private UltraLabel _label1MB;
        [AccessedThroughProperty("label1NAZIVPARTNER")]
        private UltraLabel _label1NAZIVPARTNER;
        [AccessedThroughProperty("label1PARTNEREMAIL")]
        private UltraLabel _label1PARTNEREMAIL;

        [AccessedThroughProperty("lblFizicki")]
        private UltraLabel _lblFizicki;
        [AccessedThroughProperty("cbkFizicki")]
        private UltraCheckEditor _cbkFizicki;

        [AccessedThroughProperty("lblLokacija")]
        private UltraLabel _lblLokacija;
        [AccessedThroughProperty("cmblLokacija")]
        private ComboBox _cmblLokacija;

        [AccessedThroughProperty("label1PARTNERFAX")]
        private UltraLabel _label1PARTNERFAX;
        [AccessedThroughProperty("label1PARTNERMJESTO")]
        private UltraLabel _label1PARTNERMJESTO;
        [AccessedThroughProperty("label1PARTNEROIB")]
        private UltraLabel _label1PARTNEROIB;
        [AccessedThroughProperty("label1PARTNERTELEFON")]
        private UltraLabel _label1PARTNERTELEFON;
        [AccessedThroughProperty("label1PARTNERULICA")]
        private UltraLabel _label1PARTNERULICA;
        [AccessedThroughProperty("label1PARTNERZIRO1")]
        private UltraLabel _label1PARTNERZIRO1;
        [AccessedThroughProperty("label1PARTNERZIRO2")]
        private UltraLabel _label1PARTNERZIRO2;
        [AccessedThroughProperty("label1PT")]
        private UltraLabel _label1PT;
        [AccessedThroughProperty("labelPT")]
        private UltraLabel _labelPT;
        [AccessedThroughProperty("linkLabelPARTNERZADUZENJE")]
        private UltraLabel _linkLabelPARTNERZADUZENJE;
        [AccessedThroughProperty("linkLabelPARTNERZADUZENJEAdd")]
        private UltraLabel _linkLabelPARTNERZADUZENJEAdd;
        [AccessedThroughProperty("linkLabelPARTNERZADUZENJEDelete")]
        private UltraLabel _linkLabelPARTNERZADUZENJEDelete;
        [AccessedThroughProperty("linkLabelPARTNERZADUZENJEUpdate")]
        private UltraLabel _linkLabelPARTNERZADUZENJEUpdate;
        [AccessedThroughProperty("panelactionsPARTNERZADUZENJE")]
        private Panel _panelactionsPARTNERZADUZENJE;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDPARTNER")]
        private UltraNumericEditor _textIDPARTNER;
        [AccessedThroughProperty("textMB")]
        private UltraTextEditor _textMB;
        [AccessedThroughProperty("textNAZIVPARTNER")]
        private UltraTextEditor _textNAZIVPARTNER;
        [AccessedThroughProperty("textPARTNEREMAIL")]
        private UltraTextEditor _textPARTNEREMAIL;
        [AccessedThroughProperty("textPARTNERFAX")]
        private UltraTextEditor _textPARTNERFAX;
        [AccessedThroughProperty("textPARTNERMJESTO")]
        private UltraTextEditor _textPARTNERMJESTO;
        [AccessedThroughProperty("textPARTNEROIB")]
        private UltraTextEditor _textPARTNEROIB;
        [AccessedThroughProperty("textPARTNERTELEFON")]
        private UltraTextEditor _textPARTNERTELEFON;
        [AccessedThroughProperty("textPARTNERULICA")]
        private UltraTextEditor _textPARTNERULICA;
        [AccessedThroughProperty("textPARTNERZIRO1")]
        private UltraTextEditor _textPARTNERZIRO1;
        [AccessedThroughProperty("textPARTNERZIRO2")]
        private UltraTextEditor _textPARTNERZIRO2;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourcePARTNER;
        private BindingSource bindingSourcePARTNERZADUZENJE;
        private IContainer components;
        private PARTNERDataSet dsPARTNERDataSet1;
        protected TableLayoutPanel layoutManagerformPARTNER;
        protected TableLayoutPanel layoutManagerpanelactionsPARTNERZADUZENJE;
        private bool m_AutoNumber;
        private GenericFormClass m_BaseMethods;
        private PARTNERDataSet.PARTNERRow m_CurrentRow;
        private ArrayList m_DataGrids;
        private string m_FirstLevelName;
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public PARTNERFormUserControl()
        {
            base.Load += new EventHandler(this.partnerFormUserControl_Load1);
            this.components = null;
            this.m_FrameworkDescription = StringResources.PARTNERDescription;
            this.m_DataGrids = new ArrayList();
            this.m_FirstLevelName = "PARTNER";
            this.m_AutoNumber = false;
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsPARTNERDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourcePARTNER.DataSource = this.PARTNERController.DataSet;
            this.dsPARTNERDataSet1 = this.PARTNERController.DataSet;
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
                    enumerator = this.dsPARTNERDataSet1.PARTNER.Rows.GetEnumerator();
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
                if (this.PARTNERController.Update(this))
                {
                    this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void dg_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGridColumn column = e.Cell.Column;
            if ((column.CellActivation == Activation.AllowEdit) && (Conversions.ToString(column.Tag) == "PROIZVODIDPROIZVODAddNew"))
            {
                this.PictureBoxClickedInLinesIDPROIZVOD(RuntimeHelpers.GetObjectValue(sender), e);
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
            if (this.grdLevelPARTNERZADUZENJE.ActiveRow != null)
            {
                this.grdLevelPARTNERZADUZENJE.PerformAction(UltraGridAction.NextRow);
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
                if (e.Cell.Column.Key == "IDPROIZVOD")
                {
                    this.UpdateValuesIDPROIZVOD(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
            }
        }

        private void grdLevelPARTNERZADUZENJE_AfterRowActivate(object sender, EventArgs e)
        {
            string pARTNERPARTNERZADUZENJELevelDescription = StringResources.PARTNERPARTNERZADUZENJELevelDescription;
            UltraGridRow activeRow = this.grdLevelPARTNERZADUZENJE.ActiveRow;
            this.linkLabelPARTNERZADUZENJEAdd.Text = Deklarit.Resources.Resources.Add + " " + pARTNERPARTNERZADUZENJELevelDescription;
            this.linkLabelPARTNERZADUZENJEUpdate.Text = Deklarit.Resources.Resources.Update + " " + pARTNERPARTNERZADUZENJELevelDescription;
            this.linkLabelPARTNERZADUZENJEDelete.Text = Deklarit.Resources.Resources.Delete + " " + pARTNERPARTNERZADUZENJELevelDescription;
        }

        private void grdLevelPARTNERZADUZENJE_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourcePARTNER.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourcePARTNER.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelPARTNERZADUZENJE_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.PARTNERZADUZENJEUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelPARTNERZADUZENJE_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourcePARTNER, this.PARTNERController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "PARTNER", this.m_Mode, this.dsPARTNERDataSet1, this.dsPARTNERDataSet1.PARTNER.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            if (!this.m_DataGrids.Contains(this.grdLevelPARTNERZADUZENJE))
            {
                this.m_DataGrids.Add(this.grdLevelPARTNERZADUZENJE);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsPARTNERDataSet1.PARTNER[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (PARTNERDataSet.PARTNERRow) ((DataRowView) this.bindingSourcePARTNER.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(PARTNERFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourcePARTNER = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePARTNER).BeginInit();
            this.bindingSourcePARTNERZADUZENJE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePARTNERZADUZENJE).BeginInit();
            this.layoutManagerformPARTNER = new TableLayoutPanel();
            this.layoutManagerformPARTNER.SuspendLayout();
            this.layoutManagerformPARTNER.AutoSize = true;
            this.layoutManagerformPARTNER.Dock = DockStyle.Fill;
            //this.layoutManagerformPARTNER.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPARTNER.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPARTNER.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPARTNER.Size = size;
            this.layoutManagerformPARTNER.ColumnCount = 2;
            this.layoutManagerformPARTNER.RowCount = 14;
            this.layoutManagerformPARTNER.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPARTNER.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.label1IDPARTNER = new UltraLabel();
            this.textIDPARTNER = new UltraNumericEditor();
            this.label1NAZIVPARTNER = new UltraLabel();
            this.textNAZIVPARTNER = new UltraTextEditor();
            this.label1MB = new UltraLabel();
            this.textMB = new UltraTextEditor();
            this.label1PARTNERMJESTO = new UltraLabel();
            this.textPARTNERMJESTO = new UltraTextEditor();
            this.label1PARTNERULICA = new UltraLabel();
            this.textPARTNERULICA = new UltraTextEditor();
            this.label1PARTNEREMAIL = new UltraLabel();

            lblFizicki = new UltraLabel();
            cbkFizicki = new UltraCheckEditor();
            lblLokacija = new UltraLabel();
            cmbLokacija = new ComboBox();

            this.textPARTNEREMAIL = new UltraTextEditor();
            this.label1PARTNEROIB = new UltraLabel();
            this.textPARTNEROIB = new UltraTextEditor();
            this.label1PARTNERFAX = new UltraLabel();
            this.textPARTNERFAX = new UltraTextEditor();
            this.label1PARTNERTELEFON = new UltraLabel();
            this.textPARTNERTELEFON = new UltraTextEditor();
            this.label1PARTNERZIRO1 = new UltraLabel();
            this.textPARTNERZIRO1 = new UltraTextEditor();
            this.label1PARTNERZIRO2 = new UltraLabel();
            this.textPARTNERZIRO2 = new UltraTextEditor();
            this.label1PT = new UltraLabel();
            this.labelPT = new UltraLabel();
            this.grdLevelPARTNERZADUZENJE = new UltraGrid();
            this.panelactionsPARTNERZADUZENJE = new Panel();
            this.layoutManagerpanelactionsPARTNERZADUZENJE = new TableLayoutPanel();
            this.layoutManagerpanelactionsPARTNERZADUZENJE.AutoSize = true;
            //this.layoutManagerpanelactionsPARTNERZADUZENJE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsPARTNERZADUZENJE.ColumnCount = 4;
            this.layoutManagerpanelactionsPARTNERZADUZENJE.RowCount = 1;
            this.layoutManagerpanelactionsPARTNERZADUZENJE.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsPARTNERZADUZENJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPARTNERZADUZENJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPARTNERZADUZENJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPARTNERZADUZENJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPARTNERZADUZENJE.RowStyles.Add(new RowStyle());
            this.linkLabelPARTNERZADUZENJEAdd = new UltraLabel();
            this.linkLabelPARTNERZADUZENJEUpdate = new UltraLabel();
            this.linkLabelPARTNERZADUZENJEDelete = new UltraLabel();
            this.linkLabelPARTNERZADUZENJE = new UltraLabel();
            ((ISupportInitialize) this.textIDPARTNER).BeginInit();
            ((ISupportInitialize) this.textNAZIVPARTNER).BeginInit();
            ((ISupportInitialize) this.textMB).BeginInit();
            ((ISupportInitialize) this.textPARTNERMJESTO).BeginInit();
            ((ISupportInitialize) this.textPARTNERULICA).BeginInit();
            ((ISupportInitialize) this.textPARTNEREMAIL).BeginInit();
            ((ISupportInitialize) this.textPARTNEROIB).BeginInit();
            ((ISupportInitialize) this.textPARTNERFAX).BeginInit();
            ((ISupportInitialize) this.textPARTNERTELEFON).BeginInit();
            ((ISupportInitialize) this.textPARTNERZIRO1).BeginInit();
            ((ISupportInitialize) this.textPARTNERZIRO2).BeginInit();
            ((ISupportInitialize) this.grdLevelPARTNERZADUZENJE).BeginInit();
            this.panelactionsPARTNERZADUZENJE.SuspendLayout();
            this.layoutManagerpanelactionsPARTNERZADUZENJE.SuspendLayout();
            UltraGridBand band = new UltraGridBand("PARTNERZADUZENJE", -1);
            UltraGridColumn column6 = new UltraGridColumn("IDPARTNER");
            UltraGridColumn column9 = new UltraGridColumn("IDZADUZENJE");
            UltraGridColumn column7 = new UltraGridColumn("IDPROIZVOD");
            UltraGridColumn column8 = new UltraGridColumn("columnIDPROIZVODAddNew", 0);
            UltraGridColumn column13 = new UltraGridColumn("NAZIVPROIZVOD");
            UltraGridColumn column2 = new UltraGridColumn("CIJENA");
            UltraGridColumn column12 = new UltraGridColumn("KOLICINAZADUZENJA");
            UltraGridColumn column3 = new UltraGridColumn("CIJENAZADUZENJA");
            UltraGridColumn column11 = new UltraGridColumn("IZNOSZADUZENJA");
            UltraGridColumn column14 = new UltraGridColumn("RABATZADUZENJA");
            UltraGridColumn column10 = new UltraGridColumn("IZNOSRABATAZADUZENJE");
            UltraGridColumn column4 = new UltraGridColumn("CIJENAZAFAKTURU");
            UltraGridColumn column15 = new UltraGridColumn("UGOVORBROJ");
            UltraGridColumn column5 = new UltraGridColumn("DATUMUGOVORA");
            UltraGridColumn column = new UltraGridColumn("AKTIVNO");
            this.dsPARTNERDataSet1 = new PARTNERDataSet();
            this.dsPARTNERDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsPARTNERDataSet1.DataSetName = "dsPARTNER";
            this.dsPARTNERDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourcePARTNER.DataSource = this.dsPARTNERDataSet1;
            this.bindingSourcePARTNER.DataMember = "PARTNER";
            ((ISupportInitialize) this.bindingSourcePARTNER).BeginInit();
            this.bindingSourcePARTNERZADUZENJE.DataSource = this.bindingSourcePARTNER;
            this.bindingSourcePARTNERZADUZENJE.DataMember = "PARTNER_PARTNERZADUZENJE";
            point = new System.Drawing.Point(0, 0);
            this.label1IDPARTNER.Location = point;
            this.label1IDPARTNER.Name = "label1IDPARTNER";
            this.label1IDPARTNER.TabIndex = 1;
            this.label1IDPARTNER.Tag = "labelIDPARTNER";
            this.label1IDPARTNER.Text = "Šifra:";
            this.label1IDPARTNER.StyleSetName = "FieldUltraLabel";
            this.label1IDPARTNER.AutoSize = true;
            this.label1IDPARTNER.Anchor = AnchorStyles.Left;
            this.label1IDPARTNER.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDPARTNER.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDPARTNER.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDPARTNER.ImageSize = size;
            this.label1IDPARTNER.Appearance.ForeColor = Color.Black;
            this.label1IDPARTNER.BackColor = Color.Transparent;
            this.layoutManagerformPARTNER.Controls.Add(this.label1IDPARTNER, 0, 0);
            this.layoutManagerformPARTNER.SetColumnSpan(this.label1IDPARTNER, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.label1IDPARTNER, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDPARTNER.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDPARTNER.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDPARTNER.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDPARTNER.Location = point;
            this.textIDPARTNER.Name = "textIDPARTNER";
            this.textIDPARTNER.Tag = "IDPARTNER";
            this.textIDPARTNER.TabIndex = 0;
            this.textIDPARTNER.Anchor = AnchorStyles.Left;
            this.textIDPARTNER.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDPARTNER.ReadOnly = false;
            this.textIDPARTNER.PromptChar = ' ';
            this.textIDPARTNER.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDPARTNER.DataBindings.Add(new Binding("Value", this.bindingSourcePARTNER, "IDPARTNER"));
            this.textIDPARTNER.NumericType = NumericType.Integer;
            this.textIDPARTNER.MaskInput = "{LOC}-nnnnnnnnn";
            this.layoutManagerformPARTNER.Controls.Add(this.textIDPARTNER, 1, 0);
            this.layoutManagerformPARTNER.SetColumnSpan(this.textIDPARTNER, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.textIDPARTNER, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDPARTNER.Margin = padding;
            size = new System.Drawing.Size(0x4e, 0x16);
            this.textIDPARTNER.MinimumSize = size;
            size = new System.Drawing.Size(0x4e, 0x16);
            this.textIDPARTNER.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVPARTNER.Location = point;
            this.label1NAZIVPARTNER.Name = "label1NAZIVPARTNER";
            this.label1NAZIVPARTNER.TabIndex = 1;
            this.label1NAZIVPARTNER.Tag = "labelNAZIVPARTNER";
            this.label1NAZIVPARTNER.Text = "Partner:";
            this.label1NAZIVPARTNER.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVPARTNER.AutoSize = true;
            this.label1NAZIVPARTNER.Anchor = AnchorStyles.Left;
            this.label1NAZIVPARTNER.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVPARTNER.Appearance.ForeColor = Color.Black;
            this.label1NAZIVPARTNER.BackColor = Color.Transparent;
            this.layoutManagerformPARTNER.Controls.Add(this.label1NAZIVPARTNER, 0, 1);
            this.layoutManagerformPARTNER.SetColumnSpan(this.label1NAZIVPARTNER, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.label1NAZIVPARTNER, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVPARTNER.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVPARTNER.MinimumSize = size;
            size = new System.Drawing.Size(0x42, 0x17);
            this.label1NAZIVPARTNER.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVPARTNER.Location = point;
            this.textNAZIVPARTNER.Name = "textNAZIVPARTNER";
            this.textNAZIVPARTNER.Tag = "NAZIVPARTNER";
            this.textNAZIVPARTNER.TabIndex = 0;
            this.textNAZIVPARTNER.Anchor = AnchorStyles.Left;
            this.textNAZIVPARTNER.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVPARTNER.ReadOnly = false;
            this.textNAZIVPARTNER.DataBindings.Add(new Binding("Text", this.bindingSourcePARTNER, "NAZIVPARTNER"));
            this.textNAZIVPARTNER.MaxLength = 100;
            this.layoutManagerformPARTNER.Controls.Add(this.textNAZIVPARTNER, 1, 1);
            this.layoutManagerformPARTNER.SetColumnSpan(this.textNAZIVPARTNER, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.textNAZIVPARTNER, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVPARTNER.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVPARTNER.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVPARTNER.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1MB.Location = point;
            this.label1MB.Name = "label1MB";
            this.label1MB.TabIndex = 1;
            this.label1MB.Tag = "labelMB";
            this.label1MB.Text = "MB:";
            this.label1MB.StyleSetName = "FieldUltraLabel";
            this.label1MB.AutoSize = true;
            this.label1MB.Anchor = AnchorStyles.Left;
            this.label1MB.Appearance.TextVAlign = VAlign.Middle;
            this.label1MB.Appearance.ForeColor = Color.Black;
            this.label1MB.BackColor = Color.Transparent;
            this.layoutManagerformPARTNER.Controls.Add(this.label1MB, 0, 2);
            this.layoutManagerformPARTNER.SetColumnSpan(this.label1MB, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.label1MB, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1MB.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MB.MinimumSize = size;
            size = new System.Drawing.Size(0x27, 0x17);
            this.label1MB.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMB.Location = point;
            this.textMB.Name = "textMB";
            this.textMB.Tag = "MB";
            this.textMB.TabIndex = 0;
            this.textMB.Anchor = AnchorStyles.Left;
            this.textMB.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMB.ContextMenu = this.contextMenu1;
            this.textMB.ReadOnly = false;
            this.textMB.DataBindings.Add(new Binding("Text", this.bindingSourcePARTNER, "MB"));
            this.textMB.Nullable = true;
            this.textMB.MaxLength = 13;
            this.layoutManagerformPARTNER.Controls.Add(this.textMB, 1, 2);
            this.layoutManagerformPARTNER.SetColumnSpan(this.textMB, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.textMB, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMB.Margin = padding;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.textMB.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x16);
            this.textMB.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PARTNERMJESTO.Location = point;
            this.label1PARTNERMJESTO.Name = "label1PARTNERMJESTO";
            this.label1PARTNERMJESTO.TabIndex = 1;
            this.label1PARTNERMJESTO.Tag = "labelPARTNERMJESTO";
            this.label1PARTNERMJESTO.Text = "Mjesto:";
            this.label1PARTNERMJESTO.StyleSetName = "FieldUltraLabel";
            this.label1PARTNERMJESTO.AutoSize = true;
            this.label1PARTNERMJESTO.Anchor = AnchorStyles.Left;
            this.label1PARTNERMJESTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1PARTNERMJESTO.Appearance.ForeColor = Color.Black;
            this.label1PARTNERMJESTO.BackColor = Color.Transparent;
            this.layoutManagerformPARTNER.Controls.Add(this.label1PARTNERMJESTO, 0, 3);
            this.layoutManagerformPARTNER.SetColumnSpan(this.label1PARTNERMJESTO, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.label1PARTNERMJESTO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PARTNERMJESTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PARTNERMJESTO.MinimumSize = size;
            size = new System.Drawing.Size(0x3d, 0x17);
            this.label1PARTNERMJESTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPARTNERMJESTO.Location = point;
            this.textPARTNERMJESTO.Name = "textPARTNERMJESTO";
            this.textPARTNERMJESTO.Tag = "PARTNERMJESTO";
            this.textPARTNERMJESTO.TabIndex = 0;
            this.textPARTNERMJESTO.Anchor = AnchorStyles.Left;
            this.textPARTNERMJESTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPARTNERMJESTO.ReadOnly = false;
            this.textPARTNERMJESTO.DataBindings.Add(new Binding("Text", this.bindingSourcePARTNER, "PARTNERMJESTO"));
            this.textPARTNERMJESTO.MaxLength = 50;
            this.layoutManagerformPARTNER.Controls.Add(this.textPARTNERMJESTO, 1, 3);
            this.layoutManagerformPARTNER.SetColumnSpan(this.textPARTNERMJESTO, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.textPARTNERMJESTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPARTNERMJESTO.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textPARTNERMJESTO.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textPARTNERMJESTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PARTNERULICA.Location = point;
            this.label1PARTNERULICA.Name = "label1PARTNERULICA";
            this.label1PARTNERULICA.TabIndex = 1;
            this.label1PARTNERULICA.Tag = "labelPARTNERULICA";
            this.label1PARTNERULICA.Text = "Ulica i broj:";
            this.label1PARTNERULICA.StyleSetName = "FieldUltraLabel";
            this.label1PARTNERULICA.AutoSize = true;
            this.label1PARTNERULICA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1PARTNERULICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1PARTNERULICA.Appearance.ForeColor = Color.Black;
            this.label1PARTNERULICA.BackColor = Color.Transparent;
            this.layoutManagerformPARTNER.Controls.Add(this.label1PARTNERULICA, 0, 4);
            this.layoutManagerformPARTNER.SetColumnSpan(this.label1PARTNERULICA, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.label1PARTNERULICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PARTNERULICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PARTNERULICA.MinimumSize = size;
            size = new System.Drawing.Size(0x56, 0x17);
            this.label1PARTNERULICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPARTNERULICA.Location = point;
            this.textPARTNERULICA.Name = "textPARTNERULICA";
            this.textPARTNERULICA.Tag = "PARTNERULICA";
            this.textPARTNERULICA.TabIndex = 0;
            this.textPARTNERULICA.Anchor = AnchorStyles.Left;
            this.textPARTNERULICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPARTNERULICA.ReadOnly = false;
            this.textPARTNERULICA.DataBindings.Add(new Binding("Text", this.bindingSourcePARTNER, "PARTNERULICA"));
            this.textPARTNERULICA.Multiline = true;
            this.textPARTNERULICA.MaxLength = 150;
            this.layoutManagerformPARTNER.Controls.Add(this.textPARTNERULICA, 1, 4);
            this.layoutManagerformPARTNER.SetColumnSpan(this.textPARTNERULICA, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.textPARTNERULICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPARTNERULICA.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.textPARTNERULICA.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x2c);
            this.textPARTNERULICA.Size = size;
            this.textPARTNERULICA.Dock = DockStyle.Fill;


            point = new System.Drawing.Point(0, 0);
            this.lblFizicki.Location = point;
            this.lblFizicki.Name = "lblFizicki";
            this.lblFizicki.TabIndex = 1;
            this.lblFizicki.Tag = "lblFizicki";
            this.lblFizicki.Text = "Fizička osoba:";
            this.lblFizicki.StyleSetName = "FieldUltraLabel";
            this.lblFizicki.AutoSize = true;
            this.lblFizicki.Anchor = AnchorStyles.Left;
            this.lblFizicki.Appearance.TextVAlign = VAlign.Middle;
            this.lblFizicki.Appearance.ForeColor = Color.Black;
            this.lblFizicki.BackColor = Color.Transparent;
            this.layoutManagerformPARTNER.Controls.Add(this.lblFizicki, 0, 11);
            this.layoutManagerformPARTNER.SetColumnSpan(this.lblFizicki, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.lblFizicki, 1);
            padding = new Padding(3, 1, 5, 2);
            this.lblFizicki.Margin = padding;
            size = new System.Drawing.Size(25, 16);
            lblFizicki.Size = size;

            point = new System.Drawing.Point(0, 0);
            this.cbkFizicki.Location = point;
            this.cbkFizicki.Name = "cbkFizicki";
            this.cbkFizicki.Tag = "cbkFizicki";
            this.cbkFizicki.TabIndex = 0;
            this.cbkFizicki.Anchor = AnchorStyles.Left;
            this.layoutManagerformPARTNER.Controls.Add(this.cbkFizicki, 1, 11);
            this.layoutManagerformPARTNER.SetColumnSpan(this.cbkFizicki, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.cbkFizicki, 1);
            padding = new Padding(0, 1, 3, 2);
            this.cbkFizicki.Margin = padding;
            size = new System.Drawing.Size(20, 16);
            this.cbkFizicki.Size = size;



            point = new System.Drawing.Point(0, 0);
            this.lblLokacija.Location = point;
            this.lblLokacija.Name = "lblLokacija";
            this.lblLokacija.TabIndex = 1;
            this.lblLokacija.Tag = "lblLokacija";
            this.lblLokacija.Text = "Lokacija:";
            this.lblLokacija.StyleSetName = "FieldUltraLabel";
            this.lblLokacija.AutoSize = true;
            this.lblLokacija.Anchor = AnchorStyles.Left;
            this.lblLokacija.Appearance.TextVAlign = VAlign.Middle;
            this.lblLokacija.Appearance.ForeColor = Color.Black;
            this.lblLokacija.BackColor = Color.Transparent;
            this.layoutManagerformPARTNER.Controls.Add(this.lblLokacija, 0, 12);
            this.layoutManagerformPARTNER.SetColumnSpan(this.lblLokacija, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.lblLokacija, 1);
            padding = new Padding(3, 1, 5, 2);
            this.lblLokacija.Margin = padding;
            size = new System.Drawing.Size(25, 16);
            lblLokacija.Size = size;

            point = new System.Drawing.Point(0, 0);
            this.cmbLokacija.Location = point;
            this.cmbLokacija.Name = "cmbLokacija";
            this.cmbLokacija.Tag = "cmbLokacija";
            this.cmbLokacija.TabIndex = 0;
            this.cmbLokacija.Anchor = AnchorStyles.Left;
            this.layoutManagerformPARTNER.Controls.Add(this.cmbLokacija, 1, 12);
            this.layoutManagerformPARTNER.SetColumnSpan(this.cmbLokacija, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.cmbLokacija, 1);
            padding = new Padding(0, 1, 3, 2);
            this.cmbLokacija.Margin = padding;
            size = new System.Drawing.Size(120, 18);
            this.cmbLokacija.Size = size;
            cmbLokacija.Items.Add("Hrvatska");
            cmbLokacija.Items.Add("EU");
            cmbLokacija.Items.Add("Izvan EU");



            
            point = new System.Drawing.Point(0, 0);
            this.textPARTNEREMAIL.Location = point;
            this.textPARTNEREMAIL.Name = "textPARTNEREMAIL";
            this.textPARTNEREMAIL.Tag = "PARTNEREMAIL";
            this.textPARTNEREMAIL.TabIndex = 0;
            this.textPARTNEREMAIL.Anchor = AnchorStyles.Left;
            this.textPARTNEREMAIL.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPARTNEREMAIL.ContextMenu = this.contextMenu1;
            this.textPARTNEREMAIL.ReadOnly = false;
            this.textPARTNEREMAIL.DataBindings.Add(new Binding("Text", this.bindingSourcePARTNER, "PARTNEREMAIL"));
            this.textPARTNEREMAIL.Nullable = true;
            this.textPARTNEREMAIL.MaxLength = 100;
            this.layoutManagerformPARTNER.Controls.Add(this.textPARTNEREMAIL, 1, 5);
            this.layoutManagerformPARTNER.SetColumnSpan(this.textPARTNEREMAIL, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.textPARTNEREMAIL, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPARTNEREMAIL.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textPARTNEREMAIL.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textPARTNEREMAIL.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PARTNEROIB.Location = point;
            this.label1PARTNEROIB.Name = "label1PARTNEROIB";
            this.label1PARTNEROIB.TabIndex = 1;
            this.label1PARTNEROIB.Tag = "labelPARTNEROIB";
            this.label1PARTNEROIB.Text = "OIB:";
            this.label1PARTNEROIB.StyleSetName = "FieldUltraLabel";
            this.label1PARTNEROIB.AutoSize = true;
            this.label1PARTNEROIB.Anchor = AnchorStyles.Left;
            this.label1PARTNEROIB.Appearance.TextVAlign = VAlign.Middle;
            this.label1PARTNEROIB.Appearance.ForeColor = Color.Black;
            this.label1PARTNEROIB.BackColor = Color.Transparent;
            this.layoutManagerformPARTNER.Controls.Add(this.label1PARTNEROIB, 0, 6);
            this.layoutManagerformPARTNER.SetColumnSpan(this.label1PARTNEROIB, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.label1PARTNEROIB, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PARTNEROIB.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PARTNEROIB.MinimumSize = size;
            size = new System.Drawing.Size(0x2b, 0x17);
            this.label1PARTNEROIB.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPARTNEROIB.Location = point;
            this.textPARTNEROIB.Name = "textPARTNEROIB";
            this.textPARTNEROIB.Tag = "PARTNEROIB";
            this.textPARTNEROIB.TabIndex = 0;
            this.textPARTNEROIB.Anchor = AnchorStyles.Left;
            this.textPARTNEROIB.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPARTNEROIB.ReadOnly = false;
            this.textPARTNEROIB.DataBindings.Add(new Binding("Text", this.bindingSourcePARTNER, "PARTNEROIB"));
            this.textPARTNEROIB.MaxLength = 25;
            this.layoutManagerformPARTNER.Controls.Add(this.textPARTNEROIB, 1, 6);
            this.layoutManagerformPARTNER.SetColumnSpan(this.textPARTNEROIB, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.textPARTNEROIB, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPARTNEROIB.Margin = padding;
            size = new System.Drawing.Size(0x5d, 0x16);
            this.textPARTNEROIB.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textPARTNEROIB.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PARTNERFAX.Location = point;
            this.label1PARTNERFAX.Name = "label1PARTNERFAX";
            this.label1PARTNERFAX.TabIndex = 1;
            this.label1PARTNERFAX.Tag = "labelPARTNERFAX";
            this.label1PARTNERFAX.Text = "Fax:";
            this.label1PARTNERFAX.StyleSetName = "FieldUltraLabel";
            this.label1PARTNERFAX.AutoSize = true;
            this.label1PARTNERFAX.Anchor = AnchorStyles.Left;
            this.label1PARTNERFAX.Appearance.TextVAlign = VAlign.Middle;
            this.label1PARTNERFAX.Appearance.ForeColor = Color.Black;
            this.label1PARTNERFAX.BackColor = Color.Transparent;
            this.layoutManagerformPARTNER.Controls.Add(this.label1PARTNERFAX, 0, 7);
            this.layoutManagerformPARTNER.SetColumnSpan(this.label1PARTNERFAX, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.label1PARTNERFAX, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PARTNERFAX.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PARTNERFAX.MinimumSize = size;
            size = new System.Drawing.Size(0x29, 0x17);
            this.label1PARTNERFAX.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPARTNERFAX.Location = point;
            this.textPARTNERFAX.Name = "textPARTNERFAX";
            this.textPARTNERFAX.Tag = "PARTNERFAX";
            this.textPARTNERFAX.TabIndex = 0;
            this.textPARTNERFAX.Anchor = AnchorStyles.Left;
            this.textPARTNERFAX.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPARTNERFAX.ReadOnly = false;
            this.textPARTNERFAX.DataBindings.Add(new Binding("Text", this.bindingSourcePARTNER, "PARTNERFAX"));
            this.textPARTNERFAX.MaxLength = 20;
            this.layoutManagerformPARTNER.Controls.Add(this.textPARTNERFAX, 1, 7);
            this.layoutManagerformPARTNER.SetColumnSpan(this.textPARTNERFAX, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.textPARTNERFAX, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPARTNERFAX.Margin = padding;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPARTNERFAX.MinimumSize = size;
            size = new System.Drawing.Size(0x9c, 0x16);
            this.textPARTNERFAX.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PARTNERTELEFON.Location = point;
            this.label1PARTNERTELEFON.Name = "label1PARTNERTELEFON";
            this.label1PARTNERTELEFON.TabIndex = 1;
            this.label1PARTNERTELEFON.Tag = "labelPARTNERTELEFON";
            this.label1PARTNERTELEFON.Text = "Telefon:";
            this.label1PARTNERTELEFON.StyleSetName = "FieldUltraLabel";
            this.label1PARTNERTELEFON.AutoSize = true;
            this.label1PARTNERTELEFON.Anchor = AnchorStyles.Left;
            this.label1PARTNERTELEFON.Appearance.TextVAlign = VAlign.Middle;
            this.label1PARTNERTELEFON.Appearance.ForeColor = Color.Black;
            this.label1PARTNERTELEFON.BackColor = Color.Transparent;
            this.layoutManagerformPARTNER.Controls.Add(this.label1PARTNERTELEFON, 0, 8);
            this.layoutManagerformPARTNER.SetColumnSpan(this.label1PARTNERTELEFON, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.label1PARTNERTELEFON, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PARTNERTELEFON.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PARTNERTELEFON.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x17);
            this.label1PARTNERTELEFON.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPARTNERTELEFON.Location = point;
            this.textPARTNERTELEFON.Name = "textPARTNERTELEFON";
            this.textPARTNERTELEFON.Tag = "PARTNERTELEFON";
            this.textPARTNERTELEFON.TabIndex = 0;
            this.textPARTNERTELEFON.Anchor = AnchorStyles.Left;
            this.textPARTNERTELEFON.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPARTNERTELEFON.ReadOnly = false;
            this.textPARTNERTELEFON.DataBindings.Add(new Binding("Text", this.bindingSourcePARTNER, "PARTNERTELEFON"));
            this.textPARTNERTELEFON.MaxLength = 50;
            this.layoutManagerformPARTNER.Controls.Add(this.textPARTNERTELEFON, 1, 8);
            this.layoutManagerformPARTNER.SetColumnSpan(this.textPARTNERTELEFON, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.textPARTNERTELEFON, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPARTNERTELEFON.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textPARTNERTELEFON.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textPARTNERTELEFON.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PARTNERZIRO1.Location = point;
            this.label1PARTNERZIRO1.Name = "label1PARTNERZIRO1";
            this.label1PARTNERZIRO1.TabIndex = 1;
            this.label1PARTNERZIRO1.Tag = "labelPARTNERZIRO1";
            this.label1PARTNERZIRO1.Text = "Žiro račun 1:";
            this.label1PARTNERZIRO1.StyleSetName = "FieldUltraLabel";
            this.label1PARTNERZIRO1.AutoSize = true;
            this.label1PARTNERZIRO1.Anchor = AnchorStyles.Left;
            this.label1PARTNERZIRO1.Appearance.TextVAlign = VAlign.Middle;
            this.label1PARTNERZIRO1.Appearance.ForeColor = Color.Black;
            this.label1PARTNERZIRO1.BackColor = Color.Transparent;
            this.layoutManagerformPARTNER.Controls.Add(this.label1PARTNERZIRO1, 0, 9);
            this.layoutManagerformPARTNER.SetColumnSpan(this.label1PARTNERZIRO1, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.label1PARTNERZIRO1, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PARTNERZIRO1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PARTNERZIRO1.MinimumSize = size;
            size = new System.Drawing.Size(0x5e, 0x17);
            this.label1PARTNERZIRO1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPARTNERZIRO1.Location = point;
            this.textPARTNERZIRO1.Name = "textPARTNERZIRO1";
            this.textPARTNERZIRO1.Tag = "PARTNERZIRO1";
            this.textPARTNERZIRO1.TabIndex = 0;
            this.textPARTNERZIRO1.Anchor = AnchorStyles.Left;
            this.textPARTNERZIRO1.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPARTNERZIRO1.ReadOnly = false;
            this.textPARTNERZIRO1.DataBindings.Add(new Binding("Text", this.bindingSourcePARTNER, "PARTNERZIRO1"));
            this.textPARTNERZIRO1.MaxLength = 0x12;
            this.layoutManagerformPARTNER.Controls.Add(this.textPARTNERZIRO1, 1, 9);
            this.layoutManagerformPARTNER.SetColumnSpan(this.textPARTNERZIRO1, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.textPARTNERZIRO1, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPARTNERZIRO1.Margin = padding;
            size = new System.Drawing.Size(0x8e, 0x16);
            this.textPARTNERZIRO1.MinimumSize = size;
            size = new System.Drawing.Size(0x8e, 0x16);
            this.textPARTNERZIRO1.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PARTNERZIRO2.Location = point;
            this.label1PARTNERZIRO2.Name = "label1PARTNERZIRO2";
            this.label1PARTNERZIRO2.TabIndex = 1;
            this.label1PARTNERZIRO2.Tag = "labelPARTNERZIRO2";
            this.label1PARTNERZIRO2.Text = "Žiro račun 2:";
            this.label1PARTNERZIRO2.StyleSetName = "FieldUltraLabel";
            this.label1PARTNERZIRO2.AutoSize = true;
            this.label1PARTNERZIRO2.Anchor = AnchorStyles.Left;
            this.label1PARTNERZIRO2.Appearance.TextVAlign = VAlign.Middle;
            this.label1PARTNERZIRO2.Appearance.ForeColor = Color.Black;
            this.label1PARTNERZIRO2.BackColor = Color.Transparent;
            this.layoutManagerformPARTNER.Controls.Add(this.label1PARTNERZIRO2, 0, 10);
            this.layoutManagerformPARTNER.SetColumnSpan(this.label1PARTNERZIRO2, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.label1PARTNERZIRO2, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PARTNERZIRO2.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PARTNERZIRO2.MinimumSize = size;
            size = new System.Drawing.Size(0x5e, 0x17);
            this.label1PARTNERZIRO2.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPARTNERZIRO2.Location = point;
            this.textPARTNERZIRO2.Name = "textPARTNERZIRO2";
            this.textPARTNERZIRO2.Tag = "PARTNERZIRO2";
            this.textPARTNERZIRO2.TabIndex = 0;
            this.textPARTNERZIRO2.Anchor = AnchorStyles.Left;
            this.textPARTNERZIRO2.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPARTNERZIRO2.ContextMenu = this.contextMenu1;
            this.textPARTNERZIRO2.ReadOnly = false;
            this.textPARTNERZIRO2.DataBindings.Add(new Binding("Text", this.bindingSourcePARTNER, "PARTNERZIRO2"));
            this.textPARTNERZIRO2.Nullable = true;
            this.textPARTNERZIRO2.MaxLength = 0x12;
            this.layoutManagerformPARTNER.Controls.Add(this.textPARTNERZIRO2, 1, 10);
            this.layoutManagerformPARTNER.SetColumnSpan(this.textPARTNERZIRO2, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.textPARTNERZIRO2, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPARTNERZIRO2.Margin = padding;
            size = new System.Drawing.Size(0x8e, 0x16);
            this.textPARTNERZIRO2.MinimumSize = size;
            size = new System.Drawing.Size(0x8e, 0x16);
            this.textPARTNERZIRO2.Size = size;
            
            point = new System.Drawing.Point(0, 0);
            this.grdLevelPARTNERZADUZENJE.Location = point;
            this.grdLevelPARTNERZADUZENJE.Name = "grdLevelPARTNERZADUZENJE";
            this.layoutManagerformPARTNER.Controls.Add(this.grdLevelPARTNERZADUZENJE, 0, 13);
            this.layoutManagerformPARTNER.SetColumnSpan(this.grdLevelPARTNERZADUZENJE, 2);
            this.layoutManagerformPARTNER.SetRowSpan(this.grdLevelPARTNERZADUZENJE, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelPARTNERZADUZENJE.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelPARTNERZADUZENJE.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelPARTNERZADUZENJE.Size = size;
            this.grdLevelPARTNERZADUZENJE.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsPARTNERZADUZENJE.Location = point;
            this.panelactionsPARTNERZADUZENJE.Name = "panelactionsPARTNERZADUZENJE";
            this.panelactionsPARTNERZADUZENJE.BackColor = Color.Transparent;
            this.panelactionsPARTNERZADUZENJE.Controls.Add(this.layoutManagerpanelactionsPARTNERZADUZENJE);
            this.layoutManagerformPARTNER.Controls.Add(this.panelactionsPARTNERZADUZENJE, 0, 14);
            this.layoutManagerformPARTNER.SetColumnSpan(this.panelactionsPARTNERZADUZENJE, 2);
            this.layoutManagerformPARTNER.SetRowSpan(this.panelactionsPARTNERZADUZENJE, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsPARTNERZADUZENJE.Margin = padding;
            size = new System.Drawing.Size(0x1e9, 0x19);
            this.panelactionsPARTNERZADUZENJE.MinimumSize = size;
            size = new System.Drawing.Size(0x1e9, 0x19);
            this.panelactionsPARTNERZADUZENJE.Size = size;
            this.panelactionsPARTNERZADUZENJE.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPARTNERZADUZENJEAdd.Location = point;
            this.linkLabelPARTNERZADUZENJEAdd.Name = "linkLabelPARTNERZADUZENJEAdd";
            size = new System.Drawing.Size(0x8b, 15);
            this.linkLabelPARTNERZADUZENJEAdd.Size = size;
            this.linkLabelPARTNERZADUZENJEAdd.Text = " Add Zaduzenja partnera  ";
            this.linkLabelPARTNERZADUZENJEAdd.Click += new EventHandler(this.PARTNERZADUZENJEAdd_Click);
            this.linkLabelPARTNERZADUZENJEAdd.BackColor = Color.Transparent;
            this.linkLabelPARTNERZADUZENJEAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelPARTNERZADUZENJEAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelPARTNERZADUZENJEAdd.Cursor = Cursors.Hand;
            this.linkLabelPARTNERZADUZENJEAdd.AutoSize = true;
            this.layoutManagerpanelactionsPARTNERZADUZENJE.Controls.Add(this.linkLabelPARTNERZADUZENJEAdd, 0, 0);
            this.layoutManagerpanelactionsPARTNERZADUZENJE.SetColumnSpan(this.linkLabelPARTNERZADUZENJEAdd, 1);
            this.layoutManagerpanelactionsPARTNERZADUZENJE.SetRowSpan(this.linkLabelPARTNERZADUZENJEAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPARTNERZADUZENJEAdd.Margin = padding;
            size = new System.Drawing.Size(0x8b, 15);
            this.linkLabelPARTNERZADUZENJEAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x8b, 15);
            this.linkLabelPARTNERZADUZENJEAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPARTNERZADUZENJEUpdate.Location = point;
            this.linkLabelPARTNERZADUZENJEUpdate.Name = "linkLabelPARTNERZADUZENJEUpdate";
            size = new System.Drawing.Size(0x9d, 15);
            this.linkLabelPARTNERZADUZENJEUpdate.Size = size;
            this.linkLabelPARTNERZADUZENJEUpdate.Text = " Update Zaduzenja partnera  ";
            this.linkLabelPARTNERZADUZENJEUpdate.Click += new EventHandler(this.PARTNERZADUZENJEUpdate_Click);
            this.linkLabelPARTNERZADUZENJEUpdate.BackColor = Color.Transparent;
            this.linkLabelPARTNERZADUZENJEUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelPARTNERZADUZENJEUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelPARTNERZADUZENJEUpdate.Cursor = Cursors.Hand;
            this.linkLabelPARTNERZADUZENJEUpdate.AutoSize = true;
            this.layoutManagerpanelactionsPARTNERZADUZENJE.Controls.Add(this.linkLabelPARTNERZADUZENJEUpdate, 1, 0);
            this.layoutManagerpanelactionsPARTNERZADUZENJE.SetColumnSpan(this.linkLabelPARTNERZADUZENJEUpdate, 1);
            this.layoutManagerpanelactionsPARTNERZADUZENJE.SetRowSpan(this.linkLabelPARTNERZADUZENJEUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPARTNERZADUZENJEUpdate.Margin = padding;
            size = new System.Drawing.Size(0x9d, 15);
            this.linkLabelPARTNERZADUZENJEUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x9d, 15);
            this.linkLabelPARTNERZADUZENJEUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPARTNERZADUZENJEDelete.Location = point;
            this.linkLabelPARTNERZADUZENJEDelete.Name = "linkLabelPARTNERZADUZENJEDelete";
            size = new System.Drawing.Size(0x99, 15);
            this.linkLabelPARTNERZADUZENJEDelete.Size = size;
            this.linkLabelPARTNERZADUZENJEDelete.Text = " Delete Zaduzenja partnera  ";
            this.linkLabelPARTNERZADUZENJEDelete.Click += new EventHandler(this.PARTNERZADUZENJEDelete_Click);
            this.linkLabelPARTNERZADUZENJEDelete.BackColor = Color.Transparent;
            this.linkLabelPARTNERZADUZENJEDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelPARTNERZADUZENJEDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelPARTNERZADUZENJEDelete.Cursor = Cursors.Hand;
            this.linkLabelPARTNERZADUZENJEDelete.AutoSize = true;
            this.layoutManagerpanelactionsPARTNERZADUZENJE.Controls.Add(this.linkLabelPARTNERZADUZENJEDelete, 2, 0);
            this.layoutManagerpanelactionsPARTNERZADUZENJE.SetColumnSpan(this.linkLabelPARTNERZADUZENJEDelete, 1);
            this.layoutManagerpanelactionsPARTNERZADUZENJE.SetRowSpan(this.linkLabelPARTNERZADUZENJEDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPARTNERZADUZENJEDelete.Margin = padding;
            size = new System.Drawing.Size(0x99, 15);
            this.linkLabelPARTNERZADUZENJEDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x99, 15);
            this.linkLabelPARTNERZADUZENJEDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPARTNERZADUZENJE.Location = point;
            this.linkLabelPARTNERZADUZENJE.Name = "linkLabelPARTNERZADUZENJE";
            this.layoutManagerpanelactionsPARTNERZADUZENJE.Controls.Add(this.linkLabelPARTNERZADUZENJE, 3, 0);
            this.layoutManagerpanelactionsPARTNERZADUZENJE.SetColumnSpan(this.linkLabelPARTNERZADUZENJE, 1);
            this.layoutManagerpanelactionsPARTNERZADUZENJE.SetRowSpan(this.linkLabelPARTNERZADUZENJE, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPARTNERZADUZENJE.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelPARTNERZADUZENJE.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelPARTNERZADUZENJE.Size = size;
            this.linkLabelPARTNERZADUZENJE.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformPARTNER);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourcePARTNER;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.Disabled;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.PARTNERIDPARTNERDescription;
            column6.Width = 0x4e;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnn";
            column6.PromptChar = ' ';
            column6.Format = "";
            column6.CellAppearance = appearance6;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.PARTNERIDZADUZENJEDescription;
            column9.Width = 0x4e;
            appearance8.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnn";
            column9.PromptChar = ' ';
            column9.Format = "";
            column9.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.PARTNERIDPROIZVODDescription;
            column7.Width = 0x55;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            column8.AllowGroupBy = DefaultableBoolean.False;
            column8.AutoSizeEdit = DefaultableBoolean.False;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column8.CellAppearance.BorderAlpha = Alpha.Transparent;
            column8.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column8.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column8.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column8.Header.Enabled = false;
            column8.Header.Fixed = true;
            column8.Header.Caption = "";
            column8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column8.Width = 20;
            column8.MinWidth = 20;
            column8.MaxWidth = 20;
            column8.Tag = "PROIZVODIDPROIZVODAddNew";
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.Disabled;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.PARTNERNAZIVPROIZVODDescription;
            column13.Width = 0x128;
            column13.Format = "";
            column13.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.Disabled;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.PARTNERCIJENADescription;
            column2.Width = 0x52;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn.nnnn";
            column2.PromptChar = ' ';
            column2.Format = "F4";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.PARTNERKOLICINAZADUZENJADescription;
            column12.Width = 0x4b;
            appearance11.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.PARTNERCIJENAZADUZENJADescription;
            column3.Width = 0x66;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.Disabled;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.PARTNERIZNOSZADUZENJADescription;
            column11.Width = 0x66;
            appearance10.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.PARTNERRABATZADUZENJADescription;
            column14.Width = 0x45;
            appearance13.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.Disabled;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.PARTNERIZNOSRABATAZADUZENJEDescription;
            column10.Width = 0x66;
            appearance9.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.Disabled;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.PARTNERCIJENAZAFAKTURUDescription;
            column4.Width = 170;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.PARTNERUGOVORBROJDescription;
            column15.Width = 0x128;
            column15.Format = "";
            column15.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.PARTNERDATUMUGOVORADescription;
            column5.Width = 100;
            column5.MinValue = DateTime.MinValue;
            column5.MaxValue = DateTime.MaxValue;
            column5.Format = "d";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.PARTNERAKTIVNODescription;
            column.Width = 0x41;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 0;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 1;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 2;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 3;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 4;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 5;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 6;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 7;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 8;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 9;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 10;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 11;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 12;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 13;
            this.grdLevelPARTNERZADUZENJE.Visible = true;
            this.grdLevelPARTNERZADUZENJE.Name = "grdLevelPARTNERZADUZENJE";
            this.grdLevelPARTNERZADUZENJE.Tag = "PARTNERZADUZENJE";
            this.grdLevelPARTNERZADUZENJE.TabIndex = 30;
            this.grdLevelPARTNERZADUZENJE.Dock = DockStyle.Fill;
            this.grdLevelPARTNERZADUZENJE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelPARTNERZADUZENJE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelPARTNERZADUZENJE.DataSource = this.bindingSourcePARTNERZADUZENJE;
            this.grdLevelPARTNERZADUZENJE.Enter += new EventHandler(this.grdLevelPARTNERZADUZENJE_Enter);
            this.grdLevelPARTNERZADUZENJE.AfterRowInsert += new RowEventHandler(this.grdLevelPARTNERZADUZENJE_AfterRowInsert);
            this.grdLevelPARTNERZADUZENJE.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelPARTNERZADUZENJE.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelPARTNERZADUZENJE.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelPARTNERZADUZENJE.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelPARTNERZADUZENJE_DoubleClick);
            this.grdLevelPARTNERZADUZENJE.AfterRowActivate += new EventHandler(this.grdLevelPARTNERZADUZENJE_AfterRowActivate);
            this.grdLevelPARTNERZADUZENJE.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelPARTNERZADUZENJE.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelPARTNERZADUZENJE.DisplayLayout.BandsSerializer.Add(band);
            this.Name = "PARTNERFormUserControl";
            this.Text = "PARTNER";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.PARTNERFormUserControl_Load);
            this.layoutManagerformPARTNER.ResumeLayout(false);
            this.layoutManagerformPARTNER.PerformLayout();
            ((ISupportInitialize) this.bindingSourcePARTNER).EndInit();
            ((ISupportInitialize) this.bindingSourcePARTNERZADUZENJE).EndInit();
            ((ISupportInitialize) this.textIDPARTNER).EndInit();
            ((ISupportInitialize) this.textNAZIVPARTNER).EndInit();
            ((ISupportInitialize) this.textMB).EndInit();
            ((ISupportInitialize) this.textPARTNERMJESTO).EndInit();
            ((ISupportInitialize) this.textPARTNERULICA).EndInit();
            ((ISupportInitialize) this.textPARTNEREMAIL).EndInit();
            ((ISupportInitialize) this.textPARTNEROIB).EndInit();
            ((ISupportInitialize) this.textPARTNERFAX).EndInit();
            ((ISupportInitialize) this.textPARTNERTELEFON).EndInit();
            ((ISupportInitialize) this.textPARTNERZIRO1).EndInit();
            ((ISupportInitialize) this.textPARTNERZIRO2).EndInit();
            ((ISupportInitialize) this.grdLevelPARTNERZADUZENJE).EndInit();
            this.panelactionsPARTNERZADUZENJE.ResumeLayout(true);
            this.panelactionsPARTNERZADUZENJE.PerformLayout();
            this.layoutManagerpanelactionsPARTNERZADUZENJE.ResumeLayout(false);
            this.layoutManagerpanelactionsPARTNERZADUZENJE.PerformLayout();
            this.dsPARTNERDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.PARTNERController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourcePARTNER, this.PARTNERController.WorkItem, this))
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
            this.label1IDPARTNER.Text = StringResources.PARTNERIDPARTNERDescription;
            this.label1NAZIVPARTNER.Text = StringResources.PARTNERNAZIVPARTNERDescription;
            this.label1MB.Text = StringResources.PARTNERMBDescription;
            this.label1PARTNERMJESTO.Text = StringResources.PARTNERPARTNERMJESTODescription;
            this.label1PARTNERULICA.Text = StringResources.PARTNERPARTNERULICADescription;
            this.label1PARTNEREMAIL.Text = StringResources.PARTNERPARTNEREMAILDescription;
            this.label1PARTNEROIB.Text = StringResources.PARTNERPARTNEROIBDescription;
            this.label1PARTNERFAX.Text = StringResources.PARTNERPARTNERFAXDescription;
            this.label1PARTNERTELEFON.Text = StringResources.PARTNERPARTNERTELEFONDescription;
            this.label1PARTNERZIRO1.Text = StringResources.PARTNERPARTNERZIRO1Description;
            this.label1PARTNERZIRO2.Text = StringResources.PARTNERPARTNERZIRO2Description;
            this.label1PT.Text = StringResources.PARTNERPTDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            try
            {
                this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
            }
            catch { }
        }

        [LocalCommandHandler("NewGKSTAVKA")]
        public void NewGKSTAVKAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.NewGKSTAVKA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewIRA")]
        public void NewIRAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.NewIRA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewRACUN")]
        public void NewRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.NewRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewSHEMAURA")]
        public void NewSHEMAURAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.NewSHEMAURA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("NewURA")]
        public void NewURAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.NewURA(this.m_CurrentRow);
            }
        }

        public int NUMERACIJA()
        {
            int num = 0;
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.Text,
                CommandText = "SELECT MAX(CAST(idpartner AS INTEGER)) FROM partner",
                Connection = connection
            };
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

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PARTNERFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.PARTNERDescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelPARTNERZADUZENJEAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.PARTNERPARTNERZADUZENJELevelDescription;
            this.linkLabelPARTNERZADUZENJEUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.PARTNERPARTNERZADUZENJELevelDescription;
            this.linkLabelPARTNERZADUZENJEDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.PARTNERPARTNERZADUZENJELevelDescription;
            GetFizickaOsoba();
            GetLokacija();
        }

        private void GetLokacija()
        {
            if (!textIDPARTNER.Enabled)
            {
                Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

                string lokacija = client.ExecuteScalar("Select Lokacija From PARTNER Where IDPARTNER = " + textIDPARTNER.Value).ToString();

                if (lokacija == "0")
                {
                    cmbLokacija.SelectedIndex = 0;
                }
                else if (lokacija == "1")
                {
                    cmbLokacija.SelectedIndex = 1;
                }
                else
                {
                    cmbLokacija.SelectedIndex = 2;
                }
            }
        }

        private void GetFizickaOsoba()
        {
            if (!textIDPARTNER.Enabled)
            {
                Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

                string fizicki = client.ExecuteScalar("Select Ucenik From PARTNER Where IDPARTNER = " + textIDPARTNER.Value).ToString();

                if (fizicki == "0")
                {
                    cbkFizicki.Checked = false;
                    cbkFizicki.Visible = true;
                    lblFizicki.Visible = true;
                }
                else if (fizicki == "1")
                {
                    cbkFizicki.Visible = false;
                    lblFizicki.Visible = false;
                }
                else
                {
                    cbkFizicki.Checked = true;
                    cbkFizicki.Visible = true;
                    lblFizicki.Visible = true;
                }
            }
        }

        private void partnerFormUserControl_Load1(object sender, EventArgs e)
        {
            if (this.Mode == DeklaritMode.Insert)
            {
                ((UltraNumericEditor) this.PARTNERController.PARTNERFormDefinition.GetControl("textidpartner")).Value = this.NUMERACIJA();
            }
        }

        private void PARTNERZADUZENJEAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelPARTNERZADUZENJE.ActiveRow;
            this.PARTNERZADUZENJEInsert();
        }

        private void PARTNERZADUZENJEDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelPARTNERZADUZENJE);
            if ((currentRowListIndex != -1) && (this.grdLevelPARTNERZADUZENJE.Selected.Rows.Count > 0))
            {
                this.grdLevelPARTNERZADUZENJE.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelPARTNERZADUZENJE).Selected = true;
                this.grdLevelPARTNERZADUZENJE.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/PROIZVOD", Thread=ThreadOption.UserInterface)]
        public void PARTNERZADUZENJEIDPROIZVOD_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new PROIZVODDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetPROIZVODDataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["PROIZVOD"]) {
                Sort = "NAZIVPROIZVOD"
            };
            CreateValueList(this.grdLevelPARTNERZADUZENJE, "PROIZVODIDPROIZVOD", enumList, "IDPROIZVOD", "NAZIVPROIZVOD", true);
        }

        private void PARTNERZADUZENJEInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourcePARTNER, this.PARTNERController.WorkItem, this))
            {
                this.PARTNERController.AddPARTNERZADUZENJE(this.m_CurrentRow);
            }
        }

        private void PARTNERZADUZENJEUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelPARTNERZADUZENJE) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelPARTNERZADUZENJE);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.PARTNERController.UpdatePARTNERZADUZENJE(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void PARTNERZADUZENJEUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelPARTNERZADUZENJE.ActiveRow != null)
            {
                this.PARTNERZADUZENJEUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void PictureBoxClickedInLinesIDPROIZVOD(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("PROIZVOD", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.PARTNERController.WorkItem.Items.Contains("PARTNER|PARTNER"))
            {
                this.PARTNERController.WorkItem.Items.Add(this.bindingSourcePARTNER, "PARTNER|PARTNER");
            }
            if (!this.PARTNERController.WorkItem.Items.Contains("PARTNER|PARTNERZADUZENJE"))
            {
                this.PARTNERController.WorkItem.Items.Add(this.bindingSourcePARTNERZADUZENJE, "PARTNER|PARTNERZADUZENJE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsPARTNERDataSet1.PARTNER.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.PARTNERController.Update(this);
                UpdateFizickaOsoba();
                UpdateLokacija();
            }
        }

        private void UpdateLokacija()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();


            if (cmbLokacija.SelectedIndex == 0)
            {
                client.ExecuteNonQuery("Update PARTNER Set Lokacija = 0 Where IDPARTNER = " + textIDPARTNER.Value);
            }
            else if (cmbLokacija.SelectedIndex == 1)
            {
                client.ExecuteNonQuery("Update PARTNER Set Lokacija = 1 Where IDPARTNER = " + textIDPARTNER.Value);
            }
            else if (cmbLokacija.SelectedIndex == 2)
            {
                client.ExecuteNonQuery("Update PARTNER Set Lokacija = 2 Where IDPARTNER = " + textIDPARTNER.Value);
            }

            cbkFizicki.Checked = false;
        }

        private void UpdateFizickaOsoba()
        {
            Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

            string vrsta = client.ExecuteScalar("Select Ucenik From Partner Where IDPARTNER = " + textIDPARTNER.Value).ToString();

            if (vrsta != "1")
            {
                if (cbkFizicki.Checked)
                {
                    client.ExecuteNonQuery("Update PARTNER Set Ucenik = 2 Where IDPARTNER = " + textIDPARTNER.Value);
                }
                else
                {
                    client.ExecuteNonQuery("Update PARTNER Set Ucenik = 0 Where IDPARTNER = " + textIDPARTNER.Value);
                }
            }

            cbkFizicki.Checked = false;
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.PARTNERController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                UpdateFizickaOsoba();
                UpdateLokacija();
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.PARTNERController.Update(this))
            {
                this.PARTNERController.DataSet = new PARTNERDataSet();
                DataSetUtil.AddEmptyRow(this.PARTNERController.DataSet);
                int id = (int)textIDPARTNER.Value;
                this.ChangeBinding();
                this.m_CurrentRow = this.PARTNERController.DataSet.PARTNER[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
                this.textIDPARTNER.Value = id + 1;
                UpdateFizickaOsoba();
                UpdateLokacija();
            }
        }

        private void SetComboBoxColumnProperties()
        {
            DataSet dataSet = new PROIZVODDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetPROIZVODDataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["PROIZVOD"]) {
                Sort = "NAZIVPROIZVOD"
            };
            CreateValueList(this.grdLevelPARTNERZADUZENJE, "PROIZVODIDPROIZVOD", enumList, "IDPROIZVOD", "NAZIVPROIZVOD", false);
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelPARTNERZADUZENJE, "IDPROIZVOD");
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            gridColumn.ValueList = this.grdLevelPARTNERZADUZENJE.DisplayLayout.ValueLists["PROIZVODIDPROIZVOD"];
            gridColumn.Width = 370;
            this.grdLevelPARTNERZADUZENJE.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelPARTNERZADUZENJE.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.textIDPARTNER.Focus();
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

        private void UpdateValuesIDPROIZVOD(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["IDPROIZVOD"] = RuntimeHelpers.GetObjectValue(result["IDPROIZVOD"]);
                    row["NAZIVPROIZVOD"] = RuntimeHelpers.GetObjectValue(result["NAZIVPROIZVOD"]);
                    row["CIJENA"] = RuntimeHelpers.GetObjectValue(result["CIJENA"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        [LocalCommandHandler("ViewGKSTAVKA")]
        public void ViewGKSTAVKAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.ViewGKSTAVKA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewIRA")]
        public void ViewIRAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.ViewIRA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewRACUN")]
        public void ViewRACUNHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.ViewRACUN(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewSHEMAURA")]
        public void ViewSHEMAURAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.ViewSHEMAURA(this.m_CurrentRow);
            }
        }

        [LocalCommandHandler("ViewURA")]
        public void ViewURAHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PARTNERController.ViewURA(this.m_CurrentRow);
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

        protected virtual UltraGrid grdLevelPARTNERZADUZENJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelPARTNERZADUZENJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelPARTNERZADUZENJE = value;
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

        protected virtual UltraLabel label1MB
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MB;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MB = value;
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

        protected virtual UltraLabel label1PARTNEREMAIL
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PARTNEREMAIL;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PARTNEREMAIL = value;
            }
        }


        protected virtual UltraLabel lblFizicki
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lblFizicki;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._lblFizicki = value;
            }
        }

        protected virtual UltraCheckEditor cbkFizicki
        {
            [DebuggerNonUserCode]
            get
            {
                return this._cbkFizicki;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._cbkFizicki = value;
            }
        }


        protected virtual UltraLabel lblLokacija
        {
            [DebuggerNonUserCode]
            get
            {
                return this._lblLokacija;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._lblLokacija = value;
            }
        }

        protected virtual ComboBox cmbLokacija
        {
            [DebuggerNonUserCode]
            get
            {
                return this._cmblLokacija;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._cmblLokacija = value;
            }
        }


        protected virtual UltraLabel label1PARTNERFAX
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PARTNERFAX;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PARTNERFAX = value;
            }
        }

        protected virtual UltraLabel label1PARTNERMJESTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PARTNERMJESTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PARTNERMJESTO = value;
            }
        }

        protected virtual UltraLabel label1PARTNEROIB
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PARTNEROIB;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PARTNEROIB = value;
            }
        }

        protected virtual UltraLabel label1PARTNERTELEFON
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PARTNERTELEFON;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PARTNERTELEFON = value;
            }
        }

        protected virtual UltraLabel label1PARTNERULICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PARTNERULICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PARTNERULICA = value;
            }
        }

        protected virtual UltraLabel label1PARTNERZIRO1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PARTNERZIRO1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PARTNERZIRO1 = value;
            }
        }

        protected virtual UltraLabel label1PARTNERZIRO2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PARTNERZIRO2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PARTNERZIRO2 = value;
            }
        }

        protected virtual UltraLabel label1PT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PT = value;
            }
        }

        protected virtual UltraLabel labelPT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPT = value;
            }
        }

        protected virtual UltraLabel linkLabelPARTNERZADUZENJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPARTNERZADUZENJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPARTNERZADUZENJE = value;
            }
        }

        protected virtual UltraLabel linkLabelPARTNERZADUZENJEAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPARTNERZADUZENJEAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPARTNERZADUZENJEAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelPARTNERZADUZENJEDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPARTNERZADUZENJEDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPARTNERZADUZENJEDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelPARTNERZADUZENJEUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPARTNERZADUZENJEUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPARTNERZADUZENJEUpdate = value;
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

        protected virtual Panel panelactionsPARTNERZADUZENJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsPARTNERZADUZENJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsPARTNERZADUZENJE = value;
            }
        }

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.PARTNERController PARTNERController { get; set; }

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

        protected virtual UltraNumericEditor textIDPARTNER
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDPARTNER;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDPARTNER = value;
            }
        }

        protected virtual UltraTextEditor textMB
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMB;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMB = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVPARTNER
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVPARTNER;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVPARTNER = value;
            }
        }

        protected virtual UltraTextEditor textPARTNEREMAIL
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPARTNEREMAIL;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPARTNEREMAIL = value;
            }
        }

        protected virtual UltraTextEditor textPARTNERFAX
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPARTNERFAX;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPARTNERFAX = value;
            }
        }

        protected virtual UltraTextEditor textPARTNERMJESTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPARTNERMJESTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPARTNERMJESTO = value;
            }
        }

        protected virtual UltraTextEditor textPARTNEROIB
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPARTNEROIB;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPARTNEROIB = value;
            }
        }

        protected virtual UltraTextEditor textPARTNERTELEFON
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPARTNERTELEFON;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPARTNERTELEFON = value;
            }
        }

        protected virtual UltraTextEditor textPARTNERULICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPARTNERULICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPARTNERULICA = value;
            }
        }

        protected virtual UltraTextEditor textPARTNERZIRO1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPARTNERZIRO1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPARTNERZIRO1 = value;
            }
        }

        protected virtual UltraTextEditor textPARTNERZIRO2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPARTNERZIRO2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPARTNERZIRO2 = value;
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

