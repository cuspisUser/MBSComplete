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

    public class DRZAVLJANSTVODataAdapter : IDataAdapter, IDRZAVLJANSTVODataAdapter
    {
        private bool _Gxremove;
        private ReadWriteCommand cmDRZAVLJANSTVOSelect1;
        private ReadWriteCommand cmDRZAVLJANSTVOSelect4;
        private ReadWriteConnection connDefault;
        private IDbTransaction daCurrentTransaction;
        private IDataReader DRZAVLJANSTVOSelect1;
        private IDataReader DRZAVLJANSTVOSelect4;
        private DRZAVLJANSTVODataSet DRZAVLJANSTVOSet;
        private DataStore dsDefault;
        private DbParameter[] fillDataParameters;
        private StatementType Gx_mode;
        private object m__NAZIVDRZAVLJANSTVOOriginal;
        private readonly string m_SelectString270 = "TM1.[IDDRZAVLJANSTVO], TM1.[NAZIVDRZAVLJANSTVO]";
        private string m_WhereString;
        private short RcdFound270;
        private int recordCount;
        private System.Resources.ResourceManager resourceManager;
        private System.Resources.ResourceManager resourceManagerTables;
        private DRZAVLJANSTVODataSet.DRZAVLJANSTVORow rowDRZAVLJANSTVO;
        private string scmdbuf;
        private StatementType sMode270;

        public event DRZAVLJANSTVOUpdateEventHandler DRZAVLJANSTVOUpdated;

        public event DRZAVLJANSTVOUpdateEventHandler DRZAVLJANSTVOUpdating;

        private void AddRowDrzavljanstvo()
        {
            this.DRZAVLJANSTVOSet.DRZAVLJANSTVO.AddDRZAVLJANSTVORow(this.rowDRZAVLJANSTVO);
        }

        private void AfterConfirmDrzavljanstvo()
        {
            this.OnDRZAVLJANSTVOUpdating(new DRZAVLJANSTVOEventArgs(this.rowDRZAVLJANSTVO, this.Gx_mode));
        }

        private void CheckDeleteErrorsDrzavljanstvo()
        {
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT TOP 1 [IDRADNIK] FROM [RADNIK] WITH (NOLOCK) WHERE [IDDRZAVLJANSTVO] = @IDDRZAVLJANSTVO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDRZAVLJANSTVO["IDDRZAVLJANSTVO"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                reader.Close();
                throw new RADNIKInvalidDeleteException(string.Format(this.resourceManager.GetString("del"), new object[] { "RADNIK" }));
            }
            reader.Close();
        }

        private void CheckOptimisticConcurrencyDrzavljanstvo()
        {
            if (this.Gx_mode != StatementType.Insert)
            {
                ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDDRZAVLJANSTVO], [NAZIVDRZAVLJANSTVO] FROM [DRZAVLJANSTVO] WITH (UPDLOCK) WHERE [IDDRZAVLJANSTVO] = @IDDRZAVLJANSTVO ", false);
                if (command.IDbCommand.Parameters.Count == 0)
                {
                    command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
                }
                command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDRZAVLJANSTVO["IDDRZAVLJANSTVO"]));
                IDataReader reader = command.FetchData();
                if (command.Locked)
                {
                    reader.Close();
                    throw new DRZAVLJANSTVODataLockedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("lock"), new object[] { this.resourceManagerTables.GetString("DRZAVLJANSTVO") }));
                }
                if (!command.HasMoreRows || !StringUtil.ObjectStringEquals(RuntimeHelpers.GetObjectValue(this.m__NAZIVDRZAVLJANSTVOOriginal), RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1))))
                {
                    reader.Close();
                    throw new DRZAVLJANSTVODataChangedException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("waschg"), new object[] { this.resourceManagerTables.GetString("DRZAVLJANSTVO") }));
                }
                reader.Close();
            }
        }

        protected void Cleanup()
        {
            this.dsDefault.Dispose();
        }

        private void CreateNewRowDrzavljanstvo()
        {
            this.rowDRZAVLJANSTVO = this.DRZAVLJANSTVOSet.DRZAVLJANSTVO.NewDRZAVLJANSTVORow();
        }

        private void Delete()
        {
            this.Gx_mode = StatementType.Delete;
            this.CheckOptimisticConcurrencyDrzavljanstvo();
            this.AfterConfirmDrzavljanstvo();
            ReadWriteCommand command = this.connDefault.GetCommand("DELETE FROM [DRZAVLJANSTVO]  WHERE [IDDRZAVLJANSTVO] = @IDDRZAVLJANSTVO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
            }
            command.ErrorMask |= ErrorMask.ForeignKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDRZAVLJANSTVO["IDDRZAVLJANSTVO"]));
            command.ExecuteStmt();
            if (command.ForeignKeyError)
            {
                this.CheckDeleteErrorsDrzavljanstvo();
            }
            this.OnDRZAVLJANSTVOUpdated(new DRZAVLJANSTVOEventArgs(this.rowDRZAVLJANSTVO, StatementType.Delete));
            this.rowDRZAVLJANSTVO.Delete();
            this.sMode270 = this.Gx_mode;
            this.Gx_mode = StatementType.Delete;
            this.Gx_mode = this.sMode270;
        }

        public virtual int Fill(DRZAVLJANSTVODataSet dataSet)
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
                    this.DRZAVLJANSTVOSet = dataSet;
                    this.LoadChildDrzavljanstvo(0, -1);
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
            this.DRZAVLJANSTVOSet = (DRZAVLJANSTVODataSet) dataSet;
            if (this.DRZAVLJANSTVOSet != null)
            {
                return this.Fill(this.DRZAVLJANSTVOSet);
            }
            this.DRZAVLJANSTVOSet = new DRZAVLJANSTVODataSet();
            this.Fill(this.DRZAVLJANSTVOSet);
            dataSet.Merge(this.DRZAVLJANSTVOSet);
            return 0;
        }

        public virtual int Fill(DRZAVLJANSTVODataSet dataSet, DataRow dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDDRZAVLJANSTVO"]));
        }

        public virtual int Fill(DRZAVLJANSTVODataSet dataSet, IDataRecord dataRecord)
        {
            return this.Fill(dataSet, Conversions.ToInteger(dataRecord["IDDRZAVLJANSTVO"]));
        }

        public virtual int Fill(DRZAVLJANSTVODataSet dataSet, int iDDRZAVLJANSTVO)
        {
            if (!this.FillByIDDRZAVLJANSTVO(dataSet, iDDRZAVLJANSTVO))
            {
                throw new DRZAVLJANSTVONotFoundException(string.Format(CultureInfo.InvariantCulture, this.resourceManager.GetString("inex"), new object[] { this.resourceManagerTables.GetString("DRZAVLJANSTVO") }));
            }
            return 0;
        }

        public virtual bool FillByIDDRZAVLJANSTVO(DRZAVLJANSTVODataSet dataSet, int iDDRZAVLJANSTVO)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DRZAVLJANSTVOSet = dataSet;
            this.rowDRZAVLJANSTVO = this.DRZAVLJANSTVOSet.DRZAVLJANSTVO.NewDRZAVLJANSTVORow();
            this.rowDRZAVLJANSTVO.IDDRZAVLJANSTVO = iDDRZAVLJANSTVO;
            try
            {
                this.LoadByIDDRZAVLJANSTVO(0, -1);
                dataSet.AcceptChanges();
            }
            finally
            {
                this.Cleanup();
            }
            if (this.RcdFound270 == 0)
            {
                return false;
            }
            return true;
        }

        public virtual int FillPage(DRZAVLJANSTVODataSet dataSet, int startRow, int maxRows)
        {
            this.InitializeMembers();
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.DRZAVLJANSTVOSet = dataSet;
            try
            {
                this.LoadChildDrzavljanstvo(startRow, maxRows);
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
            ReadWriteCommand command = this.connDefault.GetCommand("SELECT [IDDRZAVLJANSTVO], [NAZIVDRZAVLJANSTVO] FROM [DRZAVLJANSTVO] WITH (NOLOCK) WHERE [IDDRZAVLJANSTVO] = @IDDRZAVLJANSTVO ", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDRZAVLJANSTVO["IDDRZAVLJANSTVO"]));
            IDataReader reader = command.FetchData();
            if (command.HasMoreRows)
            {
                this.RcdFound270 = 1;
                this.rowDRZAVLJANSTVO["IDDRZAVLJANSTVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(reader, 0));
                this.rowDRZAVLJANSTVO["NAZIVDRZAVLJANSTVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(reader, 1));
                this.sMode270 = this.Gx_mode;
                this.Gx_mode = StatementType.Select;
                this.Gx_mode = this.sMode270;
            }
            else
            {
                this.RcdFound270 = 0;
            }
            reader.Close();
        }

        public virtual IDataParameter[] GetFillParameters()
        {
            if (this.fillDataParameters == null)
            {
                DbParameter parameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
                parameter.ParameterName = "IDDRZAVLJANSTVO";
                parameter.DbType = DbType.Int32;
                this.fillDataParameters = new DbParameter[] { parameter };
            }
            return this.fillDataParameters;
        }

        private int GetInternalRecordCount()
        {
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            this.cmDRZAVLJANSTVOSelect1 = this.connDefault.GetCommand("SELECT COUNT(*) FROM [DRZAVLJANSTVO] WITH (NOLOCK) ", false);
            this.DRZAVLJANSTVOSelect1 = this.cmDRZAVLJANSTVOSelect1.FetchData();
            if (this.DRZAVLJANSTVOSelect1.IsDBNull(0))
            {
                this.recordCount = 0;
            }
            else
            {
                this.recordCount = this.DRZAVLJANSTVOSelect1.GetInt32(0);
            }
            this.DRZAVLJANSTVOSelect1.Close();
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
            this.RcdFound270 = 0;
            this.scmdbuf = "";
            this.recordCount = 0;
            this._Gxremove = false;
            this.m__NAZIVDRZAVLJANSTVOOriginal = RuntimeHelpers.GetObjectValue(new object());
            this.m_WhereString = "";
            if (this.Transaction == null)
            {
                this.Transaction = (IDbTransaction) Thread.GetData(Thread.GetNamedDataSlot(DeklaritTransaction.TransactionSlotName));
            }
        }

        private void InitializeMembers()
        {
            this.DRZAVLJANSTVOSet = new DRZAVLJANSTVODataSet();
            this.Initialize();
            this.dsDefault = new DataStore(new SqlServer2005Handler(), "System.Data.SqlClient", Configuration.ConnectionString, DeklaritTransaction.TransactionSlotName);
        }

        private void InsertDrzavljanstvo()
        {
            this.CheckOptimisticConcurrencyDrzavljanstvo();
            this.AfterConfirmDrzavljanstvo();
            ReadWriteCommand command = this.connDefault.GetCommand("INSERT INTO [DRZAVLJANSTVO] ([IDDRZAVLJANSTVO], [NAZIVDRZAVLJANSTVO]) VALUES (@IDDRZAVLJANSTVO, @NAZIVDRZAVLJANSTVO)", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVDRZAVLJANSTVO", DbType.String, 50));
            }
            command.ErrorMask |= ErrorMask.DuplicateKeyError;
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDRZAVLJANSTVO["IDDRZAVLJANSTVO"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDRZAVLJANSTVO["NAZIVDRZAVLJANSTVO"]));
            command.ExecuteStmt();
            if (command.DupKey)
            {
                throw new DRZAVLJANSTVODuplicateKeyException(this.resourceManager.GetString("noupdate"));
            }
            this.OnDRZAVLJANSTVOUpdated(new DRZAVLJANSTVOEventArgs(this.rowDRZAVLJANSTVO, StatementType.Insert));
        }

        private void LoadByIDDRZAVLJANSTVO(int startRow, int maxRows)
        {
            bool enforceConstraints = this.DRZAVLJANSTVOSet.EnforceConstraints;
            this.DRZAVLJANSTVOSet.DRZAVLJANSTVO.BeginLoadData();
            this.ScanByIDDRZAVLJANSTVO(startRow, maxRows);
            this.DRZAVLJANSTVOSet.DRZAVLJANSTVO.EndLoadData();
            this.DRZAVLJANSTVOSet.EnforceConstraints = enforceConstraints;
            if (this.DRZAVLJANSTVOSet.DRZAVLJANSTVO.Count > 0)
            {
                this.rowDRZAVLJANSTVO = this.DRZAVLJANSTVOSet.DRZAVLJANSTVO[this.DRZAVLJANSTVOSet.DRZAVLJANSTVO.Count - 1];
            }
        }

        private void LoadChildDrzavljanstvo(int startRow, int maxRows)
        {
            this.CreateNewRowDrzavljanstvo();
            bool enforceConstraints = this.DRZAVLJANSTVOSet.EnforceConstraints;
            this.DRZAVLJANSTVOSet.DRZAVLJANSTVO.BeginLoadData();
            this.ScanStartDrzavljanstvo(startRow, maxRows);
            this.DRZAVLJANSTVOSet.DRZAVLJANSTVO.EndLoadData();
            this.DRZAVLJANSTVOSet.EnforceConstraints = enforceConstraints;
        }

        private void LoadDataDrzavljanstvo(int maxRows)
        {
            int num = 0;
            if (this.RcdFound270 != 0)
            {
                this.ScanLoadDrzavljanstvo();
                while ((this.RcdFound270 != 0) && (num != maxRows))
                {
                    num++;
                    this.LoadRowDrzavljanstvo();
                    this.CreateNewRowDrzavljanstvo();
                    this.ScanNextDrzavljanstvo();
                }
            }
            if (num > 0)
            {
                this.RcdFound270 = 1;
            }
            this.ScanEndDrzavljanstvo();
            if (this.DRZAVLJANSTVOSet.DRZAVLJANSTVO.Count > 0)
            {
                this.rowDRZAVLJANSTVO = this.DRZAVLJANSTVOSet.DRZAVLJANSTVO[this.DRZAVLJANSTVOSet.DRZAVLJANSTVO.Count - 1];
            }
        }

        private void LoadRowDrzavljanstvo()
        {
            this.AddRowDrzavljanstvo();
        }

        private void OnDRZAVLJANSTVOUpdated(DRZAVLJANSTVOEventArgs e)
        {
            if (this.DRZAVLJANSTVOUpdated != null)
            {
                DRZAVLJANSTVOUpdateEventHandler dRZAVLJANSTVOUpdatedEvent = this.DRZAVLJANSTVOUpdated;
                if (dRZAVLJANSTVOUpdatedEvent != null)
                {
                    dRZAVLJANSTVOUpdatedEvent(this, e);
                }
            }
        }

        private void OnDRZAVLJANSTVOUpdating(DRZAVLJANSTVOEventArgs e)
        {
            if (this.DRZAVLJANSTVOUpdating != null)
            {
                DRZAVLJANSTVOUpdateEventHandler dRZAVLJANSTVOUpdatingEvent = this.DRZAVLJANSTVOUpdating;
                if (dRZAVLJANSTVOUpdatingEvent != null)
                {
                    dRZAVLJANSTVOUpdatingEvent(this, e);
                }
            }
        }

        private void ReadRowDrzavljanstvo()
        {
            this.Gx_mode = Mode.FromRowState(this.rowDRZAVLJANSTVO.RowState);
            if (this.rowDRZAVLJANSTVO.RowState != DataRowState.Added)
            {
                this.m__NAZIVDRZAVLJANSTVOOriginal = RuntimeHelpers.GetObjectValue(this.rowDRZAVLJANSTVO["NAZIVDRZAVLJANSTVO", DataRowVersion.Original]);
            }
            else
            {
                this.m__NAZIVDRZAVLJANSTVOOriginal = RuntimeHelpers.GetObjectValue(this.rowDRZAVLJANSTVO["NAZIVDRZAVLJANSTVO"]);
            }
            this._Gxremove = this.rowDRZAVLJANSTVO.RowState == DataRowState.Deleted;
            if (this._Gxremove)
            {
                this.rowDRZAVLJANSTVO = (DRZAVLJANSTVODataSet.DRZAVLJANSTVORow) DataSetUtil.CloneOriginalDataRow(this.rowDRZAVLJANSTVO);
            }
        }

        private void ScanByIDDRZAVLJANSTVO(int startRow, int maxRows)
        {
            this.m_WhereString = " WHERE TM1.[IDDRZAVLJANSTVO] = @IDDRZAVLJANSTVO";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString270 + "  FROM [DRZAVLJANSTVO] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDDRZAVLJANSTVO]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString270, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDDRZAVLJANSTVO] ) AS DK_PAGENUM   FROM [DRZAVLJANSTVO] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString270 + " FROM [DRZAVLJANSTVO] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDDRZAVLJANSTVO] ";
            }
            this.cmDRZAVLJANSTVOSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            if (this.cmDRZAVLJANSTVOSelect4.IDbCommand.Parameters.Count == 0)
            {
                this.cmDRZAVLJANSTVOSelect4.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
            }
            this.cmDRZAVLJANSTVOSelect4.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDRZAVLJANSTVO["IDDRZAVLJANSTVO"]));
            this.DRZAVLJANSTVOSelect4 = this.cmDRZAVLJANSTVOSelect4.FetchData();
            this.RcdFound270 = 0;
            this.ScanLoadDrzavljanstvo();
            this.LoadDataDrzavljanstvo(maxRows);
        }

        private void ScanEndDrzavljanstvo()
        {
            this.DRZAVLJANSTVOSelect4.Close();
        }

        private void ScanLoadDrzavljanstvo()
        {
            this.Gx_mode = StatementType.Select;
            if (this.cmDRZAVLJANSTVOSelect4.HasMoreRows)
            {
                this.RcdFound270 = 1;
                this.rowDRZAVLJANSTVO["IDDRZAVLJANSTVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetInt32(this.DRZAVLJANSTVOSelect4, 0));
                this.rowDRZAVLJANSTVO["NAZIVDRZAVLJANSTVO"] = RuntimeHelpers.GetObjectValue(this.dsDefault.Db.GetString(this.DRZAVLJANSTVOSelect4, 1));
            }
        }

        private void ScanNextDrzavljanstvo()
        {
            this.cmDRZAVLJANSTVOSelect4.HasMoreRows = this.DRZAVLJANSTVOSelect4.Read();
            this.RcdFound270 = 0;
            this.ScanLoadDrzavljanstvo();
        }

        private void ScanStartDrzavljanstvo(int startRow, int maxRows)
        {
            this.m_WhereString = "";
            if (maxRows >= 0)
            {
                if (startRow == 0)
                {
                    this.scmdbuf = "SELECT TOP " + maxRows.ToString() + "  " + this.m_SelectString270 + "  FROM [DRZAVLJANSTVO] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDDRZAVLJANSTVO]";
                }
                else
                {
                    string[] strArray = new string[] { " SELECT * FROM ( SELECT  ", this.m_SelectString270, ", ROW_NUMBER() OVER  (  ORDER BY TM1.[IDDRZAVLJANSTVO] ) AS DK_PAGENUM   FROM [DRZAVLJANSTVO] TM1 WITH (NOLOCK) ", this.m_WhereString, " ) AS DK_PAGE WHERE DK_PAGENUM BETWEEN ", (startRow + 1).ToString(), " AND ", (startRow + maxRows).ToString() };
                    this.scmdbuf = string.Concat(strArray);
                }
            }
            else
            {
                this.scmdbuf = "SELECT " + this.m_SelectString270 + " FROM [DRZAVLJANSTVO] TM1 WITH (NOLOCK)" + this.m_WhereString + " ORDER BY TM1.[IDDRZAVLJANSTVO] ";
            }
            this.cmDRZAVLJANSTVOSelect4 = this.connDefault.GetCommand(this.scmdbuf, false);
            this.DRZAVLJANSTVOSelect4 = this.cmDRZAVLJANSTVOSelect4.FetchData();
            this.RcdFound270 = 0;
            this.ScanLoadDrzavljanstvo();
            this.LoadDataDrzavljanstvo(maxRows);
        }

        public virtual int Update(DataSet dataSet)
        {
            this.InitializeMembers();
            this.DRZAVLJANSTVOSet = (DRZAVLJANSTVODataSet) dataSet;
            this.connDefault = this.dsDefault.GetReadWriteConnection(this.daCurrentTransaction);
            if (this.DRZAVLJANSTVOSet == null)
            {
                throw new ArgumentException(this.resourceManager.GetString("nulldset"));
            }
            try
            {
                IEnumerator enumerator = null;
                this.connDefault.BeginTransaction();
                try
                {
                    enumerator = this.DRZAVLJANSTVOSet.DRZAVLJANSTVO.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        DRZAVLJANSTVODataSet.DRZAVLJANSTVORow current = (DRZAVLJANSTVODataSet.DRZAVLJANSTVORow) enumerator.Current;
                        this.rowDRZAVLJANSTVO = current;
                        if (Helpers.IsRowChanged(this.rowDRZAVLJANSTVO))
                        {
                            this.ReadRowDrzavljanstvo();
                            if (this.rowDRZAVLJANSTVO.RowState == DataRowState.Added)
                            {
                                this.InsertDrzavljanstvo();
                            }
                            else
                            {
                                if (this._Gxremove)
                                {
                                    this.Delete();
                                    continue;
                                }
                                this.UpdateDrzavljanstvo();
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

        private void UpdateDrzavljanstvo()
        {
            this.CheckOptimisticConcurrencyDrzavljanstvo();
            this.AfterConfirmDrzavljanstvo();
            ReadWriteCommand command = this.connDefault.GetCommand("UPDATE [DRZAVLJANSTVO] SET [NAZIVDRZAVLJANSTVO]=@NAZIVDRZAVLJANSTVO  WHERE [IDDRZAVLJANSTVO] = @IDDRZAVLJANSTVO", false);
            if (command.IDbCommand.Parameters.Count == 0)
            {
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@NAZIVDRZAVLJANSTVO", DbType.String, 50));
                command.IDbCommand.Parameters.Add(this.dsDefault.GetDbParameter("@IDDRZAVLJANSTVO", DbType.Int32));
            }
            command.SetParameter(0, RuntimeHelpers.GetObjectValue(this.rowDRZAVLJANSTVO["NAZIVDRZAVLJANSTVO"]));
            command.SetParameter(1, RuntimeHelpers.GetObjectValue(this.rowDRZAVLJANSTVO["IDDRZAVLJANSTVO"]));
            command.ExecuteStmt();
            this.OnDRZAVLJANSTVOUpdated(new DRZAVLJANSTVOEventArgs(this.rowDRZAVLJANSTVO, StatementType.Update));
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
        public class DRZAVLJANSTVODataChangedException : DataChangedException
        {
            public DRZAVLJANSTVODataChangedException()
            {
            }

            public DRZAVLJANSTVODataChangedException(string message) : base(message)
            {
            }

            protected DRZAVLJANSTVODataChangedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DRZAVLJANSTVODataChangedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DRZAVLJANSTVODataLockedException : DataLockedException
        {
            public DRZAVLJANSTVODataLockedException()
            {
            }

            public DRZAVLJANSTVODataLockedException(string message) : base(message)
            {
            }

            protected DRZAVLJANSTVODataLockedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DRZAVLJANSTVODataLockedException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        [Serializable]
        public class DRZAVLJANSTVODuplicateKeyException : DuplicateKeyException
        {
            public DRZAVLJANSTVODuplicateKeyException()
            {
            }

            public DRZAVLJANSTVODuplicateKeyException(string message) : base(message)
            {
            }

            protected DRZAVLJANSTVODuplicateKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DRZAVLJANSTVODuplicateKeyException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class DRZAVLJANSTVOEventArgs : EventArgs
        {
            private DRZAVLJANSTVODataSet.DRZAVLJANSTVORow m_dataRow;
            private System.Data.StatementType m_statementType;

            public DRZAVLJANSTVOEventArgs(DRZAVLJANSTVODataSet.DRZAVLJANSTVORow row, System.Data.StatementType statementType)
            {
                this.m_dataRow = row;
                this.m_statementType = statementType;
            }

            public DRZAVLJANSTVODataSet.DRZAVLJANSTVORow Row
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
        public class DRZAVLJANSTVONotFoundException : DataNotFoundException
        {
            public DRZAVLJANSTVONotFoundException()
            {
            }

            public DRZAVLJANSTVONotFoundException(string message) : base(message)
            {
            }

            protected DRZAVLJANSTVONotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            public DRZAVLJANSTVONotFoundException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public delegate void DRZAVLJANSTVOUpdateEventHandler(object sender, DRZAVLJANSTVODataAdapter.DRZAVLJANSTVOEventArgs e);

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

