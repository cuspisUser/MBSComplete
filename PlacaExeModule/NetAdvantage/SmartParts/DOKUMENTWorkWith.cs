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
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using Placa;
    using System.Windows.Forms;

    [SmartPart]
    public class DOKUMENTWorkWith : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridDOKUMENT")]
        private DOKUMENTUserDataGrid _userControlDataGridDOKUMENT;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public DOKUMENTWorkWith()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.DOKUMENTDescription), string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.DOKUMENTDescription));
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridDOKUMENT.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<DOKUMENTDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<DOKUMENTDataSet>(this.userControlDataGridDOKUMENT.DataGrid);
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
            if (!this.userControlDataGridDOKUMENT.DataGrid.GridLoading && ((this.userControlDataGridDOKUMENT.DataGrid.ActiveRow != null) && (this.userControlDataGridDOKUMENT.DataGrid.ActiveCell != null)))
            {
                this.DefaultAction();
            }
        }

        private void DataGrid_SetFocus()
        {
            if ((this.userControlDataGridDOKUMENT.DataGrid.Rows.Count > 0) && (this.userControlDataGridDOKUMENT.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridDOKUMENT.DataGrid.Rows[0].Activate();
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

        private void DOKUMENTWorkWith_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridDOKUMENT.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridDOKUMENT.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridDOKUMENT.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridDOKUMENT.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridDOKUMENT.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridDOKUMENT.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridDOKUMENT.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridDOKUMENT.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.userControlDataGridDOKUMENT.FillByPage = false;
            this.FillData();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridDOKUMENT.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridDOKUMENT.DataGrid.FillByPage;
                this.userControlDataGridDOKUMENT.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridDOKUMENT.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                if (this.m_FillByMethod == "FillByIDTIPDOKUMENTA")
                {
                    this.FillFillByIDTIPDOKUMENTA();
                }
                else
                {
                    this.userControlDataGridDOKUMENT.FillMethod = "Fill";
                }
                this.userControlDataGridDOKUMENT.Fill();
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    ((DOKUMENTSelectionListWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridDOKUMENT.DataView.Table.DataSet;
                }
                else
                {
                    ((DOKUMENTWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridDOKUMENT.DataView.Table.DataSet;
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        private void FillFillByIDTIPDOKUMENTA()
        {
            string str = "";
            this.userControlDataGridDOKUMENT.FillMethod = "FillByIDTIPDOKUMENTA";
            this.userControlDataGridDOKUMENT.FillByIDTIPDOKUMENTAIDTIPDOKUMENTA = Conversions.ToInteger(this.GetValueFromRow("IDTIPDOKUMENTA", "IDTIPDOKUMENTA"));
            str = str + "," + this.userControlDataGridDOKUMENT.FillByIDTIPDOKUMENTAIDTIPDOKUMENTA.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "DOKUMENT " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "DOKUMENT " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(DOKUMENTWorkWith));
            this.userControlDataGridDOKUMENT = new DOKUMENTUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.userControlDataGridDOKUMENT.Name = "userControlDataGridDOKUMENT";
            this.userControlDataGridDOKUMENT.Dock = DockStyle.Fill;
            this.userControlDataGridDOKUMENT.DockPadding.All = 5;
            this.userControlDataGridDOKUMENT.FillAtStartup = false;
            this.userControlDataGridDOKUMENT.TabIndex = 6;
            Size size = new System.Drawing.Size(0x2d8, 400);
            this.userControlDataGridDOKUMENT.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridDOKUMENT.DataGrid;
            this.Controls.Add(this.userControlDataGridDOKUMENT);
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "DOKUMENTWorkWith";
            this.Text = "Work With DOKUMENT";
            this.Load += new EventHandler(this.DOKUMENTWorkWith_Load);
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

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/DOKUMENT", Thread=ThreadOption.UserInterface)]
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
            UIElement lastElementEntered = this.userControlDataGridDOKUMENT.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} DOKUMENT ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} DOKUMENT ", Deklarit.Resources.Resources.Workwith);
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
        public DOKUMENTWorkWithController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridDOKUMENT.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridDOKUMENT.DataView[this.userControlDataGridDOKUMENT.DataGrid.CurrentRowIndex].Row;
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

        private DOKUMENTUserDataGrid userControlDataGridDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridDOKUMENT = value;
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

