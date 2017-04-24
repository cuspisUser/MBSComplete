using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mipsed7.DataAccessLayer;
using FinPosModule;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

public partial class frmOPZ: Form
{
    SqlClient client = new SqlClient();

    public DateTime datumOd;
    public DateTime datumDo;
    public DataGridView podaci;
    private DateTime nisuNaplaceniDo;
    private DateTime xmlDate { get; set; }

    public frmOPZ()
    {
        InitializeComponent();
    }

    private void btnOdustani_Click(object sender, EventArgs e)
    {
        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Close();
    }

    private void btnGeneriraj_Click(object sender, EventArgs e)
    {
        if (dgvPartneri.Rows.Count < 1)
        {
            return;
        }

        podaci = dgvPartneri;

        this.DialogResult = System.Windows.Forms.DialogResult.OK;

    }

    private void ultraMaskedEdit5_MaskChanged(object sender, Infragistics.Win.UltraWinMaskedEdit.MaskChangedEventArgs e)
    {

    }

    private void groupBox7_Enter(object sender, EventArgs e)
    {

    }

    private void btnDohvat_Click(object sender, EventArgs e)
    {
        if (dtpDatumOd.DateTime == new DateTime(dtpDatumOd.DateTime.Year, 3, 31))
        {
            datumDo = dtpDatumOd.DateTime;
            datumOd = new DateTime(datumDo.Year, 1, 1);
            nisuNaplaceniDo = new DateTime(datumDo.Year, 4, 30);
            xmlDate = datumOd;
        }
        else if (dtpDatumOd.DateTime == new DateTime(dtpDatumOd.DateTime.Year, 6, 30))
        {
            datumDo = dtpDatumOd.DateTime;
            datumOd = new DateTime(datumDo.Year, 4, 1);
            nisuNaplaceniDo = new DateTime(datumDo.Year, 7, 31);
            xmlDate = datumOd;
        }
        else if (dtpDatumOd.DateTime == new DateTime(dtpDatumOd.DateTime.Year, 9, 30))
        {
            datumDo = dtpDatumOd.DateTime;
            datumOd = new DateTime(datumDo.Year, 7, 1);
            nisuNaplaceniDo = new DateTime(datumDo.Year, 10, 31);
            xmlDate = datumOd;
        }
        else if (dtpDatumOd.DateTime == new DateTime(dtpDatumOd.DateTime.Year, 12, 31))
        {
            datumDo = dtpDatumOd.DateTime;
            datumOd = new DateTime(datumDo.Year, 10, 1);
            nisuNaplaceniDo = new DateTime(datumDo.Year + 1, 1, 31);
            xmlDate = new DateTime(datumDo.Year, 1, 1);
        }
        else
        {
            MessageBox.Show("Neispravan datum!");
            return;
        }

        dgvPartneri.DataSource = GetStavke();

        GridStyling();
        UkupanIznosKasnjenje();

        DataRow korisnik = client.GetDataTable("Select * From Korisnik").Rows[0];

        txtNaziv.Text = korisnik["KORISNIK1NAZIV"].ToString().Trim();
        txtOIB.Text = korisnik["KORISNIKOIB"].ToString().Trim();
        txtMjesto.Text = korisnik["KORISNIK1MJESTO"].ToString().Trim();
        txtUlica.Text = korisnik["KORISNIK1ADRESA"].ToString().Trim();
        udtDatumIzrade.Value = DateTime.Now;
        txtSastavioIme.Text = korisnik["KONTAKTOSOBA"].ToString().Trim();
        txtSastavioPrezime.Text = korisnik["KONTAKTOSOBA"].ToString().Trim();
        txtSaPDVom.Value = GetIznosUkupno(datumOd, datumDo, client);
        txtPDV.Value = GetIznosPDV(datumOd, datumDo, client);
        txtEmail.Text = korisnik["EMAIL"].ToString().Trim();
        txtTelefon.Text = korisnik["KONTAKTTELEFON"].ToString().Trim();
        txtFax.Text = korisnik["KONTAKTFAX"].ToString().Trim();
        btnIspis.Visible = false;
    }

    private void UkupanIznosKasnjenje()
    {
        int brojRedova = 0;
        decimal iznosKasnjenja = 0;

        foreach (DataGridViewRow red in dgvPartneri.Rows)
        {
            if (red.Cells[0].Value == null)
            {
                continue;
            }

            brojRedova++;

            if (red.Cells[15].Value.ToString().Length > 0)
            {
                iznosKasnjenja += Convert.ToDecimal(red.Cells[15].Value);
            }
        }

        lblBrojRedova.Text = brojRedova.ToString();
        lblUkupanIznosKasnjenja.Text = iznosKasnjenja.ToString();
    }

