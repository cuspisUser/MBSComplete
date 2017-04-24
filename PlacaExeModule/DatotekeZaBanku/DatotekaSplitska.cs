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

public class DatotekaSplitska : UserControl
{
    private IContainer components { get; set; }
    public string sifraObracuna;
    private string VBDI;
    internal Button ButtonDatotekaUniverzalna;
    private UltraTextEditor PozivNaBrojZaduzenja;
    private UltraLabel UltraLabel2;
    private UltraTextEditor ModelZaduzenja;
    private UltraLabel UltraLabel3;
    public string Ziro;

    public DatotekaSplitska()
    {
        base.Load += new EventHandler(this.DatotekaSPLITSKA_Load);
        this.sifraObracuna = "";
        this.Ziro = "";
        this.VBDI = My.Resources.ResourcesPlacaExe.VBDISPLITSKA;
        this.InitializeComponent();
    }

    private void btnGeneriraj_Click(object sender, EventArgs e)
    {
        this.SnimiDatoteku();
    }

    private bool Datoteka_Splitska(string sDatoteka)
    {
        bool flag = false;
        try
        {
            IEnumerator enumerator = null;
            string str = "";
            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);
            SqlCommand selectCommand = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            selectCommand.Connection = connection;
            selectCommand.CommandText = "SELECT KORISNIK1NAZIV FROM KORISNIK WHERE IDKORISNIK = 1";
            selectCommand.CommandType = CommandType.Text;
            adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                str = Conversions.ToString(dataTable.Rows[0]["KORISNIK1NAZIV"]);
            }
            sp_diskete_za_bankuDataAdapter adapter2 = new sp_diskete_za_bankuDataAdapter();
            sp_diskete_za_bankuDataSet dataSet = new sp_diskete_za_bankuDataSet();
            int num3 = adapter2.Fill(dataSet, this.sifraObracuna, this.VBDI);
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Ne postoje isplate za Splitsku banku");
                return flag;
            }
            decimal vBroj = DB.N20(RuntimeHelpers.GetObjectValue(dataSet.Tables[0].Compute("Sum(UKUPNOZAISPLATU)", "")));
            StreamWriter writer = new StreamWriter(sDatoteka, false, Encoding.ASCII);
            writer.Write("ST");
            writer.Write(RuntimeHelpers.GetObjectValue(Interaction.IIf(this.udteDatumUplate.Text.Trim() == "", "      ", Conversions.ToDate(this.udteDatumUplate.Value).ToString("ddMMyy"))));
            writer.Write(DB.BrojVodeceNule(vBroj, 13, 2, false, ""));
            writer.Write("\r\n");
            writer.Write("ST");
            writer.Write(str.PadRight(0x19).Substring(0, 0x19));
            writer.Write("\r\n");
            int num2 = 0;
            try
            {
                enumerator = dataSet.Tables[0].Rows.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    DataRow current = (DataRow) enumerator.Current;
                    writer.Write(DB.BrojVodeceNule(DB.N20(RuntimeHelpers.GetObjectValue(current["TEKUCI"])), 11, 0, false, ""));
                    writer.Write(DB.BrojVodeceNule(DB.N20(RuntimeHelpers.GetObjectValue(current["UKUPNOZAISPLATU"])), 13, 2, false, ""));
                    writer.Write(" ");
                    writer.Write("\r\n");
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
            writer.Close();
            flag = true;
        }
        catch (System.Exception exception1)
        {
            throw exception1;
            
            //Interaction.MsgBox("Greška", MsgBoxStyle.OkOnly, null);
            //flag = false;
        }
        return flag;
    }

    private void DatotekaSPLITSKA_Load(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection(Configuration.ConnectionString);
        SqlCommand selectCommand = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
        selectCommand.Connection = connection;
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.ButtonDatotekaUniverzalna = new System.Windows.Forms.Button();
            this.btnGeneriraj = new Infragistics.Win.Misc.UltraButton();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.PozivNaBrojZaduzenja = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ModelZaduzenja = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.udteDatumUplate = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.UltraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.Panel2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PozivNaBrojZaduzenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelZaduzenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteDatumUplate)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel2.Controls.Add(this.ButtonDatotekaUniverzalna);
            this.Panel2.Controls.Add(this.btnGeneriraj);
            this.Panel2.Location = new System.Drawing.Point(8, 122);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(360, 24);
            this.Panel2.TabIndex = 1;
            // 
            // ButtonDatotekaUniverzalna
            // 
            this.ButtonDatotekaUniverzalna.Location = new System.Drawing.Point(185, 0);
            this.ButtonDatotekaUniverzalna.Name = "ButtonDatotekaUniverzalna";
            this.ButtonDatotekaUniverzalna.Size = new System.Drawing.Size(153, 23);
            this.ButtonDatotekaUniverzalna.TabIndex = 7;
            this.ButtonDatotekaUniverzalna.Text = "Kreiraj univerzalnu datoteku";
            this.ButtonDatotekaUniverzalna.UseVisualStyleBackColor = true;
            this.ButtonDatotekaUniverzalna.Click += new System.EventHandler(this.ButtonDatotekaUniverzalna_Click);
            // 
            // btnGeneriraj
            // 
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Left;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.btnGeneriraj.Appearance = appearance1;
            this.btnGeneriraj.BackColorInternal = System.Drawing.Color.LightSteelBlue;
            this.btnGeneriraj.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton;
            this.btnGeneriraj.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnGeneriraj.ImageSize = new System.Drawing.Size(24, 16);
            this.btnGeneriraj.Location = new System.Drawing.Point(8, 0);
            this.btnGeneriraj.Name = "btnGeneriraj";
            this.btnGeneriraj.ShowFocusRect = false;
            this.btnGeneriraj.ShowOutline = false;
            this.btnGeneriraj.Size = new System.Drawing.Size(149, 24);
            this.btnGeneriraj.TabIndex = 0;
            this.btnGeneriraj.Text = "Kreiraj datoteku";
            this.btnGeneriraj.Visible = false;
            this.btnGeneriraj.WrapText = false;
            this.btnGeneriraj.Click += new System.EventHandler(this.btnGeneriraj_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.PozivNaBrojZaduzenja);
            this.GroupBox1.Controls.Add(this.UltraLabel2);
            this.GroupBox1.Controls.Add(this.ModelZaduzenja);
            this.GroupBox1.Controls.Add(this.UltraLabel3);
            this.GroupBox1.Controls.Add(this.udteDatumUplate);
            this.GroupBox1.Controls.Add(this.UltraLabel1);
            this.GroupBox1.Location = new System.Drawing.Point(8, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(360, 108);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // PozivNaBrojZaduzenja
            // 
            this.PozivNaBrojZaduzenja.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.PozivNaBrojZaduzenja.Location = new System.Drawing.Point(163, 67);
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
            this.UltraLabel2.Location = new System.Drawing.Point(8, 67);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(149, 23);
            this.UltraLabel2.TabIndex = 10;
            this.UltraLabel2.Tag = "";
            this.UltraLabel2.Text = "Poziv na broj zaduženja:";
            // 
            // ModelZaduzenja
            // 
            this.ModelZaduzenja.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ModelZaduzenja.Location = new System.Drawing.Point(163, 43);
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
            this.UltraLabel3.Location = new System.Drawing.Point(8, 43);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(149, 23);
            this.UltraLabel3.TabIndex = 8;
            this.UltraLabel3.Tag = "";
            this.UltraLabel3.Text = "Model za PNB zaduženja:";
            // 
            // udteDatumUplate
            // 
            this.udteDatumUplate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.udteDatumUplate.Location = new System.Drawing.Point(163, 18);
            this.udteDatumUplate.Name = "udteDatumUplate";
            this.udteDatumUplate.Size = new System.Drawing.Size(90, 21);
            this.udteDatumUplate.TabIndex = 3;
            // 
            // UltraLabel1
            // 
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.UltraLabel1.Appearance = appearance2;
            this.UltraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel1.Location = new System.Drawing.Point(8, 16);
            this.UltraLabel1.Name = "UltraLabel1";
            this.UltraLabel1.Size = new System.Drawing.Size(152, 23);
            this.UltraLabel1.TabIndex = 2;
            this.UltraLabel1.Tag = "";
            this.UltraLabel1.Text = "Datum uplate:";
            // 
            // DatotekaSplitska
            // 
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Panel2);
            this.Name = "DatotekaSplitska";
            this.Size = new System.Drawing.Size(376, 154);
            this.Panel2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PozivNaBrojZaduzenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelZaduzenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udteDatumUplate)).EndInit();
            this.ResumeLayout(false);

    }

    private void SnimiDatoteku()
    {
        try
        {
            SaveFileDialog dialog2 = new SaveFileDialog {
                InitialDirectory = Conversions.ToString(0),
                FileName = "DOHODAK.DAT",
                RestoreDirectory = true
            };
            SaveFileDialog dialog = dialog2;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (this.Datoteka_Splitska(dialog.FileName))
                {
                    MessageBox.Show("Datoteka uspješno kreirana");
                }
                else
                {
                    MessageBox.Show("Greška prilikom kreiranja datoteke");
                }
            }
        }
        catch (System.Exception exception1)
        {
            throw exception1;            
        }
    }

    private UltraButton btnGeneriraj;

    private GroupBox GroupBox1;

    private Panel Panel2;

    private UltraDateTimeEditor udteDatumUplate;

    private UltraLabel UltraLabel1;

    private void ButtonDatotekaUniverzalna_Click(object sender, EventArgs e)
    {
        frmRadSaBankama frmRadSaBankama = (frmRadSaBankama)this.ParentForm;
        frmRadSaBankama.IzradiDatotekuZbrojnogNalogaPoBanci(this.VBDI, (DateTime)this.udteDatumUplate.Value, this.ModelZaduzenja.Text, this.PozivNaBrojZaduzenja.Text);
    }
}

