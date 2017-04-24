using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;
using Deklarit.Practices.CompositeUI;
using Microsoft.VisualBasic.CompilerServices;
using System.Data.SqlClient;

namespace FinPosModule.ZatvaranjeBolnice
{

    [SmartPart]
    partial class ZatvaranjeFormBolniceSmartPart : UserControl, ISmartPartInfoProvider
    {
        Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
        private SmartPartInfo smartPartInfo1;
        private SmartPartInfoProvider infoProvider;

        public ISmartPartInfo GetSmartPartInfo(Type smartPartInfoType)
        {
            return this.infoProvider.GetSmartPartInfo(smartPartInfoType);
        }

        private void SetSmartPartInfoInformation()
        {
            this.smartPartInfo1.Description = "Zatvaranje stavaka";
        }

        public ZatvaranjeFormBolniceSmartPart()
        {
            InitializeComponent();
            this.smartPartInfo1 = new SmartPartInfo(string.Format("Zatvaranje stavaka", "Zatvaranje stavaka"), string.Format(Deklarit.Resources.Resources.WorkWithTitle, "Zatvaranje stavaka"));
            this.infoProvider = new SmartPartInfoProvider();
            this.infoProvider.Items.Add(this.smartPartInfo1);

            NapuniPartnere();
        }
        private void NapuniPartnere()
        {
            this.ucePartner.DataSource = client.GetDataTable("Select IDPARTNER As ID, (NAZIVPARTNER + ' | ' + PARTNEROIB) As Naziv From PARTNER");
            this.ucePartner.DataBind();
        }

        private void NapuniRacune()
        {
            this.ugdRacuni.DataSource = client.GetDataTable("Select GKSTAVKA.IDGKSTAVKA,  DOKUMENT.NAZIVDOKUMENT As Dokument, GKSTAVKA.BROJDOKUMENTA As Broj, GKGODIDGODINE As Godina, GKSTAVKA.DATUMDOKUMENTA As 'Dat.Dok.', GKSTAVKA.IDKONTO As Konto, " + 
                                        "GKSTAVKA.Duguje, GKSTAVKA.Potrazuje, GKSTAVKA.Opis, GKSTAVKA.IDDOKUMENT As 'Šifra dokumenta' From GKSTAVKA " +
                                        "Inner Join Dokument On GKSTAVKA.IDDOKUMENT = DOKUMENT.IDDOKUMENT Where GKSTAVKA.IDPARTNER = '" + ucePartner.Value + "' And GKSTAVKA.IDGKSTAVKA Not In (Select GK1IDGKSTAVKA From ZATVARANJA) And " +
                                        "GKSTAVKA.IDDOKUMENT = 3  Order by Broj");
            this.ugdRacuni.DataBind();

            if (ugdRacuni.Rows.Count > 0)
            {
                ugdRacuni.DisplayLayout.Bands[0].Columns[0].Hidden = true;
            }
        }


        [LocalCommandHandler("PoveziStavke")]
        public void PoveziStavkeHandler(object sender, EventArgs e)
        {
            this.ZatvoriStavke();
        }

        [LocalCommandHandler("UcitajDatoteku")]
        public void UcitajDatotekuHandler(object sender, EventArgs e)
        {
            this.UcitajDatoteku();
        }

        private void ZatvoriStavke()
        {
            //SetZatvaranje(ugdRacuni.ActiveRow, ugdIzvodi.ActiveRow);
            InsertIzvodZatvaranje(ugdIzvodi.Rows);
            this.Cursor = Cursors.Default;
        }

