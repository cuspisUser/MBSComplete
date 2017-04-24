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
    using Microsoft.Practices.CompositeUI.EventBroker;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using Microsoft.Practices.ObjectBuilder;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using NetAdvantage;
    using NetAdvantage.Controllers;
    using NetAdvantage.WorkItems;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using Placa;

    [SmartPart]
    public class trazi_proizvodUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1nazivproizvod")]
        private UltraLabel _label1nazivproizvod;
        [AccessedThroughProperty("textnazivproizvod")]
        private UltraTextEditor _textnazivproizvod;
        [AccessedThroughProperty("userControlDataGridtrazi_proizvod")]
        private trazi_proizvodUserDataGrid _userControlDataGridtrazi_proizvod;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformPROIZVOD;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public trazi_proizvodUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.trazi_proizvodDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.trazi_proizvodDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridtrazi_proizvod.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<trazi_proizvodDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<trazi_proizvodDataSet>(this.userControlDataGridtrazi_proizvod.DataGrid);
            this.Controller.WorkItem.Services.Add(typeof(ISelectedRowsProviderService), serviceInstance);
        }

        [LocalCommandHandler("Copy")]
        public void CopyHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.Copy(this.CurrentDataRow);
            }
        }

        private void DataGrid_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.CurrentDataRow != null)
            {
                this.Controller.CurrentRow = this.CurrentDataRow;
            }
        }

        private void DataGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (!this.userControlDataGridtrazi_proizvod.DataGrid.GridLoading && ((this.userControlDataGridtrazi_proizvod.DataGrid.ActiveRow != null) && (this.userControlDataGridtrazi_proizvod.DataGrid.ActiveCell != null)))
            {
                this.DefaultAction();
            }
        }

        private void DataGrid_SetFocus()
        {
            if ((this.userControlDataGridtrazi_proizvod.DataGrid.Rows.Count > 0) && (this.userControlDataGridtrazi_proizvod.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridtrazi_proizvod.DataGrid.Rows[0].Activate();
            }
        }

        private void DefaultAction()
        {
            if (this.InValidState())
            {
                this.Controller.Update(this.CurrentDataRow);
            }
        }

        [LocalCommandHandler("Delete")]
        public void DeleteHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.Delete(this.CurrentDataRow);
            }
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridtrazi_proizvod.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridtrazi_proizvod.DataGrid.FillByPage;
                this.userControlDataGridtrazi_proizvod.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridtrazi_proizvod.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridtrazi_proizvod.Parameternazivproizvod = this.textnazivproizvod.Text;
                this.userControlDataGridtrazi_proizvod.Fill();
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    ((PROIZVODSelectionListWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridtrazi_proizvod.DataView.Table.DataSet;
                }
                else
                {
                    ((trazi_proizvodWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridtrazi_proizvod.DataView.Table.DataSet;
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("nazivproizvod", typeof(string));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["nazivproizvod"] = this.textnazivproizvod.Text;
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
            ResourceManager manager = new ResourceManager(typeof(trazi_proizvodUserControl));
            this.layoutManagerformPROIZVOD = new TableLayoutPanel();
            this.layoutManagerformPROIZVOD.SuspendLayout();
            this.layoutManagerformPROIZVOD.AutoSize = true;
            this.layoutManagerformPROIZVOD.Dock = DockStyle.Fill;
            this.layoutManagerformPROIZVOD.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPROIZVOD.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPROIZVOD.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPROIZVOD.Size = size;
            this.layoutManagerformPROIZVOD.ColumnCount = 2;
            this.layoutManagerformPROIZVOD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPROIZVOD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPROIZVOD.RowCount = 2;
            this.layoutManagerformPROIZVOD.RowStyles.Add(new RowStyle());
            this.layoutManagerformPROIZVOD.RowStyles.Add(new RowStyle());
            this.label1nazivproizvod = new UltraLabel();
            this.textnazivproizvod = new UltraTextEditor();
            this.userControlDataGridtrazi_proizvod = new trazi_proizvodUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textnazivproizvod).BeginInit();
            this.SuspendLayout();
            this.label1nazivproizvod.Name = "label1nazivproizvod";
            this.label1nazivproizvod.TabIndex = 1;
            this.label1nazivproizvod.Tag = "labelnazivproizvod";
            this.label1nazivproizvod.AutoSize = true;
            this.label1nazivproizvod.StyleSetName = "FieldUltraLabel";
            this.label1nazivproizvod.Text = "nazivproizvod  :";
            this.label1nazivproizvod.Appearance.TextVAlign = VAlign.Middle;
            this.label1nazivproizvod.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1nazivproizvod.Appearance.ForeColor = Color.Black;
            this.layoutManagerformPROIZVOD.Controls.Add(this.label1nazivproizvod, 0, 0);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.label1nazivproizvod, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.label1nazivproizvod, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1nazivproizvod.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1nazivproizvod.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textnazivproizvod.Location = point;
            this.textnazivproizvod.Name = "textnazivproizvod";
            this.textnazivproizvod.Tag = "nazivproizvod";
            this.textnazivproizvod.TabIndex = 0;
            size = new System.Drawing.Size(0x240, 110);
            this.textnazivproizvod.Size = size;
            this.textnazivproizvod.MaxLength = 500;
            this.textnazivproizvod.Multiline = true;
            this.layoutManagerformPROIZVOD.Controls.Add(this.textnazivproizvod, 1, 0);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.textnazivproizvod, 1);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.textnazivproizvod, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textnazivproizvod.Margin = padding;
            size = new System.Drawing.Size(0x240, 110);
            this.textnazivproizvod.MinimumSize = size;
            this.textnazivproizvod.Dock = DockStyle.Fill;
            this.layoutManagerformPROIZVOD.Controls.Add(this.userControlDataGridtrazi_proizvod, 0, 1);
            this.layoutManagerformPROIZVOD.SetColumnSpan(this.userControlDataGridtrazi_proizvod, 2);
            this.layoutManagerformPROIZVOD.SetRowSpan(this.userControlDataGridtrazi_proizvod, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridtrazi_proizvod.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridtrazi_proizvod.MinimumSize = size;
            this.userControlDataGridtrazi_proizvod.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformPROIZVOD);
            this.userControlDataGridtrazi_proizvod.Name = "userControlDataGridtrazi_proizvod";
            this.userControlDataGridtrazi_proizvod.Dock = DockStyle.Fill;
            this.userControlDataGridtrazi_proizvod.DockPadding.All = 5;
            this.userControlDataGridtrazi_proizvod.FillAtStartup = false;
            this.userControlDataGridtrazi_proizvod.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridtrazi_proizvod.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridtrazi_proizvod.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridtrazi_proizvod.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "PROIZVODWorkWith";
            this.Text = "Work With PROIZVOD";
            this.Load += new EventHandler(this.trazi_proizvodUserControl_Load);
            this.layoutManagerformPROIZVOD.ResumeLayout(false);
            this.layoutManagerformPROIZVOD.PerformLayout();
            ((ISupportInitialize) this.textnazivproizvod).EndInit();
            this.ResumeLayout(false);
        }

        [LocalCommandHandler("Insert")]
        public void InsertHandler(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                this.Controller.Insert(this.m_FillByRow);
            }
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textnazivproizvod.Text = "";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("nazivproizvod") && (this.m_FillByRow["nazivproizvod"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textnazivproizvod, this.m_FillByRow["nazivproizvod"].ToString(), this.m_FillByRow.Table.Columns["nazivproizvod"].DataType);
                    this.parameterSeted = true;
                    this.textnazivproizvod.Visible = false;
                    this.label1nazivproizvod.Visible = false;
                    str = str + "," + this.m_FillByRow["nazivproizvod"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "trazi_proizvod " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "trazi_proizvod " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                }
            }
        }

        private void Localize()
        {
            this.label1nazivproizvod.Text = StringResources.trazi_proizvodnazivproizvodParameter;
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

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/PROIZVOD", Thread=ThreadOption.UserInterface)]
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
                this.userControlDataGridtrazi_proizvod.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridtrazi_proizvod.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} PROIZVOD ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} PROIZVOD ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void trazi_proizvodUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridtrazi_proizvod.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridtrazi_proizvod.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridtrazi_proizvod.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridtrazi_proizvod.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridtrazi_proizvod.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridtrazi_proizvod.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridtrazi_proizvod.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridtrazi_proizvod.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridtrazi_proizvod.DataGrid.FillByPage = true;
                this.FillData();
            }
        }

        [LocalCommandHandler("Update")]
        public void UpdateHandler(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.Update(this.CurrentDataRow);
            }
        }

        [LocalCommandHandler("View")]
        public void View(object sender, EventArgs e)
        {
            if (this.InValidState())
            {
                this.Controller.View(this.CurrentDataRow);
            }
        }

        [CreateNew]
        public PROIZVODWorkWithController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridtrazi_proizvod.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridtrazi_proizvod.DataView[this.userControlDataGridtrazi_proizvod.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1nazivproizvod
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1nazivproizvod;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1nazivproizvod = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraTextEditor textnazivproizvod
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textnazivproizvod;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textnazivproizvod = value;
            }
        }

        protected virtual trazi_proizvodUserDataGrid userControlDataGridtrazi_proizvod
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridtrazi_proizvod;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridtrazi_proizvod = value;
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

