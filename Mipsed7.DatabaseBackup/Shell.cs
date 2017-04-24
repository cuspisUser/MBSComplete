using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mipsed7.DatabaseBackup.ApplicationLogic;
using Mipsed7.DatabaseBackup.ApplicationLogic.Enums;
using Mipsed7.DatabaseBackup.ApplicationLogic.Entity;

using System.Runtime.InteropServices;

namespace Mipsed7.DatabaseBackup
{
    public class Shell : System.Windows.Forms.ApplicationContext
    {
        public Shell()
        {
            try
            {
                // Kod pokretanja servisa, postavljamo postavke za kontinuirani rad servisa
                Mipsed7.Core.ApplicationDatabaseInformation.AutoBackup_MIPSED7_dbBackup_StartAutomatically = "1";
                Mipsed7.Core.ApplicationDatabaseInformation.AutoBackup_MIPSED7_dbBackup = AppDomain.CurrentDomain.BaseDirectory + "MIPSED.7.dbbackup.exe";

                // setting up periodically backup every 3 hours
                // 1000 milliseconds = 1 second 
                // * 60 = 1 minute 
                // * 60 = 1 hour 
                // * 3 = 3 hours
                System.Timers.Timer timer = new System.Timers.Timer(1000 * 60 * 60 * 3);
                timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                timer.Enabled = true;
                timer.Start();

                // inicijalni start
                Start();
            }
            catch (Exception exception)
            {
                new Mipsed7.Emailing.SendException(exception).Send();
            }
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Start();
        }

        /// <summary>
        /// Pokrećemo proceduru BACKUP-a
        /// </summary>
        public void Start()
        {
            // ----------------------------------------------------------------------------------------------------------------------------
            // Automatski backup baze
            // ----------------------------------------------------------------------------------------------------------------------------
            // postavljamo automatski backup ukoliko nije podešen
            if (string.IsNullOrEmpty(Mipsed7.Core.ApplicationDatabaseInformation.AutoBackup_MIPSED7_dbBackup_StartAutomatically))
                Mipsed7.Core.ApplicationDatabaseInformation.AutoBackup_MIPSED7_dbBackup_StartAutomatically = "1";

            if (Mipsed7.Core.ApplicationDatabaseInformation.AutoBackup_MIPSED7_dbBackup_StartAutomatically == "1")
            {
                Mipsed7.Core.ApplicationDatabaseInformation.AutoBackup_MIPSED7_dbBackup = AppDomain.CurrentDomain.BaseDirectory + "MIPSED.7.dbbackup.exe";
            }
            else
            {
                Mipsed7.Core.ApplicationDatabaseInformation.AutoBackup_MIPSED7_dbBackup = string.Empty;

                // gasimo aplikaciju
                System.Diagnostics.Process.GetCurrentProcess().Kill();

                // ukoliko automatski backup nije podešen, izađi iz procedure
                return;
            }


            // pristup INTERNETU - ukoliko je FALSE izađi iz procedure
            if (!IsConnectedToInternet())
                return;

            // STEP #1 - planiranje backupo-ova
            DatabaseMaintenance databaseMaintenance = new DatabaseMaintenance();
            ZipFile zipFile = new ZipFile();
            FTPClient ftpClient = new FTPClient();

            string oibKorisnika = Mipsed7.Core.ApplicationDatabaseInformation.OIB;
            string databaseBackupFilename = string.Empty;
            string backupPath = string.Empty;


            // ----------------------------------------------
            // DNEVNI backup
            // ----------------------------------------------
            databaseBackupFilename = string.Format("{0}_database_{1}_dnevni_{2}_{3}_{4}.bak", Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName.Replace(" ", "_"), oibKorisnika, DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

            DatabaseObject databaseObject = new DatabaseObject(DatabaseType.Dnevna, oibKorisnika, databaseBackupFilename);

            // provjera
            if (!ftpClient.FileExists(databaseObject))
            {
                // backup
                databaseMaintenance.Backup(databaseObject, out backupPath);

                // compress file into ZIP archive
                zipFile.CompressFile(backupPath);

                // upload
                ftpClient.FileUpload(databaseObject, backupPath);
            }



            // ----------------------------------------------
            // TJEDNI backup
            // ----------------------------------------------
            databaseBackupFilename = string.Format("{0}_database_{1}_tjedni_{2}_{3}.bak", Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName.Replace(" ", "_"), oibKorisnika, DateTime.Today.Year, ApplicationLogic.Tools.DateTimeTool.WeekIndex(DateTime.Today));

            databaseObject = new DatabaseObject(DatabaseType.Tjedna, oibKorisnika, databaseBackupFilename);

            // provjera
            if (!ftpClient.FileExists(databaseObject))
            {
                // backup
                databaseMaintenance.Backup(databaseObject, out backupPath);

                // compress file into ZIP archive
                zipFile.CompressFile(backupPath);

                // upload
                ftpClient.FileUpload(databaseObject, backupPath);

                // delete daily backups
                ftpClient.DeleteDailyBackups(string.Format("/{0}/{1}", oibKorisnika, DateTime.Today.Year));
            }



            // ----------------------------------------------
            // MJESEČNI backup - prvog u mjesecu za prošli mjesec
            // ----------------------------------------------
            databaseBackupFilename = string.Format("{0}_database_{1}_mjesecni_{2}_{3}.bak", Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName.Replace(" ", "_"), oibKorisnika, DateTime.Today.AddMonths(-1).Year, DateTime.Today.AddMonths(-1).Month);

            databaseObject = new DatabaseObject(DatabaseType.Mjesecna, oibKorisnika, databaseBackupFilename);

            // provjera
            if (!ftpClient.FileExists(databaseObject))
            {
                // backup
                databaseMaintenance.Backup(databaseObject, out backupPath);

                // compress file into ZIP archive
                zipFile.CompressFile(backupPath);

                // upload
                ftpClient.FileUpload(databaseObject, backupPath);

                // delete daily & week backups
                ftpClient.DeleteDailyBackups(string.Format("/{0}/{1}", oibKorisnika, DateTime.Today.Year));
                ftpClient.DeleteWeeklyBackups(string.Format("/{0}/{1}", oibKorisnika, DateTime.Today.Year));
            }

            databaseMaintenance.DeleteBackupFolder();
        }

        //Creating the extern function...
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        //Creating a function that uses the API function...
        public static bool IsConnectedToInternet()
        {
            int description;
            return InternetGetConnectedState(out description, 0);
        }
    }
}
