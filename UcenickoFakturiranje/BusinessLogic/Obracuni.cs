using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mipsed7.DataAccessLayer.EntityFramework;
using UcenickoFakturiranje.Utils.Exceptions;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;

namespace UcenickoFakturiranje.BusinessLogic
{
    public class Obracuni :Base
    {
        SqlClient client = null;
        public Obracuni() : base()
        {
            client = new SqlClient();
        }

        #region Svojstva

        public static string pNaziv
        {
            get;
            set;
        }
        public static int? pGodinaObracuna
        {
            get;
            set;
        }
        public static int? pMjesecObracuna
        {
            get;
            set;
        }
        public static int? pkolicinaZaObracun
        {
            get;
            set;
        }
        public static DateTime? pValutaPlacanja
        {
            get;
            set;
        }
        public static bool zaduzen  {get; set;}

        public static int? pID
        {
            get;
            set;
        }

        public static int pIDShema
        {
            get;
            set;
        }

        public static bool pPregledObracuna
        {
            get;
            set;
        }

        public int pIDUcenik
        {
            get;
            set;
        }
        public int pIDCjenikStavka
        {
            get;
            set;
        }
        public int pStvarnaKolicina
        {
            get;
            set;
        }
        public decimal pIznosStavka
        {
            get;
            set;
        }
        public decimal pZaPlatiti
        {
            get;
            set;
        }
        public int pIDObracunStavka
        {
            get;
            set;
        }
        public int pIDRazrednoOdjeljenje
        {
            get;
            set;
        }

        public int pIDUstanovaSkolskaGodina
        {
            get;
            set;
        }

        public int pPozivNaBrojOdobrenja
        {
            get;
            set;
        }

        public bool pZakljucaj
        {
            get;
            set;
        }

        public bool pZaduzen
        {
            get;
            set;
        }

        public bool pVirmani
        {
            get;
            set;
        }

        public int pShema_id_dokumenta
        {
            get;
            set;
        }

        public string pShema_naziv
        {
            get;
            set;
        }

        public static List<int> pUcenici
        {
            get;
            set;
        }

        public static int pRazrednoOdjeljenje
        {
            get;
            set;
        }

        public static int pUstanova
        {
            get;
            set;
        }

        public static int pSelectedIndex
        {
            get;
            set;
        }

        public static DateTime pDatumIzdavanja { get; set; }

        #endregion

        #region DohvatPodataka

        /// <summary>
        /// dohvat svih obračuna
        /// </summary>
        /// <returns></returns>
        public DataTable GetObracuni()
        {
            string active_year = client.ExecuteScalar("Select IDGODINE From GODINE Where GODINEAKTIVNA = 1").ToString();

            return client.GetDataTable("Select ID, Naziv, GodinaObracuna As [Za godinu], MjesecObracuna As [Za mjesec], KolicinaZaObracun As [Količina], " +
                                                      "ValutaPlacanja As [Valuta plačanja], Zaduzi As [Kreirani računi] from UF_Obracun Where GodinaObracuna = '" + active_year + "'");
        }

        public DataTable GetObracunUcenici()
        {
            return client.GetDataTable("Select Distinct CONVERT(bit, 0) AS Odabrani, UF_ObracunStavka.UcenikID, UF_Ucenik.Ime, UF_Ucenik.Prezime, (UF_Razred.Naziv + ' ' + UF_Odjeljenje.Naziv) As 'Razredno odjeljenje' " + 
                                                      "From UF_ObracunStavka Inner Join UF_UstanovaSkolskaGodinaRazredOdjeljenje on UF_ObracunStavka.RazrednoOdjeljenjeID = " + 
                                                      "UF_UstanovaSkolskaGodinaRazredOdjeljenje.ID Inner Join UF_Razred on UF_UstanovaSkolskaGodinaRazredOdjeljenje.RazredID = " + 
                                                      "UF_Razred.ID Inner Join UF_Odjeljenje on UF_UstanovaSkolskaGodinaRazredOdjeljenje.OdjeljenjeID = UF_Odjeljenje.ID " +
                                                      "Inner Join UF_Ucenik on UF_ObracunStavka.UcenikID = UF_Ucenik.ID Where UF_ObracunStavka.ObracunID = " + Obracuni.pID);
        }

        /// <summary>
        /// Dohvat podataka za prikaz ucenika po razredu i odjeljenju
        /// </summary>
        /// <returns></returns>
        public DataSet GetUstanoveRazrediUcenici()
        {
            DataSet ds = new DataSet();

            DataTable UF_Ustanove = client.GetDataTable("SELECT DISTINCT dbo.UF_UstanovaSkolskaGodina.ID, UF_Ustanova_1.Naziv + ' - ' + dbo.UF_SkolskaGodina.Naziv AS [Ustanova školska godina]" +
                                     "FROM dbo.UF_Predlosci INNER JOIN dbo.UF_PredlosciStavke ON dbo.UF_Predlosci.IDPredloska = " +
                                     "dbo.UF_PredlosciStavke.IDPredloska INNER JOIN dbo.UF_UstanovaSkolskaGodina ON dbo.UF_Predlosci.IDUstanovaSkolskaGodina = " +
                                     "dbo.UF_UstanovaSkolskaGodina.ID INNER JOIN dbo.UF_Ustanova AS UF_Ustanova_1 ON dbo.UF_UstanovaSkolskaGodina.UstanovaID = " +
                                     "UF_Ustanova_1.ID INNER JOIN dbo.UF_SkolskaGodina ON dbo.UF_UstanovaSkolskaGodina.SkolskaGodinaID = dbo.UF_SkolskaGodina.ID " +
                                     "WHERE (dbo.UF_Predlosci.Aktivan = 'true') ORDER BY dbo.UF_UstanovaSkolskaGodina.ID");
            UF_Ustanove.TableName = "Ustanove";

            DataTable UF_RazrediOdjeljenje = client.GetDataTable("SELECT DISTINCT dbo.UF_UstanovaSkolskaGodinaRazredOdjeljenje.ID, dbo.UF_Predlosci.IDUstanovaSkolskaGodina, " +
                                             "dbo.UF_Razred.Naziv + dbo.UF_Odjeljenje.Naziv AS [Razred i odjeljenje] FROM dbo.UF_PredlosciStavke INNER JOIN dbo.UF_Predlosci ON " +
                                             "dbo.UF_PredlosciStavke.IDPredloska = dbo.UF_Predlosci.IDPredloska INNER JOIN dbo.UF_UstanovaSkolskaGodinaRazredOdjeljenje " +
                                             "ON dbo.UF_Predlosci.IDRazrednoOdjeljenje = dbo.UF_UstanovaSkolskaGodinaRazredOdjeljenje.ID INNER JOIN dbo.UF_Razred ON " +
                                             "dbo.UF_UstanovaSkolskaGodinaRazredOdjeljenje.RazredID = dbo.UF_Razred.ID INNER JOIN dbo.UF_Odjeljenje ON " +
                                             "dbo.UF_UstanovaSkolskaGodinaRazredOdjeljenje.OdjeljenjeID = dbo.UF_Odjeljenje.ID WHERE (dbo.UF_Predlosci.Aktivan = 'true')");
            UF_RazrediOdjeljenje.TableName = "Razredi";

            DataTable UF_Ucenici = client.GetDataTable("SELECT DISTINCT dbo.UF_Ucenik.ID, dbo.UF_Ucenik.Ime, dbo.UF_Ucenik.Prezime, dbo.UF_Predlosci.IDRazrednoOdjeljenje, " +
                                   "dbo.UF_Predlosci.IDUstanovaSkolskaGodina FROM dbo.UF_Predlosci INNER JOIN dbo.UF_PredlosciStavke ON dbo.UF_Predlosci.IDPredloska = " +
                                   "dbo.UF_PredlosciStavke.IDPredloska INNER JOIN dbo.UF_Ucenik ON dbo.UF_PredlosciStavke.IDUcenik = dbo.UF_Ucenik.ID WHERE (dbo.UF_Predlosci.Aktivan = 'true')");
            UF_Ucenici.TableName = "Ucenici";

            ds.Tables.Add(UF_Ustanove);
            ds.Tables.Add(UF_RazrediOdjeljenje);
            ds.Tables.Add(UF_Ucenici);

            DataRelation rel1 = new DataRelation("Razredi", UF_Ustanove.Columns["ID"], UF_RazrediOdjeljenje.Columns["IDUstanovaSkolskaGodina"]);

            DataRelation rel2 = new DataRelation("Ucenici", UF_RazrediOdjeljenje.Columns["ID"], UF_Ucenici.Columns["IDRazrednoOdjeljenje"]);
            ds.Relations.Add(rel1);
            ds.Relations.Add(rel2);
            return ds;
        }

