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
    public class DatotekaOTP : UserControl
    {
        public string adresa;
        public string adresa2;
        private IContainer components { get; set; }
        public KORISNIKDataAdapter daKor;
        public KORISNIKDataSet dsKor;
        public string MB;
        public string Model;
        public string naziv;
        public string Poziv;
        public string racun;
        public string Sifra;
        public string sifraObracuna;
        private string VBDI;
        internal Button ButtonDatotekaUniverzalna;
        private UltraTextEditor PozivNaBrojZaduzenja;
        private UltraLabel UltraLabel2;
        private UltraTextEditor ModelZaduzenja;
        private UltraLabel ultraLabel4;
        public string Ziro;

        public DatotekaOTP()
        {
            base.Load += new EventHandler(this.DatotekaOTP_Load);
            this.sifraObracuna = "";
            this.Ziro = "";
            this.VBDI = My.Resources.ResourcesPlacaExe.VBDIOTP;
            this.MB = "";
            this.daKor = new KORISNIKDataAdapter();
            this.dsKor = new KORISNIKDataSet();
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.SnimiDisketu();
        }

        private bool Datoteka_OTP(string NazivDatoteke)
        {
            bool flag = false;
            try
            {
                IEnumerator enumerator = null;
                int vBroj = 0;
                SqlConnection connection = new SqlConnection(Configuration.ConnectionString);
                SqlCommand selectCommand = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                selectCommand.Connection = connection;
                selectCommand.CommandText = "S_PLACA_ISPLATE_ZA_BANKU";
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.Parameters.Add("@IDOBRACUN", SqlDbType.VarChar).Value = this.sifraObracuna;
                selectCommand.Parameters.Add("@VBDIBANKE", SqlDbType.VarChar).Value = this.VBDI;
                adapter = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                object left = adapter.Fill(dataTable);
                if (Operators.ConditionalCompareObjectEqual(left, 0, false))
                {
                    MessageBox.Show("Ne postoje isplate za OTP banku");
                    return flag;
                }
                decimal num2 = DB.N20(RuntimeHelpers.GetObjectValue(dataTable.Compute("Sum(UKUPNOZAISPLATU)", "")));
                StreamWriter writer = new StreamWriter(NazivDatoteke, false, Encoding.GetEncoding(0x4e2));
                StreamWriter writer2 = writer;
                writer2.Write("PLAC");
                writer2.Write(DB.BrojVodeceNule(RuntimeHelpers.GetObjectValue(this.dsKor.KORISNIK.Rows[0]["MBKORISNIK"]), 8, 0, false, ""));
                writer2.Write(this.Vrati_String_Potrebne_Duzine(Conversions.ToString(this.dsKor.KORISNIK.Rows[0]["KORISNIK1NAZIV"]), 0x23));
                writer2.Write(this.Ziro.Replace("-", ""));
                writer2.Write(this.Vrati_String_Potrebne_Duzine(this.Model, 2));
                writer2.Write(this.Vrati_String_Potrebne_Duzine(this.Poziv, 0x16));
                writer2.Write(this.Vrati_String_Potrebne_Duzine("Isplata plaće", 0x23));
                writer2.Write(RuntimeHelpers.GetObjectValue(Interaction.IIf(this.ultraDTDatum.Text.Trim() == "", "        ", Conversions.ToDate(this.ultraDTDatum.Value).ToString("ddMMyyyy"))));
                writer2.Write(DB.BrojVodeceNule(num2, 15, 2, false, ""));
                writer2.Write(DB.BrojVodeceNule(RuntimeHelpers.GetObjectValue(left), 5, 0, false, ""));
                writer2.Write(this.Vrati_String_Potrebne_Duzine(Conversions.ToString(this.dsKor.KORISNIK.Rows[0]["KONTAKTOSOBA"]), 0x23));
                writer2.Write(this.Vrati_String_Potrebne_Duzine(Conversions.ToString(this.dsKor.KORISNIK.Rows[0]["KONTAKTTELEFON"]), 15));
                writer2.Write(Strings.Space(6));
                writer2.Write("0");
                writer2.Write("\r\n");
                int num3 = 0;
                try
                {
                    enumerator = dataTable.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        vBroj++;
                        writer2.Write(this.Vrati_String_Potrebne_Duzine(Conversions.ToString(DB.N20(RuntimeHelpers.GetObjectValue(current["TEKUCI"]))), 12));
                        writer2.Write(DB.BrojVodeceNule(DB.N20(RuntimeHelpers.GetObjectValue(current["UKUPNOZAISPLATU"])), 13, 2, false, ""));
                        writer2.Write(DB.BrojVodeceNule(vBroj, 5, 0, false, ""));
                        writer2.Write(Strings.Space(0x23));
                        writer2.Write(this.Vrati_String_Potrebne_Duzine(this.ultratxtSifra.Text, 20));
                        writer2.Write(Strings.Space(0x7a));
                        writer2.Write("3");
                        writer2.Write("\r\n");
                        num3++;
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                writer2 = null;
                writer.Close();
                flag = true;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                //Interaction.MsgBox(string.Format("Greška", new object[0]), MsgBoxStyle.OkOnly, null);
                //flag = false;
            }
            return flag;
        }

        private void DatotekaOTP_Load(object sender, EventArgs e)
        {
            this.ultraDTDatum.Value = DateTime.Today;
            this.ultratxtSifra.Value = "0";
            this.ultraDTDatum.Focus();
            this.ultraDTDatum.Select();
            this.ultraDTDatum.SelectAll();
            this.ultraDTDatum.KeyPress += new KeyPressEventHandler(InfraCustom.G_PretvoriEnterUTab_UltraKeyPress);
            this.ultratxtSifra.KeyPress += new KeyPressEventHandler(InfraCustom.G_PretvoriEnterUTab_UltraKeyPress);
            this.daKor.Fill(this.dsKor);
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.ButtonDatotekaUniverzalna = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.PozivNaBrojZaduzenja = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ModelZaduzenja = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultratxtSifra = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraDTDatum = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.UltraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.Panel2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PozivNaBrojZaduzenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelZaduzenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultratxtSifra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDTDatum)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel2.Controls.Add(this.ButtonDatotekaUniverzalna);
            this.Panel2.Controls.Add(this.Button1);
            this.Panel2.Location = new System.Drawing.Point(8, 140);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(392, 24);
            this.Panel2.TabIndex = 1;
            // 
            // ButtonDatotekaUniverzalna
            // 
            this.ButtonDatotekaUniverzalna.Location = new System.Drawing.Point(206, 1);
            this.ButtonDatotekaUniverzalna.Name = "ButtonDatotekaUniverzalna";
            this.ButtonDatotekaUniverzalna.Size = new System.Drawing.Size(153, 23);
            this.ButtonDatotekaUniverzalna.TabIndex = 7;
            this.ButtonDatotekaUniverzalna.Text = "Kreiraj univerzalnu datoteku";
            this.ButtonDatotekaUniverzalna.UseVisualStyleBackColor = true;
            this.ButtonDatotekaUniverzalna.Click += new System.EventHandler(this.ButtonDatotekaUniverzalna_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(28, 1);
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
            this.GroupBox1.Controls.Add(this.UltraLabel2);
            this.GroupBox1.Controls.Add(this.ModelZaduzenja);
            this.GroupBox1.Controls.Add(this.ultraLabel4);
            this.GroupBox1.Controls.Add(this.ultratxtSifra);
            this.GroupBox1.Controls.Add(this.UltraLabel3);
            this.GroupBox1.Controls.Add(this.ultraDTDatum);
            this.GroupBox1.Controls.Add(this.UltraLabel1);
            this.GroupBox1.Location = new System.Drawing.Point(8, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(392, 127);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // PozivNaBrojZaduzenja
            // 
            this.PozivNaBrojZaduzenja.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.PozivNaBrojZaduzenja.Location = new System.Drawing.Point(167, 90);
            this.PozivNaBrojZaduzenja.MaxLength = 22;
            this.PozivNaBrojZaduzenja.Name = "PozivNaBrojZaduzenja";
            this.PozivNaBrojZaduzenja.Size = new System.Drawing.Size(184, 21);
            this.PozivNaBrojZaduzenja.TabIndex = 11;
            // 
            // UltraLabel2
            // 
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextVAlignAsString = "Middle";
            this.UltraLabel2.Appearance = appearance3;
            this.UltraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel2.Location = new System.Drawing.Point(12, 90);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(149, 23);
            this.UltraLabel2.TabIndex = 10;
            this.UltraLabel2.Tag = "";
            this.UltraLabel2.Text = "Poziv na broj zaduženja:";
            // 
            // ModelZaduzenja
            // 
            this.ModelZaduzenja.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ModelZaduzenja.Location = new System.Drawing.Point(167, 66);
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
            this.ultraLabel4.Location = new System.Drawing.Point(12, 66);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(149, 23);
            this.ultraLabel4.TabIndex = 8;
            this.ultraLabel4.Tag = "";
            this.ultraLabel4.Text = "Model za PNB zaduženja:";
            // 
            // ultratxtSifra
            // 
            this.ultratxtSifra.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultratxtSifra.Location = new System.Drawing.Point(167, 40);
            this.ultratxtSifra.MaxLength = 20;
            this.ultratxtSifra.Name = "ultratxtSifra";
            this.ultratxtSifra.Size = new System.Drawing.Size(144, 21);
            this.ultratxtSifra.TabIndex = 5;
            // 
            // UltraLabel3
            // 
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.UltraLabel3.Appearance = appearance1;
            this.UltraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel3.Location = new System.Drawing.Point(12, 40);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(130, 23);
            this.UltraLabel3.TabIndex = 4;
            this.UltraLabel3.Tag = "";
            this.UltraLabel3.Text = "Identifikator korisnika:";
            // 
            // ultraDTDatum
            // 
            this.ultraDTDatum.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ultraDTDatum.Location = new System.Drawing.Point(167, 16);
            this.ultraDTDatum.Name = "ultraDTDatum";
            this.ultraDTDatum.Size = new System.Drawing.Size(90, 21);
            this.ultraDTDatum.TabIndex = 1;
            // 
            // UltraLabel1
            // 
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.UltraLabel1.Appearance = appearance2;
            this.UltraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel1.Location = new System.Drawing.Point(12, 16);
            this.UltraLabel1.Name = "UltraLabel1";
            this.UltraLabel1.Size = new System.Drawing.Size(130, 23);
            this.UltraLabel1.TabIndex = 0;
            this.UltraLabel1.Tag = "";
            this.UltraLabel1.Text = "Datum uplate:";
            // 
            // DatotekaOTP
            // 
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Panel2);
            this.Name = "DatotekaOTP";
            this.Size = new System.Drawing.Size(408, 172);
            this.Panel2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PozivNaBrojZaduzenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelZaduzenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultratxtSifra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDTDatum)).EndInit();
            this.ResumeLayout(false);

        }

        private void Otp_PopratniList()
        {
        }

        private void SnimiDisketu()
        {
            string str = string.Empty;
            try
            {
                str = str + "PLAC" + DB.BrojVodeceNule(RuntimeHelpers.GetObjectValue(this.dsKor.KORISNIK.Rows[0]["MBKORISNIK"]), 8, 0, false, "") + Conversions.ToDate(this.ultraDTDatum.Value).ToString("ddMMyyyy") + "01.TXT";
                SaveFileDialog dialog2 = new SaveFileDialog {
                    InitialDirectory = Conversions.ToString(0),
                    FileName = str,
                    RestoreDirectory = true
                };
                SaveFileDialog dialog = dialog2;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (this.Datoteka_OTP(dialog.FileName))
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

        public string Vrati_String_Potrebne_Duzine(string str, int potrebna)
        {
            string str2 = string.Empty;
            if (Strings.Len(str) < potrebna)
            {
                str2 = str + Strings.Space(potrebna - Strings.Len(str));
            }
            if (Strings.Len(str) == potrebna)
            {
                str2 = str;
            }
            if (Strings.Len(str) > potrebna)
            {
                str2 = Strings.Left(str, potrebna);
            }
            return str2;
        }

        private Button Button1;

        private GroupBox GroupBox1;

        private Panel Panel2;

        private UltraDateTimeEditor ultraDTDatum;

        private UltraLabel UltraLabel1;

        private UltraLabel UltraLabel3;

        private UltraTextEditor ultratxtSifra;

        private void ButtonDatotekaUniverzalna_Click(object sender, EventArgs e)
        {
            frmRadSaBankama frmRadSaBankama = (frmRadSaBankama)this.ParentForm;
            frmRadSaBankama.IzradiDatotekuZbrojnogNalogaPoBanci(this.VBDI, (DateTime)this.ultraDTDatum.Value, this.ModelZaduzenja.Text, this.PozivNaBrojZaduzenja.Text);
        }
    }
}

