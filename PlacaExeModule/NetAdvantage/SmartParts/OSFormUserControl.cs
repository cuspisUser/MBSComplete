namespace NetAdvantage.SmartParts
{
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Resources;
    using Deklarit.Win;
    using Deklarit.WinHelper;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinTabControl;
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
    public class OSFormUserControl : UserControl, IBusinessComponentUserControl
    {
        private BindingSource bindingSourceOS;
        private BindingSource bindingSourceOSTEMELJNICA;
        private IContainer components = null;
        private OSDataSet dsOSDataSet1;
        protected TableLayoutPanel layoutManagerformOS;
        protected TableLayoutPanel layoutManagerpanelactionsOSTEMELJNICA;
        protected TableLayoutPanel layoutManagerTabPage1;
        protected TableLayoutPanel layoutManagerTabPage2;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private OSDataSet.OSRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "OS";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.OSDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public OSFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsOSDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceOS.DataSource = this.OSController.DataSet;
            this.dsOSDataSet1 = this.OSController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/AMSKUPINE", Thread=ThreadOption.UserInterface)]
        public void comboIDAMSKUPINE_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDAMSKUPINE.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/OSVRSTA", Thread=ThreadOption.UserInterface)]
        public void comboIDOSVRSTA_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDOSVRSTA.Fill();
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
                    enumerator = this.dsOSDataSet1.OS.Rows.GetEnumerator();
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
                if (this.OSController.Update(this))
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
                    case "OSDOKUMENTIDOSDOKUMENTAddNew":
                        this.PictureBoxClickedInLinesIDOSDOKUMENT(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "LOKACIJERASHODLOKACIJEIDLOKACIJEAddNew":
                        this.PictureBoxClickedInLinesRASHODLOKACIJEIDLOKACIJE(RuntimeHelpers.GetObjectValue(sender), e);
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
            if (this.grdLevelOSTEMELJNICA.ActiveRow != null)
            {
                this.grdLevelOSTEMELJNICA.PerformAction(UltraGridAction.NextRow);
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
                if (e.Cell.Column.Key == "IDOSDOKUMENT")
                {
                    this.UpdateValuesIDOSDOKUMENT(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "RASHODLOKACIJEIDLOKACIJE")
                {
                    this.UpdateValuesRASHODLOKACIJEIDLOKACIJE(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
            }
        }

        private void grdLevelOSTEMELJNICA_AfterRowActivate(object sender, EventArgs e)
        {
            string oSOSTEMELJNICALevelDescription = StringResources.OSOSTEMELJNICALevelDescription;
            UltraGridRow activeRow = this.grdLevelOSTEMELJNICA.ActiveRow;
            this.linkLabelOSTEMELJNICAAdd.Text = Deklarit.Resources.Resources.Add + " " + oSOSTEMELJNICALevelDescription;
            this.linkLabelOSTEMELJNICAUpdate.Text = Deklarit.Resources.Resources.Update + " " + oSOSTEMELJNICALevelDescription;
            this.linkLabelOSTEMELJNICADelete.Text = Deklarit.Resources.Resources.Delete + " " + oSOSTEMELJNICALevelDescription;
        }

        private void grdLevelOSTEMELJNICA_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceOS.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceOS.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelOSTEMELJNICA_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.OSTEMELJNICAUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelOSTEMELJNICA_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceOS, this.OSController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "OS", this.m_Mode, this.dsOSDataSet1, this.dsOSDataSet1.OS.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourceOS, "DATUMNABAVKE", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerDATUMNABAVKE.DataBindings["Text"] != null)
            {
                this.datePickerDATUMNABAVKE.DataBindings.Remove(this.datePickerDATUMNABAVKE.DataBindings["Text"]);
            }
            this.datePickerDATUMNABAVKE.DataBindings.Add(binding);
            Binding binding2 = new Binding("Text", this.bindingSourceOS, "DATUMUPORABE", true);
            binding2.Format += new ConvertEventHandler(this.m_BaseMethods.DateFormat);
            binding2.Parse += new ConvertEventHandler(this.m_BaseMethods.DateParseNotNull);
            if (this.datePickerDATUMUPORABE.DataBindings["Text"] != null)
            {
                this.datePickerDATUMUPORABE.DataBindings.Remove(this.datePickerDATUMUPORABE.DataBindings["Text"]);
            }
            this.datePickerDATUMUPORABE.DataBindings.Add(binding2);
            if (!this.m_DataGrids.Contains(this.grdLevelOSTEMELJNICA))
            {
                this.m_DataGrids.Add(this.grdLevelOSTEMELJNICA);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsOSDataSet1.OS[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (OSDataSet.OSRow) ((DataRowView) this.bindingSourceOS.AddNew()).Row;
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
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(OSFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceOS = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOS).BeginInit();
            this.bindingSourceOSTEMELJNICA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceOSTEMELJNICA).BeginInit();
            this.layoutManagerformOS = new TableLayoutPanel();
            this.layoutManagerformOS.SuspendLayout();
            this.layoutManagerformOS.AutoSize = true;
            this.layoutManagerformOS.Dock = DockStyle.Fill;
            this.layoutManagerformOS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerformOS.AutoScroll = false;
            this.layoutManagerformOS.Location = new System.Drawing.Point(0, 0);
            this.layoutManagerformOS.Size = new System.Drawing.Size(0, 0);
            this.layoutManagerformOS.ColumnCount = 2;
            this.layoutManagerformOS.RowCount = 12;
            this.layoutManagerformOS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformOS.RowStyles.Add(new RowStyle());
            this.layoutManagerformOS.RowStyles.Add(new RowStyle());
            this.label1INVBROJ = new UltraLabel();
            this.textINVBROJ = new UltraNumericEditor();
            this.label1IDOSVRSTA = new UltraLabel();
            this.comboIDOSVRSTA = new OSVRSTAComboBox();
            this.label1NAZIVOS = new UltraLabel();
            this.textNAZIVOS = new UltraTextEditor();
            this.label1IDAMSKUPINE = new UltraLabel();
            this.comboIDAMSKUPINE = new AMSKUPINEComboBox();
            this.label1KTONABAVKEIDKONTO = new UltraLabel();
            this.labelKTONABAVKEIDKONTO = new UltraLabel();
            this.label1KTOISPRAVKAIDKONTO = new UltraLabel();
            this.labelKTOISPRAVKAIDKONTO = new UltraLabel();
            this.label1KTOIZVORAIDKONTO = new UltraLabel();
            this.labelKTOIZVORAIDKONTO = new UltraLabel();
            this.label1DATUMNABAVKE = new UltraLabel();
            this.datePickerDATUMNABAVKE = new UltraDateTimeEditor();
            this.label1DATUMUPORABE = new UltraLabel();
            this.datePickerDATUMUPORABE = new UltraDateTimeEditor();
            this.label1NAPOMENAOS = new UltraLabel();
            this.textNAPOMENAOS = new UltraTextEditor();
            this.IznosiNabave = new IznosiNabave();
            this.Tab1 = new UltraTabControl();
            UltraTab tab = new UltraTab();
            this.TabPage1 = new UltraTabPageControl();
            this.layoutManagerTabPage1 = new TableLayoutPanel();
            this.layoutManagerTabPage1.AutoSize = true;
            this.layoutManagerTabPage1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage1.ColumnCount = 1;
            this.layoutManagerTabPage1.RowCount = 2;
            this.layoutManagerTabPage1.Dock = DockStyle.Fill;
            this.layoutManagerTabPage1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage1.Margin = new Padding(5, 5, 5, 5);
            this.grdLevelOSTEMELJNICA = new UltraGrid();
            this.panelactionsOSTEMELJNICA = new Panel();
            this.layoutManagerpanelactionsOSTEMELJNICA = new TableLayoutPanel();
            this.layoutManagerpanelactionsOSTEMELJNICA.AutoSize = true;
            this.layoutManagerpanelactionsOSTEMELJNICA.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsOSTEMELJNICA.ColumnCount = 4;
            this.layoutManagerpanelactionsOSTEMELJNICA.RowCount = 1;
            this.layoutManagerpanelactionsOSTEMELJNICA.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsOSTEMELJNICA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsOSTEMELJNICA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsOSTEMELJNICA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsOSTEMELJNICA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsOSTEMELJNICA.RowStyles.Add(new RowStyle());
            this.linkLabelOSTEMELJNICAAdd = new UltraLabel();
            this.linkLabelOSTEMELJNICAUpdate = new UltraLabel();
            this.linkLabelOSTEMELJNICADelete = new UltraLabel();
            this.linkLabelOSTEMELJNICA = new UltraLabel();
            UltraTab tab2 = new UltraTab();
            this.TabPage2 = new UltraTabPageControl();
            this.layoutManagerTabPage2 = new TableLayoutPanel();
            this.layoutManagerTabPage2.AutoSize = true;
            this.layoutManagerTabPage2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage2.ColumnCount = 1;
            this.layoutManagerTabPage2.RowCount = 1;
            this.layoutManagerTabPage2.Dock = DockStyle.Fill;
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage2.Margin = new Padding(5, 5, 5, 5);
            this.UserDefinedControl1 = new RazmjestajSredstava();
            ((ISupportInitialize) this.textINVBROJ).BeginInit();
            ((ISupportInitialize) this.textNAZIVOS).BeginInit();
            ((ISupportInitialize) this.textNAPOMENAOS).BeginInit();
            this.Tab1.SuspendLayout();
            ((ISupportInitialize) this.Tab1).BeginInit();
            this.layoutManagerTabPage1.SuspendLayout();
            ((ISupportInitialize) this.grdLevelOSTEMELJNICA).BeginInit();
            this.panelactionsOSTEMELJNICA.SuspendLayout();
            this.layoutManagerpanelactionsOSTEMELJNICA.SuspendLayout();
            this.layoutManagerTabPage2.SuspendLayout();
            UltraGridBand band = new UltraGridBand("OSTEMELJNICA", -1);
            UltraGridColumn column3 = new UltraGridColumn("INVBROJ");
            UltraGridColumn column = new UltraGridColumn("IDOSDOKUMENT");
            UltraGridColumn column2 = new UltraGridColumn("columnIDOSDOKUMENTAddNew", 0);
            UltraGridColumn column5 = new UltraGridColumn("OSBROJDOKUMENTA");
            UltraGridColumn column6 = new UltraGridColumn("OSDATUMDOK");
            UltraGridColumn column8 = new UltraGridColumn("OSKOLICINA");
            UltraGridColumn column12 = new UltraGridColumn("OSSTOPA");
            UltraGridColumn column10 = new UltraGridColumn("OSOSNOVICA");
            UltraGridColumn column7 = new UltraGridColumn("OSDUGUJE");
            UltraGridColumn column11 = new UltraGridColumn("OSPOTRAZUJE");
            UltraGridColumn column13 = new UltraGridColumn("RASHODLOKACIJEIDLOKACIJE");
            UltraGridColumn column14 = new UltraGridColumn("columnRASHODLOKACIJEIDLOKACIJEAddNew", 1);
            UltraGridColumn column9 = new UltraGridColumn("OSOPIS");
            UltraGridColumn column4 = new UltraGridColumn("NAZIVOSDOKUMENT");
            this.dsOSDataSet1 = new OSDataSet();
            this.dsOSDataSet1.BeginInit();
            this.SuspendLayout();
            
            this.Tab1.Tabs.Add(tab);
            this.Tab1.Controls.Add(this.TabPage1);
            this.Tab1.Tabs.Add(tab2);
            this.Tab1.Controls.Add(this.TabPage2);
            
            this.dsOSDataSet1.DataSetName = "dsOS";
            this.dsOSDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceOS.DataSource = this.dsOSDataSet1;
            this.bindingSourceOS.DataMember = "OS";
            ((ISupportInitialize) this.bindingSourceOS).BeginInit();
            this.bindingSourceOSTEMELJNICA.DataSource = this.bindingSourceOS;
            this.bindingSourceOSTEMELJNICA.DataMember = "OS_OSTEMELJNICA";
            this.label1INVBROJ.Location = new System.Drawing.Point(0, 0);
            this.label1INVBROJ.Name = "label1INVBROJ";
            this.label1INVBROJ.TabIndex = 1;
            this.label1INVBROJ.Tag = "labelINVBROJ";
            this.label1INVBROJ.Text = "Inventarni broj:";
            this.label1INVBROJ.StyleSetName = "FieldUltraLabel";
            this.label1INVBROJ.AutoSize = true;
            this.label1INVBROJ.Anchor = AnchorStyles.Left;
            this.label1INVBROJ.Appearance.TextVAlign = VAlign.Middle;
            this.label1INVBROJ.Appearance.ImageHAlign = HAlign.Right;
            this.label1INVBROJ.ImageSize = new System.Drawing.Size(7, 10);
            this.label1INVBROJ.Appearance.ForeColor = Color.Black;
            this.label1INVBROJ.BackColor = Color.Transparent;
            this.layoutManagerformOS.Controls.Add(this.label1INVBROJ, 0, 0);
            this.layoutManagerformOS.SetColumnSpan(this.label1INVBROJ, 1);
            this.layoutManagerformOS.SetRowSpan(this.label1INVBROJ, 1);
            this.label1INVBROJ.Margin = new Padding(3, 1, 5, 2);
            this.label1INVBROJ.MinimumSize = new System.Drawing.Size(0, 0);
            this.label1INVBROJ.Size = new System.Drawing.Size(0x6f, 0x17);
            this.textINVBROJ.Location = new System.Drawing.Point(0, 0);
            this.textINVBROJ.Name = "textINVBROJ";
            this.textINVBROJ.Tag = "INVBROJ";
            this.textINVBROJ.TabIndex = 0;
            this.textINVBROJ.Anchor = AnchorStyles.Left;
            this.textINVBROJ.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textINVBROJ.ReadOnly = false;
            this.textINVBROJ.PromptChar = ' ';
            this.textINVBROJ.Enter += new EventHandler(this.numericEditor_Enter);
            this.textINVBROJ.DataBindings.Add(new Binding("Value", this.bindingSourceOS, "INVBROJ"));
            this.textINVBROJ.NumericType = NumericType.Double;
            this.textINVBROJ.MaskInput = "{LOC}-nnnnnnnnnnnn";
            this.layoutManagerformOS.Controls.Add(this.textINVBROJ, 1, 0);
            this.layoutManagerformOS.SetColumnSpan(this.textINVBROJ, 1);
            this.layoutManagerformOS.SetRowSpan(this.textINVBROJ, 1);
            this.textINVBROJ.Margin = new Padding(0, 1, 3, 2);
            this.textINVBROJ.MinimumSize = new System.Drawing.Size(0x63, 0x16);
            this.textINVBROJ.Size = new System.Drawing.Size(0x63, 0x16);
            this.label1IDOSVRSTA.Location = new System.Drawing.Point(0, 0);
            this.label1IDOSVRSTA.Name = "label1IDOSVRSTA";
            this.label1IDOSVRSTA.TabIndex = 1;
            this.label1IDOSVRSTA.Tag = "labelIDOSVRSTA";
            this.label1IDOSVRSTA.Text = "OS ili Sitan Inventar:";
            this.label1IDOSVRSTA.StyleSetName = "FieldUltraLabel";
            this.label1IDOSVRSTA.AutoSize = true;
            this.label1IDOSVRSTA.Anchor = AnchorStyles.Left;
            this.label1IDOSVRSTA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOSVRSTA.Appearance.ForeColor = Color.Black;
            this.label1IDOSVRSTA.BackColor = Color.Transparent;
            this.layoutManagerformOS.Controls.Add(this.label1IDOSVRSTA, 0, 1);
            this.layoutManagerformOS.SetColumnSpan(this.label1IDOSVRSTA, 1);
            this.layoutManagerformOS.SetRowSpan(this.label1IDOSVRSTA, 1);
            this.label1IDOSVRSTA.Margin = new Padding(3, 1, 5, 2);
            this.label1IDOSVRSTA.MinimumSize = new System.Drawing.Size(0, 0);
            this.label1IDOSVRSTA.Size = new System.Drawing.Size(0x91, 0x17);
            this.comboIDOSVRSTA.Location = new System.Drawing.Point(0, 0);
            this.comboIDOSVRSTA.Name = "comboIDOSVRSTA";
            this.comboIDOSVRSTA.Tag = "IDOSVRSTA";
            this.comboIDOSVRSTA.TabIndex = 0;
            this.comboIDOSVRSTA.Anchor = AnchorStyles.Left;
            this.comboIDOSVRSTA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDOSVRSTA.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDOSVRSTA.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDOSVRSTA.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDOSVRSTA.Enabled = true;
            this.comboIDOSVRSTA.DataBindings.Add(new Binding("Value", this.bindingSourceOS, "IDOSVRSTA"));
            this.comboIDOSVRSTA.ShowPictureBox = true;
            this.comboIDOSVRSTA.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDOSVRSTA);
            this.comboIDOSVRSTA.ValueMember = "IDOSVRSTA";
            this.comboIDOSVRSTA.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDOSVRSTA);
            this.layoutManagerformOS.Controls.Add(this.comboIDOSVRSTA, 1, 1);
            this.layoutManagerformOS.SetColumnSpan(this.comboIDOSVRSTA, 1);
            this.layoutManagerformOS.SetRowSpan(this.comboIDOSVRSTA, 1);
            this.comboIDOSVRSTA.Margin = new Padding(0, 1, 3, 2);
            this.comboIDOSVRSTA.MinimumSize = new System.Drawing.Size(0x12d, 0x17);
            this.comboIDOSVRSTA.Size = new System.Drawing.Size(0x12d, 0x17);
            this.label1NAZIVOS.Location = new System.Drawing.Point(0, 0);
            this.label1NAZIVOS.Name = "label1NAZIVOS";
            this.label1NAZIVOS.TabIndex = 1;
            this.label1NAZIVOS.Tag = "labelNAZIVOS";
            this.label1NAZIVOS.Text = "Naziv osnovnog sredstva:";
            this.label1NAZIVOS.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVOS.AutoSize = true;
            this.label1NAZIVOS.Anchor = AnchorStyles.Left;
            this.label1NAZIVOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVOS.Appearance.ForeColor = Color.Black;
            this.label1NAZIVOS.BackColor = Color.Transparent;
            this.layoutManagerformOS.Controls.Add(this.label1NAZIVOS, 0, 2);
            this.layoutManagerformOS.SetColumnSpan(this.label1NAZIVOS, 1);
            this.layoutManagerformOS.SetRowSpan(this.label1NAZIVOS, 1);
            this.label1NAZIVOS.Margin = new Padding(3, 1, 5, 2);
            this.label1NAZIVOS.MinimumSize = new System.Drawing.Size(0, 0);
            this.label1NAZIVOS.Size = new System.Drawing.Size(0xad, 0x17);
            this.textNAZIVOS.Location = new System.Drawing.Point(0, 0);
            this.textNAZIVOS.Name = "textNAZIVOS";
            this.textNAZIVOS.Tag = "NAZIVOS";
            this.textNAZIVOS.TabIndex = 0;
            this.textNAZIVOS.Anchor = AnchorStyles.Left;
            this.textNAZIVOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVOS.ReadOnly = false;
            this.textNAZIVOS.DataBindings.Add(new Binding("Text", this.bindingSourceOS, "NAZIVOS"));
            this.textNAZIVOS.MaxLength = 50;
            this.layoutManagerformOS.Controls.Add(this.textNAZIVOS, 1, 2);
            this.layoutManagerformOS.SetColumnSpan(this.textNAZIVOS, 1);
            this.layoutManagerformOS.SetRowSpan(this.textNAZIVOS, 1);
            this.textNAZIVOS.Margin = new Padding(0, 1, 3, 2);
            this.textNAZIVOS.MinimumSize = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVOS.Size = new System.Drawing.Size(0x16e, 0x16);
            this.label1IDAMSKUPINE.Location = new System.Drawing.Point(0, 0);
            this.label1IDAMSKUPINE.Name = "label1IDAMSKUPINE";
            this.label1IDAMSKUPINE.TabIndex = 1;
            this.label1IDAMSKUPINE.Tag = "labelIDAMSKUPINE";
            this.label1IDAMSKUPINE.Text = "Amortizacijska skupina:";
            this.label1IDAMSKUPINE.StyleSetName = "FieldUltraLabel";
            this.label1IDAMSKUPINE.AutoSize = true;
            this.label1IDAMSKUPINE.Anchor = AnchorStyles.Left;
            this.label1IDAMSKUPINE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDAMSKUPINE.Appearance.ForeColor = Color.Black;
            this.label1IDAMSKUPINE.BackColor = Color.Transparent;
            this.layoutManagerformOS.Controls.Add(this.label1IDAMSKUPINE, 0, 3);
            this.layoutManagerformOS.SetColumnSpan(this.label1IDAMSKUPINE, 1);
            this.layoutManagerformOS.SetRowSpan(this.label1IDAMSKUPINE, 1);
            this.label1IDAMSKUPINE.Margin = new Padding(3, 1, 5, 2);
            this.label1IDAMSKUPINE.MinimumSize = new System.Drawing.Size(0, 0);
            this.label1IDAMSKUPINE.Size = new System.Drawing.Size(0xa3, 0x17);
            this.comboIDAMSKUPINE.Location = new System.Drawing.Point(0, 0);
            this.comboIDAMSKUPINE.Name = "comboIDAMSKUPINE";
            this.comboIDAMSKUPINE.Tag = "IDAMSKUPINE";
            this.comboIDAMSKUPINE.TabIndex = 0;
            this.comboIDAMSKUPINE.Anchor = AnchorStyles.Left;
            this.comboIDAMSKUPINE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDAMSKUPINE.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDAMSKUPINE.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDAMSKUPINE.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDAMSKUPINE.Enabled = true;
            this.comboIDAMSKUPINE.DataBindings.Add(new Binding("Value", this.bindingSourceOS, "IDAMSKUPINE"));
            this.comboIDAMSKUPINE.ShowPictureBox = true;
            this.comboIDAMSKUPINE.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDAMSKUPINE);
            this.comboIDAMSKUPINE.ValueMember = "IDAMSKUPINE";
            this.comboIDAMSKUPINE.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDAMSKUPINE);
            this.layoutManagerformOS.Controls.Add(this.comboIDAMSKUPINE, 1, 3);
            this.layoutManagerformOS.SetColumnSpan(this.comboIDAMSKUPINE, 1);
            this.layoutManagerformOS.SetRowSpan(this.comboIDAMSKUPINE, 1);
            this.comboIDAMSKUPINE.Margin = new Padding(0, 1, 3, 2);
            this.comboIDAMSKUPINE.MinimumSize = new System.Drawing.Size(0x268, 0x17);
            this.comboIDAMSKUPINE.Size = new System.Drawing.Size(0x268, 0x17);
            this.label1KTONABAVKEIDKONTO.Location = new System.Drawing.Point(0, 0);
            this.label1KTONABAVKEIDKONTO.Name = "label1KTONABAVKEIDKONTO";
            this.label1KTONABAVKEIDKONTO.TabIndex = 1;
            this.label1KTONABAVKEIDKONTO.Tag = "labelKTONABAVKEIDKONTO";
            this.label1KTONABAVKEIDKONTO.Text = "Konto nabavne vr.:";
            this.label1KTONABAVKEIDKONTO.StyleSetName = "FieldUltraLabel";
            this.label1KTONABAVKEIDKONTO.AutoSize = true;
            this.label1KTONABAVKEIDKONTO.Anchor = AnchorStyles.Left;
            this.label1KTONABAVKEIDKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1KTONABAVKEIDKONTO.Appearance.ForeColor = Color.Black;
            this.label1KTONABAVKEIDKONTO.BackColor = Color.Transparent;
            this.layoutManagerformOS.Controls.Add(this.label1KTONABAVKEIDKONTO, 0, 4);
            this.layoutManagerformOS.SetColumnSpan(this.label1KTONABAVKEIDKONTO, 1);
            this.layoutManagerformOS.SetRowSpan(this.label1KTONABAVKEIDKONTO, 1);
            this.label1KTONABAVKEIDKONTO.Margin = new Padding(3, 1, 5, 2);
            this.label1KTONABAVKEIDKONTO.MinimumSize = new System.Drawing.Size(0, 0);
            this.label1KTONABAVKEIDKONTO.Size = new System.Drawing.Size(0x84, 0x17);
            this.labelKTONABAVKEIDKONTO.Location = new System.Drawing.Point(0, 0);
            this.labelKTONABAVKEIDKONTO.Name = "labelKTONABAVKEIDKONTO";
            this.labelKTONABAVKEIDKONTO.Tag = "KTONABAVKEIDKONTO";
            this.labelKTONABAVKEIDKONTO.TabIndex = 0;
            this.labelKTONABAVKEIDKONTO.Anchor = AnchorStyles.Left;
            this.labelKTONABAVKEIDKONTO.BackColor = Color.Transparent;
            this.labelKTONABAVKEIDKONTO.DataBindings.Add(new Binding("Text", this.bindingSourceOS, "KTONABAVKEIDKONTO"));
            this.labelKTONABAVKEIDKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOS.Controls.Add(this.labelKTONABAVKEIDKONTO, 1, 4);
            this.layoutManagerformOS.SetColumnSpan(this.labelKTONABAVKEIDKONTO, 1);
            this.layoutManagerformOS.SetRowSpan(this.labelKTONABAVKEIDKONTO, 1);
            this.labelKTONABAVKEIDKONTO.Margin = new Padding(0, 1, 3, 2);
            this.labelKTONABAVKEIDKONTO.MinimumSize = new System.Drawing.Size(0x72, 0x16);
            this.labelKTONABAVKEIDKONTO.Size = new System.Drawing.Size(0x72, 0x16);
            this.label1KTOISPRAVKAIDKONTO.Location = new System.Drawing.Point(0, 0);
            this.label1KTOISPRAVKAIDKONTO.Name = "label1KTOISPRAVKAIDKONTO";
            this.label1KTOISPRAVKAIDKONTO.TabIndex = 1;
            this.label1KTOISPRAVKAIDKONTO.Tag = "labelKTOISPRAVKAIDKONTO";
            this.label1KTOISPRAVKAIDKONTO.Text = "Konto ispravka vr.:";
            this.label1KTOISPRAVKAIDKONTO.StyleSetName = "FieldUltraLabel";
            this.label1KTOISPRAVKAIDKONTO.AutoSize = true;
            this.label1KTOISPRAVKAIDKONTO.Anchor = AnchorStyles.Left;
            this.label1KTOISPRAVKAIDKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1KTOISPRAVKAIDKONTO.Appearance.ForeColor = Color.Black;
            this.label1KTOISPRAVKAIDKONTO.BackColor = Color.Transparent;
            this.layoutManagerformOS.Controls.Add(this.label1KTOISPRAVKAIDKONTO, 0, 5);
            this.layoutManagerformOS.SetColumnSpan(this.label1KTOISPRAVKAIDKONTO, 1);
            this.layoutManagerformOS.SetRowSpan(this.label1KTOISPRAVKAIDKONTO, 1);
            this.label1KTOISPRAVKAIDKONTO.Margin = new Padding(3, 1, 5, 2);
            this.label1KTOISPRAVKAIDKONTO.MinimumSize = new System.Drawing.Size(0, 0);
            this.label1KTOISPRAVKAIDKONTO.Size = new System.Drawing.Size(0x84, 0x17);
            this.labelKTOISPRAVKAIDKONTO.Location = new System.Drawing.Point(0, 0);
            this.labelKTOISPRAVKAIDKONTO.Name = "labelKTOISPRAVKAIDKONTO";
            this.labelKTOISPRAVKAIDKONTO.Tag = "KTOISPRAVKAIDKONTO";
            this.labelKTOISPRAVKAIDKONTO.TabIndex = 0;
            this.labelKTOISPRAVKAIDKONTO.Anchor = AnchorStyles.Left;
            this.labelKTOISPRAVKAIDKONTO.BackColor = Color.Transparent;
            this.labelKTOISPRAVKAIDKONTO.DataBindings.Add(new Binding("Text", this.bindingSourceOS, "KTOISPRAVKAIDKONTO"));
            this.labelKTOISPRAVKAIDKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOS.Controls.Add(this.labelKTOISPRAVKAIDKONTO, 1, 5);
            this.layoutManagerformOS.SetColumnSpan(this.labelKTOISPRAVKAIDKONTO, 1);
            this.layoutManagerformOS.SetRowSpan(this.labelKTOISPRAVKAIDKONTO, 1);
            this.labelKTOISPRAVKAIDKONTO.Margin = new Padding(0, 1, 3, 2);
            this.labelKTOISPRAVKAIDKONTO.MinimumSize = new System.Drawing.Size(0x72, 0x16);
            this.labelKTOISPRAVKAIDKONTO.Size = new System.Drawing.Size(0x72, 0x16);
            this.label1KTOIZVORAIDKONTO.Location = new System.Drawing.Point(0, 0);
            this.label1KTOIZVORAIDKONTO.Name = "label1KTOIZVORAIDKONTO";
            this.label1KTOIZVORAIDKONTO.TabIndex = 1;
            this.label1KTOIZVORAIDKONTO.Tag = "labelKTOIZVORAIDKONTO";
            this.label1KTOIZVORAIDKONTO.Text = "Konto izvora vlasništva:";
            this.label1KTOIZVORAIDKONTO.StyleSetName = "FieldUltraLabel";
            this.label1KTOIZVORAIDKONTO.AutoSize = true;
            this.label1KTOIZVORAIDKONTO.Anchor = AnchorStyles.Left;
            this.label1KTOIZVORAIDKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1KTOIZVORAIDKONTO.Appearance.ForeColor = Color.Black;
            this.label1KTOIZVORAIDKONTO.BackColor = Color.Transparent;
            this.layoutManagerformOS.Controls.Add(this.label1KTOIZVORAIDKONTO, 0, 6);
            this.layoutManagerformOS.SetColumnSpan(this.label1KTOIZVORAIDKONTO, 1);
            this.layoutManagerformOS.SetRowSpan(this.label1KTOIZVORAIDKONTO, 1);
            this.label1KTOIZVORAIDKONTO.Margin = new Padding(3, 1, 5, 2);
            this.label1KTOIZVORAIDKONTO.MinimumSize = new System.Drawing.Size(0, 0);
            this.label1KTOIZVORAIDKONTO.Size = new System.Drawing.Size(0xa3, 0x17);
            this.labelKTOIZVORAIDKONTO.Location = new System.Drawing.Point(0, 0);
            this.labelKTOIZVORAIDKONTO.Name = "labelKTOIZVORAIDKONTO";
            this.labelKTOIZVORAIDKONTO.Tag = "KTOIZVORAIDKONTO";
            this.labelKTOIZVORAIDKONTO.TabIndex = 0;
            this.labelKTOIZVORAIDKONTO.Anchor = AnchorStyles.Left;
            this.labelKTOIZVORAIDKONTO.BackColor = Color.Transparent;
            this.labelKTOIZVORAIDKONTO.DataBindings.Add(new Binding("Text", this.bindingSourceOS, "KTOIZVORAIDKONTO"));
            this.labelKTOIZVORAIDKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformOS.Controls.Add(this.labelKTOIZVORAIDKONTO, 1, 6);
            this.layoutManagerformOS.SetColumnSpan(this.labelKTOIZVORAIDKONTO, 1);
            this.layoutManagerformOS.SetRowSpan(this.labelKTOIZVORAIDKONTO, 1);
            this.labelKTOIZVORAIDKONTO.Margin = new Padding(0, 1, 3, 2);
            this.labelKTOIZVORAIDKONTO.MinimumSize = new System.Drawing.Size(0x72, 0x16);
            this.labelKTOIZVORAIDKONTO.Size = new System.Drawing.Size(0x72, 0x16);
            this.label1DATUMNABAVKE.Location = new System.Drawing.Point(0, 0);
            this.label1DATUMNABAVKE.Name = "label1DATUMNABAVKE";
            this.label1DATUMNABAVKE.TabIndex = 1;
            this.label1DATUMNABAVKE.Tag = "labelDATUMNABAVKE";
            this.label1DATUMNABAVKE.Text = "Datum nabavke:";
            this.label1DATUMNABAVKE.StyleSetName = "FieldUltraLabel";
            this.label1DATUMNABAVKE.AutoSize = true;
            this.label1DATUMNABAVKE.Anchor = AnchorStyles.Left;
            this.label1DATUMNABAVKE.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMNABAVKE.Appearance.ForeColor = Color.Black;
            this.label1DATUMNABAVKE.BackColor = Color.Transparent;
            this.layoutManagerformOS.Controls.Add(this.label1DATUMNABAVKE, 0, 7);
            this.layoutManagerformOS.SetColumnSpan(this.label1DATUMNABAVKE, 1);
            this.layoutManagerformOS.SetRowSpan(this.label1DATUMNABAVKE, 1);
            this.label1DATUMNABAVKE.Margin = new Padding(3, 1, 5, 2);
            this.label1DATUMNABAVKE.MinimumSize = new System.Drawing.Size(0, 0);
            this.label1DATUMNABAVKE.Size = new System.Drawing.Size(0x75, 0x17);
            this.datePickerDATUMNABAVKE.Location = new System.Drawing.Point(0, 0);
            this.datePickerDATUMNABAVKE.Name = "datePickerDATUMNABAVKE";
            this.datePickerDATUMNABAVKE.Tag = "DATUMNABAVKE";
            this.datePickerDATUMNABAVKE.TabIndex = 0;
            this.datePickerDATUMNABAVKE.Anchor = AnchorStyles.Left;
            this.datePickerDATUMNABAVKE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMNABAVKE.Enabled = true;
            this.layoutManagerformOS.Controls.Add(this.datePickerDATUMNABAVKE, 1, 7);
            this.layoutManagerformOS.SetColumnSpan(this.datePickerDATUMNABAVKE, 1);
            this.layoutManagerformOS.SetRowSpan(this.datePickerDATUMNABAVKE, 1);
            this.datePickerDATUMNABAVKE.Margin = new Padding(0, 1, 3, 2);
            this.datePickerDATUMNABAVKE.MinimumSize = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMNABAVKE.Size = new System.Drawing.Size(100, 0x16);
            this.label1DATUMUPORABE.Location = new System.Drawing.Point(0, 0);
            this.label1DATUMUPORABE.Name = "label1DATUMUPORABE";
            this.label1DATUMUPORABE.TabIndex = 1;
            this.label1DATUMUPORABE.Tag = "labelDATUMUPORABE";
            this.label1DATUMUPORABE.Text = "Datum uporabe:";
            this.label1DATUMUPORABE.StyleSetName = "FieldUltraLabel";
            this.label1DATUMUPORABE.AutoSize = true;
            this.label1DATUMUPORABE.Anchor = AnchorStyles.Left;
            this.label1DATUMUPORABE.Appearance.TextVAlign = VAlign.Middle;
            this.label1DATUMUPORABE.Appearance.ForeColor = Color.Black;
            this.label1DATUMUPORABE.BackColor = Color.Transparent;
            this.layoutManagerformOS.Controls.Add(this.label1DATUMUPORABE, 0, 8);
            this.layoutManagerformOS.SetColumnSpan(this.label1DATUMUPORABE, 1);
            this.layoutManagerformOS.SetRowSpan(this.label1DATUMUPORABE, 1);
            this.label1DATUMUPORABE.Margin = new Padding(3, 1, 5, 2);
            this.label1DATUMUPORABE.MinimumSize = new System.Drawing.Size(0, 0);
            this.label1DATUMUPORABE.Size = new System.Drawing.Size(0x73, 0x17);
            this.datePickerDATUMUPORABE.Location = new System.Drawing.Point(0, 0);
            this.datePickerDATUMUPORABE.Name = "datePickerDATUMUPORABE";
            this.datePickerDATUMUPORABE.Tag = "DATUMUPORABE";
            this.datePickerDATUMUPORABE.TabIndex = 0;
            this.datePickerDATUMUPORABE.Anchor = AnchorStyles.Left;
            this.datePickerDATUMUPORABE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.datePickerDATUMUPORABE.Enabled = true;
            this.layoutManagerformOS.Controls.Add(this.datePickerDATUMUPORABE, 1, 8);
            this.layoutManagerformOS.SetColumnSpan(this.datePickerDATUMUPORABE, 1);
            this.layoutManagerformOS.SetRowSpan(this.datePickerDATUMUPORABE, 1);
            this.datePickerDATUMUPORABE.Margin = new Padding(0, 1, 3, 2);
            this.datePickerDATUMUPORABE.MinimumSize = new System.Drawing.Size(100, 0x16);
            this.datePickerDATUMUPORABE.Size = new System.Drawing.Size(100, 0x16);
            this.label1NAPOMENAOS.Location = new System.Drawing.Point(0, 0);
            this.label1NAPOMENAOS.Name = "label1NAPOMENAOS";
            this.label1NAPOMENAOS.TabIndex = 1;
            this.label1NAPOMENAOS.Tag = "labelNAPOMENAOS";
            this.label1NAPOMENAOS.Text = "Napomena o sredstvu:";
            this.label1NAPOMENAOS.StyleSetName = "FieldUltraLabel";
            this.label1NAPOMENAOS.AutoSize = true;
            this.label1NAPOMENAOS.Anchor = AnchorStyles.Left;
            this.label1NAPOMENAOS.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAPOMENAOS.Appearance.ForeColor = Color.Black;
            this.label1NAPOMENAOS.BackColor = Color.Transparent;
            this.layoutManagerformOS.Controls.Add(this.label1NAPOMENAOS, 0, 9);
            this.layoutManagerformOS.SetColumnSpan(this.label1NAPOMENAOS, 1);
            this.layoutManagerformOS.SetRowSpan(this.label1NAPOMENAOS, 1);
            this.label1NAPOMENAOS.Margin = new Padding(3, 1, 5, 2);
            this.label1NAPOMENAOS.MinimumSize = new System.Drawing.Size(0, 0);
            this.label1NAPOMENAOS.Size = new System.Drawing.Size(0x9a, 0x17);
            this.textNAPOMENAOS.Location = new System.Drawing.Point(0, 0);
            this.textNAPOMENAOS.Name = "textNAPOMENAOS";
            this.textNAPOMENAOS.Tag = "NAPOMENAOS";
            this.textNAPOMENAOS.TabIndex = 0;
            this.textNAPOMENAOS.Anchor = AnchorStyles.Left;
            this.textNAPOMENAOS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAPOMENAOS.ContextMenu = this.contextMenu1;
            this.textNAPOMENAOS.ReadOnly = false;
            this.textNAPOMENAOS.DataBindings.Add(new Binding("Text", this.bindingSourceOS, "NAPOMENAOS"));
            this.textNAPOMENAOS.Nullable = true;
            this.textNAPOMENAOS.MaxLength = 50;
            this.layoutManagerformOS.Controls.Add(this.textNAPOMENAOS, 1, 9);
            this.layoutManagerformOS.SetColumnSpan(this.textNAPOMENAOS, 1);
            this.layoutManagerformOS.SetRowSpan(this.textNAPOMENAOS, 1);
            this.textNAPOMENAOS.Margin = new Padding(0, 1, 3, 2);
            this.textNAPOMENAOS.MinimumSize = new System.Drawing.Size(0x16e, 0x16);
            this.textNAPOMENAOS.Size = new System.Drawing.Size(0x16e, 0x16);
            this.IznosiNabave.Location = new System.Drawing.Point(0, 0);
            this.IznosiNabave.Name = "IznosiNabave";
            this.layoutManagerformOS.Controls.Add(this.IznosiNabave, 0, 10);
            this.layoutManagerformOS.SetColumnSpan(this.IznosiNabave, 2);
            this.layoutManagerformOS.SetRowSpan(this.IznosiNabave, 1);
            this.IznosiNabave.Margin = new Padding(2, 2, 2, 2);
            this.IznosiNabave.MinimumSize = new System.Drawing.Size(4, 4);
            this.Tab1.Location = new System.Drawing.Point(0, 0);
            this.Tab1.Name = "Tab1";
            this.layoutManagerformOS.Controls.Add(this.Tab1, 0, 11);
            this.layoutManagerformOS.SetColumnSpan(this.Tab1, 2);
            this.layoutManagerformOS.SetRowSpan(this.Tab1, 1);
            this.Tab1.Margin = new Padding(5, 11, 5, 5);
            this.Tab1.MinimumSize = new System.Drawing.Size(0, 0);
            this.Tab1.Dock = DockStyle.Fill;
            this.TabPage1.Location = new System.Drawing.Point(0, 0);
            this.TabPage1.Name = "TabPage1";
            tab.TabPage = this.TabPage1;
            tab.Text = "Promjene na sredstvu";
            this.TabPage1.Controls.Add(this.layoutManagerTabPage1);
            this.grdLevelOSTEMELJNICA.Location = new System.Drawing.Point(0, 0);
            this.grdLevelOSTEMELJNICA.Name = "grdLevelOSTEMELJNICA";
            this.layoutManagerTabPage1.Controls.Add(this.grdLevelOSTEMELJNICA, 0, 0);
            this.layoutManagerTabPage1.SetColumnSpan(this.grdLevelOSTEMELJNICA, 2);
            this.layoutManagerTabPage1.SetRowSpan(this.grdLevelOSTEMELJNICA, 1);
            this.grdLevelOSTEMELJNICA.Margin = new Padding(5, 10, 5, 10);
            this.grdLevelOSTEMELJNICA.MinimumSize = new System.Drawing.Size(100, 100);
            this.grdLevelOSTEMELJNICA.Size = new System.Drawing.Size(0x286, 200);
            this.grdLevelOSTEMELJNICA.Dock = DockStyle.Fill;
            this.panelactionsOSTEMELJNICA.Location = new System.Drawing.Point(0, 0);
            this.panelactionsOSTEMELJNICA.Name = "panelactionsOSTEMELJNICA";
            this.panelactionsOSTEMELJNICA.BackColor = Color.Transparent;
            this.panelactionsOSTEMELJNICA.Controls.Add(this.layoutManagerpanelactionsOSTEMELJNICA);
            this.layoutManagerTabPage1.Controls.Add(this.panelactionsOSTEMELJNICA, 0, 1);
            this.layoutManagerTabPage1.SetColumnSpan(this.panelactionsOSTEMELJNICA, 2);
            this.layoutManagerTabPage1.SetRowSpan(this.panelactionsOSTEMELJNICA, 1);
            this.panelactionsOSTEMELJNICA.Margin = new Padding(0, 0, 0, 0);
            this.panelactionsOSTEMELJNICA.MinimumSize = new System.Drawing.Size(0x17d, 0x19);
            this.panelactionsOSTEMELJNICA.Size = new System.Drawing.Size(0x17d, 0x19);
            this.panelactionsOSTEMELJNICA.Dock = DockStyle.Fill;
            this.linkLabelOSTEMELJNICAAdd.Location = new System.Drawing.Point(0, 0);
            this.linkLabelOSTEMELJNICAAdd.Name = "linkLabelOSTEMELJNICAAdd";
            this.linkLabelOSTEMELJNICAAdd.Size = new System.Drawing.Size(0x67, 15);
            this.linkLabelOSTEMELJNICAAdd.Text = " Add TEMELJNICA  ";
            this.linkLabelOSTEMELJNICAAdd.Click += new EventHandler(this.OSTEMELJNICAAdd_Click);
            this.linkLabelOSTEMELJNICAAdd.BackColor = Color.Transparent;
            this.linkLabelOSTEMELJNICAAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelOSTEMELJNICAAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelOSTEMELJNICAAdd.Cursor = Cursors.Hand;
            this.linkLabelOSTEMELJNICAAdd.AutoSize = true;
            this.layoutManagerpanelactionsOSTEMELJNICA.Controls.Add(this.linkLabelOSTEMELJNICAAdd, 0, 0);
            this.layoutManagerpanelactionsOSTEMELJNICA.SetColumnSpan(this.linkLabelOSTEMELJNICAAdd, 1);
            this.layoutManagerpanelactionsOSTEMELJNICA.SetRowSpan(this.linkLabelOSTEMELJNICAAdd, 1);
            this.linkLabelOSTEMELJNICAAdd.Margin = new Padding(5, 5, 5, 5);
            this.linkLabelOSTEMELJNICAAdd.MinimumSize = new System.Drawing.Size(0x67, 15);
            this.linkLabelOSTEMELJNICAAdd.Size = new System.Drawing.Size(0x67, 15);
            this.linkLabelOSTEMELJNICAUpdate.Location = new System.Drawing.Point(0, 0);
            this.linkLabelOSTEMELJNICAUpdate.Name = "linkLabelOSTEMELJNICAUpdate";
            this.linkLabelOSTEMELJNICAUpdate.Size = new System.Drawing.Size(0x79, 15);
            this.linkLabelOSTEMELJNICAUpdate.Text = " Update TEMELJNICA  ";
            this.linkLabelOSTEMELJNICAUpdate.Click += new EventHandler(this.OSTEMELJNICAUpdate_Click);
            this.linkLabelOSTEMELJNICAUpdate.BackColor = Color.Transparent;
            this.linkLabelOSTEMELJNICAUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelOSTEMELJNICAUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelOSTEMELJNICAUpdate.Cursor = Cursors.Hand;
            this.linkLabelOSTEMELJNICAUpdate.AutoSize = true;
            this.layoutManagerpanelactionsOSTEMELJNICA.Controls.Add(this.linkLabelOSTEMELJNICAUpdate, 1, 0);
            this.layoutManagerpanelactionsOSTEMELJNICA.SetColumnSpan(this.linkLabelOSTEMELJNICAUpdate, 1);
            this.layoutManagerpanelactionsOSTEMELJNICA.SetRowSpan(this.linkLabelOSTEMELJNICAUpdate, 1);
            this.linkLabelOSTEMELJNICAUpdate.Margin = new Padding(5, 5, 5, 5);
            this.linkLabelOSTEMELJNICAUpdate.MinimumSize = new System.Drawing.Size(0x79, 15);
            this.linkLabelOSTEMELJNICAUpdate.Size = new System.Drawing.Size(0x79, 15);
            this.linkLabelOSTEMELJNICADelete.Location = new System.Drawing.Point(0, 0);
            this.linkLabelOSTEMELJNICADelete.Name = "linkLabelOSTEMELJNICADelete";
            this.linkLabelOSTEMELJNICADelete.Size = new System.Drawing.Size(0x75, 15);
            this.linkLabelOSTEMELJNICADelete.Text = " Delete TEMELJNICA  ";
            this.linkLabelOSTEMELJNICADelete.Click += new EventHandler(this.OSTEMELJNICADelete_Click);
            this.linkLabelOSTEMELJNICADelete.BackColor = Color.Transparent;
            this.linkLabelOSTEMELJNICADelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelOSTEMELJNICADelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelOSTEMELJNICADelete.Cursor = Cursors.Hand;
            this.linkLabelOSTEMELJNICADelete.AutoSize = true;
            this.layoutManagerpanelactionsOSTEMELJNICA.Controls.Add(this.linkLabelOSTEMELJNICADelete, 2, 0);
            this.layoutManagerpanelactionsOSTEMELJNICA.SetColumnSpan(this.linkLabelOSTEMELJNICADelete, 1);
            this.layoutManagerpanelactionsOSTEMELJNICA.SetRowSpan(this.linkLabelOSTEMELJNICADelete, 1);
            this.linkLabelOSTEMELJNICADelete.Margin = new Padding(5, 5, 5, 5);
            this.linkLabelOSTEMELJNICADelete.MinimumSize = new System.Drawing.Size(0x75, 15);
            this.linkLabelOSTEMELJNICADelete.Size = new System.Drawing.Size(0x75, 15);
            this.linkLabelOSTEMELJNICA.Location = new System.Drawing.Point(0, 0);
            this.linkLabelOSTEMELJNICA.Name = "linkLabelOSTEMELJNICA";
            this.layoutManagerpanelactionsOSTEMELJNICA.Controls.Add(this.linkLabelOSTEMELJNICA, 3, 0);
            this.layoutManagerpanelactionsOSTEMELJNICA.SetColumnSpan(this.linkLabelOSTEMELJNICA, 1);
            this.layoutManagerpanelactionsOSTEMELJNICA.SetRowSpan(this.linkLabelOSTEMELJNICA, 1);
            this.linkLabelOSTEMELJNICA.Margin = new Padding(5, 5, 5, 5);
            this.linkLabelOSTEMELJNICA.MinimumSize = new System.Drawing.Size(0, 15);
            this.linkLabelOSTEMELJNICA.Size = new System.Drawing.Size(0, 15);
            this.linkLabelOSTEMELJNICA.Dock = DockStyle.Fill;
            this.TabPage2.Location = new System.Drawing.Point(0, 0);
            this.TabPage2.Name = "TabPage2";
            tab2.TabPage = this.TabPage2;
            tab2.Text = "Razmještaj sredstva";
            this.TabPage2.Controls.Add(this.layoutManagerTabPage2);
            this.UserDefinedControl1.Location = new System.Drawing.Point(0, 0);
            this.UserDefinedControl1.Name = "UserDefinedControl1";
            this.layoutManagerTabPage2.Controls.Add(this.UserDefinedControl1, 0, 0);
            this.layoutManagerTabPage2.SetColumnSpan(this.UserDefinedControl1, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.UserDefinedControl1, 1);
            this.UserDefinedControl1.Margin = new Padding(2, 2, 2, 2);
            this.UserDefinedControl1.MinimumSize = new System.Drawing.Size(4, 4);
            this.Controls.Add(this.layoutManagerformOS);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceOS;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.Disabled;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.OSINVBROJDescription;
            column3.Width = 0x77;
            appearance2.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance2;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.OSIDOSDOKUMENTDescription;
            column.Width = 0x48;
            column.Format = "";
            column.CellAppearance = appearance;
            column2.AllowGroupBy = DefaultableBoolean.False;
            column2.AutoSizeEdit = DefaultableBoolean.False;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column2.CellAppearance.BorderAlpha = Alpha.Transparent;
            column2.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column2.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column2.Header.Enabled = false;
            column2.Header.Fixed = true;
            column2.Header.Caption = "";
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column2.Width = 20;
            column2.MinWidth = 20;
            column2.MaxWidth = 20;
            column2.Tag = "OSDOKUMENTIDOSDOKUMENTAddNew";
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.OSOSBROJDOKUMENTADescription;
            column5.Width = 0x33;
            appearance4.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.OSOSDATUMDOKDescription;
            column6.Width = 100;
            column6.MinValue = DateTime.MinValue;
            column6.MaxValue = DateTime.MaxValue;
            column6.Format = "d";
            column6.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.OSOSKOLICINADescription;
            column8.Width = 0x66;
            appearance7.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.OSOSSTOPADescription;
            column12.Width = 0x37;
            appearance11.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance11;
            column12.Hidden = true;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.OSOSOSNOVICADescription;
            column10.Width = 0x66;
            appearance9.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance9;
            column10.Hidden = true;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.OSOSDUGUJEDescription;
            column7.Width = 0x66;
            appearance6.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.OSOSPOTRAZUJEDescription;
            column11.Width = 0x66;
            appearance10.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.OSRASHODLOKACIJEIDLOKACIJEDescription;
            column13.Width = 0x48;
            column13.Format = "";
            column13.CellAppearance = appearance12;
            column14.AllowGroupBy = DefaultableBoolean.False;
            column14.AutoSizeEdit = DefaultableBoolean.False;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column14.CellAppearance.BorderAlpha = Alpha.Transparent;
            column14.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column14.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column14.Header.Enabled = false;
            column14.Header.Fixed = true;
            column14.Header.Caption = "";
            column14.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column14.Width = 20;
            column14.MinWidth = 20;
            column14.MaxWidth = 20;
            column14.Tag = "LOKACIJERASHODLOKACIJEIDLOKACIJEAddNew";
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.OSOSOPISDescription;
            column9.Width = 0x128;
            column9.Format = "";
            column9.CellAppearance = appearance8;
            column9.Hidden = true;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.Disabled;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.OSNAZIVOSDOKUMENTDescription;
            column4.Width = 0xe2;
            column4.Format = "";
            column4.CellAppearance = appearance3;
            column4.Hidden = true;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 1;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 2;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 3;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 4;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 5;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 6;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 7;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 8;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 9;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 10;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 11;
            this.grdLevelOSTEMELJNICA.Visible = true;
            this.grdLevelOSTEMELJNICA.Name = "grdLevelOSTEMELJNICA";
            this.grdLevelOSTEMELJNICA.Tag = "OSTEMELJNICA";
            this.grdLevelOSTEMELJNICA.TabIndex = 0x1f;
            this.grdLevelOSTEMELJNICA.Dock = DockStyle.Fill;
            this.grdLevelOSTEMELJNICA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelOSTEMELJNICA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelOSTEMELJNICA.DataSource = this.bindingSourceOSTEMELJNICA;
            this.grdLevelOSTEMELJNICA.Enter += new EventHandler(this.grdLevelOSTEMELJNICA_Enter);
            this.grdLevelOSTEMELJNICA.AfterRowInsert += new RowEventHandler(this.grdLevelOSTEMELJNICA_AfterRowInsert);
            this.grdLevelOSTEMELJNICA.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelOSTEMELJNICA.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelOSTEMELJNICA.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelOSTEMELJNICA.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelOSTEMELJNICA_DoubleClick);
            this.grdLevelOSTEMELJNICA.AfterRowActivate += new EventHandler(this.grdLevelOSTEMELJNICA_AfterRowActivate);
            this.grdLevelOSTEMELJNICA.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelOSTEMELJNICA.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelOSTEMELJNICA.DisplayLayout.BandsSerializer.Add(band);
            this.Name = "OSFormUserControl";
            this.Text = "OS";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.OSFormUserControl_Load);
            this.layoutManagerformOS.ResumeLayout(false);
            this.layoutManagerformOS.PerformLayout();
            ((ISupportInitialize) this.bindingSourceOS).EndInit();
            ((ISupportInitialize) this.bindingSourceOSTEMELJNICA).EndInit();
            ((ISupportInitialize) this.textINVBROJ).EndInit();
            ((ISupportInitialize) this.textNAZIVOS).EndInit();
            ((ISupportInitialize) this.textNAPOMENAOS).EndInit();
            ((ISupportInitialize) this.grdLevelOSTEMELJNICA).EndInit();
            this.panelactionsOSTEMELJNICA.ResumeLayout(true);
            this.panelactionsOSTEMELJNICA.PerformLayout();
            this.layoutManagerpanelactionsOSTEMELJNICA.ResumeLayout(false);
            this.layoutManagerpanelactionsOSTEMELJNICA.PerformLayout();
            this.layoutManagerTabPage1.ResumeLayout(false);
            this.layoutManagerTabPage1.PerformLayout();
            this.layoutManagerTabPage2.ResumeLayout(false);
            this.layoutManagerTabPage2.PerformLayout();
            this.Tab1.ResumeLayout(true);
            this.Tab1.PerformLayout();
            ((ISupportInitialize) this.Tab1).EndInit();
            this.dsOSDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.OSController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceOS, this.OSController.WorkItem, this))
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
            this.label1INVBROJ.Text = StringResources.OSINVBROJDescription;
            this.label1IDOSVRSTA.Text = StringResources.OSIDOSVRSTADescription;
            this.label1NAZIVOS.Text = StringResources.OSNAZIVOSDescription;
            this.label1IDAMSKUPINE.Text = StringResources.OSIDAMSKUPINEDescription;
            this.label1KTONABAVKEIDKONTO.Text = StringResources.OSKTONABAVKEIDKONTODescription;
            this.label1KTOISPRAVKAIDKONTO.Text = StringResources.OSKTOISPRAVKAIDKONTODescription;
            this.label1KTOIZVORAIDKONTO.Text = StringResources.OSKTOIZVORAIDKONTODescription;
            this.label1DATUMNABAVKE.Text = StringResources.OSDATUMNABAVKEDescription;
            this.label1DATUMUPORABE.Text = StringResources.OSDATUMUPORABEDescription;
            this.label1NAPOMENAOS.Text = StringResources.OSNAPOMENAOSDescription;
            this.TabPage1.Tab.Text = StringResources.OSOSTabPage1TabDescription;
            this.TabPage2.Tab.Text = StringResources.OSOSTabPage2TabDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewOSRAZMJESTAJ")]
        public void NewOSRAZMJESTAJHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OSController.NewOSRAZMJESTAJ(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void OSFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.OSDescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelOSTEMELJNICAAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.OSOSTEMELJNICALevelDescription;
            this.linkLabelOSTEMELJNICAUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.OSOSTEMELJNICALevelDescription;
            this.linkLabelOSTEMELJNICADelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.OSOSTEMELJNICALevelDescription;
        }

        private void OSTEMELJNICAAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelOSTEMELJNICA.ActiveRow;
            this.OSTEMELJNICAInsert();
        }

        private void OSTEMELJNICADelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelOSTEMELJNICA);
            if ((currentRowListIndex != -1) && (this.grdLevelOSTEMELJNICA.Selected.Rows.Count > 0))
            {
                this.grdLevelOSTEMELJNICA.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelOSTEMELJNICA).Selected = true;
                this.grdLevelOSTEMELJNICA.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/OSDOKUMENT", Thread=ThreadOption.UserInterface)]
        public void OSTEMELJNICAIDOSDOKUMENT_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new OSDOKUMENTDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetOSDOKUMENTDataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["OSDOKUMENT"]) {
                Sort = "OSDK"
            };
            CreateValueList(this.grdLevelOSTEMELJNICA, "OSDOKUMENTIDOSDOKUMENT", enumList, "IDOSDOKUMENT", "OSDK", true);
        }

        private void OSTEMELJNICAInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceOS, this.OSController.WorkItem, this))
            {
                this.OSController.AddOSTEMELJNICA(this.m_CurrentRow);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/LOKACIJE", Thread=ThreadOption.UserInterface)]
        public void OSTEMELJNICARASHODLOKACIJEIDLOKACIJE_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new LOKACIJEDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetLOKACIJEDataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["LOKACIJE"]) {
                Sort = "LOK"
            };
            CreateValueList(this.grdLevelOSTEMELJNICA, "LOKACIJERASHODLOKACIJEIDLOKACIJE", enumList, "IDLOKACIJE", "LOK", true);
        }

        private void OSTEMELJNICAUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelOSTEMELJNICA) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelOSTEMELJNICA);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.OSController.UpdateOSTEMELJNICA(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void OSTEMELJNICAUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelOSTEMELJNICA.ActiveRow != null)
            {
                this.OSTEMELJNICAUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void PictureBoxClickedIDAMSKUPINE(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("AMSKUPINE", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedIDOSVRSTA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("OSVRSTA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesIDOSDOKUMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("OSDOKUMENT", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesRASHODLOKACIJEIDLOKACIJE(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("LOKACIJE", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.OSController.WorkItem.Items.Contains("OS|OS"))
            {
                this.OSController.WorkItem.Items.Add(this.bindingSourceOS, "OS|OS");
            }
            if (!this.OSController.WorkItem.Items.Contains("OS|OSTEMELJNICA"))
            {
                this.OSController.WorkItem.Items.Add(this.bindingSourceOSTEMELJNICA, "OS|OSTEMELJNICA");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
            this.OSController.WorkItem.Items.Add(this.IznosiNabave);
            this.OSController.WorkItem.Items.Add(this.UserDefinedControl1);
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsOSDataSet1.OS.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.OSController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OSController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.OSController.Update(this))
            {
                this.OSController.DataSet = new OSDataSet();
                DataSetUtil.AddEmptyRow(this.OSController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.OSController.DataSet.OS[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedIDAMSKUPINE(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDAMSKUPINE.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDAMSKUPINE.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceOS.Current).Row["IDAMSKUPINE"] = RuntimeHelpers.GetObjectValue(row["IDAMSKUPINE"]);
                    ((DataRowView) this.bindingSourceOS.Current).Row["OPISAMSKUPINE"] = RuntimeHelpers.GetObjectValue(row["OPISAMSKUPINE"]);
                    ((DataRowView) this.bindingSourceOS.Current).Row["AMSKUPINASTOPA"] = RuntimeHelpers.GetObjectValue(row["AMSKUPINASTOPA"]);
                    ((DataRowView) this.bindingSourceOS.Current).Row["KTONABAVKEIDKONTO"] = RuntimeHelpers.GetObjectValue(row["KTONABAVKEIDKONTO"]);
                    ((DataRowView) this.bindingSourceOS.Current).Row["KTOISPRAVKAIDKONTO"] = RuntimeHelpers.GetObjectValue(row["KTOISPRAVKAIDKONTO"]);
                    ((DataRowView) this.bindingSourceOS.Current).Row["KTOIZVORAIDKONTO"] = RuntimeHelpers.GetObjectValue(row["KTOIZVORAIDKONTO"]);
                    this.bindingSourceOS.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedIDOSVRSTA(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDOSVRSTA.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDOSVRSTA.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceOS.Current).Row["IDOSVRSTA"] = RuntimeHelpers.GetObjectValue(row["IDOSVRSTA"]);
                    this.bindingSourceOS.ResetCurrentItem();
                }
            }
        }

        private void SetComboBoxColumnProperties()
        {
            DataSet dataSet = new OSDOKUMENTDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetOSDOKUMENTDataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["OSDOKUMENT"]) {
                Sort = "OSDK"
            };
            CreateValueList(this.grdLevelOSTEMELJNICA, "OSDOKUMENTIDOSDOKUMENT", enumList, "IDOSDOKUMENT", "OSDK", false);
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelOSTEMELJNICA, "IDOSDOKUMENT");
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            gridColumn.ValueList = this.grdLevelOSTEMELJNICA.DisplayLayout.ValueLists["OSDOKUMENTIDOSDOKUMENT"];
            gridColumn.Width = 370;
            DataSet set2 = new LOKACIJEDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetLOKACIJEDataAdapter().Fill(set2);
            }
            DataView view2 = new DataView(set2.Tables["LOKACIJE"]) {
                Sort = "LOK"
            };
            CreateValueList(this.grdLevelOSTEMELJNICA, "LOKACIJERASHODLOKACIJEIDLOKACIJE", view2, "IDLOKACIJE", "LOK", false);
            UltraGridColumn column2 = FormHelperClass.GetGridColumn(this.grdLevelOSTEMELJNICA, "RASHODLOKACIJEIDLOKACIJE");
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.grdLevelOSTEMELJNICA.DisplayLayout.ValueLists["LOKACIJERASHODLOKACIJEIDLOKACIJE"];
            column2.Width = 370;
            this.grdLevelOSTEMELJNICA.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelOSTEMELJNICA.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.textINVBROJ.Focus();
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

        private void UpdateValuesIDOSDOKUMENT(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["IDOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(result["IDOSDOKUMENT"]);
                    row["NAZIVOSDOKUMENT"] = RuntimeHelpers.GetObjectValue(result["NAZIVOSDOKUMENT"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesRASHODLOKACIJEIDLOKACIJE(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["RASHODLOKACIJEIDLOKACIJE"] = RuntimeHelpers.GetObjectValue(result["IDLOKACIJE"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        [LocalCommandHandler("ViewOSRAZMJESTAJ")]
        public void ViewOSRAZMJESTAJHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OSController.ViewOSRAZMJESTAJ(this.m_CurrentRow);
            }
        }

        private AMSKUPINEComboBox comboIDAMSKUPINE;

        private OSVRSTAComboBox comboIDOSVRSTA;

        private ContextMenu contextMenu1;

        private UltraDateTimeEditor datePickerDATUMNABAVKE;

        private UltraDateTimeEditor datePickerDATUMUPORABE;

        private ErrorProvider errorProvider1;

        private ErrorProviderValidator errorProviderValidator1;

        private UltraGrid grdLevelOSTEMELJNICA;

        private IznosiNabave IznosiNabave;

        private UltraLabel label1DATUMNABAVKE;

        private UltraLabel label1DATUMUPORABE;

        private UltraLabel label1IDAMSKUPINE;

        private UltraLabel label1IDOSVRSTA;

        private UltraLabel label1INVBROJ;

        private UltraLabel label1KTOISPRAVKAIDKONTO;

        private UltraLabel label1KTOIZVORAIDKONTO;

        private UltraLabel label1KTONABAVKEIDKONTO;

        private UltraLabel label1NAPOMENAOS;

        private UltraLabel label1NAZIVOS;

        private UltraLabel labelKTOISPRAVKAIDKONTO;

        private UltraLabel labelKTOIZVORAIDKONTO;

        private UltraLabel labelKTONABAVKEIDKONTO;

        private UltraLabel linkLabelOSTEMELJNICA;

        private UltraLabel linkLabelOSTEMELJNICAAdd;

        private UltraLabel linkLabelOSTEMELJNICADelete;

        private UltraLabel linkLabelOSTEMELJNICAUpdate;

        public DeklaritMode Mode;

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.OSController OSController { get; set; }

        private Panel panelactionsOSTEMELJNICA;

        private MenuItem SetNullItem;

        public UltraTabControl Tab1;

        private UltraTabPageControl TabPage1;

        private UltraTabPageControl TabPage2;

        private UltraNumericEditor textINVBROJ;

        private UltraTextEditor textNAPOMENAOS;

        private UltraTextEditor textNAZIVOS;

        private System.Windows.Forms.ToolTip toolTip1;

        public RazmjestajSredstava UserDefinedControl1;
    }
}

