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
    public class s_od_rekap_doprinosUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1idobracun")]
        private UltraLabel _label1idobracun;
        [AccessedThroughProperty("textidobracun")]
        private UltraTextEditor _textidobracun;
        [AccessedThroughProperty("userControlDataGrids_od_rekap_doprinos")]
        private s_od_rekap_doprinosUserDataGrid _userControlDataGrids_od_rekap_doprinos;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerforms_od_rekap_doprinos;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public s_od_rekap_doprinosUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.s_od_rekap_doprinosDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.s_od_rekap_doprinosDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGrids_od_rekap_doprinos.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<s_od_rekap_doprinosDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<s_od_rekap_doprinosDataSet>(this.userControlDataGrids_od_rekap_doprinos.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        private void CallPromptOBRACUNidobracun(object sender, EditorButtonEventArgs e)
        {
            s_od_rekap_doprinosController controller = this.Controller.WorkItem.Items.AddNew<s_od_rekap_doprinosController>();
            DataRow parameterRow = this.GetParameterRow();
            DataRow row = controller.SelectOBRACUNidobracun("", parameterRow);
            if (row != null)
            {
                this.textidobracun.Text = row["IDOBRACUN"].ToString();
            }
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
            if ((this.userControlDataGrids_od_rekap_doprinos.DataGrid.Rows.Count > 0) && (this.userControlDataGrids_od_rekap_doprinos.DataGrid.Rows[0] != null))
            {
                this.userControlDataGrids_od_rekap_doprinos.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGrids_od_rekap_doprinos.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGrids_od_rekap_doprinos.DataGrid.FillByPage;
                this.userControlDataGrids_od_rekap_doprinos.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGrids_od_rekap_doprinos.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGrids_od_rekap_doprinos.Parameteridobracun = this.textidobracun.Text;
                this.userControlDataGrids_od_rekap_doprinos.Fill();
                ((s_od_rekap_doprinosWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGrids_od_rekap_doprinos.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("idobracun", typeof(string));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["idobracun"] = this.textidobracun.Text;
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
            ResourceManager manager = new ResourceManager(typeof(s_od_rekap_doprinosUserControl));
            this.layoutManagerforms_od_rekap_doprinos = new TableLayoutPanel();
            this.layoutManagerforms_od_rekap_doprinos.SuspendLayout();
            this.layoutManagerforms_od_rekap_doprinos.AutoSize = true;
            this.layoutManagerforms_od_rekap_doprinos.Dock = DockStyle.Fill;
            this.layoutManagerforms_od_rekap_doprinos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerforms_od_rekap_doprinos.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerforms_od_rekap_doprinos.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerforms_od_rekap_doprinos.Size = size;
            this.layoutManagerforms_od_rekap_doprinos.ColumnCount = 2;
            this.layoutManagerforms_od_rekap_doprinos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerforms_od_rekap_doprinos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerforms_od_rekap_doprinos.RowCount = 2;
            this.layoutManagerforms_od_rekap_doprinos.RowStyles.Add(new RowStyle());
            this.layoutManagerforms_od_rekap_doprinos.RowStyles.Add(new RowStyle());
            this.label1idobracun = new UltraLabel();
            this.textidobracun = new UltraTextEditor();
            this.userControlDataGrids_od_rekap_doprinos = new s_od_rekap_doprinosUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textidobracun).BeginInit();
            this.SuspendLayout();
            this.label1idobracun.Name = "label1idobracun";
            this.label1idobracun.TabIndex = 1;
            this.label1idobracun.Tag = "labelidobracun";
            this.label1idobracun.AutoSize = true;
            this.label1idobracun.StyleSetName = "FieldUltraLabel";
            this.label1idobracun.Text = "idobracun         :";
            this.label1idobracun.Appearance.TextVAlign = VAlign.Middle;
            this.label1idobracun.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1idobracun.Appearance.ForeColor = Color.Black;
            this.layoutManagerforms_od_rekap_doprinos.Controls.Add(this.label1idobracun, 0, 0);
            this.layoutManagerforms_od_rekap_doprinos.SetColumnSpan(this.label1idobracun, 1);
            this.layoutManagerforms_od_rekap_doprinos.SetRowSpan(this.label1idobracun, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1idobracun.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1idobracun.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textidobracun.Location = point;
            this.textidobracun.Name = "textidobracun";
            this.textidobracun.Tag = "idobracun";
            this.textidobracun.TabIndex = 0;
            size = new System.Drawing.Size(0x71, 0x16);
            this.textidobracun.Size = size;
            this.textidobracun.MaxLength = 11;
            EditorButton button = new EditorButton {
                Key = "editorButtonOBRACUNidobracun",
                Tag = "editorButtonOBRACUNidobracun",
                Text = "..."
            };
            this.textidobracun.ButtonsRight.Add(button);
            this.textidobracun.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOBRACUNidobracun);
            this.layoutManagerforms_od_rekap_doprinos.Controls.Add(this.textidobracun, 1, 0);
            this.layoutManagerforms_od_rekap_doprinos.SetColumnSpan(this.textidobracun, 1);
            this.layoutManagerforms_od_rekap_doprinos.SetRowSpan(this.textidobracun, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textidobracun.Margin = padding;
            size = new System.Drawing.Size(0x71, 0x16);
            this.textidobracun.MinimumSize = size;
            this.layoutManagerforms_od_rekap_doprinos.Controls.Add(this.userControlDataGrids_od_rekap_doprinos, 0, 1);
            this.layoutManagerforms_od_rekap_doprinos.SetColumnSpan(this.userControlDataGrids_od_rekap_doprinos, 2);
            this.layoutManagerforms_od_rekap_doprinos.SetRowSpan(this.userControlDataGrids_od_rekap_doprinos, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGrids_od_rekap_doprinos.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGrids_od_rekap_doprinos.MinimumSize = size;
            this.userControlDataGrids_od_rekap_doprinos.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerforms_od_rekap_doprinos);
            this.userControlDataGrids_od_rekap_doprinos.Name = "userControlDataGrids_od_rekap_doprinos";
            this.userControlDataGrids_od_rekap_doprinos.Dock = DockStyle.Fill;
            this.userControlDataGrids_od_rekap_doprinos.DockPadding.All = 5;
            this.userControlDataGrids_od_rekap_doprinos.FillAtStartup = false;
            this.userControlDataGrids_od_rekap_doprinos.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGrids_od_rekap_doprinos.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGrids_od_rekap_doprinos.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGrids_od_rekap_doprinos.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "s_od_rekap_doprinosWorkWith";
            this.Text = "Work With s_od_rekap_doprinos";
            this.Load += new EventHandler(this.s_od_rekap_doprinosUserControl_Load);
            this.layoutManagerforms_od_rekap_doprinos.ResumeLayout(false);
            this.layoutManagerforms_od_rekap_doprinos.PerformLayout();
            ((ISupportInitialize) this.textidobracun).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textidobracun.Text = "";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("idobracun") && (this.m_FillByRow["idobracun"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textidobracun, this.m_FillByRow["idobracun"].ToString(), this.m_FillByRow.Table.Columns["idobracun"].DataType);
                    this.parameterSeted = true;
                    this.textidobracun.Visible = false;
                    this.label1idobracun.Visible = false;
                    str = str + "," + this.m_FillByRow["idobracun"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "s_od_rekap_doprinos " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "s_od_rekap_doprinos " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGrids_od_rekap_doprinos.DataGrid.DataSet.Clear();
                    this.userControlDataGrids_od_rekap_doprinos.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new s_od_rekap_doprinosDataAdapter().Update(this.userControlDataGrids_od_rekap_doprinos.DataGrid.DataSet);
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
            this.label1idobracun.Text = StringResources.s_od_rekap_doprinosidobracunParameter;
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

        private void s_od_rekap_doprinosUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGrids_od_rekap_doprinos.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGrids_od_rekap_doprinos.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGrids_od_rekap_doprinos.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGrids_od_rekap_doprinos.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGrids_od_rekap_doprinos.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGrids_od_rekap_doprinos.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGrids_od_rekap_doprinos.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGrids_od_rekap_doprinos.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGrids_od_rekap_doprinos.DataGrid.FillByPage = true;
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
                this.userControlDataGrids_od_rekap_doprinos.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGrids_od_rekap_doprinos.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} s_od_rekap_doprinos ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} s_od_rekap_doprinos ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public s_od_rekap_doprinosController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGrids_od_rekap_doprinos.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGrids_od_rekap_doprinos.DataView[this.userControlDataGrids_od_rekap_doprinos.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1idobracun
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1idobracun;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1idobracun = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraTextEditor textidobracun
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textidobracun;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textidobracun = value;
            }
        }

        protected virtual s_od_rekap_doprinosUserDataGrid userControlDataGrids_od_rekap_doprinos
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGrids_od_rekap_doprinos;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGrids_od_rekap_doprinos = value;
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

