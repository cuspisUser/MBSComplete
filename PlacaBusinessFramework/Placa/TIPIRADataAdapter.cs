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

    public class TIPIRADataAdapter : IDataAdapter, ITIPIRADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmTIPIRASelect1;
        private ReadWriteCommand cmTIPIRASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVTIPIRAOriginal;
        private readonly string m_SelectString198 = "TM1.[IDTIPIRA], TM1.[NAZIVTIPIRA]";
        private string m_WhereString;
        private short RcdFound198;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private TIPIRADataSet.TIPIRARow rowTIPIRA;
        private string scmdbuf;
        private StatementType sMode198;
        private IDataReader TIPIRASelect1;
        private IDataReader TIPIRASelect4;
        private TIPIRADataSet TIPIRASet;

        public event TIPIRAUpdateEventHandler TIPIRAUpdated;

        public event TIPIRAUpdateEventHandler TIPIRAUpdating;

        private void AddRowTipira()
        {
            this.TIPIRASet.TIPIRA.AddTIPIRARow(this.rowTIPIRA);
        }

        private void AfterConfirmTipira()
        {
            this.OnTIPIRAUpdating(new TIPIRAEventArgs(this.rowTIPIRA, this.Gx_mode));
        }

        private void CheckDeleteErrorsTipira()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IRAGODIDGODINE], [IRADOKIDDOKUMENT], [IRABROJ] FROM [IRA] WITH (NOLOCK) WHERE [IDTIPIRA] = @IDTIPIRA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPIRA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPIRA["IDTIPIRA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new IRAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "IRA" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyTipira()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDTIPIRA], [NAZIVTIPIRA] FROM [TIPIRA] WITH (UPDLOCK) WHERE [IDTIPIRA] = @IDTIPIRA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPIRA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPIRA["IDTIPIRA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new TIPIRADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("TIPIRA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVTIPIRAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new TIPIRADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("TIPIRA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowTipira()
        {
            this.rowTIPIRA = this.TIPIRASet.TIPIRA.NewTIPIRARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyTipira();
            this.AfterConfirmTipira();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [TIPIRA]  WHERE [IDTIPIRA] = @IDTIPIRA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPIRA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPIRA["IDTIPIRA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsTipira();
            }
            this.OnTIPIRAUpdated(new TIPIRAEventArgs(this.rowTIPIRA, StatementType.Delete));
            this.rowTIPIRA.Delete();
            this.sMode198 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode198;
        }

        public virtual int Fill(TIPIRADataSet dataSet)
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
                    this.TIPIRASet = dataSet;
                    this.LoadChildTipira(0, -1);
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
            this.TIPIRASet = (TIPIRADataSet) dataSet;
            if (this.TIPIRASet != null)
            {
                return this.Fill(this.TIPIRASet);
            }
            this.TIPIRASet = new TIPIRADataSet();
            this.Fill(this.TIPIRASet);
            dataSet.Merge(this.TIPIRASet);
            return 0;
        }

        public virtual int Fill(TIPIRADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDTIPIRA"]));
        }

        public virtual int Fill(TIPIRADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDTIPIRA"]));
        }

        public virtual int Fill(TIPIRADataSet dataSet, int iDTIPIRA)
        {
            if (!this.FillByIDTIPIRA(dataSet, iDTIPIRA))
            {
                throw new TIPIRANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("TIPIRA") }));
            }
            return 0;
        }

        public virtual bool FillByIDTIPIRA(TIPIRADataSet dataSet, int iDTIPIRA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.TIPIRASet = dataSet;
            this.rowTIPIRA = this.TIPIRASet.TIPIRA.NewTIPIRARow();
            this.rowTIPIRA.IDTIPIRA = iDTIPIRA;
            try
            {
                this.LoadByIDTIPIRA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound198 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(TIPIRADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.TIPIRASet = dataSet;
            try
            {
                this.LoadChildTipira(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDTIPIRA], [NAZIVTIPIRA] FROM [TIPIRA] WITH (NOLOCK) WHERE [IDTIPIRA] = @IDTIPIRA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPIRA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPIRA["IDTIPIRA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound198 = 1;
                this.rowTIPIRA["IDTIPIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowTIPIRA["NAZIVTIPIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode198 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode198;
            }
            else
            {
                this.RcdFound198 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDTIPIRA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmTIPIRASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [TIPIRA] WITH (NOLOCK) ", false);
            this.TIPIRASelect1 = this.cmTIPIRASelect1.FetchData();
            if (this.TIPIRASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.TIPIRASelect1.GetInt32(0);
            }
            this.TIPIRASelect1.Close();
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
            this.RcdFound198 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVTIPIRAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.TIPIRASet = new TIPIRADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertTipira()
        {
            this.CheckOptimisticConcurrencyTipira();
            this.AfterConfirmTipira();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [TIPIRA] ([IDTIPIRA], [NAZIVTIPIRA]) VALUES (@IDTIPIRA, @NAZIVTIPIRA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPIRA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVTIPIRA", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPIRA["IDTIPIRA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowTIPIRA["NAZIVTIPIRA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new TIPIRADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnTIPIRAUpdated(new TIPIRAEventArgs(this.rowTIPIRA, StatementType.Insert));
        }

        private void LoadByIDTIPIRA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.TIPIRASet.EnforceConstraints;
            this.TIPIRASet.TIPIRA.BeginLoadData();
            this.ScanByIDTIPIRA(startRow, maxRows);
            this.TIPIRASet.TIPIRA.EndLoadData();
            this.TIPIRASet.EnforceConstraints = enforceConstraints;
            if (this.TIPIRASet.TIPIRA.Count > 0)
            {
                this.rowTIPIRA = this.TIPIRASet.TIPIRA[this.TIPIRASet.TIPIRA.Count - 1];
            }
        }

        private void LoadChildTipira(int startRow, int maxRows)
        {
            this.CreateNewRowTipira();
            bool enforceConstraints = this.TIPIRASet.EnforceConstraints;
            this.TIPIRASet.TIPIRA.BeginLoadData();
            this.ScanStartTipira(startRow, maxRows);
            this.TIPIRASet.TIPIRA.EndLoadData();
            this.TIPIRASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataTipira(int maxRows)
        {
            int num = 0;
            if (this.RcdFound198 != 0)
            {
                this.ScanLoadTipira();
                while ((this.RcdFound198 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowTipira();
                    this.CreateNewRowTipira();
                    this.ScanNextTipira();
                }
            }
            if (num > 0)
            {
                this.RcdFound198 = 1;
            }
            this.ScanEndTipira();
            if (this.TIPIRASet.TIPIRA.Count > 0)
            {
                this.rowTIPIRA = this.TIPIRASet.TIPIRA[this.TIPIRASet.TIPIRA.Count - 1];
            }
        }

        private void LoadRowTipira()
        {
            this.AddRowTipira();
        }

        private void OnTIPIRAUpdated(TIPIRAEventArgs e)
        {
            if (this.TIPIRAUpdated != null)
            {
                TIPIRAUpdateEventHandler tIPIRAUpdatedEvent = this.TIPIRAUpdated;
                if (tIPIRAUpdatedEvent != null)
                {
                    tIPIRAUpdatedEvent(this, e);
                }
            }
        }

        private void OnTIPIRAUpdating(TIPIRAEventArgs e)
        {
            if (this.TIPIRAUpdating != null)
            {
                TIPIRAUpdateEventHandler tIPIRAUpdatingEvent = this.TIPIRAUpdating;
                if (tIPIRAUpdatingEvent != null)
                {
                    tIPIRAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowTipira()
        {
            this.Gx_mode = Mode.FromRowState(this.rowTIPIRA.RowState);
            if (this.rowTIPIRA.RowState != DataRowState.Added)
            {
                this.m__NAZIVTIPIRAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPIRA["NAZIVTIPIRA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVTIPIRAOriginal = RuntimeHelpers.GetObjectValue(this.rowTIPIRA["NAZIVTIPIRA"]);
            }
            this._Gxremove = this.rowTIPIRA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowTIPIRA = (TIPIRADataSet.TIPIRARow) DataSetUtil.CloneOriginalDataRow(this.rowTIPIRA);
            }
        }

        private void ScanByIDTIPIRA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDTIPIRA] = @IDTIPIRA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString198 + "  FROM [TIPIRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPIRA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString198, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDTIPIRA] ) AS DK_PAGENUM   FROM [TIPIRA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString198 + " FROM [TIPIRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPIRA] ";
            }
            this.cmTIPIRASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmTIPIRASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmTIPIRASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPIRA", DbType.Int32));
            }
            this.cmTIPIRASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPIRA["IDTIPIRA"]));
            this.TIPIRASelect4 = this.cmTIPIRASelect4.FetchData();
            this.RcdFound198 = 0;
            this.ScanLoadTipira();
            this.LoadDataTipira(maxRows);
        }

        private void ScanEndTipira()
        {
            this.TIPIRASelect4.Close();
        }

        private void ScanLoadTipira()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmTIPIRASelect4.HasMoreRows)
            {
                this.RcdFound198 = 1;
                this.rowTIPIRA["IDTIPIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.TIPIRASelect4, 0));
                this.rowTIPIRA["NAZIVTIPIRA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.TIPIRASelect4, 1));
            }
        }

        private void ScanNextTipira()
        {
            this.cmTIPIRASelect4.HasMoreRows = this.TIPIRASelect4.Read();
            this.RcdFound198 = 0;
            this.ScanLoadTipira();
        }

        private void ScanStartTipira(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString198 + "  FROM [TIPIRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPIRA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString198, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDTIPIRA] ) AS DK_PAGENUM   FROM [TIPIRA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString198 + " FROM [TIPIRA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDTIPIRA] ";
            }
            this.cmTIPIRASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.TIPIRASelect4 = this.cmTIPIRASelect4.FetchData();
            this.RcdFound198 = 0;
            this.ScanLoadTipira();
            this.LoadDataTipira(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.TIPIRASet = (TIPIRADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.TIPIRASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.TIPIRASet.TIPIRA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        TIPIRADataSet.TIPIRARow current = (TIPIRADataSet.TIPIRARow) enumerator.Current;
                        this.rowTIPIRA = current;
                        if (Helpers.IsRowChanged(this.rowTIPIRA))
                        {
                            this.ReadRowTipira();
                            if (this.rowTIPIRA.RowState == DataRowState.Added)
                            {
                                this.InsertTipira();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateTipira();
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

        private void UpdateTipira()
        {
            this.CheckOptimisticConcurrencyTipira();
            this.AfterConfirmTipira();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [TIPIRA] SET [NAZIVTIPIRA]=@NAZIVTIPIRA  WHERE [IDTIPIRA] = @IDTIPIRA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVTIPIRA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDTIPIRA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowTIPIRA["NAZIVTIPIRA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowTIPIRA["IDTIPIRA"]));
            command.ExecuteStmt();
            this.OnTIPIRAUpdated(new TIPIRAEventArgs(this.rowTIPIRA, StatementType.Update));
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
        public class TIPIRADataChangedException : DataChangedException
        {
            public TIPIRADataChangedException()
            {
            }

            public TIPIRADataChangedException(string message) : base(message)
            {
            }

            protected TIPIRADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPIRADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPIRADataLockedException : DataLockedException
        {
            public TIPIRADataLockedException()
            {
            }

            public TIPIRADataLockedException(string message) : base(message)
            {
            }

            protected TIPIRADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPIRADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class TIPIRADuplicateKeyException : DuplicateKeyException
        {
            public TIPIRADuplicateKeyException()
            {
            }

            public TIPIRADuplicateKeyException(string message) : base(message)
            {
            }

            protected TIPIRADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPIRADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class TIPIRAEventArgs : EventArgs
        {
            private TIPIRADataSet.TIPIRARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public TIPIRAEventArgs(TIPIRADataSet.TIPIRARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public TIPIRADataSet.TIPIRARow Row
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
        public class TIPIRANotFoundException : DataNotFoundException
        {
            public TIPIRANotFoundException()
            {
            }

            public TIPIRANotFoundException(string message) : base(message)
            {
            }

            protected TIPIRANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public TIPIRANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void TIPIRAUpdateEventHandler(object sender, TIPIRADataAdapter.TIPIRAEventArgs e);
    }
}

