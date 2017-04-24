namespace Hlp
{
    using _2gs_datewizard;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class placa
    {
        public static short DaniStaza(decimal nUlaznihGodina, decimal nUlaznihMjeseci, decimal nUlaznihDana, DateTime dtPocetniDatum, DateTime dtZavrsniDatum, decimal nTjedniFondSatiRadnika, decimal nTjedniFondSatiUstanove, decimal decFaktorBeneficiranog)
        {
            int num = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            decFaktorBeneficiranog = decimal.Divide(decFaktorBeneficiranog, 12M);
            try
            {
                num = Convert.ToInt32(Conversion.Int(decimal.Multiply(decimal.Multiply(new decimal(dtZavrsniDatum.Subtract(dtPocetniDatum).Days), decimal.Divide(nTjedniFondSatiRadnika, nTjedniFondSatiUstanove)), decFaktorBeneficiranog)));
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            dtZavrsniDatum = dtPocetniDatum.AddDays((double) num);
            dtPocetniDatum = dtPocetniDatum.AddDays(Convert.ToDouble(decimal.Negate(nUlaznihDana)));
            dtPocetniDatum = dtPocetniDatum.AddMonths(Convert.ToInt32(decimal.Negate(nUlaznihMjeseci)));
            dtPocetniDatum = dtPocetniDatum.AddYears(Convert.ToInt32(decimal.Negate(nUlaznihGodina)));
            C_DateFunctions functions = new C_DateFunctions();
            C_DateInterval interval = new C_DateInterval();
            Y_M_D_Diff(dtPocetniDatum, dtZavrsniDatum, ref num4, ref num5, ref num3);
            functions = null;
            interval = null;
            return (short) num3;
        }

        public static DateTime DatZavrsni(string godina, string mjesec)
        {
            return DateAndTime.DateSerial(Conversions.ToInteger(godina), Conversions.ToInteger(mjesec), DateTime.DaysInMonth(Conversions.ToInteger(godina), Conversions.ToInteger(mjesec)));
        }

        public static short GodineStaza(decimal nUlaznihGodina, decimal nUlaznihMjeseci, decimal nUlaznihDana, DateTime dtPocetniDatum, DateTime dtZavrsniDatum, decimal nTjedniFondSatiRadnika, decimal nTjedniFondSatiUstanove, decimal decFaktorBeneficiranog)
        {
            int num = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            decFaktorBeneficiranog = decimal.Divide(decFaktorBeneficiranog, 12M);
            try
            {
                num = Convert.ToInt32(Conversion.Int(decimal.Multiply(decimal.Multiply(new decimal(dtZavrsniDatum.Subtract(dtPocetniDatum).Days), decimal.Divide(nTjedniFondSatiRadnika, nTjedniFondSatiUstanove)), decFaktorBeneficiranog)));
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
            }
            dtZavrsniDatum = dtPocetniDatum.AddDays((double) num);
            dtPocetniDatum = dtPocetniDatum.AddDays(Convert.ToDouble(decimal.Negate(nUlaznihDana)));
            dtPocetniDatum = dtPocetniDatum.AddMonths(Convert.ToInt32(decimal.Negate(nUlaznihMjeseci)));
            dtPocetniDatum = dtPocetniDatum.AddYears(Convert.ToInt32(decimal.Negate(nUlaznihGodina)));
            C_DateFunctions functions = new C_DateFunctions();
            C_DateInterval interval = new C_DateInterval();
            Y_M_D_Diff(dtPocetniDatum, dtZavrsniDatum, ref num4, ref num5, ref num3);
            functions = null;
            interval = null;
            return (short) num4;
        }

        public static int Krediti_brojrata(int IDRADNIK, int IDKREDITOR, string CNNSTRING, DateTime DATUMUGOVORA)
        {
            decimal num2 = 0;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection {
                ConnectionString = CNNSTRING
            };
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "S_PLACA_KREDITI_DO_ZAD_OBRACUNA";
            command.Parameters.AddWithValue("@IDRADNIK", IDRADNIK);
            command.Parameters.AddWithValue("@IDKREDITOR", IDKREDITOR);
            command.Parameters.AddWithValue("@DATUMUGOVORA", DATUMUGOVORA);
            connection.Open();
            if (command.ExecuteScalar() != DBNull.Value)
            {
                num2 = Conversions.ToDecimal(command.ExecuteScalar());
            }
            connection.Close();
            return Convert.ToInt32(num2);
        }

        public static decimal Krediti_iznos(int IDRADNIK, int IDKREDITOR, string CNNSTRING, DateTime DATUMUGOVORA)
        {
            decimal num2 = 0;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection {
                ConnectionString = CNNSTRING
            };
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "S_PLACA_KREDITI_OBUSTAVLJENO_DO_OBRACUNA";
            command.Parameters.AddWithValue("@IDRADNIK", IDRADNIK);
            command.Parameters.AddWithValue("@IDKREDITOR", IDKREDITOR);
            command.Parameters.AddWithValue("@DATUMUGOVORA", DATUMUGOVORA);
            connection.Open();
            if (command.ExecuteScalar() != DBNull.Value)
            {
                num2 = Conversions.ToDecimal(command.ExecuteScalar());
            }
            connection.Close();
            return num2;
        }

        public static short MjeseciStaza(decimal nUlaznihGodina, decimal nUlaznihMjeseci, decimal nUlaznihDana, DateTime dtPocetniDatum, DateTime dtZavrsniDatum, decimal nTjedniFondSatiRadnika, decimal nTjedniFondSatiUstanove, decimal decFaktorBeneficiranog)
        {
            int num = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            decFaktorBeneficiranog = decimal.Divide(decFaktorBeneficiranog, 12M);
            try
            {
                num = Convert.ToInt32(Conversion.Int(decimal.Multiply(decimal.Multiply(new decimal(dtZavrsniDatum.Subtract(dtPocetniDatum).Days), decimal.Divide(nTjedniFondSatiRadnika, nTjedniFondSatiUstanove)), decFaktorBeneficiranog)));
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            dtZavrsniDatum = dtPocetniDatum.AddDays((double) num);
            dtPocetniDatum = dtPocetniDatum.AddDays(Convert.ToDouble(decimal.Negate(nUlaznihDana)));
            dtPocetniDatum = dtPocetniDatum.AddMonths(Convert.ToInt32(decimal.Negate(nUlaznihMjeseci)));
            dtPocetniDatum = dtPocetniDatum.AddYears(Convert.ToInt32(decimal.Negate(nUlaznihGodina)));
            C_DateFunctions functions = new C_DateFunctions();
            C_DateInterval interval = new C_DateInterval();
            Y_M_D_Diff(dtPocetniDatum, dtZavrsniDatum, ref num4, ref num5, ref num3);
            functions = null;
            interval = null;
            return (short) num5;
        }

        public static decimal Obustave_BROJRATA(int IDRADNIK, int idobustava, string CNNSTRING)
        {
            return decimal.Zero;
        }

        public static decimal Obustave_Iznos(int IDRADNIK, int idobustava, string CNNSTRING)
        {
            decimal num = 0;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection {
                ConnectionString = CNNSTRING
            };
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "S_PLACA_OBUSTAVE_OBUSTAVLJENO_DO_OBRACUNA";
            command.Parameters.AddWithValue("@IDRADNIK", IDRADNIK);
            command.Parameters.AddWithValue("@IDobustava", idobustava);
            connection.Open();
            if (command.ExecuteScalar() != DBNull.Value)
            {
                num = Conversions.ToDecimal(command.ExecuteScalar());
            }
            connection.Close();
            return num;
        }

        public static decimal PovecanjeKoeficijentaZaStaz(int IDRADNIK, DateTime NADATUM, decimal TJEDNIFONDSATI, int BROJPRIZNATIHMJESECI, string cnnstring)
        {
            DateTime dateTime = DateTime.Now;
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection {
                ConnectionString = cnnstring
            };
            command.CommandText = "SELECT GODINESTAZA, MJESECISTAZA,DANISTAZA, DATUMZADNJEGZAPOSLENJAPROMJENEFONDASATI, TJEDNIFONDSATISTAZ FROM RADNIK WHERE IDRADNIK = " + Conversions.ToString(IDRADNIK);
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                num2 = Convert.ToInt32(DB.N20(reader.GetInt16(0)));
                num3 = Convert.ToInt32(DB.N20(reader.GetInt16(1)));
                num = Convert.ToInt32(DB.N20(reader.GetInt16(2)));
                dateTime = reader.GetDateTime(3);
                num4 = Convert.ToInt32(DB.N20(reader.GetDecimal(4)));
            }
            else
            {
                num2 = -1;
            }
            reader.Close();
            connection.Close();
            UkupanRadniStaz(num2, num3, num, dateTime, NADATUM, num4, Convert.ToInt32(TJEDNIFONDSATI), new decimal(((double) BROJPRIZNATIHMJESECI) / 12.0), ref num6, ref num7, ref num5);
            if (num6 >= 0)
            {
                return new decimal(num6 * 0.5);
            }
            return decimal.Zero;
        }

        public static bool PreklapanjeDatumskihRazdoblja(DateTime dtePrvoRazdobljeOd, DateTime dtePrvoRazdobljeDo, DateTime dteDrugoRazdobljeOd, DateTime dteDrugoRazdobljeDo)
        {
            C_DateFunctions functions = new C_DateFunctions();
            return functions.DateRangesOverlap(dtePrvoRazdobljeOd, dtePrvoRazdobljeDo, dteDrugoRazdobljeOd, dteDrugoRazdobljeDo);
        }

        public static int StanjeLokacije(long invbroj, int lokacija, string CNNSTRING)
        {
            int num = 0;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection {
                ConnectionString = CNNSTRING
            };
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "S_OS_STANJE_LOKACIJE";
            command.Parameters.AddWithValue("@invbroj", invbroj);
            command.Parameters.AddWithValue("@lok", lokacija);
            connection.Open();
            if (command.ExecuteScalar() != DBNull.Value)
            {
                num = Convert.ToInt32(Conversions.ToDecimal(command.ExecuteScalar()));
            }
            else
            {
                num = 0;
            }
            connection.Dispose();
            connection.Close();
            return num;
        }

        public static decimal Test(int idradnik, int element, string cnnstring, [Optional, DecimalConstant(0, 0, (uint) 0, (uint) 0, (uint) 0)] decimal OSNOVICA, [Optional, DecimalConstant(0, 0, (uint) 0, (uint) 0, (uint) 0)] decimal SATI)
        {
            decimal num = 0;
            decimal num2 = 0;
            if (decimal.Compare(OSNOVICA, decimal.Zero) == 0)
            {
                OSNOVICA = 5108.42M;
            }
            if (decimal.Compare(SATI, decimal.Zero) == 0)
            {
                SATI = 174M;
            }
            SqlCommand command = new SqlCommand();
            SqlCommand command2 = new SqlCommand();
            SqlConnection connection = new SqlConnection {
                ConnectionString = cnnstring
            };
            command.CommandText = "SELECT     dbo.RADNIKLevel7.DODATNIKOEFICIJENT, dbo.GRUPEKOEFLevel1.IDELEMENT,radnik.TJEDNIFONDSATI  FROM dbo.GRUPEKOEFLevel1 INNER JOIN dbo.RADNIKLevel7 ON dbo.GRUPEKOEFLevel1.IDGRUPEKOEF = dbo.RADNIKLevel7.IDGRUPEKOEF INNER JOIN radnik ON dbo.RADNIKLevel7.IDRADNIK = dbo.RADNIK.IDRADNIK WHERE IDelement = " + Conversions.ToString(element) + " and radnik.idradnik = " + Conversions.ToString(idradnik);
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                num = DB.N20(reader.GetDecimal(0));
                num2 = DB.N20(reader.GetDecimal(2));
            }
            else
            {
                return decimal.Zero;
            }
            reader.Close();
            connection.Close();
            connection.Dispose();
            decimal num4 = decimal.Multiply(decimal.Divide(SATI, 40M), num2);
            return Math.Round(decimal.Divide(decimal.Multiply(num, OSNOVICA), num4), 2);
        }

        public static void UkupanRadniStaz(int nUlaznihGodina, int nUlaznihMjeseci, int nUlaznihDana, DateTime dtPocetniDatum, DateTime dtZavrsniDatum, int nTjedniFondSatiRadnika, int nTjedniFondSatiUstanove, decimal decFaktorBeneficiranog, ref int nUkupnoGodina, ref int nUkupnoMjeseci, ref int nUkupnoDana)
        {
            int num = 0;
            try
            {
                num = Convert.ToInt32(Conversion.Int(decimal.Multiply(decimal.Multiply(new decimal(dtZavrsniDatum.Subtract(dtPocetniDatum).Days), decimal.Divide(new decimal(nTjedniFondSatiRadnika), new decimal(nTjedniFondSatiUstanove))), decFaktorBeneficiranog)));
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            dtZavrsniDatum = dtPocetniDatum.AddDays((double) num);
            dtPocetniDatum = dtPocetniDatum.AddDays((double) (0 - nUlaznihDana));
            dtPocetniDatum = dtPocetniDatum.AddMonths(0 - nUlaznihMjeseci);
            dtPocetniDatum = dtPocetniDatum.AddYears(0 - nUlaznihGodina);
            C_DateFunctions functions = new C_DateFunctions();
            C_DateInterval interval = new C_DateInterval();
            Y_M_D_Diff(dtPocetniDatum, dtZavrsniDatum, ref nUkupnoGodina, ref nUkupnoMjeseci, ref nUkupnoDana);
            functions = null;
            interval = null;
        }

        public static decimal UkupnoFaktorOO(int IDRADNIK, string CNNSTRING)
        {
            decimal num = 0;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection {
                ConnectionString = CNNSTRING
            };
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT SUM(dbo.OSOBNIODBITAK.FAKTOROSOBNOGODBITKA) AS FAKTOR  FROM dbo.RADNIKOdbitak INNER JOIN dbo.OSOBNIODBITAK ON dbo.RADNIKOdbitak.OSOBNIODBITAKZADUZENJEIDOSOBNIODBITAK = dbo.OSOBNIODBITAK.IDOSOBNIODBITAK WHERE (dbo.RADNIKOdbitak.IDRADNIK = @IDRADNIK)";
            command.Parameters.AddWithValue("@IDRADNIK", IDRADNIK);
            connection.Open();
            if (command.ExecuteScalar() != DBNull.Value)
            {
                num = Conversions.ToDecimal(command.ExecuteScalar());
            }
            else
            {
                num = new decimal();
            }
            connection.Close();
            return num;
        }

        public static void Y_M_D_Diff(DateTime DateOne, DateTime DateTwo, ref int nUkupnoGodina, ref int nUkupnoMjeseci, ref int nUkupnoDana)
        {
            int day = 0;
            int month = 0;
            int year = 0;
            if (DateTime.Compare(DateOne, DateTwo) != 0)
            {
                if (DateTwo.Year > DateOne.Year)
                {
                    year = DateTwo.AddYears(0 - DateOne.Year).Year;
                }
                month = DateTwo.AddMonths(0 - DateOne.Month).Month;
                if ((DateTwo.Month <= DateOne.Month) && (year > 0))
                {
                    year--;
                }
                day = DateTwo.AddDays((double) (0 - DateOne.Day)).Day;
                if ((DateTwo.Day <= DateOne.Day) && (month > 0))
                {
                    month--;
                }
                if (DateOne.Day == DateTwo.Day)
                {
                    day = 0;
                    month++;
                }
                if (month == 12)
                {
                    month = 0;
                    year++;
                }
                if ((DateOne.Year == DateTwo.Year) && (DateOne.Month == DateOne.Month))
                {
                    year = 0;
                }
            }
            nUkupnoGodina = year;
            nUkupnoMjeseci = month;
            nUkupnoDana = day;
        }
    }
}

