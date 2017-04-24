using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

using Mipsed7.Security.Cryptography;
using Mipsed7.DatabaseBackup.ApplicationLogic.Enums;
using Mipsed7.DatabaseBackup.ApplicationLogic.Entity;

namespace Mipsed7.DatabaseBackup.ApplicationLogic
{
    public class FTPClient
    {
        private string FTPHost
        {
            get { return "ftp.vugergrad.hr"; }
        }
        
        private string Username
        {
            get { return Mipsed7.Security.Cryptography.EncodeDecode.Decrypt("Jf0NZlSV+mRRKppIMk7taHOquEKPc0rA"); }
        }

        private string Password
        {
            get { return Mipsed7.Security.Cryptography.EncodeDecode.Decrypt("kMLUawHnwl0+WVcauenM0oXcG36bTq/F"); }
        }

        private string FTPFolder
        {
            get { return "ftp://ftp.vugergrad.hr/data"; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public FTPClient()
        {
            
        }

        public bool FileExists(DatabaseObject databaseObject)
        {
            // ftp file location
            string requestUriString = this.FTPFolder + "/" + databaseObject.FolderPath + "/" + databaseObject.FileName + ".gz";

            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(requestUriString);
            ftpRequest.Credentials = new NetworkCredential(this.Username, this.Password);
            ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;

            try
            {
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }

        public void FileUpload(DatabaseObject databaseObject, string backupPath)
        {
            // FTP file location
            string requestUriString = this.FTPFolder + "/" + databaseObject.FolderPath + "/" + databaseObject.FileName + ".gz";

            // kreiramo direktorije i pod-direktorije ukoliko ne postoje
            CreateSubDirectories(databaseObject.FolderPath);

            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(requestUriString);
            ftpRequest.Credentials = new NetworkCredential(this.Username, this.Password);
           
            // parametri konekcije
            ftpRequest.UseBinary = true;
            ftpRequest.KeepAlive = true;
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;

            FileStream fileStream = File.OpenRead(backupPath + ".gz");
            Stream ftpStream = ftpRequest.GetRequestStream();

            // kreiramo konstantu
            //const int BUFFERSIZE = 4096;

            // instanciramo buffer
            byte[] buffer = File.ReadAllBytes(backupPath + ".gz");

            try
            {
                // number of bytes actually read
                ftpStream.Write(buffer, 0, buffer.Length);

                /*
                 * Ovaj dio koda je odjedanput prestao raditi, te je zamjenjen sa retkom prije.
                 * Problem je nastao što je bytesRead konstantno bio na BUFFERSIZE 4096, te se zbog toga vrtila LOOP petlja.
                 * Nisam uspio odgonetnuti gdje je bio problem.
                int bytesRead = fileStream.Read(buffer, 0, BUFFERSIZE);

                while (bytesRead != 0)
                {
                    stream.Write(buffer, 0, bytesRead);
                    bytesRead = fileStream.Read(buffer, 0, BUFFERSIZE);
                }
                */
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();

                if (ftpStream != null)
                    ftpStream.Close();
            }
        }

        private void CreateSubDirectories(string folders)
        {
            string[] subFolders = folders.Split('/');

            string folderToCreate = string.Empty;

            foreach (string folder in subFolders)
            {
                try
                {
                    folderToCreate = folderToCreate + "/" + folder;

                    FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(this.FTPFolder + folderToCreate);
                    ftpRequest.Credentials = new NetworkCredential(this.Username, this.Password);
                    ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;

                    FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    ftpResponse.Close();
                }
                catch (Exception) { }
            }
        }

        internal void DeleteDailyBackups(string subfolders)
        {
            string folderToDelete = this.FTPFolder + subfolders + "/dnevni";

            try
            {
                // delete files before - if folder is not empty on removing, ERROR 550 is thrown (access denied)
                DeleteFilesInfolders(folderToDelete);

                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(folderToDelete);
                ftpRequest.Credentials = new NetworkCredential(this.Username, this.Password);
                ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;

                FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpResponse.Close();
            }
            catch { }
        }

        internal void DeleteWeeklyBackups(string subfolders)
        {
            string folderToDelete = this.FTPFolder + subfolders + "/tjedni";

            try
            {
                // delete files before - if folder is not empty on removing, ERROR 550 is thrown (access denied)
                DeleteFilesInfolders(folderToDelete);

                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(folderToDelete);
                ftpRequest.Credentials = new NetworkCredential(this.Username, this.Password);
                ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;

                FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpResponse.Close();
            }
            catch { }
        }

        internal void DeleteFilesInfolders(string subfolder)
        {
            // list all files
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(subfolder);
            ftpRequest.Credentials = new NetworkCredential(this.Username, this.Password);
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;

            FtpWebResponse ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(ftpResponse.GetResponseStream(), System.Text.Encoding.ASCII);

            // delete files
            string[] files = streamReader.ReadToEnd().Replace("\r\n", "|").Split(new char[] { '|' }).Where(f => f != "").ToArray();
            streamReader.Close();

            foreach (string file in files)
            {
                try
                {
                    // delete file
                    FtpWebRequest ftpRequestFile = (FtpWebRequest)WebRequest.Create(subfolder + "/" + file);
                    ftpRequestFile.Credentials = new NetworkCredential(this.Username, this.Password);
                    ftpRequestFile.Method = WebRequestMethods.Ftp.DeleteFile;

                    FtpWebResponse ftpResponseFile = (FtpWebResponse)ftpRequestFile.GetResponse();
                    ftpResponseFile.Close();
                }
                catch { }
            }

            ftpResponse.Close();
        }
    }
}
