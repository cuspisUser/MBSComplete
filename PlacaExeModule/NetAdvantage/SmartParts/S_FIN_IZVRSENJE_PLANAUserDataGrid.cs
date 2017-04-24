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

    public class S_FIN_IZVRSENJE_PLANAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with S_FIN_IZVRSENJE_PLANA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with S_FIN_IZVRSENJE_PLANA";
        private S_FIN_IZVRSENJE_PLANADataGrid userControlDataGridS_FIN_IZVRSENJE_PLANA;

        public S_FIN_IZVRSENJE_PLANAUserDataGrid()
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
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA = new S_FIN_IZVRSENJE_PLANADataGrid();
            ((ISupportInitialize) this.userControlDataGridS_FIN_IZVRSENJE_PLANA).BeginInit();
            UltraGridBand band = new UltraGridBand("S_FIN_IZVRSENJE_PLANA", -1);
            UltraGridColumn column3 = new UltraGridColumn("konto");
            UltraGridColumn column4 = new UltraGridColumn("PLANIRANO");
            UltraGridColumn column2 = new UltraGridColumn("IZVRSENO");
            UltraGridColumn column = new UltraGridColumn("INDEKS");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.S_FIN_IZVRSENJE_PLANAkontoDescription;
            column3.Width = 0x79;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.S_FIN_IZVRSENJE_PLANAPLANIRANODescription;
            column4.Width = 0x66;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.S_FIN_IZVRSENJE_PLANAIZVRSENODescription;
            column2.Width = 0x66;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.S_FIN_IZVRSENJE_PLANAINDEKSDescription;
            column.Width = 0x3e;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnn.nn";
            column.PromptChar = ' ';
            column.Format = "F2";
            column.CellAppearance = appearance;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 3;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.Location = point;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.Name = "userControlDataGridS_FIN_IZVRSENJE_PLANA";
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.Tag = "S_FIN_IZVRSENJE_PLANA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.Size = size;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.Dock = DockStyle.Fill;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.FillAtStartup = false;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.InitializeRow += new InitializeRowEventHandler(this.S_FIN_IZVRSENJE_PLANAUserDataGrid_InitializeRow);
            this.userControlDataGridS_FIN_IZVRSENJE_PLANA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridS_FIN_IZVRSENJE_PLANA });
            this.Name = "S_FIN_IZVRSENJE_PLANAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.S_FIN_IZVRSENJE_PLANAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridS_FIN_IZVRSENJE_PLANA).EndInit();
            this.ResumeLayout(false);
        }

        private void S_FIN_IZVRSENJE_PLANAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void S_FIN_IZVRSENJE_PLANAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual S_FIN_IZVRSENJE_PLANADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridS_FIN_IZVRSENJE_PLANA;
            }
            set
            {
                this.userControlDataGridS_FIN_IZVRSENJE_PLANA = value;
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
        public virtual string Parametergodina
        {
            get
            {
                return this.DataGrid.Parametergodina;
            }
            set
            {
                this.DataGrid.Parametergodina = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterIDORGJED
        {
            get
            {
                return this.DataGrid.ParameterIDORGJED;
            }
            set
            {
                this.DataGrid.ParameterIDORGJED = value;
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

