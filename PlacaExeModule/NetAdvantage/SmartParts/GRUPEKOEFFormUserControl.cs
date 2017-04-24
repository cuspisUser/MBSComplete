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
    public class GRUPEKOEFFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelGRUPEKOEFLevel1")]
        private UltraGrid _grdLevelGRUPEKOEFLevel1;
        [AccessedThroughProperty("label1IDGRUPEKOEF")]
        private UltraLabel _label1IDGRUPEKOEF;
        [AccessedThroughProperty("label1NAZIVGRUPEKOEF")]
        private UltraLabel _label1NAZIVGRUPEKOEF;
        [AccessedThroughProperty("linkLabelGRUPEKOEFLevel1")]
        private UltraLabel _linkLabelGRUPEKOEFLevel1;
        [AccessedThroughProperty("linkLabelGRUPEKOEFLevel1Add")]
        private UltraLabel _linkLabelGRUPEKOEFLevel1Add;
        [AccessedThroughProperty("linkLabelGRUPEKOEFLevel1Delete")]
        private UltraLabel _linkLabelGRUPEKOEFLevel1Delete;
        [AccessedThroughProperty("linkLabelGRUPEKOEFLevel1Update")]
        private UltraLabel _linkLabelGRUPEKOEFLevel1Update;
        [AccessedThroughProperty("panelactionsGRUPEKOEFLevel1")]
        private Panel _panelactionsGRUPEKOEFLevel1;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDGRUPEKOEF")]
        private UltraNumericEditor _textIDGRUPEKOEF;
        [AccessedThroughProperty("textNAZIVGRUPEKOEF")]
        private UltraTextEditor _textNAZIVGRUPEKOEF;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceGRUPEKOEF;
        private BindingSource bindingSourceGRUPEKOEFLevel1;
        private IContainer components = null;
        private GRUPEKOEFDataSet dsGRUPEKOEFDataSet1;
        protected TableLayoutPanel layoutManagerformGRUPEKOEF;
        protected TableLayoutPanel layoutManagerpanelactionsGRUPEKOEFLevel1;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private GRUPEKOEFDataSet.GRUPEKOEFRow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "GRUPEKOEF";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.GRUPEKOEFDescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public GRUPEKOEFFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptInLinesMZOSTABLICEIDMZOSTABLICE(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.GRUPEKOEFController.SelectMZOSTABLICEIDMZOSTABLICE("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDMZOSTABLICE"] = RuntimeHelpers.GetObjectValue(row2["IDMZOSTABLICE"]);
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
            this.m_BaseMethods.CellChangedBase(this.dsGRUPEKOEFDataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceGRUPEKOEF.DataSource = this.GRUPEKOEFController.DataSet;
            this.dsGRUPEKOEFDataSet1 = this.GRUPEKOEFController.DataSet;
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
                    enumerator = this.dsGRUPEKOEFDataSet1.GRUPEKOEF.Rows.GetEnumerator();
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
                if (this.GRUPEKOEFController.Update(this))
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
                    case "ELEMENTIDELEMENTAddNew":
                        this.PictureBoxClickedInLinesIDELEMENT(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "MZOSTABLICEIDMZOSTABLICE":
                        this.CallPromptInLinesMZOSTABLICEIDMZOSTABLICE(RuntimeHelpers.GetObjectValue(sender), e);
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
            if (this.grdLevelGRUPEKOEFLevel1.ActiveRow != null)
            {
                this.grdLevelGRUPEKOEFLevel1.PerformAction(UltraGridAction.NextRow);
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

        private void grdLevelGRUPEKOEFLevel1_AfterRowActivate(object sender, EventArgs e)
        {
            string str = StringResources.GRUPEKOEFGRUPEKOEFLevel1LevelDescription;
            UltraGridRow activeRow = this.grdLevelGRUPEKOEFLevel1.ActiveRow;
            this.linkLabelGRUPEKOEFLevel1Add.Text = Deklarit.Resources.Resources.Add + " " + str;
            this.linkLabelGRUPEKOEFLevel1Update.Text = Deklarit.Resources.Resources.Update + " " + str;
            this.linkLabelGRUPEKOEFLevel1Delete.Text = Deklarit.Resources.Resources.Delete + " " + str;
        }

        private void grdLevelGRUPEKOEFLevel1_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceGRUPEKOEF.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceGRUPEKOEF.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelGRUPEKOEFLevel1_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.GRUPEKOEFLevel1Update_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelGRUPEKOEFLevel1_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceGRUPEKOEF, this.GRUPEKOEFController.WorkItem, this);
        }

        private void GRUPEKOEFFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.GRUPEKOEFDescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelGRUPEKOEFLevel1Add.Text = Deklarit.Resources.Resources.Add + " " + StringResources.GRUPEKOEFGRUPEKOEFLevel1LevelDescription;
            this.linkLabelGRUPEKOEFLevel1Update.Text = Deklarit.Resources.Resources.Update + " " + StringResources.GRUPEKOEFGRUPEKOEFLevel1LevelDescription;
            this.linkLabelGRUPEKOEFLevel1Delete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.GRUPEKOEFGRUPEKOEFLevel1LevelDescription;
        }

        private void GRUPEKOEFLevel1Add_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelGRUPEKOEFLevel1.ActiveRow;
            this.GRUPEKOEFLevel1Insert();
        }

        private void GRUPEKOEFLevel1Delete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelGRUPEKOEFLevel1);
            if ((currentRowListIndex != -1) && (this.grdLevelGRUPEKOEFLevel1.Selected.Rows.Count > 0))
            {
                this.grdLevelGRUPEKOEFLevel1.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelGRUPEKOEFLevel1).Selected = true;
                this.grdLevelGRUPEKOEFLevel1.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/ELEMENT", Thread=ThreadOption.UserInterface)]
        public void GRUPEKOEFLevel1IDELEMENT_Add(object sender, ComponentEventArgs e)
        {
            PROVIDER_BRUTOComboBox box = new PROVIDER_BRUTOComboBox();
            box.Fill();
            DataView defaultView = box.DataSet.Tables["ELEMENT"].DefaultView;
            if ((this.grdLevelGRUPEKOEFLevel1.ActiveRow != null) && (this.grdLevelGRUPEKOEFLevel1.ActiveRow.Cells["IDELEMENT"] != null))
            {
                ValueList myValueList = new ValueList();
                LoadValueList(myValueList, defaultView, "IDELEMENT", "EL");
                this.grdLevelGRUPEKOEFLevel1.ActiveRow.Cells["IDELEMENT"].ValueList = myValueList;
            }
            else
            {
                CreateValueList(this.grdLevelGRUPEKOEFLevel1, "ELEMENTIDELEMENT", defaultView, "IDELEMENT", "EL", true);
            }
        }

        private void GRUPEKOEFLevel1Insert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceGRUPEKOEF, this.GRUPEKOEFController.WorkItem, this))
            {
                this.GRUPEKOEFController.AddGRUPEKOEFLevel1(this.m_CurrentRow);
            }
        }

        private void GRUPEKOEFLevel1Update()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelGRUPEKOEFLevel1) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelGRUPEKOEFLevel1);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.GRUPEKOEFController.UpdateGRUPEKOEFLevel1(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void GRUPEKOEFLevel1Update_Click(object sender, EventArgs e)
        {
            if (this.grdLevelGRUPEKOEFLevel1.ActiveRow != null)
            {
                this.GRUPEKOEFLevel1Update();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "GRUPEKOEF", this.m_Mode, this.dsGRUPEKOEFDataSet1, this.dsGRUPEKOEFDataSet1.GRUPEKOEF.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            if (!this.m_DataGrids.Contains(this.grdLevelGRUPEKOEFLevel1))
            {
                this.m_DataGrids.Add(this.grdLevelGRUPEKOEFLevel1);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsGRUPEKOEFDataSet1.GRUPEKOEF[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (GRUPEKOEFDataSet.GRUPEKOEFRow) ((DataRowView) this.bindingSourceGRUPEKOEF.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(GRUPEKOEFFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceGRUPEKOEF = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceGRUPEKOEF).BeginInit();
            this.bindingSourceGRUPEKOEFLevel1 = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceGRUPEKOEFLevel1).BeginInit();
            this.layoutManagerformGRUPEKOEF = new TableLayoutPanel();
            this.layoutManagerformGRUPEKOEF.SuspendLayout();
            this.layoutManagerformGRUPEKOEF.AutoSize = true;
            this.layoutManagerformGRUPEKOEF.Dock = DockStyle.Fill;
            this.layoutManagerformGRUPEKOEF.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformGRUPEKOEF.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformGRUPEKOEF.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformGRUPEKOEF.Size = size;
            this.layoutManagerformGRUPEKOEF.ColumnCount = 2;
            this.layoutManagerformGRUPEKOEF.RowCount = 4;
            this.layoutManagerformGRUPEKOEF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformGRUPEKOEF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformGRUPEKOEF.RowStyles.Add(new RowStyle());
            this.layoutManagerformGRUPEKOEF.RowStyles.Add(new RowStyle());
            this.layoutManagerformGRUPEKOEF.RowStyles.Add(new RowStyle());
            this.layoutManagerformGRUPEKOEF.RowStyles.Add(new RowStyle());
            this.label1IDGRUPEKOEF = new UltraLabel();
            this.textIDGRUPEKOEF = new UltraNumericEditor();
            this.label1NAZIVGRUPEKOEF = new UltraLabel();
            this.textNAZIVGRUPEKOEF = new UltraTextEditor();
            this.grdLevelGRUPEKOEFLevel1 = new UltraGrid();
            this.panelactionsGRUPEKOEFLevel1 = new Panel();
            this.layoutManagerpanelactionsGRUPEKOEFLevel1 = new TableLayoutPanel();
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.AutoSize = true;
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.ColumnCount = 4;
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.RowCount = 1;
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.RowStyles.Add(new RowStyle());
            this.linkLabelGRUPEKOEFLevel1Add = new UltraLabel();
            this.linkLabelGRUPEKOEFLevel1Update = new UltraLabel();
            this.linkLabelGRUPEKOEFLevel1Delete = new UltraLabel();
            this.linkLabelGRUPEKOEFLevel1 = new UltraLabel();
            ((ISupportInitialize) this.textIDGRUPEKOEF).BeginInit();
            ((ISupportInitialize) this.textNAZIVGRUPEKOEF).BeginInit();
            ((ISupportInitialize) this.grdLevelGRUPEKOEFLevel1).BeginInit();
            this.panelactionsGRUPEKOEFLevel1.SuspendLayout();
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.SuspendLayout();
            UltraGridBand band = new UltraGridBand("GRUPEKOEFLevel1", -1);
            UltraGridColumn column3 = new UltraGridColumn("IDGRUPEKOEF");
            UltraGridColumn column = new UltraGridColumn("IDELEMENT");
            UltraGridColumn column2 = new UltraGridColumn("columnIDELEMENTAddNew", 0);
            UltraGridColumn column5 = new UltraGridColumn("NAZIVELEMENT");
            UltraGridColumn column4 = new UltraGridColumn("IDMZOSTABLICE");
            this.dsGRUPEKOEFDataSet1 = new GRUPEKOEFDataSet();
            this.dsGRUPEKOEFDataSet1.BeginInit();
            this.SuspendLayout();
            this.dsGRUPEKOEFDataSet1.DataSetName = "dsGRUPEKOEF";
            this.dsGRUPEKOEFDataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceGRUPEKOEF.DataSource = this.dsGRUPEKOEFDataSet1;
            this.bindingSourceGRUPEKOEF.DataMember = "GRUPEKOEF";
            ((ISupportInitialize) this.bindingSourceGRUPEKOEF).BeginInit();
            this.bindingSourceGRUPEKOEFLevel1.DataSource = this.bindingSourceGRUPEKOEF;
            this.bindingSourceGRUPEKOEFLevel1.DataMember = "GRUPEKOEF_GRUPEKOEFLevel1";
            point = new System.Drawing.Point(0, 0);
            this.label1IDGRUPEKOEF.Location = point;
            this.label1IDGRUPEKOEF.Name = "label1IDGRUPEKOEF";
            this.label1IDGRUPEKOEF.TabIndex = 1;
            this.label1IDGRUPEKOEF.Tag = "labelIDGRUPEKOEF";
            this.label1IDGRUPEKOEF.Text = "Šifra:";
            this.label1IDGRUPEKOEF.StyleSetName = "FieldUltraLabel";
            this.label1IDGRUPEKOEF.AutoSize = true;
            this.label1IDGRUPEKOEF.Anchor = AnchorStyles.Left;
            this.label1IDGRUPEKOEF.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDGRUPEKOEF.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDGRUPEKOEF.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDGRUPEKOEF.ImageSize = size;
            this.label1IDGRUPEKOEF.Appearance.ForeColor = Color.Black;
            this.label1IDGRUPEKOEF.BackColor = Color.Transparent;
            this.layoutManagerformGRUPEKOEF.Controls.Add(this.label1IDGRUPEKOEF, 0, 0);
            this.layoutManagerformGRUPEKOEF.SetColumnSpan(this.label1IDGRUPEKOEF, 1);
            this.layoutManagerformGRUPEKOEF.SetRowSpan(this.label1IDGRUPEKOEF, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDGRUPEKOEF.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDGRUPEKOEF.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDGRUPEKOEF.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDGRUPEKOEF.Location = point;
            this.textIDGRUPEKOEF.Name = "textIDGRUPEKOEF";
            this.textIDGRUPEKOEF.Tag = "IDGRUPEKOEF";
            this.textIDGRUPEKOEF.TabIndex = 0;
            this.textIDGRUPEKOEF.Anchor = AnchorStyles.Left;
            this.textIDGRUPEKOEF.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDGRUPEKOEF.ReadOnly = false;
            this.textIDGRUPEKOEF.PromptChar = ' ';
            this.textIDGRUPEKOEF.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDGRUPEKOEF.DataBindings.Add(new Binding("Value", this.bindingSourceGRUPEKOEF, "IDGRUPEKOEF"));
            this.textIDGRUPEKOEF.NumericType = NumericType.Integer;
            this.textIDGRUPEKOEF.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformGRUPEKOEF.Controls.Add(this.textIDGRUPEKOEF, 1, 0);
            this.layoutManagerformGRUPEKOEF.SetColumnSpan(this.textIDGRUPEKOEF, 1);
            this.layoutManagerformGRUPEKOEF.SetRowSpan(this.textIDGRUPEKOEF, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDGRUPEKOEF.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDGRUPEKOEF.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDGRUPEKOEF.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVGRUPEKOEF.Location = point;
            this.label1NAZIVGRUPEKOEF.Name = "label1NAZIVGRUPEKOEF";
            this.label1NAZIVGRUPEKOEF.TabIndex = 1;
            this.label1NAZIVGRUPEKOEF.Tag = "labelNAZIVGRUPEKOEF";
            this.label1NAZIVGRUPEKOEF.Text = "Naziv:";
            this.label1NAZIVGRUPEKOEF.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVGRUPEKOEF.AutoSize = true;
            this.label1NAZIVGRUPEKOEF.Anchor = AnchorStyles.Left;
            this.label1NAZIVGRUPEKOEF.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVGRUPEKOEF.Appearance.ForeColor = Color.Black;
            this.label1NAZIVGRUPEKOEF.BackColor = Color.Transparent;
            this.layoutManagerformGRUPEKOEF.Controls.Add(this.label1NAZIVGRUPEKOEF, 0, 1);
            this.layoutManagerformGRUPEKOEF.SetColumnSpan(this.label1NAZIVGRUPEKOEF, 1);
            this.layoutManagerformGRUPEKOEF.SetRowSpan(this.label1NAZIVGRUPEKOEF, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVGRUPEKOEF.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVGRUPEKOEF.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1NAZIVGRUPEKOEF.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVGRUPEKOEF.Location = point;
            this.textNAZIVGRUPEKOEF.Name = "textNAZIVGRUPEKOEF";
            this.textNAZIVGRUPEKOEF.Tag = "NAZIVGRUPEKOEF";
            this.textNAZIVGRUPEKOEF.TabIndex = 0;
            this.textNAZIVGRUPEKOEF.Anchor = AnchorStyles.Left;
            this.textNAZIVGRUPEKOEF.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVGRUPEKOEF.ReadOnly = false;
            this.textNAZIVGRUPEKOEF.DataBindings.Add(new Binding("Text", this.bindingSourceGRUPEKOEF, "NAZIVGRUPEKOEF"));
            this.textNAZIVGRUPEKOEF.MaxLength = 50;
            this.layoutManagerformGRUPEKOEF.Controls.Add(this.textNAZIVGRUPEKOEF, 1, 1);
            this.layoutManagerformGRUPEKOEF.SetColumnSpan(this.textNAZIVGRUPEKOEF, 1);
            this.layoutManagerformGRUPEKOEF.SetRowSpan(this.textNAZIVGRUPEKOEF, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVGRUPEKOEF.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVGRUPEKOEF.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVGRUPEKOEF.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelGRUPEKOEFLevel1.Location = point;
            this.grdLevelGRUPEKOEFLevel1.Name = "grdLevelGRUPEKOEFLevel1";
            this.layoutManagerformGRUPEKOEF.Controls.Add(this.grdLevelGRUPEKOEFLevel1, 0, 2);
            this.layoutManagerformGRUPEKOEF.SetColumnSpan(this.grdLevelGRUPEKOEFLevel1, 2);
            this.layoutManagerformGRUPEKOEF.SetRowSpan(this.grdLevelGRUPEKOEFLevel1, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelGRUPEKOEFLevel1.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelGRUPEKOEFLevel1.MinimumSize = size;
            size = new System.Drawing.Size(0x228, 200);
            this.grdLevelGRUPEKOEFLevel1.Size = size;
            this.grdLevelGRUPEKOEFLevel1.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsGRUPEKOEFLevel1.Location = point;
            this.panelactionsGRUPEKOEFLevel1.Name = "panelactionsGRUPEKOEFLevel1";
            this.panelactionsGRUPEKOEFLevel1.BackColor = Color.Transparent;
            this.panelactionsGRUPEKOEFLevel1.Controls.Add(this.layoutManagerpanelactionsGRUPEKOEFLevel1);
            this.layoutManagerformGRUPEKOEF.Controls.Add(this.panelactionsGRUPEKOEFLevel1, 0, 3);
            this.layoutManagerformGRUPEKOEF.SetColumnSpan(this.panelactionsGRUPEKOEFLevel1, 2);
            this.layoutManagerformGRUPEKOEF.SetRowSpan(this.panelactionsGRUPEKOEFLevel1, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsGRUPEKOEFLevel1.Margin = padding;
            size = new System.Drawing.Size(0x1b9, 0x19);
            this.panelactionsGRUPEKOEFLevel1.MinimumSize = size;
            size = new System.Drawing.Size(0x1b9, 0x19);
            this.panelactionsGRUPEKOEFLevel1.Size = size;
            this.panelactionsGRUPEKOEFLevel1.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelGRUPEKOEFLevel1Add.Location = point;
            this.linkLabelGRUPEKOEFLevel1Add.Name = "linkLabelGRUPEKOEFLevel1Add";
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelGRUPEKOEFLevel1Add.Size = size;
            this.linkLabelGRUPEKOEFLevel1Add.Text = " Add Elementi u grupi  ";
            this.linkLabelGRUPEKOEFLevel1Add.Click += new EventHandler(this.GRUPEKOEFLevel1Add_Click);
            this.linkLabelGRUPEKOEFLevel1Add.BackColor = Color.Transparent;
            this.linkLabelGRUPEKOEFLevel1Add.Appearance.ForeColor = Color.Blue;
            this.linkLabelGRUPEKOEFLevel1Add.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelGRUPEKOEFLevel1Add.Cursor = Cursors.Hand;
            this.linkLabelGRUPEKOEFLevel1Add.AutoSize = true;
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.Controls.Add(this.linkLabelGRUPEKOEFLevel1Add, 0, 0);
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.SetColumnSpan(this.linkLabelGRUPEKOEFLevel1Add, 1);
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.SetRowSpan(this.linkLabelGRUPEKOEFLevel1Add, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelGRUPEKOEFLevel1Add.Margin = padding;
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelGRUPEKOEFLevel1Add.MinimumSize = size;
            size = new System.Drawing.Size(0x7b, 15);
            this.linkLabelGRUPEKOEFLevel1Add.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelGRUPEKOEFLevel1Update.Location = point;
            this.linkLabelGRUPEKOEFLevel1Update.Name = "linkLabelGRUPEKOEFLevel1Update";
            size = new System.Drawing.Size(0x8d, 15);
            this.linkLabelGRUPEKOEFLevel1Update.Size = size;
            this.linkLabelGRUPEKOEFLevel1Update.Text = " Update Elementi u grupi  ";
            this.linkLabelGRUPEKOEFLevel1Update.Click += new EventHandler(this.GRUPEKOEFLevel1Update_Click);
            this.linkLabelGRUPEKOEFLevel1Update.BackColor = Color.Transparent;
            this.linkLabelGRUPEKOEFLevel1Update.Appearance.ForeColor = Color.Blue;
            this.linkLabelGRUPEKOEFLevel1Update.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelGRUPEKOEFLevel1Update.Cursor = Cursors.Hand;
            this.linkLabelGRUPEKOEFLevel1Update.AutoSize = true;
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.Controls.Add(this.linkLabelGRUPEKOEFLevel1Update, 1, 0);
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.SetColumnSpan(this.linkLabelGRUPEKOEFLevel1Update, 1);
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.SetRowSpan(this.linkLabelGRUPEKOEFLevel1Update, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelGRUPEKOEFLevel1Update.Margin = padding;
            size = new System.Drawing.Size(0x8d, 15);
            this.linkLabelGRUPEKOEFLevel1Update.MinimumSize = size;
            size = new System.Drawing.Size(0x8d, 15);
            this.linkLabelGRUPEKOEFLevel1Update.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelGRUPEKOEFLevel1Delete.Location = point;
            this.linkLabelGRUPEKOEFLevel1Delete.Name = "linkLabelGRUPEKOEFLevel1Delete";
            size = new System.Drawing.Size(0x89, 15);
            this.linkLabelGRUPEKOEFLevel1Delete.Size = size;
            this.linkLabelGRUPEKOEFLevel1Delete.Text = " Delete Elementi u grupi  ";
            this.linkLabelGRUPEKOEFLevel1Delete.Click += new EventHandler(this.GRUPEKOEFLevel1Delete_Click);
            this.linkLabelGRUPEKOEFLevel1Delete.BackColor = Color.Transparent;
            this.linkLabelGRUPEKOEFLevel1Delete.Appearance.ForeColor = Color.Blue;
            this.linkLabelGRUPEKOEFLevel1Delete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelGRUPEKOEFLevel1Delete.Cursor = Cursors.Hand;
            this.linkLabelGRUPEKOEFLevel1Delete.AutoSize = true;
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.Controls.Add(this.linkLabelGRUPEKOEFLevel1Delete, 2, 0);
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.SetColumnSpan(this.linkLabelGRUPEKOEFLevel1Delete, 1);
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.SetRowSpan(this.linkLabelGRUPEKOEFLevel1Delete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelGRUPEKOEFLevel1Delete.Margin = padding;
            size = new System.Drawing.Size(0x89, 15);
            this.linkLabelGRUPEKOEFLevel1Delete.MinimumSize = size;
            size = new System.Drawing.Size(0x89, 15);
            this.linkLabelGRUPEKOEFLevel1Delete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelGRUPEKOEFLevel1.Location = point;
            this.linkLabelGRUPEKOEFLevel1.Name = "linkLabelGRUPEKOEFLevel1";
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.Controls.Add(this.linkLabelGRUPEKOEFLevel1, 3, 0);
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.SetColumnSpan(this.linkLabelGRUPEKOEFLevel1, 1);
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.SetRowSpan(this.linkLabelGRUPEKOEFLevel1, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelGRUPEKOEFLevel1.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelGRUPEKOEFLevel1.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelGRUPEKOEFLevel1.Size = size;
            this.linkLabelGRUPEKOEFLevel1.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformGRUPEKOEF);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceGRUPEKOEF;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.Disabled;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.GRUPEKOEFIDGRUPEKOEFDescription;
            column3.Width = 0x33;
            appearance2.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance2;
            column3.Hidden = true;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.GRUPEKOEFIDELEMENTDescription;
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.Disabled;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.GRUPEKOEFNAZIVELEMENTDescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.GRUPEKOEFIDMZOSTABLICEDescription;
            column4.Width = 0x63;
            appearance3.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 1;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 2;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 3;
            this.grdLevelGRUPEKOEFLevel1.Visible = true;
            this.grdLevelGRUPEKOEFLevel1.Name = "grdLevelGRUPEKOEFLevel1";
            this.grdLevelGRUPEKOEFLevel1.Tag = "GRUPEKOEFLevel1";
            this.grdLevelGRUPEKOEFLevel1.TabIndex = 10;
            this.grdLevelGRUPEKOEFLevel1.Dock = DockStyle.Fill;
            this.grdLevelGRUPEKOEFLevel1.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelGRUPEKOEFLevel1.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelGRUPEKOEFLevel1.DataSource = this.bindingSourceGRUPEKOEFLevel1;
            this.grdLevelGRUPEKOEFLevel1.Enter += new EventHandler(this.grdLevelGRUPEKOEFLevel1_Enter);
            this.grdLevelGRUPEKOEFLevel1.AfterRowInsert += new RowEventHandler(this.grdLevelGRUPEKOEFLevel1_AfterRowInsert);
            this.grdLevelGRUPEKOEFLevel1.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelGRUPEKOEFLevel1.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelGRUPEKOEFLevel1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelGRUPEKOEFLevel1.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelGRUPEKOEFLevel1_DoubleClick);
            this.grdLevelGRUPEKOEFLevel1.AfterRowActivate += new EventHandler(this.grdLevelGRUPEKOEFLevel1_AfterRowActivate);
            this.grdLevelGRUPEKOEFLevel1.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelGRUPEKOEFLevel1.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelGRUPEKOEFLevel1.DisplayLayout.BandsSerializer.Add(band);
            this.Name = "GRUPEKOEFFormUserControl";
            this.Text = "Grupe koeficijenata";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.GRUPEKOEFFormUserControl_Load);
            this.layoutManagerformGRUPEKOEF.ResumeLayout(false);
            this.layoutManagerformGRUPEKOEF.PerformLayout();
            ((ISupportInitialize) this.bindingSourceGRUPEKOEF).EndInit();
            ((ISupportInitialize) this.bindingSourceGRUPEKOEFLevel1).EndInit();
            ((ISupportInitialize) this.textIDGRUPEKOEF).EndInit();
            ((ISupportInitialize) this.textNAZIVGRUPEKOEF).EndInit();
            ((ISupportInitialize) this.grdLevelGRUPEKOEFLevel1).EndInit();
            this.panelactionsGRUPEKOEFLevel1.ResumeLayout(true);
            this.panelactionsGRUPEKOEFLevel1.PerformLayout();
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.ResumeLayout(false);
            this.layoutManagerpanelactionsGRUPEKOEFLevel1.PerformLayout();
            this.dsGRUPEKOEFDataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.GRUPEKOEFController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceGRUPEKOEF, this.GRUPEKOEFController.WorkItem, this))
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
            this.label1IDGRUPEKOEF.Text = StringResources.GRUPEKOEFIDGRUPEKOEFDescription;
            this.label1NAZIVGRUPEKOEF.Text = StringResources.GRUPEKOEFNAZIVGRUPEKOEFDescription;
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

        private void RegisterBindingSources()
        {
            if (!this.GRUPEKOEFController.WorkItem.Items.Contains("GRUPEKOEF|GRUPEKOEF"))
            {
                this.GRUPEKOEFController.WorkItem.Items.Add(this.bindingSourceGRUPEKOEF, "GRUPEKOEF|GRUPEKOEF");
            }
            if (!this.GRUPEKOEFController.WorkItem.Items.Contains("GRUPEKOEF|GRUPEKOEFLevel1"))
            {
                this.GRUPEKOEFController.WorkItem.Items.Add(this.bindingSourceGRUPEKOEFLevel1, "GRUPEKOEF|GRUPEKOEFLevel1");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsGRUPEKOEFDataSet1.GRUPEKOEF.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.GRUPEKOEFController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.GRUPEKOEFController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.GRUPEKOEFController.Update(this))
            {
                this.GRUPEKOEFController.DataSet = new GRUPEKOEFDataSet();
                DataSetUtil.AddEmptyRow(this.GRUPEKOEFController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.GRUPEKOEFController.DataSet.GRUPEKOEF[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetComboBoxColumnProperties()
        {
            PROVIDER_BRUTOComboBox box = new PROVIDER_BRUTOComboBox();
            box.Fill();
            DataView defaultView = box.DataSet.Tables["ELEMENT"].DefaultView;
            CreateValueList(this.grdLevelGRUPEKOEFLevel1, "ELEMENTIDELEMENT", defaultView, "IDELEMENT", "EL", false);
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelGRUPEKOEFLevel1, "IDELEMENT");
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            gridColumn.ValueList = this.grdLevelGRUPEKOEFLevel1.DisplayLayout.ValueLists["ELEMENTIDELEMENT"];
            gridColumn.Width = 370;
            UltraGridColumn column2 = FormHelperClass.GetGridColumn(this.grdLevelGRUPEKOEFLevel1, "IDMZOSTABLICE");
            column2.Tag = "MZOSTABLICEIDMZOSTABLICE";
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            this.grdLevelGRUPEKOEFLevel1.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelGRUPEKOEFLevel1.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.textIDGRUPEKOEF.Focus();
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

        protected virtual UltraGrid grdLevelGRUPEKOEFLevel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelGRUPEKOEFLevel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelGRUPEKOEFLevel1 = value;
            }
        }

        [CreateNew, Browsable(false)]
        public NetAdvantage.Controllers.GRUPEKOEFController GRUPEKOEFController { get; set; }

        protected virtual UltraLabel label1IDGRUPEKOEF
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDGRUPEKOEF;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDGRUPEKOEF = value;
            }
        }

        protected virtual UltraLabel label1NAZIVGRUPEKOEF
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVGRUPEKOEF;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVGRUPEKOEF = value;
            }
        }

        protected virtual UltraLabel linkLabelGRUPEKOEFLevel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelGRUPEKOEFLevel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelGRUPEKOEFLevel1 = value;
            }
        }

        protected virtual UltraLabel linkLabelGRUPEKOEFLevel1Add
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelGRUPEKOEFLevel1Add;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelGRUPEKOEFLevel1Add = value;
            }
        }

        protected virtual UltraLabel linkLabelGRUPEKOEFLevel1Delete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelGRUPEKOEFLevel1Delete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelGRUPEKOEFLevel1Delete = value;
            }
        }

        protected virtual UltraLabel linkLabelGRUPEKOEFLevel1Update
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelGRUPEKOEFLevel1Update;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelGRUPEKOEFLevel1Update = value;
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

        protected virtual Panel panelactionsGRUPEKOEFLevel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsGRUPEKOEFLevel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsGRUPEKOEFLevel1 = value;
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

        protected virtual UltraNumericEditor textIDGRUPEKOEF
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDGRUPEKOEF;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDGRUPEKOEF = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVGRUPEKOEF
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVGRUPEKOEF;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVGRUPEKOEF = value;
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

