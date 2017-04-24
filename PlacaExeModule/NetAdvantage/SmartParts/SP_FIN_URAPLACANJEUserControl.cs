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
    public class SP_FIN_URAPLACANJEUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("comboIDDOKUMENT")]
        private DOKUMENTComboBox _comboIDDOKUMENT;
        [AccessedThroughProperty("label1IDDOKUMENT")]
        private UltraLabel _label1IDDOKUMENT;
        [AccessedThroughProperty("userControlDataGridSP_FIN_URAPLACANJE")]
        private SP_FIN_URAPLACANJEUserDataGrid _userControlDataGridSP_FIN_URAPLACANJE;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformSP_FIN_URAPLACANJE;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public SP_FIN_URAPLACANJEUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.SP_FIN_URAPLACANJEDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.SP_FIN_URAPLACANJEDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<SP_FIN_URAPLACANJEDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<SP_FIN_URAPLACANJEDataSet>(this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid);
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
            if ((this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.Rows.Count > 0) && (this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.FillByPage;
                this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridSP_FIN_URAPLACANJE.ParameterIDDOKUMENT = int.Parse(this.comboIDDOKUMENT.Value.ToString());
                this.userControlDataGridSP_FIN_URAPLACANJE.Fill();
                ((SP_FIN_URAPLACANJEWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridSP_FIN_URAPLACANJE.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("IDDOKUMENT", typeof(int));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["IDDOKUMENT"] = int.Parse(this.comboIDDOKUMENT.Value.ToString());
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
            ResourceManager manager = new ResourceManager(typeof(SP_FIN_URAPLACANJEUserControl));
            this.layoutManagerformSP_FIN_URAPLACANJE = new TableLayoutPanel();
            this.layoutManagerformSP_FIN_URAPLACANJE.SuspendLayout();
            this.layoutManagerformSP_FIN_URAPLACANJE.AutoSize = true;
            this.layoutManagerformSP_FIN_URAPLACANJE.Dock = DockStyle.Fill;
            this.layoutManagerformSP_FIN_URAPLACANJE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformSP_FIN_URAPLACANJE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformSP_FIN_URAPLACANJE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformSP_FIN_URAPLACANJE.Size = size;
            this.layoutManagerformSP_FIN_URAPLACANJE.ColumnCount = 2;
            this.layoutManagerformSP_FIN_URAPLACANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSP_FIN_URAPLACANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformSP_FIN_URAPLACANJE.RowCount = 2;
            this.layoutManagerformSP_FIN_URAPLACANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformSP_FIN_URAPLACANJE.RowStyles.Add(new RowStyle());
            this.label1IDDOKUMENT = new UltraLabel();
            this.comboIDDOKUMENT = new DOKUMENTComboBox();
            this.userControlDataGridSP_FIN_URAPLACANJE = new SP_FIN_URAPLACANJEUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.label1IDDOKUMENT.Name = "label1IDDOKUMENT";
            this.label1IDDOKUMENT.TabIndex = 1;
            this.label1IDDOKUMENT.Tag = "labelIDDOKUMENT";
            this.label1IDDOKUMENT.AutoSize = true;
            this.label1IDDOKUMENT.StyleSetName = "FieldUltraLabel";
            this.label1IDDOKUMENT.Text = "IDDOKUMENT               :";
            this.label1IDDOKUMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDDOKUMENT.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1IDDOKUMENT.Appearance.ForeColor = Color.Black;
            this.layoutManagerformSP_FIN_URAPLACANJE.Controls.Add(this.label1IDDOKUMENT, 0, 0);
            this.layoutManagerformSP_FIN_URAPLACANJE.SetColumnSpan(this.label1IDDOKUMENT, 1);
            this.layoutManagerformSP_FIN_URAPLACANJE.SetRowSpan(this.label1IDDOKUMENT, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDDOKUMENT.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDDOKUMENT.Location = point;
            this.comboIDDOKUMENT.Name = "comboIDDOKUMENT";
            this.comboIDDOKUMENT.Tag = "IDDOKUMENT";
            this.comboIDDOKUMENT.TabIndex = 0;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDDOKUMENT.Size = size;
            this.comboIDDOKUMENT.DropDownStyle = DropDownStyle.DropDownList;
            this.comboIDDOKUMENT.AddEmptyValue = true;
            this.layoutManagerformSP_FIN_URAPLACANJE.Controls.Add(this.comboIDDOKUMENT, 1, 0);
            this.layoutManagerformSP_FIN_URAPLACANJE.SetColumnSpan(this.comboIDDOKUMENT, 1);
            this.layoutManagerformSP_FIN_URAPLACANJE.SetRowSpan(this.comboIDDOKUMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDDOKUMENT.MinimumSize = size;
            this.layoutManagerformSP_FIN_URAPLACANJE.Controls.Add(this.userControlDataGridSP_FIN_URAPLACANJE, 0, 1);
            this.layoutManagerformSP_FIN_URAPLACANJE.SetColumnSpan(this.userControlDataGridSP_FIN_URAPLACANJE, 2);
            this.layoutManagerformSP_FIN_URAPLACANJE.SetRowSpan(this.userControlDataGridSP_FIN_URAPLACANJE, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridSP_FIN_URAPLACANJE.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridSP_FIN_URAPLACANJE.MinimumSize = size;
            this.userControlDataGridSP_FIN_URAPLACANJE.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformSP_FIN_URAPLACANJE);
            this.userControlDataGridSP_FIN_URAPLACANJE.Name = "userControlDataGridSP_FIN_URAPLACANJE";
            this.userControlDataGridSP_FIN_URAPLACANJE.Dock = DockStyle.Fill;
            this.userControlDataGridSP_FIN_URAPLACANJE.DockPadding.All = 5;
            this.userControlDataGridSP_FIN_URAPLACANJE.FillAtStartup = false;
            this.userControlDataGridSP_FIN_URAPLACANJE.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridSP_FIN_URAPLACANJE.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridSP_FIN_URAPLACANJE.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "SP_FIN_URAPLACANJEWorkWith";
            this.Text = "Work With SP_FIN_URAPLACANJE";
            this.Load += new EventHandler(this.SP_FIN_URAPLACANJEUserControl_Load);
            this.layoutManagerformSP_FIN_URAPLACANJE.ResumeLayout(false);
            this.layoutManagerformSP_FIN_URAPLACANJE.PerformLayout();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.comboIDDOKUMENT.SelectedIndex = 0;
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("IDDOKUMENT") && (this.m_FillByRow["IDDOKUMENT"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.comboIDDOKUMENT, this.m_FillByRow["IDDOKUMENT"].ToString(), this.m_FillByRow.Table.Columns["IDDOKUMENT"].DataType);
                    this.parameterSeted = true;
                    this.comboIDDOKUMENT.Visible = false;
                    this.label1IDDOKUMENT.Visible = false;
                    str = str + "," + this.m_FillByRow["IDDOKUMENT"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "SP_FIN_URAPLACANJE " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "SP_FIN_URAPLACANJE " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                }
            }
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
                    this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.DataSet.Clear();
                    this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new SP_FIN_URAPLACANJEDataAdapter().Update(this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.DataSet);
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
            this.label1IDDOKUMENT.Text = StringResources.SP_FIN_URAPLACANJEIDDOKUMENTParameter;
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
                this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} SP_FIN_URAPLACANJE ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} SP_FIN_URAPLACANJE ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void SP_FIN_URAPLACANJEUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.FillByPage = true;
                this.FillData();
            }
        }

        protected virtual DOKUMENTComboBox comboIDDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDDOKUMENT = value;
            }
        }

        [CreateNew]
        public SP_FIN_URAPLACANJEController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridSP_FIN_URAPLACANJE.DataView[this.userControlDataGridSP_FIN_URAPLACANJE.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1IDDOKUMENT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDDOKUMENT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDDOKUMENT = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual SP_FIN_URAPLACANJEUserDataGrid userControlDataGridSP_FIN_URAPLACANJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridSP_FIN_URAPLACANJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridSP_FIN_URAPLACANJE = value;
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

