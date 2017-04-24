
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using NetAdvantage.Controllers;
using Placa;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


namespace DDModule.DDModule
{

    [SmartPart]
    public class PregledTemeljnice : UserControl
    {
        public int godina;
        
        public int mjesec;

        public PregledTemeljnice()
        {
            base.Load += new EventHandler(this.PregledTemeljnice_Load);
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            UltraGridBand band = new UltraGridBand("GKSTAVKA", -1);
            UltraGridColumn column = new UltraGridColumn("IDGKSTAVKA");
            UltraGridColumn column12 = new UltraGridColumn("IDAKTIVNOST");
            UltraGridColumn column19 = new UltraGridColumn("DATUMDOKUMENTA");
            UltraGridColumn column20 = new UltraGridColumn("BROJDOKUMENTA");
            UltraGridColumn column21 = new UltraGridColumn("BROJSTAVKE");
            UltraGridColumn column22 = new UltraGridColumn("IDDOKUMENT");
            UltraGridColumn column23 = new UltraGridColumn("NAZIVDOKUMENT");
            UltraGridColumn column24 = new UltraGridColumn("IDMJESTOTROSKA", -1, "MT");
            UltraGridColumn column25 = new UltraGridColumn("NAZIVMJESTOTROSKA");
            UltraGridColumn column2 = new UltraGridColumn("IDORGJED", -1, "OJ");
            UltraGridColumn column3 = new UltraGridColumn("NAZIVORGJED");
            UltraGridColumn column4 = new UltraGridColumn("IDKONTO", -1, "KONTO");
            UltraGridColumn column5 = new UltraGridColumn("NAZIVKONTO");
            UltraGridColumn column6 = new UltraGridColumn("NAZIVAKTIVNOST");
            UltraGridColumn column7 = new UltraGridColumn("OPIS");
            UltraGridColumn column8 = new UltraGridColumn("duguje");
            UltraGridColumn column9 = new UltraGridColumn("POTRAZUJE");
            UltraGridColumn column10 = new UltraGridColumn("DATUMPRIJAVE");
            UltraGridColumn column11 = new UltraGridColumn("IDPARTNER");
            UltraGridColumn column13 = new UltraGridColumn("NAZIVPARTNER");
            UltraGridColumn column14 = new UltraGridColumn("ZATVORENIIZNOS");
            UltraGridColumn column15 = new UltraGridColumn("GKDATUMVALUTE");
            UltraGridColumn column16 = new UltraGridColumn("statusgk");
            UltraGridColumn column17 = new UltraGridColumn("ORIGINALNIDOKUMENT");
            UltraGridColumn column18 = new UltraGridColumn("GKGODIDGODINE");
            SummarySettings settings = new SummarySettings("Duguje", SummaryType.Sum, null, "duguje", 15, true, "GKSTAVKA", 0, SummaryPosition.UseSummaryPositionColumn, null, -1, false);
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            SummarySettings settings2 = new SummarySettings("Potražuje", SummaryType.Sum, null, "POTRAZUJE", 0x10, true, "GKSTAVKA", 0, SummaryPosition.UseSummaryPositionColumn, null, -1, false);
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.Panel1 = new Panel();
            this.UltraButton2 = new UltraButton();
            this.UltraButton1 = new UltraButton();
            this.UltraGrid1 = new UltraGrid();
            this.GkstavkaDataSet1 = new GKSTAVKADataSet();
            this.UltraLabel1 = new UltraLabel();
            this.datumdok = new UltraDateTimeEditor();
            this.Panel1.SuspendLayout();
            ((ISupportInitialize) this.UltraGrid1).BeginInit();
            this.GkstavkaDataSet1.BeginInit();
            ((ISupportInitialize) this.datumdok).BeginInit();
            this.SuspendLayout();
            this.Panel1.Controls.Add(this.datumdok);
            this.Panel1.Controls.Add(this.UltraLabel1);
            this.Panel1.Controls.Add(this.UltraButton2);
            this.Panel1.Controls.Add(this.UltraButton1);
            this.Panel1.Location = new System.Drawing.Point(3, 0x192);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(0x3a8, 0x4d);
            this.Panel1.TabIndex = 12;
            this.UltraButton2.Location = new System.Drawing.Point(0x2f3, 0x19);
            this.UltraButton2.Name = "UltraButton2";
            this.UltraButton2.Size = new System.Drawing.Size(0x4b, 0x17);
            this.UltraButton2.TabIndex = 1;
            this.UltraButton2.Text = "Proknjiži";
            this.UltraButton1.Location = new System.Drawing.Point(0x34e, 0x19);
            this.UltraButton1.Name = "UltraButton1";
            this.UltraButton1.Size = new System.Drawing.Size(0x4b, 0x17);
            this.UltraButton1.TabIndex = 0;
            this.UltraButton1.Text = "Odustani";
            this.UltraGrid1.DataMember = "GKSTAVKA";
            this.UltraGrid1.DataSource = this.GkstavkaDataSet1;
            appearance3.BackColor = Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance3;
            column.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column.CellActivation = Activation.Disabled;
            column.Header.VisiblePosition = 10;
            column.Hidden = true;
            column12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column12.CellActivation = Activation.Disabled;
            column12.Header.VisiblePosition = 11;
            column12.Hidden = true;
            column19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column19.CellActivation = Activation.Disabled;
            column19.Header.VisiblePosition = 12;
            column19.Hidden = true;
            column20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column20.CellActivation = Activation.Disabled;
            column20.Header.VisiblePosition = 13;
            column20.Hidden = true;
            column21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column21.CellActivation = Activation.Disabled;
            column21.Header.VisiblePosition = 14;
            column21.Hidden = true;
            column22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column22.CellActivation = Activation.Disabled;
            column22.Header.VisiblePosition = 15;
            column22.Hidden = true;
            column23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column23.CellActivation = Activation.Disabled;
            column23.Header.VisiblePosition = 0x10;
            column23.Hidden = true;
            column24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column24.Header.VisiblePosition = 1;
            column24.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            column25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column25.CellActivation = Activation.Disabled;
            column25.Header.VisiblePosition = 8;
            column25.Hidden = true;
            column25.Width = 0xab;
            column2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column2.Header.VisiblePosition = 0;
            column2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            column2.Width = 0x3d;
            column3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column3.CellActivation = Activation.Disabled;
            column3.Header.VisiblePosition = 7;
            column3.Hidden = true;
            column3.Width = 0xe3;
            column4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column4.Header.VisiblePosition = 2;
            column4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            column4.Width = 0x70;
            column5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column5.CellActivation = Activation.Disabled;
            column5.Header.VisiblePosition = 9;
            column5.Hidden = true;
            column6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column6.CellActivation = Activation.Disabled;
            column6.Header.VisiblePosition = 0x11;
            column6.Hidden = true;
            column7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column7.Header.Caption = "Opis";
            column7.Header.VisiblePosition = 3;
            column7.Width = 0x1a3;
            column8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column8.Header.Caption = "Duguje";
            column8.Header.VisiblePosition = 4;
            column8.MaskInput = "-nnnnnnnnn.nn";
            column8.Width = 0x6b;
            column9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column9.Header.Caption = "Potražuje";
            column9.Header.VisiblePosition = 5;
            column9.MaskInput = "-nnnnnnnnn.nn";
            column9.Width = 110;
            column10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column10.CellActivation = Activation.NoEdit;
            column10.Header.VisiblePosition = 0x12;
            column10.Hidden = true;
            column11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column11.Header.VisiblePosition = 0x13;
            column11.Hidden = true;
            column13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column13.CellActivation = Activation.NoEdit;
            column13.Header.VisiblePosition = 20;
            column13.Hidden = true;
            column14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column14.CellActivation = Activation.Disabled;
            column14.Header.Caption = "Zatvoreno";
            column14.Header.VisiblePosition = 6;
            column14.Hidden = true;
            column14.MaskInput = "nnnnnnnnn.nn";
            column15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column15.CellActivation = Activation.Disabled;
            column15.Header.VisiblePosition = 0x15;
            column15.Hidden = true;
            column16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column16.CellActivation = Activation.Disabled;
            column16.Header.VisiblePosition = 0x16;
            column16.Hidden = true;
            column17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column17.CellActivation = Activation.Disabled;
            column17.Header.VisiblePosition = 0x17;
            column17.Hidden = true;
            column18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            column18.CellActivation = Activation.Disabled;
            column18.Header.VisiblePosition = 0x18;
            column18.Hidden = true;
            band.Columns.AddRange(new object[] { 
                column, column12, column19, column20, column21, column22, column23, column24, column25, column2, column3, column4, column5, column6, column7, column8, 
                column9, column10, column11, column13, column14, column15, column16, column17, column18
             });
            appearance.BackColor = Color.FromArgb(0xff, 0xff, 0xc0);
            settings.Appearance = appearance;
            settings.DisplayFormat = "{0:#,##0.00}";
            settings.GroupBySummaryValueAppearance = appearance2;
            settings.SummaryDisplayArea = SummaryDisplayAreas.Top;
            appearance8.BackColor = Color.FromArgb(0xff, 0xff, 0xc0);
            settings2.Appearance = appearance8;
            settings2.DisplayFormat = "{0:#,##0.00}";
            settings2.GroupBySummaryValueAppearance = appearance9;
            settings2.SummaryDisplayArea = SummaryDisplayAreas.Top;
            band.Summaries.AddRange(new SummarySettings[] { settings, settings2 });
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(band);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;
            appearance4.BackColor = Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance4;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance5.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance5;
            appearance6.BorderColor = Color.LightGray;
            appearance6.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance6;
            this.UltraGrid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True;
            appearance7.BackColor = Color.LightSteelBlue;
            appearance7.BorderColor = Color.Black;
            appearance7.ForeColor = Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = RowConnectorStyle.None;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0xee);
            this.UltraGrid1.Location = new System.Drawing.Point(3, 5);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(0x3a8, 0x18b);
            this.UltraGrid1.TabIndex = 11;
            this.UltraGrid1.UseAppStyling = false;
            this.GkstavkaDataSet1.DataSetName = "GKSTAVKADataSet";
            this.UltraLabel1.Location = new System.Drawing.Point(15, 0x18);
            this.UltraLabel1.Name = "UltraLabel1";
            this.UltraLabel1.Size = new System.Drawing.Size(100, 0x17);
            this.UltraLabel1.TabIndex = 2;
            this.UltraLabel1.Text = "Datum dokumenta:";
            this.UltraLabel1.UseAppStyling = false;
            this.datumdok.Location = new System.Drawing.Point(0x84, 20);
            this.datumdok.Name = "datumdok";
            this.datumdok.Size = new System.Drawing.Size(0x90, 0x15);
            this.datumdok.TabIndex = 3;
            this.datumdok.UseAppStyling = false;
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.UltraGrid1);
            this.Name = "PregledTemeljnice";
            this.Size = new System.Drawing.Size(0x3b5, 0x1e5);

            this.UltraButton1.Click += new EventHandler(UltraButton1_Click);
            this.UltraButton2.Click += new EventHandler(UltraButton2_Click);

            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((ISupportInitialize) this.UltraGrid1).EndInit();
            this.GkstavkaDataSet1.EndInit();
            ((ISupportInitialize) this.datumdok).EndInit();
            this.ResumeLayout(false);
        }

        private void PregledTemeljnice_Load(object sender, EventArgs e)
        {
            this.datumdok.Value = DateAndTime.Today;
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void UltraButton2_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void UltraNumericEditor1_GotFocus(object sender, EventArgs e)
        {
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
        }

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

        public UltraDateTimeEditor datumdok;

        public GKSTAVKADataSet GkstavkaDataSet1;

        private Panel Panel1;

        private UltraButton UltraButton1;

        private UltraButton UltraButton2;

        private UltraGrid UltraGrid1;

        private UltraLabel UltraLabel1;
    }
}

