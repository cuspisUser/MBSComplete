namespace NetAdvantage.SmartParts
{
    using Infragistics.Win;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.Practices.CompositeUI.SmartParts;
    using NetAdvantage.Controls;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class sp_id_zaglavljeUserDataGrid : UserControl, ISmartPartInfo
    {
        private IContainer components = null;
        private string m_Description = "Work with sp_id_zaglavlje";
        private bool m_FillAtStartup = true;
        private string m_Title = "Work with sp_id_zaglavlje";
        private sp_id_zaglavljeDataGrid userControlDataGridsp_id_zaglavlje;

        public sp_id_zaglavljeUserDataGrid()
        {
            this.InitializeComponent();
        }

        private static void CreateValueList(UltraGrid dataGrid1, string valueListName, System.Data.DataView dataList, string Id, string Name)
        {
            ValueList list = null;
            if (dataGrid1.DisplayLayout.ValueLists.Exists(valueListName) && (dataGrid1.DisplayLayout.ValueLists[valueListName].ValueListItems.Count != dataList.Count))
            {
                dataGrid1.DisplayLayout.ValueLists.Remove(valueListName);
                list = dataGrid1.DisplayLayout.ValueLists.Add(valueListName);
            }
            if (!dataGrid1.DisplayLayout.ValueLists.Exists(valueListName))
            {
                list = dataGrid1.DisplayLayout.ValueLists.Add(valueListName);
            }
            if (list != null)
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = dataList.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRowView current = (DataRowView) enumerator.Current;
                        DataRow row = current.Row;
                        ValueListItem item = new ValueListItem {
                            DataValue = RuntimeHelpers.GetObjectValue(row[Id]),
                            DisplayText = row[Name].ToString()
                        };
                        list.ValueListItems.Add(item);
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                list.Tag = dataList;
            }
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
            this.SetComboBoxColumnProperties(false);
            this.DataGrid.Fill();
        }

        private void InitializeComponent()
        {
            this.userControlDataGridsp_id_zaglavlje = new sp_id_zaglavljeDataGrid();
            ((ISupportInitialize) this.userControlDataGridsp_id_zaglavlje).BeginInit();
            UltraGridBand band = new UltraGridBand("sp_id_zaglavlje", -1);
            UltraGridColumn column3 = new UltraGridColumn("ididobrasca");
            UltraGridColumn column5 = new UltraGridColumn("nazivfirme");
            UltraGridColumn column6 = new UltraGridColumn("punaadresa");
            UltraGridColumn column4 = new UltraGridColumn("maticnibroj");
            UltraGridColumn column2 = new UltraGridColumn("idenTIFIKATOR");
            UltraGridColumn column7 = new UltraGridColumn("REDAK_II_1");
            UltraGridColumn column8 = new UltraGridColumn("REDAK_II_2");
            UltraGridColumn column9 = new UltraGridColumn("REDAK_II_2_1");
            UltraGridColumn column10 = new UltraGridColumn("REDAK_II_2_1_1");
            UltraGridColumn column11 = new UltraGridColumn("REDAK_II_2_1_2");
            UltraGridColumn column12 = new UltraGridColumn("REDAK_II_2_1_3");
            UltraGridColumn column13 = new UltraGridColumn("REDAK_II_2_2");
            UltraGridColumn column14 = new UltraGridColumn("REDAK_II_2_2_1");
            UltraGridColumn column15 = new UltraGridColumn("REDAK_II_2_2_2");
            UltraGridColumn column16 = new UltraGridColumn("REDAK_II_2_2_3");
            UltraGridColumn column17 = new UltraGridColumn("REDAK_II_3");
            UltraGridColumn column18 = new UltraGridColumn("REDAK_II_4");
            UltraGridColumn column19 = new UltraGridColumn("REDAK_II_5");
            UltraGridColumn column20 = new UltraGridColumn("REDAK_II_6");
            UltraGridColumn column21 = new UltraGridColumn("REDAK_II_6_1");
            UltraGridColumn column22 = new UltraGridColumn("REDAK_II_6_2");
            UltraGridColumn column23 = new UltraGridColumn("REDAK_II_7");
            UltraGridColumn column24 = new UltraGridColumn("REDAK_II_8");
            UltraGridColumn column25 = new UltraGridColumn("REDAK_III_1_1");
            UltraGridColumn column26 = new UltraGridColumn("REDAK_III_1_2");
            UltraGridColumn column27 = new UltraGridColumn("REDAK_III_2_1");
            UltraGridColumn column28 = new UltraGridColumn("REDAK_III_2_2");
            UltraGridColumn column29 = new UltraGridColumn("REDAK_III_3_1");
            UltraGridColumn column30 = new UltraGridColumn("REDAK_III_3_2");
            UltraGridColumn column31 = new UltraGridColumn("REDAK_III_3_3");
            UltraGridColumn column32 = new UltraGridColumn("REDAK_III_4_1");
            UltraGridColumn column33 = new UltraGridColumn("REDAK_III_4_2");
            UltraGridColumn column34 = new UltraGridColumn("REDAK_III_5");
            UltraGridColumn column = new UltraGridColumn("DATUMSASTAVLJANJA");
            this.SuspendLayout();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            column3.CellActivation = Activation.NoEdit;
            column3.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column3.Header.Caption = StringResources.sp_id_zaglavljeididobrascaDescription;
            column3.Width = 0x5c;
            appearance3.TextHAlign = HAlign.Right;
            column3.MaskInput = "{LOC}-nnnnn";
            column3.PromptChar = ' ';
            column3.Format = "";
            column3.CellAppearance = appearance3;
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            column5.CellActivation = Activation.NoEdit;
            column5.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column5.Header.Caption = StringResources.sp_id_zaglavljenazivfirmeDescription;
            column5.Width = 0x128;
            column5.Format = "";
            column5.CellAppearance = appearance5;
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            column6.CellActivation = Activation.NoEdit;
            column6.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column6.Header.Caption = StringResources.sp_id_zaglavljepunaadresaDescription;
            column6.Width = 0x128;
            column6.Format = "";
            column6.CellAppearance = appearance6;
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            column4.CellActivation = Activation.NoEdit;
            column4.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column4.Header.Caption = StringResources.sp_id_zaglavljematicnibrojDescription;
            column4.Width = 0x6b;
            column4.Format = "";
            column4.CellAppearance = appearance4;
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            column2.CellActivation = Activation.NoEdit;
            column2.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column2.Header.Caption = StringResources.sp_id_zaglavljeidenTIFIKATORDescription;
            column2.Width = 0x72;
            column2.Format = "";
            column2.CellAppearance = appearance2;
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            column7.CellActivation = Activation.NoEdit;
            column7.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column7.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_1Description;
            column7.Width = 0x66;
            appearance7.TextHAlign = HAlign.Right;
            column7.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column7.PromptChar = ' ';
            column7.Format = "F2";
            column7.CellAppearance = appearance7;
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            column8.CellActivation = Activation.NoEdit;
            column8.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column8.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_2Description;
            column8.Width = 0x66;
            appearance16.TextHAlign = HAlign.Right;
            column8.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column8.PromptChar = ' ';
            column8.Format = "F2";
            column8.CellAppearance = appearance16;
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            column9.CellActivation = Activation.NoEdit;
            column9.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column9.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_2_1Description;
            column9.Width = 0x74;
            appearance11.TextHAlign = HAlign.Right;
            column9.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column9.PromptChar = ' ';
            column9.Format = "F2";
            column9.CellAppearance = appearance11;
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            column10.CellActivation = Activation.NoEdit;
            column10.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column10.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_2_1_1Description;
            column10.Width = 0x81;
            appearance8.TextHAlign = HAlign.Right;
            column10.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column10.PromptChar = ' ';
            column10.Format = "F2";
            column10.CellAppearance = appearance8;
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            column11.CellActivation = Activation.NoEdit;
            column11.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column11.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_2_1_2Description;
            column11.Width = 0x81;
            appearance9.TextHAlign = HAlign.Right;
            column11.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column11.PromptChar = ' ';
            column11.Format = "F2";
            column11.CellAppearance = appearance9;
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            column12.CellActivation = Activation.NoEdit;
            column12.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column12.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_2_1_3Description;
            column12.Width = 0x81;
            appearance10.TextHAlign = HAlign.Right;
            column12.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column12.PromptChar = ' ';
            column12.Format = "F2";
            column12.CellAppearance = appearance10;
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            column13.CellActivation = Activation.NoEdit;
            column13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column13.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_2_2Description;
            column13.Width = 0x74;
            appearance15.TextHAlign = HAlign.Right;
            column13.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column13.PromptChar = ' ';
            column13.Format = "F2";
            column13.CellAppearance = appearance15;
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            column14.CellActivation = Activation.NoEdit;
            column14.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column14.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_2_2_1Description;
            column14.Width = 0x81;
            appearance12.TextHAlign = HAlign.Right;
            column14.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column14.PromptChar = ' ';
            column14.Format = "F2";
            column14.CellAppearance = appearance12;
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            column15.CellActivation = Activation.NoEdit;
            column15.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column15.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_2_2_2Description;
            column15.Width = 0x81;
            appearance13.TextHAlign = HAlign.Right;
            column15.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column15.PromptChar = ' ';
            column15.Format = "F2";
            column15.CellAppearance = appearance13;
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            column16.CellActivation = Activation.NoEdit;
            column16.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column16.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_2_2_3Description;
            column16.Width = 0x81;
            appearance14.TextHAlign = HAlign.Right;
            column16.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column16.PromptChar = ' ';
            column16.Format = "F2";
            column16.CellAppearance = appearance14;
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            column17.CellActivation = Activation.NoEdit;
            column17.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column17.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_3Description;
            column17.Width = 0x66;
            appearance17.TextHAlign = HAlign.Right;
            column17.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column17.PromptChar = ' ';
            column17.Format = "F2";
            column17.CellAppearance = appearance17;
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            column18.CellActivation = Activation.NoEdit;
            column18.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column18.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_4Description;
            column18.Width = 0x66;
            appearance18.TextHAlign = HAlign.Right;
            column18.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column18.PromptChar = ' ';
            column18.Format = "F2";
            column18.CellAppearance = appearance18;
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            column19.CellActivation = Activation.NoEdit;
            column19.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column19.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_5Description;
            column19.Width = 0x66;
            appearance19.TextHAlign = HAlign.Right;
            column19.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column19.PromptChar = ' ';
            column19.Format = "F2";
            column19.CellAppearance = appearance19;
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            column20.CellActivation = Activation.NoEdit;
            column20.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column20.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_6Description;
            column20.Width = 0x66;
            appearance22.TextHAlign = HAlign.Right;
            column20.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column20.PromptChar = ' ';
            column20.Format = "F2";
            column20.CellAppearance = appearance22;
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            column21.CellActivation = Activation.NoEdit;
            column21.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column21.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_6_1Description;
            column21.Width = 0x74;
            appearance20.TextHAlign = HAlign.Right;
            column21.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column21.PromptChar = ' ';
            column21.Format = "F2";
            column21.CellAppearance = appearance20;
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            column22.CellActivation = Activation.NoEdit;
            column22.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column22.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_6_2Description;
            column22.Width = 0x74;
            appearance21.TextHAlign = HAlign.Right;
            column22.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column22.PromptChar = ' ';
            column22.Format = "F2";
            column22.CellAppearance = appearance21;
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            column23.CellActivation = Activation.NoEdit;
            column23.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column23.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_7Description;
            column23.Width = 0x66;
            appearance23.TextHAlign = HAlign.Right;
            column23.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column23.PromptChar = ' ';
            column23.Format = "F2";
            column23.CellAppearance = appearance23;
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            column24.CellActivation = Activation.NoEdit;
            column24.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column24.Header.Caption = StringResources.sp_id_zaglavljeREDAK_II_8Description;
            column24.Width = 0x66;
            appearance24.TextHAlign = HAlign.Right;
            column24.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column24.PromptChar = ' ';
            column24.Format = "F2";
            column24.CellAppearance = appearance24;
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            column25.CellActivation = Activation.NoEdit;
            column25.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column25.Header.Caption = StringResources.sp_id_zaglavljeREDAK_III_1_1Description;
            column25.Width = 0x7b;
            appearance25.TextHAlign = HAlign.Right;
            column25.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column25.PromptChar = ' ';
            column25.Format = "F2";
            column25.CellAppearance = appearance25;
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            column26.CellActivation = Activation.NoEdit;
            column26.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column26.Header.Caption = StringResources.sp_id_zaglavljeREDAK_III_1_2Description;
            column26.Width = 0x7b;
            appearance26.TextHAlign = HAlign.Right;
            column26.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column26.PromptChar = ' ';
            column26.Format = "F2";
            column26.CellAppearance = appearance26;
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            column27.CellActivation = Activation.NoEdit;
            column27.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column27.Header.Caption = StringResources.sp_id_zaglavljeREDAK_III_2_1Description;
            column27.Width = 0x7b;
            appearance27.TextHAlign = HAlign.Right;
            column27.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column27.PromptChar = ' ';
            column27.Format = "F2";
            column27.CellAppearance = appearance27;
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            column28.CellActivation = Activation.NoEdit;
            column28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column28.Header.Caption = StringResources.sp_id_zaglavljeREDAK_III_2_2Description;
            column28.Width = 0x7b;
            appearance28.TextHAlign = HAlign.Right;
            column28.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column28.PromptChar = ' ';
            column28.Format = "F2";
            column28.CellAppearance = appearance28;
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            column29.CellActivation = Activation.NoEdit;
            column29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column29.Header.Caption = StringResources.sp_id_zaglavljeREDAK_III_3_1Description;
            column29.Width = 0x7b;
            appearance29.TextHAlign = HAlign.Right;
            column29.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column29.PromptChar = ' ';
            column29.Format = "F2";
            column29.CellAppearance = appearance29;
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            column30.CellActivation = Activation.NoEdit;
            column30.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column30.Header.Caption = StringResources.sp_id_zaglavljeREDAK_III_3_2Description;
            column30.Width = 0x7b;
            appearance30.TextHAlign = HAlign.Right;
            column30.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column30.PromptChar = ' ';
            column30.Format = "F2";
            column30.CellAppearance = appearance30;
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            column31.CellActivation = Activation.NoEdit;
            column31.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column31.Header.Caption = StringResources.sp_id_zaglavljeREDAK_III_3_3Description;
            column31.Width = 0x7b;
            appearance31.TextHAlign = HAlign.Right;
            column31.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column31.PromptChar = ' ';
            column31.Format = "F2";
            column31.CellAppearance = appearance31;
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            column32.CellActivation = Activation.NoEdit;
            column32.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column32.Header.Caption = StringResources.sp_id_zaglavljeREDAK_III_4_1Description;
            column32.Width = 0x7b;
            appearance32.TextHAlign = HAlign.Right;
            column32.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column32.PromptChar = ' ';
            column32.Format = "F2";
            column32.CellAppearance = appearance32;
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            column33.CellActivation = Activation.NoEdit;
            column33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column33.Header.Caption = StringResources.sp_id_zaglavljeREDAK_III_4_2Description;
            column33.Width = 0x7b;
            appearance33.TextHAlign = HAlign.Right;
            column33.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column33.PromptChar = ' ';
            column33.Format = "F2";
            column33.CellAppearance = appearance33;
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            column34.CellActivation = Activation.NoEdit;
            column34.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column34.Header.Caption = StringResources.sp_id_zaglavljeREDAK_III_5Description;
            column34.Width = 0x6d;
            appearance34.TextHAlign = HAlign.Right;
            column34.MaskInput = "{LOC}-nnnnnnnnnn.nn";
            column34.PromptChar = ' ';
            column34.Format = "F2";
            column34.CellAppearance = appearance34;
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            column.CellActivation = Activation.NoEdit;
            column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.OnCellActivate;
            column.Header.Caption = StringResources.sp_id_zaglavljeDATUMSASTAVLJANJADescription;
            column.Width = 0x87;
            column.MinValue = DateTime.MinValue;
            column.MaxValue = DateTime.MaxValue;
            column.Format = "d";
            column.CellAppearance = appearance;
            band.Columns.Add(column3);
            column3.Header.VisiblePosition = 0;
            band.Columns.Add(column5);
            column5.Header.VisiblePosition = 1;
            band.Columns.Add(column6);
            column6.Header.VisiblePosition = 2;
            band.Columns.Add(column4);
            column4.Header.VisiblePosition = 3;
            band.Columns.Add(column2);
            column2.Header.VisiblePosition = 4;
            band.Columns.Add(column7);
            column7.Header.VisiblePosition = 5;
            band.Columns.Add(column8);
            column8.Header.VisiblePosition = 6;
            band.Columns.Add(column9);
            column9.Header.VisiblePosition = 7;
            band.Columns.Add(column10);
            column10.Header.VisiblePosition = 8;
            band.Columns.Add(column11);
            column11.Header.VisiblePosition = 9;
            band.Columns.Add(column12);
            column12.Header.VisiblePosition = 10;
            band.Columns.Add(column13);
            column13.Header.VisiblePosition = 11;
            band.Columns.Add(column14);
            column14.Header.VisiblePosition = 12;
            band.Columns.Add(column15);
            column15.Header.VisiblePosition = 13;
            band.Columns.Add(column16);
            column16.Header.VisiblePosition = 14;
            band.Columns.Add(column17);
            column17.Header.VisiblePosition = 15;
            band.Columns.Add(column18);
            column18.Header.VisiblePosition = 0x10;
            band.Columns.Add(column19);
            column19.Header.VisiblePosition = 0x11;
            band.Columns.Add(column20);
            column20.Header.VisiblePosition = 0x12;
            band.Columns.Add(column21);
            column21.Header.VisiblePosition = 0x13;
            band.Columns.Add(column22);
            column22.Header.VisiblePosition = 20;
            band.Columns.Add(column23);
            column23.Header.VisiblePosition = 0x15;
            band.Columns.Add(column24);
            column24.Header.VisiblePosition = 0x16;
            band.Columns.Add(column25);
            column25.Header.VisiblePosition = 0x17;
            band.Columns.Add(column26);
            column26.Header.VisiblePosition = 0x18;
            band.Columns.Add(column27);
            column27.Header.VisiblePosition = 0x19;
            band.Columns.Add(column28);
            column28.Header.VisiblePosition = 0x1a;
            band.Columns.Add(column29);
            column29.Header.VisiblePosition = 0x1b;
            band.Columns.Add(column30);
            column30.Header.VisiblePosition = 0x1c;
            band.Columns.Add(column31);
            column31.Header.VisiblePosition = 0x1d;
            band.Columns.Add(column32);
            column32.Header.VisiblePosition = 30;
            band.Columns.Add(column33);
            column33.Header.VisiblePosition = 0x1f;
            band.Columns.Add(column34);
            column34.Header.VisiblePosition = 0x20;
            band.Columns.Add(column);
            column.Header.VisiblePosition = 0x21;
            this.userControlDataGridsp_id_zaglavlje.Visible = true;
            System.Drawing.Point point = new System.Drawing.Point(0, 0);
            this.userControlDataGridsp_id_zaglavlje.Location = point;
            this.userControlDataGridsp_id_zaglavlje.Name = "userControlDataGridsp_id_zaglavlje";
            this.userControlDataGridsp_id_zaglavlje.Tag = "sp_id_zaglavlje";
            Size size = new System.Drawing.Size(0x200, 0x144);
            this.userControlDataGridsp_id_zaglavlje.Size = size;
            this.userControlDataGridsp_id_zaglavlje.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            this.userControlDataGridsp_id_zaglavlje.Dock = DockStyle.Fill;
            this.userControlDataGridsp_id_zaglavlje.FillAtStartup = false;
            this.userControlDataGridsp_id_zaglavlje.DisplayLayout.Appearance.TextHAlign = HAlign.Left;
            this.userControlDataGridsp_id_zaglavlje.InitializeRow += new InitializeRowEventHandler(this.sp_id_zaglavljeUserDataGrid_InitializeRow);
            this.userControlDataGridsp_id_zaglavlje.DisplayLayout.BandsSerializer.Add(band);
            this.Controls.AddRange(new Control[] { this.userControlDataGridsp_id_zaglavlje });
            this.Name = "sp_id_zaglavljeUserDataGrid";
            size = new System.Drawing.Size(0x200, 0x144);
            this.Size = size;
            this.Load += new EventHandler(this.sp_id_zaglavljeUserDataGrid_Load);
            ((ISupportInitialize) this.userControlDataGridsp_id_zaglavlje).EndInit();
            this.ResumeLayout(false);
        }

        private void SetComboBoxColumnProperties(bool setColumnsWidth)
        {
        }

        private void sp_id_zaglavljeUserDataGrid_InitializeRow(object sender, InitializeRowEventArgs e)
        {
        }

        private void sp_id_zaglavljeUserDataGrid_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.SetComboBoxColumnProperties(true);
                if (this.FillAtStartup)
                {
                    this.DataGrid.Fill();
                }
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
        public virtual sp_id_zaglavljeDataGrid DataGrid
        {
            get
            {
                return this.userControlDataGridsp_id_zaglavlje;
            }
            set
            {
                this.userControlDataGridsp_id_zaglavlje = value;
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
        public virtual string ParameterGODINAISPLATE
        {
            get
            {
                return this.DataGrid.ParameterGODINAISPLATE;
            }
            set
            {
                this.DataGrid.ParameterGODINAISPLATE = value;
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
        public virtual string ParameterMJESECISPLATE
        {
            get
            {
                return this.DataGrid.ParameterMJESECISPLATE;
            }
            set
            {
                this.DataGrid.ParameterMJESECISPLATE = value;
            }
        }

        [Category("DeKlarit Data Provider Parameters")]
        public virtual short ParameterVOLONTERI
        {
            get
            {
                return this.DataGrid.ParameterVOLONTERI;
            }
            set
            {
                this.DataGrid.ParameterVOLONTERI = value;
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

