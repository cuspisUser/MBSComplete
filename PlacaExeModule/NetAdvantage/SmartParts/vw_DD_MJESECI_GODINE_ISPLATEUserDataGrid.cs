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

    public class vw_DD_MJESECI_GODINE_ISPLATEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with vw_DD_MJESECI_GODINE_ISPLATE";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with vw_DD_MJESECI_GODINE_ISPLATE";
        private vw_DD_MJESECI_GODINE_ISPLATEDataGrid userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE;

        public vw_DD_MJESECI_GODINE_ISPLATEUserDataGrid()
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
            this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE = new vw_DD_MJESECI_GODINE_ISPLATEDataGrid();
            ((ISupportInitialize) this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE).BeginInit();
            UltraGridBand band = new UltraGridBand("vw_DD_MJESECI_GODINE_ISPLATE", -1);
            UltraGridColumn column2 = new UltraGridColumn("MJESECISPLATE");
            UltraGridColumn column = new UltraGridColumn("GODINAISPLATE");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.vw_DD_MJESECI_GODINE_ISPLATEMJESECISPLATEDescription;
            column2.Width = 0x72;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.vw_DD_MJESECI_GODINE_ISPLATEGODINAISPLATEDescription;
            column.Width = 0x72;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 1;
            this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE.Location = point;
            this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE.Name = "userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE";
            this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE.Tag = "vw_DD_MJESECI_GODINE_ISPLATE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE.Size = size;
            this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE.Dock = DockStyle.Fill;
            this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE.FillAtStartup = false;
            this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE.InitializeRow += new InitializeRowEventHandler(this.vw_DD_MJESECI_GODINE_ISPLATEUserDataGrid_InitializeRow);
            this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE });
            this.Name = "vw_DD_MJESECI_GODINE_ISPLATEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.vw_DD_MJESECI_GODINE_ISPLATEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE).EndInit();
            this.ResumeLayout(false);
        }

        private void vw_DD_MJESECI_GODINE_ISPLATEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void vw_DD_MJESECI_GODINE_ISPLATEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual vw_DD_MJESECI_GODINE_ISPLATEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE;
            }
            set
            {
                this.userControlDataGridvw_DD_MJESECI_GODINE_ISPLATE = value;
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

