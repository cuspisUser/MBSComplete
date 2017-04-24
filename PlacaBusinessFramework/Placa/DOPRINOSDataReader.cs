namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class DOPRINOSDataReader : IDisposable
    {
        private ReadWriteCommand cmDOPRINOSDelete2;
        private ReadWriteCommand cmDOPRINOSSelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DOPRINOSSelect6;
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

        public int DeleteByIDVRSTADOPRINOS(int iDVRSTADOPRINOS)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDOPRINOSDelete2 = this.connDefault.GetCommand("DELETE FROM [DOPRINOS]  WHERE [IDVRSTADOPRINOS] = @IDVRSTADOPRINOS", false);
            if (this.cmDOPRINOSDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOPRINOSDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
            }
            this.cmDOPRINOSDelete2.SetParameter(0, iDVRSTADOPRINOS);
            return this.cmDOPRINOSDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.DOPRINOSSelect6 != null))
                    {
                        this.m_Closed = true;
                        this.DOPRINOSSelect6.Close();
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
            this.cmDOPRINOSSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDDOPRINOS], TM1.[NAZIVDOPRINOS], T2.[NAZIVVRSTADOPRINOS], TM1.[STOPA], TM1.[MODOPRINOS], TM1.[PODOPRINOS], TM1.[MZDOPRINOS], TM1.[PZDOPRINOS], TM1.[PRIMATELJDOPRINOS1], TM1.[PRIMATELJDOPRINOS2], TM1.[SIFRAOPISAPLACANJADOPRINOS], TM1.[OPISPLACANJADOPRINOS], TM1.[VBDIDOPRINOS], TM1.[ZRNDOPRINOS], TM1.[MINDOPRINOS], TM1.[MAXDOPRINOS], TM1.[IDVRSTADOPRINOS] FROM ([DOPRINOS] TM1 WITH (NOLOCK) LEFT JOIN [VRSTADOPRINOS] T2 WITH (NOLOCK) ON T2.[IDVRSTADOPRINOS] = TM1.[IDVRSTADOPRINOS]) ORDER BY TM1.[IDDOPRINOS] ", false);
            this.DOPRINOSSelect6 = this.cmDOPRINOSSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DOPRINOSSelect6;
        }

        public IDataReader OpenByIDDOPRINOS(int iDDOPRINOS)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDOPRINOSSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDDOPRINOS], TM1.[NAZIVDOPRINOS], T2.[NAZIVVRSTADOPRINOS], TM1.[STOPA], TM1.[MODOPRINOS], TM1.[PODOPRINOS], TM1.[MZDOPRINOS], TM1.[PZDOPRINOS], TM1.[PRIMATELJDOPRINOS1], TM1.[PRIMATELJDOPRINOS2], TM1.[SIFRAOPISAPLACANJADOPRINOS], TM1.[OPISPLACANJADOPRINOS], TM1.[VBDIDOPRINOS], TM1.[ZRNDOPRINOS], TM1.[MINDOPRINOS], TM1.[MAXDOPRINOS], TM1.[IDVRSTADOPRINOS] FROM ([DOPRINOS] TM1 WITH (NOLOCK) LEFT JOIN [VRSTADOPRINOS] T2 WITH (NOLOCK) ON T2.[IDVRSTADOPRINOS] = TM1.[IDVRSTADOPRINOS]) WHERE TM1.[IDDOPRINOS] = @IDDOPRINOS ORDER BY TM1.[IDDOPRINOS] ", false);
            if (this.cmDOPRINOSSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOPRINOSSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDOPRINOS", DbType.Int32));
            }
            this.cmDOPRINOSSelect6.SetParameter(0, iDDOPRINOS);
            this.DOPRINOSSelect6 = this.cmDOPRINOSSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DOPRINOSSelect6;
        }

        public IDataReader OpenByIDVRSTADOPRINOS(int iDVRSTADOPRINOS)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDOPRINOSSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDDOPRINOS], TM1.[NAZIVDOPRINOS], T2.[NAZIVVRSTADOPRINOS], TM1.[STOPA], TM1.[MODOPRINOS], TM1.[PODOPRINOS], TM1.[MZDOPRINOS], TM1.[PZDOPRINOS], TM1.[PRIMATELJDOPRINOS1], TM1.[PRIMATELJDOPRINOS2], TM1.[SIFRAOPISAPLACANJADOPRINOS], TM1.[OPISPLACANJADOPRINOS], TM1.[VBDIDOPRINOS], TM1.[ZRNDOPRINOS], TM1.[MINDOPRINOS], TM1.[MAXDOPRINOS], TM1.[IDVRSTADOPRINOS] FROM ([DOPRINOS] TM1 WITH (NOLOCK) LEFT JOIN [VRSTADOPRINOS] T2 WITH (NOLOCK) ON T2.[IDVRSTADOPRINOS] = TM1.[IDVRSTADOPRINOS]) WHERE TM1.[IDVRSTADOPRINOS] = @IDVRSTADOPRINOS ORDER BY TM1.[IDDOPRINOS] ", false);
            if (this.cmDOPRINOSSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOPRINOSSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTADOPRINOS", DbType.Int32));
            }
            this.cmDOPRINOSSelect6.SetParameter(0, iDVRSTADOPRINOS);
            this.DOPRINOSSelect6 = this.cmDOPRINOSSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DOPRINOSSelect6;
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

