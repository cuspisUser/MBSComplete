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
    public class sp_zap1UserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1IDOBRACUN")]
        private UltraLabel _label1IDOBRACUN;
        [AccessedThroughProperty("textIDOBRACUN")]
        private UltraTextEditor _textIDOBRACUN;
        [AccessedThroughProperty("userControlDataGridsp_zap1")]
        private sp_zap1UserDataGrid _userControlDataGridsp_zap1;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformsp_zap1;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public sp_zap1UserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.sp_zap1Description, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.sp_zap1Description);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridsp_zap1.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<sp_zap1DataSet> serviceInstance = new UltraGridSelectedRowsProviderService<sp_zap1DataSet>(this.userControlDataGridsp_zap1.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        private void CallPromptOBRACUNIDOBRACUN(object sender, EditorButtonEventArgs e)
        {
            sp_zap1Controller controller = this.Controller.WorkItem.Items.AddNew<sp_zap1Controller>();
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
            if ((this.userControlDataGridsp_zap1.DataGrid.Rows.Count > 0) && (this.userControlDataGridsp_zap1.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridsp_zap1.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridsp_zap1.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridsp_zap1.DataGrid.FillByPage;
                this.userControlDataGridsp_zap1.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridsp_zap1.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridsp_zap1.ParameterIDOBRACUN = this.textIDOBRACUN.Text;
                this.userControlDataGridsp_zap1.Fill();
                ((sp_zap1WorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridsp_zap1.DataView.Table.DataSet;
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
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["IDOBRACUN"] = this.textIDOBRACUN.Text;
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
            ResourceManager manager = new ResourceManager(typeof(sp_zap1UserControl));
            this.layoutManagerformsp_zap1 = new TableLayoutPanel();
            this.layoutManagerformsp_zap1.SuspendLayout();
            this.layoutManagerformsp_zap1.AutoSize = true;
            this.layoutManagerformsp_zap1.Dock = DockStyle.Fill;
            this.layoutManagerformsp_zap1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformsp_zap1.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformsp_zap1.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformsp_zap1.Size = size;
            this.layoutManagerformsp_zap1.ColumnCount = 2;
            this.layoutManagerformsp_zap1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformsp_zap1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformsp_zap1.RowCount = 2;
            this.layoutManagerformsp_zap1.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_zap1.RowStyles.Add(new RowStyle());
            this.label1IDOBRACUN = new UltraLabel();
            this.textIDOBRACUN = new UltraTextEditor();
            this.userControlDataGridsp_zap1 = new sp_zap1UserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textIDOBRACUN).BeginInit();
            this.SuspendLayout();
            this.label1IDOBRACUN.Name = "label1IDOBRACUN";
            this.label1IDOBRACUN.TabIndex = 1;
            this.label1IDOBRACUN.Tag = "labelIDOBRACUN";
            this.label1IDOBRACUN.AutoSize = true;
            this.label1IDOBRACUN.StyleSetName = "FieldUltraLabel";
            this.label1IDOBRACUN.Text = "IDOBRACUN       :";
            this.label1IDOBRACUN.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOBRACUN.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1IDOBRACUN.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_zap1.Controls.Add(this.label1IDOBRACUN, 0, 0);
            this.layoutManagerformsp_zap1.SetColumnSpan(this.label1IDOBRACUN, 1);
            this.layoutManagerformsp_zap1.SetRowSpan(this.label1IDOBRACUN, 1);
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
            this.layoutManagerformsp_zap1.Controls.Add(this.textIDOBRACUN, 1, 0);
            this.layoutManagerformsp_zap1.SetColumnSpan(this.textIDOBRACUN, 1);
            this.layoutManagerformsp_zap1.SetRowSpan(this.textIDOBRACUN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0x71, 0x16);
            this.textIDOBRACUN.MinimumSize = size;
            this.layoutManagerformsp_zap1.Controls.Add(this.userControlDataGridsp_zap1, 0, 1);
            this.layoutManagerformsp_zap1.SetColumnSpan(this.userControlDataGridsp_zap1, 2);
            this.layoutManagerformsp_zap1.SetRowSpan(this.userControlDataGridsp_zap1, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridsp_zap1.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridsp_zap1.MinimumSize = size;
            this.userControlDataGridsp_zap1.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformsp_zap1);
            this.userControlDataGridsp_zap1.Name = "userControlDataGridsp_zap1";
            this.userControlDataGridsp_zap1.Dock = DockStyle.Fill;
            this.userControlDataGridsp_zap1.DockPadding.All = 5;
            this.userControlDataGridsp_zap1.FillAtStartup = false;
            this.userControlDataGridsp_zap1.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridsp_zap1.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridsp_zap1.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridsp_zap1.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "sp_zap1WorkWith";
            this.Text = "Work With sp_zap1";
            this.Load += new EventHandler(this.sp_zap1UserControl_Load);
            this.layoutManagerformsp_zap1.ResumeLayout(false);
            this.layoutManagerformsp_zap1.PerformLayout();
            ((ISupportInitialize) this.textIDOBRACUN).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textIDOBRACUN.Text = "";
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
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "sp_zap1 " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "sp_zap1 " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridsp_zap1.DataGrid.DataSet.Clear();
                    this.userControlDataGridsp_zap1.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new sp_zap1DataAdapter().Update(this.userControlDataGridsp_zap1.DataGrid.DataSet);
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
            this.label1IDOBRACUN.Text = StringResources.sp_zap1IDOBRACUNParameter;
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
                this.userControlDataGridsp_zap1.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridsp_zap1.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} sp_zap1 ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} sp_zap1 ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void sp_zap1UserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridsp_zap1.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridsp_zap1.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridsp_zap1.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridsp_zap1.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridsp_zap1.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridsp_zap1.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridsp_zap1.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridsp_zap1.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridsp_zap1.DataGrid.FillByPage = true;
                this.FillData();
            }
        }

        [CreateNew]
        public sp_zap1Controller Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridsp_zap1.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridsp_zap1.DataView[this.userControlDataGridsp_zap1.DataGrid.CurrentRowIndex].Row;
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

        protected virtual sp_zap1UserDataGrid userControlDataGridsp_zap1
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridsp_zap1;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridsp_zap1 = value;
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

