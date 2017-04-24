namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class sp_id_zaglavljeDataReader : IDisposable
    {
        private ReadWriteCommand cmsp_id_zaglavljeSelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Disposed;
        private IDataReader sp_id_zaglavljeSelect3;

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
                    this.sp_id_zaglavljeSelect3.Close();
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
        }

        private void Initialize()
        {
            this.m_Disposed = false;
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        public IDataReader Open(string iDOBRACUN, string mJESECISPLATE, string gODINAISPLATE, short vOLONTERI)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmsp_id_zaglavljeSelect3 = this.connDefault.GetCommand("S_PLACA_ID", true);
            this.cmsp_id_zaglavljeSelect3.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_id_zaglavljeSelect3.IDbCommand.Parameters.Clear();
            this.cmsp_id_zaglavljeSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmsp_id_zaglavljeSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MJESECISPLATE", mJESECISPLATE));
            this.cmsp_id_zaglavljeSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINAISPLATE", gODINAISPLATE));
            this.cmsp_id_zaglavljeSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VOLONTERI", vOLONTERI));
            this.cmsp_id_zaglavljeSelect3.ErrorMask |= ErrorMask.Lock;
            this.sp_id_zaglavljeSelect3 = this.cmsp_id_zaglavljeSelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.sp_id_zaglavljeSelect3;
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

