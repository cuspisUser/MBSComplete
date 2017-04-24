namespace Placa
{
    using Deklarit.Data;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Data;
    using System.Threading;

    public class URADataReader : IDisposable
    {
        private ReadWriteCommand cmURADelete2;
        private ReadWriteCommand cmURADelete3;
        private ReadWriteCommand cmURADelete4;
        private ReadWriteCommand cmURADelete5;
        private ReadWriteCommand cmURADelete6;
        private ReadWriteCommand cmURASelect10;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private bool m_Closed;
        private bool m_Disposed;
        private IDataReader URASelect10;

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        public void Close()
        {
            this.Dispose();
        }

        public int DeleteByIDTIPURA(int iDTIPURA)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURADelete4 = this.connDefault.GetCommand("DELETE FROM [URA]  WHERE [IDTIPURA] = @IDTIPURA", false);
            if (this.cmURADelete4.IDbCommand.Parameters.Count == 0)
            {
                this.cmURADelete4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPURA", DbType.Int32));
            }
            this.cmURADelete4.SetParameter(0, iDTIPURA);
            return this.cmURADelete4.ExecuteStmt();
        }

        public int DeleteByURADOKIDDOKUMENT(int uRADOKIDDOKUMENT)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURADelete6 = this.connDefault.GetCommand("DELETE FROM [URA]  WHERE [URADOKIDDOKUMENT] = @URADOKIDDOKUMENT", false);
            if (this.cmURADelete6.IDbCommand.Parameters.Count == 0)
            {
                this.cmURADelete6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmURADelete6.SetParameter(0, uRADOKIDDOKUMENT);
            return this.cmURADelete6.ExecuteStmt();
        }

        public int DeleteByURAGODIDGODINE(short uRAGODIDGODINE)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURADelete3 = this.connDefault.GetCommand("DELETE FROM [URA]  WHERE [URAGODIDGODINE] = @URAGODIDGODINE", false);
            if (this.cmURADelete3.IDbCommand.Parameters.Count == 0)
            {
                this.cmURADelete3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
            }
            this.cmURADelete3.SetParameter(0, uRAGODIDGODINE);
            return this.cmURADelete3.ExecuteStmt();
        }

        public int DeleteByURAGODIDGODINEURADOKIDDOKUMENT(short uRAGODIDGODINE, int uRADOKIDDOKUMENT)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURADelete2 = this.connDefault.GetCommand("DELETE FROM [URA]  WHERE [URAGODIDGODINE] = @URAGODIDGODINE and [URADOKIDDOKUMENT] = @URADOKIDDOKUMENT", false);
            if (this.cmURADelete2.IDbCommand.Parameters.Count == 0)
            {
                this.cmURADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
                this.cmURADelete2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmURADelete2.SetParameter(0, uRAGODIDGODINE);
            this.cmURADelete2.SetParameter(1, uRADOKIDDOKUMENT);
            return this.cmURADelete2.ExecuteStmt();
        }

        public int DeleteByurapartnerIDPARTNER(int urapartnerIDPARTNER)
        {
            this.init_reader();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURADelete5 = this.connDefault.GetCommand("DELETE FROM [URA]  WHERE [urapartnerIDPARTNER] = @urapartnerIDPARTNER", false);
            if (this.cmURADelete5.IDbCommand.Parameters.Count == 0)
            {
                this.cmURADelete5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@urapartnerIDPARTNER", DbType.Int32));
            }
            this.cmURADelete5.SetParameter(0, urapartnerIDPARTNER);
            return this.cmURADelete5.ExecuteStmt();
        }

        public void Dispose()
        {
            if (!this.m_Disposed)
            {
                this.m_Disposed = true;
                try
                {
                    if (!this.m_Closed && (this.URASelect10 != null))
                    {
                        this.m_Closed = true;
                        this.URASelect10.Close();
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
            this.cmURASelect10 = this.connDefault.GetCommand("SELECT TM1.[URABROJ], TM1.[OSNOVICA25], TM1.[OSNOVICA25NE],TM1.[OSNOVICA23], TM1.[OSNOVICA23NE], TM1.[OSNOVICA22], TM1.[OSNOVICA22NE], TM1.[OSNOVICA10], TM1.[OSNOVICA10NE], TM1.[OSNOVICA0], TM1.[PDV25DA], TM1.[PDV25NE], TM1.[PDV23DA], TM1.[PDV23NE], TM1.[PDV22DA], TM1.[PDV22NE], TM1.[PDV10DA], TM1.[PDV10NE], TM1.[R2], TM1.[URABROJRACUNADOBAVLJACA], TM1.[URADATUM], TM1.[URAVALUTA], TM1.[URANAPOMENA], TM1.[URAMODEL], TM1.[URAPOZIVNABROJ], TM1.[URAUKUPNO], TM1.[IDTIPURA], TM1.[URAGODIDGODINE] AS URAGODIDGODINE, TM1.[URADOKIDDOKUMENT] AS URADOKIDDOKUMENT, TM1.[urapartnerIDPARTNER] AS urapartnerIDPARTNER FROM [URA] TM1 WITH (NOLOCK) ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ", false);
            this.URASelect10 = this.cmURASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.URASelect10;
        }

        public IDataReader OpenByIDTIPURA(int iDTIPURA)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURASelect10 = this.connDefault.GetCommand("SELECT TM1.[URABROJ], TM1.[OSNOVICA24], TM1.[OSNOVICA25NE], TM1.[OSNOVICA23], TM1.[OSNOVICA23NE], TM1.[OSNOVICA22], TM1.[OSNOVICA22NE], TM1.[OSNOVICA10], TM1.[OSNOVICA10NE], TM1.[OSNOVICA0], TM1.[PDV25DA], TM1.[PDV25NE], TM1.[PDV23DA], TM1.[PDV23NE], TM1.[PDV22DA], TM1.[PDV22NE], TM1.[PDV10DA], TM1.[PDV10NE], TM1.[R2], TM1.[URABROJRACUNADOBAVLJACA], TM1.[URADATUM], TM1.[URAVALUTA], TM1.[URANAPOMENA], TM1.[URAMODEL], TM1.[URAPOZIVNABROJ], TM1.[URAUKUPNO], TM1.[IDTIPURA], TM1.[URAGODIDGODINE] AS URAGODIDGODINE, TM1.[URADOKIDDOKUMENT] AS URADOKIDDOKUMENT, TM1.[urapartnerIDPARTNER] AS urapartnerIDPARTNER FROM [URA] TM1 WITH (NOLOCK) WHERE TM1.[IDTIPURA] = @IDTIPURA ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ", false);
            if (this.cmURASelect10.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPURA", DbType.Int32));
            }
            this.cmURASelect10.SetParameter(0, iDTIPURA);
            this.URASelect10 = this.cmURASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.URASelect10;
        }

        public IDataReader OpenByURADOKIDDOKUMENT(int uRADOKIDDOKUMENT)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURASelect10 = this.connDefault.GetCommand("SELECT TM1.[URABROJ], TM1.[OSNOVICA25], TM1.[OSNOVICA25NE], TM1.[OSNOVICA23], TM1.[OSNOVICA23NE], TM1.[OSNOVICA22], TM1.[OSNOVICA22NE], TM1.[OSNOVICA10], TM1.[OSNOVICA10NE], TM1.[OSNOVICA0], TM1.[PDV25DA], TM1.[PDV25NE], TM1.[PDV23DA], TM1.[PDV23NE], TM1.[PDV22DA], TM1.[PDV22NE], TM1.[PDV10DA], TM1.[PDV10NE], TM1.[R2], TM1.[URABROJRACUNADOBAVLJACA], TM1.[URADATUM], TM1.[URAVALUTA], TM1.[URANAPOMENA], TM1.[URAMODEL], TM1.[URAPOZIVNABROJ], TM1.[URAUKUPNO], TM1.[IDTIPURA], TM1.[URAGODIDGODINE] AS URAGODIDGODINE, TM1.[URADOKIDDOKUMENT] AS URADOKIDDOKUMENT, TM1.[urapartnerIDPARTNER] AS urapartnerIDPARTNER FROM [URA] TM1 WITH (NOLOCK) WHERE TM1.[URADOKIDDOKUMENT] = @URADOKIDDOKUMENT ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ", false);
            if (this.cmURASelect10.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmURASelect10.SetParameter(0, uRADOKIDDOKUMENT);
            this.URASelect10 = this.cmURASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.URASelect10;
        }

        public IDataReader OpenByURAGODIDGODINE(short uRAGODIDGODINE)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURASelect10 = this.connDefault.GetCommand("SELECT TM1.[URABROJ], TM1.[OSNOVICA25], TM1.[OSNOVICA25NE], TM1.[OSNOVICA23], TM1.[OSNOVICA23NE], TM1.[OSNOVICA22], TM1.[OSNOVICA22NE], TM1.[OSNOVICA10], TM1.[OSNOVICA10NE], TM1.[OSNOVICA0], TM1.[PDV25DA], TM1.[PDV25NE], TM1.[PDV23DA], TM1.[PDV23NE], TM1.[PDV22DA], TM1.[PDV22NE], TM1.[PDV10DA], TM1.[PDV10NE], TM1.[R2], TM1.[URABROJRACUNADOBAVLJACA], TM1.[URADATUM], TM1.[URAVALUTA], TM1.[URANAPOMENA], TM1.[URAMODEL], TM1.[URAPOZIVNABROJ], TM1.[URAUKUPNO], TM1.[IDTIPURA], TM1.[URAGODIDGODINE] AS URAGODIDGODINE, TM1.[URADOKIDDOKUMENT] AS URADOKIDDOKUMENT, TM1.[urapartnerIDPARTNER] AS urapartnerIDPARTNER FROM [URA] TM1 WITH (NOLOCK) WHERE TM1.[URAGODIDGODINE] = @URAGODIDGODINE ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ", false);
            if (this.cmURASelect10.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
            }
            this.cmURASelect10.SetParameter(0, uRAGODIDGODINE);
            this.URASelect10 = this.cmURASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.URASelect10;
        }

        public IDataReader OpenByURAGODIDGODINEURADOKIDDOKUMENT(short uRAGODIDGODINE, int uRADOKIDDOKUMENT)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURASelect10 = this.connDefault.GetCommand("SELECT TM1.[URABROJ], TM1.[OSNOVICA25], TM1.[OSNOVICA25NE], TM1.[OSNOVICA23], TM1.[OSNOVICA23NE], TM1.[OSNOVICA22], TM1.[OSNOVICA22NE], TM1.[OSNOVICA10], TM1.[OSNOVICA10NE], TM1.[OSNOVICA0], TM1.[PDV25DA], TM1.[PDV25NE], TM1.[PDV23DA], TM1.[PDV23NE], TM1.[PDV22DA], TM1.[PDV22NE], TM1.[PDV10DA], TM1.[PDV10NE], TM1.[R2], TM1.[URABROJRACUNADOBAVLJACA], TM1.[URADATUM], TM1.[URAVALUTA], TM1.[URANAPOMENA], TM1.[URAMODEL], TM1.[URAPOZIVNABROJ], TM1.[URAUKUPNO], TM1.[IDTIPURA], TM1.[URAGODIDGODINE] AS URAGODIDGODINE, TM1.[URADOKIDDOKUMENT] AS URADOKIDDOKUMENT, TM1.[urapartnerIDPARTNER] AS urapartnerIDPARTNER FROM [URA] TM1 WITH (NOLOCK) WHERE TM1.[URAGODIDGODINE] = @URAGODIDGODINE and TM1.[URADOKIDDOKUMENT] = @URADOKIDDOKUMENT ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ", false);
            if (this.cmURASelect10.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
                this.cmURASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
            }
            this.cmURASelect10.SetParameter(0, uRAGODIDGODINE);
            this.cmURASelect10.SetParameter(1, uRADOKIDDOKUMENT);
            this.URASelect10 = this.cmURASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.URASelect10;
        }

        public IDataReader OpenByURAGODIDGODINEURADOKIDDOKUMENTURABROJ(short uRAGODIDGODINE, int uRADOKIDDOKUMENT, int uRABROJ)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURASelect10 = this.connDefault.GetCommand("SELECT TM1.[URABROJ], TM1.[OSNOVICA25], TM1.[OSNOVICA25NE], TM1.[OSNOVICA23], TM1.[OSNOVICA23NE], TM1.[OSNOVICA22], TM1.[OSNOVICA22NE], TM1.[OSNOVICA10], TM1.[OSNOVICA10NE], TM1.[OSNOVICA0], TM1.[PDV25DA], TM1.[PDV25sNE], TM1.[PDV23DA], TM1.[PDV23NE], TM1.[PDV22DA], TM1.[PDV22NE], TM1.[PDV10DA], TM1.[PDV10NE], TM1.[R2], TM1.[URABROJRACUNADOBAVLJACA], TM1.[URADATUM], TM1.[URAVALUTA], TM1.[URANAPOMENA], TM1.[URAMODEL], TM1.[URAPOZIVNABROJ], TM1.[URAUKUPNO], TM1.[IDTIPURA], TM1.[URAGODIDGODINE] AS URAGODIDGODINE, TM1.[URADOKIDDOKUMENT] AS URADOKIDDOKUMENT, TM1.[urapartnerIDPARTNER] AS urapartnerIDPARTNER FROM [URA] TM1 WITH (NOLOCK) WHERE TM1.[URAGODIDGODINE] = @URAGODIDGODINE and TM1.[URADOKIDDOKUMENT] = @URADOKIDDOKUMENT and TM1.[URABROJ] = @URABROJ ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ", false);
            if (this.cmURASelect10.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URAGODIDGODINE", DbType.Int16));
                this.cmURASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URADOKIDDOKUMENT", DbType.Int32));
                this.cmURASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@URABROJ", DbType.Int32));
            }
            this.cmURASelect10.SetParameter(0, uRAGODIDGODINE);
            this.cmURASelect10.SetParameter(1, uRADOKIDDOKUMENT);
            this.cmURASelect10.SetParameter(2, uRABROJ);
            this.URASelect10 = this.cmURASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.URASelect10;
        }

        public IDataReader OpenByurapartnerIDPARTNER(int urapartnerIDPARTNER)
        {
            this.init_reader();
            this.m_Closed = false;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmURASelect10 = this.connDefault.GetCommand("SELECT TM1.[URABROJ], TM1.[OSNOVICA25], TM1.[OSNOVICA25NE], TM1.[OSNOVICA23], TM1.[OSNOVICA23NE], TM1.[OSNOVICA22], TM1.[OSNOVICA22NE], TM1.[OSNOVICA10], TM1.[OSNOVICA10NE], TM1.[OSNOVICA0], TM1.[PDV25DA], TM1.[PDV25NE], TM1.[PDV23DA], TM1.[PDV23NE], TM1.[PDV22DA], TM1.[PDV22NE], TM1.[PDV10DA], TM1.[PDV10NE], TM1.[R2], TM1.[URABROJRACUNADOBAVLJACA], TM1.[URADATUM], TM1.[URAVALUTA], TM1.[URANAPOMENA], TM1.[URAMODEL], TM1.[URAPOZIVNABROJ], TM1.[URAUKUPNO], TM1.[IDTIPURA], TM1.[URAGODIDGODINE] AS URAGODIDGODINE, TM1.[URADOKIDDOKUMENT] AS URADOKIDDOKUMENT, TM1.[urapartnerIDPARTNER] AS urapartnerIDPARTNER FROM [URA] TM1 WITH (NOLOCK) WHERE TM1.[urapartnerIDPARTNER] = @urapartnerIDPARTNER ORDER BY TM1.[URAGODIDGODINE], TM1.[URADOKIDDOKUMENT], TM1.[URABROJ] ", false);
            if (this.cmURASelect10.IDbCommand.Parameters.Count == 0)
            {
                this.cmURASelect10.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@urapartnerIDPARTNER", DbType.Int32));
            }
            this.cmURASelect10.SetParameter(0, urapartnerIDPARTNER);
            this.URASelect10 = this.cmURASelect10.ExecuteReader((CommandBehavior) Conversions.ToInteger(Interaction.IIf(this.daCurrentTransaction == null, Configuration.ReaderCommandBehavior, CommandBehavior.Default)));
            return this.URASelect10;
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

