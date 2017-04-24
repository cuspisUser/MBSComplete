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
    using NetAdvantage.Controls;
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
    public class S_FIN_IZVRSENJE_PLANAUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("comboIDORGJED")]
        private ORGJEDComboBox _comboIDORGJED;
        [AccessedThroughProperty("label1godina")]
        private UltraLabel _label1godina;
        [AccessedThroughProperty("label1IDORGJED")]
        private UltraLabel _label1IDORGJED;
        [AccessedThroughProperty("textgodina")]
        private UltraTextEditor _textgodina;
        [AccessedThroughProperty("userControlDataGridS_FIN_IZVRSENJE_PLANA")]
        private S_FIN_IZVRSENJE_PLANAUserDataGrid _userControlDataGridS_FIN_IZVRSENJE_PLANA;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_FIN_IZVRSENJE_PLANA;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_FIN_IZVRSENJE_PLANAUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_FIN_IZVRSENJE_PLANADescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_FIN_IZVRSENJE_PLANADescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_FIN_IZVRSENJE_PLANADataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_FIN_IZVRSENJE_PLANADataSet>(this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid);
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
            if ((this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.FillByPage;
                this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_FIN_IZVRSENJE_PLANA.ParameterIDORGJED = int.Parse(this.comboIDORGJED.Value.ToString());
                this.userControlDataGridS_FIN_IZVRSENJE_PLANA.Parametergodina = this.textgodina.Text;
                this.userControlDataGridS_FIN_IZVRSENJE_PLANA.Fill();
                ((S_FIN_IZVRSENJE_PLANAWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("IDORGJED", typeof(int));
            table2.Columns.Add(column);
            column = new DataColumn("godina", typeof(string));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["IDORGJED"] = int.Parse(this.comboIDORGJED.Value.ToString());
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
            ResourceManager manager = new ResourceManager(typeof(S_FIN_IZVRSENJE_PLANAUserControl));
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA = new TableLayoutPanel();
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.SuspendLayout();
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.AutoSize = true;
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.Dock = DockStyle.Fill;
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.Size = size;
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.ColumnCount = 2;
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.RowCount = 3;
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.RowStyles.Add(new RowStyle());
            this.label1IDORGJED = new UltraLabel();
            this.comboIDORGJED = new ORGJEDComboBox();
            this.label1godina = new UltraLabel();
            this.textgodina = new UltraTextEditor();
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA = new S_FIN_IZVRSENJE_PLANAUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textgodina).BeginInit();
            this.SuspendLayout();
            this.label1IDORGJED.Name = "label1IDORGJED";
            this.label1IDORGJED.TabIndex = 1;
            this.label1IDORGJED.Tag = "labelIDORGJED";
            this.label1IDORGJED.AutoSize = true;
            this.label1IDORGJED.StyleSetName = "FieldUltraLabel";
            this.label1IDORGJED.Text = "IDORGJED   :";
            this.label1IDORGJED.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDORGJED.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1IDORGJED.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.Controls.Add(this.label1IDORGJED, 0, 0);
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.SetColumnSpan(this.label1IDORGJED, 1);
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.SetRowSpan(this.label1IDORGJED, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1IDORGJED.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDORGJED.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDORGJED.Location = point;
            this.comboIDORGJED.Name = "comboIDORGJED";
            this.comboIDORGJED.Tag = "IDORGJED";
            this.comboIDORGJED.TabIndex = 0;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDORGJED.Size = size;
            this.comboIDORGJED.DropDownStyle = DropDownStyle.DropDownList;
            this.comboIDORGJED.AddEmptyValue = true;
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.Controls.Add(this.comboIDORGJED, 1, 0);
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.SetColumnSpan(this.comboIDORGJED, 1);
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.SetRowSpan(this.comboIDORGJED, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDORGJED.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDORGJED.MinimumSize = size;
            this.label1godina.Name = "label1godina";
            this.label1godina.TabIndex = 1;
            this.label1godina.Tag = "labelgodina";
            this.label1godina.AutoSize = true;
            this.label1godina.StyleSetName = "FieldUltraLabel";
            this.label1godina.Text = "godina :";
            this.label1godina.Appearance.TextVAlign = VAlign.Middle;
            this.label1godina.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1godina.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.Controls.Add(this.label1godina, 0, 1);
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.SetColumnSpan(this.label1godina, 1);
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.SetRowSpan(this.label1godina, 1);
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
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.Controls.Add(this.textgodina, 1, 1);
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.SetColumnSpan(this.textgodina, 1);
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.SetRowSpan(this.textgodina, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textgodina.Margin = padding;
            size = new System.Drawing.Size(0x2c, 0x16);
            this.textgodina.MinimumSize = size;
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.Controls.Add(this.userControlDataGridS_FIN_IZVRSENJE_PLANA, 0, 2);
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.SetColumnSpan(this.userControlDataGridS_FIN_IZVRSENJE_PLANA, 2);
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.SetRowSpan(this.userControlDataGridS_FIN_IZVRSENJE_PLANA, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.MinimumSize = size;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_FIN_IZVRSENJE_PLANA);
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.Name = "userControlDataGridS_FIN_IZVRSENJE_PLANA";
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DockPadding.All = 5;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.FillAtStartup = false;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_FIN_IZVRSENJE_PLANAWorkWith";
            this.Text = "Work With S_FIN_IZVRSENJE_PLANA";
            this.Load += new EventHandler(this.S_FIN_IZVRSENJE_PLANAUserControl_Load);
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.ResumeLayout(false);
            this.layoutManagerformS_FIN_IZVRSENJE_PLANA.PerformLayout();
            ((ISupportInitialize) this.textgodina).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.comboIDORGJED.SelectedIndex = 0;
            this.textgodina.Text = "";
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("IDORGJED") && (this.m_FillByRow["IDORGJED"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.comboIDORGJED, this.m_FillByRow["IDORGJED"].ToString(), this.m_FillByRow.Table.Columns["IDORGJED"].DataType);
                    this.parameterSeted = true;
                    this.comboIDORGJED.Visible = false;
                    this.label1IDORGJED.Visible = false;
                    str = str + "," + this.m_FillByRow["IDORGJED"].ToString() + " ";
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
                        this.Text = Deklarit.Resources.Resources.Select + "S_FIN_IZVRSENJE_PLANA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_FIN_IZVRSENJE_PLANA " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_FIN_IZVRSENJE_PLANADataAdapter().Update(this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.DataSet);
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
            this.label1IDORGJED.Text = StringResources.S_FIN_IZVRSENJE_PLANAIDORGJEDParameter;
            this.label1godina.Text = StringResources.S_FIN_IZVRSENJE_PLANAgodinaParameter;
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

        private void S_FIN_IZVRSENJE_PLANAUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_IZVRSENJE_PLANA ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_FIN_IZVRSENJE_PLANA ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        protected virtual ORGJEDComboBox comboIDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDORGJED = value;
            }
        }

        [CreateNew]
        public S_FIN_IZVRSENJE_PLANAController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataView[this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1IDORGJED
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDORGJED;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDORGJED = value;
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

        protected virtual S_FIN_IZVRSENJE_PLANAUserDataGrid userControlDataGridS_FIN_IZVRSENJE_PLANA
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_FIN_IZVRSENJE_PLANA;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_FIN_IZVRSENJE_PLANA = value;
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

