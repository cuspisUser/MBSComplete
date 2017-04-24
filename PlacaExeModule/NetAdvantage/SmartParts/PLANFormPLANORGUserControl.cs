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
    public class PLANFormPLANORGUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboPLANOJIDORGJED")]
        private ORGJEDComboBox _comboPLANOJIDORGJED;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelPLANORGKON")]
        private UltraGrid _grdLevelPLANORGKON;
        [AccessedThroughProperty("label1PLANOJIDORGJED")]
        private UltraLabel _label1PLANOJIDORGJED;
        [AccessedThroughProperty("label1PLANOJNAZIVORGJED")]
        private UltraLabel _label1PLANOJNAZIVORGJED;
        [AccessedThroughProperty("labelPLANOJNAZIVORGJED")]
        private UltraLabel _labelPLANOJNAZIVORGJED;
        [AccessedThroughProperty("linkLabelPLANORGKON")]
        private UltraLabel _linkLabelPLANORGKON;
        [AccessedThroughProperty("linkLabelPLANORGKONAdd")]
        private UltraLabel _linkLabelPLANORGKONAdd;
        [AccessedThroughProperty("linkLabelPLANORGKONDelete")]
        private UltraLabel _linkLabelPLANORGKONDelete;
        [AccessedThroughProperty("linkLabelPLANORGKONUpdate")]
        private UltraLabel _linkLabelPLANORGKONUpdate;
        [AccessedThroughProperty("panelactionsPLANORGKON")]
        private Panel _panelactionsPLANORGKON;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourcePLANORG;
        private BindingSource bindingSourcePLANORGKON;
        private IContainer components = null;
        private PLANDataSet dsPLANDataSet1;
        protected TableLayoutPanel layoutManagerformPLANORG;
        protected TableLayoutPanel layoutManagerpanelactionsPLANORGKON;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private PLANDataSet.PLANORGRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "PLANORG";
        private string m_FrameworkDescription = StringResources.PLANDescription;
        private DeklaritMode m_Mode;
        private DataRow m_ParentRow;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public PLANFormPLANORGUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        [LocalCommandHandler("PLANORGAddLine")]
        public void AddLine(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("PLANORGAddLineAndNew")]
        public void AddLineAndNew(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SetFocusInFirstField();
                this.m_CurrentRow = (PLANDataSet.PLANORGRow) ((DataRowView) this.bindingSourcePLANORG.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsPLANDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourcePLANORG.DataSource = this.PLANController.DataSet;
            this.dsPLANDataSet1 = this.PLANController.DataSet;
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ORGJED", Thread=ThreadOption.UserInterface)]
        public void comboPLANOJIDORGJED_Add(object sender, ComponentEventArgs e)
        {
            this.comboPLANOJIDORGJED.Fill();
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
            if ((column.CellActivation == Activation.AllowEdit) && (Conversions.ToString(column.Tag) == "KONTOPLANKONTOIDKONTOAddNew"))
            {
                this.PictureBoxClickedInLinesPLANKONTOIDKONTO(RuntimeHelpers.GetObjectValue(sender), e);
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
            if (this.grdLevelPLANORGKON.ActiveRow != null)
            {
                this.grdLevelPLANORGKON.PerformAction(UltraGridAction.NextRow);
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
                if (e.Cell.Column.Key == "PLANKONTOIDKONTO")
                {
                    this.UpdateValuesPLANKONTOIDKONTO(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
            }
        }

        private void grdLevelPLANORGKON_AfterRowActivate(object sender, EventArgs e)
        {
            string pLANPLANORGKONLevelDescription = StringResources.PLANPLANORGKONLevelDescription;
            UltraGridRow activeRow = this.grdLevelPLANORGKON.ActiveRow;
            this.linkLabelPLANORGKONAdd.Text = Deklarit.Resources.Resources.Add + " " + pLANPLANORGKONLevelDescription;
            this.linkLabelPLANORGKONUpdate.Text = Deklarit.Resources.Resources.Update + " " + pLANPLANORGKONLevelDescription;
            this.linkLabelPLANORGKONDelete.Text = Deklarit.Resources.Resources.Delete + " " + pLANPLANORGKONLevelDescription;
        }

        private void grdLevelPLANORGKON_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourcePLANORG.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourcePLANORG.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelPLANORGKON_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.PLANORGKONUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelPLANORGKON_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourcePLANORG, this.PLANController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow parentRow, bool isCopy)
        {
            this.m_ParentRow = parentRow;
            this.dsPLANDataSet1 = (PLANDataSet) this.m_ParentRow.Table.DataSet;
            this.bindingSourcePLANORG.DataSource = DataSetUtil.GetSubTreeDataView(this.m_ParentRow, this.dsPLANDataSet1.Tables["PLANORG"]);
            this.bindingSourcePLANORG.DataMember = "";
            this.bindingSourcePLANORGKON.DataMember = "PLANORG_PLANORGKON";
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "PLAN", this.m_Mode, this.dsPLANDataSet1, this.dsPLANDataSet1.PLANORG.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            if (!this.m_DataGrids.Contains(this.grdLevelPLANORGKON))
            {
                this.m_DataGrids.Add(this.grdLevelPLANORGKON);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = (PLANDataSet.PLANORGRow) ((DataRowView) this.bindingSourcePLANORG.Current).Row;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (PLANDataSet.PLANORGRow) ((DataRowView) this.bindingSourcePLANORG.AddNew()).Row;
                this.m_CurrentRow.SetParentRow(this.m_ParentRow);
            }
            this.SetFocusInFirstField();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(PLANFormPLANORGUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourcePLANORG = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePLANORG).BeginInit();
            this.bindingSourcePLANORGKON = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePLANORGKON).BeginInit();
            this.layoutManagerformPLANORG = new TableLayoutPanel();
            this.layoutManagerformPLANORG.SuspendLayout();
            this.layoutManagerformPLANORG.AutoSize = true;
            this.layoutManagerformPLANORG.Dock = DockStyle.Fill;
            this.layoutManagerformPLANORG.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPLANORG.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPLANORG.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPLANORG.Size = size;
            this.layoutManagerformPLANORG.ColumnCount = 2;
            this.layoutManagerformPLANORG.RowCount = 4;
            this.layoutManagerformPLANORG.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPLANORG.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPLANORG.RowStyles.Add(new RowStyle());
            this.layoutManagerformPLANORG.RowStyles.Add(new RowStyle());
            this.layoutManagerformPLANORG.RowStyles.Add(new RowStyle());
            this.layoutManagerformPLANORG.RowStyles.Add(new RowStyle());
            this.label1PLANOJIDORGJED = new UltraLabel();
            this.comboPLANOJIDORGJED = new ORGJEDComboBox();
            this.label1PLANOJNAZIVORGJED = new UltraLabel();
            this.labelPLANOJNAZIVORGJED = new UltraLabel();
            this.grdLevelPLANORGKON = new UltraGrid();
            this.panelactionsPLANORGKON = new Panel();
            this.layoutManagerpanelactionsPLANORGKON = new TableLayoutPanel();
            this.layoutManagerpanelactionsPLANORGKON.AutoSize = true;
            this.layoutManagerpanelactionsPLANORGKON.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsPLANORGKON.ColumnCount = 4;
            this.layoutManagerpanelactionsPLANORGKON.RowCount = 1;
            this.layoutManagerpanelactionsPLANORGKON.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsPLANORGKON.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPLANORGKON.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPLANORGKON.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPLANORGKON.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPLANORGKON.RowStyles.Add(new RowStyle());
            this.linkLabelPLANORGKONAdd = new UltraLabel();
            this.linkLabelPLANORGKONUpdate = new UltraLabel();
            this.linkLabelPLANORGKONDelete = new UltraLabel();
            this.linkLabelPLANORGKON = new UltraLabel();
            ((ISupportInitialize) this.grdLevelPLANORGKON).BeginInit();
            this.panelactionsPLANORGKON.SuspendLayout();
            this.layoutManagerpanelactionsPLANORGKON.SuspendLayout();
            UltraGridBand band = new UltraGridBand("PLANORGKON", -1);
            UltraGridColumn column = new UltraGridColumn("IDPLAN");
            UltraGridColumn column2 = new UltraGridColumn("PLANGODINAIDGODINE");
            UltraGridColumn column6 = new UltraGridColumn("PLANOJIDORGJED");
            UltraGridColumn column7 = new UltraGridColumn("columnPLANOJIDORGJEDAddNew", 0);
            UltraGridColumn column4 = new UltraGridColumn("PLANKONTOIDKONTO");
            UltraGridColumn column5 = new UltraGridColumn("columnPLANKONTOIDKONTOAddNew", 1);
            UltraGridColumn column3 = new UltraGridColumn("PLANIRANIIZNOS");
            this.dsPLANDataSet1 = new PLANDataSet();
            this.dsPLANDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsPLANDataSet1.DataSetName = "dsPLAN";
            this.dsPLANDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourcePLANORG.DataSource = this.dsPLANDataSet1;
            this.bindingSourcePLANORG.DataMember = "PLANORG";
            ((ISupportInitialize) this.bindingSourcePLANORG).BeginInit();
            this.bindingSourcePLANORGKON.DataSource = this.bindingSourcePLANORG;
            this.bindingSourcePLANORGKON.DataMember = "PLANORG_PLANORGKON";
            point = new System.Drawing.Point(0, 0);
            this.label1PLANOJIDORGJED.Location = point;
            this.label1PLANOJIDORGJED.Name = "label1PLANOJIDORGJED";
            this.label1PLANOJIDORGJED.TabIndex = 1;
            this.label1PLANOJIDORGJED.Tag = "labelPLANOJIDORGJED";
            this.label1PLANOJIDORGJED.Text = "Šifra OJ:";
            this.label1PLANOJIDORGJED.StyleSetName = "FieldUltraLabel";
            this.label1PLANOJIDORGJED.AutoSize = true;
            this.label1PLANOJIDORGJED.Anchor = AnchorStyles.Left;
            this.label1PLANOJIDORGJED.Appearance.TextVAlign = VAlign.Middle;
            this.label1PLANOJIDORGJED.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1PLANOJIDORGJED.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1PLANOJIDORGJED.ImageSize = size;
            this.label1PLANOJIDORGJED.Appearance.ForeColor = Color.Black;
            this.label1PLANOJIDORGJED.BackColor = Color.Transparent;
            this.layoutManagerformPLANORG.Controls.Add(this.label1PLANOJIDORGJED, 0, 0);
            this.layoutManagerformPLANORG.SetColumnSpan(this.label1PLANOJIDORGJED, 1);
            this.layoutManagerformPLANORG.SetRowSpan(this.label1PLANOJIDORGJED, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1PLANOJIDORGJED.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PLANOJIDORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x40, 0x17);
            this.label1PLANOJIDORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboPLANOJIDORGJED.Location = point;
            this.comboPLANOJIDORGJED.Name = "comboPLANOJIDORGJED";
            this.comboPLANOJIDORGJED.Tag = "PLANOJIDORGJED";
            this.comboPLANOJIDORGJED.TabIndex = 0;
            this.comboPLANOJIDORGJED.Anchor = AnchorStyles.Left;
            this.comboPLANOJIDORGJED.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboPLANOJIDORGJED.DropDownStyle = DropDownStyle.DropDown;
            this.comboPLANOJIDORGJED.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboPLANOJIDORGJED.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboPLANOJIDORGJED.Enabled = true;
            this.comboPLANOJIDORGJED.DataBindings.Add(new Binding("Value", this.bindingSourcePLANORG, "PLANOJIDORGJED"));
            this.comboPLANOJIDORGJED.ShowPictureBox = true;
            this.comboPLANOJIDORGJED.PictureBoxClicked += new EventHandler(this.PictureBoxClickedPLANOJIDORGJED);
            this.comboPLANOJIDORGJED.ValueMember = "IDORGJED";
            this.comboPLANOJIDORGJED.SelectionChanged += new EventHandler(this.SelectedIndexChangedPLANOJIDORGJED);
            this.layoutManagerformPLANORG.Controls.Add(this.comboPLANOJIDORGJED, 1, 0);
            this.layoutManagerformPLANORG.SetColumnSpan(this.comboPLANOJIDORGJED, 1);
            this.layoutManagerformPLANORG.SetRowSpan(this.comboPLANOJIDORGJED, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboPLANOJIDORGJED.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboPLANOJIDORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboPLANOJIDORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PLANOJNAZIVORGJED.Location = point;
            this.label1PLANOJNAZIVORGJED.Name = "label1PLANOJNAZIVORGJED";
            this.label1PLANOJNAZIVORGJED.TabIndex = 1;
            this.label1PLANOJNAZIVORGJED.Tag = "labelPLANOJNAZIVORGJED";
            this.label1PLANOJNAZIVORGJED.Text = "Naziv OJ:";
            this.label1PLANOJNAZIVORGJED.StyleSetName = "FieldUltraLabel";
            this.label1PLANOJNAZIVORGJED.AutoSize = true;
            this.label1PLANOJNAZIVORGJED.Anchor = AnchorStyles.Left;
            this.label1PLANOJNAZIVORGJED.Appearance.TextVAlign = VAlign.Middle;
            this.label1PLANOJNAZIVORGJED.Appearance.ForeColor = Color.Black;
            this.label1PLANOJNAZIVORGJED.BackColor = Color.Transparent;
            this.layoutManagerformPLANORG.Controls.Add(this.label1PLANOJNAZIVORGJED, 0, 1);
            this.layoutManagerformPLANORG.SetColumnSpan(this.label1PLANOJNAZIVORGJED, 1);
            this.layoutManagerformPLANORG.SetRowSpan(this.label1PLANOJNAZIVORGJED, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PLANOJNAZIVORGJED.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PLANOJNAZIVORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x49, 0x17);
            this.label1PLANOJNAZIVORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.labelPLANOJNAZIVORGJED.Location = point;
            this.labelPLANOJNAZIVORGJED.Name = "labelPLANOJNAZIVORGJED";
            this.labelPLANOJNAZIVORGJED.Tag = "PLANOJNAZIVORGJED";
            this.labelPLANOJNAZIVORGJED.TabIndex = 0;
            this.labelPLANOJNAZIVORGJED.Anchor = AnchorStyles.Left;
            this.labelPLANOJNAZIVORGJED.BackColor = Color.Transparent;
            this.labelPLANOJNAZIVORGJED.DataBindings.Add(new Binding("Text", this.bindingSourcePLANORG, "PLANOJNAZIVORGJED"));
            this.labelPLANOJNAZIVORGJED.Appearance.TextVAlign = VAlign.Middle;
            this.layoutManagerformPLANORG.Controls.Add(this.labelPLANOJNAZIVORGJED, 1, 1);
            this.layoutManagerformPLANORG.SetColumnSpan(this.labelPLANOJNAZIVORGJED, 1);
            this.layoutManagerformPLANORG.SetRowSpan(this.labelPLANOJNAZIVORGJED, 1);
            padding = new Padding(0, 1, 3, 2);
            this.labelPLANOJNAZIVORGJED.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelPLANOJNAZIVORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x240, 0x16);
            this.labelPLANOJNAZIVORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelPLANORGKON.Location = point;
            this.grdLevelPLANORGKON.Name = "grdLevelPLANORGKON";
            this.layoutManagerformPLANORG.Controls.Add(this.grdLevelPLANORGKON, 0, 2);
            this.layoutManagerformPLANORG.SetColumnSpan(this.grdLevelPLANORGKON, 2);
            this.layoutManagerformPLANORG.SetRowSpan(this.grdLevelPLANORGKON, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelPLANORGKON.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelPLANORGKON.MinimumSize = size;
            size = new System.Drawing.Size(0x113, 200);
            this.grdLevelPLANORGKON.Size = size;
            this.grdLevelPLANORGKON.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsPLANORGKON.Location = point;
            this.panelactionsPLANORGKON.Name = "panelactionsPLANORGKON";
            this.panelactionsPLANORGKON.BackColor = Color.Transparent;
            this.panelactionsPLANORGKON.Controls.Add(this.layoutManagerpanelactionsPLANORGKON);
            this.layoutManagerformPLANORG.Controls.Add(this.panelactionsPLANORGKON, 0, 3);
            this.layoutManagerformPLANORG.SetColumnSpan(this.panelactionsPLANORGKON, 2);
            this.layoutManagerformPLANORG.SetRowSpan(this.panelactionsPLANORGKON, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsPLANORGKON.Margin = padding;
            size = new System.Drawing.Size(0xf4, 0x19);
            this.panelactionsPLANORGKON.MinimumSize = size;
            size = new System.Drawing.Size(0xf4, 0x19);
            this.panelactionsPLANORGKON.Size = size;
            this.panelactionsPLANORGKON.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPLANORGKONAdd.Location = point;
            this.linkLabelPLANORGKONAdd.Name = "linkLabelPLANORGKONAdd";
            size = new System.Drawing.Size(0x3a, 15);
            this.linkLabelPLANORGKONAdd.Size = size;
            this.linkLabelPLANORGKONAdd.Text = " Add KON  ";
            this.linkLabelPLANORGKONAdd.Click += new EventHandler(this.PLANORGKONAdd_Click);
            this.linkLabelPLANORGKONAdd.BackColor = Color.Transparent;
            this.linkLabelPLANORGKONAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelPLANORGKONAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelPLANORGKONAdd.Cursor = Cursors.Hand;
            this.linkLabelPLANORGKONAdd.AutoSize = true;
            this.layoutManagerpanelactionsPLANORGKON.Controls.Add(this.linkLabelPLANORGKONAdd, 0, 0);
            this.layoutManagerpanelactionsPLANORGKON.SetColumnSpan(this.linkLabelPLANORGKONAdd, 1);
            this.layoutManagerpanelactionsPLANORGKON.SetRowSpan(this.linkLabelPLANORGKONAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPLANORGKONAdd.Margin = padding;
            size = new System.Drawing.Size(0x3a, 15);
            this.linkLabelPLANORGKONAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x3a, 15);
            this.linkLabelPLANORGKONAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPLANORGKONUpdate.Location = point;
            this.linkLabelPLANORGKONUpdate.Name = "linkLabelPLANORGKONUpdate";
            size = new System.Drawing.Size(0x4b, 15);
            this.linkLabelPLANORGKONUpdate.Size = size;
            this.linkLabelPLANORGKONUpdate.Text = " Update KON  ";
            this.linkLabelPLANORGKONUpdate.Click += new EventHandler(this.PLANORGKONUpdate_Click);
            this.linkLabelPLANORGKONUpdate.BackColor = Color.Transparent;
            this.linkLabelPLANORGKONUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelPLANORGKONUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelPLANORGKONUpdate.Cursor = Cursors.Hand;
            this.linkLabelPLANORGKONUpdate.AutoSize = true;
            this.layoutManagerpanelactionsPLANORGKON.Controls.Add(this.linkLabelPLANORGKONUpdate, 1, 0);
            this.layoutManagerpanelactionsPLANORGKON.SetColumnSpan(this.linkLabelPLANORGKONUpdate, 1);
            this.layoutManagerpanelactionsPLANORGKON.SetRowSpan(this.linkLabelPLANORGKONUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPLANORGKONUpdate.Margin = padding;
            size = new System.Drawing.Size(0x4b, 15);
            this.linkLabelPLANORGKONUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x4b, 15);
            this.linkLabelPLANORGKONUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPLANORGKONDelete.Location = point;
            this.linkLabelPLANORGKONDelete.Name = "linkLabelPLANORGKONDelete";
            size = new System.Drawing.Size(0x47, 15);
            this.linkLabelPLANORGKONDelete.Size = size;
            this.linkLabelPLANORGKONDelete.Text = " Delete KON  ";
            this.linkLabelPLANORGKONDelete.Click += new EventHandler(this.PLANORGKONDelete_Click);
            this.linkLabelPLANORGKONDelete.BackColor = Color.Transparent;
            this.linkLabelPLANORGKONDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelPLANORGKONDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelPLANORGKONDelete.Cursor = Cursors.Hand;
            this.linkLabelPLANORGKONDelete.AutoSize = true;
            this.layoutManagerpanelactionsPLANORGKON.Controls.Add(this.linkLabelPLANORGKONDelete, 2, 0);
            this.layoutManagerpanelactionsPLANORGKON.SetColumnSpan(this.linkLabelPLANORGKONDelete, 1);
            this.layoutManagerpanelactionsPLANORGKON.SetRowSpan(this.linkLabelPLANORGKONDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPLANORGKONDelete.Margin = padding;
            size = new System.Drawing.Size(0x47, 15);
            this.linkLabelPLANORGKONDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x47, 15);
            this.linkLabelPLANORGKONDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPLANORGKON.Location = point;
            this.linkLabelPLANORGKON.Name = "linkLabelPLANORGKON";
            this.layoutManagerpanelactionsPLANORGKON.Controls.Add(this.linkLabelPLANORGKON, 3, 0);
            this.layoutManagerpanelactionsPLANORGKON.SetColumnSpan(this.linkLabelPLANORGKON, 1);
            this.layoutManagerpanelactionsPLANORGKON.SetRowSpan(this.linkLabelPLANORGKON, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPLANORGKON.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelPLANORGKON.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelPLANORGKON.Size = size;
            this.linkLabelPLANORGKON.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformPLANORG);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourcePLANORG;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.Disabled;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.PLANIDPLANDescription;
            column.Width = 0x3a;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            column.Hidden = true;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.Disabled;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.PLANPLANGODINAIDGODINEDescription;
            column2.Width = 0x48;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            column2.Hidden = true;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.Disabled;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.PLANPLANOJIDORGJEDDescription;
            column6.Width = 0x48;
            column6.Format = "";
            column6.CellAppearance = appearance5;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.PLANPLANKONTOIDKONTODescription;
            column4.Width = 0x72;
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
            column5.Tag = "KONTOPLANKONTOIDKONTOAddNew";
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.PLANPLANIRANIIZNOSDescription;
            column3.Width = 0x74;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 3;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 4;
            this.grdLevelPLANORGKON.Visible = true;
            this.grdLevelPLANORGKON.Name = "grdLevelPLANORGKON";
            this.grdLevelPLANORGKON.Tag = "PLANORGKON";
            this.grdLevelPLANORGKON.TabIndex = 10;
            this.grdLevelPLANORGKON.Dock = DockStyle.Fill;
            this.grdLevelPLANORGKON.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelPLANORGKON.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelPLANORGKON.DataSource = this.bindingSourcePLANORGKON;
            this.grdLevelPLANORGKON.Enter += new EventHandler(this.grdLevelPLANORGKON_Enter);
            this.grdLevelPLANORGKON.AfterRowInsert += new RowEventHandler(this.grdLevelPLANORGKON_AfterRowInsert);
            this.grdLevelPLANORGKON.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelPLANORGKON.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelPLANORGKON.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelPLANORGKON.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelPLANORGKON_DoubleClick);
            this.grdLevelPLANORGKON.AfterRowActivate += new EventHandler(this.grdLevelPLANORGKON_AfterRowActivate);
            this.grdLevelPLANORGKON.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelPLANORGKON.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelPLANORGKON.DisplayLayout.BandsSerializer.Add(band);
            this.Name = "PLANFormPLANORGUserControl";
            this.Text = " ORG";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.PLANFormUserControl_Load);
            this.layoutManagerformPLANORG.ResumeLayout(false);
            this.layoutManagerformPLANORG.PerformLayout();
            ((ISupportInitialize) this.bindingSourcePLANORG).EndInit();
            ((ISupportInitialize) this.bindingSourcePLANORGKON).EndInit();
            ((ISupportInitialize) this.grdLevelPLANORGKON).EndInit();
            this.panelactionsPLANORGKON.ResumeLayout(true);
            this.panelactionsPLANORGKON.PerformLayout();
            this.layoutManagerpanelactionsPLANORGKON.ResumeLayout(false);
            this.layoutManagerpanelactionsPLANORGKON.PerformLayout();
            this.dsPLANDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.PLANController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourcePLANORG, this.PLANController.WorkItem, this))
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
            this.label1PLANOJIDORGJED.Text = StringResources.PLANPLANOJIDORGJEDDescription;
            this.label1PLANOJNAZIVORGJED.Text = StringResources.PLANPLANOJNAZIVORGJEDDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedInLinesPLANKONTOIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedPLANOJIDORGJED(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ORGJED", null, DeklaritMode.Insert));
            }
        }

        private void PLANFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.PLANPLANORGLevelDescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelPLANORGKONAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.PLANPLANORGKONLevelDescription;
            this.linkLabelPLANORGKONUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.PLANPLANORGKONLevelDescription;
            this.linkLabelPLANORGKONDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.PLANPLANORGKONLevelDescription;
        }

        private void PLANORGKONAdd_Click(object sender, EventArgs e)
        {
            this.EndEditCurrentRow();
            UltraGridRow activeRow = this.grdLevelPLANORGKON.ActiveRow;
            this.PLANORGKONInsert();
        }

        private void PLANORGKONDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelPLANORGKON);
            if ((currentRowListIndex != -1) && (this.grdLevelPLANORGKON.Selected.Rows.Count > 0))
            {
                this.grdLevelPLANORGKON.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelPLANORGKON).Selected = true;
                this.grdLevelPLANORGKON.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void PLANORGKONInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourcePLANORG, this.PLANController.WorkItem, this))
            {
                this.PLANController.AddPLANORGKON(this.m_CurrentRow);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void PLANORGKONPLANKONTOIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.grdLevelPLANORGKON, "KONTOPLANKONTOIDKONTO", enumList, "IDKONTO", "KONT", true);
        }

        private void PLANORGKONUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelPLANORGKON) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelPLANORGKON);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.PLANController.UpdatePLANORGKON(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void PLANORGKONUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelPLANORGKON.ActiveRow != null)
            {
                this.PLANORGKONUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.PLANController.WorkItem.Items.Contains("PLANORG|PLANORG"))
            {
                this.PLANController.WorkItem.Items.Add(this.bindingSourcePLANORG, "PLANORG|PLANORG");
            }
            if (!this.PLANController.WorkItem.Items.Contains("PLANORG|PLANORGKON"))
            {
                this.PLANController.WorkItem.Items.Add(this.bindingSourcePLANORGKON, "PLANORG|PLANORGKON");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        [LocalCommandHandler("PLANORGSaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SelectedIndexChangedPLANOJIDORGJED(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboPLANOJIDORGJED.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboPLANOJIDORGJED.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourcePLANORG.Current).Row["PLANOJIDORGJED"] = RuntimeHelpers.GetObjectValue(row["IDORGJED"]);
                    ((DataRowView) this.bindingSourcePLANORG.Current).Row["PLANOJNAZIVORGJED"] = RuntimeHelpers.GetObjectValue(row["NAZIVORGJED"]);
                    this.bindingSourcePLANORG.ResetCurrentItem();
                }
            }
        }

        private void SetComboBoxColumnProperties()
        {
            DataSet dataSet = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.grdLevelPLANORGKON, "KONTOPLANKONTOIDKONTO", enumList, "IDKONTO", "KONT", false);
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelPLANORGKON, "PLANKONTOIDKONTO");
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            gridColumn.ValueList = this.grdLevelPLANORGKON.DisplayLayout.ValueLists["KONTOPLANKONTOIDKONTO"];
            gridColumn.Width = 370;
            this.grdLevelPLANORGKON.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelPLANORGKON.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.comboPLANOJIDORGJED.Focus();
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

        private void UpdateValuesPLANKONTOIDKONTO(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["PLANKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(result["IDKONTO"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                }
            }
        }

        protected virtual ORGJEDComboBox comboPLANOJIDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboPLANOJIDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboPLANOJIDORGJED = value;
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

        protected virtual UltraGrid grdLevelPLANORGKON
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelPLANORGKON;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelPLANORGKON = value;
            }
        }

        protected virtual UltraLabel label1PLANOJIDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PLANOJIDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PLANOJIDORGJED = value;
            }
        }

        protected virtual UltraLabel label1PLANOJNAZIVORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PLANOJNAZIVORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PLANOJNAZIVORGJED = value;
            }
        }

        protected virtual UltraLabel labelPLANOJNAZIVORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._labelPLANOJNAZIVORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._labelPLANOJNAZIVORGJED = value;
            }
        }

        protected virtual UltraLabel linkLabelPLANORGKON
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPLANORGKON;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPLANORGKON = value;
            }
        }

        protected virtual UltraLabel linkLabelPLANORGKONAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPLANORGKONAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPLANORGKONAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelPLANORGKONDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPLANORGKONDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPLANORGKONDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelPLANORGKONUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPLANORGKONUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPLANORGKONUpdate = value;
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

        protected virtual Panel panelactionsPLANORGKON
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsPLANORGKON;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsPLANORGKON = value;
            }
        }

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.PLANController PLANController { get; set; }

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

