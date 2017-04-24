using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mipsed7.DatabaseBackup.ApplicationLogic.Enums;

namespace Mipsed7.DatabaseBackup.ApplicationLogic.Entity
{
    public class DatabaseObject
    {
        public DatabaseType DatabaseType { get; set; }
        public string OIBkorisnika { get; set; }
        public string FileName { get; set; }
        public string FolderPath { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="databaseType"></param>
        /// <param name="oibKorisnika"></param>
        /// <param name="fileName"></param>
        public DatabaseObject(DatabaseType databaseType, string oibKorisnika, string fileName)
        {
            this.DatabaseType = databaseType;
            this.OIBkorisnika = oibKorisnika;
            this.FileName = fileName;
            this.FolderPath = FolderPathConstruct();
        }

        /// <summary>
        /// Funkcija koja je zaslužna za konstrukciju foldera i putanja
        /// </summary>
        /// <returns></returns>
        private string FolderPathConstruct()
        {
            switch (DatabaseType)
            {
                case Enums.DatabaseType.Dnevna:
                    return string.Format("{0}/{1}/dnevni", this.OIBkorisnika, DateTime.Today.Year);

                case Enums.DatabaseType.Tjedna:
                    return string.Format("{0}/{1}/tjedni", this.OIBkorisnika, DateTime.Today.Year);

                case Enums.DatabaseType.Mjesecna:
                    return string.Format("{0}/{1}/mjesecni", this.OIBkorisnika, DateTime.Today.Year);
            }

            return "-";
        }
    }
}
