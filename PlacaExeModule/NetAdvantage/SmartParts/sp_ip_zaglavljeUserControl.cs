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
    public class sp_ip_zaglavljeUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1godina")]
        private UltraLabel _label1godina;
        [AccessedThroughProperty("textgodina")]
        private UltraTextEditor _textgodina;
        [AccessedThroughProperty("userControlDataGridsp_ip_zaglavlje")]
        private sp_ip_zaglavljeUserDataGrid _userControlDataGridsp_ip_zaglavlje;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformsp_ip_zaglavlje;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public sp_ip_zaglavljeUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.sp_ip_zaglavljeDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.sp_ip_zaglavljeDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridsp_ip_zaglavlje.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<sp_ip_zaglavljeDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<sp_ip_zaglavljeDataSet>(this.userControlDataGridsp_ip_zaglavlje.DataGrid);
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
            if ((this.userControlDataGridsp_ip_zaglavlje.DataGrid.Rows.Count > 0) && (this.userControlDataGridsp_ip_zaglavlje.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridsp_ip_zaglavlje.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridsp_ip_zaglavlje.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridsp_ip_zaglavlje.DataGrid.FillByPage;
                this.userControlDataGridsp_ip_zaglavlje.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridsp_ip_zaglavlje.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridsp_ip_zaglavlje.Parametergodina = this.textgodina.Text;
                this.userControlDataGridsp_ip_zaglavlje.Fill();
                ((sp_ip_zaglavljeWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridsp_ip_zaglavlje.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("godina", typeof(string));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["godina"] = this.textgodina.Text;
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
            ResourceManager manager = new ResourceManager(typeof(sp_ip_zaglavljeUserControl));
            this.layoutManagerformsp_ip_zaglavlje = new TableLayoutPanel();
            this.layoutManagerformsp_ip_zaglavlje.SuspendLayout();
            this.layoutManagerformsp_ip_zaglavlje.AutoSize = true;
            this.layoutManagerformsp_ip_zaglavlje.Dock = DockStyle.Fill;
            this.layoutManagerformsp_ip_zaglavlje.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformsp_ip_zaglavlje.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformsp_ip_zaglavlje.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformsp_ip_zaglavlje.Size = size;
            this.layoutManagerformsp_ip_zaglavlje.ColumnCount = 2;
            this.layoutManagerformsp_ip_zaglavlje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformsp_ip_zaglavlje.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformsp_ip_zaglavlje.RowCount = 2;
            this.layoutManagerformsp_ip_zaglavlje.RowStyles.Add(new RowStyle());
            this.layoutManagerformsp_ip_zaglavlje.RowStyles.Add(new RowStyle());
            this.label1godina = new UltraLabel();
            this.textgodina = new UltraTextEditor();
            this.userControlDataGridsp_ip_zaglavlje = new sp_ip_zaglavljeUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textgodina).BeginInit();
            this.SuspendLayout();
            this.label1godina.Name = "label1godina";
            this.label1godina.TabIndex = 1;
            this.label1godina.Tag = "labelgodina";
            this.label1godina.AutoSize = true;
            this.label1godina.StyleSetName = "FieldUltraLabel";
            this.label1godina.Text = "godina        :";
            this.label1godina.Appearance.TextVAlign = VAlign.Middle;
            this.label1godina.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1godina.Appearance.ForeColor = Color.Black;
            this.layoutManagerformsp_ip_zaglavlje.Controls.Add(this.label1godina, 0, 0);
            this.layoutManagerformsp_ip_zaglavlje.SetColumnSpan(this.label1godina, 1);
            this.layoutManagerformsp_ip_zaglavlje.SetRowSpan(this.label1godina, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1godina.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1godina.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textgodina.Location = point;
            this.textgodina.Name = "textgodina";
            this.textgodina.Tag = "godina";
            this.textgodina.TabIndex = 0;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textgodina.Size = size;
            this.textgodina.MaxLength = 4;
            this.layoutManagerformsp_ip_zaglavlje.Controls.Add(this.textgodina, 1, 0);
            this.layoutManagerformsp_ip_zaglavlje.SetColumnSpan(this.textgodina, 1);
            this.layoutManagerformsp_ip_zaglavlje.SetRowSpan(this.textgodina, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textgodina.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textgodina.MinimumSize = size;
            this.layoutManagerformsp_ip_zaglavlje.Controls.Add(this.userControlDataGridsp_ip_zaglavlje, 0, 1);
            this.layoutManagerformsp_ip_zaglavlje.SetColumnSpan(this.userControlDataGridsp_ip_zaglavlje, 2);
            this.layoutManagerformsp_ip_zaglavlje.SetRowSpan(this.userControlDataGridsp_ip_zaglavlje, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridsp_ip_zaglavlje.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridsp_ip_zaglavlje.MinimumSize = size;
            this.userControlDataGridsp_ip_zaglavlje.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformsp_ip_zaglavlje);
            this.userControlDataGridsp_ip_zaglavlje.Name = "userControlDataGridsp_ip_zaglavlje";
            this.userControlDataGridsp_ip_zaglavlje.Dock = DockStyle.Fill;
            this.userControlDataGridsp_ip_zaglavlje.DockPadding.All = 5;
            this.userControlDataGridsp_ip_zaglavlje.FillAtStartup = false;
            this.userControlDataGridsp_ip_zaglavlje.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridsp_ip_zaglavlje.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridsp_ip_zaglavlje.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridsp_ip_zaglavlje.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "sp_ip_zaglavljeWorkWith";
            this.Text = "Work With sp_ip_zaglavlje";
            this.Load += new EventHandler(this.sp_ip_zaglavljeUserControl_Load);
            this.layoutManagerformsp_ip_zaglavlje.ResumeLayout(false);
            this.layoutManagerformsp_ip_zaglavlje.PerformLayout();
            ((ISupportInitialize) this.textgodina).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textgodina.Text = "";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("godina") && (this.m_FillByRow["godina"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textgodina, this.m_FillByRow["godina"].ToString(), this.m_FillByRow.Table.Columns["godina"].DataType);
                    this.parameterSeted = true;
                    this.textgodina.Visible = false;
                    this.label1godina.Visible = false;
                    str = str + "," + this.m_FillByRow["godina"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "sp_ip_zaglavlje " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "sp_ip_zaglavlje " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridsp_ip_zaglavlje.DataGrid.DataSet.Clear();
                    this.userControlDataGridsp_ip_zaglavlje.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new sp_ip_zaglavljeDataAdapter().Update(this.userControlDataGridsp_ip_zaglavlje.DataGrid.DataSet);
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
            this.label1godina.Text = StringResources.sp_ip_zaglavljegodinaParameter;
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
                this.userControlDataGridsp_ip_zaglavlje.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridsp_ip_zaglavlje.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} sp_ip_zaglavlje ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} sp_ip_zaglavlje ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void sp_ip_zaglavljeUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridsp_ip_zaglavlje.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridsp_ip_zaglavlje.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridsp_ip_zaglavlje.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridsp_ip_zaglavlje.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridsp_ip_zaglavlje.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridsp_ip_zaglavlje.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridsp_ip_zaglavlje.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridsp_ip_zaglavlje.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridsp_ip_zaglavlje.DataGrid.FillByPage = true;
                this.FillData();
            }
        }

        [CreateNew]
        public sp_ip_zaglavljeController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridsp_ip_zaglavlje.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridsp_ip_zaglavlje.DataView[this.userControlDataGridsp_ip_zaglavlje.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1godina
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1godina;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1godina = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraTextEditor textgodina
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textgodina;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textgodina = value;
            }
        }

        protected virtual sp_ip_zaglavljeUserDataGrid userControlDataGridsp_ip_zaglavlje
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridsp_ip_zaglavlje;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridsp_ip_zaglavlje = value;
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

