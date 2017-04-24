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
    using System.Windows.Forms;
    using Placa;

    [SmartPart]
    public class OLAKSICEWorkWith : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public OLAKSICEWorkWith()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.OLAKSICEDescription), string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.OLAKSICEDescription));
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridOLAKSICE.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<OLAKSICEDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<OLAKSICEDataSet>(this.userControlDataGridOLAKSICE.DataGrid);
            this.OLAKSICEWorkWithController.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        [LocalCommandHandler("Copy")]
        public void CopyHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OLAKSICEWorkWithController.Copy(this.CurrentDataRow);
            }
        }

        private void DataGrid_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.CurrentDataRow != null)
            {
                this.OLAKSICEWorkWithController.CurrentRow = this.CurrentDataRow;
            }
        }

        private void DataGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (!this.userControlDataGridOLAKSICE.DataGrid.GridLoading && ((this.userControlDataGridOLAKSICE.DataGrid.ActiveRow != null) && (this.userControlDataGridOLAKSICE.DataGrid.ActiveCell != null)))
            {
                this.DefaultAction();
            }
        }

        private void DataGrid_SetFocus()
        {
            if ((this.userControlDataGridOLAKSICE.DataGrid.Rows.Count > 0) && (this.userControlDataGridOLAKSICE.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridOLAKSICE.DataGrid.Rows[0].Activate();
            }
        }

        private void DefaultAction()
        {
            if (this.InValidState())
            {
                this.OLAKSICEWorkWithController.Update(this.CurrentDataRow);
            }
        }

        [LocalCommandHandler("Delete")]
        public void DeleteHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OLAKSICEWorkWithController.Delete(this.CurrentDataRow);
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
            if (this.OLAKSICEWorkWithController.WorkItem.Status == WorkItemStatus.Active)
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    DefaultExt = "xls",
                    Filter = "Excel file (*.xls)|*.xls"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    new UltraGridExcelExporter().Export(this.userControlDataGridOLAKSICE.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.OLAKSICEWorkWithController.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridOLAKSICE.DataGrid.FillByPage;
                this.userControlDataGridOLAKSICE.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridOLAKSICE.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                string fillByMethod = this.m_FillByMethod;
                if (fillByMethod == "FillByIDGRUPEOLAKSICA")
                {
                    this.FillFillByIDGRUPEOLAKSICA();
                }
                else if (fillByMethod == "FillByIDTIPOLAKSICE")
                {
                    this.FillFillByIDTIPOLAKSICE();
                }
                else
                {
                    this.userControlDataGridOLAKSICE.FillMethod = "Fill";
                }
                this.userControlDataGridOLAKSICE.Fill();
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    ((OLAKSICESelectionListWorkItem) this.OLAKSICEWorkWithController.WorkItem).DataSet = this.userControlDataGridOLAKSICE.DataView.Table.DataSet;
                }
                else
                {
                    ((OLAKSICEWorkWithWorkItem) this.OLAKSICEWorkWithController.WorkItem).DataSet = this.userControlDataGridOLAKSICE.DataView.Table.DataSet;
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        private void FillFillByIDGRUPEOLAKSICA()
        {
            string str = "";
            this.userControlDataGridOLAKSICE.FillMethod = "FillByIDGRUPEOLAKSICA";
            this.userControlDataGridOLAKSICE.FillByIDGRUPEOLAKSICAIDGRUPEOLAKSICA = Conversions.ToInteger(this.GetValueFromRow("IDGRUPEOLAKSICA", "IDGRUPEOLAKSICA"));
            str = str + "," + this.userControlDataGridOLAKSICE.FillByIDGRUPEOLAKSICAIDGRUPEOLAKSICA.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Osiguranja-Olakšice " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Osiguranja-Olakšice " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByIDTIPOLAKSICE()
        {
            string str = "";
            this.userControlDataGridOLAKSICE.FillMethod = "FillByIDTIPOLAKSICE";
            this.userControlDataGridOLAKSICE.FillByIDTIPOLAKSICEIDTIPOLAKSICE = Conversions.ToInteger(this.GetValueFromRow("IDTIPOLAKSICE", "IDTIPOLAKSICE"));
            str = str + "," + this.userControlDataGridOLAKSICE.FillByIDTIPOLAKSICEIDTIPOLAKSICE.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Osiguranja-Olakšice " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Osiguranja-Olakšice " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
            this.components = new System.ComponentModel.Container();
            this.userControlDataGridOLAKSICE = new NetAdvantage.SmartParts.OLAKSICEUserDataGrid();
            this.ultraGridPrintDocument1 = new Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new Infragistics.Win.Printing.UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            // 
            // userControlDataGridOLAKSICE
            // 
            this.userControlDataGridOLAKSICE.Description = "Work with Osiguranja-Olakšice";
            this.userControlDataGridOLAKSICE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlDataGridOLAKSICE.FillAtStartup = false;
            this.userControlDataGridOLAKSICE.FillByIDGRUPEOLAKSICAIDGRUPEOLAKSICA = 0;
            this.userControlDataGridOLAKSICE.FillByIDTIPOLAKSICEIDTIPOLAKSICE = 0;
            this.userControlDataGridOLAKSICE.FillByPage = false;
            this.userControlDataGridOLAKSICE.Location = new System.Drawing.Point(5, 5);
            this.userControlDataGridOLAKSICE.Name = "userControlDataGridOLAKSICE";
            this.userControlDataGridOLAKSICE.Padding = new System.Windows.Forms.Padding(5);
            this.userControlDataGridOLAKSICE.Size = new System.Drawing.Size(140, 140);
            this.userControlDataGridOLAKSICE.TabIndex = 6;
            this.userControlDataGridOLAKSICE.Title = "Work with Osiguranja-Olakšice";
            // 
            // ultraGridPrintDocument1
            // 
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridOLAKSICE.DataGrid;
            // 
            // ultraPrintPreviewDialog1
            // 
            this.ultraPrintPreviewDialog1.Name = "ultraPrintPreviewDialog1";
            // 
            // OLAKSICEWorkWith
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControlDataGridOLAKSICE);
            this.Name = "OLAKSICEWorkWith";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Load += new System.EventHandler(this.OLAKSICEWorkWith_Load);
            this.ResumeLayout(false);

        }

        [LocalCommandHandler("Insert")]
        public void InsertHandler(object sender, EventArgs e)
        {
            if (this.OLAKSICEWorkWithController.WorkItem.Status == WorkItemStatus.Active)
            {
                this.OLAKSICEWorkWithController.Insert(this.m_FillByRow);
            }
        }

        private bool InValidState()
        {
            return ((this.OLAKSICEWorkWithController.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void OLAKSICEWorkWith_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridOLAKSICE.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridOLAKSICE.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridOLAKSICE.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridOLAKSICE.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridOLAKSICE.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridOLAKSICE.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridOLAKSICE.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.FillData();
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
            if (this.OLAKSICEWorkWithController.WorkItem.Status == WorkItemStatus.Active)
            {
                this.ultraPrintPreviewDialog1.ShowDialog(this);
            }
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/OLAKSICE", Thread=ThreadOption.UserInterface)]
        public void RefreshGrid(object sender, ComponentEventArgs args)
        {
            this.FillData();
        }

        [LocalCommandHandler("Refresh")]
        public void RefreshHandler(object sender, EventArgs e)
        {
            if (this.OLAKSICEWorkWithController.WorkItem.Status == WorkItemStatus.Active)
            {
                this.FillData();
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridOLAKSICE.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
            if (this.OLAKSICEWorkWithController.WorkItem.Status == WorkItemStatus.Active)
            {
                this.m_RowSelected = this.CurrentDataRow;
                this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetSmartPartInfoInformation()
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.smartPartInfo1.Title = string.Format("{0} Osiguranja-Olakšice ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} Osiguranja-Olakšice ", Deklarit.Resources.Resources.Workwith);
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
                this.OLAKSICEWorkWithController.Update(this.CurrentDataRow);
            }
        }

        [LocalCommandHandler("View")]
        public void View(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.OLAKSICEWorkWithController.View(this.CurrentDataRow);
            }
        }

        [CreateNew]
        public OLAKSICEWorkWithController OLAKSICEWorkWithController { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridOLAKSICE.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridOLAKSICE.DataView[this.userControlDataGridOLAKSICE.DataGrid.CurrentRowIndex].Row;
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

        private OLAKSICEUserDataGrid userControlDataGridOLAKSICE;

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

