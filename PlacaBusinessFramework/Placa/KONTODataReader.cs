namespace Placa
{
    using Deklarit.Data;
    using Deklarit.Utils;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class KONTODataReader : IDisposable
    {
        private ReadWriteCommand cmKONTODelete2;
        private ReadWriteCommand cmKONTOSelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader KONTOSelect6;
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

        public int DeleteByIDAKTIVNOST(int iDAKTIVNOST)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmKONTODelete2 = this.connDefault.GetCommand("DELETE FROM [KONTO]  WHERE [IDAKTIVNOST] = @IDAKTIVNOST", false);
            if (this.cmKONTODelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmKONTODelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
            }
            this.cmKONTODelete2.SetParameter(0, iDAKTIVNOST);
            return this.cmKONTODelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.KONTOSelect6 != null))
                    {
                        this.m_Closed = true;
                        this.KONTOSelect6.Close();
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
            this.cmKONTOSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDKONTO], TM1.[NAZIVKONTO], T2.[NAZIVAKTIVNOST], TM1.[IDAKTIVNOST] FROM ([KONTO] TM1 WITH (NOLOCK) LEFT JOIN [AKTIVNOST] T2 WITH (NOLOCK) ON T2.[IDAKTIVNOST] = TM1.[IDAKTIVNOST]) ORDER BY TM1.[IDKONTO] ", false);
            this.KONTOSelect6 = this.cmKONTOSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.KONTOSelect6;
        }

        public IDataReader OpenByIDAKTIVNOST(int iDAKTIVNOST)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmKONTOSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDKONTO], TM1.[NAZIVKONTO], T2.[NAZIVAKTIVNOST], TM1.[IDAKTIVNOST] FROM ([KONTO] TM1 WITH (NOLOCK) LEFT JOIN [AKTIVNOST] T2 WITH (NOLOCK) ON T2.[IDAKTIVNOST] = TM1.[IDAKTIVNOST]) WHERE TM1.[IDAKTIVNOST] = @IDAKTIVNOST ORDER BY TM1.[IDKONTO] ", false);
            if (this.cmKONTOSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmKONTOSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
            }
            this.cmKONTOSelect6.SetParameter(0, iDAKTIVNOST);
            this.KONTOSelect6 = this.cmKONTOSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.KONTOSelect6;
        }

        public IDataReader OpenByIDKONTO(string iDKONTO)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmKONTOSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDKONTO], TM1.[NAZIVKONTO], T2.[NAZIVAKTIVNOST], TM1.[IDAKTIVNOST] FROM ([KONTO] TM1 WITH (NOLOCK) LEFT JOIN [AKTIVNOST] T2 WITH (NOLOCK) ON T2.[IDAKTIVNOST] = TM1.[IDAKTIVNOST]) WHERE TM1.[IDKONTO] = @IDKONTO ORDER BY TM1.[IDKONTO] ", false);
            if (this.cmKONTOSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmKONTOSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDKONTO", DbType.String, 14));
            }
            this.cmKONTOSelect6.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(iDKONTO)));
            this.KONTOSelect6 = this.cmKONTOSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.KONTOSelect6;
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

