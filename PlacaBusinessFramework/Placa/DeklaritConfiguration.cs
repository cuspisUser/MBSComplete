namespace Placa
{
    using Deklarit.Configuration;
    using Deklarit.Data;
    using System;
    using System.Data;

    public class DeklaritConfiguration : IDeklaritConfiguration
    {
        private Deklarit.Configuration.IConfigurationProvider m_ConfigurationProvider = new DefaultConfigurationProvider();

        public IDbConnection GetConnection()
        {
            IDbmsHandler handler = new SqlServer2005Handler();
            return handler.NewConnection(this.ConnectionString, "System.Data.SqlClient");
        }

        public Deklarit.Configuration.IConfigurationProvider ConfigurationProvider
        {
            get
            {
                return this.m_ConfigurationProvider;
            }
            set
            {
                this.m_ConfigurationProvider = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return this.m_ConfigurationProvider.ConnectionString;
            }
        }

        public Deklarit.Configuration.DatabaseEngineType DatabaseEngineType
        {
            get
            {
                return Deklarit.Configuration.DatabaseEngineType.SqlServer;
            }
        }

        Deklarit.Configuration.IConfigurationProvider Deklarit.Configuration.IDeklaritConfiguration.ConfigurationProvider
        {
            get
            {
                return this.m_ConfigurationProvider;
            }
            set
            {
                this.m_ConfigurationProvider = value;
            }
        }

        string Deklarit.Configuration.IDeklaritConfiguration.ConnectionString
        {
            get
            {
                return this.m_ConfigurationProvider.ConnectionString;
            }
        }

        Deklarit.Configuration.DatabaseEngineType Deklarit.Configuration.IDeklaritConfiguration.DatabaseEngineType
        {
            get
            {
                return Deklarit.Configuration.DatabaseEngineType.SqlServer;
            }
        }
    }
}

