namespace DDModule.My
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, EditorBrowsable(EditorBrowsableState.Advanced), GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed class MySettings : ApplicationSettingsBase
    {
        private static MySettings defaultInstance = ((MySettings) SettingsBase.Synchronized(new MySettings()));

        public static MySettings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [DebuggerNonUserCode, ApplicationScopedSetting, DefaultSettingValue("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"C:\\Documents and Settings\\All Users\\Application Data\\VugerGRAD\\OH.MDB\""), SpecialSetting(SpecialSetting.ConnectionString)]
        public string OHConnectionString
        {
            get
            {
                return Conversions.ToString(this["OHConnectionString"]);
            }
        }
    }
}

