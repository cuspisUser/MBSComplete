namespace Placa
{
    using Deklarit;
    using Deklarit.Data;
    using Deklarit.Utils;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Threading;

    public class VIRMANIDataAdapter : IDataAdapter, IVIRMANIDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmVIRMANISelect1;
        private ReadWriteCommand cmVIRMANISelect2;
        private ReadWriteCommand cmVIRMANISelect5;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__BROJRACUNAPLAOriginal;
        private object m__BROJRACUNAPRIOriginal;
        private object m__DATUMPODNOSENJAOriginal;
        private object m__DATUMVALUTEOriginal;
        private object m__IZNOSOriginal;
        private object m__IZVORDOKUMENTAOriginal;
        private object m__MODELODOBRENJAOriginal;
        private object m__MODELZADUZENJAOriginal;
        private object m__NAMJENAOriginal;
        private object m__OPISPLACANJAVIRMANOriginal;
        private object m__OZNACENOriginal;
        private object m__PLA1Original;
        private object m__PLA2Original;
        private object m__PLA3Original;
        private object m__POZIVODOBRENJAOriginal;
        private object m__POZIVZADUZENJAOriginal;
        private object m__PRI1Original;
        private object m__PRI2Original;
        private object m__PRI3Original;
        private object m__SIFRAOBRACUNAVIRMANOriginal;
        private object m__SIFRAOPISAPLACANJAVIRMANOriginal;
        private object m__HUB3_SIFRANAMJENEOriginal;
        private object m__HUB3_HITNOOriginal;
        //
        private object m__OpisPlacanjaOriginal;
        private object m__RoditeljOriginal;
        private object m__RoditeljAdresaOriginal;
        private object m__OpisProizvodaOriginal;
        private object m__CijenaOriginal;
        private object m__KolicinaOriginal;


        private readonly string m_SelectString40 = "TM1.[IDVIRMAN], TM1.[SIFRAOBRACUNAVIRMAN], TM1.[PLA1], TM1.[PLA2], TM1.[PLA3], TM1.[BROJRACUNAPLA], TM1.[MODELZADUZENJA], TM1.[POZIVZADUZENJA], " + 
                                                   "TM1.[PRI1], TM1.[PRI2], TM1.[PRI3], TM1.[BROJRACUNAPRI], TM1.[MODELODOBRENJA], TM1.[POZIVODOBRENJA], TM1.[SIFRAOPISAPLACANJAVIRMAN], " + 
                                                   "TM1.[OPISPLACANJAVIRMAN], TM1.[DATUMVALUTE], TM1.[DATUMPODNOSENJA], TM1.[IZVORDOKUMENTA], TM1.[OZNACEN], TM1.[IZNOS], TM1.[NAMJENA], " +
                                                   "TM1.[HUB3_SIFRANAMJENE], TM1.[HUB3_HITNO], TM1.[OpisPlacanja], TM1.[Roditelj], TM1.[RoditeljAdresa], TM1.[OpisProizvoda], " +
                                                   "TM1.[Cijena], TM1.[Kolicina]";
        private string m_WhereString;
        private short RcdFound40;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private VIRMANIDataSet.VIRMANIRow rowVIRMANI;
        private string scmdbuf;
        private StatementType sMode40;
        private IDataReader VIRMANISelect1;
        private IDataReader VIRMANISelect2;
        private IDataReader VIRMANISelect5;
        private VIRMANIDataSet VIRMANISet;

        public event VIRMANIUpdateEventHandler VIRMANIUpdated;

        public event VIRMANIUpdateEventHandler VIRMANIUpdating;

        private void AddRowVirmani()
        {
            this.VIRMANISet.VIRMANI.AddVIRMANIRow(this.rowVIRMANI);
        }

        private void AfterConfirmVirmani()
        {
            this.OnVIRMANIUpdating(new VIRMANIEventArgs(this.rowVIRMANI, this.Gx_mode));
        }

        private void CheckOptimisticConcurrencyVirmani()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDVIRMAN], [SIFRAOBRACUNAVIRMAN], [PLA1], [PLA2], [PLA3], [BROJRACUNAPLA], [MODELZADUZENJA], [POZIVZADUZENJA], [PRI1], " + 
                                                                       "[PRI2], [PRI3], [BROJRACUNAPRI], [MODELODOBRENJA], [POZIVODOBRENJA], [SIFRAOPISAPLACANJAVIRMAN], [OPISPLACANJAVIRMAN], [DATUMVALUTE], " +
                                                                       "[DATUMPODNOSENJA], [IZVORDOKUMENTA], [OZNACEN], [IZNOS], [NAMJENA], [HUB3_SIFRANAMJENE], [HUB3_HITNO], [OpisPlacanja], [Roditelj], " +
                                                                       "[RoditeljAdresa], [OpisProizvoda], [Cijena], [Kolicina] " + 
                                                                       "FROM [VIRMANI] WITH (UPDLOCK) WHERE [IDVIRMAN] = @IDVIRMAN ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVIRMAN", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["IDVIRMAN"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new VIRMANIDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("VIRMANI") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowVirmani()
        {
            this.rowVIRMANI = this.VIRMANISet.VIRMANI.NewVIRMANIRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyVirmani();
            this.AfterConfirmVirmani();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [VIRMANI]  WHERE [IDVIRMAN] = @IDVIRMAN", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVIRMAN", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["IDVIRMAN"]));
            command.ExecuteStmt();
            this.OnVIRMANIUpdated(new VIRMANIEventArgs(this.rowVIRMANI, StatementType.Delete));
            this.rowVIRMANI.Delete();
            this.sMode40 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode40;
        }

        public virtual int Fill(VIRMANIDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, int.Parse(this.fillDataParameters[0].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.VIRMANISet = dataSet;
                    this.LoadChildVirmani(0, -1);
                    dataSet.AcceptChanges();
                }
                finally
                {
                    this.Cleanup();
                }
            }
            return 0;
        }

        public virtual int Fill(DataSet dataSet)
        {
            this.VIRMANISet = (VIRMANIDataSet) dataSet;
            if (this.VIRMANISet != null)
            {
                return this.Fill(this.VIRMANISet);
            }
            this.VIRMANISet = new VIRMANIDataSet();
            this.Fill(this.VIRMANISet);
            dataSet.Merge(this.VIRMANISet);
            return 0;
        }

        public virtual int Fill(VIRMANIDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDVIRMAN"]));
        }

        public virtual int Fill(VIRMANIDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDVIRMAN"]));
        }

        public virtual int Fill(VIRMANIDataSet dataSet, int iDVIRMAN)
        {
            if (!this.FillByIDVIRMAN(dataSet, iDVIRMAN))
            {
                throw new VIRMANINotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VIRMANI") }));
            }
            return 0;
        }

        public virtual bool FillByIDVIRMAN(VIRMANIDataSet dataSet, int iDVIRMAN)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VIRMANISet = dataSet;
            this.rowVIRMANI = this.VIRMANISet.VIRMANI.NewVIRMANIRow();
            this.rowVIRMANI.IDVIRMAN = iDVIRMAN;
            try
            {
                this.LoadByIDVIRMAN(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound40 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillBySIFRAOBRACUNAVIRMAN(VIRMANIDataSet dataSet, string sIFRAOBRACUNAVIRMAN)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VIRMANISet = dataSet;
            this.rowVIRMANI = this.VIRMANISet.VIRMANI.NewVIRMANIRow();
            this.rowVIRMANI.SIFRAOBRACUNAVIRMAN = sIFRAOBRACUNAVIRMAN;
            try
            {
                this.LoadBySIFRAOBRACUNAVIRMAN(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPage(VIRMANIDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VIRMANISet = dataSet;
            try
            {
                this.LoadChildVirmani(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual int FillPageBySIFRAOBRACUNAVIRMAN(VIRMANIDataSet dataSet, string sIFRAOBRACUNAVIRMAN, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VIRMANISet = dataSet;
            this.rowVIRMANI = this.VIRMANISet.VIRMANI.NewVIRMANIRow();
            this.rowVIRMANI.SIFRAOBRACUNAVIRMAN = sIFRAOBRACUNAVIRMAN;
            try
            {
                this.LoadBySIFRAOBRACUNAVIRMAN(startRow, maxRows);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        public virtual DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
        {
            DataTable[] array = new DataTable[dataSet.Tables.Count + 1];
            dataSet.Tables.CopyTo(array, dataSet.Tables.Count);
            return array;
        }

        private void GetByPrimaryKey()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDVIRMAN], [SIFRAOBRACUNAVIRMAN], [PLA1], [PLA2], [PLA3], [BROJRACUNAPLA], [MODELZADUZENJA], [POZIVZADUZENJA], [PRI1], [PRI2], " + 
                                                                   "[PRI3], [BROJRACUNAPRI], [MODELODOBRENJA], [POZIVODOBRENJA], [SIFRAOPISAPLACANJAVIRMAN], [OPISPLACANJAVIRMAN], [DATUMVALUTE], " +
                                                                   "[DATUMPODNOSENJA], [IZVORDOKUMENTA], [OZNACEN], [IZNOS], [NAMJENA], [HUB3_SIFRANAMJENE], [HUB3_HITNO], [OpisPlacanja], [Roditelj], " +
                                                                   "[RoditeljAdresa], [OpisProizvoda], [Cijena], [Kolicina] " + 
                                                                   "FROM [VIRMANI] WITH (NOLOCK) WHERE [IDVIRMAN] = @IDVIRMAN ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVIRMAN", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["IDVIRMAN"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound40 = 1;
                this.rowVIRMANI["IDVIRMAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowVIRMANI["SIFRAOBRACUNAVIRMAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowVIRMANI["PLA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 2));
                this.rowVIRMANI["PLA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 3));
                this.rowVIRMANI["PLA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 4));
                this.rowVIRMANI["BROJRACUNAPLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 5));
                this.rowVIRMANI["MODELZADUZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 6));
                this.rowVIRMANI["POZIVZADUZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 7));
                this.rowVIRMANI["PRI1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 8));
                this.rowVIRMANI["PRI2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 9));
                this.rowVIRMANI["PRI3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 10));
                this.rowVIRMANI["BROJRACUNAPRI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 11));
                this.rowVIRMANI["MODELODOBRENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 12));
                this.rowVIRMANI["POZIVODOBRENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 13));
                this.rowVIRMANI["SIFRAOPISAPLACANJAVIRMAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 14));
                this.rowVIRMANI["OPISPLACANJAVIRMAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 15));
                this.rowVIRMANI["DATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 0x10));
                this.rowVIRMANI["DATUMPODNOSENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(reader, 0x11));
                this.rowVIRMANI["IZVORDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 0x12));
                this.rowVIRMANI["OZNACEN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 0x13));
                this.rowVIRMANI["IZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 20));
                this.rowVIRMANI["NAMJENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 21));
                this.rowVIRMANI["HUB3_SIFRANAMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 22));
                this.rowVIRMANI["HUB3_HITNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 23));
                this.rowVIRMANI["OpisPlacanja"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 24));
                this.rowVIRMANI["Roditelj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 25));
                this.rowVIRMANI["RoditeljAdresa"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 26));
                this.rowVIRMANI["OpisProizvoda"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 27));
                this.rowVIRMANI["Cijena"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 28));
                this.rowVIRMANI["Kolicina"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 29));
                this.sMode40 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode40;
            }
            else
            {
                this.RcdFound40 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDVIRMAN";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmVIRMANISelect2 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [VIRMANI] WITH (NOLOCK) ", false);
            this.VIRMANISelect2 = this.cmVIRMANISelect2.FetchData();
            if (this.VIRMANISelect2.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.VIRMANISelect2.GetInt32(0);
            }
            this.VIRMANISelect2.Close();
            return this.recordCount;
        }

        private int GetInternalRecordCountBySIFRAOBRACUNAVIRMAN(string sIFRAOBRACUNAVIRMAN)
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmVIRMANISelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [VIRMANI] WITH (NOLOCK) WHERE [SIFRAOBRACUNAVIRMAN] = @SIFRAOBRACUNAVIRMAN ", false);
            if (this.cmVIRMANISelect1.IDbCommand.Parameters.Count == 0)
            {
                this.cmVIRMANISelect1.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOBRACUNAVIRMAN", DbType.String, 11));
            }
            this.cmVIRMANISelect1.SetParameter(0, sIFRAOBRACUNAVIRMAN);
            this.VIRMANISelect1 = this.cmVIRMANISelect1.FetchData();
            if (this.VIRMANISelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.VIRMANISelect1.GetInt32(0);
            }
            this.VIRMANISelect1.Close();
            return this.recordCount;
        }

        public virtual int GetRecordCount()
        {
            int internalRecordCount;
            try
            {
                this.InitializeMembers();
                internalRecordCount = this.GetInternalRecordCount();
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCount;
        }

        public virtual int GetRecordCountBySIFRAOBRACUNAVIRMAN(string sIFRAOBRACUNAVIRMAN)
        {
            int internalRecordCountBySIFRAOBRACUNAVIRMAN;
            try
            {
                this.InitializeMembers();
                internalRecordCountBySIFRAOBRACUNAVIRMAN = this.GetInternalRecordCountBySIFRAOBRACUNAVIRMAN(sIFRAOBRACUNAVIRMAN);
            }
            finally
            {
                this.Cleanup();
            }
            return internalRecordCountBySIFRAOBRACUNAVIRMAN;
        }

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound40 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__SIFRAOBRACUNAVIRMANOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PLA1Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PLA2Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PLA3Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__BROJRACUNAPLAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MODELZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POZIVZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRI1Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRI2Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__PRI3Original = RuntimeHelpers.GetObjectValue(new object());
            this.m__BROJRACUNAPRIOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__MODELODOBRENJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__POZIVODOBRENJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__SIFRAOPISAPLACANJAVIRMANOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OPISPLACANJAVIRMANOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DATUMVALUTEOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__DATUMPODNOSENJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IZVORDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OZNACENOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__IZNOSOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__NAMJENAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__HUB3_SIFRANAMJENEOriginal= RuntimeHelpers.GetObjectValue(new object());
            this.m__HUB3_HITNOOriginal = RuntimeHelpers.GetObjectValue(new object());

            this.m__OpisPlacanjaOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RoditeljOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__RoditeljAdresaOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__OpisProizvodaOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__CijenaOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__KolicinaOriginal = RuntimeHelpers.GetObjectValue(new object());

            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.VIRMANISet = new VIRMANIDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertVirmani()
        {
            this.CheckOptimisticConcurrencyVirmani();
            this.AfterConfirmVirmani();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [VIRMANI] ([SIFRAOBRACUNAVIRMAN], [PLA1], [PLA2], [PLA3], [BROJRACUNAPLA], [MODELZADUZENJA], [POZIVZADUZENJA], [PRI1], [PRI2], " + 
                                                                   "[PRI3], [BROJRACUNAPRI], [MODELODOBRENJA], [POZIVODOBRENJA], [SIFRAOPISAPLACANJAVIRMAN], [OPISPLACANJAVIRMAN], [DATUMVALUTE], " +
                                                                   "[DATUMPODNOSENJA], [IZVORDOKUMENTA], [OZNACEN], [IZNOS], [NAMJENA], [HUB3_SIFRANAMJENE], [HUB3_HITNO], [OpisPlacanja], [Roditelj], " +
                                                                   "[RoditeljAdresa], [OpisProizvoda], [Cijena], [Kolicina]) " + 
                                                                   "VALUES (@SIFRAOBRACUNAVIRMAN, @PLA1, @PLA2, @PLA3, @BROJRACUNAPLA, @MODELZADUZENJA, @POZIVZADUZENJA, @PRI1, @PRI2, @PRI3, @BROJRACUNAPRI, " + 
                                                                   "@MODELODOBRENJA, @POZIVODOBRENJA, @SIFRAOPISAPLACANJAVIRMAN, @OPISPLACANJAVIRMAN, @DATUMVALUTE, @DATUMPODNOSENJA, @IZVORDOKUMENTA, @OZNACEN, " +
                                                                   "@IZNOS, @NAMJENA, @HUB3_SIFRANAMJENE, @HUB3_HITNO, @OpisPlacanja, @Roditelj, @RoditeljAdresa, @OpisProizvoda, @Cijena, @Kolicina); " + 
                                                                   "SELECT SCOPE_IDENTITY()", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOBRACUNAVIRMAN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLA1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLA2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLA3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJRACUNAPLA", DbType.String, 0x12));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MODELZADUZENJA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POZIVZADUZENJA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRI1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRI2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRI3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJRACUNAPRI", DbType.String, 0x12));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MODELODOBRENJA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POZIVODOBRENJA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAVIRMAN", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAVIRMAN", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMVALUTE", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMPODNOSENJA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZVORDOKUMENTA", DbType.String, 3));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OZNACEN", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAMJENA", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@HUB3_SIFRANAMJENE", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@HUB3_HITNO", DbType.Boolean));

                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OpisPlacanja", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@Roditelj", DbType.String, 40));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RoditeljAdresa", DbType.String, 80));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OpisProizvoda", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@Cijena", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@Kolicina", DbType.Currency));

            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["SIFRAOBRACUNAVIRMAN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PLA1"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PLA2"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PLA3"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["BROJRACUNAPLA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["MODELZADUZENJA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["POZIVZADUZENJA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PRI1"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PRI2"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PRI3"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["BROJRACUNAPRI"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["MODELODOBRENJA"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["POZIVODOBRENJA"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["SIFRAOPISAPLACANJAVIRMAN"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OPISPLACANJAVIRMAN"]));
            command.SetParameterDateObject(15, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["DATUMVALUTE"]));
            command.SetParameterDateObject(0x10, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["DATUMPODNOSENJA"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["IZVORDOKUMENTA"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OZNACEN"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["IZNOS"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["NAMJENA"]));
            command.SetParameter(21, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["HUB3_SIFRANAMJENE"]));
            command.SetParameter(22, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["HUB3_HITNO"]));

            command.SetParameter(23, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OpisPlacanja"]));
            command.SetParameter(24, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["Roditelj"]));
            command.SetParameter(25, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["RoditeljAdresa"]));
            command.SetParameter(26, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OpisProizvoda"]));
            command.SetParameter(27, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["Cijena"]));
            command.SetParameter(28, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["Kolicina"]));

            IDataReader reader = command.FetchData();
            this.rowVIRMANI.IDVIRMAN = Convert.ToInt32(reader.GetDecimal(0));
            reader.Close();
            this.OnVIRMANIUpdated(new VIRMANIEventArgs(this.rowVIRMANI, StatementType.Insert));
        }

        private void LoadByIDVIRMAN(int startRow, int maxRows)
        {
            bool enforceConstraints = this.VIRMANISet.EnforceConstraints;
            this.VIRMANISet.VIRMANI.BeginLoadData();
            this.ScanByIDVIRMAN(startRow, maxRows);
            this.VIRMANISet.VIRMANI.EndLoadData();
            this.VIRMANISet.EnforceConstraints = enforceConstraints;
            if (this.VIRMANISet.VIRMANI.Count > 0)
            {
                this.rowVIRMANI = this.VIRMANISet.VIRMANI[this.VIRMANISet.VIRMANI.Count - 1];
            }
        }

        private void LoadBySIFRAOBRACUNAVIRMAN(int startRow, int maxRows)
        {
            bool enforceConstraints = this.VIRMANISet.EnforceConstraints;
            this.VIRMANISet.VIRMANI.BeginLoadData();
            this.ScanBySIFRAOBRACUNAVIRMAN(startRow, maxRows);
            this.VIRMANISet.VIRMANI.EndLoadData();
            this.VIRMANISet.EnforceConstraints = enforceConstraints;
            if (this.VIRMANISet.VIRMANI.Count > 0)
            {
                this.rowVIRMANI = this.VIRMANISet.VIRMANI[this.VIRMANISet.VIRMANI.Count - 1];
            }
        }

        private void LoadChildVirmani(int startRow, int maxRows)
        {
            this.CreateNewRowVirmani();
            bool enforceConstraints = this.VIRMANISet.EnforceConstraints;
            this.VIRMANISet.VIRMANI.BeginLoadData();
            this.ScanStartVirmani(startRow, maxRows);
            this.VIRMANISet.VIRMANI.EndLoadData();
            this.VIRMANISet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataVirmani(int maxRows)
        {
            int num = 0;
            if (this.RcdFound40 != 0)
            {
                this.ScanLoadVirmani();
                while ((this.RcdFound40 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowVirmani();
                    this.CreateNewRowVirmani();
                    this.ScanNextVirmani();
                }
            }
            if (num > 0)
            {
                this.RcdFound40 = 1;
            }
            this.ScanEndVirmani();
            if (this.VIRMANISet.VIRMANI.Count > 0)
            {
                this.rowVIRMANI = this.VIRMANISet.VIRMANI[this.VIRMANISet.VIRMANI.Count - 1];
            }
        }

        private void LoadRowVirmani()
        {
            this.AddRowVirmani();
        }

        private void OnVIRMANIUpdated(VIRMANIEventArgs e)
        {
            if (this.VIRMANIUpdated != null)
            {
                VIRMANIUpdateEventHandler vIRMANIUpdatedEvent = this.VIRMANIUpdated;
                if (vIRMANIUpdatedEvent != null)
                {
                    vIRMANIUpdatedEvent(this, e);
                }
            }
        }

        private void OnVIRMANIUpdating(VIRMANIEventArgs e)
        {
            if (this.VIRMANIUpdating != null)
            {
                VIRMANIUpdateEventHandler vIRMANIUpdatingEvent = this.VIRMANIUpdating;
                if (vIRMANIUpdatingEvent != null)
                {
                    vIRMANIUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowVirmani()
        {
            this.Gx_mode = Mode.FromRowState(this.rowVIRMANI.RowState);
            if (this.rowVIRMANI.RowState != DataRowState.Deleted)
            {
                this.rowVIRMANI["DATUMVALUTE"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowVIRMANI["DATUMVALUTE"])));
                this.rowVIRMANI["DATUMPODNOSENJA"] = RuntimeHelpers.GetObjectValue(DateTimeUtil.ResetTimeObject(RuntimeHelpers.GetObjectValue(this.rowVIRMANI["DATUMPODNOSENJA"])));
            }
            if (this.rowVIRMANI.RowState != DataRowState.Added)
            {
                this.m__SIFRAOBRACUNAVIRMANOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["SIFRAOBRACUNAVIRMAN", DataRowVersion.Original]);
                this.m__PLA1Original = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PLA1", DataRowVersion.Original]);
                this.m__PLA2Original = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PLA2", DataRowVersion.Original]);
                this.m__PLA3Original = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PLA3", DataRowVersion.Original]);
                this.m__BROJRACUNAPLAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["BROJRACUNAPLA", DataRowVersion.Original]);
                this.m__MODELZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["MODELZADUZENJA", DataRowVersion.Original]);
                this.m__POZIVZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["POZIVZADUZENJA", DataRowVersion.Original]);
                this.m__PRI1Original = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PRI1", DataRowVersion.Original]);
                this.m__PRI2Original = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PRI2", DataRowVersion.Original]);
                this.m__PRI3Original = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PRI3", DataRowVersion.Original]);
                this.m__BROJRACUNAPRIOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["BROJRACUNAPRI", DataRowVersion.Original]);
                this.m__MODELODOBRENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["MODELODOBRENJA", DataRowVersion.Original]);
                this.m__POZIVODOBRENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["POZIVODOBRENJA", DataRowVersion.Original]);
                this.m__SIFRAOPISAPLACANJAVIRMANOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["SIFRAOPISAPLACANJAVIRMAN", DataRowVersion.Original]);
                this.m__OPISPLACANJAVIRMANOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OPISPLACANJAVIRMAN", DataRowVersion.Original]);
                this.m__DATUMVALUTEOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["DATUMVALUTE", DataRowVersion.Original]);
                this.m__DATUMPODNOSENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["DATUMPODNOSENJA", DataRowVersion.Original]);
                this.m__IZVORDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["IZVORDOKUMENTA", DataRowVersion.Original]);
                this.m__OZNACENOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OZNACEN", DataRowVersion.Original]);
                this.m__IZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["IZNOS", DataRowVersion.Original]);
                this.m__NAMJENAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["NAMJENA", DataRowVersion.Original]);
                this.m__HUB3_SIFRANAMJENEOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["HUB3_SIFRANAMJENE", DataRowVersion.Original]);
                this.m__HUB3_HITNOOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["HUB3_HITNO", DataRowVersion.Original]);

                this.m__OpisPlacanjaOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OpisPlacanja", DataRowVersion.Original]);
                this.m__RoditeljOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["Roditelj", DataRowVersion.Original]);
                this.m__RoditeljAdresaOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["RoditeljAdresa", DataRowVersion.Original]);
                this.m__OpisProizvodaOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OpisProizvoda", DataRowVersion.Original]);
                this.m__CijenaOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["Cijena", DataRowVersion.Original]);
                this.m__KolicinaOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["Kolicina", DataRowVersion.Original]);
            }
            else
            {
                this.m__SIFRAOBRACUNAVIRMANOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["SIFRAOBRACUNAVIRMAN"]);
                this.m__PLA1Original = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PLA1"]);
                this.m__PLA2Original = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PLA2"]);
                this.m__PLA3Original = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PLA3"]);
                this.m__BROJRACUNAPLAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["BROJRACUNAPLA"]);
                this.m__MODELZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["MODELZADUZENJA"]);
                this.m__POZIVZADUZENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["POZIVZADUZENJA"]);
                this.m__PRI1Original = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PRI1"]);
                this.m__PRI2Original = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PRI2"]);
                this.m__PRI3Original = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PRI3"]);
                this.m__BROJRACUNAPRIOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["BROJRACUNAPRI"]);
                this.m__MODELODOBRENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["MODELODOBRENJA"]);
                this.m__POZIVODOBRENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["POZIVODOBRENJA"]);
                this.m__SIFRAOPISAPLACANJAVIRMANOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["SIFRAOPISAPLACANJAVIRMAN"]);
                this.m__OPISPLACANJAVIRMANOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OPISPLACANJAVIRMAN"]);
                this.m__DATUMVALUTEOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["DATUMVALUTE"]);
                this.m__DATUMPODNOSENJAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["DATUMPODNOSENJA"]);
                this.m__IZVORDOKUMENTAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["IZVORDOKUMENTA"]);
                this.m__OZNACENOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OZNACEN"]);
                this.m__IZNOSOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["IZNOS"]);
                this.m__NAMJENAOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["NAMJENA"]);
                this.m__HUB3_SIFRANAMJENEOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["HUB3_SIFRANAMJENE"]);
                this.m__HUB3_HITNOOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["HUB3_HITNO"]);

                this.m__OpisPlacanjaOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OpisPlacanja"]);
                this.m__RoditeljOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["Roditelj"]);
                this.m__RoditeljAdresaOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["RoditeljAdresa"]);
                this.m__OpisProizvodaOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OpisProizvoda"]);
                this.m__CijenaOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["Cijena"]);
                this.m__KolicinaOriginal = RuntimeHelpers.GetObjectValue(this.rowVIRMANI["Kolicina"]);
            }
            this._Gxremove = this.rowVIRMANI.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowVIRMANI = (VIRMANIDataSet.VIRMANIRow) DataSetUtil.CloneOriginalDataRow(this.rowVIRMANI);
            }
        }

        private void ScanByIDVIRMAN(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDVIRMAN] = @IDVIRMAN";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString40 + "  FROM [VIRMANI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVIRMAN]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString40, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDVIRMAN] ) AS DK_PAGENUM   FROM [VIRMANI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString40 + " FROM [VIRMANI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVIRMAN] ";
            }
            this.cmVIRMANISelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmVIRMANISelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmVIRMANISelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVIRMAN", DbType.Int32));
            }
            this.cmVIRMANISelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["IDVIRMAN"]));
            this.VIRMANISelect5 = this.cmVIRMANISelect5.FetchData();
            this.RcdFound40 = 0;
            this.ScanLoadVirmani();
            this.LoadDataVirmani(maxRows);
        }

        private void ScanBySIFRAOBRACUNAVIRMAN(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[SIFRAOBRACUNAVIRMAN] = @SIFRAOBRACUNAVIRMAN";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString40 + "  FROM [VIRMANI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVIRMAN]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString40, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDVIRMAN] ) AS DK_PAGENUM   FROM [VIRMANI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString40 + " FROM [VIRMANI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVIRMAN] ";
            }
            this.cmVIRMANISelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmVIRMANISelect5.IDbCommand.Parameters.Count == 0)
            {
                this.cmVIRMANISelect5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOBRACUNAVIRMAN", DbType.String, 11));
            }
            this.cmVIRMANISelect5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["SIFRAOBRACUNAVIRMAN"]));
            this.VIRMANISelect5 = this.cmVIRMANISelect5.FetchData();
            this.RcdFound40 = 0;
            this.ScanLoadVirmani();
            this.LoadDataVirmani(maxRows);
        }

        private void ScanEndVirmani()
        {
            this.VIRMANISelect5.Close();
        }

        private void ScanLoadVirmani()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmVIRMANISelect5.HasMoreRows)
            {
                this.RcdFound40 = 1;
                this.rowVIRMANI["IDVIRMAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.VIRMANISelect5, 0));
                this.rowVIRMANI["SIFRAOBRACUNAVIRMAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 1));
                this.rowVIRMANI["PLA1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 2));
                this.rowVIRMANI["PLA2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 3));
                this.rowVIRMANI["PLA3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 4));
                this.rowVIRMANI["BROJRACUNAPLA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 5));
                this.rowVIRMANI["MODELZADUZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 6));
                this.rowVIRMANI["POZIVZADUZENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 7));
                this.rowVIRMANI["PRI1"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 8));
                this.rowVIRMANI["PRI2"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 9));
                this.rowVIRMANI["PRI3"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 10));
                this.rowVIRMANI["BROJRACUNAPRI"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 11));
                this.rowVIRMANI["MODELODOBRENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 12));
                this.rowVIRMANI["POZIVODOBRENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 13));
                this.rowVIRMANI["SIFRAOPISAPLACANJAVIRMAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 14));
                this.rowVIRMANI["OPISPLACANJAVIRMAN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 15));
                this.rowVIRMANI["DATUMVALUTE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.VIRMANISelect5, 0x10));
                this.rowVIRMANI["DATUMPODNOSENJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDateTime(this.VIRMANISelect5, 0x11));
                this.rowVIRMANI["IZVORDOKUMENTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 0x12));
                this.rowVIRMANI["OZNACEN"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.VIRMANISelect5, 0x13));
                this.rowVIRMANI["IZNOS"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.VIRMANISelect5, 20));
                this.rowVIRMANI["NAMJENA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 21));
                this.rowVIRMANI["HUB3_SIFRANAMJENE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 22));
                this.rowVIRMANI["HUB3_HITNO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.VIRMANISelect5, 23));

                this.rowVIRMANI["OpisPlacanja"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 24));
                this.rowVIRMANI["Roditelj"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 25));
                this.rowVIRMANI["RoditeljAdresa"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 26));
                this.rowVIRMANI["OpisProizvoda"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VIRMANISelect5, 27));
                this.rowVIRMANI["Cijena"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.VIRMANISelect5, 28));
                this.rowVIRMANI["Kolicina"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.VIRMANISelect5, 29));
            }
        }

        private void ScanNextVirmani()
        {
            this.cmVIRMANISelect5.HasMoreRows = this.VIRMANISelect5.Read();
            this.RcdFound40 = 0;
            this.ScanLoadVirmani();
        }

        private void ScanStartVirmani(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString40 + "  FROM [VIRMANI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVIRMAN]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString40, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDVIRMAN] ) AS DK_PAGENUM   FROM [VIRMANI] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString40 + " FROM [VIRMANI] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVIRMAN] ";
            }
            this.cmVIRMANISelect5 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.VIRMANISelect5 = this.cmVIRMANISelect5.FetchData();
            this.RcdFound40 = 0;
            this.ScanLoadVirmani();
            this.LoadDataVirmani(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.VIRMANISet = (VIRMANIDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.VIRMANISet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.VIRMANISet.VIRMANI.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        VIRMANIDataSet.VIRMANIRow current = (VIRMANIDataSet.VIRMANIRow) enumerator.Current;
                        this.rowVIRMANI = current;
                        if (Helpers.IsRowChanged(this.rowVIRMANI))
                        {
                            this.ReadRowVirmani();
                            if (this.rowVIRMANI.RowState == DataRowState.Added)
                            {
                                this.InsertVirmani();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateVirmani();
                            }
                        }
                    }
                }
                finally
                {
                    if (enumerator is IDisposable)
                    {
                        (enumerator as IDisposable).Dispose();
                    }
                }
                dataSet.AcceptChanges();
                this.connDefault.Commit();
            }
            catch (System.Exception exception1)
            {
                throw exception1;
                
                //this.connDefault.Rollback();
                
            }
            finally
            {
                this.Cleanup();
            }
            return 0;
        }

        private void UpdateVirmani()
        {
            this.CheckOptimisticConcurrencyVirmani();
            this.AfterConfirmVirmani();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [VIRMANI] SET [SIFRAOBRACUNAVIRMAN]=@SIFRAOBRACUNAVIRMAN, [PLA1]=@PLA1, [PLA2]=@PLA2, [PLA3]=@PLA3, " + 
                                                                   "[BROJRACUNAPLA]=@BROJRACUNAPLA, [MODELZADUZENJA]=@MODELZADUZENJA, [POZIVZADUZENJA]=@POZIVZADUZENJA, [PRI1]=@PRI1, " + 
                                                                   "[PRI2]=@PRI2, [PRI3]=@PRI3, [BROJRACUNAPRI]=@BROJRACUNAPRI, [MODELODOBRENJA]=@MODELODOBRENJA, [POZIVODOBRENJA]=@POZIVODOBRENJA, " + 
                                                                   "[SIFRAOPISAPLACANJAVIRMAN]=@SIFRAOPISAPLACANJAVIRMAN, [OPISPLACANJAVIRMAN]=@OPISPLACANJAVIRMAN, [DATUMVALUTE]=@DATUMVALUTE, " + 
                                                                   "[DATUMPODNOSENJA]=@DATUMPODNOSENJA, [IZVORDOKUMENTA]=@IZVORDOKUMENTA, [OZNACEN]=@OZNACEN, [IZNOS]=@IZNOS, [NAMJENA]=@NAMJENA, " +
                                                                   "[HUB3_SIFRANAMJENE]=@HUB3_SIFRANAMJENE, [HUB3_HITNO]=@HUB3_HITNO, [OpisPlacanja]=@OpisPlacanja, [Roditelj]=@Roditelj, " +
                                                                   "[RoditeljAdresa]=@RoditeljAdresa, [OpisProizvoda]=@OpisProizvoda, [Cijena]=@Cijena, [Kolicina]=@Kolicina " + 
                                                                   "WHERE [IDVIRMAN] = @IDVIRMAN", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOBRACUNAVIRMAN", DbType.String, 11));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLA1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLA2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PLA3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJRACUNAPLA", DbType.String, 0x12));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MODELZADUZENJA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POZIVZADUZENJA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRI1", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRI2", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@PRI3", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@BROJRACUNAPRI", DbType.String, 0x12));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@MODELODOBRENJA", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@POZIVODOBRENJA", DbType.String, 0x16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@SIFRAOPISAPLACANJAVIRMAN", DbType.String, 2));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISPLACANJAVIRMAN", DbType.String, 0x24));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMVALUTE", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@DATUMPODNOSENJA", DbType.Date));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZVORDOKUMENTA", DbType.String, 3));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OZNACEN", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IZNOS", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAMJENA", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVIRMAN", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@HUB3_SIFRANAMJENE", DbType.String, 4));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@HUB3_HITNO", DbType.Boolean));

                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OpisPlacanja", DbType.String, 150));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@Roditelj", DbType.String, 40));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RoditeljAdresa", DbType.String, 80));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OpisProizvoda", DbType.String, 100));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@Cijena", DbType.Currency));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@Kolicina", DbType.Currency));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["SIFRAOBRACUNAVIRMAN"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PLA1"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PLA2"]));
            command.SetParameter(3, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PLA3"]));
            command.SetParameter(4, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["BROJRACUNAPLA"]));
            command.SetParameter(5, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["MODELZADUZENJA"]));
            command.SetParameter(6, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["POZIVZADUZENJA"]));
            command.SetParameter(7, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PRI1"]));
            command.SetParameter(8, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PRI2"]));
            command.SetParameter(9, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["PRI3"]));
            command.SetParameter(10, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["BROJRACUNAPRI"]));
            command.SetParameter(11, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["MODELODOBRENJA"]));
            command.SetParameter(12, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["POZIVODOBRENJA"]));
            command.SetParameter(13, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["SIFRAOPISAPLACANJAVIRMAN"]));
            command.SetParameter(14, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OPISPLACANJAVIRMAN"]));
            command.SetParameterDateObject(15, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["DATUMVALUTE"]));
            command.SetParameterDateObject(0x10, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["DATUMPODNOSENJA"]));
            command.SetParameter(0x11, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["IZVORDOKUMENTA"]));
            command.SetParameter(0x12, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OZNACEN"]));
            command.SetParameter(0x13, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["IZNOS"]));
            command.SetParameter(20, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["NAMJENA"]));
            command.SetParameter(21, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["IDVIRMAN"]));
            command.SetParameter(22, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["HUB3_SIFRANAMJENE"]));
            command.SetParameter(23, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["HUB3_HITNO"]));

            command.SetParameter(24, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OpisPlacanja"]));
            command.SetParameter(25, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["Roditelj"]));
            command.SetParameter(26, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["RoditeljAdresa"]));
            command.SetParameter(27, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["OpisProizvoda"]));
            command.SetParameter(28, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["Cijena"]));
            command.SetParameter(29, RuntimeHelpers.GetObjectValue(this.rowVIRMANI["Kolicina"]));

            command.ExecuteStmt();
            this.OnVIRMANIUpdated(new VIRMANIEventArgs(this.rowVIRMANI, StatementType.Update));
        }

        public System.Data.MissingMappingAction MissingMappingAction
        {
            get
            {
                return System.Data.MissingMappingAction.Passthrough;
            }
            set
            {
            }
        }

        System.Data.MissingSchemaAction MissingSchemaAction
        {
            get
            {
                return System.Data.MissingSchemaAction.Ignore;
            }
            set
            {
            }
        }

        System.Data.MissingMappingAction System.Data.IDataAdapter.MissingMappingAction
        {
            get
            {
                return System.Data.MissingMappingAction.Passthrough;
            }
            set
            {
            }
        }

        System.Data.MissingSchemaAction System.Data.IDataAdapter.MissingSchemaAction
        {
            get
            {
                return System.Data.MissingSchemaAction.Ignore;
            }
            set
            {
            }
        }

        ITableMappingCollection System.Data.IDataAdapter.TableMappings
        {
            get
            {
                return new DataTableMappingCollection();
            }
        }

        ITableMappingCollection TableMappings
        {
            get
            {
                return new DataTableMappingCollection();
            }
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

        [Serializable]
        public class VIRMANIDataChangedException : DataChangedException
        {
            public VIRMANIDataChangedException()
            {
            }

            public VIRMANIDataChangedException(string message) : base(message)
            {
            }

            protected VIRMANIDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VIRMANIDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VIRMANIDataLockedException : DataLockedException
        {
            public VIRMANIDataLockedException()
            {
            }

            public VIRMANIDataLockedException(string message) : base(message)
            {
            }

            protected VIRMANIDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VIRMANIDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class VIRMANIEventArgs : EventArgs
        {
            private VIRMANIDataSet.VIRMANIRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public VIRMANIEventArgs(VIRMANIDataSet.VIRMANIRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public VIRMANIDataSet.VIRMANIRow Row
            {
                get
                {
                    return this.m_dataRow;
                }
                set
                {
                    this.m_dataRow = value;
                }
            }

            public System.Data.StatementType StatementType
            {
                get
                {
                    return this.m_statementType;
                }
            }
        }

        [Serializable]
        public class VIRMANINotFoundException : DataNotFoundException
        {
            public VIRMANINotFoundException()
            {
            }

            public VIRMANINotFoundException(string message) : base(message)
            {
            }

            protected VIRMANINotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VIRMANINotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void VIRMANIUpdateEventHandler(object sender, VIRMANIDataAdapter.VIRMANIEventArgs e);
    }
}

