namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class S_FIN_DNEVNIKDataReader : IDisposable
    {
        private ReadWriteCommand cmS_FIN_DNEVNIKSelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Disposed;
        private IDataReader S_FIN_DNEVNIKSelect3;

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
                    this.S_FIN_DNEVNIKSelect3.Close();
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

        public IDataReader Open(int oRG, int mT, int dOK, int bROJDOK, DateTime rAZDOBLJEOD, DateTime rAZDOBLJEDO, string pOCETNIKONTO, string zAVRSNIKONTO, bool sTATUS)
        {
            this.init_reader();

            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmS_FIN_DNEVNIKSelect3 = this.connDefault.GetCommand("S_FIN_DNEVNIK", true);
            this.cmS_FIN_DNEVNIKSelect3.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmS_FIN_DNEVNIKSelect3.IDbCommand.Parameters.Clear();
            this.cmS_FIN_DNEVNIKSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORG", oRG));
            this.cmS_FIN_DNEVNIKSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MT", mT));
            this.cmS_FIN_DNEVNIKSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DOK", dOK));
            this.cmS_FIN_DNEVNIKSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJDOK", bROJDOK));
            this.cmS_FIN_DNEVNIKSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEOD", rAZDOBLJEOD));
            this.cmS_FIN_DNEVNIKSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAZDOBLJEDO", rAZDOBLJEDO));
            this.cmS_FIN_DNEVNIKSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POCETNIKONTO", pOCETNIKONTO));
            this.cmS_FIN_DNEVNIKSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ZAVRSNIKONTO", zAVRSNIKONTO));
            this.cmS_FIN_DNEVNIKSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@STATUS", sTATUS));
            this.cmS_FIN_DNEVNIKSelect3.ErrorMask |= ErrorMask.Lock;
            this.S_FIN_DNEVNIKSelect3 = this.cmS_FIN_DNEVNIKSelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.S_FIN_DNEVNIKSelect3;
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

