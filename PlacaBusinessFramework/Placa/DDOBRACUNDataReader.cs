namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class DDOBRACUNDataReader : IDisposable
    {
        private ReadWriteCommand cmDDOBRACUNSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DDOBRACUNSelect5;
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
                    if (!this.m_Closed && (this.DDOBRACUNSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.DDOBRACUNSelect5.Close();
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
            this.cmDDOBRACUNSelect5 = this.connDefault.GetCommand("SELECT TM1.[DDOBRACUNIDOBRACUN], TM1.[DDOPISOBRACUN], TM1.[DDDATUMOBRACUNA], TM1.[DDZAKLJUCAN], TM1.[DDRSM] FROM [DDOBRACUN] TM1 WITH (NOLOCK) ORDER BY TM1.[DDOBRACUNIDOBRACUN] ", false);
            this.DDOBRACUNSelect5 = this.cmDDOBRACUNSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DDOBRACUNSelect5;
        }

        public IDataReader OpenByDDOBRACUNIDOBRACUN(string dDOBRACUNIDOBRACUN)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDOBRACUNSelect5 = this.connDefault.GetCommand("SELECT TM1.[DDOBRACUNIDOBRACUN], TM1.[DDOPISOBRACUN], TM1.[DDDATUMOBRACUNA], TM1.[DDZAKLJUCAN], TM1.[DDRSM] FROM [DDOBRACUN] TM1 WITH (NOLOCK) WHERE TM1.[DDOBRACUNIDOBRACUN] = @DDOBRACUNIDOBRACUN ORDER BY TM1.[DDOBRACUNIDOBRACUN] ", false);
            if (this.cmDDOBRACUNSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDOBRACUNSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDOBRACUNIDOBRACUN", DbType.String, 11));
            }
            this.cmDDOBRACUNSelect5.SetParameter(0, dDOBRACUNIDOBRACUN);
            this.DDOBRACUNSelect5 = this.cmDDOBRACUNSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DDOBRACUNSelect5;
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

