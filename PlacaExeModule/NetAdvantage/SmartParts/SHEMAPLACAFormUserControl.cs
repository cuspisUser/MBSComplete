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
    public class SHEMAPLACAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboSHEMAPLOJIDORGJED")]
        private ORGJEDComboBox _comboSHEMAPLOJIDORGJED;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelSHEMAPLACASHEMAPLACADOP")]
        private UltraGrid _grdLevelSHEMAPLACASHEMAPLACADOP;
        [AccessedThroughProperty("grdLevelSHEMAPLACASHEMAPLACAELEMENT")]
        private UltraGrid _grdLevelSHEMAPLACASHEMAPLACAELEMENT;
        [AccessedThroughProperty("grdLevelSHEMAPLACASHEMAPLACASTANDARD")]
        private UltraGrid _grdLevelSHEMAPLACASHEMAPLACASTANDARD;
        [AccessedThroughProperty("label1IDSHEMAPLACA")]
        private UltraLabel _label1IDSHEMAPLACA;
        [AccessedThroughProperty("label1NAZIVSHEMAPLACA")]
        private UltraLabel _label1NAZIVSHEMAPLACA;
        [AccessedThroughProperty("label1SHEMAPLOJIDORGJED")]
        private UltraLabel _label1SHEMAPLOJIDORGJED;
        [AccessedThroughProperty("linkLabelSHEMAPLACASHEMAPLACADOP")]
        private UltraLabel _linkLabelSHEMAPLACASHEMAPLACADOP;
        [AccessedThroughProperty("linkLabelSHEMAPLACASHEMAPLACADOPAdd")]
        private UltraLabel _linkLabelSHEMAPLACASHEMAPLACADOPAdd;
        [AccessedThroughProperty("linkLabelSHEMAPLACASHEMAPLACADOPDelete")]
        private UltraLabel _linkLabelSHEMAPLACASHEMAPLACADOPDelete;
        [AccessedThroughProperty("linkLabelSHEMAPLACASHEMAPLACADOPUpdate")]
        private UltraLabel _linkLabelSHEMAPLACASHEMAPLACADOPUpdate;
        [AccessedThroughProperty("linkLabelSHEMAPLACASHEMAPLACAELEMENT")]
        private UltraLabel _linkLabelSHEMAPLACASHEMAPLACAELEMENT;
        [AccessedThroughProperty("linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd")]
        private UltraLabel _linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd;
        [AccessedThroughProperty("linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete")]
        private UltraLabel _linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete;
        [AccessedThroughProperty("linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate")]
        private UltraLabel _linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate;
        [AccessedThroughProperty("linkLabelSHEMAPLACASHEMAPLACASTANDARD")]
        private UltraLabel _linkLabelSHEMAPLACASHEMAPLACASTANDARD;
        [AccessedThroughProperty("linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd")]
        private UltraLabel _linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd;
        [AccessedThroughProperty("linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete")]
        private UltraLabel _linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete;
        [AccessedThroughProperty("linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate")]
        private UltraLabel _linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate;
        [AccessedThroughProperty("panelactionsSHEMAPLACASHEMAPLACADOP")]
        private Panel _panelactionsSHEMAPLACASHEMAPLACADOP;
        [AccessedThroughProperty("panelactionsSHEMAPLACASHEMAPLACAELEMENT")]
        private Panel _panelactionsSHEMAPLACASHEMAPLACAELEMENT;
        [AccessedThroughProperty("panelactionsSHEMAPLACASHEMAPLACASTANDARD")]
        private Panel _panelactionsSHEMAPLACASHEMAPLACASTANDARD;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("Tab1")]
        private UltraTabControl _Tab1;
        [AccessedThroughProperty("TabPage1")]
        private UltraTabPageControl _TabPage1;
        [AccessedThroughProperty("TabPage2")]
        private UltraTabPageControl _TabPage2;
        [AccessedThroughProperty("TabPage3")]
        private UltraTabPageControl _TabPage3;
        [AccessedThroughProperty("textIDSHEMAPLACA")]
        private UltraNumericEditor _textIDSHEMAPLACA;
        [AccessedThroughProperty("textNAZIVSHEMAPLACA")]
        private UltraTextEditor _textNAZIVSHEMAPLACA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceSHEMAPLACA;
        private BindingSource bindingSourceSHEMAPLACASHEMAPLACADOP;
        private BindingSource bindingSourceSHEMAPLACASHEMAPLACAELEMENT;
        private BindingSource bindingSourceSHEMAPLACASHEMAPLACASTANDARD;
        private IContainer components = null;
        private SHEMAPLACADataSet dsSHEMAPLACADataSet1;
        protected TableLayoutPanel layoutManagerformSHEMAPLACA;
        protected TableLayoutPanel layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP;
        protected TableLayoutPanel layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT;
        protected TableLayoutPanel layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD;
        protected TableLayoutPanel layoutManagerTabPage1;
        protected TableLayoutPanel layoutManagerTabPage2;
        protected TableLayoutPanel layoutManagerTabPage3;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private SHEMAPLACADataSet.SHEMAPLACARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "SHEMAPLACA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.SHEMAPLACADescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public SHEMAPLACAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CellChanged(object sender, EventArgs e)
        {
            this.m_BaseMethods.CellChangedBase(this.dsSHEMAPLACADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceSHEMAPLACA.DataSource = this.SHEMAPLACAController.DataSet;
            this.dsSHEMAPLACADataSet1 = this.SHEMAPLACAController.DataSet;
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
        public void comboSHEMAPLOJIDORGJED_Add(object sender, ComponentEventArgs e)
        {
            this.comboSHEMAPLOJIDORGJED.Fill();
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
                    enumerator = this.dsSHEMAPLACADataSet1.SHEMAPLACA.Rows.GetEnumerator();
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
                if (this.SHEMAPLACAController.Update(this))
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
                    case "KONTOKONTOELEMENTIDKONTOAddNew":
                        this.PictureBoxClickedInLinesKONTOELEMENTIDKONTO(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "STRANEKNJIZENJASTRANEELEMENTIDSTRANEKNJIZENJAAddNew":
                        this.PictureBoxClickedInLinesSTRANEELEMENTIDSTRANEKNJIZENJA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "MJESTOTROSKAMTELEMENTIDMJESTOTROSKAAddNew":
                        this.PictureBoxClickedInLinesMTELEMENTIDMJESTOTROSKA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "KONTOKONTODOPIDKONTOAddNew":
                        this.PictureBoxClickedInLinesKONTODOPIDKONTO(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "MJESTOTROSKAMTDOPIDMJESTOTROSKAAddNew":
                        this.PictureBoxClickedInLinesMTDOPIDMJESTOTROSKA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "STRANEKNJIZENJASTRANEDOPIDSTRANEKNJIZENJAAddNew":
                        this.PictureBoxClickedInLinesSTRANEDOPIDSTRANEKNJIZENJA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "KONTOKONTOPLACAVRSTAIZNOSAIDKONTOAddNew":
                        this.PictureBoxClickedInLinesKONTOPLACAVRSTAIZNOSAIDKONTO(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "MJESTOTROSKAMTPLACAVRSTAIZNOSAIDMJESTOTROSKAAddNew":
                        this.PictureBoxClickedInLinesMTPLACAVRSTAIZNOSAIDMJESTOTROSKA(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "STRANEKNJIZENJASTRANEVRSTEIZNOSAIDSTRANEKNJIZENJAAddNew":
                        this.PictureBoxClickedInLinesSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA(RuntimeHelpers.GetObjectValue(sender), e);
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
            if (this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.ActiveRow != null)
            {
                this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelSHEMAPLACASHEMAPLACADOP.ActiveRow != null)
            {
                this.grdLevelSHEMAPLACASHEMAPLACADOP.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.ActiveRow != null)
            {
                this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.PerformAction(UltraGridAction.NextRow);
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
                if (e.Cell.Column.Key == "KONTOELEMENTIDKONTO")
                {
                    this.UpdateValuesKONTOELEMENTIDKONTO(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "STRANEELEMENTIDSTRANEKNJIZENJA")
                {
                    this.UpdateValuesSTRANEELEMENTIDSTRANEKNJIZENJA(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "MTELEMENTIDMJESTOTROSKA")
                {
                    this.UpdateValuesMTELEMENTIDMJESTOTROSKA(RuntimeHelpers.GetObjectValue(sender), e, result);
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
                if (e.Cell.Column.Key == "KONTOPLACAVRSTAIZNOSAIDKONTO")
                {
                    this.UpdateValuesKONTOPLACAVRSTAIZNOSAIDKONTO(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "MTPLACAVRSTAIZNOSAIDMJESTOTROSKA")
                {
                    this.UpdateValuesMTPLACAVRSTAIZNOSAIDMJESTOTROSKA(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
                if (e.Cell.Column.Key == "STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA")
                {
                    this.UpdateValuesSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA(RuntimeHelpers.GetObjectValue(sender), e, result);
                }
            }
        }

        private void grdLevelSHEMAPLACASHEMAPLACADOP_AfterRowActivate(object sender, EventArgs e)
        {
            string sHEMAPLACASHEMAPLACASHEMAPLACADOPLevelDescription = StringResources.SHEMAPLACASHEMAPLACASHEMAPLACADOPLevelDescription;
            UltraGridRow activeRow = this.grdLevelSHEMAPLACASHEMAPLACADOP.ActiveRow;
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd.Text = Deklarit.Resources.Resources.Add + " " + sHEMAPLACASHEMAPLACASHEMAPLACADOPLevelDescription;
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate.Text = Deklarit.Resources.Resources.Update + " " + sHEMAPLACASHEMAPLACASHEMAPLACADOPLevelDescription;
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete.Text = Deklarit.Resources.Resources.Delete + " " + sHEMAPLACASHEMAPLACASHEMAPLACADOPLevelDescription;
        }

        private void grdLevelSHEMAPLACASHEMAPLACADOP_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceSHEMAPLACA.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceSHEMAPLACA.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelSHEMAPLACASHEMAPLACADOP_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.SHEMAPLACASHEMAPLACADOPUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelSHEMAPLACASHEMAPLACADOP_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAPLACA, this.SHEMAPLACAController.WorkItem, this);
        }

        private void grdLevelSHEMAPLACASHEMAPLACAELEMENT_AfterRowActivate(object sender, EventArgs e)
        {
            string sHEMAPLACASHEMAPLACASHEMAPLACAELEMENTLevelDescription = StringResources.SHEMAPLACASHEMAPLACASHEMAPLACAELEMENTLevelDescription;
            UltraGridRow activeRow = this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.ActiveRow;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd.Text = Deklarit.Resources.Resources.Add + " " + sHEMAPLACASHEMAPLACASHEMAPLACAELEMENTLevelDescription;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate.Text = Deklarit.Resources.Resources.Update + " " + sHEMAPLACASHEMAPLACASHEMAPLACAELEMENTLevelDescription;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete.Text = Deklarit.Resources.Resources.Delete + " " + sHEMAPLACASHEMAPLACASHEMAPLACAELEMENTLevelDescription;
        }

        private void grdLevelSHEMAPLACASHEMAPLACAELEMENT_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceSHEMAPLACA.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceSHEMAPLACA.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelSHEMAPLACASHEMAPLACAELEMENT_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.SHEMAPLACASHEMAPLACAELEMENTUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelSHEMAPLACASHEMAPLACAELEMENT_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAPLACA, this.SHEMAPLACAController.WorkItem, this);
        }

        private void grdLevelSHEMAPLACASHEMAPLACASTANDARD_AfterRowActivate(object sender, EventArgs e)
        {
            string sHEMAPLACASHEMAPLACASHEMAPLACASTANDARDLevelDescription = StringResources.SHEMAPLACASHEMAPLACASHEMAPLACASTANDARDLevelDescription;
            UltraGridRow activeRow = this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.ActiveRow;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd.Text = Deklarit.Resources.Resources.Add + " " + sHEMAPLACASHEMAPLACASHEMAPLACASTANDARDLevelDescription;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate.Text = Deklarit.Resources.Resources.Update + " " + sHEMAPLACASHEMAPLACASHEMAPLACASTANDARDLevelDescription;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete.Text = Deklarit.Resources.Resources.Delete + " " + sHEMAPLACASHEMAPLACASHEMAPLACASTANDARDLevelDescription;
        }

        private void grdLevelSHEMAPLACASHEMAPLACASTANDARD_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceSHEMAPLACA.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceSHEMAPLACA.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelSHEMAPLACASHEMAPLACASTANDARD_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.SHEMAPLACASHEMAPLACASTANDARDUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelSHEMAPLACASHEMAPLACASTANDARD_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAPLACA, this.SHEMAPLACAController.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "SHEMAPLACA", this.m_Mode, this.dsSHEMAPLACADataSet1, this.dsSHEMAPLACADataSet1.SHEMAPLACA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            if (!this.m_DataGrids.Contains(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT))
            {
                this.m_DataGrids.Add(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelSHEMAPLACASHEMAPLACADOP))
            {
                this.m_DataGrids.Add(this.grdLevelSHEMAPLACASHEMAPLACADOP);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD))
            {
                this.m_DataGrids.Add(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsSHEMAPLACADataSet1.SHEMAPLACA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (SHEMAPLACADataSet.SHEMAPLACARow) ((DataRowView) this.bindingSourceSHEMAPLACA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(SHEMAPLACAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceSHEMAPLACA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMAPLACA).BeginInit();
            this.bindingSourceSHEMAPLACASHEMAPLACADOP = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMAPLACASHEMAPLACADOP).BeginInit();
            this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT).BeginInit();
            this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD).BeginInit();
            this.layoutManagerformSHEMAPLACA = new TableLayoutPanel();
            this.layoutManagerformSHEMAPLACA.SuspendLayout();
            this.layoutManagerformSHEMAPLACA.AutoSize = true;
            this.layoutManagerformSHEMAPLACA.Dock = DockStyle.Fill;
            this.layoutManagerformSHEMAPLACA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSHEMAPLACA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSHEMAPLACA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSHEMAPLACA.Size = size;
            this.layoutManagerformSHEMAPLACA.ColumnCount = 2;
            this.layoutManagerformSHEMAPLACA.RowCount = 4;
            this.layoutManagerformSHEMAPLACA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAPLACA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSHEMAPLACA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACA.RowStyles.Add(new RowStyle());
            this.layoutManagerformSHEMAPLACA.RowStyles.Add(new RowStyle());
            this.label1IDSHEMAPLACA = new UltraLabel();
            this.textIDSHEMAPLACA = new UltraNumericEditor();
            this.label1NAZIVSHEMAPLACA = new UltraLabel();
            this.textNAZIVSHEMAPLACA = new UltraTextEditor();
            this.label1SHEMAPLOJIDORGJED = new UltraLabel();
            this.comboSHEMAPLOJIDORGJED = new ORGJEDComboBox();
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
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT = new UltraGrid();
            this.panelactionsSHEMAPLACASHEMAPLACAELEMENT = new Panel();
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT = new TableLayoutPanel();
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.ColumnCount = 4;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.RowCount = 1;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.RowStyles.Add(new RowStyle());
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd = new UltraLabel();
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate = new UltraLabel();
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete = new UltraLabel();
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENT = new UltraLabel();
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
            this.grdLevelSHEMAPLACASHEMAPLACADOP = new UltraGrid();
            this.panelactionsSHEMAPLACASHEMAPLACADOP = new Panel();
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP = new TableLayoutPanel();
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.ColumnCount = 4;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.RowCount = 1;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.RowStyles.Add(new RowStyle());
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd = new UltraLabel();
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate = new UltraLabel();
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete = new UltraLabel();
            this.linkLabelSHEMAPLACASHEMAPLACADOP = new UltraLabel();
            UltraTab tab3 = new UltraTab();
            this.TabPage3 = new UltraTabPageControl();
            this.layoutManagerTabPage3 = new TableLayoutPanel();
            this.layoutManagerTabPage3.AutoSize = true;
            this.layoutManagerTabPage3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerTabPage3.ColumnCount = 1;
            this.layoutManagerTabPage3.RowCount = 2;
            this.layoutManagerTabPage3.Dock = DockStyle.Fill;
            this.layoutManagerTabPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            this.layoutManagerTabPage3.RowStyles.Add(new RowStyle());
            padding = new Padding(5, 5, 5, 5);
            this.layoutManagerTabPage3.Margin = padding;
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD = new UltraGrid();
            this.panelactionsSHEMAPLACASHEMAPLACASTANDARD = new Panel();
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD = new TableLayoutPanel();
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.ColumnCount = 4;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.RowCount = 1;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.RowStyles.Add(new RowStyle());
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd = new UltraLabel();
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate = new UltraLabel();
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete = new UltraLabel();
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARD = new UltraLabel();
            ((ISupportInitialize) this.textIDSHEMAPLACA).BeginInit();
            ((ISupportInitialize) this.textNAZIVSHEMAPLACA).BeginInit();
            this.Tab1.SuspendLayout();
            ((ISupportInitialize) this.Tab1).BeginInit();
            this.layoutManagerTabPage1.SuspendLayout();
            ((ISupportInitialize) this.grdLevelSHEMAPLACASHEMAPLACAELEMENT).BeginInit();
            this.panelactionsSHEMAPLACASHEMAPLACAELEMENT.SuspendLayout();
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.SuspendLayout();
            this.layoutManagerTabPage2.SuspendLayout();
            ((ISupportInitialize) this.grdLevelSHEMAPLACASHEMAPLACADOP).BeginInit();
            this.panelactionsSHEMAPLACASHEMAPLACADOP.SuspendLayout();
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.SuspendLayout();
            this.layoutManagerTabPage3.SuspendLayout();
            ((ISupportInitialize) this.grdLevelSHEMAPLACASHEMAPLACASTANDARD).BeginInit();
            this.panelactionsSHEMAPLACASHEMAPLACASTANDARD.SuspendLayout();
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.SuspendLayout();
            UltraGridBand band = new UltraGridBand("SHEMAPLACASHEMAPLACADOP", -1);
            UltraGridColumn column = new UltraGridColumn("IDSHEMAPLACA");
            UltraGridColumn column6 = new UltraGridColumn("SHEMAPLDOPIDDOPRINOS");
            UltraGridColumn column2 = new UltraGridColumn("KONTODOPIDKONTO");
            UltraGridColumn column3 = new UltraGridColumn("columnKONTODOPIDKONTOAddNew", 0);
            UltraGridColumn column4 = new UltraGridColumn("MTDOPIDMJESTOTROSKA");
            UltraGridColumn column5 = new UltraGridColumn("columnMTDOPIDMJESTOTROSKAAddNew", 1);
            UltraGridColumn column8 = new UltraGridColumn("STRANEDOPIDSTRANEKNJIZENJA");
            UltraGridColumn column9 = new UltraGridColumn("columnSTRANEDOPIDSTRANEKNJIZENJAAddNew", 2);
            UltraGridColumn column7 = new UltraGridColumn("SHEMAPLDOPNAZIVDOPRINOS");
            UltraGridBand band2 = new UltraGridBand("SHEMAPLACASHEMAPLACAELEMENT", -1);
            UltraGridColumn column10 = new UltraGridColumn("IDSHEMAPLACA");
            UltraGridColumn column15 = new UltraGridColumn("SHEMAPLELEMENTIDELEMENT");
            UltraGridColumn column16 = new UltraGridColumn("columnSHEMAPLELEMENTIDELEMENTAddNew", 0);
            UltraGridColumn column11 = new UltraGridColumn("KONTOELEMENTIDKONTO");
            UltraGridColumn column12 = new UltraGridColumn("columnKONTOELEMENTIDKONTOAddNew", 1);
            UltraGridColumn column19 = new UltraGridColumn("STRANEELEMENTIDSTRANEKNJIZENJA");
            UltraGridColumn column20 = new UltraGridColumn("columnSTRANEELEMENTIDSTRANEKNJIZENJAAddNew", 2);
            UltraGridColumn column13 = new UltraGridColumn("MTELEMENTIDMJESTOTROSKA");
            UltraGridColumn column14 = new UltraGridColumn("columnMTELEMENTIDMJESTOTROSKAAddNew", 3);
            UltraGridColumn column18 = new UltraGridColumn("SHEMAPLELEMENTNAZIVELEMENT");
            UltraGridColumn column17 = new UltraGridColumn("SHEMAPLELEMENTIDVRSTAELEMENTA");
            UltraGridBand band3 = new UltraGridBand("SHEMAPLACASHEMAPLACASTANDARD", -1);
            UltraGridColumn column23 = new UltraGridColumn("IDSHEMAPLACA");
            UltraGridColumn column29 = new UltraGridColumn("SHEMAPLACASTANDARDID");
            UltraGridColumn column21 = new UltraGridColumn("IDPLVRSTEIZNOSA");
            UltraGridColumn column22 = new UltraGridColumn("columnIDPLVRSTEIZNOSAAddNew", 0);
            UltraGridColumn column24 = new UltraGridColumn("KONTOPLACAVRSTAIZNOSAIDKONTO");
            UltraGridColumn column25 = new UltraGridColumn("columnKONTOPLACAVRSTAIZNOSAIDKONTOAddNew", 1);
            UltraGridColumn column26 = new UltraGridColumn("MTPLACAVRSTAIZNOSAIDMJESTOTROSKA");
            UltraGridColumn column27 = new UltraGridColumn("columnMTPLACAVRSTAIZNOSAIDMJESTOTROSKAAddNew", 2);
            UltraGridColumn column30 = new UltraGridColumn("STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA");
            UltraGridColumn column31 = new UltraGridColumn("columnSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJAAddNew", 3);
            UltraGridColumn column28 = new UltraGridColumn("NAZIVPLVRSTEIZNOSA");
            this.dsSHEMAPLACADataSet1 = new SHEMAPLACADataSet();
            this.dsSHEMAPLACADataSet1.BeginInit();
            this.SuspendLayout();
            this.Tab1.Tabs.Add(tab);
            this.Tab1.Controls.Add(this.TabPage1);
            this.Tab1.Tabs.Add(tab2);
            this.Tab1.Controls.Add(this.TabPage2);
            this.Tab1.Tabs.Add(tab3);
            this.Tab1.Controls.Add(this.TabPage3);
            this.dsSHEMAPLACADataSet1.DataSetName = "dsSHEMAPLACA";
            this.dsSHEMAPLACADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceSHEMAPLACA.DataSource = this.dsSHEMAPLACADataSet1;
            this.bindingSourceSHEMAPLACA.DataMember = "SHEMAPLACA";
            ((ISupportInitialize) this.bindingSourceSHEMAPLACA).BeginInit();
            this.bindingSourceSHEMAPLACASHEMAPLACADOP.DataSource = this.bindingSourceSHEMAPLACA;
            this.bindingSourceSHEMAPLACASHEMAPLACADOP.DataMember = "SHEMAPLACA_SHEMAPLACASHEMAPLACADOP";
            this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.DataSource = this.bindingSourceSHEMAPLACA;
            this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT.DataMember = "SHEMAPLACA_SHEMAPLACASHEMAPLACAELEMENT";
            this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.DataSource = this.bindingSourceSHEMAPLACA;
            this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD.DataMember = "SHEMAPLACA_SHEMAPLACASHEMAPLACASTANDARD";
            point = new System.Drawing.Point(0, 0);
            this.label1IDSHEMAPLACA.Location = point;
            this.label1IDSHEMAPLACA.Name = "label1IDSHEMAPLACA";
            this.label1IDSHEMAPLACA.TabIndex = 1;
            this.label1IDSHEMAPLACA.Tag = "labelIDSHEMAPLACA";
            this.label1IDSHEMAPLACA.Text = "Šifra:";
            this.label1IDSHEMAPLACA.StyleSetName = "FieldUltraLabel";
            this.label1IDSHEMAPLACA.AutoSize = true;
            this.label1IDSHEMAPLACA.Anchor = AnchorStyles.Left;
            this.label1IDSHEMAPLACA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDSHEMAPLACA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDSHEMAPLACA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDSHEMAPLACA.ImageSize = size;
            this.label1IDSHEMAPLACA.Appearance.ForeColor = Color.Black;
            this.label1IDSHEMAPLACA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACA.Controls.Add(this.label1IDSHEMAPLACA, 0, 0);
            this.layoutManagerformSHEMAPLACA.SetColumnSpan(this.label1IDSHEMAPLACA, 1);
            this.layoutManagerformSHEMAPLACA.SetRowSpan(this.label1IDSHEMAPLACA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDSHEMAPLACA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDSHEMAPLACA.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDSHEMAPLACA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDSHEMAPLACA.Location = point;
            this.textIDSHEMAPLACA.Name = "textIDSHEMAPLACA";
            this.textIDSHEMAPLACA.Tag = "IDSHEMAPLACA";
            this.textIDSHEMAPLACA.TabIndex = 0;
            this.textIDSHEMAPLACA.Anchor = AnchorStyles.Left;
            this.textIDSHEMAPLACA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDSHEMAPLACA.ReadOnly = false;
            this.textIDSHEMAPLACA.PromptChar = ' ';
            this.textIDSHEMAPLACA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDSHEMAPLACA.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAPLACA, "IDSHEMAPLACA"));
            this.textIDSHEMAPLACA.NumericType = NumericType.Integer;
            this.textIDSHEMAPLACA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformSHEMAPLACA.Controls.Add(this.textIDSHEMAPLACA, 1, 0);
            this.layoutManagerformSHEMAPLACA.SetColumnSpan(this.textIDSHEMAPLACA, 1);
            this.layoutManagerformSHEMAPLACA.SetRowSpan(this.textIDSHEMAPLACA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDSHEMAPLACA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSHEMAPLACA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDSHEMAPLACA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVSHEMAPLACA.Location = point;
            this.label1NAZIVSHEMAPLACA.Name = "label1NAZIVSHEMAPLACA";
            this.label1NAZIVSHEMAPLACA.TabIndex = 1;
            this.label1NAZIVSHEMAPLACA.Tag = "labelNAZIVSHEMAPLACA";
            this.label1NAZIVSHEMAPLACA.Text = "Naziv:";
            this.label1NAZIVSHEMAPLACA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVSHEMAPLACA.AutoSize = true;
            this.label1NAZIVSHEMAPLACA.Anchor = AnchorStyles.Left;
            this.label1NAZIVSHEMAPLACA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVSHEMAPLACA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVSHEMAPLACA.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACA.Controls.Add(this.label1NAZIVSHEMAPLACA, 0, 1);
            this.layoutManagerformSHEMAPLACA.SetColumnSpan(this.label1NAZIVSHEMAPLACA, 1);
            this.layoutManagerformSHEMAPLACA.SetRowSpan(this.label1NAZIVSHEMAPLACA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVSHEMAPLACA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVSHEMAPLACA.MinimumSize = size;
            size = new System.Drawing.Size(0x35, 0x17);
            this.label1NAZIVSHEMAPLACA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVSHEMAPLACA.Location = point;
            this.textNAZIVSHEMAPLACA.Name = "textNAZIVSHEMAPLACA";
            this.textNAZIVSHEMAPLACA.Tag = "NAZIVSHEMAPLACA";
            this.textNAZIVSHEMAPLACA.TabIndex = 0;
            this.textNAZIVSHEMAPLACA.Anchor = AnchorStyles.Left;
            this.textNAZIVSHEMAPLACA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVSHEMAPLACA.ReadOnly = false;
            this.textNAZIVSHEMAPLACA.DataBindings.Add(new Binding("Text", this.bindingSourceSHEMAPLACA, "NAZIVSHEMAPLACA"));
            this.textNAZIVSHEMAPLACA.MaxLength = 50;
            this.layoutManagerformSHEMAPLACA.Controls.Add(this.textNAZIVSHEMAPLACA, 1, 1);
            this.layoutManagerformSHEMAPLACA.SetColumnSpan(this.textNAZIVSHEMAPLACA, 1);
            this.layoutManagerformSHEMAPLACA.SetRowSpan(this.textNAZIVSHEMAPLACA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVSHEMAPLACA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVSHEMAPLACA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVSHEMAPLACA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1SHEMAPLOJIDORGJED.Location = point;
            this.label1SHEMAPLOJIDORGJED.Name = "label1SHEMAPLOJIDORGJED";
            this.label1SHEMAPLOJIDORGJED.TabIndex = 1;
            this.label1SHEMAPLOJIDORGJED.Tag = "labelSHEMAPLOJIDORGJED";
            this.label1SHEMAPLOJIDORGJED.Text = "Organiz. jed.:";
            this.label1SHEMAPLOJIDORGJED.StyleSetName = "FieldUltraLabel";
            this.label1SHEMAPLOJIDORGJED.AutoSize = true;
            this.label1SHEMAPLOJIDORGJED.Anchor = AnchorStyles.Left;
            this.label1SHEMAPLOJIDORGJED.Appearance.TextVAlign = VAlign.Middle;
            this.label1SHEMAPLOJIDORGJED.Appearance.ForeColor = Color.Black;
            this.label1SHEMAPLOJIDORGJED.BackColor = Color.Transparent;
            this.layoutManagerformSHEMAPLACA.Controls.Add(this.label1SHEMAPLOJIDORGJED, 0, 2);
            this.layoutManagerformSHEMAPLACA.SetColumnSpan(this.label1SHEMAPLOJIDORGJED, 1);
            this.layoutManagerformSHEMAPLACA.SetRowSpan(this.label1SHEMAPLOJIDORGJED, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SHEMAPLOJIDORGJED.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SHEMAPLOJIDORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x62, 0x17);
            this.label1SHEMAPLOJIDORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboSHEMAPLOJIDORGJED.Location = point;
            this.comboSHEMAPLOJIDORGJED.Name = "comboSHEMAPLOJIDORGJED";
            this.comboSHEMAPLOJIDORGJED.Tag = "SHEMAPLOJIDORGJED";
            this.comboSHEMAPLOJIDORGJED.TabIndex = 0;
            this.comboSHEMAPLOJIDORGJED.Anchor = AnchorStyles.Left;
            this.comboSHEMAPLOJIDORGJED.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboSHEMAPLOJIDORGJED.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAPLOJIDORGJED.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboSHEMAPLOJIDORGJED.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboSHEMAPLOJIDORGJED.Enabled = true;
            this.comboSHEMAPLOJIDORGJED.DataBindings.Add(new Binding("Value", this.bindingSourceSHEMAPLACA, "SHEMAPLOJIDORGJED"));
            this.comboSHEMAPLOJIDORGJED.ShowPictureBox = true;
            this.comboSHEMAPLOJIDORGJED.PictureBoxClicked += new EventHandler(this.PictureBoxClickedSHEMAPLOJIDORGJED);
            this.comboSHEMAPLOJIDORGJED.ValueMember = "IDORGJED";
            this.comboSHEMAPLOJIDORGJED.SelectionChanged += new EventHandler(this.SelectedIndexChangedSHEMAPLOJIDORGJED);
            this.layoutManagerformSHEMAPLACA.Controls.Add(this.comboSHEMAPLOJIDORGJED, 1, 2);
            this.layoutManagerformSHEMAPLACA.SetColumnSpan(this.comboSHEMAPLOJIDORGJED, 1);
            this.layoutManagerformSHEMAPLACA.SetRowSpan(this.comboSHEMAPLOJIDORGJED, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboSHEMAPLOJIDORGJED.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAPLOJIDORGJED.MinimumSize = size;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboSHEMAPLOJIDORGJED.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.Tab1.Location = point;
            this.Tab1.Name = "Tab1";
            this.layoutManagerformSHEMAPLACA.Controls.Add(this.Tab1, 0, 3);
            this.layoutManagerformSHEMAPLACA.SetColumnSpan(this.Tab1, 6);
            this.layoutManagerformSHEMAPLACA.SetRowSpan(this.Tab1, 3);
            padding = new Padding(5, 11, 5, 5);
            this.Tab1.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.Tab1.MinimumSize = size;
            this.Tab1.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.TabPage1.Location = point;
            this.TabPage1.Name = "TabPage1";
            tab.TabPage = this.TabPage1;
            tab.Text = "Kontiranje elemenata";
            this.TabPage1.Controls.Add(this.layoutManagerTabPage1);
            point = new System.Drawing.Point(0, 0);
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.Location = point;
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.Name = "grdLevelSHEMAPLACASHEMAPLACAELEMENT";
            this.layoutManagerTabPage1.Controls.Add(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT, 0, 0);
            this.layoutManagerTabPage1.SetColumnSpan(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT, 5);
            this.layoutManagerTabPage1.SetRowSpan(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT, 3);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0x2ae, 200);
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.Size = size;
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsSHEMAPLACASHEMAPLACAELEMENT.Location = point;
            this.panelactionsSHEMAPLACASHEMAPLACAELEMENT.Name = "panelactionsSHEMAPLACASHEMAPLACAELEMENT";
            this.panelactionsSHEMAPLACASHEMAPLACAELEMENT.BackColor = Color.Transparent;
            this.panelactionsSHEMAPLACASHEMAPLACAELEMENT.Controls.Add(this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT);
            this.layoutManagerTabPage1.Controls.Add(this.panelactionsSHEMAPLACASHEMAPLACAELEMENT, 0, 1);
            this.layoutManagerTabPage1.SetColumnSpan(this.panelactionsSHEMAPLACASHEMAPLACAELEMENT, 5);
            this.layoutManagerTabPage1.SetRowSpan(this.panelactionsSHEMAPLACASHEMAPLACAELEMENT, 3);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsSHEMAPLACASHEMAPLACAELEMENT.Margin = padding;
            size = new System.Drawing.Size(550, 0x19);
            this.panelactionsSHEMAPLACASHEMAPLACAELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(550, 0x19);
            this.panelactionsSHEMAPLACASHEMAPLACAELEMENT.Size = size;
            this.panelactionsSHEMAPLACASHEMAPLACAELEMENT.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd.Location = point;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd.Name = "linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd";
            size = new System.Drawing.Size(160, 15);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd.Size = size;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd.Text = " Add SHEMAPLACAELEMENT  ";
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd.Click += new EventHandler(this.SHEMAPLACASHEMAPLACAELEMENTAdd_Click);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd.BackColor = Color.Transparent;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd.Cursor = Cursors.Hand;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.Controls.Add(this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd, 0, 0);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.SetColumnSpan(this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd, 1);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.SetRowSpan(this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd.Margin = padding;
            size = new System.Drawing.Size(160, 15);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd.MinimumSize = size;
            size = new System.Drawing.Size(160, 15);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate.Location = point;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate.Name = "linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate";
            size = new System.Drawing.Size(0xb1, 15);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate.Size = size;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate.Text = " Update SHEMAPLACAELEMENT  ";
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate.Click += new EventHandler(this.SHEMAPLACASHEMAPLACAELEMENTUpdate_Click);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate.BackColor = Color.Transparent;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate.Cursor = Cursors.Hand;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.Controls.Add(this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate, 1, 0);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.SetColumnSpan(this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate, 1);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.SetRowSpan(this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate.Margin = padding;
            size = new System.Drawing.Size(0xb1, 15);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0xb1, 15);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete.Location = point;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete.Name = "linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete";
            size = new System.Drawing.Size(0xad, 15);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete.Size = size;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete.Text = " Delete SHEMAPLACAELEMENT  ";
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete.Click += new EventHandler(this.SHEMAPLACASHEMAPLACAELEMENTDelete_Click);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete.BackColor = Color.Transparent;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete.Cursor = Cursors.Hand;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.Controls.Add(this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete, 2, 0);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.SetColumnSpan(this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete, 1);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.SetRowSpan(this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete.Margin = padding;
            size = new System.Drawing.Size(0xad, 15);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete.MinimumSize = size;
            size = new System.Drawing.Size(0xad, 15);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENT.Location = point;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENT.Name = "linkLabelSHEMAPLACASHEMAPLACAELEMENT";
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.Controls.Add(this.linkLabelSHEMAPLACASHEMAPLACAELEMENT, 3, 0);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.SetColumnSpan(this.linkLabelSHEMAPLACASHEMAPLACAELEMENT, 1);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.SetRowSpan(this.linkLabelSHEMAPLACASHEMAPLACAELEMENT, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENT.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENT.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENT.Size = size;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENT.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.TabPage2.Location = point;
            this.TabPage2.Name = "TabPage2";
            tab2.TabPage = this.TabPage2;
            tab2.Text = "Kontiranje doprinosa";
            this.TabPage2.Controls.Add(this.layoutManagerTabPage2);
            point = new System.Drawing.Point(0, 0);
            this.grdLevelSHEMAPLACASHEMAPLACADOP.Location = point;
            this.grdLevelSHEMAPLACASHEMAPLACADOP.Name = "grdLevelSHEMAPLACASHEMAPLACADOP";
            this.layoutManagerTabPage2.Controls.Add(this.grdLevelSHEMAPLACASHEMAPLACADOP, 0, 0);
            this.layoutManagerTabPage2.SetColumnSpan(this.grdLevelSHEMAPLACASHEMAPLACADOP, 5);
            this.layoutManagerTabPage2.SetRowSpan(this.grdLevelSHEMAPLACASHEMAPLACADOP, 3);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelSHEMAPLACASHEMAPLACADOP.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelSHEMAPLACASHEMAPLACADOP.MinimumSize = size;
            size = new System.Drawing.Size(0x2ae, 200);
            this.grdLevelSHEMAPLACASHEMAPLACADOP.Size = size;
            this.grdLevelSHEMAPLACASHEMAPLACADOP.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsSHEMAPLACASHEMAPLACADOP.Location = point;
            this.panelactionsSHEMAPLACASHEMAPLACADOP.Name = "panelactionsSHEMAPLACASHEMAPLACADOP";
            this.panelactionsSHEMAPLACASHEMAPLACADOP.BackColor = Color.Transparent;
            this.panelactionsSHEMAPLACASHEMAPLACADOP.Controls.Add(this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP);
            this.layoutManagerTabPage2.Controls.Add(this.panelactionsSHEMAPLACASHEMAPLACADOP, 0, 1);
            this.layoutManagerTabPage2.SetColumnSpan(this.panelactionsSHEMAPLACASHEMAPLACADOP, 5);
            this.layoutManagerTabPage2.SetRowSpan(this.panelactionsSHEMAPLACASHEMAPLACADOP, 3);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsSHEMAPLACASHEMAPLACADOP.Margin = padding;
            size = new System.Drawing.Size(0x144, 0x19);
            this.panelactionsSHEMAPLACASHEMAPLACADOP.MinimumSize = size;
            size = new System.Drawing.Size(0x144, 0x19);
            this.panelactionsSHEMAPLACASHEMAPLACADOP.Size = size;
            this.panelactionsSHEMAPLACASHEMAPLACADOP.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd.Location = point;
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd.Name = "linkLabelSHEMAPLACASHEMAPLACADOPAdd";
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd.Size = size;
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd.Text = " Add Doprinosi  ";
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd.Click += new EventHandler(this.SHEMAPLACASHEMAPLACADOPAdd_Click);
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd.BackColor = Color.Transparent;
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd.Cursor = Cursors.Hand;
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.Controls.Add(this.linkLabelSHEMAPLACASHEMAPLACADOPAdd, 0, 0);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.SetColumnSpan(this.linkLabelSHEMAPLACASHEMAPLACADOPAdd, 1);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.SetRowSpan(this.linkLabelSHEMAPLACASHEMAPLACADOPAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd.Margin = padding;
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate.Location = point;
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate.Name = "linkLabelSHEMAPLACASHEMAPLACADOPUpdate";
            size = new System.Drawing.Size(0x66, 15);
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate.Size = size;
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate.Text = " Update Doprinosi  ";
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate.Click += new EventHandler(this.SHEMAPLACASHEMAPLACADOPUpdate_Click);
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate.BackColor = Color.Transparent;
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate.Cursor = Cursors.Hand;
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.Controls.Add(this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate, 1, 0);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.SetColumnSpan(this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate, 1);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.SetRowSpan(this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate.Margin = padding;
            size = new System.Drawing.Size(0x66, 15);
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 15);
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete.Location = point;
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete.Name = "linkLabelSHEMAPLACASHEMAPLACADOPDelete";
            size = new System.Drawing.Size(0x62, 15);
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete.Size = size;
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete.Text = " Delete Doprinosi  ";
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete.Click += new EventHandler(this.SHEMAPLACASHEMAPLACADOPDelete_Click);
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete.BackColor = Color.Transparent;
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete.Cursor = Cursors.Hand;
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.Controls.Add(this.linkLabelSHEMAPLACASHEMAPLACADOPDelete, 2, 0);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.SetColumnSpan(this.linkLabelSHEMAPLACASHEMAPLACADOPDelete, 1);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.SetRowSpan(this.linkLabelSHEMAPLACASHEMAPLACADOPDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete.Margin = padding;
            size = new System.Drawing.Size(0x62, 15);
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x62, 15);
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAPLACASHEMAPLACADOP.Location = point;
            this.linkLabelSHEMAPLACASHEMAPLACADOP.Name = "linkLabelSHEMAPLACASHEMAPLACADOP";
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.Controls.Add(this.linkLabelSHEMAPLACASHEMAPLACADOP, 3, 0);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.SetColumnSpan(this.linkLabelSHEMAPLACASHEMAPLACADOP, 1);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.SetRowSpan(this.linkLabelSHEMAPLACASHEMAPLACADOP, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAPLACASHEMAPLACADOP.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSHEMAPLACASHEMAPLACADOP.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSHEMAPLACASHEMAPLACADOP.Size = size;
            this.linkLabelSHEMAPLACASHEMAPLACADOP.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.TabPage3.Location = point;
            this.TabPage3.Name = "TabPage3";
            tab3.TabPage = this.TabPage3;
            tab3.Text = "Kontiranje ostalih iznosa";
            this.TabPage3.Controls.Add(this.layoutManagerTabPage3);
            point = new System.Drawing.Point(0, 0);
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.Location = point;
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.Name = "grdLevelSHEMAPLACASHEMAPLACASTANDARD";
            this.layoutManagerTabPage3.Controls.Add(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD, 0, 0);
            this.layoutManagerTabPage3.SetColumnSpan(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD, 3);
            this.layoutManagerTabPage3.SetRowSpan(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD, 2);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.MinimumSize = size;
            size = new System.Drawing.Size(0x2a7, 200);
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.Size = size;
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsSHEMAPLACASHEMAPLACASTANDARD.Location = point;
            this.panelactionsSHEMAPLACASHEMAPLACASTANDARD.Name = "panelactionsSHEMAPLACASHEMAPLACASTANDARD";
            this.panelactionsSHEMAPLACASHEMAPLACASTANDARD.BackColor = Color.Transparent;
            this.panelactionsSHEMAPLACASHEMAPLACASTANDARD.Controls.Add(this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD);
            this.layoutManagerTabPage3.Controls.Add(this.panelactionsSHEMAPLACASHEMAPLACASTANDARD, 0, 1);
            this.layoutManagerTabPage3.SetColumnSpan(this.panelactionsSHEMAPLACASHEMAPLACASTANDARD, 3);
            this.layoutManagerTabPage3.SetRowSpan(this.panelactionsSHEMAPLACASHEMAPLACASTANDARD, 2);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsSHEMAPLACASHEMAPLACASTANDARD.Margin = padding;
            size = new System.Drawing.Size(0x243, 0x19);
            this.panelactionsSHEMAPLACASHEMAPLACASTANDARD.MinimumSize = size;
            size = new System.Drawing.Size(0x243, 0x19);
            this.panelactionsSHEMAPLACASHEMAPLACASTANDARD.Size = size;
            this.panelactionsSHEMAPLACASHEMAPLACASTANDARD.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd.Location = point;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd.Name = "linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd";
            size = new System.Drawing.Size(0xa9, 15);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd.Size = size;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd.Text = " Add SHEMAPLACASTANDARD  ";
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd.Click += new EventHandler(this.SHEMAPLACASHEMAPLACASTANDARDAdd_Click);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd.BackColor = Color.Transparent;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd.Cursor = Cursors.Hand;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.Controls.Add(this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd, 0, 0);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.SetColumnSpan(this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd, 1);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.SetRowSpan(this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd.Margin = padding;
            size = new System.Drawing.Size(0xa9, 15);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd.MinimumSize = size;
            size = new System.Drawing.Size(0xa9, 15);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate.Location = point;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate.Name = "linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate";
            size = new System.Drawing.Size(0xbb, 15);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate.Size = size;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate.Text = " Update SHEMAPLACASTANDARD  ";
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate.Click += new EventHandler(this.SHEMAPLACASHEMAPLACASTANDARDUpdate_Click);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate.BackColor = Color.Transparent;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate.Cursor = Cursors.Hand;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.Controls.Add(this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate, 1, 0);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.SetColumnSpan(this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate, 1);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.SetRowSpan(this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate.Margin = padding;
            size = new System.Drawing.Size(0xbb, 15);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0xbb, 15);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete.Location = point;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete.Name = "linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete";
            size = new System.Drawing.Size(0xb7, 15);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete.Size = size;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete.Text = " Delete SHEMAPLACASTANDARD  ";
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete.Click += new EventHandler(this.SHEMAPLACASHEMAPLACASTANDARDDelete_Click);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete.BackColor = Color.Transparent;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete.Cursor = Cursors.Hand;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete.AutoSize = true;
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.Controls.Add(this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete, 2, 0);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.SetColumnSpan(this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete, 1);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.SetRowSpan(this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete.Margin = padding;
            size = new System.Drawing.Size(0xb7, 15);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete.MinimumSize = size;
            size = new System.Drawing.Size(0xb7, 15);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARD.Location = point;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARD.Name = "linkLabelSHEMAPLACASHEMAPLACASTANDARD";
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.Controls.Add(this.linkLabelSHEMAPLACASHEMAPLACASTANDARD, 3, 0);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.SetColumnSpan(this.linkLabelSHEMAPLACASHEMAPLACASTANDARD, 1);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.SetRowSpan(this.linkLabelSHEMAPLACASHEMAPLACASTANDARD, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARD.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARD.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARD.Size = size;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARD.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformSHEMAPLACA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceSHEMAPLACA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.Disabled;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.SHEMAPLACAIDSHEMAPLACADescription;
            column10.Width = 0x33;
            appearance7.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnn";
            column10.PromptChar = ' ';
            column10.Format = "";
            column10.CellAppearance = appearance7;
            column10.Hidden = true;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.SHEMAPLACASHEMAPLELEMENTIDELEMENTDescription;
            column15.Width = 0x70;
            column15.Format = "";
            column15.CellAppearance = appearance10;
            column15.Hidden = true;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.SHEMAPLACAKONTOELEMENTIDKONTODescription;
            column11.Width = 0x72;
            column11.Format = "";
            column11.CellAppearance = appearance8;
            column12.AllowGroupBy = DefaultableBoolean.False;
            column12.AutoSizeEdit = DefaultableBoolean.False;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column12.CellAppearance.BorderAlpha = Alpha.Transparent;
            column12.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column12.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column12.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column12.Header.Enabled = false;
            column12.Header.Fixed = true;
            column12.Header.Caption = "";
            column12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column12.Width = 20;
            column12.MinWidth = 20;
            column12.MaxWidth = 20;
            column12.Tag = "KONTOKONTOELEMENTIDKONTOAddNew";
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.SHEMAPLACASTRANEELEMENTIDSTRANEKNJIZENJADescription;
            column19.Width = 0x7e;
            column19.Format = "";
            column19.CellAppearance = appearance13;
            column20.AllowGroupBy = DefaultableBoolean.False;
            column20.AutoSizeEdit = DefaultableBoolean.False;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column20.CellAppearance.BorderAlpha = Alpha.Transparent;
            column20.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column20.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column20.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column20.Header.Enabled = false;
            column20.Header.Fixed = true;
            column20.Header.Caption = "";
            column20.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column20.Width = 20;
            column20.MinWidth = 20;
            column20.MaxWidth = 20;
            column20.Tag = "STRANEKNJIZENJASTRANEELEMENTIDSTRANEKNJIZENJAAddNew";
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.SHEMAPLACAMTELEMENTIDMJESTOTROSKADescription;
            column13.Width = 0x69;
            column13.Format = "";
            column13.CellAppearance = appearance9;
            column14.AllowGroupBy = DefaultableBoolean.False;
            column14.AutoSizeEdit = DefaultableBoolean.False;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column14.CellAppearance.BorderAlpha = Alpha.Transparent;
            column14.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column14.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column14.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column14.Header.Enabled = false;
            column14.Header.Fixed = true;
            column14.Header.Caption = "";
            column14.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column14.Width = 20;
            column14.MinWidth = 20;
            column14.MaxWidth = 20;
            column14.Tag = "MJESTOTROSKAMTELEMENTIDMJESTOTROSKAAddNew";
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.Disabled;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.SHEMAPLACASHEMAPLELEMENTNAZIVELEMENTDescription;
            column18.Width = 0x128;
            column18.Format = "";
            column18.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.Disabled;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.SHEMAPLACASHEMAPLELEMENTIDVRSTAELEMENTADescription;
            column17.Width = 0x99;
            appearance11.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnnn";
            column17.PromptChar = ' ';
            column17.Format = "";
            column17.CellAppearance = appearance11;
            column17.Hidden = true;
            band2.Columns.Add(column18);
            column18.Header.VisiblePosition = 0;
            band2.Columns.Add(column11);
            column11.Header.VisiblePosition = 1;
            band2.Columns.Add(column19);
            column19.Header.VisiblePosition = 2;
            band2.Columns.Add(column13);
            column13.Header.VisiblePosition = 3;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 4;
            band2.Columns.Add(column15);
            column15.Header.VisiblePosition = 5;
            band2.Columns.Add(column17);
            column17.Header.VisiblePosition = 6;
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.Visible = true;
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.Name = "grdLevelSHEMAPLACASHEMAPLACAELEMENT";
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.Tag = "SHEMAPLACASHEMAPLACAELEMENT";
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.TabIndex = 0x1c;
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.Dock = DockStyle.Fill;
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.DataSource = this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT;
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.Enter += new EventHandler(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT_Enter);
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.AfterRowInsert += new RowEventHandler(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT_AfterRowInsert);
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT_DoubleClick);
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.AfterRowActivate += new EventHandler(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT_AfterRowActivate);
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.DisplayLayout.BandsSerializer.Add(band2);
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.Disabled;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.SHEMAPLACAIDSHEMAPLACADescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            column.Hidden = true;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.SHEMAPLACASHEMAPLDOPIDDOPRINOSDescription;
            column6.Width = 0x77;
            appearance4.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnn";
            column6.PromptChar = ' ';
            column6.Format = "";
            column6.CellAppearance = appearance4;
            column6.Hidden = true;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.SHEMAPLACAKONTODOPIDKONTODescription;
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
            column4.Header.Caption = StringResources.SHEMAPLACAMTDOPIDMJESTOTROSKADescription;
            column4.Width = 0x69;
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
            column8.Header.Caption = StringResources.SHEMAPLACASTRANEDOPIDSTRANEKNJIZENJADescription;
            column8.Width = 0x7e;
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
            column7.Header.Caption = StringResources.SHEMAPLACASHEMAPLDOPNAZIVDOPRINOSDescription;
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
            this.grdLevelSHEMAPLACASHEMAPLACADOP.Visible = true;
            this.grdLevelSHEMAPLACASHEMAPLACADOP.Name = "grdLevelSHEMAPLACASHEMAPLACADOP";
            this.grdLevelSHEMAPLACASHEMAPLACADOP.Tag = "SHEMAPLACASHEMAPLACADOP";
            this.grdLevelSHEMAPLACASHEMAPLACADOP.TabIndex = 0x1c;
            this.grdLevelSHEMAPLACASHEMAPLACADOP.Dock = DockStyle.Fill;
            this.grdLevelSHEMAPLACASHEMAPLACADOP.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelSHEMAPLACASHEMAPLACADOP.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelSHEMAPLACASHEMAPLACADOP.DataSource = this.bindingSourceSHEMAPLACASHEMAPLACADOP;
            this.grdLevelSHEMAPLACASHEMAPLACADOP.Enter += new EventHandler(this.grdLevelSHEMAPLACASHEMAPLACADOP_Enter);
            this.grdLevelSHEMAPLACASHEMAPLACADOP.AfterRowInsert += new RowEventHandler(this.grdLevelSHEMAPLACASHEMAPLACADOP_AfterRowInsert);
            this.grdLevelSHEMAPLACASHEMAPLACADOP.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelSHEMAPLACASHEMAPLACADOP.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelSHEMAPLACASHEMAPLACADOP.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelSHEMAPLACASHEMAPLACADOP.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelSHEMAPLACASHEMAPLACADOP_DoubleClick);
            this.grdLevelSHEMAPLACASHEMAPLACADOP.AfterRowActivate += new EventHandler(this.grdLevelSHEMAPLACASHEMAPLACADOP_AfterRowActivate);
            this.grdLevelSHEMAPLACASHEMAPLACADOP.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelSHEMAPLACASHEMAPLACADOP.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelSHEMAPLACASHEMAPLACADOP.DisplayLayout.BandsSerializer.Add(band);
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.Disabled;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.SHEMAPLACAIDSHEMAPLACADescription;
            column23.Width = 0x33;
            appearance15.TextHAlign = HAlign.Right;
            column23.MaskInput = "{LOC}-nnnnn";
            column23.PromptChar = ' ';
            column23.Format = "";
            column23.CellAppearance = appearance15;
            column23.Hidden = true;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.SHEMAPLACASHEMAPLACASTANDARDIDDescription;
            column29.Width = 0x10c;
            column29.Format = "";
            column29.CellAppearance = appearance19;
            column29.Hidden = true;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.SHEMAPLACAIDPLVRSTEIZNOSADescription;
            column21.Width = 0x63;
            column21.Format = "";
            column21.CellAppearance = appearance14;
            column21.Hidden = true;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.SHEMAPLACAKONTOPLACAVRSTAIZNOSAIDKONTODescription;
            column24.Width = 0x72;
            column24.Format = "";
            column24.CellAppearance = appearance16;
            column25.AllowGroupBy = DefaultableBoolean.False;
            column25.AutoSizeEdit = DefaultableBoolean.False;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column25.CellAppearance.BorderAlpha = Alpha.Transparent;
            column25.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column25.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column25.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column25.Header.Enabled = false;
            column25.Header.Fixed = true;
            column25.Header.Caption = "";
            column25.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column25.Width = 20;
            column25.MinWidth = 20;
            column25.MaxWidth = 20;
            column25.Tag = "KONTOKONTOPLACAVRSTAIZNOSAIDKONTOAddNew";
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.SHEMAPLACAMTPLACAVRSTAIZNOSAIDMJESTOTROSKADescription;
            column26.Width = 0x69;
            column26.Format = "";
            column26.CellAppearance = appearance17;
            column27.AllowGroupBy = DefaultableBoolean.False;
            column27.AutoSizeEdit = DefaultableBoolean.False;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column27.CellAppearance.BorderAlpha = Alpha.Transparent;
            column27.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column27.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column27.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column27.Header.Enabled = false;
            column27.Header.Fixed = true;
            column27.Header.Caption = "";
            column27.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column27.Width = 20;
            column27.MinWidth = 20;
            column27.MaxWidth = 20;
            column27.Tag = "MJESTOTROSKAMTPLACAVRSTAIZNOSAIDMJESTOTROSKAAddNew";
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.SHEMAPLACASTRANEVRSTEIZNOSAIDSTRANEKNJIZENJADescription;
            column30.Width = 0x77;
            column30.Format = "";
            column30.CellAppearance = appearance20;
            column31.AllowGroupBy = DefaultableBoolean.False;
            column31.AutoSizeEdit = DefaultableBoolean.False;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            column31.CellAppearance.BorderAlpha = Alpha.Transparent;
            column31.CellButtonAppearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("newImage"));
            column31.Header.Appearance.BorderAlpha = Alpha.Transparent;
            column31.Header.Appearance.ThemedElementAlpha = Alpha.Transparent;
            column31.Header.Enabled = false;
            column31.Header.Fixed = true;
            column31.Header.Caption = "";
            column31.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            column31.Width = 20;
            column31.MinWidth = 20;
            column31.MaxWidth = 20;
            column31.Tag = "STRANEKNJIZENJASTRANEVRSTEIZNOSAIDSTRANEKNJIZENJAAddNew";
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.Disabled;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.SHEMAPLACANAZIVPLVRSTEIZNOSADescription;
            column28.Width = 0x128;
            column28.Format = "";
            column28.CellAppearance = appearance18;
            band3.Columns.Add(column28);
            column28.Header.VisiblePosition = 0;
            band3.Columns.Add(column24);
            column24.Header.VisiblePosition = 1;
            band3.Columns.Add(column30);
            column30.Header.VisiblePosition = 2;
            band3.Columns.Add(column26);
            column26.Header.VisiblePosition = 3;
            band3.Columns.Add(column23);
            column23.Header.VisiblePosition = 4;
            band3.Columns.Add(column29);
            column29.Header.VisiblePosition = 5;
            band3.Columns.Add(column21);
            column21.Header.VisiblePosition = 6;
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.Visible = true;
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.Name = "grdLevelSHEMAPLACASHEMAPLACASTANDARD";
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.Tag = "SHEMAPLACASHEMAPLACASTANDARD";
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.TabIndex = 0x1c;
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.Dock = DockStyle.Fill;
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.DataSource = this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD;
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.Enter += new EventHandler(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD_Enter);
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.AfterRowInsert += new RowEventHandler(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD_AfterRowInsert);
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD_DoubleClick);
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.AfterRowActivate += new EventHandler(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD_AfterRowActivate);
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.DisplayLayout.BandsSerializer.Add(band3);
            this.Name = "SHEMAPLACAFormUserControl";
            this.Text = "Shema place";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.SHEMAPLACAFormUserControl_Load);
            this.layoutManagerformSHEMAPLACA.ResumeLayout(false);
            this.layoutManagerformSHEMAPLACA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceSHEMAPLACA).EndInit();
            ((ISupportInitialize) this.bindingSourceSHEMAPLACASHEMAPLACADOP).EndInit();
            ((ISupportInitialize) this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT).EndInit();
            ((ISupportInitialize) this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD).EndInit();
            ((ISupportInitialize) this.textIDSHEMAPLACA).EndInit();
            ((ISupportInitialize) this.textNAZIVSHEMAPLACA).EndInit();
            ((ISupportInitialize) this.grdLevelSHEMAPLACASHEMAPLACAELEMENT).EndInit();
            this.panelactionsSHEMAPLACASHEMAPLACAELEMENT.ResumeLayout(true);
            this.panelactionsSHEMAPLACASHEMAPLACAELEMENT.PerformLayout();
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.ResumeLayout(false);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACAELEMENT.PerformLayout();
            this.layoutManagerTabPage1.ResumeLayout(false);
            this.layoutManagerTabPage1.PerformLayout();
            ((ISupportInitialize) this.grdLevelSHEMAPLACASHEMAPLACADOP).EndInit();
            this.panelactionsSHEMAPLACASHEMAPLACADOP.ResumeLayout(true);
            this.panelactionsSHEMAPLACASHEMAPLACADOP.PerformLayout();
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.ResumeLayout(false);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACADOP.PerformLayout();
            this.layoutManagerTabPage2.ResumeLayout(false);
            this.layoutManagerTabPage2.PerformLayout();
            ((ISupportInitialize) this.grdLevelSHEMAPLACASHEMAPLACASTANDARD).EndInit();
            this.panelactionsSHEMAPLACASHEMAPLACASTANDARD.ResumeLayout(true);
            this.panelactionsSHEMAPLACASHEMAPLACASTANDARD.PerformLayout();
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.ResumeLayout(false);
            this.layoutManagerpanelactionsSHEMAPLACASHEMAPLACASTANDARD.PerformLayout();
            this.layoutManagerTabPage3.ResumeLayout(false);
            this.layoutManagerTabPage3.PerformLayout();
            this.Tab1.ResumeLayout(true);
            this.Tab1.PerformLayout();
            ((ISupportInitialize) this.Tab1).EndInit();
            this.dsSHEMAPLACADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.SHEMAPLACAController.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAPLACA, this.SHEMAPLACAController.WorkItem, this))
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
            this.label1IDSHEMAPLACA.Text = StringResources.SHEMAPLACAIDSHEMAPLACADescription;
            this.label1NAZIVSHEMAPLACA.Text = StringResources.SHEMAPLACANAZIVSHEMAPLACADescription;
            this.label1SHEMAPLOJIDORGJED.Text = StringResources.SHEMAPLACASHEMAPLOJIDORGJEDDescription;
            this.TabPage1.Tab.Text = StringResources.SHEMAPLACASHEMAPLACATabPage1TabDescription;
            this.TabPage2.Tab.Text = StringResources.SHEMAPLACASHEMAPLACATabPage2TabDescription;
            this.TabPage3.Tab.Text = StringResources.SHEMAPLACASHEMAPLACATabPage3TabDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedInLinesKONTODOPIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesKONTOELEMENTIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesKONTOPLACAVRSTAIZNOSAIDKONTO(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("KONTO", null, DeklaritMode.Insert));
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

        private void PictureBoxClickedInLinesMTELEMENTIDMJESTOTROSKA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("MJESTOTROSKA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesMTPLACAVRSTAIZNOSAIDMJESTOTROSKA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("MJESTOTROSKA", null, DeklaritMode.Insert));
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

        private void PictureBoxClickedInLinesSTRANEELEMENTIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRANEKNJIZENJA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedInLinesSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("STRANEKNJIZENJA", null, DeklaritMode.Insert));
            }
        }

        private void PictureBoxClickedSHEMAPLOJIDORGJED(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("ORGJED", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.SHEMAPLACAController.WorkItem.Items.Contains("SHEMAPLACA|SHEMAPLACA"))
            {
                this.SHEMAPLACAController.WorkItem.Items.Add(this.bindingSourceSHEMAPLACA, "SHEMAPLACA|SHEMAPLACA");
            }
            if (!this.SHEMAPLACAController.WorkItem.Items.Contains("SHEMAPLACA|SHEMAPLACASHEMAPLACADOP"))
            {
                this.SHEMAPLACAController.WorkItem.Items.Add(this.bindingSourceSHEMAPLACASHEMAPLACADOP, "SHEMAPLACA|SHEMAPLACASHEMAPLACADOP");
            }
            if (!this.SHEMAPLACAController.WorkItem.Items.Contains("SHEMAPLACA|SHEMAPLACASHEMAPLACAELEMENT"))
            {
                this.SHEMAPLACAController.WorkItem.Items.Add(this.bindingSourceSHEMAPLACASHEMAPLACAELEMENT, "SHEMAPLACA|SHEMAPLACASHEMAPLACAELEMENT");
            }
            if (!this.SHEMAPLACAController.WorkItem.Items.Contains("SHEMAPLACA|SHEMAPLACASHEMAPLACASTANDARD"))
            {
                this.SHEMAPLACAController.WorkItem.Items.Add(this.bindingSourceSHEMAPLACASHEMAPLACASTANDARD, "SHEMAPLACA|SHEMAPLACASHEMAPLACASTANDARD");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsSHEMAPLACADataSet1.SHEMAPLACA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.SHEMAPLACAController.Update(this);
            }
        }

        [LocalCommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (this.InValidState() && this.SHEMAPLACAController.Update(this))
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [LocalCommandHandler("SaveAndNew")]
        public void SaveAndNew(object sender, EventArgs e)
        {
            if (this.InValidState() && this.SHEMAPLACAController.Update(this))
            {
                this.SHEMAPLACAController.DataSet = new SHEMAPLACADataSet();
                DataSetUtil.AddEmptyRow(this.SHEMAPLACAController.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.SHEMAPLACAController.DataSet.SHEMAPLACA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedSHEMAPLOJIDORGJED(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboSHEMAPLOJIDORGJED.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboSHEMAPLOJIDORGJED.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceSHEMAPLACA.Current).Row["SHEMAPLOJIDORGJED"] = RuntimeHelpers.GetObjectValue(row["IDORGJED"]);
                    this.bindingSourceSHEMAPLACA.ResetCurrentItem();
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
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT, "KONTOKONTOELEMENTIDKONTO", enumList, "IDKONTO", "KONT", false);
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT, "KONTOELEMENTIDKONTO");
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            gridColumn.ValueList = this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.DisplayLayout.ValueLists["KONTOKONTOELEMENTIDKONTO"];
            gridColumn.Width = 370;
            DataSet set6 = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(set6);
            }
            DataView view6 = new DataView(set6.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT, "STRANEKNJIZENJASTRANEELEMENTIDSTRANEKNJIZENJA", view6, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA", false);
            UltraGridColumn column6 = FormHelperClass.GetGridColumn(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT, "STRANEELEMENTIDSTRANEKNJIZENJA");
            column6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column6.ValueList = this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.DisplayLayout.ValueLists["STRANEKNJIZENJASTRANEELEMENTIDSTRANEKNJIZENJA"];
            column6.Width = 280;
            DataSet set5 = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(set5);
            }
            DataView view5 = new DataView(set5.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT, "MJESTOTROSKAMTELEMENTIDMJESTOTROSKA", view5, "IDMJESTOTROSKA", "mt", false);
            UltraGridColumn column5 = FormHelperClass.GetGridColumn(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT, "MTELEMENTIDMJESTOTROSKA");
            column5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column5.ValueList = this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.DisplayLayout.ValueLists["MJESTOTROSKAMTELEMENTIDMJESTOTROSKA"];
            column5.Width = 370;
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
            DataSet set = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set);
            }
            DataView view = new DataView(set.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACADOP, "KONTOKONTODOPIDKONTO", view, "IDKONTO", "KONT", false);
            UltraGridColumn column = FormHelperClass.GetGridColumn(this.grdLevelSHEMAPLACASHEMAPLACADOP, "KONTODOPIDKONTO");
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column.ValueList = this.grdLevelSHEMAPLACASHEMAPLACADOP.DisplayLayout.ValueLists["KONTOKONTODOPIDKONTO"];
            column.Width = 370;
            DataSet set2 = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(set2);
            }
            DataView view2 = new DataView(set2.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACADOP, "MJESTOTROSKAMTDOPIDMJESTOTROSKA", view2, "IDMJESTOTROSKA", "mt", false);
            UltraGridColumn column2 = FormHelperClass.GetGridColumn(this.grdLevelSHEMAPLACASHEMAPLACADOP, "MTDOPIDMJESTOTROSKA");
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column2.ValueList = this.grdLevelSHEMAPLACASHEMAPLACADOP.DisplayLayout.ValueLists["MJESTOTROSKAMTDOPIDMJESTOTROSKA"];
            column2.Width = 370;
            DataSet set3 = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(set3);
            }
            DataView view3 = new DataView(set3.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACADOP, "STRANEKNJIZENJASTRANEDOPIDSTRANEKNJIZENJA", view3, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA", false);
            UltraGridColumn column3 = FormHelperClass.GetGridColumn(this.grdLevelSHEMAPLACASHEMAPLACADOP, "STRANEDOPIDSTRANEKNJIZENJA");
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column3.ValueList = this.grdLevelSHEMAPLACASHEMAPLACADOP.DisplayLayout.ValueLists["STRANEKNJIZENJASTRANEDOPIDSTRANEKNJIZENJA"];
            column3.Width = 280;
            this.grdLevelSHEMAPLACASHEMAPLACADOP.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelSHEMAPLACASHEMAPLACADOP.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
            DataSet set7 = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(set7);
            }
            DataView view7 = new DataView(set7.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD, "KONTOKONTOPLACAVRSTAIZNOSAIDKONTO", view7, "IDKONTO", "KONT", false);
            UltraGridColumn column7 = FormHelperClass.GetGridColumn(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD, "KONTOPLACAVRSTAIZNOSAIDKONTO");
            column7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column7.ValueList = this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.DisplayLayout.ValueLists["KONTOKONTOPLACAVRSTAIZNOSAIDKONTO"];
            column7.Width = 370;
            DataSet set8 = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(set8);
            }
            DataView view8 = new DataView(set8.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD, "MJESTOTROSKAMTPLACAVRSTAIZNOSAIDMJESTOTROSKA", view8, "IDMJESTOTROSKA", "mt", false);
            UltraGridColumn column8 = FormHelperClass.GetGridColumn(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD, "MTPLACAVRSTAIZNOSAIDMJESTOTROSKA");
            column8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column8.ValueList = this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.DisplayLayout.ValueLists["MJESTOTROSKAMTPLACAVRSTAIZNOSAIDMJESTOTROSKA"];
            column8.Width = 370;
            DataSet set9 = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(set9);
            }
            DataView view9 = new DataView(set9.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD, "STRANEKNJIZENJASTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA", view9, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA", false);
            UltraGridColumn column9 = FormHelperClass.GetGridColumn(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD, "STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA");
            column9.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            column9.ValueList = this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.DisplayLayout.ValueLists["STRANEKNJIZENJASTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"];
            column9.Width = 280;
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.BeforeCellActivate += new CancelableCellEventHandler(this.grd_BeforeCellActivate);
            this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.CellListSelect += new CellEventHandler(this.grd_CellListSelect);
        }

        private void SetFocusInFirstField()
        {
            this.textIDSHEMAPLACA.Focus();
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

        private void SHEMAPLACAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.SHEMAPLACADescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.SHEMAPLACASHEMAPLACASHEMAPLACAELEMENTLevelDescription;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.SHEMAPLACASHEMAPLACASHEMAPLACAELEMENTLevelDescription;
            this.linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.SHEMAPLACASHEMAPLACASHEMAPLACAELEMENTLevelDescription;
            this.linkLabelSHEMAPLACASHEMAPLACADOPAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.SHEMAPLACASHEMAPLACASHEMAPLACADOPLevelDescription;
            this.linkLabelSHEMAPLACASHEMAPLACADOPUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.SHEMAPLACASHEMAPLACASHEMAPLACADOPLevelDescription;
            this.linkLabelSHEMAPLACASHEMAPLACADOPDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.SHEMAPLACASHEMAPLACASHEMAPLACADOPLevelDescription;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.SHEMAPLACASHEMAPLACASHEMAPLACASTANDARDLevelDescription;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.SHEMAPLACASHEMAPLACASHEMAPLACASTANDARDLevelDescription;
            this.linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.SHEMAPLACASHEMAPLACASHEMAPLACASTANDARDLevelDescription;
        }

        private void SHEMAPLACASHEMAPLACADOPAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelSHEMAPLACASHEMAPLACADOP.ActiveRow;
            this.SHEMAPLACASHEMAPLACADOPInsert();
        }

        private void SHEMAPLACASHEMAPLACADOPDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelSHEMAPLACASHEMAPLACADOP);
            if ((currentRowListIndex != -1) && (this.grdLevelSHEMAPLACASHEMAPLACADOP.Selected.Rows.Count > 0))
            {
                this.grdLevelSHEMAPLACASHEMAPLACADOP.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelSHEMAPLACASHEMAPLACADOP).Selected = true;
                this.grdLevelSHEMAPLACASHEMAPLACADOP.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SHEMAPLACASHEMAPLACADOPInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAPLACA, this.SHEMAPLACAController.WorkItem, this))
            {
                this.SHEMAPLACAController.AddSHEMAPLACASHEMAPLACADOP(this.m_CurrentRow);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void SHEMAPLACASHEMAPLACADOPKONTODOPIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACADOP, "KONTOKONTODOPIDKONTO", enumList, "IDKONTO", "KONT", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/MJESTOTROSKA", Thread=ThreadOption.UserInterface)]
        public void SHEMAPLACASHEMAPLACADOPMTDOPIDMJESTOTROSKA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACADOP, "MJESTOTROSKAMTDOPIDMJESTOTROSKA", enumList, "IDMJESTOTROSKA", "mt", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRANEKNJIZENJA", Thread=ThreadOption.UserInterface)]
        public void SHEMAPLACASHEMAPLACADOPSTRANEDOPIDSTRANEKNJIZENJA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACADOP, "STRANEKNJIZENJASTRANEDOPIDSTRANEKNJIZENJA", enumList, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA", true);
        }

        private void SHEMAPLACASHEMAPLACADOPUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelSHEMAPLACASHEMAPLACADOP) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelSHEMAPLACASHEMAPLACADOP);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.SHEMAPLACAController.UpdateSHEMAPLACASHEMAPLACADOP(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SHEMAPLACASHEMAPLACADOPUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelSHEMAPLACASHEMAPLACADOP.ActiveRow != null)
            {
                this.SHEMAPLACASHEMAPLACADOPUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SHEMAPLACASHEMAPLACAELEMENTAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.ActiveRow;
            this.SHEMAPLACASHEMAPLACAELEMENTInsert();
        }

        private void SHEMAPLACASHEMAPLACAELEMENTDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT);
            if ((currentRowListIndex != -1) && (this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.Selected.Rows.Count > 0))
            {
                this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT).Selected = true;
                this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SHEMAPLACASHEMAPLACAELEMENTInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAPLACA, this.SHEMAPLACAController.WorkItem, this))
            {
                this.SHEMAPLACAController.AddSHEMAPLACASHEMAPLACAELEMENT(this.m_CurrentRow);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void SHEMAPLACASHEMAPLACAELEMENTKONTOELEMENTIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT, "KONTOKONTOELEMENTIDKONTO", enumList, "IDKONTO", "KONT", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/MJESTOTROSKA", Thread=ThreadOption.UserInterface)]
        public void SHEMAPLACASHEMAPLACAELEMENTMTELEMENTIDMJESTOTROSKA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT, "MJESTOTROSKAMTELEMENTIDMJESTOTROSKA", enumList, "IDMJESTOTROSKA", "mt", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRANEKNJIZENJA", Thread=ThreadOption.UserInterface)]
        public void SHEMAPLACASHEMAPLACAELEMENTSTRANEELEMENTIDSTRANEKNJIZENJA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT, "STRANEKNJIZENJASTRANEELEMENTIDSTRANEKNJIZENJA", enumList, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA", true);
        }

        private void SHEMAPLACASHEMAPLACAELEMENTUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelSHEMAPLACASHEMAPLACAELEMENT);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.SHEMAPLACAController.UpdateSHEMAPLACASHEMAPLACAELEMENT(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SHEMAPLACASHEMAPLACAELEMENTUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelSHEMAPLACASHEMAPLACAELEMENT.ActiveRow != null)
            {
                this.SHEMAPLACASHEMAPLACAELEMENTUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SHEMAPLACASHEMAPLACASTANDARDAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.ActiveRow;
            this.SHEMAPLACASHEMAPLACASTANDARDInsert();
        }

        private void SHEMAPLACASHEMAPLACASTANDARDDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD);
            if ((currentRowListIndex != -1) && (this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.Selected.Rows.Count > 0))
            {
                this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD).Selected = true;
                this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SHEMAPLACASHEMAPLACASTANDARDInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceSHEMAPLACA, this.SHEMAPLACAController.WorkItem, this))
            {
                this.SHEMAPLACAController.AddSHEMAPLACASHEMAPLACASTANDARD(this.m_CurrentRow);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/KONTO", Thread=ThreadOption.UserInterface)]
        public void SHEMAPLACASHEMAPLACASTANDARDKONTOPLACAVRSTAIZNOSAIDKONTO_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new KONTODataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetKONTODataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["KONTO"]) {
                Sort = "KONT"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD, "KONTOKONTOPLACAVRSTAIZNOSAIDKONTO", enumList, "IDKONTO", "KONT", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/MJESTOTROSKA", Thread=ThreadOption.UserInterface)]
        public void SHEMAPLACASHEMAPLACASTANDARDMTPLACAVRSTAIZNOSAIDMJESTOTROSKA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new MJESTOTROSKADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetMJESTOTROSKADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["MJESTOTROSKA"]) {
                Sort = "mt"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD, "MJESTOTROSKAMTPLACAVRSTAIZNOSAIDMJESTOTROSKA", enumList, "IDMJESTOTROSKA", "mt", true);
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/STRANEKNJIZENJA", Thread=ThreadOption.UserInterface)]
        public void SHEMAPLACASHEMAPLACASTANDARDSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA_Add(object sender, ComponentEventArgs e)
        {
            DataSet dataSet = new STRANEKNJIZENJADataSet();
            if (DataAdapterFactory.Provider != null)
            {
                DataAdapterFactory.GetSTRANEKNJIZENJADataAdapter().Fill(dataSet);
            }
            DataView enumList = new DataView(dataSet.Tables["STRANEKNJIZENJA"]) {
                Sort = "NAZIVSTRANEKNJIZENJA"
            };
            CreateValueList(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD, "STRANEKNJIZENJASTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA", enumList, "IDSTRANEKNJIZENJA", "NAZIVSTRANEKNJIZENJA", true);
        }

        private void SHEMAPLACASHEMAPLACASTANDARDUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelSHEMAPLACASHEMAPLACASTANDARD);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.SHEMAPLACAController.UpdateSHEMAPLACASHEMAPLACASTANDARD(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void SHEMAPLACASHEMAPLACASTANDARDUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelSHEMAPLACASHEMAPLACASTANDARD.ActiveRow != null)
            {
                this.SHEMAPLACASHEMAPLACASTANDARDUpdate();
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

        private void UpdateValuesKONTOELEMENTIDKONTO(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["KONTOELEMENTIDKONTO"] = RuntimeHelpers.GetObjectValue(result["IDKONTO"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                    
                }
            }
        }

        private void UpdateValuesKONTOPLACAVRSTAIZNOSAIDKONTO(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["KONTOPLACAVRSTAIZNOSAIDKONTO"] = RuntimeHelpers.GetObjectValue(result["IDKONTO"]);
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

        private void UpdateValuesMTELEMENTIDMJESTOTROSKA(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["MTELEMENTIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(result["IDMJESTOTROSKA"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                }
            }
        }

        private void UpdateValuesMTPLACAVRSTAIZNOSAIDMJESTOTROSKA(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["MTPLACAVRSTAIZNOSAIDMJESTOTROSKA"] = RuntimeHelpers.GetObjectValue(result["IDMJESTOTROSKA"]);
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

        private void UpdateValuesSTRANEELEMENTIDSTRANEKNJIZENJA(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["STRANEELEMENTIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(result["IDSTRANEKNJIZENJA"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                }
            }
        }

        private void UpdateValuesSTRANEVRSTEIZNOSAIDSTRANEKNJIZENJA(object sender, CellEventArgs e, DataRow result)
        {
            DataRow row = ((DataRowView) e.Cell.Row.ListObject).Row;
            if (result != null)
            {
                try
                {
                    row["STRANEVRSTEIZNOSAIDSTRANEKNJIZENJA"] = RuntimeHelpers.GetObjectValue(result["IDSTRANEKNJIZENJA"]);
                }
                catch (ConstraintException exception1)
                {
                    throw exception1;
                    //ConstraintException exception = exception1;
                    //MessageBox.Show(exception.Message, "Data Error");
                }
            }
        }

        protected virtual ORGJEDComboBox comboSHEMAPLOJIDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboSHEMAPLOJIDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboSHEMAPLOJIDORGJED = value;
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

        protected virtual UltraGrid grdLevelSHEMAPLACASHEMAPLACADOP
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelSHEMAPLACASHEMAPLACADOP;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelSHEMAPLACASHEMAPLACADOP = value;
            }
        }

        protected virtual UltraGrid grdLevelSHEMAPLACASHEMAPLACAELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelSHEMAPLACASHEMAPLACAELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelSHEMAPLACASHEMAPLACAELEMENT = value;
            }
        }

        protected virtual UltraGrid grdLevelSHEMAPLACASHEMAPLACASTANDARD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelSHEMAPLACASHEMAPLACASTANDARD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelSHEMAPLACASHEMAPLACASTANDARD = value;
            }
        }

        protected virtual UltraLabel label1IDSHEMAPLACA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDSHEMAPLACA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDSHEMAPLACA = value;
            }
        }

        protected virtual UltraLabel label1NAZIVSHEMAPLACA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVSHEMAPLACA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVSHEMAPLACA = value;
            }
        }

        protected virtual UltraLabel label1SHEMAPLOJIDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SHEMAPLOJIDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SHEMAPLOJIDORGJED = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAPLACASHEMAPLACADOP
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAPLACASHEMAPLACADOP;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAPLACASHEMAPLACADOP = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAPLACASHEMAPLACADOPAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAPLACASHEMAPLACADOPAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAPLACASHEMAPLACADOPAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAPLACASHEMAPLACADOPDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAPLACASHEMAPLACADOPDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAPLACASHEMAPLACADOPDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAPLACASHEMAPLACADOPUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAPLACASHEMAPLACADOPUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAPLACASHEMAPLACADOPUpdate = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAPLACASHEMAPLACAELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAPLACASHEMAPLACAELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAPLACASHEMAPLACAELEMENT = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAPLACASHEMAPLACAELEMENTAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAPLACASHEMAPLACAELEMENTDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAPLACASHEMAPLACAELEMENTUpdate = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAPLACASHEMAPLACASTANDARD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAPLACASHEMAPLACASTANDARD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAPLACASHEMAPLACASTANDARD = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAPLACASHEMAPLACASTANDARDAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAPLACASHEMAPLACASTANDARDDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelSHEMAPLACASHEMAPLACASTANDARDUpdate = value;
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

        protected virtual Panel panelactionsSHEMAPLACASHEMAPLACADOP
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsSHEMAPLACASHEMAPLACADOP;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsSHEMAPLACASHEMAPLACADOP = value;
            }
        }

        protected virtual Panel panelactionsSHEMAPLACASHEMAPLACAELEMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsSHEMAPLACASHEMAPLACAELEMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsSHEMAPLACASHEMAPLACAELEMENT = value;
            }
        }

        protected virtual Panel panelactionsSHEMAPLACASHEMAPLACASTANDARD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsSHEMAPLACASHEMAPLACASTANDARD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsSHEMAPLACASHEMAPLACASTANDARD = value;
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
        public NetAdvantage.Controllers.SHEMAPLACAController SHEMAPLACAController { get; set; }

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

        protected virtual UltraTabPageControl TabPage3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._TabPage3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._TabPage3 = value;
            }
        }

        protected virtual UltraNumericEditor textIDSHEMAPLACA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDSHEMAPLACA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDSHEMAPLACA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVSHEMAPLACA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVSHEMAPLACA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVSHEMAPLACA = value;
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

