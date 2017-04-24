﻿namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class AKTIVNOSTDataReader : IDisposable
    {
        private IDataReader AKTIVNOSTSelect5;
        private ReadWriteCommand cmAKTIVNOSTSelect5;
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
                    if (!this.m_Closed && (this.AKTIVNOSTSelect5 != null))
                    {
                        this.m_Closed = true;
                        this.AKTIVNOSTSelect5.Close();
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
            this.cmAKTIVNOSTSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDAKTIVNOST], TM1.[NAZIVAKTIVNOST] FROM [AKTIVNOST] TM1 WITH (NOLOCK) ORDER BY TM1.[IDAKTIVNOST] ", false);
            this.AKTIVNOSTSelect5 = this.cmAKTIVNOSTSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.AKTIVNOSTSelect5;
        }

        public IDataReader OpenByIDAKTIVNOST(int iDAKTIVNOST)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmAKTIVNOSTSelect5 = this.connDefault.GetCommand("SELECT TM1.[IDAKTIVNOST], TM1.[NAZIVAKTIVNOST] FROM [AKTIVNOST] TM1 WITH (NOLOCK) WHERE TM1.[IDAKTIVNOST] = @IDAKTIVNOST ORDER BY TM1.[IDAKTIVNOST] ", false);
            if (this.cmAKTIVNOSTSelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmAKTIVNOSTSelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDAKTIVNOST", DbType.Int32));
            }
            this.cmAKTIVNOSTSelect5.SetParameter(0, iDAKTIVNOST);
            this.AKTIVNOSTSelect5 = this.cmAKTIVNOSTSelect5.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.AKTIVNOSTSelect5;
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

