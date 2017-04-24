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

    public class SP_LISTA_IZNOSA_RADNIKAUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with SP_LISTA_IZNOSA_RADNIKA";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with SP_LISTA_IZNOSA_RADNIKA";
        private SP_LISTA_IZNOSA_RADNIKADataGrid userControlDataGridSP_LISTA_IZNOSA_RADNIKA;

        public SP_LISTA_IZNOSA_RADNIKAUserDataGrid()
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
            this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA = new SP_LISTA_IZNOSA_RADNIKADataGrid();
            ((ISupportInitialize) this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA).BeginInit();
            UltraGridBand band = new UltraGridBand("SP_LISTA_IZNOSA_RADNIKA", -1);
            UltraGridColumn column = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column8 = new UltraGridColumn("PREZIME");
            UltraGridColumn column2 = new UltraGridColumn("IME");
            UltraGridColumn column9 = new UltraGridColumn("satibruto");
            UltraGridColumn column10 = new UltraGridColumn("ukupnobruto");
            UltraGridColumn column3 = new UltraGridColumn("KOEFICIJENT");
            UltraGridColumn column11 = new UltraGridColumn("ukupnodoprinosi");
            UltraGridColumn column16 = new UltraGridColumn("ukupnoporeziprirez");
            UltraGridColumn column4 = new UltraGridColumn("netoplaca");
            UltraGridColumn column13 = new UltraGridColumn("ukupnonetonaknade");
            UltraGridColumn column6 = new UltraGridColumn("netoprimanja");
            UltraGridColumn column14 = new UltraGridColumn("ukupnoobustave");
            UltraGridColumn column17 = new UltraGridColumn("UKUPNOZAISPLATU");
            UltraGridColumn column15 = new UltraGridColumn("ukupnoolaksice");
            UltraGridColumn column12 = new UltraGridColumn("UKUPNODOPRINOSINA");
            UltraGridColumn column7 = new UltraGridColumn("POREZKRIZNI");
            UltraGridColumn column5 = new UltraGridColumn("netoplacamanjekrizni");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAIDRADNIKDescription;
            column.Width = 0x69;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAPREZIMEDescription;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAIMEDescription;
            column2.Width = 0x128;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAsatibrutoDescription;
            column9.Width = 0x66;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAukupnobrutoDescription;
            column10.Width = 0x66;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAKOEFICIJENTDescription;
            column3.Width = 0x88;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnn.nnnnnnnnnn";
            column3.PromptChar = ' ';
            column3.Format = "F10";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAukupnodoprinosiDescription;
            column11.Width = 0x7b;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAukupnoporeziprirezDescription;
            column16.Width = 0x8f;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column16.PromptChar = ' ';
            column16.Format = "F2";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAnetoplacaDescription;
            column4.Width = 0x66;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column4.PromptChar = ' ';
            column4.Format = "F2";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAukupnonetonaknadeDescription;
            column13.Width = 0x88;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAnetoprimanjaDescription;
            column6.Width = 0x66;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAukupnoobustaveDescription;
            column14.Width = 0x74;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAUKUPNOZAISPLATUDescription;
            column17.Width = 0x7b;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column17.PromptChar = ' ';
            column17.Format = "F2";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAukupnoolaksiceDescription;
            column15.Width = 0x74;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAUKUPNODOPRINOSINADescription;
            column12.Width = 0x88;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAPOREZKRIZNIDescription;
            column7.Width = 0x66;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.SP_LISTA_IZNOSA_RADNIKAnetoplacamanjekrizniDescription;
            column5.Width = 0x9c;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 1;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 2;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 3;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 4;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 5;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 6;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 7;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 8;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 9;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 10;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 11;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 12;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 13;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 14;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 15;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 0x10;
            this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA.Location = point;
            this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA.Name = "userControlDataGridSP_LISTA_IZNOSA_RADNIKA";
            this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA.Tag = "SP_LISTA_IZNOSA_RADNIKA";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA.Size = size;
            this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA.Dock = DockStyle.Fill;
            this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA.FillAtStartup = false;
            this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA.InitializeRow += new InitializeRowEventHandler(this.SP_LISTA_IZNOSA_RADNIKAUserDataGrid_InitializeRow);
            this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA });
            this.Name = "SP_LISTA_IZNOSA_RADNIKAUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.SP_LISTA_IZNOSA_RADNIKAUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA).EndInit();
            this.ResumeLayout(false);
        }

        private void SP_LISTA_IZNOSA_RADNIKAUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void SP_LISTA_IZNOSA_RADNIKAUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual SP_LISTA_IZNOSA_RADNIKADataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA;
            }
            set
            {
                this.userControlDataGridSP_LISTA_IZNOSA_RADNIKA = value;
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

        [DefaultValue(true), Description("True= Fill at Startup. False= Not Fill"), Category("Deklarit Work With ")]
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

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterGODINAOBRACUNA
        {
            get
            {
                return this.DataGrid.ParameterGODINAOBRACUNA;
            }
            set
            {
                this.DataGrid.ParameterGODINAOBRACUNA = value;
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

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string ParameterMJESECOBRACUNA
        {
            get
            {
                return this.DataGrid.ParameterMJESECOBRACUNA;
            }
            set
            {
                this.DataGrid.ParameterMJESECOBRACUNA = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int ParameterSORT
        {
            get
            {
                return this.DataGrid.ParameterSORT;
            }
            set
            {
                this.DataGrid.ParameterSORT = value;
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

