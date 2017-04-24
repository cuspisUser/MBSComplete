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
    public class trazi_partneraUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("label1NAZIVPARTNER")]
        private UltraLabel _label1NAZIVPARTNER;
        [AccessedThroughProperty("textNAZIVPARTNER")]
        private UltraTextEditor _textNAZIVPARTNER;
        [AccessedThroughProperty("userControlDataGridtrazi_partnera")]
        private trazi_partneraUserDataGrid _userControlDataGridtrazi_partnera;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformPARTNER;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public trazi_partneraUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.trazi_partneraDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.trazi_partneraDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridtrazi_partnera.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<trazi_partneraDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<trazi_partneraDataSet>(this.userControlDataGridtrazi_partnera.DataGrid);
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
            if (!this.userControlDataGridtrazi_partnera.DataGrid.GridLoading && ((this.userControlDataGridtrazi_partnera.DataGrid.ActiveRow != null) && (this.userControlDataGridtrazi_partnera.DataGrid.ActiveCell != null)))
            {
                this.DefaultAction();
            }
        }

        private void DataGrid_SetFocus()
        {
            if ((this.userControlDataGridtrazi_partnera.DataGrid.Rows.Count > 0) && (this.userControlDataGridtrazi_partnera.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridtrazi_partnera.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridtrazi_partnera.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridtrazi_partnera.DataGrid.FillByPage;
                this.userControlDataGridtrazi_partnera.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridtrazi_partnera.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridtrazi_partnera.ParameterNAZIVPARTNER = this.textNAZIVPARTNER.Text;
                this.userControlDataGridtrazi_partnera.Fill();
                if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                {
                    ((PARTNERSelectionListWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridtrazi_partnera.DataView.Table.DataSet;
                }
                else
                {
                    ((trazi_partneraWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridtrazi_partnera.DataView.Table.DataSet;
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
            DataColumn column = new DataColumn("NAZIVPARTNER", typeof(string));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["NAZIVPARTNER"] = this.textNAZIVPARTNER.Text;
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
            ResourceManager manager = new ResourceManager(typeof(trazi_partneraUserControl));
            this.layoutManagerformPARTNER = new TableLayoutPanel();
            this.layoutManagerformPARTNER.SuspendLayout();
            this.layoutManagerformPARTNER.AutoSize = true;
            this.layoutManagerformPARTNER.Dock = DockStyle.Fill;
            this.layoutManagerformPARTNER.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformPARTNER.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformPARTNER.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformPARTNER.Size = size;
            this.layoutManagerformPARTNER.ColumnCount = 2;
            this.layoutManagerformPARTNER.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPARTNER.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformPARTNER.RowCount = 2;
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.layoutManagerformPARTNER.RowStyles.Add(new RowStyle());
            this.label1NAZIVPARTNER = new UltraLabel();
            this.textNAZIVPARTNER = new UltraTextEditor();
            this.userControlDataGridtrazi_partnera = new trazi_partneraUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textNAZIVPARTNER).BeginInit();
            this.SuspendLayout();
            this.label1NAZIVPARTNER.Name = "label1NAZIVPARTNER";
            this.label1NAZIVPARTNER.TabIndex = 1;
            this.label1NAZIVPARTNER.Tag = "labelNAZIVPARTNER";
            this.label1NAZIVPARTNER.AutoSize = true;
            this.label1NAZIVPARTNER.StyleSetName = "FieldUltraLabel";
            this.label1NAZIVPARTNER.Text = "Unesite naziv partnera  :";
            this.label1NAZIVPARTNER.Appearance.TextVAlign = VAlign.Middle;
            this.label1NAZIVPARTNER.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1NAZIVPARTNER.Appearance.ForeColor = Color.Black;
            this.layoutManagerformPARTNER.Controls.Add(this.label1NAZIVPARTNER, 0, 0);
            this.layoutManagerformPARTNER.SetColumnSpan(this.label1NAZIVPARTNER, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.label1NAZIVPARTNER, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1NAZIVPARTNER.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1NAZIVPARTNER.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textNAZIVPARTNER.Location = point;
            this.textNAZIVPARTNER.Name = "textNAZIVPARTNER";
            this.textNAZIVPARTNER.Tag = "NAZIVPARTNER";
            this.textNAZIVPARTNER.TabIndex = 0;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVPARTNER.Size = size;
            this.textNAZIVPARTNER.MaxLength = 100;
            this.layoutManagerformPARTNER.Controls.Add(this.textNAZIVPARTNER, 1, 0);
            this.layoutManagerformPARTNER.SetColumnSpan(this.textNAZIVPARTNER, 1);
            this.layoutManagerformPARTNER.SetRowSpan(this.textNAZIVPARTNER, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textNAZIVPARTNER.Margin = padding;
            size = new System.Drawing.Size(0x240, 0x16);
            this.textNAZIVPARTNER.MinimumSize = size;
            this.layoutManagerformPARTNER.Controls.Add(this.userControlDataGridtrazi_partnera, 0, 1);
            this.layoutManagerformPARTNER.SetColumnSpan(this.userControlDataGridtrazi_partnera, 2);
            this.layoutManagerformPARTNER.SetRowSpan(this.userControlDataGridtrazi_partnera, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridtrazi_partnera.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridtrazi_partnera.MinimumSize = size;
            this.userControlDataGridtrazi_partnera.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformPARTNER);
            this.userControlDataGridtrazi_partnera.Name = "userControlDataGridtrazi_partnera";
            this.userControlDataGridtrazi_partnera.Dock = DockStyle.Fill;
            this.userControlDataGridtrazi_partnera.DockPadding.All = 5;
            this.userControlDataGridtrazi_partnera.FillAtStartup = false;
            this.userControlDataGridtrazi_partnera.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridtrazi_partnera.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridtrazi_partnera.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridtrazi_partnera.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "PARTNERWorkWith";
            this.Text = "Work With PARTNER";
            this.Load += new EventHandler(this.trazi_partneraUserControl_Load);
            this.layoutManagerformPARTNER.ResumeLayout(false);
            this.layoutManagerformPARTNER.PerformLayout();
            ((ISupportInitialize) this.textNAZIVPARTNER).EndInit();
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
            this.textNAZIVPARTNER.Text = "";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("NAZIVPARTNER") && (this.m_FillByRow["NAZIVPARTNER"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textNAZIVPARTNER, this.m_FillByRow["NAZIVPARTNER"].ToString(), this.m_FillByRow.Table.Columns["NAZIVPARTNER"].DataType);
                    this.parameterSeted = true;
                    this.textNAZIVPARTNER.Visible = false;
                    this.label1NAZIVPARTNER.Visible = false;
                    str = str + "," + this.m_FillByRow["NAZIVPARTNER"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "trazi_partnera " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "trazi_partnera " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                }
            }
        }

        private void Localize()
        {
            this.label1NAZIVPARTNER.Text = StringResources.trazi_partneraNAZIVPARTNERParameter;
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

        [EventSubscription("topic://NetAdvantage/BusinessComponentUpdated/PARTNER", Thread=ThreadOption.UserInterface)]
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
                this.userControlDataGridtrazi_partnera.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridtrazi_partnera.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} PARTNER ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} PARTNER ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void trazi_partneraUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridtrazi_partnera.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridtrazi_partnera.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridtrazi_partnera.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridtrazi_partnera.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridtrazi_partnera.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridtrazi_partnera.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridtrazi_partnera.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridtrazi_partnera.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridtrazi_partnera.DataGrid.FillByPage = true;
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
        public PARTNERWorkWithController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridtrazi_partnera.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridtrazi_partnera.DataView[this.userControlDataGridtrazi_partnera.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1NAZIVPARTNER
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1NAZIVPARTNER;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1NAZIVPARTNER = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraTextEditor textNAZIVPARTNER
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textNAZIVPARTNER;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textNAZIVPARTNER = value;
            }
        }

        protected virtual trazi_partneraUserDataGrid userControlDataGridtrazi_partnera
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridtrazi_partnera;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridtrazi_partnera = value;
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

