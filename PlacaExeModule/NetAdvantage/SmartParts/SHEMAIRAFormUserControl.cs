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
    public class SHEMAIRAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboSHEMAIRADOKIDDOKUMENT")]
        private DOKUMENTComboBox _comboSHEMAIRADOKIDDOKUMENT;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelSHEMAIRASHEMAIRAKONTIRANJE")]
        private UltraGrid _grdLevelSHEMAIRASHEMAIRAKONTIRANJE;
        [AccessedThroughProperty("label1IDSHEMAIRA")]
        private UltraLabel _label1IDSHEMAIRA;
        [AccessedThroughProperty("label1NAZIVSHEMAIRA")]
        private UltraLabel _label1NAZIVSHEMAIRA;
        [AccessedThroughProperty("label1SHEMAIRADOKIDDOKUMENT")]
        private UltraLabel _label1SHEMAIRADOKIDDOKUMENT;
        [AccessedThroughProperty("linkLabelSHEMAIRASHEMAIRAKONTIRANJE")]
        private UltraLabel _linkLabelSHEMAIRASHEMAIRAKONTIRANJE;
        [AccessedThroughProperty("linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd")]
        private UltraLabel _linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd;
        [AccessedThroughProperty("linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete")]
        private UltraLabel _linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete;
        [AccessedThroughProperty("linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate")]
        private UltraLabel _linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate;
        [AccessedThroughProperty("panelactionsSHEMAIRASHEMAIRAKONTIRANJE")]
        private Panel _panelactionsSHEMAIRASHEMAIRAKONTIRANJE;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDSHEMAIRA")]
        private UltraNumericEditor _textIDSHEMAIRA;
        [AccessedThroughProperty("textNAZIVSHEMAIRA")]
        private UltraTextEditor _textNAZIVSHEMAIRA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSHEMAIRA;
        private BindingSource bindingSourceSHEMAIRASHEMAIRAKONTIRANJE;
        private IContainer components = null;
        private SHEMAIRADataSet dsSHEMAIRADataSet1;
        protected TableLayoutPanel layoutManagerformSHEMAIRA;
        protected TableLayoutPanel layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SHEMAIRADataSet.SHEMAIRARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SHEMAIRA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.SHEMAIRADescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public SHEMAIRAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsSHEMAIRADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceSHEMAIRA.DataSource = this.SHEMAIRAController.DataSet;
            this.dsSHEMAIRADataSet1 = this.SHEMAIRAController.DataSet;
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
        public void comboSHEMAIRADOKIDDOKUMENT_Add(object sender, ComponentEventArgs e)
        {
            this.comboSHEMAIRADOKIDDOKUMENT.Fill();
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
                    enumerator = this.dsSHEMAIRADataSet1.SHEMAIRA.Rows.GetEnumerator();
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
                if (this.SHEMAIRAController.Update(this))
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
                    case "KONTOSHEMAIRAKONTOIDKONTOAddNew":
                        this.PictureBoxClickedInLinesSHEMAIRAKONTOIDKONTO(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "STRANEKNJIZENJASHEMAIRASTRANEIDSTRANEKNJIZENJAAddNew":
                        this.PictureBoxClickedInLinesSHEMAIRASTRANEIDSTRANEKNJIZENJA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "IRAVRSTAIZNOSAIDIRAVRSTAIZNOSAAddNew":
                        this.PictureBoxClickedInLinesIDIRAVRSTAIZNOSA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "MJESTOTROSKASHEMAIRAMTIDMJESTOTROSKAAddNew":
                        this.PictureBoxClickedInLinesSHEMAIRAMTIDMJESTOTROSKA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "ORGJEDSHEMAIRAOJIDORGJEDAddNew":
                        this.PictureBoxClickedInLinesSHEMAIRAOJIDORGJED(RuntimeHelpers.GetObjectValue(sender), e);
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
            if (this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.ActiveRow != null)
            {
                this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.PerformAction(UltraGridAction.NextRow);
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
                if (e.Cell.Column.Key == "SHEMAIRAKONTOIDKONTO")
                {
                    this.UpdateValuesSHEMAIRAKONTOIDKONTO(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "SHEMAIRASTRANEIDSTRANEKNJIZENJA")
                {
                    this.UpdateValuesSHEMAIRASTRANEIDSTRANEKNJIZENJA(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "IDIRAVRSTAIZNOSA")
                {
                    this.UpdateValuesIDIRAVRSTAIZNOSA(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "SHEMAIRAMTIDMJESTOTROSKA")
                {
                    this.UpdateValuesSHEMAIRAMTIDMJESTOTROSKA(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "SHEMAIRAOJIDORGJED")
                {
                    this.UpdateValuesSHEMAIRAOJIDORGJED(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
            }
        }

        private void grdLevelSHEMAIRASHEMAIRAKONTIRANJE_AfterRowActivate(object sender, EventArgs e)
        {
            string sHEMAIRASHEMAIRASHEMAIRAKONTIRANJELevelDescription = StringResources.SHEMAIRASHEMAIRASHEMAIRAKONTIRANJELevelDescription;
            UltraGridRow activeRow = this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.ActiveRow;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd.Text = Deklarit.Resources.Resources.Add + " " + sHEMAIRASHEMAIRASHEMAIRAKONTIRANJELevelDescription;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate.Text = Deklarit.Resources.Resources.Update + " " + sHEMAIRASHEMAIRASHEMAIRAKONTIRANJELevelDescription;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete.Text = Deklarit.Resources.Resources.Delete + " " + sHEMAIRASHEMAIRASHEMAIRAKONTIRANJELevelDescription;
        }

        private void grdLevelSHEMAIRASHEMAIRAKONTIRANJE_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceSHEMAIRA.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceSHEMAIRA.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelSHEMAIRASHEMAIRAKONTIRANJE_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.SHEMAIRASHEMAIRAKONTIRANJEUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelSHEMAIRASHEMAIRAKONTIRANJE_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAIRA, this.SHEMAIRAController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SHEMAIRA", this.m_Mode, this.dsSHEMAIRADataSet1, this.dsSHEMAIRADataSet1.SHEMAIRA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            if (!this.m_DataGrids.Contains(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE))
            {
                this.m_DataGrids.Add(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsSHEMAIRADataSet1.SHEMAIRA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (SHEMAIRADataSet.SHEMAIRARow) ((DataRowView) this.bindingSourceSHEMAIRA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(SHEMAIRAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSHEMAIRA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMAIRA).BeginInit();
            this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE).BeginInit();
            this.layoutManagerformSHEMAIRA = new TableLayoutPanel();
            this.layoutManagerformSHEMAIRA.SuspendLayout();
            this.layoutManagerformSHEMAIRA.AutoSize = true;
            this.layoutManagerformSHEMAIRA.Dock = DockStyle.Fill;
            this.layoutManagerformSHEMAIRA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSHEMAIRA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSHEMAIRA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSHEMAIRA.Size = size;
            this.layoutManagerformSHEMAIRA.ColumnCount = 2;
            this.layoutManagerformSHEMAIRA.RowCount = 5;
            this.layoutManagerformSHEMAIRA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAIRA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAIRA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAIRA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAIRA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAIRA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAIRA.RowStyles.Add(new RowStyle());
            this.label1IDSHEMAIRA = new UltraLabel();
            this.textIDSHEMAIRA = new UltraNumericEditor();
            this.label1NAZIVSHEMAIRA = new UltraLabel();
            this.textNAZIVSHEMAIRA = new UltraTextEditor();
            this.label1SHEMAIRADOKIDDOKUMENT = new UltraLabel();
            this.comboSHEMAIRADOKIDDOKUMENT = new DOKUMENTComboBox();
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE = new UltraGrid();
            this.panelactionsSHEMAIRASHEMAIRAKONTIRANJE = new Panel();
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE = new TableLayoutPanel();
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.ColumnCount = 4;
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.RowCount = 1;
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.RowStyles.Add(new RowStyle());
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd = new UltraLabel();
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate = new UltraLabel();
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete = new UltraLabel();
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJE = new UltraLabel();
            ((ISupportInitialize) this.textIDSHEMAIRA).BeginInit();
            ((ISupportInitialize) this.textNAZIVSHEMAIRA).BeginInit();
            ((ISupportInitialize) this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE).BeginInit();
            this.panelactionsSHEMAIRASHEMAIRAKONTIRANJE.SuspendLayout();
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.SuspendLayout();
            UltraGridBand band = new UltraGridBand("SHEMAIRASHEMAIRAKONTIRANJE", -1);
            UltraGridColumn column3 = new UltraGridColumn("IDSHEMAIRA");
            UltraGridColumn column4 = new UltraGridColumn("SHEMAIRAKONTOIDKONTO");
            UltraGridColumn column5 = new UltraGridColumn("columnSHEMAIRAKONTOIDKONTOAddNew", 0);
            UltraGridColumn column10 = new UltraGridColumn("SHEMAIRASTRANEIDSTRANEKNJIZENJA");
            UltraGridColumn column11 = new UltraGridColumn("columnSHEMAIRASTRANEIDSTRANEKNJIZENJAAddNew", 1);
            UltraGridColumn column = new UltraGridColumn("IDIRAVRSTAIZNOSA");
            UltraGridColumn column2 = new UltraGridColumn("columnIDIRAVRSTAIZNOSAAddNew", 2);
            UltraGridColumn column6 = new UltraGridColumn("SHEMAIRAMTIDMJESTOTROSKA");
            UltraGridColumn column7 = new UltraGridColumn("columnSHEMAIRAMTIDMJESTOTROSKAAddNew", 3);
            UltraGridColumn column8 = new UltraGridColumn("SHEMAIRAOJIDORGJED");
            UltraGridColumn column9 = new UltraGridColumn("columnSHEMAIRAOJIDORGJEDAddNew", 4);
            this.dsSHEMAIRADataSet1 = new SHEMAIRADataSet();
            this.dsSHEMAIRADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSHEMAIRADataSet1.DataSetName = "dsSHEMAIRA";
            this.dsSHEMAIRADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSHEMAIRA.DataSource = this.dsSHEMAIRADataSet1;
            this.bindingSourceSHEMAIRA.DataMember = "SHEMAIRA";
            ((ISupportInitialize) this.bindingSourceSHEMAIRA).BeginInit();
            this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.DataSource = this.bindingSourceSHEMAIRA;
            this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE.DataMember = "SHEMAIRA_SHEMAIRASHEMAIRAKONTIRANJE";
            point = new System.Drawing.Point(0, 0);
            this.label1IDSHEMAIRA.Location = point;
            this.label1IDSHEMAIRA.Name = "label1IDSHEMAIRA";
            this.label1IDSHEMAIRA.TabIndex = 1;
            this.label1IDSHEMAIRA.Tag = "labelIDSHEMAIRA";
            this.label1IDSHEMAIRA.Text = "Šifra:";
            this.label1IDSHEMAIRA.StyleSetName = "FieldUltraLabel";
            this.label1IDSHEMAIRA.AutoSize = true;
            this.label1IDSHEMAIRA.Anchor = AnchorStyles.Left;
            this.label1IDSHEMAIRA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDSHEMAIRA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDSHEMAIRA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDSHEMAIRA.ImageSize = size;
            this.label1IDSHEMAIRA.Appearance.ForeColor = Color.Black;
            this.label1IDSHEMAIRA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAIRA.Controls.Add(this.label1IDSHEMAIRA, 0, 0);
            this.layoutManagerformSHEMAIRA.SetColumnSpan(this.label1IDSHEMAIRA, 1);
            this.layoutManagerformSHEMAIRA.SetRowSpan(this.label1IDSHEMAIRA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDSHEMAIRA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDSHEMAIRA.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDSHEMAIRA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDSHEMAIRA.Location = point;
            this.textIDSHEMAIRA.Name = "textIDSHEMAIRA";
            this.textIDSHEMAIRA.Tag = "IDSHEMAIRA";
            this.textIDSHEMAIRA.TabIndex = 0;
            this.textIDSHEMAIRA.Anchor = AnchorStyles.Left;
            this.textIDSHEMAIRA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDSHEMAIRA.ReadOnly = false;
            this.textIDSHEMAIRA.PromptChar = ' ';
            this.textIDSHEMAIRA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDSHEMAIRA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAIRA, "IDSHEMAIRA"));
            this.textIDSHEMAIRA.NumericType = NumericType.Integer;
            this.textIDSHEMAIRA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformSHEMAIRA.Controls.Add(this.textIDSHEMAIRA, 1, 0);
            this.layoutManagerformSHEMAIRA.SetColumnSpan(this.textIDSHEMAIRA, 1);
            this.layoutManagerformSHEMAIRA.SetRowSpan(this.textIDSHEMAIRA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDSHEMAIRA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSHEMAIRA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSHEMAIRA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVSHEMAIRA.Location = point;
            this.label1NAZIVSHEMAIRA.Name = "label1NAZIVSHEMAIRA";
            this.label1NAZIVSHEMAIRA.TabIndex = 1;
            this.label1NAZIVSHEMAIRA.Tag = "labelNAZIVSHEMAIRA";
            this.label1NAZIVSHEMAIRA.Text = "Naziv:";
            this.label1NAZIVSHEMAIRA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVSHEMAIRA.AutoSize = true;
            this.label1NAZIVSHEMAIRA.Anchor = AnchorStyles.Left;
            this.label1NAZIVSHEMAIRA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVSHEMAIRA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVSHEMAIRA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAIRA.Controls.Add(this.label1NAZIVSHEMAIRA, 0, 1);
            this.layoutManagerformSHEMAIRA.SetColumnSpan(this.label1NAZIVSHEMAIRA, 1);
            this.layoutManagerformSHEMAIRA.SetRowSpan(this.label1NAZIVSHEMAIRA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVSHEMAIRA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVSHEMAIRA.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1NAZIVSHEMAIRA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVSHEMAIRA.Location = point;
            this.textNAZIVSHEMAIRA.Name = "textNAZIVSHEMAIRA";
            this.textNAZIVSHEMAIRA.Tag = "NAZIVSHEMAIRA";
            this.textNAZIVSHEMAIRA.TabIndex = 0;
            this.textNAZIVSHEMAIRA.Anchor = AnchorStyles.Left;
            this.textNAZIVSHEMAIRA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVSHEMAIRA.ReadOnly = false;
            this.textNAZIVSHEMAIRA.DataBindings.Add(new Binding("Text", this.bindingSourceSHEMAIRA, "NAZIVSHEMAIRA"));
            this.textNAZIVSHEMAIRA.MaxLength = 50;
            this.layoutManagerformSHEMAIRA.Controls.Add(this.textNAZIVSHEMAIRA, 1, 1);
            this.layoutManagerformSHEMAIRA.SetColumnSpan(this.textNAZIVSHEMAIRA, 1);
            this.layoutManagerformSHEMAIRA.SetRowSpan(this.textNAZIVSHEMAIRA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVSHEMAIRA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVSHEMAIRA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVSHEMAIRA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMAIRADOKIDDOKUMENT.Location = point;
            this.label1SHEMAIRADOKIDDOKUMENT.Name = "label1SHEMAIRADOKIDDOKUMENT";
            this.label1SHEMAIRADOKIDDOKUMENT.TabIndex = 1;
            this.label1SHEMAIRADOKIDDOKUMENT.Tag = "labelSHEMAIRADOKIDDOKUMENT";
            this.label1SHEMAIRADOKIDDOKUMENT.Text = "Dokument:";
            this.label1SHEMAIRADOKIDDOKUMENT.StyleSetName = "FieldUltraLabel";
            this.label1SHEMAIRADOKIDDOKUMENT.AutoSize = true;
            this.label1SHEMAIRADOKIDDOKUMENT.Anchor = AnchorStyles.Left;
            this.label1SHEMAIRADOKIDDOKUMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMAIRADOKIDDOKUMENT.Appearance.ForeColor = Color.Black;
            this.label1SHEMAIRADOKIDDOKUMENT.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAIRA.Controls.Add(this.label1SHEMAIRADOKIDDOKUMENT, 0, 2);
            this.layoutManagerformSHEMAIRA.SetColumnSpan(this.label1SHEMAIRADOKIDDOKUMENT, 1);
            this.layoutManagerformSHEMAIRA.SetRowSpan(this.label1SHEMAIRADOKIDDOKUMENT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SHEMAIRADOKIDDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMAIRADOKIDDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x54, 0x17);
            this.label1SHEMAIRADOKIDDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSHEMAIRADOKIDDOKUMENT.Location = point;
            this.comboSHEMAIRADOKIDDOKUMENT.Name = "comboSHEMAIRADOKIDDOKUMENT";
            this.comboSHEMAIRADOKIDDOKUMENT.Tag = "SHEMAIRADOKIDDOKUMENT";
            this.comboSHEMAIRADOKIDDOKUMENT.TabIndex = 0;
            this.comboSHEMAIRADOKIDDOKUMENT.Anchor = AnchorStyles.Left;
            this.comboSHEMAIRADOKIDDOKUMENT.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSHEMAIRADOKIDDOKUMENT.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAIRADOKIDDOKUMENT.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAIRADOKIDDOKUMENT.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSHEMAIRADOKIDDOKUMENT.Enabled = true;
            this.comboSHEMAIRADOKIDDOKUMENT.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAIRA, "SHEMAIRADOKIDDOKUMENT"));
            this.comboSHEMAIRADOKIDDOKUMENT.ShowPictureBox = true;
            this.comboSHEMAIRADOKIDDOKUMENT.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSHEMAIRADOKIDDOKUMENT);
            this.comboSHEMAIRADOKIDDOKUMENT.ValueMember = "IDDOKUMENT";
            this.comboSHEMAIRADOKIDDOKUMENT.SelectionChanged += new EventHandler(this.SelectedIndexChangedSHEMAIRADOKIDDOKUMENT);
            this.layoutManagerformSHEMAIRA.Controls.Add(this.comboSHEMAIRADOKIDDOKUMENT, 1, 2);
            this.layoutManagerformSHEMAIRA.SetColumnSpan(this.comboSHEMAIRADOKIDDOKUMENT, 1);
            this.layoutManagerformSHEMAIRA.SetRowSpan(this.comboSHEMAIRADOKIDDOKUMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSHEMAIRADOKIDDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboSHEMAIRADOKIDDOKUMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboSHEMAIRADOKIDDOKUMENT.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.Location = point;
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.Name = "grdLevelSHEMAIRASHEMAIRAKONTIRANJE";
            this.layoutManagerformSHEMAIRA.Controls.Add(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, 0, 3);
            this.layoutManagerformSHEMAIRA.SetColumnSpan(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, 7);
            this.layoutManagerformSHEMAIRA.SetRowSpan(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.MinimumSize = size;
            size = new System.Drawing.Size(0x210, 200);
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.Size = size;
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsSHEMAIRASHEMAIRAKONTIRANJE.Location = point;
            this.panelactionsSHEMAIRASHEMAIRAKONTIRANJE.Name = "panelactionsSHEMAIRASHEMAIRAKONTIRANJE";
            this.panelactionsSHEMAIRASHEMAIRAKONTIRANJE.BackColor = Color.Transparent;
            this.panelactionsSHEMAIRASHEMAIRAKONTIRANJE.Controls.Add(this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE);
            this.layoutManagerformSHEMAIRA.Controls.Add(this.panelactionsSHEMAIRASHEMAIRAKONTIRANJE, 0, 4);
            this.layoutManagerformSHEMAIRA.SetColumnSpan(this.panelactionsSHEMAIRASHEMAIRAKONTIRANJE, 7);
            this.layoutManagerformSHEMAIRA.SetRowSpan(this.panelactionsSHEMAIRASHEMAIRAKONTIRANJE, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsSHEMAIRASHEMAIRAKONTIRANJE.Margin = padding;
            size = new System.Drawing.Size(0x232, 0x19);
            this.panelactionsSHEMAIRASHEMAIRAKONTIRANJE.MinimumSize = size;
            size = new System.Drawing.Size(0x232, 0x19);
            this.panelactionsSHEMAIRASHEMAIRAKONTIRANJE.Size = size;
            this.panelactionsSHEMAIRASHEMAIRAKONTIRANJE.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd.Location = point;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd.Name = "linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd";
            size = new System.Drawing.Size(0xa4, 15);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd.Size = size;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd.Text = " Add SHEMAIRAKONTIRANJE  ";
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd.Click += new EventHandler(this.SHEMAIRASHEMAIRAKONTIRANJEAdd_Click);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd.BackColor = Color.Transparent;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd.Cursor = Cursors.Hand;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.Controls.Add(this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd, 0, 0);
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.SetColumnSpan(this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd, 1);
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.SetRowSpan(this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd.Margin = padding;
            size = new System.Drawing.Size(0xa4, 15);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd.MinimumSize = size;
            size = new System.Drawing.Size(0xa4, 15);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate.Location = point;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate.Name = "linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate";
            size = new System.Drawing.Size(0xb5, 15);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate.Size = size;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate.Text = " Update SHEMAIRAKONTIRANJE  ";
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate.Click += new EventHandler(this.SHEMAIRASHEMAIRAKONTIRANJEUpdate_Click);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate.BackColor = Color.Transparent;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate.Cursor = Cursors.Hand;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.Controls.Add(this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate, 1, 0);
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.SetColumnSpan(this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate, 1);
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.SetRowSpan(this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate.Margin = padding;
            size = new System.Drawing.Size(0xb5, 15);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0xb5, 15);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete.Location = point;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete.Name = "linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete";
            size = new System.Drawing.Size(0xb1, 15);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete.Size = size;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete.Text = " Delete SHEMAIRAKONTIRANJE  ";
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete.Click += new EventHandler(this.SHEMAIRASHEMAIRAKONTIRANJEDelete_Click);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete.BackColor = Color.Transparent;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete.Cursor = Cursors.Hand;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.Controls.Add(this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete, 2, 0);
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.SetColumnSpan(this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete, 1);
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.SetRowSpan(this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete.Margin = padding;
            size = new System.Drawing.Size(0xb1, 15);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete.MinimumSize = size;
            size = new System.Drawing.Size(0xb1, 15);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJE.Location = point;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJE.Name = "linkLabelSHEMAIRASHEMAIRAKONTIRANJE";
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.Controls.Add(this.linkLabelSHEMAIRASHEMAIRAKONTIRANJE, 3, 0);
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.SetColumnSpan(this.linkLabelSHEMAIRASHEMAIRAKONTIRANJE, 1);
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.SetRowSpan(this.linkLabelSHEMAIRASHEMAIRAKONTIRANJE, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJE.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJE.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJE.Size = size;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJE.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformSHEMAIRA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSHEMAIRA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.Disabled;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.SHEMAIRAIDSHEMAIRADescription;
            column3.Width = 0x33;
            appearance2.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance2;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.SHEMAIRASHEMAIRAKONTOIDKONTODescription;
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
            column5.Tag = "KONTOSHEMAIRAKONTOIDKONTOAddNew";
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.SHEMAIRASHEMAIRASTRANEIDSTRANEKNJIZENJADescription;
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
            column11.Tag = "STRANEKNJIZENJASHEMAIRASTRANEIDSTRANEKNJIZENJAAddNew";
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.SHEMAIRAIDIRAVRSTAIZNOSADescription;
            column.Width = 0x63;
            column.Format = "";
            column.CellAppearance = appearance;
            column2.AllowGroupBy = DefaultableBoolean.False;
            column2.AutoSizeEdit = DefaultableBoolean.False;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column2.CellAppearance.BorderAlpha = Alpha.Transparent;
            column2.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column2.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column2.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column2.Header.Enabled = false;
            column2.Header.Fixed = true;
            column2.Header.Caption = "";
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column2.Width = 20;
            column2.MinWidth = 20;
            column2.MaxWidth = 20;
            column2.Tag = "IRAVRSTAIZNOSAIDIRAVRSTAIZNOSAAddNew";
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.SHEMAIRASHEMAIRAMTIDMJESTOTROSKADescription;
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
            column7.Tag = "MJESTOTROSKASHEMAIRAMTIDMJESTOTROSKAAddNew";
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.SHEMAIRASHEMAIRAOJIDORGJEDDescription;
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
            column9.Tag = "ORGJEDSHEMAIRAOJIDORGJEDAddNew";
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 0;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 3;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 4;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 5;
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.Visible = true;
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.Name = "grdLevelSHEMAIRASHEMAIRAKONTIRANJE";
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.Tag = "SHEMAIRASHEMAIRAKONTIRANJE";
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.TabIndex = 12;
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.Dock = DockStyle.Fill;
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.DataSource = this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE;
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.Enter += new EventHandler(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE_Enter);
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.AfterRowInsert += new RowEventHandler(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE_AfterRowInsert);
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE_DoubleClick);
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.AfterRowActivate += new EventHandler(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE_AfterRowActivate);
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.DisplayLayout.BandsSerializer.Add(band);
            this.Name = "SHEMAIRAFormUserControl";
            this.Text = "Shema kontiranja IRA";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SHEMAIRAFormUserControl_Load);
            this.layoutManagerformSHEMAIRA.ResumeLayout(false);
            this.layoutManagerformSHEMAIRA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSHEMAIRA).EndInit();
            ((ISupportInitialize) this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE).EndInit();
            ((ISupportInitialize) this.textIDSHEMAIRA).EndInit();
            ((ISupportInitialize) this.textNAZIVSHEMAIRA).EndInit();
            ((ISupportInitialize) this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE).EndInit();
            this.panelactionsSHEMAIRASHEMAIRAKONTIRANJE.ResumeLayout(true);
            this.panelactionsSHEMAIRASHEMAIRAKONTIRANJE.PerformLayout();
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.ResumeLayout(false);
            this.layoutManagerpanelactionsSHEMAIRASHEMAIRAKONTIRANJE.PerformLayout();
            this.dsSHEMAIRADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.SHEMAIRAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAIRA, this.SHEMAIRAController.WorkItem, this))
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
            this.label1IDSHEMAIRA.Text = StringResources.SHEMAIRAIDSHEMAIRADescription;
            this.label1NAZIVSHEMAIRA.Text = StringResources.SHEMAIRANAZIVSHEMAIRADescription;
            this.label1SHEMAIRADOKIDDOKUMENT.Text = StringResources.SHEMAIRASHEMAIRADOKIDDOKUMENTDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedInLinesIDIRAVRSTAIZNOSA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("IRAVRSTAIZNOSA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesSHEMAIRAKONTOIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesSHEMAIRAMTIDMJESTOTROSKA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("MJESTOTROSKA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesSHEMAIRAOJIDORGJED(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ORGJED", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesSHEMAIRASTRANEIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRANEKNJIZENJA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSHEMAIRADOKIDDOKUMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("DOKUMENT", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.SHEMAIRAController.WorkItem.Items.Contains("SHEMAIRA|SHEMAIRA"))
            {
                this.SHEMAIRAController.WorkItem.Items.Add(this.bindingSourceSHEMAIRA, "SHEMAIRA|SHEMAIRA");
            }
            if (!this.SHEMAIRAController.WorkItem.Items.Contains("SHEMAIRA|SHEMAIRASHEMAIRAKONTIRANJE"))
            {
                this.SHEMAIRAController.WorkItem.Items.Add(this.bindingSourceSHEMAIRASHEMAIRAKONTIRANJE, "SHEMAIRA|SHEMAIRASHEMAIRAKONTIRANJE");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsSHEMAIRADataSet1.SHEMAIRA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.SHEMAIRAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.SHEMAIRAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.SHEMAIRAController.Update(this))
            {
                this.SHEMAIRAController.DataSet = new SHEMAIRADataSet();
                DataSetUtil.AddEmptyRow(this.SHEMAIRAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.SHEMAIRAController.DataSet.SHEMAIRA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedSHEMAIRADOKIDDOKUMENT(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSHEMAIRADOKIDDOKUMENT.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSHEMAIRADOKIDDOKUMENT.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAIRA.Current).Row["SHEMAIRADOKIDDOKUMENT"] = RuntimeHelpers.GetObjectValue(row["IDDOKUMENT"]);
                    this.bindingSourceSHEMAIRA.ResetCurrentItem();
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
            CreateValueList(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, "KONTOSHEMAIRAKONTOIDKONTO", enumList, "IDKONTO", "KONT", false);
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, "SHEMAIRAKONTOIDKONTO");
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            gridColumn.ValueList = this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.DisplayLayout.ValueLists["KONTOSHEMAIRAKONTOIDKONTO"];
            gridColumn.Width = 370;
            DataSet set5 = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(set5);
            }
            DataView view5 = new DataView(set5.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, "STRANEKNJIZENJASHEMAIRASTRANEIDSTRANEKNJIZENJA", view5, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA", false);
            UltraGridColumn column5 = FormHelperClass.GetGridColumn(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, "SHEMAIRASTRANEIDSTRANEKNJIZENJA");
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column5.ValueList = this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.DisplayLayout.ValueLists["STRANEKNJIZENJASHEMAIRASTRANEIDSTRANEKNJIZENJA"];
            column5.Width = 280;
            DataSet set = new IRAVRSTAIZNOSADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetIRAVRSTAIZNOSADataAdapter().Fill(set);
            }
            DataView view = new DataView(set.Tables["IRAVRSTAIZNOSA"]) {
                Sort = "IRAVRSTAIZNOSANAZIV"
            };
            CreateValueList(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, "IRAVRSTAIZNOSAIDIRAVRSTAIZNOSA", view, "IDIRAVRSTAIZNOSA", "IRAVRSTAIZNOSANAZIV", false);
            UltraGridColumn column = FormHelperClass.GetGridColumn(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, "IDIRAVRSTAIZNOSA");
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.DisplayLayout.ValueLists["IRAVRSTAIZNOSAIDIRAVRSTAIZNOSA"];
            column.Width = 280;
            DataSet set3 = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(set3);
            }
            DataView view3 = new DataView(set3.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, "MJESTOTROSKASHEMAIRAMTIDMJESTOTROSKA", view3, "IDMJESTOTROSKA", "mt", false);
            UltraGridColumn column3 = FormHelperClass.GetGridColumn(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, "SHEMAIRAMTIDMJESTOTROSKA");
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column3.ValueList = this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.DisplayLayout.ValueLists["MJESTOTROSKASHEMAIRAMTIDMJESTOTROSKA"];
            column3.Width = 370;
            DataSet set4 = new ORGJEDDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetORGJEDDataAdapter().Fill(set4);
            }
            DataView view4 = new DataView(set4.Tables["ORGJED"]) {
                Sort = "oj"
            };
            CreateValueList(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, "ORGJEDSHEMAIRAOJIDORGJED", view4, "IDORGJED", "oj", false);
            UltraGridColumn column4 = FormHelperClass.GetGridColumn(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, "SHEMAIRAOJIDORGJED");
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column4.ValueList = this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.DisplayLayout.ValueLists["ORGJEDSHEMAIRAOJIDORGJED"];
            column4.Width = 370;
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.textIDSHEMAIRA.Focus();
        }

        private void SetNullItem_Click(object sender, EventArgs e)
        {
            this.m_BaseMethods.SetNullItemClickBase(RuntimeHelpers.GetObjectValue(sender), this.m_CurrentRow);
        }

        private void SetSize()
        {
        }

        private void SHEMAIRAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.SHEMAIRADescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.SHEMAIRASHEMAIRASHEMAIRAKONTIRANJELevelDescription;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.SHEMAIRASHEMAIRASHEMAIRAKONTIRANJELevelDescription;
            this.linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.SHEMAIRASHEMAIRASHEMAIRAKONTIRANJELevelDescription;
        }

        private void SHEMAIRASHEMAIRAKONTIRANJEAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.ActiveRow;
            this.SHEMAIRASHEMAIRAKONTIRANJEInsert();
        }

        private void SHEMAIRASHEMAIRAKONTIRANJEDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE);
            if ((currentRowListIndex != -1) && (this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.Selected.Rows.Count > 0))
            {
                this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE).Selected = true;
                this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/IRAVRSTAIZNOSA", Thread=ThreadOption.UserInterface)]
        public void SHEMAIRASHEMAIRAKONTIRANJEIDIRAVRSTAIZNOSA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new IRAVRSTAIZNOSADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetIRAVRSTAIZNOSADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["IRAVRSTAIZNOSA"]) {
                Sort = "IRAVRSTAIZNOSANAZIV"
            };
            CreateValueList(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, "IRAVRSTAIZNOSAIDIRAVRSTAIZNOSA", enumList, "IDIRAVRSTAIZNOSA", "IRAVRSTAIZNOSANAZIV", true);
        }

        private void SHEMAIRASHEMAIRAKONTIRANJEInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAIRA, this.SHEMAIRAController.WorkItem, this))
            {
                this.SHEMAIRAController.AddSHEMAIRASHEMAIRAKONTIRANJE(this.m_CurrentRow);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void SHEMAIRASHEMAIRAKONTIRANJESHEMAIRAKONTOIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, "KONTOSHEMAIRAKONTOIDKONTO", enumList, "IDKONTO", "KONT", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/MJESTOTROSKA", Thread=ThreadOption.UserInterface)]
        public void SHEMAIRASHEMAIRAKONTIRANJESHEMAIRAMTIDMJESTOTROSKA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, "MJESTOTROSKASHEMAIRAMTIDMJESTOTROSKA", enumList, "IDMJESTOTROSKA", "mt", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ORGJED", Thread=ThreadOption.UserInterface)]
        public void SHEMAIRASHEMAIRAKONTIRANJESHEMAIRAOJIDORGJED_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new ORGJEDDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetORGJEDDataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["ORGJED"]) {
                Sort = "oj"
            };
            CreateValueList(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, "ORGJEDSHEMAIRAOJIDORGJED", enumList, "IDORGJED", "oj", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRANEKNJIZENJA", Thread=ThreadOption.UserInterface)]
        public void SHEMAIRASHEMAIRAKONTIRANJESHEMAIRASTRANEIDSTRANEKNJIZENJA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE, "STRANEKNJIZENJASHEMAIRASTRANEIDSTRANEKNJIZENJA", enumList, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA", true);
        }

        private void SHEMAIRASHEMAIRAKONTIRANJEUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.SHEMAIRAController.UpdateSHEMAIRASHEMAIRAKONTIRANJE(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SHEMAIRASHEMAIRAKONTIRANJEUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelSHEMAIRASHEMAIRAKONTIRANJE.ActiveRow != null)
            {
                this.SHEMAIRASHEMAIRAKONTIRANJEUpdate();
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

        private void UpdateValuesIDIRAVRSTAIZNOSA(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["IDIRAVRSTAIZNOSA"] = RuntimeHelpers.GetObjectValue(result["IDIRAVRSTAIZNOSA"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesSHEMAIRAKONTOIDKONTO(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["SHEMAIRAKONTOIDKONTO"] = RuntimeHelpers.GetObjectValue(result["IDKONTO"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesSHEMAIRAMTIDMJESTOTROSKA(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["SHEMAIRAMTIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(result["IDMJESTOTROSKA"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesSHEMAIRAOJIDORGJED(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["SHEMAIRAOJIDORGJED"] = RuntimeHelpers.GetObjectValue(result["IDORGJED"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesSHEMAIRASTRANEIDSTRANEKNJIZENJA(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["SHEMAIRASTRANEIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(result["IDSTRANEKNJIZENJA"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        protected virtual DOKUMENTComboBox comboSHEMAIRADOKIDDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSHEMAIRADOKIDDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSHEMAIRADOKIDDOKUMENT = value;
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

        protected virtual UltraGrid grdLevelSHEMAIRASHEMAIRAKONTIRANJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelSHEMAIRASHEMAIRAKONTIRANJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelSHEMAIRASHEMAIRAKONTIRANJE = value;
            }
        }

        protected virtual UltraLabel label1IDSHEMAIRA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDSHEMAIRA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDSHEMAIRA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVSHEMAIRA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVSHEMAIRA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVSHEMAIRA = value;
            }
        }

        protected virtual UltraLabel label1SHEMAIRADOKIDDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMAIRADOKIDDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMAIRADOKIDDOKUMENT = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAIRASHEMAIRAKONTIRANJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAIRASHEMAIRAKONTIRANJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAIRASHEMAIRAKONTIRANJE = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAIRASHEMAIRAKONTIRANJEAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAIRASHEMAIRAKONTIRANJEDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAIRASHEMAIRAKONTIRANJEUpdate = value;
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

        protected virtual Panel panelactionsSHEMAIRASHEMAIRAKONTIRANJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsSHEMAIRASHEMAIRAKONTIRANJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsSHEMAIRASHEMAIRAKONTIRANJE = value;
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.SHEMAIRAController SHEMAIRAController { get; set; }

        protected virtual UltraNumericEditor textIDSHEMAIRA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDSHEMAIRA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDSHEMAIRA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVSHEMAIRA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVSHEMAIRA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVSHEMAIRA = value;
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

