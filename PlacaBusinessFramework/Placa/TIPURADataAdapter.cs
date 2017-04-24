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

    public class TIPURADataAdapter : IDataAdapter, ITIPURADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmTIPURASelect1;
        private ReadWriteCommand cmTIPURASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVTIPURAOriginal;
        private readonly string m_SelectString199 = "TM1.[IDTIPURA], TM1.[NAZIVTIPURA]";
        private string m_WhereString;
        private short RcdFound199;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private TIPURADataSet.TIPURARow rowTIPURA;
        private string scmdbuf;
        private StatementType sMode199;
        private IDataReader TIPURASelect1;
        private IDataReader TIPURASelect4;
        private TIPURADataSet TIPURASet;

        public event TIPURAUpdateEventHandler TIPURAUpdated;

        public event TIPURAUpdateEventHandler TIPURAUpdating;

        private void AddRowTipura()
        {
            this.TIPURASet.TIPURA.AddTIPURARow(this.rowTIPURA);
        }

        private void AfterConfirmTipura()
        {
            this.OnTIPURAUpdating(new TIPURAEventArgs(this.rowTIPURA, this.Gx_mode));
        }

        private void CheckDeleteErrorsTipura()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [URAGODIDGODINE], [URADOKIDDOKUMENT], [URABROJ] FROM [URA] WITH (NOLOCK) WHERE [IDTIPURA] = @IDTIPURA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPURA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPURA["IDTIPURA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new URAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "URA" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyTipura()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDTIPURA], [NAZIVTIPURA] FROM [TIPURA] WITH (UPDLOCK) WHERE [IDTIPURA] = @IDTIPURA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPURA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPURA["IDTIPURA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new TIPURADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("TIPURA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVTIPURAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new TIPURADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("TIPURA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowTipura()
        {
            this.rowTIPURA = this.TIPURASet.TIPURA.NewTIPURARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyTipura();
            this.AfterConfirmTipura();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [TIPURA]  WHERE [IDTIPURA] = @IDTIPURA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPURA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPURA["IDTIPURA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsTipura();
            }
            this.OnTIPURAUpdated(new TIPURAEventArgs(this.rowTIPURA, StatementType.Delete));
            this.rowTIPURA.Delete();
            this.sMode199 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode199;
        }

        public virtual int Fill(TIPURADataSet dataSet)
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
                    this.TIPURASet = dataSet;
                    this.LoadChildTipura(0, -1);
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
            this.TIPURASet = (TIPURADataSet) dataSet;
            if (this.TIPURASet != null)
            {
                return this.Fill(this.TIPURASet);
            }
            this.TIPURASet = new TIPURADataSet();
            this.Fill(this.TIPURASet);
            dataSet.Merge(this.TIPURASet);
            return 0;
        }

        public virtual int Fill(TIPURADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDTIPURA"]));
        }

        public virtual int Fill(TIPURADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDTIPURA"]));
        }

        public virtual int Fill(TIPURADataSet dataSet, int iDTIPURA)
        {
            if (!this.FillByIDTIPURA(dataSet, iDTIPURA))
            {
                throw new TIPURANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("TIPURA") }));
            }
            return 0;
        }

        public virtual bool FillByIDTIPURA(TIPURADataSet dataSet, int iDTIPURA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.TIPURASet = dataSet;
            this.rowTIPURA = this.TIPURASet.TIPURA.NewTIPURARow();
            this.rowTIPURA.IDTIPURA = iDTIPURA;
            try
            {
                this.LoadByIDTIPURA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound199 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(TIPURADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.TIPURASet = dataSet;
            try
            {
                this.LoadChildTipura(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDTIPURA], [NAZIVTIPURA] FROM [TIPURA] WITH (NOLOCK) WHERE [IDTIPURA] = @IDTIPURA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPURA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPURA["IDTIPURA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound199 = 1;
                this.rowTIPURA["IDTIPURA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowTIPURA["NAZIVTIPURA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode199 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode199;
            }
            else
            {
                this.RcdFound199 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDTIPURA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmTIPURASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [TIPURA] WITH (NOLOCK) ", false);
            this.TIPURASelect1 = this.cmTIPURASelect1.FetchData();
            if (this.TIPURASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.TIPURASelect1.GetInt32(0);
            }
            this.TIPURASelect1.Close();
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
            this.RcdFound199 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVTIPURAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.TIPURASet = new TIPURADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertTipura()
        {
            this.CheckOptimisticConcurrencyTipura();
            this.AfterConfirmTipura();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [TIPURA] ([IDTIPURA], [NAZIVTIPURA]) VALUES (@IDTIPURA, @NAZIVTIPURA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPURA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVTIPURA", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPURA["IDTIPURA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowTIPURA["NAZIVTIPURA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new TIPURADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnTIPURAUpdated(new TIPURAEventArgs(this.rowTIPURA, StatementType.Insert));
        }

        private void LoadByIDTIPURA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.TIPURASet.EnforceConstraints;
            this.TIPURASet.TIPURA.BeginLoadData();
            this.ScanByIDTIPURA(startRow, maxRows);
            this.TIPURASet.TIPURA.EndLoadData();
            this.TIPURASet.EnforceConstraints = enforceConstraints;
            if (this.TIPURASet.TIPURA.Count > 0)
            {
                this.rowTIPURA = this.TIPURASet.TIPURA[this.TIPURASet.TIPURA.Count - 1];
            }
        }

        private void LoadChildTipura(int startRow, int maxRows)
        {
            this.CreateNewRowTipura();
            bool enforceConstraints = this.TIPURASet.EnforceConstraints;
            this.TIPURASet.TIPURA.BeginLoadData();
            this.ScanStartTipura(startRow, maxRows);
            this.TIPURASet.TIPURA.EndLoadData();
            this.TIPURASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataTipura(int maxRows)
        {
            int num = 0;
            if (this.RcdFound199 != 0)
            {
                this.ScanLoadTipura();
                while ((this.RcdFound199 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowTipura();
                    this.CreateNewRowTipura();
                    this.ScanNextTipura();
                }
            }
            if (num > 0)
            {
                this.RcdFound199 = 1;
            }
            this.ScanEndTipura();
            if (this.TIPURASet.TIPURA.Count > 0)
            {
                this.rowTIPURA = this.TIPURASet.TIPURA[this.TIPURASet.TIPURA.Count - 1];
            }
        }

        private void LoadRowTipura()
        {
            this.AddRowTipura();
        }

        private void OnTIPURAUpdated(TIPURAEventArgs e)
        {
            if (this.TIPURAUpdated != null)
            {
                TIPURAUpdateEventHandler tIPURAUpdatedEvent = this.TIPURAUpdated;
                if (tIPURAUpdatedEvent != null)
                {
                    tIPURAUpdatedEvent(this, e);
                }
            }
        }

        private void OnTIPURAUpdating(TIPURAEventArgs e)
        {
            if (this.TIPURAUpdating != null)
            {
                TIPURAUpdateEventHandler tIPURAUpdatingEvent = this.TIPURAUpdating;
                if (tIPURAUpdatingEvent != null)
                {
                    tIPURAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowTipura()
        {
            this.Gx_mode = Mode.FromRowState(this.rowTIPURA.RowState);
            if (this.rowTIPURA.RowState != DataRowState.Added)
            {
                this.m__NAZIVTIPURAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPURA["NAZIVTIPURA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVTIPURAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPURA["NAZIVTIPURA"]);
            }
            this._Gxremove = this.rowTIPURA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowTIPURA = (TIPURADataSet.TIPURARow) DataSetUtil.CloneOriginalDataRow(this.rowTIPURA);
            }
        }

        private void ScanByIDTIPURA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDTIPURA] = @IDTIPURA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString199 + "  FROM [TIPURA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPURA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString199, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDTIPURA] ) AS DK_PAGENUM   FROM [TIPURA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString199 + " FROM [TIPURA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPURA] ";
            }
            this.cmTIPURASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmTIPURASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmTIPURASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPURA", DbType.Int32));
            }
            this.cmTIPURASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPURA["IDTIPURA"]));
            this.TIPURASelect4 = this.cmTIPURASelect4.FetchData();
            this.RcdFound199 = 0;
            this.ScanLoadTipura();
            this.LoadDataTipura(maxRows);
        }

        private void ScanEndTipura()
        {
            this.TIPURASelect4.Close();
        }

        private void ScanLoadTipura()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmTIPURASelect4.HasMoreRows)
            {
                this.RcdFound199 = 1;
                this.rowTIPURA["IDTIPURA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.TIPURASelect4, 0));
                this.rowTIPURA["NAZIVTIPURA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.TIPURASelect4, 1));
            }
        }

        private void ScanNextTipura()
        {
            this.cmTIPURASelect4.HasMoreRows = this.TIPURASelect4.Read();
            this.RcdFound199 = 0;
            this.ScanLoadTipura();
        }

        private void ScanStartTipura(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString199 + "  FROM [TIPURA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPURA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString199, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDTIPURA] ) AS DK_PAGENUM   FROM [TIPURA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString199 + " FROM [TIPURA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPURA] ";
            }
            this.cmTIPURASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.TIPURASelect4 = this.cmTIPURASelect4.FetchData();
            this.RcdFound199 = 0;
            this.ScanLoadTipura();
            this.LoadDataTipura(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.TIPURASet = (TIPURADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.TIPURASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.TIPURASet.TIPURA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        TIPURADataSet.TIPURARow current = (TIPURADataSet.TIPURARow) enumerator.Current;
                        this.rowTIPURA = current;
                        if (Helpers.IsRowChanged(this.rowTIPURA))
                        {
                            this.ReadRowTipura();
                            if (this.rowTIPURA.RowState == DataRowState.Added)
                            {
                                this.InsertTipura();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateTipura();
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

        private void UpdateTipura()
        {
            this.CheckOptimisticConcurrencyTipura();
            this.AfterConfirmTipura();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [TIPURA] SET [NAZIVTIPURA]=@NAZIVTIPURA  WHERE [IDTIPURA] = @IDTIPURA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVTIPURA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPURA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPURA["NAZIVTIPURA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowTIPURA["IDTIPURA"]));
            command.ExecuteStmt();
            this.OnTIPURAUpdated(new TIPURAEventArgs(this.rowTIPURA, StatementType.Update));
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
        public class TIPURADataChangedException : DataChangedException
        {
            public TIPURADataChangedException()
            {
            }

            public TIPURADataChangedException(string message) : base(message)
            {
            }

            protected TIPURADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPURADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPURADataLockedException : DataLockedException
        {
            public TIPURADataLockedException()
            {
            }

            public TIPURADataLockedException(string message) : base(message)
            {
            }

            protected TIPURADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPURADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPURADuplicateKeyException : DuplicateKeyException
        {
            public TIPURADuplicateKeyException()
            {
            }

            public TIPURADuplicateKeyException(string message) : base(message)
            {
            }

            protected TIPURADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPURADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class TIPURAEventArgs : EventArgs
        {
            private TIPURADataSet.TIPURARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public TIPURAEventArgs(TIPURADataSet.TIPURARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public TIPURADataSet.TIPURARow Row
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
        public class TIPURANotFoundException : DataNotFoundException
        {
            public TIPURANotFoundException()
            {
            }

            public TIPURANotFoundException(string message) : base(message)
            {
            }

            protected TIPURANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPURANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void TIPURAUpdateEventHandler(object sender, TIPURADataAdapter.TIPURAEventArgs e);

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

