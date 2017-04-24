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

    public class IPIDENTDataAdapter : IDataAdapter, IIPIDENTDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmIPIDENTSelect1;
        private ReadWriteCommand cmIPIDENTSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private IDataReader IPIDENTSelect1;
        private IDataReader IPIDENTSelect4;
        private IPIDENTDataSet IPIDENTSet;
        private object m__NAZIVIPIDENTOriginal;
        private readonly string m_SelectString58 = "TM1.[IDIPIDENT], TM1.[NAZIVIPIDENT]";
        private string m_WhereString;
        private short RcdFound58;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private IPIDENTDataSet.IPIDENTRow rowIPIDENT;
        private string scmdbuf;
        private StatementType sMode58;

        public event IPIDENTUpdateEventHandler IPIDENTUpdated;

        public event IPIDENTUpdateEventHandler IPIDENTUpdating;

        private void AddRowIpident()
        {
            this.IPIDENTSet.IPIDENT.AddIPIDENTRow(this.rowIPIDENT);
        }

        private void AfterConfirmIpident()
        {
            this.OnIPIDENTUpdating(new IPIDENTEventArgs(this.rowIPIDENT, this.Gx_mode));
        }

        private void CheckDeleteErrorsIpident()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [IDIPIDENT] = @IDIPIDENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIPIDENT["IDIPIDENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyIpident()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDIPIDENT], [NAZIVIPIDENT] FROM [IPIDENT] WITH (UPDLOCK) WHERE [IDIPIDENT] = @IDIPIDENT ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIPIDENT["IDIPIDENT"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new IPIDENTDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("IPIDENT") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVIPIDENTOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new IPIDENTDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("IPIDENT") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowIpident()
        {
            this.rowIPIDENT = this.IPIDENTSet.IPIDENT.NewIPIDENTRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyIpident();
            this.AfterConfirmIpident();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [IPIDENT]  WHERE [IDIPIDENT] = @IDIPIDENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIPIDENT["IDIPIDENT"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsIpident();
            }
            this.OnIPIDENTUpdated(new IPIDENTEventArgs(this.rowIPIDENT, StatementType.Delete));
            this.rowIPIDENT.Delete();
            this.sMode58 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode58;
        }


        public virtual int Fill(IPIDENTDataSet dataSet)
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
                    this.IPIDENTSet = dataSet;
                    this.LoadChildIpident(0, -1);
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
            this.IPIDENTSet = (IPIDENTDataSet) dataSet;
            if (this.IPIDENTSet != null)
            {
                return this.Fill(this.IPIDENTSet);
            }
            this.IPIDENTSet = new IPIDENTDataSet();
            this.Fill(this.IPIDENTSet);
            dataSet.Merge(this.IPIDENTSet);
            return 0;
        }

        public virtual int Fill(IPIDENTDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDIPIDENT"]));
        }

        public virtual int Fill(IPIDENTDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDIPIDENT"]));
        }

        public virtual int Fill(IPIDENTDataSet dataSet, int iDIPIDENT)
        {
            if (!this.FillByIDIPIDENT(dataSet, iDIPIDENT))
            {
                throw new IPIDENTNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("IPIDENT") }));
            }
            return 0;
        }

        public virtual bool FillByIDIPIDENT(IPIDENTDataSet dataSet, int iDIPIDENT)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IPIDENTSet = dataSet;
            this.rowIPIDENT = this.IPIDENTSet.IPIDENT.NewIPIDENTRow();
            this.rowIPIDENT.IDIPIDENT = iDIPIDENT;
            try
            {
                this.LoadByIDIPIDENT(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound58 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(IPIDENTDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.IPIDENTSet = dataSet;
            try
            {
                this.LoadChildIpident(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDIPIDENT], [NAZIVIPIDENT] FROM [IPIDENT] WITH (NOLOCK) WHERE [IDIPIDENT] = @IDIPIDENT ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIPIDENT["IDIPIDENT"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound58 = 1;
                this.rowIPIDENT["IDIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowIPIDENT["NAZIVIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode58 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode58;
            }
            else
            {
                this.RcdFound58 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDIPIDENT";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmIPIDENTSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [IPIDENT] WITH (NOLOCK) ", false);
            this.IPIDENTSelect1 = this.cmIPIDENTSelect1.FetchData();
            if (this.IPIDENTSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.IPIDENTSelect1.GetInt32(0);
            }
            this.IPIDENTSelect1.Close();
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
            this.RcdFound58 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVIPIDENTOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.IPIDENTSet = new IPIDENTDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertIpident()
        {
            this.CheckOptimisticConcurrencyIpident();
            this.AfterConfirmIpident();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [IPIDENT] ([IDIPIDENT], [NAZIVIPIDENT]) VALUES (@IDIPIDENT, @NAZIVIPIDENT)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVIPIDENT", DbType.String, 20));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIPIDENT["IDIPIDENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowIPIDENT["NAZIVIPIDENT"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new IPIDENTDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnIPIDENTUpdated(new IPIDENTEventArgs(this.rowIPIDENT, StatementType.Insert));
        }

        private void LoadByIDIPIDENT(int startRow, int maxRows)
        {
            bool enforceConstraints = this.IPIDENTSet.EnforceConstraints;
            this.IPIDENTSet.IPIDENT.BeginLoadData();
            this.ScanByIDIPIDENT(startRow, maxRows);
            this.IPIDENTSet.IPIDENT.EndLoadData();
            this.IPIDENTSet.EnforceConstraints = enforceConstraints;
            if (this.IPIDENTSet.IPIDENT.Count > 0)
            {
                this.rowIPIDENT = this.IPIDENTSet.IPIDENT[this.IPIDENTSet.IPIDENT.Count - 1];
            }
        }

        private void LoadChildIpident(int startRow, int maxRows)
        {
            this.CreateNewRowIpident();
            bool enforceConstraints = this.IPIDENTSet.EnforceConstraints;
            this.IPIDENTSet.IPIDENT.BeginLoadData();
            this.ScanStartIpident(startRow, maxRows);
            this.IPIDENTSet.IPIDENT.EndLoadData();
            this.IPIDENTSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataIpident(int maxRows)
        {
            int num = 0;
            if (this.RcdFound58 != 0)
            {
                this.ScanLoadIpident();
                while ((this.RcdFound58 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowIpident();
                    this.CreateNewRowIpident();
                    this.ScanNextIpident();
                }
            }
            if (num > 0)
            {
                this.RcdFound58 = 1;
            }
            this.ScanEndIpident();
            if (this.IPIDENTSet.IPIDENT.Count > 0)
            {
                this.rowIPIDENT = this.IPIDENTSet.IPIDENT[this.IPIDENTSet.IPIDENT.Count - 1];
            }
        }

        private void LoadRowIpident()
        {
            this.AddRowIpident();
        }

        private void OnIPIDENTUpdated(IPIDENTEventArgs e)
        {
            if (this.IPIDENTUpdated != null)
            {
                IPIDENTUpdateEventHandler iPIDENTUpdatedEvent = this.IPIDENTUpdated;
                if (iPIDENTUpdatedEvent != null)
                {
                    iPIDENTUpdatedEvent(this, e);
                }
            }
        }

        private void OnIPIDENTUpdating(IPIDENTEventArgs e)
        {
            if (this.IPIDENTUpdating != null)
            {
                IPIDENTUpdateEventHandler iPIDENTUpdatingEvent = this.IPIDENTUpdating;
                if (iPIDENTUpdatingEvent != null)
                {
                    iPIDENTUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowIpident()
        {
            this.Gx_mode = Mode.FromRowState(this.rowIPIDENT.RowState);
            if (this.rowIPIDENT.RowState != DataRowState.Added)
            {
                this.m__NAZIVIPIDENTOriginal = RuntimeHelpers.GetObjectValue(this.rowIPIDENT["NAZIVIPIDENT", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVIPIDENTOriginal = RuntimeHelpers.GetObjectValue(this.rowIPIDENT["NAZIVIPIDENT"]);
            }
            this._Gxremove = this.rowIPIDENT.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowIPIDENT = (IPIDENTDataSet.IPIDENTRow) DataSetUtil.CloneOriginalDataRow(this.rowIPIDENT);
            }
        }

        private void ScanByIDIPIDENT(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDIPIDENT] = @IDIPIDENT";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString58 + "  FROM [IPIDENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDIPIDENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString58, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDIPIDENT] ) AS DK_PAGENUM   FROM [IPIDENT] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString58 + " FROM [IPIDENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDIPIDENT] ";
            }
            this.cmIPIDENTSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmIPIDENTSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmIPIDENTSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
            }
            this.cmIPIDENTSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIPIDENT["IDIPIDENT"]));
            this.IPIDENTSelect4 = this.cmIPIDENTSelect4.FetchData();
            this.RcdFound58 = 0;
            this.ScanLoadIpident();
            this.LoadDataIpident(maxRows);
        }

        private void ScanEndIpident()
        {
            this.IPIDENTSelect4.Close();
        }

        private void ScanLoadIpident()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmIPIDENTSelect4.HasMoreRows)
            {
                this.RcdFound58 = 1;
                this.rowIPIDENT["IDIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.IPIDENTSelect4, 0));
                this.rowIPIDENT["NAZIVIPIDENT"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.IPIDENTSelect4, 1));
            }
        }

        private void ScanNextIpident()
        {
            this.cmIPIDENTSelect4.HasMoreRows = this.IPIDENTSelect4.Read();
            this.RcdFound58 = 0;
            this.ScanLoadIpident();
        }

        private void ScanStartIpident(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString58 + "  FROM [IPIDENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDIPIDENT]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString58, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDIPIDENT] ) AS DK_PAGENUM   FROM [IPIDENT] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString58 + " FROM [IPIDENT] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDIPIDENT] ";
            }
            this.cmIPIDENTSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.IPIDENTSelect4 = this.cmIPIDENTSelect4.FetchData();
            this.RcdFound58 = 0;
            this.ScanLoadIpident();
            this.LoadDataIpident(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.IPIDENTSet = (IPIDENTDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.IPIDENTSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.IPIDENTSet.IPIDENT.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        IPIDENTDataSet.IPIDENTRow current = (IPIDENTDataSet.IPIDENTRow) enumerator.Current;
                        this.rowIPIDENT = current;
                        if (Helpers.IsRowChanged(this.rowIPIDENT))
                        {
                            this.ReadRowIpident();
                            if (this.rowIPIDENT.RowState == DataRowState.Added)
                            {
                                this.InsertIpident();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateIpident();
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

        private void UpdateIpident()
        {
            this.CheckOptimisticConcurrencyIpident();
            this.AfterConfirmIpident();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [IPIDENT] SET [NAZIVIPIDENT]=@NAZIVIPIDENT  WHERE [IDIPIDENT] = @IDIPIDENT", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVIPIDENT", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDIPIDENT", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowIPIDENT["NAZIVIPIDENT"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowIPIDENT["IDIPIDENT"]));
            command.ExecuteStmt();
            this.OnIPIDENTUpdated(new IPIDENTEventArgs(this.rowIPIDENT, StatementType.Update));
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
        public class IPIDENTDataChangedException : DataChangedException
        {
            public IPIDENTDataChangedException()
            {
            }

            public IPIDENTDataChangedException(string message) : base(message)
            {
            }

            protected IPIDENTDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IPIDENTDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class IPIDENTDataLockedException : DataLockedException
        {
            public IPIDENTDataLockedException()
            {
            }

            public IPIDENTDataLockedException(string message) : base(message)
            {
            }

            protected IPIDENTDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IPIDENTDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class IPIDENTDuplicateKeyException : DuplicateKeyException
        {
            public IPIDENTDuplicateKeyException()
            {
            }

            public IPIDENTDuplicateKeyException(string message) : base(message)
            {
            }

            protected IPIDENTDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IPIDENTDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class IPIDENTEventArgs : EventArgs
        {
            private IPIDENTDataSet.IPIDENTRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public IPIDENTEventArgs(IPIDENTDataSet.IPIDENTRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public IPIDENTDataSet.IPIDENTRow Row
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
        public class IPIDENTNotFoundException : DataNotFoundException
        {
            public IPIDENTNotFoundException()
            {
            }

            public IPIDENTNotFoundException(string message) : base(message)
            {
            }

            protected IPIDENTNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public IPIDENTNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void IPIDENTUpdateEventHandler(object sender, IPIDENTDataAdapter.IPIDENTEventArgs e);

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

