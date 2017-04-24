namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class ZAPOSLENIDataReader : IDisposable
    {
        private ReadWriteCommand cmZAPOSLENIDelete2;
        private ReadWriteCommand cmZAPOSLENISelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader ZAPOSLENISelect6;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByIDRADNIK(int iDRADNIK)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmZAPOSLENIDelete2 = this.connDefault.GetCommand("DELETE FROM [ZAPOSLENI]  WHERE [IDRADNIK] = @IDRADNIK", false);
            if (this.cmZAPOSLENIDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmZAPOSLENIDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmZAPOSLENIDelete2.SetParameter(0, iDRADNIK);
            return this.cmZAPOSLENIDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.ZAPOSLENISelect6 != null))
                    {
                        this.m_Closed = true;
                        this.ZAPOSLENISelect6.Close();
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
            this.cmZAPOSLENISelect6 = this.connDefault.GetCommand("SELECT TM1.[DATUMZAPOSLENJA], TM1.[IDRADNIK] FROM [ZAPOSLENI] TM1 WITH (NOLOCK) ORDER BY TM1.[IDRADNIK], TM1.[DATUMZAPOSLENJA] ", false);
            this.ZAPOSLENISelect6 = this.cmZAPOSLENISelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.ZAPOSLENISelect6;
        }

        public IDataReader OpenByIDRADNIK(int iDRADNIK)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmZAPOSLENISelect6 = this.connDefault.GetCommand("SELECT TM1.[DATUMZAPOSLENJA], TM1.[IDRADNIK] FROM [ZAPOSLENI] TM1 WITH (NOLOCK) WHERE TM1.[IDRADNIK] = @IDRADNIK ORDER BY TM1.[IDRADNIK], TM1.[DATUMZAPOSLENJA] ", false);
            if (this.cmZAPOSLENISelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmZAPOSLENISelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmZAPOSLENISelect6.SetParameter(0, iDRADNIK);
            this.ZAPOSLENISelect6 = this.cmZAPOSLENISelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.ZAPOSLENISelect6;
        }

        public IDataReader OpenByIDRADNIKDATUMZAPOSLENJA(int iDRADNIK, DateTime dATUMZAPOSLENJA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmZAPOSLENISelect6 = this.connDefault.GetCommand("SELECT TM1.[DATUMZAPOSLENJA], TM1.[IDRADNIK] FROM [ZAPOSLENI] TM1 WITH (NOLOCK) WHERE TM1.[IDRADNIK] = @IDRADNIK and TM1.[DATUMZAPOSLENJA] = @DATUMZAPOSLENJA ORDER BY TM1.[IDRADNIK], TM1.[DATUMZAPOSLENJA] ", false);
            if (this.cmZAPOSLENISelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmZAPOSLENISelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
                this.cmZAPOSLENISelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMZAPOSLENJA", DbType.Date));
            }
            this.cmZAPOSLENISelect6.SetParameter(0, iDRADNIK);
            this.cmZAPOSLENISelect6.SetParameterDateObject(1, dATUMZAPOSLENJA);
            this.ZAPOSLENISelect6 = this.cmZAPOSLENISelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.ZAPOSLENISelect6;
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

