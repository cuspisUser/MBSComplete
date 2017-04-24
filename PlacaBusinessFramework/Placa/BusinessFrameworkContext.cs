namespace Placa
{
    using Deklarit.Configuration;
    using Deklarit.Data;
    using System;
    using System.Data;

    public class BusinessFrameworkContext : BusinessFrameworkContextBase
    {
        public static BusinessFrameworkContext Instance = new BusinessFrameworkContext();

        public override IDeklaritTransaction GetDeklaritTransaction()
        {
            return new DeklaritTransaction();
        }

        public override IDeklaritTransaction GetDeklaritTransaction(IsolationLevel isolationLevel)
        {
            return new DeklaritTransaction(isolationLevel);
        }

        public override object DataAdapterFactory
        {
            get
            {
                return Placa.DataAdapterFactory.Provider;
            }
        }

        public override IDeklaritConfiguration DeklaritConfiguration
        {
            get
            {
                return Configuration.Instance;
            }
        }

        public override object EnterpriseLibraryConfigurationSource
        {
            get
            {
                return EnterpriseLibrary.Instance.ConfigurationContext;
            }
        }
    }
}

