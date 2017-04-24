namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class sp_id_detaljiDataReader : IDisposable
    {
        private ReadWriteCommand cmsp_id_detaljiSelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Disposed;
        private IDataReader sp_id_detaljiSelect3;

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
                    this.sp_id_detaljiSelect3.Close();
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

        public IDataReader Open(string idobracun, string mjeseCISPLATE, string godinaISPLATE, short vOLONTERI)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmsp_id_detaljiSelect3 = this.connDefault.GetCommand("S_PLACA_ID_REDOVI", true);
            this.cmsp_id_detaljiSelect3.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_id_detaljiSelect3.IDbCommand.Parameters.Clear();
            this.cmsp_id_detaljiSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idobracun", idobracun));
            this.cmsp_id_detaljiSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mjeseCISPLATE", mjeseCISPLATE));
            this.cmsp_id_detaljiSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godinaISPLATE", godinaISPLATE));
            this.cmsp_id_detaljiSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VOLONTERI", vOLONTERI));
            this.cmsp_id_detaljiSelect3.ErrorMask |= ErrorMask.Lock;
            this.sp_id_detaljiSelect3 = this.cmsp_id_detaljiSelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.sp_id_detaljiSelect3;
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

