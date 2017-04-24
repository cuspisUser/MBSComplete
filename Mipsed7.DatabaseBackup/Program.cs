using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Diagnostics;

namespace Mipsed7.DatabaseBackup
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AllowOnlyOneInstance();

            // Aplikacija je windowless, pa iz Run()-a mičemo instanciranje forme.
            Application.Run(new Shell());
        }

        /// <summary>
        /// Funkcija koja provjerava da li su možda pokrenute "stare" instance ove aplikacije.
        /// Ako su pokrenute ugasi ih.
        /// </summary>
        private static void AllowOnlyOneInstance()
        {
            string moduleName, processName;

            Process currentProcess = Process.GetCurrentProcess();

            moduleName = currentProcess.MainModule.ModuleName.ToString();
            processName = System.IO.Path.GetFileNameWithoutExtension(moduleName);

            // uzimamo procese sa istim imenom
            Process[] processList = Process.GetProcessesByName(processName);

            // ako postoje više od jednog procesa sa tim imenom (current + others)
            if (processList.Length > 1)
            {
                // svaki od procesa koji ima isto ime, KILL-amo
                foreach (Process process in processList)
                {
                    // napravi Kill procesa ukoliko se ne radi o trenutnome
                    if (process.Id != currentProcess.Id)
                        process.Kill();
                }
            }
        }
    }
}
