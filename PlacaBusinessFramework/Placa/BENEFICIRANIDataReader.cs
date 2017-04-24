namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class BENEFICIRANIDataReader : IDisposable
    {
        private IDataReader BENEFICIRANISelect5;
        private ReadWriteCommand cmBENEFICIRANISelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.BENEFICIRANISelect5 != null))
                    {
                        this.m_Closed = true;
                        this.BENEFICIRANISelect5.Close();
                    }
                }
                finally
                {
                    try
                    {
                        this.connDefault.Close();
                    }
                    finally
                    {
                        this.Cleanup();
                    }
                }
            }
        }

        private void init_reader()
        {
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
            this.m_Disposed = false;
            this.m_Closed = true;
        }

        private void Initialize()
        {
            this.m_Disposed = false;
            this.m_Closed = false;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        public IDataReader Open()
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmBENEFICIRANISelect5 = this.connDefault.GetCommand("SELECT TM1.[IDBENEFICIRANI], TM1.[NAZIVBENEFICIRANI], TM1.[BROJPRIZNATIHMJESECI] FROM [BENEFICIRANI] TM1 WITH (NOLOCK) ORDER BY TM1.[IDBENEFICIRANI] ", false);
            this.BENEFICIRANISelect5 = this.cmBENEFICIRANISelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.BENEFICIRANISelect5;
        }

        public IDataReader OpenByIDBENEFICIRANI(string iDBENEFICIRANI)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmBENEFICIRANISelect5 = this.connDefault.GetCommand("SELECT TM1.[IDBENEFICIRANI], TM1.[NAZIVBENEFICIRANI], TM1.[BROJPRIZNATIHMJESECI] FROM [BENEFICIRANI] TM1 WITH (NOLOCK) WHERE TM1.[IDBENEFICIRANI] = @IDBENEFICIRANI ORDER BY TM1.[IDBENEFICIRANI] ", false);
            if (this.cmBENEFICIRANISelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmBENEFICIRANISelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBENEFICIRANI", DbType.String, 1));
            }
            this.cmBENEFICIRANISelect5.SetParameter(0, iDBENEFICIRANI);
            this.BENEFICIRANISelect5 = this.cmBENEFICIRANISelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.BENEFICIRANISelect5;
        }

        public IDbTransaction Transaction
        {
            get
            {
                return this.daCurrentTransaction;
            }
            set
            {
                this.daCurrentTransaction = value;
            }
        }
    }
}

