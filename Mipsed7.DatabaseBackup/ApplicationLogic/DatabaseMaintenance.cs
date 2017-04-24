using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mipsed7.DatabaseBackup.ApplicationLogic.Enums;
using Mipsed7.DatabaseBackup.ApplicationLogic.Entity;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

using System.IO;

namespace Mipsed7.DatabaseBackup.ApplicationLogic
{
    public class DatabaseMaintenance
    {
        public void Backup(DatabaseObject databaseObject, out string backupPath)
        {
            // definiramo backup
            Backup backup = new Backup();

            backup.Action = BackupActionType.Database;
            backup.Database = Mipsed7.Core.ApplicationDatabaseInformation.DatabaseName;
            
            backup.Incremental = false;
            backup.Initialize = true;

            // --------------------------------------------------------------------------------------------------------------
            // Backup Compression is not supported on SQL 2008 Express, Workgroup, or Standard editions, only on Enterprise. 
            // There is no way to turn this on without upgrading your version to Enterprise
            // --------------------------------------------------------------------------------------------------------------
            backup.CompressionOption = BackupCompressionOptions.Off;


            backup.BackupSetName = backup.Database + " database backup";
            backup.BackupSetDescription = backup.Database + " - Full Backup";


            // pripremamo direktorij za backup 
            backupPath = GetRootDrive() + "vugergrad_temp";

            DirectoryInfo directoryInfo = new DirectoryInfo(backupPath);

            if (!directoryInfo.Exists)
                directoryInfo.Create();

            backupPath = backupPath + @"\" + databaseObject.FileName;

            backup.Devices.AddDevice(backupPath, DeviceType.File);

            // definiramo server
            Server server = new Server(Mipsed7.Core.ApplicationDatabaseInformation.ServerName);
            
            server.ConnectionContext.LoginSecure = false;
            server.ConnectionContext.Login = Mipsed7.Core.ApplicationDatabaseInformation.SqlUserName;
            server.ConnectionContext.Password = Mipsed7.Core.ApplicationDatabaseInformation.SqlPassword;
            
            // kreiramo backup
            backup.SqlBackup(server);
        }

        public void DeleteBackupFolder()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(GetRootDrive() + "vugergrad_temp");

            if (directoryInfo.Exists)
                directoryInfo.Delete(true);
        }

        /// <summary>
        /// Funkcija nam vraća path za ROOT drive - "C:\"
        /// </summary>
        /// <returns></returns>
        private string GetRootDrive()
        {
            return Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
        }
    }
}
