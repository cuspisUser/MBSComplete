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
    public class sp_diskete_za_bankuUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1idobracun")]
        private UltraLabel _label1idobracun;
        [AccessedThroughProperty("label1vbdibanke")]
        private UltraLabel _label1vbdibanke;
        [AccessedThroughProperty("textidobracun")]
        private UltraTextEditor _textidobracun;
        [AccessedThroughProperty("textvbdibanke")]
        private UltraTextEditor _textvbdibanke;
        [AccessedThroughProperty("userControlDataGridsp_diskete_za_banku")]
        private sp_diskete_za_bankuUserDataGrid _userControlDataGridsp_diskete_za_banku;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformsp_diskete_za_banku;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public sp_diskete_za_bankuUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.sp_diskete_za_bankuDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.sp_diskete_za_bankuDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridsp_diskete_za_banku.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<sp_diskete_za_bankuDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<sp_diskete_za_bankuDataSet>(this.userControlDataGridsp_diskete_za_banku.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        private void CallPromptOBRACUNidobracun(object sender, EditorButtonEventArgs e)
        {
            sp_diskete_za_bankuController controller = this.Controller.WorkItem.Items.AddNew<sp_diskete_za_bankuController>();
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
            if ((this.userControlDataGridsp_diskete_za_banku.DataGrid.Rows.Count > 0) && (this.userControlDataGridsp_diskete_za_banku.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridsp_diskete_za_banku.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridsp_diskete_za_banku.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridsp_diskete_za_banku.DataGrid.FillByPage;
                this.userControlDataGridsp_diskete_za_banku.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridsp_diskete_za_banku.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridsp_diskete_za_banku.Parameteridobracun = this.textidobracun.Text;
                this.userControlDataGridsp_diskete_za_banku.Parametervbdibanke = this.textvbdibanke.Text;
                this.userControlDataGridsp_diskete_za_banku.Fill();
                ((sp_diskete_za_bankuWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridsp_diskete_za_banku.DataView.Table.DataSet;
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
            column = new DataColumn("vbdibanke", typeof(string));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["idobracun"] = this.textidobracun.Text;
            row2["vbdibanke"] = this.textvbdibanke.Text;
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
            ResourceManager manager = new ResourceManager(typeof(sp_diskete_za_bankuUserControl));
            this.layoutManagerformsp_diskete_za_banku = new TableLayoutPanel();
            this.layoutManagerformsp_diskete_za_banku.SuspendLayout();
            this.layoutManagerformsp_diskete_za_banku.AutoSize = true;
            this.layoutManagerformsp_diskete_za_banku.Dock = DockStyle.Fill;
            this.layoutManagerformsp_diskete_za_banku.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformsp_diskete_za_banku.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformsp_diskete_za_banku.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformsp_diskete_za_banku.Size = size;
            this.layoutManagerformsp_diskete_za_banku.ColumnCount = 2;
            this.layoutManagerformsp_diskete_za_banku.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformsp_diskete_za_banku.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformsp_diskete_za_banku.RowCount = 3;
            this.layoutManagerformsp_diskete_za_banku.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_diskete_za_banku.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_diskete_za_banku.RowStyles.Add(new RowStyle());
            this.label1idobracun = new UltraLabel();
            this.textidobracun = new UltraTextEditor();
            this.label1vbdibanke = new UltraLabel();
            this.textvbdibanke = new UltraTextEditor();
            this.userControlDataGridsp_diskete_za_banku = new sp_diskete_za_bankuUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textidobracun).BeginInit();
            ((ISupportInitialize) this.textvbdibanke).BeginInit();
            this.SuspendLayout();
            this.label1idobracun.Name = "label1idobracun";
            this.label1idobracun.TabIndex = 1;
            this.label1idobracun.Tag = "labelidobracun";
            this.label1idobracun.AutoSize = true;
            this.label1idobracun.StyleSetName = "FieldUltraLabel";
            this.label1idobracun.Text = "idobracun    :";
            this.label1idobracun.Appearance.TextVAlign = VAlign.Middle;
            this.label1idobracun.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1idobracun.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_diskete_za_banku.Controls.Add(this.label1idobracun, 0, 0);
            this.layoutManagerformsp_diskete_za_banku.SetColumnSpan(this.label1idobracun, 1);
            this.layoutManagerformsp_diskete_za_banku.SetRowSpan(this.label1idobracun, 1);
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
            this.layoutManagerformsp_diskete_za_banku.Controls.Add(this.textidobracun, 1, 0);
            this.layoutManagerformsp_diskete_za_banku.SetColumnSpan(this.textidobracun, 1);
            this.layoutManagerformsp_diskete_za_banku.SetRowSpan(this.textidobracun, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textidobracun.Margin = padding;
            size = new System.Drawing.Size(0x71, 0x16);
            this.textidobracun.MinimumSize = size;
            this.label1vbdibanke.Name = "label1vbdibanke";
            this.label1vbdibanke.TabIndex = 1;
            this.label1vbdibanke.Tag = "labelvbdibanke";
            this.label1vbdibanke.AutoSize = true;
            this.label1vbdibanke.StyleSetName = "FieldUltraLabel";
            this.label1vbdibanke.Text = "vbdibanke    :";
            this.label1vbdibanke.Appearance.TextVAlign = VAlign.Middle;
            this.label1vbdibanke.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1vbdibanke.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_diskete_za_banku.Controls.Add(this.label1vbdibanke, 0, 1);
            this.layoutManagerformsp_diskete_za_banku.SetColumnSpan(this.label1vbdibanke, 1);
            this.layoutManagerformsp_diskete_za_banku.SetRowSpan(this.label1vbdibanke, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1vbdibanke.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1vbdibanke.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textvbdibanke.Location = point;
            this.textvbdibanke.Name = "textvbdibanke";
            this.textvbdibanke.Tag = "vbdibanke";
            this.textvbdibanke.TabIndex = 1;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textvbdibanke.Size = size;
            this.textvbdibanke.MaxLength = 7;
            this.layoutManagerformsp_diskete_za_banku.Controls.Add(this.textvbdibanke, 1, 1);
            this.layoutManagerformsp_diskete_za_banku.SetColumnSpan(this.textvbdibanke, 1);
            this.layoutManagerformsp_diskete_za_banku.SetRowSpan(this.textvbdibanke, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textvbdibanke.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textvbdibanke.MinimumSize = size;
            this.layoutManagerformsp_diskete_za_banku.Controls.Add(this.userControlDataGridsp_diskete_za_banku, 0, 2);
            this.layoutManagerformsp_diskete_za_banku.SetColumnSpan(this.userControlDataGridsp_diskete_za_banku, 2);
            this.layoutManagerformsp_diskete_za_banku.SetRowSpan(this.userControlDataGridsp_diskete_za_banku, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridsp_diskete_za_banku.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridsp_diskete_za_banku.MinimumSize = size;
            this.userControlDataGridsp_diskete_za_banku.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformsp_diskete_za_banku);
            this.userControlDataGridsp_diskete_za_banku.Name = "userControlDataGridsp_diskete_za_banku";
            this.userControlDataGridsp_diskete_za_banku.Dock = DockStyle.Fill;
            this.userControlDataGridsp_diskete_za_banku.DockPadding.All = 5;
            this.userControlDataGridsp_diskete_za_banku.FillAtStartup = false;
            this.userControlDataGridsp_diskete_za_banku.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridsp_diskete_za_banku.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridsp_diskete_za_banku.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridsp_diskete_za_banku.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "sp_diskete_za_bankuWorkWith";
            this.Text = "Work With sp_diskete_za_banku";
            this.Load += new EventHandler(this.sp_diskete_za_bankuUserControl_Load);
            this.layoutManagerformsp_diskete_za_banku.ResumeLayout(false);
            this.layoutManagerformsp_diskete_za_banku.PerformLayout();
            ((ISupportInitialize) this.textidobracun).EndInit();
            ((ISupportInitialize) this.textvbdibanke).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textidobracun.Text = "";
            this.textvbdibanke.Text = "";
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
                if (this.m_FillByRow.Table.Columns.Contains("vbdibanke") && (this.m_FillByRow["vbdibanke"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textvbdibanke, this.m_FillByRow["vbdibanke"].ToString(), this.m_FillByRow.Table.Columns["vbdibanke"].DataType);
                    this.parameterSeted = true;
                    this.textvbdibanke.Visible = false;
                    this.label1vbdibanke.Visible = false;
                    str = str + "," + this.m_FillByRow["vbdibanke"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "sp_diskete_za_banku " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "sp_diskete_za_banku " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridsp_diskete_za_banku.DataGrid.DataSet.Clear();
                    this.userControlDataGridsp_diskete_za_banku.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new sp_diskete_za_bankuDataAdapter().Update(this.userControlDataGridsp_diskete_za_banku.DataGrid.DataSet);
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
            this.label1idobracun.Text = StringResources.sp_diskete_za_bankuidobracunParameter;
            this.label1vbdibanke.Text = StringResources.sp_diskete_za_bankuvbdibankeParameter;
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
                this.userControlDataGridsp_diskete_za_banku.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridsp_diskete_za_banku.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} sp_diskete_za_banku ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} sp_diskete_za_banku ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void sp_diskete_za_bankuUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridsp_diskete_za_banku.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridsp_diskete_za_banku.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridsp_diskete_za_banku.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridsp_diskete_za_banku.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridsp_diskete_za_banku.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridsp_diskete_za_banku.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridsp_diskete_za_banku.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridsp_diskete_za_banku.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridsp_diskete_za_banku.DataGrid.FillByPage = true;
                this.FillData();
            }
        }

        [CreateNew]
        public sp_diskete_za_bankuController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridsp_diskete_za_banku.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridsp_diskete_za_banku.DataView[this.userControlDataGridsp_diskete_za_banku.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1vbdibanke
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1vbdibanke;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1vbdibanke = value;
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

        protected virtual UltraTextEditor textvbdibanke
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textvbdibanke;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textvbdibanke = value;
            }
        }

        protected virtual sp_diskete_za_bankuUserDataGrid userControlDataGridsp_diskete_za_banku
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridsp_diskete_za_banku;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridsp_diskete_za_banku = value;
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

