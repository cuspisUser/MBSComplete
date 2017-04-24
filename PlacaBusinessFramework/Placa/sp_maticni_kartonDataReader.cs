namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class sp_maticni_kartonDataReader : IDisposable
    {
        private ReadWriteCommand cmsp_maticni_kartonSelect3;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Disposed;
        private IDataReader sp_maticni_kartonSelect3;

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
                    this.sp_maticni_kartonSelect3.Close();
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

        public IDataReader Open(string godina, int idradnik_od, int idradnik_do, bool zbirni, bool ukljucenobruto, bool ukljucenodoprinosiiz, bool ukljucenodoprinosina, bool ukljucenoporezi, bool ukljucenooo, bool ukljucenoobustave, bool ukljucenoolaksice, bool ukljucenonetoplaca, bool ukljucenonetonaknade, bool ukljucenoisplata)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmsp_maticni_kartonSelect3 = this.connDefault.GetCommand("S_PLACA_MATICNI_KARTON_ZAPOSLENIKA_ILI_USTANOVE", true);
            this.cmsp_maticni_kartonSelect3.IDbCommand.CommandType = CommandType.StoredProcedure;
            this.cmsp_maticni_kartonSelect3.IDbCommand.Parameters.Clear();
            this.cmsp_maticni_kartonSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@godina", godina));
            this.cmsp_maticni_kartonSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idradnik_od", idradnik_od));
            this.cmsp_maticni_kartonSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@idradnik_do", idradnik_do));
            this.cmsp_maticni_kartonSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@zbirni", zbirni));
            this.cmsp_maticni_kartonSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenobruto", ukljucenobruto));
            this.cmsp_maticni_kartonSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenodoprinosiiz", ukljucenodoprinosiiz));
            this.cmsp_maticni_kartonSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenodoprinosina", ukljucenodoprinosina));
            this.cmsp_maticni_kartonSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenoporezi", ukljucenoporezi));
            this.cmsp_maticni_kartonSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenooo", ukljucenooo));
            this.cmsp_maticni_kartonSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenoobustave", ukljucenoobustave));
            this.cmsp_maticni_kartonSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenoolaksice", ukljucenoolaksice));
            this.cmsp_maticni_kartonSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenonetoplaca", ukljucenonetoplaca));
            this.cmsp_maticni_kartonSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenonetonaknade", ukljucenonetonaknade));
            this.cmsp_maticni_kartonSelect3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ukljucenoisplata", ukljucenoisplata));
            this.cmsp_maticni_kartonSelect3.ErrorMask |= ErrorMask.Lock;
            this.sp_maticni_kartonSelect3 = this.cmsp_maticni_kartonSelect3.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.sp_maticni_kartonSelect3;
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

