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
    public class S_FIN_IRA_PLACANJEUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("comboIDDOKUMENT")]
        private DOKUMENTComboBox _comboIDDOKUMENT;
        [AccessedThroughProperty("label1IDDOKUMENT")]
        private UltraLabel _label1IDDOKUMENT;
        [AccessedThroughProperty("userControlDataGridS_FIN_IRA_PLACANJE")]
        private S_FIN_IRA_PLACANJEUserDataGrid _userControlDataGridS_FIN_IRA_PLACANJE;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_FIN_IRA_PLACANJE;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_FIN_IRA_PLACANJEUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_FIN_IRA_PLACANJEDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_FIN_IRA_PLACANJEDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_FIN_IRA_PLACANJEDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_FIN_IRA_PLACANJEDataSet>(this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid);
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
            if ((this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.FillByPage;
                this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_FIN_IRA_PLACANJE.ParameterIDDOKUMENT = int.Parse(this.comboIDDOKUMENT.Value.ToString());
                this.userControlDataGridS_FIN_IRA_PLACANJE.Fill();
                ((S_FIN_IRA_PLACANJEWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_FIN_IRA_PLACANJE.DataView.Table.DataSet;
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
            ResourceManager manager = new ResourceManager(typeof(S_FIN_IRA_PLACANJEUserControl));
            this.layoutManagerformS_FIN_IRA_PLACANJE = new TableLayoutPanel();
            this.layoutManagerformS_FIN_IRA_PLACANJE.SuspendLayout();
            this.layoutManagerformS_FIN_IRA_PLACANJE.AutoSize = true;
            this.layoutManagerformS_FIN_IRA_PLACANJE.Dock = DockStyle.Fill;
            this.layoutManagerformS_FIN_IRA_PLACANJE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_FIN_IRA_PLACANJE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_FIN_IRA_PLACANJE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_FIN_IRA_PLACANJE.Size = size;
            this.layoutManagerformS_FIN_IRA_PLACANJE.ColumnCount = 2;
            this.layoutManagerformS_FIN_IRA_PLACANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_IRA_PLACANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_IRA_PLACANJE.RowCount = 2;
            this.layoutManagerformS_FIN_IRA_PLACANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_IRA_PLACANJE.RowStyles.Add(new RowStyle());
            this.label1IDDOKUMENT = new UltraLabel();
            this.comboIDDOKUMENT = new DOKUMENTComboBox();
            this.userControlDataGridS_FIN_IRA_PLACANJE = new S_FIN_IRA_PLACANJEUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.label1IDDOKUMENT.Name = "label1IDDOKUMENT";
            this.label1IDDOKUMENT.TabIndex = 1;
            this.label1IDDOKUMENT.Tag = "labelIDDOKUMENT";
            this.label1IDDOKUMENT.AutoSize = true;
            this.label1IDDOKUMENT.StyleSetName = "FieldUltraLabel";
            this.label1IDDOKUMENT.Text = "IDDOKUMENT     :";
            this.label1IDDOKUMENT.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDDOKUMENT.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1IDDOKUMENT.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_IRA_PLACANJE.Controls.Add(this.label1IDDOKUMENT, 0, 0);
            this.layoutManagerformS_FIN_IRA_PLACANJE.SetColumnSpan(this.label1IDDOKUMENT, 1);
            this.layoutManagerformS_FIN_IRA_PLACANJE.SetRowSpan(this.label1IDDOKUMENT, 1);
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
            this.layoutManagerformS_FIN_IRA_PLACANJE.Controls.Add(this.comboIDDOKUMENT, 1, 0);
            this.layoutManagerformS_FIN_IRA_PLACANJE.SetColumnSpan(this.comboIDDOKUMENT, 1);
            this.layoutManagerformS_FIN_IRA_PLACANJE.SetRowSpan(this.comboIDDOKUMENT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDDOKUMENT.Margin = padding;
            size = new System.Drawing.Size(0x196, 0x17);
            this.comboIDDOKUMENT.MinimumSize = size;
            this.layoutManagerformS_FIN_IRA_PLACANJE.Controls.Add(this.userControlDataGridS_FIN_IRA_PLACANJE, 0, 1);
            this.layoutManagerformS_FIN_IRA_PLACANJE.SetColumnSpan(this.userControlDataGridS_FIN_IRA_PLACANJE, 2);
            this.layoutManagerformS_FIN_IRA_PLACANJE.SetRowSpan(this.userControlDataGridS_FIN_IRA_PLACANJE, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_FIN_IRA_PLACANJE.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_FIN_IRA_PLACANJE.MinimumSize = size;
            this.userControlDataGridS_FIN_IRA_PLACANJE.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_FIN_IRA_PLACANJE);
            this.userControlDataGridS_FIN_IRA_PLACANJE.Name = "userControlDataGridS_FIN_IRA_PLACANJE";
            this.userControlDataGridS_FIN_IRA_PLACANJE.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_IRA_PLACANJE.DockPadding.All = 5;
            this.userControlDataGridS_FIN_IRA_PLACANJE.FillAtStartup = false;
            this.userControlDataGridS_FIN_IRA_PLACANJE.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_IRA_PLACANJE.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_FIN_IRA_PLACANJE.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_FIN_IRA_PLACANJEWorkWith";
            this.Text = "Work With S_FIN_IRA_PLACANJE";
            this.Load += new EventHandler(this.S_FIN_IRA_PLACANJEUserControl_Load);
            this.layoutManagerformS_FIN_IRA_PLACANJE.ResumeLayout(false);
            this.layoutManagerformS_FIN_IRA_PLACANJE.PerformLayout();
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
                        this.Text = Deklarit.Resources.Resources.Select + "S_FIN_IRA_PLACANJE " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_FIN_IRA_PLACANJE " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_FIN_IRA_PLACANJEDataAdapter().Update(this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.DataSet);
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
            this.label1IDDOKUMENT.Text = StringResources.S_FIN_IRA_PLACANJEIDDOKUMENTParameter;
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

        private void S_FIN_IRA_PLACANJEUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_IRA_PLACANJE ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_IRA_PLACANJE ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        public S_FIN_IRA_PLACANJEController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_FIN_IRA_PLACANJE.DataView[this.userControlDataGridS_FIN_IRA_PLACANJE.DataGrid.CurrentRowIndex].Row;
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

        protected virtual S_FIN_IRA_PLACANJEUserDataGrid userControlDataGridS_FIN_IRA_PLACANJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_FIN_IRA_PLACANJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_FIN_IRA_PLACANJE = value;
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

