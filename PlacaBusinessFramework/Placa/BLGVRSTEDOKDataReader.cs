﻿namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class BLGVRSTEDOKDataReader : IDisposable
    {
        private IDataReader BLGVRSTEDOKSelect5;
        private ReadWriteCommand cmBLGVRSTEDOKSelect5;
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

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.BLGVRSTEDOKSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.BLGVRSTEDOKSelect5.Close();
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
            this.cmBLGVRSTEDOKSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDBLGVRSTEDOK], TM1.[NAZIVVRSTEDOK] FROM [BLGVRSTEDOK] TM1 WITH (NOLOCK) ORDER BY TM1.[IDBLGVRSTEDOK] ", false);
            this.BLGVRSTEDOKSelect5 = this.cmBLGVRSTEDOKSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.BLGVRSTEDOKSelect5;
        }

        public IDataReader OpenByIDBLGVRSTEDOK(int iDBLGVRSTEDOK)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmBLGVRSTEDOKSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDBLGVRSTEDOK], TM1.[NAZIVVRSTEDOK] FROM [BLGVRSTEDOK] TM1 WITH (NOLOCK) WHERE TM1.[IDBLGVRSTEDOK] = @IDBLGVRSTEDOK ORDER BY TM1.[IDBLGVRSTEDOK] ", false);
            if (this.cmBLGVRSTEDOKSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmBLGVRSTEDOKSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBLGVRSTEDOK", DbType.Int32));
            }
            this.cmBLGVRSTEDOKSelect5.SetParameter(0, iDBLGVRSTEDOK);
            this.BLGVRSTEDOKSelect5 = this.cmBLGVRSTEDOKSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.BLGVRSTEDOKSelect5;
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

