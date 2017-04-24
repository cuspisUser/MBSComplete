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

    public class DDVRSTEIZNOSADataAdapter : IDataAdapter, IDDVRSTEIZNOSADataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmDDVRSTEIZNOSASelect1;
        private ReadWriteCommand cmDDVRSTEIZNOSASelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DDVRSTEIZNOSASelect1;
        private IDataReader DDVRSTEIZNOSASelect4;
        private DDVRSTEIZNOSADataSet DDVRSTEIZNOSASet;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVDDVRSTEIZNOSAOriginal;
        private readonly string m_SelectString242 = "TM1.[IDDDVRSTEIZNOSA], TM1.[NAZIVDDVRSTEIZNOSA]";
        private string m_WhereString;
        private short RcdFound242;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow rowDDVRSTEIZNOSA;
        private string scmdbuf;
        private StatementType sMode242;

        public event DDVRSTEIZNOSAUpdateEventHandler DDVRSTEIZNOSAUpdated;

        public event DDVRSTEIZNOSAUpdateEventHandler DDVRSTEIZNOSAUpdating;

        private void AddRowDdvrsteiznosa()
        {
            this.DDVRSTEIZNOSASet.DDVRSTEIZNOSA.AddDDVRSTEIZNOSARow(this.rowDDVRSTEIZNOSA);
        }

        private void AfterConfirmDdvrsteiznosa()
        {
            this.OnDDVRSTEIZNOSAUpdating(new DDVRSTEIZNOSAEventArgs(this.rowDDVRSTEIZNOSA, this.Gx_mode));
        }

        private void CheckDeleteErrorsDdvrsteiznosa()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDSHEMADD], [SHEMADDSTANDARDID] FROM [SHEMADDSHEMADDSTANDARD] WITH (NOLOCK) WHERE [IDDDVRSTEIZNOSA] = @IDDDVRSTEIZNOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDDVRSTEIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEIZNOSA["IDDDVRSTEIZNOSA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new SHEMADDSHEMADDSTANDARDInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "SHEMADDSTANDARD" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyDdvrsteiznosa()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDDDVRSTEIZNOSA], [NAZIVDDVRSTEIZNOSA] FROM [DDVRSTEIZNOSA] WITH (UPDLOCK) WHERE [IDDDVRSTEIZNOSA] = @IDDDVRSTEIZNOSA ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDDVRSTEIZNOSA", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEIZNOSA["IDDDVRSTEIZNOSA"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DDVRSTEIZNOSADataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DDVRSTEIZNOSA") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVDDVRSTEIZNOSAOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new DDVRSTEIZNOSADataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DDVRSTEIZNOSA") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowDdvrsteiznosa()
        {
            this.rowDDVRSTEIZNOSA = this.DDVRSTEIZNOSASet.DDVRSTEIZNOSA.NewDDVRSTEIZNOSARow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDdvrsteiznosa();
            this.AfterConfirmDdvrsteiznosa();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DDVRSTEIZNOSA]  WHERE [IDDDVRSTEIZNOSA] = @IDDDVRSTEIZNOSA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDDVRSTEIZNOSA", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEIZNOSA["IDDDVRSTEIZNOSA"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsDdvrsteiznosa();
            }
            this.OnDDVRSTEIZNOSAUpdated(new DDVRSTEIZNOSAEventArgs(this.rowDDVRSTEIZNOSA, StatementType.Delete));
            this.rowDDVRSTEIZNOSA.Delete();
            this.sMode242 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode242;
        }

        public virtual int Fill(DDVRSTEIZNOSADataSet dataSet)
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
                    this.DDVRSTEIZNOSASet = dataSet;
                    this.LoadChildDdvrsteiznosa(0, -1);
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
            this.DDVRSTEIZNOSASet = (DDVRSTEIZNOSADataSet) dataSet;
            if (this.DDVRSTEIZNOSASet != null)
            {
                return this.Fill(this.DDVRSTEIZNOSASet);
            }
            this.DDVRSTEIZNOSASet = new DDVRSTEIZNOSADataSet();
            this.Fill(this.DDVRSTEIZNOSASet);
            dataSet.Merge(this.DDVRSTEIZNOSASet);
            return 0;
        }

        public virtual int Fill(DDVRSTEIZNOSADataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDDDVRSTEIZNOSA"]));
        }

        public virtual int Fill(DDVRSTEIZNOSADataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDDDVRSTEIZNOSA"]));
        }

        public virtual int Fill(DDVRSTEIZNOSADataSet dataSet, int iDDDVRSTEIZNOSA)
        {
            if (!this.FillByIDDDVRSTEIZNOSA(dataSet, iDDDVRSTEIZNOSA))
            {
                throw new DDVRSTEIZNOSANotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DDVRSTEIZNOSA") }));
            }
            return 0;
        }

        public virtual bool FillByIDDDVRSTEIZNOSA(DDVRSTEIZNOSADataSet dataSet, int iDDDVRSTEIZNOSA)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDVRSTEIZNOSASet = dataSet;
            this.rowDDVRSTEIZNOSA = this.DDVRSTEIZNOSASet.DDVRSTEIZNOSA.NewDDVRSTEIZNOSARow();
            this.rowDDVRSTEIZNOSA.IDDDVRSTEIZNOSA = iDDDVRSTEIZNOSA;
            try
            {
                this.LoadByIDDDVRSTEIZNOSA(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound242 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(DDVRSTEIZNOSADataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DDVRSTEIZNOSASet = dataSet;
            try
            {
                this.LoadChildDdvrsteiznosa(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDDDVRSTEIZNOSA], [NAZIVDDVRSTEIZNOSA] FROM [DDVRSTEIZNOSA] WITH (NOLOCK) WHERE [IDDDVRSTEIZNOSA] = @IDDDVRSTEIZNOSA ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDDVRSTEIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEIZNOSA["IDDDVRSTEIZNOSA"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound242 = 1;
                this.rowDDVRSTEIZNOSA["IDDDVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowDDVRSTEIZNOSA["NAZIVDDVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode242 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode242;
            }
            else
            {
                this.RcdFound242 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDDDVRSTEIZNOSA";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDDVRSTEIZNOSASelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DDVRSTEIZNOSA] WITH (NOLOCK) ", false);
            this.DDVRSTEIZNOSASelect1 = this.cmDDVRSTEIZNOSASelect1.FetchData();
            if (this.DDVRSTEIZNOSASelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DDVRSTEIZNOSASelect1.GetInt32(0);
            }
            this.DDVRSTEIZNOSASelect1.Close();
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
            this.RcdFound242 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVDDVRSTEIZNOSAOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.DDVRSTEIZNOSASet = new DDVRSTEIZNOSADataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertDdvrsteiznosa()
        {
            this.CheckOptimisticConcurrencyDdvrsteiznosa();
            this.AfterConfirmDdvrsteiznosa();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DDVRSTEIZNOSA] ([IDDDVRSTEIZNOSA], [NAZIVDDVRSTEIZNOSA]) VALUES (@IDDDVRSTEIZNOSA, @NAZIVDDVRSTEIZNOSA)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDDVRSTEIZNOSA", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVDDVRSTEIZNOSA", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEIZNOSA["IDDDVRSTEIZNOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEIZNOSA["NAZIVDDVRSTEIZNOSA"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DDVRSTEIZNOSADuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDDVRSTEIZNOSAUpdated(new DDVRSTEIZNOSAEventArgs(this.rowDDVRSTEIZNOSA, StatementType.Insert));
        }

        private void LoadByIDDDVRSTEIZNOSA(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DDVRSTEIZNOSASet.EnforceConstraints;
            this.DDVRSTEIZNOSASet.DDVRSTEIZNOSA.BeginLoadData();
            this.ScanByIDDDVRSTEIZNOSA(startRow, maxRows);
            this.DDVRSTEIZNOSASet.DDVRSTEIZNOSA.EndLoadData();
            this.DDVRSTEIZNOSASet.EnforceConstraints = enforceConstraints;
            if (this.DDVRSTEIZNOSASet.DDVRSTEIZNOSA.Count > 0)
            {
                this.rowDDVRSTEIZNOSA = this.DDVRSTEIZNOSASet.DDVRSTEIZNOSA[this.DDVRSTEIZNOSASet.DDVRSTEIZNOSA.Count - 1];
            }
        }

        private void LoadChildDdvrsteiznosa(int startRow, int maxRows)
        {
            this.CreateNewRowDdvrsteiznosa();
            bool enforceConstraints = this.DDVRSTEIZNOSASet.EnforceConstraints;
            this.DDVRSTEIZNOSASet.DDVRSTEIZNOSA.BeginLoadData();
            this.ScanStartDdvrsteiznosa(startRow, maxRows);
            this.DDVRSTEIZNOSASet.DDVRSTEIZNOSA.EndLoadData();
            this.DDVRSTEIZNOSASet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataDdvrsteiznosa(int maxRows)
        {
            int num = 0;
            if (this.RcdFound242 != 0)
            {
                this.ScanLoadDdvrsteiznosa();
                while ((this.RcdFound242 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowDdvrsteiznosa();
                    this.CreateNewRowDdvrsteiznosa();
                    this.ScanNextDdvrsteiznosa();
                }
            }
            if (num > 0)
            {
                this.RcdFound242 = 1;
            }
            this.ScanEndDdvrsteiznosa();
            if (this.DDVRSTEIZNOSASet.DDVRSTEIZNOSA.Count > 0)
            {
                this.rowDDVRSTEIZNOSA = this.DDVRSTEIZNOSASet.DDVRSTEIZNOSA[this.DDVRSTEIZNOSASet.DDVRSTEIZNOSA.Count - 1];
            }
        }

        private void LoadRowDdvrsteiznosa()
        {
            this.AddRowDdvrsteiznosa();
        }

        private void OnDDVRSTEIZNOSAUpdated(DDVRSTEIZNOSAEventArgs e)
        {
            if (this.DDVRSTEIZNOSAUpdated != null)
            {
                DDVRSTEIZNOSAUpdateEventHandler dDVRSTEIZNOSAUpdatedEvent = this.DDVRSTEIZNOSAUpdated;
                if (dDVRSTEIZNOSAUpdatedEvent != null)
                {
                    dDVRSTEIZNOSAUpdatedEvent(this, e);
                }
            }
        }

        private void OnDDVRSTEIZNOSAUpdating(DDVRSTEIZNOSAEventArgs e)
        {
            if (this.DDVRSTEIZNOSAUpdating != null)
            {
                DDVRSTEIZNOSAUpdateEventHandler dDVRSTEIZNOSAUpdatingEvent = this.DDVRSTEIZNOSAUpdating;
                if (dDVRSTEIZNOSAUpdatingEvent != null)
                {
                    dDVRSTEIZNOSAUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowDdvrsteiznosa()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDDVRSTEIZNOSA.RowState);
            if (this.rowDDVRSTEIZNOSA.RowState != DataRowState.Added)
            {
                this.m__NAZIVDDVRSTEIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDVRSTEIZNOSA["NAZIVDDVRSTEIZNOSA", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVDDVRSTEIZNOSAOriginal = RuntimeHelpers.GetObjectValue(this.rowDDVRSTEIZNOSA["NAZIVDDVRSTEIZNOSA"]);
            }
            this._Gxremove = this.rowDDVRSTEIZNOSA.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowDDVRSTEIZNOSA = (DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow) DataSetUtil.CloneOriginalDataRow(this.rowDDVRSTEIZNOSA);
            }
        }

        private void ScanByIDDDVRSTEIZNOSA(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDDDVRSTEIZNOSA] = @IDDDVRSTEIZNOSA";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString242 + "  FROM [DDVRSTEIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDDDVRSTEIZNOSA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString242, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDDDVRSTEIZNOSA] ) AS DK_PAGENUM   FROM [DDVRSTEIZNOSA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString242 + " FROM [DDVRSTEIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDDDVRSTEIZNOSA] ";
            }
            this.cmDDVRSTEIZNOSASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDDVRSTEIZNOSASelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmDDVRSTEIZNOSASelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDDVRSTEIZNOSA", DbType.Int32));
            }
            this.cmDDVRSTEIZNOSASelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEIZNOSA["IDDDVRSTEIZNOSA"]));
            this.DDVRSTEIZNOSASelect4 = this.cmDDVRSTEIZNOSASelect4.FetchData();
            this.RcdFound242 = 0;
            this.ScanLoadDdvrsteiznosa();
            this.LoadDataDdvrsteiznosa(maxRows);
        }

        private void ScanEndDdvrsteiznosa()
        {
            this.DDVRSTEIZNOSASelect4.Close();
        }

        private void ScanLoadDdvrsteiznosa()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDDVRSTEIZNOSASelect4.HasMoreRows)
            {
                this.RcdFound242 = 1;
                this.rowDDVRSTEIZNOSA["IDDDVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DDVRSTEIZNOSASelect4, 0));
                this.rowDDVRSTEIZNOSA["NAZIVDDVRSTEIZNOSA"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DDVRSTEIZNOSASelect4, 1));
            }
        }

        private void ScanNextDdvrsteiznosa()
        {
            this.cmDDVRSTEIZNOSASelect4.HasMoreRows = this.DDVRSTEIZNOSASelect4.Read();
            this.RcdFound242 = 0;
            this.ScanLoadDdvrsteiznosa();
        }

        private void ScanStartDdvrsteiznosa(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString242 + "  FROM [DDVRSTEIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDDDVRSTEIZNOSA]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString242, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDDDVRSTEIZNOSA] ) AS DK_PAGENUM   FROM [DDVRSTEIZNOSA] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString242 + " FROM [DDVRSTEIZNOSA] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDDDVRSTEIZNOSA] ";
            }
            this.cmDDVRSTEIZNOSASelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.DDVRSTEIZNOSASelect4 = this.cmDDVRSTEIZNOSASelect4.FetchData();
            this.RcdFound242 = 0;
            this.ScanLoadDdvrsteiznosa();
            this.LoadDataDdvrsteiznosa(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.DDVRSTEIZNOSASet = (DDVRSTEIZNOSADataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.DDVRSTEIZNOSASet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.DDVRSTEIZNOSASet.DDVRSTEIZNOSA.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow current = (DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow) enumerator.Current;
                        this.rowDDVRSTEIZNOSA = current;
                        if (Helpers.IsRowChanged(this.rowDDVRSTEIZNOSA))
                        {
                            this.ReadRowDdvrsteiznosa();
                            if (this.rowDDVRSTEIZNOSA.RowState == DataRowState.Added)
                            {
                                this.InsertDdvrsteiznosa();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateDdvrsteiznosa();
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

        private void UpdateDdvrsteiznosa()
        {
            this.CheckOptimisticConcurrencyDdvrsteiznosa();
            this.AfterConfirmDdvrsteiznosa();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DDVRSTEIZNOSA] SET [NAZIVDDVRSTEIZNOSA]=@NAZIVDDVRSTEIZNOSA  WHERE [IDDDVRSTEIZNOSA] = @IDDDVRSTEIZNOSA", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVDDVRSTEIZNOSA", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDDVRSTEIZNOSA", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEIZNOSA["NAZIVDDVRSTEIZNOSA"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDDVRSTEIZNOSA["IDDDVRSTEIZNOSA"]));
            command.ExecuteStmt();
            this.OnDDVRSTEIZNOSAUpdated(new DDVRSTEIZNOSAEventArgs(this.rowDDVRSTEIZNOSA, StatementType.Update));
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
        public class DDVRSTEIZNOSADataChangedException : DataChangedException
        {
            public DDVRSTEIZNOSADataChangedException()
            {
            }

            public DDVRSTEIZNOSADataChangedException(string message) : base(message)
            {
            }

            protected DDVRSTEIZNOSADataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDVRSTEIZNOSADataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDVRSTEIZNOSADataLockedException : DataLockedException
        {
            public DDVRSTEIZNOSADataLockedException()
            {
            }

            public DDVRSTEIZNOSADataLockedException(string message) : base(message)
            {
            }

            protected DDVRSTEIZNOSADataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDVRSTEIZNOSADataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DDVRSTEIZNOSADuplicateKeyException : DuplicateKeyException
        {
            public DDVRSTEIZNOSADuplicateKeyException()
            {
            }

            public DDVRSTEIZNOSADuplicateKeyException(string message) : base(message)
            {
            }

            protected DDVRSTEIZNOSADuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDVRSTEIZNOSADuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DDVRSTEIZNOSAEventArgs : EventArgs
        {
            private DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DDVRSTEIZNOSAEventArgs(DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DDVRSTEIZNOSADataSet.DDVRSTEIZNOSARow Row
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
        public class DDVRSTEIZNOSANotFoundException : DataNotFoundException
        {
            public DDVRSTEIZNOSANotFoundException()
            {
            }

            public DDVRSTEIZNOSANotFoundException(string message) : base(message)
            {
            }

            protected DDVRSTEIZNOSANotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DDVRSTEIZNOSANotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void DDVRSTEIZNOSAUpdateEventHandler(object sender, DDVRSTEIZNOSADataAdapter.DDVRSTEIZNOSAEventArgs e);

        [Serializable]
        public class SHEMADDSHEMADDSTANDARDInvalidDeleteException : InvalidDeleteException
        {
            public SHEMADDSHEMADDSTANDARDInvalidDeleteException()
            {
            }

            public SHEMADDSHEMADDSTANDARDInvalidDeleteException(string message) : base(message)
            {
            }

            protected SHEMADDSHEMADDSTANDARDInvalidDeleteException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public SHEMADDSHEMADDSTANDARDInvalidDeleteException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}