    private void GridStyling()
    {
        dgvPartneri.RowHeadersVisible = false;
        dgvPartneri.Columns[0].Visible = false;
        dgvPartneri.Columns[1].Visible = false;
        dgvPartneri.Columns[6].Visible = false;
        dgvPartneri.Columns[11].DefaultCellStyle.Format = "0.00##";
        dgvPartneri.Columns[12].DefaultCellStyle.Format = "0.00##";
        dgvPartneri.Columns[13].DefaultCellStyle.Format = "0.00##";
        dgvPartneri.Columns[2].HeaderText = "Šifra";
        dgvPartneri.Columns[3].HeaderText = "OIB";
        dgvPartneri.Columns[4].HeaderText = "Naziv";
        dgvPartneri.Columns[5].HeaderText = "Oznaka P.B.";
        dgvPartneri.Columns[7].HeaderText = "Br. Računa";
        dgvPartneri.Columns[8].HeaderText = "Dat. Računa";
        dgvPartneri.Columns[9].HeaderText = "Valuta Pl. Rač.";
        dgvPartneri.Columns[10].HeaderText = "Br. dana kašnjenja";
        dgvPartneri.Columns[11].HeaderText = "Iznos Računa";
        dgvPartneri.Columns[12].HeaderText = "Iznos PDV-a";
        dgvPartneri.Columns[13].HeaderText = "Ukupan iznos sa PDV-om";
        dgvPartneri.Columns[14].HeaderText = "Plaćeni iznos";
        dgvPartneri.Columns[15].HeaderText = "Neplaćeni iznos";

        dgvPartneri.Columns[4].Width = 200;
    }

    private DataTable GetStavke()
    {
        DataTable dtStavke = new DataTable();
        SqlCommand sqlComm = new SqlCommand("sp_OPZForma", client.sqlConnection);
        sqlComm.CommandType = CommandType.StoredProcedure;
        sqlComm.Parameters.AddWithValue("@DatumOd", datumOd);
        sqlComm.Parameters.AddWithValue("@DatumDo", datumDo);
        sqlComm.Parameters.AddWithValue("@nisuNaplaceni", nisuNaplaceniDo);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = sqlComm;
        da.Fill(dtStavke);

        return dtStavke;
    }

    private decimal GetIznosPDV(DateTime dateTime1, DateTime dateTime2, Mipsed7.DataAccessLayer.SqlClient conn)
    {
        DataTable tbl = conn.GetDataTable("SELECT IRA.PDV05 + IRA.PDV10 + IRA.PDV22 + IRA.PDV23 + IRA.PDV25 FROM dbo.GKSTAVKA As firstTbl " +
            "INNER JOIN dbo.KONTO ON firstTbl.IDKONTO = dbo.KONTO.IDKONTO INNER JOIN dbo.PARTNER ON firstTbl.IDPARTNER = dbo.PARTNER.IDPARTNER " +
            "Inner Join IRA On firstTbl.BROJDOKUMENTA = IRA.IRABROJ And firstTbl.GKGODIDGODINE = IRA.IRAGODIDGODINE And firstTbl.IDDOKUMENT = IRA.IRADOKIDDOKUMENT " +
            "WHERE KONTO.IDAKTIVNOST > 1 And DATEDIFF(DAY, firstTbl.GKDATUMVALUTE, '" + dateTime2.ToString("yyyy-MM-dd HH:mm:ss") + "') > 0 And PARTNER.Ucenik > 0 " +
            "And (Select ISNULL(SUM(ZATVARANJAIZNOS), 0) From ZATVARANJA Inner Join GKSTAVKA On ZATVARANJA.GK1IDGKSTAVKA = GKSTAVKA.IDGKSTAVKA " +
            "Where GKSTAVKA.DATUMDOKUMENTA <= '" + dateTime2.ToString("yyyy-MM-dd HH:mm:ss") + "' And GK2IDGKSTAVKA = firstTbl.IDGKSTAVKA) <> IRA.IRAUKUPNO And IRA.IRAGODIDGODINE = " + mipsed.application.framework.Application.ActiveYear);

        decimal ukupno = 0;

        foreach (DataRow item in tbl.Rows)
        {
            ukupno += Convert.ToDecimal(item[0]);
        }

        return ukupno;
    }

