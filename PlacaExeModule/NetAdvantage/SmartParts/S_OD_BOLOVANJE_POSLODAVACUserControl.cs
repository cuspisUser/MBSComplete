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
    public class S_OD_BOLOVANJE_POSLODAVACUserControl : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        [AccessedThroughProperty("comboIDRADNIK")]
        private PregledRadnikaComboBox _comboIDRADNIK;
        [AccessedThroughProperty("label1dooo")]
        private UltraLabel _label1dooo;
        [AccessedThroughProperty("label1IDRADNIK")]
        private UltraLabel _label1IDRADNIK;
        [AccessedThroughProperty("label1odd")]
        private UltraLabel _label1odd;
        [AccessedThroughProperty("textdooo")]
        private UltraTextEditor _textdooo;
        [AccessedThroughProperty("textodd")]
        private UltraTextEditor _textodd;
        [AccessedThroughProperty("userControlDataGridS_OD_BOLOVANJE_POSLODAVAC")]
        private S_OD_BOLOVANJE_POSLODAVACUserDataGrid _userControlDataGridS_OD_BOLOVANJE_POSLODAVAC;
        private IContainer components = null;
        private SmartPartInfoProvider infoProvider;
        private TableLayoutPanel layoutManagerformS_OD_BOLOVANJE_POSLODAVAC;
        private string m_FillByMethod = "";
        private DataRow m_FillByRow;
        private DataRow m_RowSelected;
        private Deklarit.Practices.CompositeUI.WorkWithMode m_WorkWithMode;
        private bool parameterSeted;
        private SmartPartInfo smartPartInfo1;
        private UltraGridPrintDocument ultraGridPrintDocument1;
        private UltraPrintPreviewDialog ultraPrintPreviewDialog1;

        public S_OD_BOLOVANJE_POSLODAVACUserControl()
        {
            this.InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(Deklarit.Resources.Resources.Providerfor + " " + StringResources.S_OD_BOLOVANJE_POSLODAVACDescription, Deklarit.Resources.Resources.WorkWithTitle + " " + StringResources.S_OD_BOLOVANJE_POSLODAVACDescription);
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.AfterRowActivate += new EventHandler(this.DataGrid_AfterRowActivate);
            this.Localize();
        }

        [OnBuiltUp]
        public void AddSelectedRowProviderService()
        {
            UltraGridSelectedRowsProviderService<S_OD_BOLOVANJE_POSLODAVACDataSet> serviceInstance = new UltraGridSelectedRowsProviderService<S_OD_BOLOVANJE_POSLODAVACDataSet>(this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid);
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
            if ((this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.Rows.Count > 0) && (this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.Rows[0] != null))
            {
                this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.Rows[0].Activate();
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
                    new UltraGridExcelExporter().Export(this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid, dialog.FileName);
                    Process.Start(dialog.FileName);
                }
            }
        }

        [LocalCommandHandler("FillAll")]
        public void FillAll(object sender, EventArgs e)
        {
            if (this.Controller.WorkItem.Status == WorkItemStatus.Active)
            {
                bool fillByPage = this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.FillByPage;
                this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.FillByPage = false;
                this.FillData();
                this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.FillByPage = fillByPage;
            }
        }

        public virtual void FillData()
        {
            try
            {
                this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.Parameterodd = this.textodd.Text;
                this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.Parameterdooo = this.textdooo.Text;
                this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.ParameterIDRADNIK = int.Parse(this.comboIDRADNIK.Value.ToString());
                this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.Fill();
                ((S_OD_BOLOVANJE_POSLODAVACWorkWithWorkItem) this.Controller.WorkItem).DataSet = this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataView.Table.DataSet;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }

        public static DataTable GetParameterDataTable()
        {
            DataTable table2 = new DataTable("Parameters");
            DataColumn column = new DataColumn("odd", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("dooo", typeof(string));
            table2.Columns.Add(column);
            column = new DataColumn("IDRADNIK", typeof(int));
            table2.Columns.Add(column);
            return table2;
        }

        private DataRow GetParameterRow()
        {
            DataRow row2 = GetParameterDataTable().NewRow();
            row2["odd"] = this.textodd.Text;
            row2["dooo"] = this.textdooo.Text;
            row2["IDRADNIK"] = int.Parse(this.comboIDRADNIK.Value.ToString());
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
            ResourceManager manager = new ResourceManager(typeof(S_OD_BOLOVANJE_POSLODAVACUserControl));
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC = new TableLayoutPanel();
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.SuspendLayout();
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.AutoSize = true;
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.Dock = DockStyle.Fill;
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.AutoScroll = false;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.Location = point;
            Size size = new System.Drawing.Size(0, 0);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.Size = size;
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.ColumnCount = 2;
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.RowCount = 4;
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.RowStyles.Add(new RowStyle());
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.RowStyles.Add(new RowStyle());
            this.label1odd = new UltraLabel();
            this.textodd = new UltraTextEditor();
            this.label1dooo = new UltraLabel();
            this.textdooo = new UltraTextEditor();
            this.label1IDRADNIK = new UltraLabel();
            this.comboIDRADNIK = new PregledRadnikaComboBox();
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC = new S_OD_BOLOVANJE_POSLODAVACUserDataGrid();
            this.ultraGridPrintDocument1 = new UltraGridPrintDocument(this.components);
            this.ultraPrintPreviewDialog1 = new UltraPrintPreviewDialog(this.components);
            ((ISupportInitialize) this.textodd).BeginInit();
            ((ISupportInitialize) this.textdooo).BeginInit();
            this.SuspendLayout();
            this.label1odd.Name = "label1odd";
            this.label1odd.TabIndex = 1;
            this.label1odd.Tag = "labelodd";
            this.label1odd.AutoSize = true;
            this.label1odd.StyleSetName = "FieldUltraLabel";
            this.label1odd.Text = "odd      :";
            this.label1odd.Appearance.TextVAlign = VAlign.Middle;
            this.label1odd.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1odd.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.Controls.Add(this.label1odd, 0, 0);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.SetColumnSpan(this.label1odd, 1);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.SetRowSpan(this.label1odd, 1);
            Padding padding = new Padding(3, 1, 5, 2);
            this.label1odd.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1odd.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textodd.Location = point;
            this.textodd.Name = "textodd";
            this.textodd.Tag = "odd";
            this.textodd.TabIndex = 0;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textodd.Size = size;
            this.textodd.MaxLength = 7;
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.Controls.Add(this.textodd, 1, 0);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.SetColumnSpan(this.textodd, 1);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.SetRowSpan(this.textodd, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textodd.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textodd.MinimumSize = size;
            this.label1dooo.Name = "label1dooo";
            this.label1dooo.TabIndex = 1;
            this.label1dooo.Tag = "labeldooo";
            this.label1dooo.AutoSize = true;
            this.label1dooo.StyleSetName = "FieldUltraLabel";
            this.label1dooo.Text = "dooo     :";
            this.label1dooo.Appearance.TextVAlign = VAlign.Middle;
            this.label1dooo.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1dooo.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.Controls.Add(this.label1dooo, 0, 1);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.SetColumnSpan(this.label1dooo, 1);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.SetRowSpan(this.label1dooo, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1dooo.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1dooo.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.textdooo.Location = point;
            this.textdooo.Name = "textdooo";
            this.textdooo.Tag = "dooo";
            this.textdooo.TabIndex = 1;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textdooo.Size = size;
            this.textdooo.MaxLength = 7;
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.Controls.Add(this.textdooo, 1, 1);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.SetColumnSpan(this.textdooo, 1);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.SetRowSpan(this.textdooo, 1);
            padding = new Padding(0, 1, 3, 2);
            this.textdooo.Margin = padding;
            size = new System.Drawing.Size(0x41, 0x16);
            this.textdooo.MinimumSize = size;
            this.label1IDRADNIK.Name = "label1IDRADNIK";
            this.label1IDRADNIK.TabIndex = 1;
            this.label1IDRADNIK.Tag = "labelIDRADNIK";
            this.label1IDRADNIK.AutoSize = true;
            this.label1IDRADNIK.StyleSetName = "FieldUltraLabel";
            this.label1IDRADNIK.Text = "IDRADNIK    :";
            this.label1IDRADNIK.Appearance.TextVAlign = VAlign.Middle;
            this.label1IDRADNIK.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            this.label1IDRADNIK.Appearance.ForeColor = Color.Black;
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.Controls.Add(this.label1IDRADNIK, 0, 2);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.SetColumnSpan(this.label1IDRADNIK, 1);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.SetRowSpan(this.label1IDRADNIK, 1);
            padding = new Padding(3, 1, 5, 2);
            this.label1IDRADNIK.Margin = padding;
            size = new System.Drawing.Size(0, 0);
            this.label1IDRADNIK.MinimumSize = size;
            point = new System.Drawing.Point(0, 0);
            this.comboIDRADNIK.Location = point;
            this.comboIDRADNIK.Name = "comboIDRADNIK";
            this.comboIDRADNIK.Tag = "IDRADNIK";
            this.comboIDRADNIK.TabIndex = 2;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDRADNIK.Size = size;
            this.comboIDRADNIK.DropDownStyle = DropDownStyle.DropDownList;
            this.comboIDRADNIK.AddEmptyValue = true;
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.Controls.Add(this.comboIDRADNIK, 1, 2);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.SetColumnSpan(this.comboIDRADNIK, 1);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.SetRowSpan(this.comboIDRADNIK, 1);
            padding = new Padding(0, 1, 3, 2);
            this.comboIDRADNIK.Margin = padding;
            size = new System.Drawing.Size(0x268, 0x17);
            this.comboIDRADNIK.MinimumSize = size;
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.Controls.Add(this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC, 0, 3);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.SetColumnSpan(this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC, 2);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.SetRowSpan(this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC, 1);
            padding = new Padding(5, 10, 5, 10);
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.Margin = padding;
            size = new System.Drawing.Size(100, 100);
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.MinimumSize = size;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.Dock = DockStyle.Fill;
            this.Controls.Add(this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC);
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.Name = "userControlDataGridS_OD_BOLOVANJE_POSLODAVAC";
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DockPadding.All = 5;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.FillAtStartup = false;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.TabIndex = 6;
            point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.Location = point;
            size = new System.Drawing.Size(0x285, 350);
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.Size = size;
            this.ultraGridPrintDocument1.Grid = this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid;
            SizeF ef = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleDimensions = ef;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DockPadding.All = 5;
            this.Name = "S_OD_BOLOVANJE_POSLODAVACWorkWith";
            this.Text = "Work With S_OD_BOLOVANJE_POSLODAVAC";
            this.Load += new EventHandler(this.S_OD_BOLOVANJE_POSLODAVACUserControl_Load);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.ResumeLayout(false);
            this.layoutManagerformS_OD_BOLOVANJE_POSLODAVAC.PerformLayout();
            ((ISupportInitialize) this.textodd).EndInit();
            ((ISupportInitialize) this.textdooo).EndInit();
            this.ResumeLayout(false);
        }

        private bool InValidState()
        {
            return ((this.Controller.WorkItem.Status == WorkItemStatus.Active) && (this.CurrentDataRow != null));
        }

        private void LoadDefault()
        {
            this.textodd.Text = "";
            this.textdooo.Text = "";
            this.comboIDRADNIK.SelectedIndex = 0;
            if (this.m_FillByRow != null)
            {
                string str = "";
                if (this.m_FillByRow.Table.Columns.Contains("odd") && (this.m_FillByRow["odd"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textodd, this.m_FillByRow["odd"].ToString(), this.m_FillByRow.Table.Columns["odd"].DataType);
                    this.parameterSeted = true;
                    this.textodd.Visible = false;
                    this.label1odd.Visible = false;
                    str = str + "," + this.m_FillByRow["odd"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("dooo") && (this.m_FillByRow["dooo"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.textdooo, this.m_FillByRow["dooo"].ToString(), this.m_FillByRow.Table.Columns["dooo"].DataType);
                    this.parameterSeted = true;
                    this.textdooo.Visible = false;
                    this.label1dooo.Visible = false;
                    str = str + "," + this.m_FillByRow["dooo"].ToString() + " ";
                }
                if (this.m_FillByRow.Table.Columns.Contains("IDRADNIK") && (this.m_FillByRow["IDRADNIK"] != DBNull.Value))
                {
                    FormHelperClass.SetValue(this.comboIDRADNIK, this.m_FillByRow["IDRADNIK"].ToString(), this.m_FillByRow.Table.Columns["IDRADNIK"].DataType);
                    this.parameterSeted = true;
                    this.comboIDRADNIK.Visible = false;
                    this.label1IDRADNIK.Visible = false;
                    str = str + "," + this.m_FillByRow["IDRADNIK"].ToString() + " ";
                }
                if (this.parameterSeted)
                {
                    if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
                    {
                        this.Text = Deklarit.Resources.Resources.Select + "S_OD_BOLOVANJE_POSLODAVAC " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
                    }
                    else
                    {
                        this.Text = Deklarit.Resources.Resources.Workwith + "S_OD_BOLOVANJE_POSLODAVAC " + Deklarit.Resources.Resources.For + " " + str.Substring(1);
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
                    this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.DataSet.Clear();
                    this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.DataSet.ReadXml(dialog.FileName);
                    new S_OD_BOLOVANJE_POSLODAVACDataAdapter().Update(this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.DataSet);
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
            this.label1odd.Text = StringResources.S_OD_BOLOVANJE_POSLODAVACoddParameter;
            this.label1dooo.Text = StringResources.S_OD_BOLOVANJE_POSLODAVACdoooParameter;
            this.label1IDRADNIK.Text = StringResources.S_OD_BOLOVANJE_POSLODAVACIDRADNIKParameter;
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

        private void S_OD_BOLOVANJE_POSLODAVACUserControl_Load(object sender, EventArgs e)
        {
            if (this.m_WorkWithMode == Deklarit.Practices.CompositeUI.WorkWithMode.SelectionList)
            {
                this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.DoubleClick += new EventHandler(this.Select_Click);
                Size size = new System.Drawing.Size(600, 500);
                this.Parent.Parent.Size = size;
            }
            else
            {
                this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.DoubleClickRow += new DoubleClickRowEventHandler(this.DataGrid_DoubleClickRow);
            }
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.DisplayLayout.Override.AllowDelete = DefaultableBoolean.False;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy;
            this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortSingle;
            this.LoadDefault();
            if (this.parameterSeted)
            {
                this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.FillByPage = true;
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
                this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.DataSet.WriteXml(dialog.FileName);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            RowUIElement ancestor;
            UIElement lastElementEntered = this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.DisplayLayout.UIElement.LastElementEntered;
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
                this.smartPartInfo1.Title = string.Format("{0} S_OD_BOLOVANJE_POSLODAVAC ", Deklarit.Resources.Resources.Select);
            }
            else
            {
                this.smartPartInfo1.Title = string.Format("{0} S_OD_BOLOVANJE_POSLODAVAC ", Deklarit.Resources.Resources.Workwith);
            }
            this.smartPartInfo1.Description = this.smartPartInfo1.Title;
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg, this.smartPartInfo1.Description, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        protected virtual PregledRadnikaComboBox comboIDRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._comboIDRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._comboIDRADNIK = value;
            }
        }

        [CreateNew]
        public S_OD_BOLOVANJE_POSLODAVACController Controller { get; set; }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataView[this.userControlDataGridS_OD_BOLOVANJE_POSLODAVAC.DataGrid.CurrentRowIndex].Row;
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

        protected virtual UltraLabel label1dooo
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1dooo;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1dooo = value;
            }
        }

        protected virtual UltraLabel label1IDRADNIK
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1IDRADNIK;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1IDRADNIK = value;
            }
        }

        protected virtual UltraLabel label1odd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._label1odd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._label1odd = value;
            }
        }

        public DataRow SelectedRow
        {
            get
            {
                return this.m_RowSelected;
            }
        }

        protected virtual UltraTextEditor textdooo
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textdooo;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textdooo = value;
            }
        }

        protected virtual UltraTextEditor textodd
        {
            [DebuggerNonUserCode]
            get
            {
                return this._textodd;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._textodd = value;
            }
        }

        protected virtual S_OD_BOLOVANJE_POSLODAVACUserDataGrid userControlDataGridS_OD_BOLOVANJE_POSLODAVAC
        {
            [DebuggerNonUserCode]
            get
            {
                return this._userControlDataGridS_OD_BOLOVANJE_POSLODAVAC;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                this._userControlDataGridS_OD_BOLOVANJE_POSLODAVAC = value;
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

