using Deklarit.Practices.CompositeUI;
using Hlp;
using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.ObjectBuilder;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using My.Resources;
using NetAdvantage.Controllers;
using NetAdvantage.WorkItems;
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
    [SmartPart]
    public class DatotekaHZZO : UserControl, ISmartPartInfoProvider, IFilteredView
    {
        private IContainer components { get; set; }
        
        private string nazivkorisnika;
        public string Obracun;
        private int olaksica;

        private SmartPartInfoProvider infoProvider;
        internal Button ButtonDatotekaUniverzalna;
        private UltraTextEditor PozivNaBrojZaduzenja;
        private UltraLabel UltraLabel2;
        private UltraTextEditor ModelZaduzenja;
        private UltraLabel UltraLabel3;
        private SmartPartInfo smartPartInfo1;

        public DatotekaHZZO()
        {
            base.Load += new EventHandler(this.DisketaHZZO_Load);
            this.olaksica = -1;
            this.Obracun = "";
            this.smartPartInfo1 = new SmartPartInfo("Datoteka HZZO", "Datoteka HZZO");
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.KreirajDIsketu();
        }

        private void DisketaHZZO_Load(object sender, EventArgs e)
        {
            KORISNIKDataAdapter adapter = new KORISNIKDataAdapter();
            KORISNIKDataSet dataSet = new KORISNIKDataSet();
            adapter.Fill(dataSet);
            this.rkdp.Value = DB.N2T(RuntimeHelpers.GetObjectValue(dataSet.KORISNIK.Rows[0]["rkp"]), "99999");
            this.nazivkorisnika = Conversions.ToString(dataSet.KORISNIK.Rows[0]["KORISNIK1NAZIV"]);
            this.datum.Value = DateAndTime.Today;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            this.Button1 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.PozivNaBrojZaduzenja = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.UltraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ModelZaduzenja = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.UltraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ButtonDatotekaUniverzalna = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.UltraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.datum = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.Label2 = new System.Windows.Forms.Label();
            this.sifraugovaratelja = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.rkdp = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PozivNaBrojZaduzenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelZaduzenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sifraugovaratelja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkdp)).BeginInit();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(9, 192);
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
            this.GroupBox1.Controls.Add(this.ButtonDatotekaUniverzalna);
            this.GroupBox1.Controls.Add(this.Button1);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.UltraButton1);
            this.GroupBox1.Controls.Add(this.datum);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.sifraugovaratelja);
            this.GroupBox1.Controls.Add(this.rkdp);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(8, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(384, 233);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // PozivNaBrojZaduzenja
            // 
            this.PozivNaBrojZaduzenja.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.PozivNaBrojZaduzenja.Location = new System.Drawing.Point(164, 152);
            this.PozivNaBrojZaduzenja.MaxLength = 22;
            this.PozivNaBrojZaduzenja.Name = "PozivNaBrojZaduzenja";
            this.PozivNaBrojZaduzenja.Size = new System.Drawing.Size(184, 21);
            this.PozivNaBrojZaduzenja.TabIndex = 16;
            // 
            // UltraLabel2
            // 
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextVAlignAsString = "Middle";
            this.UltraLabel2.Appearance = appearance3;
            this.UltraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel2.Location = new System.Drawing.Point(9, 152);
            this.UltraLabel2.Name = "UltraLabel2";
            this.UltraLabel2.Size = new System.Drawing.Size(149, 23);
            this.UltraLabel2.TabIndex = 15;
            this.UltraLabel2.Tag = "";
            this.UltraLabel2.Text = "Poziv na broj zaduženja:";
            // 
            // ModelZaduzenja
            // 
            this.ModelZaduzenja.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.ModelZaduzenja.Location = new System.Drawing.Point(164, 128);
            this.ModelZaduzenja.MaxLength = 2;
            this.ModelZaduzenja.Name = "ModelZaduzenja";
            this.ModelZaduzenja.Size = new System.Drawing.Size(28, 21);
            this.ModelZaduzenja.TabIndex = 14;
            // 
            // UltraLabel3
            // 
            appearance.ForeColor = System.Drawing.Color.Black;
            appearance.TextVAlignAsString = "Middle";
            this.UltraLabel3.Appearance = appearance;
            this.UltraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.UltraLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UltraLabel3.Location = new System.Drawing.Point(9, 128);
            this.UltraLabel3.Name = "UltraLabel3";
            this.UltraLabel3.Size = new System.Drawing.Size(149, 23);
            this.UltraLabel3.TabIndex = 13;
            this.UltraLabel3.Tag = "";
            this.UltraLabel3.Text = "Model za PNB zaduženja:";
            // 
            // ButtonDatotekaUniverzalna
            // 
            this.ButtonDatotekaUniverzalna.Location = new System.Drawing.Point(195, 192);
            this.ButtonDatotekaUniverzalna.Name = "ButtonDatotekaUniverzalna";
            this.ButtonDatotekaUniverzalna.Size = new System.Drawing.Size(153, 23);
            this.ButtonDatotekaUniverzalna.TabIndex = 12;
            this.ButtonDatotekaUniverzalna.Text = "Kreiraj univerzalnu datoteku";
            this.ButtonDatotekaUniverzalna.UseVisualStyleBackColor = true;
            this.ButtonDatotekaUniverzalna.Click += new System.EventHandler(this.ButtonDatotekaUniverzalna_Click);
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(4, 69);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(154, 23);
            this.Label3.TabIndex = 11;
            this.Label3.Text = "Datum uplate:";
            // 
            // UltraButton1
            // 
            this.UltraButton1.Location = new System.Drawing.Point(164, 97);
            this.UltraButton1.Name = "UltraButton1";
            this.UltraButton1.Size = new System.Drawing.Size(154, 23);
            this.UltraButton1.TabIndex = 10;
            this.UltraButton1.Text = "Olakšica (odabir)";
            this.UltraButton1.Click += new System.EventHandler(this.UltraButton1_Click);
            // 
            // datum
            // 
            this.datum.Location = new System.Drawing.Point(164, 69);
            this.datum.Name = "datum";
            this.datum.Size = new System.Drawing.Size(154, 21);
            this.datum.TabIndex = 9;
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(4, 43);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(154, 23);
            this.Label2.TabIndex = 8;
            this.Label2.Text = "Šifr. ugovaratelja:";
            // 
            // sifraugovaratelja
            // 
            this.sifraugovaratelja.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.sifraugovaratelja.Location = new System.Drawing.Point(164, 41);
            this.sifraugovaratelja.MaxLength = 8;
            this.sifraugovaratelja.Name = "sifraugovaratelja";
            this.sifraugovaratelja.Size = new System.Drawing.Size(154, 21);
            this.sifraugovaratelja.TabIndex = 7;
            // 
            // rkdp
            // 
            this.rkdp.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.rkdp.Location = new System.Drawing.Point(164, 14);
            this.rkdp.MaxLength = 7;
            this.rkdp.Name = "rkdp";
            this.rkdp.Size = new System.Drawing.Size(154, 21);
            this.rkdp.TabIndex = 6;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(4, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(154, 23);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "RKDP:";
            // 
            // DatotekaHZZO
            // 
            this.Controls.Add(this.GroupBox1);
            this.Name = "DatotekaHZZO";
            this.Size = new System.Drawing.Size(400, 252);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PozivNaBrojZaduzenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModelZaduzenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sifraugovaratelja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkdp)).EndInit();
            this.ResumeLayout(false);

        }

        private void KreirajDIsketu()
        {
            string strPoziv = this.sifraugovaratelja.Text + "90";
            strPoziv = strPoziv + Razno.KontrolniBroj(strPoziv);
            string str = "up5924-" + this.rkdp.Text + "-" + strPoziv;
            SaveFileDialog dialog2 = new SaveFileDialog
            {
                InitialDirectory = Conversions.ToString(0),
                FileName = str,
                RestoreDirectory = true
            };
            SaveFileDialog dialog = dialog2;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (this.SnimiDisketuZaHZZO(dialog.FileName))
                {
                    MessageBox.Show("Datoteka za HZZO uspješno kreirana.");
                }
                else
                {
                    MessageBox.Show("Greška prilikom kreiranja HZZO datoteke.");
                }
            }
        }

        private bool SnimiDisketuZaHZZO(string strNazivDatoteke)
        {
            bool flag = false;
            if (this.olaksica == -1)
            {
                Interaction.MsgBox("Potrebno je odabrati olakšicu za koju želite izraditi datoteku", MsgBoxStyle.OkOnly, null);
                return flag;
            }
            try
            {
                IEnumerator enumerator = null;
                SqlConnection connection = new SqlConnection(Configuration.ConnectionString);
                SqlCommand selectCommand = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
                selectCommand.Connection = connection;
                S_OD_REKAP_OLAKSICEDataAdapter adapter2 = new S_OD_REKAP_OLAKSICEDataAdapter();
                S_OD_REKAP_OLAKSICEDataSet dataSet = new S_OD_REKAP_OLAKSICEDataSet();
                object obj2 = adapter2.Fill(dataSet, this.Obracun);
                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Ne postoje obračunate olakšice!");
                    return flag;
                }
                DataView view = new DataView {
                    Table = dataSet.S_OD_REKAP_OLAKSICE
                };
                decimal num3 = DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("Sum(IZNOSOLAKSICE)", "IDOLAKSICE=" + Conversions.ToString(this.olaksica))));
                decimal num = DB.N20(RuntimeHelpers.GetObjectValue(view.Table.Compute("count(idradnik)", "IDOLAKSICE=" + Conversions.ToString(this.olaksica))));
                StreamWriter writer = new StreamWriter(strNazivDatoteke, false, Encoding.ASCII);
                writer.Write("0:5924-");
                writer.Write(DB.BrojVodeceNule(this.rkdp.Text, 5, 0, false, ""));
                string strPoziv = this.sifraugovaratelja.Text + "90";
                strPoziv = strPoziv + Razno.KontrolniBroj(strPoziv);
                writer.Write("-");
                writer.Write(strPoziv);
                writer.Write(":");
                writer.Write(this.nazivkorisnika);
                writer.Write("  :");
                writer.Write(Conversions.ToDate(this.datum.Value).ToString("dd.MM.yyyy"));
                writer.Write(":  ");
                writer.Write(num3.ToString("0.00").Replace(",", "."));
                writer.Write(":" + Conversions.ToString(num));
                writer.WriteLine(":");
                int num2 = 0;
                try
                {
                    enumerator = view.Table.Rows.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DataRow current = (DataRow) enumerator.Current;
                        if (Operators.ConditionalCompareObjectEqual(current["idolaksice"], this.olaksica, false))
                        {
                            num2++;
                            writer.Write("1:5924-");
                            writer.Write(this.rkdp.Text + "-");
                            writer.Write(RuntimeHelpers.GetObjectValue(current["ZADPOJEDINACNIPOZIV"]));
                            writer.Write(":");
                            writer.Write(RuntimeHelpers.GetObjectValue(current["prezime"]));
                            writer.Write(Operators.ConcatenateObject(" ", current["ime"]));
                            writer.Write(":");
                            writer.Write(Conversions.ToDate(this.datum.Value).ToString("dd.MM.yyyy"));
                            writer.Write(":  ");
                            decimal num4 = Conversions.ToDecimal(current["iznosolaksice"]);
                            writer.Write(num4.ToString("0.00").Replace(",", "."));
                            writer.Write(":");
                            writer.Write(num2);
                            writer.WriteLine(":");
                        }
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
                
                //Interaction.MsgBox("Greška prilikom kreiranja datoteke za HZZO", MsgBoxStyle.OkOnly, null);
                //flag = false;
            }
            return flag;
        }

        private void UltraButton1_Click(object sender, EventArgs e)
        {
            OLAKSICESelectionListWorkItem item = this.Controller.WorkItem.Items.AddNew<OLAKSICESelectionListWorkItem>("Olaksice");
            DataRow row = item.ShowModal(true, "", null);
            item.Terminate();
            if (row != null)
            {
                this.olaksica = Conversions.ToInteger(row["idolaksice"]);
            }
        }

        private Button Button1;

        [CreateNew]
        public RSmObrazacController Controller { get; set; }

        private UltraDateTimeEditor datum;

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.FillByRow
        {
            set
            {
            }
        }

        string Deklarit.Practices.CompositeUI.IFilteredView.FillMethod
        {
            set
            {
            }
        }

        DataRow Deklarit.Practices.CompositeUI.IFilteredView.SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        Deklarit.Practices.CompositeUI.WorkWithMode Deklarit.Practices.CompositeUI.IFilteredView.WorkWithMode
        {
            set
            {
            }
        }

        public DataRow FillByRow
        {
            set
            {
            }
        }

        public string FillMethod
        {
            set
            {
            }
        }

        private GroupBox GroupBox1;

        private Label Label1;

        private Label Label2;

        private Label Label3;

        private UltraTextEditor rkdp;

        public DataRow SelectedRow
        {
            get
            {
                DataRow row = null;
                return row;
            }
        }

        private UltraTextEditor sifraugovaratelja;

        private UltraButton UltraButton1;

        Deklarit.Practices.CompositeUI.WorkWithMode WorkWithMode
        {
            set
            {
            }
        }

        private void ButtonDatotekaUniverzalna_Click(object sender, EventArgs e)
        {
        }
    }
}

