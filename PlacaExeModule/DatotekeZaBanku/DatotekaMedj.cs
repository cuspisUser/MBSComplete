using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My.Resources;
using Placa;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;


namespace DatotekeZaBanku
{
    public class DatotekaMedj : UserControl
    {
        private IContainer components { get; set; }
        public string sifraObracuna;
        private string VBDI;
        internal Button ButtonDatotekaUniverzalna;
        private UltraTextEditor PozivNaBrojZaduzenja;
        private UltraLabel ultraLabel3;
        private UltraTextEditor ModelZaduzenja;
        private UltraLabel ultraLabel4;
        public string Ziro;

        public DatotekaMedj()
        {
            base.Load += new EventHandler(this.DatotekaMedjmurska_Load);
            this.sifraObracuna = "";
            this.Ziro = "";
            this.VBDI = My.Resources.ResourcesPlacaExe.VBDIMEDJ;
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.SnimiDatoteku();
        }

        private bool Datoteka_Medjimurska(string nazivDatoteke)
        {
            bool flag = false;
            try
            {
                IEnumerator enumerator = null;
                string vBroj = "";
                string str4 = "";
                string str2 = "";
                string str = "";
                SqlConnection connection = new SqlConnection(Configuration.ConnectionString);
                SqlCommand selectCommand = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                selectCommand.Connection = connection;
                selectCommand.CommandText = "SELECT KORISNIK1NAZIV,vbdikorisnik, zirokorisnik FROM KORISNIKlevel1 INNER JOIN KORISNIK ON KORISNIKLEVEL1.IDKORISNIK = KORISNIK.IDKORISNIK WHERE vbdikorisnik = '2392007'";
                selectCommand.CommandType = CommandType.Text;
                adapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    vBroj = Conversions.ToString(dataTable.Rows[0]["vbdikorisnik"]);
                    str4 = Conversions.ToString(dataTable.Rows[0]["zirokorisnik"]);
                    str = dataTable.Rows[0]["korisnik1naziv"].ToString().Substring(0, 6);
                }
                if (vBroj != "2392007")
                {
                    MessageBox.Show("Žiro račun u Međimurskoj banci nije otvoren - otvorite žiroračun prije kreiranja datoteke!", "Kreiranje datoteke za banku!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return flag;
                }
                selectCommand.CommandText = "SELECT OPISPLACANJABANKE FROM BANKE WHERE VBDIBANKE = @VBDI";
                selectCommand.Parameters.Add("@VBDI", SqlDbType.VarChar).Value = this.VBDI;
                selectCommand.CommandType = CommandType.Text;
                adapter = new SqlDataAdapter(selectCommand);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    str2 = Conversions.ToString(dataTable.Rows[0]["OPISPLACANJABANKE"]).TrimEnd(new char[0]) + " " + this.sifraObracuna;
                }
                if (vBroj != "2392007")
                {
                    MessageBox.Show("Nemate žiro račun otvoren u  Međimurskoj banci");
                    return flag;
                }
                selectCommand.Parameters.Clear();
                selectCommand.CommandText = "S_PLACA_ISPLATE_ZA_BANKU";
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add("@IDOBRACUN", SqlDbType.VarChar).Value = this.sifraObracuna;
                selectCommand.Parameters.Add("@VBDIBANKE", SqlDbType.VarChar).Value = this.VBDI;
                adapter = new SqlDataAdapter(selectCommand);
                DataTable table2 = new DataTable();
                if (adapter.Fill(table2) == 0)
                {
                    MessageBox.Show("Ne postoje isplate za Međimursku banku");
                    return flag;
                }
                StreamWriter writer = new StreamWriter(nazivDatoteke, false, Encoding.ASCII);
                int num = 0;
                try
                {
                    enumerator = table2.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        StreamWriter writer2 = writer;
                        writer2.Write("330*");
                        writer2.Write("11*");
                        writer2.Write(DB.BrojVodeceNule(DB.N20(RuntimeHelpers.GetObjectValue(current["TEKUCI"])), 10, 0, false, "") + "*");
                        writer2.Write(RuntimeHelpers.GetObjectValue(Interaction.IIf(this.DatumKnjizenja.Text.Trim() == "", "", Conversions.ToDate(this.DatumKnjizenja.Value).ToString("dd.MM.yyyy") + "*")));
                        writer2.Write(RuntimeHelpers.GetObjectValue(Interaction.IIf(this.DatumValute.Text.Trim() == "", "", Conversions.ToDate(this.DatumValute.Value).ToString("dd.MM.yyyy") + "*")));
                        writer2.Write(DB.BrojVodeceNule(DB.N20(RuntimeHelpers.GetObjectValue(current["UKUPNOZAISPLATU"])), 0, 2, true, ".") + "*");
                        writer2.Write(str + "*");
                        writer2.Write("8071*");
                        writer2.Write("170*");
                        writer2.Write("000*");
                        writer2.Write(DB.BrojVodeceNule(vBroj, 7, 0, false, "") + "-" + DB.BrojVodeceNule(str4, 10, 0, false, "") + "*");
                        writer2.Write(("Plaća  " + str2.Substring(str2.Length - 7, 7)) + "*");
                        writer2.Write("\r\n");
                        writer2 = null;
                        num++;
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                writer.Close();
                flag = true;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                //Interaction.MsgBox("Greška: ", MsgBoxStyle.OkOnly, null);
                //flag = false;
            }
            return flag;
        }

