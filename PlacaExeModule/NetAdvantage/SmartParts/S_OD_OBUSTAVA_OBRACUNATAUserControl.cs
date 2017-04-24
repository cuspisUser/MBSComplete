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
    public class S_OD_OBUSTAVA_OBRACUNATAUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1IDOBRACUN")]
        private UltraLabel _label1IDOBRACUN;
        [AccessedThroughProperty("textIDOBRACUN")]
        private UltraTextEditor _textIDOBRACUN;
        [AccessedThroughProperty("userControlDataGridS_OD_OBUSTAVA_OBRACUNATA")]
        private S_OD_OBUSTAVA_OBRACUNATAUserDataGrid _userControlDataGridS_OD_OBUSTAVA_OBRACUNATA;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_OD_OBUSTAVA_OBRACUNATA;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_OD_OBUSTAVA_OBRACUNATAUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_OD_OBUSTAVA_OBRACUNATADescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_OD_OBUSTAVA_OBRACUNATADescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_OD_OBUSTAVA_OBRACUNATADataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_OD_OBUSTAVA_OBRACUNATADataSet>(this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        private void CallPromptOBRACUNIDOBRACUN(object sender, EditorButtonEventArgs e)
        {
            S_OD_OBUSTAVA_OBRACUNATAController controller = this.Controller.WorkItem.Items.AddNew<S_OD_OBUSTAVA_OBRACUNATAController>();
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
            if ((this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.FillByPage;
                this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.ParameterIDOBRACUN = this.textIDOBRACUN.Text;
                this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.Fill();
                ((S_OD_OBUSTAVA_OBRACUNATAWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataView.Table.DataSet;
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
            ResourceManager manager = new ResourceManager(typeof(S_OD_OBUSTAVA_OBRACUNATAUserControl));
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA = new TableLayoutPanel();
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.SuspendLayout();
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.AutoSize = true;
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.Dock = DockStyle.Fill;
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.Size = size;
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.ColumnCount = 2;
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.RowCount = 2;
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.RowStyles.Add(new RowStyle());
            this.label1IDOBRACUN = new UltraLabel();
            this.textIDOBRACUN = new UltraTextEditor();
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA = new S_OD_OBUSTAVA_OBRACUNATAUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textIDOBRACUN).BeginInit();
            this.SuspendLayout();
            this.label1IDOBRACUN.Name = "label1IDOBRACUN";
            this.label1IDOBRACUN.TabIndex = 1;
            this.label1IDOBRACUN.Tag = "labelIDOBRACUN";
            this.label1IDOBRACUN.AutoSize = true;
            this.label1IDOBRACUN.StyleSetName = "FieldUltraLabel";
            this.label1IDOBRACUN.Text = "IDOBRACUN   :";
            this.label1IDOBRACUN.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDOBRACUN.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1IDOBRACUN.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.Controls.Add(this.label1IDOBRACUN, 0, 0);
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.SetColumnSpan(this.label1IDOBRACUN, 1);
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.SetRowSpan(this.label1IDOBRACUN, 1);
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
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.Controls.Add(this.textIDOBRACUN, 1, 0);
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.SetColumnSpan(this.textIDOBRACUN, 1);
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.SetRowSpan(this.textIDOBRACUN, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textIDOBRACUN.Margin = padding;
            size = new System.Drawing.Size(0x71, 0x16);
            this.textIDOBRACUN.MinimumSize = size;
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.Controls.Add(this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA, 0, 1);
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.SetColumnSpan(this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA, 2);
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.SetRowSpan(this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.MinimumSize = size;
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA);
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.Name = "userControlDataGridS_OD_OBUSTAVA_OBRACUNATA";
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DockPadding.All = 5;
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.FillAtStartup = false;
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_OD_OBUSTAVA_OBRACUNATAWorkWith";
            this.Text = "Work With S_OD_OBUSTAVA_OBRACUNATA";
            this.Load += new EventHandler(this.S_OD_OBUSTAVA_OBRACUNATAUserControl_Load);
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.ResumeLayout(false);
            this.layoutManagerformS_OD_OBUSTAVA_OBRACUNATA.PerformLayout();
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
                        this.Text = Deklarit.Resources.Resources.Select + "S_OD_OBUSTAVA_OBRACUNATA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_OD_OBUSTAVA_OBRACUNATA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_OD_OBUSTAVA_OBRACUNATADataAdapter().Update(this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.DataSet);
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
            this.label1IDOBRACUN.Text = StringResources.S_OD_OBUSTAVA_OBRACUNATAIDOBRACUNParameter;
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

        private void S_OD_OBUSTAVA_OBRACUNATAUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_OD_OBUSTAVA_OBRACUNATA ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_OD_OBUSTAVA_OBRACUNATA ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_OD_OBUSTAVA_OBRACUNATAController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataView[this.userControlDataGridS_OD_OBUSTAVA_OBRACUNATA.DataGrid.CurrentRowIndex].Row;
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

        protected virtual S_OD_OBUSTAVA_OBRACUNATAUserDataGrid userControlDataGridS_OD_OBUSTAVA_OBRACUNATA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_OD_OBUSTAVA_OBRACUNATA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_OD_OBUSTAVA_OBRACUNATA = value;
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

