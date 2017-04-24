namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class DOKUMENTDataReader : IDisposable
    {
        private ReadWriteCommand cmDOKUMENTDelete2;
        private ReadWriteCommand cmDOKUMENTSelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DOKUMENTSelect6;
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

        public int DeleteByIDTIPDOKUMENTA(int iDTIPDOKUMENTA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDOKUMENTDelete2 = this.connDefault.GetCommand("DELETE FROM [DOKUMENT]  WHERE [IDTIPDOKUMENTA] = @IDTIPDOKUMENTA", false);
            if (this.cmDOKUMENTDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOKUMENTDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
            }
            this.cmDOKUMENTDelete2.SetParameter(0, iDTIPDOKUMENTA);
            return this.cmDOKUMENTDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.DOKUMENTSelect6 != null))
                    {
                        this.m_Closed = true;
                        this.DOKUMENTSelect6.Close();
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
            this.cmDOKUMENTSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDDOKUMENT], TM1.[NAZIVDOKUMENT], T2.[NAZIVTIPDOKUMENTA], TM1.[PS], TM1.[IDTIPDOKUMENTA] FROM ([DOKUMENT] TM1 WITH (NOLOCK) LEFT JOIN [TIPDOKUMENTA] T2 WITH (NOLOCK) ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA]) ORDER BY TM1.[IDDOKUMENT] ", false);
            this.DOKUMENTSelect6 = this.cmDOKUMENTSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DOKUMENTSelect6;
        }

        public IDataReader OpenByIDDOKUMENT(int iDDOKUMENT)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDOKUMENTSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDDOKUMENT], TM1.[NAZIVDOKUMENT], T2.[NAZIVTIPDOKUMENTA], TM1.[PS], TM1.[IDTIPDOKUMENTA] FROM ([DOKUMENT] TM1 WITH (NOLOCK) LEFT JOIN [TIPDOKUMENTA] T2 WITH (NOLOCK) ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA]) WHERE TM1.[IDDOKUMENT] = @IDDOKUMENT ORDER BY TM1.[IDDOKUMENT] ", false);
            if (this.cmDOKUMENTSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOKUMENTSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOKUMENT", DbType.Int32));
            }
            this.cmDOKUMENTSelect6.SetParameter(0, iDDOKUMENT);
            this.DOKUMENTSelect6 = this.cmDOKUMENTSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DOKUMENTSelect6;
        }

        public IDataReader OpenByIDTIPDOKUMENTA(int iDTIPDOKUMENTA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDOKUMENTSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDDOKUMENT], TM1.[NAZIVDOKUMENT], T2.[NAZIVTIPDOKUMENTA], TM1.[PS], TM1.[IDTIPDOKUMENTA] FROM ([DOKUMENT] TM1 WITH (NOLOCK) LEFT JOIN [TIPDOKUMENTA] T2 WITH (NOLOCK) ON T2.[IDTIPDOKUMENTA] = TM1.[IDTIPDOKUMENTA]) WHERE TM1.[IDTIPDOKUMENTA] = @IDTIPDOKUMENTA ORDER BY TM1.[IDDOKUMENT] ", false);
            if (this.cmDOKUMENTSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOKUMENTSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPDOKUMENTA", DbType.Int32));
            }
            this.cmDOKUMENTSelect6.SetParameter(0, iDTIPDOKUMENTA);
            this.DOKUMENTSelect6 = this.cmDOKUMENTSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DOKUMENTSelect6;
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

