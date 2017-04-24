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
    public class DDKATEGORIJAFormUserControl : UserControl, IBusinessComponentUserControl
    {
        [AccessedThroughProperty("comboIDKOLONAIDD")]
        private DDKOLONAIDDComboBox _comboIDKOLONAIDD;
        [AccessedThroughProperty("contextMenu1")]
        private ContextMenu _contextMenu1;
        [AccessedThroughProperty("errorProvider1")]
        private ErrorProvider _errorProvider1;
        [AccessedThroughProperty("errorProviderValidator1")]
        private ErrorProviderValidator _errorProviderValidator1;
        [AccessedThroughProperty("grdLevelDDKATEGORIJAIzdaci")]
        private UltraGrid _grdLevelDDKATEGORIJAIzdaci;
        [AccessedThroughProperty("grdLevelDDKATEGORIJALevel1")]
        private UltraGrid _grdLevelDDKATEGORIJALevel1;
        [AccessedThroughProperty("grdLevelDDKATEGORIJALevel3")]
        private UltraGrid _grdLevelDDKATEGORIJALevel3;
        [AccessedThroughProperty("label1IDKATEGORIJA")]
        private UltraLabel _label1IDKATEGORIJA;
        [AccessedThroughProperty("label1IDKOLONAIDD")]
        private UltraLabel _label1IDKOLONAIDD;
        [AccessedThroughProperty("label1NAZIVKATEGORIJA")]
        private UltraLabel _label1NAZIVKATEGORIJA;
        [AccessedThroughProperty("linkLabelDDKATEGORIJAIzdaci")]
        private UltraLabel _linkLabelDDKATEGORIJAIzdaci;
        [AccessedThroughProperty("linkLabelDDKATEGORIJAIzdaciAdd")]
        private UltraLabel _linkLabelDDKATEGORIJAIzdaciAdd;
        [AccessedThroughProperty("linkLabelDDKATEGORIJAIzdaciDelete")]
        private UltraLabel _linkLabelDDKATEGORIJAIzdaciDelete;
        [AccessedThroughProperty("linkLabelDDKATEGORIJAIzdaciUpdate")]
        private UltraLabel _linkLabelDDKATEGORIJAIzdaciUpdate;
        [AccessedThroughProperty("linkLabelDDKATEGORIJALevel1")]
        private UltraLabel _linkLabelDDKATEGORIJALevel1;
        [AccessedThroughProperty("linkLabelDDKATEGORIJALevel1Add")]
        private UltraLabel _linkLabelDDKATEGORIJALevel1Add;
        [AccessedThroughProperty("linkLabelDDKATEGORIJALevel1Delete")]
        private UltraLabel _linkLabelDDKATEGORIJALevel1Delete;
        [AccessedThroughProperty("linkLabelDDKATEGORIJALevel1Update")]
        private UltraLabel _linkLabelDDKATEGORIJALevel1Update;
        [AccessedThroughProperty("linkLabelDDKATEGORIJALevel3")]
        private UltraLabel _linkLabelDDKATEGORIJALevel3;
        [AccessedThroughProperty("linkLabelDDKATEGORIJALevel3Add")]
        private UltraLabel _linkLabelDDKATEGORIJALevel3Add;
        [AccessedThroughProperty("linkLabelDDKATEGORIJALevel3Delete")]
        private UltraLabel _linkLabelDDKATEGORIJALevel3Delete;
        [AccessedThroughProperty("linkLabelDDKATEGORIJALevel3Update")]
        private UltraLabel _linkLabelDDKATEGORIJALevel3Update;
        [AccessedThroughProperty("panelactionsDDKATEGORIJAIzdaci")]
        private Panel _panelactionsDDKATEGORIJAIzdaci;
        [AccessedThroughProperty("panelactionsDDKATEGORIJALevel1")]
        private Panel _panelactionsDDKATEGORIJALevel1;
        [AccessedThroughProperty("panelactionsDDKATEGORIJALevel3")]
        private Panel _panelactionsDDKATEGORIJALevel3;
        [AccessedThroughProperty("SetNullItem")]
        private MenuItem _SetNullItem;
        [AccessedThroughProperty("textIDKATEGORIJA")]
        private UltraNumericEditor _textIDKATEGORIJA;
        [AccessedThroughProperty("textNAZIVKATEGORIJA")]
        private UltraTextEditor _textNAZIVKATEGORIJA;
        [AccessedThroughProperty("toolTip1")]
        private System.Windows.Forms.ToolTip _toolTip1;
        private BindingSource bindingSourceDDKATEGORIJA;
        private BindingSource bindingSourceDDKATEGORIJAIzdaci;
        private BindingSource bindingSourceDDKATEGORIJALevel1;
        private BindingSource bindingSourceDDKATEGORIJALevel3;
        private IContainer components = null;
        private DDKATEGORIJADataSet dsDDKATEGORIJADataSet1;
        protected TableLayoutPanel layoutManagerformDDKATEGORIJA;
        protected TableLayoutPanel layoutManagerpanelactionsDDKATEGORIJAIzdaci;
        protected TableLayoutPanel layoutManagerpanelactionsDDKATEGORIJALevel1;
        protected TableLayoutPanel layoutManagerpanelactionsDDKATEGORIJALevel3;
        private bool m_AutoNumber = false;
        private GenericFormClass m_BaseMethods;
        private DDKATEGORIJADataSet.DDKATEGORIJARow m_CurrentRow;
        private ArrayList m_DataGrids = new ArrayList();
        private string m_FirstLevelName = "DDKATEGORIJA";
        private DataRow m_ForeignKeys;
        private string m_FrameworkDescription = StringResources.DDKATEGORIJADescription;
        private DeklaritMode m_Mode;

        [EventPublication("topic://NetAdvantage/OpenBusinessComponent", PublicationScope.Global)]
        public event EventHandler<OpenComponentEventArgs> StartProcess;

        public DDKATEGORIJAFormUserControl()
        {
            this.InitializeComponent();
            this.Localize();
            this.SetSize();
        }

        private void CallPromptInLinesDDIZDATAKDDIDIZDATAK(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.Controller.SelectDDIZDATAKDDIDIZDATAK("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["DDIDIZDATAK"] = RuntimeHelpers.GetObjectValue(row2["DDIDIZDATAK"]);
                    row3["DDNAZIVIZDATKA"] = RuntimeHelpers.GetObjectValue(row2["DDNAZIVIZDATKA"]);
                    row3["DDPOSTOTAKIZDATKA"] = RuntimeHelpers.GetObjectValue(row2["DDPOSTOTAKIZDATKA"]);
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

        private void CallPromptInLinesDOPRINOSIDDOPRINOS(object sender, CellEventArgs e)
        {
            DataRow row3 = ((DataRowView) e.Cell.Row.ListObject).Row;
            DataRow fillByRow = null;
            DataRow row2 = this.Controller.SelectDOPRINOSIDDOPRINOS("", fillByRow);
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
            DataRow row2 = this.Controller.SelectPOREZIDPOREZ("", fillByRow);
            if (row2 != null)
            {
                try
                {
                    row3["IDPOREZ"] = RuntimeHelpers.GetObjectValue(row2["IDPOREZ"]);
                    row3["NAZIVPOREZ"] = RuntimeHelpers.GetObjectValue(row2["NAZIVPOREZ"]);
                    row3["POREZMJESECNO"] = RuntimeHelpers.GetObjectValue(row2["POREZMJESECNO"]);
                    row3["STOPAPOREZA"] = RuntimeHelpers.GetObjectValue(row2["STOPAPOREZA"]);
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
            this.m_BaseMethods.CellChangedBase(this.dsDDKATEGORIJADataSet1, RuntimeHelpers.GetObjectValue(sender));
        }

        public void ChangeBinding()
        {
            this.bindingSourceDDKATEGORIJA.DataSource = this.Controller.DataSet;
            this.dsDDKATEGORIJADataSet1 = this.Controller.DataSet;
        }

        [LocalCommandHandler("Close")]
        public void Close(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/DDKOLONAIDD", Thread=ThreadOption.UserInterface)]
        public void comboIDKOLONAIDD_Add(object sender, ComponentEventArgs e)
        {
            this.comboIDKOLONAIDD.Fill();
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

        private void DDKATEGORIJAFormUserControl_Load(object sender, EventArgs e)
        {
            this.Text = StringResources.DDKATEGORIJADescription;
            this.errorProvider1.ContainerControl = this;
            this.SetComboBoxColumnProperties();
            this.linkLabelDDKATEGORIJALevel1Add.Text = Deklarit.Resources.Resources.Add + " " + StringResources.DDKATEGORIJADDKATEGORIJALevel1LevelDescription;
            this.linkLabelDDKATEGORIJALevel1Update.Text = Deklarit.Resources.Resources.Update + " " + StringResources.DDKATEGORIJADDKATEGORIJALevel1LevelDescription;
            this.linkLabelDDKATEGORIJALevel1Delete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.DDKATEGORIJADDKATEGORIJALevel1LevelDescription;
            this.linkLabelDDKATEGORIJALevel3Add.Text = Deklarit.Resources.Resources.Add + " " + StringResources.DDKATEGORIJADDKATEGORIJALevel3LevelDescription;
            this.linkLabelDDKATEGORIJALevel3Update.Text = Deklarit.Resources.Resources.Update + " " + StringResources.DDKATEGORIJADDKATEGORIJALevel3LevelDescription;
            this.linkLabelDDKATEGORIJALevel3Delete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.DDKATEGORIJADDKATEGORIJALevel3LevelDescription;
            this.linkLabelDDKATEGORIJAIzdaciAdd.Text = Deklarit.Resources.Resources.Add + " " + StringResources.DDKATEGORIJADDKATEGORIJAIzdaciLevelDescription;
            this.linkLabelDDKATEGORIJAIzdaciUpdate.Text = Deklarit.Resources.Resources.Update + " " + StringResources.DDKATEGORIJADDKATEGORIJAIzdaciLevelDescription;
            this.linkLabelDDKATEGORIJAIzdaciDelete.Text = Deklarit.Resources.Resources.Delete + " " + StringResources.DDKATEGORIJADDKATEGORIJAIzdaciLevelDescription;
        }

        private void DDKATEGORIJAIzdaciAdd_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelDDKATEGORIJAIzdaci.ActiveRow;
            this.DDKATEGORIJAIzdaciInsert();
        }

        private void DDKATEGORIJAIzdaciDelete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelDDKATEGORIJAIzdaci);
            if ((currentRowListIndex != -1) && (this.grdLevelDDKATEGORIJAIzdaci.Selected.Rows.Count > 0))
            {
                this.grdLevelDDKATEGORIJAIzdaci.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelDDKATEGORIJAIzdaci).Selected = true;
                this.grdLevelDDKATEGORIJAIzdaci.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void DDKATEGORIJAIzdaciInsert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceDDKATEGORIJA, this.Controller.WorkItem, this))
            {
                this.Controller.AddDDKATEGORIJAIzdaci(this.m_CurrentRow);
            }
        }

        private void DDKATEGORIJAIzdaciUpdate()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelDDKATEGORIJAIzdaci) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelDDKATEGORIJAIzdaci);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.Controller.UpdateDDKATEGORIJAIzdaci(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void DDKATEGORIJAIzdaciUpdate_Click(object sender, EventArgs e)
        {
            if (this.grdLevelDDKATEGORIJAIzdaci.ActiveRow != null)
            {
                this.DDKATEGORIJAIzdaciUpdate();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void DDKATEGORIJALevel1Add_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelDDKATEGORIJALevel1.ActiveRow;
            this.DDKATEGORIJALevel1Insert();
        }

        private void DDKATEGORIJALevel1Delete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelDDKATEGORIJALevel1);
            if ((currentRowListIndex != -1) && (this.grdLevelDDKATEGORIJALevel1.Selected.Rows.Count > 0))
            {
                this.grdLevelDDKATEGORIJALevel1.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelDDKATEGORIJALevel1).Selected = true;
                this.grdLevelDDKATEGORIJALevel1.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void DDKATEGORIJALevel1Insert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceDDKATEGORIJA, this.Controller.WorkItem, this))
            {
                this.Controller.AddDDKATEGORIJALevel1(this.m_CurrentRow);
            }
        }

        private void DDKATEGORIJALevel1Update()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelDDKATEGORIJALevel1) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelDDKATEGORIJALevel1);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.Controller.UpdateDDKATEGORIJALevel1(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void DDKATEGORIJALevel1Update_Click(object sender, EventArgs e)
        {
            if (this.grdLevelDDKATEGORIJALevel1.ActiveRow != null)
            {
                this.DDKATEGORIJALevel1Update();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void DDKATEGORIJALevel3Add_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = this.grdLevelDDKATEGORIJALevel3.ActiveRow;
            this.DDKATEGORIJALevel3Insert();
        }

        private void DDKATEGORIJALevel3Delete_Click(object sender, EventArgs e)
        {
            int currentRowListIndex = FormHelperClass.GetCurrentRowListIndex(this.grdLevelDDKATEGORIJALevel3);
            if ((currentRowListIndex != -1) && (this.grdLevelDDKATEGORIJALevel3.Selected.Rows.Count > 0))
            {
                this.grdLevelDDKATEGORIJALevel3.DeleteSelectedRows();
            }
            else if (currentRowListIndex != -1)
            {
                FormHelperClass.GetCurrentRow(this.grdLevelDDKATEGORIJALevel3).Selected = true;
                this.grdLevelDDKATEGORIJALevel3.DeleteSelectedRows();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void DDKATEGORIJALevel3Insert()
        {
            if (GenericFormClass.EndEditBindingSource(this.bindingSourceDDKATEGORIJA, this.Controller.WorkItem, this))
            {
                this.Controller.AddDDKATEGORIJALevel3(this.m_CurrentRow);
            }
        }

        private void DDKATEGORIJALevel3Update()
        {
            if (FormHelperClass.GetCurrentRowListIndex(this.grdLevelDDKATEGORIJALevel3) != -1)
            {
                UltraGridRow currentRow = FormHelperClass.GetCurrentRow(this.grdLevelDDKATEGORIJALevel3);
                if (currentRow.ListObject is DataRowView)
                {
                    DataRowView listObject = (DataRowView) currentRow.ListObject;
                    this.Controller.UpdateDDKATEGORIJALevel3(listObject.Row);
                }
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
            }
        }

        private void DDKATEGORIJALevel3Update_Click(object sender, EventArgs e)
        {
            if (this.grdLevelDDKATEGORIJALevel3.ActiveRow != null)
            {
                this.DDKATEGORIJALevel3Update();
            }
            else
            {
                this.ShowMessage(Deklarit.Resources.Resources.NoRowSelected);
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
                    enumerator = this.dsDDKATEGORIJADataSet1.DDKATEGORIJA.Rows.GetEnumerator();
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
                    case "POREZIDPOREZ":
                        this.CallPromptInLinesPOREZIDPOREZ(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "DOPRINOSIDDOPRINOS":
                        this.CallPromptInLinesDOPRINOSIDDOPRINOS(RuntimeHelpers.GetObjectValue(sender), e);
                        break;

                    case "DDIZDATAKDDIDIZDATAK":
                        this.CallPromptInLinesDDIZDATAKDDIDIZDATAK(RuntimeHelpers.GetObjectValue(sender), e);
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
            if (this.grdLevelDDKATEGORIJALevel1.ActiveRow != null)
            {
                this.grdLevelDDKATEGORIJALevel1.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelDDKATEGORIJALevel3.ActiveRow != null)
            {
                this.grdLevelDDKATEGORIJALevel3.PerformAction(UltraGridAction.NextRow);
            }
            if (this.grdLevelDDKATEGORIJAIzdaci.ActiveRow != null)
            {
                this.grdLevelDDKATEGORIJAIzdaci.PerformAction(UltraGridAction.NextRow);
            }
        }

        private void grdLevelDDKATEGORIJAIzdaci_AfterRowActivate(object sender, EventArgs e)
        {
            string dDKATEGORIJADDKATEGORIJAIzdaciLevelDescription = StringResources.DDKATEGORIJADDKATEGORIJAIzdaciLevelDescription;
            UltraGridRow activeRow = this.grdLevelDDKATEGORIJAIzdaci.ActiveRow;
            this.linkLabelDDKATEGORIJAIzdaciAdd.Text = Deklarit.Resources.Resources.Add + " " + dDKATEGORIJADDKATEGORIJAIzdaciLevelDescription;
            this.linkLabelDDKATEGORIJAIzdaciUpdate.Text = Deklarit.Resources.Resources.Update + " " + dDKATEGORIJADDKATEGORIJAIzdaciLevelDescription;
            this.linkLabelDDKATEGORIJAIzdaciDelete.Text = Deklarit.Resources.Resources.Delete + " " + dDKATEGORIJADDKATEGORIJAIzdaciLevelDescription;
        }

        private void grdLevelDDKATEGORIJAIzdaci_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceDDKATEGORIJA.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceDDKATEGORIJA.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelDDKATEGORIJAIzdaci_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.DDKATEGORIJAIzdaciUpdate_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelDDKATEGORIJAIzdaci_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceDDKATEGORIJA, this.Controller.WorkItem, this);
        }

        private void grdLevelDDKATEGORIJALevel1_AfterRowActivate(object sender, EventArgs e)
        {
            string str = StringResources.DDKATEGORIJADDKATEGORIJALevel1LevelDescription;
            UltraGridRow activeRow = this.grdLevelDDKATEGORIJALevel1.ActiveRow;
            this.linkLabelDDKATEGORIJALevel1Add.Text = Deklarit.Resources.Resources.Add + " " + str;
            this.linkLabelDDKATEGORIJALevel1Update.Text = Deklarit.Resources.Resources.Update + " " + str;
            this.linkLabelDDKATEGORIJALevel1Delete.Text = Deklarit.Resources.Resources.Delete + " " + str;
        }

        private void grdLevelDDKATEGORIJALevel1_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceDDKATEGORIJA.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceDDKATEGORIJA.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelDDKATEGORIJALevel1_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.DDKATEGORIJALevel1Update_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelDDKATEGORIJALevel1_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceDDKATEGORIJA, this.Controller.WorkItem, this);
        }

        private void grdLevelDDKATEGORIJALevel3_AfterRowActivate(object sender, EventArgs e)
        {
            string str = StringResources.DDKATEGORIJADDKATEGORIJALevel3LevelDescription;
            UltraGridRow activeRow = this.grdLevelDDKATEGORIJALevel3.ActiveRow;
            this.linkLabelDDKATEGORIJALevel3Add.Text = Deklarit.Resources.Resources.Add + " " + str;
            this.linkLabelDDKATEGORIJALevel3Update.Text = Deklarit.Resources.Resources.Update + " " + str;
            this.linkLabelDDKATEGORIJALevel3Delete.Text = Deklarit.Resources.Resources.Delete + " " + str;
        }

        private void grdLevelDDKATEGORIJALevel3_AfterRowInsert(object sender, RowEventArgs e)
        {
            //if (this.bindingSourceDDKATEGORIJA.Current == typeof(DataRowView))
            //{
            //    DataRowView current = (DataRowView) this.bindingSourceDDKATEGORIJA.Current;
            //    if (current.IsNew)
            //    {
            //        current.Row.SetParentRow(this.m_CurrentRow);
            //    }
            //}
        }

        private void grdLevelDDKATEGORIJALevel3_DoubleClick(object sender, DoubleClickRowEventArgs e)
        {
            this.DDKATEGORIJALevel3Update_Click(RuntimeHelpers.GetObjectValue(sender), e);
        }

        private void grdLevelDDKATEGORIJALevel3_Enter(object sender, EventArgs e)
        {
            GenericFormClass.EndEditBindingSource(this.bindingSourceDDKATEGORIJA, this.Controller.WorkItem, this);
        }

        public void Initialize(DeklaritMode mode, DataRow foreignKeys, bool isCopy)
        {
            this.ChangeBinding();
            this.m_ForeignKeys = foreignKeys;
            this.RegisterBindingSources();
            this.m_Mode = mode;
            this.m_BaseMethods = new GenericFormClass(this.m_FrameworkDescription, this.m_FirstLevelName, "DDKATEGORIJA", this.m_Mode, this.dsDDKATEGORIJADataSet1, this.dsDDKATEGORIJADataSet1.DDKATEGORIJA.Columns, this.Controls, this.m_DataGrids, this.m_AutoNumber);
            if (!this.m_DataGrids.Contains(this.grdLevelDDKATEGORIJALevel1))
            {
                this.m_DataGrids.Add(this.grdLevelDDKATEGORIJALevel1);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelDDKATEGORIJALevel3))
            {
                this.m_DataGrids.Add(this.grdLevelDDKATEGORIJALevel3);
            }
            if (!this.m_DataGrids.Contains(this.grdLevelDDKATEGORIJAIzdaci))
            {
                this.m_DataGrids.Add(this.grdLevelDDKATEGORIJAIzdaci);
            }
            this.m_BaseMethods.FormLoadStyle();
            if ((this.m_BaseMethods.IsUpdate() || this.m_BaseMethods.IsDelete()) || (this.m_BaseMethods.IsSelect() || isCopy))
            {
                this.m_CurrentRow = this.dsDDKATEGORIJADataSet1.DDKATEGORIJA[0];
            }
            if (this.m_BaseMethods.IsInsert() && !isCopy)
            {
                this.m_CurrentRow = (DDKATEGORIJADataSet.DDKATEGORIJARow) ((DataRowView) this.bindingSourceDDKATEGORIJA.AddNew()).Row;
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
            ResourceManager manager = new ResourceManager(typeof(DDKATEGORIJAFormUserControl));
            this.contextMenu1 = new ContextMenu();
            this.SetNullItem = new MenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new ErrorProvider();
            this.errorProviderValidator1 = new ErrorProviderValidator(this.components);
            this.bindingSourceDDKATEGORIJA = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDDKATEGORIJA).BeginInit();
            this.bindingSourceDDKATEGORIJALevel1 = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDDKATEGORIJALevel1).BeginInit();
            this.bindingSourceDDKATEGORIJALevel3 = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDDKATEGORIJALevel3).BeginInit();
            this.bindingSourceDDKATEGORIJAIzdaci = new BindingSource(this.components);
            ((ISupportInitialize) this.bindingSourceDDKATEGORIJAIzdaci).BeginInit();
            this.layoutManagerformDDKATEGORIJA = new TableLayoutPanel();
            this.layoutManagerformDDKATEGORIJA.SuspendLayout();
            this.layoutManagerformDDKATEGORIJA.AutoSize = true;
            this.layoutManagerformDDKATEGORIJA.Dock = DockStyle.Fill;
            this.layoutManagerformDDKATEGORIJA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformDDKATEGORIJA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformDDKATEGORIJA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformDDKATEGORIJA.Size = size;
            this.layoutManagerformDDKATEGORIJA.ColumnCount = 2;
            this.layoutManagerformDDKATEGORIJA.RowCount = 9;
            this.layoutManagerformDDKATEGORIJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDDKATEGORIJA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformDDKATEGORIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDKATEGORIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDKATEGORIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDKATEGORIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDKATEGORIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDKATEGORIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDKATEGORIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDKATEGORIJA.RowStyles.Add(new RowStyle());
            this.layoutManagerformDDKATEGORIJA.RowStyles.Add(new RowStyle());
            this.label1IDKATEGORIJA = new UltraLabel();
            this.textIDKATEGORIJA = new UltraNumericEditor();
            this.label1NAZIVKATEGORIJA = new UltraLabel();
            this.textNAZIVKATEGORIJA = new UltraTextEditor();
            this.label1IDKOLONAIDD = new UltraLabel();
            this.comboIDKOLONAIDD = new DDKOLONAIDDComboBox();
            this.grdLevelDDKATEGORIJALevel1 = new UltraGrid();
            this.panelactionsDDKATEGORIJALevel1 = new Panel();
            this.layoutManagerpanelactionsDDKATEGORIJALevel1 = new TableLayoutPanel();
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.AutoSize = true;
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.ColumnCount = 4;
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.RowCount = 1;
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.RowStyles.Add(new RowStyle());
            this.linkLabelDDKATEGORIJALevel1Add = new UltraLabel();
            this.linkLabelDDKATEGORIJALevel1Update = new UltraLabel();
            this.linkLabelDDKATEGORIJALevel1Delete = new UltraLabel();
            this.linkLabelDDKATEGORIJALevel1 = new UltraLabel();
            this.grdLevelDDKATEGORIJALevel3 = new UltraGrid();
            this.panelactionsDDKATEGORIJALevel3 = new Panel();
            this.layoutManagerpanelactionsDDKATEGORIJALevel3 = new TableLayoutPanel();
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.AutoSize = true;
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.ColumnCount = 4;
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.RowCount = 1;
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.RowStyles.Add(new RowStyle());
            this.linkLabelDDKATEGORIJALevel3Add = new UltraLabel();
            this.linkLabelDDKATEGORIJALevel3Update = new UltraLabel();
            this.linkLabelDDKATEGORIJALevel3Delete = new UltraLabel();
            this.linkLabelDDKATEGORIJALevel3 = new UltraLabel();
            this.grdLevelDDKATEGORIJAIzdaci = new UltraGrid();
            this.panelactionsDDKATEGORIJAIzdaci = new Panel();
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci = new TableLayoutPanel();
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.AutoSize = true;
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.ColumnCount = 4;
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.RowCount = 1;
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.Dock = DockStyle.Fill;
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.RowStyles.Add(new RowStyle());
            this.linkLabelDDKATEGORIJAIzdaciAdd = new UltraLabel();
            this.linkLabelDDKATEGORIJAIzdaciUpdate = new UltraLabel();
            this.linkLabelDDKATEGORIJAIzdaciDelete = new UltraLabel();
            this.linkLabelDDKATEGORIJAIzdaci = new UltraLabel();
            ((ISupportInitialize) this.textIDKATEGORIJA).BeginInit();
            ((ISupportInitialize) this.textNAZIVKATEGORIJA).BeginInit();
            ((ISupportInitialize) this.grdLevelDDKATEGORIJALevel1).BeginInit();
            this.panelactionsDDKATEGORIJALevel1.SuspendLayout();
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.SuspendLayout();
            ((ISupportInitialize) this.grdLevelDDKATEGORIJALevel3).BeginInit();
            this.panelactionsDDKATEGORIJALevel3.SuspendLayout();
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.SuspendLayout();
            ((ISupportInitialize) this.grdLevelDDKATEGORIJAIzdaci).BeginInit();
            this.panelactionsDDKATEGORIJAIzdaci.SuspendLayout();
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.SuspendLayout();
            UltraGridBand band2 = new UltraGridBand("DDKATEGORIJALevel1", -1);
            UltraGridColumn column7 = new UltraGridColumn("IDKATEGORIJA");
            UltraGridColumn column8 = new UltraGridColumn("IDPOREZ");
            UltraGridColumn column10 = new UltraGridColumn("NAZIVPOREZ");
            UltraGridColumn column12 = new UltraGridColumn("POREZMJESECNO");
            UltraGridColumn column17 = new UltraGridColumn("STOPAPOREZA");
            UltraGridColumn column5 = new UltraGridColumn("DDMOPOREZ");
            UltraGridColumn column6 = new UltraGridColumn("DDPOPOREZ");
            UltraGridColumn column9 = new UltraGridColumn("MZPOREZ");
            UltraGridColumn column15 = new UltraGridColumn("PZPOREZ");
            UltraGridColumn column13 = new UltraGridColumn("PRIMATELJPOREZ1");
            UltraGridColumn column14 = new UltraGridColumn("PRIMATELJPOREZ2");
            UltraGridColumn column16 = new UltraGridColumn("SIFRAOPISAPLACANJAPOREZ");
            UltraGridColumn column11 = new UltraGridColumn("OPISPLACANJAPOREZ");
            UltraGridBand band3 = new UltraGridBand("DDKATEGORIJALevel3", -1);
            UltraGridColumn column20 = new UltraGridColumn("IDKATEGORIJA");
            UltraGridColumn column19 = new UltraGridColumn("IDDOPRINOS");
            UltraGridColumn column24 = new UltraGridColumn("NAZIVDOPRINOS");
            UltraGridColumn column21 = new UltraGridColumn("IDVRSTADOPRINOS");
            UltraGridColumn column25 = new UltraGridColumn("NAZIVVRSTADOPRINOS");
            UltraGridColumn column22 = new UltraGridColumn("MODOPRINOS");
            UltraGridColumn column27 = new UltraGridColumn("PODOPRINOS");
            UltraGridColumn column23 = new UltraGridColumn("MZDOPRINOS");
            UltraGridColumn column30 = new UltraGridColumn("PZDOPRINOS");
            UltraGridColumn column28 = new UltraGridColumn("PRIMATELJDOPRINOS1");
            UltraGridColumn column29 = new UltraGridColumn("PRIMATELJDOPRINOS2");
            UltraGridColumn column31 = new UltraGridColumn("SIFRAOPISAPLACANJADOPRINOS");
            UltraGridColumn column26 = new UltraGridColumn("OPISPLACANJADOPRINOS");
            UltraGridColumn column33 = new UltraGridColumn("VBDIDOPRINOS");
            UltraGridColumn column34 = new UltraGridColumn("ZRNDOPRINOS");
            UltraGridColumn column32 = new UltraGridColumn("STOPA");
            UltraGridColumn column18 = new UltraGridColumn("DOPRINOSDRUGOGSTUPA");
            UltraGridBand band = new UltraGridBand("DDKATEGORIJAIzdaci", -1);
            UltraGridColumn column4 = new UltraGridColumn("IDKATEGORIJA");
            UltraGridColumn column = new UltraGridColumn("DDIDIZDATAK");
            UltraGridColumn column2 = new UltraGridColumn("DDNAZIVIZDATKA");
            UltraGridColumn column3 = new UltraGridColumn("DDPOSTOTAKIZDATKA");
            this.dsDDKATEGORIJADataSet1 = new DDKATEGORIJADataSet();
            this.dsDDKATEGORIJADataSet1.BeginInit();
            this.SuspendLayout();
            this.dsDDKATEGORIJADataSet1.DataSetName = "dsDDKATEGORIJA";
            this.dsDDKATEGORIJADataSet1.Locale = new CultureInfo("hr-HR");
            this.bindingSourceDDKATEGORIJA.DataSource = this.dsDDKATEGORIJADataSet1;
            this.bindingSourceDDKATEGORIJA.DataMember = "DDKATEGORIJA";
            ((ISupportInitialize) this.bindingSourceDDKATEGORIJA).BeginInit();
            this.bindingSourceDDKATEGORIJALevel1.DataSource = this.bindingSourceDDKATEGORIJA;
            this.bindingSourceDDKATEGORIJALevel1.DataMember = "DDKATEGORIJA_DDKATEGORIJALevel1";
            this.bindingSourceDDKATEGORIJALevel3.DataSource = this.bindingSourceDDKATEGORIJA;
            this.bindingSourceDDKATEGORIJALevel3.DataMember = "DDKATEGORIJA_DDKATEGORIJALevel3";
            this.bindingSourceDDKATEGORIJAIzdaci.DataSource = this.bindingSourceDDKATEGORIJA;
            this.bindingSourceDDKATEGORIJAIzdaci.DataMember = "DDKATEGORIJA_DDKATEGORIJAIzdaci";
            point = new System.Drawing.Point(0, 0);
            this.label1IDKATEGORIJA.Location = point;
            this.label1IDKATEGORIJA.Name = "label1IDKATEGORIJA";
            this.label1IDKATEGORIJA.TabIndex = 1;
            this.label1IDKATEGORIJA.Tag = "labelIDKATEGORIJA";
            this.label1IDKATEGORIJA.Text = "Šifra:";
            this.label1IDKATEGORIJA.StyleSetName = "FieldUltraLabel";
            this.label1IDKATEGORIJA.AutoSize = true;
            this.label1IDKATEGORIJA.Anchor = AnchorStyles.Left;
            this.label1IDKATEGORIJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDKATEGORIJA.Appearance.Image = RuntimeHelpers.GetObjectValue(manager.GetObject("pictureBoxKey.Image"));
            this.label1IDKATEGORIJA.Appearance.ImageHAlign = HAlign.Right;
            size = new System.Drawing.Size(7, 10);
            this.label1IDKATEGORIJA.ImageSize = size;
            this.label1IDKATEGORIJA.Appearance.ForeColor = Color.Black;
            this.label1IDKATEGORIJA.BackColor = Color.Transparent;
            this.layoutManagerformDDKATEGORIJA.Controls.Add(this.label1IDKATEGORIJA, 0, 0);
            this.layoutManagerformDDKATEGORIJA.SetColumnSpan(this.label1IDKATEGORIJA, 1);
            this.layoutManagerformDDKATEGORIJA.SetRowSpan(this.label1IDKATEGORIJA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDKATEGORIJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDKATEGORIJA.MinimumSize = size;
            size = new System.Drawing.Size(0x2d, 0x17);
            this.label1IDKATEGORIJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDKATEGORIJA.Location = point;
            this.textIDKATEGORIJA.Name = "textIDKATEGORIJA";
            this.textIDKATEGORIJA.Tag = "IDKATEGORIJA";
            this.textIDKATEGORIJA.TabIndex = 0;
            this.textIDKATEGORIJA.Anchor = AnchorStyles.Left;
            this.textIDKATEGORIJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textIDKATEGORIJA.ReadOnly = false;
            this.textIDKATEGORIJA.PromptChar = ' ';
            this.textIDKATEGORIJA.Enter += new EventHandler(this.numericEditor_Enter);
            this.textIDKATEGORIJA.DataBindings.Add(new Binding("Value", this.bindingSourceDDKATEGORIJA, "IDKATEGORIJA"));
            this.textIDKATEGORIJA.NumericType = NumericType.Integer;
            this.textIDKATEGORIJA.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformDDKATEGORIJA.Controls.Add(this.textIDKATEGORIJA, 1, 0);
            this.layoutManagerformDDKATEGORIJA.SetColumnSpan(this.textIDKATEGORIJA, 1);
            this.layoutManagerformDDKATEGORIJA.SetRowSpan(this.textIDKATEGORIJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDKATEGORIJA.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDKATEGORIJA.MinimumSize = size;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textIDKATEGORIJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1NAZIVKATEGORIJA.Location = point;
            this.label1NAZIVKATEGORIJA.Name = "label1NAZIVKATEGORIJA";
            this.label1NAZIVKATEGORIJA.TabIndex = 1;
            this.label1NAZIVKATEGORIJA.Tag = "labelNAZIVKATEGORIJA";
            this.label1NAZIVKATEGORIJA.Text = "Kategorija drugog dohotka:";
            this.label1NAZIVKATEGORIJA.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVKATEGORIJA.AutoSize = true;
            this.label1NAZIVKATEGORIJA.Anchor = AnchorStyles.Left;
            this.label1NAZIVKATEGORIJA.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVKATEGORIJA.Appearance.ForeColor = Color.Black;
            this.label1NAZIVKATEGORIJA.BackColor = Color.Transparent;
            this.layoutManagerformDDKATEGORIJA.Controls.Add(this.label1NAZIVKATEGORIJA, 0, 1);
            this.layoutManagerformDDKATEGORIJA.SetColumnSpan(this.label1NAZIVKATEGORIJA, 1);
            this.layoutManagerformDDKATEGORIJA.SetRowSpan(this.label1NAZIVKATEGORIJA, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVKATEGORIJA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVKATEGORIJA.MinimumSize = size;
            size = new System.Drawing.Size(0xba, 0x17);
            this.label1NAZIVKATEGORIJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVKATEGORIJA.Location = point;
            this.textNAZIVKATEGORIJA.Name = "textNAZIVKATEGORIJA";
            this.textNAZIVKATEGORIJA.Tag = "NAZIVKATEGORIJA";
            this.textNAZIVKATEGORIJA.TabIndex = 0;
            this.textNAZIVKATEGORIJA.Anchor = AnchorStyles.Left;
            this.textNAZIVKATEGORIJA.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.textNAZIVKATEGORIJA.ReadOnly = false;
            this.textNAZIVKATEGORIJA.DataBindings.Add(new Binding("Text", this.bindingSourceDDKATEGORIJA, "NAZIVKATEGORIJA"));
            this.textNAZIVKATEGORIJA.MaxLength = 50;
            this.layoutManagerformDDKATEGORIJA.Controls.Add(this.textNAZIVKATEGORIJA, 1, 1);
            this.layoutManagerformDDKATEGORIJA.SetColumnSpan(this.textNAZIVKATEGORIJA, 1);
            this.layoutManagerformDDKATEGORIJA.SetRowSpan(this.textNAZIVKATEGORIJA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVKATEGORIJA.Margin = padding;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVKATEGORIJA.MinimumSize = size;
            size = new System.Drawing.Size(0x16e, 0x16);
            this.textNAZIVKATEGORIJA.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.label1IDKOLONAIDD.Location = point;
            this.label1IDKOLONAIDD.Name = "label1IDKOLONAIDD";
            this.label1IDKOLONAIDD.TabIndex = 1;
            this.label1IDKOLONAIDD.Tag = "labelIDKOLONAIDD";
            this.label1IDKOLONAIDD.Text = "Kolona IDD obrasca:";
            this.label1IDKOLONAIDD.StyleSetName = "FieldUltraLabel";
            this.label1IDKOLONAIDD.AutoSize = true;
            this.label1IDKOLONAIDD.Anchor = AnchorStyles.Left;
            this.label1IDKOLONAIDD.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDKOLONAIDD.Appearance.ForeColor = Color.Black;
            this.label1IDKOLONAIDD.BackColor = Color.Transparent;
            this.layoutManagerformDDKATEGORIJA.Controls.Add(this.label1IDKOLONAIDD, 0, 2);
            this.layoutManagerformDDKATEGORIJA.SetColumnSpan(this.label1IDKOLONAIDD, 1);
            this.layoutManagerformDDKATEGORIJA.SetRowSpan(this.label1IDKOLONAIDD, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDKOLONAIDD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDKOLONAIDD.MinimumSize = size;
            size = new System.Drawing.Size(0x8e, 0x17);
            this.label1IDKOLONAIDD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDKOLONAIDD.Location = point;
            this.comboIDKOLONAIDD.Name = "comboIDKOLONAIDD";
            this.comboIDKOLONAIDD.Tag = "IDKOLONAIDD";
            this.comboIDKOLONAIDD.TabIndex = 0;
            this.comboIDKOLONAIDD.Anchor = AnchorStyles.Left;
            this.comboIDKOLONAIDD.MouseEnter += new EventHandler(this.mouseEnter_Text);
            this.comboIDKOLONAIDD.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDKOLONAIDD.ComboBox.DropDownStyle = DropDownStyle.DropDown;
            this.comboIDKOLONAIDD.ComboBox.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.comboIDKOLONAIDD.Enabled = true;
            this.comboIDKOLONAIDD.DataBindings.Add(new Binding("Value", this.bindingSourceDDKATEGORIJA, "IDKOLONAIDD"));
            this.comboIDKOLONAIDD.ShowPictureBox = true;
            this.comboIDKOLONAIDD.PictureBoxClicked += new EventHandler(this.PictureBoxClickedIDKOLONAIDD);
            this.comboIDKOLONAIDD.ValueMember = "IDKOLONAIDD";
            this.comboIDKOLONAIDD.SelectionChanged += new EventHandler(this.SelectedIndexChangedIDKOLONAIDD);
            this.layoutManagerformDDKATEGORIJA.Controls.Add(this.comboIDKOLONAIDD, 1, 2);
            this.layoutManagerformDDKATEGORIJA.SetColumnSpan(this.comboIDKOLONAIDD, 1);
            this.layoutManagerformDDKATEGORIJA.SetRowSpan(this.comboIDKOLONAIDD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDKOLONAIDD.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDKOLONAIDD.MinimumSize = size;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDKOLONAIDD.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelDDKATEGORIJALevel1.Location = point;
            this.grdLevelDDKATEGORIJALevel1.Name = "grdLevelDDKATEGORIJALevel1";
            this.layoutManagerformDDKATEGORIJA.Controls.Add(this.grdLevelDDKATEGORIJALevel1, 0, 3);
            this.layoutManagerformDDKATEGORIJA.SetColumnSpan(this.grdLevelDDKATEGORIJALevel1, 2);
            this.layoutManagerformDDKATEGORIJA.SetRowSpan(this.grdLevelDDKATEGORIJALevel1, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelDDKATEGORIJALevel1.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelDDKATEGORIJALevel1.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelDDKATEGORIJALevel1.Size = size;
            this.grdLevelDDKATEGORIJALevel1.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsDDKATEGORIJALevel1.Location = point;
            this.panelactionsDDKATEGORIJALevel1.Name = "panelactionsDDKATEGORIJALevel1";
            this.panelactionsDDKATEGORIJALevel1.BackColor = Color.Transparent;
            this.panelactionsDDKATEGORIJALevel1.Controls.Add(this.layoutManagerpanelactionsDDKATEGORIJALevel1);
            this.layoutManagerformDDKATEGORIJA.Controls.Add(this.panelactionsDDKATEGORIJALevel1, 0, 4);
            this.layoutManagerformDDKATEGORIJA.SetColumnSpan(this.panelactionsDDKATEGORIJALevel1, 2);
            this.layoutManagerformDDKATEGORIJA.SetRowSpan(this.panelactionsDDKATEGORIJALevel1, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsDDKATEGORIJALevel1.Margin = padding;
            size = new System.Drawing.Size(270, 0x19);
            this.panelactionsDDKATEGORIJALevel1.MinimumSize = size;
            size = new System.Drawing.Size(270, 0x19);
            this.panelactionsDDKATEGORIJALevel1.Size = size;
            this.panelactionsDDKATEGORIJALevel1.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelDDKATEGORIJALevel1Add.Location = point;
            this.linkLabelDDKATEGORIJALevel1Add.Name = "linkLabelDDKATEGORIJALevel1Add";
            size = new System.Drawing.Size(0x42, 15);
            this.linkLabelDDKATEGORIJALevel1Add.Size = size;
            this.linkLabelDDKATEGORIJALevel1Add.Text = " Add Porezi  ";
            this.linkLabelDDKATEGORIJALevel1Add.Click += new EventHandler(this.DDKATEGORIJALevel1Add_Click);
            this.linkLabelDDKATEGORIJALevel1Add.BackColor = Color.Transparent;
            this.linkLabelDDKATEGORIJALevel1Add.Appearance.ForeColor = Color.Blue;
            this.linkLabelDDKATEGORIJALevel1Add.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelDDKATEGORIJALevel1Add.Cursor = Cursors.Hand;
            this.linkLabelDDKATEGORIJALevel1Add.AutoSize = true;
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.Controls.Add(this.linkLabelDDKATEGORIJALevel1Add, 0, 0);
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.SetColumnSpan(this.linkLabelDDKATEGORIJALevel1Add, 1);
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.SetRowSpan(this.linkLabelDDKATEGORIJALevel1Add, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelDDKATEGORIJALevel1Add.Margin = padding;
            size = new System.Drawing.Size(0x42, 15);
            this.linkLabelDDKATEGORIJALevel1Add.MinimumSize = size;
            size = new System.Drawing.Size(0x42, 15);
            this.linkLabelDDKATEGORIJALevel1Add.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelDDKATEGORIJALevel1Update.Location = point;
            this.linkLabelDDKATEGORIJALevel1Update.Name = "linkLabelDDKATEGORIJALevel1Update";
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelDDKATEGORIJALevel1Update.Size = size;
            this.linkLabelDDKATEGORIJALevel1Update.Text = " Update Porezi  ";
            this.linkLabelDDKATEGORIJALevel1Update.Click += new EventHandler(this.DDKATEGORIJALevel1Update_Click);
            this.linkLabelDDKATEGORIJALevel1Update.BackColor = Color.Transparent;
            this.linkLabelDDKATEGORIJALevel1Update.Appearance.ForeColor = Color.Blue;
            this.linkLabelDDKATEGORIJALevel1Update.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelDDKATEGORIJALevel1Update.Cursor = Cursors.Hand;
            this.linkLabelDDKATEGORIJALevel1Update.AutoSize = true;
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.Controls.Add(this.linkLabelDDKATEGORIJALevel1Update, 1, 0);
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.SetColumnSpan(this.linkLabelDDKATEGORIJALevel1Update, 1);
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.SetRowSpan(this.linkLabelDDKATEGORIJALevel1Update, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelDDKATEGORIJALevel1Update.Margin = padding;
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelDDKATEGORIJALevel1Update.MinimumSize = size;
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelDDKATEGORIJALevel1Update.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelDDKATEGORIJALevel1Delete.Location = point;
            this.linkLabelDDKATEGORIJALevel1Delete.Name = "linkLabelDDKATEGORIJALevel1Delete";
            size = new System.Drawing.Size(80, 15);
            this.linkLabelDDKATEGORIJALevel1Delete.Size = size;
            this.linkLabelDDKATEGORIJALevel1Delete.Text = " Delete Porezi  ";
            this.linkLabelDDKATEGORIJALevel1Delete.Click += new EventHandler(this.DDKATEGORIJALevel1Delete_Click);
            this.linkLabelDDKATEGORIJALevel1Delete.BackColor = Color.Transparent;
            this.linkLabelDDKATEGORIJALevel1Delete.Appearance.ForeColor = Color.Blue;
            this.linkLabelDDKATEGORIJALevel1Delete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelDDKATEGORIJALevel1Delete.Cursor = Cursors.Hand;
            this.linkLabelDDKATEGORIJALevel1Delete.AutoSize = true;
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.Controls.Add(this.linkLabelDDKATEGORIJALevel1Delete, 2, 0);
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.SetColumnSpan(this.linkLabelDDKATEGORIJALevel1Delete, 1);
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.SetRowSpan(this.linkLabelDDKATEGORIJALevel1Delete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelDDKATEGORIJALevel1Delete.Margin = padding;
            size = new System.Drawing.Size(80, 15);
            this.linkLabelDDKATEGORIJALevel1Delete.MinimumSize = size;
            size = new System.Drawing.Size(80, 15);
            this.linkLabelDDKATEGORIJALevel1Delete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelDDKATEGORIJALevel1.Location = point;
            this.linkLabelDDKATEGORIJALevel1.Name = "linkLabelDDKATEGORIJALevel1";
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.Controls.Add(this.linkLabelDDKATEGORIJALevel1, 3, 0);
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.SetColumnSpan(this.linkLabelDDKATEGORIJALevel1, 1);
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.SetRowSpan(this.linkLabelDDKATEGORIJALevel1, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelDDKATEGORIJALevel1.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelDDKATEGORIJALevel1.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelDDKATEGORIJALevel1.Size = size;
            this.linkLabelDDKATEGORIJALevel1.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelDDKATEGORIJALevel3.Location = point;
            this.grdLevelDDKATEGORIJALevel3.Name = "grdLevelDDKATEGORIJALevel3";
            this.layoutManagerformDDKATEGORIJA.Controls.Add(this.grdLevelDDKATEGORIJALevel3, 0, 5);
            this.layoutManagerformDDKATEGORIJA.SetColumnSpan(this.grdLevelDDKATEGORIJALevel3, 2);
            this.layoutManagerformDDKATEGORIJA.SetRowSpan(this.grdLevelDDKATEGORIJALevel3, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelDDKATEGORIJALevel3.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelDDKATEGORIJALevel3.MinimumSize = size;
            size = new System.Drawing.Size(750, 200);
            this.grdLevelDDKATEGORIJALevel3.Size = size;
            this.grdLevelDDKATEGORIJALevel3.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsDDKATEGORIJALevel3.Location = point;
            this.panelactionsDDKATEGORIJALevel3.Name = "panelactionsDDKATEGORIJALevel3";
            this.panelactionsDDKATEGORIJALevel3.BackColor = Color.Transparent;
            this.panelactionsDDKATEGORIJALevel3.Controls.Add(this.layoutManagerpanelactionsDDKATEGORIJALevel3);
            this.layoutManagerformDDKATEGORIJA.Controls.Add(this.panelactionsDDKATEGORIJALevel3, 0, 6);
            this.layoutManagerformDDKATEGORIJA.SetColumnSpan(this.panelactionsDDKATEGORIJALevel3, 2);
            this.layoutManagerformDDKATEGORIJA.SetRowSpan(this.panelactionsDDKATEGORIJALevel3, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsDDKATEGORIJALevel3.Margin = padding;
            size = new System.Drawing.Size(0x144, 0x19);
            this.panelactionsDDKATEGORIJALevel3.MinimumSize = size;
            size = new System.Drawing.Size(0x144, 0x19);
            this.panelactionsDDKATEGORIJALevel3.Size = size;
            this.panelactionsDDKATEGORIJALevel3.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelDDKATEGORIJALevel3Add.Location = point;
            this.linkLabelDDKATEGORIJALevel3Add.Name = "linkLabelDDKATEGORIJALevel3Add";
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelDDKATEGORIJALevel3Add.Size = size;
            this.linkLabelDDKATEGORIJALevel3Add.Text = " Add Doprinosi  ";
            this.linkLabelDDKATEGORIJALevel3Add.Click += new EventHandler(this.DDKATEGORIJALevel3Add_Click);
            this.linkLabelDDKATEGORIJALevel3Add.BackColor = Color.Transparent;
            this.linkLabelDDKATEGORIJALevel3Add.Appearance.ForeColor = Color.Blue;
            this.linkLabelDDKATEGORIJALevel3Add.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelDDKATEGORIJALevel3Add.Cursor = Cursors.Hand;
            this.linkLabelDDKATEGORIJALevel3Add.AutoSize = true;
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.Controls.Add(this.linkLabelDDKATEGORIJALevel3Add, 0, 0);
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.SetColumnSpan(this.linkLabelDDKATEGORIJALevel3Add, 1);
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.SetRowSpan(this.linkLabelDDKATEGORIJALevel3Add, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelDDKATEGORIJALevel3Add.Margin = padding;
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelDDKATEGORIJALevel3Add.MinimumSize = size;
            size = new System.Drawing.Size(0x54, 15);
            this.linkLabelDDKATEGORIJALevel3Add.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelDDKATEGORIJALevel3Update.Location = point;
            this.linkLabelDDKATEGORIJALevel3Update.Name = "linkLabelDDKATEGORIJALevel3Update";
            size = new System.Drawing.Size(0x66, 15);
            this.linkLabelDDKATEGORIJALevel3Update.Size = size;
            this.linkLabelDDKATEGORIJALevel3Update.Text = " Update Doprinosi  ";
            this.linkLabelDDKATEGORIJALevel3Update.Click += new EventHandler(this.DDKATEGORIJALevel3Update_Click);
            this.linkLabelDDKATEGORIJALevel3Update.BackColor = Color.Transparent;
            this.linkLabelDDKATEGORIJALevel3Update.Appearance.ForeColor = Color.Blue;
            this.linkLabelDDKATEGORIJALevel3Update.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelDDKATEGORIJALevel3Update.Cursor = Cursors.Hand;
            this.linkLabelDDKATEGORIJALevel3Update.AutoSize = true;
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.Controls.Add(this.linkLabelDDKATEGORIJALevel3Update, 1, 0);
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.SetColumnSpan(this.linkLabelDDKATEGORIJALevel3Update, 1);
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.SetRowSpan(this.linkLabelDDKATEGORIJALevel3Update, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelDDKATEGORIJALevel3Update.Margin = padding;
            size = new System.Drawing.Size(0x66, 15);
            this.linkLabelDDKATEGORIJALevel3Update.MinimumSize = size;
            size = new System.Drawing.Size(0x66, 15);
            this.linkLabelDDKATEGORIJALevel3Update.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelDDKATEGORIJALevel3Delete.Location = point;
            this.linkLabelDDKATEGORIJALevel3Delete.Name = "linkLabelDDKATEGORIJALevel3Delete";
            size = new System.Drawing.Size(0x62, 15);
            this.linkLabelDDKATEGORIJALevel3Delete.Size = size;
            this.linkLabelDDKATEGORIJALevel3Delete.Text = " Delete Doprinosi  ";
            this.linkLabelDDKATEGORIJALevel3Delete.Click += new EventHandler(this.DDKATEGORIJALevel3Delete_Click);
            this.linkLabelDDKATEGORIJALevel3Delete.BackColor = Color.Transparent;
            this.linkLabelDDKATEGORIJALevel3Delete.Appearance.ForeColor = Color.Blue;
            this.linkLabelDDKATEGORIJALevel3Delete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelDDKATEGORIJALevel3Delete.Cursor = Cursors.Hand;
            this.linkLabelDDKATEGORIJALevel3Delete.AutoSize = true;
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.Controls.Add(this.linkLabelDDKATEGORIJALevel3Delete, 2, 0);
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.SetColumnSpan(this.linkLabelDDKATEGORIJALevel3Delete, 1);
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.SetRowSpan(this.linkLabelDDKATEGORIJALevel3Delete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelDDKATEGORIJALevel3Delete.Margin = padding;
            size = new System.Drawing.Size(0x62, 15);
            this.linkLabelDDKATEGORIJALevel3Delete.MinimumSize = size;
            size = new System.Drawing.Size(0x62, 15);
            this.linkLabelDDKATEGORIJALevel3Delete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelDDKATEGORIJALevel3.Location = point;
            this.linkLabelDDKATEGORIJALevel3.Name = "linkLabelDDKATEGORIJALevel3";
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.Controls.Add(this.linkLabelDDKATEGORIJALevel3, 3, 0);
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.SetColumnSpan(this.linkLabelDDKATEGORIJALevel3, 1);
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.SetRowSpan(this.linkLabelDDKATEGORIJALevel3, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelDDKATEGORIJALevel3.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelDDKATEGORIJALevel3.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelDDKATEGORIJALevel3.Size = size;
            this.linkLabelDDKATEGORIJALevel3.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.grdLevelDDKATEGORIJAIzdaci.Location = point;
            this.grdLevelDDKATEGORIJAIzdaci.Name = "grdLevelDDKATEGORIJAIzdaci";
            this.layoutManagerformDDKATEGORIJA.Controls.Add(this.grdLevelDDKATEGORIJAIzdaci, 0, 7);
            this.layoutManagerformDDKATEGORIJA.SetColumnSpan(this.grdLevelDDKATEGORIJAIzdaci, 2);
            this.layoutManagerformDDKATEGORIJA.SetRowSpan(this.grdLevelDDKATEGORIJAIzdaci, 1);
            padding = new Padding(5, 10, 5, 10);
            this.grdLevelDDKATEGORIJAIzdaci.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.grdLevelDDKATEGORIJAIzdaci.MinimumSize = size;
            size = new System.Drawing.Size(0x209, 200);
            this.grdLevelDDKATEGORIJAIzdaci.Size = size;
            this.grdLevelDDKATEGORIJAIzdaci.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.panelactionsDDKATEGORIJAIzdaci.Location = point;
            this.panelactionsDDKATEGORIJAIzdaci.Name = "panelactionsDDKATEGORIJAIzdaci";
            this.panelactionsDDKATEGORIJAIzdaci.BackColor = Color.Transparent;
            this.panelactionsDDKATEGORIJAIzdaci.Controls.Add(this.layoutManagerpanelactionsDDKATEGORIJAIzdaci);
            this.layoutManagerformDDKATEGORIJA.Controls.Add(this.panelactionsDDKATEGORIJAIzdaci, 0, 8);
            this.layoutManagerformDDKATEGORIJA.SetColumnSpan(this.panelactionsDDKATEGORIJAIzdaci, 2);
            this.layoutManagerformDDKATEGORIJA.SetRowSpan(this.panelactionsDDKATEGORIJAIzdaci, 1);
            padding = new Padding(0, 0, 0, 0);
            this.panelactionsDDKATEGORIJAIzdaci.Margin = padding;
            size = new System.Drawing.Size(0x10b, 0x19);
            this.panelactionsDDKATEGORIJAIzdaci.MinimumSize = size;
            size = new System.Drawing.Size(0x10b, 0x19);
            this.panelactionsDDKATEGORIJAIzdaci.Size = size;
            this.panelactionsDDKATEGORIJAIzdaci.Dock = DockStyle.Fill;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelDDKATEGORIJAIzdaciAdd.Location = point;
            this.linkLabelDDKATEGORIJAIzdaciAdd.Name = "linkLabelDDKATEGORIJAIzdaciAdd";
            size = new System.Drawing.Size(0x41, 15);
            this.linkLabelDDKATEGORIJAIzdaciAdd.Size = size;
            this.linkLabelDDKATEGORIJAIzdaciAdd.Text = " Add Izdaci  ";
            this.linkLabelDDKATEGORIJAIzdaciAdd.Click += new EventHandler(this.DDKATEGORIJAIzdaciAdd_Click);
            this.linkLabelDDKATEGORIJAIzdaciAdd.BackColor = Color.Transparent;
            this.linkLabelDDKATEGORIJAIzdaciAdd.Appearance.ForeColor = Color.Blue;
            this.linkLabelDDKATEGORIJAIzdaciAdd.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelDDKATEGORIJAIzdaciAdd.Cursor = Cursors.Hand;
            this.linkLabelDDKATEGORIJAIzdaciAdd.AutoSize = true;
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.Controls.Add(this.linkLabelDDKATEGORIJAIzdaciAdd, 0, 0);
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.SetColumnSpan(this.linkLabelDDKATEGORIJAIzdaciAdd, 1);
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.SetRowSpan(this.linkLabelDDKATEGORIJAIzdaciAdd, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelDDKATEGORIJAIzdaciAdd.Margin = padding;
            size = new System.Drawing.Size(0x41, 15);
            this.linkLabelDDKATEGORIJAIzdaciAdd.MinimumSize = size;
            size = new System.Drawing.Size(0x41, 15);
            this.linkLabelDDKATEGORIJAIzdaciAdd.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelDDKATEGORIJAIzdaciUpdate.Location = point;
            this.linkLabelDDKATEGORIJAIzdaciUpdate.Name = "linkLabelDDKATEGORIJAIzdaciUpdate";
            size = new System.Drawing.Size(0x53, 15);
            this.linkLabelDDKATEGORIJAIzdaciUpdate.Size = size;
            this.linkLabelDDKATEGORIJAIzdaciUpdate.Text = " Update Izdaci  ";
            this.linkLabelDDKATEGORIJAIzdaciUpdate.Click += new EventHandler(this.DDKATEGORIJAIzdaciUpdate_Click);
            this.linkLabelDDKATEGORIJAIzdaciUpdate.BackColor = Color.Transparent;
            this.linkLabelDDKATEGORIJAIzdaciUpdate.Appearance.ForeColor = Color.Blue;
            this.linkLabelDDKATEGORIJAIzdaciUpdate.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelDDKATEGORIJAIzdaciUpdate.Cursor = Cursors.Hand;
            this.linkLabelDDKATEGORIJAIzdaciUpdate.AutoSize = true;
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.Controls.Add(this.linkLabelDDKATEGORIJAIzdaciUpdate, 1, 0);
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.SetColumnSpan(this.linkLabelDDKATEGORIJAIzdaciUpdate, 1);
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.SetRowSpan(this.linkLabelDDKATEGORIJAIzdaciUpdate, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelDDKATEGORIJAIzdaciUpdate.Margin = padding;
            size = new System.Drawing.Size(0x53, 15);
            this.linkLabelDDKATEGORIJAIzdaciUpdate.MinimumSize = size;
            size = new System.Drawing.Size(0x53, 15);
            this.linkLabelDDKATEGORIJAIzdaciUpdate.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelDDKATEGORIJAIzdaciDelete.Location = point;
            this.linkLabelDDKATEGORIJAIzdaciDelete.Name = "linkLabelDDKATEGORIJAIzdaciDelete";
            size = new System.Drawing.Size(0x4f, 15);
            this.linkLabelDDKATEGORIJAIzdaciDelete.Size = size;
            this.linkLabelDDKATEGORIJAIzdaciDelete.Text = " Delete Izdaci  ";
            this.linkLabelDDKATEGORIJAIzdaciDelete.Click += new EventHandler(this.DDKATEGORIJAIzdaciDelete_Click);
            this.linkLabelDDKATEGORIJAIzdaciDelete.BackColor = Color.Transparent;
            this.linkLabelDDKATEGORIJAIzdaciDelete.Appearance.ForeColor = Color.Blue;
            this.linkLabelDDKATEGORIJAIzdaciDelete.Appearance.FontData.UnderlineAsString = "True";
            this.linkLabelDDKATEGORIJAIzdaciDelete.Cursor = Cursors.Hand;
            this.linkLabelDDKATEGORIJAIzdaciDelete.AutoSize = true;
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.Controls.Add(this.linkLabelDDKATEGORIJAIzdaciDelete, 2, 0);
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.SetColumnSpan(this.linkLabelDDKATEGORIJAIzdaciDelete, 1);
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.SetRowSpan(this.linkLabelDDKATEGORIJAIzdaciDelete, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelDDKATEGORIJAIzdaciDelete.Margin = padding;
            size = new System.Drawing.Size(0x4f, 15);
            this.linkLabelDDKATEGORIJAIzdaciDelete.MinimumSize = size;
            size = new System.Drawing.Size(0x4f, 15);
            this.linkLabelDDKATEGORIJAIzdaciDelete.Size = size;
            point = new System.Drawing.Point(0, 0);
            this.linkLabelDDKATEGORIJAIzdaci.Location = point;
            this.linkLabelDDKATEGORIJAIzdaci.Name = "linkLabelDDKATEGORIJAIzdaci";
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.Controls.Add(this.linkLabelDDKATEGORIJAIzdaci, 3, 0);
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.SetColumnSpan(this.linkLabelDDKATEGORIJAIzdaci, 1);
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.SetRowSpan(this.linkLabelDDKATEGORIJAIzdaci, 1);
            padding = new Padding(5, 5, 5, 5);
            this.linkLabelDDKATEGORIJAIzdaci.Margin = padding;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelDDKATEGORIJAIzdaci.MinimumSize = size;
            size = new System.Drawing.Size(0, 15);
            this.linkLabelDDKATEGORIJAIzdaci.Size = size;
            this.linkLabelDDKATEGORIJAIzdaci.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformDDKATEGORIJA);
            this.SetNullItem.Index = 0;
            this.SetNullItem.Text = "Set Null";
            this.SetNullItem.Click += new EventHandler(this.SetNullItem_Click);
            this.contextMenu1.Popup += new EventHandler(this.contextMenu1_Popup);
            this.contextMenu1.MenuItems.AddRange(new MenuItem[] { this.SetNullItem });
            this.errorProvider1.DataSource = this.bindingSourceDDKATEGORIJA;
            this.errorProviderValidator1.ErrorProvider = this.errorProvider1;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.Disabled;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.DDKATEGORIJAIDKATEGORIJADescription;
            column7.Width = 0x33;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnn";
            column7.PromptChar = ' ';
            column7.Format = "";
            column7.CellAppearance = appearance7;
            column7.Hidden = true;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.DDKATEGORIJAIDPOREZDescription;
            column8.Width = 0x63;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnn";
            column8.PromptChar = ' ';
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.Disabled;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.DDKATEGORIJANAZIVPOREZDescription;
            column10.Width = 0x128;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.Disabled;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.DDKATEGORIJAPOREZMJESECNODescription;
            column12.Width = 0xd9;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.Disabled;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.DDKATEGORIJASTOPAPOREZADescription;
            column17.Width = 0x66;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nn.nn";
            column17.PromptChar = ' ';
            column17.Format = "F2";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.DDKATEGORIJADDMOPOREZDescription;
            column5.Width = 0x79;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.DDKATEGORIJADDPOPOREZDescription;
            column6.Width = 0xb1;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.Disabled;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.DDKATEGORIJAMZPOREZDescription;
            column9.Width = 170;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.Disabled;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.DDKATEGORIJAPZPOREZDescription;
            column15.Width = 0xe2;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.Disabled;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.DDKATEGORIJAPRIMATELJPOREZ1Description;
            column13.Width = 0x9c;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.Disabled;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.DDKATEGORIJAPRIMATELJPOREZ2Description;
            column14.Width = 0x9c;
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.Disabled;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.DDKATEGORIJASIFRAOPISAPLACANJAPOREZDescription;
            column16.Width = 0xcd;
            column16.Format = "";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.Disabled;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.DDKATEGORIJAOPISPLACANJAPOREZDescription;
            column11.Width = 0x10c;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            band2.Columns.Add(column8);
            column8.Header.VisiblePosition = 0;
            band2.Columns.Add(column10);
            column10.Header.VisiblePosition = 1;
            band2.Columns.Add(column12);
            column12.Header.VisiblePosition = 2;
            band2.Columns.Add(column17);
            column17.Header.VisiblePosition = 3;
            band2.Columns.Add(column5);
            column5.Header.VisiblePosition = 4;
            band2.Columns.Add(column6);
            column6.Header.VisiblePosition = 5;
            band2.Columns.Add(column9);
            column9.Header.VisiblePosition = 6;
            band2.Columns.Add(column15);
            column15.Header.VisiblePosition = 7;
            band2.Columns.Add(column13);
            column13.Header.VisiblePosition = 8;
            band2.Columns.Add(column14);
            column14.Header.VisiblePosition = 9;
            band2.Columns.Add(column16);
            column16.Header.VisiblePosition = 10;
            band2.Columns.Add(column11);
            column11.Header.VisiblePosition = 11;
            band2.Columns.Add(column7);
            column7.Header.VisiblePosition = 12;
            this.grdLevelDDKATEGORIJALevel1.Visible = true;
            this.grdLevelDDKATEGORIJALevel1.Name = "grdLevelDDKATEGORIJALevel1";
            this.grdLevelDDKATEGORIJALevel1.Tag = "DDKATEGORIJALevel1";
            this.grdLevelDDKATEGORIJALevel1.TabIndex = 0x18;
            this.grdLevelDDKATEGORIJALevel1.Dock = DockStyle.Fill;
            this.grdLevelDDKATEGORIJALevel1.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelDDKATEGORIJALevel1.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelDDKATEGORIJALevel1.DataSource = this.bindingSourceDDKATEGORIJALevel1;
            this.grdLevelDDKATEGORIJALevel1.Enter += new EventHandler(this.grdLevelDDKATEGORIJALevel1_Enter);
            this.grdLevelDDKATEGORIJALevel1.AfterRowInsert += new RowEventHandler(this.grdLevelDDKATEGORIJALevel1_AfterRowInsert);
            this.grdLevelDDKATEGORIJALevel1.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelDDKATEGORIJALevel1.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelDDKATEGORIJALevel1.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelDDKATEGORIJALevel1.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelDDKATEGORIJALevel1_DoubleClick);
            this.grdLevelDDKATEGORIJALevel1.AfterRowActivate += new EventHandler(this.grdLevelDDKATEGORIJALevel1_AfterRowActivate);
            this.grdLevelDDKATEGORIJALevel1.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelDDKATEGORIJALevel1.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelDDKATEGORIJALevel1.DisplayLayout.BandsSerializer.Add(band2);
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.Disabled;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.DDKATEGORIJAIDKATEGORIJADescription;
            column20.Width = 0x33;
            appearance20.TextHAlign = HAlign.Right;
            column20.MaskInput = "{LOC}-nnnnn";
            column20.PromptChar = ' ';
            column20.Format = "";
            column20.CellAppearance = appearance20;
            column20.Hidden = true;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.DDKATEGORIJAIDDOPRINOSDescription;
            column19.Width = 0x77;
            appearance19.TextHAlign = HAlign.Right;
            column19.MaskInput = "{LOC}-nnnnnnnn";
            column19.PromptChar = ' ';
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.Disabled;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.DDKATEGORIJANAZIVDOPRINOSDescription;
            column24.Width = 0x128;
            column24.Format = "";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.Disabled;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.DDKATEGORIJAIDVRSTADOPRINOSDescription;
            column21.Width = 0x9f;
            appearance21.TextHAlign = HAlign.Right;
            column21.MaskInput = "{LOC}-nnnnn";
            column21.PromptChar = ' ';
            column21.Format = "";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.Disabled;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.DDKATEGORIJANAZIVVRSTADOPRINOSDescription;
            column25.Width = 0x128;
            column25.Format = "";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.Disabled;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.DDKATEGORIJAMODOPRINOSDescription;
            column22.Width = 0xbf;
            column22.Format = "";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.Disabled;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.DDKATEGORIJAPODOPRINOSDescription;
            column27.Width = 0xbf;
            column27.Format = "";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.Disabled;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.DDKATEGORIJAMZDOPRINOSDescription;
            column23.Width = 0xbf;
            column23.Format = "";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column30.CellActivation = Activation.Disabled;
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.DDKATEGORIJAPZDOPRINOSDescription;
            column30.Width = 0xbf;
            column30.Format = "";
            column30.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.Disabled;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.DDKATEGORIJAPRIMATELJDOPRINOS1Description;
            column28.Width = 0x9c;
            column28.Format = "";
            column28.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.Disabled;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.DDKATEGORIJAPRIMATELJDOPRINOS2Description;
            column29.Width = 0xb1;
            column29.Format = "";
            column29.CellAppearance = appearance29;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.Disabled;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.DDKATEGORIJASIFRAOPISAPLACANJADOPRINOSDescription;
            column31.Width = 0xe2;
            column31.Format = "";
            column31.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.Disabled;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.DDKATEGORIJAOPISPLACANJADOPRINOSDescription;
            column26.Width = 0x10c;
            column26.Format = "";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column33.CellActivation = Activation.Disabled;
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.DDKATEGORIJAVBDIDOPRINOSDescription;
            column33.Width = 0x80;
            column33.Format = "";
            column33.CellAppearance = appearance33;
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            column34.CellActivation = Activation.Disabled;
            column34.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column34.Header.Caption = StringResources.DDKATEGORIJAZRNDOPRINOSDescription;
            column34.Width = 170;
            column34.Format = "";
            column34.CellAppearance = appearance34;
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column32.CellActivation = Activation.Disabled;
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.DDKATEGORIJASTOPADescription;
            column32.Width = 0x37;
            appearance32.TextHAlign = HAlign.Right;
            column32.MaskInput = "{LOC}-nnn.nn";
            column32.PromptChar = ' ';
            column32.Format = "F2";
            column32.CellAppearance = appearance32;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.DDKATEGORIJADOPRINOSDRUGOGSTUPADescription;
            column18.Width = 0xcd;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            band3.Columns.Add(column19);
            column19.Header.VisiblePosition = 0;
            band3.Columns.Add(column24);
            column24.Header.VisiblePosition = 1;
            band3.Columns.Add(column21);
            column21.Header.VisiblePosition = 2;
            band3.Columns.Add(column25);
            column25.Header.VisiblePosition = 3;
            band3.Columns.Add(column22);
            column22.Header.VisiblePosition = 4;
            band3.Columns.Add(column27);
            column27.Header.VisiblePosition = 5;
            band3.Columns.Add(column23);
            column23.Header.VisiblePosition = 6;
            band3.Columns.Add(column30);
            column30.Header.VisiblePosition = 7;
            band3.Columns.Add(column28);
            column28.Header.VisiblePosition = 8;
            band3.Columns.Add(column29);
            column29.Header.VisiblePosition = 9;
            band3.Columns.Add(column31);
            column31.Header.VisiblePosition = 10;
            band3.Columns.Add(column26);
            column26.Header.VisiblePosition = 11;
            band3.Columns.Add(column33);
            column33.Header.VisiblePosition = 12;
            band3.Columns.Add(column34);
            column34.Header.VisiblePosition = 13;
            band3.Columns.Add(column32);
            column32.Header.VisiblePosition = 14;
            band3.Columns.Add(column18);
            column18.Header.VisiblePosition = 15;
            band3.Columns.Add(column20);
            column20.Header.VisiblePosition = 0x10;
            this.grdLevelDDKATEGORIJALevel3.Visible = true;
            this.grdLevelDDKATEGORIJALevel3.Name = "grdLevelDDKATEGORIJALevel3";
            this.grdLevelDDKATEGORIJALevel3.Tag = "DDKATEGORIJALevel3";
            this.grdLevelDDKATEGORIJALevel3.TabIndex = 0x18;
            this.grdLevelDDKATEGORIJALevel3.Dock = DockStyle.Fill;
            this.grdLevelDDKATEGORIJALevel3.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelDDKATEGORIJALevel3.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelDDKATEGORIJALevel3.DataSource = this.bindingSourceDDKATEGORIJALevel3;
            this.grdLevelDDKATEGORIJALevel3.Enter += new EventHandler(this.grdLevelDDKATEGORIJALevel3_Enter);
            this.grdLevelDDKATEGORIJALevel3.AfterRowInsert += new RowEventHandler(this.grdLevelDDKATEGORIJALevel3_AfterRowInsert);
            this.grdLevelDDKATEGORIJALevel3.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelDDKATEGORIJALevel3.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelDDKATEGORIJALevel3.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelDDKATEGORIJALevel3.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelDDKATEGORIJALevel3_DoubleClick);
            this.grdLevelDDKATEGORIJALevel3.AfterRowActivate += new EventHandler(this.grdLevelDDKATEGORIJALevel3_AfterRowActivate);
            this.grdLevelDDKATEGORIJALevel3.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelDDKATEGORIJALevel3.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelDDKATEGORIJALevel3.DisplayLayout.BandsSerializer.Add(band3);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.Disabled;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.DDKATEGORIJAIDKATEGORIJADescription;
            column4.Width = 0x33;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnn";
            column4.PromptChar = ' ';
            column4.Format = "";
            column4.CellAppearance = appearance4;
            column4.Hidden = true;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.DDKATEGORIJADDIDIZDATAKDescription;
            column.Width = 0x33;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.Disabled;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.DDKATEGORIJADDNAZIVIZDATKADescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.Disabled;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.DDKATEGORIJADDPOSTOTAKIZDATKADescription;
            column3.Width = 0x81;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            this.grdLevelDDKATEGORIJAIzdaci.Visible = true;
            this.grdLevelDDKATEGORIJAIzdaci.Name = "grdLevelDDKATEGORIJAIzdaci";
            this.grdLevelDDKATEGORIJAIzdaci.Tag = "DDKATEGORIJAIzdaci";
            this.grdLevelDDKATEGORIJAIzdaci.TabIndex = 0x18;
            this.grdLevelDDKATEGORIJAIzdaci.Dock = DockStyle.Fill;
            this.grdLevelDDKATEGORIJAIzdaci.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.grdLevelDDKATEGORIJAIzdaci.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.grdLevelDDKATEGORIJAIzdaci.DataSource = this.bindingSourceDDKATEGORIJAIzdaci;
            this.grdLevelDDKATEGORIJAIzdaci.Enter += new EventHandler(this.grdLevelDDKATEGORIJAIzdaci_Enter);
            this.grdLevelDDKATEGORIJAIzdaci.AfterRowInsert += new RowEventHandler(this.grdLevelDDKATEGORIJAIzdaci_AfterRowInsert);
            this.grdLevelDDKATEGORIJAIzdaci.AfterCellActivate += new EventHandler(this.CellChanged);
            this.grdLevelDDKATEGORIJAIzdaci.ClickCellButton += new CellEventHandler(this.dg_ClickCellButton);
            this.grdLevelDDKATEGORIJAIzdaci.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.grdLevelDDKATEGORIJAIzdaci.DoubleClickRow += new DoubleClickRowEventHandler(this.grdLevelDDKATEGORIJAIzdaci_DoubleClick);
            this.grdLevelDDKATEGORIJAIzdaci.AfterRowActivate += new EventHandler(this.grdLevelDDKATEGORIJAIzdaci_AfterRowActivate);
            this.grdLevelDDKATEGORIJAIzdaci.DisplayLayout.Override.AllowAddNew = AllowAddNew.Yes;
            this.grdLevelDDKATEGORIJAIzdaci.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            this.grdLevelDDKATEGORIJAIzdaci.DisplayLayout.BandsSerializer.Add(band);
            this.Name = "DDKATEGORIJAFormUserControl";
            this.Text = "Kategorija drugog dohotka";
            this.AutoSize = true;
            this.AutoScroll = true;
            this.Load += new EventHandler(this.DDKATEGORIJAFormUserControl_Load);
            this.layoutManagerformDDKATEGORIJA.ResumeLayout(false);
            this.layoutManagerformDDKATEGORIJA.PerformLayout();
            ((ISupportInitialize) this.bindingSourceDDKATEGORIJA).EndInit();
            ((ISupportInitialize) this.bindingSourceDDKATEGORIJALevel1).EndInit();
            ((ISupportInitialize) this.bindingSourceDDKATEGORIJALevel3).EndInit();
            ((ISupportInitialize) this.bindingSourceDDKATEGORIJAIzdaci).EndInit();
            ((ISupportInitialize) this.textIDKATEGORIJA).EndInit();
            ((ISupportInitialize) this.textNAZIVKATEGORIJA).EndInit();
            ((ISupportInitialize) this.grdLevelDDKATEGORIJALevel1).EndInit();
            this.panelactionsDDKATEGORIJALevel1.ResumeLayout(true);
            this.panelactionsDDKATEGORIJALevel1.PerformLayout();
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.ResumeLayout(false);
            this.layoutManagerpanelactionsDDKATEGORIJALevel1.PerformLayout();
            ((ISupportInitialize) this.grdLevelDDKATEGORIJALevel3).EndInit();
            this.panelactionsDDKATEGORIJALevel3.ResumeLayout(true);
            this.panelactionsDDKATEGORIJALevel3.PerformLayout();
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.ResumeLayout(false);
            this.layoutManagerpanelactionsDDKATEGORIJALevel3.PerformLayout();
            ((ISupportInitialize) this.grdLevelDDKATEGORIJAIzdaci).EndInit();
            this.panelactionsDDKATEGORIJAIzdaci.ResumeLayout(true);
            this.panelactionsDDKATEGORIJAIzdaci.PerformLayout();
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.ResumeLayout(false);
            this.layoutManagerpanelactionsDDKATEGORIJAIzdaci.PerformLayout();
            this.dsDDKATEGORIJADataSet1.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private bool InValidState()
        {
            if ((this.Controller.WorkItem.Status != WorkItemStatus.Active) || !GenericFormClass.EndEditBindingSource(this.bindingSourceDDKATEGORIJA, this.Controller.WorkItem, this))
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
            this.label1IDKATEGORIJA.Text = StringResources.DDKATEGORIJAIDKATEGORIJADescription;
            this.label1NAZIVKATEGORIJA.Text = StringResources.DDKATEGORIJANAZIVKATEGORIJADescription;
            this.label1IDKOLONAIDD.Text = StringResources.DDKATEGORIJAIDKOLONAIDDDescription;
        }

        private void mouseEnter_Text(object sender, EventArgs e)
        {
            this.m_BaseMethods.MouseEnterTextBase(this.toolTip1, this.m_CurrentRow, RuntimeHelpers.GetObjectValue(sender));
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
        }

        private void PictureBoxClickedIDKOLONAIDD(object sender, EventArgs e)
        {
            EventHandler<OpenComponentEventArgs> startProcessEvent = this.StartProcess;
            if (startProcessEvent != null)
            {
                startProcessEvent(RuntimeHelpers.GetObjectValue(sender), new OpenComponentEventArgs("DDKOLONAIDD", null, DeklaritMode.Insert));
            }
        }

        private void RegisterBindingSources()
        {
            if (!this.Controller.WorkItem.Items.Contains("DDKATEGORIJA|DDKATEGORIJA"))
            {
                this.Controller.WorkItem.Items.Add(this.bindingSourceDDKATEGORIJA, "DDKATEGORIJA|DDKATEGORIJA");
            }
            if (!this.Controller.WorkItem.Items.Contains("DDKATEGORIJA|DDKATEGORIJALevel1"))
            {
                this.Controller.WorkItem.Items.Add(this.bindingSourceDDKATEGORIJALevel1, "DDKATEGORIJA|DDKATEGORIJALevel1");
            }
            if (!this.Controller.WorkItem.Items.Contains("DDKATEGORIJA|DDKATEGORIJALevel3"))
            {
                this.Controller.WorkItem.Items.Add(this.bindingSourceDDKATEGORIJALevel3, "DDKATEGORIJA|DDKATEGORIJALevel3");
            }
            if (!this.Controller.WorkItem.Items.Contains("DDKATEGORIJA|DDKATEGORIJAIzdaci"))
            {
                this.Controller.WorkItem.Items.Add(this.bindingSourceDDKATEGORIJAIzdaci, "DDKATEGORIJA|DDKATEGORIJAIzdaci");
            }
        }

        [OnBuiltUp]
        public void RegisterUserControls()
        {
        }

        public void ResumeBindingPostUpdate()
        {
            if ((this.dsDDKATEGORIJADataSet1.DDKATEGORIJA.Rows[0] != null) && this.m_BaseMethods.IsInsert())
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
                this.Controller.DataSet = new DDKATEGORIJADataSet();
                DataSetUtil.AddEmptyRow(this.Controller.DataSet);
                this.ChangeBinding();
                this.m_CurrentRow = this.Controller.DataSet.DDKATEGORIJA[0];
                DataSetUtil.CopyForeignKeyValues(this.m_CurrentRow, this.m_ForeignKeys);
                this.SetFocusInFirstField();
            }
        }

        private void SelectedIndexChangedIDKOLONAIDD(object sender, EventArgs e)
        {
            if ((this.m_BaseMethods != null) && (this.comboIDKOLONAIDD.SelectedItem != null))
            {
                DataRow row = ((DataRowView) this.comboIDKOLONAIDD.SelectedItem.ListObject).Row;
                if (row != null)
                {
                    ((DataRowView) this.bindingSourceDDKATEGORIJA.Current).Row["IDKOLONAIDD"] = RuntimeHelpers.GetObjectValue(row["IDKOLONAIDD"]);
                    ((DataRowView) this.bindingSourceDDKATEGORIJA.Current).Row["NAZIVKOLONAIDD"] = RuntimeHelpers.GetObjectValue(row["NAZIVKOLONAIDD"]);
                    this.bindingSourceDDKATEGORIJA.ResetCurrentItem();
                }
            }
        }

        private void SetComboBoxColumnProperties()
        {
            UltraGridColumn gridColumn = FormHelperClass.GetGridColumn(this.grdLevelDDKATEGORIJALevel1, "IDPOREZ");
            gridColumn.Tag = "POREZIDPOREZ";
            gridColumn.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            gridColumn.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            UltraGridColumn column3 = FormHelperClass.GetGridColumn(this.grdLevelDDKATEGORIJALevel3, "IDDOPRINOS");
            column3.Tag = "DOPRINOSIDDOPRINOS";
            column3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            UltraGridColumn column = FormHelperClass.GetGridColumn(this.grdLevelDDKATEGORIJAIzdaci, "DDIDIZDATAK");
            column.Tag = "DDIZDATAKDDIDIZDATAK";
            column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
        }

        private void SetFocusInFirstField()
        {
            this.textIDKATEGORIJA.Focus();
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

        protected virtual DDKOLONAIDDComboBox comboIDKOLONAIDD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDKOLONAIDD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDKOLONAIDD = value;
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

        [Browsable(false), CreateNew]
        public NetAdvantage.Controllers.DDKATEGORIJAController Controller { get; set; }

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

        protected virtual UltraGrid grdLevelDDKATEGORIJAIzdaci
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelDDKATEGORIJAIzdaci;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelDDKATEGORIJAIzdaci = value;
            }
        }

        protected virtual UltraGrid grdLevelDDKATEGORIJALevel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelDDKATEGORIJALevel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelDDKATEGORIJALevel1 = value;
            }
        }

        protected virtual UltraGrid grdLevelDDKATEGORIJALevel3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._grdLevelDDKATEGORIJALevel3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._grdLevelDDKATEGORIJALevel3 = value;
            }
        }

        protected virtual UltraLabel label1IDKATEGORIJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDKATEGORIJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDKATEGORIJA = value;
            }
        }

        protected virtual UltraLabel label1IDKOLONAIDD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDKOLONAIDD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDKOLONAIDD = value;
            }
        }

        protected virtual UltraLabel label1NAZIVKATEGORIJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVKATEGORIJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVKATEGORIJA = value;
            }
        }

        protected virtual UltraLabel linkLabelDDKATEGORIJAIzdaci
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelDDKATEGORIJAIzdaci;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelDDKATEGORIJAIzdaci = value;
            }
        }

        protected virtual UltraLabel linkLabelDDKATEGORIJAIzdaciAdd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelDDKATEGORIJAIzdaciAdd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelDDKATEGORIJAIzdaciAdd = value;
            }
        }

        protected virtual UltraLabel linkLabelDDKATEGORIJAIzdaciDelete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelDDKATEGORIJAIzdaciDelete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelDDKATEGORIJAIzdaciDelete = value;
            }
        }

        protected virtual UltraLabel linkLabelDDKATEGORIJAIzdaciUpdate
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelDDKATEGORIJAIzdaciUpdate;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelDDKATEGORIJAIzdaciUpdate = value;
            }
        }

        protected virtual UltraLabel linkLabelDDKATEGORIJALevel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelDDKATEGORIJALevel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelDDKATEGORIJALevel1 = value;
            }
        }

        protected virtual UltraLabel linkLabelDDKATEGORIJALevel1Add
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelDDKATEGORIJALevel1Add;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelDDKATEGORIJALevel1Add = value;
            }
        }

        protected virtual UltraLabel linkLabelDDKATEGORIJALevel1Delete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelDDKATEGORIJALevel1Delete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelDDKATEGORIJALevel1Delete = value;
            }
        }

        protected virtual UltraLabel linkLabelDDKATEGORIJALevel1Update
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelDDKATEGORIJALevel1Update;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelDDKATEGORIJALevel1Update = value;
            }
        }

        protected virtual UltraLabel linkLabelDDKATEGORIJALevel3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelDDKATEGORIJALevel3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelDDKATEGORIJALevel3 = value;
            }
        }

        protected virtual UltraLabel linkLabelDDKATEGORIJALevel3Add
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelDDKATEGORIJALevel3Add;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelDDKATEGORIJALevel3Add = value;
            }
        }

        protected virtual UltraLabel linkLabelDDKATEGORIJALevel3Delete
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelDDKATEGORIJALevel3Delete;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelDDKATEGORIJALevel3Delete = value;
            }
        }

        protected virtual UltraLabel linkLabelDDKATEGORIJALevel3Update
        {
            [DebuggerNonUserCode]
            get
            {
                return this._linkLabelDDKATEGORIJALevel3Update;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._linkLabelDDKATEGORIJALevel3Update = value;
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

        protected virtual Panel panelactionsDDKATEGORIJAIzdaci
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsDDKATEGORIJAIzdaci;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsDDKATEGORIJAIzdaci = value;
            }
        }

        protected virtual Panel panelactionsDDKATEGORIJALevel1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsDDKATEGORIJALevel1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsDDKATEGORIJALevel1 = value;
            }
        }

        protected virtual Panel panelactionsDDKATEGORIJALevel3
        {
            [DebuggerNonUserCode]
            get
            {
                return this._panelactionsDDKATEGORIJALevel3;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._panelactionsDDKATEGORIJALevel3 = value;
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

        protected virtual UltraNumericEditor textIDKATEGORIJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDKATEGORIJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDKATEGORIJA = value;
            }
        }

        protected virtual UltraTextEditor textNAZIVKATEGORIJA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVKATEGORIJA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVKATEGORIJA = value;
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