        public DataSet GetUstanoveRazrediUceniciZaPregled(Enums.FormEditMode mode)
        {
            DataSet ds = new DataSet();

            DataTable UF_Ustanove = new DataTable();

            if (mode == Enums.FormEditMode.Update)
            {
                UF_Ustanove = client.GetDataTable("SELECT DISTINCT dbo.UF_UstanovaSkolskaGodina.ID, UF_Ustanova_1.Naziv + ' - ' + dbo.UF_SkolskaGodina.Naziv AS [Ustanova školska godina]" +
                                     "FROM dbo.UF_Predlosci INNER JOIN dbo.UF_PredlosciStavke ON dbo.UF_Predlosci.IDPredloska = " +
                                     "dbo.UF_PredlosciStavke.IDPredloska INNER JOIN dbo.UF_UstanovaSkolskaGodina ON dbo.UF_Predlosci.IDUstanovaSkolskaGodina = " +
                                     "dbo.UF_UstanovaSkolskaGodina.ID INNER JOIN dbo.UF_Ustanova AS UF_Ustanova_1 ON dbo.UF_UstanovaSkolskaGodina.UstanovaID = " +
                                     "UF_Ustanova_1.ID INNER JOIN dbo.UF_SkolskaGodina ON dbo.UF_UstanovaSkolskaGodina.SkolskaGodinaID = dbo.UF_SkolskaGodina.ID " +
                                     "ORDER BY dbo.UF_UstanovaSkolskaGodina.ID");
            }
            else
            {
                UF_Ustanove = client.GetDataTable("SELECT DISTINCT dbo.UF_UstanovaSkolskaGodina.ID, UF_Ustanova_1.Naziv + ' - ' + dbo.UF_SkolskaGodina.Naziv AS [Ustanova školska godina]" +
                                     "FROM dbo.UF_Predlosci INNER JOIN dbo.UF_PredlosciStavke ON dbo.UF_Predlosci.IDPredloska = " +
                                     "dbo.UF_PredlosciStavke.IDPredloska INNER JOIN dbo.UF_UstanovaSkolskaGodina ON dbo.UF_Predlosci.IDUstanovaSkolskaGodina = " +
                                     "dbo.UF_UstanovaSkolskaGodina.ID INNER JOIN dbo.UF_Ustanova AS UF_Ustanova_1 ON dbo.UF_UstanovaSkolskaGodina.UstanovaID = " +
                                     "UF_Ustanova_1.ID INNER JOIN dbo.UF_SkolskaGodina ON dbo.UF_UstanovaSkolskaGodina.SkolskaGodinaID = dbo.UF_SkolskaGodina.ID " +
                                     "WHERE (dbo.UF_Predlosci.Aktivan = 'true') ORDER BY dbo.UF_UstanovaSkolskaGodina.ID");
            }

            UF_Ustanove.TableName = "Ustanove";

            DataTable UF_RazrediOdjeljenje = client.GetDataTable("Select Distinct dbo.UF_ObracunStavka.RazrednoOdjeljenjeID As ID, UF_UstanovaSkolskaGodinaRazredOdjeljenje.UstanovaSkolskaGodinaID As IDUstanovaSkolskaGodina, " +
                                             "dbo.UF_Razred.Naziv + dbo.UF_Odjeljenje.Naziv AS [Razred i odjeljenje] From dbo.UF_ObracunStavka " +
                                             "Inner Join UF_UstanovaSkolskaGodinaRazredOdjeljenje on UF_ObracunStavka.RazrednoOdjeljenjeID = UF_UstanovaSkolskaGodinaRazredOdjeljenje.ID " +
                                             "Inner Join dbo.UF_Razred ON dbo.UF_UstanovaSkolskaGodinaRazredOdjeljenje.RazredID = dbo.UF_Razred.ID " +
                                             "Inner Join dbo.UF_Odjeljenje ON dbo.UF_UstanovaSkolskaGodinaRazredOdjeljenje.OdjeljenjeID = dbo.UF_Odjeljenje.ID Where ObracunID = '" + pID + "'");
            UF_RazrediOdjeljenje.TableName = "Razredi";

            DataTable UF_Ucenici = client.GetDataTable("Select Distinct dbo.UF_Ucenik.ID, dbo.UF_Ucenik.Ime, dbo.UF_Ucenik.Prezime, dbo.UF_ObracunStavka.RazrednoOdjeljenjeID As IDRazrednoOdjeljenje, " + 
                                   "UF_UstanovaSkolskaGodinaRazredOdjeljenje.UstanovaSkolskaGodinaID As IDUstanovaSkolskaGodina " +
                                   "From dbo.UF_ObracunStavka Inner Join UF_UstanovaSkolskaGodinaRazredOdjeljenje on UF_ObracunStavka.RazrednoOdjeljenjeID = UF_UstanovaSkolskaGodinaRazredOdjeljenje.ID " +
                                   "Inner Join dbo.UF_Ucenik ON dbo.UF_ObracunStavka.UcenikID = dbo.UF_Ucenik.ID Where ObracunID = '" + pID + "'");
            UF_Ucenici.TableName = "Ucenici";

            ds.Tables.Add(UF_Ustanove);
            ds.Tables.Add(UF_RazrediOdjeljenje);
            ds.Tables.Add(UF_Ucenici);

            DataRelation rel1 = new DataRelation("Razredi", UF_Ustanove.Columns["ID"], UF_RazrediOdjeljenje.Columns["IDUstanovaSkolskaGodina"]);

            DataRelation rel2 = new DataRelation("Ucenici", UF_RazrediOdjeljenje.Columns["ID"], UF_Ucenici.Columns["IDRazrednoOdjeljenje"]);
            ds.Relations.Add(rel1);
            ds.Relations.Add(rel2);
            return ds;
        }

        /// <summary>
        /// dohvat podatak o zaduzenom cjeniku za ustanovu
        /// </summary>
        /// <param name="id"></param>
        /// <param name="kolicina"></param>
        /// <returns></returns>
        public DataTable GetObracunUstanoveStavke(int id, int? kolicina)
        {
            DataTable dtUstanove = client.GetDataTable("SELECT dbo.UF_Proizvod.Naziv AS Proizvod, dbo.UF_Proizvod.Cijena AS [Jednična cijena], dbo.UF_Olaksica.Naziv AS [Naziv olakšice], " +
                                   "CASE WHEN dbo.UF_CjenikStavka.OlaksicaIznos IS NOT NULL THEN " +
                                   "CAST(dbo.UF_Proizvod.Cijena - dbo.UF_CjenikStavka.OlaksicaIznos AS money) ELSE CAST(dbo.UF_Proizvod.Cijena - (dbo.UF_Proizvod.Cijena * " +
                                   "(dbo.UF_CjenikStavka.OlaksicaPostotak / 100)) AS money) END AS [Cijena s olakšicom], dbo.FINPOREZ.FINPOREZSTOPA AS Porez FROM " +
                                   "dbo.UF_PredlosciStavke INNER JOIN dbo.UF_CjenikStavka ON dbo.UF_PredlosciStavke.IDCjenik = dbo.UF_CjenikStavka.CjenikID " +
                                   "INNER JOIN dbo.UF_Proizvod ON dbo.UF_CjenikStavka.ProizvodID = dbo.UF_Proizvod.ID INNER JOIN dbo.UF_Olaksica ON dbo.UF_CjenikStavka.OlaksicaID = " +
                                   "dbo.UF_Olaksica.ID INNER JOIN dbo.FINPOREZ ON dbo.UF_Proizvod.PorezID = dbo.FINPOREZ.FINPOREZIDPOREZ INNER JOIN dbo.UF_Predlosci ON " +
                                   "dbo.UF_PredlosciStavke.IDPredloska = dbo.UF_Predlosci.IDPredloska WHERE (dbo.UF_Predlosci.IDUstanovaSkolskaGodina = '" + id + "') GROUP BY " +
                                   "dbo.UF_Proizvod.Naziv, dbo.UF_Proizvod.Cijena, dbo.UF_Olaksica.Naziv, dbo.UF_CjenikStavka.OlaksicaIznos, dbo.FINPOREZ.FINPOREZSTOPA, " +
                                   "dbo.UF_CjenikStavka.OlaksicaPostotak, dbo.UF_Proizvod.TipKolicineID");
            return dtUstanove;
        }

        public DataTable GetObracunStavke()
        {
            DataTable dtUstanove = client.GetDataTable("SELECT UcenikID, RazrednoOdjeljenjeID Where ObracunID = '" + pID + "'");
            return dtUstanove;
        }

        public DataTable GetUstanoveVirmani()
        {
            DataTable dtUstanove = client.GetDataTable("SELECT ID, Naziv From UF_Ustanova");
            return dtUstanove;
        }

        public DataTable GetRazrednaOdjeljenja()
        {
            DataTable dt = client.GetDataTable("Select Distinct v_UF_RekapitulacijaObracuna.RazrednoOdjeljenjeID As ID, (UF_Razred.Naziv + ' ' + UF_Odjeljenje.Naziv) As Naziv From v_UF_RekapitulacijaObracuna " +
                           "Inner Join UF_UstanovaSkolskaGodinaRazredOdjeljenje on v_UF_RekapitulacijaObracuna.RazrednoOdjeljenjeID = UF_UstanovaSkolskaGodinaRazredOdjeljenje.ID " +
                           "Inner Join UF_Razred on UF_UstanovaSkolskaGodinaRazredOdjeljenje.RazredID = UF_Razred.ID Inner Join UF_Odjeljenje " + 
                           "on UF_UstanovaSkolskaGodinaRazredOdjeljenje.OdjeljenjeID = UF_Odjeljenje.ID Where v_UF_RekapitulacijaObracuna.ID = " + pID);
            return dt;
        }

