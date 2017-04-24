namespace Hlp
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class DB
    {
        public static string BrojDodajPraznine(object vbroj)
        {
            decimal num = 0;
            if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(vbroj)))
            {
                num = decimal.Parse(Conversions.ToString(vbroj));
            }
            else
            {
                num = new decimal();
            }
            string expression = "";
            expression = Conversions.ToString(num);
            return (expression + Strings.Space(8 - Strings.Len(expression)) + "-");
        }

        public static string BrojVodeceNule(object vBroj, int nBrojCijelihMjesta, int nBrojDecimalnihMjesta, bool bDecimalniZnak = true, string sDecimalniZnak = "")
        {
            decimal number = Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(vBroj)) ? decimal.Parse(Conversions.ToString(vBroj)) : decimal.Zero;
            string str2 = "";
            str2 = (nBrojCijelihMjesta > 0) ? Conversion.Fix(number).ToString(new string('0', nBrojCijelihMjesta)).Substring(0, nBrojCijelihMjesta) : Conversion.Fix(number).ToString("0");
            if (bDecimalniZnak)
            {
                if (sDecimalniZnak == "")
                {
                    int num4 = 0;
                    sDecimalniZnak = num4.ToString("0.0").Substring(1, 1);
                }
                str2 = str2 + sDecimalniZnak;
            }
            if (nBrojDecimalnihMjesta > 0)
            {
                string str3 = number.ToString("0." + new string('0', nBrojDecimalnihMjesta));
                str3 = str3.Substring(str3.Length - 2, 2);
                str2 = str2 + str3;
            }
            return str2;
        }

        public static string BrojVodecePraznine(object vBroj, int nBrojCijelihMjesta, int nBrojDecimalnihMjesta, bool bDecimalniZnak = true, string sDecimalniZnak = "")
        {
            decimal num = 0;
            if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(vBroj)))
            {
                num = decimal.Parse(Conversions.ToString(vBroj));
            }
            else
            {
                num = new decimal();
            }
            string str2 = "";
            if (nBrojCijelihMjesta > 0)
            {
                str2 = Conversion.Fix(num).ToString("0").PadLeft(nBrojCijelihMjesta).Substring(0, nBrojCijelihMjesta);
            }
            else
            {
                str2 = Conversion.Fix(num).ToString("0");
            }
            if (bDecimalniZnak)
            {
                if (sDecimalniZnak == "")
                {
                    int num3 = 0;
                    sDecimalniZnak = num3.ToString("0.0").Substring(1, 1);
                }
                str2 = str2 + sDecimalniZnak;
            }
            if (nBrojDecimalnihMjesta > 0)
            {
                string str3 = num.ToString("0." + new string('0', nBrojDecimalnihMjesta));
                str3 = str3.Substring(str3.Length - 2, 2);
                str2 = str2 + str3;
            }
            return str2;
        }

        public static string DoubleToString(decimal dec)
        {
            string str2 = Conversions.ToString(dec);
            return Strings.Replace(dec.ToString("0000000000000.00;0000000000000.00;0000000000000.00"), ",", "", 1, -1, CompareMethod.Binary);
        }

        public static string DoubleToStringKRACI(decimal d)
        {
            string str2 = Conversions.ToString(d);
            return Strings.Replace(d.ToString("00000000000.00;00000000000.00;00000000000.00"), ",", "", 1, -1, CompareMethod.Binary);
        }

        public static string FixNull(object dbvalue)
        {
            if (dbvalue != DBNull.Value)
            {
                return dbvalue.ToString();
            }
            return "";
        }

        public static bool IsDBNull(object dbvalue)
        {
            return (dbvalue == DBNull.Value);
        }

        public static bool IsInteger(string sNumber)
        {
            bool flag = false;
            try
            {
                int.Parse(sNumber);
                flag = true;
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            return flag;
        }

        public static string IzvuciSamoBrojke(string sText, bool bNulaZaPrazno = true)
        {
            string str4 = sText;
            string str3 = "";
            int num2 = str4.Length - 1;
            for (int i = 0; i <= num2; i++)
            {
                string str2 = str4.Substring(i, 1);
                if ((Strings.Asc(str2) >= 0x30) & (Strings.Asc(str2) <= 0x39))
                {
                    str3 = str3 + str2;
                }
            }
            if (bNulaZaPrazno & (str3 == ""))
            {
                str3 = "0";
            }
            return str3;
        }

        public static string Ko437to852(string kojistring)
        {
            kojistring = Strings.Replace(kojistring, "{", Conversions.ToString(Strings.Chr(0x9a)), 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, "[", Conversions.ToString(Strings.Chr(0x8a)), 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, "|", Conversions.ToString(Strings.Chr(240)), 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, @"\", Conversions.ToString(Strings.Chr(0xd0)), 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, "~", Conversions.ToString(Strings.Chr(0xe8)), 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, "^", Conversions.ToString(Strings.Chr(200)), 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, "}", Conversions.ToString(Strings.Chr(230)), 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, "]", Conversions.ToString(Strings.Chr(0xc6)), 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, "`", Conversions.ToString(Strings.Chr(0x9e)), 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, "@", Conversions.ToString(Strings.Chr(0x8e)), 1, -1, CompareMethod.Binary);
            return kojistring.ToUpper();
        }

        public static string Ko852to437(string kojistring)
        {
            string str2 = kojistring;
            kojistring = Strings.Replace(kojistring, Conversions.ToString(Strings.Chr(0x9a)), "{", 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, Conversions.ToString(Strings.Chr(0x8a)), "[", 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, Conversions.ToString(Strings.Chr(240)), "|", 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, Conversions.ToString(Strings.Chr(0xd0)), @"\", 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, Conversions.ToString(Strings.Chr(0xe8)), "~", 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, Conversions.ToString(Strings.Chr(200)), "^", 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, Conversions.ToString(Strings.Chr(230)), "}", 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, Conversions.ToString(Strings.Chr(0xc6)), "]", 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, Conversions.ToString(Strings.Chr(0x9e)), "`", 1, -1, CompareMethod.Binary);
            kojistring = Strings.Replace(kojistring, Conversions.ToString(Strings.Chr(0x8e)), "@", 1, -1, CompareMethod.Binary);
            return str2.ToUpper();
        }

        public static string MjesecNazivDativ(int nMjesec)
        {
            switch (nMjesec)
            {
                case 1:
                    return "siječnju";

                case 2:
                    return "veljači";

                case 3:
                    return "ožujku";

                case 4:
                    return "travnju";

                case 5:
                    return "svibnju";

                case 6:
                    return "lipnju";

                case 7:
                    return "srpnju";

                case 8:
                    return "kolovozu";

                case 9:
                    return "rujnu";

                case 10:
                    return "listopadu";

                case 11:
                    return "studenom";

                case 12:
                    return "prosincu";
            }
            return "(nepoznatom)";
        }

        public static string MjesecNazivPlatna(int nMjesec)
        {
            switch (nMjesec)
            {
                case 1:
                    return "siječanj";

                case 2:
                    return "veljaču";

                case 3:
                    return "ožujak";

                case 4:
                    return "travanj";

                case 5:
                    return "svibanj";

                case 6:
                    return "lipanj";

                case 7:
                    return "srpanj";

                case 8:
                    return "kolovoz";

                case 9:
                    return "rujan";

                case 10:
                    return "listopad";

                case 11:
                    return "studeni";

                case 12:
                    return "prosinac";
            }
            return "(nepoznatom)";
        }

        public static decimal N20(object vNumber)
        {
            if (!IsDBNull(RuntimeHelpers.GetObjectValue(vNumber)) & (vNumber != null))
            {
                decimal zero;
                if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(vNumber)))
                {
                    return decimal.Zero;
                }
                try
                {
                    zero = decimal.Parse(Conversions.ToString(vNumber));
                }
                catch (System.Exception exception1)
                {
                    throw exception1;
                    
                    //zero = decimal.Zero;
                    
                }
                return zero;
            }
            return decimal.Zero;
        }

        public static bool N2B(object bNumber)
        {
            return (!IsDBNull(RuntimeHelpers.GetObjectValue(bNumber)) && Conversions.ToBoolean(Interaction.IIf(decimal.Compare(Conversions.ToDecimal(bNumber), decimal.Zero) == 0, false, true)));
        }

        public static string N2T(object vText, string sAlterText = "")
        {
            if (!(!IsDBNull(RuntimeHelpers.GetObjectValue(vText)) & (vText != null)))
            {
                return sAlterText;
            }
            try
            {
                if (vText.ToString().Trim() == string.Empty)
                {
                    return sAlterText;
                }
            }
            catch (Exception) { }

            return Conversions.ToString(vText);
        }

        public static double Round(byte BrojDecimala, double Granica, double Broj)
        {
            double num2 = Math.Exp(BrojDecimala * Math.Log(10.0));
            return (Conversion.Int((double) (((Broj * num2) + 1.0) - Granica)) / num2);
        }

        public decimal RoundNear(object varNumber, object varDelta)
        {
            object obj3 = decimal.Divide(Conversions.ToDecimal(varNumber), Conversions.ToDecimal(varDelta));
            int num = Conversions.ToInteger(Conversion.Int(RuntimeHelpers.GetObjectValue(obj3)));
            object obj2 = decimal.Subtract(Conversions.ToDecimal(obj3), new decimal(num));
            if (Convert.ToDouble(Conversions.ToDecimal(obj2)) >= 0.5)
            {
                return decimal.Multiply(Conversions.ToDecimal(varDelta), new decimal(num + 1));
            }
            return decimal.Multiply(Conversions.ToDecimal(varDelta), new decimal(num));
        }

        public static decimal RoundUP(object number)
        {
            decimal d = new decimal(Convert.ToDouble(Conversions.ToDecimal(number)) + 1E-05);
            return decimal.Round(d, 2);
        }

        public static decimal RoundUpDecimale(object number, int decimale)
        {
            return Math.Round(Conversions.ToDecimal(number), decimale, MidpointRounding.AwayFromZero);
        }

        public static decimal RoundUpDown(object varNumber, object varDelta)
        {
            object obj2 = decimal.Divide(Conversions.ToDecimal(varNumber), Conversions.ToDecimal(varDelta));
            if (Conversion.Int(RuntimeHelpers.GetObjectValue(obj2)) == obj2)
            {
                return Conversions.ToDecimal(varNumber);
            }
            return decimal.Multiply(Conversion.Int(decimal.Subtract(decimal.Divide(decimal.Add(Conversions.ToDecimal(varNumber), decimal.Multiply(2M, Conversions.ToDecimal(varDelta))), Conversions.ToDecimal(varDelta)), decimal.One)), Conversions.ToDecimal(varDelta));
        }

        public static string SQLDate(string sText)
        {
            DateTime dateValue = Conversions.ToDate(sText);
            return (Conversions.ToString(DateAndTime.DatePart(DateInterval.Month, dateValue, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) + "/" + Conversions.ToString(DateAndTime.DatePart(DateInterval.Day, dateValue, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) + "/" + Conversions.ToString(DateAndTime.DatePart(DateInterval.Year, dateValue, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)));
        }
    }
}

