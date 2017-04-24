namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class sp_VIRMANIDataReader : IDisposable
    {
        private ReadWriteCommand cmsp_VIRMANISelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Disposed;
        private IDataReader sp_VIRMANISelect3;

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
                    this.sp_VIRMANISelect3.Close();
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

        public IDataReader Open(string iDOBRACUN, string zaduzenje, string poreziprirezodvojeno, string pl1, string pl2, string pl3, string vbd, string zrn, string mb, string dd)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmsp_VIRMANISelect3 = this.connDefault.GetCommand("S_VIRMANI", true);
            this.cmsp_VIRMANISelect3.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_VIRMANISelect3.IDbCommand.Parameters.Clear();
            this.cmsp_VIRMANISelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOBRACUN", iDOBRACUN));
            this.cmsp_VIRMANISelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@zaduzenje", zaduzenje));
            this.cmsp_VIRMANISelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@poreziprirezodvojeno", poreziprirezodvojeno));
            this.cmsp_VIRMANISelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@pl1", pl1));
            this.cmsp_VIRMANISelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@pl2", pl2));
            this.cmsp_VIRMANISelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@pl3", pl3));
            this.cmsp_VIRMANISelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@vbd", vbd));
            this.cmsp_VIRMANISelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@zrn", zrn));
            this.cmsp_VIRMANISelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@mb", mb));
            this.cmsp_VIRMANISelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@dd", dd));
            this.cmsp_VIRMANISelect3.ErrorMask |= ErrorMask.Lock;
            this.sp_VIRMANISelect3 = this.cmsp_VIRMANISelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.sp_VIRMANISelect3;
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

