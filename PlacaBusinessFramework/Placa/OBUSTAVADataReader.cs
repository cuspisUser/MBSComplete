namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class OBUSTAVADataReader : IDisposable
    {
        private ReadWriteCommand cmOBUSTAVADelete2;
        private ReadWriteCommand cmOBUSTAVASelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader OBUSTAVASelect6;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByVRSTAOBUSTAVE(short vRSTAOBUSTAVE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOBUSTAVADelete2 = this.connDefault.GetCommand("DELETE FROM [OBUSTAVA]  WHERE [VRSTAOBUSTAVE] = @VRSTAOBUSTAVE", false);
            if (this.cmOBUSTAVADelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOBUSTAVADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
            }
            this.cmOBUSTAVADelete2.SetParameter(0, vRSTAOBUSTAVE);
            return this.cmOBUSTAVADelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.OBUSTAVASelect6 != null))
                    {
                        this.m_Closed = true;
                        this.OBUSTAVASelect6.Close();
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
            this.cmOBUSTAVASelect6 = this.connDefault.GetCommand("SELECT TM1.[IDOBUSTAVA], TM1.[NAZIVOBUSTAVA], TM1.[MOOBUSTAVA], TM1.[POOBUSTAVA], TM1.[MZOBUSTAVA], TM1.[PZOBUSTAVA], TM1.[VBDIOBUSTAVA], TM1.[ZRNOBUSTAVA], TM1.[PRIMATELJOBUSTAVA1], TM1.[PRIMATELJOBUSTAVA2], TM1.[PRIMATELJOBUSTAVA3], TM1.[SIFRAOPISAPLACANJAOBUSTAVA], TM1.[OPISPLACANJAOBUSTAVA], T2.[NAZIVVRSTAOBUSTAVE], TM1.[VRSTAOBUSTAVE] FROM ([OBUSTAVA] TM1 WITH (NOLOCK) LEFT JOIN [VRSTEOBUSTAVA] T2 WITH (NOLOCK) ON T2.[VRSTAOBUSTAVE] = TM1.[VRSTAOBUSTAVE]) ORDER BY TM1.[IDOBUSTAVA] ", false);
            this.OBUSTAVASelect6 = this.cmOBUSTAVASelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OBUSTAVASelect6;
        }

        public IDataReader OpenByIDOBUSTAVA(int iDOBUSTAVA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOBUSTAVASelect6 = this.connDefault.GetCommand("SELECT TM1.[IDOBUSTAVA], TM1.[NAZIVOBUSTAVA], TM1.[MOOBUSTAVA], TM1.[POOBUSTAVA], TM1.[MZOBUSTAVA], TM1.[PZOBUSTAVA], TM1.[VBDIOBUSTAVA], TM1.[ZRNOBUSTAVA], TM1.[PRIMATELJOBUSTAVA1], TM1.[PRIMATELJOBUSTAVA2], TM1.[PRIMATELJOBUSTAVA3], TM1.[SIFRAOPISAPLACANJAOBUSTAVA], TM1.[OPISPLACANJAOBUSTAVA], T2.[NAZIVVRSTAOBUSTAVE], TM1.[VRSTAOBUSTAVE] FROM ([OBUSTAVA] TM1 WITH (NOLOCK) LEFT JOIN [VRSTEOBUSTAVA] T2 WITH (NOLOCK) ON T2.[VRSTAOBUSTAVE] = TM1.[VRSTAOBUSTAVE]) WHERE TM1.[IDOBUSTAVA] = @IDOBUSTAVA ORDER BY TM1.[IDOBUSTAVA] ", false);
            if (this.cmOBUSTAVASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmOBUSTAVASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBUSTAVA", DbType.Int32));
            }
            this.cmOBUSTAVASelect6.SetParameter(0, iDOBUSTAVA);
            this.OBUSTAVASelect6 = this.cmOBUSTAVASelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OBUSTAVASelect6;
        }

        public IDataReader OpenByVRSTAOBUSTAVE(short vRSTAOBUSTAVE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOBUSTAVASelect6 = this.connDefault.GetCommand("SELECT TM1.[IDOBUSTAVA], TM1.[NAZIVOBUSTAVA], TM1.[MOOBUSTAVA], TM1.[POOBUSTAVA], TM1.[MZOBUSTAVA], TM1.[PZOBUSTAVA], TM1.[VBDIOBUSTAVA], TM1.[ZRNOBUSTAVA], TM1.[PRIMATELJOBUSTAVA1], TM1.[PRIMATELJOBUSTAVA2], TM1.[PRIMATELJOBUSTAVA3], TM1.[SIFRAOPISAPLACANJAOBUSTAVA], TM1.[OPISPLACANJAOBUSTAVA], T2.[NAZIVVRSTAOBUSTAVE], TM1.[VRSTAOBUSTAVE] FROM ([OBUSTAVA] TM1 WITH (NOLOCK) LEFT JOIN [VRSTEOBUSTAVA] T2 WITH (NOLOCK) ON T2.[VRSTAOBUSTAVE] = TM1.[VRSTAOBUSTAVE]) WHERE TM1.[VRSTAOBUSTAVE] = @VRSTAOBUSTAVE ORDER BY TM1.[IDOBUSTAVA] ", false);
            if (this.cmOBUSTAVASelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmOBUSTAVASelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VRSTAOBUSTAVE", DbType.Int16));
            }
            this.cmOBUSTAVASelect6.SetParameter(0, vRSTAOBUSTAVE);
            this.OBUSTAVASelect6 = this.cmOBUSTAVASelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OBUSTAVASelect6;
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

