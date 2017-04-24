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

    public class STRUKADataAdapter : IDataAdapter, ISTRUKADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmSTRUKASelect1;
        private ReadWriteCommand cmSTRUKASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVSTRUKAOriginal;
        private readonly string m_SelectString35 = "TM1.[IDSTRUKA], TM1.[NAZIVSTRUKA]";
        private string m_WhereString;
        private short RcdFound35;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private STRUKADataSet.STRUKARow rowSTRUKA;
        private string scmdbuf;
        private StatementType sMode35;
        private IDataReader STRUKASelect1;
        private IDataReader STRUKASelect4;
        private STRUKADataSet STRUKASet;

        public event STRUKAUpdateEventHandler STRUKAUpdated;

        public event STRUKAUpdateEventHandler STRUKAUpdating;

        private void AddRowStruka()
        {
            this.STRUKASet.STRUKA.AddSTRUKARow(this.rowSTRUKA);
        }

        private void AfterConfirmStruka()
        {
            this.OnSTRUKAUpdating(new STRUKAEventArgs(this.rowSTRUKA, this.Gx_mode));
        }

        private void CheckDeleteErrorsStruka()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [IDSTRUKA] = @IDSTRUKA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUKA["IDSTRUKA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyStruka()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSTRUKA], [NAZIVSTRUKA] FROM [STRUKA] WITH (UPDLOCK) WHERE [IDSTRUKA] = @IDSTRUKA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUKA["IDSTRUKA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new STRUKADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("STRUKA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVSTRUKAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new STRUKADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("STRUKA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowStruka()
        {
            this.rowSTRUKA = this.STRUKASet.STRUKA.NewSTRUKARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyStruka();
            this.AfterConfirmStruka();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [STRUKA]  WHERE [IDSTRUKA] = @IDSTRUKA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUKA["IDSTRUKA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsStruka();
            }
            this.OnSTRUKAUpdated(new STRUKAEventArgs(this.rowSTRUKA, StatementType.Delete));
            this.rowSTRUKA.Delete();
            this.sMode35 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode35;
        }

        public virtual int Fill(STRUKADataSet dataSet)
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
                    this.STRUKASet = dataSet;
                    this.LoadChildStruka(0, -1);
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
            this.STRUKASet = (STRUKADataSet) dataSet;
            if (this.STRUKASet != null)
            {
                return this.Fill(this.STRUKASet);
            }
            this.STRUKASet = new STRUKADataSet();
            this.Fill(this.STRUKASet);
            dataSet.Merge(this.STRUKASet);
            return 0;
        }

        public virtual int Fill(STRUKADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSTRUKA"]));
        }

        public virtual int Fill(STRUKADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSTRUKA"]));
        }

        public virtual int Fill(STRUKADataSet dataSet, int iDSTRUKA)
        {
            if (!this.FillByIDSTRUKA(dataSet, iDSTRUKA))
            {
                throw new STRUKANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRUKA") }));
            }
            return 0;
        }

        public virtual bool FillByIDSTRUKA(STRUKADataSet dataSet, int iDSTRUKA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.STRUKASet = dataSet;
            this.rowSTRUKA = this.STRUKASet.STRUKA.NewSTRUKARow();
            this.rowSTRUKA.IDSTRUKA = iDSTRUKA;
            try
            {
                this.LoadByIDSTRUKA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound35 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(STRUKADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.STRUKASet = dataSet;
            try
            {
                this.LoadChildStruka(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSTRUKA], [NAZIVSTRUKA] FROM [STRUKA] WITH (NOLOCK) WHERE [IDSTRUKA] = @IDSTRUKA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUKA["IDSTRUKA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound35 = 1;
                this.rowSTRUKA["IDSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowSTRUKA["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode35 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode35;
            }
            else
            {
                this.RcdFound35 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDSTRUKA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSTRUKASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [STRUKA] WITH (NOLOCK) ", false);
            this.STRUKASelect1 = this.cmSTRUKASelect1.FetchData();
            if (this.STRUKASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.STRUKASelect1.GetInt32(0);
            }
            this.STRUKASelect1.Close();
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
            this.RcdFound35 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVSTRUKAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.STRUKASet = new STRUKADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertStruka()
        {
            this.CheckOptimisticConcurrencyStruka();
            this.AfterConfirmStruka();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [STRUKA] ([IDSTRUKA], [NAZIVSTRUKA]) VALUES (@IDSTRUKA, @NAZIVSTRUKA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSTRUKA", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUKA["IDSTRUKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSTRUKA["NAZIVSTRUKA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new STRUKADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnSTRUKAUpdated(new STRUKAEventArgs(this.rowSTRUKA, StatementType.Insert));
        }

        private void LoadByIDSTRUKA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.STRUKASet.EnforceConstraints;
            this.STRUKASet.STRUKA.BeginLoadData();
            this.ScanByIDSTRUKA(startRow, maxRows);
            this.STRUKASet.STRUKA.EndLoadData();
            this.STRUKASet.EnforceConstraints = enforceConstraints;
            if (this.STRUKASet.STRUKA.Count > 0)
            {
                this.rowSTRUKA = this.STRUKASet.STRUKA[this.STRUKASet.STRUKA.Count - 1];
            }
        }

        private void LoadChildStruka(int startRow, int maxRows)
        {
            this.CreateNewRowStruka();
            bool enforceConstraints = this.STRUKASet.EnforceConstraints;
            this.STRUKASet.STRUKA.BeginLoadData();
            this.ScanStartStruka(startRow, maxRows);
            this.STRUKASet.STRUKA.EndLoadData();
            this.STRUKASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataStruka(int maxRows)
        {
            int num = 0;
            if (this.RcdFound35 != 0)
            {
                this.ScanLoadStruka();
                while ((this.RcdFound35 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowStruka();
                    this.CreateNewRowStruka();
                    this.ScanNextStruka();
                }
            }
            if (num > 0)
            {
                this.RcdFound35 = 1;
            }
            this.ScanEndStruka();
            if (this.STRUKASet.STRUKA.Count > 0)
            {
                this.rowSTRUKA = this.STRUKASet.STRUKA[this.STRUKASet.STRUKA.Count - 1];
            }
        }

        private void LoadRowStruka()
        {
            this.AddRowStruka();
        }

        private void OnSTRUKAUpdated(STRUKAEventArgs e)
        {
            if (this.STRUKAUpdated != null)
            {
                STRUKAUpdateEventHandler sTRUKAUpdatedEvent = this.STRUKAUpdated;
                if (sTRUKAUpdatedEvent != null)
                {
                    sTRUKAUpdatedEvent(this, e);
                }
            }
        }

        private void OnSTRUKAUpdating(STRUKAEventArgs e)
        {
            if (this.STRUKAUpdating != null)
            {
                STRUKAUpdateEventHandler sTRUKAUpdatingEvent = this.STRUKAUpdating;
                if (sTRUKAUpdatingEvent != null)
                {
                    sTRUKAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowStruka()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSTRUKA.RowState);
            if (this.rowSTRUKA.RowState != DataRowState.Added)
            {
                this.m__NAZIVSTRUKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSTRUKA["NAZIVSTRUKA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVSTRUKAOriginal = RuntimeHelpers.GetObjectValue(this.rowSTRUKA["NAZIVSTRUKA"]);
            }
            this._Gxremove = this.rowSTRUKA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowSTRUKA = (STRUKADataSet.STRUKARow) DataSetUtil.CloneOriginalDataRow(this.rowSTRUKA);
            }
        }

        private void ScanByIDSTRUKA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDSTRUKA] = @IDSTRUKA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString35 + "  FROM [STRUKA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRUKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString35, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSTRUKA] ) AS DK_PAGENUM   FROM [STRUKA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString35 + " FROM [STRUKA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRUKA] ";
            }
            this.cmSTRUKASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmSTRUKASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmSTRUKASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
            }
            this.cmSTRUKASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUKA["IDSTRUKA"]));
            this.STRUKASelect4 = this.cmSTRUKASelect4.FetchData();
            this.RcdFound35 = 0;
            this.ScanLoadStruka();
            this.LoadDataStruka(maxRows);
        }

        private void ScanEndStruka()
        {
            this.STRUKASelect4.Close();
        }

        private void ScanLoadStruka()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSTRUKASelect4.HasMoreRows)
            {
                this.RcdFound35 = 1;
                this.rowSTRUKA["IDSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.STRUKASelect4, 0));
                this.rowSTRUKA["NAZIVSTRUKA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.STRUKASelect4, 1));
            }
        }

        private void ScanNextStruka()
        {
            this.cmSTRUKASelect4.HasMoreRows = this.STRUKASelect4.Read();
            this.RcdFound35 = 0;
            this.ScanLoadStruka();
        }

        private void ScanStartStruka(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString35 + "  FROM [STRUKA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRUKA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString35, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSTRUKA] ) AS DK_PAGENUM   FROM [STRUKA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString35 + " FROM [STRUKA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRUKA] ";
            }
            this.cmSTRUKASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.STRUKASelect4 = this.cmSTRUKASelect4.FetchData();
            this.RcdFound35 = 0;
            this.ScanLoadStruka();
            this.LoadDataStruka(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.STRUKASet = (STRUKADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.STRUKASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.STRUKASet.STRUKA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        STRUKADataSet.STRUKARow current = (STRUKADataSet.STRUKARow) enumerator.Current;
                        this.rowSTRUKA = current;
                        if (Helpers.IsRowChanged(this.rowSTRUKA))
                        {
                            this.ReadRowStruka();
                            if (this.rowSTRUKA.RowState == DataRowState.Added)
                            {
                                this.InsertStruka();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateStruka();
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

        private void UpdateStruka()
        {
            this.CheckOptimisticConcurrencyStruka();
            this.AfterConfirmStruka();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [STRUKA] SET [NAZIVSTRUKA]=@NAZIVSTRUKA  WHERE [IDSTRUKA] = @IDSTRUKA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSTRUKA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUKA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUKA["NAZIVSTRUKA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSTRUKA["IDSTRUKA"]));
            command.ExecuteStmt();
            this.OnSTRUKAUpdated(new STRUKAEventArgs(this.rowSTRUKA, StatementType.Update));
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
        public class STRUKADataChangedException : DataChangedException
        {
            public STRUKADataChangedException()
            {
            }

            public STRUKADataChangedException(string message) : base(message)
            {
            }

            protected STRUKADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRUKADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class STRUKADataLockedException : DataLockedException
        {
            public STRUKADataLockedException()
            {
            }

            public STRUKADataLockedException(string message) : base(message)
            {
            }

            protected STRUKADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRUKADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class STRUKADuplicateKeyException : DuplicateKeyException
        {
            public STRUKADuplicateKeyException()
            {
            }

            public STRUKADuplicateKeyException(string message) : base(message)
            {
            }

            protected STRUKADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRUKADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class STRUKAEventArgs : EventArgs
        {
            private STRUKADataSet.STRUKARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public STRUKAEventArgs(STRUKADataSet.STRUKARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public STRUKADataSet.STRUKARow Row
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
        public class STRUKANotFoundException : DataNotFoundException
        {
            public STRUKANotFoundException()
            {
            }

            public STRUKANotFoundException(string message) : base(message)
            {
            }

            protected STRUKANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRUKANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void STRUKAUpdateEventHandler(object sender, STRUKADataAdapter.STRUKAEventArgs e);
    }
}

