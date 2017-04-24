namespace NetAdvantage.SmartParts
{
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using NetAdvantage.Controls;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class S_PLACA_ODBICI_GODINAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_PLACA_ODBICI_GODINA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_PLACA_ODBICI_GODINA";
        private S_PLACA_ODBICI_GODINADataGrid userControlDataGridS_PLACA_ODBICI_GODINA;

        public S_PLACA_ODBICI_GODINAUserDataGrid()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Fill()
        {
            this.DataGrid.Fill();
        }

        private void InitializeComponent()
        {
            this.userControlDataGridS_PLACA_ODBICI_GODINA = new S_PLACA_ODBICI_GODINADataGrid();
            ((ISupportInitialize) this.userControlDataGridS_PLACA_ODBICI_GODINA).BeginInit();
            UltraGridBand band = new UltraGridBand("S_PLACA_ODBICI_GODINA", -1);
            UltraGridColumn column3 = new UltraGridColumn("OLAKSICE");
            UltraGridColumn column2 = new UltraGridColumn("ODBITAK");
            UltraGridColumn column = new UltraGridColumn("IDRADNIK");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_PLACA_ODBICI_GODINAOLAKSICEDescription;
            column3.Width = 0x66;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_PLACA_ODBICI_GODINAODBITAKDescription;
            column2.Width = 0x66;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_PLACA_ODBICI_GODINAIDRADNIKDescription;
            column.Width = 0x69;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            this.userControlDataGridS_PLACA_ODBICI_GODINA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_PLACA_ODBICI_GODINA.Location = point;
            this.userControlDataGridS_PLACA_ODBICI_GODINA.Name = "userControlDataGridS_PLACA_ODBICI_GODINA";
            this.userControlDataGridS_PLACA_ODBICI_GODINA.Tag = "S_PLACA_ODBICI_GODINA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_PLACA_ODBICI_GODINA.Size = size;
            this.userControlDataGridS_PLACA_ODBICI_GODINA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_PLACA_ODBICI_GODINA.Dock = DockStyle.Fill;
            this.userControlDataGridS_PLACA_ODBICI_GODINA.FillAtStartup = false;
            this.userControlDataGridS_PLACA_ODBICI_GODINA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_PLACA_ODBICI_GODINA.InitializeRow += new InitializeRowEventHandler(this.S_PLACA_ODBICI_GODINAUserDataGrid_InitializeRow);
            this.userControlDataGridS_PLACA_ODBICI_GODINA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_PLACA_ODBICI_GODINA });
            this.Name = "S_PLACA_ODBICI_GODINAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_PLACA_ODBICI_GODINAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_PLACA_ODBICI_GODINA).EndInit();
            this.ResumeLayout(false);
        }

        private void S_PLACA_ODBICI_GODINAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_PLACA_ODBICI_GODINAUserDataGrid_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && this.FillAtStartup)
            {
                this.DataGrid.Fill();
            }
        }

        private DataRow CurrentDataRow
        {
            get
            {
                if (this.DataGrid.CurrentRowIndex == -1)
                {
                    return null;
                }
                return this.DataView[this.DataGrid.CurrentRowIndex].Row;
            }
        }

        [Browsable(false)]
        public virtual S_PLACA_ODBICI_GODINADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_PLACA_ODBICI_GODINA;
            }
            set
            {
                this.userControlDataGridS_PLACA_ODBICI_GODINA = value;
            }
        }

        [Category("Deklarit Work With "), Browsable(false)]
        public virtual System.Data.DataView DataView
        {
            get
            {
                return this.DataGrid.DataView;
            }
        }

        public string Description
        {
            get
            {
                return this.m_Description;
            }
            set
            {
                this.m_Description = value;
            }
        }

        [DefaultValue(true), Category("Deklarit Work With "), Description("True= Fill at Startup. False= Not Fill")]
        public virtual bool FillAtStartup
        {
            get
            {
                return this.m_FillAtStartup;
            }
            set
            {
                this.m_FillAtStartup = value;
            }
        }

        [DefaultValue(true), Category("Deklarit Work With ")]
        public virtual bool FillByPage
        {
            get
            {
                return this.DataGrid.FillByPage;
            }
            set
            {
                this.DataGrid.FillByPage = value;
            }
        }

        string Microsoft.Practices.CompositeUI.SmartParts.ISmartPartInfo.Description
        {
            get
            {
                return this.m_Description;
            }
            set
            {
                this.m_Description = value;
            }
        }

        string Microsoft.Practices.CompositeUI.SmartParts.ISmartPartInfo.Title
        {
            get
            {
                return this.m_Title;
            }
            set
            {
                this.m_Title = value;
            }
        }

        [DefaultValue(60), Category("Deklarit Work With ")]
        public virtual int PageSize
        {
            get
            {
                return this.DataGrid.PageSize;
            }
            set
            {
                this.DataGrid.PageSize = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterGODINAISPLATE
        {
            get
            {
                return this.DataGrid.ParameterGODINAISPLATE;
            }
            set
            {
                this.DataGrid.ParameterGODINAISPLATE = value;
            }
        }

        public string Title
        {
            get
            {
                return this.m_Title;
            }
            set
            {
                this.m_Title = value;
            }
        }
    }
}

