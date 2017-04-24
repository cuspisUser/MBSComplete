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

    public class TITULADataAdapter : IDataAdapter, ITITULADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmTITULASelect1;
        private ReadWriteCommand cmTITULASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVTITULAOriginal;
        private readonly string m_SelectString38 = "TM1.[IDTITULA], TM1.[NAZIVTITULA]";
        private string m_WhereString;
        private short RcdFound38;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private TITULADataSet.TITULARow rowTITULA;
        private string scmdbuf;
        private StatementType sMode38;
        private IDataReader TITULASelect1;
        private IDataReader TITULASelect4;
        private TITULADataSet TITULASet;

        public event TITULAUpdateEventHandler TITULAUpdated;

        public event TITULAUpdateEventHandler TITULAUpdating;

        private void AddRowTitula()
        {
            this.TITULASet.TITULA.AddTITULARow(this.rowTITULA);
        }

        private void AfterConfirmTitula()
        {
            this.OnTITULAUpdating(new TITULAEventArgs(this.rowTITULA, this.Gx_mode));
        }

        private void CheckDeleteErrorsTitula()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [IDTITULA] = @IDTITULA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTITULA["IDTITULA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyTitula()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDTITULA], [NAZIVTITULA] FROM [TITULA] WITH (UPDLOCK) WHERE [IDTITULA] = @IDTITULA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTITULA["IDTITULA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new TITULADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("TITULA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVTITULAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new TITULADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("TITULA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowTitula()
        {
            this.rowTITULA = this.TITULASet.TITULA.NewTITULARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyTitula();
            this.AfterConfirmTitula();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [TITULA]  WHERE [IDTITULA] = @IDTITULA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTITULA["IDTITULA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsTitula();
            }
            this.OnTITULAUpdated(new TITULAEventArgs(this.rowTITULA, StatementType.Delete));
            this.rowTITULA.Delete();
            this.sMode38 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode38;
        }

        public virtual int Fill(TITULADataSet dataSet)
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
                    this.TITULASet = dataSet;
                    this.LoadChildTitula(0, -1);
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
            this.TITULASet = (TITULADataSet) dataSet;
            if (this.TITULASet != null)
            {
                return this.Fill(this.TITULASet);
            }
            this.TITULASet = new TITULADataSet();
            this.Fill(this.TITULASet);
            dataSet.Merge(this.TITULASet);
            return 0;
        }

        public virtual int Fill(TITULADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDTITULA"]));
        }

        public virtual int Fill(TITULADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDTITULA"]));
        }

        public virtual int Fill(TITULADataSet dataSet, int iDTITULA)
        {
            if (!this.FillByIDTITULA(dataSet, iDTITULA))
            {
                throw new TITULANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("TITULA") }));
            }
            return 0;
        }

        public virtual bool FillByIDTITULA(TITULADataSet dataSet, int iDTITULA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.TITULASet = dataSet;
            this.rowTITULA = this.TITULASet.TITULA.NewTITULARow();
            this.rowTITULA.IDTITULA = iDTITULA;
            try
            {
                this.LoadByIDTITULA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound38 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(TITULADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.TITULASet = dataSet;
            try
            {
                this.LoadChildTitula(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDTITULA], [NAZIVTITULA] FROM [TITULA] WITH (NOLOCK) WHERE [IDTITULA] = @IDTITULA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTITULA["IDTITULA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound38 = 1;
                this.rowTITULA["IDTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowTITULA["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode38 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode38;
            }
            else
            {
                this.RcdFound38 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDTITULA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmTITULASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [TITULA] WITH (NOLOCK) ", false);
            this.TITULASelect1 = this.cmTITULASelect1.FetchData();
            if (this.TITULASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.TITULASelect1.GetInt32(0);
            }
            this.TITULASelect1.Close();
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
            this.RcdFound38 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVTITULAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.TITULASet = new TITULADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertTitula()
        {
            this.CheckOptimisticConcurrencyTitula();
            this.AfterConfirmTitula();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [TITULA] ([IDTITULA], [NAZIVTITULA]) VALUES (@IDTITULA, @NAZIVTITULA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVTITULA", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTITULA["IDTITULA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowTITULA["NAZIVTITULA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new TITULADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnTITULAUpdated(new TITULAEventArgs(this.rowTITULA, StatementType.Insert));
        }

        private void LoadByIDTITULA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.TITULASet.EnforceConstraints;
            this.TITULASet.TITULA.BeginLoadData();
            this.ScanByIDTITULA(startRow, maxRows);
            this.TITULASet.TITULA.EndLoadData();
            this.TITULASet.EnforceConstraints = enforceConstraints;
            if (this.TITULASet.TITULA.Count > 0)
            {
                this.rowTITULA = this.TITULASet.TITULA[this.TITULASet.TITULA.Count - 1];
            }
        }

        private void LoadChildTitula(int startRow, int maxRows)
        {
            this.CreateNewRowTitula();
            bool enforceConstraints = this.TITULASet.EnforceConstraints;
            this.TITULASet.TITULA.BeginLoadData();
            this.ScanStartTitula(startRow, maxRows);
            this.TITULASet.TITULA.EndLoadData();
            this.TITULASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataTitula(int maxRows)
        {
            int num = 0;
            if (this.RcdFound38 != 0)
            {
                this.ScanLoadTitula();
                while ((this.RcdFound38 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowTitula();
                    this.CreateNewRowTitula();
                    this.ScanNextTitula();
                }
            }
            if (num > 0)
            {
                this.RcdFound38 = 1;
            }
            this.ScanEndTitula();
            if (this.TITULASet.TITULA.Count > 0)
            {
                this.rowTITULA = this.TITULASet.TITULA[this.TITULASet.TITULA.Count - 1];
            }
        }

        private void LoadRowTitula()
        {
            this.AddRowTitula();
        }

        private void OnTITULAUpdated(TITULAEventArgs e)
        {
            if (this.TITULAUpdated != null)
            {
                TITULAUpdateEventHandler tITULAUpdatedEvent = this.TITULAUpdated;
                if (tITULAUpdatedEvent != null)
                {
                    tITULAUpdatedEvent(this, e);
                }
            }
        }

        private void OnTITULAUpdating(TITULAEventArgs e)
        {
            if (this.TITULAUpdating != null)
            {
                TITULAUpdateEventHandler tITULAUpdatingEvent = this.TITULAUpdating;
                if (tITULAUpdatingEvent != null)
                {
                    tITULAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowTitula()
        {
            this.Gx_mode = Mode.FromRowState(this.rowTITULA.RowState);
            if (this.rowTITULA.RowState != DataRowState.Added)
            {
                this.m__NAZIVTITULAOriginal = RuntimeHelpers.GetObjectValue(this.rowTITULA["NAZIVTITULA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVTITULAOriginal = RuntimeHelpers.GetObjectValue(this.rowTITULA["NAZIVTITULA"]);
            }
            this._Gxremove = this.rowTITULA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowTITULA = (TITULADataSet.TITULARow) DataSetUtil.CloneOriginalDataRow(this.rowTITULA);
            }
        }

        private void ScanByIDTITULA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDTITULA] = @IDTITULA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString38 + "  FROM [TITULA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTITULA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString38, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDTITULA] ) AS DK_PAGENUM   FROM [TITULA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString38 + " FROM [TITULA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTITULA] ";
            }
            this.cmTITULASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmTITULASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmTITULASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
            }
            this.cmTITULASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTITULA["IDTITULA"]));
            this.TITULASelect4 = this.cmTITULASelect4.FetchData();
            this.RcdFound38 = 0;
            this.ScanLoadTitula();
            this.LoadDataTitula(maxRows);
        }

        private void ScanEndTitula()
        {
            this.TITULASelect4.Close();
        }

        private void ScanLoadTitula()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmTITULASelect4.HasMoreRows)
            {
                this.RcdFound38 = 1;
                this.rowTITULA["IDTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.TITULASelect4, 0));
                this.rowTITULA["NAZIVTITULA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.TITULASelect4, 1));
            }
        }

        private void ScanNextTitula()
        {
            this.cmTITULASelect4.HasMoreRows = this.TITULASelect4.Read();
            this.RcdFound38 = 0;
            this.ScanLoadTitula();
        }

        private void ScanStartTitula(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString38 + "  FROM [TITULA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTITULA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString38, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDTITULA] ) AS DK_PAGENUM   FROM [TITULA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString38 + " FROM [TITULA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTITULA] ";
            }
            this.cmTITULASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.TITULASelect4 = this.cmTITULASelect4.FetchData();
            this.RcdFound38 = 0;
            this.ScanLoadTitula();
            this.LoadDataTitula(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.TITULASet = (TITULADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.TITULASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.TITULASet.TITULA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        TITULADataSet.TITULARow current = (TITULADataSet.TITULARow) enumerator.Current;
                        this.rowTITULA = current;
                        if (Helpers.IsRowChanged(this.rowTITULA))
                        {
                            this.ReadRowTitula();
                            if (this.rowTITULA.RowState == DataRowState.Added)
                            {
                                this.InsertTitula();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateTitula();
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

        private void UpdateTitula()
        {
            this.CheckOptimisticConcurrencyTitula();
            this.AfterConfirmTitula();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [TITULA] SET [NAZIVTITULA]=@NAZIVTITULA  WHERE [IDTITULA] = @IDTITULA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVTITULA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTITULA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTITULA["NAZIVTITULA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowTITULA["IDTITULA"]));
            command.ExecuteStmt();
            this.OnTITULAUpdated(new TITULAEventArgs(this.rowTITULA, StatementType.Update));
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
        public class RADNIKInvalidDeleteException : InvalidDeleteException
        {
            public RADNIKInvalidDeleteException()
            {
            }

            public RADNIKInvalidDeleteException(string message) : base(message)
            {
            }

            protected RADNIKInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RADNIKInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TITULADataChangedException : DataChangedException
        {
            public TITULADataChangedException()
            {
            }

            public TITULADataChangedException(string message) : base(message)
            {
            }

            protected TITULADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TITULADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TITULADataLockedException : DataLockedException
        {
            public TITULADataLockedException()
            {
            }

            public TITULADataLockedException(string message) : base(message)
            {
            }

            protected TITULADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TITULADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TITULADuplicateKeyException : DuplicateKeyException
        {
            public TITULADuplicateKeyException()
            {
            }

            public TITULADuplicateKeyException(string message) : base(message)
            {
            }

            protected TITULADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TITULADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class TITULAEventArgs : EventArgs
        {
            private TITULADataSet.TITULARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public TITULAEventArgs(TITULADataSet.TITULARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public TITULADataSet.TITULARow Row
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
        public class TITULANotFoundException : DataNotFoundException
        {
            public TITULANotFoundException()
            {
            }

            public TITULANotFoundException(string message) : base(message)
            {
            }

            protected TITULANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TITULANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void TITULAUpdateEventHandler(object sender, TITULADataAdapter.TITULAEventArgs e);
    }
}

