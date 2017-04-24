﻿namespace NetAdvantage.SmartParts
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

    public class VW_MJESECI_GODINE_OBRACUNAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with VW_MJESECI_GODINE_OBRACUNA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with VW_MJESECI_GODINE_OBRACUNA";
        private VW_MJESECI_GODINE_OBRACUNADataGrid userControlDataGridVW_MJESECI_GODINE_OBRACUNA;

        public VW_MJESECI_GODINE_OBRACUNAUserDataGrid()
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
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA = new VW_MJESECI_GODINE_OBRACUNADataGrid();
            ((ISupportInitialize) this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA).BeginInit();
            UltraGridBand band = new UltraGridBand("VW_MJESECI_GODINE_OBRACUNA", -1);
            UltraGridColumn column2 = new UltraGridColumn("MJESECOBRACUNA");
            UltraGridColumn column = new UltraGridColumn("GODINAOBRACUNA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.VW_MJESECI_GODINE_OBRACUNAMJESECOBRACUNADescription;
            column2.Width = 0x79;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.VW_MJESECI_GODINE_OBRACUNAGODINAOBRACUNADescription;
            column.Width = 0x79;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 1;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.Location = point;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.Name = "userControlDataGridVW_MJESECI_GODINE_OBRACUNA";
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.Tag = "VW_MJESECI_GODINE_OBRACUNA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.Size = size;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.Dock = DockStyle.Fill;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.FillAtStartup = false;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.InitializeRow += new InitializeRowEventHandler(this.VW_MJESECI_GODINE_OBRACUNAUserDataGrid_InitializeRow);
            this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA });
            this.Name = "VW_MJESECI_GODINE_OBRACUNAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.VW_MJESECI_GODINE_OBRACUNAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA).EndInit();
            this.ResumeLayout(false);
        }

        private void VW_MJESECI_GODINE_OBRACUNAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void VW_MJESECI_GODINE_OBRACUNAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual VW_MJESECI_GODINE_OBRACUNADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA;
            }
            set
            {
                this.userControlDataGridVW_MJESECI_GODINE_OBRACUNA = value;
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
