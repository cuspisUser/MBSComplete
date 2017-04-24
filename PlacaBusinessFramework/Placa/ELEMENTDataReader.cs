namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class ELEMENTDataReader : IDisposable
    {
        private ReadWriteCommand cmELEMENTDelete2;
        private ReadWriteCommand cmELEMENTDelete3;
        private ReadWriteCommand cmELEMENTSelect7;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private IDataReader ELEMENTSelect7;
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

        public int DeleteByIDOSNOVAOSIGURANJA(string iDOSNOVAOSIGURANJA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmELEMENTDelete2 = this.connDefault.GetCommand("DELETE FROM [ELEMENT]  WHERE [IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA", false);
            if (this.cmELEMENTDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmELEMENTDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            this.cmELEMENTDelete2.SetParameterString(0, iDOSNOVAOSIGURANJA);
            return this.cmELEMENTDelete2.ExecuteStmt();
        }

        public int DeleteByIDVRSTAELEMENTA(short iDVRSTAELEMENTA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmELEMENTDelete3 = this.connDefault.GetCommand("DELETE FROM [ELEMENT]  WHERE [IDVRSTAELEMENTA] = @IDVRSTAELEMENTA", false);
            if (this.cmELEMENTDelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmELEMENTDelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
            }
            this.cmELEMENTDelete3.SetParameter(0, iDVRSTAELEMENTA);
            return this.cmELEMENTDelete3.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.ELEMENTSelect7 != null))
                    {
                        this.m_Closed = true;
                        this.ELEMENTSelect7.Close();
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
            this.cmELEMENTSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDELEMENT], TM1.[NAZIVELEMENT], T2.[NAZIVVRSTAELEMENT], T3.[NAZIVOSNOVAOSIGURANJA], T3.[RAZDOBLJESESMIJEPREKLAPATI], TM1.[POSTOTAK], TM1.[ZBRAJASATEUFONDSATI], TM1.[MOELEMENT], TM1.[POELEMENT], TM1.[MZELEMENT], TM1.[PZELEMENT], TM1.[SIFRAOPISAPLACANJAELEMENT], TM1.[OPISPLACANJAELEMENT], TM1.[POSTAVLJAMZPZSVIMVIRMANIMA], TM1.[IDVRSTAELEMENTA], TM1.[IDOSNOVAOSIGURANJA] FROM (([ELEMENT] TM1 WITH (NOLOCK) LEFT JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA]) ORDER BY TM1.[IDELEMENT] ", false);
            this.ELEMENTSelect7 = this.cmELEMENTSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.ELEMENTSelect7;
        }

        public IDataReader OpenByIDELEMENT(int iDELEMENT)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmELEMENTSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDELEMENT], TM1.[NAZIVELEMENT], T2.[NAZIVVRSTAELEMENT], T3.[NAZIVOSNOVAOSIGURANJA], T3.[RAZDOBLJESESMIJEPREKLAPATI], TM1.[POSTOTAK], TM1.[ZBRAJASATEUFONDSATI], TM1.[MOELEMENT], TM1.[POELEMENT], TM1.[MZELEMENT], TM1.[PZELEMENT], TM1.[SIFRAOPISAPLACANJAELEMENT], TM1.[OPISPLACANJAELEMENT], TM1.[POSTAVLJAMZPZSVIMVIRMANIMA], TM1.[IDVRSTAELEMENTA], TM1.[IDOSNOVAOSIGURANJA] FROM (([ELEMENT] TM1 WITH (NOLOCK) LEFT JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA]) WHERE TM1.[IDELEMENT] = @IDELEMENT ORDER BY TM1.[IDELEMENT] ", false);
            if (this.cmELEMENTSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmELEMENTSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDELEMENT", DbType.Int32));
            }
            this.cmELEMENTSelect7.SetParameter(0, iDELEMENT);
            this.ELEMENTSelect7 = this.cmELEMENTSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.ELEMENTSelect7;
        }

        public IDataReader OpenByIDOSNOVAOSIGURANJA(string iDOSNOVAOSIGURANJA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmELEMENTSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDELEMENT], TM1.[NAZIVELEMENT], T2.[NAZIVVRSTAELEMENT], T3.[NAZIVOSNOVAOSIGURANJA], T3.[RAZDOBLJESESMIJEPREKLAPATI], TM1.[POSTOTAK], TM1.[ZBRAJASATEUFONDSATI], TM1.[MOELEMENT], TM1.[POELEMENT], TM1.[MZELEMENT], TM1.[PZELEMENT], TM1.[SIFRAOPISAPLACANJAELEMENT], TM1.[OPISPLACANJAELEMENT], TM1.[POSTAVLJAMZPZSVIMVIRMANIMA], TM1.[IDVRSTAELEMENTA], TM1.[IDOSNOVAOSIGURANJA] FROM (([ELEMENT] TM1 WITH (NOLOCK) LEFT JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA]) WHERE TM1.[IDOSNOVAOSIGURANJA] = @IDOSNOVAOSIGURANJA ORDER BY TM1.[IDELEMENT] ", false);
            if (this.cmELEMENTSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmELEMENTSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSNOVAOSIGURANJA", DbType.String, 2));
            }
            this.cmELEMENTSelect7.SetParameterString(0, iDOSNOVAOSIGURANJA);
            this.ELEMENTSelect7 = this.cmELEMENTSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.ELEMENTSelect7;
        }

        public IDataReader OpenByIDVRSTAELEMENTA(short iDVRSTAELEMENTA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmELEMENTSelect7 = this.connDefault.GetCommand("SELECT TM1.[IDELEMENT], TM1.[NAZIVELEMENT], T2.[NAZIVVRSTAELEMENT], T3.[NAZIVOSNOVAOSIGURANJA], T3.[RAZDOBLJESESMIJEPREKLAPATI], TM1.[POSTOTAK], TM1.[ZBRAJASATEUFONDSATI], TM1.[MOELEMENT], TM1.[POELEMENT], TM1.[MZELEMENT], TM1.[PZELEMENT], TM1.[SIFRAOPISAPLACANJAELEMENT], TM1.[OPISPLACANJAELEMENT], TM1.[POSTAVLJAMZPZSVIMVIRMANIMA], TM1.[IDVRSTAELEMENTA], TM1.[IDOSNOVAOSIGURANJA] FROM (([ELEMENT] TM1 WITH (NOLOCK) LEFT JOIN [VRSTAELEMENT] T2 WITH (NOLOCK) ON T2.[IDVRSTAELEMENTA] = TM1.[IDVRSTAELEMENTA]) LEFT JOIN [OSNOVAOSIGURANJA] T3 WITH (NOLOCK) ON T3.[IDOSNOVAOSIGURANJA] = TM1.[IDOSNOVAOSIGURANJA]) WHERE TM1.[IDVRSTAELEMENTA] = @IDVRSTAELEMENTA ORDER BY TM1.[IDELEMENT] ", false);
            if (this.cmELEMENTSelect7.IDbCommand.Parameters.Count == 0)
            {
                this.cmELEMENTSelect7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVRSTAELEMENTA", DbType.Int16));
            }
            this.cmELEMENTSelect7.SetParameter(0, iDVRSTAELEMENTA);
            this.ELEMENTSelect7 = this.cmELEMENTSelect7.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.ELEMENTSelect7;
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

