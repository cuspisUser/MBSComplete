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
    public class SHEMAURAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboPARTNERSHEMAURAIDPARTNER")]
        private PARTNERComboBox _comboPARTNERSHEMAURAIDPARTNER;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelSHEMAURASHEMAURAKONTIRANJE")]
        private UltraGrid _grdLevelSHEMAURASHEMAURAKONTIRANJE;
        [AccessedThroughProperty("label1IDSHEMAURA")]
        private UltraLabel _label1IDSHEMAURA;
        [AccessedThroughProperty("label1NAZIVSHEMAURA")]
        private UltraLabel _label1NAZIVSHEMAURA;
        [AccessedThroughProperty("label1PARTNERSHEMAURAIDPARTNER")]
        private UltraLabel _label1PARTNERSHEMAURAIDPARTNER;
        [AccessedThroughProperty("linkLabelSHEMAURASHEMAURAKONTIRANJE")]
        private UltraLabel _linkLabelSHEMAURASHEMAURAKONTIRANJE;
        [AccessedThroughProperty("linkLabelSHEMAURASHEMAURAKONTIRANJEAdd")]
        private UltraLabel _linkLabelSHEMAURASHEMAURAKONTIRANJEAdd;
        [AccessedThroughProperty("linkLabelSHEMAURASHEMAURAKONTIRANJEDelete")]
        private UltraLabel _linkLabelSHEMAURASHEMAURAKONTIRANJEDelete;
        [AccessedThroughProperty("linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate")]
        private UltraLabel _linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate;
        [AccessedThroughProperty("panelactionsSHEMAURASHEMAURAKONTIRANJE")]
        private Panel _panelactionsSHEMAURASHEMAURAKONTIRANJE;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDSHEMAURA")]
        private UltraNumericEditor _textIDSHEMAURA;
        [AccessedThroughProperty("textNAZIVSHEMAURA")]
        private UltraTextEditor _textNAZIVSHEMAURA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSHEMAURA;
        private BindingSource bindingSourceSHEMAURASHEMAURAKONTIRANJE;
        private IContainer components = null;
        private SHEMAURADataSet dsSHEMAURADataSet1;
        protected TableLayoutPanel layoutManagerformSHEMAURA;
        protected TableLayoutPanel layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SHEMAURADataSet.SHEMAURARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SHEMAURA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.SHEMAURADescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public SHEMAURAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsSHEMAURADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceSHEMAURA.DataSource = this.SHEMAURAController.DataSet;
            this.dsSHEMAURADataSet1 = this.SHEMAURAController.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/PARTNER", Thread=ThreadOption.UserInterface)]
        public void comboPARTNERSHEMAURAIDPARTNER_Add(object sender, ComponentEventArgs e)
        {
            this.comboPARTNERSHEMAURAIDPARTNER.Fill();
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
                    enumerator = this.dsSHEMAURADataSet1.SHEMAURA.Rows.GetEnumerator();
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
                if (this.SHEMAURAController.Update(this))
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
                    case "KONTOSHEMAURAKONTOIDKONTOAddNew":
                        this.PictureBoxClickedInLinesSHEMAURAKONTOIDKONTO(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "STRANEKNJIZENJASHEMAURASTRANEIDSTRANEKNJIZENJAAddNew":
                        this.PictureBoxClickedInLinesSHEMAURASTRANEIDSTRANEKNJIZENJA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "URAVRSTAIZNOSAIDURAVRSTAIZNOSAAddNew":
                        this.PictureBoxClickedInLinesIDURAVRSTAIZNOSA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "MJESTOTROSKASHEMAURAMTIDMJESTOTROSKAAddNew":
                        this.PictureBoxClickedInLinesSHEMAURAMTIDMJESTOTROSKA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "ORGJEDSHEMAURAOJIDORGJEDAddNew":
                        this.PictureBoxClickedInLinesSHEMAURAOJIDORGJED(RuntimeHelpers.GetObjectValue(sender), e);
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
            if (this.grdLevelSHEMAURASHEMAURAKONTIRANJE.ActiveRow != null)
            {
                this.grdLevelSHEMAURASHEMAURAKONTIRANJE.PerformAction(UltraGridAction.NextRow);
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
                if (e.Cell.Column.Key == "SHEMAURAKONTOIDKONTO")
                {
                    this.UpdateValuesSHEMAURAKONTOIDKONTO(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "SHEMAURASTRANEIDSTRANEKNJIZENJA")
                {
                    this.UpdateValuesSHEMAURASTRANEIDSTRANEKNJIZENJA(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "IDURAVRSTAIZNOSA")
                {
                    this.UpdateValuesIDURAVRSTAIZNOSA(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "SHEMAURAMTIDMJESTOTROSKA")
                {
                    this.UpdateValuesSHEMAURAMTIDMJESTOTROSKA(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "SHEMAURAOJIDORGJED")
                {
                    this.UpdateValuesSHEMAURAOJIDORGJED(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
            }
        }

        private void grdLevelSHEMAURASHEMAURAKONTIRANJE_AfterRowActivate(object sender, EventArgs e)
        {
            string sHEMAURASHEMAURASHEMAURAKONTIRANJELevelDescription = StringResources.SHEMAURASHEMAURASHEMAURAKONTIRANJELevelDescription;
            UltraGridRow activeRow = this.grdLevelSHEMAURASHEMAURAKONTIRANJE.ActiveRow;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd.Text = Deklarit.Resources.Resources.Add + " " + sHEMAURASHEMAURASHEMAURAKONTIRANJELevelDescription;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate.Text = Deklarit.Resources.Resources.Update + " " + sHEMAURASHEMAURASHEMAURAKONTIRANJELevelDescription;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete.Text = Deklarit.Resources.Resources.Delete + " " + sHEMAURASHEMAURASHEMAURAKONTIRANJELevelDescription;
        }

        private void grdLevelSHEMAURASHEMAURAKONTIRANJE_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceSHEMAURA.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceSHEMAURA.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelSHEMAURASHEMAURAKONTIRANJE_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.SHEMAURASHEMAURAKONTIRANJEUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelSHEMAURASHEMAURAKONTIRANJE_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAURA, this.SHEMAURAController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SHEMAURA", this.m_Mode, this.dsSHEMAURADataSet1, this.dsSHEMAURADataSet1.SHEMAURA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            if (!this.m_DataGrids.Contains(this.grdLevelSHEMAURASHEMAURAKONTIRANJE))
            {
                this.m_DataGrids.Add(this.grdLevelSHEMAURASHEMAURAKONTIRANJE);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsSHEMAURADataSet1.SHEMAURA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (SHEMAURADataSet.SHEMAURARow) ((DataRowView) this.bindingSourceSHEMAURA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(SHEMAURAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSHEMAURA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMAURA).BeginInit();
            this.bindingSourceSHEMAURASHEMAURAKONTIRANJE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMAURASHEMAURAKONTIRANJE).BeginInit();
            this.layoutManagerformSHEMAURA = new TableLayoutPanel();
            this.layoutManagerformSHEMAURA.SuspendLayout();
            this.layoutManagerformSHEMAURA.AutoSize = true;
            this.layoutManagerformSHEMAURA.Dock = DockStyle.Fill;
            this.layoutManagerformSHEMAURA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSHEMAURA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSHEMAURA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSHEMAURA.Size = size;
            this.layoutManagerformSHEMAURA.ColumnCount = 2;
            this.layoutManagerformSHEMAURA.RowCount = 5;
            this.layoutManagerformSHEMAURA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAURA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAURA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAURA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAURA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAURA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAURA.RowStyles.Add(new RowStyle());
            this.label1IDSHEMAURA = new UltraLabel();
            this.textIDSHEMAURA = new UltraNumericEditor();
            this.label1NAZIVSHEMAURA = new UltraLabel();
            this.textNAZIVSHEMAURA = new UltraTextEditor();
            this.label1PARTNERSHEMAURAIDPARTNER = new UltraLabel();
            this.comboPARTNERSHEMAURAIDPARTNER = new PARTNERComboBox();
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE = new UltraGrid();
            this.panelactionsSHEMAURASHEMAURAKONTIRANJE = new Panel();
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE = new TableLayoutPanel();
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.ColumnCount = 4;
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.RowCount = 1;
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.RowStyles.Add(new RowStyle());
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd = new UltraLabel();
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate = new UltraLabel();
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete = new UltraLabel();
            this.linkLabelSHEMAURASHEMAURAKONTIRANJE = new UltraLabel();
            ((ISupportInitialize) this.textIDSHEMAURA).BeginInit();
            ((ISupportInitialize) this.textNAZIVSHEMAURA).BeginInit();
            ((ISupportInitialize) this.grdLevelSHEMAURASHEMAURAKONTIRANJE).BeginInit();
            this.panelactionsSHEMAURASHEMAURAKONTIRANJE.SuspendLayout();
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.SuspendLayout();
            UltraGridBand band = new UltraGridBand("SHEMAURASHEMAURAKONTIRANJE", -1);
            UltraGridColumn column = new UltraGridColumn("IDSHEMAURA");
            UltraGridColumn column4 = new UltraGridColumn("SHEMAURAKONTOIDKONTO");
            UltraGridColumn column5 = new UltraGridColumn("columnSHEMAURAKONTOIDKONTOAddNew", 0);
            UltraGridColumn column10 = new UltraGridColumn("SHEMAURASTRANEIDSTRANEKNJIZENJA");
            UltraGridColumn column11 = new UltraGridColumn("columnSHEMAURASTRANEIDSTRANEKNJIZENJAAddNew", 1);
            UltraGridColumn column2 = new UltraGridColumn("IDURAVRSTAIZNOSA");
            UltraGridColumn column3 = new UltraGridColumn("columnIDURAVRSTAIZNOSAAddNew", 2);
            UltraGridColumn column6 = new UltraGridColumn("SHEMAURAMTIDMJESTOTROSKA");
            UltraGridColumn column7 = new UltraGridColumn("columnSHEMAURAMTIDMJESTOTROSKAAddNew", 3);
            UltraGridColumn column8 = new UltraGridColumn("SHEMAURAOJIDORGJED");
            UltraGridColumn column9 = new UltraGridColumn("columnSHEMAURAOJIDORGJEDAddNew", 4);
            this.dsSHEMAURADataSet1 = new SHEMAURADataSet();
            this.dsSHEMAURADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSHEMAURADataSet1.DataSetName = "dsSHEMAURA";
            this.dsSHEMAURADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSHEMAURA.DataSource = this.dsSHEMAURADataSet1;
            this.bindingSourceSHEMAURA.DataMember = "SHEMAURA";
            ((ISupportInitialize) this.bindingSourceSHEMAURA).BeginInit();
            this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.DataSource = this.bindingSourceSHEMAURA;
            this.bindingSourceSHEMAURASHEMAURAKONTIRANJE.DataMember = "SHEMAURA_SHEMAURASHEMAURAKONTIRANJE";
            point = new System.Drawing.Point(0, 0);
            this.label1IDSHEMAURA.Location = point;
            this.label1IDSHEMAURA.Name = "label1IDSHEMAURA";
            this.label1IDSHEMAURA.TabIndex = 1;
            this.label1IDSHEMAURA.Tag = "labelIDSHEMAURA";
            this.label1IDSHEMAURA.Text = "Šifra:";
            this.label1IDSHEMAURA.StyleSetName = "FieldUltraLabel";
            this.label1IDSHEMAURA.AutoSize = true;
            this.label1IDSHEMAURA.Anchor = AnchorStyles.Left;
            this.label1IDSHEMAURA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDSHEMAURA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDSHEMAURA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDSHEMAURA.ImageSize = size;
            this.label1IDSHEMAURA.Appearance.ForeColor = Color.Black;
            this.label1IDSHEMAURA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAURA.Controls.Add(this.label1IDSHEMAURA, 0, 0);
            this.layoutManagerformSHEMAURA.SetColumnSpan(this.label1IDSHEMAURA, 1);
            this.layoutManagerformSHEMAURA.SetRowSpan(this.label1IDSHEMAURA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDSHEMAURA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDSHEMAURA.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDSHEMAURA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDSHEMAURA.Location = point;
            this.textIDSHEMAURA.Name = "textIDSHEMAURA";
            this.textIDSHEMAURA.Tag = "IDSHEMAURA";
            this.textIDSHEMAURA.TabIndex = 0;
            this.textIDSHEMAURA.Anchor = AnchorStyles.Left;
            this.textIDSHEMAURA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDSHEMAURA.ReadOnly = false;
            this.textIDSHEMAURA.PromptChar = ' ';
            this.textIDSHEMAURA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDSHEMAURA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAURA, "IDSHEMAURA"));
            this.textIDSHEMAURA.NumericType = NumericType.Integer;
            this.textIDSHEMAURA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformSHEMAURA.Controls.Add(this.textIDSHEMAURA, 1, 0);
            this.layoutManagerformSHEMAURA.SetColumnSpan(this.textIDSHEMAURA, 1);
            this.layoutManagerformSHEMAURA.SetRowSpan(this.textIDSHEMAURA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDSHEMAURA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSHEMAURA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSHEMAURA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVSHEMAURA.Location = point;
            this.label1NAZIVSHEMAURA.Name = "label1NAZIVSHEMAURA";
            this.label1NAZIVSHEMAURA.TabIndex = 1;
            this.label1NAZIVSHEMAURA.Tag = "labelNAZIVSHEMAURA";
            this.label1NAZIVSHEMAURA.Text = "Naziv:";
            this.label1NAZIVSHEMAURA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVSHEMAURA.AutoSize = true;
            this.label1NAZIVSHEMAURA.Anchor = AnchorStyles.Left;
            this.label1NAZIVSHEMAURA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVSHEMAURA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVSHEMAURA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAURA.Controls.Add(this.label1NAZIVSHEMAURA, 0, 1);
            this.layoutManagerformSHEMAURA.SetColumnSpan(this.label1NAZIVSHEMAURA, 1);
            this.layoutManagerformSHEMAURA.SetRowSpan(this.label1NAZIVSHEMAURA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVSHEMAURA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVSHEMAURA.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1NAZIVSHEMAURA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVSHEMAURA.Location = point;
            this.textNAZIVSHEMAURA.Name = "textNAZIVSHEMAURA";
            this.textNAZIVSHEMAURA.Tag = "NAZIVSHEMAURA";
            this.textNAZIVSHEMAURA.TabIndex = 0;
            this.textNAZIVSHEMAURA.Anchor = AnchorStyles.Left;
            this.textNAZIVSHEMAURA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVSHEMAURA.ReadOnly = false;
            this.textNAZIVSHEMAURA.DataBindings.Add(new Binding("Text", this.bindingSourceSHEMAURA, "NAZIVSHEMAURA"));
            this.textNAZIVSHEMAURA.MaxLength = 50;
            this.layoutManagerformSHEMAURA.Controls.Add(this.textNAZIVSHEMAURA, 1, 1);
            this.layoutManagerformSHEMAURA.SetColumnSpan(this.textNAZIVSHEMAURA, 1);
            this.layoutManagerformSHEMAURA.SetRowSpan(this.textNAZIVSHEMAURA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVSHEMAURA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVSHEMAURA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVSHEMAURA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PARTNERSHEMAURAIDPARTNER.Location = point;
            this.label1PARTNERSHEMAURAIDPARTNER.Name = "label1PARTNERSHEMAURAIDPARTNER";
            this.label1PARTNERSHEMAURAIDPARTNER.TabIndex = 1;
            this.label1PARTNERSHEMAURAIDPARTNER.Tag = "labelPARTNERSHEMAURAIDPARTNER";
            this.label1PARTNERSHEMAURAIDPARTNER.Text = "Partner:";
            this.label1PARTNERSHEMAURAIDPARTNER.StyleSetName = "FieldUltraLabel";
            this.label1PARTNERSHEMAURAIDPARTNER.AutoSize = true;
            this.label1PARTNERSHEMAURAIDPARTNER.Anchor = AnchorStyles.Left;
            this.label1PARTNERSHEMAURAIDPARTNER.Appearance.TextVAlign = VAlign.Middle;
            this.label1PARTNERSHEMAURAIDPARTNER.Appearance.ForeColor = Color.Black;
            this.label1PARTNERSHEMAURAIDPARTNER.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAURA.Controls.Add(this.label1PARTNERSHEMAURAIDPARTNER, 0, 2);
            this.layoutManagerformSHEMAURA.SetColumnSpan(this.label1PARTNERSHEMAURAIDPARTNER, 1);
            this.layoutManagerformSHEMAURA.SetRowSpan(this.label1PARTNERSHEMAURAIDPARTNER, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PARTNERSHEMAURAIDPARTNER.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PARTNERSHEMAURAIDPARTNER.MinimumSize = size;
            size = new System.Drawing.Size(0x42, 0x17);
            this.label1PARTNERSHEMAURAIDPARTNER.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboPARTNERSHEMAURAIDPARTNER.Location = point;
            this.comboPARTNERSHEMAURAIDPARTNER.Name = "comboPARTNERSHEMAURAIDPARTNER";
            this.comboPARTNERSHEMAURAIDPARTNER.Tag = "PARTNERSHEMAURAIDPARTNER";
            this.comboPARTNERSHEMAURAIDPARTNER.TabIndex = 0;
            this.comboPARTNERSHEMAURAIDPARTNER.Anchor = AnchorStyles.Left;
            this.comboPARTNERSHEMAURAIDPARTNER.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboPARTNERSHEMAURAIDPARTNER.DropDownStyle = DropDownStyle.DropDown;
            this.comboPARTNERSHEMAURAIDPARTNER.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboPARTNERSHEMAURAIDPARTNER.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboPARTNERSHEMAURAIDPARTNER.Enabled = true;
            this.comboPARTNERSHEMAURAIDPARTNER.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAURA, "PARTNERSHEMAURAIDPARTNER"));
            this.comboPARTNERSHEMAURAIDPARTNER.ShowPictureBox = true;
            this.comboPARTNERSHEMAURAIDPARTNER.PictureBoxClicked += new EventHandler(this.PictureBoxClickedPARTNERSHEMAURAIDPARTNER);
            this.comboPARTNERSHEMAURAIDPARTNER.ValueMember = "IDPARTNER";
            this.comboPARTNERSHEMAURAIDPARTNER.SelectionChanged += new EventHandler(this.SelectedIndexChangedPARTNERSHEMAURAIDPARTNER);
            this.layoutManagerformSHEMAURA.Controls.Add(this.comboPARTNERSHEMAURAIDPARTNER, 1, 2);
            this.layoutManagerformSHEMAURA.SetColumnSpan(this.comboPARTNERSHEMAURAIDPARTNER, 1);
            this.layoutManagerformSHEMAURA.SetRowSpan(this.comboPARTNERSHEMAURAIDPARTNER, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboPARTNERSHEMAURAIDPARTNER.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboPARTNERSHEMAURAIDPARTNER.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboPARTNERSHEMAURAIDPARTNER.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.Location = point;
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.Name = "grdLevelSHEMAURASHEMAURAKONTIRANJE";
            this.layoutManagerformSHEMAURA.Controls.Add(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, 0, 3);
            this.layoutManagerformSHEMAURA.SetColumnSpan(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, 7);
            this.layoutManagerformSHEMAURA.SetRowSpan(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.MinimumSize = size;
            size = new System.Drawing.Size(0x210, 200);
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.Size = size;
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsSHEMAURASHEMAURAKONTIRANJE.Location = point;
            this.panelactionsSHEMAURASHEMAURAKONTIRANJE.Name = "panelactionsSHEMAURASHEMAURAKONTIRANJE";
            this.panelactionsSHEMAURASHEMAURAKONTIRANJE.BackColor = Color.Transparent;
            this.panelactionsSHEMAURASHEMAURAKONTIRANJE.Controls.Add(this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE);
            this.layoutManagerformSHEMAURA.Controls.Add(this.panelactionsSHEMAURASHEMAURAKONTIRANJE, 0, 4);
            this.layoutManagerformSHEMAURA.SetColumnSpan(this.panelactionsSHEMAURASHEMAURAKONTIRANJE, 7);
            this.layoutManagerformSHEMAURA.SetRowSpan(this.panelactionsSHEMAURASHEMAURAKONTIRANJE, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsSHEMAURASHEMAURAKONTIRANJE.Margin = padding;
            size = new System.Drawing.Size(0x23d, 0x19);
            this.panelactionsSHEMAURASHEMAURAKONTIRANJE.MinimumSize = size;
            size = new System.Drawing.Size(0x23d, 0x19);
            this.panelactionsSHEMAURASHEMAURAKONTIRANJE.Size = size;
            this.panelactionsSHEMAURASHEMAURAKONTIRANJE.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd.Location = point;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd.Name = "linkLabelSHEMAURASHEMAURAKONTIRANJEAdd";
            size = new System.Drawing.Size(0xa7, 15);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd.Size = size;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd.Text = " Add SHEMAURAKONTIRANJE  ";
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd.Click += new EventHandler(this.SHEMAURASHEMAURAKONTIRANJEAdd_Click);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd.BackColor = Color.Transparent;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd.Cursor = Cursors.Hand;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.Controls.Add(this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd, 0, 0);
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.SetColumnSpan(this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd, 1);
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.SetRowSpan(this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd.Margin = padding;
            size = new System.Drawing.Size(0xa7, 15);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd.MinimumSize = size;
            size = new System.Drawing.Size(0xa7, 15);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate.Location = point;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate.Name = "linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate";
            size = new System.Drawing.Size(0xb9, 15);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate.Size = size;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate.Text = " Update SHEMAURAKONTIRANJE  ";
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate.Click += new EventHandler(this.SHEMAURASHEMAURAKONTIRANJEUpdate_Click);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate.BackColor = Color.Transparent;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate.Cursor = Cursors.Hand;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.Controls.Add(this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate, 1, 0);
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.SetColumnSpan(this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate, 1);
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.SetRowSpan(this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate.Margin = padding;
            size = new System.Drawing.Size(0xb9, 15);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0xb9, 15);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete.Location = point;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete.Name = "linkLabelSHEMAURASHEMAURAKONTIRANJEDelete";
            size = new System.Drawing.Size(0xb5, 15);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete.Size = size;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete.Text = " Delete SHEMAURAKONTIRANJE  ";
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete.Click += new EventHandler(this.SHEMAURASHEMAURAKONTIRANJEDelete_Click);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete.BackColor = Color.Transparent;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete.Cursor = Cursors.Hand;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.Controls.Add(this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete, 2, 0);
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.SetColumnSpan(this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete, 1);
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.SetRowSpan(this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete.Margin = padding;
            size = new System.Drawing.Size(0xb5, 15);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete.MinimumSize = size;
            size = new System.Drawing.Size(0xb5, 15);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJE.Location = point;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJE.Name = "linkLabelSHEMAURASHEMAURAKONTIRANJE";
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.Controls.Add(this.linkLabelSHEMAURASHEMAURAKONTIRANJE, 3, 0);
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.SetColumnSpan(this.linkLabelSHEMAURASHEMAURAKONTIRANJE, 1);
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.SetRowSpan(this.linkLabelSHEMAURASHEMAURAKONTIRANJE, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJE.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJE.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSHEMAURASHEMAURAKONTIRANJE.Size = size;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJE.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformSHEMAURA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSHEMAURA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.Disabled;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.SHEMAURAIDSHEMAURADescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            column.Hidden = true;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.SHEMAURASHEMAURAKONTOIDKONTODescription;
            column4.Width = 0x72;
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
            column5.Tag = "KONTOSHEMAURAKONTOIDKONTOAddNew";
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.SHEMAURASHEMAURASTRANEIDSTRANEKNJIZENJADescription;
            column10.Width = 0x7e;
            column10.Format = "";
            column10.CellAppearance = appearance6;
            column11.AllowGroupBy = DefaultableBoolean.False;
            column11.AutoSizeEdit = DefaultableBoolean.False;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column11.CellAppearance.BorderAlpha = Alpha.Transparent;
            column11.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column11.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column11.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column11.Header.Enabled = false;
            column11.Header.Fixed = true;
            column11.Header.Caption = "";
            column11.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column11.Width = 20;
            column11.MinWidth = 20;
            column11.MaxWidth = 20;
            column11.Tag = "STRANEKNJIZENJASHEMAURASTRANEIDSTRANEKNJIZENJAAddNew";
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.SHEMAURAIDURAVRSTAIZNOSADescription;
            column2.Width = 0x63;
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
            column3.Tag = "URAVRSTAIZNOSAIDURAVRSTAIZNOSAAddNew";
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.SHEMAURASHEMAURAMTIDMJESTOTROSKADescription;
            column6.Width = 0x48;
            column6.Format = "";
            column6.CellAppearance = appearance4;
            column7.AllowGroupBy = DefaultableBoolean.False;
            column7.AutoSizeEdit = DefaultableBoolean.False;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column7.CellAppearance.BorderAlpha = Alpha.Transparent;
            column7.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column7.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column7.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column7.Header.Enabled = false;
            column7.Header.Fixed = true;
            column7.Header.Caption = "";
            column7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column7.Width = 20;
            column7.MinWidth = 20;
            column7.MaxWidth = 20;
            column7.Tag = "MJESTOTROSKASHEMAURAMTIDMJESTOTROSKAAddNew";
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.SHEMAURASHEMAURAOJIDORGJEDDescription;
            column8.Width = 0x48;
            column8.Format = "";
            column8.CellAppearance = appearance5;
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
            column9.Tag = "ORGJEDSHEMAURAOJIDORGJEDAddNew";
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 0;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 3;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 4;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 5;
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.Visible = true;
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.Name = "grdLevelSHEMAURASHEMAURAKONTIRANJE";
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.Tag = "SHEMAURASHEMAURAKONTIRANJE";
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.TabIndex = 12;
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.Dock = DockStyle.Fill;
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.DataSource = this.bindingSourceSHEMAURASHEMAURAKONTIRANJE;
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.Enter += new EventHandler(this.grdLevelSHEMAURASHEMAURAKONTIRANJE_Enter);
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.AfterRowInsert += new RowEventHandler(this.grdLevelSHEMAURASHEMAURAKONTIRANJE_AfterRowInsert);
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelSHEMAURASHEMAURAKONTIRANJE_DoubleClick);
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.AfterRowActivate += new EventHandler(this.grdLevelSHEMAURASHEMAURAKONTIRANJE_AfterRowActivate);
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.DisplayLayout.BandsSerializer.Add(band);
            this.Name = "SHEMAURAFormUserControl";
            this.Text = "Shema kontiranja URA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SHEMAURAFormUserControl_Load);
            this.layoutManagerformSHEMAURA.ResumeLayout(false);
            this.layoutManagerformSHEMAURA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSHEMAURA).EndInit();
            ((ISupportInitialize) this.bindingSourceSHEMAURASHEMAURAKONTIRANJE).EndInit();
            ((ISupportInitialize) this.textIDSHEMAURA).EndInit();
            ((ISupportInitialize) this.textNAZIVSHEMAURA).EndInit();
            ((ISupportInitialize) this.grdLevelSHEMAURASHEMAURAKONTIRANJE).EndInit();
            this.panelactionsSHEMAURASHEMAURAKONTIRANJE.ResumeLayout(true);
            this.panelactionsSHEMAURASHEMAURAKONTIRANJE.PerformLayout();
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.ResumeLayout(false);
            this.layoutManagerpanelactionsSHEMAURASHEMAURAKONTIRANJE.PerformLayout();
            this.dsSHEMAURADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.SHEMAURAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAURA, this.SHEMAURAController.WorkItem, this))
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
            this.label1IDSHEMAURA.Text = StringResources.SHEMAURAIDSHEMAURADescription;
            this.label1NAZIVSHEMAURA.Text = StringResources.SHEMAURANAZIVSHEMAURADescription;
            this.label1PARTNERSHEMAURAIDPARTNER.Text = StringResources.SHEMAURAPARTNERSHEMAURAIDPARTNERDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedInLinesIDURAVRSTAIZNOSA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("URAVRSTAIZNOSA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesSHEMAURAKONTOIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesSHEMAURAMTIDMJESTOTROSKA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("MJESTOTROSKA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesSHEMAURAOJIDORGJED(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ORGJED", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesSHEMAURASTRANEIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRANEKNJIZENJA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedPARTNERSHEMAURAIDPARTNER(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("PARTNER", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.SHEMAURAController.WorkItem.Items.Contains("SHEMAURA|SHEMAURA"))
            {
                this.SHEMAURAController.WorkItem.Items.Add(this.bindingSourceSHEMAURA, "SHEMAURA|SHEMAURA");
            }
            if (!this.SHEMAURAController.WorkItem.Items.Contains("SHEMAURA|SHEMAURASHEMAURAKONTIRANJE"))
            {
                this.SHEMAURAController.WorkItem.Items.Add(this.bindingSourceSHEMAURASHEMAURAKONTIRANJE, "SHEMAURA|SHEMAURASHEMAURAKONTIRANJE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsSHEMAURADataSet1.SHEMAURA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.SHEMAURAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.SHEMAURAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.SHEMAURAController.Update(this))
            {
                this.SHEMAURAController.DataSet = new SHEMAURADataSet();
                DataSetUtil.AddEmptyRow(this.SHEMAURAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.SHEMAURAController.DataSet.SHEMAURA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedPARTNERSHEMAURAIDPARTNER(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboPARTNERSHEMAURAIDPARTNER.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboPARTNERSHEMAURAIDPARTNER.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAURA.Current).Row["PARTNERSHEMAURAIDPARTNER"] = RuntimeHelpers.GetObjectValue(row["IDPARTNER"]);
                    this.bindingSourceSHEMAURA.ResetCurrentItem();
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
            CreateValueList(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, "KONTOSHEMAURAKONTOIDKONTO", enumList, "IDKONTO", "KONT", false);
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, "SHEMAURAKONTOIDKONTO");
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            gridColumn.ValueList = this.grdLevelSHEMAURASHEMAURAKONTIRANJE.DisplayLayout.ValueLists["KONTOSHEMAURAKONTOIDKONTO"];
            gridColumn.Width = 370;
            DataSet set5 = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(set5);
            }
            DataView view5 = new DataView(set5.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, "STRANEKNJIZENJASHEMAURASTRANEIDSTRANEKNJIZENJA", view5, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA", false);
            UltraGridColumn column5 = FormHelperClass.GetGridColumn(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, "SHEMAURASTRANEIDSTRANEKNJIZENJA");
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column5.ValueList = this.grdLevelSHEMAURASHEMAURAKONTIRANJE.DisplayLayout.ValueLists["STRANEKNJIZENJASHEMAURASTRANEIDSTRANEKNJIZENJA"];
            column5.Width = 280;
            DataSet set = new URAVRSTAIZNOSADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetURAVRSTAIZNOSADataAdapter().Fill(set);
            }
            DataView view = new DataView(set.Tables["URAVRSTAIZNOSA"]) {
                Sort = "URAVRSTAIZNOSANAZIV"
            };
            CreateValueList(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, "URAVRSTAIZNOSAIDURAVRSTAIZNOSA", view, "IDURAVRSTAIZNOSA", "URAVRSTAIZNOSANAZIV", false);
            UltraGridColumn column = FormHelperClass.GetGridColumn(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, "IDURAVRSTAIZNOSA");
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.grdLevelSHEMAURASHEMAURAKONTIRANJE.DisplayLayout.ValueLists["URAVRSTAIZNOSAIDURAVRSTAIZNOSA"];
            column.Width = 280;
            DataSet set3 = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(set3);
            }
            DataView view3 = new DataView(set3.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, "MJESTOTROSKASHEMAURAMTIDMJESTOTROSKA", view3, "IDMJESTOTROSKA", "mt", false);
            UltraGridColumn column3 = FormHelperClass.GetGridColumn(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, "SHEMAURAMTIDMJESTOTROSKA");
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column3.ValueList = this.grdLevelSHEMAURASHEMAURAKONTIRANJE.DisplayLayout.ValueLists["MJESTOTROSKASHEMAURAMTIDMJESTOTROSKA"];
            column3.Width = 370;
            DataSet set4 = new ORGJEDDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetORGJEDDataAdapter().Fill(set4);
            }
            DataView view4 = new DataView(set4.Tables["ORGJED"]) {
                Sort = "oj"
            };
            CreateValueList(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, "ORGJEDSHEMAURAOJIDORGJED", view4, "IDORGJED", "oj", false);
            UltraGridColumn column4 = FormHelperClass.GetGridColumn(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, "SHEMAURAOJIDORGJED");
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column4.ValueList = this.grdLevelSHEMAURASHEMAURAKONTIRANJE.DisplayLayout.ValueLists["ORGJEDSHEMAURAOJIDORGJED"];
            column4.Width = 370;
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelSHEMAURASHEMAURAKONTIRANJE.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.textIDSHEMAURA.Focus();
        }

        private void SetNullItem_Click(object sender, EventArgs e)
        {
            this.m_BaseMethods.SetNullItemClickBase(RuntimeHelpers.GetObjectValue(sender), this.m_CurrentRow);
        }

        private void SetSize()
        {
        }

        private void SHEMAURAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.SHEMAURADescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.SHEMAURASHEMAURASHEMAURAKONTIRANJELevelDescription;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.SHEMAURASHEMAURASHEMAURAKONTIRANJELevelDescription;
            this.linkLabelSHEMAURASHEMAURAKONTIRANJEDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.SHEMAURASHEMAURASHEMAURAKONTIRANJELevelDescription;
        }

        private void SHEMAURASHEMAURAKONTIRANJEAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelSHEMAURASHEMAURAKONTIRANJE.ActiveRow;
            this.SHEMAURASHEMAURAKONTIRANJEInsert();
        }

        private void SHEMAURASHEMAURAKONTIRANJEDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelSHEMAURASHEMAURAKONTIRANJE);
            if ((currentRowListIndex != -1) && (this.grdLevelSHEMAURASHEMAURAKONTIRANJE.Selected.Rows.Count > 0))
            {
                this.grdLevelSHEMAURASHEMAURAKONTIRANJE.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelSHEMAURASHEMAURAKONTIRANJE).Selected = true;
                this.grdLevelSHEMAURASHEMAURAKONTIRANJE.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/URAVRSTAIZNOSA", Thread=ThreadOption.UserInterface)]
        public void SHEMAURASHEMAURAKONTIRANJEIDURAVRSTAIZNOSA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new URAVRSTAIZNOSADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetURAVRSTAIZNOSADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["URAVRSTAIZNOSA"]) {
                Sort = "URAVRSTAIZNOSANAZIV"
            };
            CreateValueList(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, "URAVRSTAIZNOSAIDURAVRSTAIZNOSA", enumList, "IDURAVRSTAIZNOSA", "URAVRSTAIZNOSANAZIV", true);
        }

        private void SHEMAURASHEMAURAKONTIRANJEInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAURA, this.SHEMAURAController.WorkItem, this))
            {
                this.SHEMAURAController.AddSHEMAURASHEMAURAKONTIRANJE(this.m_CurrentRow);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void SHEMAURASHEMAURAKONTIRANJESHEMAURAKONTOIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, "KONTOSHEMAURAKONTOIDKONTO", enumList, "IDKONTO", "KONT", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/MJESTOTROSKA", Thread=ThreadOption.UserInterface)]
        public void SHEMAURASHEMAURAKONTIRANJESHEMAURAMTIDMJESTOTROSKA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, "MJESTOTROSKASHEMAURAMTIDMJESTOTROSKA", enumList, "IDMJESTOTROSKA", "mt", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ORGJED", Thread=ThreadOption.UserInterface)]
        public void SHEMAURASHEMAURAKONTIRANJESHEMAURAOJIDORGJED_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new ORGJEDDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetORGJEDDataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["ORGJED"]) {
                Sort = "oj"
            };
            CreateValueList(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, "ORGJEDSHEMAURAOJIDORGJED", enumList, "IDORGJED", "oj", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRANEKNJIZENJA", Thread=ThreadOption.UserInterface)]
        public void SHEMAURASHEMAURAKONTIRANJESHEMAURASTRANEIDSTRANEKNJIZENJA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.grdLevelSHEMAURASHEMAURAKONTIRANJE, "STRANEKNJIZENJASHEMAURASTRANEIDSTRANEKNJIZENJA", enumList, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA", true);
        }

        private void SHEMAURASHEMAURAKONTIRANJEUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelSHEMAURASHEMAURAKONTIRANJE) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelSHEMAURASHEMAURAKONTIRANJE);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.SHEMAURAController.UpdateSHEMAURASHEMAURAKONTIRANJE(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SHEMAURASHEMAURAKONTIRANJEUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelSHEMAURASHEMAURAKONTIRANJE.ActiveRow != null)
            {
                this.SHEMAURASHEMAURAKONTIRANJEUpdate();
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

        private void UpdateValuesIDURAVRSTAIZNOSA(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["IDURAVRSTAIZNOSA"] = RuntimeHelpers.GetObjectValue(result["IDURAVRSTAIZNOSA"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesSHEMAURAKONTOIDKONTO(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["SHEMAURAKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(result["IDKONTO"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesSHEMAURAMTIDMJESTOTROSKA(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["SHEMAURAMTIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(result["IDMJESTOTROSKA"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesSHEMAURAOJIDORGJED(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["SHEMAURAOJIDORGJED"] = RuntimeHelpers.GetObjectValue(result["IDORGJED"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesSHEMAURASTRANEIDSTRANEKNJIZENJA(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["SHEMAURASTRANEIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(result["IDSTRANEKNJIZENJA"]);
                }
                catch (ConstraintException exception)
                {
                    throw exception;
                    //MessageBox.Show(exception.Message, "Data Error");
                }
            }
        }

        protected virtual PARTNERComboBox comboPARTNERSHEMAURAIDPARTNER
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboPARTNERSHEMAURAIDPARTNER;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboPARTNERSHEMAURAIDPARTNER = value;
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

        protected virtual UltraGrid grdLevelSHEMAURASHEMAURAKONTIRANJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelSHEMAURASHEMAURAKONTIRANJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelSHEMAURASHEMAURAKONTIRANJE = value;
            }
        }

        protected virtual UltraLabel label1IDSHEMAURA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDSHEMAURA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDSHEMAURA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVSHEMAURA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVSHEMAURA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVSHEMAURA = value;
            }
        }

        protected virtual UltraLabel label1PARTNERSHEMAURAIDPARTNER
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PARTNERSHEMAURAIDPARTNER;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PARTNERSHEMAURAIDPARTNER = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAURASHEMAURAKONTIRANJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAURASHEMAURAKONTIRANJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAURASHEMAURAKONTIRANJE = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAURASHEMAURAKONTIRANJEAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAURASHEMAURAKONTIRANJEAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAURASHEMAURAKONTIRANJEAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAURASHEMAURAKONTIRANJEDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAURASHEMAURAKONTIRANJEDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAURASHEMAURAKONTIRANJEDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAURASHEMAURAKONTIRANJEUpdate = value;
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

        protected virtual Panel panelactionsSHEMAURASHEMAURAKONTIRANJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsSHEMAURASHEMAURAKONTIRANJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsSHEMAURASHEMAURAKONTIRANJE = value;
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
        public NetAdvantage.Controllers.SHEMAURAController SHEMAURAController { get; set; }

        protected virtual UltraNumericEditor textIDSHEMAURA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDSHEMAURA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDSHEMAURA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVSHEMAURA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVSHEMAURA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVSHEMAURA = value;
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

