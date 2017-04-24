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
    public class S_DD_LISTA_IZNOSA_RADNIKAUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1IDOBRACUN")]
        private UltraLabel _label1IDOBRACUN;
        [AccessedThroughProperty("label1SORT")]
        private UltraLabel _label1SORT;
        [AccessedThroughProperty("textIDOBRACUN")]
        private UltraTextEditor _textIDOBRACUN;
        [AccessedThroughProperty("textSORT")]
        private UltraNumericEditor _textSORT;
        [AccessedThroughProperty("userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA")]
        private S_DD_LISTA_IZNOSA_RADNIKAUserDataGrid _userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_DD_LISTA_IZNOSA_RADNIKAUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_DD_LISTA_IZNOSA_RADNIKADescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_DD_LISTA_IZNOSA_RADNIKADescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_DD_LISTA_IZNOSA_RADNIKADataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_DD_LISTA_IZNOSA_RADNIKADataSet>(this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        private void CallPromptOBRACUNIDOBRACUN(object sender, EditorButtonEventArgs e)
        {
            S_DD_LISTA_IZNOSA_RADNIKAController controller = this.Controller.WorkItem.Items.AddNew<S_DD_LISTA_IZNOSA_RADNIKAController>();
            DataRow parameterRow = this.GetParameterRow();
            DataRow row = controller.SelectOBRACUNIDOBRACUN("", parameterRow);
            if (row != null)
            {
                this.textIDOBRACUN.Text = row["IDOBRACUN"].ToString();
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
            if ((this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.FillByPage;
                this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.ParameterIDOBRACUN = this.textIDOBRACUN.Text;
                this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.ParameterSORT = int.Parse(this.textSORT.Value.ToString(), CultureInfo.CurrentCulture);
                this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.Fill();
                ((S_DD_LISTA_IZNOSA_RADNIKAWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("IDOBRACUN", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("SORT", typeof(int));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["IDOBRACUN"] = this.textIDOBRACUN.Text;
            row2["SORT"] = int.Parse(this.textSORT.Value.ToString(), CultureInfo.CurrentCulture);
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
            ResourceManager manager = new ResourceManager(typeof(S_DD_LISTA_IZNOSA_RADNIKAUserControl));
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA = new TableLayoutPanel();
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.SuspendLayout();
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.AutoSize = true;
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.Dock = DockStyle.Fill;
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.Size = size;
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.ColumnCount = 2;
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.RowCount = 3;
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.RowStyles.Add(new RowStyle());
            this.label1IDOBRACUN = new UltraLabel();
            this.textIDOBRACUN = new UltraTextEditor();
            this.label1SORT = new UltraLabel();
            this.textSORT = new UltraNumericEditor();
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA = new S_DD_LISTA_IZNOSA_RADNIKAUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textIDOBRACUN).BeginInit();
            ((ISupportInitialize) this.textSORT).BeginInit();
            this.SuspendLayout();
            this.label1IDOBRACUN.Name = "label1IDOBRACUN";
            this.label1IDOBRACUN.TabIndex = 1;
            this.label1IDOBRACUN.Tag = "labelIDOBRACUN";
            this.label1IDOBRACUN.AutoSize = true;
            this.label1IDOBRACUN.StyleSetName = "FieldUltraLabel";
            this.label1IDOBRACUN.Text = "IDOBRACUN     :";
            this.label1IDOBRACUN.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOBRACUN.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1IDOBRACUN.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.Controls.Add(this.label1IDOBRACUN, 0, 0);
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.SetColumnSpan(this.label1IDOBRACUN, 1);
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.SetRowSpan(this.label1IDOBRACUN, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDOBRACUN.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textIDOBRACUN.Location = point;
            this.textIDOBRACUN.Name = "textIDOBRACUN";
            this.textIDOBRACUN.Tag = "IDOBRACUN";
            this.textIDOBRACUN.TabIndex = 0;
            size = new System.Drawing.Size(0x71, 0x16);
            this.textIDOBRACUN.Size = size;
            this.textIDOBRACUN.MaxLength = 11;
            EditorButton button = new EditorButton {
                Key = "editorButtonOBRACUNIDOBRACUN",
                Tag = "editorButtonOBRACUNIDOBRACUN",
                Text = "..."
            };
            this.textIDOBRACUN.ButtonsRight.Add(button);
            this.textIDOBRACUN.EditorButtonClick += new EditorButtonEventHandler(this.CallPromptOBRACUNIDOBRACUN);
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.Controls.Add(this.textIDOBRACUN, 1, 0);
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.SetColumnSpan(this.textIDOBRACUN, 1);
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.SetRowSpan(this.textIDOBRACUN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0x71, 0x16);
            this.textIDOBRACUN.MinimumSize = size;
            this.label1SORT.Name = "label1SORT";
            this.label1SORT.TabIndex = 1;
            this.label1SORT.Tag = "labelSORT";
            this.label1SORT.AutoSize = true;
            this.label1SORT.StyleSetName = "FieldUltraLabel";
            this.label1SORT.Text = "SORT     :";
            this.label1SORT.Appearance.TextVAlign = VAlign.Middle;
            this.label1SORT.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1SORT.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.Controls.Add(this.label1SORT, 0, 1);
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.SetColumnSpan(this.label1SORT, 1);
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.SetRowSpan(this.label1SORT, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1SORT.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1SORT.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textSORT.Location = point;
            this.textSORT.Name = "textSORT";
            this.textSORT.Tag = "SORT";
            this.textSORT.TabIndex = 1;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textSORT.Size = size;
            this.textSORT.PromptChar = ' ';
            this.textSORT.Enter += new EventHandler(this.numericEditor_Enter);
            this.textSORT.NumericType = NumericType.Integer;
            this.textSORT.MaskInput = "{LOC}-nnnnn";
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.Controls.Add(this.textSORT, 1, 1);
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.SetColumnSpan(this.textSORT, 1);
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.SetRowSpan(this.textSORT, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textSORT.Margin = padding;
            size = new System.Drawing.Size(0x33, 0x16);
            this.textSORT.MinimumSize = size;
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.Controls.Add(this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA, 0, 2);
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.SetColumnSpan(this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA, 2);
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.SetRowSpan(this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.MinimumSize = size;
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA);
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.Name = "userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA";
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.Dock = DockStyle.Fill;
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DockPadding.All = 5;
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.FillAtStartup = false;
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_DD_LISTA_IZNOSA_RADNIKAWorkWith";
            this.Text = "Work With S_DD_LISTA_IZNOSA_RADNIKA";
            this.Load += new EventHandler(this.S_DD_LISTA_IZNOSA_RADNIKAUserControl_Load);
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.ResumeLayout(false);
            this.layoutManagerformS_DD_LISTA_IZNOSA_RADNIKA.PerformLayout();
            ((ISupportInitialize) this.textIDOBRACUN).EndInit();
            ((ISupportInitialize) this.textSORT).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textIDOBRACUN.Text = "";
            this.textSORT.Text = "0";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("IDOBRACUN") && (this.m_FillByRow["IDOBRACUN"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textIDOBRACUN, this.m_FillByRow["IDOBRACUN"].ToString(), this.m_FillByRow.Table.Columns["IDOBRACUN"].DataType);
                    this.parameterSeted = true;
                    this.textIDOBRACUN.Visible = false;
                    this.label1IDOBRACUN.Visible = false;
                    str = str + "," + this.m_FillByRow["IDOBRACUN"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("SORT") && (this.m_FillByRow["SORT"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textSORT, this.m_FillByRow["SORT"].ToString(), this.m_FillByRow.Table.Columns["SORT"].DataType);
                    this.parameterSeted = true;
                    this.textSORT.Visible = false;
                    this.label1SORT.Visible = false;
                    str = str + "," + this.m_FillByRow["SORT"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_DD_LISTA_IZNOSA_RADNIKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_DD_LISTA_IZNOSA_RADNIKA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_DD_LISTA_IZNOSA_RADNIKADataAdapter().Update(this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.DataSet);
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
            this.label1IDOBRACUN.Text = StringResources.S_DD_LISTA_IZNOSA_RADNIKAIDOBRACUNParameter;
            this.label1SORT.Text = StringResources.S_DD_LISTA_IZNOSA_RADNIKASORTParameter;
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

        private void S_DD_LISTA_IZNOSA_RADNIKAUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_DD_LISTA_IZNOSA_RADNIKA ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_DD_LISTA_IZNOSA_RADNIKA ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_DD_LISTA_IZNOSA_RADNIKAController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataView[this.userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1IDOBRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDOBRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDOBRACUN = value;
            }
        }

        protected virtual UltraLabel label1SORT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1SORT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1SORT = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraTextEditor textIDOBRACUN
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textIDOBRACUN;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textIDOBRACUN = value;
            }
        }

        protected virtual UltraNumericEditor textSORT
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textSORT;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textSORT = value;
            }
        }

        protected virtual S_DD_LISTA_IZNOSA_RADNIKAUserDataGrid userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_DD_LISTA_IZNOSA_RADNIKA = value;
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

