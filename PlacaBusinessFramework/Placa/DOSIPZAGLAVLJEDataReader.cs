namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class DOSIPZAGLAVLJEDataReader : IDisposable
    {
        private ReadWriteCommand cmDOSIPZAGLAVLJEDelete2;
        private ReadWriteCommand cmDOSIPZAGLAVLJESelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DOSIPZAGLAVLJESelect6;
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

        public int DeleteByDOSIPIDENT(string dOSIPIDENT)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDOSIPZAGLAVLJEDelete2 = this.connDefault.GetCommand("DELETE FROM [DOSIPZAGLAVLJE]  WHERE [DOSIPIDENT] = @DOSIPIDENT", false);
            if (this.cmDOSIPZAGLAVLJEDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOSIPZAGLAVLJEDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
            }
            this.cmDOSIPZAGLAVLJEDelete2.SetParameter(0, dOSIPIDENT);
            return this.cmDOSIPZAGLAVLJEDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.DOSIPZAGLAVLJESelect6 != null))
                    {
                        this.m_Closed = true;
                        this.DOSIPZAGLAVLJESelect6.Close();
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
            this.cmDOSIPZAGLAVLJESelect6 = this.connDefault.GetCommand("SELECT TM1.[DOSIPIDENT], TM1.[DOSJMBG], TM1.[DOSISPLATAUGODINI], TM1.[DOSISPLATAZAGODINU], TM1.[DOSOZNACEN] FROM [DOSIPZAGLAVLJE] TM1 WITH (NOLOCK) ORDER BY TM1.[DOSIPIDENT], TM1.[DOSJMBG] ", false);
            this.DOSIPZAGLAVLJESelect6 = this.cmDOSIPZAGLAVLJESelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DOSIPZAGLAVLJESelect6;
        }

        public IDataReader OpenByDOSIPIDENT(string dOSIPIDENT)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDOSIPZAGLAVLJESelect6 = this.connDefault.GetCommand("SELECT TM1.[DOSIPIDENT], TM1.[DOSJMBG], TM1.[DOSISPLATAUGODINI], TM1.[DOSISPLATAZAGODINU], TM1.[DOSOZNACEN] FROM [DOSIPZAGLAVLJE] TM1 WITH (NOLOCK) WHERE TM1.[DOSIPIDENT] = @DOSIPIDENT ORDER BY TM1.[DOSIPIDENT], TM1.[DOSJMBG] ", false);
            if (this.cmDOSIPZAGLAVLJESelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOSIPZAGLAVLJESelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
            }
            this.cmDOSIPZAGLAVLJESelect6.SetParameter(0, dOSIPIDENT);
            this.DOSIPZAGLAVLJESelect6 = this.cmDOSIPZAGLAVLJESelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DOSIPZAGLAVLJESelect6;
        }

        public IDataReader OpenByDOSIPIDENTDOSJMBG(string dOSIPIDENT, string dOSJMBG)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDOSIPZAGLAVLJESelect6 = this.connDefault.GetCommand("SELECT TM1.[DOSIPIDENT], TM1.[DOSJMBG], TM1.[DOSISPLATAUGODINI], TM1.[DOSISPLATAZAGODINU], TM1.[DOSOZNACEN] FROM [DOSIPZAGLAVLJE] TM1 WITH (NOLOCK) WHERE TM1.[DOSIPIDENT] = @DOSIPIDENT and TM1.[DOSJMBG] = @DOSJMBG ORDER BY TM1.[DOSIPIDENT], TM1.[DOSJMBG] ", false);
            if (this.cmDOSIPZAGLAVLJESelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmDOSIPZAGLAVLJESelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSIPIDENT", DbType.String, 2));
                this.cmDOSIPZAGLAVLJESelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOSJMBG", DbType.String, 13));
            }
            this.cmDOSIPZAGLAVLJESelect6.SetParameter(0, dOSIPIDENT);
            this.cmDOSIPZAGLAVLJESelect6.SetParameter(1, dOSJMBG);
            this.DOSIPZAGLAVLJESelect6 = this.cmDOSIPZAGLAVLJESelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DOSIPZAGLAVLJESelect6;
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

