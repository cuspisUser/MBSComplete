namespace NetAdvantage.SmartParts
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

    public class OBUSTAVAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with Obustave";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with Obustave";
        private OBUSTAVADataGrid userControlDataGridOBUSTAVA;

        public OBUSTAVAUserDataGrid()
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
            this.userControlDataGridOBUSTAVA = new OBUSTAVADataGrid();
            ((ISupportInitialize) this.userControlDataGridOBUSTAVA).BeginInit();
            UltraGridBand band = new UltraGridBand("OBUSTAVA", -1);
            UltraGridColumn column = new UltraGridColumn("IDOBUSTAVA");
            UltraGridColumn column4 = new UltraGridColumn("NAZIVOBUSTAVA");
            UltraGridColumn column2 = new UltraGridColumn("MOOBUSTAVA");
            UltraGridColumn column7 = new UltraGridColumn("POOBUSTAVA");
            UltraGridColumn column3 = new UltraGridColumn("MZOBUSTAVA");
            UltraGridColumn column11 = new UltraGridColumn("PZOBUSTAVA");
            UltraGridColumn column13 = new UltraGridColumn("VBDIOBUSTAVA");
            UltraGridColumn column15 = new UltraGridColumn("ZRNOBUSTAVA");
            UltraGridColumn column8 = new UltraGridColumn("PRIMATELJOBUSTAVA1");
            UltraGridColumn column9 = new UltraGridColumn("PRIMATELJOBUSTAVA2");
            UltraGridColumn column10 = new UltraGridColumn("PRIMATELJOBUSTAVA3");
            UltraGridColumn column12 = new UltraGridColumn("SIFRAOPISAPLACANJAOBUSTAVA");
            UltraGridColumn column6 = new UltraGridColumn("OPISPLACANJAOBUSTAVA");
            UltraGridColumn column14 = new UltraGridColumn("VRSTAOBUSTAVE");
            UltraGridColumn column5 = new UltraGridColumn("NAZIVVRSTAOBUSTAVE");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.OBUSTAVAIDOBUSTAVADescription;
            column.Width = 0x70;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.OBUSTAVANAZIVOBUSTAVADescription;
            column4.Width = 0x128;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.OBUSTAVAMOOBUSTAVADescription;
            column2.Width = 0x79;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.OBUSTAVAPOOBUSTAVADescription;
            column7.Width = 240;
            column7.Format = "";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.OBUSTAVAMZOBUSTAVADescription;
            column3.Width = 0xb8;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.OBUSTAVAPZOBUSTAVADescription;
            column11.Width = 240;
            column11.Format = "";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.OBUSTAVAVBDIOBUSTAVADescription;
            column13.Width = 0xbf;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.OBUSTAVAZRNOBUSTAVADescription;
            column15.Width = 0xbf;
            column15.Format = "";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.OBUSTAVAPRIMATELJOBUSTAVA1Description;
            column8.Width = 0x9c;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.OBUSTAVAPRIMATELJOBUSTAVA2Description;
            column9.Width = 0x9c;
            column9.Format = "";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.OBUSTAVAPRIMATELJOBUSTAVA3Description;
            column10.Width = 0x9c;
            column10.Format = "";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.OBUSTAVASIFRAOPISAPLACANJAOBUSTAVADescription;
            column12.Width = 0x9c;
            column12.Format = "";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.OBUSTAVAOPISPLACANJAOBUSTAVADescription;
            column6.Width = 0x10c;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.OBUSTAVAVRSTAOBUSTAVEDescription;
            column14.Width = 0x70;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nn";
            column14.PromptChar = ' ';
            column14.Format = "";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.OBUSTAVANAZIVVRSTAOBUSTAVEDescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 3;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 4;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 5;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 6;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 7;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 8;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 9;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 10;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 11;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 12;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 13;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 14;
            this.userControlDataGridOBUSTAVA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridOBUSTAVA.Location = point;
            this.userControlDataGridOBUSTAVA.Name = "userControlDataGridOBUSTAVA";
            this.userControlDataGridOBUSTAVA.Tag = "OBUSTAVA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridOBUSTAVA.Size = size;
            this.userControlDataGridOBUSTAVA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridOBUSTAVA.Dock = DockStyle.Fill;
            this.userControlDataGridOBUSTAVA.FillAtStartup = false;
            this.userControlDataGridOBUSTAVA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridOBUSTAVA.InitializeRow += new InitializeRowEventHandler(this.OBUSTAVAUserDataGrid_InitializeRow);
            this.userControlDataGridOBUSTAVA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridOBUSTAVA });
            this.Name = "OBUSTAVAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.OBUSTAVAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridOBUSTAVA).EndInit();
            this.ResumeLayout(false);
        }

        private void OBUSTAVAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void OBUSTAVAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual OBUSTAVADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridOBUSTAVA;
            }
            set
            {
                this.userControlDataGridOBUSTAVA = value;
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

        [Category("Deklarit Work With ")]
        public virtual short FillByVRSTAOBUSTAVEVRSTAOBUSTAVE
        {
            get
            {
                return this.DataGrid.FillByVRSTAOBUSTAVEVRSTAOBUSTAVE;
            }
            set
            {
                this.DataGrid.FillByVRSTAOBUSTAVEVRSTAOBUSTAVE = value;
            }
        }

        [DefaultValue("Fill"), TypeConverter(typeof(DeklaritDataGrid.FillMethodsConverter)), Category("Deklarit Work With ")]
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

