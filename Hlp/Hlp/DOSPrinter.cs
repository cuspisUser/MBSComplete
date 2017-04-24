namespace Hlp
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public class DOSPrinter
    {
        [DllImport("winspool.Drv", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern bool ClosePrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);
        [DllImport("kernel32.dll", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern int GetLastError();
        [DllImport("winspool.Drv", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern bool OpenPrinter(string src, ref IntPtr hPrinter, int pd);
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, int dwCount)
        {
            DOCINFOW docinfow = new DOCINFOW();
            IntPtr ptr = new IntPtr();
            docinfow.pDocName = "My Visual Basic .NET RAW Document";
            docinfow.pDataType = "RAW";
            bool flag = false;
            if (OpenPrinter(szPrinterName, ref ptr, 0))
            {
                if (StartDocPrinter(ptr, 1, ref docinfow))
                {
                    if (StartPagePrinter(ptr))
                    {
                        int num2 = 0;
                        flag = WritePrinter(ptr, pBytes, dwCount, ref num2);
                        EndPagePrinter(ptr);
                    }
                    EndDocPrinter(ptr);
                }
                ClosePrinter(ptr);
            }
            if (!flag)
            {
                int lastError = GetLastError();
            }
            return flag;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            FileStream input = new FileStream(szFileName, FileMode.Open);
            BinaryReader reader = new BinaryReader(input);
            byte[] source = new byte[((int) input.Length) + 1];
            source = reader.ReadBytes((int) input.Length);
            IntPtr destination = Marshal.AllocCoTaskMem((int) input.Length);
            Marshal.Copy(source, 0, destination, (int) input.Length);
            bool flag = SendBytesToPrinter(szPrinterName, destination, (int) input.Length);
            Marshal.FreeCoTaskMem(destination);
            input.Close();
            return flag;
        }

        public static object SendStringToPrinter(string szPrinterName, string szString)
        {
            object obj2 = new object();
            int length = szString.Length;
            IntPtr pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            SendBytesToPrinter(szPrinterName, pBytes, length);
            Marshal.FreeCoTaskMem(pBytes);
            return obj2;
        }

        [DllImport("winspool.Drv", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, ref DOCINFOW pDI);
        [DllImport("winspool.Drv", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Auto, SetLastError=true)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, ref int dwWritten);

        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        public struct DOCINFOW
        {
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pDataType;
        }
    }
}

