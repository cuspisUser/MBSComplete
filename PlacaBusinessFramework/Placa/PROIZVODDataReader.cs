namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class PROIZVODDataReader : IDisposable
    {
        private ReadWriteCommand cmPROIZVODDelete2;
        private ReadWriteCommand cmPROIZVODDelete3;
        private ReadWriteCommand cmPROIZVODSelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader PROIZVODSelect7;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByFINPOREZIDPOREZ(int fINPOREZIDPOREZ)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPROIZVODDelete3 = this.connDefault.GetCommand("DELETE FROM [PROIZVOD]  WHERE [FINPOREZIDPOREZ] = @FINPOREZIDPOREZ", false);
            if (this.cmPROIZVODDelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmPROIZVODDelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
            }
            this.cmPROIZVODDelete3.SetParameter(0, fINPOREZIDPOREZ);
            return this.cmPROIZVODDelete3.ExecuteStmt();
        }

        public int DeleteByIDJEDINICAMJERE(int iDJEDINICAMJERE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPROIZVODDelete2 = this.connDefault.GetCommand("DELETE FROM [PROIZVOD]  WHERE [IDJEDINICAMJERE] = @IDJEDINICAMJERE", false);
            if (this.cmPROIZVODDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmPROIZVODDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
            }
            this.cmPROIZVODDelete2.SetParameter(0, iDJEDINICAMJERE);
            return this.cmPROIZVODDelete2.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.PROIZVODSelect7 != null))
                    {
                        this.m_Closed = true;
                        this.PROIZVODSelect7.Close();
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
            this.cmPROIZVODSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDPROIZVOD], TM1.[NAZIVPROIZVOD], T2.[FINPOREZSTOPA], TM1.[CIJENA], T3.[NAZIVJEDINICAMJERE], TM1.[FINPOREZIDPOREZ], TM1.[IDJEDINICAMJERE] FROM (([PROIZVOD] TM1 WITH (NOLOCK) LEFT JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) LEFT JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE]) ORDER BY TM1.[IDPROIZVOD] ", false);
            this.PROIZVODSelect7 = this.cmPROIZVODSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PROIZVODSelect7;
        }

        public IDataReader OpenByFINPOREZIDPOREZ(int fINPOREZIDPOREZ)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPROIZVODSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDPROIZVOD], TM1.[NAZIVPROIZVOD], T2.[FINPOREZSTOPA], TM1.[CIJENA], T3.[NAZIVJEDINICAMJERE], TM1.[FINPOREZIDPOREZ], TM1.[IDJEDINICAMJERE] FROM (([PROIZVOD] TM1 WITH (NOLOCK) LEFT JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) LEFT JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE]) WHERE TM1.[FINPOREZIDPOREZ] = @FINPOREZIDPOREZ ORDER BY TM1.[IDPROIZVOD] ", false);
            if (this.cmPROIZVODSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmPROIZVODSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@FINPOREZIDPOREZ", DbType.Int32));
            }
            this.cmPROIZVODSelect7.SetParameter(0, fINPOREZIDPOREZ);
            this.PROIZVODSelect7 = this.cmPROIZVODSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PROIZVODSelect7;
        }

        public IDataReader OpenByIDJEDINICAMJERE(int iDJEDINICAMJERE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPROIZVODSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDPROIZVOD], TM1.[NAZIVPROIZVOD], T2.[FINPOREZSTOPA], TM1.[CIJENA], T3.[NAZIVJEDINICAMJERE], TM1.[FINPOREZIDPOREZ], TM1.[IDJEDINICAMJERE] FROM (([PROIZVOD] TM1 WITH (NOLOCK) LEFT JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) LEFT JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE]) WHERE TM1.[IDJEDINICAMJERE] = @IDJEDINICAMJERE ORDER BY TM1.[IDPROIZVOD] ", false);
            if (this.cmPROIZVODSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmPROIZVODSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDJEDINICAMJERE", DbType.Int32));
            }
            this.cmPROIZVODSelect7.SetParameter(0, iDJEDINICAMJERE);
            this.PROIZVODSelect7 = this.cmPROIZVODSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PROIZVODSelect7;
        }

        public IDataReader OpenByIDPROIZVOD(int iDPROIZVOD)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmPROIZVODSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDPROIZVOD], TM1.[NAZIVPROIZVOD], T2.[FINPOREZSTOPA], TM1.[CIJENA], T3.[NAZIVJEDINICAMJERE], TM1.[FINPOREZIDPOREZ], TM1.[IDJEDINICAMJERE] FROM (([PROIZVOD] TM1 WITH (NOLOCK) LEFT JOIN [FINPOREZ] T2 WITH (NOLOCK) ON T2.[FINPOREZIDPOREZ] = TM1.[FINPOREZIDPOREZ]) LEFT JOIN [JEDINICAMJERE] T3 WITH (NOLOCK) ON T3.[IDJEDINICAMJERE] = TM1.[IDJEDINICAMJERE]) WHERE TM1.[IDPROIZVOD] = @IDPROIZVOD ORDER BY TM1.[IDPROIZVOD] ", false);
            if (this.cmPROIZVODSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmPROIZVODSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDPROIZVOD", DbType.Int32));
            }
            this.cmPROIZVODSelect7.SetParameter(0, iDPROIZVOD);
            this.PROIZVODSelect7 = this.cmPROIZVODSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.PROIZVODSelect7;
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

