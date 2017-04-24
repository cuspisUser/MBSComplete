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
    public class PRPLACEFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelPRPLACEPRPLACEELEMENTI")]
        private UltraGrid _grdLevelPRPLACEPRPLACEELEMENTI;
        [AccessedThroughProperty("label1PRPLACEID")]
        private UltraLabel _label1PRPLACEID;
        [AccessedThroughProperty("label1PRPLACEOPIS")]
        private UltraLabel _label1PRPLACEOPIS;
        [AccessedThroughProperty("label1PRPLACEOSNOVICA")]
        private UltraLabel _label1PRPLACEOSNOVICA;
        [AccessedThroughProperty("label1PRPLACEPROSJECNISATI")]
        private UltraLabel _label1PRPLACEPROSJECNISATI;
        [AccessedThroughProperty("label1PRPLACEZAGODINU")]
        private UltraLabel _label1PRPLACEZAGODINU;
        [AccessedThroughProperty("label1PRPLACEZAMJESEC")]
        private UltraLabel _label1PRPLACEZAMJESEC;
        [AccessedThroughProperty("linkLabelPRPLACEPRPLACEELEMENTI")]
        private UltraLabel _linkLabelPRPLACEPRPLACEELEMENTI;
        [AccessedThroughProperty("linkLabelPRPLACEPRPLACEELEMENTIAdd")]
        private UltraLabel _linkLabelPRPLACEPRPLACEELEMENTIAdd;
        [AccessedThroughProperty("linkLabelPRPLACEPRPLACEELEMENTIDelete")]
        private UltraLabel _linkLabelPRPLACEPRPLACEELEMENTIDelete;
        [AccessedThroughProperty("linkLabelPRPLACEPRPLACEELEMENTIUpdate")]
        private UltraLabel _linkLabelPRPLACEPRPLACEELEMENTIUpdate;
        [AccessedThroughProperty("panelactionsPRPLACEPRPLACEELEMENTI")]
        private Panel _panelactionsPRPLACEPRPLACEELEMENTI;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textPRPLACEID")]
        private UltraNumericEditor _textPRPLACEID;
        [AccessedThroughProperty("textPRPLACEOPIS")]
        private UltraTextEditor _textPRPLACEOPIS;
        [AccessedThroughProperty("textPRPLACEOSNOVICA")]
        private UltraNumericEditor _textPRPLACEOSNOVICA;
        [AccessedThroughProperty("textPRPLACEPROSJECNISATI")]
        private UltraNumericEditor _textPRPLACEPROSJECNISATI;
        [AccessedThroughProperty("textPRPLACEZAGODINU")]
        private UltraNumericEditor _textPRPLACEZAGODINU;
        [AccessedThroughProperty("textPRPLACEZAMJESEC")]
        private UltraNumericEditor _textPRPLACEZAMJESEC;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourcePRPLACE;
        private BindingSource bindingSourcePRPLACEPRPLACEELEMENTI;
        private IContainer components = null;
        private PRPLACEDataSet dsPRPLACEDataSet1;
        protected TableLayoutPanel layoutManagerformPRPLACE;
        protected TableLayoutPanel layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private PRPLACEDataSet.PRPLACERow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "PRPLACE";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.PRPLACEDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public PRPLACEFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsPRPLACEDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourcePRPLACE.DataSource = this.PRPLACEController.DataSet;
            this.dsPRPLACEDataSet1 = this.PRPLACEController.DataSet;
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
                    enumerator = this.dsPRPLACEDataSet1.PRPLACE.Rows.GetEnumerator();
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
                if (this.PRPLACEController.Update(this))
                {
                    this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void dg_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGridColumn column = e.Cell.Column;
            if ((column.CellActivation == Activation.AllowEdit) && (Conversions.ToString(column.Tag) == "ELEMENTIDELEMENTAddNew"))
            {
                this.PictureBoxClickedInLinesIDELEMENT(RuntimeHelpers.GetObjectValue(sender), e);
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
            if (this.grdLevelPRPLACEPRPLACEELEMENTI.ActiveRow != null)
            {
                this.grdLevelPRPLACEPRPLACEELEMENTI.PerformAction(UltraGridAction.NextRow);
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
                if (e.Cell.Column.Key == "IDELEMENT")
                {
                    this.UpdateValuesIDELEMENT(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
            }
        }

        private void grdLevelPRPLACEPRPLACEELEMENTI_AfterRowActivate(object sender, EventArgs e)
        {
            string pRPLACEPRPLACEPRPLACEELEMENTILevelDescription = StringResources.PRPLACEPRPLACEPRPLACEELEMENTILevelDescription;
            if ((this.grdLevelPRPLACEPRPLACEELEMENTI.ActiveRow != null) && this.grdLevelPRPLACEPRPLACEELEMENTI.ActiveRow.Band.Key.EndsWith("_PRPLACEPRPLACEELEMENTIRADNIK"))
            {
                pRPLACEPRPLACEPRPLACEELEMENTILevelDescription = StringResources.PRPLACEPRPLACEPRPLACEELEMENTIRADNIKLevelDescription;
            }
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd.Text = Deklarit.Resources.Resources.Add + " " + pRPLACEPRPLACEPRPLACEELEMENTILevelDescription;
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate.Text = Deklarit.Resources.Resources.Update + " " + pRPLACEPRPLACEPRPLACEELEMENTILevelDescription;
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete.Text = Deklarit.Resources.Resources.Delete + " " + pRPLACEPRPLACEPRPLACEELEMENTILevelDescription;
        }

        private void grdLevelPRPLACEPRPLACEELEMENTI_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourcePRPLACE.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourcePRPLACE.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelPRPLACEPRPLACEELEMENTI_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.PRPLACEPRPLACEELEMENTIUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelPRPLACEPRPLACEELEMENTI_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourcePRPLACE, this.PRPLACEController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "PRPLACE", this.m_Mode, this.dsPRPLACEDataSet1, this.dsPRPLACEDataSet1.PRPLACE.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            if (!this.m_DataGrids.Contains(this.grdLevelPRPLACEPRPLACEELEMENTI))
            {
                this.m_DataGrids.Add(this.grdLevelPRPLACEPRPLACEELEMENTI);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsPRPLACEDataSet1.PRPLACE[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (PRPLACEDataSet.PRPLACERow) ((DataRowView) this.bindingSourcePRPLACE.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(PRPLACEFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourcePRPLACE = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePRPLACE).BeginInit();
            this.bindingSourcePRPLACEPRPLACEELEMENTI = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourcePRPLACEPRPLACEELEMENTI).BeginInit();
            this.layoutManagerformPRPLACE = new TableLayoutPanel();
            this.layoutManagerformPRPLACE.SuspendLayout();
            this.layoutManagerformPRPLACE.AutoSize = true;
            this.layoutManagerformPRPLACE.Dock = DockStyle.Fill;
            this.layoutManagerformPRPLACE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPRPLACE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPRPLACE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPRPLACE.Size = size;
            this.layoutManagerformPRPLACE.ColumnCount = 2;
            this.layoutManagerformPRPLACE.RowCount = 8;
            this.layoutManagerformPRPLACE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPRPLACE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPRPLACE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACE.RowStyles.Add(new RowStyle());
            this.layoutManagerformPRPLACE.RowStyles.Add(new RowStyle());
            this.label1PRPLACEZAMJESEC = new UltraLabel();
            this.textPRPLACEZAMJESEC = new UltraNumericEditor();
            this.label1PRPLACEZAGODINU = new UltraLabel();
            this.textPRPLACEZAGODINU = new UltraNumericEditor();
            this.label1PRPLACEID = new UltraLabel();
            this.textPRPLACEID = new UltraNumericEditor();
            this.label1PRPLACEOSNOVICA = new UltraLabel();
            this.textPRPLACEOSNOVICA = new UltraNumericEditor();
            this.label1PRPLACEPROSJECNISATI = new UltraLabel();
            this.textPRPLACEPROSJECNISATI = new UltraNumericEditor();
            this.label1PRPLACEOPIS = new UltraLabel();
            this.textPRPLACEOPIS = new UltraTextEditor();
            this.grdLevelPRPLACEPRPLACEELEMENTI = new UltraGrid();
            this.panelactionsPRPLACEPRPLACEELEMENTI = new Panel();
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI = new TableLayoutPanel();
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.AutoSize = true;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.ColumnCount = 4;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.RowCount = 1;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.RowStyles.Add(new RowStyle());
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd = new UltraLabel();
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate = new UltraLabel();
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete = new UltraLabel();
            this.linkLabelPRPLACEPRPLACEELEMENTI = new UltraLabel();
            ((ISupportInitialize) this.textPRPLACEZAMJESEC).BeginInit();
            ((ISupportInitialize) this.textPRPLACEZAGODINU).BeginInit();
            ((ISupportInitialize) this.textPRPLACEID).BeginInit();
            ((ISupportInitialize) this.textPRPLACEOSNOVICA).BeginInit();
            ((ISupportInitialize) this.textPRPLACEPROSJECNISATI).BeginInit();
            ((ISupportInitialize) this.textPRPLACEOPIS).BeginInit();
            ((ISupportInitialize) this.grdLevelPRPLACEPRPLACEELEMENTI).BeginInit();
            this.panelactionsPRPLACEPRPLACEELEMENTI.SuspendLayout();
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.SuspendLayout();
            UltraGridBand band = new UltraGridBand("PRPLACEPRPLACEELEMENTI", -1);
            UltraGridColumn column7 = new UltraGridColumn("PRPLACEZAMJESEC");
            UltraGridColumn column5 = new UltraGridColumn("PRPLACEID");
            UltraGridColumn column6 = new UltraGridColumn("PRPLACEZAGODINU");
            UltraGridColumn column = new UltraGridColumn("IDELEMENT");
            UltraGridColumn column2 = new UltraGridColumn("columnIDELEMENTAddNew", 0);
            UltraGridColumn column3 = new UltraGridColumn("NAZIVELEMENT");
            UltraGridColumn column4 = new UltraGridColumn("POSTOTAK");
            UltraGridBand band2 = new UltraGridBand("PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK", 0);
            UltraGridColumn column20 = new UltraGridColumn("PRPLACEZAMJESEC");
            UltraGridColumn column14 = new UltraGridColumn("PRPLACEID");
            UltraGridColumn column19 = new UltraGridColumn("PRPLACEZAGODINU");
            UltraGridColumn column8 = new UltraGridColumn("IDELEMENT");
            UltraGridColumn column9 = new UltraGridColumn("columnIDELEMENTAddNew", 0);
            UltraGridColumn column10 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column11 = new UltraGridColumn("columnIDRADNIKAddNew", 1);
            UltraGridColumn column13 = new UltraGridColumn("PREZIME");
            UltraGridColumn column12 = new UltraGridColumn("IME");
            UltraGridColumn column17 = new UltraGridColumn("PRPLACESATI");
            UltraGridColumn column18 = new UltraGridColumn("PRPLACESATNICA");
            UltraGridColumn column16 = new UltraGridColumn("PRPLACEPOSTOTAK");
            UltraGridColumn column15 = new UltraGridColumn("PRPLACEIZNOS");
            UltraGridColumn column21 = new UltraGridColumn("SPOJENOPREZIME");
            this.dsPRPLACEDataSet1 = new PRPLACEDataSet();
            this.dsPRPLACEDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsPRPLACEDataSet1.DataSetName = "dsPRPLACE";
            this.dsPRPLACEDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourcePRPLACE.DataSource = this.dsPRPLACEDataSet1;
            this.bindingSourcePRPLACE.DataMember = "PRPLACE";
            ((ISupportInitialize) this.bindingSourcePRPLACE).BeginInit();
            this.bindingSourcePRPLACEPRPLACEELEMENTI.DataSource = this.bindingSourcePRPLACE;
            this.bindingSourcePRPLACEPRPLACEELEMENTI.DataMember = "PRPLACE_PRPLACEPRPLACEELEMENTI";
            point = new System.Drawing.Point(0, 0);
            this.label1PRPLACEZAMJESEC.Location = point;
            this.label1PRPLACEZAMJESEC.Name = "label1PRPLACEZAMJESEC";
            this.label1PRPLACEZAMJESEC.TabIndex = 1;
            this.label1PRPLACEZAMJESEC.Tag = "labelPRPLACEZAMJESEC";
            this.label1PRPLACEZAMJESEC.Text = "Za mjesec:";
            this.label1PRPLACEZAMJESEC.StyleSetName = "FieldUltraLabel";
            this.label1PRPLACEZAMJESEC.AutoSize = true;
            this.label1PRPLACEZAMJESEC.Anchor = AnchorStyles.Left;
            this.label1PRPLACEZAMJESEC.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRPLACEZAMJESEC.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1PRPLACEZAMJESEC.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1PRPLACEZAMJESEC.ImageSize = size;
            this.label1PRPLACEZAMJESEC.Appearance.ForeColor = Color.Black;
            this.label1PRPLACEZAMJESEC.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACE.Controls.Add(this.label1PRPLACEZAMJESEC, 0, 0);
            this.layoutManagerformPRPLACE.SetColumnSpan(this.label1PRPLACEZAMJESEC, 1);
            this.layoutManagerformPRPLACE.SetRowSpan(this.label1PRPLACEZAMJESEC, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1PRPLACEZAMJESEC.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRPLACEZAMJESEC.MinimumSize = size;
            size = new System.Drawing.Size(0x4f, 0x17);
            this.label1PRPLACEZAMJESEC.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRPLACEZAMJESEC.Location = point;
            this.textPRPLACEZAMJESEC.Name = "textPRPLACEZAMJESEC";
            this.textPRPLACEZAMJESEC.Tag = "PRPLACEZAMJESEC";
            this.textPRPLACEZAMJESEC.TabIndex = 0;
            this.textPRPLACEZAMJESEC.Anchor = AnchorStyles.Left;
            this.textPRPLACEZAMJESEC.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRPLACEZAMJESEC.ReadOnly = false;
            this.textPRPLACEZAMJESEC.PromptChar = ' ';
            this.textPRPLACEZAMJESEC.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPRPLACEZAMJESEC.DataBindings.Add(new Binding("Value", this.bindingSourcePRPLACE, "PRPLACEZAMJESEC"));
            this.textPRPLACEZAMJESEC.NumericType = NumericType.Integer;
            this.textPRPLACEZAMJESEC.MaskInput = "{LOC}-nn";
            this.layoutManagerformPRPLACE.Controls.Add(this.textPRPLACEZAMJESEC, 1, 0);
            this.layoutManagerformPRPLACE.SetColumnSpan(this.textPRPLACEZAMJESEC, 1);
            this.layoutManagerformPRPLACE.SetRowSpan(this.textPRPLACEZAMJESEC, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRPLACEZAMJESEC.Margin = padding;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.textPRPLACEZAMJESEC.MinimumSize = size;
            size = new System.Drawing.Size(0x1f, 0x16);
            this.textPRPLACEZAMJESEC.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRPLACEZAGODINU.Location = point;
            this.label1PRPLACEZAGODINU.Name = "label1PRPLACEZAGODINU";
            this.label1PRPLACEZAGODINU.TabIndex = 1;
            this.label1PRPLACEZAGODINU.Tag = "labelPRPLACEZAGODINU";
            this.label1PRPLACEZAGODINU.Text = "Za godinu:";
            this.label1PRPLACEZAGODINU.StyleSetName = "FieldUltraLabel";
            this.label1PRPLACEZAGODINU.AutoSize = true;
            this.label1PRPLACEZAGODINU.Anchor = AnchorStyles.Left;
            this.label1PRPLACEZAGODINU.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRPLACEZAGODINU.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1PRPLACEZAGODINU.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1PRPLACEZAGODINU.ImageSize = size;
            this.label1PRPLACEZAGODINU.Appearance.ForeColor = Color.Black;
            this.label1PRPLACEZAGODINU.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACE.Controls.Add(this.label1PRPLACEZAGODINU, 0, 1);
            this.layoutManagerformPRPLACE.SetColumnSpan(this.label1PRPLACEZAGODINU, 1);
            this.layoutManagerformPRPLACE.SetRowSpan(this.label1PRPLACEZAGODINU, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRPLACEZAGODINU.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRPLACEZAGODINU.MinimumSize = size;
            size = new System.Drawing.Size(0x4d, 0x17);
            this.label1PRPLACEZAGODINU.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRPLACEZAGODINU.Location = point;
            this.textPRPLACEZAGODINU.Name = "textPRPLACEZAGODINU";
            this.textPRPLACEZAGODINU.Tag = "PRPLACEZAGODINU";
            this.textPRPLACEZAGODINU.TabIndex = 0;
            this.textPRPLACEZAGODINU.Anchor = AnchorStyles.Left;
            this.textPRPLACEZAGODINU.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRPLACEZAGODINU.ReadOnly = false;
            this.textPRPLACEZAGODINU.PromptChar = ' ';
            this.textPRPLACEZAGODINU.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPRPLACEZAGODINU.DataBindings.Add(new Binding("Value", this.bindingSourcePRPLACE, "PRPLACEZAGODINU"));
            this.textPRPLACEZAGODINU.NumericType = NumericType.Integer;
            this.textPRPLACEZAGODINU.MaskInput = "{LOC}-nnnn";
            this.layoutManagerformPRPLACE.Controls.Add(this.textPRPLACEZAGODINU, 1, 1);
            this.layoutManagerformPRPLACE.SetColumnSpan(this.textPRPLACEZAGODINU, 1);
            this.layoutManagerformPRPLACE.SetRowSpan(this.textPRPLACEZAGODINU, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRPLACEZAGODINU.Margin = padding;
            size = new System.Drawing.Size(0x2d, 0x16);
            this.textPRPLACEZAGODINU.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x16);
            this.textPRPLACEZAGODINU.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRPLACEID.Location = point;
            this.label1PRPLACEID.Name = "label1PRPLACEID";
            this.label1PRPLACEID.TabIndex = 1;
            this.label1PRPLACEID.Tag = "labelPRPLACEID";
            this.label1PRPLACEID.Text = "Broj pripreme unutar mjeseca:";
            this.label1PRPLACEID.StyleSetName = "FieldUltraLabel";
            this.label1PRPLACEID.AutoSize = true;
            this.label1PRPLACEID.Anchor = AnchorStyles.Left;
            this.label1PRPLACEID.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRPLACEID.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1PRPLACEID.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1PRPLACEID.ImageSize = size;
            this.label1PRPLACEID.Appearance.ForeColor = Color.Black;
            this.label1PRPLACEID.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACE.Controls.Add(this.label1PRPLACEID, 0, 2);
            this.layoutManagerformPRPLACE.SetColumnSpan(this.label1PRPLACEID, 1);
            this.layoutManagerformPRPLACE.SetRowSpan(this.label1PRPLACEID, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRPLACEID.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRPLACEID.MinimumSize = size;
            size = new System.Drawing.Size(0xca, 0x17);
            this.label1PRPLACEID.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRPLACEID.Location = point;
            this.textPRPLACEID.Name = "textPRPLACEID";
            this.textPRPLACEID.Tag = "PRPLACEID";
            this.textPRPLACEID.TabIndex = 0;
            this.textPRPLACEID.Anchor = AnchorStyles.Left;
            this.textPRPLACEID.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRPLACEID.ReadOnly = false;
            this.textPRPLACEID.PromptChar = ' ';
            this.textPRPLACEID.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPRPLACEID.DataBindings.Add(new Binding("Value", this.bindingSourcePRPLACE, "PRPLACEID"));
            this.textPRPLACEID.NumericType = NumericType.Integer;
            this.textPRPLACEID.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformPRPLACE.Controls.Add(this.textPRPLACEID, 1, 2);
            this.layoutManagerformPRPLACE.SetColumnSpan(this.textPRPLACEID, 1);
            this.layoutManagerformPRPLACE.SetRowSpan(this.textPRPLACEID, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRPLACEID.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textPRPLACEID.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textPRPLACEID.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRPLACEOSNOVICA.Location = point;
            this.label1PRPLACEOSNOVICA.Name = "label1PRPLACEOSNOVICA";
            this.label1PRPLACEOSNOVICA.TabIndex = 1;
            this.label1PRPLACEOSNOVICA.Tag = "labelPRPLACEOSNOVICA";
            this.label1PRPLACEOSNOVICA.Text = "Osnovica:";
            this.label1PRPLACEOSNOVICA.StyleSetName = "FieldUltraLabel";
            this.label1PRPLACEOSNOVICA.AutoSize = true;
            this.label1PRPLACEOSNOVICA.Anchor = AnchorStyles.Left;
            this.label1PRPLACEOSNOVICA.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRPLACEOSNOVICA.Appearance.ForeColor = Color.Black;
            this.label1PRPLACEOSNOVICA.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACE.Controls.Add(this.label1PRPLACEOSNOVICA, 0, 3);
            this.layoutManagerformPRPLACE.SetColumnSpan(this.label1PRPLACEOSNOVICA, 1);
            this.layoutManagerformPRPLACE.SetRowSpan(this.label1PRPLACEOSNOVICA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRPLACEOSNOVICA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRPLACEOSNOVICA.MinimumSize = size;
            size = new System.Drawing.Size(0x4b, 0x17);
            this.label1PRPLACEOSNOVICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRPLACEOSNOVICA.Location = point;
            this.textPRPLACEOSNOVICA.Name = "textPRPLACEOSNOVICA";
            this.textPRPLACEOSNOVICA.Tag = "PRPLACEOSNOVICA";
            this.textPRPLACEOSNOVICA.TabIndex = 0;
            this.textPRPLACEOSNOVICA.Anchor = AnchorStyles.Left;
            this.textPRPLACEOSNOVICA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRPLACEOSNOVICA.ReadOnly = false;
            this.textPRPLACEOSNOVICA.PromptChar = ' ';
            this.textPRPLACEOSNOVICA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPRPLACEOSNOVICA.DataBindings.Add(new Binding("Value", this.bindingSourcePRPLACE, "PRPLACEOSNOVICA"));
            this.textPRPLACEOSNOVICA.NumericType = NumericType.Double;
            this.textPRPLACEOSNOVICA.MaxValue = 79228162514264337593543950335M;
            this.textPRPLACEOSNOVICA.MinValue = -79228162514264337593543950335M;
            this.textPRPLACEOSNOVICA.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformPRPLACE.Controls.Add(this.textPRPLACEOSNOVICA, 1, 3);
            this.layoutManagerformPRPLACE.SetColumnSpan(this.textPRPLACEOSNOVICA, 1);
            this.layoutManagerformPRPLACE.SetRowSpan(this.textPRPLACEOSNOVICA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRPLACEOSNOVICA.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textPRPLACEOSNOVICA.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textPRPLACEOSNOVICA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRPLACEPROSJECNISATI.Location = point;
            this.label1PRPLACEPROSJECNISATI.Name = "label1PRPLACEPROSJECNISATI";
            this.label1PRPLACEPROSJECNISATI.TabIndex = 1;
            this.label1PRPLACEPROSJECNISATI.Tag = "labelPRPLACEPROSJECNISATI";
            this.label1PRPLACEPROSJECNISATI.Text = "Prosječan broj sati:";
            this.label1PRPLACEPROSJECNISATI.StyleSetName = "FieldUltraLabel";
            this.label1PRPLACEPROSJECNISATI.AutoSize = true;
            this.label1PRPLACEPROSJECNISATI.Anchor = AnchorStyles.Left;
            this.label1PRPLACEPROSJECNISATI.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRPLACEPROSJECNISATI.Appearance.ForeColor = Color.Black;
            this.label1PRPLACEPROSJECNISATI.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACE.Controls.Add(this.label1PRPLACEPROSJECNISATI, 0, 4);
            this.layoutManagerformPRPLACE.SetColumnSpan(this.label1PRPLACEPROSJECNISATI, 1);
            this.layoutManagerformPRPLACE.SetRowSpan(this.label1PRPLACEPROSJECNISATI, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRPLACEPROSJECNISATI.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRPLACEPROSJECNISATI.MinimumSize = size;
            size = new System.Drawing.Size(0x87, 0x17);
            this.label1PRPLACEPROSJECNISATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRPLACEPROSJECNISATI.Location = point;
            this.textPRPLACEPROSJECNISATI.Name = "textPRPLACEPROSJECNISATI";
            this.textPRPLACEPROSJECNISATI.Tag = "PRPLACEPROSJECNISATI";
            this.textPRPLACEPROSJECNISATI.TabIndex = 0;
            this.textPRPLACEPROSJECNISATI.Anchor = AnchorStyles.Left;
            this.textPRPLACEPROSJECNISATI.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRPLACEPROSJECNISATI.ReadOnly = false;
            this.textPRPLACEPROSJECNISATI.PromptChar = ' ';
            this.textPRPLACEPROSJECNISATI.Enter += new EventHandler(this.numericEditor_Enter);
            this.textPRPLACEPROSJECNISATI.DataBindings.Add(new Binding("Value", this.bindingSourcePRPLACE, "PRPLACEPROSJECNISATI"));
            this.textPRPLACEPROSJECNISATI.NumericType = NumericType.Double;
            this.textPRPLACEPROSJECNISATI.MaxValue = 79228162514264337593543950335M;
            this.textPRPLACEPROSJECNISATI.MinValue = -79228162514264337593543950335M;
            this.textPRPLACEPROSJECNISATI.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            this.layoutManagerformPRPLACE.Controls.Add(this.textPRPLACEPROSJECNISATI, 1, 4);
            this.layoutManagerformPRPLACE.SetColumnSpan(this.textPRPLACEPROSJECNISATI, 1);
            this.layoutManagerformPRPLACE.SetRowSpan(this.textPRPLACEPROSJECNISATI, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRPLACEPROSJECNISATI.Margin = padding;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textPRPLACEPROSJECNISATI.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 0x16);
            this.textPRPLACEPROSJECNISATI.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1PRPLACEOPIS.Location = point;
            this.label1PRPLACEOPIS.Name = "label1PRPLACEOPIS";
            this.label1PRPLACEOPIS.TabIndex = 1;
            this.label1PRPLACEOPIS.Tag = "labelPRPLACEOPIS";
            this.label1PRPLACEOPIS.Text = "Opis:";
            this.label1PRPLACEOPIS.StyleSetName = "FieldUltraLabel";
            this.label1PRPLACEOPIS.AutoSize = true;
            this.label1PRPLACEOPIS.Anchor = AnchorStyles.Left;
            this.label1PRPLACEOPIS.Appearance.TextVAlign = VAlign.Middle;
            this.label1PRPLACEOPIS.Appearance.ForeColor = Color.Black;
            this.label1PRPLACEOPIS.BackColor = Color.Transparent;
            this.layoutManagerformPRPLACE.Controls.Add(this.label1PRPLACEOPIS, 0, 5);
            this.layoutManagerformPRPLACE.SetColumnSpan(this.label1PRPLACEOPIS, 1);
            this.layoutManagerformPRPLACE.SetRowSpan(this.label1PRPLACEOPIS, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1PRPLACEOPIS.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1PRPLACEOPIS.MinimumSize = size;
            size = new System.Drawing.Size(0x2e, 0x17);
            this.label1PRPLACEOPIS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textPRPLACEOPIS.Location = point;
            this.textPRPLACEOPIS.Name = "textPRPLACEOPIS";
            this.textPRPLACEOPIS.Tag = "PRPLACEOPIS";
            this.textPRPLACEOPIS.TabIndex = 0;
            this.textPRPLACEOPIS.Anchor = AnchorStyles.Left;
            this.textPRPLACEOPIS.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textPRPLACEOPIS.ReadOnly = false;
            this.textPRPLACEOPIS.DataBindings.Add(new Binding("Text", this.bindingSourcePRPLACE, "PRPLACEOPIS"));
            this.textPRPLACEOPIS.MaxLength = 50;
            this.layoutManagerformPRPLACE.Controls.Add(this.textPRPLACEOPIS, 1, 5);
            this.layoutManagerformPRPLACE.SetColumnSpan(this.textPRPLACEOPIS, 1);
            this.layoutManagerformPRPLACE.SetRowSpan(this.textPRPLACEOPIS, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textPRPLACEOPIS.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textPRPLACEOPIS.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textPRPLACEOPIS.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelPRPLACEPRPLACEELEMENTI.Location = point;
            this.grdLevelPRPLACEPRPLACEELEMENTI.Name = "grdLevelPRPLACEPRPLACEELEMENTI";
            this.layoutManagerformPRPLACE.Controls.Add(this.grdLevelPRPLACEPRPLACEELEMENTI, 0, 6);
            this.layoutManagerformPRPLACE.SetColumnSpan(this.grdLevelPRPLACEPRPLACEELEMENTI, 2);
            this.layoutManagerformPRPLACE.SetRowSpan(this.grdLevelPRPLACEPRPLACEELEMENTI, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelPRPLACEPRPLACEELEMENTI.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelPRPLACEPRPLACEELEMENTI.MinimumSize = size;
            size = new System.Drawing.Size(0x210, 200);
            this.grdLevelPRPLACEPRPLACEELEMENTI.Size = size;
            this.grdLevelPRPLACEPRPLACEELEMENTI.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsPRPLACEPRPLACEELEMENTI.Location = point;
            this.panelactionsPRPLACEPRPLACEELEMENTI.Name = "panelactionsPRPLACEPRPLACEELEMENTI";
            this.panelactionsPRPLACEPRPLACEELEMENTI.BackColor = Color.Transparent;
            this.panelactionsPRPLACEPRPLACEELEMENTI.Controls.Add(this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI);
            this.layoutManagerformPRPLACE.Controls.Add(this.panelactionsPRPLACEPRPLACEELEMENTI, 0, 7);
            this.layoutManagerformPRPLACE.SetColumnSpan(this.panelactionsPRPLACEPRPLACEELEMENTI, 2);
            this.layoutManagerformPRPLACE.SetRowSpan(this.panelactionsPRPLACEPRPLACEELEMENTI, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsPRPLACEPRPLACEELEMENTI.Margin = padding;
            size = new System.Drawing.Size(0x1ec, 0x19);
            this.panelactionsPRPLACEPRPLACEELEMENTI.MinimumSize = size;
            size = new System.Drawing.Size(0x1ec, 0x19);
            this.panelactionsPRPLACEPRPLACEELEMENTI.Size = size;
            this.panelactionsPRPLACEPRPLACEELEMENTI.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd.Location = point;
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd.Name = "linkLabelPRPLACEPRPLACEELEMENTIAdd";
            size = new System.Drawing.Size(140, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd.Size = size;
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd.Text = " Add Elementi u pripremi  ";
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd.Click += new EventHandler(this.PRPLACEPRPLACEELEMENTIAdd_Click);
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd.BackColor = Color.Transparent;
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd.Cursor = Cursors.Hand;
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd.AutoSize = true;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.Controls.Add(this.linkLabelPRPLACEPRPLACEELEMENTIAdd, 0, 0);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.SetColumnSpan(this.linkLabelPRPLACEPRPLACEELEMENTIAdd, 1);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.SetRowSpan(this.linkLabelPRPLACEPRPLACEELEMENTIAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd.Margin = padding;
            size = new System.Drawing.Size(140, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd.MinimumSize = size;
            size = new System.Drawing.Size(140, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate.Location = point;
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate.Name = "linkLabelPRPLACEPRPLACEELEMENTIUpdate";
            size = new System.Drawing.Size(0x9e, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate.Size = size;
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate.Text = " Update Elementi u pripremi  ";
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate.Click += new EventHandler(this.PRPLACEPRPLACEELEMENTIUpdate_Click);
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate.BackColor = Color.Transparent;
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate.Cursor = Cursors.Hand;
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate.AutoSize = true;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.Controls.Add(this.linkLabelPRPLACEPRPLACEELEMENTIUpdate, 1, 0);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.SetColumnSpan(this.linkLabelPRPLACEPRPLACEELEMENTIUpdate, 1);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.SetRowSpan(this.linkLabelPRPLACEPRPLACEELEMENTIUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate.Margin = padding;
            size = new System.Drawing.Size(0x9e, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x9e, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete.Location = point;
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete.Name = "linkLabelPRPLACEPRPLACEELEMENTIDelete";
            size = new System.Drawing.Size(0x9a, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete.Size = size;
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete.Text = " Delete Elementi u pripremi  ";
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete.Click += new EventHandler(this.PRPLACEPRPLACEELEMENTIDelete_Click);
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete.BackColor = Color.Transparent;
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete.Cursor = Cursors.Hand;
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete.AutoSize = true;
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.Controls.Add(this.linkLabelPRPLACEPRPLACEELEMENTIDelete, 2, 0);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.SetColumnSpan(this.linkLabelPRPLACEPRPLACEELEMENTIDelete, 1);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.SetRowSpan(this.linkLabelPRPLACEPRPLACEELEMENTIDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete.Margin = padding;
            size = new System.Drawing.Size(0x9a, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x9a, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelPRPLACEPRPLACEELEMENTI.Location = point;
            this.linkLabelPRPLACEPRPLACEELEMENTI.Name = "linkLabelPRPLACEPRPLACEELEMENTI";
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.Controls.Add(this.linkLabelPRPLACEPRPLACEELEMENTI, 3, 0);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.SetColumnSpan(this.linkLabelPRPLACEPRPLACEELEMENTI, 1);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.SetRowSpan(this.linkLabelPRPLACEPRPLACEELEMENTI, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelPRPLACEPRPLACEELEMENTI.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTI.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelPRPLACEPRPLACEELEMENTI.Size = size;
            this.linkLabelPRPLACEPRPLACEELEMENTI.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformPRPLACE);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourcePRPLACE;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.Disabled;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.PRPLACEPRPLACEZAMJESECDescription;
            column7.Width = 0x4e;
            appearance6.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nn";
            column7.PromptChar = ' ';
            column7.Format = "";
            column7.CellAppearance = appearance6;
            column7.Hidden = true;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.Disabled;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.PRPLACEPRPLACEIDDescription;
            column5.Width = 0xcf;
            appearance4.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnn";
            column5.PromptChar = ' ';
            column5.Format = "";
            column5.CellAppearance = appearance4;
            column5.Hidden = true;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.Disabled;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.PRPLACEPRPLACEZAGODINUDescription;
            column6.Width = 0x4e;
            appearance5.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnn";
            column6.PromptChar = ' ';
            column6.Format = "";
            column6.CellAppearance = appearance5;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.PRPLACEIDELEMENTDescription;
            column.Width = 0x70;
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
            column2.Tag = "ELEMENTIDELEMENTAddNew";
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.Disabled;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.PRPLACENAZIVELEMENTDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.Disabled;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.PRPLACEPOSTOTAKDescription;
            column4.Width = 0x4b;
            appearance3.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.Disabled;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.PRPLACEPRPLACEZAMJESECDescription;
            column20.Width = 0x4e;
            appearance17.TextHAlign = HAlign.Right;
            column20.MaskInput = "{LOC}-nn";
            column20.PromptChar = ' ';
            column20.Format = "";
            column20.CellAppearance = appearance17;
            column20.Hidden = true;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.Disabled;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.PRPLACEPRPLACEIDDescription;
            column14.Width = 0xcf;
            appearance11.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnn";
            column14.PromptChar = ' ';
            column14.Format = "";
            column14.CellAppearance = appearance11;
            column14.Hidden = true;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.Disabled;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.PRPLACEPRPLACEZAGODINUDescription;
            column19.Width = 0x4e;
            appearance16.TextHAlign = HAlign.Right;
            column19.MaskInput = "{LOC}-nnnn";
            column19.PromptChar = ' ';
            column19.Format = "";
            column19.CellAppearance = appearance16;
            column19.Hidden = true;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.Disabled;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.PRPLACEIDELEMENTDescription;
            column8.Width = 0x70;
            column8.Format = "";
            column8.CellAppearance = appearance7;
            column8.Hidden = true;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.PRPLACEIDRADNIKDescription;
            column10.Width = 0x55;
            column10.Format = "";
            column10.CellAppearance = appearance8;
            column10.Hidden = true;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.Disabled;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.PRPLACEPREZIMEDescription;
            column13.Width = 0x128;
            column13.Format = "";
            column13.CellAppearance = appearance10;
            column13.Hidden = true;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.Disabled;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.PRPLACEIMEDescription;
            column12.Width = 0x128;
            column12.Format = "";
            column12.CellAppearance = appearance9;
            column12.Hidden = true;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.PRPLACEPRPLACESATIDescription;
            column17.Width = 0x37;
            appearance14.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnn.nn";
            column17.PromptChar = ' ';
            column17.Format = "F2";
            column17.CellAppearance = appearance14;
            column17.Hidden = true;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.PRPLACEPRPLACESATNICADescription;
            column18.Width = 0x45;
            appearance15.TextHAlign = HAlign.Right;
            column18.MaskInput = "{LOC}-nnn.nn";
            column18.PromptChar = ' ';
            column18.Format = "F2";
            column18.CellAppearance = appearance15;
            column18.Hidden = true;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.PRPLACEPRPLACEPOSTOTAKDescription;
            column16.Width = 0x4b;
            appearance13.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnn.nn";
            column16.PromptChar = ' ';
            column16.Format = "F2";
            column16.CellAppearance = appearance13;
            column16.Hidden = true;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.PRPLACEPRPLACEIZNOSDescription;
            column15.Width = 0x66;
            appearance12.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance12;
            column15.Hidden = true;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.Disabled;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.PRPLACESPOJENOPREZIMEDescription;
            column21.Width = 0x128;
            column21.Format = "";
            column21.CellAppearance = appearance18;
            column21.Hidden = true;
            band2.Columns.Add(column8);
            column8.Header.VisiblePosition = 0;
            band2.Columns.Add(column20);
            column20.Header.VisiblePosition = 1;
            band2.Columns.Add(column14);
            column14.Header.VisiblePosition = 2;
            band2.Columns.Add(column19);
            column19.Header.VisiblePosition = 3;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 4;
            band2.Columns.Add(column13);
            column13.Header.VisiblePosition = 5;
            band2.Columns.Add(column12);
            column12.Header.VisiblePosition = 6;
            band2.Columns.Add(column17);
            column17.Header.VisiblePosition = 7;
            band2.Columns.Add(column18);
            column18.Header.VisiblePosition = 8;
            band2.Columns.Add(column16);
            column16.Header.VisiblePosition = 9;
            band2.Columns.Add(column15);
            column15.Header.VisiblePosition = 10;
            band2.Columns.Add(column21);
            column21.Header.VisiblePosition = 11;
            band2.Hidden = true;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 1;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 2;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 3;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 4;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 5;
            this.grdLevelPRPLACEPRPLACEELEMENTI.Visible = true;
            this.grdLevelPRPLACEPRPLACEELEMENTI.Name = "grdLevelPRPLACEPRPLACEELEMENTI";
            this.grdLevelPRPLACEPRPLACEELEMENTI.Tag = "PRPLACEPRPLACEELEMENTI";
            this.grdLevelPRPLACEPRPLACEELEMENTI.TabIndex = 0x12;
            this.grdLevelPRPLACEPRPLACEELEMENTI.Dock = DockStyle.Fill;
            this.grdLevelPRPLACEPRPLACEELEMENTI.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelPRPLACEPRPLACEELEMENTI.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelPRPLACEPRPLACEELEMENTI.DataSource = this.bindingSourcePRPLACEPRPLACEELEMENTI;
            this.grdLevelPRPLACEPRPLACEELEMENTI.Enter += new EventHandler(this.grdLevelPRPLACEPRPLACEELEMENTI_Enter);
            this.grdLevelPRPLACEPRPLACEELEMENTI.AfterRowInsert += new RowEventHandler(this.grdLevelPRPLACEPRPLACEELEMENTI_AfterRowInsert);
            this.grdLevelPRPLACEPRPLACEELEMENTI.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelPRPLACEPRPLACEELEMENTI.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelPRPLACEPRPLACEELEMENTI.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelPRPLACEPRPLACEELEMENTI.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelPRPLACEPRPLACEELEMENTI_DoubleClick);
            this.grdLevelPRPLACEPRPLACEELEMENTI.AfterRowActivate += new EventHandler(this.grdLevelPRPLACEPRPLACEELEMENTI_AfterRowActivate);
            this.grdLevelPRPLACEPRPLACEELEMENTI.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelPRPLACEPRPLACEELEMENTI.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelPRPLACEPRPLACEELEMENTI.DisplayLayout.BandsSerializer.Add(band);
            this.grdLevelPRPLACEPRPLACEELEMENTI.DisplayLayout.BandsSerializer.Add(band2);
            this.Name = "PRPLACEFormUserControl";
            this.Text = "Priprema plaae";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.PRPLACEFormUserControl_Load);
            this.layoutManagerformPRPLACE.ResumeLayout(false);
            this.layoutManagerformPRPLACE.PerformLayout();
            ((ISupportInitialize) this.bindingSourcePRPLACE).EndInit();
            ((ISupportInitialize) this.bindingSourcePRPLACEPRPLACEELEMENTI).EndInit();
            ((ISupportInitialize) this.textPRPLACEZAMJESEC).EndInit();
            ((ISupportInitialize) this.textPRPLACEZAGODINU).EndInit();
            ((ISupportInitialize) this.textPRPLACEID).EndInit();
            ((ISupportInitialize) this.textPRPLACEOSNOVICA).EndInit();
            ((ISupportInitialize) this.textPRPLACEPROSJECNISATI).EndInit();
            ((ISupportInitialize) this.textPRPLACEOPIS).EndInit();
            ((ISupportInitialize) this.grdLevelPRPLACEPRPLACEELEMENTI).EndInit();
            this.panelactionsPRPLACEPRPLACEELEMENTI.ResumeLayout(true);
            this.panelactionsPRPLACEPRPLACEELEMENTI.PerformLayout();
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.ResumeLayout(false);
            this.layoutManagerpanelactionsPRPLACEPRPLACEELEMENTI.PerformLayout();
            this.dsPRPLACEDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.PRPLACEController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourcePRPLACE, this.PRPLACEController.WorkItem, this))
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
            this.label1PRPLACEZAMJESEC.Text = StringResources.PRPLACEPRPLACEZAMJESECDescription;
            this.label1PRPLACEZAGODINU.Text = StringResources.PRPLACEPRPLACEZAGODINUDescription;
            this.label1PRPLACEID.Text = StringResources.PRPLACEPRPLACEIDDescription;
            this.label1PRPLACEOSNOVICA.Text = StringResources.PRPLACEPRPLACEOSNOVICADescription;
            this.label1PRPLACEPROSJECNISATI.Text = StringResources.PRPLACEPRPLACEPROSJECNISATIDescription;
            this.label1PRPLACEOPIS.Text = StringResources.PRPLACEPRPLACEOPISDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedInLinesIDELEMENT(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ELEMENT", null, DeklaritMode.Insert));
            }
        }

        private void PRPLACEFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.PRPLACEDescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelPRPLACEPRPLACEELEMENTIAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.PRPLACEPRPLACEPRPLACEELEMENTILevelDescription;
            this.linkLabelPRPLACEPRPLACEELEMENTIUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.PRPLACEPRPLACEPRPLACEELEMENTILevelDescription;
            this.linkLabelPRPLACEPRPLACEELEMENTIDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.PRPLACEPRPLACEPRPLACEELEMENTILevelDescription;
        }

        private void PRPLACEPRPLACEELEMENTIAdd_Click(object sender, EventArgs e)
        {
            if ((this.grdLevelPRPLACEPRPLACEELEMENTI.ActiveRow != null) && this.grdLevelPRPLACEPRPLACEELEMENTI.ActiveRow.Band.Key.EndsWith("_PRPLACEPRPLACEELEMENTIRADNIK"))
            {
                this.PRPLACEPRPLACEELEMENTIRADNIKInsert();
            }
            else
            {
                this.PRPLACEPRPLACEELEMENTIInsert();
            }
        }

        private void PRPLACEPRPLACEELEMENTIDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelPRPLACEPRPLACEELEMENTI);
            if ((currentRowListIndex != -1) && (this.grdLevelPRPLACEPRPLACEELEMENTI.Selected.Rows.Count > 0))
            {
                this.grdLevelPRPLACEPRPLACEELEMENTI.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelPRPLACEPRPLACEELEMENTI).Selected = true;
                this.grdLevelPRPLACEPRPLACEELEMENTI.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ELEMENT", Thread=ThreadOption.UserInterface)]
        public void PRPLACEPRPLACEELEMENTIIDELEMENT_Add(object sender, ComponentEventArgs e)
        {
            PROVIDER_BRUTOComboBox box = new PROVIDER_BRUTOComboBox();
            box.Fill();
            DataView defaultView = box.DataSet.Tables["ELEMENT"].DefaultView;
            if ((this.grdLevelPRPLACEPRPLACEELEMENTI.ActiveRow != null) && (this.grdLevelPRPLACEPRPLACEELEMENTI.ActiveRow.Cells["IDELEMENT"] != null))
            {
                ValueList myValueList = new ValueList();
                LoadValueList(myValueList, defaultView, "IDELEMENT", "EL");
                this.grdLevelPRPLACEPRPLACEELEMENTI.ActiveRow.Cells["IDELEMENT"].ValueList = myValueList;
            }
            else
            {
                CreateValueList(this.grdLevelPRPLACEPRPLACEELEMENTI, "ELEMENTIDELEMENT", defaultView, "IDELEMENT", "EL", true);
            }
        }

        private void PRPLACEPRPLACEELEMENTIInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourcePRPLACE, this.PRPLACEController.WorkItem, this))
            {
                this.PRPLACEController.AddPRPLACEPRPLACEELEMENTI(this.m_CurrentRow);
            }
        }

        private void PRPLACEPRPLACEELEMENTIRADNIKInsert()
        {
            if (this.grdLevelPRPLACEPRPLACEELEMENTI.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelPRPLACEPRPLACEELEMENTI.ActiveRow.ListObject;
                DataRow parentRow = listObject.Row.GetParentRow("PRPLACEPRPLACEELEMENTI_PRPLACEPRPLACEELEMENTIRADNIK");
                this.PRPLACEController.AddPRPLACEPRPLACEELEMENTIRADNIK(parentRow);
            }
        }

        private void PRPLACEPRPLACEELEMENTIRADNIKUpdate()
        {
            if (this.grdLevelPRPLACEPRPLACEELEMENTI.ActiveRow.ListObject is DataRowView)
            {
                DataRowView listObject = (DataRowView) this.grdLevelPRPLACEPRPLACEELEMENTI.ActiveRow.ListObject;
                this.PRPLACEController.UpdatePRPLACEPRPLACEELEMENTIRADNIK(listObject.Row);
            }
        }

        private void PRPLACEPRPLACEELEMENTIUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelPRPLACEPRPLACEELEMENTI) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelPRPLACEPRPLACEELEMENTI);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.PRPLACEController.UpdatePRPLACEPRPLACEELEMENTI(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void PRPLACEPRPLACEELEMENTIUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelPRPLACEPRPLACEELEMENTI.ActiveRow != null)
            {
                if (this.grdLevelPRPLACEPRPLACEELEMENTI.ActiveRow.Band.Key.EndsWith("_PRPLACEPRPLACEELEMENTIRADNIK"))
                {
                    this.PRPLACEPRPLACEELEMENTIRADNIKUpdate();
                }
                else
                {
                    this.PRPLACEPRPLACEELEMENTIUpdate();
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.PRPLACEController.WorkItem.Items.Contains("PRPLACE|PRPLACE"))
            {
                this.PRPLACEController.WorkItem.Items.Add(this.bindingSourcePRPLACE, "PRPLACE|PRPLACE");
            }
            if (!this.PRPLACEController.WorkItem.Items.Contains("PRPLACE|PRPLACEPRPLACEELEMENTI"))
            {
                this.PRPLACEController.WorkItem.Items.Add(this.bindingSourcePRPLACEPRPLACEELEMENTI, "PRPLACE|PRPLACEPRPLACEELEMENTI");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsPRPLACEDataSet1.PRPLACE.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.PRPLACEController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.PRPLACEController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.PRPLACEController.Update(this))
            {
                this.PRPLACEController.DataSet = new PRPLACEDataSet();
                DataSetUtil.AddEmptyRow(this.PRPLACEController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.PRPLACEController.DataSet.PRPLACE[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetComboBoxColumnProperties()
        {
            PROVIDER_BRUTOComboBox box = new PROVIDER_BRUTOComboBox();
            box.Fill();
            DataView defaultView = box.DataSet.Tables["ELEMENT"].DefaultView;
            CreateValueList(this.grdLevelPRPLACEPRPLACEELEMENTI, "ELEMENTIDELEMENT", defaultView, "IDELEMENT", "EL", false);
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelPRPLACEPRPLACEELEMENTI, "IDELEMENT");
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            gridColumn.ValueList = this.grdLevelPRPLACEPRPLACEELEMENTI.DisplayLayout.ValueLists["ELEMENTIDELEMENT"];
            gridColumn.Width = 370;
            this.grdLevelPRPLACEPRPLACEELEMENTI.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelPRPLACEPRPLACEELEMENTI.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.textPRPLACEZAMJESEC.Focus();
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

        private void UpdateValuesIDELEMENT(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["IDELEMENT"] = RuntimeHelpers.GetObjectValue(result["IDELEMENT"]);
                    row["NAZIVELEMENT"] = RuntimeHelpers.GetObjectValue(result["NAZIVELEMENT"]);
                    row["POSTOTAK"] = RuntimeHelpers.GetObjectValue(result["POSTOTAK"]);
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

        protected virtual UltraGrid grdLevelPRPLACEPRPLACEELEMENTI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelPRPLACEPRPLACEELEMENTI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelPRPLACEPRPLACEELEMENTI = value;
            }
        }

        protected virtual UltraLabel label1PRPLACEID
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRPLACEID;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRPLACEID = value;
            }
        }

        protected virtual UltraLabel label1PRPLACEOPIS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRPLACEOPIS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRPLACEOPIS = value;
            }
        }

        protected virtual UltraLabel label1PRPLACEOSNOVICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRPLACEOSNOVICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRPLACEOSNOVICA = value;
            }
        }

        protected virtual UltraLabel label1PRPLACEPROSJECNISATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRPLACEPROSJECNISATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRPLACEPROSJECNISATI = value;
            }
        }

        protected virtual UltraLabel label1PRPLACEZAGODINU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRPLACEZAGODINU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRPLACEZAGODINU = value;
            }
        }

        protected virtual UltraLabel label1PRPLACEZAMJESEC
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1PRPLACEZAMJESEC;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1PRPLACEZAMJESEC = value;
            }
        }

        protected virtual UltraLabel linkLabelPRPLACEPRPLACEELEMENTI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPRPLACEPRPLACEELEMENTI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPRPLACEPRPLACEELEMENTI = value;
            }
        }

        protected virtual UltraLabel linkLabelPRPLACEPRPLACEELEMENTIAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPRPLACEPRPLACEELEMENTIAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPRPLACEPRPLACEELEMENTIAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelPRPLACEPRPLACEELEMENTIDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPRPLACEPRPLACEELEMENTIDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPRPLACEPRPLACEELEMENTIDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelPRPLACEPRPLACEELEMENTIUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelPRPLACEPRPLACEELEMENTIUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelPRPLACEPRPLACEELEMENTIUpdate = value;
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

        protected virtual Panel panelactionsPRPLACEPRPLACEELEMENTI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsPRPLACEPRPLACEELEMENTI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsPRPLACEPRPLACEELEMENTI = value;
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

        protected virtual UltraNumericEditor textPRPLACEID
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRPLACEID;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRPLACEID = value;
            }
        }

        protected virtual UltraTextEditor textPRPLACEOPIS
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRPLACEOPIS;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRPLACEOPIS = value;
            }
        }

        protected virtual UltraNumericEditor textPRPLACEOSNOVICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRPLACEOSNOVICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRPLACEOSNOVICA = value;
            }
        }

        protected virtual UltraNumericEditor textPRPLACEPROSJECNISATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRPLACEPROSJECNISATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRPLACEPROSJECNISATI = value;
            }
        }

        protected virtual UltraNumericEditor textPRPLACEZAGODINU
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRPLACEZAGODINU;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRPLACEZAGODINU = value;
            }
        }

        protected virtual UltraNumericEditor textPRPLACEZAMJESEC
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textPRPLACEZAMJESEC;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textPRPLACEZAMJESEC = value;
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

