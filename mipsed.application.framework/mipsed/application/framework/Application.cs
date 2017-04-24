using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using CrystalDecisions.CrystalReports.Engine;



namespace mipsed.application.framework
{
    
    public class Application
    {
        private static bool isUserKorisnikValid = false;
        public static ValidationEventHandler schemaValidation = new ValidationEventHandler(Application.ValidationHandler);

        public static int Analitika()
        {
            SqlConnection connection = new SqlConnection(Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString);
            string cmdText = "SELECT TOP 1 ANALITIKA FROM KORISNIK";
            int num2 = 0;
            try
            {
                connection.Open();
                num2 = Conversions.ToInteger(new SqlCommand(cmdText) { CommandType = CommandType.Text, Connection = connection }.ExecuteScalar());
            }
            catch (System.Exception)
            {
                num2 = 5;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            if (num2 > 0)
            {
                return int.Parse(Conversions.ToString(num2));
            }
            return 5;
        }

        public static string GenerateMD5(string SourceText)
        {
            byte[] bytes = new UnicodeEncoding().GetBytes(SourceText);
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            return Convert.ToBase64String(provider.ComputeHash(bytes));
        }

        public static string GetModulePath(string assemblyFile)
        {
            if (!Path.IsPathRooted(assemblyFile))
            {
                assemblyFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyFile);
            }
            return assemblyFile;
        }

