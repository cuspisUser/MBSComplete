namespace Placa
{
    using System;
    using System.Configuration;

    public class DefaultConfigurationProvider : IConfigurationProvider
    {
        private string m_ConnectionString;

        public void SetConnectionString(string sConnStr)
        {
            this.m_ConnectionString = sConnStr;
        }

        public string ConnectionString
        {
            get
            {
                string connectionString = null;
                if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null)
                {
                    connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                }
                else if (ConfigurationManager.AppSettings["ConnectionString"] != null)
                {
                    connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                }
                if (connectionString != null)
                {
                    return connectionString;
                }
                if ((this.m_ConnectionString == null) || (this.m_ConnectionString.Length == 0))
                {
                    return @"Data Source=.\SQLEXPRESS;Initial Catalog=NOVAPLACA;Integrated Security=True";
                }
                return this.m_ConnectionString;
            }
        }

        string Deklarit.Configuration.IConfigurationProvider.ConnectionString
        {
            get
            {
                string connectionString = null;
                if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null)
                {
                    connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                }
                else if (ConfigurationManager.AppSettings["ConnectionString"] != null)
                {
                    connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                }
                if (connectionString != null)
                {
                    return connectionString;
                }
                if ((this.m_ConnectionString == null) || (this.m_ConnectionString.Length == 0))
                {
                    return @"Data Source=.\SQLEXPRESS;Initial Catalog=NOVAPLACA;Integrated Security=True";
                }
                return this.m_ConnectionString;
            }
        }
    }
}

