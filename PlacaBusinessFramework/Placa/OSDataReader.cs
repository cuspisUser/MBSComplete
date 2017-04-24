namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class OSDataReader : IDisposable
    {
        private ReadWriteCommand cmOSDelete2;
        private ReadWriteCommand cmOSDelete3;
        private ReadWriteCommand cmOSSelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader OSSelect7;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByIDAMSKUPINE(int iDAMSKUPINE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSDelete2 = this.connDefault.GetCommand("DELETE FROM [OS]  WHERE [IDAMSKUPINE] = @IDAMSKUPINE", false);
            if (this.cmOSDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
            }
            this.cmOSDelete2.SetParameter(0, iDAMSKUPINE);
            return this.cmOSDelete2.ExecuteStmt();
        }

        public int DeleteByIDOSVRSTA(int iDOSVRSTA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSDelete3 = this.connDefault.GetCommand("DELETE FROM [OS]  WHERE [IDOSVRSTA] = @IDOSVRSTA", false);
            if (this.cmOSDelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSDelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSVRSTA", DbType.Int32));
            }
            this.cmOSDelete3.SetParameter(0, iDOSVRSTA);
            return this.cmOSDelete3.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.OSSelect7 != null))
                    {
                        this.m_Closed = true;
                        this.OSSelect7.Close();
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
            this.cmOSSelect7 = this.connDefault.GetCommand("SELECT TM1.[INVBROJ], TM1.[NAZIVOS], TM1.[DATUMNABAVKE], TM1.[DATUMUPORABE], TM1.[NAPOMENAOS], T2.[OPISAMSKUPINE], T2.[AMSKUPINASTOPA], TM1.[IDAMSKUPINE], T2.[KTONABAVKEIDKONTO], T2.[KTOISPRAVKAIDKONTO], T2.[KTOIZVORAIDKONTO], TM1.[IDOSVRSTA] FROM ([OS] TM1 WITH (NOLOCK) LEFT JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE]) ORDER BY TM1.[INVBROJ] ", false);
            this.OSSelect7 = this.cmOSSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OSSelect7;
        }

        public IDataReader OpenByIDAMSKUPINE(int iDAMSKUPINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSSelect7 = this.connDefault.GetCommand("SELECT TM1.[INVBROJ], TM1.[NAZIVOS], TM1.[DATUMNABAVKE], TM1.[DATUMUPORABE], TM1.[NAPOMENAOS], T2.[OPISAMSKUPINE], T2.[AMSKUPINASTOPA], TM1.[IDAMSKUPINE], T2.[KTONABAVKEIDKONTO], T2.[KTOISPRAVKAIDKONTO], T2.[KTOIZVORAIDKONTO], TM1.[IDOSVRSTA] FROM ([OS] TM1 WITH (NOLOCK) LEFT JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE]) WHERE TM1.[IDAMSKUPINE] = @IDAMSKUPINE ORDER BY TM1.[INVBROJ] ", false);
            if (this.cmOSSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
            }
            this.cmOSSelect7.SetParameter(0, iDAMSKUPINE);
            this.OSSelect7 = this.cmOSSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OSSelect7;
        }

        public IDataReader OpenByIDOSVRSTA(int iDOSVRSTA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSSelect7 = this.connDefault.GetCommand("SELECT TM1.[INVBROJ], TM1.[NAZIVOS], TM1.[DATUMNABAVKE], TM1.[DATUMUPORABE], TM1.[NAPOMENAOS], T2.[OPISAMSKUPINE], T2.[AMSKUPINASTOPA], TM1.[IDAMSKUPINE], T2.[KTONABAVKEIDKONTO], T2.[KTOISPRAVKAIDKONTO], T2.[KTOIZVORAIDKONTO], TM1.[IDOSVRSTA] FROM ([OS] TM1 WITH (NOLOCK) LEFT JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE]) WHERE TM1.[IDOSVRSTA] = @IDOSVRSTA ORDER BY TM1.[INVBROJ] ", false);
            if (this.cmOSSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSVRSTA", DbType.Int32));
            }
            this.cmOSSelect7.SetParameter(0, iDOSVRSTA);
            this.OSSelect7 = this.cmOSSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OSSelect7;
        }

        public IDataReader OpenByINVBROJ(long iNVBROJ)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSSelect7 = this.connDefault.GetCommand("SELECT TM1.[INVBROJ], TM1.[NAZIVOS], TM1.[DATUMNABAVKE], TM1.[DATUMUPORABE], TM1.[NAPOMENAOS], T2.[OPISAMSKUPINE], T2.[AMSKUPINASTOPA], TM1.[IDAMSKUPINE], T2.[KTONABAVKEIDKONTO], T2.[KTOISPRAVKAIDKONTO], T2.[KTOIZVORAIDKONTO], TM1.[IDOSVRSTA] FROM ([OS] TM1 WITH (NOLOCK) LEFT JOIN [AMSKUPINE] T2 WITH (NOLOCK) ON T2.[IDAMSKUPINE] = TM1.[IDAMSKUPINE]) WHERE TM1.[INVBROJ] = @INVBROJ ORDER BY TM1.[INVBROJ] ", false);
            if (this.cmOSSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@INVBROJ", DbType.Int64));
            }
            this.cmOSSelect7.SetParameter(0, iNVBROJ);
            this.OSSelect7 = this.cmOSSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.OSSelect7;
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

