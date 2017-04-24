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

    public class S_OD_OO_MJESECNOUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_OD_OO_MJESECNO";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_OD_OO_MJESECNO";
        private S_OD_OO_MJESECNODataGrid userControlDataGridS_OD_OO_MJESECNO;

        public S_OD_OO_MJESECNOUserDataGrid()
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
            this.userControlDataGridS_OD_OO_MJESECNO = new S_OD_OO_MJESECNODataGrid();
            ((ISupportInitialize) this.userControlDataGridS_OD_OO_MJESECNO).BeginInit();
            UltraGridBand band = new UltraGridBand("S_OD_OO_MJESECNO", -1);
            UltraGridColumn column = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column2 = new UltraGridColumn("UKUPNOOBRACUNATOOO");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_OD_OO_MJESECNOIDRADNIKDescription;
            column.Width = 0x69;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_OD_OO_MJESECNOUKUPNOOBRACUNATOOODescription;
            column2.Width = 0x8f;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 1;
            this.userControlDataGridS_OD_OO_MJESECNO.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_OD_OO_MJESECNO.Location = point;
            this.userControlDataGridS_OD_OO_MJESECNO.Name = "userControlDataGridS_OD_OO_MJESECNO";
            this.userControlDataGridS_OD_OO_MJESECNO.Tag = "S_OD_OO_MJESECNO";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_OD_OO_MJESECNO.Size = size;
            this.userControlDataGridS_OD_OO_MJESECNO.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_OD_OO_MJESECNO.Dock = DockStyle.Fill;
            this.userControlDataGridS_OD_OO_MJESECNO.FillAtStartup = false;
            this.userControlDataGridS_OD_OO_MJESECNO.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_OD_OO_MJESECNO.InitializeRow += new InitializeRowEventHandler(this.S_OD_OO_MJESECNOUserDataGrid_InitializeRow);
            this.userControlDataGridS_OD_OO_MJESECNO.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_OD_OO_MJESECNO });
            this.Name = "S_OD_OO_MJESECNOUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_OD_OO_MJESECNOUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_OD_OO_MJESECNO).EndInit();
            this.ResumeLayout(false);
        }

        private void S_OD_OO_MJESECNOUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_OD_OO_MJESECNOUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_OD_OO_MJESECNODataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_OD_OO_MJESECNO;
            }
            set
            {
                this.userControlDataGridS_OD_OO_MJESECNO = value;
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

        [Category("Deklarit Work With "), DefaultValue(true), Description("True= Fill at Startup. False= Not Fill")]
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

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterIDOBRACUN
        {
            get
            {
                return this.DataGrid.ParameterIDOBRACUN;
            }
            set
            {
                this.DataGrid.ParameterIDOBRACUN = value;
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

