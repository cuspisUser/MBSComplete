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
    public class PLANFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelPLANORG")]
        private UltraGrid _grdLevelPLANORG;
        [AccessedThroughProperty("label1IDPLAN")]
        private UltraLabel _label1IDPLAN;
        [AccessedThroughProperty("label1PLANGODINAIDGODINE")]
        private UltraLabel _label1PLANGODINAIDGODINE;
        [AccessedThroughProperty("label1RADNINAZIVPLANA")]
        private UltraLabel _label1RADNINAZIVPLANA;
        [AccessedThroughProperty("linkLabelPLANORG")]
        private UltraLabel _linkLabelPLANORG;
        [AccessedThroughProperty("linkLabelPLANORGAdd")]
        private UltraLabel _linkLabelPLANORGAdd;
        [AccessedThroughProperty("linkLabelPLANORGDelete")]
        private UltraLabel _linkLabelPLANORGDelete;
        [AccessedThroughProperty("linkLabelPLANORGUpdate")]
        private UltraLabel _linkLabelPLANORGUpdate;
        [AccessedThroughProperty("panelactionsPLANORG")]
        private Panel _panelactionsPLANORG;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDPLAN")]
        private UltraNumericEditor _textIDPLAN;
        [AccessedThroughProperty("textPLANGODINAIDGODINE")]
        private UltraNumericEditor _textPLANGODINAIDGODINE;
        [AccessedThroughProperty("textRADNINAZIVPLANA")]
        private UltraTextEditor _textRADNINAZIVPLANA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourcePLAN;
        private BindingSource bindingSourcePLANORG;
        private IContainer components = null;
        private PLANDataSet dsPLANDataSet1;
        protected TableLayoutPanel layoutManagerformPLAN;
        protected TableLayoutPanel layoutManagerpanelactionsPLANORG;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private PLANDataSet.PLANRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "PLAN";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.PLANDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public PLANFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptGODINEPLANGODINAIDGODINE(object sender, EditorButtonEventArgs e)
        {
            DataRow fillByRow = null;
            string fillMethod = "";
            DataRow result = this.PLANController.SelectGODINEPLANGODINAIDGODINE(fillMethod, fillByRow);
            this.UpdateValuesGODINEPLANGODINAIDGODINE(result);
        }

        private void CallViewGODINEPLANGODINAIDGODINE(object sender, EventArgs e)
        {
            DataRow result = this.PLANController.ShowGODINEPLANGODINAIDGODINE(this.m_CurrentRow);
            this.UpdateValuesGODINEPLANGODINAIDGODINE(result);
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsPLANDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourcePLAN.DataSource = this.PLANController.DataSet;
            this.dsPLANDataSet1 = this.PLANController.DataSet;
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
                    enumerator = this.dsPLANDataSet1.PLAN.Rows.GetEnumerator();
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
                if (this.PLANController.Update(this))
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
                    case "ORGJEDPLANOJIDORGJEDAddNew":
                        this.PictureBoxClickedInLinesPLANOJIDORGJED(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "KONTOPLANKONTOIDKONTOAddNew":
                        this.PictureBoxClickedInLinesPLANKONTOIDKONTO(RuntimeHelpers.GetObjectValue(sender), e);
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
            if (this.grdLevelPLANORG.ActiveRow != null)
            {
                this.grdLevelPLANORG.PerformAction(UltraGridAction.NextRow);
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
                if (e.Cell.Column.Key == "PLANOJIDORGJED")
                {
                    this.UpdateValuesPLANOJIDORGJED(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "PLANKONTOIDKONTO")
                {
                    this.UpdateValuesPLANKONTOIDKONTO(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
            }
        }

        private void grdLevelPLANORG_AfterRowActivate(object sender, EventArgs e)
        {
            string pLANPLANORGLevelDescription = StringResources.PLANPLANORGLevelDescription;
            if ((this.grdLevelPLANORG.ActiveRow != null) && this.grdLevelPLANORG.ActiveRow.Band.Key.EndsWith("_PLANORGKON"))
            {
                pLANPLANORGLevelDescription = StringResources.PLANPLANORGKONLevelDescription;
            }
            this.linkLabelPLANORGAdd.Text = Deklarit.Resources.Resources.Add + " " + pLANPLANORGLevelDescription;
            this.linkLabelPLANORGUpdate.Text = Deklarit.Resources.Resources.Update + " " + pLANPLANORGLevelDescription;
            this.linkLabelPLANORGDelete.Text = Deklarit.Resources.Resources.Delete + " " + pLANPLANORGLevelDescription;
        }

        private void grdLevelPLANORG_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourcePLAN.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourcePLAN.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelPLANORG_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.PLANORGUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelPLANORG_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourcePLAN, this.PLANController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "PLAN", this.m_Mode, this.dsPLANDataSet1, this.dsPLANDataSet1.PLAN.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            if (!this.m_DataGrids.Contains(this.grdLevelPLANORG))
            {
                this.m_DataGrids.Add(this.grdLevelPLANORG);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsPLANDataSet1.PLAN[0];
                this.textPLANGODINAIDGODINE.ButtonsRight[0].Visible = false;
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.textPLANGODINAIDGODINE.ButtonsRight[0].Visible = true;
                this.m_CurrentRow = (PLANDataSet.PLANRow) ((DataRowView) this.bindingSourcePLAN.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(PLANFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourcePLAN = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePLAN).BeginInit();
            this.bindingSourcePLANORG = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePLANORG).BeginInit();
            this.layoutManagerformPLAN = new TableLayoutPanel();
            this.layoutManagerformPLAN.SuspendLayout();
            this.layoutManagerformPLAN.AutoSize = true;
            this.layoutManagerformPLAN.Dock = DockStyle.Fill;
            this.layoutManagerformPLAN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPLAN.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPLAN.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPLAN.Size = size;
            this.layoutManagerformPLAN.ColumnCount = 2;
            this.layoutManagerformPLAN.RowCount = 5;
            this.layoutManagerformPLAN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPLAN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPLAN.RowStyles.Add(new RowStyle());
            this.layoutManagerformPLAN.RowStyles.Add(new RowStyle());
            this.layoutManagerformPLAN.RowStyles.Add(new RowStyle());
            this.layoutManagerformPLAN.RowStyles.Add(new RowStyle());
            this.layoutManagerformPLAN.RowStyles.Add(new RowStyle());
            this.label1IDPLAN = new UltraLabel();
            this.textIDPLAN = new UltraNumericEditor();
            this.label1PLANGODINAIDGODINE = new UltraLabel();
            this.textPLANGODINAIDGODINE = new UltraNumericEditor();
            this.label1RADNINAZIVPLANA = new UltraLabel();
            this.textRADNINAZIVPLANA = new UltraTextEditor();
            this.grdLevelPLANORG = new UltraGrid();
            this.panelactionsPLANORG = new Panel();
            this.layoutManagerpanelactionsPLANORG = new TableLayoutPanel();
            this.layoutManagerpanelactionsPLANORG.AutoSize = true;
            this.layoutManagerpanelactionsPLANORG.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsPLANORG.ColumnCount = 4;
            this.layoutManagerpanelactionsPLANORG.RowCount = 1;
            this.layoutManagerpanelactionsPLANORG.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsPLANORG.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPLANORG.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPLANORG.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPLANORG.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPLANORG.RowStyles.Add(new RowStyle());
            this.linkLabelPLANORGAdd = new UltraLabel();
            this.linkLabelPLANORGUpdate = new UltraLabel();
            this.linkLabelPLANORGDelete = new UltraLabel();
            this.linkLabelPLANORG = new UltraLabel();
            ((ISupportInitialize) this.textIDPLAN).BeginInit();
            ((ISupportInitialize) this.textPLANGODINAIDGODINE).BeginInit();
            ((ISupportInitialize) this.textRADNINAZIVPLANA).BeginInit();
            ((ISupportInitialize) this.grdLevelPLANORG).BeginInit();
            this.panelactionsPLANORG.SuspendLayout();
            this.layoutManagerpanelactionsPLANORG.SuspendLayout();
            UltraGridBand band = new UltraGridBand("PLANORG", -1);
            UltraGridColumn column = new UltraGridColumn("IDPLAN");
            UltraGridColumn column9 = new UltraGridColumn("PLANGODINAIDGODINE");
            UltraGridColumn column10 = new UltraGridColumn("PLANOJIDORGJED");
            UltraGridColumn column11 = new UltraGridColumn("columnPLANOJIDORGJEDAddNew", 0);
            UltraGridColumn column12 = new UltraGridColumn("PLANOJNAZIVORGJED");
            UltraGridBand band2 = new UltraGridBand("PLANORG_PLANORGKON", 0);
            UltraGridColumn column2 = new UltraGridColumn("IDPLAN");
            UltraGridColumn column3 = new UltraGridColumn("PLANGODINAIDGODINE");
            UltraGridColumn column7 = new UltraGridColumn("PLANOJIDORGJED");
            UltraGridColumn column8 = new UltraGridColumn("columnPLANOJIDORGJEDAddNew", 0);
            UltraGridColumn column5 = new UltraGridColumn("PLANKONTOIDKONTO");
            UltraGridColumn column6 = new UltraGridColumn("columnPLANKONTOIDKONTOAddNew", 1);
            UltraGridColumn column4 = new UltraGridColumn("PLANIRANIIZNOS");
            this.dsPLANDataSet1 = new PLANDataSet();
            this.dsPLANDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsPLANDataSet1.DataSetName = "dsPLAN";
            this.dsPLANDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourcePLAN.DataSource = this.dsPLANDataSet1;
            this.bindingSourcePLAN.DataMember = "PLAN";
            ((ISupportInitialize) this.bindingSourcePLAN).BeginInit();
            this.bindingSourcePLANORG.DataSource = this.bindingSourcePLAN;
            this.bindingSourcePLANORG.DataMember = "PLAN_PLANORG";
            point = new System.Drawing.Point(0, 0);
            this.label1IDPLAN.Location = point;
            this.label1IDPLAN.Name = "label1IDPLAN";
            this.label1IDPLAN.TabIndex = 1;
            this.label1IDPLAN.Tag = "labelIDPLAN";
            this.label1IDPLAN.Text = "IDPLAN:";
            this.label1IDPLAN.StyleSetName = "FieldUltraLabel";
            this.label1IDPLAN.AutoSize = true;
            this.label1IDPLAN.Anchor = AnchorStyles.Left;
            this.label1IDPLAN.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDPLAN.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDPLAN.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDPLAN.ImageSize = size;
            this.label1IDPLAN.Appearance.ForeColor = Color.Black;
            this.label1IDPLAN.BackColor = Color.Transparent;
            this.layoutManagerformPLAN.Controls.Add(this.label1IDPLAN, 0, 0);
            this.layoutManagerformPLAN.SetColumnSpan(this.label1IDPLAN, 1);
            this.layoutManagerformPLAN.SetRowSpan(this.label1IDPLAN, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDPLAN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDPLAN.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x17);
            this.label1IDPLAN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDPLAN.Location = point;
            this.textIDPLAN.Name = "textIDPLAN";
            this.textIDPLAN.Tag = "IDPLAN";
            this.textIDPLAN.TabIndex = 0;
            this.textIDPLAN.Anchor = AnchorStyles.Left;
            this.textIDPLAN.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDPLAN.ReadOnly = false;
            this.textIDPLAN.PromptChar = ' ';
            this.textIDPLAN.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDPLAN.DataBindings.Add(new Binding("Value", this.bindingSourcePLAN, "IDPLAN"));
            this.textIDPLAN.NumericType = NumericType.Integer;
            this.textIDPLAN.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformPLAN.Controls.Add(this.textIDPLAN, 1, 0);
            this.layoutManagerformPLAN.SetColumnSpan(this.textIDPLAN, 1);
            this.layoutManagerformPLAN.SetRowSpan(this.textIDPLAN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDPLAN.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDPLAN.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDPLAN.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PLANGODINAIDGODINE.Location = point;
            this.label1PLANGODINAIDGODINE.Name = "label1PLANGODINAIDGODINE";
            this.label1PLANGODINAIDGODINE.TabIndex = 1;
            this.label1PLANGODINAIDGODINE.Tag = "labelPLANGODINAIDGODINE";
            this.label1PLANGODINAIDGODINE.Text = "IDGODINE:";
            this.label1PLANGODINAIDGODINE.StyleSetName = "FieldUltraLabel";
            this.label1PLANGODINAIDGODINE.AutoSize = true;
            this.label1PLANGODINAIDGODINE.Anchor = AnchorStyles.Left;
            this.label1PLANGODINAIDGODINE.Appearance.TextVAlign = VAlign.Middle;
            this.label1PLANGODINAIDGODINE.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1PLANGODINAIDGODINE.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1PLANGODINAIDGODINE.ImageSize = size;
            this.label1PLANGODINAIDGODINE.Appearance.ForeColor = Color.Black;
            this.label1PLANGODINAIDGODINE.BackColor = Color.Transparent;
            this.layoutManagerformPLAN.Controls.Add(this.label1PLANGODINAIDGODINE, 0, 1);
            this.layoutManagerformPLAN.SetColumnSpan(this.label1PLANGODINAIDGODINE, 1);
            this.layoutManagerformPLAN.SetRowSpan(this.label1PLANGODINAIDGODINE, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PLANGODINAIDGODINE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PLANGODINAIDGODINE.MinimumSize = size;
            size = new System.Drawing.Size(0x53, 0x17);
            this.label1PLANGODINAIDGODINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPLANGODINAIDGODINE.Location = point;
            this.textPLANGODINAIDGODINE.Name = "textPLANGODINAIDGODINE";
            this.textPLANGODINAIDGODINE.Tag = "PLANGODINAIDGODINE";
            this.textPLANGODINAIDGODINE.TabIndex = 0;
            this.textPLANGODINAIDGODINE.Anchor = AnchorStyles.Left;
            this.textPLANGODINAIDGODINE.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPLANGODINAIDGODINE.ReadOnly = false;
            this.textPLANGODINAIDGODINE.PromptChar = ' ';
            this.textPLANGODINAIDGODINE.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPLANGODINAIDGODINE.DataBindings.Add(new Binding("Value", this.bindingSourcePLAN, "PLANGODINAIDGODINE"));
            this.textPLANGODINAIDGODINE.NumericType = NumericType.Integer;
            this.textPLANGODINAIDGODINE.MaskInput = "{LOC}-nnnn";
            EditorButton button = new EditorButton {
                Key = "editorButtonGODINEPLANGODINAIDGODINE",
                Tag = "editorButtonGODINEPLANGODINAIDGODINE",
                Text = "..."
            };
            this.textPLANGODINAIDGODINE.ButtonsRight.Add(button);
            this.textPLANGODINAIDGODINE.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptGODINEPLANGODINAIDGODINE);
            this.layoutManagerformPLAN.Controls.Add(this.textPLANGODINAIDGODINE, 1, 1);
            this.layoutManagerformPLAN.SetColumnSpan(this.textPLANGODINAIDGODINE, 1);
            this.layoutManagerformPLAN.SetRowSpan(this.textPLANGODINAIDGODINE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPLANGODINAIDGODINE.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textPLANGODINAIDGODINE.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textPLANGODINAIDGODINE.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1RADNINAZIVPLANA.Location = point;
            this.label1RADNINAZIVPLANA.Name = "label1RADNINAZIVPLANA";
            this.label1RADNINAZIVPLANA.TabIndex = 1;
            this.label1RADNINAZIVPLANA.Tag = "labelRADNINAZIVPLANA";
            this.label1RADNINAZIVPLANA.Text = "RADNINAZIVPLANA:";
            this.label1RADNINAZIVPLANA.StyleSetName = "FieldUltraLabel";
            this.label1RADNINAZIVPLANA.AutoSize = true;
            this.label1RADNINAZIVPLANA.Anchor = AnchorStyles.Left;
            this.label1RADNINAZIVPLANA.Appearance.TextVAlign = VAlign.Middle;
            this.label1RADNINAZIVPLANA.Appearance.ForeColor = Color.Black;
            this.label1RADNINAZIVPLANA.BackColor = Color.Transparent;
            this.layoutManagerformPLAN.Controls.Add(this.label1RADNINAZIVPLANA, 0, 2);
            this.layoutManagerformPLAN.SetColumnSpan(this.label1RADNINAZIVPLANA, 1);
            this.layoutManagerformPLAN.SetRowSpan(this.label1RADNINAZIVPLANA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RADNINAZIVPLANA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RADNINAZIVPLANA.MinimumSize = size;
            size = new System.Drawing.Size(0x8f, 0x17);
            this.label1RADNINAZIVPLANA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textRADNINAZIVPLANA.Location = point;
            this.textRADNINAZIVPLANA.Name = "textRADNINAZIVPLANA";
            this.textRADNINAZIVPLANA.Tag = "RADNINAZIVPLANA";
            this.textRADNINAZIVPLANA.TabIndex = 0;
            this.textRADNINAZIVPLANA.Anchor = AnchorStyles.Left;
            this.textRADNINAZIVPLANA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textRADNINAZIVPLANA.ReadOnly = false;
            this.textRADNINAZIVPLANA.DataBindings.Add(new Binding("Text", this.bindingSourcePLAN, "RADNINAZIVPLANA"));
            this.textRADNINAZIVPLANA.MaxLength = 50;
            this.layoutManagerformPLAN.Controls.Add(this.textRADNINAZIVPLANA, 1, 2);
            this.layoutManagerformPLAN.SetColumnSpan(this.textRADNINAZIVPLANA, 1);
            this.layoutManagerformPLAN.SetRowSpan(this.textRADNINAZIVPLANA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textRADNINAZIVPLANA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textRADNINAZIVPLANA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textRADNINAZIVPLANA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelPLANORG.Location = point;
            this.grdLevelPLANORG.Name = "grdLevelPLANORG";
            this.layoutManagerformPLAN.Controls.Add(this.grdLevelPLANORG, 0, 3);
            this.layoutManagerformPLAN.SetColumnSpan(this.grdLevelPLANORG, 2);
            this.layoutManagerformPLAN.SetRowSpan(this.grdLevelPLANORG, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelPLANORG.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelPLANORG.MinimumSize = size;
            size = new System.Drawing.Size(0x19d, 200);
            this.grdLevelPLANORG.Size = size;
            this.grdLevelPLANORG.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsPLANORG.Location = point;
            this.panelactionsPLANORG.Name = "panelactionsPLANORG";
            this.panelactionsPLANORG.BackColor = Color.Transparent;
            this.panelactionsPLANORG.Controls.Add(this.layoutManagerpanelactionsPLANORG);
            this.layoutManagerformPLAN.Controls.Add(this.panelactionsPLANORG, 0, 4);
            this.layoutManagerformPLAN.SetColumnSpan(this.panelactionsPLANORG, 2);
            this.layoutManagerformPLAN.SetRowSpan(this.panelactionsPLANORG, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsPLANORG.Margin = padding;
            size = new System.Drawing.Size(0xf6, 0x19);
            this.panelactionsPLANORG.MinimumSize = size;
            size = new System.Drawing.Size(0xf6, 0x19);
            this.panelactionsPLANORG.Size = size;
            this.panelactionsPLANORG.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPLANORGAdd.Location = point;
            this.linkLabelPLANORGAdd.Name = "linkLabelPLANORGAdd";
            size = new System.Drawing.Size(0x3a, 15);
            this.linkLabelPLANORGAdd.Size = size;
            this.linkLabelPLANORGAdd.Text = " Add ORG  ";
            this.linkLabelPLANORGAdd.Click += new EventHandler(this.PLANORGAdd_Click);
            this.linkLabelPLANORGAdd.BackColor = Color.Transparent;
            this.linkLabelPLANORGAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelPLANORGAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelPLANORGAdd.Cursor = Cursors.Hand;
            this.linkLabelPLANORGAdd.AutoSize = true;
            this.layoutManagerpanelactionsPLANORG.Controls.Add(this.linkLabelPLANORGAdd, 0, 0);
            this.layoutManagerpanelactionsPLANORG.SetColumnSpan(this.linkLabelPLANORGAdd, 1);
            this.layoutManagerpanelactionsPLANORG.SetRowSpan(this.linkLabelPLANORGAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPLANORGAdd.Margin = padding;
            size = new System.Drawing.Size(0x3a, 15);
            this.linkLabelPLANORGAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x3a, 15);
            this.linkLabelPLANORGAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPLANORGUpdate.Location = point;
            this.linkLabelPLANORGUpdate.Name = "linkLabelPLANORGUpdate";
            size = new System.Drawing.Size(0x4c, 15);
            this.linkLabelPLANORGUpdate.Size = size;
            this.linkLabelPLANORGUpdate.Text = " Update ORG  ";
            this.linkLabelPLANORGUpdate.Click += new EventHandler(this.PLANORGUpdate_Click);
            this.linkLabelPLANORGUpdate.BackColor = Color.Transparent;
            this.linkLabelPLANORGUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelPLANORGUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelPLANORGUpdate.Cursor = Cursors.Hand;
            this.linkLabelPLANORGUpdate.AutoSize = true;
            this.layoutManagerpanelactionsPLANORG.Controls.Add(this.linkLabelPLANORGUpdate, 1, 0);
            this.layoutManagerpanelactionsPLANORG.SetColumnSpan(this.linkLabelPLANORGUpdate, 1);
            this.layoutManagerpanelactionsPLANORG.SetRowSpan(this.linkLabelPLANORGUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPLANORGUpdate.Margin = padding;
            size = new System.Drawing.Size(0x4c, 15);
            this.linkLabelPLANORGUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x4c, 15);
            this.linkLabelPLANORGUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPLANORGDelete.Location = point;
            this.linkLabelPLANORGDelete.Name = "linkLabelPLANORGDelete";
            size = new System.Drawing.Size(0x48, 15);
            this.linkLabelPLANORGDelete.Size = size;
            this.linkLabelPLANORGDelete.Text = " Delete ORG  ";
            this.linkLabelPLANORGDelete.Click += new EventHandler(this.PLANORGDelete_Click);
            this.linkLabelPLANORGDelete.BackColor = Color.Transparent;
            this.linkLabelPLANORGDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelPLANORGDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelPLANORGDelete.Cursor = Cursors.Hand;
            this.linkLabelPLANORGDelete.AutoSize = true;
            this.layoutManagerpanelactionsPLANORG.Controls.Add(this.linkLabelPLANORGDelete, 2, 0);
            this.layoutManagerpanelactionsPLANORG.SetColumnSpan(this.linkLabelPLANORGDelete, 1);
            this.layoutManagerpanelactionsPLANORG.SetRowSpan(this.linkLabelPLANORGDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPLANORGDelete.Margin = padding;
            size = new System.Drawing.Size(0x48, 15);
            this.linkLabelPLANORGDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x48, 15);
            this.linkLabelPLANORGDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPLANORG.Location = point;
            this.linkLabelPLANORG.Name = "linkLabelPLANORG";
            this.layoutManagerpanelactionsPLANORG.Controls.Add(this.linkLabelPLANORG, 3, 0);
            this.layoutManagerpanelactionsPLANORG.SetColumnSpan(this.linkLabelPLANORG, 1);
            this.layoutManagerpanelactionsPLANORG.SetRowSpan(this.linkLabelPLANORG, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPLANORG.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelPLANORG.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelPLANORG.Size = size;
            this.linkLabelPLANORG.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformPLAN);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourcePLAN;
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
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.Disabled;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.PLANPLANGODINAIDGODINEDescription;
            column9.Width = 0x48;
            appearance7.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnn";
            column9.PromptChar = ' ';
            column9.Format = "";
            column9.CellAppearance = appearance7;
            column9.Hidden = true;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.PLANPLANOJIDORGJEDDescription;
            column10.Width = 0x48;
            column10.Format = "";
            column10.CellAppearance = appearance8;
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
            column11.Tag = "ORGJEDPLANOJIDORGJEDAddNew";
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.Disabled;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.PLANPLANOJNAZIVORGJEDDescription;
            column12.Width = 0x128;
            column12.Format = "";
            column12.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.Disabled;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.PLANIDPLANDescription;
            column2.Width = 0x3a;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            column2.Hidden = true;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.Disabled;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.PLANPLANGODINAIDGODINEDescription;
            column3.Width = 0x48;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.Disabled;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.PLANPLANOJIDORGJEDDescription;
            column7.Width = 0x48;
            column7.Format = "";
            column7.CellAppearance = appearance6;
            column7.Hidden = true;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.PLANPLANKONTOIDKONTODescription;
            column5.Width = 0x72;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            column6.AllowGroupBy = DefaultableBoolean.False;
            column6.AutoSizeEdit = DefaultableBoolean.False;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column6.CellAppearance.BorderAlpha = Alpha.Transparent;
            column6.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column6.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column6.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column6.Header.Enabled = false;
            column6.Header.Fixed = true;
            column6.Header.Caption = "";
            column6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column6.Width = 20;
            column6.MinWidth = 20;
            column6.MaxWidth = 20;
            column6.Tag = "KONTOPLANKONTOIDKONTOAddNew";
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.PLANPLANIRANIIZNOSDescription;
            column4.Width = 0x74;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            band2.Columns.Add(column7);
            column7.Header.VisiblePosition = 0;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 1;
            band2.Columns.Add(column4);
            column4.Header.VisiblePosition = 2;
            band2.Columns.Add(column2);
            column2.Header.VisiblePosition = 3;
            band2.Columns.Add(column3);
            column3.Header.VisiblePosition = 4;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 0;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 3;
            this.grdLevelPLANORG.Visible = true;
            this.grdLevelPLANORG.Name = "grdLevelPLANORG";
            this.grdLevelPLANORG.Tag = "PLANORG";
            this.grdLevelPLANORG.TabIndex = 12;
            this.grdLevelPLANORG.Dock = DockStyle.Fill;
            this.grdLevelPLANORG.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelPLANORG.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelPLANORG.DataSource = this.bindingSourcePLANORG;
            this.grdLevelPLANORG.Enter += new EventHandler(this.grdLevelPLANORG_Enter);
            this.grdLevelPLANORG.AfterRowInsert += new RowEventHandler(this.grdLevelPLANORG_AfterRowInsert);
            this.grdLevelPLANORG.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelPLANORG.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelPLANORG.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelPLANORG.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelPLANORG_DoubleClick);
            this.grdLevelPLANORG.AfterRowActivate += new EventHandler(this.grdLevelPLANORG_AfterRowActivate);
            this.grdLevelPLANORG.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelPLANORG.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelPLANORG.DisplayLayout.BandsSerializer.Add(band);
            this.grdLevelPLANORG.DisplayLayout.BandsSerializer.Add(band2);
            this.Name = "PLANFormUserControl";
            this.Text = "PLAN";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.PLANFormUserControl_Load);
            this.layoutManagerformPLAN.ResumeLayout(false);
            this.layoutManagerformPLAN.PerformLayout();
            ((ISupportInitialize) this.bindingSourcePLAN).EndInit();
            ((ISupportInitialize) this.bindingSourcePLANORG).EndInit();
            ((ISupportInitialize) this.textIDPLAN).EndInit();
            ((ISupportInitialize) this.textPLANGODINAIDGODINE).EndInit();
            ((ISupportInitialize) this.textRADNINAZIVPLANA).EndInit();
            ((ISupportInitialize) this.grdLevelPLANORG).EndInit();
            this.panelactionsPLANORG.ResumeLayout(true);
            this.panelactionsPLANORG.PerformLayout();
            this.layoutManagerpanelactionsPLANORG.ResumeLayout(false);
            this.layoutManagerpanelactionsPLANORG.PerformLayout();
            this.dsPLANDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.PLANController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourcePLAN, this.PLANController.WorkItem, this))
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
            this.label1IDPLAN.Text = StringResources.PLANIDPLANDescription;
            this.label1PLANGODINAIDGODINE.Text = StringResources.PLANPLANGODINAIDGODINEDescription;
            this.label1RADNINAZIVPLANA.Text = StringResources.PLANRADNINAZIVPLANADescription;
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

        private void PictureBoxClickedInLinesPLANOJIDORGJED(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ORGJED", null, DeklaritMode.Insert));
            }
        }

        private void PLANFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.PLANDescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelPLANORGAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.PLANPLANORGLevelDescription;
            this.linkLabelPLANORGUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.PLANPLANORGLevelDescription;
            this.linkLabelPLANORGDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.PLANPLANORGLevelDescription;
        }

        private void PLANORGAdd_Click(object sender, EventArgs e)
        {
            if ((this.grdLevelPLANORG.ActiveRow != null) && this.grdLevelPLANORG.ActiveRow.Band.Key.EndsWith("_PLANORGKON"))
            {
                this.PLANORGKONInsert();
            }
            else
            {
                this.PLANORGInsert();
            }
        }

        private void PLANORGDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelPLANORG);
            if ((currentRowListIndex != -1) && (this.grdLevelPLANORG.Selected.Rows.Count > 0))
            {
                this.grdLevelPLANORG.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelPLANORG).Selected = true;
                this.grdLevelPLANORG.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void PLANORGInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourcePLAN, this.PLANController.WorkItem, this))
            {
                this.PLANController.AddPLANORG(this.m_CurrentRow);
            }
        }

        private void PLANORGKONInsert()
        {
            if (this.grdLevelPLANORG.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelPLANORG.ActiveRow.ListObject;
                DataRow parentRow = listObject.Row.GetParentRow("PLANORG_PLANORGKON");
                this.PLANController.AddPLANORGKON(parentRow);
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
            CreateValueList(this.grdLevelPLANORG, "KONTOPLANKONTOIDKONTO", enumList, "IDKONTO", "KONT", true);
        }

        private void PLANORGKONUpdate()
        {
            if (this.grdLevelPLANORG.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelPLANORG.ActiveRow.ListObject;
                this.PLANController.UpdatePLANORGKON(listObject.Row);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ORGJED", Thread=ThreadOption.UserInterface)]
        public void PLANORGPLANOJIDORGJED_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new ORGJEDDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetORGJEDDataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["ORGJED"]) {
                Sort = "oj"
            };
            CreateValueList(this.grdLevelPLANORG, "ORGJEDPLANOJIDORGJED", enumList, "IDORGJED", "oj", true);
        }

        private void PLANORGUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelPLANORG) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelPLANORG);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.PLANController.UpdatePLANORG(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void PLANORGUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelPLANORG.ActiveRow != null)
            {
                if (this.grdLevelPLANORG.ActiveRow.Band.Key.EndsWith("_PLANORGKON"))
                {
                    this.PLANORGKONUpdate();
                }
                else
                {
                    this.PLANORGUpdate();
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.PLANController.WorkItem.Items.Contains("PLAN|PLAN"))
            {
                this.PLANController.WorkItem.Items.Add(this.bindingSourcePLAN, "PLAN|PLAN");
            }
            if (!this.PLANController.WorkItem.Items.Contains("PLAN|PLANORG"))
            {
                this.PLANController.WorkItem.Items.Add(this.bindingSourcePLANORG, "PLAN|PLANORG");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsPLANDataSet1.PLAN.Rows[0] != null) && this.m_BaseMethods.IsInsert())
            {
                this.m_Mode = DeklaritMode.Update;
                this.m_BaseMethods.Mode = this.m_Mode;
                this.m_BaseMethods.FormLoadStyle();
                this.textPLANGODINAIDGODINE.ButtonsRight[0].Visible = false;
            }
        }

        [LocalCommandHandler("Save")]
        public void Save(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.PLANController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.PLANController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.PLANController.Update(this))
            {
                this.PLANController.DataSet = new PLANDataSet();
                DataSetUtil.AddEmptyRow(this.PLANController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.PLANController.DataSet.PLAN[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetComboBoxColumnProperties()
        {
            DataSet dataSet = new ORGJEDDataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetORGJEDDataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["ORGJED"]) {
                Sort = "oj"
            };
            CreateValueList(this.grdLevelPLANORG, "ORGJEDPLANOJIDORGJED", enumList, "IDORGJED", "oj", false);
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelPLANORG, "PLANOJIDORGJED");
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            gridColumn.ValueList = this.grdLevelPLANORG.DisplayLayout.ValueLists["ORGJEDPLANOJIDORGJED"];
            gridColumn.Width = 370;
            DataSet set = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set);
            }
            DataView view = new DataView(set.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.grdLevelPLANORG, "KONTOPLANKONTOIDKONTO", view, "IDKONTO", "KONT", false);
            UltraGridColumn column = FormHelperClass.GetGridColumn(this.grdLevelPLANORG, "PLANKONTOIDKONTO");
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.grdLevelPLANORG.DisplayLayout.ValueLists["KONTOPLANKONTOIDKONTO"];
            column.Width = 370;
            this.grdLevelPLANORG.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelPLANORG.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.textIDPLAN.Focus();
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

        private void UpdateValuesGODINEPLANGODINAIDGODINE(DataRow result)
        {
            if (result != null)
            {
                ((DataRowView) this.bindingSourcePLAN.Current).Row["PLANGODINAIDGODINE"] = RuntimeHelpers.GetObjectValue(result["IDGODINE"]);
                this.bindingSourcePLAN.ResetCurrentItem();
            }
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

        private void UpdateValuesPLANOJIDORGJED(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["PLANOJIDORGJED"] = RuntimeHelpers.GetObjectValue(result["IDORGJED"]);
                    row["PLANOJNAZIVORGJED"] = RuntimeHelpers.GetObjectValue(result["NAZIVORGJED"]);
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

        protected virtual UltraGrid grdLevelPLANORG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelPLANORG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelPLANORG = value;
            }
        }

        protected virtual UltraLabel label1IDPLAN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDPLAN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDPLAN = value;
            }
        }

        protected virtual UltraLabel label1PLANGODINAIDGODINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PLANGODINAIDGODINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PLANGODINAIDGODINE = value;
            }
        }

        protected virtual UltraLabel label1RADNINAZIVPLANA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RADNINAZIVPLANA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RADNINAZIVPLANA = value;
            }
        }

        protected virtual UltraLabel linkLabelPLANORG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPLANORG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPLANORG = value;
            }
        }

        protected virtual UltraLabel linkLabelPLANORGAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPLANORGAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPLANORGAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelPLANORGDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPLANORGDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPLANORGDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelPLANORGUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPLANORGUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPLANORGUpdate = value;
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

        protected virtual Panel panelactionsPLANORG
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsPLANORG;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsPLANORG = value;
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

        protected virtual UltraNumericEditor textIDPLAN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDPLAN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDPLAN = value;
            }
        }

        protected virtual UltraNumericEditor textPLANGODINAIDGODINE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPLANGODINAIDGODINE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPLANGODINAIDGODINE = value;
            }
        }

        protected virtual UltraTextEditor textRADNINAZIVPLANA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textRADNINAZIVPLANA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textRADNINAZIVPLANA = value;
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

