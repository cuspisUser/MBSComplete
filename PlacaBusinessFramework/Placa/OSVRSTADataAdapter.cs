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

    public class OSVRSTADataAdapter : IDataAdapter, IOSVRSTADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmOSVRSTASelect1;
        private ReadWriteCommand cmOSVRSTASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__OPISOSVRSTAOriginal;
        private readonly string m_SelectString255 = "TM1.[IDOSVRSTA], TM1.[OPISOSVRSTA]";
        private string m_WhereString;
        private IDataReader OSVRSTASelect1;
        private IDataReader OSVRSTASelect4;
        private OSVRSTADataSet OSVRSTASet;
        private short RcdFound255;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private OSVRSTADataSet.OSVRSTARow rowOSVRSTA;
        private string scmdbuf;
        private StatementType sMode255;

        public event OSVRSTAUpdateEventHandler OSVRSTAUpdated;

        public event OSVRSTAUpdateEventHandler OSVRSTAUpdating;

        private void AddRowOsvrsta()
        {
            this.OSVRSTASet.OSVRSTA.AddOSVRSTARow(this.rowOSVRSTA);
        }

        private void AfterConfirmOsvrsta()
        {
            this.OnOSVRSTAUpdating(new OSVRSTAEventArgs(this.rowOSVRSTA, this.Gx_mode));
        }

        private void CheckDeleteErrorsOsvrsta()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [INVBROJ] FROM [OS] WITH (NOLOCK) WHERE [IDOSVRSTA] = @IDOSVRSTA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSVRSTA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSVRSTA["IDOSVRSTA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new OSInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "OS" }));
            }
            reader.Close();
        }

        private void CheckExtendedTableOsvrsta()
        {
            this.rowOSVRSTA.OSV = NumberUtil.ToString((long) this.rowOSVRSTA.IDOSVRSTA, "") + " | " + this.rowOSVRSTA.OPISOSVRSTA;
        }

        private void CheckOptimisticConcurrencyOsvrsta()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOSVRSTA], [OPISOSVRSTA] FROM [OSVRSTA] WITH (UPDLOCK) WHERE [IDOSVRSTA] = @IDOSVRSTA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSVRSTA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSVRSTA["IDOSVRSTA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new OSVRSTADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("OSVRSTA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__OPISOSVRSTAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new OSVRSTADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("OSVRSTA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowOsvrsta()
        {
            this.rowOSVRSTA = this.OSVRSTASet.OSVRSTA.NewOSVRSTARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyOsvrsta();
            this.OnDeleteControlsOsvrsta();
            this.AfterConfirmOsvrsta();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [OSVRSTA]  WHERE [IDOSVRSTA] = @IDOSVRSTA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSVRSTA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSVRSTA["IDOSVRSTA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsOsvrsta();
            }
            this.OnOSVRSTAUpdated(new OSVRSTAEventArgs(this.rowOSVRSTA, StatementType.Delete));
            this.rowOSVRSTA.Delete();
            this.sMode255 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode255;
        }

        public virtual int Fill(OSVRSTADataSet dataSet)
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
                    this.OSVRSTASet = dataSet;
                    this.LoadChildOsvrsta(0, -1);
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
            this.OSVRSTASet = (OSVRSTADataSet) dataSet;
            if (this.OSVRSTASet != null)
            {
                return this.Fill(this.OSVRSTASet);
            }
            this.OSVRSTASet = new OSVRSTADataSet();
            this.Fill(this.OSVRSTASet);
            dataSet.Merge(this.OSVRSTASet);
            return 0;
        }

        public virtual int Fill(OSVRSTADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDOSVRSTA"]));
        }

        public virtual int Fill(OSVRSTADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDOSVRSTA"]));
        }

        public virtual int Fill(OSVRSTADataSet dataSet, int iDOSVRSTA)
        {
            if (!this.FillByIDOSVRSTA(dataSet, iDOSVRSTA))
            {
                throw new OSVRSTANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("OSVRSTA") }));
            }
            return 0;
        }

        public virtual bool FillByIDOSVRSTA(OSVRSTADataSet dataSet, int iDOSVRSTA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSVRSTASet = dataSet;
            this.rowOSVRSTA = this.OSVRSTASet.OSVRSTA.NewOSVRSTARow();
            this.rowOSVRSTA.IDOSVRSTA = iDOSVRSTA;
            try
            {
                this.LoadByIDOSVRSTA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound255 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(OSVRSTADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.OSVRSTASet = dataSet;
            try
            {
                this.LoadChildOsvrsta(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDOSVRSTA], [OPISOSVRSTA] FROM [OSVRSTA] WITH (NOLOCK) WHERE [IDOSVRSTA] = @IDOSVRSTA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSVRSTA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSVRSTA["IDOSVRSTA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound255 = 1;
                this.rowOSVRSTA["IDOSVRSTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowOSVRSTA["OPISOSVRSTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode255 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.LoadOsvrsta();
                this.Gx_mode = this.sMode255;
            }
            else
            {
                this.RcdFound255 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDOSVRSTA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmOSVRSTASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [OSVRSTA] WITH (NOLOCK) ", false);
            this.OSVRSTASelect1 = this.cmOSVRSTASelect1.FetchData();
            if (this.OSVRSTASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.OSVRSTASelect1.GetInt32(0);
            }
            this.OSVRSTASelect1.Close();
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
            this.RcdFound255 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__OPISOSVRSTAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.OSVRSTASet = new OSVRSTADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertOsvrsta()
        {
            this.CheckOptimisticConcurrencyOsvrsta();
            this.CheckExtendedTableOsvrsta();
            this.AfterConfirmOsvrsta();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [OSVRSTA] ([IDOSVRSTA], [OPISOSVRSTA]) VALUES (@IDOSVRSTA, @OPISOSVRSTA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSVRSTA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISOSVRSTA", DbType.String, 30));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSVRSTA["IDOSVRSTA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOSVRSTA["OPISOSVRSTA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new OSVRSTADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnOSVRSTAUpdated(new OSVRSTAEventArgs(this.rowOSVRSTA, StatementType.Insert));
        }

        private void LoadByIDOSVRSTA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.OSVRSTASet.EnforceConstraints;
            this.OSVRSTASet.OSVRSTA.BeginLoadData();
            this.ScanByIDOSVRSTA(startRow, maxRows);
            this.OSVRSTASet.OSVRSTA.EndLoadData();
            this.OSVRSTASet.EnforceConstraints = enforceConstraints;
            if (this.OSVRSTASet.OSVRSTA.Count > 0)
            {
                this.rowOSVRSTA = this.OSVRSTASet.OSVRSTA[this.OSVRSTASet.OSVRSTA.Count - 1];
            }
        }

        private void LoadChildOsvrsta(int startRow, int maxRows)
        {
            this.CreateNewRowOsvrsta();
            bool enforceConstraints = this.OSVRSTASet.EnforceConstraints;
            this.OSVRSTASet.OSVRSTA.BeginLoadData();
            this.ScanStartOsvrsta(startRow, maxRows);
            this.OSVRSTASet.OSVRSTA.EndLoadData();
            this.OSVRSTASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataOsvrsta(int maxRows)
        {
            int num = 0;
            if (this.RcdFound255 != 0)
            {
                this.ScanLoadOsvrsta();
                while ((this.RcdFound255 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowOsvrsta();
                    this.CreateNewRowOsvrsta();
                    this.ScanNextOsvrsta();
                }
            }
            if (num > 0)
            {
                this.RcdFound255 = 1;
            }
            this.ScanEndOsvrsta();
            if (this.OSVRSTASet.OSVRSTA.Count > 0)
            {
                this.rowOSVRSTA = this.OSVRSTASet.OSVRSTA[this.OSVRSTASet.OSVRSTA.Count - 1];
            }
        }

        private void LoadOsvrsta()
        {
            this.rowOSVRSTA.OSV = NumberUtil.ToString((long) this.rowOSVRSTA.IDOSVRSTA, "") + " | " + this.rowOSVRSTA.OPISOSVRSTA;
        }

        private void LoadRowOsvrsta()
        {
            this.OnLoadActionsOsvrsta();
            this.AddRowOsvrsta();
        }

        private void OnDeleteControlsOsvrsta()
        {
            this.rowOSVRSTA.OSV = NumberUtil.ToString((long) this.rowOSVRSTA.IDOSVRSTA, "") + " | " + this.rowOSVRSTA.OPISOSVRSTA;
        }

        private void OnLoadActionsOsvrsta()
        {
            this.rowOSVRSTA.OSV = NumberUtil.ToString((long) this.rowOSVRSTA.IDOSVRSTA, "") + " | " + this.rowOSVRSTA.OPISOSVRSTA;
        }

        private void OnOSVRSTAUpdated(OSVRSTAEventArgs e)
        {
            if (this.OSVRSTAUpdated != null)
            {
                OSVRSTAUpdateEventHandler oSVRSTAUpdatedEvent = this.OSVRSTAUpdated;
                if (oSVRSTAUpdatedEvent != null)
                {
                    oSVRSTAUpdatedEvent(this, e);
                }
            }
        }

        private void OnOSVRSTAUpdating(OSVRSTAEventArgs e)
        {
            if (this.OSVRSTAUpdating != null)
            {
                OSVRSTAUpdateEventHandler oSVRSTAUpdatingEvent = this.OSVRSTAUpdating;
                if (oSVRSTAUpdatingEvent != null)
                {
                    oSVRSTAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowOsvrsta()
        {
            this.Gx_mode = Mode.FromRowState(this.rowOSVRSTA.RowState);
            if (this.rowOSVRSTA.RowState != DataRowState.Added)
            {
                this.m__OPISOSVRSTAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSVRSTA["OPISOSVRSTA", DataRowVersion.Original]);
            }
            else
            {
                this.m__OPISOSVRSTAOriginal = RuntimeHelpers.GetObjectValue(this.rowOSVRSTA["OPISOSVRSTA"]);
            }
            this._Gxremove = this.rowOSVRSTA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowOSVRSTA = (OSVRSTADataSet.OSVRSTARow) DataSetUtil.CloneOriginalDataRow(this.rowOSVRSTA);
            }
        }

        private void ScanByIDOSVRSTA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDOSVRSTA] = @IDOSVRSTA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString255 + "  FROM [OSVRSTA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSVRSTA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString255, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOSVRSTA] ) AS DK_PAGENUM   FROM [OSVRSTA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString255 + " FROM [OSVRSTA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSVRSTA] ";
            }
            this.cmOSVRSTASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmOSVRSTASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmOSVRSTASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSVRSTA", DbType.Int32));
            }
            this.cmOSVRSTASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSVRSTA["IDOSVRSTA"]));
            this.OSVRSTASelect4 = this.cmOSVRSTASelect4.FetchData();
            this.RcdFound255 = 0;
            this.ScanLoadOsvrsta();
            this.LoadDataOsvrsta(maxRows);
        }

        private void ScanEndOsvrsta()
        {
            this.OSVRSTASelect4.Close();
        }

        private void ScanLoadOsvrsta()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmOSVRSTASelect4.HasMoreRows)
            {
                this.RcdFound255 = 1;
                this.rowOSVRSTA["IDOSVRSTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.OSVRSTASelect4, 0));
                this.rowOSVRSTA["OPISOSVRSTA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.OSVRSTASelect4, 1));
            }
        }

        private void ScanNextOsvrsta()
        {
            this.cmOSVRSTASelect4.HasMoreRows = this.OSVRSTASelect4.Read();
            this.RcdFound255 = 0;
            this.ScanLoadOsvrsta();
        }

        private void ScanStartOsvrsta(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString255 + "  FROM [OSVRSTA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSVRSTA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString255, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDOSVRSTA] ) AS DK_PAGENUM   FROM [OSVRSTA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString255 + " FROM [OSVRSTA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDOSVRSTA] ";
            }
            this.cmOSVRSTASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.OSVRSTASelect4 = this.cmOSVRSTASelect4.FetchData();
            this.RcdFound255 = 0;
            this.ScanLoadOsvrsta();
            this.LoadDataOsvrsta(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.OSVRSTASet = (OSVRSTADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.OSVRSTASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.OSVRSTASet.OSVRSTA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        OSVRSTADataSet.OSVRSTARow current = (OSVRSTADataSet.OSVRSTARow) enumerator.Current;
                        this.rowOSVRSTA = current;
                        if (Helpers.IsRowChanged(this.rowOSVRSTA))
                        {
                            this.ReadRowOsvrsta();
                            if (this.rowOSVRSTA.RowState == DataRowState.Added)
                            {
                                this.InsertOsvrsta();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateOsvrsta();
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

        private void UpdateOsvrsta()
        {
            this.CheckOptimisticConcurrencyOsvrsta();
            this.CheckExtendedTableOsvrsta();
            this.AfterConfirmOsvrsta();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [OSVRSTA] SET [OPISOSVRSTA]=@OPISOSVRSTA  WHERE [IDOSVRSTA] = @IDOSVRSTA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@OPISOSVRSTA", DbType.String, 30));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDOSVRSTA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowOSVRSTA["OPISOSVRSTA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowOSVRSTA["IDOSVRSTA"]));
            command.ExecuteStmt();
            this.OnOSVRSTAUpdated(new OSVRSTAEventArgs(this.rowOSVRSTA, StatementType.Update));
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
        public class OSInvalidDeleteException : InvalidDeleteException
        {
            public OSInvalidDeleteException()
            {
            }

            public OSInvalidDeleteException(string message) : base(message)
            {
            }

            protected OSInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSVRSTADataChangedException : DataChangedException
        {
            public OSVRSTADataChangedException()
            {
            }

            public OSVRSTADataChangedException(string message) : base(message)
            {
            }

            protected OSVRSTADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSVRSTADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSVRSTADataLockedException : DataLockedException
        {
            public OSVRSTADataLockedException()
            {
            }

            public OSVRSTADataLockedException(string message) : base(message)
            {
            }

            protected OSVRSTADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSVRSTADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class OSVRSTADuplicateKeyException : DuplicateKeyException
        {
            public OSVRSTADuplicateKeyException()
            {
            }

            public OSVRSTADuplicateKeyException(string message) : base(message)
            {
            }

            protected OSVRSTADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSVRSTADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class OSVRSTAEventArgs : EventArgs
        {
            private OSVRSTADataSet.OSVRSTARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public OSVRSTAEventArgs(OSVRSTADataSet.OSVRSTARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public OSVRSTADataSet.OSVRSTARow Row
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
        public class OSVRSTANotFoundException : DataNotFoundException
        {
            public OSVRSTANotFoundException()
            {
            }

            public OSVRSTANotFoundException(string message) : base(message)
            {
            }

            protected OSVRSTANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public OSVRSTANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void OSVRSTAUpdateEventHandler(object sender, OSVRSTADataAdapter.OSVRSTAEventArgs e);
    }
}