        public DataTable GetUstanova()
        {
            DataTable dt = client.GetDataTable("Select Distinct UstanovaID As ID, UF_Ustanova.Naziv From v_UF_RekapitulacijaObracuna " +
                                               "Inner Join UF_Ustanova on v_UF_RekapitulacijaObracuna.UstanovaID = UF_Ustanova.ID " +
                                               "Where v_UF_RekapitulacijaObracuna.ID = " + pID);
            return dt;
        }

        public DataTable GetObracunStavkeCjenik()
        {
            DataTable dtUstanove = client.GetDataTable("SELECT ObracunStavkaID, CjenikStavkaID, StvarnaKolicina, IznosStavka Where ObracunID = '" + pID + "'");
            return dtUstanove;
        }

        public DataTable GetUcenikZaduzenje()
        {
            DataTable dtUstanove = client.GetDataTable("SELECT ObracunStavkaID, UcenikID, ZaPlatiti, PozNaBrOdobrenjaIzracun Where ObracunID = '" + pID + "'");
            return dtUstanove;
        }

        /// <summary>
        /// dohvat podataka o zaduzenom cjeniku za razredno odjeljenje
        /// </summary>
        /// <param name="id"></param>
        /// <param name="id_razred"></param>
        /// <param name="kolicina"></param>
        /// <returns></returns>
        public DataTable GetObracunRazrediStavke(int id, int id_razred, int? kolicina)
        {
            DataTable dtRazredi = client.GetDataTable("SELECT dbo.UF_Proizvod.Naziv AS Proizvod, dbo.UF_Proizvod.Cijena AS [Jednična cijena], dbo.UF_Olaksica.Naziv AS [Naziv olakšice], " +
                                   "CASE WHEN dbo.UF_CjenikStavka.OlaksicaIznos IS NOT NULL THEN CAST(dbo.UF_Proizvod.Cijena - dbo.UF_CjenikStavka.OlaksicaIznos AS money) " +
                                   "ELSE CAST(dbo.UF_Proizvod.Cijena - (dbo.UF_Proizvod.Cijena * " +
                                   "(dbo.UF_CjenikStavka.OlaksicaPostotak / 100)) AS money) END AS [Cijena s olakšicom], dbo.FINPOREZ.FINPOREZSTOPA AS Porez " +
                                   "FROM dbo.UF_PredlosciStavke INNER JOIN dbo.UF_CjenikStavka ON dbo.UF_PredlosciStavke.IDCjenik = dbo.UF_CjenikStavka.CjenikID " +
                                   "INNER JOIN dbo.UF_Proizvod ON dbo.UF_CjenikStavka.ProizvodID = dbo.UF_Proizvod.ID INNER JOIN dbo.UF_Olaksica ON dbo.UF_CjenikStavka.OlaksicaID = " +
                                   "dbo.UF_Olaksica.ID INNER JOIN dbo.FINPOREZ ON dbo.UF_Proizvod.PorezID = dbo.FINPOREZ.FINPOREZIDPOREZ INNER JOIN dbo.UF_Predlosci ON " +
                                   "dbo.UF_PredlosciStavke.IDPredloska = dbo.UF_Predlosci.IDPredloska WHERE (dbo.UF_Predlosci.IDRazrednoOdjeljenje = '" + id + "') AND " +
                                   "(dbo.UF_Predlosci.IDUstanovaSkolskaGodina = '" + id_razred + "') GROUP BY " +
                                   "dbo.UF_Proizvod.Naziv, dbo.UF_Proizvod.Cijena, dbo.UF_Olaksica.Naziv, dbo.UF_CjenikStavka.OlaksicaIznos, dbo.FINPOREZ.FINPOREZSTOPA, " +
                                   "dbo.UF_CjenikStavka.OlaksicaPostotak, dbo.UF_Proizvod.TipKolicineID");
            return dtRazredi;
        }

        /// <summary>
        /// dohvat podataka o zaduzenom cjeniku za pojedinog ucenika
        /// </summary>
        /// <param name="id_ucenik"></param>
        /// <param name="id_ustanova"></param>
        /// <param name="id_razred"></param>
        /// <param name="kolicina"></param>
        /// <returns></returns>
        public DataTable GetObracunUceniciStavke(int id_ucenik, int id_ustanova, int id_razred, int? kolicina)
        {
            DataTable dtUcenici = client.GetDataTable("SELECT dbo.UF_CjenikStavka.ID, dbo.UF_Proizvod.Naziv AS Proizvod, dbo.UF_Proizvod.Cijena AS [Jednična cijena], CASE WHEN dbo.UF_Proizvod.TipKolicineID = 2 " +
                                   "THEN 1 ELSE '" + kolicina + "' END AS Količina, dbo.UF_Olaksica.Naziv AS [Naziv olakšice], CASE WHEN dbo.UF_CjenikStavka.OlaksicaIznos IS NOT NULL THEN " +
                                   "CAST(dbo.UF_Proizvod.Cijena - dbo.UF_CjenikStavka.OlaksicaIznos AS money) ELSE CAST(dbo.UF_Proizvod.Cijena - (dbo.UF_Proizvod.Cijena * " +
                                   "(dbo.UF_CjenikStavka.OlaksicaPostotak / 100)) AS money) END AS [Cijena s olakšicom], dbo.FINPOREZ.FINPOREZSTOPA AS Porez, CASE WHEN " +
                                   "dbo.UF_CjenikStavka.OlaksicaIznos IS NOT NULL THEN CAST(dbo.UF_Proizvod.Cijena - dbo.UF_CjenikStavka.OlaksicaIznos AS money) ELSE CAST(dbo.UF_Proizvod.Cijena " +
                                   "- (dbo.UF_Proizvod.Cijena * (dbo.UF_CjenikStavka.OlaksicaPostotak / 100)) AS money) END * CASE WHEN dbo.UF_Proizvod.TipKolicineID = 2 THEN 1 ELSE '" + kolicina + "' " +
                                   "END AS [Ukupno za platiti], dbo.UF_Predlosci.IDRazrednoOdjeljenje FROM dbo.UF_PredlosciStavke INNER JOIN dbo.UF_CjenikStavka ON dbo.UF_PredlosciStavke.IDCjenik = dbo.UF_CjenikStavka.CjenikID " +
                                   "INNER JOIN dbo.UF_Proizvod ON dbo.UF_CjenikStavka.ProizvodID = dbo.UF_Proizvod.ID INNER JOIN dbo.UF_Olaksica ON dbo.UF_CjenikStavka.OlaksicaID = " +
                                   "dbo.UF_Olaksica.ID INNER JOIN dbo.FINPOREZ ON dbo.UF_Proizvod.PorezID = dbo.FINPOREZ.FINPOREZIDPOREZ INNER JOIN dbo.UF_Predlosci ON " +
                                   "dbo.UF_PredlosciStavke.IDPredloska = dbo.UF_Predlosci.IDPredloska WHERE (dbo.UF_Predlosci.IDRazrednoOdjeljenje = '" + id_razred + "') AND " +
                                   "(dbo.UF_Predlosci.IDUstanovaSkolskaGodina = '" + id_ustanova + "') AND (dbo.UF_PredlosciStavke.IDUcenik = '" + id_ucenik + "' )  And (dbo.UF_Predlosci.Aktivan = 'true') GROUP BY " +
                                   "dbo.UF_Proizvod.Naziv, dbo.UF_Proizvod.Cijena, dbo.UF_Olaksica.Naziv, dbo.UF_CjenikStavka.OlaksicaIznos, dbo.FINPOREZ.FINPOREZSTOPA, " +
                                   "dbo.UF_CjenikStavka.OlaksicaPostotak, dbo.UF_Proizvod.TipKolicineID, dbo.UF_CjenikStavka.ID, dbo.UF_Predlosci.IDRazrednoOdjeljenje");
            return dtUcenici;
        }

