namespace DDModule
{
    using Infragistics.Win;
    using Infragistics.Win.Misc;
    using Infragistics.Win.UltraWinGrid;
    using Microsoft.VisualBasic.CompilerServices;
    using Placa;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Security.Permissions;
    using System.Windows.Forms;

    [DesignerGenerated]
    public class frmPregledRadnika : Form
    {
        private IContainer components { get; set; }
        private DDOBRACUNDataSet.DDOBRACUNRadniciDataTable Obracunati;

        public frmPregledRadnika()
        {
            base.Load += new EventHandler(this.frmPregledRadnika_Load_1);
            this.Obracunati = new DDOBRACUNDataSet.DDOBRACUNRadniciDataTable();
            this.InitializeComponent();
        }

        private int BrojOznacenihRadnika()
        {
            int num2 = 0;
            int num4 = this.UltraGrid2.Rows.Count - 1;
            for (int i = 0; i <= num4; i++)
            {
                if (Conversions.ToBoolean(this.UltraGrid2.Rows[i].Cells["oznacen"].Value))
                {
                    num2++;
                }
            }
            return num2;
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (this.components != null))
                {
                    this.components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private void frmPregledRadnika_Load_1(object sender, EventArgs e)
        {
            new DDRADNIKDataAdapter().Fill(this.DdradnikDataSet1);

            //micanje radnika koji nisu aktivni
            DataRow[] aktivni = this.DdradnikDataSet1.DDRADNIK.Select("Aktivan = False");

            foreach (var item in aktivni)
            {
                this.DdradnikDataSet1.DDRADNIK.RemoveDDRADNIKRow((DDRADNIKDataSet.DDRADNIKRow)item);
            }

            if (this.Obracunati != null)
            {
                IEnumerator enumerator = null;
                try
                {
                    enumerator = this.Obracunati.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        DataRow[] rowArray = this.DdradnikDataSet1.DDRADNIK.Select(Conversions.ToString(Operators.ConcatenateObject("ddidradnik = ", current["ddidradnik"])));
                        this.DdradnikDataSet1.DDRADNIK.RemoveDDRADNIKRow((DDRADNIKDataSet.DDRADNIKRow) rowArray[0]);
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
            }
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("DDRADNIK", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIDRADNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDJMBG");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOIB");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDPREZIME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDIME");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDADRESA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDKUCNIBROJ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDMJESTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDZRN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDBANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBANKE1");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBANKE2");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVBANKE3");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VBDIBANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZRNBANKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINARADAIDOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINARADANAZIVOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAIDOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJANAZIVOPCINE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAPRIREZ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAVBDIOPCINA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPCINASTANOVANJAZRNOPCINA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDSIFRAOPISAPLACANJANETO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDOPISPLACANJANETO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDPDVOBVEZNIK");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDDRUGISTUP");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDZBIRNINETO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDMO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DDPBO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("oznacen", 0);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPregledRadnika));
            this.UltraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.UltraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.PregledRadnikaDataSet2 = new Placa.PregledRadnikaDataSet();
            this.UltraGrid2 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.DdradnikDataSet1 = new Placa.DDRADNIKDataSet();
            this.UltraButton3 = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.PregledRadnikaDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdradnikDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraButton1
            // 
            this.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton1.Location = new System.Drawing.Point(12, 12);
            this.UltraButton1.Name = "UltraButton1";
            this.UltraButton1.Size = new System.Drawing.Size(123, 23);
            this.UltraButton1.TabIndex = 1;
            this.UltraButton1.Text = "Dodaj oznake svima";
            this.UltraButton1.UseAppStyling = false;
            this.UltraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton1.Click += new System.EventHandler(this.UltraButton1_Click);
            // 
            // UltraButton2
            // 
            this.UltraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton2.Location = new System.Drawing.Point(141, 12);
            this.UltraButton2.Name = "UltraButton2";
            this.UltraButton2.Size = new System.Drawing.Size(128, 23);
            this.UltraButton2.TabIndex = 2;
            this.UltraButton2.Text = "Ukloni oznake svima";
            this.UltraButton2.UseAppStyling = false;
            this.UltraButton2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton2.Click += new System.EventHandler(this.UltraButton2_Click);
            // 
            // PregledRadnikaDataSet2
            // 
            this.PregledRadnikaDataSet2.DataSetName = "PregledRadnikaDataSet";
            // 
            // UltraGrid2
            // 
            this.UltraGrid2.DataMember = "DDRADNIK";
            this.UltraGrid2.DataSource = this.DdradnikDataSet1;
            appearance.BackColor = System.Drawing.Color.White;
            this.UltraGrid2.DisplayLayout.Appearance = appearance;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Width = 100;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn4.Width = 165;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn5.Width = 156;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 9;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 10;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 17;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 18;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 19;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.VisiblePosition = 20;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.VisiblePosition = 21;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.VisiblePosition = 22;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 11;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.VisiblePosition = 12;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn18.Header.VisiblePosition = 8;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.VisiblePosition = 13;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.Header.VisiblePosition = 14;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.Header.VisiblePosition = 15;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.Header.VisiblePosition = 16;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.Header.VisiblePosition = 23;
            ultraGridColumn23.Hidden = true;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn24.Header.VisiblePosition = 24;
            ultraGridColumn24.Hidden = true;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn25.Header.VisiblePosition = 25;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn26.Header.VisiblePosition = 26;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn27.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn27.Header.VisiblePosition = 27;
            ultraGridColumn27.Hidden = true;
            ultraGridColumn28.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn28.Header.VisiblePosition = 28;
            ultraGridColumn28.Hidden = true;
            ultraGridColumn29.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn29.Header.VisiblePosition = 29;
            ultraGridColumn29.Hidden = true;
            ultraGridColumn30.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn30.DataType = typeof(bool);
            ultraGridColumn30.DefaultCellValue = false;
            ultraGridColumn30.Header.Caption = "Označen";
            ultraGridColumn30.Header.VisiblePosition = 0;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24,
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29,
            ultraGridColumn30});
            ultraGridBand1.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid2.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid2.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid2.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid2.DisplayLayout.Override.CellPadding = 3;
            this.UltraGrid2.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance3.TextHAlignAsString = "Left";
            this.UltraGrid2.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.UltraGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance4.BorderColor = System.Drawing.Color.LightGray;
            appearance4.TextVAlignAsString = "Middle";
            this.UltraGrid2.DisplayLayout.Override.RowAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance5.BorderColor = System.Drawing.Color.Black;
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid2.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid2.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.UltraGrid2.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.UltraGrid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGrid2.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.UltraGrid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.UltraGrid2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid2.Location = new System.Drawing.Point(12, 41);
            this.UltraGrid2.Name = "UltraGrid2";
            this.UltraGrid2.Size = new System.Drawing.Size(648, 527);
            this.UltraGrid2.TabIndex = 43;
            this.UltraGrid2.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.UltraGrid2_InitializeLayout);
            this.UltraGrid2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UltraGrid2_MouseDown);
            this.UltraGrid2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UltraGrid2_MouseUp);
            // 
            // DdradnikDataSet1
            // 
            this.DdradnikDataSet1.DataSetName = "DDRADNIKDataSet";
            // 
            // UltraButton3
            // 
            this.UltraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton3.Location = new System.Drawing.Point(275, 12);
            this.UltraButton3.Name = "UltraButton3";
            this.UltraButton3.Size = new System.Drawing.Size(123, 23);
            this.UltraButton3.TabIndex = 44;
            this.UltraButton3.Text = "Potvrda odabira";
            this.UltraButton3.UseAppStyling = false;
            this.UltraButton3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton3.Click += new System.EventHandler(this.UltraButton3_Click);
            // 
            // frmPregledRadnika
            // 
            this.ClientSize = new System.Drawing.Size(666, 605);
            this.Controls.Add(this.UltraButton3);
            this.Controls.Add(this.UltraGrid2);
            this.Controls.Add(this.UltraButton2);
            this.Controls.Add(this.UltraButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPregledRadnika";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.PregledRadnikaDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DdradnikDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        public void odaberi()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void Parametri_OznaciSve()
        {
            int num2 = this.UltraGrid2.Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                this.UltraGrid2.Rows[i].Cells["oznacen"].Value = true;
            }
            this.Text = "Odabrano: " + Conversions.ToString(this.BrojOznacenihRadnika()) + " zaposlenika";
        }

        private void Parametri_PrikaziSamoAktivne()
        {
            this.UltraGrid2.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
            this.UltraGrid2.DisplayLayout.Bands[0].ColumnFilters["aktivan"].FilterConditions.Add(FilterComparisionOperator.Equals, 1);
        }

        private void Parametri_PrikaziSve()
        {
            this.UltraGrid2.DisplayLayout.Bands[0].ColumnFilters.ClearAllFilters();
        }

        private void Parametri_SkiniOznakeSvima()
        {
            int num2 = this.UltraGrid2.Rows.Count - 1;
            for (int i = 0; i <= num2; i++)
            {
                this.UltraGrid2.Rows[i].Cells["oznacen"].Value = false;
            }
            this.Text = "Odabrano: " + Conversions.ToString(this.BrojOznacenihRadnika()) + " zaposlenika";
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            this.Parametri_OznaciSve();
        }

        private void UltraButton2_Click(object sender, EventArgs e)
        {
            this.Parametri_SkiniOznakeSvima();
        }

        private void UltraButton3_Click(object sender, EventArgs e)
        {
            if (this.BrojOznacenihRadnika() == 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void UltraCheckEditor1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void UltraGrid2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
        }

        private void UltraGrid2_MouseDown(object sender, MouseEventArgs e)
        {
            this.UltraGrid2.ActiveRow = null;
            if (e.Button == MouseButtons.Left)
            {
                UltraGridRow context = null;
                context = (UltraGridRow) this.UltraGrid2.DisplayLayout.UIElement.ElementFromPoint(e.Location).GetContext(typeof(UltraGridRow));
                if ((context != null) && context.IsDataRow)
                {
                    context.Selected = true;
                    context.Cells["oznacen"].Value = Operators.NotObject(context.Cells["oznacen"].Value);
                }
            }
            this.Text = "Odabrano: " + Conversions.ToString(this.BrojOznacenihRadnika()) + " zaposlenika";
        }

        private void UltraGrid2_MouseUp(object sender, MouseEventArgs e)
        {
        }

        [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == 0x112) && (m.WParam.ToInt32() == 0xf060))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        internal DDRADNIKDataSet DdradnikDataSet1;

        public object OdabraniRadnici
        {
            get
            {
                object obj2 = new object();
                if (this.UltraGrid2.Rows.Count != 0)
                {
                    obj2 = this.UltraGrid2;
                }
                return obj2;
            }
            set
            {
                this.OdabraniRadnici = RuntimeHelpers.GetObjectValue(value);
            }
        }

        private PregledRadnikaDataSet PregledRadnikaDataSet2;

        private UltraButton UltraButton1;

        private UltraButton UltraButton2;

        private UltraButton UltraButton3;

        private UltraGrid UltraGrid2;

        public DDOBRACUNDataSet.DDOBRACUNRadniciDataTable VecUObracunu;
    }
}