    private decimal GetIznosUkupno(DateTime dateTime1, DateTime dateTime2, Mipsed7.DataAccessLayer.SqlClient conn)
    {
        DataTable tbl = conn.GetDataTable("SELECT IRA.IRAUKUPNO FROM dbo.GKSTAVKA As firstTbl INNER JOIN dbo.KONTO ON firstTbl.IDKONTO = dbo.KONTO.IDKONTO " +
            "INNER JOIN dbo.PARTNER ON firstTbl.IDPARTNER = dbo.PARTNER.IDPARTNER Inner Join IRA On firstTbl.BROJDOKUMENTA = IRA.IRABROJ And firstTbl.GKGODIDGODINE = IRA.IRAGODIDGODINE " +
            "And firstTbl.IDDOKUMENT = IRA.IRADOKIDDOKUMENT WHERE KONTO.IDAKTIVNOST > 1 And DATEDIFF(DAY, firstTbl.GKDATUMVALUTE, '" + dateTime2.ToString("yyyy-MM-dd HH:mm:ss") + "') > 0 " +
            "And PARTNER.Ucenik > 0 And (Select ISNULL(SUM(ZATVARANJAIZNOS), 0) From ZATVARANJA Inner Join GKSTAVKA On ZATVARANJA.GK1IDGKSTAVKA = GKSTAVKA.IDGKSTAVKA " +
            "Where GKSTAVKA.DATUMDOKUMENTA <= '" + dateTime2.ToString("yyyy-MM-dd HH:mm:ss") + "' And GK2IDGKSTAVKA = firstTbl.IDGKSTAVKA) <> IRA.IRAUKUPNO And IRA.IRAGODIDGODINE = " + mipsed.application.framework.Application.ActiveYear);

        decimal ukupno = 0;

        foreach (DataRow item in tbl.Rows)
        {
            ukupno += Convert.ToDecimal(item[0]);
        }

        return ukupno;
    }

    static Guid StringToGUID(string value)
    {
        MD5 md5Hasher = MD5.Create();
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
        return new Guid(data);
    }

