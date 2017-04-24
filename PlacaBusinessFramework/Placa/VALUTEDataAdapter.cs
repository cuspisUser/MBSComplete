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

    public class VALUTEDataAdapter : IDataAdapter, IVALUTEDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmVALUTESelect1;
        private ReadWriteCommand cmVALUTESelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVVALUTAOriginal;
        private object m__TECAJOriginal;
        private readonly string m_SelectString39 = "TM1.[IDVALUTA], TM1.[NAZIVVALUTA], TM1.[TECAJ]";
        private string m_WhereString;
        private short RcdFound39;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private VALUTEDataSet.VALUTERow rowVALUTE;
        private string scmdbuf;
        private StatementType sMode39;
        private IDataReader VALUTESelect1;
        private IDataReader VALUTESelect4;
        private VALUTEDataSet VALUTESet;

        public event VALUTEUpdateEventHandler VALUTEUpdated;

        public event VALUTEUpdateEventHandler VALUTEUpdating;

        private void AddRowValute()
        {
            this.VALUTESet.VALUTE.AddVALUTERow(this.rowVALUTE);
        }

        private void AfterConfirmValute()
        {
            this.OnVALUTEUpdating(new VALUTEEventArgs(this.rowVALUTE, this.Gx_mode));
        }

        private void CheckOptimisticConcurrencyValute()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDVALUTA], [NAZIVVALUTA], [TECAJ] FROM [VALUTE] WITH (UPDLOCK) WHERE [IDVALUTA] = @IDVALUTA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVALUTA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVALUTE["IDVALUTA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new VALUTEDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("VALUTE") }));
                }
                if ((!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVVALUTAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1)))) || !this.m__TECAJOriginal.Equals(RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2))))
                {
                    reader.Close();
                    throw new VALUTEDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("VALUTE") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowValute()
        {
            this.rowVALUTE = this.VALUTESet.VALUTE.NewVALUTERow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyValute();
            this.AfterConfirmValute();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [VALUTE]  WHERE [IDVALUTA] = @IDVALUTA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVALUTA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVALUTE["IDVALUTA"]));
            command.ExecuteStmt();
            this.OnVALUTEUpdated(new VALUTEEventArgs(this.rowVALUTE, StatementType.Delete));
            this.rowVALUTE.Delete();
            this.sMode39 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode39;
        }

        public virtual int Fill(VALUTEDataSet dataSet)
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
                    this.VALUTESet = dataSet;
                    this.LoadChildValute(0, -1);
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
            this.VALUTESet = (VALUTEDataSet) dataSet;
            if (this.VALUTESet != null)
            {
                return this.Fill(this.VALUTESet);
            }
            this.VALUTESet = new VALUTEDataSet();
            this.Fill(this.VALUTESet);
            dataSet.Merge(this.VALUTESet);
            return 0;
        }

        public virtual int Fill(VALUTEDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDVALUTA"]));
        }

        public virtual int Fill(VALUTEDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDVALUTA"]));
        }

        public virtual int Fill(VALUTEDataSet dataSet, int iDVALUTA)
        {
            if (!this.FillByIDVALUTA(dataSet, iDVALUTA))
            {
                throw new VALUTENotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VALUTE") }));
            }
            return 0;
        }

        public virtual bool FillByIDVALUTA(VALUTEDataSet dataSet, int iDVALUTA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VALUTESet = dataSet;
            this.rowVALUTE = this.VALUTESet.VALUTE.NewVALUTERow();
            this.rowVALUTE.IDVALUTA = iDVALUTA;
            try
            {
                this.LoadByIDVALUTA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound39 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(VALUTEDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VALUTESet = dataSet;
            try
            {
                this.LoadChildValute(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDVALUTA], [NAZIVVALUTA], [TECAJ] FROM [VALUTE] WITH (NOLOCK) WHERE [IDVALUTA] = @IDVALUTA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVALUTA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVALUTE["IDVALUTA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound39 = 1;
                this.rowVALUTE["IDVALUTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowVALUTE["NAZIVVALUTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.rowVALUTE["TECAJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(reader, 2));
                this.sMode39 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode39;
            }
            else
            {
                this.RcdFound39 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDVALUTA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmVALUTESelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [VALUTE] WITH (NOLOCK) ", false);
            this.VALUTESelect1 = this.cmVALUTESelect1.FetchData();
            if (this.VALUTESelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.VALUTESelect1.GetInt32(0);
            }
            this.VALUTESelect1.Close();
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
            this.RcdFound39 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVVALUTAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m__TECAJOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.VALUTESet = new VALUTEDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertValute()
        {
            this.CheckOptimisticConcurrencyValute();
            this.AfterConfirmValute();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [VALUTE] ([IDVALUTA], [NAZIVVALUTA], [TECAJ]) VALUES (@IDVALUTA, @NAZIVVALUTA, @TECAJ)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVALUTA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVALUTA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TECAJ", DbType.Decimal));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVALUTE["IDVALUTA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowVALUTE["NAZIVVALUTA"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowVALUTE["TECAJ"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new VALUTEDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnVALUTEUpdated(new VALUTEEventArgs(this.rowVALUTE, StatementType.Insert));
        }

        private void LoadByIDVALUTA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.VALUTESet.EnforceConstraints;
            this.VALUTESet.VALUTE.BeginLoadData();
            this.ScanByIDVALUTA(startRow, maxRows);
            this.VALUTESet.VALUTE.EndLoadData();
            this.VALUTESet.EnforceConstraints = enforceConstraints;
            if (this.VALUTESet.VALUTE.Count > 0)
            {
                this.rowVALUTE = this.VALUTESet.VALUTE[this.VALUTESet.VALUTE.Count - 1];
            }
        }

        private void LoadChildValute(int startRow, int maxRows)
        {
            this.CreateNewRowValute();
            bool enforceConstraints = this.VALUTESet.EnforceConstraints;
            this.VALUTESet.VALUTE.BeginLoadData();
            this.ScanStartValute(startRow, maxRows);
            this.VALUTESet.VALUTE.EndLoadData();
            this.VALUTESet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataValute(int maxRows)
        {
            int num = 0;
            if (this.RcdFound39 != 0)
            {
                this.ScanLoadValute();
                while ((this.RcdFound39 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowValute();
                    this.CreateNewRowValute();
                    this.ScanNextValute();
                }
            }
            if (num > 0)
            {
                this.RcdFound39 = 1;
            }
            this.ScanEndValute();
            if (this.VALUTESet.VALUTE.Count > 0)
            {
                this.rowVALUTE = this.VALUTESet.VALUTE[this.VALUTESet.VALUTE.Count - 1];
            }
        }

        private void LoadRowValute()
        {
            this.AddRowValute();
        }

        private void OnVALUTEUpdated(VALUTEEventArgs e)
        {
            if (this.VALUTEUpdated != null)
            {
                VALUTEUpdateEventHandler vALUTEUpdatedEvent = this.VALUTEUpdated;
                if (vALUTEUpdatedEvent != null)
                {
                    vALUTEUpdatedEvent(this, e);
                }
            }
        }

        private void OnVALUTEUpdating(VALUTEEventArgs e)
        {
            if (this.VALUTEUpdating != null)
            {
                VALUTEUpdateEventHandler vALUTEUpdatingEvent = this.VALUTEUpdating;
                if (vALUTEUpdatingEvent != null)
                {
                    vALUTEUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowValute()
        {
            this.Gx_mode = Mode.FromRowState(this.rowVALUTE.RowState);
            if (this.rowVALUTE.RowState != DataRowState.Added)
            {
                this.m__NAZIVVALUTAOriginal = RuntimeHelpers.GetObjectValue(this.rowVALUTE["NAZIVVALUTA", DataRowVersion.Original]);
                this.m__TECAJOriginal = RuntimeHelpers.GetObjectValue(this.rowVALUTE["TECAJ", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVVALUTAOriginal = RuntimeHelpers.GetObjectValue(this.rowVALUTE["NAZIVVALUTA"]);
                this.m__TECAJOriginal = RuntimeHelpers.GetObjectValue(this.rowVALUTE["TECAJ"]);
            }
            this._Gxremove = this.rowVALUTE.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowVALUTE = (VALUTEDataSet.VALUTERow) DataSetUtil.CloneOriginalDataRow(this.rowVALUTE);
            }
        }

        private void ScanByIDVALUTA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDVALUTA] = @IDVALUTA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString39 + "  FROM [VALUTE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVALUTA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString39, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDVALUTA] ) AS DK_PAGENUM   FROM [VALUTE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString39 + " FROM [VALUTE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVALUTA] ";
            }
            this.cmVALUTESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmVALUTESelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmVALUTESelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVALUTA", DbType.Int32));
            }
            this.cmVALUTESelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVALUTE["IDVALUTA"]));
            this.VALUTESelect4 = this.cmVALUTESelect4.FetchData();
            this.RcdFound39 = 0;
            this.ScanLoadValute();
            this.LoadDataValute(maxRows);
        }

        private void ScanEndValute()
        {
            this.VALUTESelect4.Close();
        }

        private void ScanLoadValute()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmVALUTESelect4.HasMoreRows)
            {
                this.RcdFound39 = 1;
                this.rowVALUTE["IDVALUTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.VALUTESelect4, 0));
                this.rowVALUTE["NAZIVVALUTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VALUTESelect4, 1));
                this.rowVALUTE["TECAJ"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetDecimal(this.VALUTESelect4, 2));
            }
        }

        private void ScanNextValute()
        {
            this.cmVALUTESelect4.HasMoreRows = this.VALUTESelect4.Read();
            this.RcdFound39 = 0;
            this.ScanLoadValute();
        }

        private void ScanStartValute(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString39 + "  FROM [VALUTE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVALUTA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString39, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDVALUTA] ) AS DK_PAGENUM   FROM [VALUTE] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString39 + " FROM [VALUTE] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVALUTA] ";
            }
            this.cmVALUTESelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.VALUTESelect4 = this.cmVALUTESelect4.FetchData();
            this.RcdFound39 = 0;
            this.ScanLoadValute();
            this.LoadDataValute(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.VALUTESet = (VALUTEDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.VALUTESet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.VALUTESet.VALUTE.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        VALUTEDataSet.VALUTERow current = (VALUTEDataSet.VALUTERow) enumerator.Current;
                        this.rowVALUTE = current;
                        if (Helpers.IsRowChanged(this.rowVALUTE))
                        {
                            this.ReadRowValute();
                            if (this.rowVALUTE.RowState == DataRowState.Added)
                            {
                                this.InsertValute();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateValute();
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

        private void UpdateValute()
        {
            this.CheckOptimisticConcurrencyValute();
            this.AfterConfirmValute();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [VALUTE] SET [NAZIVVALUTA]=@NAZIVVALUTA, [TECAJ]=@TECAJ  WHERE [IDVALUTA] = @IDVALUTA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVVALUTA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@TECAJ", DbType.Decimal));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVALUTA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVALUTE["NAZIVVALUTA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowVALUTE["TECAJ"]));
            command.SetParameter(2, RuntimeHelpers.GetObjectValue(this.rowVALUTE["IDVALUTA"]));
            command.ExecuteStmt();
            this.OnVALUTEUpdated(new VALUTEEventArgs(this.rowVALUTE, StatementType.Update));
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
        public class VALUTEDataChangedException : DataChangedException
        {
            public VALUTEDataChangedException()
            {
            }

            public VALUTEDataChangedException(string message) : base(message)
            {
            }

            protected VALUTEDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VALUTEDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VALUTEDataLockedException : DataLockedException
        {
            public VALUTEDataLockedException()
            {
            }

            public VALUTEDataLockedException(string message) : base(message)
            {
            }

            protected VALUTEDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VALUTEDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VALUTEDuplicateKeyException : DuplicateKeyException
        {
            public VALUTEDuplicateKeyException()
            {
            }

            public VALUTEDuplicateKeyException(string message) : base(message)
            {
            }

            protected VALUTEDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VALUTEDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class VALUTEEventArgs : EventArgs
        {
            private VALUTEDataSet.VALUTERow m_dataRow;
            private System.Data.StatementType m_statementType;

            public VALUTEEventArgs(VALUTEDataSet.VALUTERow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public VALUTEDataSet.VALUTERow Row
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
        public class VALUTENotFoundException : DataNotFoundException
        {
            public VALUTENotFoundException()
            {
            }

            public VALUTENotFoundException(string message) : base(message)
            {
            }

            protected VALUTENotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VALUTENotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void VALUTEUpdateEventHandler(object sender, VALUTEDataAdapter.VALUTEEventArgs e);
    }
}

