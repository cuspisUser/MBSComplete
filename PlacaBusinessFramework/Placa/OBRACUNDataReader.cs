namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class OBRACUNDataReader : IDisposable
    {
        private ReadWriteCommand cmOBRACUNSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader OBRACUNSelect5;

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
                    if (!this.m_Closed && (this.OBRACUNSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.OBRACUNSelect5.Close();
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
            this.cmOBRACUNSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDOBRACUN], TM1.[VRSTAOBRACUNA], TM1.[MJESECOBRACUNA], TM1.[GODINAOBRACUNA], TM1.[MJESECISPLATE], TM1.[GODINAISPLATE], TM1.[DATUMISPLATE], TM1.[tjednifondsatiobracun], TM1.[MJESECNIFONDSATIOBRACUN], TM1.[OSNOVNIOO], TM1.[OBRACUNSKAOSNOVICA], TM1.[DATUMOBRACUNASTAZA], TM1.[OBRPOSTOTNIH], TM1.[OBRFIKSNIH], TM1.[OBRKREDITNIH], TM1.[ZAKLJ], TM1.[SVRHAOBRACUNA] FROM [OBRACUN] TM1 WITH (NOLOCK) ORDER BY TM1.[IDOBRACUN] ", false);
            this.OBRACUNSelect5 = this.cmOBRACUNSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OBRACUNSelect5;
        }

        public IDataReader OpenByIDOBRACUN(string iDOBRACUN)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOBRACUNSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDOBRACUN], TM1.[VRSTAOBRACUNA], TM1.[MJESECOBRACUNA], TM1.[GODINAOBRACUNA], TM1.[MJESECISPLATE], TM1.[GODINAISPLATE], TM1.[DATUMISPLATE], TM1.[tjednifondsatiobracun], TM1.[MJESECNIFONDSATIOBRACUN], TM1.[OSNOVNIOO], TM1.[OBRACUNSKAOSNOVICA], TM1.[DATUMOBRACUNASTAZA], TM1.[OBRPOSTOTNIH], TM1.[OBRFIKSNIH], TM1.[OBRKREDITNIH], TM1.[ZAKLJ], TM1.[SVRHAOBRACUNA] FROM [OBRACUN] TM1 WITH (NOLOCK) WHERE TM1.[IDOBRACUN] = @IDOBRACUN ORDER BY TM1.[IDOBRACUN] ", false);
            if (this.cmOBRACUNSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmOBRACUNSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", DbType.String, 11));
            }
            this.cmOBRACUNSelect5.SetParameter(0, iDOBRACUN);
            this.OBRACUNSelect5 = this.cmOBRACUNSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OBRACUNSelect5;
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