    private void btnXmlDatoteka_Click(object sender, EventArgs e)
    {
        if (dgvPartneri.Rows.Count < 1)
        {
            return;
        }
        var Result = dgvPartneri.Rows.OfType<DataGridViewRow>().Select(
            r => r.Cells.OfType<DataGridViewCell>().Select(c => c.Value).ToArray()).ToList();

        Result.RemoveAt(Result.Count - 1);

        Result = Result.OrderBy(x => x[2]).ThenBy(x => x[7]).ToList();

        StringBuilder error = Validacija(Result);
        if (error.Length > 0)
        {
            MessageBox.Show(error.ToString());
            return;
        }

        int redniBrojKupac = 0;
        int redniBrojRacun = 0;
        int idPartner = 0;
        foreach (var item in Result)
        {
            if ((int)item[2] == idPartner)
            {
                item[0] = redniBrojKupac;

                redniBrojRacun++;
                item[1] = redniBrojRacun;
            }
            else
            {
                redniBrojKupac++;
                item[0] = redniBrojKupac;
                idPartner = (int)item[2];
                redniBrojRacun = 1;
                item[1] = redniBrojRacun;
            }
        }

        OPZShema.sObrazacOPZ dokument = new OPZShema.sObrazacOPZ();

        OPZShema.sOPZmetapodaci metaPodaci = new OPZShema.sOPZmetapodaci();
        metaPodaci.Jezik = new OPZShema.sJezikTemeljni { dc = "http://purl.org/dc/elements/1.1/language", Value = OPZShema.tJezik.hrHR };
        metaPodaci.Uskladjenost = new OPZShema.sUskladjenost { dc = "http://purl.org/dc/terms/conformsTo", Value = "ObrazacOPZ-v1-0" };
        metaPodaci.Tip = new OPZShema.sTipTemeljni { dc = "http://purl.org/dc/elements/1.1/type", Value = OPZShema.tTip.Elektroničkiobrazac };
        metaPodaci.Naslov = new OPZShema.sNaslovTemeljni { dc = "http://purl.org/dc/elements/1.1/title", Value = "Obrazac OPZ" };
        OPZShema.sIdentifikatorTemeljni ident = new OPZShema.sIdentifikatorTemeljni();
        ident.dc = "http://purl.org/dc/elements/1.1/identifier";
        ident.Value = StringToGUID(ident.GetHashCode().ToString()).ToString();
        metaPodaci.Identifikator = ident;
        metaPodaci.Format = new OPZShema.sFormatTemeljni { dc = "http://purl.org/dc/elements/1.1/format", Value = OPZShema.tFormat.textxml };
        metaPodaci.Datum = new OPZShema.sDatumTemeljni { dc = "http://purl.org/dc/elements/1.1/date", Value = udtDatumIzrade.DateTime.ToString("yyyy-MM-ddTHH:mm:ss") };
        metaPodaci.Autor = new OPZShema.sAutorTemeljni { dc = "http://purl.org/dc/elements/1.1/creator", Value = txtNaziv.Text };
        metaPodaci.Adresant = new OPZShema.sAdresantTemeljni { Value = "Ministarstvo Financija, Porezna uprava, Zagreb" };

        OPZShema.sZaglavlje zaglavljePodaci = new OPZShema.sZaglavlje();
        zaglavljePodaci.IzvjesceSastavio = new OPZShema.sIzvjesceSastavio { Email = txtEmail.Text, Fax = txtFax.Text, 
                                                                            Ime = txtSastavioIme.Text, Prezime = txtSastavioPrezime.Text, 
                                                                            Telefon = txtTelefon.Text };
        zaglavljePodaci.NaDan = datumDo;
        zaglavljePodaci.NisuNaplaceniDo = nisuNaplaceniDo;
        OPZShema.sAdresa adresa = new OPZShema.sAdresa { Broj = txtBroj.Text, Mjesto = txtMjesto.Text, Ulica = txtUlica.Text };
        OPZShema.sPorezniObveznik porezniObveznik = new OPZShema.sPorezniObveznik();
        porezniObveznik.Adresa = adresa;
        porezniObveznik.Email = txtEmail.Text;
        porezniObveznik.Items = new string[] {txtNaziv.Text};
        porezniObveznik.OIB = txtOIB.Text;
        zaglavljePodaci.PorezniObveznik = porezniObveznik;
        zaglavljePodaci.Razdoblje = new OPZShema.sRazdoblje { DatumOd = xmlDate, DatumDo = datumDo };

        OPZShema.ItemsChoiceType[] sa = new OPZShema.ItemsChoiceType[3];
        sa[0] = OPZShema.ItemsChoiceType.Naziv;
        sa[1] = OPZShema.ItemsChoiceType.Ime;
        sa[2] = OPZShema.ItemsChoiceType.Prezime;
        porezniObveznik.ItemsElementName = sa;

        OPZShema.sTijelo tijelo = new OPZShema.sTijelo();

        //tu dohvatiti broj partnera/ kupaca i pustiti ga u varijablu pa nakon toga izvrtiti sa petljom i napuniti ih sve sa racunima koje ima
        var kupciDistinct = (from item in Result select new
                                  {
                                      IDPARTNER = item[2],
                                      rBr = item[0].ToString(),
                                      oznakaPoreznogBroja = item[5].ToString(),
                                      porezniBroj = item[3].ToString(),
                                      nazivKupac = item[4].ToString(),
                                      iznosRacuna = Result.Where(x => (int)x[2] == (int)item[2]).Select(x => (decimal)x[11]).Sum(),
                                      iznosPDV = Result.Where(x => (int)x[2] == (int)item[2]).Select(x => (decimal)x[12]).Sum(),
                                      iznosUkupnoSaPDV = Result.Where(x => (int)x[2] == (int)item[2]).Select(x => (decimal)x[13]).Sum(),
                                      iznosPlaceno = Result.Where(x => (int)x[2] == (int)item[2]).Select(x => (decimal)x[14]).Sum(),
                                      iznosNeplaceno = Result.Where(x => (int)x[2] == (int)item[2]).Select(x => (decimal)x[15]).Sum(),
                                      brojRacuna = Result.Where(x => (int)x[2] == (int)item[2]).Count(),
                                  })
                                  .ToList().Distinct();

        OPZShema.sKupac[] kupci = new OPZShema.sKupac[kupciDistinct.Count()];
        OPZShema.sKupac kupac;
        OPZShema.sRacun racun;
        var brojac = 0;
        var brojacRacun = 0;

        foreach (var item in kupciDistinct)
        {
            kupac =  new OPZShema.sKupac();
            kupac.K1 = item.rBr;
            kupac.K2 = item.oznakaPoreznogBroja;
            kupac.K3 = item.porezniBroj;
            kupac.K4 = item.nazivKupac;
            kupac.K5 = Math.Round(item.iznosRacuna, 2);
            kupac.K6 = Math.Round(item.iznosPDV, 2);
            kupac.K7 = Math.Round(item.iznosUkupnoSaPDV, 2);
            kupac.K8 = Math.Round(item.iznosPlaceno, 2);
            kupac.K9 = Math.Round(item.iznosNeplaceno, 2);

            kupac.Racuni = new OPZShema.sRacun[item.brojRacuna];
            var racuni = Result.Where(x => (int)x[2] == (int)item.IDPARTNER);

            foreach (var item2 in racuni)
            {
                racun = new OPZShema.sRacun();

                racun.R1 = item2[1].ToString();

                if (item2[7].ToString().Length == 1)
                {
                    racun.R2 = "0" + item2[7].ToString();
                }
                else
                {
                    racun.R2 = item2[7].ToString();
                }

                racun.R3 = Convert.ToDateTime(item2[8]).ToString("yyyy-MM-dd");
                racun.R4 = Convert.ToDateTime(item2[9]).ToString("yyyy-MM-dd");
                racun.R5 = item2[10].ToString();
                racun.R6 = Math.Round(Convert.ToDecimal(item2[11]), 2);
                racun.R7 = Math.Round(Convert.ToDecimal(item2[12]), 2);
                racun.R8 = Math.Round(Convert.ToDecimal(item2[13]), 2);
                racun.R9 = Math.Round(Convert.ToDecimal(item2[14]), 2);
                racun.R10 = Math.Round(Convert.ToDecimal(item2[15]), 2);
                kupac.Racuni[brojacRacun] = racun;
                brojacRacun++;
            }

            kupci[brojac] = kupac;
            brojac++;
            brojacRacun = 0;
        }

        
        tijelo.Kupci = kupci;

  
        tijelo.NeplaceniIznosRacunaObrasca = Math.Round(Result.Select(x => (decimal)x[15]).Sum(), 2);
        tijelo.OPZUkupanIznosPdv = Math.Round(Convert.ToDecimal(txtPDV.Value), 2);
        tijelo.OPZUkupanIznosRacunaSPdv = Math.Round(Convert.ToDecimal(txtSaPDVom.Value), 2);
        tijelo.UkupanIznosPdvObrasca = Math.Round(Result.Select(x => (decimal)x[12]).Sum(), 2);
        tijelo.UkupanIznosRacunaObrasca = Math.Round(Result.Select(x => (decimal)x[11]).Sum(), 2);
        tijelo.UkupanIznosRacunaSPdvObrasca = Math.Round(Result.Select(x => (decimal)x[13]).Sum(), 2);
        tijelo.UkupniPlaceniIznosRacunaObrasca = Math.Round(Result.Select(x => (decimal)x[14]).Sum(), 2);
        
        dokument.Metapodaci = metaPodaci;
        dokument.Zaglavlje = zaglavljePodaci;
        dokument.Tijelo = tijelo;

        try
        {
            SaveFileDialog dialog2 = new SaveFileDialog
            {
                FileName = string.Format("OPZ.xml"),
                RestoreDirectory = true
            };

            SaveFileDialog dialog = dialog2;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(dialog.FileName, false, new UTF8Encoding(true)))
                {
                    //XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                    //namespaces.Add("xmlns", "http://www.fina.hr/regzap/common-types/v0.6");

                    new XmlSerializer(typeof(OPZShema.sObrazacOPZ)).Serialize(writer, dokument);

                    writer.Close();
                }

                string xmlText = File.ReadAllText(dialog.FileName);
                string utf = xmlText.Replace("utf-8", "UTF-8");
                string xmlns = utf.Remove(51, 99);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlns);

