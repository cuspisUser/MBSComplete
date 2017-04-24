namespace NetAdvantage.SmartParts
{
    using Deklarit;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Practices.CompositeUI.NetAdvantage.Services;
    using Deklarit.Practices.CompositeUI.Services;
    using Deklarit.Resources;
    using Infragistics.Win;
    using Infragistics.Win.Printing;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinGrid.ExcelExport;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.EventBroker;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class GOOBRACUNWorkWith : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridGOOBRACUN")]
        private GOOBRACUNUserDataGrid _userControlDataGridGOOBRACUN;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public GOOBRACUNWorkWith()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.GOOBRACUNDescription), string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.GOOBRACUNDescription));
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridGOOBRACUN.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<GOOBRACUNDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<GOOBRACUNDataSet>(this.userControlDataGridGOOBRACUN.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        [LocalCommandHandler("Copy")]
        public void CopyHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.Copy(this.CurrentDataRow);
            }
        }

        private void DataGrid_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.CurrentDataRow != null)
            {
                this.Controller.CurrentRow = this.CurrentDataRow;
            }
        }

        private void DataGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (!this.userControlDataGridGOOBRACUN.DataGrid.GridLoading && ((this.userControlDataGridGOOBRACUN.DataGrid.ActiveRow != null) && (this.userControlDataGridGOOBRACUN.DataGrid.ActiveCell != null)))
            {
                this.DefaultAction();
            }
        }

        private void DataGrid_SetFocus()
        {
            if ((this.userControlDataGridGOOBRACUN.DataGrid.Rows.Count > 0) && (this.userControlDataGridGOOBRACUN.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridGOOBRACUN.DataGrid.Rows[0].Activate();
            }
        }

        private void DefaultAction()
        {
            if (this.InValidState())
            {
                this.Controller.Update(this.CurrentDataRow);
            }
        }

        [LocalCommandHandler("Delete")]
        public void DeleteHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.Delete(this.CurrentDataRow);
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

        [LocalCommandHandler("ExportExcel")]
        public void ExportExcelHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    DefaultExt = "xls",
                    Filter = "Excel file (*.xls)|*.xls"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    new UltraGridExcelExporter().Export(this.userControlDataGridGOOBRACUN.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridGOOBRACUN.DataGrid.FillByPage;
                this.userControlDataGridGOOBRACUN.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridGOOBRACUN.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                if (this.m_FillByMethod == "FillByIDRADNIK")
                {
                    this.FillFillByIDRADNIK();
                }
                else
                {
                    this.userControlDataGridGOOBRACUN.FillMethod = "Fill";
                }
                this.userControlDataGridGOOBRACUN.Fill();
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    ((GOOBRACUNSelectionListWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridGOOBRACUN.DataView.Table.DataSet;
                }
                else
                {
                    ((GOOBRACUNWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridGOOBRACUN.DataView.Table.DataSet;
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        private void FillFillByIDRADNIK()
        {
            string str = "";
            this.userControlDataGridGOOBRACUN.FillMethod = "FillByIDRADNIK";
            this.userControlDataGridGOOBRACUN.FillByIDRADNIKIDRADNIK = Conversions.ToInteger(this.GetValueFromRow("IDRADNIK", "IDRADNIK"));
            str = str + "," + this.userControlDataGridGOOBRACUN.FillByIDRADNIKIDRADNIK.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Godišnji odbici i olakšice " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Godišnji odbici i olakšice " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private object GetValueFromRow(string fieldSuperTypeName, string fieldName)
        {
            if (this.m_FillByRow.Table.Columns.Contains(fieldSuperTypeName))
            {
                return this.m_FillByRow[fieldSuperTypeName];
            }
            return this.m_FillByRow[fieldName];
        }

        private void GOOBRACUNWorkWith_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridGOOBRACUN.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridGOOBRACUN.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridGOOBRACUN.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridGOOBRACUN.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridGOOBRACUN.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridGOOBRACUN.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridGOOBRACUN.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.FillData();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(GOOBRACUNWorkWith));
            this.userControlDataGridGOOBRACUN = new GOOBRACUNUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.userControlDataGridGOOBRACUN.Name = "userControlDataGridGOOBRACUN";
            this.userControlDataGridGOOBRACUN.Dock = DockStyle.Fill;
            this.userControlDataGridGOOBRACUN.DockPadding.All = 5;
            this.userControlDataGridGOOBRACUN.FillAtStartup = false;
            this.userControlDataGridGOOBRACUN.TabIndex = 6;
            Size size = new System.Drawing.Size(0x2d8, 400);
            this.userControlDataGridGOOBRACUN.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridGOOBRACUN.DataGrid;
            this.Controls.Add(this.userControlDataGridGOOBRACUN);
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "GOOBRACUNWorkWith";
            this.Text = "Work With Godišnji odbici i olakšice";
            this.Load += new EventHandler(this.GOOBRACUNWorkWith_Load);
            this.ResumeLayout(false);
        }

        [LocalCommandHandler("Insert")]
        public void InsertHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.Controller.Insert(this.m_FillByRow);
            }
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        [LocalCommandHandler("cmdPuni")]
        public void IspisiKrediteHandler(object sender, EventArgs e)
        {
            this.PuniTablicu();
        }

        [LocalCommandHandler("Print")]
        public void PrintHandler(object sender, EventArgs e)
        {
            if (Information.IsNothing(this.ultraPrintPreviewDialog1.Document))
            {
                this.ultraPrintPreviewDialog1.Document = this.ultraGridPrintDocument1;
                this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
                this.ultraPrintPreviewDialog1.Document.DocumentName = "";
                this.ultraPrintPreviewDialog1.Text = "";
            }
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.ultraPrintPreviewDialog1.ShowDialog(this);
            }
        }

        public void PuniTablicu()
        {
            if (Interaction.MsgBox("Želite li stvarno izbrisati postojeće podatke \r\n i napuniti tablicu prava na godišnje odbitke\r\n sa novim podacima???", MsgBoxStyle.YesNo, null) != MsgBoxResult.No)
            {
                DataRow current;
                IEnumerator enumerator = null;
                IEnumerator enumerator2 = null;
                try
                {
                    enumerator = this.userControlDataGridGOOBRACUN.DataGrid.DataSet.GOOBRACUN.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (DataRow) enumerator.Current;
                        current.Delete();
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                GOOBRACUNDataAdapter adapter2 = new GOOBRACUNDataAdapter();
                adapter2.Update(this.userControlDataGridGOOBRACUN.DataGrid.DataSet);
                S_PLACA_ODBICI_GODINADataAdapter adapter = new S_PLACA_ODBICI_GODINADataAdapter();
                S_PLACA_ODBICI_GODINADataSet dataSet = new S_PLACA_ODBICI_GODINADataSet();
                adapter.Fill(dataSet, "2010");
                try
                {
                    enumerator2 = dataSet.S_PLACA_ODBICI_GODINA.Rows.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        DataRow row2 = (DataRow) enumerator2.Current;
                        current = this.userControlDataGridGOOBRACUN.DataGrid.DataSet.GOOBRACUN.NewRow();
                        current["IDRADNIK"] = RuntimeHelpers.GetObjectValue(row2["IDRADNIK"]);
                        current["ODBICIISKORISTIVO"] = RuntimeHelpers.GetObjectValue(row2["ODBITAK"]);
                        current["OLAKSICEISKORISTIVO"] = RuntimeHelpers.GetObjectValue(row2["OLAKSICE"]);
                        this.userControlDataGridGOOBRACUN.DataGrid.DataSet.GOOBRACUN.Rows.Add(current);
                    }
                }
                finally
                {
                    if (enumerator2 is IDisposable)
                    {
                        (enumerator2 as IDisposable).Dispose();
                    }
                }
                adapter2.Update(this.userControlDataGridGOOBRACUN.DataGrid.DataSet);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/GOOBRACUN", Thread=ThreadOption.UserInterface)]
        public void RefreshGrid(object sender, ComponentEventArgs args)
        {
            this.FillData();
        }

        [LocalCommandHandler("Refresh")]
        public void RefreshHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.FillData();
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridGOOBRACUN.DataGrid.DisplayLayout.UIElement.LastElementEntered;
            if (lastElementEntered is RowUIElement)
            {
                ancestor = (RowUIElement) lastElementEntered;
            }
            else
            {
                ancestor = (RowUIElement) lastElementEntered.GetAncestor(typeof(RowUIElement));
            }
            if (ancestor != null)
            {
                this.SelectHandler(RuntimeHelpers.GetObjectValue(sender), e);
            }
        }

        [LocalCommandHandler("Select")]
        public void SelectHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.m_RowSelected = this.CurrentDataRow;
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetSmartPartInfoInformation()
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.smartPartInfo1.Title = string.Format("{0} Godišnji odbici i olakšice ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} Godišnji odbici i olakšice ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [LocalCommandHandler("Update")]
        public void UpdateHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.Update(this.CurrentDataRow);
            }
        }

        [LocalCommandHandler("View")]
        public void View(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.View(this.CurrentDataRow);
            }
        }

        [CreateNew]
        public GOOBRACUNWorkWithController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridGOOBRACUN.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridGOOBRACUN.DataView[this.userControlDataGridGOOBRACUN.DataGrid.CurrentRowIndex].Row;
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.FillByRow
        {
            set
            {
                this.m_FillByRow = value;
                this.SetSmartPartInfoInformation();
            }
        }

        string Deklarit.Practices.CompositeUI.IFilteredView.FillMethod
        {
            set
            {
                this.m_FillByMethod = value;
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode Deklarit.Practices.CompositeUI.IFilteredView.WorkWithMode
        {
            set
            {
                this.m_WorkWithMode = value;
                this.SetSmartPartInfoInformation();
            }
        }

        public DataRow FillByRow
        {
            set
            {
                this.m_FillByRow = value;
                this.SetSmartPartInfoInformation();
            }
        }

        public string FillMethod
        {
            set
            {
                this.m_FillByMethod = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        private GOOBRACUNUserDataGrid userControlDataGridGOOBRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridGOOBRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridGOOBRACUN = value;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
                this.m_WorkWithMode = value;
                this.SetSmartPartInfoInformation();
            }
        }
    }
}

