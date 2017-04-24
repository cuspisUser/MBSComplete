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

    public class s_od_pripremaUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with s_od_priprema";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with s_od_priprema";
        private s_od_pripremaDataGrid userControlDataGrids_od_priprema;

        public s_od_pripremaUserDataGrid()
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
            this.userControlDataGrids_od_priprema = new s_od_pripremaDataGrid();
            ((ISupportInitialize) this.userControlDataGrids_od_priprema).BeginInit();
            UltraGridBand band = new UltraGridBand("s_od_priprema", -1);
            UltraGridColumn column8 = new UltraGridColumn("imeprezime");
            UltraGridColumn column13 = new UltraGridColumn("NAZIVRADNOMJESTO");
            UltraGridColumn column20 = new UltraGridColumn("osnovnaplaca");
            UltraGridColumn column33 = new UltraGridColumn("smjenskiiznos");
            UltraGridColumn column35 = new UltraGridColumn("smjenskisatnica");
            UltraGridColumn column34 = new UltraGridColumn("smjenskisati");
            UltraGridColumn column21 = new UltraGridColumn("posebni1iznos");
            UltraGridColumn column23 = new UltraGridColumn("posebni1satnica");
            UltraGridColumn column22 = new UltraGridColumn("posebni1sati");
            UltraGridColumn column24 = new UltraGridColumn("posebni2iznos");
            UltraGridColumn column26 = new UltraGridColumn("posebni2satnica");
            UltraGridColumn column25 = new UltraGridColumn("posebni2sati");
            UltraGridColumn column27 = new UltraGridColumn("posebni3iznos");
            UltraGridColumn column29 = new UltraGridColumn("posebni3satnica");
            UltraGridColumn column28 = new UltraGridColumn("posebni3sati");
            UltraGridColumn column18 = new UltraGridColumn("nocnisatnica");
            UltraGridColumn column19 = new UltraGridColumn("nocniuvecani");
            UltraGridColumn column17 = new UltraGridColumn("nocni");
            UltraGridColumn column31 = new UltraGridColumn("prekovremenisatnica");
            UltraGridColumn column32 = new UltraGridColumn("prekovremeniuvecani");
            UltraGridColumn column30 = new UltraGridColumn("prekovremeni");
            UltraGridColumn column37 = new UltraGridColumn("subotomsatnica");
            UltraGridColumn column38 = new UltraGridColumn("subotomuvecani");
            UltraGridColumn column36 = new UltraGridColumn("subotom");
            UltraGridColumn column15 = new UltraGridColumn("nedjeljomsatnica");
            UltraGridColumn column16 = new UltraGridColumn("nedjeljomuvecani");
            UltraGridColumn column14 = new UltraGridColumn("nedjeljom");
            UltraGridColumn column2 = new UltraGridColumn("blagdansatnica");
            UltraGridColumn column3 = new UltraGridColumn("blagdanuvecani");
            UltraGridColumn column = new UltraGridColumn("blagdan");
            UltraGridColumn column6 = new UltraGridColumn("dvokratnisatnica");
            UltraGridColumn column7 = new UltraGridColumn("dvokratniuvecani");
            UltraGridColumn column5 = new UltraGridColumn("dvokratni");
            UltraGridColumn column4 = new UltraGridColumn("DODATNIKOEFICIJENT");
            UltraGridColumn column9 = new UltraGridColumn("KOMBINACIJAIZNOS");
            UltraGridColumn column11 = new UltraGridColumn("KOMBINACIJAPOSTOTAK");
            UltraGridColumn column10 = new UltraGridColumn("KOMBINACIJAIZNOS2");
            UltraGridColumn column12 = new UltraGridColumn("KOMBINACIJAPOSTOTAK2");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.s_od_pripremaimeprezimeDescription;
            column8.Width = 0x128;
            column8.Format = "";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.s_od_pripremaNAZIVRADNOMJESTODescription;
            column13.Width = 0x128;
            column13.Format = "";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.s_od_pripremaosnovnaplacaDescription;
            column20.Width = 0x66;
            appearance20.TextHAlign = HAlign.Right;
            column20.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column20.PromptChar = ' ';
            column20.Format = "F2";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column33.CellActivation = Activation.NoEdit;
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.s_od_pripremasmjenskiiznosDescription;
            column33.Width = 0x6d;
            appearance33.TextHAlign = HAlign.Right;
            column33.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column33.PromptChar = ' ';
            column33.Format = "F2";
            column33.CellAppearance = appearance33;
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            column35.CellActivation = Activation.NoEdit;
            column35.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column35.Header.Caption = StringResources.s_od_pripremasmjenskisatnicaDescription;
            column35.Width = 0x7b;
            appearance35.TextHAlign = HAlign.Right;
            column35.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column35.PromptChar = ' ';
            column35.Format = "F2";
            column35.CellAppearance = appearance35;
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            column34.CellActivation = Activation.NoEdit;
            column34.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column34.Header.Caption = StringResources.s_od_pripremasmjenskisatiDescription;
            column34.Width = 0x66;
            appearance34.TextHAlign = HAlign.Right;
            column34.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column34.PromptChar = ' ';
            column34.Format = "F2";
            column34.CellAppearance = appearance34;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.s_od_pripremaposebni1iznosDescription;
            column21.Width = 0x6d;
            appearance21.TextHAlign = HAlign.Right;
            column21.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column21.PromptChar = ' ';
            column21.Format = "F2";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.s_od_pripremaposebni1satnicaDescription;
            column23.Width = 0x7b;
            appearance23.TextHAlign = HAlign.Right;
            column23.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column23.PromptChar = ' ';
            column23.Format = "F2";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.s_od_pripremaposebni1satiDescription;
            column22.Width = 0x66;
            appearance22.TextHAlign = HAlign.Right;
            column22.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column22.PromptChar = ' ';
            column22.Format = "F2";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.s_od_pripremaposebni2iznosDescription;
            column24.Width = 0x6d;
            appearance24.TextHAlign = HAlign.Right;
            column24.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column24.PromptChar = ' ';
            column24.Format = "F2";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.s_od_pripremaposebni2satnicaDescription;
            column26.Width = 0x7b;
            appearance26.TextHAlign = HAlign.Right;
            column26.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column26.PromptChar = ' ';
            column26.Format = "F2";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.s_od_pripremaposebni2satiDescription;
            column25.Width = 0x66;
            appearance25.TextHAlign = HAlign.Right;
            column25.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column25.PromptChar = ' ';
            column25.Format = "F2";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.NoEdit;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.s_od_pripremaposebni3iznosDescription;
            column27.Width = 0x6d;
            appearance27.TextHAlign = HAlign.Right;
            column27.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column27.PromptChar = ' ';
            column27.Format = "F2";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.NoEdit;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.s_od_pripremaposebni3satnicaDescription;
            column29.Width = 0x7b;
            appearance29.TextHAlign = HAlign.Right;
            column29.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column29.PromptChar = ' ';
            column29.Format = "F2";
            column29.CellAppearance = appearance29;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.NoEdit;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.s_od_pripremaposebni3satiDescription;
            column28.Width = 0x66;
            appearance28.TextHAlign = HAlign.Right;
            column28.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column28.PromptChar = ' ';
            column28.Format = "F2";
            column28.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.s_od_pripremanocnisatnicaDescription;
            column18.Width = 0x66;
            appearance18.TextHAlign = HAlign.Right;
            column18.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column18.PromptChar = ' ';
            column18.Format = "F2";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.s_od_pripremanocniuvecaniDescription;
            column19.Width = 0x66;
            appearance19.TextHAlign = HAlign.Right;
            column19.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column19.PromptChar = ' ';
            column19.Format = "F2";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.s_od_pripremanocniDescription;
            column17.Width = 0x66;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column17.PromptChar = ' ';
            column17.Format = "F2";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.NoEdit;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.s_od_pripremaprekovremenisatnicaDescription;
            column31.Width = 150;
            appearance31.TextHAlign = HAlign.Right;
            column31.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column31.PromptChar = ' ';
            column31.Format = "F2";
            column31.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column32.CellActivation = Activation.NoEdit;
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.s_od_pripremaprekovremeniuvecaniDescription;
            column32.Width = 150;
            appearance32.TextHAlign = HAlign.Right;
            column32.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column32.PromptChar = ' ';
            column32.Format = "F2";
            column32.CellAppearance = appearance32;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column30.CellActivation = Activation.NoEdit;
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.s_od_pripremaprekovremeniDescription;
            column30.Width = 0x66;
            appearance30.TextHAlign = HAlign.Right;
            column30.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column30.PromptChar = ' ';
            column30.Format = "F2";
            column30.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            column37.CellActivation = Activation.NoEdit;
            column37.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column37.Header.Caption = StringResources.s_od_pripremasubotomsatnicaDescription;
            column37.Width = 0x74;
            appearance37.TextHAlign = HAlign.Right;
            column37.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column37.PromptChar = ' ';
            column37.Format = "F2";
            column37.CellAppearance = appearance37;
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            column38.CellActivation = Activation.NoEdit;
            column38.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column38.Header.Caption = StringResources.s_od_pripremasubotomuvecaniDescription;
            column38.Width = 0x74;
            appearance38.TextHAlign = HAlign.Right;
            column38.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column38.PromptChar = ' ';
            column38.Format = "F2";
            column38.CellAppearance = appearance38;
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            column36.CellActivation = Activation.NoEdit;
            column36.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column36.Header.Caption = StringResources.s_od_pripremasubotomDescription;
            column36.Width = 0x66;
            appearance36.TextHAlign = HAlign.Right;
            column36.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column36.PromptChar = ' ';
            column36.Format = "F2";
            column36.CellAppearance = appearance36;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.s_od_pripremanedjeljomsatnicaDescription;
            column15.Width = 0x81;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.s_od_pripremanedjeljomuvecaniDescription;
            column16.Width = 0x81;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column16.PromptChar = ' ';
            column16.Format = "F2";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.s_od_pripremanedjeljomDescription;
            column14.Width = 0x66;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.s_od_pripremablagdansatnicaDescription;
            column2.Width = 0x74;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column2.PromptChar = ' ';
            column2.Format = "F2";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.s_od_pripremablagdanuvecaniDescription;
            column3.Width = 0x74;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column3.PromptChar = ' ';
            column3.Format = "F2";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.s_od_pripremablagdanDescription;
            column.Width = 0x66;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column.PromptChar = ' ';
            column.Format = "F2";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.s_od_pripremadvokratnisatnicaDescription;
            column6.Width = 0x81;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.s_od_pripremadvokratniuvecaniDescription;
            column7.Width = 0x81;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.s_od_pripremadvokratniDescription;
            column5.Width = 0x66;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.s_od_pripremaDODATNIKOEFICIJENTDescription;
            column4.Width = 0x8f;
            appearance4.TextHAlign = HAlign.Right;
            column4.MaskInput = "{LOC}-nnnn.nnnnnnnn";
            column4.PromptChar = ' ';
            column4.Format = "F8";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.s_od_pripremaKOMBINACIJAIZNOSDescription;
            column9.Width = 0x81;
            appearance10.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.s_od_pripremaKOMBINACIJAPOSTOTAKDescription;
            column11.Width = 150;
            appearance12.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.s_od_pripremaKOMBINACIJAIZNOS2Description;
            column10.Width = 0x8f;
            appearance9.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.s_od_pripremaKOMBINACIJAPOSTOTAK2Description;
            column12.Width = 0xa3;
            appearance11.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance11;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 0;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 1;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 2;
            band.Columns.Add(column33);
            column33.Header.VisiblePosition = 3;
            band.Columns.Add(column35);
            column35.Header.VisiblePosition = 4;
            band.Columns.Add(column34);
            column34.Header.VisiblePosition = 5;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 6;
            band.Columns.Add(column23);
            column23.Header.VisiblePosition = 7;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 8;
            band.Columns.Add(column24);
            column24.Header.VisiblePosition = 9;
            band.Columns.Add(column26);
            column26.Header.VisiblePosition = 10;
            band.Columns.Add(column25);
            column25.Header.VisiblePosition = 11;
            band.Columns.Add(column27);
            column27.Header.VisiblePosition = 12;
            band.Columns.Add(column29);
            column29.Header.VisiblePosition = 13;
            band.Columns.Add(column28);
            column28.Header.VisiblePosition = 14;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 15;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 0x10;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 0x11;
            band.Columns.Add(column31);
            column31.Header.VisiblePosition = 0x12;
            band.Columns.Add(column32);
            column32.Header.VisiblePosition = 0x13;
            band.Columns.Add(column30);
            column30.Header.VisiblePosition = 20;
            band.Columns.Add(column37);
            column37.Header.VisiblePosition = 0x15;
            band.Columns.Add(column38);
            column38.Header.VisiblePosition = 0x16;
            band.Columns.Add(column36);
            column36.Header.VisiblePosition = 0x17;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 0x18;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 0x19;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 0x1a;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 0x1b;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0x1c;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0x1d;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 30;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 0x1f;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 0x20;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 0x21;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 0x22;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 0x23;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 0x24;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 0x25;
            this.userControlDataGrids_od_priprema.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGrids_od_priprema.Location = point;
            this.userControlDataGrids_od_priprema.Name = "userControlDataGrids_od_priprema";
            this.userControlDataGrids_od_priprema.Tag = "s_od_priprema";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGrids_od_priprema.Size = size;
            this.userControlDataGrids_od_priprema.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGrids_od_priprema.Dock = DockStyle.Fill;
            this.userControlDataGrids_od_priprema.FillAtStartup = false;
            this.userControlDataGrids_od_priprema.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGrids_od_priprema.InitializeRow += new InitializeRowEventHandler(this.s_od_pripremaUserDataGrid_InitializeRow);
            this.userControlDataGrids_od_priprema.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGrids_od_priprema });
            this.Name = "s_od_pripremaUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.s_od_pripremaUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGrids_od_priprema).EndInit();
            this.ResumeLayout(false);
        }

        private void s_od_pripremaUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void s_od_pripremaUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual s_od_pripremaDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGrids_od_priprema;
            }
            set
            {
                this.userControlDataGrids_od_priprema = value;
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
        public virtual int Parametergodina
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
        public virtual int Parameterid
        {
            get
            {
                return this.DataGrid.Parameterid;
            }
            set
            {
                this.DataGrid.Parameterid = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int Parametermjesec
        {
            get
            {
                return this.DataGrid.Parametermjesec;
            }
            set
            {
                this.DataGrid.Parametermjesec = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual string Parametervrsta
        {
            get
            {
                return this.DataGrid.Parametervrsta;
            }
            set
            {
                this.DataGrid.Parametervrsta = value;
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

