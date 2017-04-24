namespace My
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

        [SpecialSetting(SpecialSetting.ConnectionString), ApplicationScopedSetting, DebuggerNonUserCode, DefaultSettingValue(@"Data Source=BOJAN\SQLEXPRESS;Initial Catalog=NovaPlaca;Integrated Security=True")]
        public string NovaPlacaConnectionString
        {
            get
            {
                return Conversions.ToString(this["NovaPlacaConnectionString"]);
            }
        }
    }
}

