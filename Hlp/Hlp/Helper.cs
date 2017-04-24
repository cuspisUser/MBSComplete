namespace Hlp
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.IO;
    using System.Reflection;

    public class Helper
    {
        public static string GetModulePath(string assemblyFile)
        {
            if (!Path.IsPathRooted(assemblyFile))
            {
                assemblyFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyFile);
            }
            return assemblyFile;
        }

        public static decimal KuhinjaMargine_LEFT()
        {
            System.Configuration.Configuration configuration;
            string str = "kuhinja.exe.config";
            string str2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\mipsed7", str);
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap {
                ExeConfigFilename = str2
            };
            try
            {
                configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                //decimal zero = decimal.Zero;
                
                //return zero;
            }
            ConfigurationSectionCollection sections = configuration.Sections;
            AppSettingsSection section = (AppSettingsSection) configuration.GetSection("appSettings");
            return new decimal(Convert.ToDouble(Conversions.ToDecimal(section.Settings["LEFT"].Value.ToString().Replace(".", ","))) * 566.92913385826773);
        }

        public static decimal KuhinjaMargine_top()
        {
            System.Configuration.Configuration configuration;
            string str = "kuhinja.exe.config";
            string str2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\mipsed7", str);
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap {
                ExeConfigFilename = str2
            };
            try
            {
                configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            ConfigurationSectionCollection sections = configuration.Sections;
            AppSettingsSection section = (AppSettingsSection) configuration.GetSection("appSettings");
            return new decimal(Convert.ToDouble(Conversions.ToDecimal(section.Settings["TOP"].Value.ToString().Replace(".", ","))) * 566.92913385826773);
        }

        public static Assembly LoadAssembly(string assemblyFile)
        {
            assemblyFile = GetModulePath(assemblyFile);
            FileInfo info = new FileInfo(assemblyFile);
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFrom(info.FullName);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            return assembly;
        }

        public static decimal placamargine_LEFT()
        {
            System.Configuration.Configuration configuration = null;
            string str = "placa.exe.config";
            string str2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\mipsed7", str);
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap {
                ExeConfigFilename = str2
            };
            try
            {
                configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            ConfigurationSectionCollection sections = configuration.Sections;
            AppSettingsSection section = (AppSettingsSection) configuration.GetSection("appSettings");
            return new decimal((int) Math.Round((double) (Convert.ToDouble(Conversions.ToDecimal(section.Settings["LEFT"].Value.ToString().Replace(".", ","))) * 566.92913385826773)));
        }

        public static decimal placamargine_top()
        {
            System.Configuration.Configuration configuration = null;
            string str = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\mipsed7", "placa.exe.config");
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap {
                ExeConfigFilename = str
            };
            try
            {
                configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            ConfigurationSectionCollection sections = configuration.Sections;
            AppSettingsSection section = (AppSettingsSection) configuration.GetSection("appSettings");
            return new decimal((int) Math.Round((double) (Convert.ToDouble(Conversions.ToDecimal(section.Settings["TOP"].Value.ToString().Replace(".", ","))) * 566.92913385826773)));
        }

        public static string UsingOpenExeConfigurationKuhinja()
        {
            System.Configuration.Configuration configuration = null;
            string str = "kuhinja.exe.config";
            string str2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\mipsed7", str);
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap {
                ExeConfigFilename = str2
            };
            try
            {
                configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            }
            catch (System.Exception exception1)
            {
                throw exception1;
            }
            ConfigurationSectionCollection sections = configuration.Sections;
            AppSettingsSection section = (AppSettingsSection) configuration.GetSection("appSettings");
            return section.Settings["ConnectionString"].Value.ToString();
        }
    }
}

