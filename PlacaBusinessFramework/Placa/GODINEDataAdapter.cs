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

    public class GODINEDataAdapter : IDataAdapter, IGODINEDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmGODINESelect1;
        private ReadWriteCommand cmGODINESelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private IDataReader GODINESelect1;
        private IDataReader GODINESelect4;
        private GODINEDataSet GODINESet;
        private StatementType Gx_mode;
        private object m__GODINEAKTIVNAOriginal;
        private readonly string m_SelectString186 = "TM1.[IDGODINE], TM1.[GODINEAKTIVNA]";
        private string m_WhereString;
        private short RcdFound186;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private GODINEDataSet.GODINERow rowGODINE;
        private string scmdbuf;
        private StatementType sMode186;

        public event GODINEUpdateEventHandler GODINEUpdated;

        public event GODINEUpdateEventHandler GODINEUpdating;

        private void AddRowGodine()
        {
            this.GODINESet.GODINE.AddGODINERow(this.rowGODINE);
        }

        private void AfterConfirmGodine()
        {
            this.OnGODINEUpdating(new GODINEEventArgs(this.rowGODINE, this.Gx_mode));
        }

        private void CheckDeleteErrorsGodine()
        {
            ReadWriteCommand command5 = this.connDefault.GetCommand("SELECT TOP 1 [IDPLAN], [PLANGODINAIDGODINE] FROM [PLAN] WITH (NOLOCK) WHERE [PLANGODINAIDGODINE] = @IDGODINE ", false);
            if (command5.IDbCommand.Parameters.Count == 0)
            {
                command5.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            command5.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGODINE["IDGODINE"]));
            IDataReader reader5 = command5.FetchData();
            if (command5.HasMoreRows)
            {
                reader5.Close();
                throw new PLANInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "PLAN" }));
            }
            reader5.Close();
            ReadWriteCommand command6 = this.connDefault.GetCommand("SELECT TOP 1 [IDRACUN], [RACUNGODINAIDGODINE] FROM [RACUN] WITH (NOLOCK) WHERE [RACUNGODINAIDGODINE] = @IDGODINE ", false);
            if (command6.IDbCommand.Parameters.Count == 0)
            {
                command6.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            command6.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGODINE["IDGODINE"]));
            IDataReader reader6 = command6.FetchData();
            if (command6.HasMoreRows)
            {
                reader6.Close();
                throw new RACUNInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "Raeuni" }));
            }
            reader6.Close();
            ReadWriteCommand command7 = this.connDefault.GetCommand("SELECT TOP 1 [URAGODIDGODINE], [URADOKIDDOKUMENT], [URABROJ] FROM [URA] WITH (NOLOCK) WHERE [URAGODIDGODINE] = @IDGODINE ", false);
            if (command7.IDbCommand.Parameters.Count == 0)
            {
                command7.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            command7.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGODINE["IDGODINE"]));
            IDataReader reader7 = command7.FetchData();
            if (command7.HasMoreRows)
            {
                reader7.Close();
                throw new URAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "URA" }));
            }
            reader7.Close();
            ReadWriteCommand command4 = this.connDefault.GetCommand("SELECT TOP 1 [IRAGODIDGODINE], [IRADOKIDDOKUMENT], [IRABROJ] FROM [IRA] WITH (NOLOCK) WHERE [IRAGODIDGODINE] = @IDGODINE ", false);
            if (command4.IDbCommand.Parameters.Count == 0)
            {
                command4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            command4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGODINE["IDGODINE"]));
            IDataReader reader4 = command4.FetchData();
            if (command4.HasMoreRows)
            {
                reader4.Close();
                throw new IRAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "IRA" }));
            }
            reader4.Close();
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [MJESEC], [IDGODINE], [BROJEVIDENCIJE] FROM [EVIDENCIJA] WITH (NOLOCK) WHERE [IDGODINE] = @IDGODINE ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGODINE["IDGODINE"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new EVIDENCIJAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "EVIDENCIJA" }));
            }
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT TOP 1 [IDGKSTAVKA] FROM [GKSTAVKA] WITH (NOLOCK) WHERE [GKGODIDGODINE] = @IDGODINE ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGODINE["IDGODINE"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                reader3.Close();
                throw new GKSTAVKAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "GKSTAVKA" }));
            }
            reader3.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [BLGDOKIDDOKUMENT], [IDBLGVRSTEDOK], [blggodineIDGODINE], [BLGBROJDOKUMENTA] FROM [BLAGAJNAStavkeBlagajne] WITH (NOLOCK) WHERE [blggodineIDGODINE] = @IDGODINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGODINE["IDGODINE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new BLAGAJNAStavkeBlagajneInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "StavkeBlagajne" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyGodine()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGODINE], [GODINEAKTIVNA] FROM [GODINE] WITH (UPDLOCK) WHERE [IDGODINE] = @IDGODINE ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGODINE["IDGODINE"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new GODINEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("GODINE") }));
                }
                if (!command.HasMoreRows || !this.m__GODINEAKTIVNAOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 1))))
                {
                    reader.Close();
                    throw new GODINEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("GODINE") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowGodine()
        {
            this.rowGODINE = this.GODINESet.GODINE.NewGODINERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyGodine();
            this.AfterConfirmGodine();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [GODINE]  WHERE [IDGODINE] = @IDGODINE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGODINE["IDGODINE"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsGodine();
            }
            this.OnGODINEUpdated(new GODINEEventArgs(this.rowGODINE, StatementType.Delete));
            this.rowGODINE.Delete();
            this.sMode186 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode186;
        }

        public virtual int Fill(GODINEDataSet dataSet)
        {
            if (this.fillDataParameters != null)
            {
                this.Fill(dataSet, short.Parse(this.fillDataParameters[0].Value.ToString()));
            }
            else
            {
                try
                {
                    this.InitializeMembers();
                    this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
                    this.GODINESet = dataSet;
                    this.LoadChildGodine(0, -1);
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
            this.GODINESet = (GODINEDataSet) dataSet;
            if (this.GODINESet != null)
            {
                return this.Fill(this.GODINESet);
            }
            this.GODINESet = new GODINEDataSet();
            this.Fill(this.GODINESet);
            dataSet.Merge(this.GODINESet);
            return 0;
        }

        public virtual int Fill(GODINEDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToShort(dataRecord["IDGODINE"]));
        }

        public virtual int Fill(GODINEDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToShort(dataRecord["IDGODINE"]));
        }

        public virtual int Fill(GODINEDataSet dataSet, short iDGODINE)
        {
            if (!this.FillByIDGODINE(dataSet, iDGODINE))
            {
                throw new GODINENotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("GODINE") }));
            }
            return 0;
        }

        public virtual bool FillByIDGODINE(GODINEDataSet dataSet, short iDGODINE)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GODINESet = dataSet;
            this.rowGODINE = this.GODINESet.GODINE.NewGODINERow();
            this.rowGODINE.IDGODINE = iDGODINE;
            try
            {
                this.LoadByIDGODINE(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound186 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(GODINEDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.GODINESet = dataSet;
            try
            {
                this.LoadChildGodine(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDGODINE], [GODINEAKTIVNA] FROM [GODINE] WITH (NOLOCK) WHERE [IDGODINE] = @IDGODINE ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGODINE["IDGODINE"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound186 = 1;
                this.rowGODINE["IDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 0));
                this.rowGODINE["GODINEAKTIVNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(reader, 1));
                this.sMode186 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode186;
            }
            else
            {
                this.RcdFound186 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDGODINE";
                parameter.DbType = DbType.Int16;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmGODINESelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [GODINE] WITH (NOLOCK) ", false);
            this.GODINESelect1 = this.cmGODINESelect1.FetchData();
            if (this.GODINESelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.GODINESelect1.GetInt32(0);
            }
            this.GODINESelect1.Close();
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

        private void Initialize()
        {
            this.resourceManager = Deklarit.Utils.ResourceManager.Instance;
            this.resourceManagerTables = new System.Resources.ResourceManager("Tables", Assembly.GetExecutingAssembly());
            this.RcdFound186 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__GODINEAKTIVNAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.GODINESet = new GODINEDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertGodine()
        {
            this.CheckOptimisticConcurrencyGodine();
            this.AfterConfirmGodine();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [GODINE] ([IDGODINE], [GODINEAKTIVNA]) VALUES (@IDGODINE, @GODINEAKTIVNA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINEAKTIVNA", DbType.Boolean));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGODINE["IDGODINE"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowGODINE["GODINEAKTIVNA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new GODINEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnGODINEUpdated(new GODINEEventArgs(this.rowGODINE, StatementType.Insert));
        }

        private void LoadByIDGODINE(int startRow, int maxRows)
        {
            bool enforceConstraints = this.GODINESet.EnforceConstraints;
            this.GODINESet.GODINE.BeginLoadData();
            this.ScanByIDGODINE(startRow, maxRows);
            this.GODINESet.GODINE.EndLoadData();
            this.GODINESet.EnforceConstraints = enforceConstraints;
            if (this.GODINESet.GODINE.Count > 0)
            {
                this.rowGODINE = this.GODINESet.GODINE[this.GODINESet.GODINE.Count - 1];
            }
        }

        private void LoadChildGodine(int startRow, int maxRows)
        {
            this.CreateNewRowGodine();
            bool enforceConstraints = this.GODINESet.EnforceConstraints;
            this.GODINESet.GODINE.BeginLoadData();
            this.ScanStartGodine(startRow, maxRows);
            this.GODINESet.GODINE.EndLoadData();
            this.GODINESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataGodine(int maxRows)
        {
            int num = 0;
            if (this.RcdFound186 != 0)
            {
                this.ScanLoadGodine();
                while ((this.RcdFound186 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowGodine();
                    this.CreateNewRowGodine();
                    this.ScanNextGodine();
                }
            }
            if (num > 0)
            {
                this.RcdFound186 = 1;
            }
            this.ScanEndGodine();
            if (this.GODINESet.GODINE.Count > 0)
            {
                this.rowGODINE = this.GODINESet.GODINE[this.GODINESet.GODINE.Count - 1];
            }
        }

        private void LoadRowGodine()
        {
            this.AddRowGodine();
        }

        private void OnGODINEUpdated(GODINEEventArgs e)
        {
            if (this.GODINEUpdated != null)
            {
                GODINEUpdateEventHandler gODINEUpdatedEvent = this.GODINEUpdated;
                if (gODINEUpdatedEvent != null)
                {
                    gODINEUpdatedEvent(this, e);
                }
            }
        }

        private void OnGODINEUpdating(GODINEEventArgs e)
        {
            if (this.GODINEUpdating != null)
            {
                GODINEUpdateEventHandler gODINEUpdatingEvent = this.GODINEUpdating;
                if (gODINEUpdatingEvent != null)
                {
                    gODINEUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowGodine()
        {
            this.Gx_mode = Mode.FromRowState(this.rowGODINE.RowState);
            if (this.rowGODINE.RowState != DataRowState.Added)
            {
                this.m__GODINEAKTIVNAOriginal = RuntimeHelpers.GetObjectValue(this.rowGODINE["GODINEAKTIVNA", DataRowVersion.Original]);
            }
            else
            {
                this.m__GODINEAKTIVNAOriginal = RuntimeHelpers.GetObjectValue(this.rowGODINE["GODINEAKTIVNA"]);
            }
            this._Gxremove = this.rowGODINE.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowGODINE = (GODINEDataSet.GODINERow) DataSetUtil.CloneOriginalDataRow(this.rowGODINE);
            }
        }

        private void ScanByIDGODINE(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDGODINE] = @IDGODINE";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString186 + "  FROM [GODINE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDGODINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString186, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGODINE] ) AS DK_PAGENUM   FROM [GODINE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString186 + " FROM [GODINE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDGODINE] ";
            }
            this.cmGODINESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmGODINESelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmGODINESelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            this.cmGODINESelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGODINE["IDGODINE"]));
            this.GODINESelect4 = this.cmGODINESelect4.FetchData();
            this.RcdFound186 = 0;
            this.ScanLoadGodine();
            this.LoadDataGodine(maxRows);
        }

        private void ScanEndGodine()
        {
            this.GODINESelect4.Close();
        }

        private void ScanLoadGodine()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmGODINESelect4.HasMoreRows)
            {
                this.RcdFound186 = 1;
                this.rowGODINE["IDGODINE"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.GODINESelect4, 0));
                this.rowGODINE["GODINEAKTIVNA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetBoolean(this.GODINESelect4, 1));
            }
        }

        private void ScanNextGodine()
        {
            this.cmGODINESelect4.HasMoreRows = this.GODINESelect4.Read();
            this.RcdFound186 = 0;
            this.ScanLoadGodine();
        }

        private void ScanStartGodine(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString186 + "  FROM [GODINE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDGODINE]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString186, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDGODINE] ) AS DK_PAGENUM   FROM [GODINE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString186 + " FROM [GODINE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDGODINE] ";
            }
            this.cmGODINESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.GODINESelect4 = this.cmGODINESelect4.FetchData();
            this.RcdFound186 = 0;
            this.ScanLoadGodine();
            this.LoadDataGodine(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.GODINESet = (GODINEDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.GODINESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.GODINESet.GODINE.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        GODINEDataSet.GODINERow current = (GODINEDataSet.GODINERow) enumerator.Current;
                        this.rowGODINE = current;
                        if (Helpers.IsRowChanged(this.rowGODINE))
                        {
                            this.ReadRowGodine();
                            if (this.rowGODINE.RowState == DataRowState.Added)
                            {
                                this.InsertGodine();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateGodine();
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

        private void UpdateGodine()
        {
            this.CheckOptimisticConcurrencyGodine();
            this.AfterConfirmGodine();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [GODINE] SET [GODINEAKTIVNA]=@GODINEAKTIVNA  WHERE [IDGODINE] = @IDGODINE", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@GODINEAKTIVNA", DbType.Boolean));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDGODINE", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowGODINE["GODINEAKTIVNA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowGODINE["IDGODINE"]));
            command.ExecuteStmt();
            this.OnGODINEUpdated(new GODINEEventArgs(this.rowGODINE, StatementType.Update));
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
        public class BLAGAJNAStavkeBlagajneInvalidDeleteException : InvalidDeleteException
        {
            public BLAGAJNAStavkeBlagajneInvalidDeleteException()
            {
            }

            public BLAGAJNAStavkeBlagajneInvalidDeleteException(string message) : base(message)
            {
            }

            protected BLAGAJNAStavkeBlagajneInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public BLAGAJNAStavkeBlagajneInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class EVIDENCIJAInvalidDeleteException : InvalidDeleteException
        {
            public EVIDENCIJAInvalidDeleteException()
            {
            }

            public EVIDENCIJAInvalidDeleteException(string message) : base(message)
            {
            }

            protected EVIDENCIJAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public EVIDENCIJAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GKSTAVKAInvalidDeleteException : InvalidDeleteException
        {
            public GKSTAVKAInvalidDeleteException()
            {
            }

            public GKSTAVKAInvalidDeleteException(string message) : base(message)
            {
            }

            protected GKSTAVKAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GKSTAVKAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GODINEDataChangedException : DataChangedException
        {
            public GODINEDataChangedException()
            {
            }

            public GODINEDataChangedException(string message) : base(message)
            {
            }

            protected GODINEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GODINEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GODINEDataLockedException : DataLockedException
        {
            public GODINEDataLockedException()
            {
            }

            public GODINEDataLockedException(string message) : base(message)
            {
            }

            protected GODINEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GODINEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class GODINEDuplicateKeyException : DuplicateKeyException
        {
            public GODINEDuplicateKeyException()
            {
            }

            public GODINEDuplicateKeyException(string message) : base(message)
            {
            }

            protected GODINEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GODINEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class GODINEEventArgs : EventArgs
        {
            private GODINEDataSet.GODINERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public GODINEEventArgs(GODINEDataSet.GODINERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public GODINEDataSet.GODINERow Row
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
        public class GODINENotFoundException : DataNotFoundException
        {
            public GODINENotFoundException()
            {
            }

            public GODINENotFoundException(string message) : base(message)
            {
            }

            protected GODINENotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public GODINENotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void GODINEUpdateEventHandler(object sender, GODINEDataAdapter.GODINEEventArgs e);

        [Serializable]
        public class IRAInvalidDeleteException : InvalidDeleteException
        {
            public IRAInvalidDeleteException()
            {
            }

            public IRAInvalidDeleteException(string message) : base(message)
            {
            }

            protected IRAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IRAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class PLANInvalidDeleteException : InvalidDeleteException
        {
            public PLANInvalidDeleteException()
            {
            }

            public PLANInvalidDeleteException(string message) : base(message)
            {
            }

            protected PLANInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public PLANInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RACUNInvalidDeleteException : InvalidDeleteException
        {
            public RACUNInvalidDeleteException()
            {
            }

            public RACUNInvalidDeleteException(string message) : base(message)
            {
            }

            protected RACUNInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RACUNInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class URAInvalidDeleteException : InvalidDeleteException
        {
            public URAInvalidDeleteException()
            {
            }

            public URAInvalidDeleteException(string message) : base(message)
            {
            }

            protected URAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public URAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

