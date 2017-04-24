namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class RAD1GELEMENTIVEZADataReader : IDisposable
    {
        private ReadWriteCommand cmRAD1GELEMENTIVEZADelete2;
        private ReadWriteCommand cmRAD1GELEMENTIVEZADelete3;
        private ReadWriteCommand cmRAD1GELEMENTIVEZASelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader RAD1GELEMENTIVEZASelect7;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByIDELEMENT(int iDELEMENT)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1GELEMENTIVEZADelete3 = this.connDefault.GetCommand("DELETE FROM [RAD1GELEMENTIVEZA]  WHERE [IDELEMENT] = @IDELEMENT", false);
            if (this.cmRAD1GELEMENTIVEZADelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1GELEMENTIVEZADelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmRAD1GELEMENTIVEZADelete3.SetParameter(0, iDELEMENT);
            return this.cmRAD1GELEMENTIVEZADelete3.ExecuteStmt();
        }

        public int DeleteByRAD1GELEMENTIID(int rAD1GELEMENTIID)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1GELEMENTIVEZADelete2 = this.connDefault.GetCommand("DELETE FROM [RAD1GELEMENTIVEZA]  WHERE [RAD1GELEMENTIID] = @RAD1GELEMENTIID", false);
            if (this.cmRAD1GELEMENTIVEZADelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1GELEMENTIVEZADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
            }
            this.cmRAD1GELEMENTIVEZADelete2.SetParameter(0, rAD1GELEMENTIID);
            return this.cmRAD1GELEMENTIVEZADelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.RAD1GELEMENTIVEZASelect7 != null))
                    {
                        this.m_Closed = true;
                        this.RAD1GELEMENTIVEZASelect7.Close();
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
            this.cmRAD1GELEMENTIVEZASelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK) ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] ", false);
            this.RAD1GELEMENTIVEZASelect7 = this.cmRAD1GELEMENTIVEZASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1GELEMENTIVEZASelect7;
        }

        public IDataReader OpenByIDELEMENT(int iDELEMENT)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1GELEMENTIVEZASelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK) WHERE TM1.[IDELEMENT] = @IDELEMENT ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] ", false);
            if (this.cmRAD1GELEMENTIVEZASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1GELEMENTIVEZASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmRAD1GELEMENTIVEZASelect7.SetParameter(0, iDELEMENT);
            this.RAD1GELEMENTIVEZASelect7 = this.cmRAD1GELEMENTIVEZASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1GELEMENTIVEZASelect7;
        }

        public IDataReader OpenByRAD1GELEMENTIID(int rAD1GELEMENTIID)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1GELEMENTIVEZASelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK) WHERE TM1.[RAD1GELEMENTIID] = @RAD1GELEMENTIID ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] ", false);
            if (this.cmRAD1GELEMENTIVEZASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1GELEMENTIVEZASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
            }
            this.cmRAD1GELEMENTIVEZASelect7.SetParameter(0, rAD1GELEMENTIID);
            this.RAD1GELEMENTIVEZASelect7 = this.cmRAD1GELEMENTIVEZASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1GELEMENTIVEZASelect7;
        }

        public IDataReader OpenByRAD1GELEMENTIIDIDELEMENT(int rAD1GELEMENTIID, int iDELEMENT)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1GELEMENTIVEZASelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] FROM [RAD1GELEMENTIVEZA] TM1 WITH (NOLOCK) WHERE TM1.[RAD1GELEMENTIID] = @RAD1GELEMENTIID and TM1.[IDELEMENT] = @IDELEMENT ORDER BY TM1.[RAD1GELEMENTIID], TM1.[IDELEMENT] ", false);
            if (this.cmRAD1GELEMENTIVEZASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1GELEMENTIVEZASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1GELEMENTIID", DbType.Int32));
                this.cmRAD1GELEMENTIVEZASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmRAD1GELEMENTIVEZASelect7.SetParameter(0, rAD1GELEMENTIID);
            this.cmRAD1GELEMENTIVEZASelect7.SetParameter(1, iDELEMENT);
            this.RAD1GELEMENTIVEZASelect7 = this.cmRAD1GELEMENTIVEZASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1GELEMENTIVEZASelect7;
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

