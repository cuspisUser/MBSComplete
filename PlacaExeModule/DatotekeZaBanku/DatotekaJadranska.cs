using Hlp;
using Infragistics.Win;
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

    public class DatotekaJadranska : UserControl
    {
        private IContainer components { get; set; }
        public string Obracun;
        private string VBDI;
        public string Ziro;
        internal Button ButtonDatotekaUniverzalna;
        private UltraTextEditor PozivNaBrojZaduzenja;
        private Infragistics.Win.Misc.UltraLabel UltraLabel2;
        private UltraTextEditor ModelZaduzenja;
        private Infragistics.Win.Misc.UltraLabel UltraLabel3;
        private string ZRNBANKE;

        public DatotekaJadranska()
        {
            base.Load += new EventHandler(this.DatotekaJadranska_Load);
            this.Obracun = "";
            this.Ziro = "";
            this.ZRNBANKE = "0";
            this.VBDI = My.Resources.ResourcesPlacaExe.VBDIJADRANSKA;
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.SnimiDatoteku();
        }

        private bool Datoteka_Jadranska(string sDatoteka)
        {
            bool flag = false;
            try
            {
                IEnumerator enumerator = null;
                SqlConnection connection = new SqlConnection(Configuration.ConnectionString);
                SqlCommand selectCommand = new SqlCommand();
                SqlDataAdapter adapter2 = new SqlDataAdapter(selectCommand);
                selectCommand.Connection = connection;
                selectCommand.CommandText = "SELECT ZRNBANKE FROM BANKE WHERE VBDIBANKE = '" + this.VBDI + "'";
                selectCommand.CommandType = CommandType.Text;
                adapter2 = new SqlDataAdapter(selectCommand);
                DataTable dataTable = new DataTable();
                adapter2.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    this.ZRNBANKE = Conversions.ToString(dataTable.Rows[0]["zrnbanke"]);
                }
                sp_diskete_za_bankuDataAdapter adapter = new sp_diskete_za_bankuDataAdapter();
                sp_diskete_za_bankuDataSet dataSet = new sp_diskete_za_bankuDataSet();
                object obj2 = adapter.Fill(dataSet, this.Obracun, this.VBDI);
                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Ne postoje isplate za JADRANSKU banku!");
                    return flag;
                }
                decimal vNumber = DB.N20(RuntimeHelpers.GetObjectValue(dataSet.Tables[0].Compute("Sum(UKUPNOZAISPLATU)", "")));
                StreamWriter writer = new StreamWriter(sDatoteka, false, Encoding.ASCII);
                StreamWriter writer2 = writer;
                writer2.Write("00   ");
                writer2.Write(this.utxtSifraPoduzeca.Text);
                writer2.Write(DB.BrojVodeceNule(DB.N20(vNumber), 13, 2, false, ""));
                writer2.Write(Strings.Space(10));
                writer2.Write("\r\n");
                int num2 = 0;
                try
                {
                    enumerator = dataSet.Tables[0].Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        writer2.Write("11");
                        writer2.Write(DB.BrojVodeceNule(DB.N20(RuntimeHelpers.GetObjectValue(current["TEKUCI"])), 10, 0, false, ""));
                        writer2.Write(DB.BrojVodeceNule(DB.N20(RuntimeHelpers.GetObjectValue(current["UKUPNOZAISPLATU"])), 13, 2, false, ""));
                        writer2.Write(Strings.Space(10));
                        writer2.Write("\r\n");
                        num2++;
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
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

        private void DatotekaJadranska_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);
            SqlCommand selectCommand = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            selectCommand.Connection = connection;
            selectCommand.CommandText = "SELECT ZRNBANKE FROM BANKE WHERE VBDIBANKE = '" + this.VBDI + "'";
            selectCommand.CommandType = CommandType.Text;
            adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                this.ZRNBANKE = Conversions.ToString(dataTable.Rows[0]["zrnbanke"]);
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

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.ButtonDatotekaUniverzalna = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.PozivNaBrojZaduzenja = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ModelZaduzenja = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.utxtSifraPoduzeca = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PozivNaBrojZaduzenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelZaduzenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utxtSifraPoduzeca)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel2.Controls.Add(this.ButtonDatotekaUniverzalna);
            this.Panel2.Controls.Add(this.Button1);
            this.Panel2.Location = new System.Drawing.Point(8, 119);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(360, 24);
            this.Panel2.TabIndex = 1;
            // 
            // ButtonDatotekaUniverzalna
            // 
            this.ButtonDatotekaUniverzalna.Location = new System.Drawing.Point(194, 0);
            this.ButtonDatotekaUniverzalna.Name = "ButtonDatotekaUniverzalna";
            this.ButtonDatotekaUniverzalna.Size = new System.Drawing.Size(153, 23);
            this.ButtonDatotekaUniverzalna.TabIndex = 7;
            this.ButtonDatotekaUniverzalna.Text = "Kreiraj univerzalnu datoteku";
            this.ButtonDatotekaUniverzalna.UseVisualStyleBackColor = true;
            this.ButtonDatotekaUniverzalna.Click += new System.EventHandler(this.ButtonDatotekaUniverzalna_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(6, 0);
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
            this.GroupBox1.Controls.Add(this.utxtSifraPoduzeca);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(8, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(360, 100);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // PozivNaBrojZaduzenja
            // 
            this.PozivNaBrojZaduzenja.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.PozivNaBrojZaduzenja.Location = new System.Drawing.Point(160, 64);
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
            this.UltraLabel2.Location = new System.Drawing.Point(5, 64);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(149, 23);
            this.UltraLabel2.TabIndex = 10;
            this.UltraLabel2.Tag = "";
            this.UltraLabel2.Text = "Poziv na broj zaduženja:";
            // 
            // ModelZaduzenja
            // 
            this.ModelZaduzenja.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ModelZaduzenja.Location = new System.Drawing.Point(160, 40);
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
            this.UltraLabel3.Location = new System.Drawing.Point(5, 40);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(149, 23);
            this.UltraLabel3.TabIndex = 8;
            this.UltraLabel3.Tag = "";
            this.UltraLabel3.Text = "Model za PNB zaduženja:";
            // 
            // utxtSifraPoduzeca
            // 
            this.utxtSifraPoduzeca.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.utxtSifraPoduzeca.Location = new System.Drawing.Point(160, 16);
            this.utxtSifraPoduzeca.MaxLength = 7;
            this.utxtSifraPoduzeca.Name = "utxtSifraPoduzeca";
            this.utxtSifraPoduzeca.Size = new System.Drawing.Size(86, 21);
            this.utxtSifraPoduzeca.TabIndex = 6;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(4, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(150, 23);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "MB  bez vodeće nule:";
            // 
            // DatotekaJadranska
            // 
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Panel2);
            this.Name = "DatotekaJadranska";
            this.Size = new System.Drawing.Size(376, 151);
            this.Panel2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PozivNaBrojZaduzenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelZaduzenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utxtSifraPoduzeca)).EndInit();
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
                    if (this.Datoteka_Jadranska(dialog.FileName))
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

        private GroupBox GroupBox1;

        private Label Label1;

        private Panel Panel2;

        private UltraTextEditor utxtSifraPoduzeca;

        private void ButtonDatotekaUniverzalna_Click(object sender, EventArgs e)
        {
            frmRadSaBankama frmRadSaBankama = (frmRadSaBankama)this.ParentForm;
            frmRadSaBankama.IzradiDatotekuZbrojnogNalogaPoBanci(this.VBDI, null, this.ModelZaduzenja.Text, this.PozivNaBrojZaduzenja.Text);
        }
    }
}

