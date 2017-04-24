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

    public class S_PLACA_RAD1G_IVUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_PLACA_RAD1G_IV";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_PLACA_RAD1G_IV";
        private S_PLACA_RAD1G_IVDataGrid userControlDataGridS_PLACA_RAD1G_IV;

        public S_PLACA_RAD1G_IVUserDataGrid()
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
            this.userControlDataGridS_PLACA_RAD1G_IV = new S_PLACA_RAD1G_IVDataGrid();
            ((ISupportInitialize) this.userControlDataGridS_PLACA_RAD1G_IV).BeginInit();
            UltraGridBand band = new UltraGridBand("S_PLACA_RAD1G_IV", -1);
            UltraGridColumn column = new UltraGridColumn("BRUTOPLACA");
            UltraGridColumn column2 = new UltraGridColumn("netoplaca");
            UltraGridColumn column4 = new UltraGridColumn("SPREMA");
            UltraGridColumn column3 = new UltraGridColumn("SPOL");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_PLACA_RAD1G_IVBRUTOPLACADescription;
            column.Width = 0x66;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column.PromptChar = ' ';
            column.Format = "F2";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_PLACA_RAD1G_IVnetoplacaDescription;
            column2.Width = 0x66;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_PLACA_RAD1G_IVSPREMADescription;
            column4.Width = 0x3a;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_PLACA_RAD1G_IVSPOLDescription;
            column3.Width = 0x2c;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 2;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 3;
            this.userControlDataGridS_PLACA_RAD1G_IV.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_PLACA_RAD1G_IV.Location = point;
            this.userControlDataGridS_PLACA_RAD1G_IV.Name = "userControlDataGridS_PLACA_RAD1G_IV";
            this.userControlDataGridS_PLACA_RAD1G_IV.Tag = "S_PLACA_RAD1G_IV";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_PLACA_RAD1G_IV.Size = size;
            this.userControlDataGridS_PLACA_RAD1G_IV.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_PLACA_RAD1G_IV.Dock = DockStyle.Fill;
            this.userControlDataGridS_PLACA_RAD1G_IV.FillAtStartup = false;
            this.userControlDataGridS_PLACA_RAD1G_IV.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_PLACA_RAD1G_IV.InitializeRow += new InitializeRowEventHandler(this.S_PLACA_RAD1G_IVUserDataGrid_InitializeRow);
            this.userControlDataGridS_PLACA_RAD1G_IV.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_PLACA_RAD1G_IV });
            this.Name = "S_PLACA_RAD1G_IVUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_PLACA_RAD1G_IVUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_PLACA_RAD1G_IV).EndInit();
            this.ResumeLayout(false);
        }

        private void S_PLACA_RAD1G_IVUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_PLACA_RAD1G_IVUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_PLACA_RAD1G_IVDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_PLACA_RAD1G_IV;
            }
            set
            {
                this.userControlDataGridS_PLACA_RAD1G_IV = value;
            }
        }

        [Browsable(false), Category("Deklarit Work With ")]
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
        public virtual string ParameterGODINAOBRACUNA
        {
            get
            {
                return this.DataGrid.ParameterGODINAOBRACUNA;
            }
            set
            {
                this.DataGrid.ParameterGODINAOBRACUNA = value;
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

