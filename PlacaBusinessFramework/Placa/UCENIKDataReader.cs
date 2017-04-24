namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class UCENIKDataReader : IDisposable
    {
        private ReadWriteCommand cmUCENIKDelete2;
        private ReadWriteCommand cmUCENIKSelect6;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader UCENIKSelect6;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByPOSTANSKIBROJ(string pOSTANSKIBROJ)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmUCENIKDelete2 = this.connDefault.GetCommand("DELETE FROM [UCENIK]  WHERE [POSTANSKIBROJ] = @POSTANSKIBROJ", false);
            if (this.cmUCENIKDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmUCENIKDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
            }
            this.cmUCENIKDelete2.SetParameter(0, pOSTANSKIBROJ);
            return this.cmUCENIKDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.UCENIKSelect6 != null))
                    {
                        this.m_Closed = true;
                        this.UCENIKSelect6.Close();
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
            this.cmUCENIKSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDUCENIK], TM1.[PREZIMEUCENIK], TM1.[IMEUCENIK], TM1.[OIBUCENIK], TM1.[RAZRED], TM1.[ODJELJENJE], TM1.[SPOLUCENIKA], TM1.[ULICAIBROJ], TM1.[NASELJE], TM1.[JMBGUCENIKA], TM1.[DATUMRODJENJAUCENIKA], TM1.[IMERODITELJA], T2.[NAZIVPOSTE], TM1.[POSTANSKIBROJ] FROM ([UCENIK] TM1 WITH (NOLOCK) LEFT JOIN [POSTANSKIBROJEVI] T2 WITH (NOLOCK) ON T2.[POSTANSKIBROJ] = TM1.[POSTANSKIBROJ]) ORDER BY TM1.[IDUCENIK] ", false);
            this.UCENIKSelect6 = this.cmUCENIKSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.UCENIKSelect6;
        }

        public IDataReader OpenByIDUCENIK(int iDUCENIK)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmUCENIKSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDUCENIK], TM1.[PREZIMEUCENIK], TM1.[IMEUCENIK], TM1.[OIBUCENIK], TM1.[RAZRED], TM1.[ODJELJENJE], TM1.[SPOLUCENIKA], TM1.[ULICAIBROJ], TM1.[NASELJE], TM1.[JMBGUCENIKA], TM1.[DATUMRODJENJAUCENIKA], TM1.[IMERODITELJA], T2.[NAZIVPOSTE], TM1.[POSTANSKIBROJ] FROM ([UCENIK] TM1 WITH (NOLOCK) LEFT JOIN [POSTANSKIBROJEVI] T2 WITH (NOLOCK) ON T2.[POSTANSKIBROJ] = TM1.[POSTANSKIBROJ]) WHERE TM1.[IDUCENIK] = @IDUCENIK ORDER BY TM1.[IDUCENIK] ", false);
            if (this.cmUCENIKSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmUCENIKSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDUCENIK", DbType.Int32));
            }
            this.cmUCENIKSelect6.SetParameter(0, iDUCENIK);
            this.UCENIKSelect6 = this.cmUCENIKSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.UCENIKSelect6;
        }

        public IDataReader OpenByPOSTANSKIBROJ(string pOSTANSKIBROJ)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmUCENIKSelect6 = this.connDefault.GetCommand("SELECT TM1.[IDUCENIK], TM1.[PREZIMEUCENIK], TM1.[IMEUCENIK], TM1.[OIBUCENIK], TM1.[RAZRED], TM1.[ODJELJENJE], TM1.[SPOLUCENIKA], TM1.[ULICAIBROJ], TM1.[NASELJE], TM1.[JMBGUCENIKA], TM1.[DATUMRODJENJAUCENIKA], TM1.[IMERODITELJA], T2.[NAZIVPOSTE], TM1.[POSTANSKIBROJ] FROM ([UCENIK] TM1 WITH (NOLOCK) LEFT JOIN [POSTANSKIBROJEVI] T2 WITH (NOLOCK) ON T2.[POSTANSKIBROJ] = TM1.[POSTANSKIBROJ]) WHERE TM1.[POSTANSKIBROJ] = @POSTANSKIBROJ ORDER BY TM1.[IDUCENIK] ", false);
            if (this.cmUCENIKSelect6.IDbCommand.Parameters.Count == 0)
            {
                this.cmUCENIKSelect6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POSTANSKIBROJ", DbType.String, 5));
            }
            this.cmUCENIKSelect6.SetParameter(0, pOSTANSKIBROJ);
            this.UCENIKSelect6 = this.cmUCENIKSelect6.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.UCENIKSelect6;
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

