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
    public class SKUPPOREZAIDOPRINOSAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelSKUPPOREZAIDOPRINOSA1")]
        private UltraGrid _grdLevelSKUPPOREZAIDOPRINOSA1;
        [AccessedThroughProperty("grdLevelSKUPPOREZAIDOPRINOSA2")]
        private UltraGrid _grdLevelSKUPPOREZAIDOPRINOSA2;
        [AccessedThroughProperty("label1IDSKUPPOREZAIDOPRINOSA")]
        private UltraLabel _label1IDSKUPPOREZAIDOPRINOSA;
        [AccessedThroughProperty("label1NAZIVSKUPPOREZAIDOPRINOSA")]
        private UltraLabel _label1NAZIVSKUPPOREZAIDOPRINOSA;
        [AccessedThroughProperty("linkLabelSKUPPOREZAIDOPRINOSA1")]
        private UltraLabel _linkLabelSKUPPOREZAIDOPRINOSA1;
        [AccessedThroughProperty("linkLabelSKUPPOREZAIDOPRINOSA1Add")]
        private UltraLabel _linkLabelSKUPPOREZAIDOPRINOSA1Add;
        [AccessedThroughProperty("linkLabelSKUPPOREZAIDOPRINOSA1Delete")]
        private UltraLabel _linkLabelSKUPPOREZAIDOPRINOSA1Delete;
        [AccessedThroughProperty("linkLabelSKUPPOREZAIDOPRINOSA1Update")]
        private UltraLabel _linkLabelSKUPPOREZAIDOPRINOSA1Update;
        [AccessedThroughProperty("linkLabelSKUPPOREZAIDOPRINOSA2")]
        private UltraLabel _linkLabelSKUPPOREZAIDOPRINOSA2;
        [AccessedThroughProperty("linkLabelSKUPPOREZAIDOPRINOSA2Add")]
        private UltraLabel _linkLabelSKUPPOREZAIDOPRINOSA2Add;
        [AccessedThroughProperty("linkLabelSKUPPOREZAIDOPRINOSA2Delete")]
        private UltraLabel _linkLabelSKUPPOREZAIDOPRINOSA2Delete;
        [AccessedThroughProperty("linkLabelSKUPPOREZAIDOPRINOSA2Update")]
        private UltraLabel _linkLabelSKUPPOREZAIDOPRINOSA2Update;
        [AccessedThroughProperty("panelactionsSKUPPOREZAIDOPRINOSA1")]
        private Panel _panelactionsSKUPPOREZAIDOPRINOSA1;
        [AccessedThroughProperty("panelactionsSKUPPOREZAIDOPRINOSA2")]
        private Panel _panelactionsSKUPPOREZAIDOPRINOSA2;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDSKUPPOREZAIDOPRINOSA")]
        private UltraNumericEditor _textIDSKUPPOREZAIDOPRINOSA;
        [AccessedThroughProperty("textNAZIVSKUPPOREZAIDOPRINOSA")]
        private UltraTextEditor _textNAZIVSKUPPOREZAIDOPRINOSA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSKUPPOREZAIDOPRINOSA;
        private BindingSource bindingSourceSKUPPOREZAIDOPRINOSA1;
        private BindingSource bindingSourceSKUPPOREZAIDOPRINOSA2;
        private IContainer components = null;
        private SKUPPOREZAIDOPRINOSADataSet dsSKUPPOREZAIDOPRINOSADataSet1;
        protected TableLayoutPanel layoutManagerformSKUPPOREZAIDOPRINOSA;
        protected TableLayoutPanel layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1;
        protected TableLayoutPanel layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SKUPPOREZAIDOPRINOSA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.SKUPPOREZAIDOPRINOSADescription;
        private DeklaritMode m_Mode;

        public SKUPPOREZAIDOPRINOSAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptInLinesDOPRINOSIDDOPRINOS(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.SKUPPOREZAIDOPRINOSAController.SelectDOPRINOSIDDOPRINOS("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["IDDOPRINOS"]);
                    row3["NAZIVDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["NAZIVDOPRINOS"]);
                    row3["MODOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["MODOPRINOS"]);
                    row3["PODOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["PODOPRINOS"]);
                    row3["MZDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["MZDOPRINOS"]);
                    row3["PZDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["PZDOPRINOS"]);
                    row3["PRIMATELJDOPRINOS1"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJDOPRINOS1"]);
                    row3["PRIMATELJDOPRINOS2"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJDOPRINOS2"]);
                    row3["SIFRAOPISAPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["SIFRAOPISAPLACANJADOPRINOS"]);
                    row3["OPISPLACANJADOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["OPISPLACANJADOPRINOS"]);
                    row3["VBDIDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["VBDIDOPRINOS"]);
                    row3["ZRNDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["ZRNDOPRINOS"]);
                    row3["MINDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["MINDOPRINOS"]);
                    row3["MAXDOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["MAXDOPRINOS"]);
                    row3["STOPA"] = RuntimeHelpers.GetObjectValue(row2["STOPA"]);
                    row3["IDVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["IDVRSTADOPRINOS"]);
                    row3["NAZIVVRSTADOPRINOS"] = RuntimeHelpers.GetObjectValue(row2["NAZIVVRSTADOPRINOS"]);
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

        private void CallPromptInLinesPOREZIDPOREZ(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.SKUPPOREZAIDOPRINOSAController.SelectPOREZIDPOREZ("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDPOREZ"] = RuntimeHelpers.GetObjectValue(row2["IDPOREZ"]);
                    row3["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(row2["NAZIVPOREZ"]);
                    row3["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(row2["POREZMJESECNO"]);
                    row3["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(row2["STOPAPOREZA"]);
                    row3["MOPOREZ"] = RuntimeHelpers.GetObjectValue(row2["MOPOREZ"]);
                    row3["POPOREZ"] = RuntimeHelpers.GetObjectValue(row2["POPOREZ"]);
                    row3["MZPOREZ"] = RuntimeHelpers.GetObjectValue(row2["MZPOREZ"]);
                    row3["PZPOREZ"] = RuntimeHelpers.GetObjectValue(row2["PZPOREZ"]);
                    row3["PRIMATELJPOREZ1"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJPOREZ1"]);
                    row3["PRIMATELJPOREZ2"] = RuntimeHelpers.GetObjectValue(row2["PRIMATELJPOREZ2"]);
                    row3["SIFRAOPISAPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(row2["SIFRAOPISAPLACANJAPOREZ"]);
                    row3["OPISPLACANJAPOREZ"] = RuntimeHelpers.GetObjectValue(row2["OPISPLACANJAPOREZ"]);
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
            this.m_BaseMethods.CellChangedBase(this.dsSKUPPOREZAIDOPRINOSADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceSKUPPOREZAIDOPRINOSA.DataSource = this.SKUPPOREZAIDOPRINOSAController.DataSet;
            this.dsSKUPPOREZAIDOPRINOSADataSet1 = this.SKUPPOREZAIDOPRINOSAController.DataSet;
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
                    enumerator = this.dsSKUPPOREZAIDOPRINOSADataSet1.SKUPPOREZAIDOPRINOSA.Rows.GetEnumerator();
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
                if (this.SKUPPOREZAIDOPRINOSAController.Update(this))
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
                    case "POREZIDPOREZ":
                        this.CallPromptInLinesPOREZIDPOREZ(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "DOPRINOSIDDOPRINOS":
                        this.CallPromptInLinesDOPRINOSIDDOPRINOS(RuntimeHelpers.GetObjectValue(sender), e);
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
            if (this.grdLevelSKUPPOREZAIDOPRINOSA1.ActiveRow != null)
            {
                this.grdLevelSKUPPOREZAIDOPRINOSA1.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelSKUPPOREZAIDOPRINOSA2.ActiveRow != null)
            {
                this.grdLevelSKUPPOREZAIDOPRINOSA2.PerformAction(UltraGridAction.NextRow);
            }
        }

        private void grdLevelSKUPPOREZAIDOPRINOSA1_AfterRowActivate(object sender, EventArgs e)
        {
            string str = StringResources.SKUPPOREZAIDOPRINOSASKUPPOREZAIDOPRINOSA1LevelDescription;
            UltraGridRow activeRow = this.grdLevelSKUPPOREZAIDOPRINOSA1.ActiveRow;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add.Text = Deklarit.Resources.Resources.Add + " " + str;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update.Text = Deklarit.Resources.Resources.Update + " " + str;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete.Text = Deklarit.Resources.Resources.Delete + " " + str;
        }

        private void grdLevelSKUPPOREZAIDOPRINOSA1_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceSKUPPOREZAIDOPRINOSA.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelSKUPPOREZAIDOPRINOSA1_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.SKUPPOREZAIDOPRINOSA1Update_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelSKUPPOREZAIDOPRINOSA1_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceSKUPPOREZAIDOPRINOSA, this.SKUPPOREZAIDOPRINOSAController.WorkItem, this);
        }

        private void grdLevelSKUPPOREZAIDOPRINOSA2_AfterRowActivate(object sender, EventArgs e)
        {
            string str = StringResources.SKUPPOREZAIDOPRINOSASKUPPOREZAIDOPRINOSA2LevelDescription;
            UltraGridRow activeRow = this.grdLevelSKUPPOREZAIDOPRINOSA2.ActiveRow;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add.Text = Deklarit.Resources.Resources.Add + " " + str;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update.Text = Deklarit.Resources.Resources.Update + " " + str;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete.Text = Deklarit.Resources.Resources.Delete + " " + str;
        }

        private void grdLevelSKUPPOREZAIDOPRINOSA2_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceSKUPPOREZAIDOPRINOSA.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelSKUPPOREZAIDOPRINOSA2_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.SKUPPOREZAIDOPRINOSA2Update_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelSKUPPOREZAIDOPRINOSA2_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceSKUPPOREZAIDOPRINOSA, this.SKUPPOREZAIDOPRINOSAController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SKUPPOREZAIDOPRINOSA", this.m_Mode, this.dsSKUPPOREZAIDOPRINOSADataSet1, this.dsSKUPPOREZAIDOPRINOSADataSet1.SKUPPOREZAIDOPRINOSA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            if (!this.m_DataGrids.Contains(this.grdLevelSKUPPOREZAIDOPRINOSA1))
            {
                this.m_DataGrids.Add(this.grdLevelSKUPPOREZAIDOPRINOSA1);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelSKUPPOREZAIDOPRINOSA2))
            {
                this.m_DataGrids.Add(this.grdLevelSKUPPOREZAIDOPRINOSA2);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsSKUPPOREZAIDOPRINOSADataSet1.SKUPPOREZAIDOPRINOSA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (SKUPPOREZAIDOPRINOSADataSet.SKUPPOREZAIDOPRINOSARow) ((DataRowView) this.bindingSourceSKUPPOREZAIDOPRINOSA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(SKUPPOREZAIDOPRINOSAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSKUPPOREZAIDOPRINOSA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSKUPPOREZAIDOPRINOSA).BeginInit();
            this.bindingSourceSKUPPOREZAIDOPRINOSA1 = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSKUPPOREZAIDOPRINOSA1).BeginInit();
            this.bindingSourceSKUPPOREZAIDOPRINOSA2 = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSKUPPOREZAIDOPRINOSA2).BeginInit();
            this.layoutManagerformSKUPPOREZAIDOPRINOSA = new TableLayoutPanel();
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SuspendLayout();
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.AutoSize = true;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.Dock = DockStyle.Fill;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.Size = size;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.ColumnCount = 2;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.RowCount = 6;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.RowStyles.Add(new RowStyle());
            this.label1IDSKUPPOREZAIDOPRINOSA = new UltraLabel();
            this.textIDSKUPPOREZAIDOPRINOSA = new UltraNumericEditor();
            this.label1NAZIVSKUPPOREZAIDOPRINOSA = new UltraLabel();
            this.textNAZIVSKUPPOREZAIDOPRINOSA = new UltraTextEditor();
            this.grdLevelSKUPPOREZAIDOPRINOSA1 = new UltraGrid();
            this.panelactionsSKUPPOREZAIDOPRINOSA1 = new Panel();
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1 = new TableLayoutPanel();
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.AutoSize = true;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.ColumnCount = 4;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.RowCount = 1;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.RowStyles.Add(new RowStyle());
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add = new UltraLabel();
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update = new UltraLabel();
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete = new UltraLabel();
            this.linkLabelSKUPPOREZAIDOPRINOSA1 = new UltraLabel();
            this.grdLevelSKUPPOREZAIDOPRINOSA2 = new UltraGrid();
            this.panelactionsSKUPPOREZAIDOPRINOSA2 = new Panel();
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2 = new TableLayoutPanel();
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.AutoSize = true;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.ColumnCount = 4;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.RowCount = 1;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.RowStyles.Add(new RowStyle());
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add = new UltraLabel();
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update = new UltraLabel();
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete = new UltraLabel();
            this.linkLabelSKUPPOREZAIDOPRINOSA2 = new UltraLabel();
            ((ISupportInitialize) this.textIDSKUPPOREZAIDOPRINOSA).BeginInit();
            ((ISupportInitialize) this.textNAZIVSKUPPOREZAIDOPRINOSA).BeginInit();
            ((ISupportInitialize) this.grdLevelSKUPPOREZAIDOPRINOSA1).BeginInit();
            this.panelactionsSKUPPOREZAIDOPRINOSA1.SuspendLayout();
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.SuspendLayout();
            ((ISupportInitialize) this.grdLevelSKUPPOREZAIDOPRINOSA2).BeginInit();
            this.panelactionsSKUPPOREZAIDOPRINOSA2.SuspendLayout();
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.SuspendLayout();
            UltraGridBand band = new UltraGridBand("SKUPPOREZAIDOPRINOSA1", -1);
            UltraGridColumn column2 = new UltraGridColumn("IDSKUPPOREZAIDOPRINOSA");
            UltraGridColumn column = new UltraGridColumn("IDPOREZ");
            UltraGridColumn column5 = new UltraGridColumn("NAZIVPOREZ");
            UltraGridColumn column8 = new UltraGridColumn("POREZMJESECNO");
            UltraGridColumn column13 = new UltraGridColumn("STOPAPOREZA");
            UltraGridColumn column3 = new UltraGridColumn("MOPOREZ");
            UltraGridColumn column7 = new UltraGridColumn("POPOREZ");
            UltraGridColumn column4 = new UltraGridColumn("MZPOREZ");
            UltraGridColumn column11 = new UltraGridColumn("PZPOREZ");
            UltraGridColumn column9 = new UltraGridColumn("PRIMATELJPOREZ1");
            UltraGridColumn column10 = new UltraGridColumn("PRIMATELJPOREZ2");
            UltraGridColumn column12 = new UltraGridColumn("SIFRAOPISAPLACANJAPOREZ");
            UltraGridColumn column6 = new UltraGridColumn("OPISPLACANJAPOREZ");
            UltraGridBand band2 = new UltraGridBand("SKUPPOREZAIDOPRINOSA2", -1);
            UltraGridColumn column15 = new UltraGridColumn("IDSKUPPOREZAIDOPRINOSA");
            UltraGridColumn column14 = new UltraGridColumn("IDDOPRINOS");
            UltraGridColumn column21 = new UltraGridColumn("NAZIVDOPRINOS");
            UltraGridColumn column16 = new UltraGridColumn("IDVRSTADOPRINOS");
            UltraGridColumn column22 = new UltraGridColumn("NAZIVVRSTADOPRINOS");
            UltraGridColumn column19 = new UltraGridColumn("MODOPRINOS");
            UltraGridColumn column24 = new UltraGridColumn("PODOPRINOS");
            UltraGridColumn column20 = new UltraGridColumn("MZDOPRINOS");
            UltraGridColumn column27 = new UltraGridColumn("PZDOPRINOS");
            UltraGridColumn column25 = new UltraGridColumn("PRIMATELJDOPRINOS1");
            UltraGridColumn column26 = new UltraGridColumn("PRIMATELJDOPRINOS2");
            UltraGridColumn column28 = new UltraGridColumn("SIFRAOPISAPLACANJADOPRINOS");
            UltraGridColumn column23 = new UltraGridColumn("OPISPLACANJADOPRINOS");
            UltraGridColumn column30 = new UltraGridColumn("VBDIDOPRINOS");
            UltraGridColumn column31 = new UltraGridColumn("ZRNDOPRINOS");
            UltraGridColumn column18 = new UltraGridColumn("MINDOPRINOS");
            UltraGridColumn column17 = new UltraGridColumn("MAXDOPRINOS");
            UltraGridColumn column29 = new UltraGridColumn("STOPA");
            this.dsSKUPPOREZAIDOPRINOSADataSet1 = new SKUPPOREZAIDOPRINOSADataSet();
            this.dsSKUPPOREZAIDOPRINOSADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsSKUPPOREZAIDOPRINOSADataSet1.DataSetName = "dsSKUPPOREZAIDOPRINOSA";
            this.dsSKUPPOREZAIDOPRINOSADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSKUPPOREZAIDOPRINOSA.DataSource = this.dsSKUPPOREZAIDOPRINOSADataSet1;
            this.bindingSourceSKUPPOREZAIDOPRINOSA.DataMember = "SKUPPOREZAIDOPRINOSA";
            ((ISupportInitialize) this.bindingSourceSKUPPOREZAIDOPRINOSA).BeginInit();
            this.bindingSourceSKUPPOREZAIDOPRINOSA1.DataSource = this.bindingSourceSKUPPOREZAIDOPRINOSA;
            this.bindingSourceSKUPPOREZAIDOPRINOSA1.DataMember = "SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA1";
            this.bindingSourceSKUPPOREZAIDOPRINOSA2.DataSource = this.bindingSourceSKUPPOREZAIDOPRINOSA;
            this.bindingSourceSKUPPOREZAIDOPRINOSA2.DataMember = "SKUPPOREZAIDOPRINOSA_SKUPPOREZAIDOPRINOSA2";
            point = new System.Drawing.Point(0, 0);
            this.label1IDSKUPPOREZAIDOPRINOSA.Location = point;
            this.label1IDSKUPPOREZAIDOPRINOSA.Name = "label1IDSKUPPOREZAIDOPRINOSA";
            this.label1IDSKUPPOREZAIDOPRINOSA.TabIndex = 1;
            this.label1IDSKUPPOREZAIDOPRINOSA.Tag = "labelIDSKUPPOREZAIDOPRINOSA";
            this.label1IDSKUPPOREZAIDOPRINOSA.Text = "Šifra skupine poreza i doprinosa:";
            this.label1IDSKUPPOREZAIDOPRINOSA.StyleSetName = "FieldUltraLabel";
            this.label1IDSKUPPOREZAIDOPRINOSA.AutoSize = true;
            this.label1IDSKUPPOREZAIDOPRINOSA.Anchor = AnchorStyles.Left;
            this.label1IDSKUPPOREZAIDOPRINOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDSKUPPOREZAIDOPRINOSA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDSKUPPOREZAIDOPRINOSA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDSKUPPOREZAIDOPRINOSA.ImageSize = size;
            this.label1IDSKUPPOREZAIDOPRINOSA.Appearance.ForeColor = Color.Black;
            this.label1IDSKUPPOREZAIDOPRINOSA.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.Controls.Add(this.label1IDSKUPPOREZAIDOPRINOSA, 0, 0);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetColumnSpan(this.label1IDSKUPPOREZAIDOPRINOSA, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetRowSpan(this.label1IDSKUPPOREZAIDOPRINOSA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDSKUPPOREZAIDOPRINOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDSKUPPOREZAIDOPRINOSA.MinimumSize = size;
            size = new System.Drawing.Size(0xd7, 0x17);
            this.label1IDSKUPPOREZAIDOPRINOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDSKUPPOREZAIDOPRINOSA.Location = point;
            this.textIDSKUPPOREZAIDOPRINOSA.Name = "textIDSKUPPOREZAIDOPRINOSA";
            this.textIDSKUPPOREZAIDOPRINOSA.Tag = "IDSKUPPOREZAIDOPRINOSA";
            this.textIDSKUPPOREZAIDOPRINOSA.TabIndex = 0;
            this.textIDSKUPPOREZAIDOPRINOSA.Anchor = AnchorStyles.Left;
            this.textIDSKUPPOREZAIDOPRINOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDSKUPPOREZAIDOPRINOSA.ReadOnly = false;
            this.textIDSKUPPOREZAIDOPRINOSA.PromptChar = ' ';
            this.textIDSKUPPOREZAIDOPRINOSA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDSKUPPOREZAIDOPRINOSA.DataBindings.Add(new Binding("Value", this.bindingSourceSKUPPOREZAIDOPRINOSA, "IDSKUPPOREZAIDOPRINOSA"));
            this.textIDSKUPPOREZAIDOPRINOSA.NumericType = NumericType.Integer;
            this.textIDSKUPPOREZAIDOPRINOSA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.Controls.Add(this.textIDSKUPPOREZAIDOPRINOSA, 1, 0);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetColumnSpan(this.textIDSKUPPOREZAIDOPRINOSA, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetRowSpan(this.textIDSKUPPOREZAIDOPRINOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDSKUPPOREZAIDOPRINOSA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSKUPPOREZAIDOPRINOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSKUPPOREZAIDOPRINOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVSKUPPOREZAIDOPRINOSA.Location = point;
            this.label1NAZIVSKUPPOREZAIDOPRINOSA.Name = "label1NAZIVSKUPPOREZAIDOPRINOSA";
            this.label1NAZIVSKUPPOREZAIDOPRINOSA.TabIndex = 1;
            this.label1NAZIVSKUPPOREZAIDOPRINOSA.Tag = "labelNAZIVSKUPPOREZAIDOPRINOSA";
            this.label1NAZIVSKUPPOREZAIDOPRINOSA.Text = "Naziv skupine poreza i doprinosa:";
            this.label1NAZIVSKUPPOREZAIDOPRINOSA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVSKUPPOREZAIDOPRINOSA.AutoSize = true;
            this.label1NAZIVSKUPPOREZAIDOPRINOSA.Anchor = AnchorStyles.Left;
            this.label1NAZIVSKUPPOREZAIDOPRINOSA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVSKUPPOREZAIDOPRINOSA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVSKUPPOREZAIDOPRINOSA.BackColor = Color.Transparent;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.Controls.Add(this.label1NAZIVSKUPPOREZAIDOPRINOSA, 0, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetColumnSpan(this.label1NAZIVSKUPPOREZAIDOPRINOSA, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetRowSpan(this.label1NAZIVSKUPPOREZAIDOPRINOSA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVSKUPPOREZAIDOPRINOSA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVSKUPPOREZAIDOPRINOSA.MinimumSize = size;
            size = new System.Drawing.Size(0xe0, 0x17);
            this.label1NAZIVSKUPPOREZAIDOPRINOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVSKUPPOREZAIDOPRINOSA.Location = point;
            this.textNAZIVSKUPPOREZAIDOPRINOSA.Name = "textNAZIVSKUPPOREZAIDOPRINOSA";
            this.textNAZIVSKUPPOREZAIDOPRINOSA.Tag = "NAZIVSKUPPOREZAIDOPRINOSA";
            this.textNAZIVSKUPPOREZAIDOPRINOSA.TabIndex = 0;
            this.textNAZIVSKUPPOREZAIDOPRINOSA.Anchor = AnchorStyles.Left;
            this.textNAZIVSKUPPOREZAIDOPRINOSA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVSKUPPOREZAIDOPRINOSA.ReadOnly = false;
            this.textNAZIVSKUPPOREZAIDOPRINOSA.DataBindings.Add(new Binding("Text", this.bindingSourceSKUPPOREZAIDOPRINOSA, "NAZIVSKUPPOREZAIDOPRINOSA"));
            this.textNAZIVSKUPPOREZAIDOPRINOSA.MaxLength = 50;
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.Controls.Add(this.textNAZIVSKUPPOREZAIDOPRINOSA, 1, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetColumnSpan(this.textNAZIVSKUPPOREZAIDOPRINOSA, 1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetRowSpan(this.textNAZIVSKUPPOREZAIDOPRINOSA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVSKUPPOREZAIDOPRINOSA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVSKUPPOREZAIDOPRINOSA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVSKUPPOREZAIDOPRINOSA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelSKUPPOREZAIDOPRINOSA1.Location = point;
            this.grdLevelSKUPPOREZAIDOPRINOSA1.Name = "grdLevelSKUPPOREZAIDOPRINOSA1";
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.Controls.Add(this.grdLevelSKUPPOREZAIDOPRINOSA1, 0, 2);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetColumnSpan(this.grdLevelSKUPPOREZAIDOPRINOSA1, 2);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetRowSpan(this.grdLevelSKUPPOREZAIDOPRINOSA1, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelSKUPPOREZAIDOPRINOSA1.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelSKUPPOREZAIDOPRINOSA1.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelSKUPPOREZAIDOPRINOSA1.Size = size;
            this.grdLevelSKUPPOREZAIDOPRINOSA1.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsSKUPPOREZAIDOPRINOSA1.Location = point;
            this.panelactionsSKUPPOREZAIDOPRINOSA1.Name = "panelactionsSKUPPOREZAIDOPRINOSA1";
            this.panelactionsSKUPPOREZAIDOPRINOSA1.BackColor = Color.Transparent;
            this.panelactionsSKUPPOREZAIDOPRINOSA1.Controls.Add(this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.Controls.Add(this.panelactionsSKUPPOREZAIDOPRINOSA1, 0, 3);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetColumnSpan(this.panelactionsSKUPPOREZAIDOPRINOSA1, 2);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetRowSpan(this.panelactionsSKUPPOREZAIDOPRINOSA1, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsSKUPPOREZAIDOPRINOSA1.Margin = padding;
            size = new System.Drawing.Size(270, 0x19);
            this.panelactionsSKUPPOREZAIDOPRINOSA1.MinimumSize = size;
            size = new System.Drawing.Size(270, 0x19);
            this.panelactionsSKUPPOREZAIDOPRINOSA1.Size = size;
            this.panelactionsSKUPPOREZAIDOPRINOSA1.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add.Location = point;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add.Name = "linkLabelSKUPPOREZAIDOPRINOSA1Add";
            size = new System.Drawing.Size(0x42, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add.Size = size;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add.Text = " Add Porezi  ";
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add.Click += new EventHandler(this.SKUPPOREZAIDOPRINOSA1Add_Click);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add.BackColor = Color.Transparent;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add.Appearance.ForeColor = Color.Blue;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add.Cursor = Cursors.Hand;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add.AutoSize = true;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.Controls.Add(this.linkLabelSKUPPOREZAIDOPRINOSA1Add, 0, 0);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.linkLabelSKUPPOREZAIDOPRINOSA1Add, 1);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.linkLabelSKUPPOREZAIDOPRINOSA1Add, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add.Margin = padding;
            size = new System.Drawing.Size(0x42, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add.MinimumSize = size;
            size = new System.Drawing.Size(0x42, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update.Location = point;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update.Name = "linkLabelSKUPPOREZAIDOPRINOSA1Update";
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update.Size = size;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update.Text = " Update Porezi  ";
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update.Click += new EventHandler(this.SKUPPOREZAIDOPRINOSA1Update_Click);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update.BackColor = Color.Transparent;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update.Appearance.ForeColor = Color.Blue;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update.Cursor = Cursors.Hand;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update.AutoSize = true;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.Controls.Add(this.linkLabelSKUPPOREZAIDOPRINOSA1Update, 1, 0);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.linkLabelSKUPPOREZAIDOPRINOSA1Update, 1);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.linkLabelSKUPPOREZAIDOPRINOSA1Update, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update.Margin = padding;
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update.MinimumSize = size;
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete.Location = point;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete.Name = "linkLabelSKUPPOREZAIDOPRINOSA1Delete";
            size = new System.Drawing.Size(80, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete.Size = size;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete.Text = " Delete Porezi  ";
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete.Click += new EventHandler(this.SKUPPOREZAIDOPRINOSA1Delete_Click);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete.BackColor = Color.Transparent;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete.Appearance.ForeColor = Color.Blue;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete.Cursor = Cursors.Hand;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete.AutoSize = true;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.Controls.Add(this.linkLabelSKUPPOREZAIDOPRINOSA1Delete, 2, 0);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.linkLabelSKUPPOREZAIDOPRINOSA1Delete, 1);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.linkLabelSKUPPOREZAIDOPRINOSA1Delete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete.Margin = padding;
            size = new System.Drawing.Size(80, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete.MinimumSize = size;
            size = new System.Drawing.Size(80, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSKUPPOREZAIDOPRINOSA1.Location = point;
            this.linkLabelSKUPPOREZAIDOPRINOSA1.Name = "linkLabelSKUPPOREZAIDOPRINOSA1";
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.Controls.Add(this.linkLabelSKUPPOREZAIDOPRINOSA1, 3, 0);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.SetColumnSpan(this.linkLabelSKUPPOREZAIDOPRINOSA1, 1);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.SetRowSpan(this.linkLabelSKUPPOREZAIDOPRINOSA1, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSKUPPOREZAIDOPRINOSA1.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA1.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA1.Size = size;
            this.linkLabelSKUPPOREZAIDOPRINOSA1.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelSKUPPOREZAIDOPRINOSA2.Location = point;
            this.grdLevelSKUPPOREZAIDOPRINOSA2.Name = "grdLevelSKUPPOREZAIDOPRINOSA2";
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.Controls.Add(this.grdLevelSKUPPOREZAIDOPRINOSA2, 0, 4);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetColumnSpan(this.grdLevelSKUPPOREZAIDOPRINOSA2, 2);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetRowSpan(this.grdLevelSKUPPOREZAIDOPRINOSA2, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelSKUPPOREZAIDOPRINOSA2.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelSKUPPOREZAIDOPRINOSA2.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelSKUPPOREZAIDOPRINOSA2.Size = size;
            this.grdLevelSKUPPOREZAIDOPRINOSA2.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsSKUPPOREZAIDOPRINOSA2.Location = point;
            this.panelactionsSKUPPOREZAIDOPRINOSA2.Name = "panelactionsSKUPPOREZAIDOPRINOSA2";
            this.panelactionsSKUPPOREZAIDOPRINOSA2.BackColor = Color.Transparent;
            this.panelactionsSKUPPOREZAIDOPRINOSA2.Controls.Add(this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.Controls.Add(this.panelactionsSKUPPOREZAIDOPRINOSA2, 0, 5);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetColumnSpan(this.panelactionsSKUPPOREZAIDOPRINOSA2, 2);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.SetRowSpan(this.panelactionsSKUPPOREZAIDOPRINOSA2, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsSKUPPOREZAIDOPRINOSA2.Margin = padding;
            size = new System.Drawing.Size(0x144, 0x19);
            this.panelactionsSKUPPOREZAIDOPRINOSA2.MinimumSize = size;
            size = new System.Drawing.Size(0x144, 0x19);
            this.panelactionsSKUPPOREZAIDOPRINOSA2.Size = size;
            this.panelactionsSKUPPOREZAIDOPRINOSA2.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add.Location = point;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add.Name = "linkLabelSKUPPOREZAIDOPRINOSA2Add";
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add.Size = size;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add.Text = " Add Doprinosi  ";
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add.Click += new EventHandler(this.SKUPPOREZAIDOPRINOSA2Add_Click);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add.BackColor = Color.Transparent;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add.Appearance.ForeColor = Color.Blue;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add.Cursor = Cursors.Hand;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add.AutoSize = true;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.Controls.Add(this.linkLabelSKUPPOREZAIDOPRINOSA2Add, 0, 0);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.linkLabelSKUPPOREZAIDOPRINOSA2Add, 1);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.linkLabelSKUPPOREZAIDOPRINOSA2Add, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add.Margin = padding;
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add.MinimumSize = size;
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update.Location = point;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update.Name = "linkLabelSKUPPOREZAIDOPRINOSA2Update";
            size = new System.Drawing.Size(0x66, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update.Size = size;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update.Text = " Update Doprinosi  ";
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update.Click += new EventHandler(this.SKUPPOREZAIDOPRINOSA2Update_Click);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update.BackColor = Color.Transparent;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update.Appearance.ForeColor = Color.Blue;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update.Cursor = Cursors.Hand;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update.AutoSize = true;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.Controls.Add(this.linkLabelSKUPPOREZAIDOPRINOSA2Update, 1, 0);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.linkLabelSKUPPOREZAIDOPRINOSA2Update, 1);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.linkLabelSKUPPOREZAIDOPRINOSA2Update, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update.Margin = padding;
            size = new System.Drawing.Size(0x66, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete.Location = point;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete.Name = "linkLabelSKUPPOREZAIDOPRINOSA2Delete";
            size = new System.Drawing.Size(0x62, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete.Size = size;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete.Text = " Delete Doprinosi  ";
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete.Click += new EventHandler(this.SKUPPOREZAIDOPRINOSA2Delete_Click);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete.BackColor = Color.Transparent;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete.Appearance.ForeColor = Color.Blue;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete.Cursor = Cursors.Hand;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete.AutoSize = true;
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.Controls.Add(this.linkLabelSKUPPOREZAIDOPRINOSA2Delete, 2, 0);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.linkLabelSKUPPOREZAIDOPRINOSA2Delete, 1);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.linkLabelSKUPPOREZAIDOPRINOSA2Delete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete.Margin = padding;
            size = new System.Drawing.Size(0x62, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete.MinimumSize = size;
            size = new System.Drawing.Size(0x62, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSKUPPOREZAIDOPRINOSA2.Location = point;
            this.linkLabelSKUPPOREZAIDOPRINOSA2.Name = "linkLabelSKUPPOREZAIDOPRINOSA2";
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.Controls.Add(this.linkLabelSKUPPOREZAIDOPRINOSA2, 3, 0);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.SetColumnSpan(this.linkLabelSKUPPOREZAIDOPRINOSA2, 1);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.SetRowSpan(this.linkLabelSKUPPOREZAIDOPRINOSA2, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSKUPPOREZAIDOPRINOSA2.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA2.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSKUPPOREZAIDOPRINOSA2.Size = size;
            this.linkLabelSKUPPOREZAIDOPRINOSA2.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformSKUPPOREZAIDOPRINOSA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSKUPPOREZAIDOPRINOSA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.Disabled;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAIDSKUPPOREZAIDOPRINOSADescription;
            column2.Width = 0xea;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            column2.Hidden = true;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAIDPOREZDescription;
            column.Width = 0x63;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.Disabled;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSANAZIVPOREZDescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.Disabled;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPOREZMJESECNODescription;
            column8.Width = 0xd9;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.Disabled;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSASTOPAPOREZADescription;
            column13.Width = 0x66;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.Disabled;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAMOPOREZDescription;
            column3.Width = 170;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.Disabled;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPOPOREZDescription;
            column7.Width = 0xe2;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.Disabled;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAMZPOREZDescription;
            column4.Width = 170;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.Disabled;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPZPOREZDescription;
            column11.Width = 0xe2;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.Disabled;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPRIMATELJPOREZ1Description;
            column9.Width = 0x9c;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.Disabled;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPRIMATELJPOREZ2Description;
            column10.Width = 0x9c;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.Disabled;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSASIFRAOPISAPLACANJAPOREZDescription;
            column12.Width = 0xcd;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.Disabled;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAOPISPLACANJAPOREZDescription;
            column6.Width = 0x10c;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 1;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 2;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 3;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 4;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 5;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 6;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 7;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 8;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 9;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 10;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 11;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 12;
            this.grdLevelSKUPPOREZAIDOPRINOSA1.Visible = true;
            this.grdLevelSKUPPOREZAIDOPRINOSA1.Name = "grdLevelSKUPPOREZAIDOPRINOSA1";
            this.grdLevelSKUPPOREZAIDOPRINOSA1.Tag = "SKUPPOREZAIDOPRINOSA1";
            this.grdLevelSKUPPOREZAIDOPRINOSA1.TabIndex = 0x10;
            this.grdLevelSKUPPOREZAIDOPRINOSA1.Dock = DockStyle.Fill;
            this.grdLevelSKUPPOREZAIDOPRINOSA1.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelSKUPPOREZAIDOPRINOSA1.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelSKUPPOREZAIDOPRINOSA1.DataSource = this.bindingSourceSKUPPOREZAIDOPRINOSA1;
            this.grdLevelSKUPPOREZAIDOPRINOSA1.Enter += new EventHandler(this.grdLevelSKUPPOREZAIDOPRINOSA1_Enter);
            this.grdLevelSKUPPOREZAIDOPRINOSA1.AfterRowInsert += new RowEventHandler(this.grdLevelSKUPPOREZAIDOPRINOSA1_AfterRowInsert);
            this.grdLevelSKUPPOREZAIDOPRINOSA1.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelSKUPPOREZAIDOPRINOSA1.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelSKUPPOREZAIDOPRINOSA1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelSKUPPOREZAIDOPRINOSA1.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelSKUPPOREZAIDOPRINOSA1_DoubleClick);
            this.grdLevelSKUPPOREZAIDOPRINOSA1.AfterRowActivate += new EventHandler(this.grdLevelSKUPPOREZAIDOPRINOSA1_AfterRowActivate);
            this.grdLevelSKUPPOREZAIDOPRINOSA1.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelSKUPPOREZAIDOPRINOSA1.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelSKUPPOREZAIDOPRINOSA1.DisplayLayout.BandsSerializer.Add(band);
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.Disabled;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAIDSKUPPOREZAIDOPRINOSADescription;
            column15.Width = 0xea;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnn";
            column15.PromptChar = ' ';
            column15.Format = "";
            column15.CellAppearance = appearance15;
            column15.Hidden = true;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAIDDOPRINOSDescription;
            column14.Width = 0x77;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnn";
            column14.PromptChar = ' ';
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.Disabled;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSANAZIVDOPRINOSDescription;
            column21.Width = 0x128;
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.Disabled;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAIDVRSTADOPRINOSDescription;
            column16.Width = 0x9f;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnn";
            column16.PromptChar = ' ';
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.Disabled;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSANAZIVVRSTADOPRINOSDescription;
            column22.Width = 0x128;
            column22.Format = "";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.Disabled;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAMODOPRINOSDescription;
            column19.Width = 0xbf;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.Disabled;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPODOPRINOSDescription;
            column24.Width = 0xbf;
            column24.Format = "";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.Disabled;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAMZDOPRINOSDescription;
            column20.Width = 0xbf;
            column20.Format = "";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.Disabled;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPZDOPRINOSDescription;
            column27.Width = 0xbf;
            column27.Format = "";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.Disabled;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPRIMATELJDOPRINOS1Description;
            column25.Width = 0x9c;
            column25.Format = "";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.Disabled;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAPRIMATELJDOPRINOS2Description;
            column26.Width = 0xb1;
            column26.Format = "";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.Disabled;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSASIFRAOPISAPLACANJADOPRINOSDescription;
            column28.Width = 0xe2;
            column28.Format = "";
            column28.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.Disabled;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAOPISPLACANJADOPRINOSDescription;
            column23.Width = 0x10c;
            column23.Format = "";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column30.CellActivation = Activation.Disabled;
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAVBDIDOPRINOSDescription;
            column30.Width = 0x80;
            column30.Format = "";
            column30.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.Disabled;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAZRNDOPRINOSDescription;
            column31.Width = 170;
            column31.Format = "";
            column31.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.Disabled;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAMINDOPRINOSDescription;
            column18.Width = 0x11d;
            appearance18.TextHAlign = HAlign.Right;
            column18.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column18.PromptChar = ' ';
            column18.Format = "F2";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.Disabled;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSAMAXDOPRINOSDescription;
            column17.Width = 0x123;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column17.PromptChar = ' ';
            column17.Format = "F2";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.Disabled;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.SKUPPOREZAIDOPRINOSASTOPADescription;
            column29.Width = 0x37;
            appearance29.TextHAlign = HAlign.Right;
            column29.MaskInput = "{LOC}-nnn.nn";
            column29.PromptChar = ' ';
            column29.Format = "F2";
            column29.CellAppearance = appearance29;
            band2.Columns.Add(column14);
            column14.Header.VisiblePosition = 0;
            band2.Columns.Add(column21);
            column21.Header.VisiblePosition = 1;
            band2.Columns.Add(column16);
            column16.Header.VisiblePosition = 2;
            band2.Columns.Add(column22);
            column22.Header.VisiblePosition = 3;
            band2.Columns.Add(column19);
            column19.Header.VisiblePosition = 4;
            band2.Columns.Add(column24);
            column24.Header.VisiblePosition = 5;
            band2.Columns.Add(column20);
            column20.Header.VisiblePosition = 6;
            band2.Columns.Add(column27);
            column27.Header.VisiblePosition = 7;
            band2.Columns.Add(column25);
            column25.Header.VisiblePosition = 8;
            band2.Columns.Add(column26);
            column26.Header.VisiblePosition = 9;
            band2.Columns.Add(column28);
            column28.Header.VisiblePosition = 10;
            band2.Columns.Add(column23);
            column23.Header.VisiblePosition = 11;
            band2.Columns.Add(column30);
            column30.Header.VisiblePosition = 12;
            band2.Columns.Add(column31);
            column31.Header.VisiblePosition = 13;
            band2.Columns.Add(column18);
            column18.Header.VisiblePosition = 14;
            band2.Columns.Add(column17);
            column17.Header.VisiblePosition = 15;
            band2.Columns.Add(column29);
            column29.Header.VisiblePosition = 0x10;
            band2.Columns.Add(column15);
            column15.Header.VisiblePosition = 0x11;
            this.grdLevelSKUPPOREZAIDOPRINOSA2.Visible = true;
            this.grdLevelSKUPPOREZAIDOPRINOSA2.Name = "grdLevelSKUPPOREZAIDOPRINOSA2";
            this.grdLevelSKUPPOREZAIDOPRINOSA2.Tag = "SKUPPOREZAIDOPRINOSA2";
            this.grdLevelSKUPPOREZAIDOPRINOSA2.TabIndex = 0x10;
            this.grdLevelSKUPPOREZAIDOPRINOSA2.Dock = DockStyle.Fill;
            this.grdLevelSKUPPOREZAIDOPRINOSA2.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelSKUPPOREZAIDOPRINOSA2.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelSKUPPOREZAIDOPRINOSA2.DataSource = this.bindingSourceSKUPPOREZAIDOPRINOSA2;
            this.grdLevelSKUPPOREZAIDOPRINOSA2.Enter += new EventHandler(this.grdLevelSKUPPOREZAIDOPRINOSA2_Enter);
            this.grdLevelSKUPPOREZAIDOPRINOSA2.AfterRowInsert += new RowEventHandler(this.grdLevelSKUPPOREZAIDOPRINOSA2_AfterRowInsert);
            this.grdLevelSKUPPOREZAIDOPRINOSA2.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelSKUPPOREZAIDOPRINOSA2.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelSKUPPOREZAIDOPRINOSA2.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelSKUPPOREZAIDOPRINOSA2.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelSKUPPOREZAIDOPRINOSA2_DoubleClick);
            this.grdLevelSKUPPOREZAIDOPRINOSA2.AfterRowActivate += new EventHandler(this.grdLevelSKUPPOREZAIDOPRINOSA2_AfterRowActivate);
            this.grdLevelSKUPPOREZAIDOPRINOSA2.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelSKUPPOREZAIDOPRINOSA2.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelSKUPPOREZAIDOPRINOSA2.DisplayLayout.BandsSerializer.Add(band2);
            this.Name = "SKUPPOREZAIDOPRINOSAFormUserControl";
            this.Text = "Skupine poreza i doprinosa";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SKUPPOREZAIDOPRINOSAFormUserControl_Load);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.ResumeLayout(false);
            this.layoutManagerformSKUPPOREZAIDOPRINOSA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSKUPPOREZAIDOPRINOSA).EndInit();
            ((ISupportInitialize) this.bindingSourceSKUPPOREZAIDOPRINOSA1).EndInit();
            ((ISupportInitialize) this.bindingSourceSKUPPOREZAIDOPRINOSA2).EndInit();
            ((ISupportInitialize) this.textIDSKUPPOREZAIDOPRINOSA).EndInit();
            ((ISupportInitialize) this.textNAZIVSKUPPOREZAIDOPRINOSA).EndInit();
            ((ISupportInitialize) this.grdLevelSKUPPOREZAIDOPRINOSA1).EndInit();
            this.panelactionsSKUPPOREZAIDOPRINOSA1.ResumeLayout(true);
            this.panelactionsSKUPPOREZAIDOPRINOSA1.PerformLayout();
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.ResumeLayout(false);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA1.PerformLayout();
            ((ISupportInitialize) this.grdLevelSKUPPOREZAIDOPRINOSA2).EndInit();
            this.panelactionsSKUPPOREZAIDOPRINOSA2.ResumeLayout(true);
            this.panelactionsSKUPPOREZAIDOPRINOSA2.PerformLayout();
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.ResumeLayout(false);
            this.layoutManagerpanelactionsSKUPPOREZAIDOPRINOSA2.PerformLayout();
            this.dsSKUPPOREZAIDOPRINOSADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.SKUPPOREZAIDOPRINOSAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSKUPPOREZAIDOPRINOSA, this.SKUPPOREZAIDOPRINOSAController.WorkItem, this))
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
            this.label1IDSKUPPOREZAIDOPRINOSA.Text = StringResources.SKUPPOREZAIDOPRINOSAIDSKUPPOREZAIDOPRINOSADescription;
            this.label1NAZIVSKUPPOREZAIDOPRINOSA.Text = StringResources.SKUPPOREZAIDOPRINOSANAZIVSKUPPOREZAIDOPRINOSADescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        [LocalCommandHandler("NewRADNIK")]
        public void NewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SKUPPOREZAIDOPRINOSAController.NewRADNIK(this.m_CurrentRow);
            }
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void RegisterBindingSources()
        {
            if (!this.SKUPPOREZAIDOPRINOSAController.WorkItem.Items.Contains("SKUPPOREZAIDOPRINOSA|SKUPPOREZAIDOPRINOSA"))
            {
                this.SKUPPOREZAIDOPRINOSAController.WorkItem.Items.Add(this.bindingSourceSKUPPOREZAIDOPRINOSA, "SKUPPOREZAIDOPRINOSA|SKUPPOREZAIDOPRINOSA");
            }
            if (!this.SKUPPOREZAIDOPRINOSAController.WorkItem.Items.Contains("SKUPPOREZAIDOPRINOSA|SKUPPOREZAIDOPRINOSA1"))
            {
                this.SKUPPOREZAIDOPRINOSAController.WorkItem.Items.Add(this.bindingSourceSKUPPOREZAIDOPRINOSA1, "SKUPPOREZAIDOPRINOSA|SKUPPOREZAIDOPRINOSA1");
            }
            if (!this.SKUPPOREZAIDOPRINOSAController.WorkItem.Items.Contains("SKUPPOREZAIDOPRINOSA|SKUPPOREZAIDOPRINOSA2"))
            {
                this.SKUPPOREZAIDOPRINOSAController.WorkItem.Items.Add(this.bindingSourceSKUPPOREZAIDOPRINOSA2, "SKUPPOREZAIDOPRINOSA|SKUPPOREZAIDOPRINOSA2");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsSKUPPOREZAIDOPRINOSADataSet1.SKUPPOREZAIDOPRINOSA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.SKUPPOREZAIDOPRINOSAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.SKUPPOREZAIDOPRINOSAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.SKUPPOREZAIDOPRINOSAController.Update(this))
            {
                this.SKUPPOREZAIDOPRINOSAController.DataSet = new SKUPPOREZAIDOPRINOSADataSet();
                DataSetUtil.AddEmptyRow(this.SKUPPOREZAIDOPRINOSAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.SKUPPOREZAIDOPRINOSAController.DataSet.SKUPPOREZAIDOPRINOSA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SetComboBoxColumnProperties()
        {
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelSKUPPOREZAIDOPRINOSA1, "IDPOREZ");
            gridColumn.Tag = "POREZIDPOREZ";
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            gridColumn.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            UltraGridColumn column2 = FormHelperClass.GetGridColumn(this.grdLevelSKUPPOREZAIDOPRINOSA2, "IDDOPRINOS");
            column2.Tag = "DOPRINOSIDDOPRINOS";
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
        }

        private void SetFocusInFirstField()
        {
            this.textIDSKUPPOREZAIDOPRINOSA.Focus();
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

        private void SKUPPOREZAIDOPRINOSA1Add_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelSKUPPOREZAIDOPRINOSA1.ActiveRow;
            this.SKUPPOREZAIDOPRINOSA1Insert();
        }

        private void SKUPPOREZAIDOPRINOSA1Delete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelSKUPPOREZAIDOPRINOSA1);
            if ((currentRowListIndex != -1) && (this.grdLevelSKUPPOREZAIDOPRINOSA1.Selected.Rows.Count > 0))
            {
                this.grdLevelSKUPPOREZAIDOPRINOSA1.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelSKUPPOREZAIDOPRINOSA1).Selected = true;
                this.grdLevelSKUPPOREZAIDOPRINOSA1.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SKUPPOREZAIDOPRINOSA1Insert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceSKUPPOREZAIDOPRINOSA, this.SKUPPOREZAIDOPRINOSAController.WorkItem, this))
            {
                this.SKUPPOREZAIDOPRINOSAController.AddSKUPPOREZAIDOPRINOSA1(this.m_CurrentRow);
            }
        }

        private void SKUPPOREZAIDOPRINOSA1Update()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelSKUPPOREZAIDOPRINOSA1) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelSKUPPOREZAIDOPRINOSA1);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.SKUPPOREZAIDOPRINOSAController.UpdateSKUPPOREZAIDOPRINOSA1(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SKUPPOREZAIDOPRINOSA1Update_Click(object sender, EventArgs e)
        {
            if (this.grdLevelSKUPPOREZAIDOPRINOSA1.ActiveRow != null)
            {
                this.SKUPPOREZAIDOPRINOSA1Update();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SKUPPOREZAIDOPRINOSA2Add_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelSKUPPOREZAIDOPRINOSA2.ActiveRow;
            this.SKUPPOREZAIDOPRINOSA2Insert();
        }

        private void SKUPPOREZAIDOPRINOSA2Delete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelSKUPPOREZAIDOPRINOSA2);
            if ((currentRowListIndex != -1) && (this.grdLevelSKUPPOREZAIDOPRINOSA2.Selected.Rows.Count > 0))
            {
                this.grdLevelSKUPPOREZAIDOPRINOSA2.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelSKUPPOREZAIDOPRINOSA2).Selected = true;
                this.grdLevelSKUPPOREZAIDOPRINOSA2.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SKUPPOREZAIDOPRINOSA2Insert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceSKUPPOREZAIDOPRINOSA, this.SKUPPOREZAIDOPRINOSAController.WorkItem, this))
            {
                this.SKUPPOREZAIDOPRINOSAController.AddSKUPPOREZAIDOPRINOSA2(this.m_CurrentRow);
            }
        }

        private void SKUPPOREZAIDOPRINOSA2Update()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelSKUPPOREZAIDOPRINOSA2) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelSKUPPOREZAIDOPRINOSA2);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.SKUPPOREZAIDOPRINOSAController.UpdateSKUPPOREZAIDOPRINOSA2(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SKUPPOREZAIDOPRINOSA2Update_Click(object sender, EventArgs e)
        {
            if (this.grdLevelSKUPPOREZAIDOPRINOSA2.ActiveRow != null)
            {
                this.SKUPPOREZAIDOPRINOSA2Update();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SKUPPOREZAIDOPRINOSAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.SKUPPOREZAIDOPRINOSADescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelSKUPPOREZAIDOPRINOSA1Add.Text = Deklarit.Resources.Resources.Add + " " + StringResources.SKUPPOREZAIDOPRINOSASKUPPOREZAIDOPRINOSA1LevelDescription;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Update.Text = Deklarit.Resources.Resources.Update + " " + StringResources.SKUPPOREZAIDOPRINOSASKUPPOREZAIDOPRINOSA1LevelDescription;
            this.linkLabelSKUPPOREZAIDOPRINOSA1Delete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.SKUPPOREZAIDOPRINOSASKUPPOREZAIDOPRINOSA1LevelDescription;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Add.Text = Deklarit.Resources.Resources.Add + " " + StringResources.SKUPPOREZAIDOPRINOSASKUPPOREZAIDOPRINOSA2LevelDescription;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Update.Text = Deklarit.Resources.Resources.Update + " " + StringResources.SKUPPOREZAIDOPRINOSASKUPPOREZAIDOPRINOSA2LevelDescription;
            this.linkLabelSKUPPOREZAIDOPRINOSA2Delete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.SKUPPOREZAIDOPRINOSASKUPPOREZAIDOPRINOSA2LevelDescription;
        }

        [LocalCommandHandler("ViewRADNIK")]
        public void ViewRADNIKHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.SKUPPOREZAIDOPRINOSAController.ViewRADNIK(this.m_CurrentRow);
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

        protected virtual UltraGrid grdLevelSKUPPOREZAIDOPRINOSA1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelSKUPPOREZAIDOPRINOSA1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelSKUPPOREZAIDOPRINOSA1 = value;
            }
        }

        protected virtual UltraGrid grdLevelSKUPPOREZAIDOPRINOSA2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelSKUPPOREZAIDOPRINOSA2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelSKUPPOREZAIDOPRINOSA2 = value;
            }
        }

        protected virtual UltraLabel label1IDSKUPPOREZAIDOPRINOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDSKUPPOREZAIDOPRINOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDSKUPPOREZAIDOPRINOSA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVSKUPPOREZAIDOPRINOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVSKUPPOREZAIDOPRINOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVSKUPPOREZAIDOPRINOSA = value;
            }
        }

        protected virtual UltraLabel linkLabelSKUPPOREZAIDOPRINOSA1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSKUPPOREZAIDOPRINOSA1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSKUPPOREZAIDOPRINOSA1 = value;
            }
        }

        protected virtual UltraLabel linkLabelSKUPPOREZAIDOPRINOSA1Add
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSKUPPOREZAIDOPRINOSA1Add;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSKUPPOREZAIDOPRINOSA1Add = value;
            }
        }

        protected virtual UltraLabel linkLabelSKUPPOREZAIDOPRINOSA1Delete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSKUPPOREZAIDOPRINOSA1Delete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSKUPPOREZAIDOPRINOSA1Delete = value;
            }
        }

        protected virtual UltraLabel linkLabelSKUPPOREZAIDOPRINOSA1Update
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSKUPPOREZAIDOPRINOSA1Update;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSKUPPOREZAIDOPRINOSA1Update = value;
            }
        }

        protected virtual UltraLabel linkLabelSKUPPOREZAIDOPRINOSA2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSKUPPOREZAIDOPRINOSA2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSKUPPOREZAIDOPRINOSA2 = value;
            }
        }

        protected virtual UltraLabel linkLabelSKUPPOREZAIDOPRINOSA2Add
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSKUPPOREZAIDOPRINOSA2Add;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSKUPPOREZAIDOPRINOSA2Add = value;
            }
        }

        protected virtual UltraLabel linkLabelSKUPPOREZAIDOPRINOSA2Delete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSKUPPOREZAIDOPRINOSA2Delete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSKUPPOREZAIDOPRINOSA2Delete = value;
            }
        }

        protected virtual UltraLabel linkLabelSKUPPOREZAIDOPRINOSA2Update
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSKUPPOREZAIDOPRINOSA2Update;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSKUPPOREZAIDOPRINOSA2Update = value;
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

        protected virtual Panel panelactionsSKUPPOREZAIDOPRINOSA1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsSKUPPOREZAIDOPRINOSA1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsSKUPPOREZAIDOPRINOSA1 = value;
            }
        }

        protected virtual Panel panelactionsSKUPPOREZAIDOPRINOSA2
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsSKUPPOREZAIDOPRINOSA2;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsSKUPPOREZAIDOPRINOSA2 = value;
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
        public NetAdvantage.Controllers.SKUPPOREZAIDOPRINOSAController SKUPPOREZAIDOPRINOSAController { get; set; }

        protected virtual UltraNumericEditor textIDSKUPPOREZAIDOPRINOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDSKUPPOREZAIDOPRINOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDSKUPPOREZAIDOPRINOSA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVSKUPPOREZAIDOPRINOSA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVSKUPPOREZAIDOPRINOSA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVSKUPPOREZAIDOPRINOSA = value;
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

