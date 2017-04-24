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

    public class AMSKUPINEDataReader : IDisposable
    {
        private IDataReader AMSKUPINESelect8;
        private ReadWriteCommand cmAMSKUPINEDelete2;
        private ReadWriteCommand cmAMSKUPINEDelete3;
        private ReadWriteCommand cmAMSKUPINEDelete4;
        private ReadWriteCommand cmAMSKUPINESelect8;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
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

        public int DeleteByKTOISPRAVKAIDKONTO(string kTOISPRAVKAIDKONTO)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmAMSKUPINEDelete3 = this.connDefault.GetCommand("DELETE FROM [AMSKUPINE]  WHERE [KTOISPRAVKAIDKONTO] = @KTOISPRAVKAIDKONTO", false);
            if (this.cmAMSKUPINEDelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmAMSKUPINEDelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTOISPRAVKAIDKONTO", DbType.String, 14));
            }
            this.cmAMSKUPINEDelete3.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(kTOISPRAVKAIDKONTO)));
            return this.cmAMSKUPINEDelete3.ExecuteStmt();
        }

        public int DeleteByKTOIZVORAIDKONTO(string kTOIZVORAIDKONTO)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmAMSKUPINEDelete4 = this.connDefault.GetCommand("DELETE FROM [AMSKUPINE]  WHERE [KTOIZVORAIDKONTO] = @KTOIZVORAIDKONTO", false);
            if (this.cmAMSKUPINEDelete4.IDbCommand.Parameters.Count == 0)
            {
                this.cmAMSKUPINEDelete4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTOIZVORAIDKONTO", DbType.String, 14));
            }
            this.cmAMSKUPINEDelete4.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(kTOIZVORAIDKONTO)));
            return this.cmAMSKUPINEDelete4.ExecuteStmt();
        }

        public int DeleteByKTONABAVKEIDKONTO(string kTONABAVKEIDKONTO)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmAMSKUPINEDelete2 = this.connDefault.GetCommand("DELETE FROM [AMSKUPINE]  WHERE [KTONABAVKEIDKONTO] = @KTONABAVKEIDKONTO", false);
            if (this.cmAMSKUPINEDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmAMSKUPINEDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTONABAVKEIDKONTO", DbType.String, 14));
            }
            this.cmAMSKUPINEDelete2.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(kTONABAVKEIDKONTO)));
            return this.cmAMSKUPINEDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.AMSKUPINESelect8 != null))
                    {
                        this.m_Closed = true;
                        this.AMSKUPINESelect8.Close();
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
            this.cmAMSKUPINESelect8 = this.connDefault.GetCommand("SELECT TM1.[IDAMSKUPINE], TM1.[KRATKASIFRA], TM1.[OPISAMSKUPINE], TM1.[AMSKUPINASTOPA], TM1.[KTONABAVKEIDKONTO] AS KTONABAVKEIDKONTO, TM1.[KTOISPRAVKAIDKONTO] AS KTOISPRAVKAIDKONTO, TM1.[KTOIZVORAIDKONTO] AS KTOIZVORAIDKONTO FROM [AMSKUPINE] TM1 WITH (NOLOCK) ORDER BY TM1.[IDAMSKUPINE] ", false);
            this.AMSKUPINESelect8 = this.cmAMSKUPINESelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.AMSKUPINESelect8;
        }

        public IDataReader OpenByIDAMSKUPINE(int iDAMSKUPINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmAMSKUPINESelect8 = this.connDefault.GetCommand("SELECT TM1.[IDAMSKUPINE], TM1.[KRATKASIFRA], TM1.[OPISAMSKUPINE], TM1.[AMSKUPINASTOPA], TM1.[KTONABAVKEIDKONTO] AS KTONABAVKEIDKONTO, TM1.[KTOISPRAVKAIDKONTO] AS KTOISPRAVKAIDKONTO, TM1.[KTOIZVORAIDKONTO] AS KTOIZVORAIDKONTO FROM [AMSKUPINE] TM1 WITH (NOLOCK) WHERE TM1.[IDAMSKUPINE] = @IDAMSKUPINE ORDER BY TM1.[IDAMSKUPINE] ", false);
            if (this.cmAMSKUPINESelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmAMSKUPINESelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAMSKUPINE", DbType.Int32));
            }
            this.cmAMSKUPINESelect8.SetParameter(0, iDAMSKUPINE);
            this.AMSKUPINESelect8 = this.cmAMSKUPINESelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.AMSKUPINESelect8;
        }

        public IDataReader OpenByKTOISPRAVKAIDKONTO(string kTOISPRAVKAIDKONTO)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmAMSKUPINESelect8 = this.connDefault.GetCommand("SELECT TM1.[IDAMSKUPINE], TM1.[KRATKASIFRA], TM1.[OPISAMSKUPINE], TM1.[AMSKUPINASTOPA], TM1.[KTONABAVKEIDKONTO] AS KTONABAVKEIDKONTO, TM1.[KTOISPRAVKAIDKONTO] AS KTOISPRAVKAIDKONTO, TM1.[KTOIZVORAIDKONTO] AS KTOIZVORAIDKONTO FROM [AMSKUPINE] TM1 WITH (NOLOCK) WHERE TM1.[KTOISPRAVKAIDKONTO] = @KTOISPRAVKAIDKONTO ORDER BY TM1.[IDAMSKUPINE] ", false);
            if (this.cmAMSKUPINESelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmAMSKUPINESelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTOISPRAVKAIDKONTO", DbType.String, 14));
            }
            this.cmAMSKUPINESelect8.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(kTOISPRAVKAIDKONTO)));
            this.AMSKUPINESelect8 = this.cmAMSKUPINESelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.AMSKUPINESelect8;
        }

        public IDataReader OpenByKTOIZVORAIDKONTO(string kTOIZVORAIDKONTO)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmAMSKUPINESelect8 = this.connDefault.GetCommand("SELECT TM1.[IDAMSKUPINE], TM1.[KRATKASIFRA], TM1.[OPISAMSKUPINE], TM1.[AMSKUPINASTOPA], TM1.[KTONABAVKEIDKONTO] AS KTONABAVKEIDKONTO, TM1.[KTOISPRAVKAIDKONTO] AS KTOISPRAVKAIDKONTO, TM1.[KTOIZVORAIDKONTO] AS KTOIZVORAIDKONTO FROM [AMSKUPINE] TM1 WITH (NOLOCK) WHERE TM1.[KTOIZVORAIDKONTO] = @KTOIZVORAIDKONTO ORDER BY TM1.[IDAMSKUPINE] ", false);
            if (this.cmAMSKUPINESelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmAMSKUPINESelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTOIZVORAIDKONTO", DbType.String, 14));
            }
            this.cmAMSKUPINESelect8.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(kTOIZVORAIDKONTO)));
            this.AMSKUPINESelect8 = this.cmAMSKUPINESelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.AMSKUPINESelect8;
        }

        public IDataReader OpenByKTONABAVKEIDKONTO(string kTONABAVKEIDKONTO)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmAMSKUPINESelect8 = this.connDefault.GetCommand("SELECT TM1.[IDAMSKUPINE], TM1.[KRATKASIFRA], TM1.[OPISAMSKUPINE], TM1.[AMSKUPINASTOPA], TM1.[KTONABAVKEIDKONTO] AS KTONABAVKEIDKONTO, TM1.[KTOISPRAVKAIDKONTO] AS KTOISPRAVKAIDKONTO, TM1.[KTOIZVORAIDKONTO] AS KTOIZVORAIDKONTO FROM [AMSKUPINE] TM1 WITH (NOLOCK) WHERE TM1.[KTONABAVKEIDKONTO] = @KTONABAVKEIDKONTO ORDER BY TM1.[IDAMSKUPINE] ", false);
            if (this.cmAMSKUPINESelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmAMSKUPINESelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@KTONABAVKEIDKONTO", DbType.String, 14));
            }
            this.cmAMSKUPINESelect8.SetParameter(0, RuntimeHelpers.GetObjectValue(StringUtil.ObjectStringRightTrim(kTONABAVKEIDKONTO)));
            this.AMSKUPINESelect8 = this.cmAMSKUPINESelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.AMSKUPINESelect8;
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

