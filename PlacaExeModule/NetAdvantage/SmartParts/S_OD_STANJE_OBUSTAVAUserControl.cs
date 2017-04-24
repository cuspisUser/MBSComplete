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
    public class S_OD_STANJE_OBUSTAVAUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1idobracun")]
        private UltraLabel _label1idobracun;
        [AccessedThroughProperty("textidobracun")]
        private UltraTextEditor _textidobracun;
        [AccessedThroughProperty("userControlDataGridS_OD_STANJE_OBUSTAVA")]
        private S_OD_STANJE_OBUSTAVAUserDataGrid _userControlDataGridS_OD_STANJE_OBUSTAVA;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_OD_STANJE_OBUSTAVA;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_OD_STANJE_OBUSTAVAUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_OD_STANJE_OBUSTAVADescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_OD_STANJE_OBUSTAVADescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_OD_STANJE_OBUSTAVADataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_OD_STANJE_OBUSTAVADataSet>(this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        private void CallPromptOBRACUNidobracun(object sender, EditorButtonEventArgs e)
        {
            S_OD_STANJE_OBUSTAVAController controller = this.Controller.WorkItem.Items.AddNew<S_OD_STANJE_OBUSTAVAController>();
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
            if ((this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.FillByPage;
                this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_OD_STANJE_OBUSTAVA.Parameteridobracun = this.textidobracun.Text;
                this.userControlDataGridS_OD_STANJE_OBUSTAVA.Fill();
                ((S_OD_STANJE_OBUSTAVAWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataView.Table.DataSet;
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
            ResourceManager manager = new ResourceManager(typeof(S_OD_STANJE_OBUSTAVAUserControl));
            this.layoutManagerformS_OD_STANJE_OBUSTAVA = new TableLayoutPanel();
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.SuspendLayout();
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.AutoSize = true;
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.Dock = DockStyle.Fill;
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.Size = size;
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.ColumnCount = 2;
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.RowCount = 2;
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.RowStyles.Add(new RowStyle());
            this.label1idobracun = new UltraLabel();
            this.textidobracun = new UltraTextEditor();
            this.userControlDataGridS_OD_STANJE_OBUSTAVA = new S_OD_STANJE_OBUSTAVAUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textidobracun).BeginInit();
            this.SuspendLayout();
            this.label1idobracun.Name = "label1idobracun";
            this.label1idobracun.TabIndex = 1;
            this.label1idobracun.Tag = "labelidobracun";
            this.label1idobracun.AutoSize = true;
            this.label1idobracun.StyleSetName = "FieldUltraLabel";
            this.label1idobracun.Text = "idobracun  :";
            this.label1idobracun.Appearance.TextVAlign = VAlign.Middle;
            this.label1idobracun.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1idobracun.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.Controls.Add(this.label1idobracun, 0, 0);
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.SetColumnSpan(this.label1idobracun, 1);
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.SetRowSpan(this.label1idobracun, 1);
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
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.Controls.Add(this.textidobracun, 1, 0);
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.SetColumnSpan(this.textidobracun, 1);
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.SetRowSpan(this.textidobracun, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textidobracun.Margin = padding;
            size = new System.Drawing.Size(0x71, 0x16);
            this.textidobracun.MinimumSize = size;
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.Controls.Add(this.userControlDataGridS_OD_STANJE_OBUSTAVA, 0, 1);
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.SetColumnSpan(this.userControlDataGridS_OD_STANJE_OBUSTAVA, 2);
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.SetRowSpan(this.userControlDataGridS_OD_STANJE_OBUSTAVA, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.MinimumSize = size;
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_OD_STANJE_OBUSTAVA);
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.Name = "userControlDataGridS_OD_STANJE_OBUSTAVA";
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.DockPadding.All = 5;
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.FillAtStartup = false;
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_OD_STANJE_OBUSTAVAWorkWith";
            this.Text = "Work With S_OD_STANJE_OBUSTAVA";
            this.Load += new EventHandler(this.S_OD_STANJE_OBUSTAVAUserControl_Load);
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.ResumeLayout(false);
            this.layoutManagerformS_OD_STANJE_OBUSTAVA.PerformLayout();
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
                        this.Text = Deklarit.Resources.Resources.Select + "S_OD_STANJE_OBUSTAVA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_OD_STANJE_OBUSTAVA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_OD_STANJE_OBUSTAVADataAdapter().Update(this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.DataSet);
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
            this.label1idobracun.Text = StringResources.S_OD_STANJE_OBUSTAVAidobracunParameter;
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

        private void S_OD_STANJE_OBUSTAVAUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_OD_STANJE_OBUSTAVA ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_OD_STANJE_OBUSTAVA ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_OD_STANJE_OBUSTAVAController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataView[this.userControlDataGridS_OD_STANJE_OBUSTAVA.DataGrid.CurrentRowIndex].Row;
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

        protected virtual S_OD_STANJE_OBUSTAVAUserDataGrid userControlDataGridS_OD_STANJE_OBUSTAVA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_OD_STANJE_OBUSTAVA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_OD_STANJE_OBUSTAVA = value;
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

