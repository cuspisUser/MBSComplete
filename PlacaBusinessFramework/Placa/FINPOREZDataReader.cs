﻿namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class FINPOREZDataReader : IDisposable
    {
        private ReadWriteCommand cmFINPOREZSelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader FINPOREZSelect5;
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

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.FINPOREZSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.FINPOREZSelect5.Close();
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
            this.cmFINPOREZSelect5 = this.connDefault.GetCommand("SELECT TM1.[FINPOREZIDPOREZ], TM1.[FINPOREZNAZIVPOREZ], TM1.[FINPOREZSTOPA], TM1.[OSNOVICAUKNIZIIRA] FROM [FINPOREZ] TM1 WITH (NOLOCK) ORDER BY TM1.[FINPOREZIDPOREZ] ", false);
            this.FINPOREZSelect5 = this.cmFINPOREZSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.FINPOREZSelect5;
        }

        public IDataReader OpenByFINPOREZIDPOREZ(int fINPOREZIDPOREZ)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmFINPOREZSelect5 = this.connDefault.GetCommand("SELECT TM1.[FINPOREZIDPOREZ], TM1.[FINPOREZNAZIVPOREZ], TM1.[FINPOREZSTOPA], TM1.[OSNOVICAUKNIZIIRA] FROM [FINPOREZ] TM1 WITH (NOLOCK) WHERE TM1.[FINPOREZIDPOREZ] = @FINPOREZIDPOREZ ORDER BY TM1.[FINPOREZIDPOREZ] ", false);
            if (this.cmFINPOREZSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmFINPOREZSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
            }
            this.cmFINPOREZSelect5.SetParameter(0, fINPOREZIDPOREZ);
            this.FINPOREZSelect5 = this.cmFINPOREZSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.FINPOREZSelect5;
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

