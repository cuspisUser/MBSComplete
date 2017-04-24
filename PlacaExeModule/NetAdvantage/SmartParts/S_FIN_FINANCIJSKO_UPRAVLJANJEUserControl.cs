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
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    [SmartPart]
    public class S_FIN_FINANCIJSKO_UPRAVLJANJEUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("datePickerRAZDOBLJEDO")]
        private UltraDateTimeEditor _datePickerRAZDOBLJEDO;
        [AccessedThroughProperty("datePickerRAZDOBLJEOD")]
        private UltraDateTimeEditor _datePickerRAZDOBLJEOD;
        [AccessedThroughProperty("label1RAZDOBLJEDO")]
        private UltraLabel _label1RAZDOBLJEDO;
        [AccessedThroughProperty("label1RAZDOBLJEOD")]
        private UltraLabel _label1RAZDOBLJEOD;
        [AccessedThroughProperty("userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE")]
        private S_FIN_FINANCIJSKO_UPRAVLJANJEUserDataGrid _userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_FIN_FINANCIJSKO_UPRAVLJANJEUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_FIN_FINANCIJSKO_UPRAVLJANJEDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_FIN_FINANCIJSKO_UPRAVLJANJEDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_FIN_FINANCIJSKO_UPRAVLJANJEDataSet>(this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid);
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
            if ((this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.FillByPage;
                this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                if (this.datePickerRAZDOBLJEOD.Value == null)
                {
                    this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.ParameterRAZDOBLJEOD = DateTime.MinValue;
                }
                else
                {
                    this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.ParameterRAZDOBLJEOD = DateTime.Parse(this.datePickerRAZDOBLJEOD.Value.ToString(), CultureInfo.CurrentCulture);
                }
                if (this.datePickerRAZDOBLJEDO.Value == null)
                {
                    this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.ParameterRAZDOBLJEDO = DateTime.MinValue;
                }
                else
                {
                    this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.ParameterRAZDOBLJEDO = DateTime.Parse(this.datePickerRAZDOBLJEDO.Value.ToString(), CultureInfo.CurrentCulture);
                }
                this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.Fill();
                ((S_FIN_FINANCIJSKO_UPRAVLJANJEWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("RAZDOBLJEOD", typeof(DateTime));
            table2.Columns.Add(column);
            column = new DataColumn("RAZDOBLJEDO", typeof(DateTime));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            if (this.datePickerRAZDOBLJEOD.Value == null)
            {
                row2["RAZDOBLJEOD"] = DateTime.MinValue;
            }
            else
            {
                row2["RAZDOBLJEOD"] = DateTime.Parse(this.datePickerRAZDOBLJEOD.Value.ToString(), CultureInfo.CurrentCulture);
            }
            if (this.datePickerRAZDOBLJEDO.Value == null)
            {
                row2["RAZDOBLJEDO"] = DateTime.MinValue;
                return row2;
            }
            row2["RAZDOBLJEDO"] = DateTime.Parse(this.datePickerRAZDOBLJEDO.Value.ToString(), CultureInfo.CurrentCulture);
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
            ResourceManager manager = new ResourceManager(typeof(S_FIN_FINANCIJSKO_UPRAVLJANJEUserControl));
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE = new TableLayoutPanel();
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.SuspendLayout();
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.AutoSize = true;
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.Dock = DockStyle.Fill;
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.Size = size;
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.ColumnCount = 2;
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.RowCount = 3;
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.RowStyles.Add(new RowStyle());
            this.label1RAZDOBLJEOD = new UltraLabel();
            this.datePickerRAZDOBLJEOD = new UltraDateTimeEditor();
            this.label1RAZDOBLJEDO = new UltraLabel();
            this.datePickerRAZDOBLJEDO = new UltraDateTimeEditor();
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE = new S_FIN_FINANCIJSKO_UPRAVLJANJEUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            this.SuspendLayout();
            this.label1RAZDOBLJEOD.Name = "label1RAZDOBLJEOD";
            this.label1RAZDOBLJEOD.TabIndex = 1;
            this.label1RAZDOBLJEOD.Tag = "labelRAZDOBLJEOD";
            this.label1RAZDOBLJEOD.AutoSize = true;
            this.label1RAZDOBLJEOD.StyleSetName = "FieldUltraLabel";
            this.label1RAZDOBLJEOD.Text = "RAZDOBLJEOD   :";
            this.label1RAZDOBLJEOD.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAZDOBLJEOD.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1RAZDOBLJEOD.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.Controls.Add(this.label1RAZDOBLJEOD, 0, 0);
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.SetColumnSpan(this.label1RAZDOBLJEOD, 1);
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.SetRowSpan(this.label1RAZDOBLJEOD, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1RAZDOBLJEOD.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAZDOBLJEOD.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerRAZDOBLJEOD.Location = point;
            this.datePickerRAZDOBLJEOD.Name = "datePickerRAZDOBLJEOD";
            this.datePickerRAZDOBLJEOD.Tag = "RAZDOBLJEOD";
            this.datePickerRAZDOBLJEOD.TabIndex = 0;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerRAZDOBLJEOD.Size = size;
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.Controls.Add(this.datePickerRAZDOBLJEOD, 1, 0);
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.SetColumnSpan(this.datePickerRAZDOBLJEOD, 1);
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.SetRowSpan(this.datePickerRAZDOBLJEOD, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerRAZDOBLJEOD.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerRAZDOBLJEOD.MinimumSize = size;
            this.label1RAZDOBLJEDO.Name = "label1RAZDOBLJEDO";
            this.label1RAZDOBLJEDO.TabIndex = 1;
            this.label1RAZDOBLJEDO.Tag = "labelRAZDOBLJEDO";
            this.label1RAZDOBLJEDO.AutoSize = true;
            this.label1RAZDOBLJEDO.StyleSetName = "FieldUltraLabel";
            this.label1RAZDOBLJEDO.Text = "RAZDOBLJEDO   :";
            this.label1RAZDOBLJEDO.Appearance.TextVAlign = VAlign.Middle;
            this.label1RAZDOBLJEDO.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1RAZDOBLJEDO.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.Controls.Add(this.label1RAZDOBLJEDO, 0, 1);
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.SetColumnSpan(this.label1RAZDOBLJEDO, 1);
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.SetRowSpan(this.label1RAZDOBLJEDO, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1RAZDOBLJEDO.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1RAZDOBLJEDO.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.datePickerRAZDOBLJEDO.Location = point;
            this.datePickerRAZDOBLJEDO.Name = "datePickerRAZDOBLJEDO";
            this.datePickerRAZDOBLJEDO.Tag = "RAZDOBLJEDO";
            this.datePickerRAZDOBLJEDO.TabIndex = 1;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerRAZDOBLJEDO.Size = size;
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.Controls.Add(this.datePickerRAZDOBLJEDO, 1, 1);
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.SetColumnSpan(this.datePickerRAZDOBLJEDO, 1);
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.SetRowSpan(this.datePickerRAZDOBLJEDO, 1);
            padding = new Padding(0, 1, 3, 2);
            this.datePickerRAZDOBLJEDO.Margin = padding;
            size = new System.Drawing.Size(100, 0x16);
            this.datePickerRAZDOBLJEDO.MinimumSize = size;
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.Controls.Add(this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE, 0, 2);
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.SetColumnSpan(this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE, 2);
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.SetRowSpan(this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.MinimumSize = size;
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE);
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.Name = "userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE";
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DockPadding.All = 5;
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.FillAtStartup = false;
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_FIN_FINANCIJSKO_UPRAVLJANJEWorkWith";
            this.Text = "Work With S_FIN_FINANCIJSKO_UPRAVLJANJE";
            this.Load += new EventHandler(this.S_FIN_FINANCIJSKO_UPRAVLJANJEUserControl_Load);
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.ResumeLayout(false);
            this.layoutManagerformS_FIN_FINANCIJSKO_UPRAVLJANJE.PerformLayout();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.datePickerRAZDOBLJEOD.Text = "";
            this.datePickerRAZDOBLJEDO.Text = "";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("RAZDOBLJEOD") && (this.m_FillByRow["RAZDOBLJEOD"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.datePickerRAZDOBLJEOD, this.m_FillByRow["RAZDOBLJEOD"].ToString(), this.m_FillByRow.Table.Columns["RAZDOBLJEOD"].DataType);
                    this.parameterSeted = true;
                    this.datePickerRAZDOBLJEOD.Visible = false;
                    this.label1RAZDOBLJEOD.Visible = false;
                    str = str + "," + this.m_FillByRow["RAZDOBLJEOD"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("RAZDOBLJEDO") && (this.m_FillByRow["RAZDOBLJEDO"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.datePickerRAZDOBLJEDO, this.m_FillByRow["RAZDOBLJEDO"].ToString(), this.m_FillByRow.Table.Columns["RAZDOBLJEDO"].DataType);
                    this.parameterSeted = true;
                    this.datePickerRAZDOBLJEDO.Visible = false;
                    this.label1RAZDOBLJEDO.Visible = false;
                    str = str + "," + this.m_FillByRow["RAZDOBLJEDO"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_FIN_FINANCIJSKO_UPRAVLJANJE " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_FIN_FINANCIJSKO_UPRAVLJANJE " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_FIN_FINANCIJSKO_UPRAVLJANJEDataAdapter().Update(this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.DataSet);
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
            this.label1RAZDOBLJEOD.Text = StringResources.S_FIN_FINANCIJSKO_UPRAVLJANJERAZDOBLJEODParameter;
            this.label1RAZDOBLJEDO.Text = StringResources.S_FIN_FINANCIJSKO_UPRAVLJANJERAZDOBLJEDOParameter;
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

        private void S_FIN_FINANCIJSKO_UPRAVLJANJEUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_FINANCIJSKO_UPRAVLJANJE ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_FINANCIJSKO_UPRAVLJANJE ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_FIN_FINANCIJSKO_UPRAVLJANJEController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataView[this.userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE.DataGrid.CurrentRowIndex].Row;
            }
        }

        protected virtual UltraDateTimeEditor datePickerRAZDOBLJEDO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerRAZDOBLJEDO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerRAZDOBLJEDO = value;
            }
        }

        protected virtual UltraDateTimeEditor datePickerRAZDOBLJEOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._datePickerRAZDOBLJEOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._datePickerRAZDOBLJEOD = value;
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

        protected virtual UltraLabel label1RAZDOBLJEDO
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAZDOBLJEDO;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAZDOBLJEDO = value;
            }
        }

        protected virtual UltraLabel label1RAZDOBLJEOD
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1RAZDOBLJEOD;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1RAZDOBLJEOD = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual S_FIN_FINANCIJSKO_UPRAVLJANJEUserDataGrid userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_FIN_FINANCIJSKO_UPRAVLJANJE = value;
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