        /// <summary>
        /// Dohvat podataka o zaduzenom cjeniku za pojedinog ucenika za postojeci red
        /// </summary>
        /// <param name="id_razred"></param>
        /// <param name="id_ucenik"></param>
        /// <returns></returns>
        public DataTable GetObracunUceniciStavkePostojeci(int id_razred, int id_ucenik)
        {
            DataTable dtUcenici = client.GetDataTable("SELECT dbo.UF_CjenikStavka.ID, dbo.UF_Proizvod.Naziv AS Proizvod, dbo.UF_Proizvod.Cijena AS [Jedinična cijena], " +
                                  "CAST(dbo.UF_ObracunStavkaCjenik.StvarnaKolicina AS int) AS Količina, dbo.UF_Olaksica.Naziv AS [Naziv olakšice], CASE WHEN dbo.UF_CjenikStavka.OlaksicaIznos IS NOT NULL " +
                                  "THEN CAST(dbo.UF_Proizvod.Cijena - dbo.UF_CjenikStavka.OlaksicaIznos AS money) ELSE CAST(dbo.UF_Proizvod.Cijena - (dbo.UF_Proizvod.Cijena * " +
                                  "(dbo.UF_CjenikStavka.OlaksicaPostotak / 100)) AS money) END AS [Cijena s olakšicom], dbo.FINPOREZ.FINPOREZSTOPA AS Porez, " +
                                  "dbo.UF_ObracunStavkaCjenik.IznosStavka AS [Ukupno za platiti], dbo.UF_ObracunStavka.RazrednoOdjeljenjeID AS IDRazrednoOdjeljenje FROM " +
                                  "dbo.UF_ObracunStavka INNER JOIN dbo.UF_ObracunStavkaCjenik ON dbo.UF_ObracunStavka.ID = dbo.UF_ObracunStavkaCjenik.ObracunStavkaID INNER JOIN " +
                                  "dbo.UF_CjenikStavka ON dbo.UF_ObracunStavkaCjenik.CjenikStavkaID = dbo.UF_CjenikStavka.ID INNER JOIN dbo.UF_Proizvod ON dbo.UF_CjenikStavka.ProizvodID " +
                                  "= dbo.UF_Proizvod.ID INNER JOIN dbo.UF_Olaksica ON dbo.UF_CjenikStavka.OlaksicaID = dbo.UF_Olaksica.ID INNER JOIN dbo.FINPOREZ ON dbo.UF_Proizvod.PorezID = " +
                                  "dbo.FINPOREZ.FINPOREZIDPOREZ WHERE (dbo.UF_ObracunStavka.RazrednoOdjeljenjeID = '" + id_razred + "') AND " +
                                  "(dbo.UF_ObracunStavka.ObracunID = '" + pID + "') AND (dbo.UF_ObracunStavka.UcenikID = '" + id_ucenik + "')");

            return dtUcenici;
        }

