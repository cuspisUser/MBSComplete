namespace NetAdvantage.SmartParts
{
    using Deklarit;
    using Deklarit.Practices.CompositeUI;
    using Deklarit.Practices.CompositeUI.BuilderStrategies;
    using Deklarit.Practices.CompositeUI.NetAdvantage.Services;
    using Deklarit.Practices.CompositeUI.Services;
    using Deklarit.Resources;
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.Printing;
    using Infragistics.Win.UltraWinEditors;
    using Infragistics.Win.UltraWinGrid;
    using Infragistics.Win.UltraWinGrid.ExcelExport;
    using Microsoft.Practices.CompositeUI;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using NetAdvantage.Controls;
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
    public class S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("comboIDLOKACIJE")]
        private LOKACIJEComboBox _comboIDLOKACIJE;
        [AccessedThroughProperty("label1IDLOKACIJE")]
        private UltraLabel _label1IDLOKACIJE;
        [AccessedThroughProperty("userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA")]
        private S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAUserDataGrid _userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICADataSet>(this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid);
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
            if ((this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.FillByPage;
                this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.ParameterIDLOKACIJE = int.Parse(this.comboIDLOKACIJE.Value.ToString());
                this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Fill();
                ((S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("IDLOKACIJE", typeof(int));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["IDLOKACIJE"] = int.Parse(this.comboIDLOKACIJE.Value.ToString());
            return row2;
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new Container();
            ResourceManager manager = new ResourceManager(typeof(S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAUserControl));
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA = new TableLayoutPanel();
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.SuspendLayout();
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.AutoSize = true;
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Dock = DockStyle.Fill;
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Size = size;
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.ColumnCount = 2;
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.RowCount = 2;
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.RowStyles.Add(new RowStyle());
            this.label1IDLOKACIJE = new UltraLabel();
            this.comboIDLOKACIJE = new LOKACIJEComboBox();
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA = new S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.label1IDLOKACIJE.Name = "label1IDLOKACIJE";
            this.label1IDLOKACIJE.TabIndex = 1;
            this.label1IDLOKACIJE.Tag = "labelIDLOKACIJE";
            this.label1IDLOKACIJE.AutoSize = true;
            this.label1IDLOKACIJE.StyleSetName = "FieldUltraLabel";
            this.label1IDLOKACIJE.Text = "IDLOKACIJE   :";
            this.label1IDLOKACIJE.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDLOKACIJE.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1IDLOKACIJE.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Controls.Add(this.label1IDLOKACIJE, 0, 0);
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.SetColumnSpan(this.label1IDLOKACIJE, 1);
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.SetRowSpan(this.label1IDLOKACIJE, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDLOKACIJE.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDLOKACIJE.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDLOKACIJE.Location = point;
            this.comboIDLOKACIJE.Name = "comboIDLOKACIJE";
            this.comboIDLOKACIJE.Tag = "IDLOKACIJE";
            this.comboIDLOKACIJE.TabIndex = 0;
            size = new System.Drawing.Size(0x1dc, 0x17);
            this.comboIDLOKACIJE.Size = size;
            this.comboIDLOKACIJE.DropDownStyle = DropDownStyle.DropDownList;
            this.comboIDLOKACIJE.AddEmptyValue = true;
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Controls.Add(this.comboIDLOKACIJE, 1, 0);
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.SetColumnSpan(this.comboIDLOKACIJE, 1);
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.SetRowSpan(this.comboIDLOKACIJE, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDLOKACIJE.Margin = padding;
            size = new System.Drawing.Size(0x1dc, 0x17);
            this.comboIDLOKACIJE.MinimumSize = size;
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Controls.Add(this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA, 0, 1);
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.SetColumnSpan(this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA, 2);
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.SetRowSpan(this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.MinimumSize = size;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA);
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Name = "userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA";
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Dock = DockStyle.Fill;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DockPadding.All = 5;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.FillAtStartup = false;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAWorkWith";
            this.Text = "Work With ";
            this.Load += new EventHandler(this.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAUserControl_Load);
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.ResumeLayout(false);
            this.layoutManagerformS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.PerformLayout();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.comboIDLOKACIJE.SelectedIndex = 0;
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("IDLOKACIJE") && (this.m_FillByRow["IDLOKACIJE"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.comboIDLOKACIJE, this.m_FillByRow["IDLOKACIJE"].ToString(), this.m_FillByRow.Table.Columns["IDLOKACIJE"].DataType);
                    this.parameterSeted = true;
                    this.comboIDLOKACIJE.Visible = false;
                    this.label1IDLOKACIJE.Visible = false;
                    str = str + "," + this.m_FillByRow["IDLOKACIJE"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + " " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + " " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                }
            }
        }

        private void Localize()
        {
            this.label1IDLOKACIJE.Text = StringResources.S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAIDLOKACIJEParameter;
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

        private void S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.FillByPage = true;
                this.FillData();
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0}  ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0}  ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        protected virtual LOKACIJEComboBox comboIDLOKACIJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDLOKACIJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDLOKACIJE = value;
            }
        }

        [CreateNew]
        public S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataView[this.userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1IDLOKACIJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDLOKACIJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDLOKACIJE = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual S_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICAUserDataGrid userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_OS_STANJE_LOKACIJA_ISPIS_NALJEPNICA = value;
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

