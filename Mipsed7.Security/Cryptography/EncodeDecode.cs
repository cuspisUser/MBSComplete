using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

using System.Configuration;

namespace Mipsed7.Security.Cryptography
{
    public class EncodeDecode
    {
        private static UInt64[] DESkey = { UInt64.Parse("13651584896467774119"), UInt64.Parse("17666548991976544485"), UInt64.Parse("14598027512390752102")};

        private static UInt64 DESIV = 1947855656165165240;

        private static int UInt64LENGTH = UInt64.MaxValue.ToString().Length;

        public static string Crypt(string value)
        {
            TripleDESCryptoServiceProvider dprov = new TripleDESCryptoServiceProvider();

            dprov.BlockSize = 64;
            dprov.KeySize = 192;
            byte[] IVBuf = BitConverter.GetBytes(DESIV);
            byte[] keyBuf = new byte[24];
            byte[] keyB0 = BitConverter.GetBytes(DESkey[0]);
            byte[] keyB1 = BitConverter.GetBytes(DESkey[1]);
            byte[] keyB2 = BitConverter.GetBytes(DESkey[2]);
            for (int i = 0; i < 8; i++) keyBuf[i] = keyB0[i];
            for (int i = 0; i < 8; i++) keyBuf[i + 8] = keyB1[i];
            for (int i = 0; i < 8; i++) keyBuf[i + 16] = keyB2[i];

            ICryptoTransform ict = dprov.CreateEncryptor(keyBuf, IVBuf);

            System.IO.MemoryStream mstream = new System.IO.MemoryStream();
            CryptoStream cstream = new CryptoStream(mstream, ict, CryptoStreamMode.Write);

            byte[] toEncrypt = new ASCIIEncoding().GetBytes(value);

            // Write the byte array to the crypto stream and flush it.
            cstream.Write(toEncrypt, 0, toEncrypt.Length);
            cstream.FlushFinalBlock();

            byte[] ret = mstream.ToArray();

            cstream.Close();
            mstream.Close();

            return Convert.ToBase64String(ret);
        }

        public static string Decrypt(string value)
        {
            TripleDESCryptoServiceProvider dprov = new TripleDESCryptoServiceProvider();

            dprov.BlockSize = 64;
            dprov.KeySize = 192;
            byte[] IVBuf = BitConverter.GetBytes(DESIV);
            byte[] keyBuf = new byte[24];
            byte[] keyB0 = BitConverter.GetBytes(DESkey[0]);
            byte[] keyB1 = BitConverter.GetBytes(DESkey[1]);
            byte[] keyB2 = BitConverter.GetBytes(DESkey[2]);
            for (int i = 0; i < 8; i++) keyBuf[i] = keyB0[i];
            for (int i = 0; i < 8; i++) keyBuf[i + 8] = keyB1[i];
            for (int i = 0; i < 8; i++) keyBuf[i + 16] = keyB2[i];

            ICryptoTransform ict = dprov.CreateDecryptor(keyBuf, IVBuf);

            byte[] byteData = Convert.FromBase64String(value);

            System.IO.MemoryStream mstream = new System.IO.MemoryStream(byteData);
            CryptoStream cstream = new CryptoStream(mstream, ict, CryptoStreamMode.Read);

            //byte[] toDecrypt = new byte[byteData.Length];

            //cstream.Read(toDecrypt, 0, toDecrypt.Length);

            System.IO.StreamReader str = new System.IO.StreamReader(cstream);

            string ret = str.ReadToEnd();

            //byte[] retb = new UnicodeEncoding().GetBytes(ret);

            str.Close();
            cstream.Close();
            mstream.Close();

            return ret;//UnicodeEncoding.ASCII.GetString(retb);

        }
    }
}