                doc.Save(dialog.FileName);

                MessageBox.Show("Datoteka uspješno spremljena u: " + dialog.FileName);

                btnIspis.Visible = true;
            }
        }
        catch (Exception greska)
        {
            MessageBox.Show("Dogodila se greška prilikom kreiranja datoteke!!!\nKontaktirajete administratora.\n" + greska.Message);
        }

    }


    private StringBuilder Validacija(List<object[]> Result)
    {
        StringBuilder message = new StringBuilder();

        foreach (var item in Result)
        {
            if (item[0].ToString().Length == 0)
            {
                item[0] = 0;
                item[1] = 0;
                item[6] = 0;
            }

            foreach (var col in item)
            {
                
                if (col.ToString().Length == 0)
                {
                    message.Append(" - Nisu popunjena sva polja unutar grida!");
                    break;
                }
            }
        }

        foreach (var item in Result)
        {
            if ((decimal)item[11] < 0)
            {
                message.Append(" - Postoje računi koji imaju negativne iznose.\nUklonite takve račune da bi se mogla generirati datoteka.");
                break;
            }
        }

        if (txtNaziv.Text.Length == 0)
        {
            message.Append(" - Naziv poreznog obveznika je obavezan podatak.");
        }

        if (txtOIB.Text.Length == 0)
        {
            message.Append(" - OIB je obavezan podatak.");
        }

        if (txtMjesto.Text.Length == 0)
        {
            message.Append(" - Mjesto je obavezan podatak.");
        }

        if (txtUlica.Text.Length == 0)
        {
            message.Append(" - Ulica je obavezan podatak.");
        }

        if (txtBroj.Text.Length == 0)
        {
            message.Append(" - Broj je obavezan podatak.");
        }

        if (txtEmail.Text.Length == 0)
        {
            message.Append(" - email je obavezan podatak.");
        }

        if (txtTelefon.Text.Length == 0)
        {
            message.Append(" - Telefon je obavezan podatak.");
        }

        if (txtFax.Text.Length == 0)
        {
            message.Append(" - Mjesto je obavezan podatak.");
        }

        if (!TelefonFormat())
        {
            message.Append(" - Neispravan format telefona.");
        }

        if (!FaxFormat())
        {
            message.Append(" - Neispravan format fax-a.");
        }

        return message;
    }

    private bool FaxFormat()
    {
        Regex rgx = new Regex(@"^[+][0-9]{10,13}$");

        if (!rgx.IsMatch(txtFax.Text))
        {
            return false;
        }

        return true;
    }

    private bool TelefonFormat()
    {
        Regex rgx = new Regex(@"^[+][0-9]{10,13}$");

        if (!rgx.IsMatch(txtTelefon.Text))
        {
            return false;
        }

        return true;
    }

    private void btnTemeljnica_Click(object sender, EventArgs e)
    {
        if (dgvPartneri.Rows.Count > 1)
        {
            DataTable tblTemeljnica = client.GetDataTable("Select idPartner, originalniDokument, Substring(ORIGINALNIDOKUMENT, 15,4) As godina, Substring(ORIGINALNIDOKUMENT, 20,4) As brojRacuna, " + 
                "ZATVARANJA.ZATVARANJAIZNOS From GKSTAVKA Left join ZATVARANJA on ZATVARANJA.GK2IDGKSTAVKA = GKSTAVKA.IDGKSTAVKA " +
                "Where IDDOKUMENT = 1 And BROJDOKUMENTA = 1 And GKGODIDGODINE = 2016 And ORIGINALNIDOKUMENT Like 'Izlazni račun%' And ZATVARANJAIZNOS is Not NULL " + 
                "And (Select DATUMDOKUMENTA From GKSTAVKA Where IDGKSTAVKA = ZATVARANJA.GK1IDGKSTAVKA) <= '" + datumDo.ToString("yyyy-MM-dd") + "' order by IDPARTNER");

            foreach (DataRow row in tblTemeljnica.Rows)
            {
                for (int i = dgvPartneri.Rows.Count - 2; i >= 0; i--)
                {
                    if (row["idPartner"].ToString() == dgvPartneri.Rows[i].Cells["IDPARTNER"].Value.ToString() 
                        && row["brojRacuna"].ToString() == dgvPartneri.Rows[i].Cells["BrojIzdanogRacuna"].Value.ToString())
                    {
                        if (row["ZATVARANJAIZNOS"].ToString().Length > 0)
                        {
                            dgvPartneri.Rows.RemoveAt(i);
                        }
                    }
                }
            }
        }

        UkupanIznosKasnjenje();
    }

    private void label17_Click(object sender, EventArgs e)
    {

    }

    private void dgvPartneri_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        UkupanIznosKasnjenje();
    }

    private void dgvPartneri_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
    {
        UkupanIznosKasnjenje();
    }

    private void dgvPartneri_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        UkupanIznosKasnjenje();
    }
}

