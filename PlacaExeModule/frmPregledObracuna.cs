using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Placa;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

[DesignerGenerated]
public class frmPregledObracuna : Form
{
    private CurrencyManager cm;
    private IContainer components { get; set; }
    private DataRowView drv;
    private string m_vrstaobracuna { get; set; }

    

    [DebuggerNonUserCode]
    public frmPregledObracuna()
    {
        base.Load += new EventHandler(this.frmPregledObracuna_Load);
        this.InitializeComponent();
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

    private void frmPregledObracuna_Load(object sender, EventArgs e)
    {
        new PregledObracunaDataAdapter().Fill(this.PregledObracunaDataSet1);
        if (this.UltraGrid1.Rows.Count > 0)
        {
            this.UltraGrid1.ActiveRow = this.UltraGrid1.Rows[0];
        }
    }

    private void InitializeComponent()
    {
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PregledObracuna", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOBRACUN", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("VRSTAOBRACUNA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MJESECOBRACUNA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GODINAOBRACUNA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MJESECISPLATE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GODINAISPLATE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMISPLATE");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("tjednifondsatiobracun");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MJESECNIFONDSATIOBRACUN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OSNOVNIOO");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRACUNSKAOSNOVICA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DATUMOBRACUNASTAZA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRPOSTOTNIH");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRFIKSNIH");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("OBRKREDITNIH");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ZAKLJ");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SVRHAOBRACUNA");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IDENTIFIKATOROBRASCA");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.frmPregledObracuna_Fill_Panel = new System.Windows.Forms.Panel();
            this.UltraButton4 = new Infragistics.Win.Misc.UltraButton();
            this.UltraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.UltraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.UltraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.UltraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.PregledObracunaDataSet1 = new Placa.PregledObracunaDataSet();
            this.frmPregledObracuna_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PregledObracunaDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // frmPregledObracuna_Fill_Panel
            // 
            this.frmPregledObracuna_Fill_Panel.Controls.Add(this.UltraButton4);
            this.frmPregledObracuna_Fill_Panel.Controls.Add(this.UltraButton3);
            this.frmPregledObracuna_Fill_Panel.Controls.Add(this.UltraButton2);
            this.frmPregledObracuna_Fill_Panel.Controls.Add(this.UltraButton1);
            this.frmPregledObracuna_Fill_Panel.Controls.Add(this.UltraGrid1);
            this.frmPregledObracuna_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmPregledObracuna_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmPregledObracuna_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.frmPregledObracuna_Fill_Panel.Name = "frmPregledObracuna_Fill_Panel";
            this.frmPregledObracuna_Fill_Panel.Size = new System.Drawing.Size(961, 626);
            this.frmPregledObracuna_Fill_Panel.TabIndex = 0;
            // 
            // UltraButton4
            // 
            this.UltraButton4.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton4.Location = new System.Drawing.Point(401, 12);
            this.UltraButton4.Name = "UltraButton4";
            this.UltraButton4.Size = new System.Drawing.Size(123, 23);
            this.UltraButton4.TabIndex = 48;
            this.UltraButton4.Text = "Zaključaj sve";
            this.UltraButton4.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton4.Click += new System.EventHandler(this.UltraButton4_Click);
            // 
            // UltraButton3
            // 
            this.UltraButton3.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton3.Location = new System.Drawing.Point(272, 12);
            this.UltraButton3.Name = "UltraButton3";
            this.UltraButton3.Size = new System.Drawing.Size(123, 23);
            this.UltraButton3.TabIndex = 47;
            this.UltraButton3.Text = "Zaključaj sve";
            this.UltraButton3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton3.Click += new System.EventHandler(this.UltraButton3_Click);
            // 
            // UltraButton2
            // 
            this.UltraButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton2.Location = new System.Drawing.Point(138, 12);
            this.UltraButton2.Name = "UltraButton2";
            this.UltraButton2.Size = new System.Drawing.Size(128, 23);
            this.UltraButton2.TabIndex = 46;
            this.UltraButton2.Text = "Obriši obračun";
            this.UltraButton2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton2.Click += new System.EventHandler(this.UltraButton2_Click);
            // 
            // UltraButton1
            // 
            this.UltraButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.UltraButton1.Location = new System.Drawing.Point(9, 12);
            this.UltraButton1.Name = "UltraButton1";
            this.UltraButton1.Size = new System.Drawing.Size(123, 23);
            this.UltraButton1.TabIndex = 45;
            this.UltraButton1.Text = "Odaberi obračun";
            this.UltraButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.UltraButton1.Click += new System.EventHandler(this.UltraButton1_Click);
            // 
            // UltraGrid1
            // 
            this.UltraGrid1.DataMember = "PregledObracuna";
            this.UltraGrid1.DataSource = this.PregledObracunaDataSet1;
            appearance.BackColor = System.Drawing.Color.White;
            this.UltraGrid1.DisplayLayout.Appearance = appearance;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn1.Header.Caption = "Obračun";
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 88;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn3.Header.Caption = "MJ Obr";
            ultraGridColumn3.Header.VisiblePosition = 3;
            ultraGridColumn3.Width = 85;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn4.Header.Caption = "GOD Obr";
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn4.Width = 86;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn5.Header.Caption = "MJ Isp";
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn5.Width = 82;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn6.Header.Caption = "God Isp";
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn6.Width = 71;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn7.Header.VisiblePosition = 7;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn8.Width = 72;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn9.Header.Caption = "Mjesečni fond sati";
            ultraGridColumn9.Header.VisiblePosition = 9;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn9.Width = 91;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn10.Header.Caption = "Osnovni OO";
            ultraGridColumn10.Header.VisiblePosition = 10;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn11.Header.Caption = "Obračunska osnovica";
            ultraGridColumn11.Header.VisiblePosition = 11;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn12.Header.Caption = "Datum obračuna staža";
            ultraGridColumn12.Header.VisiblePosition = 12;
            ultraGridColumn12.Hidden = true;
            ultraGridColumn12.Width = 97;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn13.Header.Caption = "Obr.postotnih";
            ultraGridColumn13.Header.VisiblePosition = 13;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn14.Header.Caption = "Obr.fiksnih";
            ultraGridColumn14.Header.VisiblePosition = 14;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn15.Header.Caption = "Obr.kreditnih";
            ultraGridColumn15.Header.VisiblePosition = 15;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn16.Header.Caption = "Zaključan";
            ultraGridColumn16.Header.VisiblePosition = 16;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn17.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit;
            ultraGridColumn17.Header.Caption = "Svrha obračuna";
            ultraGridColumn17.Header.VisiblePosition = 17;
            ultraGridColumn17.Width = 262;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None;
            ultraGridColumn18.Header.Caption = "JOPPD";
            ultraGridColumn18.Header.VisiblePosition = 2;
            ultraGridColumn18.Width = 52;
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
            ultraGridColumn18});
            ultraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.UltraGrid1.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.UltraGrid1.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.None;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance2;
            this.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.UltraGrid1.DisplayLayout.Override.CellPadding = 3;
            appearance3.TextHAlignAsString = "Left";
            this.UltraGrid1.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance4.BorderColor = System.Drawing.Color.LightGray;
            appearance4.TextVAlignAsString = "Middle";
            this.UltraGrid1.DisplayLayout.Override.RowAppearance = appearance4;
            this.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance5.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance5.BorderColor = System.Drawing.Color.Black;
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.UltraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.UltraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.UltraGrid1.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None;
            this.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.UltraGrid1.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell;
            this.UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.UltraGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraGrid1.Location = new System.Drawing.Point(9, 41);
            this.UltraGrid1.Name = "UltraGrid1";
            this.UltraGrid1.Size = new System.Drawing.Size(940, 585);
            this.UltraGrid1.TabIndex = 0;
            this.UltraGrid1.AfterRowActivate += new System.EventHandler(this.UltraGrid1_AfterRowActivate);
            this.UltraGrid1.AfterRowUpdate += new Infragistics.Win.UltraWinGrid.RowEventHandler(this.UltraGrid1_AfterRowUpdate);
            this.UltraGrid1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UltraGrid1_KeyDown);
            this.UltraGrid1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UltraGrid1_MouseDown);
            // 
            // PregledObracunaDataSet1
            // 
            this.PregledObracunaDataSet1.DataSetName = "PregledObracunaDataSet";
            // 
            // frmPregledObracuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 626);
            this.Controls.Add(this.frmPregledObracuna_Fill_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPregledObracuna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pregled obračuna";
            this.frmPregledObracuna_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UltraGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PregledObracunaDataSet1)).EndInit();
            this.ResumeLayout(false);

    }

    private void Obrisi()
    {
        this.cm = (CurrencyManager) this.BindingContext[this.PregledObracunaDataSet1, "PregledObracuna"];
        if (this.cm.Count != 0)
        {
            if (Operators.ConditionalCompareObjectEqual(this.drv["zaklj"], true, false))
            {
                Interaction.MsgBox("Obračun je zaključan! Brisanje nije moguće!", MsgBoxStyle.Critical, "Obračun plaća");
            }
            else
            {
                this.drv = (DataRowView) this.cm.Current;
                if (Conversions.ToString(this.drv["idobracun"]) == this.Sifra_Zadnjeg_Obracuna(Conversions.ToString(this.drv["mjesecisplate"]), Conversions.ToString(this.drv["godinaisplate"])))
                {
                    if (Interaction.MsgBox("Molim da potvrdite brisanje obračuna!", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
                    {
                        SqlCommand command = new SqlCommand();
                        SqlConnection connection = new SqlConnection {
                            ConnectionString = Configuration.ConnectionString
                        };
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        command.CommandText = "DELETE FROM RSMA1 WHERE IDENTIFIKATOROBRASCA = '" + DB.N2T(RuntimeHelpers.GetObjectValue(this.drv["IDENTIFIKATOROBRASCA"]), "") + "'";
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM RSMA WHERE IDENTIFIKATOROBRASCA = '" + DB.N2T(RuntimeHelpers.GetObjectValue(this.drv["IDENTIFIKATOROBRASCA"]), "") + "'";
                        command.ExecuteNonQuery();
                        connection.Close();
                        OBRACUNDataSet set = new OBRACUNDataSet();
                        this.ObrisiObracun(Conversions.ToString(this.drv["idobracun"]));
                        this.drv.Delete();
                        this.drv = null;
                    }
                }
                else
                {
                    Interaction.MsgBox("Brisanje obračuna nije moguće!", MsgBoxStyle.OkOnly, null);
                }
            }
        }
    }

    private void ObrisiObracun(string sifraobr)
    {
        SqlCommand command = new SqlCommand();
        SqlConnection connection = new SqlConnection {
            ConnectionString = Configuration.ConnectionString
        };
        command.Connection = connection;
        command.CommandType = CommandType.Text;
        connection.Open();
        command.CommandText = "DELETE FROM OBRACUNOBRACUNLevel1ObracunKrizni WHERE IDOBRACUN = '" + sifraobr + "'";
        command.ExecuteNonQuery();
        command.CommandText = "DELETE FROM OBRACUNobustave WHERE IDOBRACUN = '" + sifraobr + "'";
        command.ExecuteNonQuery();
        command.CommandText = "DELETE FROM OBRACUNkrediti WHERE IDOBRACUN = '" + sifraobr + "'";
        command.ExecuteNonQuery();
        command.CommandText = "DELETE FROM OBRACUNelementi WHERE IDOBRACUN = '" + sifraobr + "'";
        command.ExecuteNonQuery();
        command.CommandText = "DELETE FROM OBRACUNdoprinosi WHERE IDOBRACUN = '" + sifraobr + "'";
        command.ExecuteNonQuery();
        command.CommandText = "DELETE FROM OBRACUNporezi WHERE IDOBRACUN = '" + sifraobr + "'";
        command.ExecuteNonQuery();
        command.CommandText = "DELETE FROM OBRACUNolaksice WHERE IDOBRACUN = '" + sifraobr + "'";
        command.ExecuteNonQuery();
        command.CommandText = "DELETE FROM OBRACUNradnici WHERE IDOBRACUN = '" + sifraobr + "'";
        command.ExecuteNonQuery();
        command.CommandText = "DELETE FROM OBRACUN WHERE IDOBRACUN = '" + sifraobr + "'";
        command.ExecuteNonQuery();
        connection.Close();
    }

    private void Odaberi()
    {
        this.cm = (CurrencyManager) this.BindingContext[this.PregledObracunaDataSet1, "PregledObracuna"];
        if (this.cm.Count != 0)
        {
            this.drv = (DataRowView) this.cm.Current;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }

    public void OdaberiKonacni()
    {
        this.cm = (CurrencyManager)this.BindingContext[this.PregledObracunaDataSet1, "PregledObracuna"];
        if (this.cm.Count != 0)
        {
            this.drv = (DataRowView)this.cm.Current;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }

    public void Promjeni_Status_Zadanog_Obracuna(string OBRACUN, bool ZAKLJ)
    {
        SqlConnection connection = new SqlConnection {
            ConnectionString = Configuration.ConnectionString
        };
        connection.Open();
        SqlCommand command = new SqlCommand {
            CommandType = CommandType.Text,
            Connection = connection
        };
        if (ZAKLJ)
        {
            command.CommandText = "update obracun set zaklj = 1 where idobracun = '" + OBRACUN + "'";
            try
            {
                command.ExecuteNonQuery();
                this.UltraButton4.Text = "Odključaj";
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                
                
            }
        }
        else
        {
            command.CommandText = "update obracun set zaklj = 0 where idobracun = '" + OBRACUN + "'";
            try
            {
                command.ExecuteNonQuery();
                this.UltraButton4.Text = "Zaključaj";
            }
            catch (System.Exception exception3)
            {
                throw exception3;
                //Exception exception2 = exception3;
                //Interaction.MsgBox(exception2.Message, MsgBoxStyle.OkOnly, null);
            }
        }
        connection.Close();
    }

    private string Sifra_Zadnjeg_Obracuna(string mjesecisplate, string godinaisplate)
    {
        SqlCommand command = new SqlCommand();
        SqlConnection connection = new SqlConnection {
            ConnectionString = Configuration.ConnectionString
        };
        command.CommandText = "SELECT max(idobracun) from obracun where mjesecisplate= '" + mjesecisplate + "' and godinaisplate = '" + godinaisplate + "'";
        command.CommandType = CommandType.Text;
        command.Connection = connection;
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            return reader.GetString(0);
        }
        return "";
    }

    private void UltraButton1_Click(object sender, EventArgs e)
    {
        this.Odaberi();
    }

    private void UltraButton2_Click(object sender, EventArgs e)
    {
        if (ProvjeraNapravljenogJOPPDAZaObracun())
        {
            this.Obrisi();
        }
        else
        {
            MessageBox.Show("Postoji JOPPD obrazac za označeni obračun.\nPotrebno je prvo obrisati JOPPD obrazac da bi se mogao brisati obračun.", "Upozorenje");

        }
    }

    private bool ProvjeraNapravljenogJOPPDAZaObracun()
    {
        Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();

        try
        {
            string var = client.ExecuteScalar("Select ID From JOPPDAObracun Where OBRACUN_ID = '" + drv["idobracun"].ToString() + "' And Vrsta = 0").ToString();
            return false;
        }
        catch 
        {
            return true;
        }
    }

    private void UltraButton3_Click(object sender, EventArgs e)
    {
        this.Zakljucaj_Sve_Obracune();
        this.PregledObracunaDataSet1.PregledObracuna.Clear();
        new PregledObracunaDataAdapter().Fill(this.PregledObracunaDataSet1);
    }

    private void UltraButton4_Click(object sender, EventArgs e)
    {
        this.cm = (CurrencyManager) this.BindingContext[this.PregledObracunaDataSet1, "PREGLEDOBRACUNA"];
        if (this.cm.Count != 0)
        {
            this.drv = (DataRowView) this.cm.Current;
            if (this.UltraGrid1.Selected.Rows.Count == 0)
            {
                Interaction.MsgBox("Odaberite obračun!", MsgBoxStyle.OkOnly, null);
            }
            else if (this.UltraGrid1.Selected.Rows.Count > 1)
            {
                Interaction.MsgBox("Odabrati možete samo jedan redak istovremeno!", MsgBoxStyle.OkOnly, null);
            }
            else if (Operators.ConditionalCompareObjectEqual(this.drv["zaklj"], 0, false))
            {
                this.Promjeni_Status_Zadanog_Obracuna(Conversions.ToString(this.drv["IDOBRACUN"]), true);
                this.UltraGrid1.Selected.Rows[0].Cells["ZAKLJ"].Value = true;
            }
            else
            {
                this.Promjeni_Status_Zadanog_Obracuna(Conversions.ToString(this.drv["IDOBRACUN"]), false);
                this.UltraGrid1.Selected.Rows[0].Cells["ZAKLJ"].Value = false;
            }
        }
    }

    private void UltraGrid1_AfterRowActivate(object sender, EventArgs e)
    {
        this.cm = (CurrencyManager) this.BindingContext[this.PregledObracunaDataSet1, "PREGLEDOBRACUNA"];
        if (this.cm.Count != 0)
        {
            this.drv = (DataRowView) this.cm.Current;
            if (Operators.ConditionalCompareObjectEqual(this.drv["zaklj"], 0, false))
            {
                this.UltraButton4.Text = "Zaključaj";
            }
            else
            {
                this.UltraButton4.Text = "Odključaj";
            }
        }
    }

    private void UltraGrid1_AfterRowUpdate(object sender, RowEventArgs e)
    {
        if (e.Row != null)
        {
            SqlConnection connection = new SqlConnection {
                ConnectionString = Configuration.ConnectionString
            };
            connection.Open();
            SqlCommand command = new SqlCommand {
                CommandType = CommandType.Text,
                Connection = connection
            };
            command.Parameters.Add("@SVRHA", SqlDbType.VarChar, 100).Value = RuntimeHelpers.GetObjectValue(e.Row.Cells["SVRHAOBRACUNA"].Value);
            command.Parameters.Add("@datum", SqlDbType.DateTime).Value = RuntimeHelpers.GetObjectValue(e.Row.Cells["DATUMISPLATE"].Value);
            command.CommandText = Conversions.ToString(Operators.ConcatenateObject("update obracun set SVRHAOBRACUNA = @SVRHA, datumisplate = @datum where idobracun = ", Operators.AddObject(Operators.AddObject("'", e.Row.Cells["IDOBRACUN"].Value), "'")));
            try
            {
                command.ExecuteNonQuery();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
        }
    }

    private void UltraGrid1_MouseDown(object sender, MouseEventArgs e)
    {
        RowUIElement ancestor;
        UIElement lastElementEntered = this.UltraGrid1.DisplayLayout.UIElement.LastElementEntered;
        if (lastElementEntered is RowUIElement)
        {
            ancestor = (RowUIElement) lastElementEntered;
        }
        else
        {
            ancestor = (RowUIElement) lastElementEntered.GetAncestor(typeof(RowUIElement));
        }

        if ((ancestor != null) && ((e.Button == MouseButtons.Left) && (e.Clicks == 2)))
        {
            UltraGridRow context = null;
            context = (UltraGridRow) this.UltraGrid1.DisplayLayout.UIElement.ElementFromPoint(e.Location).GetContext(typeof(UltraGridRow));
            if ((context != null) && context.IsDataRow)
            {
                context.Selected = true;
                this.Odaberi();
            }
        }
    }

    private void UltraToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
    {
    }

    public void Zakljucaj_Sve_Obracune()
    {
        SqlConnection connection = new SqlConnection {
            ConnectionString = Configuration.ConnectionString
        };
        connection.Open();
        SqlCommand command = new SqlCommand {
            CommandType = CommandType.Text,
            Connection = connection,
            CommandText = "update obracun set zaklj = 1"
        };
        try
        {
            command.ExecuteNonQuery();
            RowEnumerator enumerator = this.UltraGrid1.Rows.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Cells["zaklj"].Value = 1;
            }
        }
        catch (System.Exception exception1)
        {
            throw exception1;
            
            
        }
        connection.Close();
    }

    private Panel frmPregledObracuna_Fill_Panel;

    public object ObracunSelected
    {
        get
        {
            object objectValue = new object();
            if ((this.drv != null) && (this.cm.Count != 0))
            {
                objectValue = RuntimeHelpers.GetObjectValue(this.drv["idobracun"]);
            }
            return objectValue;
        }
        set
        {
            this.ObracunSelected = RuntimeHelpers.GetObjectValue(value);
        }
    }

    public object OdabraniGodinaIsplate
    {
        get
        {
            object objectValue = new object();
            if ((this.drv != null) && (this.cm.Count != 0))
            {
                objectValue = RuntimeHelpers.GetObjectValue(this.drv["godinaisplate"]);
            }
            return objectValue;
        }
        set
        {
            this.OdabraniGodinaIsplate = RuntimeHelpers.GetObjectValue(value);
        }
    }

    public object OdabraniMjesecIsplate
    {
        get
        {
            object objectValue = new object();
            if ((this.drv != null) && (this.cm.Count != 0))
            {
                objectValue = RuntimeHelpers.GetObjectValue(this.drv["mjesecisplate"]);
            }
            return objectValue;
        }
        set
        {
            this.OdabraniMjesecIsplate = RuntimeHelpers.GetObjectValue(value);
        }
    }

    private PregledObracunaDataSet PregledObracunaDataSet1;

    private UltraButton UltraButton1;

    private UltraButton UltraButton2;

    private UltraButton UltraButton3;

    private UltraButton UltraButton4;

    private UltraGrid UltraGrid1;

    public object Zakljucano
    {
        get
        {
            object objectValue = new object();
            if ((this.drv != null) && (this.cm.Count != 0))
            {
                objectValue = RuntimeHelpers.GetObjectValue(this.drv["zaklj"]);
            }
            return objectValue;
        }
        set
        {
            this.Zakljucano = RuntimeHelpers.GetObjectValue(value);
        }
    }


    private void UltraGrid1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            UltraButton2_Click(null, null);
        }
    }
}

