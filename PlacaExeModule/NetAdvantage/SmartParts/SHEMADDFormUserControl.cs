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
    public class SHEMADDFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboSHEMADDOJIDORGJED")]
        private ORGJEDComboBox _comboSHEMADDOJIDORGJED;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelSHEMADDSHEMADDDOPRINOS")]
        private UltraGrid _grdLevelSHEMADDSHEMADDDOPRINOS;
        [AccessedThroughProperty("grdLevelSHEMADDSHEMADDSTANDARD")]
        private UltraGrid _grdLevelSHEMADDSHEMADDSTANDARD;
        [AccessedThroughProperty("label1IDSHEMADD")]
        private UltraLabel _label1IDSHEMADD;
        [AccessedThroughProperty("label1NAZIVSHEMADD")]
        private UltraLabel _label1NAZIVSHEMADD;
        [AccessedThroughProperty("label1SHEMADDOJIDORGJED")]
        private UltraLabel _label1SHEMADDOJIDORGJED;
        [AccessedThroughProperty("linkLabelSHEMADDSHEMADDDOPRINOS")]
        private UltraLabel _linkLabelSHEMADDSHEMADDDOPRINOS;
        [AccessedThroughProperty("linkLabelSHEMADDSHEMADDDOPRINOSAdd")]
        private UltraLabel _linkLabelSHEMADDSHEMADDDOPRINOSAdd;
        [AccessedThroughProperty("linkLabelSHEMADDSHEMADDDOPRINOSDelete")]
        private UltraLabel _linkLabelSHEMADDSHEMADDDOPRINOSDelete;
        [AccessedThroughProperty("linkLabelSHEMADDSHEMADDDOPRINOSUpdate")]
        private UltraLabel _linkLabelSHEMADDSHEMADDDOPRINOSUpdate;
        [AccessedThroughProperty("linkLabelSHEMADDSHEMADDSTANDARD")]
        private UltraLabel _linkLabelSHEMADDSHEMADDSTANDARD;
        [AccessedThroughProperty("linkLabelSHEMADDSHEMADDSTANDARDAdd")]
        private UltraLabel _linkLabelSHEMADDSHEMADDSTANDARDAdd;
        [AccessedThroughProperty("linkLabelSHEMADDSHEMADDSTANDARDDelete")]
        private UltraLabel _linkLabelSHEMADDSHEMADDSTANDARDDelete;
        [AccessedThroughProperty("linkLabelSHEMADDSHEMADDSTANDARDUpdate")]
        private UltraLabel _linkLabelSHEMADDSHEMADDSTANDARDUpdate;
        [AccessedThroughProperty("panelactionsSHEMADDSHEMADDDOPRINOS")]
        private Panel _panelactionsSHEMADDSHEMADDDOPRINOS;
        [AccessedThroughProperty("panelactionsSHEMADDSHEMADDSTANDARD")]
        private Panel _panelactionsSHEMADDSHEMADDSTANDARD;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("Tab1")]
        private UltraTabControl _Tab1;
        [AccessedThroughProperty("TabPage1")]
        private UltraTabPageControl _TabPage1;
        [AccessedThroughProperty("TabPage2")]
        private UltraTabPageControl _TabPage2;
        [AccessedThroughProperty("textIDSHEMADD")]
        private UltraNumericEditor _textIDSHEMADD;
        [AccessedThroughProperty("textNAZIVSHEMADD")]
        private UltraTextEditor _textNAZIVSHEMADD;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSHEMADD;
        private BindingSource bindingSourceSHEMADDSHEMADDDOPRINOS;
        private BindingSource bindingSourceSHEMADDSHEMADDSTANDARD;
        private IContainer components = null;
        private SHEMADDDataSet dsSHEMADDDataSet1;
        protected TableLayoutPanel layoutManagerformSHEMADD;
        protected TableLayoutPanel layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS;
        protected TableLayoutPanel layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD;
        protected TableLayoutPanel layoutManagerTabPage1;
        protected TableLayoutPanel layoutManagerTabPage2;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SHEMADDDataSet.SHEMADDRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SHEMADD";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.SHEMADDDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public SHEMADDFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsSHEMADDDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceSHEMADD.DataSource = this.SHEMADDController.DataSet;
            this.dsSHEMADDDataSet1 = this.SHEMADDController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ORGJED", Thread=ThreadOption.UserInterface)]
        public void comboSHEMADDOJIDORGJED_Add(object sender, ComponentEventArgs e)
        {
            this.comboSHEMADDOJIDORGJED.Fill();
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
                    enumerator = this.dsSHEMADDDataSet1.SHEMADD.Rows.GetEnumerator();
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
                if (this.SHEMADDController.Update(this))
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
                    case "KONTOKONTODOPIDKONTOAddNew":
                        this.PictureBoxClickedInLinesKONTODOPIDKONTO(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "MJESTOTROSKAMTDOPIDMJESTOTROSKAAddNew":
                        this.PictureBoxClickedInLinesMTDOPIDMJESTOTROSKA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "STRANEKNJIZENJASTRANEDOPIDSTRANEKNJIZENJAAddNew":
                        this.PictureBoxClickedInLinesSTRANEDOPIDSTRANEKNJIZENJA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "KONTOKONTODDVRSTAIZNOSAIDKONTOAddNew":
                        this.PictureBoxClickedInLinesKONTODDVRSTAIZNOSAIDKONTO(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "MJESTOTROSKAMTDDVRSTAIZNOSAIDMJESTOTROSKAAddNew":
                        this.PictureBoxClickedInLinesMTDDVRSTAIZNOSAIDMJESTOTROSKA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "STRANEKNJIZENJASTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJAAddNew":
                        this.PictureBoxClickedInLinesSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA(RuntimeHelpers.GetObjectValue(sender), e);
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
            if (this.grdLevelSHEMADDSHEMADDDOPRINOS.ActiveRow != null)
            {
                this.grdLevelSHEMADDSHEMADDDOPRINOS.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelSHEMADDSHEMADDSTANDARD.ActiveRow != null)
            {
                this.grdLevelSHEMADDSHEMADDSTANDARD.PerformAction(UltraGridAction.NextRow);
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
                if (e.Cell.Column.Key == "KONTODOPIDKONTO")
                {
                    this.UpdateValuesKONTODOPIDKONTO(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "MTDOPIDMJESTOTROSKA")
                {
                    this.UpdateValuesMTDOPIDMJESTOTROSKA(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "STRANEDOPIDSTRANEKNJIZENJA")
                {
                    this.UpdateValuesSTRANEDOPIDSTRANEKNJIZENJA(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "KONTODDVRSTAIZNOSAIDKONTO")
                {
                    this.UpdateValuesKONTODDVRSTAIZNOSAIDKONTO(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "MTDDVRSTAIZNOSAIDMJESTOTROSKA")
                {
                    this.UpdateValuesMTDDVRSTAIZNOSAIDMJESTOTROSKA(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA")
                {
                    this.UpdateValuesSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
            }
        }

        private void grdLevelSHEMADDSHEMADDDOPRINOS_AfterRowActivate(object sender, EventArgs e)
        {
            string sHEMADDSHEMADDSHEMADDDOPRINOSLevelDescription = StringResources.SHEMADDSHEMADDSHEMADDDOPRINOSLevelDescription;
            UltraGridRow activeRow = this.grdLevelSHEMADDSHEMADDDOPRINOS.ActiveRow;
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd.Text = Deklarit.Resources.Resources.Add + " " + sHEMADDSHEMADDSHEMADDDOPRINOSLevelDescription;
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate.Text = Deklarit.Resources.Resources.Update + " " + sHEMADDSHEMADDSHEMADDDOPRINOSLevelDescription;
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete.Text = Deklarit.Resources.Resources.Delete + " " + sHEMADDSHEMADDSHEMADDDOPRINOSLevelDescription;
        }

        private void grdLevelSHEMADDSHEMADDDOPRINOS_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceSHEMADD.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceSHEMADD.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelSHEMADDSHEMADDDOPRINOS_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.SHEMADDSHEMADDDOPRINOSUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelSHEMADDSHEMADDDOPRINOS_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMADD, this.SHEMADDController.WorkItem, this);
        }

        private void grdLevelSHEMADDSHEMADDSTANDARD_AfterRowActivate(object sender, EventArgs e)
        {
            string sHEMADDSHEMADDSHEMADDSTANDARDLevelDescription = StringResources.SHEMADDSHEMADDSHEMADDSTANDARDLevelDescription;
            UltraGridRow activeRow = this.grdLevelSHEMADDSHEMADDSTANDARD.ActiveRow;
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd.Text = Deklarit.Resources.Resources.Add + " " + sHEMADDSHEMADDSHEMADDSTANDARDLevelDescription;
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate.Text = Deklarit.Resources.Resources.Update + " " + sHEMADDSHEMADDSHEMADDSTANDARDLevelDescription;
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete.Text = Deklarit.Resources.Resources.Delete + " " + sHEMADDSHEMADDSHEMADDSTANDARDLevelDescription;
        }

        private void grdLevelSHEMADDSHEMADDSTANDARD_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceSHEMADD.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceSHEMADD.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelSHEMADDSHEMADDSTANDARD_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.SHEMADDSHEMADDSTANDARDUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelSHEMADDSHEMADDSTANDARD_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMADD, this.SHEMADDController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SHEMADD", this.m_Mode, this.dsSHEMADDDataSet1, this.dsSHEMADDDataSet1.SHEMADD.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            if (!this.m_DataGrids.Contains(this.grdLevelSHEMADDSHEMADDDOPRINOS))
            {
                this.m_DataGrids.Add(this.grdLevelSHEMADDSHEMADDDOPRINOS);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelSHEMADDSHEMADDSTANDARD))
            {
                this.m_DataGrids.Add(this.grdLevelSHEMADDSHEMADDSTANDARD);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsSHEMADDDataSet1.SHEMADD[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (SHEMADDDataSet.SHEMADDRow) ((DataRowView) this.bindingSourceSHEMADD.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(SHEMADDFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSHEMADD = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMADD).BeginInit();
            this.bindingSourceSHEMADDSHEMADDDOPRINOS = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMADDSHEMADDDOPRINOS).BeginInit();
            this.bindingSourceSHEMADDSHEMADDSTANDARD = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMADDSHEMADDSTANDARD).BeginInit();
            this.layoutManagerformSHEMADD = new TableLayoutPanel();
            this.layoutManagerformSHEMADD.SuspendLayout();
            this.layoutManagerformSHEMADD.AutoSize = true;
            this.layoutManagerformSHEMADD.Dock = DockStyle.Fill;
            this.layoutManagerformSHEMADD.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSHEMADD.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSHEMADD.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSHEMADD.Size = size;
            this.layoutManagerformSHEMADD.ColumnCount = 2;
            this.layoutManagerformSHEMADD.RowCount = 4;
            this.layoutManagerformSHEMADD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMADD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMADD.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMADD.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMADD.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMADD.RowStyles.Add(new RowStyle());
            this.label1IDSHEMADD = new UltraLabel();
            this.textIDSHEMADD = new UltraNumericEditor();
            this.label1NAZIVSHEMADD = new UltraLabel();
            this.textNAZIVSHEMADD = new UltraTextEditor();
            this.label1SHEMADDOJIDORGJED = new UltraLabel();
            this.comboSHEMADDOJIDORGJED = new ORGJEDComboBox();
            this.Tab1 = new UltraTabControl();
            UltraTab tab = new UltraTab();
            this.TabPage1 = new UltraTabPageControl();
            this.layoutManagerTabPage1 = new TableLayoutPanel();
            this.layoutManagerTabPage1.AutoSize = true;
            this.layoutManagerTabPage1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage1.ColumnCount = 1;
            this.layoutManagerTabPage1.RowCount = 2;
            this.layoutManagerTabPage1.Dock = DockStyle.Fill;
            this.layoutManagerTabPage1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage1.RowStyles.Add(new RowStyle());
            Padding padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage1.Margin = padding;
            this.grdLevelSHEMADDSHEMADDDOPRINOS = new UltraGrid();
            this.panelactionsSHEMADDSHEMADDDOPRINOS = new Panel();
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS = new TableLayoutPanel();
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.AutoSize = true;
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.ColumnCount = 4;
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.RowCount = 1;
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.RowStyles.Add(new RowStyle());
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd = new UltraLabel();
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate = new UltraLabel();
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete = new UltraLabel();
            this.linkLabelSHEMADDSHEMADDDOPRINOS = new UltraLabel();
            UltraTab tab2 = new UltraTab();
            this.TabPage2 = new UltraTabPageControl();
            this.layoutManagerTabPage2 = new TableLayoutPanel();
            this.layoutManagerTabPage2.AutoSize = true;
            this.layoutManagerTabPage2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage2.ColumnCount = 1;
            this.layoutManagerTabPage2.RowCount = 2;
            this.layoutManagerTabPage2.Dock = DockStyle.Fill;
            this.layoutManagerTabPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage2.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage2.Margin = padding;
            this.grdLevelSHEMADDSHEMADDSTANDARD = new UltraGrid();
            this.panelactionsSHEMADDSHEMADDSTANDARD = new Panel();
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD = new TableLayoutPanel();
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.AutoSize = true;
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.ColumnCount = 4;
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.RowCount = 1;
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.RowStyles.Add(new RowStyle());
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd = new UltraLabel();
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate = new UltraLabel();
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete = new UltraLabel();
            this.linkLabelSHEMADDSHEMADDSTANDARD = new UltraLabel();
            ((ISupportInitialize) this.textIDSHEMADD).BeginInit();
            ((ISupportInitialize) this.textNAZIVSHEMADD).BeginInit();
            this.Tab1.SuspendLayout();
            ((ISupportInitialize) this.Tab1).BeginInit();
            this.layoutManagerTabPage1.SuspendLayout();
            ((ISupportInitialize) this.grdLevelSHEMADDSHEMADDDOPRINOS).BeginInit();
            this.panelactionsSHEMADDSHEMADDDOPRINOS.SuspendLayout();
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.SuspendLayout();
            this.layoutManagerTabPage2.SuspendLayout();
            ((ISupportInitialize) this.grdLevelSHEMADDSHEMADDSTANDARD).BeginInit();
            this.panelactionsSHEMADDSHEMADDSTANDARD.SuspendLayout();
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.SuspendLayout();
            UltraGridBand band = new UltraGridBand("SHEMADDSHEMADDDOPRINOS", -1);
            UltraGridColumn column = new UltraGridColumn("IDSHEMADD");
            UltraGridColumn column6 = new UltraGridColumn("SHEMADDDOPRINOSIDDOPRINOS");
            UltraGridColumn column2 = new UltraGridColumn("KONTODOPIDKONTO");
            UltraGridColumn column3 = new UltraGridColumn("columnKONTODOPIDKONTOAddNew", 0);
            UltraGridColumn column4 = new UltraGridColumn("MTDOPIDMJESTOTROSKA");
            UltraGridColumn column5 = new UltraGridColumn("columnMTDOPIDMJESTOTROSKAAddNew", 1);
            UltraGridColumn column8 = new UltraGridColumn("STRANEDOPIDSTRANEKNJIZENJA");
            UltraGridColumn column9 = new UltraGridColumn("columnSTRANEDOPIDSTRANEKNJIZENJAAddNew", 2);
            UltraGridColumn column7 = new UltraGridColumn("SHEMADDDOPRINOSNAZIVDOPRINOS");
            UltraGridBand band2 = new UltraGridBand("SHEMADDSHEMADDSTANDARD", -1);
            UltraGridColumn column11 = new UltraGridColumn("IDSHEMADD");
            UltraGridColumn column17 = new UltraGridColumn("SHEMADDSTANDARDID");
            UltraGridColumn column10 = new UltraGridColumn("IDDDVRSTEIZNOSA");
            UltraGridColumn column12 = new UltraGridColumn("KONTODDVRSTAIZNOSAIDKONTO");
            UltraGridColumn column13 = new UltraGridColumn("columnKONTODDVRSTAIZNOSAIDKONTOAddNew", 0);
            UltraGridColumn column14 = new UltraGridColumn("MTDDVRSTAIZNOSAIDMJESTOTROSKA");
            UltraGridColumn column15 = new UltraGridColumn("columnMTDDVRSTAIZNOSAIDMJESTOTROSKAAddNew", 1);
            UltraGridColumn column18 = new UltraGridColumn("STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA");
            UltraGridColumn column19 = new UltraGridColumn("columnSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJAAddNew", 2);
            UltraGridColumn column16 = new UltraGridColumn("NAZIVDDVRSTEIZNOSA");
            this.dsSHEMADDDataSet1 = new SHEMADDDataSet();
            this.dsSHEMADDDataSet1.BeginInit();
            this.SuspendLayout();
            this.Tab1.Tabs.Add(tab);
            this.Tab1.Controls.Add(this.TabPage1);
            this.Tab1.Tabs.Add(tab2);
            this.Tab1.Controls.Add(this.TabPage2);
            this.dsSHEMADDDataSet1.DataSetName = "dsSHEMADD";
            this.dsSHEMADDDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSHEMADD.DataSource = this.dsSHEMADDDataSet1;
            this.bindingSourceSHEMADD.DataMember = "SHEMADD";
            ((ISupportInitialize) this.bindingSourceSHEMADD).BeginInit();
            this.bindingSourceSHEMADDSHEMADDDOPRINOS.DataSource = this.bindingSourceSHEMADD;
            this.bindingSourceSHEMADDSHEMADDDOPRINOS.DataMember = "SHEMADD_SHEMADDSHEMADDDOPRINOS";
            this.bindingSourceSHEMADDSHEMADDSTANDARD.DataSource = this.bindingSourceSHEMADD;
            this.bindingSourceSHEMADDSHEMADDSTANDARD.DataMember = "SHEMADD_SHEMADDSHEMADDSTANDARD";
            point = new System.Drawing.Point(0, 0);
            this.label1IDSHEMADD.Location = point;
            this.label1IDSHEMADD.Name = "label1IDSHEMADD";
            this.label1IDSHEMADD.TabIndex = 1;
            this.label1IDSHEMADD.Tag = "labelIDSHEMADD";
            this.label1IDSHEMADD.Text = "Šifra:";
            this.label1IDSHEMADD.StyleSetName = "FieldUltraLabel";
            this.label1IDSHEMADD.AutoSize = true;
            this.label1IDSHEMADD.Anchor = AnchorStyles.Left;
            this.label1IDSHEMADD.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDSHEMADD.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDSHEMADD.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDSHEMADD.ImageSize = size;
            this.label1IDSHEMADD.Appearance.ForeColor = Color.Black;
            this.label1IDSHEMADD.BackColor = Color.Transparent;
            this.layoutManagerformSHEMADD.Controls.Add(this.label1IDSHEMADD, 0, 0);
            this.layoutManagerformSHEMADD.SetColumnSpan(this.label1IDSHEMADD, 1);
            this.layoutManagerformSHEMADD.SetRowSpan(this.label1IDSHEMADD, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDSHEMADD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDSHEMADD.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDSHEMADD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDSHEMADD.Location = point;
            this.textIDSHEMADD.Name = "textIDSHEMADD";
            this.textIDSHEMADD.Tag = "IDSHEMADD";
            this.textIDSHEMADD.TabIndex = 0;
            this.textIDSHEMADD.Anchor = AnchorStyles.Left;
            this.textIDSHEMADD.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDSHEMADD.ReadOnly = false;
            this.textIDSHEMADD.PromptChar = ' ';
            this.textIDSHEMADD.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDSHEMADD.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMADD, "IDSHEMADD"));
            this.textIDSHEMADD.NumericType = NumericType.Integer;
            this.textIDSHEMADD.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformSHEMADD.Controls.Add(this.textIDSHEMADD, 1, 0);
            this.layoutManagerformSHEMADD.SetColumnSpan(this.textIDSHEMADD, 1);
            this.layoutManagerformSHEMADD.SetRowSpan(this.textIDSHEMADD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDSHEMADD.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSHEMADD.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSHEMADD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVSHEMADD.Location = point;
            this.label1NAZIVSHEMADD.Name = "label1NAZIVSHEMADD";
            this.label1NAZIVSHEMADD.TabIndex = 1;
            this.label1NAZIVSHEMADD.Tag = "labelNAZIVSHEMADD";
            this.label1NAZIVSHEMADD.Text = "Naziv:";
            this.label1NAZIVSHEMADD.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVSHEMADD.AutoSize = true;
            this.label1NAZIVSHEMADD.Anchor = AnchorStyles.Left;
            this.label1NAZIVSHEMADD.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVSHEMADD.Appearance.ForeColor = Color.Black;
            this.label1NAZIVSHEMADD.BackColor = Color.Transparent;
            this.layoutManagerformSHEMADD.Controls.Add(this.label1NAZIVSHEMADD, 0, 1);
            this.layoutManagerformSHEMADD.SetColumnSpan(this.label1NAZIVSHEMADD, 1);
            this.layoutManagerformSHEMADD.SetRowSpan(this.label1NAZIVSHEMADD, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVSHEMADD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVSHEMADD.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1NAZIVSHEMADD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVSHEMADD.Location = point;
            this.textNAZIVSHEMADD.Name = "textNAZIVSHEMADD";
            this.textNAZIVSHEMADD.Tag = "NAZIVSHEMADD";
            this.textNAZIVSHEMADD.TabIndex = 0;
            this.textNAZIVSHEMADD.Anchor = AnchorStyles.Left;
            this.textNAZIVSHEMADD.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVSHEMADD.ReadOnly = false;
            this.textNAZIVSHEMADD.DataBindings.Add(new Binding("Text", this.bindingSourceSHEMADD, "NAZIVSHEMADD"));
            this.textNAZIVSHEMADD.MaxLength = 50;
            this.layoutManagerformSHEMADD.Controls.Add(this.textNAZIVSHEMADD, 1, 1);
            this.layoutManagerformSHEMADD.SetColumnSpan(this.textNAZIVSHEMADD, 1);
            this.layoutManagerformSHEMADD.SetRowSpan(this.textNAZIVSHEMADD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVSHEMADD.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVSHEMADD.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVSHEMADD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMADDOJIDORGJED.Location = point;
            this.label1SHEMADDOJIDORGJED.Name = "label1SHEMADDOJIDORGJED";
            this.label1SHEMADDOJIDORGJED.TabIndex = 1;
            this.label1SHEMADDOJIDORGJED.Tag = "labelSHEMADDOJIDORGJED";
            this.label1SHEMADDOJIDORGJED.Text = "Šifra OJ:";
            this.label1SHEMADDOJIDORGJED.StyleSetName = "FieldUltraLabel";
            this.label1SHEMADDOJIDORGJED.AutoSize = true;
            this.label1SHEMADDOJIDORGJED.Anchor = AnchorStyles.Left;
            this.label1SHEMADDOJIDORGJED.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMADDOJIDORGJED.Appearance.ForeColor = Color.Black;
            this.label1SHEMADDOJIDORGJED.BackColor = Color.Transparent;
            this.layoutManagerformSHEMADD.Controls.Add(this.label1SHEMADDOJIDORGJED, 0, 2);
            this.layoutManagerformSHEMADD.SetColumnSpan(this.label1SHEMADDOJIDORGJED, 1);
            this.layoutManagerformSHEMADD.SetRowSpan(this.label1SHEMADDOJIDORGJED, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SHEMADDOJIDORGJED.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMADDOJIDORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x43, 0x17);
            this.label1SHEMADDOJIDORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSHEMADDOJIDORGJED.Location = point;
            this.comboSHEMADDOJIDORGJED.Name = "comboSHEMADDOJIDORGJED";
            this.comboSHEMADDOJIDORGJED.Tag = "SHEMADDOJIDORGJED";
            this.comboSHEMADDOJIDORGJED.TabIndex = 0;
            this.comboSHEMADDOJIDORGJED.Anchor = AnchorStyles.Left;
            this.comboSHEMADDOJIDORGJED.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSHEMADDOJIDORGJED.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMADDOJIDORGJED.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMADDOJIDORGJED.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSHEMADDOJIDORGJED.Enabled = true;
            this.comboSHEMADDOJIDORGJED.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMADD, "SHEMADDOJIDORGJED"));
            this.comboSHEMADDOJIDORGJED.ShowPictureBox = true;
            this.comboSHEMADDOJIDORGJED.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSHEMADDOJIDORGJED);
            this.comboSHEMADDOJIDORGJED.ValueMember = "IDORGJED";
            this.comboSHEMADDOJIDORGJED.SelectionChanged += new EventHandler(this.SelectedIndexChangedSHEMADDOJIDORGJED);
            this.layoutManagerformSHEMADD.Controls.Add(this.comboSHEMADDOJIDORGJED, 1, 2);
            this.layoutManagerformSHEMADD.SetColumnSpan(this.comboSHEMADDOJIDORGJED, 1);
            this.layoutManagerformSHEMADD.SetRowSpan(this.comboSHEMADDOJIDORGJED, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSHEMADDOJIDORGJED.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMADDOJIDORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMADDOJIDORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.Tab1.Location = point;
            this.Tab1.Name = "Tab1";
            this.layoutManagerformSHEMADD.Controls.Add(this.Tab1, 0, 3);
            this.layoutManagerformSHEMADD.SetColumnSpan(this.Tab1, 2);
            this.layoutManagerformSHEMADD.SetRowSpan(this.Tab1, 1);
            padding = new Padding(5, 11, 5, 5);
            this.Tab1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.Tab1.MinimumSize = size;
            this.Tab1.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.TabPage1.Location = point;
            this.TabPage1.Name = "TabPage1";
            tab.TabPage = this.TabPage1;
            tab.Text = "Kontiranje doprinosa";
            this.TabPage1.Controls.Add(this.layoutManagerTabPage1);
            point = new System.Drawing.Point(0, 0);
            this.grdLevelSHEMADDSHEMADDDOPRINOS.Location = point;
            this.grdLevelSHEMADDSHEMADDDOPRINOS.Name = "grdLevelSHEMADDSHEMADDDOPRINOS";
            this.layoutManagerTabPage1.Controls.Add(this.grdLevelSHEMADDSHEMADDDOPRINOS, 0, 0);
            this.layoutManagerTabPage1.SetColumnSpan(this.grdLevelSHEMADDSHEMADDDOPRINOS, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.grdLevelSHEMADDSHEMADDDOPRINOS, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelSHEMADDSHEMADDDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelSHEMADDSHEMADDDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x272, 200);
            this.grdLevelSHEMADDSHEMADDDOPRINOS.Size = size;
            this.grdLevelSHEMADDSHEMADDDOPRINOS.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsSHEMADDSHEMADDDOPRINOS.Location = point;
            this.panelactionsSHEMADDSHEMADDDOPRINOS.Name = "panelactionsSHEMADDSHEMADDDOPRINOS";
            this.panelactionsSHEMADDSHEMADDDOPRINOS.BackColor = Color.Transparent;
            this.panelactionsSHEMADDSHEMADDDOPRINOS.Controls.Add(this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS);
            this.layoutManagerTabPage1.Controls.Add(this.panelactionsSHEMADDSHEMADDDOPRINOS, 0, 1);
            this.layoutManagerTabPage1.SetColumnSpan(this.panelactionsSHEMADDSHEMADDDOPRINOS, 1);
            this.layoutManagerTabPage1.SetRowSpan(this.panelactionsSHEMADDSHEMADDDOPRINOS, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsSHEMADDSHEMADDDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0x144, 0x19);
            this.panelactionsSHEMADDSHEMADDDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0x144, 0x19);
            this.panelactionsSHEMADDSHEMADDDOPRINOS.Size = size;
            this.panelactionsSHEMADDSHEMADDDOPRINOS.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd.Location = point;
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd.Name = "linkLabelSHEMADDSHEMADDDOPRINOSAdd";
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd.Size = size;
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd.Text = " Add Doprinosi  ";
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd.Click += new EventHandler(this.SHEMADDSHEMADDDOPRINOSAdd_Click);
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd.BackColor = Color.Transparent;
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd.Cursor = Cursors.Hand;
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd.AutoSize = true;
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.Controls.Add(this.linkLabelSHEMADDSHEMADDDOPRINOSAdd, 0, 0);
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.SetColumnSpan(this.linkLabelSHEMADDSHEMADDDOPRINOSAdd, 1);
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.SetRowSpan(this.linkLabelSHEMADDSHEMADDDOPRINOSAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd.Margin = padding;
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate.Location = point;
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate.Name = "linkLabelSHEMADDSHEMADDDOPRINOSUpdate";
            size = new System.Drawing.Size(0x66, 15);
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate.Size = size;
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate.Text = " Update Doprinosi  ";
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate.Click += new EventHandler(this.SHEMADDSHEMADDDOPRINOSUpdate_Click);
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate.BackColor = Color.Transparent;
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate.Cursor = Cursors.Hand;
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate.AutoSize = true;
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.Controls.Add(this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate, 1, 0);
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.SetColumnSpan(this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate, 1);
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.SetRowSpan(this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate.Margin = padding;
            size = new System.Drawing.Size(0x66, 15);
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 15);
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete.Location = point;
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete.Name = "linkLabelSHEMADDSHEMADDDOPRINOSDelete";
            size = new System.Drawing.Size(0x62, 15);
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete.Size = size;
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete.Text = " Delete Doprinosi  ";
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete.Click += new EventHandler(this.SHEMADDSHEMADDDOPRINOSDelete_Click);
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete.BackColor = Color.Transparent;
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete.Cursor = Cursors.Hand;
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete.AutoSize = true;
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.Controls.Add(this.linkLabelSHEMADDSHEMADDDOPRINOSDelete, 2, 0);
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.SetColumnSpan(this.linkLabelSHEMADDSHEMADDDOPRINOSDelete, 1);
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.SetRowSpan(this.linkLabelSHEMADDSHEMADDDOPRINOSDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete.Margin = padding;
            size = new System.Drawing.Size(0x62, 15);
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x62, 15);
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMADDSHEMADDDOPRINOS.Location = point;
            this.linkLabelSHEMADDSHEMADDDOPRINOS.Name = "linkLabelSHEMADDSHEMADDDOPRINOS";
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.Controls.Add(this.linkLabelSHEMADDSHEMADDDOPRINOS, 3, 0);
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.SetColumnSpan(this.linkLabelSHEMADDSHEMADDDOPRINOS, 1);
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.SetRowSpan(this.linkLabelSHEMADDSHEMADDDOPRINOS, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMADDSHEMADDDOPRINOS.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSHEMADDSHEMADDDOPRINOS.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSHEMADDSHEMADDDOPRINOS.Size = size;
            this.linkLabelSHEMADDSHEMADDDOPRINOS.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.TabPage2.Location = point;
            this.TabPage2.Name = "TabPage2";
            tab2.TabPage = this.TabPage2;
            tab2.Text = "Kontiranje ostalih iznosa";
            this.TabPage2.Controls.Add(this.layoutManagerTabPage2);
            point = new System.Drawing.Point(0, 0);
            this.grdLevelSHEMADDSHEMADDSTANDARD.Location = point;
            this.grdLevelSHEMADDSHEMADDSTANDARD.Name = "grdLevelSHEMADDSHEMADDSTANDARD";
            this.layoutManagerTabPage2.Controls.Add(this.grdLevelSHEMADDSHEMADDSTANDARD, 0, 0);
            this.layoutManagerTabPage2.SetColumnSpan(this.grdLevelSHEMADDSHEMADDSTANDARD, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.grdLevelSHEMADDSHEMADDSTANDARD, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelSHEMADDSHEMADDSTANDARD.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelSHEMADDSHEMADDSTANDARD.MinimumSize = size;
            size = new System.Drawing.Size(0x272, 200);
            this.grdLevelSHEMADDSHEMADDSTANDARD.Size = size;
            this.grdLevelSHEMADDSHEMADDSTANDARD.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsSHEMADDSHEMADDSTANDARD.Location = point;
            this.panelactionsSHEMADDSHEMADDSTANDARD.Name = "panelactionsSHEMADDSHEMADDSTANDARD";
            this.panelactionsSHEMADDSHEMADDSTANDARD.BackColor = Color.Transparent;
            this.panelactionsSHEMADDSHEMADDSTANDARD.Controls.Add(this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD);
            this.layoutManagerTabPage2.Controls.Add(this.panelactionsSHEMADDSHEMADDSTANDARD, 0, 1);
            this.layoutManagerTabPage2.SetColumnSpan(this.panelactionsSHEMADDSHEMADDSTANDARD, 1);
            this.layoutManagerTabPage2.SetRowSpan(this.panelactionsSHEMADDSHEMADDSTANDARD, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsSHEMADDSHEMADDSTANDARD.Margin = padding;
            size = new System.Drawing.Size(0x20d, 0x19);
            this.panelactionsSHEMADDSHEMADDSTANDARD.MinimumSize = size;
            size = new System.Drawing.Size(0x20d, 0x19);
            this.panelactionsSHEMADDSHEMADDSTANDARD.Size = size;
            this.panelactionsSHEMADDSHEMADDSTANDARD.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd.Location = point;
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd.Name = "linkLabelSHEMADDSHEMADDSTANDARDAdd";
            size = new System.Drawing.Size(0x97, 15);
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd.Size = size;
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd.Text = " Add SHEMADDSTANDARD  ";
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd.Click += new EventHandler(this.SHEMADDSHEMADDSTANDARDAdd_Click);
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd.BackColor = Color.Transparent;
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd.Cursor = Cursors.Hand;
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd.AutoSize = true;
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.Controls.Add(this.linkLabelSHEMADDSHEMADDSTANDARDAdd, 0, 0);
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.SetColumnSpan(this.linkLabelSHEMADDSHEMADDSTANDARDAdd, 1);
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.SetRowSpan(this.linkLabelSHEMADDSHEMADDSTANDARDAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd.Margin = padding;
            size = new System.Drawing.Size(0x97, 15);
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x97, 15);
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate.Location = point;
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate.Name = "linkLabelSHEMADDSHEMADDSTANDARDUpdate";
            size = new System.Drawing.Size(0xa9, 15);
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate.Size = size;
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate.Text = " Update SHEMADDSTANDARD  ";
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate.Click += new EventHandler(this.SHEMADDSHEMADDSTANDARDUpdate_Click);
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate.BackColor = Color.Transparent;
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate.Cursor = Cursors.Hand;
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate.AutoSize = true;
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.Controls.Add(this.linkLabelSHEMADDSHEMADDSTANDARDUpdate, 1, 0);
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.SetColumnSpan(this.linkLabelSHEMADDSHEMADDSTANDARDUpdate, 1);
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.SetRowSpan(this.linkLabelSHEMADDSHEMADDSTANDARDUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate.Margin = padding;
            size = new System.Drawing.Size(0xa9, 15);
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0xa9, 15);
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete.Location = point;
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete.Name = "linkLabelSHEMADDSHEMADDSTANDARDDelete";
            size = new System.Drawing.Size(0xa5, 15);
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete.Size = size;
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete.Text = " Delete SHEMADDSTANDARD  ";
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete.Click += new EventHandler(this.SHEMADDSHEMADDSTANDARDDelete_Click);
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete.BackColor = Color.Transparent;
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete.Cursor = Cursors.Hand;
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete.AutoSize = true;
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.Controls.Add(this.linkLabelSHEMADDSHEMADDSTANDARDDelete, 2, 0);
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.SetColumnSpan(this.linkLabelSHEMADDSHEMADDSTANDARDDelete, 1);
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.SetRowSpan(this.linkLabelSHEMADDSHEMADDSTANDARDDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete.Margin = padding;
            size = new System.Drawing.Size(0xa5, 15);
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete.MinimumSize = size;
            size = new System.Drawing.Size(0xa5, 15);
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMADDSHEMADDSTANDARD.Location = point;
            this.linkLabelSHEMADDSHEMADDSTANDARD.Name = "linkLabelSHEMADDSHEMADDSTANDARD";
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.Controls.Add(this.linkLabelSHEMADDSHEMADDSTANDARD, 3, 0);
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.SetColumnSpan(this.linkLabelSHEMADDSHEMADDSTANDARD, 1);
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.SetRowSpan(this.linkLabelSHEMADDSHEMADDSTANDARD, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMADDSHEMADDSTANDARD.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSHEMADDSHEMADDSTANDARD.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSHEMADDSHEMADDSTANDARD.Size = size;
            this.linkLabelSHEMADDSHEMADDSTANDARD.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformSHEMADD);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSHEMADD;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.Disabled;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.SHEMADDIDSHEMADDDescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            column.Hidden = true;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.SHEMADDSHEMADDDOPRINOSIDDOPRINOSDescription;
            column6.Width = 0x77;
            appearance4.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnn";
            column6.PromptChar = ' ';
            column6.Format = "";
            column6.CellAppearance = appearance4;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.SHEMADDKONTODOPIDKONTODescription;
            column2.Width = 0x72;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            column3.AllowGroupBy = DefaultableBoolean.False;
            column3.AutoSizeEdit = DefaultableBoolean.False;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column3.CellAppearance.BorderAlpha = Alpha.Transparent;
            column3.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column3.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column3.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column3.Header.Enabled = false;
            column3.Header.Fixed = true;
            column3.Header.Caption = "";
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column3.Width = 20;
            column3.MinWidth = 20;
            column3.MaxWidth = 20;
            column3.Tag = "KONTOKONTODOPIDKONTOAddNew";
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.SHEMADDMTDOPIDMJESTOTROSKADescription;
            column4.Width = 0x48;
            column4.Format = "";
            column4.CellAppearance = appearance3;
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
            column5.Tag = "MJESTOTROSKAMTDOPIDMJESTOTROSKAAddNew";
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.SHEMADDSTRANEDOPIDSTRANEKNJIZENJADescription;
            column8.Width = 0x63;
            column8.Format = "";
            column8.CellAppearance = appearance6;
            column9.AllowGroupBy = DefaultableBoolean.False;
            column9.AutoSizeEdit = DefaultableBoolean.False;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column9.CellAppearance.BorderAlpha = Alpha.Transparent;
            column9.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column9.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column9.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column9.Header.Enabled = false;
            column9.Header.Fixed = true;
            column9.Header.Caption = "";
            column9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column9.Width = 20;
            column9.MinWidth = 20;
            column9.MaxWidth = 20;
            column9.Tag = "STRANEKNJIZENJASTRANEDOPIDSTRANEKNJIZENJAAddNew";
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.Disabled;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.SHEMADDSHEMADDDOPRINOSNAZIVDOPRINOSDescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance5;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 4;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 5;
            this.grdLevelSHEMADDSHEMADDDOPRINOS.Visible = true;
            this.grdLevelSHEMADDSHEMADDDOPRINOS.Name = "grdLevelSHEMADDSHEMADDDOPRINOS";
            this.grdLevelSHEMADDSHEMADDDOPRINOS.Tag = "SHEMADDSHEMADDDOPRINOS";
            this.grdLevelSHEMADDSHEMADDDOPRINOS.TabIndex = 0x15;
            this.grdLevelSHEMADDSHEMADDDOPRINOS.Dock = DockStyle.Fill;
            this.grdLevelSHEMADDSHEMADDDOPRINOS.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelSHEMADDSHEMADDDOPRINOS.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelSHEMADDSHEMADDDOPRINOS.DataSource = this.bindingSourceSHEMADDSHEMADDDOPRINOS;
            this.grdLevelSHEMADDSHEMADDDOPRINOS.Enter += new EventHandler(this.grdLevelSHEMADDSHEMADDDOPRINOS_Enter);
            this.grdLevelSHEMADDSHEMADDDOPRINOS.AfterRowInsert += new RowEventHandler(this.grdLevelSHEMADDSHEMADDDOPRINOS_AfterRowInsert);
            this.grdLevelSHEMADDSHEMADDDOPRINOS.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelSHEMADDSHEMADDDOPRINOS.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelSHEMADDSHEMADDDOPRINOS.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelSHEMADDSHEMADDDOPRINOS.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelSHEMADDSHEMADDDOPRINOS_DoubleClick);
            this.grdLevelSHEMADDSHEMADDDOPRINOS.AfterRowActivate += new EventHandler(this.grdLevelSHEMADDSHEMADDDOPRINOS_AfterRowActivate);
            this.grdLevelSHEMADDSHEMADDDOPRINOS.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelSHEMADDSHEMADDDOPRINOS.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelSHEMADDSHEMADDDOPRINOS.DisplayLayout.BandsSerializer.Add(band);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.Disabled;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.SHEMADDIDSHEMADDDescription;
            column11.Width = 0x33;
            appearance8.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnn";
            column11.PromptChar = ' ';
            column11.Format = "";
            column11.CellAppearance = appearance8;
            column11.Hidden = true;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.SHEMADDSHEMADDSTANDARDIDDescription;
            column17.Width = 0x10c;
            column17.Format = "";
            column17.CellAppearance = appearance12;
            column17.Hidden = true;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.SHEMADDIDDDVRSTEIZNOSADescription;
            column10.Width = 0x63;
            appearance7.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnn";
            column10.PromptChar = ' ';
            column10.Format = "";
            column10.CellAppearance = appearance7;
            column10.Hidden = true;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.SHEMADDKONTODDVRSTAIZNOSAIDKONTODescription;
            column12.Width = 0x72;
            column12.Format = "";
            column12.CellAppearance = appearance9;
            column13.AllowGroupBy = DefaultableBoolean.False;
            column13.AutoSizeEdit = DefaultableBoolean.False;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column13.CellAppearance.BorderAlpha = Alpha.Transparent;
            column13.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column13.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column13.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column13.Header.Enabled = false;
            column13.Header.Fixed = true;
            column13.Header.Caption = "";
            column13.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column13.Width = 20;
            column13.MinWidth = 20;
            column13.MaxWidth = 20;
            column13.Tag = "KONTOKONTODDVRSTAIZNOSAIDKONTOAddNew";
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.SHEMADDMTDDVRSTAIZNOSAIDMJESTOTROSKADescription;
            column14.Width = 0x48;
            column14.Format = "";
            column14.CellAppearance = appearance10;
            column15.AllowGroupBy = DefaultableBoolean.False;
            column15.AutoSizeEdit = DefaultableBoolean.False;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column15.CellAppearance.BorderAlpha = Alpha.Transparent;
            column15.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column15.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column15.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column15.Header.Enabled = false;
            column15.Header.Fixed = true;
            column15.Header.Caption = "";
            column15.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column15.Width = 20;
            column15.MinWidth = 20;
            column15.MaxWidth = 20;
            column15.Tag = "MJESTOTROSKAMTDDVRSTAIZNOSAIDMJESTOTROSKAAddNew";
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.SHEMADDSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJADescription;
            column18.Width = 0x63;
            column18.Format = "";
            column18.CellAppearance = appearance13;
            column19.AllowGroupBy = DefaultableBoolean.False;
            column19.AutoSizeEdit = DefaultableBoolean.False;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column19.CellAppearance.BorderAlpha = Alpha.Transparent;
            column19.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column19.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column19.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column19.Header.Enabled = false;
            column19.Header.Fixed = true;
            column19.Header.Caption = "";
            column19.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column19.Width = 20;
            column19.MinWidth = 20;
            column19.MaxWidth = 20;
            column19.Tag = "STRANEKNJIZENJASTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJAAddNew";
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.Disabled;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.SHEMADDNAZIVDDVRSTEIZNOSADescription;
            column16.Width = 0x128;
            column16.Format = "";
            column16.CellAppearance = appearance11;
            band2.Columns.Add(column16);
            column16.Header.VisiblePosition = 0;
            band2.Columns.Add(column12);
            column12.Header.VisiblePosition = 1;
            band2.Columns.Add(column18);
            column18.Header.VisiblePosition = 2;
            band2.Columns.Add(column14);
            column14.Header.VisiblePosition = 3;
            band2.Columns.Add(column11);
            column11.Header.VisiblePosition = 4;
            band2.Columns.Add(column17);
            column17.Header.VisiblePosition = 5;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 6;
            this.grdLevelSHEMADDSHEMADDSTANDARD.Visible = true;
            this.grdLevelSHEMADDSHEMADDSTANDARD.Name = "grdLevelSHEMADDSHEMADDSTANDARD";
            this.grdLevelSHEMADDSHEMADDSTANDARD.Tag = "SHEMADDSHEMADDSTANDARD";
            this.grdLevelSHEMADDSHEMADDSTANDARD.TabIndex = 0x15;
            this.grdLevelSHEMADDSHEMADDSTANDARD.Dock = DockStyle.Fill;
            this.grdLevelSHEMADDSHEMADDSTANDARD.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelSHEMADDSHEMADDSTANDARD.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelSHEMADDSHEMADDSTANDARD.DataSource = this.bindingSourceSHEMADDSHEMADDSTANDARD;
            this.grdLevelSHEMADDSHEMADDSTANDARD.Enter += new EventHandler(this.grdLevelSHEMADDSHEMADDSTANDARD_Enter);
            this.grdLevelSHEMADDSHEMADDSTANDARD.AfterRowInsert += new RowEventHandler(this.grdLevelSHEMADDSHEMADDSTANDARD_AfterRowInsert);
            this.grdLevelSHEMADDSHEMADDSTANDARD.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelSHEMADDSHEMADDSTANDARD.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelSHEMADDSHEMADDSTANDARD.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelSHEMADDSHEMADDSTANDARD.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelSHEMADDSHEMADDSTANDARD_DoubleClick);
            this.grdLevelSHEMADDSHEMADDSTANDARD.AfterRowActivate += new EventHandler(this.grdLevelSHEMADDSHEMADDSTANDARD_AfterRowActivate);
            this.grdLevelSHEMADDSHEMADDSTANDARD.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelSHEMADDSHEMADDSTANDARD.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelSHEMADDSHEMADDSTANDARD.DisplayLayout.BandsSerializer.Add(band2);
            this.Name = "SHEMADDFormUserControl";
            this.Text = "Shema drugi dohodak";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SHEMADDFormUserControl_Load);
            this.layoutManagerformSHEMADD.ResumeLayout(false);
            this.layoutManagerformSHEMADD.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSHEMADD).EndInit();
            ((ISupportInitialize) this.bindingSourceSHEMADDSHEMADDDOPRINOS).EndInit();
            ((ISupportInitialize) this.bindingSourceSHEMADDSHEMADDSTANDARD).EndInit();
            ((ISupportInitialize) this.textIDSHEMADD).EndInit();
            ((ISupportInitialize) this.textNAZIVSHEMADD).EndInit();
            ((ISupportInitialize) this.grdLevelSHEMADDSHEMADDDOPRINOS).EndInit();
            this.panelactionsSHEMADDSHEMADDDOPRINOS.ResumeLayout(true);
            this.panelactionsSHEMADDSHEMADDDOPRINOS.PerformLayout();
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.ResumeLayout(false);
            this.layoutManagerpanelactionsSHEMADDSHEMADDDOPRINOS.PerformLayout();
            this.layoutManagerTabPage1.ResumeLayout(false);
            this.layoutManagerTabPage1.PerformLayout();
            ((ISupportInitialize) this.grdLevelSHEMADDSHEMADDSTANDARD).EndInit();
            this.panelactionsSHEMADDSHEMADDSTANDARD.ResumeLayout(true);
            this.panelactionsSHEMADDSHEMADDSTANDARD.PerformLayout();
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.ResumeLayout(false);
            this.layoutManagerpanelactionsSHEMADDSHEMADDSTANDARD.PerformLayout();
            this.layoutManagerTabPage2.ResumeLayout(false);
            this.layoutManagerTabPage2.PerformLayout();
            this.Tab1.ResumeLayout(true);
            this.Tab1.PerformLayout();
            ((ISupportInitialize) this.Tab1).EndInit();
            this.dsSHEMADDDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.SHEMADDController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMADD, this.SHEMADDController.WorkItem, this))
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
            this.label1IDSHEMADD.Text = StringResources.SHEMADDIDSHEMADDDescription;
            this.label1NAZIVSHEMADD.Text = StringResources.SHEMADDNAZIVSHEMADDDescription;
            this.label1SHEMADDOJIDORGJED.Text = StringResources.SHEMADDSHEMADDOJIDORGJEDDescription;
            this.TabPage1.Tab.Text = StringResources.SHEMADDSHEMADDTabPage1TabDescription;
            this.TabPage2.Tab.Text = StringResources.SHEMADDSHEMADDTabPage2TabDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedInLinesKONTODDVRSTAIZNOSAIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesKONTODOPIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesMTDDVRSTAIZNOSAIDMJESTOTROSKA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("MJESTOTROSKA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesMTDOPIDMJESTOTROSKA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("MJESTOTROSKA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRANEKNJIZENJA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesSTRANEDOPIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRANEKNJIZENJA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSHEMADDOJIDORGJED(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ORGJED", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.SHEMADDController.WorkItem.Items.Contains("SHEMADD|SHEMADD"))
            {
                this.SHEMADDController.WorkItem.Items.Add(this.bindingSourceSHEMADD, "SHEMADD|SHEMADD");
            }
            if (!this.SHEMADDController.WorkItem.Items.Contains("SHEMADD|SHEMADDSHEMADDDOPRINOS"))
            {
                this.SHEMADDController.WorkItem.Items.Add(this.bindingSourceSHEMADDSHEMADDDOPRINOS, "SHEMADD|SHEMADDSHEMADDDOPRINOS");
            }
            if (!this.SHEMADDController.WorkItem.Items.Contains("SHEMADD|SHEMADDSHEMADDSTANDARD"))
            {
                this.SHEMADDController.WorkItem.Items.Add(this.bindingSourceSHEMADDSHEMADDSTANDARD, "SHEMADD|SHEMADDSHEMADDSTANDARD");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsSHEMADDDataSet1.SHEMADD.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.SHEMADDController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.SHEMADDController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.SHEMADDController.Update(this))
            {
                this.SHEMADDController.DataSet = new SHEMADDDataSet();
                DataSetUtil.AddEmptyRow(this.SHEMADDController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.SHEMADDController.DataSet.SHEMADD[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedSHEMADDOJIDORGJED(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSHEMADDOJIDORGJED.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSHEMADDOJIDORGJED.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMADD.Current).Row["SHEMADDOJIDORGJED"] = RuntimeHelpers.GetObjectValue(row["IDORGJED"]);
                    this.bindingSourceSHEMADD.ResetCurrentItem();
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
            CreateValueList(this.grdLevelSHEMADDSHEMADDDOPRINOS, "KONTOKONTODOPIDKONTO", enumList, "IDKONTO", "KONT", false);
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelSHEMADDSHEMADDDOPRINOS, "KONTODOPIDKONTO");
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            gridColumn.ValueList = this.grdLevelSHEMADDSHEMADDDOPRINOS.DisplayLayout.ValueLists["KONTOKONTODOPIDKONTO"];
            gridColumn.Width = 370;
            DataSet set2 = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(set2);
            }
            DataView view2 = new DataView(set2.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.grdLevelSHEMADDSHEMADDDOPRINOS, "MJESTOTROSKAMTDOPIDMJESTOTROSKA", view2, "IDMJESTOTROSKA", "mt", false);
            UltraGridColumn column2 = FormHelperClass.GetGridColumn(this.grdLevelSHEMADDSHEMADDDOPRINOS, "MTDOPIDMJESTOTROSKA");
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.grdLevelSHEMADDSHEMADDDOPRINOS.DisplayLayout.ValueLists["MJESTOTROSKAMTDOPIDMJESTOTROSKA"];
            column2.Width = 370;
            DataSet set3 = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(set3);
            }
            DataView view3 = new DataView(set3.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.grdLevelSHEMADDSHEMADDDOPRINOS, "STRANEKNJIZENJASTRANEDOPIDSTRANEKNJIZENJA", view3, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA", false);
            UltraGridColumn column3 = FormHelperClass.GetGridColumn(this.grdLevelSHEMADDSHEMADDDOPRINOS, "STRANEDOPIDSTRANEKNJIZENJA");
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column3.ValueList = this.grdLevelSHEMADDSHEMADDDOPRINOS.DisplayLayout.ValueLists["STRANEKNJIZENJASTRANEDOPIDSTRANEKNJIZENJA"];
            column3.Width = 280;
            this.grdLevelSHEMADDSHEMADDDOPRINOS.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelSHEMADDSHEMADDDOPRINOS.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
            DataSet set4 = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set4);
            }
            DataView view4 = new DataView(set4.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.grdLevelSHEMADDSHEMADDSTANDARD, "KONTOKONTODDVRSTAIZNOSAIDKONTO", view4, "IDKONTO", "KONT", false);
            UltraGridColumn column4 = FormHelperClass.GetGridColumn(this.grdLevelSHEMADDSHEMADDSTANDARD, "KONTODDVRSTAIZNOSAIDKONTO");
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column4.ValueList = this.grdLevelSHEMADDSHEMADDSTANDARD.DisplayLayout.ValueLists["KONTOKONTODDVRSTAIZNOSAIDKONTO"];
            column4.Width = 370;
            DataSet set5 = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(set5);
            }
            DataView view5 = new DataView(set5.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.grdLevelSHEMADDSHEMADDSTANDARD, "MJESTOTROSKAMTDDVRSTAIZNOSAIDMJESTOTROSKA", view5, "IDMJESTOTROSKA", "mt", false);
            UltraGridColumn column5 = FormHelperClass.GetGridColumn(this.grdLevelSHEMADDSHEMADDSTANDARD, "MTDDVRSTAIZNOSAIDMJESTOTROSKA");
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column5.ValueList = this.grdLevelSHEMADDSHEMADDSTANDARD.DisplayLayout.ValueLists["MJESTOTROSKAMTDDVRSTAIZNOSAIDMJESTOTROSKA"];
            column5.Width = 370;
            DataSet set6 = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(set6);
            }
            DataView view6 = new DataView(set6.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.grdLevelSHEMADDSHEMADDSTANDARD, "STRANEKNJIZENJASTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA", view6, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA", false);
            UltraGridColumn column6 = FormHelperClass.GetGridColumn(this.grdLevelSHEMADDSHEMADDSTANDARD, "STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA");
            column6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column6.ValueList = this.grdLevelSHEMADDSHEMADDSTANDARD.DisplayLayout.ValueLists["STRANEKNJIZENJASTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"];
            column6.Width = 280;
            this.grdLevelSHEMADDSHEMADDSTANDARD.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelSHEMADDSHEMADDSTANDARD.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.textIDSHEMADD.Focus();
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

        private void SHEMADDFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.SHEMADDDescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelSHEMADDSHEMADDDOPRINOSAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.SHEMADDSHEMADDSHEMADDDOPRINOSLevelDescription;
            this.linkLabelSHEMADDSHEMADDDOPRINOSUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.SHEMADDSHEMADDSHEMADDDOPRINOSLevelDescription;
            this.linkLabelSHEMADDSHEMADDDOPRINOSDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.SHEMADDSHEMADDSHEMADDDOPRINOSLevelDescription;
            this.linkLabelSHEMADDSHEMADDSTANDARDAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.SHEMADDSHEMADDSHEMADDSTANDARDLevelDescription;
            this.linkLabelSHEMADDSHEMADDSTANDARDUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.SHEMADDSHEMADDSHEMADDSTANDARDLevelDescription;
            this.linkLabelSHEMADDSHEMADDSTANDARDDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.SHEMADDSHEMADDSHEMADDSTANDARDLevelDescription;
        }

        private void SHEMADDSHEMADDDOPRINOSAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelSHEMADDSHEMADDDOPRINOS.ActiveRow;
            this.SHEMADDSHEMADDDOPRINOSInsert();
        }

        private void SHEMADDSHEMADDDOPRINOSDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelSHEMADDSHEMADDDOPRINOS);
            if ((currentRowListIndex != -1) && (this.grdLevelSHEMADDSHEMADDDOPRINOS.Selected.Rows.Count > 0))
            {
                this.grdLevelSHEMADDSHEMADDDOPRINOS.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelSHEMADDSHEMADDDOPRINOS).Selected = true;
                this.grdLevelSHEMADDSHEMADDDOPRINOS.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SHEMADDSHEMADDDOPRINOSInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMADD, this.SHEMADDController.WorkItem, this))
            {
                this.SHEMADDController.AddSHEMADDSHEMADDDOPRINOS(this.m_CurrentRow);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void SHEMADDSHEMADDDOPRINOSKONTODOPIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.grdLevelSHEMADDSHEMADDDOPRINOS, "KONTOKONTODOPIDKONTO", enumList, "IDKONTO", "KONT", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/MJESTOTROSKA", Thread=ThreadOption.UserInterface)]
        public void SHEMADDSHEMADDDOPRINOSMTDOPIDMJESTOTROSKA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.grdLevelSHEMADDSHEMADDDOPRINOS, "MJESTOTROSKAMTDOPIDMJESTOTROSKA", enumList, "IDMJESTOTROSKA", "mt", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRANEKNJIZENJA", Thread=ThreadOption.UserInterface)]
        public void SHEMADDSHEMADDDOPRINOSSTRANEDOPIDSTRANEKNJIZENJA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.grdLevelSHEMADDSHEMADDDOPRINOS, "STRANEKNJIZENJASTRANEDOPIDSTRANEKNJIZENJA", enumList, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA", true);
        }

        private void SHEMADDSHEMADDDOPRINOSUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelSHEMADDSHEMADDDOPRINOS) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelSHEMADDSHEMADDDOPRINOS);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.SHEMADDController.UpdateSHEMADDSHEMADDDOPRINOS(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SHEMADDSHEMADDDOPRINOSUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelSHEMADDSHEMADDDOPRINOS.ActiveRow != null)
            {
                this.SHEMADDSHEMADDDOPRINOSUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SHEMADDSHEMADDSTANDARDAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelSHEMADDSHEMADDSTANDARD.ActiveRow;
            this.SHEMADDSHEMADDSTANDARDInsert();
        }

        private void SHEMADDSHEMADDSTANDARDDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelSHEMADDSHEMADDSTANDARD);
            if ((currentRowListIndex != -1) && (this.grdLevelSHEMADDSHEMADDSTANDARD.Selected.Rows.Count > 0))
            {
                this.grdLevelSHEMADDSHEMADDSTANDARD.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelSHEMADDSHEMADDSTANDARD).Selected = true;
                this.grdLevelSHEMADDSHEMADDSTANDARD.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SHEMADDSHEMADDSTANDARDInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMADD, this.SHEMADDController.WorkItem, this))
            {
                this.SHEMADDController.AddSHEMADDSHEMADDSTANDARD(this.m_CurrentRow);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void SHEMADDSHEMADDSTANDARDKONTODDVRSTAIZNOSAIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.grdLevelSHEMADDSHEMADDSTANDARD, "KONTOKONTODDVRSTAIZNOSAIDKONTO", enumList, "IDKONTO", "KONT", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/MJESTOTROSKA", Thread=ThreadOption.UserInterface)]
        public void SHEMADDSHEMADDSTANDARDMTDDVRSTAIZNOSAIDMJESTOTROSKA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.grdLevelSHEMADDSHEMADDSTANDARD, "MJESTOTROSKAMTDDVRSTAIZNOSAIDMJESTOTROSKA", enumList, "IDMJESTOTROSKA", "mt", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRANEKNJIZENJA", Thread=ThreadOption.UserInterface)]
        public void SHEMADDSHEMADDSTANDARDSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.grdLevelSHEMADDSHEMADDSTANDARD, "STRANEKNJIZENJASTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA", enumList, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA", true);
        }

        private void SHEMADDSHEMADDSTANDARDUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelSHEMADDSHEMADDSTANDARD) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelSHEMADDSHEMADDSTANDARD);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.SHEMADDController.UpdateSHEMADDSHEMADDSTANDARD(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SHEMADDSHEMADDSTANDARDUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelSHEMADDSHEMADDSTANDARD.ActiveRow != null)
            {
                this.SHEMADDSHEMADDSTANDARDUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.m_FrameworkDescription, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void UpdateValuesKONTODDVRSTAIZNOSAIDKONTO(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["KONTODDVRSTAIZNOSAIDKONTO"] = RuntimeHelpers.GetObjectValue(result["IDKONTO"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesKONTODOPIDKONTO(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["KONTODOPIDKONTO"] = RuntimeHelpers.GetObjectValue(result["IDKONTO"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesMTDDVRSTAIZNOSAIDMJESTOTROSKA(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["MTDDVRSTAIZNOSAIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(result["IDMJESTOTROSKA"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesMTDOPIDMJESTOTROSKA(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["MTDOPIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(result["IDMJESTOTROSKA"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesSTRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["STRANEDDVRSTEIZNOSAIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(result["IDSTRANEKNJIZENJA"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesSTRANEDOPIDSTRANEKNJIZENJA(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["STRANEDOPIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(result["IDSTRANEKNJIZENJA"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        protected virtual ORGJEDComboBox comboSHEMADDOJIDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSHEMADDOJIDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSHEMADDOJIDORGJED = value;
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

        protected virtual UltraGrid grdLevelSHEMADDSHEMADDDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelSHEMADDSHEMADDDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelSHEMADDSHEMADDDOPRINOS = value;
            }
        }

        protected virtual UltraGrid grdLevelSHEMADDSHEMADDSTANDARD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelSHEMADDSHEMADDSTANDARD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelSHEMADDSHEMADDSTANDARD = value;
            }
        }

        protected virtual UltraLabel label1IDSHEMADD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDSHEMADD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDSHEMADD = value;
            }
        }

        protected virtual UltraLabel label1NAZIVSHEMADD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVSHEMADD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVSHEMADD = value;
            }
        }

        protected virtual UltraLabel label1SHEMADDOJIDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMADDOJIDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMADDOJIDORGJED = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMADDSHEMADDDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMADDSHEMADDDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMADDSHEMADDDOPRINOS = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMADDSHEMADDDOPRINOSAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMADDSHEMADDDOPRINOSAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMADDSHEMADDDOPRINOSAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMADDSHEMADDDOPRINOSDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMADDSHEMADDDOPRINOSDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMADDSHEMADDDOPRINOSDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMADDSHEMADDDOPRINOSUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMADDSHEMADDDOPRINOSUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMADDSHEMADDDOPRINOSUpdate = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMADDSHEMADDSTANDARD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMADDSHEMADDSTANDARD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMADDSHEMADDSTANDARD = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMADDSHEMADDSTANDARDAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMADDSHEMADDSTANDARDAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMADDSHEMADDSTANDARDAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMADDSHEMADDSTANDARDDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMADDSHEMADDSTANDARDDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMADDSHEMADDSTANDARDDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMADDSHEMADDSTANDARDUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMADDSHEMADDSTANDARDUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMADDSHEMADDSTANDARDUpdate = value;
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

        protected virtual Panel panelactionsSHEMADDSHEMADDDOPRINOS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsSHEMADDSHEMADDDOPRINOS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsSHEMADDSHEMADDDOPRINOS = value;
            }
        }

        protected virtual Panel panelactionsSHEMADDSHEMADDSTANDARD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsSHEMADDSHEMADDSTANDARD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsSHEMADDSHEMADDSTANDARD = value;
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

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.SHEMADDController SHEMADDController { get; set; }

        protected virtual UltraTabControl Tab1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._Tab1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._Tab1 = value;
            }
        }

        protected virtual UltraTabPageControl TabPage1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage1 = value;
            }
        }

        protected virtual UltraTabPageControl TabPage2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage2 = value;
            }
        }

        protected virtual UltraNumericEditor textIDSHEMADD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDSHEMADD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDSHEMADD = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVSHEMADD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVSHEMADD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVSHEMADD = value;
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

