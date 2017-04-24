namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class RAD1MELEMENTIVEZADataReader : IDisposable
    {
        private ReadWriteCommand cmRAD1MELEMENTIVEZADelete2;
        private ReadWriteCommand cmRAD1MELEMENTIVEZADelete3;
        private ReadWriteCommand cmRAD1MELEMENTIVEZASelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader RAD1MELEMENTIVEZASelect7;

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
            this.cmRAD1MELEMENTIVEZADelete3 = this.connDefault.GetCommand("DELETE FROM [RAD1MELEMENTIVEZA]  WHERE [IDELEMENT] = @IDELEMENT", false);
            if (this.cmRAD1MELEMENTIVEZADelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1MELEMENTIVEZADelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmRAD1MELEMENTIVEZADelete3.SetParameter(0, iDELEMENT);
            return this.cmRAD1MELEMENTIVEZADelete3.ExecuteStmt();
        }

        public int DeleteByRAD1ELEMENTIID(int rAD1ELEMENTIID)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1MELEMENTIVEZADelete2 = this.connDefault.GetCommand("DELETE FROM [RAD1MELEMENTIVEZA]  WHERE [RAD1ELEMENTIID] = @RAD1ELEMENTIID", false);
            if (this.cmRAD1MELEMENTIVEZADelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1MELEMENTIVEZADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
            }
            this.cmRAD1MELEMENTIVEZADelete2.SetParameter(0, rAD1ELEMENTIID);
            return this.cmRAD1MELEMENTIVEZADelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.RAD1MELEMENTIVEZASelect7 != null))
                    {
                        this.m_Closed = true;
                        this.RAD1MELEMENTIVEZASelect7.Close();
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
            this.cmRAD1MELEMENTIVEZASelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK) ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] ", false);
            this.RAD1MELEMENTIVEZASelect7 = this.cmRAD1MELEMENTIVEZASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1MELEMENTIVEZASelect7;
        }

        public IDataReader OpenByIDELEMENT(int iDELEMENT)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1MELEMENTIVEZASelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK) WHERE TM1.[IDELEMENT] = @IDELEMENT ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] ", false);
            if (this.cmRAD1MELEMENTIVEZASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1MELEMENTIVEZASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmRAD1MELEMENTIVEZASelect7.SetParameter(0, iDELEMENT);
            this.RAD1MELEMENTIVEZASelect7 = this.cmRAD1MELEMENTIVEZASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1MELEMENTIVEZASelect7;
        }

        public IDataReader OpenByRAD1ELEMENTIID(int rAD1ELEMENTIID)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1MELEMENTIVEZASelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK) WHERE TM1.[RAD1ELEMENTIID] = @RAD1ELEMENTIID ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] ", false);
            if (this.cmRAD1MELEMENTIVEZASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1MELEMENTIVEZASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
            }
            this.cmRAD1MELEMENTIVEZASelect7.SetParameter(0, rAD1ELEMENTIID);
            this.RAD1MELEMENTIVEZASelect7 = this.cmRAD1MELEMENTIVEZASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1MELEMENTIVEZASelect7;
        }

        public IDataReader OpenByRAD1ELEMENTIIDIDELEMENT(int rAD1ELEMENTIID, int iDELEMENT)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1MELEMENTIVEZASelect7 = this.connDefault.GetCommand("SELECT TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] FROM [RAD1MELEMENTIVEZA] TM1 WITH (NOLOCK) WHERE TM1.[RAD1ELEMENTIID] = @RAD1ELEMENTIID and TM1.[IDELEMENT] = @IDELEMENT ORDER BY TM1.[RAD1ELEMENTIID], TM1.[IDELEMENT] ", false);
            if (this.cmRAD1MELEMENTIVEZASelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1MELEMENTIVEZASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1ELEMENTIID", DbType.Int32));
                this.cmRAD1MELEMENTIVEZASelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmRAD1MELEMENTIVEZASelect7.SetParameter(0, rAD1ELEMENTIID);
            this.cmRAD1MELEMENTIVEZASelect7.SetParameter(1, iDELEMENT);
            this.RAD1MELEMENTIVEZASelect7 = this.cmRAD1MELEMENTIVEZASelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.RAD1MELEMENTIVEZASelect7;
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