        private void InsertIzvodZatvaranje(Infragistics.Win.UltraWinGrid.RowsCollection izvodi)
        {
            using (OdabirKonta objekt = new OdabirKonta())
            {
                SqlCommand sqlUpit = new SqlCommand();
                sqlUpit.Connection = client.sqlConnection;
                sqlUpit.CommandType = CommandType.Text;

                string idKonto = "";
                int idgkstavkaIzvod = 0;
                int idgkstavkaRacun = 0;
                int izvod = 0;
                int brojStavke = 0;
                DataTable racun = new DataTable();
                
                if (objekt.ShowDialogForm("Odabir konta") == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;

                    idKonto = objekt.idKonto;

                    izvod = GetNextIzvod(izvodi[0].Cells["iraGodina"].Value);

                    foreach (var item in izvodi)
                    {
                        racun = client.GetDataTable("Select * From GKSTAVKA Where IDDOKUMENT = 3 And BROJDOKUMENTA = '" + item.Cells["iraBroj"].Value + "' And GKGODIDGODINE = '" + item.Cells["iraGodina"].Value + "' And duguje > 0");
                        brojStavke = 1;

                        foreach (DataRow row in racun.Rows)
                        {
                            idgkstavkaRacun = Convert.ToInt32(row[0]);

                            //prvi red na potrazu stranu na konto jedinice
                            sqlUpit.CommandText = "Insert Into GKSTAVKA (DATUMDOKUMENTA, BROJDOKUMENTA, BROJSTAVKE, IDDOKUMENT, IDMJESTOTROSKA, IDORGJED, IDKONTO, OPIS, duguje, POTRAZUJE, " +
                                "DATUMPRIJAVE, IDPARTNER, ZATVORENIIZNOS, statusgk, ORIGINALNIDOKUMENT, GKGODIDGODINE, GKDATUMVALUTE) Values " +
                                "('" + Convert.ToDateTime(item.Cells["datum"].Value).ToString("yyyy-MM-dd") + "', " + izvod + ", " + brojStavke + ", 4, '" + row["IDMJESTOTROSKA"].ToString() + "', '"
                                + row["IDORGJED"].ToString() + "', '" + row["IDKONTO"].ToString() + "', 'Izvod', '0', '" + row["duguje"].ToString().Replace(',', '.') + "', '" +
                                Convert.ToDateTime(row["DATUMPRIJAVE"]).ToString("yyyy-MM-dd") + "', '" + row["IDPARTNER"] + "', '0', '1', '" + row["ORIGINALNIDOKUMENT"] + "', '" + row["GKGODIDGODINE"] +
                                "', '" + Convert.ToDateTime(row["GKDATUMVALUTE"]).ToString("yyyy-MM-dd") + "') Select @@Identity";

                            idgkstavkaIzvod = Convert.ToInt32(sqlUpit.ExecuteScalar());

                            
                            brojStavke++;

                            //drugi red na dugovnu stranu na konto ziroracuna
                            sqlUpit.CommandText = "Insert Into GKSTAVKA (DATUMDOKUMENTA, BROJDOKUMENTA, BROJSTAVKE, IDDOKUMENT, IDMJESTOTROSKA, IDORGJED, IDKONTO, OPIS, duguje, POTRAZUJE, " +
                                "DATUMPRIJAVE, ZATVORENIIZNOS, statusgk, ORIGINALNIDOKUMENT, GKGODIDGODINE, GKDATUMVALUTE) Values " +
                                "('" + Convert.ToDateTime(item.Cells["datum"].Value).ToString("yyyy-MM-dd") + "', " + izvod + ", " + brojStavke + ", 4, '" + row["IDMJESTOTROSKA"].ToString() + "', '"
                                + row["IDORGJED"].ToString() + "', '" + idKonto + "', 'Izvod', '" + row["duguje"].ToString().Replace(',', '.') + "', '0', '" +
                                Convert.ToDateTime(row["DATUMPRIJAVE"]).ToString("yyyy-MM-dd") + "', '0', '1', '" + row["ORIGINALNIDOKUMENT"] + "', '" + row["GKGODIDGODINE"] +
                                "', '" + Convert.ToDateTime(row["GKDATUMVALUTE"]).ToString("yyyy-MM-dd") + "') Select @@Identity";

                            sqlUpit.ExecuteNonQuery();
                            
                            izvod++;
                        }

                        sqlUpit.CommandText = "Insert Into ZATVARANJA (GK1IDGKSTAVKA, GK2IDGKSTAVKA, ZATVARANJAIZNOS) " +
                                                  "Values ('" + idgkstavkaRacun + "', '" + idgkstavkaIzvod + "', '" + item.Cells["iznosPlaceno"].Value.ToString().Replace(',', '.') + "')";

                        sqlUpit.ExecuteNonQuery();
                        idgkstavkaIzvod = 0;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                } 
            }
        }

        private int GetNextIzvod(object p)
        {
            try
            {
                return Convert.ToInt32(client.ExecuteScalar("Select Max(BROJDOKUMENTA) From GKSTAVKA Where GKGODIDGODINE = '" + p + "' And IDDOKUMENT = 4")) + 1;
            }
            catch { return 1; }
        }

        private void SetZatvaranje(Infragistics.Win.UltraWinGrid.UltraGridRow racun, Infragistics.Win.UltraWinGrid.UltraGridRow izvod)
        {
            string idGk1 = client.ExecuteScalar("Select IDGKSTAVKA From GKSTAVKA Where IDPARTNER is Not NULL And BROJDOKUMENTA = " + racun.Cells["Broj"].Value).ToString();

            string idGk2 = client.ExecuteScalar("Select IDGKSTAVKA From GKSTAVKA Where IDPARTNER is NULL And BROJDOKUMENTA = " + racun.Cells["Broj"].Value).ToString();

            client.ExecuteNonQuery("");

            racun.Delete();
            izvod.Delete();
        }

        private void UcitajDatoteku()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    List<Zatvaranje> zatvaranja = GetZatvaranja(ofd.FileName);

                    this.ugdIzvodi.DataSource = zatvaranja;
                    this.ugdIzvodi.DataBind();
                }
            }
        }

        private List<Zatvaranje> GetZatvaranja(string path)
        {
            if (!path.ToLower().EndsWith("unl"))
            {
                return null;
            }

            string plainText = System.IO.File.ReadAllText(path, System.Text.Encoding.UTF8);
            string[] racuniZatvaranja = plainText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string[] rowField;

            List<Zatvaranje> zatvaranja = new List<Zatvaranje>();
            Zatvaranje objekt;
            Nullable<int> sifra;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                foreach (var item in racuniZatvaranja)
                {
                    if (item.Length == 0)
                    {
                        continue;
                    }
                    rowField = item.Split('|');
                    objekt = new Zatvaranje();

                    objekt.tipDokumenta = "Izvod";
                    sifra = FindIRA(rowField[2]);
                    if (sifra != null)
                    {
                        objekt.iraBroj = (int)sifra;
                        objekt.iraGodina = FindGodina(rowField[2]);
                        objekt.sifraDokumenta = 4;
                        objekt.datum = Convert.ToDateTime(rowField[3]);
                        objekt.iznosRacun = Convert.ToDecimal(rowField[6].Replace('.', ','));
                        objekt.iznosPlaceno = Convert.ToDecimal(rowField[7].Replace('.', ','));

                        zatvaranja.Add(objekt);
                    }
                    else
                    {
                        MessageBox.Show("Dokument u zatvaranjima nije pronaden u listi racuna!!!");
                        break;
                    }
                }
            }
            catch { Cursor.Current = Cursors.Default; }

            Cursor.Current = Cursors.Default;

            return zatvaranja;
        }

        private int FindGodina(string sifraBis)
        {
            return Convert.ToInt32(client.ExecuteScalar("Select IRAGODIDGODINE From IRA Where SifraBIS = '" + sifraBis + "'"));
        }

        private int? FindIRA(string sifraBis)
        {
            try
            {
                return Convert.ToInt32(client.ExecuteScalar("Select IRABROJ From IRA Where SifraBIS = '" + sifraBis + "'"));
            }
            catch { return null; }
        }

        class Zatvaranje
        {
            public string tipDokumenta { get; set; }
            public int iraBroj { get; set; }
            public int iraGodina { get; set;}
            public DateTime datum { get; set; }
            public decimal iznosPlaceno { get; set; }
            public decimal iznosRacun { get; set; }
            public int sifraDokumenta { get; set; }
        }


        private void ugdRacuni_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        private void ugdIzvodi_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
        }

        private void ucePartner_ValueChanged(object sender, EventArgs e)
        {
            NapuniRacune();
        }

    }
}
