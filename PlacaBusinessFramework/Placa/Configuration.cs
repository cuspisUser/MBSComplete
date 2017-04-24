namespace Placa
{
    using Deklarit.Configuration;
    using System;
    using System.Data;

    public class Configuration
    {
        public static IDeklaritConfiguration Instance = new DeklaritConfiguration();

        public static IDbConnection GetConnection()
        {
            return Instance.GetConnection();
        }

        public static Deklarit.Configuration.IConfigurationProvider ConfigurationProvider
        {
            get
            {
                return Instance.ConfigurationProvider;
            }
            set
            {
                Instance.ConfigurationProvider = value;
            }
        }

        public static string ConnectionString
        {
            get
            {
                return Instance.ConnectionString;
            }
        }

        public static Deklarit.Configuration.DatabaseEngineType DatabaseEngineType
        {
            get
            {
                return Instance.DatabaseEngineType;
            }
        }

        public static CommandBehavior ReaderCommandBehavior
        {
            get
            {
                return CommandBehavior.CloseConnection;
            }
        }
    }
}