        /// <summary>
        /// Pronadi stavku po razrednom odjeljnju, uceniku i obracunu. Ukoliko ne postoji stavka radi se insert, a ukoliko postoji radi se update u bazi.
        /// </summary>
        /// <returns></returns>
        public bool NadiStavku()
        {
            DataTable dtUcenici = client.GetDataTable("SELECT ID FROM UF_ObracunStavka Where UcenikID = '" + pIDUcenik + "' And RazrednoOdjeljenjeID = '"
                                                      + pIDRazrednoOdjeljenje + "' And ObracunID = '" + pID + "'");

            if (dtUcenici.Rows.Count > 0)
            {
                pIDObracunStavka = (int)dtUcenici.Rows[0]["ID"];
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Vracanje sljedeceg slobodnog poziva na broj odobrenja
        /// </summary>
        /// <returns></returns>
        public int VratiPozivNaBroj()
        {
            int broj = 0;
            DataTable dtUcenik = client.GetDataTable("Select  PozNaBrOdobrenjaIzracun From UF_UcenikZaduzenje Where ObracunID = '" + pID + "' And UcenikID = '" + pIDUcenik + "'");

            if (dtUcenik.Rows.Count > 0)
            {
                broj = Convert.ToInt32(dtUcenik.Rows[0]["PozNaBrOdobrenjaIzracun"]);
                return broj;
            }
            else
            {
                DataTable dtPozivNaBroj = client.GetDataTable("Select Max (PozNaBrOdobrenjaIzracun) As Broj From UF_UcenikZaduzenje");
                if (dtPozivNaBroj.Rows[0]["Broj"] != DBNull.Value)
                {
                    broj = Convert.ToInt32(dtPozivNaBroj.Rows[0]["Broj"]) + 1;
                    return broj;
                }
                else
                    return 1;
            }
        }

        private int? VratiIdIzPartnera(string oib)
        {
            int id_partner = 0;

            DataTable dtPartner = client.GetDataTable("Select IDPARTNER From PARTNER Where PARTNEROIB = '" + oib + "'");

            if (dtPartner.Rows.Count > 0)
            {
                id_partner = Convert.ToInt32(dtPartner.Rows[0]["IDPARTNER"]);
                return id_partner;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Informacija dali je obracun zakljucan
        /// </summary>
        /// <returns></returns>
        public bool VratiDaliJeZakljucan()
        {
            DataSet ds = new DataSet();

            DataTable dtObracun = client.GetDataTable("Select Zakljucaj From UF_Obracun Where ID = '" + pID + "'");

            return Convert.ToBoolean(dtObracun.Rows[0]["Zakljucaj"]);
        }

        /// <summary>
        /// Vraca broj dokumenta za glavne knjige kod financijskog zaduzivanja
        /// </summary>
        /// <returns></returns>
        private int GetBrojDokumenta()
        {
            int broj_dokumenta = 0;

            DataTable dtbroj = client.GetDataTable("Select Max(BROJDOKUMENTA) As Broj From GKSTAVKA");

            if (dtbroj.Rows.Count > 0)
            {
                broj_dokumenta = Convert.ToInt32(dtbroj.Rows[0]["Broj"]);
                return broj_dokumenta +1;
            }
            else
            {
                return 1;
            }
        }

        private int GetAktivnaGodina()
        {
            int aktivna_godina = 0;

            DataTable dtgodina= client.GetDataTable("Select IDGODINE From Godine Where GODINEAKTIVNA = 1");

            if (dtgodina.Rows.Count > 0)
            {
                aktivna_godina = Convert.ToInt32(dtgodina.Rows[0]["IDGODINE"]);
                return aktivna_godina;
            }
            else
            {
                return DateTime.Now.Year;
            }
        }

        public int GetIDShemaOdabir()
        {
            using (UcenickoFakturiranje.UI.Fakturiranje.OdabirSheme objekt = new UI.Fakturiranje.OdabirSheme())
            {
                if (objekt.ShowDialogForm("Odabir sheme") == System.Windows.Forms.DialogResult.OK)
                {
                    return objekt.id_sheme;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int GetIDShema()
        {
            int broj_dokumenta = 0;

            DataTable dtbroj = client.GetDataTable("Select Max(ID) As Broj From UF_Shema");

            if (dtbroj.Rows.Count > 0 && dtbroj.Rows[0]["Broj"].ToString() != "")
            {
                broj_dokumenta = Convert.ToInt32(dtbroj.Rows[0]["Broj"]);
                return broj_dokumenta;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Kompletna zaduzenja unutar jednog obracuna
        /// </summary>
        /// <returns></returns>
        private DataTable GetUcenikzaduzenjeIzObracuna()
        {
            DataTable dtUcenici = client.GetDataTable("Select UcenikID, ZaPlatiti From UF_UcenikZaduzenje Where ObracunID = '" + pID + "'");
            return dtUcenici;
        }

        /// <summary>
        /// Zaduzenja po ucenicima unutar jednog obracuna
        /// </summary>
        /// <returns></returns>
        private DataTable GetZaduzenjaPoUceniku()
        {
            DataTable dtUcenici = client.GetDataTable("Select Distinct UcenikID, CAST(0 AS money) AS ZaPlatiti, UF_Ucenik.OIB From UF_UcenikZaduzenje " +
                                  "Inner Join UF_Ucenik On UF_UcenikZaduzenje.UcenikID = UF_Ucenik.ID Where ObracunID = '" + pID + "'");
            return dtUcenici;
        }

        public DataSet GetShema()
        {
            DataSet ds = new DataSet();

            DataTable dtShema = client.GetDataTable("SELECT ID, NAZIV As Naziv, NAZIVDOKUMENT As Dokument FROM DOKUMENT INNER JOIN UF_Shema ON DOKUMENT.IDDOKUMENT = UF_Shema.IDDOKUMENT");
            ds.Tables.Add(dtShema);
            return ds;
        }

        public DataTable GetShemaFinancijsko()
        {

            DataTable dtShema = client.GetDataTable("SELECT ID, NAZIV FROM UF_Shema");

            return dtShema;
        }

        /// <summary>
        /// dohvat dokumenata za shemu
        /// </summary>
        /// <returns></returns>
        public DataTable GetDokumenti()
        {
            DataTable dtDokumenti = client.GetDataTable("Select IDDOKUMENT, NAZIVDOKUMENT From DOKUMENT order by NAZIVDOKUMENT");
            return dtDokumenti;
        }

        /// <summary>
        /// dohvat konta za shemu
        /// </summary>
        /// <returns></returns>
        public DataTable GetKonto()
        {
            DataTable dtKonto = client.GetDataTable("Select RTRIM(IDKONTO), (RTRIM(IDKONTO) + ' | ' + RTRIM(NAZIVKONTO)) As NAZIVKONTO  From KONTO");
            return dtKonto;
        }

        /// <summary>
        /// dohvat strane knjizenja za shemu
        /// </summary>
        /// <returns></returns>
        public DataTable GetStranaKnjizenja()
        {
            DataTable dtStranaKnjizenja = client.GetDataTable("Select IDSTRANEKNJIZENJA, NAZIVSTRANEKNJIZENJA From STRANEKNJIZENJA");
            return dtStranaKnjizenja;
        }

        /// <summary>
        /// dohvat vrste iznosa za shemu
        /// </summary>
        /// <returns></returns>
        public DataTable GetVrstaIznosa()
        {
            DataTable dtUcenici = client.GetDataTable("Select IDIRAVRSTAIZNOSA, IRAVRSTAIZNOSANAZIV From IRAVRSTAIZNOSA");
            return dtUcenici;
        }

        /// <summary>
        /// dohvat mjesta troska za shemu
        /// </summary>
        /// <returns></returns>
        public DataTable GetSifraMT()
        {
            DataTable dtUcenici = client.GetDataTable("Select IDMJESTOTROSKA, (NAZIVMJESTOTROSKA + ' | ' + Convert(nvarchar, IDMJESTOTROSKA)) As NAZIVMJESTOTROSKA From MJESTOTROSKA order by NAZIVMJESTOTROSKA");
            return dtUcenici;
        }

        /// <summary>
        /// dohvat organizacijskih jedinica za shemu
        /// </summary>
        /// <returns></returns>
        public DataTable GetSifraOJ()
        {
            DataTable dtUcenici = client.GetDataTable("Select IDORGJED, (NAZIVORGJED + ' | ' + Convert(nvarchar, IDORGJED)) As NAZIVORGJED From ORGJED");
            return dtUcenici;
        }

        /// <summary>
        /// dohvat sheme po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataRow GetShemaById(int id)
        {
            DataTable dtShema = client.GetDataTable("SELECT ID, NAZIV As Naziv, IDDOKUMENT FROM UF_Shema Where ID = '" + id + "'");
            return dtShema.Rows[0];
        }

        /// <summary>
        /// dohvat sheme kontiranja po id-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetShemaKontiranjeByID(int id)
        {
            DataTable dtShemaKontiranja = client.GetDataTable("SELECT dbo.KONTO.IDKONTO AS ID_KONTO, dbo.STRANEKNJIZENJA.IDSTRANEKNJIZENJA AS ID_STRANE_KNJIZENJA, " +
                                          "dbo.IRAVRSTAIZNOSA.IDIRAVRSTAIZNOSA AS ID_IRA_VRSTA_IZNOSA, dbo.MJESTOTROSKA.IDMJESTOTROSKA AS ID_MJESTO_TROSKA, " +
                                          "dbo.ORGJED.IDORGJED AS ID_ORG_JED, (RTRIM(dbo.Konto.IDKONTO) + ' | ' + dbo.Konto.NAZIVKONTO) AS Konto, " +
                                          "dbo.STRANEKNJIZENJA.NAZIVSTRANEKNJIZENJA AS StranaKnjizenja, dbo.IRAVRSTAIZNOSA.IRAVRSTAIZNOSANAZIV AS VrstaIznosa, " +
                                          "(dbo.MJESTOTROSKA.NAZIVMJESTOTROSKA + ' | ' + Convert(nvarchar, dbo.MJESTOTROSKA.IDMJESTOTROSKA)) AS SifraMT, " +
                                          "(dbo.ORGJED.NAZIVORGJED + ' | ' + Convert(nvarchar, dbo.ORGJED.IDORGJED)) AS SifraOJ " +  
                                          "FROM dbo.UF_ShemaKontiranje INNER JOIN dbo.STRANEKNJIZENJA ON dbo.UF_ShemaKontiranje.ID_STRANE_KNJIZENJA = dbo.STRANEKNJIZENJA.IDSTRANEKNJIZENJA " + 
                                          "INNER JOIN dbo.IRAVRSTAIZNOSA ON dbo.UF_ShemaKontiranje.ID_IRA_VRSTA_IZNOSA = dbo.IRAVRSTAIZNOSA.IDIRAVRSTAIZNOSA INNER JOIN " +
                                          "dbo.ORGJED ON dbo.UF_ShemaKontiranje.ID_ORG_JED = dbo.ORGJED.IDORGJED INNER JOIN " +
                                          "dbo.MJESTOTROSKA ON dbo.UF_ShemaKontiranje.ID_MJESTO_TROSKA = dbo.MJESTOTROSKA.IDMJESTOTROSKA INNER JOIN " +
                                          "dbo.KONTO ON dbo.UF_ShemaKontiranje.ID_KONTO = dbo.KONTO.IDKONTO WHERE (dbo.UF_ShemaKontiranje.ID_SHEMA = '" + id + "')");
            return dtShemaKontiranja;
        }

        #endregion

        #region RadSaPodacima

        /// <summary>
        /// Upis novog obracuna u bazu
        /// </summary>
        /// <param name="naziv">Naziv obračuna</param>
        /// <param name="GodinaObracuna">Za koju godinu se radi obračun</param>
        /// <param name="MjesecObracuna">mjesec obračuna</param>
        /// <returns></returns>
        public bool InsertObracun()
        {
            UF_Obracun clsObracun = new UF_Obracun();

            clsObracun.Naziv = pNaziv;
            clsObracun.GodinaObracuna = (int)pGodinaObracuna;
            clsObracun.MjesecObracuna = (int)pMjesecObracuna;
            clsObracun.KolicinaZaObracun = (int)pkolicinaZaObracun;
            clsObracun.ValutaPlacanja = (DateTime)pValutaPlacanja;
            clsObracun.Zakljucaj = false;
            clsObracun.Zaduzi = false;
            clsObracun.Virmani = false;
            clsObracun.TS = DateTime.Now;

            base.Database.UF_Obracun.AddObject(clsObracun);
            return true;
        }

        /// <summary>
        /// Editiranje postoječeg obračuna
        /// </summary>
        /// <param name="id">šifra obračuna</param>
        /// <param name="naziv">naziv obračuna</param>
        /// <param name="GodinaObracuna">godina obračuna</param>
        /// <param name="MjesecObracuna">mjesec obračuna</param>
        /// <returns></returns>
        public bool EditObracun()
        {
            UF_Obracun clsObracun = base.Database.UF_Obracun.SingleOrDefault(o => o.ID == pID);

            clsObracun.Naziv = pNaziv;
            clsObracun.GodinaObracuna = (int)pGodinaObracuna;
            clsObracun.MjesecObracuna = (int)pMjesecObracuna;
            clsObracun.KolicinaZaObracun = (int)pkolicinaZaObracun;
            clsObracun.ValutaPlacanja = (DateTime)pValutaPlacanja;
            clsObracun.Zakljucaj = false;
            clsObracun.Virmani = false;
            clsObracun.TS = DateTime.Now;

            return true;
        }

        /// <summary>
        /// Brisanje obračuna
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ObrisiObracun()
        {
            bool status = false;

            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            //brisanje ucenika zaduzenje
            sqlUpit.CommandText = "Delete From  UF_UcenikZaduzenje Where ObracunID = @ObracunID";

            sqlUpit.Parameters.Add(new SqlParameter("@ObracunID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
                status = true;
            }
            catch
            {
                status = false;
            }

            //brisanje obracun stavke cjenika
            sqlUpit.CommandText = "Delete From  UF_ObracunStavkaCjenik Where ObracunID = @ObracunID";

            try
            {
                sqlUpit.ExecuteNonQuery();
                status = true;
            }
            catch
            {
                status = false;
            }

            //brisanje obracun stavke
            sqlUpit.CommandText = "Delete From  UF_ObracunStavka Where ObracunID = @ObracunID";

            try
            {
                sqlUpit.ExecuteNonQuery();
                status = true;
            }
            catch
            {
                status = false;
            }

            //brisanje obracuna
            sqlUpit.CommandText = "Delete From  UF_Obracun Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
                status = true;
            }
            catch
            {
                status = false;
            }

            return status;
        }

        /// <summary>
        /// Zapis promjena u entitet
        /// </summary>
        public bool Persist()
        {
            try
            {
                base.Database.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        /// <summary>
        /// dohvačanje najvećeg id-a
        /// </summary>
        /// <returns></returns>
        public int? NajveciID()
        {
            try
            {
                return base.Database.UF_Obracun.Max(o => o.ID);
            }
            catch
            {
                return 1;
            }
        }
        
        /// <summary>
        /// Upis nove stavke obracuna u bazu
        /// </summary>
        /// <returns></returns>
        public bool InsertObracunStavka()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into UF_ObracunStavka (ObracunID, UcenikID, RazrednoOdjeljenjeID, TS) Values (@ObracunID, @UcenikID, @RazrednoOdjeljenjeID, @TS)" +
                                  "Select @@Identity";

            sqlUpit.Parameters.Add(new SqlParameter("@ObracunID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@UcenikID", pIDUcenik));
            sqlUpit.Parameters.Add(new SqlParameter("@RazrednoOdjeljenjeID", pIDRazrednoOdjeljenje));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

            try
            {
                pIDObracunStavka = Convert.ToInt32(sqlUpit.ExecuteScalar());
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Upis nove stavke cjenik obracuna u bazu
        /// </summary>
        /// <returns></returns>
        public bool InsertObracunStavkaCjenik()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into UF_ObracunStavkaCjenik ([ObracunStavkaID], [CjenikStavkaID], [StvarnaKolicina], [IznosStavka], [ObracunID]) Values " +
                                  "(@ObracunStavkaID, @CjenikStavkaID, @StvarnaKolicina, @IznosStavka, @ObracunID)";

            sqlUpit.Parameters.Add(new SqlParameter("@ObracunStavkaID", pIDObracunStavka));
            sqlUpit.Parameters.Add(new SqlParameter("@CjenikStavkaID", pIDCjenikStavka));
            sqlUpit.Parameters.Add(new SqlParameter("@StvarnaKolicina", pStvarnaKolicina));
            sqlUpit.Parameters.Add(new SqlParameter("@IznosStavka", pIznosStavka));
            sqlUpit.Parameters.Add(new SqlParameter("@ObracunID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Upis novog ucenika zaduzenje u bazu
        /// </summary>
        /// <returns></returns>
        public bool InsertUcenikZaduzenje()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into UF_UcenikZaduzenje (ObracunID, ObracunStavkaID, UcenikID, ZaPlatiti, PozNaBrOdobrenjaIzracun) Values " +
                                  "(@ObracunID, @ObracunStavkaID, @UcenikID, @ZaPlatiti, @PozNaBrOdobrenjaIzracun)";

            sqlUpit.Parameters.Add(new SqlParameter("@ObracunID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@ObracunStavkaID", pIDObracunStavka));
            sqlUpit.Parameters.Add(new SqlParameter("@UcenikID", pIDUcenik));
            sqlUpit.Parameters.Add(new SqlParameter("@ZaPlatiti", decimal.Round(pZaPlatiti, 2)));
            sqlUpit.Parameters.Add(new SqlParameter("@PozNaBrOdobrenjaIzracun", pPozivNaBrojOdobrenja));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// Editiranje stavke obracuna
        /// </summary>
        /// <returns></returns>
        public bool EditObracunStavka()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update UF_ObracunStavka Set TS = @TS Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pIDObracunStavka));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Brisanje stavke cjenika obracuna
        /// </summary>
        /// <returns></returns>
        public bool DeleteObracunStavkaCjenik()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Delete From  UF_ObracunStavkaCjenik Where ObracunStavkaID = @ObracunStavkaID";

            sqlUpit.Parameters.Add(new SqlParameter("@ObracunStavkaID", pIDObracunStavka));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Editiranje Ucenika zaduzenje
        /// </summary>
        /// <returns></returns>
        public bool EditUcenikZaduzenje()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update UF_UcenikZaduzenje Set ZaPlatiti = @ZaPlatiti Where UcenikID = @UcenikID And ObracunStavkaID = @ObracunStavkaID";

            sqlUpit.Parameters.Add(new SqlParameter("@UcenikID", pIDUcenik));
            sqlUpit.Parameters.Add(new SqlParameter("@ObracunStavkaID", pIDObracunStavka));
            sqlUpit.Parameters.Add(new SqlParameter("@ZaPlatiti", decimal.Round(pZaPlatiti, 2)));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Zakljucavanje obracuna za daljenje editiranje
        /// </summary>
        /// <returns></returns>
        public bool ZakljucajObracun()
        {
            UF_Obracun clsObracun = base.Database.UF_Obracun.SingleOrDefault(o => o.ID == pID);

            clsObracun.Zakljucaj = pZakljucaj;
            clsObracun.TS = DateTime.Now;

            return true;
        }

        public void ZaduziObracun()
        {
            client.ExecuteNonQuery("Update UF_Obracun Set Zaduzi = 1 Where ID = " + pID);
        }

        /// <summary>
        /// Financijsko zaduživanje ucenika iz odabranog obračuna
        /// </summary>
        /// <returns></returns>
        public bool InsertGlavnaKnjiga(ref int id_shema)
        {
            DataTable dtZaduzenjaUObracunu = GetUcenikzaduzenjeIzObracuna();
            DataTable dtZaduzenjaPoUceniku = GetZaduzenjaPoUceniku();
            id_shema = GetIDShemaOdabir();
            DataTable dtShemaUF = GetShemaKontiranjeByID(id_shema);
            int broj_dokumenta = GetBrojDokumenta();
            int broj_stavke = 0;
            int id_dokument = 997;
            int id_mjesto_troska;
            int id_org_jed;
            string id_konto;
            string duguje;
            string potrazuje;
            decimal cijena = 0;
            DateTime datum_prijave = DateTime.Now;
            int aktivna_godina = GetAktivnaGodina();

            //sumiranje cijena iz uf_ucenikzaduzenje
            foreach (DataRow ucenici_zaduzenje in dtZaduzenjaPoUceniku.Rows)
            {
                foreach (DataRow obracun_zaduzenja in dtZaduzenjaUObracunu.Rows)
                {
                    if (obracun_zaduzenja["UcenikID"].ToString() == ucenici_zaduzenje["UcenikID"].ToString())
                    {
                        cijena = Convert.ToDecimal(obracun_zaduzenja["ZaPlatiti"]) + Convert.ToDecimal(ucenici_zaduzenje["ZaPlatiti"]);
                        ucenici_zaduzenje["ZaPlatiti"] = cijena;
                    }
                }
            }

            foreach (DataRow ucenici_zaduzenje in dtZaduzenjaPoUceniku.Rows)
            {
                int? id = VratiIdIzPartnera(ucenici_zaduzenje["OIB"].ToString());

                if (id != null)
                    ucenici_zaduzenje["UcenikID"] = id;
                else
                    return false;
            }

            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            sqlUpit.Parameters.Add(new SqlParameter("@DatumPrijave", datum_prijave));
            sqlUpit.Parameters.Add(new SqlParameter("@ValutaPlacanja", pValutaPlacanja));

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Upis u glavnu knjigu");

            sqlUpit.Transaction = transakcija;

            try
            {
                foreach (DataRow ucenici_zaduzenje in dtZaduzenjaPoUceniku.Rows)
                {
                    foreach (DataRow shema_kontiranja in dtShemaUF.Rows)
                    {
                        broj_stavke++;
                        id_mjesto_troska = (int)shema_kontiranja["ID_MJESTO_TROSKA"];
                        id_org_jed = (int)shema_kontiranja["ID_ORG_JED"];
                        id_konto = shema_kontiranja["ID_KONTO"].ToString().Trim();

                        if (Convert.ToInt32(shema_kontiranja["ID_STRANE_KNJIZENJA"]) == 1)
                        {
                            duguje = Convert.ToDecimal(ucenici_zaduzenje["ZaPlatiti"]).ToString().Replace(',', '.');
                            potrazuje = "0";

                            sqlUpit.CommandText = "Insert Into GKSTAVKA (DATUMDOKUMENTA, BROJDOKUMENTA, BROJSTAVKE, IDDOKUMENT, IDMJESTOTROSKA, IDORGJED, IDKONTO, OPIS, duguje, POTRAZUJE, " +
                            "DATUMPRIJAVE, IDPARTNER, ZATVORENIIZNOS, statusgk, ORIGINALNIDOKUMENT, GKGODIDGODINE, GKDATUMVALUTE) Values " +
                            "(@DatumPrijave, " + broj_dokumenta + ", " + broj_stavke + ", " + id_dokument + ", " + id_mjesto_troska + ", " + id_org_jed + ", '" + id_konto + "', " +
                            "'" + pNaziv + "', '" + duguje.ToString() + "', '" + potrazuje + "', @DatumPrijave, " + (int)ucenici_zaduzenje["UcenikID"] + ", '0', '0', " +
                            "'Učeničko fakturiranje', " + aktivna_godina + ", @ValutaPlacanja)";
                        }
                        else
                        {
                            potrazuje = Convert.ToDecimal(ucenici_zaduzenje["ZaPlatiti"]).ToString().Replace(',', '.');
                            duguje = "0";

                            sqlUpit.CommandText = "Insert Into GKSTAVKA (DATUMDOKUMENTA, BROJDOKUMENTA, BROJSTAVKE, IDDOKUMENT, IDMJESTOTROSKA, IDORGJED, IDKONTO, OPIS, duguje, POTRAZUJE, " +
                            "DATUMPRIJAVE, IDPARTNER, ZATVORENIIZNOS, statusgk, ORIGINALNIDOKUMENT, GKGODIDGODINE, GKDATUMVALUTE) Values " +
                            "(@DatumPrijave, " + broj_dokumenta + ", " + broj_stavke + ", " + id_dokument + ", " + id_mjesto_troska + ", " + id_org_jed + ", '" + id_konto + "', " +
                            "'" + pNaziv + "', '" + duguje.ToString() + "', '" + potrazuje + "', @DatumPrijave, " + (int)ucenici_zaduzenje["UcenikID"] + ", '" + potrazuje + "', '0', " +
                            "'Učeničko fakturiranje', " + aktivna_godina + ", @ValutaPlacanja)";
                        }

                        sqlUpit.ExecuteNonQuery();

                    }
                    broj_stavke = 0;
                }

                transakcija.Commit();

            }
            catch
            {
                transakcija.Rollback();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Brisanje sheme UF u bazi
        /// </summary>
        /// <returns></returns>
        public bool DeleteShema()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Delete from UF_ShemaKontiranje Where ID_SHEMA = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID", pIDShema));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            sqlUpit.CommandText = "Delete from UF_Shema Where ID = @ID";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Unos nove sheme u bazu
        /// </summary>
        /// <returns></returns>
        public bool InsertShema()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Insert Into UF_Shema (IDDOKUMENT, NAZIV) Values (@IDDOKUMENT, @NAZIV) Select @@Identity";

            sqlUpit.Parameters.Add(new SqlParameter("@IDDOKUMENT", pShema_id_dokumenta));
            sqlUpit.Parameters.Add(new SqlParameter("@NAZIV", pShema_naziv));

            try
            {
                pIDShema = Convert.ToInt32(sqlUpit.ExecuteScalar());
            }
            catch
            {
                return false;
            }

            foreach (DataRow  red in UI.Fakturiranje.uscShema.pShemaKontiranja.Rows)
            {
                sqlUpit.CommandText = "Insert Into UF_ShemaKontiranje (ID_SHEMA, ID_IRA_VRSTA_IZNOSA, ID_STRANE_KNJIZENJA, ID_MJESTO_TROSKA, ID_ORG_JED, ID_KONTO) " +
                                  "Values ('" + pIDShema + "', '" + red["ID_IRA_VRSTA_IZNOSA"] + "', '" + red["ID_STRANE_KNJIZENJA"] + 
                                  "', '" + red["ID_MJESTO_TROSKA"] + "', '" + red["ID_ORG_JED"] + "', '" + red["ID_KONTO"] + "')";
                try
                {
                    sqlUpit.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Editiranje postojece sheme u bazi
        /// </summary>
        /// <returns></returns>
        public bool EditShema()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Update UF_Shema Set IDDOKUMENT = @IDDOKUMENT, NAZIV = @NAZIV Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@IDDOKUMENT", pShema_id_dokumenta));
            sqlUpit.Parameters.Add(new SqlParameter("@NAZIV", pShema_naziv));
            sqlUpit.Parameters.Add(new SqlParameter("@ID", pIDShema));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            sqlUpit.CommandText = "Delete from UF_ShemaKontiranje Where ID_SHEMA = @ID";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            foreach (DataRow red in UI.Fakturiranje.uscShema.pShemaKontiranja.Rows)
            {
                sqlUpit.CommandText = "Insert Into UF_ShemaKontiranje (ID_SHEMA, ID_IRA_VRSTA_IZNOSA, ID_STRANE_KNJIZENJA, ID_MJESTO_TROSKA, ID_ORG_JED, ID_KONTO) " +
                                  "Values ('" + pIDShema + "', '" + red["ID_IRA_VRSTA_IZNOSA"] + "', '" + red["ID_STRANE_KNJIZENJA"] +
                                  "', '" + red["ID_MJESTO_TROSKA"] + "', '" + red["ID_ORG_JED"] + "', '" + red["ID_KONTO"] + "')";
                try
                {
                    sqlUpit.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        public bool BrisiUcenika()
        {
            int obracun_stavka_id = 0;

            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "Select ID From UF_ObracunStavka Where ObracunID = @ObracunID And UcenikID = @UcenikID And RazrednoOdjeljenjeID = @RazrednoOdjeljenjeID";

            sqlUpit.Parameters.Add(new SqlParameter("@ObracunID", pID));
            sqlUpit.Parameters.Add(new SqlParameter("@UcenikID", pIDUcenik));
            sqlUpit.Parameters.Add(new SqlParameter("@RazrednoOdjeljenjeID", pIDRazrednoOdjeljenje));

            try
            {
                obracun_stavka_id = (int)sqlUpit.ExecuteScalar();
            }
            catch
            {
                return false;
            }

            sqlUpit.CommandText = "Delete from UF_UcenikZaduzenje Where ObracunID = @ObracunID And ObracunStavkaID = @ObracunStavkaID";

            sqlUpit.Parameters.Add(new SqlParameter("@ObracunStavkaID", obracun_stavka_id));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            sqlUpit.CommandText = "Delete from UF_ObracunStavkaCjenik Where ObracunID = @ObracunID And ObracunStavkaID = @ObracunStavkaID";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            sqlUpit.CommandText = "Delete from UF_ObracunStavka Where ObracunID = @ObracunID And ID = @ObracunStavkaID";

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }

            return true;
        }
                
        #endregion

        public DataTable GetRekapitulacijaIspis(int id)
        {
            DataTable dt = client.GetDataTable("Select * From v_UF_RekapitulacijaObracuna Where ID = " + id + " Order by Prezime,Ime");
            return dt;
        }

        public DataTable GetRekapitulacijaRazrednoOdjeljenjeIspis(int id, int razredno_odjeljenje_id)
        {
            DataTable dt = client.GetDataTable("Select * From v_UF_RekapitulacijaObracuna Where ID = " + id + " And RazrednoOdjeljenjeID = " + razredno_odjeljenje_id + " Order by Prezime,Ime");
            return dt;
        }

        internal bool CreateRacuni()
        {
            DataTable dtRacuni = client.GetDataTable("Select UF_ObracunStavka.ID, PARTNER.IDPARTNER, UF_Obracun.ValutaPlacanja, UF_Obracun.Naziv, " +
                                "(Select Sum(IznosStavka + (IznosStavka * FINPOREZ.FINPOREZSTOPA/100)) From UF_ObracunStavkaCjenik " +
                                "Inner Join UF_CjenikStavka On UF_ObracunStavkaCjenik.CjenikStavkaID = UF_CjenikStavka.ID Inner Join UF_Proizvod On UF_CjenikStavka.ProizvodID = UF_Proizvod.ID " +
                                "Inner Join FINPOREZ On UF_Proizvod.PorezID = FINPOREZ.FINPOREZIDPOREZ Where ObracunStavkaID = UF_ObracunStavka.ID) As UkupanIznos, UF_Ucenik.ID As ucenikID, " +
                                "UF_Ucenik.OIB As ucenikOIB, UF_ObracunStavka.RazrednoOdjeljenjeID As razredID " +
                                "From PARTNER Inner Join UF_Ucenik On UF_Ucenik.OIB = PARTNER.PARTNEROIB Inner Join UF_ObracunStavka On UF_Ucenik.ID = UF_ObracunStavka.UcenikID Inner Join " +
                                "UF_Obracun On UF_Obracun.ID = UF_ObracunStavka.ObracunID Where UF_ObracunStavka.ObracunID = '" + pID + "' And OIB IN(Select PARTNEROIB From PARTNER Where Ucenik = 1) " +
                                "And (Select Sum(IznosStavka) From UF_ObracunStavkaCjenik Where ObracunStavkaID = UF_ObracunStavka.ID) > 0");

            DataRow ustanova = client.GetDataTable("Select Broj, Model, PozivNaBroj01, ModelOdobrenja, PozivNaBrojOdobrenja, ModelOdobrenja2, SifraUstanove From UF_Ustanova Where ID = " + pUstanova).Rows[0];

            DataTable dtStavke = new DataTable();
            int brojStavke;
            int brojRacuna;
            int activeYear = Convert.ToInt32(client.ExecuteScalar("Select IDGODINE From GODINE Where GODINEAKTIVNA = 1"));
            string datum = pDatumIzdavanja.ToString("yyyy.MM.dd");
            string datumNapomena = pDatumIzdavanja.ToString("dd.MM.yyyy");
            string valuta = string.Empty;

            string model = string.Empty;
            string poziv = string.Empty;
            string pdvNapomena = GetPDVNapomena();
            decimal otvoreneStavke;
            bool prikazOtvoreno = GetIsOtvoreno();
            string napomena = string.Empty;

            foreach (DataRow row in dtRacuni.Rows)
            {
                brojStavke = 1;

                model = GetModel(ustanova);
                poziv = GetPoziv(ustanova, row);

                if (prikazOtvoreno)
                {
                    otvoreneStavke = GetOtvoreneStavke(row["ucenikID"], pDatumIzdavanja);

                    if (otvoreneStavke > 0)
                    {
                        napomena = "Na dan " + datumNapomena + " dug je " + Math.Round(Math.Abs(otvoreneStavke), 2) + "kn";
                    }
                    else if (otvoreneStavke < 0)
                    {
                        napomena = "Na dan " + datumNapomena + " preplata je " + Math.Round(Math.Abs(otvoreneStavke), 2) + "kn";
                    }
                    else
                    {
                        napomena = "Na dan " + datumNapomena + " nema dugovanja";
                    }

                    if (pdvNapomena.Length > 0)
                    {
                        napomena = pdvNapomena + ", " + napomena;
                    }
                }
                else
                {
                    napomena = pdvNapomena;
                }

                dtStavke = client.GetDataTable("Select UF_Proizvod.ID, UF_Proizvod.Naziv, UF_Proizvod.Cijena, UF_ObracunStavkaCjenik.StvarnaKolicina, (UF_ObracunStavkaCjenik.IznosStavka + (UF_ObracunStavkaCjenik.IznosStavka * FINPOREZ.FINPOREZSTOPA/100)) As IznosStavka, " +
                "Case When UF_ObracunStavkaCjenik.StvarnaKolicina = 0 Then 0 Else ((1- (UF_ObracunStavkaCjenik.IznosStavka/UF_Proizvod.Cijena/UF_ObracunStavkaCjenik.StvarnaKolicina)) * 100) End As Rabat, " +
                "FINPOREZ.FINPOREZSTOPA From UF_ObracunStavkaCjenik Inner Join UF_CjenikStavka On UF_CjenikStavka.ID = UF_ObracunStavkaCjenik.CjenikStavkaID Inner Join UF_Proizvod On UF_CjenikStavka.ProizvodID = UF_Proizvod.ID " +
                "Inner join FINPOREZ On FINPOREZ.FINPOREZIDPOREZ = UF_Proizvod.PorezID Where UF_ObracunStavkaCjenik.ObracunStavkaID = '" + row["ID"].ToString() + "' And UF_ObracunStavkaCjenik.IznosStavka > 0");

                brojRacuna = GetNextID(activeYear);
                valuta = Convert.ToDateTime(row["ValutaPlacanja"]).ToString("yyyy.MM.dd");

                client.ExecuteNonQuery("Insert Into RACUN (IDRACUN, RACUNGODINAIDGODINE, IDPARTNER, DATUM, VALUTA, MODEL, POZIV, NAPOMENA, ZAPREDUJAM, Vrsta, UkupanIznos, VezaObracun, Ustanova, Zaduzen) Values " +
                                       "('" + brojRacuna + "', '" + activeYear + "', '" + row["IDPARTNER"].ToString() + "', '" + datum + "', '" + valuta +
                                       "', '" + model + "', '" + poziv + "', '" + napomena + "', 'false', 'UF', '" + row["UkupanIznos"].ToString().Replace(',', '.') + "', '" + pID + "', '" + pUstanova + "', 0)");

                foreach (DataRow rowSt in dtStavke.Rows)
                {
                    client.ExecuteNonQuery("Insert Into RACUNRacunStavke (IDRACUN, RACUNGODINAIDGODINE, BROJSTAVKE, IDPROIZVOD, NAZIVPROIZVODRACUN, CIJENARACUN, RABAT, KOLICINA, FINPOREZSTOPARACUN, CijenaPDV) " +
                                    "Values ('" + brojRacuna + "', '" + activeYear + "', '" + brojStavke + "', '" + rowSt["ID"].ToString() + "', '" + rowSt["Naziv"].ToString() +
                                    "', '" + rowSt["Cijena"].ToString().Replace(',', '.') + "', '" + rowSt["Rabat"].ToString().Replace(',', '.') + "', '" + rowSt["StvarnaKolicina"].ToString().Replace(',', '.') +
                                    "', '" + rowSt["FINPOREZSTOPA"].ToString().Replace(',', '.') + "', '" + rowSt["IznosStavka"].ToString().Replace(',', '.') + "')");

                    brojStavke++;
                }
            }

            return true;
        }

        private string GetPoziv(DataRow ustanova, DataRow row)
        {
            string rkp = client.ExecuteScalar("Select Top(1) RKP From KORISNIK").ToString();

            string mjesec = client.ExecuteScalar("Select MjesecObracuna From UF_Obracun Where ID = " + pID).ToString();
            string godina = client.ExecuteScalar("Select SUBSTRING(CAST(GodinaObracuna as nvarchar(4)),3,2) From UF_Obracun Where ID = " + pID).ToString();

            if (mjesec.Length == 1)
            {
                mjesec = "0" + mjesec;
            }

            if (ustanova["Broj"].ToString() == "1" && ustanova["PozivNaBroj01"].ToString().Length > 0)
            {
                return ustanova["PozivNaBroj01"].ToString().Trim() + "-" + rkp + "-" + row["ucenikOIB"].ToString();
            }
            else if (ustanova["Broj"].ToString() == "2" && ustanova["ModelOdobrenja2"].ToString().Length > 0)
            {
                return mjesec + godina + "-" + ustanova["SifraUstanove"].ToString() + row["razredID"].ToString() + "-" + row["ucenikOIB"].ToString();
            }
            else if (ustanova["Broj"].ToString() == "3" && ustanova["PozivNaBrojOdobrenja"].ToString().Length > 0)
            {
                return ustanova["PozivNaBrojOdobrenja"].ToString().Trim() + "-" + row["ucenikOIB"].ToString() + "-" + row["ucenikID"].ToString();
            }
            else
            {
                return "0000";
            }
        }

        private string GetModel(DataRow ustanova)
        {
            if (ustanova["Broj"].ToString() == "1" && ustanova["Model"].ToString().Length > 0)
            {
                return ustanova["Model"].ToString();
            }
            else if (ustanova["Broj"].ToString() == "2" && ustanova["ModelOdobrenja2"].ToString().Length > 0)
            {
                return ustanova["ModelOdobrenja2"].ToString();
            }
            else if (ustanova["Broj"].ToString() == "3" && ustanova["PozivNaBrojOdobrenja"].ToString().Length > 0)
            {
                return ustanova["ModelOdobrenja"].ToString();
            }
            else
            {
                return "00";
            }
        }

        private bool GetIsOtvoreno()
        {
            return Convert.ToBoolean(client.ExecuteScalar("Select OtvoreneStavke From UF_Ustanova Where ID = " + pUstanova));
        }

        private decimal GetOtvoreneStavke(object ucenikID, DateTime datum)
        {
            string godina = client.ExecuteScalar("Select IDGODINE From GODINE Where GODINEAKTIVNA = 1").ToString();

            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            sqlUpit.CommandText = "SELECT Distinct (Select ISNULL(SUM(dbo.GKSTAVKA.DUGUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) - " +
                                  "(SELECT Distinct (Select ISNULL(SUM(dbo.GKSTAVKA.POTRAZUJE - dbo.GKSTAVKA.ZATVORENIIZNOS), 0) From dbo.GKSTAVKA " +
                                  "INNER JOIN dbo.PARTNER ON dbo.GKSTAVKA.IDPARTNER = dbo.PARTNER.IDPARTNER INNER JOIN UF_Ucenik On PARTNER.PARTNEROIB = UF_Ucenik.OIB " +
                                  "Where UF_Ucenik.ID = @ID And GKGODIDGODINE = @godina And IDKONTO Not Like '9%' and POTRAZUJE  > 0 And GKSTAVKA.DATUMDOKUMENTA <= @datum " + 
                                  "AND GKSTAVKA.DATUMDOKUMENTA >= CAST(@godina As NvarChar) + '-01-01') AS Potrazuje FROM dbo.GKSTAVKA) " +
                                  "From dbo.GKSTAVKA INNER JOIN dbo.PARTNER ON dbo.GKSTAVKA.IDPARTNER = dbo.PARTNER.IDPARTNER INNER JOIN UF_Ucenik On PARTNER.PARTNEROIB = UF_Ucenik.OIB " +
                                  "Where UF_Ucenik.ID = @ID And GKGODIDGODINE = @godina And IDKONTO Not Like '9%' and DUGUJE > 0 And GKSTAVKA.DATUMDOKUMENTA <= @datum AND " + 
                                  "GKSTAVKA.DATUMDOKUMENTA >= CAST(@godina As NvarChar) + '-01-01') AS Otvoreno FROM dbo.GKSTAVKA";
            
            sqlUpit.Parameters.Add(new SqlParameter("@ID", ucenikID.ToString()));
            sqlUpit.Parameters.Add(new SqlParameter("@datum", datum));
            sqlUpit.Parameters.Add(new SqlParameter("@godina", godina));

            decimal otvoreno = 0;

            try
            {
                otvoreno = Convert.ToDecimal(sqlUpit.ExecuteScalar());
            }
            catch {}

            return otvoreno;
        }

        private string GetPDVNapomena()
        {
            bool pdvNapomena = Convert.ToBoolean(client.ExecuteScalar("Select PDVNapomena From UF_Ustanova Where ID = " + pUstanova));
            
            if(pdvNapomena)
            {
                return "OSL.PL.PDV po čl.39 zakona o PDV";
            }

            return string.Empty;
        }        

        private int GetNextID(int year)
        {
            int parser;
            string number = client.ExecuteScalar("Select Max(IDRACUN) From Racun Where RACUNGODINAIDGODINE = " + year).ToString();


            if (Int32.TryParse(number, out parser))
            {
                return Convert.ToInt32(number) + 1;
            }
            else
            {
                return 1;
            }

           
        }

        internal bool ProvjeraUcenikPartner()
        {
            DataTable dtOsobe = client.GetDataTable("Select UF_Ucenik.ID, OIB From UF_Ucenik Inner Join UF_ObracunStavka On UF_Ucenik.ID = UF_ObracunStavka.UcenikID " +
                                "Where UF_ObracunStavka.ID = " + pID + " And OIB Not In(Select PARTNEROIB From PARTNER Where Ucenik = 1)");

            if (dtOsobe.Rows.Count > 0)
            {
                return false;
            }

            return true;
        }

        internal bool GetZaduzen()
        {
            UF_Obracun clsObracun = base.Database.UF_Obracun.SingleOrDefault(o => o.ID == pID);

            if (clsObracun.Zaduzi)
            {
                return true;
            }
            return false;
        }
    }
}
