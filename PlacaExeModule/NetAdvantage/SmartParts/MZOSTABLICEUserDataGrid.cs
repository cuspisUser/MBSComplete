﻿namespace NetAdvantage.SmartParts
{
    using Deklarit.Controls;
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using NetAdvantage.Controls;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class MZOSTABLICEUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with MZOŠ Tablica";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with MZOŠ Tablica";
        private MZOSTABLICEDataGrid userControlDataGridMZOSTABLICE;

        public MZOSTABLICEUserDataGrid()
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
            this.userControlDataGridMZOSTABLICE = new MZOSTABLICEDataGrid();
            ((ISupportInitialize) this.userControlDataGridMZOSTABLICE).BeginInit();
            UltraGridBand band = new UltraGridBand("MZOSTABLICE", -1);
            UltraGridColumn column = new UltraGridColumn("IDMZOSTABLICE");
            UltraGridColumn column2 = new UltraGridColumn("OPISMZOSTABLICE");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.MZOSTABLICEIDMZOSTABLICEDescription;
            column.Width = 0x69;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.MZOSTABLICEOPISMZOSTABLICEDescription;
            column2.Width = 0x9c;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            this.userControlDataGridMZOSTABLICE.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridMZOSTABLICE.Location = point;
            this.userControlDataGridMZOSTABLICE.Name = "userControlDataGridMZOSTABLICE";
            this.userControlDataGridMZOSTABLICE.Tag = "MZOSTABLICE";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridMZOSTABLICE.Size = size;
            this.userControlDataGridMZOSTABLICE.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridMZOSTABLICE.Dock = DockStyle.Fill;
            this.userControlDataGridMZOSTABLICE.FillAtStartup = false;
            this.userControlDataGridMZOSTABLICE.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridMZOSTABLICE.InitializeRow += new InitializeRowEventHandler(this.MZOSTABLICEUserDataGrid_InitializeRow);
            this.userControlDataGridMZOSTABLICE.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridMZOSTABLICE });
            this.Name = "MZOSTABLICEUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.MZOSTABLICEUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridMZOSTABLICE).EndInit();
            this.ResumeLayout(false);
        }

        private void MZOSTABLICEUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void MZOSTABLICEUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual MZOSTABLICEDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridMZOSTABLICE;
            }
            set
            {
                this.userControlDataGridMZOSTABLICE = value;
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

        [TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), Category("Deklarit Work With "), DefaultValue("Fill")]
        public virtual string FillMethod
        {
            get
            {
                return this.DataGrid.FillMethod;
            }
            set
            {
                this.DataGrid.FillMethod = value;
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

