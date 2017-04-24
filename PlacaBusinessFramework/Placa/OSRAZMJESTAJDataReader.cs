namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class OSRAZMJESTAJDataReader : IDisposable
    {
        private ReadWriteCommand cmOSRAZMJESTAJDelete2;
        private ReadWriteCommand cmOSRAZMJESTAJDelete3;
        private ReadWriteCommand cmOSRAZMJESTAJSelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader OSRAZMJESTAJSelect7;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByIDLOKACIJE(int iDLOKACIJE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSRAZMJESTAJDelete3 = this.connDefault.GetCommand("DELETE FROM [OSRAZMJESTAJ]  WHERE [IDLOKACIJE] = @IDLOKACIJE", false);
            if (this.cmOSRAZMJESTAJDelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSRAZMJESTAJDelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", DbType.Int32));
            }
            this.cmOSRAZMJESTAJDelete3.SetParameter(0, iDLOKACIJE);
            return this.cmOSRAZMJESTAJDelete3.ExecuteStmt();
        }

        public int DeleteByINVBROJ(long iNVBROJ)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSRAZMJESTAJDelete2 = this.connDefault.GetCommand("DELETE FROM [OSRAZMJESTAJ]  WHERE [INVBROJ] = @INVBROJ", false);
            if (this.cmOSRAZMJESTAJDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSRAZMJESTAJDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
            }
            this.cmOSRAZMJESTAJDelete2.SetParameter(0, iNVBROJ);
            return this.cmOSRAZMJESTAJDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.OSRAZMJESTAJSelect7 != null))
                    {
                        this.m_Closed = true;
                        this.OSRAZMJESTAJSelect7.Close();
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
            this.cmOSRAZMJESTAJSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDOSRAZMJESTAJ], TM1.[KOLICINAULAZA], TM1.[KOLICINARASHODA], TM1.[IDLOKACIJE], TM1.[INVBROJ] FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK) ORDER BY TM1.[IDOSRAZMJESTAJ] ", false);
            this.OSRAZMJESTAJSelect7 = this.cmOSRAZMJESTAJSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OSRAZMJESTAJSelect7;
        }

        public IDataReader OpenByIDLOKACIJE(int iDLOKACIJE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSRAZMJESTAJSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDOSRAZMJESTAJ], TM1.[KOLICINAULAZA], TM1.[KOLICINARASHODA], TM1.[IDLOKACIJE], TM1.[INVBROJ] FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK) WHERE TM1.[IDLOKACIJE] = @IDLOKACIJE ORDER BY TM1.[IDOSRAZMJESTAJ] ", false);
            if (this.cmOSRAZMJESTAJSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSRAZMJESTAJSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDLOKACIJE", DbType.Int32));
            }
            this.cmOSRAZMJESTAJSelect7.SetParameter(0, iDLOKACIJE);
            this.OSRAZMJESTAJSelect7 = this.cmOSRAZMJESTAJSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OSRAZMJESTAJSelect7;
        }

        public IDataReader OpenByIDOSRAZMJESTAJ(Guid iDOSRAZMJESTAJ)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSRAZMJESTAJSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDOSRAZMJESTAJ], TM1.[KOLICINAULAZA], TM1.[KOLICINARASHODA], TM1.[IDLOKACIJE], TM1.[INVBROJ] FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK) WHERE TM1.[IDOSRAZMJESTAJ] = @IDOSRAZMJESTAJ ORDER BY TM1.[IDOSRAZMJESTAJ] ", false);
            if (this.cmOSRAZMJESTAJSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSRAZMJESTAJSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSRAZMJESTAJ", DbType.Guid));
            }
            this.cmOSRAZMJESTAJSelect7.SetParameter(0, iDOSRAZMJESTAJ);
            this.OSRAZMJESTAJSelect7 = this.cmOSRAZMJESTAJSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OSRAZMJESTAJSelect7;
        }

        public IDataReader OpenByINVBROJ(long iNVBROJ)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSRAZMJESTAJSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDOSRAZMJESTAJ], TM1.[KOLICINAULAZA], TM1.[KOLICINARASHODA], TM1.[IDLOKACIJE], TM1.[INVBROJ] FROM [OSRAZMJESTAJ] TM1 WITH (NOLOCK) WHERE TM1.[INVBROJ] = @INVBROJ ORDER BY TM1.[IDOSRAZMJESTAJ] ", false);
            if (this.cmOSRAZMJESTAJSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSRAZMJESTAJSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
            }
            this.cmOSRAZMJESTAJSelect7.SetParameter(0, iNVBROJ);
            this.OSRAZMJESTAJSelect7 = this.cmOSRAZMJESTAJSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OSRAZMJESTAJSelect7;
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

