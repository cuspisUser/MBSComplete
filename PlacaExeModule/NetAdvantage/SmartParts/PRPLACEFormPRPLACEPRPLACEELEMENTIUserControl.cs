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
    public class PRPLACEFormPRPLACEPRPLACEELEMENTIUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDELEMENT")]
        private PROVIDER_BRUTOComboBox _comboIDELEMENT;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelPRPLACEPRPLACEELEMENTIRADNIK")]
        private UltraGrid _grdLevelPRPLACEPRPLACEELEMENTIRADNIK;
        [AccessedThroughProperty("label1IDELEMENT")]
        private UltraLabel _label1IDELEMENT;
        [AccessedThroughProperty("label1NAZIVELEMENT")]
        private UltraLabel _label1NAZIVELEMENT;
        [AccessedThroughProperty("label1POSTOTAK")]
        private UltraLabel _label1POSTOTAK;
        [AccessedThroughProperty("labelNAZIVELEMENT")]
        private UltraLabel _labelNAZIVELEMENT;
        [AccessedThroughProperty("labelPOSTOTAK")]
        private UltraLabel _labelPOSTOTAK;
        [AccessedThroughProperty("linkLabelPRPLACEPRPLACEELEMENTIRADNIK")]
        private UltraLabel _linkLabelPRPLACEPRPLACEELEMENTIRADNIK;
        [AccessedThroughProperty("linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd")]
        private UltraLabel _linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd;
        [AccessedThroughProperty("linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete")]
        private UltraLabel _linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete;
        [AccessedThroughProperty("linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate")]
        private UltraLabel _linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate;
        [AccessedThroughProperty("panelactionsPRPLACEPRPLACEELEMENTIRADNIK")]
        private Panel _panelactionsPRPLACEPRPLACEELEMENTIRADNIK;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourcePRPLACEPRPLACEELEMENTI;
        private BindingSource bindingSourcePRPLACEPRPLACEELEMENTIRADNIK;
        private IContainer components = null;
        private PRPLACEDataSet dsPRPLACEDataSet1;
        protected TableLayoutPanel layoutManagerformPRPLACEPRPLACEELEMENTI;
        protected TableLayoutPanel layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "PRPLACEPRPLACEELEMENTI";
        private string m_FrameworkDescription = StringResources.PRPLACEDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public PRPLACEFormPRPLACEPRPLACEELEMENTIUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("PRPLACEPRPLACEELEMENTIAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("PRPLACEPRPLACEELEMENTIAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow) ((DataRowView) this.bindingSourcePRPLACEPRPLACEELEMENTI.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsPRPLACEDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourcePRPLACEPRPLACEELEMENTI.DataSource = this.PRPLACEController.DataSet;
            this.dsPRPLACEDataSet1 = this.PRPLACEController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ELEMENT", Thread=ThreadOption.UserInterface)]
        public void comboIDELEMENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDELEMENT.Fill();
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

        private void dg_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGridColumn column = e.Cell.Column;
            if ((column.CellActivation == Activation.AllowEdit) && (Conversions.ToString(column.Tag) == "RADNIKIDRADNIKAddNew"))
            {
                this.PictureBoxClickedInLinesIDRADNIK(RuntimeHelpers.GetObjectValue(sender), e);
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
            if (this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.ActiveRow != null)
            {
                this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.PerformAction(UltraGridAction.NextRow);
            }
        }

        private void FillProviderCombocomboIDELEMENT()
        {
            object objectValue = RuntimeHelpers.GetObjectValue(this.comboIDELEMENT.Value);
            this.comboIDELEMENT.Fill();
            if (objectValue != null)
            {
                this.comboIDELEMENT.Value = RuntimeHelpers.GetObjectValue(objectValue);
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
                if (e.Cell.Column.Key == "IDRADNIK")
                {
                    this.UpdateValuesIDRADNIK(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
            }
        }

        private void grdLevelPRPLACEPRPLACEELEMENTIRADNIK_AfterRowActivate(object sender, EventArgs e)
        {
            string pRPLACEPRPLACEPRPLACEELEMENTIRADNIKLevelDescription = StringResources.PRPLACEPRPLACEPRPLACEELEMENTIRADNIKLevelDescription;
            UltraGridRow activeRow = this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.ActiveRow;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd.Text = Deklarit.Resources.Resources.Add + " " + pRPLACEPRPLACEPRPLACEELEMENTIRADNIKLevelDescription;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate.Text = Deklarit.Resources.Resources.Update + " " + pRPLACEPRPLACEPRPLACEELEMENTIRADNIKLevelDescription;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete.Text = Deklarit.Resources.Resources.Delete + " " + pRPLACEPRPLACEPRPLACEELEMENTIRADNIKLevelDescription;
        }

        private void grdLevelPRPLACEPRPLACEELEMENTIRADNIK_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourcePRPLACEPRPLACEELEMENTI.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourcePRPLACEPRPLACEELEMENTI.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelPRPLACEPRPLACEELEMENTIRADNIK_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.PRPLACEPRPLACEELEMENTIRADNIKUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelPRPLACEPRPLACEELEMENTIRADNIK_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourcePRPLACEPRPLACEELEMENTI, this.PRPLACEController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow parentRow, bool isCopy)
        {
            this.m_ParentRow = parentRow;
            this.dsPRPLACEDataSet1 = (PRPLACEDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourcePRPLACEPRPLACEELEMENTI.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsPRPLACEDataSet1.Tables["PRPLACEPRPLACEELEMENTI"]);
            this.bindingSourcePRPLACEPRPLACEELEMENTI.DataMember = "";
            this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.DataMember = "PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "PRPLACE", this.m_Mode, this.dsPRPLACEDataSet1, this.dsPRPLACEDataSet1.PRPLACEPRPLACEELEMENTI.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            Binding binding = new Binding("Text", this.bindingSourcePRPLACEPRPLACEELEMENTI, "POSTOTAK", true);
            binding.Format += new ConvertEventHandler(this.m_BaseMethods.NumericFormat);
            if (this.labelPOSTOTAK.DataBindings["Text"] != null)
            {
                this.labelPOSTOTAK.DataBindings.Remove(this.labelPOSTOTAK.DataBindings["Text"]);
            }
            this.labelPOSTOTAK.DataBindings.Add(binding);
            if (!this.m_DataGrids.Contains(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK))
            {
                this.m_DataGrids.Add(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow) ((DataRowView) this.bindingSourcePRPLACEPRPLACEELEMENTI.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (PRPLACEDataSet.PRPLACEPRPLACEELEMENTIRow) ((DataRowView) this.bindingSourcePRPLACEPRPLACEELEMENTI.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.FillProviderCombocomboIDELEMENT();
            if (this.m_BaseMethods.IsInsert())
            {
                this.comboIDELEMENT.SelectedIndex = -1;
            }
            if (this.comboIDELEMENT.DataBindings["Value"] != null)
            {
                this.comboIDELEMENT.DataBindings.Remove(this.comboIDELEMENT.DataBindings["Value"]);
            }
            this.comboIDELEMENT.DataBindings.Add(new Binding("Value", this.bindingSourcePRPLACEPRPLACEELEMENTI, "IDELEMENT"));
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(PRPLACEFormPRPLACEPRPLACEELEMENTIUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourcePRPLACEPRPLACEELEMENTI = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePRPLACEPRPLACEELEMENTI).BeginInit();
            this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK).BeginInit();
            this.layoutManagerformPRPLACEPRPLACEELEMENTI = new TableLayoutPanel();
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SuspendLayout();
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.AutoSize = true;
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.Dock = DockStyle.Fill;
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.Size = size;
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.ColumnCount = 2;
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.RowCount = 5;
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.RowStyles.Add(new RowStyle());
            this.label1IDELEMENT = new UltraLabel();
            this.comboIDELEMENT = new PROVIDER_BRUTOComboBox();
            this.label1NAZIVELEMENT = new UltraLabel();
            this.labelNAZIVELEMENT = new UltraLabel();
            this.label1POSTOTAK = new UltraLabel();
            this.labelPOSTOTAK = new UltraLabel();
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK = new UltraGrid();
            this.panelactionsPRPLACEPRPLACEELEMENTIRADNIK = new Panel();
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK = new TableLayoutPanel();
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.AutoSize = true;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.ColumnCount = 4;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.RowCount = 1;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.RowStyles.Add(new RowStyle());
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd = new UltraLabel();
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate = new UltraLabel();
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete = new UltraLabel();
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIK = new UltraLabel();
            ((ISupportInitialize) this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK).BeginInit();
            this.panelactionsPRPLACEPRPLACEELEMENTIRADNIK.SuspendLayout();
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.SuspendLayout();
            UltraGridBand band = new UltraGridBand("PRPLACEPRPLACEELEMENTIRADNIK", -1);
            UltraGridColumn column13 = new UltraGridColumn("PRPLACEZAMJESEC");
            UltraGridColumn column7 = new UltraGridColumn("PRPLACEID");
            UltraGridColumn column12 = new UltraGridColumn("PRPLACEZAGODINU");
            UltraGridColumn column = new UltraGridColumn("IDELEMENT");
            UltraGridColumn column2 = new UltraGridColumn("columnIDELEMENTAddNew", 0);
            UltraGridColumn column3 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column4 = new UltraGridColumn("columnIDRADNIKAddNew", 1);
            UltraGridColumn column6 = new UltraGridColumn("PREZIME");
            UltraGridColumn column5 = new UltraGridColumn("IME");
            UltraGridColumn column10 = new UltraGridColumn("PRPLACESATI");
            UltraGridColumn column11 = new UltraGridColumn("PRPLACESATNICA");
            UltraGridColumn column9 = new UltraGridColumn("PRPLACEPOSTOTAK");
            UltraGridColumn column8 = new UltraGridColumn("PRPLACEIZNOS");
            UltraGridColumn column14 = new UltraGridColumn("SPOJENOPREZIME");
            this.dsPRPLACEDataSet1 = new PRPLACEDataSet();
            this.dsPRPLACEDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsPRPLACEDataSet1.DataSetName = "dsPRPLACE";
            this.dsPRPLACEDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourcePRPLACEPRPLACEELEMENTI.DataSource = this.dsPRPLACEDataSet1;
            this.bindingSourcePRPLACEPRPLACEELEMENTI.DataMember = "PRPLACEPRPLACEELEMENTI";
            ((ISupportInitialize) this.bindingSourcePRPLACEPRPLACEELEMENTI).BeginInit();
            this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.DataSource = this.bindingSourcePRPLACEPRPLACEELEMENTI;
            this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK.DataMember = "PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK";
            point = new System.Drawing.Point(0, 0);
            this.label1IDELEMENT.Location = point;
            this.label1IDELEMENT.Name = "label1IDELEMENT";
            this.label1IDELEMENT.TabIndex = 1;
            this.label1IDELEMENT.Tag = "labelIDELEMENT";
            this.label1IDELEMENT.Text = "Šifra elementa:";
            this.label1IDELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1IDELEMENT.AutoSize = true;
            this.label1IDELEMENT.Anchor = AnchorStyles.Left;
            this.label1IDELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDELEMENT.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDELEMENT.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDELEMENT.ImageSize = size;
            this.label1IDELEMENT.Appearance.ForeColor = Color.Black;
            this.label1IDELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.Controls.Add(this.label1IDELEMENT, 0, 0);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetColumnSpan(this.label1IDELEMENT, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetRowSpan(this.label1IDELEMENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x6b, 0x17);
            this.label1IDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDELEMENT.Location = point;
            this.comboIDELEMENT.Name = "comboIDELEMENT";
            this.comboIDELEMENT.Tag = "IDELEMENT";
            this.comboIDELEMENT.TabIndex = 0;
            this.comboIDELEMENT.Anchor = AnchorStyles.Left;
            this.comboIDELEMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDELEMENT.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDELEMENT.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDELEMENT.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDELEMENT.Enabled = true;
            this.comboIDELEMENT.FillAtStartup = false;
            this.comboIDELEMENT.ShowPictureBox = true;
            this.comboIDELEMENT.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDELEMENT);
            this.comboIDELEMENT.ValueMember = "IDELEMENT";
            this.comboIDELEMENT.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDELEMENT);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.Controls.Add(this.comboIDELEMENT, 1, 0);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetColumnSpan(this.comboIDELEMENT, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetRowSpan(this.comboIDELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVELEMENT.Location = point;
            this.label1NAZIVELEMENT.Name = "label1NAZIVELEMENT";
            this.label1NAZIVELEMENT.TabIndex = 1;
            this.label1NAZIVELEMENT.Tag = "labelNAZIVELEMENT";
            this.label1NAZIVELEMENT.Text = "Naziv elementa:";
            this.label1NAZIVELEMENT.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVELEMENT.AutoSize = true;
            this.label1NAZIVELEMENT.Anchor = AnchorStyles.Left;
            this.label1NAZIVELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVELEMENT.Appearance.ForeColor = Color.Black;
            this.label1NAZIVELEMENT.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.Controls.Add(this.label1NAZIVELEMENT, 0, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetColumnSpan(this.label1NAZIVELEMENT, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetRowSpan(this.label1NAZIVELEMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x73, 0x17);
            this.label1NAZIVELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelNAZIVELEMENT.Location = point;
            this.labelNAZIVELEMENT.Name = "labelNAZIVELEMENT";
            this.labelNAZIVELEMENT.Tag = "NAZIVELEMENT";
            this.labelNAZIVELEMENT.TabIndex = 0;
            this.labelNAZIVELEMENT.Anchor = AnchorStyles.Left;
            this.labelNAZIVELEMENT.BackColor = Color.Transparent;
            this.labelNAZIVELEMENT.DataBindings.Add(new Binding("Text", this.bindingSourcePRPLACEPRPLACEELEMENTI, "NAZIVELEMENT"));
            this.labelNAZIVELEMENT.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.Controls.Add(this.labelNAZIVELEMENT, 1, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetColumnSpan(this.labelNAZIVELEMENT, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetRowSpan(this.labelNAZIVELEMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelNAZIVELEMENT.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.labelNAZIVELEMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1POSTOTAK.Location = point;
            this.label1POSTOTAK.Name = "label1POSTOTAK";
            this.label1POSTOTAK.TabIndex = 1;
            this.label1POSTOTAK.Tag = "labelPOSTOTAK";
            this.label1POSTOTAK.Text = "Postotak:";
            this.label1POSTOTAK.StyleSetName = "FieldUltraLabel";
            this.label1POSTOTAK.AutoSize = true;
            this.label1POSTOTAK.Anchor = AnchorStyles.Left;
            this.label1POSTOTAK.Appearance.TextVAlign = VAlign.Middle;
            this.label1POSTOTAK.Appearance.ForeColor = Color.Black;
            this.label1POSTOTAK.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.Controls.Add(this.label1POSTOTAK, 0, 2);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetColumnSpan(this.label1POSTOTAK, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetRowSpan(this.label1POSTOTAK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1POSTOTAK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1POSTOTAK.MinimumSize = size;
            size = new System.Drawing.Size(0x4a, 0x17);
            this.label1POSTOTAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPOSTOTAK.Location = point;
            this.labelPOSTOTAK.Name = "labelPOSTOTAK";
            this.labelPOSTOTAK.Tag = "POSTOTAK";
            this.labelPOSTOTAK.TabIndex = 0;
            this.labelPOSTOTAK.Anchor = AnchorStyles.Left;
            this.labelPOSTOTAK.BackColor = Color.Transparent;
            this.labelPOSTOTAK.Appearance.TextHAlign = HAlign.Left;
            this.labelPOSTOTAK.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.Controls.Add(this.labelPOSTOTAK, 1, 2);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetColumnSpan(this.labelPOSTOTAK, 1);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetRowSpan(this.labelPOSTOTAK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPOSTOTAK.Margin = padding;
            size = new System.Drawing.Size(0x37, 0x16);
            this.labelPOSTOTAK.MinimumSize = size;
            size = new System.Drawing.Size(0x37, 0x16);
            this.labelPOSTOTAK.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.Location = point;
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.Name = "grdLevelPRPLACEPRPLACEELEMENTIRADNIK";
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.Controls.Add(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK, 0, 3);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetColumnSpan(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK, 2);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetRowSpan(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x1af, 200);
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.Size = size;
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsPRPLACEPRPLACEELEMENTIRADNIK.Location = point;
            this.panelactionsPRPLACEPRPLACEELEMENTIRADNIK.Name = "panelactionsPRPLACEPRPLACEELEMENTIRADNIK";
            this.panelactionsPRPLACEPRPLACEELEMENTIRADNIK.BackColor = Color.Transparent;
            this.panelactionsPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.Controls.Add(this.panelactionsPRPLACEPRPLACEELEMENTIRADNIK, 0, 4);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetColumnSpan(this.panelactionsPRPLACEPRPLACEELEMENTIRADNIK, 2);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.SetRowSpan(this.panelactionsPRPLACEPRPLACEELEMENTIRADNIK, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsPRPLACEPRPLACEELEMENTIRADNIK.Margin = padding;
            size = new System.Drawing.Size(0x1d4, 0x19);
            this.panelactionsPRPLACEPRPLACEELEMENTIRADNIK.MinimumSize = size;
            size = new System.Drawing.Size(0x1d4, 0x19);
            this.panelactionsPRPLACEPRPLACEELEMENTIRADNIK.Size = size;
            this.panelactionsPRPLACEPRPLACEELEMENTIRADNIK.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd.Location = point;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd.Name = "linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd";
            size = new System.Drawing.Size(0x84, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd.Size = size;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd.Text = " Add Radnici u pripremi  ";
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd.Click += new EventHandler(this.PRPLACEPRPLACEELEMENTIRADNIKAdd_Click);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd.BackColor = Color.Transparent;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd.Cursor = Cursors.Hand;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd.AutoSize = true;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd, 0, 0);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd, 1);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd.Margin = padding;
            size = new System.Drawing.Size(0x84, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x84, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate.Location = point;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate.Name = "linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate";
            size = new System.Drawing.Size(150, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate.Size = size;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate.Text = " Update Radnici u pripremi  ";
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate.Click += new EventHandler(this.PRPLACEPRPLACEELEMENTIRADNIKUpdate_Click);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate.BackColor = Color.Transparent;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate.Cursor = Cursors.Hand;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate.AutoSize = true;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate, 1, 0);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate, 1);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate.Margin = padding;
            size = new System.Drawing.Size(150, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate.MinimumSize = size;
            size = new System.Drawing.Size(150, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete.Location = point;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete.Name = "linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete";
            size = new System.Drawing.Size(0x92, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete.Size = size;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete.Text = " Delete Radnici u pripremi  ";
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete.Click += new EventHandler(this.PRPLACEPRPLACEELEMENTIRADNIKDelete_Click);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete.BackColor = Color.Transparent;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete.Cursor = Cursors.Hand;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete.AutoSize = true;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete, 2, 0);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete, 1);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete.Margin = padding;
            size = new System.Drawing.Size(0x92, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x92, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIK.Location = point;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIK.Name = "linkLabelPRPLACEPRPLACEELEMENTIRADNIK";
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.Controls.Add(this.linkLabelPRPLACEPRPLACEELEMENTIRADNIK, 3, 0);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.SetColumnSpan(this.linkLabelPRPLACEPRPLACEELEMENTIRADNIK, 1);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.SetRowSpan(this.linkLabelPRPLACEPRPLACEELEMENTIRADNIK, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIK.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIK.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIK.Size = size;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIK.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformPRPLACEPRPLACEELEMENTI);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourcePRPLACEPRPLACEELEMENTI;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.Disabled;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.PRPLACEPRPLACEZAMJESECDescription;
            column13.Width = 0x4e;
            appearance11.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nn";
            column13.PromptChar = ' ';
            column13.Format = "";
            column13.CellAppearance = appearance11;
            column13.Hidden = true;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.Disabled;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.PRPLACEPRPLACEIDDescription;
            column7.Width = 0xcf;
            appearance5.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnn";
            column7.PromptChar = ' ';
            column7.Format = "";
            column7.CellAppearance = appearance5;
            column7.Hidden = true;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.Disabled;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.PRPLACEPRPLACEZAGODINUDescription;
            column12.Width = 0x4e;
            appearance10.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnn";
            column12.PromptChar = ' ';
            column12.Format = "";
            column12.CellAppearance = appearance10;
            column12.Hidden = true;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.Disabled;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.PRPLACEIDELEMENTDescription;
            column.Width = 0x70;
            column.Format = "";
            column.CellAppearance = appearance;
            column.Hidden = true;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.PRPLACEIDRADNIKDescription;
            column3.Width = 0x55;
            column3.Format = "";
            column3.CellAppearance = appearance2;
            column4.AllowGroupBy = DefaultableBoolean.False;
            column4.AutoSizeEdit = DefaultableBoolean.False;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column4.CellAppearance.BorderAlpha = Alpha.Transparent;
            column4.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column4.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column4.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column4.Header.Enabled = false;
            column4.Header.Fixed = true;
            column4.Header.Caption = "";
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column4.Width = 20;
            column4.MinWidth = 20;
            column4.MaxWidth = 20;
            column4.Tag = "RADNIKIDRADNIKAddNew";
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.Disabled;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.PRPLACEPREZIMEDescription;
            column6.Width = 0x128;
            column6.Format = "";
            column6.CellAppearance = appearance4;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.Disabled;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.PRPLACEIMEDescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance3;
            column5.Hidden = true;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.PRPLACEPRPLACESATIDescription;
            column10.Width = 0x37;
            appearance8.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.PRPLACEPRPLACESATNICADescription;
            column11.Width = 0x45;
            appearance9.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.PRPLACEPRPLACEPOSTOTAKDescription;
            column9.Width = 0x4b;
            appearance7.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.PRPLACEPRPLACEIZNOSDescription;
            column8.Width = 0x66;
            appearance6.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.Disabled;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.PRPLACESPOJENOPREZIMEDescription;
            column14.Width = 0x128;
            column14.Format = "";
            column14.CellAppearance = appearance12;
            column14.Hidden = true;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 1;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 2;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 3;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 4;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 5;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 6;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 7;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 8;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 9;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 10;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 11;
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.Visible = true;
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.Name = "grdLevelPRPLACEPRPLACEELEMENTIRADNIK";
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.Tag = "PRPLACEPRPLACEELEMENTIRADNIK";
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.TabIndex = 12;
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.Dock = DockStyle.Fill;
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.DataSource = this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK;
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.Enter += new EventHandler(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK_Enter);
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.AfterRowInsert += new RowEventHandler(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK_AfterRowInsert);
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK_DoubleClick);
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.AfterRowActivate += new EventHandler(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK_AfterRowActivate);
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.DisplayLayout.BandsSerializer.Add(band);
            this.Name = "PRPLACEFormPRPLACEPRPLACEELEMENTIUserControl";
            this.Text = " Elementi u pripremi";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.PRPLACEFormUserControl_Load);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.ResumeLayout(false);
            this.layoutManagerformPRPLACEPRPLACEELEMENTI.PerformLayout();
            ((ISupportInitialize) this.bindingSourcePRPLACEPRPLACEELEMENTI).EndInit();
            ((ISupportInitialize) this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK).EndInit();
            ((ISupportInitialize) this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK).EndInit();
            this.panelactionsPRPLACEPRPLACEELEMENTIRADNIK.ResumeLayout(true);
            this.panelactionsPRPLACEPRPLACEELEMENTIRADNIK.PerformLayout();
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.ResumeLayout(false);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTIRADNIK.PerformLayout();
            this.dsPRPLACEDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.PRPLACEController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourcePRPLACEPRPLACEELEMENTI, this.PRPLACEController.WorkItem, this))
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
            this.label1IDELEMENT.Text = StringResources.PRPLACEIDELEMENTDescription;
            this.label1NAZIVELEMENT.Text = StringResources.PRPLACENAZIVELEMENTDescription;
            this.label1POSTOTAK.Text = StringResources.PRPLACEPOSTOTAKDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDELEMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ELEMENT", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesIDRADNIK(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("RADNIK", null, DeklaritMode.Insert));
            }
        }

        private void PRPLACEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.PRPLACEPRPLACEPRPLACEELEMENTILevelDescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.PRPLACEPRPLACEPRPLACEELEMENTIRADNIKLevelDescription;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.PRPLACEPRPLACEPRPLACEELEMENTIRADNIKLevelDescription;
            this.linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.PRPLACEPRPLACEPRPLACEELEMENTIRADNIKLevelDescription;
        }

        private void PRPLACEPRPLACEELEMENTIRADNIKAdd_Click(object sender, EventArgs e)
        {
            this.EndEditCurrentRow();
            UltraGridRow activeRow = this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.ActiveRow;
            this.PRPLACEPRPLACEELEMENTIRADNIKInsert();
        }

        private void PRPLACEPRPLACEELEMENTIRADNIKDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK);
            if ((currentRowListIndex != -1) && (this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.Selected.Rows.Count > 0))
            {
                this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK).Selected = true;
                this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/RADNIK", Thread=ThreadOption.UserInterface)]
        public void PRPLACEPRPLACEELEMENTIRADNIKIDRADNIK_Add(object sender, ComponentEventArgs e)
        {
            PregledRadnikaComboBox box = new PregledRadnikaComboBox();
            box.Fill();
            DataView defaultView = box.DataSet.Tables["RADNIK"].DefaultView;
            CreateValueList(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK, "RADNIKIDRADNIK", defaultView, "IDRADNIK", "SPOJENOPREZIME", true);
        }

        private void PRPLACEPRPLACEELEMENTIRADNIKInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourcePRPLACEPRPLACEELEMENTI, this.PRPLACEController.WorkItem, this))
            {
                this.PRPLACEController.AddPRPLACEPRPLACEELEMENTIRADNIK(this.m_CurrentRow);
            }
        }

        private void PRPLACEPRPLACEELEMENTIRADNIKUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.PRPLACEController.UpdatePRPLACEPRPLACEELEMENTIRADNIK(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void PRPLACEPRPLACEELEMENTIRADNIKUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.ActiveRow != null)
            {
                this.PRPLACEPRPLACEELEMENTIRADNIKUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.PRPLACEController.WorkItem.Items.Contains("PRPLACEPRPLACEELEMENTI|PRPLACEPRPLACEELEMENTI"))
            {
                this.PRPLACEController.WorkItem.Items.Add(this.bindingSourcePRPLACEPRPLACEELEMENTI, "PRPLACEPRPLACEELEMENTI|PRPLACEPRPLACEELEMENTI");
            }
            if (!this.PRPLACEController.WorkItem.Items.Contains("PRPLACEPRPLACEELEMENTI|PRPLACEPRPLACEELEMENTIRADNIK"))
            {
                this.PRPLACEController.WorkItem.Items.Add(this.bindingSourcePRPLACEPRPLACEELEMENTIRADNIK, "PRPLACEPRPLACEELEMENTI|PRPLACEPRPLACEELEMENTIRADNIK");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("PRPLACEPRPLACEELEMENTISaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedIDELEMENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDELEMENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDELEMENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourcePRPLACEPRPLACEELEMENTI.Current).Row["IDELEMENT"] = RuntimeHelpers.GetObjectValue(row["IDELEMENT"]);
                    ((DataRowView) this.bindingSourcePRPLACEPRPLACEELEMENTI.Current).Row["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(row["NAZIVELEMENT"]);
                    ((DataRowView) this.bindingSourcePRPLACEPRPLACEELEMENTI.Current).Row["POSTOTAK"] = RuntimeHelpers.GetObjectValue(row["POSTOTAK"]);
                    this.bindingSourcePRPLACEPRPLACEELEMENTI.ResetCurrentItem();
                }
            }
        }

        private void SetComboBoxColumnProperties()
        {
            PregledRadnikaComboBox box = new PregledRadnikaComboBox();
            box.Fill();
            DataView defaultView = box.DataSet.Tables["RADNIK"].DefaultView;
            CreateValueList(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK, "RADNIKIDRADNIK", defaultView, "IDRADNIK", "SPOJENOPREZIME", false);
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK, "IDRADNIK");
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            gridColumn.ValueList = this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.DisplayLayout.ValueLists["RADNIKIDRADNIK"];
            gridColumn.Width = 370;
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelPRPLACEPRPLACEELEMENTIRADNIK.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.comboIDELEMENT.Focus();
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
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        protected virtual PROVIDER_BRUTOComboBox comboIDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDELEMENT = value;
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

        protected virtual UltraGrid grdLevelPRPLACEPRPLACEELEMENTIRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelPRPLACEPRPLACEELEMENTIRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelPRPLACEPRPLACEELEMENTIRADNIK = value;
            }
        }

        protected virtual UltraLabel label1IDELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDELEMENT = value;
            }
        }

        protected virtual UltraLabel label1NAZIVELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVELEMENT = value;
            }
        }

        protected virtual UltraLabel label1POSTOTAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1POSTOTAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1POSTOTAK = value;
            }
        }

        protected virtual UltraLabel labelNAZIVELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelNAZIVELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelNAZIVELEMENT = value;
            }
        }

        protected virtual UltraLabel labelPOSTOTAK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPOSTOTAK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPOSTOTAK = value;
            }
        }

        protected virtual UltraLabel linkLabelPRPLACEPRPLACEELEMENTIRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPRPLACEPRPLACEELEMENTIRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPRPLACEPRPLACEELEMENTIRADNIK = value;
            }
        }

        protected virtual UltraLabel linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPRPLACEPRPLACEELEMENTIRADNIKAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPRPLACEPRPLACEELEMENTIRADNIKDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPRPLACEPRPLACEELEMENTIRADNIKUpdate = value;
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

        protected virtual Panel panelactionsPRPLACEPRPLACEELEMENTIRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsPRPLACEPRPLACEELEMENTIRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsPRPLACEPRPLACEELEMENTIRADNIK = value;
            }
        }

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.PRPLACEController PRPLACEController { get; set; }

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

