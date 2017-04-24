namespace mipsed.application.framework
{
    using Deklarit.Configuration;
    using System;

    public class MipsedConfigurationProvider : IConfigurationProvider
    {
        public string ConnectionString
        {
            get
            {
                return Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString;
            }
        }

        string Deklarit.Configuration.IConfigurationProvider.ConnectionString
        {
            get
            {
                return Mipsed7.Core.ApplicationDatabaseInformation.ConnectionString;
            }
        }
    }
}

