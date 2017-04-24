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
    public class BLAGAJNAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboBLGDOKIDDOKUMENT")]
        private DOKUMENTComboBox _comboBLGDOKIDDOKUMENT;
        [AccessedThroughProperty("comboBLGKONTOIDKONTO")]
        private KONTOComboBox _comboBLGKONTOIDKONTO;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelBLAGAJNAStavkeBlagajne")]
        private UltraGrid _grdLevelBLAGAJNAStavkeBlagajne;
        [AccessedThroughProperty("label1BLGDOKIDDOKUMENT")]
        private UltraLabel _label1BLGDOKIDDOKUMENT;
        [AccessedThroughProperty("label1BLGKONTOIDKONTO")]
        private UltraLabel _label1BLGKONTOIDKONTO;
        [AccessedThroughProperty("label1NAZIVBLAGAJNA")]
        private UltraLabel _label1NAZIVBLAGAJNA;
        [AccessedThroughProperty("linkLabelBLAGAJNAStavkeBlagajne")]
        private UltraLabel _linkLabelBLAGAJNAStavkeBlagajne;
        [AccessedThroughProperty("linkLabelBLAGAJNAStavkeBlagajneAdd")]
        private UltraLabel _linkLabelBLAGAJNAStavkeBlagajneAdd;
        [AccessedThroughProperty("linkLabelBLAGAJNAStavkeBlagajneDelete")]
        private UltraLabel _linkLabelBLAGAJNAStavkeBlagajneDelete;
        [AccessedThroughProperty("linkLabelBLAGAJNAStavkeBlagajneUpdate")]
        private UltraLabel _linkLabelBLAGAJNAStavkeBlagajneUpdate;
        [AccessedThroughProperty("panelactionsBLAGAJNAStavkeBlagajne")]
        private Panel _panelactionsBLAGAJNAStavkeBlagajne;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textNAZIVBLAGAJNA")]
        private UltraTextEditor _textNAZIVBLAGAJNA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceBLAGAJNA;
        private BindingSource bindingSourceBLAGAJNAStavkeBlagajne;
        private IContainer components = null;
        private BLAGAJNADataSet dsBLAGAJNADataSet1;
        protected TableLayoutPanel layoutManagerformBLAGAJNA;
        protected TableLayoutPanel layoutManagerpanelactionsBLAGAJNAStavkeBlagajne;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private BLAGAJNADataSet.BLAGAJNARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "BLAGAJNA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.BLAGAJNADescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public BLAGAJNAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void BLAGAJNAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.BLAGAJNADescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelBLAGAJNAStavkeBlagajneAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.BLAGAJNABLAGAJNAStavkeBlagajneLevelDescription;
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.BLAGAJNABLAGAJNAStavkeBlagajneLevelDescription;
            this.linkLabelBLAGAJNAStavkeBlagajneDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.BLAGAJNABLAGAJNAStavkeBlagajneLevelDescription;
        }

        private void BLAGAJNAStavkeBlagajneAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelBLAGAJNAStavkeBlagajne.ActiveRow;
            this.BLAGAJNAStavkeBlagajneInsert();
        }

        private void BLAGAJNAStavkeBlagajneDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelBLAGAJNAStavkeBlagajne);
            if ((currentRowListIndex != -1) && (this.grdLevelBLAGAJNAStavkeBlagajne.Selected.Rows.Count > 0))
            {
                this.grdLevelBLAGAJNAStavkeBlagajne.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelBLAGAJNAStavkeBlagajne).Selected = true;
                this.grdLevelBLAGAJNAStavkeBlagajne.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void BLAGAJNAStavkeBlagajneInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceBLAGAJNA, this.Controller.WorkItem, this))
            {
                this.Controller.AddBLAGAJNAStavkeBlagajne(this.m_CurrentRow);
            }
        }

        private void BLAGAJNAStavkeBlagajneUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelBLAGAJNAStavkeBlagajne) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelBLAGAJNAStavkeBlagajne);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.Controller.UpdateBLAGAJNAStavkeBlagajne(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void BLAGAJNAStavkeBlagajneUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelBLAGAJNAStavkeBlagajne.ActiveRow != null)
            {
                this.BLAGAJNAStavkeBlagajneUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void CallPromptInLinesBLGVRSTEDOKIDBLGVRSTEDOK(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.Controller.SelectBLGVRSTEDOKIDBLGVRSTEDOK("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDBLGVRSTEDOK"] = RuntimeHelpers.GetObjectValue(row2["IDBLGVRSTEDOK"]);
                    row3["NAZIVVRSTEDOK"] = RuntimeHelpers.GetObjectValue(row2["NAZIVVRSTEDOK"]);
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

        private void CallPromptInLinesGODINEblggodineIDGODINE(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.Controller.SelectGODINEblggodineIDGODINE("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["blggodineIDGODINE"] = RuntimeHelpers.GetObjectValue(row2["IDGODINE"]);
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

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsBLAGAJNADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceBLAGAJNA.DataSource = this.Controller.DataSet;
            this.dsBLAGAJNADataSet1 = this.Controller.DataSet;
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
        public void comboBLGDOKIDDOKUMENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboBLGDOKIDDOKUMENT.Fill();
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void comboBLGKONTOIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            this.comboBLGKONTOIDKONTO.Fill();
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
                    enumerator = this.dsBLAGAJNADataSet1.BLAGAJNA.Rows.GetEnumerator();
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

        private void dg_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGridColumn column = e.Cell.Column;
            if (column.CellActivation == Activation.AllowEdit)
            {
                switch (Conversions.ToString(column.Tag))
                {
                    case "BLGVRSTEDOKIDBLGVRSTEDOK":
                        this.CallPromptInLinesBLGVRSTEDOKIDBLGVRSTEDOK(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "GODINEblggodineIDGODINE":
                        this.CallPromptInLinesGODINEblggodineIDGODINE(RuntimeHelpers.GetObjectValue(sender), e);
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
            if (this.grdLevelBLAGAJNAStavkeBlagajne.ActiveRow != null)
            {
                this.grdLevelBLAGAJNAStavkeBlagajne.PerformAction(UltraGridAction.NextRow);
            }
        }

        private void grdLevelBLAGAJNAStavkeBlagajne_AfterRowActivate(object sender, EventArgs e)
        {
            string bLAGAJNABLAGAJNAStavkeBlagajneLevelDescription = StringResources.BLAGAJNABLAGAJNAStavkeBlagajneLevelDescription;
            UltraGridRow activeRow = this.grdLevelBLAGAJNAStavkeBlagajne.ActiveRow;
            this.linkLabelBLAGAJNAStavkeBlagajneAdd.Text = Deklarit.Resources.Resources.Add + " " + bLAGAJNABLAGAJNAStavkeBlagajneLevelDescription;
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate.Text = Deklarit.Resources.Resources.Update + " " + bLAGAJNABLAGAJNAStavkeBlagajneLevelDescription;
            this.linkLabelBLAGAJNAStavkeBlagajneDelete.Text = Deklarit.Resources.Resources.Delete + " " + bLAGAJNABLAGAJNAStavkeBlagajneLevelDescription;
        }

        private void grdLevelBLAGAJNAStavkeBlagajne_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceBLAGAJNA.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceBLAGAJNA.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelBLAGAJNAStavkeBlagajne_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.BLAGAJNAStavkeBlagajneUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelBLAGAJNAStavkeBlagajne_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceBLAGAJNA, this.Controller.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "BLAGAJNA", this.m_Mode, this.dsBLAGAJNADataSet1, this.dsBLAGAJNADataSet1.BLAGAJNA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            if (!this.m_DataGrids.Contains(this.grdLevelBLAGAJNAStavkeBlagajne))
            {
                this.m_DataGrids.Add(this.grdLevelBLAGAJNAStavkeBlagajne);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsBLAGAJNADataSet1.BLAGAJNA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (BLAGAJNADataSet.BLAGAJNARow) ((DataRowView) this.bindingSourceBLAGAJNA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(BLAGAJNAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceBLAGAJNA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceBLAGAJNA).BeginInit();
            this.bindingSourceBLAGAJNAStavkeBlagajne = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceBLAGAJNAStavkeBlagajne).BeginInit();
            this.layoutManagerformBLAGAJNA = new TableLayoutPanel();
            this.layoutManagerformBLAGAJNA.SuspendLayout();
            this.layoutManagerformBLAGAJNA.AutoSize = true;
            this.layoutManagerformBLAGAJNA.Dock = DockStyle.Fill;
            this.layoutManagerformBLAGAJNA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformBLAGAJNA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformBLAGAJNA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformBLAGAJNA.Size = size;
            this.layoutManagerformBLAGAJNA.ColumnCount = 2;
            this.layoutManagerformBLAGAJNA.RowCount = 5;
            this.layoutManagerformBLAGAJNA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformBLAGAJNA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformBLAGAJNA.RowStyles.Add(new RowStyle());
            this.layoutManagerformBLAGAJNA.RowStyles.Add(new RowStyle());
            this.layoutManagerformBLAGAJNA.RowStyles.Add(new RowStyle());
            this.layoutManagerformBLAGAJNA.RowStyles.Add(new RowStyle());
            this.layoutManagerformBLAGAJNA.RowStyles.Add(new RowStyle());
            this.label1BLGDOKIDDOKUMENT = new UltraLabel();
            this.comboBLGDOKIDDOKUMENT = new DOKUMENTComboBox();
            this.label1NAZIVBLAGAJNA = new UltraLabel();
            this.textNAZIVBLAGAJNA = new UltraTextEditor();
            this.label1BLGKONTOIDKONTO = new UltraLabel();
            this.comboBLGKONTOIDKONTO = new KONTOComboBox();
            this.grdLevelBLAGAJNAStavkeBlagajne = new UltraGrid();
            this.panelactionsBLAGAJNAStavkeBlagajne = new Panel();
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne = new TableLayoutPanel();
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.AutoSize = true;
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.ColumnCount = 4;
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.RowCount = 1;
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.RowStyles.Add(new RowStyle());
            this.linkLabelBLAGAJNAStavkeBlagajneAdd = new UltraLabel();
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate = new UltraLabel();
            this.linkLabelBLAGAJNAStavkeBlagajneDelete = new UltraLabel();
            this.linkLabelBLAGAJNAStavkeBlagajne = new UltraLabel();
            ((ISupportInitialize) this.textNAZIVBLAGAJNA).BeginInit();
            ((ISupportInitialize) this.grdLevelBLAGAJNAStavkeBlagajne).BeginInit();
            this.panelactionsBLAGAJNAStavkeBlagajne.SuspendLayout();
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.SuspendLayout();
            UltraGridBand band = new UltraGridBand("BLAGAJNAStavkeBlagajne", -1);
            UltraGridColumn column3 = new UltraGridColumn("BLGDOKIDDOKUMENT");
            UltraGridColumn column4 = new UltraGridColumn("columnBLGDOKIDDOKUMENTAddNew", 0);
            UltraGridColumn column8 = new UltraGridColumn("IDBLGVRSTEDOK");
            UltraGridColumn column5 = new UltraGridColumn("blggodineIDGODINE");
            UltraGridColumn column9 = new UltraGridColumn("NAZIVVRSTEDOK");
            UltraGridColumn column = new UltraGridColumn("BLGBROJDOKUMENTA");
            UltraGridColumn column2 = new UltraGridColumn("BLGDATUMDOKUMENTA");
            UltraGridColumn column7 = new UltraGridColumn("BLGSVRHA");
            UltraGridColumn column6 = new UltraGridColumn("BLGIZNOS");
            UltraGridBand band2 = new UltraGridBand("BLAGAJNAStavkeBlagajne_BLAGAJNAStavkeBlagajneStavkeBlagajneKontiranje", 0);
            UltraGridColumn column11 = new UltraGridColumn("BLGDOKIDDOKUMENT");
            UltraGridColumn column12 = new UltraGridColumn("columnBLGDOKIDDOKUMENTAddNew", 0);
            UltraGridColumn column24 = new UltraGridColumn("IDBLGVRSTEDOK");
            UltraGridColumn column13 = new UltraGridColumn("blggodineIDGODINE");
            UltraGridColumn column10 = new UltraGridColumn("BLGBROJDOKUMENTA");
            UltraGridColumn column21 = new UltraGridColumn("BLGSTAVKEBLAGAJNEKONTOIDKONTO");
            UltraGridColumn column22 = new UltraGridColumn("columnBLGSTAVKEBLAGAJNEKONTOIDKONTOAddNew", 1);
            UltraGridColumn column23 = new UltraGridColumn("BLGSTAVKEBLAGAJNEKONTONAZIVKONTO");
            UltraGridColumn column15 = new UltraGridColumn("BLGMTIDMJESTOTROSKA");
            UltraGridColumn column16 = new UltraGridColumn("columnBLGMTIDMJESTOTROSKAAddNew", 2);
            UltraGridColumn column17 = new UltraGridColumn("BLGMTNAZIVMJESTOTROSKA");
            UltraGridColumn column18 = new UltraGridColumn("BLGORGJEDIDORGJED");
            UltraGridColumn column19 = new UltraGridColumn("columnBLGORGJEDIDORGJEDAddNew", 3);
            UltraGridColumn column20 = new UltraGridColumn("BLGORGJEDNAZIVORGJED");
            UltraGridColumn column14 = new UltraGridColumn("BLGIZNOSKONTIRANJA");
            this.dsBLAGAJNADataSet1 = new BLAGAJNADataSet();
            this.dsBLAGAJNADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsBLAGAJNADataSet1.DataSetName = "dsBLAGAJNA";
            this.dsBLAGAJNADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceBLAGAJNA.DataSource = this.dsBLAGAJNADataSet1;
            this.bindingSourceBLAGAJNA.DataMember = "BLAGAJNA";
            ((ISupportInitialize) this.bindingSourceBLAGAJNA).BeginInit();
            this.bindingSourceBLAGAJNAStavkeBlagajne.DataSource = this.bindingSourceBLAGAJNA;
            this.bindingSourceBLAGAJNAStavkeBlagajne.DataMember = "BLAGAJNA_BLAGAJNAStavkeBlagajne";
            point = new System.Drawing.Point(0, 0);
            this.label1BLGDOKIDDOKUMENT.Location = point;
            this.label1BLGDOKIDDOKUMENT.Name = "label1BLGDOKIDDOKUMENT";
            this.label1BLGDOKIDDOKUMENT.TabIndex = 1;
            this.label1BLGDOKIDDOKUMENT.Tag = "labelBLGDOKIDDOKUMENT";
            this.label1BLGDOKIDDOKUMENT.Text = "Šifra dok. blagajne:";
            this.label1BLGDOKIDDOKUMENT.StyleSetName = "FieldUltraLabel";
            this.label1BLGDOKIDDOKUMENT.AutoSize = true;
            this.label1BLGDOKIDDOKUMENT.Anchor = AnchorStyles.Left;
            this.label1BLGDOKIDDOKUMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1BLGDOKIDDOKUMENT.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1BLGDOKIDDOKUMENT.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1BLGDOKIDDOKUMENT.ImageSize = size;
            this.label1BLGDOKIDDOKUMENT.Appearance.ForeColor = Color.Black;
            this.label1BLGDOKIDDOKUMENT.BackColor = Color.Transparent;
            this.layoutManagerformBLAGAJNA.Controls.Add(this.label1BLGDOKIDDOKUMENT, 0, 0);
            this.layoutManagerformBLAGAJNA.SetColumnSpan(this.label1BLGDOKIDDOKUMENT, 1);
            this.layoutManagerformBLAGAJNA.SetRowSpan(this.label1BLGDOKIDDOKUMENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1BLGDOKIDDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BLGDOKIDDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x85, 0x17);
            this.label1BLGDOKIDDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboBLGDOKIDDOKUMENT.Location = point;
            this.comboBLGDOKIDDOKUMENT.Name = "comboBLGDOKIDDOKUMENT";
            this.comboBLGDOKIDDOKUMENT.Tag = "BLGDOKIDDOKUMENT";
            this.comboBLGDOKIDDOKUMENT.TabIndex = 0;
            this.comboBLGDOKIDDOKUMENT.Anchor = AnchorStyles.Left;
            this.comboBLGDOKIDDOKUMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboBLGDOKIDDOKUMENT.DropDownStyle = DropDownStyle.DropDown;
            this.comboBLGDOKIDDOKUMENT.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboBLGDOKIDDOKUMENT.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboBLGDOKIDDOKUMENT.Enabled = true;
            this.comboBLGDOKIDDOKUMENT.DataBindings.Add(new Binding("Value", this.bindingSourceBLAGAJNA, "BLGDOKIDDOKUMENT"));
            this.comboBLGDOKIDDOKUMENT.ShowPictureBox = true;
            this.comboBLGDOKIDDOKUMENT.PictureBoxClicked += new EventHandler(this.PictureBoxClickedBLGDOKIDDOKUMENT);
            this.comboBLGDOKIDDOKUMENT.ValueMember = "IDDOKUMENT";
            this.comboBLGDOKIDDOKUMENT.SelectionChanged += new EventHandler(this.SelectedIndexChangedBLGDOKIDDOKUMENT);
            this.layoutManagerformBLAGAJNA.Controls.Add(this.comboBLGDOKIDDOKUMENT, 1, 0);
            this.layoutManagerformBLAGAJNA.SetColumnSpan(this.comboBLGDOKIDDOKUMENT, 1);
            this.layoutManagerformBLAGAJNA.SetRowSpan(this.comboBLGDOKIDDOKUMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboBLGDOKIDDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboBLGDOKIDDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboBLGDOKIDDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVBLAGAJNA.Location = point;
            this.label1NAZIVBLAGAJNA.Name = "label1NAZIVBLAGAJNA";
            this.label1NAZIVBLAGAJNA.TabIndex = 1;
            this.label1NAZIVBLAGAJNA.Tag = "labelNAZIVBLAGAJNA";
            this.label1NAZIVBLAGAJNA.Text = "Naziv:";
            this.label1NAZIVBLAGAJNA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVBLAGAJNA.AutoSize = true;
            this.label1NAZIVBLAGAJNA.Anchor = AnchorStyles.Left;
            this.label1NAZIVBLAGAJNA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVBLAGAJNA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVBLAGAJNA.BackColor = Color.Transparent;
            this.layoutManagerformBLAGAJNA.Controls.Add(this.label1NAZIVBLAGAJNA, 0, 1);
            this.layoutManagerformBLAGAJNA.SetColumnSpan(this.label1NAZIVBLAGAJNA, 1);
            this.layoutManagerformBLAGAJNA.SetRowSpan(this.label1NAZIVBLAGAJNA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVBLAGAJNA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVBLAGAJNA.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1NAZIVBLAGAJNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVBLAGAJNA.Location = point;
            this.textNAZIVBLAGAJNA.Name = "textNAZIVBLAGAJNA";
            this.textNAZIVBLAGAJNA.Tag = "NAZIVBLAGAJNA";
            this.textNAZIVBLAGAJNA.TabIndex = 0;
            this.textNAZIVBLAGAJNA.Anchor = AnchorStyles.Left;
            this.textNAZIVBLAGAJNA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVBLAGAJNA.ReadOnly = false;
            this.textNAZIVBLAGAJNA.DataBindings.Add(new Binding("Text", this.bindingSourceBLAGAJNA, "NAZIVBLAGAJNA"));
            this.textNAZIVBLAGAJNA.MaxLength = 30;
            this.layoutManagerformBLAGAJNA.Controls.Add(this.textNAZIVBLAGAJNA, 1, 1);
            this.layoutManagerformBLAGAJNA.SetColumnSpan(this.textNAZIVBLAGAJNA, 1);
            this.layoutManagerformBLAGAJNA.SetRowSpan(this.textNAZIVBLAGAJNA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVBLAGAJNA.Margin = padding;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textNAZIVBLAGAJNA.MinimumSize = size;
            size = new System.Drawing.Size(0xe2, 0x16);
            this.textNAZIVBLAGAJNA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1BLGKONTOIDKONTO.Location = point;
            this.label1BLGKONTOIDKONTO.Name = "label1BLGKONTOIDKONTO";
            this.label1BLGKONTOIDKONTO.TabIndex = 1;
            this.label1BLGKONTOIDKONTO.Tag = "labelBLGKONTOIDKONTO";
            this.label1BLGKONTOIDKONTO.Text = "Konto blagajne:";
            this.label1BLGKONTOIDKONTO.StyleSetName = "FieldUltraLabel";
            this.label1BLGKONTOIDKONTO.AutoSize = true;
            this.label1BLGKONTOIDKONTO.Anchor = AnchorStyles.Left;
            this.label1BLGKONTOIDKONTO.Appearance.TextVAlign = VAlign.Middle;
            this.label1BLGKONTOIDKONTO.Appearance.ForeColor = Color.Black;
            this.label1BLGKONTOIDKONTO.BackColor = Color.Transparent;
            this.layoutManagerformBLAGAJNA.Controls.Add(this.label1BLGKONTOIDKONTO, 0, 2);
            this.layoutManagerformBLAGAJNA.SetColumnSpan(this.label1BLGKONTOIDKONTO, 1);
            this.layoutManagerformBLAGAJNA.SetRowSpan(this.label1BLGKONTOIDKONTO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1BLGKONTOIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1BLGKONTOIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x71, 0x17);
            this.label1BLGKONTOIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboBLGKONTOIDKONTO.Location = point;
            this.comboBLGKONTOIDKONTO.Name = "comboBLGKONTOIDKONTO";
            this.comboBLGKONTOIDKONTO.Tag = "BLGKONTOIDKONTO";
            this.comboBLGKONTOIDKONTO.TabIndex = 0;
            this.comboBLGKONTOIDKONTO.Anchor = AnchorStyles.Left;
            this.comboBLGKONTOIDKONTO.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboBLGKONTOIDKONTO.DropDownStyle = DropDownStyle.DropDown;
            this.comboBLGKONTOIDKONTO.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboBLGKONTOIDKONTO.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboBLGKONTOIDKONTO.Enabled = true;
            this.comboBLGKONTOIDKONTO.DataBindings.Add(new Binding("Value", this.bindingSourceBLAGAJNA, "BLGKONTOIDKONTO"));
            this.comboBLGKONTOIDKONTO.ShowPictureBox = true;
            this.comboBLGKONTOIDKONTO.PictureBoxClicked += new EventHandler(this.PictureBoxClickedBLGKONTOIDKONTO);
            this.comboBLGKONTOIDKONTO.ValueMember = "IDKONTO";
            this.comboBLGKONTOIDKONTO.SelectionChanged += new EventHandler(this.SelectedIndexChangedBLGKONTOIDKONTO);
            this.layoutManagerformBLAGAJNA.Controls.Add(this.comboBLGKONTOIDKONTO, 1, 2);
            this.layoutManagerformBLAGAJNA.SetColumnSpan(this.comboBLGKONTOIDKONTO, 1);
            this.layoutManagerformBLAGAJNA.SetRowSpan(this.comboBLGKONTOIDKONTO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboBLGKONTOIDKONTO.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboBLGKONTOIDKONTO.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboBLGKONTOIDKONTO.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelBLAGAJNAStavkeBlagajne.Location = point;
            this.grdLevelBLAGAJNAStavkeBlagajne.Name = "grdLevelBLAGAJNAStavkeBlagajne";
            this.layoutManagerformBLAGAJNA.Controls.Add(this.grdLevelBLAGAJNAStavkeBlagajne, 0, 3);
            this.layoutManagerformBLAGAJNA.SetColumnSpan(this.grdLevelBLAGAJNAStavkeBlagajne, 2);
            this.layoutManagerformBLAGAJNA.SetRowSpan(this.grdLevelBLAGAJNAStavkeBlagajne, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelBLAGAJNAStavkeBlagajne.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelBLAGAJNAStavkeBlagajne.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelBLAGAJNAStavkeBlagajne.Size = size;
            this.grdLevelBLAGAJNAStavkeBlagajne.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsBLAGAJNAStavkeBlagajne.Location = point;
            this.panelactionsBLAGAJNAStavkeBlagajne.Name = "panelactionsBLAGAJNAStavkeBlagajne";
            this.panelactionsBLAGAJNAStavkeBlagajne.BackColor = Color.Transparent;
            this.panelactionsBLAGAJNAStavkeBlagajne.Controls.Add(this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne);
            this.layoutManagerformBLAGAJNA.Controls.Add(this.panelactionsBLAGAJNAStavkeBlagajne, 0, 4);
            this.layoutManagerformBLAGAJNA.SetColumnSpan(this.panelactionsBLAGAJNAStavkeBlagajne, 2);
            this.layoutManagerformBLAGAJNA.SetRowSpan(this.panelactionsBLAGAJNAStavkeBlagajne, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsBLAGAJNAStavkeBlagajne.Margin = padding;
            size = new System.Drawing.Size(420, 0x19);
            this.panelactionsBLAGAJNAStavkeBlagajne.MinimumSize = size;
            size = new System.Drawing.Size(420, 0x19);
            this.panelactionsBLAGAJNAStavkeBlagajne.Size = size;
            this.panelactionsBLAGAJNAStavkeBlagajne.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelBLAGAJNAStavkeBlagajneAdd.Location = point;
            this.linkLabelBLAGAJNAStavkeBlagajneAdd.Name = "linkLabelBLAGAJNAStavkeBlagajneAdd";
            size = new System.Drawing.Size(0x74, 15);
            this.linkLabelBLAGAJNAStavkeBlagajneAdd.Size = size;
            this.linkLabelBLAGAJNAStavkeBlagajneAdd.Text = " Add StavkeBlagajne  ";
            this.linkLabelBLAGAJNAStavkeBlagajneAdd.Click += new EventHandler(this.BLAGAJNAStavkeBlagajneAdd_Click);
            this.linkLabelBLAGAJNAStavkeBlagajneAdd.BackColor = Color.Transparent;
            this.linkLabelBLAGAJNAStavkeBlagajneAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelBLAGAJNAStavkeBlagajneAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelBLAGAJNAStavkeBlagajneAdd.Cursor = Cursors.Hand;
            this.linkLabelBLAGAJNAStavkeBlagajneAdd.AutoSize = true;
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.Controls.Add(this.linkLabelBLAGAJNAStavkeBlagajneAdd, 0, 0);
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.SetColumnSpan(this.linkLabelBLAGAJNAStavkeBlagajneAdd, 1);
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.SetRowSpan(this.linkLabelBLAGAJNAStavkeBlagajneAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelBLAGAJNAStavkeBlagajneAdd.Margin = padding;
            size = new System.Drawing.Size(0x74, 15);
            this.linkLabelBLAGAJNAStavkeBlagajneAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x74, 15);
            this.linkLabelBLAGAJNAStavkeBlagajneAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate.Location = point;
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate.Name = "linkLabelBLAGAJNAStavkeBlagajneUpdate";
            size = new System.Drawing.Size(0x86, 15);
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate.Size = size;
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate.Text = " Update StavkeBlagajne  ";
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate.Click += new EventHandler(this.BLAGAJNAStavkeBlagajneUpdate_Click);
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate.BackColor = Color.Transparent;
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate.Cursor = Cursors.Hand;
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate.AutoSize = true;
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.Controls.Add(this.linkLabelBLAGAJNAStavkeBlagajneUpdate, 1, 0);
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.SetColumnSpan(this.linkLabelBLAGAJNAStavkeBlagajneUpdate, 1);
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.SetRowSpan(this.linkLabelBLAGAJNAStavkeBlagajneUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate.Margin = padding;
            size = new System.Drawing.Size(0x86, 15);
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x86, 15);
            this.linkLabelBLAGAJNAStavkeBlagajneUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelBLAGAJNAStavkeBlagajneDelete.Location = point;
            this.linkLabelBLAGAJNAStavkeBlagajneDelete.Name = "linkLabelBLAGAJNAStavkeBlagajneDelete";
            size = new System.Drawing.Size(130, 15);
            this.linkLabelBLAGAJNAStavkeBlagajneDelete.Size = size;
            this.linkLabelBLAGAJNAStavkeBlagajneDelete.Text = " Delete StavkeBlagajne  ";
            this.linkLabelBLAGAJNAStavkeBlagajneDelete.Click += new EventHandler(this.BLAGAJNAStavkeBlagajneDelete_Click);
            this.linkLabelBLAGAJNAStavkeBlagajneDelete.BackColor = Color.Transparent;
            this.linkLabelBLAGAJNAStavkeBlagajneDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelBLAGAJNAStavkeBlagajneDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelBLAGAJNAStavkeBlagajneDelete.Cursor = Cursors.Hand;
            this.linkLabelBLAGAJNAStavkeBlagajneDelete.AutoSize = true;
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.Controls.Add(this.linkLabelBLAGAJNAStavkeBlagajneDelete, 2, 0);
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.SetColumnSpan(this.linkLabelBLAGAJNAStavkeBlagajneDelete, 1);
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.SetRowSpan(this.linkLabelBLAGAJNAStavkeBlagajneDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelBLAGAJNAStavkeBlagajneDelete.Margin = padding;
            size = new System.Drawing.Size(130, 15);
            this.linkLabelBLAGAJNAStavkeBlagajneDelete.MinimumSize = size;
            size = new System.Drawing.Size(130, 15);
            this.linkLabelBLAGAJNAStavkeBlagajneDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelBLAGAJNAStavkeBlagajne.Location = point;
            this.linkLabelBLAGAJNAStavkeBlagajne.Name = "linkLabelBLAGAJNAStavkeBlagajne";
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.Controls.Add(this.linkLabelBLAGAJNAStavkeBlagajne, 3, 0);
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.SetColumnSpan(this.linkLabelBLAGAJNAStavkeBlagajne, 1);
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.SetRowSpan(this.linkLabelBLAGAJNAStavkeBlagajne, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelBLAGAJNAStavkeBlagajne.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelBLAGAJNAStavkeBlagajne.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelBLAGAJNAStavkeBlagajne.Size = size;
            this.linkLabelBLAGAJNAStavkeBlagajne.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformBLAGAJNA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceBLAGAJNA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.Disabled;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.BLAGAJNABLGDOKIDDOKUMENTDescription;
            column3.Width = 0x92;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.BLAGAJNAIDBLGVRSTEDOKDescription;
            column8.Width = 0x7e;
            appearance7.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnn";
            column8.PromptChar = ' ';
            column8.Format = "";
            column8.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.BLAGAJNAblggodineIDGODINEDescription;
            column5.Width = 0x3a;
            appearance4.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.Disabled;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.BLAGAJNANAZIVVRSTEDOKDescription;
            column9.Width = 0xe2;
            column9.Format = "";
            column9.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.BLAGAJNABLGBROJDOKUMENTADescription;
            column.Width = 0x70;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.BLAGAJNABLGDATUMDOKUMENTADescription;
            column2.Width = 100;
            column2.MinValue = DateTime.MinValue;
            column2.MaxValue = DateTime.MaxValue;
            column2.Format = "d";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.BLAGAJNABLGSVRHADescription;
            column7.Width = 0x128;
            column7.Format = "";
            column7.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.BLAGAJNABLGIZNOSDescription;
            column6.Width = 0x66;
            appearance5.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.Disabled;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.BLAGAJNABLGDOKIDDOKUMENTDescription;
            column11.Width = 0x92;
            column11.Format = "";
            column11.CellAppearance = appearance10;
            column11.Hidden = true;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.Disabled;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.BLAGAJNAIDBLGVRSTEDOKDescription;
            column24.Width = 0x7e;
            appearance19.TextHAlign = HAlign.Right;
            column24.MaskInput = "{LOC}-nnnnn";
            column24.PromptChar = ' ';
            column24.Format = "";
            column24.CellAppearance = appearance19;
            column24.Hidden = true;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.Disabled;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.BLAGAJNAblggodineIDGODINEDescription;
            column13.Width = 0x3a;
            appearance11.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnnn";
            column13.PromptChar = ' ';
            column13.Format = "";
            column13.CellAppearance = appearance11;
            column13.Hidden = true;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.Disabled;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.BLAGAJNABLGBROJDOKUMENTADescription;
            column10.Width = 0x70;
            appearance9.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnn";
            column10.PromptChar = ' ';
            column10.Format = "";
            column10.CellAppearance = appearance9;
            column10.Hidden = true;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.BLAGAJNABLGSTAVKEBLAGAJNEKONTOIDKONTODescription;
            column21.Width = 0x72;
            column21.Format = "";
            column21.CellAppearance = appearance17;
            column21.Hidden = true;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.Disabled;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.BLAGAJNABLGSTAVKEBLAGAJNEKONTONAZIVKONTODescription;
            column23.Width = 0x128;
            column23.Format = "";
            column23.CellAppearance = appearance18;
            column23.Hidden = true;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.BLAGAJNABLGMTIDMJESTOTROSKADescription;
            column15.Width = 0x48;
            column15.Format = "";
            column15.CellAppearance = appearance13;
            column15.Hidden = true;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.Disabled;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.BLAGAJNABLGMTNAZIVMJESTOTROSKADescription;
            column17.Width = 0x128;
            column17.Format = "";
            column17.CellAppearance = appearance14;
            column17.Hidden = true;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.BLAGAJNABLGORGJEDIDORGJEDDescription;
            column18.Width = 0x48;
            column18.Format = "";
            column18.CellAppearance = appearance15;
            column18.Hidden = true;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.Disabled;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.BLAGAJNABLGORGJEDNAZIVORGJEDDescription;
            column20.Width = 0x128;
            column20.Format = "";
            column20.CellAppearance = appearance16;
            column20.Hidden = true;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.BLAGAJNABLGIZNOSKONTIRANJADescription;
            column14.Width = 0x81;
            appearance12.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance12;
            column14.Hidden = true;
            band2.Columns.Add(column24);
            column24.Header.VisiblePosition = 0;
            band2.Columns.Add(column13);
            column13.Header.VisiblePosition = 1;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 2;
            band2.Columns.Add(column11);
            column11.Header.VisiblePosition = 3;
            band2.Columns.Add(column21);
            column21.Header.VisiblePosition = 4;
            band2.Columns.Add(column23);
            column23.Header.VisiblePosition = 5;
            band2.Columns.Add(column15);
            column15.Header.VisiblePosition = 6;
            band2.Columns.Add(column17);
            column17.Header.VisiblePosition = 7;
            band2.Columns.Add(column18);
            column18.Header.VisiblePosition = 8;
            band2.Columns.Add(column20);
            column20.Header.VisiblePosition = 9;
            band2.Columns.Add(column14);
            column14.Header.VisiblePosition = 10;
            band2.Hidden = true;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 0;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 1;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 3;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 4;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 5;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 6;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 7;
            this.grdLevelBLAGAJNAStavkeBlagajne.Visible = true;
            this.grdLevelBLAGAJNAStavkeBlagajne.Name = "grdLevelBLAGAJNAStavkeBlagajne";
            this.grdLevelBLAGAJNAStavkeBlagajne.Tag = "BLAGAJNAStavkeBlagajne";
            this.grdLevelBLAGAJNAStavkeBlagajne.TabIndex = 12;
            this.grdLevelBLAGAJNAStavkeBlagajne.Dock = DockStyle.Fill;
            this.grdLevelBLAGAJNAStavkeBlagajne.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelBLAGAJNAStavkeBlagajne.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelBLAGAJNAStavkeBlagajne.DataSource = this.bindingSourceBLAGAJNAStavkeBlagajne;
            this.grdLevelBLAGAJNAStavkeBlagajne.Enter += new EventHandler(this.grdLevelBLAGAJNAStavkeBlagajne_Enter);
            this.grdLevelBLAGAJNAStavkeBlagajne.AfterRowInsert += new RowEventHandler(this.grdLevelBLAGAJNAStavkeBlagajne_AfterRowInsert);
            this.grdLevelBLAGAJNAStavkeBlagajne.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelBLAGAJNAStavkeBlagajne.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelBLAGAJNAStavkeBlagajne.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelBLAGAJNAStavkeBlagajne.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelBLAGAJNAStavkeBlagajne_DoubleClick);
            this.grdLevelBLAGAJNAStavkeBlagajne.AfterRowActivate += new EventHandler(this.grdLevelBLAGAJNAStavkeBlagajne_AfterRowActivate);
            this.grdLevelBLAGAJNAStavkeBlagajne.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelBLAGAJNAStavkeBlagajne.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelBLAGAJNAStavkeBlagajne.DisplayLayout.BandsSerializer.Add(band);
            this.grdLevelBLAGAJNAStavkeBlagajne.DisplayLayout.BandsSerializer.Add(band2);
            this.Name = "BLAGAJNAFormUserControl";
            this.Text = "BLAGAJNA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.BLAGAJNAFormUserControl_Load);
            this.layoutManagerformBLAGAJNA.ResumeLayout(false);
            this.layoutManagerformBLAGAJNA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceBLAGAJNA).EndInit();
            ((ISupportInitialize) this.bindingSourceBLAGAJNAStavkeBlagajne).EndInit();
            ((ISupportInitialize) this.textNAZIVBLAGAJNA).EndInit();
            ((ISupportInitialize) this.grdLevelBLAGAJNAStavkeBlagajne).EndInit();
            this.panelactionsBLAGAJNAStavkeBlagajne.ResumeLayout(true);
            this.panelactionsBLAGAJNAStavkeBlagajne.PerformLayout();
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.ResumeLayout(false);
            this.layoutManagerpanelactionsBLAGAJNAStavkeBlagajne.PerformLayout();
            this.dsBLAGAJNADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.Controller.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceBLAGAJNA, this.Controller.WorkItem, this))
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
            this.label1BLGDOKIDDOKUMENT.Text = StringResources.BLAGAJNABLGDOKIDDOKUMENTDescription;
            this.label1NAZIVBLAGAJNA.Text = StringResources.BLAGAJNANAZIVBLAGAJNADescription;
            this.label1BLGKONTOIDKONTO.Text = StringResources.BLAGAJNABLGKONTOIDKONTODescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedBLGDOKIDDOKUMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("DOKUMENT", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedBLGKONTOIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.Controller.WorkItem.Items.Contains("BLAGAJNA|BLAGAJNA"))
            {
                this.Controller.WorkItem.Items.Add(this.bindingSourceBLAGAJNA, "BLAGAJNA|BLAGAJNA");
            }
            if (!this.Controller.WorkItem.Items.Contains("BLAGAJNA|BLAGAJNAStavkeBlagajne"))
            {
                this.Controller.WorkItem.Items.Add(this.bindingSourceBLAGAJNAStavkeBlagajne, "BLAGAJNA|BLAGAJNAStavkeBlagajne");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsBLAGAJNADataSet1.BLAGAJNA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.Controller.DataSet = new BLAGAJNADataSet();
                DataSetUtil.AddEmptyRow(this.Controller.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.Controller.DataSet.BLAGAJNA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedBLGDOKIDDOKUMENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboBLGDOKIDDOKUMENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboBLGDOKIDDOKUMENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceBLAGAJNA.Current).Row["BLGDOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(row["IDDOKUMENT"]);
                    this.bindingSourceBLAGAJNA.ResetCurrentItem();
                }
            }
        }

        private void SelectedIndexChangedBLGKONTOIDKONTO(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboBLGKONTOIDKONTO.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboBLGKONTOIDKONTO.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceBLAGAJNA.Current).Row["BLGKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(row["IDKONTO"]);
                    this.bindingSourceBLAGAJNA.ResetCurrentItem();
                }
            }
        }

        private void SetComboBoxColumnProperties()
        {
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelBLAGAJNAStavkeBlagajne, "IDBLGVRSTEDOK");
            gridColumn.Tag = "BLGVRSTEDOKIDBLGVRSTEDOK";
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            gridColumn.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            UltraGridColumn column = FormHelperClass.GetGridColumn(this.grdLevelBLAGAJNAStavkeBlagajne, "blggodineIDGODINE");
            column.Tag = "GODINEblggodineIDGODINE";
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
        }

        private void SetFocusInFirstField()
        {
            this.comboBLGDOKIDDOKUMENT.Focus();
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.BLAGAJNAController Controller { get; set; }

        protected virtual DOKUMENTComboBox comboBLGDOKIDDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboBLGDOKIDDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboBLGDOKIDDOKUMENT = value;
            }
        }

        protected virtual KONTOComboBox comboBLGKONTOIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboBLGKONTOIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboBLGKONTOIDKONTO = value;
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

        protected virtual UltraGrid grdLevelBLAGAJNAStavkeBlagajne
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelBLAGAJNAStavkeBlagajne;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelBLAGAJNAStavkeBlagajne = value;
            }
        }

        protected virtual UltraLabel label1BLGDOKIDDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BLGDOKIDDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BLGDOKIDDOKUMENT = value;
            }
        }

        protected virtual UltraLabel label1BLGKONTOIDKONTO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1BLGKONTOIDKONTO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1BLGKONTOIDKONTO = value;
            }
        }

        protected virtual UltraLabel label1NAZIVBLAGAJNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVBLAGAJNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVBLAGAJNA = value;
            }
        }

        protected virtual UltraLabel linkLabelBLAGAJNAStavkeBlagajne
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelBLAGAJNAStavkeBlagajne;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelBLAGAJNAStavkeBlagajne = value;
            }
        }

        protected virtual UltraLabel linkLabelBLAGAJNAStavkeBlagajneAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelBLAGAJNAStavkeBlagajneAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelBLAGAJNAStavkeBlagajneAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelBLAGAJNAStavkeBlagajneDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelBLAGAJNAStavkeBlagajneDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelBLAGAJNAStavkeBlagajneDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelBLAGAJNAStavkeBlagajneUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelBLAGAJNAStavkeBlagajneUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelBLAGAJNAStavkeBlagajneUpdate = value;
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

        protected virtual Panel panelactionsBLAGAJNAStavkeBlagajne
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsBLAGAJNAStavkeBlagajne;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsBLAGAJNAStavkeBlagajne = value;
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

        protected virtual UltraTextEditor textNAZIVBLAGAJNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVBLAGAJNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVBLAGAJNA = value;
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

