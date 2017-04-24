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

    public class S_DD_IPPUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_DD_IPP";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_DD_IPP";
        private S_DD_IPPDataGrid userControlDataGridS_DD_IPP;

        public S_DD_IPPUserDataGrid()
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
            this.userControlDataGridS_DD_IPP = new S_DD_IPPDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_DD_IPP).BeginInit();
            UltraGridBand band = new UltraGridBand("S_DD_IPP", -1);
            UltraGridColumn column3 = new UltraGridColumn("OSNOVICAKRIZNOGPOREZA");
            UltraGridColumn column2 = new UltraGridColumn("KRIZNIPOREZ");
            UltraGridColumn column = new UltraGridColumn("BROJRADNIKA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_DD_IPPOSNOVICAKRIZNOGPOREZADescription;
            column3.Width = 0x81;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_DD_IPPKRIZNIPOREZDescription;
            column2.Width = 0xa3;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_DD_IPPBROJRADNIKADescription;
            column.Width = 0x81;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column.PromptChar = ' ';
            column.Format = "F2";
            column.CellAppearance = appearance;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 2;
            this.userControlDataGridS_DD_IPP.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_DD_IPP.Location = point;
            this.userControlDataGridS_DD_IPP.Name = "userControlDataGridS_DD_IPP";
            this.userControlDataGridS_DD_IPP.Tag = "S_DD_IPP";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_DD_IPP.Size = size;
            this.userControlDataGridS_DD_IPP.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_DD_IPP.Dock = DockStyle.Fill;
            this.userControlDataGridS_DD_IPP.FillAtStartup = false;
            this.userControlDataGridS_DD_IPP.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_DD_IPP.InitializeRow += new InitializeRowEventHandler(this.S_DD_IPPUserDataGrid_InitializeRow);
            this.userControlDataGridS_DD_IPP.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_DD_IPP });
            this.Name = "S_DD_IPPUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_DD_IPPUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_DD_IPP).EndInit();
            this.ResumeLayout(false);
        }

        private void S_DD_IPPUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_DD_IPPUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_DD_IPPDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_DD_IPP;
            }
            set
            {
                this.userControlDataGridS_DD_IPP = value;
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

        [Description("True= Fill at Startup. False= Not Fill"), DefaultValue(true), Category("Deklarit Work With ")]
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

        [Category("Deklarit Work With "), DefaultValue(true)]
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
        public virtual string ParameterGODINA
        {
            get
            {
                return this.DataGrid.ParameterGODINA;
            }
            set
            {
                this.DataGrid.ParameterGODINA = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterMJESEC
        {
            get
            {
                return this.DataGrid.ParameterMJESEC;
            }
            set
            {
                this.DataGrid.ParameterMJESEC = value;
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

