namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class EVIDENCIJADataReader : IDisposable
    {
        private ReadWriteCommand cmEVIDENCIJADelete2;
        private ReadWriteCommand cmEVIDENCIJADelete3;
        private ReadWriteCommand cmEVIDENCIJADelete4;
        private ReadWriteCommand cmEVIDENCIJASelect8;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader EVIDENCIJASelect8;
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

        public int DeleteByIDGODINE(short iDGODINE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmEVIDENCIJADelete4 = this.connDefault.GetCommand("DELETE FROM [EVIDENCIJA]  WHERE [IDGODINE] = @IDGODINE", false);
            if (this.cmEVIDENCIJADelete4.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJADelete4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            this.cmEVIDENCIJADelete4.SetParameter(0, iDGODINE);
            return this.cmEVIDENCIJADelete4.ExecuteStmt();
        }

        public int DeleteByMJESEC(int mJESEC)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmEVIDENCIJADelete3 = this.connDefault.GetCommand("DELETE FROM [EVIDENCIJA]  WHERE [MJESEC] = @MJESEC", false);
            if (this.cmEVIDENCIJADelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJADelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
            }
            this.cmEVIDENCIJADelete3.SetParameter(0, mJESEC);
            return this.cmEVIDENCIJADelete3.ExecuteStmt();
        }

        public int DeleteByMJESECIDGODINE(int mJESEC, short iDGODINE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmEVIDENCIJADelete2 = this.connDefault.GetCommand("DELETE FROM [EVIDENCIJA]  WHERE [MJESEC] = @MJESEC and [IDGODINE] = @IDGODINE", false);
            if (this.cmEVIDENCIJADelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                this.cmEVIDENCIJADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            this.cmEVIDENCIJADelete2.SetParameter(0, mJESEC);
            this.cmEVIDENCIJADelete2.SetParameter(1, iDGODINE);
            return this.cmEVIDENCIJADelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.EVIDENCIJASelect8 != null))
                    {
                        this.m_Closed = true;
                        this.EVIDENCIJASelect8.Close();
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
            this.cmEVIDENCIJASelect8 = this.connDefault.GetCommand("SELECT TM1.[MJESEC], TM1.[BROJEVIDENCIJE], TM1.[OPISEVIDENCIJE], TM1.[IDGODINE] FROM [EVIDENCIJA] TM1 WITH (NOLOCK) ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] ", false);
            this.EVIDENCIJASelect8 = this.cmEVIDENCIJASelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.EVIDENCIJASelect8;
        }

        public IDataReader OpenByIDGODINE(short iDGODINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmEVIDENCIJASelect8 = this.connDefault.GetCommand("SELECT TM1.[MJESEC], TM1.[BROJEVIDENCIJE], TM1.[OPISEVIDENCIJE], TM1.[IDGODINE] FROM [EVIDENCIJA] TM1 WITH (NOLOCK) WHERE TM1.[IDGODINE] = @IDGODINE ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] ", false);
            if (this.cmEVIDENCIJASelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJASelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            this.cmEVIDENCIJASelect8.SetParameter(0, iDGODINE);
            this.EVIDENCIJASelect8 = this.cmEVIDENCIJASelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.EVIDENCIJASelect8;
        }

        public IDataReader OpenByMJESEC(int mJESEC)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmEVIDENCIJASelect8 = this.connDefault.GetCommand("SELECT TM1.[MJESEC], TM1.[BROJEVIDENCIJE], TM1.[OPISEVIDENCIJE], TM1.[IDGODINE] FROM [EVIDENCIJA] TM1 WITH (NOLOCK) WHERE TM1.[MJESEC] = @MJESEC ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] ", false);
            if (this.cmEVIDENCIJASelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJASelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
            }
            this.cmEVIDENCIJASelect8.SetParameter(0, mJESEC);
            this.EVIDENCIJASelect8 = this.cmEVIDENCIJASelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.EVIDENCIJASelect8;
        }

        public IDataReader OpenByMJESECIDGODINE(int mJESEC, short iDGODINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmEVIDENCIJASelect8 = this.connDefault.GetCommand("SELECT TM1.[MJESEC], TM1.[BROJEVIDENCIJE], TM1.[OPISEVIDENCIJE], TM1.[IDGODINE] FROM [EVIDENCIJA] TM1 WITH (NOLOCK) WHERE TM1.[MJESEC] = @MJESEC and TM1.[IDGODINE] = @IDGODINE ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] ", false);
            if (this.cmEVIDENCIJASelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJASelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                this.cmEVIDENCIJASelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            this.cmEVIDENCIJASelect8.SetParameter(0, mJESEC);
            this.cmEVIDENCIJASelect8.SetParameter(1, iDGODINE);
            this.EVIDENCIJASelect8 = this.cmEVIDENCIJASelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.EVIDENCIJASelect8;
        }

        public IDataReader OpenByMJESECIDGODINEBROJEVIDENCIJE(int mJESEC, short iDGODINE, int bROJEVIDENCIJE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmEVIDENCIJASelect8 = this.connDefault.GetCommand("SELECT TM1.[MJESEC], TM1.[BROJEVIDENCIJE], TM1.[OPISEVIDENCIJE], TM1.[IDGODINE] FROM [EVIDENCIJA] TM1 WITH (NOLOCK) WHERE TM1.[MJESEC] = @MJESEC and TM1.[IDGODINE] = @IDGODINE and TM1.[BROJEVIDENCIJE] = @BROJEVIDENCIJE ORDER BY TM1.[MJESEC], TM1.[IDGODINE], TM1.[BROJEVIDENCIJE] ", false);
            if (this.cmEVIDENCIJASelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmEVIDENCIJASelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESEC", DbType.Int32));
                this.cmEVIDENCIJASelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                this.cmEVIDENCIJASelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJEVIDENCIJE", DbType.Int32));
            }
            this.cmEVIDENCIJASelect8.SetParameter(0, mJESEC);
            this.cmEVIDENCIJASelect8.SetParameter(1, iDGODINE);
            this.cmEVIDENCIJASelect8.SetParameter(2, bROJEVIDENCIJE);
            this.EVIDENCIJASelect8 = this.cmEVIDENCIJASelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.EVIDENCIJASelect8;
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

