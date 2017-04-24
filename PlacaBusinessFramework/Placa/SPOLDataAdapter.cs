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

    public class SPOLDataAdapter : IDataAdapter, ISPOLDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmSPOLSelect1;
        private ReadWriteCommand cmSPOLSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVSPOLOriginal;
        private readonly string m_SelectString57 = "TM1.[IDSPOL], TM1.[NAZIVSPOL]";
        private string m_WhereString;
        private short RcdFound57;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private SPOLDataSet.SPOLRow rowSPOL;
        private string scmdbuf;
        private StatementType sMode57;
        private IDataReader SPOLSelect1;
        private IDataReader SPOLSelect4;
        private SPOLDataSet SPOLSet;

        public event SPOLUpdateEventHandler SPOLUpdated;

        public event SPOLUpdateEventHandler SPOLUpdating;

        private void AddRowSpol()
        {
            this.SPOLSet.SPOL.AddSPOLRow(this.rowSPOL);
        }

        private void AfterConfirmSpol()
        {
            this.OnSPOLUpdating(new SPOLEventArgs(this.rowSPOL, this.Gx_mode));
        }

        private void CheckDeleteErrorsSpol()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [IDSPOL] = @IDSPOL ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSPOL["IDSPOL"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader2.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [RAD1SPOLID], [IDSPOL] FROM [RAD1VEZASPOL] WITH (NOLOCK) WHERE [IDSPOL] = @IDSPOL ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSPOL["IDSPOL"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RAD1VEZASPOLInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RAD1VEZASPOL" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencySpol()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSPOL], [NAZIVSPOL] FROM [SPOL] WITH (UPDLOCK) WHERE [IDSPOL] = @IDSPOL ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSPOL["IDSPOL"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new SPOLDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("SPOL") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVSPOLOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new SPOLDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("SPOL") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowSpol()
        {
            this.rowSPOL = this.SPOLSet.SPOL.NewSPOLRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencySpol();
            this.AfterConfirmSpol();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [SPOL]  WHERE [IDSPOL] = @IDSPOL", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSPOL["IDSPOL"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsSpol();
            }
            this.OnSPOLUpdated(new SPOLEventArgs(this.rowSPOL, StatementType.Delete));
            this.rowSPOL.Delete();
            this.sMode57 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode57;
        }

        public virtual int Fill(SPOLDataSet dataSet)
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
                    this.SPOLSet = dataSet;
                    this.LoadChildSpol(0, -1);
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
            this.SPOLSet = (SPOLDataSet) dataSet;
            if (this.SPOLSet != null)
            {
                return this.Fill(this.SPOLSet);
            }
            this.SPOLSet = new SPOLDataSet();
            this.Fill(this.SPOLSet);
            dataSet.Merge(this.SPOLSet);
            return 0;
        }

        public virtual int Fill(SPOLDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSPOL"]));
        }

        public virtual int Fill(SPOLDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSPOL"]));
        }

        public virtual int Fill(SPOLDataSet dataSet, int iDSPOL)
        {
            if (!this.FillByIDSPOL(dataSet, iDSPOL))
            {
                throw new SPOLNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("SPOL") }));
            }
            return 0;
        }

        public virtual bool FillByIDSPOL(SPOLDataSet dataSet, int iDSPOL)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SPOLSet = dataSet;
            this.rowSPOL = this.SPOLSet.SPOL.NewSPOLRow();
            this.rowSPOL.IDSPOL = iDSPOL;
            try
            {
                this.LoadByIDSPOL(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound57 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(SPOLDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.SPOLSet = dataSet;
            try
            {
                this.LoadChildSpol(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSPOL], [NAZIVSPOL] FROM [SPOL] WITH (NOLOCK) WHERE [IDSPOL] = @IDSPOL ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSPOL["IDSPOL"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound57 = 1;
                this.rowSPOL["IDSPOL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowSPOL["NAZIVSPOL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode57 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode57;
            }
            else
            {
                this.RcdFound57 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDSPOL";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSPOLSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [SPOL] WITH (NOLOCK) ", false);
            this.SPOLSelect1 = this.cmSPOLSelect1.FetchData();
            if (this.SPOLSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.SPOLSelect1.GetInt32(0);
            }
            this.SPOLSelect1.Close();
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
            this.RcdFound57 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVSPOLOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.SPOLSet = new SPOLDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertSpol()
        {
            this.CheckOptimisticConcurrencySpol();
            this.AfterConfirmSpol();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [SPOL] ([IDSPOL], [NAZIVSPOL]) VALUES (@IDSPOL, @NAZIVSPOL)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSPOL", DbType.String, 20));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSPOL["IDSPOL"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSPOL["NAZIVSPOL"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new SPOLDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnSPOLUpdated(new SPOLEventArgs(this.rowSPOL, StatementType.Insert));
        }

        private void LoadByIDSPOL(int startRow, int maxRows)
        {
            bool enforceConstraints = this.SPOLSet.EnforceConstraints;
            this.SPOLSet.SPOL.BeginLoadData();
            this.ScanByIDSPOL(startRow, maxRows);
            this.SPOLSet.SPOL.EndLoadData();
            this.SPOLSet.EnforceConstraints = enforceConstraints;
            if (this.SPOLSet.SPOL.Count > 0)
            {
                this.rowSPOL = this.SPOLSet.SPOL[this.SPOLSet.SPOL.Count - 1];
            }
        }

        private void LoadChildSpol(int startRow, int maxRows)
        {
            this.CreateNewRowSpol();
            bool enforceConstraints = this.SPOLSet.EnforceConstraints;
            this.SPOLSet.SPOL.BeginLoadData();
            this.ScanStartSpol(startRow, maxRows);
            this.SPOLSet.SPOL.EndLoadData();
            this.SPOLSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataSpol(int maxRows)
        {
            int num = 0;
            if (this.RcdFound57 != 0)
            {
                this.ScanLoadSpol();
                while ((this.RcdFound57 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowSpol();
                    this.CreateNewRowSpol();
                    this.ScanNextSpol();
                }
            }
            if (num > 0)
            {
                this.RcdFound57 = 1;
            }
            this.ScanEndSpol();
            if (this.SPOLSet.SPOL.Count > 0)
            {
                this.rowSPOL = this.SPOLSet.SPOL[this.SPOLSet.SPOL.Count - 1];
            }
        }

        private void LoadRowSpol()
        {
            this.AddRowSpol();
        }

        private void OnSPOLUpdated(SPOLEventArgs e)
        {
            if (this.SPOLUpdated != null)
            {
                SPOLUpdateEventHandler sPOLUpdatedEvent = this.SPOLUpdated;
                if (sPOLUpdatedEvent != null)
                {
                    sPOLUpdatedEvent(this, e);
                }
            }
        }

        private void OnSPOLUpdating(SPOLEventArgs e)
        {
            if (this.SPOLUpdating != null)
            {
                SPOLUpdateEventHandler sPOLUpdatingEvent = this.SPOLUpdating;
                if (sPOLUpdatingEvent != null)
                {
                    sPOLUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowSpol()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSPOL.RowState);
            if (this.rowSPOL.RowState != DataRowState.Added)
            {
                this.m__NAZIVSPOLOriginal = RuntimeHelpers.GetObjectValue(this.rowSPOL["NAZIVSPOL", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVSPOLOriginal = RuntimeHelpers.GetObjectValue(this.rowSPOL["NAZIVSPOL"]);
            }
            this._Gxremove = this.rowSPOL.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowSPOL = (SPOLDataSet.SPOLRow) DataSetUtil.CloneOriginalDataRow(this.rowSPOL);
            }
        }

        private void ScanByIDSPOL(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDSPOL] = @IDSPOL";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString57 + "  FROM [SPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSPOL]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString57, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSPOL] ) AS DK_PAGENUM   FROM [SPOL] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString57 + " FROM [SPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSPOL] ";
            }
            this.cmSPOLSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmSPOLSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmSPOLSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            this.cmSPOLSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSPOL["IDSPOL"]));
            this.SPOLSelect4 = this.cmSPOLSelect4.FetchData();
            this.RcdFound57 = 0;
            this.ScanLoadSpol();
            this.LoadDataSpol(maxRows);
        }

        private void ScanEndSpol()
        {
            this.SPOLSelect4.Close();
        }

        private void ScanLoadSpol()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSPOLSelect4.HasMoreRows)
            {
                this.RcdFound57 = 1;
                this.rowSPOL["IDSPOL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.SPOLSelect4, 0));
                this.rowSPOL["NAZIVSPOL"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.SPOLSelect4, 1));
            }
        }

        private void ScanNextSpol()
        {
            this.cmSPOLSelect4.HasMoreRows = this.SPOLSelect4.Read();
            this.RcdFound57 = 0;
            this.ScanLoadSpol();
        }

        private void ScanStartSpol(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString57 + "  FROM [SPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSPOL]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString57, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSPOL] ) AS DK_PAGENUM   FROM [SPOL] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString57 + " FROM [SPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSPOL] ";
            }
            this.cmSPOLSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.SPOLSelect4 = this.cmSPOLSelect4.FetchData();
            this.RcdFound57 = 0;
            this.ScanLoadSpol();
            this.LoadDataSpol(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.SPOLSet = (SPOLDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.SPOLSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.SPOLSet.SPOL.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        SPOLDataSet.SPOLRow current = (SPOLDataSet.SPOLRow) enumerator.Current;
                        this.rowSPOL = current;
                        if (Helpers.IsRowChanged(this.rowSPOL))
                        {
                            this.ReadRowSpol();
                            if (this.rowSPOL.RowState == DataRowState.Added)
                            {
                                this.InsertSpol();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateSpol();
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

        private void UpdateSpol()
        {
            this.CheckOptimisticConcurrencySpol();
            this.AfterConfirmSpol();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [SPOL] SET [NAZIVSPOL]=@NAZIVSPOL  WHERE [IDSPOL] = @IDSPOL", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSPOL", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSPOL", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSPOL["NAZIVSPOL"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSPOL["IDSPOL"]));
            command.ExecuteStmt();
            this.OnSPOLUpdated(new SPOLEventArgs(this.rowSPOL, StatementType.Update));
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
        public class RAD1VEZASPOLInvalidDeleteException : InvalidDeleteException
        {
            public RAD1VEZASPOLInvalidDeleteException()
            {
            }

            public RAD1VEZASPOLInvalidDeleteException(string message) : base(message)
            {
            }

            protected RAD1VEZASPOLInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1VEZASPOLInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
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
        public class SPOLDataChangedException : DataChangedException
        {
            public SPOLDataChangedException()
            {
            }

            public SPOLDataChangedException(string message) : base(message)
            {
            }

            protected SPOLDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SPOLDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SPOLDataLockedException : DataLockedException
        {
            public SPOLDataLockedException()
            {
            }

            public SPOLDataLockedException(string message) : base(message)
            {
            }

            protected SPOLDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SPOLDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class SPOLDuplicateKeyException : DuplicateKeyException
        {
            public SPOLDuplicateKeyException()
            {
            }

            public SPOLDuplicateKeyException(string message) : base(message)
            {
            }

            protected SPOLDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SPOLDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class SPOLEventArgs : EventArgs
        {
            private SPOLDataSet.SPOLRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public SPOLEventArgs(SPOLDataSet.SPOLRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public SPOLDataSet.SPOLRow Row
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
        public class SPOLNotFoundException : DataNotFoundException
        {
            public SPOLNotFoundException()
            {
            }

            public SPOLNotFoundException(string message) : base(message)
            {
            }

            protected SPOLNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SPOLNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void SPOLUpdateEventHandler(object sender, SPOLDataAdapter.SPOLEventArgs e);
    }
}

