namespace mipsed.application.framework
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Management;
    using System.Security.Cryptography;
    using System.Text;

    public class FingerPrint
    {
        private static string fingerPrint = string.Empty;

        private static string baseId()
        {
            return (identifier("Win32_BaseBoard", "Model") + identifier("Win32_BaseBoard", "Manufacturer") + identifier("Win32_BaseBoard", "Name") + identifier("Win32_BaseBoard", "SerialNumber"));
        }

        private static string biosId()
        {
            return (identifier("Win32_BIOS", "Manufacturer") + identifier("Win32_BIOS", "SMBIOSBIOSVersion") + identifier("Win32_BIOS", "IdentificationCode") + identifier("Win32_BIOS", "SerialNumber") + identifier("Win32_BIOS", "ReleaseDate") + identifier("Win32_BIOS", "Version"));
        }

        private static string cpuId()
        {
            string str2 = identifier("Win32_Processor", "UniqueId");
            if (str2 != "")
            {
                return str2;
            }
            str2 = identifier("Win32_Processor", "ProcessorId");
            if (str2 != "")
            {
                return str2;
            }
            str2 = identifier("Win32_Processor", "Name");
            if (str2 == "")
            {
                str2 = identifier("Win32_Processor", "Manufacturer");
            }
            return (str2 + identifier("Win32_Processor", "MaxClockSpeed"));
        }

        private static string diskId()
        {
            return (identifier("Win32_DiskDrive", "Model") + identifier("Win32_DiskDrive", "Manufacturer") + identifier("Win32_DiskDrive", "Signature") + identifier("Win32_DiskDrive", "TotalHeads"));
        }

        private static string GetHash(string s)
        {
            MD5 md = new MD5CryptoServiceProvider();
            byte[] bytes = new ASCIIEncoding().GetBytes(s);
            return GetHexString(md.ComputeHash(bytes));
        }

        private static string GetHexString(byte[] bt)
        {
            string str2 = string.Empty;
            int num6 = bt.Length - 1;
            for (int i = 0; i <= num6; i++)
            {
                byte num = bt[i];
                int num3 = num;
                int num4 = num3 & 15;
                int num5 = (num3 >> 4) & 15;
                if (num5 > 9)
                {
                    str2 = str2 + Strings.ChrW((num5 - 10) + 0x41).ToString();
                }
                else
                {
                    str2 = str2 + num5.ToString();
                }
                if (num4 > 9)
                {
                    str2 = str2 + Strings.ChrW((num4 - 10) + 0x41).ToString();
                }
                else
                {
                    str2 = str2 + num4.ToString();
                }
                if (((i + 1) != bt.Length) && (((i + 1) % 2) == 0))
                {
                    str2 = str2 + "-";
                }
            }
            return str2;
        }

        private static string identifier(string wmiClass, string wmiProperty)
        {
            string str2 = "";
            ManagementObjectCollection instances = new ManagementClass(wmiClass).GetInstances();
            foreach (ManagementObject obj2 in instances)
            {
                if (str2 == "")
                {
                    try
                    {
                        str2 = obj2[wmiProperty].ToString();
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;
                        
                    }
                }
            }
            return str2;
        }

        private static string identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            string str2 = "";
            ManagementObjectCollection instances = new ManagementClass(wmiClass).GetInstances();
            foreach (ManagementObject obj2 in instances)
            {
                if ((obj2[wmiMustBeTrue].ToString() == "True") && (str2 == ""))
                {
                    try
                    {
                        str2 = obj2[wmiProperty].ToString();
                    }
                    catch (System.Exception exception1)
                    {
                        throw exception1;
                        
                    }
                }
            }
            return str2;
        }

        private static string macId()
        {
            return identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
        }

        public static string Value()
        {
            if (string.IsNullOrEmpty(fingerPrint))
            {
                fingerPrint = GetHash("CPU >> " + cpuId() + "\nBIOS >> " + biosId() + "\nBASE >> " + baseId() + videoId() + "\nMAC >> " + macId());
            }
            return fingerPrint;
        }

        private static string videoId()
        {
            return (identifier("Win32_VideoController", "DriverVersion") + identifier("Win32_VideoController", "Name"));
        }
    }
}

