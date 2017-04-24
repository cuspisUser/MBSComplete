using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO.Compression;
using System.IO;

namespace Mipsed7.DatabaseBackup.ApplicationLogic
{
    public class ZipFile
    {
        public void CompressFile(string backupPath)
        {
            // učitavamo *.BAK datoteku
            FileStream sourceFile = File.OpenRead(backupPath);

            // kreiramo *.ZIP datoteku

            // Ovdje smo imali problem da je datoteka koja se zip-ala, izgubila extenziju!

            // ------------------------------------------------------------------------------
            // GZip only compresses one file - without knowing the name. Therefore if you compress the file myReport.xls you should name it myReport.xls.gz. 
            // On decompression the last file extension will be removed so you end up with the original filename.
            // ------------------------------------------------------------------------------
            FileStream destinationFile = File.Create(backupPath + ".gz");

            // kreiramo *.GZ arhivu
            GZipStream gZipStream = new GZipStream(destinationFile, CompressionMode.Compress);

            try
            {
                // kopiraj BACKUP file u GZ file
                sourceFile.CopyTo(gZipStream);
            }
            catch (Exception ex)
            {
                // throw-aj exception i šalji na email
                throw ex;
            }
            finally
            {
                gZipStream.Dispose();
                sourceFile.Dispose();
                destinationFile.Dispose();
            }
        }
    }
}
