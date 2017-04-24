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
    public class S_OD_IPPUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1godina")]
        private UltraLabel _label1godina;
        [AccessedThroughProperty("label1mjesec")]
        private UltraLabel _label1mjesec;
        [AccessedThroughProperty("textgodina")]
        private UltraTextEditor _textgodina;
        [AccessedThroughProperty("textmjesec")]
        private UltraTextEditor _textmjesec;
        [AccessedThroughProperty("userControlDataGridS_OD_IPP")]
        private S_OD_IPPUserDataGrid _userControlDataGridS_OD_IPP;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_OD_IPP;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_OD_IPPUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_OD_IPPDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_OD_IPPDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_OD_IPP.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_OD_IPPDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_OD_IPPDataSet>(this.userControlDataGridS_OD_IPP.DataGrid);
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
            if ((this.userControlDataGridS_OD_IPP.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_OD_IPP.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_OD_IPP.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_OD_IPP.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_OD_IPP.DataGrid.FillByPage;
                this.userControlDataGridS_OD_IPP.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_OD_IPP.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_OD_IPP.Parametermjesec = this.textmjesec.Text;
                this.userControlDataGridS_OD_IPP.Parametergodina = this.textgodina.Text;
                this.userControlDataGridS_OD_IPP.Fill();
                ((S_OD_IPPWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_OD_IPP.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("mjesec", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("godina", typeof(string));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["mjesec"] = this.textmjesec.Text;
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
            ResourceManager manager = new ResourceManager(typeof(S_OD_IPPUserControl));
            this.layoutManagerformS_OD_IPP = new TableLayoutPanel();
            this.layoutManagerformS_OD_IPP.SuspendLayout();
            this.layoutManagerformS_OD_IPP.AutoSize = true;
            this.layoutManagerformS_OD_IPP.Dock = DockStyle.Fill;
            this.layoutManagerformS_OD_IPP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_OD_IPP.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_OD_IPP.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_OD_IPP.Size = size;
            this.layoutManagerformS_OD_IPP.ColumnCount = 2;
            this.layoutManagerformS_OD_IPP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OD_IPP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OD_IPP.RowCount = 3;
            this.layoutManagerformS_OD_IPP.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OD_IPP.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OD_IPP.RowStyles.Add(new RowStyle());
            this.label1mjesec = new UltraLabel();
            this.textmjesec = new UltraTextEditor();
            this.label1godina = new UltraLabel();
            this.textgodina = new UltraTextEditor();
            this.userControlDataGridS_OD_IPP = new S_OD_IPPUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textmjesec).BeginInit();
            ((ISupportInitialize) this.textgodina).BeginInit();
            this.SuspendLayout();
            this.label1mjesec.Name = "label1mjesec";
            this.label1mjesec.TabIndex = 1;
            this.label1mjesec.Tag = "labelmjesec";
            this.label1mjesec.AutoSize = true;
            this.label1mjesec.StyleSetName = "FieldUltraLabel";
            this.label1mjesec.Text = "mjesec   :";
            this.label1mjesec.Appearance.TextVAlign = VAlign.Middle;
            this.label1mjesec.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1mjesec.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OD_IPP.Controls.Add(this.label1mjesec, 0, 0);
            this.layoutManagerformS_OD_IPP.SetColumnSpan(this.label1mjesec, 1);
            this.layoutManagerformS_OD_IPP.SetRowSpan(this.label1mjesec, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1mjesec.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1mjesec.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textmjesec.Location = point;
            this.textmjesec.Name = "textmjesec";
            this.textmjesec.Tag = "mjesec";
            this.textmjesec.TabIndex = 0;
            size = new System.Drawing.Size(30, 0x16);
            this.textmjesec.Size = size;
            this.textmjesec.MaxLength = 2;
            this.layoutManagerformS_OD_IPP.Controls.Add(this.textmjesec, 1, 0);
            this.layoutManagerformS_OD_IPP.SetColumnSpan(this.textmjesec, 1);
            this.layoutManagerformS_OD_IPP.SetRowSpan(this.textmjesec, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textmjesec.Margin = padding;
            size = new System.Drawing.Size(30, 0x16);
            this.textmjesec.MinimumSize = size;
            this.label1godina.Name = "label1godina";
            this.label1godina.TabIndex = 1;
            this.label1godina.Tag = "labelgodina";
            this.label1godina.AutoSize = true;
            this.label1godina.StyleSetName = "FieldUltraLabel";
            this.label1godina.Text = "godina   :";
            this.label1godina.Appearance.TextVAlign = VAlign.Middle;
            this.label1godina.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1godina.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OD_IPP.Controls.Add(this.label1godina, 0, 1);
            this.layoutManagerformS_OD_IPP.SetColumnSpan(this.label1godina, 1);
            this.layoutManagerformS_OD_IPP.SetRowSpan(this.label1godina, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1godina.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1godina.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textgodina.Location = point;
            this.textgodina.Name = "textgodina";
            this.textgodina.Tag = "godina";
            this.textgodina.TabIndex = 1;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textgodina.Size = size;
            this.textgodina.MaxLength = 4;
            this.layoutManagerformS_OD_IPP.Controls.Add(this.textgodina, 1, 1);
            this.layoutManagerformS_OD_IPP.SetColumnSpan(this.textgodina, 1);
            this.layoutManagerformS_OD_IPP.SetRowSpan(this.textgodina, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textgodina.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textgodina.MinimumSize = size;
            this.layoutManagerformS_OD_IPP.Controls.Add(this.userControlDataGridS_OD_IPP, 0, 2);
            this.layoutManagerformS_OD_IPP.SetColumnSpan(this.userControlDataGridS_OD_IPP, 2);
            this.layoutManagerformS_OD_IPP.SetRowSpan(this.userControlDataGridS_OD_IPP, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_OD_IPP.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_OD_IPP.MinimumSize = size;
            this.userControlDataGridS_OD_IPP.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_OD_IPP);
            this.userControlDataGridS_OD_IPP.Name = "userControlDataGridS_OD_IPP";
            this.userControlDataGridS_OD_IPP.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_IPP.DockPadding.All = 5;
            this.userControlDataGridS_OD_IPP.FillAtStartup = false;
            this.userControlDataGridS_OD_IPP.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_IPP.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_OD_IPP.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_OD_IPP.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_OD_IPPWorkWith";
            this.Text = "Work With S_OD_IPP";
            this.Load += new EventHandler(this.S_OD_IPPUserControl_Load);
            this.layoutManagerformS_OD_IPP.ResumeLayout(false);
            this.layoutManagerformS_OD_IPP.PerformLayout();
            ((ISupportInitialize) this.textmjesec).EndInit();
            ((ISupportInitialize) this.textgodina).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textmjesec.Text = "";
            this.textgodina.Text = "";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("mjesec") && (this.m_FillByRow["mjesec"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textmjesec, this.m_FillByRow["mjesec"].ToString(), this.m_FillByRow.Table.Columns["mjesec"].DataType);
                    this.parameterSeted = true;
                    this.textmjesec.Visible = false;
                    this.label1mjesec.Visible = false;
                    str = str + "," + this.m_FillByRow["mjesec"].ToString() + " ";
                }
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
                        this.Text = Deklarit.Resources.Resources.Select + "S_OD_IPP " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_OD_IPP " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_OD_IPP.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_OD_IPP.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_OD_IPPDataAdapter().Update(this.userControlDataGridS_OD_IPP.DataGrid.DataSet);
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
            this.label1mjesec.Text = StringResources.S_OD_IPPmjesecParameter;
            this.label1godina.Text = StringResources.S_OD_IPPgodinaParameter;
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

        private void S_OD_IPPUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_OD_IPP.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_OD_IPP.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_OD_IPP.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_OD_IPP.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_OD_IPP.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_OD_IPP.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_OD_IPP.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_OD_IPP.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_OD_IPP.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_OD_IPP.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_OD_IPP.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_OD_IPP ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_OD_IPP ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [CreateNew]
        public S_OD_IPPController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_OD_IPP.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_OD_IPP.DataView[this.userControlDataGridS_OD_IPP.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1mjesec
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1mjesec;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1mjesec = value;
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

        protected virtual UltraTextEditor textmjesec
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textmjesec;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textmjesec = value;
            }
        }

        protected virtual S_OD_IPPUserDataGrid userControlDataGridS_OD_IPP
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_OD_IPP;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_OD_IPP = value;
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

