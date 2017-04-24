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

    public class VERZIJADataAdapter : IDataAdapter, IVERZIJADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmVERZIJASelect1;
        private ReadWriteCommand cmVERZIJASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__VERZIJAOriginal;
        private readonly string m_SelectString79 = "TM1.[IDVERZIJA], TM1.[VERZIJA]";
        private string m_WhereString;
        private short RcdFound79;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private VERZIJADataSet.VERZIJARow rowVERZIJA;
        private string scmdbuf;
        private StatementType sMode79;
        private IDataReader VERZIJASelect1;
        private IDataReader VERZIJASelect4;
        private VERZIJADataSet VERZIJASet;

        public event VERZIJAUpdateEventHandler VERZIJAUpdated;

        public event VERZIJAUpdateEventHandler VERZIJAUpdating;

        private void AddRowVerzija()
        {
            this.VERZIJASet.VERZIJA.AddVERZIJARow(this.rowVERZIJA);
        }

        private void AfterConfirmVerzija()
        {
            this.OnVERZIJAUpdating(new VERZIJAEventArgs(this.rowVERZIJA, this.Gx_mode));
        }

        private void CheckOptimisticConcurrencyVerzija()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDVERZIJA], [VERZIJA] FROM [VERZIJA] WITH (UPDLOCK) WHERE [IDVERZIJA] = @IDVERZIJA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVERZIJA", DbType.Int16));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVERZIJA["IDVERZIJA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new VERZIJADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("VERZIJA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__VERZIJAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new VERZIJADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("VERZIJA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowVerzija()
        {
            this.rowVERZIJA = this.VERZIJASet.VERZIJA.NewVERZIJARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyVerzija();
            this.AfterConfirmVerzija();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [VERZIJA]  WHERE [IDVERZIJA] = @IDVERZIJA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVERZIJA", DbType.Int16));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVERZIJA["IDVERZIJA"]));
            command.ExecuteStmt();
            this.OnVERZIJAUpdated(new VERZIJAEventArgs(this.rowVERZIJA, StatementType.Delete));
            this.rowVERZIJA.Delete();
            this.sMode79 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode79;
        }

        public virtual int Fill(VERZIJADataSet dataSet)
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
                    this.VERZIJASet = dataSet;
                    this.LoadChildVerzija(0, -1);
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
            this.VERZIJASet = (VERZIJADataSet) dataSet;
            if (this.VERZIJASet != null)
            {
                return this.Fill(this.VERZIJASet);
            }
            this.VERZIJASet = new VERZIJADataSet();
            this.Fill(this.VERZIJASet);
            dataSet.Merge(this.VERZIJASet);
            return 0;
        }

        public virtual int Fill(VERZIJADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToShort(dataRecord["IDVERZIJA"]));
        }

        public virtual int Fill(VERZIJADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToShort(dataRecord["IDVERZIJA"]));
        }

        public virtual int Fill(VERZIJADataSet dataSet, short iDVERZIJA)
        {
            if (!this.FillByIDVERZIJA(dataSet, iDVERZIJA))
            {
                throw new VERZIJANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("VERZIJA") }));
            }
            return 0;
        }

        public virtual bool FillByIDVERZIJA(VERZIJADataSet dataSet, short iDVERZIJA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VERZIJASet = dataSet;
            this.rowVERZIJA = this.VERZIJASet.VERZIJA.NewVERZIJARow();
            this.rowVERZIJA.IDVERZIJA = iDVERZIJA;
            try
            {
                this.LoadByIDVERZIJA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound79 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(VERZIJADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.VERZIJASet = dataSet;
            try
            {
                this.LoadChildVerzija(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDVERZIJA], [VERZIJA] FROM [VERZIJA] WITH (NOLOCK) WHERE [IDVERZIJA] = @IDVERZIJA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVERZIJA", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVERZIJA["IDVERZIJA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound79 = 1;
                this.rowVERZIJA["IDVERZIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(reader, 0));
                this.rowVERZIJA["VERZIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode79 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode79;
            }
            else
            {
                this.RcdFound79 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDVERZIJA";
                parameter.DbType = DbType.Int16;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmVERZIJASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [VERZIJA] WITH (NOLOCK) ", false);
            this.VERZIJASelect1 = this.cmVERZIJASelect1.FetchData();
            if (this.VERZIJASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.VERZIJASelect1.GetInt32(0);
            }
            this.VERZIJASelect1.Close();
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
            this.RcdFound79 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__VERZIJAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.VERZIJASet = new VERZIJADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertVerzija()
        {
            this.CheckOptimisticConcurrencyVerzija();
            this.AfterConfirmVerzija();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [VERZIJA] ([IDVERZIJA], [VERZIJA]) VALUES (@IDVERZIJA, @VERZIJA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVERZIJA", DbType.Int16));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VERZIJA", DbType.String, 20));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVERZIJA["IDVERZIJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowVERZIJA["VERZIJA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new VERZIJADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnVERZIJAUpdated(new VERZIJAEventArgs(this.rowVERZIJA, StatementType.Insert));
        }

        private void LoadByIDVERZIJA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.VERZIJASet.EnforceConstraints;
            this.VERZIJASet.VERZIJA.BeginLoadData();
            this.ScanByIDVERZIJA(startRow, maxRows);
            this.VERZIJASet.VERZIJA.EndLoadData();
            this.VERZIJASet.EnforceConstraints = enforceConstraints;
            if (this.VERZIJASet.VERZIJA.Count > 0)
            {
                this.rowVERZIJA = this.VERZIJASet.VERZIJA[this.VERZIJASet.VERZIJA.Count - 1];
            }
        }

        private void LoadChildVerzija(int startRow, int maxRows)
        {
            this.CreateNewRowVerzija();
            bool enforceConstraints = this.VERZIJASet.EnforceConstraints;
            this.VERZIJASet.VERZIJA.BeginLoadData();
            this.ScanStartVerzija(startRow, maxRows);
            this.VERZIJASet.VERZIJA.EndLoadData();
            this.VERZIJASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataVerzija(int maxRows)
        {
            int num = 0;
            if (this.RcdFound79 != 0)
            {
                this.ScanLoadVerzija();
                while ((this.RcdFound79 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowVerzija();
                    this.CreateNewRowVerzija();
                    this.ScanNextVerzija();
                }
            }
            if (num > 0)
            {
                this.RcdFound79 = 1;
            }
            this.ScanEndVerzija();
            if (this.VERZIJASet.VERZIJA.Count > 0)
            {
                this.rowVERZIJA = this.VERZIJASet.VERZIJA[this.VERZIJASet.VERZIJA.Count - 1];
            }
        }

        private void LoadRowVerzija()
        {
            this.AddRowVerzija();
        }

        private void OnVERZIJAUpdated(VERZIJAEventArgs e)
        {
            if (this.VERZIJAUpdated != null)
            {
                VERZIJAUpdateEventHandler vERZIJAUpdatedEvent = this.VERZIJAUpdated;
                if (vERZIJAUpdatedEvent != null)
                {
                    vERZIJAUpdatedEvent(this, e);
                }
            }
        }

        private void OnVERZIJAUpdating(VERZIJAEventArgs e)
        {
            if (this.VERZIJAUpdating != null)
            {
                VERZIJAUpdateEventHandler vERZIJAUpdatingEvent = this.VERZIJAUpdating;
                if (vERZIJAUpdatingEvent != null)
                {
                    vERZIJAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowVerzija()
        {
            this.Gx_mode = Mode.FromRowState(this.rowVERZIJA.RowState);
            if (this.rowVERZIJA.RowState != DataRowState.Added)
            {
                this.m__VERZIJAOriginal = RuntimeHelpers.GetObjectValue(this.rowVERZIJA["VERZIJA", DataRowVersion.Original]);
            }
            else
            {
                this.m__VERZIJAOriginal = RuntimeHelpers.GetObjectValue(this.rowVERZIJA["VERZIJA"]);
            }
            this._Gxremove = this.rowVERZIJA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowVERZIJA = (VERZIJADataSet.VERZIJARow) DataSetUtil.CloneOriginalDataRow(this.rowVERZIJA);
            }
        }

        private void ScanByIDVERZIJA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDVERZIJA] = @IDVERZIJA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString79 + "  FROM [VERZIJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVERZIJA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString79, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDVERZIJA] ) AS DK_PAGENUM   FROM [VERZIJA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString79 + " FROM [VERZIJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVERZIJA] ";
            }
            this.cmVERZIJASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmVERZIJASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmVERZIJASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVERZIJA", DbType.Int16));
            }
            this.cmVERZIJASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVERZIJA["IDVERZIJA"]));
            this.VERZIJASelect4 = this.cmVERZIJASelect4.FetchData();
            this.RcdFound79 = 0;
            this.ScanLoadVerzija();
            this.LoadDataVerzija(maxRows);
        }

        private void ScanEndVerzija()
        {
            this.VERZIJASelect4.Close();
        }

        private void ScanLoadVerzija()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmVERZIJASelect4.HasMoreRows)
            {
                this.RcdFound79 = 1;
                this.rowVERZIJA["IDVERZIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt16(this.VERZIJASelect4, 0));
                this.rowVERZIJA["VERZIJA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.VERZIJASelect4, 1));
            }
        }

        private void ScanNextVerzija()
        {
            this.cmVERZIJASelect4.HasMoreRows = this.VERZIJASelect4.Read();
            this.RcdFound79 = 0;
            this.ScanLoadVerzija();
        }

        private void ScanStartVerzija(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString79 + "  FROM [VERZIJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVERZIJA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString79, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDVERZIJA] ) AS DK_PAGENUM   FROM [VERZIJA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString79 + " FROM [VERZIJA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDVERZIJA] ";
            }
            this.cmVERZIJASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.VERZIJASelect4 = this.cmVERZIJASelect4.FetchData();
            this.RcdFound79 = 0;
            this.ScanLoadVerzija();
            this.LoadDataVerzija(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.VERZIJASet = (VERZIJADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.VERZIJASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.VERZIJASet.VERZIJA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        VERZIJADataSet.VERZIJARow current = (VERZIJADataSet.VERZIJARow) enumerator.Current;
                        this.rowVERZIJA = current;
                        if (Helpers.IsRowChanged(this.rowVERZIJA))
                        {
                            this.ReadRowVerzija();
                            if (this.rowVERZIJA.RowState == DataRowState.Added)
                            {
                                this.InsertVerzija();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateVerzija();
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

        private void UpdateVerzija()
        {
            this.CheckOptimisticConcurrencyVerzija();
            this.AfterConfirmVerzija();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [VERZIJA] SET [VERZIJA]=@VERZIJA  WHERE [IDVERZIJA] = @IDVERZIJA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@VERZIJA", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDVERZIJA", DbType.Int16));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowVERZIJA["VERZIJA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowVERZIJA["IDVERZIJA"]));
            command.ExecuteStmt();
            this.OnVERZIJAUpdated(new VERZIJAEventArgs(this.rowVERZIJA, StatementType.Update));
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
        public class VERZIJADataChangedException : DataChangedException
        {
            public VERZIJADataChangedException()
            {
            }

            public VERZIJADataChangedException(string message) : base(message)
            {
            }

            protected VERZIJADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VERZIJADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VERZIJADataLockedException : DataLockedException
        {
            public VERZIJADataLockedException()
            {
            }

            public VERZIJADataLockedException(string message) : base(message)
            {
            }

            protected VERZIJADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VERZIJADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class VERZIJADuplicateKeyException : DuplicateKeyException
        {
            public VERZIJADuplicateKeyException()
            {
            }

            public VERZIJADuplicateKeyException(string message) : base(message)
            {
            }

            protected VERZIJADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VERZIJADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class VERZIJAEventArgs : EventArgs
        {
            private VERZIJADataSet.VERZIJARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public VERZIJAEventArgs(VERZIJADataSet.VERZIJARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public VERZIJADataSet.VERZIJARow Row
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
        public class VERZIJANotFoundException : DataNotFoundException
        {
            public VERZIJANotFoundException()
            {
            }

            public VERZIJANotFoundException(string message) : base(message)
            {
            }

            protected VERZIJANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public VERZIJANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void VERZIJAUpdateEventHandler(object sender, VERZIJADataAdapter.VERZIJAEventArgs e);
    }
}