        private void DatotekaMedjmurska_Load(object sender, EventArgs e)
        {
            this.DatumKnjizenja.Value = DateTime.Today;
            this.DatumValute.Value = DateTime.Today;
            this.DatumKnjizenja.Focus();
            this.DatumKnjizenja.Select();
            this.DatumKnjizenja.SelectAll();
            this.DatumKnjizenja.KeyPress += new KeyPressEventHandler(InfraCustom.G_PretvoriEnterUTab_UltraKeyPress);
            this.DatumValute.KeyPress += new KeyPressEventHandler(InfraCustom.G_PretvoriEnterUTab_UltraKeyPress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.ButtonDatotekaUniverzalna = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.PozivNaBrojZaduzenja = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ModelZaduzenja = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.DatumValute = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.DatumKnjizenja = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.UltraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.Panel2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PozivNaBrojZaduzenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelZaduzenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatumValute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatumKnjizenja)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel2.Controls.Add(this.ButtonDatotekaUniverzalna);
            this.Panel2.Controls.Add(this.Button1);
            this.Panel2.Location = new System.Drawing.Point(8, 146);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(360, 24);
            this.Panel2.TabIndex = 1;
            // 
            // ButtonDatotekaUniverzalna
            // 
            this.ButtonDatotekaUniverzalna.Location = new System.Drawing.Point(192, 1);
            this.ButtonDatotekaUniverzalna.Name = "ButtonDatotekaUniverzalna";
            this.ButtonDatotekaUniverzalna.Size = new System.Drawing.Size(153, 23);
            this.ButtonDatotekaUniverzalna.TabIndex = 7;
            this.ButtonDatotekaUniverzalna.Text = "Kreiraj univerzalnu datoteku";
            this.ButtonDatotekaUniverzalna.UseVisualStyleBackColor = true;
            this.ButtonDatotekaUniverzalna.Click += new System.EventHandler(this.ButtonDatotekaUniverzalna_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(12, 1);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(153, 23);
            this.Button1.TabIndex = 3;
            this.Button1.Text = "Kreiraj ";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Visible = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.PozivNaBrojZaduzenja);
            this.GroupBox1.Controls.Add(this.ultraLabel3);
            this.GroupBox1.Controls.Add(this.ModelZaduzenja);
            this.GroupBox1.Controls.Add(this.ultraLabel4);
            this.GroupBox1.Controls.Add(this.DatumValute);
            this.GroupBox1.Controls.Add(this.UltraLabel2);
            this.GroupBox1.Controls.Add(this.DatumKnjizenja);
            this.GroupBox1.Controls.Add(this.UltraLabel1);
            this.GroupBox1.Location = new System.Drawing.Point(8, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(360, 128);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // PozivNaBrojZaduzenja
            // 
            this.PozivNaBrojZaduzenja.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.PozivNaBrojZaduzenja.Location = new System.Drawing.Point(167, 93);
            this.PozivNaBrojZaduzenja.MaxLength = 22;
            this.PozivNaBrojZaduzenja.Name = "PozivNaBrojZaduzenja";
            this.PozivNaBrojZaduzenja.Size = new System.Drawing.Size(184, 21);
            this.PozivNaBrojZaduzenja.TabIndex = 11;
            // 
            // ultraLabel3
            // 
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance3;
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel3.Location = new System.Drawing.Point(12, 93);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(149, 23);
            this.ultraLabel3.TabIndex = 10;
            this.ultraLabel3.Tag = "";
            this.ultraLabel3.Text = "Poziv na broj zaduženja:";
            // 
            // ModelZaduzenja
            // 
            this.ModelZaduzenja.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ModelZaduzenja.Location = new System.Drawing.Point(167, 69);
            this.ModelZaduzenja.MaxLength = 2;
            this.ModelZaduzenja.Name = "ModelZaduzenja";
            this.ModelZaduzenja.Size = new System.Drawing.Size(28, 21);
            this.ModelZaduzenja.TabIndex = 9;
            // 
            // ultraLabel4
            // 
            appearance.ForeColor = System.Drawing.Color.Black;
            appearance.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance;
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ultraLabel4.Location = new System.Drawing.Point(12, 69);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(149, 23);
            this.ultraLabel4.TabIndex = 8;
            this.ultraLabel4.Tag = "";
            this.ultraLabel4.Text = "Model za PNB zaduženja:";
            // 
            // DatumValute
            // 
            this.DatumValute.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.DatumValute.Location = new System.Drawing.Point(167, 42);
            this.DatumValute.Name = "DatumValute";
            this.DatumValute.Size = new System.Drawing.Size(90, 21);
            this.DatumValute.TabIndex = 3;
            // 
            // UltraLabel2
            // 
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.UltraLabel2.Appearance = appearance2;
            this.UltraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel2.Location = new System.Drawing.Point(12, 42);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(131, 23);
            this.UltraLabel2.TabIndex = 2;
            this.UltraLabel2.Tag = "";
            this.UltraLabel2.Text = "Datum valute:";
            // 
            // DatumKnjizenja
            // 
            this.DatumKnjizenja.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.DatumKnjizenja.Location = new System.Drawing.Point(167, 13);
            this.DatumKnjizenja.Name = "DatumKnjizenja";
            this.DatumKnjizenja.Size = new System.Drawing.Size(90, 21);
            this.DatumKnjizenja.TabIndex = 1;
            // 
            // UltraLabel1
            // 
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.UltraLabel1.Appearance = appearance1;
            this.UltraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel1.Location = new System.Drawing.Point(12, 16);
            this.UltraLabel1.Name = "UltraLabel1";
            this.UltraLabel1.Size = new System.Drawing.Size(131, 23);
            this.UltraLabel1.TabIndex = 0;
            this.UltraLabel1.Tag = "";
            this.UltraLabel1.Text = "Datum knjiženja:";
            // 
            // DatotekaMedj
            // 
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Panel2);
            this.Name = "DatotekaMedj";
            this.Size = new System.Drawing.Size(376, 178);
            this.Panel2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PozivNaBrojZaduzenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelZaduzenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatumValute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatumKnjizenja)).EndInit();
            this.ResumeLayout(false);

        }

        private void SnimiDatoteku()
        {
            try
            {
                SaveFileDialog dialog2 = new SaveFileDialog {
                    InitialDirectory = Conversions.ToString(0),
                    FileName = "PLACA.TXT",
                    RestoreDirectory = true
                };
                SaveFileDialog dialog = dialog2;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (this.Datoteka_Medjimurska(dialog.FileName))
                    {
                        MessageBox.Show(My.Resources.ResourcesPlacaExe.DATOTEKAUSPJESNO);
                    }
                    else
                    {
                        MessageBox.Show(My.Resources.ResourcesPlacaExe.DATOTEKANEUSPJESNO);
                    }
                }
            }
            catch (System.Exception exception1)
            {
                throw exception1;                
            }
        }

        private Button Button1;

        private UltraDateTimeEditor DatumKnjizenja;

        private UltraDateTimeEditor DatumValute;

        private GroupBox GroupBox1;

        private Panel Panel2;

        private UltraLabel UltraLabel1;

        private UltraLabel UltraLabel2;

        private void ButtonDatotekaUniverzalna_Click(object sender, EventArgs e)
        {
            frmRadSaBankama frmRadSaBankama = (frmRadSaBankama)this.ParentForm;
            frmRadSaBankama.IzradiDatotekuZbrojnogNalogaPoBanci(this.VBDI, (DateTime)this.DatumValute.Value, this.ModelZaduzenja.Text, this.PozivNaBrojZaduzenja.Text);
        }
    }
}

