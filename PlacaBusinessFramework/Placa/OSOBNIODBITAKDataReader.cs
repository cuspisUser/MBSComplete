namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class OSOBNIODBITAKDataReader : IDisposable
    {
        private ReadWriteCommand cmOSOBNIODBITAKSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader OSOBNIODBITAKSelect5;

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
                    if (!this.m_Closed && (this.OSOBNIODBITAKSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.OSOBNIODBITAKSelect5.Close();
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
            this.cmOSOBNIODBITAKSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDOSOBNIODBITAK], TM1.[NAZIVOSOBNIODBITAK], TM1.[FAKTOROSOBNOGODBITKA] FROM [OSOBNIODBITAK] TM1 WITH (NOLOCK) ORDER BY TM1.[IDOSOBNIODBITAK] ", false);
            this.OSOBNIODBITAKSelect5 = this.cmOSOBNIODBITAKSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OSOBNIODBITAKSelect5;
        }

        public IDataReader OpenByIDOSOBNIODBITAK(int iDOSOBNIODBITAK)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSOBNIODBITAKSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDOSOBNIODBITAK], TM1.[NAZIVOSOBNIODBITAK], TM1.[FAKTOROSOBNOGODBITKA] FROM [OSOBNIODBITAK] TM1 WITH (NOLOCK) WHERE TM1.[IDOSOBNIODBITAK] = @IDOSOBNIODBITAK ORDER BY TM1.[IDOSOBNIODBITAK] ", false);
            if (this.cmOSOBNIODBITAKSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSOBNIODBITAKSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSOBNIODBITAK", DbType.Int32));
            }
            this.cmOSOBNIODBITAKSelect5.SetParameter(0, iDOSOBNIODBITAK);
            this.OSOBNIODBITAKSelect5 = this.cmOSOBNIODBITAKSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OSOBNIODBITAKSelect5;
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

