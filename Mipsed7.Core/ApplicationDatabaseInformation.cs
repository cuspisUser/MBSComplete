using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Reflection;
using System.Security.AccessControl;
using Microsoft.Win32;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace Mipsed7.Core
{
    public class ApplicationDatabaseInformation
    {

        private static RegistryKey MipsedRootKey
        {
            get
            {
                return Registry.LocalMachine.CreateSubKey("SOFTWARE\\PIS_INFO"); 
            }
        }

        public static string OIB
        {
            get
            {
                return (string)MipsedRootKey.GetValue("OIB", "");
            }
            set
            {
                MipsedRootKey.SetValue("OIB", value);
            }
        }

        public static string AutoBackup_MIPSED7_dbBackup
        {
            get
            {
                return (string)Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValue("MIPSED7 dbBackup Automatically", "");
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue("MIPSED7 dbBackup Automatically", value);
                else // ukoliko je VALUE prazan, obriši u registry-u podatak
                    Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).DeleteValue("MIPSED7 dbBackup Automatically", false);
            }
        }  

        public static string AutoBackup_MIPSED7_dbBackup_StartAutomatically
        {
            get
            {
                return (string)MipsedRootKey.GetValue("MIPSED7 dbBackup Automatically", "");
            }
            set
            {
                MipsedRootKey.SetValue("MIPSED7 dbBackup Automatically", value);
            }
        }        

        public static string ServerName
        {
            get
            {
                return (string)MipsedRootKey.GetValue("ServerName", "");
            }
            set
            {
                MipsedRootKey.SetValue("ServerName", value);
            }
        }

        public static string SMTPClient_Exceptions
        {
            get
            {
                return (string)MipsedRootKey.GetValue("SMTPClient_Exceptions", "");
            }
            set
            {
                MipsedRootKey.SetValue("SMTPClient_Exceptions", value);
            }
        }

        public static string SqlUserName_REGISTRY_ORIGINAL
        {
            get
            {
                return MipsedRootKey.GetValue("SqlUserName", "").ToString();
            }
        }

        public static string SqlUserName
        {
            get
            {
                string val = MipsedRootKey.GetValue("SqlUserName", "").ToString();

                if (!string.IsNullOrEmpty(val))
                    return Mipsed7.Security.Cryptography.EncodeDecode.Decrypt(val);
                else
                    return val;
            }
            set
            {
                MipsedRootKey.SetValue("SqlUserName", value);
            }
        }

        public static string SqlPassword_REGISTRY_ORIGINAL
        {
            get
            {
                return MipsedRootKey.GetValue("SqlPassword", "").ToString();
            }
        }

        public static string SqlPassword
        {
            get
            {
                string val = MipsedRootKey.GetValue("SqlPassword", "").ToString();

                if (!string.IsNullOrEmpty(val))
                    return Mipsed7.Security.Cryptography.EncodeDecode.Decrypt(val);
                else
                    return val;
            }
            set
            {
                MipsedRootKey.SetValue("SqlPassword", value);
            }
        }

        public static string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = ServerName,
                    InitialCatalog = DatabaseName
                };

                builder.IntegratedSecurity = false;
                builder.UserID = SqlUserName;
                builder.Password = SqlPassword;

                return builder.ConnectionString;
            }
            set
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(value);
                ServerName = builder.DataSource;
                DatabaseName = builder.InitialCatalog;

                SqlUserName = builder.UserID;
                SqlPassword = builder.Password;
            }
        }

        public static string DatabaseName
        {
            get
            {
                return (string)MipsedRootKey.GetValue("DatabaseName", "");
            }
            set
            {
                MipsedRootKey.SetValue("DatabaseName", value);
            }
        }

        public static string ProgramVersion
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                return version.Major + "." + version.Minor + "." + version.Build + "." + version.Revision;
            }
        }

        public static string DatabaseVersion
        {
            get
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                string sql = "SELECT verzija FROM verzija WHERE idverzija = 1";

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql)
                    {
                        Connection = connection
                    };

                    return command.ExecuteScalar().ToString();
                }
                catch (Exception) { }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
                DbConnectionStringBuilder builder = new DbConnectionStringBuilder
                {
                    ConnectionString = ConnectionString
                };
                Microsoft.SqlServer.Management.Smo.Server server = new Microsoft.SqlServer.Management.Smo.Server(ServerName);
                Microsoft.SqlServer.Management.Smo.Database database = new Microsoft.SqlServer.Management.Smo.Database();

                server.ConnectionContext.LoginSecure = false;
                server.ConnectionContext.Login = SqlUserName;
                server.ConnectionContext.Password = SqlPassword;

                return "VERZIJA baze nije postavljena! [dbo.VERZIJA]";
            }
        }

        public static string KorisnikAplikacije
        {
            get
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                string sql = "SELECT TOP 1(KORISNIK1NAZIV) FROM dbo.KORISNIK";

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql)
                    {
                        Connection = connection
                    };

                    return command.ExecuteScalar().ToString();
                }
                catch (System.Exception) { }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
                DbConnectionStringBuilder builder = new DbConnectionStringBuilder
                {
                    ConnectionString = ConnectionString
                };
                Microsoft.SqlServer.Management.Smo.Server server = new Microsoft.SqlServer.Management.Smo.Server(ServerName);
                Microsoft.SqlServer.Management.Smo.Database database = new Microsoft.SqlServer.Management.Smo.Database();

                server.ConnectionContext.LoginSecure = false;
                server.ConnectionContext.Login = SqlUserName;
                server.ConnectionContext.Password = SqlPassword;

                return "KORISNIK aplikacije nije postavljen! [dbo.KORISNIK]";
            }
        }

        /// <summary>
        /// ID vezan uz aktivnost koju bilježimo u WEB bazi
        /// </summary>
        public static string KorisnikAktivnost_ID
        {
            get;
            set;
        }

        public static string Modul_Place
        {
            get { return (string)MipsedRootKey.GetValue("Modul_Place", ""); }
            set { MipsedRootKey.SetValue("Modul_Place", value); }
        }

        public static string Modul_Honorari
        {
            get { return (string)MipsedRootKey.GetValue("Modul_Honorari", ""); }
            set { MipsedRootKey.SetValue("Modul_Honorari", value); }
        }

        public static string Modul_Finpos
        {
            get { return (string)MipsedRootKey.GetValue("Modul_Finpos", ""); }
            set { MipsedRootKey.SetValue("Modul_Finpos", value); }
        }

        public static string Modul_eDokumenti
        {
            get { return (string)MipsedRootKey.GetValue("Modul_eDokumenti", ""); }
            set { MipsedRootKey.SetValue("Modul_eDokumenti", value); }
        }

        public static string Modul_Erv
        {
            get { return (string)MipsedRootKey.GetValue("Modul_Erv", ""); }
            set { MipsedRootKey.SetValue("Modul_Erv", value); }
        }

        public static string Modul_Praksa
        {
            get { return (string)MipsedRootKey.GetValue("Modul_Praksa", ""); }
            set { MipsedRootKey.SetValue("Modul_Praksa", value); }
        }

        public static string Modul_Imovina
        {
            get { return (string)MipsedRootKey.GetValue("Modul_Imovina", ""); }
            set { MipsedRootKey.SetValue("Modul_Imovina", value); }
        }

        public static string Modul_KorisnikSifrarnici
        {
            get { return (string)MipsedRootKey.GetValue("Modul_KorisnikSifrarnici", ""); }
            set { MipsedRootKey.SetValue("Modul_KorisnikSifrarnici", value); }
        }

        public static string Modul_ServisneFunkcije
        {
            get { return (string)MipsedRootKey.GetValue("Modul_ServisneFunkcije", ""); }
            set { MipsedRootKey.SetValue("Modul_ServisneFunkcije", value); }
        }

        public static string Modul_JavnaNabava
        {
            get { return (string)MipsedRootKey.GetValue("Modul_JavnaNabava", ""); }
            set { MipsedRootKey.SetValue("Modul_JavnaNabava", value); }
        }

        public static string Modul_Materijalno
        {
            get { return (string)MipsedRootKey.GetValue("Modul_Materijalno", ""); }
            set { MipsedRootKey.SetValue("Modul_Materijalno", value); }
        }

        public static string Modul_PutniNalog
        {
            get { return (string)MipsedRootKey.GetValue("Modul_PutniNalog", ""); }
            set { MipsedRootKey.SetValue("Modul_PutniNalog", value); }
        }

        public static string Modul_COP
        {
            get { return (string)MipsedRootKey.GetValue("Modul_COP", ""); }
            set { MipsedRootKey.SetValue("Modul_COP", value); }
        }

        public static string Modul_JOPPD
        {
            get { return (string)MipsedRootKey.GetValue("Modul_JOPPD", ""); }
            set { MipsedRootKey.SetValue("Modul_JOPPD", value); }
        }

        public static string Modul_JOPPDRazno
        {
            get { return (string)MipsedRootKey.GetValue("Modul_JOPPDRazno", ""); }
            set { MipsedRootKey.SetValue("Modul_JOPPDRazno", value); }
        }

        public static string Modul_UF
        {
            get { return (string)MipsedRootKey.GetValue("Modul_UF", ""); }
            set { MipsedRootKey.SetValue("Modul_UF", value); }
        }

        public static string Modul_Raspored
        {
            get { return (string)MipsedRootKey.GetValue("Modul_Raspored", ""); }
            set { MipsedRootKey.SetValue("Modul_Raspored", value); }
        }

        /// <summary>
        /// Top;Bottom;Left;Right
        /// </summary>
        public static string Margine
        {
            get { return (string)MipsedRootKey.GetValue("Margine", ""); }
            set { MipsedRootKey.SetValue("Margine", value); }
        }
    }
}
