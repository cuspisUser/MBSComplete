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

    public class sp_maticni_kartonUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with sp_maticni_karton";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with sp_maticni_karton";
        private sp_maticni_kartonDataGrid userControlDataGridsp_maticni_karton;

        public sp_maticni_kartonUserDataGrid()
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
            this.userControlDataGridsp_maticni_karton = new sp_maticni_kartonDataGrid();
            ((ISupportInitialize) this.userControlDataGridsp_maticni_karton).BeginInit();
            UltraGridBand band = new UltraGridBand("sp_maticni_karton", -1);
            UltraGridColumn column32 = new UltraGridColumn("tip");
            UltraGridColumn column18 = new UltraGridColumn("opistip");
            UltraGridColumn column35 = new UltraGridColumn("vrstavrij");
            UltraGridColumn column2 = new UltraGridColumn("IDRADNIK");
            UltraGridColumn column19 = new UltraGridColumn("PREZIME");
            UltraGridColumn column3 = new UltraGridColumn("IME");
            UltraGridColumn column4 = new UltraGridColumn("JMBG");
            UltraGridColumn column = new UltraGridColumn("idpodatka");
            UltraGridColumn column17 = new UltraGridColumn("nazivpodatka");
            UltraGridColumn column5 = new UltraGridColumn("mj01");
            UltraGridColumn column6 = new UltraGridColumn("mj02");
            UltraGridColumn column7 = new UltraGridColumn("mj03");
            UltraGridColumn column8 = new UltraGridColumn("mj04");
            UltraGridColumn column9 = new UltraGridColumn("mj05");
            UltraGridColumn column10 = new UltraGridColumn("mj06");
            UltraGridColumn column11 = new UltraGridColumn("mj07");
            UltraGridColumn column12 = new UltraGridColumn("mj08");
            UltraGridColumn column13 = new UltraGridColumn("mj09");
            UltraGridColumn column14 = new UltraGridColumn("mj10");
            UltraGridColumn column15 = new UltraGridColumn("mj11");
            UltraGridColumn column16 = new UltraGridColumn("mj12");
            UltraGridColumn column33 = new UltraGridColumn("UKUPNO");
            UltraGridColumn column20 = new UltraGridColumn("sati01");
            UltraGridColumn column21 = new UltraGridColumn("sati02");
            UltraGridColumn column22 = new UltraGridColumn("sati03");
            UltraGridColumn column23 = new UltraGridColumn("sati04");
            UltraGridColumn column24 = new UltraGridColumn("sati05");
            UltraGridColumn column25 = new UltraGridColumn("sati06");
            UltraGridColumn column26 = new UltraGridColumn("sati07");
            UltraGridColumn column27 = new UltraGridColumn("sati08");
            UltraGridColumn column28 = new UltraGridColumn("sati09");
            UltraGridColumn column29 = new UltraGridColumn("sati10");
            UltraGridColumn column30 = new UltraGridColumn("sati11");
            UltraGridColumn column31 = new UltraGridColumn("sati12");
            UltraGridColumn column34 = new UltraGridColumn("ukupnosati");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column32.CellActivation = Activation.NoEdit;
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.sp_maticni_kartontipDescription;
            column32.Width = 0x33;
            appearance32.TextHAlign = HAlign.Right;
            column32.MaskInput = "{LOC}-nnnnn";
            column32.PromptChar = ' ';
            column32.Format = "";
            column32.CellAppearance = appearance32;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.sp_maticni_kartonopistipDescription;
            column18.Width = 0x128;
            column18.Format = "";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            column35.CellActivation = Activation.NoEdit;
            column35.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column35.Header.Caption = StringResources.sp_maticni_kartonvrstavrijDescription;
            column35.Width = 0x4e;
            appearance35.TextHAlign = HAlign.Right;
            column35.MaskInput = "{LOC}-nnnnn";
            column35.PromptChar = ' ';
            column35.Format = "";
            column35.CellAppearance = appearance35;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.sp_maticni_kartonIDRADNIKDescription;
            column2.Width = 0x69;
            appearance2.TextHAlign = HAlign.Right;
            column2.MaskInput = "{LOC}-nnnnnnnn";
            column2.PromptChar = ' ';
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.sp_maticni_kartonPREZIMEDescription;
            column19.Width = 0x128;
            column19.Format = "";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.sp_maticni_kartonIMEDescription;
            column3.Width = 0x128;
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.sp_maticni_kartonJMBGDescription;
            column4.Width = 0x6b;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.sp_maticni_kartonidpodatkaDescription;
            column.Width = 0x4e;
            appearance.TextHAlign = HAlign.Right;
            column.MaskInput = "{LOC}-nnnnn";
            column.PromptChar = ' ';
            column.Format = "";
            column.CellAppearance = appearance;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.sp_maticni_kartonnazivpodatkaDescription;
            column17.Width = 0x128;
            column17.Format = "";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.sp_maticni_kartonmj01Description;
            column5.Width = 0x66;
            appearance5.TextHAlign = HAlign.Right;
            column5.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column5.PromptChar = ' ';
            column5.Format = "F2";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.sp_maticni_kartonmj02Description;
            column6.Width = 0x66;
            appearance6.TextHAlign = HAlign.Right;
            column6.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column6.PromptChar = ' ';
            column6.Format = "F2";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.sp_maticni_kartonmj03Description;
            column7.Width = 0x66;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.sp_maticni_kartonmj04Description;
            column8.Width = 0x66;
            appearance8.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.sp_maticni_kartonmj05Description;
            column9.Width = 0x66;
            appearance9.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.sp_maticni_kartonmj06Description;
            column10.Width = 0x66;
            appearance10.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.sp_maticni_kartonmj07Description;
            column11.Width = 0x66;
            appearance11.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.sp_maticni_kartonmj08Description;
            column12.Width = 0x66;
            appearance12.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.sp_maticni_kartonmj09Description;
            column13.Width = 0x66;
            appearance13.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.sp_maticni_kartonmj10Description;
            column14.Width = 0x66;
            appearance14.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.sp_maticni_kartonmj11Description;
            column15.Width = 0x66;
            appearance15.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.sp_maticni_kartonmj12Description;
            column16.Width = 0x66;
            appearance16.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column16.PromptChar = ' ';
            column16.Format = "F2";
            column16.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column33.CellActivation = Activation.NoEdit;
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.sp_maticni_kartonUKUPNODescription;
            column33.Width = 0x4b;
            appearance33.TextHAlign = HAlign.Right;
            column33.MaskInput = "{LOC}-nnnnnn.nn";
            column33.PromptChar = ' ';
            column33.Format = "F2";
            column33.CellAppearance = appearance33;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.sp_maticni_kartonsati01Description;
            column20.Width = 0x66;
            appearance20.TextHAlign = HAlign.Right;
            column20.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column20.PromptChar = ' ';
            column20.Format = "F2";
            column20.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.sp_maticni_kartonsati02Description;
            column21.Width = 0x66;
            appearance21.TextHAlign = HAlign.Right;
            column21.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column21.PromptChar = ' ';
            column21.Format = "F2";
            column21.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.sp_maticni_kartonsati03Description;
            column22.Width = 0x66;
            appearance22.TextHAlign = HAlign.Right;
            column22.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column22.PromptChar = ' ';
            column22.Format = "F2";
            column22.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.sp_maticni_kartonsati04Description;
            column23.Width = 0x66;
            appearance23.TextHAlign = HAlign.Right;
            column23.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column23.PromptChar = ' ';
            column23.Format = "F2";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.sp_maticni_kartonsati05Description;
            column24.Width = 0x66;
            appearance24.TextHAlign = HAlign.Right;
            column24.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column24.PromptChar = ' ';
            column24.Format = "F2";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.sp_maticni_kartonsati06Description;
            column25.Width = 0x66;
            appearance25.TextHAlign = HAlign.Right;
            column25.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column25.PromptChar = ' ';
            column25.Format = "F2";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.sp_maticni_kartonsati07Description;
            column26.Width = 0x66;
            appearance26.TextHAlign = HAlign.Right;
            column26.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column26.PromptChar = ' ';
            column26.Format = "F2";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.NoEdit;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.sp_maticni_kartonsati08Description;
            column27.Width = 0x66;
            appearance27.TextHAlign = HAlign.Right;
            column27.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column27.PromptChar = ' ';
            column27.Format = "F2";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.NoEdit;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.sp_maticni_kartonsati09Description;
            column28.Width = 0x66;
            appearance28.TextHAlign = HAlign.Right;
            column28.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column28.PromptChar = ' ';
            column28.Format = "F2";
            column28.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.NoEdit;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.sp_maticni_kartonsati10Description;
            column29.Width = 0x66;
            appearance29.TextHAlign = HAlign.Right;
            column29.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column29.PromptChar = ' ';
            column29.Format = "F2";
            column29.CellAppearance = appearance29;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column30.CellActivation = Activation.NoEdit;
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.sp_maticni_kartonsati11Description;
            column30.Width = 0x66;
            appearance30.TextHAlign = HAlign.Right;
            column30.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column30.PromptChar = ' ';
            column30.Format = "F2";
            column30.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.NoEdit;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.sp_maticni_kartonsati12Description;
            column31.Width = 0x66;
            appearance31.TextHAlign = HAlign.Right;
            column31.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column31.PromptChar = ' ';
            column31.Format = "F2";
            column31.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            column34.CellActivation = Activation.NoEdit;
            column34.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column34.Header.Caption = StringResources.sp_maticni_kartonukupnosatiDescription;
            column34.Width = 0x66;
            appearance34.TextHAlign = HAlign.Right;
            column34.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column34.PromptChar = ' ';
            column34.Format = "F2";
            column34.CellAppearance = appearance34;
            band.Columns.Add(column32);
            column32.Header.VisiblePosition = 0;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 1;
            band.Columns.Add(column35);
            column35.Header.VisiblePosition = 2;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 3;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 4;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 5;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 6;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 7;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 8;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 9;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 10;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 11;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 12;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 13;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 14;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 15;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 0x10;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 0x11;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 0x12;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 0x13;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 20;
            band.Columns.Add(column33);
            column33.Header.VisiblePosition = 0x15;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 0x16;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 0x17;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 0x18;
            band.Columns.Add(column23);
            column23.Header.VisiblePosition = 0x19;
            band.Columns.Add(column24);
            column24.Header.VisiblePosition = 0x1a;
            band.Columns.Add(column25);
            column25.Header.VisiblePosition = 0x1b;
            band.Columns.Add(column26);
            column26.Header.VisiblePosition = 0x1c;
            band.Columns.Add(column27);
            column27.Header.VisiblePosition = 0x1d;
            band.Columns.Add(column28);
            column28.Header.VisiblePosition = 30;
            band.Columns.Add(column29);
            column29.Header.VisiblePosition = 0x1f;
            band.Columns.Add(column30);
            column30.Header.VisiblePosition = 0x20;
            band.Columns.Add(column31);
            column31.Header.VisiblePosition = 0x21;
            band.Columns.Add(column34);
            column34.Header.VisiblePosition = 0x22;
            this.userControlDataGridsp_maticni_karton.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridsp_maticni_karton.Location = point;
            this.userControlDataGridsp_maticni_karton.Name = "userControlDataGridsp_maticni_karton";
            this.userControlDataGridsp_maticni_karton.Tag = "sp_maticni_karton";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridsp_maticni_karton.Size = size;
            this.userControlDataGridsp_maticni_karton.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridsp_maticni_karton.Dock = DockStyle.Fill;
            this.userControlDataGridsp_maticni_karton.FillAtStartup = false;
            this.userControlDataGridsp_maticni_karton.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridsp_maticni_karton.InitializeRow += new InitializeRowEventHandler(this.sp_maticni_kartonUserDataGrid_InitializeRow);
            this.userControlDataGridsp_maticni_karton.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridsp_maticni_karton });
            this.Name = "sp_maticni_kartonUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.sp_maticni_kartonUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridsp_maticni_karton).EndInit();
            this.ResumeLayout(false);
        }

        private void sp_maticni_kartonUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void sp_maticni_kartonUserDataGrid_Load(object sender, EventArgs e)
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
        public virtual sp_maticni_kartonDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridsp_maticni_karton;
            }
            set
            {
                this.userControlDataGridsp_maticni_karton = value;
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
        public virtual int Parameteridradnik_do
        {
            get
            {
                return this.DataGrid.Parameteridradnik_do;
            }
            set
            {
                this.DataGrid.Parameteridradnik_do = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual int Parameteridradnik_od
        {
            get
            {
                return this.DataGrid.Parameteridradnik_od;
            }
            set
            {
                this.DataGrid.Parameteridradnik_od = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenobruto
        {
            get
            {
                return this.DataGrid.Parameterukljucenobruto;
            }
            set
            {
                this.DataGrid.Parameterukljucenobruto = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenodoprinosiiz
        {
            get
            {
                return this.DataGrid.Parameterukljucenodoprinosiiz;
            }
            set
            {
                this.DataGrid.Parameterukljucenodoprinosiiz = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenodoprinosina
        {
            get
            {
                return this.DataGrid.Parameterukljucenodoprinosina;
            }
            set
            {
                this.DataGrid.Parameterukljucenodoprinosina = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenoisplata
        {
            get
            {
                return this.DataGrid.Parameterukljucenoisplata;
            }
            set
            {
                this.DataGrid.Parameterukljucenoisplata = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenonetonaknade
        {
            get
            {
                return this.DataGrid.Parameterukljucenonetonaknade;
            }
            set
            {
                this.DataGrid.Parameterukljucenonetonaknade = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenonetoplaca
        {
            get
            {
                return this.DataGrid.Parameterukljucenonetoplaca;
            }
            set
            {
                this.DataGrid.Parameterukljucenonetoplaca = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenoobustave
        {
            get
            {
                return this.DataGrid.Parameterukljucenoobustave;
            }
            set
            {
                this.DataGrid.Parameterukljucenoobustave = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenoolaksice
        {
            get
            {
                return this.DataGrid.Parameterukljucenoolaksice;
            }
            set
            {
                this.DataGrid.Parameterukljucenoolaksice = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenooo
        {
            get
            {
                return this.DataGrid.Parameterukljucenooo;
            }
            set
            {
                this.DataGrid.Parameterukljucenooo = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterukljucenoporezi
        {
            get
            {
                return this.DataGrid.Parameterukljucenoporezi;
            }
            set
            {
                this.DataGrid.Parameterukljucenoporezi = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual bool Parameterzbirni
        {
            get
            {
                return this.DataGrid.Parameterzbirni;
            }
            set
            {
                this.DataGrid.Parameterzbirni = value;
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

