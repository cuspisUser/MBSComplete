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
    public class S_OD_TABLICA01UserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1GODINA")]
        private UltraLabel _label1GODINA;
        [AccessedThroughProperty("textGODINA")]
        private UltraTextEditor _textGODINA;
        [AccessedThroughProperty("userControlDataGridS_OD_TABLICA01")]
        private S_OD_TABLICA01UserDataGrid _userControlDataGridS_OD_TABLICA01;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_OD_TABLICA01;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_OD_TABLICA01UserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_OD_TABLICA01Description, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_OD_TABLICA01Description);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_OD_TABLICA01.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_OD_TABLICA01DataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_OD_TABLICA01DataSet>(this.userControlDataGridS_OD_TABLICA01.DataGrid);
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
            if ((this.userControlDataGridS_OD_TABLICA01.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_OD_TABLICA01.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_OD_TABLICA01.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_OD_TABLICA01.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_OD_TABLICA01.DataGrid.FillByPage;
                this.userControlDataGridS_OD_TABLICA01.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_OD_TABLICA01.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_OD_TABLICA01.ParameterGODINA = this.textGODINA.Text;
                this.userControlDataGridS_OD_TABLICA01.Fill();
                ((S_OD_TABLICA01WorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_OD_TABLICA01.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("GODINA", typeof(string));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["GODINA"] = this.textGODINA.Text;
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
            ResourceManager manager = new ResourceManager(typeof(S_OD_TABLICA01UserControl));
            this.layoutManagerformS_OD_TABLICA01 = new TableLayoutPanel();
            this.layoutManagerformS_OD_TABLICA01.SuspendLayout();
            this.layoutManagerformS_OD_TABLICA01.AutoSize = true;
            this.layoutManagerformS_OD_TABLICA01.Dock = DockStyle.Fill;
            this.layoutManagerformS_OD_TABLICA01.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_OD_TABLICA01.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_OD_TABLICA01.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_OD_TABLICA01.Size = size;
            this.layoutManagerformS_OD_TABLICA01.ColumnCount = 2;
            this.layoutManagerformS_OD_TABLICA01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OD_TABLICA01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OD_TABLICA01.RowCount = 2;
            this.layoutManagerformS_OD_TABLICA01.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OD_TABLICA01.RowStyles.Add(new RowStyle());
            this.label1GODINA = new UltraLabel();
            this.textGODINA = new UltraTextEditor();
            this.userControlDataGridS_OD_TABLICA01 = new S_OD_TABLICA01UserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textGODINA).BeginInit();
            this.SuspendLayout();
            this.label1GODINA.Name = "label1GODINA";
            this.label1GODINA.TabIndex = 1;
            this.label1GODINA.Tag = "labelGODINA";
            this.label1GODINA.AutoSize = true;
            this.label1GODINA.StyleSetName = "FieldUltraLabel";
            this.label1GODINA.Text = "GODINA   :";
            this.label1GODINA.Appearance.TextVAlign = VAlign.Middle;
            this.label1GODINA.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1GODINA.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OD_TABLICA01.Controls.Add(this.label1GODINA, 0, 0);
            this.layoutManagerformS_OD_TABLICA01.SetColumnSpan(this.label1GODINA, 1);
            this.layoutManagerformS_OD_TABLICA01.SetRowSpan(this.label1GODINA, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1GODINA.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1GODINA.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textGODINA.Location = point;
            this.textGODINA.Name = "textGODINA";
            this.textGODINA.Tag = "GODINA";
            this.textGODINA.TabIndex = 0;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textGODINA.Size = size;
            this.textGODINA.MaxLength = 4;
            this.layoutManagerformS_OD_TABLICA01.Controls.Add(this.textGODINA, 1, 0);
            this.layoutManagerformS_OD_TABLICA01.SetColumnSpan(this.textGODINA, 1);
            this.layoutManagerformS_OD_TABLICA01.SetRowSpan(this.textGODINA, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textGODINA.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textGODINA.MinimumSize = size;
            this.layoutManagerformS_OD_TABLICA01.Controls.Add(this.userControlDataGridS_OD_TABLICA01, 0, 1);
            this.layoutManagerformS_OD_TABLICA01.SetColumnSpan(this.userControlDataGridS_OD_TABLICA01, 2);
            this.layoutManagerformS_OD_TABLICA01.SetRowSpan(this.userControlDataGridS_OD_TABLICA01, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_OD_TABLICA01.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_OD_TABLICA01.MinimumSize = size;
            this.userControlDataGridS_OD_TABLICA01.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_OD_TABLICA01);
            this.userControlDataGridS_OD_TABLICA01.Name = "userControlDataGridS_OD_TABLICA01";
            this.userControlDataGridS_OD_TABLICA01.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_TABLICA01.DockPadding.All = 5;
            this.userControlDataGridS_OD_TABLICA01.FillAtStartup = false;
            this.userControlDataGridS_OD_TABLICA01.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_TABLICA01.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_OD_TABLICA01.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_OD_TABLICA01.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_OD_TABLICA01WorkWith";
            this.Text = "Work With S_OD_TABLICA01";
            this.Load += new EventHandler(this.S_OD_TABLICA01UserControl_Load);
            this.layoutManagerformS_OD_TABLICA01.ResumeLayout(false);
            this.layoutManagerformS_OD_TABLICA01.PerformLayout();
            ((ISupportInitialize) this.textGODINA).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textGODINA.Text = "";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("GODINA") && (this.m_FillByRow["GODINA"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textGODINA, this.m_FillByRow["GODINA"].ToString(), this.m_FillByRow.Table.Columns["GODINA"].DataType);
                    this.parameterSeted = true;
                    this.textGODINA.Visible = false;
                    this.label1GODINA.Visible = false;
                    str = str + "," + this.m_FillByRow["GODINA"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_OD_TABLICA01 " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_OD_TABLICA01 " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_OD_TABLICA01.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_OD_TABLICA01.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_OD_TABLICA01DataAdapter().Update(this.userControlDataGridS_OD_TABLICA01.DataGrid.DataSet);
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
            this.label1GODINA.Text = StringResources.S_OD_TABLICA01GODINAParameter;
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

        private void S_OD_TABLICA01UserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_OD_TABLICA01.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_OD_TABLICA01.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_OD_TABLICA01.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_OD_TABLICA01.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_OD_TABLICA01.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_OD_TABLICA01.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_OD_TABLICA01.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_OD_TABLICA01.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_OD_TABLICA01.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_OD_TABLICA01.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_OD_TABLICA01.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_OD_TABLICA01 ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_OD_TABLICA01 ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_OD_TABLICA01Controller Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_OD_TABLICA01.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_OD_TABLICA01.DataView[this.userControlDataGridS_OD_TABLICA01.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1GODINA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1GODINA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1GODINA = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraTextEditor textGODINA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textGODINA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textGODINA = value;
            }
        }

        protected virtual S_OD_TABLICA01UserDataGrid userControlDataGridS_OD_TABLICA01
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_OD_TABLICA01;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_OD_TABLICA01 = value;
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

