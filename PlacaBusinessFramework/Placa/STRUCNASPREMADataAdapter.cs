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

    public class STRUCNASPREMADataAdapter : IDataAdapter, ISTRUCNASPREMADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmSTRUCNASPREMASelect1;
        private ReadWriteCommand cmSTRUCNASPREMASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVSTRUCNASPREMAOriginal;
        private readonly string m_SelectString34 = "TM1.[IDSTRUCNASPREMA], TM1.[NAZIVSTRUCNASPREMA]";
        private string m_WhereString;
        private short RcdFound34;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private STRUCNASPREMADataSet.STRUCNASPREMARow rowSTRUCNASPREMA;
        private string scmdbuf;
        private StatementType sMode34;
        private IDataReader STRUCNASPREMASelect1;
        private IDataReader STRUCNASPREMASelect4;
        private STRUCNASPREMADataSet STRUCNASPREMASet;

        public event STRUCNASPREMAUpdateEventHandler STRUCNASPREMAUpdated;

        public event STRUCNASPREMAUpdateEventHandler STRUCNASPREMAUpdating;

        private void AddRowStrucnasprema()
        {
            this.STRUCNASPREMASet.STRUCNASPREMA.AddSTRUCNASPREMARow(this.rowSTRUCNASPREMA);
        }

        private void AfterConfirmStrucnasprema()
        {
            this.OnSTRUCNASPREMAUpdating(new STRUCNASPREMAEventArgs(this.rowSTRUCNASPREMA, this.Gx_mode));
        }

        private void CheckDeleteErrorsStrucnasprema()
        {
            ReadWriteCommand command2 = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [TRENUTNASTRUCNASPREMAIDSTRUCNASPREMA] = @IDSTRUCNASPREMA ", false);
            if (command2.IDbCommand.Parameters.Count == 0)
            {
                command2.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            command2.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUCNASPREMA["IDSTRUCNASPREMA"]));
            IDataReader reader2 = command2.FetchData();
            if (command2.HasMoreRows)
            {
                reader2.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader2.Close();
            ReadWriteCommand command3 = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [POTREBNASTRUCNASPREMAIDSTRUCNASPREMA] = @IDSTRUCNASPREMA ", false);
            if (command3.IDbCommand.Parameters.Count == 0)
            {
                command3.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            command3.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUCNASPREMA["IDSTRUCNASPREMA"]));
            IDataReader reader3 = command3.FetchData();
            if (command3.HasMoreRows)
            {
                reader3.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader3.Close();
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [RAD1IDSPREME], [IDSTRUCNASPREMA] FROM [RAD1SPREMEVEZA] WITH (NOLOCK) WHERE [IDSTRUCNASPREMA] = @IDSTRUCNASPREMA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUCNASPREMA["IDSTRUCNASPREMA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RAD1SPREMEVEZAInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RAD1SPREMEVEZA" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyStrucnasprema()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSTRUCNASPREMA], [NAZIVSTRUCNASPREMA] FROM [STRUCNASPREMA] WITH (UPDLOCK) WHERE [IDSTRUCNASPREMA] = @IDSTRUCNASPREMA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUCNASPREMA["IDSTRUCNASPREMA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new STRUCNASPREMADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("STRUCNASPREMA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVSTRUCNASPREMAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new STRUCNASPREMADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("STRUCNASPREMA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowStrucnasprema()
        {
            this.rowSTRUCNASPREMA = this.STRUCNASPREMASet.STRUCNASPREMA.NewSTRUCNASPREMARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyStrucnasprema();
            this.AfterConfirmStrucnasprema();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [STRUCNASPREMA]  WHERE [IDSTRUCNASPREMA] = @IDSTRUCNASPREMA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUCNASPREMA["IDSTRUCNASPREMA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsStrucnasprema();
            }
            this.OnSTRUCNASPREMAUpdated(new STRUCNASPREMAEventArgs(this.rowSTRUCNASPREMA, StatementType.Delete));
            this.rowSTRUCNASPREMA.Delete();
            this.sMode34 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode34;
        }

        public virtual int Fill(STRUCNASPREMADataSet dataSet)
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
                    this.STRUCNASPREMASet = dataSet;
                    this.LoadChildStrucnasprema(0, -1);
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
            this.STRUCNASPREMASet = (STRUCNASPREMADataSet) dataSet;
            if (this.STRUCNASPREMASet != null)
            {
                return this.Fill(this.STRUCNASPREMASet);
            }
            this.STRUCNASPREMASet = new STRUCNASPREMADataSet();
            this.Fill(this.STRUCNASPREMASet);
            dataSet.Merge(this.STRUCNASPREMASet);
            return 0;
        }

        public virtual int Fill(STRUCNASPREMADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSTRUCNASPREMA"]));
        }

        public virtual int Fill(STRUCNASPREMADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDSTRUCNASPREMA"]));
        }

        public virtual int Fill(STRUCNASPREMADataSet dataSet, int iDSTRUCNASPREMA)
        {
            if (!this.FillByIDSTRUCNASPREMA(dataSet, iDSTRUCNASPREMA))
            {
                throw new STRUCNASPREMANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("STRUCNASPREMA") }));
            }
            return 0;
        }

        public virtual bool FillByIDSTRUCNASPREMA(STRUCNASPREMADataSet dataSet, int iDSTRUCNASPREMA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.STRUCNASPREMASet = dataSet;
            this.rowSTRUCNASPREMA = this.STRUCNASPREMASet.STRUCNASPREMA.NewSTRUCNASPREMARow();
            this.rowSTRUCNASPREMA.IDSTRUCNASPREMA = iDSTRUCNASPREMA;
            try
            {
                this.LoadByIDSTRUCNASPREMA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound34 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(STRUCNASPREMADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.STRUCNASPREMASet = dataSet;
            try
            {
                this.LoadChildStrucnasprema(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDSTRUCNASPREMA], [NAZIVSTRUCNASPREMA] FROM [STRUCNASPREMA] WITH (NOLOCK) WHERE [IDSTRUCNASPREMA] = @IDSTRUCNASPREMA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUCNASPREMA["IDSTRUCNASPREMA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound34 = 1;
                this.rowSTRUCNASPREMA["IDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowSTRUCNASPREMA["NAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode34 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode34;
            }
            else
            {
                this.RcdFound34 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDSTRUCNASPREMA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmSTRUCNASPREMASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [STRUCNASPREMA] WITH (NOLOCK) ", false);
            this.STRUCNASPREMASelect1 = this.cmSTRUCNASPREMASelect1.FetchData();
            if (this.STRUCNASPREMASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.STRUCNASPREMASelect1.GetInt32(0);
            }
            this.STRUCNASPREMASelect1.Close();
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
            this.RcdFound34 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVSTRUCNASPREMAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.STRUCNASPREMASet = new STRUCNASPREMADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertStrucnasprema()
        {
            this.CheckOptimisticConcurrencyStrucnasprema();
            this.AfterConfirmStrucnasprema();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [STRUCNASPREMA] ([IDSTRUCNASPREMA], [NAZIVSTRUCNASPREMA]) VALUES (@IDSTRUCNASPREMA, @NAZIVSTRUCNASPREMA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSTRUCNASPREMA", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUCNASPREMA["IDSTRUCNASPREMA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSTRUCNASPREMA["NAZIVSTRUCNASPREMA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new STRUCNASPREMADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnSTRUCNASPREMAUpdated(new STRUCNASPREMAEventArgs(this.rowSTRUCNASPREMA, StatementType.Insert));
        }

        private void LoadByIDSTRUCNASPREMA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.STRUCNASPREMASet.EnforceConstraints;
            this.STRUCNASPREMASet.STRUCNASPREMA.BeginLoadData();
            this.ScanByIDSTRUCNASPREMA(startRow, maxRows);
            this.STRUCNASPREMASet.STRUCNASPREMA.EndLoadData();
            this.STRUCNASPREMASet.EnforceConstraints = enforceConstraints;
            if (this.STRUCNASPREMASet.STRUCNASPREMA.Count > 0)
            {
                this.rowSTRUCNASPREMA = this.STRUCNASPREMASet.STRUCNASPREMA[this.STRUCNASPREMASet.STRUCNASPREMA.Count - 1];
            }
        }

        private void LoadChildStrucnasprema(int startRow, int maxRows)
        {
            this.CreateNewRowStrucnasprema();
            bool enforceConstraints = this.STRUCNASPREMASet.EnforceConstraints;
            this.STRUCNASPREMASet.STRUCNASPREMA.BeginLoadData();
            this.ScanStartStrucnasprema(startRow, maxRows);
            this.STRUCNASPREMASet.STRUCNASPREMA.EndLoadData();
            this.STRUCNASPREMASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataStrucnasprema(int maxRows)
        {
            int num = 0;
            if (this.RcdFound34 != 0)
            {
                this.ScanLoadStrucnasprema();
                while ((this.RcdFound34 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowStrucnasprema();
                    this.CreateNewRowStrucnasprema();
                    this.ScanNextStrucnasprema();
                }
            }
            if (num > 0)
            {
                this.RcdFound34 = 1;
            }
            this.ScanEndStrucnasprema();
            if (this.STRUCNASPREMASet.STRUCNASPREMA.Count > 0)
            {
                this.rowSTRUCNASPREMA = this.STRUCNASPREMASet.STRUCNASPREMA[this.STRUCNASPREMASet.STRUCNASPREMA.Count - 1];
            }
        }

        private void LoadRowStrucnasprema()
        {
            this.AddRowStrucnasprema();
        }

        private void OnSTRUCNASPREMAUpdated(STRUCNASPREMAEventArgs e)
        {
            if (this.STRUCNASPREMAUpdated != null)
            {
                STRUCNASPREMAUpdateEventHandler sTRUCNASPREMAUpdatedEvent = this.STRUCNASPREMAUpdated;
                if (sTRUCNASPREMAUpdatedEvent != null)
                {
                    sTRUCNASPREMAUpdatedEvent(this, e);
                }
            }
        }

        private void OnSTRUCNASPREMAUpdating(STRUCNASPREMAEventArgs e)
        {
            if (this.STRUCNASPREMAUpdating != null)
            {
                STRUCNASPREMAUpdateEventHandler sTRUCNASPREMAUpdatingEvent = this.STRUCNASPREMAUpdating;
                if (sTRUCNASPREMAUpdatingEvent != null)
                {
                    sTRUCNASPREMAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowStrucnasprema()
        {
            this.Gx_mode = Mode.FromRowState(this.rowSTRUCNASPREMA.RowState);
            if (this.rowSTRUCNASPREMA.RowState != DataRowState.Added)
            {
                this.m__NAZIVSTRUCNASPREMAOriginal = RuntimeHelpers.GetObjectValue(this.rowSTRUCNASPREMA["NAZIVSTRUCNASPREMA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVSTRUCNASPREMAOriginal = RuntimeHelpers.GetObjectValue(this.rowSTRUCNASPREMA["NAZIVSTRUCNASPREMA"]);
            }
            this._Gxremove = this.rowSTRUCNASPREMA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowSTRUCNASPREMA = (STRUCNASPREMADataSet.STRUCNASPREMARow) DataSetUtil.CloneOriginalDataRow(this.rowSTRUCNASPREMA);
            }
        }

        private void ScanByIDSTRUCNASPREMA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDSTRUCNASPREMA] = @IDSTRUCNASPREMA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString34 + "  FROM [STRUCNASPREMA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRUCNASPREMA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString34, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSTRUCNASPREMA] ) AS DK_PAGENUM   FROM [STRUCNASPREMA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString34 + " FROM [STRUCNASPREMA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRUCNASPREMA] ";
            }
            this.cmSTRUCNASPREMASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmSTRUCNASPREMASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmSTRUCNASPREMASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            this.cmSTRUCNASPREMASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUCNASPREMA["IDSTRUCNASPREMA"]));
            this.STRUCNASPREMASelect4 = this.cmSTRUCNASPREMASelect4.FetchData();
            this.RcdFound34 = 0;
            this.ScanLoadStrucnasprema();
            this.LoadDataStrucnasprema(maxRows);
        }

        private void ScanEndStrucnasprema()
        {
            this.STRUCNASPREMASelect4.Close();
        }

        private void ScanLoadStrucnasprema()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmSTRUCNASPREMASelect4.HasMoreRows)
            {
                this.RcdFound34 = 1;
                this.rowSTRUCNASPREMA["IDSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.STRUCNASPREMASelect4, 0));
                this.rowSTRUCNASPREMA["NAZIVSTRUCNASPREMA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.STRUCNASPREMASelect4, 1));
            }
        }

        private void ScanNextStrucnasprema()
        {
            this.cmSTRUCNASPREMASelect4.HasMoreRows = this.STRUCNASPREMASelect4.Read();
            this.RcdFound34 = 0;
            this.ScanLoadStrucnasprema();
        }

        private void ScanStartStrucnasprema(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString34 + "  FROM [STRUCNASPREMA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRUCNASPREMA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString34, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDSTRUCNASPREMA] ) AS DK_PAGENUM   FROM [STRUCNASPREMA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString34 + " FROM [STRUCNASPREMA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDSTRUCNASPREMA] ";
            }
            this.cmSTRUCNASPREMASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.STRUCNASPREMASelect4 = this.cmSTRUCNASPREMASelect4.FetchData();
            this.RcdFound34 = 0;
            this.ScanLoadStrucnasprema();
            this.LoadDataStrucnasprema(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.STRUCNASPREMASet = (STRUCNASPREMADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.STRUCNASPREMASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.STRUCNASPREMASet.STRUCNASPREMA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        STRUCNASPREMADataSet.STRUCNASPREMARow current = (STRUCNASPREMADataSet.STRUCNASPREMARow) enumerator.Current;
                        this.rowSTRUCNASPREMA = current;
                        if (Helpers.IsRowChanged(this.rowSTRUCNASPREMA))
                        {
                            this.ReadRowStrucnasprema();
                            if (this.rowSTRUCNASPREMA.RowState == DataRowState.Added)
                            {
                                this.InsertStrucnasprema();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateStrucnasprema();
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

        private void UpdateStrucnasprema()
        {
            this.CheckOptimisticConcurrencyStrucnasprema();
            this.AfterConfirmStrucnasprema();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [STRUCNASPREMA] SET [NAZIVSTRUCNASPREMA]=@NAZIVSTRUCNASPREMA  WHERE [IDSTRUCNASPREMA] = @IDSTRUCNASPREMA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVSTRUCNASPREMA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDSTRUCNASPREMA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowSTRUCNASPREMA["NAZIVSTRUCNASPREMA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowSTRUCNASPREMA["IDSTRUCNASPREMA"]));
            command.ExecuteStmt();
            this.OnSTRUCNASPREMAUpdated(new STRUCNASPREMAEventArgs(this.rowSTRUCNASPREMA, StatementType.Update));
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
        public class RAD1SPREMEVEZAInvalidDeleteException : InvalidDeleteException
        {
            public RAD1SPREMEVEZAInvalidDeleteException()
            {
            }

            public RAD1SPREMEVEZAInvalidDeleteException(string message) : base(message)
            {
            }

            protected RAD1SPREMEVEZAInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public RAD1SPREMEVEZAInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
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
        public class STRUCNASPREMADataChangedException : DataChangedException
        {
            public STRUCNASPREMADataChangedException()
            {
            }

            public STRUCNASPREMADataChangedException(string message) : base(message)
            {
            }

            protected STRUCNASPREMADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRUCNASPREMADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class STRUCNASPREMADataLockedException : DataLockedException
        {
            public STRUCNASPREMADataLockedException()
            {
            }

            public STRUCNASPREMADataLockedException(string message) : base(message)
            {
            }

            protected STRUCNASPREMADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRUCNASPREMADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class STRUCNASPREMADuplicateKeyException : DuplicateKeyException
        {
            public STRUCNASPREMADuplicateKeyException()
            {
            }

            public STRUCNASPREMADuplicateKeyException(string message) : base(message)
            {
            }

            protected STRUCNASPREMADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRUCNASPREMADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class STRUCNASPREMAEventArgs : EventArgs
        {
            private STRUCNASPREMADataSet.STRUCNASPREMARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public STRUCNASPREMAEventArgs(STRUCNASPREMADataSet.STRUCNASPREMARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public STRUCNASPREMADataSet.STRUCNASPREMARow Row
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
        public class STRUCNASPREMANotFoundException : DataNotFoundException
        {
            public STRUCNASPREMANotFoundException()
            {
            }

            public STRUCNASPREMANotFoundException(string message) : base(message)
            {
            }

            protected STRUCNASPREMANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public STRUCNASPREMANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void STRUCNASPREMAUpdateEventHandler(object sender, STRUCNASPREMADataAdapter.STRUCNASPREMAEventArgs e);
    }
}

