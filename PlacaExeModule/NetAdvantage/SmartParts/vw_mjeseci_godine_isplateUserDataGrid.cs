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

    public class vw_mjeseci_godine_isplateUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with vw_mjeseci_godine_isplate";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with vw_mjeseci_godine_isplate";
        private vw_mjeseci_godine_isplateDataGrid userControlDataGridvw_mjeseci_godine_isplate;

        public vw_mjeseci_godine_isplateUserDataGrid()
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
            this.userControlDataGridvw_mjeseci_godine_isplate = new vw_mjeseci_godine_isplateDataGrid();
            ((ISupportInitialize) this.userControlDataGridvw_mjeseci_godine_isplate).BeginInit();
            UltraGridBand band = new UltraGridBand("vw_mjeseci_godine_isplate", -1);
            UltraGridColumn column2 = new UltraGridColumn("MJESECISPLATE");
            UltraGridColumn column = new UltraGridColumn("GODINAISPLATE");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.vw_mjeseci_godine_isplateMJESECISPLATEDescription;
            column2.Width = 0x72;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.vw_mjeseci_godine_isplateGODINAISPLATEDescription;
            column.Width = 0x72;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 1;
            this.userControlDataGridvw_mjeseci_godine_isplate.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridvw_mjeseci_godine_isplate.Location = point;
            this.userControlDataGridvw_mjeseci_godine_isplate.Name = "userControlDataGridvw_mjeseci_godine_isplate";
            this.userControlDataGridvw_mjeseci_godine_isplate.Tag = "vw_mjeseci_godine_isplate";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridvw_mjeseci_godine_isplate.Size = size;
            this.userControlDataGridvw_mjeseci_godine_isplate.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridvw_mjeseci_godine_isplate.Dock = DockStyle.Fill;
            this.userControlDataGridvw_mjeseci_godine_isplate.FillAtStartup = false;
            this.userControlDataGridvw_mjeseci_godine_isplate.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridvw_mjeseci_godine_isplate.InitializeRow += new InitializeRowEventHandler(this.vw_mjeseci_godine_isplateUserDataGrid_InitializeRow);
            this.userControlDataGridvw_mjeseci_godine_isplate.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridvw_mjeseci_godine_isplate });
            this.Name = "vw_mjeseci_godine_isplateUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.vw_mjeseci_godine_isplateUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridvw_mjeseci_godine_isplate).EndInit();
            this.ResumeLayout(false);
        }

        private void vw_mjeseci_godine_isplateUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void vw_mjeseci_godine_isplateUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual vw_mjeseci_godine_isplateDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridvw_mjeseci_godine_isplate;
            }
            set
            {
                this.userControlDataGridvw_mjeseci_godine_isplate = value;
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

        [Category("Deklarit Work With "), Description("True= Fill at Startup. False= Not Fill"), DefaultValue(true)]
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

