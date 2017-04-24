using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Mipsed7.DataAccessLayer;
using System.Data.SqlClient;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace JavnaNabava.BusinessLogic
{
    public class PlanNabave : Base
    {
        SqlClient client = null;
        public PlanNabave()
            : base()
        {
            client = new SqlClient();
        }

        #region Svojstva

        public static int pSelectedIndex
        {
            get;
            set;
        }

        public static int? pID
        {
            get;
            set;
        }

        public static int? pID_Ustanova
        {
            get;
            set;
        }

        public static int? pID_FiskalnaGodina
        {
            get;
            set;
        }

        public static string pNaziv
        {
            get;
            set;
        }

        public static string pKlasa
        {
            get;
            set;
        }

        public static string pUrBroj
        {
            get;
            set;
        }

        public static decimal? pSaPorezomUkupno
        {
            get;
            set;
        }

        public static int? pID_Stavka
        {
            get;
            set;
        }

        public static string pID_Konto
        {
            get;
            set;
        }

        public static decimal? pBezPoreza
        {
            get;
            set;
        }

        public static decimal? pSaPorezom
        {
            get;
            set;
        }

        public static int? pID_StopaPoreza
        {
            get;
            set;
        }

        public static int? pID_VrstaNabave
        {
            get;
            set;
        }

        public static DataTable pStavkePlanNabave
        {
            get;
            set;
        }

        public static string pOpisStavka
        {
            get;
            set;
        }

        public static DateTime pIspisPlanaNabave
        {
            get;
            set;
        }

        #endregion

        #region DohvatPodataka

        /// <summary>
        /// Dohvat stopa poreza za comobox
        /// </summary>
        /// <returns></returns>
        public DataTable GetStopePoreza()
        {
            DataTable dtStope = client.GetDataTable("Select FINPOREZIDPOREZ As ID, FINPOREZNAZIVPOREZ As Naziv, FINPOREZSTOPA As Stopa From FINPOREZ Order by FINPOREZSTOPA Desc");
            return dtStope;
        }

        /// <summary>
        /// Dohvat vrsta nabave za combobox
        /// </summary>
        /// <returns></returns>
        public DataTable GetVrsteNabave()
        {
            DataTable dtVrsteNabava = client.GetDataTable("Select ID, Naziv From JN_VrstaNabave");
            return dtVrsteNabava;
        }

        public DataTable GetKonto()
        {
            DataTable dtKonto = client.GetDataTable("Select RTRIM(IDKONTO) As ID, (RTRIM(IDKONTO) + ' | ' + RTRIM(NAZIVKONTO)) As Naziv From KONTO");
            return dtKonto;
        }

        public DataTable GetUstanova()
        {
            DataTable dtUstanova = client.GetDataTable("Select ID, Naziv From UF_Ustanova");
            return dtUstanova;
        }

        public DataTable GetFiskalnaGodina()
        {
            DataTable dtFiskalnaGodina = client.GetDataTable("Select IDGODINE As ID, IDGODINE As Naziv From GODINE");
            return dtFiskalnaGodina;
        }

        public DataTable GetPlanNabaveIspis(int ? id)
        {
            DataTable dt_plan_nabave = client.GetDataTable("Select * From v_JN_PlanNabave Where ID = " + id);
            return dt_plan_nabave;
        }

        public DataSet GetPlanNabaveMainGrid()
        {
            DataSet ds = new DataSet();

            DataTable dtPlanNabave = client.GetDataTable("Select JN_PlanNabave.ID, UF_Ustanova.Naziv As Ustanova, JN_PlanNabave.ID_FiskalnaGodina As [Fiskalna godina], " + 
                                                             "JN_PlanNabave.naziv As Opis, JN_PlanNabave.SaPorezomUkupno As [Ukupna vrijednost sa porezom] From JN_PlanNabave " +
                                                             "Inner Join UF_Ustanova on JN_PlanNabave.ID_Ustanova = UF_Ustanova.ID");

            DataTable dtPlanNabaveStavka = client.GetDataTable("Select JN_PlanNabaveStavka.ID, JN_PlanNabaveStavka.ID_PlanNabave, JN_PlanNabaveStavka.ID_Konto As Konto, " + 
                                                               "JN_PlanNabaveStavka.BezPoreza, FINPOREZ.FINPOREZNAZIVPOREZ, JN_PlanNabaveStavka.SaPorezom, JN_VrstaNabave.Naziv " + 
                                                               "From JN_PlanNabaveStavka Inner Join FINPOREZ on JN_PlanNabaveStavka.ID_StopaPoreza = FINPOREZ.FINPOREZIDPOREZ " +
                                                               "Inner Join JN_VrstaNabave on JN_PlanNabaveStavka.ID_VrstaNabave = JN_VrstaNabave.ID");

            ds.Tables.Add(dtPlanNabave);
            ds.Tables.Add(dtPlanNabaveStavka);

            DataRelation relPlanNabave = new DataRelation("PLAN_NABAVE", dtPlanNabave.Columns["ID"], dtPlanNabaveStavka.Columns["ID_PlanNabave"]);

            ds.Relations.Add(relPlanNabave);
            return ds;
        }

        public bool PlanNabaveByID()
        {
            DataTable dtPlanNabave = client.GetDataTable("Select ID_Ustanova, ID_FiskalnaGodina, Naziv, Klasa, UrBroj, SaPorezomUkupno From JN_PlanNabave Where ID = '" + pID + "'");

            DataRow red = dtPlanNabave.Rows[0];

            try
            {
                pID_Ustanova = (int)red["ID_Ustanova"];
                pID_FiskalnaGodina = Convert.ToInt32(red["ID_FiskalnaGodina"]);
                pNaziv = red["Naziv"].ToString();
                pKlasa = red["Klasa"].ToString();
                pUrBroj = red["UrBroj"].ToString();
                pSaPorezomUkupno = Convert.ToDecimal(red["SaPorezomUkupno"]);
            }
            catch
            {
                return false;
            }

            DataTable dtPlanNabaveStavka = client.GetDataTable("Select 'false' As SEL, JN_PlanNabaveStavka.ID_Konto As Konto, KONTO.NAZIVKONTO As [Naziv konta], " +
                                                               "JN_PlanNabaveStavka.BezPoreza As [Procijenjena vrijednost bez poreza], JN_PlanNabaveStavka.ID_StopaPoreza, " +
                                                               "JN_PlanNabaveStavka.SaPorezom As [Procijenjena vrijednost sa porezom], JN_PlanNabaveStavka.ID_VrstaNabave, " +
                                                               "JN_VrstaNabave.Naziv As [Vrsta nabave], OpisStavka From JN_PlanNabaveStavka " +
                                                               "Inner Join JN_VrstaNabave on JN_PlanNabaveStavka.ID_VrstaNabave = JN_VrstaNabave.ID " +
                                                               "Inner Join KONTO on JN_PlanNabaveStavka.ID_Konto = KONTO.IDKONTO " +
                                                               "Inner Join FINPOREZ on JN_PlanNabaveStavka.ID_StopaPoreza = FINPOREZ.FINPOREZIDPOREZ Where ID_PlanNabave = '" + pID + "'");
            pStavkePlanNabave = dtPlanNabaveStavka;

            return true;
        }

        #endregion

        #region RadSaPodacima

        public bool Delete()
        {
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;
            bool kontrola = false;

            sqlUpit.CommandText = "Delete From JN_PlanNabaveStavka Where ID_PlanNabave = @ID";
            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
                kontrola = true;
            }
            catch
            {
                kontrola = false;
            }

            sqlUpit.CommandText = "Delete From JN_PlanNabave Where ID = @ID";

            try
            {
                sqlUpit.ExecuteNonQuery();
                kontrola = true;
            }
            catch
            {
                kontrola = false;
            }
            return kontrola;
        }

        public bool Insert(StringBuilder message, UltraGrid ugdPlanNabaveStavka)
        {
            string bez_poreza = string.Empty;
            string sa_porezom = string.Empty;
            string opis_stavka = string.Empty;
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Plan nabave");
            sqlUpit.Transaction = transakcija;

            sqlUpit.CommandText = "Insert Into JN_PlanNabave (ID_Ustanova, ID_FiskalnaGodina, Naziv, Klasa, UrBroj, SaPorezomUkupno, TS) " +
                                  "Values (@ID_Ustanova, @ID_FiskalnaGodina, @Naziv, @Klasa, @UrBroj, @SaPorezomUkupno, @TS) Select @@Identity";

            sqlUpit.Parameters.Add(new SqlParameter("@ID_Ustanova", pID_Ustanova));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_FiskalnaGodina", pID_FiskalnaGodina));
            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", pNaziv));
            sqlUpit.Parameters.Add(new SqlParameter("@Klasa", pKlasa));
            sqlUpit.Parameters.Add(new SqlParameter("@UrBroj", pUrBroj));
            sqlUpit.Parameters.Add(new SqlParameter("@SaPorezomUkupno", pSaPorezomUkupno));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));

            try
            {
                pID = Convert.ToInt32(sqlUpit.ExecuteScalar());
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                transakcija.Rollback();
                return false;
            }

            try
            {
                foreach (UltraGridRow red in ugdPlanNabaveStavka.Rows)
                {
                    pID_Konto = red.Cells["Konto"].Value.ToString().Trim();
                    pBezPoreza = Convert.ToDecimal(red.Cells["Procijenjena vrijednost bez poreza"].Value);
                    pID_StopaPoreza = (int?)red.Cells["ID_StopaPoreza"].Value;
                    pSaPorezom = Convert.ToDecimal(red.Cells["Procijenjena vrijednost sa porezom"].Value);
                    pID_VrstaNabave = (int?)red.Cells["ID_VrstaNabave"].Value;
                    sa_porezom = pSaPorezom.ToString().Replace(',', '.');
                    bez_poreza = pBezPoreza.ToString().Replace(',', '.');
                    opis_stavka = red.Cells["OpisStavka"].Value.ToString();

                    sqlUpit.CommandText = "Insert Into JN_PlanNabaveStavka (ID_PlanNabave, ID_Konto, BezPoreza, ID_StopaPoreza, SaPorezom, ID_VrstaNabave, TS, OpisStavka) " +
                                          "Values (" + pID + ", '" + pID_Konto + "', '" + bez_poreza + "', " + pID_StopaPoreza + ", '" + sa_porezom + "', " + pID_VrstaNabave + 
                                          ", @TS, '" + opis_stavka + "')";

                    sqlUpit.ExecuteNonQuery();
                }

            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                transakcija.Rollback();
                return false;
            }

            transakcija.Commit();
            return true;
        }

        public bool Update(StringBuilder message, UltraGrid ugdPlanNabaveStavka)
        {
            string bez_poreza = string.Empty;
            string sa_porezom = string.Empty;
            string opis_stavka = string.Empty;
            SqlCommand sqlUpit = new SqlCommand();
            sqlUpit.Connection = client.sqlConnection;
            sqlUpit.CommandType = CommandType.Text;

            SqlTransaction transakcija = sqlUpit.Connection.BeginTransaction("Plan nabave");
            sqlUpit.Transaction = transakcija;

            sqlUpit.CommandText = "Update JN_PlanNabave Set ID_Ustanova = @ID_Ustanova, ID_FiskalnaGodina = @ID_FiskalnaGodina, Naziv = @Naziv, Klasa = @Klasa, " +
                                  "UrBroj = @UrBroj, SaPorezomUkupno = @SaPorezomUkupno, TS = @TS Where ID = @ID";

            sqlUpit.Parameters.Add(new SqlParameter("@ID_Ustanova", pID_Ustanova));
            sqlUpit.Parameters.Add(new SqlParameter("@ID_FiskalnaGodina", pID_FiskalnaGodina));
            sqlUpit.Parameters.Add(new SqlParameter("@Naziv", pNaziv));
            sqlUpit.Parameters.Add(new SqlParameter("@Klasa", pKlasa));
            sqlUpit.Parameters.Add(new SqlParameter("@UrBroj", pUrBroj));
            sqlUpit.Parameters.Add(new SqlParameter("@SaPorezomUkupno", pSaPorezomUkupno));
            sqlUpit.Parameters.Add(new SqlParameter("@TS", DateTime.Now));
            sqlUpit.Parameters.Add(new SqlParameter("@ID", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                transakcija.Rollback();
                return false;
            }


            sqlUpit.CommandText = "Delete From JN_PlanNabaveStavka Where ID_PlanNabave = @ID_PlanNabave";
            sqlUpit.Parameters.Add(new SqlParameter("@ID_PlanNabave", pID));

            try
            {
                sqlUpit.ExecuteNonQuery();
            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                transakcija.Rollback();
                return false;
            }

            try
            {
                foreach (UltraGridRow red in ugdPlanNabaveStavka.Rows)
                {
                    pID_Konto = red.Cells["Konto"].Value.ToString().Trim();
                    pBezPoreza = Convert.ToDecimal(red.Cells["Procijenjena vrijednost bez poreza"].Value);
                    pID_StopaPoreza = (int?)red.Cells["ID_StopaPoreza"].Value;
                    pSaPorezom = Convert.ToDecimal(red.Cells["Procijenjena vrijednost sa porezom"].Value);
                    pID_VrstaNabave = (int?)red.Cells["ID_VrstaNabave"].Value;
                    sa_porezom = pSaPorezom.ToString().Replace(',', '.');
                    bez_poreza = pBezPoreza.ToString().Replace(',', '.');
                    opis_stavka = red.Cells["OpisStavka"].Value.ToString();

                    sqlUpit.CommandText = "Insert Into JN_PlanNabaveStavka (ID_PlanNabave, ID_Konto, BezPoreza, ID_StopaPoreza, SaPorezom, ID_VrstaNabave, TS, OpisStavka) " +
                                          "Values (" + pID + ", '" + pID_Konto + "', '" + bez_poreza + "', " + pID_StopaPoreza + ", '" + sa_porezom + "', " + pID_VrstaNabave +
                                          ", @TS, '" + opis_stavka + "')";

                    sqlUpit.ExecuteNonQuery();
                }

            }
            catch (Exception greska)
            {
                message.Append(greska.Message);
                transakcija.Rollback();
                return false;
            }

            transakcija.Commit();
            return true;
        }

        #endregion

    }
}