        public static XmlSchema GetSchema(string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return XmlSchema.Read(reader, null);
                }
            }
        }

        public static Assembly LoadAssembly(string assemblyFile)
        {
            assemblyFile = GetModulePath(assemblyFile);
            FileInfo info = new FileInfo(assemblyFile);
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFrom(info.FullName);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }

            return assembly;
        }

        public static bool Login(string userName, string password)
        {
            return true;
        }

        public static void PostaviParametreIzvjestaja(ref CrystalDecisions.CrystalReports.Engine.ReportDocument rpt)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;
            string str4 = string.Empty;
            string str5 = string.Empty;
            string str6 = string.Empty;
            string str7 = string.Empty;
            SqlConnection connection = new SqlConnection(Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString);
            string cmdText = "SELECT TOP 1 korisnik1naziv,korisnik1adresa,korisnik1mjesto,kontakttelefon,kontaktfax,email,korisnikoib FROM KORISNIK";
            try
            {
                connection.Open();
                SqlDataReader reader = new SqlCommand(cmdText) { CommandType = CommandType.Text, Connection = connection }.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    str6 = Conversions.ToString(reader["KORISNIK1NAZIV"]);
                    str4 = Conversions.ToString(reader["KORISNIK1ADRESA"]);
                    str5 = Conversions.ToString(reader["KORISNIK1MJESTO"]);
                    str3 = Conversions.ToString(reader["KONTAKTTELEFON"]);
                    str2 = Conversions.ToString(reader["KONTAKTFAX"]);
                    str = Conversions.ToString(reader["EMAIL"]);
                    str7 = Conversions.ToString(reader["KORISNIKOIB"]);
                }
                reader.Close();
            }
            catch (System.Exception exception1)
            {
                throw exception1;                
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            rpt.SetParameterValue("naziv", str6);
            rpt.SetParameterValue("adresa", str4 + ", " + str5);
            rpt.SetParameterValue("telefonfaxmail", "Telefon: " + str3 + " Fax: " + str2 + " Email: " + str);
            rpt.SetParameterValue("OIB", "Osobni identifikacijski broj: " + str7);
        }

        public string ReadResourceValue(string file, string key)
        {
            string str2 = string.Empty;
            try
            {
                string baseName = file;
                string resourceDir = AppDomain.CurrentDomain.BaseDirectory.ToString();
                str2 = ResourceManager.CreateFileBasedResourceManager(baseName, resourceDir, null).GetString(key);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }

            return string.Empty;
        }

        public static object UpdateDatabase()
        {
            Microsoft.SqlServer.Management.Smo.Server server = new Microsoft.SqlServer.Management.Smo.Server(Mipsed7.Core.ApplicationDatabaseInformation.ServerName);
            Microsoft.SqlServer.Management.Smo.Database database = new Microsoft.SqlServer.Management.Smo.Database();

            server.ConnectionContext.LoginSecure = false;
            server.ConnectionContext.Login = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
            server.ConnectionContext.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;

            server.ConnectionContext.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
            server.ConnectionContext.SqlExecutionModes = SqlExecutionModes.ExecuteAndCaptureSql;
            // ----------------------------------------------------------------------------------------------------
            // 14.08.2012. - Matija Božičević
            // Gasimo sve prijašnje update-ove jer nam rade greške i vraćaju storane procedure na stare verzije!
            // ----------------------------------------------------------------------------------------------------

            // ----------------------------------------------------------------------------------------------------
            // Od verzije 7.0.0.0, update-ovi se primjenjuju putem *.SQL datoteka
            // Matija Božičević - 09.08.2012
            // ----------------------------------------------------------------------------------------------------

            string[] sqlUpdateFiles = new string[] { 
                "SQL_1_0_0_2.sql",
                "SQL_1_0_0_4.sql",
                "SQL_1_0_0_5.sql",
                "SQL_1_0_0_6.sql",
                "SQL_1_0_0_7.sql",
                "SQL_1_0_0_9.sql",
                "SQL_1_0_1_0.sql",
                "SQL_1_0_1_1.sql",
                "SQL_1_0_1_2.sql",
                "SQL_1_0_1_3.sql",
                "SQL_1_0_1_5.sql",
                "SQL_1_0_1_6.sql",
                "SQL_1_0_1_7.sql",
                "SQL_1_0_1_8.sql",
                "SQL_1_0_1_9.sql",
                "SQL_1_0_2_0.sql",
                "SQL_1_0_2_1.sql",
                "SQL_1_0_2_2.sql",
                "SQL_1_0_2_3.sql",
                "SQL_1_0_2_8.sql"
                };

            foreach (string sqlUpdateFile in sqlUpdateFiles)
            {
                double sqlUpdateVersion = 0;
                try
                {
                    sqlUpdateVersion = double.Parse(sqlUpdateFile.ToLower().Replace("sql", string.Empty).Replace("_", string.Empty).Replace(".", string.Empty));

                    if (double.Parse(Mipsed7.Core.ApplicationDatabaseInformation.DatabaseVersion) < sqlUpdateVersion)
                        server.ConnectionContext.ExecuteNonQuery(Update_OpenSQLQueryFile(sqlUpdateFile));
                }
                catch (Exception exception)
                {
                    new Mipsed7.Emailing.SendException(exception).DatabaseUpdateFailed(sqlUpdateFile, Mipsed7.Core.ApplicationDatabaseInformation.DatabaseVersion);
                }
            }

            // update-amo bazu po trenutnoj verziji software-a
            //ubacen dio u catch-u zbog togha jer kod nekih nije prolazio update baze.
            try
            {
                server.ConnectionContext.ExecuteNonQuery("UPDATE dbo.VERZIJA SET VERZIJA = '" + Mipsed7.Core.ApplicationDatabaseInformation.ProgramVersion + "' WHERE IDVERZIJA = 1");
            }
            catch
            {
                Mipsed7.DataAccessLayer.SqlClient client = new Mipsed7.DataAccessLayer.SqlClient();
                client.ExecuteNonQuery("UPDATE dbo.VERZIJA SET VERZIJA = '" + Mipsed7.Core.ApplicationDatabaseInformation.ProgramVersion + "' WHERE IDVERZIJA = 1");
            }
            // ----------------------------------------------------------------------------------------------------

            return true;
        }

        /// <summary>
        /// Funkcija za otvaranje update-ova napisanih u SQL datoteka
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private static string Update_OpenSQLQueryFile(string filename)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            StreamReader streamReader = new StreamReader(assembly.GetManifestResourceStream("mipsed.application.framework.SQL_updates." + filename));

            string query = streamReader.ReadToEnd();

            return query;
        }

        public static object UpdateNoviZakon()
        {
            Microsoft.SqlServer.Management.Smo.Server server = new Microsoft.SqlServer.Management.Smo.Server(Mipsed7.Core.ApplicationDatabaseInformation.ServerName);
            Microsoft.SqlServer.Management.Smo.Database database = new Microsoft.SqlServer.Management.Smo.Database();

            server.ConnectionContext.LoginSecure = false;
            server.ConnectionContext.Login = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
            server.ConnectionContext.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;

            server.ConnectionContext.DatabaseName = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
            server.ConnectionContext.SqlExecutionModes = SqlExecutionModes.ExecuteAndCaptureSql;
            try
            {
                server.ConnectionContext.ExecuteNonQuery(FrameworkResources.novizakon, ExecutionTypes.ContinueOnError);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            return true;
        }

        public static bool ValidateXml(string xmlFileName, string xmlSchemaName, ref string poruka)
        {
            bool flag = false;
            using (FileStream stream = new FileStream(xmlFileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                XmlDocument document = new XmlDocument();
                document.Load(stream);
                document.Schemas.Add(GetSchema(xmlSchemaName));
                try
                {
                    document.Validate(schemaValidation);
                    flag = true;
                }
                catch (XmlSchemaValidationException exception1)
                {
                    throw exception1;
                    //poruka = exception1.ToString();
                    //flag = false;
                }
                catch (XmlSchemaException exception4)
                {
                    throw exception4;
                    //poruka = exception4.ToString();
                    //flag = false;
                }
                catch (System.Exception exception5)
                {
                    throw exception5;
                    //poruka = exception5.ToString();
                    //flag = false;
                }
            }
            return flag;
        }

        public static void ValidationHandler(object sender, ValidationEventArgs e)
        {
            throw e.Exception;
        }

        public static short ActiveYear
        {
            get
            {
                short num = 0;
                SqlConnection connection = new SqlConnection(Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString);
                string cmdText = "SELECT idgodine FROM godine WHERE GODINEAKTIVNA = 1";
                int num2 = 0;
                try
                {
                    connection.Open();
                    num2 = Conversions.ToInteger(new SqlCommand(cmdText) { CommandType = CommandType.Text, Connection = connection }.ExecuteScalar());
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    
                    //num2 = 0x270f;
                    
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
                if (num2 > 0)
                {
                    return (short) int.Parse(Conversions.ToString(num2));
                }
                num2 = 0x270f;
                return num;
            }
        }

        public static DateTime Pocetni
        {
            get
            {
                SqlConnection connection = new SqlConnection(Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString);
                string cmdText = "SELECT idgodine FROM godine WHERE GODINEAKTIVNA = 1";
                int year = 0;
                try
                {
                    connection.Open();
                    year = Conversions.ToInteger(new SqlCommand(cmdText) { CommandType = CommandType.Text, Connection = connection }.ExecuteScalar());
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
                if (year <= 0)
                {
                    throw new IncorrectDatabaseFormatException();
                }
                return DateAndTime.DateSerial(year, 1, 1);
            }
        }

        public static bool UserSettingsValid
        {
            get
            {
                return isUserKorisnikValid;
            }
        }

        public static DateTime Zavrsni
        {
            get
            {
                SqlConnection connection = new SqlConnection(Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString);
                string cmdText = "SELECT idgodine FROM godine WHERE GODINEAKTIVNA = 1";
                int year = 0;
                try
                {
                    connection.Open();
                    year = Conversions.ToInteger(new SqlCommand(cmdText) { CommandType = CommandType.Text, Connection = connection }.ExecuteScalar());
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
                if (year <= 0)
                {
                    throw new IncorrectDatabaseFormatException();
                }
                return DateAndTime.DateSerial(year, 12, 0x1f);
            }
        }
    }
}

