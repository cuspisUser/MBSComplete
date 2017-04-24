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
    public class S_PLACA_RAD1G_SATIUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1GODINAOBRACUNA")]
        private UltraLabel _label1GODINAOBRACUNA;
        [AccessedThroughProperty("textGODINAOBRACUNA")]
        private UltraTextEditor _textGODINAOBRACUNA;
        [AccessedThroughProperty("userControlDataGridS_PLACA_RAD1G_SATI")]
        private S_PLACA_RAD1G_SATIUserDataGrid _userControlDataGridS_PLACA_RAD1G_SATI;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_PLACA_RAD1G_SATI;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_PLACA_RAD1G_SATIUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_PLACA_RAD1G_SATIDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_PLACA_RAD1G_SATIDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_PLACA_RAD1G_SATIDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_PLACA_RAD1G_SATIDataSet>(this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid);
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
            if ((this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.FillByPage;
                this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_PLACA_RAD1G_SATI.ParameterGODINAOBRACUNA = this.textGODINAOBRACUNA.Text;
                this.userControlDataGridS_PLACA_RAD1G_SATI.Fill();
                ((S_PLACA_RAD1G_SATIWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_PLACA_RAD1G_SATI.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("GODINAOBRACUNA", typeof(string));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["GODINAOBRACUNA"] = this.textGODINAOBRACUNA.Text;
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
            ResourceManager manager = new ResourceManager(typeof(S_PLACA_RAD1G_SATIUserControl));
            this.layoutManagerformS_PLACA_RAD1G_SATI = new TableLayoutPanel();
            this.layoutManagerformS_PLACA_RAD1G_SATI.SuspendLayout();
            this.layoutManagerformS_PLACA_RAD1G_SATI.AutoSize = true;
            this.layoutManagerformS_PLACA_RAD1G_SATI.Dock = DockStyle.Fill;
            this.layoutManagerformS_PLACA_RAD1G_SATI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_PLACA_RAD1G_SATI.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_PLACA_RAD1G_SATI.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_PLACA_RAD1G_SATI.Size = size;
            this.layoutManagerformS_PLACA_RAD1G_SATI.ColumnCount = 2;
            this.layoutManagerformS_PLACA_RAD1G_SATI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_PLACA_RAD1G_SATI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_PLACA_RAD1G_SATI.RowCount = 2;
            this.layoutManagerformS_PLACA_RAD1G_SATI.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_PLACA_RAD1G_SATI.RowStyles.Add(new RowStyle());
            this.label1GODINAOBRACUNA = new UltraLabel();
            this.textGODINAOBRACUNA = new UltraTextEditor();
            this.userControlDataGridS_PLACA_RAD1G_SATI = new S_PLACA_RAD1G_SATIUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textGODINAOBRACUNA).BeginInit();
            this.SuspendLayout();
            this.label1GODINAOBRACUNA.Name = "label1GODINAOBRACUNA";
            this.label1GODINAOBRACUNA.TabIndex = 1;
            this.label1GODINAOBRACUNA.Tag = "labelGODINAOBRACUNA";
            this.label1GODINAOBRACUNA.AutoSize = true;
            this.label1GODINAOBRACUNA.StyleSetName = "FieldUltraLabel";
            this.label1GODINAOBRACUNA.Text = "GODINAOBRACUNA   :";
            this.label1GODINAOBRACUNA.Appearance.TextVAlign = VAlign.Middle;
            this.label1GODINAOBRACUNA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1GODINAOBRACUNA.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_PLACA_RAD1G_SATI.Controls.Add(this.label1GODINAOBRACUNA, 0, 0);
            this.layoutManagerformS_PLACA_RAD1G_SATI.SetColumnSpan(this.label1GODINAOBRACUNA, 1);
            this.layoutManagerformS_PLACA_RAD1G_SATI.SetRowSpan(this.label1GODINAOBRACUNA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1GODINAOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1GODINAOBRACUNA.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textGODINAOBRACUNA.Location = point;
            this.textGODINAOBRACUNA.Name = "textGODINAOBRACUNA";
            this.textGODINAOBRACUNA.Tag = "GODINAOBRACUNA";
            this.textGODINAOBRACUNA.TabIndex = 0;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textGODINAOBRACUNA.Size = size;
            this.textGODINAOBRACUNA.MaxLength = 4;
            this.layoutManagerformS_PLACA_RAD1G_SATI.Controls.Add(this.textGODINAOBRACUNA, 1, 0);
            this.layoutManagerformS_PLACA_RAD1G_SATI.SetColumnSpan(this.textGODINAOBRACUNA, 1);
            this.layoutManagerformS_PLACA_RAD1G_SATI.SetRowSpan(this.textGODINAOBRACUNA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textGODINAOBRACUNA.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textGODINAOBRACUNA.MinimumSize = size;
            this.layoutManagerformS_PLACA_RAD1G_SATI.Controls.Add(this.userControlDataGridS_PLACA_RAD1G_SATI, 0, 1);
            this.layoutManagerformS_PLACA_RAD1G_SATI.SetColumnSpan(this.userControlDataGridS_PLACA_RAD1G_SATI, 2);
            this.layoutManagerformS_PLACA_RAD1G_SATI.SetRowSpan(this.userControlDataGridS_PLACA_RAD1G_SATI, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_PLACA_RAD1G_SATI.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_PLACA_RAD1G_SATI.MinimumSize = size;
            this.userControlDataGridS_PLACA_RAD1G_SATI.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_PLACA_RAD1G_SATI);
            this.userControlDataGridS_PLACA_RAD1G_SATI.Name = "userControlDataGridS_PLACA_RAD1G_SATI";
            this.userControlDataGridS_PLACA_RAD1G_SATI.Dock = DockStyle.Fill;
            this.userControlDataGridS_PLACA_RAD1G_SATI.DockPadding.All = 5;
            this.userControlDataGridS_PLACA_RAD1G_SATI.FillAtStartup = false;
            this.userControlDataGridS_PLACA_RAD1G_SATI.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_PLACA_RAD1G_SATI.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_PLACA_RAD1G_SATI.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_PLACA_RAD1G_SATIWorkWith";
            this.Text = "Work With S_PLACA_RAD1G_SATI";
            this.Load += new EventHandler(this.S_PLACA_RAD1G_SATIUserControl_Load);
            this.layoutManagerformS_PLACA_RAD1G_SATI.ResumeLayout(false);
            this.layoutManagerformS_PLACA_RAD1G_SATI.PerformLayout();
            ((ISupportInitialize) this.textGODINAOBRACUNA).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textGODINAOBRACUNA.Text = "";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("GODINAOBRACUNA") && (this.m_FillByRow["GODINAOBRACUNA"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textGODINAOBRACUNA, this.m_FillByRow["GODINAOBRACUNA"].ToString(), this.m_FillByRow.Table.Columns["GODINAOBRACUNA"].DataType);
                    this.parameterSeted = true;
                    this.textGODINAOBRACUNA.Visible = false;
                    this.label1GODINAOBRACUNA.Visible = false;
                    str = str + "," + this.m_FillByRow["GODINAOBRACUNA"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_PLACA_RAD1G_SATI " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_PLACA_RAD1G_SATI " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_PLACA_RAD1G_SATIDataAdapter().Update(this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.DataSet);
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
            this.label1GODINAOBRACUNA.Text = StringResources.S_PLACA_RAD1G_SATIGODINAOBRACUNAParameter;
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

        private void S_PLACA_RAD1G_SATIUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_PLACA_RAD1G_SATI ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_PLACA_RAD1G_SATI ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_PLACA_RAD1G_SATIController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_PLACA_RAD1G_SATI.DataView[this.userControlDataGridS_PLACA_RAD1G_SATI.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1GODINAOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1GODINAOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1GODINAOBRACUNA = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraTextEditor textGODINAOBRACUNA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textGODINAOBRACUNA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textGODINAOBRACUNA = value;
            }
        }

        protected virtual S_PLACA_RAD1G_SATIUserDataGrid userControlDataGridS_PLACA_RAD1G_SATI
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_PLACA_RAD1G_SATI;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_PLACA_RAD1G_SATI = value;
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

