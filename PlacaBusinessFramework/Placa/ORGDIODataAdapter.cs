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

    public class ORGDIODataAdapter : IDataAdapter, IORGDIODataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmORGDIOSelect1;
        private ReadWriteCommand cmORGDIOSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__ORGANIZACIJSKIDIOOriginal;
        private readonly string m_SelectString17 = "TM1.[IDORGDIO], TM1.[ORGANIZACIJSKIDIO]";
        private string m_WhereString;
        private IDataReader ORGDIOSelect1;
        private IDataReader ORGDIOSelect4;
        private ORGDIODataSet ORGDIOSet;
        private short RcdFound17;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private ORGDIODataSet.ORGDIORow rowORGDIO;
        private string scmdbuf;
        private StatementType sMode17;

        public event ORGDIOUpdateEventHandler ORGDIOUpdated;

        public event ORGDIOUpdateEventHandler ORGDIOUpdating;

        private void AddRowOrgdio()
        {
            this.ORGDIOSet.ORGDIO.AddORGDIORow(this.rowORGDIO);
        }

        private void AfterConfirmOrgdio()
        {
            this.OnORGDIOUpdating(new ORGDIOEventArgs(this.rowORGDIO, this.Gx_mode));
        }

        private void CheckDeleteErrorsOrgdio()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [IDORGDIO] = @IDORGDIO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGDIO["IDORGDIO"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyOrgdio()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDORGDIO], [ORGANIZACIJSKIDIO] FROM [ORGDIO] WITH (UPDLOCK) WHERE [IDORGDIO] = @IDORGDIO ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGDIO["IDORGDIO"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new ORGDIODataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("ORGDIO") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__ORGANIZACIJSKIDIOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new ORGDIODataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("ORGDIO") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowOrgdio()
        {
            this.rowORGDIO = this.ORGDIOSet.ORGDIO.NewORGDIORow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyOrgdio();
            this.AfterConfirmOrgdio();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [ORGDIO]  WHERE [IDORGDIO] = @IDORGDIO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGDIO["IDORGDIO"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsOrgdio();
            }
            this.OnORGDIOUpdated(new ORGDIOEventArgs(this.rowORGDIO, StatementType.Delete));
            this.rowORGDIO.Delete();
            this.sMode17 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode17;
        }

        public virtual int Fill(ORGDIODataSet dataSet)
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
                    this.ORGDIOSet = dataSet;
                    this.LoadChildOrgdio(0, -1);
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
            this.ORGDIOSet = (ORGDIODataSet) dataSet;
            if (this.ORGDIOSet != null)
            {
                return this.Fill(this.ORGDIOSet);
            }
            this.ORGDIOSet = new ORGDIODataSet();
            this.Fill(this.ORGDIOSet);
            dataSet.Merge(this.ORGDIOSet);
            return 0;
        }

        public virtual int Fill(ORGDIODataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDORGDIO"]));
        }

        public virtual int Fill(ORGDIODataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDORGDIO"]));
        }

        public virtual int Fill(ORGDIODataSet dataSet, int iDORGDIO)
        {
            if (!this.FillByIDORGDIO(dataSet, iDORGDIO))
            {
                throw new ORGDIONotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("ORGDIO") }));
            }
            return 0;
        }

        public virtual bool FillByIDORGDIO(ORGDIODataSet dataSet, int iDORGDIO)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ORGDIOSet = dataSet;
            this.rowORGDIO = this.ORGDIOSet.ORGDIO.NewORGDIORow();
            this.rowORGDIO.IDORGDIO = iDORGDIO;
            try
            {
                this.LoadByIDORGDIO(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound17 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(ORGDIODataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.ORGDIOSet = dataSet;
            try
            {
                this.LoadChildOrgdio(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDORGDIO], [ORGANIZACIJSKIDIO] FROM [ORGDIO] WITH (NOLOCK) WHERE [IDORGDIO] = @IDORGDIO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGDIO["IDORGDIO"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound17 = 1;
                this.rowORGDIO["IDORGDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowORGDIO["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode17 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode17;
            }
            else
            {
                this.RcdFound17 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDORGDIO";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmORGDIOSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [ORGDIO] WITH (NOLOCK) ", false);
            this.ORGDIOSelect1 = this.cmORGDIOSelect1.FetchData();
            if (this.ORGDIOSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.ORGDIOSelect1.GetInt32(0);
            }
            this.ORGDIOSelect1.Close();
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
            this.RcdFound17 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__ORGANIZACIJSKIDIOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.ORGDIOSet = new ORGDIODataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertOrgdio()
        {
            this.CheckOptimisticConcurrencyOrgdio();
            this.AfterConfirmOrgdio();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [ORGDIO] ([IDORGDIO], [ORGANIZACIJSKIDIO]) VALUES (@IDORGDIO, @ORGANIZACIJSKIDIO)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORGANIZACIJSKIDIO", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGDIO["IDORGDIO"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowORGDIO["ORGANIZACIJSKIDIO"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new ORGDIODuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnORGDIOUpdated(new ORGDIOEventArgs(this.rowORGDIO, StatementType.Insert));
        }

        private void LoadByIDORGDIO(int startRow, int maxRows)
        {
            bool enforceConstraints = this.ORGDIOSet.EnforceConstraints;
            this.ORGDIOSet.ORGDIO.BeginLoadData();
            this.ScanByIDORGDIO(startRow, maxRows);
            this.ORGDIOSet.ORGDIO.EndLoadData();
            this.ORGDIOSet.EnforceConstraints = enforceConstraints;
            if (this.ORGDIOSet.ORGDIO.Count > 0)
            {
                this.rowORGDIO = this.ORGDIOSet.ORGDIO[this.ORGDIOSet.ORGDIO.Count - 1];
            }
        }

        private void LoadChildOrgdio(int startRow, int maxRows)
        {
            this.CreateNewRowOrgdio();
            bool enforceConstraints = this.ORGDIOSet.EnforceConstraints;
            this.ORGDIOSet.ORGDIO.BeginLoadData();
            this.ScanStartOrgdio(startRow, maxRows);
            this.ORGDIOSet.ORGDIO.EndLoadData();
            this.ORGDIOSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataOrgdio(int maxRows)
        {
            int num = 0;
            if (this.RcdFound17 != 0)
            {
                this.ScanLoadOrgdio();
                while ((this.RcdFound17 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowOrgdio();
                    this.CreateNewRowOrgdio();
                    this.ScanNextOrgdio();
                }
            }
            if (num > 0)
            {
                this.RcdFound17 = 1;
            }
            this.ScanEndOrgdio();
            if (this.ORGDIOSet.ORGDIO.Count > 0)
            {
                this.rowORGDIO = this.ORGDIOSet.ORGDIO[this.ORGDIOSet.ORGDIO.Count - 1];
            }
        }

        private void LoadRowOrgdio()
        {
            this.AddRowOrgdio();
        }

        private void OnORGDIOUpdated(ORGDIOEventArgs e)
        {
            if (this.ORGDIOUpdated != null)
            {
                ORGDIOUpdateEventHandler oRGDIOUpdatedEvent = this.ORGDIOUpdated;
                if (oRGDIOUpdatedEvent != null)
                {
                    oRGDIOUpdatedEvent(this, e);
                }
            }
        }

        private void OnORGDIOUpdating(ORGDIOEventArgs e)
        {
            if (this.ORGDIOUpdating != null)
            {
                ORGDIOUpdateEventHandler oRGDIOUpdatingEvent = this.ORGDIOUpdating;
                if (oRGDIOUpdatingEvent != null)
                {
                    oRGDIOUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowOrgdio()
        {
            this.Gx_mode = Mode.FromRowState(this.rowORGDIO.RowState);
            if (this.rowORGDIO.RowState != DataRowState.Added)
            {
                this.m__ORGANIZACIJSKIDIOOriginal = RuntimeHelpers.GetObjectValue(this.rowORGDIO["ORGANIZACIJSKIDIO", DataRowVersion.Original]);
            }
            else
            {
                this.m__ORGANIZACIJSKIDIOOriginal = RuntimeHelpers.GetObjectValue(this.rowORGDIO["ORGANIZACIJSKIDIO"]);
            }
            this._Gxremove = this.rowORGDIO.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowORGDIO = (ORGDIODataSet.ORGDIORow) DataSetUtil.CloneOriginalDataRow(this.rowORGDIO);
            }
        }

        private void ScanByIDORGDIO(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDORGDIO] = @IDORGDIO";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString17 + "  FROM [ORGDIO] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDORGDIO]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString17, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDORGDIO] ) AS DK_PAGENUM   FROM [ORGDIO] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString17 + " FROM [ORGDIO] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDORGDIO] ";
            }
            this.cmORGDIOSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmORGDIOSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmORGDIOSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
            }
            this.cmORGDIOSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGDIO["IDORGDIO"]));
            this.ORGDIOSelect4 = this.cmORGDIOSelect4.FetchData();
            this.RcdFound17 = 0;
            this.ScanLoadOrgdio();
            this.LoadDataOrgdio(maxRows);
        }

        private void ScanEndOrgdio()
        {
            this.ORGDIOSelect4.Close();
        }

        private void ScanLoadOrgdio()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmORGDIOSelect4.HasMoreRows)
            {
                this.RcdFound17 = 1;
                this.rowORGDIO["IDORGDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.ORGDIOSelect4, 0));
                this.rowORGDIO["ORGANIZACIJSKIDIO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.ORGDIOSelect4, 1));
            }
        }

        private void ScanNextOrgdio()
        {
            this.cmORGDIOSelect4.HasMoreRows = this.ORGDIOSelect4.Read();
            this.RcdFound17 = 0;
            this.ScanLoadOrgdio();
        }

        private void ScanStartOrgdio(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString17 + "  FROM [ORGDIO] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDORGDIO]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString17, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDORGDIO] ) AS DK_PAGENUM   FROM [ORGDIO] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString17 + " FROM [ORGDIO] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDORGDIO] ";
            }
            this.cmORGDIOSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.ORGDIOSelect4 = this.cmORGDIOSelect4.FetchData();
            this.RcdFound17 = 0;
            this.ScanLoadOrgdio();
            this.LoadDataOrgdio(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.ORGDIOSet = (ORGDIODataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.ORGDIOSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.ORGDIOSet.ORGDIO.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        ORGDIODataSet.ORGDIORow current = (ORGDIODataSet.ORGDIORow) enumerator.Current;
                        this.rowORGDIO = current;
                        if (Helpers.IsRowChanged(this.rowORGDIO))
                        {
                            this.ReadRowOrgdio();
                            if (this.rowORGDIO.RowState == DataRowState.Added)
                            {
                                this.InsertOrgdio();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateOrgdio();
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

        private void UpdateOrgdio()
        {
            this.CheckOptimisticConcurrencyOrgdio();
            this.AfterConfirmOrgdio();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [ORGDIO] SET [ORGANIZACIJSKIDIO]=@ORGANIZACIJSKIDIO  WHERE [IDORGDIO] = @IDORGDIO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@ORGANIZACIJSKIDIO", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDORGDIO", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowORGDIO["ORGANIZACIJSKIDIO"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowORGDIO["IDORGDIO"]));
            command.ExecuteStmt();
            this.OnORGDIOUpdated(new ORGDIOEventArgs(this.rowORGDIO, StatementType.Update));
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
        public class ORGDIODataChangedException : DataChangedException
        {
            public ORGDIODataChangedException()
            {
            }

            public ORGDIODataChangedException(string message) : base(message)
            {
            }

            protected ORGDIODataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ORGDIODataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ORGDIODataLockedException : DataLockedException
        {
            public ORGDIODataLockedException()
            {
            }

            public ORGDIODataLockedException(string message) : base(message)
            {
            }

            protected ORGDIODataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ORGDIODataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class ORGDIODuplicateKeyException : DuplicateKeyException
        {
            public ORGDIODuplicateKeyException()
            {
            }

            public ORGDIODuplicateKeyException(string message) : base(message)
            {
            }

            protected ORGDIODuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ORGDIODuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class ORGDIOEventArgs : EventArgs
        {
            private ORGDIODataSet.ORGDIORow m_dataRow;
            private System.Data.StatementType m_statementType;

            public ORGDIOEventArgs(ORGDIODataSet.ORGDIORow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public ORGDIODataSet.ORGDIORow Row
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
        public class ORGDIONotFoundException : DataNotFoundException
        {
            public ORGDIONotFoundException()
            {
            }

            public ORGDIONotFoundException(string message) : base(message)
            {
            }

            protected ORGDIONotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public ORGDIONotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void ORGDIOUpdateEventHandler(object sender, ORGDIODataAdapter.ORGDIOEventArgs e);

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
    }
}

