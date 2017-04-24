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

    public class VW_GODINE_ISPLATEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with VW_GODINE_ISPLATE";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with VW_GODINE_ISPLATE";
        private VW_GODINE_ISPLATEDataGrid userControlDataGridVW_GODINE_ISPLATE;

        public VW_GODINE_ISPLATEUserDataGrid()
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
            this.userControlDataGridVW_GODINE_ISPLATE = new VW_GODINE_ISPLATEDataGrid();
            ((ISupportInitialize) this.userControlDataGridVW_GODINE_ISPLATE).BeginInit();
            UltraGridBand band = new UltraGridBand("VW_GODINE_ISPLATE", -1);
            UltraGridColumn column = new UltraGridColumn("GODINAISPLATE");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.VW_GODINE_ISPLATEGODINAISPLATEDescription;
            column.Width = 0x72;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            this.userControlDataGridVW_GODINE_ISPLATE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridVW_GODINE_ISPLATE.Location = point;
            this.userControlDataGridVW_GODINE_ISPLATE.Name = "userControlDataGridVW_GODINE_ISPLATE";
            this.userControlDataGridVW_GODINE_ISPLATE.Tag = "VW_GODINE_ISPLATE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridVW_GODINE_ISPLATE.Size = size;
            this.userControlDataGridVW_GODINE_ISPLATE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridVW_GODINE_ISPLATE.Dock = DockStyle.Fill;
            this.userControlDataGridVW_GODINE_ISPLATE.FillAtStartup = false;
            this.userControlDataGridVW_GODINE_ISPLATE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridVW_GODINE_ISPLATE.InitializeRow += new InitializeRowEventHandler(this.VW_GODINE_ISPLATEUserDataGrid_InitializeRow);
            this.userControlDataGridVW_GODINE_ISPLATE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridVW_GODINE_ISPLATE });
            this.Name = "VW_GODINE_ISPLATEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.VW_GODINE_ISPLATEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridVW_GODINE_ISPLATE).EndInit();
            this.ResumeLayout(false);
        }

        private void VW_GODINE_ISPLATEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void VW_GODINE_ISPLATEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual VW_GODINE_ISPLATEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridVW_GODINE_ISPLATE;
            }
            set
            {
                this.userControlDataGridVW_GODINE_ISPLATE = value;
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

        [Category("Deklarit Work With "), DefaultValue(60)]
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

