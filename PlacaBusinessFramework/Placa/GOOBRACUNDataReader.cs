namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class GOOBRACUNDataReader : IDisposable
    {
        private ReadWriteCommand cmGOOBRACUNDelete2;
        private ReadWriteCommand cmGOOBRACUNSelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader GOOBRACUNSelect6;
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

        public int DeleteByIDRADNIK(int iDRADNIK)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGOOBRACUNDelete2 = this.connDefault.GetCommand("DELETE FROM [GOOBRACUN]  WHERE [IDRADNIK] = @IDRADNIK", false);
            if (this.cmGOOBRACUNDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmGOOBRACUNDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmGOOBRACUNDelete2.SetParameter(0, iDRADNIK);
            return this.cmGOOBRACUNDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.GOOBRACUNSelect6 != null))
                    {
                        this.m_Closed = true;
                        this.GOOBRACUNSelect6.Close();
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
            this.cmGOOBRACUNSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDGOOBRACUN], T2.[PREZIME], T2.[IME], T2.[AKTIVAN], TM1.[OLAKSICEISKORISTIVO], TM1.[ODBICIISKORISTIVO], TM1.[IDRADNIK] FROM ([GOOBRACUN] TM1 WITH (NOLOCK) LEFT JOIN [RADNIK] T2 WITH (NOLOCK) ON T2.[IDRADNIK] = TM1.[IDRADNIK]) ORDER BY TM1.[IDGOOBRACUN] ", false);
            this.GOOBRACUNSelect6 = this.cmGOOBRACUNSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GOOBRACUNSelect6;
        }

        public IDataReader OpenByIDGOOBRACUN(int iDGOOBRACUN)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGOOBRACUNSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDGOOBRACUN], T2.[PREZIME], T2.[IME], T2.[AKTIVAN], TM1.[OLAKSICEISKORISTIVO], TM1.[ODBICIISKORISTIVO], TM1.[IDRADNIK] FROM ([GOOBRACUN] TM1 WITH (NOLOCK) LEFT JOIN [RADNIK] T2 WITH (NOLOCK) ON T2.[IDRADNIK] = TM1.[IDRADNIK]) WHERE TM1.[IDGOOBRACUN] = @IDGOOBRACUN ORDER BY TM1.[IDGOOBRACUN] ", false);
            if (this.cmGOOBRACUNSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmGOOBRACUNSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGOOBRACUN", DbType.Int32));
            }
            this.cmGOOBRACUNSelect6.SetParameter(0, iDGOOBRACUN);
            this.GOOBRACUNSelect6 = this.cmGOOBRACUNSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GOOBRACUNSelect6;
        }

        public IDataReader OpenByIDRADNIK(int iDRADNIK)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGOOBRACUNSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDGOOBRACUN], T2.[PREZIME], T2.[IME], T2.[AKTIVAN], TM1.[OLAKSICEISKORISTIVO], TM1.[ODBICIISKORISTIVO], TM1.[IDRADNIK] FROM ([GOOBRACUN] TM1 WITH (NOLOCK) LEFT JOIN [RADNIK] T2 WITH (NOLOCK) ON T2.[IDRADNIK] = TM1.[IDRADNIK]) WHERE TM1.[IDRADNIK] = @IDRADNIK ORDER BY TM1.[IDGOOBRACUN] ", false);
            if (this.cmGOOBRACUNSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmGOOBRACUNSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDRADNIK", DbType.Int32));
            }
            this.cmGOOBRACUNSelect6.SetParameter(0, iDRADNIK);
            this.GOOBRACUNSelect6 = this.cmGOOBRACUNSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.GOOBRACUNSelect6;
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

