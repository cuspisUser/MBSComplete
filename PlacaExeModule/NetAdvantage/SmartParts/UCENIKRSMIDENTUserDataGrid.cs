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

    public class UCENIKRSMIDENTUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with UCENIKRSMIDENT";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with UCENIKRSMIDENT";
        private UCENIKRSMIDENTDataGrid userControlDataGridUCENIKRSMIDENT;

        public UCENIKRSMIDENTUserDataGrid()
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
            this.userControlDataGridUCENIKRSMIDENT = new UCENIKRSMIDENTDataGrid();
            ((ISupportInitialize) this.userControlDataGridUCENIKRSMIDENT).BeginInit();
            UltraGridBand band = new UltraGridBand("UCENIKRSMIDENT", -1);
            UltraGridColumn column = new UltraGridColumn("UCENIKRSMIDENT");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.UCENIKRSMIDENTUCENIKRSMIDENTDescription;
            column.Width = 0x72;
            column.Format = "";
            column.CellAppearance = appearance;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            this.userControlDataGridUCENIKRSMIDENT.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridUCENIKRSMIDENT.Location = point;
            this.userControlDataGridUCENIKRSMIDENT.Name = "userControlDataGridUCENIKRSMIDENT";
            this.userControlDataGridUCENIKRSMIDENT.Tag = "UCENIKRSMIDENT";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridUCENIKRSMIDENT.Size = size;
            this.userControlDataGridUCENIKRSMIDENT.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridUCENIKRSMIDENT.Dock = DockStyle.Fill;
            this.userControlDataGridUCENIKRSMIDENT.FillAtStartup = false;
            this.userControlDataGridUCENIKRSMIDENT.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridUCENIKRSMIDENT.InitializeRow += new InitializeRowEventHandler(this.UCENIKRSMIDENTUserDataGrid_InitializeRow);
            this.userControlDataGridUCENIKRSMIDENT.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridUCENIKRSMIDENT });
            this.Name = "UCENIKRSMIDENTUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.UCENIKRSMIDENTUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridUCENIKRSMIDENT).EndInit();
            this.ResumeLayout(false);
        }

        private void UCENIKRSMIDENTUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void UCENIKRSMIDENTUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual UCENIKRSMIDENTDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridUCENIKRSMIDENT;
            }
            set
            {
                this.userControlDataGridUCENIKRSMIDENT = value;
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

