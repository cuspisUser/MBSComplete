namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class DDRADNIKDataReader : IDisposable
    {
        private ReadWriteCommand cmDDRADNIKDelete2;
        private ReadWriteCommand cmDDRADNIKDelete3;
        private ReadWriteCommand cmDDRADNIKDelete4;
        private ReadWriteCommand cmDDRADNIKSelect8;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DDRADNIKSelect8;
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

        public int DeleteByIDBANKE(int iDBANKE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDRADNIKDelete4 = this.connDefault.GetCommand("DELETE FROM [DDRADNIK]  WHERE [IDBANKE] = @IDBANKE", false);
            if (this.cmDDRADNIKDelete4.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDRADNIKDelete4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            this.cmDDRADNIKDelete4.SetParameter(0, iDBANKE);
            return this.cmDDRADNIKDelete4.ExecuteStmt();
        }

        public int DeleteByOPCINARADAIDOPCINE(string oPCINARADAIDOPCINE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDRADNIKDelete2 = this.connDefault.GetCommand("DELETE FROM [DDRADNIK]  WHERE [OPCINARADAIDOPCINE] = @OPCINARADAIDOPCINE", false);
            if (this.cmDDRADNIKDelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDRADNIKDelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
            }
            this.cmDDRADNIKDelete2.SetParameter(0, oPCINARADAIDOPCINE);
            return this.cmDDRADNIKDelete2.ExecuteStmt();
        }

        public int DeleteByOPCINASTANOVANJAIDOPCINE(string oPCINASTANOVANJAIDOPCINE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDRADNIKDelete3 = this.connDefault.GetCommand("DELETE FROM [DDRADNIK]  WHERE [OPCINASTANOVANJAIDOPCINE] = @OPCINASTANOVANJAIDOPCINE", false);
            if (this.cmDDRADNIKDelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDRADNIKDelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
            }
            this.cmDDRADNIKDelete3.SetParameter(0, oPCINASTANOVANJAIDOPCINE);
            return this.cmDDRADNIKDelete3.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.DDRADNIKSelect8 != null))
                    {
                        this.m_Closed = true;
                        this.DDRADNIKSelect8.Close();
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
            this.cmDDRADNIKSelect8 = this.connDefault.GetCommand("SELECT TM1.[DDIDRADNIK], TM1.[DDDRUGISTUP], TM1.[DDPDVOBVEZNIK], TM1.[DDZBIRNINETO], TM1.[DDJMBG], TM1.[DDOIB], TM1.[DDPREZIME], TM1.[DDIME], TM1.[DDADRESA], TM1.[DDKUCNIBROJ], TM1.[DDMJESTO], TM1.[DDZRN], T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], T3.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T4.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T4.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T4.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T4.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, TM1.[DDSIFRAOPISAPLACANJANETO], TM1.[DDOPISPLACANJANETO], TM1.[DDMO], TM1.[DDPBO], TM1.[IDBANKE], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE FROM ((([DDRADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) ORDER BY TM1.[DDIDRADNIK] ", false);
            this.DDRADNIKSelect8 = this.cmDDRADNIKSelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DDRADNIKSelect8;
        }

        public IDataReader OpenByDDIDRADNIK(int dDIDRADNIK)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDRADNIKSelect8 = this.connDefault.GetCommand("SELECT TM1.[DDIDRADNIK], TM1.[DDDRUGISTUP], TM1.[DDPDVOBVEZNIK], TM1.[DDZBIRNINETO], TM1.[DDJMBG], TM1.[DDOIB], TM1.[DDPREZIME], TM1.[DDIME], TM1.[DDADRESA], TM1.[DDKUCNIBROJ], TM1.[DDMJESTO], TM1.[DDZRN], T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], T3.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T4.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T4.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T4.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T4.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, TM1.[DDSIFRAOPISAPLACANJANETO], TM1.[DDOPISPLACANJANETO], TM1.[DDMO], TM1.[DDPBO], TM1.[IDBANKE], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE FROM ((([DDRADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) WHERE TM1.[DDIDRADNIK] = @DDIDRADNIK ORDER BY TM1.[DDIDRADNIK] ", false);
            if (this.cmDDRADNIKSelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDRADNIKSelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DDIDRADNIK", DbType.Int32));
            }
            this.cmDDRADNIKSelect8.SetParameter(0, dDIDRADNIK);
            this.DDRADNIKSelect8 = this.cmDDRADNIKSelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DDRADNIKSelect8;
        }

        public IDataReader OpenByIDBANKE(int iDBANKE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDRADNIKSelect8 = this.connDefault.GetCommand("SELECT TM1.[DDIDRADNIK], TM1.[DDDRUGISTUP], TM1.[DDPDVOBVEZNIK], TM1.[DDZBIRNINETO], TM1.[DDJMBG], TM1.[DDOIB], TM1.[DDPREZIME], TM1.[DDIME], TM1.[DDADRESA], TM1.[DDKUCNIBROJ], TM1.[DDMJESTO], TM1.[DDZRN], T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], T3.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T4.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T4.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T4.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T4.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, TM1.[DDSIFRAOPISAPLACANJANETO], TM1.[DDOPISPLACANJANETO], TM1.[DDMO], TM1.[DDPBO], TM1.[IDBANKE], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE FROM ((([DDRADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) WHERE TM1.[IDBANKE] = @IDBANKE ORDER BY TM1.[DDIDRADNIK] ", false);
            if (this.cmDDRADNIKSelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDRADNIKSelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDBANKE", DbType.Int32));
            }
            this.cmDDRADNIKSelect8.SetParameter(0, iDBANKE);
            this.DDRADNIKSelect8 = this.cmDDRADNIKSelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DDRADNIKSelect8;
        }

        public IDataReader OpenByOPCINARADAIDOPCINE(string oPCINARADAIDOPCINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDRADNIKSelect8 = this.connDefault.GetCommand("SELECT TM1.[DDIDRADNIK], TM1.[DDDRUGISTUP], TM1.[DDPDVOBVEZNIK], TM1.[DDZBIRNINETO], TM1.[DDJMBG], TM1.[DDOIB], TM1.[DDPREZIME], TM1.[DDIME], TM1.[DDADRESA], TM1.[DDKUCNIBROJ], TM1.[DDMJESTO], TM1.[DDZRN], T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], T3.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T4.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T4.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T4.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T4.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, TM1.[DDSIFRAOPISAPLACANJANETO], TM1.[DDOPISPLACANJANETO], TM1.[DDMO], TM1.[DDPBO], TM1.[IDBANKE], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE FROM ((([DDRADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) WHERE TM1.[OPCINARADAIDOPCINE] = @OPCINARADAIDOPCINE ORDER BY TM1.[DDIDRADNIK] ", false);
            if (this.cmDDRADNIKSelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDRADNIKSelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINARADAIDOPCINE", DbType.String, 4));
            }
            this.cmDDRADNIKSelect8.SetParameter(0, oPCINARADAIDOPCINE);
            this.DDRADNIKSelect8 = this.cmDDRADNIKSelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DDRADNIKSelect8;
        }

        public IDataReader OpenByOPCINASTANOVANJAIDOPCINE(string oPCINASTANOVANJAIDOPCINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDRADNIKSelect8 = this.connDefault.GetCommand("SELECT TM1.[DDIDRADNIK], TM1.[DDDRUGISTUP], TM1.[DDPDVOBVEZNIK], TM1.[DDZBIRNINETO], TM1.[DDJMBG], TM1.[DDOIB], TM1.[DDPREZIME], TM1.[DDIME], TM1.[DDADRESA], TM1.[DDKUCNIBROJ], TM1.[DDMJESTO], TM1.[DDZRN], T2.[NAZIVBANKE1], T2.[NAZIVBANKE2], T2.[NAZIVBANKE3], T2.[VBDIBANKE], T2.[ZRNBANKE], T3.[NAZIVOPCINE] AS OPCINARADANAZIVOPCINE, T4.[NAZIVOPCINE] AS OPCINASTANOVANJANAZIVOPCINE, T4.[PRIREZ] AS OPCINASTANOVANJAPRIREZ, T4.[VBDIOPCINA] AS OPCINASTANOVANJAVBDIOPCINA, T4.[ZRNOPCINA] AS OPCINASTANOVANJAZRNOPCINA, TM1.[DDSIFRAOPISAPLACANJANETO], TM1.[DDOPISPLACANJANETO], TM1.[DDMO], TM1.[DDPBO], TM1.[IDBANKE], TM1.[OPCINARADAIDOPCINE] AS OPCINARADAIDOPCINE, TM1.[OPCINASTANOVANJAIDOPCINE] AS OPCINASTANOVANJAIDOPCINE FROM ((([DDRADNIK] TM1 WITH (NOLOCK) LEFT JOIN [BANKE] T2 WITH (NOLOCK) ON T2.[IDBANKE] = TM1.[IDBANKE]) LEFT JOIN [OPCINA] T3 WITH (NOLOCK) ON T3.[IDOPCINE] = TM1.[OPCINARADAIDOPCINE]) LEFT JOIN [OPCINA] T4 WITH (NOLOCK) ON T4.[IDOPCINE] = TM1.[OPCINASTANOVANJAIDOPCINE]) WHERE TM1.[OPCINASTANOVANJAIDOPCINE] = @OPCINASTANOVANJAIDOPCINE ORDER BY TM1.[DDIDRADNIK] ", false);
            if (this.cmDDRADNIKSelect8.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDRADNIKSelect8.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPCINASTANOVANJAIDOPCINE", DbType.String, 4));
            }
            this.cmDDRADNIKSelect8.SetParameter(0, oPCINASTANOVANJAIDOPCINE);
            this.DDRADNIKSelect8 = this.cmDDRADNIKSelect8.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.DDRADNIKSelect8;
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

