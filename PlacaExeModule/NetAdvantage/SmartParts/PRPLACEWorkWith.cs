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
    public class PRPLACEWorkWith : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridPRPLACE")]
        private PRPLACEUserDataGrid _userControlDataGridPRPLACE;
        private IContainer components;
        private SmartPartInfoProvider infoProvider;
        private string m_FillByMethod;
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public PRPLACEWorkWith()
        {
            base.Leave += new EventHandler(this.PRPLACEWorkWith_Leave);
            base.Load += new EventHandler(this.PRPLACEWorkWith_Load1);
            this.components = null;
            this.m_FillByMethod = "";
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.PRPLACEDescription), string.Format(Deklarit.Resources.Resources.WorkWithTitle, StringResources.PRPLACEDescription));
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridPRPLACE.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<PRPLACEDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<PRPLACEDataSet>(this.userControlDataGridPRPLACE.DataGrid);
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
            if (!this.userControlDataGridPRPLACE.DataGrid.GridLoading && ((this.userControlDataGridPRPLACE.DataGrid.ActiveRow != null) && (this.userControlDataGridPRPLACE.DataGrid.ActiveCell != null)))
            {
                this.DefaultAction();
            }
        }

        private void DataGrid_SetFocus()
        {
            if ((this.userControlDataGridPRPLACE.DataGrid.Rows.Count > 0) && (this.userControlDataGridPRPLACE.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridPRPLACE.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridPRPLACE.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridPRPLACE.DataGrid.FillByPage;
                this.userControlDataGridPRPLACE.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridPRPLACE.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                string fillByMethod = this.m_FillByMethod;
                if (fillByMethod == "FillByPRPLACEID")
                {
                    this.FillFillByPRPLACEID();
                }
                else if (fillByMethod == "FillByPRPLACEIDPRPLACEZAMJESEC")
                {
                    this.FillFillByPRPLACEIDPRPLACEZAMJESEC();
                }
                else
                {
                    this.userControlDataGridPRPLACE.FillMethod = "Fill";
                }
                this.userControlDataGridPRPLACE.Fill();
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    ((PRPLACESelectionListWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridPRPLACE.DataView.Table.DataSet;
                }
                else
                {
                    ((PRPLACEWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridPRPLACE.DataView.Table.DataSet;
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        private void FillFillByPRPLACEID()
        {
            string str = "";
            this.userControlDataGridPRPLACE.FillMethod = "FillByPRPLACEID";
            this.userControlDataGridPRPLACE.FillByPRPLACEIDPRPLACEID = Conversions.ToInteger(this.GetValueFromRow("PRPLACEID", "PRPLACEID"));
            str = str + "," + this.userControlDataGridPRPLACE.FillByPRPLACEIDPRPLACEID.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Priprema plaae " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Priprema plaae " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
            }
        }

        private void FillFillByPRPLACEIDPRPLACEZAMJESEC()
        {
            string str = "";
            this.userControlDataGridPRPLACE.FillMethod = "FillByPRPLACEIDPRPLACEZAMJESEC";
            this.userControlDataGridPRPLACE.FillByPRPLACEIDPRPLACEZAMJESECPRPLACEID = Conversions.ToInteger(this.GetValueFromRow("PRPLACEID", "PRPLACEID"));
            str = str + "," + this.userControlDataGridPRPLACE.FillByPRPLACEIDPRPLACEZAMJESECPRPLACEID.ToString() + " ";
            this.userControlDataGridPRPLACE.FillByPRPLACEIDPRPLACEZAMJESECPRPLACEZAMJESEC = Conversions.ToShort(this.GetValueFromRow("PRPLACEZAMJESEC", "PRPLACEZAMJESEC"));
            str = str + "," + this.userControlDataGridPRPLACE.FillByPRPLACEIDPRPLACEZAMJESECPRPLACEZAMJESEC.ToString() + " ";
            if (FormHelperClass.GetDescription(this.m_FillByRow).Length == 0)
            {
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    this.Text = Deklarit.Resources.Resources.Select + "Priprema plaae " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                }
                else
                {
                    this.Text = Deklarit.Resources.Resources.Workwith + "Priprema plaae " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
            ResourceManager manager = new ResourceManager(typeof(PRPLACEWorkWith));
            this.userControlDataGridPRPLACE = new PRPLACEUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.userControlDataGridPRPLACE.Name = "userControlDataGridPRPLACE";
            this.userControlDataGridPRPLACE.Dock = DockStyle.Fill;
            this.userControlDataGridPRPLACE.DockPadding.All = 5;
            this.userControlDataGridPRPLACE.FillAtStartup = false;
            this.userControlDataGridPRPLACE.TabIndex = 6;
            Size size = new System.Drawing.Size(0x2d8, 400);
            this.userControlDataGridPRPLACE.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridPRPLACE.DataGrid;
            this.Controls.Add(this.userControlDataGridPRPLACE);
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "PRPLACEWorkWith";
            this.Text = "Work With Priprema plaae";
            this.Load += new EventHandler(this.PRPLACEWorkWith_Load);
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

        [LocalCommandHandler("Smjenski")]
        public void IspisiHandler(object sender, EventArgs e)
        {
            if (this.Controller.CurrentRow != null)
            {
                this.Smjenski_Rad_Tablica();
            }
        }

        public void Posebni_Tablica()
        {
            Interaction.MsgBox("Izrada tablica u novom unosu pripreme", MsgBoxStyle.OkOnly, null);
        }

        [LocalCommandHandler("Posebni")]
        public void PosebniHandler(object sender, EventArgs e)
        {
            if (this.Controller.CurrentRow != null)
            {
                this.Posebni_Tablica();
            }
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

        private void PRPLACEWorkWith_Leave(object sender, EventArgs e)
        {
        }

        private void PRPLACEWorkWith_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridPRPLACE.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridPRPLACE.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridPRPLACE.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridPRPLACE.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridPRPLACE.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridPRPLACE.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridPRPLACE.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.FillData();
        }

        private void PRPLACEWorkWith_Load1(object sender, EventArgs e)
        {
        }

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/PRPLACE", Thread=ThreadOption.UserInterface)]
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
            UIElement lastElementEntered = this.userControlDataGridPRPLACE.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} Priprema plaae ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} Priprema plaae ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public void Smjenski_Rad_Tablica()
        {
            Interaction.MsgBox("Izrada tablica u novom unosu pripreme", MsgBoxStyle.OkOnly, null);
        }

        [LocalCommandHandler("Update")]
        public void UpdateHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.Update(this.CurrentDataRow);
            }
        }

        public void Uvecanje_Tablica()
        {
            Interaction.MsgBox("Izrada tablica u novom unosu pripreme", MsgBoxStyle.OkOnly, null);
        }

        [LocalCommandHandler("Uvecanje")]
        public void UvecanjeHandler(object sender, EventArgs e)
        {
            if (this.Controller.CurrentRow != null)
            {
                this.Uvecanje_Tablica();
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
        public PRPLACEWorkWithController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridPRPLACE.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridPRPLACE.DataView[this.userControlDataGridPRPLACE.DataGrid.CurrentRowIndex].Row;
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

        private PRPLACEUserDataGrid userControlDataGridPRPLACE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridPRPLACE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridPRPLACE = value;
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

