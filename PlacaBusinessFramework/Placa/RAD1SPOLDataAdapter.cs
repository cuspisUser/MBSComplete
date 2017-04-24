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

    public class RAD1SPOLDataAdapter : IDataAdapter, IRAD1SPOLDataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmRAD1SPOLSelect1;
        private ReadWriteCommand cmRAD1SPOLSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__RAD1SPOLNAZIVOriginal;
        private readonly string m_SelectString283 = "TM1.[RAD1SPOLID], TM1.[RAD1SPOLNAZIV]";
        private string m_WhereString;
        private IDataReader RAD1SPOLSelect1;
        private IDataReader RAD1SPOLSelect4;
        private RAD1SPOLDataSet RAD1SPOLSet;
        private short RcdFound283;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private RAD1SPOLDataSet.RAD1SPOLRow rowRAD1SPOL;
        private string scmdbuf;
        private StatementType sMode283;

        public event RAD1SPOLUpdateEventHandler RAD1SPOLUpdated;

        public event RAD1SPOLUpdateEventHandler RAD1SPOLUpdating;

        private void AddRowRad1spol()
        {
            this.RAD1SPOLSet.RAD1SPOL.AddRAD1SPOLRow(this.rowRAD1SPOL);
        }

        private void AfterConfirmRad1spol()
        {
            this.OnRAD1SPOLUpdating(new RAD1SPOLEventArgs(this.rowRAD1SPOL, this.Gx_mode));
        }

        private void CheckDeleteErrorsRad1spol()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [RAD1SPOLID], [IDSPOL] FROM [RAD1VEZASPOL] WITH (NOLOCK) WHERE [RAD1SPOLID] = @RAD1SPOLID ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPOL["RAD1SPOLID"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RAD1VEZASPOLInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RAD1VEZASPOL" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyRad1spol()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1SPOLID], [RAD1SPOLNAZIV] FROM [RAD1SPOL] WITH (UPDLOCK) WHERE [RAD1SPOLID] = @RAD1SPOLID ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPOL["RAD1SPOLID"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new RAD1SPOLDataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("RAD1SPOL") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__RAD1SPOLNAZIVOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new RAD1SPOLDataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("RAD1SPOL") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowRad1spol()
        {
            this.rowRAD1SPOL = this.RAD1SPOLSet.RAD1SPOL.NewRAD1SPOLRow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyRad1spol();
            this.AfterConfirmRad1spol();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [RAD1SPOL]  WHERE [RAD1SPOLID] = @RAD1SPOLID", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPOL["RAD1SPOLID"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsRad1spol();
            }
            this.OnRAD1SPOLUpdated(new RAD1SPOLEventArgs(this.rowRAD1SPOL, StatementType.Delete));
            this.rowRAD1SPOL.Delete();
            this.sMode283 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode283;
        }

        public virtual int Fill(RAD1SPOLDataSet dataSet)
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
                    this.RAD1SPOLSet = dataSet;
                    this.LoadChildRad1spol(0, -1);
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
            this.RAD1SPOLSet = (RAD1SPOLDataSet) dataSet;
            if (this.RAD1SPOLSet != null)
            {
                return this.Fill(this.RAD1SPOLSet);
            }
            this.RAD1SPOLSet = new RAD1SPOLDataSet();
            this.Fill(this.RAD1SPOLSet);
            dataSet.Merge(this.RAD1SPOLSet);
            return 0;
        }

        public virtual int Fill(RAD1SPOLDataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1SPOLID"]));
        }

        public virtual int Fill(RAD1SPOLDataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["RAD1SPOLID"]));
        }

        public virtual int Fill(RAD1SPOLDataSet dataSet, int rAD1SPOLID)
        {
            if (!this.FillByRAD1SPOLID(dataSet, rAD1SPOLID))
            {
                throw new RAD1SPOLNotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("RAD1SPOL") }));
            }
            return 0;
        }

        public virtual bool FillByRAD1SPOLID(RAD1SPOLDataSet dataSet, int rAD1SPOLID)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1SPOLSet = dataSet;
            this.rowRAD1SPOL = this.RAD1SPOLSet.RAD1SPOL.NewRAD1SPOLRow();
            this.rowRAD1SPOL.RAD1SPOLID = rAD1SPOLID;
            try
            {
                this.LoadByRAD1SPOLID(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound283 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(RAD1SPOLDataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.RAD1SPOLSet = dataSet;
            try
            {
                this.LoadChildRad1spol(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [RAD1SPOLID], [RAD1SPOLNAZIV] FROM [RAD1SPOL] WITH (NOLOCK) WHERE [RAD1SPOLID] = @RAD1SPOLID ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPOL["RAD1SPOLID"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound283 = 1;
                this.rowRAD1SPOL["RAD1SPOLID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowRAD1SPOL["RAD1SPOLNAZIV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode283 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode283;
            }
            else
            {
                this.RcdFound283 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "RAD1SPOLID";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmRAD1SPOLSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [RAD1SPOL] WITH (NOLOCK) ", false);
            this.RAD1SPOLSelect1 = this.cmRAD1SPOLSelect1.FetchData();
            if (this.RAD1SPOLSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.RAD1SPOLSelect1.GetInt32(0);
            }
            this.RAD1SPOLSelect1.Close();
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
            this.RcdFound283 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__RAD1SPOLNAZIVOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.RAD1SPOLSet = new RAD1SPOLDataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertRad1spol()
        {
            this.CheckOptimisticConcurrencyRad1spol();
            this.AfterConfirmRad1spol();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [RAD1SPOL] ([RAD1SPOLID], [RAD1SPOLNAZIV]) VALUES (@RAD1SPOLID, @RAD1SPOLNAZIV)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLNAZIV", DbType.String, 20));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPOL["RAD1SPOLID"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1SPOL["RAD1SPOLNAZIV"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new RAD1SPOLDuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnRAD1SPOLUpdated(new RAD1SPOLEventArgs(this.rowRAD1SPOL, StatementType.Insert));
        }

        private void LoadByRAD1SPOLID(int startRow, int maxRows)
        {
            bool enforceConstraints = this.RAD1SPOLSet.EnforceConstraints;
            this.RAD1SPOLSet.RAD1SPOL.BeginLoadData();
            this.ScanByRAD1SPOLID(startRow, maxRows);
            this.RAD1SPOLSet.RAD1SPOL.EndLoadData();
            this.RAD1SPOLSet.EnforceConstraints = enforceConstraints;
            if (this.RAD1SPOLSet.RAD1SPOL.Count > 0)
            {
                this.rowRAD1SPOL = this.RAD1SPOLSet.RAD1SPOL[this.RAD1SPOLSet.RAD1SPOL.Count - 1];
            }
        }

        private void LoadChildRad1spol(int startRow, int maxRows)
        {
            this.CreateNewRowRad1spol();
            bool enforceConstraints = this.RAD1SPOLSet.EnforceConstraints;
            this.RAD1SPOLSet.RAD1SPOL.BeginLoadData();
            this.ScanStartRad1spol(startRow, maxRows);
            this.RAD1SPOLSet.RAD1SPOL.EndLoadData();
            this.RAD1SPOLSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataRad1spol(int maxRows)
        {
            int num = 0;
            if (this.RcdFound283 != 0)
            {
                this.ScanLoadRad1spol();
                while ((this.RcdFound283 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowRad1spol();
                    this.CreateNewRowRad1spol();
                    this.ScanNextRad1spol();
                }
            }
            if (num > 0)
            {
                this.RcdFound283 = 1;
            }
            this.ScanEndRad1spol();
            if (this.RAD1SPOLSet.RAD1SPOL.Count > 0)
            {
                this.rowRAD1SPOL = this.RAD1SPOLSet.RAD1SPOL[this.RAD1SPOLSet.RAD1SPOL.Count - 1];
            }
        }

        private void LoadRowRad1spol()
        {
            this.AddRowRad1spol();
        }

        private void OnRAD1SPOLUpdated(RAD1SPOLEventArgs e)
        {
            if (this.RAD1SPOLUpdated != null)
            {
                RAD1SPOLUpdateEventHandler handler = this.RAD1SPOLUpdated;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void OnRAD1SPOLUpdating(RAD1SPOLEventArgs e)
        {
            if (this.RAD1SPOLUpdating != null)
            {
                RAD1SPOLUpdateEventHandler handler = this.RAD1SPOLUpdating;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
        }

        private void ReadRowRad1spol()
        {
            this.Gx_mode = Mode.FromRowState(this.rowRAD1SPOL.RowState);
            if (this.rowRAD1SPOL.RowState != DataRowState.Added)
            {
                this.m__RAD1SPOLNAZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowRAD1SPOL["RAD1SPOLNAZIV", DataRowVersion.Original]);
            }
            else
            {
                this.m__RAD1SPOLNAZIVOriginal = RuntimeHelpers.GetObjectValue(this.rowRAD1SPOL["RAD1SPOLNAZIV"]);
            }
            this._Gxremove = this.rowRAD1SPOL.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowRAD1SPOL = (RAD1SPOLDataSet.RAD1SPOLRow) DataSetUtil.CloneOriginalDataRow(this.rowRAD1SPOL);
            }
        }

        private void ScanByRAD1SPOLID(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[RAD1SPOLID] = @RAD1SPOLID";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString283 + "  FROM [RAD1SPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1SPOLID]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString283, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1SPOLID] ) AS DK_PAGENUM   FROM [RAD1SPOL] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString283 + " FROM [RAD1SPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1SPOLID] ";
            }
            this.cmRAD1SPOLSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmRAD1SPOLSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmRAD1SPOLSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
            }
            this.cmRAD1SPOLSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPOL["RAD1SPOLID"]));
            this.RAD1SPOLSelect4 = this.cmRAD1SPOLSelect4.FetchData();
            this.RcdFound283 = 0;
            this.ScanLoadRad1spol();
            this.LoadDataRad1spol(maxRows);
        }

        private void ScanEndRad1spol()
        {
            this.RAD1SPOLSelect4.Close();
        }

        private void ScanLoadRad1spol()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmRAD1SPOLSelect4.HasMoreRows)
            {
                this.RcdFound283 = 1;
                this.rowRAD1SPOL["RAD1SPOLID"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.RAD1SPOLSelect4, 0));
                this.rowRAD1SPOL["RAD1SPOLNAZIV"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.RAD1SPOLSelect4, 1));
            }
        }

        private void ScanNextRad1spol()
        {
            this.cmRAD1SPOLSelect4.HasMoreRows = this.RAD1SPOLSelect4.Read();
            this.RcdFound283 = 0;
            this.ScanLoadRad1spol();
        }

        private void ScanStartRad1spol(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString283 + "  FROM [RAD1SPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1SPOLID]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString283, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[RAD1SPOLID] ) AS DK_PAGENUM   FROM [RAD1SPOL] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString283 + " FROM [RAD1SPOL] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[RAD1SPOLID] ";
            }
            this.cmRAD1SPOLSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.RAD1SPOLSelect4 = this.cmRAD1SPOLSelect4.FetchData();
            this.RcdFound283 = 0;
            this.ScanLoadRad1spol();
            this.LoadDataRad1spol(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.RAD1SPOLSet = (RAD1SPOLDataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.RAD1SPOLSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.RAD1SPOLSet.RAD1SPOL.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        RAD1SPOLDataSet.RAD1SPOLRow current = (RAD1SPOLDataSet.RAD1SPOLRow) enumerator.Current;
                        this.rowRAD1SPOL = current;
                        if (Helpers.IsRowChanged(this.rowRAD1SPOL))
                        {
                            this.ReadRowRad1spol();
                            if (this.rowRAD1SPOL.RowState == DataRowState.Added)
                            {
                                this.InsertRad1spol();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateRad1spol();
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

        private void UpdateRad1spol()
        {
            this.CheckOptimisticConcurrencyRad1spol();
            this.AfterConfirmRad1spol();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [RAD1SPOL] SET [RAD1SPOLNAZIV]=@RAD1SPOLNAZIV  WHERE [RAD1SPOLID] = @RAD1SPOLID", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLNAZIV", DbType.String, 20));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@RAD1SPOLID", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowRAD1SPOL["RAD1SPOLNAZIV"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowRAD1SPOL["RAD1SPOLID"]));
            command.ExecuteStmt();
            this.OnRAD1SPOLUpdated(new RAD1SPOLEventArgs(this.rowRAD1SPOL, StatementType.Update));
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
        public class RAD1SPOLDataChangedException : DataChangedException
        {
            public RAD1SPOLDataChangedException()
            {
            }

            public RAD1SPOLDataChangedException(string message) : base(message)
            {
            }

            protected RAD1SPOLDataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPOLDataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1SPOLDataLockedException : DataLockedException
        {
            public RAD1SPOLDataLockedException()
            {
            }

            public RAD1SPOLDataLockedException(string message) : base(message)
            {
            }

            protected RAD1SPOLDataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPOLDataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class RAD1SPOLDuplicateKeyException : DuplicateKeyException
        {
            public RAD1SPOLDuplicateKeyException()
            {
            }

            public RAD1SPOLDuplicateKeyException(string message) : base(message)
            {
            }

            protected RAD1SPOLDuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPOLDuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class RAD1SPOLEventArgs : EventArgs
        {
            private RAD1SPOLDataSet.RAD1SPOLRow m_dataRow;
            private System.Data.StatementType m_statementType;

            public RAD1SPOLEventArgs(RAD1SPOLDataSet.RAD1SPOLRow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public RAD1SPOLDataSet.RAD1SPOLRow Row
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
        public class RAD1SPOLNotFoundException : DataNotFoundException
        {
            public RAD1SPOLNotFoundException()
            {
            }

            public RAD1SPOLNotFoundException(string message) : base(message)
            {
            }

            protected RAD1SPOLNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPOLNotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void RAD1SPOLUpdateEventHandler(object sender, RAD1SPOLDataAdapter.RAD1SPOLEventArgs e);

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
    }
}

