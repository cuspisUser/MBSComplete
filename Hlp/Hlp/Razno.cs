namespace Hlp
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Windows.Forms;

    public class Razno
    {
        public static string Cash2Text(double Cash)
        {
            string str4 = "";
            int piSiTri = 0;
            string str = Strings.Format(Cash, "###0.00");
            int length = Strings.InStr(str, ",", CompareMethod.Binary);
            if (length == 0)
            {
                length = Strings.Len(str);
            }
            else
            {
                length--;
            }
            if (Operators.ConditionalCompareObjectEqual(Conversion.Int(str), 0, false))
            {
                str4 = "Nula kuna";
            }
            else
            {
                string str7 = Strings.Mid(str, 1, length);
                while (length > 0)
                {
                    string str6 = string.Empty;
                    int num4 = length;
                    if (num4 >= 3)
                    {
                        str6 = Strings.Mid(str7, length - 2, 3);
                    }
                    else if (num4 == 2)
                    {
                        str6 = Strings.Mid(str7, 1, 2);
                    }
                    else if (num4 == 1)
                    {
                        str6 = Strings.Mid(str7, 1, 1);
                    }
                    long triBroja = (long) Math.Round(Conversion.Val(str6));
                    string str8 = Upisi(triBroja, piSiTri);
                    length -= 3;
                    piSiTri++;
                    str4 = str8 + str4;
                }
            }
            string str5 = " i " + Strings.Right(str, 2) + "/100";
            return (str4 + " " + str5);
        }

        private static FileStream GetFileStream(string pathName)
        {
            return new FileStream(pathName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }

        public static string GetSHA1Hash(string pathName)
        {
            string str3 = "";
            FileStream inputStream = null;
            SHA1CryptoServiceProvider provider = new SHA1CryptoServiceProvider();
            try
            {
                inputStream = GetFileStream(pathName);
                byte[] buffer = provider.ComputeHash(inputStream);
                inputStream.Close();
                str3 = BitConverter.ToString(buffer).Replace("-", "");
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
            }
            return str3;
        }

        public static string KontrolniBroj(string strPoziv)
        {
            int num3 = 0;
            string expression = strPoziv.Replace("-", "");
            int num = 0;
            int num6 = Strings.Len(expression) - 1;
            for (int i = 0; i <= num6; i++)
            {
                int num4 = (Strings.Len(expression) + 1) - i;
                num = (int) Math.Round((double) (num + (num4 * Conversions.ToDouble(expression.Substring(i, 1)))));
            }
            int num2 = num % 11;
            if (((11 - num2) == 11) | ((11 - num2) == 10))
            {
                num3 = 0;
            }
            else
            {
                num3 = 11 - num2;
            }
            return Conversions.ToString(num3);
        }

        public static string Upisi(long TriBroja, int PiSiTri)
        {
            int num = 0;
            string str = string.Empty;
            string str2 = string.Empty;
            string str3 = string.Empty;
            string str4 = string.Empty;
            int num3 = 0;
            long num4 = TriBroja;
            if (num4 > 0x383L)
            {
                str = "devetsto";
                num3 = 30;
            }
            else if (num4 > 0x31fL)
            {
                str = "osamsto";
                num3 = 30;
            }
            else if (num4 > 0x2bbL)
            {
                str = "sedamsto";
                num3 = 30;
            }
            else if (num4 > 0x257L)
            {
                str = "šeststo";
                num3 = 30;
            }
            else if (num4 > 0x1f3L)
            {
                str = "petsto";
                num3 = 30;
            }
            else if (num4 > 0x18fL)
            {
                str = "četristo";
                num3 = 30;
            }
            else if (num4 > 0x12bL)
            {
                str = "tristo";
                num3 = 30;
            }
            else if (num4 > 0xc7L)
            {
                str = "dvjesto";
                num3 = 30;
            }
            else if (num4 > 0x63L)
            {
                str = "sto";
                num3 = 30;
            }
            int num2 = (int) (TriBroja % 100L);
            if (!((num2 < 20) & (num2 >= 10)))
            {
                switch (((int) Math.Round(Conversion.Int((double) (((double) num2) / 10.0)))))
                {
                    case 2:
                        str2 = "dvadeset";
                        break;

                    case 3:
                        str2 = "trideset";
                        break;

                    case 4:
                        str2 = "četrdeset";
                        break;

                    case 5:
                        str2 = "pedeset";
                        break;

                    case 6:
                        str2 = "šezdeset";
                        break;

                    case 7:
                        str2 = "sedamdeset";
                        break;

                    case 8:
                        str2 = "osamdeset";
                        break;

                    case 9:
                        str2 = "devedeset";
                        break;
                }
            }
            else
            {
                switch (num2)
                {
                    case 10:
                        str2 = "deset";
                        break;

                    case 11:
                        str2 = "jedanaest";
                        break;

                    case 12:
                        str2 = "dvanaest";
                        break;

                    case 13:
                        str2 = "trinaest";
                        break;

                    case 14:
                        str2 = "četrnaest";
                        break;

                    case 15:
                        str2 = "petnaest";
                        break;

                    case 0x10:
                        str2 = "šesnaest";
                        break;

                    case 0x11:
                        str2 = "sedamnaest";
                        break;

                    case 0x12:
                        str2 = "osamnaest";
                        break;

                    case 0x13:
                        str2 = "devetnaest";
                        break;
                }
                num = 7;
                goto Label_034D;
            }
            switch (((int) (TriBroja % 10L)))
            {
                case 0:
                    str3 = "";
                    break;

                case 1:
                    switch (PiSiTri)
                    {
                        case 0:
                        case 1:
                        case 3:
                        case 4:
                        case 5:
                        case 20:
                            str3 = "jedna";
                            break;

                        case 2:
                            str3 = "jedan";
                            break;
                    }
                    break;

                case 2:
                    switch (PiSiTri)
                    {
                        case 0:
                        case 1:
                        case 3:
                        case 20:
                            str3 = "dvije";
                            break;

                        case 2:
                        case 4:
                            str3 = "dva";
                            break;
                    }
                    break;

                case 3:
                    str3 = "tri";
                    break;

                case 4:
                    str3 = "četiri";
                    break;

                case 5:
                    str3 = "pet";
                    break;

                case 6:
                    str3 = "šest";
                    break;

                case 7:
                    str3 = "sedam";
                    break;

                case 8:
                    str3 = "osam";
                    break;

                case 9:
                    str3 = "devet";
                    break;
            }
        Label_034D:
            if (num3 == 30)
            {
                num = 1;
            }
            switch (PiSiTri)
            {
                case 0:
                    switch (num)
                    {
                        case 0:
                            str4 = " kuna";
                            break;

                        case 1:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 0x10:
                        case 0x11:
                        case 0x12:
                        case 0x13:
                            str4 = " kuna";
                            break;

                        case 2:
                        case 3:
                        case 4:
                            str4 = " kune";
                            break;
                    }
                    break;

                case 1:
                case 3:
                case 5:
                    switch (num)
                    {
                        case 1:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 0x10:
                        case 0x11:
                        case 0x12:
                        case 0x13:
                            str4 = "tisuća";
                            break;

                        case 2:
                        case 3:
                        case 4:
                            str4 = "tisuće";
                            break;
                    }
                    break;

                case 2:
                    switch (num)
                    {
                        case 1:
                            str4 = "milijun";
                            break;

                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 0x10:
                        case 0x11:
                        case 0x12:
                        case 0x13:
                            str4 = "milijuna";
                            break;
                    }
                    break;

                case 4:
                    switch (num)
                    {
                        case 1:
                            str4 = "milijarda";
                            break;

                        case 2:
                        case 3:
                        case 4:
                            str4 = "milijarde";
                            break;

                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 0x10:
                        case 0x11:
                        case 0x12:
                        case 0x13:
                            str4 = "milijardi";
                            break;
                    }
                    break;

                case 20:
                    switch (num)
                    {
                        case 0:
                        case 1:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 0x10:
                        case 0x11:
                        case 0x12:
                        case 0x13:
                            str4 = " lipa";
                            break;

                        case 2:
                        case 3:
                        case 4:
                            str4 = " lipe";
                            break;
                    }
                    break;
            }
            if (str != "")
            {
                string str6 = str.Substring(0, 1);
                str = str.Remove(0, 1);
                str = str6.ToLower() + str;
            }
            return (str + str2 + str3 + str4);
        }

        public static decimal IzracunajCijenuUF(decimal neto, decimal? pdv, decimal? popustStopa, decimal? popustIznos) 
        {
            //ukolilko pdv nije null izracunaj i pribroji ga
            neto = (pdv == null ? neto : (neto + neto * (decimal)pdv / 100));
            if (popustStopa != null)
            {
                neto = neto - (neto * (decimal)popustStopa / 100);
            }
            else if (popustIznos != null)
            {
                neto = neto - (decimal)popustIznos;
            }
            return neto;
        }
    }
}

