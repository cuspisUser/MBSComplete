using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using mipsed.application.framework;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


namespace FinPosModule
{

    [DesignerGenerated]
    public class frmPogledUVeze : Form
    {
        private IContainer components;
        public int IDGKSTAVKA;
        public string naslov;

        [DebuggerNonUserCode]
        public frmPogledUVeze()
        {
            base.Load += new EventHandler(this.frmPogledUVeze_Load);
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            AppSettingsReader reader = new AppSettingsReader();
            connection.ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString;
            CurrencyManager manager = (CurrencyManager) this.BindingContext[this.dsVezeZatvaranja, "ZATVARANJA"];
            if (manager.Count != 0)
            {
                DataRowView current = (DataRowView) manager.Current;
                SqlCommand command = new SqlCommand {
                    CommandType = CommandType.Text,
                    CommandText = "delete from zatvaranja where GK1IDGKSTAVKA=@koja and GK2IDGKSTAVKA = @koju"
                };
                command.Parameters.AddWithValue("@koja", RuntimeHelpers.GetObjectValue(current["GK1IDGKSTAVKA"]));
                command.Parameters.AddWithValue("@koju", RuntimeHelpers.GetObjectValue(current["GK2IDGKSTAVKA"]));
                command.Connection = connection;
                connection.Open();
                command.ExecuteScalar();
                connection.Close();
                this.pODACI();
            }
        }

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

        private void frmPogledUVeze_Load(object sender, EventArgs e)
        {
            this.Label1.Text = this.naslov;
            this.pODACI();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ZATVARANJA", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GK1IDGKSTAVKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GK2IDGKSTAVKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZATVARANJAIZNOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGKSTAVKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMDOKUMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJDOKUMENTA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BROJSTAVKE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDKONTO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OPIS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DUGUJE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("POTRAZUJE");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMPRIJAVE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZATVORENIIZNOS");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMDVO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMVALUTE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVPARTNER");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVMJESTOTROSKA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVORGJED");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SKRACENIDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVDOKUMENT");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NAZIVKONTO");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPogledUVeze));
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.DataSet11BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsVezeZatvaranja = new dsZatvaranja();
            this.Button1 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet11BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsVezeZatvaranja)).BeginInit();
            this.SuspendLayout();
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "ZATVARANJA";
            this.UltraGrid1.DataSource = this.DataSet11BindingSource;
            appearance.BackColor = System.Drawing.Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 8;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.VisiblePosition = 9;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 10;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.VisiblePosition = 11;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.Caption = "Dat.dok.";
            ultraGridColumn5.Header.VisiblePosition = 2;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.Caption = "Broj";
            ultraGridColumn6.Header.VisiblePosition = 1;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "Stavka";
            ultraGridColumn7.Header.VisiblePosition = 3;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 12;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 13;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.VisiblePosition = 14;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.Caption = "Konto";
            ultraGridColumn11.Header.VisiblePosition = 4;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.VisiblePosition = 15;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.Caption = "Duguje";
            ultraGridColumn13.Header.VisiblePosition = 5;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            appearance1.FontData.BoldAsString = "True";
            appearance1.TextHAlignAsString = "Right";
            ultraGridColumn14.CellAppearance = appearance1;
            ultraGridColumn14.Header.Caption = "Potražuje";
            ultraGridColumn14.Header.VisiblePosition = 6;
            ultraGridColumn14.MaskInput = "-nnnnnnnnn.nn";
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.VisiblePosition = 16;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.VisiblePosition = 17;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.Caption = "Zatvoreno";
            ultraGridColumn17.Header.VisiblePosition = 7;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.VisiblePosition = 18;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.VisiblePosition = 19;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.Header.VisiblePosition = 20;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.Header.VisiblePosition = 21;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn22.Header.VisiblePosition = 22;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn23.Header.Caption = "Dokument";
            ultraGridColumn23.Header.VisiblePosition = 0;
            ultraGridColumn23.Width = 95;
            ultraGridColumn24.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn24.Header.VisiblePosition = 23;
            ultraGridColumn25.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn25.Header.VisiblePosition = 24;
            ultraGridColumn25.Hidden = true;
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
            ultraGridColumn25});
            ultraGridBand1.SummaryFooterCaption = "Totali";
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance4.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance4;
            appearance5.BorderColor = System.Drawing.Color.LightGray;
            appearance5.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance5;
            this.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance6.BackColor = System.Drawing.Color.Navy;
            appearance6.BorderColor = System.Drawing.Color.Black;
            appearance6.ForeColor = System.Drawing.Color.White;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance6;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(1, 77);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(752, 346);
            this.UltraGrid1.TabIndex = 4;
            this.UltraGrid1.UseAppStyling = false;
            this.UltraGrid1.UseFlatMode = Infragistics.Win.DefaultableBoolean.False;
            this.UltraGrid1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // DataSet11BindingSource
            // 
            this.DataSet11BindingSource.DataSource = this.dsVezeZatvaranja;
            this.DataSet11BindingSource.Position = 0;
            // 
            // dsVezeZatvaranja
            // 
            this.dsVezeZatvaranja.DataSetName = "DataSet1";
            this.dsVezeZatvaranja.Locale = new System.Globalization.CultureInfo("hr-HR");
            this.dsVezeZatvaranja.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(1, 39);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 5;
            this.Button1.Text = "Briši vezu";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(45, 13);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Label1";
            // 
            // frmPogledUVeze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 422);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.UltraGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPogledUVeze";
            this.Text = "Pogled u veze";
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet11BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsVezeZatvaranja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void pODACI()
        {
            SqlConnection connection = new SqlConnection {
                ConnectionString = Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString
            };
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            command.CommandText = "S_FIN_POGLED_U_VEZE";
            command.Parameters.Add("@IDGKSTAVKA", SqlDbType.BigInt).Value = this.IDGKSTAVKA;
            this.dsVezeZatvaranja.EnforceConstraints = false;
            this.dsVezeZatvaranja.Clear();
            adapter.SelectCommand = command;
            try
            {
                adapter.Fill(this.dsVezeZatvaranja, "ZATVARANJA");
            }
            catch (SqlException exception1)
            {
                throw exception1;
            }
        }

        private Button Button1;

        private BindingSource DataSet11BindingSource;

        private dsZatvaranja dsVezeZatvaranja;

        private Label Label1;

        private UltraGrid UltraGrid1;
    }
}

