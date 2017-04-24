namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class RAD1GELEMENTIDataReader : IDisposable
    {
        private ReadWriteCommand cmRAD1GELEMENTISelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader RAD1GELEMENTISelect5;

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
                    if (!this.m_Closed && (this.RAD1GELEMENTISelect5 != null))
                    {
                        this.m_Closed = true;
                        this.RAD1GELEMENTISelect5.Close();
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
            this.cmRAD1GELEMENTISelect5 = this.connDefault.GetCommand("SELECT TM1.[RAD1GELEMENTIID], TM1.[RAD1GELEMENTINAZIV] FROM [RAD1GELEMENTI] TM1 WITH (NOLOCK) ORDER BY TM1.[RAD1GELEMENTIID] ", false);
            this.RAD1GELEMENTISelect5 = this.cmRAD1GELEMENTISelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1GELEMENTISelect5;
        }

        public IDataReader OpenByRAD1GELEMENTIID(int rAD1GELEMENTIID)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1GELEMENTISelect5 = this.connDefault.GetCommand("SELECT TM1.[RAD1GELEMENTIID], TM1.[RAD1GELEMENTINAZIV] FROM [RAD1GELEMENTI] TM1 WITH (NOLOCK) WHERE TM1.[RAD1GELEMENTIID] = @RAD1GELEMENTIID ORDER BY TM1.[RAD1GELEMENTIID] ", false);
            if (this.cmRAD1GELEMENTISelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1GELEMENTISelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
            }
            this.cmRAD1GELEMENTISelect5.SetParameter(0, rAD1GELEMENTIID);
            this.RAD1GELEMENTISelect5 = this.cmRAD1GELEMENTISelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1GELEMENTISelect5;
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

