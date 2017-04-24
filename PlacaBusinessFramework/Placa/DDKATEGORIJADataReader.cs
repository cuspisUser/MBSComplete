namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class DDKATEGORIJADataReader : IDisposable
    {
        private ReadWriteCommand cmDDKATEGORIJADelete2;
        private ReadWriteCommand cmDDKATEGORIJASelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DDKATEGORIJASelect6;
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

        public int DeleteByIDKOLONAIDD(int iDKOLONAIDD)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDKATEGORIJADelete2 = this.connDefault.GetCommand("DELETE FROM [DDKATEGORIJA]  WHERE [IDKOLONAIDD] = @IDKOLONAIDD", false);
            if (this.cmDDKATEGORIJADelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDKATEGORIJADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
            }
            this.cmDDKATEGORIJADelete2.SetParameter(0, iDKOLONAIDD);
            return this.cmDDKATEGORIJADelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.DDKATEGORIJASelect6 != null))
                    {
                        this.m_Closed = true;
                        this.DDKATEGORIJASelect6.Close();
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
            this.cmDDKATEGORIJASelect6 = this.connDefault.GetCommand("SELECT TM1.[IDKATEGORIJA], TM1.[NAZIVKATEGORIJA], T2.[NAZIVKOLONAIDD], TM1.[IDKOLONAIDD] FROM ([DDKATEGORIJA] TM1 WITH (NOLOCK) LEFT JOIN [DDKOLONAIDD] T2 WITH (NOLOCK) ON T2.[IDKOLONAIDD] = TM1.[IDKOLONAIDD]) ORDER BY TM1.[IDKATEGORIJA] ", false);
            this.DDKATEGORIJASelect6 = this.cmDDKATEGORIJASelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DDKATEGORIJASelect6;
        }

        public IDataReader OpenByIDKATEGORIJA(int iDKATEGORIJA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDKATEGORIJASelect6 = this.connDefault.GetCommand("SELECT TM1.[IDKATEGORIJA], TM1.[NAZIVKATEGORIJA], T2.[NAZIVKOLONAIDD], TM1.[IDKOLONAIDD] FROM ([DDKATEGORIJA] TM1 WITH (NOLOCK) LEFT JOIN [DDKOLONAIDD] T2 WITH (NOLOCK) ON T2.[IDKOLONAIDD] = TM1.[IDKOLONAIDD]) WHERE TM1.[IDKATEGORIJA] = @IDKATEGORIJA ORDER BY TM1.[IDKATEGORIJA] ", false);
            if (this.cmDDKATEGORIJASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDKATEGORIJASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKATEGORIJA", DbType.Int32));
            }
            this.cmDDKATEGORIJASelect6.SetParameter(0, iDKATEGORIJA);
            this.DDKATEGORIJASelect6 = this.cmDDKATEGORIJASelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DDKATEGORIJASelect6;
        }

        public IDataReader OpenByIDKOLONAIDD(int iDKOLONAIDD)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDKATEGORIJASelect6 = this.connDefault.GetCommand("SELECT TM1.[IDKATEGORIJA], TM1.[NAZIVKATEGORIJA], T2.[NAZIVKOLONAIDD], TM1.[IDKOLONAIDD] FROM ([DDKATEGORIJA] TM1 WITH (NOLOCK) LEFT JOIN [DDKOLONAIDD] T2 WITH (NOLOCK) ON T2.[IDKOLONAIDD] = TM1.[IDKOLONAIDD]) WHERE TM1.[IDKOLONAIDD] = @IDKOLONAIDD ORDER BY TM1.[IDKATEGORIJA] ", false);
            if (this.cmDDKATEGORIJASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDKATEGORIJASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKOLONAIDD", DbType.Int32));
            }
            this.cmDDKATEGORIJASelect6.SetParameter(0, iDKOLONAIDD);
            this.DDKATEGORIJASelect6 = this.cmDDKATEGORIJASelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DDKATEGORIJASelect6;
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

