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
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinGrid.ExcelExport;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage.Controllers;
    using NetAdvantage.WorkItems;
    using Placa;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class GODINA_I_MJESEC_OBRACUNAUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("userControlDataGridGODINA_I_MJESEC_OBRACUNA")]
        private GODINA_I_MJESEC_OBRACUNAUserDataGrid _userControlDataGridGODINA_I_MJESEC_OBRACUNA;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformGODINA_I_MJESEC_OBRACUNA;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public GODINA_I_MJESEC_OBRACUNAUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.GODINA_I_MJESEC_OBRACUNADescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.GODINA_I_MJESEC_OBRACUNADescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<GODINA_I_MJESEC_OBRACUNADataSet> serviceInstance = new UltraGridSelectedRowsProviderService<GODINA_I_MJESEC_OBRACUNADataSet>(this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        private void DataGrid_AfterRowActivate(object sender, EventArgs e)
        {
            DataRow currentDataRow = this.CurrentDataRow;
        }

        private void DataGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
        }

        private void DataGrid_SetFocus()
        {
            if ((this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.Rows.Count > 0) && (this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.Rows[0].Activate();
            }
        }

        private void DefaultAction()
        {
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.FillByPage;
                this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.Fill();
                ((GODINA_I_MJESEC_OBRACUNAWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            return null;
        }

        private DataRow GetParameterRow()
        {
            return null;
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void GODINA_I_MJESEC_OBRACUNAUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.FillByPage = false;
            this.FillData();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(GODINA_I_MJESEC_OBRACUNAUserControl));
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA = new TableLayoutPanel();
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.SuspendLayout();
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.AutoSize = true;
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.Dock = DockStyle.Fill;
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.Size = size;
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.ColumnCount = 2;
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.RowCount = 1;
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.RowStyles.Add(new RowStyle());
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA = new GODINA_I_MJESEC_OBRACUNAUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.Controls.Add(this.userControlDataGridGODINA_I_MJESEC_OBRACUNA, 0, 0);
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.SetColumnSpan(this.userControlDataGridGODINA_I_MJESEC_OBRACUNA, 2);
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.SetRowSpan(this.userControlDataGridGODINA_I_MJESEC_OBRACUNA, 1);
            Padding padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.MinimumSize = size;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformGODINA_I_MJESEC_OBRACUNA);
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.Name = "userControlDataGridGODINA_I_MJESEC_OBRACUNA";
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.Dock = DockStyle.Fill;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DockPadding.All = 5;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.FillAtStartup = false;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "GODINA_I_MJESEC_OBRACUNAWorkWith";
            this.Text = "Work With GODINA_I_MJESEC_OBRACUNA";
            this.Load += new EventHandler(this.GODINA_I_MJESEC_OBRACUNAUserControl_Load);
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.ResumeLayout(false);
            this.layoutManagerformGODINA_I_MJESEC_OBRACUNA.PerformLayout();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
        }

        [LocalCommandHandler("ImportXml")]
        public void LoadFromXml(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                DefaultExt = "xml",
                Filter = "XML file (*.xml)|*.xml"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.DataSet.Clear();
                    this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new GODINA_I_MJESEC_OBRACUNADataAdapter().Update(this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.DataSet);
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    
                }
            }
            this.FillData();
        }

        private void Localize()
        {
        }

        private void numericEditor_Enter(object sender, EventArgs e)
        {
            ((UltraNumericEditor) sender).SelectAll();
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

        [LocalCommandHandler("ExportXml")]
        public void SaveToXml(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog {
                DefaultExt = "xml",
                Filter = "XML file (*.xml)|*.xml"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} GODINA_I_MJESEC_OBRACUNA ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} GODINA_I_MJESEC_OBRACUNA ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public GODINA_I_MJESEC_OBRACUNAController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataView[this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DataGrid.CurrentRowIndex].Row;
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

        protected virtual GODINA_I_MJESEC_OBRACUNAUserDataGrid userControlDataGridGODINA_I_MJESEC_OBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridGODINA_I_MJESEC_OBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridGODINA_I_MJESEC_OBRACUNA = value;
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

