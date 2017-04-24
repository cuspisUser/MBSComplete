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
    public class DatotekaHPB : UserControl
    {
        private IContainer components { get; set; }
        public string SifraObracuna;
        private string vbdiBanke;
        internal Button ButtonDatotekaUniverzalna;
        private UltraTextEditor PozivNaBrojZaduzenja;
        private UltraLabel UltraLabel2;
        private UltraTextEditor ModelZaduzenja;
        private UltraLabel UltraLabel3;
        public string Ziro;

        public DatotekaHPB()
        {
            base.Load += new EventHandler(this.DatotekaHPB_Load);
            this.SifraObracuna = "";
            this.Ziro = "";
            this.vbdiBanke = My.Resources.ResourcesPlacaExe.VBDIHPB;
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.SnimiDatoteku();
        }

        private bool Datoteka_HPB(string strNazivDatoteke)
        {
            bool flag = false;
            try
            {
                IEnumerator enumerator = null;
                string str2 = "0";
                string str3 = "0";
                string str = "";
                SqlConnection connection = new SqlConnection(Configuration.ConnectionString);
                SqlCommand selectCommand = new SqlCommand();
                SqlDataAdapter adapter4 = new SqlDataAdapter(selectCommand);
                selectCommand.Connection = connection;
                KORISNIKDataSet dataSet = new KORISNIKDataSet();
                new KORISNIKDataAdapter().Fill(dataSet);
                str2 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["MBKORISNIK"]);
                str3 = Conversions.ToString(dataSet.KORISNIK.Rows[0]["MBKORISNIKJEDINICA"]);
                if (str3.Length > 3)
                {
                    str3 = str3.Substring(0, 3);
                }
                VIRMANIDataAdapter adapter3 = new VIRMANIDataAdapter();
                Placa.VIRMANIDataSet set = new Placa.VIRMANIDataSet();
                adapter3.FillBySIFRAOBRACUNAVIRMAN(set, this.SifraObracuna);
                str = Conversions.ToString(set.VIRMANI.Rows[0]["brojracunapla"]);
                sp_diskete_za_bankuDataAdapter adapter = new sp_diskete_za_bankuDataAdapter();
                sp_diskete_za_bankuDataSet set3 = new sp_diskete_za_bankuDataSet();
                int num2 = adapter.Fill(set3, this.SifraObracuna, this.vbdiBanke);
                if (set3.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Ne postoje isplate za HPB banku!");
                    return flag;
                }
                decimal vBroj = Conversions.ToDecimal(set3.Tables[0].Compute("Sum(UKUPNOZAISPLATU)", ""));
                StreamWriter writer = new StreamWriter(strNazivDatoteke, false, Encoding.ASCII);
                StreamWriter writer2 = writer;
                writer2.Write("98");
                writer2.Write(new string(' ', 0x77));
                writer2.Write("0");
                writer2.Write("\r\n");
                writer2.Write("94");
                writer2.Write(str.PadRight(0x15));
                writer2.Write(RuntimeHelpers.GetObjectValue(Interaction.IIf(this.DatumUplate.Text.Trim() == "", "      ", Conversions.ToDate(this.DatumUplate.Value).ToString("ddMMyy"))));
                writer2.Write(RuntimeHelpers.GetObjectValue(Interaction.IIf(this.DatumUplate.Text.Trim() == "", "      ", Conversions.ToDate(this.DatumUplate.Value).ToString("ddMMyy"))));
                writer2.Write(DB.BrojVodeceNule(vBroj, 13, 2, false, ""));
                writer2.Write(new string('0', 60));
                writer2.Write(new string(' ', 11));
                writer2.Write("0");
                writer2.Write("\r\n");
                int num3 = 0;
                try
                {
                    enumerator = set3.Tables[0].Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        writer2.Write("070000011");
                        writer2.Write("2");
                        writer2.Write(new string(' ', 10));
                        writer2.Write(DB.BrojVodeceNule(DB.N20(RuntimeHelpers.GetObjectValue(current["TEKUCI"])), 11, 0, false, ""));
                        writer2.Write(DB.BrojVodeceNule(DB.N20(RuntimeHelpers.GetObjectValue(current["UKUPNOZAISPLATU"])), 9, 2, false, ""));
                        writer2.Write(RuntimeHelpers.GetObjectValue(Interaction.IIf(this.DatumUplate.Text.Trim() == "", "      ", Conversions.ToDate(this.DatumUplate.Value).ToString("ddMMyy"))));
                        writer2.Write(new string(' ', 0x49));
                        writer2.Write("0");
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
                writer2.Write("99");
                writer2.Write(new string(' ', 0x77));
                writer2.Write("0");
                writer2.Write("\r\n");
                writer2.Close();
                writer2 = null;
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

        private void DatotekaHPB_Load(object sender, EventArgs e)
        {
            InfraCustom.PostaviSelectAllSvimEditKontrolama(this);
            InfraCustom.PostaviEnterUTabSvimEditKontrolama(this);
            this.DatumUplate.Value = DateTime.Today;
            this.DatumUplate.Focus();
            this.DatumUplate.KeyPress += new KeyPressEventHandler(InfraCustom.G_PretvoriEnterUTab_UltraKeyPress);
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
            this.Panel2 = new System.Windows.Forms.Panel();
            this.ButtonDatotekaUniverzalna = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.PozivNaBrojZaduzenja = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ModelZaduzenja = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.DatumUplate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.UltraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.Panel2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PozivNaBrojZaduzenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelZaduzenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatumUplate)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel2.Controls.Add(this.ButtonDatotekaUniverzalna);
            this.Panel2.Controls.Add(this.Button1);
            this.Panel2.Location = new System.Drawing.Point(8, 128);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(376, 24);
            this.Panel2.TabIndex = 1;
            // 
            // ButtonDatotekaUniverzalna
            // 
            this.ButtonDatotekaUniverzalna.Location = new System.Drawing.Point(186, 0);
            this.ButtonDatotekaUniverzalna.Name = "ButtonDatotekaUniverzalna";
            this.ButtonDatotekaUniverzalna.Size = new System.Drawing.Size(153, 23);
            this.ButtonDatotekaUniverzalna.TabIndex = 7;
            this.ButtonDatotekaUniverzalna.Text = "Kreiraj univerzalnu datoteku";
            this.ButtonDatotekaUniverzalna.UseVisualStyleBackColor = true;
            this.ButtonDatotekaUniverzalna.Click += new System.EventHandler(this.ButtonDatotekaUniverzalna_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(12, 0);
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
            this.GroupBox1.Controls.Add(this.UltraLabel3);
            this.GroupBox1.Controls.Add(this.DatumUplate);
            this.GroupBox1.Controls.Add(this.UltraLabel1);
            this.GroupBox1.Location = new System.Drawing.Point(8, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(376, 114);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // PozivNaBrojZaduzenja
            // 
            this.PozivNaBrojZaduzenja.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.PozivNaBrojZaduzenja.Location = new System.Drawing.Point(167, 69);
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
            this.UltraLabel2.Location = new System.Drawing.Point(12, 69);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(149, 23);
            this.UltraLabel2.TabIndex = 10;
            this.UltraLabel2.Tag = "";
            this.UltraLabel2.Text = "Poziv na broj zaduženja:";
            // 
            // ModelZaduzenja
            // 
            this.ModelZaduzenja.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ModelZaduzenja.Location = new System.Drawing.Point(167, 45);
            this.ModelZaduzenja.MaxLength = 2;
            this.ModelZaduzenja.Name = "ModelZaduzenja";
            this.ModelZaduzenja.Size = new System.Drawing.Size(28, 21);
            this.ModelZaduzenja.TabIndex = 9;
            // 
            // UltraLabel3
            // 
            appearance.ForeColor = System.Drawing.Color.Black;
            appearance.TextVAlignAsString = "Middle";
            this.UltraLabel3.Appearance = appearance;
            this.UltraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel3.Location = new System.Drawing.Point(12, 45);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(149, 23);
            this.UltraLabel3.TabIndex = 8;
            this.UltraLabel3.Tag = "";
            this.UltraLabel3.Text = "Model za PNB zaduženja:";
            // 
            // DatumUplate
            // 
            this.DatumUplate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.DatumUplate.Location = new System.Drawing.Point(167, 18);
            this.DatumUplate.Name = "DatumUplate";
            this.DatumUplate.Size = new System.Drawing.Size(90, 21);
            this.DatumUplate.TabIndex = 1;
            this.DatumUplate.UseAppStyling = false;
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
            this.UltraLabel1.Size = new System.Drawing.Size(113, 23);
            this.UltraLabel1.TabIndex = 0;
            this.UltraLabel1.Tag = "";
            this.UltraLabel1.Text = "Datum uplate:";
            // 
            // DatotekaHPB
            // 
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Panel2);
            this.Name = "DatotekaHPB";
            this.Size = new System.Drawing.Size(392, 160);
            this.Panel2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PozivNaBrojZaduzenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelZaduzenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatumUplate)).EndInit();
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
                    if (this.Datoteka_HPB(dialog.FileName))
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

        private UltraDateTimeEditor DatumUplate;

        private GroupBox GroupBox1;

        private Panel Panel2;

        private UltraLabel UltraLabel1;

        private void ButtonDatotekaUniverzalna_Click(object sender, EventArgs e)
        {
            frmRadSaBankama frmRadSaBankama = (frmRadSaBankama)this.ParentForm;
            frmRadSaBankama.IzradiDatotekuZbrojnogNalogaPoBanci(this.vbdiBanke, (DateTime)this.DatumUplate.Value, this.ModelZaduzenja.Text, this.PozivNaBrojZaduzenja.Text);
        }
    }
}

