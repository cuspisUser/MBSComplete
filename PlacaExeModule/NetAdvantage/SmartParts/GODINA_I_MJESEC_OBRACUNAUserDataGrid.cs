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

    public class GODINA_I_MJESEC_OBRACUNAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with GODINA_I_MJESEC_OBRACUNA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with GODINA_I_MJESEC_OBRACUNA";
        private GODINA_I_MJESEC_OBRACUNADataGrid userControlDataGridGODINA_I_MJESEC_OBRACUNA;

        public GODINA_I_MJESEC_OBRACUNAUserDataGrid()
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

        private void GODINA_I_MJESEC_OBRACUNAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void GODINA_I_MJESEC_OBRACUNAUserDataGrid_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && this.FillAtStartup)
            {
                this.DataGrid.Fill();
            }
        }

        private void InitializeComponent()
        {
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA = new GODINA_I_MJESEC_OBRACUNADataGrid();
            ((ISupportInitialize) this.userControlDataGridGODINA_I_MJESEC_OBRACUNA).BeginInit();
            UltraGridBand band = new UltraGridBand("GODINA_I_MJESEC_OBRACUNA", -1);
            UltraGridColumn column = new UltraGridColumn("GODINAIMJESECOBRACUNA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.GODINA_I_MJESEC_OBRACUNAGODINAIMJESECOBRACUNADescription;
            column.Width = 0xa3;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.Location = point;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.Name = "userControlDataGridGODINA_I_MJESEC_OBRACUNA";
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.Tag = "GODINA_I_MJESEC_OBRACUNA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.Size = size;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.Dock = DockStyle.Fill;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.FillAtStartup = false;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.InitializeRow += new InitializeRowEventHandler(this.GODINA_I_MJESEC_OBRACUNAUserDataGrid_InitializeRow);
            this.userControlDataGridGODINA_I_MJESEC_OBRACUNA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridGODINA_I_MJESEC_OBRACUNA });
            this.Name = "GODINA_I_MJESEC_OBRACUNAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.GODINA_I_MJESEC_OBRACUNAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridGODINA_I_MJESEC_OBRACUNA).EndInit();
            this.ResumeLayout(false);
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
        public virtual GODINA_I_MJESEC_OBRACUNADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridGODINA_I_MJESEC_OBRACUNA;
            }
            set
            {
                this.userControlDataGridGODINA_I_MJESEC_OBRACUNA = value;
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

