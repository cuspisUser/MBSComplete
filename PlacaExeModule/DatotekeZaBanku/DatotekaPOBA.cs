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
    public class DatotekaPOBA : UserControl
    {
        private IContainer components { get; set; }
        public string sifraObracuna;
        private string VBDI;
        internal Button ButtonDatotekaUniverzalna;
        private UltraTextEditor PozivNaBrojZaduzenja;
        private UltraLabel UltraLabel2;
        private UltraTextEditor ModelZaduzenja;
        private UltraLabel ultraLabel4;
        public string Ziro;

        public DatotekaPOBA()
        {
            base.Load += new EventHandler(this.DatotekaPOBA_Load);
            this.sifraObracuna = "";
            this.Ziro = "";
            this.VBDI = My.Resources.ResourcesPlacaExe.VBDIPOBA;
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.SnimiDatoteku();
        }

        private bool Datoteka_Podravska_Banka(string NazivDatoteke)
        {
            bool flag = false;
            try
            {
                IEnumerator enumerator = null;
                string vBroj = Conversions.ToString(this.BrojPoslovnice.Value);
                string str4 = "0";
                string str = "0";
                string str2 = "0";
                SqlConnection connection = new SqlConnection(Configuration.ConnectionString);
                SqlCommand selectCommand = new SqlCommand();
                SqlDataAdapter adapter2 = new SqlDataAdapter(selectCommand);
                selectCommand.Connection = connection;
                selectCommand.CommandText = "SELECT KORISNIK.MBKORISNIK, KORISNIK.MBKORISNIKJEDINICA FROM KORISNIK WHERE IDKORISNIK = 1";
                selectCommand.CommandType = CommandType.Text;
                adapter2 = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                adapter2.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    str = Conversions.ToString(dataTable.Rows[0]["MBKORISNIK"]);
                    str2 = Conversions.ToString(dataTable.Rows[0]["MBKORISNIKJEDINICA"]);
                    if (str2.Length > 3)
                    {
                        str2 = str2.Substring(0, 3);
                    }
                }
                sp_diskete_za_bankuDataAdapter adapter = new sp_diskete_za_bankuDataAdapter();
                sp_diskete_za_bankuDataSet dataSet = new sp_diskete_za_bankuDataSet();
                int num = adapter.Fill(dataSet, this.sifraObracuna, this.VBDI);
                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Ne postoje isplate za PODRAVSKU banku");
                    return flag;
                }
                decimal num2 = DB.N20(RuntimeHelpers.GetObjectValue(dataSet.Tables[0].Compute("Sum(UKUPNOZAISPLATU)", "")));
                StreamWriter writer = new StreamWriter(NazivDatoteke, false, Encoding.ASCII);
                StreamWriter writer2 = writer;
                writer2.Write("030");
                writer2.Write("0000000");
                writer2.Write("3234495");
                writer2.Write(RuntimeHelpers.GetObjectValue(Interaction.IIf(this.datUplate.Text.Trim() == "", "      ", Conversions.ToDate(this.datUplate.Value).ToString("ddMMyy"))));
                writer2.Write("0000000000000");
                writer2.Write(DB.BrojVodeceNule(num2, 11, 2, false, ""));
                writer2.Write(DB.BrojVodeceNule(num, 4, 0, false, ""));
                writer2.Write(DB.BrojVodeceNule(str, 8, 0, false, ""));
                writer2.Write(DB.BrojVodeceNule(str2, 3, 0, false, ""));
                writer2.Write(new string('0', 6));
                writer2.Write(DB.BrojVodeceNule(vBroj, 6, 0, false, ""));
                writer2.Write("*");
                writer2.Write("   ");
                writer2.Write("\r\n");
                int num3 = 0;
                try
                {
                    enumerator = dataSet.Tables[0].Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        writer2.Write("031");
                        writer2.Write("0000000");
                        writer2.Write(DB.BrojVodeceNule(str4, 6, 0, false, ""));
                        writer2.Write(RuntimeHelpers.GetObjectValue(Interaction.IIf(this.datUplate.Text.Trim() == "", "      ", Conversions.ToDate(this.datUplate.Value).ToString("ddMMyy"))));
                        writer2.Write("01");
                        writer2.Write("50");
                        writer2.Write(DB.BrojVodeceNule(DB.N20(RuntimeHelpers.GetObjectValue(current["UKUPNOZAISPLATU"])), 9, 2, false, ""));
                        writer2.Write(DB.BrojVodeceNule(DB.N20(RuntimeHelpers.GetObjectValue(current["TEKUCI"])), 10, 0, false, ""));
                        writer2.Write(new string('0', 6));
                        writer2.Write(DB.BrojVodeceNule(str, 8, 0, false, ""));
                        writer2.Write(DB.BrojVodeceNule(str2, 3, 0, false, ""));
                        writer2.Write(new string('0', 12));
                        writer2.Write("*");
                        writer2.Write("   ");
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
                
                //Interaction.MsgBox("Greška: ", MsgBoxStyle.OkOnly, null);
                //flag = false;
            }
            return flag;
        }

        private void DatotekaPOBA_Load(object sender, EventArgs e)
        {
            this.datUplate.Value = DateTime.Today;
            this.BrojPoslovnice.Value = "0";
            this.datUplate.Focus();
            this.datUplate.Select();
            this.datUplate.SelectAll();
            this.datUplate.KeyPress += new KeyPressEventHandler(InfraCustom.G_PretvoriEnterUTab_UltraKeyPress);
            this.BrojPoslovnice.KeyPress += new KeyPressEventHandler(InfraCustom.G_PretvoriEnterUTab_UltraKeyPress);
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
            this.BrojPoslovnice = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.datUplate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.UltraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.Panel2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PozivNaBrojZaduzenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelZaduzenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrojPoslovnice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datUplate)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel2.Controls.Add(this.ButtonDatotekaUniverzalna);
            this.Panel2.Controls.Add(this.Button1);
            this.Panel2.Location = new System.Drawing.Point(8, 150);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(360, 24);
            this.Panel2.TabIndex = 1;
            // 
            // ButtonDatotekaUniverzalna
            // 
            this.ButtonDatotekaUniverzalna.Location = new System.Drawing.Point(189, 0);
            this.ButtonDatotekaUniverzalna.Name = "ButtonDatotekaUniverzalna";
            this.ButtonDatotekaUniverzalna.Size = new System.Drawing.Size(153, 23);
            this.ButtonDatotekaUniverzalna.TabIndex = 7;
            this.ButtonDatotekaUniverzalna.Text = "Kreiraj univerzalnu datoteku";
            this.ButtonDatotekaUniverzalna.UseVisualStyleBackColor = true;
            this.ButtonDatotekaUniverzalna.Click += new System.EventHandler(this.ButtonDatotekaUniverzalna_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(25, 0);
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
            this.GroupBox1.Controls.Add(this.BrojPoslovnice);
            this.GroupBox1.Controls.Add(this.UltraLabel3);
            this.GroupBox1.Controls.Add(this.datUplate);
            this.GroupBox1.Controls.Add(this.UltraLabel1);
            this.GroupBox1.Location = new System.Drawing.Point(8, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(360, 136);
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
            // UltraLabel2
            // 
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextVAlignAsString = "Middle";
            this.UltraLabel2.Appearance = appearance3;
            this.UltraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel2.Location = new System.Drawing.Point(12, 93);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(149, 23);
            this.UltraLabel2.TabIndex = 10;
            this.UltraLabel2.Tag = "";
            this.UltraLabel2.Text = "Poziv na broj zaduženja:";
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
            // BrojPoslovnice
            // 
            this.BrojPoslovnice.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.BrojPoslovnice.Location = new System.Drawing.Point(167, 42);
            this.BrojPoslovnice.MaxLength = 8;
            this.BrojPoslovnice.Name = "BrojPoslovnice";
            this.BrojPoslovnice.Size = new System.Drawing.Size(52, 21);
            this.BrojPoslovnice.TabIndex = 5;
            // 
            // UltraLabel3
            // 
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.UltraLabel3.Appearance = appearance1;
            this.UltraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel3.Location = new System.Drawing.Point(12, 41);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(152, 23);
            this.UltraLabel3.TabIndex = 4;
            this.UltraLabel3.Tag = "";
            this.UltraLabel3.Text = "Interni broj poslovnice banke:";
            // 
            // datUplate
            // 
            this.datUplate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.datUplate.Location = new System.Drawing.Point(167, 16);
            this.datUplate.Name = "datUplate";
            this.datUplate.Size = new System.Drawing.Size(90, 21);
            this.datUplate.TabIndex = 1;
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
            this.UltraLabel1.Size = new System.Drawing.Size(115, 23);
            this.UltraLabel1.TabIndex = 0;
            this.UltraLabel1.Tag = "";
            this.UltraLabel1.Text = "Datum uplate:";
            // 
            // DatotekaPOBA
            // 
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Panel2);
            this.Name = "DatotekaPOBA";
            this.Size = new System.Drawing.Size(376, 182);
            this.Panel2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PozivNaBrojZaduzenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelZaduzenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrojPoslovnice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datUplate)).EndInit();
            this.ResumeLayout(false);

        }

        private void SnimiDatoteku()
        {
            try
            {
                string str = "";
                str = str + "PL" + Interaction.IIf(this.datUplate.Text.Trim() == "", DateTime.Now.ToString("ddMMyy"), Conversions.ToDate(this.datUplate.Value).ToString("ddMMyy")).ToString() + ".TXT";
                SaveFileDialog dialog2 = new SaveFileDialog {
                    InitialDirectory = Conversions.ToString(0),
                    FileName = str,
                    RestoreDirectory = true
                };
                SaveFileDialog dialog = dialog2;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (this.Datoteka_Podravska_Banka(dialog.FileName))
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

        private UltraTextEditor BrojPoslovnice;

        private Button Button1;

        private UltraDateTimeEditor datUplate;

        private GroupBox GroupBox1;

        private Panel Panel2;

        private UltraLabel UltraLabel1;

        private UltraLabel UltraLabel3;

        private void ButtonDatotekaUniverzalna_Click(object sender, EventArgs e)
        {
            frmRadSaBankama frmRadSaBankama = (frmRadSaBankama)this.ParentForm;
            frmRadSaBankama.IzradiDatotekuZbrojnogNalogaPoBanci(this.VBDI, (DateTime)this.datUplate.Value, this.ModelZaduzenja.Text, this.PozivNaBrojZaduzenja.Text);
        }
    }
}

