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
    using Microsoft.Practices.CompositeUI.EventBroker;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic.CompilerServices;
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
    public class EVIDENCIJAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelEVIDENCIJARADNICI")]
        private UltraGrid _grdLevelEVIDENCIJARADNICI;
        [AccessedThroughProperty("label1BROJEVIDENCIJE")]
        private UltraLabel _label1BROJEVIDENCIJE;
        [AccessedThroughProperty("label1IDGODINE")]
        private UltraLabel _label1IDGODINE;
        [AccessedThroughProperty("label1MJESEC")]
        private UltraLabel _label1MJESEC;
        [AccessedThroughProperty("label1OPISEVIDENCIJE")]
        private UltraLabel _label1OPISEVIDENCIJE;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textBROJEVIDENCIJE")]
        private UltraNumericEditor _textBROJEVIDENCIJE;
        [AccessedThroughProperty("textIDGODINE")]
        private UltraNumericEditor _textIDGODINE;
        [AccessedThroughProperty("textMJESEC")]
        private UltraNumericEditor _textMJESEC;
        [AccessedThroughProperty("textOPISEVIDENCIJE")]
        private UltraTextEditor _textOPISEVIDENCIJE;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceEVIDENCIJA;
        private BindingSource bindingSourceEVIDENCIJARADNICI;
        private IContainer components = null;
        private EVIDENCIJADataSet dsEVIDENCIJADataSet1;
        protected TableLayoutPanel layoutManagerformEVIDENCIJA;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private EVIDENCIJADataSet.EVIDENCIJARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "EVIDENCIJA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.EVIDENCIJADescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public EVIDENCIJAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptGODINEIDGODINE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.EVIDENCIJAController.SelectGODINEIDGODINE(fillMethod, fillByRow);
            this.UpdateValuesGODINEIDGODINE(result);
        }

        private void CallPromptInLinesSMJENEDRUGASMJENAIDSMJENE(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.EVIDENCIJAController.SelectSMJENEDRUGASMJENAIDSMJENE("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["DRUGASMJENAIDSMJENE"] = RuntimeHelpers.GetObjectValue(row2["IDSMJENE"]);
                    row3["DRUGASMJENAOPISSMJENE"] = RuntimeHelpers.GetObjectValue(row2["OPISSMJENE"]);
                    row3["DRUGASMJENAPOCETAK"] = RuntimeHelpers.GetObjectValue(row2["POCETAK"]);
                    row3["DRUGASMJENAZAVRSETAK"] = RuntimeHelpers.GetObjectValue(row2["ZAVRSETAK"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                }
                e.Cell.Value = RuntimeHelpers.GetObjectValue(((DataRowView) e.Cell.Row.ListObject).Row[e.Cell.Column.Key]);
            }
        }

        private void CallPromptInLinesSMJENEPRVASMJENAIDSMJENE(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.EVIDENCIJAController.SelectSMJENEPRVASMJENAIDSMJENE("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["PRVASMJENAIDSMJENE"] = RuntimeHelpers.GetObjectValue(row2["IDSMJENE"]);
                    row3["PRVASMJENAOPISSMJENE"] = RuntimeHelpers.GetObjectValue(row2["OPISSMJENE"]);
                    row3["PRVASMJENAPOCETAK"] = RuntimeHelpers.GetObjectValue(row2["POCETAK"]);
                    row3["PRVASMJENAZAVRSETAK"] = RuntimeHelpers.GetObjectValue(row2["ZAVRSETAK"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
                e.Cell.Value = RuntimeHelpers.GetObjectValue(((DataRowView) e.Cell.Row.ListObject).Row[e.Cell.Column.Key]);
            }
        }

        private void CallViewGODINEIDGODINE(object sender, EventArgs e)
        {
            DataRow result = this.EVIDENCIJAController.ShowGODINEIDGODINE(this.m_CurrentRow);
            this.UpdateValuesGODINEIDGODINE(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsEVIDENCIJADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceEVIDENCIJA.DataSource = this.EVIDENCIJAController.DataSet;
            this.dsEVIDENCIJADataSet1 = this.EVIDENCIJAController.DataSet;
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
                    enumerator = this.dsEVIDENCIJADataSet1.EVIDENCIJA.Rows.GetEnumerator();
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
                if (this.EVIDENCIJAController.Update(this))
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
                switch (Conversions.ToString(column.Tag))
                {
                    case "RADNIKIDRADNIKAddNew":
                        this.PictureBoxClickedInLinesIDRADNIK(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "SMJENEPRVASMJENAIDSMJENE":
                        this.CallPromptInLinesSMJENEPRVASMJENAIDSMJENE(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "SMJENEDRUGASMJENAIDSMJENE":
                        this.CallPromptInLinesSMJENEDRUGASMJENAIDSMJENE(RuntimeHelpers.GetObjectValue(sender), e);
                        break;
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

        private void EndEditCurrentRow()
        {
            if (this.grdLevelEVIDENCIJARADNICI.ActiveRow != null)
            {
                this.grdLevelEVIDENCIJARADNICI.PerformAction(UltraGridAction.NextRow);
            }
        }

        private void EVIDENCIJAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.EVIDENCIJADescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/RADNIK", Thread=ThreadOption.UserInterface)]
        public void EVIDENCIJARADNICIIDRADNIK_Add(object sender, ComponentEventArgs e)
        {
            PregledRadnikaComboBox box = new PregledRadnikaComboBox();
            box.Fill();
            DataView defaultView = box.DataSet.Tables["RADNIK"].DefaultView;
            CreateValueList(this.grdLevelEVIDENCIJARADNICI, "RADNIKIDRADNIK", defaultView, "IDRADNIK", "SPOJENOPREZIME", true);
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
                if (e.Cell.Column.Key == "IDRADNIK")
                {
                    this.UpdateValuesIDRADNIK(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
            }
        }

        private void grdLevelEVIDENCIJARADNICI_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceEVIDENCIJA.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceEVIDENCIJA.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelEVIDENCIJARADNICI_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceEVIDENCIJA, this.EVIDENCIJAController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "EVIDENCIJA", this.m_Mode, this.dsEVIDENCIJADataSet1, this.dsEVIDENCIJADataSet1.EVIDENCIJA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            if (!this.m_DataGrids.Contains(this.grdLevelEVIDENCIJARADNICI))
            {
                this.m_DataGrids.Add(this.grdLevelEVIDENCIJARADNICI);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsEVIDENCIJADataSet1.EVIDENCIJA[0];
                this.textIDGODINE.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textIDGODINE.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (EVIDENCIJADataSet.EVIDENCIJARow) ((DataRowView) this.bindingSourceEVIDENCIJA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(EVIDENCIJAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceEVIDENCIJA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceEVIDENCIJA).BeginInit();
            this.bindingSourceEVIDENCIJARADNICI = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceEVIDENCIJARADNICI).BeginInit();
            this.layoutManagerformEVIDENCIJA = new TableLayoutPanel();
            this.layoutManagerformEVIDENCIJA.SuspendLayout();
            this.layoutManagerformEVIDENCIJA.AutoSize = true;
            this.layoutManagerformEVIDENCIJA.Dock = DockStyle.Fill;
            this.layoutManagerformEVIDENCIJA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformEVIDENCIJA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformEVIDENCIJA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformEVIDENCIJA.Size = size;
            this.layoutManagerformEVIDENCIJA.ColumnCount = 2;
            this.layoutManagerformEVIDENCIJA.RowCount = 5;
            this.layoutManagerformEVIDENCIJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformEVIDENCIJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformEVIDENCIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformEVIDENCIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformEVIDENCIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformEVIDENCIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformEVIDENCIJA.RowStyles.Add(new RowStyle());
            this.label1MJESEC = new UltraLabel();
            this.textMJESEC = new UltraNumericEditor();
            this.label1IDGODINE = new UltraLabel();
            this.textIDGODINE = new UltraNumericEditor();
            this.label1BROJEVIDENCIJE = new UltraLabel();
            this.textBROJEVIDENCIJE = new UltraNumericEditor();
            this.label1OPISEVIDENCIJE = new UltraLabel();
            this.textOPISEVIDENCIJE = new UltraTextEditor();
            this.grdLevelEVIDENCIJARADNICI = new UltraGrid();
            ((ISupportInitialize) this.textMJESEC).BeginInit();
            ((ISupportInitialize) this.textIDGODINE).BeginInit();
            ((ISupportInitialize) this.textBROJEVIDENCIJE).BeginInit();
            ((ISupportInitialize) this.textOPISEVIDENCIJE).BeginInit();
            ((ISupportInitialize) this.grdLevelEVIDENCIJARADNICI).BeginInit();
            UltraGridBand band = new UltraGridBand("EVIDENCIJARADNICI", -1);
            UltraGridColumn column7 = new UltraGridColumn("MJESEC");
            UltraGridColumn column3 = new UltraGridColumn("IDGODINE");
            UltraGridColumn column2 = new UltraGridColumn("BROJEVIDENCIJE");
            UltraGridColumn column4 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column5 = new UltraGridColumn("columnIDRADNIKAddNew", 0);
            UltraGridColumn column8 = new UltraGridColumn("PREZIME");
            UltraGridColumn column6 = new UltraGridColumn("IME");
            UltraGridColumn column51 = new UltraGridColumn("TJEDNIFONDSATI");
            UltraGridColumn column = new UltraGridColumn("AKTIVAN");
            UltraGridBand band2 = new UltraGridBand("EVIDENCIJARADNICI_EVIDENCIJARADNICISATI", 0);
            UltraGridColumn column24 = new UltraGridColumn("MJESEC");
            UltraGridColumn column19 = new UltraGridColumn("IDGODINE");
            UltraGridColumn column12 = new UltraGridColumn("BROJEVIDENCIJE");
            UltraGridColumn column20 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column21 = new UltraGridColumn("columnIDRADNIKAddNew", 0);
            UltraGridColumn column13 = new UltraGridColumn("DAN");
            UltraGridColumn column41 = new UltraGridColumn("PRVASMJENAIDSMJENE");
            UltraGridColumn column42 = new UltraGridColumn("PRVASMJENAOPISSMJENE");
            UltraGridColumn column43 = new UltraGridColumn("PRVASMJENAPOCETAK");
            UltraGridColumn column44 = new UltraGridColumn("PRVASMJENAZAVRSETAK");
            UltraGridColumn column14 = new UltraGridColumn("DRUGASMJENAIDSMJENE");
            UltraGridColumn column15 = new UltraGridColumn("DRUGASMJENAOPISSMJENE");
            UltraGridColumn column16 = new UltraGridColumn("DRUGASMJENAPOCETAK");
            UltraGridColumn column17 = new UltraGridColumn("DRUGASMJENAZAVRSETAK");
            UltraGridColumn column46 = new UltraGridColumn("RR");
            UltraGridColumn column35 = new UltraGridColumn("ODTOGASMJENSKI");
            UltraGridColumn column30 = new UltraGridColumn("ODTOGADVOKRATNI");
            UltraGridColumn column32 = new UltraGridColumn("ODTOGAPOSEBNI1");
            UltraGridColumn column33 = new UltraGridColumn("ODTOGAPOSEBNI2");
            UltraGridColumn column34 = new UltraGridColumn("ODTOGAPOSEBNI3");
            UltraGridColumn column31 = new UltraGridColumn("ODTOGAKOMBINACIJA");
            UltraGridColumn column36 = new UltraGridColumn("ODTOGASPECIJALNA");
            UltraGridColumn column22 = new UltraGridColumn("IZNADNORME");
            UltraGridColumn column38 = new UltraGridColumn("PR");
            UltraGridColumn column47 = new UltraGridColumn("SP");
            UltraGridColumn column18 = new UltraGridColumn("GO");
            UltraGridColumn column11 = new UltraGridColumn("BOP");
            UltraGridColumn column10 = new UltraGridColumn("BOF");
            UltraGridColumn column45 = new UltraGridColumn("RD");
            UltraGridColumn column37 = new UltraGridColumn("PD");
            UltraGridColumn column29 = new UltraGridColumn("NPD");
            UltraGridColumn column9 = new UltraGridColumn("BLG");
            UltraGridColumn column50 = new UltraGridColumn("ZAS");
            UltraGridColumn column40 = new UltraGridColumn("PRV");
            UltraGridColumn column49 = new UltraGridColumn("TR");
            UltraGridColumn column39 = new UltraGridColumn("PRI");
            UltraGridColumn column26 = new UltraGridColumn("NEN");
            UltraGridColumn column27 = new UltraGridColumn("NENNEODOBRENA");
            UltraGridColumn column48 = new UltraGridColumn("STR");
            UltraGridColumn column23 = new UltraGridColumn("LOC");
            UltraGridColumn column25 = new UltraGridColumn("NED");
            UltraGridColumn column28 = new UltraGridColumn("NOC");
            this.dsEVIDENCIJADataSet1 = new EVIDENCIJADataSet();
            this.dsEVIDENCIJADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsEVIDENCIJADataSet1.DataSetName = "dsEVIDENCIJA";
            this.dsEVIDENCIJADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceEVIDENCIJA.DataSource = this.dsEVIDENCIJADataSet1;
            this.bindingSourceEVIDENCIJA.DataMember = "EVIDENCIJA";
            ((ISupportInitialize) this.bindingSourceEVIDENCIJA).BeginInit();
            this.bindingSourceEVIDENCIJARADNICI.DataSource = this.bindingSourceEVIDENCIJA;
            this.bindingSourceEVIDENCIJARADNICI.DataMember = "EVIDENCIJA_EVIDENCIJARADNICI";
            point = new System.Drawing.Point(0, 0);
            this.label1MJESEC.Location = point;
            this.label1MJESEC.Name = "label1MJESEC";
            this.label1MJESEC.TabIndex = 1;
            this.label1MJESEC.Tag = "labelMJESEC";
            this.label1MJESEC.Text = "MJESEC:";
            this.label1MJESEC.StyleSetName = "FieldUltraLabel";
            this.label1MJESEC.AutoSize = true;
            this.label1MJESEC.Anchor = AnchorStyles.Left;
            this.label1MJESEC.Appearance.TextVAlign = VAlign.Middle;
            this.label1MJESEC.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1MJESEC.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1MJESEC.ImageSize = size;
            this.label1MJESEC.Appearance.ForeColor = Color.Black;
            this.label1MJESEC.BackColor = Color.Transparent;
            this.layoutManagerformEVIDENCIJA.Controls.Add(this.label1MJESEC, 0, 0);
            this.layoutManagerformEVIDENCIJA.SetColumnSpan(this.label1MJESEC, 1);
            this.layoutManagerformEVIDENCIJA.SetRowSpan(this.label1MJESEC, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1MJESEC.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1MJESEC.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x17);
            this.label1MJESEC.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textMJESEC.Location = point;
            this.textMJESEC.Name = "textMJESEC";
            this.textMJESEC.Tag = "MJESEC";
            this.textMJESEC.TabIndex = 0;
            this.textMJESEC.Anchor = AnchorStyles.Left;
            this.textMJESEC.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textMJESEC.ReadOnly = false;
            this.textMJESEC.PromptChar = ' ';
            this.textMJESEC.Enter += new EventHandler(this.numericEditor_Enter);
            this.textMJESEC.DataBindings.Add(new Binding("Value", this.bindingSourceEVIDENCIJA, "MJESEC"));
            this.textMJESEC.NumericType = NumericType.Integer;
            this.textMJESEC.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformEVIDENCIJA.Controls.Add(this.textMJESEC, 1, 0);
            this.layoutManagerformEVIDENCIJA.SetColumnSpan(this.textMJESEC, 1);
            this.layoutManagerformEVIDENCIJA.SetRowSpan(this.textMJESEC, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textMJESEC.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textMJESEC.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textMJESEC.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDGODINE.Location = point;
            this.label1IDGODINE.Name = "label1IDGODINE";
            this.label1IDGODINE.TabIndex = 1;
            this.label1IDGODINE.Tag = "labelIDGODINE";
            this.label1IDGODINE.Text = "Godina:";
            this.label1IDGODINE.StyleSetName = "FieldUltraLabel";
            this.label1IDGODINE.AutoSize = true;
            this.label1IDGODINE.Anchor = AnchorStyles.Left;
            this.label1IDGODINE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDGODINE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDGODINE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDGODINE.ImageSize = size;
            this.label1IDGODINE.Appearance.ForeColor = Color.Black;
            this.label1IDGODINE.BackColor = Color.Transparent;
            this.layoutManagerformEVIDENCIJA.Controls.Add(this.label1IDGODINE, 0, 1);
            this.layoutManagerformEVIDENCIJA.SetColumnSpan(this.label1IDGODINE, 1);
            this.layoutManagerformEVIDENCIJA.SetRowSpan(this.label1IDGODINE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDGODINE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDGODINE.MinimumSize = size;
            size = new System.Drawing.Size(60, 0x17);
            this.label1IDGODINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDGODINE.Location = point;
            this.textIDGODINE.Name = "textIDGODINE";
            this.textIDGODINE.Tag = "IDGODINE";
            this.textIDGODINE.TabIndex = 0;
            this.textIDGODINE.Anchor = AnchorStyles.Left;
            this.textIDGODINE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDGODINE.ReadOnly = false;
            this.textIDGODINE.PromptChar = ' ';
            this.textIDGODINE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDGODINE.DataBindings.Add(new Binding("Value", this.bindingSourceEVIDENCIJA, "IDGODINE"));
            this.textIDGODINE.NumericType = NumericType.Integer;
            this.textIDGODINE.MaskInput = "{LOC}-nnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonGODINEIDGODINE",
                Tag = "editorButtonGODINEIDGODINE",
                Text = "..."
            };
            this.textIDGODINE.ButtonsRight.Add(button);
            this.textIDGODINE.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptGODINEIDGODINE);
            this.layoutManagerformEVIDENCIJA.Controls.Add(this.textIDGODINE, 1, 1);
            this.layoutManagerformEVIDENCIJA.SetColumnSpan(this.textIDGODINE, 1);
            this.layoutManagerformEVIDENCIJA.SetRowSpan(this.textIDGODINE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDGODINE.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textIDGODINE.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textIDGODINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1BROJEVIDENCIJE.Location = point;
            this.label1BROJEVIDENCIJE.Name = "label1BROJEVIDENCIJE";
            this.label1BROJEVIDENCIJE.TabIndex = 1;
            this.label1BROJEVIDENCIJE.Tag = "labelBROJEVIDENCIJE";
            this.label1BROJEVIDENCIJE.Text = "Broj evidencije:";
            this.label1BROJEVIDENCIJE.StyleSetName = "FieldUltraLabel";
            this.label1BROJEVIDENCIJE.AutoSize = true;
            this.label1BROJEVIDENCIJE.Anchor = AnchorStyles.Left;
            this.label1BROJEVIDENCIJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1BROJEVIDENCIJE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1BROJEVIDENCIJE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1BROJEVIDENCIJE.ImageSize = size;
            this.label1BROJEVIDENCIJE.Appearance.ForeColor = Color.Black;
            this.label1BROJEVIDENCIJE.BackColor = Color.Transparent;
            this.layoutManagerformEVIDENCIJA.Controls.Add(this.label1BROJEVIDENCIJE, 0, 2);
            this.layoutManagerformEVIDENCIJA.SetColumnSpan(this.label1BROJEVIDENCIJE, 1);
            this.layoutManagerformEVIDENCIJA.SetRowSpan(this.label1BROJEVIDENCIJE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BROJEVIDENCIJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BROJEVIDENCIJE.MinimumSize = size;
            size = new System.Drawing.Size(0x6d, 0x17);
            this.label1BROJEVIDENCIJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textBROJEVIDENCIJE.Location = point;
            this.textBROJEVIDENCIJE.Name = "textBROJEVIDENCIJE";
            this.textBROJEVIDENCIJE.Tag = "BROJEVIDENCIJE";
            this.textBROJEVIDENCIJE.TabIndex = 0;
            this.textBROJEVIDENCIJE.Anchor = AnchorStyles.Left;
            this.textBROJEVIDENCIJE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textBROJEVIDENCIJE.ReadOnly = false;
            this.textBROJEVIDENCIJE.PromptChar = ' ';
            this.textBROJEVIDENCIJE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textBROJEVIDENCIJE.DataBindings.Add(new Binding("Value", this.bindingSourceEVIDENCIJA, "BROJEVIDENCIJE"));
            this.textBROJEVIDENCIJE.NumericType = NumericType.Integer;
            this.textBROJEVIDENCIJE.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformEVIDENCIJA.Controls.Add(this.textBROJEVIDENCIJE, 1, 2);
            this.layoutManagerformEVIDENCIJA.SetColumnSpan(this.textBROJEVIDENCIJE, 1);
            this.layoutManagerformEVIDENCIJA.SetRowSpan(this.textBROJEVIDENCIJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textBROJEVIDENCIJE.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textBROJEVIDENCIJE.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textBROJEVIDENCIJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1OPISEVIDENCIJE.Location = point;
            this.label1OPISEVIDENCIJE.Name = "label1OPISEVIDENCIJE";
            this.label1OPISEVIDENCIJE.TabIndex = 1;
            this.label1OPISEVIDENCIJE.Tag = "labelOPISEVIDENCIJE";
            this.label1OPISEVIDENCIJE.Text = "Opis:";
            this.label1OPISEVIDENCIJE.StyleSetName = "FieldUltraLabel";
            this.label1OPISEVIDENCIJE.AutoSize = true;
            this.label1OPISEVIDENCIJE.Anchor = AnchorStyles.Left;
            this.label1OPISEVIDENCIJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1OPISEVIDENCIJE.Appearance.ForeColor = Color.Black;
            this.label1OPISEVIDENCIJE.BackColor = Color.Transparent;
            this.layoutManagerformEVIDENCIJA.Controls.Add(this.label1OPISEVIDENCIJE, 0, 3);
            this.layoutManagerformEVIDENCIJA.SetColumnSpan(this.label1OPISEVIDENCIJE, 1);
            this.layoutManagerformEVIDENCIJA.SetRowSpan(this.label1OPISEVIDENCIJE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1OPISEVIDENCIJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1OPISEVIDENCIJE.MinimumSize = size;
            size = new System.Drawing.Size(0x2e, 0x17);
            this.label1OPISEVIDENCIJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textOPISEVIDENCIJE.Location = point;
            this.textOPISEVIDENCIJE.Name = "textOPISEVIDENCIJE";
            this.textOPISEVIDENCIJE.Tag = "OPISEVIDENCIJE";
            this.textOPISEVIDENCIJE.TabIndex = 0;
            this.textOPISEVIDENCIJE.Anchor = AnchorStyles.Left;
            this.textOPISEVIDENCIJE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textOPISEVIDENCIJE.ReadOnly = false;
            this.textOPISEVIDENCIJE.DataBindings.Add(new Binding("Text", this.bindingSourceEVIDENCIJA, "OPISEVIDENCIJE"));
            this.textOPISEVIDENCIJE.MaxLength = 40;
            this.layoutManagerformEVIDENCIJA.Controls.Add(this.textOPISEVIDENCIJE, 1, 3);
            this.layoutManagerformEVIDENCIJA.SetColumnSpan(this.textOPISEVIDENCIJE, 1);
            this.layoutManagerformEVIDENCIJA.SetRowSpan(this.textOPISEVIDENCIJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textOPISEVIDENCIJE.Margin = padding;
            size = new System.Drawing.Size(0x128, 0x16);
            this.textOPISEVIDENCIJE.MinimumSize = size;
            size = new System.Drawing.Size(0x128, 0x16);
            this.textOPISEVIDENCIJE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelEVIDENCIJARADNICI.Location = point;
            this.grdLevelEVIDENCIJARADNICI.Name = "grdLevelEVIDENCIJARADNICI";
            this.layoutManagerformEVIDENCIJA.Controls.Add(this.grdLevelEVIDENCIJARADNICI, 0, 4);
            this.layoutManagerformEVIDENCIJA.SetColumnSpan(this.grdLevelEVIDENCIJARADNICI, 2);
            this.layoutManagerformEVIDENCIJA.SetRowSpan(this.grdLevelEVIDENCIJARADNICI, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelEVIDENCIJARADNICI.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelEVIDENCIJARADNICI.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelEVIDENCIJARADNICI.Size = size;
            this.grdLevelEVIDENCIJARADNICI.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformEVIDENCIJA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceEVIDENCIJA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.Disabled;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.EVIDENCIJAMJESECDescription;
            column7.Width = 0x3a;
            appearance6.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnn";
            column7.PromptChar = ' ';
            column7.Format = "";
            column7.CellAppearance = appearance6;
            column7.Hidden = true;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.Disabled;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.EVIDENCIJAIDGODINEDescription;
            column3.Width = 0x3a;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.Disabled;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.EVIDENCIJABROJEVIDENCIJEDescription;
            column2.Width = 0x77;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            column2.Hidden = true;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.EVIDENCIJAIDRADNIKDescription;
            column4.Width = 0x69;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            column5.AllowGroupBy = DefaultableBoolean.False;
            column5.AutoSizeEdit = DefaultableBoolean.False;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column5.CellAppearance.BorderAlpha = Alpha.Transparent;
            column5.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column5.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column5.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column5.Header.Enabled = false;
            column5.Header.Fixed = true;
            column5.Header.Caption = "";
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column5.Width = 20;
            column5.MinWidth = 20;
            column5.MaxWidth = 20;
            column5.Tag = "RADNIKIDRADNIKAddNew";
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.Disabled;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.EVIDENCIJAPREZIMEDescription;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.Disabled;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.EVIDENCIJAIMEDescription;
            column6.Width = 0x128;
            column6.Format = "";
            column6.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            column51.CellActivation = Activation.Disabled;
            column51.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column51.Header.Caption = StringResources.EVIDENCIJATJEDNIFONDSATIDescription;
            column51.Width = 0xd9;
            appearance49.TextHAlign = HAlign.Right;
            column51.MaskInput = "{LOC}-nnn.nn";
            column51.PromptChar = ' ';
            column51.Format = "F2";
            column51.CellAppearance = appearance49;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.Disabled;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.EVIDENCIJAAKTIVANDescription;
            column.Width = 0x41;
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.Disabled;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.EVIDENCIJAMJESECDescription;
            column24.Width = 0x3a;
            appearance22.TextHAlign = HAlign.Right;
            column24.MaskInput = "{LOC}-nnnnn";
            column24.PromptChar = ' ';
            column24.Format = "";
            column24.CellAppearance = appearance22;
            column24.Hidden = true;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.Disabled;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.EVIDENCIJAIDGODINEDescription;
            column19.Width = 0x3a;
            appearance18.TextHAlign = HAlign.Right;
            column19.MaskInput = "{LOC}-nnnn";
            column19.PromptChar = ' ';
            column19.Format = "";
            column19.CellAppearance = appearance18;
            column19.Hidden = true;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.Disabled;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.EVIDENCIJABROJEVIDENCIJEDescription;
            column12.Width = 0x77;
            appearance11.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnn";
            column12.PromptChar = ' ';
            column12.Format = "";
            column12.CellAppearance = appearance11;
            column12.Hidden = true;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.Disabled;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.EVIDENCIJAIDRADNIKDescription;
            column20.Width = 0x69;
            column20.Format = "";
            column20.CellAppearance = appearance19;
            column20.Hidden = true;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.EVIDENCIJADANDescription;
            column13.Width = 0x33;
            appearance12.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnnnn";
            column13.PromptChar = ' ';
            column13.Format = "";
            column13.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            column41.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column41.Header.Caption = StringResources.EVIDENCIJAPRVASMJENAIDSMJENEDescription;
            column41.Width = 0x48;
            appearance38.TextHAlign = HAlign.Right;
            column41.MaskInput = "{LOC}-nnnnn";
            column41.PromptChar = ' ';
            column41.Format = "";
            column41.CellAppearance = appearance38;
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            column42.CellActivation = Activation.Disabled;
            column42.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column42.Header.Caption = StringResources.EVIDENCIJAPRVASMJENAOPISSMJENEDescription;
            column42.Width = 0x128;
            column42.Format = "";
            column42.CellAppearance = appearance39;
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            column43.CellActivation = Activation.Disabled;
            column43.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column43.Header.Caption = StringResources.EVIDENCIJAPRVASMJENAPOCETAKDescription;
            column43.Width = 0x41;
            column43.Format = "";
            column43.CellAppearance = appearance40;
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            column44.CellActivation = Activation.Disabled;
            column44.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column44.Header.Caption = StringResources.EVIDENCIJAPRVASMJENAZAVRSETAKDescription;
            column44.Width = 0x4f;
            column44.Format = "";
            column44.CellAppearance = appearance41;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.EVIDENCIJADRUGASMJENAIDSMJENEDescription;
            column14.Width = 0x48;
            appearance13.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnn";
            column14.PromptChar = ' ';
            column14.Format = "";
            column14.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.Disabled;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.EVIDENCIJADRUGASMJENAOPISSMJENEDescription;
            column15.Width = 0x128;
            column15.Format = "";
            column15.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.Disabled;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.EVIDENCIJADRUGASMJENAPOCETAKDescription;
            column16.Width = 0x41;
            column16.Format = "";
            column16.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.Disabled;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.EVIDENCIJADRUGASMJENAZAVRSETAKDescription;
            column17.Width = 0x4f;
            column17.Format = "";
            column17.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            column46.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column46.Header.Caption = StringResources.EVIDENCIJARRDescription;
            column46.Width = 0x60;
            appearance44.TextHAlign = HAlign.Right;
            column46.MaskInput = "{LOC}-nnn.nn";
            column46.PromptChar = ' ';
            column46.Format = "F2";
            column46.CellAppearance = appearance44;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column35.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column35.Header.Caption = StringResources.EVIDENCIJAODTOGASMJENSKIDescription;
            column35.Width = 0x4b;
            appearance33.TextHAlign = HAlign.Right;
            column35.MaskInput = "{LOC}-nnn.nn";
            column35.PromptChar = ' ';
            column35.Format = "F2";
            column35.CellAppearance = appearance33;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.EVIDENCIJAODTOGADVOKRATNIDescription;
            column30.Width = 0x52;
            appearance28.TextHAlign = HAlign.Right;
            column30.MaskInput = "{LOC}-nnn.nn";
            column30.PromptChar = ' ';
            column30.Format = "F2";
            column30.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.EVIDENCIJAODTOGAPOSEBNI1Description;
            column32.Width = 0x59;
            appearance30.TextHAlign = HAlign.Right;
            column32.MaskInput = "{LOC}-nnn.nn";
            column32.PromptChar = ' ';
            column32.Format = "F2";
            column32.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.EVIDENCIJAODTOGAPOSEBNI2Description;
            column33.Width = 0x60;
            appearance31.TextHAlign = HAlign.Right;
            column33.MaskInput = "{LOC}-nnn.nn";
            column33.PromptChar = ' ';
            column33.Format = "F2";
            column33.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column34.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column34.Header.Caption = StringResources.EVIDENCIJAODTOGAPOSEBNI3Description;
            column34.Width = 0x60;
            appearance32.TextHAlign = HAlign.Right;
            column34.MaskInput = "{LOC}-nnn.nn";
            column34.PromptChar = ' ';
            column34.Format = "F2";
            column34.CellAppearance = appearance32;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.EVIDENCIJAODTOGAKOMBINACIJADescription;
            column31.Width = 0x60;
            appearance29.TextHAlign = HAlign.Right;
            column31.MaskInput = "{LOC}-nnn.nn";
            column31.PromptChar = ' ';
            column31.Format = "F2";
            column31.CellAppearance = appearance29;
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            column36.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column36.Header.Caption = StringResources.EVIDENCIJAODTOGASPECIJALNADescription;
            column36.Width = 0xa3;
            appearance34.TextHAlign = HAlign.Right;
            column36.MaskInput = "{LOC}-nnn.nn";
            column36.PromptChar = ' ';
            column36.Format = "F2";
            column36.CellAppearance = appearance34;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.EVIDENCIJAIZNADNORMEDescription;
            column22.Width = 0x7b;
            appearance20.TextHAlign = HAlign.Right;
            column22.MaskInput = "{LOC}-nnn.nn";
            column22.PromptChar = ' ';
            column22.Format = "F2";
            column22.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            column38.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column38.Header.Caption = StringResources.EVIDENCIJAPRDescription;
            column38.Width = 0x37;
            appearance36.TextHAlign = HAlign.Right;
            column38.MaskInput = "{LOC}-nnn.nn";
            column38.PromptChar = ' ';
            column38.Format = "F2";
            column38.CellAppearance = appearance36;
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            column47.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column47.Header.Caption = StringResources.EVIDENCIJASPDescription;
            column47.Width = 0x37;
            appearance45.TextHAlign = HAlign.Right;
            column47.MaskInput = "{LOC}-nnn.nn";
            column47.PromptChar = ' ';
            column47.Format = "F2";
            column47.CellAppearance = appearance45;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.EVIDENCIJAGODescription;
            column18.Width = 0x37;
            appearance17.TextHAlign = HAlign.Right;
            column18.MaskInput = "{LOC}-nnn.nn";
            column18.PromptChar = ' ';
            column18.Format = "F2";
            column18.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.EVIDENCIJABOPDescription;
            column11.Width = 0x37;
            appearance10.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.EVIDENCIJABOFDescription;
            column10.Width = 0x37;
            appearance9.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            column45.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column45.Header.Caption = StringResources.EVIDENCIJARDDescription;
            column45.Width = 0x37;
            appearance43.TextHAlign = HAlign.Right;
            column45.MaskInput = "{LOC}-nnn.nn";
            column45.PromptChar = ' ';
            column45.Format = "F2";
            column45.CellAppearance = appearance43;
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            column37.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column37.Header.Caption = StringResources.EVIDENCIJAPDDescription;
            column37.Width = 0x37;
            appearance35.TextHAlign = HAlign.Right;
            column37.MaskInput = "{LOC}-nnn.nn";
            column37.PromptChar = ' ';
            column37.Format = "F2";
            column37.CellAppearance = appearance35;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.EVIDENCIJANPDDescription;
            column29.Width = 0x37;
            appearance27.TextHAlign = HAlign.Right;
            column29.MaskInput = "{LOC}-nnn.nn";
            column29.PromptChar = ' ';
            column29.Format = "F2";
            column29.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.EVIDENCIJABLGDescription;
            column9.Width = 0x37;
            appearance8.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            column50.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column50.Header.Caption = StringResources.EVIDENCIJAZASDescription;
            column50.Width = 0x37;
            appearance48.TextHAlign = HAlign.Right;
            column50.MaskInput = "{LOC}-nnn.nn";
            column50.PromptChar = ' ';
            column50.Format = "F2";
            column50.CellAppearance = appearance48;
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            column40.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column40.Header.Caption = StringResources.EVIDENCIJAPRVDescription;
            column40.Width = 0x37;
            appearance42.TextHAlign = HAlign.Right;
            column40.MaskInput = "{LOC}-nnn.nn";
            column40.PromptChar = ' ';
            column40.Format = "F2";
            column40.CellAppearance = appearance42;
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            column49.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column49.Header.Caption = StringResources.EVIDENCIJATRDescription;
            column49.Width = 0x37;
            appearance47.TextHAlign = HAlign.Right;
            column49.MaskInput = "{LOC}-nnn.nn";
            column49.PromptChar = ' ';
            column49.Format = "F2";
            column49.CellAppearance = appearance47;
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            column39.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column39.Header.Caption = StringResources.EVIDENCIJAPRIDescription;
            column39.Width = 0x37;
            appearance37.TextHAlign = HAlign.Right;
            column39.MaskInput = "{LOC}-nnn.nn";
            column39.PromptChar = ' ';
            column39.Format = "F2";
            column39.CellAppearance = appearance37;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.EVIDENCIJANENDescription;
            column26.Width = 0x9c;
            appearance24.TextHAlign = HAlign.Right;
            column26.MaskInput = "{LOC}-nnn.nn";
            column26.PromptChar = ' ';
            column26.Format = "F2";
            column26.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.EVIDENCIJANENNEODOBRENADescription;
            column27.Width = 170;
            appearance25.TextHAlign = HAlign.Right;
            column27.MaskInput = "{LOC}-nnn.nn";
            column27.PromptChar = ' ';
            column27.Format = "F2";
            column27.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            column48.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column48.Header.Caption = StringResources.EVIDENCIJASTRDescription;
            column48.Width = 0x37;
            appearance46.TextHAlign = HAlign.Right;
            column48.MaskInput = "{LOC}-nnn.nn";
            column48.PromptChar = ' ';
            column48.Format = "F2";
            column48.CellAppearance = appearance46;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.EVIDENCIJALOCDescription;
            column23.Width = 0x37;
            appearance21.TextHAlign = HAlign.Right;
            column23.MaskInput = "{LOC}-nnn.nn";
            column23.PromptChar = ' ';
            column23.Format = "F2";
            column23.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.EVIDENCIJANEDDescription;
            column25.Width = 0x37;
            appearance23.TextHAlign = HAlign.Right;
            column25.MaskInput = "{LOC}-nnn.nn";
            column25.PromptChar = ' ';
            column25.Format = "F2";
            column25.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.EVIDENCIJANOCDescription;
            column28.Width = 0x37;
            appearance26.TextHAlign = HAlign.Right;
            column28.MaskInput = "{LOC}-nnn.nn";
            column28.PromptChar = ' ';
            column28.Format = "F2";
            column28.CellAppearance = appearance26;
            band2.Columns.Add(column20);
            column20.Header.VisiblePosition = 0;
            band2.Columns.Add(column21);
            column21.Header.VisiblePosition = 1;
            band2.Columns.Add(column13);
            column13.Header.VisiblePosition = 2;
            band2.Columns.Add(column41);
            column41.Header.VisiblePosition = 3;
            band2.Columns.Add(column42);
            column42.Header.VisiblePosition = 4;
            band2.Columns.Add(column43);
            column43.Header.VisiblePosition = 5;
            band2.Columns.Add(column44);
            column44.Header.VisiblePosition = 6;
            band2.Columns.Add(column14);
            column14.Header.VisiblePosition = 7;
            band2.Columns.Add(column15);
            column15.Header.VisiblePosition = 8;
            band2.Columns.Add(column16);
            column16.Header.VisiblePosition = 9;
            band2.Columns.Add(column17);
            column17.Header.VisiblePosition = 10;
            band2.Columns.Add(column46);
            column46.Header.VisiblePosition = 11;
            band2.Columns.Add(column35);
            column35.Header.VisiblePosition = 12;
            band2.Columns.Add(column30);
            column30.Header.VisiblePosition = 13;
            band2.Columns.Add(column32);
            column32.Header.VisiblePosition = 14;
            band2.Columns.Add(column33);
            column33.Header.VisiblePosition = 15;
            band2.Columns.Add(column34);
            column34.Header.VisiblePosition = 0x10;
            band2.Columns.Add(column31);
            column31.Header.VisiblePosition = 0x11;
            band2.Columns.Add(column36);
            column36.Header.VisiblePosition = 0x12;
            band2.Columns.Add(column22);
            column22.Header.VisiblePosition = 0x13;
            band2.Columns.Add(column38);
            column38.Header.VisiblePosition = 20;
            band2.Columns.Add(column47);
            column47.Header.VisiblePosition = 0x15;
            band2.Columns.Add(column18);
            column18.Header.VisiblePosition = 0x16;
            band2.Columns.Add(column11);
            column11.Header.VisiblePosition = 0x17;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 0x18;
            band2.Columns.Add(column45);
            column45.Header.VisiblePosition = 0x19;
            band2.Columns.Add(column37);
            column37.Header.VisiblePosition = 0x1a;
            band2.Columns.Add(column29);
            column29.Header.VisiblePosition = 0x1b;
            band2.Columns.Add(column9);
            column9.Header.VisiblePosition = 0x1c;
            band2.Columns.Add(column50);
            column50.Header.VisiblePosition = 0x1d;
            band2.Columns.Add(column40);
            column40.Header.VisiblePosition = 30;
            band2.Columns.Add(column49);
            column49.Header.VisiblePosition = 0x1f;
            band2.Columns.Add(column39);
            column39.Header.VisiblePosition = 0x20;
            band2.Columns.Add(column26);
            column26.Header.VisiblePosition = 0x21;
            band2.Columns.Add(column27);
            column27.Header.VisiblePosition = 0x22;
            band2.Columns.Add(column48);
            column48.Header.VisiblePosition = 0x23;
            band2.Columns.Add(column23);
            column23.Header.VisiblePosition = 0x24;
            band2.Columns.Add(column25);
            column25.Header.VisiblePosition = 0x25;
            band2.Columns.Add(column28);
            column28.Header.VisiblePosition = 0x26;
            band2.Columns.Add(column24);
            column24.Header.VisiblePosition = 0x27;
            band2.Columns.Add(column19);
            column19.Header.VisiblePosition = 40;
            band2.Columns.Add(column12);
            column12.Header.VisiblePosition = 0x29;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 0;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 1;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 2;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 3;
            band.Columns.Add(column51);
            column51.Header.VisiblePosition = 4;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 5;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 6;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 7;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 8;
            this.grdLevelEVIDENCIJARADNICI.Visible = true;
            this.grdLevelEVIDENCIJARADNICI.Name = "grdLevelEVIDENCIJARADNICI";
            this.grdLevelEVIDENCIJARADNICI.Tag = "EVIDENCIJARADNICI";
            this.grdLevelEVIDENCIJARADNICI.TabIndex = 9;
            this.grdLevelEVIDENCIJARADNICI.Dock = DockStyle.Fill;
            this.grdLevelEVIDENCIJARADNICI.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelEVIDENCIJARADNICI.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelEVIDENCIJARADNICI.DataSource = this.bindingSourceEVIDENCIJARADNICI;
            this.grdLevelEVIDENCIJARADNICI.Enter += new EventHandler(this.grdLevelEVIDENCIJARADNICI_Enter);
            this.grdLevelEVIDENCIJARADNICI.AfterRowInsert += new RowEventHandler(this.grdLevelEVIDENCIJARADNICI_AfterRowInsert);
            this.grdLevelEVIDENCIJARADNICI.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelEVIDENCIJARADNICI.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelEVIDENCIJARADNICI.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
            this.grdLevelEVIDENCIJARADNICI.DisplayLayout.BandsSerializer.Add(band);
            this.grdLevelEVIDENCIJARADNICI.DisplayLayout.BandsSerializer.Add(band2);
            this.Name = "EVIDENCIJAFormUserControl";
            this.Text = "EVIDENCIJA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.EVIDENCIJAFormUserControl_Load);
            this.layoutManagerformEVIDENCIJA.ResumeLayout(false);
            this.layoutManagerformEVIDENCIJA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceEVIDENCIJA).EndInit();
            ((ISupportInitialize) this.bindingSourceEVIDENCIJARADNICI).EndInit();
            ((ISupportInitialize) this.textMJESEC).EndInit();
            ((ISupportInitialize) this.textIDGODINE).EndInit();
            ((ISupportInitialize) this.textBROJEVIDENCIJE).EndInit();
            ((ISupportInitialize) this.textOPISEVIDENCIJE).EndInit();
            ((ISupportInitialize) this.grdLevelEVIDENCIJARADNICI).EndInit();
            this.dsEVIDENCIJADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.EVIDENCIJAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceEVIDENCIJA, this.EVIDENCIJAController.WorkItem, this))
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
            this.label1MJESEC.Text = StringResources.EVIDENCIJAMJESECDescription;
            this.label1IDGODINE.Text = StringResources.EVIDENCIJAIDGODINEDescription;
            this.label1BROJEVIDENCIJE.Text = StringResources.EVIDENCIJABROJEVIDENCIJEDescription;
            this.label1OPISEVIDENCIJE.Text = StringResources.EVIDENCIJAOPISEVIDENCIJEDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedInLinesIDRADNIK(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("RADNIK", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.EVIDENCIJAController.WorkItem.Items.Contains("EVIDENCIJA|EVIDENCIJA"))
            {
                this.EVIDENCIJAController.WorkItem.Items.Add(this.bindingSourceEVIDENCIJA, "EVIDENCIJA|EVIDENCIJA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsEVIDENCIJADataSet1.EVIDENCIJA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.m_Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.m_Mode;
                this.m_BaseMethods.FormLoadStyle();
                this.textIDGODINE.ButtonsRight[0].Visible = false;
            }
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.EVIDENCIJAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.EVIDENCIJAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.EVIDENCIJAController.Update(this))
            {
                this.EVIDENCIJAController.DataSet = new EVIDENCIJADataSet();
                DataSetUtil.AddEmptyRow(this.EVIDENCIJAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.EVIDENCIJAController.DataSet.EVIDENCIJA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetComboBoxColumnProperties()
        {
            PregledRadnikaComboBox box = new PregledRadnikaComboBox();
            box.Fill();
            DataView defaultView = box.DataSet.Tables["RADNIK"].DefaultView;
            CreateValueList(this.grdLevelEVIDENCIJARADNICI, "RADNIKIDRADNIK", defaultView, "IDRADNIK", "SPOJENOPREZIME", false);
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelEVIDENCIJARADNICI, "IDRADNIK");
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            gridColumn.ValueList = this.grdLevelEVIDENCIJARADNICI.DisplayLayout.ValueLists["RADNIKIDRADNIK"];
            gridColumn.Width = 370;
            UltraGridColumn column3 = FormHelperClass.GetGridColumn(this.grdLevelEVIDENCIJARADNICI, "PRVASMJENAIDSMJENE");
            column3.Tag = "SMJENEPRVASMJENAIDSMJENE";
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            UltraGridColumn column2 = FormHelperClass.GetGridColumn(this.grdLevelEVIDENCIJARADNICI, "DRUGASMJENAIDSMJENE");
            column2.Tag = "SMJENEDRUGASMJENAIDSMJENE";
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            this.grdLevelEVIDENCIJARADNICI.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelEVIDENCIJARADNICI.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.textMJESEC.Focus();
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

        private void UpdateValuesGODINEIDGODINE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourceEVIDENCIJA.Current).Row["IDGODINE"] = RuntimeHelpers.GetObjectValue(result["IDGODINE"]);
                this.bindingSourceEVIDENCIJA.ResetCurrentItem();
            }
        }

        private void UpdateValuesIDRADNIK(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["IDRADNIK"] = RuntimeHelpers.GetObjectValue(result["IDRADNIK"]);
                    row["PREZIME"] = RuntimeHelpers.GetObjectValue(result["PREZIME"]);
                    row["IME"] = RuntimeHelpers.GetObjectValue(result["IME"]);
                    row["TJEDNIFONDSATI"] = RuntimeHelpers.GetObjectValue(result["TJEDNIFONDSATI"]);
                    row["AKTIVAN"] = RuntimeHelpers.GetObjectValue(result["AKTIVAN"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.EVIDENCIJAController EVIDENCIJAController { get; set; }

        protected virtual UltraGrid grdLevelEVIDENCIJARADNICI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelEVIDENCIJARADNICI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelEVIDENCIJARADNICI = value;
            }
        }

        protected virtual UltraLabel label1BROJEVIDENCIJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BROJEVIDENCIJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BROJEVIDENCIJE = value;
            }
        }

        protected virtual UltraLabel label1IDGODINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDGODINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDGODINE = value;
            }
        }

        protected virtual UltraLabel label1MJESEC
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1MJESEC;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1MJESEC = value;
            }
        }

        protected virtual UltraLabel label1OPISEVIDENCIJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1OPISEVIDENCIJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1OPISEVIDENCIJE = value;
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

        protected virtual UltraNumericEditor textBROJEVIDENCIJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textBROJEVIDENCIJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textBROJEVIDENCIJE = value;
            }
        }

        protected virtual UltraNumericEditor textIDGODINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDGODINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDGODINE = value;
            }
        }

        protected virtual UltraNumericEditor textMJESEC
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textMJESEC;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textMJESEC = value;
            }
        }

        protected virtual UltraTextEditor textOPISEVIDENCIJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textOPISEVIDENCIJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textOPISEVIDENCIJE = value;
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

